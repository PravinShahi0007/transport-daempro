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
using System.Web.Script.Serialization;

namespace ACC
{
    public partial class WebRJVou : System.Web.UI.Page
    {
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
        public short LocNumber
        {
            get
            {
                if (ViewState["LocNumber"] == null)
                {
                    ViewState["LocNumber"] = 1;
                }
                return short.Parse(ViewState["LocNumber"].ToString());
            }
            set { ViewState["LocNumber"] = value; }
        }
        public short LocType
        {
            get
            {
                if (ViewState["LocType"] == null)
                {
                    ViewState["LocType"] = 1;
                }
                return short.Parse(ViewState["LocType"].ToString());
            }
            set { ViewState["LocType"] = value; }
        }

        public void EditMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            // BtnPrint.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass265;
            BtnEdit.Visible = true; // && (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass262;
            BtnNew.Visible = false;
            BtnDelete.Visible = true;  // && (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass263;

            if (BtnEdit.Visible || BtnDelete.Visible)
            {
                txtReason.Visible = true;
                ValReason.Enabled = true;
                lblReason.Visible = true;
            }
            // if (!(bool)((List<TblRoles>)(Session["Roll"]))[0].Pass262) ControlsOnOff(false);
        }

        public void NewMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            //txtVouNo.ReadOnly = false;
            //txtVouNo.BackColor = System.Drawing.Color.White;

            BtnEdit.Visible = false;
            BtnNew.Visible = true;   // && (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass261;
            BtnDelete.Visible = false;

