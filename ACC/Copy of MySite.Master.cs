using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Web.Configuration;
using BLL;

namespace ACC
{
    public partial class MySite : System.Web.UI.MasterPage
    {
        protected void Page_PreInit(object sender , EventArgs e)
        {
            CultureInfo currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            CultureInfo newCulture = new CultureInfo(currentCulture.IetfLanguageTag);
            newCulture.NumberFormat.CurrencyDecimalDigits = 2;
            newCulture.NumberFormat.NumberNegativePattern = 0;
            newCulture.NumberFormat.CurrencyNegativePattern = 0;
            System.Threading.Thread.CurrentThread.CurrentCulture = newCulture;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["Branch"] = "1";
                Session["Modal"] = true;

                if (!Page.IsPostBack)
                {
                    if (Session["CurrentUser"] == null || Session["FullUser"] == null)
                    {
                        Response.Redirect("logout.aspx");
                    }
                    else
                    {
                        LblUser.Text = Session["FullUser"].ToString();
                    }
                    if (Session["Roll"] == null)
                    {
                        Response.Redirect("logout.aspx");
                    }
                    else
                    {
                        lblData.Text = Session["CNN2"].ToString();

                        MyConfig mySetting = new MyConfig();
                        mySetting.Branch = short.Parse(Session["Branch"].ToString());
                        mySetting = mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (mySetting != null)
                        {
                            Label1.Text = mySetting.CompanyName;
                        }
                        li1.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass10;
                        li2.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass11;
                        li3.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass12;
                        li4.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass13;
                        li47.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass14;
                        li14.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass15;
                        li15.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass16;
                        li48.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass17;
                        li5.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass18;
                        li6.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass19;
                        li7.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass24;
                        li10.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass25;
                        li12.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass26;
                        li17.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass35;
                        li21.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass40;
                        li22.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass41;
                        li23.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass42;
                        li24.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass43;
                        li25.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass44;
                        li26.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass45;
                        li13.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass46;
                        li44.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass47;
                        li29.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass60;
                        li30.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass61;
                    }
                }
            }
            finally
            {

            }
        }

        protected void BtnProcess_Click(object sender, EventArgs e)
        {
            Transactions UserTran = new Transactions();
            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
            UserTran.UserName = Session["CurrentUser"].ToString();
            UserTran.FormName = "الرئيسية";
            UserTran.FormAction = "اختيار";
            UserTran.Description = "تم اختيار تشغيل نظام مطابقة الأرصدة";
            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

            moh.Tally(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, short.Parse(Session["Branch"].ToString()));
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage("لقد تم تشغيل مطابقة الارصدة بنجاح", false, true), true);
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            //HttpContext.Current.Profile.SetPropertyValue("LastVisitedDate", moh.Nows());
            Response.Redirect(@"~\Logout.aspx", true);
        }
    }
}