using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Configuration;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class WebFastRepair : System.Web.UI.Page
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
        public string vAreaNo
        {
            get
            {
                if (ViewState["vAreaNo"] == null)
                {
                    ViewState["vAreaNo"] = "00001";
                }
                return ViewState["vAreaNo"].ToString();
            }
            set { ViewState["vAreaNo"] = value; }
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

            BtnPrint.Visible = true; // (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass275 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass245;
            BtnEdit.Visible = true; // (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass272 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass242;
            BtnNew.Visible = false;
            BtnDelete.Visible = true; // (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass273 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass243;

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
            //if (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0")
           // {
           //     if (!(bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass272) ControlsOnOff(false);
           // }
           // else if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass242) ControlsOnOff(false);
        }

        public void NewMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            //txtVouNo.ReadOnly = false;
            //txtVouNo.BackColor = System.Drawing.Color.White;

            BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = true; // (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass271 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass241;
            BtnDelete.Visible = false;

            txtReason.Visible = false;
            ValReason.Enabled = false;
            lblReason.Visible = false;
            //if (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0")
            //{
            //    if (!(bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass272) ControlsOnOff(true);
            //}
            //else if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass242) ControlsOnOff(true);
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
                    this.Page.Header.Title = "بيان أصلاح خارجي سريع";

                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "الرئيسية", "اختيار", "اختيار بيان أصلاح خارجي سريع", "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    if (Request.QueryString["AreaNo"] != null)
                    {
                        AreaNo = Request.QueryString["AreaNo"].ToString();
                        vAreaNo = AreaNo;
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
                            vAreaNo = AreaNo;
                            SiteInfo = (CostCenter)Session["SiteInfo"];
                        }                        
                    }
                    if (Request.QueryString["StoreNo"] != null) StoreNo = Request.QueryString["StoreNo"].ToString();

                    if (Request.QueryString["FType"] != null)
                    {
                        LocType = 3;
                        vAreaNo = "00001";
                        lblBranch2.Text = "/00" + short.Parse(vAreaNo).ToString();                        
                    }
                    else lblBranch2.Text = "/" + short.Parse(vAreaNo).ToString();

                    lblJobOrder.Visible = (LocType == 3);
                    txtJobOrder.Visible = (LocType == 3);
                    ValJobOrder.Enabled = (LocType == 3);
                    ValJobOrder2.Enabled = (LocType == 3);
                    ddlVehicle.Enabled = (LocType != 3);
                    txtCarNo.ReadOnly = (LocType == 3);

                    Drivers myDrive = new Drivers();
                    myDrive.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlDriver.DataTextField = GetLocalResourceObject("DriverName").ToString();  //"Name1";
                    ddlDriver.DataValueField = "Code";
                    ddlDriver.DataSource = (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()]);
                    ddlDriver.DataBind();
                    ddlDriver.Items.Insert(0,new ListItem("--- أختار السائق ---", "-1", true));  // "WorkShop"

                    Cars myCar = new Cars();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                    myCar.CarsType = 1;
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlVehicle.DataTextField = GetLocalResourceObject("CarName").ToString();  //"Name";
                    ddlVehicle.DataValueField = "Code";
                    ddlVehicle.DataSource = (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()]);
                    ddlVehicle.DataBind();
                    ddlVehicle.Items.Insert(0, new ListItem("--- أختار الوحدة ---", "-1", true));

                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    vRoleName = moh.GetCurrentRole(vAreaNo, (from useritm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                                            where useritm.UserName == Session["CurrentUser"].ToString()
                                                            select useritm).FirstOrDefault());
                    if (Session[vRoleName] == null)
                    {
                        Response.Redirect("WebNotPrev.aspx", false);
                        return;
                    }

                    //BtnNew.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass271 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass241;
                    //BtnEdit.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass272 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass242;
                    //BtnDelete.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass273 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass243;
                    //BtnSearch.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass274 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass244;
                    //BtnFind.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass274 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass244;
                    //BtnPrint.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass275 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass245;


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
                                }
                            }
                        }
                        txtSearch.Text = Request.QueryString["FNum"].ToString();
                        BtnSearch_Click(sender, null);

                        if (Request.QueryString["FType2"] != null)
                        {
                            if (Request.QueryString["FType2"].ToString() == "1")
                            {
                                chkAgree1.Enabled = true;
                                txtAgreeRemark1.Enabled = true;
                                BtnAgree1.Enabled = true;
                                BtnDisagree1.Enabled = true;
                            }
                            else if (Request.QueryString["FType2"].ToString() == "2")
                            {
                                txtAgreeRemark2.Enabled = true;
                                chkAgree2.Enabled = true;
                            }
                            else if (Request.QueryString["FType2"].ToString() == "3")
                            {
                                txtAgreeRemark3.Enabled = true;
                                chkAgree3.Enabled = true;
                            }
                        }
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
                NewMode();
                txtSearch.Text = "";
                ddlDriver.SelectedIndex = 0;
                ddlVehicle.SelectedIndex = 0;
                lblStatus.Text = "";
                txtVouDate.Text = "";
                txtAm1.Text = "";
                txtAm2.Text = "";
                txtAm3.Text = "";
                txtAm4.Text = "";
                txtAm5.Text = "";
                txtAm6.Text = "";
                txtAm7.Text = "";
                txtAm8.Text = "";
                txtAm9.Text = "";
                txtAm10.Text = "";
                txtAm11.Text = "";
                txtAm12.Text = "";
                txtAm13.Text = "";
                txtAm14.Text = "";
                txtAm15.Text = "";
                txtAm16.Text = "";
                txtAm17.Text = "";
                txtAm18.Text = "";
                txtAm19.Text = "";
                txtAm20.Text = "";
                txtAm21.Text = "";
                txtAm22.Text = "";
                txtAm23.Text = "";
                txtAm24.Text = "";
                txtAm25.Text = "";
                txtAm26.Text = "";
                txtAm27.Text = "";
                txtAm28.Text = "";
                txtAm29.Text = "";
                txtAm30.Text = "";
                txtAm31.Text = "";
                txtAm32.Text = "";
                txtAm33.Text = "";
                txtAm34.Text = "";
                txtInvDate1.Text = "";
                txtInvDate2.Text = "";
                txtInvDate3.Text = "";
                txtInvDate4.Text = "";
                txtInvDate5.Text = "";
                txtInvDate6.Text = "";
                txtInvDate7.Text = "";
                txtInvDate8.Text = "";
                txtInvDate9.Text = "";
                txtInvDate10.Text = "";
                txtInvDate11.Text = "";
                txtInvDate12.Text = "";
                txtInvDate13.Text = "";
                txtInvDate14.Text = "";
                txtInvDate15.Text = "";
                txtInvDate16.Text = "";
                txtInvDate17.Text = "";
                txtInvDate18.Text = "";
                txtInvDate19.Text = "";
                txtInvDate20.Text = "";
                txtInvDate21.Text = "";
                txtInvDate22.Text = "";
                txtInvDate23.Text = "";
                txtInvDate24.Text = "";
                txtInvDate25.Text = "";
                txtInvDate26.Text = "";
                txtInvDate27.Text = "";
                txtInvDate28.Text = "";
                txtInvDate29.Text = "";
                txtInvDate30.Text = "";
                txtInvDate31.Text = "";
                txtInvDate32.Text = "";
                txtInvDate33.Text = "";
                txtInvDate34.Text = "";
                txtInvNo1.Text = "";
                txtInvNo2.Text = "";
                txtInvNo3.Text = "";
                txtInvNo4.Text = "";
                txtInvNo5.Text = "";
                txtInvNo6.Text = "";
                txtInvNo7.Text = "";
                txtInvNo8.Text = "";
                txtInvNo9.Text = "";
                txtInvNo10.Text = "";
                txtInvNo11.Text = "";
                txtInvNo12.Text = "";
                txtInvNo13.Text = "";
                txtInvNo14.Text = "";
                txtInvNo15.Text = "";
                txtInvNo16.Text = "";
                txtInvNo17.Text = "";
                txtInvNo18.Text = "";
                txtInvNo19.Text = "";
                txtInvNo20.Text = "";
                txtInvNo21.Text = "";
                txtInvNo22.Text = "";
                txtInvNo23.Text = "";
                txtInvNo24.Text = "";
                txtInvNo25.Text = "";
                txtInvNo26.Text = "";
                txtInvNo27.Text = "";
                txtInvNo28.Text = "";
                txtInvNo29.Text = "";
                txtInvNo30.Text = "";
                txtInvNo31.Text = "";
                txtInvNo32.Text = "";
                txtInvQty1.Text = "";
                txtInvQty2.Text = "";
                txtInvQty3.Text = "";
                txtInvQty4.Text = "";
                txtInvQty5.Text = "";
                txtInvQty6.Text = "";
                txtInvQty7.Text = "";
                txtInvQty8.Text = "";
                txtInvQty9.Text = "";
                txtInvQty10.Text = "";
                txtInvQty11.Text = "";
                txtInvQty12.Text = "";
                txtInvQty13.Text = "";
                txtInvQty14.Text = "";
                txtInvQty15.Text = "";
                txtInvQty16.Text = "";
                txtInvQty17.Text = "";
                txtInvQty18.Text = "";
                txtInvQty19.Text = "";
                txtInvQty20.Text = "";
                txtInvQty21.Text = "";
                txtInvQty22.Text = "";
                txtInvQty23.Text = "";
                txtInvQty24.Text = "";
                txtInvQty25.Text = "";
                txtInvQty26.Text = "";
                txtInvQty27.Text = "";
                txtInvQty28.Text = "";
                txtInvQty29.Text = "";
                txtInvQty30.Text = "";
                txtInvQty31.Text = "";
                txtInvQty32.Text = "";
                txtInvQty33.Text = "";
                txtInvQty34.Text = "";
                txtJobOrder.Text = "";
                txtTax.Text = "";
                txtTotal.Text = "";
                txtReason.Text = "";
                txtRemark.Text = "";
                txtCarNo.Text = "";
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                if (sender != null)
                {
                    txtVouNo.Text = "";
                    FastRepair myJv = new FastRepair();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.LocType = LocType;
                    myJv.VouLoc = short.Parse(vAreaNo);
                    int? i = myJv.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
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
                LoadAttachData();

                txtAgreeRemark1.Enabled = false;
                chkAgree1.Enabled = false;
                BtnAgree1.Enabled = false;
                BtnDisagree1.Enabled = false;

                txtAgreeRemark2.Enabled = false;
                chkAgree2.Enabled = false;

                txtAgreeRemark3.Enabled = false;
                chkAgree3.Enabled = false;

                txtAgreeRemark1.Text = "";
                txtAgreeRemark2.Text = "";
                txtAgreeRemark3.Text = "";
                txtAgreeUser1.Text = "";
                txtAgreeUser2.Text = "";
                txtAgreeUser3.Text = "";
                txtAgreeUserDate1.Text = "";
                txtAgreeUserDate2.Text = "";
                txtAgreeUserDate3.Text = "";
                chkAgree1.Checked = false;
                chkAgree2.Checked = false;
                chkAgree3.Checked = false;
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
            ddlDriver.Enabled = State;
            if (LocType != 3)
            {
                ddlVehicle.Enabled = State;
                txtCarNo.ReadOnly = !State;
            }
            txtVouDate.ReadOnly = !State;
            txtAm1.ReadOnly = !State;
            txtAm2.ReadOnly = !State;
            txtAm3.ReadOnly = !State;
            txtAm4.ReadOnly = !State;
            txtAm5.ReadOnly = !State;
            txtAm6.ReadOnly = !State;
            txtAm7.ReadOnly = !State;
            txtAm8.ReadOnly = !State;
            txtAm9.ReadOnly = !State;
            txtAm10.ReadOnly = !State;
            txtAm11.ReadOnly = !State;
            txtAm12.ReadOnly = !State;
            txtAm13.ReadOnly = !State;
            txtAm14.ReadOnly = !State;
            txtAm15.ReadOnly = !State;
            txtAm16.ReadOnly = !State;
            txtAm17.ReadOnly = !State;
            txtAm18.ReadOnly = !State;
            txtAm19.ReadOnly = !State;
            txtAm20.ReadOnly = !State;
            txtAm21.ReadOnly = !State;
            txtAm22.ReadOnly = !State;
            txtAm23.ReadOnly = !State;
            txtAm24.ReadOnly = !State;
            txtAm25.ReadOnly = !State;
            txtAm26.ReadOnly = !State;
            txtAm27.ReadOnly = !State;
            txtAm28.ReadOnly = !State;
            txtAm29.ReadOnly = !State;
            txtAm30.ReadOnly = !State;
            txtAm31.ReadOnly = !State;
            txtAm32.ReadOnly = !State;
            txtAm33.ReadOnly = !State;
            txtAm34.ReadOnly = !State;
            txtInvDate1.ReadOnly = !State;
            txtInvDate2.ReadOnly = !State;
            txtInvDate3.ReadOnly = !State;
            txtInvDate4.ReadOnly = !State;
            txtInvDate5.ReadOnly = !State;
            txtInvDate6.ReadOnly = !State;
            txtInvDate7.ReadOnly = !State;
            txtInvDate8.ReadOnly = !State;
            txtInvDate9.ReadOnly = !State;
            txtInvDate10.ReadOnly = !State;
            txtInvDate11.ReadOnly = !State;
            txtInvDate12.ReadOnly = !State;
            txtInvDate13.ReadOnly = !State;
            txtInvDate14.ReadOnly = !State;
            txtInvDate15.ReadOnly = !State;
            txtInvDate16.ReadOnly = !State;
            txtInvDate17.ReadOnly = !State;
            txtInvDate18.ReadOnly = !State;
            txtInvDate19.ReadOnly = !State;
            txtInvDate20.ReadOnly = !State;
            txtInvDate21.ReadOnly = !State;
            txtInvDate22.ReadOnly = !State;
            txtInvDate23.ReadOnly = !State;
            txtInvDate24.ReadOnly = !State;
            txtInvDate25.ReadOnly = !State;
            txtInvDate26.ReadOnly = !State;
            txtInvDate27.ReadOnly = !State;
            txtInvDate28.ReadOnly = !State;
            txtInvDate29.ReadOnly = !State;
            txtInvDate30.ReadOnly = !State;
            txtInvDate31.ReadOnly = !State;
            txtInvDate32.ReadOnly = !State;
            txtInvDate33.ReadOnly = !State;
            txtInvDate34.ReadOnly = !State;
            txtInvNo1.ReadOnly = !State;
            txtInvNo2.ReadOnly = !State;
            txtInvNo3.ReadOnly = !State;
            txtInvNo4.ReadOnly = !State;
            txtInvNo5.ReadOnly = !State;
            txtInvNo6.ReadOnly = !State;
            txtInvNo7.ReadOnly = !State;
            txtInvNo8.ReadOnly = !State;
            txtInvNo9.ReadOnly = !State;
            txtInvNo10.ReadOnly = !State;
            txtInvNo11.ReadOnly = !State;
            txtInvNo12.ReadOnly = !State;
            txtInvNo13.ReadOnly = !State;
            txtInvNo14.ReadOnly = !State;
            txtInvNo15.ReadOnly = !State;
            txtInvNo16.ReadOnly = !State;
            txtInvNo17.ReadOnly = !State;
            txtInvNo18.ReadOnly = !State;
            txtInvNo19.ReadOnly = !State;
            txtInvNo20.ReadOnly = !State;
            txtInvNo21.ReadOnly = !State;
            txtInvNo22.ReadOnly = !State;
            txtInvNo23.ReadOnly = !State;
            txtInvNo24.ReadOnly = !State;
            txtInvNo25.ReadOnly = !State;
            txtInvNo26.ReadOnly = !State;
            txtInvNo27.ReadOnly = !State;
            txtInvNo28.ReadOnly = !State;
            txtInvNo29.ReadOnly = !State;
            txtInvNo30.ReadOnly = !State;
            txtInvNo31.ReadOnly = !State;
            txtInvNo32.ReadOnly = !State;
            txtInvNo33.ReadOnly = !State;
            txtInvNo34.ReadOnly = !State;
            txtInvQty1.ReadOnly = !State;
            txtInvQty2.ReadOnly = !State;
            txtInvQty3.ReadOnly = !State;
            txtInvQty4.ReadOnly = !State;
            txtInvQty5.ReadOnly = !State;
            txtInvQty6.ReadOnly = !State;
            txtInvQty7.ReadOnly = !State;
            txtInvQty8.ReadOnly = !State;
            txtInvQty9.ReadOnly = !State;
            txtInvQty10.ReadOnly = !State;
            txtInvQty11.ReadOnly = !State;
            txtInvQty12.ReadOnly = !State;
            txtInvQty13.ReadOnly = !State;
            txtInvQty14.ReadOnly = !State;
            txtInvQty15.ReadOnly = !State;
            txtInvQty16.ReadOnly = !State;
            txtInvQty17.ReadOnly = !State;
            txtInvQty18.ReadOnly = !State;
            txtInvQty19.ReadOnly = !State;
            txtInvQty20.ReadOnly = !State;
            txtInvQty21.ReadOnly = !State;
            txtInvQty22.ReadOnly = !State;
            txtInvQty23.ReadOnly = !State;
            txtInvQty24.ReadOnly = !State;
            txtInvQty25.ReadOnly = !State;
            txtInvQty26.ReadOnly = !State;
            txtInvQty27.ReadOnly = !State;
            txtInvQty28.ReadOnly = !State;
            txtInvQty29.ReadOnly = !State;
            txtInvQty30.ReadOnly = !State;
            txtInvQty31.ReadOnly = !State;
            txtInvQty32.ReadOnly = !State;
            txtInvQty33.ReadOnly = !State;
            txtInvQty34.ReadOnly = !State;
            txtTax.ReadOnly = !State;
            txtReason.ReadOnly = !State;
            txtRemark.ReadOnly = !State;
            txtVouDate.ReadOnly = !State;
            txtJobOrder.ReadOnly = !State;
            //grdAttach.Enabled = State;
            /*
            foreach (GridViewRow itm in grdAttach.Rows)
            {
                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                if (BtnDelete != null) BtnDelete.Visible = State;
            }
            FileUpload1.Enabled = State;
            BtnAttach.Enabled = State;
             */
        }

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    //if (ddlDriver.SelectedIndex == 0)
                    //{
                    //    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    //    LblCodesResult.Text = "يجب أختيار السائق";
                    //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    //    return;
                    //}
                    if (ddlVehicle.SelectedIndex == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أختيار الشاحنة"; 
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                    if (LocType == 3 && !CheckRef()) return;

                    FastRepair myJv = new FastRepair();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.LocType = LocType;
                    myJv.VouLoc = short.Parse(vAreaNo);
                    myJv.VouNo = int.Parse(txtVouNo.Text);
                    myJv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myJv != null)
                    {
                        if (myJv.UserName == txtUserName.ToolTip)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم بيان الأصلاح مكرر";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                        else
                        {
                            myJv = new FastRepair();
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.LocType = LocType;
                            myJv.VouLoc = short.Parse(vAreaNo);
                            int? i = myJv.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
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

                    if (Saveall(true))
                    {
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان اصلاح خارجي", "اضافة", "أضافة بيان الاصلاح رقم " + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                        String vNumber = txtVouNo.Text;
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
                    //if (ddlDriver.SelectedIndex == 0)
                    //{
                    //    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    //    LblCodesResult.Text = "يجب أختيار الوحدة";
                    //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    //    return;
                    //}
                    if (ddlVehicle.SelectedIndex == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أختيار الوحدة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                    if (LocType == 3 && !CheckRef()) return;

                    FastRepair myJv = new FastRepair();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.LocType = LocType;
                    myJv.VouLoc = short.Parse(vAreaNo);
                    myJv.VouNo = int.Parse(txtVouNo.Text);
                    myJv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myJv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم البيان غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        if (myJv.Am27 != 0) myJv.UnPost(myJv.CarNo, (double)myJv.Am27, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (Saveall(false))
                        {                            
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان اصلاح خارجي", "تعديل", "تعديل بيانات بيان الأصلاح رقم " + lblBranch2.Text + "/" + txtVouNo.Text, txtReason.Text, IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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
                    FastRepair myJv = new FastRepair();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.LocType = LocType;
                    myJv.VouLoc = short.Parse(vAreaNo);
                    myJv.VouNo = int.Parse(txtVouNo.Text);
                    myJv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myJv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم البيان غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (myJv.Am27 != 0) myJv.UnPost(myJv.CarNo, (double)myJv.Am27, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان اصلاح خارجي", "الغاء", "الغاء بيانات بيان الأصلاح رقم " + lblBranch2.Text + "/" + txtVouNo.Text, txtReason.Text, IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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
                    FastRepair myJv = new FastRepair();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.LocType = LocType;
                    myJv.VouLoc = short.Parse(vAreaNo);
                    myJv.VouNo = int.Parse(vs);
                    BtnClear_Click(null, e);
                    myJv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myJv == null)                        
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم البيان غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        bool vPass = true;
                        if (Request.QueryString["FType2"] == null && ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower() != "admin" && !((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("مدير التشغيل") && !((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("مدير الورشة") && !((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("الحسابات"))
                        {
                            if (myJv.UserName != txtUserName.ToolTip)
                            {
                                vPass = false;
                                Agreement vAgree0 = new Agreement();
                                vAgree0.FType = 801;
                                vAgree0.LocType = LocType;
                                vAgree0.LocNumber = short.Parse(vAreaNo);
                                vAgree0.Number = int.Parse(txtVouNo.Text);
                                foreach (Agreement itm in vAgree0.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                {
                                    if (itm.AgreeUser == txtUserName.ToolTip)
                                    {
                                        vPass = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (!vPass && ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("مراقبي الفروع"))
                        {
                            TblUsers ax0 = new TblUsers();
                            if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax0.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                            ax0.UserName = Session["CurrentUser"].ToString();
                            ax0 = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                  where uitm.UserName == ax0.UserName
                                  select uitm).FirstOrDefault();
                            if (ax0 != null && ax0.MainBran == AreaNo) vPass = true;
                        }
                        if (!vPass)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "المستخدم ليست له صلاحية لعرض البيان";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }



                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان اصلاح خارجي", "عرض", "عرض بيانات بيان اصلاح خارجي رقم " + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        EditMode();
                        txtVouNo.Text = myJv.VouNo.ToString();
                        ddlDriver.SelectedValue = myJv.DriverNo;
                        ddlVehicle.SelectedValue = myJv.CarNo;
                        txtCarNo.Text = myJv.CarNo;
                        txtVouDate.Text = myJv.VouDate;
                        txtAm1.Text = string.Format("{0:N2}", myJv.Am1);
                        txtAm2.Text = string.Format("{0:N2}", myJv.Am2);
                        txtAm3.Text = string.Format("{0:N2}", myJv.Am3);
                        txtAm4.Text = string.Format("{0:N2}", myJv.Am4);
                        txtAm5.Text = string.Format("{0:N2}", myJv.Am5);
                        txtAm6.Text = string.Format("{0:N2}", myJv.Am6);
                        txtAm7.Text = string.Format("{0:N2}", myJv.Am7);
                        txtAm8.Text = string.Format("{0:N2}", myJv.Am8);
                        txtAm9.Text = string.Format("{0:N2}", myJv.Am9);
                        txtAm10.Text = string.Format("{0:N2}", myJv.Am10);
                        txtAm11.Text = string.Format("{0:N2}", myJv.Am11);
                        txtAm12.Text = string.Format("{0:N2}", myJv.Am12);
                        txtAm13.Text = string.Format("{0:N2}", myJv.Am13);
                        txtAm14.Text = string.Format("{0:N2}", myJv.Am14);
                        txtAm15.Text = string.Format("{0:N2}", myJv.Am15);
                        txtAm16.Text = string.Format("{0:N2}", myJv.Am16);
                        txtAm17.Text = string.Format("{0:N2}", myJv.Am17);
                        txtAm18.Text = string.Format("{0:N2}", myJv.Am18);
                        txtAm19.Text = string.Format("{0:N2}", myJv.Am19);
                        txtAm20.Text = string.Format("{0:N2}", myJv.Am20);
                        txtAm21.Text = string.Format("{0:N2}", myJv.Am21);
                        txtAm22.Text = string.Format("{0:N2}", myJv.Am22);
                        txtAm23.Text = string.Format("{0:N2}", myJv.Am23);
                        txtAm24.Text = string.Format("{0:N2}", myJv.Am24);
                        txtAm25.Text = string.Format("{0:N2}", myJv.Am25);
                        txtAm26.Text = string.Format("{0:N2}", myJv.Am26);
                        txtAm27.Text = string.Format("{0:N2}", myJv.Am27);
                        txtAm28.Text = string.Format("{0:N2}", myJv.Am28);
                        txtAm29.Text = string.Format("{0:N2}", myJv.Am29);
                        txtAm30.Text = string.Format("{0:N2}", myJv.Am30);
                        txtAm31.Text = string.Format("{0:N2}", myJv.Am31);
                        txtAm32.Text = string.Format("{0:N2}", myJv.Am32);
                        txtAm33.Text = string.Format("{0:N2}", myJv.Am33);
                        txtAm34.Text = string.Format("{0:N2}", myJv.Am34);

                        txtInvDate1.Text = myJv.InvDate1;
                        txtInvDate2.Text = myJv.InvDate2;
                        txtInvDate3.Text = myJv.InvDate3;
                        txtInvDate4.Text = myJv.InvDate4;
                        txtInvDate5.Text = myJv.InvDate5;
                        txtInvDate6.Text = myJv.InvDate6;
                        txtInvDate7.Text = myJv.InvDate7;
                        txtInvDate8.Text = myJv.InvDate8;
                        txtInvDate9.Text = myJv.InvDate9;
                        txtInvDate10.Text = myJv.InvDate10;
                        txtInvDate11.Text = myJv.InvDate11;
                        txtInvDate12.Text = myJv.InvDate12;
                        txtInvDate13.Text = myJv.InvDate13;
                        txtInvDate14.Text = myJv.InvDate14;
                        txtInvDate15.Text = myJv.InvDate15;
                        txtInvDate16.Text = myJv.InvDate16;
                        txtInvDate17.Text = myJv.InvDate17;
                        txtInvDate18.Text = myJv.InvDate18;
                        txtInvDate19.Text = myJv.InvDate19;
                        txtInvDate20.Text = myJv.InvDate20;
                        txtInvDate21.Text = myJv.InvDate21;
                        txtInvDate22.Text = myJv.InvDate22;
                        txtInvDate23.Text = myJv.InvDate23;
                        txtInvDate24.Text = myJv.InvDate24;
                        txtInvDate25.Text = myJv.InvDate25;
                        txtInvDate26.Text = myJv.InvDate26;
                        txtInvDate27.Text = myJv.InvDate27;
                        txtInvDate28.Text = myJv.InvDate28;
                        txtInvDate29.Text = myJv.InvDate29;
                        txtInvDate30.Text = myJv.InvDate30;
                        txtInvDate31.Text = myJv.InvDate31;
                        txtInvDate32.Text = myJv.InvDate32;
                        txtInvDate33.Text = myJv.InvDate33;
                        txtInvDate34.Text = myJv.InvDate34;

                        txtInvNo1.Text = myJv.InvNo1;
                        txtInvNo2.Text = myJv.InvNo2;
                        txtInvNo3.Text = myJv.InvNo3;
                        txtInvNo4.Text = myJv.InvNo4;
                        txtInvNo5.Text = myJv.InvNo5;
                        txtInvNo6.Text = myJv.InvNo6;
                        txtInvNo7.Text = myJv.InvNo7;
                        txtInvNo8.Text = myJv.InvNo8;
                        txtInvNo9.Text = myJv.InvNo9;
                        txtInvNo10.Text = myJv.InvNo10;
                        txtInvNo11.Text = myJv.InvNo11;
                        txtInvNo12.Text = myJv.InvNo12;
                        txtInvNo13.Text = myJv.InvNo13;
                        txtInvNo14.Text = myJv.InvNo14;
                        txtInvNo15.Text = myJv.InvNo15;
                        txtInvNo16.Text = myJv.InvNo16;
                        txtInvNo17.Text = myJv.InvNo17;
                        txtInvNo18.Text = myJv.InvNo18;
                        txtInvNo19.Text = myJv.InvNo19;
                        txtInvNo20.Text = myJv.InvNo20;
                        txtInvNo21.Text = myJv.InvNo21;
                        txtInvNo22.Text = myJv.InvNo22;
                        txtInvNo23.Text = myJv.InvNo23;
                        txtInvNo24.Text = myJv.InvNo24;
                        txtInvNo25.Text = myJv.InvNo25;
                        txtInvNo26.Text = myJv.InvNo26;
                        txtInvNo27.Text = myJv.InvNo27;
                        txtInvNo28.Text = myJv.InvNo28;
                        txtInvNo29.Text = myJv.InvNo29;
                        txtInvNo30.Text = myJv.InvNo30;
                        txtInvNo31.Text = myJv.InvNo31;
                        txtInvNo32.Text = myJv.InvNo32;
                        txtInvNo33.Text = myJv.InvNo33;
                        txtInvNo34.Text = myJv.InvNo34;

                        txtInvQty1.Text = myJv.InvQty1;
                        txtInvQty2.Text = myJv.InvQty2;
                        txtInvQty3.Text = myJv.InvQty3;
                        txtInvQty4.Text = myJv.InvQty4;
                        txtInvQty5.Text = myJv.InvQty5;
                        txtInvQty6.Text = myJv.InvQty6;
                        txtInvQty7.Text = myJv.InvQty7;
                        txtInvQty8.Text = myJv.InvQty8;
                        txtInvQty9.Text = myJv.InvQty9;
                        txtInvQty10.Text = myJv.InvQty10;
                        txtInvQty11.Text = myJv.InvQty11;
                        txtInvQty12.Text = myJv.InvQty12;
                        txtInvQty13.Text = myJv.InvQty13;
                        txtInvQty14.Text = myJv.InvQty14;
                        txtInvQty15.Text = myJv.InvQty15;
                        txtInvQty16.Text = myJv.InvQty16;
                        txtInvQty17.Text = myJv.InvQty17;
                        txtInvQty18.Text = myJv.InvQty18;
                        txtInvQty19.Text = myJv.InvQty19;
                        txtInvQty20.Text = myJv.InvQty20;
                        txtInvQty21.Text = myJv.InvQty21;
                        txtInvQty22.Text = myJv.InvQty22;
                        txtInvQty23.Text = myJv.InvQty23;
                        txtInvQty24.Text = myJv.InvQty24;
                        txtInvQty25.Text = myJv.InvQty25;
                        txtInvQty26.Text = myJv.InvQty26;
                        txtInvQty27.Text = myJv.InvQty27;
                        txtInvQty28.Text = myJv.InvQty28;
                        txtInvQty29.Text = myJv.InvQty29;
                        txtInvQty30.Text = myJv.InvQty30;
                        txtInvQty31.Text = myJv.InvQty31;
                        txtInvQty32.Text = myJv.InvQty32;
                        txtInvQty33.Text = myJv.InvQty33;
                        txtInvQty34.Text = myJv.InvQty34;

                        txtJobOrder.Text = myJv.JobOrder.ToString();
                        txtTax.Text = string.Format("{0:N2}", myJv.Tax);
                        txtAm1_TextChanged(sender, e);
                        txtRemark.Text = myJv.Remark;
                        txtUserDate.Text = myJv.UserDate;
                        txtUserName.ToolTip = myJv.UserName;
                        TblUsers ax = new TblUsers();
                        if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        ax.UserName = myJv.UserName;
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
                        LoadAttachData();

                        Agreement myAgree = new Agreement();
                        myAgree.FType = 801;
                        myAgree.LocType = LocType;
                        myAgree.LocNumber = short.Parse(vAreaNo);
                        myAgree.Number = int.Parse(txtVouNo.Text);
                        foreach (Agreement itm in myAgree.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (itm.FNo == 1)
                            {
                                txtAgreeRemark1.Text = itm.AgreeRemark;
                                chkAgree1.Checked = (itm.Agree == 1);
                                BtnAgree1.Visible = (itm.Agree == 1);
                                BtnDisagree1.Visible = (itm.Agree != 1);
                                txtAgreeUserDate1.Text = itm.AgreeUserDate;
                                txtAgreeUser1.ToolTip = itm.AgreeUser;

                                ax = new TblUsers();
                                ax.UserName = itm.AgreeUser;
                                ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                      where uitm.UserName == ax.UserName
                                      select uitm).FirstOrDefault();
                                if (ax == null)
                                {
                                    txtAgreeUser1.Text = txtAgreeUser1.ToolTip;
                                }
                                else
                                {
                                    txtAgreeUser1.Text = ax.FName;
                                }

                                if (Request.QueryString["FType2"] == null && Session["CurrentUser"].ToString() != "Admin1" && Session["CurrentUser"].ToString() != "sameh")
                                {
                                    BtnDelete.Visible = false;
                                    BtnEdit.Visible = false;
                                    ControlsOnOff(false);
                                }
                                else
                                {
                                    BtnDelete.Visible = true;
                                    BtnEdit.Visible = true;
                                    ControlsOnOff(true);
                                }


                            }
                            else if (itm.FNo == 2)
                            {
                                txtAgreeRemark2.Text = itm.AgreeRemark;
                                chkAgree2.Checked = (itm.Agree == 1);
                                txtAgreeUserDate2.Text = itm.AgreeUserDate;
                                txtAgreeUser2.ToolTip = itm.AgreeUser;

                                ax = new TblUsers();
                                ax.UserName = itm.AgreeUser;
                                ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                      where uitm.UserName == ax.UserName
                                      select uitm).FirstOrDefault();
                                if (ax == null)
                                {
                                    txtAgreeUser2.Text = txtAgreeUser2.ToolTip;
                                }
                                else
                                {
                                    txtAgreeUser2.Text = ax.FName;
                                }

                                if (Session["CurrentUser"].ToString() != "Admin1" && Session["CurrentUser"].ToString() != "sameh")
                                {
                                    BtnDelete.Visible = false;
                                    BtnEdit.Visible = false;
                                    ControlsOnOff(false);
                                }
                                else
                                {

                                    BtnDelete.Visible = true;
                                    BtnEdit.Visible = true;
                                    ControlsOnOff(true);
                                }
                            }
                            else if (itm.FNo == 3)
                            {
                                txtAgreeRemark3.Text = itm.AgreeRemark;
                                chkAgree3.Checked = (itm.Agree == 1);
                                txtAgreeUserDate3.Text = itm.AgreeUserDate;
                                txtAgreeUser3.ToolTip = itm.AgreeUser;

                                ax = new TblUsers();
                                ax.UserName = itm.AgreeUser;
                                ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                      where uitm.UserName == ax.UserName
                                      select uitm).FirstOrDefault();
                                if (ax == null)
                                {
                                    txtAgreeUser2.Text = txtAgreeUser2.ToolTip;
                                }
                                else
                                {
                                    txtAgreeUser3.Text = ax.FName;
                                    //txtAgreeUser3.Text = ax.FName;
                                }
                                if (Session["CurrentUser"].ToString() != "Admin1")
                                {
                                    BtnDelete.Visible = false;
                                    BtnEdit.Visible = false;
                                    ControlsOnOff(false);
                                }
                            }
                        }


                        Jv vJv = new Jv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 102;
                        vJv.LocType = LocType;
                        vJv.LocNumber = short.Parse(vAreaNo);
                        vJv.InvNo = (LocType == 3 ? "00" :"") + myJv.VouLoc.ToString() + "/" + myJv.VouNo.ToString();
                        vJv.DocType = 5;
                        vJv = vJv.findInvNo20(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (vJv != null)
                        {
                            if (vJv.LocType == 2) lblStatus.Text = "تم أدراج المستند في سند الصرف رقم " + @"<a href='WebPay1.aspx?FType=2&Flag=0&AreaNo=" + moh.MakeMask(vJv.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + vJv.Number.ToString() + @"' target='_blank'>" + vJv.LocNumber.ToString() + @"/" + vJv.Number.ToString() + @"</a>" + " ";
                            else lblStatus.Text = "تم أدراج المستند في سند الصرف رقم " + @"<a href='WebPay1.aspx?FType=200&Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + vJv.Number.ToString() + @"' target='_blank'>" + (LocType == 3 ? "00" : "") + vJv.LocNumber.ToString() + @"/" + vJv.Number.ToString() + @"</a>" + " ";
                        }
                        else
                        {
                            vJv = new Jv();
                            vJv.Branch = short.Parse(Session["Branch"].ToString());
                            vJv.FType = 100;
                            vJv.LocType = 1;
                            vJv.LocNumber = short.Parse(vAreaNo);
                            vJv.InvNo = myJv.VouLoc.ToString() + "/" + myJv.VouNo.ToString();
                            vJv.DocType = 5;
                            vJv = vJv.findInvNo20(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (vJv != null)
                            {
                                lblStatus.Text = "تم أدراج المستند في قيد اليومية رقم " + @"<a href='WebJVou.aspx?Flag=0&AreaNo=" + moh.MakeMask(vJv.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + vJv.Number.ToString() + @"' target='_blank'>" + vJv.LocNumber.ToString() + @"/" + vJv.Number.ToString() + @"</a>" + " ";
                            }
                        }




                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم البيان";
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
            try
            {
                BtnSearch_Click(sender, e);
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

        protected void BtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                PrintMe(txtVouNo.Text);
                return;
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

        private bool Saveall(bool Add)
        {
            try
            {
                FastRepair vJv = new FastRepair();
                vJv.Branch = short.Parse(Session["Branch"].ToString());
                vJv.LocType = LocType;
                vJv.VouLoc = short.Parse(vAreaNo);
                vJv.VouNo = int.Parse(txtVouNo.Text);
                vJv.DriverNo = ddlDriver.SelectedValue;
                vJv.CarNo = ddlVehicle.SelectedValue;
                vJv.VouDate = moh.CheckDate(txtVouDate.Text);
                vJv.Am1 = moh.StrToDouble(txtAm1.Text);
                vJv.Am2 = moh.StrToDouble(txtAm2.Text);
                vJv.Am3 = moh.StrToDouble(txtAm3.Text);
                vJv.Am4 = moh.StrToDouble(txtAm4.Text);
                vJv.Am5 = moh.StrToDouble(txtAm5.Text);
                vJv.Am6 = moh.StrToDouble(txtAm6.Text);
                vJv.Am7 = moh.StrToDouble(txtAm7.Text);
                vJv.Am8 = moh.StrToDouble(txtAm8.Text);
                vJv.Am9 = moh.StrToDouble(txtAm9.Text);
                vJv.Am10 = moh.StrToDouble(txtAm10.Text);
                vJv.Am11 = moh.StrToDouble(txtAm11.Text);
                vJv.Am12 = moh.StrToDouble(txtAm12.Text);
                vJv.Am13 = moh.StrToDouble(txtAm13.Text);
                vJv.Am14 = moh.StrToDouble(txtAm14.Text);
                vJv.Am15 = moh.StrToDouble(txtAm15.Text);
                vJv.Am16 = moh.StrToDouble(txtAm16.Text);
                vJv.Am17 = moh.StrToDouble(txtAm17.Text);
                vJv.Am18 = moh.StrToDouble(txtAm18.Text);
                vJv.Am19 = moh.StrToDouble(txtAm19.Text);
                vJv.Am20 = moh.StrToDouble(txtAm20.Text);
                vJv.Am21 = moh.StrToDouble(txtAm21.Text);
                vJv.Am22 = moh.StrToDouble(txtAm22.Text);
                vJv.Am23 = moh.StrToDouble(txtAm23.Text);
                vJv.Am24 = moh.StrToDouble(txtAm24.Text);
                vJv.Am25 = moh.StrToDouble(txtAm25.Text);
                vJv.Am26 = moh.StrToDouble(txtAm26.Text);
                vJv.Am27 = moh.StrToDouble(txtAm27.Text);
                vJv.Am28 = moh.StrToDouble(txtAm28.Text);
                vJv.Am29 = moh.StrToDouble(txtAm29.Text);
                vJv.Am30 = moh.StrToDouble(txtAm30.Text);
                vJv.Am31 = moh.StrToDouble(txtAm31.Text);
                vJv.Am32 = moh.StrToDouble(txtAm32.Text);
                vJv.Am33 = moh.StrToDouble(txtAm33.Text);
                vJv.Am34 = moh.StrToDouble(txtAm34.Text);
                vJv.Tax = moh.StrToDouble(txtTax.Text);

                vJv.InvDate1 = txtInvDate1.Text;
                vJv.InvDate2 = txtInvDate2.Text;
                vJv.InvDate3 = txtInvDate3.Text;
                vJv.InvDate4 = txtInvDate4.Text;
                vJv.InvDate5 = txtInvDate5.Text;
                vJv.InvDate6 = txtInvDate6.Text;
                vJv.InvDate7 = txtInvDate7.Text;
                vJv.InvDate8 = txtInvDate8.Text;
                vJv.InvDate9 = txtInvDate9.Text;
                vJv.InvDate10 = txtInvDate10.Text;
                vJv.InvDate11 = txtInvDate11.Text;
                vJv.InvDate12 = txtInvDate12.Text;
                vJv.InvDate13 = txtInvDate13.Text;
                vJv.InvDate14 = txtInvDate14.Text;
                vJv.InvDate15 = txtInvDate15.Text;
                vJv.InvDate16 = txtInvDate16.Text;
                vJv.InvDate17 = txtInvDate17.Text;
                vJv.InvDate18 = txtInvDate18.Text;
                vJv.InvDate19 = txtInvDate19.Text;
                vJv.InvDate20 = txtInvDate20.Text;
                vJv.InvDate21 = txtInvDate21.Text;
                vJv.InvDate22 = txtInvDate22.Text;
                vJv.InvDate23 = txtInvDate23.Text;
                vJv.InvDate24 = txtInvDate24.Text;
                vJv.InvDate25 = txtInvDate25.Text;
                vJv.InvDate26 = txtInvDate26.Text;
                vJv.InvDate27 = txtInvDate27.Text;
                vJv.InvDate28 = txtInvDate28.Text;
                vJv.InvDate29 = txtInvDate29.Text;
                vJv.InvDate30 = txtInvDate30.Text;
                vJv.InvDate31 = txtInvDate31.Text;
                vJv.InvDate32 = txtInvDate32.Text;
                vJv.InvDate33 = txtInvDate33.Text;
                vJv.InvDate34 = txtInvDate34.Text;

                vJv.InvNo1 = txtInvNo1.Text;
                vJv.InvNo2 = txtInvNo2.Text;
                vJv.InvNo3 = txtInvNo3.Text;
                vJv.InvNo4 = txtInvNo4.Text;
                vJv.InvNo5 = txtInvNo5.Text;
                vJv.InvNo6 = txtInvNo6.Text;
                vJv.InvNo7 = txtInvNo7.Text;
                vJv.InvNo8 = txtInvNo8.Text;
                vJv.InvNo9 = txtInvNo9.Text;
                vJv.InvNo10 = txtInvNo10.Text;
                vJv.InvNo11 = txtInvNo11.Text;
                vJv.InvNo12 = txtInvNo12.Text;
                vJv.InvNo13 = txtInvNo13.Text;
                vJv.InvNo14 = txtInvNo14.Text;
                vJv.InvNo15 = txtInvNo15.Text;
                vJv.InvNo16 = txtInvNo16.Text;
                vJv.InvNo17 = txtInvNo17.Text;
                vJv.InvNo18 = txtInvNo18.Text;
                vJv.InvNo19 = txtInvNo19.Text;
                vJv.InvNo20 = txtInvNo20.Text;
                vJv.InvNo21 = txtInvNo21.Text;
                vJv.InvNo22 = txtInvNo22.Text;
                vJv.InvNo23 = txtInvNo23.Text;
                vJv.InvNo24 = txtInvNo24.Text;
                vJv.InvNo25 = txtInvNo25.Text;
                vJv.InvNo26 = txtInvNo26.Text;
                vJv.InvNo27 = txtInvNo27.Text;
                vJv.InvNo28 = txtInvNo28.Text;
                vJv.InvNo29 = txtInvNo29.Text;
                vJv.InvNo30 = txtInvNo30.Text;
                vJv.InvNo31 = txtInvNo31.Text;
                vJv.InvNo32 = txtInvNo32.Text;
                vJv.InvNo33 = txtInvNo33.Text;
                vJv.InvNo34 = txtInvNo34.Text;

                vJv.InvQty1 = txtInvQty1.Text;
                vJv.InvQty2 = txtInvQty2.Text;
                vJv.InvQty3 = txtInvQty3.Text;
                vJv.InvQty4 = txtInvQty4.Text;
                vJv.InvQty5 = txtInvQty5.Text;
                vJv.InvQty6 = txtInvQty6.Text;
                vJv.InvQty7 = txtInvQty7.Text;
                vJv.InvQty8 = txtInvQty8.Text;
                vJv.InvQty9 = txtInvQty9.Text;
                vJv.InvQty10 = txtInvQty10.Text;
                vJv.InvQty11 = txtInvQty11.Text;
                vJv.InvQty12 = txtInvQty12.Text;
                vJv.InvQty13 = txtInvQty13.Text;
                vJv.InvQty14 = txtInvQty14.Text;
                vJv.InvQty15 = txtInvQty15.Text;
                vJv.InvQty16 = txtInvQty16.Text;
                vJv.InvQty17 = txtInvQty17.Text;
                vJv.InvQty18 = txtInvQty18.Text;
                vJv.InvQty19 = txtInvQty19.Text;
                vJv.InvQty20 = txtInvQty20.Text;
                vJv.InvQty21 = txtInvQty21.Text;
                vJv.InvQty22 = txtInvQty22.Text;
                vJv.InvQty23 = txtInvQty23.Text;
                vJv.InvQty24 = txtInvQty24.Text;
                vJv.InvQty25 = txtInvQty25.Text;
                vJv.InvQty26 = txtInvQty26.Text;
                vJv.InvQty27 = txtInvQty27.Text;
                vJv.InvQty28 = txtInvQty28.Text;
                vJv.InvQty29 = txtInvQty29.Text;
                vJv.InvQty30 = txtInvQty30.Text;
                vJv.InvQty31 = txtInvQty31.Text;
                vJv.InvQty32 = txtInvQty32.Text;
                vJv.InvQty33 = txtInvQty33.Text;
                vJv.InvQty34 = txtInvQty34.Text;

                vJv.JobOrder = moh.StrToInt(txtJobOrder.Text);
                vJv.Remark = txtRemark.Text;                
                vJv.UserName = txtUserName.ToolTip;
                vJv.UserDate = txtUserDate.Text;
                bool vret = false;
                if (Add)
                {
                    if(vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                       Acc myAcc = new Acc();
                       myAcc.Branch = short.Parse(Session["Branch"].ToString());
                       myAcc.Code = "1101"+ddlVehicle.SelectedValue;
                       if(myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                       {
                           vret = vJv.Post(myAcc.Area,myAcc.Project,"00017","00002",WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                       }
                    }                    
                }
                else
                {
                    if (vJv.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        Jv myJv = new Jv();
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.FType = 801;
                        myJv.LocType = LocType;
                        myJv.LocNumber = short.Parse(vAreaNo);
                        myJv.Number = int.Parse(txtVouNo.Text);
                        myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        Acc myAcc = new Acc();
                        myAcc.Branch = short.Parse(Session["Branch"].ToString());
                        myAcc.Code = "1101" + ddlVehicle.SelectedValue;
                        if (myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            vret = vJv.Post(myAcc.Area, myAcc.Project, "00017", "00002", WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                    }
                }
                return vret;
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
                        myArch.LocNumber = short.Parse(vAreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = (LocType == 2 ? 700 : 701);

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(vAreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = (LocType == 2 ? 700 : 701);
                        myArch.FileName = FileUpload1.FileName;
                        myArch.FileName2 = mySetting.ImagePath2 + FileName;
                        myArch.FNo = (short)i;
                        myArch.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        if (myArch.FileName.Contains("الفحص الدوري"))
                        {
                            myArch = new Arch();
                            myArch.Branch = short.Parse(Session["Branch"].ToString());
                            myArch.LocNumber = 0;
                            myArch.Number = int.Parse(txtCarNo.Text);
                            myArch.DocType = 999;

                            i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (i == null) i = 1;
                            else i++;

                            myArch = new Arch();
                            myArch.Branch = short.Parse(Session["Branch"].ToString());
                            myArch.LocNumber = 0;
                            myArch.Number = int.Parse(txtCarNo.Text);
                            myArch.DocType = 999;
                            myArch.FileName = FileUpload1.FileName;
                            myArch.FileName2 = mySetting.ImagePath2 + FileName;
                            myArch.FNo = (short)i;
                            myArch.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }

                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان اصلاح خارجي", "اضافة مرفقات", "اضافة مرفقات لبيان اصلاح خارجي رقم " + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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
                myArch.LocNumber = short.Parse(vAreaNo);
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = (LocType == 2 ? 700 : 701);
                myArch.FNo = short.Parse(FNo);
                myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان اصلاح خارجي", "الغاء مرفقات", "الغاء مرفقات لبيان اصلاح خارجي رقم " + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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
                myArch.LocNumber = short.Parse(vAreaNo);
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = (LocType == 2 ? 700 : 701);
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

        protected void txtAm1_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = string.Format("{0:N2}", moh.StrToDouble(txtAm1.Text) + moh.StrToDouble(txtAm2.Text) + moh.StrToDouble(txtAm3.Text) + moh.StrToDouble(txtAm4.Text) + moh.StrToDouble(txtAm5.Text) + moh.StrToDouble(txtAm6.Text) + moh.StrToDouble(txtAm7.Text) + moh.StrToDouble(txtAm8.Text) + moh.StrToDouble(txtAm9.Text) + moh.StrToDouble(txtAm10.Text) + moh.StrToDouble(txtAm11.Text) + moh.StrToDouble(txtAm12.Text) + moh.StrToDouble(txtAm13.Text) + moh.StrToDouble(txtAm14.Text) + moh.StrToDouble(txtAm15.Text) + moh.StrToDouble(txtAm16.Text) + moh.StrToDouble(txtAm17.Text) + moh.StrToDouble(txtAm18.Text) + moh.StrToDouble(txtAm19.Text) + moh.StrToDouble(txtAm20.Text) + moh.StrToDouble(txtAm21.Text) + moh.StrToDouble(txtAm22.Text) + moh.StrToDouble(txtAm23.Text) + moh.StrToDouble(txtAm24.Text) + moh.StrToDouble(txtAm25.Text) + moh.StrToDouble(txtAm26.Text) + moh.StrToDouble(txtAm27.Text) + moh.StrToDouble(txtAm28.Text) + moh.StrToDouble(txtAm29.Text) + moh.StrToDouble(txtAm30.Text) + moh.StrToDouble(txtAm31.Text) + moh.StrToDouble(txtAm32.Text) + moh.StrToDouble(txtAm33.Text) + moh.StrToDouble(txtAm34.Text) + moh.StrToDouble(txtTax.Text));
        }

        protected void ddlVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlVehicle.SelectedIndex > 0)
                {
                    Cars myCar = new Cars();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myCar.Code = ddlVehicle.SelectedValue;
                    myCar.CarsType = int.Parse(ddlVehicle.SelectedValue.Substring(0, 2));
                    myCar = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                             where sitm.Code == myCar.Code
                             select sitm).FirstOrDefault();
                    if (myCar != null)
                    {
                        txtCarNo.Text = myCar.Code;
                        if (myCar.DriverCode != "-1") ddlDriver.SelectedValue = myCar.DriverCode;
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

        protected void txtCarNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cars myCar = new Cars();
                myCar.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myCar.Code = moh.MakeMask(txtCarNo.Text, 5);
                myCar = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                         where sitm.Code == myCar.Code
                         select sitm).FirstOrDefault();
                if (myCar != null)
                {
                    ddlVehicle.SelectedValue = myCar.Code;
                    ddlVehicle_SelectedIndexChanged(sender, e);
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

        protected void ddlDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDriver.SelectedIndex > 0)
                {
                    Cars myCar = new Cars();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myCar.DriverCode = ddlDriver.SelectedValue;
                    myCar = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                             where sitm.DriverCode == myCar.DriverCode && (bool)sitm.Status
                             select sitm).FirstOrDefault();
                    if (myCar != null)
                    {
                        txtCarNo.Text = myCar.Code;
                        ddlVehicle.SelectedValue = myCar.Code;
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

        public void PrintMe(String Number)
        {
            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان اصلاح خارجي", "طباعة", "طباعة بيانات بيان اصلاح خارجي رقم " + Number, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=801&LocType=" + LocType.ToString() + "&LocNumber=" + short.Parse(vAreaNo).ToString() + "&Number=" + Number + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
            return;
        }

        protected void ChkRep_CheckedChanged(object sender, EventArgs e)
        {
            ChkFix.Checked = !ChkRep.Checked;
        }

        protected void ChkFix_CheckedChanged(object sender, EventArgs e)
        {
            ChkRep.Checked = !ChkFix.Checked;
        }

        protected void chkAgree1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAgree1.Checked)
                {
                    txtAgreeUser1.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser1.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate1.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Agreement myAgree = new Agreement();
                    myAgree.FType = 801;
                    myAgree.LocType = LocType;
                    myAgree.LocNumber = short.Parse(vAreaNo);
                    myAgree.Number = int.Parse(txtVouNo.Text);
                    myAgree.FNo = 1;
                    myAgree.Agree = 1;
                    myAgree.AgreeRemark = txtAgreeRemark1.Text;
                    myAgree.AgreeUser = txtAgreeUser1.ToolTip;
                    myAgree.AgreeUserDate = txtAgreeUserDate1.Text;
                    if (myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "تم اعتماد المستند بنجاح";

                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.Description = "أعتماد بيان الاصلاح الخارجي رقم  " + lblBranch2.Text + "/" + txtVouNo.Text;
                        UserTran.FormAction = "أعتماد";
                        UserTran.FormName = "بيان اصلاح خارجي";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, true), true);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "خطأ أثناء تعميد المستند ... حاول مرة أخرى";
                    }
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }

        }

        protected void chkAgree2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAgree2.Checked)
                {
                    txtAgreeUser2.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser2.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate2.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Agreement myAgree = new Agreement();
                    myAgree.FType = 801;
                    myAgree.LocType = LocType;
                    myAgree.LocNumber = short.Parse(vAreaNo);
                    myAgree.Number = int.Parse(txtVouNo.Text);
                    myAgree.FNo = 2;
                    myAgree.Agree = 1;
                    myAgree.AgreeRemark = txtAgreeRemark2.Text;
                    myAgree.AgreeUser = txtAgreeUser2.ToolTip;
                    myAgree.AgreeUserDate = txtAgreeUserDate2.Text;
                    if (myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "تم اعتماد المستند بنجاح";

                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.Description = "أعتماد بيان الاصلاح الخارجي رقم  " + lblBranch2.Text + "/" + txtVouNo.Text;
                        UserTran.FormAction = "أعتماد";
                        UserTran.FormName = "بيان اصلاح خارجي";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, true), true);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "خطأ أثناء تعميد المستند ... حاول مرة أخرى";
                    }
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void chkAgree3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAgree3.Checked)
                {
                    txtAgreeUser3.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser3.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate3.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Agreement myAgree = new Agreement();
                    myAgree.FType = 801;
                    myAgree.LocType = LocType;
                    myAgree.LocNumber = short.Parse(vAreaNo);
                    myAgree.Number = int.Parse(txtVouNo.Text);
                    myAgree.FNo = 3;
                    myAgree.Agree = 1;
                    myAgree.AgreeRemark = txtAgreeRemark3.Text;
                    myAgree.AgreeUser = txtAgreeUser3.ToolTip;
                    myAgree.AgreeUserDate = txtAgreeUserDate3.Text;
                    if (myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "تم اعتماد المستند بنجاح";

                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.Description = "أعتماد بيان الاصلاح الخارجي رقم  " + lblBranch2.Text + "/" + txtVouNo.Text;
                        UserTran.FormAction = "أعتماد";
                        UserTran.FormName = "بيان اصلاح خارجي";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, true), true);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "خطأ أثناء تعميد المستند ... حاول مرة أخرى";
                    }
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void txtJobOrder_TextChanged(object sender, EventArgs e)
        {
            CheckRef();
        }            


        public bool CheckRef()
        {
            JobWork myJv = new JobWork();
            myJv.Branch = short.Parse(Session["Branch"].ToString());
            myJv.VouLoc = short.Parse(StoreNo);
            myJv.VouNo = int.Parse(txtJobOrder.Text);
            myJv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myJv == null)
            {
                txtJobOrder.Text = "";
                txtCarNo.Text = "";
                ddlVehicle.SelectedIndex = 0;

                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "رقم بيان التشغيل غير معرف من قبل";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }
            else
            {
                if (myJv.Status != 0)
                {
                    txtJobOrder.Text = "";
                    txtCarNo.Text = "";
                    ddlVehicle.SelectedIndex = 0;

                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "حالة بيان التشغيل غير مفتوح للصرف";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    return false;
                }
                else
                {
                    txtCarNo.Text = myJv.CarNo;
                    ddlVehicle.SelectedValue = myJv.CarNo;
                    ddlVehicle_SelectedIndexChanged(ddlVehicle, null);
                    return true;
                }
            }
        }
    }
}
