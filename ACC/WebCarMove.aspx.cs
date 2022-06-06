using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using BLL;
using System.Configuration;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class WebCarMove : System.Web.UI.Page
    {
        public List<TrackMove> MyOverTrack
        {
            get
            {
                if (ViewState["MyOverTrack"] == null)
                {
                    ViewState["MyOverTrack"] = new List<TrackMove>();
                }
                return (List<TrackMove>)ViewState["MyOverTrack"];
            }
            set { ViewState["MyOverTrack"] = value; }
        }
        public List<TrackMove> MyOverTrack1
        {
            get
            {
                if (ViewState["MyOverTrack1"] == null)
                {
                    ViewState["MyOverTrack1"] = new List<TrackMove>();
                }
                return (List<TrackMove>)ViewState["MyOverTrack1"];
            }
            set { ViewState["MyOverTrack1"] = value; }
        }
        public List<TrackMove> MyOverTrack2
        {
            get
            {
                if (ViewState["MyOverTrack2"] == null)
                {
                    ViewState["MyOverTrack2"] = new List<TrackMove>();
                }
                return (List<TrackMove>)ViewState["MyOverTrack2"];
            }
            set { ViewState["MyOverTrack2"] = value; }
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
            txtNumber.ReadOnly = true;
            txtNumber.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = true && (Request.QueryString["Support"] != null || (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass215);
            BtnEdit.Visible = true && Request.QueryString["Support"] == null && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass212;
            BtnNew.Visible = false;
            BtnDelete.Visible = true && Request.QueryString["Support"] == null && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass213;
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
            if (BtnEdit.Visible || BtnDelete.Visible)
            {
                txtReason.Visible = true;
                ValReason.Enabled = true;
                lblReason.Visible = true;
            }
            if (Request.QueryString["Support"] != null || !(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass212 || !BtnEdit.Visible) ControlsOnOff(false);
        }

        public void NewMode()
        {
            txtNumber.ReadOnly = true;
            txtNumber.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass211;
            BtnDelete.Visible = false;

            txtReason.Visible = false;
            ValReason.Enabled = false;
            lblReason.Visible = false;

            if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass212 || !BtnEdit.Visible) ControlsOnOff(true);
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
                    this.Page.Header.Title = "بيان الترحيل";
                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "الرئيسية", "اختيار", "اختيار بيان الترحيل", "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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
                    lblBranch.Text = "/" + short.Parse(AreaNo).ToString();

                    Cities myCity = new Cities();
                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlTo.DataTextField = "Name1";
                    ddlTo.DataValueField = "Code";
                    ddlFrom.DataTextField = "Name1";
                    ddlFrom.DataValueField = "Code";
                    ddlTo.DataSource = (from itm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                        orderby itm.Name1
                                        select itm).ToList();
                    ddlFrom.DataSource = ddlTo.DataSource;

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
                    if (Session[vRoleName] != null && Request.QueryString["Support"] == null)
                    {
                        BtnNew.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass211;
                        BtnEdit.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass212;
                        BtnDelete.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass213;
                        BtnSearch.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass214;
                        BtnPrint.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass215;
                        BtnFind.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass214;
                    }

                    ddlTo.DataBind();
                    ddlFrom.DataBind();
                    ddlFrom.Items.Insert(0, new ListItem("--- أختار من ---", "-1", true));
                    ddlTo.Items.Insert(0, new ListItem("--- أختار إلى ---", "-1", true));

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
                        }
                        txtSearch.Text = Request.QueryString["FNum"].ToString();
                        BtnSearch_Click(sender, null);
                    }
                    else
                    {
                        BtnClear_Click(sender, null);
                        if (Request.QueryString["Dest1"] != null)
                        {
                            ddlFrom.SelectedValue = SiteInfo.City;
                            ddlTo.SelectedValue = Request.QueryString["Dest"].ToString();
                            ChkAll.Checked = true;
                            ChkAll_CheckedChanged(null, e);
                            VouData = (from itm in VouData
                                       where (Request.QueryString["Dest"] != null && itm.Destination == Request.QueryString["Dest"].ToString()) ||
                                             (Request.QueryString["Dest1"] != null && itm.Destination == Request.QueryString["Dest1"].ToString()) ||
                                             (Request.QueryString["Dest2"] != null && itm.Destination == Request.QueryString["Dest2"].ToString()) ||
                                             (Request.QueryString["Dest3"] != null && itm.Destination == Request.QueryString["Dest3"].ToString()) ||
                                             (Request.QueryString["Dest4"] != null && itm.Destination == Request.QueryString["Dest4"].ToString()) ||
                                             (Request.QueryString["Dest5"] != null && itm.Destination == Request.QueryString["Dest5"].ToString()) ||
                                             (Request.QueryString["Dest6"] != null && itm.Destination == Request.QueryString["Dest6"].ToString()) ||
                                             (Request.QueryString["Dest7"] != null && itm.Destination == Request.QueryString["Dest7"].ToString()) ||
                                             (Request.QueryString["Dest8"] != null && itm.Destination == Request.QueryString["Dest8"].ToString()) ||
                                             (Request.QueryString["Dest9"] != null && itm.Destination == Request.QueryString["Dest9"].ToString())
                                       orderby DateTime.Parse(itm.GDate)
                                       select itm).ToList();
                            int i = 0;
                            foreach (myInv2 itm in VouData)
                            {
                                itm.Status = true;
                                i++;
                                if(i>7) break;
                            }
                            //VouData.OrderBy(c => c.Status).ThenBy(c => DateTime.Parse(c.GDate));
                            LoadVouData();
                        }
                        else
                        {
                            if (Request.QueryString["Dest"] != null)
                            {
                                ddlFrom.SelectedValue = SiteInfo.City;
                                ddlTo.SelectedValue = Request.QueryString["Dest"].ToString();
                                ChkInvType.Items[0].Selected = true;
                                ChkAll_CheckedChanged(null, e);
                                VouData = (from itm in VouData
                                           orderby DateTime.Parse(itm.GDate)
                                           select itm).ToList();

                                for (int i = 0; i < (VouData.Count() > 8 ? 8 : VouData.Count()); i++)
                                {
                                    VouData[i].Status = true;
                                }
                                LoadVouData();
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

                if (HttpRuntime.Cache["OverTrack2_" + AreaNo + Session["CNN2"].ToString()] == null) ProcessTrackMove();
                ddlDriver.DataTextField = "Driver";
                ddlDriver.DataValueField = "DriverCode";
                ddlDriver.DataSource = (List<TrackMove>)(HttpRuntime.Cache["OverTrack2_" + AreaNo + Session["CNN2"].ToString()]);

                ddlCar.DataTextField = "PlateNo";
                ddlCar.DataValueField = "Code";
                ddlCar.DataSource = (List<TrackMove>)(HttpRuntime.Cache["OverTrack2_" + AreaNo + Session["CNN2"].ToString()]);
                /*
                else
                {
                    Drivers myDrive = new Drivers();
                    myDrive.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlDriver.DataTextField = "Name1";
                    ddlDriver.DataValueField = "Code";
                    ddlDriver.DataSource = (from itm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                                            where (bool)itm.Status && CheckDriverRCV2(itm.Code)
                                            orderby itm.Name1
                                            select itm).ToList();                        

                    Cars myCar = new Cars();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());


                    ddlCar.DataTextField = "PlateNo";
                    ddlCar.DataValueField = "Code";
                    ddlCar.DataSource = (from itm in myCar.GetAll20(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                         where (bool)itm.Status && CheckCarRCV(itm.Code)
                                         select itm).ToList();
                }
                 */
                ddlDriver.DataBind();
                ddlCar.DataBind();
                ddlCar.Items.Insert(0, new ListItem("--- أختار الشاحنة ---", "-1", true));
                ddlDriver.Items.Insert(0, new ListItem("--- أختار السائق ---", "-1", true));

                txtSearch.Text = "";
                txtReason.Text = "";
                txtSearch2.Text = "";
                txtNumber.Text = "";
                txtCarNo.Text = "";
                txtCap.Text = "";
                txtFType2.Text = "";
                txtFType2.ToolTip = "";
                txtRemark.Text = "";
                txtGDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                txtHDate.Text = HDate.getNow();
                LblFTime.Text = String.Format("{0:HH:mm:ss}", moh.Nows());  //moh.Nows().ToShortTimeString();
                ddlFrom.SelectedIndex = 0;
                ddlTo.SelectedIndex = 0;
                ddlDriver.SelectedIndex = 0;
                ddlCar.SelectedIndex = 0;
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                ChkAll.Checked = false;
                CarAlert.Visible = false;
                ChkNoCost.Checked = false;
                txtRentMobileNo.Text = "";
                txtRentDriver.Text = "";
                txtRentValue.Text = "";
                txtRentPlateNo.Text = "";
                ChkRent.Checked = false;
                ChkRent_CheckedChanged(sender, e);

                VouData.Clear();

                CarMove myInv = new CarMove();
                myInv.Branch = short.Parse(Session["Branch"].ToString());
                myInv.VouLoc = AreaNo;
                int? i1 = myInv.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (i1 == 0 || i1 == null)
                {
                    i1 = SiteInfo.CarMoveNo;
                }
                else
                {
                    i1++;
                }
                txtNumber.Text = i1.ToString();
                LoadVouData();
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

        public void ControlsOnOff(bool State)
        {
            txtCarNo.ReadOnly = !State;
            txtCap.ReadOnly = !State;
            txtFType2.ReadOnly = !State;
            txtRemark.ReadOnly = !State;
            txtGDate.ReadOnly = !State;
            txtHDate.ReadOnly = !State;
            ddlFrom.Enabled = State;
            ddlTo.Enabled = State;
            ddlDriver.Enabled = State;
            ddlCar.Enabled = State;
            ChkAll.Enabled = State;
            //grdAttach.Enabled = State;
            foreach (GridViewRow itm in grdAttach.Rows)
            {
                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                if (BtnDelete != null) BtnDelete.Visible = State;
            }
            FileUpload1.Enabled = State;
            BtnAttach.Enabled = State;
            ChkNoCost.Enabled = State;
            txtReason.ReadOnly = !State;
            ChkRent.Enabled = State;
            txtRentMobileNo.ReadOnly = !State;
            txtRentDriver.ReadOnly = !State;
            txtRentValue.ReadOnly = !State;
            txtRentPlateNo.ReadOnly = !State;
        }

        protected void LoadVouData()
        {
            try
            {
                grdCodes.DataSource = (List<myInv2>)VouData;
                grdCodes.DataBind();
                if (txtGDate.ReadOnly)
                {
                    if (grdCodes.Rows != null)
                    {
                        for (int i = 0; i < grdCodes.Rows.Count; i++)
                        {
                            grdCodes.Rows[i].Cells[0].Enabled = false;
                        }
                    }
                }
                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                LblCodesResult.Text = "عدد الشحنات " + VouData.Count.ToString();

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
                    CarMove myInv = new CarMove();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.Number = int.Parse(txtNumber.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();

                    if (myInv != null)
                    {
                        if (myInv.UserName == txtUserName.ToolTip)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "بيان الترحيل مكرر";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            BtnNew.Enabled = true;
                            return;
                        }
                        else
                        {
                            myInv = new CarMove();
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
                            txtNumber.Text = i.ToString();
                        }
                    }
                    myInv = new CarMove();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.Number = int.Parse(txtNumber.Text);
                    PutInv(myInv);

                    int r  = 0;
                    int FNo = 1;
                    bool Add = true;
                    foreach (GridViewRow gvr in grdCodes.Rows)
                    {
                        CheckBox ChkStatus = gvr.FindControl("ChkStatus") as CheckBox;
                        if (ChkStatus.Checked)
                        {
                            myInv.FNo = (short)FNo;
                            myInv.InvoiceNo = VouData[r].VouNo;
                            myInv.InvoiceFNo = VouData[r].InvoiceFNo;
                            myInv.CarMoveNo = VouData[r].CarMoveNo;
                            myInv.CarMoveLoc = VouData[r].CarMoveLoc;
                            myInv.InvoiceVouLoc = VouData[r].InvoiceVouLoc;
                            myInv.Flag = VouData[r].Flag;
                            myInv.FTime = LblFTime.Text;
                            if (txtFType2.ToolTip != "") myInv.FType2 = txtFType2.ToolTip;
                            else myInv.FType2 = "-1";
                            Add = myInv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString , (VouData[r].Destination == ddlTo.SelectedValue));
                            FNo++;
                        }
                        r++;
                    }

                    if (FNo == 1)
                    {
                        myInv.FNo = (short)FNo;
                        myInv.InvoiceNo = 0;
                        myInv.InvoiceFNo = 0;
                        myInv.CarMoveNo = 0;
                        myInv.CarMoveLoc = "";
                        myInv.InvoiceVouLoc = "";
                        myInv.FTime = LblFTime.Text;
                        myInv.Flag = "";
                        Add = myInv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, false);                    
                    }

                    if (Add)
                    {
                        double CostAmount = 0;
                        double KM = 0;
                        CarPrices myPrice = new CarPrices();
                        myPrice.Branch = short.Parse(Session["Branch"].ToString());
                        myPrice.MonthNo = 0;
                        myPrice.FromCode = this.ddlFrom.SelectedValue;
                        myPrice.toCode = this.ddlTo.SelectedValue;
                        myPrice.PLevel = "00002";
                        myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myPrice != null)
                        {
                            //CostAmount = (double)myPrice.CostAmount;
                            KM = (double)myPrice.KMeter;
                            CostAmount = Math.Round((double)(moh.doTripCost(txtGDate.Text) * KM), 0);                            
                        }


                        Drivers myDrive = new Drivers();
                        myDrive.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myDrive.Code = myInv.DriverCode;
                        myDrive = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                                   where sitm.Code == myDrive.Code
                                   select sitm).FirstOrDefault();
                        if (myDrive != null)
                        {
                            myInv.DriverCode = myDrive.Sponsor;
                            if ((bool)myDrive.Ajir)
                            {
                                CostAmount = Math.Round((double)(myDrive.Cost * KM),0);
                            }
                        }

                        CarMoveLines myCarMoveLine = new CarMoveLines();
                        myCarMoveLine.Branch = short.Parse(Session["Branch"].ToString());
                        myCarMoveLine.VouLoc = myInv.VouLoc;
                        myCarMoveLine.Number = myInv.Number;
                        myCarMoveLine = myCarMoveLine.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                        if (myCarMoveLine != null)
                        {
                            foreach (CarMoveLines itm in myCarMoveLine.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                if (itm.FromLoc == "-1" && itm.FNo != 1) CostAmount -= (double)itm.Cost;
                                else CostAmount += (double)itm.Cost;
                            }
                        }

                        if (CostAmount != 0)
                        {
                            /*
                            Drivers myDrive = new Drivers();
                            myDrive.Branch = short.Parse(Session["Branch"].ToString());
                            myDrive.Code = myInv.DriverCode;
                            myDrive = myDrive.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myDrive != null)
                            {
                                myInv.DriverCode = myDrive.Sponsor;
                                if ((bool)myDrive.Ajir)
                                {
                                    CostAmount = (double)(myDrive.Cost * KM);
                                }
                            }
                             */

                            myInv.Post(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString,CostAmount,SiteInfo.DezelAcc,SiteInfo.TripAcc,SiteInfo.CurExpAcc,SiteInfo.Project,SiteInfo.Area,"00002", (ChkRent.Checked ? moh.StrToDouble(txtRentValue.Text) : 0));
                        }
                        else if (ChkRent.Checked && moh.StrToDouble(txtRentValue.Text) > 0) myInv.Post(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, CostAmount, SiteInfo.DezelAcc, SiteInfo.TripAcc, SiteInfo.CurExpAcc, SiteInfo.Project, SiteInfo.Area, "00002", (ChkRent.Checked ? moh.StrToDouble(txtRentValue.Text) : 0));
                        RefreshCache();
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان ترحيل", "اضافة", "اضافة بيان الترحيل رقم " + lblBranch.Text + "/" + txtNumber.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);                        
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                        BtnNew.Enabled = true;
                        string vNumber = txtNumber.Text;
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
                    }
                }
            }
            catch (Exception ex)
            {
                BtnNew.Enabled = true;
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

        public bool ValidateInv()
        {
            if (ChkRent.Checked)
            {
                if (moh.StrToDouble(txtRentValue.Text) == 0)
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب أدخال قيمة الايجار";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    return false;
                }

                if (txtRentPlateNo.Text == "")
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب أدخال رقم اللوحة للشاحنة المستأجرة";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    return false;
                }

                if (txtRentDriver.Text == "")
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب أدخال السائق";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    return false;
                }

            }

            int Count = 0;
            foreach (GridViewRow gvr in grdCodes.Rows)
            {
                CheckBox ChkStatus = gvr.FindControl("ChkStatus") as CheckBox;
                HyperLink lblVouNo = gvr.FindControl("lblVouNo") as HyperLink;
                if (ChkStatus.Checked)
                {
                    if(lblVouNo.Text[0] != 'L' && lblVouNo.Text[0] != 'E') Count++;
                }
            }

            //if (Count == 0)
            //{
            //    LblCodesResult.ForeColor = System.Drawing.Color.Red;
            //    LblCodesResult.Text = "يجب أختيار 8 الى 10 سيارات للشحن";
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
            //    return false;
            //}

            if (Count > 20)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "لقد تجاوزت حمولة الشحن القصوى 20 سيارات";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }
            return true;
        }

        public void PutInv(CarMove myInv)
        {
            myInv.DriverCode = ddlDriver.SelectedValue;
            myInv.CarCode = ddlCar.SelectedValue;
            myInv.FromLoc = ddlFrom.SelectedValue;
            myInv.ToLoc = ddlTo.SelectedValue;
            myInv.HDate = txtHDate.Text;
            myInv.GDate = txtGDate.Text;
            myInv.UserName = txtUserName.ToolTip;
            myInv.UserDate = txtUserDate.Text;
            myInv.FTime = LblFTime.Text;
            myInv.Remark = txtRemark.Text;
            myInv.NoCost = ChkNoCost.Checked;
            myInv.Rent = ChkRent.Checked;
            myInv.RentMobileNo = txtRentMobileNo.Text;
            myInv.RentDriver = txtRentDriver.Text;
            myInv.RentValue = moh.StrToDouble(txtRentValue.Text);
            myInv.RentPlateNo = txtRentPlateNo.Text;
        }

        public void GetInv(CarMove myInv)
        {
            if (ddlDriver.Items.FindByValue(myInv.DriverCode) != null) ddlDriver.SelectedValue = myInv.DriverCode;
            else
            {
                Drivers myDrive = new Drivers();
                myDrive.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myDrive.Code = myInv.DriverCode;
                myDrive = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                           where sitm.Code == myDrive.Code
                           select sitm).FirstOrDefault();
                if (myDrive != null)
                {
                    ddlDriver.Items.Add(new ListItem(myDrive.Name1, myDrive.Code));
                    ddlDriver.SelectedValue = myInv.DriverCode;
                }
            }
            if (ddlCar.Items.FindByValue(myInv.CarCode) != null) ddlCar.SelectedValue = myInv.CarCode;
            else
            {
                Cars myCar = new Cars();
                myCar.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myCar.Code = myInv.CarCode;
                myCar.CarsType = int.Parse(myInv.CarCode.Substring(0, 2));
                myCar = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                         where sitm.Code == myCar.Code
                         select sitm).FirstOrDefault();
                if (myCar != null)
                {
                    ddlCar.Items.Add(new ListItem(myCar.PlateNo, myCar.Code));
                    ddlCar.SelectedValue = myInv.CarCode;
                }
            }
            ddlFrom.SelectedValue = myInv.FromLoc;
            ddlTo.SelectedValue = myInv.ToLoc;
            txtHDate.Text = myInv.HDate;
            txtGDate.Text = myInv.GDate;
            LblFTime.Text = myInv.FTime;
            txtCarNo.Text = myInv.CarCode;
            txtRemark.Text = myInv.Remark;
            ChkNoCost.Checked = (bool)myInv.NoCost;
            if (myInv.FType2 == "-1") txtFType2.ToolTip = "";
            else
            {
                txtFType2.ToolTip = myInv.FType2;
                Codes myCode = new Codes();
                myCode.Branch = short.Parse(Session["Branch"].ToString());
                myCode.Ftype = 30;
                myCode.Code = int.Parse(myInv.FType2);
                if (Cache["LastCodes" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCodes" + Session["CNN2"].ToString(), myCode.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myCode = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                          where itm.Ftype == myCode.Ftype && itm.Code == myCode.Code
                          select itm).FirstOrDefault();
                if (myCode != null)
                {
                    txtCap.Text = myCode.FType2;
                    txtFType2.Text = myCode.Name1;
                }
                else
                {
                    txtCap.Text = "";
                    txtFType2.Text = "";
                    txtFType2.ToolTip = "";
                }
            }
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

            ChkRent.Checked = (bool)myInv.Rent;
            txtRentMobileNo.Text = myInv.RentMobileNo;
            txtRentDriver.Text = myInv.RentDriver;
            txtRentValue.Text = myInv.RentValue.ToString();
            txtRentPlateNo.Text = myInv.RentPlateNo;
        }

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (!ValidateInv()) return;

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

                    CarMove myInv = new CarMove();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.Number = int.Parse(txtNumber.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم بيان الحركة غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    else
                    {
                        PutInv(myInv);
                        if (myInv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            myInv = new CarMove();
                            myInv.Branch = short.Parse(Session["Branch"].ToString());
                            myInv.VouLoc = AreaNo;
                            myInv.Number = int.Parse(txtNumber.Text);
                            PutInv(myInv);

                            int r = 0;
                            int FNo = 1;
                            bool Add = true;
                            foreach (GridViewRow gvr in grdCodes.Rows)
                            {
                                CheckBox ChkStatus = gvr.FindControl("ChkStatus") as CheckBox;
                                if (ChkStatus.Checked)
                                {
                                    myInv.FNo = (short)FNo;
                                    myInv.InvoiceNo = VouData[r].VouNo;
                                    myInv.InvoiceFNo = VouData[r].InvoiceFNo;
                                    myInv.CarMoveNo = VouData[r].CarMoveNo;
                                    myInv.CarMoveLoc = VouData[r].CarMoveLoc;
                                    myInv.InvoiceVouLoc = VouData[r].InvoiceVouLoc;
                                    myInv.FTime = LblFTime.Text;
                                    myInv.Flag = VouData[r].Flag;
                                    //myInv.FTime = VouData[r].FTime;
                                    if (txtFType2.ToolTip != "") myInv.FType2 = txtFType2.ToolTip;
                                    else myInv.FType2 = "-1";
                                    Add = myInv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, (VouData[r].Destination == ddlTo.SelectedValue));
                                    FNo++;
                                }
                                r++;
                            }

                            if (FNo == 1)
                            {
                                myInv.FNo = (short)FNo;
                                myInv.InvoiceNo = 0;
                                myInv.InvoiceFNo = 0;
                                myInv.CarMoveNo = 0;
                                myInv.CarMoveLoc = "";
                                myInv.InvoiceVouLoc = "";
                                myInv.FTime = LblFTime.Text;
                                Add = myInv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, false);
                            }

                            if (Add)
                            {
                                double CostAmount = 0;
                                double KM = 0;
                                CarPrices myPrice = new CarPrices();
                                myPrice.Branch = short.Parse(Session["Branch"].ToString());
                                myPrice.MonthNo = 0;
                                myPrice.FromCode = this.ddlFrom.SelectedValue;
                                myPrice.toCode = this.ddlTo.SelectedValue;
                                myPrice.PLevel = "00002";
                                myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (myPrice != null)
                                {
                                    KM = (double)myPrice.KMeter;
                                    //CostAmount = (double)myPrice.CostAmount;
                                    CostAmount = Math.Round((double)(moh.doTripCost(txtGDate.Text) * KM),0);                                    
                                }


                                Drivers myDrive = new Drivers();
                                myDrive.Branch = short.Parse(Session["Branch"].ToString());
                                if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                myDrive.Code = myInv.DriverCode;
                                myDrive = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                                           where sitm.Code == myDrive.Code
                                           select sitm).FirstOrDefault();
                                if (myDrive != null)
                                {
                                    myInv.DriverCode = myDrive.Sponsor;
                                    if ((bool)myDrive.Ajir)
                                    {
                                        CostAmount = Math.Round((double)(myDrive.Cost * KM),0);
                                    }
                                }

                                CarMoveLines myCarMoveLine = new CarMoveLines();
                                myCarMoveLine.Branch = short.Parse(Session["Branch"].ToString());
                                myCarMoveLine.VouLoc = myInv.VouLoc;
                                myCarMoveLine.Number = myInv.Number;
                                myCarMoveLine = myCarMoveLine.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                                if (myCarMoveLine != null)
                                {
                                    foreach (CarMoveLines itm in myCarMoveLine.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        if (itm.FromLoc == "-1" && itm.FNo != 1) CostAmount -= (double)itm.Cost;
                                        else CostAmount += (double)itm.Cost;
                                    }
                                }

                                if (CostAmount != 0)
                                {
                                    /*
                                    Drivers myDrive = new Drivers();
                                    myDrive.Branch = short.Parse(Session["Branch"].ToString());
                                    myDrive.Code = myInv.DriverCode;
                                    myDrive = myDrive.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (myDrive != null)
                                    {
                                        myInv.DriverCode = myDrive.Sponsor;
                                        if ((bool)myDrive.Ajir)
                                        {
                                            CostAmount = (double)(myDrive.Cost * KM);
                                        }
                                    }
                                     */
                                    myInv.Post(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, CostAmount, SiteInfo.DezelAcc, SiteInfo.TripAcc, SiteInfo.CurExpAcc, SiteInfo.Project, SiteInfo.Area, "00002",(ChkRent.Checked ? moh.StrToDouble(txtRentValue.Text) : 0));
                                }
                                if(ChkRent.Checked && moh.StrToDouble(txtRentValue.Text)>0) myInv.Post(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, CostAmount, SiteInfo.DezelAcc, SiteInfo.TripAcc, SiteInfo.CurExpAcc, SiteInfo.Project, SiteInfo.Area, "00002", (ChkRent.Checked ? moh.StrToDouble(txtRentValue.Text) : 0));
                                RefreshCache();
                                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان ترحيل", "تعديل", "تعديل بيان الترحيل رقم " + lblBranch.Text + "/" + txtNumber.Text, txtReason.Text, IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                txtReason.Text = "";                                
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                                string vNumber = txtNumber.Text;
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
                        if (DateTime.Parse(txtGDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                    }

                    CarMove myInv = new CarMove();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.Number = int.Parse(txtNumber.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم بيان الحركة غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    else
                    {
                        // Check if CarMoveRCV Exists
                        CarMoveRCV vCMR = new CarMoveRCV();
                        vCMR.Branch = short.Parse(Session["Branch"].ToString());
                        vCMR.CarMove = int.Parse(AreaNo).ToString()+"/"+txtNumber.Text;
                        vCMR = vCMR.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (vCMR != null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لا يمكن الغاء بيان الترحيل لانه مرتبط ببيان الوصول رقم " + vCMR.LocNumber.ToString() + "/" + vCMR.Number.ToString();
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }

                        if (myInv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            CarMoveLines mylines = new CarMoveLines();
                            mylines.Branch = short.Parse(Session["Branch"].ToString());
                            mylines.VouLoc = AreaNo;
                            mylines.Number = int.Parse(txtNumber.Text);
                            mylines.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            RefreshCache();
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان ترحيل", "الغاء", "الغاء بيان الترحيل رقم " + lblBranch.Text + "/" + txtNumber.Text, txtReason.Text, IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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

                    CarMove myInv = new CarMove();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.Number = int.Parse(txtSearch.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم بيان الحركة غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    else
                    {
                        txtNumber.Text = txtSearch.Text;
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان ترحيل", "عرض", "عرض بيان الترحيل رقم " + lblBranch.Text + "/" + txtNumber.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        EditMode();
                        GetInv(myInv);
                        if (ChkRent.Checked) ChkRent_CheckedChanged(sender, e);
                        VouData = myInv.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        LoadVouData();
                        LoadAttachData();

                        // Check if CarMoveRCV Exists
                        CarMoveRCV vCMR = new CarMoveRCV();
                        vCMR.Branch = short.Parse(Session["Branch"].ToString());
                        vCMR.CarMove = int.Parse(AreaNo).ToString()+"/"+txtNumber.Text;
                        vCMR = vCMR.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (vCMR != null) 
                        {
                            if (Request.QueryString["Support"] != null || !(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass216)
                            {
                                BtnEdit.Visible = false;
                                BtnDelete.Visible = false;
                            }
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = Request.QueryString["Support"] != null  ?  "لا يمكن الغاء او تعديل بيان الترحيل لانه مرتبط ببيان الوصول رقم " + @"<a href='WebCarMoveRCV.aspx?Support=1&Flag=0&AreaNo=" + moh.MakeMask(vCMR.LocNumber.ToString(), 5) + @"&FNum=" + vCMR.Number.ToString() + @"' target='_blank'>" + vCMR.LocNumber.ToString() + '/' + vCMR.Number.ToString() + @"</a>"
                                                                                          : "لا يمكن الغاء او تعديل بيان الترحيل لانه مرتبط ببيان الوصول رقم " + @"<a href='WebCarMoveRCV.aspx?Flag=0&AreaNo=" + moh.MakeMask(vCMR.LocNumber.ToString(), 5) + @"&FNum=" + vCMR.Number.ToString() + @"' target='_blank'>" + vCMR.LocNumber.ToString() + '/' + vCMR.Number.ToString() + @"</a>";
                        }

                        // Check Payment
                        Jv vJv = new Jv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 102;
                        vJv.LocType = 2;
                        vJv.LocNumber = short.Parse(AreaNo);
                        vJv.InvNo = int.Parse(AreaNo).ToString() + "/" + txtNumber.Text;
                        vJv.DocType = 2;
                        vJv = vJv.findInvNo30(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (vJv != null)
                        {
                            LblCodesResult.Text += @"<br/>" + "تم أدراج المستند في سند الصرف رقم " + @"<a href='WebPay1.aspx?FType=2&Flag=0&AreaNo=" + moh.MakeMask(vJv.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + vJv.Number.ToString() + @"' target='_blank'>" + vJv.LocNumber.ToString() + @"/" + vJv.Number.ToString() + @"</a>" + " ";
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
            BtnSearch_Click(sender, e);
        }

        public void PrintMe(String Number)
        {
            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان ترحيل", "طباعة", "طباعة بيان الترحيل رقم " + int.Parse(AreaNo).ToString() + "/" +  Number, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=1&AreaNo=" + AreaNo + "&Number=" + Number + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
                    return;    
        }

        protected void BtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    // if (!ValidateInv()) return;
                    PrintMe(txtNumber.Text);
                    return;

                    /*
                    string Number = txtNumber.Text;
                    string Branch = lblBranch.Text;
                    string From2 = ddlFrom.SelectedItem.Text;
                    string To2 = ddlTo.SelectedItem.Text;
                    string Car = ddlCar.SelectedValue;
                    string Hdate = HDate.RotateDate2(txtHDate.Text) + " هـ ";
                    string GDate = txtGDate.Text + " م " + LblFTime.Text;
                    string Driver = ddlDriver.SelectedItem.Text;
                    string DriverCode = ddlDriver.SelectedValue;
                    List<myInv2> lstCar = new List<myInv2>();
                    int i = 0;
                    if (grdCodes.Rows.Count > 0)
                    {
                        foreach (GridViewRow gvr in grdCodes.Rows)
                        {
                            CheckBox ChkStatus = gvr.FindControl("ChkStatus") as CheckBox;
                            if (ChkStatus.Checked)
                            {
                                lstCar.Add(new myInv2
                                {
                                    Name = VouData[i].Name,
                                    VouNo = VouData[i].VouNo,
                                    InvoiceVouLoc = VouData[i].InvoiceVouLoc,
                                    CarType = VouData[i].CarType,
                                    PlateNo = VouData[i].PlateNo,
                                    ChassisNo = VouData[i].ChassisNo,
                                    Model = VouData[i].Model,
                                    Color = VouData[i].Color,
                                    RecName = VouData[i].RecName,
                                    DestinationName1 = VouData[i].DestinationName1
                                });
                            }
                            i++;
                        }
                    }

                    CarMove myInv = new CarMove();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.Number = int.Parse(txtNumber.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myInv == null) BtnNew_Click(sender, e);
                    //else BtnEdit_Click(sender, e);

                    iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), -50, -50, 80, 50);
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
                    page.PageNo = "1";
                    page.UserName = Session["FullUser"].ToString();

                    page.vStr4 = ((Label)this.Master.FindControl("LblBranchName")).Text;    //Session["AreaName"].ToString();
                    //-------------------------------------------------------------------------------------------                    
                    document.Open();
                    //-------------------------------------------------------------------------------------------                    

                    //string arialunicodepath = Server.MapPath("Fonts") + @"\arial.ttf";
                    string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";                    
                    BaseFont nationalBase;
                    nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 11f, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font nationalTextFont2 = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font nationalTextFont14 = new iTextSharp.text.Font(nationalBase, 14f, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font nationalTextFont16 = new iTextSharp.text.Font(nationalBase, 16f, iTextSharp.text.Font.NORMAL);
                    //-------------------------------------------------------------------------------------------                    
                    //document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    //-------------------------------------------------------------------------------------------                    
                    var cols = new[] { 200,200, 150,250,400};
                    document.Open();
                    PdfPTable table = new PdfPTable(5);
                    table.TotalWidth = document.PageSize.Width; //100f;
                    table.SetWidths(cols);
                    PdfPCell cell2 = new PdfPCell();
                    cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    PdfPCell cell22 = new PdfPCell();
                    cell22.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell22.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell22.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;


                    cell2.Border = 0;
                    Cars myCar = new Cars();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                    myCar.Code = Car;
                    myCar = myCar.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    cell2.Phrase = new iTextSharp.text.Phrase(" " , nationalTextFont);
                    table.AddCell(cell2);

                    cell2.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell2.Phrase = new iTextSharp.text.Phrase(" بيان ترحيل سيارات رقم ", nationalTextFont16);
                    table.AddCell(cell2);

                    cell22.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell22.Phrase = new iTextSharp.text.Phrase(Number + Branch, nationalTextFont16);
                    table.AddCell(cell22);

                    cell2.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell2);


                    var TextCell = new PdfPCell(table.DefaultCell);
                    TextCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    TextCell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    //TextCell.Border = 0;
                    TextCell.BorderColor = iTextSharp.text.BaseColor.WHITE;
                    PdfContentByte cb = writer.DirectContent;
                    var bc128 = new Barcode128();
                    bc128.CodeType = Barcode.CODE128;
                    bc128.Code = Branch + Number;
                    bc128.GenerateChecksum = true;
                    bc128.AltText = "" ;
                    bc128.StartStopText = true;
                    

                    //bc128.BarHeight = 8;
                    //bc128.Extended = true; 

                    //bc128.Baseline = 20;   // Doesn't affect rendering.
                    //bc128.Size = 20;       // Doesn't affect rendering.
                    //bc128.BarHeight = 60;  // DOES affect rendering.
                    //bc128.X = 2;                          

                    TextCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    //cell.AddElement(bc128.CreateImageWithBarcode(cb, null, null));                    
                    var bi = bc128.CreateImageWithBarcode(cb, null, null);
                    bi.ScalePercent(100);
                    bi.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    TextCell.AddElement(bi);

                    //cell.Image = bc128.CreateImageWithBarcode(cb, null, null);                    
                    //table.AddCell(cell);
                    table.AddCell(TextCell);
                    document.Add(table);
                    //-------------------------------------------------------------------------------------------
                      document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    //-------------------------------------------------------------------------------------------
                    cols = new[] { 400, 120, 210, 120, 170, 120};
                    table = new PdfPTable(6);
                    table.TotalWidth = document.PageSize.Width; //100f;
                    table.SetWidths(cols);
                    PdfPCell cell = new PdfPCell();
                    cell.FixedHeight = 20f;

                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    //cell.Border = 0;
                    cell.Phrase = new iTextSharp.text.Phrase("من", nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(From2, nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("إلى", nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(To2, nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("الشاحنة", nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(myCar.CarType + " " + myCar.PlateNo + " نقل السعودية ", nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("التاريخ", nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(Hdate, nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("الموافق", nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(GDate, nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("السائق", nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(Driver, nationalTextFont2);
                    table.AddCell(cell);
                    document.Add(table);
                    //-------------------------------------------------------------------------------------------
                   // document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    //-------------------------------------------------------------------------------------------
                    int ColCount = 9;
                    cols = new[] { 200,175,250,150,150,150,120,250,50};                    
                    table = new PdfPTable(ColCount);
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

                    cell.Phrase = new iTextSharp.text.Phrase("مرسل السيارة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("رقم الفاتورة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("نوع السيارة", nationalTextFont);
                    table.AddCell(cell);

                    //cell.Phrase = new iTextSharp.text.Phrase("رقم اللوحة أو الهيكل", nationalTextFont);
                    cell.Phrase = new iTextSharp.text.Phrase("رقم اللوحة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الموديل و اللون", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("أسم مستلم السيارة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("جهة الترحيل", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("ملاحظات", nationalTextFont);
                    table.AddCell(cell);

                    //-------------------------------------------------------------------------------------------
                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    int FNo = 1;
                    bool vClient = true;
                    string vClientName = "-1";
                    if (lstCar.Count>0)
                    {
                        foreach (myInv2 inv in lstCar)
                        {

                                cell.Phrase = new iTextSharp.text.Phrase(FNo.ToString(), nationalTextFont);
                                table.AddCell(cell);
                                if (vClientName == "-1") vClientName = inv.Name;
                                else if (vClientName != inv.Name) vClient = false;
                                cell.Phrase = new iTextSharp.text.Phrase(inv.Name, nationalTextFont);
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(inv.VouNo.ToString() + '/' + int.Parse(inv.InvoiceVouLoc).ToString(), nationalTextFont);
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(inv.CarType, nationalTextFont);
                                table.AddCell(cell);

                                if (inv.PlateNo != "") cell.Phrase = new iTextSharp.text.Phrase(inv.PlateNo, nationalTextFont);
                                else cell.Phrase = new iTextSharp.text.Phrase(inv.ChassisNo, nationalTextFont);
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(inv.Model + " " + inv.Color, nationalTextFont);
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(inv.RecName, nationalTextFont);
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(inv.DestinationName1, nationalTextFont);
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase("    ", nationalTextFont);
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
                    table.AddCell(cell);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    document.Add(table);
                    //document.Add(Environment.NewLine);
                    //document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    //-------------------------------------------------------------------------------------------
                    string vs = "\nأقر أنا السائق / " + ddlDriver.SelectedItem.Text + " هوية رقم ";
                    Drivers myDrive = new Drivers();
                    myDrive.Branch = short.Parse(Session["Branch"].ToString());
                    myDrive.Code = DriverCode;
                    myDrive = myDrive.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    vs += myDrive.IqamaNo + " على كفالة " + myDrive.Sponsor + "أنني أستلمت السيارات الموضحة أعلاه.";
                    if (vClient) vs += "وعددها " + (FNo - 1).ToString() + " سليمة و مسئول عنها و عن محتوياتها حتى يتم تسليمها إلى العميل/ " + vClientName + " وعلى ذلك أوقع. ";
                    else vs += "وعددها " + (FNo - 1).ToString() + " سليمة و مسئول عنها و عن محتوياتها حتى يتم تسليمها إلى /  " + To2 + " وعلى ذلك أوقع. ";
                    table = new PdfPTable(3);
                    table.TotalWidth = document.PageSize.Width; //100f;
                    cols = new[] { 500,300,500 };
                    table.SetWidths(cols);
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell = new PdfPCell();
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Phrase = new iTextSharp.text.Phrase(vs , nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont2);
                    table.AddCell(cell);

                    if(vClient) vs = "\nأقر أنا المستلم/"+vClientName+" بأنني أستلمت السيارات الموضحة بعالية كماهي مثبتة بالفواتير أو بالملاحظات المثبتة بأعلاه ";
                    else vs = "\nأقر أنا المستلم (موظف الفرع) /                                 بأنني أستلمت السيارات الموضحة بعالية كماهي مثبتة بالفواتير أو بالملاحظات المثبتة بأعلاه ";
                    cell.Phrase = new iTextSharp.text.Phrase(vs, nationalTextFont2);
                    table.AddCell(cell);

                    document.Add(table);
                  //  document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    //-------------------------------------------------------------------------------------------
                    table = new PdfPTable(7);
                    table.TotalWidth = document.PageSize.Width; //100f;
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cols = new[] { 125, 300, 75, 300, 100, 300, 100};
                    table.SetWidths(cols);

                    cell = new PdfPCell();
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("السائق :", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("المرسل : (موظف الفرع)", nationalTextFont2);                   
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    if(vClient) cell.Phrase = new iTextSharp.text.Phrase("المرسل إليه : (العميل)", nationalTextFont2);
                    else cell.Phrase = new iTextSharp.text.Phrase("المرسل إليه : (موظف الفرع)", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    //-------------------------------------------------------------------------------------------

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الاســم : " + Driver, nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الاســم : " + txtUserName.Text, nationalTextFont2);                    
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    if(vClient) cell.Phrase = new iTextSharp.text.Phrase("الاســم : "+vClientName , nationalTextFont2);
                    else cell.Phrase = new iTextSharp.text.Phrase("الاســم : ", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    //-------------------------------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("التوقيع : ", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("التوقيع : ", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("التوقيع : ", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);
                    document.Add(table);
                    //-------------------------------------------------------------------------------------------
                    //document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    //-------------------------------------------------------------------------------------------
                    //-------------------------------------------------------------------------------------------
                    document.Close();
                     */
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
                     //string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\arial.ttf";
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
                 //string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\DTNASKH1.TTF";
                 //string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\arial.ttf";
                 BaseFont nationalBase;
                 nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                 iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 18f, iTextSharp.text.Font.NORMAL);


                 //I use a PdfPtable with 1 column to position my header where I want it
                 PdfPTable headerTbl = new PdfPTable(3);
                 var cols2 = new[] { 300, 600, 300 };
                 headerTbl.TotalWidth = doc.PageSize.Width;
                 headerTbl.SetWidths(cols2);
                 headerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                 headerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                 //set the width of the table to be the same as the document
                

                 PdfPCell cell2 = new PdfPCell();
                 cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                 cell2.Border = 0;
                 cell2.PaddingRight = 15;
                 cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                 cell2.Phrase = new iTextSharp.text.Phrase(vCompanyName + "\n" + vStr4, nationalTextFont);
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

        protected void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlFrom.SelectedValue == "00073" || ddlFrom.SelectedValue == "00074")
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "لقد تم ايقاف خدمة الترحيل للورشة يمكنك استخدام طلب الاصلاح";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    ddlFrom.SelectedIndex = 0;
                    return;
                }
                if (ddlTo.SelectedValue == "00073" || ddlTo.SelectedValue == "00074")
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "لقد تم ايقاف خدمة الترحيل للورشة يمكنك استخدام طلب الاصلاح";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    ddlTo.SelectedIndex = 0;
                    return;
                }

                ChkInvType_SelectedIndexChanged(sender, e);
                /*
                List<myInv2> SelectedVou = new List<myInv2>();
                if (grdCodes.Rows != null && grdCodes.Rows.Count > 0)
                {
                    int r = 0;
                    foreach (GridViewRow gvr in grdCodes.Rows)
                    {
                        CheckBox ChkStatus = gvr.FindControl("ChkStatus") as CheckBox;
                        if (ChkStatus.Checked)
                        {
                            SelectedVou.Add(new myInv2
                            {
                                VouNo = VouData[r].VouNo,
                                InvoiceFNo = VouData[r].InvoiceFNo,
                                CarMoveNo = VouData[r].CarMoveNo,
                                CarMoveLoc = VouData[r].CarMoveLoc,
                                InvoiceVouLoc = VouData[r].InvoiceVouLoc
                            });
                        }
                        r++;
                    }
                }

                VouData.Clear();
                if (txtSearch.Text == txtNumber.Text)
                {
                    CarMove myInv = new CarMove();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.Number = int.Parse(txtSearch.Text);
                    VouData = myInv.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }

                Invoice inv = new Invoice();
                inv.Branch = short.Parse(Session["Branch"].ToString());
                inv.VouLoc = AreaNo;
                if (ChkAll.Checked)
                {
                    if (txtNumber.ReadOnly)
                    {
                        List<myInv2> myList = new List<myInv2>();
                        myList = inv.GetInvMove(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myList != null) VouData.AddRange(myList);
                    }
                    else VouData.AddRange(inv.GetInvMove(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                }
                else if (ddlTo.SelectedIndex > 0)
                {
                    inv.Destination = ddlTo.SelectedValue;
                    VouData.AddRange(inv.GetInvMove2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                }

                List<myInv2> myList2 = new List<myInv2>();
                CarMove myCarMove = new CarMove();
                myCarMove.Branch = short.Parse(Session["Branch"].ToString());
                myCarMove.VouLoc = AreaNo;
                myCarMove.ToLoc = ddlTo.SelectedValue;
                myList2 = myCarMove.Gettr(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, ChkAll.Checked, SiteInfo.City,AreaNo);

                if(myList2 != null) VouData.AddRange(myList2);

                if (SelectedVou != null && SelectedVou.Count > 0)
                {
                    foreach (myInv2 itm in SelectedVou)
                    {
                        foreach (myInv2 sitm in VouData)
                        {
                            if (itm.VouNo == sitm.VouNo && itm.InvoiceVouLoc == sitm.InvoiceVouLoc && itm.InvoiceFNo == sitm.InvoiceFNo)
                            {
                                sitm.Status = true;
                                break;
                            }
                        }
                    }

                    VouData = VouData.OrderByDescending(x => x.Status).ToList();
                }

                if(sender!= null) LoadVouData();
                 */
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


        public bool CheckCarJobWork(string CarNo)
        {
            JobWork jw = new JobWork();
            jw.CarNo = CarNo;
            jw = jw.GetOpenCarNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (jw != null)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يوجد للشاحنة امر تشغيل مفتوح حاليا في الصيانة برقم " + jw.VouNo.ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return true;
            }
            else return false;            
        }

        protected void ddlCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(ddlCar.SelectedIndex>0)
                {
                    Cars myCar = new Cars();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myCar.Code = ddlCar.SelectedValue;
                    myCar.CarsType = int.Parse(ddlCar.SelectedValue.Substring(0, 2));
                    myCar = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                             where sitm.Code == myCar.Code
                             select sitm).FirstOrDefault();
                    if (myCar != null)
                    {
                        if (!CheckCarJobWork(myCar.Code))
                        {
                            if (CheckCarRCV(myCar.Code))
                            {

                                txtCarNo.Text = myCar.Code;
                                try
                                {
                                    DateTime dt = HDate.Ch_Date(HDate.getNow());
                                    List<Cars> lcar = new List<Cars>();
                                    lcar.Add(new Cars
                                    {
                                        WorkShopCode = "1",
                                        Code = myCar.Code,
                                        PlateNo = myCar.PlateNo,
                                        PHDate1 = moh.GetPic(1, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString),
                                        PHDate2 = moh.GetPic(2, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString),
                                        PHDate3 = moh.GetPic(3, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString),
                                        PHDate4 = moh.GetPic(4, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString),
                                        PLoc1 = myCar.PLoc1,
                                        PLoc2 = myCar.PLoc2,
                                        PLoc3 = myCar.PLoc3,
                                        PLoc4 = myCar.PLoc4,
                                        strDate1 = (string.IsNullOrEmpty(myCar.PHDate1) ? "المستند غير مدرج" :
                                                    HDate.Ch_Date(myCar.PHDate1) <= dt ? @"<a href='" + moh.GetPic(1, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + "منتهي من " + dt.Subtract(HDate.Ch_Date(myCar.PHDate1)).Days.ToString() + " يوم" + @"</a>" :
                                                    HDate.Ch_Date(myCar.PHDate1).AddDays(-30) <= dt ? "ينتهي خلال " + HDate.Ch_Date(myCar.PHDate1).Subtract(dt).Days.ToString() + " يوم" + @"</a>" : @"<a href='" + moh.GetPic(1, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>"),
                                        strDate2 = (string.IsNullOrEmpty(myCar.PHDate2) ? "المستند غير مدرج" :
                                                    HDate.Ch_Date(myCar.PHDate2) <= dt ? @"<a href='" + moh.GetPic(2, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + "منتهي من " + dt.Subtract(HDate.Ch_Date(myCar.PHDate2)).Days.ToString() + " يوم" + @"</a>" :
                                                    HDate.Ch_Date(myCar.PHDate2).AddDays(-30) <= dt ? "ينتهي خلال " + HDate.Ch_Date(myCar.PHDate2).Subtract(dt).Days.ToString() + " يوم" + @"</a>" : @"<a href='" + moh.GetPic(2, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>"),
                                        strDate3 = (string.IsNullOrEmpty(myCar.PHDate3) ? "المستند غير مدرج" :
                                                    HDate.Ch_Date(myCar.PHDate3) <= dt ? @"<a href='" + moh.GetPic(3, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + "منتهي من " + dt.Subtract(HDate.Ch_Date(myCar.PHDate3)).Days.ToString() + " يوم" + @"</a>" :
                                                    HDate.Ch_Date(myCar.PHDate3).AddDays(-30) <= dt ? "ينتهي خلال " + HDate.Ch_Date(myCar.PHDate3).Subtract(dt).Days.ToString() + " يوم" + @"</a>" : @"<a href='" + moh.GetPic(3, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>"),
                                        strDate4 = (string.IsNullOrEmpty(myCar.PHDate4) ? "المستند غير مدرج" :
                                                    HDate.Ch_Date(myCar.PHDate4) <= dt ? @"<a href='" + moh.GetPic(4, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + "منتهي من " + dt.Subtract(HDate.Ch_Date(myCar.PHDate4)).Days.ToString() + " يوم" + @"</a>" :
                                                    HDate.Ch_Date(myCar.PHDate4).AddDays(-30) <= dt ? "ينتهي خلال " + HDate.Ch_Date(myCar.PHDate4).Subtract(dt).Days.ToString() + " يوم" + @"</a>" : @"<a href='" + moh.GetPic(4, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>")
                                    });
                                    grdCarAlert.DataSource = lcar;
                                    grdCarAlert.DataBind();
                                    CarAlert.Visible = true;
                                }
                                catch { }



                                if (myCar.DriverCode != "-1")
                                {
                                    bool vFound = false;
                                    for (int i0 = 0; i0 < ddlDriver.Items.Count; i0++)
                                    {
                                        if (myCar.DriverCode == ddlDriver.Items[i0].Value)
                                        {
                                            vFound = true;
                                            break;
                                        }
                                    }
                                    if (!vFound)
                                    {
                                        ddlDriver.Items.Add(new ListItem((from itm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                                                                          where (bool)itm.Status && itm.Code == myCar.DriverCode
                                                                          select itm.Name1).FirstOrDefault(), myCar.DriverCode));
                                    }

                                        ddlDriver.SelectedValue = myCar.DriverCode;
                                }
                                if (myCar.FType2 != "-1")
                                {
                                    Codes myCode = new Codes();
                                    myCode.Branch = short.Parse(Session["Branch"].ToString());
                                    myCode.Ftype = 30;
                                    myCode.Code = int.Parse(myCar.FType2);
                                    if (Cache["LastCodes" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCodes" + Session["CNN2"].ToString(), myCode.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                    myCode = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                              where itm.Ftype == myCode.Ftype && itm.Code == myCode.Code
                                              select itm).FirstOrDefault();
                                    if (myCode != null)
                                    {
                                        txtCap.Text = myCode.FType2;
                                        txtFType2.Text = myCode.Name1;
                                        txtFType2.ToolTip = myCar.FType2;
                                    }
                                    else
                                    {
                                        txtCap.Text = "";
                                        txtFType2.Text = "";
                                        txtFType2.ToolTip = "";
                                    }
                                }
                            }
                            else
                            {
                                txtCarNo.Text = "";
                                ddlCar.SelectedIndex = 0;
                                ddlDriver.SelectedIndex = 0;
                                txtSearch2.Text = "";
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "الشاحنة رقم " + myCar.Code + " لوحة رقم " + myCar.PlateNo + " لم يتم عمل بيان وصول لها ";
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
                    Response.Redirect("GeneralServerError.aspx", false);
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }

        protected string UrlHelper(object Number, object LocNumber, object Flag)
        {
            return Flag.ToString() == "" ? "~/WebInvoice.aspx?Flag=0&FNum=" + Number.ToString() + "&AreaNo=" + moh.MakeMask(LocNumber.ToString(), 5) + "&StoreNo=00001" :
                Flag.ToString() == "L" ? "~/WebLShipment.aspx?Flag=0&FNum=" + Number.ToString() + "&AreaNo=" + moh.MakeMask(LocNumber.ToString(), 5) + "&StoreNo=00001" :
                                        "~/WebShipment.aspx?Flag=0&FNum=" + Number.ToString() + "&AreaNo=" + moh.MakeMask(LocNumber.ToString(), 5) + "&StoreNo=00001";
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
                        myArch.Number = int.Parse(txtNumber.Text);
                        myArch.DocType = 504;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(AreaNo);
                        myArch.Number = int.Parse(txtNumber.Text);
                        myArch.DocType = 504;
                        myArch.FileName = FileUpload1.FileName;
                        myArch.FileName2 = mySetting.ImagePath2 + FileName;
                        myArch.FNo = (short)i;
                        myArch.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان ترحيل", "اضافة مرفقات", "اضافة مرفقات لبيان الترحيل رقم " + lblBranch.Text + "/" + txtNumber.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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
                myArch.Number = int.Parse(txtNumber.Text);
                myArch.DocType = 504;
                myArch.FNo = short.Parse(FNo);
                myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان ترحيل", "الغاء مرفقات", "الغاء مرفقات لبيان الترحيل رقم " + lblBranch.Text + "/" + txtNumber.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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
            Arch myArch = new Arch();
            myArch.Branch = short.Parse(Session["Branch"].ToString());
            myArch.LocNumber = short.Parse(AreaNo);
            myArch.Number = int.Parse(txtNumber.Text);
            myArch.DocType = 504;
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

        protected void BtnFind2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtCarNo.Text != "")
                {
                    txtCarNo.Text = moh.MakeMask(txtCarNo.Text, 5);
                    Cars myInv = new Cars();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myInv.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myInv.CarsType = int.Parse(ddlCar.SelectedValue.Substring(0, 2));
                    myInv.Code = txtCarNo.Text;
                    myInv = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                             where sitm.Code == myInv.Code
                             select sitm).FirstOrDefault();
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الباب غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    else
                    {
                        ddlCar.SelectedValue = txtCarNo.Text;
                        ddlCar_SelectedIndexChanged(sender, e);
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم الباب";
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
                        if (CheckCarRCV(myCar.Code))
                        {
                            txtCarNo.Text = myCar.Code;
                            ddlCar.SelectedValue = myCar.Code;
                            if (myCar.FType2 != "-1")
                            {
                                Codes myCode = new Codes();
                                myCode.Branch = short.Parse(Session["Branch"].ToString());
                                myCode.Ftype = 30;
                                myCode.Code = int.Parse(myCar.FType2);
                                if (Cache["LastCodes" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCodes" + Session["CNN2"].ToString(), myCode.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                myCode = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                          where itm.Ftype == myCode.Ftype && itm.Code == myCode.Code
                                          select itm).FirstOrDefault();
                                if (myCode != null)
                                {
                                    txtCap.Text = myCode.FType2;
                                    txtFType2.Text = myCode.Name1;
                                    txtFType2.ToolTip = myCar.FType2;
                                }
                                else
                                {
                                    txtCap.Text = "";
                                    txtFType2.Text = "";
                                    txtFType2.ToolTip = "";
                                }
                            }
                        }
                        else
                        {
                            txtCarNo.Text = "";
                            ddlCar.SelectedIndex = 0;
                            ddlDriver.SelectedIndex = 0;
                            txtSearch2.Text = "";
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الشاحنة رقم " + myCar.Code + " لوحة رقم " + myCar.PlateNo + " لم يتم عمل بيان وصول لها ";
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

        protected void BtnLines_Click(object sender, EventArgs e)
        {
            try
            {
                string script = @"window.open('WebCarMoveLines.aspx?FDate="+txtGDate.Text+"&FNo="+txtNumber.Text+lblBranch.Text+"&Driver="+ddlDriver.SelectedValue+"&From="+ddlFrom.SelectedValue+"&To="+ddlTo.SelectedValue +@"','_blank','toolbar=no, scrollbars=no, resizable=no,location=no,menubar=no,status=no, top=100, left=300, width=650, height=500');";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), script, true);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            while (true)
            {
                txtNumber.Text = (int.Parse(txtNumber.Text) - 1).ToString();
                CarMove myInv = new CarMove();
                myInv.Branch = short.Parse(Session["Branch"].ToString());
                myInv.VouLoc = AreaNo;
                myInv.Number = int.Parse(txtNumber.Text);
                myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                if (myInv != null)
                {
                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 104;
                    myJv.LocType = 2;
                    myJv.LocNumber = short.Parse(myInv.VouLoc);
                    myJv.Number = myInv.Number;
                    myJv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myJv == null)
                    {
                        double CostAmount = 0;
                        double KM = 0;
                        CarPrices myPrice = new CarPrices();
                        myPrice.Branch = short.Parse(Session["Branch"].ToString());
                        myPrice.MonthNo = 0;
                        myPrice.FromCode = myInv.FromLoc;
                        myPrice.toCode = myInv.ToLoc;
                        myPrice.PLevel = "00002";
                        myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myPrice != null)
                        {
                            KM = (double)myPrice.KMeter;
                            //CostAmount = (double)myPrice.CostAmount;
                            CostAmount = Math.Round((double)(moh.doTripCost(txtGDate.Text) * KM),0);                            
                        }

                        Drivers myDrive = new Drivers();
                        myDrive.Branch = short.Parse(Session["Branch"].ToString());
                        myDrive.Code = myInv.DriverCode;
                        if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myDrive = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                                   where sitm.Code == myDrive.Code
                                   select sitm).FirstOrDefault();
                        if (myDrive != null)
                        {
                            //myInv.DriverCode = myDrive.Sponsor;
                            if ((bool)myDrive.Ajir)
                            {
                                CostAmount = Math.Round((double)(myDrive.Cost * KM),0);
                            }
                        }

                        CarMoveLines myCarMoveLine = new CarMoveLines();
                        myCarMoveLine.Branch = short.Parse(Session["Branch"].ToString());
                        myCarMoveLine.VouLoc = myInv.VouLoc;
                        myCarMoveLine.Number = myInv.Number;
                        myCarMoveLine = myCarMoveLine.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                        if (myCarMoveLine != null)
                        {
                            foreach (CarMoveLines itm in myCarMoveLine.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                if (itm.FromLoc == "-1" && itm.FNo != 1) CostAmount -= (double)itm.Cost;
                                else CostAmount += (double)itm.Cost;
                            }
                        }

                        if (CostAmount != 0)
                        {
                            myInv.Post(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, CostAmount, SiteInfo.DezelAcc, SiteInfo.TripAcc, SiteInfo.CurExpAcc, SiteInfo.Project, SiteInfo.Area, "00002", (ChkRent.Checked ? moh.StrToDouble(txtRentValue.Text) : 0));
                        }
                    }
                }
                else break;
            }
        }

        public void RefreshCache()
        {
            if (HttpRuntime.Cache["OverTrack_" + AreaNo + Session["CNN2"].ToString()] != null)
            {
                Cache.Remove("OverTrack_" + AreaNo + Session["CNN2"].ToString());
                Cache.Remove("OverTrack1_" + AreaNo + Session["CNN2"].ToString());
                Cache.Remove("OverTrack2_" + AreaNo + Session["CNN2"].ToString());
                if (HttpRuntime.Cache["OverCarMove_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMove_" + AreaNo + Session["CNN2"].ToString());
                if (HttpRuntime.Cache["OverCarMoveTrip_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMoveTrip_" + AreaNo + Session["CNN2"].ToString());
                if (HttpRuntime.Cache["OverCarMoveChart_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMoveChart_" + AreaNo + Session["CNN2"].ToString());

                Cities myCity = new Cities();
                myCity.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myCity.Code = ddlTo.SelectedValue;
                myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                          where sitm.Code == myCity.Code
                          select sitm).FirstOrDefault();
                if (myCity != null)
                {
                    if (myCity.Site != AreaNo)
                    {
                        if (HttpRuntime.Cache["OverTrack_" + myCity.Site + Session["CNN2"].ToString()] != null)
                        {
                            Cache.Remove("OverTrack_" + myCity.Site + Session["CNN2"].ToString());
                            Cache.Remove("OverTrack1_" + myCity.Site + Session["CNN2"].ToString());
                            Cache.Remove("OverTrack2_" + myCity.Site + Session["CNN2"].ToString());
                        }
                        if (HttpRuntime.Cache["OverCarMove_" + myCity.Site + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMove_" + myCity.Site + Session["CNN2"].ToString());
                        if (HttpRuntime.Cache["OverCarMoveTrip_" + myCity.Site + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMoveTrip_" + AreaNo + Session["CNN2"].ToString());
                        if (HttpRuntime.Cache["OverCarMoveChart_" + myCity.Site + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMoveChart_" + AreaNo + Session["CNN2"].ToString());
                    }
                }
            }
        }

        public bool CheckCarRCV(string CarNo)
        {
            bool Result = true;
            CarMove cm = new CarMove();
            cm.CarCode = CarNo;
            cm = cm.FindLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (cm != null)
            {
                CarMoveRCV Rcv = new CarMoveRCV();
                Rcv.Branch = 1;
                Rcv.CarMove = int.Parse(cm.VouLoc).ToString() + "/" + cm.Number.ToString();
                Rcv = Rcv.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                Result = (Rcv != null);
            }
            return Result;
        }

        public bool CheckDriverRCV(string Driverno)
        {
            bool Result = true;
            CarMove cm = new CarMove();
            cm.DriverCode = Driverno;
            cm = cm.FindLastDriver(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (cm != null)
            {
                CarMoveRCV Rcv = new CarMoveRCV();
                Rcv.Branch = 1;
                Rcv.CarMove = int.Parse(cm.VouLoc).ToString() + "/" + cm.Number.ToString();
                Rcv = Rcv.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                Result = (Rcv != null);
            }
            if (!Result)
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
                        Result = CheckCarRCV(myCar.Code);
                    }
            }
            return Result;
        }

        public bool CheckDriverRCV2(string Driverno)
        {
            bool Result = true;
            CarMove cm = new CarMove();
            cm.DriverCode = Driverno;
            cm = cm.FindLastDriver(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (cm != null)
            {
                CarMoveRCV Rcv = new CarMoveRCV();
                Rcv.Branch = 1;
                Rcv.CarMove = int.Parse(cm.VouLoc).ToString() + "/" + cm.Number.ToString();
                Rcv = Rcv.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                Result = (Rcv != null);
            }
            return Result;
        }


        protected void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch2.Text != "")
            {
                Cars myCar = new Cars();
                myCar.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myCar.PlateNo = txtSearch2.Text;
                myCar = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                         where sitm.PlateNo == myCar.PlateNo
                         select sitm).FirstOrDefault();
                if (myCar != null)
                {
                    txtCarNo.Text = myCar.Code;
                    ddlCar.SelectedValue = myCar.Code;
                    ddlCar_SelectedIndexChanged(sender, e);
                }
            }
        }

        protected void ChkRent_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkRent.Checked)
            {
                Label11.Text = "رقم اللوحه";

                txtCarNo.Visible = false;
                BtnFind2.Visible = false;
                txtSearch2.Visible = false;
                txtRentPlateNo.Visible = true;

                lblRentValue.Text = "قيمة الايجار";
                lblRentValue.Visible = true;
                txtRentValue.Visible = true;

                Label4.Text = "رقم الجوال";
                txtRentMobileNo.Visible = true;

                ddlCar.Visible = false;
                ValCar.Enabled = false;
                ddlCar.SelectedIndex = 0;

                ddlDriver.Visible = false;
                ValDriver.Enabled = false;
                ValRentDriver.Enabled = true;
                ddlDriver.SelectedIndex = 0;

                txtRentDriver.Visible = true;
                ValRentValue.Enabled = true;
                ValRentValue2.Enabled = true;
                ValRentPlateNo.Enabled = true;

                Label12.Text = "نوع الشاحنة";
                txtRemark.Visible = false;
                ddlRemark.Visible = true;

            }
            else
            {
                Label11.Text = "رقم الباب";

                txtCarNo.Visible = true;
                BtnFind2.Visible = true;
                txtSearch2.Visible = true;
                txtRentPlateNo.Visible = false;
                txtRentPlateNo.Text = "";

                lblRentValue.Visible = false;
                txtRentValue.Visible = false;
                txtRentValue.Text = "";

                Label4.Text = "الناقلة";
                txtRentMobileNo.Visible = false;
                txtRentMobileNo.Text = "";

                ddlCar.Visible = true;
                ValCar.Enabled = true;

                ddlDriver.Visible = true;
                ValDriver.Enabled = true;
                ValRentDriver.Enabled =  false;

                txtRentDriver.Visible = false;
                txtRentDriver.Text = "";
                ValRentValue.Enabled = false;
                ValRentValue2.Enabled = false;
                ValRentPlateNo.Enabled = false;

                Label12.Text = "المرفقات";
                txtRemark.Visible = true;
                ddlRemark.Visible = false;
                Label6.Text = "ملحقات الناقلة";
                txtFType2.Visible = true;

            }
        }

        protected void ChkInvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<myInv2> SelectedVou = new List<myInv2>();
            if (grdCodes.Rows != null && grdCodes.Rows.Count > 0)
            {
                int r = 0;
                foreach (GridViewRow gvr in grdCodes.Rows)
                {
                    CheckBox ChkStatus = gvr.FindControl("ChkStatus") as CheckBox;
                    if (ChkStatus.Checked)
                    {
                        SelectedVou.Add(new myInv2
                        {
                            VouNo = VouData[r].VouNo,
                            InvoiceFNo = VouData[r].InvoiceFNo,
                            CarMoveNo = VouData[r].CarMoveNo,
                            CarMoveLoc = VouData[r].CarMoveLoc,
                            InvoiceVouLoc = VouData[r].InvoiceVouLoc,
                            Flag = VouData[r].Flag
                        });
                    }
                    r++;
                }
            }

            VouData.Clear();
            if (ChkInvType.Items[0].Selected)
            {                                
                if (txtSearch.Text == txtNumber.Text)
                {
                    CarMove myInv = new CarMove();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.Number = int.Parse(txtSearch.Text);
                    VouData = myInv.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }

                Invoice inv = new Invoice();
                inv.Branch = short.Parse(Session["Branch"].ToString());
                inv.VouLoc = AreaNo;
                if (ChkAll.Checked)
                {
                    if (txtNumber.ReadOnly)
                    {
                        List<myInv2> myList = new List<myInv2>();
                        myList = inv.GetInvMove(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myList != null) VouData.AddRange(myList);
                    }
                    else VouData.AddRange(inv.GetInvMove(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    if (((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("admin"))
                    {
                        TripCollect tinv = new TripCollect();
                        tinv.Branch = 1;
                        tinv.VouLoc = AreaNo;
                        VouData.AddRange((from itm in tinv.GetTripMove(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                          where itm.Flag.Trim() == ""
                                          select itm).ToList());
                    }
                }
                else if (ddlTo.SelectedIndex > 0)
                {
                    inv.Destination = ddlTo.SelectedValue;
                    VouData.AddRange(inv.GetInvMove2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    if (((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("admin"))
                    {
                        TripCollect tinv = new TripCollect();
                        tinv.Branch = 1;
                        tinv.VouLoc = AreaNo;
                        tinv.ToLoc = ddlTo.SelectedValue;
                        VouData.AddRange((from itm in tinv.GetTripMove2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                          where itm.Flag.Trim() == ""
                                          select itm).ToList());
                    }

                }
            }

            if (ChkInvType.Items[1].Selected)
            {                
                LShipment inv2 = new LShipment();
                inv2.Branch = short.Parse(Session["Branch"].ToString());
                inv2.VouLoc = AreaNo;
                if (ChkAll.Checked)
                {
                    if (txtNumber.ReadOnly)
                    {
                        List<myInv2> myList = new List<myInv2>();
                        myList = inv2.GetInvMove(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myList != null) VouData.AddRange(myList);
                    }
                    else VouData.AddRange(inv2.GetInvMove(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                }
                else if (ddlTo.SelectedIndex > 0)
                {
                    inv2.Destination = ddlTo.SelectedValue;
                    VouData.AddRange(inv2.GetInvMove2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                }
            }

            if (ChkInvType.Items[2].Selected)
            {
                Shipment inv2 = new Shipment();
                inv2.Branch = short.Parse(Session["Branch"].ToString());
                inv2.VouLoc = AreaNo;
                if (ChkAll.Checked)
                {
                    if (txtNumber.ReadOnly)
                    {
                        List<myInv2> myList = new List<myInv2>();
                        myList = inv2.GetInvMove(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myList != null) VouData.AddRange(myList);
                    }
                    else VouData.AddRange(inv2.GetInvMove(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    if (((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("admin"))
                    {
                        TripCollect tinv = new TripCollect();
                        tinv.Branch = 1;
                        tinv.VouLoc = AreaNo;
                        VouData.AddRange((from itm in tinv.GetTripMove(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                          where itm.Flag.Trim() == "E"
                                          select itm).ToList());
                    }
                }
                else if (ddlTo.SelectedIndex > 0)
                {
                    inv2.Destination = ddlTo.SelectedValue;
                    VouData.AddRange(inv2.GetInvMove2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    if (((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("admin"))
                    {
                        TripCollect tinv = new TripCollect();
                        tinv.Branch = 1;
                        tinv.VouLoc = AreaNo;
                        tinv.ToLoc = ddlTo.SelectedValue;
                        VouData.AddRange((from itm in tinv.GetTripMove2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                          where itm.Flag.Trim() == "E"
                                          select itm).ToList());
                    }
                }
            }

            if (ChkInvType.Items[0].Selected || ChkInvType.Items[1].Selected || ChkInvType.Items[2].Selected)
            {
                List<myInv2> myList2 = new List<myInv2>();
                CarMove myCarMove = new CarMove();
                myCarMove.Branch = short.Parse(Session["Branch"].ToString());
                myCarMove.VouLoc = AreaNo;
                myCarMove.ToLoc = ddlTo.SelectedValue;
                myList2 = (from itm in myCarMove.Gettr(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, ChkAll.Checked, SiteInfo.City, AreaNo)
                           where (ChkInvType.Items[0].Selected && itm.Flag=="") || (ChkInvType.Items[1].Selected && itm.Flag=="L") || (ChkInvType.Items[2].Selected && itm.Flag=="E")
                           select itm).ToList();
                if (myList2 != null) VouData.AddRange(myList2);
            }


            if (SelectedVou != null && SelectedVou.Count > 0)
            {
                foreach (myInv2 itm in SelectedVou)
                {
                    foreach (myInv2 sitm in VouData)
                    {
                        if (itm.VouNo == sitm.VouNo && itm.InvoiceVouLoc == sitm.InvoiceVouLoc && itm.InvoiceFNo == sitm.InvoiceFNo && itm.Flag == sitm.Flag)
                        {
                            sitm.Status = true;
                            break;
                        }
                    }
                }

                VouData = VouData.OrderByDescending(x => x.Status).ToList();
            }                
            LoadVouData();
        }

        protected void ddlFrom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public void ProcessTrackMove()
        {
            if (HttpRuntime.Cache["OverTrack_" + AreaNo + Session["CNN2"].ToString()] == null)
            {
                MyOverTrack.Clear();
                MyOverTrack1.Clear();
                MyOverTrack2.Clear();

                List<Drivers> dr = new List<Drivers>();
                Drivers Drive = new Drivers();
                Drive.Branch = 1;
                if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), Drive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                dr = (from itm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                      where (bool)itm.Status
                      select itm).ToList();

                List<Cities> lcity = new List<Cities>();
                Cities myCity = new Cities();
                myCity.Branch = 1;
                if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                lcity = (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()]);

                List<Cities> lc = new List<Cities>();
                Cities mc = new Cities();
                mc.Branch = 1;
                if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), mc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                lc = mc.GetMySites(AreaNo, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()]), (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()]));

                int i = 1;
                int i1 = 1;
                int i2 = 1;
                Cars myCar = new Cars();
                myCar.Branch = 1;
                if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myCar.CarsType = 1;
                foreach (Cars itm in (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                      where (sitm.CarsType == 1 || sitm.CarsType == 3 || sitm.CarsType == 32 || sitm.CarsType == 33) && (bool)sitm.Status
                                      orderby sitm.PlateNo
                                      select sitm
                                          ).ToList())
                {
                    if ((bool)itm.Status)
                    {
                        CarMove cm = new CarMove();
                        cm.CarCode = itm.Code;
                        cm = cm.FindLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (cm != null)
                        {
                            if (CheckSite(cm.ToLoc, lc))
                            {
                                CarPrices myPrice = new CarPrices();
                                myPrice.Branch = 1;
                                myPrice.MonthNo = 0;
                                myPrice.FromCode = cm.FromLoc;
                                myPrice.toCode = cm.ToLoc;
                                myPrice.PLevel = "00002";
                                myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                DateTime DFrom = new DateTime();
                                double add = 0;
                                if (myPrice != null && !string.IsNullOrEmpty(myPrice.FTime) && !string.IsNullOrEmpty(cm.FTime))
                                {
                                    double.TryParse(myPrice.FTime, out add);
                                    DFrom = DateTime.Parse(cm.GDate + " " + cm.FTime.Replace("ص", "AM").Replace("م", "PM"));
                                }

                                CarMoveRCV Rcv = new CarMoveRCV();
                                Rcv.Branch = 1;
                                Rcv.CarMove = int.Parse(cm.VouLoc).ToString() + "/" + cm.Number.ToString();
                                Rcv = Rcv.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (Rcv == null)
                                {
                                    MyOverTrack.Add(new TrackMove
                                    {
                                        FNo = i++,
                                        Code = itm.Code,
                                        PlateNo = itm.PlateNo,
                                        CarMoveNo = int.Parse(cm.VouLoc).ToString() + "/" + cm.Number.ToString(),
                                        CarMoveFTime = cm.FTime,
                                        CarMoveDate = cm.GDate,
                                        CarMoveFrom = cm.FromLoc,
                                        CarMoveFromLoc = (from d in lcity
                                                          where d.Code == cm.FromLoc
                                                          select d.Name1).FirstOrDefault(),
                                        CarMoveTo = cm.ToLoc,
                                        CarMoveToLoc = (from d in lcity
                                                        where d.Code == cm.ToLoc
                                                        select d.Name1).FirstOrDefault(),
                                        DriverCode = cm.DriverCode,
                                        Driver = (from d in dr
                                                  where d.Code == cm.DriverCode
                                                  select d.Name1).FirstOrDefault(),
                                        RCVFTime = (myPrice != null && !string.IsNullOrEmpty(myPrice.FTime) && !string.IsNullOrEmpty(cm.FTime) ? DFrom.AddHours(add).ToString() : ""),
                                        RCVFTime2 = (myPrice != null && !string.IsNullOrEmpty(myPrice.FTime) && !string.IsNullOrEmpty(cm.FTime) ? DFrom.AddHours(add).ToShortTimeString() : "")
                                    });


                                    //if (string.IsNullOrEmpty(itm.RCVFTime))
                                    //{
                                    //    itm.Status = " *****في الطريق";
                                    //}
                                    //else if (DateTime.Now > DateTime.Parse(itm.RCVFTime))
                                    //{
                                    //    itm.Status = "تأخرت في الطريق";
                                    //}
                                    //else
                                    //{
                                    //    itm.Status = "في الطريق";
                                    //}
                                }
                                else
                                {
                                    MyOverTrack2.Add(new TrackMove
                                    {
                                        FNo = i2++,
                                        Code = itm.Code,
                                        PlateNo = itm.PlateNo,
                                        CarMoveNo = int.Parse(cm.VouLoc).ToString() + "/" + cm.Number.ToString(),
                                        CarMoveFTime = cm.FTime,
                                        CarMoveDate = cm.GDate,
                                        CarMoveFrom = cm.FromLoc,
                                        CarMoveFromLoc = (from d in lcity
                                                          where d.Code == cm.FromLoc
                                                          select d.Name1).FirstOrDefault(),
                                        CarMoveTo = cm.ToLoc,
                                        CarMoveToLoc = (from d in lcity
                                                        where d.Code == cm.ToLoc
                                                        select d.Name1).FirstOrDefault(),
                                        DriverCode = cm.DriverCode,
                                        Driver = (from d in dr
                                                  where d.Code == cm.DriverCode
                                                  select d.Name1).FirstOrDefault(),
                                        CarMoveRCVNo = Rcv.LocNumber.ToString() + "/" + Rcv.Number.ToString(),
                                        CarMoveRCVDate = Rcv.GDate,
                                        CarMoveRCVFTime = Rcv.FTime,
                                        Status = "تم الوصول"
                                    });
                                }
                            }
                            else if (CheckSite(cm.FromLoc, lc))
                            {
                                CarMoveRCV Rcv = new CarMoveRCV();
                                Rcv.Branch = 1;
                                Rcv.CarMove = int.Parse(cm.VouLoc).ToString() + "/" + cm.Number.ToString();
                                Rcv = Rcv.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (Rcv == null)
                                {
                                    MyOverTrack1.Add(new TrackMove
                                    {
                                        FNo = i1++,
                                        Code = itm.Code,
                                        PlateNo = itm.PlateNo,
                                        CarMoveNo = int.Parse(cm.VouLoc).ToString() + "/" + cm.Number.ToString(),
                                        CarMoveFTime = cm.FTime,
                                        CarMoveDate = cm.GDate,
                                        CarMoveFrom = cm.FromLoc,
                                        CarMoveFromLoc = (from d in lcity
                                                          where d.Code == cm.FromLoc
                                                          select d.Name1).FirstOrDefault(),
                                        CarMoveTo = cm.ToLoc,
                                        CarMoveToLoc = (from d in lcity
                                                        where d.Code == cm.ToLoc
                                                        select d.Name1).FirstOrDefault(),
                                        DriverCode = cm.DriverCode,
                                        Driver = (from d in dr
                                                  where d.Code == cm.DriverCode
                                                  select d.Name1).FirstOrDefault()
                                    });

                                    //CarPrices myPrice = new CarPrices();
                                    //myPrice.Branch = 1;
                                    //myPrice.MonthNo = 0;
                                    //myPrice.FromCode = cm.FromLoc;
                                    //myPrice.toCode = cm.FromLoc;
                                    //myPrice.PLevel = "00002";
                                    //myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    //if (myPrice != null && !string.IsNullOrEmpty(myPrice.FTime) && !string.IsNullOrEmpty(cm.FTime))
                                    //{
                                    //    double add = 0;
                                    //    double.TryParse(myPrice.FTime, out add);
                                    //    DateTime DFrom = new DateTime();
                                    //    DFrom = DateTime.Parse(cm.GDate + " " + cm.FTime.Replace("ص", "AM").Replace("م", "PM"));
                                    //    itm.RCVFTime = DFrom.AddHours(add).ToString();
                                    //    itm.RCVFTime2 = DFrom.AddHours(add).ToShortTimeString();
                                    //}

                                    //if (string.IsNullOrEmpty(itm.RCVFTime))
                                    //{
                                    //    itm.Status = " *****في الطريق";
                                    //}
                                    //else if (DateTime.Now > DateTime.Parse(itm.RCVFTime))
                                    //{
                                    //    itm.Status = "تأخرت في الطريق";
                                    //}
                                    //else
                                    //{
                                    //    itm.Status = "في الطريق";
                                    //}
                                }
                            }
                        }
                    }
                }

                CostCenter myCostCenter = new CostCenter();
                myCostCenter.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                CarMove mycm = new CarMove();
                mycm.VouLoc = AreaNo;
                foreach (CarMove cr in mycm.CarMoveNotRcv(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, (List<CostCenter>)(HttpRuntime.Cache["LastCostCenter" + Session["CNN2"].ToString()])))
                {
                    if (cr.Rent != null && (bool)cr.Rent)
                    {
                        if (CheckSite(cr.DriverCode, lc))
                        {
                            CarPrices myPrice = new CarPrices();
                            myPrice.Branch = 1;
                            myPrice.MonthNo = 0;
                            myPrice.FromCode = cr.FromLoc;
                            myPrice.toCode = cr.DriverCode;
                            myPrice.PLevel = "00002";
                            myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            DateTime DFrom = new DateTime();
                            double add = 0;
                            if (myPrice != null && !string.IsNullOrEmpty(myPrice.FTime) && !string.IsNullOrEmpty(cr.FTime))
                            {
                                double.TryParse(myPrice.FTime, out add);
                                DFrom = DateTime.Parse(cr.GDate + " " + cr.FTime.Replace("ص", "AM").Replace("م", "PM"));
                            }

                            CarMoveRCV Rcv = new CarMoveRCV();
                            Rcv.Branch = 1;
                            Rcv.CarMove = int.Parse(cr.VouLoc).ToString() + "/" + cr.Number.ToString();
                            Rcv = Rcv.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (Rcv == null)
                            {
                                MyOverTrack.Add(new TrackMove
                                {
                                    FNo = i++,
                                    Code = "مستأجرة",
                                    PlateNo = cr.RentPlateNo,
                                    CarMoveNo = int.Parse(cr.VouLoc).ToString() + "/" + cr.Number.ToString(),
                                    CarMoveFTime = cr.FTime,
                                    CarMoveDate = cr.GDate,
                                    CarMoveFrom = cr.FromLoc,
                                    CarMoveFromLoc = (from d in lcity
                                                      where d.Code == cr.FromLoc
                                                      select d.Name1).FirstOrDefault(),
                                    CarMoveTo = cr.DriverCode,
                                    CarMoveToLoc = (from d in lcity
                                                    where d.Code == cr.DriverCode
                                                    select d.Name1).FirstOrDefault(),
                                    DriverCode = cr.DriverCode,
                                    Driver = cr.RentDriver + " " + cr.RentValue.ToString() + " ريال ",
                                    RCVFTime = (myPrice != null && !string.IsNullOrEmpty(myPrice.FTime) && !string.IsNullOrEmpty(cr.FTime) ? DFrom.AddHours(add).ToString() : ""),
                                    RCVFTime2 = (myPrice != null && !string.IsNullOrEmpty(myPrice.FTime) && !string.IsNullOrEmpty(cr.FTime) ? DFrom.AddHours(add).ToShortTimeString() : "")
                                });

                            }

                        }
                        else if (CheckSite(cr.FromLoc, lc))
                        {
                            MyOverTrack1.Add(new TrackMove
                            {
                                FNo = i1++,
                                Code = "مستأجرة",
                                PlateNo = cr.RentPlateNo,
                                CarMoveNo = int.Parse(cr.VouLoc).ToString() + "/" + cr.Number.ToString(),
                                CarMoveFTime = cr.FTime,
                                CarMoveDate = cr.GDate,
                                CarMoveFrom = cr.FromLoc,
                                CarMoveFromLoc = (from d in lcity
                                                  where d.Code == cr.FromLoc
                                                  select d.Name1).FirstOrDefault(),
                                CarMoveTo = cr.DriverCode,
                                CarMoveToLoc = (from d in lcity
                                                where d.Code == cr.DriverCode
                                                select d.Name1).FirstOrDefault(),
                                DriverCode = cr.DriverCode,
                                Driver = cr.RentDriver + " " + cr.RentValue.ToString() + " ريال "
                            });
                        }
                    }
                }

                try
                {
                    i = 1;
                    MyOverTrack = MyOverTrack.OrderBy(c => DateTime.Parse(c.RCVFTime)).ToList();
                }
                catch
                { }
                foreach (TrackMove itm in MyOverTrack)
                {
                    itm.FNo = i++;
                }
                Cache.Insert("OverTrack_" + AreaNo + Session["CNN2"].ToString(), MyOverTrack);
                //CheckTrack(MyOverTrack);

                try
                {
                    i = 1;
                    MyOverTrack2 = MyOverTrack2.OrderByDescending(c => DateTime.Parse(c.CarMoveRCVDate + " " + c.CarMoveRCVFTime.Replace("ص", "AM").Replace("م", "PM"))).ToList();
                }
                catch
                { }
                foreach (TrackMove itm in MyOverTrack2)
                {
                    itm.FNo = i++;
                }
                Cache.Insert("OverTrack2_" + AreaNo + Session["CNN2"].ToString(), MyOverTrack2);
                //CheckTrack(MyOverTrack2);

                try
                {
                    i = 1;
                    MyOverTrack1 = MyOverTrack1.OrderByDescending(c => DateTime.Parse(c.CarMoveDate + " " + c.CarMoveFTime.Replace("ص", "AM").Replace("م", "PM"))).ToList();
                }
                catch
                { }
                foreach (TrackMove itm in MyOverTrack1)
                {
                    itm.FNo = i++;
                }
                Cache.Insert("OverTrack1_" + AreaNo + Session["CNN2"].ToString(), MyOverTrack1);
                //CheckTrack(MyOverTrack1);
            }
        }

        public bool CheckSite(string CurrentCity, List<Cities> lc)
        {
            try
            {
                bool vFound = false;
                if (lc != null)
                {
                    foreach (Cities itm in lc)
                    {
                        if (CurrentCity == itm.Code)
                        {
                            vFound = true;
                            break;
                        }
                    }
                }
                return vFound;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}