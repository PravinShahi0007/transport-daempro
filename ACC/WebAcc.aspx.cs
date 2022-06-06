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
    public partial class WebAcc : System.Web.UI.Page
    {
        public bool AccountType = false; // Should Change and Switch According to Clients
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
        private short CurLevel
        {
            get
            {
                if (ViewState["CurLevel"] == null)
                {
                    ViewState["CurLevel"] = 1;
                }
                return short.Parse(ViewState["CurLevel"].ToString());
            }
            set { ViewState["CurLevel"] = value; }
        }
        private string fcode
        {
            get
            {
                if (ViewState["fcode"] == null)
                {
                    ViewState["fcode"] = "";
                }
                return ViewState["fcode"].ToString();
            }
            set { ViewState["fcode"] = value; }
        }

        public void EditMode()
        {
            txtCode.ReadOnly = true;
            txtCode.BackColor = System.Drawing.Color.LightGray;

            BtnEdit.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass112;
            BtnNew.Visible = false;
            BtnDelete.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass113;

            if (BtnEdit.Visible || BtnDelete.Visible)
            {
                txtReason.Visible = true;
                ValReason.Enabled = true;
                lblReason.Visible = true;
            }
            if (!(bool)((List<TblRoles>)(Session["Roll"]))[0].Pass112) ControlsOnOff(false);
        }

        public void NewMode()
        {
            txtCode.ReadOnly = false;
            txtCode.BackColor = System.Drawing.Color.White;

            BtnEdit.Visible = false;
            BtnNew.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass111;
            BtnDelete.Visible = false;

            txtReason.Visible = false;
            ValReason.Enabled = false;
            lblReason.Visible = false;
            if (!(bool)((List<TblRoles>)(Session["Roll"]))[0].Pass112) ControlsOnOff(true);
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
                    this.Page.Header.Title = GetLocalResourceObject("Title").ToString();  // "الحسابات التحليلية";
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


                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetGlobalResourceObject("Resource", "Home").ToString(), GetGlobalResourceObject("Resource", "Select").ToString(), GetLocalResourceObject("SelectPage").ToString(), "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    fcode = "";
                    string[] ax = new string[2];
                    ax[0] = "FCode";
                    ax[1] = "Code";
                    grdCodes.DataKeyNames = ax;
                    LoadAccData();

                    AccCenter myCenter = new AccCenter();
                    myCenter.Branch = short.Parse(Session["Branch"].ToString());
                    ddlCenter.DataSource = myCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlCenter.DataTextField = "Name1";
                    ddlCenter.DataValueField = "Code";
                    ddlCenter.DataBind();
                    ddlCenter.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectAccountCenter").ToString(), "-1", true));
                    ddlCenter.SelectedIndex = 0;

                    Coin myCoin = new Coin();
                    myCoin.Branch = short.Parse(Session["Branch"].ToString());
                    ddlCoin.DataSource = myCoin.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlCoin.DataTextField = "Shape";
                    ddlCoin.DataValueField = "Code";
                    ddlCoin.DataBind();

                    Acc myacc = new Acc();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastACC" + Session["CNN2"].ToString()] == null) Cache.Insert("LastACC" + Session["CNN2"].ToString(), myacc.GetLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlDepCode.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                              where itm.FCode.StartsWith("220302") select itm).ToList();
                    ddlDepCode.DataTextField = "Name1";
                    ddlDepCode.DataValueField = "Code";
                    ddlDepCode.DataBind();
                    ddlDepCode.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectAcDep").ToString(), "-1", true));

                    myacc = new Acc();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    ddlCost.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                             where itm.FCode.StartsWith("310202")
                                             select itm).ToList();
                    ddlCost.DataTextField = "Name1";
                    ddlCost.DataValueField = "Code";
                    ddlCost.DataBind();
                    ddlCost.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectWorkShopExp").ToString(), "-1", true));

                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    ddlAcDep.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                             where itm.FCode.StartsWith("3201") select itm).ToList();
                    ddlAcDep.DataTextField = "Name1";
                    ddlAcDep.DataValueField = "Code";
                    ddlAcDep.DataBind();
                    ddlAcDep.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectDepAccount").ToString(), "-1", true));

                    ddlSType2.Items.Add(new ListItem(GetLocalResourceObject("SelectAccountType").ToString(), "0", true));
                    ddlSType2.Items.Add(new ListItem(GetLocalResourceObject("SelectFixed").ToString(), "1", true));
                    ddlSType2.Items.Add(new ListItem(GetLocalResourceObject("SelectCash").ToString(), "2", true));
                    ddlSType2.Items.Add(new ListItem(GetLocalResourceObject("SelectBank").ToString(), "3", true));
                    ddlSType2.Items.Add(new ListItem(GetLocalResourceObject("SelectLoan").ToString(), "4", true));
                    ddlSType2.Items.Add(new ListItem(GetLocalResourceObject("SelectCustomer").ToString(), "5", true));
                    ddlSType2.Items.Add(new ListItem(GetLocalResourceObject("SelectVendor").ToString(), "6", true));
                    ddlSType2.Items.Add(new ListItem(GetLocalResourceObject("SelectDep").ToString(), "7", true));
                    ddlSType2.Items.Add(new ListItem(GetLocalResourceObject("SelectOther").ToString(), "8", true));
                    ddlSType2.SelectedIndex = 0;


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
                    ddlCostAcc.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectCostAcc").ToString(), "-1", true));

                    SEmp myemp = new SEmp();
                    if (Cache["Emps" + Session["CNN2"].ToString()] == null) Cache.Insert("Emps" + Session["CNN2"].ToString(), myemp.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlEmpCode.DataTextField = "Name";
                    ddlEmpCode.DataValueField = "EmpCode";
                    ddlEmpCode.DataSource = (List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()]);
                    ddlEmpCode.DataBind();
                    ddlEmpCode.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectEmp").ToString(), "-1", true));

                    Cars myCar = new Cars();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlCarNo.DataTextField = "CarType";
                    ddlCarNo.DataValueField = "Code";
                    ddlCarNo.DataSource = (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()]);
                    ddlCarNo.DataBind();
                    ddlCarNo.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectCar").ToString(), "-1", true));

                    BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass111;
                    BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass112;
                    BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass113;
                    BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass114;

                    NewMode();
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


        protected void LoadAccData()
        {
            try
            {
                Acc myacc = new Acc();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                myacc.FCode = fcode;
                grdCodes.DataSource = myacc.GetAllAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                grdCodes.DataBind();

                if (CurLevel == 5)
                {
                    BtnClear_Click(BtnClear, null);
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

        protected void grdCodes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                if (CurLevel < 5)
                {
                    string FCode = grdCodes.DataKeys[e.NewSelectedIndex]["FCode"].ToString();
                    string Code = grdCodes.DataKeys[e.NewSelectedIndex]["Code"].ToString();
                    GridViewRow gvr = grdCodes.Rows[e.NewSelectedIndex];
                    Label txtName1 = gvr.FindControl("lblName1") as Label;

                    CurLevel++;
                    fcode = Code;
                    LoadAccData();

                    switch (CurLevel)
                    {
                        case 1:
                            LbtnLevel1.Visible = true;
                            LbtnLevel2.Visible = false;
                            LbtnLevel3.Visible = false;
                            LbtnLevel4.Visible = false;
                            LbtnLevel5.Visible = false;
                            Panel2.Visible = false;
                            break;
                        case 2:
                            LbtnLevel1.Visible = true;
                            LbtnLevel2.Visible = true;
                            LbtnLevel2.Text = " :: " + txtName1.Text;
                            LbtnLevel2.ToolTip = Code.ToString();
                            LbtnLevel3.Visible = false;
                            LbtnLevel4.Visible = false;
                            LbtnLevel5.Visible = false;
                            Panel2.Visible = false;
                            break;
                        case 3:
                            LbtnLevel1.Visible = true;
                            LbtnLevel2.Visible = true;
                            LbtnLevel3.Visible = true;
                            LbtnLevel3.Text = " :: " + txtName1.Text;
                            LbtnLevel3.ToolTip = Code.ToString();
                            LbtnLevel4.Visible = false;
                            LbtnLevel5.Visible = false;
                            Panel2.Visible = false;
                            break;
                        case 4:
                            LbtnLevel1.Visible = true;
                            LbtnLevel2.Visible = true;
                            LbtnLevel3.Visible = true;
                            LbtnLevel4.Visible = true;
                            LbtnLevel4.Text = " :: " + txtName1.Text;
                            LbtnLevel4.ToolTip = Code.ToString();
                            Panel2.Visible = false;
                            break;
                        case 5:
                            LbtnLevel1.Visible = true;
                            LbtnLevel2.Visible = true;
                            LbtnLevel3.Visible = true;
                            LbtnLevel4.Visible = true;
                            LbtnLevel5.Visible = true;
                            LbtnLevel5.Text = " :: " + txtName1.Text;
                            LbtnLevel5.ToolTip = Code.ToString();

                            Panel2.Visible = true;
                            ChkDepDo.Visible = (fcode == "120503");

                            lblCost.Visible = fcode.StartsWith("1202");
                            ddlCost.Visible = fcode.StartsWith("1202");

                            Acc myacc = new Acc();
                            myacc.Branch = short.Parse(Session["Branch"].ToString());
                            myacc.FCode = fcode;
                            myacc.Code = Code;
                            if (myacc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                SetType(myacc.FType);                            
                            }
                            if (!CostCenters.Visible) CostCenters.Visible = fcode.StartsWith("1205");
                            break;                             
                    }
                    e.NewSelectedIndex = -1;
                }
                else
                {
                    BtnClear_Click(sender, null);
                    string FCode = grdCodes.DataKeys[e.NewSelectedIndex]["FCode"].ToString();
                    string Code = grdCodes.DataKeys[e.NewSelectedIndex]["Code"].ToString();
                    fcode = FCode;
                    txtCode.Text = Code.Substring(6, 3);
                    BtnSearch_Click(sender, null);
                    //LblCodesResult.Text = "لقد تم الوصول الى أخر مستوى للتصنيف";
                    //e.NewSelectedIndex = -1;
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
                    e.NewSelectedIndex = -1;
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
                LoadAccData();
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

        protected void LbtnLevel1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                switch (int.Parse(e.CommandName))
                {
                    case 1:
                        LbtnLevel1.Visible = true;
                        LbtnLevel2.Visible = false;
                        LbtnLevel3.Visible = false;
                        LbtnLevel4.Visible = false;
                        LbtnLevel5.Visible = false;
                        Panel2.Visible = false;
                        fcode = "";
                        CurLevel = 1;
                        LoadAccData();
                        break;
                    case 2:
                        LbtnLevel1.Visible = true;
                        LbtnLevel2.Visible = true;
                        LbtnLevel3.Visible = false;
                        LbtnLevel4.Visible = false;
                        LbtnLevel5.Visible = false;
                        fcode = LbtnLevel2.ToolTip;
                        Panel2.Visible = false;
                        CurLevel = 2;
                        LoadAccData();
                        break;
                    case 3:
                        LbtnLevel1.Visible = true;
                        LbtnLevel2.Visible = true;
                        LbtnLevel3.Visible = true;
                        LbtnLevel4.Visible = false;
                        LbtnLevel5.Visible = false;
                        fcode = LbtnLevel3.ToolTip;
                        Panel2.Visible = false;
                        CurLevel = 3;
                        LoadAccData();
                        break;
                    case 4:
                        LbtnLevel1.Visible = true;
                        LbtnLevel2.Visible = true;
                        LbtnLevel3.Visible = true;
                        LbtnLevel4.Visible = true;
                        LbtnLevel5.Visible = false;
                        fcode = LbtnLevel4.ToolTip;
                        Panel2.Visible = false;
                        CurLevel = 4;
                        LoadAccData();
                        break;
                    case 5:
                        LbtnLevel1.Visible = true;
                        LbtnLevel2.Visible = true;
                        LbtnLevel3.Visible = true;
                        LbtnLevel4.Visible = true;
                        LbtnLevel5.Visible = true;
                        Panel2.Visible = true;
                        fcode = LbtnLevel5.ToolTip;
                        CurLevel = 5;
                        LoadAccData();
                        break;
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

        public void ControlsOnOff(bool State)
        {
            txtName.ReadOnly = !State;
            txtName2.ReadOnly = !State;
            txtocacc.ReadOnly = !State;
            txtodacc.ReadOnly = !State;
            txtFcacc.ReadOnly = !State;
            txtFdacc.ReadOnly = !State;
            txtRemark.ReadOnly = !State;
            txtReason.ReadOnly = !State;
            ChkDepDo.Enabled = State;
            ddlCenter.Enabled = State;
            ddlCenter.Enabled = State;
            ddlSType2.Enabled = State;
            txtDepAmount.ReadOnly = !State;
            txtDepPer.ReadOnly = !State;
            txtFixPurDate.ReadOnly = !State;
            txtFixPurch.ReadOnly = !State;
            ddlAcDep.Enabled = State;
            ddlCost.Enabled = State;
            ddlDepCode.Enabled = State;
            ddlArea.Enabled = State;
            ddlCarNo.Enabled = State;
            ddlCostAcc.Enabled = State;
            ddlCostCenter.Enabled = State;
            ddlProject.Enabled = State;
            ddlEmpCode.Enabled = State;
            ChkCarNo.Enabled = State;
            ChkArea.Enabled = State;
            ChkCostAcc.Enabled = State;
            ChkCostCenter.Enabled = State;
            ChkEmp.Enabled = State;
            ChkProject.Enabled = State;
        }

        protected void BtnClear_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ChkCarNo.Checked = false;
                ChkArea.Checked = false;
                ChkCostAcc.Checked = false;
                ChkCostCenter.Checked = false;
                ChkEmp.Checked = false;
                ChkProject.Checked = false;
                txtCode.Text = "";
                txtName.Text = "";
                txtName2.Text = "";
                txtocacc.Text = "";
                txtodacc.Text = "";
                txtFcacc.Text = "";
                txtFdacc.Text = "";
                txtRemark.Text = "";
                txtReason.Text = "";
                ChkDepDo.Checked = false;
                ddlCenter.SelectedIndex = 1;
                ddlCenter.SelectedIndex = 0;
                ddlSType2.SelectedIndex = 0;
                LblCodesResult.Text = "";
                txtDepAmount.Text = "";
                txtDepPer.Text = "";
                txtFixPurDate.Text = "";
                txtFixPurch.Text = "";
                ddlAcDep.SelectedIndex = 0;
                ddlCost.SelectedIndex = 0;
                ddlDepCode.SelectedIndex = 0;
                ddlArea.SelectedIndex = 0;
                ddlCarNo.SelectedIndex = 0;
                ddlCostAcc.SelectedIndex = 0;
                ddlCostCenter.SelectedIndex = 0;
                ddlProject.SelectedIndex = 0;
                ddlEmpCode.SelectedIndex = 0;
                NewMode();
                Acc myacc = new Acc();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                myacc.FCode = fcode;
                string s = myacc.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (s != null)
                {
                    s = s.Substring(6, 3);
                    txtCode.Text = moh.MakeMask((Int32.Parse(s) + 1).ToString(), 3);
                }
                else
                {
                    txtCode.Text = "001";
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

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    txtCode.Text = moh.MakeMask(txtCode.Text, 3);
                    Acc myacc = new Acc();

                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.Code = fcode + txtCode.Text;
                    if (myacc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        bool vfound = true;
                        while (vfound)
                        {
                            txtCode.Text = moh.MakeMask((Int32.Parse(txtCode.Text) + 1).ToString(), 3);
                            myacc.Code = fcode + txtCode.Text;
                            vfound = myacc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                    }

                    if (txtodacc.Text == "") txtodacc.Text = "0";
                    if (txtocacc.Text == "") txtocacc.Text = "0";
                    if (txtFcacc.Text == "") txtFcacc.Text = "0";
                    if (txtFdacc.Text == "") txtFdacc.Text = "0";
                    if (txtDepPer.Text == "") txtDepPer.Text = "0";
                    if (txtFixPurch.Text == "") txtFixPurch.Text = "0";
                    if (txtName2.Text == "") txtName2.Text = txtName.Text;
                    if (txtDepAmount.Text == "") txtDepAmount.Text ="0";

                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.Code = fcode;
                    if (myacc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        myacc.Branch = short.Parse(Session["Branch"].ToString());
                        myacc.FCode = fcode;
                        myacc.Code = fcode + txtCode.Text;
                        myacc.MCode = txtCode.Text;
                        myacc.Name1 = txtName.Text;                        
                        myacc.Name2 = txtName2.Text;
                        myacc.Remark = txtRemark.Text;
                        myacc.ODAcc = moh.StrToDouble(txtodacc.Text);
                        myacc.OCAcc = moh.StrToDouble(txtocacc.Text);
                        myacc.FCAcc = moh.StrToDouble(txtFcacc.Text);
                        myacc.FDAcc = moh.StrToDouble(txtFdacc.Text);
                        myacc.DAcc = 0;
                        myacc.CAcc = 0;
                        myacc.DepAmount = moh.StrToDouble(txtDepAmount.Text);
                        myacc.DepPer = moh.StrToDouble(txtDepPer.Text);
                        myacc.FixPurch = moh.StrToDouble(txtFixPurch.Text);
                        myacc.Stype1 = ddlSType2.SelectedValue;
                        myacc.LastLevel = true;
                        myacc.FLevel = CurLevel;
                        myacc.Coin = ddlCoin.SelectedValue;
                        myacc.BatchCode = ddlCenter.SelectedValue;
                        myacc.DepCode = ddlDepCode.SelectedValue;
                        myacc.ACDep = ddlAcDep.SelectedValue;
                        myacc.FixPurDate = txtFixPurDate.Text;
                        myacc.CheckArea = ChkArea.Checked;
                        myacc.CheckCostAcc = ChkCostAcc.Checked;
                        myacc.CheckEmp = ChkEmp.Checked;
                        myacc.CheckProject = ChkProject.Checked;
                        myacc.CheckCostCenter = ChkCostCenter.Checked;
                        myacc.CheckCarNo = ChkCarNo.Checked;
                        myacc.Area = ddlArea.SelectedValue;
                        myacc.CostCenter = ddlCostCenter.SelectedValue;
                        myacc.Project = ddlProject.SelectedValue;
                        myacc.CostAcc = ddlCostAcc.SelectedValue;
                        myacc.EmpCode = ddlEmpCode.SelectedValue;
                        myacc.CarNo = ddlCarNo.SelectedValue;
                        if (ChkDepDo.Visible) myacc.DepDo = ChkDepDo.Checked ? "1" : "";
                        if (ddlCost.Visible) myacc.ACDep = ddlCost.SelectedValue;
                        if (myacc.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            PutCars(myacc, myacc.Code.Substring(4, 5));
                            if (ChkDepDo.Visible && ChkDepDo.Checked) PutTech(myacc, myacc.Code.Substring(4, 5));
                            PutEmp(myacc, myacc.Code.Substring(4, 5));
                            LoadAccData();

                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetLocalResourceObject("Title").ToString(), GetLocalResourceObject("Add").ToString(), GetLocalResourceObject("AddAccount").ToString() + " " + myacc.Code + " " + myacc.Name1, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = GetLocalResourceObject("SaveSuccess").ToString(); // "لقد تم حفظ البيانات بنجاح";
                            SetACCCache();
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("ErrorSave").ToString(); // "لقد حدث خطأ اثناء حفظ البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("ErrorSave").ToString();  // "لقد حدث خطأ اثناء حفظ البيانات ... حاول مرة أخرى";
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
                    //SoundPlayer sp = new SoundPlayer(Server.MapPath("") + @"/ching.wav");
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }

        public void SetType(string Ftype)
        {
            ddlSType2.Items[0].Enabled = true;
            ddlSType2.Items[1].Enabled = false;
            ddlSType2.Items[2].Enabled = false;
            ddlSType2.Items[3].Enabled = false;
            ddlSType2.Items[4].Enabled = false;
            ddlSType2.Items[5].Enabled = false;
            ddlSType2.Items[6].Enabled = false;
            ddlSType2.Items[7].Enabled = false;
            ddlSType2.Items[8].Enabled = true;

            FixAssets.Visible = false;
            CostCenters.Visible = false;

            if (Ftype == "1")
            {
                ddlSType2.Items[1].Enabled = true;
                FixAssets.Visible = true;
                CostCenters.Visible = true;
            }
            else if (Ftype == "2")
            {
                ddlSType2.Items[2].Enabled = true;
                ddlSType2.Items[3].Enabled = true;
                ddlSType2.Items[4].Enabled = true;
                ddlSType2.Items[5].Enabled = true;
            }
            else if (Ftype == "3")
            {
                ddlSType2.Items[6].Enabled = true;
            }
            else if (Ftype == "4")
            {

            }
            else if (Ftype == "5")
            {

            }
            else if (Ftype == "6")
            {

            }
            else if (Ftype == "7")
            {

            }
            else if (Ftype == "8")
            {
                ddlSType2.Items[5].Enabled = true;
            }
            else if (Ftype == "9")
            {
                ddlSType2.Items[1].Enabled = true;
                ddlSType2.Items[2].Enabled = true;
                ddlSType2.Items[3].Enabled = true;
                ddlSType2.Items[4].Enabled = true;
                ddlSType2.Items[5].Enabled = true;
                ddlSType2.Items[6].Enabled = true;

            }
            else if (Ftype == "A")
            {
                ddlSType2.Items[1].Enabled = true;
                ddlSType2.Items[2].Enabled = true;
                ddlSType2.Items[3].Enabled = true;
                ddlSType2.Items[4].Enabled = true;
                ddlSType2.Items[5].Enabled = true;
                ddlSType2.Items[6].Enabled = true;

            }
            else if (Ftype == "B")
            {

            }
            else if (Ftype == "C")
            {

            }
        }

        protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtCode.Text != "")
                {
                    Acc myacc = new Acc();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.FCode = fcode;
                    myacc.Code = fcode + txtCode.Text;
                    if (myacc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetLocalResourceObject("Title").ToString(), GetLocalResourceObject("View").ToString(), GetLocalResourceObject("ViewAccount").ToString() + " " + myacc.Code + " " + myacc.Name1, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        txtName.Text = myacc.Name1;
                        txtName2.Text = myacc.Name2;
                        txtRemark.Text = myacc.Remark;
                        txtodacc.Text = string.Format("{0:N2}", myacc.ODAcc);
                        txtocacc.Text = string.Format("{0:N2}", myacc.OCAcc);
                        txtFcacc.Text = string.Format("{0:N2}", myacc.FCAcc);
                        txtFdacc.Text = string.Format("{0:N2}", myacc.FDAcc);
                        txtDepPer.Text = string.Format("{0:N2}", myacc.DepPer);
                        txtFixPurch.Text = string.Format("{0:N2}", myacc.FixPurch);
                        txtDepAmount.Text = string.Format("{0:N2}", myacc.DepAmount);
                        txtReason.Text = "";

                        ddlSType2.SelectedValue = myacc.Stype1;
                        ddlCoin.SelectedValue = myacc.Coin;
                        ddlCenter.SelectedValue = myacc.BatchCode;

                        ddlDepCode.SelectedValue = myacc.DepCode;
                        if (ddlCost.Visible)
                        {
                            ddlCost.SelectedValue = myacc.ACDep;
                            ddlAcDep.SelectedIndex = 0;
                        }
                        else
                        {
                            ddlAcDep.SelectedValue = myacc.ACDep;
                            ddlCost.SelectedIndex = 0;
                        }
                        txtFixPurDate.Text = myacc.FixPurDate;
                        ChkArea.Checked = (bool)myacc.CheckArea;
                        ChkCostAcc.Checked = (bool)myacc.CheckCostAcc;
                        ChkEmp.Checked = (bool)myacc.CheckEmp;
                        ChkProject.Checked = (bool)myacc.CheckProject;
                        ChkCostCenter.Checked = (bool)myacc.CheckCostCenter;
                        ChkCarNo.Checked = (bool)myacc.CheckCarNo;
                        ddlArea.SelectedValue = myacc.Area;
                        ddlCostCenter.SelectedValue = myacc.CostCenter;
                        ddlProject.SelectedValue = myacc.Project;
                        ddlCostAcc.SelectedValue = myacc.CostAcc;
                        ddlEmpCode.SelectedValue = myacc.EmpCode;
                        ddlCarNo.SelectedValue = myacc.CarNo;
                        if (ChkDepDo.Visible)
                        {                            
                            ChkDepDo.Checked = (myacc.DepDo == "1");
                        }
                        EditMode();


                        AccValue myAccValue = new AccValue();
                        myAccValue.Code = myacc.Code;
                        grdValue.DataSource = myAccValue.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        grdValue.DataBind();
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("AccountNotFound").ToString(); // "الحساب غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "playsound();", true);
                        //System.Media.SystemSounds.Exclamation.Play();
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = GetLocalResourceObject("EnterAccount").ToString();  // "يجب إدخال رقم الحساب";
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

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    txtCode.Text = moh.MakeMask(txtCode.Text, 3);
                    if (txtodacc.Text == "") txtodacc.Text = "0";
                    if (txtocacc.Text == "") txtocacc.Text = "0";
                    if (txtFcacc.Text == "") txtFcacc.Text = "0";
                    if (txtFdacc.Text == "") txtFdacc.Text = "0";
                    if (txtDepPer.Text == "") txtDepPer.Text = "0";
                    if (txtFixPurch.Text == "") txtFixPurch.Text = "0";
                    if (txtDepAmount.Text == "") txtDepAmount.Text = "";

                    Acc myacc = new Acc();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.Code = fcode + txtCode.Text;
                    if (myacc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        myacc.Branch = short.Parse(Session["Branch"].ToString());
                        myacc.FCode = fcode;
                        myacc.Code = fcode + txtCode.Text;
                        myacc.MCode = txtCode.Text;
                        myacc.Name1 = txtName.Text;
                        myacc.Name2 = txtName2.Text;
                        myacc.Remark = txtRemark.Text;
                        myacc.ODAcc = moh.StrToDouble(txtodacc.Text);
                        myacc.OCAcc = moh.StrToDouble(txtocacc.Text);
                        myacc.FCAcc = moh.StrToDouble(txtFcacc.Text);
                        myacc.FDAcc = moh.StrToDouble(txtFdacc.Text);
                        myacc.DepPer = moh.StrToDouble(txtDepPer.Text);
                        myacc.FixPurch = moh.StrToDouble(txtFixPurch.Text);
                        myacc.DepAmount = moh.StrToDouble(txtDepAmount.Text);
                        myacc.DepCode = ddlDepCode.SelectedValue;
                        myacc.ACDep = ddlAcDep.SelectedValue;                      
                        myacc.Stype1 = ddlSType2.SelectedValue;
                        myacc.LastLevel = true;
                        myacc.FLevel = CurLevel;
                        myacc.Coin = ddlCoin.SelectedValue;
                        myacc.BatchCode = ddlCenter.SelectedValue;
                        myacc.FixPurDate = txtFixPurDate.Text;
                        myacc.CheckArea = ChkArea.Checked;
                        myacc.CheckCostAcc = ChkCostAcc.Checked;
                        myacc.CheckEmp = ChkEmp.Checked;
                        myacc.CheckProject = ChkProject.Checked;
                        myacc.CheckCostCenter = ChkCostCenter.Checked;
                        myacc.CheckCarNo = ChkCarNo.Checked;
                        myacc.Area = ddlArea.SelectedValue;
                        myacc.CostCenter = ddlCostCenter.SelectedValue;
                        myacc.Project = ddlProject.SelectedValue;
                        myacc.CostAcc = ddlCostAcc.SelectedValue;
                        myacc.EmpCode = ddlEmpCode.SelectedValue;
                        myacc.CarNo = ddlCarNo.SelectedValue;
                        if (ChkDepDo.Visible) myacc.DepDo = ChkDepDo.Checked ? "1" : "";
                        if (ddlCost.Visible) myacc.ACDep = ddlCost.SelectedValue;                      
                        if (myacc.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            PutCars(myacc, myacc.Code.Substring(4, 5));
                            if (ChkDepDo.Visible && ChkDepDo.Checked) PutTech(myacc, myacc.Code.Substring(4, 5));
                            PutEmp(myacc, myacc.Code.Substring(4, 5));
                            LoadAccData();

                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetLocalResourceObject("Title").ToString(), GetLocalResourceObject("Edit").ToString(), GetLocalResourceObject("EditAccount").ToString() + " " + myacc.Code + " " + myacc.Name1, txtReason.Text, IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            txtReason.Text = "";
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = GetLocalResourceObject("SaveSuccess").ToString(); // "لقد تم حفظ البيانات بنجاح";
                            SetACCCache();
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("ErrorSave").ToString();  // "لقد حدث خطأ اثناء حفظ البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("ErrorSave").ToString(); // "لقد حدث خطأ اثناء حفظ البيانات ... حاول مرة أخرى";
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

        protected void BtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtCode.Text != "")
                {
                    Acc myacc = new Acc();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.FCode = fcode;
                    myacc.Code = fcode + txtCode.Text;
                    if (myacc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        if (myacc.ODAcc != 0 || myacc.OCAcc != 0 || myacc.CAcc != 0 || myacc.DAcc != 0)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("AccountHaveBal").ToString(); // "لا يمكن الغاء الحساب حيث يحتوي الى ارصدة أو حركات";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            Acc1 myAcc1 = new Acc1();
                            myAcc1 = myacc.AccFixReleate(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                            if (myAcc1 != null)
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = GetLocalResourceObject("DeleteReleateAcc").ToString();  // "لا يمكن الغاء الحساب لانه مرتبط بحسابات اخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            }
                            else if (myacc.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetLocalResourceObject("Title").ToString(), GetLocalResourceObject("Delete").ToString(), GetLocalResourceObject("DeleteItem").ToString() + " " + myacc.Code + " " + myacc.Name1, txtReason.Text, IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                txtReason.Text = "";

                                LoadAccData();
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = GetLocalResourceObject("DeleteSuccess").ToString(); // "تم الغاء بيانات الحساب بنجاح";
                                SetACCCache();
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                                BtnClear_Click(sender, e);
                            }
                            else
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = GetLocalResourceObject("DeleteError").ToString();  // "لقد حدث خطأ أثناء الغاء البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            }
                        }
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = GetLocalResourceObject("SelectAccount").ToString(); // "يجب إدخال رقم الحساب";
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

        protected void ddlDepCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (ddlDepCode.SelectedIndex>0)
            //    {
            //        Acc myacc = new Acc();
            //        myacc.Branch = short.Parse(Session["Branch"].ToString());
            //        myacc.Code = ddlDepCode.SelectedValue;
            //        if (myacc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            //        {
            //            txtDepAmount.Text = string.Format("{0:N2}", myacc.ODAcc-myacc.OCAcc-myacc.CAcc+myacc.DAcc);
            //        }
            //        else txtDepAmount.Text = string.Format("{0:N2}", 0);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    LblCodesResult.ForeColor = System.Drawing.Color.Red;
            //    LblCodesResult.Text = ex.Message.ToString();
            //}
        }

        public void SetACCCache()
        {
            Acc myAcc = new Acc();
            myAcc.Branch = short.Parse(Session["Branch"].ToString());
            Cache["LastACC" + Session["CNN2"].ToString()] = myAcc.GetLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            Cache["AllACC" + Session["CNN2"].ToString()] = myAcc.Getall(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
        }


        public void PutCars(Acc myAcc, string s4)
        {
            if (myAcc.FCode == "110101" || myAcc.FCode == "110102" || myAcc.FCode == "110103" || myAcc.FCode == "110104" || myAcc.FCode == "110105" || myAcc.FCode == "110106" || myAcc.FCode == "110107" || myAcc.FCode == "110123" || myAcc.FCode == "110124" || myAcc.FCode == "110127" || myAcc.FCode == "110132" || myAcc.FCode == "110133" || myAcc.FCode == "110137")
            {
                s4 = moh.MakeMask(s4, 5);
                Cars myacc = new Cars();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myacc.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myacc.CarsType = int.Parse(s4.Substring(0,2));
                myacc.Code = s4;
                myacc = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                         where sitm.Code == myacc.Code
                         select sitm).FirstOrDefault();
                if (myacc == null)
                {
                    myacc = new Cars();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.CarsType = int.Parse(s4.Substring(0, 2));
                    myacc.Code = s4;
                    myacc.FixAssetCode = myAcc.Code;
                    myacc.CarType = txtName.Text;
                    myacc.CarType2 = txtName2.Text;
                    myacc.ChDezelKMeter = 0;
                    myacc.ChOilKMeter = 0;
                    myacc.KMeter = 0;
                    myacc.DriverCode = "-1";
                    myacc.FType2 = "-1";
                    myacc.FollowType = -1;
                    myacc.Follow2 = -1;
                    myacc.Status = true;
                    myacc.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }
                else
                {
                    myacc.FixAssetCode = myAcc.Code;
                    myacc.CarType = txtName.Text;
                    myacc.CarType2 = txtName2.Text;
                    myacc.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Acc myacc2 = new Acc();
            myacc2.Branch = short.Parse(Session["Branch"].ToString());
            myacc2.FCode = fcode;
            foreach (Acc itm in myacc2.GetAllAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            {
                string s4 = itm.Code.Substring(4, 5);
                if(itm.FCode.StartsWith("1205"))
                {
                    s4 = moh.MakeMask(s4, 5);
                    SEmp myacc = new SEmp();
                    myacc.EmpCode = int.Parse(s4);
                    myacc = myacc.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc == null)
                    {
                        myacc = new SEmp();
                        myacc.EmpCode = int.Parse(s4);
                        myacc.Name = itm.Name1;
                        myacc.Name2 = itm.Name2;
                        myacc.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    else
                    {
                        myacc.Name = itm.Name1;
                        myacc.Name2 = itm.Name2;
                        myacc.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                }
            }
        }


        public void PutTech(Acc myAcc, string s4)
        {
            s4 = moh.MakeMask(s4, 5);
            Tech myacc = new Tech();
            myacc.Code = int.Parse(s4);
            myacc = myacc.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myacc == null)
            {
              myacc = new Tech();
              myacc.Code = int.Parse(s4);
              myacc.Name = txtName.Text;
              myacc.Name2 = txtName2.Text;
              myacc.Remark = "";
              myacc.MobileNo = "";
              myacc.HourRate = 0;
              myacc.AccountAcc = myAcc.Code;
              myacc.Job = -1;
              myacc.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            }
            else
            {
                myacc.Name = txtName.Text;
                myacc.Name2 = txtName2.Text;
                myacc.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            }
        }

        public void PutEmp(Acc myAcc, string s4)
        {
            if (myAcc.FCode.StartsWith("1205"))
            {
                s4 = moh.MakeMask(s4, 5);
                SEmp myacc = new SEmp();
                myacc.EmpCode = int.Parse(s4);
                myacc = myacc.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myacc == null)
                {
                    myacc = new SEmp();
                    myacc.EmpCode = int.Parse(s4);
                    myacc.Name = txtName.Text;
                    myacc.Name2 = txtName2.Text;
                    myacc.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    Cache.Remove("Emps" + Session["CNN2"].ToString());
                    Cache.Insert("Emps" + Session["CNN2"].ToString(), myacc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                }
                else
                {
                    myacc.Name = txtName.Text;
                    myacc.Name2 = txtName2.Text;
                    myacc.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    Cache.Remove("Emps" + Session["CNN2"].ToString());
                    Cache.Insert("Emps" + Session["CNN2"].ToString(), myacc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                }
            }
        }      

    }
}