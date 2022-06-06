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
using System.Net;
using System.Web.Script.Serialization;
using System.Text;

namespace ACC
{
    public partial class WebTripDelivery : System.Web.UI.Page
    {
        public List<vCarRcvSite> VouData
        {
            get
            {
                if (ViewState["VouData"] == null)
                {
                    ViewState["VouData"] = new List<vCarRcvSite>();
                }
                return (List<vCarRcvSite>)ViewState["VouData"];
            }
            set
            {
                ViewState["VouData"] = value;

            }
        }

        public bool ShipCar
        {
            get
            {
                if (ViewState["ShipCar"] == null)
                {
                    ViewState["ShipCar"] = false;
                }
                return (bool)ViewState["ShipCar"];
            }
            set { ViewState["ShipCar"] = value; }
        }

        public bool ShipExpress
        {
            get
            {
                if (ViewState["ShipExpress"] == null)
                {
                    ViewState["ShipExpress"] = false;
                }
                return (bool)ViewState["ShipExpress"];
            }
            set { ViewState["ShipExpress"] = value; }
        }

        public string AreaNo
        {
            get
            {
                if (ViewState["AreaNo"] == null)
                {
                    ViewState["AreaNo"] = "00018";
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

            // if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass212 || !BtnEdit.Visible) ControlsOnOff(true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Cities myCity = new Cities();
                    this.Page.Header.Title = "بيان التوزيع";         
                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "الرئيسية", "اختيار", "اختيار بيان التوزيع", "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

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
                    //   BtnSearch.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass214;
                        BtnPrint.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass215;
                        BtnFind.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass214;
                    } 

                    lblBranch.Text = "/" + short.Parse(AreaNo).ToString();
                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlFrom.DataTextField = "Name1";
                    ddlFrom.DataValueField = "Code"; // edited by hanan
                    ddlFrom.DataSource = (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()]);
                    ddlFrom.DataBind();
                    ddlFrom.Items.Insert(0, new ListItem("-- أختر منطقة التوزيع --", "-1", true));

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

                    /*       if (Request.QueryString["FNum"] != null)
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
                               { */
                    BtnClear_Click(sender, null);
                    /*        if (Request.QueryString["Dest1"] != null)
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
                            } */
                    // }
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
                grdCodes.DataSource = VouData;
                grdCodes.DataBind();
    

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
            //     mytrip.RentValue = moh.StrToDouble(txtRentValue.Text);
            //     mytrip.RentPlateNo = txtRentPlateNo.Text;
        }


        public void GetInv(TripCollect mytrip)
        {
            if (ddlDriver.Items.FindByValue(mytrip.DriverCode) != null) ddlDriver.SelectedValue = mytrip.DriverCode;
            /*
            else
            {
                Drivers myDrive = new Drivers();
                myDrive.Branch = short.Parse(Session["Branch"].ToString());
                myDrive.Code = mytrip.DriverCode;
                myDrive = myDrive.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myDrive != null)
                {
                    ddlDriver.Items.Add(new ListItem(myDrive.Name1, myDrive.Code));
                    ddlDriver.SelectedValue = mytrip.DriverCode;
                }
            }
             */
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
            //       txtRentValue.Text = mytrip.RentValue.ToString();
            //      txtRentPlateNo.Text = mytrip.RentPlateNo;
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
            }
        }

        protected void ChkInvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            VouData.Clear();
            /*
            if (!ChkInvType.Items[0].Selected && ShipCar)
            {
                ShipCar = false;
                VouData.Clear();
            }
            if (!ChkInvType.Items[1].Selected && ShipExpress)
            {
                ShipExpress = false;
                VouData.Clear();
            }
             */


