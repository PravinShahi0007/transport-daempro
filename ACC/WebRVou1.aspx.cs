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
using System.Web.Script.Serialization;

namespace ACC
{
    public partial class WebRVou1 : System.Web.UI.Page
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

            BtnPrint.Visible = true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass245;
            BtnEdit.Visible = true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass242;
            BtnNew.Visible = false;
            BtnDelete.Visible = true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass243;

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
            if (!BtnEdit.Visible) ControlsOnOff(false);
        }

        public void NewMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;
            //txtVouNo.ReadOnly = false;
            //txtVouNo.BackColor = System.Drawing.Color.White;

            BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass241;
            BtnDelete.Visible = false;
            if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass242) ControlsOnOff(true);
        }


        //private bool IsPageRefresh = false;
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (Page.IsPostBack)
        //    {
        //        if (ViewState["postid"].ToString() != Session["postid"].ToString())
        //            IsPageRefresh = true;
        //    }
        //    Session["postid"] = System.Guid.NewGuid().ToString();
        //    ViewState["postid"] = Session["postid"];
        //}

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
                    this.Page.Header.Title = "سندات القبض";
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


                    lblBranch2.Text = "/" + short.Parse(AreaNo).ToString();
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

                    Cars myCar = new Cars();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlCarNo.DataTextField = "PlateNo";
                    ddlCarNo.DataValueField = "Code";
                    ddlCarNo.DataSource = (from itm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                           where itm.CarsType == myCar.CarsType && (bool)itm.Status
                                           select itm).ToList();
                    ddlCarNo.DataBind();
                    ddlCarNo.Items.Insert(0, new ListItem("--- أختار الشاحنة---", "-1", true));

                    ddlEmp.Items.Insert(0, new ListItem("--- أختار الموظف---", "-1", true));

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
                    BtnNew.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass241;
                    BtnEdit.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass242;
                    BtnDelete.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass243;
                    BtnSearch.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass244;
                    BtnFind.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass244;
                    BtnPrint.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass245;

                    if (Request.QueryString["Flag"] != null)
                    {
                        if (Request.QueryString["Flag"].ToString() == "1" || Request.QueryString["Flag"].ToString() == "0")
                        {
                            ddlArea.Enabled = false;
                            ddlCostAcc.Enabled = false;
                            ddlCostCenter.Enabled = false;
                            ddlDbCode.Enabled = false;
                            ddlProject.Enabled = false;
                            ddlCarNo.Enabled = false;
                        }
                        else
                        {
                            ddlArea.Enabled = true;
                            ddlCostAcc.Enabled = true;
                            ddlCostCenter.Enabled = true;
                            ddlDbCode.Enabled = true;
                            ddlProject.Enabled = true;
                            ddlCarNo.Enabled = true;
                        }
                    }

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
                        }
                        txtSearch.Text = Request.QueryString["FNum"].ToString();
                        BtnSearch_Click(sender, null);
                    }
                    else
                    {
                        BtnClear_Click(sender, null);
                        if (Request.QueryString["Claim"] != null)
                        {
                            ddlClaim.SelectedValue = Request.QueryString["Claim"].ToString();
                            ddlClaim_SelectedIndexChanged(sender, e);
                            rdoPayment.SelectedValue = "1";
                            rdoPayment_SelectedIndexChanged(sender, e);
                        }
                        else if (Request.QueryString["InvNo"] != null)
                        {
                            Invoice myInv = new Invoice();
                            myInv.Branch = short.Parse(Session["Branch"].ToString());
                            myInv.VouLoc = moh.MakeMask(Request.QueryString["InvNo"].ToString().Split('/')[0], 5);
                            myInv.VouNo = int.Parse(Request.QueryString["InvNo"].ToString().Split('/')[1]);
                            myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myInv == null)
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "رقم الفاتورة غير مدرج من قبل";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }

                            //if()   سند القبض للمنطقة
                            //{                    
                            //}

                            Cities myCity = new Cities();
                            myCity.Branch = short.Parse(Session["Branch"].ToString());
                            myCity.Code = myInv.Destination;
                            if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                            myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                      where sitm.Code == myCity.Code
                                      select sitm).FirstOrDefault();
                            if (myCity == null)
                            {
                                grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "رقم الفاتورة غير مدرج من قبل";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }

                            if (myInv.CustomerAmount == 0 && myInv.SiteAmount == 0)
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لا يوجد مبالغ مستحقة على هذه الفاتورة";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }

                            Jv vJv = new Jv();
                            vJv.Branch = short.Parse(Session["Branch"].ToString());
                            vJv.FType = 101;
                            vJv.LocType = 2;
                            vJv.LocNumber = short.Parse(AreaNo);
                            vJv.InvNo = Request.QueryString["InvNo"].ToString();
                            vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (vJv != null)
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "الفاتورة تم ادخالها من قبل في السند رقم " + vJv.LocNumber.ToString() + "/" + vJv.Number.ToString();
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;

                                //if ((myInv.SiteAmount > 0 && vJv.Amount == (double)myInv.SiteAmount) || (myInv.CustomerAmount > 0 && vJv.Amount == (double)myInv.CustomerAmount))
                                //{
                                //}
                            }

                            InvDetails Inv = new InvDetails();
                            Inv.Branch = short.Parse(Session["Branch"].ToString());
                            Inv.VouLoc = moh.MakeMask(Request.QueryString["InvNo"].ToString().Split('/')[0], 5);
                            Inv.VouNo = int.Parse(Request.QueryString["InvNo"].ToString().Split('/')[1]);
                            Inv.FNo = 1;
                            Inv = Inv.GetFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            if (Inv != null)
                            {
                                if (myInv.SiteAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv.VouNo, InvoiceVouLoc = myInv.VouLoc, Name = myInv.RecName, Amount = myInv.SiteAmount, PlateNo = Inv.PlateNo, Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = myInv.Site, Customer = myInv.Customer, SiteAmount = myInv.SiteAmount, CustomerAmount = 0 });
                                if (myInv.CustomerAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv.VouNo, InvoiceVouLoc = myInv.VouLoc, Name = myInv.RecName, Amount = myInv.CustomerAmount, PlateNo = Inv.PlateNo, Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = "-1", Customer = myInv.Customer, CustomerAmount = myInv.CustomerAmount, SiteAmount = 0 });
                            }
                            else
                            {
                                if (myInv.SiteAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv.VouNo, InvoiceVouLoc = myInv.VouLoc, Name = myInv.RecName, Amount = myInv.SiteAmount, PlateNo = myInv.PlateNo.Replace('@', '-'), Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = myInv.Site, Customer = myInv.Customer, SiteAmount = myInv.SiteAmount, CustomerAmount = 0 });
                                if (myInv.CustomerAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv.VouNo, InvoiceVouLoc = myInv.VouLoc, Name = myInv.RecName, Amount = myInv.CustomerAmount, PlateNo = myInv.PlateNo.Replace('@', '-'), Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = "-1", Customer = myInv.Customer, CustomerAmount = myInv.CustomerAmount, SiteAmount = 0 });
                            }
                            MakeSum();
                            LoadVouData();
                        }
                    }
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

        public void ControlsOnOff(bool State)
        {
            txtVouDate.ReadOnly = !State;
            rdoPayment.Enabled = State;
            CalendarExtender1.Enabled = State;
            CalendarExtender2.Enabled = State;
            txtAmount.ReadOnly = (rdoType.SelectedValue == "0" || rdoType.SelectedValue == "2");
            txtShAmount.ReadOnly = !State;
            txtCashAmount.ReadOnly = !State;
            txtRemark.ReadOnly = !State;
            txtBankName.ReadOnly = !State;
            txtchqNo.ReadOnly = !State;
            txtChqDate.ReadOnly = !State;
            txtDiscount.ReadOnly = !State;
            rdoType.Enabled = State;
            ChkCheque.Enabled = State;
            //grdAttach.Enabled = State;
            foreach (GridViewRow itm in grdAttach.Rows)
            {
                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                if (BtnDelete != null) BtnDelete.Visible = State;
            }
            grdCodes.Enabled = State;
            FileUpload1.Enabled = State;
            BtnAttach.Enabled = State;
            txtPerson.Enabled = State;
            txtCust.Enabled = State;
            txtLand.Enabled = State;
            txtOthers.Enabled = State;
            ChkShAmount.Enabled = State;
            ChkCashAmount.Enabled = State;
        }

        protected void BtnClear_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Claim myClaim = new Claim();
                //myClaim.DocLoc = short.Parse(AreaNo);
                myClaim.DocLoc = -1;
                if (Cache["ClaimPending" + Session["CNN2"].ToString()] == null)
                {
                    myClaim.DocLoc = -1;
                    Cache.Insert("ClaimPending" + Session["CNN2"].ToString(), myClaim.GetPending(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                }

                ddlClaim.DataTextField = "DocNo";
                ddlClaim.DataValueField = "DocNo";
                ddlClaim.DataSource = (from itm in (List<Claim>)(Cache["ClaimPending" + Session["CNN2"].ToString()])
                                       select itm).ToList();
                ddlClaim.DataBind();
                ddlClaim.Items.Insert(0, new ListItem("--- أختار المطالبة ---", "-1", true));
                //ddlClaim.SelectedIndex = 0;
                NewMode();
                rdoPayment.SelectedIndex = 0;
                rdoPayment_SelectedIndexChanged(sender, e);
                txtVouDate.Text = "";
                txtSearch.Text = "";
                txtAmount.Text = "";
                txtShAmount.Text = "";
                txtCashAmount.Text = "";
                txtRemark.Text = "";
                txtBankName.Text = "";
                txtchqNo.Text = "";
                txtChqDate.Text = "";
                txtDiscount.Text = "";
                txtNet.Text = "";
                txtPerson.Text = "";
                txtLand.Text = "";
                txtOthers.Text = "";
                txtCust.Text = "";
                rdoType.SelectedIndex = 0;
                rdoType_SelectedIndexChanged(sender, e);
                ChkCheque.Checked = false;
                ChkCheque_CheckedChanged(sender, e);
                ChkShAmount.Checked = false;
                ChkCashAmount.Checked = false;
                if(ddlArea.Enabled) ddlArea.SelectedIndex = 0;
                if (ddlCostAcc.Enabled) ddlCostAcc.SelectedIndex = 0;
                if (ddlCostCenter.Enabled) ddlCostCenter.SelectedIndex = 0;
                if(ddlDbCode.Enabled) ddlDbCode.SelectedIndex = 0;
                if (ddlProject.Enabled) ddlProject.SelectedIndex = 0;
                if (ddlCarNo.Enabled) ddlCarNo.SelectedIndex = 0;

                ddlArea.SelectedValue = SiteInfo.Area;
                ddlCostCenter.SelectedValue = SiteInfo.Code;
                ddlProject.SelectedValue = SiteInfo.Project;
                ddlDbCode.SelectedValue = SiteInfo.CashAcc;

                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                if (sender != null)
                {
                    txtVouNo.Text = "";
                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 101;
                    myJv.LocType = 2;
                    myJv.LocNumber = short.Parse(AreaNo);
                    int? i = myJv.GetNewNumber(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (i == 0 || i == null)
                    {
                        i = myJv.FType == 101 ? SiteInfo.RecNo : SiteInfo.PayNo;
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

        protected void LoadVouData()
        {
            try
            {
                grdCodes.DataSource = VouData;
                grdCodes.DataBind();
                if (grdCodes.Rows.Count < 1)
                {
                    myInv2 inv = new myInv2();
                    List<myInv2> Listax = new List<myInv2>();
                    Listax.Add(inv);
                    grdCodes.DataSource = Listax;
                    grdCodes.DataBind();
                    grdCodes.Rows[0].Cells.Clear();
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
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }
                    }

                    BtnNew.Enabled = false;
                    ValidateNum();
                    // MakeSum();
                    if (moh.StrToDouble(txtNet.Text) != (moh.StrToDouble(txtCashAmount.Text) + moh.StrToDouble(txtShAmount.Text)))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "المبلغ المحصل لا يساوي المبلغ المستحق";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }


                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 101;
                    myJv.LocType = 2;
                    myJv.LocNumber = short.Parse(AreaNo);
                    myJv.Number = int.Parse(txtVouNo.Text);                      
                    myJv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myJv != null)
                    {
                        if (myJv.UserName == txtUserName.ToolTip)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم السند مكرر";
                            BtnNew.Enabled = true;
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                        else
                        {
                            myJv = new Jv();
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.FType = 101;
                            myJv.LocType = 2;
                            myJv.LocNumber = short.Parse(AreaNo);
                            int? i = myJv.GetNewNumber(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (i == 0 || i == null)
                            {
                                i = myJv.FType == 101 ? SiteInfo.RecNo : SiteInfo.PayNo;
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
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                        if (rdoType.SelectedValue == "0" || rdoType.SelectedValue == "2") DeletemyCookie();
                        string vNumber = txtVouNo.Text;
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        BtnClear_Click(sender, e);
                        BtnNew.Enabled = true;
                        PrintMe(vNumber);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        BtnNew.Enabled = true;
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
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
                    ValidateNum();

                    if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    {
                        if (DateTime.Parse(txtVouDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }
                    }
                   // MakeSum();
                    if (moh.StrToDouble(txtNet.Text) != (moh.StrToDouble(txtCashAmount.Text) + moh.StrToDouble(txtShAmount.Text)))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "المبلغ المحصل لا يساوي المبلغ المستحق";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    List<Jv> ljv = new List<Jv>();
                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 101;
                    myJv.LocType = 2;
                    myJv.LocNumber = short.Parse(AreaNo);
                    myJv.Number = int.Parse(txtVouNo.Text);
                    ljv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (ljv == null || ljv.Count() == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم السند غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    }
                    else
                    {
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.FType = 101;
                        myJv.LocType = 2;
                        myJv.LocNumber = short.Parse(AreaNo);
                        myJv.Number = int.Parse(txtVouNo.Text);
                        if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (ljv[0].Claim > 0)
                            {
                                foreach (Jv itm in ljv)
                                {
                                    if (itm.Claim > 0 && itm.InvNo != "")
                                    {
                                        Claim myClaim = new Claim();
                                        if (itm.VouNo2.Split('/').Count() < 2)
                                        {
                                            myClaim.Flag = "";
                                            myClaim.InvLoc = 0;
                                            myClaim.InvNo = int.Parse(itm.VouNo2);
                                        }
                                        else
                                        {
                                            string vVouNo2 = (itm.VouNo2[0] == 'L' || itm.VouNo2[0] == 'E' ? itm.VouNo2.Substring(1, itm.VouNo2.Length - 1) : itm.VouNo2);
                                            myClaim.InvLoc = short.Parse(vVouNo2.Split('/')[0]);
                                            myClaim.InvNo = int.Parse(vVouNo2.Split('/')[1]);
                                            myClaim.Flag = (itm.VouNo2[0] == 'L' || itm.VouNo2[0] == 'E' ? itm.VouNo2.Substring(0, 1) : "");
                                        }
                                        myClaim = myClaim.GetByInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if (myClaim != null)
                                        {
                                            myClaim.State = false;
                                            myClaim.UpdateState(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                                            {
                                                Transactions UserTran = new Transactions();
                                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                                UserTran.UserName = Session["CurrentUser"].ToString();
                                                UserTran.FormName = "المطالبة المالية";
                                                UserTran.FormAction = "الغاء";
                                                UserTran.Description = " الغاء سداد المطالبة المالية رقم " + myClaim.InvNo.ToString();
                                                UserTran.IP = IPNetworking.GetIP4Address();
                                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                            }

                                        }
                                    }
                                }
                                UpdateCache();
                            }
                            if (Saveall())
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                                if (rdoType.SelectedValue == "0" || rdoType.SelectedValue == "2") DeletemyCookie();
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
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            }
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ أثناء تعديل البيانات ... حاول مرة أخرى";
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
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }
                    }

                    List<Jv> ljv = new List<Jv>();
                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 101;
                    myJv.LocType = 2;
                    myJv.LocNumber = short.Parse(AreaNo);
                    myJv.Number = int.Parse(txtVouNo.Text);
                    ljv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (ljv == null || ljv.Count() == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم السند غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    }
                    else
                    {
                        if (ljv[0].Claim > 0)
                        {
                            foreach (Jv itm in ljv)
                            {
                                if (itm.Claim > 0 && itm.InvNo != "" )
                                {
                                    Claim myClaim = new Claim();
                                    if (itm.VouNo2.Split('/').Count() < 2)
                                    {
                                        myClaim.Flag = "";
                                        myClaim.InvLoc = 0;
                                        myClaim.InvNo = int.Parse(itm.VouNo2);
                                    }
                                    else
                                    {
                                        string vVouNo2 = (itm.VouNo2[0] == 'L' || itm.VouNo2[0] == 'E' ? itm.VouNo2.Substring(1, itm.VouNo2.Length - 1) : itm.VouNo2);
                                        myClaim.InvLoc = short.Parse(vVouNo2.Split('/')[0]);
                                        myClaim.InvNo = int.Parse(vVouNo2.Split('/')[1]);
                                        myClaim.Flag = (itm.VouNo2[0] == 'L' || itm.VouNo2[0] == 'E' ? itm.VouNo2.Substring(0, 1) : "");
                                    }
                                    myClaim = myClaim.GetByInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (myClaim != null)
                                    {
                                        myClaim.State = false;
                                        myClaim.UpdateState(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                                        {
                                            Transactions UserTran = new Transactions();
                                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                            UserTran.UserName = Session["CurrentUser"].ToString();
                                            UserTran.FormName = "المطالبة المالية";
                                            UserTran.FormAction = "الغاء";
                                            UserTran.Description = " الغاء سداد المطالبة المالية رقم " + myClaim.InvNo.ToString();
                                            UserTran.IP = IPNetworking.GetIP4Address();
                                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                        }
                                    }
                                }                                
                            }
                            UpdateCache();
                        }
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.FType = 101;
                        myJv.LocType = 2;
                        myJv.LocNumber = short.Parse(AreaNo);
                        myJv.Number = int.Parse(txtVouNo.Text);
                        if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormAction = "الغاء";
                            UserTran.FormName = "سند القبض";
                            UserTran.Description = "الغاء بيانات سند القبض رقم " + txtVouNo.Text;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);


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

                        List<vJv> lJv = new List<vJv>();
                        Jv myJv = new Jv();
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.FType = 101;
                        myJv.LocType = 2;
                        myJv.LocNumber = short.Parse(AreaNo);
                        myJv.Number = int.Parse(txtSearch.Text);
                        BtnClear_Click(null, e);
                        lJv = myJv.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (lJv == null || lJv.Count == 0)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم السند غير معرف من قبل";                            
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        }
                        else
                        {
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

                            rdoPayment.SelectedValue = lJv[0].Payment.ToString();
                            rdoPayment_SelectedIndexChanged(sender, e);

                            ddlDbCode.SelectedValue = lJv[0].DbCode;
                            txtBankName.Text = lJv[0].BankName;
                            txtChqDate.Text = lJv[0].ChequeDate;
                            txtchqNo.Text = lJv[0].ChequeNo;
                            txtAmount.Text = string.Format("{0:N2}", lJv[0].Amount);
                            txtRemark.Text = lJv[0].Remark;
                            txtPerson.Text = lJv[0].Person;                            
                            ChkCheque.Checked = false;
                            if (txtBankName.Text != "" || txtChqDate.Text != "" || txtchqNo.Text != "") ChkCheque.Checked = true;
                            ChkCheque_CheckedChanged(sender, e);
                            rdoType.SelectedIndex = (int)lJv[0].DocType;
                            rdoType_SelectedIndexChanged(sender, e);

                            //ddlArea.SelectedValue = lJv[1].Area;
                            //ddlCostAcc.SelectedValue = lJv[1].CostAcc;
                            //ddlCostCenter.SelectedValue = lJv[1].CostCenter;
                            //ddlEmp.SelectedValue = lJv[1].EmpCode;
                            //ddlProject.SelectedValue = lJv[1].Project;
                            //ddlCarNo.SelectedValue = lJv[1].CarNo;

                            if (lJv[0].Claim > 0)
                            {
                                ddlClaim.Items.Clear();
                                ddlClaim.Items.Add(new ListItem(lJv[0].Claim.ToString(),lJv[0].Claim.ToString()));
                                ddlClaim.Items.Insert(0, new ListItem("--- أختار المطالبة ---", "-1", true));
                                ddlClaim.SelectedValue = lJv[0].Claim.ToString();
                            }

                            int start = 0;
                            for (int i = start; i < lJv.Count(); i++)
                            {
                                if (lJv[i].DbCode != "")
                                {
                                    if (lJv[i].DbCode == SiteInfo.CashAcc) txtCashAmount.Text = string.Format("{0:N2}", lJv[i].Amount);
                                    else if (lJv[i].DbCode == moh.MadaAcc) txtShAmount.Text = string.Format("{0:N2}", lJv[i].Amount);
                                    else if (lJv[i].DbCode == SiteInfo.DiscountAcc) txtDiscount.Text = string.Format("{0:N2}", lJv[i].Amount);
                                    else if (lJv[i].DbCode == "310102027") txtShAmount.Text = string.Format("{0:N2}", moh.StrToDouble(txtShAmount.Text) + lJv[i].Amount);                                    
                                }
                                else
                                {
                                    start = i;
                                    break;
                                }
                            }

                            txtAmount.Text = string.Format("{0:N2}", moh.StrToDouble(txtCashAmount.Text) + moh.StrToDouble(txtDiscount.Text) + moh.StrToDouble(txtShAmount.Text));

                            if (rdoType.SelectedIndex == 0 || rdoType.SelectedIndex == 2)
                            {
                                VouData.Clear();
                                for (int i = start; i < lJv.Count(); i++)
                                {
                                    if (lJv[i].CrCode != "" && lJv[i].CrCode == SiteInfo.LateAcc)
                                    {
                                        txtLand.Text = string.Format("{0:N2}", lJv[i].Amount);
                                        txtAmount.Text = string.Format("{0:N2}", moh.StrToDouble(txtAmount.Text) - lJv[i].Amount);
                                        continue;
                                    }
                                    if (lJv[i].CrCode != "" && lJv[i].CrCode == SiteInfo.InComeAcc)  // إيرادات التشغيل
                                    {
                                        txtOthers.Text = string.Format("{0:N2}", lJv[i].Amount);
                                        txtAmount.Text = string.Format("{0:N2}", moh.StrToDouble(txtAmount.Text) - lJv[i].Amount);
                                        continue;
                                    }
                                    else if (lJv[i].InvNo == "" && lJv[i].CrCode != "" && (lJv[i].CrCode == VouData[VouData.Count() - 1].Customer || lJv[i].CrCode == "240201001"))
                                    {
                                        txtCust.Text = string.Format("{0:N2}", lJv[i].Amount);
                                        txtAmount.Text = string.Format("{0:N2}", moh.StrToDouble(txtAmount.Text) - lJv[i].Amount);
                                        continue;
                                    }


                                    if (lJv[i].InvNo.Split('/').Count() < 2 || lJv[i].InvNo.StartsWith("0/"))
                                    {
                                        Jv mJv = new Jv();
                                        mJv.Branch = short.Parse(Session["Branch"].ToString());
                                        mJv.FType = 100;
                                        mJv.LocNumber = 1;
                                        mJv.LocType = 1;
                                        mJv.Number = (lJv[i].InvNo.Split('/').Count() < 2 ? int.Parse(lJv[i].InvNo) : int.Parse(lJv[i].InvNo.Split('/')[1]));
                                        mJv = (from sitm in mJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                               where sitm.DbCode == lJv[i].CrCode
                                               select sitm).FirstOrDefault();
                                        if (mJv != null)
                                        {
                                            Acc myAcc = new Acc();
                                            myAcc.Branch = short.Parse(Session["Branch"].ToString());
                                            myAcc.Code = mJv.DbCode;
                                            myAcc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                            VouData.Add(new myInv2
                                            {
                                                FNo = VouData.Count() + 1,
                                                VouNo = mJv.Number,
                                                InvoiceVouLoc = "00000",
                                                Flag = "",
                                                Name = myAcc.Name1,
                                                Amount = mJv.Amount,
                                                PlateNo = "",
                                                Destination = "تسوية",
                                                DestinationName1 = "تسوية",
                                                DestinationName2 = "Adjust",
                                                Site = "-1",
                                                Customer = mJv.DbCode,
                                                SiteAmount = 0,
                                                CustomerAmount = mJv.Amount,
                                                Claim = lJv[i].Claim
                                            });
                                        }
                                    }
                                    else
                                    {
                                        if (lJv[i].InvNo[0] == 'L')
                                        {
                                            LShipment myInv2 = new LShipment();
                                            string vVouNo2 = lJv[i].InvNo.Substring(1, lJv[i].InvNo.Length - 1);
                                            myInv2.Branch = short.Parse(Session["Branch"].ToString());
                                            myInv2.VouLoc = moh.MakeMask(vVouNo2.Split('/')[0], 5);
                                            myInv2.VouNo = int.Parse(vVouNo2.Split('/')[1]);
                                            myInv2 = myInv2.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                            if (myInv2 != null)
                                            {
                                                if (myInv2 != null)
                                                {
                                                    Cities myCity = new Cities();
                                                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                                                    myCity.Code = myInv2.Destination;
                                                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                                    myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                                              where sitm.Code == myCity.Code
                                                              select sitm).FirstOrDefault();
                                                    if (myCity != null)
                                                    {
                                                        if (myInv2.Customer == lJv[i].CrCode) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv2.VouNo, InvoiceVouLoc = myInv2.VouLoc, Flag = "L", Name = myInv2.RecName, Amount = lJv[i].Amount, CustomerAmount = lJv[i].Amount, PlateNo = "", Destination = myInv2.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = "-1", Customer = myInv2.Customer, Claim = lJv[i].Claim });
                                                        else VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv2.VouNo, InvoiceVouLoc = myInv2.VouLoc, Flag = "L", Name = myInv2.RecName, Amount = lJv[i].Amount, SiteAmount = lJv[i].Amount, PlateNo = "", Destination = myInv2.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = myInv2.Site, Customer = myInv2.Customer, Claim = lJv[i].Claim });
                                                    }
                                                }
                                            }
                                        }
                                        else if (lJv[i].InvNo[0] == 'E')
                                        {
                                            Shipment myInv1 = new Shipment();
                                            string vVouNo2 = lJv[i].InvNo.Substring(1, lJv[i].InvNo.Length - 1);
                                            myInv1.Branch = short.Parse(Session["Branch"].ToString());
                                            myInv1.VouLoc = moh.MakeMask(vVouNo2.Split('/')[0], 5);
                                            myInv1.VouNo = int.Parse(vVouNo2.Split('/')[1]);
                                            myInv1 = myInv1.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                            if (myInv1 != null)
                                            {
                                                if (myInv1 != null)
                                                {
                                                    Cities myCity = new Cities();
                                                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                                                    myCity.Code = myInv1.Destination;
                                                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                                    myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                                              where sitm.Code == myCity.Code
                                                              select sitm).FirstOrDefault();
                                                    if (myCity != null)
                                                    {
                                                        if (myInv1.Customer == lJv[i].CrCode) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv1.VouNo, InvoiceVouLoc = myInv1.VouLoc, Flag = "E", Name = myInv1.RecName, Amount = lJv[i].Amount, CustomerAmount = lJv[i].Amount, PlateNo = "", Destination = myInv1.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = "-1", Customer = myInv1.Customer, Claim = lJv[i].Claim });
                                                        else VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv1.VouNo, InvoiceVouLoc = myInv1.VouLoc, Flag = "E", Name = myInv1.RecName, Amount = lJv[i].Amount, SiteAmount = lJv[i].Amount, PlateNo = "", Destination = myInv1.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = myInv1.Site, Customer = myInv1.Customer, Claim = lJv[i].Claim });
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Invoice myInv = new Invoice();
                                            myInv.Branch = short.Parse(Session["Branch"].ToString());
                                            myInv.VouLoc = moh.MakeMask(lJv[i].InvNo.Split('/')[0], 5);
                                            myInv.VouNo = int.Parse(lJv[i].InvNo.Split('/')[1]);
                                            myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                            if (myInv != null)
                                            {
                                                InvDetails Inv = new InvDetails();
                                                Inv.Branch = short.Parse(Session["Branch"].ToString());
                                                Inv.VouLoc = moh.MakeMask(lJv[i].InvNo.Split('/')[0], 5);
                                                Inv.VouNo = int.Parse(lJv[i].InvNo.Split('/')[1]);
                                                Inv.FNo = 1;
                                                Inv = Inv.GetFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                                if (myInv != null && Inv != null)
                                                {
                                                    Cities myCity = new Cities();
                                                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                                                    myCity.Code = myInv.Destination;
                                                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                                    myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                                              where sitm.Code == myCity.Code
                                                              select sitm).FirstOrDefault();
                                                    if (myCity != null)
                                                    {
                                                        if (myInv.Customer == lJv[i].CrCode) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv.VouNo, InvoiceVouLoc = myInv.VouLoc, Name = myInv.RecName, Amount = lJv[i].Amount, CustomerAmount = lJv[i].Amount, PlateNo = Inv.PlateNo, Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = "-1", Customer = myInv.Customer, Claim = lJv[i].Claim });
                                                        else VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv.VouNo, InvoiceVouLoc = myInv.VouLoc, Name = myInv.RecName, Amount = lJv[i].Amount, SiteAmount = lJv[i].Amount, PlateNo = Inv.PlateNo, Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = myInv.Site, Customer = myInv.Customer, Claim = lJv[i].Claim });
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                myInv = new Invoice();
                                                myInv.Branch = short.Parse(Session["Branch"].ToString());
                                                myInv.VouLoc = moh.MakeMask(lJv[i].InvNo.Split('/')[0], 5);
                                                myInv.VouNo = int.Parse(lJv[i].InvNo.Split('/')[1]);
                                                myInv = myInv.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                                if (myInv != null)
                                                {
                                                    Cities myCity = new Cities();
                                                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                                                    myCity.Code = myInv.Destination;
                                                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                                    myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                                              where sitm.Code == myCity.Code
                                                              select sitm).FirstOrDefault();
                                                    if (myCity != null)
                                                    {
                                                        if (myInv.Customer == lJv[i].CrCode) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv.VouNo, InvoiceVouLoc = myInv.VouLoc, Name = myInv.RecName, Amount = lJv[i].Amount, CustomerAmount = lJv[i].Amount, PlateNo = myInv.PlateNo.Replace('@', '-'), Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = "-1", Customer = myInv.Customer, Claim = lJv[i].Claim });
                                                        else VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv.VouNo, InvoiceVouLoc = myInv.VouLoc, Name = myInv.RecName, Amount = lJv[i].Amount, SiteAmount = lJv[i].Amount, PlateNo = myInv.PlateNo.Replace('@', '-'), Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = myInv.Site, Customer = myInv.Customer, Claim = lJv[i].Claim });
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                txtDiscount_TextChanged(sender, e);
                                LoadVouData();
                                MakeSum();
                            }
                            else
                            {
                                for (int i = start; i < lJv.Count(); i++)
                                {
                                    if (lJv[i].CrCode != "" && lJv[i].CrCode == SiteInfo.LateAcc)
                                    {
                                        txtLand.Text = string.Format("{0:N2}", lJv[i].Amount);
                                        txtAmount.Text = string.Format("{0:N2}", moh.StrToDouble(txtAmount.Text) - lJv[i].Amount);
                                        continue;
                                    }
                                    if (lJv[i].CrCode != "" && lJv[i].CrCode == SiteInfo.InComeAcc)  // إيرادات التشغيل
                                    {
                                        txtOthers.Text = string.Format("{0:N2}", lJv[i].Amount);
                                        txtAmount.Text = string.Format("{0:N2}", moh.StrToDouble(txtAmount.Text) - lJv[i].Amount);
                                        continue;
                                    }
                                }

                                /*
                                if (lJv.Count() > 2 && lJv[lJv.Count() - 1].CrCode == SiteInfo.LateAcc)
                                {
                                    txtLand.Text = string.Format("{0:N2}", lJv[lJv.Count() - 1].Amount);
                                    txtAmount.Text = string.Format("{0:N2}", moh.StrToDouble(txtAmount.Text) - lJv[lJv.Count() - 1].Amount);                                
                                }
                                 */
                                txtDiscount_TextChanged(sender, e);
                            }
                            LoadAttachData();                                     
                        }
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب إدخال رقم السند";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
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

        public void PrintMe(String Number)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=6&LocType=2&LocNumber=" + AreaNo + "&Number=" + Number + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
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
                        UserTran.FormName = "سند القبض";
                        UserTran.FormAction = "طباعة";
                        UserTran.Description = "طباعة سند القبض رقم " + txtVouNo.Text;
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
                    page.vStr1 = "سند القبض";
                    page.vStr2 = "أستلمنا من:";

                    page.PageNo = "1";
                    page.UserName = Session["FullUser"].ToString();
                    page.vStr3 = Session["AreaName"].ToString();

                    string arialunicodepath = Server.MapPath("Fonts")  + @"\mohammad_bold_art_1.ttf";
                    BaseFont nationalBase;
                    nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font nationalTextFont14 = new iTextSharp.text.Font(nationalBase, 14f, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font nationalTextFont16 = new iTextSharp.text.Font(nationalBase, 16f, iTextSharp.text.Font.NORMAL);

                    document.Open();
                    int ColCount = 5;
                    var cols = new[] { 125, 125, 125, 150, 225 };
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
                    cell.Phrase = new iTextSharp.text.Phrase(" سند قبض رقم ", nationalTextFont16);
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
                    cols = new[] { 275, 125, 280, 120 };
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
                    //cell.Border = 0;
                    //cell.Phrase = new iTextSharp.text.Phrase("رقم السند", nationalTextFont);
                    //table.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    //cell.Phrase = new iTextSharp.text.Phrase(txtVouNo.Text + "/" + int.Parse(AreaNo).ToString(), nationalTextFont);
                    //table.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("التاريخ:", nationalTextFont14);
                    table11.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(txtVouDate.Text, nationalTextFont);
                    table11.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("نوع القبض:", nationalTextFont14);
                    table11.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if (ChkCheque.Checked) cell.Phrase = new iTextSharp.text.Phrase("بشيك", nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("نقداً", nationalTextFont);
                    table11.AddCell(cell);
//
                    if (txtDiscount.Text != "" && moh.StrToDouble(txtDiscount.Text) > 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase("الاجمالي:", nationalTextFont14);
                        table11.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtAmount.Text, nationalTextFont);
                        table11.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("الخصم:", nationalTextFont14);
                        table11.AddCell(cell);

                        //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        cell.Phrase = new iTextSharp.text.Phrase(txtDiscount.Text, nationalTextFont);
                        table11.AddCell(cell);
                    }
//
                    //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase(page.vStr2, nationalTextFont14);
                    table11.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if (rdoType.SelectedIndex == 0 || rdoType.SelectedIndex == 2)
                    {
                        if (VouData.Count() > 0) cell.Phrase = new iTextSharp.text.Phrase(VouData[0].Name, nationalTextFont);
                        else cell.Phrase = new iTextSharp.text.Phrase(txtRemark.Text, nationalTextFont);
                    }
                    else cell.Phrase = new iTextSharp.text.Phrase(txtRemark.Text, nationalTextFont);
                    table11.AddCell(cell);


                    //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("مبلغ وقدرة:", nationalTextFont14);
                    table11.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(txtNet.Text, nationalTextFont);
                    table11.AddCell(cell);

//
                    cell.Phrase = new iTextSharp.text.Phrase("وذلك عن:", nationalTextFont14);
                    table11.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(txtRemark.Text, nationalTextFont14);
                    table11.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont14);
                    table11.AddCell(cell);
                    table11.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    /*
                    cell.Phrase = new iTextSharp.text.Phrase("الاجمالي:", nationalTextFont14);
                    table11.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(txtAmount.Text, nationalTextFont);
                    table11.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("الخصم:", nationalTextFont14);
                    table11.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(txtDiscount.Text, nationalTextFont);
                    table11.AddCell(cell);
                    */
                    //
                /*
                    if (ChkCheque.Checked)
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

//
                    document.Add(table11);

                    //document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));

                    PdfPTable table40 = new PdfPTable(5);
                    if (divGrid.Visible)
                    {
                        table40.TotalWidth = 100f;
                        PdfPCell cell4 = new PdfPCell();
                        var cols4 = new[] { 150, 150, 150, 150, 150 };
                        table40.SetWidths(cols4);
                        cell4.ArabicOptions = ColumnText.DIGITS_EN2AN;
                        table40.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                        table40.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell4.FixedHeight = 20f;
                        cell4.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        cell4.Phrase = new iTextSharp.text.Phrase("رقم الفاتورة", nationalTextFont);
                        table40.AddCell(cell4);

                        cell4.Phrase = new iTextSharp.text.Phrase("رقم اللوحه", nationalTextFont);
                        table40.AddCell(cell4);

                        cell4.Phrase = new iTextSharp.text.Phrase("المستلم", nationalTextFont);
                        table40.AddCell(cell4);

                        cell4.Phrase = new iTextSharp.text.Phrase("جهة الترحيل", nationalTextFont);
                        table40.AddCell(cell4);

                        cell4.Phrase = new iTextSharp.text.Phrase("المبلغ", nationalTextFont);
                        table40.AddCell(cell4);
                        cell4.BackgroundColor = iTextSharp.text.BaseColor.WHITE;

                        foreach (myInv2 itm in VouData)
                        {
                            if (itm.VouNo2.Split('/').Count()>1)
                            {
                                cell4.Phrase = new iTextSharp.text.Phrase(itm.VouNo2.Split('/')[1] + "/" + itm.VouNo2.Split('/')[0], nationalTextFont);
                                table40.AddCell(cell4);
                            }
                            else
                            {
                                cell4.Phrase = new iTextSharp.text.Phrase(itm.VouNo2, nationalTextFont);
                                table40.AddCell(cell4);
                            }

                            cell4.Phrase = new iTextSharp.text.Phrase(itm.PlateNo, nationalTextFont);
                            table40.AddCell(cell4);

                            cell4.Phrase = new iTextSharp.text.Phrase(itm.Name, nationalTextFont);
                            table40.AddCell(cell4);

                            cell4.Phrase = new iTextSharp.text.Phrase(itm.DestinationName1, nationalTextFont);
                            table40.AddCell(cell4);

                            cell4.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Amount), nationalTextFont);
                            table40.AddCell(cell4);
                        }

                        document.Add(table40);
                        document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    }
                   
                    PdfPTable table50 = new PdfPTable(5);
                    table50.TotalWidth = 100f;
                    PdfPCell cell5 = new PdfPCell();
                    var cols5 = new[] { 150, 150,150, 150, 150 };
                    table50.SetWidths(cols5);
                    cell5.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    table50.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table50.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    cell5.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("المستلم", nationalTextFont14);
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

                    cell5.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
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

                    string harialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                    BaseFont hnationalBase;
                    hnationalBase = BaseFont.CreateFont(harialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font hnationalTextFont = new iTextSharp.text.Font(hnationalBase, 16f, iTextSharp.text.Font.NORMAL);

                    //I use a PdfPtable with 1 column to position my header where I want it
                    PdfPTable headerTbl = new PdfPTable(3);
                    var cols2 = new[] { 200, 300, 200 };
                    headerTbl.SetWidths(cols2);

                    headerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    headerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    //set the width of the table to be the same as the document
                    headerTbl.TotalWidth = document.PageSize.Width;

                    PdfPCell cell2 = new PdfPCell();
                    cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell2.Border = 0;
                    cell2.PaddingRight = 15;
                    cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell2.Phrase = new iTextSharp.text.Phrase(page.vCompanyName + "\n" + page.vStr3, hnationalTextFont);
                    cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    headerTbl.AddCell(cell2);

                    cell2.PaddingRight = 0;
                    page.vStr1 = " ";
                    cell2.Phrase = new iTextSharp.text.Phrase(page.vStr1, hnationalTextFont);
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
                    document.Add(headerTbl);
                    document.Add(table10);
                    document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    document.Add(table11);
                    if (divGrid.Visible)
                    {
                        document.Add(table40);
                        document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    }
                    document.Add(table50);
                    document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));

                    document.Close();*/
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
                cell2.Phrase = new iTextSharp.text.Phrase(vCompanyName +"\n" + vStr3, nationalTextFont);
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                headerTbl.AddCell(cell2);

                cell2.PaddingRight = 0;
                vStr1=" ";
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
            try
            {
                double vShabaka = 0;                    
                MakeSum();
                short FNo = 1;
                Jv vJv = new Jv();
                if(moh.StrToDouble(txtCashAmount.Text)>0)
                {
                    vJv = new Jv();
                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                    vJv.FType = 101;
                    vJv.LocType = 2;
                    vJv.LocNumber = short.Parse(AreaNo);
                    vJv.Number = int.Parse(txtVouNo.Text);
                    vJv.Post = 1;
                    vJv.FDate = moh.CheckDate(txtVouDate.Text);
                    vJv.DbCode = ddlDbCode.SelectedValue;
                    vJv.CrCode = "";
                    vJv.Area = "-1";
                    vJv.CostCenter = "-1";
                    vJv.Project = "-1";
                    vJv.CostAcc = "-1";
                    vJv.EmpCode = "-1";
                    vJv.Person = txtPerson.Text;
                    vJv.Payment = short.Parse(rdoPayment.SelectedValue);
                    vJv.Remark = txtRemark.Text;
                    vJv.BankName = txtBankName.Text;
                    vJv.ChequeDate = txtChqDate.Text;
                    vJv.ChequeNo = txtchqNo.Text;
                    //vJv.InvNo = txtInvNo.Text;
                    //vJv.Amount = moh.StrToDouble(txtNet.Text);
                    vJv.Amount = moh.StrToDouble(txtCashAmount.Text);
                    vJv.FNo = FNo;
                    vJv.UserName = txtUserName.ToolTip;
                    vJv.UserDate = txtUserDate.Text;
                    vJv.DocType = (short)rdoType.SelectedIndex;
                    vJv.Claim = (ddlClaim.SelectedIndex == 0 ? 0 : int.Parse(ddlClaim.SelectedValue));
                    FNo++;
                    vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }

                if(moh.StrToDouble(txtShAmount.Text)>0)
                {
                    vShabaka = Math.Round(moh.StrToDouble(txtShAmount.Text) * (moh.StrToDouble(txtShAmount.Text) > 100 ? 0.008 : 0.007), 2);  // Should be Setting
                    if (vShabaka > 160) vShabaka = 160; // Should be Setting

                    vJv = new Jv();
                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                    vJv.FType = 101;
                    vJv.LocType = 2;
                    vJv.LocNumber = short.Parse(AreaNo);
                    vJv.Number = int.Parse(txtVouNo.Text);
                    vJv.Post = 1;
                    vJv.FDate = moh.CheckDate(txtVouDate.Text);
                    vJv.DbCode = moh.MadaAcc;
                    vJv.CrCode = "";
                    vJv.Area = "-1";
                    vJv.CostCenter = "-1";
                    vJv.Project = "-1";
                    vJv.CostAcc = "-1";
                    vJv.EmpCode = "-1";
                    vJv.Person = txtPerson.Text;
                    vJv.Payment = short.Parse(rdoPayment.SelectedValue);
                    vJv.Remark = txtRemark.Text;
                    vJv.BankName = txtBankName.Text;
                    vJv.ChequeDate = txtChqDate.Text;
                    vJv.ChequeNo = txtchqNo.Text;
                    //vJv.InvNo = txtInvNo.Text;
                    //vJv.Amount = moh.StrToDouble(txtNet.Text);
                    vJv.Amount = moh.StrToDouble(txtShAmount.Text) - vShabaka;
                    vJv.FNo = FNo;
                    vJv.UserName = txtUserName.ToolTip;
                    vJv.UserDate = txtUserDate.Text;
                    vJv.DocType = (short)rdoType.SelectedIndex;
                    vJv.Claim = (ddlClaim.SelectedIndex == 0 ? 0 : int.Parse(ddlClaim.SelectedValue));
                    FNo++;
                    vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    
                }

                if (vShabaka > 0)
                {
                    vJv = new Jv();
                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                    vJv.FType = 101;
                    vJv.LocType = 2;
                    vJv.LocNumber = short.Parse(AreaNo);
                    vJv.Number = int.Parse(txtVouNo.Text);
                    vJv.Post = 1;
                    vJv.Person = txtPerson.Text;
                    vJv.Payment = short.Parse(rdoPayment.SelectedValue);
                    vJv.FDate = moh.CheckDate(txtVouDate.Text);
                    vJv.DbCode = "310102027"; // Should be Setting
                    vJv.CrCode = "";
                    if (ddlArea.SelectedIndex > 0) vJv.Area = ddlArea.SelectedValue;
                    else vJv.Area = "-1";
                    if (ddlCostCenter.SelectedIndex > 0) vJv.CostCenter = ddlCostCenter.SelectedValue;
                    else vJv.CostCenter = "-1";
                    if (ddlProject.SelectedIndex > 0) vJv.Project = ddlProject.SelectedValue;
                    else vJv.Project = "-1";
                    if (ddlCarNo.SelectedIndex > 0) vJv.CarNo = ddlCarNo.SelectedValue;
                    else vJv.CarNo = "-1";
                    if (ddlCostAcc.SelectedIndex > 0) vJv.CostAcc = ddlCostAcc.SelectedValue;
                    else vJv.CostAcc = "-1";
                    if (ddlEmp.SelectedIndex > 0) vJv.EmpCode = ddlEmp.SelectedValue;
                    else vJv.EmpCode = "-1";
                    vJv.Remark = txtRemark.Text;
                    vJv.BankName = txtBankName.Text;
                    vJv.ChequeDate = txtChqDate.Text;
                    vJv.ChequeNo = txtchqNo.Text;
                    //vJv.InvNo = txtInvNo.Text;
                    vJv.Amount = vShabaka;
                    vJv.FNo = FNo;
                    vJv.UserName = txtUserName.ToolTip;
                    vJv.UserDate = txtUserDate.Text;
                    vJv.DocType = (short)rdoType.SelectedIndex;
                    vJv.Claim = (ddlClaim.SelectedIndex == 0 ? 0 : int.Parse(ddlClaim.SelectedValue));
                    vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    FNo++;
                }

                if (moh.StrToDouble(txtDiscount.Text)>0)
                {
                    vJv = new Jv();
                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                    vJv.FType = 101;
                    vJv.LocType = 2;
                    vJv.LocNumber = short.Parse(AreaNo);
                    vJv.Number = int.Parse(txtVouNo.Text);
                    vJv.Post = 1;
                    vJv.Person = txtPerson.Text;
                    vJv.Payment = short.Parse(rdoPayment.SelectedValue);
                    vJv.FDate = moh.CheckDate(txtVouDate.Text);
                    vJv.DbCode = SiteInfo.DiscountAcc;
                    vJv.CrCode = "";
                    if (ddlArea.SelectedIndex > 0) vJv.Area = ddlArea.SelectedValue;
                    else vJv.Area = "-1";
                    if (ddlCostCenter.SelectedIndex > 0) vJv.CostCenter = ddlCostCenter.SelectedValue;
                    else vJv.CostCenter = "-1";
                    if (ddlProject.SelectedIndex > 0) vJv.Project = ddlProject.SelectedValue;
                    else vJv.Project = "-1";
                    if (ddlCarNo.SelectedIndex > 0) vJv.CarNo = ddlCarNo.SelectedValue;
                    else vJv.CarNo = "-1";
                    if (ddlCostAcc.SelectedIndex > 0) vJv.CostAcc = ddlCostAcc.SelectedValue;
                    else vJv.CostAcc = "-1";
                    if (ddlEmp.SelectedIndex > 0) vJv.EmpCode = ddlEmp.SelectedValue;
                    else vJv.EmpCode = "-1";
                    vJv.Remark = txtRemark.Text;
                    vJv.BankName = txtBankName.Text;
                    vJv.ChequeDate = txtChqDate.Text;
                    vJv.ChequeNo = txtchqNo.Text;
                    //vJv.InvNo = txtInvNo.Text;
                    vJv.Amount = moh.StrToDouble(txtDiscount.Text);
                    vJv.FNo = FNo;
                    vJv.UserName = txtUserName.ToolTip;
                    vJv.UserDate = txtUserDate.Text;
                    vJv.DocType = (short)rdoType.SelectedIndex;
                    vJv.Claim = (ddlClaim.SelectedIndex == 0 ? 0 : int.Parse(ddlClaim.SelectedValue));
                    vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    FNo++;                       
                }
                
                string myCode = "";
                if (rdoType.SelectedIndex == 0 || rdoType.SelectedIndex == 2)
                {
                    foreach (myInv2 itm in VouData)
                    {
                        vJv = new Jv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 101;
                        vJv.LocType = 2;
                        vJv.LocNumber = short.Parse(AreaNo);
                        vJv.Payment = short.Parse(rdoPayment.SelectedValue);
                        vJv.Person = txtPerson.Text;
                        vJv.Number = int.Parse(txtVouNo.Text);
                        vJv.Post = 1;
                        vJv.FDate = moh.CheckDate(txtVouDate.Text);
                        if (itm.SiteAmount > 0)
                        {
                            CostCenter myCenter = new CostCenter();
                            myCenter.Branch = short.Parse(Session["Branch"].ToString());
                            if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                            myCenter.Code = itm.Site;
                            myCode = itm.Site;
                            myCenter = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                        where citm.Code == myCenter.Code
                                        select citm).FirstOrDefault();
                            if (myCenter != null) vJv.CrCode = myCenter.SiteAcc;
                            vJv.Amount = itm.SiteAmount;
                        }
                        else if (itm.CustomerAmount > 0)
                        {
                            vJv.CrCode = itm.Customer;
                            vJv.Amount = itm.CustomerAmount;
                            myCode = itm.Customer;
                        }                            
                        vJv.DbCode = "";
                        vJv.Area = "-1";
                        vJv.CostCenter = "-1";
                        vJv.Project = "-1";
                        vJv.CostAcc = "-1";
                        vJv.EmpCode = "-1";
                        vJv.Remark = txtRemark.Text;
                        vJv.BankName = "";
                        vJv.ChequeDate = "";
                        vJv.ChequeNo = "";
                        vJv.InvNo = itm.VouNo2;
                        //vJv.Amount = moh.StrToDouble(txtAmount.Text);
                        vJv.FNo = FNo;
                        vJv.UserName = txtUserName.ToolTip;
                        vJv.UserDate = txtUserDate.Text;
                        vJv.DocType = (short)rdoType.SelectedIndex;
                        vJv.Claim = itm.Claim;      // (ddlClaim.SelectedIndex == 0 ? 0 : int.Parse(ddlClaim.SelectedValue));
                        vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        FNo++;


                        if (itm.Claim != 0)       // (ddlClaim.SelectedIndex > 0)
                        {
                            Claim myClaim = new Claim();
                            if (itm.VouNo2.Split('/').Count() < 2)
                            {
                                myClaim.Flag = "";
                                myClaim.InvLoc = 0;
                                myClaim.InvNo = int.Parse(itm.VouNo2);
                            }
                            else
                            {
                                string vVouNo2 = (itm.VouNo2[0] == 'L' || itm.VouNo2[0] == 'E' ? itm.VouNo2.Substring(1, itm.VouNo2.Length - 1) : itm.VouNo2);
                                myClaim.Flag = (itm.VouNo2[0] == 'L' || itm.VouNo2[0] == 'E' ? itm.VouNo2.Substring(0, 1) : "");
                                myClaim.InvLoc = short.Parse(vVouNo2.Split('/')[0]);
                                myClaim.InvNo = int.Parse(vVouNo2.Split('/')[1]);
                            }
                            myClaim = myClaim.GetByInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if(myClaim != null)
                            {
                                myClaim.State = true;
                                myClaim.UpdateState(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                                {
                                    Transactions UserTran = new Transactions();
                                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                    UserTran.UserName = Session["CurrentUser"].ToString();
                                    UserTran.FormName = "المطالبة المالية";
                                    UserTran.FormAction = "سداد";
                                    UserTran.Description = " سداد المطالبة المالية رقم " + myClaim.InvNo.ToString();
                                    UserTran.IP = IPNetworking.GetIP4Address();
                                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                }
                            }
                        }
                        FNo++;
                    }


                    if (moh.StrToDouble(txtCust.Text) > 0)
                    {
                        Acc myAcc = new Acc();
                        myAcc.Branch = short.Parse(Session["Branch"].ToString());
                        myAcc.Code = vJv.CrCode;
                        if (myAcc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)) vJv.Remark = "دفعة مقدمة من العميل " + myAcc.Code + " " + myAcc.Name1;

                        vJv.Amount = moh.StrToDouble(txtCust.Text);
                        vJv.FNo = FNo;
                        vJv.InvNo = "";
                        vJv.CrCode = "240201001";                            
                        vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        FNo++;
                    }

                    if (moh.StrToDouble(txtLand.Text) > 0)
                    {
                        vJv = new Jv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 101;
                        vJv.LocType = 2;
                        vJv.LocNumber = short.Parse(AreaNo);
                        vJv.Payment = short.Parse(rdoPayment.SelectedValue);
                        vJv.Person = txtPerson.Text;
                        vJv.Number = int.Parse(txtVouNo.Text);
                        vJv.Post = 1;
                        vJv.FDate = moh.CheckDate(txtVouDate.Text);
                        vJv.Amount = moh.StrToDouble(txtLand.Text);
                        vJv.CrCode = SiteInfo.LateAcc;
                        vJv.DbCode = "";
                        if (ddlArea.SelectedIndex > 0) vJv.Area = ddlArea.SelectedValue;
                        else vJv.Area = "-1";
                        if (ddlCostCenter.SelectedIndex > 0) vJv.CostCenter = ddlCostCenter.SelectedValue;
                        else vJv.CostCenter = "-1";
                        if (ddlProject.SelectedIndex > 0) vJv.Project = ddlProject.SelectedValue;
                        else vJv.Project = "-1";
                        if (ddlCarNo.SelectedIndex > 0) vJv.CarNo = ddlCarNo.SelectedValue;
                        else vJv.CarNo = "-1";
                        if (ddlCostAcc.SelectedIndex > 0) vJv.CostAcc = ddlCostAcc.SelectedValue;
                        else vJv.CostAcc = "-1";
                        if (ddlEmp.SelectedIndex > 0) vJv.EmpCode = ddlEmp.SelectedValue;
                        else vJv.EmpCode = "-1";
                        vJv.Remark = txtRemark.Text;
                        vJv.BankName = "";
                        vJv.ChequeDate = "";
                        vJv.ChequeNo = "";
                        vJv.InvNo = "";
                        //vJv.Amount = moh.StrToDouble(txtAmount.Text);
                        vJv.FNo = FNo;
                        vJv.UserName = txtUserName.ToolTip;
                        vJv.UserDate = txtUserDate.Text;
                        vJv.DocType = (short)rdoType.SelectedIndex;
                        vJv.Claim = (ddlClaim.SelectedIndex == 0 ? 0 : int.Parse(ddlClaim.SelectedValue));
                        vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        FNo++;
                    }


                    if (moh.StrToDouble(txtOthers.Text) > 0)
                    {
                        vJv = new Jv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 101;
                        vJv.LocType = 2;
                        vJv.LocNumber = short.Parse(AreaNo);
                        vJv.Payment = short.Parse(rdoPayment.SelectedValue);
                        vJv.Person = txtPerson.Text;
                        vJv.Number = int.Parse(txtVouNo.Text);
                        vJv.Post = 1;
                        vJv.FDate = moh.CheckDate(txtVouDate.Text);
                        vJv.Amount = moh.StrToDouble(txtOthers.Text);
                        vJv.CrCode = SiteInfo.InComeAcc;
                        vJv.DbCode = "";
                        if (ddlArea.SelectedIndex > 0) vJv.Area = ddlArea.SelectedValue;
                        else vJv.Area = "-1";
                        if (ddlCostCenter.SelectedIndex > 0) vJv.CostCenter = ddlCostCenter.SelectedValue;
                        else vJv.CostCenter = "-1";
                        if (ddlProject.SelectedIndex > 0) vJv.Project = ddlProject.SelectedValue;
                        else vJv.Project = "-1";
                        if (ddlCarNo.SelectedIndex > 0) vJv.CarNo = ddlCarNo.SelectedValue;
                        else vJv.CarNo = "-1";
                        if (ddlCostAcc.SelectedIndex > 0) vJv.CostAcc = ddlCostAcc.SelectedValue;
                        else vJv.CostAcc = "-1";
                        if (ddlEmp.SelectedIndex > 0) vJv.EmpCode = ddlEmp.SelectedValue;
                        else vJv.EmpCode = "-1";
                        vJv.Remark = txtRemark.Text;
                        vJv.BankName = "";
                        vJv.ChequeDate = "";
                        vJv.ChequeNo = "";
                        vJv.InvNo = "";
                        //vJv.Amount = moh.StrToDouble(txtAmount.Text);
                        vJv.FNo = FNo;
                        vJv.UserName = txtUserName.ToolTip;
                        vJv.UserDate = txtUserDate.Text;
                        vJv.DocType = (short)rdoType.SelectedIndex;
                        vJv.Claim = (ddlClaim.SelectedIndex == 0 ? 0 : int.Parse(ddlClaim.SelectedValue));
                        vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        FNo++;
                    }

                }
                else
                {
                    if (moh.StrToDouble(txtAmount.Text) > 0)
                    {
                        vJv = new Jv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 101;
                        vJv.LocType = 2;
                        vJv.LocNumber = short.Parse(AreaNo);
                        vJv.Number = int.Parse(txtVouNo.Text);
                        vJv.Post = 1;
                        vJv.FDate = moh.CheckDate(txtVouDate.Text);
                        vJv.CrCode = SiteInfo.ClientsAcc;
                        vJv.Payment = short.Parse(rdoPayment.SelectedValue);
                        vJv.Person = txtPerson.Text;
                        vJv.DbCode = "";
                        if (ddlArea.SelectedIndex > 0) vJv.Area = ddlArea.SelectedValue;
                        else vJv.Area = "-1";
                        if (ddlCostCenter.SelectedIndex > 0) vJv.CostCenter = ddlCostCenter.SelectedValue;
                        else vJv.CostCenter = "-1";
                        if (ddlProject.SelectedIndex > 0) vJv.Project = ddlProject.SelectedValue;
                        else vJv.Project = "-1";
                        if (ddlCarNo.SelectedIndex > 0) vJv.CarNo = ddlCarNo.SelectedValue;
                        else vJv.CarNo = "-1";
                        if (ddlCostAcc.SelectedIndex > 0) vJv.CostAcc = ddlCostAcc.SelectedValue;
                        else vJv.CostAcc = "-1";
                        if (ddlEmp.SelectedIndex > 0) vJv.EmpCode = ddlEmp.SelectedValue;
                        else vJv.EmpCode = "-1";
                        vJv.Remark = txtRemark.Text;
                        vJv.BankName = txtBankName.Text;
                        vJv.ChequeDate = txtChqDate.Text;
                        vJv.ChequeNo = txtchqNo.Text;
                        //vJv.InvNo = txtInvNo.Text;
                        vJv.Amount = moh.StrToDouble(txtAmount.Text);
                        vJv.FNo = FNo;
                        vJv.UserName = txtUserName.ToolTip;
                        vJv.UserDate = txtUserDate.Text;
                        vJv.DocType = (short)rdoType.SelectedIndex;
                        vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        FNo++;
                    }

                    if (moh.StrToDouble(txtLand.Text) > 0)
                    {
                        vJv = new Jv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 101;
                        vJv.LocType = 2;
                        vJv.LocNumber = short.Parse(AreaNo);
                        vJv.Payment = short.Parse(rdoPayment.SelectedValue);
                        vJv.Person = txtPerson.Text;
                        vJv.Number = int.Parse(txtVouNo.Text);
                        vJv.Post = 1;
                        vJv.FDate = moh.CheckDate(txtVouDate.Text);
                        vJv.Amount = moh.StrToDouble(txtLand.Text);
                        vJv.CrCode = SiteInfo.LateAcc;
                        vJv.DbCode = "";
                        if (ddlArea.SelectedIndex > 0) vJv.Area = ddlArea.SelectedValue;
                        else vJv.Area = "-1";
                        if (ddlCostCenter.SelectedIndex > 0) vJv.CostCenter = ddlCostCenter.SelectedValue;
                        else vJv.CostCenter = "-1";
                        if (ddlProject.SelectedIndex > 0) vJv.Project = ddlProject.SelectedValue;
                        else vJv.Project = "-1";
                        if (ddlCarNo.SelectedIndex > 0) vJv.CarNo = ddlCarNo.SelectedValue;
                        else vJv.CarNo = "-1";
                        if (ddlCostAcc.SelectedIndex > 0) vJv.CostAcc = ddlCostAcc.SelectedValue;
                        else vJv.CostAcc = "-1";
                        if (ddlEmp.SelectedIndex > 0) vJv.EmpCode = ddlEmp.SelectedValue;
                        else vJv.EmpCode = "-1";
                        vJv.Remark = txtRemark.Text;
                        vJv.BankName = "";
                        vJv.ChequeDate = "";
                        vJv.ChequeNo = "";
                        vJv.InvNo = "";
                        //vJv.Amount = moh.StrToDouble(txtAmount.Text);
                        vJv.FNo = FNo;
                        vJv.UserName = txtUserName.ToolTip;
                        vJv.UserDate = txtUserDate.Text;
                        vJv.DocType = (short)rdoType.SelectedIndex;
                        vJv.Claim =  (ddlClaim.SelectedIndex == 0 ? 0 : int.Parse(ddlClaim.SelectedValue));
                        vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        FNo++;
                    }

                    if (moh.StrToDouble(txtOthers.Text) > 0)
                    {
                        vJv = new Jv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 101;
                        vJv.LocType = 2;
                        vJv.LocNumber = short.Parse(AreaNo);
                        vJv.Payment = short.Parse(rdoPayment.SelectedValue);
                        vJv.Person = txtPerson.Text;
                        vJv.Number = int.Parse(txtVouNo.Text);
                        vJv.Post = 1;
                        vJv.FDate = moh.CheckDate(txtVouDate.Text);
                        vJv.Amount = moh.StrToDouble(txtOthers.Text);
                        vJv.CrCode = SiteInfo.InComeAcc;
                        vJv.DbCode = "";
                        if (ddlArea.SelectedIndex > 0) vJv.Area = ddlArea.SelectedValue;
                        else vJv.Area = "-1";
                        if (ddlCostCenter.SelectedIndex > 0) vJv.CostCenter = ddlCostCenter.SelectedValue;
                        else vJv.CostCenter = "-1";
                        if (ddlProject.SelectedIndex > 0) vJv.Project = ddlProject.SelectedValue;
                        else vJv.Project = "-1";
                        if (ddlCarNo.SelectedIndex > 0) vJv.CarNo = ddlCarNo.SelectedValue;
                        else vJv.CarNo = "-1";
                        if (ddlCostAcc.SelectedIndex > 0) vJv.CostAcc = ddlCostAcc.SelectedValue;
                        else vJv.CostAcc = "-1";
                        if (ddlEmp.SelectedIndex > 0) vJv.EmpCode = ddlEmp.SelectedValue;
                        else vJv.EmpCode = "-1";
                        vJv.Remark = txtRemark.Text;
                        vJv.BankName = "";
                        vJv.ChequeDate = "";
                        vJv.ChequeNo = "";
                        vJv.InvNo = "";
                        //vJv.Amount = moh.StrToDouble(txtAmount.Text);
                        vJv.FNo = FNo;
                        vJv.UserName = txtUserName.ToolTip;
                        vJv.UserDate = txtUserDate.Text;
                        vJv.DocType = (short)rdoType.SelectedIndex;
                        vJv.Claim = (ddlClaim.SelectedIndex == 0 ? 0 : int.Parse(ddlClaim.SelectedValue));
                        vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        FNo++;
                    }

                }
                if (ddlClaim.SelectedIndex > 0)
                {
                    UpdateCache();
                }
                return true;
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

                    TextBox txtVouNo2 = gvr.FindControl("txtVouNo2") as TextBox;

                    if (txtVouNo2 == null)
                    {
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                    if (txtVouNo2.Text == "")
                    {
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "تاكد من أدخال البيانات المطلوبة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                    else
                    {
                        txtVouNo2.Text = txtVouNo2.Text.Trim();
                        //txtVouNo2.Text = int.Parse(txtVouNo2.Text.Split('/')[0]).ToString().Trim() + "/" + int.Parse(txtVouNo2.Text.Split('/')[1]).ToString().Trim();
                    }

                    double Amount = 0;
                    double vJvamount = 0;
                    if (txtVouNo2.Text[0] == 'L')
                    {
                        LShipment myInv2 = new LShipment();
                        myInv2.Branch = short.Parse(Session["Branch"].ToString());
                        string vVouNo2 = txtVouNo2.Text.Substring(1, txtVouNo2.Text.Length-1);
                        myInv2.VouLoc = moh.MakeMask(vVouNo2.Split('/')[0], 5);
                        myInv2.VouNo = int.Parse(vVouNo2.Split('/')[1]);
                        myInv2 = myInv2.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myInv2 == null)
                        {
                            myInv2 = new LShipment();
                            myInv2.Branch = short.Parse(Session["Branch"].ToString());
                            myInv2.VouLoc = moh.MakeMask(vVouNo2.Split('/')[0], 5);
                            myInv2.VouNo = int.Parse(vVouNo2.Split('/')[1]);
                            myInv2 = myInv2.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myInv2 == null)
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "رقم الفاتورة غير مدرج من قبل";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }
                        Amount = (double)(myInv2.CustomerAmount + myInv2.SiteAmount);

                        Cities myCity = new Cities();
                        myCity.Branch = short.Parse(Session["Branch"].ToString());
                        myCity.Code = myInv2.Destination;
                        if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                  where sitm.Code == myCity.Code
                                  select sitm).FirstOrDefault();
                        if (myCity == null)
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم الفاتورة غير مدرج من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                        if (myInv2.CustomerAmount == 0 && myInv2.SiteAmount == 0)
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لا يوجد مبالغ مستحقة على هذه الفاتورة";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                        List<Jv> lJv = new List<Jv>();
                        Jv vJv = new Jv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 101;
                        vJv.LocType = 2;
                        vJv.LocNumber = short.Parse(AreaNo);
                        vJv.InvNo = txtVouNo2.Text;
                        vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (vJv != null)
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text += "الفاتورة تم ادخالها من قبل في السند رقم " + vJv.LocNumber.ToString() + @"/" + vJv.Number.ToString();
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                        vJv = new Jv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 100;
                        vJv.LocType = 1;
                        vJv.LocNumber = 1;
                        vJv.InvNo = txtVouNo2.Text;
                        vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (vJv != null)
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الفاتورة تم ادخالها من قبل بالقيد رقم " + vJv.Number.ToString();
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                        Claim myClaim = new Claim();
                        myClaim.InvNo = int.Parse(vVouNo2.Split('/')[1]);
                        myClaim.InvLoc = short.Parse(vVouNo2.Split('/')[0]);
                        myClaim.Flag = "L";
                        myClaim = myClaim.GetByInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myClaim != null)
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الفاتورة مدرجة في المطالبة المالية رقم " + myClaim.InvNo.ToString();
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                        for (int i = 0; i < VouData.Count; i++)
                        {
                            if (VouData[i].VouNo2 == txtVouNo2.Text)
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "الفاتورة تم ادخالها من قبل";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }

                        if (myInv2.SiteAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv2.VouNo, Flag = "L", InvoiceVouLoc = myInv2.VouLoc, Name = myInv2.RecName, Amount = myInv2.SiteAmount, PlateNo = "", Destination = myInv2.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = myInv2.Site, Customer = myInv2.Customer, SiteAmount = myInv2.SiteAmount, CustomerAmount = 0 });
                        if (myInv2.CustomerAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv2.VouNo, Flag = "L", InvoiceVouLoc = myInv2.VouLoc, Name = myInv2.RecName, Amount = myInv2.CustomerAmount, PlateNo = "", Destination = myInv2.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = "-1", Customer = myInv2.Customer, CustomerAmount = myInv2.CustomerAmount, SiteAmount = 0 });
                    }
                    else if (txtVouNo2.Text[0] == 'E')
                    {
                        string vVouNo2 = txtVouNo2.Text.Substring(1, txtVouNo2.Text.Length-1);
                        Shipment myInv1 = new Shipment();
                        myInv1.Branch = short.Parse(Session["Branch"].ToString());
                        myInv1.VouLoc = moh.MakeMask(vVouNo2.Split('/')[0], 5);
                        myInv1.VouNo = int.Parse(vVouNo2.Split('/')[1]);
                        myInv1 = myInv1.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myInv1 == null)
                        {
                            myInv1 = new Shipment();
                            myInv1.Branch = short.Parse(Session["Branch"].ToString());
                            myInv1.VouLoc = moh.MakeMask(vVouNo2.Split('/')[0], 5);
                            myInv1.VouNo = int.Parse(vVouNo2.Split('/')[1]);
                            myInv1 = myInv1.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myInv1 == null)
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "رقم الفاتورة غير مدرج من قبل";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }

                        //if()   سند القبض للمنطقة
                        //{                    
                        //}

                        Cities myCity = new Cities();
                        myCity.Branch = short.Parse(Session["Branch"].ToString());
                        myCity.Code = myInv1.Destination;
                        if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                  where sitm.Code == myCity.Code
                                  select sitm).FirstOrDefault();
                        if (myCity == null)
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم الفاتورة غير مدرج من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                        if (myInv1.CustomerAmount == 0 && myInv1.SiteAmount == 0)
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لا يوجد مبالغ مستحقة على هذه الفاتورة";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }


                        Jv vJv = new Jv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 101;
                        vJv.LocType = 2;
                        vJv.LocNumber = short.Parse(AreaNo);
                        vJv.InvNo = txtVouNo2.Text;
                        vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (vJv != null)
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الفاتورة تم ادخالها من قبل في السند رقم " + vJv.LocNumber.ToString() + "/" + vJv.Number.ToString();
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;

                            //if ((myInv.SiteAmount > 0 && vJv.Amount == (double)myInv.SiteAmount) || (myInv.CustomerAmount > 0 && vJv.Amount == (double)myInv.CustomerAmount))
                            //{
                            //}
                        }

                        vJv = new Jv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 100;
                        vJv.LocType = 1;
                        vJv.LocNumber = 1;
                        vJv.InvNo = txtVouNo2.Text;
                        vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (vJv != null)
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الفاتورة تم ادخالها من قبل بالقيد رقم " + vJv.Number.ToString();
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;

                            //if ((myInv.SiteAmount > 0 && vJv.Amount == (double)myInv.SiteAmount) || (myInv.CustomerAmount > 0 && vJv.Amount == (double)myInv.CustomerAmount))
                            //{
                            //}
                        }


                        Claim myClaim = new Claim();
                        myClaim.InvNo = int.Parse(vVouNo2.Split('/')[1]);
                        myClaim.InvLoc = short.Parse(vVouNo2.Split('/')[0]);
                        myClaim.Flag = "E";
                        myClaim = myClaim.GetByInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myClaim != null)
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الفاتورة مدرجة في المطالبة المالية رقم " + myClaim.InvNo.ToString();
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                        for (int i = 0; i < VouData.Count; i++)
                        {
                            if (VouData[i].VouNo == myInv1.VouNo)
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "الفاتورة تم ادخالها من قبل";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }

                        if (myInv1.SiteAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv1.VouNo, InvoiceVouLoc = myInv1.VouLoc, Flag = "E", Name = myInv1.RecName, Amount = myInv1.SiteAmount, PlateNo = "", Destination = myInv1.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = myInv1.Site, Customer = myInv1.Customer, SiteAmount = myInv1.SiteAmount, CustomerAmount = 0 });
                        if (myInv1.CustomerAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv1.VouNo, InvoiceVouLoc = myInv1.VouLoc, Flag = "E", Name = myInv1.RecName, Amount = myInv1.CustomerAmount, PlateNo = "", Destination = myInv1.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = "-1", Customer = myInv1.Customer, CustomerAmount = myInv1.CustomerAmount, SiteAmount = 0 });
                    }
                    else
                    {
                        Invoice myInv = new Invoice();
                        myInv.Branch = short.Parse(Session["Branch"].ToString());
                        myInv.VouLoc = moh.MakeMask(txtVouNo2.Text.Split('/')[0], 5);
                        myInv.VouNo = int.Parse(txtVouNo2.Text.Split('/')[1]);
                        myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myInv == null)
                        {
                            myInv = new Invoice();
                            myInv.Branch = short.Parse(Session["Branch"].ToString());
                            myInv.VouLoc = moh.MakeMask(txtVouNo2.Text.Split('/')[0], 5);
                            myInv.VouNo = int.Parse(txtVouNo2.Text.Split('/')[1]);
                            myInv = myInv.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myInv == null)
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "رقم الفاتورة غير مدرج من قبل";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }

                        Amount = (double)(myInv.CustomerAmount + myInv.SiteAmount);

                        Cities myCity = new Cities();
                        myCity.Branch = short.Parse(Session["Branch"].ToString());
                        myCity.Code = myInv.Destination;
                        if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                  where sitm.Code == myCity.Code
                                  select sitm).FirstOrDefault();
                        if (myCity == null)
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم الفاتورة غير مدرج من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                        if (myInv.CustomerAmount == 0 && myInv.SiteAmount == 0)
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لا يوجد مبالغ مستحقة على هذه الفاتورة";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                        List<Jv> lJv = new List<Jv>();
                        Jv vJv = new Jv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 101;
                        vJv.LocType = 2;
                        vJv.LocNumber = short.Parse(AreaNo);
                        vJv.InvNo = txtVouNo2.Text;
                        lJv = vJv.findInvNo2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (lJv != null && lJv.Count() > 0)
                        {
                            foreach (Jv itm in lJv)
                            {
                                vJvamount += (double)itm.Amount;
                            }
                            if (vJvamount < Amount)
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "";
                                foreach (Jv itm in lJv)
                                {
                                    LblCodesResult.Text += "الفاتورة تم ادخالها من قبل السند رقم " + itm.LocNumber.ToString() + @"/" + itm.Number.ToString() + @" بقيمة " + itm.Amount.ToString() + " ريال " + @"<br/>";
                                }                                
                            }
                            else
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "";
                                foreach (Jv itm in lJv)
                                {
                                    LblCodesResult.Text += "الفاتورة تم ادخالها من قبل السند رقم " + itm.LocNumber.ToString() + @"/" + itm.Number.ToString() + @" بقيمة " + itm.Amount.ToString() + " ريال " + @"<br/>";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }

                        lJv = new List<Jv>();
                        vJv = new Jv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 100;
                        vJv.LocType = 1;
                        vJv.LocNumber = 1;
                        vJv.InvNo = txtVouNo2.Text;
                        lJv = vJv.findInvNo2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (lJv != null && lJv.Count() > 0)
                        {
                            foreach (Jv itm in lJv)
                            {
                                vJvamount += (double)itm.Amount;
                            }
                            if (vJvamount < Amount)
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "";
                                foreach (Jv itm in lJv)
                                {
                                    LblCodesResult.Text += "الفاتورة تم ادخالها من قبل بالقيد رقم " + itm.Number.ToString() + @" بقيمة " + itm.Amount.ToString() + " ريال " + @"<br/>";
                                }
                            }
                            else
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "";
                                foreach (Jv itm in lJv)
                                {
                                    LblCodesResult.Text += "الفاتورة تم ادخالها من قبل بالقيد رقم " + itm.Number.ToString() + @" بقيمة " + itm.Amount.ToString() + " ريال " +  @"<br/>";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }


                        Claim myClaim = new Claim();
                        myClaim.InvNo = int.Parse(txtVouNo2.Text.Split('/')[1]);
                        myClaim.InvLoc = short.Parse(txtVouNo2.Text.Split('/')[0]);
                        myClaim = myClaim.GetByInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myClaim != null)
                        {
                            if (!(bool)myClaim.State)
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "الفاتورة مدرجة في المطالبة المالية رقم " + myClaim.InvNo.ToString();
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }

                        for (int i = 0; i < VouData.Count; i++)
                        {
                            if (VouData[i].VouNo == myInv.VouNo)
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "الفاتورة تم ادخالها من قبل";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }

                        Amount = Amount - vJvamount;

                        InvDetails Inv = new InvDetails();
                        Inv.Branch = short.Parse(Session["Branch"].ToString());
                        Inv.VouLoc = moh.MakeMask(txtVouNo2.Text.Split('/')[0], 5);
                        Inv.VouNo = int.Parse(txtVouNo2.Text.Split('/')[1]);
                        Inv.FNo = 1;
                        Inv = Inv.GetFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        if (Inv != null)
                        {
                            if (vJvamount == 0)
                            {
                                if (myInv.SiteAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv.VouNo, InvoiceVouLoc = myInv.VouLoc, Name = myInv.RecName, Amount = myInv.SiteAmount, PlateNo = Inv.PlateNo, Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = myInv.Site, Customer = myInv.Customer, SiteAmount = myInv.SiteAmount, CustomerAmount = 0 });
                                if (myInv.CustomerAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv.VouNo, InvoiceVouLoc = myInv.VouLoc, Name = myInv.RecName, Amount = myInv.CustomerAmount, PlateNo = Inv.PlateNo, Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = "-1", Customer = myInv.Customer, CustomerAmount = myInv.CustomerAmount, SiteAmount = 0 });
                            }
                            else
                            {
                                if (vJvamount == myInv.SiteAmount)
                                {
                                    //if (myInv.SiteAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv.VouNo, InvoiceVouLoc = myInv.VouLoc, Name = myInv.RecName, Amount = myInv.SiteAmount, PlateNo = Inv.PlateNo, Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = myInv.Site, Customer = myInv.Customer, SiteAmount = myInv.SiteAmount, CustomerAmount = 0 });
                                    if (myInv.CustomerAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv.VouNo, InvoiceVouLoc = myInv.VouLoc, Name = myInv.RecName, Amount = myInv.CustomerAmount, PlateNo = Inv.PlateNo, Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = "-1", Customer = myInv.Customer, CustomerAmount = myInv.CustomerAmount, SiteAmount = 0 });
                                }
                                else
                                {
                                    if (myInv.SiteAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv.VouNo, InvoiceVouLoc = myInv.VouLoc, Name = myInv.RecName, Amount = myInv.SiteAmount, PlateNo = Inv.PlateNo, Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = myInv.Site, Customer = myInv.Customer, SiteAmount = myInv.SiteAmount, CustomerAmount = 0 });
                                }
                            }
                        }
                        else
                        {
                            if (myInv.SiteAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv.VouNo, InvoiceVouLoc = myInv.VouLoc, Name = myInv.RecName, Amount = myInv.SiteAmount, PlateNo = myInv.PlateNo.Replace('@', '-'), Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = myInv.Site, Customer = myInv.Customer, SiteAmount = myInv.SiteAmount, CustomerAmount = 0 });
                            if (myInv.CustomerAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv.VouNo, InvoiceVouLoc = myInv.VouLoc, Name = myInv.RecName, Amount = myInv.CustomerAmount, PlateNo = myInv.PlateNo.Replace('@', '-'), Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = "-1", Customer = myInv.Customer, CustomerAmount = myInv.CustomerAmount, SiteAmount = 0 });
                        }
                    }
                    SavemyCookie();
                    MakeSum();
                    LoadVouData();
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
                string FNo = grdCodes.DataKeys[e.RowIndex]["FNo"].ToString();
                VouData.RemoveAt(int.Parse(FNo)-1);
                for (int i = 0; i < VouData.Count; i++)
                {
                    VouData[i].FNo = i+1;
                }
                SavemyCookie();
                e.Cancel = false;                
                MakeSum();                
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

        private void MakeSum()
        {
            try
            {
                ValidateNum();
                if (rdoType.SelectedValue != "1")
                {
                    double Amount = 0;
                    foreach (myInv2 itm in VouData)
                    {
                        Amount += (double)itm.Amount;
                    }
                    txtAmount.Text = string.Format("{0:N2}", Amount);

                    if (txtLand.Text == "") txtLand.Text = string.Format("{0:N2}", 0);
                    if (txtOthers.Text == "") txtOthers.Text = string.Format("{0:N2}", 0);
                    if (txtDiscount.Text == "") txtDiscount.Text = string.Format("{0:N2}", 0);
                    txtNet.Text = string.Format("{0:N2}", moh.StrToDouble(txtAmount.Text) + moh.StrToDouble(txtCust.Text) + moh.StrToDouble(txtLand.Text) + moh.StrToDouble(txtOthers.Text) - moh.StrToDouble(txtDiscount.Text));
                }
                else
                {
                    if (txtLand.Text == "") txtLand.Text = string.Format("{0:N2}", 0);
                    if (txtOthers.Text == "") txtOthers.Text = string.Format("{0:N2}", 0);
                    if (txtDiscount.Text == "") txtDiscount.Text = string.Format("{0:N2}", 0);
                    txtNet.Text = string.Format("{0:N2}", moh.StrToDouble(txtAmount.Text) + moh.StrToDouble(txtLand.Text) + moh.StrToDouble(txtOthers.Text) - moh.StrToDouble(txtDiscount.Text));
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

        protected void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MakeSum();
                /*
                if (txtAmount.Text == "") txtAmount.Text = string.Format("{0:N2}", 0);
                if (txtLand.Text == "") txtLand.Text = string.Format("{0:N2}", 0);
                if (txtCust.Text == "") txtCust.Text = string.Format("{0:N2}", 0);
                if (txtDiscount.Text == "") txtDiscount.Text = string.Format("{0:N2}", 0);
                if (txtOthers.Text == "") txtOthers.Text = string.Format("{0:N2}", 0);
                txtNet.Text = string.Format("{0:N2}", moh.StrToDouble(txtAmount.Text) + moh.StrToDouble(txtCust.Text) + moh.StrToDouble(txtLand.Text) - moh.StrToDouble(txtDiscount.Text));
                 */
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

        protected void rdoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtAmount.ReadOnly = (rdoType.SelectedValue == "0" || rdoType.SelectedValue == "2");
                divGrid.Visible = (rdoType.SelectedValue == "0" || rdoType.SelectedValue == "2");
                BtnRecovery.Visible = (rdoType.SelectedValue == "0" || rdoType.SelectedValue == "2");
                lblClaim.Visible = (rdoType.SelectedValue == "0");
                ddlClaim.Visible = (rdoType.SelectedValue == "0");

                Label18.Visible = (rdoType.SelectedValue == "0");
                txtCust.Visible = (rdoType.SelectedValue == "0");
                CompareValidator4.Visible = (rdoType.SelectedValue == "0");
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
                        myArch.DocType = 505;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(AreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 505;
                        myArch.FileName = FileUpload1.FileName;
                        myArch.FileName2 = mySetting.ImagePath2 + FileName;
                        myArch.FNo = (short)i;
                        myArch.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
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
                myArch.DocType = 505;
                myArch.FNo = short.Parse(FNo);
                myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

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
                myArch.LocNumber = short.Parse(AreaNo);
                myArch.Number = txtVouNo.Text != "" ? int.Parse(txtVouNo.Text) : 9999999;
                myArch.DocType = 505;
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
            if (txtDiscount.Text == "") txtDiscount.Text = "0";
            if (txtNet.Text == "") txtNet.Text = "0";
        }

        protected void rdoPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblChqNo.Visible = (rdoPayment.SelectedIndex == 1);
                lblChqDate.Visible = (rdoPayment.SelectedIndex == 1);
                lblBankName.Visible = (rdoPayment.SelectedIndex == 1);

                ValchqNo.Enabled = (rdoPayment.SelectedIndex == 1);
                ValChqDate.Enabled = (rdoPayment.SelectedIndex == 1);
                ValBankName.Enabled = (rdoPayment.SelectedIndex == 1);

                txtchqNo.Visible = (rdoPayment.SelectedIndex == 1);
                txtChqDate.Visible = (rdoPayment.SelectedIndex == 1);
                txtBankName.Visible = (rdoPayment.SelectedIndex == 1);
                if (rdoPayment.SelectedIndex == 0) ddlDbCode.SelectedValue = SiteInfo.CashAcc;
                else if (rdoPayment.SelectedIndex == 1) ddlDbCode.SelectedValue = SiteInfo.CashAcc;
                else if (rdoPayment.SelectedIndex == 2) ddlDbCode.SelectedValue = moh.MadaAcc;
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

        protected void BtnRecovery_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["RVou1"] != null)
                {
                    var serializer = new JavaScriptSerializer();
                    var deserializedResult = serializer.Deserialize<List<myInv2>>(Request.Cookies["RVou1"].Value);
                    VouData = deserializedResult;
                    LoadVouData();
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

        public void SavemyCookie()
        {
            try
            {
                string myObjectJson = new JavaScriptSerializer().Serialize(VouData);
                Response.Cookies["RVou1"].Value = myObjectJson;
                Response.Cookies["RVou1"].Expires = DateTime.Now.AddDays(10);
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

        public void DeletemyCookie()
        {
            try
            {
                if (Request.Cookies["RVou1"] != null)
                {
                    HttpCookie currentUserCookie = HttpContext.Current.Request.Cookies["RVou1"];
                    HttpContext.Current.Response.Cookies.Remove("RVou1");
                    currentUserCookie.Expires = DateTime.Now.AddDays(-10);
                    currentUserCookie.Value = null;
                    HttpContext.Current.Response.SetCookie(currentUserCookie);
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

        protected void ddlClaim_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlClaim.SelectedIndex > 0)
                {
                    Claim myClaim = new Claim();
                    myClaim.DocNo = int.Parse(ddlClaim.SelectedValue);
                    foreach (Claim itm in myClaim.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        bool Getit = false;
                        for (int i = 0; i < VouData.Count; i++)
                        {
                            if (itm.InvLoc == 0 && VouData[i].VouNo == itm.InvNo)
                            {
                                Getit = true;
                                break;
                            }
                            else if (VouData[i].VouNo == itm.InvNo && short.Parse(VouData[i].InvoiceVouLoc) == itm.InvLoc && VouData[i].Flag == itm.Flag)
                            {
                                Getit = true;
                                break;
                            }
                        }
                        if (Getit) continue;

                        if (txtPerson.Text == "")
                        {
                            Acc myAcc = new Acc();
                            myAcc.Branch = short.Parse(Session["Branch"].ToString());
                            myAcc.Code = itm.CustCode;
                            if (myAcc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                txtPerson.Text = myAcc.Name1;
                            }
                        }

                        if (itm.InvLoc == 0)
                        {
                            Jv mJv = new Jv();
                            mJv.Branch = short.Parse(Session["Branch"].ToString());
                            mJv.FType = 100;
                            mJv.LocNumber = 1;
                            mJv.LocType = 1;
                            mJv.Number = (int)itm.InvNo;
                            mJv = (from sitm in mJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                   where sitm.DbCode == itm.CustCode
                                   select sitm).FirstOrDefault();
                            if (mJv != null)
                            {
                                Acc myAcc = new Acc();
                                myAcc.Branch = short.Parse(Session["Branch"].ToString());
                                myAcc.Code = mJv.DbCode;
                                myAcc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = (int)itm.InvNo, InvoiceVouLoc = "00000", Flag = "", 
                                    Name = myAcc.Name1, Amount = mJv.Amount, PlateNo = "", Destination = "تسوية", DestinationName1 = "تسوية", DestinationName2 = "Adjust", Site = "-1", Customer = mJv.DbCode, SiteAmount = 0, CustomerAmount = mJv.Amount, Claim = int.Parse(ddlClaim.SelectedValue) });
                            }
                        }
                        else
                        {
                            if (itm.Flag == "L")
                            {
                                LShipment myInv2 = new LShipment();
                                myInv2.Branch = short.Parse(Session["Branch"].ToString());
                                myInv2.VouLoc = moh.MakeMask(itm.InvLoc.ToString(), 5);
                                myInv2.VouNo = (int)itm.InvNo;
                                myInv2 = myInv2.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (myInv2 != null)
                                {
                                    Cities myCity = new Cities();
                                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                                    myCity.Code = myInv2.Destination;
                                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                    myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                              where sitm.Code == myCity.Code
                                              select sitm).FirstOrDefault();
                                    if (myCity == null)
                                    {
                                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                        LblCodesResult.Text = "رقم الفاتورة غير مدرج من قبل";
                                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                        return;
                                    }

                                    if (myInv2.CustomerAmount > 0)
                                    {
                                        if (myInv2.SiteAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv2.VouNo, InvoiceVouLoc = myInv2.VouLoc, Flag = "L", Name = myInv2.RecName, Amount = myInv2.SiteAmount, PlateNo = "", Destination = myInv2.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = myInv2.Site, Customer = myInv2.Customer, SiteAmount = myInv2.SiteAmount, CustomerAmount = 0, Claim = int.Parse(ddlClaim.SelectedValue) });
                                        if (myInv2.CustomerAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv2.VouNo, InvoiceVouLoc = myInv2.VouLoc, Flag = "L", Name = myInv2.RecName, Amount = myInv2.CustomerAmount, PlateNo = "", Destination = myInv2.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = "-1", Customer = myInv2.Customer, CustomerAmount = myInv2.CustomerAmount, SiteAmount = 0, Claim = int.Parse(ddlClaim.SelectedValue) });
                                    }
                                }
                            }
                            else if (itm.Flag == "E")
                            {
                                Shipment myInv2 = new Shipment();
                                myInv2.Branch = short.Parse(Session["Branch"].ToString());
                                myInv2.VouLoc = moh.MakeMask(itm.InvLoc.ToString(), 5);
                                myInv2.VouNo = (int)itm.InvNo;
                                myInv2 = myInv2.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (myInv2 != null)
                                {
                                    Cities myCity = new Cities();
                                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                                    myCity.Code = myInv2.Destination;
                                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                    myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                              where sitm.Code == myCity.Code
                                              select sitm).FirstOrDefault();
                                    if (myCity == null)
                                    {
                                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                        LblCodesResult.Text = "رقم الفاتورة غير مدرج من قبل";
                                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                        return;
                                    }

                                    if (myInv2.CustomerAmount > 0)
                                    {
                                        if (myInv2.SiteAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv2.VouNo, InvoiceVouLoc = myInv2.VouLoc, Flag = "E", Name = myInv2.RecName, Amount = myInv2.SiteAmount, PlateNo = "", Destination = myInv2.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = myInv2.Site, Customer = myInv2.Customer, SiteAmount = myInv2.SiteAmount, CustomerAmount = 0, Claim = int.Parse(ddlClaim.SelectedValue) });
                                        if (myInv2.CustomerAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv2.VouNo, InvoiceVouLoc = myInv2.VouLoc, Flag = "E", Name = myInv2.RecName, Amount = myInv2.CustomerAmount, PlateNo = "", Destination = myInv2.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = "-1", Customer = myInv2.Customer, CustomerAmount = myInv2.CustomerAmount, SiteAmount = 0, Claim = int.Parse(ddlClaim.SelectedValue) });
                                    }
                                }
                            }
                            else
                            {
                                Invoice myInv = new Invoice();
                                myInv.Branch = short.Parse(Session["Branch"].ToString());
                                myInv.VouLoc = moh.MakeMask(itm.InvLoc.ToString(), 5);
                                myInv.VouNo = (int)itm.InvNo;
                                myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (myInv != null)
                                {
                                    Cities myCity = new Cities();
                                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                                    myCity.Code = myInv.Destination;
                                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                    myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                              where sitm.Code == myCity.Code
                                              select sitm).FirstOrDefault();
                                    if (myCity == null)
                                    {
                                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                        LblCodesResult.Text = "رقم الفاتورة غير مدرج من قبل";
                                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                        return;
                                    }

                                    if (myInv.CustomerAmount > 0)
                                    {
                                        InvDetails Inv = new InvDetails();
                                        Inv.Branch = short.Parse(Session["Branch"].ToString());
                                        Inv.VouLoc = myInv.VouLoc;
                                        Inv.VouNo = myInv.VouNo;
                                        Inv.FNo = 1;
                                        Inv = Inv.GetFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if (Inv != null)
                                        {
                                            if (myInv.SiteAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv.VouNo, InvoiceVouLoc = myInv.VouLoc, Name = myInv.RecName, Amount = myInv.SiteAmount, PlateNo = Inv.PlateNo, Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = myInv.Site, Customer = myInv.Customer, SiteAmount = myInv.SiteAmount, CustomerAmount = 0, Claim = int.Parse(ddlClaim.SelectedValue) });
                                            if (myInv.CustomerAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv.VouNo, InvoiceVouLoc = myInv.VouLoc, Name = myInv.RecName, Amount = myInv.CustomerAmount, PlateNo = Inv.PlateNo, Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = "-1", Customer = myInv.Customer, CustomerAmount = myInv.CustomerAmount, SiteAmount = 0, Claim = int.Parse(ddlClaim.SelectedValue) });
                                        }
                                        else
                                        {
                                            if (myInv.SiteAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv.VouNo, InvoiceVouLoc = myInv.VouLoc, Name = myInv.RecName, Amount = myInv.SiteAmount, PlateNo = myInv.PlateNo.Replace('@', '-'), Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = myInv.Site, Customer = myInv.Customer, SiteAmount = myInv.SiteAmount, CustomerAmount = 0, Claim = int.Parse(ddlClaim.SelectedValue) });
                                            if (myInv.CustomerAmount > 0) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myInv.VouNo, InvoiceVouLoc = myInv.VouLoc, Name = myInv.RecName, Amount = myInv.CustomerAmount, PlateNo = myInv.PlateNo.Replace('@', '-'), Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, Site = "-1", Customer = myInv.Customer, CustomerAmount = myInv.CustomerAmount, SiteAmount = 0, Claim = int.Parse(ddlClaim.SelectedValue) });
                                        }
                                    }
                                }
                            }
                        }
                    }
                    SavemyCookie();
                    MakeSum();
                    LoadVouData();
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

        public void UpdateCache()
        {
            if (Cache["ClaimPending" + Session["CNN2"].ToString()] != null) Cache.Remove("ClaimPending" + Session["CNN2"].ToString());
            Claim myClaim = new Claim();
            myClaim.DocLoc = -1;
            Cache.Insert("ClaimPending" + Session["CNN2"].ToString(), myClaim.GetPending(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
        }

        protected void ChkCashAmount_CheckedChanged(object sender, EventArgs e)
        {
            txtCashAmount.Text = (ChkCashAmount.Checked ? string.Format("{0:N2}", moh.StrToDouble(this.txtNet.Text) - moh.StrToDouble(txtShAmount.Text)) : "0");
            if (ChkCashAmount.Checked)
            {
                ChkShAmount.Checked = false;
            }
        }

        protected void ChkShAmount_CheckedChanged(object sender, EventArgs e)
        {
            txtShAmount.Text = (ChkShAmount.Checked ? string.Format("{0:N2}", moh.StrToDouble(this.txtNet.Text) - moh.StrToDouble(txtCashAmount.Text)) : "0");
            if (ChkShAmount.Checked)
            {
                ChkCashAmount.Checked = false;
            }
        }
    }    
}
