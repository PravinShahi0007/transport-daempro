using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Threading;
using System.Globalization;
using System.Configuration;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;

namespace ACC
{
    public partial class WebLShipment : System.Web.UI.Page
    {
        public List<myShip> VouData
        {
            get
            {
                if (ViewState["VouData"] == null)
                {
                    ViewState["VouData"] = new List<myShip>();
                }
                return (List<myShip>)ViewState["VouData"];
            }
            set
            {
                ViewState["VouData"] = value;

            }
        }

        public string Slat
        {
            get
            {
                if (ViewState["Slat"] == null)
                {
                    ViewState["Slat"] = "";
                }
                return ViewState["Slat"].ToString();
            }
            set { ViewState["Slat"] = value; }
        }
        public string Slng
        {
            get
            {
                if (ViewState["Slng"] == null)
                {
                    ViewState["Slng"] = "";
                }
                return ViewState["Slng"].ToString();
            }
            set { ViewState["Slng"] = value; }
        }
        public string Dlat
        {
            get
            {
                if (ViewState["Dlat"] == null)
                {
                    ViewState["Dlat"] = "";
                }
                return ViewState["Dlat"].ToString();
            }
            set { ViewState["Dlat"] = value; }
        }
        public string Dlng
        {
            get
            {
                if (ViewState["Dlng"] == null)
                {
                    ViewState["Dlng"] = "";
                }
                return ViewState["Dlng"].ToString();
            }
            set { ViewState["Dlng"] = value; }
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
        public string Total20
        {
            get
            {
                if (ViewState["Total20"] == null)
                {
                    ViewState["Total20"] = "0.00";
                }
                return ViewState["Total20"].ToString();
            }
            set { ViewState["Total20"] = value; }
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
        public void EditMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = true; // && (Request.QueryString["Support"] != null || (Session[vRoleName] != null && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass205));
            BtnEdit.Visible = true; // && Session[vRoleName] != null && Request.QueryString["Support"] == null && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass202;
            BtnNew.Visible = false;
            BtnDelete.Visible = true;   // && Session[vRoleName] != null && Request.QueryString["Support"] == null && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass203;
            ChkDoubleSide.Visible = BtnPrint.Visible;
            if (Request.QueryString["Flag"] != null)
            {
                if (Request.QueryString["Flag"].ToString() == "0")
                {
                    if ((Session[vRoleName] != null && Request.QueryString["Support"] == null && !(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass40) || Request.QueryString["Support"] != null)
                    {
                        BtnEdit.Visible = false;
                        BtnDelete.Visible = false;
                        BtnClear.Visible = false;
                    }

                }
            }
            if (Request.QueryString["Support"] != null || !(bool)(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass202 || !BtnEdit.Visible) ControlsOnOff(false);

            if (BtnEdit.Visible || BtnDelete.Visible)
            {
                txtReason.Visible = true;
                ValReason.Enabled = true;
                lblReason.Visible = true;
            }
        }

        public void NewMode()
        {
            //txtVouNo.ReadOnly = false;
            //txtVouNo.BackColor = System.Drawing.Color.White;
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = true; // && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass201;
            BtnDelete.Visible = false;
            ChkDoubleSide.Visible = BtnPrint.Visible;

            txtReason.Visible = false;
            ValReason.Enabled = false;
            lblReason.Visible = false;

            //if (!(bool)(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass202 || !BtnEdit.Visible) ControlsOnOff(true);
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
                    this.Page.Header.Title = "أتفاقية شحن بضاعة";

                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = "الرئيسية";
                        UserTran.FormAction = "اختيار";
                        UserTran.Description = "اختيار اتفاقية شحن بضاعة";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

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
                        AreaNo = Session["AreaNo"].ToString();
                        SiteInfo = (CostCenter)Session["SiteInfo"];
                    }
                    if (Request.QueryString["StoreNo"] != null) StoreNo = Request.QueryString["StoreNo"].ToString();
                    else
                    {
                        if (Session["StoreNo"] == null) Session["StoreNo"] = 1;
                        StoreNo = Session["StoreNo"].ToString();
                    }

                    lblBranch.Text = "/L" + short.Parse(AreaNo).ToString();

                    CostCenter myCostCenter = new CostCenter();
                    myCostCenter.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlSite.DataTextField = "Name1";
                    ddlSite.DataValueField = "Code";
                    ddlSite.DataSource = (from sitm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                          orderby sitm.Name1
                                          select sitm).ToList();

                    ddlTo.DataTextField = "Name1";
                    ddlTo.DataValueField = "Code";
                    ddlTo.DataSource = ddlSite.DataSource;


                    Cities myCity = new Cities();
                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlDestination.DataTextField = "Name1";
                    ddlDestination.DataValueField = "Code";
                    ddlPlaceofLoading.DataTextField = "Name1";
                    ddlPlaceofLoading.DataValueField = "Code";
                    ddlDestination.DataSource = (from itm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                                 orderby itm.Name1
                                                 select itm).ToList();
                    ddlPlaceofLoading.DataSource = ddlDestination.DataSource;

                    ddlSite.DataBind();
                    ddlDestination.DataBind();
                    ddlPlaceofLoading.DataBind();
                    ddlTo.DataBind();
                    ddlSite.Items.Insert(0, new ListItem("--- أختار الفرع ---", "-1", true));
                    ddlTo.Items.Insert(0, new ListItem("--- أختار الفرع ---", "-1", true));
                    ddlDestination.Items.Insert(0, new ListItem("--- أختار جهة الترحيل ---", "-1", true));
                    ddlPlaceofLoading.Items.Insert(0, new ListItem("--- أختار مكان الشحن ---", "-1", true));

                    ddlPlaceofLoading.SelectedValue = AreaNo;


                    Acc myacc = new Acc();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastACC" + Session["CNN2"].ToString()] == null) Cache.Insert("LastACC" + Session["CNN2"].ToString(), myacc.GetLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlCustomers.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                               where itm.FCode.StartsWith("120301") 
                                               orderby itm.Name1
                                               select itm).ToList();
                    ddlCustomers.DataTextField = "Name1";
                    ddlCustomers.DataValueField = "Code";
                    ddlCustomers.DataBind();
                    ddlCustomers.Items.Insert(0, new ListItem("--- أختار حساب العميل ---", "-1", true));

                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    vRoleName = moh.GetCurrentRole(AreaNo,(from useritm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                                          where useritm.UserName == Session["CurrentUser"].ToString()
                                                          select useritm).FirstOrDefault());
                    if (Session[vRoleName] == null)
                    {
                        Response.Redirect("WebNotPrev.aspx", false);
                        return;
                    }

                    if (Session[vRoleName] != null && Request.QueryString["Support"] == null)
                    {
                        //BtnNew.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass201;
                        //BtnEdit.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass202;
                        //BtnDelete.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass203;
                        //BtnSearch.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass204;
                        //BtnFind.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass204;
                        //BtnPrint.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass205;
                    }

                    if (Request.QueryString["FNum"] != null)
                    {
                        if (Request.QueryString["Flag"] != null)
                        {
                            if (Request.QueryString["Flag"].ToString() == "0")
                            {
                                if (Session[vRoleName] != null && Request.QueryString["Support"] == null && !(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass40)
                                {
                                    BtnEdit.Visible = false;
                                    BtnDelete.Visible = false;
                                    BtnClear.Visible = false;
                                    ((HtmlGenericControl)this.Master.FindControl("menu")).Visible = false;
                                }
                            }
                            txtSearch.Text = Request.QueryString["FNum"].ToString();
                            BtnSearch_Click(sender, null);
                        }
                        else
                        {
                            txtSearch.Text = Request.QueryString["FNum"].ToString();
                            BtnSearch_Click(sender, null);
                        }
                    }
                    else BtnClear_Click(sender, null);
                }
                else
                {
                    LblCodesResult.Text = "";
                    SaveGridInfo();
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


        public bool ValidateInv()
        {

            if (RdoGType.SelectedIndex != 1)
            {
                if (ddlCoverSize.SelectedValue == "1")
                {
                    if (moh.StrToDouble(txtWeight.Text) > 15)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الوزن لا يتناسب مع مقاس التغليف";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return false;
                    }
                }
                else if (ddlCoverSize.SelectedValue == "2")
                {
                    if (moh.StrToDouble(txtWeight.Text) > 30)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الوزن لا يتناسب مع مقاس التغليف";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return false;
                    }

                }
                else if (ddlCoverSize.SelectedValue == "3")
                {
                    if (moh.StrToDouble(txtWeight.Text) > 100)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الوزن لا يتناسب مع مقاس التغليف";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return false;
                    }
                }
            }
            if (txtName.Text == "")
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يجب أدخال أسم المرسل";
                txtName.Focus();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }

