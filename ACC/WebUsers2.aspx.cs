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
using System.Web.UI.HtmlControls;


namespace ACC
{
    public partial class WebUsers2 : System.Web.UI.Page
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
        public string ImageUrl
        {
            get
            {
                if (ViewState["ImageUrl"] == null)
                {
                    ViewState["ImageUrl"] = "";
                }
                return ViewState["ImageUrl"].ToString();
            }
            set { ViewState["ImageUrl"] = value; }
        }
        public List<Order> MyOrders
        {
            get
            {
                if (ViewState["MyOrders"] == null)
                {
                    ViewState["MyOrders"] = new List<Order>();
                }
                return (List<Order>)ViewState["MyOrders"];
            }
            set { ViewState["MyOrders"] = value; }
        }

        public List<Transactions> MyTransactions
        {
            get
            {
                if (ViewState["MyTransactions"] == null)
                {
                    ViewState["MyTransactions"] = new List<Transactions>();
                }
                return (List<Transactions>)ViewState["MyTransactions"];
            }
            set { ViewState["MyTransactions"] = value; }
        }


        public List<Notification> MyNotiy
        {
            get
            {
                if (ViewState["MyNotiy"] == null)
                {
                    ViewState["MyNotiy"] = new List<Notification>();
                }
                return (List<Notification>)ViewState["MyNotiy"];
            }
            set { ViewState["MyNotiy"] = value; }
        }


        public void EditMode()
        {
            txtName.ReadOnly = true;
            txtName.BackColor = System.Drawing.Color.LightGray;

            BtnEdit.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass192;
            BtnNew.Visible = false;
            BtnDelete.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass193;

            if (BtnEdit.Visible || BtnDelete.Visible)
            {
                txtReason.Visible = true;
                ValReason.Enabled = true;
                lblReason.Visible = true;
            }
        }

        public void NewMode()
        {
            txtName.ReadOnly = false;
            txtName.BackColor = System.Drawing.Color.White;

            BtnEdit.Visible = false;
            BtnNew.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass191;
            BtnDelete.Visible = false;

            txtReason.Visible = false;
            ValReason.Enabled = false;
            lblReason.Visible = false;
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
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad0);
                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "مستخدمين الأجهزة الذكية";
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

                    MyConfig mysetting = new MyConfig();
                    mysetting.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mysetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    mysetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                    if (mysetting != null)
                    {
                        ImageUrl = mysetting.ImagePath2;
                    }

                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = "الرئيسية";
                        UserTran.FormAction = "اختيار";
                        UserTran.Description = "تم اختيار صفحة مستخدمين الأجهزة الذكية";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass191;
                    BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass192;
                    BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass193;
                    BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass194;

                    CostCenter myCostCenter = new CostCenter();
                    myCostCenter.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlSites.DataTextField = "Name1";
                    ddlSites.DataValueField = "Code";
                    ddlSites.DataSource = (from sitm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                           orderby sitm.Name1
                                           select sitm).ToList();
                    ddlSites.DataBind();
                    ddlSites.Items.Insert(0, new ListItem("--- أختار الفرع ---", "-1", true));

