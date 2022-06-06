using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class WebSInv : System.Web.UI.Page
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

        public List<InvOnLineDetails> VouData
        {
            get
            {
                if (ViewState["VouData"] == null)
                {
                    ViewState["VouData"] = new List<InvOnLineDetails>();
                }
                return (List<InvOnLineDetails>)ViewState["VouData"];
            }
            set
            {
                ViewState["VouData"] = value;

            }
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
        public void EditMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = true;   // && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass205;
            BtnEdit.Visible = false; // true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass202;
            BtnNew.Visible = false;
            BtnDelete.Visible = false; // true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass203;
            ChkDoubleSide.Visible = BtnPrint.Visible;
            if (Request.QueryString["Flag"] != null)
            {
                if (Request.QueryString["Flag"].ToString() == "0")
                {
                    if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass40)
                    {
                        BtnEdit.Visible = false;
                        BtnDelete.Visible = false;
                        BtnClear.Visible = false;
                    }
                }
            }
            if (!(bool)(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass202 || !BtnEdit.Visible) ControlsOnOff(false);

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
            BtnNew.Visible = true;  // && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass201;
            BtnDelete.Visible = false;
            ChkDoubleSide.Visible = BtnPrint.Visible;

            txtReason.Visible = false;
            ValReason.Enabled = false;
            lblReason.Visible = false;

            if (!(bool)(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass202 || !BtnEdit.Visible) ControlsOnOff(true);
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
                    this.Page.Header.Title = "أتفاقية شحن - فاتورة";

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
                        UserTran.Description = "اختيار اتفاقية شحن";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    //if (Request.QueryString["AreaNo"] != null)
                    //{
                    //    AreaNo = Request.QueryString["AreaNo"].ToString();
                    //    CostCenter myCost = new CostCenter();
                    //    myCost.Branch = 1;
                    //    myCost.Code = Request.QueryString["AreaNo"].ToString();
                    //    myCost = myCost.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    //    if (myCost != null) SiteInfo = myCost;
                    //}
                    //else
                    //{
                    //    AreaNo = Session["AreaNo"].ToString();
                    //    SiteInfo = (CostCenter)Session["SiteInfo"];
                    //}

                    //lblBranch.Text = "/" + short.Parse(AreaNo).ToString();
                    lblBranch.Text = "";

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

                    CostCenter myCostCenter = new CostCenter();
                    myCostCenter.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlSite.DataTextField = "Name1";
                    ddlSite.DataValueField = "Code";
                    ddlSite.DataSource = (from sitm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                          orderby sitm.Name1
                                          select sitm).ToList();


                    ddlCust.DataTextField = "Name1";
                    ddlCust.DataValueField = "Code";
                    Clients myClient = new Clients();
                    myClient.Branch = short.Parse(Session["Branch"].ToString());
                    ddlCust.DataSource = myClient.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlCust.DataBind();
                    ddlCust.Items.Insert(0, new ListItem("--- أختار العميل ---", "-1", true));

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
                    ddlSite.Items.Insert(0, new ListItem("--- أختار الفرع ---", "-1", true));
                    ddlDestination.Items.Insert(0, new ListItem("--- أختار جهة الترحيل ---", "-1", true));
                    ddlPlaceofLoading.Items.Insert(0, new ListItem("--- أختار مكان الشحن ---", "-1", true));

                    ddlPlaceofLoading.SelectedValue = AreaNo;

                    //vRoleName = moh.GetCurrentRole(AreaNo, Session["CurrentUser"].ToString(), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    vRoleName = "Roll";
                    if (Session[vRoleName] == null)
                    {
                        Response.Redirect("WebNotPrev.aspx", false);
                        return;
                    }
                    BtnNew.Visible = true; // (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass201;
                    BtnEdit.Visible = false; // (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass202;
                    BtnDelete.Visible = false; // (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass203;
                    BtnSearch.Visible = true; // (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass204;
                    BtnFind.Visible = true; // (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass204;
                    BtnPrint.Visible = false;// (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass205;

                    if (Request.QueryString["FNum"] != null)
                    {
                        if (Request.QueryString["Flag"] != null)
                        {
                            if (Request.QueryString["Flag"].ToString() == "0")
                            {
                                if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass40)
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
                        else if (Request.QueryString["FMode"] != null && Request.QueryString["FMode"].ToString() == "99")
                        {
                            InvOnLine myInv = new InvOnLine();
                            myInv.Branch = short.Parse(Session["Branch"].ToString());
                            myInv.VouLoc = "00000";
                            myInv.VouNo = int.Parse(Request.QueryString["FNum"].ToString());
                            myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myInv != null)
                            {
                                BtnClear_Click(sender, null);
                                rdoVouType.SelectedValue = myInv.VouType.ToString();
                                txtHDate.Text = myInv.HDate;
                                txtGDate.Text = moh.CheckDate(myInv.GDate);
                                LblTax.Text = moh.doTax(txtGDate.Text, 1);
                                LblFTime.Text = myInv.FTime;
                                if (myInv.Payment == 0)
                                {
                                    ddlPayment.SelectedValue = myInv.Payment.ToString();
                                    txtCashAmount.Text = myInv.Amount.ToString();   // string.Format("{0:N2}", myInv.CashAmount);

                                }
                                else if (myInv.Payment == 2)
                                {
                                    ddlSite.SelectedValue = myInv.Site2;
                                    txtSiteAmount.Text = myInv.Amount.ToString();   // string.Format("{0:N2}", myInv.SiteAmount);
                                }

                                txtRecName.Text = myInv.RecName;
                                txtRecAddress.Text = myInv.RecAddress;
                                txtRecMobileNo.Text = myInv.RecMobileNo;

                                txtName.Text = myInv.Name;
                                txtAddress.Text = myInv.Address;
                                txtMobileNo.Text = myInv.MobileNo;

                                ddlPlaceofLoading.SelectedValue = myInv.PlaceofLoading;
                                ddlDestination.SelectedValue = myInv.Destination;


                                ddlCustomers.SelectedValue = myInv.Customer;
                                txtCustomerAmount.Text = myInv.CustomerAmount.ToString();   // string.Format("{0:N2}", myInv.CustomerAmount);
                                txtIDNo.Text = myInv.IDNo;
                                rdoIDType.SelectedValue = myInv.IDType.ToString();
                                txtIDFrom.Text = myInv.IDFrom;
                                txtIdDate.Text = myInv.IDDate;
                                txtRemark1.Text = myInv.Remark1;
                                txtAttached.Text = myInv.Attached;
                                ddlQty.SelectedValue = myInv.Qty.ToString();

                                InvOnLineDetails sinv = new InvOnLineDetails();
                                sinv.Branch = short.Parse(Session["Branch"].ToString());
                                sinv.VouLoc = "00000";
                                sinv.VouNo = int.Parse(Request.QueryString["FNum"].ToString());
                                VouData.Clear();
                                VouData = (from itm in sinv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                           select new InvOnLineDetails
                                           {
                                               Branch = itm.Branch,
                                               Brand = itm.Brand,
                                               Color = itm.Color,
                                               //CarMove = "",
                                               CarType = itm.CarType,
                                               ChassisNo = itm.ChassisNo,
                                               FNo = itm.FNo,
                                               Model = itm.Model,
                                               PlateNo = itm.ChassisNo,
                                               Price = itm.Price,
                                               Price2 = itm.Price,
                                               //RcvNo = "",
                                               //RGetDate = "",
                                               //Status = "",
                                               //Transit = false,
                                               VouLoc = AreaNo,
                                               VouNo = int.Parse(txtVouNo.Text)
                                               //VouNo2 = ""
                                           }).ToList();
                                DispVouData();
                                bool State = false;
                                ChkReturnInv.Enabled = State;
                                txtOVouNo.ReadOnly = !State;
                                rdoVouType.Enabled = State;
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
                                //ddlPayment.Enabled = State;
                                ddlDestination.Enabled = State;
                                txtRecName.ReadOnly = !State;
                                txtRecAddress.ReadOnly = !State;
                                txtRecMobileNo.ReadOnly = !State;
                                txtTotal.ReadOnly = !State;
                                //txtCashAmount.ReadOnly = !State;
                                //ddlSite.Enabled = State;
                                //txtSiteAmount.ReadOnly = !State;
                                //ddlCustomers.Enabled = State;
                                //txtCustomerAmount.ReadOnly = !State;
                                //ImgS1.Disabled = !State;
                                //ImgS2.Disabled = !State;
                                //ImgS3.Disabled = !State;
                                //ImgS4.Disabled = !State;
                                //ImgS5.Disabled = !State;
                                //ImgS6.Disabled = !State;
                                //ImgS7.Disabled = !State;
                                //ImgS8.Disabled = !State;
                                //ImgS9.Disabled = !State;
                                //ImgS10.Disabled = !State;
                                //ImgS11.Disabled = !State;
                                //ImgS12.Disabled = !State;
                                //ImgS13.Disabled = !State;
                                //ImgS14.Disabled = !State;
                                //ImgS15.Disabled = !State;
                                //ImgS16.Disabled = !State;
                                //ImgS17.Disabled = !State;
                                //ImgS18.Disabled = !State;
                                //ImgS19.Disabled = !State;
                                //ImgS20.Disabled = !State;
                                //ImgS21.Disabled = !State;
                                //ImgS22.Disabled = !State;
                                //ImgS23.Disabled = !State;
                                //ImgS24.Disabled = !State;
                                //ImgS25.Disabled = !State;
                                //ImgS26.Disabled = !State;
                                //ImgS27.Disabled = !State;
                                //ImgS28.Disabled = !State;
                                //ImgS29.Disabled = !State;
                                //ImgS30.Disabled = !State;
                                //ImgS31.Disabled = !State;
                                //ImgS32.Disabled = !State;
                                //ImgS33.Disabled = !State;
                                //ImgS34.Disabled = !State;
                                //ImgS35.Disabled = !State;
                                //ImgS36.Disabled = !State;
                                //ImgS37.Disabled = !State;
                                //ImgS38.Disabled = !State;
                                //ImgAccess1.Disabled = !State;
                                //ImgAccess2.Disabled = !State;
                                //ImgAccess3.Disabled = !State;
                                //ImgAccess4.Disabled = !State;
                                //ImgAccess5.Disabled = !State;
                                //ImgAccess6.Disabled = !State;
                                //ImgAccess7.Disabled = !State;
                                //ImgAccess8.Disabled = !State;
                                //ImgAccess9.Disabled = !State;
                                //ImgAccess10.Disabled = !State;
                                //ImgAccess11.Disabled = !State;
                                //ImgAccess12.Disabled = !State;
                                //ImgAccess13.Disabled = !State;
                                //ImgAccess14.Disabled = !State;
                                //ImgAccess15.Disabled = !State;
                                //ImgAccess16.Disabled = !State;
                                //ImgAccess17.Disabled = !State;
                                //ImgAccess18.Disabled = !State;
                                //HImgAccess.Value = "111111111111111111";
                                //HImgS.Value = "11111111111111111111111111111111111111";
                                //txtAccess1.ReadOnly = !State;
                                //txtAccess2.ReadOnly = !State;
                                //txtAccess3.ReadOnly = !State;
                                //txtAccess4.ReadOnly = !State;
                                //txtAccess5.ReadOnly = !State;
                                //txtAccess6.ReadOnly = !State;
                                //txtAccess7.ReadOnly = !State;
                                //txtAccess8.ReadOnly = !State;
                                //txtAccess9.ReadOnly = !State;
                                //txtAccess10.ReadOnly = !State;
                                //txtAccess11.ReadOnly = !State;
                                //txtAccess12.ReadOnly = !State;
                                //txtAccess13.ReadOnly = !State;
                                //txtAccess14.ReadOnly = !State;
                                //txtAccess15.ReadOnly = !State;
                                //txtAccess16.ReadOnly = !State;
                                //txtAccess17.ReadOnly = !State;
                                //txtAccess18.ReadOnly = !State;
                                txtRemark1.ReadOnly = !State;
                                //txtRemark2.ReadOnly = !State;
                                txtAttached.ReadOnly = !State;
                                ddlQty.Enabled = State;
                                //grdAttach.Enabled = State;
                                foreach (GridViewRow itm in grdAttach.Rows)
                                {
                                    ImageButton BtnDelete0 = itm.FindControl("btnDelete") as ImageButton;
                                    if (BtnDelete0 != null) BtnDelete0.Visible = State;
                                }
                                grdCodes.Enabled = State;
                                FileUpload1.Enabled = State;
                                BtnAttach.Enabled = State;

                            }
                        }
                        else
                        {
                            txtSearch.Text = Request.QueryString["FNum"].ToString();
                            BtnSearch_Click(sender, null);
                        }
                    }
                    else BtnClear_Click(sender, null);
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
                ddlPayment.SelectedIndex = 0;
                txtVouNo.Text = "";
                txtReason.Text = "";
                txtSearch.Text = "";
                ddlCust.SelectedIndex = 0;
                ChkCust.Checked = false;
                ChkCust_CheckedChanged(sender, e);
                ChkReturnInv.Checked = false;
                ChkReturnInv_CheckedChanged(sender, e);
                txtOVouNo.Text = "";
                rdoVouType.SelectedIndex = 0;
                txtGDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                LblTax.Text = moh.doTax(txtGDate.Text, 1);
                txtHDate.Text = HDate.getNow();
                txtName.Text = "";
                txtIDNo.Text = "";
                rdoIDType.SelectedIndex = 0;
                txtIDFrom.Text = "";
                txtMail.Text = "";
                txtRecMail.Text = "";
                txtIdDate.Text = "";
                txtAddress.Text = "";
                txtMobileNo.Text = "";
                ddlPlaceofLoading.SelectedIndex = 0;
                ddlDestination.SelectedIndex = 0;
                txtRecName.Text = "";
                txtRecAddress.Text = "";
                txtRecMobileNo.Text = "";
                txtTotal.Text = "";
                txtCashAmount.Text = "";
                ddlSite.SelectedIndex = 0;
                txtSiteAmount.Text = "";
                ddlCustomers.SelectedIndex = 0;
                txtDiscount.Text = "0";
                txtDiscountTerm.Text = "";
                txtCustomerAmount.Text = "";
                HImgAccess.Value = "111111111111111111";
                HImgS.Value = "11111111111111111111111111111111111111";
                txtRemark1.Text = "";
                txtAttached.Text = "";
                txtTax.Text = "";
                txtTotNet.Text = "";
                ddlQty.SelectedIndex = 0;
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));

                Dlat = "";
                Dlng = "";
                Slat = "";
                Slng = "";
                chkbPlaceFrom.Checked = false;
                chkbPlaceFrom_CheckedChanged(sender, e);
                chkbTo.Checked = false;
                chkbTo_CheckedChanged(sender, e);

                rdoShipType2.Items[1].Selected = false;
                rdoShipType2.Items[0].Selected = true;
                rdoShipType2_SelectedIndexChanged(sender, e);
                lnkDispTo.NavigateUrl = @"WebGetMap.aspx";

                InvOnLine myInv = new InvOnLine();
                myInv.Branch = short.Parse(Session["Branch"].ToString());
                myInv.VouLoc = AreaNo;
                int? i = myInv.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (i == 0 || i == null)
                {
                    i = SiteInfo.InvNo;
                }
                else
                {
                    i++;
                }
                LblFTime.Text = String.Format("{0:HH:mm:ss}", moh.Nows());  //moh.Nows().ToShortTimeString();
                txtVouNo.Text = i.ToString();
                LoadAttachData();
                VouData.Clear();
                VouData.Add(new InvOnLineDetails { FNo = 1 });
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
            ChkReturnInv.Enabled = State;
            txtOVouNo.ReadOnly = !State;
            rdoVouType.Enabled = State;
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
            ddlPayment.Enabled = State;
            ddlDestination.Enabled = State;
            txtRecName.ReadOnly = !State;
            txtRecAddress.ReadOnly = !State;
            txtRecMobileNo.ReadOnly = !State;
            txtTotal.ReadOnly = !State;
            txtCashAmount.ReadOnly = !State;
            ddlSite.Enabled = State;
            txtSiteAmount.ReadOnly = !State;
            ddlCustomers.Enabled = State;
            txtCustomerAmount.ReadOnly = !State;
            txtRemark1.ReadOnly = !State;
            txtAttached.ReadOnly = !State;
            txtMail.ReadOnly = !State;
            txtRecMail.ReadOnly = !State;
            ddlQty.Enabled = State;
            chkbPlaceFrom.Enabled = State;
            rdoShipType2.Enabled = State;
            ddlShipType2.Enabled = State;
            chkbTo.Enabled = State;
            //grdAttach.Enabled = State;
            foreach (GridViewRow itm in grdAttach.Rows)
            {
                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                if (BtnDelete != null) BtnDelete.Visible = State;
            }
            grdCodes.Enabled = State;
            FileUpload1.Enabled = State;
            BtnAttach.Enabled = State;
            txtReason.ReadOnly = !State;
            txtDiscountTerm.ReadOnly = !State;
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
                            return;
                        }
                    }

                    BtnNew.Enabled = false;
                    if (!ValidateInv())
                    {
                        BtnNew.Enabled = true;
                        return;
                    }
                    InvOnLine myInv = new InvOnLine();
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
                            return;
                        }
                        else
                        {
                            myInv = new InvOnLine();
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

                    myInv = new InvOnLine();
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
                    if (myInv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        SaveGridInfo();
                        foreach (InvOnLineDetails inv in VouData)
                        {
                            inv.Branch = short.Parse(Session["Branch"].ToString());
                            inv.VouLoc = AreaNo;
                            inv.VouNo = int.Parse(txtVouNo.Text);
                            inv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }


                        if (myInv.DiscountTerm != "")
                        {
                            Promo myPromo = new Promo();
                            myPromo.UserName = myInv.UserName;
                            myPromo.VouNo = myInv.VouNo;
                            myPromo.VouLoc = myInv.VouLoc;
                            myPromo.PromoCode = myInv.DiscountTerm;
                            myPromo.GDateTime = myInv.GDate + " " + myInv.FTime;
                            myPromo.OrderType = 1;
                            myPromo.Discount = myInv.Discount;
                            myPromo.Amount = myInv.Amount;
                            myPromo.DeviceType = 2;
                            myPromo.Add(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString);
                        }

                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تمت أضافة الفاتورة رقم " + txtVouNo.Text + " بنجاح";

                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormName = "اتفاقية شحن";
                            UserTran.FormAction = "اضافة";
                            UserTran.Description = "اضافة بيانات اتفاقية الشحن رقم " + txtVouNo.Text;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }

                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, true), true);
                        string vNumber = txtVouNo.Text;
                        BtnClear_Click(sender, e);
                        BtnNew.Enabled = true;
                        //PrintMe(vNumber);
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

        public bool ValidateInv()
        {
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

            if (ddlSite.SelectedIndex == 0)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يجب أختيار فرع الشحن";
                ddlSite.Focus();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }

            if (chkbPlaceFrom.Checked && (Slat == "" || Slng == ""))
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يجب تحديد موقع الاستلام من المرسل بالخريطة مع حفظ الموقع";
                ddlSite.Focus();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }

            if (chkbTo.Checked && (Dlat == "" || Dlng == ""))
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يجب تحديد موقع التسليم إلى المرسل الية بالخريطة مع حفظ الموقع";
                ddlSite.Focus();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }


            if (txtCashAmount.Text.Trim() == "") txtCashAmount.Text = "0";
            if (txtSiteAmount.Text.Trim() == "") txtSiteAmount.Text = "0";
            if (txtTax.Text.Trim() == "") txtTax.Text = "0";
            if (txtCustomerAmount.Text.Trim() == "") txtCustomerAmount.Text = "0";
            if (txtDiscount.Text.Trim() == "") txtDiscount.Text = "0";

            MakeSum();

            if (moh.StrToDouble(txtTotNet.Text) > moh.StrToDouble(txtCashAmount.Text) + moh.StrToDouble(txtSiteAmount.Text) + moh.StrToDouble(txtCustomerAmount.Text))
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "السعر لا يغطي أجمالي الفاتورة";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }

            if (moh.StrToDouble(txtTotNet.Text) != moh.StrToDouble(txtCashAmount.Text) + moh.StrToDouble(txtSiteAmount.Text) + moh.StrToDouble(txtCustomerAmount.Text))
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "المدفوع لا يتساوى مع مبلغ الفاتورة";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }

            foreach (GridViewRow gvr in grdCodes.Rows)
            {
                DropDownList ddlCarType = gvr.FindControl("ddlCarType") as DropDownList;
                TextBox txtPlateNo = gvr.FindControl("txtPlateNo") as TextBox;
                TextBox txtChassisNo = gvr.FindControl("txtChassisNo") as TextBox;

                if (ddlCarType != null && txtPlateNo != null && txtChassisNo != null)
                {
                    if (ddlCarType.SelectedIndex == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أختيار نوع السيارة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return false;
                    }

                    if (txtPlateNo.Text == "" && txtChassisNo.Text == "")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أدخال رقم اللوحة أو الهيكل للسيارة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return false;
                    }
                }
            }

            if (moh.StrToDouble(txtCustomerAmount.Text) != 0 && ddlCustomers.SelectedIndex == 0)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يجب أختيار العميل";
                ddlCustomers.Focus();
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

            return true;
        }

        public void PutInv(InvOnLine myInv)
        {
            myInv.Payment = short.Parse(ddlPayment.SelectedValue);
            myInv.VouType = short.Parse(rdoVouType.SelectedValue);
            myInv.HDate = txtHDate.Text;
            myInv.GDate = moh.CheckDate(txtGDate.Text);
            myInv.Name = txtName.Text;
            myInv.IDNo = txtIDNo.Text;
            myInv.IDType = short.Parse(rdoIDType.SelectedValue);
            myInv.IDFrom = txtIDFrom.Text;
            myInv.IDDate = txtIdDate.Text;
            myInv.Address = txtAddress.Text;
            myInv.MobileNo = txtMobileNo.Text;
            myInv.PlaceofLoading = ddlPlaceofLoading.SelectedValue;
            myInv.Destination = ddlDestination.SelectedValue;
            myInv.RecName = txtRecName.Text;
            myInv.RecAddress = txtRecAddress.Text;
            myInv.RecMobileNo = txtRecMobileNo.Text;
            myInv.FTime = LblFTime.Text;
            // myInv.ReturnInv = ChkReturnInv.Checked;
            // myInv.OVouNo = txtOVouNo.Text;
            myInv.Mail = txtMail.Text;
            myInv.RecMail = txtRecMail.Text;
            SaveGridInfo();

            myInv.CashAmount = moh.StrToDouble(txtCashAmount.Text);
            myInv.Amount = moh.StrToDouble(txtTotal.Text);
            // myInv.RecVouNo = 0;  // int.Parse(txtRecVouNo.Text);
            // myInv.RecVouDate = ""; // txtRecVouDate.Text;
            myInv.Site = ddlSite.SelectedValue;
            myInv.SiteAmount = moh.StrToDouble(txtSiteAmount.Text);
            myInv.Customer = ddlCustomers.SelectedValue;
            myInv.CustomerAmount = moh.StrToDouble(txtCustomerAmount.Text);
            myInv.Remark1 = txtRemark1.Text;
            // myInv.Remark2 = txtRemark2.Text;
            myInv.Attached = txtAttached.Text;
            myInv.UserName = txtUserName.ToolTip;
            myInv.UserDate = txtUserDate.Text;
            myInv.Qty = short.Parse(ddlQty.SelectedValue);
            myInv.SLat = Slat;
            myInv.SLng = Slng;
            myInv.RLat = Dlat;
            myInv.RLng = Dlng;
            myInv.DiscountTerm = txtDiscountTerm.Text;
            myInv.Discount = moh.StrToDouble(txtDiscount.Text);
            myInv.ShipType2 = short.Parse(rdoShipType2.SelectedValue);
            myInv.Tax = moh.StrToDouble(txtTax.Text);
            if (rdoShipType2.Items[0].Selected) myInv.ShipType2 = 0;
            else myInv.ShipType2 = short.Parse(ddlShipType2.SelectedValue);            
        }

        public void GetInv(InvOnLine myInv, Boolean ReturnFlag)
        {
            if (!ReturnFlag) rdoVouType.SelectedValue = myInv.VouType.ToString();
            txtHDate.Text = myInv.HDate;
            txtGDate.Text = myInv.GDate;
            LblTax.Text = moh.doTax(txtGDate.Text, 1);
            LblFTime.Text = myInv.FTime;

            ddlPayment.SelectedValue = myInv.Payment.ToString();
            if (ReturnFlag)
            {
                txtName.Text = myInv.RecName;
                txtAddress.Text = myInv.RecAddress;
                txtMobileNo.Text = myInv.RecMobileNo;

                txtRecName.Text = myInv.Name;
                txtRecAddress.Text = myInv.Address;
                txtRecMobileNo.Text = myInv.MobileNo;

                ddlPlaceofLoading.SelectedValue = myInv.Destination;
                ddlDestination.SelectedValue = myInv.PlaceofLoading;

                txtCashAmount.Text = "0";
                //txtRecVouNo.Text = myInv.RecVouNo.ToString();
                //txtRecVouDate.Text = myInv.RecVouDate;
                ddlSite.SelectedValue = "-1";
                txtSiteAmount.Text = "0";
                ddlCustomers.SelectedValue = "-1";
                txtCustomerAmount.Text = "0";
            }
            else
            {
                // ChkReturnInv.Checked = (bool)myInv.ReturnInv;
                // ChkReturnInv_CheckedChanged(ChkReturnInv, null);
                // txtOVouNo.Text = myInv.OVouNo;

                txtRecName.Text = myInv.RecName;
                txtRecAddress.Text = myInv.RecAddress;
                txtRecMobileNo.Text = myInv.RecMobileNo;

                txtName.Text = myInv.Name;
                txtAddress.Text = myInv.Address;
                txtMobileNo.Text = myInv.MobileNo;

                ddlPlaceofLoading.SelectedValue = myInv.PlaceofLoading;
                ddlDestination.SelectedValue = myInv.Destination;

                txtCashAmount.Text = myInv.CashAmount.ToString();   // string.Format("{0:N2}", myInv.CashAmount);
                //txtRecVouNo.Text = myInv.RecVouNo.ToString();
                //txtRecVouDate.Text = myInv.RecVouDate;
                ddlSite.SelectedValue = myInv.Site;
                txtSiteAmount.Text = myInv.SiteAmount.ToString();   // string.Format("{0:N2}", myInv.SiteAmount);
                ddlCustomers.SelectedValue = myInv.Customer;
                txtCustomerAmount.Text = myInv.CustomerAmount.ToString();   // string.Format("{0:N2}", myInv.CustomerAmount);
            }
            txtIDNo.Text = myInv.IDNo;
            rdoIDType.SelectedValue = myInv.IDType.ToString();
            txtIDFrom.Text = myInv.IDFrom;
            txtIdDate.Text = myInv.IDDate;
            txtRemark1.Text = myInv.Remark1;
            txtMail.Text = myInv.Mail;
            txtRecMail.Text = myInv.RecMail;
            
            txtAttached.Text = myInv.Attached;
            ddlQty.SelectedValue = myInv.Qty.ToString();
            if (!ReturnFlag)
            {
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
            }

            if (myInv.SLat != "" && myInv.SLng != "")
            {
                Slat = myInv.SLat;
                Slng = myInv.SLng;
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

            if (myInv.RLat != "" && myInv.RLng != "")
            {
                Dlat = myInv.RLat;
                Dlng = myInv.RLng;
                lnkTo.NavigateUrl = @"WebMap.aspx?lat=" + Dlat + @"&lng=" + Dlng;
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
            txtTotal.Text = myInv.Amount.ToString();
            txtDiscountTerm.Text = myInv.DiscountTerm;
            txtDiscount.Text = myInv.Discount.ToString();

            if (myInv.ShipType2 == 0)
            {
                rdoShipType2.Items[0].Selected = true;
                rdoShipType2_SelectedIndexChanged(null, null);
            }
            else
            {
                rdoShipType2.Items[1].Selected = true;
                rdoShipType2_SelectedIndexChanged(null, null);
                ddlShipType2.SelectedValue = myInv.ShipType2.ToString();
                //ddlShipType2_SelectedIndexChanged(null, null);
            }




            /*
            string vStr = "";
            string vStr2 = "";
            ContentPlaceHolder myContent = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
            for (int i = 1; i < 19; i++)
            {
                HtmlImage ImgAccess = myContent.FindControl("ImgAccess" + i.ToString()) as HtmlImage;
                vStr += (ImgAccess.Src.Contains("True") ? "1" : "0");
            }
            for (int i = 1; i < 38; i++)
            {
                HtmlImage ImgS = myContent.FindControl("ImgS" + i.ToString()) as HtmlImage;
                vStr2 += (ImgS.Src.Contains("True") ? "1" : "0");
            }
            HImgAccess.Value = vStr;
            HImgS.Value = vStr2;
             */
            if (!ReturnFlag) LoadAttachData();
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
                            return;
                        }
                    }

                    if (!ValidateInv()) return;
                    InvOnLine myInv = new InvOnLine();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.VouNo = int.Parse(txtVouNo.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الفاتورة غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    else
                    {
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
                        if (myInv.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            InvOnLineDetails sinv = new InvOnLineDetails();
                            sinv.Branch = short.Parse(Session["Branch"].ToString());
                            sinv.VouLoc = AreaNo;
                            sinv.VouNo = int.Parse(txtVouNo.Text);
                            sinv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            SaveGridInfo();
                            foreach (InvOnLineDetails inv in VouData)
                            {
                                inv.Branch = short.Parse(Session["Branch"].ToString());
                                inv.VouLoc = AreaNo;
                                inv.VouNo = int.Parse(txtVouNo.Text);
                                inv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }


                            if (myInv.DiscountTerm != "")
                            {
                                bool vFound = false;
                                Promo myPromo = new Promo();
                                myPromo.OrderType = 1;
                                myPromo.VouNo = myInv.VouNo;
                                myPromo.VouLoc = myInv.VouLoc;
                                myPromo = myPromo.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (myPromo != null)
                                {
                                    if (myPromo.PromoCode != myInv.DiscountTerm) vFound = true;
                                }
                                else vFound = true;

                                if(vFound)
                                {
                                    myPromo = new Promo();
                                    myPromo.OrderType = 1;
                                    myPromo.VouNo = myInv.VouNo;
                                    myPromo.VouLoc = myInv.VouLoc;
                                    myPromo.UserName = myInv.UserName;
                                    myPromo.PromoCode = myInv.DiscountTerm;
                                    myPromo.GDateTime = myInv.GDate + " " + myInv.FTime;
                                    myPromo.Discount = myInv.Discount;
                                    myPromo.Amount = myInv.Amount;
                                    myPromo.DeviceType = 2;
                                    myPromo.Add(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString);
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
                                UserTran.FormName = "اتفاقية شحن";
                                UserTran.FormAction = "تعديل";
                                UserTran.Description = "تعديل بيانات اتفاقية شحن رقم " + txtVouNo.Text;
                                UserTran.Reason = txtReason.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }
                            txtReason.Text = "";

                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            string vNumber = txtVouNo.Text;
                            BtnClear_Click(sender, e);
                            //PrintMe(vNumber);
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
                            return;
                        }
                    }

                    InvOnLine myInv = new InvOnLine();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.VouNo = int.Parse(txtVouNo.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الفاتورة غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    else
                    {
                        if (myInv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            InvDetails sinv = new InvDetails();
                            sinv.Branch = short.Parse(Session["Branch"].ToString());
                            sinv.VouLoc = AreaNo;
                            sinv.VouNo = int.Parse(txtVouNo.Text);
                            sinv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.Description = "الغاء بيانات فاتورة الشحن رقم " + txtVouNo.Text;
                                UserTran.FormAction = "الغاء";
                                UserTran.FormName = "اتفاقية الشحن";
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Reason = txtReason.Text;
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

                    InvOnLine myInv = new InvOnLine();
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
                            UserTran.FormName = "اتفاقية شحن";
                            UserTran.FormAction = "عرض";
                            UserTran.Description = "عرض بيانات اتفاقية الشحن رقم " + txtVouNo.Text;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }

                        EditMode();
                        GetInv(myInv, false);
                        InvOnLineDetails sinv = new InvOnLineDetails();
                        sinv.Branch = short.Parse(Session["Branch"].ToString());
                        sinv.VouLoc = AreaNo;
                        sinv.VouNo = int.Parse(txtVouNo.Text);
                        VouData.Clear();
                        VouData = sinv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        foreach (InvOnLineDetails itm in VouData)
                        {
                            itm.Price2 = itm.Price - (rdoShipType2.Items[0].Selected ? (chkbPlaceFrom.Checked ? 50 : 0) - (chkbTo.Checked ? 50 : 0) : 0);
                        }


                        DispVouData();

                        // Check if CarMove Exists
                        /*
                        CarMove myCarMove = new CarMove();
                        myCarMove.Branch = short.Parse(Session["Branch"].ToString());
                        myCarMove.InvoiceNo = int.Parse(txtVouNo.Text);
                        myCarMove.InvoiceVouLoc = AreaNo;
                        myCarMove = myCarMove.GetByInv2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                        if (myCarMove != null)
                        {
                            if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass206)
                            {
                                BtnEdit.Visible = false;
                                BtnDelete.Visible = false;
                            }
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لا يمكن الغاء او تعديل الفاتورة لانها مرتبطة ببيان الترحيل رقم " + @"<a href='WebCarMove.aspx?Flag=0&AreaNo=" + myCarMove.VouLoc + @"&FNum=" + myCarMove.Number.ToString() + @"' target='_blank'>" + int.Parse(myCarMove.VouLoc).ToString() + "/" + myCarMove.Number.ToString() + @"</a>";
                        }
                         */
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

        protected void BtnFind_Click(object sender, ImageClickEventArgs e)
        {
            BtnSearch_Click(sender, e);
        }

        public void PrintMe(String Number)
        {
            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
            {
                Transactions UserTran = new Transactions();
                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                UserTran.UserName = Session["CurrentUser"].ToString();
                UserTran.FormName = "اتفاقية شحن";
                UserTran.FormAction = "طباعة";
                UserTran.Description = "طباعة بيانات اتفاقية الشحن رقم " + Number;
                UserTran.IP = IPNetworking.GetIP4Address();
                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
            }

            if (Request.QueryString["FMode"] != null && Request.QueryString["FMode"].ToString() == "99")
            {
                // Post eInvoice
                InvOnLine eInv = new InvOnLine();
                eInv.Branch = short.Parse(Session["Branch"].ToString());
                eInv.VouLoc = "00019";
                eInv.VouNo = int.Parse(Request.QueryString["FNum"].ToString());
                eInv = eInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                string myNumber = "";
                if (eInv != null)
                {
                    string vStr6 = eInv.GDate;
                    string vStr5 = "00000";
                    string vStr3 = Request.QueryString["FNum"].ToString();
                    string vStr = moh.MakeMask(DateTime.Parse(vStr6).Month.ToString(), 2) + moh.MakeMask(DateTime.Parse(vStr6).Day.ToString(), 2) + "" + vStr3 + "" + (100 + int.Parse(vStr5)).ToString();
                    int r = 0;
                    for (int i = 0; i < vStr.Length; i++)
                    {
                        r += int.Parse(vStr[i].ToString());
                    }
                    myNumber = moh.MakeMask(r.ToString(), 2) + vStr;
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=555&OnLine=" + myNumber + @"1&AreaNo=" + AreaNo + "&Number=" + Number + "&DoubleSide=" + (ChkDoubleSide.Checked ? "1" : "0") + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
            }
            else ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=555&AreaNo=" + AreaNo + "&Number=" + Number + "&DoubleSide=" + (ChkDoubleSide.Checked ? "1" : "0") + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
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
                UserTran.FormName = "اتفاقية شحن";
                UserTran.FormAction = "طباعة";
                UserTran.Description = "طباعة شروط اتفاقية الشحن رقم " + Number;
                UserTran.IP = IPNetworking.GetIP4Address();
                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=4&AreaNo=" + AreaNo + "&Number=" + Number + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
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

        protected void ddlPlaceofLoading_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDestination.SelectedIndex > 0 && ddlPlaceofLoading.SelectedIndex > 0 && !ChkReturnInv.Checked)
                {
                    foreach (GridViewRow gvr in grdCodes.Rows)
                    {
                        DropDownList ddlModel = gvr.FindControl("ddlModel") as DropDownList;
                        if (ddlModel != null)
                        {
                            ddlModel_SelectedIndexChanged(ddlModel, e);
                        }
                    }
                    MakeSum();
                    lnkDispTo.NavigateUrl = @"WebGetMap.aspx?myCity=" + ddlDestination.SelectedItem.Text;
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

        public void DispVouData()
        {
            try
            {
                grdCodes.DataSource = VouData;
                grdCodes.DataBind();
                int i = 1;
                foreach (GridViewRow gvr in grdCodes.Rows)
                {
                    DropDownList ddlCarType = gvr.FindControl("ddlCarType") as DropDownList;
                    DropDownList ddlModel = gvr.FindControl("ddlModel") as DropDownList;
                    TextBox txtBrand = gvr.FindControl("txtBrand") as TextBox;
                    TextBox txtPlateNo = gvr.FindControl("txtPlateNo") as TextBox;
                    TextBox txtChassisNo = gvr.FindControl("txtChassisNo") as TextBox;
                    TextBox txtColor = gvr.FindControl("txtColor") as TextBox;
                    TextBox txtPrice = gvr.FindControl("txtPrice") as TextBox;
                    HiddenField txtPrice2 = gvr.FindControl("txtPrice2") as HiddenField;
                    string FNo = grdCodes.DataKeys[gvr.RowIndex]["FNo"].ToString();
                    CustomValidator ValAmount2 = gvr.FindControl("ValAmount2") as CustomValidator;

                    if (ddlCarType != null && ddlModel != null && txtBrand != null && txtPlateNo != null && txtChassisNo != null && txtColor != null && txtPrice != null && FNo != null && txtPrice2 != null && ValAmount2 != null)
                    {

                        CarType myCarType = new CarType();
                        myCarType.cnn = WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString;
                        myCarType.Branch = short.Parse(Session["Branch"].ToString());
                        myCarType.FCode = "";
                        ddlCarType.DataTextField = "Name1";
                        ddlCarType.DataValueField = "Code";
                        ddlCarType.DataSource = myCarType.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        ddlCarType.DataBind();
                        ddlCarType.Items.Insert(0, new ListItem("[" + i.ToString() + "]", "-1", true));

                        ValAmount2.ClientValidationFunction = "CheckItemO" + (i - 1).ToString();
                        txtPrice.Attributes.Add("onchange", "javascript:MakeJSum();");
                        ddlCarType.SelectedValue = VouData[int.Parse(FNo) - 1].CarType;
                        if (ddlCarType.SelectedIndex > 0)
                        {
                            myCarType = new CarType();
                            myCarType.cnn = WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString;
                            myCarType.Branch = short.Parse(Session["Branch"].ToString());
                            myCarType.FCode = ddlCarType.SelectedValue;
                            ddlModel.DataTextField = "Name1";
                            ddlModel.DataValueField = "Code";

                            ddlModel.DataSource = myCarType.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            ddlModel.DataBind();

                            ddlModel.SelectedValue = VouData[int.Parse(FNo) - 1].Model;
                            txtPlateNo.Text = VouData[int.Parse(FNo) - 1].PlateNo;
                            txtChassisNo.Text = VouData[int.Parse(FNo) - 1].ChassisNo;
                            txtColor.Text = VouData[int.Parse(FNo) - 1].Color;
                            txtPrice.Text = VouData[int.Parse(FNo) - 1].Price.ToString();   // string.Format("{0:N2}", VouData[int.Parse(FNo) - 1].Price);
                            txtPrice2.Value = VouData[int.Parse(FNo) - 1].Price2.ToString(); // string.Format("{0:N2}", VouData[int.Parse(FNo) - 1].Price2);
                        }
                    }
                    i++;
                }
                MakeSum();
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
            try
            {
                BtnDiscountTerm_Click(BtnDiscountTerm, null);

                txtTotal.Text = "";
                double tot = 0;
                foreach (GridViewRow gvr in grdCodes.Rows)
                {
                    TextBox txtPrice = gvr.FindControl("txtPrice") as TextBox;
                    if (txtPrice != null)
                    {
                        if (txtPrice.Text == "") txtPrice.Text = "0";
                        tot += moh.StrToDouble(txtPrice.Text);
                    }
                }
                tot = tot - moh.StrToDouble(txtDiscount.Text);
                txtTotal.Text = tot.ToString() ; //string.Format("{0:N2}", tot);
                MakeSum0();
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

        public void MakeSum0()
        {
            LblTax.Text = moh.doTax(txtGDate.Text, 1);
            txtTax.Text = (DateTime.Parse(txtGDate.Text) >= DateTime.Parse("01/01/2018") ? (moh.StrToDouble(txtTotal.Text) * moh.doTax(txtGDate.Text)).ToString() : "0");
            txtTotNet.Text = (moh.StrToDouble(txtTotal.Text) + moh.StrToDouble(txtTax.Text)).ToString();
        }


        public void MakeSum2()
        {
            try
            {
                txtTotal.Text = "";
                double tot = 0;
                foreach (GridViewRow gvr in grdCodes.Rows)
                {
                    TextBox txtPrice = gvr.FindControl("txtPrice") as TextBox;
                    if (txtPrice != null)
                    {
                        if (txtPrice.Text == "") txtPrice.Text = "0";
                        tot += moh.StrToDouble(txtPrice.Text);
                    }
                }
                txtTotal.Text = tot.ToString(); //string.Format("{0:N2}", tot);
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

        public void SaveGridInfo()
        {
            VouData.Clear();
            int i = 1;
            foreach (GridViewRow gvr in grdCodes.Rows)
            {
                DropDownList ddlCarType = gvr.FindControl("ddlCarType") as DropDownList;
                string FNo = grdCodes.DataKeys[gvr.RowIndex]["FNo"].ToString();
                DropDownList ddlModel = gvr.FindControl("ddlModel") as DropDownList;
                TextBox txtBrand = gvr.FindControl("txtBrand") as TextBox;
                TextBox txtPlateNo = gvr.FindControl("txtPlateNo") as TextBox;
                TextBox txtChassisNo = gvr.FindControl("txtChassisNo") as TextBox;
                TextBox txtColor = gvr.FindControl("txtColor") as TextBox;
                TextBox txtPrice = gvr.FindControl("txtPrice") as TextBox;
                HiddenField txtPrice2 = gvr.FindControl("txtPrice2") as HiddenField;

                if (ddlCarType != null && ddlModel != null && txtBrand != null && txtPlateNo != null && txtChassisNo != null && txtColor != null && txtPrice != null && FNo != null && txtPrice2 != null)
                {
                    if (txtPrice.Text == "") txtPrice.Text = "0";
                    if (txtPrice2.Value == "") txtPrice2.Value = "0";
                    VouData.Add(new InvOnLineDetails
                    {
                        Brand = txtBrand.Text,
                        CarType = ddlCarType.SelectedValue,
                        ChassisNo = txtChassisNo.Text,
                        Color = txtColor.Text,
                        FNo = (short)i,
                        Model = ddlModel.SelectedValue,
                        PlateNo = txtPlateNo.Text,
                        Price = moh.StrToDouble(txtPrice.Text),
                        Price2 = moh.StrToDouble(txtPrice2.Value)
                    });
                }
                i++;
            }
        }

        protected void ddlQty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SaveGridInfo();
                if (VouData.Count > ddlQty.SelectedIndex + 1)
                {
                    for (int i = VouData.Count; i > (ddlQty.SelectedIndex + 1); i--)
                    {
                        VouData.RemoveAt(i - 1);
                    }
                }
                else
                {
                    for (int i = VouData.Count; i <= ddlQty.SelectedIndex; i++)
                    {
                        VouData.Add(new InvOnLineDetails { FNo = (short)(i + 1) });
                    }
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
                        myArch.DocType = 503;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(AreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 503;
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
                            UserTran.FormName = "اتفاقية شحن";
                            UserTran.FormAction = "اضافة مرفقات";
                            UserTran.Description = "أضافة مرفقات أتفاقية الشحن رقم " + lblBranch.Text + "/" + txtVouNo.Text;
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
                myArch.DocType = 503;
                myArch.FNo = short.Parse(FNo);
                myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                {
                    Transactions UserTran = new Transactions();
                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                    UserTran.UserName = Session["CurrentUser"].ToString();
                    UserTran.FormName = "اتفاقية شحن";
                    UserTran.FormAction = "الغاء مرفقات";
                    UserTran.Description = "الغاء مرفقات أتفاقية الشحن رقم " + lblBranch.Text + "/" + txtVouNo.Text;
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
                myArch.DocType = 503;
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

        protected void ddlCarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddlCarType = sender as DropDownList;
                if (ddlCarType != null && ddlCarType.SelectedIndex > 0)
                {
                    GridViewRow gvr = ddlCarType.NamingContainer as GridViewRow;
                    string FNo = grdCodes.DataKeys[gvr.RowIndex]["FNo"].ToString();
                    VouData[int.Parse(FNo) - 1].CarType = ddlCarType.SelectedValue;
                    DropDownList ddlModel = gvr.FindControl("ddlModel") as DropDownList;
                    if (ddlModel != null)
                    {
                        CarType myCarType = new CarType();
                        myCarType.cnn = WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString;
                        myCarType.Branch = short.Parse(Session["Branch"].ToString());
                        myCarType.FCode = ddlCarType.SelectedValue;
                        ddlModel.DataTextField = "Name1";
                        ddlModel.DataValueField = "Code";
                        ddlModel.DataSource = myCarType.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        ddlModel.DataBind();
                        VouData[int.Parse(FNo) - 1].Model = ddlModel.SelectedValue;
                        ddlModel_SelectedIndexChanged(ddlModel, e);
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

        protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddlModel = sender as DropDownList;
                if (ddlModel != null)
                {
                    GridViewRow gvr = ddlModel.NamingContainer as GridViewRow;
                    string FNo = grdCodes.DataKeys[gvr.RowIndex]["FNo"].ToString();
                    TextBox txtPrice = gvr.FindControl("txtPrice") as TextBox;
                    HiddenField txtPrice2 = gvr.FindControl("txtPrice2") as HiddenField;

                    VouData[int.Parse(FNo) - 1].Model = ddlModel.SelectedValue;
                    CarType myCarType = new CarType();
                    myCarType.cnn = WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString;
                    myCarType.Branch = short.Parse(Session["Branch"].ToString());
                    myCarType.Code = ddlModel.SelectedValue;
                    myCarType = myCarType.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myCarType != null && ddlDestination.SelectedIndex > 0 && ddlPlaceofLoading.SelectedIndex > 0)
                    {
                        double vPer = 0;
                        CarPrices myPrice = new CarPrices();
                        myPrice.Branch = short.Parse(Session["Branch"].ToString());
                        myPrice.MonthNo = 0;
                        myPrice.FromCode = ddlPlaceofLoading.SelectedValue;
                        myPrice.toCode = ddlDestination.SelectedValue;
                        myPrice.PLevel = myCarType.LevelCode;
                        if (this.ddlCustomers.SelectedValue != "-1")
                        {
                            myPrice.AccountNo = ddlCustomers.SelectedValue;
                            myPrice.PLevel = "00002";
                            myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myPrice != null)
                            {
                                txtPrice.Text = (rdoVouType.SelectedValue == "0" ? (myPrice.HOneWay + (myPrice.HOneWay * vPer / 100)).ToString() : (myPrice.HTwoWay + (myPrice.HTwoWay * vPer / 100)).ToString());
                                txtPrice2.Value = (rdoVouType.SelectedValue == "0" ? (myPrice.LOneWay + (myPrice.LOneWay * vPer / 100)).ToString() : (myPrice.LTwoWay + (myPrice.LTwoWay * vPer / 100)).ToString());

                                VouData[int.Parse(FNo) - 1].Price = moh.StrToDouble(txtPrice.Text);
                                VouData[int.Parse(FNo) - 1].Price2 = moh.StrToDouble(txtPrice2.Value);
                                MakeSum();
                                return;
                            }
                        }

                        myPrice = new CarPrices();
                        myPrice.Branch = short.Parse(Session["Branch"].ToString());
                        myPrice.MonthNo = 0;
                        myPrice.FromCode = ddlPlaceofLoading.SelectedValue;
                        myPrice.toCode = ddlDestination.SelectedValue;
                        //myPrice.PLevel = myCarType.LevelCode;
                        myPrice.PLevel = (myCarType.LevelCode == "00002" ? "00007" :
                                            myCarType.LevelCode == "00003" ? "00008" :
                                            myCarType.LevelCode == "00006" ? "00009" : "00010");

                        myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myPrice != null && txtPrice != null && txtPrice2 != null)
                        {
                            /*
                            Offers myOffer = new Offers();
                            myOffer.Branch = short.Parse(Session["Branch"].ToString());
                            foreach (Offers itm in myOffer.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                if ((bool)itm.OfferActive)
                                {
                                    if (DateTime.Parse(txtGDate.Text) >= DateTime.Parse(itm.FDate) && DateTime.Parse(txtGDate.Text) <= DateTime.Parse(itm.EDate))
                                    {
                                        vPer = (double)itm.Discount;
                                        if (itm.FTime != "" && itm.ETime != "")
                                        {
                                            if (moh.Nows().TimeOfDay >= TimeSpan.Parse(itm.FTime) && moh.Nows().TimeOfDay <= TimeSpan.Parse(itm.ETime))
                                            {
                                                vPer = (double)itm.Discount;
                                            }
                                            else vPer = 0;
                                        }

                                        break;
                                    }
                                }
                            }
                             */


                            if (rdoShipType2.Items[0].Selected)
                            {
                                txtPrice.Text = (rdoVouType.SelectedValue == "0" ? (myPrice.HOneWay + (myPrice.HOneWay * vPer / 100) + (chkbPlaceFrom.Checked ? 50 : 0) + (this.chkbTo.Checked ? 50 : 0)).ToString() : (myPrice.HTwoWay + (myPrice.HTwoWay * vPer / 100) + (chkbPlaceFrom.Checked ? 100 : 0) + (this.chkbTo.Checked ? 100 : 0)).ToString());
                                txtPrice2.Value = (rdoVouType.SelectedValue == "0" ? (myPrice.HOneWay + (myPrice.HOneWay * vPer / 100)).ToString() : (myPrice.HTwoWay + (myPrice.HTwoWay * vPer / 100)).ToString());
                            }
                            else
                            {
                                if (ddlShipType2.SelectedIndex == 0) txtPrice.Text = (rdoVouType.SelectedValue == "0" ? (myPrice.ExPrice1).ToString() : (myPrice.ExPrice1 * 2 * 0.9).ToString());
                                else if (ddlShipType2.SelectedIndex == 1) txtPrice.Text = (rdoVouType.SelectedValue == "0" ? (myPrice.ExPrice2).ToString() : (myPrice.ExPrice2 * 2 * 0.9).ToString());
                                else txtPrice.Text = (rdoVouType.SelectedValue == "0" ? (myPrice.ExPrice3).ToString() : (myPrice.ExPrice3 * 2 * 0.9).ToString());
                                txtPrice2.Value = txtPrice.Text;
                            }

                            // txtPrice.Text = (rdoVouType.SelectedValue == "0" ? (myPrice.HOneWay + (myPrice.HOneWay * vPer / 100)).ToString() : (myPrice.HTwoWay + (myPrice.HTwoWay * vPer / 100)).ToString());
                            // txtPrice2.Value = (rdoVouType.SelectedValue == "0" ? (myPrice.LOneWay + (myPrice.LOneWay * vPer / 100)).ToString() : (myPrice.LTwoWay + (myPrice.LTwoWay * vPer / 100)).ToString());

                            VouData[int.Parse(FNo) - 1].Price = moh.StrToDouble(txtPrice.Text);
                            VouData[int.Parse(FNo) - 1].Price2 = moh.StrToDouble(txtPrice2.Value);
                            MakeSum();
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

        protected void ValAmount2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                CustomValidator ValAmount2 = source as CustomValidator;
                GridViewRow gvr = ValAmount2.NamingContainer as GridViewRow;
                TextBox txtPrice = gvr.FindControl("txtPrice") as TextBox;
                HiddenField txtPrice2 = gvr.FindControl("txtPrice2") as HiddenField;
                string FNo = grdCodes.DataKeys[gvr.RowIndex]["FNo"].ToString();
                args.IsValid = true;
                if (txtPrice != null && txtPrice2 != null && FNo != null)
                {
                    if (txtPrice.Text == "") txtPrice.Text = "0";
                    if (txtPrice2.Value == "") txtPrice2.Value = "0";
                    if (moh.StrToDouble(txtPrice.Text) < moh.StrToDouble(txtPrice2.Value))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد تجاوزت الحد الادنى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        args.IsValid = false;
                    }
                    else VouData[int.Parse(FNo) - 1].Price = moh.StrToDouble(txtPrice.Text);
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

        protected void BtnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                int vCarType = -1;
                int vModel = -1;
                string vBrand = "";
                string vColor = "";
                string vPrice = "";
                string vPrice2 = "";

                foreach (GridViewRow gvr in grdCodes.Rows)
                {
                    DropDownList ddlCarType = gvr.FindControl("ddlCarType") as DropDownList;
                    DropDownList ddlModel = gvr.FindControl("ddlModel") as DropDownList;
                    TextBox txtBrand = gvr.FindControl("txtBrand") as TextBox;
                    TextBox txtColor = gvr.FindControl("txtColor") as TextBox;
                    TextBox txtPrice = gvr.FindControl("txtPrice") as TextBox;
                    HiddenField txtPrice2 = gvr.FindControl("txtPrice2") as HiddenField;
                    string FNo = grdCodes.DataKeys[gvr.RowIndex]["FNo"].ToString();

                    if (ddlCarType != null && ddlModel != null && txtBrand != null && txtColor != null && txtPrice != null && FNo != null && txtPrice2 != null)
                    {
                        if (ddlCarType.SelectedIndex > 0)
                        {
                            vCarType = ddlCarType.SelectedIndex;
                            vModel = ddlModel.SelectedIndex;
                            vBrand = txtBrand.Text;
                            vColor = txtColor.Text;
                            vPrice = txtPrice.Text;
                            vPrice2 = txtPrice2.Value;
                        }
                        else
                        {
                            ddlCarType.SelectedIndex = vCarType;
                            ddlCarType_SelectedIndexChanged(ddlCarType, e);
                            ddlModel.SelectedIndex = vModel;
                            txtBrand.Text = vBrand;
                            txtColor.Text = vColor;
                            txtPrice.Text = vPrice;
                            txtPrice2.Value = vPrice2;
                            VouData[int.Parse(FNo) - 1].CarType = ddlCarType.SelectedValue;
                            VouData[int.Parse(FNo) - 1].Model = ddlModel.SelectedValue;
                            if (txtPrice.Text == "") txtPrice.Text = "0";
                            if (txtPrice2.Value == "") txtPrice2.Value = "0";
                            VouData[int.Parse(FNo) - 1].Price = moh.StrToDouble(txtPrice.Text);
                            VouData[int.Parse(FNo) - 1].Price2 = moh.StrToDouble(txtPrice2.Value);
                            MakeSum();
                            break;
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

        protected void ChkReturnInv_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtOVouNo.Visible = ChkReturnInv.Checked;
                BtnFind2.Visible = ChkReturnInv.Checked;
                if (!ChkReturnInv.Checked) txtOVouNo.Text = "";
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

        protected void BtnFind2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtOVouNo.Text != "")
                {
                    if (txtOVouNo.Text.Split('/').Count() < 2)
                    {
                        txtOVouNo.Text = int.Parse(AreaNo).ToString() + "/" + txtOVouNo.Text;
                    }

                    
                    InvOnLine myInv = new InvOnLine();
                    /*
                    myInv.OVouNo = txtOVouNo.Text;
                    myInv = myInv.FindByOVouNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myInv != null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "تم عمل عودة لنفس الفاتورة في الفاتورة رقم " + int.Parse(myInv.VouLoc).ToString() + "/" + myInv.VouNo.ToString();
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }
                     */

                    myInv = new InvOnLine();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = moh.MakeMask(txtOVouNo.Text.Split('/')[0], 5);
                    myInv.VouNo = int.Parse(txtOVouNo.Text.Split('/')[1]);


                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الفاتورة غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    else
                    {
                        if ((short)myInv.VouType != 1)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الفاتورة ذهاب فقط وليست ذهاب و عودة";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        }
                        else
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.FormName = "اتفاقية شحن";
                                UserTran.FormAction = "عوده";
                                UserTran.Description = "اختيار عوده لأتفاقية الشحن رقم " + txtOVouNo.Text + " في أتفاقية الشحن رقم " + lblBranch.Text + "/" + txtVouNo.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }


                            GetInv(myInv, true);
                            InvOnLineDetails sinv = new InvOnLineDetails();
                            sinv.Branch = myInv.Branch;
                            sinv.VouLoc = myInv.VouLoc;
                            sinv.VouNo = myInv.VouNo;
                            VouData.Clear();
                            VouData = sinv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            foreach (InvOnLineDetails itm in VouData)
                            {
                                itm.Price = 0;
                                itm.Price2 = 0;
                            }
                            DispVouData();
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

        protected void chkbPlaceFrom_CheckedChanged(object sender, EventArgs e)
        {
            btnFrom.Visible = chkbPlaceFrom.Checked;
            lnkFrom.Visible = chkbPlaceFrom.Checked;
            lnkDispFrom.Visible = chkbPlaceFrom.Checked;
            if(sender != null) RefreshPrices();
        }

        protected void chkbTo_CheckedChanged(object sender, EventArgs e)
        {
            btnPlaceTo.Visible = chkbTo.Checked;
            lnkTo.Visible = chkbTo.Checked;
            lnkDispTo.Visible = chkbTo.Checked;
            if (sender != null) RefreshPrices();
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

        protected void rdoShipType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlShipType2.Visible = rdoShipType2.Items[1].Selected;
            if (ddlShipType2.Visible)
            {
                ddlShipType2.SelectedIndex = 0;                
            }
            if (sender != null) RefreshPrices();
        }

        protected void BtnDiscountTerm_Click(object sender, ImageClickEventArgs e)
        {
            if (txtDiscountTerm.Text.Trim() != "")
            {
                double tot = 0;
                foreach (GridViewRow gvr in grdCodes.Rows)
                {
                    HiddenField txtPrice2 = gvr.FindControl("txtPrice2") as HiddenField;
                    if (txtPrice2 != null)
                    {
                        if (txtPrice2.Value == "") txtPrice2.Value = "0";
                        tot += moh.StrToDouble(txtPrice2.Value);
                    }
                }

                ChkPromo cp = new ChkPromo();
                cp = moh.CheckMyPromoCode(1, txtDiscountTerm.Text, ddlCustomers.SelectedValue, lblBranch.Text.Trim() + "/" + txtVouNo.Text.Trim(), txtGDate.Text + " " + LblFTime.Text, 2, ddlPlaceofLoading.SelectedValue, ddlDestination.SelectedValue, Slat, Slng, txtUserName.ToolTip, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                if (cp.ErrMsg == "1")
                {
                    double Discount = 0, vDisPer = 0;
                    if (cp.Amount != 0) Discount = (double)cp.Amount;
                    else if (cp.SAmount != 0) Discount = (double)cp.SAmount;
                    else if (cp.Per != 0)
                    {
                        vDisPer = (double)(cp.Per / 100);
                        Discount = (tot * vDisPer);
                    }
                    else if (cp.SPer != 0)
                    {
                        vDisPer = (double)(cp.SPer / 100);
                        Discount = (tot * vDisPer);
                    }
                    txtDiscount.Text = Discount.ToString();
                    MakeSum0();
                }
                else
                {
                    txtDiscount.Text = "0";
                    txtDiscountTerm.Text = "";
                    MakeSum0();

                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "كود الخصم غير صالح";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    return;
                }
            }

            //MakeSum();
        }

        public void RefreshPrices()
        {
            foreach (GridViewRow gvr in grdCodes.Rows)
            {
                DropDownList ddlModel = gvr.FindControl("ddlModel") as DropDownList;
                if (ddlModel != null)
                {
                    ddlModel_SelectedIndexChanged(ddlModel, null);
                }
            }
            //BtnDiscountTerm_Click(null, null);
        }

        protected void ddlShipType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshPrices();
        }

        protected void ChkCust_CheckedChanged(object sender, EventArgs e)
        {
            ddlCust.Visible = ChkCust.Checked;
            txtName.Visible = !ChkCust.Checked;
        }

        protected void ddlCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCust.SelectedIndex != 0)
            {
                Clients myCust = new Clients();
                myCust.Branch = short.Parse(Session["Branch"].ToString());
                myCust.Code = ddlCust.SelectedValue;
                myCust = myCust.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myCust != null)
                {
                    txtName.Text = myCust.Name1;
                    txtIDNo.Text = myCust.IdNo;
                    txtAddress.Text = myCust.Address;
                    txtMobileNo.Text = myCust.MobileNo;
                    ddlCustomers.SelectedValue = myCust.Account;
                    ddlCustomers_SelectedIndexChanged(sender, e);
                }
            }
        }

        protected void ddlCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshPrices();
        }

        protected void txtGDate_TextChanged(object sender, EventArgs e)
        {
            MakeSum();
        }

        protected void txtPrice_TextChanged(object sender, EventArgs e)
        {
            MakeSum();
        }

    }
}