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
    public partial class WebCoDrivers : System.Web.UI.Page
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


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //  ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttach);

                if (!Page.IsPostBack)
                {
                    Cities myCity = new Cities();
                    this.Page.Header.Title = "حساب سائق متعاون";

                    //Session.Add("Branch", 1);
                    //Session.Add("AreaNo", "00001");
                    //Session.Add("CurrentUser", "Hanan");
                    //Session.Add("FullUser", "Hanan m");
                    //Session.Add("CNN", "MyCnn");
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

                    CarsType mytype = new CarsType(); // edited by hanan3

                    mytype.Branch = short.Parse(Session["Branch"].ToString());
                    //     mytype.FCode = ""; // edited by hanan3
                    ddltype11.DataTextField = "Name1";
                    ddltype11.DataValueField = "Code";
                    ddltype11.DataSource = (from itm in mytype.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                              where itm.Code > 130
                                              select itm).ToList();
                    ddltype11.DataBind();
                    ddltype11.Items.Insert(0, new ListItem("-- أختر نوع/حجم المركبة --", "-1", true));

                    Codes mycode = new Codes();
                    mycode.Branch = short.Parse(Session["Branch"].ToString());
                    mycode.Ftype = 1;
                    if (Cache["LastCodes" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCodes" + Session["CNN2"].ToString(), mycode.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlnat.DataTextField = "Name1";
                    ddlnat.DataValueField = "Code";
                    ddlnat.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                         where itm.Ftype == 1
                                         select itm).ToList();
                    ddlnat.DataBind();
                    ddlnat.Items.Insert(0, new ListItem("-- أختر الجنسية --", "-1", true));

                    Codes mycode2 = new Codes();
                    mycode2.Branch = short.Parse(Session["Branch"].ToString());
                    mycode2.Ftype = 8;
                    ddlbank.DataTextField = "Name1";
                    ddlbank.DataValueField = "Code";
                    ddlbank.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                          where itm.Ftype == 8
                                          select itm).ToList();
                    ddlbank.DataBind();
                    ddlbank.Items.Insert(0, new ListItem("-- أختر البنك --", "-1", true));

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

                    if (Request.QueryString["DrNo"] != null) // Driver ID
                    {
                        AreaNo = Request.QueryString["AreaNo"].ToString();
                        int myNo = int.Parse(Request.QueryString["DrNo"]);

                        CoDrivers mydr = new CoDrivers();

                        mydr.ID = int.Parse(Request.QueryString["DrNo"]);
                        mydr = mydr.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        txtNumber.Text = mydr.ID.ToString();
                        ddltype11.SelectedValue = mydr.DCareType.ToString();
                        txtname.Text = mydr.Name1;
                        txtname2.Text = mydr.Name2;
                        txtid.Text = mydr.IDNo;
                        txtidDate.Text = mydr.IDdate;
                        ddlnat.SelectedValue = mydr.Nat.ToString();
                        txtaddr.Text = mydr.Address;
                        txtmob.Text = mydr.MobileNo;
                        ddltype11.SelectedValue = mydr.DCareType.ToString();
                        ddltype11_SelectedIndexChanged(sender,e);
                        ddlColor.SelectedValue = mydr.DCarColor;
                        txtplate.Text = mydr.DPlateNo;
                        ddlbank.SelectedValue = mydr.Bank.ToString();
                        txtiban.Text = mydr.IBan;
                        txtpercent.Text = mydr.PIncome.ToString(); //edited by hanan
                        lblacc.Text = mydr.AccCode; //edited by hanan
                    //    mydr.ATM = "";
                        ddltrans.SelectedValue = mydr.TransType.ToString();

                 //       ddltype11_SelectedIndexChanged(sender, e); // edited by hanan2
                        txtmodel.Text = mydr.DCarModel; // edited by hanan2

                    }
                    else //edited by hanan2
                    {
                        txtpercent.Text = "0";
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

        protected void ddltype11_SelectedIndexChanged(object sender, EventArgs e)        
        {
            if(ddltype11.SelectedIndex > 0)
            {
                Acc myAcc = new Acc();
                myAcc.Branch = short.Parse(Session["Branch"].ToString());
                myAcc.FCode = "120"+ddltype11.SelectedValue;
                ddlColor.DataTextField = "Name1";
                ddlColor.DataValueField = "Code";
                ddlColor.DataSource = myAcc.GetAllAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                ddlColor.DataBind();
                ddlColor.Items.Insert(0, new ListItem("-- أختر الحساب المرتبط --", "-1", true));

                CoDrivers mydr2 = new CoDrivers();
                grdCodes.DataSource = (from itm in mydr2.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                       where itm.DCareType == short.Parse(ddltype11.SelectedValue)
                                       select itm).ToList();
                grdCodes.DataBind(); // edited by hanan11 : to here

            }

        }

        protected void ddlnat_SelectedIndexChanged(object sender, EventArgs e)
        {

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

                    CoDrivers mydr = new CoDrivers();

                    mydr.ID = int.Parse(txtNumber.Text);
                    mydr = mydr.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    if (mydr != null)
                    {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "السائق موجود مسبقا";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            BtnNew.Enabled = true;
                            return;
                    
                    }
                    else
                    {
                        mydr = new CoDrivers();

                        int? myid = mydr.GetMax(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myid == 0 || myid == null)
                        {
                            myid = 001;
                        }
                        else
                        {
                            myid++;
                        }
                        txtNumber.Text = myid.ToString();
                    }

                    bool Add = false;
                    mydr = new CoDrivers();
                    mydr.ID = int.Parse(txtNumber.Text);
                    mydr.DCareType = short.Parse(ddltype11.SelectedValue);
                    mydr.DCarModel = txtmodel.Text; // edited by hanan2
                    mydr.Name1 = txtname.Text;
                    mydr.Name2 = txtname2.Text;
                    mydr.IDNo = txtid.Text;
                    mydr.IDdate = txtidDate.Text;
                    mydr.Address = txtaddr.Text;
                    mydr.MobileNo = txtmob.Text;
                    mydr.Online = 0;//edited by hanan2
                    mydr.Nat = int.Parse(ddlnat.SelectedValue);//edited by hanan2
                    mydr.DCarColor = ddlColor.SelectedValue;
                    mydr.DPlateNo = txtplate.Text;
                    mydr.Bank = int.Parse(ddlbank.SelectedValue);
                    mydr.IBan = txtiban.Text;
                    mydr.ATM = "";
                    mydr.TransType = short.Parse(ddltrans.SelectedValue) ;
                    mydr.PIncome = short.Parse(txtpercent.Text); //edited by hanan
                    mydr.AccCode = ""; //edited by hanan
             
                    Add = mydr.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

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
                        LblCodesResult.Text = "لقد حدث خطأ أثناء إنشاء حساب السائق ... حاول مرة أخرى";
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

                    CoDrivers mydr = new CoDrivers();
                    mydr.ID = int.Parse(txtNumber.Text);
                    mydr = mydr.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (mydr == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم السائق غير معرف من قبل";

                    }
                    else
                    {
                        bool Add = false;
                        mydr = new CoDrivers();
                        mydr.ID = int.Parse(txtNumber.Text);
                        mydr.DCareType = short.Parse(ddltype11.SelectedValue);
                        mydr.DCarModel = txtmodel.Text ; // edited by hanan2
                        mydr.Name1 = txtname.Text;
                        mydr.Name2 = txtname2.Text;
                        mydr.IDNo = txtid.Text;
                        mydr.IDdate = txtidDate.Text;
                        mydr.Address = txtaddr.Text;
                        mydr.MobileNo = txtmob.Text;
                        mydr.Online = 0; //edited by hanan2
                        mydr.Nat = int.Parse(ddlnat.SelectedValue);//edited by hanan2
                        mydr.DCarColor = ddlColor.SelectedValue;
                        mydr.DPlateNo = txtplate.Text;
                        mydr.Bank = int.Parse(ddlbank.SelectedValue);
                        mydr.IBan = txtiban.Text;
                        mydr.ATM = "";
                        mydr.TransType = short.Parse(ddltrans.SelectedValue);
                        mydr.PIncome = short.Parse(txtpercent.Text); //edited by hanan
                        mydr.AccCode = lblacc.Text; //edited by hanan

                        Add = mydr.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

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

                CarsType mytype = new CarsType();

                //edited by hanan5 :from here
        /*        mytype.Branch = short.Parse(Session["Branch"].ToString()); 
                ddltype11.DataTextField = "Name1"; 
                ddltype11.DataValueField = "Code"; 
                ddltype11.DataSource = mytype.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString); 
                ddltype11.DataBind();
                ddltype11.Items.Insert(0, new ListItem("-- أختر نوع السيارة --", "-1", true));  

                Codes mycode = new Codes();

                mycode.Branch = short.Parse(Session["Branch"].ToString());
                mycode.Ftype = 1;
                ddlnat.DataTextField = "Name1";
                ddlnat.DataValueField = "Code";
                ddlnat.DataSource = mycode.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                ddlnat.DataBind();
                ddlnat.Items.Insert(0, new ListItem("-- أختر الجنسية --", "-1", true));

                Codes mycode2 = new Codes();

                mycode2.Branch = short.Parse(Session["Branch"].ToString());
                mycode2.Ftype = 8;
                ddlbank.DataTextField = "Name1";
                ddlbank.DataValueField = "Code";
                ddlbank.DataSource = mycode2.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                ddlbank.DataBind();
                ddlbank.Items.Insert(0, new ListItem("-- أختر البنك --", "-1", true)); */

                ddltype11.SelectedIndex = 0;
                ddlnat.SelectedIndex = 0;
                ddlbank.SelectedIndex = 0;
                //edited by hanan5 :to here

                txtSearch.Text = "";
                txtReason.Text = "";
                txtNumber.Text = "";
                txtname.Text = "";
                txtname2.Text = "";
                txtid.Text = "";
                txtidDate.Text = "";
                txtaddr.Text = "";
                txtmob.Text = "";
                ddlColor.SelectedIndex = -1;
                txtplate.Text = "";
                txtmodel.Text = ""; // edited by hanan2
                txtpercent.Text = ""; // edited by hanan5

                /*   ddldetail.Items.Clear(); // edited by hanan2
                   ddldetail.Items.Clear();
                   ddldetail.DataSource = null;
                   ddldetail.DataBind(); */

                CoDrivers mydr = new CoDrivers();
 
                int? myid = mydr.GetMax(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myid == 0 || myid == null)
                {
                    myid = 1;
                }
                else
                {
                    myid++;
                }

                txtNumber.Text = myid.ToString();

                CoDrivers mydr2 = new CoDrivers(); // edited by hanan11 : from here
                grdCodes.DataSource = null;
                grdCodes.DataBind();

                grdCodes.DataSource = mydr2.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                grdCodes.DataBind(); // edited by hanan11 : to here

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

                    CoDrivers mydr = new CoDrivers();
                    mydr.ID = int.Parse(txtNumber.Text);

                    mydr = mydr.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (mydr == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم السائق غير معرف من قبل";

                    }
                    else
                    {
                        mydr = new CoDrivers();
                        mydr.ID = int.Parse(txtNumber.Text);

                        if (mydr.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
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
            CoDrivers mydr = new CoDrivers();
            mydr.ID = int.Parse(txtSearch.Text);

            mydr = mydr.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (mydr == null)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "رقم السائق غير معرف من قبل";
            }
            else
            {
                txtNumber.Text = mydr.ID.ToString();
                //     if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان ترحيل", "عرض", "عرض بيان الترحيل رقم " + lblBranch.Text + "/" + txtNumber.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                //     EditMode();

                /*       string mycartype = ""; // edited by hanan2
                       if (mydr.DCareType < 10)
                           mycartype = "000" + mydr.DCareType.ToString();
                       else
                           mycartype = "00" + mydr.DCareType.ToString(); */
                ddltype11.SelectedValue = mydr.DCareType.ToString(); // edited by hanan2
                txtname.Text = mydr.Name1;
                txtname2.Text = mydr.Name2;
                txtid.Text = mydr.IDNo;
                txtidDate.Text = mydr.IDdate;
                ddlnat.SelectedValue = mydr.Nat.ToString();
                txtaddr.Text = mydr.Address;
                txtmob.Text = mydr.MobileNo;
                ddltype11.SelectedValue = mydr.DCareType.ToString();
                ddltype11_SelectedIndexChanged(sender, e);
                ddlColor.SelectedValue = mydr.DCarColor;
                txtplate.Text = mydr.DPlateNo;
                ddlbank.SelectedValue = mydr.Bank.ToString();
                txtiban.Text = mydr.IBan;
          //      mydr.ATM = "";
                ddltrans.SelectedValue = mydr.TransType.ToString();

                // ddltype11_SelectedIndexChanged(sender, e); // edited by hanan2
                txtmodel.Text = mydr.DCarModel; // edited by hanan2

            }

        }


    }
}