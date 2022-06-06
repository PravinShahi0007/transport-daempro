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
    public partial class WebVac : System.Web.UI.Page
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
            try
            {
                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "الاجازات الرسمية";

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

                    LoadVacData();

                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = "الرئيسية";
                        UserTran.FormAction = "اختيار";
                        UserTran.Description = "اختيار صفحة الاجازات الرسمية";
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
                    Response.Redirect("GeneralServerError.aspx", false);
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }

        protected void LoadVacData()
        {
            try
            {
                //grdCodes.ShowFooter = (bool)((List<TblRoles>)(Session["Roll"]))[3].Pass121;
                Vac ax = new Vac();
                grdCodes.DataSource = ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                grdCodes.DataBind();

                if (grdCodes.Rows.Count < 1)
                {
                    List<Vac> Listax = new List<Vac>();
                    Listax.Add(ax);
                    grdCodes.DataSource = Listax;
                    grdCodes.DataBind();
                    grdCodes.Rows[0].Cells.Clear();
                }
                /*
                foreach (GridViewRow itm in grdCodes.Rows)
                {
                    ImageButton BtnEdit = itm.FindControl("BtnEdit") as ImageButton;
                    ImageButton BtnDelete = itm.FindControl("BtnDelete") as ImageButton;
                    if (BtnEdit != null) BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[3].Pass122;
                    if (BtnDelete != null) BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[3].Pass123;
                }
                 */
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
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }

        protected void grdCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdCodes.PageIndex = e.NewPageIndex;
                LoadVacData();
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
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }

        protected void grdCodes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdCodes.EditIndex = -1;
                LoadVacData();
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
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }

        protected void grdCodes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Insert"))
                {
                    ImageButton btnInsert = e.CommandSource as ImageButton;
                    if (btnInsert == null)
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    GridViewRow gvr = btnInsert.NamingContainer as GridViewRow;
                    if (gvr == null)
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    TextBox txtFDate = gvr.FindControl("txtFDate") as TextBox;
                    TextBox txtName = gvr.FindControl("txtName") as TextBox;

                    if (txtFDate == null || txtName == null)
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }
                    if (txtName.Text == "" || txtFDate.Text == "")
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "تاكد من أدخال البيانات المطلوبة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    Vac myAccess = new Vac();
                    myAccess.FDate = txtFDate.Text;
                    myAccess.Name = txtName.Text;

                    if (myAccess.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormName = "الاجازة الرسمية";
                            UserTran.FormAction = "اضافة";
                            UserTran.Description = "اضافة أجازة " + myAccess.Name + " من يوم  " + myAccess.FDate;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }

                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تم اضافة البيانات بنجاح";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, false), true);
                    }
                    else
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    LoadVacData();
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
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }

        protected void grdCodes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string FNo = grdCodes.DataKeys[e.RowIndex]["FNo"].ToString();
                GridViewRow gvr = grdCodes.Rows[e.RowIndex];
                Label lblFDate = gvr.FindControl("lblFDate") as Label;

                Vac myAccess = new Vac();
                myAccess.FDate = lblFDate.Text;

                if (!myAccess.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    e.Cancel = true;
                }
                else
                {
                    Transactions UserTran = new Transactions();
                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                    UserTran.UserName = Session["CurrentUser"].ToString();
                    UserTran.Description = "الغاء البند  " + lblFDate.Text + " من الاجازات  ";
                    UserTran.FormName = "الاجازات الرسمية";
                    UserTran.FormAction = "الغاء";
                    UserTran.IP = IPNetworking.GetIP4Address();
                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult.Text = "لقد تم حذف السجل بنجاح";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, false), true);
                    LoadVacData();
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
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }

    }
}