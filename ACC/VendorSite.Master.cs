using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Web.Configuration;
using BLL;
using System.Configuration;
using System.Media;

namespace ACC
{
    public partial class VendorSite : System.Web.UI.MasterPage
    {
        public string vHomeRoleName
        {
            get
            {
                if (ViewState["HomeRoleName"] == null)
                {
                    ViewState["HomeRoleName"] = "Roll";
                }
                return ViewState["HomeRoleName"].ToString();
            }
            set { ViewState["HomeRoleName"] = value; }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            CultureInfo currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            CultureInfo newCulture = new CultureInfo(currentCulture.IetfLanguageTag);
            newCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            newCulture.DateTimeFormat.DateSeparator = "/";
            newCulture.NumberFormat.CurrencyDecimalDigits = 2;
            newCulture.NumberFormat.NumberNegativePattern = 0;
            newCulture.NumberFormat.CurrencyNegativePattern = 0;
            System.Threading.Thread.CurrentThread.CurrentCulture = newCulture;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnProcess_Click(object sender, EventArgs e)
        {
            //if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetGlobalResourceObject("Resource", "Home").ToString(), GetGlobalResourceObject("Resource", "Select").ToString(), GetGlobalResourceObject("Resource", "Tally").ToString(), "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
            //moh.Tally(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, short.Parse(Session["Branch"].ToString()));
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(GetGlobalResourceObject("Resource", "SuccessTally").ToString(), false, true), true); // "لقد تم تشغيل مطابقة الارصدة بنجاح"
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            //HttpContext.Current.Profile.SetPropertyValue("LastVisitedDate", moh.Nows());
            Response.Redirect(@"~\Logout.aspx", true);
        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {
        }

        protected void grdCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
        }

        protected void btnLangImg_Click(object sender, EventArgs e)
        {
        }


    }
}