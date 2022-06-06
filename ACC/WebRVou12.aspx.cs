using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;
using iTextSharp.text.pdf;
using System.IO;
using System.Configuration;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class WebRVou12 : System.Web.UI.Page
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
        public short LocType
        {
            get
            {
                if (ViewState["LocType"] == null)
                {
                    ViewState["LocType"] = 1;
                }
                return (short)(ViewState["LocType"]);
            }
            set { ViewState["LocType"] = value; }
        }
        public short LocNumber
        {
            get
            {
                if (ViewState["LocNumber"] == null)
                {
                    ViewState["LocNumber"] = 1;
                }
                return (short)(ViewState["LocNumber"]);
            }
            set { ViewState["LocNumber"] = value; }
        }

        public void EditMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = true && (Request.QueryString["FType"].ToString() == "1" ? (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass245:(bool)((List<TblRoles>)(Session["Roll"]))[0].Pass255);
            BtnEdit.Visible = true && (Request.QueryString["FType"].ToString() == "1" ? (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass242:(bool)((List<TblRoles>)(Session["Roll"]))[0].Pass252);
            BtnNew.Visible = false;
            BtnDelete.Visible = true && (Request.QueryString["FType"].ToString() == "1" ? (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass243:(bool)((List<TblRoles>)(Session["Roll"]))[0].Pass253);

            if (BtnEdit.Visible || BtnDelete.Visible)
            {
                txtReason.Visible = true;
                ValReason.Enabled = true;
                lblReason.Visible = true;
            }
            if(!(Request.QueryString["FType"].ToString() == "1" ? (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass242 : (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass252)) ControlsOnOff(false);
        }

        public void NewMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            //txtVouNo.ReadOnly = false;
            //txtVouNo.BackColor = System.Drawing.Color.White;

            BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = true && (Request.QueryString["FType"].ToString() == "1" ? (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass241:(bool)((List<TblRoles>)(Session["Roll"]))[0].Pass251);
            BtnDelete.Visible = false;

            txtReason.Visible = false;
            ValReason.Enabled = false;
            lblReason.Visible = false;
            if (!(Request.QueryString["FType"].ToString() == "1" ? (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass242 : (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass252)) ControlsOnOff(true);
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
                    if (!(bool)((List<TblRoles>)(Session["Roll"]))[0].Pass24)
                    {
                        Response.Redirect("WebNotPrev.aspx", false);
                        return;
                    }

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


                    if (Request.QueryString["FType"] == null) Response.Redirect("default.aspx");
                    else if (Request.QueryString["FType"].ToString() == "1")
                    {
                        this.Page.Header.Title = "سندات القبض";
                        BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass241;
                        BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass242;
                        BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass243;
                        BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass244;
                        BtnFind.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass244;
                        BtnPrint.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass245;
                        ddlDocType.Visible = false;
                        BtnInvFind.Visible = false;
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormName = "الرئيسية";
                            UserTran.FormAction = "اختيار";
                            UserTran.Description = "تم اختيار صفحة سندات القبض";
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }
                    }
                    else
                    {
                        this.Page.Header.Title = "سندات الصرف";
                        lblHead.Text = "[ سند الصرف ]";
                        Label6.Text = "ادفعوا لأمر";
                        BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass251;
                        BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass252;
                        BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass253;
                        BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass254;
                        BtnFind.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass254;
                        BtnPrint.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass255;

                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormName = "الرئيسية";
                            UserTran.FormAction = "اختيار";
                            UserTran.Description = "تم اختيار صفحة سندات الصرف";
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }
                    }


                    Acc myacc = new Acc();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastACC" + Session["CNN2"].ToString()] == null) Cache.Insert("LastACC" + Session["CNN2"].ToString(), myacc.GetLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlDbCode.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                             where itm.FCode.StartsWith("120101") || itm.FCode.StartsWith("120102") || itm.FCode.StartsWith("120103") || itm.FCode.StartsWith("1205")
                                             select itm).ToList();
                    ddlDbCode.DataTextField = "Name1";
                    ddlDbCode.DataValueField = "Code";
                    ddlDbCode.DataBind();
                    ddlDbCode.Items.Insert(0, new ListItem("--- أختار حساب الصندوق - البنك - العهده ---", "-1", true));

                    Area myArea = new Area();
                    myArea.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastArea" + Session["CNN2"].ToString()] == null) Cache.Insert("LastArea" + Session["CNN2"].ToString(), myArea.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlArea.DataTextField = "Name1";
                    ddlArea.DataValueField = "Code";
                    ddlArea.DataSource = (List<Area>)(Cache["LastArea" + Session["CNN2"].ToString()]);
                    ddlArea.DataBind();
                    ddlArea.Items.Insert(0, new ListItem("--- أختار المنطقة---", "-1", true));

                    CostCenter myCostCenter = new CostCenter();
                    myCostCenter.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlCostCenter.DataTextField = "Name1";
                    ddlCostCenter.DataValueField = "Code";
                    ddlCostCenter.DataSource = (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()]);
                    ddlCostCenter.DataBind();
                    ddlCostCenter.Items.Insert(0, new ListItem("--- أختار الفرع---", "-1", true));

                    AccProject myProject = new AccProject();
                    myProject.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastProject" + Session["CNN2"].ToString()] == null) Cache.Insert("LastProject" + Session["CNN2"].ToString(), myProject.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlProject.DataTextField = "Name1";
                    ddlProject.DataValueField = "Code";
                    ddlProject.DataSource = (List<AccProject>)(Cache["LastProject" + Session["CNN2"].ToString()]);
                    ddlProject.DataBind();
                    ddlProject.Items.Insert(0, new ListItem("--- أختار المشروع---", "-1", true));

                    CostAcc myCostAcc = new CostAcc();
                    myCostAcc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastCostAcc" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostAcc" + Session["CNN2"].ToString(), myCostAcc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlCostAcc.DataTextField = "Name1";
                    ddlCostAcc.DataValueField = "Code";
                    ddlCostAcc.DataSource = (List<CostAcc>)(Cache["LastCostAcc" + Session["CNN2"].ToString()]);
                    ddlCostAcc.DataBind();
                    ddlCostAcc.Items.Insert(0, new ListItem("--- أختار حساب التكاليف---", "-1", true));

                    ddlEmp.Items.Insert(0, new ListItem("--- أختار الموظف---", "-1", true));
                    LocType = 1;
                    LocNumber = 1;

                    if (Request.QueryString["FNum"] != null)
                    {
                        txtSearch.Text = Request.QueryString["FNum"].ToString();
                        if (Request.QueryString["LocNumber"] != null) LocNumber = short.Parse(Request.QueryString["LocNumber"].ToString());
                        if (Request.QueryString["LocType"] != null) LocType = short.Parse(Request.QueryString["LocType"].ToString());
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

        protected void BtnClear_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                txtVouNo.Text = "";
                txtSearch.Text = "";
                txtVouDate.Text = "";
                txtReason.Text = "";
                txtAmount.Text = "";
                txtRemark.Text = "";
                txtCode.Text = "";
                txtName.Text = "";
                txtBankName.Text = "";
                txtchqNo.Text = "";
                txtChqDate.Text = "";
                txtPerson.Text = "";
                ddlDocType.SelectedIndex=0;
                ChkCheque.Checked = false;
                ChkCheque_CheckedChanged(sender, e);
                ddlArea.SelectedIndex = 0;
                ddlCostAcc.SelectedIndex = 0;
                ddlCostCenter.SelectedIndex = 0;
                ddlDbCode.SelectedIndex = 0;
                ddlProject.SelectedIndex = 0;
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                txtInvNo.Text = "";
                NewMode();
                if (sender != null)
                {
                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    if (Request.QueryString["FType"].ToString() == "1")  myJv.FType = 101;
                    else myJv.FType = 102;
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
            CalendarExtender2.Enabled = State;
            txtReason.ReadOnly = !State;
            txtAmount.ReadOnly = !State;
            txtRemark.ReadOnly = !State;
            txtCode.ReadOnly = !State;
            txtName.ReadOnly = !State;
            txtBankName.ReadOnly = !State;
            txtchqNo.ReadOnly = !State;
            txtChqDate.ReadOnly = !State;
            ChkCheque.Enabled = State;
            ddlArea.Enabled = State;
            ddlCostAcc.Enabled = State;
            ddlCostCenter.Enabled = State;
            ddlDbCode.Enabled = State;
            ddlProject.Enabled = State;
            ddlEmp.Enabled = State;
            txtInvNo.ReadOnly = !State;
            ddlDocType.Enabled = State;
            txtPerson.ReadOnly = !State;
        }

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    {
                        if (DateTime.Parse(txtVouDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                    }

                    Acc myAcc = new Acc();
                    myAcc.Branch = short.Parse(Session["Branch"].ToString());
                    myAcc.Code = txtCode.Text;
                    if (!myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الحساب غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }
                    else
                    {
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
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }

                        // Check to force Entering of Project
                        if ((bool)myAcc.CheckProject && ddlProject.SelectedValue == "-1")
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الحساب مرتبط بمشروع ... يجب أختيار المشروع";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }

                        // Check to force Entering of Cost Acc
                        if ((bool)myAcc.CheckCostAcc && ddlCostAcc.SelectedValue == "-1")
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الحساب مرتبط بحسابات التكاليف ... يجب أختيار حساب التكاليف";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }

                        // Check to force Entering of Emp
                        if ((bool)myAcc.CheckEmp && ddlEmp.SelectedValue == "-1")
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الحساب مرتبط بالموظفين ... يجب أختيار الموظف";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }

                        /*
                        if ((bool)myAcc.CheckCarNo && txtCarNo.Text.Trim() == "")
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الحساب مرتبط بشاحنة ... يجب أختيار الشاحنة";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }
                         */

                        List<Jv> ljv = new List<Jv>();
                        Jv myJv = new Jv();
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        if (Request.QueryString["FType"].ToString() == "1") myJv.FType = 101;
                        else myJv.FType = 102;
                        myJv.LocType = LocType;
                        myJv.LocNumber = LocNumber;
                        myJv.Number = int.Parse(txtVouNo.Text);
                        ljv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (ljv != null && ljv.Count()>0)
                        {
                            if (ljv[0].UserName == txtUserName.ToolTip)
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "رقم السند مكرر";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                            else
                            {
                                myJv = new Jv();
                                myJv.Branch = short.Parse(Session["Branch"].ToString());
                                if (Request.QueryString["FType"].ToString() == "1") myJv.FType = 101;
                                else myJv.FType = 102;
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

                        if(Saveall())
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.FormName = (Request.QueryString["FType"].ToString() == "1") ? "سند القبض" : "سند الصرف";
                                UserTran.FormAction = "اضافة";
                                UserTran.Description = "اضافة " + UserTran.FormName + " رقم " + txtVouNo.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }

                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                            string vNumber = txtVouNo.Text;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                            PrintMe(vNumber);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
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

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    {
                        if (DateTime.Parse(txtVouDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                    }

                    Acc myAcc = new Acc();
                    myAcc.Branch = short.Parse(Session["Branch"].ToString());
                    myAcc.Code = txtCode.Text;
                    if (!myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الحساب غير معرف من قبل";                        
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    else
                    {
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
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }

                        // Check to force Entering of Project
                        if ((bool)myAcc.CheckProject && ddlProject.SelectedValue == "-1")
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الحساب مرتبط بمشروع ... يجب أختيار المشروع";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }

                        // Check to force Entering of Cost Acc
                        if ((bool)myAcc.CheckCostAcc && ddlCostAcc.SelectedValue == "-1")
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الحساب مرتبط بحسابات التكاليف ... يجب أختيار حساب التكاليف";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }

                        // Check to force Entering of Emp
                        if ((bool)myAcc.CheckEmp && ddlEmp.SelectedValue == "-1")
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الحساب مرتبط بالموظفين ... يجب أختيار الموظف";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }

                        /*
                        if ((bool)myAcc.CheckCarNo && txtCarNo.Text.Trim() == "")
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الحساب مرتبط بشاحنة ... يجب أختيار الشاحنة";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }
                         */


                        List<Jv> ljv = new List<Jv>();
                        Jv myJv = new Jv();
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        if (Request.QueryString["FType"].ToString() == "1") myJv.FType = 101;
                        else myJv.FType = 102;
                        myJv.LocType = LocType;
                        myJv.LocNumber = LocNumber;
                        myJv.Number = int.Parse(txtVouNo.Text);
                        ljv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (ljv == null || ljv.Count() == 0)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم السند غير معرف من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            if (Request.QueryString["FType"].ToString() == "1") myJv.FType = 101;
                            else myJv.FType = 102;
                            myJv.LocType = LocType;
                            myJv.LocNumber = LocNumber;
                            myJv.Number = int.Parse(txtVouNo.Text);
                            if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                if (Saveall())
                                {
                                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                                    {
                                        Transactions UserTran = new Transactions();
                                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                        UserTran.UserName = Session["CurrentUser"].ToString();
                                        UserTran.FormName = (Request.QueryString["FType"].ToString() == "1") ? "سند القبض" : "سند الصرف";
                                        UserTran.FormAction = "تعديل";
                                        UserTran.Description = "تعديل " + UserTran.FormName + " رقم " + txtVouNo.Text;
                                        UserTran.Reason = txtReason.Text;
                                        UserTran.IP = IPNetworking.GetIP4Address();
                                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                    }
                                    txtReason.Text = "";

                                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                    LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                                    string vNumber = txtVouNo.Text;
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                                    BtnClear_Click(sender, e);
                                    PrintMe(vNumber);
                                }
                                else
                                {
                                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                    LblCodesResult.Text = "لقد حدث خطأ أثناء تعديل البيانات ... حاول مرة أخرى";
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                }
                            }
                            else
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء تعديل البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
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
                    if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    {
                        if (DateTime.Parse(txtVouDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                    }

                    List<Jv> ljv = new List<Jv>();
                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    if (Request.QueryString["FType"].ToString() == "1") myJv.FType = 101;
                    else myJv.FType = 102;
                    myJv.LocType = LocType;
                    myJv.LocNumber = LocNumber;
                    myJv.Number = int.Parse(txtVouNo.Text);
                    ljv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (ljv == null || ljv.Count() == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم السند غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);                        
                    }
                    else
                    {
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        if (Request.QueryString["FType"].ToString() == "1") myJv.FType = 101;
                        else myJv.FType = 102;
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
                                UserTran.FormName = (Request.QueryString["FType"].ToString() == "1") ? "سند القبض" : "سند الصرف";
                                UserTran.FormAction = "الغاء";
                                UserTran.Description = "الغاء " + UserTran.FormName + " رقم " + txtVouNo.Text;
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

                        List<vJv> lJv = new List<vJv>();
                        Jv myJv = new Jv();
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        if (Request.QueryString["FType"].ToString() == "1") myJv.FType = 101;
                        else myJv.FType = 102;
                        myJv.LocType = LocType;
                        myJv.LocNumber = LocNumber;
                        myJv.Number = int.Parse(txtSearch.Text);
                        lJv = myJv.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (lJv == null || lJv.Count == 0)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم السند غير معرف من قبل";                            
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
                                UserTran.FormName = (Request.QueryString["FType"].ToString() == "1") ? "سند القبض" : "سند الصرف";
                                UserTran.FormAction = "عرض";
                                UserTran.Description = "عرض بيانات " + UserTran.FormName + " رقم " + txtVouNo.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }

                            EditMode();
                            txtVouNo.Text = lJv[0].Number.ToString();
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
                            if (Request.QueryString["FType"].ToString() == "1") 
                            {
                                ddlDbCode.SelectedValue = lJv[0].DbCode;
                                txtCode.Text = lJv[1].CrCode;
                                txtName.Text = lJv[1].AccName1;
                                ddlArea.SelectedValue = lJv[1].Area;
                                ddlCostAcc.SelectedValue = lJv[1].CostAcc;
                                ddlCostCenter.SelectedValue = lJv[1].CostCenter;
                                ddlEmp.SelectedValue = lJv[1].EmpCode;
                                ddlProject.SelectedValue = lJv[1].Project;
                            }
                            else
                            {
                                txtCode.Text = lJv[0].DbCode;
                                txtName.Text = lJv[0].AccName1;
                                ddlDbCode.SelectedValue = lJv[1].CrCode;
                                ddlArea.SelectedValue = lJv[0].Area;
                                ddlCostAcc.SelectedValue = lJv[0].CostAcc;
                                ddlCostCenter.SelectedValue = lJv[0].CostCenter;
                                ddlEmp.SelectedValue = lJv[0].EmpCode;
                                ddlProject.SelectedValue = lJv[0].Project;
                            }
                            ddlDocType.SelectedIndex = (short)lJv[0].DocType;
                            txtPerson.Text = lJv[0].Person;
                            txtAmount.Text = string.Format("{0:N2}", lJv[0].Amount);
                            txtBankName.Text = lJv[0].BankName;
                            txtChqDate.Text = lJv[0].ChequeDate;
                            txtchqNo.Text = lJv[0].ChequeNo;
                            ChkCheque.Checked = false;
                            if (txtBankName.Text != "" || txtChqDate.Text != "" || txtchqNo.Text != "") ChkCheque.Checked = true;
                            ChkCheque_CheckedChanged(sender, e);
                            txtInvNo.Text = lJv[0].InvNo;
                            txtRemark.Text = lJv[0].Remark;                            
                        }
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب إدخال رقم القيد";
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

        public void PrintMe(String Number)
        {
            if (Request.QueryString["FType"].ToString() == "1")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=101&LocType=" + LocType.ToString() + "&LocNumber=" + LocNumber.ToString() + "&Number=" + Number + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=102&LocType=" + LocType.ToString() + "&LocNumber=" + LocNumber.ToString() + "&Number=" + Number + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
            }
            return;
        }

        protected void BtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = (Request.QueryString["FType"].ToString() == "1") ? "سند القبض" : "سند الصرف";
                        UserTran.FormAction = "طباعة";
                        UserTran.Description = "طباعة بيانات " + UserTran.FormName + " رقم " + txtVouNo.Text;
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }
                    PrintMe(txtVouNo.Text);
                    return;
                    
                    /*
                    iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, -50, -50, 80, 50);
                    HttpContext.Current.Response.ContentType = "application/pdf";
                    PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
                    pdfPage page = new pdfPage();
                    MyConfig mySetting = new MyConfig();
                    mySetting.Branch = short.Parse(Session["Branch"].ToString());
                    mySetting = mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (mySetting != null)
                    {
                        page.vCompanyName = mySetting.CompanyName;
                    }

                    writer.PageEvent = page;
                    if (Request.QueryString["FType"].ToString() == "1")
                    {
                        page.vStr1 = "سند القبض";
                        page.vStr2 = "أستلمنا من";
                    }
                    else
                    {
                        page.vStr1 = "سند الصرف";
                        page.vStr2 = "صرفنا على";
                    }
                    page.PageNo = "1";
                    page.UserName = Session["FullUser"].ToString();

                    int ColCount = 4;                    
                    var cols = new[] { 275,125, 300, 100 };
                    document.Open();
                    PdfPTable table = new PdfPTable(ColCount);
                    table.TotalWidth = document.PageSize.Width; //100f;
                    table.SetWidths(cols);
                    PdfPCell cell = new PdfPCell();
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell.FixedHeight = 20f;

                    //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";                    
                    BaseFont nationalBase;
                    nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    //cell.Border = 0;
                    cell.Phrase = new iTextSharp.text.Phrase("رقم السند", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(txtVouNo.Text, nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("التاريخ", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(txtVouDate.Text, nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase(page.vStr2, nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(txtName.Text, nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("رقم المستند", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(txtInvNo.Text, nationalTextFont);
                    table.AddCell(cell);


                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("المنطقة", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if(ddlArea.SelectedIndex>0) cell.Phrase = new iTextSharp.text.Phrase(ddlArea.SelectedItem.Text, nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("نوع الدفع", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if (ChkCheque.Checked) cell.Phrase = new iTextSharp.text.Phrase("بشيك", nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("نقداً", nationalTextFont);
                    table.AddCell(cell);


                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("الفرع", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if(ddlCostCenter.SelectedIndex>0) cell.Phrase = new iTextSharp.text.Phrase(ddlCostCenter.SelectedItem.Text, nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    if (ChkCheque.Checked) cell.Phrase = new iTextSharp.text.Phrase("تاريخ الشيك", nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if (ChkCheque.Checked) cell.Phrase = new iTextSharp.text.Phrase(txtChqDate.Text, nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);

                    table.AddCell(cell);


                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("المشروع", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if(ddlProject.SelectedIndex>0) cell.Phrase = new iTextSharp.text.Phrase(ddlProject.SelectedItem.Text, nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    if (ChkCheque.Checked) cell.Phrase = new iTextSharp.text.Phrase("رقم الشيك", nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if (ChkCheque.Checked) cell.Phrase = new iTextSharp.text.Phrase(txtchqNo.Text, nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                    table.AddCell(cell);


                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("حساب التكاليف", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if(ddlCostAcc.SelectedIndex>0) cell.Phrase = new iTextSharp.text.Phrase(ddlCostAcc.SelectedItem.Text, nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    if (ChkCheque.Checked) cell.Phrase = new iTextSharp.text.Phrase("مسحوب على بنك", nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if (ChkCheque.Checked) cell.Phrase = new iTextSharp.text.Phrase(txtBankName.Text, nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                    table.AddCell(cell);


                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("الموظف", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if(ddlEmp.SelectedIndex>0) cell.Phrase = new iTextSharp.text.Phrase(ddlEmp.SelectedItem.Text, nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("مبلغ وقدرة", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(txtAmount.Text + " ريال", nationalTextFont);
                    table.AddCell(cell);
                    document.Add(table);

                    cols = new[] { 700, 100 };                    
                    PdfPTable table9 = new PdfPTable(2);
                    table9.TotalWidth = document.PageSize.Width; //100f;
                    table9.SetWidths(cols);
                    PdfPCell cell9 = new PdfPCell();
                    cell9.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    table9.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table9.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    cell9.Phrase = new iTextSharp.text.Phrase("وذلك عن", nationalTextFont);
                    cell9.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    //cell.Border = 0;
                    table9.AddCell(cell9);

                    cell9.Phrase = new iTextSharp.text.Phrase(txtRemark.Text, nationalTextFont);
                    cell9.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    //cell.Border = 0;
                    table9.AddCell(cell9);


                    document.Add(table9);


                    PdfPTable table5 = new PdfPTable(4);
                    table5.TotalWidth = 100f;

                    var cols5 = new[] { 275, 125, 300, 100 };
                    table5.SetWidths(cols5);
                    PdfPCell cell5 = new PdfPCell();
                    cell5.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell5.FixedHeight = 20f;

                    table5.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table5.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    cell5.Phrase = new iTextSharp.text.Phrase("إدخلت بواسطة", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    //cell.Border = 0;
                    table5.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase(txtUserName.Text, nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table5.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("تاريخ الإدخال", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table5.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase(txtUserDate.Text, nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table5.AddCell(cell5);

                    document.Add(table5);
                    document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));

                    PdfPTable table50 = new PdfPTable(5);
                    table50.TotalWidth = 100f;
                    cell5 = new PdfPCell();
                    cols5 = new[] { 150, 150,150, 150, 150 };
                    table50.SetWidths(cols5);
                    cell5.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    table50.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table50.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    cell5.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("المستلم", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Border = 0;
                    table50.AddCell(cell5);


                    cell5.Phrase = new iTextSharp.text.Phrase("الحسابات", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

//
                    cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

//
                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);


                    cell5.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 2;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 2;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    document.Add(table50);
                    document.Close();
                     */
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
            finally
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true,false), true);
            }
        }


        // *************************************************** ITextSharp ****************************************************************
        /*
        public class pdfPage : iTextSharp.text.pdf.PdfPageEventHelper
        {
            public string vStr1, vStr2, vStr3, vStr4, UserName, PageNo , vCompanyName;
            //I create a font object to use within my footer
            protected iTextSharp.text.Font footer
            {
                get
                {
                    // create a basecolor to use for the footer font, if needed.
                    iTextSharp.text.BaseColor grey = new iTextSharp.text.BaseColor(128, 128, 128);
                    string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";                    
                    BaseFont nationalBase;
                    nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(nationalBase, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.WHITE);
                    return font;
                }
            }
            //override the OnStartPage event handler to add our header
            public override void OnStartPage(PdfWriter writer, iTextSharp.text.Document doc)
            {
                string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";                    
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 16f, iTextSharp.text.Font.NORMAL);

                //I use a PdfPtable with 1 column to position my header where I want it
                PdfPTable headerTbl = new PdfPTable(3);
                var cols2 = new[] { 200, 300, 200 };
                headerTbl.SetWidths(cols2);

                headerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                //set the width of the table to be the same as the document
                headerTbl.TotalWidth = doc.PageSize.Width;

                PdfPCell cell2 = new PdfPCell();
                cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell2.Border = 0;
                cell2.PaddingRight = 15;
                cell2.Phrase = new iTextSharp.text.Phrase(vCompanyName, nationalTextFont);
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                headerTbl.AddCell(cell2);

                cell2.PaddingRight = 0;
                cell2.Phrase = new iTextSharp.text.Phrase(vStr1, nationalTextFont);
                cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                headerTbl.AddCell(cell2);

                //I use an image logo in the header so I need to get an instance of the image to be able to insert it. I believe this is something you couldn't do with older versions of iTextSharp
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("images/logo_naqlyat.png"));

                //I used a large version of the logo to maintain the quality when the size was reduced. I guess you could reduce the size manually and use a smaller version, but I used iTextSharp to reduce the scale. As you can see, I reduced it down to 7% of original size.
                logo.ScalePercent(70);

                //create instance of a table cell to contain the logo
                PdfPCell cell20 = new PdfPCell(logo);

                //align the logo to the right of the cell
                cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                //add a bit of padding to bring it away from the right edge
                cell20.PaddingTop = 0;
                cell20.PaddingRight = 30;

                //remove the border
                cell20.Border = 0;

                //Add the cell to the table
                headerTbl.AddCell(cell20);
                headerTbl.WriteSelectedRows(0, -1, -1, (doc.PageSize.Height - 20), writer.DirectContent);
            }

            //override the OnPageEnd event handler to add our footer
            public override void OnEndPage(PdfWriter writer, iTextSharp.text.Document doc)
            {
                //I use a PdfPtable with 2 columns to position my footer where I want it
                PdfPTable footerTbl = new PdfPTable(4);
                var cols2 = new[] { 200, 200, 200, 200 };
                footerTbl.SetWidths(cols2);
                footerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                footerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                //set the width of the table to be the same as the document
                footerTbl.TotalWidth = doc.PageSize.Width;
                //Center the table on the page
                footerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                PdfPCell cell = new PdfPCell();
                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell.BackgroundColor = iTextSharp.text.BaseColor.RED;
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                //set cell border to 0
                cell.Border = 2;

                //add some padding to bring away from the edge
                cell.PaddingRight = 5;
                cell.Phrase = new iTextSharp.text.Phrase("تاريخ الطباعة : " + String.Format("{0:dd/MM/yyyy}", moh.Nows()), footer);
                //add cell to table
                footerTbl.AddCell(cell);

                //create new instance of cell to hold the text
                //cell = new PdfPCell();

                //align the text to the right of the cell
                //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell.Phrase = new iTextSharp.text.Phrase("طبعت بواسطة " + UserName, footer);

                // add some padding to take away from the edge of the page
                //cell.PaddingRight = 5;

                //add the cell to the table
                footerTbl.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("عدد مرات الطباعة " + PageNo, footer);
                footerTbl.AddCell(cell);

                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell.Phrase = new iTextSharp.text.Phrase("صفحة رقم " + writer.PageNumber.ToString(), footer);

                // add some padding to take away from the edge of the page
                cell.PaddingLeft = 5;

                //add the cell to the table
                footerTbl.AddCell(cell);

                //write the rows out to the PDF output stream.
                footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin - 10), writer.DirectContent);
            }
        }
         */

        protected void ChkCheque_CheckedChanged(object sender, EventArgs e)
        {
           try
            {
                lblChqNo.Visible = ChkCheque.Checked;
                lblChqDate.Visible = ChkCheque.Checked;
                lblBankName.Visible = ChkCheque.Checked;
                txtchqNo.Visible = ChkCheque.Checked;
                txtChqDate.Visible = ChkCheque.Checked;
                txtBankName.Visible = ChkCheque.Checked;
                if (ChkCheque.Checked && ddlDbCode.SelectedIndex>0) txtBankName.Text = ddlDbCode.SelectedItem.Text;
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
        
        private bool Saveall()
        {
            Jv vJv = new Jv();
            vJv.Branch = short.Parse(Session["Branch"].ToString());
            if (Request.QueryString["FType"].ToString() == "1") vJv.FType = 101;
            else vJv.FType = 102;
            vJv.LocType = LocType;
            vJv.LocNumber = LocNumber;
            vJv.Number = int.Parse(txtVouNo.Text);
            vJv.Post = 1;
            vJv.FDate = moh.CheckDate(txtVouDate.Text);
            if (Request.QueryString["FType"].ToString() == "1")
            {
                vJv.DbCode = ddlDbCode.SelectedValue;
                vJv.CrCode = "";
                vJv.Area = "-1";
                vJv.CostCenter = "-1";
                vJv.Project = "-1";
                vJv.CostAcc = "-1";
                vJv.EmpCode = "-1";
            }
            else
            {
                vJv.DbCode = txtCode.Text;
                vJv.CrCode = "";

                if (ddlArea.SelectedIndex > 0) vJv.Area = ddlArea.SelectedValue;
                else vJv.Area = "-1";
                if (ddlCostCenter.SelectedIndex > 0) vJv.CostCenter = ddlCostCenter.SelectedValue;
                else vJv.CostCenter = "-1";
                if (ddlProject.SelectedIndex > 0) vJv.Project = ddlProject.SelectedValue;
                else vJv.Project = "-1";
                if (ddlCostAcc.SelectedIndex > 0) vJv.CostAcc = ddlCostAcc.SelectedValue;
                else vJv.CostAcc = "-1";
                if (ddlEmp.SelectedIndex > 0) vJv.EmpCode = ddlEmp.SelectedValue;
                else vJv.EmpCode = "-1";
            }
            vJv.DocType = (short)ddlDocType.SelectedIndex;
            vJv.Person = txtPerson.Text;
            vJv.Remark = txtRemark.Text;
            vJv.BankName = txtBankName.Text;
            vJv.ChequeDate = txtChqDate.Text;
            vJv.ChequeNo = txtchqNo.Text;
            vJv.InvNo = txtInvNo.Text;
            vJv.Amount = moh.StrToDouble(txtAmount.Text);
            vJv.FNo = 1;
            vJv.UserName = txtUserName.ToolTip;
            vJv.UserDate = txtUserDate.Text;
            if (vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            {
                vJv = new Jv();
                vJv.Branch = short.Parse(Session["Branch"].ToString());
                if (Request.QueryString["FType"].ToString() == "1") vJv.FType = 101;
                else vJv.FType = 102;
                vJv.LocType = LocType;
                vJv.LocNumber = LocNumber;
                vJv.Number = int.Parse(txtVouNo.Text);
                vJv.Post = 1;
                vJv.FDate = moh.CheckDate(txtVouDate.Text);
                if (Request.QueryString["FType"].ToString() == "2")
                {
                    vJv.CrCode = ddlDbCode.SelectedValue;
                    vJv.DbCode = "";
                    vJv.Area = "-1";
                    vJv.CostCenter = "-1";
                    vJv.Project = "-1";
                    vJv.CostAcc = "-1";
                    vJv.EmpCode = "-1";
                }
                else
                {
                    vJv.CrCode = txtCode.Text;
                    vJv.DbCode = "";

                    if (ddlArea.SelectedIndex > 0) vJv.Area = ddlArea.SelectedValue;
                    else vJv.Area = "-1";
                    if (ddlCostCenter.SelectedIndex > 0) vJv.CostCenter = ddlCostCenter.SelectedValue;
                    else vJv.CostCenter = "-1";
                    if (ddlProject.SelectedIndex > 0) vJv.Project = ddlProject.SelectedValue;
                    else vJv.Project = "-1";
                    if (ddlCostAcc.SelectedIndex > 0) vJv.CostAcc = ddlCostAcc.SelectedValue;
                    else vJv.CostAcc = "-1";
                    if (ddlEmp.SelectedIndex > 0) vJv.EmpCode = ddlEmp.SelectedValue;
                    else vJv.EmpCode = "-1";
                }
                vJv.Remark = txtRemark.Text;
                vJv.BankName = txtBankName.Text;
                vJv.ChequeDate = txtChqDate.Text;
                vJv.ChequeNo = txtchqNo.Text;
                vJv.InvNo = txtInvNo.Text;
                vJv.Amount = moh.StrToDouble(txtAmount.Text);
                vJv.FNo = 2;
                vJv.UserName = txtUserName.ToolTip;
                vJv.UserDate = txtUserDate.Text;
                vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                return true;
            }
            else return false;
        }

        protected void BtnInvFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Jv vJv = new Jv();
                vJv.Branch = short.Parse(Session["Branch"].ToString());
                vJv.FType = 102;
                vJv.LocType = LocType;
                vJv.LocNumber = LocNumber;

                vJv.FType = 102;
                vJv.LocType = 2;
                //vJv.LocNumber = short.Parse(AreaNo);
                vJv.InvNo = Request.QueryString["CarMove"].ToString();
                vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (vJv != null)
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "تم أدراج المستند في سند الصرف رقم " + vJv.LocNumber.ToString() + "/" + vJv.Number.ToString();
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    return;
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

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCostCenter.DataSource = (from itm in (List<CostCenter>)(HttpRuntime.Cache["LastCostCenter" + HttpContext.Current.Session["CNN2"].ToString()])
                                        where ddlArea.SelectedValue == "-1" || itm.Area == ddlArea.SelectedValue
                                        select itm).ToList();
            ddlCostCenter.DataBind();
            ddlCostCenter.Items.Insert(0, new ListItem("--- أختار الفرع---", "-1", true));
        }

        protected void ddlCostCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCostCenter.SelectedValue != "-1")
            {
                if (ddlArea.SelectedValue == "-1")
                {
                    string vArea = (from itm in (List<CostCenter>)(HttpRuntime.Cache["LastCostCenter" + HttpContext.Current.Session["CNN2"].ToString()])
                                    where itm.Code == ((DropDownList)sender).SelectedValue
                                    select itm.Area).FirstOrDefault();
                    if (vArea != null)
                    {
                        ddlArea.SelectedValue = vArea;
                        string vCost = ddlCostCenter.SelectedValue;
                        ddlCostCenter.DataSource = (from itm in (List<CostCenter>)(HttpRuntime.Cache["LastCostCenter" + HttpContext.Current.Session["CNN2"].ToString()])
                                                             where itm.Area == vArea
                                                             select itm).ToList();
                        ddlCostCenter.DataBind();
                        ddlCostCenter.Items.Insert(0, new ListItem("--- أختار الفرع---", "-1", true));
                        ddlCostCenter.SelectedValue = vCost;
                    }

                }
            }
        }

    }    
}
