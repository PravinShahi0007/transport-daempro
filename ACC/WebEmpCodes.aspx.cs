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
    public partial class WebEmpCodes : System.Web.UI.Page
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
                    this.Page.Header.Title = "الاكواد العامة";

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

                    LoadCodesData();

                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = "الرئيسية";
                        UserTran.FormAction = "اختيار";
                        UserTran.Description = "اختيار صفحة الاكواد العامة";
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
                grdCodes.ShowFooter = (bool)((List<TblRoles>)(Session["Roll"]))[3].Pass121;
                Codes ax = new Codes();
                ax.Branch = short.Parse(Session["Branch"].ToString());
                ax.Ftype = short.Parse(ddlFtype.SelectedValue);
                if (Cache["LastCodes" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCodes" + Session["CNN2"].ToString(), ax.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                grdCodes.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                       where itm.Ftype == short.Parse(ddlFtype.SelectedValue)
                                       select itm).ToList();
                grdCodes.DataBind();

                if (grdCodes.Rows.Count < 1)
                {
                    List<Codes> Listax = new List<Codes>();                    
                    Listax.Add(ax);
                    grdCodes.DataSource = Listax;
                    grdCodes.DataBind();
                    grdCodes.Rows[0].Cells.Clear();
                }
                foreach (GridViewRow itm in grdCodes.Rows)
                {
                    ImageButton BtnEdit = itm.FindControl("BtnEdit") as ImageButton;
                    ImageButton BtnDelete = itm.FindControl("BtnDelete") as ImageButton;
                    if (BtnEdit != null) BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[3].Pass122;
                    if (BtnDelete != null) BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[3].Pass123;
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


        protected void grdCodes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string Code = grdCodes.DataKeys[e.RowIndex]["Code"].ToString();
                GridViewRow gvr = grdCodes.Rows[e.RowIndex];
                TextBox txtName1 = gvr.FindControl("txtName1") as TextBox;
                TextBox txtName2 = gvr.FindControl("txtName2") as TextBox;

                if (txtName1 == null || txtName2 == null)
                {
                    e.Cancel = true;
                    LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true,false), true); 
                    return;
                }

                Codes myAccess = new Codes();
                myAccess.Branch = short.Parse(Session["Branch"].ToString());
                myAccess.Ftype = short.Parse(ddlFtype.SelectedValue);
                myAccess.Code = int.Parse(Code);
                myAccess.Name1 = txtName1.Text;
                myAccess.Name2 = txtName2.Text;


                if (!myAccess.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    e.Cancel = true;
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true); 
                }
                else
                {
                    updateCache();
                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = "الاكواد العامة";
                        UserTran.FormAction = "تعديل";
                        UserTran.Description = "تعديل بيانات الاكواد العامة " + myAccess.Name1 + " من بيانات  " + ddlFtype.SelectedItem.Text;
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    grdCodes.EditIndex = -1;
                    LoadCodesData();
                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false,false), true); 
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

        protected void grdCodes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                //e.NewSelectedIndex = -1;
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

        protected void grdCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdCodes.PageIndex = e.NewPageIndex;
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

        protected void grdCodes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdCodes.EditIndex = -1;
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

        protected void grdCodes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Insert"))
                {
                    ImageButton btnInsert = e.CommandSource as ImageButton;
                    if (btnInsert == null) {
                        grdCodes_RowCancelingEdit(sender, null);
                        return; }

                    GridViewRow gvr = btnInsert.NamingContainer as GridViewRow;
                    if (gvr == null) {
                        grdCodes_RowCancelingEdit(sender, null);
                        return; }

                    TextBox txtName1 = gvr.FindControl("txtName1") as TextBox;
                    TextBox txtName2 = gvr.FindControl("txtName2") as TextBox;

                    if (txtName1 == null || txtName2 == null)
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true ,false), true); 
                        return;
                    }
                    if (txtName1.Text == "")
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "تاكد من أدخال البيانات المطلوبة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true ,false), true); 
                        return;
                    }

                    Codes myAccess = new Codes();
                    myAccess.Branch = short.Parse(Session["Branch"].ToString());
                    myAccess.Ftype = short.Parse(ddlFtype.SelectedValue);
                    myAccess.Name1 = txtName1.Text;
                    myAccess.Name2 = txtName2.Text;

                    if (myAccess.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        updateCache();
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormName = "الاكواد العامة";
                            UserTran.FormAction = "اضافة";
                            UserTran.Description = "اضافة بند في الاكواد العامة " + myAccess.Name1 + " من بيانات  " + ddlFtype.SelectedItem.Text;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }

                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تم اضافة البيانات بنجاح";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false , false), true); 
                    }
                    else
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true , false), true); 
                    }
                    LoadCodesData();
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

        protected void grdCodes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string Code = grdCodes.DataKeys[e.RowIndex]["Code"].ToString();

                Codes myAccess = new Codes();
                myAccess.Branch = short.Parse(Session["Branch"].ToString());
                myAccess.Ftype = short.Parse(ddlFtype.SelectedValue);
                myAccess.Code = short.Parse(Code);

                bool verror = false;
                SEmp myemp = new SEmp();
                if (Cache["Emps" + Session["CNN2"].ToString()] == null) Cache.Insert("Emps" + Session["CNN2"].ToString(), myemp.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                // Pending work check if exists in other files
                if (ddlFtype.SelectedIndex == 0) // الجنسية
                {
                    if (((List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()])).Where(p => p.Nat == myAccess.Code).Count() > 0) verror = true;
                }
                else if (ddlFtype.SelectedIndex == 1) // الوظيفة
                {
                    if (((List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()])).Where(p => p.Job == myAccess.Code).Count() > 0) verror = true;
                }
                else if (ddlFtype.SelectedIndex == 2) // القسم
                {
                    if (((List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()])).Where(p => p.Section == myAccess.Code).Count() > 0) verror = true;
                }
                else if (ddlFtype.SelectedIndex == 3) // المؤهل
                {
                    if (((List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()])).Where(p => p.Certificate == myAccess.Code).Count() > 0) verror = true;
                }
                else if (ddlFtype.SelectedIndex == 4) // محل أصدار 
                {
                    if (((List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()])).Where(p => p.PaperLoc1 == myAccess.Code || p.PaperLoc2 == myAccess.Code || p.PaperLoc3 == myAccess.Code || p.PaperLoc4 == myAccess.Code || p.PaperLoc5 == myAccess.Code || p.PaperLoc6 == myAccess.Code || p.PaperLoc7 == myAccess.Code || p.PaperLoc8 == myAccess.Code || p.PaperLoc9 == myAccess.Code || p.PaperLoc10 == myAccess.Code).Count() > 0) verror = true;
                }
                else if (ddlFtype.SelectedIndex == 5) // الديانة
                {
                    if (((List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()])).Where(p => p.Reginal == myAccess.Code).Count() > 0) verror = true;
                }
                else if (ddlFtype.SelectedIndex == 6) // مكان الميلاد
                {
                    if (((List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()])).Where(p => p.BirthPlace == myAccess.Code).Count() > 0) verror = true;
                }
                else if (ddlFtype.SelectedIndex == 7) // البنك
                {
                    if (((List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()])).Where(p => p.Bank == myAccess.Code).Count() > 0) verror = true;
                }
                else if (ddlFtype.SelectedIndex == 8)  // الكفيل
                {
                    if (((List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()])).Where(p => p.Sponsor == myAccess.Code).Count() > 0) verror = true;
                }

                if (verror)
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "لا يمكن الغاء البند حيث انه مرتبط ببيانات أخرى";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    e.Cancel = true;
                    return;
                }

                if (!myAccess.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true , false), true); 
                    e.Cancel = true;
                }
                else
                {
                    updateCache();
                    Transactions UserTran = new Transactions();
                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                    UserTran.UserName = Session["CurrentUser"].ToString();
                    UserTran.Description = "الغاء البند  " + Code + " من بيانات  " + ddlFtype.SelectedItem.Text;
                    UserTran.FormName = "الاكواد العامة";
                    UserTran.FormAction = "الغاء";
                    UserTran.IP = IPNetworking.GetIP4Address();
                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult.Text = "لقد تم حذف السجل بنجاح";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false , false), true); 
                    LoadCodesData();
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

        protected void grdCodes_RowEditing(object sender, GridViewEditEventArgs e)
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

        protected void btnUpdate_Load(object sender, EventArgs e)
        {
            ((ImageButton)sender).Visible = true;
        }

        public void updateCache()
        {
            if (Cache["LastCodes" + Session["CNN2"].ToString()] != null) Cache.Remove("LastCodes" + Session["CNN2"].ToString());
            Codes ax = new Codes();
            ax.Branch = short.Parse(Session["Branch"].ToString());       
            Cache.Insert("LastCodes" + Session["CNN2"].ToString(), ax.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
        }

    }
}