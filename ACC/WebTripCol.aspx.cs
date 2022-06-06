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
using System.Data;

namespace ACC
{
    public partial class WebTripCol : System.Web.UI.Page
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
                    ViewState["AreaNo"] = "00019";
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

            BtnPrint.Visible = true; // && (Request.QueryString["Support"] != null || (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass215);
            BtnEdit.Visible = true; // && Request.QueryString["Support"] == null && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass212;
            BtnNew.Visible = false;
            BtnDelete.Visible = true; // && Request.QueryString["Support"] == null && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass213;
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
            //if (Request.QueryString["Support"] != null || !(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass212 || !BtnEdit.Visible) ControlsOnOff(false);
        }

        public void NewMode()
        {
            txtNumber.ReadOnly = true;
            txtNumber.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = true; // && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass211;
            BtnDelete.Visible = false;

            txtReason.Visible = false;
            ValReason.Enabled = false;
            lblReason.Visible = false;

            //if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass212 || !BtnEdit.Visible) ControlsOnOff(true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Cities myCity = new Cities();
                    this.Page.Header.Title = "بيان تسليم للفرع";

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

                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "الرئيسية", "اختيار", "اختيار بيان التجميع", "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    vRoleName = moh.GetCurrentRole(AreaNo, (from useritm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                                            where useritm.UserName == Session["CurrentUser"].ToString()
                                                            select useritm).FirstOrDefault());
                    /*
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
                     //   BtnSearch.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass214;
                        BtnPrint.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass215;
                        BtnFind.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass214;
                    } 
                    */

                    lblBranch.Text = "/" + short.Parse(AreaNo).ToString();

                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlFrom.DataTextField = "Name1";
                    ddlFrom.DataValueField = "Code"; // edited by hanan
                    ddlFrom.DataSource = (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()]);
                    ddlFrom.DataBind();
                    ddlFrom.Items.Insert(0, new ListItem("-- أختر منطقة التجميع --", "-1", true));

                    CarsType mytype = new CarsType();

                    mytype.Branch = short.Parse(Session["Branch"].ToString());
                    ddlType.DataTextField = "Name1";
                    ddlType.DataValueField = "Code";
                    ddlType.DataSource = mytype.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlType.DataBind();
                    ddlType.Items.Insert(0, new ListItem("-- أختر نوع الناقلة --", "-1", true));

                    ShipDrivers mydr2 = new ShipDrivers();
                    mydr2.Branch = short.Parse(Session["Branch"].ToString());
                    ddlDriver.DataValueField = "ID";
                    ddlDriver.DataTextField = "Name";
                    ddlDriver.DataSource = mydr2.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlDriver.DataBind();
                    ddlDriver.Items.Insert(0, new ListItem(" -- إختر السائق", "-1", true));


                    if (Request.QueryString["AreaNo"] != null)
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
                        AreaNo = Request.QueryString["AreaNo"].ToString();
                    }
                    BtnClear_Click(sender, null);
                    if (Request.QueryString["FMode"] != null && Request.QueryString["FNum"] != null)
                    {
                        txtSearch.Text = Request.QueryString["FNum"].ToString();
                        BtnFind_Click(sender, e);
                        ControlsOnOff(false);
                        ChkStatus.Enabled = true;
                        ChkAll.Visible = false;
                        ChkInvType.Visible = false;
                        ChkRent.Visible = false;
                        BtnClear.Visible = false;
                        BtnDelete.Visible = false;
                        BtnNew.Visible = false;
                        BtnEdit.Visible = false;
                        BtnPrint.Visible = false;
                        Label9.Visible = false;
                             
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

        protected void LoadVouData()
        {
            try
            {
                grdCodes.DataSource = null;
                grdCodes.DataBind();
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
                    //  Response.Redirect("GeneralServerError.aspx", false);
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }


        public void PutInv(TripCollect mytrip)
        {
            mytrip.DriverCode = ddlDriver.SelectedValue;
            mytrip.CarCode = ddlCar.SelectedValue;
            mytrip.FromLoc = ddlFrom.SelectedValue;
            mytrip.HDate = txtHDate.Text;
            mytrip.GDate = txtGDate.Text;
            mytrip.UserName = txtUserName.ToolTip;
            mytrip.UserDate = txtUserDate.Text;
            mytrip.FTime = LblFTime.Text;
            mytrip.Rent = ChkRent.Checked;
            mytrip.RentMobileNo = txtRentMobileNo.Text;
            mytrip.RentDriver = txtRentDriver.Text;
            mytrip.Status = (short)(ChkStatus.Checked ? 1 : 99);
            //mytrip.RentValue = moh.StrToDouble(txtRentValue.Text);
            //mytrip.RentPlateNo = txtRentPlateNo.Text;
        }


        public void GetInv(TripCollect mytrip)
        {
            if (ddlDriver.Items.FindByValue(mytrip.DriverCode) != null) ddlDriver.SelectedValue = mytrip.DriverCode;

            if (ddlCar.Items.FindByValue(mytrip.CarCode) != null) ddlCar.SelectedValue = mytrip.CarCode;
            else
            {
                Cars myCar = new Cars();
                myCar.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myCar.Code = mytrip.CarCode;
                myCar.CarsType = int.Parse(mytrip.CarCode.Substring(0, 2));
                myCar = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                         where sitm.Code == myCar.Code
                         select sitm).FirstOrDefault();
                if (myCar != null)
                {
                    ddlCar.Items.Add(new ListItem(myCar.PlateNo, myCar.Code));
                    ddlCar.SelectedValue = mytrip.CarCode;
                }
            }
            ddlFrom.SelectedValue = mytrip.ToLoc;
            txtHDate.Text = mytrip.HDate;
            txtGDate.Text = mytrip.GDate;
            LblFTime.Text = mytrip.FTime;


            txtUserName.ToolTip = mytrip.UserName;
            TblUsers ax = new TblUsers();
            if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            ax.UserName = mytrip.UserName;
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
            txtUserDate.Text = mytrip.UserDate;

            ChkRent.Checked = (bool)mytrip.Rent;
            txtRentMobileNo.Text = mytrip.RentMobileNo;
            txtRentDriver.Text = mytrip.RentDriver;
            //txtRentValue.Text = mytrip.RentValue.ToString();
            //txtRentPlateNo.Text = mytrip.RentPlateNo;
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChkRent.Checked == true)  // edited by hanan2
            {
                CoDrivers mydr = new CoDrivers();
                mydr.TransType = short.Parse(ddlType.SelectedValue);
                ddlCar.DataTextField = "DPlateNo";
                ddlCar.DataValueField = "ID";
                ddlCar.DataSource = mydr.FindByTransType(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                ddlCar.DataBind();
                ddlCar.Items.Insert(0, new ListItem("-- أختر الناقلة --", "-1", true));
            }
            else
            {
                // edited by hanan5 : from here
                if (ChkAll.Checked == true)
                {
                    ChkAll_CheckedChanged(sender, e);
                }
                else
                {
                    Cars mycars = new Cars();
                    List<Cars> carlist = new List<Cars>();

                    mycars.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), mycars.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    mycars.CarsType = int.Parse(ddlType.SelectedValue);

                    ddlCar.DataTextField = "PlateNo";
                    ddlCar.DataValueField = "DriverCode";
                    carlist = (from itm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                               where itm.CarsType == mycars.CarsType
                               select itm).ToList();
                    ddlCar.DataSource = carlist;
                    ddlCar.DataBind();
                    ddlCar.Items.Insert(0, new ListItem("-- أختر الناقلة --", "-1", true));

                }

                // edited by hanan5 : to here
            }
        }

        protected void ddlFrom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (ChkRent.Checked == true)  // edited by hanan2
            {
                ddlDriver.SelectedValue = ddlCar.SelectedValue;
                CoDrivers myDr = new CoDrivers();
                myDr.ID = int.Parse(ddlDriver.SelectedValue);
                myDr = myDr.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                txtRentDriver.Text = myDr.Name2;

            }
            else
            {
                Cars mycars = new Cars();

                mycars.Branch = short.Parse(Session["Branch"].ToString());
                mycars.Code = ddlType.SelectedValue;

                Drivers myDr = new Drivers();

                myDr.Branch = short.Parse(Session["Branch"].ToString());
                myDr.Code = ddlCar.SelectedValue;
                myDr = myDr.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if( myDr != null) // edited by hanan5
                txtRentDriver.Text = myDr.Name2;

                ddlDriver.SelectedValue = ddlCar.SelectedValue;
            }
             */
        }

        protected void ddlDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (ChkRent.Checked == true)  // edited by hanan2
            {
                ddlCar.SelectedValue = ddlDriver.SelectedValue;

                CoDrivers myDr = new CoDrivers();
                myDr.ID = int.Parse(ddlDriver.SelectedValue);
                myDr = myDr.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                txtRentDriver.Text = myDr.Name2;

            }
            else
            {
                Drivers myDr = new Drivers();

                myDr.Branch = short.Parse(Session["Branch"].ToString());
                myDr.Code = ddlDriver.SelectedValue;
                myDr = myDr.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                txtRentDriver.Text = myDr.Name2;

                ddlCar.SelectedValue = ddlDriver.SelectedValue;
            }
             */
        }

        /*     protected void ChkInvType_SelectedIndexChanged(object sender, EventArgs e)
             {
                 if (ChkInvType.Items[0].Selected == true && ChkInvType.Items[1].Selected == false && ChkInvType.Items[2].Selected == false)
                 {
                     string place1 = ddlFrom.SelectedValue;
                     LoadCodesData(place1, 0);
                 }
                 else if (ChkInvType.Items[1].Selected == true && ChkInvType.Items[0].Selected == false && ChkInvType.Items[2].Selected == false)
                 {
                     string place1 = ddlFrom.SelectedValue;
                     LoadCodesData(place1, 1);
                 }
                 else if (ChkInvType.Items[0].Selected == false && ChkInvType.Items[1].Selected == false && ChkInvType.Items[2].Selected == true)
                 {
                     string place1 = ddlFrom.SelectedValue;
                     LoadCodesData(place1, 2);
                 }

             } */


        protected void ChkInvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<myInv2> SelectedVou = new List<myInv2>();
            List<myInv2> newVou = new List<myInv2>();

            if (ChkInvType.Items[0].Selected) // ChkAll_CheckedChanged(sender, e);
            {
                // store every row checked
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

                // get lshipment inv
                Invoice inv = new Invoice();
                inv.Branch = short.Parse(Session["Branch"].ToString());
                inv.VouLoc = AreaNo;
                if (ddlFrom.SelectedIndex > 0)
                {
                    inv.PlaceofLoading = ddlFrom.SelectedValue;
                    newVou.AddRange(inv.GetInvMove3(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                }
            }
            if (ChkInvType.Items[1].Selected)
            {

                // store every row checked
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

                // get shipment inv
                Shipment myship = new Shipment();
                myship.Branch = short.Parse(Session["Branch"].ToString());
                myship.VouLoc = AreaNo;
                if (ddlFrom.SelectedIndex > 0)
                {
                    myship.PlaceofLoading = ddlFrom.SelectedValue;
                    newVou.AddRange(myship.GetInvMove3(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                }


            }

            if (ChkInvType.Items[2].Selected)
            {
                // store every row checked
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

                // get lshipment inv
                LShipment mylship = new LShipment();
                mylship.Branch = short.Parse(Session["Branch"].ToString());
                mylship.VouLoc = AreaNo;
                if (ddlFrom.SelectedIndex > 0)
                {
                    mylship.PlaceofLoading = ddlFrom.SelectedValue;
                    newVou.AddRange(mylship.GetInvMove3(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                }
            }



            if (SelectedVou != null && SelectedVou.Count > 0)
            {
                foreach (myInv2 itm in SelectedVou)
                {
                    foreach (myInv2 sitm in newVou)
                    {
                        if (itm.VouNo == sitm.VouNo && itm.InvoiceVouLoc == sitm.InvoiceVouLoc && itm.InvoiceFNo == sitm.InvoiceFNo)
                        {
                            sitm.Status = true;
                            break;
                        }
                    }
                }


                newVou = newVou.OrderByDescending(x => x.Status).ToList();
            }

            VouData.Clear();
            VouData = newVou;
            LoadVouData();
        }

        public string getCity(int id)
        {
            if (id < 0) return "";
            string id1;
            string city1;
            Cities myCity = new Cities();
            if (id < 10)
                id1 = "0000" + id.ToString();
            else
                id1 = "000" + id.ToString();

            myCity.Branch = short.Parse(Session["Branch"].ToString());
            myCity.Code = id1;
            if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                      where sitm.Code == myCity.Code
                      select sitm).FirstOrDefault();
            city1 = myCity.Name1;
            return city1;
        }

        public void ControlsOnOff(bool State)
        {

            txtGDate.Enabled = State;
            txtHDate.Enabled = State;
            ddlFrom.Enabled = State;
            ddlDriver.Enabled = State;
            ddlCar.Enabled = State;
            //   ChkAll.Enabled = State;
            //   grdAttach.Enabled = State;
            //   FileUpload1.Enabled = State;
            //    BtnAttach.Enabled = State;
            //    ChkNoCost.Enabled = State;
            txtReason.ReadOnly = !State;
            ChkRent.Enabled = State;
            txtRentMobileNo.ReadOnly = !State;
            txtRentDriver.ReadOnly = !State;
            ChkStatus.Enabled = State;
            //   txtRentValue.ReadOnly = !State;
            //   txtRentPlateNo.ReadOnly = !State;
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid)
                {

                    /*   if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                       {
                           if (DateTime.Parse(txtGDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                           {
                               LblCodesResult.ForeColor = System.Drawing.Color.Red;
                               LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                               ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                               return;
                           }
                       } */

                    BtnNew.Enabled = false;
                    if (!ValidateInv())
                    {
                        BtnNew.Enabled = true;
                        return;
                    }
                    TripCollect mytrip = new TripCollect();
                    mytrip.Branch = short.Parse(Session["Branch"].ToString());
                    mytrip.VouLoc = AreaNo;
                    mytrip.Number = int.Parse(txtNumber.Text);
                    mytrip.FNo = 1;
                    mytrip = mytrip.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    if (mytrip != null)
                    {
                        if (mytrip.UserName == txtUserName.ToolTip)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "بيان التجميع موجود مسبقا";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            BtnNew.Enabled = true;
                            return;
                        }
                        else
                        {
                            mytrip = new TripCollect();
                            mytrip.Branch = short.Parse(Session["Branch"].ToString());
                            mytrip.VouLoc = AreaNo;
                            int? myid = mytrip.GetMax(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myid == 0 || myid == null)
                            {
                                myid = 1;
                            }
                            else
                            {
                                myid++;
                            }
                            txtNumber.Text = myid.ToString();
                        }
                    }


                    mytrip = new TripCollect();
                    mytrip.Branch = short.Parse(Session["Branch"].ToString());
                    mytrip.VouLoc = AreaNo;
                    mytrip.Number = int.Parse(txtNumber.Text);
                    mytrip.DriverCode = ddlDriver.SelectedValue;
                    mytrip.CarCode = ddlCar.SelectedValue;
                    mytrip.ToLoc = ddlFrom.SelectedValue; // point of collecting
                    mytrip.HDate = txtHDate.Text;
                    mytrip.GDate = txtGDate.Text;
                    mytrip.UserName = txtUserName.ToolTip;
                    mytrip.UserDate = txtUserDate.Text;
                    mytrip.FTime = LblFTime.Text;
                    mytrip.Rent = ChkRent.Checked;
                    mytrip.RentPlateNo = "";
                    mytrip.RentValue = 0;
                    mytrip.RentDriver = txtRentDriver.Text;
                    mytrip.RentMobileNo = txtRentMobileNo.Text;
                    // edited by hanan (delete line )

                    int r = 0;
                    int FNo = 1;
                    bool Add = true;
                    foreach (GridViewRow gvr in grdCodes.Rows)
                    {
                        CheckBox ChkStatus = gvr.FindControl("ChkStatus") as CheckBox;
                        //    Label lblvouNo = gvr.FindControl("lblVouNo") as Label;
                        //    Label lblvouloc = gvr.FindControl("lblVouLoc") as Label;
                        //    Label lblLoading = gvr.FindControl("lblLoadingCode") as Label;
                        //    Label lbltype = gvr.FindControl("lblshiptype") as Label;

                        if (ChkStatus.Checked)
                        {
                            mytrip.FNo = (short)FNo;
                            mytrip.InvoiceNo = VouData[r].VouNo; // int.Parse(lblvouNo.Text);
                            mytrip.InvoiceLocNo = short.Parse(VouData[r].VouLoc); // short.Parse(lblvouloc.Text);
                            mytrip.InvoiceFNo = VouData[r].InvoiceFNo;
                            mytrip.FromLoc = VouData[r].PlaceofLoading; // lblLoading.Text; // place of customer invoice
                            mytrip.ShipType = VouData[r].Flag; //lbltype.Text;
                            mytrip.FTime = LblFTime.Text;
                            mytrip.DTPickUp = ""; // lblLoading.Text; // place of customer invoice
                            mytrip.DTDropOff = ""; //lbltype.Text;
                            mytrip.Status = (short)VouData[r].myStatus; // edited by hanan

                            Add = mytrip.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            FNo++;
                        }
                        r++;
                    }

                    if (FNo == 1)
                    {
                        mytrip.FNo = (short)FNo;
                        mytrip.InvoiceNo = 0;
                        mytrip.InvoiceLocNo = 0;
                        mytrip.InvoiceFNo = 0;
                        mytrip.FromLoc = ""; // place of customer invoice
                        mytrip.ShipType = "";
                        mytrip.FTime = LblFTime.Text;
                        mytrip.DTPickUp = ""; // lblLoading.Text; // place of customer invoice
                        mytrip.DTDropOff = ""; //lbltype.Text;
                        Add = mytrip.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }

                    if (Add)
                    {

                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                        BtnNew.Enabled = true;
                        BtnClear_Click(sender, e);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء إنشاء بيان التجميع ... حاول مرة أخرى";
                        BtnNew.Enabled = true;

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

            if (txtRentDriver.Text == "")
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يجب أدخال السائق";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }

            int Count = 0;
            int carSum = 0;
            //****************** edited by hanan3 : from here
            foreach (GridViewRow gvr in grdCodes.Rows)
            {
                CheckBox ChkStatus = gvr.FindControl("ChkStatus") as CheckBox;
                Label lbltype = gvr.FindControl("lblshiptype") as Label;
                if (ChkStatus.Checked)
                {
                    if (lbltype.Text == "")
                    {
                        if (ddlType.SelectedValue == "33")
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "نوع السيارة لا يتوافق مع الفاتورة";
                            return false;
                        }
                        else
                            Count++;
                    }
                }
            }

            ///// get size of car
            Cars mycars = new Cars();

            mycars.Branch = short.Parse(Session["Branch"].ToString());
            if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), mycars.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            mycars.DriverCode = ddlCar.SelectedValue;
            mycars = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                      where sitm.DriverCode == mycars.DriverCode && (bool)sitm.Status
                      select sitm).FirstOrDefault();

            if (mycars != null) // edited by hanan7
            { // edited by hanan7
                if (mycars.FType2 == "113")
                    carSum = 4;
                else if (mycars.FType2 == "114")
                    carSum = 10;
                else if (mycars.FType2 == "197")
                    carSum = 2;
            } // edited by hanan7

            if (Count > carSum)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "لقد تجاوزت حمولة الشحن القصوى للشاحنة المحددة";
                return false;
            }
            else if (Count == carSum)
            {
                // driver is busy now
                ShipUsers myuser = new ShipUsers();
                myuser.ID = ddlDriver.SelectedValue;
                myuser.Online = 2;

                if (myuser.updateOnline(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "حدث خطأ اثناء تحديث حالة السائق";
                }

            }
            return true;
            // *********************** edited by hanan3 : to here
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid)
                {
                    if (!ValidateInv()) return;

                    /*  if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                      {
                          if (DateTime.Parse(txtGDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                          {
                              LblCodesResult.ForeColor = System.Drawing.Color.Red;
                              LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                              ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                              return;
                          }
                      } */

                    TripCollect mytrip = new TripCollect();
                    mytrip.Branch = short.Parse(Session["Branch"].ToString());
                    mytrip.VouLoc = AreaNo;
                    mytrip.Number = int.Parse(txtNumber.Text);
                    mytrip.FNo = 1;
                    mytrip = mytrip.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (mytrip == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم البيان غير معرف من قبل";

                    }
                    else
                    {
                        mytrip = new TripCollect();
                        mytrip.Branch = short.Parse(Session["Branch"].ToString());
                        mytrip.VouLoc = AreaNo;
                        mytrip.Number = int.Parse(txtNumber.Text);
                        if (mytrip.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            mytrip = new TripCollect();
                            mytrip.Branch = short.Parse(Session["Branch"].ToString());
                            mytrip.VouLoc = AreaNo;
                            mytrip.Number = int.Parse(txtNumber.Text);
                            mytrip.DriverCode = ddlDriver.SelectedValue;
                            mytrip.CarCode = ddlCar.SelectedValue;
                            mytrip.ToLoc = ddlFrom.SelectedValue; // point of collecting
                            mytrip.HDate = txtHDate.Text;
                            mytrip.GDate = txtGDate.Text;
                            mytrip.UserName = txtUserName.ToolTip;
                            mytrip.UserDate = txtUserDate.Text;
                            mytrip.FTime = LblFTime.Text;
                            mytrip.Rent = ChkRent.Checked;
                            mytrip.RentPlateNo = "";
                            mytrip.RentValue = 0;
                            mytrip.RentDriver = txtRentDriver.Text;
                            mytrip.RentMobileNo = txtRentMobileNo.Text;
                            // edited by hanan (delete line )

                            int r = 0;
                            int FNo = 1;
                            bool Add = true;
                            foreach (GridViewRow gvr in grdCodes.Rows)
                            {
                                CheckBox ChkStatus = gvr.FindControl("ChkStatus") as CheckBox;
                                Label lblvouNo = gvr.FindControl("lblVouNo") as Label;
                                Label lblvouloc = gvr.FindControl("lblVouLoc") as Label;
                                Label lblLoading = gvr.FindControl("lblLoadingCode") as Label;
                                Label lbltype = gvr.FindControl("lblshiptype") as Label;

                                if (ChkStatus.Checked)
                                {
                                    mytrip.FNo = (short)FNo;
                                    mytrip.InvoiceNo = VouData[r].VouNo; // int.Parse(lblvouNo.Text);
                                    mytrip.InvoiceLocNo = short.Parse(VouData[r].VouLoc); // short.Parse(lblvouloc.Text);
                                    mytrip.InvoiceFNo = VouData[r].InvoiceFNo;
                                    mytrip.FromLoc = VouData[r].PlaceofLoading; // lblLoading.Text; // place of customer invoice
                                    mytrip.ShipType = VouData[r].Flag; //lbltype.Text;
                                    mytrip.FTime = LblFTime.Text;
                                    mytrip.DTPickUp = VouData[r].DTPickUp; // lblLoading.Text; // place of customer invoice
                                    mytrip.DTDropOff = VouData[r].DTDropOff; //lbltype.Text;
                                    mytrip.Status = (short)VouData[r].myStatus; // edited by hanan

                                    Add = mytrip.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    FNo++;
                                }
                                r++;
                            }

                            if (FNo == 1)
                            {
                                mytrip.FNo = (short)FNo;
                                mytrip.InvoiceNo = 0;
                                mytrip.InvoiceLocNo = 0;
                                mytrip.InvoiceFNo = 0;
                                mytrip.FromLoc = ""; // place of customer invoice
                                mytrip.ShipType = "";
                                mytrip.FTime = LblFTime.Text;
                                mytrip.DTPickUp = ""; // lblLoading.Text; // place of customer invoice
                                mytrip.DTDropOff = ""; //lbltype.Text;
                                Add = mytrip.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }

                            if (Add)
                            {

                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تمت تحديث البيانات بنجاح";
                                BtnNew.Enabled = true;
                                BtnClear_Click(sender, e);
                            }
                            else
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء تحديث بيان التجميع ... حاول مرة أخرى";
                                BtnNew.Enabled = true;

                            }
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ أثناء تحديث بيان التجميع ... حاول مرة أخرى";
                            BtnNew.Enabled = true;

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

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                //  NewMode();

                Cities myCity = new Cities();

                myCity.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                ddlFrom.DataTextField = "Name1";
                ddlFrom.DataValueField = "Code";
                ddlFrom.DataSource = (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()]);
                ddlFrom.DataBind();
                ddlFrom.Items.Insert(0, new ListItem("-- أختر منطقة التجميع --", "-1", true));

                CarsType mytype = new CarsType();

                mytype.Branch = short.Parse(Session["Branch"].ToString());
                ddlType.DataTextField = "Name1";
                ddlType.DataValueField = "Code";
                ddlType.DataSource = mytype.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                ddlType.DataBind();
                ddlType.Items.Insert(0, new ListItem("-- أختر نوع الناقلة --", "-1", true));

                txtSearch.Text = "";
                txtReason.Text = "";
                txtNumber.Text = "";
                DateTime localDate = DateTime.Now;
                txtGDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                txtHDate.Text = HDate.getNow();
                LblFTime.Text = String.Format("{0:HH:mm:ss}", moh.Nows());
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                ddlFrom.SelectedIndex = 0;
                //    ddlDriver.SelectedIndex = 0; // edited by hanan8
                //     ddlCar.SelectedIndex = 0; // edited by hanan8
                ddlDriver.DataSource = null;
                ddlDriver.DataBind();
                ddlCar.DataSource = null;
                ddlCar.DataBind();
                ChkStatus.Checked = false;
                for (int i = 0; i < ChkInvType.Items.Count; i++)
                {
                    ChkInvType.Items[i].Selected = false;
                }
                //     CarAlert.Visible = false;
                //     ChkNoCost.Checked = false;
                txtRentMobileNo.Text = "";
                txtRentDriver.Text = "";
                ChkRent.Checked = false;
                ChkAll.Checked = false; // edited by hanan5
                //   ChkRent_CheckedChanged(sender, e);
                VouData.Clear();
                //       grdCodes.DataSource = null;
                //       grdCodes.DataBind();

                TripCollect mytrip = new TripCollect();
                mytrip.Branch = short.Parse(Session["Branch"].ToString());
                mytrip.VouLoc = AreaNo;
                int? myid = mytrip.GetMax(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myid == 0 || myid == null)
                {
                    myid = 1;
                }
                else
                {
                    myid++;
                }

                txtNumber.Text = myid.ToString();
                LoadVouData();
                //       LoadAttachData();
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

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid)
                {
                    /*  if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                      {
                          if (DateTime.Parse(txtGDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                          {
                              LblCodesResult.ForeColor = System.Drawing.Color.Red;
                              LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                              ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                              return;
                          }
                      } */

                    TripCollect mytrip = new TripCollect();
                    mytrip.Branch = short.Parse(Session["Branch"].ToString());
                    mytrip.VouLoc = AreaNo;
                    mytrip.Number = int.Parse(txtNumber.Text);
                    mytrip.FNo = 1;
                    mytrip = mytrip.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (mytrip == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم بيان الحركة غير معرف من قبل";

                    }
                    else
                    {
                        mytrip = new TripCollect();
                        mytrip.Branch = short.Parse(Session["Branch"].ToString());
                        mytrip.VouLoc = AreaNo;
                        mytrip.Number = int.Parse(txtNumber.Text);

                        if (mytrip.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            txtReason.Text = "";

                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم الغاء البيانات بنجاح";

                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ أثناء الغاء البيانات ... حاول مرة أخرى";

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

        protected void BtnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void BtnPrint_Click(object sender, EventArgs e)
        {

        }

        public void PrintMe(String Number)
        {
            // if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان ترحيل", "طباعة", "طباعة بيان الترحيل رقم " + int.Parse(AreaNo).ToString() + "/" + Number, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=1&AreaNo=" + AreaNo + "&Number=" + Number + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
            return;
        }

        protected void BtnFind_Click(object sender, EventArgs e)
        {
            string vSearch = txtSearch.Text;
            BtnClear_Click(sender, e);
            txtSearch.Text = vSearch;

            TripCollect mytrip = new TripCollect();
            TripCollect mytrip2 = new TripCollect();

            ChkAll.Checked = false; // edited by hanan5

            mytrip.Branch = short.Parse(Session["Branch"].ToString());
            mytrip.VouLoc = AreaNo;
            mytrip.Number = int.Parse(txtSearch.Text);
            mytrip.FNo = 1;
            mytrip2.Branch = short.Parse(Session["Branch"].ToString());
            mytrip2.VouLoc = AreaNo;
            mytrip2.Number = int.Parse(txtSearch.Text);
            mytrip = mytrip.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (mytrip == null)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "رقم البيان غير معرف من قبل";
            }
            else
            {
                lblBranch.Text = int.Parse(mytrip.VouLoc).ToString();
                txtNumber.Text = mytrip.Number.ToString();
                //     if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان ترحيل", "عرض", "عرض بيان الترحيل رقم " + lblBranch.Text + "/" + txtNumber.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                //     EditMode();
                //      GetInv(mytrip);
                //GetcarDetails(mytrip.DriverCode, sender, e); // edited by hanan5
                //      ddlDriver.SelectedValue = mytrip.DriverCode;
                //  ddlCar.SelectedValue = mytrip.CarCode;
                //ddlFrom.SelectedValue = mytrip.ToLoc; // point of collecting
                txtHDate.Text = mytrip.HDate;
                txtGDate.Text = mytrip.GDate;
                txtUserName.Text = mytrip.UserName;
                txtUserDate.Text = mytrip.UserDate;
                LblFTime.Text = mytrip.FTime;
                ddlDriver.SelectedValue = mytrip.DriverCode;
                //ChkRent.Checked = (bool)mytrip.Rent;
                // mytrip.RentPlateNo = "";
                //  mytrip.RentValue = 0;
                //txtRentMobileNo.Text = mytrip.RentMobileNo;
                ChkStatus.Checked  = (mytrip.Status != (short)99);
                VouData = mytrip.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                /*         int i = 0; // edited by hanan
                         foreach (myInv2 itm in VouData)
                         {
                             if (itm.Flag == "")
                             {
                                 Invoice mylnv = new Invoice();
                                 mylnv.Branch = itm.Branch;
                                 if (int.Parse(itm.VouLoc) < 10)
                                     mylnv.VouLoc = "0000" + itm.VouLoc;
                                 else
                                     mylnv.VouLoc = "000" + itm.VouLoc;
                                 mylnv.VouNo = itm.VouNo;
                                 mylnv = mylnv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                 VouData[i].Name = mylnv.Name;
                                 VouData[i].FTime = mylnv.FTime;
                                 VouData[i].GDate = mylnv.GDate;


                             }
                             else if (itm.Flag == "L")
                             {
                                 LShipment mylsh = new LShipment();
                                 mylsh.Branch = itm.Branch;
                                 if (int.Parse(itm.VouLoc) < 10)
                                     mylsh.VouLoc = "0000" + itm.VouLoc;
                                 else
                                     mylsh.VouLoc = "000" + itm.VouLoc;
                                 mylsh.VouNo = itm.VouNo;
                                 mylsh = mylsh.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                 VouData[i].Name = mylsh.Name;
                                 VouData[i].FTime = mylsh.FTime;
                                 VouData[i].GDate = mylsh.GDate;
                             }
                             if (itm.Flag == "E")
                             {
                                 Shipment myship = new Shipment();
                                 myship.Branch = itm.Branch;
                                 if(int.Parse(itm.VouLoc)<10)
                                 myship.VouLoc = "0000" +itm.VouLoc;
                                 else
                                 myship.VouLoc = "000" +itm.VouLoc;
                                 myship.VouNo = itm.VouNo;
                                 myship = myship.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                 VouData[i].Name = myship.Name;
                                 VouData[i].FTime = myship.FTime;
                                 VouData[i].GDate = myship.GDate;
                             }
                             i++;
                         } */
                LoadVouData();
                //   grdCodes.DataSource = mytrip2.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                //    grdCodes.DataBind();
            }

        }


        public void GetcarDetails(string drcode, object sender, EventArgs e)
        {
            // edited by hanan5 : from here
            Cars mycars = new Cars();

            mycars.Branch = short.Parse(Session["Branch"].ToString());
            if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), mycars.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            mycars.DriverCode = drcode;
            if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), mycars.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            mycars = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                      where sitm.DriverCode == mycars.DriverCode && (bool)sitm.Status
                      select sitm).FirstOrDefault();

            if (mycars != null && ddlType.Items.Count != 0) // edited by hanan8
            {
                ddlType.SelectedValue = mycars.CarsType.ToString();

                ddlType_SelectedIndexChanged(sender, e);

                if (ddlDriver.DataSource != null && ddlCar.DataSource != null)
                {
                    ddlDriver.SelectedValue = drcode;
                    ddlCar.SelectedValue = ddlDriver.SelectedValue;

                    Drivers myDr = new Drivers();

                    myDr.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDr.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myDr.Code = drcode;
                    myDr = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                            where sitm.Code == myDr.Code
                            select sitm).FirstOrDefault();
                    if (myDr != null) // edited by hanan8
                        txtRentDriver.Text = myDr.Name2;
                }
            }

            // edited by hanan5 : to here

        }

        protected string UrlHelper(object Number, object LocNumber, object Flag)
        {
            if (Flag.ToString() == "E") return "~/WebShipment.aspx?Flag=0&FNum=" + Number.ToString() + "&AreaNo=" + moh.MakeMask(LocNumber.ToString(), 5);
            else return "~/WebInvoice.aspx?Flag=0&FNum=" + Number.ToString() + "&AreaNo=" + moh.MakeMask(LocNumber.ToString(), 5);
        }


        protected void ChkRent_CheckedChanged(object sender, EventArgs e)
        {

            // edited by hanan2
            if (ChkRent.Checked == true)
            {
                CoDrivers mydr = new CoDrivers();

                ddlType.Items.Clear();
                ddlType.DataSource = null;
                ddlType.DataBind();

                ddlType.Items.Add(new ListItem("-- أختر نوع الناقلة --", "-1"));
                ddlType.Items.Add(new ListItem("سيارة صغيرة", "1"));
                ddlType.Items.Add(new ListItem("سطحة", "2"));
                ddlType.Items.Add(new ListItem("شاحنة رأس تريلا", "3"));

                ddlCar.Items.Clear();
                ddlCar.DataSource = null;
                ddlCar.DataBind();

                //ddlDriver.Items.Clear();
                //ddlDriver.DataSource = null;
                //ddlDriver.DataBind();
            }
            else
            {
                CarsType mytype = new CarsType();

                mytype.Branch = short.Parse(Session["Branch"].ToString());
                ddlType.DataTextField = "Name1";
                ddlType.DataValueField = "Code";
                ddlType.DataSource = mytype.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                ddlType.DataBind();
                ddlType.Items.Insert(0, new ListItem("-- أختر نوع الناقلة --", "-1", true));

                txtRentDriver.Text = "";
                ddlCar.Items.Clear();
                ddlCar.DataSource = null;
                ddlCar.DataBind();

                //ddlDriver.Items.Clear();
                //ddlDriver.DataSource = null;
                //ddlDriver.DataBind();
            }

        }

        // edited by hanan ( adding method )
        public string getStatus(int id)
        {
            string mycurrent = "";

            if (id == 0)
                mycurrent = "لم تبدأ بعد";
            else if (id == 1)
                mycurrent = "في الطريق";
            else if (id == 5)
                mycurrent = "تم التسليم";
            else if (id == 6)
                mycurrent = "وصلت للفرع";

            return mycurrent;
        }


        // edited by hanan5
        protected void ChkAll_CheckedChanged(object sender, EventArgs e)
        {

            if (ChkRent.Checked != true)
            {
                if (ChkAll.Checked != true)
                {
                    ddlType_SelectedIndexChanged(sender, e);
                }
                else
                {
                    List<TrackMove> CarData1 = new List<TrackMove>();
                    List<TrackMove> CarData2 = new List<TrackMove>();

                    string mytype = ddlType.SelectedValue;
                    if (int.Parse(mytype) < 10)
                        mytype = "0" + mytype;

                    ddlCar.DataTextField = "PlateNo";
                    ddlCar.DataValueField = "DriverCode";

                    CarData1 = (List<TrackMove>)(HttpRuntime.Cache["OverTrack2_" + Session["AreaNo"].ToString() + Session["CNN2"].ToString()]);


                    if (CarData1 != null)
                    {
                        CarData2 = (from itm in CarData1
                                    where (itm.Code.StartsWith(mytype))
                                    select itm).ToList();
                        ddlCar.DataSource = CarData2;
                        ddlCar.DataBind();
                        ddlCar.Items.Insert(0, new ListItem("-- أختر الناقلة --", "-1", true));

                        /*
                        ddlDriver.DataValueField = "DriverCode";
                        ddlDriver.DataTextField = "DriverCode";
                        ddlDriver.DataSource = CarData2;
                        ddlDriver.DataBind();
                        ddlDriver.Items.Insert(0, new ListItem(" -- إختر السائق", "-1", true));
                         */
                    }
                }
            }
        }

        protected void ChkStatus_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                    TripCollect mytrip = new TripCollect();
                    mytrip.Branch = short.Parse(Session["Branch"].ToString());
                    mytrip.VouLoc = AreaNo;
                    mytrip.Number = int.Parse(txtNumber.Text);
                    mytrip.FNo = 1;
                    mytrip = mytrip.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    if (mytrip == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "بيان التجميع غير موجود من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);                        
                        return;
                    }
                    else
                    { 
                        mytrip = new TripCollect();
                        mytrip.Branch = short.Parse(Session["Branch"].ToString());
                        mytrip.VouLoc = AreaNo;
                        mytrip.Number = int.Parse(txtNumber.Text);
                        mytrip.Status = (short)(ChkStatus.Checked ? 0 : 99);
                        mytrip.UserName = txtUserName.ToolTip;
                        mytrip.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        mytrip.UpdateStatus(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        mytrip = new TripCollect();
                        mytrip.Branch = short.Parse(Session["Branch"].ToString());
                        mytrip.VouLoc = AreaNo;
                        mytrip.Number = int.Parse(txtNumber.Text);
                        foreach(TripCollect itm in mytrip.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {

                            if (itm.ShipType != "E")
                            {
                                Invoice myShip = new Invoice();
                                myShip.Branch = 1;
                                myShip.VouLoc = moh.MakeMask(itm.InvoiceLocNo.ToString(),5);
                                myShip.VouNo = (int)itm.InvoiceNo;
                                myShip.Status = (short)(ChkStatus.Checked ? 81 : 80);
                                myShip.StatusUpdate(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }
                            else
                            {
                                Shipment myShip = new Shipment();
                                myShip.Branch = 1;
                                myShip.VouLoc = moh.MakeMask(itm.InvoiceLocNo.ToString(),5);
                                myShip.VouNo = (int)itm.InvoiceNo;
                                myShip.Status = (short)(ChkStatus.Checked ? 81 : 80);
                                myShip.StatusUpdate(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }                        
                        }

                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                        
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

    }

}
