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
    public partial class WebSetup : System.Web.UI.Page
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
                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "أعدادات النظام";

                    if (Request.QueryString["StoreNo"] != null) StoreNo = Request.QueryString["StoreNo"].ToString();
                    else
                    {
                        if (Session["StoreNo"] == null) Session["StoreNo"] = 1;
                        StoreNo = Session["StoreNo"].ToString();
                    }

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

                    lblBranch.Text = "/" + short.Parse(AreaNo).ToString();
                    lblBranch1.Text = "/" + short.Parse(AreaNo).ToString();
                    lblBranch2.Text = "/" + short.Parse(AreaNo).ToString();
                    lblBranch3.Text = "/" + short.Parse(AreaNo).ToString();
                    lblBranch4.Text = "/" + short.Parse(AreaNo).ToString();

                    Area myArea = new Area();
                    myArea.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastArea" + Session["CNN2"].ToString()] == null) Cache.Insert("LastArea" + Session["CNN2"].ToString(), myArea.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlArea.DataTextField = "Name1";
                    ddlArea.DataValueField = "Code";
                    ddlArea.DataSource = (List<Area>)(Cache["LastArea" + Session["CNN2"].ToString()]);
                    ddlArea.DataBind();
                    ddlArea.Items.Insert(0, new ListItem("--- أختار المنطقة---", "-1", true));

                    Cities myCity = new Cities();
                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlCity.DataTextField = "Name1";
                    ddlCity.DataValueField = "Code";
                    ddlCity.DataSource = (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()]);
                    ddlCity.DataBind();
                    ddlCity.Items.Insert(0, new ListItem("--- أختار المدينة---", "-1", true));

                    AccProject myProject = new AccProject();
                    myProject.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastProject" + Session["CNN2"].ToString()] == null) Cache.Insert("LastProject" + Session["CNN2"].ToString(), myProject.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlProject.DataTextField = "Name1";
                    ddlProject.DataValueField = "Code";
                    ddlProject.DataSource = (List<AccProject>)(Cache["LastProject" + Session["CNN2"].ToString()]);
                    ddlProject.DataBind();
                    ddlProject.Items.Insert(0, new ListItem("--- أختار المشروع---", "-1", true));

                    Acc myacc = new Acc();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    ddlCashAcc.DataTextField = "Name1";
                    ddlCashAcc.DataValueField = "Code";

                    ddlExpAcc.DataTextField = "Name1";
                    ddlExpAcc.DataValueField = "Code";

                    ddlInComeAcc.DataTextField = "Name1";
                    ddlInComeAcc.DataValueField = "Code";

                    ddlSiteAcc.DataTextField = "Name1";
                    ddlSiteAcc.DataValueField = "Code";

                    ddlDezelAcc.DataTextField = "Name1";
                    ddlDezelAcc.DataValueField = "Code";

                    ddlTripAcc.DataTextField = "Name1";
                    ddlTripAcc.DataValueField = "Code";

                    ddlCurExpAcc.DataTextField = "Name1";
                    ddlCurExpAcc.DataValueField = "Code";

                    ddlClientsAcc.DataTextField = "Name1";
                    ddlClientsAcc.DataValueField = "Code";

                    ddlPettyExpAcc.DataTextField = "Name1";
                    ddlPettyExpAcc.DataValueField = "Code";

                    ddlDiscountAcc.DataTextField = "Name1";
                    ddlDiscountAcc.DataValueField = "Code";

                    ddlRadAcc.DataTextField = "Name1";
                    ddlRadAcc.DataValueField = "Code";

                    ddlLoanAcc.DataTextField = "Name1";
                    ddlLoanAcc.DataValueField = "Code";

                    ddlLateAcc.DataTextField = "Name1";
                    ddlLateAcc.DataValueField = "Code";

                    ddlCancelInvAcc.DataTextField = "Name1";
                    ddlCancelInvAcc.DataValueField = "Code";
                    
                    if (Cache["LastACC" + Session["CNN2"].ToString()] == null) Cache.Insert("LastACC" + Session["CNN2"].ToString(), myacc.GetLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlCashAcc.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                               where itm.FCode.StartsWith("120102")
                                               select itm).ToList();
                    ddlExpAcc.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                            where itm.FCode.StartsWith("310201") 
                                            select itm).ToList();
                    ddlInComeAcc.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                               where itm.FCode.StartsWith("410101")
                                               select itm).ToList();
                    ddlSiteAcc.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                             where itm.FCode.StartsWith("120401")
                                             select itm).ToList();

                    ddlDezelAcc.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                            where itm.FCode.StartsWith("310201") 
                                            select itm).ToList();

                    ddlTripAcc.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                            where itm.FCode.StartsWith("310201")
                                            select itm).ToList();

                    ddlCurExpAcc.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                            where itm.FCode.StartsWith("240104")
                                            select itm).ToList();

                    ddlClientsAcc.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                            where itm.FCode.StartsWith("120301")
                                            select itm).ToList();

                    ddlPettyExpAcc.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                            where itm.FCode.StartsWith("310201")
                                            select itm).ToList();

                    ddlDiscountAcc.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                            where itm.FCode.StartsWith("310201")
                                            select itm).ToList();

                    ddlRadAcc.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                            where itm.FCode.StartsWith("310201")
                                            select itm).ToList();


                    ddlLoanAcc.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                             where itm.FCode.StartsWith("120103")
                                             select itm).ToList();

                    ddlLateAcc.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                             where itm.FCode.StartsWith("410101")
                                             select itm).ToList();

                    ddlCancelInvAcc.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                             where itm.FCode.StartsWith("410101")
                                             select itm).ToList();

                    txtCrLimit.Text = "0";
                    ddlCashAcc.DataBind();
                    ddlCashAcc.Items.Insert(0, new ListItem("--- أختار حساب الصندوق ---", "-1", true));
                    ddlExpAcc.DataBind();
                    ddlExpAcc.Items.Insert(0, new ListItem("--- أختار حساب مصاريف التشغيل ---", "-1", true));
                    ddlInComeAcc.DataBind();
                    ddlInComeAcc.Items.Insert(0, new ListItem("--- أختار حساب الايرادات ---", "-1", true));
                    ddlSiteAcc.DataBind();
                    ddlSiteAcc.Items.Insert(0, new ListItem("--- أختار حساب الفرع ---", "-1", true));
                    ddlDezelAcc.DataBind();
                    ddlDezelAcc.Items.Insert(0, new ListItem("--- أختار حساب الديزل ---", "-1", true));
                    ddlTripAcc.DataBind();
                    ddlTripAcc.Items.Insert(0, new ListItem("--- أختار حساب بدل الرحلات ---", "-1", true));
                    ddlCurExpAcc.DataBind();
                    ddlCurExpAcc.Items.Insert(0, new ListItem("--- أختار حساب مصاريف مستحقة ---", "-1", true));
                    ddlClientsAcc.DataBind();
                    ddlClientsAcc.Items.Insert(0, new ListItem("--- أختار حساب العملاء ---", "-1", true));
                    ddlPettyExpAcc.DataBind();
                    ddlPettyExpAcc.Items.Insert(0, new ListItem("--- أختار حساب المصروفات النثرية ---", "-1", true));
                    ddlDiscountAcc.DataBind();
                    ddlDiscountAcc.Items.Insert(0, new ListItem("--- أختار حساب الخصم ---", "-1", true));
                    ddlRadAcc.DataBind();
                    ddlRadAcc.Items.Insert(0, new ListItem("--- أختار حساب الرد ---", "-1", true));
                    ddlLoanAcc.DataBind();
                    ddlLoanAcc.Items.Insert(0, new ListItem("--- أختار حساب العهدة المستديمة ---", "-1", true));
                    ddlLateAcc.DataBind();
                    ddlLateAcc.Items.Insert(0, new ListItem("--- أختار حساب الارضية ---", "-1", true));
                    ddlCancelInvAcc.DataBind();
                    ddlCancelInvAcc.Items.Insert(0, new ListItem("--- أختار حساب الرسوم الإدارية ---", "-1", true));

                    txtInvNo.Text = SiteInfo.InvNo.ToString();
                    txtRecNo.Text = SiteInfo.RecNo.ToString();
                    txtPayNo.Text = SiteInfo.PayNo.ToString();
                    txtCarMoveNo.Text = SiteInfo.CarMoveNo.ToString();
                    txtCarRcvNo.Text = SiteInfo.CarRcvNo.ToString();

                    ddlCashAcc.SelectedValue = SiteInfo.CashAcc;
                    ddlExpAcc.SelectedValue = SiteInfo.ExpAcc;
                    ddlInComeAcc.SelectedValue = SiteInfo.InComeAcc;
                    ddlSiteAcc.SelectedValue = SiteInfo.SiteAcc;
                    ddlArea.SelectedValue = SiteInfo.Area;
                    ddlProject.SelectedValue = SiteInfo.Project;
                    ddlCity.SelectedValue = SiteInfo.City;
                    ddlDezelAcc.SelectedValue = SiteInfo.DezelAcc;
                    ddlTripAcc.SelectedValue = SiteInfo.TripAcc;
                    ddlCurExpAcc.SelectedValue = SiteInfo.CurExpAcc;
                    ddlClientsAcc.SelectedValue = SiteInfo.ClientsAcc;
                    ddlPettyExpAcc.SelectedValue = SiteInfo.PettyExpAcc;
                    ddlDiscountAcc.SelectedValue = SiteInfo.DiscountAcc;
                    ddlRadAcc.SelectedValue = SiteInfo.RadAcc;
                    ddlLoanAcc.SelectedValue = SiteInfo.LoanAcc;
                    ddlLateAcc.SelectedValue = SiteInfo.LateAcc;
                    ddlCancelInvAcc.SelectedValue = SiteInfo.CancelInvAcc;
                    txtLandDay.Text = SiteInfo.LandDay.ToString();
                    txtLandHour.Text = SiteInfo.LandHour.ToString();
                    txtCrLimit.Text = SiteInfo.CrLimit.ToString();
                    lblSMS.Text = sms.GetBalance();

                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    string vRoleName = moh.GetCurrentRole(AreaNo, (from useritm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                                                  where useritm.UserName == Session["CurrentUser"].ToString()
                                                                  select useritm).FirstOrDefault());
                    if (Session[vRoleName] == null)
                    {
                        Response.Redirect("WebNotPrev.aspx", false);
                        return;
                    }
                    //BtnEdit.Visible = (bool)((List<TblRoles>)(Session["vRoleName"]))[1].Pass301;

                    if (SiteInfo.UserName == "")
                    {
                        txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                        txtUserName.Text = Session["FullUser"].ToString();
                        txtUserDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    }
                    else
                    {
                        txtUserName.ToolTip = SiteInfo.UserName;
                        TblUsers ax0 = new TblUsers();
                        if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax0.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        ax.UserName = SiteInfo.UserName;
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
                        txtUserDate.Text = SiteInfo.UserDate;
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
                    SiteInfo.InvNo = int.Parse(txtInvNo.Text);
                    SiteInfo.RecNo = int.Parse(txtRecNo.Text);
                    SiteInfo.PayNo = int.Parse(txtPayNo.Text);
                    SiteInfo.CarMoveNo = int.Parse(txtCarMoveNo.Text);
                    SiteInfo.CarRcvNo = int.Parse(txtCarRcvNo.Text);

                    SiteInfo.CashAcc = ddlCashAcc.SelectedValue;
                    SiteInfo.ExpAcc = ddlExpAcc.SelectedValue;
                    SiteInfo.InComeAcc = ddlInComeAcc.SelectedValue;
                    SiteInfo.SiteAcc = ddlSiteAcc.SelectedValue;

                    SiteInfo.DezelAcc = ddlDezelAcc.SelectedValue;
                    SiteInfo.TripAcc = ddlTripAcc.SelectedValue;
                    SiteInfo.CurExpAcc = ddlCurExpAcc.SelectedValue;
                    SiteInfo.ClientsAcc = ddlClientsAcc.SelectedValue;
                    SiteInfo.PettyExpAcc = ddlPettyExpAcc.SelectedValue;
                    SiteInfo.DiscountAcc = ddlDiscountAcc.SelectedValue;
                    SiteInfo.RadAcc = ddlRadAcc.SelectedValue;

                    SiteInfo.Area = ddlArea.SelectedValue;
                    SiteInfo.Project = ddlProject.SelectedValue;
                    SiteInfo.City = ddlCity.SelectedValue;
                    SiteInfo.LoanAcc = ddlLoanAcc.SelectedValue;
                    SiteInfo.LateAcc = ddlLateAcc.SelectedValue;
                    SiteInfo.CancelInvAcc = ddlCancelInvAcc.SelectedValue;
                    SiteInfo.LandDay = moh.StrToDouble(txtLandDay.Text);
                    SiteInfo.LandHour = moh.StrToDouble(txtLandHour.Text);
                    SiteInfo.CrLimit = moh.StrToDouble(txtCrLimit.Text);
                    SiteInfo.Addr1 = txtAddr1.Text;
                    SiteInfo.Addr2 = txtAddr2.Text;
                    SiteInfo.Addr3 = txtAddr3.Text;
                    SiteInfo.Addr4 = txtAddr4.Text;
                    SiteInfo.Addr5 = txtAddr5.Text;
                    SiteInfo.Addr6 = txtAddr6.Text;
                    SiteInfo.Addr7 = txtAddr7.Text;
                    SiteInfo.Addr8 = txtAddr8.Text;

                    Session["SiteInfo"] = SiteInfo;

                    if (SiteInfo.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء تعديل البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
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