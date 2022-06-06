using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class GeneralServerError : System.Web.UI.Page
    {
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
                if (Session["FullUser"] == null) Response.Redirect("logout.aspx", false);
                if (Session["Error"] != null)
                {
                    string myAccess = @"<div dir='ltr'><table dir='ltr' width='95%' style='background-color:#FCFDC4;border:1px solid #F3F9B7' cellspacing='7' border='0'><thead><tr><th scope='col' >Exception</th><th scope='col'>Value</th></tr></thead><tbody>";
                    myAccess += @"<tr><td style='width: 150px;'>User Name</td><td style=;width: 700px'>" + Session["FullUser"].ToString() + " - " + Session["CurrentUser"].ToString() + @"</td></tr>";
                    myAccess += @"<tr><td style='width: 150px;'>Date/Time</td><td style=;width: 700px'>" + moh.Nows().ToShortDateString() + " " + String.Format("{0:HH:mm:ss}", moh.Nows()) + @"</td></tr>";
                    myAccess += @"<tr><td style='width: 150px;'>IP</td><td style=;width: 700px'>" + Request.ServerVariables["remote_addr"].ToString() + @"</td></tr>";
                    myAccess += @"<tr><td style='width: 150px;'>Browser</td><td style=;width: 700px'>" + Request.ServerVariables["http_user_agent"].ToString() + @"</td></tr>";
                    myAccess += @"<tr><td style='width: 150px;'>Message</td><td style=;width: 700px'>" + ((Exception)Session["Error"]).Message.ToString() + @"</td></tr>";
                    if (((Exception)Session["Error"]).InnerException != null)
                    {
                        myAccess += @"<tr><td style='width: 150px;'>Inner Type</td><td style=;width: 700px'>" + ((Exception)Session["Error"]).InnerException.GetType() + @"</td></tr>";
                        myAccess += @"<tr><td style='width: 150px;'>Inner Message</td><td style=;width: 700px'>" + ((Exception)Session["Error"]).InnerException.Message.ToString() + @"</td></tr>";
                        myAccess += @"<tr><td style='width: 150px;'>Inner Source</td><td style=;width: 700px'>" + ((Exception)Session["Error"]).InnerException.Source + @"</td></tr>";
                        myAccess += @"<tr><td style='width: 150px;'>Inner Target Site</td><td style=;width: 700px'>" + ((Exception)Session["Error"]).InnerException.TargetSite.Name + @"</td></tr>";
                        if (((Exception)Session["Error"]).InnerException.StackTrace != null)
                        {
                            myAccess += @"<tr><td style='width: 150px;'>Inner Stack Trace</td><td style=;width: 700px'>" + ((Exception)Session["Error"]).InnerException.StackTrace + @"</td></tr>";
                        }
                    }
                    myAccess += @"<tr><td style='width: 150px;'>Type</td><td style=;width: 700px'>" + ((Exception)Session["Error"]).GetType() + @"</td></tr>";
                    myAccess += @"<tr><td style='width: 150px;'>Source</td><td style=;width: 700px'>" + ((Exception)Session["Error"]).Source + @"</td></tr>";
                    myAccess += @"<tr><td style='width: 150px;'>Target Site</td><td style=;width: 700px'>" + ((Exception)Session["Error"]).TargetSite.Name + @"</td></tr>";
                    if (((Exception)Session["Error"]).StackTrace != null)
                    {
                        myAccess += @"<tr><td style='width: 150px;'>Inner Stack Trace</td><td style=;width: 700px'>" + ((Exception)Session["Error"]).StackTrace + @"</td></tr>";
                    }
                    myAccess += @"</tbody></table></div>";
                    lblError.Text = myAccess;

                    moh.SendEmail("mohamed@isofttec.com", myAccess, "خطأ في نظام الناقلات البرية ", null);
                }
                System.Web.Security.FormsAuthentication.SignOut();
                Session.Abandon();
            }
        }
    }
}