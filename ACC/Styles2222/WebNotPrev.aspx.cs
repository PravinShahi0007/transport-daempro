using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using BLL;
using System.Web.Configuration;

namespace ACC.Styles
{
    public partial class WebNotPrev : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Page.Header.Title = "دخول غير مسموح به";

                if (Session["CurrentUser"] != null)
                {
                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = "دخول غير مسموح به";
                        UserTran.FormAction = "تسجيل خروج";
                        UserTran.Description = "تم تسجيل خروج من النظام";
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }
                }
                System.Web.Security.FormsAuthentication.SignOut();
                Session.Abandon();
            }
        }
    }
}