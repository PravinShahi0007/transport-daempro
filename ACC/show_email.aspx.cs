using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MailBee;
using MailBee.Mime;
using MailBee.ImapMail;
using MailBee.Pop3Mail;
using System.Text;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class show_email : System.Web.UI.Page
    {
        public string AreaNo
        {
            get
            {
                if (ViewState["AreaNo"] == null)
                {
                    ViewState["AreaNo"] = "00001";
                }
                return ViewState["AreaNo"].ToString();
            }
            set { ViewState["AreaNo"] = value; }
        }
        public string StoreNo
        {
            get
            {
                if (ViewState["StoreNo"] == null)
                {
                    ViewState["StoreNo"] = "1";
                }
                return ViewState["StoreNo"].ToString();
            }
            set { ViewState["StoreNo"] = value; }
        }

        private Envelope DownloadImapEnvelope(string uid, string partID)
        {
            string host = (string)Session["host"];
            int port = (int)Session["port"];
            string user = (string)Session["user"];
            string pass = (string)Session["pass"];

            // No need to display Gmail/POP3 warning with IMAP.
            pGmailPop3Comment.Visible = false;

            Imap imp = new Imap();

            imp.Log.MemoryLog = true;
            imp.Log.Enabled = true;

            if (port == 0)
            {
                imp.Connect(host);
            }
            else
            {
                imp.Connect(host, port);
            }
            imp.Login(user, pass);
            imp.SelectFolder("Inbox");

            EnvelopeCollection envelopes = null;
            if (imp.MessageCount > 0)
            {
                if (partID == null)
                {
                    // Download the e-mail header and structure of an e-mail in Inbox.
                    envelopes = imp.DownloadEnvelopes(
                        uid == null ? imp.MessageCount.ToString() : uid,
                        uid != null,
                        EnvelopeParts.MailBeeEnvelope |
                        EnvelopeParts.MessagePreview |
                        EnvelopeParts.BodyStructure, 0);
                }
                else
                {
                    // The list of FETCH keys to request from the server.
                    string[] fetchRequestKeys = new string[2];
                    fetchRequestKeys[0] = "BODY.PEEK[" + partID + ".MIME]";
                    fetchRequestKeys[1] = "BODY.PEEK[" + partID + "]";

                    // Download the header and body of the specified MIME part.
                    envelopes = imp.DownloadEnvelopes(
                        uid, true, EnvelopeParts.Uid, 0, null, fetchRequestKeys);
                }
            }

            imp.Disconnect();

            //_logContents = imp.Log.GetMemoryLog();

            if (envelopes != null && envelopes.Count > 0)
            {
                return envelopes[0];
            }

            return null;
        }

        // Displays the list of links to download attachments.
        private void DisplayImapAttachmentList(Envelope env,
            bool treatLinkedResourcesAsAttachments)
        {
            // Get body structures of all MIME parts as flat list.
            ImapBodyStructureCollection parts = env.BodyStructure.GetAllParts();
            StringBuilder sb = new StringBuilder();
            foreach (ImapBodyStructure part in parts)
            {
                string contentType = part.ContentType.ToLower();
                string disposition = (part.Disposition == null) ?
                    string.Empty : part.Disposition.ToLower();

                // Provide links only for attachments and, optionally,
                // for other objects except of the e-mail text body.
                if (disposition == "attachment" ||
                    (treatLinkedResourcesAsAttachments &&
                    !(part.IsMultipart ||
                    contentType == "text/plain" || contentType == "text/html")))
                {
                    if (sb.Length > 0)
                    {
                        sb.Append("; ");
                    }
                    string filename = part.SafeFilename;
                    string forceSaveFile = "&save_file=yes";

                    sb.Append(String.Format("<a href=\"download_attach_directly_from_server.aspx?" +
                        "filename={0}&part_id={1}&uid={2}{3}\">{4}</a>",
                        Server.UrlEncode(filename), part.PartID, env.Uid, forceSaveFile, filename));
                }
            }

            if (sb.Length > 0)
            {
                lAttachs.Text = sb.ToString();
            }
            else if (!treatLinkedResourcesAsAttachments)
            {
                lAttachs.Text = "No attachments (linked resources, if any, not counted as attachments)";
            }
            else
            {
                lAttachs.Text = "No attachments";
            }
        }

        // attachFilename can be null/empty as we can get the filename from the downloaded attachment.
        private void DownloadImapAttachmentToWebClient(
            Envelope env, string partID, string attachFilename, bool forceSaveFile)
        {
            // The list of FETCH keys to expect from the server in return to the request of
            // items listed in fetchRequestKeys (used in DownloadImapEnvelope).
            string[] fetchResponseKeys = new string[2];

            // For BODY.PEEK[...] request the server returns BODY[...] response.
            fetchResponseKeys[0] = "BODY[" + partID + ".MIME]";
            fetchResponseKeys[1] = "BODY[" + partID + "]";

            // Get MIME part header data.
            byte[] mimePartHeader = (byte[])env.GetEnvelopeItem(
                (string)fetchResponseKeys[0], true);

            // Get MIME part body data.
            byte[] mimePartBody = (byte[])env.GetEnvelopeItem(
                (string)fetchResponseKeys[1], true);

            if (mimePartHeader != null && mimePartBody != null)
            {
                // Build MIME part data from header data and body data.
                byte[] mimePartData = new byte[mimePartHeader.Length + mimePartBody.Length];
                System.Buffer.BlockCopy(mimePartHeader, 0, mimePartData, 0, mimePartHeader.Length);
                System.Buffer.BlockCopy(mimePartBody, 0, mimePartData,
                    mimePartHeader.Length, mimePartBody.Length);
                mimePartHeader = null;
                mimePartBody = null;

                // Build Attachment object from the MIME part data.
                MimePart part = MimePart.Parse(mimePartData);
                Attachment attach = new Attachment(part);

                Response.ClearHeaders();

                if (string.IsNullOrEmpty(attachFilename))
                {
                    attachFilename = attach.Filename;
                }

                if (forceSaveFile)
                {
                    Response.AppendHeader(
                        "Content-Disposition", "attachment; filename=\"" + attachFilename + "\"");
                    Response.ContentType = "application/octet-stream";
                }
                else
                {
                    Response.AppendHeader(
                        "Content-Disposition", "inline; filename=\"" + attachFilename + "\"");
                    Response.ContentType = attach.ContentType;
                }

                Response.BinaryWrite(attach.GetData());
                Response.End();
            }
            else
            {
                Response.Write("There is a problem with the IMAP server, it retured NIL instead of the required data. The IMAP log follows:");
                //Response.Write("<pre>" + Server.HtmlEncode(_logContents) + "</pre>");
                Response.End();
            }
        }

        private MailMessage DownloadPop3Email(string uid)
        {
            string host = (string)Session["host"];
            int port = (int)Session["port"];
            string user = (string)Session["user"];
            string pass = (string)Session["pass"];

            // Display special warning on weird behaviour of Gmail/POP3.
            pGmailPop3Comment.Visible = (host.ToLower() == "pop.gmail.com");

            MailMessage msg = null;

            Pop3 pop = new Pop3();

            if (port == 0)
            {
                pop.Connect(host);
            }
            else
            {
                pop.Connect(host, port);
            }

            // We need UID list as well.
            pop.InboxPreloadOptions = Pop3InboxPreloadOptions.Uidl;

            pop.Login(user, pass);

            int msgIndex = 0;

            if (uid == null && (pop.InboxMessageCount > 0))
            {
                // Download the last e-mail in Inbox.
                msgIndex = pop.InboxMessageCount;
            }
            else if (uid != null)
            {
                // When UID is specified, this means we either need to display the list of
                // attachments for that e-mail or download any of its attachments. We use
                // the same code both both options because with POP3 you'll have to download
                // the entire message to get any of its attachmens.
                msgIndex = pop.GetMessageIndexFromUid(uid);
            }

            if (msgIndex > 0)
            {
                msg = pop.DownloadEntireMessage(pop.InboxMessageCount);
            }

            pop.Disconnect();

            return msg;
        }

        // Displays the list of links to download attachments.
        private void DisplayPop3AttachmentList(MailMessage msg,
            bool treatLinkedResourcesAsAttachments)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < msg.Attachments.Count; i++)
            {
                Attachment attach = msg.Attachments[i];
                if (!attach.IsInline || treatLinkedResourcesAsAttachments)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append("; ");
                    }

                    string forceSaveFile = "&save_file=yes";

                    sb.Append(String.Format("<a href=\"download_attach_directly_from_server.aspx?" +
                        "filename={0}&part_id={1}&uid={2}{3}\">{4}</a><br/>",
                        Server.UrlEncode(attach.Filename), i.ToString(), msg.UidOnServer.ToString(),
                        forceSaveFile, attach.Filename));
                }
            }

            if (sb.Length > 0)
            {
                lAttachs.Text = sb.ToString();
            }
            else if (!treatLinkedResourcesAsAttachments)
            {
                lAttachs.Text = "No attachments (linked resources, if any, not counted as attachments)";
            }
            else
            {
                lAttachs.Text = "No attachments";
            }
        }

        // attachFilename can be null/empty as we can get the filename from the downloaded attachment.
        private void DownloadPop3AttachmentToWebClient(
            MailMessage msg, int index, string attachFilename, bool forceSaveFile)
        {
            Attachment attach = msg.Attachments[index];
            Response.ClearHeaders();

            if (string.IsNullOrEmpty(attachFilename))
            {
                attachFilename = attach.Filename;
            }

            if (forceSaveFile)
            {
                Response.AppendHeader(
                    "Content-Disposition", "attachment; filename=\"" + attachFilename + "\"");
                Response.ContentType = "application/octet-stream";
            }
            else
            {
                Response.AppendHeader(
                    "Content-Disposition", "inline; filename=\"" + attachFilename + "\"");
                Response.ContentType = attach.ContentType;
            }

            Response.BinaryWrite(attach.GetData());
            Response.End();
        }

        // Page index is zero-based.
        private int GetCurrentPageIndex(int pageSize, int totalCount, int currentOrdinalNumber)
        {
            return (totalCount - currentOrdinalNumber) / pageSize;
        }

        // Nearest UIDs allow for implementing "prev e-mail/next e-mail" mechanism.
        //
        // This version of the method can be used if the list of UIDs of all e-mails in the folder
        // is not known to the application. You can, of course, download this list at any time but
        // this is quite an expensive operation. If you, however, already have this list, use
        // another overload below.
        private UidCollection GetNearestImapUids(Imap imp, int ordinalNumber, long uid,
            out bool hasPrev, out bool hasNext)
        {
            for (; ; )
            {
                switch (imp.MessageCount)
                {
                    case 0:
                        hasPrev = false;
                        hasNext = false;
                        return new UidCollection();
                    case 1:
                        hasPrev = false;
                        hasNext = false;
                        UidCollection result = new UidCollection();
                        result.Add(uid);
                        return result;
                    default:
                        int fromOrdNumber;
                        int toOrdNumber;

                        int overallCount = 1;

                        if (ordinalNumber == 1)
                        {
                            fromOrdNumber = 1;
                            hasPrev = false;
                        }
                        else
                        {
                            fromOrdNumber = ordinalNumber - 1;
                            hasPrev = true;
                            overallCount++;
                        }

                        if (ordinalNumber == imp.MessageCount)
                        {
                            toOrdNumber = imp.MessageCount;
                            hasNext = false;
                        }
                        else
                        {
                            toOrdNumber = ordinalNumber + 1;
                            hasNext = true;
                            overallCount++;
                        }

                        UidCollection uids = (UidCollection)imp.Search(true,
                            fromOrdNumber.ToString() + ":" + toOrdNumber.ToString(), null);

                        int curPos = hasPrev ? 1 : 0;
                        if (overallCount == uids.Count && uids[curPos] == uid)
                        {
                            return uids;
                        }
                        else
                        {
                            int uidPos = Array.IndexOf(uids.ToArray(), uid, 0, uids.Count);
                            if (uidPos > -1)
                            {
                                if (uidPos < curPos)
                                {
                                    ordinalNumber--;
                                }
                                else if (uidPos > curPos)
                                {
                                    ordinalNumber++;
                                }
                            }
                            else
                            {
                                MessageNumberCollection nums = (MessageNumberCollection)imp.Search(false, "UID " + uid.ToString(), null);
                                if (nums.Count == 0)
                                {
                                    return new UidCollection();
                                }
                                else
                                {
                                    ordinalNumber = nums[0];
                                }
                            }
                            break;
                        }
                }
            }
        }

        // Another overload of GetNearestImapUids.
        // Either imp or allUids can be null, but not both.
        //
        // This verison of the method assumes the application has already downloaded the list
        // of all UIDs in the folder or doesn't mind if this method does this. Downloading
        // all the UIDs may slightly degrade performance.
        private UidCollection GetNearestImapUids(Imap imp, UidCollection allUids, long uid,
            out bool hasPrev, out bool hasNext)
        {
            if (allUids == null)
            {
                allUids = imp.Search();
            }

            int uidPos = allUids.IndexOf(uid);
            if (uidPos < 0)
            {
                hasPrev = false;
                hasNext = false;
                return new UidCollection();
            }

            UidCollection uids = new UidCollection();

            if (uidPos == 1)
            {
                hasPrev = false;
            }
            else
            {
                hasPrev = true;
                uids.Add(allUids[uidPos - 1]);
            }
            uids.Add(allUids[uidPos]);
            if (uidPos == uids.Count)
            {
                hasNext = false;
            }
            else
            {
                hasNext = true;
                uids.Add(allUids[uidPos + 1]);
            }

            return uids;
        }

        // Nearest UIDs allow for implementing "prev e-mail/next e-mail" mechanism.
        private string[] GetNearestPop3Uids(Pop3 pop, string uid,
            out bool hasPrev, out bool hasNext)
        {
            int uidPos = pop.GetMessageIndexFromUid(uid);
            if (uidPos < 0)
            {
                hasPrev = false;
                hasNext = false;
                return new string[0];
            }

            int overallCount = 1;
            if (uidPos == 1)
            {
                hasPrev = false;
            }
            else
            {
                hasPrev = true;
                overallCount++;
            }
            if (uidPos == pop.InboxMessageCount)
            {
                hasNext = false;
            }
            else
            {
                hasNext = true;
                overallCount++;
            }

            string[] uids = new string[overallCount];
            int addedItemCount = 0;

            // Previous e-mail.
            if (hasPrev)
            {
                uids[addedItemCount] = pop.GetMessageUidFromIndex(uidPos - 1);
                addedItemCount++;
            }

            // This e-mail.
            uids[addedItemCount] = uid;
            addedItemCount++;

            // Next e-mail.
            if (hasNext)
            {
                uids[addedItemCount] = pop.GetMessageUidFromIndex(uidPos + 1);
            }

            return uids;
        }

        // Used with IFRAME-based view of HTML e-mail in IMAP mode. In this case (as IFRAME is
        // a separate document), we need to create a separate connection to download the HTML body
        // from the IMAP server. For that, in the main frame we need to determine which part of
        // the message holds this body (so that IFRAME would know what to download). This method
        // does this job, it returns IMAP ID of the HTML body within the message.
        //
        // Note that with POP3 we re-download the entire message in IFRAME as POP3 does not allows
        // downloading particular parts of the message (except of the header).
        //
        // In your application you can, however, try another IFRAME approach as well. Download the
        // e-mail in a single connection from the e-mail server, then send the body to the client 
        // in encoded form (such as javascript string or XML), and on the client side use javascript
        // to write this string into IFRAME. This will work fine with both IMAP and POP3 (no need to
        // re-download anything) but will increase CPU load and memory usage in the client browser.
        // May be efficient for AJAX applications as they use XML or JSON to exchange data anyway.
        private string GetHtmlBodyPartID(ImapBodyStructure bodyStruct)
        {
            ImapBodyStructureCollection parts = bodyStruct.GetAllParts();

            foreach (ImapBodyStructure part in parts)
            {
                string contentType = part.ContentType.ToLower();
                string disposition = (part.Disposition == null ? string.Empty : part.Disposition.ToLower());
                if (disposition != "attachment" && contentType == "text/html")
                {
                    return part.PartID;
                }
            }

            return null;
        }

        // Downloads an e-mail from the e-mail server and optionally sets the IMAP ID of HTML body within the e-mail
        // (this is used with IFRAME view of HTML body).
        private MailMessage DownloadEmail(out int page, out string olderUid, out string newerUid, ref string imapPartID)
        {
            MailMessage msg = null;

            string host = (string)Session["host"];
            int port = (int)Session["port"];
            bool useImap = (bool)Session["imap"];
            string user = (string)Session["user"];
            string pass = (string)Session["pass"];
            string uid = Request.QueryString["uid"];

            int pageSize = -1;
            if (Request.QueryString["page_size"] != null)
            {
                int.TryParse(Request.QueryString["page_size"], out pageSize);
            }

            olderUid = null;
            newerUid = null;

            bool hasPrev;
            bool hasNext;

            // Display special warning on weird behaviour of Gmail/POP3.
            pGmailPop3Comment.Visible = (host.ToLower() == "pop.gmail.com");

            page = -1;

            if (useImap)
            {
                // Get e-mail from an IMAP inbox.
                Imap imp = new Imap();
                if (port == 0)
                {
                    imp.Connect(host);
                }
                else
                {
                    imp.Connect(host, port);
                }
                imp.Login(user, pass);
                imp.SelectFolder("Inbox");

                if (imp.MessageCount > 0)
                {
                    // If UID not specified, download the last e-mail.
                    EnvelopeCollection envs = imp.DownloadEnvelopes(uid != null ? uid : imp.MessageCount.ToString(), uid != null, EnvelopeParts.BodyStructure | EnvelopeParts.MessagePreview, -1);
                    if (envs.Count > 0 && envs[0].IsValid)
                    {
                        msg = envs[0].MessagePreview;
                        imapPartID = GetHtmlBodyPartID(envs[0].BodyStructure);

                        UidCollection uids = GetNearestImapUids(imp, msg.IndexOnServer, (long)msg.UidOnServer, out hasPrev, out hasNext);
                        if (hasPrev)
                        {
                            olderUid = uids[0].ToString();
                        }
                        if (hasNext)
                        {
                            newerUid = uids[hasPrev ? 2 : 1].ToString();
                        }

                        if (pageSize > 0)
                        {
                            page = GetCurrentPageIndex(pageSize, imp.MessageCount, msg.IndexOnServer);
                        }
                    }
                }

                imp.Disconnect();
            }
            else
            {
                // POP3 version.
                Pop3 pop = new Pop3();
                if (port == 0)
                {
                    pop.Connect(host);
                }
                else
                {
                    pop.Connect(host, port);
                }

                // We want to display UID of the message as well.
                pop.InboxPreloadOptions = Pop3InboxPreloadOptions.Uidl;

                pop.Login(user, pass);

                if (pop.InboxMessageCount > 0)
                {
                    int msgIndex;

                    // If UID not specified, download the last e-mail.
                    if (uid == null)
                    {
                        msgIndex = pop.InboxMessageCount;
                    }
                    else
                    {
                        msgIndex = pop.GetMessageIndexFromUid(uid);
                    }
                    if (msgIndex > 0)
                    {
                        msg = pop.DownloadEntireMessage(msgIndex);

                        string[] uids = GetNearestPop3Uids(pop, (string)msg.UidOnServer, out hasPrev, out hasNext);
                        if (hasPrev)
                        {
                            olderUid = uids[0];
                        }
                        if (hasNext)
                        {
                            newerUid = uids[hasPrev ? 2 : 1];
                        }

                        if (pageSize > 0)
                        {
                            page = GetCurrentPageIndex(pageSize, pop.InboxMessageCount, msg.IndexOnServer);
                        }
                    }
                }

                pop.Disconnect();
            }

            return msg;
        }

        protected string _olderUid;
        protected string _newerUid;
        protected bool _displayIframe;
        protected string _uid;
        protected string _partID;
        protected string _page;

        private void EnableHtmlDisplayModeControls(bool enable)
        {
            rbHtmlAsPlainText.Enabled = enable;
            rbHtmlAsIs.Enabled = enable;
            rbHtmlInIframe.Enabled = enable;
        }

        protected override void InitializeCulture()
        {
            HttpCookie cultureCookie = Request.Cookies["Lang"];
            String Lang = (cultureCookie != null) ? cultureCookie.Value : null;
            if (!string.IsNullOrEmpty(Lang))
            {
                String selectedLanguage = Lang;
                UICulture = selectedLanguage;
                Culture = selectedLanguage;

                Thread.CurrentThread.CurrentCulture =
                    CultureInfo.CreateSpecificCulture(selectedLanguage);
                Thread.CurrentThread.CurrentUICulture = new
                    CultureInfo(selectedLanguage);
            }

            CultureInfo newCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            newCulture.NumberFormat.CurrencyDecimalDigits = 2;
            newCulture.NumberFormat.NumberNegativePattern = 0;
            newCulture.NumberFormat.CurrencyNegativePattern = 0;
            newCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            newCulture.DateTimeFormat.DateSeparator = "/";
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;

            base.InitializeCulture();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["AreaNo"] != null)
                {
                    AreaNo = Request.QueryString["AreaNo"].ToString();
                }
                else
                {
                    AreaNo = Session["AreaNo"].ToString();
                }
                if (Request.QueryString["StoreNo"] != null)
                {
                    StoreNo = Request.QueryString["StoreNo"].ToString();
                }

                if (Session["host"] == null || (string)Session["mode"] != "imap_pop3")
                {
                    lStatus.Text = "<a href=\"set_imap_pop3.aspx\">Configure IMAP/POP3 access</a> first!";
                    lUid.Text = string.Empty;
                    lFrom.Text = string.Empty;
                    lTo.Text = string.Empty;
                    lCc.Text = string.Empty;
                    lSubject.Text = string.Empty;
                    lDate.Text = string.Empty;
                    lSize.Text = string.Empty;
                    lBodyText.Text = string.Empty;
                    pGmailPop3Comment.Visible = false;
                    cbIncludeInline.Visible = false;
                    EnableHtmlDisplayModeControls(false);
                    _displayIframe = false;
                    return;
                }

                _partID = null;

                int pageIndex;

                MailMessage msg = DownloadEmail(out pageIndex, out _olderUid, out _newerUid, ref _partID);

                if (pageIndex > -1)
                {
                    _page = pageIndex.ToString();
                }
                else
                {
                    _page = null;
                }

                // From now on, the message is retrieved and it no longer matters
                // how we got it, with POP3 or IMAP.
                if (msg != null)
                {
                    // Plain-text e-mails cannot be rendered directly because the browser
                    // can only render HTML. So we need to convert plain-text into HMTL.
                    msg.Parser.PlainToHtmlMode = PlainToHtmlAutoConvert.IfNoHtml;

                    // If plain-text view is desired for HTML e-mails...
                    if (rbHtmlAsPlainText.Checked)
                    {
                        // ...and the message has HTML part, we'll display it but
                        // in plain-text alike manner (rich HTML => plain-text => simple HTML).
                        msg.Parser.HtmlToSimpleHtmlMode = HtmlToSimpleHtmlAutoConvert.IfHtml;
                    }

                    // Enable HTML encoding of the headers and display them.
                    msg.Parser.HeadersAsHtml = true;
                    lStatus.Text = "Downloaded OK";
                    lUid.Text = msg.UidOnServer.ToString();
                    lFrom.Text = msg.From.AsString;
                    lTo.Text = msg.To.AsString;
                    lCc.Text = msg.Cc.AsString;
                    lSubject.Text = msg.Subject;
                    lDate.Text = msg.Date.ToString();
                    lSize.Text = (msg.Size / 1024).ToString() + "KB";

                    // Turn off HMTL encoding (we are not using non-encoded header values
                    // but your code may do this in case if it not only displays them but
                    // also processes them somehow).
                    msg.Parser.HeadersAsHtml = false;

                    // Denotes whether we want to skip inline pictures and other linked resources
                    // when listing attachment filenames.
                    bool treatLinkedResourcesAsAttachments = cbIncludeInline.Checked;

                    // Display attachment filenames.
                    if (msg.Attachments.Count > 0)
                    {
                        if (msg.Attachments.Count == msg.Attachments.InlineCount &&
                            !treatLinkedResourcesAsAttachments)
                        {
                            // All attachments are inline and we want real attachments only.
                            lAttachs.Text = "No attachments (linked resources not counted)";
                        }
                        else
                        {
                            bool useImap = (bool)Session["imap"];
                            string forceSaveFile = "&save_file=yes";
                            string partID = null;
                            if (useImap)
                            {
                                Envelope env = DownloadImapEnvelope(msg.UidOnServer.ToString(), partID);

                                if (env != null)
                                {
                                    if (partID == null)
                                    {
                                        // List all attachments so that the user can click any.
                                        //DisplayHeaders(env.MessagePreview);
                                        DisplayImapAttachmentList(env, treatLinkedResourcesAsAttachments);
                                    }
                                    else
                                    {
                                        // Download the selected attachment to the client.
                                        //DownloadImapAttachmentToWebClient(env, partID, attachFilename, forceSaveFile);
                                    }
                                }
                                else
                                {
                                    //lStatus.Text = "Inbox is empty or the requested e-mail is no longer on the server (may happen with Gmail/POP3)";
                                }
                            }
                            else
                            {
                                MailMessage msg2 = DownloadPop3Email(msg.UidOnServer.ToString());
                                if (msg2 != null)
                                {
                                    if (partID == null)
                                    {
                                        // List all attachments so that the user can click any.
                                        //DisplayHeaders(msg);
                                        DisplayPop3AttachmentList(msg2, treatLinkedResourcesAsAttachments);
                                    }
                                    else
                                    {
                                        // Download the selected attachment to the client.
                                        //DownloadPop3AttachmentToWebClient(msg, int.Parse(partID), attachFilename, forceSaveFile);
                                    }
                                }
                                else
                                {
                                    //lStatus.Text = "Inbox is empty or the requested e-mail is no longer on the server (may happen with Gmail/POP3)";
                                }
                            }
                            /*

                            StringBuilder sb = new StringBuilder();
                            for (int i = 0; i < msg.Attachments.Count; i++)
                            {
                                Attachment attach = msg.Attachments[i];
                                if (!attach.IsInline || treatLinkedResourcesAsAttachments)
                                {
                                    if (sb.Length > 0)
                                    {
                                        sb.Append("; ");
                                    }

                                    

                                    sb.Append(String.Format("<a target='_blank' href=\"download_attach_directly_from_server.aspx?" +
                                        "filename={0}&part_id={1}&uid={2}{3}\">{4}</a><br/>",
                                        Server.UrlEncode(attach.Filename), "2", msg.UidOnServer.ToString(),
                                        forceSaveFile, attach.Filename));
                                }
                            }
                            if (sb.Length > 0)
                            {
                                lAttachs.Text = sb.ToString();
                            }
                            else if (!treatLinkedResourcesAsAttachments)
                            {
                                lAttachs.Text = "No attachments (linked resources, if any, not counted as attachments)";
                            }
                            else
                            {
                                lAttachs.Text = "No attachments";
                            }
                             */
                        }
                        cbIncludeInline.Enabled = true;
                    }
                    else
                    {
                        lAttachs.Text = "No attachments";
                        cbIncludeInline.Enabled = false;
                    }

                    // HTML-display-mode controls make sense only if HTML body is available in the e-mail.
                    if (msg.IsBodyAvail("text/html", true))
                    {
                        lBodyFormat.Text = "HTML";
                        EnableHtmlDisplayModeControls(true);
                    }
                    else if (msg.IsBodyAvail("text/plain", true))
                    {
                        lBodyFormat.Text = "Plain-text";
                        EnableHtmlDisplayModeControls(false);
                    }
                    else
                    {
                        lBodyFormat.Text = "Other";
                        EnableHtmlDisplayModeControls(false);
                    }

                    _displayIframe = rbHtmlInIframe.Checked && msg.IsBodyAvail("text/html", true);
                    _uid = msg.UidOnServer.ToString();

                    if (!_displayIframe)
                    {
                        // Display the plain-text of the e-mail. Note that we read BodyHtmlText,
                        // not BodyPlainText because we actually need HTML version of plain-text.
                        lBodyText.Text = msg.BodyHtmlText;
                    }
                }
                else
                {
                    lStatus.Text = "Inbox is empty or the requested e-mail is no longer on the server (may happen with Gmail/POP3) or the requested e-mail is no longer on the server";
                }
                cbIncludeInline.Visible = (msg != null);
            }
        }
    }
}