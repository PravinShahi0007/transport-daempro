using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using BLL;
using System.Configuration;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class WebStartMsg : System.Web.UI.Page
    {
        public string AreaNo
        {
            get
            {
                if (ViewState["AreaNo"] == null)
                {
                    ViewState["AreaNo"] = "00000";
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
            try
            {
                if (!Page.IsPostBack)
                {
                    LoadCodesData();
                    this.Page.Header.Title = "أعدادات بيانات الاتصال و حسابات البنوك";
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

                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = "الرئيسية";
                        UserTran.FormAction = "اختيار";
                        UserTran.Description = "اختيار صفحة أعدادات بيانات الاتصال وحسابات البنوك";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    //BtnNew.Visible = (bool)((TblRoles)(Session["Roll"])).Pass131;
                    //BtnEdit.Visible = (bool)((TblRoles)(Session["Roll"])).Pass132;
                    //BtnDelete.Visible = (bool)((TblRoles)(Session["Roll"])).Pass133;

                }
                else
                {
                    LblCodesResult.Text = "";
                }

            }
            catch (Exception ex)
            {
                if (ConfigurationManager.AppSettings["ExitOnError"].ToString() == "1")
                {
                    Session.Add("Error", ex);
                    Response.Redirect("GeneralServerError.aspx",false);
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }

        protected void LoadCodesData()
        {
            try
            {
                TblStart ax = new TblStart();
                ax.FType = short.Parse(ddlFtype.SelectedValue);
                grdCodes.DataSource = ax.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                grdCodes.DataBind();
            }
            catch (Exception ex)
            {
                if (ConfigurationManager.AppSettings["ExitOnError"].ToString() == "1")
                {
                    Session.Add("Error", ex);
                    Response.Redirect("GeneralServerError.aspx",false);
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }
        
        protected void ddlFtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadCodesData();
            }
            catch (Exception ex)
            {
                if (ConfigurationManager.AppSettings["ExitOnError"].ToString() == "1")
                {
                    Session.Add("Error", ex);
                    Response.Redirect("GeneralServerError.aspx",false);
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }

        protected void CheckUpdates()
        {
            bool vupdate = false;
            foreach (GridViewRow itm in grdCodes.Rows)
            {
                TextBox Fd1 = itm.FindControl("txtFd1") as TextBox;
                TextBox Fd2 = itm.FindControl("txtFd2") as TextBox;
                TextBox Fd3 = itm.FindControl("txtFd3") as TextBox;
                TextBox Fd4 = itm.FindControl("txtFd4") as TextBox;
                TextBox Fd5 = itm.FindControl("txtFd5") as TextBox;
                string FType = grdCodes.DataKeys[itm.RowIndex]["FType"].ToString();
                string FNo = grdCodes.DataKeys[itm.RowIndex]["FNo"].ToString();
                if (Fd1 != null && Fd2 != null && Fd3 != null && Fd4 != null && Fd5 != null && FType != null && FNo != null )
                {
                    TblStart myStart = new TblStart();
                    myStart.FType = short.Parse(FType);
                    myStart.FNo = short.Parse(FNo);
                    myStart = myStart.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if(myStart != null)
                    {
                        if (Fd1.Text != myStart.Fd1 || Fd2.Text != myStart.Fd2 || Fd3.Text != myStart.Fd3 || Fd4.Text != myStart.Fd4 || Fd5.Text != myStart.Fd5)
                        {
                            myStart = new TblStart();
                            myStart.FType = short.Parse(FType);
                            myStart.FNo = short.Parse(FNo);
                            myStart.Fd1 = Fd1.Text;
                            myStart.Fd2 = Fd2.Text;
                            myStart.Fd3 = Fd3.Text;
                            myStart.Fd4 = Fd4.Text;
                            myStart.Fd5 = Fd5.Text;
                            myStart.Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            vupdate = true;
                       }
                    }
                }
            }
            if (vupdate)
            {
                if (Cache["Starter" + Session["CNN2"].ToString()] != null) Cache.Remove("Starter" + Session["CNN2"].ToString());
                TblStart myStart = new TblStart();
                Cache.Insert("Starter" + Session["CNN2"].ToString(), myStart.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, false), true); 
            }
        }

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CheckUpdates();
            }
            catch (Exception ex)
            {
                if (ConfigurationManager.AppSettings["ExitOnError"].ToString() == "1")
                {
                    Session.Add("Error", ex);
                    Response.Redirect("GeneralServerError.aspx",false);
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }
    }
}