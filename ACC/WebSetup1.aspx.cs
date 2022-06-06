using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class WebSetup1 : System.Web.UI.Page
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
        public string ShiftTip
        {
            get
            {
                if (ViewState["ShiftTip"] == null)
                {
                    ViewState["ShiftTip"] = "";
                }
                return ViewState["ShiftTip"].ToString();
            }
            set { ViewState["ShiftTip"] = value; }
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

                    //BtnEdit.Visible = (bool)((TblRoles)(Session["Roll"])).Pass301;
                    ShiftTip = "";
                    Acc myacc = new Acc();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastACC" + Session["CNN2"].ToString()] == null) Cache.Insert("LastACC" + Session["CNN2"].ToString(), myacc.GetLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlAdd01.DataTextField = "Name1";
                    ddlAdd01.DataValueField = "Code";
                    ddlAdd02.DataTextField = "Name1";
                    ddlAdd02.DataValueField = "Code";
                    ddlAdd03.DataTextField = "Name1";
                    ddlAdd03.DataValueField = "Code";
                    ddlAdd04.DataTextField = "Name1";
                    ddlAdd04.DataValueField = "Code";
                    ddlAdd05.DataTextField = "Name1";
                    ddlAdd05.DataValueField = "Code";
                    ddlAdd06.DataTextField = "Name1";
                    ddlAdd06.DataValueField = "Code";
                    ddlAdd07.DataTextField = "Name1";
                    ddlAdd07.DataValueField = "Code";
                    ddlAdd08.DataTextField = "Name1";
                    ddlAdd08.DataValueField = "Code";
                    ddlAdd09.DataTextField = "Name1";
                    ddlAdd09.DataValueField = "Code";
                    ddlAdd10.DataTextField = "Name1";
                    ddlAdd10.DataValueField = "Code";
                    ddlAdd11.DataTextField = "Name1";
                    ddlAdd11.DataValueField = "Code";
                    ddlAdd12.DataTextField = "Name1";
                    ddlAdd12.DataValueField = "Code";
                    ddlAdd13.DataTextField = "Name1";
                    ddlAdd13.DataValueField = "Code";
                    ddlAdd14.DataTextField = "Name1";
                    ddlAdd14.DataValueField = "Code";
                    ddlAdd15.DataTextField = "Name1";
                    ddlAdd15.DataValueField = "Code";

                    ddlDed01.DataTextField = "Name1";
                    ddlDed01.DataValueField = "Code";
                    ddlDed02.DataTextField = "Name1";
                    ddlDed02.DataValueField = "Code";
                    ddlDed03.DataTextField = "Name1";
                    ddlDed03.DataValueField = "Code";
                    ddlDed04.DataTextField = "Name1";
                    ddlDed04.DataValueField = "Code";
                    ddlDed05.DataTextField = "Name1";
                    ddlDed05.DataValueField = "Code";
                    ddlDed06.DataTextField = "Name1";
                    ddlDed06.DataValueField = "Code";
                    ddlDed07.DataTextField = "Name1";
                    ddlDed07.DataValueField = "Code";
                    ddlDed08.DataTextField = "Name1";
                    ddlDed08.DataValueField = "Code";
                    ddlDed09.DataTextField = "Name1";
                    ddlDed09.DataValueField = "Code";
                    ddlDed10.DataTextField = "Name1";
                    ddlDed10.DataValueField = "Code";
                    ddlDed11.DataTextField = "Name1";
                    ddlDed11.DataValueField = "Code";
                    ddlDed12.DataTextField = "Name1";
                    ddlDed12.DataValueField = "Code";
                    ddlDed13.DataTextField = "Name1";
                    ddlDed13.DataValueField = "Code";
                    ddlDed14.DataTextField = "Name1";
                    ddlDed14.DataValueField = "Code";
                    ddlDed15.DataTextField = "Name1";
                    ddlDed15.DataValueField = "Code";

                    ddlBasic.DataTextField = "Name1";
                    ddlBasic.DataValueField = "Code";

                    ddlShift.DataTextField = "Name1";
                    ddlShift.DataValueField = "Code";

                    Codes myCode = new Codes();
                    myCode.Branch = short.Parse(Session["Branch"].ToString());
                    myCode.Ftype = 20;
                    if (Cache["LastCodes" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCodes" + Session["CNN2"].ToString(), myCode.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlShift.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                           where itm.Ftype == 20
                                           select itm).ToList();

                    ddlAdd01.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlAdd02.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlAdd03.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlAdd04.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlAdd05.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlAdd06.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlAdd07.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlAdd08.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlAdd09.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlAdd10.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlAdd11.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlAdd12.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlAdd13.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlAdd14.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlAdd15.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);

                    ddlDed01.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlDed02.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    if (Cache["AllACC" + Session["CNN2"].ToString()] == null) Cache.Insert("AllACC" + Session["CNN2"].ToString(), myacc.Getall(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlDed03.DataSource = (List<Acc>)(Cache["AllACC" + Session["CNN2"].ToString()]);
                    ddlDed04.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlDed05.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlDed06.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlDed07.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlDed08.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlDed09.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlDed10.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlDed11.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlDed12.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlDed13.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlDed14.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);
                    ddlDed15.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);

                    ddlBasic.DataSource = (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()]);

                    ddlAdd01.DataBind();
                    ddlAdd02.DataBind();
                    ddlAdd03.DataBind();
                    ddlAdd04.DataBind();
                    ddlAdd05.DataBind();
                    ddlAdd06.DataBind();
                    ddlAdd07.DataBind();
                    ddlAdd08.DataBind();
                    ddlAdd09.DataBind();
                    ddlAdd10.DataBind();
                    ddlAdd11.DataBind();
                    ddlAdd12.DataBind();
                    ddlAdd13.DataBind();
                    ddlAdd14.DataBind();
                    ddlAdd15.DataBind();

                    ddlDed01.DataBind();
                    ddlDed02.DataBind();
                    ddlDed03.DataBind();
                    ddlDed04.DataBind();
                    ddlDed05.DataBind();
                    ddlDed06.DataBind();
                    ddlDed07.DataBind();
                    ddlDed08.DataBind();
                    ddlDed09.DataBind();
                    ddlDed10.DataBind();
                    ddlDed11.DataBind();
                    ddlDed12.DataBind();
                    ddlDed13.DataBind();
                    ddlDed14.DataBind();
                    ddlDed15.DataBind();

                    ddlBasic.DataBind();
                    ddlShift.DataBind();
                    ddlShift_SelectedIndexChanged(sender, e);

                    ddlAdd01.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlAdd02.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlAdd03.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlAdd04.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlAdd05.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlAdd06.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlAdd07.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlAdd08.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlAdd09.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlAdd10.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlAdd11.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlAdd12.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlAdd13.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlAdd14.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlAdd15.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));

                    ddlDed01.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlDed02.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlDed03.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlDed04.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlDed05.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlDed06.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlDed07.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlDed08.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlDed09.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlDed10.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlDed11.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlDed12.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlDed13.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlDed14.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    ddlDed15.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));

                    ddlBasic.Items.Insert(0, new ListItem("--- أختار الحساب ---", "-1", true));
                    
                    Timers mytime = new Timers();
                    grdCodes.DataSource = mytime.GetAll(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString);
                    grdCodes.DataBind();
                    //BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[3].Pass301;
                    LoadConfig();
                }
                else
                {
                    ddlShift.ToolTip = ShiftTip;
                    LblCodesResult.Text = "";
                }

            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
             
        }

        public void LoadConfig()
        {
            try
            {
                MyConfig mysetting = new MyConfig();
                mysetting.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mysetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                mysetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                if (mysetting != null)
                {
                    txtAdd01.Text = mysetting.Add01;
                    txtAdd02.Text = mysetting.Add02;
                    txtAdd03.Text = mysetting.Add03;
                    txtAdd04.Text = mysetting.Add04;
                    txtAdd05.Text = mysetting.Add05;
                    txtAdd06.Text = mysetting.Add06;
                    txtAdd07.Text = mysetting.Add07;
                    txtAdd08.Text = mysetting.Add08;
                    txtAdd09.Text = mysetting.Add09;
                    txtAdd10.Text = mysetting.Add10;
                    txtAdd11.Text = mysetting.Add11;
                    txtAdd12.Text = mysetting.Add12;
                    txtAdd13.Text = mysetting.Add13;
                    txtAdd14.Text = mysetting.Add14;
                    txtAdd15.Text = mysetting.Add15;


                    txtAdd201.Text = mysetting.Add201;
                    txtAdd202.Text = mysetting.Add202;
                    txtAdd203.Text = mysetting.Add203;
                    txtAdd204.Text = mysetting.Add204;
                    txtAdd205.Text = mysetting.Add205;
                    txtAdd206.Text = mysetting.Add206;
                    txtAdd207.Text = mysetting.Add207;
                    txtAdd208.Text = mysetting.Add208;
                    txtAdd209.Text = mysetting.Add209;
                    txtAdd210.Text = mysetting.Add210;
                    txtAdd211.Text = mysetting.Add211;
                    txtAdd212.Text = mysetting.Add212;
                    txtAdd213.Text = mysetting.Add213;
                    txtAdd214.Text = mysetting.Add214;
                    txtAdd215.Text = mysetting.Add215;

                    txtCompanyName.Text = mysetting.CompanyName;
                    txtCompanyName2.Text = mysetting.CompanyName2;
                    txtDed01.Text = mysetting.Ded01;
                    txtDed02.Text = mysetting.Ded02;
                    txtDed03.Text = mysetting.Ded03;
                    txtDed04.Text = mysetting.Ded04;
                    txtDed05.Text = mysetting.Ded05;
                    txtDed06.Text = mysetting.Ded06;
                    txtDed07.Text = mysetting.Ded07;
                    txtDed08.Text = mysetting.Ded08;
                    txtDed09.Text = mysetting.Ded09;
                    txtDed10.Text = mysetting.Ded10;
                    txtDed11.Text = mysetting.Ded11;
                    txtDed12.Text = mysetting.Ded12;
                    txtDed13.Text = mysetting.Ded13;
                    txtDed14.Text = mysetting.Ded14;
                    txtDed15.Text = mysetting.Ded15;

                    txtDed201.Text = mysetting.Ded201;
                    txtDed202.Text = mysetting.Ded202;
                    txtDed203.Text = mysetting.Ded203;
                    txtDed204.Text = mysetting.Ded204;
                    txtDed205.Text = mysetting.Ded205;
                    txtDed206.Text = mysetting.Ded206;
                    txtDed207.Text = mysetting.Ded207;
                    txtDed208.Text = mysetting.Ded208;
                    txtDed209.Text = mysetting.Ded209;
                    txtDed210.Text = mysetting.Ded210;
                    txtDed211.Text = mysetting.Ded211;
                    txtDed212.Text = mysetting.Ded212;
                    txtDed213.Text = mysetting.Ded213;
                    txtDed214.Text = mysetting.Ded214;
                    txtDed215.Text = mysetting.Ded215;

                    ddlAdd01.SelectedValue = mysetting.AddAcc01;
                    ddlAdd02.SelectedValue = mysetting.AddAcc02;
                    ddlAdd03.SelectedValue = mysetting.AddAcc03;
                    ddlAdd04.SelectedValue = mysetting.AddAcc04;
                    ddlAdd05.SelectedValue = mysetting.AddAcc05;
                    ddlAdd06.SelectedValue = mysetting.AddAcc06;
                    ddlAdd07.SelectedValue = mysetting.AddAcc07;
                    ddlAdd08.SelectedValue = mysetting.AddAcc08;
                    ddlAdd09.SelectedValue = mysetting.AddAcc09;
                    ddlAdd10.SelectedValue = mysetting.AddAcc10;
                    ddlAdd11.SelectedValue = mysetting.AddAcc11;
                    ddlAdd12.SelectedValue = mysetting.AddAcc12;
                    ddlAdd13.SelectedValue = mysetting.AddAcc13;
                    ddlAdd14.SelectedValue = mysetting.AddAcc14;
                    ddlAdd15.SelectedValue = mysetting.AddAcc15;

                    ddlDed01.SelectedValue = mysetting.DedAcc01;
                    ddlDed02.SelectedValue = mysetting.DedAcc02;
                    ddlDed03.SelectedValue = mysetting.DedAcc03;
                    ddlDed04.SelectedValue = mysetting.DedAcc04;
                    ddlDed05.SelectedValue = mysetting.DedAcc05;
                    ddlDed06.SelectedValue = mysetting.DedAcc06;
                    ddlDed07.SelectedValue = mysetting.DedAcc07;
                    ddlDed08.SelectedValue = mysetting.DedAcc08;
                    ddlDed09.SelectedValue = mysetting.DedAcc09;
                    ddlDed10.SelectedValue = mysetting.DedAcc10;
                    ddlDed11.SelectedValue = mysetting.DedAcc11;
                    ddlDed12.SelectedValue = mysetting.DedAcc12;
                    ddlDed13.SelectedValue = mysetting.DedAcc13;
                    ddlDed14.SelectedValue = mysetting.DedAcc14;
                    ddlDed15.SelectedValue = mysetting.DedAcc15;

                    txtPaper1.Text = mysetting.Paper1;
                    txtPaper2.Text = mysetting.Paper2;
                    txtPaper3.Text = mysetting.Paper3;
                    txtPaper4.Text = mysetting.Paper4;
                    txtPaper5.Text = mysetting.Paper5;
                    txtPaper6.Text = mysetting.Paper6;
                    txtPaper7.Text = mysetting.Paper7;
                    txtPaper8.Text = mysetting.Paper8;
                    txtPaper9.Text = mysetting.Paper9;
                    txtPaper10.Text = mysetting.Paper10;
                    ddlBasic.SelectedValue = mysetting.BasicAcc;
                    txtPaperE1.Text = mysetting.PaperE1;
                    txtPaperE2.Text = mysetting.PaperE2;
                    txtPaperE3.Text = mysetting.PaperE3;
                    txtPaperE4.Text = mysetting.PaperE4;
                    txtPaperE5.Text = mysetting.PaperE5;
                    txtPaperE6.Text = mysetting.PaperE6;
                    txtPaperE7.Text = mysetting.PaperE7;
                    txtPaperE8.Text = mysetting.PaperE8;
                    txtPaperE9.Text = mysetting.PaperE9;
                    txtPaperE10.Text = mysetting.PaperE10;
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "لا يوجد أعدادات للنظام";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(1,'" + LblCodesResult.Text + "');", true);
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }             
        }

        public void putShift(Shift myShift)
        {
            ShiftTip = "";
            ddlShift.ToolTip = "";
            myShift.ShiftNo = int.Parse(ddlShift.SelectedValue);
            myShift.FTime = txtFTime.Text;
            myShift.ETime = txtETime.Text;
            myShift.SFTime = txtSFTime.Text;
            myShift.SETime = txtSETime.Text;
            myShift.RFTime = txtRFTime.Text;
            myShift.RETime = txtRETime.Text;
            myShift.DLate = moh.StrToInt(txtDLate.Text);
            myShift.MDLateNo = moh.StrToInt(txtMDLateNo.Text);
            myShift.MDLate = moh.StrToInt(txtMDLate.Text);
            myShift.YDLate = moh.StrToInt(txtYDLate.Text);
            myShift.YDLateNo = moh.StrToInt(txtYDLateNo.Text);
            myShift.DEarly = moh.StrToInt(txtDEarly.Text);
            myShift.MDEarly = moh.StrToInt(txtMDEarly.Text);
            myShift.MDEarlyNo = moh.StrToInt(txtMDEarlyNo.Text);
            myShift.YDEarlyNo = moh.StrToInt(txtYDEarlyNo.Text);
            myShift.YDEarly = moh.StrToInt(txtYDEarly.Text);
            myShift.MForget = moh.StrToInt(txtMForget.Text);
            myShift.YForget = moh.StrToInt(txtYForget.Text);
            myShift.Forget = moh.StrToInt(txtForget.Text);
            myShift.NoTime = moh.StrToDouble(txtNoTime.Text);
            myShift.ThSat = ChkThSat.Checked;
        }

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Shift myShift = new Shift();
                myShift.ShiftNo = int.Parse(ddlShift.SelectedValue);
                myShift = myShift.find(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString);
                if (myShift != null)
                {
                    putShift(myShift);
                    myShift.update(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString);
                }
                else
                {
                    myShift = new Shift();
                    putShift(myShift);
                    myShift.Add(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString);
                }

                MyConfig mysetting = new MyConfig();
                mysetting.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mysetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                mysetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                if (mysetting != null)
                {
                    mysetting.Add01 = txtAdd01.Text;
                    mysetting.Add02 = txtAdd02.Text;
                    mysetting.Add03 = txtAdd03.Text;
                    mysetting.Add04 = txtAdd04.Text;
                    mysetting.Add05 = txtAdd05.Text;
                    mysetting.Add06 = txtAdd06.Text;
                    mysetting.Add07 = txtAdd07.Text;
                    mysetting.Add08 = txtAdd08.Text;
                    mysetting.Add09 = txtAdd09.Text;
                    mysetting.Add10 = txtAdd10.Text;
                    mysetting.Add11 = txtAdd11.Text;
                    mysetting.Add12 = txtAdd12.Text;
                    mysetting.Add13 = txtAdd13.Text;
                    mysetting.Add14 = txtAdd14.Text;
                    mysetting.Add15 = txtAdd15.Text;

                    mysetting.Add201 = txtAdd201.Text;
                    mysetting.Add202 = txtAdd202.Text;
                    mysetting.Add203 = txtAdd203.Text;
                    mysetting.Add204 = txtAdd204.Text;
                    mysetting.Add205 = txtAdd205.Text;
                    mysetting.Add206 = txtAdd206.Text;
                    mysetting.Add207 = txtAdd207.Text;
                    mysetting.Add208 = txtAdd208.Text;
                    mysetting.Add209 = txtAdd209.Text;
                    mysetting.Add210 = txtAdd210.Text;
                    mysetting.Add211 = txtAdd211.Text;
                    mysetting.Add212 = txtAdd212.Text;
                    mysetting.Add213 = txtAdd213.Text;
                    mysetting.Add214 = txtAdd214.Text;
                    mysetting.Add215 = txtAdd215.Text;

                    mysetting.CompanyName = txtCompanyName.Text;
                    mysetting.CompanyName2 = txtCompanyName2.Text;
                    mysetting.Ded01 = txtDed01.Text;
                    mysetting.Ded02 = txtDed02.Text;
                    mysetting.Ded03 = txtDed03.Text;
                    mysetting.Ded04 = txtDed04.Text;
                    mysetting.Ded05 = txtDed05.Text;
                    mysetting.Ded06 = txtDed06.Text;
                    mysetting.Ded07 = txtDed07.Text;
                    mysetting.Ded08 = txtDed08.Text;
                    mysetting.Ded09 = txtDed09.Text;
                    mysetting.Ded10 = txtDed10.Text;
                    mysetting.Ded11 = txtDed11.Text;
                    mysetting.Ded12 = txtDed12.Text;
                    mysetting.Ded13 = txtDed13.Text;
                    mysetting.Ded14 = txtDed14.Text;
                    mysetting.Ded15 = txtDed15.Text;

                    mysetting.Ded201 = txtDed201.Text;
                    mysetting.Ded202 = txtDed202.Text;
                    mysetting.Ded203 = txtDed203.Text;
                    mysetting.Ded204 = txtDed204.Text;
                    mysetting.Ded205 = txtDed205.Text;
                    mysetting.Ded206 = txtDed206.Text;
                    mysetting.Ded207 = txtDed207.Text;
                    mysetting.Ded208 = txtDed208.Text;
                    mysetting.Ded209 = txtDed209.Text;
                    mysetting.Ded210 = txtDed210.Text;
                    mysetting.Ded211 = txtDed211.Text;
                    mysetting.Ded212 = txtDed212.Text;
                    mysetting.Ded213 = txtDed213.Text;
                    mysetting.Ded214 = txtDed214.Text;
                    mysetting.Ded215 = txtDed215.Text;

                    mysetting.AddAcc01 = ddlAdd01.SelectedValue;
                    mysetting.AddAcc02 = ddlAdd02.SelectedValue;
                    mysetting.AddAcc03 = ddlAdd03.SelectedValue;
                    mysetting.AddAcc04 = ddlAdd04.SelectedValue;
                    mysetting.AddAcc05 = ddlAdd05.SelectedValue;
                    mysetting.AddAcc06 = ddlAdd06.SelectedValue;
                    mysetting.AddAcc07 = ddlAdd07.SelectedValue;
                    mysetting.AddAcc08 = ddlAdd08.SelectedValue;
                    mysetting.AddAcc09 = ddlAdd09.SelectedValue;
                    mysetting.AddAcc10 = ddlAdd10.SelectedValue;
                    mysetting.AddAcc11 = ddlAdd11.SelectedValue;
                    mysetting.AddAcc12 = ddlAdd12.SelectedValue;
                    mysetting.AddAcc13 = ddlAdd13.SelectedValue;
                    mysetting.AddAcc14 = ddlAdd14.SelectedValue;
                    mysetting.AddAcc15 = ddlAdd15.SelectedValue;

                    mysetting.DedAcc01 = ddlDed01.SelectedValue;
                    mysetting.DedAcc02 = ddlDed02.SelectedValue;
                    mysetting.DedAcc03 = ddlDed03.SelectedValue;
                    mysetting.DedAcc04 = ddlDed04.SelectedValue;
                    mysetting.DedAcc05 = ddlDed05.SelectedValue;
                    mysetting.DedAcc06 = ddlDed06.SelectedValue;
                    mysetting.DedAcc07 = ddlDed07.SelectedValue;
                    mysetting.DedAcc08 = ddlDed08.SelectedValue;
                    mysetting.DedAcc09 = ddlDed09.SelectedValue;
                    mysetting.DedAcc10 = ddlDed10.SelectedValue;
                    mysetting.DedAcc11 = ddlDed11.SelectedValue;
                    mysetting.DedAcc12 = ddlDed12.SelectedValue;
                    mysetting.DedAcc13 = ddlDed13.SelectedValue;
                    mysetting.DedAcc14 = ddlDed14.SelectedValue;
                    mysetting.DedAcc15 = ddlDed15.SelectedValue;
                    mysetting.BasicAcc = ddlBasic.SelectedValue;

                    mysetting.Paper1 = txtPaper1.Text;
                    mysetting.Paper2 = txtPaper2.Text;
                    mysetting.Paper3 = txtPaper3.Text;
                    mysetting.Paper4 = txtPaper4.Text;
                    mysetting.Paper5 = txtPaper5.Text;
                    mysetting.Paper6 = txtPaper6.Text;
                    mysetting.Paper7 = txtPaper7.Text;
                    mysetting.Paper8 = txtPaper8.Text;
                    mysetting.Paper9 = txtPaper9.Text;
                    mysetting.Paper10 = txtPaper10.Text;
                    mysetting.PaperE1 = txtPaperE1.Text;
                    mysetting.PaperE2 = txtPaperE2.Text;
                    mysetting.PaperE3 = txtPaperE3.Text;
                    mysetting.PaperE4 = txtPaperE4.Text;
                    mysetting.PaperE5 = txtPaperE5.Text;
                    mysetting.PaperE6 = txtPaperE6.Text;
                    mysetting.PaperE7 = txtPaperE7.Text;
                    mysetting.PaperE8 = txtPaperE8.Text;
                    mysetting.PaperE9 = txtPaperE9.Text;
                    mysetting.PaperE10 = txtPaperE10.Text;
                    if (mysetting.update(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString))
                    {
                        if (Cache["MyConfig" + Session["CNN2"].ToString()] != null) Cache.Remove("MyConfig" + Session["CNN2"].ToString());
                        mysetting = new MyConfig();
                        mysetting.Branch = 1;
                        Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mysetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormAction = "تعديل";
                        UserTran.FormName = "اعدادات النظام";
                        UserTran.Description = "تعديل اعدادات النظام للشئون الادارية";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);


                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";                       
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(1,'" + LblCodesResult.Text + "');", true);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ اثناء تعديل البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>');", true);                    
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "لقد حدث خطأ اثناء تعديل البيانات ... حاول مرة أخرى";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>');", true);
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        public bool CheckShift(Shift myShift)
        {
            bool vChange = false;
            if (txtFTime.Text != myShift.FTime)
            {
                vChange = true;
                return vChange;
            }
            if (txtETime.Text != myShift.ETime)
            {
                vChange = true;
                return vChange;
            }
            if (txtSFTime.Text != myShift.SFTime)
            {
                vChange = true;
                return vChange;
            }
            if (txtSETime.Text != myShift.SETime)
            {
                vChange = true;
                return vChange;
            }
            if (txtRFTime.Text != myShift.RFTime)
            {
                vChange = true;
                return vChange;
            }
            if (txtRETime.Text != myShift.RETime)
            {
                vChange = true;
                return vChange;
            }
            if (txtDLate.Text != myShift.DLate.ToString())
            {
                vChange = true;
                return vChange;
            }
            if (txtMDLateNo.Text != myShift.MDLateNo.ToString())
            {
                vChange = true;
                return vChange;
            }
            if (txtMDLate.Text != myShift.MDLate.ToString())
            {
                vChange = true;
                return vChange;
            }
            if (txtYDLate.Text != myShift.YDLate.ToString())
            {
                vChange = true;
                return vChange;
            }
            if (txtYDLateNo.Text != myShift.YDLateNo.ToString())
            {
                vChange = true;
                return vChange;
            }
            if (txtDEarly.Text != myShift.DEarly.ToString())
            {
                vChange = true;
                return vChange;
            }
            if (txtMDEarly.Text != myShift.MDEarly.ToString())
            {
                vChange = true;
                return vChange;
            }
            if (txtMDEarlyNo.Text != myShift.MDEarlyNo.ToString())
            {
                vChange = true;
                return vChange;
            }
            if (txtYDEarlyNo.Text != myShift.YDEarlyNo.ToString())
            {
                vChange = true;
                return vChange;
            }
            if (txtYDEarly.Text != myShift.YDEarly.ToString())
            {
                vChange = true;
                return vChange;
            }
            if (txtMForget.Text != myShift.MForget.ToString())
            {
                vChange = true;
                return vChange;
            }
            if (txtYForget.Text != myShift.YForget.ToString())
            {
                vChange = true;
                return vChange;
            }
            if (txtForget.Text != myShift.Forget.ToString())
            {
                vChange = true;
                return vChange;
            }
            if (txtNoTime.Text != myShift.NoTime.ToString())
            {
                vChange = true;
                return vChange;
            }
            if (ChkThSat.Checked != (bool)myShift.ThSat)
            {
                vChange = true;
                return vChange;
            }
            return vChange;
        }

        protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            Shift myShift = new Shift();
            //if (ddlShift.ToolTip != "" && ddlShift.ToolTip != ddlShift.SelectedValue)
            //{
            //    myShift.ShiftNo = int.Parse(ddlShift.SelectedValue);
            //    myShift = myShift.find(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString);
            //    if (myShift != null)
            //    {
            //        if(CheckShift(myShift))
            //        {                       
            //            LblCodesResult.ForeColor = System.Drawing.Color.Red;
            //            LblCodesResult.Text = "تم تعديل بيانات توقيت الحضور و الانصراف يجب أختيار تعديل قبل الانتقال لتوقيت آخر";
            //            ddlShift.SelectedValue = ddlShift.ToolTip;                       
            //            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>');", true);
            //            return;
            //        }
            //    }
            //}

            ddlShift.ToolTip = ddlShift.SelectedValue;
            ShiftTip = ddlShift.SelectedValue;

            myShift = new Shift();
            myShift.ShiftNo = int.Parse(ddlShift.SelectedValue);
            myShift = myShift.find(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString);
            if (myShift != null)
            {
                txtFTime.Text = myShift.FTime;
                txtETime.Text = myShift.ETime;
                txtSFTime.Text = myShift.SFTime;
                txtSETime.Text = myShift.SETime;
                txtRFTime.Text = myShift.RFTime;
                txtRETime.Text = myShift.RETime;
                txtDLate.Text = myShift.DLate.ToString();
                txtMDLateNo.Text = myShift.MDLateNo.ToString();
                txtMDLate.Text = myShift.MDLate.ToString();
                txtYDLate.Text = myShift.YDLate.ToString();
                txtYDLateNo.Text = myShift.YDLateNo.ToString();
                txtDEarly.Text = myShift.DEarly.ToString();
                txtMDEarly.Text = myShift.MDEarly.ToString();
                txtMDEarlyNo.Text = myShift.MDEarlyNo.ToString();
                txtYDEarlyNo.Text = myShift.YDEarlyNo.ToString();
                txtYDEarly.Text = myShift.YDEarly.ToString();
                txtMForget.Text = myShift.MForget.ToString();
                txtYForget.Text = myShift.YForget.ToString();
                txtForget.Text = myShift.Forget.ToString();
                txtNoTime.Text = myShift.NoTime.ToString();
                ChkThSat.Checked = (bool)myShift.ThSat;
            }
            else
            {
                txtFTime.Text = "";
                txtETime.Text = "";
                txtSFTime.Text = "";
                txtSETime.Text = "";
                txtRFTime.Text = "";
                txtRETime.Text = "";
                txtDLate.Text = "0";
                txtMDLateNo.Text = "0";
                txtMDLate.Text = "0";
                txtYDLate.Text = "0";
                txtYDLateNo.Text = "0";
                txtDEarly.Text = "0";
                txtMDEarly.Text = "0";
                txtMDEarlyNo.Text = "0";
                txtYDEarlyNo.Text = "0";
                txtYDEarly.Text = "0";
                txtMForget.Text = "0";
                txtYForget.Text = "0";
                txtForget.Text = "0";
                txtNoTime.Text = "0";
                ChkThSat.Checked = false;
            }
        }
      
    }
}