                    ddlNat.DataTextField = "Name1";
                    ddlNat.DataValueField = "Code";
                    Codes myCode = new Codes();
                    myCode.Branch = short.Parse(Session["Branch"].ToString());
                    myCode.Ftype = 1;
                    if (Cache["LastCodes" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCodes" + Session["CNN2"].ToString(), myCode.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlNat.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                         where itm.Ftype == 1
                                         select itm).ToList();
                    ddlNat.DataBind();
                    ddlNat.Items.Insert(0, new ListItem("---  أختر الجنسية  ---", "-1", true));

                    CarType myCarType = new CarType();
                    myCarType.cnn = WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString;
                    myCarType.Branch = short.Parse(Session["Branch"].ToString());
                    myCarType.FCode = "";
                    ddlDCareType.DataTextField = "Name1";
                    ddlDCareType.DataValueField = "Code";
                    ddlDCareType.DataSource = myCarType.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlDCareType.DataBind();
                    ddlDCareType.Items.Insert(0, new ListItem("--- أختر النوع ---", "-1", true));

                    LoadUsersData();
                    DisplayNotify();
                    DisplayOrders();
                    DisplayUserLog();

                    ddlAccType_SelectedIndexChanged(sender, e);
                    NewMode();
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

        protected void LoadUsersData()
        {
            try
            {
                if (ddlAccType.SelectedIndex == 0)
                {
                    ShipDrivers myuser = new ShipDrivers();
                    grdCodes.DataSource = (from itm in myuser.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                           orderby itm.ID
                                           select itm).ToList();
                    grdCodes.DataBind();
                }
                else if (ddlAccType.SelectedIndex == 1)
                {                    
                    ShipUsers myuser = new ShipUsers();
                    grdCodes.DataSource = (from itm in myuser.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                           orderby itm.ID
                                           select itm).ToList();
                    grdCodes.DataBind();
                }
                else if (ddlAccType.SelectedIndex == 2)
                {
                    grdCodes.DataSource = null;
                    grdCodes.DataBind();
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
            NewMode();
            txtReason.Text = "";
            BtnLoad0.ToolTip = "";
            BtnView01.ToolTip = "";
            BtnView02.ToolTip = "";
            BtnView03.ToolTip = "";
            BtnView04.ToolTip = "";
            BtnView01.Attributes.Remove("onclick");
            BtnView02.Attributes.Remove("onclick");
            BtnView03.Attributes.Remove("onclick");
            BtnView04.Attributes.Remove("onclick");
            txtFName.Text = "";
            txtLName.Text = "";
            txtMobileNo.Text = "";
            txtIDNo.Text = "";
            txtMobileNo.Text = "";
            txtName.Text = "";
            txtName.ToolTip = "";
            txtPassword.Text = "";
            txtPassword2.Text = "";
            txtPassword.ToolTip = "";
            txtPassword2.ToolTip = "";
            txtPassword.Attributes.Add("value", "");
            txtPassword2.Attributes.Add("value", "");
            txtSearch.Text = "";
            txtAcceptRate.Text = "";
            txtAccountName01.Text = "";
            txtAccountName02.Text = "";
            txtAccountName03.Text = "";
            txtAccountName04.Text = "";
            txtAccountNo01.Text = "";
            txtAccountNo02.Text = "";
            txtAccountNo03.Text = "";
            txtAccountNo04.Text = "";
            txtEmail.Text = "";
            txtApp_Version.Text = "";
            txtCountryCode.Text = "";
            txtBal.Text = "";
            txtCardType.Text = "";
            txtCarOwner.Text = "";
            txtDateofBirth.Text = "";
            txtDCarColor.Text = "";
            txtDevice_Label.Text = "";
            txtDevice_Name.Text = "";
            txtDevice_OS_Version.Text = "";
            txtDevice_Type.Text = "";
            txtDPlateNo.Text = "";
            txtNotify.Text = "";
            txtPHDate1.Text = "";
            txtPHDate2.Text = "";
            txtPHDate3.Text = "";
            txtPHDate4.Text = "";
            txtWorkRate.Text = "";
            txtOdacc.Text = "";
            txtOcacc.Text = "";

            ChkOnLine.Checked = false;
            ChkActive.Checked = false;
            ChkVersion.Checked = false;
            ChkAccount01.Checked = false;
            ChkAccount02.Checked = false;
            ChkAccount03.Checked = false;
            ChkAccount04.Checked = false;

            ddlAccType.SelectedIndex = 0;
            txtAccount.Text = "";
            //ddlDCareType.SelectedIndex = 0;
            //ddlDCarModel.SelectedIndex = 0;
            txtDCarType.Text = "";
            txtDCarModel.Text = "";
            ddlILang.SelectedIndex = 0;
            txtNat.Text = "";
            //ddlNat.SelectedIndex = 0;
            //ddlSites.SelectedIndex = 0;
            ImgPhoto.Src = "images/123.jpg";

            for (int i = 0; i < ChkRoles.Items.Count; i++)
            {
                ChkRoles.Items[i].Selected = false;
            }

            DivDriverDetails.Visible = false;
            txtCarWeight.Text = "";
            txtReason.Text = "";
            LoadAttachData();

            txtAccountName02.Visible = false;
            txtAccountName03.Visible = false;
            txtAccountName04.Visible = false;
            txtAccountNo02.Visible = false;
            txtAccountNo03.Visible = false;
            txtAccountNo04.Visible = false;
            lblAccount02.Visible = false;
            lblAccount03.Visible = false;
            lblAccount04.Visible = false;
            ChkAccount02.Visible = false;
            ChkAccount03.Visible = false;
            ChkAccount04.Visible = false;
            BtnView02.Visible = false;
            BtnView03.Visible = false;
            BtnView04.Visible = false;
            RdoGender.Items[0].Selected = true;
        }

        public void ControlsOnOff(bool State)
        {
            txtReason.ReadOnly = !State;
            txtFName.ReadOnly = !State;
            txtLName.ReadOnly = !State;
            txtMobileNo.ReadOnly = !State;
            txtIDNo.ReadOnly = !State;
            txtMobileNo.ReadOnly = !State;
            txtName.ReadOnly = !State;
            txtPassword.ReadOnly = !State;
            txtPassword2.ReadOnly = !State;
            txtAcceptRate.ReadOnly = !State;
            txtAccountName01.ReadOnly = !State;
            txtAccountName02.ReadOnly = !State;
            txtAccountName03.ReadOnly = !State;
            txtAccountName04.ReadOnly = !State;
            txtAccountNo01.ReadOnly = !State;
            txtAccountNo02.ReadOnly = !State;
            txtAccountNo03.ReadOnly = !State;
            txtAccountNo04.ReadOnly = !State;
            txtApp_Version.ReadOnly = !State;
            txtBal.ReadOnly = !State;
            txtCardType.ReadOnly = !State;
            txtCarOwner.ReadOnly = !State;
            txtDateofBirth.ReadOnly = !State;
            txtDCarColor.ReadOnly = !State;
            txtDevice_Label.ReadOnly = !State;
            txtDevice_Name.ReadOnly = !State;
            txtDevice_OS_Version.ReadOnly = !State;
            txtDevice_Type.ReadOnly = !State;
            txtDPlateNo.ReadOnly = !State;
            txtNotify.ReadOnly = !State;
            txtPHDate1.ReadOnly = !State;
            txtPHDate2.ReadOnly = !State;
            txtPHDate3.ReadOnly = !State;
            txtPHDate4.ReadOnly = !State;
            txtWorkRate.ReadOnly = !State;
            txtCountryCode.ReadOnly = !State;
            txtEmail.ReadOnly = !State;
            ChkOnLine.Enabled = State;
            ChkActive.Enabled = State;
            ChkVersion.Enabled = State;
            ChkAccount01.Enabled = State;
            ChkAccount02.Enabled = State;
            ChkAccount03.Enabled = State;
            ChkAccount04.Enabled = State;

            ddlAccType.Enabled = State;
            ddlDCareType.Enabled = State;
            ddlDCarModel.Enabled = State;
            txtDCarType.ReadOnly = !State;
            txtDCarModel.ReadOnly = !State;
            ddlILang.Enabled = State;
            ddlNat.Enabled = State;
            txtNat.ReadOnly = !State;
            ddlSites.Enabled = State;
            ChkRoles.Enabled = State;
            txtCarWeight.ReadOnly = !State;
            txtAccountName02.ReadOnly = !State;
            txtAccountName03.ReadOnly = !State;
            txtAccountName04.ReadOnly = !State;
            txtAccountNo02.ReadOnly = !State;
            txtAccountNo03.ReadOnly = !State;
            txtAccountNo04.ReadOnly = !State;

            ChkAccount02.Enabled = State;
            ChkAccount03.Enabled = State;
            ChkAccount04.Enabled = State;
            BtnView02.Enabled = State;
            BtnView03.Enabled = State;
            BtnView04.Enabled = State;
            BtnLoad0.Enabled = State;
            foreach (GridViewRow itm in grdAttach.Rows)
            {
                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                if (BtnDelete != null) BtnDelete.Visible = State;
            }
            FileUpload1.Enabled = State;
            BtnAttach.Enabled = State;
            RdoGender.Enabled = State;
        }


        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    // Check User Have Role
                    bool vFound = false;
                    string vRole = "";

                    // Check Password 
                    if (txtPassword.Text == "")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب إدخال كلمة السر";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    if (txtPassword.Text != txtPassword2.Text)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "كلمة السر غير مطابقة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    // Check if User Exists
                    if (ddlAccType.SelectedIndex == 0)
                    {
                        for (int i = 0; i < ChkRoles.Items.Count; i++)
                        {
                            if (ChkRoles.Items[i].Selected)
                            {
                                if (vRole == "") vRole = ChkRoles.Items[i].Value;
                                else vRole += ";" + ChkRoles.Items[i].Value;
                                vFound = true;
                                //break;
                            }
                        }
                        if (!vFound)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "يجب أن ينضم المستخدم لخدمة من الخدمات";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                        ShipDrivers myUser = new ShipDrivers();
                        myUser.ID = txtName.Text;
                        myUser = myUser.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myUser != null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "اسم المستخدم مدخل من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            myUser = new ShipDrivers();
                            myUser.ID = txtName.Text;
                            myUser.Password = txtPassword.Text;
                            myUser.FirstName = txtFName.Text;
                            myUser.LastName = txtLName.Text;
                            myUser.MobileNo = txtMobileNo.Text;
                            myUser.CountryCode = txtCountryCode.Text;
                            myUser.IDNo = txtIDNo.Text;
                            myUser.UserType = (short)(ChkVersion.Checked ? 1 : 0);
                            myUser.LoginType = 0; // 2;            
                            myUser.Photo = BtnLoad0.ToolTip;
                            myUser.Online = (short)(ChkOnLine.Checked ? 1: 0);
                            //myUser.DCareType = ddlDCareType.SelectedValue;
                            //myUser.DCarModel = ddlDCarModel.SelectedValue;
                            //myUser.DCareType = txtDCarType.Text;
                            myUser.DCarModel = txtDCarModel.Text;
                            myUser.DPlateNo = txtDPlateNo.Text;
                            myUser.DCarColor = txtDCarColor.Text;
                            myUser.CardType = moh.StrToShort(txtCardType.Text);
                            //myUser.Account = ddlAccount.SelectedValue;
                            myUser.OrdID = ddlSites.SelectedValue;
                            myUser.OrdTemp = vRole;
                            myUser.ILang = ddlILang.SelectedValue;
                            // Rate
                            myUser.Email = txtEmail.Text;
                            myUser.Gender = (RdoGender.Items[0].Selected ? "0" : "1");
                            myUser.DateofBirth = txtDateofBirth.Text;
                            //myUser.Nationality = ddlNat.SelectedValue;
                            myUser.Nationality = txtNat.Text;
                            myUser.YearofRegistration = txtPHDate2.Text;
                            myUser.CarRegistration = txtPHDate1.Text;
                            myUser.Current_Device.device_label = txtDevice_Label.Text;
                            myUser.Current_Device.device_os_version = txtDevice_OS_Version.Text;
                            myUser.Current_Device.device_name = txtDevice_Name.Text;
                            myUser.Current_Device.device_type = txtDevice_Type.Text;
                            myUser.Current_Device.app_version = txtApp_Version.Text;
                            myUser.BankAcc01 = ChkAccount01.Checked;
                            myUser.BankAcc02 = ChkAccount02.Checked;
                            myUser.BankAcc03 = ChkAccount03.Checked;
                            myUser.BankAcc04 = ChkAccount04.Checked;
                            myUser.BankAcc1 = txtAccountNo01.Text;
                            myUser.BankAcc2 = txtAccountNo02.Text;
                            myUser.BankAcc3 = txtAccountNo03.Text;
                            myUser.BankAcc4 = txtAccountNo04.Text;
                            myUser.AccountName1 = txtAccountName01.Text;
                            myUser.AccountName2 = txtAccountName02.Text;
                            myUser.AccountName3 = txtAccountName03.Text;
                            myUser.AccountName4 = txtAccountName04.Text;
                            myUser.AccountImage1 = BtnView01.ToolTip;
                            myUser.AccountImage2 = BtnView02.ToolTip;
                            myUser.AccountImage3 = BtnView03.ToolTip;
                            myUser.AccountImage4 = BtnView04.ToolTip;
                            myUser.CarOwner = txtCarOwner.Text;
                            myUser.PHDate3 = txtPHDate3.Text;
                            myUser.PHDate4 = txtPHDate4.Text;
                            myUser.odacc = moh.StrToDouble(txtOdacc.Text);
                            myUser.ocacc = moh.StrToDouble(txtOcacc.Text);
                            myUser.CarWeight = moh.StrToDouble(txtCarWeight.Text);

                            if (myUser.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                                {
                                    Transactions UserTran = new Transactions();
                                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                    UserTran.UserName = Session["CurrentUser"].ToString();
                                    UserTran.FormName = "مستخدمي الاجهزة الذكية";
                                    UserTran.FormAction = "اضافة";
                                    UserTran.Description = "اضافة بيانات المستخدم " + txtName.Text;
                                    UserTran.IP = IPNetworking.GetIP4Address();
                                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                }

                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                                BtnClear_Click(sender, e);
                                LoadUsersData();
                            }
                            else
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ اثناء أضافة البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            }
                        }
                    }
                    else if (ddlAccType.SelectedIndex == 1)
                    {
                        ShipUsers myUser = new ShipUsers();
                        myUser.ID = txtName.Text;
                        myUser = myUser.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myUser != null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "اسم المستخدم مدخل من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            myUser = new ShipUsers();
                            myUser.ID = txtName.Text;
                            myUser.Password = txtPassword.Text;
                            myUser.FirstName = txtFName.Text;
                            myUser.LastName = txtLName.Text;
                            myUser.MobileNo = txtMobileNo.Text;
                            myUser.CountryCode = txtCountryCode.Text;
                            myUser.IDNo = txtIDNo.Text;
                            myUser.UserType = (short)(ChkVersion.Checked ? 1 : 0);
                            myUser.LoginType = 0; // 2;                        
                            myUser.Photo = BtnLoad0.ToolTip;
                            myUser.Online = (short)(ChkOnLine.Checked ? 1 : 0);
                            //myUser.Account = ddlAccount.SelectedValue;
                            myUser.ILang = ddlILang.SelectedValue;
                            // Rate
                            myUser.Email = txtEmail.Text;
                            myUser.Current_Device.device_label = txtDevice_Label.Text;
                            myUser.Current_Device.device_os_version = txtDevice_OS_Version.Text;
                            myUser.Current_Device.device_name = txtDevice_Name.Text;
                            myUser.Current_Device.device_type = txtDevice_Type.Text;
                            myUser.Current_Device.app_version = txtApp_Version.Text;
                            myUser.odacc = moh.StrToDouble(txtOdacc.Text);
                            myUser.ocacc = moh.StrToDouble(txtOcacc.Text);

                            if (myUser.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                                {
                                    Transactions UserTran = new Transactions();
                                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                    UserTran.UserName = Session["CurrentUser"].ToString();
                                    UserTran.FormName = "مستخدمي الاجهزة الذكية";
                                    UserTran.FormAction = "اضافة";
                                    UserTran.Description = "اضافة بيانات المستخدم " + txtName.Text;
                                    UserTran.IP = IPNetworking.GetIP4Address();
                                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                }

                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                                BtnClear_Click(sender, e);
                                LoadUsersData();
                            }
                            else
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ اثناء أضافة البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            }
                        }
                    }
                    else
                    {

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
                    // Check User Have Role
                    bool vFound = false;
                    string vRole = "";

                    // Check Password 
                    if (txtPassword.Text == "" || txtPassword2.Text == "")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب إدخال كلمة السر";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    if (txtPassword.Text != txtPassword2.Text)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "كلمة السر غير مطابقة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    // Check if User Exists
                    if (ddlAccType.SelectedIndex == 0)
                    {
                        for (int i = 0; i < ChkRoles.Items.Count; i++)
                        {
                            if (ChkRoles.Items[i].Selected)
                            {
                                if (vRole == "") vRole = ChkRoles.Items[i].Value;
                                else vRole += ";" + ChkRoles.Items[i].Value;
                                vFound = true;
                                //break;
                            }
                        }
                        if (!vFound)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "يجب أن ينضم المستخدم لخدمة من الخدمات";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                        // Check if User Exists
                        ShipDrivers myUser = new ShipDrivers();
                        myUser.ID = txtName.Text;
                        myUser = myUser.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myUser == null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "اسم المستخدم غير مدرج من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            myUser.Password = txtPassword.Text;
                            myUser.FirstName = txtFName.Text;
                            myUser.LastName = txtLName.Text;
                            myUser.MobileNo = txtMobileNo.Text;
                            myUser.CountryCode = txtCountryCode.Text;
                            myUser.IDNo = txtIDNo.Text;
                            myUser.UserType = (short)(ChkVersion.Checked ? 1 : 0);
                            myUser.LoginType = 0; // 2;            
                            myUser.Photo = BtnLoad0.ToolTip;
                            myUser.Online = (short)(ChkOnLine.Checked ? 1 : 0);
                            //myUser.DCareType = ddlDCareType.SelectedValue;
                            //myUser.DCarModel = ddlDCarModel.SelectedValue;
                            //myUser.DCareType = txtDCarType.Text;
                            myUser.DCarModel = txtDCarModel.Text;
                            myUser.DPlateNo = txtDPlateNo.Text;
                            myUser.DCarColor = txtDCarColor.Text;
                            myUser.CardType = moh.StrToShort(txtCardType.Text);
                            //myUser.Account = ddlAccount.SelectedValue;
                            myUser.OrdID = ddlSites.SelectedValue;
                            myUser.OrdTemp = vRole;
                            myUser.ILang = ddlILang.SelectedValue;
                            // Rate
                            myUser.Email = txtEmail.Text;
                            myUser.Gender = (RdoGender.Items[0].Selected ? "0" : "1");
                            myUser.DateofBirth = txtDateofBirth.Text;
                            //myUser.Nationality = ddlNat.SelectedValue;
                            myUser.Nationality = txtNat.Text;
                            myUser.YearofRegistration = txtPHDate2.Text;
                            myUser.CarRegistration = txtPHDate1.Text;
                            myUser.Current_Device.device_label = txtDevice_Label.Text;
                            myUser.Current_Device.device_os_version = txtDevice_OS_Version.Text;
                            myUser.Current_Device.device_name = txtDevice_Name.Text;
                            myUser.Current_Device.device_type = txtDevice_Type.Text;
                            myUser.Current_Device.app_version = txtApp_Version.Text;
                            myUser.BankAcc01 = ChkAccount01.Checked;
                            myUser.BankAcc02 = ChkAccount02.Checked;
                            myUser.BankAcc03 = ChkAccount03.Checked;
                            myUser.BankAcc04 = ChkAccount04.Checked;
                            myUser.BankAcc1 = txtAccountNo01.Text;
                            myUser.BankAcc2 = txtAccountNo02.Text;
                            myUser.BankAcc3 = txtAccountNo03.Text;
                            myUser.BankAcc4 = txtAccountNo04.Text;
                            myUser.AccountName1 = txtAccountName01.Text;
                            myUser.AccountName2 = txtAccountName02.Text;
                            myUser.AccountName3 = txtAccountName03.Text;
                            myUser.AccountName4 = txtAccountName04.Text;
                            myUser.AccountImage1 = BtnView01.ToolTip;
                            myUser.AccountImage2 = BtnView02.ToolTip;
                            myUser.AccountImage3 = BtnView03.ToolTip;
                            myUser.AccountImage4 = BtnView04.ToolTip;
                            myUser.CarOwner = txtCarOwner.Text;
                            myUser.PHDate3 = txtPHDate3.Text;
                            myUser.PHDate4 = txtPHDate4.Text;
                            myUser.CarWeight = moh.StrToDouble(txtCarWeight.Text);
                            myUser.odacc = moh.StrToDouble(txtOdacc.Text);
                            myUser.ocacc = moh.StrToDouble(txtOcacc.Text);

                            if (myUser.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                                {
                                    Transactions UserTran = new Transactions();
                                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                    UserTran.UserName = Session["CurrentUser"].ToString();
                                    UserTran.FormName = "مستخدمي الاجهزة الذكية";
                                    UserTran.FormAction = "تعديل";
                                    UserTran.Description = "تعديل بيانات المستخدم " + txtName.Text;
                                    UserTran.Reason = txtReason.Text;
                                    UserTran.IP = IPNetworking.GetIP4Address();
                                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                }
                                txtReason.Text = "";

                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                                BtnClear_Click(sender, e);
                                LoadUsersData();
                            }
                            else
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ اثناء تعديل البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            }
                        }
                    }
                    else if (ddlAccType.SelectedIndex == 1)
                    {

                        // Check if User Exists
                        ShipUsers myUser = new ShipUsers();
                        myUser.ID = txtName.Text;
                        myUser = myUser.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myUser == null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "اسم المستخدم غير مدرج من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            myUser.Password = txtPassword.Text;
                            myUser.FirstName = txtFName.Text;
                            myUser.LastName = txtLName.Text;
                            myUser.MobileNo = txtMobileNo.Text;
                            myUser.CountryCode = txtCountryCode.Text;
                            myUser.IDNo = txtIDNo.Text;
                            myUser.UserType = (short)(ChkVersion.Checked ? 1 : 0);
                            myUser.LoginType = 0; // 2;                        
                            myUser.Photo = BtnLoad0.ToolTip;
                            myUser.Online = (short)(ChkOnLine.Checked ? 1 : 0);
                            //myUser.Account = ddlAccount.SelectedValue;
                            myUser.ILang = ddlILang.SelectedValue;
                            // Rate
                            myUser.Email = txtEmail.Text;
                            myUser.Current_Device.device_label = txtDevice_Label.Text;
                            myUser.Current_Device.device_os_version = txtDevice_OS_Version.Text;
                            myUser.Current_Device.device_name = txtDevice_Name.Text;
                            myUser.Current_Device.device_type = txtDevice_Type.Text;
                            myUser.Current_Device.app_version = txtApp_Version.Text;
                            myUser.odacc = moh.StrToDouble(txtOdacc.Text);
                            myUser.ocacc = moh.StrToDouble(txtOcacc.Text);
                            if (myUser.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                                {
                                    Transactions UserTran = new Transactions();
                                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                    UserTran.UserName = Session["CurrentUser"].ToString();
                                    UserTran.FormName = "مستخدمي الاجهزة الذكية";
                                    UserTran.FormAction = "تعديل";
                                    UserTran.Description = "تعديل بيانات المستخدم " + txtName.Text;
                                    UserTran.Reason = txtReason.Text;
                                    UserTran.IP = IPNetworking.GetIP4Address();
                                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                }
                                txtReason.Text = "";

                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                                BtnClear_Click(sender, e);
                                LoadUsersData();
                            }
                            else
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ اثناء تعديل البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            }
                        }
                    }
                    else
                    {

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
                    if (ddlAccType.SelectedIndex == 0)
                    {
                        // Check if User Exists
                        ShipDrivers myUser = new ShipDrivers();
                        myUser.ID = txtName.Text;
                        myUser = myUser.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myUser == null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "اسم المستخدم غير مدرج من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            if (myUser.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                                {
                                    Transactions UserTran = new Transactions();
                                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                    UserTran.UserName = Session["CurrentUser"].ToString();
                                    UserTran.FormName = "مستخدمي الاجهزة الذكية";
                                    UserTran.FormAction = "الغاء";
                                    UserTran.Description = "الغاء بيانات المستخدم " + txtName.Text;
                                    UserTran.Reason = txtReason.Text;
                                    UserTran.IP = IPNetworking.GetIP4Address();
                                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                }
                                txtReason.Text = "";

                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم الغاء البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                                BtnClear_Click(sender, e);
                                LoadUsersData();
                            }
                            else
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ اثناء الغاء البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            }
                        }
                    }
                    else if (ddlAccType.SelectedIndex == 1)
                    {
                        // Check if User Exists
                        ShipUsers myUser = new ShipUsers();
                        myUser.ID = txtName.Text;
                        myUser = myUser.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myUser == null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "اسم المستخدم غير مدرج من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            if (myUser.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                                {
                                    Transactions UserTran = new Transactions();
                                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                    UserTran.UserName = Session["CurrentUser"].ToString();
                                    UserTran.FormName = "مستخدمي الاجهزة الذكية";
                                    UserTran.FormAction = "الغاء";
                                    UserTran.Description = "الغاء بيانات المستخدم " + txtName.Text;
                                    UserTran.Reason = txtReason.Text;
                                    UserTran.IP = IPNetworking.GetIP4Address();
                                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                }
                                txtReason.Text = "";

                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم الغاء البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                                BtnClear_Click(sender, e);
                                LoadUsersData();
                            }
                            else
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ اثناء الغاء البيانات ... حاول مرة أخرى";
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
                }
                else if (txtName.Text != "")
                {
                    // Check if User Exists
                    if (ddlAccType.SelectedIndex == 0)
                    {
                        ShipDrivers myUser = new ShipDrivers();
                        myUser.ID = txtName.Text;
                        myUser = myUser.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myUser == null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "اسم المستخدم غير مدرج من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.FormName = "مستخدمي الاجهزة الذكية";
                                UserTran.FormAction = "عرض";
                                UserTran.Description = "عرض بيانات المستخدم " + txtName.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }
                            BtnClear_Click(sender, e);
                            EditMode();
                            ddlAccType.SelectedIndex = 0;
                            ddlAccType_SelectedIndexChanged(sender, e);
                            txtName.Text = myUser.ID;
                            txtName.ToolTip = myUser.Num.ToString();
                            txtAccount.Text = myUser.Num.ToString();
                            txtOdacc.Text = string.Format("{0:N2}", myUser.odacc);
                            txtOcacc.Text = string.Format("{0:N2}", myUser.ocacc);
                            txtFName.Text = myUser.FirstName;
                            txtLName.Text = myUser.LastName;
                            txtMobileNo.Text = myUser.MobileNo;
                            txtPassword.Text = myUser.Password;
                            txtPassword.ToolTip = myUser.Password;
                            txtPassword.Attributes.Add("value", myUser.Password);
                            txtPassword2.Text = myUser.Password;
                            txtPassword2.Attributes.Add("value", myUser.Password);
                            txtPassword2.ToolTip = myUser.Password;
                            txtIDNo.Text = myUser.IDNo;
                            txtCountryCode.Text = myUser.CountryCode;
                            ChkVersion.Checked = (myUser.UserType == 1);
                            BtnLoad0.ToolTip = "";
                            if (!string.IsNullOrEmpty(myUser.Photo))
                            {
                                BtnLoad0.ToolTip = myUser.Photo;
                                string url = @"http://Naqelat.net/" + myUser.Photo;
                                ImgPhoto.Src = url;
                            }
                            else ImgPhoto.Src = "images/123.jpg";
                            ChkOnLine.Checked = (myUser.Online == 1);
                            //ddlDCareType.SelectedValue = myUser.DCareType;
                            //ddlDCarModel.SelectedValue = myUser.DCarModel;
                            txtDCarType.Text = myUser.DCareType.ToString();
                            txtDCarModel.Text = myUser.DCarModel;
                            txtDPlateNo.Text = myUser.DPlateNo;
                            txtDCarColor.Text = myUser.DCarColor;
                            txtCardType.Text = myUser.CardType.ToString();
                            //ddlAccount.SelectedValue = myUser.Account;
                            if (string.IsNullOrEmpty(myUser.OrdID)) myUser.OrdID = "-1";
                            ddlSites.SelectedValue = myUser.OrdID;
                            for (int i = 0; i < ChkRoles.Items.Count; i++)
                            {
                                if (myUser.OrdTemp.Contains(ChkRoles.Items[i].Value))
                                {
                                    ChkRoles.Items[i].Selected = true;
                                }
                            }
                            ddlILang.SelectedValue = myUser.ILang;
                            MyRate.CurrentRating = (int)myUser.MyRate;
                            txtEmail.Text = myUser.Email;
                            if (myUser.Gender == "0" || myUser.Gender == "") RdoGender.Items[0].Selected = true;
                            else RdoGender.Items[1].Selected = true;
                            txtDateofBirth.Text = myUser.DateofBirth;
                            //ddlNat.SelectedValue = myUser.Nationality;
                            txtNat.Text = myUser.Nationality;
                            txtPHDate2.Text = myUser.YearofRegistration;
                            txtPHDate1.Text = myUser.CarRegistration;
                            txtDevice_Label.Text = myUser.Current_Device.device_label;
                            txtDevice_OS_Version.Text = myUser.Current_Device.device_os_version;
                            txtDevice_Name.Text = myUser.Current_Device.device_name;
                            txtDevice_Type.Text = myUser.Current_Device.device_type;
                            txtApp_Version.Text = myUser.Current_Device.app_version;

                            ChkAccount01.Checked = (bool)myUser.BankAcc01;
                            ChkAccount02.Checked = (bool)myUser.BankAcc02;
                            ChkAccount03.Checked = (bool)myUser.BankAcc03;
                            ChkAccount04.Checked = (bool)myUser.BankAcc04;
                            txtAccountNo01.Text = myUser.BankAcc1;
                            txtAccountNo02.Text = myUser.BankAcc2;
                            txtAccountNo03.Text = myUser.BankAcc3;
                            txtAccountNo04.Text = myUser.BankAcc4;
                            txtAccountName01.Text = myUser.AccountName1;
                            txtAccountName02.Text = myUser.AccountName2;
                            txtAccountName03.Text = myUser.AccountName3;
                            txtAccountName04.Text = myUser.AccountName4;
                            
                            BtnView01.ToolTip = myUser.AccountImage1;
                            BtnView02.ToolTip = myUser.AccountImage2;
                            BtnView03.ToolTip = myUser.AccountImage3;
                            BtnView04.ToolTip = myUser.AccountImage4;

                            if (!string.IsNullOrEmpty(myUser.AccountImage1))
                            {
                                string url = @"http://Naqelat.net/" + myUser.AccountImage1;
                                BtnView01.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                                BtnView01.Attributes.Add("onclick", "window.open('" + url + "')");
                                BtnView01.Visible = true;
                            }
                            else
                            {
                                BtnView01.Attributes.Remove("onclick");
                                BtnView01.Visible = false;
                            }

                            if (!string.IsNullOrEmpty(myUser.AccountImage2))
                            {
                                string url = @"http://Naqelat.net/" + myUser.AccountImage2;
                                BtnView02.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                                BtnView02.Attributes.Add("onclick", "window.open('" + url + "')");
                                BtnView02.Visible = true;
                            }
                            else
                            {
                                BtnView02.Attributes.Remove("onclick");
                                BtnView02.Visible = false;
                            }

                            if (!string.IsNullOrEmpty(myUser.AccountImage3))
                            {
                                string url = @"http://Naqelat.net/" + myUser.AccountImage3;
                                BtnView03.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                                BtnView03.Attributes.Add("onclick", "window.open('" + url + "')");
                                BtnView03.Visible = true;
                            }
                            else
                            {
                                BtnView03.Attributes.Remove("onclick");
                                BtnView03.Visible = false;
                            }

                            if (!string.IsNullOrEmpty(myUser.AccountImage4))
                            {
                                string url = @"http://Naqelat.net/" + myUser.AccountImage4;
                                BtnView04.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                                BtnView04.Attributes.Add("onclick", "window.open('" + url + "')");
                                BtnView04.Visible = true;
                            }
                            else
                            {
                                BtnView04.Attributes.Remove("onclick");
                                BtnView04.Visible = false;
                            }

                            txtCarOwner.Text = myUser.CarOwner;
                            txtPHDate3.Text = myUser.PHDate3;
                            txtPHDate4.Text = myUser.PHDate4;
                            txtCarWeight.Text = myUser.CarWeight.ToString();
                            if (txtAccountNo02.Text != "" || txtAccountName02.Text !="")
                            {
                                lblAccount02.Visible = true;
                                ChkAccount02.Visible = true;
                                txtAccountNo02.Visible = true;
                                txtAccountName02.Visible = true;
                            }
                            if (txtAccountNo03.Text != "" || txtAccountName03.Text != "")
                            {
                                lblAccount03.Visible = true;
                                ChkAccount03.Visible = true;
                                txtAccountNo03.Visible = true;
                                txtAccountName03.Visible = true;
                            }
                            if (txtAccountNo04.Text != "" || txtAccountName04.Text != "")
                            {
                                lblAccount04.Visible = true;
                                ChkAccount04.Visible = true;
                                txtAccountNo04.Visible = true;
                                txtAccountName04.Visible = true;
                            }

                            AppServices AppItem = new AppServices();
                            List<AppServices> lAppItem = new List<AppServices>();
                            lAppItem = AppItem.GetAll2(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString);

                            Order vOrder = new Order();
                            vOrder.IDdriver = myUser.MobileNo;
                            MyOrders = vOrder.GetByIDDriver(false, "Ar", WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString);
                            if (MyOrders != null)
                            {
                                foreach (Order itm in MyOrders)
                                {
                                    itm.CNN = WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString;
                                    itm.StatusName = moh.GetStatus(itm.Status, "Ar");
                                    itm.AppIcon = (from eitm in lAppItem
                                                   where eitm.ServiceCode == itm.OrderType.ToString()
                                                   select eitm.AppIcon).FirstOrDefault();
                                    itm.ServiceName = (from eitm in lAppItem
                                                       where eitm.ServiceCode == itm.OrderType.ToString()
                                                       select  eitm.Name1).FirstOrDefault();
                                }
                            }
                            DisplayOrders();
                            DisplayNotify();
                        }
                    }
                    else if (ddlAccType.SelectedIndex == 1)
                    {
                        ShipUsers myUser = new ShipUsers();
                        myUser.ID = txtName.Text;
                        myUser = myUser.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myUser == null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "اسم المستخدم غير مدرج من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.FormName = "مستخدمي الاجهزة الذكية";
                                UserTran.FormAction = "عرض";
                                UserTran.Description = "عرض بيانات المستخدم " + txtName.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }

                            BtnClear_Click(sender, e);
                            EditMode();
                            ddlAccType.SelectedIndex = 1;
                            ddlAccType_SelectedIndexChanged(sender, e);                            
                            txtName.Text = myUser.ID;
                            txtFName.Text = myUser.FirstName;
                            txtLName.Text = myUser.LastName;
                            txtMobileNo.Text = myUser.MobileNo;
                            txtPassword.Text = myUser.Password;
                            txtPassword.ToolTip = myUser.Password;
                            txtPassword.Attributes.Add("value", myUser.Password);
                            txtPassword2.Text = myUser.Password;
                            txtPassword2.Attributes.Add("value", myUser.Password);
                            txtPassword2.ToolTip = myUser.Password;
                            txtIDNo.Text = myUser.IDNo;
                            txtCountryCode.Text = myUser.CountryCode;
                            txtBal.Text = string.Format("{0:N2}", myUser.Bal);
                            ChkVersion.Checked = (myUser.UserType == 1);
                            BtnLoad0.ToolTip = "";
                            if (!string.IsNullOrEmpty(myUser.Photo))
                            {
                                BtnLoad0.ToolTip = myUser.Photo;
                                string url = @"http://Naqelat.net/" + myUser.Photo;
                                ImgPhoto.Src = url;
                            }
                            else ImgPhoto.Src = "images/123.jpg";                            
                            ChkOnLine.Checked = (myUser.Online == 1);
                            //ddlAccount.SelectedValue = myUser.Account;
                            MyRate.CurrentRating = (int)myUser.MyRate;
                            txtEmail.Text = myUser.Email;
                            txtDevice_Label.Text = myUser.Current_Device.device_label;
                            txtDevice_OS_Version.Text = myUser.Current_Device.device_os_version;
                            txtDevice_Name.Text = myUser.Current_Device.device_name;
                            txtDevice_Type.Text = myUser.Current_Device.device_type;
                            txtApp_Version.Text = myUser.Current_Device.app_version;

                            AppServices AppItem = new AppServices();
                            List<AppServices> lAppItem = new List<AppServices>();
                            lAppItem = AppItem.GetAll2(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString);

                            Order vOrder = new Order();
                            vOrder.UserName = myUser.MobileNo;
                            MyOrders = vOrder.GetByUserName(false, "Ar", WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString);
                            if (MyOrders != null)
                            {
                                foreach (Order itm in MyOrders)
                                {
                                    itm.CNN = WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString;
                                    itm.StatusName = moh.GetStatus(itm.Status, "Ar");
                                    itm.AppIcon = (from eitm in lAppItem
                                                   where eitm.ServiceCode == itm.OrderType.ToString()
                                                   select eitm.AppIcon).FirstOrDefault();
                                    itm.ServiceName = (from eitm in lAppItem
                                                       where eitm.ServiceCode == itm.OrderType.ToString()
                                                       select eitm.Name1).FirstOrDefault();
                                }
                            }
                            DisplayOrders();
                            DisplayNotify();
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

        protected void grdCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdCodes.PageIndex = e.NewPageIndex;
                LoadUsersData();
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

        protected void grdCodes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                string UserName = grdCodes.DataKeys[e.NewSelectedIndex]["ID"].ToString();
                if (UserName != null)
                {
                    txtName.Text = UserName;
                    BtnSearch_Click(sender, null);
                    e.NewSelectedIndex = -1;
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
                    e.NewSelectedIndex = -1;
                }
            }
        }

        protected void ddlAccType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlAccType.SelectedIndex == 0)
            {
                //ddlAccount.DataTextField = "Name2";
                //ddlAccount.DataValueField = "Code";
                //Drivers myDrive = new Drivers();
                //myDrive.Branch = short.Parse(Session["Branch"].ToString());
                //ddlAccount.DataSource = myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                //ddlAccount.DataBind();
                DivDriverDetails.Visible = true;

            }
            else if (ddlAccType.SelectedIndex == 1)
            {
                //ddlAccount.DataTextField = "EmpCode";
                //ddlAccount.DataValueField = "Name";

                //SEmp myemp = new SEmp();
                //ddlAccount.DataSource = myemp.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                //ddlAccount.DataBind();
                DivDriverDetails.Visible = false;
            }
            else if (ddlAccType.SelectedIndex == 2)
            {
                DivDriverDetails.Visible = false;
            }
            //ddlAccount.Items.Insert(0, new ListItem("أختر الحساب", "-1", true));
            LoadUsersData();
        }

        protected void ddlAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlAccount.SelectedIndex > 0)
            //{
            //    txtName.Text = ddlAccType.SelectedValue + ddlAccount.SelectedValue;
            //    if (ddlAccType.SelectedIndex == 0)
            //    {
            //        //ChkRoles.Items[0].Selected = true;
            //        Drivers myDrive = new Drivers();
            //        myDrive.Branch = short.Parse(Session["Branch"].ToString());
            //        myDrive.Code = ddlAccount.SelectedValue;
            //        myDrive = myDrive.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            //        if (myDrive != null)
            //        {
            //            txtIDNo.Text = myDrive.IqamaNo;
            //            txtMobileNo.Text = "966"+myDrive.MobileNo.Substring(1,9);
            //            txtPassword.Text = myDrive.MobileNo;
            //            txtPassword.ToolTip = myDrive.MobileNo;
            //            txtPassword.Attributes.Add("value", myDrive.MobileNo);
            //            txtPassword2.Text = myDrive.MobileNo;
            //            txtPassword2.Attributes.Add("value", myDrive.MobileNo);
            //            txtPassword2.ToolTip = myDrive.MobileNo;
            //            if (myDrive.Name2.Split(' ').Count() > 1)
            //            {
            //                txtFName.Text = myDrive.Name2.Split(' ')[0];
            //                txtLName.Text = myDrive.Name2.Split(' ')[1];
            //            }
            //        }
            //    }
            //}
        }

        protected void BtnSMS_Click(object sender, EventArgs e)
        {
            if (txtMobileNo.Text != "")
            {
                sms.SendMessage(@"UserName: " + txtName.Text + " Password: " + txtPassword.ToolTip + " Application URL : http://www.naqelat.com/android-debug.apk", "naqelat", txtMobileNo.Text);
                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                LblCodesResult.Text = "تم ارسال الرسالة بنجاح";
            }
            else
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يجب أدخال رقم الجوال";
            }
        }

        protected void BtnEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "")
            {
                string myAccess = @"<div dir='ltr'><table dir='ltr' width='95%' style='background-color:#FCFDC4;border:1px solid #F3F9B7' cellspacing='7' border='0'><thead><tr><th scope='col' >Exception</th><th scope='col'>Value</th></tr></thead><tbody>";
                myAccess += @"<tr><td style='width: 150px;'>User Name</td><td style=;width: 700px'>" + txtName.Text + @"</td></tr>";
                myAccess += @"<tr><td style='width: 150px;'>Password</td><td style=;width: 700px'>" + txtPassword.ToolTip + @"</td></tr>";
                myAccess += @"<tr><td style='width: 150px;'>Application URL</td><td style=;width: 700px'><a href='http://www.naqelat.com/android-debug.apk'>Click to Download Application</a>" + Request.ServerVariables["remote_addr"].ToString() + @"</td></tr>";
                myAccess += @"</tbody></table></div>";
                moh.SendEmail(txtEmail.Text, myAccess, "نظام الناقلات البرية على الاجهزة الذكية ", null);
                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                LblCodesResult.Text = "تم ارسال الايميل بنجاح";
            }
            else
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يجب إدخال الايميل";
            }
        }

        protected void MyRate_Changed(object sender, AjaxControlToolkit.RatingEventArgs e)
        {

        }

        protected void BtnAttach_Click(object sender, ImageClickEventArgs e)
        {
            if (FileUpload1.HasFile && txtName.ToolTip != "")
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
                        myArch.LocNumber = 19;
                        myArch.Number = int.Parse(txtName.ToolTip);
                        myArch.DocType = (ddlAccType.SelectedIndex == 0 ? 750 : ddlAccType.SelectedIndex == 1 ? 751 : 752);

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = 19;
                        myArch.Number = int.Parse(txtName.ToolTip);
                        myArch.DocType = (ddlAccType.SelectedIndex == 0 ? 750 : ddlAccType.SelectedIndex == 1 ? 751 : 752);
                        myArch.FileName = FileUpload1.FileName;
                        myArch.FileName2 = mySetting.ImagePath2 + FileName;
                        myArch.FNo = (short)i;
                        myArch.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormName = "مستخدمي التطبيق";
                            UserTran.FormAction = "اضافة مرفقات";
                            UserTran.Description = "اضافة مرفقات لملف الموظف رقم " + txtName.Text;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }

                        LoadAttachData();
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
                myArch.LocNumber = 19;
                myArch.Number = int.Parse(txtName.ToolTip);
                myArch.DocType = (ddlAccType.SelectedIndex == 0 ? 750 : ddlAccType.SelectedIndex == 1 ? 751 : 752);
                myArch.FNo = short.Parse(FNo);
                myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                {
                    Transactions UserTran = new Transactions();
                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                    UserTran.UserName = Session["CurrentUser"].ToString();
                    UserTran.FormName = "مستخدمي التطبيق";
                    UserTran.FormAction = "الغاء مرفقات";
                    UserTran.Description = "الغاء مرفقات من ملف الموظف رقم " + txtName.Text;
                    UserTran.IP = IPNetworking.GetIP4Address();
                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                }

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
            if (txtName.ToolTip != "")
            {
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(Session["Branch"].ToString());
                myArch.LocNumber = 19;
                myArch.Number = int.Parse(txtName.ToolTip);
                myArch.DocType = (ddlAccType.SelectedIndex == 0 ? 750 : ddlAccType.SelectedIndex == 1 ? 751 : 752);
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

        protected void ddlDCareType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDCareType.SelectedIndex > 0)
            {
                CarType myCarType = new CarType();
                myCarType.cnn = WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString;
                myCarType.Branch = short.Parse(Session["Branch"].ToString());
                myCarType.FCode = ddlDCareType.SelectedValue;
                ddlDCarModel.DataTextField = "Name1";
                ddlDCarModel.DataValueField = "Code";
                ddlDCarModel.DataSource = myCarType.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                ddlDCarModel.DataBind();
                ddlDCarModel.Items.Insert(0, new ListItem("--- أختر الموديل ---", "-1", true));
            }
        }

        protected void BtnLoad0_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload0.HasFile)
                {
                    try
                    {
                        string fileExt = System.IO.Path.GetExtension(FileUpload0.FileName);
                        String FileName = Config.GetImageName(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + fileExt;
                        FileUpload0.SaveAs(Server.MapPath(ImageUrl) + @"/" + FileName);
                        ((Button)sender).ToolTip = FileName;
                        string url = ImageUrl + FileName;
                        ImgPhoto.Src = url;
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
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "لم بتم اختيار الملف";
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

        public void DisplayUserLog()
        {
            List<Transactions> myTran = new List<Transactions>();
            myTran.Add(new Transactions{});
            grdUserLog.DataSource = myTran;
            grdUserLog.DataBind();
        }

        protected void grdUserLog_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdUserLog.PageIndex = e.NewPageIndex;
                DisplayUserLog();
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

        public void DisplayOrders()
        {
            grdOrders.DataSource = (from itm in MyOrders
                                    where (ddlOrderType.SelectedIndex ==0 || (ddlOrderType.SelectedIndex != 0 && itm.OrderType == short.Parse(ddlOrderType.SelectedValue))) &&
                                          (ddlStatus.SelectedIndex == 0 || (ddlStatus.SelectedIndex != 0 && itm.Status==short.Parse(ddlStatus.SelectedValue)))
                                          && (txtSearch2.Text.Trim() == "" || (txtSearch2.Text.Trim() != "" && (ddlSearch.SelectedIndex == 0 ? itm.UIID.ToString().Contains(txtSearch2.Text.Trim()) : ddlSearch.SelectedIndex == 1 ? itm.MobileNo.Contains(txtSearch2.Text.Trim()) : ddlSearch.SelectedIndex == 2 ? itm.RecMobileNo.Contains(txtSearch2.Text.Trim()) : itm.DriverMobileNo.Contains(txtSearch2.Text.Trim()))))
                                    select itm).ToList();
            grdOrders.DataBind();
            txtSearch2.Text = "";
        }

        protected void grdOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdOrders.PageIndex = e.NewPageIndex;
                DisplayOrders();
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

        public void DisplayNotify()
        {
            Notify vNotify = new Notify();
            vNotify.AppType = short.Parse(ddlAccType.SelectedValue);
            vNotify.MobileNo = txtMobileNo.Text;
            grdNotify.DataSource = vNotify.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            grdNotify.DataBind();
        }

        protected void grdNotify_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdNotify.PageIndex = e.NewPageIndex;
                DisplayNotify();
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

        protected void ddlOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayOrders();
        }

        protected void BtnFind_Click(object sender, ImageClickEventArgs e)
        {
            DisplayOrders();
        }

   
    }

    [Serializable]
    public class Notification
    {
        public string FDateTime { get; set; }
        public string Description { get; set; }
    }
}

