using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class WebEmp : System.Web.UI.Page
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

        public void EditMode()
        {
            txtEmpCode.ReadOnly = true;
            txtEmpCode.BackColor = System.Drawing.Color.LightGray;

            BtnEdit.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[3].Pass102;
            BtnNew.Visible = false;
            BtnDelete.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[3].Pass103;

            if (BtnEdit.Visible || BtnDelete.Visible)
            {
                txtReason.Visible = true;
                ValReason.Enabled = true;
                lblReason.Visible = true;
            }
            ControlsOnOff(BtnEdit.Visible);
        }

        public void NewMode()
        {
            txtEmpCode.ReadOnly = false;
            txtEmpCode.BackColor = System.Drawing.Color.White;

            BtnEdit.Visible = false;
            BtnNew.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[3].Pass101;
            BtnDelete.Visible = false;
            txtReason.Visible = false;
            ValReason.Enabled = false;
            lblReason.Visible = false;
            ControlsOnOff(BtnEdit.Visible || BtnNew.Visible);
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
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad1);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad2);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad3);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad4);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad5);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad6);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad7);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad8);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad9);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad10);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttach);
                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "البيانات الأساسية";

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
                        UserTran.Description = "تم اختيار صفحة البيانات الاساسية للموظفين";
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

                        lblPaper1.Text = mysetting.Paper1;
                        lblPaper2.Text = mysetting.Paper2;
                        lblPaper3.Text = mysetting.Paper3;
                        lblPaper4.Text = mysetting.Paper4;
                        lblPaper5.Text = mysetting.Paper5;
                        lblPaper6.Text = mysetting.Paper6;
                        lblPaper7.Text = mysetting.Paper7;
                        lblPaper8.Text = mysetting.Paper8;
                        lblPaper9.Text = mysetting.Paper9;
                        lblPaper10.Text = mysetting.Paper10;

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
                    }

                    ddlNational.DataTextField = "Name1";
                    ddlNational.DataValueField = "Code";
                    ddlJob.DataTextField = "Name1";
                    ddlJob.DataValueField = "Code";
                    ddlSection.DataTextField = "Name1";
                    ddlSection.DataValueField = "Code";
                    ddlDep.DataTextField = "Name1";
                    ddlDep.DataValueField = "Code";
                    ddlCertificate.DataTextField = "Name1";
                    ddlCertificate.DataValueField = "Code";
                    ddlPaperLoc1.DataTextField = "Name1";
                    ddlPaperLoc1.DataValueField = "Code";
                    ddlPaperLoc2.DataTextField = "Name1";
                    ddlPaperLoc2.DataValueField = "Code";
                    ddlPaperLoc3.DataTextField = "Name1";
                    ddlPaperLoc3.DataValueField = "Code";
                    ddlPaperLoc4.DataTextField = "Name1";
                    ddlPaperLoc4.DataValueField = "Code";
                    ddlPaperLoc5.DataTextField = "Name1";
                    ddlPaperLoc5.DataValueField = "Code";
                    ddlPaperLoc6.DataTextField = "Name1";
                    ddlPaperLoc6.DataValueField = "Code";
                    ddlPaperLoc7.DataTextField = "Name1";
                    ddlPaperLoc7.DataValueField = "Code";
                    ddlPaperLoc8.DataTextField = "Name1";
                    ddlPaperLoc8.DataValueField = "Code";
                    ddlPaperLoc9.DataTextField = "Name1";
                    ddlPaperLoc9.DataValueField = "Code";
                    ddlPaperLoc10.DataTextField = "Name1";
                    ddlPaperLoc10.DataValueField = "Code";
                    ddlReginal.DataTextField = "Name1";
                    ddlReginal.DataValueField = "Code";
                    ddlBirthPlace.DataTextField = "Name1";
                    ddlBirthPlace.DataValueField = "Code";                    
                    ddlBank.DataTextField = "Name1";
                    ddlBank.DataValueField = "Code";
                    ddlSponsor.DataTextField = "Name1";
                    ddlSponsor.DataValueField = "Code";

                    ddlShift.DataTextField = "Name1";
                    ddlShift.DataValueField = "Code";

                    BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[3].Pass101;
                    BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[3].Pass102;
                    BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[3].Pass103;
                    BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[3].Pass104;
                    BtnFind2.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[3].Pass104;
                    string vRoleName = ((List<TblRoles>)(Session[moh.GetCurrentRole(AreaNo, (from useritm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                                                                             where useritm.UserName == Session["CurrentUser"].ToString()
                                                                                             select useritm).FirstOrDefault())]))[0].RoleName;
                    vRoleName = (vRoleName == null ? "Roll" : vRoleName);

                    ddlType2.DataTextField = "Name";
                    ddlType2.DataValueField = "FType";

                    Functions1 myFun = new Functions1();
                    ddlType2.DataSource = (from itm in myFun.GetAll((Request.QueryString["Support"] != null), AreaNo, StoreNo, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                           //where itm.FCreate == "-1" || itm.FCreate == "*" || itm.FCreate.Contains(Session["CurrentUser"].ToString()) || itm.FCreate.Contains(vRoleName)
                                           select itm).ToList();
                    ddlType2.DataBind();
                    ddlType2.Items.Insert(0, new ListItem("--- الجميع ---", "-1", true));

                    int vY = 2018;
                    int vM = 11;
                    int vY2 = moh.Nows().Year;
                    int vM2 = moh.Nows().Month;

                    while (vY <= vY2)
                    {
                        for (int i = vM; i < 13; i++)
                        {
                            ddlMonth2.Items.Add(new ListItem(vY.ToString() + "/" + moh.MakeMask(i.ToString(), 2), vY.ToString() + "/" + moh.MakeMask(i.ToString(), 2)));
                        }
                        vY++;
                        vM = 1;
                    }
                    ddlMonth2.Items.Insert(0, new ListItem("--- الجميع ---", "-1", true));                                       


                    LoadddlData();
                    BtnClear_Click(sender, null);
                    if (Request.QueryString["FNum"] != null)
                    {
                        txtEmpCode.Text = Request.QueryString["FNum"].ToString();
                        BtnSearch_Click(sender, null);
                    }
                    LoadHistoryTran();
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

        public void LoadHistoryTran()
        {
            try
            {
                veServices myService = new veServices();
                myService.DocType = -1;
                myService.EmpCode = int.Parse(txtEmpCode.Text);
                grdTranHistory.DataSource = (from itm in myService.GetAll0(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                             where (ddlMonth2.SelectedIndex == 0 || (DateTime.Parse(itm.DocDate).Year == int.Parse(ddlMonth2.SelectedItem.Text.Split('/')[0])) && (DateTime.Parse(itm.DocDate).Month == int.Parse(ddlMonth2.SelectedItem.Text.Split('/')[1]))) && (ddlType2.SelectedIndex == 0 || itm.DocType.ToString() == ddlType2.SelectedValue)
                                             select itm).ToList();
                grdTranHistory.DataBind();
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

        protected void grdTranHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdTranHistory.PageIndex = e.NewPageIndex;
                LoadHistoryTran();
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

        protected void ddlMonth2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHistoryTran();
        }

        public void ControlsOnOff(bool State)
        {
            this.txtAdd01.ReadOnly = !State;
            this.txtAdd02.ReadOnly = !State;
            this.txtAdd03.ReadOnly = !State;
            this.txtAdd04.ReadOnly = !State;
            this.txtAdd05.ReadOnly = !State;
            this.txtAdd06.ReadOnly = !State;
            this.txtAdd07.ReadOnly = !State;
            this.txtAdd08.ReadOnly = !State;
            this.txtAdd09.ReadOnly = !State;
            this.txtAdd10.ReadOnly = !State;
            this.txtAdd11.ReadOnly = !State;
            this.txtAdd12.ReadOnly = !State;
            this.txtAdd13.ReadOnly = !State;
            this.txtAdd14.ReadOnly = !State;
            this.txtAdd15.ReadOnly = !State;
            this.txtDed01.ReadOnly = !State;
            this.txtDed02.ReadOnly = !State;
            //this.txtDed03.ReadOnly = !State;
            this.txtDed04.ReadOnly = !State;
            this.txtDed05.ReadOnly = !State;
            this.txtDed06.ReadOnly = !State;
            this.txtDed07.ReadOnly = !State;
            this.txtDed08.ReadOnly = !State;
            this.txtDed09.ReadOnly = !State;
            this.txtDed10.ReadOnly = !State;
            this.txtDed11.ReadOnly = !State;
            this.txtDed12.ReadOnly = !State;
            this.txtDed13.ReadOnly = !State;
            this.txtDed14.ReadOnly = !State;
            this.txtDed15.ReadOnly = !State;

            this.txtamP10.ReadOnly = !State;
            this.txtamP11.ReadOnly = !State;
            this.txtamP12.ReadOnly = !State;
            this.txtamP13.ReadOnly = !State;

            this.txtATM.ReadOnly = !State;
            this.txtBasic.ReadOnly = !State;
            this.txtBirthDate.ReadOnly = !State;
            this.txtEndDate.ReadOnly = !State;
            this.txtEnterVisaDate.ReadOnly = !State;
            this.txtEnterVisaDate2.ReadOnly = !State;
            this.txtEnterVisaNo.ReadOnly = !State;
            this.txtEnterVisaNo2.ReadOnly = !State;
            this.txtExpDate1.ReadOnly = !State;
            this.txtExpDate2.ReadOnly = !State;
            this.txtExpDate3.ReadOnly = !State;
            this.txtExpDate4.ReadOnly = !State;
            this.txtExpDate5.ReadOnly = !State;
            this.txtExpDate6.ReadOnly = !State;
            this.txtExpDate7.ReadOnly = !State;
            this.txtExpDate8.ReadOnly = !State;
            this.txtExpDate9.ReadOnly = !State;
            this.txtExpDate10.ReadOnly = !State;

            this.txtIBan.ReadOnly = !State;
            this.txtIqamaEnd.ReadOnly = !State;
            this.txtIssueDate1.ReadOnly = !State;
            this.txtIssueDate2.ReadOnly = !State;
            this.txtIssueDate3.ReadOnly = !State;
            this.txtIssueDate4.ReadOnly = !State;
            this.txtIssueDate5.ReadOnly = !State;
            this.txtIssueDate6.ReadOnly = !State;
            this.txtIssueDate7.ReadOnly = !State;
            this.txtIssueDate8.ReadOnly = !State;
            this.txtIssueDate9.ReadOnly = !State;
            this.txtIssueDate10.ReadOnly = !State;

            this.txtJobNo.ReadOnly = !State;
            this.txtJoinDate.ReadOnly = !State;
            this.txtMobileNo.ReadOnly = !State;
            this.txtMobileNo2.ReadOnly = !State;
            this.txtMP10.ReadOnly = !State;
            this.txtMP11.ReadOnly = !State;
            this.txtMP12.ReadOnly = !State;
            this.txtMP13.ReadOnly = !State;
            //this.txtName.ReadOnly = !State;
            //this.txtName2.ReadOnly = !State;
            this.txtOffDays.ReadOnly = !State;
            this.txtOffice.ReadOnly = !State;
            this.txtOfficeManager.ReadOnly = !State;
            this.txtOfficeMobile.ReadOnly = !State;
            this.txtP10LDate.ReadOnly = !State;
            this.txtP11LDate.ReadOnly = !State;
            this.txtP12LDate.ReadOnly = !State;
            this.txtP13LDate.ReadOnly = !State;
            this.txtPaperNo1.ReadOnly = !State;
            this.txtPaperNo2.ReadOnly = !State;
            this.txtPaperNo3.ReadOnly = !State;
            this.txtPaperNo4.ReadOnly = !State;
            this.txtPaperNo5.ReadOnly = !State;
            this.txtPaperNo6.ReadOnly = !State;
            this.txtPaperNo7.ReadOnly = !State;
            this.txtPaperNo8.ReadOnly = !State;
            this.txtPaperNo9.ReadOnly = !State;
            this.txtPaperNo10.ReadOnly = !State;

            this.txtReason.ReadOnly = !State;
            this.txtRemark.ReadOnly = !State;
            this.txtReturnDate.ReadOnly = !State;
            this.txtTicketNo.ReadOnly = !State;
            this.txtTicketValue.ReadOnly = !State;
            this.txtVacDate.ReadOnly = !State;
            this.txtVacDays.ReadOnly = !State;
            this.txtVacRemain.ReadOnly = !State;
            this.txtVisaPlace.ReadOnly = !State;
            this.txtWorkerNo.ReadOnly = !State;

            this.ddlBank.Enabled = State;
            this.ddlBirthPlace.Enabled = State;
            this.ddlCertificate.Enabled = State;
            this.ddlJob.Enabled = State;
            this.ddlManag1.Enabled = State;
            this.ddlManag2.Enabled = State;
            this.ddlNational.Enabled = State;
            this.ddlPaperLoc1.Enabled = State;
            this.ddlPaperLoc2.Enabled = State;
            this.ddlPaperLoc3.Enabled = State;
            this.ddlPaperLoc4.Enabled = State;
            this.ddlPaperLoc5.Enabled = State;
            this.ddlPaperLoc6.Enabled = State;
            this.ddlPaperLoc7.Enabled = State;
            this.ddlPaperLoc8.Enabled = State;
            this.ddlPaperLoc9.Enabled = State;
            this.ddlPaperLoc10.Enabled = State;
            this.ddlReginal.Enabled = State;
            this.ddlSection.Enabled = State;
            this.ddlDep.Enabled = State;
            this.ddlShift.Enabled = State;
            this.ddlSponsor.Enabled = State;
            this.ddlUserName.Enabled = State;
            this.ddlUserName2.Enabled = State;
            this.FileUpload0.Enabled = State;
            this.FileUpload1.Enabled = State;
            this.FileUpload2.Enabled = State;
            this.FileUpload3.Enabled = State;
            this.FileUpload4.Enabled = State;
            this.FileUpload5.Enabled = State;
            this.FileUpload6.Enabled = State;
            this.FileUpload7.Enabled = State;
            this.FileUpload8.Enabled = State;
            this.FileUpload9.Enabled = State;
            this.FileUpload10.Enabled = State;
            this.FileUpload11.Enabled = State;

            this.BtnLoad0.Enabled = State;
            this.BtnLoad1.Enabled = State;
            this.BtnLoad2.Enabled = State;
            this.BtnLoad3.Enabled = State;
            this.BtnLoad4.Enabled = State;
            this.BtnLoad5.Enabled = State;
            this.BtnLoad6.Enabled = State;
            this.BtnLoad7.Enabled = State;
            this.BtnLoad8.Enabled = State;
            this.BtnLoad9.Enabled = State;
            this.BtnLoad10.Enabled = State;

            this.rdoContractType.Enabled = State;
            this.rdoState.Enabled = State;

            foreach (GridViewRow itm in grdAttach.Rows)
            {
                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                if (BtnDelete != null) BtnDelete.Visible = State;
            }
            FileUpload1.Enabled = State;
            BtnAttach.Enabled = State;

            if (!State && (((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("الحسابات") || ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("التأمين")))                
            {
                
                txtamP11.ReadOnly = false;
                txtMP11.ReadOnly = false;
                txtP11LDate.ReadOnly = false;

                txtamP10.ReadOnly = false;
                txtMP10.ReadOnly = false;                
                txtP10LDate.ReadOnly = false;

                txtamP12.ReadOnly = false;
                txtMP12.ReadOnly = false;
                txtP12LDate.ReadOnly = false;

                txtamP13.ReadOnly = false;
                txtMP13.ReadOnly = false;
                txtP13LDate.ReadOnly = false;

                BtnEdit.Visible = true;
            }
        }

        public void LoadddlData()
        {
            try
            {
                Codes myCode = new Codes();
                myCode.Branch = short.Parse(Session["Branch"].ToString());
                myCode.Ftype = 1;
                if (Cache["LastCodes" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCodes" + Session["CNN2"].ToString(), myCode.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                ddlNational.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                          where itm.Ftype == 1
                                          select itm).ToList();

                myCode.Ftype = 2;
                ddlJob.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                     where itm.Ftype == 2
                                     select itm).ToList();

                myCode.Ftype = 3;
                ddlSection.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                         where itm.Ftype == 3
                                         select itm).ToList();

                myCode.Ftype = 19;
                ddlDep.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                     where itm.Ftype == 19
                                     select itm).ToList();

                myCode.Ftype = 4;
                ddlCertificate.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                             where itm.Ftype == 4
                                             select itm).ToList();

                myCode.Ftype = 5;
                ddlPaperLoc1.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                           where itm.Ftype == 5
                                           select itm).ToList();
                ddlPaperLoc2.DataSource = ddlPaperLoc1.DataSource;
                ddlPaperLoc3.DataSource = ddlPaperLoc1.DataSource;
                ddlPaperLoc4.DataSource = ddlPaperLoc1.DataSource;
                ddlPaperLoc5.DataSource = ddlPaperLoc1.DataSource;
                ddlPaperLoc6.DataSource = ddlPaperLoc1.DataSource;
                ddlPaperLoc7.DataSource = ddlPaperLoc1.DataSource;
                ddlPaperLoc8.DataSource = ddlPaperLoc1.DataSource;
                ddlPaperLoc9.DataSource = ddlPaperLoc1.DataSource;
                ddlPaperLoc10.DataSource = ddlPaperLoc1.DataSource;

                myCode.Ftype = 6;
                ddlReginal.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                         where itm.Ftype == 6
                                         select itm).ToList();

                myCode.Ftype = 7;
                ddlBirthPlace.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                            where itm.Ftype == 7
                                            select itm).ToList();

                myCode.Ftype = 8;
                ddlBank.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                      where itm.Ftype == 8
                                      select itm).ToList();

                myCode.Ftype = 9;
                ddlSponsor.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                         where itm.Ftype == 9
                                         select itm).ToList();

                myCode.Ftype = 20;
                ddlShift.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                       where itm.Ftype == 20
                                       select itm).ToList();

                ddlUserName.DataTextField = "UserName";
                ddlUserName.DataValueField = "UserName";
                ddlUserName.DataSource = (List<TblUsers>)HttpRuntime.Cache["Users" + Session["CNN2"].ToString()];

                ddlUserName2.DataTextField = "UserName";
                ddlUserName2.DataValueField = "UserName";
                ddlUserName2.DataSource = (List<TblUsers>)HttpRuntime.Cache["Users" + Session["CNN2"].ToString()];

                ddlManag1.DataTextField = "UserName";
                ddlManag1.DataValueField = "UserName";
                ddlManag1.DataSource = (List<TblUsers>)HttpRuntime.Cache["Users" + Session["CNN2"].ToString()];

                ddlManag2.DataTextField = "UserName";
                ddlManag2.DataValueField = "UserName";
                ddlManag2.DataSource = (List<TblUsers>)HttpRuntime.Cache["Users" + Session["CNN2"].ToString()];

                ddlUserName.DataBind();
                ddlUserName2.DataBind();
                ddlManag1.DataBind();
                ddlManag2.DataBind();
                ddlNational.DataBind();
                ddlJob.DataBind();
                ddlSection.DataBind();
                ddlDep.DataBind();
                ddlCertificate.DataBind();
                ddlPaperLoc1.DataBind();
                ddlPaperLoc2.DataBind();
                ddlPaperLoc3.DataBind();
                ddlPaperLoc4.DataBind();
                ddlPaperLoc5.DataBind();
                ddlPaperLoc6.DataBind();
                ddlPaperLoc7.DataBind();
                ddlPaperLoc8.DataBind();
                ddlPaperLoc9.DataBind();
                ddlPaperLoc10.DataBind();
                ddlReginal.DataBind();
                ddlBirthPlace.DataBind();
                ddlBank.DataBind();
                ddlSponsor.DataBind();
                ddlShift.DataBind();

                ddlNational.Items.Insert(0, new ListItem("-----  أختر الجنسية  -----", "-1", true));
                ddlJob.Items.Insert(0, new ListItem("-----  أختر الوظيفة  -----", "-1", true));
                ddlSection.Items.Insert(0, new ListItem("-----  أختر القسم  -----", "-1", true));
                ddlDep.Items.Insert(0, new ListItem("-----  أختر الإدارة  -----", "-1", true));
                ddlCertificate.Items.Insert(0, new ListItem("--  أختر المؤهل الدراسي  --", "-1", true));
                ddlPaperLoc1.Items.Insert(0, new ListItem("  أختر محل الأصدار  ", "-1", true));
                ddlPaperLoc2.Items.Insert(0, new ListItem("  أختر محل الأصدار  ", "-1", true));
                ddlPaperLoc3.Items.Insert(0, new ListItem("  أختر محل الأصدار  ", "-1", true));
                ddlPaperLoc4.Items.Insert(0, new ListItem("  أختر محل الأصدار  ", "-1", true));
                ddlPaperLoc5.Items.Insert(0, new ListItem("  أختر محل الأصدار  ", "-1", true));
                ddlPaperLoc6.Items.Insert(0, new ListItem("  أختر محل الأصدار  ", "-1", true));
                ddlPaperLoc7.Items.Insert(0, new ListItem("  أختر محل الأصدار  ", "-1", true));
                ddlPaperLoc8.Items.Insert(0, new ListItem("  أختر محل الأصدار  ", "-1", true));
                ddlPaperLoc9.Items.Insert(0, new ListItem("  أختر محل الأصدار  ", "-1", true));
                ddlPaperLoc10.Items.Insert(0, new ListItem("  أختر محل الأصدار  ", "-1", true));
                ddlReginal.Items.Insert(0, new ListItem("-----  أختر الديانه  -----", "-1", true));
                ddlBirthPlace.Items.Insert(0, new ListItem("-----  أختر محل الميلاد  -----", "-1", true));
                ddlBank.Items.Insert(0, new ListItem("-----  أختر البنك  -----", "-1", true));
                ddlSponsor.Items.Insert(0, new ListItem("-----  أختر الكفيل  -----", "-1", true));
                ddlUserName.Items.Insert(0, new ListItem("--- أختر المستخدم ---", "-1", true));  // "جميع المستخدمين"
                ddlUserName2.Items.Insert(0, new ListItem("--- أختر المستخدم ---", "-1", true));  // "جميع المستخدمين"
                ddlManag1.Items.Insert(0, new ListItem("--- أختر المدير المباشر ---", "-1", true));  // "جميع المستخدمين"
                ddlManag2.Items.Insert(0, new ListItem("--- أختر نائب المدير ---", "-1", true));  // "جميع المستخدمين"
                ddlShift.Items.Insert(0, new ListItem("---  أختر توقيت الحضور و الانصراف  ---", "-1", true));
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
            try
            {
                NewMode();
                txtReason.Text = "";
                ImgPhoto.Src = "images/123.jpg";
                ddlBank.SelectedIndex = 0;
                ddlBirthPlace.SelectedIndex = 0;
                ddlCertificate.SelectedIndex = 0;
                ddlJob.SelectedIndex = 0;
                ddlNational.SelectedIndex = 0;
                ddlPaperLoc1.SelectedIndex = 0;
                ddlPaperLoc10.SelectedIndex = 0;
                ddlPaperLoc2.SelectedIndex = 0;
                ddlPaperLoc3.SelectedIndex = 0;
                ddlPaperLoc4.SelectedIndex = 0;
                ddlPaperLoc5.SelectedIndex = 0;
                ddlPaperLoc6.SelectedIndex = 0;
                ddlPaperLoc7.SelectedIndex = 0;
                ddlPaperLoc8.SelectedIndex = 0;
                ddlPaperLoc9.SelectedIndex = 0;
                ddlReginal.SelectedIndex = 0;
                ddlSection.SelectedIndex = 0;
                ddlDep.SelectedIndex = 0;
                ddlSponsor.SelectedIndex = 0;
                ddlUserName.SelectedIndex = 0;
                ddlUserName2.SelectedIndex = 0;
                ddlManag1.SelectedIndex = 0;
                ddlManag2.SelectedIndex = 0;
                ddlShift.SelectedIndex = 0;
                txtVacRemain.Text = "";
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
                txtATM.Text = "";
                txtBasic.Text = "";
                txtBirthDate.Text = "";
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
                txtDed15.Text = "";
                txtEmpCode.Text = "";
                txtEndDate.Text = "";
                txtEnterVisaDate.Text = "";
                txtEnterVisaDate2.Text = "";
                txtEnterVisaNo.Text = "";
                txtEnterVisaNo2.Text = "";
                txtExpDate1.Text = "";
                txtExpDate10.Text = "";
                txtExpDate2.Text = "";
                txtExpDate3.Text = "";
                txtExpDate4.Text = "";
                txtExpDate5.Text = "";
                txtExpDate6.Text = "";
                txtExpDate7.Text = "";
                txtExpDate8.Text = "";
                txtExpDate9.Text = "";
                txtIBan.Text = "";
                txtIqamaEnd.Text = "";
                txtIssueDate1.Text = "";
                txtIssueDate10.Text = "";
                txtIssueDate2.Text = "";
                txtIssueDate3.Text = "";
                txtIssueDate4.Text = "";
                txtIssueDate5.Text = "";
                txtIssueDate6.Text = "";
                txtIssueDate7.Text = "";
                txtIssueDate8.Text = "";
                txtIssueDate9.Text = "";
                txtJobNo.Text = "";
                txtJoinDate.Text = "";
                txtMobileNo.Text = "";
                txtMobileNo2.Text = "";
                txtName.Text = "";
                txtName2.Text = "";
                txtOffice.Text = "";
                txtOfficeManager.Text = "";
                txtOfficeMobile.Text = "";
                txtPaperNo1.Text = "";
                txtPaperNo10.Text = "";
                txtPaperNo2.Text = "";
                txtPaperNo3.Text = "";
                txtPaperNo4.Text = "";
                txtPaperNo5.Text = "";
                txtPaperNo6.Text = "";
                txtPaperNo7.Text = "";
                txtPaperNo8.Text = "";
                txtPaperNo9.Text = "";
                txtRemark.Text = "";
                txtReturnDate.Text = "";
                txtVisaPlace.Text = "";
                txtVacDate.Text = "";
                txtWorkerNo.Text = "";
                BtnLoad0.ToolTip = "";
                BtnLoad1.ToolTip = "";
                BtnLoad2.ToolTip = "";
                BtnLoad3.ToolTip = "";
                BtnLoad4.ToolTip = "";
                BtnLoad5.ToolTip = "";
                BtnLoad6.ToolTip = "";
                BtnLoad7.ToolTip = "";
                BtnLoad8.ToolTip = "";
                BtnLoad9.ToolTip = "";
                BtnLoad10.ToolTip = "";
                LblCodesResult.Text = "";
                rdoContractType.SelectedIndex = 0;
                txtTicketNo.Text = "";
                txtVacDays.Text = "";
                BtnView1.Attributes.Remove("onclick");
                BtnView2.Attributes.Remove("onclick");
                BtnView3.Attributes.Remove("onclick");
                BtnView4.Attributes.Remove("onclick");
                BtnView5.Attributes.Remove("onclick");
                BtnView6.Attributes.Remove("onclick");
                BtnView7.Attributes.Remove("onclick");
                BtnView8.Attributes.Remove("onclick");
                BtnView9.Attributes.Remove("onclick");
                BtnView10.Attributes.Remove("onclick");
                rdoState.SelectedValue = "0";
                txtTAdd.Text = "";
                txtNet.Text = "";
                txtTDed.Text = "";
                txtOffDays.Text = "";
                txtTicketValue.Text = "";
                //txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                //txtUserName.Text = Session["FullUser"].ToString();
                //txtUserDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                SEmp myEmp = new SEmp();
                int? i = myEmp.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if(i == null) i = 0;
                txtEmpCode.Text = (i + 1).ToString();
                LoadAttachData();

                txtMP10.Text = "";
                txtMP11.Text = "";
                txtMP12.Text = "";
                txtMP13.Text = "";

                txtamP10.Text = "";
                txtamP11.Text = "";
                txtamP12.Text = "";
                txtamP13.Text = "";

                txtP10LDate.Text = "";
                txtP11LDate.Text = "";
                txtP12LDate.Text = "";
                txtP13LDate.Text = "";
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

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    SEmp myEmp = new SEmp();
                    myEmp.EmpCode = int.Parse(txtEmpCode.Text);
                    if (myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) != null)                        
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم ملف الموظف مدخل من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>','');", true);
                    }
                    else
                    {
                        myEmp.JobNo = txtJobNo.Text;
                        if (myEmp.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault() != null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الرقم الوظيفي مدخل من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>');", true);
                            BtnClear_Click(sender, e);
                        }                               
                        PutEmp(myEmp);
                        if (myEmp.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                if (Cache["EmpAlert2" + Session["CNN2"].ToString()] != null) Cache.Remove("EmpAlert2" + Session["CNN2"].ToString());
                                Cache.Remove("Emps" + Session["CNN2"].ToString());
                                Cache.Insert("Emps" + Session["CNN2"].ToString(), myEmp.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.FormName = "البيانات الاساسية";
                                UserTran.FormAction = "اضافة";
                                UserTran.Description = "اضافة بيانات موظف رقم " + txtEmpCode.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }

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

        public void PutEmp(SEmp myEmp)
        {
            try
            {
                myEmp.EmpCode = int.Parse(txtEmpCode.Text);
                myEmp.Status = short.Parse(rdoState.SelectedValue);
                if (txtAdd01.Text == "") txtAdd01.Text = "0.00";
                if (txtAdd02.Text == "") txtAdd02.Text = "0.00";
                if (txtAdd03.Text == "") txtAdd03.Text = "0.00";
                if (txtAdd04.Text == "") txtAdd04.Text = "0.00";
                if (txtAdd05.Text == "") txtAdd05.Text = "0.00";
                if (txtAdd06.Text == "") txtAdd06.Text = "0.00";
                if (txtAdd07.Text == "") txtAdd07.Text = "0.00";
                if (txtAdd08.Text == "") txtAdd08.Text = "0.00";
                if (txtAdd09.Text == "") txtAdd09.Text = "0.00";
                if (txtAdd10.Text == "") txtAdd10.Text = "0.00";
                if (txtAdd11.Text == "") txtAdd11.Text = "0.00";
                if (txtAdd12.Text == "") txtAdd12.Text = "0.00";
                if (txtAdd13.Text == "") txtAdd13.Text = "0.00";
                if (txtAdd14.Text == "") txtAdd14.Text = "0.00";
                if (txtAdd15.Text == "") txtAdd15.Text = "0.00";
                if (txtDed01.Text == "") txtDed01.Text = "0.00";
                if (txtDed02.Text == "") txtDed02.Text = "0.00";
                if (txtDed03.Text == "") txtDed03.Text = "0.00";
                if (txtDed04.Text == "") txtDed04.Text = "0.00";
                if (txtDed05.Text == "") txtDed05.Text = "0.00";
                if (txtDed06.Text == "") txtDed06.Text = "0.00";
                if (txtDed07.Text == "") txtDed07.Text = "0.00";
                if (txtDed08.Text == "") txtDed08.Text = "0.00";
                if (txtDed09.Text == "") txtDed09.Text = "0.00";
                if (txtDed10.Text == "") txtDed10.Text = "0.00";
                if (txtDed11.Text == "") txtDed11.Text = "0.00";
                if (txtDed12.Text == "") txtDed12.Text = "0.00";
                if (txtDed13.Text == "") txtDed13.Text = "0.00";
                if (txtDed14.Text == "") txtDed14.Text = "0.00";
                if (txtDed15.Text == "") txtDed15.Text = "0.00";
                if (txtBasic.Text == "") txtBasic.Text = "0.00";
                if (txtVacRemain.Text == "") txtVacRemain.Text = "0.00";

                if (txtTicketNo.Text == "") txtTicketNo.Text = "0";
                if (txtVacDays.Text == "") txtVacDays.Text = "0";

                myEmp.Name = txtName.Text;
                myEmp.Name2 = txtName2.Text;
                myEmp.Add01 = moh.StrToDouble(txtAdd01.Text);
                myEmp.Add02 = moh.StrToDouble(txtAdd02.Text);
                myEmp.Add03 = moh.StrToDouble(txtAdd03.Text);
                myEmp.Add04 = moh.StrToDouble(txtAdd04.Text);
                myEmp.Add05 = moh.StrToDouble(txtAdd05.Text);
                myEmp.Add06 = moh.StrToDouble(txtAdd06.Text);
                myEmp.Add07 = moh.StrToDouble(txtAdd07.Text);
                myEmp.Add08 = moh.StrToDouble(txtAdd08.Text);
                myEmp.Add09 = moh.StrToDouble(txtAdd09.Text);
                myEmp.Add10 = moh.StrToDouble(txtAdd10.Text);
                myEmp.Add11 = moh.StrToDouble(txtAdd11.Text);
                myEmp.Add12 = moh.StrToDouble(txtAdd12.Text);
                myEmp.Add13 = moh.StrToDouble(txtAdd13.Text);
                myEmp.Add14 = moh.StrToDouble(txtAdd14.Text);
                myEmp.Add15 = moh.StrToDouble(txtAdd15.Text);
                myEmp.Ded01 = moh.StrToDouble(txtDed01.Text);
                myEmp.Ded02 = moh.StrToDouble(txtDed02.Text);
                myEmp.Ded03 = moh.StrToDouble(txtDed03.Text);
                myEmp.Ded04 = moh.StrToDouble(txtDed04.Text);
                myEmp.Ded05 = moh.StrToDouble(txtDed05.Text);
                myEmp.Ded06 = moh.StrToDouble(txtDed06.Text);
                myEmp.Ded07 = moh.StrToDouble(txtDed07.Text);
                myEmp.Ded08 = moh.StrToDouble(txtDed08.Text);
                myEmp.Ded09 = moh.StrToDouble(txtDed09.Text);
                myEmp.Ded10 = moh.StrToDouble(txtDed10.Text);
                myEmp.Ded11 = moh.StrToDouble(txtDed11.Text);
                myEmp.Ded12 = moh.StrToDouble(txtDed12.Text);
                myEmp.Ded13 = moh.StrToDouble(txtDed13.Text);
                myEmp.Ded14 = moh.StrToDouble(txtDed14.Text);
                myEmp.Ded15 = moh.StrToDouble(txtDed15.Text);
                myEmp.ATM = txtATM.Text;

                myEmp.Bank = int.Parse(ddlBank.SelectedValue);
                myEmp.Basic = moh.StrToDouble(txtBasic.Text);
                myEmp.BirthDate = txtBirthDate.Text;
                myEmp.BirthPlace = int.Parse(ddlBirthPlace.SelectedValue);
                myEmp.Certificate = int.Parse(ddlCertificate.SelectedValue);
                myEmp.EnterVisaDate = txtEnterVisaDate.Text;
                myEmp.EnterVisaDate2 = txtEnterVisaDate2.Text;
                myEmp.EnterVisaNo = txtEnterVisaNo.Text;
                myEmp.EnterVisaNo2 = txtEnterVisaNo2.Text;
                myEmp.EnterVisaPlace = txtVisaPlace.Text;
                myEmp.ExpDate1 = txtExpDate1.Text;
                myEmp.ExpDate10 = txtExpDate10.Text;
                myEmp.ExpDate2 = txtExpDate2.Text;
                myEmp.ExpDate3 = txtExpDate3.Text;
                myEmp.ExpDate4 = txtExpDate4.Text;
                myEmp.ExpDate5 = txtExpDate5.Text;
                myEmp.ExpDate6 = txtExpDate6.Text;
                myEmp.ExpDate7 = txtExpDate7.Text;
                myEmp.ExpDate8 = txtExpDate8.Text;
                myEmp.ExpDate9 = txtExpDate9.Text;
                myEmp.Photo = BtnLoad0.ToolTip;
                myEmp.FileName1 = BtnLoad1.ToolTip;
                myEmp.FileName2 = BtnLoad2.ToolTip;
                myEmp.FileName3 = BtnLoad3.ToolTip;
                myEmp.FileName4 = BtnLoad4.ToolTip;
                myEmp.FileName5 = BtnLoad5.ToolTip;
                myEmp.FileName6 = BtnLoad6.ToolTip;
                myEmp.FileName7 = BtnLoad7.ToolTip;
                myEmp.FileName8 = BtnLoad8.ToolTip;
                myEmp.FileName9 = BtnLoad9.ToolTip;
                myEmp.FileName10 = BtnLoad10.ToolTip;
                myEmp.IBan = txtIBan.Text;
                myEmp.IqamaEnd = txtIqamaEnd.Text;
                myEmp.IssueDate1 = txtIssueDate1.Text;
                myEmp.IssueDate2 = txtIssueDate2.Text;
                myEmp.IssueDate3 = txtIssueDate3.Text;
                myEmp.IssueDate4 = txtIssueDate4.Text;
                myEmp.IssueDate5 = txtIssueDate5.Text;
                myEmp.IssueDate6 = txtIssueDate6.Text;
                myEmp.IssueDate7 = txtIssueDate7.Text;
                myEmp.IssueDate8 = txtIssueDate8.Text;
                myEmp.IssueDate9 = txtIssueDate9.Text;
                myEmp.IssueDate10 = txtIssueDate10.Text;
                myEmp.Job = int.Parse(ddlJob.SelectedValue);
                myEmp.JobNo = txtJobNo.Text;
                myEmp.JoinDate = txtJoinDate.Text;
                myEmp.MobileNo = txtMobileNo.Text;
                myEmp.MobileNo2 = txtMobileNo2.Text;
                myEmp.Nat = int.Parse(ddlNational.SelectedValue);
                myEmp.Office = txtOffice.Text;
                myEmp.OfficeManager = txtOfficeManager.Text;
                myEmp.OfficeMobile = txtOfficeMobile.Text;
                myEmp.PaperLoc1 = int.Parse(ddlPaperLoc1.SelectedValue);
                myEmp.PaperLoc2 = int.Parse(ddlPaperLoc2.SelectedValue);
                myEmp.PaperLoc3 = int.Parse(ddlPaperLoc3.SelectedValue);
                myEmp.PaperLoc4 = int.Parse(ddlPaperLoc4.SelectedValue);
                myEmp.PaperLoc5 = int.Parse(ddlPaperLoc5.SelectedValue);
                myEmp.PaperLoc6 = int.Parse(ddlPaperLoc6.SelectedValue);
                myEmp.PaperLoc7 = int.Parse(ddlPaperLoc7.SelectedValue);
                myEmp.PaperLoc8 = int.Parse(ddlPaperLoc8.SelectedValue);
                myEmp.PaperLoc9 = int.Parse(ddlPaperLoc9.SelectedValue);
                myEmp.PaperLoc10 = int.Parse(ddlPaperLoc10.SelectedValue);
                myEmp.PaperNo1 = txtPaperNo1.Text;
                myEmp.PaperNo2 = txtPaperNo2.Text;
                myEmp.PaperNo3 = txtPaperNo3.Text;
                myEmp.PaperNo4 = txtPaperNo4.Text;
                myEmp.PaperNo5 = txtPaperNo5.Text;
                myEmp.PaperNo6 = txtPaperNo6.Text;
                myEmp.PaperNo7 = txtPaperNo7.Text;
                myEmp.PaperNo8 = txtPaperNo8.Text;
                myEmp.PaperNo9 = txtPaperNo9.Text;
                myEmp.PaperNo10 = txtPaperNo10.Text;
                myEmp.Reginal = int.Parse(ddlReginal.SelectedValue);
                myEmp.Remark = txtRemark.Text;
                myEmp.ReturnDate = txtReturnDate.Text;
                myEmp.Section = int.Parse(ddlSection.SelectedValue);
                myEmp.Dep = int.Parse(ddlDep.SelectedValue);
                myEmp.Sponsor = int.Parse(ddlSponsor.SelectedValue);
                myEmp.VacDate = txtVacDate.Text;
                myEmp.WorkerNo = txtWorkerNo.Text;
                myEmp.ContractType = (short)rdoContractType.SelectedIndex;
                if (txtTicketNo.Text == "") txtTicketNo.Text = "0";
                myEmp.TicketNo = short.Parse(txtTicketNo.Text);
                if (txtVacDays.Text == "") txtVacDays.Text = "0";
                myEmp.VacDays = short.Parse(txtVacDays.Text);
                if (txtTicketValue.Text == "") txtTicketValue.Text = "0";
                myEmp.TicketValue = double.Parse(txtTicketValue.Text);
                if (txtOffDays.Text == "") txtOffDays.Text = "0";
                myEmp.OffDays = int.Parse(txtOffDays.Text);
                myEmp.EndDate = txtEndDate.Text;
                myEmp.UserName = ddlUserName.SelectedValue;
                myEmp.UserName2 = ddlUserName2.SelectedValue;
                myEmp.Manag1 = ddlManag1.SelectedValue;
                myEmp.Manag2 = ddlManag2.SelectedValue;
                myEmp.Shift = int.Parse(ddlShift.SelectedValue);
                myEmp.P10am = moh.StrToDouble(txtamP10.Text);
                myEmp.P11am = moh.StrToDouble(txtamP11.Text);
                myEmp.P12am = moh.StrToDouble(txtamP12.Text);
                myEmp.P13am = moh.StrToDouble(txtamP13.Text);
                myEmp.P10m = moh.StrToShort(txtMP10.Text);
                myEmp.P11m = moh.StrToShort(txtMP11.Text);
                myEmp.P12m = moh.StrToShort(txtMP12.Text);
                myEmp.P13m = moh.StrToShort(txtMP13.Text);
                myEmp.P10LDate = txtP10LDate.Text;
                myEmp.P11LDate = txtP11LDate.Text;
                myEmp.P12LDate = txtP12LDate.Text;
                myEmp.P13LDate = txtP13LDate.Text;
                myEmp.VacRemain = moh.StrToShort(txtVacRemain.Text);
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

        public void getEmp(SEmp myEmp)
        {
            try
            {
                txtName.Text = myEmp.Name;
                txtName2.Text = myEmp.Name2;
                rdoState.SelectedValue = myEmp.Status.ToString();
                txtAdd01.Text = string.Format("{0:N2}", (double)myEmp.Add01);
                txtAdd02.Text = string.Format("{0:N2}", (double)myEmp.Add02);
                txtAdd03.Text = string.Format("{0:N2}", (double)myEmp.Add03);
                txtAdd04.Text = string.Format("{0:N2}", (double)myEmp.Add04);
                txtAdd05.Text = string.Format("{0:N2}", (double)myEmp.Add05);
                txtAdd06.Text = string.Format("{0:N2}", (double)myEmp.Add06);
                txtAdd07.Text = string.Format("{0:N2}", (double)myEmp.Add07);
                txtAdd08.Text = string.Format("{0:N2}", (double)myEmp.Add08);
                txtAdd09.Text = string.Format("{0:N2}", (double)myEmp.Add09);
                txtAdd10.Text = string.Format("{0:N2}", (double)myEmp.Add10);
                txtAdd11.Text = string.Format("{0:N2}", (double)myEmp.Add11);
                txtAdd12.Text = string.Format("{0:N2}", (double)myEmp.Add12);
                txtAdd13.Text = string.Format("{0:N2}", (double)myEmp.Add13);
                txtAdd14.Text = string.Format("{0:N2}", (double)myEmp.Add14);
                txtAdd15.Text = string.Format("{0:N2}", (double)myEmp.Add15);
                txtDed01.Text = string.Format("{0:N2}", (double)myEmp.Ded01);
                txtDed02.Text = string.Format("{0:N2}", (double)myEmp.Ded02);
                txtDed03.Text = string.Format("{0:N2}", (double)myEmp.Ded03);
                txtDed04.Text = string.Format("{0:N2}", (double)myEmp.Ded04);
                txtDed05.Text = string.Format("{0:N2}", (double)myEmp.Ded05);
                txtDed06.Text = string.Format("{0:N2}", (double)myEmp.Ded06);
                txtDed07.Text = string.Format("{0:N2}", (double)myEmp.Ded07);
                txtDed08.Text = string.Format("{0:N2}", (double)myEmp.Ded08);
                txtDed09.Text = string.Format("{0:N2}", (double)myEmp.Ded09);
                txtDed10.Text = string.Format("{0:N2}", (double)myEmp.Ded10);
                txtDed11.Text = string.Format("{0:N2}", (double)myEmp.Ded11);
                txtDed12.Text = string.Format("{0:N2}", (double)myEmp.Ded12);
                txtDed13.Text = string.Format("{0:N2}", (double)myEmp.Ded13);
                txtDed14.Text = string.Format("{0:N2}", (double)myEmp.Ded14);
                txtDed15.Text = string.Format("{0:N2}", (double)myEmp.Ded15);
                txtATM.Text = myEmp.ATM;
                ddlBank.SelectedValue = myEmp.Bank.ToString();
                txtBasic.Text = string.Format("{0:N2}", (double)myEmp.Basic);
                txtBirthDate.Text = myEmp.BirthDate;
                ddlBirthPlace.SelectedValue = myEmp.BirthPlace.ToString();
                ddlCertificate.SelectedValue = myEmp.Certificate.ToString();
                txtEnterVisaDate.Text = myEmp.EnterVisaDate;
                txtEnterVisaDate2.Text = myEmp.EnterVisaDate2;
                txtEnterVisaNo.Text = myEmp.EnterVisaNo;
                txtEnterVisaNo2.Text = myEmp.EnterVisaNo2;
                txtVisaPlace.Text = myEmp.EnterVisaPlace;
                txtExpDate1.Text = myEmp.ExpDate1;
                txtExpDate10.Text = myEmp.ExpDate10;
                txtExpDate2.Text = myEmp.ExpDate2;
                txtExpDate3.Text = myEmp.ExpDate3;
                txtExpDate4.Text = myEmp.ExpDate4;
                txtExpDate5.Text = myEmp.ExpDate5;
                txtExpDate6.Text = myEmp.ExpDate6;
                txtExpDate7.Text = myEmp.ExpDate7;
                txtExpDate8.Text = myEmp.ExpDate8;
                txtExpDate9.Text = myEmp.ExpDate9;
                BtnLoad1.ToolTip = myEmp.FileName1;
                ddlShift.SelectedValue = myEmp.Shift.ToString();
                ddlUserName.SelectedValue = (string.IsNullOrEmpty(myEmp.UserName) ? "-1" : myEmp.UserName);
                ddlUserName2.SelectedValue = (string.IsNullOrEmpty(myEmp.UserName2) ? "-1" : myEmp.UserName2);
                ddlManag1.SelectedValue = (string.IsNullOrEmpty(myEmp.Manag1) ? "-1" : myEmp.Manag1);
                ddlManag2.SelectedValue = (string.IsNullOrEmpty(myEmp.Manag2) ? "-1" : myEmp.Manag2);
                if (!string.IsNullOrEmpty(myEmp.Photo))
                {
                    BtnLoad0.ToolTip = myEmp.Photo;
                    string url = ImageUrl + myEmp.Photo;
                    ImgPhoto.Src = url;
                }
                else
                {
                    ImgPhoto.Src = "images/123.jpg";
                    BtnLoad0.ToolTip = "";
                }
                rdoContractType.SelectedIndex = (int)myEmp.ContractType;
                txtTicketNo.Text = myEmp.TicketNo.ToString();
                txtVacDays.Text = myEmp.VacDays.ToString();

                    if (!string.IsNullOrEmpty(myEmp.FileName1))
                    {
                        string  url = ImageUrl + myEmp.FileName1;
                        BtnView1.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                        BtnView1.Attributes.Add("onclick", "window.open('" + url + "')");
                    }
                    else BtnView1.Attributes.Remove("onclick");

                    BtnLoad2.ToolTip = myEmp.FileName2;
                    if (!string.IsNullOrEmpty(myEmp.FileName2))
                    {
                        string  url = ImageUrl + myEmp.FileName2;
                        BtnView2.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                        BtnView2.Attributes.Add("onclick", "window.open('" + url + "')");
                    }
                    else BtnView2.Attributes.Remove("onclick");

                    BtnLoad3.ToolTip = myEmp.FileName3;
                    if (!string.IsNullOrEmpty(myEmp.FileName3))
                    {
                        string  url = ImageUrl + myEmp.FileName3;
                        BtnView3.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                        BtnView3.Attributes.Add("onclick", "window.open('" + url + "')");
                    }
                    else BtnView3.Attributes.Remove("onclick");

                    BtnLoad4.ToolTip = myEmp.FileName4;
                    if (!string.IsNullOrEmpty(myEmp.FileName4))
                    {
                        string  url = ImageUrl + myEmp.FileName4;
                        BtnView4.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                        BtnView4.Attributes.Add("onclick", "window.open('" + url + "')");
                    }
                    else BtnView4.Attributes.Remove("onclick");

                    BtnLoad5.ToolTip = myEmp.FileName5;
                    if (!string.IsNullOrEmpty(myEmp.FileName5))
                    {
                        string  url = ImageUrl + myEmp.FileName5;
                        BtnView5.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                        BtnView5.Attributes.Add("onclick", "window.open('" + url + "')");
                    }
                    else BtnView5.Attributes.Remove("onclick");

                    BtnLoad6.ToolTip = myEmp.FileName6;
                    if (!string.IsNullOrEmpty(myEmp.FileName6))
                    {
                        string  url = ImageUrl + myEmp.FileName6;
                        BtnView6.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                        BtnView6.Attributes.Add("onclick", "window.open('" + url + "')");
                    }
                    else BtnView6.Attributes.Remove("onclick");

                    BtnLoad7.ToolTip = myEmp.FileName7;
                    if (!string.IsNullOrEmpty(myEmp.FileName7))
                    {
                        string  url = ImageUrl + myEmp.FileName7;
                        BtnView7.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                        BtnView7.Attributes.Add("onclick", "window.open('" + url + "')");
                    }
                    else BtnView7.Attributes.Remove("onclick");

                    BtnLoad8.ToolTip = myEmp.FileName8;
                    if (!string.IsNullOrEmpty(myEmp.FileName8))
                    {
                        string  url = ImageUrl + myEmp.FileName8;
                        BtnView8.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                        BtnView8.Attributes.Add("onclick", "window.open('" + url + "')");
                    }
                    else BtnView8.Attributes.Remove("onclick");

                    BtnLoad9.ToolTip = myEmp.FileName9;
                    if (!string.IsNullOrEmpty(myEmp.FileName9))
                    {
                        string  url = ImageUrl + myEmp.FileName9;
                        BtnView9.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                        BtnView9.Attributes.Add("onclick", "window.open('" + url + "')");
                    }
                    else BtnView9.Attributes.Remove("onclick");

                    BtnLoad10.ToolTip = myEmp.FileName10;
                    if (!string.IsNullOrEmpty(myEmp.FileName10))
                    {
                        string  url = ImageUrl + myEmp.FileName10;
                        BtnView10.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                        BtnView10.Attributes.Add("onclick", "window.open('" + url + "')");
                    }
                    else BtnView10.Attributes.Remove("onclick");

                txtIBan.Text = myEmp.IBan;
                txtIqamaEnd.Text = myEmp.IqamaEnd;
                txtIssueDate1.Text = myEmp.IssueDate1;
                txtIssueDate2.Text = myEmp.IssueDate2;
                txtIssueDate3.Text = myEmp.IssueDate3;
                txtIssueDate4.Text = myEmp.IssueDate4;
                txtIssueDate5.Text = myEmp.IssueDate5;
                txtIssueDate6.Text = myEmp.IssueDate6;
                txtIssueDate7.Text = myEmp.IssueDate7;
                txtIssueDate8.Text = myEmp.IssueDate8;
                txtIssueDate9.Text = myEmp.IssueDate9;
                txtIssueDate10.Text = myEmp.IssueDate10;
                ddlJob.SelectedValue = myEmp.Job.ToString();
                txtJobNo.Text = myEmp.JobNo;
                txtJoinDate.Text = myEmp.JoinDate;
                txtMobileNo.Text = myEmp.MobileNo;
                txtMobileNo2.Text = myEmp.MobileNo2;
                ddlNational.SelectedValue = myEmp.Nat.ToString();
                txtOffice.Text = myEmp.Office;
                txtOfficeManager.Text = myEmp.OfficeManager;
                txtOfficeMobile.Text = myEmp.OfficeMobile;
                ddlPaperLoc1.SelectedValue = myEmp.PaperLoc1.ToString();
                ddlPaperLoc2.SelectedValue = myEmp.PaperLoc2.ToString();
                ddlPaperLoc3.SelectedValue = myEmp.PaperLoc3.ToString();
                ddlPaperLoc4.SelectedValue = myEmp.PaperLoc4.ToString();
                ddlPaperLoc5.SelectedValue = myEmp.PaperLoc5.ToString();
                ddlPaperLoc6.SelectedValue = myEmp.PaperLoc6.ToString();
                ddlPaperLoc7.SelectedValue = myEmp.PaperLoc7.ToString();
                ddlPaperLoc8.SelectedValue = myEmp.PaperLoc8.ToString();
                ddlPaperLoc9.SelectedValue = myEmp.PaperLoc9.ToString();
                ddlPaperLoc10.SelectedValue = myEmp.PaperLoc10.ToString();
                txtPaperNo1.Text = myEmp.PaperNo1;
                txtPaperNo2.Text = myEmp.PaperNo2;
                txtPaperNo3.Text = myEmp.PaperNo3;
                txtPaperNo4.Text = myEmp.PaperNo4;
                txtPaperNo5.Text = myEmp.PaperNo5;
                txtPaperNo6.Text = myEmp.PaperNo6;
                txtPaperNo7.Text = myEmp.PaperNo7;
                txtPaperNo8.Text = myEmp.PaperNo8;
                txtPaperNo9.Text = myEmp.PaperNo9;
                txtPaperNo10.Text = myEmp.PaperNo10;
                ddlReginal.SelectedValue = myEmp.Reginal.ToString();
                txtRemark.Text = myEmp.Remark;
                txtReturnDate.Text = myEmp.ReturnDate;
                ddlSection.SelectedValue = myEmp.Section.ToString();
                ddlDep.SelectedValue = myEmp.Dep.ToString();
                ddlSponsor.SelectedValue = myEmp.Sponsor.ToString();
                txtVacDate.Text = myEmp.VacDate;
                txtWorkerNo.Text = myEmp.WorkerNo;
                txtTicketValue.Text = string.Format("{0:N2}", (double)myEmp.TicketValue);
                txtOffDays.Text = myEmp.OffDays.ToString();
                txtEndDate.Text = myEmp.EndDate;
                txtamP10.Text = (myEmp.P10am == 0 ? "" : myEmp.P10am.ToString());
                txtamP11.Text = (myEmp.P11am == 0 ? "" : myEmp.P11am.ToString());
                txtamP12.Text = (myEmp.P12am == 0 ? "" : myEmp.P12am.ToString());
                txtamP13.Text = (myEmp.P13am == 0 ? "" : myEmp.P13am.ToString());
                txtMP10.Text = (myEmp.P10m == 0 ? "" : myEmp.P10m.ToString());
                txtMP11.Text = (myEmp.P11m == 0 ? "" : myEmp.P11m.ToString());
                txtMP12.Text = (myEmp.P12m == 0 ? "" : myEmp.P12m.ToString());
                txtMP13.Text = (myEmp.P13m == 0 ? "" : myEmp.P13m.ToString());
                txtP10LDate.Text = myEmp.P10LDate;
                txtP11LDate.Text = myEmp.P11LDate;
                txtP12LDate.Text = myEmp.P12LDate;
                txtP13LDate.Text = myEmp.P13LDate;
                txtVacRemain.Text = myEmp.VacRemain.ToString();
                TotSum();
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
                    SEmp myEmp = new SEmp();
                    myEmp.JobNo = txtJobNo.Text;
                    bool found = false;
                    foreach (SEmp itm in myEmp.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        if (itm.EmpCode.ToString() != txtEmpCode.Text)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الرقم الوظيفي مكرر";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>');", true);
                        txtJobNo.Focus();
                        return;
                    }
                    else
                    {
                        myEmp = new SEmp();
                        myEmp.EmpCode = int.Parse(txtEmpCode.Text);
                        myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myEmp == null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم ملف الموظف غير مدرج من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>');", true);
                        }
                        else
                        {

                            PutEmp(myEmp);
                            if (myEmp.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                if (Cache["EmpAlert2" + Session["CNN2"].ToString()] != null) Cache.Remove("EmpAlert2" + Session["CNN2"].ToString());
                                Cache.Remove("Emps" + Session["CNN2"].ToString());
                                Cache.Insert("Emps" + Session["CNN2"].ToString(), myEmp.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                                {
                                    Transactions UserTran = new Transactions();
                                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                    UserTran.UserName = Session["CurrentUser"].ToString();
                                    UserTran.FormName = "البيانات الاساسية";
                                    UserTran.FormAction = "تعديل";
                                    UserTran.Description = "تعديل بيانات الموظف رقم " + txtEmpCode.Text;
                                    UserTran.Reason = txtReason.Text;
                                    UserTran.IP = IPNetworking.GetIP4Address();
                                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                    txtReason.Text = "";
                                }

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
                    SEmp myEmp = new SEmp();
                    myEmp.EmpCode = int.Parse(txtEmpCode.Text);
                    myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if ( myEmp == null)                        
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم ملف الموظف غير مدرج من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>');", true);
                    }
                    else
                        {
                        if (myEmp.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (Cache["EmpAlert2" + Session["CNN2"].ToString()] != null) Cache.Remove("EmpAlert2" + Session["CNN2"].ToString());
                            Cache.Remove("Emps" + Session["CNN2"].ToString());
                            Cache.Insert("Emps" + Session["CNN2"].ToString(), myEmp.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.FormName = "البيانات الاساسية";
                                UserTran.FormAction = "الغاء";
                                UserTran.Description = "الغاء بيانات الموظف رقم " + txtEmpCode.Text;
                                UserTran.Reason = txtReason.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }
                            txtReason.Text = "";

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
                int i;                
                if (txtEmpCode.Attributes["Value"] != "" && Int32.TryParse(txtEmpCode.Attributes["Value"], out i)) txtEmpCode.Text = txtEmpCode.Attributes["Value"]; 
                if (txtEmpCode.Text != "" && Int32.TryParse(txtEmpCode.Text, out i))
                {
                    SEmp myEmp = new SEmp();
                    myEmp.EmpCode = int.Parse(txtEmpCode.Text);
                    myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myEmp == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم ملف الموظف غير مدرج من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>');", true);
                        BtnClear_Click(sender, e);
                    }
                    else
                    {
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormName = "البيانات الاساسية";
                            UserTran.FormAction = "عرض";
                            UserTran.Description = "عرض بيانات الموظف رقم " + txtEmpCode.Text;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }

                        EditMode();
                        getEmp(myEmp);
                        LoadAttachData();
                        LoadHistoryTran();
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

        protected void BtnFind_Click(object sender, ImageClickEventArgs e)
        {
            BtnSearch_Click(sender, null);
        }

        protected void BtnFind2_Click(object sender, ImageClickEventArgs e)
        {
            BtnSearch_Click(sender, null);
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



        protected void BtnLoad1_Click(object sender, EventArgs e)
        {
            try
            {
                string Tag = ((Button)sender).ID.Substring(7, ((Button)sender).ID.Length - 7);
                FileUpload fp = Panel5.FindControl("FileUpload" + Tag) as FileUpload;
                if (fp != null)
                {
                    if (fp.HasFile)
                        try
                        {
                                string fileExt = System.IO.Path.GetExtension(fp.FileName);
                                String FileName = Config.GetImageName(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + fileExt;
                                fp.SaveAs(Server.MapPath(ImageUrl) + @"/" + FileName);
                                ((Button)sender).ToolTip = FileName;
                                string url = ImageUrl + FileName;
                                Button BtnView = Panel5.FindControl("BtnView" + Tag) as Button;
                                if (BtnView != null)
                                {
                                    BtnView.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                                    BtnView.Attributes.Add("onclick", "window.open('" + url + "')");
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
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لم بتم اختيار الملف";
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

        protected void BtnFind3_Click(object sender, ImageClickEventArgs e)
        {
            if (txtJobNo.Text != "")
            {
                SEmp myEmp = new SEmp();
                myEmp.JobNo = txtJobNo.Text;
                myEmp = myEmp.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                if (myEmp == null)
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "الرقم الوظيفي غير مدرج من قبل";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>');", true);
                    BtnClear_Click(sender, e);
                }
                else
                {
                    txtEmpCode.Text = myEmp.EmpCode.ToString();
                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = "البيانات الاساسية";
                        UserTran.FormAction = "عرض";
                        UserTran.Description = "عرض بيانات الموظف رقم " + txtEmpCode.Text;
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }
                    EditMode();
                    getEmp(myEmp);
                }
            }
        }

        public void TotSum()
        {
            txtTAdd.Text = string.Format("{0:N2}", (moh.StrToDouble(txtBasic.Text) + moh.StrToDouble(txtAdd01.Text) + moh.StrToDouble(txtAdd02.Text) + moh.StrToDouble(txtAdd03.Text) + moh.StrToDouble(txtAdd04.Text) + moh.StrToDouble(txtAdd05.Text) + moh.StrToDouble(txtAdd06.Text) + moh.StrToDouble(txtAdd07.Text) + moh.StrToDouble(txtAdd08.Text) + moh.StrToDouble(txtAdd09.Text) + moh.StrToDouble(txtAdd10.Text) + moh.StrToDouble(txtAdd11.Text) + moh.StrToDouble(txtAdd12.Text) + moh.StrToDouble(txtAdd13.Text) + moh.StrToDouble(txtAdd14.Text) + moh.StrToDouble(txtAdd15.Text)).ToString());
            txtTDed.Text = string.Format("{0:N2}", (moh.StrToDouble(txtDed01.Text) + moh.StrToDouble(txtDed02.Text) + moh.StrToDouble(txtDed03.Text) + moh.StrToDouble(txtDed04.Text) + moh.StrToDouble(txtDed05.Text) + moh.StrToDouble(txtDed06.Text) + moh.StrToDouble(txtDed07.Text) + moh.StrToDouble(txtDed08.Text) + moh.StrToDouble(txtDed09.Text) + moh.StrToDouble(txtDed10.Text) + moh.StrToDouble(txtDed11.Text) + moh.StrToDouble(txtDed12.Text) + moh.StrToDouble(txtDed13.Text) + moh.StrToDouble(txtDed14.Text) + moh.StrToDouble(txtDed15.Text)).ToString());
            txtNet.Text = string.Format("{0:N2}", Math.Round(moh.StrToDouble(txtTAdd.Text) - moh.StrToDouble(txtTDed.Text),0).ToString());
        }

        protected void txtBasic_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).ID.ToUpper() == "TXTBASIC")
            {
                txtAdd01.Text = string.Format("{0:N2}", Math.Round(moh.StrToDouble(txtBasic.Text) * 0.10 < 300 ? 300 : moh.StrToDouble(txtBasic.Text) * 0.10,2));
                txtAdd02.Text = string.Format("{0:N2}", Math.Round(moh.StrToDouble(txtBasic.Text) * 0.25,2));
                if (ddlNational.SelectedIndex == 1 || ddlNational.SelectedValue == "203")
                {
                    txtAdd08.Text = string.Format("{0:N2}", Math.Round((moh.StrToDouble(txtBasic.Text) + moh.StrToDouble(txtAdd02.Text)) * 0.09, 2));
                    txtAdd15.Text = string.Format("{0:N2}", Math.Round((moh.StrToDouble(txtBasic.Text) + moh.StrToDouble(txtAdd02.Text)) * 0.0075, 2));
                }
                else
                {
                    txtAdd08.Text = "0.00";
                    txtAdd15.Text = "0.00";
                }
                txtAdd07.Text = string.Format("{0:N2}", Math.Round((moh.StrToDouble(txtBasic.Text) + moh.StrToDouble(txtAdd02.Text)) * 0.02,2));
                txtDed01.Text = string.Format("{0:N2}", Math.Round((moh.StrToDouble(txtAdd07.Text) + (moh.StrToDouble(txtAdd08.Text) * 2) + (moh.StrToDouble(txtAdd15.Text) * 2)), 2));                
            }
            TotSum();

        }

        protected void BtnAttach_Click(object sender, ImageClickEventArgs e)
        {
            if (FileUpload11.HasFile)
                try
                {
                    MyConfig mySetting = new MyConfig();
                    mySetting.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    mySetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                    if (mySetting != null)
                    {
                        string fileExt = System.IO.Path.GetExtension(FileUpload11.FileName);
                        String FileName = Config.GetImageName(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + fileExt;
                        FileUpload11.SaveAs(mySetting.ImagePath + FileName);

                        Arch myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = 0;
                        myArch.Number = int.Parse(txtEmpCode.Text);
                        myArch.DocType = 668;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = 0;
                        myArch.Number = int.Parse(txtEmpCode.Text);
                        myArch.DocType = 668;
                        myArch.FileName = FileUpload11.FileName;
                        myArch.FileName2 = mySetting.ImagePath2 + FileName;
                        myArch.FNo = (short)i;
                        myArch.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormName = "البيانات الاساسية";
                            UserTran.FormAction = "اضافة مرفقات";
                            UserTran.Description = "اضافة مرفقات لملف الموظف رقم " + txtEmpCode.Text;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }

                        LoadAttachData();
                    }

                    //    LblCodesResult.Text = "File name: " + FileUpload11.PostedFile.FileName + "<br>" + FileUpload11.PostedFile.ContentLength + " kb<br>" + "Content type: " + FileUpload11.PostedFile.ContentType;
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
                myArch.LocNumber = 0;
                myArch.Number = int.Parse(txtEmpCode.Text);
                myArch.DocType = 668;
                myArch.FNo = short.Parse(FNo);
                myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                {
                    Transactions UserTran = new Transactions();
                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                    UserTran.UserName = Session["CurrentUser"].ToString();
                    UserTran.FormName = "البيانات الاساسية";
                    UserTran.FormAction = "الغاء مرفقات";
                    UserTran.Description = "الغاء مرفقات من ملف الموظف رقم " + txtEmpCode.Text;
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
                    Response.Redirect("GeneralServerError.aspx",false);
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
            if (txtEmpCode.Text != "")
            {
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(Session["Branch"].ToString());
                myArch.LocNumber = 0;
                myArch.Number = int.Parse(txtEmpCode.Text);
                myArch.DocType = 668;
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

    }
}
