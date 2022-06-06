using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using BLL;
using System.Web.Configuration;
using System.Reflection;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class WebProfile : System.Web.UI.Page
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
                    ViewState["StoreNo"] = "00001";
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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad0);
                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "الملف الشخصي";
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
                        UserTran.Description = "تم اختيار صفحة الملف الشخصي";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    Prev myPrev = new Prev();
                    ChkPass.DataTextField = "Name";
                    ChkPass.DataValueField = "KeyName";
                    //ChkPass.DataSource = myPrev.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ChkPass.DataSource = (from itm in myPrev.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                          where CheckItem(itm.KeyName)
                                          select itm).ToList();

                    ChkPass.DataBind();

                    CostCenter myCostCenter = new CostCenter();
                    myCostCenter.Branch = 1;
                    if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ChkBranch.DataTextField = "Name1";
                    ChkBranch.DataValueField = "Code";
                    ChkBranch.DataSource = (from itm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                            select new CostCenter { Name1 = itm.Name1, Code = itm.Code }).ToList();
                    ChkBranch.DataBind();


                    // Check if User Exists
                    txtName.Text = Session["CurrentUser"].ToString();
                    TblUsers myUser = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), myUser.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myUser.UserName = Session["CurrentUser"].ToString();
                    myUser = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                              where uitm.UserName == myUser.UserName
                              select uitm).FirstOrDefault();
                    if (myUser != null)
                    {
                        txtFName.Text = myUser.FName;
                        txtMobile.Text = myUser.Mobile;
                        txtTel.Text = myUser.tel;
                        txtEmail.Text = myUser.Email;

                        MyConfig mysetting = new MyConfig();
                        mysetting.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mysetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        mysetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                        if (mysetting != null)
                        {
                            if (!string.IsNullOrEmpty(myUser.Photo))
                            {
                                BtnLoad0.ToolTip = myUser.Photo;
                                string url = mysetting.ImagePath2 + myUser.Photo;
                                ImgPhoto.Src = url;
                            }
                            else ImgPhoto.Src = "images/123.jpg";
                        }
                        else ImgPhoto.Src = "images/123.jpg";


                        if (!string.IsNullOrEmpty(myUser.MainBran) && myUser.MainBran != "-1")
                        {
                            myCostCenter = new CostCenter();
                            myCostCenter.Branch = 1;
                            if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                            myCostCenter.Code = myUser.MainBran;
                            myCostCenter = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                            where citm.Code == myCostCenter.Code
                                            select citm).FirstOrDefault();
                            if (myCostCenter != null) txtMainBran.Text = myCostCenter.Name1;
                        }

                        if (!string.IsNullOrEmpty(myUser.BranRoll) && myUser.BranRoll != "-1")
                        {
                            txtBranRoll.Text = myUser.BranRoll;
                        }

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

                        TblUsersInRole UR2 = new TblUsersInRole();                        
                        UR2.UserName = myUser.UserName;
                        UR2 = UR2.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                        if (UR2 != null) 
                        {
                            txtRole.Text = UR2.RoleName;

                            TblRoles myRollA = new TblRoles();
                            myRollA.RoleName = txtRole.Text;
                            myRollA.PassType = "A";
                            myRollA = myRollA.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myRollA != null)
                            {
                                TblRoles myRollB = new TblRoles();
                                myRollB.RoleName = txtRole.Text;
                                myRollB.PassType = "B";
                                myRollB = myRollB.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (myRollB != null)
                                {
                                    TblRoles myRollC = new TblRoles();
                                    myRollC.RoleName = txtRole.Text;
                                    myRollC.PassType = "C";
                                    myRollC = myRollC.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (myRollC != null)
                                    {
                                        TblRoles myRollD = new TblRoles();
                                        myRollD.RoleName = txtRole.Text;
                                        myRollD.PassType = "D";
                                        myRollD = myRollD.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if (myRollD != null)
                                        {
                                            for (int i = 0; i < ChkPass.Items.Count; i++)
                                            {
                                                if (ChkPass.Items[i].Value.Substring(0, 5) == "PassA")
                                                {
                                                    PropertyInfo propertyInfo = typeof(TblRoles).GetProperty("Pass" + (ChkPass.Items[i].Value.Substring(5, ChkPass.Items[i].Value.Length - 5)));
                                                    ChkPass.Items[i].Selected = (bool)propertyInfo.GetValue(myRollA, null);
                                                }
                                                else if (ChkPass.Items[i].Value.Substring(0, 5) == "PassB")
                                                {
                                                    PropertyInfo propertyInfo = typeof(TblRoles).GetProperty("Pass" + (ChkPass.Items[i].Value.Substring(5, ChkPass.Items[i].Value.Length - 5)));
                                                    ChkPass.Items[i].Selected = (bool)propertyInfo.GetValue(myRollB, null);
                                                }
                                                else if (ChkPass.Items[i].Value.Substring(0, 5) == "PassC")
                                                {
                                                    PropertyInfo propertyInfo = typeof(TblRoles).GetProperty("Pass" + (ChkPass.Items[i].Value.Substring(5, ChkPass.Items[i].Value.Length - 5)));
                                                    ChkPass.Items[i].Selected = (bool)propertyInfo.GetValue(myRollC, null);
                                                }
                                                else if (ChkPass.Items[i].Value.Substring(0, 5) == "PassD")
                                                {
                                                    PropertyInfo propertyInfo = typeof(TblRoles).GetProperty("Pass" + (ChkPass.Items[i].Value.Substring(5, ChkPass.Items[i].Value.Length - 5)));
                                                    ChkPass.Items[i].Selected = (bool)propertyInfo.GetValue(myRollD, null);
                                                }
                                            }
                                        }
                                    }
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

        public bool CheckItem(string keyname)
        {
            if ((string)((List<TblRoles>)(Session["Roll"]))[0].RoleName.ToUpper() == "ADMIN") return true;
            else
            {
                PropertyInfo propertyInfo = typeof(TblRoles).GetProperty("Pass" + (keyname.Substring(5, keyname.Length - 5)));
                return (bool)propertyInfo.GetValue(((List<TblRoles>)(Session["Roll"]))[
                    keyname.Substring(0, 5) == "PassA" ? 0 :
                    keyname.Substring(0, 5) == "PassB" ? 1 :
                    keyname.Substring(0, 5) == "PassC" ? 2 : 3], null);
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
                        string ImageUrl = "";
                        MyConfig mysetting = new MyConfig();
                        mysetting.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mysetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        mysetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                        if (mysetting != null)
                        {
                            ImageUrl = mysetting.ImagePath2;
                        }

                        FileUpload0.SaveAs(Server.MapPath(ImageUrl) + @"/" + FileName);
                        BtnLoad0.ToolTip = FileName;
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

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
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
                        myUser.FName = txtFName.Text;
                        myUser.Mobile = txtMobile.Text;
                        myUser.tel = txtTel.Text;
                        myUser.Email = txtEmail.Text;
                        myUser.UserOP = "تعديل";
                        myUser.Photo = BtnLoad0.ToolTip;
                        if (myUser.Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.FormName = "الملف الشخصي";
                                UserTran.FormAction = "تعديل";
                                UserTran.Description = "تعديل بيانات المستخدم " + txtName.Text;
                                //UserTran.Reason = txtReason.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }

                            if (Cache["Users" + Session["CNN2"].ToString()] != null) Cache.Remove("Users" + Session["CNN2"].ToString());
                            TblUsers ax = new TblUsers();
                            if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
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

    }
}