            txtReason.Visible = false;
            ValReason.Enabled = false;
            lblReason.Visible = false;
            // if (!(bool)((List<TblRoles>)(Session["Roll"]))[0].Pass262) ControlsOnOff(true);
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
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttach);
                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "القيود الدورية";
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
                        UserTran.Description = "تم اختيار صفحة القيود الدورية";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    LoadVouData();

                    //BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass261;
                    //BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass262;
                    //BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass263;
                    //BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass264;
                    //BtnFind.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass264;

                    //BtnPrint.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass265;

                    if (Request.QueryString["FNum"] != null)
                    {
                        txtSearch.Text = Request.QueryString["FNum"].ToString();
                        BtnSearch_Click(sender, null);
                    }
                    else BtnClear_Click(sender, null);
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
                    grdCodes.Rows[0].Visible = false;
                    grdCodes.Rows[0].Controls.Clear();
                    grdCodes.Rows[0].Cells.Clear();
                    VouData.Remove(ax);
                }

                DropDownList ddlArea = grdCodes.FooterRow.FindControl("ddlArea2") as DropDownList;
                ddlArea.DataTextField = "Name1";
                ddlArea.DataValueField = "Code";
                ddlArea.DataSource = (List<Area>)(HttpRuntime.Cache["LastArea" + HttpContext.Current.Session["CNN2"].ToString()]);
                ddlArea.DataBind();
                ddlArea.Items.Insert(0, new ListItem("--- أختار المنطقة---", "-1", true));

                DropDownList ddlCostCenter = grdCodes.FooterRow.FindControl("ddlCostCenter2") as DropDownList;
                ddlCostCenter.DataTextField = "Name1";
                ddlCostCenter.DataValueField = "Code";
                ddlCostCenter.DataSource = (List<CostCenter>)(HttpRuntime.Cache["LastCostCenter" + HttpContext.Current.Session["CNN2"].ToString()]);
                ddlCostCenter.DataBind();
                ddlCostCenter.Items.Insert(0, new ListItem("--- أختار الفرع---", "-1", true));

                DropDownList ddlProject = grdCodes.FooterRow.FindControl("ddlProject2") as DropDownList;
                ddlProject.DataTextField = "Name1";
                ddlProject.DataValueField = "Code";
                ddlProject.DataSource = (List<AccProject>)(HttpRuntime.Cache["LastProject" + HttpContext.Current.Session["CNN2"].ToString()]);
                ddlProject.DataBind();
                ddlProject.Items.Insert(0, new ListItem("--- أختار المشروع---", "-1", true));

                DropDownList ddlCostAcc = grdCodes.FooterRow.FindControl("ddlCostAcc2") as DropDownList;
                ddlCostAcc.DataTextField = "Name1";
                ddlCostAcc.DataValueField = "Code";
                ddlCostAcc.DataSource = (List<CostAcc>)(HttpRuntime.Cache["LastCostAcc" + HttpContext.Current.Session["CNN2"].ToString()]);
                ddlCostAcc.DataBind();
                ddlCostAcc.Items.Insert(0, new ListItem("--- أختار حساب التكاليف---", "-1", true));

                DropDownList ddlEmp = grdCodes.FooterRow.FindControl("ddlEmp2") as DropDownList;
                SEmp myemp = new SEmp();
                if (Cache["Emps" + Session["CNN2"].ToString()] == null) Cache.Insert("Emps" + Session["CNN2"].ToString(), myemp.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                ddlEmp.DataTextField = "Name";
                ddlEmp.DataValueField = "EmpCode";
                ddlEmp.DataSource = (List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()]);
                ddlEmp.DataBind();
                ddlEmp.Items.Insert(0, new ListItem("--- أختار الموظف---", "-1", true));

                //DropDownList ddlCarNo = grdCodes.FooterRow.FindControl("ddlCarNo2") as DropDownList;
                //Cars myCar = new Cars();
                //myCar.Branch = short.Parse(Session["Branch"].ToString());
                //ddlCarNo.DataTextField = "CodeName";
                //ddlCarNo.DataValueField = "Code";
                //ddlCarNo.DataSource = (from itm in myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                //                       orderby itm.Code
                //                       select itm).ToList();

                //ddlCarNo.DataBind();
                //ddlCarNo.Items.Insert(0, new ListItem("--- أختار الشاحنة---", "-1", true));
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

                    TextBox txtFNo = gvr.FindControl("txtFNo") as TextBox;
                    TextBox txtDebit = gvr.FindControl("txtDebit") as TextBox;
                    TextBox txtCredit = gvr.FindControl("txtCredit") as TextBox;
                    TextBox txtCode = gvr.FindControl("txtCode") as TextBox;
                    TextBox txtName = gvr.FindControl("txtName") as TextBox;
                    TextBox txtRemark = gvr.FindControl("txtRemark") as TextBox;
                    TextBox txtInvNo = gvr.FindControl("txtInvNo") as TextBox;

                    DropDownList ddlCostCenter = gvr.FindControl("ddlCostCenter2") as DropDownList;
                    DropDownList ddlProject = gvr.FindControl("ddlProject2") as DropDownList;
                    DropDownList ddlEmp = gvr.FindControl("ddlEmp2") as DropDownList;
                    DropDownList ddlArea = gvr.FindControl("ddlArea2") as DropDownList;
                    DropDownList ddlCostAcc = gvr.FindControl("ddlCostAcc2") as DropDownList;
                    TextBox txtCarNo = gvr.FindControl("txtCarNo2") as TextBox;


                    if (txtDebit == null || txtCredit == null || txtCode == null || txtName == null || txtRemark == null || ddlCostCenter == null || ddlProject == null || ddlEmp == null || ddlArea == null || ddlCostAcc == null || txtCarNo == null || txtInvNo == null)
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
                        //if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    if (moh.StrToDouble(txtDebit.Text) == 0 && moh.StrToDouble(txtCredit.Text) == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب إدخال مبلغ مدين أو دائن";
                        //if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
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
                        // Check to force Entering of Area
                        if ((bool)myAcc.CheckArea && ddlArea.SelectedValue == "-1")
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الحساب مرتبط بمنطقة ... يجب أختيار المنطقة";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }

                        // Check to force Entering of Cost Center
                        if ((bool)myAcc.CheckCostCenter && ddlCostCenter.SelectedValue == "-1")
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الحساب مرتبط بفرع ... يجب أختيار الفرع";
                            //if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }

                        // Check to force Entering of Project
                        if ((bool)myAcc.CheckProject && ddlProject.SelectedValue == "-1")
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الحساب مرتبط بمشروع ... يجب أختيار المشروع";
                            //if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }

                        // Check to force Entering of Cost Acc
                        if ((bool)myAcc.CheckCostAcc && ddlCostAcc.SelectedValue == "-1")
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الحساب مرتبط بحسابات التكاليف ... يجب أختيار حساب التكاليف";
                            //if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }

                        // Check to force Entering of Emp
                        if ((bool)myAcc.CheckEmp && ddlEmp.SelectedValue == "-1")
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الحساب مرتبط بالموظفين ... يجب أختيار الموظف";
                            //if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }

                        if ((bool)myAcc.CheckCarNo && txtCarNo.Text.Trim() == "")
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الحساب مرتبط بشاحنة ... يجب أختيار الشاحنة";
                            //if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }

                    }

                    Vou myAccess = new Vou();
                    myAccess.sno = (short)(VouData.Count + 1);
                    myAccess.Debit = moh.StrToDouble(txtDebit.Text);
                    myAccess.Credit = moh.StrToDouble(txtCredit.Text);
                    myAccess.Code = txtCode.Text;
                    myAccess.Name = txtName.Text;
                    if (ddlProject.SelectedIndex > 0)
                    {
                        myAccess.Project = ddlProject.SelectedItem.Text;
                        myAccess.ProjectCode = ddlProject.SelectedValue;
                    }
                    else
                    {
                        myAccess.Project = "";
                        myAccess.ProjectCode = "-1";
                    }
                    if (ddlCostCenter.SelectedIndex > 0)
                    {
                        myAccess.CostCenter = ddlCostCenter.SelectedItem.Text;
                        myAccess.CostCenterCode = ddlCostCenter.SelectedValue;
                    }
                    else
                    {
                        myAccess.CostCenter = "";
                        myAccess.CostCenterCode = "-1";
                    }
                    if (ddlArea.SelectedIndex > 0)
                    {
                        myAccess.Area = ddlArea.SelectedItem.Text;
                        myAccess.AreaCode = ddlArea.SelectedValue;
                    }
                    else
                    {
                        myAccess.Area = "";
                        myAccess.AreaCode = "-1";
                    }
                    if (ddlCostAcc.SelectedIndex > 0)
                    {
                        myAccess.CostAcc = ddlCostAcc.SelectedItem.Text;
                        myAccess.CostAccCode = ddlCostAcc.SelectedValue;
                    }
                    else
                    {
                        myAccess.CostAcc = "";
                        myAccess.CostAccCode = "-1";
                    }
                    if (ddlEmp.SelectedIndex > 0)
                    {
                        myAccess.Emp = ddlEmp.SelectedItem.Text;
                        myAccess.EmpCode = ddlEmp.SelectedValue;
                    }
                    else
                    {
                        myAccess.Emp = "";
                        myAccess.EmpCode = "-1";
                    }

                    if (txtCarNo.Text != "")
                    {
                        Cars myCar = new Cars();
                        myCar.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCar.Code = txtCarNo.Text;
                        myCar = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                 where sitm.Code == myCar.Code
                                 select sitm).FirstOrDefault();
                        if (myCar != null)
                        {
                            myAccess.CarNo2 = myCar.CodeName;
                            myAccess.CarNo = myCar.Code;
                        }
                    }
                    else
                    {
                        myAccess.CarNo2 = "";
                        myAccess.CarNo = "-1";
                    }
                    myAccess.InvNo = txtInvNo.Text;
                    myAccess.Remark = txtRemark.Text;

                    if (txtFNo.Text.Trim() == "" || int.Parse(txtFNo.Text) > VouData.Count())
                    {
                        VouData.Add(myAccess);
                    }
                    else
                    {
                        VouData.Insert(int.Parse(txtFNo.Text) - 1, myAccess);
                        for (int i = 0; i < VouData.Count; i++)
                        {
                            VouData[i].sno = (short)(i + 1);
                        }
                    }

                    SavemyCookie();

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
                TextBox txtInvNo = gvr.FindControl("txtInvNo2") as TextBox;
                DropDownList ddlArea = gvr.FindControl("ddlArea") as DropDownList;
                DropDownList ddlCostCenter = gvr.FindControl("ddlCostCenter") as DropDownList;
                DropDownList ddlProject = gvr.FindControl("ddlProject") as DropDownList;
                DropDownList ddlCostAcc = gvr.FindControl("ddlCostAcc") as DropDownList;
                DropDownList ddlEmp = gvr.FindControl("ddlEmp") as DropDownList;
                TextBox txtCarNo = gvr.FindControl("txtCarNo") as TextBox;

                if (txtDebit == null || txtCredit == null || txtCode == null || txtName == null || txtRemark == null || txtInvNo == null || ddlArea == null || ddlCostCenter == null || ddlCostAcc == null || ddlProject == null || ddlEmp == null || txtCarNo == null)
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
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    return;
                }

                if (moh.StrToDouble(txtDebit.Text) == 0 && moh.StrToDouble(txtCredit.Text) == 0)
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال مبلغ مدين أو دائن";
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
                    // Check to force Entering of Area
                    if ((bool)myAcc.CheckArea && ddlArea.SelectedValue == "-1")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الحساب مرتبط بمنطقة ... يجب أختيار المنطقة";
                        //if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    // Check to force Entering of Cost Center
                    if ((bool)myAcc.CheckCostCenter && ddlCostCenter.SelectedValue == "-1")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الحساب مرتبط بفرع ... يجب أختيار الفرع";
                        //if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    // Check to force Entering of Project
                    if ((bool)myAcc.CheckProject && ddlProject.SelectedValue == "-1")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الحساب مرتبط بمشروع ... يجب أختيار المشروع";
                        //if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    // Check to force Entering of Cost Acc
                    if ((bool)myAcc.CheckCostAcc && ddlCostAcc.SelectedValue == "-1")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الحساب مرتبط بحسابات التكاليف ... يجب أختيار حساب التكاليف";
                        //if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    // Check to force Entering of Emp
                    if ((bool)myAcc.CheckEmp && ddlEmp.SelectedValue == "-1")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الحساب مرتبط بالموظفين ... يجب أختيار الموظف";
                        //if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    // Check to force Entering of Emp
                    if ((bool)myAcc.CheckCarNo && txtCarNo.Text.Trim() == "")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الحساب مرتبط بشاحنة ... يجب أختيار الشاحنة";
                        //if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }


                }

                VouData[int.Parse(sno) - 1].Debit = moh.StrToDouble(txtDebit.Text);
                VouData[int.Parse(sno) - 1].Credit = moh.StrToDouble(txtCredit.Text);
                VouData[int.Parse(sno) - 1].Code = txtCode.Text;
                VouData[int.Parse(sno) - 1].Name = txtName.Text;
                if (ddlProject.SelectedIndex > 0)
                {
                    VouData[int.Parse(sno) - 1].Project = ddlProject.SelectedItem.Text;
                    VouData[int.Parse(sno) - 1].ProjectCode = ddlProject.SelectedValue;
                }
                else
                {
                    VouData[int.Parse(sno) - 1].Project = "";
                    VouData[int.Parse(sno) - 1].ProjectCode = "-1";
                }
                if (ddlCostCenter.SelectedIndex > 0)
                {
                    VouData[int.Parse(sno) - 1].CostCenter = ddlCostCenter.SelectedItem.Text;
                    VouData[int.Parse(sno) - 1].CostCenterCode = ddlCostCenter.SelectedValue;
                }
                else
                {
                    VouData[int.Parse(sno) - 1].CostCenter = "";
                    VouData[int.Parse(sno) - 1].CostCenterCode = "-1";
                }
                if (ddlArea.SelectedIndex > 0)
                {
                    VouData[int.Parse(sno) - 1].Area = ddlArea.SelectedItem.Text;
                    VouData[int.Parse(sno) - 1].AreaCode = ddlArea.SelectedValue;
                }
                else
                {
                    VouData[int.Parse(sno) - 1].Area = "";
                    VouData[int.Parse(sno) - 1].AreaCode = "-1";
                }
                if (ddlCostAcc.SelectedIndex > 0)
                {
                    VouData[int.Parse(sno) - 1].CostAcc = ddlCostAcc.SelectedItem.Text;
                    VouData[int.Parse(sno) - 1].CostAccCode = ddlCostAcc.SelectedValue;
                }
                else
                {
                    VouData[int.Parse(sno) - 1].CostAcc = "";
                    VouData[int.Parse(sno) - 1].CostAccCode = "-1";
                }
                if (ddlEmp.SelectedIndex > 0)
                {
                    VouData[int.Parse(sno) - 1].Emp = ddlEmp.SelectedItem.Text;
                    VouData[int.Parse(sno) - 1].EmpCode = ddlEmp.SelectedValue;
                }
                else
                {
                    VouData[int.Parse(sno) - 1].Emp = "";
                    VouData[int.Parse(sno) - 1].EmpCode = "-1";
                }
                if (txtCarNo.Text != "")
                {
                    Cars myCar = new Cars();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myCar.Code = txtCarNo.Text;
                    myCar = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                             where sitm.Code == myCar.Code
                             select sitm).FirstOrDefault();
                    if (myCar != null)
                    {
                        VouData[int.Parse(sno) - 1].CarNo2 = myCar.CodeName;
                        VouData[int.Parse(sno) - 1].CarNo = myCar.Code;
                    }
                }
                else
                {
                    VouData[int.Parse(sno) - 1].CarNo2 = "";
                    VouData[int.Parse(sno) - 1].CarNo = "-1";
                }
                VouData[int.Parse(sno) - 1].Remark = txtRemark.Text;
                VouData[int.Parse(sno) - 1].InvNo = txtInvNo.Text;
                SavemyCookie();

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

                SavemyCookie();
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
                txtSearch.Text = "";
                txtVouDate.Text = "";
                txtReason.Text = "";
                txtEndDate.Text = "";
                txtStartDate.Text = "";
                ddlPeriod.SelectedValue = "30";
                lblDiff.Text = "";
                lblTotalCR.Text = "";
                lblTotalDB.Text = "";
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                NewMode();
                if (sender != null)
                {
                    RJv myJv = new RJv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 100;
                    myJv.LocType = LocType;
                    myJv.LocNumber = LocNumber;
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
                VouData.Clear();
                LoadVouData();
                LoadAttachData();
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

        public void ControlsOnOff(bool State)
        {
            txtVouDate.ReadOnly = !State;
            CalendarExtender1.Enabled = State;
            txtReason.ReadOnly = !State;
            //grdAttach.Enabled = State;
            foreach (GridViewRow itm in grdAttach.Rows)
            {
                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                if (BtnDelete != null) BtnDelete.Visible = State;
            }
            grdCodes.Enabled = State;
            FileUpload1.Enabled = State;
            BtnAttach.Enabled = State;
            txtStartDate.ReadOnly = !State;
            txtEndDate.ReadOnly = !State;
            ddlPeriod.Enabled = State;
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

                    //if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    //{
                    //    if (DateTime.Parse(txtVouDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    //    {
                    //        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    //        LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                    //        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    //        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    //        return;
                    //    }
                    //}

                    List<RJv> ljv = new List<RJv>();
                    RJv myJv = new RJv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 100;
                    myJv.LocType = LocType;
                    myJv.LocNumber = LocNumber;
                    myJv.Number = int.Parse(txtVouNo.Text);
                    ljv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (ljv != null && ljv.Count() > 0)
                    {
                        if (ljv[0].UserName == txtUserName.ToolTip)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم القيد مكرر";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }
                        else
                        {
                            myJv = new RJv();
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.FType = 100;
                            myJv.LocType = LocType;
                            myJv.LocNumber = LocNumber;
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
                    }

                    foreach (Vou itm in VouData)
                    {
                        RJv vJv = new RJv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 100;
                        vJv.LocType = LocType;
                        vJv.LocNumber = LocNumber;
                        vJv.Number = int.Parse(txtVouNo.Text);
                        vJv.Post = 1;
                        vJv.FDate = moh.CheckDate(txtVouDate.Text);
                        vJv.CostCenter = itm.CostCenterCode;
                        vJv.Project = itm.ProjectCode;
                        vJv.CarNo = itm.CarNo;
                        vJv.Area = itm.AreaCode;
                        vJv.CostAcc = itm.CostAccCode;
                        vJv.EmpCode = itm.EmpCode;
                        vJv.Remark = itm.Remark;
                        vJv.InvNo = itm.InvNo;
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
                        vJv.StartDate = txtStartDate.Text;
                        vJv.CDate = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(txtStartDate.Text).AddDays(int.Parse(ddlPeriod.SelectedValue) * -1));
                        if (ddlPeriod.SelectedValue == "30")
                        {
                            if (DateTime.Parse(txtStartDate.Text).Month == DateTime.Parse(vJv.CDate).Month)
                            {
                                vJv.CDate = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(vJv.CDate).AddDays(-10));
                            }
                        }
                        vJv.EndDate = txtEndDate.Text;
                        vJv.Period = int.Parse(ddlPeriod.SelectedValue);
                        vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }

                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = "القيود الدورية";
                        UserTran.FormAction = "اضافة";
                        UserTran.Description = "اضافة قيد دوري رقم " + txtVouNo.Text;
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                    DeletemyCookie();
                    string vNumber = txtVouNo.Text;
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                    BtnClear_Click(sender, e);
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
                    //if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    //{
                    //    if (DateTime.Parse(txtVouDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    //    {
                    //        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    //        LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                    //        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    //        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    //        return;
                    //    }
                    //}

                    List<RJv> ljv = new List<RJv>();
                    RJv myJv = new RJv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 100;
                    myJv.LocType = LocType;
                    myJv.LocNumber = LocNumber;
                    myJv.Number = int.Parse(txtVouNo.Text);
                    string cDate = "";
                    ljv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (ljv == null || ljv.Count() == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم القيد غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    }
                    else
                    {
                        cDate = ljv[0].CDate;
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.FType = 100;
                        myJv.LocType = LocType;
                        myJv.LocNumber = LocNumber;
                        myJv.Number = int.Parse(txtVouNo.Text);
                        if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            foreach (Vou itm in VouData)
                            {
                                RJv vJv = new RJv();
                                vJv.Branch = short.Parse(Session["Branch"].ToString());
                                vJv.FType = 100;
                                vJv.LocType = LocType;
                                vJv.LocNumber = LocNumber;
                                vJv.Number = int.Parse(txtVouNo.Text);
                                vJv.Post = 1;
                                vJv.FDate = moh.CheckDate(txtVouDate.Text);
                                vJv.CostCenter = itm.CostCenterCode;
                                vJv.Project = itm.ProjectCode;
                                vJv.CarNo = itm.CarNo;
                                vJv.Area = itm.AreaCode;
                                vJv.CostAcc = itm.CostAccCode;
                                vJv.EmpCode = itm.EmpCode;
                                vJv.Remark = itm.Remark;
                                vJv.InvNo = itm.InvNo;
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
                                vJv.StartDate = txtStartDate.Text;
                                vJv.EndDate = txtEndDate.Text;
                                vJv.Period = int.Parse(ddlPeriod.SelectedValue);
                                vJv.CDate = cDate;
                                vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }

                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.FormName = "القيود الدورية";
                                UserTran.FormAction = "تعديل";
                                UserTran.Description = "تعديل قيد دوري رقم " + txtVouNo.Text;
                                UserTran.Reason = txtReason.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                txtReason.Text = "";
                            }

                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                            DeletemyCookie();
                            string vNumber = txtVouNo.Text;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                            //PrintMe(vNumber);
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
                    //if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    //{
                    //    if (DateTime.Parse(txtVouDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    //    {
                    //        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    //        LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                    //        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    //        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    //        return;
                    //    }
                    //}

                    List<RJv> ljv = new List<RJv>();
                    RJv myJv = new RJv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 100;
                    myJv.LocType = LocType;
                    myJv.LocNumber = LocNumber;
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
                        myJv.LocType = LocType;
                        myJv.LocNumber = LocNumber;
                        myJv.Number = int.Parse(txtVouNo.Text);
                        if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.FormName = "القيود الدورية";
                                UserTran.FormAction = "الغاء";
                                UserTran.Description = "الغاء قيد دوري رقم " + txtVouNo.Text;
                                UserTran.Reason = txtReason.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }
                            txtReason.Text = "";

                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم الغاء البيانات بنجاح";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ أثناء الغاء البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
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
                if (txtSearch.Text != "")
                {
                    string vs = txtSearch.Text;
                    BtnClear_Click(sender, e);
                    txtSearch.Text = vs;

                    List<vRJv> lJv = new List<vRJv>();
                    vRJv myJv = new vRJv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 100;
                    myJv.LocType = LocType;
                    myJv.LocNumber = LocNumber;
                    myJv.Number = int.Parse(txtSearch.Text);
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
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormName = "القيود الدورية";
                            UserTran.FormAction = "عرض";
                            UserTran.Description = "عرض قيد دوري رقم " + txtVouNo.Text;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }

                        EditMode();
                        txtVouNo.Text = lJv[0].Number.ToString();
                        txtVouDate.Text = lJv[0].FDate;
                        txtUserDate.Text = lJv[0].UserDate;
                        txtUserName.ToolTip = lJv[0].UserName;
                        txtStartDate.Text = lJv[0].StartDate;
                        txtEndDate.Text = lJv[0].EndDate;
                        ddlPeriod.SelectedValue = lJv[0].Period.ToString();
                        if (!string.IsNullOrEmpty(lJv[0].CDate))
                        {
                            BtnDelete.Visible = false;
                            BtnEdit.Visible = false;
                        }

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
                        foreach (vRJv itm in lJv)
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
                                Emp = itm.EmpName1,
                                Emp2 = itm.EmpName2,
                                EmpCode = itm.EmpCode,
                                CarNo = itm.CarNo,
                                CarNo2 = itm.PlateNo,
                                Area = itm.AreaName1,
                                Area2 = itm.AreaName2,
                                AreaCode = itm.Area,
                                CostAcc = itm.CostAccName1,
                                CostAcc2 = itm.CostAccName2,
                                CostAccCode = itm.CostAcc,
                                Remark = itm.Remark,
                                InvNo = itm.InvNo,
                                Name = itm.AccName1,
                                Name2 = itm.AccName2,
                                sno = itm.FNo                                 
                            });
                        }
                        LoadVouData();
                        MakeSum();
                        LoadAttachData();
                        SavemyCookie();
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

        protected void ddlArea_Init(object sender, EventArgs e)
        {
            DropDownList ddlArea = sender as DropDownList;
            if (ddlArea.Items.Count == 0)
            {
                GridViewRow gvr = ddlArea.NamingContainer as GridViewRow;
                string sno = grdCodes.DataKeys[gvr.RowIndex]["sno"].ToString();
                foreach (Area itm in (List<Area>)(HttpRuntime.Cache["LastArea" + HttpContext.Current.Session["CNN2"].ToString()]))
                {
                    ddlArea.Items.Add(new ListItem(itm.Name1, itm.Code));
                }
                ddlArea.Items.Insert(0, new ListItem("--- أختار المنطقة---", "-1", true));
                if (int.Parse(sno) > 0 && VouData[int.Parse(sno) - 1].AreaCode != "" && VouData[int.Parse(sno) - 1].AreaCode != "-1")
                {
                    ddlArea.SelectedValue = VouData[int.Parse(sno) - 1].AreaCode;
                }
            }
        }

        protected void ddlCostCenter_Init(object sender, EventArgs e)
        {
            DropDownList ddlCostCenter = sender as DropDownList;
            if (ddlCostCenter.Items.Count == 0)
            {
                GridViewRow gvr = ddlCostCenter.NamingContainer as GridViewRow;
                DropDownList ddlArea = gvr.FindControl("ddlArea") as DropDownList;

                string sno = grdCodes.DataKeys[gvr.RowIndex]["sno"].ToString();
                foreach (CostCenter itm in (List<CostCenter>)(HttpRuntime.Cache["LastCostCenter" + HttpContext.Current.Session["CNN2"].ToString()]))
                {
                    if (ddlArea.SelectedValue != "-1")
                    {
                        if (ddlArea.SelectedValue == itm.Area) ddlCostCenter.Items.Add(new ListItem(itm.Name1, itm.Code));
                    }
                    else ddlCostCenter.Items.Add(new ListItem(itm.Name1, itm.Code));
                }
                ddlCostCenter.Items.Insert(0, new ListItem("--- أختار الفرع---", "-1", true));
                if (int.Parse(sno) > 0 && VouData[int.Parse(sno) - 1].CostCenterCode != "" && VouData[int.Parse(sno) - 1].CostCenterCode != "-1") ddlCostCenter.SelectedValue = VouData[int.Parse(sno) - 1].CostCenterCode;
            }
        }

        protected void ddlProject_Init(object sender, EventArgs e)
        {
            DropDownList ddlProject = sender as DropDownList;
            if (ddlProject.Items.Count == 0)
            {
                GridViewRow gvr = ddlProject.NamingContainer as GridViewRow;
                string sno = grdCodes.DataKeys[gvr.RowIndex]["sno"].ToString();
                foreach (AccProject itm in (List<AccProject>)(HttpRuntime.Cache["LastProject" + HttpContext.Current.Session["CNN2"].ToString()]))
                {
                    ddlProject.Items.Add(new ListItem(itm.Name1, itm.Code));
                }
                ddlProject.Items.Insert(0, new ListItem("--- أختار المشروع---", "-1", true));
                if (int.Parse(sno) > 0 && VouData[int.Parse(sno) - 1].ProjectCode != "" && VouData[int.Parse(sno) - 1].ProjectCode != "-1") ddlProject.SelectedValue = VouData[int.Parse(sno) - 1].ProjectCode;
            }
        }

        protected void ddlCarNo_Init(object sender, EventArgs e)
        {
            DropDownList ddlCarNo = sender as DropDownList;
            if (ddlCarNo.Items.Count == 0)
            {
                GridViewRow gvr = ddlCarNo.NamingContainer as GridViewRow;
                string sno = grdCodes.DataKeys[gvr.RowIndex]["sno"].ToString();
                Cars myCar = new Cars();
                myCar.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                ddlCarNo.DataTextField = "CodeName";
                ddlCarNo.DataValueField = "Code";
                ddlCarNo.DataSource = (from itm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                       orderby itm.Code
                                       select itm).ToList();
                ddlCarNo.DataBind();
                ddlCarNo.Items.Insert(0, new ListItem("--- أختار الشاحنة---", "-1", true));
                if (int.Parse(sno) > 0 && VouData[int.Parse(sno) - 1].CarNo != "" && VouData[int.Parse(sno) - 1].CarNo != "-1") ddlCarNo.SelectedValue = VouData[int.Parse(sno) - 1].CarNo;
            }
        }

        protected void ddlCostAcc_Init(object sender, EventArgs e)
        {
            DropDownList ddlCostAcc = sender as DropDownList;
            if (ddlCostAcc.Items.Count == 0)
            {
                GridViewRow gvr = ddlCostAcc.NamingContainer as GridViewRow;
                string sno = grdCodes.DataKeys[gvr.RowIndex]["sno"].ToString();
                foreach (CostAcc itm in (List<CostAcc>)(HttpRuntime.Cache["LastCostAcc" + HttpContext.Current.Session["CNN2"].ToString()]))
                {
                    ddlCostAcc.Items.Add(new ListItem(itm.Name1, itm.Code));
                }
                ddlCostAcc.Items.Insert(0, new ListItem("--- أختار حساب التكاليف---", "-1", true));
                if (int.Parse(sno) > 0 && VouData[int.Parse(sno) - 1].CostAccCode != "" && VouData[int.Parse(sno) - 1].CostAccCode != "-1") ddlCostAcc.SelectedValue = VouData[int.Parse(sno) - 1].CostAccCode;
            }
        }

        protected void ddlEmp_Init(object sender, EventArgs e)
        {
            DropDownList ddlEmp = sender as DropDownList;
            if (ddlEmp.Items.Count == 0)
            {
                GridViewRow gvr = ddlEmp.NamingContainer as GridViewRow;
                string sno = grdCodes.DataKeys[gvr.RowIndex]["sno"].ToString();
                SEmp myemp = new SEmp();
                if (Cache["Emps" + Session["CNN2"].ToString()] == null) Cache.Insert("Emps" + Session["CNN2"].ToString(), myemp.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                foreach (SEmp itm in (List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()]))
                {
                    ddlEmp.Items.Add(new ListItem(itm.Name, itm.EmpCode.ToString()));
                }
                ddlEmp.Items.Insert(0, new ListItem("--- أختار الموظف---", "-1", true));
                if (int.Parse(sno) > 0 && VouData[int.Parse(sno) - 1].EmpCode != "" && VouData[int.Parse(sno) - 1].EmpCode != "-1") ddlEmp.SelectedValue = VouData[int.Parse(sno) - 1].EmpCode;
            }
        }

        protected void BtnAttach_Click(object sender, ImageClickEventArgs e)
        {
            if (FileUpload1.HasFile)
                try
                {
                    MyConfig mySetting = new MyConfig();
                    mySetting.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    mySetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                    if (mySetting != null)
                    {
                        string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
                        String FileName = Config.GetImageName(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + fileExt;
                        FileUpload1.SaveAs(mySetting.ImagePath + FileName);

                        Arch myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = 0;
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 001;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = 0;
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 001;
                        myArch.FileName = FileUpload1.FileName;
                        myArch.FileName2 = mySetting.ImagePath2 + FileName;
                        myArch.FNo = (short)i;
                        myArch.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormName = "القيود الدورية";
                            UserTran.FormAction = "اضافة مرفقات";
                            UserTran.Description = "اضافة مرفقات لقيد دوري رقم " + txtVouNo.Text;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }

                        LoadAttachData();
                    }

                    //    LblCodesResult.Text = "File name: " + FileUpload1.PostedFile.FileName + "<br>" + FileUpload1.PostedFile.ContentLength + " kb<br>" + "Content type: " + FileUpload1.PostedFile.ContentType;
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
                        LblCodesResult.Text = "ERROR: " + ex.Message.ToString();
                    }
                }
            else
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "لم بتم اختيار الملف";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);

            }
        }

        protected void grdAttach_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string FNo = grdAttach.DataKeys[e.RowIndex]["FNo"].ToString();
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(Session["Branch"].ToString());
                myArch.LocNumber = 0;
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = 001;
                myArch.FNo = short.Parse(FNo);
                myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                {
                    Transactions UserTran = new Transactions();
                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                    UserTran.UserName = Session["CurrentUser"].ToString();
                    UserTran.FormName = "القيود الدورية";
                    UserTran.FormAction = "الغاء مرفقات";
                    UserTran.Description = "الغاء مرفقات لقيد دوري رقم " + txtVouNo.Text;
                    UserTran.IP = IPNetworking.GetIP4Address();
                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                }

                LoadAttachData();
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

        public void LoadAttachData()
        {
            if (txtVouNo.Text != "")
            {
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(Session["Branch"].ToString());
                myArch.LocNumber = 0;
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = 001;
                grdAttach.DataSource = myArch.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                grdAttach.DataBind();
                if (((List<Arch>)grdAttach.DataSource).Count > 0)
                {
                    cpeDemo.Collapsed = false;
                    cpeDemo.ClientState = "false";
                }
                else
                {
                    cpeDemo.Collapsed = true;
                    cpeDemo.ClientState = "true";
                }
            }
        }

        public void SavemyCookie()
        {
            //string myObjectJson = new JavaScriptSerializer().Serialize(VouData);
            //Response.Cookies["JVou"].Value = myObjectJson;
            //Response.Cookies["JVou"].Expires = DateTime.Now.AddDays(10);                    

            Cache["JRVou_" + Session["CurrentUser"].ToString()] = VouData;
        }

        public void DeletemyCookie()
        {
            // HttpCookie currentUserCookie = HttpContext.Current.Request.Cookies["JVou"];
            // HttpContext.Current.Response.Cookies.Remove("JVou");
            // currentUserCookie.Expires = DateTime.Now.AddDays(-10);
            // currentUserCookie.Value = null;
            // HttpContext.Current.Response.SetCookie(currentUserCookie);
            Cache.Remove("JRVou_" + Session["CurrentUser"].ToString());
        }

        protected void BtnRecovery_Click(object sender, EventArgs e)
        {
            if (Cache["JRVou_" + Session["CurrentUser"].ToString()] != null)
            {
                VouData = (List<Vou>)Cache["JRVou_" + Session["CurrentUser"].ToString()];
                LoadVouData();
            }
            //if (Request.Cookies["JVou"] != null)
            //{
            //    var serializer = new JavaScriptSerializer();
            //    var deserializedResult = serializer.Deserialize<List<Vou>>(Request.Cookies["JVou"].Value);
            //    VouData = deserializedResult;
            //    LoadVouData();
            //}
        }

        protected void grdCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.EditIndex = grdCodes.SelectedIndex;
            LoadVouData();
        }

        protected void ddlArea2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlCostCenter = grdCodes.FooterRow.FindControl("ddlCostCenter2") as DropDownList;
            ddlCostCenter.DataSource = (from itm in (List<CostCenter>)(HttpRuntime.Cache["LastCostCenter" + HttpContext.Current.Session["CNN2"].ToString()])
                                        where ((DropDownList)sender).SelectedValue == "-1" || itm.Area == ((DropDownList)sender).SelectedValue
                                        select itm).ToList();
            ddlCostCenter.DataBind();
            ddlCostCenter.Items.Insert(0, new ListItem("--- أختار الفرع---", "-1", true));
        }

        protected void ddlCostCenter2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((DropDownList)sender).SelectedValue != "-1")
            {
                DropDownList ddlArea = grdCodes.FooterRow.FindControl("ddlArea2") as DropDownList;
                if (ddlArea.SelectedValue == "-1")
                {
                    string vArea = (from itm in (List<CostCenter>)(HttpRuntime.Cache["LastCostCenter" + HttpContext.Current.Session["CNN2"].ToString()])
                                    where itm.Code == ((DropDownList)sender).SelectedValue
                                    select itm.Area).FirstOrDefault();
                    if (vArea != null)
                    {
                        ddlArea.SelectedValue = vArea;
                        string vCost = ((DropDownList)sender).SelectedValue;
                        ((DropDownList)sender).DataSource = (from itm in (List<CostCenter>)(HttpRuntime.Cache["LastCostCenter" + HttpContext.Current.Session["CNN2"].ToString()])
                                                             where itm.Area == vArea
                                                             select itm).ToList();
                        ((DropDownList)sender).DataBind();
                        ((DropDownList)sender).Items.Insert(0, new ListItem("--- أختار الفرع---", "-1", true));
                        ((DropDownList)sender).SelectedValue = vCost;
                    }

                }
            }
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = ((DropDownList)sender).NamingContainer as GridViewRow;
            DropDownList ddlCostCenter = gvr.FindControl("ddlCostCenter") as DropDownList;
            if (ddlCostCenter != null)
            {
                string vCostCenter = "";
                if (ddlCostCenter.SelectedValue != "-1")
                {
                    vCostCenter = ddlCostCenter.SelectedValue;
                    ddlCostCenter.ClearSelection();
                }
                ddlCostCenter.DataTextField = "Name1";
                ddlCostCenter.DataValueField = "Code";
                ddlCostCenter.DataSource = (from itm in (List<CostCenter>)(HttpRuntime.Cache["LastCostCenter" + HttpContext.Current.Session["CNN2"].ToString()])
                                            where ((DropDownList)sender).SelectedValue == "-1" || itm.Area == ((DropDownList)sender).SelectedValue
                                            select itm).ToList();
                ddlCostCenter.DataBind();
                ddlCostCenter.Items.Insert(0, new ListItem("--- أختار الفرع---", "-1", true));
                if (vCostCenter != "" && ddlCostCenter.Items.FindByValue(vCostCenter) != null) ddlCostCenter.SelectedValue = vCostCenter;
            }
        }

        protected void ddlCostCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((DropDownList)sender).SelectedValue != "-1")
            {
                GridViewRow gvr = ((DropDownList)sender).NamingContainer as GridViewRow;
                DropDownList ddlArea = gvr.FindControl("ddlArea") as DropDownList;
                if (ddlArea != null)
                {
                    if (ddlArea.SelectedValue == "-1")
                    {
                        string vArea = (from itm in (List<CostCenter>)(HttpRuntime.Cache["LastCostCenter" + HttpContext.Current.Session["CNN2"].ToString()])
                                        where itm.Code == ((DropDownList)sender).SelectedValue
                                        select itm.Area).FirstOrDefault();
                        if (vArea != null)
                        {
                            ddlArea.SelectedValue = vArea;
                        }
                    }
                }
            }
        }
    }
}