            vCarRcvSite xSite = new vCarRcvSite();
            xSite.RCVLocNumber = short.Parse(AreaNo);
            if (ChkInvType.Items[0].Selected)
            {
                ShipCar = true;
                VouData.AddRange(xSite.Get0(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            }
            if (ChkInvType.Items[1].Selected)
            {
                ShipExpress = true;
                VouData.AddRange(xSite.GetE0(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            }
            LoadVouData();
        }

        public string getCity(int id)
        {
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

            txtGDate.ReadOnly = !State;
            txtHDate.ReadOnly = !State;
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
            //   txtRentValue.ReadOnly = !State;
            //   txtRentPlateNo.ReadOnly = !State;
        }

        protected void BtnNew_Click(object sender, EventArgs e)
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
                    //if (!ValidateInv())
                   // {
                   //     BtnNew.Enabled = true;
                    //    return;
                   // }
                    TripDelivery mytrip = new TripDelivery();
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
                            LblCodesResult.Text = "بيان التوزيع موجود مسبقا";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            BtnNew.Enabled = true;
                            return;
                        }
                        else
                        {
                            mytrip = new TripDelivery();
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
                                    
                    int r = 0;
                    int FNo = 1;
                    bool Add = false;
                    foreach (GridViewRow gvr in grdCodes.Rows)
                    {
                        CheckBox ChkStatus = gvr.FindControl("ChkStatus") as CheckBox;
                        if (ChkStatus.Checked)
                        {
                            mytrip = new TripDelivery();
                            mytrip.Branch = short.Parse(Session["Branch"].ToString());
                            mytrip.VouLoc = AreaNo;
                            mytrip.Number = int.Parse(txtNumber.Text);
                            mytrip.DriverCode = ddlDriver.SelectedValue;
                            mytrip.CarCode = ddlCar.SelectedValue;
                            mytrip.FromLoc = ddlFrom.SelectedValue; // point of collecting
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
                            mytrip.FNo = (short)FNo;
                            mytrip.InvoiceNo = VouData[r].VouNo; // int.Parse(lblvouNo.Text);
                            mytrip.InvoiceLocNo = short.Parse(VouData[r].VouLoc); // short.Parse(lblvouloc.Text);
                            mytrip.InvoiceFNo = VouData[r].InvoiceFNo;
                            //mytrip.ToLoc = VouData[r].PlaceofLoading; // place of customer invoice  // edited by hanan
                            mytrip.ShipType = VouData[r].Flag; //lbltype.Text;
                            //mytrip.FTime = LblFTime.Text;
                            mytrip.DTPickUp = ""; // lblLoading.Text; // place of customer invoice
                            mytrip.DTDropOff = ""; //lbltype.Text;
                            //mytrip.Status = (short)VouData[r].myStatus; // edited by hanan

                            Add = mytrip.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            FNo++;

                            OrderTran vTran = new OrderTran();
                            vTran.IDDriver = ddlDriver.SelectedValue;
                            vTran.OrderType = (short)(VouData[r].Flag == "E" ? 2 : 1);
                            vTran.VouLoc = moh.MakeMask(VouData[r].VouLoc,5);
                            vTran.VouNo = (int)VouData[r].VouNo;
                            vTran.Steps = 9;
                            if(vTran.Find(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString) == null)
                            {
                                vTran.Accept = true;
                                vTran.AcceptDateTime = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                                vTran.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                if (VouData[r].Flag != "E")
                                {
                                    Invoice myShip = new Invoice();
                                    myShip.Branch = 1;
                                    myShip.VouLoc = moh.MakeMask(VouData[r].VouLoc,5);
                                    myShip.VouNo = (int)VouData[r].VouNo;
                                    myShip.Status = 10;
                                    myShip.StatusUpdate(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                }
                                else
                                {
                                    Shipment myShip = new Shipment();
                                    myShip.Branch = 1;
                                    myShip.VouLoc = moh.MakeMask(VouData[r].VouLoc,5);
                                    myShip.VouNo = (int)VouData[r].VouNo;
                                    myShip.Status = 10;
                                    myShip.StatusUpdate(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                }
                            }

                            // Post Jv



                        }
                        r++;
                    }

                    if (FNo == 1)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يحب أختيار شحنة من الشحنات";
                        BtnNew.Enabled = true;
                    }
                    else
                    {
                        if (Add)
                        {
                            var request = WebRequest.Create("http://Naqelat.net/WebServicesJSON.asmx/SendDriverNotification") as HttpWebRequest;
                            request.KeepAlive = true;
                            request.Method = "POST";
                            request.ContentType = "application/json; charset=utf-8";
                            request.Headers.Add("Username", "TWEGA");
                            request.Headers.Add("Password", "N0555899111@2020");
                             
                            var serializer = new JavaScriptSerializer();
                            var obj = new
                            {
                                MobileNo = ddlDriver.SelectedValue,
                                StartDate = "لقد تم أدراج بيان التوزيع رقم " + int.Parse(AreaNo).ToString()+"/"+txtNumber.Text
                            };
 
                            var param = serializer.Serialize(obj);
                            byte[] byteArray = Encoding.UTF8.GetBytes(param);
                            string responseContent = null;
 
                            try
                            {
                                using (var writer = request.GetRequestStream())
                                {
                                    writer.Write(byteArray, 0, byteArray.Length);
                                }
 
                                using (var response = request.GetResponse() as HttpWebResponse)
                                {
                                    using (var reader = new StreamReader(response.GetResponseStream()))
                                    {
                                        responseContent = reader.ReadToEnd();
                                    }
                                }
                            }
                            catch { }
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                            BtnNew.Enabled = true;
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ أثناء إنشاء بيان التوزيع ... حاول مرة أخرى";
                            BtnNew.Enabled = true;
                        }
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

            if (txtRentDriver.Text == "")
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يجب أدخال السائق";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }

            int Count = 0;
            //int carSum = 0;
            foreach (GridViewRow gvr in grdCodes.Rows)
            {
                CheckBox ChkStatus = gvr.FindControl("ChkStatus") as CheckBox;
                Label lbltype = gvr.FindControl("lblshiptype") as Label;
                if (ChkStatus.Checked)
                {
                    if (lbltype.Text == "c")
                    {
                        if (ddlType.SelectedIndex == (ddlType.Items.Count - 1))
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

            if (Count > 2)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "لقد تجاوزت حمولة الشحن القصوى وهي سيارتان";
                return false;
            }
            return true;
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid)
                {
                   // if (!ValidateInv()) return;

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

                    TripDelivery mytrip = new TripDelivery();
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
                        bool vPass = true;
                        List<vCarRcvSite> lcar = new List<vCarRcvSite>();
                        lcar = mytrip.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        foreach (vCarRcvSite itm in lcar)
                        {
                            OrderTran vTran = new OrderTran();
                            vTran.IDDriver = itm.DriverCode;
                            vTran.OrderType = (short)(itm.Flag == "E" ? 2 : 1);
                            vTran.VouLoc = moh.MakeMask(itm.VouLoc,5);
                            vTran.VouNo = (int)itm.VouNo;
                            vTran.Steps = 9;
                            vTran = vTran.Find(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString);
                            if (vTran != null)
                            {
                                if (!string.IsNullOrEmpty(vTran.Completed) || !string.IsNullOrEmpty(vTran.EndDateTime) || !string.IsNullOrEmpty(vTran.Delivered))
                                {
                                    vPass = false;
                                    break;
                                }
                            }
                        }
                        if (!vPass)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لا يمكن تعديل البيان لوجود متابعة للسائق على البيان";
                        }
                        else
                        {
                            if (mytrip.DriverCode != ddlDriver.SelectedValue)
                            {
                                var request = WebRequest.Create("http://Naqelat.net/WebServicesJSON.asmx/SendDriverNotification") as HttpWebRequest;
                                request.KeepAlive = true;
                                request.Method = "POST";
                                request.ContentType = "application/json; charset=utf-8";
                                request.Headers.Add("Username", "TWEGA");
                                request.Headers.Add("Password", "N0555899111@2020");

                                var serializer = new JavaScriptSerializer();
                                var obj = new
                                {
                                    MobileNo = mytrip.DriverCode,
                                    StartDate = "لقد تم الغاء بيان التوزيع رقم " + int.Parse(AreaNo).ToString() + "/" + txtNumber.Text
                                };

                                var param = serializer.Serialize(obj);
                                byte[] byteArray = Encoding.UTF8.GetBytes(param);
                                string responseContent = null;

                                try
                                {
                                    using (var writer = request.GetRequestStream())
                                    {
                                        writer.Write(byteArray, 0, byteArray.Length);
                                    }

                                    using (var response = request.GetResponse() as HttpWebResponse)
                                    {
                                        using (var reader = new StreamReader(response.GetResponseStream()))
                                        {
                                            responseContent = reader.ReadToEnd();
                                        }
                                    }
                                }
                                catch { }
                            }
                            mytrip = new TripDelivery();
                            mytrip.Branch = short.Parse(Session["Branch"].ToString());
                            mytrip.VouLoc = AreaNo;
                            mytrip.Number = int.Parse(txtNumber.Text);
                            
                            if (mytrip.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                foreach (vCarRcvSite itm in lcar)
                                {
                                    OrderTran vTran = new OrderTran();
                                    vTran.IDDriver = itm.DriverCode;
                                    vTran.OrderType = (short)(itm.Flag == "E" ? 2 : 1);
                                    vTran.VouLoc = moh.MakeMask(itm.VouLoc,5);
                                    vTran.VouNo = (int)itm.VouNo;
                                    vTran.Steps = 9;
                                    vTran.Delete(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString);

                                    if (itm.Flag != "E")
                                    {
                                        Invoice myShip = new Invoice();
                                        myShip.Branch = 1;
                                        myShip.VouLoc = moh.MakeMask(itm.VouLoc,5);
                                        myShip.VouNo = (int)itm.VouNo;
                                        myShip.Status = 81;
                                        myShip.StatusUpdate(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    }
                                    else
                                    {
                                        Shipment myShip = new Shipment();
                                        myShip.Branch = 1;
                                        myShip.VouLoc = moh.MakeMask(itm.VouLoc,5);
                                        myShip.VouNo = (int)itm.VouNo;
                                        myShip.Status = 81;
                                        myShip.StatusUpdate(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    }

                                }
                            }

                            int r = 0;
                            int FNo = 1;
                            bool Add = false;
                            foreach (GridViewRow gvr in grdCodes.Rows)
                            {
                                CheckBox ChkStatus = gvr.FindControl("ChkStatus") as CheckBox;
                                if (ChkStatus.Checked)
                                {
                                    mytrip = new TripDelivery();
                                    mytrip.Branch = short.Parse(Session["Branch"].ToString());
                                    mytrip.VouLoc = AreaNo;
                                    mytrip.Number = int.Parse(txtNumber.Text);
                                    mytrip.DriverCode = ddlDriver.SelectedValue;
                                    mytrip.CarCode = ddlCar.SelectedValue;
                                    mytrip.FromLoc = ddlFrom.SelectedValue; // point of collecting
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
                                    mytrip.FNo = (short)FNo;
                                    mytrip.InvoiceNo = VouData[r].VouNo; // int.Parse(lblvouNo.Text);
                                    mytrip.InvoiceLocNo = short.Parse(VouData[r].VouLoc); // short.Parse(lblvouloc.Text);
                                    mytrip.InvoiceFNo = VouData[r].InvoiceFNo;
                                    //mytrip.ToLoc = VouData[r].PlaceofLoading; // place of customer invoice  // edited by hanan
                                    mytrip.ShipType = VouData[r].Flag; //lbltype.Text;
                                    //mytrip.FTime = LblFTime.Text;
                                    mytrip.DTPickUp = ""; // lblLoading.Text; // place of customer invoice
                                    mytrip.DTDropOff = ""; //lbltype.Text;
                                    //mytrip.Status = (short)VouData[r].myStatus; // edited by hanan

                                    Add = mytrip.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    FNo++;

                                    OrderTran vTran = new OrderTran();
                                    vTran.IDDriver = ddlDriver.SelectedValue;
                                    vTran.OrderType = (short)(VouData[r].Flag == "E" ? 2 : 1);
                                    vTran.VouLoc = moh.MakeMask(VouData[r].VouLoc,5);
                                    vTran.VouNo = (int)VouData[r].VouNo;
                                    vTran.Steps = 9;
                                    if(vTran.Find(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString) == null)
                                    {
                                        vTran.Accept = true;
                                        vTran.AcceptDateTime = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                                        vTran.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                        if (VouData[r].Flag != "E")
                                        {
                                            Invoice myShip = new Invoice();
                                            myShip.Branch = 1;
                                            myShip.VouLoc = moh.MakeMask(VouData[r].VouLoc,5);
                                            myShip.VouNo = (int)VouData[r].VouNo;
                                            myShip.Status = 10;
                                            myShip.StatusUpdate(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        }
                                        else
                                        {
                                            Shipment myShip = new Shipment();
                                            myShip.Branch = 1;
                                            myShip.VouLoc = moh.MakeMask(VouData[r].VouLoc,5);
                                            myShip.VouNo = (int)VouData[r].VouNo;
                                            myShip.Status = 10;
                                            myShip.StatusUpdate(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        }
                                    }
                                }
                                r++;
                            }
                            if (Add)
                            {
                                var request = WebRequest.Create("http://Naqelat.net/WebServicesJSON.asmx/SendDriverNotification") as HttpWebRequest;
                                request.KeepAlive = true;
                                request.Method = "POST";
                                request.ContentType = "application/json; charset=utf-8";
                                request.Headers.Add("Username", "TWEGA");
                                request.Headers.Add("Password", "N0555899111@2020");

                                var serializer = new JavaScriptSerializer();
                                var obj = new
                                {
                                    MobileNo = ddlDriver.SelectedValue,
                                    StartDate = "لقد تم تعديل بيان التوزيع رقم " + int.Parse(AreaNo).ToString() + "/" + txtNumber.Text
                                };

                                var param = serializer.Serialize(obj);
                                byte[] byteArray = Encoding.UTF8.GetBytes(param);
                                string responseContent = null;

                                try
                                {
                                    using (var writer = request.GetRequestStream())
                                    {
                                        writer.Write(byteArray, 0, byteArray.Length);
                                    }

                                    using (var response = request.GetResponse() as HttpWebResponse)
                                    {
                                        using (var reader = new StreamReader(response.GetResponseStream()))
                                        {
                                            responseContent = reader.ReadToEnd();
                                        }
                                    }
                                }
                                catch { }

                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تمت تحديث البيانات بنجاح";
                                BtnNew.Enabled = true;
                                BtnClear_Click(sender, e);
                            }
                            else
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء تحديث بيان التوزيع ... حاول مرة أخرى";
                                BtnNew.Enabled = true;
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
                    Response.Redirect("GeneralServerError.aspx",false);
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
                ddlFrom.DataValueField = "Code"; // edited by hanan
                ddlFrom.DataSource = (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()]);
                ddlFrom.DataBind();
                ddlFrom.Items.Insert(0, new ListItem("-- أختر منطقة التوزيع --", "-1", true));
                
                CarsType mytype = new CarsType();

                mytype.Branch = short.Parse(Session["Branch"].ToString());
                ddlType.DataTextField = "Name1";
                ddlType.DataValueField = "Code";
                ddlType.DataSource = mytype.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                ddlType.DataBind();
                ddlType.Items.Insert(0, new ListItem("-- أختر نوع الناقلة --", "-1", true));

                ShipCar = false;
                ShipExpress = false;
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
                ddlCar.Items.Clear();
                ddlCar.DataSource = null;
                ddlCar.DataBind();

                /*
                ddlDriver.Items.Clear();
                ddlDriver.DataSource = null;
                ddlDriver.DataBind();
                 */

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
                TripDelivery mytrip = new TripDelivery();
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
                    Response.Redirect("GeneralServerError.aspx",false);
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

                    TripDelivery mytrip = new TripDelivery();
                    mytrip.Branch = short.Parse(Session["Branch"].ToString());
                    mytrip.VouLoc = AreaNo;
                    mytrip.Number = int.Parse(txtNumber.Text);
                    mytrip.FNo = 1;
                    mytrip = mytrip.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (mytrip == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم بيان التوزيع غير معرف من قبل";

                    }
                    else
                    {
                        bool vPass = true;
                        List<vCarRcvSite> lcar = new List<vCarRcvSite>();
                        lcar = mytrip.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        foreach (vCarRcvSite itm in lcar)
                        {
                            OrderTran vTran = new OrderTran();
                            vTran.IDDriver = itm.DriverCode;
                            vTran.OrderType = (short)(itm.Flag == "E" ? 2 : 1);
                            vTran.VouLoc = moh.MakeMask(itm.VouLoc,5);
                            vTran.VouNo = (int)itm.VouNo;
                            vTran.Steps = 9;
                            vTran = vTran.Find(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString);
                            if (vTran != null)
                            {
                                if (!string.IsNullOrEmpty(vTran.Completed) || !string.IsNullOrEmpty(vTran.EndDateTime) || !string.IsNullOrEmpty(vTran.Delivered))
                                {
                                    vPass = false;
                                    break;
                                }
                            }
                        }
                        if (!vPass)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لا يمكن الغاء البيان لوجود متابعة للسائق على البيان";
                        }
                        else
                        {
                            mytrip = new TripDelivery();
                            mytrip.Branch = short.Parse(Session["Branch"].ToString());
                            mytrip.VouLoc = AreaNo;
                            mytrip.Number = int.Parse(txtNumber.Text);

                            if (mytrip.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                foreach (vCarRcvSite itm in lcar)
                                {
                                    OrderTran vTran = new OrderTran();
                                    vTran.IDDriver = itm.DriverCode;
                                    vTran.OrderType = (short)(itm.Flag == "E" ? 2 : 1);
                                    vTran.VouLoc = moh.MakeMask(itm.VouLoc, 5);
                                    vTran.VouNo = (int)itm.VouNo;
                                    vTran.Steps = 9;
                                    vTran.Delete(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString);

                                    if (itm.Flag != "E")
                                    {
                                        Invoice myShip = new Invoice();
                                        myShip.Branch = 1;
                                        myShip.VouLoc = moh.MakeMask(itm.VouLoc, 5);
                                        myShip.VouNo = (int)itm.VouNo;
                                        myShip.Status = 81;
                                        myShip.StatusUpdate(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    }
                                    else
                                    {
                                        Shipment myShip = new Shipment();
                                        myShip.Branch = 1;
                                        myShip.VouLoc = moh.MakeMask(itm.VouLoc, 5);
                                        myShip.VouNo = (int)itm.VouNo;
                                        myShip.Status = 81;
                                        myShip.StatusUpdate(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    }

                                }

                                var request = WebRequest.Create("http://Naqelat.net/WebServicesJSON.asmx/SendDriverNotification") as HttpWebRequest;
                                request.KeepAlive = true;
                                request.Method = "POST";
                                request.ContentType = "application/json; charset=utf-8";
                                request.Headers.Add("Username", "TWEGA");
                                request.Headers.Add("Password", "N0555899111@2020");

                                var serializer = new JavaScriptSerializer();
                                var obj = new
                                {
                                    MobileNo = ddlDriver.SelectedValue,
                                    StartDate = "لقد تم الغاء بيان التوزيع رقم " + int.Parse(AreaNo).ToString() + "/" + txtNumber.Text
                                };

                                var param = serializer.Serialize(obj);
                                byte[] byteArray = Encoding.UTF8.GetBytes(param);
                                string responseContent = null;

                                try
                                {
                                    using (var writer = request.GetRequestStream())
                                    {
                                        writer.Write(byteArray, 0, byteArray.Length);
                                    }

                                    using (var response = request.GetResponse() as HttpWebResponse)
                                    {
                                        using (var reader = new StreamReader(response.GetResponseStream()))
                                        {
                                            responseContent = reader.ReadToEnd();
                                        }
                                    }
                                }
                                catch { }

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
            string vstr = txtSearch.Text;
            BtnClear_Click(sender, e);
            txtSearch.Text = vstr;
            TripDelivery mytrip = new TripDelivery();
            TripDelivery mytrip2 = new TripDelivery();

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
                // GetcarDetails(mytrip.DriverCode, sender, e); // edited by hanan5
                ddlDriver.SelectedValue = mytrip.DriverCode;
                //  ddlCar.SelectedValue = mytrip.CarCode;
                ddlFrom.SelectedValue = mytrip.FromLoc; // point of delivery
                txtHDate.Text = mytrip.HDate;
                txtGDate.Text = mytrip.GDate;
                txtUserName.Text = mytrip.UserName;
                txtUserDate.Text = mytrip.UserDate;
                LblFTime.Text = mytrip.FTime;
                ChkRent.Checked = (bool)mytrip.Rent;
                // mytrip.RentPlateNo = "";
                //  mytrip.RentValue = 0;
                txtRentMobileNo.Text = mytrip.RentMobileNo;
                VouData = mytrip2.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString); // edited by hanan
       
                LoadVouData();
         
            }

        }


        public void GetcarDetails(string drcode, object sender, EventArgs e) // edited by hanan5 : from here
        {
            Cars mycars = new Cars();

            mycars.Branch = short.Parse(Session["Branch"].ToString());
            mycars.DriverCode = drcode;
            if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), mycars.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            mycars = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                      where sitm.DriverCode == mycars.DriverCode && (bool)sitm.Status
                      select sitm).FirstOrDefault();
            ddlType.SelectedValue = mycars.CarsType.ToString();

            ddlType_SelectedIndexChanged(sender, e);

            ddlDriver.SelectedValue = drcode;
            ddlCar.SelectedValue = ddlDriver.SelectedValue;
          
            Drivers myDr = new Drivers();          
            myDr.Branch = short.Parse(Session["Branch"].ToString());
            if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDr.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            myDr.Code = drcode;
            myDr = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                    where sitm.Code == myDr.Code
                    select sitm).FirstOrDefault();
            txtRentDriver.Text = myDr.Name2;

            // edited by hanan5 : to here
        }

        protected string UrlHelper(object Number, object LocNumber,object Flag)
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

                /*
                ddlDriver.Items.Clear();
                ddlDriver.DataSource = null;
                ddlDriver.DataBind();
                 */
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

                /*
                ddlDriver.Items.Clear();
                ddlDriver.DataSource = null;
                ddlDriver.DataBind();
                 */
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


    }
}