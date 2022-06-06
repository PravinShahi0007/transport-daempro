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
using System.Drawing;
using System.Globalization;
using System.Threading;
using BLL;
using System.Web.Configuration;
namespace ACC
{
    public partial class set_imap_pop3 : System.Web.UI.Page
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
            // If ViewState does not hold the page state yet, restore it from Session.
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

                if (ViewState["active"] == null)
                {
                    if (Session["host"] != null && (string)Session["mode"] == "imap_pop3")
                    {
                        tbHost.Text = (string)Session["host"];
                        int port = (int)Session["port"];
                        tbPort.Text = (port == 0) ? string.Empty : port.ToString();
                        if ((bool)Session["imap"])
                        {
                            rbImap.Checked = true;
                        }
                        else
                        {
                            rbPop3.Checked = true;
                        }
                        tbUsername.Text = (string)Session["user"];
                        tbPassword.Text = (string)Session["pass"];
                    }

                    ViewState["active"] = "yes";
                }

                bool isImapLicensed = false;
                bool isPop3Licensed = false;
                bool isImapKeyCorrect = false;
                bool isPop3KeyCorrect = false;
                //tbLicenseKey.Text = "MN100-0EC6C6F9C66AC688C69973F9D051-6A4F"; // tbLicenseKey.Text.Trim();

                if (tbLicenseKey.Text != string.Empty && !tbLicenseKey.Text.StartsWith("["))
                {
                    try
                    {
                        MailBee.Global.LicenseKey = tbLicenseKey.Text;
                        isImapKeyCorrect = true;
                    }
                    catch (MailBeeLicenseException) { }
                }
                else
                {
                    isImapKeyCorrect = true;
                }
                try
                {
                    Imap imp = new Imap();
                    isImapLicensed = true;
                }
                catch (MailBeeLicenseException) { }

                if (tbLicenseKey.Text != string.Empty && !tbLicenseKey.Text.StartsWith("["))
                {
                    try
                    {
                        MailBee.Global.LicenseKey = tbLicenseKey.Text;
                        isPop3KeyCorrect = true;
                    }
                    catch (MailBeeLicenseException) { }
                }
                else
                {
                    isPop3KeyCorrect = true;
                }
                try
                {
                    Pop3 pop = new Pop3();
                    isPop3Licensed = true;
                }
                catch (MailBeeLicenseException) { }

                if (isImapLicensed)
                {
                    if (isImapKeyCorrect)
                    {
                        lImapKeyStatus.Text = "[IMAP OK]";
                    }
                    else
                    {
                        lImapKeyStatus.Text = "[IMAP USABLE]";
                    }
                    lImapKeyStatus.ForeColor = Color.Blue;
                }
                else
                {
                    lImapKeyStatus.Text = "[IMAP N/A]";
                    lImapKeyStatus.ForeColor = Color.Red;
                }
                if (isPop3Licensed)
                {
                    if (isPop3KeyCorrect)
                    {
                        lPop3KeyStatus.Text = "[POP3 OK]";
                    }
                    else
                    {
                        lPop3KeyStatus.Text = "[POP3 USABLE]";
                    }
                    lPop3KeyStatus.ForeColor = Color.Blue;
                }
                else
                {
                    lPop3KeyStatus.Text = "[POP3 N/A]";
                    lPop3KeyStatus.ForeColor = Color.Red;
                }

                if (isImapLicensed && isPop3Licensed)
                {
                    if (tbLicenseKey.Text == string.Empty)
                    {
                        tbLicenseKey.Text = "[Valid license found in web.config or registry]";
                        tbLicenseKey.ForeColor = Color.Blue;
                    }
                }
                else if (tbLicenseKey.Text.StartsWith("["))
                {
                    tbLicenseKey.Text = string.Empty;
                }