            if (ddlPlaceofLoading.SelectedIndex == 0)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يجب أختيار مكان الشحن";
                ddlPlaceofLoading.Focus();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }

            if (ddlDestination.SelectedIndex == 0)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يجب أختيار جهة الترحيل";
                ddlDestination.Focus();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }

            if (txtCashAmount.Text.Trim() == "") txtCashAmount.Text = "0";
            if (txtSiteAmount.Text.Trim() == "") txtSiteAmount.Text = "0";
            if (txtShabakaAmount.Text.Trim() == "") txtShabakaAmount.Text = "0";
            if (txtCustomerAmount.Text.Trim() == "") txtCustomerAmount.Text = "0";
            if (txtPrice.Text.Trim() == "") txtPrice.Text = "0";
            if (txtQty2.Text.Trim() == "") txtQty2.Text = "1";
            if (txtTotal.Text.Trim() == "") txtTotal.Text = "0";

            if (RdoGType.SelectedIndex == 1)
            {
                SaveGridInfo();
                txtTotal.Text = Total20;

            }

            if (moh.StrToDouble(txtTotNet.Text) > moh.StrToDouble(txtCashAmount.Text) + moh.StrToDouble(txtSiteAmount.Text) + moh.StrToDouble(txtShabakaAmount.Text) + moh.StrToDouble(txtCustomerAmount.Text))
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "السعر لا يغطي أجمالي الفاتورة";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }

            if (moh.StrToDouble(txtTotNet.Text) != moh.StrToDouble(txtCashAmount.Text) + moh.StrToDouble(txtSiteAmount.Text) + moh.StrToDouble(txtShabakaAmount.Text) + moh.StrToDouble(txtCustomerAmount.Text))
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "المدفوع لا يتساوى مع مبلغ الفاتورة";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }

            if (moh.StrToDouble(txtSiteAmount.Text) != 0 && ddlSite.SelectedIndex == 0)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يجب أختيار الفرع";
                ddlSite.Focus();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }

            if (moh.StrToDouble(txtCustomerAmount.Text) != 0 && ddlCustomers.SelectedIndex == 0)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يجب أختيار العميل";
                ddlSite.Focus();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }

            return true;
        }

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    {
                        if (DateTime.Parse(txtGDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            ddlItems_SelectedIndexChanged(sender, e);
                            return;
                        }
                    }

                    BtnNew.Enabled = false;
                    if (!ValidateInv())
                    {
                        BtnNew.Enabled = true;
                        ddlItems_SelectedIndexChanged(sender, e);
                        return;
                    }
                    LShipment myInv = new LShipment();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.VouNo = int.Parse(txtVouNo.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myInv != null)
                    {
                        if (myInv.UserName == txtUserName.ToolTip)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم الفاتورة مكرر";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            BtnNew.Enabled = true;
                            ddlItems_SelectedIndexChanged(sender, e);
                            return;
                        }
                        else
                        {
                            myInv = new LShipment();
                            myInv.Branch = short.Parse(Session["Branch"].ToString());
                            myInv.VouLoc = AreaNo;
                            int? i = myInv.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
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

                    myInv = new LShipment();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.VouNo = int.Parse(txtVouNo.Text);
                    PutInv(myInv);
                    string SiteCode = "-1";
                    if (ddlSite.SelectedIndex > 0)
                    {
                        CostCenter myCenter = new CostCenter();
                        myCenter.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCenter.Code = ddlSite.SelectedValue;
                        myCenter = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                    where citm.Code == myCenter.Code
                                    select citm).FirstOrDefault();
                        if (myCenter != null) SiteCode = myCenter.SiteAcc;
                    }
                    if (myInv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, "410301001", SiteInfo.CashAcc, moh.MadaAcc, SiteInfo.SiteAcc, SiteInfo.Area, "00003", SiteCode, "310102027"))
                    {
                        if (RdoGType.SelectedIndex == 1)
                        {
                            SaveGridInfo();
                            ShipDetails myInv2 = new ShipDetails();
                            foreach (myShip itm in VouData)
                            {
                                myInv2.Branch = short.Parse(Session["Branch"].ToString());
                                myInv2.VouLoc = AreaNo;
                                myInv2.VouNo = int.Parse(txtVouNo.Text);
                                myInv2.FNo = (short)itm.FNo;
                                myInv2.Name = itm.Name;
                                myInv2.Price = itm.Price;
                                myInv2.Qty = itm.Qty;
                                myInv2.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }
                        }

                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";


                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormName = "اتفاقية شحن بضاعة";
                            UserTran.FormAction = "اضافة";
                            UserTran.Description = "اضافة بيانات اتفاقية شحن بضاعة رقم " + lblBranch.Text + "/" + txtVouNo.Text;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }

                        if (this.Txtmail.Text.Trim() != "")
                        {
                            moh.SendEmail(Txtmail.Text, "شكرا لتعاملك مع ناقلات البرية تم اصدار فاتورة الشحن رقم " + lblBranch.Text + "/" + txtVouNo.Text + " للاستفسار اتصل ب920028833 ", "نظام الناقلات البرية", null);  // "نظام الناقلات البرية - أستعادة كلمة المرور"
                        }

                        if (this.Txtrecmail.Text.Trim() != "")
                        {
                            moh.SendEmail(Txtrecmail.Text, "شكرا لتعاملك مع ناقلات البرية تم اصدار فاتورة الشحن رقم " + lblBranch.Text + "/" + txtVouNo.Text + " للاستفسار اتصل ب920028833 ", "نظام الناقلات البرية", null);  // "نظام الناقلات البرية - أستعادة كلمة المرور"
                        }

                        UpdateCache();
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        string vNumber = txtVouNo.Text;
                        BtnClear_Click(sender, e);
                        BtnNew.Enabled = true;
                        PrintMe(vNumber);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        BtnNew.Enabled = true;
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                }
            }
            catch (Exception ex)
            {
                BtnNew.Enabled = true;
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
                        if (DateTime.Parse(txtGDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            ddlItems_SelectedIndexChanged(sender, e);
                            return;
                        }
                    }

                    if (!ValidateInv()) return;
                    LShipment myInv = new LShipment();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.VouNo = int.Parse(txtVouNo.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الفاتورة غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        ddlItems_SelectedIndexChanged(sender, e);
                    }
                    else
                    {
                        ShipDetails myInv2 = new ShipDetails();
                        myInv2.Branch = short.Parse(Session["Branch"].ToString());
                        myInv2.VouLoc = AreaNo;
                        myInv2.VouNo = int.Parse(txtVouNo.Text);
                        myInv2.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        PutInv(myInv);
                        string SiteCode = "-1";
                        if (ddlSite.SelectedIndex > 0)
                        {
                            CostCenter myCenter = new CostCenter();
                            myCenter.Branch = short.Parse(Session["Branch"].ToString());
                            if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                            myCenter.Code = ddlSite.SelectedValue;
                            myCenter = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                        where citm.Code == myCenter.Code
                                        select citm).FirstOrDefault();
                            if (myCenter != null) SiteCode = myCenter.SiteAcc;
                        }
                        if (myInv.Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, "410301001", SiteInfo.CashAcc, moh.MadaAcc, SiteInfo.SiteAcc, SiteInfo.Area, "00003", SiteCode, "310102027"))
                        {
                            if (RdoGType.SelectedIndex == 1)
                            {
                                SaveGridInfo();
                                myInv2 = new ShipDetails();
                                foreach (myShip itm in VouData)
                                {
                                    myInv2.Branch = short.Parse(Session["Branch"].ToString());
                                    myInv2.VouLoc = AreaNo;
                                    myInv2.VouNo = int.Parse(txtVouNo.Text);
                                    myInv2.FNo = (short)itm.FNo;
                                    myInv2.Name = itm.Name;
                                    myInv2.Price = itm.Price;
                                    myInv2.Qty = itm.Qty;
                                    myInv2.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                }
                            }

                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";

                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.FormName = "اتفاقية شحن بضاعة";
                                UserTran.FormAction = "تعديل";
                                UserTran.Description = "تعديل بيانات اتفاقية شحن بضاعة رقم " + lblBranch.Text + "/" + txtVouNo.Text;
                                UserTran.Reason = txtReason.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }
                            txtReason.Text = "";
                            UpdateCache();
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            string vNumber = txtVouNo.Text;
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
                NewMode();
                RdoGType.SelectedIndex = 1;
                RdoGType_SelectedIndexChanged(sender, e);
                ddlItems.SelectedValue = "16";
                ddlItems_SelectedIndexChanged(sender, e);
                lblStatus.Text = "";
                txtVouNo.Text = "";
                txtReason.Text = "";
                txtSearch.Text = "";
                txtGDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                LblTax.Text = moh.doTax(txtGDate.Text, 1);
                txtHDate.Text = HDate.getNow();
                txtName.Text = "";
                txtIDNo.Text = "";
                rdoIDType.SelectedIndex = 0;
                txtIDFrom.Text = "";
                txtIdDate.Text = "";
                txtAddress.Text = "";
                txtMobileNo.Text = "";
                Txtmail.Text = "";
                Txtmail2.Text = "";
                txtQty2.Text = "1";
                txtCustomerAmount.Text = "";
                ddlCustomers.SelectedIndex = 0;
                txtDiscount.Text = "";
                txtDiscountTerm.Text = "";
                txtTax.Text = "";
                txtNet.Text = "";
                txtTotNet.Text = "";
                ChkCashAmount.Checked = false;
                ChkSiteAmount.Checked = false;
                ChkCustomerAmount.Checked = false;
                ChkShabakaAmount.Checked = false;
                Dlat = "";
                Dlng = "";
                Slat = "";
                Slng = "";
                lnkTo.NavigateUrl = "";
                lnkFrom.NavigateUrl = "";
                chkbPlaceFrom.Checked = false;
                chkbPlaceFrom_CheckedChanged(sender, e);
                if (((List<TblRoles>)(Session[vRoleName]))[1].RoleName.Contains("موظفي التشغيل"))
                {
                    ddlPlaceofLoading.SelectedValue = SiteInfo.City;
                    ddlPlaceofLoading.Enabled = false;
                }
                else ddlPlaceofLoading.SelectedIndex = 0;
                ddlDestination.SelectedIndex = 0;
                ddlTo.SelectedIndex = 0;
                txtRecName.Text = "";
                txtRecAddress.Text = "";
                txtRecMobileNo.Text = "";
                Txtrecmail.Text = "";
                Txtrecmail2.Text = "";
                chkbTo.Checked = false;
                chkbTo_CheckedChanged(sender, e);
                ddlType.SelectedIndex = 0;
                ddlUnit.SelectedIndex = 0;
                txtQty.Text = "";
                txtQty2.Text = "";
                txtWeight.Text = "";
                txtPrice.Text = "";
                Total20 = "0";
                ddlUse.SelectedIndex = 0;
                txtShabakaAmount.Text = "";
                txtRemark1.Text = "";
                txtnote.Text = "";
                txtCashAmount.Text = "";
                ddlSite.SelectedIndex = 0;
                ddlDPeriod.SelectedIndex = 0;
                txtSiteAmount.Text = "";
                ddlCoverType.SelectedIndex = 0;
                ddlCoverType_SelectedIndexChanged(sender, e);
                ddlCoverSize.SelectedIndex = 0;
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                LShipment myInv = new LShipment();
                myInv.Branch = short.Parse(Session["Branch"].ToString());
                myInv.VouLoc = AreaNo;
                int? i = myInv.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (i == 0 || i == null)
                {
                    i = 1;
                }
                else
                {
                    i++;
                }
                LblFTime.Text = String.Format("{0:HH:mm:ss}", moh.Nows());  //moh.Nows().ToShortTimeString();
                txtVouNo.Text = i.ToString();
                LoadAttachData();
                VouData.Clear();
                for (int i1 = 1; i1 < 11; i1++)
                {
                    VouData.Add(new myShip
                    {
                        FNo = (short)i1
                    });
                }
                DispVouData();
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
            txtGDate.ReadOnly = !State;
            txtHDate.ReadOnly = !State;
            txtName.ReadOnly = !State;
            txtIDNo.ReadOnly = !State;
            rdoIDType.Enabled = State;
            txtIDFrom.ReadOnly = !State;
            txtIdDate.ReadOnly = !State;
            txtAddress.ReadOnly = !State;
            txtMobileNo.ReadOnly = !State;
            ddlPlaceofLoading.Enabled = State;
            ddlDestination.Enabled = State;
            txtRecName.ReadOnly = !State;
            txtRecAddress.ReadOnly = !State;
            txtRecMobileNo.ReadOnly = !State;
            txtCashAmount.ReadOnly = !State;
            txtCustomerAmount.ReadOnly = !State;
            ddlSite.Enabled = State;
            ddlCustomers.Enabled = State;
            txtSiteAmount.ReadOnly = !State;
            txtRemark1.ReadOnly = !State;
            //grdAttach.Enabled = State;
            foreach (GridViewRow itm in grdAttach.Rows)
            {
                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                if (BtnDelete != null) BtnDelete.Visible = State;
            }
            FileUpload1.Enabled = State;
            BtnAttach.Enabled = State;
            txtReason.ReadOnly = !State;
            this.Txtmail.ReadOnly = !State;
            this.Txtmail2.ReadOnly = !State;
            this.chkbPlaceFrom.Enabled = State;
            this.ddlTo.Enabled = State;
            this.Txtrecmail.ReadOnly = !State;
            this.Txtrecmail2.ReadOnly = !State;
            this.chkbTo.Enabled = State;
            this.ddlType.Enabled = State;
            this.ddlUnit.Enabled = State;
            this.txtQty.ReadOnly = !State;
            this.txtWeight.ReadOnly = !State;
            this.txtPrice.ReadOnly = !State;
            this.ddlUse.Enabled = State;
            this.txtnote.ReadOnly = !State;
            this.ddlCoverType.Enabled = State;
            this.ddlCoverSize.Enabled = State;
            this.txtShabakaAmount.Enabled = State;
            this.ddlDPeriod.Enabled = State;
            btnFrom.Enabled = State;
            btnPlaceTo.Enabled = State;
            txtQty2.Enabled = State;
            this.RdoGType.Enabled = State;
            this.ddlItems.Enabled = State;
            grdCodes.Enabled = State;
        }

        protected void BtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    {
                        if (DateTime.Parse(txtGDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            ddlItems_SelectedIndexChanged(sender, e);
                            return;
                        }
                    }

                    LShipment myInv = new LShipment();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.VouNo = int.Parse(txtVouNo.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الفاتورة غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        ddlItems_SelectedIndexChanged(sender, e);
                    }
                    else
                    {
                        if (myInv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            ShipDetails myInv2 = new ShipDetails();
                            myInv2.Branch = short.Parse(Session["Branch"].ToString());
                            myInv2.VouLoc = AreaNo;
                            myInv2.VouNo = int.Parse(txtVouNo.Text);
                            myInv2.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.Description = "الغاء بيانات فاتورة شحن بضاعة رقم " + txtVouNo.Text;
                                UserTran.FormAction = "الغاء";
                                UserTran.FormName = "اتفاقية شحن بضاعة";
                                UserTran.Reason = txtReason.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }
                            txtReason.Text = "";

                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم الغاء البيانات بنجاح";
                            UpdateCache();
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ أثناء الغاء البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            ddlItems_SelectedIndexChanged(sender, e);
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

                    LShipment myInv = new LShipment();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.VouNo = int.Parse(txtSearch.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الفاتورة غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    else
                    {
                        txtVouNo.Text = myInv.VouNo.ToString();

                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormName = "اتفاقية شحن بضاعة";
                            UserTran.FormAction = "عرض";
                            UserTran.Description = "عرض بيانات اتفاقية شحن بضاعة رقم " + lblBranch.Text + "/" + txtVouNo.Text;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }

                        EditMode();
                        GetInv(myInv);

                        if (RdoGType.SelectedIndex == 1)
                        {
                            VouData.Clear();
                            ShipDetails myInv2 = new ShipDetails();
                            myInv2.Branch = short.Parse(Session["Branch"].ToString());
                            myInv2.VouLoc = AreaNo;
                            myInv2.VouNo = int.Parse(txtVouNo.Text);
                            double tot = 0;
                            foreach (ShipDetails itm in myInv2.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                VouData.Add(new myShip
                                {
                                    FNo = itm.FNo,
                                    Name = itm.Name,
                                    Price = itm.Price,
                                    Qty = itm.Qty,
                                    Total = itm.Price * itm.Qty
                                });
                                tot += (double)(itm.Price * itm.Qty);
                            }
                            Total20 = string.Format("{0:N2}", tot);
                            DispVouData();
                        }

                        lblStatus.Text = "";
                        if (moh.StrToDouble(this.txtSiteAmount.Text) > 0 || moh.StrToDouble(this.txtCustomerAmount.Text) > 0)
                        {
                            Jv myJv = new Jv();
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.FType = 100;
                            myJv.InvNo = "L"+int.Parse(myInv.VouLoc).ToString() + "/" + myInv.VouNo.ToString();
                            myJv = myJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myJv != null)
                            {
                                lblStatus.Text = @"<a href='WebJVou.aspx?AreaNo=" + AreaNo + "&StoreNo=" + Request.QueryString["StoreNo"].ToString() + "&FNum=" + myJv.Number.ToString() + @"' target='_blank'>مدرجه بالقيد رقم " + myJv.Number.ToString();
                            }
                            else
                            {
                                myJv = new Jv();
                                myJv.Branch = short.Parse(Session["Branch"].ToString());
                                myJv.FType = 101;
                                myJv.InvNo = "L"+int.Parse(myInv.VouLoc).ToString() + "/" + myInv.VouNo.ToString();
                                myJv = myJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (myJv != null)
                                {
                                    lblStatus.Text = @"<a href='WebRVou1.aspx?Flag=0&AreaNo=" + moh.MakeMask(myJv.LocNumber.ToString(), 5) + "&StoreNo=" + Request.QueryString["StoreNo"].ToString() + "&FNum=" + myJv.Number.ToString() + @"' target='_blank'>مدرجه بسند القبض رقم " + myJv.Number.ToString();
                                }
                            }
                            if (moh.StrToDouble(this.txtCustomerAmount.Text) > 0)
                            {
                                Claim myClaim = new Claim();
                                myClaim.InvNo = myInv.VouNo;
                                myClaim.InvLoc = short.Parse(myInv.VouLoc);
                                myClaim.Flag = "L";
                                myClaim = myClaim.GetByInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (myClaim != null)
                                {
                                    if (lblStatus.Text != "") lblStatus.Text += @"</br><a href='WebClaim.aspx?AreaNo=" + AreaNo + "&StoreNo=" + Request.QueryString["StoreNo"].ToString() + "&FNum=" + myClaim.DocNo.ToString() + @"' target='_blank'>مدرجه بالمطالبة رقم " + myClaim.DocNo.ToString();
                                    else lblStatus.Text = @"<a href='WebClaim.aspx?AreaNo=" + AreaNo + "&StoreNo=" + Request.QueryString["StoreNo"].ToString() + "&FNum=" + myClaim.DocNo.ToString() + @"' target='_blank'>مدرجه بالمطالبة رقم " + myClaim.DocNo.ToString();
                                }
                            }
                        }

                        // Check if CarMove Exists
                        CarMove myCarMove = new CarMove();
                        myCarMove.Branch = short.Parse(Session["Branch"].ToString());
                        myCarMove.InvoiceNo = int.Parse(txtVouNo.Text);
                        myCarMove.InvoiceVouLoc = AreaNo;
                        myCarMove.Flag = "L";
                        myCarMove = myCarMove.GetByInv2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                        if (myCarMove != null)
                        {
                            if (Request.QueryString["Support"] != null || !(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass206)
                            {
                                BtnEdit.Visible = false;
                                BtnDelete.Visible = false;
                            }
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = Request.QueryString["Support"] != null ? "لا يمكن الغاء او تعديل الفاتورة لانها مرتبطة ببيان الترحيل رقم " + @"<a href='WebCarMove.aspx?Support=1&Flag=0&AreaNo=" + myCarMove.VouLoc + @"&FNum=" + myCarMove.Number.ToString() + @"' target='_blank'>" + int.Parse(myCarMove.VouLoc).ToString() + "/" + myCarMove.Number.ToString() + @"</a>" :
                                                                                            "لا يمكن الغاء او تعديل الفاتورة لانها مرتبطة ببيان الترحيل رقم " + @"<a href='WebCarMove.aspx?Flag=0&AreaNo=" + myCarMove.VouLoc + @"&FNum=" + myCarMove.Number.ToString() + @"' target='_blank'>" + int.Parse(myCarMove.VouLoc).ToString() + "/" + myCarMove.Number.ToString() + @"</a>";
                        }
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم الفاتورة";
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


        public void PrintMe(String Number)
        {
            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
            {
                Transactions UserTran = new Transactions();
                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                UserTran.UserName = Session["CurrentUser"].ToString();
                UserTran.FormName = "اتفاقية شحن بضاعة";
                UserTran.FormAction = "طباعة";
                UserTran.Description = "طباعة بيانات اتفاقية شحن بضاعة رقم " + Number;
                UserTran.IP = IPNetworking.GetIP4Address();
                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=51&AreaNo=" + AreaNo + "&Number=" + Number + "&DoubleSide=" + (ChkDoubleSide.Checked ? "1" : "0") + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
            return;
        }

        public void PrintMe2(String Number)
        {
            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
            {
                Transactions UserTran = new Transactions();
                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                UserTran.UserName = Session["CurrentUser"].ToString();
                UserTran.FormName = "اتفاقية شحن بضاعة";
                UserTran.FormAction = "طباعة";
                UserTran.Description = "طباعة شروط اتفاقية شحن بضاعة رقم " + Number;
                UserTran.IP = IPNetworking.GetIP4Address();
                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=40&AreaNo=" + AreaNo + "&Number=" + Number + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
            return;
        }

        protected void BtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (!ValidateInv()) return;
                    string vNumber = txtVouNo.Text;
                    PrintMe(vNumber);
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
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
            }
        }


        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlUnit.SelectedValue == "1")
            //    txtPrice.Text = (float.Parse(txtWeight.Text) * 70).ToString();
            //else if (ddlUnit.SelectedValue == "2")
            //    txtPrice.Text = (float.Parse(txtWeight.Text) * 100).ToString();
            //else if (ddlUnit.SelectedValue == "3")
            //    txtPrice.Text = (float.Parse(txtWeight.Text) * 200).ToString();
            // txtTotal2.Text = (float.Parse(txtPrice.Text) * float.Parse(txtQty.Text)).ToString();
            ddlPlaceofLoading_SelectedIndexChanged(sender, e);
        }

        protected void txtPrice_TextChanged(object sender, EventArgs e)
        {
            // txtTotal2.Text = (float.Parse(txtPrice.Text) * float.Parse(txtQty.Text)).ToString();
        }

        protected void chkbTo_CheckedChanged(object sender, EventArgs e)
        {
            btnPlaceTo.Visible = chkbTo.Checked;
            lnkTo.Visible = chkbTo.Checked;
            lnkDispTo.Visible = chkbTo.Checked;
        }

        protected void chkbPlaceFrom_CheckedChanged(object sender, EventArgs e)
        {
            btnFrom.Visible = chkbPlaceFrom.Checked;
            lnkFrom.Visible = chkbPlaceFrom.Checked;
            lnkDispFrom.Visible = chkbPlaceFrom.Checked;
        }

        protected void BtnPrint2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    string vNumber = txtVouNo.Text;
                    PrintMe2(vNumber);
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
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
            }
        }

        protected void BtnFind_Click(object sender, ImageClickEventArgs e)
        {
            BtnSearch_Click(sender, e);
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
                        myArch.LocNumber = short.Parse(AreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 500;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(AreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 500;
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
                            UserTran.FormName = "اتفاقية شحن بضاعة";
                            UserTran.FormAction = "اضافة مرفقات";
                            UserTran.Description = "أضافة مرفقات أتفاقية الشحن البضاعة رقم " + lblBranch.Text + "/E" + txtVouNo.Text;
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
                        LblCodesResult.Text = ex.Message.ToString();
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
                myArch.LocNumber = short.Parse(AreaNo);
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = 500;
                myArch.FNo = short.Parse(FNo);
                myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                {
                    Transactions UserTran = new Transactions();
                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                    UserTran.UserName = Session["CurrentUser"].ToString();
                    UserTran.FormName = "اتفاقية شحن بضاعة";
                    UserTran.FormAction = "الغاء مرفقات";
                    UserTran.Description = "الغاء مرفقات أتفاقية الشحن البضاعة رقم " + lblBranch.Text + "/E" + txtVouNo.Text;
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
            try
            {
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(Session["Branch"].ToString());
                myArch.LocNumber = short.Parse(AreaNo);
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = 500;
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

        protected void ddlPlaceofLoading_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDestination.SelectedIndex > 0 && ddlPlaceofLoading.SelectedIndex > 0 && moh.StrToDouble(txtWeight.Text) > 0)
                {
                    CarPrices myPrice = new CarPrices();
                    myPrice.Branch = short.Parse(Session["Branch"].ToString());
                    myPrice.MonthNo = 0;
                    myPrice.FromCode = ddlPlaceofLoading.SelectedValue;
                    myPrice.toCode = ddlDestination.SelectedValue;
                    myPrice.PLevel = "00005";  // 5/13/14/15
                    if (ddlCoverSize.SelectedValue == "1")
                    {
                        myPrice.PLevel = "00014";  // 5/13/14/15
                        if (moh.StrToDouble(txtWeight.Text) > 15)
                        {
                            txtPrice.Text = "0";
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الوزن لا يتناسب مع مقاس التغليف";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                    }
                    else if (ddlCoverSize.SelectedValue == "2")
                    {
                        myPrice.PLevel = "00013";  // 5/13/14/15
                        if (moh.StrToDouble(txtWeight.Text) > 30)
                        {
                            txtPrice.Text = "0";
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الوزن لا يتناسب مع مقاس التغليف";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                    }
                    else if (ddlCoverSize.SelectedValue == "3")
                    {
                        myPrice.PLevel = "00005";  // 5/13/14/15
                        if (moh.StrToDouble(txtWeight.Text) > 100)
                        {
                            txtPrice.Text = "0";
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الوزن لا يتناسب مع مقاس التغليف";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                    }
                    else if (ddlCoverSize.SelectedValue == "4")
                    {
                        myPrice.PLevel = "00015";  // 5/13/14/15
                    }


                    myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myPrice != null && txtPrice != null)
                    {
                        if (ddlCoverSize.SelectedValue == "4") txtPrice.Text = string.Format("{0:N2}", (myPrice.HOneWay * moh.StrToDouble(txtWeight.Text)));
                        else txtPrice.Text = myPrice.HOneWay.ToString();
                    }

                    txtTotal.Text = string.Format("{0:N2}", (moh.StrToDouble(txtQty2.Text) * moh.StrToDouble(txtPrice.Text)));
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

        public void PutInv(LShipment myInv)
        {
            myInv.Branch = short.Parse(Session["Branch"].ToString());
            myInv.VouLoc = AreaNo;
            myInv.VouNo = int.Parse(txtVouNo.Text);
            myInv.FTime = LblFTime.Text;
            myInv.Name = txtName.Text;
            myInv.IDNo = txtIDNo.Text;
            myInv.IDType = short.Parse(rdoIDType.SelectedValue);
            myInv.IDFrom = txtIDFrom.Text;
            myInv.IDDate = txtIdDate.Text;
            myInv.Address = txtAddress.Text;
            myInv.MobileNo = txtMobileNo.Text;
            myInv.Mail = Txtmail.Text;
            myInv.PlaceofLoading = ddlPlaceofLoading.SelectedValue;
            myInv.Destination = ddlDestination.SelectedValue;
            myInv.LocFrom = Slat != "" ? (Slat + @"#" + Slng) : "";
            myInv.LocTo = Dlat != "" ? (Dlat + @"#" + Dlng) : "";
            myInv.RecName = txtRecName.Text;
            myInv.RecAddress = txtRecAddress.Text;
            myInv.RecMobileNo = txtRecMobileNo.Text;
            myInv.CashAmount = moh.StrToDouble(txtCashAmount.Text);
            myInv.RecMail = Txtrecmail.Text;
            myInv.Qty = moh.StrToInt(txtQty.Text);
            myInv.PlaceFrom = chkbPlaceFrom.Checked;
            myInv.Weight = moh.StrToDouble(txtWeight.Text);
            myInv.SiteAmount = moh.StrToDouble(txtSiteAmount.Text);
            myInv.Unit = short.Parse(ddlUnit.SelectedValue);
            myInv.Site = ddlSite.SelectedValue;
            myInv.ShUse = short.Parse(ddlUse.SelectedValue);
            myInv.ShType = short.Parse(ddlType.SelectedValue);
            myInv.ShRemark = txtRemark1.Text;
            myInv.ShNote = txtnote.Text;
            myInv.ShabakaAmount = moh.StrToDouble(txtShabakaAmount.Text);
            myInv.Amount = moh.StrToDouble(txtPrice.Text);
            myInv.DPeriod = short.Parse(ddlDPeriod.SelectedValue);
            myInv.HDate = txtHDate.Text;
            myInv.GDate = txtGDate.Text;
            myInv.VouLoc2 = ddlTo.SelectedValue;
            myInv.CoverType = short.Parse(ddlCoverType.SelectedValue);
            myInv.CoverSize = short.Parse(ddlCoverSize.SelectedValue);
            myInv.bto = chkbTo.Checked;
            myInv.UserName = txtUserName.ToolTip;
            myInv.UserDate = txtUserDate.Text;
            myInv.Qty2 = moh.StrToInt(txtQty2.Text);
            myInv.sitm = short.Parse(ddlItems.SelectedValue);
            myInv.ShipType = short.Parse(RdoGType.SelectedValue);
            myInv.Customer = ddlCustomers.SelectedValue;
            myInv.CustomerAmount = moh.StrToDouble(txtCustomerAmount.Text);
            myInv.DiscountTerm = txtDiscountTerm.Text;
            myInv.Discount = moh.StrToDouble(txtDiscount.Text);
            myInv.Tax = moh.StrToDouble(txtTax.Text);
        }

        public void GetInv(LShipment myInv)
        {
            LblFTime.Text = myInv.FTime;
            txtName.Text = myInv.Name;
            txtIDNo.Text = myInv.IDNo;
            rdoIDType.SelectedValue = myInv.IDType.ToString();
            txtIDFrom.Text = myInv.IDFrom;
            txtIdDate.Text = myInv.IDDate;
            txtAddress.Text = myInv.Address;
            txtMobileNo.Text = myInv.MobileNo;
            Txtmail.Text = myInv.Mail;
            Txtmail2.Text = Txtmail.Text;
            ddlPlaceofLoading.SelectedValue = myInv.PlaceofLoading;
            ddlDestination.SelectedValue = myInv.Destination;
            if (myInv.LocFrom != "")
            {
                Slat = myInv.LocFrom.Split('#')[0];
                Slng = myInv.LocFrom.Split('#')[1];
                lnkFrom.NavigateUrl = @"WebMap.aspx?lat=" + Slat + @"&lng=" + Slng;
                chkbPlaceFrom.Checked = true;
                chkbPlaceFrom_CheckedChanged(null, null);
            }
            else
            {
                Slat = "";
                Slng = "";
                lnkFrom.NavigateUrl = "";
                chkbPlaceFrom.Checked = false;
                chkbPlaceFrom_CheckedChanged(null, null);
            }
            if (myInv.LocTo != "")
            {
                Dlat = myInv.LocTo.Split('#')[0];
                Dlng = myInv.LocTo.Split('#')[1];
                lnkTo.NavigateUrl = @"WebMap.aspx?lat=" + Slat + @"&lng=" + Slng;
                chkbTo.Checked = true;
                chkbTo_CheckedChanged(null, null);
            }
            else
            {
                Dlat = "";
                Dlng = "";
                lnkTo.NavigateUrl = "";
                chkbTo.Checked = false;
                chkbTo_CheckedChanged(null, null);
            }
            txtRecName.Text = myInv.RecName;
            txtRecAddress.Text = myInv.RecAddress;
            txtRecMobileNo.Text = myInv.RecMobileNo;
            txtCashAmount.Text = myInv.CashAmount.ToString();
            Txtrecmail.Text = myInv.RecMail;
            Txtrecmail2.Text = Txtrecmail.Text;
            txtQty.Text = myInv.Qty.ToString();
            txtQty2.Text = myInv.Qty2.ToString();
            chkbPlaceFrom.Checked = (bool)myInv.PlaceFrom;
            txtWeight.Text = myInv.Weight.ToString();
            txtSiteAmount.Text = myInv.SiteAmount.ToString();
            ddlUnit.SelectedValue = myInv.Unit.ToString();
            ddlSite.SelectedValue = myInv.Site;
            ddlUse.SelectedValue = myInv.ShUse.ToString();
            ddlType.SelectedValue = myInv.ShType.ToString();
            txtRemark1.Text = myInv.ShRemark;
            txtnote.Text = myInv.ShNote;
            txtShabakaAmount.Text = myInv.ShabakaAmount.ToString();
            txtPrice.Text = myInv.Amount.ToString();
            ddlDPeriod.SelectedValue = myInv.DPeriod.ToString();
            txtHDate.Text = myInv.HDate;
            txtGDate.Text = myInv.GDate;
            LblTax.Text = moh.doTax(txtGDate.Text, 1);
            myInv.VouLoc2 = ddlTo.SelectedValue;
            ddlCoverType.SelectedValue = myInv.CoverType.ToString();
            ddlCoverSize.SelectedValue = myInv.CoverSize.ToString();
            // myInv.bto = chkbTo.Checked;

            txtUserName.ToolTip = myInv.UserName;
            TblUsers ax = new TblUsers();
            if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            ax.UserName = myInv.UserName;
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
            txtUserDate.Text = myInv.UserDate;
            LoadAttachData();

            ddlItems.SelectedValue = myInv.sitm.ToString();
            ddlItems_SelectedIndexChanged(ddlItems, null);
            RdoGType.SelectedValue = myInv.ShipType.ToString();
            RdoGType_SelectedIndexChanged(RdoGType, null);
            ddlCustomers.SelectedValue = myInv.Customer;
            txtCustomerAmount.Text = myInv.CustomerAmount.ToString();
            if (myInv.ShipType == 1) SaveGridInfo();
            txtDiscountTerm.Text = myInv.DiscountTerm;
            txtDiscount.Text = myInv.Discount.ToString();
            txtTax.Text = myInv.Tax.ToString();
            MakeSum();
        }

        protected void txtWeight_TextChanged(object sender, EventArgs e)
        {
            ddlPlaceofLoading_SelectedIndexChanged(sender, e);
        }

        protected void ddlCoverType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label37.Visible = !(ddlCoverType.SelectedValue == "2");
            ddlCoverSize.Visible = !(ddlCoverType.SelectedValue == "2");
        }

        protected void btnPlaceTo_Click(object sender, EventArgs e)
        {
            HttpCookie UserlatCookie = Request.Cookies["Userlat"];
            HttpCookie UserlngCookie = Request.Cookies["Userlng"];
            if (UserlatCookie != null && UserlngCookie != null)
            {
                Dlat = UserlatCookie.Value;
                Dlng = UserlngCookie.Value;
                lnkTo.NavigateUrl = @"WebMap.aspx?lat=" + UserlatCookie.Value + @"&lng=" + UserlngCookie.Value;
            }
        }

        protected void btnFrom_Click(object sender, EventArgs e)
        {
            HttpCookie UserlatCookie = Request.Cookies["Userlat"];
            HttpCookie UserlngCookie = Request.Cookies["Userlng"];
            if (UserlatCookie != null && UserlngCookie != null)
            {
                Slat = UserlatCookie.Value;
                Slng = UserlngCookie.Value;
                lnkFrom.NavigateUrl = @"WebMap.aspx?lat=" + UserlatCookie.Value + @"&lng=" + UserlngCookie.Value;
            }
        }

        protected void RdoGType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Divsingle.Visible = (RdoGType.SelectedIndex == 0);
            DivMulti.Visible = (RdoGType.SelectedIndex == 1);
        }

        protected void ddlItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveGridInfo();
            if (VouData.Count > ddlItems.SelectedIndex + 1)
            {
                for (int i = VouData.Count; i > (ddlItems.SelectedIndex + 1); i--)
                {
                    VouData.RemoveAt(i - 1);
                }
            }
            else
            {
                for (int i = VouData.Count; i <= ddlItems.SelectedIndex; i++)
                {
                    VouData.Add(new myShip { FNo = (short)(i + 1) });
                }
            }
            DispVouData();
        }

        public void DispVouData()
        {
            grdCodes.DataSource = VouData;
            grdCodes.DataBind();
            if (grdCodes.FooterRow != null)
            {
                Label vlblTotal2 = grdCodes.FooterRow.FindControl("lblTotal2") as Label;
                if (vlblTotal2 != null) vlblTotal2.Text = Total20;
            }
        }

        public void SaveGridInfo()
        {
            VouData.Clear();
            int i = 1;
            double tot = 0;
            foreach (GridViewRow gvr in grdCodes.Rows)
            {
                string FNo = grdCodes.DataKeys[gvr.RowIndex]["FNo"].ToString();
                TextBox vtxtName = gvr.FindControl("txtName") as TextBox;
                TextBox vtxtQty = gvr.FindControl("txtQty") as TextBox;
                TextBox vtxtPrice = gvr.FindControl("txtPrice") as TextBox;
                Label lblTotal = gvr.FindControl("lblTotall") as Label;

                if (FNo != null && vtxtName != null && vtxtQty != null && vtxtPrice != null && lblTotal != null)
                {
                    VouData.Add(new myShip
                    {
                        FNo = (short)i,
                        Name = vtxtName.Text,
                        Qty = moh.StrToInt(vtxtQty.Text),
                        Price = moh.StrToDouble(vtxtPrice.Text),
                        Total = moh.StrToDouble(vtxtPrice.Text) * moh.StrToInt(vtxtQty.Text)
                    });
                    tot += moh.StrToDouble(vtxtPrice.Text) * moh.StrToInt(vtxtQty.Text);
                    lblTotal.Text = string.Format("{0:N2}", moh.StrToDouble(vtxtPrice.Text) * moh.StrToInt(vtxtQty.Text));                   
                }
                i++;
                Total20 = string.Format("{0:N2}", tot);
                txtPrice.Text = Total20;
            }

            if (grdCodes.FooterRow != null)
            {
                Label vlblTotal2 = grdCodes.FooterRow.FindControl("lblTotal2") as Label;
                if (vlblTotal2 != null) vlblTotal2.Text = Total20;
            }
            MakeSum();
        }


        protected void txtPrice_TextChanged1(object sender, EventArgs e)
        {
            SaveGridInfo();
            DispVouData();
        }

        public void UpdateCache()
        {
            try
            {
                if (HttpRuntime.Cache["OverCarMove_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMove_" + AreaNo + Session["CNN2"].ToString());
                if (HttpRuntime.Cache["OverCarMoveTrip_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMoveTrip_" + AreaNo + Session["CNN2"].ToString());
                if (HttpRuntime.Cache["OverCarMoveChart_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMoveChart_" + AreaNo + Session["CNN2"].ToString());

                if (Cache["LMobileNoList" + Session["CNN2"].ToString()] != null) Cache.Remove("LMobileNoList" + Session["CNN2"].ToString());
                if (Cache["LRecMobileNoList" + Session["CNN2"].ToString()] != null) Cache.Remove("LRecMobileNoList" + Session["CNN2"].ToString());
                if (Cache["LIDNoList" + Session["CNN2"].ToString()] != null) Cache.Remove("LIDNoList" + Session["CNN2"].ToString());
                if (Cache["LVouNoList" + Session["CNN2"].ToString()] != null) Cache.Remove("LVouNoList" + Session["CNN2"].ToString());
                if (Cache["LNameList" + Session["CNN2"].ToString()] != null) Cache.Remove("LNameList" + Session["CNN2"].ToString());
                if (Cache["LRecNameList" + Session["CNN2"].ToString()] != null) Cache.Remove("LRecNameList" + Session["CNN2"].ToString());

                DocSerial myInv = new DocSerial();
                Cache.Insert("LMobileNoList" + Session["CNN2"].ToString(), myInv.GetLMobileNoList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                Cache.Insert("LRecMobileNoList" + Session["CNN2"].ToString(), myInv.GetLMobileNoList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                Cache.Insert("LIDNoList" + Session["CNN2"].ToString(), myInv.GetLIDNoList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                Cache.Insert("LVouNoList" + Session["CNN2"].ToString(), myInv.GetLVouNoList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                Cache.Insert("LNameList" + Session["CNN2"].ToString(), myInv.GetLNameList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                Cache.Insert("LRecNameList" + Session["CNN2"].ToString(), myInv.GetLRecNameList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
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

        protected void BtnDiscountTerm_Click(object sender, ImageClickEventArgs e)
        {
            if (txtTotal.Text == "") txtTotal.Text = "0";

            if ((txtDiscountTerm.Text.ToUpper() == "SE20") || (txtDiscountTerm.Text.ToUpper() == "RP020"))
            {
                txtDiscount.Text = (double.Parse(txtTotal.Text) * 0.20).ToString();
            }
            else
            {
                txtDiscount.Text = "0";
            }


            MakeSum();
        }

        public void MakeSum()
        {
            if (grdCodes.FooterRow != null)
            {
                Label txtTotal = grdCodes.FooterRow.FindControl("lblTotal2") as Label;
                if (txtTotal != null) txtTotal.Text = Total20;


                if (txtTotal.Text == "") txtTotal.Text = "0";
                if (txtDiscount.Text == "") txtDiscount.Text = "0";

                txtNet.Text = (moh.StrToDouble(txtTotal.Text) - moh.StrToDouble(txtDiscount.Text)).ToString();
                txtTax.Text = (moh.StrToDouble(txtNet.Text) * moh.doTax(txtGDate.Text)).ToString();                

                txtTotNet.Text = (moh.StrToDouble(txtNet.Text) + moh.StrToDouble(txtTax.Text)).ToString();
            }
        }

        protected void ChkCashAmount_CheckedChanged(object sender, EventArgs e)
        {
            txtCashAmount.Text = (ChkCashAmount.Checked ? txtTotNet.Text : "0");
            if (ChkCashAmount.Checked)
            {
                txtSiteAmount.Text = "0";
                txtCustomerAmount.Text = "0";
                txtShabakaAmount.Text = "0";
                ChkSiteAmount.Checked = false;
                ChkCustomerAmount.Checked = false;
                ChkShabakaAmount.Checked = false;
            }
        }

        protected void ChkSiteAmount_CheckedChanged(object sender, EventArgs e)
        {
            txtSiteAmount.Text = (ChkSiteAmount.Checked ? txtTotNet.Text : "0");
            if (ChkSiteAmount.Checked)
            {
                txtCashAmount.Text = "0";
                txtCustomerAmount.Text = "0";
                txtShabakaAmount.Text = "0";
                ChkCashAmount.Checked = false;
                ChkCustomerAmount.Checked = false;
                ChkShabakaAmount.Checked = false;
            }
        }

        protected void ChkCustomerAmount_CheckedChanged(object sender, EventArgs e)
        {
            txtCustomerAmount.Text = (ChkCustomerAmount.Checked ? txtTotNet.Text : "0");
            if (ChkCustomerAmount.Checked)
            {
                txtCashAmount.Text = "0";
                txtSiteAmount.Text = "0";
                txtShabakaAmount.Text = "0";
                ChkCashAmount.Checked = false;
                ChkSiteAmount.Checked = false;
                ChkShabakaAmount.Checked = false;
            }
        }

        protected void ChkShabakaAmount_CheckedChanged(object sender, EventArgs e)
        {
            txtShabakaAmount.Text = (ChkShabakaAmount.Checked ? txtTotNet.Text : "0");
            if (ChkCustomerAmount.Checked)
            {
                txtCashAmount.Text = "0";
                txtSiteAmount.Text = "0";
                txtCustomerAmount.Text = "0";
                ChkCashAmount.Checked = false;
                ChkSiteAmount.Checked = false;
                ChkCustomerAmount.Checked = false;
            }
        }

        protected void txtGDate_TextChanged(object sender, EventArgs e)
        {
            LblTax.Text = moh.doTax(txtGDate.Text, 1);
        }
    }

    [Serializable]
    public class myShip
    {
        public short? FNo { get; set; }
        public string Name { get; set; }
        public int? Qty { get; set; }
        public double? Price { get; set; }
        public double? Total { get; set; }

        public myShip()
        {
            this.FNo = 0;
            this.Name = "";
            this.Price = 0;
            this.Qty = 0;
            this.Total = 0;
        }
    }
}
