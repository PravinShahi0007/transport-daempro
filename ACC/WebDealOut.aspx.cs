using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using System.Configuration;
using BLL;
using System.Web.Configuration;

namespace ACC
{
    public partial class WebDealOut : System.Web.UI.Page
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


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "أعدادات خط سير المعاملة";
                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = "الرئيسية";
                        UserTran.FormAction = "اختيار";
                        UserTran.Description = "تم اختيار صفحة أعدادات خط سير المعاملة";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    if (Request.QueryString["AreaNo"] != null)
                    {
                        AreaNo = Request.QueryString["AreaNo"].ToString();
                    }
                    else
                    {
                        AreaNo = Session["AreaNo"].ToString();
                    }


                    if (Request.QueryString["StoreNo"] != null) StoreNo = Request.QueryString["StoreNo"].ToString();
                    else
                    {
                        if (Session["StoreNo"] == null) Session["StoreNo"] = 1;
                        StoreNo = Session["StoreNo"].ToString();
                    }

                    Functions1 myFun = new Functions1();
                    ddlType1.DataTextField = "Name";
                    ddlType1.DataValueField = "FType";
                    ddlType1.DataSource = myFun.GetAll((Request.QueryString["Support"] != null),AreaNo,StoreNo,WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlType1.DataBind();
                    ddlType1.Items.Insert(0, new ListItem("--- أختر نوع المعاملة ---", "-1", true));

                    ddlcreat.DataTextField = "Name1";
                    ddlcreat.DataValueField = "Name2";

                    ddlappr1.DataTextField = "Name1";
                    ddlappr1.DataValueField = "Name2";
                    ddlappr2.DataTextField = "Name1";
                    ddlappr2.DataValueField = "Name2";
                    ddlappr3.DataTextField = "Name1";
                    ddlappr3.DataValueField = "Name2";
                    ddlappr4.DataTextField = "Name1";
                    ddlappr4.DataValueField = "Name2";
                    ddlappr5.DataTextField = "Name1";
                    ddlappr5.DataValueField = "Name2";
                    ddlappr6.DataTextField = "Name1";
                    ddlappr6.DataValueField = "Name2";
                    ddlappr7.DataTextField = "Name1";
                    ddlappr7.DataValueField = "Name2";
                    ddlappr8.DataTextField = "Name1";
                    ddlappr8.DataValueField = "Name2";

                    Codes myCode = new Codes();
                    List<Codes> lCode = new List<Codes>();                                           
                    TblRoles myRoles = new TblRoles();
                    if (Cache["Roles" + Session["CNN2"].ToString()] == null) Cache.Insert("Roles" + Session["CNN2"].ToString(), myRoles.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    lCode = (from itm in (List<TblRoles>)(Cache["Roles" + Session["CNN2"].ToString()])
                             select new Codes
                             {
                                  Name1 = itm.RoleName,
                                  Name2 = itm.RoleName
                             }).ToList();

                    lCode.AddRange((from itm in (List<TblUsers>)HttpRuntime.Cache["Users" + Session["CNN2"].ToString()]
                             select new Codes
                             {
                                 Name1 = itm.UserName,
                                 Name2 = itm.UserName
                             }).ToList());

                    //myCode.Branch = short.Parse(Session["Branch"].ToString());
                    //myCode.Ftype = 3;
                    //lCode.AddRange((from itm in myCode.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                    //         select new Codes
                    //         {
                    //             Name1 = itm.Name1,
                    //             Name2 = itm.Code.ToString()
                    //         }).ToList());




                    ddlcreat.DataSource = lCode;
                    ddlcreat.DataBind();
                    ddlcreat.Items.Insert(0, new ListItem("جميع المستخدمين", "*", true));
                    ddlappr1.Items.Insert(0, new ListItem("--- اختيار ---", "-1", true));
                   

                    ddlappr1.DataSource = lCode;
                    ddlappr2.DataSource = lCode;
                    ddlappr3.DataSource = lCode;
                    ddlappr4.DataSource = lCode;
                    ddlappr5.DataSource = lCode;
                    ddlappr6.DataSource = lCode;
                    ddlappr7.DataSource = lCode;
                    ddlappr8.DataSource = lCode;

                    ddlappr1.DataBind();
                    ddlappr2.DataBind();
                    ddlappr3.DataBind();
                    ddlappr4.DataBind();
                    ddlappr5.DataBind();
                    ddlappr6.DataBind();
                    ddlappr7.DataBind();
                    ddlappr8.DataBind();

                    ddlappr1.Items.Insert(0, new ListItem("المدير المباشر", "1", true));
                    ddlappr1.Items.Insert(0, new ListItem("--- اختيار ---", "-1", true));

                    ddlappr2.Items.Insert(0, new ListItem("المدير المباشر", "1", true));
                    ddlappr2.Items.Insert(0, new ListItem("--- اختيار ---", "-1", true));

                    ddlappr3.Items.Insert(0, new ListItem("المدير المباشر", "1", true));
                    ddlappr3.Items.Insert(0, new ListItem("--- اختيار ---", "-1", true));

                    ddlappr4.Items.Insert(0, new ListItem("المدير المباشر", "1", true));
                    ddlappr4.Items.Insert(0, new ListItem("--- اختيار ---", "-1", true));

                    ddlappr5.Items.Insert(0, new ListItem("المدير المباشر", "1", true));
                    ddlappr5.Items.Insert(0, new ListItem("--- اختيار ---", "-1", true));

                    ddlappr6.Items.Insert(0, new ListItem("المدير المباشر", "1", true));
                    ddlappr6.Items.Insert(0, new ListItem("--- اختيار ---", "-1", true));

                    ddlappr7.Items.Insert(0, new ListItem("المدير المباشر", "1", true));
                    ddlappr7.Items.Insert(0, new ListItem("--- اختيار ---", "-1", true));

                    ddlappr8.Items.Insert(0, new ListItem("المدير المباشر", "1", true));
                    ddlappr8.Items.Insert(0, new ListItem("--- اختيار ---", "-1", true));
                    ddlType1_SelectedIndexChanged(sender, e);
                }
                else
                {
                    LblCodesResult.Text = "";
                }

            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Functions1 myFun = new Functions1();
                myFun.FType = int.Parse(ddlType1.SelectedValue);
                myFun = myFun.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myFun != null)
                {
                    myFun.FStep1 = ddlappr1.SelectedValue;
                    myFun.FStep2 = ddlappr2.SelectedValue;
                    myFun.FStep3 = ddlappr3.SelectedValue;
                    myFun.FStep4 = ddlappr4.SelectedValue;
                    myFun.FStep5 = ddlappr5.SelectedValue;
                    myFun.FStep6 = ddlappr6.SelectedValue;
                    myFun.FStep7 = ddlappr7.SelectedValue;
                    myFun.FStep8 = ddlappr8.SelectedValue;
                    myFun.SType1 = short.Parse(ddlSType1.SelectedValue);
                    myFun.SType2 = short.Parse(ddlSType2.SelectedValue);
                    myFun.SType3 = short.Parse(ddlSType3.SelectedValue);
                    myFun.SType4 = short.Parse(ddlSType4.SelectedValue);
                    myFun.SType5 = short.Parse(ddlSType5.SelectedValue);
                    myFun.SType6 = short.Parse(ddlSType6.SelectedValue);
                    myFun.SType7 = short.Parse(ddlSType7.SelectedValue);
                    myFun.SType8 = short.Parse(ddlSType8.SelectedValue);
                    myFun.Action1 = ChkAction1.Checked;
                    myFun.Action2 = ChkAction2.Checked;
                    myFun.Action3 = ChkAction3.Checked;
                    myFun.Action4 = ChkAction4.Checked;
                    myFun.Action5 = ChkAction5.Checked;
                    myFun.Action6 = ChkAction6.Checked;
                    myFun.Action7 = ChkAction7.Checked;
                    myFun.Action8 = ChkAction8.Checked;

                    string vCreate = "";
                    for (int i = 0; i < ddlcreat.Items.Count; i++)
                    {
                        if (ddlcreat.Items[i].Selected)
                        {
                            vCreate += (vCreate != "" ? ";" : "") + ddlcreat.Items[i].Value;
                        }
                    }
                    myFun.FCreate = vCreate;

                    if (myFun.Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormName = "خط سير المعاملة";
                            UserTran.FormAction = "تعديل";
                            UserTran.Description = "تعديل بيانات خط سير المعاملة  " + ddlType1.SelectedItem.Text;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }

                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تم تحديث البيانات بنجاح";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(1,'" + LblCodesResult.Text + "');", true);
                        BtnClear_Click(sender, e);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ اثناء تحديث البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void ddlType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BtnClear_Click(null, null);
                if (ddlType1.SelectedValue != "-1")
                {
                    Functions1 myFun = new Functions1();
                    myFun.FType = int.Parse(ddlType1.SelectedValue);
                    myFun = myFun.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myFun != null)
                    {
                        if (!string.IsNullOrEmpty(myFun.FStep1)) ddlappr1.SelectedValue = myFun.FStep1;
                        if (!string.IsNullOrEmpty(myFun.FStep2)) ddlappr2.SelectedValue = myFun.FStep2;
                        if (!string.IsNullOrEmpty(myFun.FStep3)) ddlappr3.SelectedValue = myFun.FStep3;
                        if (!string.IsNullOrEmpty(myFun.FStep4)) ddlappr4.SelectedValue = myFun.FStep4;
                        if (!string.IsNullOrEmpty(myFun.FStep5)) ddlappr5.SelectedValue = myFun.FStep5;
                        if (!string.IsNullOrEmpty(myFun.FStep6)) ddlappr6.SelectedValue = myFun.FStep6;
                        if (!string.IsNullOrEmpty(myFun.FStep7)) ddlappr7.SelectedValue = myFun.FStep7;
                        if (!string.IsNullOrEmpty(myFun.FStep8)) ddlappr8.SelectedValue = myFun.FStep8;
                        ddlSType1.SelectedValue = myFun.SType1.ToString();
                        ddlSType2.SelectedValue = myFun.SType2.ToString();
                        ddlSType3.SelectedValue = myFun.SType3.ToString();
                        ddlSType4.SelectedValue = myFun.SType4.ToString();
                        ddlSType5.SelectedValue = myFun.SType5.ToString();
                        ddlSType6.SelectedValue = myFun.SType6.ToString();
                        ddlSType7.SelectedValue = myFun.SType7.ToString();
                        ddlSType8.SelectedValue = myFun.SType8.ToString();
                        ChkAction1.Checked = (bool)myFun.Action1;
                        ChkAction2.Checked = (bool)myFun.Action2;
                        ChkAction3.Checked = (bool)myFun.Action3;
                        ChkAction4.Checked = (bool)myFun.Action4;
                        ChkAction5.Checked = (bool)myFun.Action5;
                        ChkAction6.Checked = (bool)myFun.Action6;
                        ChkAction7.Checked = (bool)myFun.Action7;
                        ChkAction8.Checked = (bool)myFun.Action8;

                        if (!string.IsNullOrEmpty(myFun.FCreate))
                        {
                            if (myFun.FCreate.Split(';').Count() > 0)
                            {
                                foreach (string itm in myFun.FCreate.Split(';'))
                                {
                                    for (int i = 0; i < ddlcreat.Items.Count; i++)
                                    {
                                        if (ddlcreat.Items[i].Value == itm)
                                        {
                                            ddlcreat.Items[i].Selected = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < ddlcreat.Items.Count; i++)
                                {
                                    if (ddlcreat.Items[i].Value == myFun.FCreate)
                                    {
                                        ddlcreat.Items[i].Selected = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }             
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void BtnClear_Click(object sender, ImageClickEventArgs e)
        {
            try                        
            {
                if(sender != null) ddlType1.SelectedIndex = 0;
                ddlappr1.SelectedIndex = 0;
                ddlappr2.SelectedIndex = 0;
                ddlappr3.SelectedIndex = 0;
                ddlappr4.SelectedIndex = 0;
                ddlappr5.SelectedIndex = 0;
                ddlappr6.SelectedIndex = 0;
                ddlappr7.SelectedIndex = 0;
                ddlappr8.SelectedIndex = 0;

                ddlSType1.SelectedIndex = 0;
                ddlSType2.SelectedIndex = 0;
                ddlSType3.SelectedIndex = 0;
                ddlSType4.SelectedIndex = 0;
                ddlSType5.SelectedIndex = 0;
                ddlSType6.SelectedIndex = 0;
                ddlSType7.SelectedIndex = 0;
                ddlSType8.SelectedIndex = 0;

                ChkAction1.Checked = false;
                ChkAction2.Checked = false;
                ChkAction3.Checked = false;
                ChkAction4.Checked = false;
                ChkAction5.Checked = false;
                ChkAction6.Checked = false;
                ChkAction7.Checked = false;
                ChkAction8.Checked = false;

                for (int i = 0; i < ddlcreat.Items.Count; i++) ddlcreat.Items[i].Selected = false;
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void ChkAction1_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)(sender)).Checked)
            {
                string vs = ((CheckBox)(sender)).ID;
                if (vs.ToUpper() != "CHKACTION1") ChkAction1.Checked = false;
                if (vs.ToUpper() != "CHKACTION2") ChkAction2.Checked = false;
                if (vs.ToUpper() != "CHKACTION3") ChkAction3.Checked = false;
                if (vs.ToUpper() != "CHKACTION4") ChkAction4.Checked = false;
                if (vs.ToUpper() != "CHKACTION5") ChkAction5.Checked = false;
                if (vs.ToUpper() != "CHKACTION6") ChkAction6.Checked = false;
                if (vs.ToUpper() != "CHKACTION7") ChkAction7.Checked = false;
                if (vs.ToUpper() != "CHKACTION8") ChkAction8.Checked = false;
            }

        }
    }
}