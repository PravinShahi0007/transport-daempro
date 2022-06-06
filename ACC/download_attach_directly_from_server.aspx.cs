using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MailBee;
using MailBee.Mime;
using MailBee.ImapMail;
using MailBee.Pop3Mail;

// Downloads an attachment to the client by direct downloading that attachment
// from the e-mail server. No temporary file is created. The sample combines both functions:
// download the e-mail and get attachments links, and download attachments to the client if
// the user clicks their corresponding links.
//
// This is very effective for IMAP as IMAP allows you to download a particular attachment
// without downloading the entire message. With POP3 you'll need to download the entire message.
// Thus, if the message has 10 attachments, you'll need to download it 10 times to get them
// all. Due to this, it's more effective to use temp files with POP3.
//
// This sample, however, never uses temp files.

namespace Mail1
{
    public partial class download_attach_directly_from_server : System.Web.UI.Page
    {
        // <!-- BEGIN IMAP SPECIFIC

        string _logContents;

        // Downloads either the header and structure of the last e-mail in Inbox,
        // or (if partID not set) the header and body of the specified MIME part.
        // Attachment is an example of a MIME part.
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

            _logContents = imp.Log.GetMemoryLog();

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
                    string forceSaveFile = cbForceSaveFile.Checked ? "&save_file=yes" : string.Empty;

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
                Response.Write("<pre>" + Server.HtmlEncode(_logContents) + "</pre>");
                Response.End();
            }
        }

        // END IMAP SPECIFIC -->

        // <!-- BEGIN POP3 SPECIFIC

        // Downloads either the last e-mail in Inbox of the e-mail by the specified UID.
        // With POP3, it's not possible to work with attachments without downloading the
        // entire message. Thus, we download it entirely both times (to get the list of
        // attachments and to download a particular attachment to the web client).
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

                    string forceSaveFile = cbForceSaveFile.Checked ? "&save_file=yes" : string.Empty;

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

        // END POP3 SPECIFIC -->

        // Just displays some info to let you easily identify
        // for which e-mail the attachments are displayed.
        private void DisplayHeaders(MailMessage msg)
        {
            msg.Parser.HeadersAsHtml = true;
            lStatus.Text = "Downloaded OK";
            lUid.Text = msg.UidOnServer.ToString();
            lFrom.Text = msg.From.AsString;
            lTo.Text = msg.To.AsString;
            lCc.Text = msg.Cc.AsString;
            lSubject.Text = msg.Subject;
            lDate.Text = msg.Date.ToString();
            lSize.Text = (msg.SizeOnServer / 1024).ToString() + "KB";
            msg.Parser.HeadersAsHtml = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["host"] == null || (string)Session["mode"] != "imap_pop3")
            {
                lStatus.Text = "<a href=\"set_imap_pop3.aspx\">Configure IMAP/POP3 access</a> first!";
                pGmailPop3Comment.Visible = false;
                cbIncludeInline.Visible = false;
                cbForceSaveFile.Visible = false;
                return;
            }

            // If true, inline images will be displayed in the attachment list.
            bool treatLinkedResourcesAsAttachments = cbIncludeInline.Checked;

            string partID = Request.QueryString["part_id"];
            string uid = Request.QueryString["uid"];
            string attachFilename = Request.QueryString["filename"];
            bool forceSaveFile = (Request.QueryString["save_file"] == "yes");

            bool useImap = (bool)Session["imap"];

            if (useImap)
            {
                Envelope env = DownloadImapEnvelope(uid, partID);

                if (env != null)
                {
                    if (partID == null)
                    {
                        // List all attachments so that the user can click any.
                        DisplayHeaders(env.MessagePreview);
                        DisplayImapAttachmentList(env, treatLinkedResourcesAsAttachments);
                    }
                    else
                    {
                        // Download the selected attachment to the client.
                        DownloadImapAttachmentToWebClient(env, partID, attachFilename, forceSaveFile);
                    }
                }
                else
                {
                    lStatus.Text = "Inbox is empty or the requested e-mail is no longer on the server (may happen with Gmail/POP3)";
                }

                cbIncludeInline.Visible = (env != null);
                cbForceSaveFile.Visible = (env != null);
            }
            else
            {
                MailMessage msg = DownloadPop3Email(uid);
                if (msg != null)
                {
                    if (partID == null)
                    {
                        // List all attachments so that the user can click any.
                        DisplayHeaders(msg);
                        DisplayPop3AttachmentList(msg, treatLinkedResourcesAsAttachments);
                    }
                    else
                    {
                        // Download the selected attachment to the client.
                        DownloadPop3AttachmentToWebClient(
                            msg, int.Parse(partID), attachFilename, forceSaveFile);
                    }
                }
                else
                {
                    lStatus.Text = "Inbox is empty or the requested e-mail is no longer on the server (may happen with Gmail/POP3)";
                }

                cbIncludeInline.Visible = (msg != null);
                cbForceSaveFile.Visible = (msg != null);
            }
        }
    }
}