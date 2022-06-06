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
    public partial class WebCarRCV : System.Web.UI.Page
    {
        public List<CarRcv> VouData
        {
            get
            {
                if (ViewState["VouData"] == null)
                {
                    ViewState["VouData"] = new List<CarRcv>();
                }
                return (List<CarRcv>)ViewState["VouData"];
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

            BtnPrint.Visible = true && (Request.QueryString["Support"] != null || (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass235);
            BtnEdit.Visible = true && Request.QueryString["Support"] == null && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass232;
            BtnNew.Visible = false;
            BtnDelete.Visible = true && Request.QueryString["Support"] == null && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass233;
            if (Request.QueryString["Flag"] != null)
            {
                if (Request.QueryString["Flag"].ToString() == "0")
                {
                    if (Request.QueryString["Support"] != null || !(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass40)
                    {
                        BtnEdit.Visible = false;
                        BtnDelete.Visible = false;
                        BtnClear.Visible = false;
                    }
                }
            }
            if (Request.QueryString["Support"] != null || !(bool)((List<TblRoles>)(Session["Roll"]))[1].Pass232) ControlsOnOff(false);
        }

        public void NewMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = true && Request.QueryString["Support"] == null && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass231;
            BtnDelete.Visible = false;
            if (Request.QueryString["Support"] != null || !(bool)((List<TblRoles>)(Session["Roll"]))[1].Pass232) ControlsOnOff(true);
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
                    this.Page.Header.Title = "سند أستلام سيارة";
                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "الرئيسية", "اختيار", "اختيار سند استلام سيارة", "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

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
                        BtnNew.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass231;
                        BtnEdit.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass232;
                        BtnDelete.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass233;
                        BtnSearch.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass234;
                        BtnFind.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass234;
                        BtnPrint.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass235;
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
                                }
                            }
                        }
                        txtSearch.Text = Request.QueryString["FNum"].ToString();
                        BtnSearch_Click(sender, null);
                    }
                    else
                    {
                        BtnClear_Click(sender, null);

                        if (Request.QueryString["InvNo"] != null)
                        {
                            string vError = "";
                            if (Request.QueryString["InvNo"].ToString()[0] == 'E')
                            {
                                string vNo2 = Request.QueryString["InvNo"].ToString().Substring(1, Request.QueryString["InvNo"].ToString().Length - 1);
                                Shipment myInv = new Shipment();
                                myInv.Branch = short.Parse(Session["Branch"].ToString());
                                myInv.VouLoc = moh.MakeMask(vNo2.Split('/')[0], 5);
                                myInv.VouNo = int.Parse(vNo2.Split('/')[1]);
                                myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (myInv == null)
                                {
                                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                    LblCodesResult.Text = "رقم الفاتورة غير مدرج من قبل";
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                    return;
                                }
                                else if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass236 && myInv.Destination != SiteInfo.City)
                                {
                                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                    LblCodesResult.Text = "جهة التسليم في الفاتورة تختلف عن موقعك";
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                    return;
                                }

                                // Check Invoice Debit
                                if (myInv.SiteAmount != 0)
                                {
                                    bool vDebit = true;
                                    Jv vJv = new Jv();
                                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                                    vJv.FType = 101;
                                    vJv.LocType = 2;
                                    vJv.LocNumber = short.Parse(AreaNo);
                                    vJv.InvNo = Request.QueryString["InvNo"].ToString();
                                    vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (vJv != null)
                                    {
                                        vDebit = false;
                                        //if ((myInv.SiteAmount > 0 && vJv.Amount == (double)myInv.SiteAmount) || (myInv.CustomerAmount > 0 && vJv.Amount == (double)myInv.CustomerAmount))
                                    }
                                    if (vDebit)
                                    {
                                        vDebit = true;
                                        vJv = new Jv();
                                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                                        vJv.FType = 100;
                                        vJv.LocType = 1;
                                        vJv.LocNumber = short.Parse(AreaNo);
                                        vJv.InvNo = Request.QueryString["InvNo"].ToString();
                                        vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if (vJv != null)
                                        {
                                            vDebit = false;
                                            //if ((myInv.SiteAmount > 0 && vJv.Amount == (double)myInv.SiteAmount) || (myInv.CustomerAmount > 0 && vJv.Amount == (double)myInv.CustomerAmount))
                                        }
                                        if (vDebit)
                                        {
                                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                            LblCodesResult.Text = "الفاتورة عليها مديونية بمبلغ " + myInv.SiteAmount.ToString() + " يجب أجراء سند قبض قيل التسليم ";
                                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                            //if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass226) return;
                                        }
                                    }
                                }
                                // End of Check Invoice 

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
                                    LblCodesResult.Text = "الجهة غير مدرجه من قبل";
                                    return;
                                }
                                
                                CarMove myCarMove = new CarMove();
                                myCarMove.Branch = short.Parse(Session["Branch"].ToString());
                                myCarMove.InvoiceVouLoc = myInv.VouLoc;
                                myCarMove.InvoiceNo = myInv.VouNo;
                                myCarMove.InvoiceFNo = 1;
                                myCarMove.Flag = "E";
                                bool vAdd = false;
                                foreach (CarMove CarMoves in myCarMove.GetByInv(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                {
                                    vAdd = false;
                                    CarMoveRCV mRCV = new CarMoveRCV();
                                    mRCV.Branch = short.Parse(Session["Branch"].ToString());
                                    mRCV.CarMove = short.Parse(CarMoves.VouLoc).ToString() + '/' + CarMoves.Number.ToString();
                                    mRCV = mRCV.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (mRCV != null) vAdd = true;
                                    else break;
                                }

                                if (vAdd)
                                {
                                    CarRcv vCarRcv = new CarRcv();
                                    vCarRcv.Branch = short.Parse(Session["Branch"].ToString());

                                    vCarRcv.LocNumber = short.Parse(AreaNo);
                                    vCarRcv.InvNo = Request.QueryString["InvNo"].ToString();
                                    vCarRcv.InvFNo = 1;
                                    vCarRcv = vCarRcv.GetByInvFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (vCarRcv == null)
                                    {
                                        VouData.Add(new CarRcv { FNo = (short)(VouData.Count() + 1), LocNumber = short.Parse(AreaNo), InvNo = Request.QueryString["InvNo"].ToString(), Name = myInv.Name, PlateNo = "مغلف", Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, InvFNo = 1 });
                                        txtCustomer.Text = myInv.RecName;
                                    }
                                    else
                                    {
                                        vError += "تم تسليم الشحنة " + "مغلف" + " ببيان تسليم رقم " + @"<a href='WebCarRCV.aspx?Flag=0&AreaNo=" + moh.MakeMask(vCarRcv.LocNumber.ToString(), 5) + @"&FNum=" + vCarRcv.Number.ToString() + @"' target='_blank'>" + vCarRcv.LocNumber.ToString() + '/' + vCarRcv.Number.ToString() + @"</a><br/>";
                                    }
                                }
                            }
                            else if (Request.QueryString["InvNo"].ToString()[0] == 'L')
                            {
                                string vNo2 = Request.QueryString["InvNo"].ToString().Substring(1, Request.QueryString["InvNo"].ToString().Length - 1);
                                LShipment myInv = new LShipment();
                                myInv.Branch = short.Parse(Session["Branch"].ToString());
                                myInv.VouLoc = moh.MakeMask(vNo2.Split('/')[0], 5);
                                myInv.VouNo = int.Parse(vNo2.Split('/')[1]);
                                myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (myInv == null)
                                {
                                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                    LblCodesResult.Text = "رقم الفاتورة غير مدرج من قبل";
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                    return;
                                }
                                else if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass236 && myInv.Destination != SiteInfo.City)
                                {
                                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                    LblCodesResult.Text = "جهة التسليم في الفاتورة تختلف عن موقعك";
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                    return;
                                }

                                // Check Invoice Debit
                                if (myInv.SiteAmount != 0)
                                {
                                    bool vDebit = true;
                                    Jv vJv = new Jv();
                                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                                    vJv.FType = 101;
                                    vJv.LocType = 2;
                                    vJv.LocNumber = short.Parse(AreaNo);
                                    vJv.InvNo = Request.QueryString["InvNo"].ToString();
                                    vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (vJv != null)
                                    {
                                        vDebit = false;
                                        //if ((myInv.SiteAmount > 0 && vJv.Amount == (double)myInv.SiteAmount) || (myInv.CustomerAmount > 0 && vJv.Amount == (double)myInv.CustomerAmount))
                                    }
                                    if (vDebit)
                                    {
                                        vDebit = true;
                                        vJv = new Jv();
                                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                                        vJv.FType = 100;
                                        vJv.LocType = 1;
                                        vJv.LocNumber = short.Parse(AreaNo);
                                        vJv.InvNo = Request.QueryString["InvNo"].ToString();
                                        vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if (vJv != null)
                                        {
                                            vDebit = false;
                                            //if ((myInv.SiteAmount > 0 && vJv.Amount == (double)myInv.SiteAmount) || (myInv.CustomerAmount > 0 && vJv.Amount == (double)myInv.CustomerAmount))
                                        }
                                        if (vDebit)
                                        {
                                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                            LblCodesResult.Text = "الفاتورة عليها مديونية بمبلغ " + myInv.SiteAmount.ToString() + " يجب أجراء سند قبض قيل التسليم ";
                                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                            //if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass226) return;
                                        }
                                    }
                                }
                                // End of Check Invoice 

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
                                    LblCodesResult.Text = "الجهة غير مدرجه من قبل";
                                    return;
                                }

                                ShipDetails myInvD = new ShipDetails();
                                myInvD.Branch = short.Parse(Session["Branch"].ToString());
                                myInvD.VouLoc = myInv.VouLoc;
                                myInvD.VouNo = myInv.VouNo;
                                foreach (ShipDetails Invd in myInvD.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                {
                                    CarMove myCarMove = new CarMove();
                                    myCarMove.Branch = short.Parse(Session["Branch"].ToString());
                                    myCarMove.InvoiceVouLoc = myInv.VouLoc;
                                    myCarMove.InvoiceNo = myInv.VouNo;
                                    myCarMove.Flag = "L";
                                    myCarMove.InvoiceFNo = Invd.FNo;

                                    bool vAdd = false;
                                    foreach (CarMove CarMoves in myCarMove.GetByInv(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        vAdd = false;
                                        CarMoveRCV mRCV = new CarMoveRCV();
                                        mRCV.Branch = short.Parse(Session["Branch"].ToString());
                                        mRCV.CarMove = short.Parse(CarMoves.VouLoc).ToString() + '/' + CarMoves.Number.ToString();
                                        mRCV = mRCV.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if (mRCV != null) vAdd = true;
                                        else break;
                                    }

                                    if (vAdd)
                                    {
                                        CarRcv vCarRcv = new CarRcv();
                                        vCarRcv.Branch = short.Parse(Session["Branch"].ToString());

                                        vCarRcv.LocNumber = short.Parse(AreaNo);
                                        vCarRcv.InvNo = Request.QueryString["InvNo"].ToString();
                                        vCarRcv.InvFNo = Invd.FNo;
                                        vCarRcv = vCarRcv.GetByInvFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if (vCarRcv == null)
                                        {
                                            VouData.Add(new CarRcv { FNo = (short)(VouData.Count() + 1), LocNumber = short.Parse(AreaNo), InvNo = Request.QueryString["InvNo"].ToString(), Name = myInv.Name, PlateNo = Invd.Name, Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, InvFNo = Invd.FNo });
                                            txtCustomer.Text = myInv.RecName;
                                        }
                                        else
                                        {
                                            vError += "تم تسليم الشحنة " + Invd.Name + " ببيان تسليم رقم " + @"<a href='WebCarRCV.aspx?Flag=0&AreaNo=" + moh.MakeMask(vCarRcv.LocNumber.ToString(), 5) + @"&FNum=" + vCarRcv.Number.ToString() + @"' target='_blank'>" + vCarRcv.LocNumber.ToString() + '/' + vCarRcv.Number.ToString() + @"</a><br/>";
                                        }
                                    }
                                }
                            }
                            else
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
                                else if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass236 && myInv.Destination != SiteInfo.City)
                                {
                                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                    LblCodesResult.Text = "جهة التسليم في الفاتورة تختلف عن موقعك";
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                    return;
                                }

                                // Check Invoice Debit
                                if (myInv.SiteAmount != 0)
                                {
                                    bool vDebit = true;
                                    Jv vJv = new Jv();
                                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                                    vJv.FType = 101;
                                    vJv.LocType = 2;
                                    vJv.LocNumber = short.Parse(AreaNo);
                                    vJv.InvNo = Request.QueryString["InvNo"].ToString();
                                    vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (vJv != null)
                                    {
                                        vDebit = false;
                                        //if ((myInv.SiteAmount > 0 && vJv.Amount == (double)myInv.SiteAmount) || (myInv.CustomerAmount > 0 && vJv.Amount == (double)myInv.CustomerAmount))
                                    }
                                    if (vDebit)
                                    {
                                        vDebit = true;
                                        vJv = new Jv();
                                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                                        vJv.FType = 100;
                                        vJv.LocType = 1;
                                        vJv.LocNumber = short.Parse(AreaNo);
                                        vJv.InvNo = Request.QueryString["InvNo"].ToString();
                                        vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if (vJv != null)
                                        {
                                            vDebit = false;
                                            //if ((myInv.SiteAmount > 0 && vJv.Amount == (double)myInv.SiteAmount) || (myInv.CustomerAmount > 0 && vJv.Amount == (double)myInv.CustomerAmount))
                                        }
                                        if (vDebit)
                                        {
                                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                            LblCodesResult.Text = "الفاتورة عليها مديونية بمبلغ " + myInv.SiteAmount.ToString() + " يجب أجراء سند قبض قيل التسليم ";
                                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                            //if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass226) return;
                                        }
                                    }
                                }
                                // End of Check Invoice 

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
                                    LblCodesResult.Text = "الجهة غير مدرجه من قبل";
                                    return;
                                }
                                
                                InvDetails myInvD = new InvDetails();
                                myInvD.Branch = short.Parse(Session["Branch"].ToString());
                                myInvD.VouLoc = myInv.VouLoc;
                                myInvD.VouNo = myInv.VouNo;
                                foreach (InvDetails Invd in myInvD.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                {
                                    CarMove myCarMove = new CarMove();
                                    myCarMove.Branch = short.Parse(Session["Branch"].ToString());
                                    myCarMove.InvoiceVouLoc = myInv.VouLoc;
                                    myCarMove.InvoiceNo = myInv.VouNo;
                                    myCarMove.InvoiceFNo = Invd.FNo;

                                    bool vAdd = false;
                                    foreach (CarMove CarMoves in myCarMove.GetByInv(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        vAdd = false;
                                        CarMoveRCV mRCV = new CarMoveRCV();
                                        mRCV.Branch = short.Parse(Session["Branch"].ToString());
                                        mRCV.CarMove = short.Parse(CarMoves.VouLoc).ToString() + '/' + CarMoves.Number.ToString();
                                        mRCV = mRCV.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if (mRCV != null) vAdd = true;
                                        else break;
                                    }

                                    if (vAdd)
                                    {
                                        CarRcv vCarRcv = new CarRcv();
                                        vCarRcv.Branch = short.Parse(Session["Branch"].ToString());

                                        vCarRcv.LocNumber = short.Parse(AreaNo);
                                        vCarRcv.InvNo = Request.QueryString["InvNo"].ToString();
                                        vCarRcv.InvFNo = Invd.FNo;
                                        vCarRcv = vCarRcv.GetByInvFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if (vCarRcv == null)
                                        {
                                            VouData.Add(new CarRcv { FNo = (short)(VouData.Count() + 1), LocNumber = short.Parse(AreaNo), InvNo = Request.QueryString["InvNo"].ToString(), Name = myInv.Name, PlateNo = Invd.PlateNo, Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, InvFNo = Invd.FNo });
                                            txtCustomer.Text = myInv.RecName;
                                        }
                                        else
                                        {
                                            vError += "تم تسليم السيارة " + Invd.PlateNo + " ببيان تسليم رقم " + @"<a href='WebCarRCV.aspx?Flag=0&AreaNo=" + moh.MakeMask(vCarRcv.LocNumber.ToString(), 5) + @"&FNum=" + vCarRcv.Number.ToString() + @"' target='_blank'>" + vCarRcv.LocNumber.ToString() + '/' + vCarRcv.Number.ToString() + @"</a><br/>";
                                        }
                                    }
                                }
                            }
                            LoadVouData();
                            if (vError != "")
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = vError;
                                //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
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

        protected void BtnClear_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                NewMode();
                txtSearch.Text = "";
                txtVouNo.Text = "";
                txtVouDate.Text = "";
                txtRemark.Text = "";
                txtGTime.Text = "";
                txtCustomer.Text = "";
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                if (sender != null)
                {
                    CarRcv myJv = new CarRcv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.LocNumber = short.Parse(AreaNo);
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
                txtGTime.Text = String.Format("{0:HH:mm:ss}", moh.Nows());  //moh.Nows().ToShortTimeString();
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
            txtRemark.ReadOnly = !State;
            txtGTime.ReadOnly = !State;
            txtCustomer.ReadOnly = !State;
            txtVouDate.ReadOnly = !State;
            txtGTime.ReadOnly = !State;
            //grdAttach.Enabled = State;
            foreach (GridViewRow itm in grdAttach.Rows)
            {
                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                if (BtnDelete != null) BtnDelete.Visible = State;
            }
            grdCodes.Enabled = State;
            FileUpload1.Enabled = State;
            BtnAttach.Enabled = State;
        }

        protected void LoadVouData()
        {
            try
            {
                grdCodes.DataSource = VouData;
                grdCodes.DataBind();
                if (grdCodes.Rows.Count < 1)
                {
                    CarRcv inv = new CarRcv();
                    List<CarRcv> Listax = new List<CarRcv>();
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
                            if(VouData.Count()<1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }
                    }

                    BtnNew.Enabled = false;
                    CarRcv myJv = new CarRcv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.LocNumber = short.Parse(AreaNo);
                    myJv.Number = int.Parse(txtVouNo.Text);
                    myJv = myJv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myJv != null)
                    {
                        if (myJv.UserName == txtUserName.ToolTip)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم السند مكرر";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }
                        else
                        {
                            myJv = new CarRcv();
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.LocNumber = short.Parse(AreaNo);
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

                    if (VouData.Count() > 0)
                    {
                        CarRcv vCarRcv = new CarRcv();
                        vCarRcv.Branch = short.Parse(Session["Branch"].ToString());

                        vCarRcv.LocNumber = short.Parse(AreaNo);
                        vCarRcv.InvNo = VouData[0].InvNo;
                        vCarRcv.InvFNo = VouData[0].InvFNo;
                        vCarRcv = vCarRcv.GetByInvFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (vCarRcv != null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "تم تسليم السيارة " + VouData[0].PlateNo + " ببيان تسليم رقم " + @"<a href='WebCarRCV.aspx?Flag=0&AreaNo=" + moh.MakeMask(vCarRcv.LocNumber.ToString(), 5) + @"&FNum=" + vCarRcv.Number.ToString() + @"' target='_blank'>" + vCarRcv.LocNumber.ToString() + '/' + vCarRcv.Number.ToString() + @"</a><br/>";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }
                    }

                    if (Saveall())
                    {
                        if (HttpRuntime.Cache["OverCarsIn_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarsIn_" + AreaNo + Session["CNN2"].ToString());
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";

                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "سند استلام سيارة", "اضافة", "اضافة سند استلام سيارة رقم " + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        string vNumber = txtVouNo.Text;
                        BtnClear_Click(sender, e);
                        BtnNew.Enabled = true;
                        PrintMe(vNumber);
                    }
                    else
                    {
                        BtnNew.Enabled = true;
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
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

                    CarRcv myJv = new CarRcv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.LocNumber = short.Parse(AreaNo);
                    myJv.Number = int.Parse(txtVouNo.Text);
                    myJv = myJv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myJv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم السند غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    }
                    else
                    {
                        EditMode();
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.LocNumber = short.Parse(AreaNo);
                        myJv.Number = int.Parse(txtVouNo.Text);
                        if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (Saveall())
                            {
                                if (HttpRuntime.Cache["OverCarsIn_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarsIn_" + AreaNo + Session["CNN2"].ToString());
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";

                                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "سند استلام سيارة", "تعديل", "تعديل سند استلام سيارة رقم " + lblBranch2.Text + "/" + txtVouNo.Text, txtReason.Text, IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                txtReason.Text = "";

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

                    CarRcv myJv = new CarRcv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.LocNumber = short.Parse(AreaNo);
                    myJv.Number = int.Parse(txtVouNo.Text);
                    myJv = myJv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myJv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم السند غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    }
                    else
                    {
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.LocNumber = short.Parse(AreaNo);
                        myJv.Number = int.Parse(txtVouNo.Text);
                        if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormAction = "الغاء";
                            UserTran.FormName = "بيان استلام";
                            UserTran.Description = "الغاء بيانات سند أستلام سيارة رقم " + txtVouNo.Text;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                            if (HttpRuntime.Cache["OverCarsIn_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarsIn_" + AreaNo + Session["CNN2"].ToString());

                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم الغاء البيانات بنجاح";

                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "سند استلام سيارة", "الغاء", "الغاء سند استلام سيارة رقم " + lblBranch2.Text + "/" + txtVouNo.Text, txtReason.Text, IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            txtReason.Text = "";

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

                    EditMode();
                    List<CarRcv> lJv = new List<CarRcv>();
                    CarRcv myJv = new CarRcv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.LocNumber = short.Parse(AreaNo);
                    myJv.Number = int.Parse(txtSearch.Text);
                    lJv = myJv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (lJv == null || lJv.Count == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم السند غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    }
                    else
                    {
                        txtVouNo.Text = txtSearch.Text;

                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "سند استلام سيارة", "عرض", "عرض سند استلام سيارة رقم " + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                        txtVouDate.Text = lJv[0].GDate;
                        txtGTime.Text = lJv[0].GTime;
                        txtCustomer.Text = lJv[0].Customer;
                        txtRemark.Text = lJv[0].Remark;
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
                        VouData.Clear();
                        for (int i = 0; i < lJv.Count(); i++)
                        {
                            if (lJv[i].InvNo[0] == 'L')
                            {
                                string InvNo = lJv[i].InvNo.Substring(1, lJv[i].InvNo.Length - 1);
                                LShipment myInv = new LShipment();
                                myInv.Branch = short.Parse(Session["Branch"].ToString());
                                myInv.VouLoc = moh.MakeMask(InvNo.Split('/')[0], 5);
                                myInv.VouNo = int.Parse(InvNo.Split('/')[1]);
                                myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                ShipDetails Inv = new ShipDetails();
                                Inv.Branch = short.Parse(Session["Branch"].ToString());
                                Inv.VouLoc = moh.MakeMask(InvNo.Split('/')[0], 5);
                                Inv.VouNo = int.Parse(InvNo.Split('/')[1]);
                                Inv.FNo = (short)lJv[i].InvFNo;
                                Inv = Inv.GetFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                if (myInv != null && Inv != null)
                                {
                                    Cities myCity = new Cities();
                                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));                    
                                    myCity.Code = myInv.Destination;
                                    myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                              where sitm.Code == myCity.Code
                                              select sitm).FirstOrDefault();
                                    if (myCity != null)
                                    {
                                        VouData.Add(new CarRcv { FNo = (short)(VouData.Count() + 1), InvNo = lJv[i].InvNo, Name = myInv.Name, PlateNo = Inv.Name, Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2 });
                                    }
                                }
                            }
                            else if (lJv[i].InvNo[0] == 'E')
                            {
                                string InvNo = lJv[i].InvNo.Substring(1, lJv[i].InvNo.Length - 1);
                                Shipment myInv = new Shipment();
                                myInv.Branch = short.Parse(Session["Branch"].ToString());
                                myInv.VouLoc = moh.MakeMask(InvNo.Split('/')[0], 5);
                                myInv.VouNo = int.Parse(InvNo.Split('/')[1]);
                                myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                if (myInv != null)
                                {
                                    Cities myCity = new Cities();
                                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));                    
                                    myCity.Code = myInv.Destination;
                                    myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                              where sitm.Code == myCity.Code
                                              select sitm).FirstOrDefault();
                                    if (myCity != null)
                                    {
                                        VouData.Add(new CarRcv { FNo = (short)(VouData.Count() + 1), InvNo = lJv[i].InvNo, Name = myInv.Name, PlateNo = "مغلف", Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2 });
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

                                InvDetails Inv = new InvDetails();
                                Inv.Branch = short.Parse(Session["Branch"].ToString());
                                Inv.VouLoc = moh.MakeMask(lJv[i].InvNo.Split('/')[0], 5);
                                Inv.VouNo = int.Parse(lJv[i].InvNo.Split('/')[1]);
                                Inv.FNo = (short)lJv[i].InvFNo;
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
                                        VouData.Add(new CarRcv { FNo = (short)(VouData.Count() + 1), InvNo = lJv[i].InvNo, Name = myInv.Name, PlateNo = Inv.PlateNo, Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2 });
                                    }
                                }
                            }
                        }
                        LoadVouData();
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
            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "سند استلام سيارة", "طباعة", "طباعة سند استلام سيارة رقم " + int.Parse(AreaNo).ToString() + "/" + Number, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=3&AreaNo=" + AreaNo + "&Number=" + Number + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
            return;
        }

        protected void BtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    string vNumber = txtVouNo.Text;
                    PrintMe(vNumber);
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
                    page.vStr1 = "سند أستلام";
                    page.vStr2 = "";

                    string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                    BaseFont nationalBase;
                    nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font nationalTextFont14 = new iTextSharp.text.Font(nationalBase, 14f, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font nationalTextFont16 = new iTextSharp.text.Font(nationalBase, 16f, iTextSharp.text.Font.NORMAL);

                    page.PageNo = "1";
                    page.UserName = Session["FullUser"].ToString();
                    page.vStr3 = Session["AreaName"].ToString();
                    //page.vStr4 = ((Label)this.Master.FindControl("LblBranchName")).Text;
                    int ColCount = 5;
                    var cols = new[] { 125, 100, 100, 200, 200 };

                    document.Open();

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
                    cell.Phrase = new iTextSharp.text.Phrase(" سند أستلام سيارة رقم ", nationalTextFont16);
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
                    cell.Border = 0;
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    table11.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table11.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;

                    cell.Phrase = new iTextSharp.text.Phrase("التاريخ:", nationalTextFont14);
                    table11.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(txtVouDate.Text, nationalTextFont);
                    table11.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("وقت التسليم:", nationalTextFont14);
                    table11.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(txtGTime.Text + (ChkDeleteInv.Checked ? "              الغاء فاتورة":""), nationalTextFont);
                    table11.AddCell(cell);

                    //
                    cell.Phrase = new iTextSharp.text.Phrase("اسم المستلم:", nationalTextFont14);
                    table11.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(txtCustomer.Text, nationalTextFont);
                    table11.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("ملاحظات:", nationalTextFont14);
                    table11.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(txtRemark.Text, nationalTextFont);
                    table11.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table11.AddCell(cell);
                    table11.AddCell(cell);
                    table11.AddCell(cell);
                    table11.AddCell(cell);
                    document.Add(table11);

                    cols = new[] { 150, 250, 120, 120, 50 };
                    PdfPTable table = new PdfPTable(5);
                    table.TotalWidth = document.PageSize.Width; //100f;
                    table.SetWidths(cols);
                    cell = new PdfPCell();
                    cell.FixedHeight = 20f;
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    //cell.Border = 0;
                    cell.Phrase = new iTextSharp.text.Phrase("م", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("رقم الفاتورة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("رقم اللوحة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("العميل", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("جهة الترحيل", nationalTextFont);
                    table.AddCell(cell);
                    //-------------------------------------------------------------------------------------------
                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    int FNo = 1;
                    if (grdCodes.Rows.Count > 0)
                    {
                        foreach (GridViewRow gvr in grdCodes.Rows)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(FNo.ToString(), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(VouData[FNo-1].InvNo, nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(VouData[FNo-1].PlateNo, nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(VouData[FNo-1].Name, nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(VouData[FNo - 1].DestinationName1, nationalTextFont);
                            table.AddCell(cell);

                            FNo++;
                        }
                    }
                    cell.Border = 0;
                    cell.Phrase = new iTextSharp.text.Phrase("    ", nationalTextFont);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    document.Add(table);

                    table = new PdfPTable(2);
                    table.TotalWidth = 100f;
                    cell = new PdfPCell();
                    var cols5 = new[] { 400, 400 };
                    table.SetWidths(cols5);
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.Border = 0;
                    cell.Phrase = new iTextSharp.text.Phrase("أستلمت انا الموقع أدناه السياره بحالتها الراهنه دون أدنى مسئولية على الناقل.", nationalTextFont);
                    table.AddCell(cell);
                    cell.Phrase = new iTextSharp.text.Phrase("    ", nationalTextFont);
                    table.AddCell(cell);
                    document.Add(table);

                    PdfPTable table50 = new PdfPTable(5);
                    table50.TotalWidth = 100f;
                    PdfPCell cell5 = new PdfPCell();
                    cols5 = new[] { 150, 150, 150, 150, 150 };
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

                    cell5.Phrase = new iTextSharp.text.Phrase(txtCustomer.Text, nationalTextFont);
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
                    cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
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

                    cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
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

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
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

                    cell5.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 2;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    //
                    for (int i = 0; i < 2; i++)
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
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
            }
        }

        /*
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

        private bool Saveall()
        {
            try
            {
                short FNo = 1;
                foreach (CarRcv itm in VouData)
                {
                    InvDetails myInvDetails = new InvDetails();
                    myInvDetails.Branch = short.Parse(Session["Branch"].ToString());
                    myInvDetails.VouLoc = moh.MakeMask(itm.InvNo.Split('/')[0], 5);
                    myInvDetails.VouNo = int.Parse(itm.InvNo.Split('/')[1]);
                    myInvDetails.FNo = (short)itm.InvFNo;
                    myInvDetails.Transit = false;
                    myInvDetails.SetTransit(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    itm.Branch = short.Parse(Session["Branch"].ToString());
                    itm.LocNumber = short.Parse(AreaNo);
                    itm.Number = int.Parse(txtVouNo.Text);
                    itm.FNo = FNo;
                    itm.GDate = moh.CheckDate(txtVouDate.Text);
                    itm.GTime = txtGTime.Text;
                    itm.Customer = txtCustomer.Text;
                    itm.Remark = txtRemark.Text;
                    itm.UserName = txtUserName.ToolTip;
                    itm.UserDate = txtUserDate.Text;
                    itm.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    FNo++;
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

                    TextBox txtVouNo = gvr.FindControl("txtVouNo") as TextBox;

                    if (txtVouNo == null)
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }
                    if (txtVouNo.Text == "")
                    {
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "تاكد من أدخال البيانات المطلوبة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }
                    else
                    {
                        txtVouNo.Text = txtVouNo.Text.Trim();
                        //txtVouNo.Text = int.Parse(txtVouNo.Text.Split('/')[0]).ToString().Trim() + "/" + int.Parse(txtVouNo.Text.Split('/')[1]).ToString().Trim();
                    }

                    string vError = "";
                    if (txtVouNo.Text[0] == 'E')
                    {
                        string vNo2 = txtVouNo.Text.Substring(1, txtVouNo.Text.Length - 1);
                        Shipment myInv = new Shipment();
                        myInv.Branch = short.Parse(Session["Branch"].ToString());
                        myInv.VouLoc = moh.MakeMask(vNo2.Split('/')[0], 5);
                        myInv.VouNo = int.Parse(vNo2.Split('/')[1]);
                        myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myInv == null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم الفاتورة غير مدرج من قبل";
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }
                        else if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass236 && myInv.Destination != SiteInfo.City)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "جهة التسليم في الفاتورة تختلف عن موقعك";
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }

                        // Check Invoice Debit
                        if (myInv.SiteAmount != 0)
                        {
                            bool vDebit = true;
                            Jv vJv = new Jv();
                            vJv.Branch = short.Parse(Session["Branch"].ToString());
                            vJv.FType = 101;
                            vJv.LocType = 2;
                            vJv.LocNumber = short.Parse(AreaNo);
                            vJv.InvNo = txtVouNo.Text;
                            vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (vJv != null)
                            {
                                vDebit = false;
                                //if ((myInv.SiteAmount > 0 && vJv.Amount == (double)myInv.SiteAmount) || (myInv.CustomerAmount > 0 && vJv.Amount == (double)myInv.CustomerAmount))
                            }
                            if (vDebit)
                            {
                                vDebit = true;
                                vJv = new Jv();
                                vJv.Branch = short.Parse(Session["Branch"].ToString());
                                vJv.FType = 100;
                                vJv.LocType = 1;
                                vJv.LocNumber = short.Parse(AreaNo);
                                vJv.InvNo = txtVouNo.Text;
                                vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (vJv != null)
                                {
                                    vDebit = false;
                                    //if ((myInv.SiteAmount > 0 && vJv.Amount == (double)myInv.SiteAmount) || (myInv.CustomerAmount > 0 && vJv.Amount == (double)myInv.CustomerAmount))
                                }
                                if (vDebit)
                                {
                                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                    LblCodesResult.Text = "الفاتورة عليها مديونية بمبلغ " + myInv.SiteAmount.ToString() + " يجب أجراء سند قبض قيل التسليم ";
                                    //if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass226)
                                    //{
                                    //    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                    //    return;
                                    // }
                                }
                            }
                        }
                        // End of Check Invoice 

                        Cities myCity = new Cities();
                        myCity.Branch = short.Parse(Session["Branch"].ToString());
                        myCity.Code = myInv.Destination;
                        if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                  where sitm.Code == myCity.Code
                                  select sitm).FirstOrDefault();
                        if (myCity == null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الجهة غير مدرجه من قبل";
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }
                                
                        CarMove myCarMove = new CarMove();
                        myCarMove.Branch = short.Parse(Session["Branch"].ToString());
                        myCarMove.InvoiceVouLoc = myInv.VouLoc;
                        myCarMove.InvoiceNo = myInv.VouNo;
                        myCarMove.InvoiceFNo = 1;
                        myCarMove.Flag = "E";
                        bool vAdd = false;
                        foreach (CarMove CarMoves in myCarMove.GetByInv(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            vAdd = false;
                            CarMoveRCV mRCV = new CarMoveRCV();
                            mRCV.Branch = short.Parse(Session["Branch"].ToString());
                            mRCV.CarMove = short.Parse(CarMoves.VouLoc).ToString() + '/' + CarMoves.Number.ToString();
                            mRCV = mRCV.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (mRCV != null) vAdd = true;
                            else break;
                        }

                        if (vAdd)
                        {
                            CarRcv vCarRcv = new CarRcv();
                            vCarRcv.Branch = short.Parse(Session["Branch"].ToString());

                            if (txtCustomer.Text == "")
                            {
                                txtCustomer.Text = myInv.RecName;
                            }

                            vCarRcv.LocNumber = short.Parse(AreaNo);
                            vCarRcv.InvNo = txtVouNo.Text;
                            vCarRcv.InvFNo = 1;
                            vCarRcv = vCarRcv.GetByInvFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (vCarRcv == null)
                            {
                                VouData.Add(new CarRcv { FNo = (short)(VouData.Count() + 1), LocNumber = short.Parse(AreaNo), InvNo = txtVouNo.Text, Name = myInv.Name, PlateNo = "مغلف", Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, InvFNo = 1 });
                                txtCustomer.Text = myInv.RecName;
                            }
                            else
                            {
                                vError += "تم تسليم الشحنة " + "مغلف" + " ببيان تسليم رقم " + @"<a href='WebCarRCV.aspx?Flag=0&AreaNo=" + moh.MakeMask(vCarRcv.LocNumber.ToString(), 5) + @"&FNum=" + vCarRcv.Number.ToString() + @"' target='_blank'>" + vCarRcv.LocNumber.ToString() + '/' + vCarRcv.Number.ToString() + @"</a><br/>";
                            }
                        }
                    }
                    else if (txtVouNo.Text[0] == 'L')
                    {
                        string vNo2 = txtVouNo.Text.Substring(1, txtVouNo.Text.Length - 1);
                        LShipment myInv = new LShipment();
                        myInv.Branch = short.Parse(Session["Branch"].ToString());
                        myInv.VouLoc = moh.MakeMask(vNo2.Split('/')[0], 5);
                        myInv.VouNo = int.Parse(vNo2.Split('/')[1]);
                        myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myInv == null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم الفاتورة غير مدرج من قبل";
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }
                        else if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass236 && myInv.Destination != SiteInfo.City)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "جهة التسليم في الفاتورة تختلف عن موقعك";
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }

                        // Check Invoice Debit
                        if (myInv.SiteAmount != 0)
                        {
                            bool vDebit = true;
                            Jv vJv = new Jv();
                            vJv.Branch = short.Parse(Session["Branch"].ToString());
                            vJv.FType = 101;
                            vJv.LocType = 2;
                            vJv.LocNumber = short.Parse(AreaNo);
                            vJv.InvNo = txtVouNo.Text;
                            vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (vJv != null)
                            {
                                vDebit = false;
                                //if ((myInv.SiteAmount > 0 && vJv.Amount == (double)myInv.SiteAmount) || (myInv.CustomerAmount > 0 && vJv.Amount == (double)myInv.CustomerAmount))
                            }
                            if (vDebit)
                            {
                                vDebit = true;
                                vJv = new Jv();
                                vJv.Branch = short.Parse(Session["Branch"].ToString());
                                vJv.FType = 100;
                                vJv.LocType = 1;
                                vJv.LocNumber = short.Parse(AreaNo);
                                vJv.InvNo = txtVouNo.Text;
                                vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (vJv != null)
                                {
                                    vDebit = false;
                                    //if ((myInv.SiteAmount > 0 && vJv.Amount == (double)myInv.SiteAmount) || (myInv.CustomerAmount > 0 && vJv.Amount == (double)myInv.CustomerAmount))
                                }
                                if (vDebit)
                                {
                                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                    LblCodesResult.Text = "الفاتورة عليها مديونية بمبلغ " + myInv.SiteAmount.ToString() + " يجب أجراء سند قبض قيل التسليم ";
                                    //if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass226)
                                    //{
                                    //    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                    //    return;
                                    //}
                                }
                            }
                        }
                        // End of Check Invoice 

                        Cities myCity = new Cities();
                        myCity.Branch = short.Parse(Session["Branch"].ToString());
                        myCity.Code = myInv.Destination;
                        if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                  where sitm.Code == myCity.Code
                                  select sitm).FirstOrDefault();
                        if (myCity == null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الجهة غير مدرجه من قبل";
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }

                        ShipDetails myInvD = new ShipDetails();
                        myInvD.Branch = short.Parse(Session["Branch"].ToString());
                        myInvD.VouLoc = myInv.VouLoc;
                        myInvD.VouNo = myInv.VouNo;
                        foreach (ShipDetails Invd in myInvD.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            CarMove myCarMove = new CarMove();
                            myCarMove.Branch = short.Parse(Session["Branch"].ToString());
                            myCarMove.InvoiceVouLoc = myInv.VouLoc;
                            myCarMove.Flag = "L";
                            myCarMove.InvoiceNo = myInv.VouNo;
                            myCarMove.InvoiceFNo = Invd.FNo;

                            bool vAdd = false;
                            foreach (CarMove CarMoves in myCarMove.GetByInv(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                vAdd = false;
                                CarMoveRCV mRCV = new CarMoveRCV();
                                mRCV.Branch = short.Parse(Session["Branch"].ToString());
                                mRCV.CarMove = short.Parse(CarMoves.VouLoc).ToString() + '/' + CarMoves.Number.ToString();
                                mRCV = mRCV.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (mRCV != null) vAdd = true;
                                else break;
                            }

                            if (vAdd)
                            {
                                CarRcv vCarRcv = new CarRcv();
                                vCarRcv.Branch = short.Parse(Session["Branch"].ToString());

                                vCarRcv.LocNumber = short.Parse(AreaNo);
                                vCarRcv.InvNo = txtVouNo.Text;
                                vCarRcv.InvFNo = Invd.FNo;
                                vCarRcv = vCarRcv.GetByInvFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (vCarRcv == null)
                                {
                                    VouData.Add(new CarRcv { FNo = (short)(VouData.Count() + 1), LocNumber = short.Parse(AreaNo), InvNo = txtVouNo.Text, Name = myInv.Name, PlateNo = Invd.Name, Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, InvFNo = Invd.FNo });
                                    txtCustomer.Text = myInv.RecName;
                                }
                                else
                                {
                                    vError += "تم تسليم الشحنة " + Invd.Name + " ببيان تسليم رقم " + @"<a href='WebCarRCV.aspx?Flag=0&AreaNo=" + moh.MakeMask(vCarRcv.LocNumber.ToString(), 5) + @"&FNum=" + vCarRcv.Number.ToString() + @"' target='_blank'>" + vCarRcv.LocNumber.ToString() + '/' + vCarRcv.Number.ToString() + @"</a><br/>";
                                }
                            }
                        }
                    }
                    else
                    {
                        Invoice myInv = new Invoice();
                        myInv.Branch = short.Parse(Session["Branch"].ToString());
                        myInv.VouLoc = moh.MakeMask(txtVouNo.Text.Split('/')[0], 5);
                        myInv.VouNo = int.Parse(txtVouNo.Text.Split('/')[1]);
                        myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myInv == null)
                        {
                            grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم الفاتورة غير مدرج من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }
                        else if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass236 && myInv.Destination != SiteInfo.City)
                        {
                            grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "جهة التسليم في الفاتورة تختلف عن موقعك";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }


                        // Check Invoice Debit
                        if (myInv.SiteAmount != 0)
                        {
                            bool vDebit = true;
                            Jv vJv = new Jv();
                            vJv.Branch = short.Parse(Session["Branch"].ToString());
                            vJv.FType = 101;
                            vJv.LocType = 2;
                            vJv.LocNumber = short.Parse(AreaNo);
                            vJv.InvNo = txtVouNo.Text;
                            vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (vJv != null)
                            {
                                vDebit = false;
                                //if ((myInv.SiteAmount > 0 && vJv.Amount == (double)myInv.SiteAmount) || (myInv.CustomerAmount > 0 && vJv.Amount == (double)myInv.CustomerAmount))
                            }
                            if (vDebit)
                            {
                                vDebit = true;
                                vJv = new Jv();
                                vJv.Branch = short.Parse(Session["Branch"].ToString());
                                vJv.FType = 100;
                                vJv.LocType = 1;
                                vJv.LocNumber = short.Parse(AreaNo);
                                vJv.InvNo = txtVouNo.Text;
                                vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (vJv != null)
                                {
                                    vDebit = false;
                                    //if ((myInv.SiteAmount > 0 && vJv.Amount == (double)myInv.SiteAmount) || (myInv.CustomerAmount > 0 && vJv.Amount == (double)myInv.CustomerAmount))
                                }
                                if (vDebit)
                                {
                                    grdCodes_RowCancelingEdit(sender, null);
                                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                    LblCodesResult.Text = "الفاتورة عليها مديونية بمبلغ " + myInv.SiteAmount.ToString() + " يجب أجراء سند قبض قيل التسليم ";
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                    //if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass226)
                                    //{
                                    //    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                    //    return;
                                    //}
                                }
                            }
                        }
                        // End of Check Invoice 

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
                            LblCodesResult.Text = "الجهة غير مدرجه من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }                        
                        InvDetails myInvD = new InvDetails();
                        myInvD.Branch = short.Parse(Session["Branch"].ToString());
                        myInvD.VouLoc = myInv.VouLoc;
                        myInvD.VouNo = myInv.VouNo;
                        foreach (InvDetails Invd in myInvD.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            CarMove myCarMove = new CarMove();
                            myCarMove.Branch = short.Parse(Session["Branch"].ToString());
                            myCarMove.InvoiceVouLoc = myInv.VouLoc;
                            myCarMove.InvoiceNo = myInv.VouNo;
                            myCarMove.InvoiceFNo = Invd.FNo;

                            bool vAdd = false;
                            foreach (CarMove CarMoves in myCarMove.GetByInv(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                vAdd = false;
                                CarMoveRCV mRCV = new CarMoveRCV();
                                mRCV.Branch = short.Parse(Session["Branch"].ToString());
                                mRCV.CarMove = short.Parse(CarMoves.VouLoc).ToString() + '/' + CarMoves.Number.ToString();
                                mRCV = mRCV.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (mRCV != null) vAdd = true;
                                else break;
                            }

                            if (vAdd)
                            {
                                CarRcv vCarRcv = new CarRcv();
                                vCarRcv.Branch = short.Parse(Session["Branch"].ToString());

                                vCarRcv.LocNumber = short.Parse(AreaNo);
                                vCarRcv.InvNo = txtVouNo.Text;
                                vCarRcv.InvFNo = Invd.FNo;
                                vCarRcv = vCarRcv.GetByInvFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (vCarRcv == null) VouData.Add(new CarRcv { FNo = (short)(VouData.Count() + 1), LocNumber = short.Parse(AreaNo), InvNo = txtVouNo.Text, Name = myInv.Name, PlateNo = Invd.PlateNo, Destination = myInv.Destination, DestinationName1 = myCity.Name1, DestinationName2 = myCity.Name2, InvFNo = Invd.FNo });
                                else
                                {
                                    vError += "تم تسليم السيارة " + Invd.PlateNo + " ببيان تسليم رقم " + @"<a href='WebCarRCV.aspx?Flag=0&AreaNo=" + moh.MakeMask(vCarRcv.LocNumber.ToString(), 5) + @"&FNum=" + vCarRcv.Number.ToString() + @"' target='_blank'>" + vCarRcv.LocNumber.ToString() + '/' + vCarRcv.Number.ToString() + @"</a><br/>";
                                }
                            }
                        }
                    }
                    LoadVouData();
                    if (vError != "")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = vError;
                        //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
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

        protected void grdCodes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string FNo = grdCodes.DataKeys[e.RowIndex]["FNo"].ToString();
                VouData.RemoveAt(int.Parse(FNo) - 1);
                for (int i = 0; i < VouData.Count; i++)
                {
                    VouData[i].FNo = (short)(i + 1);
                }
                e.Cancel = false;
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
                        myArch.DocType = 506;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(AreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 506;
                        myArch.FileName = FileUpload1.FileName;
                        myArch.FileName2 = mySetting.ImagePath2 + FileName;
                        myArch.FNo = (short)i;
                        myArch.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "سند استلام سيارة", "اضافة مرفقات", "اضافة مرفقات لسند استلام سيارة رقم " + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

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
                myArch.DocType = 506;
                myArch.FNo = short.Parse(FNo);
                myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "سند استلام سيارة", "الغاء مرفقات", "الغاء مرفقات لسند استلام سيارة رقم " + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

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
            Arch myArch = new Arch();
            myArch.Branch = short.Parse(Session["Branch"].ToString());
            myArch.LocNumber = short.Parse(AreaNo);
            myArch.Number = int.Parse(txtVouNo.Text);
            myArch.DocType = 506;
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

        protected string UrlHelper(object Number)
        {
            if (!string.IsNullOrEmpty(Number.ToString()))
            {
                string[] vs = Number.ToString().Split('/');
                if (vs.Count() > 1)
                {
                    if (vs[0][0] == 'L') return "~/WebLShipment.aspx?Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0].Substring(1, vs[0].Length - 1), 5) + "&StoreNo=00001";
                    else if (vs[0][0] == 'E') return "~/WebShipment.aspx?Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0].Substring(1, vs[0].Length - 1), 5) + "&StoreNo=00001";
                    else return "~/WebInvoice.aspx?Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&StoreNo=00001";
 
                }
                else return "";
            }
            else return "";
        }
    }
}
