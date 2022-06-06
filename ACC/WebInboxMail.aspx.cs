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
using System.Threading;
using System.Globalization;
using BLL;
using System.Web.Configuration;

namespace ACC
{
    public partial class WebInboxMail : System.Web.UI.Page
    {
        protected const int PageSize = 50;

        // Total count of e-mails in the Inbox.
        private int _totalCount;
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
        // Page index is zero-based, message indices are 1-based. If page < 0, lists all e-mails on one page.
        // Paging is in reverse order, from newer e-mails to older. E.g. if a mailbox
        // has 100 e-mails total and we display 10 e-mails per page, the page #0 displays
        // the e-mails from #100 to #91 inclusive.
        // With POP3, use startIndex and msgCount; with IMAP, startIndex and endIndex.
        private bool SetIndicesForPage(int msgTotalCount, int page, int msgPerPageCount,
            out int startIndex, out int msgCount, out int endIndex)
        {
            if (page < 0)
            {
                if (msgTotalCount == 0)
                {
                    startIndex = 0;
                    msgCount = 0;
                    endIndex = 0;
                    return false;
                }
                else
                {
                    startIndex = 1;
                    msgCount = msgTotalCount;
                    endIndex = msgCount;
                    return true;
                }
            }
            else if (msgTotalCount < (page + 1) * msgPerPageCount)
            {
                if (msgTotalCount < (page * msgPerPageCount) + 1)
                {
                    startIndex = 0;
                    msgCount = 0;
                    endIndex = 0;
                    return false;
                }
                else
                {
                    startIndex = 1;
                    msgCount = msgTotalCount - (page * msgPerPageCount);
                    endIndex = msgCount;
                    return true;
                }
            }
            else
            {
                startIndex = msgTotalCount + 1 - ((page + 1) * msgPerPageCount);
                msgCount = msgPerPageCount;
                endIndex = startIndex + msgPerPageCount - 1;
                return true;
            }
        }

        protected string MakeLink(string text, string uid, int pageSize)
        {
            return String.Format("<a target='_blank' href={0}?uid={1}&page_size={2}&AreaNo={4}&StoreNo={5}&back=list>{3}</a>",
                "show_email.aspx", HttpUtility.UrlEncode(uid), pageSize.ToString(), HttpUtility.HtmlEncode(text),AreaNo,StoreNo);
        }

        private MailMessageCollection DownloadEmailList(int page, int pageSize, out int totalCount)
        {
            string host = (string)Session["host"];
            int port = (int)Session["port"];
            bool useImap = (bool)Session["imap"];
            string user = (string)Session["user"];
            string pass = (string)Session["pass"];

            int startIndex;
            int msgCount;
            int endIndex;
            MailMessageCollection msgHeaders = null;

            totalCount = 0;

            if (useImap)
            {
                pGmailPop3Comment.Visible = false;

                // Get the last e-mail from an IMAP inbox.
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

                totalCount = imp.MessageCount;

                if (SetIndicesForPage(imp.MessageCount, page, pageSize,
                    out startIndex, out msgCount, out endIndex))
                {
                    // We could have also used DownloadEnvelopes if the sample were IMAP only.
                    // DownloadEnvelopes is more flexible (because envelopes are more flexible
                    // than e-mail messages).
                    msgHeaders = imp.DownloadMessageHeaders(
                        startIndex.ToString() + ":" + endIndex.ToString(), false);
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

                // We need e-mail sizes and UIDs.
                pop.InboxPreloadOptions =
                    Pop3InboxPreloadOptions.List | Pop3InboxPreloadOptions.Uidl;

                pop.Login(user, pass);

                totalCount = pop.InboxMessageCount;

                if (SetIndicesForPage(pop.InboxMessageCount, page, pageSize,
                        out startIndex, out msgCount, out endIndex))
                {
                    msgHeaders = pop.DownloadMessageHeaders(startIndex, msgCount);
                }

                pop.Disconnect();
            }

            return msgHeaders;
        }

        private void FillTableWithData(int page)
        {
            MailMessageCollection msgHeaders = DownloadEmailList(page, PageSize, out _totalCount);

            if (msgHeaders != null)
            {
                // We want newer messages first.
                msgHeaders.Reverse();

                _msgs = msgHeaders;
                _pageCount = (_totalCount - 1) / PageSize + 1;
                if (_pageCount > 10) _pageCount = 10;
                _curPage = page;
            }
        }

        protected MailMessageCollection _msgs = null;
        protected int _curPage;
        protected int _pageCount;

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
                if (Request.QueryString["AreaNo"] != null) AreaNo = Request.QueryString["AreaNo"].ToString();
                else
                {
                    if (Session["AreaNo"] != null) AreaNo = Session["AreaNo"].ToString();
                }

                if (Request.QueryString["StoreNo"] != null) StoreNo = Request.QueryString["StoreNo"].ToString();
                else
                {
                    if (Session["StoreNo"] == null) Session["StoreNo"] = 1;
                    StoreNo = Session["StoreNo"].ToString();
                }

                // Check if the user has configured IMAP/POP3 settings.
                if (Session["host"] == null || (string)Session["mode"] != "imap_pop3")
                {
                    TblUsers myUser = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), myUser.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myUser.UserName = Session["CurrentUser"].ToString();
                    myUser = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                              where uitm.UserName == myUser.UserName
                              select uitm).FirstOrDefault();
                    if (myUser != null)
                    {
                        if (myUser.Email != "" && myUser.EmailPassword != "")
                        {
                            Session["mode"] = "imap_pop3";
                            Session["host"] = "23.91.117.86";       // "mail.naqelat.com";

                            if (RadioButtonList1.SelectedIndex == 0) Session["imap"] = true;
                            else Session["imap"] = false;
                            //Session["imap"] = true;
                            Session["port"] = 0;

                            Session["user"] = myUser.Email;
                            Session["pass"] = myUser.EmailPassword;

                            pConfigureImapPop3AccessAlert.Visible = false;
                        }
                        else
                        {
                            pConfigureImapPop3AccessAlert.Visible = true;
                            pGmailPop3Comment.Visible = false;
                            return;
                        }
                    }
                    else
                    {
                        pConfigureImapPop3AccessAlert.Visible = true;
                        pGmailPop3Comment.Visible = false;
                        return;
                    }
                }
                else
                {
                    pConfigureImapPop3AccessAlert.Visible = false;
                }

                // Display special warning on weird behaviour of Gmail/POP3.
                pGmailPop3Comment.Visible = (((string)Session["host"]).ToLower() == "pop.gmail.com");

                int page;
                int.TryParse(Request.QueryString["page"], out page);

                // Display the message list.
                FillTableWithData(page);
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(RadioButtonList1.SelectedIndex == 0) Session["imap"] = true;
            else Session["imap"] = false;

            int page;
            int.TryParse(Request.QueryString["page"], out page);

            // Display the message list.
            FillTableWithData(page);
        }
    }
}