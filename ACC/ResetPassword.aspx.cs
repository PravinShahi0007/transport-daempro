using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class ResetPassword : System.Web.UI.Page
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
            try
            {
                ScriptManager.GetCurrent(this).RegisterPostBackControl(this.BtnConfirm);
                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = GetLocalResourceObject("Label4.Text").ToString();  // "تغيير كلمة المرور";


                    if (Request.QueryString["FMode"] != null)
                    {
                        if (Request.QueryString["FMode"].ToString() == "1") 
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")  moh.AddUserTrans(Session["CurrentUser"].ToString(), GetGlobalResourceObject("Resource", "Home").ToString(), GetGlobalResourceObject("Resource", "Select").ToString(), GetLocalResourceObject("ChangePassPage").ToString(), "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            txtReason.Visible = true;
                            ValReason.Enabled = true;
                            lblReason.Visible = true;

                            lblRstPass.Visible = true;
                            Home.Visible = true;
                        }
                        else
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetLocalResourceObject("Label4.Text").ToString(), GetGlobalResourceObject("Resource", "Select").ToString(), GetLocalResourceObject("RedirectChangePass").ToString(), "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                            txtReason.Visible = false;
                            ValReason.Enabled = false;
                            lblReason.Visible = false;

                            Home.Visible = false;
                            lblRstPass.Visible = false;
                        }
                    }
                    else
                    {
                        lblRstPass.Visible = false;
                        Home.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationManager.AppSettings["ExitOnError"].ToString() == "1")
                {
                    Session.Add("Error", ex);
                    Response.Redirect("GeneralServerError.aspx", false);
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = ex.Message.ToString();
                }
            }
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (txtOldPassword.Text == txtNewPassword.Text)
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = GetLocalResourceObject("MatchPassword").ToString();  // "خطأ كلمة المرور القديمة و الجديدة متطابقين";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(lblError.Text, true, false), true);
                    }
                    else
                    {
                        TblUsers x = new TblUsers();
                        x.UserName = Session["CurrentUser"].ToString();
                        if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), x.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        x = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                             where uitm.UserName == x.UserName
                             select uitm).FirstOrDefault();
                        if (x != null)
                        {
                            if (txtOldPassword.Text != x.Password)
                            {
                                lblError.ForeColor = System.Drawing.Color.Red;
                                lblError.Text = GetLocalResourceObject("InvalidPassword").ToString();  // "كلمة المرور الحالية غير صحيحة";  
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(lblError.Text, true, false), true);
                            }
                            else
                            {
                                    x.Password = txtNewPassword.Text;
                                    x.ChangePass = true;
                                    if (!x.Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        lblError.ForeColor = System.Drawing.Color.Red;
                                        lblError.Text = GetLocalResourceObject("ErrorUpdate").ToString();  // "خطأ أثناء تحديث البيانات ... حاول مرة أحرى";
                                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(lblError.Text, true, false), true);
                                    }
                                    else
                                    {
                                        if (Cache["Users" + Session["CNN2"].ToString()] != null) Cache.Remove("Users" + Session["CNN2"].ToString());
                                        TblUsers ax = new TblUsers();
                                        if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetLocalResourceObject("Label4.Text").ToString(), GetLocalResourceObject("Update").ToString(), GetLocalResourceObject("SuccessUpdate").ToString(), txtReason.Text, IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                        lblError.ForeColor = System.Drawing.Color.Green;
                                        lblError.Text = GetLocalResourceObject("SuccessUpdate").ToString(); //"تم تغيير كلمة المرور بنجاح";
                                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(lblError.Text, true, false), true);
                                        Response.Redirect("login.aspx", false);
                                    }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                if (ConfigurationManager.AppSettings["ExitOnError"].ToString() == "1")
                {
                    Session.Add("Error", ex);
                    Response.Redirect("GeneralServerError.aspx", false);
                }
                else
                {
                    lblError.Text = ex.Message.ToString();
                }
            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtNewPassword.Text = "";
                txtNewPassword2.Text = "";
                txtOldPassword.Text = "";
                lblError.Text = "";
            }
            catch (Exception ex)
            {
                if (ConfigurationManager.AppSettings["ExitOnError"].ToString() == "1")
                {
                    Session.Add("Error", ex);
                    Response.Redirect("GeneralServerError.aspx", false);
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = ex.Message.ToString();
                }
            }
        }
    }
}