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
    public partial class WebUsers : System.Web.UI.Page
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
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad0);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnSign);
                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "المستخدمين";
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

                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = "الرئيسية";
                        UserTran.FormAction = "اختيار";
                        UserTran.Description = "تم اختيار صفحة المستخدمين";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    MyConfig mysetting = new MyConfig();
                    mysetting.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mysetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    mysetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                    if (mysetting != null)
                    {
                        ImageUrl = mysetting.ImagePath2;
                    }
                    BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass191;
                    BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass192;
                    BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass193;
                    BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass194;

                    txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtUserName.Text = Session["FullUser"].ToString();
                    txtUserDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    TblRoles myRoles = new TblRoles();
                    ChkRoles.DataTextField = "RoleName";
                    ChkRoles.DataValueField = "RoleName";
                    if (Cache["Roles" + Session["CNN2"].ToString()] == null) Cache.Insert("Roles" + Session["CNN2"].ToString(), myRoles.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ChkRoles.DataSource = (List<TblRoles>)(Cache["Roles" + Session["CNN2"].ToString()]);
                    ChkRoles.DataBind();

                    ddlBranRoll.DataTextField = "RoleName";
                    ddlBranRoll.DataValueField = "RoleName";
                    ddlBranRoll.DataSource = (List<TblRoles>)(Cache["Roles" + Session["CNN2"].ToString()]);
                    ddlBranRoll.DataBind();

                    ddlAccount1.DataValueField = "Code";
                    ddlAccount2.DataValueField = "Code";
                    ddlAccount3.DataValueField = "Code";
                    ddlAccount4.DataValueField = "Code";
                    ddlAccount5.DataValueField = "Code";
                    ddlAccount6.DataValueField = "Code";
                    ddlAccount1.DataTextField = "Name1";
                    ddlAccount2.DataTextField = "Name1";
                    ddlAccount3.DataTextField = "Name1";
                    ddlAccount4.DataTextField = "Name1";
                    ddlAccount5.DataTextField = "Name1";
                    ddlAccount6.DataTextField = "Name1";
                    Acc myAcc = new Acc();
                    myAcc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["AllACC" + Session["CNN2"].ToString()] == null) Cache.Insert("AllACC" + Session["CNN2"].ToString(), myAcc.Getall(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlAccount1.DataSource = (List<Acc>)(Cache["AllACC" + Session["CNN2"].ToString()]);
                    ddlAccount2.DataSource = (List<Acc>)(Cache["AllACC" + Session["CNN2"].ToString()]);
                    ddlAccount3.DataSource = (List<Acc>)(Cache["AllACC" + Session["CNN2"].ToString()]);
                    ddlAccount4.DataSource = (List<Acc>)(Cache["AllACC" + Session["CNN2"].ToString()]);
                    ddlAccount5.DataSource = (List<Acc>)(Cache["AllACC" + Session["CNN2"].ToString()]);
                    ddlAccount6.DataSource = (List<Acc>)(Cache["AllACC" + Session["CNN2"].ToString()]);
                    ddlAccount1.DataBind();
                    ddlAccount2.DataBind();
                    ddlAccount3.DataBind();
                    ddlAccount4.DataBind();
                    ddlAccount5.DataBind();
                    ddlAccount6.DataBind();
                    ddlAccount1.Items.Insert(0, new ListItem("--- أختر الحساب  ---", "-1", true));
                    ddlAccount2.Items.Insert(0, new ListItem("--- أختر الحساب  ---", "-1", true));
                    ddlAccount3.Items.Insert(0, new ListItem("--- أختر الحساب  ---", "-1", true));
                    ddlAccount4.Items.Insert(0, new ListItem("--- أختر الحساب  ---", "-1", true));
                    ddlAccount5.Items.Insert(0, new ListItem("--- أختر الحساب  ---", "-1", true));
                    ddlAccount6.Items.Insert(0, new ListItem("--- أختر الحساب  ---", "-1", true));

                    CostCenter myCostCenter = new CostCenter();
                    myCostCenter.Branch = 1;
                    if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ChkBranch.DataTextField = "Name1";
                    ChkBranch.DataValueField = "Code";
                    ChkBranch.DataSource = (from itm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                                select new CostCenter { Name1 = itm.Name1, Code = itm.Code }).ToList();

                    ddlMainBran.DataTextField = "Name1";
                    ddlMainBran.DataValueField = "Code";
                    ddlMainBran.DataSource = (from itm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()]) 
                                            select new CostCenter { Name1 = itm.Name1, Code = itm.Code }).ToList();

                    ChkBranch.DataBind();
                    ddlMainBran.DataBind();

                    ddlBranRoll.Items.Insert(0, new ListItem("--- أختار صلاحية الفرع البديل ---", "-1", true));
                    LoadUsersData();
                    LoadGroupData();
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
                TblUsers myuser = new TblUsers();
                if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), myuser.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                grdCodes.DataSource = (from itm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                       orderby itm.UserName
                                       select itm).ToList();
                grdCodes.DataBind();
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

        protected void LoadGroupData()
        {
            try
            {
                TblUsersInRole myuser = new TblUsersInRole();
                GrdGroup.DataSource = myuser.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        //(from itm in myuser.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                       //orderby itm.UserName
                                       //select itm).ToList();
                GrdGroup.DataBind();
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
            NewMode();
            ImgPhoto.Src = "images/123.jpg";
            ImgPhoto0.Src = "";
            BtnLoad0.ToolTip = "";
            BtnSign.ToolTip = "";
            txtEmail.Text = "";
            txtReason.Text = "";
            txtFName.Text = "";
            txtMobile.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
            txtPassword2.Text = "";
            txtPassword.ToolTip = "";
            txtPassword2.ToolTip = "";
            txtPassword.Attributes.Add("value", "");
            txtPassword2.Attributes.Add("value", "");
            txtSearch.Text = "";
            txtTel.Text = "";
            ChkActive.Checked = false;
            ddlBranRoll.SelectedIndex = 0;
            ddlAccount1.SelectedIndex = 0;
            ddlAccount2.SelectedIndex = 0;
            ddlAccount3.SelectedIndex = 0;
            ddlAccount4.SelectedIndex = 0;
            ddlAccount5.SelectedIndex = 0;
            ddlAccount6.SelectedIndex = 0;
            ddlMainBran.SelectedIndex = 0;

            for (int i = 0; i < ChkRoles.Items.Count; i++)
            {
                ChkRoles.Items[i].Selected = false;
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> ChangeState(false); </script>", false);
        }

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    // Check User Have Role
                    bool vFound = false;
                    for (int i = 0; i < ChkRoles.Items.Count; i++)
                    {
                        if (ChkRoles.Items[i].Selected)
                        {
                            vFound = true;
                            break;
                        }
                    }
                    if (!vFound)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أن ينضم المستخدم لمجموعة من مجموعات المستخدمين";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

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
                    TblUsers myUser = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), myUser.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myUser.UserName = txtName.Text;
                    myUser = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                              where uitm.UserName == myUser.UserName
                              select uitm).FirstOrDefault();
                    if (myUser != null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "اسم المستخدم مدخل من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        bool vError = false;
                        for (int i = 0; i < ChkBranch.Items.Count; i++)
                        {
                            if (ChkBranch.Items[i].Selected)
                            {
                                if (ChkBranch.Items[i].Value == ddlMainBran.SelectedValue)
                                {
                                    vError = true;
                                    break;
                                }
                            }
                        }
                        if (vError)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "خطأ... الفرع الرئيسي لا يمكن ادراجة كفرع بديل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                        vError = false;
                        for (int i = 0; i < ChkBranch.Items.Count; i++)
                        {
                            if (ChkBranch.Items[i].Selected)
                            {
                                if (ChkBranch.Items[i].Value == ddlMainBran.SelectedValue)
                                {
                                    vError = true;
                                    break;
                                }
                            }
                        }
                        if (vError && ddlBranRoll.SelectedIndex == 0)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "يجب أختيار صلاحيات الفرع البديل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                        myUser = new TblUsers();
                        myUser.UserName = txtName.Text;
                        myUser.FName = txtFName.Text;
                        myUser.Mobile = txtMobile.Text;
                        myUser.Password = txtPassword.Text;
                        myUser.tel = txtTel.Text;
                        myUser.Email = txtEmail.Text;
                        myUser.UserName2 = txtUserName.Text;
                        myUser.UserOP = "جديد";
                        myUser.UserDate = txtUserDate.Text;
                        myUser.MainBran = ddlMainBran.SelectedValue;
                        myUser.BranRoll = ddlBranRoll.SelectedValue;
                        myUser.ChangePass = false;
                        myUser.Photo = BtnLoad0.ToolTip;
                        myUser.Sign = BtnSign.ToolTip;
                        myUser.Active = ChkActive.Checked;
                        myUser.Account1 = ddlAccount1.SelectedValue;
                        myUser.Account2 = ddlAccount2.SelectedValue;
                        myUser.Account3 = ddlAccount3.SelectedValue;
                        myUser.Account4 = ddlAccount4.SelectedValue;
                        myUser.Account5 = ddlAccount5.SelectedValue;
                        myUser.Account6 = ddlAccount6.SelectedValue;
                        string vBrans = "";
                        for(int i = 0; i<ChkBranch.Items.Count ; i++)
                        {
                            if(ChkBranch.Items[i].Selected) 
                            {
                                if (vBrans != "") vBrans = vBrans +  ";" + ChkBranch.Items[i].Value ;
                                else vBrans = ChkBranch.Items[i].Value;
                            }
                        }
                        myUser.Branchs = vBrans;
                        if (myUser.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            for (int i = 0; i < ChkRoles.Items.Count; i++)
                            {
                                if (ChkRoles.Items[i].Selected)
                                {
                                    TblUsersInRole UR = new TblUsersInRole();
                                    UR.UserName = myUser.UserName;
                                    UR.RoleName = ChkRoles.Items[i].Value;
                                    UR.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    break;
                                }
                            }

                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.FormName = "المستخدمين";
                                UserTran.FormAction = "اضافة";
                                UserTran.Description = "اضافة بيانات المستخدم " + txtName.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }

                            UpdateCache();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                            LoadUsersData();
                            LoadGroupData();
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ اثناء أضافة البيانات ... حاول مرة أخرى";
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
                    for (int i = 0; i < ChkRoles.Items.Count; i++)
                    {
                        if (ChkRoles.Items[i].Selected)
                        {
                            vFound = true;
                            break;
                        }
                    }
                    if (!vFound)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أن ينضم المستخدم لمجموعة من مجموعات المستخدمين";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

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
                    TblUsers myUser = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), myUser.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myUser.UserName = txtName.Text;
                    myUser = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                              where uitm.UserName == myUser.UserName
                              select uitm).FirstOrDefault();
                    if (myUser == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "اسم المستخدم غير مدرج من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        bool vError = false;
                        for (int i = 0; i < ChkBranch.Items.Count; i++)
                        {
                            if (ChkBranch.Items[i].Selected)
                            {
                                if (ChkBranch.Items[i].Value == ddlMainBran.SelectedValue)
                                {
                                    vError = true;
                                    break;
                                }
                            }
                        }
                        if (vError)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "خطأ... الفرع الرئيسي لا يمكن ادراجة كفرع بديل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                        vError = false;
                        for (int i = 0; i < ChkBranch.Items.Count; i++)
                        {
                            if (ChkBranch.Items[i].Selected)
                            {
                                if (ChkBranch.Items[i].Value == ddlMainBran.SelectedValue)
                                {
                                    vError = true;
                                    break;
                                }
                            }
                        }
                        if (vError && ddlBranRoll.SelectedIndex == 0)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "يجب أختيار صلاحيات الفرع البديل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                        myUser.FName = txtFName.Text;
                        myUser.Mobile = txtMobile.Text;
                        myUser.Password = txtPassword.Text;
                        myUser.tel = txtTel.Text;
                        myUser.Email = txtEmail.Text;
                        myUser.UserName2 = txtUserName.ToolTip;
                        myUser.UserOP = "تعديل";
                        myUser.UserDate = txtUserDate.Text;
                        myUser.MainBran = ddlMainBran.SelectedValue;
                        myUser.BranRoll = ddlBranRoll.SelectedValue;
                        myUser.Photo = BtnLoad0.ToolTip;
                        myUser.Sign = BtnSign.ToolTip;
                        myUser.Active = ChkActive.Checked;
                        myUser.Account1 = ddlAccount1.SelectedValue;
                        myUser.Account2 = ddlAccount2.SelectedValue;
                        myUser.Account3 = ddlAccount3.SelectedValue;
                        myUser.Account4 = ddlAccount4.SelectedValue;
                        myUser.Account5 = ddlAccount5.SelectedValue;
                        myUser.Account6 = ddlAccount6.SelectedValue;
                        string vBrans = "";
                        for (int i = 0; i < ChkBranch.Items.Count; i++)
                        {
                            if (ChkBranch.Items[i].Selected)
                            {
                                if (vBrans != "") vBrans = vBrans + ";" + ChkBranch.Items[i].Value;
                                else vBrans = ChkBranch.Items[i].Value;
                            }
                        }
                        myUser.Branchs = vBrans;
                        if (myUser.Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            TblUsersInRole UR2 = new TblUsersInRole();
                            UR2.UserName = myUser.UserName;
                            UR2.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            for (int i = 0; i < ChkRoles.Items.Count; i++)
                            {
                                if (ChkRoles.Items[i].Selected)
                                {
                                    TblUsersInRole UR = new TblUsersInRole();
                                    UR.UserName = myUser.UserName;
                                    UR.RoleName = ChkRoles.Items[i].Value;
                                    UR.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    break;
                                }
                            }

                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.FormName = "المستخدمين";
                                UserTran.FormAction = "تعديل";
                                UserTran.Description = "تعديل بيانات المستخدم " + txtName.Text;
                                UserTran.Reason = txtReason.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }
                            txtReason.Text = "";
                            UpdateCache();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                            LoadUsersData();
                            LoadGroupData();
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ اثناء تعديل البيانات ... حاول مرة أخرى";
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
                    // Check if User Exists
                    TblUsers myUser = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), myUser.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myUser.UserName = txtName.Text;
                    myUser = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                              where uitm.UserName == myUser.UserName
                              select uitm).FirstOrDefault();
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
                            TblUsersInRole UR2 = new TblUsersInRole();
                            UR2.UserName = myUser.UserName;
                            UR2.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.FormName = "المستخدمين";
                                UserTran.FormAction = "الغاء";
                                UserTran.Description = "الغاء بيانات المستخدم " + txtName.Text;
                                UserTran.Reason = txtReason.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }
                            txtReason.Text = "";
                            UpdateCache();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم الغاء البيانات بنجاح";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                            LoadUsersData();
                            LoadGroupData();
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
                    TblUsers myUser = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), myUser.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myUser.UserName = txtName.Text;
                    myUser = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                              where uitm.UserName == myUser.UserName
                              select uitm).FirstOrDefault();
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
                            UserTran.FormName = "المستخدمين";
                            UserTran.FormAction = "عرض";
                            UserTran.Description = "عرض بيانات المستخدم " + txtName.Text;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }
                        
                        EditMode();
                        txtFName.Text = myUser.FName;
                        txtMobile.Text = myUser.Mobile;
                        txtPassword.Text = myUser.Password;
                        txtPassword.ToolTip = myUser.Password;
                        txtPassword.Attributes.Add("value", myUser.Password);
                        txtPassword2.Text = myUser.Password;
                        txtPassword2.Attributes.Add("value", myUser.Password);
                        txtPassword2.ToolTip = myUser.Password;
                        txtTel.Text = myUser.tel;
                        txtEmail.Text = myUser.Email;
                        ChkActive.Checked = (bool)myUser.Active;
                        BtnLoad0.ToolTip = "";
                        if (!string.IsNullOrEmpty(myUser.Photo))
                        {
                            BtnLoad0.ToolTip = myUser.Photo;
                            string url = ImageUrl + myUser.Photo;
                            ImgPhoto.Src = url;
                        }
                        else ImgPhoto.Src = "images/123.jpg";
                        BtnSign.ToolTip = "";
                        if (!string.IsNullOrEmpty(myUser.Sign))
                        {
                            BtnSign.ToolTip = myUser.Sign;
                            string url = ImageUrl + myUser.Sign;
                            ImgPhoto0.Src = url;
                        }
                        else ImgPhoto0.Src = "images/123.jpg";

                        ddlMainBran.SelectedValue = myUser.MainBran;
                        ddlBranRoll.SelectedValue = myUser.BranRoll;
                        ddlAccount1.SelectedValue = myUser.Account1;
                        ddlAccount2.SelectedValue = myUser.Account2;
                        ddlAccount3.SelectedValue = myUser.Account3;
                        ddlAccount4.SelectedValue = myUser.Account4;
                        ddlAccount5.SelectedValue = myUser.Account5;
                        ddlAccount6.SelectedValue = myUser.Account6;
                        for (int i = 0; i < ChkBranch.Items.Count; i++)
                        {
                            ChkBranch.Items[i].Selected = false;
                        }

                        if (myUser.Branchs != "")
                        {
                            string[] k = myUser.Branchs.Split(';');
                            foreach (string m in k)
                            {
                                for (int i = 0; i < ChkBranch.Items.Count; i++)
                                {
                                    if (ChkBranch.Items[i].Value == m)
                                    {
                                        ChkBranch.Items[i].Selected = true;
                                    }
                                }
                            }
                        }


                        //txtUserName.Text = myUser.UserName2;
                        txtUserName.ToolTip = myUser.UserName2;

                        TblUsers ax = new TblUsers();
                        ax.UserName = myUser.UserName2;
                        if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
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
                        txtUserDate.Text = myUser.UserDate.ToString();


                        for (int i = 0; i < ChkRoles.Items.Count; i++)
                        {
                            ChkRoles.Items[i].Selected = false;
                        }

                        TblUsersInRole UR2 = new TblUsersInRole();
                        List<TblUsersInRole> LUR2 = new List<TblUsersInRole>();
                        UR2.UserName = myUser.UserName;
                        LUR2 = UR2.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        foreach (TblUsersInRole UR in LUR2)
                        {
                            for (int i = 0; i < ChkRoles.Items.Count; i++)
                            {
                                if (ChkRoles.Items[i].Value == UR.RoleName)
                                {
                                    ChkRoles.Items[i].Selected = true;
                                    break;
                                }
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
                string UserName = grdCodes.DataKeys[e.NewSelectedIndex]["UserName"].ToString();
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
                            Response.Redirect("GeneralServerError.aspx",false);
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
                    Response.Redirect("GeneralServerError.aspx",false);
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }

        protected void BtnSign_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.FileUpload1.HasFile)
                {
                    try
                    {
                        string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
                        String FileName = Config.GetImageName(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + fileExt;
                        FileUpload1.SaveAs(Server.MapPath(ImageUrl) + @"/" + FileName);
                        ((Button)sender).ToolTip = FileName;
                        string url = ImageUrl + FileName;                        
                        ImgPhoto0.Src = url;
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
                    Response.Redirect("GeneralServerError.aspx",false);
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }

        protected void GrdGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdGroup.PageIndex = e.NewPageIndex;
                LoadGroupData();
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

        protected void GrdGroup_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                string UserName = GrdGroup.DataKeys[e.NewSelectedIndex]["UserName"].ToString();
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
                    Response.Redirect("GeneralServerError.aspx", false);
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                    e.NewSelectedIndex = -1;
                }
            }
        } 
       
        public void UpdateCache()
        {
            if (Cache["Users" + Session["CNN2"].ToString()] != null) Cache.Remove("Users" + Session["CNN2"].ToString());
            TblUsers ax = new TblUsers();
            if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
        }
    }
}

