using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using iTextSharp.text.pdf;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Configuration;


namespace ACC
{
    public partial class WebSal : System.Web.UI.Page
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
                BtnPrint.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnPrint);

                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "بيانات الرواتب";

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

                    //BtnNew.Visible = (bool)((TblRoles)(Session["Roll"])).Pass111;
                    //BtnEdit.Visible = (bool)((TblRoles)(Session["Roll"])).Pass112;
                    //BtnDelete.Visible = (bool)((TblRoles)(Session["Roll"])).Pass113;
                    //BtnSearch.Visible = (bool)((TblRoles)(Session["Roll"])).Pass114;
                    //BtnPrint.Visible = (bool)((TblRoles)(Session["Roll"])).Pass115;

                    BtnNew.Visible = false;
                    BtnPrint.Visible = false;

                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = "الرئيسية";
                        UserTran.FormAction = "اختيار";
                        UserTran.Description = "تم اختيار صفحة بيانات الرواتب للموظفين";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    MyConfig mysetting = new MyConfig();
                    mysetting.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mysetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    mysetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                    if (mysetting != null)
                    {
                        lblAdd01.Text = mysetting.Add01;                        
                        lblAdd02.Text = mysetting.Add02;
                        lblAdd03.Text = mysetting.Add03;
                        lblAdd04.Text = mysetting.Add04;
                        lblAdd05.Text = mysetting.Add05;
                        lblAdd06.Text = mysetting.Add06;
                        lblAdd07.Text = mysetting.Add07;
                        lblAdd08.Text = mysetting.Add08;
                        lblAdd09.Text = mysetting.Add09;
                        lblAdd10.Text = mysetting.Add10;
                        lblAdd11.Text = mysetting.Add11;
                        lblAdd12.Text = mysetting.Add12;
                        lblAdd13.Text = mysetting.Add13;
                        lblAdd14.Text = mysetting.Add14;
                        lblAdd15.Text = mysetting.Add15;

                        lblDed01.Text = mysetting.Ded01;
                        lblDed02.Text = mysetting.Ded02;
                        lblDed03.Text = mysetting.Ded03;
                        lblDed04.Text = mysetting.Ded04;
                        lblDed05.Text = mysetting.Ded05;
                        lblDed06.Text = mysetting.Ded06;
                        lblDed07.Text = mysetting.Ded07;
                        lblDed08.Text = mysetting.Ded08;
                        lblDed09.Text = mysetting.Ded09;
                        lblDed10.Text = mysetting.Ded10;
                        lblDed11.Text = mysetting.Ded11;
                        lblDed12.Text = mysetting.Ded12;
                        lblDed13.Text = mysetting.Ded13;
                        lblDed14.Text = mysetting.Ded14;
                        lblDed15.Text = mysetting.Ded15;

                        txtAdd01.Visible = txtAdd01.Visible && (lblAdd01.Text != "");
                        lblAdd01.Visible = lblAdd01.Visible && (lblAdd01.Text != "");
                        txtAdd02.Visible = txtAdd02.Visible && (lblAdd02.Text != "");
                        lblAdd02.Visible = lblAdd02.Visible && (lblAdd02.Text != "");
                        txtAdd03.Visible = txtAdd03.Visible && (lblAdd03.Text != "");
                        lblAdd03.Visible = lblAdd03.Visible && (lblAdd03.Text != "");
                        txtAdd04.Visible = txtAdd04.Visible && (lblAdd04.Text != "");
                        txtAdd041.Visible = txtAdd041.Visible && txtAdd04.Visible;
                        txtAdd042.Visible = txtAdd042.Visible && txtAdd04.Visible;
                        lblAdd04.Visible = lblAdd04.Visible && (lblAdd04.Text != "");
                        txtAdd05.Visible = txtAdd05.Visible && (lblAdd05.Text != "");
                        lblAdd05.Visible = lblAdd05.Visible && (lblAdd05.Text != "");
                        txtAdd06.Visible = txtAdd06.Visible && (lblAdd06.Text != "");
                        lblAdd06.Visible = lblAdd06.Visible && (lblAdd06.Text != "");
                        txtAdd07.Visible = txtAdd07.Visible && (lblAdd07.Text != "");
                        lblAdd07.Visible = lblAdd07.Visible && (lblAdd07.Text != "");
                        txtAdd08.Visible = txtAdd08.Visible && (lblAdd08.Text != "");
                        lblAdd08.Visible = lblAdd08.Visible && (lblAdd08.Text != "");
                        txtAdd09.Visible = txtAdd09.Visible && (lblAdd09.Text != "");
                        lblAdd09.Visible = lblAdd09.Visible && (lblAdd09.Text != "");
                        txtAdd10.Visible = txtAdd10.Visible && (lblAdd10.Text != "");
                        lblAdd10.Visible = lblAdd10.Visible && (lblAdd10.Text != "");
                        txtAdd11.Visible = txtAdd11.Visible && (lblAdd11.Text != "");
                        lblAdd11.Visible = lblAdd11.Visible && (lblAdd11.Text != "");
                        txtAdd12.Visible = txtAdd12.Visible && (lblAdd12.Text != "");
                        lblAdd12.Visible = lblAdd12.Visible && (lblAdd12.Text != "");
                        txtAdd13.Visible = txtAdd13.Visible && (lblAdd13.Text != "");
                        lblAdd13.Visible = lblAdd13.Visible && (lblAdd13.Text != "");
                        txtAdd14.Visible = txtAdd14.Visible && (lblAdd14.Text != "");
                        lblAdd14.Visible = lblAdd14.Visible && (lblAdd14.Text != "");
                        txtAdd15.Visible = txtAdd15.Visible && (lblAdd15.Text != "");
                        lblAdd15.Visible = lblAdd15.Visible && (lblAdd15.Text != "");

                        txtDed01.Visible = txtDed01.Visible && (lblDed01.Text != "");
                        lblDed01.Visible = lblDed01.Visible && (lblDed01.Text != "");
                        txtDed02.Visible = txtDed02.Visible && (lblDed02.Text != "");
                        txtDed021.Visible = txtDed021.Visible && txtDed02.Visible;
                        txtDed022.Visible = txtDed022.Visible && txtDed02.Visible;
                        lblDed02.Visible = lblDed02.Visible && (lblDed02.Text != "");
                        txtDed03.Visible = txtDed03.Visible && (lblDed03.Text != "");
                        lblDed03.Visible = lblDed03.Visible && (lblDed03.Text != "");
                        txtDed04.Visible = txtDed04.Visible && (lblDed04.Text != "");
                        lblDed04.Visible = lblDed04.Visible && (lblDed04.Text != "");
                        txtDed05.Visible = txtDed05.Visible && (lblDed05.Text != "");
                        lblDed05.Visible = lblDed05.Visible && (lblDed05.Text != "");
                        txtDed06.Visible = txtDed06.Visible && (lblDed06.Text != "");
                        lblDed06.Visible = lblDed06.Visible && (lblDed06.Text != "");
                        txtDed07.Visible = txtDed07.Visible && (lblDed07.Text != "");
                        lblDed07.Visible = lblDed07.Visible && (lblDed07.Text != "");
                        txtDed08.Visible = txtDed08.Visible && (lblDed08.Text != "");
                        lblDed08.Visible = lblDed08.Visible && (lblDed08.Text != "");
                        txtDed09.Visible = txtDed09.Visible && (lblDed09.Text != "");
                        lblDed09.Visible = lblDed09.Visible && (lblDed09.Text != "");
                        txtDed10.Visible = txtDed10.Visible && (lblDed10.Text != "");
                        lblDed10.Visible = lblDed10.Visible && (lblDed10.Text != "");
                        txtDed11.Visible = txtDed11.Visible && (lblDed11.Text != "");
                        lblDed11.Visible = lblDed11.Visible && (lblDed11.Text != "");
                        txtDed12.Visible = txtDed12.Visible && (lblDed12.Text != "");
                        lblDed12.Visible = lblDed12.Visible && (lblDed12.Text != "");
                        txtDed13.Visible = txtDed13.Visible && (lblDed13.Text != "");
                        lblDed13.Visible = lblDed13.Visible && (lblDed13.Text != "");
                        txtDed14.Visible = txtDed14.Visible && (lblDed14.Text != "");
                        txtDed014.Visible = txtDed14.Visible && (lblDed14.Text != "");
                        lblDed14.Visible = lblDed14.Visible && (lblDed14.Text != "");
                        txtDed15.Visible = txtDed15.Visible && (lblDed15.Text != "");
                        lblDed15.Visible = lblDed15.Visible && (lblDed15.Text != "");

                        txtsAdd01.Visible = txtAdd01.Visible;
                        txtsAdd02.Visible = txtAdd02.Visible;
                        txtsAdd03.Visible = txtAdd03.Visible;
                        txtsAdd04.Visible = txtAdd04.Visible;
                        txtsAdd05.Visible = txtAdd05.Visible;
                        txtsAdd06.Visible = txtAdd06.Visible;
                        txtsAdd07.Visible = txtAdd07.Visible;
                        txtsAdd08.Visible = txtAdd08.Visible;
                        txtsAdd09.Visible = txtAdd09.Visible;
                        txtsAdd10.Visible = txtAdd10.Visible;
                        txtsAdd11.Visible = txtAdd11.Visible;
                        txtsAdd12.Visible = txtAdd12.Visible;
                        txtsAdd13.Visible = txtAdd13.Visible;
                        txtsAdd14.Visible = txtAdd14.Visible;
                        txtsAdd15.Visible = txtAdd15.Visible;
                        txtsDed01.Visible = txtDed01.Visible;
                        txtsDed02.Visible = txtDed02.Visible;
                        txtsDed03.Visible = txtDed03.Visible;
                        txtsDed04.Visible = txtDed04.Visible;
                        txtsDed05.Visible = txtDed05.Visible;
                        txtsDed06.Visible = txtDed06.Visible;
                        txtsDed07.Visible = txtDed07.Visible;
                        txtsDed08.Visible = txtDed08.Visible;
                        txtsDed09.Visible = txtDed09.Visible;
                        txtsDed10.Visible = txtDed10.Visible;
                        txtsDed11.Visible = txtDed11.Visible;
                        txtsDed12.Visible = txtDed12.Visible;
                        txtsDed13.Visible = txtDed13.Visible;
                        txtsDed14.Visible = txtDed14.Visible;
                        txtsDed15.Visible = txtDed15.Visible;
                    }

                    Salaries myPro = new Salaries();
                    ddlMonth.DataSource = myPro.GetMonth(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlMonth.DataBind();

                    ddlMonth.Items.Insert(0, new ListItem("أختر الشهر", "-1", true));

                    ddlSection.DataTextField = "Name1";
                    ddlSection.DataValueField = "Code";

                    Codes myCode = new Codes();
                    myCode.Branch = short.Parse(Session["Branch"].ToString());
                    myCode.Ftype = 3;
                    if (Cache["LastCodes" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCodes" + Session["CNN2"].ToString(), myCode.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlSection.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                             where itm.Ftype == 3
                                             select itm).ToList();
                    ddlSection.DataBind();
                    ddlSection.Items.Insert(0, new ListItem("-----  أختر القسم  -----", "-1", true));

                    ddlEmpCode.DataTextField = "EmpCode";
                    ddlEmpCode.DataValueField = "Name";

                    SEmp myemp = new SEmp();
                    if (Cache["Emps" + Session["CNN2"].ToString()] == null) Cache.Insert("Emps" + Session["CNN2"].ToString(), myemp.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlEmpCode.DataSource = (List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()]);
                    ddlEmpCode.DataBind();

                    ddlEmpCode.Items.Insert(0, new ListItem("أختر كود الموظف", "-1", true));

                    BtnClear_Click(sender, null);


                    if (Request.QueryString["FNum"] != null)
                    {
                        ddlMonth.SelectedValue = Request.QueryString["Year"].ToString() + "/" + moh.MakeMask(Request.QueryString["Month"].ToString(),2);

                        foreach (ListItem itm in ddlEmpCode.Items)
                        {
                            if (itm.Text == Request.QueryString["FNum"].ToString())
                            {
                                itm.Selected = true;
                            }
                            else itm.Selected = false;
                        }
                        ddlEmpCode_SelectedIndexChanged(sender, e);
                    }

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

        public void ClearSal()
        {
            BtnEdit.Visible = true;
            BtnDelete.Visible = true;
            txtAdd01.Text = "";
            txtAdd02.Text = "";
            txtAdd03.Text = "";
            txtAdd04.Text = "";
            txtAdd05.Text = "";
            txtAdd06.Text = "";
            txtAdd07.Text = "";
            txtAdd08.Text = "";
            txtAdd09.Text = "";
            txtAdd10.Text = "";
            txtAdd11.Text = "";
            txtAdd12.Text = "";
            txtAdd13.Text = "";
            txtAdd14.Text = "";
            txtAdd15.Text = "";
            txtBasic.Text = "";
            txtDed01.Text = "";
            txtDed02.Text = "";
            txtDed03.Text = "";
            txtDed04.Text = "";
            txtDed05.Text = "";
            txtDed06.Text = "";
            txtDed07.Text = "";
            txtDed08.Text = "";
            txtDed09.Text = "";
            txtDed10.Text = "";
            txtDed11.Text = "";
            txtDed12.Text = "";
            txtDed13.Text = "";
            txtDed14.Text = "";
            txtDed014.Text = "";
            txtDed15.Text = "";

            txtsAdd01.Text = "";
            txtsAdd02.Text = "";
            txtsAdd03.Text = "";
            txtsAdd04.Text = "";
            txtsAdd05.Text = "";
            txtsAdd06.Text = "";
            txtsAdd07.Text = "";
            txtsAdd08.Text = "";
            txtsAdd09.Text = "";
            txtsAdd10.Text = "";
            txtsAdd11.Text = "";
            txtsAdd12.Text = "";
            txtsAdd13.Text = "";
            txtsAdd14.Text = "";
            txtsAdd15.Text = "";
            txtsBasic.Text = "";
            txtsDed01.Text = "";
            txtsDed02.Text = "";
            txtsDed03.Text = "";
            txtsDed04.Text = "";
            txtsDed05.Text = "";
            txtsDed06.Text = "";
            txtsDed07.Text = "";
            txtsDed08.Text = "";
            txtsDed09.Text = "";
            txtsDed10.Text = "";
            txtsDed11.Text = "";
            txtsDed12.Text = "";
            txtsDed13.Text = "";
            txtsDed14.Text = "";
            txtsDed15.Text = "";
            txtTAdd.Text = "";
            txtTDed.Text = "";
            txtNet.Text = "";
            txtRemark.Text = "";
            txtAdd041.Text = "";
            txtAdd042.Text = "";
            txtDed021.Text = "";
            txtDed022.Text = "";
            ddlNoDays.SelectedValue = "30";
            ddlSection.SelectedIndex = 0;
            lblDays.Text = "ايام العمل الفعلية";
        }


        public void EnabelSal(bool Enable)
        {
            txtAdd01.ReadOnly = !Enable;
            txtAdd02.ReadOnly = !Enable;
            txtAdd03.ReadOnly = !Enable;
            //txtAdd04.ReadOnly = !Enable;
            txtAdd05.ReadOnly = !Enable;
            txtAdd06.ReadOnly = !Enable;
            txtAdd07.ReadOnly = !Enable;
            txtAdd08.ReadOnly = !Enable;
            txtAdd09.ReadOnly = !Enable;
            txtAdd10.ReadOnly = !Enable;
            txtAdd11.ReadOnly = !Enable;
            txtAdd12.ReadOnly = !Enable;
            txtAdd13.ReadOnly = !Enable;
            txtAdd14.ReadOnly = !Enable;
            txtAdd15.ReadOnly = !Enable;
            txtBasic.ReadOnly = !Enable;
            txtDed01.ReadOnly = !Enable;
            //txtDed02.ReadOnly = !Enable;
            txtDed03.ReadOnly = !Enable;
            txtDed04.ReadOnly = !Enable;
            txtDed05.ReadOnly = !Enable;
            txtDed06.ReadOnly = !Enable;
            txtDed07.ReadOnly = !Enable;
            txtDed08.ReadOnly = !Enable;
            txtDed09.ReadOnly = !Enable;
            txtDed10.ReadOnly = !Enable;
            txtDed11.ReadOnly = !Enable;
            txtDed12.ReadOnly = !Enable;
            txtDed13.ReadOnly = !Enable;
            txtDed14.ReadOnly = !Enable;
            txtDed014.ReadOnly = !Enable;
            txtDed15.ReadOnly = !Enable;

            txtsAdd01.ReadOnly = !Enable;
            txtsAdd02.ReadOnly = !Enable;
            txtsAdd03.ReadOnly = !Enable;
            txtsAdd04.ReadOnly = !Enable;
            txtsAdd05.ReadOnly = !Enable;
            txtsAdd06.ReadOnly = !Enable;
            txtsAdd07.ReadOnly = !Enable;
            txtsAdd08.ReadOnly = !Enable;
            txtsAdd09.ReadOnly = !Enable;
            txtsAdd10.ReadOnly = !Enable;
            txtsAdd11.ReadOnly = !Enable;
            txtsAdd12.ReadOnly = !Enable;
            txtsAdd13.ReadOnly = !Enable;
            txtsAdd14.ReadOnly = !Enable;
            txtsAdd15.ReadOnly = !Enable;
            txtsBasic.ReadOnly = !Enable;
            txtsDed01.ReadOnly = !Enable;
            txtsDed02.ReadOnly = !Enable;
            txtsDed03.ReadOnly = !Enable;
            txtsDed04.ReadOnly = !Enable;
            txtsDed05.ReadOnly = !Enable;
            txtsDed06.ReadOnly = !Enable;
            txtsDed07.ReadOnly = !Enable;
            txtsDed08.ReadOnly = !Enable;
            txtsDed09.ReadOnly = !Enable;
            txtsDed10.ReadOnly = !Enable;
            txtsDed11.ReadOnly = !Enable;
            txtsDed12.ReadOnly = !Enable;
            txtsDed13.ReadOnly = !Enable;
            txtsDed14.ReadOnly = !Enable;
            txtsDed15.ReadOnly = !Enable;
            txtAdd041.ReadOnly = !Enable;
            txtAdd042.ReadOnly = !Enable;
            txtDed021.ReadOnly = !Enable;
            txtDed022.ReadOnly = !Enable;
            ddlNoDays.Enabled = Enable;
        }



        protected void BtnClear_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ddlEmpCode.SelectedIndex = 0;
                ddlMonth.SelectedIndex = 0;
                ClearSal();
                EnabelSal(true);
                lblName.Text = "";                
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    Salaries myPay = new Salaries();
                    myPay.Year1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                    myPay.Month1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                    myPay.EmpCode = int.Parse(ddlEmpCode.SelectedItem.Text);
                    if (myPay.GetEmp(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) != null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "بيانات الموظف مدخله من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>','');", true);
                    }
                    else
                    {
                        SEmp myEmp = new SEmp();
                        myEmp.EmpCode = int.Parse(ddlEmpCode.SelectedItem.Text);
                        myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myPay.Year1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                        myPay.Month1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                        myPay.EmpCode = int.Parse(ddlEmpCode.SelectedItem.Text);
                        PutPay(myPay);
                        if (myPay.insertSalary(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(1,'" + LblCodesResult.Text + "');", true);
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ اثناء أضافة البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>');", true);

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

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
                try
                {
                    if (Page.IsValid)
                    {
                        Salaries myPay = new Salaries();
                        myPay.Year1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                        myPay.Month1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                        myPay.EmpCode = int.Parse(ddlEmpCode.SelectedItem.Text);
                        myPay = myPay.GetEmp(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myPay == null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "بيانات الموظف غير مدرجه في ملف الرواتب من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>');", true);
                        }
                        else
                        {
                            PutPay(myPay);

                            if (myPay.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(1,'" + LblCodesResult.Text + "');", true);                                  
                                BtnClear_Click(sender, e);
                            }
                            else
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ اثناء تعديل البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>');", true);
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

        protected void BtnDelete_Click(object sender, ImageClickEventArgs e)
        {
                try
                {
                    if (Page.IsValid)
                    {
                        Salaries myPay = new Salaries();
                        myPay.Year1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                        myPay.Month1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                        myPay.EmpCode = int.Parse(ddlEmpCode.SelectedItem.Text);
                        if (myPay == null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "بيانات الموظف غير مدرجه في ملف الرواتب من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>');", true);
                        }
                        else
                        {
                            if (myPay.DeleteSalary(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = txtUserName.ToolTip;
                                UserTran.Description = "الغاء بيانات الرواتب للموظف رقم " + ddlEmpCode.SelectedItem.Text + " لشهر " + ddlMonth.SelectedItem.Text;
                                UserTran.FormAction = "الغاء";
                                UserTran.FormName = "بيانات الرواتب";
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم الغاء البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(1,'" + LblCodesResult.Text + "');", true);
                                BtnClear_Click(sender, e);
                            }
                            else
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ اثناء الغاء البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>');", true);
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

        protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Checksal();
        }

        private void PutPay(Salaries myPay)
        {             
            try
            {
                txtDed021_TextChanged(txtDed02, null);
                txtAdd041_TextChanged(txtAdd04, null);
                txtBasic_TextChanged(txtBasic, null);

                myPay.Section = int.Parse(ddlSection.SelectedValue);
                if (txtBasic.Text == "") txtBasic.Text = "0";
                myPay.Basic = moh.StrToDouble(txtBasic.Text);
                if (txtAdd01.Text == "") txtAdd01.Text = "0";
                myPay.Add01 = moh.StrToDouble(txtAdd01.Text);
                if (txtAdd02.Text == "") txtAdd02.Text = "0";
                myPay.Add02 = moh.StrToDouble(txtAdd02.Text);
                if (txtAdd03.Text == "") txtAdd03.Text = "0";
                myPay.Add03 = moh.StrToDouble(txtAdd03.Text);
                if (txtAdd04.Text == "") txtAdd04.Text = "0";
                myPay.Add04 = moh.StrToDouble(txtAdd04.Text);
                if (txtAdd05.Text == "") txtAdd05.Text = "0";
                myPay.Add05 = moh.StrToDouble(txtAdd05.Text);
                if (txtAdd06.Text == "") txtAdd06.Text = "0";
                myPay.Add06 = moh.StrToDouble(txtAdd06.Text);
                if (txtAdd07.Text == "") txtAdd07.Text = "0";
                myPay.Add07 = moh.StrToDouble(txtAdd07.Text);
                if (txtAdd08.Text == "") txtAdd08.Text = "0";
                myPay.Add08 = moh.StrToDouble(txtAdd08.Text);
                if (txtAdd09.Text == "") txtAdd09.Text = "0";
                myPay.Add09 = moh.StrToDouble(txtAdd09.Text);
                if (txtAdd10.Text == "") txtAdd10.Text = "0";
                myPay.Add10 = moh.StrToDouble(txtAdd10.Text);
                if (txtAdd11.Text == "") txtAdd11.Text = "0";
                myPay.Add11 = moh.StrToDouble(txtAdd11.Text);
                if (txtAdd12.Text == "") txtAdd12.Text = "0";
                myPay.Add12 = moh.StrToDouble(txtAdd12.Text);
                if (txtAdd13.Text == "") txtAdd13.Text = "0";
                myPay.Add13 = moh.StrToDouble(txtAdd13.Text);
                if (txtAdd14.Text == "") txtAdd14.Text = "0";
                myPay.Add14 = moh.StrToDouble(txtAdd14.Text);
                if (txtAdd15.Text == "") txtAdd15.Text = "0";
                myPay.Add15 = moh.StrToDouble(txtAdd15.Text);

                if (txtDed01.Text == "") txtDed01.Text = "0";
                myPay.Ded01 = moh.StrToDouble(txtDed01.Text);
                if (txtDed02.Text == "") txtDed02.Text = "0";
                myPay.Ded02 = moh.StrToDouble(txtDed02.Text);
                if (txtDed03.Text == "") txtDed03.Text = "0";
                myPay.Ded03 = moh.StrToDouble(txtDed03.Text);
                if (txtDed04.Text == "") txtDed04.Text = "0";
                myPay.Ded04 = moh.StrToDouble(txtDed04.Text);
                if (txtDed05.Text == "") txtDed05.Text = "0";
                myPay.Ded05 = moh.StrToDouble(txtDed05.Text);
                if (txtDed06.Text == "") txtDed06.Text = "0";
                myPay.Ded06 = moh.StrToDouble(txtDed06.Text);
                if (txtDed07.Text == "") txtDed07.Text = "0";
                myPay.Ded07 = moh.StrToDouble(txtDed07.Text);
                if (txtDed08.Text == "") txtDed08.Text = "0";
                myPay.Ded08 = moh.StrToDouble(txtDed08.Text);
                if (txtDed09.Text == "") txtDed09.Text = "0";
                myPay.Ded09 = moh.StrToDouble(txtDed09.Text);
                if (txtDed10.Text == "") txtDed10.Text = "0";
                myPay.Ded10 = moh.StrToDouble(txtDed10.Text);
                if (txtDed11.Text == "") txtDed11.Text = "0";
                myPay.Ded11 = moh.StrToDouble(txtDed11.Text);
                if (txtDed12.Text == "") txtDed12.Text = "0";
                myPay.Ded12 = moh.StrToDouble(txtDed12.Text);
                if (txtDed13.Text == "") txtDed13.Text = "0";
                myPay.Ded13 = moh.StrToDouble(txtDed13.Text);
                if (txtDed14.Text == "") txtDed14.Text = "0";
                myPay.Ded14 = moh.StrToDouble(txtDed14.Text);
                if (txtDed014.Text == "") txtDed014.Text = "0";
                myPay.Ded014 = moh.StrToDouble(txtDed014.Text);
                if (txtDed15.Text == "") txtDed15.Text = "0";
                myPay.Ded15 = moh.StrToDouble(txtDed15.Text);

                if (txtDed021.Text == "") txtDed021.Text = "0";
                myPay.Ded021 = moh.StrToDouble(txtDed021.Text);
                if (txtDed022.Text == "") txtDed022.Text = "0";
                myPay.Ded022 = moh.StrToDouble(txtDed022.Text);
                if (txtAdd041.Text == "") txtAdd041.Text = "0";
                myPay.Add041 = moh.StrToDouble(txtAdd041.Text);
                if (txtAdd042.Text == "") txtAdd042.Text = "0";
                myPay.Add042 = moh.StrToDouble(txtAdd042.Text);


                myPay.sBasic = txtsBasic.Text;
                myPay.sAdd01 = txtsAdd01.Text;
                myPay.sAdd02 = txtsAdd02.Text;
                myPay.sAdd03 = txtsAdd03.Text;
                myPay.sAdd04 = txtsAdd04.Text;
                myPay.sAdd05 = txtsAdd05.Text;
                myPay.sAdd06 = txtsAdd06.Text;
                myPay.sAdd07 = txtsAdd07.Text;
                myPay.sAdd08 = txtsAdd08.Text;
                myPay.sAdd09 = txtsAdd09.Text;
                myPay.sAdd10 = txtsAdd10.Text;
                myPay.sAdd11 = txtsAdd11.Text;
                myPay.sAdd12 = txtsAdd12.Text;
                myPay.sAdd13 = txtsAdd13.Text;
                myPay.sAdd14 = txtsAdd14.Text;
                myPay.sAdd15 = txtsAdd15.Text;

                myPay.sDed01 = txtsDed01.Text;
                myPay.sDed02 = txtsDed02.Text;
                myPay.sDed03 = txtsDed03.Text;
                myPay.sDed04 = txtsDed04.Text;
                myPay.sDed05 = txtsDed05.Text;
                myPay.sDed06 = txtsDed06.Text;
                myPay.sDed07 = txtsDed07.Text;
                myPay.sDed08 = txtsDed08.Text;
                myPay.sDed09 = txtsDed09.Text;
                myPay.sDed10 = txtsDed10.Text;
                myPay.sDed11 = txtsDed11.Text;
                myPay.sDed12 = txtsDed12.Text;
                myPay.sDed13 = txtsDed13.Text;
                myPay.sDed14 = txtsDed14.Text;
                myPay.sDed15 = txtsDed15.Text;

                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                myPay.NoDays = short.Parse(ddlNoDays.SelectedValue);
                myPay.Username = txtUserName.ToolTip;
                myPay.UserDate = txtUserDate.Text;
                myPay.Remark = txtRemark.Text;
                TotSum();
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        
        protected void txtBasic_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TotSum();
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        public void TotSum()
        {
            txtTAdd.Text = string.Format("{0:N2}", (moh.StrToDouble(txtBasic.Text) + moh.StrToDouble(txtAdd01.Text) + moh.StrToDouble(txtAdd02.Text) + moh.StrToDouble(txtAdd03.Text) + moh.StrToDouble(txtAdd04.Text) + moh.StrToDouble(txtAdd05.Text) + moh.StrToDouble(txtAdd06.Text) + moh.StrToDouble(txtAdd07.Text) + moh.StrToDouble(txtAdd08.Text) + moh.StrToDouble(txtAdd09.Text) + moh.StrToDouble(txtAdd10.Text) + moh.StrToDouble(txtAdd11.Text) + moh.StrToDouble(txtAdd12.Text) + moh.StrToDouble(txtAdd13.Text) + moh.StrToDouble(txtAdd14.Text) + moh.StrToDouble(txtAdd15.Text)));
            txtTDed.Text = string.Format("{0:N2}", (moh.StrToDouble(txtDed01.Text) + moh.StrToDouble(txtDed02.Text) + moh.StrToDouble(txtDed03.Text) + moh.StrToDouble(txtDed04.Text) + moh.StrToDouble(txtDed05.Text) + moh.StrToDouble(txtDed06.Text) + moh.StrToDouble(txtDed07.Text) + moh.StrToDouble(txtDed08.Text) + moh.StrToDouble(txtDed09.Text) + moh.StrToDouble(txtDed10.Text) + moh.StrToDouble(txtDed11.Text) + moh.StrToDouble(txtDed12.Text) + moh.StrToDouble(txtDed13.Text) + moh.StrToDouble(txtDed14.Text) + moh.StrToDouble(txtDed15.Text)));
            txtNet.Text = string.Format("{0:N2}", Math.Round(moh.StrToDouble(txtTAdd.Text) - moh.StrToDouble(txtTDed.Text),2));
            if (ddlNoDays.SelectedIndex == 0) lblDays.Text = "ايام العمل الفعلية " + "0 يوم";
            else
            {
                SalOP mySal = new SalOP();
                mySal.Year1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                mySal.Month1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                mySal.EmpCode = int.Parse(ddlEmpCode.SelectedItem.Text);
                mySal = mySal.GetMonthEmpCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (mySal != null)
                {
                    //lblDays.Text = "ايام العمل الفعلية " + (ddlNoDays.SelectedIndex - mySal.Abs4 - moh.StrToInt(txtDed021.Text) - moh.StrToInt(txtDed014.Text)).ToString() + " يوم";
                    lblDays.Text = "ايام العمل الفعلية " + (ddlNoDays.SelectedIndex - moh.StrToInt(txtDed021.Text) - moh.StrToInt(txtDed014.Text)).ToString() + " يوم";
                }
                else lblDays.Text = "ايام العمل الفعلية " + (ddlNoDays.SelectedIndex - moh.StrToInt(txtDed021.Text) - moh.StrToInt(txtDed014.Text)).ToString() + " يوم";
            }
        }


        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Checksal();
        }

        protected void ddlEmpCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlEmpCode.SelectedIndex > 0)
                {
                    lblName.Text = ddlEmpCode.SelectedValue;
                    Checksal();
                }
                else
                {
                    BtnClear_Click(sender, null);
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        public void Checksal()
        {
            try
            {
                if (ddlMonth.SelectedIndex < 1)
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب أختيار الشهر";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true,false), true); 
                }
                else
                {
                    if (ddlEmpCode.SelectedIndex < 1)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أختيار كود الموظف";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true); 
                    }
                    else
                    {
                            Salaries myPay = new Salaries();
                            myPay.Year1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                            myPay.Month1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                            myPay.EmpCode = int.Parse(ddlEmpCode.SelectedItem.Text);
                            myPay = myPay.GetEmp(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myPay != null)
                            {                                
                                SetPayControl(myPay);
                                BtnEdit.Visible = (myPay.VouNo == 0);
                                BtnDelete.Visible = (myPay.VouNo == 0);

                                SEmp myEmp = new SEmp();
                                myEmp.EmpCode = int.Parse(ddlEmpCode.SelectedItem.Text);
                                myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                Agreement myAgree = new Agreement();
                                myAgree.FType = 400;
                                myAgree.LocType = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                                myAgree.LocNumber = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                                myAgree.Number = (int)myEmp.Dep;
                                myAgree.FNo = 6;
                                myAgree = myAgree.FindFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                //if (Session["CurrentUser"].ToString().ToUpper() == "ADMIN") EnabelSal(true);
                                if (myAgree != null) EnabelSal((myAgree.Agree == 2));
                                else EnabelSal(true);
                            }
                            else
                            {
                                ClearSal();
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لا يوجد للموظف بيانات في ملف الرواتب لهذا الشهر";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true,false), true); 
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


        private void SetPayControl(Salaries myPay)
        {            
            try
            {
                ddlSection.SelectedValue = myPay.Section.ToString();
                txtBasic.Text = string.Format("{0:N2}",(double)myPay.Basic);
                txtAdd01.Text = string.Format("{0:N2}",(double)myPay.Add01);
                txtAdd02.Text = string.Format("{0:N2}",(double)myPay.Add02);
                txtAdd03.Text = string.Format("{0:N2}",(double)myPay.Add03);
                txtAdd04.Text = string.Format("{0:N2}",(double)myPay.Add04);
                txtAdd05.Text = string.Format("{0:N2}",(double)myPay.Add05);
                txtAdd06.Text = string.Format("{0:N2}",(double)myPay.Add06);
                txtAdd07.Text = string.Format("{0:N2}",(double)myPay.Add07);
                txtAdd08.Text = string.Format("{0:N2}",(double)myPay.Add08);
                txtAdd09.Text = string.Format("{0:N2}",(double)myPay.Add09);
                txtAdd10.Text = string.Format("{0:N2}",(double)myPay.Add10);
                txtAdd11.Text = string.Format("{0:N2}",(double)myPay.Add11);
                txtAdd12.Text = string.Format("{0:N2}",(double)myPay.Add12);
                txtAdd13.Text = string.Format("{0:N2}",(double)myPay.Add13);
                txtAdd14.Text = string.Format("{0:N2}",(double)myPay.Add14);
                txtAdd15.Text = string.Format("{0:N2}", (double)myPay.Add15);

                txtDed01.Text = string.Format("{0:N2}",(double)myPay.Ded01);
                txtDed02.Text = string.Format("{0:N2}",(double)myPay.Ded02);
                txtDed03.Text = string.Format("{0:N2}",(double)myPay.Ded03);
                txtDed04.Text = string.Format("{0:N2}",(double)myPay.Ded04);
                txtDed05.Text = string.Format("{0:N2}",(double)myPay.Ded05);
                txtDed06.Text = string.Format("{0:N2}",(double)myPay.Ded06);
                txtDed07.Text = string.Format("{0:N2}",(double)myPay.Ded07);
                txtDed08.Text = string.Format("{0:N2}",(double)myPay.Ded08);
                txtDed09.Text = string.Format("{0:N2}",(double)myPay.Ded09);
                txtDed10.Text = string.Format("{0:N2}",(double)myPay.Ded10);
                txtDed11.Text = string.Format("{0:N2}",(double)myPay.Ded11);
                txtDed12.Text = string.Format("{0:N2}",(double)myPay.Ded12);
                txtDed13.Text = string.Format("{0:N2}",(double)myPay.Ded13);
                txtDed14.Text = string.Format("{0:N2}",(double)myPay.Ded14);
                txtDed014.Text = string.Format("{0:N2}", (double)myPay.Ded014);
                txtDed15.Text = string.Format("{0:N2}",(double)myPay.Ded15);
                txtAdd041.Text = myPay.Add041.ToString();
                txtAdd042.Text = myPay.Add042.ToString();
                txtDed021.Text = myPay.Ded021.ToString();
                txtDed022.Text = myPay.Ded022.ToString();

                txtsBasic.Text = myPay.sBasic;
                txtsAdd01.Text = myPay.sAdd01;
                txtsAdd02.Text = myPay.sAdd02;
                txtsAdd03.Text = myPay.sAdd03;
                txtsAdd04.Text = myPay.sAdd04;
                txtsAdd05.Text = myPay.sAdd05;
                txtsAdd06.Text = myPay.sAdd06;
                txtsAdd07.Text = myPay.sAdd07;
                txtsAdd08.Text = myPay.sAdd08;
                txtsAdd09.Text = myPay.sAdd09;
                txtsAdd10.Text = myPay.sAdd10;
                txtsAdd11.Text = myPay.sAdd11;
                txtsAdd12.Text = myPay.sAdd12;
                txtsAdd13.Text = myPay.sAdd13;
                txtsAdd14.Text = myPay.sAdd14;
                txtsAdd15.Text = myPay.sAdd15;

                txtsDed01.Text = myPay.sDed01;
                txtsDed02.Text = myPay.sDed02;
                txtsDed03.Text = myPay.sDed03;
                txtsDed04.Text = myPay.sDed04;
                txtsDed05.Text = myPay.sDed05;
                txtsDed06.Text = myPay.sDed06;
                txtsDed07.Text = myPay.sDed07;
                txtsDed08.Text = myPay.sDed08;
                txtsDed09.Text = myPay.sDed09;
                txtsDed10.Text = myPay.sDed10;
                txtsDed11.Text = myPay.sDed11;
                txtsDed12.Text = myPay.sDed12;
                txtsDed13.Text = myPay.sDed13;
                txtsDed14.Text = myPay.sDed14;
                txtsDed15.Text = myPay.sDed15;

                txtRemark.Text = myPay.Remark;
                txtUserName.ToolTip = myPay.Username;
                txtUserDate.Text = myPay.UserDate;
                ddlNoDays.SelectedValue = myPay.NoDays.ToString();
                TblUsers ax = new TblUsers();
                if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                ax.UserName = myPay.Username;
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
                TotSum();
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
             
        }

        protected void BtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            /*
            try
            {
                if (Page.IsValid)
                {
                    iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4,-20,-20, 80, 50);
                    HttpContext.Current.Response.ContentType = "application/pdf";
                    PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
                    pdfPage page = new pdfPage();
                    writer.PageEvent = page;
                    document.Open();

                    string arialunicodepath = Server.MapPath("Fonts") + @"\arial.ttf";
                    BaseFont nationalBase;
                    nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);

                    if (ChkPrintall.Checked)
                    {
                        vPay myPay = new vPay();
                        double VAbs1 = 0, VAbs2 = 0, VAbs3 = 0, VAbs4 = 0, VAbs5 = 0, VAbs6 = 0, VAbs7 = 0, VAbs8 = 0, VAbs9 = 0, VAbs10 = 0, VAbs11 = 0, VAbs12 = 0, VAbs13 = 0;
                        if (ddlMonth.SelectedIndex == 1)
                        {
                            myPay.Year = 0;
                            myPay.Month = 0;
                        }
                        else
                        {
                            myPay.Year = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                            myPay.Month = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                        }
                        bool firstPage = true;
                        List<vPay> lPay = new List<vPay>();
                        if(ChkAccount.Checked)
                        {
                            if(ddlAccount.SelectedIndex ==0)
                            {
                                lPay = (from itm in myPay.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                        orderby itm.Account
                                        select itm).ToList();
                            }
                            else
                            {
                                lPay = (from itm in myPay.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                        where itm.Account == int.Parse(ddlAccount.SelectedValue)
                                        select itm).ToList();                            
                            }                            
                        }
                        else
                        {
                            lPay = myPay.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }

                        foreach (vPay ipay in lPay)
                        {
                            vemp iemp = new vemp();
                            iemp.EmpCode = ipay.EmpCode;
                            iemp = iemp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (iemp != null)
                            {
                                if (!firstPage)
                                {
                                    document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                                    firstPage = true;
                                }
                                else firstPage = false;

                                PdfPTable table = new PdfPTable(4);
                                table.TotalWidth = document.PageSize.Width;

                                //float[] cols = { 25,50, 50, 250, 150, 150, 150, 100, 100};
                                var cols = new[] { 225, 75, 225, 75 };
                                table.SetWidths(cols);
                                PdfPCell cell = new PdfPCell();
                                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                                cell.Phrase = new iTextSharp.text.Phrase("الشهر", nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;                    
                                //cell.Border = 0;
                                table.AddCell(cell);

                                if (ChkAccount.Checked)
                                {
                                    if (ddlAccount.SelectedIndex == 0)
                                    {
                                        cell.Phrase = new iTextSharp.text.Phrase(ddlMonth.SelectedItem.Text + "           " + iemp.AccountName, nationalTextFont);
                                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                        table.AddCell(cell);
                                    }
                                    else
                                    {
                                        cell.Phrase = new iTextSharp.text.Phrase(ddlMonth.SelectedItem.Text + "           " + ddlAccount.SelectedItem.Text, nationalTextFont);
                                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                        table.AddCell(cell);
                                    }
                                }
                                else
                                {
                                    cell.Phrase = new iTextSharp.text.Phrase(ddlMonth.SelectedItem.Text, nationalTextFont);
                                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                    table.AddCell(cell);
                                }

                                cell.Phrase = new iTextSharp.text.Phrase("نوع الموظف", nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(rdoEmpType.Items[(int)iemp.EmpType].Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase("كود الموظف", nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(ipay.EmpCode.ToString(), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase("الاسم", nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(iemp.Name, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase("القطاع", nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                //cell.Border = 0;
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(iemp.SectorName, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase("الإدارة", nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(iemp.DepName, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase("القسم", nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(iemp.SectionName, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase("الكادر", nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(iemp.JobName, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table.AddCell(cell);


                                document.Add(table);

                                PdfPTable table2 = new PdfPTable(5);
                                table2.TotalWidth = document.PageSize.Width;
                                var cols2 = new[] { 75, 75, 100, 200, 200 };
                                table2.SetWidths(cols2);
                                table2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                table2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                                document.AddTitle("اسم التقرير");

                                // **************************************************************************************************************************
                                // document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));

                                cell.Phrase = new iTextSharp.text.Phrase("الاستحقاقات", nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                                table2.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase("الاستقطاعات", nationalTextFont);
                                table2.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase("الغياب", nationalTextFont);
                                table2.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase("عدد الساعات", nationalTextFont);
                                table2.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase("القيمة", nationalTextFont);
                                table2.AddCell(cell);

                                document.Add(table2);

                                PdfPTable table3 = new PdfPTable(7);
                                table3.TotalWidth = document.PageSize.Width;
                                var cols3 = new[] { 75, 75, 100, 75, 125, 75, 125 };
                                table3.SetWidths(cols3);
                                table3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                table3.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                                cell.Phrase = new iTextSharp.text.Phrase(lblBasic.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VBasic), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                if (ipay.Abs1 + ipay.Abs2 + ipay.Abs3 + ipay.Abs4 + ipay.Abs5 + ipay.Abs6 + ipay.Abs7 + ipay.Abs8 + ipay.Abs9 + ipay.Abs10 + ipay.Abs11 + ipay.Abs12 + ipay.Abs13 > 0)
                                {
                                    Absent myAbs = new Absent();
                                    myAbs.EmpCode = int.Parse(ddlEmpCode.SelectedItem.Text);
                                    myAbs.Year = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                                    myAbs.Month = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);

                                    myAbs = myAbs.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (myAbs != null)
                                    {
                                        VAbs1 = myAbs.VAbs1;
                                        VAbs2 = myAbs.VAbs2;
                                        VAbs3 = myAbs.VAbs3;
                                        VAbs4 = myAbs.VAbs4;
                                        VAbs5 = myAbs.VAbs5;
                                        VAbs6 = myAbs.VAbs6;
                                        VAbs7 = myAbs.VAbs7;
                                        VAbs8 = myAbs.VAbs8;
                                        VAbs9 = myAbs.VAbs9;
                                        VAbs10 = myAbs.VAbs10;
                                        VAbs11 = myAbs.VAbs11;
                                        VAbs12 = myAbs.VAbs12;
                                        VAbs13 = myAbs.VAbs13;
                                    }
                                    else
                                    {
                                        VAbs1 = 0;
                                        VAbs2 = 0;
                                        VAbs3 = 0;
                                        VAbs4 = 0;
                                        VAbs5 = 0;
                                        VAbs6 = 0;
                                        VAbs7 = 0;
                                        VAbs8 = 0;
                                        VAbs9 = 0;
                                        VAbs10 = 0;
                                        VAbs11 = 0;
                                        VAbs12 = 0;
                                        VAbs13 = 0;
                                    }
                                }
                                else
                                {
                                    VAbs1 = 0;
                                    VAbs2 = 0;
                                    VAbs3 = 0;
                                    VAbs4 = 0;
                                    VAbs5 = 0;
                                    VAbs6 = 0;
                                    VAbs7 = 0;
                                    VAbs8 = 0;
                                    VAbs9 = 0;
                                    VAbs10 = 0;
                                    VAbs11 = 0;
                                    VAbs12 = 0;
                                    VAbs13 = 0;
                                }

                                cell.Phrase = new iTextSharp.text.Phrase(lblDed01.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Ded01), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblsAbs1.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Abs1), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", VAbs1), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);
                                //
                                cell.Phrase = new iTextSharp.text.Phrase(lblAdd01.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VAdd01), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblDed02.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Ded02), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblsAbs2.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Abs2), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", VAbs2), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);
                                //
                                cell.Phrase = new iTextSharp.text.Phrase(lblAdd02.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VAdd02), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblDed04.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Ded04), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblsAbs3.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Abs3), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", VAbs3), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);
                                //
                                cell.Phrase = new iTextSharp.text.Phrase(lblAdd03.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VAdd03), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblDed03.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VDed03), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblsAbs4.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Abs4), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", VAbs4), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);
                                //
                                cell.Phrase = new iTextSharp.text.Phrase(lblAdd04.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VAdd04), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblDed05.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Ded05), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblsAbs5.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Abs5), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", VAbs5), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);
                                //
                                cell.Phrase = new iTextSharp.text.Phrase(lblAdd05.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VAdd05), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblDed06.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Ded06), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblsAbs6.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Abs6), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", VAbs6), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);
                                //
                                cell.Phrase = new iTextSharp.text.Phrase(lblAdd06.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VAdd06), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblDed07.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Ded07), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblsAbs7.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Abs7), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", VAbs7), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);
                                //
                                cell.Phrase = new iTextSharp.text.Phrase(lblAdd07.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VAdd07), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblDed08.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Ded08), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblsAbs8.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Abs8), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", VAbs8), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);
                                //
                                cell.Phrase = new iTextSharp.text.Phrase(lblAdd08.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VAdd08), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblDed09.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Ded09), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblsAbs9.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Abs9), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", VAbs9), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);
                                //
                                cell.Phrase = new iTextSharp.text.Phrase(lblAdd09.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VAdd09), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblDed10.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VDed10), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblsAbs10.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Abs10), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", VAbs10), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);
                                //
                                cell.Phrase = new iTextSharp.text.Phrase(lblAdd10.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VAdd10), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblLoan.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VLoan), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblsAbs11.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Abs11), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", VAbs11), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);
                                //
                                cell.Phrase = new iTextSharp.text.Phrase(lblAdd11.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VAdd11), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblDiff.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VDiff), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblsAbs12.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Abs12), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", VAbs12), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);
                                //
                                cell.Phrase = new iTextSharp.text.Phrase(lblAdd12.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VAdd12), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblVPenal.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VPenal), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblsAbs13.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Abs13), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", VAbs13), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblAdd13.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase("    ", nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase("     ", nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase("الاجمالي", nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.Abs1 + ipay.Abs2 + ipay.Abs3 + ipay.Abs4 + ipay.Abs5 + ipay.Abs6 + ipay.Abs7 + ipay.Abs8 + ipay.Abs9 + ipay.Abs10 + ipay.Abs11 + ipay.Abs12 + ipay.Abs13), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", VAbs1 + VAbs2 + VAbs3 + VAbs4 + VAbs5 + VAbs6 + VAbs7 + VAbs8 + VAbs9 + VAbs10 + VAbs11 + VAbs12 + VAbs13), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblTAdd.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VTotAdd2), nationalTextFont);
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblTDed.Text, nationalTextFont);
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VTotDed), nationalTextFont);
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblAdd13.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VAdd13), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(lblNet.Text, nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ipay.VNet), nationalTextFont);
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                                table3.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                                table3.AddCell(cell);

                                document.Add(table3);

                                // **************************************************************************************************************************
                                //if (ipay.VLoan > 0)
                                //{
                                //    document.Add(new iTextSharp.text.Phrase(Environment.NewLine, nationalTextFont));
                                //    PdfPTable table4 = new PdfPTable(6);
                                //    table3.TotalWidth = document.PageSize.Width;
                                //    var cols4 = new[] { 70, 70, 100, 200, 100, 70 };
                                //    table4.SetWidths(cols4);
                                //    table4.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                //    table4.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                                //    cell.Phrase = new iTextSharp.text.Phrase("رقم البيان", nationalTextFont);
                                //    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                //    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                                //    table4.AddCell(cell);

                                //    cell.Phrase = new iTextSharp.text.Phrase("قيمة القسط", nationalTextFont);
                                //    table4.AddCell(cell);

                                //    cell.Phrase = new iTextSharp.text.Phrase("جهة القرض", nationalTextFont);
                                //    table4.AddCell(cell);

                                //    cell.Phrase = new iTextSharp.text.Phrase("المتبقي", nationalTextFont);
                                //    table4.AddCell(cell);

                                //    cell.Phrase = new iTextSharp.text.Phrase("تاريخ البداية", nationalTextFont);
                                //    table4.AddCell(cell);

                                //    cell.Phrase = new iTextSharp.text.Phrase("تاريخ النهاية", nationalTextFont);
                                //    table4.AddCell(cell);

                                //    vLoanDetails myLoans = new vLoanDetails();
                                //    myLoans.EmpCode = ipay.EmpCode;
                                //    myLoans.Year = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                                //    myLoans.Month = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);

                                //    foreach (vLoanDetails ld in myLoans.getall2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                //    {
                                //        cell.Phrase = new iTextSharp.text.Phrase(ld.NoteNo.ToString(), nationalTextFont);
                                //        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                //        cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                                //        table4.AddCell(cell);

                                //        cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ld.Amount), nationalTextFont);
                                //        table4.AddCell(cell);

                                //        cell.Phrase = new iTextSharp.text.Phrase(ld.CompanyName, nationalTextFont);
                                //        table4.AddCell(cell);

                                //        cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ld.Net2), nationalTextFont);
                                //        table4.AddCell(cell);

                                //        cell.Phrase = new iTextSharp.text.Phrase(ld.StartDate, nationalTextFont);
                                //        table4.AddCell(cell);

                                //        cell.Phrase = new iTextSharp.text.Phrase(ld.EndDate, nationalTextFont);
                                //        table4.AddCell(cell);
                                //    }                                 
                                //    document.Add(table4);                                
                                //}
                            }
                        }
                    }
                    else
                    {
                        PdfPTable table = new PdfPTable(4);
                        table.TotalWidth = document.PageSize.Width;
                        //float[] cols = { 25,50, 50, 250, 150, 150, 150, 100, 100};
                        var cols = new[] { 225, 75, 225, 75 };
                        table.SetWidths(cols);
                        PdfPCell cell = new PdfPCell();
                        cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                        table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                        table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                        cell.Phrase = new iTextSharp.text.Phrase("الشهر", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        cell.ArabicOptions = ColumnText.DIGITS_EN2AN;                    
                        //cell.Border = 0;
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(ddlMonth.SelectedItem.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("نوع الموظف", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(rdoEmpType.SelectedItem.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("كود الموظف", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(ddlEmpCode.SelectedItem.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("الاسم", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblName.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("القطاع", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        //cell.Border = 0;
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblSector.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("الإدارة", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblDep.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("القسم", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblSection.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("الكادر", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblJob.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table.AddCell(cell);


                        document.Add(table);

                        PdfPTable table2 = new PdfPTable(5);
                        table2.TotalWidth = document.PageSize.Width;
                        var cols2 = new[] { 75, 75, 100, 200, 200 };
                        table2.SetWidths(cols2);
                        table2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                        table2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                        document.AddTitle("اسم التقرير");

                        // **************************************************************************************************************************
                        document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));

                        cell.Phrase = new iTextSharp.text.Phrase("الاستحقاقات", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        table2.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("الاستقطاعات", nationalTextFont);
                        table2.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("الغياب", nationalTextFont);
                        table2.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("عدد الساعات", nationalTextFont);
                        table2.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("القيمة", nationalTextFont);
                        table2.AddCell(cell);

                        document.Add(table2);

                        PdfPTable table3 = new PdfPTable(7);
                        table3.TotalWidth = document.PageSize.Width;
                        var cols3 = new[] { 75, 75, 100, 75, 125, 75, 125 };
                        table3.SetWidths(cols3);
                        table3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                        table3.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        //
                        cell.Phrase = new iTextSharp.text.Phrase(lblBasic.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtVBasic.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblDed01.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtDed01.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblsAbs1.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblAbs1.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblVAbs1.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        //ContentPlaceHolder MainContent = Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder; (MainContent.FindControl("lblAdd" + s) as Label).Text
                        //
                        cell.Phrase = new iTextSharp.text.Phrase(lblAdd01.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtVAdd01.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblDed02.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtDed02.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblsAbs2.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblAbs2.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblVAbs2.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);
                        //
                        cell.Phrase = new iTextSharp.text.Phrase(lblAdd02.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtVAdd02.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblDed04.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtDed04.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblsAbs3.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblAbs3.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblVAbs3.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);
                        //
                        cell.Phrase = new iTextSharp.text.Phrase(lblAdd03.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtVAdd03.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblDed03.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtDed03.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblsAbs4.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblAbs4.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblVAbs4.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);
                        //
                        cell.Phrase = new iTextSharp.text.Phrase(lblAdd04.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtVAdd04.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblDed05.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtDed05.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblsAbs5.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblAbs5.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblVAbs5.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);
                        //
                        cell.Phrase = new iTextSharp.text.Phrase(lblAdd05.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtVAdd05.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblDed06.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtDed06.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblsAbs6.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblAbs6.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblVAbs6.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);
                        //
                        cell.Phrase = new iTextSharp.text.Phrase(lblAdd06.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtVAdd06.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblDed07.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtDed07.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblsAbs7.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblAbs7.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblVAbs7.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);
                        //
                        cell.Phrase = new iTextSharp.text.Phrase(lblAdd07.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtVAdd07.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblDed08.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtDed08.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblsAbs8.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblAbs8.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblVAbs8.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);
                        //
                        cell.Phrase = new iTextSharp.text.Phrase(lblAdd08.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtVAdd08.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblDed09.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtDed09.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblsAbs9.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblAbs9.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblVAbs9.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);
                        //
                        cell.Phrase = new iTextSharp.text.Phrase(lblAdd09.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtVAdd09.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblDed10.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtDed10.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblsAbs10.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblAbs10.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblVAbs10.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);
                        //
                        cell.Phrase = new iTextSharp.text.Phrase(lblAdd10.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtVAdd10.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblLoan.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtVLoan.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblsAbs11.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblAbs11.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblVAbs11.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblAdd11.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtVAdd11.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblDiff.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtVDiff.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblsAbs12.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblAbs12.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblVAbs12.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblAdd12.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtVAdd12.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblVPenal.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtVPenal.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblsAbs13.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblAbs13.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblVAbs13.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("     ", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("    ", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("    ", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("     ", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("الاجمالي", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", moh.StrToDouble(lblAbs1.Text) + moh.StrToDouble(lblAbs2.Text) + moh.StrToDouble(lblAbs3.Text) + moh.StrToDouble(lblAbs4.Text) + moh.StrToDouble(lblAbs5.Text) + moh.StrToDouble(lblAbs6.Text) + moh.StrToDouble(lblAbs7.Text) + moh.StrToDouble(lblAbs8.Text) + moh.StrToDouble(lblAbs9.Text) + moh.StrToDouble(lblAbs10.Text) + moh.StrToDouble(lblAbs11.Text) + moh.StrToDouble(lblAbs12.Text) + moh.StrToDouble(lblAbs13.Text)), nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", moh.StrToDouble(lblVAbs1.Text) + moh.StrToDouble(lblVAbs2.Text) + moh.StrToDouble(lblVAbs3.Text) + moh.StrToDouble(lblVAbs4.Text) + moh.StrToDouble(lblVAbs5.Text) + moh.StrToDouble(lblVAbs6.Text) + moh.StrToDouble(lblVAbs7.Text) + moh.StrToDouble(lblVAbs8.Text) + moh.StrToDouble(lblVAbs9.Text) + moh.StrToDouble(lblVAbs10.Text) + moh.StrToDouble(lblVAbs11.Text) + moh.StrToDouble(lblVAbs12.Text) + moh.StrToDouble(lblVAbs13.Text)), nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        /* cell.Phrase = new iTextSharp.text.Phrase(lblOver.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        //cell.Phrase = new iTextSharp.text.Phrase(txtVOver.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("    ", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("     ", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("    ", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("    ", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("    ", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell); 

                        cell.Phrase = new iTextSharp.text.Phrase(lblTAdd.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtTAdd.Text, nationalTextFont);
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblTDed.Text, nationalTextFont);
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtTDed.Text, nationalTextFont);
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblAdd13.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtVAdd13.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(lblNet.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(txtNet.Text, nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("     ", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("     ", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("     ", nationalTextFont);
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        table3.AddCell(cell);



                        document.Add(table3);


                        /*
                        if (false)
                        {
                            document.Add(new iTextSharp.text.Phrase("    ", nationalTextFont));
                            PdfPTable table4 = new PdfPTable(11);
                            table3.TotalWidth = 100f;
                            var cols4 = new[] {45,45,45,45,45,45,45,45,45,45,50};
                            table4.SetWidths(cols4);
                            table4.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            table4.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                            cell.Phrase = new iTextSharp.text.Phrase("اليوم", nationalTextFont);
                            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                            table4.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase("بداية الوقت", nationalTextFont);
                            table4.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase("نهاية الوقت", nationalTextFont);
                            table4.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase("عدد الساعات", nationalTextFont);
                            table4.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase("جمع و عطلات", nationalTextFont);
                            table4.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase("ساعات 1.25", nationalTextFont);
                            table4.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase("ساعات 1.5", nationalTextFont);
                            table4.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase("ساعات 1", nationalTextFont);
                            table4.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase("ساعات 2.5", nationalTextFont);
                            table4.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase("ساعات 3", nationalTextFont);
                            table4.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase("م ساعات معدلة", nationalTextFont);
                            table4.AddCell(cell);

                            Trans myTrans = new Trans();
                            myTrans.EmpCode = int.Parse(ddlEmpCode.SelectedItem.Text);
                            myTrans.Year = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                            myTrans.Month = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);

                            foreach (Trans ld in myTrans.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                cell.Phrase = new iTextSharp.text.Phrase(ld.day.ToString(), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                                table4.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(ld.InTime, nationalTextFont);
                                table4.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(ld.OutTime, nationalTextFont);
                                table4.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ld.HourNo), nationalTextFont);
                                table4.AddCell(cell);
                            
                                if ((bool)ld.ISVac)
                                {
                                    cell.Phrase = new iTextSharp.text.Phrase("نعم", nationalTextFont);
 
                                    //iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/images/accept.png"));
                                    //logo.ScalePercent(40);
                                    //PdfPCell cell2 = new PdfPCell(logo);
                                    //cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                                    ////add a bit of padding to bring it away from the right edge
                                    //cell2.PaddingTop = 3;
                                    table4.AddCell(cell);
                                }
                                else
                                {
                                    cell.Phrase = new iTextSharp.text.Phrase("لا", nationalTextFont);
                                    //iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/images/cross.png"));
                                    //logo.ScalePercent(40);
                                    //PdfPCell cell2 = new PdfPCell(logo);
                                    //cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                                    ////add a bit of padding to bring it away from the right edge
                                    //cell2.PaddingTop = 3;
                                    table4.AddCell(cell);
                                }
                         

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ld.Hour125), nationalTextFont);
                                table4.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ld.Hour15), nationalTextFont);
                                table4.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ld.Hour1), nationalTextFont);
                                table4.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ld.Hour25), nationalTextFont);
                                table4.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ld.Hour3), nationalTextFont);
                                table4.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ld.HourNo2), nationalTextFont);
                                table4.AddCell(cell);
                            }
                            document.Add(table4);
                        }
                        
                        // **************************************************************************************************************************
                        if (moh.StrToDouble(txtVLoan.Text) > 0)
                        {
                            document.Add(new iTextSharp.text.Phrase(Environment.NewLine, nationalTextFont));
                            PdfPTable table4 = new PdfPTable(6);
                            table3.TotalWidth = document.PageSize.Width;
                            var cols4 = new[] { 70, 70, 100, 200, 100, 70 };
                            table4.SetWidths(cols4);
                            table4.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            table4.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                            cell.Phrase = new iTextSharp.text.Phrase("رقم البيان", nationalTextFont);
                            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                            table4.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase("قيمة القسط", nationalTextFont);
                            table4.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase("جهة القرض", nationalTextFont);
                            table4.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase("المتبقي", nationalTextFont);
                            table4.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase("تاريخ البداية", nationalTextFont);
                            table4.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase("تاريخ النهاية", nationalTextFont);
                            table4.AddCell(cell);

                            vLoanDetails myLoans = new vLoanDetails();
                            myLoans.EmpCode = int.Parse(ddlEmpCode.SelectedItem.Text);
                            myLoans.Year = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                            myLoans.Month = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);

                            foreach (vLoanDetails ld in myLoans.getall2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                cell.Phrase = new iTextSharp.text.Phrase(ld.NoteNo.ToString(), nationalTextFont);
                                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                                table4.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ld.Amount), nationalTextFont);
                                table4.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(ld.CompanyName, nationalTextFont);
                                table4.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", ld.Net2), nationalTextFont);
                                table4.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(ld.StartDate, nationalTextFont);
                                table4.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(ld.EndDate, nationalTextFont);
                                table4.AddCell(cell);
                            }
                            document.Add(table4);
                        }
                    }                    
                    document.Close();
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
             */
        }

        protected void BtnFind_Click(object sender, ImageClickEventArgs e)
        {
            if (txtCode.Text != "")
            {
                foreach (ListItem itm in ddlEmpCode.Items)
                {
                    if(itm.Text == txtCode.Text.Split('.')[0].Trim() ) 
                    {
                        itm.Selected = true;
                    }
                    else itm.Selected = false;
                }
                ddlEmpCode_SelectedIndexChanged(sender, e);
            }
        }

        protected void txtCode_TextChanged(object sender, EventArgs e)
        {
            BtnFind_Click(sender,null);
        }

        protected void ddlNoDays_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (int.Parse(ddlNoDays.SelectedValue) < 20)
            {
                //txtDed03.Text = "0.00";
                //txtDed09.Text = "0.00";
                //txtDed10.Text = "0.00";
                //txtDed12.Text = "0.00";
            }

            SEmp myEmp = new SEmp();
            myEmp.EmpCode = int.Parse(ddlEmpCode.SelectedItem.Text);
            myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myEmp != null)
            {
                txtBasic.Text = string.Format("{0:N2}", Math.Round((double)myEmp.Basic * int.Parse(ddlNoDays.SelectedValue) / 30, 2));               
                txtAdd01.Text = string.Format("{0:N2}", Math.Round((double)myEmp.Add01 * int.Parse(ddlNoDays.SelectedValue) / 30, 2));
                txtAdd02.Text = string.Format("{0:N2}", Math.Round((double)myEmp.Add02 * int.Parse(ddlNoDays.SelectedValue) / 30, 2));
                txtAdd03.Text = string.Format("{0:N2}", Math.Round((double)myEmp.Add03 * int.Parse(ddlNoDays.SelectedValue) / 30, 2));
                txtAdd05.Text = string.Format("{0:N2}", Math.Round((double)myEmp.Add05 * int.Parse(ddlNoDays.SelectedValue) / 30, 2));
                txtAdd13.Text = string.Format("{0:N2}", Math.Round((double)myEmp.Add13 * int.Parse(ddlNoDays.SelectedValue) / 30, 2));
                txtAdd14.Text = string.Format("{0:N2}", Math.Round((double)myEmp.Add14 * int.Parse(ddlNoDays.SelectedValue) / 30, 2));
            }

            TotSum();
        }

        protected void txtAdd041_TextChanged(object sender, EventArgs e)
        {
            double basic = 0;
            SEmp myEmp = new SEmp();
            myEmp.EmpCode = int.Parse(ddlEmpCode.SelectedItem.Text);
            myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myEmp != null)
            {
                basic = (double)myEmp.Basic;
            }

            if (txtAdd041.Text == "") txtAdd041.Text = "0";
            if (txtAdd042.Text == "") txtAdd042.Text = "0";

            double Houram = basic * 1.5 / 240;

            txtAdd04.Text = string.Format("{0:N2}",
                Math.Round((Houram * moh.StrToDouble(txtAdd041.Text) * 8) + (Houram * moh.StrToDouble(txtAdd042.Text)), 2));
        }

        protected void txtDed021_TextChanged(object sender, EventArgs e)
        {
            double basic = 0 , add01 = 0;
            SEmp myEmp = new SEmp();
            myEmp.EmpCode = int.Parse(ddlEmpCode.SelectedItem.Text);
            myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myEmp != null)
            {
                basic = (double)myEmp.Basic;
                add01 = (double)myEmp.Add01 + (double)myEmp.Add02 + (double)myEmp.Add03 + (double)myEmp.Add05 + (double)myEmp.Add13 + (double)myEmp.Add14;
            }

            if (txtBasic.Text == "") txtBasic.Text = "0.00";
            if (txtAdd01.Text == "") txtAdd01.Text = "0.00";
            if (txtDed021.Text == "") txtDed021.Text = "0";
            if (txtDed022.Text == "") txtDed022.Text = "0";

            double Houram = (basic * 1) / 240;
            double Dayam = ((basic + add01) * 1) / 30;

            txtDed02.Text = string.Format("{0:N2}",
                Math.Round((Houram * moh.StrToDouble(txtDed022.Text)) + (Dayam * moh.StrToDouble(txtDed021.Text)), 2));
        }

        protected void txtDed014_TextChanged(object sender, EventArgs e)
        {
            double vDed = 0;
            SEmp myEmp = new SEmp();
            myEmp.EmpCode = int.Parse(ddlEmpCode.SelectedItem.Text);
            myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myEmp != null)
            {
                vDed = (double)myEmp.Add01 + (double)myEmp.Add03 + (double)myEmp.Add05 + (double)myEmp.Add13 + (double)myEmp.Add14;
            }
            txtDed14.Text = string.Format("{0:N2}",Math.Round((vDed / 30)  * moh.StrToDouble(txtDed014.Text), 2));
        }


       
        // *************************************************** ITextSharp ****************************************************************
        /*
        public class pdfPage : iTextSharp.text.pdf.PdfPageEventHelper
        {
           
            //I create a font object to use within my footer
            protected iTextSharp.text.Font footer
            {
                get
                {
                    // create a basecolor to use for the footer font, if needed.
                    iTextSharp.text.BaseColor grey = new iTextSharp.text.BaseColor(128, 128, 128);
                    string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\arial.ttf";
                    BaseFont nationalBase;
                    nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(nationalBase, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.WHITE);
                    return font;
                }
            }
            //override the OnStartPage event handler to add our header
            public override void OnStartPage(PdfWriter writer, iTextSharp.text.Document doc)
            {
                string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\DTNASKH1.TTF";
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 16f, iTextSharp.text.Font.NORMAL);

                //I use a PdfPtable with 1 column to position my header where I want it
                PdfPTable headerTbl = new PdfPTable(3);
                var cols2 = new[] { 175, 270, 200};
                headerTbl.SetWidths(cols2);

                headerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                //set the width of the table to be the same as the document
                headerTbl.TotalWidth = doc.PageSize.Width;

                PdfPCell cell = new PdfPCell();
                cell.Border = 0;
                cell.PaddingRight = 15;
                cell.Phrase = new iTextSharp.text.Phrase("شركة صناعة اليايات ومهمات وسائل النقل", nationalTextFont);
                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;                                
                headerTbl.AddCell(cell);

                cell.PaddingRight = 0;
                cell.Phrase = new iTextSharp.text.Phrase("بيان تفصيلي راتب موظف", nationalTextFont);
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                headerTbl.AddCell(cell);

                cell.PaddingRight = 15;

                //I use an image logo in the header so I need to get an instance of the image to be able to insert it. I believe this is something you couldn't do with older versions of iTextSharp
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("images/yayat.jpg"));

                //I used a large version of the logo to maintain the quality when the size was reduced. I guess you could reduce the size manually and use a smaller version, but I used iTextSharp to reduce the scale. As you can see, I reduced it down to 7% of original size.
                logo.ScalePercent(15);

                //create instance of a table cell to contain the logo
                PdfPCell cell2 = new PdfPCell(logo);

                //align the logo to the right of the cell
                cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                //add a bit of padding to bring it away from the right edge
                cell2.PaddingTop = 0;
                cell2.PaddingRight = 30;

                //remove the border
                cell2.Border = 0;

                //Add the cell to the table
                headerTbl.AddCell(cell2);

                //cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                //cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                //headerTbl.AddCell(cell);

                ////I use an image logo in the header so I need to get an instance of the image to be able to insert it. I believe this is something you couldn't do with older versions of iTextSharp
                //iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/images/Signa_NEW.gif"));

                ////I used a large version of the logo to maintain the quality when the size was reduced. I guess you could reduce the size manually and use a smaller version, but I used iTextSharp to reduce the scale. As you can see, I reduced it down to 7% of original size.
                //logo.ScalePercent(20);

                ////create instance of a table cell to contain the logo
                //PdfPCell cell = new PdfPCell(logo);

                ////align the logo to the right of the cell
                //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                ////add a bit of padding to bring it away from the right edge
                ////cell.PaddingRight = 20;

                ////remove the border
                //cell.Border = 0;

                ////Add the cell to the table
                //headerTbl.AddCell(cell);

                //cell2.Phrase = new iTextSharp.text.Phrase("             ", nationalTextFont);
                //headerTbl.AddCell(cell2);

                //write the rows out to the PDF output stream. I use the height of the document to position the table. Positioning seems quite strange in iTextSharp and caused me the biggest headache.. It almost seems like it starts from the bottom of the page and works up to the top, so you may ned to play around with this.
                headerTbl.WriteSelectedRows(0, -1, -1, (doc.PageSize.Height - 20), writer.DirectContent);
            }

            //override the OnPageEnd event handler to add our footer
            public override void OnEndPage(PdfWriter writer, iTextSharp.text.Document doc)
            {
                //I use a PdfPtable with 2 columns to position my footer where I want it
                PdfPTable footerTbl = new PdfPTable(3);
                var cols2 = new[] { 150, 270, 180 };
                footerTbl.SetWidths(cols2);
                footerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                footerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                //set the width of the table to be the same as the document
                footerTbl.TotalWidth = doc.PageSize.Width;
                //Center the table on the page
                footerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = iTextSharp.text.BaseColor.RED;
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                //set cell border to 0
                cell.Border = 0;
                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;                    

                //add some padding to bring away from the edge
                cell.PaddingRight = 5;
                cell.Phrase = new iTextSharp.text.Phrase("تاريخ الطباعة : "+String.Format("{0:dd/MM/yyyy}", moh.Nows()), footer);
                //add cell to table
                footerTbl.AddCell(cell);

                //create new instance of cell to hold the text
                //cell = new PdfPCell();

                //align the text to the right of the cell
                //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell.Phrase = new iTextSharp.text.Phrase("     ", footer);

                // add some padding to take away from the edge of the page
                //cell.PaddingRight = 5;

                //add the cell to the table
                footerTbl.AddCell(cell);

                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell.Phrase = new iTextSharp.text.Phrase("صفحة رقم " + writer.PageNumber.ToString() , footer);

                // add some padding to take away from the edge of the page
                cell.PaddingLeft = 5;

                //add the cell to the table
                footerTbl.AddCell(cell);

                //write the rows out to the PDF output stream.
                footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin - 10), writer.DirectContent);
            }
        }
        */

    }        
}