                tbHost.Text = "mail.naqelat.com";
                TblUsers myUser = new TblUsers();
                if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), myUser.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myUser.UserName = Session["CurrentUser"].ToString();
                myUser = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                          where uitm.UserName == myUser.UserName
                          select uitm).FirstOrDefault();
                if (myUser != null)
                {
                    tbUsername.Text = myUser.Email;
                }
            }
        }

        private void SetResult(bool isError, string msg, Logger memoryLogger)
        {
            lResult.ForeColor = isError ? Color.Red : Color.Blue;
            lResult.Text = msg;
            string log = (memoryLogger != null) ? memoryLogger.GetMemoryLog() : null;
            if (log != null)
            {
                lLog.Text = Server.HtmlEncode(log);
            }
            else
            {
                lLog.Text = string.Empty;
            }
        }

        // Test the current settings and save them into Session on success.
        protected void btnTest_Click(object sender, EventArgs e)
        {
            int msgCount = 0;
            string host = tbHost.Text.Trim();
            bool useImap = rbImap.Checked;
            int port = 0;
            string user = tbUsername.Text.Trim();
            string pass = tbPassword.Text.Trim();
            

            Logger memoryLogger = null;
            if (tbPort.Text != string.Empty)
            {
                if (!int.TryParse(tbPort.Text.Trim(), out port))
                {
                    SetResult(true, "Can't parse port.", null);
                    return;
                }
            }

            Imap imp = null;
            Pop3 pop = null;

            try
            {
                if (useImap)
                {
                    imp = new Imap();
                    imp.Log.MemoryLog = true;
                    imp.Log.Enabled = true;
                    memoryLogger = imp.Log;
                    if (port > 0)
                    {
                        imp.Connect(host, port);
                    }
                    else
                    {
                        // Connect to default port (143, or 993 for Gmail.com).
                        imp.Connect(host);
                    }
                    imp.Login(user, pass);
                    imp.SelectFolder("Inbox");
                    msgCount = imp.MessageCount;
                    imp.Disconnect();
                }
                else
                {
                    pop = new Pop3();
                    pop.Log.MemoryLog = true;
                    pop.Log.Enabled = true;
                    memoryLogger = pop.Log;
                    if (port > 0)
                    {
                        pop.Connect(host, port);
                    }
                    else
                    {
                        // Connect to default port (110, or 995 for Gmail.com and Live.com).
                        pop.Connect(host);
                    }
                    pop.Login(user, pass);
                    msgCount = pop.InboxMessageCount;
                    pop.Disconnect();
                }
            }
            catch (MailBeeException ex)
            {
                if (imp != null && imp.IsConnected)
                {
                    imp.Disconnect();
                }
                if (pop != null && pop.IsConnected)
                {
                    pop.Disconnect();
                }
                //SetResult(true, ex.GetType().Name + " occurred, " + ex.Message, memoryLogger);
                SetResult(true, "حدث خطأ اثناء الاتصال بالبريد تاكد من الايميل و كلمة المرور الصحيحة" + ex.Message, memoryLogger);
                return;
            }

            if (msgCount == 0)
            {
                SetResult(false, "تم الاتصال وحفظ البيانات بنجاح", memoryLogger);
                //SetResult(true, "The connection succeeded and the settings have been saved, " +
                 //   "but the Inbox of this account was empty.<br/>Send some e-mails to this account " +
                 //   "before you can start using samples which read e-mails from its Inbox.", memoryLogger);
                // Although we claim there is an error, we still save the server settings because they are correct
                // (we just have no messages to display since Inbox is empty).
            }
            else
            {
                SetResult(false, "تم الاتصال وحفظ البيانات بنجاح", memoryLogger);
            }

            Session["mode"] = "imap_pop3";
            Session["host"] = host;
            Session["imap"] = useImap;
            Session["port"] = port;
            Session["user"] = user;
            Session["pass"] = pass;

            TblUsers myUser = new TblUsers();
            if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), myUser.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            myUser.UserName = Session["CurrentUser"].ToString();
            myUser = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                      where uitm.UserName == myUser.UserName
                      select uitm).FirstOrDefault();
            if (myUser != null)
            {
                myUser.Email = user;
                myUser.EmailPassword = pass;
                myUser.Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            }
        }
    }
}