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
    public partial class WebBankPay : System.Web.UI.Page
    {
        public List<myInv2> VouData
        {
            get
            {
                if (ViewState["VouData"] == null)
                {
                    ViewState["VouData"] = new List<myInv2>();
                }
                return (List<myInv2>)ViewState["VouData"];
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
        public short LocType
        {
            get
            {
                if (ViewState["LocType"] == null)
                {
                    ViewState["LocType"] = 2;
                }
                return short.Parse(ViewState["LocType"].ToString());
            }
            set { ViewState["LocType"] = value; }
        }
        public string vRoleName
        {

            get
            {
                if (ViewState["RoleName"] == null)
                {
                    ViewState["RoleName"] = "Roll";
                }
                return ViewState["RoleName"].ToString();
            }
            set { ViewState["RoleName"] = value; }
        }
        public CostCenter SiteInfo
        {
            get
            {
                if (ViewState["SiteInfo"] == null)
                {
                    ViewState["SiteInfo"] = new CostCenter();
                }
                return (CostCenter)ViewState["SiteInfo"];
            }
            set { ViewState["SiteInfo"] = value; }
        }
        public void EditMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass275 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass245;
            BtnEdit.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass272 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass242;
            BtnNew.Visible = false;
            BtnDelete.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass273 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass243;

            if (Request.QueryString["FMode"] != null)
            {
                if (Request.QueryString["FMode"].ToString() == "0")
                {
                    if (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0")
                    {

                    }
                    else
                    {
                        if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass40)
                        {
                            BtnEdit.Visible = false;
                            BtnDelete.Visible = false;
                            BtnClear.Visible = false;
                        }
                    }
                }
            }

            if (BtnEdit.Visible || BtnDelete.Visible)
            {
                txtReason.Visible = true;
                ValReason.Enabled = true;
                lblReason.Visible = true;
            }
            if (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0")
            {
                if (!(bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass272) ControlsOnOff(false);
            }
            else if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass242) ControlsOnOff(false);
        }

        public void NewMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;
            
            //txtVouNo.ReadOnly = false;
            //txtVouNo.BackColor = System.Drawing.Color.White;

            BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass271 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass241;
            BtnDelete.Visible = false;

            txtReason.Visible = false;
            ValReason.Enabled = false;
            lblReason.Visible = false;
            if (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0")
            {
                if (!(bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass272) ControlsOnOff(true);
            }
            else if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass242) ControlsOnOff(true);
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
                BtnPrint.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnPrint);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttach);

                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["Flag"].ToString() == "0" && !(bool)((List<TblRoles>)(Session["Roll"]))[0].Pass27)
                    {
                        Response.Redirect("WebNotPrev.aspx", false);
                        return;
                    }

                    this.Page.Header.Title = GetLocalResourceObject("Title").ToString();  // "قسيمة إيداع بنكي";

                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetLocalResourceObject("Home").ToString(),GetLocalResourceObject("Select").ToString(), GetLocalResourceObject("SelectVou").ToString(), "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    if (Request.QueryString["AreaNo"] != null)
                    {
                        AreaNo = Request.QueryString["AreaNo"].ToString();
                        CostCenter myCost = new CostCenter();
                        myCost.Branch = 1;
                        if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCost.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCost.Code = Request.QueryString["AreaNo"].ToString();
                        myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                  where citm.Code == myCost.Code
                                  select citm).FirstOrDefault();
                        if (myCost != null) SiteInfo = myCost;
                    }
                    else
                    {
                        if (Session["AreaNo"] != null)
                        {
                            AreaNo = Session["AreaNo"].ToString();
                            SiteInfo = (CostCenter)Session["SiteInfo"];
                        }
                        else AreaNo = "1";
                    }
                    if (Request.QueryString["StoreNo"] != null) StoreNo = Request.QueryString["StoreNo"].ToString();
                    else
                    {
                        if (Session["StoreNo"] == null) Session["StoreNo"] = 1;
                        StoreNo = Session["StoreNo"].ToString();
                    }
                    if (Request.QueryString["Flag"] != null)
                    {
                        LocType = (short)(int.Parse(Request.QueryString["Flag"].ToString()) + 1);
                        if (Request.QueryString["Flag"].ToString() == "0") AreaNo = "1";                        
                    }
                    lblBranch2.Text = "/" + short.Parse(AreaNo).ToString();
                    Acc myacc = new Acc();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastACC" + Session["CNN2"].ToString()] == null) Cache.Insert("LastACC" + Session["CNN2"].ToString(), myacc.GetLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlDbCode.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                            where itm.FCode.StartsWith("120101") || itm.Code.StartsWith("120501001") || itm.Code.StartsWith("120502001")
                                            select itm).ToList();
                    ddlDbCode.DataTextField = "Name1";
                    ddlDbCode.DataValueField = "Code";
                    ddlDbCode.DataBind();
                    ddlDbCode.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectBank").ToString(), "-1", true));

                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    vRoleName = moh.GetCurrentRole(AreaNo, (from useritm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                                           where useritm.UserName == Session["CurrentUser"].ToString()
                                                           select useritm).FirstOrDefault());
                    if (Session[vRoleName] == null)
                    {
                        Response.Redirect("WebNotPrev.aspx", false);
                        return;
                    }

                    BtnNew.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass271 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass241;
                    BtnEdit.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass272 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass242;
                    BtnDelete.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass273 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass243;
                    BtnSearch.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass274 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass244;
                    BtnFind.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass274 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass244;
                    BtnPrint.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass275 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass245;

                    lblEmp.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0");
                    ddlEmp.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0");
                    lblCostAcc.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0");
                    ddlCostAcc.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0");
                    lblProject.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0");
                    ddlProject.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0");
                    lblCostCenter.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0");
                    ddlCostCenter.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0");
                    lblArea.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0");
                    ddlArea.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0");
                    if (ddlEmp.Visible)
                    {
                        Area myArea = new Area();
                        myArea.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["LastArea" + Session["CNN2"].ToString()] == null) Cache.Insert("LastArea" + Session["CNN2"].ToString(), myArea.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        ddlArea.DataTextField = "Name1";
                        ddlArea.DataValueField = "Code";
                        ddlArea.DataSource = (List<Area>)(Cache["LastArea" + Session["CNN2"].ToString()]);
                        ddlArea.DataBind();
                        ddlArea.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectArea").ToString(), "-1", true));

                        CostCenter myCostCenter = new CostCenter();
                        myCostCenter.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        ddlCostCenter.DataTextField = "Name1";
                        ddlCostCenter.DataValueField = "Code";
                        ddlCostCenter.DataSource = (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()]);
                        ddlCostCenter.DataBind();
                        ddlCostCenter.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectBranch").ToString(), "-1", true));

                        AccProject myProject = new AccProject();
                        myProject.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["LastProject" + Session["CNN2"].ToString()] == null) Cache.Insert("LastProject" + Session["CNN2"].ToString(), myProject.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        ddlProject.DataTextField = "Name1";
                        ddlProject.DataValueField = "Code";
                        ddlProject.DataSource = (List<AccProject>)(Cache["LastProject" + Session["CNN2"].ToString()]);
                        ddlProject.DataBind();
                        ddlProject.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectProject").ToString(), "-1", true));

                        CostAcc myCostAcc = new CostAcc();
                        myCostAcc.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["LastCostAcc" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostAcc" + Session["CNN2"].ToString(), myCostAcc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        ddlCostAcc.DataTextField = "Name1";
                        ddlCostAcc.DataValueField = "Code";
                        ddlCostAcc.DataSource = (List<CostAcc>)(Cache["LastCostAcc" + Session["CNN2"].ToString()]);
                        ddlCostAcc.DataBind();
                        ddlCostAcc.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectCost").ToString(), "-1", true));

                        ddlEmp.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectEmp").ToString(), "-1", true));
                    }
                    else
                    {
                        ddlArea.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectArea").ToString(), "-1", true));
                        ddlCostCenter.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectBranch").ToString(), "-1", true));
                        ddlProject.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectProject").ToString(), "-1", true));
                        ddlCostAcc.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectCost").ToString(), "-1", true));
                        ddlEmp.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectEmp").ToString(), "-1", true));
                    }

                    if (Request.QueryString["FNum"] != null)
                    {
                        if (Request.QueryString["FMode"] != null)
                        {
                            if (Request.QueryString["FMode"].ToString() == "0")
                            {
                                if (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0")
                                {
                                    BtnEdit.Visible = false;
                                    BtnDelete.Visible = false;
                                    BtnClear.Visible = false;
                                    ((HtmlGenericControl)this.Master.FindControl("menu")).Visible = false;
                                }
                                else
                                {
                                    if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass40)
                                    {
                                        BtnEdit.Visible = false;
                                        BtnDelete.Visible = false;
                                        BtnClear.Visible = false;
                                        ((HtmlGenericControl)this.Master.FindControl("menu")).Visible = false;
                                    }
                                }
                            }
                        }
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
                    Response.Redirect("GeneralServerError.aspx", false);
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
                NewMode();
                txtSearch.Text = "";
                ddlDbCode.SelectedIndex = 0;
                ddlArea.SelectedIndex = 0;
                ddlCostAcc.SelectedIndex = 0;
                ddlCostCenter.SelectedIndex = 0;
                ddlEmp.SelectedIndex = 0;
                ddlProject.SelectedIndex = 0;
                txtVouDate.Text = "";
                txtAmount.Text = "";
                txtReason.Text = "";
                txtRemark.Text = "";
                txtBankName.Text = "";
                txtchqNo.Text = "";
                txtChqDate.Text = "";
                txtPerson.Text = "";
                txtCode.Text = (LocType == 2 ? SiteInfo.CashAcc : "");
                txtName.Text = "";
                if (LocType == 2)
                {
                    Acc myAcc = new Acc();
                    myAcc.Branch = short.Parse(Session["Branch"].ToString());
                    myAcc.Code = SiteInfo.CashAcc;
                    if (myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        txtName.Text = myAcc.Name1;
                    }
                }
                RdoChq.Items[0].Selected = true;
                RdoChq_SelectedIndexChanged(sender, e);

                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                if (sender != null)
                {
                    txtVouNo.Text = "";
                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 105;
                    myJv.LocType = LocType;
                    myJv.LocNumber = short.Parse(AreaNo);
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
                LoadAttachData();
                LoadTransData();
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

        public void ControlsOnOff(bool State)
        {
            ddlDbCode.Enabled = State;
            txtVouDate.ReadOnly = !State;
            txtAmount.ReadOnly = !State;
            txtReason.ReadOnly = !State;
            txtRemark.ReadOnly = !State;
            txtBankName.ReadOnly = !State;
            txtchqNo.ReadOnly = !State;
            txtChqDate.ReadOnly = !State;
            txtPerson.ReadOnly = !State;
            txtCode.ReadOnly = !State;
            txtName.ReadOnly = !State;
            RdoChq.Enabled = State;
            txtVouDate.ReadOnly = !State;
            ddlArea.Enabled = State;
            ddlCostAcc.Enabled = State;
            ddlCostCenter.Enabled = State;
            ddlDbCode.Enabled = State;
            ddlProject.Enabled = State;
            ddlEmp.Enabled = State;

            // grdAttach.Enabled = State;
            foreach (GridViewRow itm in grdAttach.Rows)
            {
                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                if (BtnDelete != null) BtnDelete.Visible = State;
            }
            grdTrans.Enabled = State;
            FileUpload1.Enabled = State;
            BtnAttach.Enabled = State;
        }

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    ValidateNum();
                    if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    {
                        if (DateTime.Parse(txtVouDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("ClosedPeriod").ToString() + " " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
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
                        LblCodesResult.Text = GetLocalResourceObject("CreditAccNotFound").ToString(); // "الحساب الدائن غير معرف من قبل";                        
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 105;
                    myJv.LocType = LocType;
                    myJv.LocNumber = short.Parse(AreaNo);
                    myJv.Number = int.Parse(txtVouNo.Text);
                    myJv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myJv != null)
                    {
                        if (myJv.UserName == txtUserName.ToolTip)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("DuplicateVou").ToString();  // "رقم الايداع البنكي مكرر";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                        else
                        {
                            myJv = new Jv();
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.FType = 105;
                            myJv.LocType = LocType;
                            myJv.LocNumber = short.Parse(AreaNo);
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

                    if (Saveall())
                    {
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetLocalResourceObject("Title2").ToString(), GetLocalResourceObject("Add").ToString(), GetLocalResourceObject("AddVou").ToString() + " " + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = GetLocalResourceObject("SuccessAdd").ToString(); // "لقد تمت أضافة البيانات بنجاح";
                        SaveTrans(1);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        BtnClear_Click(sender, e);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("ErrorAdd").ToString();  //"لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
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
                    ValidateNum();
                    if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    {
                        if (DateTime.Parse(txtVouDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("ClosedPeriod").ToString() + " " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
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
                        LblCodesResult.Text = GetLocalResourceObject("CreditAccNotFound").ToString(); // "الحساب الدائن غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    List<Jv> ljv = new List<Jv>();
                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 105;
                    myJv.LocType = LocType;
                    myJv.LocNumber = short.Parse(AreaNo);
                    myJv.Number = int.Parse(txtVouNo.Text);
                    ljv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (ljv == null || ljv.Count() == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("VouNotFound").ToString();  // "رقم السند غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.FType = 105;
                        myJv.LocType = LocType;
                        myJv.LocNumber = short.Parse(AreaNo);
                        myJv.Number = int.Parse(txtVouNo.Text);
                        if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (Saveall())
                            {
                                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetLocalResourceObject("Title2").ToString(), GetLocalResourceObject("Edit").ToString(), GetLocalResourceObject("Edit").ToString() + " "  + lblBranch2.Text + "/" + txtVouNo.Text, txtReason.Text, IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                txtReason.Text = "";
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = GetLocalResourceObject("SuccessUpdate").ToString();  //"لقد تم تعديل البيانات بنجاح";
                                SaveTrans(2);
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                                BtnClear_Click(sender, e);
                            }
                            else
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = GetLocalResourceObject("ErrorUpdate").ToString(); // "لقد حدث خطأ أثناء تعديل البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            }
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("ErrorUpdate").ToString(); // "لقد حدث خطأ أثناء تعديل البيانات ... حاول مرة أخرى";
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
                    Response.Redirect("GeneralServerError.aspx", false);
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
                            LblCodesResult.Text = GetLocalResourceObject("ClosedPeriod").ToString() + " " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                    }
                    List<Jv> ljv = new List<Jv>();
                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 105;
                    myJv.LocType = LocType;
                    myJv.LocNumber = short.Parse(AreaNo);
                    myJv.Number = int.Parse(txtVouNo.Text);
                    ljv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (ljv == null || ljv.Count() == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("VouNotFound").ToString();  // "رقم السند غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.FType = 105;
                        myJv.LocType = LocType;
                        myJv.LocNumber = short.Parse(AreaNo);
                        myJv.Number = int.Parse(txtVouNo.Text);
                        if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetLocalResourceObject("Title2").ToString(), GetLocalResourceObject("Delete").ToString(), GetLocalResourceObject("DeleteVou2").ToString() + " " + lblBranch2.Text + "/" + txtVouNo.Text, txtReason.Text, IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            txtReason.Text = "";

                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = GetLocalResourceObject("SuccessDelete").ToString();  // "لقد تم الغاء البيانات بنجاح";
                            SaveTrans(3);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("ErrorDelete").ToString(); // "لقد حدث خطأ أثناء الغاء البيانات ... حاول مرة أخرى";
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
                    Response.Redirect("GeneralServerError.aspx", false);
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
                    myJv.FType = 105;
                    myJv.LocType = LocType;
                    myJv.LocNumber = short.Parse(AreaNo);
                    myJv.Number = int.Parse(txtSearch.Text);
                    BtnClear_Click(null, e);
                    lJv = myJv.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (lJv == null || lJv.Count == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("VouNotFound").ToString();   // "رقم السند غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetLocalResourceObject("Title2").ToString(), GetLocalResourceObject("View").ToString(), GetLocalResourceObject("ViewVou").ToString() + " "  + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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

                        if (ddlArea.Visible)
                        {
                            ddlArea.SelectedValue = lJv[1].Area;
                            ddlCostAcc.SelectedValue = lJv[1].CostAcc;
                            ddlCostCenter.SelectedValue = lJv[1].CostCenter;
                            ddlEmp.SelectedValue = lJv[1].EmpCode;
                            ddlProject.SelectedValue = lJv[1].Project;
                        }

                        ddlDbCode.SelectedValue = lJv[0].DbCode;
                        txtPerson.Text = lJv[0].Person;
                        txtBankName.Text = lJv[0].BankName;
                        txtChqDate.Text = lJv[0].ChequeDate;
                        txtchqNo.Text = lJv[0].ChequeNo;
                        txtAmount.Text = string.Format("{0:N2}", lJv[0].Amount);
                        txtRemark.Text = lJv[0].Remark;
                        if (txtBankName.Text != "" || txtChqDate.Text != "" || txtchqNo.Text != "")
                        {
                            RdoChq.Items[1].Selected = true;
                        }
                        else
                        {
                            RdoChq.Items[0].Selected = true;
                        }
                        RdoChq_SelectedIndexChanged(sender, e);
                        txtCode.Text = lJv[1].CrCode;
                        Acc myAcc = new Acc();
                        myAcc.Branch = short.Parse(Session["Branch"].ToString());
                        myAcc.Code = lJv[1].CrCode;
                        if (myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            txtName.Text = myAcc.Name1;
                        }                       
                        LoadAttachData();
                        LoadTransData();
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = GetLocalResourceObject("EnterVouNo").ToString(); // "يجب إدخال رقم السند";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
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

        protected void BtnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BtnSearch_Click(sender, e);
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

        protected void BtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    SaveTrans(4);
                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetLocalResourceObject("Title2").ToString(), GetLocalResourceObject("Print").ToString(), GetLocalResourceObject("PrintVou").ToString() + " " + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, -50, -50, 80, 50);
                    HttpContext.Current.Response.ContentType = "application/pdf";
                    PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
                    pdfPage page = new pdfPage();
                    MyConfig mySetting = new MyConfig();
                    mySetting.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    mySetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                    if (mySetting != null)
                    {
                        page.vCompanyName = mySetting.CompanyName;
                    }

                    writer.PageEvent = page;
                    page.vStr1 = "قسيمة إيداع بنكي";
                    page.vStr2 = "";

                    page.PageNo = "1";
                    page.UserName = Session["FullUser"].ToString();
                    page.vStr3 = LocType == 2 ? Session["AreaName"].ToString() : "الإدارة المالية" ;

                    string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                    BaseFont nationalBase;
                    nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font nationalTextFont14 = new iTextSharp.text.Font(nationalBase, 14f, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font nationalTextFont16 = new iTextSharp.text.Font(nationalBase, 16f, iTextSharp.text.Font.NORMAL);

                    document.Open();
                    int ColCount = 5;
                    var cols = new[] { 125, 100, 100, 225, 200 };
                    PdfPTable table10 = new PdfPTable(ColCount);
                    table10.TotalWidth = document.PageSize.Width; //100f;
                    table10.SetWidths(cols);
                    PdfPCell cell = new PdfPCell();
                    cell.Border = 0;
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    table10.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table10.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table10.AddCell(cell);

                    cell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell.Phrase = new iTextSharp.text.Phrase(" قسيمة إيداع بنكي رقم ", nationalTextFont16);
                    table10.AddCell(cell);

                    PdfPCell cell22 = new PdfPCell();
                    cell22.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell22.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell22.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell22.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell22.Phrase = new iTextSharp.text.Phrase(txtVouNo.Text + lblBranch2.Text, nationalTextFont16);
                    table10.AddCell(cell22);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table10.AddCell(cell);

                    var TextCell = new PdfPCell(table10.DefaultCell);
                    TextCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    TextCell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    //TextCell.Border = 0;
                    TextCell.BorderColor = iTextSharp.text.BaseColor.WHITE;
                    PdfContentByte cb = writer.DirectContent;
                    var bc128 = new Barcode128();
                    bc128.CodeType = Barcode.CODE128;
                    bc128.Code = lblBranch2.Text + txtVouNo.Text;
                    bc128.GenerateChecksum = true;
                    bc128.AltText = "";
                    bc128.StartStopText = true;

                    TextCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    //cell.AddElement(bc128.CreateImageWithBarcode(cb, null, null));                    
                    var bi = bc128.CreateImageWithBarcode(cb, null, null);
                    bi.ScalePercent(100);
                    bi.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    TextCell.AddElement(bi);

                    //cell.Image = bc128.CreateImageWithBarcode(cb, null, null);                    
                    //table.AddCell(cell);
                    table10.AddCell(TextCell);
                    document.Add(table10);
                    document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    //-------------------------------------------------------------------------------------------
                    ColCount = 4;
                    cols = new[] { 250, 140, 260, 160 };
                    PdfPTable table11 = new PdfPTable(ColCount);
                    table11.TotalWidth = document.PageSize.Width; //100f;
                    table11.SetWidths(cols);
                    cell = new PdfPCell();
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell.Border = 0;
                    //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    table11.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table11.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("التاريخ:", nationalTextFont14);
                    table11.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(txtVouDate.Text, nationalTextFont);
                    table11.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("نوع الإيداع:", nationalTextFont14);
                    table11.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if (RdoChq.Items[1].Selected) cell.Phrase = new iTextSharp.text.Phrase("بشيك", nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("نقداً", nationalTextFont);
                    table11.AddCell(cell);
//
                    //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("البنك المودع فيه:", nationalTextFont14);
                    table11.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(ddlDbCode.SelectedItem.Text, nationalTextFont);
                    table11.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("الحساب الدائن:", nationalTextFont14);
                    table11.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(txtName.Text, nationalTextFont);
                    table11.AddCell(cell);

//
                    //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("مبلغ وقدرة:", nationalTextFont14);
                    table11.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(txtAmount.Text+" ريال", nationalTextFont);
                    table11.AddCell(cell);


                    cell.Phrase = new iTextSharp.text.Phrase("وذلك عن:", nationalTextFont14);
                    table11.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(txtRemark.Text, nationalTextFont);
                    table11.AddCell(cell);

//                    
                    if (RdoChq.Items[1].Selected)
                    {
                        //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        cell.Phrase = new iTextSharp.text.Phrase("تاريخ الشيك:", nationalTextFont14);
                        table11.AddCell(cell);

                        //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        cell.Phrase = new iTextSharp.text.Phrase(txtChqDate.Text, nationalTextFont);
                        table11.AddCell(cell);

                        //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        cell.Phrase = new iTextSharp.text.Phrase("رقم الشيك:", nationalTextFont14);
                        table11.AddCell(cell);

                        //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        cell.Phrase = new iTextSharp.text.Phrase(txtchqNo.Text, nationalTextFont);
                        table11.AddCell(cell);


                        //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        cell.Phrase = new iTextSharp.text.Phrase("مسحوب على بنك:", nationalTextFont14);
                        table11.AddCell(cell);

                        //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        cell.Phrase = new iTextSharp.text.Phrase(txtBankName.Text, nationalTextFont);
                        table11.AddCell(cell);

                        //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        cell.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                        table11.AddCell(cell);

                        //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        cell.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                        table11.AddCell(cell);
                    }


                    if (ddlArea.Visible)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase("المنطقة:", nationalTextFont14);
                        table11.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase((ddlArea.SelectedIndex == 0 ? "" : ddlArea.SelectedItem.Text), nationalTextFont);
                        table11.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("المشروع:", nationalTextFont14);
                        table11.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase((ddlProject.SelectedIndex == 0 ? "" : ddlProject.SelectedItem.Text), nationalTextFont);
                        table11.AddCell(cell);
                        //
                        cell.Phrase = new iTextSharp.text.Phrase("الفرع:", nationalTextFont14);
                        table11.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase((ddlCostCenter.SelectedIndex == 0 ? "" : ddlCostCenter.SelectedItem.Text), nationalTextFont);
                        table11.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("حساب التكاليف:", nationalTextFont);
                        table11.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase((ddlCostAcc.SelectedIndex == 0 ? "" : ddlCostAcc.SelectedItem.Text), nationalTextFont);
                        table11.AddCell(cell);
                        //
                        cell.Phrase = new iTextSharp.text.Phrase("الموظف:", nationalTextFont14);
                        table11.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase((ddlEmp.SelectedIndex == 0 ? " " : ddlEmp.SelectedItem.Text), nationalTextFont);
                        table11.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                        table11.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                        table11.AddCell(cell);
                    }

                   //
                    document.Add(table11);
                    document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    PdfPTable table50 = new PdfPTable(5);
                    table50.TotalWidth = 100f;
                    PdfPCell cell5 = new PdfPCell();
                    var cols5 = new[] { 150, 150, 150, 150, 150 };
                    table50.SetWidths(cols5);
                    cell5.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    table50.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table50.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    cell5.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("المودع", nationalTextFont14);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("إدخلت بواسطة", nationalTextFont14);
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

                    cell5.Phrase = new iTextSharp.text.Phrase(txtPerson.Text, nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase(txtUserName.Text, nationalTextFont);
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

                    cell5.Phrase = new iTextSharp.text.Phrase(txtUserDate.Text, nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 2;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    //
                    for (int i = 0; i < 3; i++)
                    {
                        cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                        table50.AddCell(cell5);

                        cell5.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                        table50.AddCell(cell5);

                        cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                        table50.AddCell(cell5);

                        cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                        table50.AddCell(cell5);

                        cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                        table50.AddCell(cell5);
                    }

                    document.Add(table50);
                    document.Add(new iTextSharp.text.pdf.draw.LineSeparator());
                    document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    //-----------------------------------------------------------------------------------------------------------------

                    //string harialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                    //BaseFont hnationalBase;
                    //hnationalBase = BaseFont.CreateFont(harialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    //iTextSharp.text.Font hnationalTextFont = new iTextSharp.text.Font(hnationalBase, 16f, iTextSharp.text.Font.NORMAL);

                    ////I use a PdfPtable with 1 column to position my header where I want it
                    //PdfPTable headerTbl = new PdfPTable(3);
                    //var cols2 = new[] { 200, 300, 200 };
                    //headerTbl.SetWidths(cols2);

                    //headerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    //headerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    ////set the width of the table to be the same as the document
                    //headerTbl.TotalWidth = document.PageSize.Width;

                    //PdfPCell cell2 = new PdfPCell();
                    //cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell2.Border = 0;
                    //cell2.PaddingRight = 15;
                    //cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    //cell2.Phrase = new iTextSharp.text.Phrase(page.vCompanyName + "\n" + page.vStr3, hnationalTextFont);
                    //cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    //headerTbl.AddCell(cell2);

                    //cell2.PaddingRight = 0;
                    //page.vStr1 = " ";
                    //cell2.Phrase = new iTextSharp.text.Phrase(page.vStr1, hnationalTextFont);
                    //cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    //cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    //headerTbl.AddCell(cell2);

                    ////I use an image logo in the header so I need to get an instance of the image to be able to insert it. I believe this is something you couldn't do with older versions of iTextSharp
                    //iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("images/logo_naqlyat.png"));

                    ////I used a large version of the logo to maintain the quality when the size was reduced. I guess you could reduce the size manually and use a smaller version, but I used iTextSharp to reduce the scale. As you can see, I reduced it down to 7% of original size.
                    //logo.ScalePercent(70);

                    ////create instance of a table cell to contain the logo
                    //PdfPCell cell20 = new PdfPCell(logo);

                    ////align the logo to the right of the cell
                    //cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    ////add a bit of padding to bring it away from the right edge
                    //cell20.PaddingTop = 0;
                    //cell20.PaddingRight = 30;

                    ////remove the border
                    //cell20.Border = 0;

                    ////Add the cell to the table
                    //headerTbl.AddCell(cell20);
                    //document.Add(headerTbl);
                    //document.Add(table10);
                    //document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    //document.Add(table11);
                    //document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    //document.Add(table50);
                    //document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    //document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));

                    document.Close();
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
            finally
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
            }
        }


        // *************************************************** ITextSharp ****************************************************************
        public class pdfPage : iTextSharp.text.pdf.PdfPageEventHelper
        {
            public string vStr1, vStr2, vStr3, vStr4, UserName, PageNo, vCompanyName;
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
                var cols2 = new[] { 225, 250, 225 };
                headerTbl.SetWidths(cols2);

                headerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                //set the width of the table to be the same as the document
                headerTbl.TotalWidth = doc.PageSize.Width;

                PdfPCell cell2 = new PdfPCell();
                cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell2.Border = 0;
                cell2.PaddingRight = 15;
                cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell2.Phrase = new iTextSharp.text.Phrase(vCompanyName + "\n" + vStr3, nationalTextFont);
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                headerTbl.AddCell(cell2);

                cell2.PaddingRight = 0;
                vStr1 = " ";
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
                var cols2 = new[] { 175, 175, 275, 175 };
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
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                //set cell border to 0
                cell.Border = 2;

                //add some padding to bring away from the edge
                if (moh.PrintDateofPrint) cell.Phrase = new iTextSharp.text.Phrase("تاريخ الطباعة : " + String.Format("{0:dd/MM/yyyy}", moh.Nows()), footer);
                else cell.Phrase = new iTextSharp.text.Phrase(" ", footer);
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

                cell.Phrase = new iTextSharp.text.Phrase("صفحة رقم " + writer.PageNumber.ToString(), footer);
                footerTbl.AddCell(cell);

                //write the rows out to the PDF output stream.
                footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin - 10), writer.DirectContent);
            }
        }

        private bool Saveall()
        {
            try
            {
                short FNo = 1;
                Jv vJv = new Jv();
                vJv.Branch = short.Parse(Session["Branch"].ToString());
                vJv.FType = 105;
                vJv.LocType = LocType;
                vJv.LocNumber = short.Parse(AreaNo);
                vJv.Number = int.Parse(txtVouNo.Text);
                vJv.Post = 1;
                vJv.FDate = moh.CheckDate(txtVouDate.Text);
                vJv.DbCode = ddlDbCode.SelectedValue;
                vJv.Person = txtPerson.Text;
                vJv.CrCode = "";
                vJv.Area = "-1";
                vJv.CostCenter = "-1";
                vJv.Project = "-1";
                vJv.CostAcc = "-1";
                vJv.EmpCode = "-1";
                vJv.Remark = txtRemark.Text;
                vJv.BankName = txtBankName.Text;
                vJv.ChequeDate = txtChqDate.Text;
                vJv.ChequeNo = txtchqNo.Text;
                //vJv.InvNo = txtInvNo.Text;
                if (txtAmount.Text.Trim() == "") txtAmount.Text = "0";
                vJv.Amount = moh.StrToDouble(txtAmount.Text);
                vJv.FNo = FNo;
                vJv.UserName = txtUserName.ToolTip;
                vJv.UserDate = txtUserDate.Text;
                FNo++;
                if (vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    vJv = new Jv();
                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                    vJv.FType = 105;
                    vJv.LocType = LocType;
                    vJv.LocNumber = short.Parse(AreaNo);
                    vJv.Number = int.Parse(txtVouNo.Text);
                    vJv.Post = 1;
                    vJv.FDate = moh.CheckDate(txtVouDate.Text);
                    vJv.DbCode = "";
                    vJv.Person = txtPerson.Text;
                    vJv.CrCode = txtCode.Text;
                    if (ddlArea.Visible)
                    {
                        vJv.Area = ddlArea.SelectedValue;
                        vJv.CostCenter = ddlCostCenter.SelectedValue;
                        vJv.Project = ddlProject.SelectedValue;
                        vJv.CostAcc = (vJv.CrCode.StartsWith("3") ? ddlCostAcc.SelectedValue : "-1");
                        vJv.EmpCode = ddlEmp.SelectedValue;
                    }
                    else
                    {
                        vJv.Area = "-1";
                        vJv.CostCenter = "-1";
                        vJv.Project = "-1";
                        vJv.CostAcc = "-1";
                        vJv.EmpCode = "-1";
                    }
                    vJv.Remark = txtRemark.Text;
                    vJv.BankName = txtBankName.Text;
                    vJv.ChequeDate = txtChqDate.Text;
                    vJv.ChequeNo = txtchqNo.Text;
                    //vJv.InvNo = txtInvNo.Text;
                    if (txtAmount.Text.Trim() == "") txtAmount.Text = "0";
                    vJv.Amount = moh.StrToDouble(txtAmount.Text);
                    vJv.FNo = FNo;
                    vJv.UserName = txtUserName.ToolTip;
                    vJv.UserDate = txtUserDate.Text;
                    FNo++;
                    if (vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)) return true;                   
                }
                else return false;
                return true;
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
                return false;
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
                        myArch.LocNumber = (short)(LocType == 1 ? 0 : short.Parse(AreaNo));
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 509;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = (short)(LocType == 1 ? 0 : short.Parse(AreaNo));
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 509;
                        myArch.FileName = FileUpload1.FileName;
                        myArch.FileName2 = mySetting.ImagePath2 + FileName;
                        myArch.FNo = (short)i;
                        myArch.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetLocalResourceObject("Title2").ToString(), GetLocalResourceObject("AddAttach").ToString(), GetLocalResourceObject("AddAttachFile").ToString() + " " + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        LoadAttachData();
                    }

                    //    LblCodesResult.Text = "File name: " + FileUpload1.PostedFile.FileName + "<br>" + FileUpload1.PostedFile.ContentLength + " kb<br>" + "Content type: " + FileUpload1.PostedFile.ContentType;
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
                        LblCodesResult.Text = "ERROR: " + ex.Message.ToString();
                    }
                }
            else
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = GetLocalResourceObject("FileNotSelect").ToString();  // "لم بتم اختيار الملف";
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
                myArch.LocNumber = (short)(LocType == 1 ? 0 : short.Parse(AreaNo));
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = 509;
                myArch.FNo = short.Parse(FNo);
                myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetLocalResourceObject("Title2").ToString(), GetLocalResourceObject("DeleteAttach").ToString(), GetLocalResourceObject("DeleteAttachFile").ToString() + " " + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                LoadAttachData();
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

        public void LoadAttachData()
        {
            if (txtVouNo.Text != "")
            {
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(Session["Branch"].ToString());
                myArch.LocNumber = (short)(LocType == 1 ? 0 :  short.Parse(AreaNo));
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = 509;
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

        public void ValidateNum()
        {
            if (txtAmount.Text == "") txtAmount.Text = "0";
        }

        protected void RdoChq_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblChqNo.Visible = RdoChq.Items[1].Selected;
                lblChqDate.Visible = RdoChq.Items[1].Selected;
                lblBankName.Visible = RdoChq.Items[1].Selected;
                txtchqNo.Visible = RdoChq.Items[1].Selected;
                txtChqDate.Visible = RdoChq.Items[1].Selected;
                txtBankName.Visible = RdoChq.Items[1].Selected;
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


        public void SaveTrans(short? UOP)
        {
            string vUserDate2 = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
            short FNo = 1;
            Jv vJv = new Jv();
            vJv.UserDate2 = vUserDate2;
            vJv.UserOP = UOP;
            vJv.Branch = short.Parse(Session["Branch"].ToString());
            vJv.FType = 105;
            vJv.LocType = LocType;
            vJv.LocNumber = short.Parse(AreaNo);
            vJv.Number = int.Parse(txtVouNo.Text);
            vJv.Post = 1;
            vJv.FDate = moh.CheckDate(txtVouDate.Text);
            vJv.DbCode = ddlDbCode.SelectedValue;
            vJv.Person = txtPerson.Text;
            vJv.CrCode = "";
            vJv.Area = "-1";
            vJv.CostCenter = "-1";
            vJv.Project = "-1";
            vJv.CostAcc = "-1";
            vJv.EmpCode = "-1";
            vJv.Remark = txtRemark.Text;
            vJv.BankName = txtBankName.Text;
            vJv.ChequeDate = txtChqDate.Text;
            vJv.ChequeNo = txtchqNo.Text;
            //vJv.InvNo = txtInvNo.Text;
            if (txtAmount.Text.Trim() == "") txtAmount.Text = "0";
            vJv.Amount = moh.StrToDouble(txtAmount.Text);
            vJv.FNo = FNo;
            vJv.UserName = Session["FullUser"].ToString();
            vJv.UserDate = txtUserDate.Text;
            FNo++;
            if (vJv.pAdd(WebConfigurationManager.ConnectionStrings["MyCnnTrans"].ConnectionString))
            {
                vJv = new Jv();
                vJv.UserDate2 = vUserDate2;
                vJv.UserOP = UOP;
                vJv.Branch = short.Parse(Session["Branch"].ToString());
                vJv.FType = 105;
                vJv.LocType = LocType;
                vJv.LocNumber = short.Parse(AreaNo);
                vJv.Number = int.Parse(txtVouNo.Text);
                vJv.Post = 1;
                vJv.FDate = moh.CheckDate(txtVouDate.Text);
                vJv.DbCode = "";
                vJv.Person = txtPerson.Text;
                vJv.CrCode = txtCode.Text;
                if (ddlArea.Visible)
                {
                    vJv.Area = ddlArea.SelectedValue;
                    vJv.CostCenter = ddlCostCenter.SelectedValue;
                    vJv.Project = ddlProject.SelectedValue;
                    vJv.CostAcc = (vJv.CrCode.StartsWith("3") ? ddlCostAcc.SelectedValue : "-1");
                    vJv.EmpCode = ddlEmp.SelectedValue;
                }
                else
                {
                    vJv.Area = "-1";
                    vJv.CostCenter = "-1";
                    vJv.Project = "-1";
                    vJv.CostAcc = "-1";
                    vJv.EmpCode = "-1";
                }
                vJv.Remark = txtRemark.Text;
                vJv.BankName = txtBankName.Text;
                vJv.ChequeDate = txtChqDate.Text;
                vJv.ChequeNo = txtchqNo.Text;
                //vJv.InvNo = txtInvNo.Text;
                if (txtAmount.Text.Trim() == "") txtAmount.Text = "0";
                vJv.Amount = moh.StrToDouble(txtAmount.Text);
                vJv.FNo = FNo;
                vJv.UserName = Session["FullUser"].ToString();
                vJv.UserDate = txtUserDate.Text;
                FNo++;
                vJv.pAdd(WebConfigurationManager.ConnectionStrings["MyCnnTrans"].ConnectionString);
            }
        }

        protected void grdTrans_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string UserDate2 = grdTrans.DataKeys[e.NewSelectedIndex]["UserDate2"].ToString();
            List<vJv> lJv = new List<vJv>();
            Jv myJv = new Jv();
            myJv.Branch = short.Parse(Session["Branch"].ToString());
            myJv.FType = 105;
            myJv.LocType = LocType;
            myJv.LocNumber = short.Parse(AreaNo);
            myJv.Number = int.Parse(txtVouNo.Text);
            myJv.UserDate2 = UserDate2;
            // BtnClear_Click(null, e);
            lJv = myJv.pfind2(WebConfigurationManager.ConnectionStrings["MyCnnTrans"].ConnectionString);
            if (lJv == null || lJv.Count == 0)
            {
            }
            else
            {
                // if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "ايداع بنكي", "عرض", "عرض بيانات الايداع البنكي رقم " + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                EditMode();
                VouData.Clear();
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
                ddlDbCode.SelectedValue = lJv[0].DbCode;
                if (ddlArea.Visible)
                {
                    ddlArea.SelectedValue = lJv[0].Area;
                    ddlCostAcc.SelectedValue = lJv[0].CostAcc;
                    ddlCostCenter.SelectedValue = lJv[0].CostCenter;
                    ddlEmp.SelectedValue = lJv[0].EmpCode;
                    ddlProject.SelectedValue = lJv[0].Project;
                }
                txtPerson.Text = lJv[0].Person;
                txtBankName.Text = lJv[0].BankName;
                txtChqDate.Text = lJv[0].ChequeDate;
                txtchqNo.Text = lJv[0].ChequeNo;
                txtAmount.Text = string.Format("{0:N2}", lJv[0].Amount);
                txtRemark.Text = lJv[0].Remark;
                if (txtBankName.Text != "" || txtChqDate.Text != "" || txtchqNo.Text != "")
                {
                    RdoChq.Items[1].Selected = true;
                }
                else
                {
                    RdoChq.Items[0].Selected = true;
                }
                RdoChq_SelectedIndexChanged(sender, e);
                txtCode.Text = lJv[1].CrCode;
                Acc myAcc = new Acc();
                myAcc.Branch = short.Parse(Session["Branch"].ToString());
                myAcc.Code = lJv[1].CrCode;
                if (myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    txtName.Text = myAcc.Name1;
                }
                LoadAttachData();
                BtnNew.Visible = false;
                BtnEdit.Visible = false;
                BtnDelete.Visible = false;
                BtnPrint.Visible = false;
            }
        }

        public void LoadTransData()
        {
            if (txtVouNo.Text != "")
            {
                Jv myJv = new Jv();
                myJv.Branch = short.Parse(Session["Branch"].ToString());
                myJv.FType = 105;
                myJv.LocType = LocType;
                myJv.LocNumber = short.Parse(AreaNo);
                myJv.Number = int.Parse(txtVouNo.Text);

                List<Jv> lJv = new List<Jv>();
                lJv = myJv.pGetList(WebConfigurationManager.ConnectionStrings["MyCnnTrans"].ConnectionString);
                grdTrans.DataSource = lJv;
                grdTrans.DataBind();

                if (lJv == null || lJv.Count == 0)
                {
                    cpeDemo2.Collapsed = true;
                    cpeDemo2.ClientState = "true";
                }
                else
                {
                    cpeDemo2.Collapsed = false;
                    cpeDemo2.ClientState = "false";
                }

            }
        }


        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCostCenter.DataSource = (from itm in (List<CostCenter>)(HttpRuntime.Cache["LastCostCenter" + HttpContext.Current.Session["CNN2"].ToString()])
                                        where ddlArea.SelectedValue == "-1" || itm.Area == ddlArea.SelectedValue
                                        select itm).ToList();
            ddlCostCenter.DataBind();
            ddlCostCenter.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectBranch").ToString(), "-1", true));
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
                        ddlCostCenter.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectBranch").ToString(), "-1", true));
                        ddlCostCenter.SelectedValue = vCost;
                    }

                }
            }
        }

    }
}
