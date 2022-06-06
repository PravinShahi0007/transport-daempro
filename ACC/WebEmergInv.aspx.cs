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
    public partial class WebEmergInv : System.Web.UI.Page
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

        public string itCode // edited by hanan99
        {
            get
            {
                if (ViewState["itCode"] == null)
                {
                    ViewState["itCode"] = "0";
                }
                return ViewState["itCode"].ToString();
            }
            set { ViewState["itCode"] = value; }
        }

   //     public string itCode { get; set; } // edited by hanan2
  

        protected void Page_Load(object sender, EventArgs e)
        {
        try
            {
                //  ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttach);

                if (!Page.IsPostBack)
                {
                    Cities myCity = new Cities();
                    this.Page.Header.Title = "اتفاقية خدمات طريق";


                    //Session.Add("Branch", 1);
                    //Session.Add("AreaNo", "00001");
                    //Session.Add("CurrentUser", "Hanan");
                    //Session.Add("FullUser", "Hanan m");
                    //Session.Add("CNN", "MyCnn2");
                    //Session.Add("CNN2", "MyCnnlog");

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

                        if (Request.QueryString["AreaNo"] != null && Request.QueryString["InvNo"] != null) // related to Emergency invoice
                        {

                            Emergency myemr = new Emergency();
                            ShipUsers myuser = new ShipUsers();
                            myemr.Branch = 1;
                            myemr.VouLoc = "1";
                            myemr.VouNo = int.Parse(Request.QueryString["InvNo"]);
                            myemr = myemr.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            if (myemr != null)
                            {
                                //      txtNumber.Text = myemr.VouNo.ToString();
                                txtdesc.Text = myemr.Remark;
                                txtprice.Text = myemr.SerPrice.ToString(); // edited by hanan11
                                txtprod.Text = myemr.Price.ToString();  // edited by hanan11
                                txtpromo.Text = myemr.PromoCode;
                                txtdisc.Text = myemr.Discount.ToString();
                                txttotal.Text = "0";
                                txtremark.Text = "";
                                Lat1 = myemr.PickLat; // edited by hanan2
                                Long1 = myemr.PickLong; // edited by hanan2
                                itCode = myemr.ItemType.ToString(); // edited by hanan11

                                ddltype11.SelectedValue = myemr.EmrType.ToString();
                                ddltype11_SelectedIndexChanged(sender, e); // display details of type
                                ddldetail.SelectedValue = myemr.DetailType.ToString();
                                //          ddldetail_SelectedIndexChanged(sender, e); // display prices  // edited by hanan11
                                if (myemr.ItemType != -1) // edited by hanan11
                                    loadData((short)myemr.ItemType); // edited by hanan11
                                else // edited by hanan11
                                    ddlitem.Enabled = false; // edited by hanan11
                                txtprice_TextChanged(sender, e); // display total

                                // edited by hanan2
                                string driverNo = myemr.IDdriver;

                                string result = myemr.IDdriver;  // driverNo.Substring(driverNo.LastIndexOf('#') + 1);

                                if (result.StartsWith("01"))
                                {
                                    Cars myDr = new Cars();
                                    myDr.Branch = short.Parse(Session["Branch"].ToString());
                                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myDr.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                    myDr.DriverCode = result;
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
                                    myco.ID = int.Parse(result);
                                    myco = myco.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (myco != null)
                                    { 
                                        ddlType.SelectedValue = myco.DCareType.ToString();
                                        ddlType_SelectedIndexChanged(sender, e);
                                        ddlDriver.SelectedValue = myco.ID.ToString();
                                        ddlDriver_SelectedIndexChanged(sender, e);
                                    }
                                }


                                myuser.ID = myemr.IDUser;
                                myuser = myuser.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (myuser != null)
                                {
                                    ddlusers.SelectedValue = myuser.ID;
                                    txtname.Text = myuser.FirstName + " " + myuser.LastName;
                                    txtid.Text = myuser.IDNo;
                                    txtplace.Text = "";
                                    txtidDate.Text = "";
                                    txtaddr.Text = "";
                                    txtmob.Text = myuser.MobileNo;
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
            

         //   ddlCar.SelectedValue = ddlDriver.SelectedValue; // edited by hanan2
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
                  
                    EmergInv myinv = new EmergInv();
                    myinv.Branch = short.Parse(Session["Branch"].ToString());
                    myinv.VouLoc = AreaNo;
                    myinv.VouNo = int.Parse(txtNumber.Text);
                    myinv = myinv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    if (myinv != null)
                    {
                        if (myinv.UserName == txtUserName.ToolTip)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "فاتورة خدمة الطريق موجودة مسبقا";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            BtnNew.Enabled = true;
                            return;
                        }
                        else
                        {
                            myinv = new EmergInv();
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
                    int newNo = int.Parse(txtNumber.Text);
                    myinv = new EmergInv();
                    /*
                    myinv.Branch = short.Parse(Session["Branch"].ToString());
                    myinv.VouLoc = AreaNo;
                    myinv.VouNo = int.Parse(txtNumber.Text);
                    myinv.IDUser = ddlusers.SelectedValue; // edited by hanan2
                    myinv.IDdriver = ddlDriver.SelectedValue;
                    myinv.EmrType = short.Parse(ddltype11.SelectedValue);
                    myinv.DetailType = short.Parse(ddldetail.SelectedValue);

                    if (ddlitem.SelectedValue != null && ddlitem.SelectedValue != "") // edited by hanan12
                        myinv.ItemType = short.Parse(ddlitem.SelectedValue); // edited by hanan11
                    else // edited by hanan11
                        myinv.ItemType = -1; // edited by hanan11
                    myinv.HDate = txtHDate.Text;
                    myinv.GDate = txtGDate.Text;
                    myinv.Name = txtname.Text;
                    myinv.IDNo = txtid.Text;
                    myinv.IDType = 0; // edited by hanan2
                    myinv.IDFrom = txtplace.Text;
                    myinv.IDDate = txtidDate.Text;
                    myinv.Address1 = txtaddr.Text;
                    myinv.MobileNo = txtmob.Text;
                    myinv.Mail = ""; // edited by hanan2
                    myinv.PickLat = Lat1; // edited by hanan2
                    myinv.PickLong = Long1; // edited by hanan2
                    myinv.UserName = txtUserName.ToolTip;
                    myinv.UserDate = txtUserDate.Text;
                    myinv.FTime = LblFTime.Text;
                    myinv.Descr = txtdesc.Text;
                    myinv.ServPrice = double.Parse(txtprice.Text);
                    myinv.Price = double.Parse(txtprod.Text);
                    myinv.PayType = 0; // edited by hanan2
                    myinv.PromoCode = txtpromo.Text;
                    myinv.Discount = double.Parse(txtdisc.Text);
                    myinv.Total = double.Parse(txttotal.Text);
                    myinv.Remark = txtremark.Text;
                    myinv.Status = 0; // edited by hanan2
                     */
                //    myinv.RentPlateNo = "";
                //    myinv.RentValue = 0;
            //        myinv.RentDriver = txtRentDriver.Text;
             //       myinv.RentMobileNo = txtRentMobileNo.Text;
                    Add = myinv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    if (Add)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Green; // edited by hanan11
                        LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح"; // edited by hanan11
                        BtnNew.Enabled = true; // edited by hanan11
                        BtnClear_Click(sender, e); // edited by hanan11

                        if (Request.QueryString["InvNo"] != null)  // related to Emergency invoice
                        { // edited by hanan11
                            Emergency myemerg = new Emergency();
                            myemerg.Branch = short.Parse(Session["Branch"].ToString());
                            myemerg.VouLoc = "1";
                            myemerg.VouNo = int.Parse(Request.QueryString["InvNo"]);
                            myemerg.NewVouNo = int.Parse(AreaNo) + "/" + newNo; // edited by hanan99
                            if (myemerg.PostEmergency(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))  // edited by hanan99 
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
                        } // edited by hanan11
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

                    EmergInv myinv = new EmergInv();
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
                        myinv = new EmergInv();
                        /*
                        myinv.Branch = short.Parse(Session["Branch"].ToString());
                        myinv.VouLoc = AreaNo;
                        myinv.VouNo = int.Parse(txtNumber.Text);
                        myinv.IDUser = ddlusers.SelectedValue; // edited by hanan2
                        myinv.IDdriver = ddlDriver.SelectedValue;
                        myinv.EmrType = short.Parse(ddltype11.SelectedValue);
                        myinv.DetailType = short.Parse(ddldetail.SelectedValue);

                        if (ddlitem.SelectedValue != "") // edited by hanan11
                            myinv.ItemType = short.Parse(ddlitem.SelectedValue); // edited by hanan11
                        else // edited by hanan11
                            myinv.ItemType = -1; // edited by hanan11
                        myinv.HDate = txtHDate.Text;
                        myinv.GDate = txtGDate.Text;
                        myinv.Name = txtname.Text;
                        myinv.IDNo = txtid.Text;
                        myinv.IDType = 0; // edited by hanan2
                        myinv.IDFrom = txtplace.Text;
                        myinv.IDDate = txtidDate.Text;
                        myinv.Address1 = txtaddr.Text;
                        myinv.MobileNo = txtmob.Text;
                        myinv.Mail = ""; // edited by hanan2
                        myinv.PickLat = Lat1; // edited by hanan2
                        myinv.PickLong = Long1; // edited by hanan2
                        myinv.UserName = txtUserName.ToolTip;
                        myinv.UserDate = txtUserDate.Text;
                        myinv.FTime = LblFTime.Text;
                        myinv.Descr = txtdesc.Text;
                        myinv.ServPrice = double.Parse(txtprice.Text);
                        myinv.Price = double.Parse(txtprod.Text);
                        myinv.PayType = 0; // edited by hanan2
                        myinv.PromoCode = txtpromo.Text;
                        myinv.Discount = double.Parse(txtdisc.Text);
                        myinv.Total = double.Parse(txttotal.Text);
                        myinv.Remark = txtremark.Text;
                        myinv.Status = 0; // edited by hanan2
                        //    myinv.RentPlateNo = "";
                        //    myinv.RentValue = 0;
                        //        myinv.RentDriver = txtRentDriver.Text;
                        //       myinv.RentMobileNo = txtRentMobileNo.Text;
                        Add = myinv.Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                         */

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
                ddlusers.DataSource = myuser.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString); // edited by hanan11
                ddlusers.DataBind(); // edited by hanan11
                ddlusers.Items.Insert(0, new ListItem("-- حساب غير مسجل --", "-1", true));

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
                txtprod.Text = "0";
                txtpromo.Text = "0";
                txtdisc.Text = "0";
                txttotal.Text = "0";
                txtremark.Text = "";

                ddldetail.Items.Clear();
                //       ddlCar.SelectedIndex = -1; // edited by hanan2
                ddlDriver.DataSource = null;
                ddlDriver.DataBind();
                //        ddlCar.DataSource = null; // edited by hanan2
                //           ddlCar.DataBind(); // edited by hanan2

                ddltype11.SelectedIndex = -1;

                ddldetail.Items.Clear();
                ddldetail.DataSource = null;
                ddldetail.DataBind();

                ddlitem.Items.Clear(); // edited by hanan11
                ddlitem.DataSource = null; // edited by hanan11
                ddlitem.DataBind(); // edited by hanan11

                //    txtRentMobileNo.Text = ""; // edited by hanan2
                txtRentDriver.Text = "";

                EmergInv myinv = new EmergInv();
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

                    EmergInv myinv = new EmergInv();
                    myinv.Branch = short.Parse(Session["Branch"].ToString());
                    myinv.VouLoc = AreaNo;
                    myinv.VouNo = int.Parse(txtNumber.Text);

                    myinv = myinv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myinv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم بيان الحركة غير معرف من قبل";

                    }
                    else
                    {
                        myinv = new EmergInv();
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
            EmergInv myinv = new EmergInv();

            myinv.Branch = short.Parse(Session["Branch"].ToString());
            myinv.VouLoc = AreaNo;
            myinv.VouNo = int.Parse(txtSearch.Text);

            myinv = myinv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myinv == null)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "رقم البيان غير معرف من قبل";
            }
            else
            {
                BtnClear_Click(sender, e); // edited by hanan12
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
                /*
                ddltype11.SelectedValue = myinv.EmrType.ToString();
                //       LoadDetails(myinv); // edited by hanan12
                ddltype11_SelectedIndexChanged(sender, e); // edited by hanan12
                ddldetail.SelectedValue = myinv.DetailType.ToString(); // edited by hanan12
                if (myinv.ItemType != -1) // edited by hanan11
                    loadData((short)myinv.ItemType); // edited by hanan11
                else // edited by hanan11
                    ddlitem.Enabled = false; // edited by hanan11
                txtname.Text = myinv.Name;
                txtid.Text = myinv.IDNo;
                txtplace.Text = myinv.IDFrom;
                txtidDate.Text = myinv.IDDate;
                txtaddr.Text = myinv.Address1;
                txtmob.Text = myinv.MobileNo;
                txtdesc.Text = myinv.Descr;
                txtprice.Text = myinv.ServPrice.ToString();
                txtprod.Text = myinv.Price.ToString(); ;
                txtpromo.Text = myinv.PromoCode.ToString(); ;
                 */
                txtdisc.Text = myinv.Discount.ToString(); ;
                txttotal.Text = myinv.Total.ToString(); ;
                txtremark.Text = myinv.Remark ;
                Lat1 = myinv.PickLat; // edited by hanan2
                Long1 = myinv.PickLong; // edited by hanan2
                ddlusers.SelectedValue = myinv.IDUser; // edited by hanan2

            }

        }



        protected void LoadDetails(EmergInv myinv)
        {
            if (ddltype11.SelectedValue == "1")
            {
                ddldetail.Items.Clear();
                ddldetail.DataSource = null;
                ddldetail.DataBind();

                ddldetail.Items.Add(new ListItem("داخل المدينة", "1"));
                ddldetail.Items.Add(new ListItem("خارج المدينة", "2"));

                //ddldetail.SelectedValue = myinv.DetailType.ToString();

            }
            else if (ddltype11.SelectedValue == "2")
            {
                ddldetail.Items.Clear();
                ddldetail.DataSource = null;
                ddldetail.DataBind();

                ddldetail.Items.Add(new ListItem("شحن", "3"));
                ddldetail.Items.Add(new ListItem("استبدال", "4"));

                //ddldetail.SelectedValue = myinv.DetailType.ToString();
            }
            else if (ddltype11.SelectedValue == "3")
            {
                ddldetail.Items.Clear();
                ddldetail.DataSource = null;
                ddldetail.DataBind();

                ddldetail.Items.Add(new ListItem("بنشر", "5"));
                ddldetail.Items.Add(new ListItem("تغيير كفر", "6"));
                ddldetail.Items.Add(new ListItem("كفر جديد", "7"));

                //ddldetail.SelectedValue = myinv.DetailType.ToString();

            }
            else if (ddltype11.SelectedValue == "4")
            {
                ddldetail.Items.Clear();
                ddldetail.DataSource = null;
                ddldetail.DataBind();

                ddldetail.Items.Add(new ListItem("رافعة بونش", "8"));

                //ddldetail.SelectedValue = myinv.DetailType.ToString();
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
       //     ddlCar.SelectedValue = ddlDriver.SelectedValue; // edited by hanan2

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
            if (ddltype11.SelectedValue == "1")
            {
                ddldetail.Items.Clear();
                ddldetail.DataSource = null;
                ddldetail.DataBind();

                ddldetail.Items.Add(new ListItem("-- اختر --", "-1")); // edited by hanan
                ddldetail.Items.Add(new ListItem("داخل المدينة", "1"));
                ddldetail.Items.Add(new ListItem("خارج المدينة", "2"));

            }
            else if (ddltype11.SelectedValue == "2")
            {
                ddldetail.Items.Clear();
           //     ddldetail.SelectedIndex = 0;
                ddldetail.DataSource = null;
                ddldetail.DataBind();

                ddldetail.Items.Add(new ListItem("-- اختر --", "-1")); // edited by hanan
                ddldetail.Items.Add(new ListItem("شحن", "3"));
                ddldetail.Items.Add(new ListItem("استبدال", "4"));
            }
            else if (ddltype11.SelectedValue == "3")
            {
                ddldetail.Items.Clear();
                ddldetail.DataSource = null;
                ddldetail.DataBind();

                ddldetail.Items.Add(new ListItem("-- اختر --", "-1")); // edited by hanan
                ddldetail.Items.Add(new ListItem("بنشر", "5"));
                ddldetail.Items.Add(new ListItem("تغيير كفر", "6"));
                ddldetail.Items.Add(new ListItem("كفر جديد", "7"));

            }
            else if (ddltype11.SelectedValue == "4")
            {
                ddldetail.Items.Clear();
                ddldetail.DataSource = null;
                ddldetail.DataBind();

                ddldetail.Items.Add(new ListItem("-- اختر --", "-1")); // edited by hanan
                ddldetail.Items.Add(new ListItem("رافعة بونش", "8"));
            }

        }

        protected void ddldetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            // edited by hanan11 : start
             if (int.Parse(ddldetail.SelectedValue) != -1)
           {
                AppService myserv = new AppService();
                myserv.Branch = short.Parse(Session["Branch"].ToString());
                myserv.SCode = int.Parse(ddldetail.SelectedValue);
                myserv = myserv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
          
                if (myserv == null)
                {
                    txtprice.Text = "0";
                }
                else
                {
                    txtprice.Text = myserv.Sprice.ToString(); // service
                    //     txtprod.Text = "50"; // value of oil
                }


                if (ddldetail.SelectedValue == "4" || ddldetail.SelectedValue == "7")
                {
                    AppItem myitem = new AppItem();

                    myitem.Branch = short.Parse(Session["Branch"].ToString());
                    myitem.FType = short.Parse(ddltype11.SelectedValue);

                 
                    ddlitem.DataValueField = "ITCode";
                    ddlitem.DataTextField = "ITName1";
                    ddlitem.DataSource = myitem.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlitem.DataBind();
                    ddlitem.Items.Insert(0, new ListItem("-- اختر --", "-1", true));
                    

                    ddlitem.Enabled = true;
                }
                else
                {
                    ddlitem.Items.Clear(); 
                    ddlitem.DataSource = null; 
                    ddlitem.DataBind(); 
                    ddlitem.Enabled = false;
                    txtprod.Text = "0";
                }

                  
                    txtprice_TextChanged(sender, e); 

          }

            // **************** edited by hanan11 : end
        }

        public void loadData(short itemCode) // edited by hanan12
        {
            string itemS = "0000";
            if (ddldetail.SelectedValue == "4" || ddldetail.SelectedValue == "7")
            {
                AppItem myitem = new AppItem();

                myitem.Branch = short.Parse(Session["Branch"].ToString());
                myitem.FType = short.Parse(ddltype11.SelectedValue);


                ddlitem.DataValueField = "ITCode";
                ddlitem.DataTextField = "ITName1";
                ddlitem.DataSource = myitem.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                ddlitem.DataBind();
                ddlitem.Items.Insert(0, new ListItem("-- اختر --", "-1", true));
                ddlitem.Enabled = true;

                if (ddlitem.DataSource != null)
                {
                    if (itemCode < 10)
                        itemS = "000" + itemCode;
                    else                        
                        itemS = "00" + itemCode;
                    ddlitem.SelectedValue = itemS;
                    ddlitem.Enabled = true;
                }
            }

        } // edited by hanan12

        protected void txtprice_TextChanged(object sender, EventArgs e)
        {
            BtnDiscountTerm_Click(sender, null);
            txttotal.Text = (double.Parse(txtprod.Text) + double.Parse(txtprice.Text) - double.Parse(txtdisc.Text)).ToString();         
        }

        protected void txtprod_TextChanged(object sender, EventArgs e)
        {
            BtnDiscountTerm_Click(sender, null);
            txttotal.Text = (double.Parse(txtprod.Text) + double.Parse(txtprice.Text) - double.Parse(txtdisc.Text)).ToString();
        }

        protected void txtdisc_TextChanged(object sender, EventArgs e)
        {
            txttotal.Text = (double.Parse(txtprod.Text) + double.Parse(txtprice.Text) - double.Parse(txtdisc.Text)).ToString();
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
            BtnDiscountTerm_Click(sender, null);
        }

        protected void ddlitem_SelectedIndexChanged(object sender, EventArgs e) // edited by hanan11
        {
            if (int.Parse(ddlitem.SelectedValue) != -1)
            {
                AppItem myitem = new AppItem();

                myitem.Branch = short.Parse(Session["Branch"].ToString());
                myitem.ITCode = ddlitem.SelectedValue;

                myitem.FType = short.Parse(ddltype11.SelectedValue);
                myitem = myitem.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myitem != null)
                {
                    txtprod.Text = myitem.ITprice.ToString();
                }
                else
                    txtprod.Text = "0";

            }
            else
                txtprod.Text = "0";

            txtprice_TextChanged(sender, e);

        }

        protected void BtnDiscountTerm_Click(object sender, ImageClickEventArgs e)
        {            
            if (this.txtpromo.Text != "")
            {
                txttotal.Text = (double.Parse(txtprod.Text) + double.Parse(txtprice.Text)).ToString();

                ChkPromo cp = new ChkPromo();
                cp = moh.CheckMyPromoCode(3, this.txtpromo.Text, "", lblBranch.Text.Trim() + "/" + this.txtNumber.Text.Trim(), txtGDate.Text + " " + LblFTime.Text, 1, "-1", "-1", "", "", txtUserName.ToolTip, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                if (cp.ErrMsg == "1")
                {
                    double Discount = 0, vDisPer = 0, tot = moh.StrToDouble(txttotal.Text);
                    if (cp.Amount != 0) Discount = (double)cp.Amount;
                    else if (cp.SAmount != 0) Discount = (double)cp.SAmount;
                    else if (cp.Per != 0)
                    {
                        vDisPer = (double)(cp.Per / 100);
                        Discount = (moh.StrToDouble(txtprice.Text) * vDisPer);
                    }
                    else if (cp.SPer != 0)
                    {
                        vDisPer = (double)(cp.SPer / 100);
                        Discount = (moh.StrToDouble(txtprice.Text) * vDisPer);
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
                txttotal.Text = (double.Parse(txtprod.Text) + double.Parse(txtprice.Text) - double.Parse(txtdisc.Text)).ToString();
            }
        }

        protected void txtGDate_TextChanged(object sender, EventArgs e)
        {
            BtnDiscountTerm_Click(sender, null);
        }  
    }
}