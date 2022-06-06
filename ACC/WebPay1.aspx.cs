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
    public partial class WebPay1 : System.Web.UI.Page
    {
        public int gNoDays = 90;
        public string gInTax = "120409001";
        public short LocType
        {
            get
            {
                if (ViewState["LocType"] == null)
                {
                    ViewState["LocType"] = 2;
                }
                return (short)(ViewState["LocType"]);
            }
            set { ViewState["LocType"] = value; }
        }
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

        public void EditMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass255;
            BtnEdit.Visible = true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass252;
            BtnNew.Visible = false;
            BtnDelete.Visible = true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass253;
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
            if(!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass252) ControlsOnOff(false);
        }

        public void NewMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            //txtVouNo.ReadOnly = false;
            //txtVouNo.BackColor = System.Drawing.Color.White;

            BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass251;
            BtnDelete.Visible = false;
            if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass252) ControlsOnOff(true);
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
                    this.Page.Header.Title = "سندات الصرف";
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
                        AreaNo = Session["AreaNo"].ToString();
                        vAreaNo = AreaNo;
                        SiteInfo = (CostCenter)Session["SiteInfo"];
                    }
                    if (Request.QueryString["StoreNo"] != null) StoreNo = Request.QueryString["StoreNo"].ToString();
                    LocType = (short)(Request.QueryString["FType"].ToString() == "20" ? 3 : Request.QueryString["FType"].ToString() == "200" ? 4 : 2);
                    lblBranch2.Text = "/" + (Request.QueryString["FType"].ToString() == "20" ? "01" : Request.QueryString["FType"].ToString() == "200" ? "001" : short.Parse(vAreaNo).ToString());
                    if (LocType == 3) // ش
                    {
                        CostCenter myCost = new CostCenter();
                        myCost.Branch = 1;
                        if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCost.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCost.Code = "00014";
                        myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                  where citm.Code == myCost.Code
                                  select citm).FirstOrDefault();
                        if (myCost != null) SiteInfo = myCost;
                    }
                    else if (LocType == 4) // ص
                    {
                        CostCenter myCost = new CostCenter();
                        myCost.Branch = 1;
                        if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCost.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCost.Code = "00015";
                        myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                  where citm.Code == myCost.Code
                                  select citm).FirstOrDefault();
                        if (myCost != null) SiteInfo = myCost;
                    }

                    if (LocType == 3 || LocType == 4) vAreaNo = "00001";
                    lblBranch2.Text = "/" + (Request.QueryString["FType"].ToString() == "20" ? "01" : Request.QueryString["FType"].ToString() == "200" ? "001" : short.Parse(vAreaNo).ToString()); 

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


                    if (LocType == 3)
                    {
                        ddlDbCode.SelectedValue = "120103013";
                        ddlDbCode.Enabled = false;

                        Panel3.Visible = false;
                        Panel4.Visible = false;
                        ddlType.SelectedValue = "3";
                        ddlType.Enabled = false;

                    }
                    else if (LocType == 4)
                    {
                        ddlDbCode.SelectedValue = "120103014";
                        ddlDbCode.Enabled = false;

                        Panel3.Visible = false;
                        Panel4.Visible = false;
                        ddlType.SelectedValue = "3";
                        // ddlType.Enabled = false;

                    }

                    ddlArea.DataTextField = "Name1";
                    ddlArea.DataValueField = "Code";
                    ddlArea.DataSource = (List<Area>)(HttpRuntime.Cache["LastArea" + HttpContext.Current.Session["CNN2"].ToString()]);
                    ddlArea.DataBind();
                    ddlArea.Items.Insert(0, new ListItem("--- أختار المنطقة---", "-1", true));

                    ddlCostCenter.DataTextField = "Name1";
                    ddlCostCenter.DataValueField = "Code";
                    ddlCostCenter.DataSource = (List<CostCenter>)(HttpRuntime.Cache["LastCostCenter" + HttpContext.Current.Session["CNN2"].ToString()]);
                    ddlCostCenter.DataBind();
                    ddlCostCenter.Items.Insert(0, new ListItem("--- أختار الفرع---", "-1", true));

                    ddlProject.DataTextField = "Name1";
                    ddlProject.DataValueField = "Code";
                    ddlProject.DataSource = (List<AccProject>)(HttpRuntime.Cache["LastProject" + HttpContext.Current.Session["CNN2"].ToString()]);
                    ddlProject.DataBind();
                    ddlProject.Items.Insert(0, new ListItem("--- أختار المشروع---", "-1", true));

                    ddlCostAcc.DataTextField = "Name1";
                    ddlCostAcc.DataValueField = "Code";
                    ddlCostAcc.DataSource = (List<CostAcc>)(HttpRuntime.Cache["LastCostAcc" + HttpContext.Current.Session["CNN2"].ToString()]);
                    ddlCostAcc.DataBind();
                    ddlCostAcc.Items.Insert(0, new ListItem("--- أختار حساب التكاليف---", "-1", true));

                    Cars myCar2 = new Cars();
                    myCar2.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar2.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlCarNo.DataTextField = "PlateNo";
                    ddlCarNo.DataValueField = "Code";
                    ddlCarNo.DataSource = (from itm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                           where itm.CarsType == myCar2.CarsType && (bool)itm.Status
                                           select itm).ToList();
                    ddlCarNo.DataBind();
                    ddlCarNo.Items.Insert(0, new ListItem("--- أختار الشاحنة---", "-1", true));

                    ddlEmp.Items.Insert(0, new ListItem("--- أختار الموظف---", "-1", true));

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
                    BtnNew.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass251;
                    BtnEdit.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass252;
                    BtnDelete.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass253;
                    BtnSearch.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass254;
                    BtnFind.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass254;
                    BtnPrint.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass255;

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
                        if (Request.QueryString["CarMove"] != null)
                        {
                            double Amount = 0;
                            String Name = "";

                            if (ddlType.SelectedValue == "2")
                            {
                                Jv vJv = new Jv();
                                vJv.Branch = short.Parse(Session["Branch"].ToString());
                                vJv.FType = 102;
                                vJv.LocType = LocType;
                                vJv.LocNumber = short.Parse(vAreaNo);
                                vJv.InvNo = Request.QueryString["CarMove"].ToString();
                                vJv.DocType = short.Parse(ddlType.SelectedValue);
                                vJv = vJv.findInvNo20(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (vJv != null)
                                {
                                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                    LblCodesResult.Text = "تم أدراج المستند في سند الصرف رقم " + vJv.LocNumber.ToString() + "/" + vJv.Number.ToString();
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                    return;
                                }

                                CarMove myCar = new CarMove();
                                myCar.Branch = short.Parse(Session["Branch"].ToString());
                                myCar.VouLoc = moh.MakeMask(Request.QueryString["CarMove"].ToString().Split('/')[0], 5);
                                myCar.Number = int.Parse(Request.QueryString["CarMove"].ToString().Split('/')[1]);
                                myCar = myCar.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                                if (myCar != null)
                                {
                                    //if (myCar.VouNo2 != "")
                                    //{
                                    //    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                    //    LblCodesResult.Text = "تم أدراج المستند في سند الصرف رقم " + myCar.VouNo2;
                                    //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                    //    return;
                                    //}

                                    CarMoveRCV rcv = new CarMoveRCV();
                                    rcv.Branch = short.Parse(Session["Branch"].ToString());
                                    rcv.CarMove = myCar.CarMoveNo2;
                                    rcv = rcv.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (rcv == null)
                                    {
                                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                        LblCodesResult.Text = "يجب تسجيل بيان وصول قبل سند الصرف";
                                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                        return;
                                    }

                                    vJv = new Jv();
                                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                                    vJv.FType = 104;
                                    vJv.LocType = 2;
                                    vJv.LocNumber = short.Parse(Request.QueryString["CarMove"].ToString().Split('/')[0]);
                                    vJv.Number = int.Parse(Request.QueryString["CarMove"].ToString().Split('/')[1]);
                                    vJv = (from itm in vJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                           where itm.CrCode != ""
                                           select itm).FirstOrDefault();
                                    if (vJv != null)
                                    {
                                        if ((bool)myCar.Rent)
                                        {
                                            Amount = (double)myCar.RentValue;
                                            Name = SiteInfo.CurExpAcc;
                                            VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myCar.Number, InvoiceVouLoc = myCar.VouLoc, Name = myCar.RentDriver, Amount = Amount, DocType = short.Parse(ddlType.SelectedValue), Site = "240104005" });
                                            // MakeSum();
                                            LoadVouData();
                                        }
                                        else
                                        {
                                            Amount = (double)vJv.Amount;
                                            Name = SiteInfo.CurExpAcc;
                                            Drivers myDrive = new Drivers();
                                            myDrive.Branch = short.Parse(Session["Branch"].ToString());
                                            if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                            myDrive.Code = myCar.DriverCode;
                                            myDrive = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                                                       where sitm.Code == myDrive.Code
                                                       select sitm).FirstOrDefault();
                                            if (myDrive != null)
                                            {
                                                VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myCar.Number, InvoiceVouLoc = myCar.VouLoc, Name = myDrive.Name1, Amount = Amount, DocType = short.Parse(ddlType.SelectedValue), Site = SiteInfo.CurExpAcc });
                                                LoadVouData();
                                            }
                                            else
                                            {
                                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                                LblCodesResult.Text = "بيانات السائق غير مدرجه من قبل";
                                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                                return;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if ((bool)myCar.Rent)
                                        {
                                            Amount = (double)myCar.RentValue;
                                            Name = SiteInfo.CurExpAcc;
                                            VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myCar.Number, InvoiceVouLoc = myCar.VouLoc, Name = myCar.RentDriver, Amount = Amount, DocType = short.Parse(ddlType.SelectedValue), Site = "240104005" });
                                            //MakeSum();
                                            LoadVouData();
                                        }
                                        else
                                        {
                                            CarPrices myPrice = new CarPrices();
                                            myPrice.Branch = short.Parse(Session["Branch"].ToString());
                                            myPrice.MonthNo = 0;
                                            myPrice.FromCode = myCar.FromLoc;
                                            myPrice.PLevel = "00002";
                                            myPrice.toCode = myCar.ToLoc;
                                            myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                            if (myPrice != null)
                                            {
                                                Amount = (double)myPrice.CostAmount;
                                                CarMoveLines myCarMoveLine = new CarMoveLines();
                                                myCarMoveLine.Branch = short.Parse(Session["Branch"].ToString());
                                                myCarMoveLine.VouLoc = moh.MakeMask(Request.QueryString["CarMove"].ToString().Split('/')[0], 5);
                                                myCarMoveLine.Number = int.Parse(Request.QueryString["CarMove"].ToString().Split('/')[1]);
                                                foreach (CarMoveLines itm in myCarMoveLine.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                                {
                                                    if (itm.FromLoc == "-1" && itm.LineFNo != 1) Amount -= (double)itm.Cost;
                                                    else Amount += (double)itm.Cost;
                                                }

                                                Name = SiteInfo.CurExpAcc;
                                                Drivers myDrive = new Drivers();
                                                myDrive.Branch = short.Parse(Session["Branch"].ToString());
                                                if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                                myDrive.Code = myCar.DriverCode;
                                                myDrive = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                                                           where sitm.Code == myDrive.Code
                                                           select sitm).FirstOrDefault();
                                                if (myDrive != null)
                                                {
                                                    VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myCar.Number, InvoiceVouLoc = myCar.VouLoc, Name = myDrive.Name1, Amount = Amount, DocType = short.Parse(ddlType.SelectedValue), Site = SiteInfo.CurExpAcc });
                                                    //MakeSum();
                                                    LoadVouData();
                                                }
                                                else
                                                {
                                                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                                    LblCodesResult.Text = "بيانات السائق غير مدرجه من قبل";
                                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                                LblCodesResult.Text = "جهة المستند غير مدرجه من قبل";
                                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                                return;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                    LblCodesResult.Text = "رقم بيان الترحيل غير مدرج من قبل";
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                    return;
                                }
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
                lblStatus.Text = "";
                txtVouDate.Text = "";
                txtSearch.Text = "";
                txtAmount.Text = "";
                txtRemark.Text = "";
                txtBankName.Text = "";
                txtchqNo.Text = "";
                txtChqDate.Text = "";
                txtDiscount.Text = "";
                txtNet.Text = "";
                if (LocType == 2)
                {
                    ddlType.SelectedIndex = 0;
                    ddlType_SelectedIndexChanged(sender, e);
                    ChkCheque.Checked = false;
                    ChkCheque_CheckedChanged(sender, e);
                }
                else
                {
                    ddlType.SelectedValue = "3";
                    ddlType_SelectedIndexChanged(sender, e);
                    ChkCheque.Visible = false;
                }
                
                if (ddlArea.Enabled) ddlArea.SelectedIndex = 0;
                if (ddlCostAcc.Enabled) ddlCostAcc.SelectedIndex = 0;
                if (ddlCostCenter.Enabled) ddlCostCenter.SelectedIndex = 0;
                if (ddlDbCode.Enabled) ddlDbCode.SelectedIndex = 0;
                if (ddlProject.Enabled) ddlProject.SelectedIndex = 0;
                if (ddlCarNo.Enabled) ddlCarNo.SelectedIndex = 0;

                if (LocType == 2 || LocType == 3 || LocType == 4)
                {
                    ddlArea.SelectedValue = SiteInfo.Area;
                    ddlCostCenter.SelectedValue = SiteInfo.Code;
                    ddlProject.SelectedValue = SiteInfo.Project;                    
                    ddlDbCode.SelectedValue = SiteInfo.LoanAcc;  // cashacc
                }

                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                if (sender != null)
                {
                    txtVouNo.Text = "";
                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 102;
                    myJv.LocType = LocType;
                    myJv.LocNumber = short.Parse(vAreaNo);
                    int? i = myJv.GetNewNumber(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (i == 0 || i == null)
                    {
                        if (LocType == 2) i = myJv.FType == 101 ? SiteInfo.RecNo : SiteInfo.PayNo;
                        else i = 1;
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
                LoadTransData();
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
            CalendarExtender1.Enabled = State;
            CalendarExtender2.Enabled = State;
            txtVouDate.ReadOnly = !State;
            txtAmount.ReadOnly = !State;
            if (State) txtAmount.ReadOnly = (ddlType.SelectedValue != "3");
            txtRemark.ReadOnly = !State;
            txtBankName.ReadOnly = !State;
            txtchqNo.ReadOnly = !State;
            txtChqDate.ReadOnly = !State;
            txtDiscount.ReadOnly = !State;
            ddlType.Enabled = State;
            ChkCheque.Enabled = State;
            //grdAttach.Enabled = State;
            foreach (GridViewRow itm in grdAttach.Rows)
            {
                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                if (BtnDelete != null) BtnDelete.Visible = State;
            }
            grdTrans.Enabled = State;
            //grdCodes.Enabled = State;
            grdCodes.ShowFooter = State;
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
                    myInv2 inv = new myInv2();
                    List<myInv2> Listax = new List<myInv2>();
                    Listax.Add(inv);
                    grdCodes.DataSource = Listax;
                    grdCodes.DataBind();
                    grdCodes.Rows[0].Cells.Clear();
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

                    if (VouData.Count() == 0 || (VouData.Count==1 && VouData[0].Amount == 0))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لا توجد بيانات";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    BtnNew.Enabled = false;
                    ValidateNum();
                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 102;
                    myJv.LocType = LocType;
                    myJv.LocNumber = short.Parse(vAreaNo);
                    myJv.Number = int.Parse(txtVouNo.Text);
                    myJv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
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
                            myJv = new Jv();
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.FType = 102;
                            myJv.LocType = LocType;
                            myJv.LocNumber = short.Parse(vAreaNo);
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

                        if (Saveall())
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                            SaveTrans(1);
                            string vNumber = txtVouNo.Text;
                            BtnNew.Enabled = true;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                            PrintMe(vNumber);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                            BtnNew.Enabled = true;
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
                    ValidateNum();
                 //   if (ValidateVou()) return;

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

                    if (VouData.Count() == 0 || (VouData.Count == 1 && VouData[0].Amount == 0))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لا توجد بيانات";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    List<Jv> ljv = new List<Jv>();
                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 102;
                    myJv.LocType = LocType;
                    myJv.LocNumber = short.Parse(vAreaNo);
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
                        myJv.FType = 102;
                        myJv.LocType = LocType;
                        myJv.LocNumber = short.Parse(vAreaNo);
                        myJv.Number = int.Parse(txtVouNo.Text);
                        if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            moh.PostDoc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, 1, short.Parse(Session["Branch"].ToString()), 0, "0", 0, myJv.LocNumber.ToString() + "/" + myJv.Number.ToString(), 0, false);
                            if (Saveall())
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                                SaveTrans(2);
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
                    myJv.FType = 102;
                    myJv.LocType = LocType;
                    myJv.LocNumber = short.Parse(vAreaNo);
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
                        myJv.FType = 102;
                        myJv.LocType = LocType;
                        myJv.LocNumber = short.Parse(vAreaNo);
                        myJv.Number = int.Parse(txtVouNo.Text);
                        if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            moh.PostDoc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, 1, short.Parse(Session["Branch"].ToString()), 0, "0", 0, myJv.LocNumber.ToString() + "/" + myJv.Number.ToString(), 0, false);
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormAction = "الغاء";
                            UserTran.FormName = "سند الصرف";
                            UserTran.Description = "الغاء بيانات سند الصرف رقم " + txtVouNo.Text;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);


                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم الغاء البيانات بنجاح";
                            SaveTrans(3);
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
                    myJv.FType = 102;
                    myJv.LocType = LocType;
                    myJv.LocNumber = short.Parse(vAreaNo);
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
                        int myItem = lJv.Count - 1;
                        txtVouNo.Text = lJv[myItem].Number.ToString();
                        txtVouDate.Text = lJv[myItem].FDate;
                        txtUserDate.Text = lJv[myItem].UserDate;
                        txtUserName.ToolTip = lJv[myItem].UserName;
                        TblUsers ax = new TblUsers();
                        if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        ax.UserName = lJv[myItem].UserName;
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
                        ddlDbCode.SelectedValue = lJv[myItem].CrCode;
                        txtBankName.Text = lJv[myItem].BankName;
                        txtChqDate.Text = lJv[myItem].ChequeDate;
                        txtchqNo.Text = lJv[myItem].ChequeNo;
                        txtAmount.Text = string.Format("{0:N2}", lJv[myItem].Amount);                        
                        ChkCheque.Checked = false;
                        if (txtBankName.Text != "" || txtChqDate.Text != "" || txtchqNo.Text != "") ChkCheque.Checked = true;
                        ChkCheque_CheckedChanged(sender, e);
                        ddlType.SelectedValue = lJv[myItem].DocType.ToString();
                        ddlType_SelectedIndexChanged(sender,e);
                        txtRemark.Text = lJv[myItem].Remark;

                        if (lJv[myItem - 1].FNo2 == -1 && ddlType.SelectedValue == "2")
                        {
                            txtDiscount.Text = string.Format("{0:N2}", lJv[myItem - 1].Amount);
                        }
                        if (ddlType.SelectedValue != "2")  txtDiscount.Text = "0";
                        txtDiscount_TextChanged(sender, e);

                        if (ddlType.SelectedValue != "3")
                        {VouData.Clear();
                            for (int i = 0; i < lJv.Count(); i++)
                            {
                                if(lJv[i].FNo2 != -1)
                                {
                                    if(lJv[i].Area != "-1")
                                    {
                                        if (LocType == 2 || LocType == 3 || LocType == 4)
                                        {

                                        }
                                        else
                                        {
                                            ddlArea.SelectedValue = lJv[i].Area;
                                            ddlCostAcc.SelectedValue = lJv[i].CostAcc;
                                            ddlCostCenter.SelectedValue = lJv[i].CostCenter;
                                            ddlEmp.SelectedValue = lJv[i].EmpCode;
                                            ddlProject.SelectedValue = lJv[i].Project;
                                            ddlCarNo.SelectedValue = lJv[i].CarNo;
                                        }
                                    }

                                    if(lJv[i].DocType == 2)
                                    {
                                        CarMove myCar = new CarMove();
                                        myCar.Branch = short.Parse(Session["Branch"].ToString());
                                        myCar.VouLoc = moh.MakeMask(lJv[i].InvNo.Split('/')[0], 5);
                                        myCar.Number = int.Parse(lJv[i].InvNo.Split('/')[1]);
                                        myCar = myCar.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                                        if (myCar != null)
                                        {
                                            if ((bool)myCar.Rent)
                                            {
                                                VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myCar.Number, InvoiceVouLoc = myCar.VouLoc, Name = myCar.RentDriver, Amount = lJv[i].Amount, DocType = (short)lJv[i].DocType, Site = lJv[i].DbCode, FNo2 = lJv[i].FNo2 });
                                            }
                                            else
                                            {
                                                Drivers myDrive = new Drivers();
                                                myDrive.Branch = short.Parse(Session["Branch"].ToString());
                                                if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                                myDrive.Code = myCar.DriverCode;
                                                myDrive = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                                                           where sitm.Code == myDrive.Code
                                                           select sitm).FirstOrDefault();
                                                if (myDrive != null)
                                                {
                                                    VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myCar.Number, InvoiceVouLoc = myCar.VouLoc, Name = myDrive.Name1, Amount = lJv[i].Amount, DocType = (short)lJv[i].DocType, Site = lJv[i].DbCode, FNo2 = lJv[i].FNo2 });
                                                }
                                            }
                                        }                                    
                                    }
                                    else if(lJv[i].DocType == 0)
                                    {
                                        MyPO inv = new MyPO();
                                        inv.Branch = short.Parse(Session["Branch"].ToString());
                                        inv.FType = 1;
                                        inv.LocNumber = short.Parse(lJv[i].InvNo.Split('/')[0]);
                                        inv.Number = int.Parse(lJv[i].InvNo.Split('/')[1]);
                                        inv.FNo = (short)lJv[i].FNo2;
                                        inv = inv.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if(inv != null)
                                        {
                                               VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = inv.Number, InvoiceVouLoc = moh.MakeMask(inv.LocNumber.ToString(), 5), Name = inv.Item, Amount = lJv[i].Amount, DocType = (short)lJv[i].DocType, Site = lJv[i].DbCode , FNo2 = lJv[i].FNo2 });        
                                        }                                    
                                    }
                                    else if(lJv[i].DocType == 4)
                                    {
                                        MyPO inv = new MyPO();
                                        inv.Branch = short.Parse(Session["Branch"].ToString());
                                        inv.FType = 1;
                                        inv.LocNumber = short.Parse(lJv[i].InvNo.Split('/')[0]);
                                        inv.Number = int.Parse(lJv[i].InvNo.Split('/')[1]);
                                        inv.FNo = (short)lJv[i].FNo2;
                                        inv = inv.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if(inv != null)
                                        {
                                            VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = inv.Number, InvoiceVouLoc = moh.MakeMask(inv.LocNumber.ToString(), 5), Name = inv.Item, Amount = inv.Amount, DocType = (short)lJv[i].DocType , Site = lJv[i].DbCode , FNo2 = lJv[i].FNo2 });
                                        }                                            
                                    }
                                    else if (lJv[i].DocType == 5)
                                    {
                                        if(lJv[i].DbCode != "")
                                            VouData.Add(new myInv2 { FNo = VouData.Count() + 1, LocType = (short)(lJv[i].InvNo.Split('/')[0] == "001" ? 3 : 2 ) , VouNo = int.Parse(lJv[i].InvNo.Split('/')[1]), InvoiceVouLoc = moh.MakeMask(lJv[i].InvNo.Split('/')[0], 5), Name = lJv[i].AccName1, Amount = lJv[i].Amount, DocType = (short)lJv[i].DocType, Site = lJv[i].DbCode, FNo2 = lJv[i].FNo2 });
                                    }
                                    else if (lJv[i].DocType == 9)
                                    {
                                        if (lJv[i].DbCode != "")
                                            VouData.Add(new myInv2 { FNo = VouData.Count() + 1, LocType = (short)(lJv[i].InvNo.Split('/')[0] == "001" ? 3 : 2), VouNo = int.Parse(lJv[i].InvNo.Split('/')[1]), InvoiceVouLoc = moh.MakeMask(lJv[i].InvNo.Split('/')[0], 5), Name = lJv[i].AccName1, Amount = lJv[i].Amount, DocType = (short)lJv[i].DocType, Site = lJv[i].DbCode, FNo2 = lJv[i].FNo2 });
                                    }
                                }
                            }
                            LoadVouData();
                            // MakeSum();
                        }
                        LoadAttachData();
                        LoadTransData();

                        MyPO myPo = new MyPO();
                        myPo.Branch = short.Parse(Session["Branch"].ToString());
                        myPo.FType = (short)(LocType == 3 ? 6 : LocType == 4 ? 4 : 2);
                        myPo.LocNumber = short.Parse(vAreaNo);
                        myPo.VouNo = (LocType == 3 ? "0" + int.Parse(vAreaNo).ToString() : LocType == 4 ? "00" + int.Parse(vAreaNo).ToString() : int.Parse(vAreaNo).ToString()) + "/" + txtVouNo.Text.Trim();
                        myPo = myPo.GetVouNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myPo != null)
                        {
                            lblStatus.Text = (LocType == 3 ? @"<a href='WebPPO1.aspx?FType=20&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + myPo.Number.ToString() + @"' target='_blank'> مدرج في طلب الدفع رقم " + "0" + myPo.LocNumber.ToString() + @"/" + myPo.Number.ToString() + @"</a>"
                                             : LocType == 4 ? @"<a href='WebPPO1.aspx?FType=4&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + myPo.Number.ToString() + @"' target='_blank'> مدرج في طلب الدفع رقم " + "00" + myPo.LocNumber.ToString() + @"/" + myPo.Number.ToString() + @"</a>"
                                             : @"<a href='WebPPO1.aspx?AreaNo=" + moh.MakeMask(myPo.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + myPo.Number.ToString() + @"' target='_blank'> مدرج في طلب الدفع رقم " + myPo.LocNumber.ToString() + @"/" + myPo.Number.ToString() + @"</a>");
                            BtnEdit.Visible = false;
                            BtnDelete.Visible = false;
                        }
                        else lblStatus.Text = "";
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=7&LocType=" + LocType.ToString() + @"&LocNumber=" + vAreaNo + "&Number=" + Number + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
            return;
        }

        protected void BtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    SaveTrans(4);
                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = "سند االصرف";
                        UserTran.FormAction = "طباعة";
                        UserTran.Description = "طباعة سند الصرف رقم " + txtVouNo.Text;
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
                    page.vStr1 = "سند الصرف";
                    page.vStr2 = "صرفنا على:";

                    string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                    BaseFont nationalBase;
                    nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font nationalTextFont14 = new iTextSharp.text.Font(nationalBase, 14f, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font nationalTextFont16 = new iTextSharp.text.Font(nationalBase, 16f, iTextSharp.text.Font.NORMAL);

                    page.PageNo = "1";
                    page.UserName = Session["FullUser"].ToString();
                    page.vStr3 = Session["AreaName"].ToString();
                    int ColCount = 5;
                    var cols = new[] { 125, 125, 125, 150, 225 };

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
                    cell.Phrase = new iTextSharp.text.Phrase(" سند صرف رقم ", nationalTextFont16);
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
                    cell.FixedHeight = 20f;
                    cell.Border = 0;
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    table11.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table11.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    //cell.Border = 0;
                    //cell.Phrase = new iTextSharp.text.Phrase("رقم السند:", nationalTextFont14);
                    //table.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    //cell.Phrase = new iTextSharp.text.Phrase(txtVouNo.Text + "/" + int.Parse(vAreaNo).ToString(), nationalTextFont);
                    //table.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("التاريخ:", nationalTextFont);
                    table11.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(txtVouDate.Text, nationalTextFont);
                    table11.AddCell(cell);
                    //
                    //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("نوع الدفع:", nationalTextFont);
                    table11.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if (ChkCheque.Checked) cell.Phrase = new iTextSharp.text.Phrase("بشيك", nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("نقداً", nationalTextFont);
                    table11.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("مبلغ وقدرة:", nationalTextFont);
                    table11.AddCell(cell);

                    //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(txtNet.Text, nationalTextFont);
                    table11.AddCell(cell);


                    //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if (ddlType.SelectedValue == "0")
                    {
                        //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        cell.Phrase = new iTextSharp.text.Phrase("فرق مصروف", nationalTextFont);
                        table11.AddCell(cell);

                        //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        cell.Phrase = new iTextSharp.text.Phrase(txtDiscount.Text, nationalTextFont);
                        table11.AddCell(cell);

                        //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                        cell.Phrase = new iTextSharp.text.Phrase("وذلك عن:", nationalTextFont);
                        table11.AddCell(cell);

                        //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        cell.Phrase = new iTextSharp.text.Phrase(txtRemark.Text, nationalTextFont);
                        table11.AddCell(cell);

                        //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                        table11.AddCell(cell);

                        //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                        table11.AddCell(cell);
                    }
                    else
                    {
                        //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        cell.Phrase = new iTextSharp.text.Phrase(page.vStr2, nationalTextFont);
                        table11.AddCell(cell);

                        //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        cell.Phrase = new iTextSharp.text.Phrase(txtRemark.Text, nationalTextFont);
                        table11.AddCell(cell);

                      
                    }
                    //


                    //
                    if (ChkCheque.Checked)
                    {
                        //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        cell.Phrase = new iTextSharp.text.Phrase("تاريخ الشيك:", nationalTextFont);
                        table11.AddCell(cell);

                        //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        cell.Phrase = new iTextSharp.text.Phrase(txtChqDate.Text, nationalTextFont);
                        table11.AddCell(cell);

                        //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        cell.Phrase = new iTextSharp.text.Phrase("رقم الشيك:", nationalTextFont);
                        table11.AddCell(cell);

                        //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        cell.Phrase = new iTextSharp.text.Phrase(txtchqNo.Text, nationalTextFont);
                        table11.AddCell(cell);


                        //cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        cell.Phrase = new iTextSharp.text.Phrase("مسحوب على بنك:", nationalTextFont);
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

                    ColCount = 3;
                    PdfPTable table = new PdfPTable(ColCount);
                    if (ddlType.SelectedValue == "0")
                    {
                       // document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                        cols = new[] { 200, 400, 150 };                        
                        table.TotalWidth = document.PageSize.Width; //100f;
                        table.SetWidths(cols);
                        table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                        table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell = new PdfPCell();
                        cell.FixedHeight = 20f;
                        cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.Phrase = new iTextSharp.text.Phrase("رقم المستند", nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("البيان", nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("المبلغ", nationalTextFont);
                        table.AddCell(cell);

                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                        foreach (myInv2 itm in VouData)
                        {
                            if (itm.VouNo2.Split('/').Count()>1)
                            {
                                cell.Phrase = new iTextSharp.text.Phrase(itm.VouNo2.Split('/')[1] + "/" + itm.VouNo2.Split('/')[0], nationalTextFont);
                                table.AddCell(cell);
                            }
                            else
                            {
                                cell.Phrase = new iTextSharp.text.Phrase(itm.VouNo2, nationalTextFont);
                                table.AddCell(cell);
                            }

                            cell.Phrase = new iTextSharp.text.Phrase(itm.Name, nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Amount), nationalTextFont);
                            table.AddCell(cell);
                        }
                        document.Add(table);
                    }


                    document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));

                    PdfPTable table50 = new PdfPTable(5);
                    table50.TotalWidth = 100f;
                    PdfPCell cell5 = new PdfPCell();
                    var cols5 = new[] { 150, 150, 150, 150, 150 };
                    table50.SetWidths(cols5);
                    cell5.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell5.FixedHeight = 20f;
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

                    cell5.Phrase = new iTextSharp.text.Phrase("إدخلت بواسطة", nationalTextFont);
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
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.
                        WHITE;
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

                    cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
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
                    //if (ddlType.SelectedValue == "0")
                    //{
                    //    //document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    //    document.Add(table);
                    //}
                    //document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    //document.Add(table50);
                    //document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    //document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
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


        // *************************************************** ITextSharp ****************************************************************
        /*
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
                if (ddlType.SelectedValue != "2")
                {
                    txtDiscount.Text = "0";
                    MakeSum();
                }
                else txtDiscount_TextChanged(null, null);
                short FNo = 1;
                Jv vJv = new Jv();
                double Cram = 0;
                if (ddlType.SelectedValue == "3")
                {
                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                    vJv.FType = 102;
                    vJv.LocType = LocType;
                    vJv.LocNumber = short.Parse(vAreaNo);
                    vJv.Number = int.Parse(txtVouNo.Text);
                    vJv.Post = 1;
                    vJv.FDate = moh.CheckDate(txtVouDate.Text);
                    vJv.DbCode = SiteInfo.PettyExpAcc;
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
                    vJv.BankName = "";
                    vJv.ChequeDate = "";
                    vJv.ChequeNo = "";
                    vJv.InvNo = "";
                    vJv.Amount = moh.StrToDouble(txtNet.Text);
                    Cram += (double)vJv.Amount;
                    vJv.FNo = FNo;
                    vJv.UserName = txtUserName.ToolTip;
                    vJv.UserDate = txtUserDate.Text;
                    vJv.DocType = short.Parse(ddlType.SelectedValue.ToString());
                    vJv.FNo2 = -1;
                    FNo++;
                    vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }
                else
                {
                    foreach (myInv2 itm in VouData)
                    {
                        vJv = new Jv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 102;
                        vJv.LocType = LocType;
                        vJv.LocNumber = short.Parse(vAreaNo);
                        vJv.Number = int.Parse(txtVouNo.Text);
                        vJv.Post = 1;
                        vJv.FDate = moh.CheckDate(txtVouDate.Text);
                        vJv.Amount = itm.Amount;
                        vJv.DbCode = itm.Site;
                        vJv.CrCode = "";
                        vJv.Remark = itm.ShRemark;
                        if (int.Parse(itm.Site.Substring(0, 1)) > 2)
                        {
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

                            /*
                            if (ddlType.SelectedValue == "9")
                            {
                                vJv.CostAcc = "00001";
                                if (itm.Site == "310102004" || itm.Site == "310102006" || itm.Site == "310102007" || itm.Site == "310102009" || itm.Site == "310102010" || itm.Site == "310102011" ||
                                    itm.Site == "310102012" || itm.Site == "310102014" || itm.Site == "310102015" || itm.Site == "310102016" || itm.Site == "310102017" || itm.Site == "310102018" ||
                                    itm.Site == "310102021" || itm.Site == "310102022" || itm.Site == "310102023" || itm.Site == "310102024" || itm.Site == "310102025" || itm.Site == "310102026" ||
                                    itm.Site == "310102029" || itm.Site == "310102035" || itm.Site == "310102038" || itm.Site == "310102042" || itm.Site == "310201008" || itm.Site == "310201009" ||
                                    itm.Site == "310201012" || itm.Site == "310201017" || itm.Site == "310102028")
                                {
                                    vJv.CostAcc = "00002";
                                }

                                if (itm.Site == "310201008" || itm.Site == "310201009" || itm.Site == "310201015" || itm.Site == "310201016" || itm.Site == "310201028")
                                {
                                    vJv.CostCenter = "00016";
                                }
                            }
                             */
                        }
                        else
                        {
                            /*
                            if (ddlType.SelectedValue == "9" && itm.Destination != "" && itm.Site == "240101001")
                            {
                                vJv.Area = itm.Color;
                                vJv.CostCenter = itm.DestinationName1;
                                vJv.Project = itm.DestinationName2;
                                vJv.EmpCode = itm.Destination;
                            }
                            else
                            {
                                vJv.Area = "-1";
                                vJv.CostCenter = "-1";
                                vJv.Project = "-1";
                                vJv.CostAcc = "-1";
                                vJv.EmpCode = "-1";
                                vJv.CarNo = "-1";
                            }
                             */
                            vJv.Area = "-1";
                            vJv.CostCenter = "-1";
                            vJv.Project = "-1";
                            vJv.CostAcc = "-1";
                            vJv.EmpCode = "-1";
                            vJv.CarNo = "-1"; 
                        }
                        vJv.BankName = "";
                        vJv.ChequeDate = "";
                        vJv.ChequeNo = "";
                        vJv.InvNo = itm.VouNo2;
                        vJv.Amount = itm.Amount;
                        Cram += (double)vJv.Amount;
                        vJv.FNo = FNo;
                        vJv.FNo2 = itm.FNo2;
                        vJv.UserName = txtUserName.ToolTip;
                        vJv.UserDate = txtUserDate.Text;
                        vJv.DocType = itm.DocType;
                        vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (itm.DocType == 2)
                        {
                            moh.PostDoc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString,3,short.Parse(Session["Branch"].ToString()),short.Parse(itm.InvoiceVouLoc),itm.InvoiceVouLoc, itm.VouNo,vJv.LocNumber.ToString()+"/"+vJv.Number.ToString(),(short)itm.FNo2 , true);
                            if (itm.VouNo20 != "") moh.PostDoc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, 2, short.Parse(Session["Branch"].ToString()), short.Parse(itm.VouNo20.Split('/')[0]), moh.MakeMask(itm.VouNo20.Split('/')[0], 5), int.Parse(itm.VouNo20.Split('/')[1]), vJv.LocNumber.ToString() + "/" + vJv.Number.ToString(), (short)itm.FNo2, true);
                        }
                        else if (itm.DocType == 0)
                        {
                            moh.PostDoc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, 2, short.Parse(Session["Branch"].ToString()), short.Parse(itm.InvoiceVouLoc), itm.InvoiceVouLoc, itm.VouNo, vJv.LocNumber.ToString() + "/" + vJv.Number.ToString(), (short)itm.FNo2, true);
                        }
                        else if (itm.DocType == 4)
                        {
                            moh.PostDoc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString,1,short.Parse(Session["Branch"].ToString()),short.Parse(itm.InvoiceVouLoc),itm.InvoiceVouLoc, itm.VouNo,vJv.LocNumber.ToString()+"/"+vJv.Number.ToString(),(short)itm.FNo2 , true);
                        }                        
                        FNo++;
                    }
                }

                if(ddlType.SelectedValue == "2" && moh.StrToDouble(txtDiscount.Text)>0)
                {
                    vJv = new Jv();
                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                    vJv.FType = 102;
                    vJv.LocType = LocType;
                    vJv.LocNumber = short.Parse(vAreaNo);
                    vJv.Number = int.Parse(txtVouNo.Text);
                    vJv.Post = 1;
                    vJv.FDate = moh.CheckDate(txtVouDate.Text);
                    vJv.DbCode = SiteInfo.RadAcc;
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
                    vJv.BankName = "";
                    vJv.ChequeDate = "";
                    vJv.ChequeNo = "";
                    vJv.InvNo = "";
                    vJv.Amount = moh.StrToDouble(txtDiscount.Text);
                    Cram += (double)vJv.Amount;
                    vJv.FNo = FNo;
                    vJv.UserName = txtUserName.ToolTip;
                    vJv.UserDate = txtUserDate.Text;
                    vJv.DocType = short.Parse(ddlType.SelectedValue.ToString());
                    vJv.FNo2 = -1;
                    FNo++;
                    vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }

                vJv = new Jv();
                vJv.Branch = short.Parse(Session["Branch"].ToString());
                vJv.FType = 102;
                vJv.LocType = LocType;
                vJv.LocNumber = short.Parse(vAreaNo);
                vJv.Number = int.Parse(txtVouNo.Text);
                vJv.Post = 1;
                vJv.FDate = moh.CheckDate(txtVouDate.Text);
                if (ddlDbCode.SelectedValue == "-1")
                {
                    ddlDbCode.SelectedValue = SiteInfo.LoanAcc;
                }
                vJv.CrCode = ddlDbCode.SelectedValue;               
                vJv.DbCode = "";
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
                vJv.Amount = Cram; // moh.StrToDouble(txtNet.Text);
                vJv.FNo = FNo;
                vJv.UserName = txtUserName.ToolTip;
                vJv.UserDate = txtUserDate.Text;
                vJv.DocType = short.Parse(ddlType.SelectedValue.ToString());
                vJv.FNo2 = -1;
                FNo++;
                vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
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
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
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


                    for (int i = 0; i < VouData.Count; i++)
                    {
                        if (VouData[i].VouNo == int.Parse(txtVouNo2.Text.Split('/')[1]) && VouData[i].DocType == short.Parse(ddlType.SelectedValue))
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "المستند تم ادخاله من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                    }

                    double Amount = 0;
                    String Name = "";

                    if (ddlType.SelectedValue == "2")
                    {
                        //Jv vJv = new Jv();
                        //vJv.Branch = short.Parse(Session["Branch"].ToString());
                        //vJv.FType = 102;
                        //vJv.LocType = LocType;
                        //vJv.LocNumber = short.Parse(vAreaNo);
                        //vJv.InvNo = txtVouNo2.Text;
                        //vJv.DocType = short.Parse(ddlType.SelectedValue);
                        //vJv = vJv.findInvNo20(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        //if (vJv != null)
                        //{
                        //    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        //    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        //    LblCodesResult.Text = "تم أدراج المستند في سند الصرف رقم " + vJv.LocNumber.ToString() + "/" + vJv.Number.ToString();
                        //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        //    return;
                        //}


                        Jv vJv = new Jv();
                        vJv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                        vJv.FType = 102;
                        vJv.InvNo = txtVouNo2.Text;
                        vJv.DocType = 2;
                        double totamount = 0;
                        string vError = "";
                        bool vGet = true;
                        foreach (Jv itm in vJv.findInvNo200(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
                        {
                            if (vGet)
                            {
                                vError += "تم أدراج المستند في سند الصرف رقم  ";
                                vGet = false;
                            }
                            vError += "  " + itm.LocNumber.ToString() + "/" + itm.Number.ToString();
                            totamount += (double)itm.Amount;
                        }

                        vJv = new Jv();
                        vJv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                        vJv.FType = 106;
                        vJv.InvNo = txtVouNo2.Text;
                        vJv.DocType = 2;
                        vGet = true;
                        foreach (Jv itm in vJv.findInvNo200(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
                        {
                            if (vGet)
                            {
                                if (totamount > 0) vError += "  " + "تم أدراج المستند في التحويل البنكي رقم  ";
                                else vError = "تم أدراج المستند في التحويل البنكي رقم  ";
                                vGet = false;
                            }
                            vError += "  " + itm.LocNumber.ToString() + "/" + itm.Number.ToString();
                            totamount += (double)itm.Amount;
                        }



                        CarMove myCar = new CarMove();
                        myCar.Branch = short.Parse(Session["Branch"].ToString());
                        myCar.VouLoc = moh.MakeMask(txtVouNo2.Text.Split('/')[0], 5);
                        myCar.Number = int.Parse(txtVouNo2.Text.Split('/')[1]);
                        myCar = myCar.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                        if (myCar != null)
                        {

                            if ((bool)myCar.NoCost)
                            {
                                grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "بيان الترحيل بدون مصرف طريق";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }


                            CarMoveRCV rcv = new CarMoveRCV();
                            rcv.Branch = short.Parse(Session["Branch"].ToString());
                            rcv.CarMove = myCar.CarMoveNo2;
                            rcv = rcv.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (rcv == null)
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "يجب تسجيل بيان وصول قبل سند الصرف";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }


                            if ((DateTime.Parse(txtVouDate.Text) - DateTime.Parse(myCar.GDate)).TotalDays >= gNoDays && !Session["CurrentUser"].ToString().ToUpper().Contains("ADMIN"))
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد تم اغلاق الفترة";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }

                            //CarPrices myPrice = new CarPrices();
                            //myPrice.Branch = short.Parse(Session["Branch"].ToString());
                            //myPrice.MonthNo = 0;
                            //myPrice.FromCode = myCar.FromLoc;
                            //myPrice.PLevel = "00002";
                            //myPrice.toCode = myCar.ToLoc;
                            //myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            //if (myPrice != null)
                            //{
                                //Amount = (double)myPrice.CostAmount;
                                //CarMoveLines myCarMoveLine = new CarMoveLines();
                                //myCarMoveLine.Branch = short.Parse(Session["Branch"].ToString());
                                //myCarMoveLine.VouLoc = moh.MakeMask(txtVouNo2.Text.Split('/')[0], 5);
                                //myCarMoveLine.Number = int.Parse(txtVouNo2.Text.Split('/')[1]);
                                //foreach (CarMoveLines itm in myCarMoveLine.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                //{
                                //    if (itm.FromLoc == "-1" && itm.LineFNo != 1) Amount -= (double)itm.Cost;
                                //    else Amount += (double)itm.Cost;
                                //}

                            vJv = new Jv();
                            vJv.Branch = short.Parse(Session["Branch"].ToString());
                            vJv.FType = 104;
                            vJv.LocType = 2;
                            vJv.LocNumber = short.Parse(txtVouNo2.Text.Split('/')[0]);
                            vJv.Number = int.Parse(txtVouNo2.Text.Split('/')[1]);
                            vJv = (from itm in vJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                   where itm.CrCode !=""
                                   select itm).FirstOrDefault();
                            if (vJv != null)
                            {
                                if ((bool)myCar.Rent)
                                {
                                    Amount = (double)myCar.RentValue - totamount;
                                    Name = SiteInfo.CurExpAcc;
                                    VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myCar.Number, InvoiceVouLoc = myCar.VouLoc, Name = myCar.RentDriver, Amount = Amount, DocType = short.Parse(ddlType.SelectedValue), Site = "240104005" });
                                    // MakeSum();
                                    LoadVouData();
                                }
                                else
                                {

                                    Amount = (double)vJv.Amount - totamount;
                                    Name = SiteInfo.CurExpAcc;
                                    Drivers myDrive = new Drivers();
                                    myDrive.Branch = short.Parse(Session["Branch"].ToString());
                                    if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                    myDrive.Code = myCar.DriverCode;
                                    myDrive = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                                               where sitm.Code == myDrive.Code
                                               select sitm).FirstOrDefault();
                                    if (myDrive != null)
                                    {
                                        VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myCar.Number, InvoiceVouLoc = myCar.VouLoc, Name = myDrive.Name1, Amount = Amount, DocType = short.Parse(ddlType.SelectedValue), Site = SiteInfo.CurExpAcc });
                                    }
                                    else
                                    {
                                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                        LblCodesResult.Text = "بيانات السائق غير مدرجه من قبل";
                                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                        return;
                                    }
                                }
                                LblCodesResult.Text = vError;
                            }


                                
                            //}
                            //else
                            //{
                            //    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            //    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            //    LblCodesResult.Text = "جهة المستند غير مدرجه من قبل";
                            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            //    return;
                            //}
                     


                        }
                        else
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم بيان الترحيل غير مدرج من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                    }
                    else if (ddlType.SelectedValue == "0")
                    {
                        List<MyPO> lJv = new List<MyPO>();
                        MyPO inv = new MyPO();
                        inv.Branch = short.Parse(Session["Branch"].ToString());
                        inv.FType = 1;
                        inv.LocNumber = short.Parse(txtVouNo2.Text.Split('/')[0]);
                        inv.Number = int.Parse(txtVouNo2.Text.Split('/')[1]);
                        lJv = inv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (lJv == null || lJv.Count == 0)
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم الطلب غير مدرج من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                        foreach (MyPO itm in lJv)
                        {
                            if (itm.Approved == 1 && itm.VouNo2 == "")
                            {
                                VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = itm.Number, InvoiceVouLoc = moh.MakeMask(itm.LocNumber.ToString(), 5), Name = itm.Item, Amount = itm.Amount, DocType = short.Parse(ddlType.SelectedValue), Site = SiteInfo.PettyExpAcc, FNo2 = itm.FNo });
                            }
                        }
                    }
                    else if (ddlType.SelectedValue == "4")
                    {
                        List<MyPO> lJv = new List<MyPO>();
                        MyPO inv = new MyPO();
                        inv.Branch = short.Parse(Session["Branch"].ToString());
                        inv.FType = 2;
                        inv.LocNumber = short.Parse(txtVouNo2.Text.Split('/')[0]);
                        inv.Number = int.Parse(txtVouNo2.Text.Split('/')[1]);
                        lJv = inv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (lJv == null || lJv.Count == 0)
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم الطلب غير مدرج من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                        foreach (MyPO itm in lJv)
                        {
                            if (itm.Approved == 1 && itm.VouNo2 == "")
                            {
                                if (itm.VouNo != "")
                                {
                                    CarMove myCar = new CarMove();
                                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                                    myCar.VouLoc = moh.MakeMask(itm.VouNo.Split('/')[0], 5);
                                    myCar.Number = int.Parse(itm.VouNo.Split('/')[1]);
                                    myCar = myCar.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                                    if (myCar != null && myCar.VouNo2 == "")
                                    {
                                        Drivers myDrive = new Drivers();
                                        myDrive.Branch = short.Parse(Session["Branch"].ToString());
                                        if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                        myDrive.Code = myCar.DriverCode;
                                        myDrive = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                                                   where sitm.Code == myDrive.Code
                                                   select sitm).FirstOrDefault();
                                        if (myDrive != null)
                                        {
                                            bool found = false;
                                            for (int i = 0; i < VouData.Count; i++)
                                            {                                                
                                                if (VouData[i].VouNo == myCar.Number && VouData[i].DocType == 0)
                                                {
                                                    found = true;
                                                    break;
                                                }
                                            }
                                            
                                            // Check Paid CarMove Before
                                            if (!found) VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myCar.Number, InvoiceVouLoc = myCar.VouLoc, Name = myDrive.Name1, Amount = itm.Amount, DocType = 0 , Site = SiteInfo.CurExpAcc , FNo2 = itm.FNo , VouNo20 = itm.LocNumber.ToString()+"/"+itm.Number.ToString() });
                                        }
                                    }
                                }
                                else VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = itm.Number, InvoiceVouLoc = moh.MakeMask(itm.LocNumber.ToString(), 5), Name = itm.Item, Amount = itm.Amount, DocType = short.Parse(ddlType.SelectedValue), Site = SiteInfo.PettyExpAcc, FNo2 = itm.FNo });
                            }
                        }
                    }
                    else if (ddlType.SelectedValue == "5")
                    {
                        Jv vJv = new Jv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 102;
                        vJv.LocType = LocType;
                        vJv.LocNumber = short.Parse(vAreaNo);
                        vJv.InvNo = txtVouNo2.Text;
                        vJv.DocType = short.Parse(ddlType.SelectedValue);
                        vJv = vJv.findInvNo20(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (vJv != null)
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "تم أدراج المستند في سند الصرف رقم " + vJv.LocNumber.ToString() + "/" + vJv.Number.ToString();
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                        vJv = new Jv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 100;
                        vJv.LocType = 1;
                        vJv.LocNumber = short.Parse(vAreaNo);
                        vJv.InvNo = txtVouNo2.Text;
                        vJv.DocType = 5;
                        vJv = vJv.findInvNo20(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (vJv != null)
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "تم أدراج المستند في قيد اليومية رقم " +  vJv.Number.ToString();
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                        FastRepair myRepair = new FastRepair();
                        myRepair.Branch = short.Parse(Session["Branch"].ToString());
                        myRepair.LocType = (short)(txtVouNo2.Text.Split('/')[0] == "001" ? 3 : 2);
                        myRepair.VouLoc = short.Parse(txtVouNo2.Text.Split('/')[0]);
                        myRepair.VouNo = int.Parse(txtVouNo2.Text.Split('/')[1]);
                        myRepair = myRepair.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myRepair != null)
                        {
                            if ((DateTime.Parse(txtVouDate.Text) - DateTime.Parse(myRepair.VouDate)).TotalDays >= gNoDays && !Session["CurrentUser"].ToString().ToUpper().Contains("ADMIN"))
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد تم اغلاق الفترة";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }


                            Agreement myAgree = new Agreement();
                            myAgree.FType = 801;
                            myAgree.LocType = (short)(txtVouNo2.Text.Split('/')[0] == "001" ? 3 : 2);
                            myAgree.LocNumber = short.Parse(txtVouNo2.Text.Split('/')[0]);
                            myAgree.Number = int.Parse(txtVouNo2.Text.Split('/')[1]);
                            myAgree.FNo = 3;
                            myAgree = myAgree.FindFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if(myAgree == null)
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لم يتم اعتماد بيان الاصلاح من الإدارة المالية بعد";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }

                            Jv myJv = new Jv();
                            vJv mJv = new vJv();
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.FType = 801;
                            myJv.LocType = (short)(txtVouNo2.Text.Split('/')[0] == "001" ? 3 : 2);
                            myJv.LocNumber = short.Parse(txtVouNo2.Text.Split('/')[0]);
                            myJv.Number = int.Parse(txtVouNo2.Text.Split('/')[1]);
                            mJv = (from itm in myJv.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                   where itm.CrCode != ""
                                   select itm).FirstOrDefault();

                            VouData.Add(new myInv2 { FNo = VouData.Count() + 1, LocType = (short)(txtVouNo2.Text.Split('/')[0] == "001" ? 3 : 2) ,VouNo = myRepair.VouNo, InvoiceVouLoc = moh.MakeMask(myRepair.VouLoc.ToString(), 5), Name = mJv.AccName1, Amount = mJv.Amount, DocType = short.Parse(ddlType.SelectedValue), Site = mJv.CrCode , FNo2 = 0 });
                        }
                        else
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم بيان الاصلاح الخارجي غير مدرج من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                    }
                    else if (ddlType.SelectedValue == "9")
                    {
                        Jv vJv = new Jv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 102;
                        vJv.LocType = LocType;
                        vJv.LocNumber = short.Parse(vAreaNo);
                        vJv.InvNo = txtVouNo2.Text;
                        vJv.DocType = short.Parse(ddlType.SelectedValue);
                        vJv = vJv.findInvNo20(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (vJv != null)
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "تم أدراج المستند في سند الصرف رقم " + vJv.LocNumber.ToString() + "/" + vJv.Number.ToString();
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                        vJv = new Jv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 100;
                        vJv.LocType = 1;
                        vJv.LocNumber = short.Parse(vAreaNo);
                        vJv.InvNo = txtVouNo2.Text;
                        vJv.DocType = short.Parse(ddlType.SelectedValue);
                        vJv = vJv.findInvNo20(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (vJv != null)
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "تم أدراج المستند في قيد اليومية رقم " + vJv.Number.ToString();
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                        List<PettyCash> lp = new List<PettyCash>();
                        PettyCash myPettyCash = new PettyCash();
                        myPettyCash.Branch = short.Parse(Session["Branch"].ToString());
                        myPettyCash.LocType = (short)(txtVouNo2.Text.Split('/')[0] == "001" ? 3 : 2);
                        myPettyCash.VouLoc = short.Parse(txtVouNo2.Text.Split('/')[0]);
                        myPettyCash.VouNo = int.Parse(txtVouNo2.Text.Split('/')[1]);
                        lp = myPettyCash.find3(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (lp != null)
                        {
                            if ((DateTime.Parse(txtVouDate.Text) - DateTime.Parse(lp[0].VouDate)).TotalDays >= gNoDays && !Session["CurrentUser"].ToString().ToUpper().Contains("ADMIN"))
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد تم اغلاق الفترة";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }

                            foreach (PettyCash itm in lp)
                            {
                                txtRemark.Text += " " + itm.Remark;
                            }

                            Agreement myAgree = new Agreement();
                            myAgree.FType = 802;
                            myAgree.LocType = (short)(txtVouNo2.Text.Split('/')[0] == "001" ? 3 : 2);
                            myAgree.LocNumber = short.Parse(txtVouNo2.Text.Split('/')[0]);
                            myAgree.Number = int.Parse(txtVouNo2.Text.Split('/')[1]);
                            myAgree.FNo = 3;
                            myAgree = myAgree.FindFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myAgree == null)
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لم يتم اعتماد بيان المصروفات النثرية من الإدارة المالية بعد";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }

                            Jv myJv = new Jv();
                            vJv mJv = new vJv();
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.FType = 802;
                            myJv.LocType = (short)(txtVouNo2.Text.Split('/')[0] == "001" ? 3 : 2);
                            myJv.LocNumber = short.Parse(txtVouNo2.Text.Split('/')[0]);
                            myJv.Number = int.Parse(txtVouNo2.Text.Split('/')[1]);
                            mJv = (from itm in myJv.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                   where itm.CrCode != ""
                                   select itm).FirstOrDefault();

                            VouData.Add(new myInv2 { FNo = VouData.Count() + 1, LocType = (short)(txtVouNo2.Text.Split('/')[0] == "001" ? 3 : 2), VouNo = lp[0].VouNo, InvoiceVouLoc = moh.MakeMask(lp[0].VouLoc.ToString(), 5), Name = mJv.AccName1, Amount = mJv.Amount, DocType = short.Parse(ddlType.SelectedValue), Site = mJv.CrCode, FNo2 = 0 });

                            /*
                            double Tax = 0;
                            foreach (PettyCash itm in lp)
                            {
                                Acc myAcc = new Acc();                                
                                Tax += (double)itm.Tax;
                                if (itm.Emp != "")
                                {
                                    myAcc.Branch = short.Parse(Session["Branch"].ToString());
                                    myAcc.Code = "12050" + itm.Emp;
                                    myAcc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                }

                                VouData.Add(new myInv2 { FNo = itm.FNo, LocType = (short)(txtVouNo2.Text.Split('/')[0] == "001" ? 3 : 2), VouNo = itm.VouNo, InvoiceVouLoc = moh.MakeMask(itm.VouLoc.ToString(), 5), Name = itm.Name, Amount = itm.Amount, DocType = short.Parse(ddlType.SelectedValue), Site = itm.Code,FNo2 = 0 , ShRemark = itm.Remark,
                                                         Destination = (itm.Emp != "" ? itm.Emp : ""),
                                                         Color = (itm.Emp != "" && myAcc != null ? myAcc.Area : ""),
                                                         DestinationName1 = (itm.Emp != "" && myAcc != null ? myAcc.CostCenter : ""),
                                                         DestinationName2 = (itm.Emp != "" && myAcc != null ? myAcc.Project : "")
                                });
                                txtRemark.Text += " " + itm.Remark;
                            }
                            if (Tax > 0)
                            {
                                Acc myAcc = new Acc();
                                myAcc.Branch = short.Parse(Session["Branch"].ToString());
                                myAcc.Code = gInTax;
                                if (myAcc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                {
                                    VouData.Add(new myInv2 { FNo = VouData.Count() + 1, LocType = (short)(txtVouNo2.Text.Split('/')[0] == "001" ? 3 : 2), VouNo = lp[0].VouNo, InvoiceVouLoc = moh.MakeMask(lp[0].VouLoc.ToString(), 5), Name = myAcc.Name1, Amount = Tax, DocType = short.Parse(ddlType.SelectedValue), Site = gInTax, FNo2 = 0 });
                                }
                            }
                             */
                        }
                        else
                        {
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم بيان المصروفات النثرية غير مدرج من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                    }
                    // MakeSum();
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
                VouData.RemoveAt(int.Parse(FNo) - 1);
                for (int i = 0; i < VouData.Count; i++)
                {
                    VouData[i].FNo = i + 1;
                }
                e.Cancel = false;
                // MakeSum();
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
                if (ddlType.SelectedValue == "0" || ddlType.SelectedValue == "2" || ddlType.SelectedValue == "4" || ddlType.SelectedValue == "5" || ddlType.SelectedValue == "9")
                {
                    double Amount = 0;
                    foreach (myInv2 itm in VouData)
                    {
                        Amount += (double)itm.Amount;
                    }
                    txtAmount.Text = string.Format("{0:N2}", Amount);
                }
                if (txtDiscount.Text == "") txtDiscount.Text = string.Format("{0:N2}", 0);
                txtNet.Text = string.Format("{0:N2}", moh.StrToDouble(txtAmount.Text) + moh.StrToDouble(txtDiscount.Text));
                if (moh.StrToDouble(txtAmount.Text) > 0 || moh.StrToDouble(txtNet.Text) != 0) this.ddlType.Enabled = false;
                else this.ddlType.Enabled = true;

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
                if (txtAmount.Text == "") txtAmount.Text = string.Format("{0:N2}", 0);
                if (txtDiscount.Text == "") txtDiscount.Text = string.Format("{0:N2}", 0);
                txtNet.Text = string.Format("{0:N2}", moh.StrToDouble(txtAmount.Text) + moh.StrToDouble(txtDiscount.Text));
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
                        myArch.LocNumber = short.Parse(vAreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 506;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(vAreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 506;
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
                myArch.LocNumber = short.Parse(vAreaNo);
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = 506;
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
                myArch.LocNumber = short.Parse(vAreaNo);
                myArch.Number = txtVouNo.Text != "" ? int.Parse(txtVouNo.Text) : 9999999;
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
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text == "")
                {
                    BtnNew.Visible = true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass251;
                    //BtnNew.Visible = true;
                }
                if (ddlType.SelectedValue == "2")
                {
                    txtRemark.Text = "قيمة بيانات الترحيل المدرجة أدناه";
                    //txtRemark.ReadOnly = true;
                }
                else if (ddlType.SelectedValue == "3")
                {
                    BtnNew.Visible = false;
                }
                else if (ddlType.SelectedValue == "5")
                {
                    txtRemark.Text = "قيمة بيانات الاصلاح الخارجي المدرجة أدناه";
                }
                else if (ddlType.SelectedValue == "9")
                {
                    txtRemark.Text = "قيمة بيانات المصروفات المتنوعة المدرجة أدناه";
                }
                else
                {
                    txtRemark.Text = "";
                    //txtRemark.ReadOnly = false;
                }
                txtNet.Visible = (ddlType.SelectedValue == "2");
                txtDiscount.Visible = (ddlType.SelectedValue == "2");
                Label7.Visible = (ddlType.SelectedValue == "2");
                Label12.Visible = (ddlType.SelectedValue == "2");

                txtAmount.ReadOnly = (ddlType.SelectedValue != "3");
                divGrid.Visible = (ddlType.SelectedValue != "3");
                grdCodes_RowCancelingEdit(sender, null);
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

        public void ValidateNum()
        {
            if (txtAmount.Text == "") txtAmount.Text = "0";
            if (txtDiscount.Text == "") txtDiscount.Text = "0";
            if (txtNet.Text == "") txtNet.Text = "0";            
        }


        public bool ValidateVou()
        {
            bool Valid = true;
            foreach(myInv2 itm in VouData)
            {
                if (ddlType.SelectedValue == "2")
                {
                    CarMove myCar = new CarMove();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                    myCar.VouLoc = itm.InvoiceVouLoc;
                    myCar.Number = itm.VouNo;
                    List<CarMove> lCarMove = new List<CarMove>();
                    lCarMove = myCar.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (lCarMove != null && lCarMove.Count>0)
                    {
                        foreach(CarMove CarMoveItm in lCarMove)
                        {
                            if (CarMoveItm.VouNo2 != "" && CarMoveItm.VouNo2 != short.Parse(vAreaNo).ToString()+"/"+txtVouNo.Text)
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "تم أدراج المستند "+ int.Parse(CarMoveItm.VouLoc).ToString()+"/"+CarMoveItm.Number.ToString() + " في سند الصرف رقم " + CarMoveItm.VouNo2;
                                Valid = false;
                                break;                                
                            }
                        }
                        if(!Valid) break;
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم بيان الترحيل غير مدرج من قبل " + int.Parse(myCar.VouLoc).ToString() + "/" + myCar.Number.ToString();
                        Valid = false;
                        break;                                                    
                    }
                }
                else if (ddlType.SelectedValue == "0")
                {
                    List<MyPO> lJv = new List<MyPO>();
                    MyPO inv = new MyPO();
                    inv.Branch = short.Parse(Session["Branch"].ToString());
                    inv.FType = 1;
                    inv.LocNumber = short.Parse(itm.InvoiceVouLoc);
                    inv.Number = itm.VouNo;
                    lJv = inv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if(lJv == null || lJv.Count==0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الطلب غير مدرج من قبل " + inv.LocNumber.ToString() + "/" + inv.Number.ToString();
                        Valid = false;
                        break;                                                                        
                    }
                    foreach (MyPO MyPOitm in lJv)
                    {
                        if (itm.FNo2 == MyPOitm.FNo )
                        {
                            if(MyPOitm.Approved != 1)
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "البند غير معتمد "+ inv.LocNumber.ToString() + "/" + inv.Number.ToString();
                                Valid = false;
                                break;
                            }
                            if (MyPOitm.VouNo2 != "" && MyPOitm.VouNo2 != short.Parse(vAreaNo).ToString() + "/" + txtVouNo.Text)
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "تم أدراج المستند "+ MyPOitm.LocNumber.ToString()+"/"+MyPOitm.Number.ToString()+"-" +MyPOitm.FNo.ToString()+ " في سند الصرف رقم " + MyPOitm.VouNo2;
                                Valid = false;
                                break;
                            }
                        }
                    }
                    if(!Valid) break;
                }
                else if (ddlType.SelectedValue == "4")
                {
                    List<MyPO> lJv = new List<MyPO>();
                    MyPO inv = new MyPO();
                    inv.Branch = short.Parse(Session["Branch"].ToString());
                    inv.FType = 2;
                    inv.LocNumber = short.Parse(itm.InvoiceVouLoc);
                    inv.Number = itm.VouNo;
                    lJv = inv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (lJv == null || lJv.Count == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الطلب غير مدرج من قبل " + inv.LocNumber.ToString() + "/" + inv.Number.ToString();
                        Valid = false;
                        break;
                    }
                    foreach (MyPO MyPOitm in lJv)
                    {
                        string VouNo = MyPOitm.VouNo2;
                        if (VouNo == "") VouNo = MyPOitm.VouNo;
                        if (itm.FNo2 == MyPOitm.FNo)
                        {
                            if (MyPOitm.Approved != 1)
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "البند غير معتمد " + inv.LocNumber.ToString() + "/" + inv.Number.ToString();
                                Valid = false;
                                break;
                            }
                            if (MyPOitm.VouNo2 != "" && MyPOitm.VouNo2 != short.Parse(vAreaNo).ToString() + "/" + txtVouNo.Text)
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "تم أدراج المستند " + MyPOitm.LocNumber.ToString() + "/" + MyPOitm.Number.ToString() + "-" + MyPOitm.FNo.ToString() + " في سند الصرف رقم " + MyPOitm.VouNo2;
                                Valid = false;
                                break;
                            }
                        }
                    }
                    if (!Valid) break;
                }
                else if (ddlType.SelectedValue == "5")
                {
                    //if (!Valid) break;
                }
            }
            return Valid;
        }

        protected string UrlHelper(object FType, object Number)
        {
            string[] vs = Number.ToString().Split('/');
            if (vs.Count() > 1)
            {
                if (this.ddlType.SelectedValue == "2") return (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass416 ? "~/WebCarMove.aspx?FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&Flag=0&StoreNo=" + StoreNo : "";
                else if (this.ddlType.SelectedValue == "9") return (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass416 ? vs[0] == "001" ? "~/WebPettyCash.aspx?FType=1&FNum=" + vs[1] + "&AreaNo=" + AreaNo + "&Flag=0&StoreNo=" + StoreNo : "~/WebPettyCash.aspx?FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&Flag=0&StoreNo=" + StoreNo : "";
//                else if (this.ddlType.SelectedValue == "4") return (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass416 ? "~/WebCarMove.aspx?FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&Flag=0&StoreNo=" + StoreNo : "";
                else if (this.ddlType.SelectedValue == "5") return (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass416 ? vs[0] == "001" ? "~/WebFastRepair.aspx?FType=1&FNum=" + vs[1] + "&AreaNo=" + AreaNo + "&Flag=0&StoreNo=" + StoreNo : "~/WebFastRepair.aspx?FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&Flag=0&StoreNo=" + StoreNo : "";
                else return "";
            }
            else return "";
        }

        public void SaveTrans(short? UOP)
        {
            string vUserDate2 = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
            short FNo = 1;
            Jv vJv = new Jv();
            double Cram = 0;
            if (ddlType.SelectedValue == "3")
            {
                vJv.Branch = short.Parse(Session["Branch"].ToString());
                vJv.UserDate2 = vUserDate2;
                vJv.UserOP = UOP;
                vJv.FType = 102;
                vJv.LocType = LocType;
                vJv.LocNumber = short.Parse(vAreaNo);
                vJv.Number = int.Parse(txtVouNo.Text);
                vJv.Post = 1;
                vJv.FDate = moh.CheckDate(txtVouDate.Text);
                vJv.DbCode = SiteInfo.PettyExpAcc;
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
                vJv.BankName = "";
                vJv.ChequeDate = "";
                vJv.ChequeNo = "";
                vJv.InvNo = "";
                vJv.Amount = moh.StrToDouble(txtNet.Text);
                Cram += (double)vJv.Amount;
                vJv.FNo = FNo;
                vJv.UserName = Session["FullUser"].ToString();
                vJv.UserDate = txtUserDate.Text;
                vJv.DocType = short.Parse(ddlType.SelectedValue.ToString());
                vJv.FNo2 = -1;
                FNo++;
                vJv.pAdd(WebConfigurationManager.ConnectionStrings["MyCnnTrans"].ConnectionString);
            }
            else
            {
                foreach (myInv2 itm in VouData)
                {
                    vJv = new Jv();
                    vJv.UserDate2 = vUserDate2;
                    vJv.UserOP = UOP;
                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                    vJv.FType = 102;
                    vJv.LocType = LocType;
                    vJv.LocNumber = short.Parse(vAreaNo);
                    vJv.Number = int.Parse(txtVouNo.Text);
                    vJv.Post = 1;
                    vJv.FDate = moh.CheckDate(txtVouDate.Text);
                    vJv.Amount = itm.Amount;
                    vJv.DbCode = itm.Site;
                    vJv.CrCode = "";
                    if (int.Parse(itm.Site.Substring(0, 1)) > 2)
                    {
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
                    }
                    else
                    {
                        vJv.Area = "-1";
                        vJv.CostCenter = "-1";
                        vJv.Project = "-1";
                        vJv.CostAcc = "-1";
                        vJv.EmpCode = "-1";
                        vJv.CarNo = "-1";
                    }
                    vJv.Remark = txtRemark.Text;
                    vJv.BankName = "";
                    vJv.ChequeDate = "";
                    vJv.ChequeNo = "";
                    vJv.InvNo = itm.VouNo2;
                    vJv.Amount = itm.Amount;
                    Cram += (double)vJv.Amount;
                    vJv.FNo = FNo;
                    vJv.FNo2 = itm.FNo2;
                    vJv.UserName = Session["FullUser"].ToString();
                    vJv.UserDate = txtUserDate.Text;
                    vJv.DocType = itm.DocType;
                    vJv.pAdd(WebConfigurationManager.ConnectionStrings["MyCnnTrans"].ConnectionString);
                    FNo++;
                }
            }

            if (ddlType.SelectedValue == "2" && moh.StrToDouble(txtDiscount.Text) > 0)
            {
                vJv = new Jv();
                vJv.UserDate2 = vUserDate2;
                vJv.UserOP = UOP;
                vJv.Branch = short.Parse(Session["Branch"].ToString());
                vJv.FType = 102;
                vJv.LocType = LocType;
                vJv.LocNumber = short.Parse(vAreaNo);
                vJv.Number = int.Parse(txtVouNo.Text);
                vJv.Post = 1;
                vJv.FDate = moh.CheckDate(txtVouDate.Text);
                vJv.DbCode = SiteInfo.RadAcc;
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
                vJv.BankName = "";
                vJv.ChequeDate = "";
                vJv.ChequeNo = "";
                vJv.InvNo = "";
                vJv.Amount = moh.StrToDouble(txtDiscount.Text);
                Cram += (double)vJv.Amount;
                vJv.FNo = FNo;
                vJv.UserName = Session["FullUser"].ToString();
                vJv.UserDate = txtUserDate.Text;
                vJv.DocType = short.Parse(ddlType.SelectedValue.ToString());
                vJv.FNo2 = -1;
                FNo++;
                vJv.pAdd(WebConfigurationManager.ConnectionStrings["MyCnnTrans"].ConnectionString);
            }

            vJv = new Jv();
            vJv.UserDate2 = vUserDate2;
            vJv.UserOP = UOP;
            vJv.Branch = short.Parse(Session["Branch"].ToString());
            vJv.FType = 102;
            vJv.LocType = LocType;
            vJv.LocNumber = short.Parse(vAreaNo);
            vJv.Number = int.Parse(txtVouNo.Text);
            vJv.Post = 1;
            vJv.FDate = moh.CheckDate(txtVouDate.Text);
            if (ddlDbCode.SelectedValue == "-1")
            {
                ddlDbCode.SelectedValue = SiteInfo.LoanAcc;
            }
            vJv.CrCode = ddlDbCode.SelectedValue;
            vJv.DbCode = "";
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
            vJv.Amount = Cram; // moh.StrToDouble(txtNet.Text);
            vJv.FNo = FNo;
            vJv.UserName = Session["FullUser"].ToString();
            vJv.UserDate = txtUserDate.Text;
            vJv.DocType = short.Parse(ddlType.SelectedValue.ToString());
            vJv.FNo2 = -1;
            FNo++;
            vJv.pAdd(WebConfigurationManager.ConnectionStrings["MyCnnTrans"].ConnectionString);
        }

        protected void grdTrans_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string UserDate2 = grdTrans.DataKeys[e.NewSelectedIndex]["UserDate2"].ToString();
            List<vJv> lJv = new List<vJv>();
            Jv myJv = new Jv();
            myJv.Branch = short.Parse(Session["Branch"].ToString());
            myJv.FType = 102;
            myJv.LocType = LocType;
            myJv.LocNumber = short.Parse(vAreaNo);
            myJv.Number = int.Parse(txtVouNo.Text);
            // BtnClear_Click(null, e);
            lJv = myJv.pfind2(WebConfigurationManager.ConnectionStrings["MyCnnTrans"].ConnectionString);
            if (lJv == null || lJv.Count == 0)
            {
            }
            else
            {
                EditMode();
                VouData.Clear();
                int myItem = lJv.Count - 1;
                txtVouNo.Text = lJv[myItem].Number.ToString();
                txtVouDate.Text = lJv[myItem].FDate;
                txtUserDate.Text = lJv[myItem].UserDate;
                txtUserName.ToolTip = lJv[myItem].UserName;
                TblUsers ax = new TblUsers();
                if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                ax.UserName = lJv[myItem].UserName;
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
                ddlDbCode.SelectedValue = lJv[myItem].CrCode;
                txtBankName.Text = lJv[myItem].BankName;
                txtChqDate.Text = lJv[myItem].ChequeDate;
                txtchqNo.Text = lJv[myItem].ChequeNo;
                txtAmount.Text = string.Format("{0:N2}", lJv[myItem].Amount);
                ChkCheque.Checked = false;
                if (txtBankName.Text != "" || txtChqDate.Text != "" || txtchqNo.Text != "") ChkCheque.Checked = true;
                ChkCheque_CheckedChanged(sender, e);
                ddlType.SelectedValue = lJv[myItem].DocType.ToString();
                ddlType_SelectedIndexChanged(sender, e);
                txtRemark.Text = lJv[myItem].Remark;

                if (lJv[myItem - 1].FNo2 == -1 && ddlType.SelectedValue == "0")
                {
                    txtDiscount.Text = string.Format("{0:N2}", lJv[myItem - 1].Amount);
                }
                if (ddlType.SelectedValue != "0") txtDiscount.Text = "0";
                txtDiscount_TextChanged(sender, e);

                if (ddlType.SelectedValue != "3")
                {
                    VouData.Clear();
                    for (int i = 0; i < lJv.Count(); i++)
                    {
                        if (lJv[i].FNo2 != -1)
                        {
                            if (lJv[i].Area != "-1")
                            {
                                if (LocType == 2 || LocType == 3 || LocType == 4)
                                {

                                }
                                else
                                {
                                    ddlArea.SelectedValue = lJv[i].Area;
                                    ddlCostAcc.SelectedValue = lJv[i].CostAcc;
                                    ddlCostCenter.SelectedValue = lJv[i].CostCenter;
                                    ddlEmp.SelectedValue = lJv[i].EmpCode;
                                    ddlProject.SelectedValue = lJv[i].Project;
                                    ddlCarNo.SelectedValue = lJv[i].CarNo;
                                }
                            }

                            if (lJv[i].DocType == 2)
                            {
                                CarMove myCar = new CarMove();
                                myCar.Branch = short.Parse(Session["Branch"].ToString());
                                myCar.VouLoc = moh.MakeMask(lJv[i].InvNo.Split('/')[0], 5);
                                myCar.Number = int.Parse(lJv[i].InvNo.Split('/')[1]);
                                myCar = myCar.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                                if (myCar != null)
                                {
                                    if ((bool)myCar.Rent)
                                    {
                                        VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myCar.Number, InvoiceVouLoc = myCar.VouLoc, Name = myCar.RentDriver, Amount = lJv[i].Amount, DocType = (short)lJv[i].DocType, Site = lJv[i].DbCode, FNo2 = lJv[i].FNo2 });
                                    }
                                    else
                                    {
                                        Drivers myDrive = new Drivers();
                                        myDrive.Branch = short.Parse(Session["Branch"].ToString());
                                        if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                        myDrive.Code = myCar.DriverCode;
                                        myDrive = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                                                   where sitm.Code == myDrive.Code
                                                   select sitm).FirstOrDefault();
                                        if (myDrive != null)
                                        {
                                            VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = myCar.Number, InvoiceVouLoc = myCar.VouLoc, Name = myDrive.Name1, Amount = lJv[i].Amount, DocType = (short)lJv[i].DocType, Site = lJv[i].DbCode, FNo2 = lJv[i].FNo2 });
                                        }
                                    }
                                }
                            }
                            else if (lJv[i].DocType == 0)
                            {
                                MyPO inv = new MyPO();
                                inv.Branch = short.Parse(Session["Branch"].ToString());
                                inv.FType = 1;
                                inv.LocNumber = short.Parse(lJv[i].InvNo.Split('/')[0]);
                                inv.Number = int.Parse(lJv[i].InvNo.Split('/')[1]);
                                inv.FNo = (short)lJv[i].FNo2;
                                inv = inv.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (inv != null)
                                {
                                    VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = inv.Number, InvoiceVouLoc = moh.MakeMask(inv.LocNumber.ToString(), 5), Name = inv.Item, Amount = lJv[i].Amount, DocType = (short)lJv[i].DocType, Site = lJv[i].DbCode, FNo2 = lJv[i].FNo2 });
                                }
                            }
                            else if (lJv[i].DocType == 4)
                            {
                                MyPO inv = new MyPO();
                                inv.Branch = short.Parse(Session["Branch"].ToString());
                                inv.FType = 1;
                                inv.LocNumber = short.Parse(lJv[i].InvNo.Split('/')[0]);
                                inv.Number = int.Parse(lJv[i].InvNo.Split('/')[1]);
                                inv.FNo = (short)lJv[i].FNo2;
                                inv = inv.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (inv != null)
                                {
                                    VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = inv.Number, InvoiceVouLoc = moh.MakeMask(inv.LocNumber.ToString(), 5), Name = inv.Item, Amount = inv.Amount, DocType = (short)lJv[i].DocType, Site = lJv[i].DbCode, FNo2 = lJv[i].FNo2 });
                                }
                            }
                            else if (lJv[i].DocType == 5 || lJv[i].DocType == 9)
                            {
                                if (lJv[i].DbCode != "")
                                    VouData.Add(new myInv2 { FNo = VouData.Count() + 1, VouNo = int.Parse(lJv[i].InvNo.Split('/')[1]), InvoiceVouLoc = moh.MakeMask(lJv[i].InvNo.Split('/')[0], 5), Name = lJv[i].AccName1, Amount = lJv[i].Amount, DocType = (short)lJv[i].DocType, Site = lJv[i].DbCode, FNo2 = lJv[i].FNo2 });
                            }
                        }
                    }
                    LoadVouData();
                    // MakeSum();
                }
                LoadAttachData();
                MyPO myPo = new MyPO();
                myPo.Branch = short.Parse(Session["Branch"].ToString());
                myPo.FType = (short)(LocType == 3 ? 6 : LocType == 4 ? 4 : 2);
                myPo.LocNumber = short.Parse(vAreaNo);
                myPo.VouNo = (LocType == 3 ? "0" + int.Parse(vAreaNo).ToString() : LocType == 4 ? "00" + int.Parse(vAreaNo).ToString() : int.Parse(vAreaNo).ToString()) + "/" + txtVouNo.Text.Trim();
                myPo = myPo.GetVouNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myPo != null)
                {
                    lblStatus.Text = (LocType == 3 ? @"<a href='WebPPO1.aspx?FType=20&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + myPo.Number.ToString() + @"' target='_blank'> مدرج في طلب الدفع رقم " + "0" + myPo.LocNumber.ToString() + @"/" + myPo.Number.ToString() + @"</a>"
                                     : LocType == 4 ? @"<a href='WebPPO1.aspx?FType=4&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + myPo.Number.ToString() + @"' target='_blank'> مدرج في طلب الدفع رقم " + "00" + myPo.LocNumber.ToString() + @"/" + myPo.Number.ToString() + @"</a>"
                                     : @"<a href='WebPPO1.aspx?AreaNo=" + moh.MakeMask(myPo.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + myPo.Number.ToString() + @"' target='_blank'> مدرج في طلب الدفع رقم " + myPo.LocNumber.ToString() + @"/" + myPo.Number.ToString() + @"</a>");
                    BtnEdit.Visible = false;
                    BtnDelete.Visible = false;
                }
                else lblStatus.Text = "";

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
                myJv.FType = 102;
                myJv.LocType = LocType;
                myJv.LocNumber = short.Parse(vAreaNo);
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



    }
}
