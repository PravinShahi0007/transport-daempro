using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Web.Security;
using BLL;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Net;

namespace ACC
{
    public partial class login : System.Web.UI.Page
    {
        protected override void InitializeCulture()
        {
            HttpCookie cultureCookie = Request.Cookies["Lang"];
            String Lang = (cultureCookie != null) ? cultureCookie.Value : null;
            if (Thread.CurrentThread.CurrentCulture.Name.ToUpper() == "AR-SA") Response.Cookies.Add(new HttpCookie("Lang", "ar-EG"));

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
                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = GetLocalResourceObject("Login").ToString();  // "تسجيل الدخول";
                    TxtUserName.Focus();
                    Session.Clear();
                }


            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message.ToString();
            }
        }

        protected void BtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    //Session.Add("CNN", ddlCnn.SelectedValue);
                    //Session.Add("CNN2", ddlCnn.SelectedItem.Text);
                    Session.Add("StoreNo", "1");

                    TblRoles myRole = new TblRoles();
                    if (Cache["MyRoles" + Session["CNN2"].ToString()] == null) Cache.Insert("MyRoles" + Session["CNN2"].ToString(), myRole.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    if (Cache["Roles" + Session["CNN2"].ToString()] == null) Cache.Insert("Roles" + Session["CNN2"].ToString(), myRole.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    if (TxtUserName.Text == "dewan" && txtPassword.Text == "d@12345")
                    {
                        Session.Add("CurrentUser", TxtUserName.Text);
                        Session.Add("FullUser", "ديوان المظالم");
                        List<TblRoles> lRoll = new List<TblRoles>();
                        TblRoles myRoll = new TblRoles();
                        myRoll.RoleName = "admin";
                        lRoll = (from itm in (List<TblRoles>)(Cache["MyRoles" + Session["CNN2"].ToString()])
                                 where itm.RoleName == myRoll.RoleName
                                 select itm).ToList();

                        if (lRoll != null)
                        {
                            Session.Add("Roll", lRoll);
                        }
                        Session.Add("AreaNo", "00001");

                        HttpCookie authCookie = FormsAuthentication.GetAuthCookie(TxtUserName.Text, false);  // Get the FormsAuthenticationTicket out of the encrypted cookie                                 
                        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); // Create a new FormsAuthenticationTicket that includes our custom User Data                               
                        FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, TxtUserName.Text); // Update the authCookie's Value to use the encrypted version of newTicket                                
                        authCookie.Value = FormsAuthentication.Encrypt(newTicket); // Manually add the authCookie to the Cookies collection 
                        Response.Cookies.Add(authCookie); // Determine redirect URL and send user there 
                        string redirUrl = FormsAuthentication.GetRedirectUrl(TxtUserName.Text, false);
                        Session.Add("DispMessage", true);

                        //moh.Backup(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString,Server.MapPath("Excel"));
                        //FormsAuthentication.RedirectFromLoginPage

                        HttpCookie MylatCookie = Request.Cookies["Mylat"];
                        HttpCookie MylngCookie = Request.Cookies["Mylng"];

                        string lat = (MylatCookie != null ? MylatCookie.Value : "");
                        string lng = (MylngCookie != null ? MylngCookie.Value : "");

                        if (Session["myLat"] != null)
                        {
                            Session["myLat"] = lat;                                          // ((HiddenField)this.Master.FindControl("Mylat2")).Value;
                            Session["myLng"] = lng;

                        }
                        else
                        {
                            Session.Add("myLat", lat);
                            Session.Add("myLng", lng);
                        }

                        CostCenter myCost = new CostCenter();
                        myCost.Branch = 1;
                        if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCost.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCost.Code = "00001";
                        myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                  where citm.Code == myCost.Code
                                  select citm).FirstOrDefault();
                        if (myCost != null)
                        {
                            Session.Add("SiteInfo", myCost);
                            Session.Add("AreaName", myCost.Name1);
                        }
                        else
                        {
                            Response.Redirect("logout.aspx");
                        }
                        Response.Redirect("WebProject1.aspx?Support=1");
                    }


                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));



                    ax.UserName = TxtUserName.Text;
                    ax = (from itm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                          where itm.UserName == ax.UserName
                          select itm).FirstOrDefault();
                    if (ax != null)
                    {
                        if (ax.Password == txtPassword.Text )
                        {
                            if (!(bool)ax.Active)
                            {
                                LblError.Text = GetLocalResourceObject("NotActive").ToString(); // "المستخدم غير نشط ... الاتصال بالدعم الفني لتنشيط الحساب";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblError.Text, true, false), true);
                                return;
                            }

                            Session.Add("CurrentUser", TxtUserName.Text);
                            Session.Add("FullUser", ax.FName);
                            TblUsersInRole UR = new TblUsersInRole();
                            UR.UserName = ax.UserName;
                            UR = UR.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                            if (UR != null)
                            {
                                List<TblRoles> lRoll = new List<TblRoles>();
                                TblRoles myRoll = new TblRoles();
                                if (Cache["MyRoles" + Session["CNN2"].ToString()] == null) Cache.Insert("MyRoles" + Session["CNN2"].ToString(), myRoll.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                myRoll.RoleName = UR.RoleName;
                                lRoll = (from itm in (List<TblRoles>)(Cache["MyRoles" + Session["CNN2"].ToString()])
                                         where itm.RoleName == myRoll.RoleName
                                         select itm).ToList();
                                if (lRoll != null)
                                {
                                    Session.Add("Roll", lRoll);
                                }

                                Session.Add("AreaNo", ax.MainBran);
                                lRoll = new List<TblRoles>();
                                myRoll = new TblRoles();
                                myRoll.RoleName = ax.BranRoll;
                                lRoll = (from itm in (List<TblRoles>)(Cache["MyRoles" + Session["CNN2"].ToString()])
                                         where itm.RoleName == myRoll.RoleName
                                         select itm).ToList();
                                if (lRoll != null)
                                {
                                    Session.Add("AltRoll", lRoll);
                                }

                            }

                            // Query the user store to get this user's User Data string 
                            HttpCookie authCookie = FormsAuthentication.GetAuthCookie(TxtUserName.Text, false);  // Get the FormsAuthenticationTicket out of the encrypted cookie                                 
                            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); // Create a new FormsAuthenticationTicket that includes our custom User Data                               
                            FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, TxtUserName.Text); // Update the authCookie's Value to use the encrypted version of newTicket                                
                            authCookie.Value = FormsAuthentication.Encrypt(newTicket); // Manually add the authCookie to the Cookies collection 
                            Response.Cookies.Add(authCookie); // Determine redirect URL and send user there 
                            string redirUrl = FormsAuthentication.GetRedirectUrl(TxtUserName.Text, false);
                            Session.Add("DispMessage", true);                            

                            //moh.Backup(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString,Server.MapPath("Excel"));
                            //FormsAuthentication.RedirectFromLoginPage

                            HttpCookie MylatCookie = Request.Cookies["Mylat"];
                            HttpCookie MylngCookie = Request.Cookies["Mylng"];

                            string lat = (MylatCookie != null ? MylatCookie.Value : "");
                            string lng = (MylngCookie != null ? MylngCookie.Value : "");

                            if (Session["myLat"] != null)
                            {
                                Session["myLat"] = lat;                                          // ((HiddenField)this.Master.FindControl("Mylat2")).Value;
                                Session["myLng"] = lng;

                            }
                            else
                            {
                                Session.Add("myLat", lat);
                                Session.Add("myLng", lng);
                            }

                            LoadMyCache();

                            CostCenter myCost = new CostCenter();
                            myCost.Branch = 1;
                            if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCost.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                            myCost.Code = ax.MainBran;
                            myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                      where citm.Code == myCost.Code
                                      select citm).FirstOrDefault();
                            if (myCost != null)
                            {
                                Session.Add("SiteInfo", myCost);
                                Session.Add("AreaName", myCost.Name1);
                            }
                            else
                            {
                                Response.Redirect("logout.aspx");
                            }


                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetLocalResourceObject("Login").ToString(), GetLocalResourceObject("Login").ToString(), GetLocalResourceObject("SuccessLogin").ToString(), "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            if (Session["CNN"].ToString().ToUpper() == "MYCNN" && (int.Parse(String.Format("{0:HH}", moh.Nows())) == 8 || int.Parse(String.Format("{0:HH}", moh.Nows())) == 9))
                            //if (Session["CNN"].ToString().ToUpper() == "MYCNN")
                            {
                                try
                                {
                                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetLocalResourceObject("Home").ToString(), GetLocalResourceObject("Auto").ToString(), GetLocalResourceObject("MakeBackup").ToString(), "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                    moh.Backup(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, ConfigurationManager.AppSettings["BackupPath"].ToString());  // Server.MapPath("/Backup")

                                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetLocalResourceObject("Home").ToString(), GetLocalResourceObject("Auto").ToString(), GetLocalResourceObject("MakeTally").ToString(), "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                    moh.Tally(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString, short.Parse(HttpContext.Current.Session["Branch"].ToString()));
                                }
                                catch (Exception ex)
                                {
                                    LblError.ForeColor = System.Drawing.Color.Red;
                                    LblError.Text += ex.Message.ToString();
                                }
                            }


                            if ((bool)ax.ChangePass)
                            {
                                if (((List<TblRoles>)(Session["Roll"]))[0].Interface == 0)
                                {
                                  //  Response.Redirect(ChkFast.Checked ? "default2.aspx" : "default.aspx");
                                }
                                else if (((List<TblRoles>)(Session["Roll"]))[0].Interface == 1)
                                {
                                    Session["StoreNo"] = "1";
                                    Session["AreaNo"] = "00001";
                                    Response.Redirect("Default_Support.aspx");
                                }
                                else if (((List<TblRoles>)(Session["Roll"]))[0].Interface == 2)
                                {
                                    Session["StoreNo"] = "1";
                                    Session["AreaNo"] = "00001";
                                    Response.Redirect("Default_Vendor.aspx");
                                }
                                else if (((List<TblRoles>)(Session["Roll"]))[0].Interface == 3)
                                {
                                    Session["StoreNo"] = "1";
                                    Session["AreaNo"] = "00001";
                                    Response.Redirect("Default_Client.aspx");
                                }
                                else Response.Redirect(redirUrl);
                            }
                            else Response.Redirect("ResetPassword.aspx");
                        }
                        else
                        {
                            LblError.Text = GetLocalResourceObject("UserNamePasswordError").ToString();   // "خطأ في اسم المستخدم او كلمة المرور ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblError.Text, true,false), true);
                        }
                    }
                    else
                    {
                        LblError.Text = GetLocalResourceObject("UserNamePasswordError").ToString();   //"خطأ في اسم المستخدم او كلمة المرور ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblError.Text, true,false), true);
                    }
                }
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message.ToString();
            }
        }

        public void LoadMyCache()
        {
            Acc myAcc = new Acc();
            myAcc.Branch = 1;
            if (Cache["LastACC" + Session["CNN2"].ToString()] == null) Cache.Insert("LastACC" + Session["CNN2"].ToString(), myAcc.GetLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            if (Cache["AllACC" + Session["CNN2"].ToString()] == null) Cache.Insert("AllACC" + Session["CNN2"].ToString(), myAcc.Getall(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

            MyConfig mySetting = new MyConfig();
            mySetting.Branch = 1;
            if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

            Claim cl = new Claim();
            cl.DocLoc = (short)-1;
            if (Cache["ClaimPending" + Session["CNN2"].ToString()] == null) Cache.Insert("ClaimPending" + Session["CNN2"].ToString(), cl.GetPending(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

            DocSerial myInv = new DocSerial();
            if (Cache["PlateNoList" + Session["CNN2"].ToString()] == null) Cache.Insert("PlateNoList" + Session["CNN2"].ToString(), myInv.GetPlateNoList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            if (Cache["ChassisNoList" + Session["CNN2"].ToString()] == null) Cache.Insert("ChassisNoList" + Session["CNN2"].ToString(), myInv.GetChassisNoList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            if (Cache["MobileNoList" + Session["CNN2"].ToString()] == null) Cache.Insert("MobileNoList" + Session["CNN2"].ToString(), myInv.GetMobileNoList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            if (Cache["RecMobileNoList" + Session["CNN2"].ToString()] == null) Cache.Insert("RecMobileNoList" + Session["CNN2"].ToString(), myInv.GetRecMobileNoList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            if (Cache["IDNoList" + Session["CNN2"].ToString()] == null) Cache.Insert("IDNoList" + Session["CNN2"].ToString(), myInv.GetIDNoList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            if (Cache["VouNoList" + Session["CNN2"].ToString()] == null) Cache.Insert("VouNoList" + Session["CNN2"].ToString(), myInv.GetVouNoList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            if (Cache["NameList" + Session["CNN2"].ToString()] == null) Cache.Insert("NameList" + Session["CNN2"].ToString(), myInv.GetNameList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            if (Cache["RecNameList" + Session["CNN2"].ToString()] == null) Cache.Insert("RecNameList" + Session["CNN2"].ToString(), myInv.GetRecNameList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

            if (Cache["LMobileNoList" + Session["CNN2"].ToString()] == null) Cache.Insert("LMobileNoList" + Session["CNN2"].ToString(), myInv.GetLMobileNoList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            if (Cache["LRecMobileNoList" + Session["CNN2"].ToString()] == null) Cache.Insert("LRecMobileNoList" + Session["CNN2"].ToString(), myInv.GetLRecMobileNoList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            if (Cache["LIDNoList" + Session["CNN2"].ToString()] == null) Cache.Insert("LIDNoList" + Session["CNN2"].ToString(), myInv.GetLIDNoList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            if (Cache["LVouNoList" + Session["CNN2"].ToString()] == null) Cache.Insert("LVouNoList" + Session["CNN2"].ToString(), myInv.GetLVouNoList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            if (Cache["LNameList" + Session["CNN2"].ToString()] == null) Cache.Insert("LNameList" + Session["CNN2"].ToString(), myInv.GetLNameList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            if (Cache["LRecNameList" + Session["CNN2"].ToString()] == null) Cache.Insert("LRecNameList" + Session["CNN2"].ToString(), myInv.GetLRecNameList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

            if (Cache["EMobileNoList" + Session["CNN2"].ToString()] == null) Cache.Insert("EMobileNoList" + Session["CNN2"].ToString(), myInv.GetEMobileNoList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            if (Cache["ERecMobileNoList" + Session["CNN2"].ToString()] == null) Cache.Insert("ERecMobileNoList" + Session["CNN2"].ToString(), myInv.GetEMobileNoList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            if (Cache["EIDNoList" + Session["CNN2"].ToString()] == null) Cache.Insert("EIDNoList" + Session["CNN2"].ToString(), myInv.GetEIDNoList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            if (Cache["EVouNoList" + Session["CNN2"].ToString()] == null) Cache.Insert("EVouNoList" + Session["CNN2"].ToString(), myInv.GetEVouNoList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            if (Cache["ENameList" + Session["CNN2"].ToString()] == null) Cache.Insert("ENameList" + Session["CNN2"].ToString(), myInv.GetENameList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            if (Cache["ERecNameList" + Session["CNN2"].ToString()] == null) Cache.Insert("ERecNameList" + Session["CNN2"].ToString(), myInv.GetERecNameList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

            Item myItem = new Item();
            myItem.Branch = 1;
            if (Cache["Items" + Session["CNN2"].ToString()] == null) Cache.Insert("Items" + Session["CNN2"].ToString(), myItem.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

            Area myArea = new Area();
            myArea.Branch = 1;
            if (Cache["LastArea" + Session["CNN2"].ToString()] == null) Cache.Insert("LastArea" + Session["CNN2"].ToString(), myArea.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

            CostCenter myCostCenter = new CostCenter();
            myCostCenter.Branch = 1;
            if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

            AccProject myProject = new AccProject();
            myProject.Branch = 1;
            if (Cache["LastProject" + Session["CNN2"].ToString()] == null) Cache.Insert("LastProject" + Session["CNN2"].ToString(), myProject.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

            Codes myCode = new Codes();
            myCode.Branch = 1;
            if (Cache["LastCodes" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCodes" + Session["CNN2"].ToString(), myCode.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

            CostAcc myCostAcc = new CostAcc();
            myCostAcc.Branch = 1;
            if (Cache["LastCostAcc" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostAcc" + Session["CNN2"].ToString(), myCostAcc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

            Drivers myDrive = new Drivers();
            myDrive.Branch = 1;
            if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

            Cities myCity = new Cities();
            myCity.Branch = 1;
            if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            
            Cars myCar = new Cars();
            myCar.Branch = 1;
            if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
    
            TblStart myStart = new TblStart();
            if (Cache["Starter" + Session["CNN2"].ToString()] == null) Cache.Insert("Starter" + Session["CNN2"].ToString(), myStart.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

            SEmp myEmp = new SEmp();
            if (Cache["Emps" + Session["CNN2"].ToString()] == null) Cache.Insert("Emps" + Session["CNN2"].ToString(), myEmp.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
        }

        protected void btnForgetPass_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CNN"] == null)
                {
                    //Session.Add("CNN", ddlCnn.SelectedValue);
                    //Session.Add("CNN2", ddlCnn.SelectedItem.Text);
                }
                TblUsers ax = new TblUsers();
                if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                ax.UserName = TxtUserName.Text;
                ax = (from itm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                      where itm.UserName == ax.UserName
                      select itm).FirstOrDefault();
                if (ax != null)
                {
                    if (ax.Email != "")
                    {
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(ax.UserName, GetLocalResourceObject("Login").ToString(), GetLocalResourceObject("ForgetPass").ToString(), GetLocalResourceObject("SentMail").ToString(), "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        
                        string Body = string.Format(GetLocalResourceObject("Email").ToString(), ax.UserName, ax.Password);

                        moh.SendEmail(ax.Email, Body, GetLocalResourceObject("ResetPass").ToString(), null);  // "نظام الناقلات البرية - أستعادة كلمة المرور"
                        LblError.Text = GetLocalResourceObject("SentMailSuccess").ToString();  //"تم إرسال الرسالة على بريدك الالكتروني بنجاح .. شاكرين تواصلك معنا";
                        LblError.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        LblError.Text = GetLocalResourceObject("InvalidEmail").ToString();  // "لم يتم تفعيل البريد الالكتروني بحسابك";
                        LblError.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    LblError.Text = GetLocalResourceObject("WrongUserName").ToString();  // "تأكد من اسم المستخدم";
                    LblError.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
                LblError.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    Session.Add("CNN", ddlCnn.SelectedValue);
                    Session.Add("CNN2", ddlCnn.SelectedItem.Text);
                    Session.Add("StoreNo", "1");

                    TblRoles myRole = new TblRoles();
                    if (Cache["MyRoles" + Session["CNN2"].ToString()] == null) Cache.Insert("MyRoles" + Session["CNN2"].ToString(), myRole.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    if (Cache["Roles" + Session["CNN2"].ToString()] == null) Cache.Insert("Roles" + Session["CNN2"].ToString(), myRole.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    if (TxtUserName.Text == "dewan" && txtPassword.Text == "d@12345")
                    {
                        Session.Add("CurrentUser", TxtUserName.Text);
                        Session.Add("FullUser", "ديوان المظالم");
                        List<TblRoles> lRoll = new List<TblRoles>();
                        TblRoles myRoll = new TblRoles();
                        myRoll.RoleName = "admin";
                        lRoll = (from itm in (List<TblRoles>)(Cache["MyRoles" + Session["CNN2"].ToString()])
                                 where itm.RoleName == myRoll.RoleName
                                 select itm).ToList();

                        if (lRoll != null)
                        {
                            Session.Add("Roll", lRoll);
                        }
                        Session.Add("AreaNo", "00001");

                        HttpCookie authCookie = FormsAuthentication.GetAuthCookie(TxtUserName.Text, false);  // Get the FormsAuthenticationTicket out of the encrypted cookie                                 
                        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); // Create a new FormsAuthenticationTicket that includes our custom User Data                               
                        FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, TxtUserName.Text); // Update the authCookie's Value to use the encrypted version of newTicket                                
                        authCookie.Value = FormsAuthentication.Encrypt(newTicket); // Manually add the authCookie to the Cookies collection 
                        Response.Cookies.Add(authCookie); // Determine redirect URL and send user there 
                        string redirUrl = FormsAuthentication.GetRedirectUrl(TxtUserName.Text, false);
                        Session.Add("DispMessage", true);

                        //moh.Backup(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString,Server.MapPath("Excel"));
                        //FormsAuthentication.RedirectFromLoginPage

                        HttpCookie MylatCookie = Request.Cookies["Mylat"];
                        HttpCookie MylngCookie = Request.Cookies["Mylng"];

                        string lat = (MylatCookie != null ? MylatCookie.Value : "");
                        string lng = (MylngCookie != null ? MylngCookie.Value : "");

                        if (Session["myLat"] != null)
                        {
                            Session["myLat"] = lat;                                          // ((HiddenField)this.Master.FindControl("Mylat2")).Value;
                            Session["myLng"] = lng;

                        }
                        else
                        {
                            Session.Add("myLat", lat);
                            Session.Add("myLng", lng);
                        }

                        CostCenter myCost = new CostCenter();
                        myCost.Branch = 1;
                        if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCost.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCost.Code = "00001";
                        myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                  where citm.Code == myCost.Code
                                  select citm).FirstOrDefault();
                        if (myCost != null)
                        {
                            Session.Add("SiteInfo", myCost);
                            Session.Add("AreaName", myCost.Name1);
                        }
                        else
                        {
                            Response.Redirect("logout.aspx");
                        }
                        Response.Redirect("WebProject1.aspx?Support=1");
                    }


                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));



                    ax.UserName = TxtUserName.Text;
                    ax = (from itm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                          where itm.UserName == ax.UserName
                          select itm).FirstOrDefault();
                    if (ax != null)
                    {
                        if (ax.Password == txtPassword.Text)
                        {
                            if (!(bool)ax.Active)
                            {
                                LblError.Text = GetLocalResourceObject("NotActive").ToString(); // "المستخدم غير نشط ... الاتصال بالدعم الفني لتنشيط الحساب";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblError.Text, true, false), true);
                                return;
                            }

                            Session.Add("CurrentUser", TxtUserName.Text);
                            Session.Add("FullUser", ax.FName);
                            TblUsersInRole UR = new TblUsersInRole();
                            UR.UserName = ax.UserName;
                            UR = UR.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                            if (UR != null)
                            {
                                List<TblRoles> lRoll = new List<TblRoles>();
                                TblRoles myRoll = new TblRoles();
                                if (Cache["MyRoles" + Session["CNN2"].ToString()] == null) Cache.Insert("MyRoles" + Session["CNN2"].ToString(), myRoll.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                myRoll.RoleName = UR.RoleName;
                                lRoll = (from itm in (List<TblRoles>)(Cache["MyRoles" + Session["CNN2"].ToString()])
                                         where itm.RoleName == myRoll.RoleName
                                         select itm).ToList();
                                if (lRoll != null)
                                {
                                    Session.Add("Roll", lRoll);
                                }

                                Session.Add("AreaNo", ax.MainBran);
                                lRoll = new List<TblRoles>();
                                myRoll = new TblRoles();
                                myRoll.RoleName = ax.BranRoll;
                                lRoll = (from itm in (List<TblRoles>)(Cache["MyRoles" + Session["CNN2"].ToString()])
                                         where itm.RoleName == myRoll.RoleName
                                         select itm).ToList();
                                if (lRoll != null)
                                {
                                    Session.Add("AltRoll", lRoll);
                                }

                            }

                            // Query the user store to get this user's User Data string 
                            HttpCookie authCookie = FormsAuthentication.GetAuthCookie(TxtUserName.Text, false);  // Get the FormsAuthenticationTicket out of the encrypted cookie                                 
                            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); // Create a new FormsAuthenticationTicket that includes our custom User Data                               
                            FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, TxtUserName.Text); // Update the authCookie's Value to use the encrypted version of newTicket                                
                            authCookie.Value = FormsAuthentication.Encrypt(newTicket); // Manually add the authCookie to the Cookies collection 
                            Response.Cookies.Add(authCookie); // Determine redirect URL and send user there 
                            string redirUrl = FormsAuthentication.GetRedirectUrl(TxtUserName.Text, false);
                            Session.Add("DispMessage", true);

                            //moh.Backup(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString,Server.MapPath("Excel"));
                            //FormsAuthentication.RedirectFromLoginPage

                            HttpCookie MylatCookie = Request.Cookies["Mylat"];
                            HttpCookie MylngCookie = Request.Cookies["Mylng"];

                            string lat = (MylatCookie != null ? MylatCookie.Value : "");
                            string lng = (MylngCookie != null ? MylngCookie.Value : "");

                            if (Session["myLat"] != null)
                            {
                                Session["myLat"] = lat;                                          // ((HiddenField)this.Master.FindControl("Mylat2")).Value;
                                Session["myLng"] = lng;

                            }
                            else
                            {
                                Session.Add("myLat", lat);
                                Session.Add("myLng", lng);
                            }

                            LoadMyCache();

                            CostCenter myCost = new CostCenter();
                            myCost.Branch = 1;
                            if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCost.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                            myCost.Code = ax.MainBran;
                            myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                      where citm.Code == myCost.Code
                                      select citm).FirstOrDefault();
                            if (myCost != null)
                            {
                                Session.Add("SiteInfo", myCost);
                                Session.Add("AreaName", myCost.Name1);
                            }
                            else
                            {
                                Response.Redirect("logout.aspx");
                            }


                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetLocalResourceObject("Login").ToString(), GetLocalResourceObject("Login").ToString(), GetLocalResourceObject("SuccessLogin").ToString(), "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            if (Session["CNN"].ToString().ToUpper() == "MYCNN" && (int.Parse(String.Format("{0:HH}", moh.Nows())) == 8 || int.Parse(String.Format("{0:HH}", moh.Nows())) == 9))
                            //if (Session["CNN"].ToString().ToUpper() == "MYCNN")
                            {
                                try
                                {
                                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetLocalResourceObject("Home").ToString(), GetLocalResourceObject("Auto").ToString(), GetLocalResourceObject("MakeBackup").ToString(), "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                    moh.Backup(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, ConfigurationManager.AppSettings["BackupPath"].ToString());  // Server.MapPath("/Backup")

                                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetLocalResourceObject("Home").ToString(), GetLocalResourceObject("Auto").ToString(), GetLocalResourceObject("MakeTally").ToString(), "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                    moh.Tally(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString, short.Parse(HttpContext.Current.Session["Branch"].ToString()));
                                }
                                catch (Exception ex)
                                {
                                    LblError.ForeColor = System.Drawing.Color.Red;
                                    LblError.Text += ex.Message.ToString();
                                }
                            }


                            if ((bool)ax.ChangePass)
                            {
                                if (((List<TblRoles>)(Session["Roll"]))[0].Interface == 0)
                                {
                                    Response.Redirect(ChkFast.Checked ? "default2.aspx" : "default.aspx");
                                }
                                else if (((List<TblRoles>)(Session["Roll"]))[0].Interface == 1)
                                {
                                    Session["StoreNo"] = "1";
                                    Session["AreaNo"] = "00001";
                                    Response.Redirect("Default_Support.aspx");
                                }
                                else if (((List<TblRoles>)(Session["Roll"]))[0].Interface == 2)
                                {
                                    Session["StoreNo"] = "1";
                                    Session["AreaNo"] = "00001";
                                    Response.Redirect("Default_Vendor.aspx");
                                }
                                else if (((List<TblRoles>)(Session["Roll"]))[0].Interface == 3)
                                {
                                    Session["StoreNo"] = "1";
                                    Session["AreaNo"] = "00001";
                                    Response.Redirect("Default_Client.aspx");
                                }
                                else Response.Redirect(redirUrl);
                            }
                            else Response.Redirect("ResetPassword.aspx");
                        }
                        else
                        {
                            LblError.Text = GetLocalResourceObject("UserNamePasswordError").ToString();   // "خطأ في اسم المستخدم او كلمة المرور ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblError.Text, true, false), true);
                        }
                    }
                    else
                    {
                        LblError.Text = GetLocalResourceObject("UserNamePasswordError").ToString();   //"خطأ في اسم المستخدم او كلمة المرور ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblError.Text, true, false), true);
                    }
                }
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message.ToString();
            }
        }
    }

    public static class IPNetworking
    {
        public static string GetIP4Address()
        {
            string IP4Address = String.Empty;

            foreach (IPAddress IPA in Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            if (IP4Address != String.Empty)
            {
                return IP4Address;
            }

            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }
            //string ipaddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            //if (ipaddress == "" || ipaddress == null) ipaddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            return IP4Address;
        }
    }
}