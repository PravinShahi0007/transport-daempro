using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using System.Configuration;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class WebRVou : System.Web.UI.Page
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
        public List<Vou> VouData
        {
            get
            {
                if (ViewState["VouData"] == null)
                {
                    ViewState["VouData"] = new List<Vou>();
                }
                return (List<Vou>)ViewState["VouData"];
            }
            set
            {
                ViewState["VouData"] = value;

            }
        }

        public void EditMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = true;    // && (bool)((List<TblRoles>)(Session[RoleName]))[1].Pass215;
            BtnEdit.Visible = true;     // && (bool)((List<TblRoles>)(Session[RoleName]))[1].Pass212;
            BtnNew.Visible = false;
            BtnDelete.Visible = true;       // && (bool)((List<TblRoles>)(Session[RoleName]))[1].Pass213;
        }

        public void NewMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            //txtVouNo.ReadOnly = false;
            //txtVouNo.BackColor = System.Drawing.Color.White;

            BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = true;      // && (bool)((List<TblRoles>)(Session[RoleName]))[1].Pass211;
            BtnDelete.Visible = false;
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
                    this.Page.Header.Title = "سندات القبض المجمعة";
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
                    LoadVouData();
                    BtnClear_Click(sender, null);
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

        protected void LoadVouData()
        {
            try
            {
                grdCodes.DataSource = VouData;
                grdCodes.DataBind();

                if (grdCodes.Rows.Count < 1)
                {
                    Vou ax = new Vou();
                    VouData.Add(ax);
                    grdCodes.DataSource = VouData;
                    grdCodes.DataBind();
                    grdCodes.Rows[0].Controls.Clear();
                    grdCodes.Rows[0].Cells.Clear();
                    VouData.Remove(ax);
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

        protected void ddlRecordsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                grdCodes.PageSize = int.Parse(ddlRecordsPerPage.SelectedValue);
                LoadVouData();
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
                    if (btnInsert == null)
                    {
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    GridViewRow gvr = btnInsert.NamingContainer as GridViewRow;
                    if (gvr == null)
                    {
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    TextBox txtDebit = gvr.FindControl("txtDebit") as TextBox;
                    TextBox txtCredit = gvr.FindControl("txtCredit") as TextBox;
                    TextBox txtCode = gvr.FindControl("txtCode") as TextBox;
                    TextBox txtName = gvr.FindControl("txtName") as TextBox;
                    TextBox txtRemark = gvr.FindControl("txtRemark") as TextBox;
                    TextBox txtCostCenter = gvr.FindControl("txtCostCenter") as TextBox;
                    TextBox txtProject = gvr.FindControl("txtProject") as TextBox;
                    HiddenField lblCostCenter = gvr.FindControl("lblCostCenterCode") as HiddenField;
                    HiddenField lblProject = gvr.FindControl("lblProjectCode") as HiddenField;

                    if (txtDebit == null || txtCredit == null || txtCode == null || txtName == null || txtRemark == null || txtCostCenter == null || txtProject == null || lblCostCenter == null || lblProject == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }
                    if (txtDebit.Text == "") txtDebit.Text = "0.00";
                    if (txtCredit.Text == "") txtCredit.Text = "0.00";

                    if (moh.StrToDouble(txtDebit.Text) > 0 && moh.StrToDouble(txtCredit.Text) > 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب ان يكون الحساب أما مدين أو دائن";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    if (moh.StrToDouble(txtDebit.Text) == 0 && moh.StrToDouble(txtCredit.Text) == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب إدخال مبلغ مدين أو دائن";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    Acc myAcc = new Acc();
                    myAcc.Branch = short.Parse(Session["Branch"].ToString());
                    myAcc.Code = txtCode.Text;
                    if (!myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الحساب غير معرف من قبل";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }
                    else
                    {
                        // Check to force Entering of Cost Center
                        if ((bool)myAcc.CheckCostCenter && lblCostCenter.Value == "")
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الحساب مرتبط بمراكز التكلفة ... يجب أختيار مركز تكلفة";
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }
                        // Check to force Entering of Emp
                    }

                    // Check Existing Cost Center
                    if (lblCostCenter.Value != "")
                    {
                        CostCenter myCostCenter = new CostCenter();
                        myCostCenter.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCostCenter.Code = lblCostCenter.Value;
                        myCostCenter = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                        where citm.Code == myCostCenter.Code
                                        select citm).FirstOrDefault();
                        if (myCostCenter == null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "مركز التكلفة غير معرف من قبل";
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }
                    }

                    // Check Existing Project
                    if (lblProject.Value != "")
                    {
                        AccProject myProject = new AccProject();
                        myProject.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["LastProject" + Session["CNN2"].ToString()] == null) Cache.Insert("LastProject" + Session["CNN2"].ToString(), myProject.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myProject.Code = lblProject.Value;
                        myProject = (from itm in (List<AccProject>)(Cache["LastProject" + Session["CNN2"].ToString()])
                                     where itm.Code == myProject.Code
                                     select itm).FirstOrDefault();
                        if (myProject == null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "المشروع غير معرف من قبل";
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }
                    }

                    // Check Existing Emp

                    Vou myAccess = new Vou();
                    myAccess.sno = (short)(VouData.Count + 1);
                    myAccess.Debit = moh.StrToDouble(txtDebit.Text);
                    myAccess.Credit = moh.StrToDouble(txtCredit.Text);
                    myAccess.Code = txtCode.Text;
                    myAccess.Name = txtName.Text;
                    myAccess.Project = txtProject.Text;
                    myAccess.ProjectCode = lblProject.Value;
                    myAccess.CostCenter = txtCostCenter.Text;
                    myAccess.CostCenterCode = lblCostCenter.Value;
                    myAccess.Remark = txtRemark.Text;

                    txtProject.ToolTip = "";
                    txtCostCenter.ToolTip = "";

                    VouData.Add(myAccess);
                    MakeSum();
                    LoadVouData();

                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult.Text = "لقد تم اضافة البند بنجاح";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, false), true);
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

        public void MakeSum()
        {
            double db = 0, cr = 0;
            foreach (Vou itm in VouData)
            {
                db += itm.Debit;
                cr += itm.Credit;
            }
            lblTotalDB.Text = string.Format("{0:N2}", db);
            lblTotalCR.Text = string.Format("{0:N2}", cr);
            if (db - cr != 0)
            {
                lblDiff.ForeColor = System.Drawing.Color.Red;
                lblDiff.Text = string.Format("{0:N2}", Math.Abs(db - cr));
            }
            else
            {
                lblDiff.ForeColor = System.Drawing.Color.Green;
                lblDiff.Text = string.Format("{0:N2}", db - cr);
            }
        }

        protected void grdCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdCodes.PageIndex = e.NewPageIndex;
                LoadVouData();
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
                LoadVouData();
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
                string sno = grdCodes.DataKeys[e.RowIndex]["sno"].ToString();
                GridViewRow gvr = grdCodes.Rows[e.RowIndex];

                if (sno == null || gvr == null)
                {
                    e.Cancel = true;
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "لقد حدث خطأ أثناء تعديل البيانات ... حاول مرة أخرى";
                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    return;
                }

                TextBox txtDebit = gvr.FindControl("txtDebit2") as TextBox;
                TextBox txtCredit = gvr.FindControl("txtCredit2") as TextBox;
                TextBox txtCode = gvr.FindControl("txtCode2") as TextBox;
                TextBox txtName = gvr.FindControl("txtName2") as TextBox;
                TextBox txtRemark = gvr.FindControl("txtRemark2") as TextBox;
                TextBox txtCostCenter = gvr.FindControl("txtCostCenter2") as TextBox;
                TextBox txtProject = gvr.FindControl("txtProject2") as TextBox;
                TextBox txtCostCenterCode = gvr.FindControl("txtCostCenterCode") as TextBox;
                TextBox txtProjectCode = gvr.FindControl("txtProjectCode") as TextBox;

                if (txtDebit == null || txtCredit == null || txtCode == null || txtName == null || txtRemark == null || txtCostCenter == null || txtProject == null || txtCostCenterCode == null || txtProjectCode == null)
                {
                    e.Cancel = true;
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "لقد حدث خطأ أثناء تعديل البيانات ... حاول مرة أخرى";
                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    return;
                }

                if (txtDebit.Text == "") txtDebit.Text = "0.00";
                if (txtCredit.Text == "") txtCredit.Text = "0.00";

                if (moh.StrToDouble(txtDebit.Text) > 0 && moh.StrToDouble(txtCredit.Text) > 0)
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب ان يكون الحساب أما مدين أو دائن";
                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    return;
                }

                if (moh.StrToDouble(txtDebit.Text) == 0 && moh.StrToDouble(txtCredit.Text) == 0)
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال مبلغ مدين أو دائن";
                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    return;
                }

                Acc myAcc = new Acc();
                myAcc.Branch = short.Parse(Session["Branch"].ToString());
                myAcc.Code = txtCode.Text;
                if (!myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "رقم الحساب غير معرف من قبل";
                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    return;
                }
                else
                {
                    // Check to force Entering of Cost Center
                    if ((bool)myAcc.CheckCostCenter && txtCostCenterCode.Text == "")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الحساب مرتبط بمراكز التكلفة ... يجب أختيار مركز تكلفة";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }
                    // Check to force Entering of Emp
                }

                // Check Existing Cost Center
                if (txtCostCenterCode.Text != "")
                {
                    CostCenter myCostCenter = new CostCenter();
                    myCostCenter.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myCostCenter.Code = txtCostCenterCode.Text;
                    myCostCenter = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                    where citm.Code == myCostCenter.Code
                                    select citm).FirstOrDefault();
                    if (myCostCenter == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "مركز التكلفة غير معرف من قبل";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }
                }

                // Check Existing Project
                if (txtProjectCode.Text != "")
                {
                    AccProject myProject = new AccProject();
                    myProject.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastProject" + Session["CNN2"].ToString()] == null) Cache.Insert("LastProject" + Session["CNN2"].ToString(), myProject.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myProject.Code = txtProjectCode.Text;
                    myProject = (from itm in (List<AccProject>)(Cache["LastProject" + Session["CNN2"].ToString()])
                                 where itm.Code == myProject.Code
                                 select itm).FirstOrDefault();
                    if (myProject == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "المشروع غير معرف من قبل";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }
                }

                // Check Existing Emp

                VouData[int.Parse(sno) - 1].Debit = moh.StrToDouble(txtDebit.Text);
                VouData[int.Parse(sno) - 1].Credit = moh.StrToDouble(txtCredit.Text);
                VouData[int.Parse(sno) - 1].Code = txtCode.Text;
                VouData[int.Parse(sno) - 1].Name = txtName.Text;
                VouData[int.Parse(sno) - 1].Project = txtProject.Text;
                if (txtProject.ToolTip != "") VouData[int.Parse(sno) - 1].ProjectCode = txtProjectCode.Text;
                VouData[int.Parse(sno) - 1].CostCenter = txtCostCenter.Text;
                if (txtCostCenter.ToolTip != "") VouData[int.Parse(sno) - 1].CostCenterCode = txtCostCenterCode.Text;
                VouData[int.Parse(sno) - 1].Remark = txtRemark.Text;

                txtProject.ToolTip = "";
                txtCostCenter.ToolTip = "";

                grdCodes.EditIndex = -1;
                MakeSum();
                LoadVouData();

                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                LblCodesResult.Text = "لقد تم تعديل البند بنجاح";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, false), true);
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
                    e.NewSelectedIndex = -1;
                }
            }
        }

        protected void grdCodes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string sno = grdCodes.DataKeys[e.RowIndex]["sno"].ToString();
                VouData.RemoveAt((int)moh.StrToDouble(sno) - 1);
                for (int i = 0; i < VouData.Count; i++)
                {
                    VouData[i].sno = (short)(i + 1);
                }
                e.Cancel = false;
                MakeSum();
                LoadVouData();
                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                LblCodesResult.Text = "لقد تم الغاء البند بنجاح";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, false), true);
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
                LoadVouData();
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

        protected void BtnClear_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                txtVouNo.Text = "";
                txtVouDate.Text = "";
                lblDiff.Text = "";
                lblTotalCR.Text = "";
                lblTotalDB.Text = "";
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));

                if (sender != null)
                {
                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 100;
                    myJv.LocType = 1;
                    myJv.LocNumber = short.Parse(Session["Branch"].ToString());
                    int? i = myJv.GetNewNumber(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (i == 0 || i == null)
                    {
                        i = 1;
                    }
                    else
                    {
                        i++;
                    }
                    txtVouNo.Text = i.ToString();
                }
                txtVouDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                NewMode();
                VouData.Clear();
                LoadVouData();
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

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (lblDiff.Text == "" || moh.StrToDouble(lblDiff.Text) != 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "القيد غير متزن";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                    List<Jv> ljv = new List<Jv>();
                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 100;
                    myJv.LocType = 1;
                    myJv.LocNumber = short.Parse(Session["Branch"].ToString());
                    myJv.Number = int.Parse(txtVouNo.Text);
                    ljv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (ljv != null && ljv.Count() > 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم القيد مكرر";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                    else
                    {
                        foreach (Vou itm in VouData)
                        {
                            Jv vJv = new Jv();
                            vJv.Branch = short.Parse(Session["Branch"].ToString());
                            vJv.FType = 100;
                            vJv.LocType = 1;
                            vJv.LocNumber = short.Parse(Session["Branch"].ToString());
                            vJv.Number = int.Parse(txtVouNo.Text);
                            vJv.Post = 1;
                            vJv.FDate = moh.CheckDate(txtVouDate.Text);
                            vJv.CostCenter = itm.CostCenterCode;
                            vJv.Project = itm.ProjectCode;
                            vJv.Remark = itm.Remark;
                            vJv.FNo = itm.sno;
                            if (itm.Credit > 0)
                            {
                                vJv.Amount = itm.Credit;
                                vJv.CrCode = itm.Code;
                            }
                            else
                            {
                                vJv.Amount = itm.Debit;
                                vJv.DbCode = itm.Code;
                            }
                            vJv.UserName = txtUserName.ToolTip;
                            vJv.UserDate = txtUserDate.Text;
                            vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        BtnClear_Click(sender, e);
                    }
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

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (lblDiff.Text == "" || moh.StrToDouble(lblDiff.Text) != 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "القيد غير متزن";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    List<Jv> ljv = new List<Jv>();
                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 100;
                    myJv.LocType = 1;
                    myJv.LocNumber = short.Parse(Session["Branch"].ToString());
                    myJv.Number = int.Parse(txtVouNo.Text);
                    ljv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (ljv == null || ljv.Count() == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم القيد غير معرف من قبل";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.FType = 100;
                        myJv.LocType = 1;
                        myJv.LocNumber = short.Parse(Session["Branch"].ToString());
                        myJv.Number = int.Parse(txtVouNo.Text);
                        if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            foreach (Vou itm in VouData)
                            {
                                Jv vJv = new Jv();
                                vJv.Branch = short.Parse(Session["Branch"].ToString());
                                vJv.FType = 100;
                                vJv.LocType = 1;
                                vJv.LocNumber = short.Parse(Session["Branch"].ToString());
                                vJv.Number = int.Parse(txtVouNo.Text);
                                vJv.Post = 1;
                                vJv.FDate = moh.CheckDate(txtVouDate.Text);
                                vJv.CostCenter = itm.CostCenterCode;
                                vJv.Project = itm.ProjectCode;
                                vJv.Remark = itm.Remark;
                                if (itm.Credit > 0)
                                {
                                    vJv.Amount = itm.Credit;
                                    vJv.CrCode = itm.Code;
                                }
                                else
                                {
                                    vJv.Amount = itm.Debit;
                                    vJv.DbCode = itm.Code;
                                }
                                vJv.UserName = txtUserName.ToolTip;
                                vJv.UserDate = txtUserDate.Text;
                                vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                        }
                    }
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

        protected void BtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    List<Jv> ljv = new List<Jv>();
                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 100;
                    myJv.LocType = 1;
                    myJv.LocNumber = short.Parse(Session["Branch"].ToString());
                    myJv.Number = int.Parse(txtVouNo.Text);
                    ljv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (ljv == null || ljv.Count() == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم القيد غير معرف من قبل";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.FType = 100;
                        myJv.LocType = 1;
                        myJv.LocNumber = short.Parse(Session["Branch"].ToString());
                        myJv.Number = int.Parse(txtVouNo.Text);
                        if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم الغاء البيانات بنجاح";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ أثناء الغاء البيانات ... حاول مرة أخرى";
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
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

        protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (txtVouNo.Text != "")
                    {
                        //string vs = txtSearch.Text;
                        //BtnClear_Click(sender, e);
                        //txtSearch.Text = vs;

                        string vs = txtVouNo.Text;
                        BtnClear_Click(sender, e);
                        txtVouNo.Text = vs;

                        List<vJv> lJv = new List<vJv>();
                        Jv myJv = new Jv();
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.FType = 100;
                        myJv.LocType = 1;
                        myJv.LocNumber = short.Parse(Session["Branch"].ToString());
                        myJv.Number = int.Parse(txtVouNo.Text);
                        lJv = myJv.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (lJv == null || lJv.Count == 0)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم القيد غير معرف من قبل";
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            EditMode();
                            txtVouDate.Text = lJv[0].FDate;
                            txtUserDate.Text = lJv[0].UserDate;
                            txtUserName.ToolTip = lJv[0].UserName;
                            TblUsers ax = new TblUsers();
                            if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                            ax.UserName = lJv[0].UserName;
                            ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                  where uitm.UserName == ax.UserName
                                  select uitm).FirstOrDefault();
                            if (ax == null)
                            {
                                txtUserName.Text = txtUserName.ToolTip;
                            }
                            else
                            {
                                txtUserName.Text = ax.FName;
                            }
                            foreach (vJv itm in lJv)
                            {
                                VouData.Add(new Vou
                                {
                                    Code = itm.DbCode == "" ? itm.CrCode : itm.DbCode,
                                    Credit = itm.DbCode == "" ? (double)itm.Amount : 0,
                                    Debit = itm.DbCode == "" ? 0 : (double)itm.Amount,
                                    CostCenter = itm.CostName1,
                                    CostCenter2 = itm.CostName2,
                                    CostCenterCode = itm.CostCenter,
                                    Project = itm.ProjectName1,
                                    Project2 = itm.ProjectName2,
                                    ProjectCode = itm.Project,
                                    Remark = itm.Remark,
                                    Name = itm.AccName1,
                                    Name2 = itm.AccName2,
                                    sno = itm.FNo
                                });
                            }
                            LoadVouData();
                            MakeSum();
                        }
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب إدخال رقم القيد";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
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

        protected void BtnFind_Click(object sender, ImageClickEventArgs e)
        {
            BtnSearch_Click(sender, e);
        }

    }
}
