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
    public partial class WebWater : System.Web.UI.Page
    {

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

        //     public string Lat1 { get; set; } // edited by hanan99
        //     public string Long1 { get; set; } // edited by hanan99

        public string Lat1  // edited by hanan99
        {
            get
            {
                if (ViewState["Lat1"] == null)
                {
                    ViewState["Lat1"] = "0";
                }
                return ViewState["Lat1"].ToString();
            }
            set { ViewState["Lat1"] = value; }
        }

        public string Long1 // edited by hanan99
        {
            get
            {
                if (ViewState["Long1"] == null)
                {
                    ViewState["Long1"] = "0";
                }
                return ViewState["Long1"].ToString();
            }
            set { ViewState["Long1"] = value; }
        }
   

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                //  ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttach);

                if (!Page.IsPostBack)
                {
                    Cities myCity = new Cities();
                    this.Page.Header.Title = "اتفاقية فاتورة مياه";

                    //    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "الرئيسية", "اختيار", "اختيار بيان الترحيل", "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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
                    /*       if (Session[vRoleName] == null)
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
                           } */

                    lblBranch.Text = "/" + short.Parse(AreaNo).ToString();

                    CarsType mytype = new CarsType();

                    mytype.Branch = short.Parse(Session["Branch"].ToString());
                    ddlType.DataTextField = "Name1";
                    ddlType.DataValueField = "Code";
                    ddlType.DataSource = mytype.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlType.DataBind();
                    ddlType.Items.Insert(0, new ListItem("-- أختر نوع الناقلة --", "-1", true));

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

                        if (Request.QueryString["AreaNo"] != null && Request.QueryString["InvNo"] != null) // related to WaterOnline invoice
                        {

                            WaterOnline mywater = new WaterOnline();
                            ShipUsers myuser = new ShipUsers();
                            mywater.Branch = short.Parse(Session["Branch"].ToString());
                            mywater.VouLoc = "1";
                            mywater.VouNo = int.Parse(Request.QueryString["InvNo"]);
                            mywater = mywater.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            if (mywater != null)
                            {
                                // txtNumber.Text = mywater.VouNo.ToString();
                                ddlusers.Enabled = false; // edited by hanan10
                                ddltype11.Enabled = false; // edited by hanan10
                                ddldetail.Enabled = false; // edited by hanan10
                                ddlcity.Enabled = false; // edited by hanan10

                                txtdesc.Text = mywater.Remark;
                                txtprice.Text = mywater.Price.ToString();
                                txtprice2.Text = "0"; // edited by hanan10
                                txtpromo.Text = mywater.PromoCode;
                                txtdisc.Text = mywater.Discount.ToString();
                                txttotal.Text = "0";
                                txtremark.Text = mywater.Remark;
                                Lat1 = mywater.PickLat; // edited by hanan2
                                Long1 = mywater.PickLong; // edited by hanan2

                                var result = (mywater.Address.Substring(mywater.Address.LastIndexOf('#') + 1)).Trim();

                                ddlcity.SelectedValue = result;
                                ddltype11.SelectedValue = mywater.WaterType.ToString();
                                ddltype11_SelectedIndexChanged(sender, e); // display details of type
                                ddldetail.SelectedValue = mywater.DetailType.ToString();
                                if (ddldetail.DataSource != null)
                                {
                                    ddldetail_SelectedIndexChanged(sender, e); // display prices
                                }
                                txtprice_TextChanged(sender, e); // display total

                                // edited by hanan2
                                string driverNo = mywater.IDdriver;
                                string result2 = driverNo.Substring(driverNo.LastIndexOf('#') + 1);

                                if (result2.StartsWith("01"))
                                {
                                    Cars myDr = new Cars();
                                    myDr.Branch = short.Parse(Session["Branch"].ToString());
                                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myDr.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                    myDr.DriverCode = result2.Trim();
                                    myDr = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                            where sitm.DriverCode == myDr.DriverCode && (bool)sitm.Status
                                            select sitm).FirstOrDefault();
                                    if (myDr != null)
                                    {
                                        ddlType.SelectedValue = myDr.CarsType.ToString();
                                        ddlType_SelectedIndexChanged(sender, e);
                                        ddlDriver.SelectedValue = myDr.DriverCode;
                                        ddlDriver_SelectedIndexChanged(sender, e);
                                    }
                                }
                                else
                                {
                                    CoDrivers myco = new CoDrivers();
                                    myco.DriverCode = result2;
                                    myco = myco.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (myco != null)
                                    {
                                        ddlType.SelectedValue = myco.DCareType.ToString();
                                        ddlType_SelectedIndexChanged(sender, e);
                                        ddlDriver.SelectedValue = myco.ID.ToString();
                                        ddlDriver_SelectedIndexChanged(sender, e);
                                    }
                                }

                                myuser.ID = mywater.IDUser;
                                myuser = myuser.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                ddlusers.SelectedValue = myuser.ID;
                                txtname.Text = myuser.FirstName + " " + myuser.LastName;
                                txtid.Text = myuser.IDNo;
                                txtplace.Text = "";
                                txtidDate.Text = "";
                                txtaddr.Text = "";
                                txtmob.Text = myuser.MobileNo;

                            }
                            else
                                LblCodesResult.Text = "لم يتم العثور على بيانات الفاتورة";
                        }
                        else
                        {
                            // create new invoice
                            ddlusers.Enabled = true;
                            ddltype11.Enabled = true;
                            ddldetail.Enabled = true;
                            ddlcity.Enabled = true;
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


        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // edited by hanan2 ( copy & paste the section )

            /*  Cars mycars = new Cars();

                       mycars.Branch = short.Parse(Session["Branch"].ToString());
                       mycars.CarsType = int.Parse(ddlType.SelectedValue);   
                      ddlCar.DataTextField = "PlateNo";
                       ddlCar.DataValueField = "DriverCode";
                       ddlCar.DataSource = mycars.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                       ddlCar.DataBind();
                       ddlCar.Items.Insert(0, new ListItem("-- أختر الناقلة --", "-1", true)); */

            Cars mycars2 = new Cars();
            List<Cars> mylist1 = new List<Cars>(); 
            mycars2.Branch = short.Parse(Session["Branch"].ToString());
            if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), mycars2.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            mycars2.CarsType = int.Parse(ddlType.SelectedValue);
            mylist1 = (from itm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                       where (bool)itm.Status && itm.CarsType == mycars2.CarsType
                       select itm).ToList();

            CoDrivers myco = new CoDrivers(); 
            List<CoDrivers> mylist2 = new List<CoDrivers>();
            myco.DCareType = short.Parse(ddlType.SelectedValue);
            mylist2 = myco.FindByCarType(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString); // edited by hanan2

            // create drivers list
            var driversCollected = from itm in mylist1
                                   select new
                                   {
                                       Value = itm.DriverCode,
                                       Text = itm.DriverCode
                                   };

            var finalQuery = driversCollected.Concat(
                from itm in mylist2
                select new
                {
                    Value = itm.DriverCode,
                    Text = itm.DriverCode
                }
            );

            ddlDriver.DataSource = finalQuery;
            ddlDriver.DataTextField = "Text";
            ddlDriver.DataValueField = "Value";
            ddlDriver.DataBind();
            ddlDriver.Items.Insert(0, new ListItem(" -- إختر السائق", "-1", true));
        }


        protected void ddlCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            // edited by hanan2
            /*   Cars mycars = new Cars();

               mycars.Branch = short.Parse(Session["Branch"].ToString());
               mycars.Code = ddlType.SelectedValue;

               Drivers myDr = new Drivers();

               myDr.Branch = short.Parse(Session["Branch"].ToString());
               myDr.Code = ddlCar.SelectedValue;
               myDr = myDr.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
               txtRentDriver.Text = myDr.Name2;

               ddlDriver.SelectedValue = ddlCar.SelectedValue; */

        }

        protected void ddlDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            // edited by hanan2
            Drivers myDr = new Drivers();
            myDr.Branch = short.Parse(Session["Branch"].ToString());
            if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDr.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            myDr.Code = ddlDriver.SelectedValue;
            myDr = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                    where sitm.Code == myDr.Code
                    select sitm).FirstOrDefault();

            if (myDr == null)
            {
                CoDrivers myCodr = new CoDrivers();
                myCodr.ID = int.Parse(ddlDriver.SelectedValue);

                myCodr = myCodr.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                txtRentDriver.Text = myCodr.Name2;
            }
            else
            {
                txtRentDriver.Text = myDr.Name2;
            }

           // ddlCar.SelectedValue = ddlDriver.SelectedValue; // edited by hanan2
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

                    BtnNew.Enabled = true;

                    Water myinv = new Water();
                    myinv.Branch = short.Parse(Session["Branch"].ToString());
                    myinv.VouLoc = AreaNo;
                    myinv.VouNo = int.Parse(txtNumber.Text);
                    myinv = myinv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    if (myinv != null)
                    {
                        if (myinv.UserName == txtUserName.ToolTip)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "فاتورة المياه موجودة مسبقا";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            BtnNew.Enabled = true;
                            return;
                        }
                        else
                        {
                            myinv = new Water();
                            myinv.Branch = short.Parse(Session["Branch"].ToString());
                            myinv.VouLoc = AreaNo;
                            int? myid = myinv.GetMax(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
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

                    bool Add = false;
                    myinv = new Water();
                    int newNo = int.Parse(txtNumber.Text);
                    myinv.Branch = short.Parse(Session["Branch"].ToString());
                    myinv.VouLoc = AreaNo;
                    myinv.VouNo = int.Parse(txtNumber.Text);
                    myinv.IDUser = ddlusers.SelectedValue; // edited by hanan2
                    myinv.IDdriver = ddlDriver.SelectedValue;
                    myinv.WaterType = short.Parse(ddltype11.SelectedValue);
                    myinv.DetailType = short.Parse(ddldetail.SelectedValue);
                    myinv.HDate = txtHDate.Text;
                    myinv.GDate = txtGDate.Text;
                    myinv.Name = txtname.Text;
                    myinv.IDNo = txtid.Text;
                    myinv.IDType = 0; // edited by hanan2
                    myinv.IDFrom = txtplace.Text;
                    myinv.IDDate = txtidDate.Text;
                    myinv.Address = txtaddr.Text + "#" + ddlcity.SelectedValue;
                    myinv.MobileNo = txtmob.Text;
                    myinv.Mail = ""; // edited by hanan2
                    myinv.PickLat = Lat1; // edited by hanan2
                    myinv.PickLong = Long1; // edited by hanan2
                    myinv.UserName = txtUserName.ToolTip;
                    myinv.UserDate = txtUserDate.Text;
                    myinv.FTime = LblFTime.Text;
                    myinv.Descr = txtdesc.Text;
                    myinv.Price = double.Parse(txtprice.Text);
                    myinv.SerPrice = double.Parse(txtprice2.Text); // edited by hanan10
                    myinv.PayType = 0; // edited by hanan2
                    myinv.PromoCode = txtpromo.Text;
                    myinv.Discount = double.Parse(txtdisc.Text);
                    myinv.Remark = txtremark.Text;
                    myinv.Status = 0; // edited by hanan2
                    //    myinv.RentPlateNo = "";
                    //    myinv.RentValue = 0;
                    //        myinv.RentDriver = txtRentDriver.Text;
                    //       myinv.RentMobileNo = txtRentMobileNo.Text;
                    Add = myinv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    if (Add)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Green; // edited by hanan12
                        LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح"; // edited by hanan12
                        BtnNew.Enabled = true; // edited by hanan12
                        BtnClear_Click(sender, e); // edited by hanan12

                        if (Request.QueryString["InvNo"] != null)  // edited by hanan12
                        { // edited by hanan12
                            WaterOnline mywater = new WaterOnline();
                            mywater.Branch = short.Parse(Session["Branch"].ToString());
                            mywater.VouLoc = "1";
                            mywater.VouNo = int.Parse(Request.QueryString["InvNo"]);
                            mywater.NewVouNo = int.Parse(AreaNo) + "/" + newNo; // edited by hanan99
                            if (mywater.PostWaterOnline(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)) // edited by hanan99
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                                BtnNew.Enabled = true;
                                BtnClear_Click(sender, e);
                            }
                            else
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء تحديث الفاتورة المؤقتة ... حاول مرة أخرى";
                                BtnNew.Enabled = true;

                            }
                        }

                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء إنشاء الفاتورة ... حاول مرة أخرى";
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


        protected void BtnEdit_Click(object sender, EventArgs e)
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

                    Water myinv = new Water();
                    myinv.Branch = short.Parse(Session["Branch"].ToString());
                    myinv.VouLoc = AreaNo;
                    myinv.VouNo = int.Parse(txtNumber.Text);
                    myinv = myinv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myinv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم البيان غير معرف من قبل";

                    }
                    else
                    {
                        bool Add = false;
                        myinv = new Water();
                        myinv.Branch = short.Parse(Session["Branch"].ToString());
                        myinv.VouLoc = AreaNo;
                        myinv.VouNo = int.Parse(txtNumber.Text);
                        myinv.IDUser = ""; // edited by hanan2
                        myinv.IDdriver = ddlDriver.SelectedValue;
                        myinv.WaterType = short.Parse(ddltype11.SelectedValue);
                        myinv.DetailType = short.Parse(ddldetail.SelectedValue);
                        myinv.HDate = txtHDate.Text;
                        myinv.GDate = txtGDate.Text;
                        myinv.Name = txtname.Text;
                        myinv.IDNo = txtid.Text;
                        myinv.IDType = 0; // edited by hanan2
                        myinv.IDFrom = txtplace.Text;
                        myinv.IDDate = txtidDate.Text;
                        myinv.Address = txtaddr.Text + "#" + ddlcity.SelectedValue;
                        myinv.MobileNo = txtmob.Text;
                        myinv.Mail = ""; // edited by hanan2
                        myinv.PickLat = Lat1; // edited by hanan2
                        myinv.PickLong = Long1; // edited by hanan2
                        myinv.UserName = txtUserName.ToolTip;
                        myinv.UserDate = txtUserDate.Text;
                        myinv.FTime = LblFTime.Text;
                        myinv.Descr = txtdesc.Text;
                        myinv.Price = double.Parse(txtprice.Text);
                        myinv.SerPrice = double.Parse(txtprice2.Text); // edited by hanan10
                        myinv.PayType = 0; // edited by hanan2
                        myinv.PromoCode = txtpromo.Text;
                        myinv.Discount = double.Parse(txtdisc.Text);
                        myinv.Remark = txtremark.Text;
                        myinv.Status = 0; // edited by hanan2
                        //    myinv.RentPlateNo = "";
                        //    myinv.RentValue = 0;
                        //        myinv.RentDriver = txtRentDriver.Text;
                        //       myinv.RentMobileNo = txtRentMobileNo.Text;
                        Add = myinv.Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        if (Add)
                        {

                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "تم تحديث البيانات بنجاح";
                            BtnNew.Enabled = true;
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ أثناء التحديث ... حاول مرة أخرى";
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

                CarsType mytype = new CarsType();

                mytype.Branch = short.Parse(Session["Branch"].ToString());
                ddlType.DataTextField = "Name1";
                ddlType.DataValueField = "Code";
                ddlType.DataSource = mytype.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                ddlType.DataBind();
                ddlType.Items.Insert(0, new ListItem("-- أختر نوع الناقلة --", "-1", true));

                ShipUsers myuser = new ShipUsers();
                ddlusers.DataTextField = "ID";
                ddlusers.DataValueField = "ID";
                ddlusers.DataSource = myuser.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString); // edited by hanan10 (GetAll2 added in shipusers class)
                ddlusers.DataBind();
                ddlusers.Items.Insert(0, new ListItem("-- حساب غير مسجل --", "-1", true));

                Cities mycity = new Cities();
                mycity.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                ddlcity.DataTextField = "Name1";
                ddlcity.DataValueField = "Code";
                ddlcity.DataSource = (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()]);
                ddlcity.DataBind();
                ddlcity.Items.Insert(0, new ListItem("-- أختر المدينة --", "-1", true));

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
                txtname.Text = "";
                txtid.Text = "";
                txtplace.Text = "";
                txtidDate.Text = "";
                txtaddr.Text = "";
                txtmob.Text = "";
                txtdesc.Text = "";
                txtprice.Text = "0";
                txtprice2.Text = "0"; // edited by hanan10
                txtpromo.Text = "0";
                txtdisc.Text = "0";
                txttotal.Text = "0";
                txtremark.Text = "";

                ddldetail.Items.Clear();
                //      ddlCar.SelectedIndex = -1;// edited by hanan2
                ddlDriver.DataSource = null;
                ddlDriver.DataBind();
                //          ddlCar.DataSource = null; // edited by hanan2
                //       ddlCar.DataBind(); // edited by hanan2

                ddlcity.SelectedIndex = -1;
                ddltype11.SelectedIndex = -1;
                ddldetail.SelectedIndex = -1;

                ddlusers.Enabled = true; // edited by hanan10
                ddltype11.Enabled = true; // edited by hanan10
                ddldetail.Enabled = true; // edited by hanan10
                ddlcity.Enabled = true; // edited by hanan10

         //       ddldetail.Items.Clear();
         //       ddldetail.DataSource = null;
         //       ddldetail.DataBind();

                //        txtRentMobileNo.Text = ""; // edited by hanan2
                txtRentDriver.Text = "";

                Water myinv = new Water();
                myinv.Branch = short.Parse(Session["Branch"].ToString());
                myinv.VouLoc = AreaNo;
                int? myid = myinv.GetMax(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
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
            catch (Exception ex)
            {
                // if (ConfigurationManager.AppSettings["ExitOnError"].ToString() == "1")
                // {
                //      Session.Add("Error", ex);
                //      Response.Redirect("GeneralServerError.aspx", false);
                //  }
                //  else
                //   {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
                //  }
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

                    Water myinv = new Water();
                    myinv.Branch = short.Parse(Session["Branch"].ToString());
                    myinv.VouLoc = AreaNo;
                    myinv.VouNo = int.Parse(txtNumber.Text);

                    myinv = myinv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myinv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الفاتورة غير معرف من قبل";

                    }
                    else
                    {
                        myinv = new Water();
                        myinv.Branch = short.Parse(Session["Branch"].ToString());
                        myinv.VouLoc = AreaNo;
                        myinv.VouNo = int.Parse(txtNumber.Text);

                        if (myinv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
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
            BtnFind_Click(sender, e);
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
            Water myinv = new Water();

            myinv.Branch = short.Parse(Session["Branch"].ToString());
            myinv.VouLoc = AreaNo;
            myinv.VouNo = int.Parse(txtSearch.Text);

            myinv = myinv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myinv == null)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "رقم الفاتورة غير معرف من قبل";
            }
            else
            {
                lblBranch.Text = int.Parse(myinv.VouLoc).ToString();
                txtNumber.Text = myinv.VouNo.ToString();
                //     if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان ترحيل", "عرض", "عرض بيان الترحيل رقم " + lblBranch.Text + "/" + txtNumber.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                //     EditMode();

                GetcarDetails(myinv.IDdriver, sender, e); // edited by hanan2

                txtHDate.Text = myinv.HDate;
                txtGDate.Text = myinv.GDate;
                txtUserName.Text = myinv.UserName;
                txtUserDate.Text = myinv.UserDate;
                LblFTime.Text = myinv.FTime;
                var result = (myinv.Address.Substring(myinv.Address.LastIndexOf('#') + 1)).Trim();
                ddlcity.SelectedValue = result;
                ddltype11.SelectedValue = myinv.WaterType.ToString();
                ddltype11_SelectedIndexChanged(sender, e); // display details of type
                ddldetail.SelectedValue = myinv.DetailType.ToString();
            //    if (ddldetail.DataSource != null)
           //     {
           //         ddldetail_SelectedIndexChanged(sender, e); // display prices
           //     }
          //      txtprice_TextChanged(sender, e); // display total
    //            LoadDetails(myinv);
                txtname.Text = myinv.Name;
                txtid.Text = myinv.IDNo;
                txtplace.Text = myinv.IDFrom;
                txtidDate.Text = myinv.IDDate;
                txtaddr.Text = myinv.Address;
                txtmob.Text = myinv.MobileNo;
                txtdesc.Text = myinv.Descr;
                txtprice.Text = myinv.Price.ToString();
                txtprice2.Text = myinv.SerPrice.ToString(); // edited by hanan10
                txtpromo.Text = myinv.PromoCode.ToString(); ;
                txtdisc.Text = myinv.Discount.ToString();
                txtprice_TextChanged(sender, e); // edited by hanan11
                txtremark.Text = myinv.Remark;
                Lat1 = myinv.PickLat; // edited by hanan2
                Long1 = myinv.PickLong; // edited by hanan2
                ddlusers.SelectedValue = myinv.IDUser; // edited by hanan2

            }

        }



        protected void LoadDetails(Water myinv)
        {
            if (ddltype11.SelectedValue == "1")
            {
                ddldetail.Items.Clear();
                ddldetail.DataSource = null;
                ddldetail.DataBind();
                ddldetail.SelectedValue = myinv.DetailType.ToString();

            }
            else if (ddltype11.SelectedValue == "2")
            {
                ddldetail.Items.Clear();
                ddldetail.DataSource = null;
                ddldetail.DataBind();

                ddldetail.SelectedValue = myinv.DetailType.ToString();
            }
            else if (ddltype11.SelectedValue == "3")
            {
                ddldetail.Items.Clear();
                ddldetail.DataSource = null;
                ddldetail.DataBind();

                ddldetail.SelectedValue = myinv.DetailType.ToString();

            }
         
        }


        // edited by hanan2 ( copy & paste function)
        public void GetcarDetails(string drcode, object sender, EventArgs e)
        {
            Cars mycars = new Cars();

            mycars.Branch = short.Parse(Session["Branch"].ToString());
            if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), mycars.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            mycars.DriverCode = drcode;

            mycars = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                      where sitm.DriverCode == mycars.DriverCode && (bool)sitm.Status
                      select sitm).FirstOrDefault();
            ddlType.SelectedValue = mycars.CarsType.ToString();

            ddlType_SelectedIndexChanged(sender, e);

            ddlDriver.SelectedValue = drcode;
            //         ddlCar.SelectedValue = ddlDriver.SelectedValue; // edited by hanan2

            Drivers myDr = new Drivers();
            myDr.Branch = short.Parse(Session["Branch"].ToString());
            if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDr.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            myDr.Code = drcode;
            myDr = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                    where sitm.Code == myDr.Code
                    select sitm).FirstOrDefault();
            txtRentDriver.Text = myDr.Name2;

        }

        protected void ddltype11_SelectedIndexChanged(object sender, EventArgs e)
        {
                ddldetail.Items.Clear();
                ddldetail.DataSource = null;
                ddldetail.DataBind();

                if (ddltype11.SelectedValue !="-1" && ddlcity.SelectedValue != "-1") // edited by hanan11
                { // edited by hanan11
                    AppPrice myprice = new AppPrice();

                    myprice.Branch = short.Parse(Session["Branch"].ToString());
                    myprice.FType = 1;
                    myprice.FType2 = short.Parse(ddltype11.SelectedValue);
                    myprice.Code = ddlcity.SelectedValue;

                    ddldetail.DataValueField = "FType3";
                    ddldetail.DataTextField = "Name1";
                    ddldetail.DataSource = myprice.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddldetail.DataBind();
                    ddldetail_SelectedIndexChanged(sender, e); // edited by hanan11
                } // edited by hanan11
        }

        protected void ddldetail_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddldetail.SelectedValue != "" && ddldetail.SelectedValue != "-1" && ddltype11.SelectedValue != "-1" && ddlcity.SelectedValue != "-1") // edited by hanan11
            {
                AppPrice myprice = new AppPrice();

                myprice.Branch = short.Parse(Session["Branch"].ToString());
                myprice.FType = 1;
                myprice.FType2 = short.Parse(ddltype11.SelectedValue);
                myprice.Code = ddlcity.SelectedValue;
                myprice.FType3 = short.Parse(ddldetail.SelectedValue);

                myprice = myprice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                txtprice.Text = myprice.Price.ToString(); ; //
                txtprice2.Text = myprice.SerPrice.ToString(); // edited by hanan10
                txtprice_TextChanged(sender, e);

            }
            else // edited by hanan11
            { // edited by hanan11
                txtprice.Text = "0"; 
                txtprice2.Text = "0"; 
                txttotal.Text = "0";
                txtpromo.Text = "0";
                txtdisc.Text = "0";
            } // edited by hanan11
           
        }

        protected void txtprice_TextChanged(object sender, EventArgs e)
        {
            txttotal.Text = (double.Parse(txtprice.Text) + double.Parse(txtprice2.Text) - double.Parse(txtdisc.Text)).ToString(); // edited by hanan10

        }

        protected void txtdisc_TextChanged(object sender, EventArgs e)
        {
            txttotal.Text = (double.Parse(txtprice.Text) + double.Parse(txtprice2.Text) - double.Parse(txtdisc.Text)).ToString(); // edited by hanan10
        }

        protected void txtpromo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlusers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShipUsers myuser = new ShipUsers();
            myuser.ID = ddlusers.SelectedValue;
            myuser = myuser.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

            txtname.Text = myuser.FirstName + " " + myuser.LastName;
            txtid.Text = myuser.IDNo;
            txtplace.Text = "";
            txtidDate.Text = "";
            txtaddr.Text = "";
            txtmob.Text = myuser.MobileNo;

        }

        protected void ddlcity_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddltype11.SelectedValue != "-1" && ddlcity.SelectedValue != "-1") // edited by hanan11
            { // edited by hanan11
                AppPrice myprice = new AppPrice();

                myprice.Branch = short.Parse(Session["Branch"].ToString());
                myprice.FType = 1;
                myprice.FType2 = short.Parse(ddltype11.SelectedValue);
                myprice.Code = ddlcity.SelectedValue;

                ddldetail.DataValueField = "FType3";
                ddldetail.DataTextField = "Name1";
                ddldetail.DataSource = myprice.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                ddldetail.DataBind();
                ddldetail_SelectedIndexChanged(sender, e); // edited by hanan11
            } // edited by hanan11

        }

        protected void txtprice2_TextChanged(object sender, EventArgs e) // edited by hanan10
        {
            txttotal.Text = (double.Parse(txtprice.Text) + double.Parse(txtprice2.Text) - double.Parse(txtdisc.Text)).ToString(); // edited by hanan10
        }

        protected void BtnDiscountTerm_Click(object sender, ImageClickEventArgs e)
        {            
            if (this.txtpromo.Text != "")
            {
                txttotal.Text = (double.Parse(txtprice.Text) + double.Parse(txtprice2.Text) - double.Parse(txtdisc.Text)).ToString();
                ChkPromo cp = new ChkPromo();
                cp = moh.CheckMyPromoCode(5, this.txtpromo.Text, "", lblBranch.Text.Trim() + "/" + this.txtNumber.Text.Trim(), txtGDate.Text + " " + LblFTime.Text, 1, "-1", "-1", "", "", txtUserName.ToolTip, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                if (cp.ErrMsg == "1")
                {
                    double Discount = 0, vDisPer = 0, tot = moh.StrToDouble(txttotal.Text);
                    if (cp.Amount != 0) Discount = (double)cp.Amount;
                    else if (cp.SAmount != 0) Discount = (double)cp.SAmount;
                    else if (cp.Per != 0)
                    {
                        vDisPer = (double)(cp.Per / 100);
                        Discount = (moh.StrToDouble(txtprice2.Text) * vDisPer);
                    }
                    else if (cp.SPer != 0)
                    {
                        vDisPer = (double)(cp.SPer / 100);
                        Discount = (moh.StrToDouble(txtprice2.Text) * vDisPer);
                    }
                    txtdisc.Text = Discount.ToString();
                }
                else
                {
                    txtdisc.Text = "0";
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "كود الخصم غير صالح";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                }
                txttotal.Text = (double.Parse(txtprice.Text) + double.Parse(txtprice2.Text) - double.Parse(txtdisc.Text)).ToString();
            }

        } // edited by hanan10


    }
}