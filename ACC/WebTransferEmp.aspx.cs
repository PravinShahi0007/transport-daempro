using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using System.Configuration;
using System.Globalization;
using System.Threading;

namespace ACC
{
    public partial class WebTransferEmp : System.Web.UI.Page
    {
        public string DocType = "401";
        public string DocName = "طلب نقل موظف";

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

        public void EditMode(bool Flag)
        {
            txtDocNo.ReadOnly = true;
            txtDocNo.BackColor = System.Drawing.Color.LightGray;
            BtnPrint.Visible = true; // && (Request.QueryString["Support"] != null || (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass215);
            BtnNew.Visible = false;
            if (Flag) BtnEdit.Visible = true;
            else ControlsOnOff(false);
        }

        public void NewMode()
        {
            txtDocNo.ReadOnly = true;
            txtDocNo.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = false;
            BtnNew.Visible = true; // && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass211;
            BtnEdit.Visible = false;
            ControlsOnOff(true);
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
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttachAgree1A1);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttachAgree2A1);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttachAgree3A1);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttachAgree4A1);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttachAgree5A1);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttachAgree6A1);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttachAgree7A1);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttachAgree8A1);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttachAgree9A1);

                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["Support"] == null)
                    {

                    }

                    this.Page.Header.Title = DocName;
                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "الرئيسية", "اختيار", DocName, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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
                    if (Session[vRoleName] == null)
                    {
                        Response.Redirect("WebNotPrev.aspx", false);
                        return;
                    }

                    lblDaysOff1.Visible = false;
                    lblDaysOff2.Visible = false;
                    lblDaysOff3.Visible = false;
                    lblDaysOff4.Visible = false;
                    lblDaysOff5.Visible = false;
                    lblDaysOff6.Visible = false;
                    lblDaysOff7.Visible = false;
                    lblDaysOff8.Visible = false;
                    lblDaysOff9.Visible = false;
                    txtDaysOff1.Visible = false;
                    txtDaysOff2.Visible = false;
                    txtDaysOff3.Visible = false;
                    txtDaysOff4.Visible = false;
                    txtDaysOff5.Visible = false;
                    txtDaysOff6.Visible = false;
                    txtDaysOff7.Visible = false;
                    txtDaysOff8.Visible = false;
                    txtDaysOff9.Visible = false;
                    lblDiscount1.Visible = false;
                    lblDiscount2.Visible = false;
                    lblDiscount3.Visible = false;
                    lblDiscount4.Visible = false;
                    lblDiscount5.Visible = false;
                    lblDiscount6.Visible = false;
                    lblDiscount7.Visible = false;
                    lblDiscount8.Visible = false;
                    lblDiscount9.Visible = false;
                    txtDiscount1.Visible = false;
                    txtDiscount2.Visible = false;
                    txtDiscount3.Visible = false;
                    txtDiscount4.Visible = false;
                    txtDiscount5.Visible = false;
                    txtDiscount6.Visible = false;
                    txtDiscount7.Visible = false;
                    txtDiscount8.Visible = false;
                    txtDiscount9.Visible = false;

                    ddlFType.DataTextField = "Name1";
                    ddlFType.DataValueField = "Name2";

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

                    ddlFType.DataSource = lCode;
                    ddlFType.DataBind();
                    ddlFType.Items.Insert(0, new ListItem("--- أختر الصلاحيه ---", "-1", true));

                    ddlDep.DataTextField = "Name1";
                    ddlDep.DataValueField = "Code";
                    myCode = new Codes();
                    myCode.Branch = short.Parse(Session["Branch"].ToString());
                    myCode.Ftype = 19;
                    ddlDep.DataSource = myCode.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlDep.DataBind();
                    ddlDep.Items.Insert(0, new ListItem("--- أختر الإداره ---", "-1", true));

                    ddlSection.DataTextField = "Name1";
                    ddlSection.DataValueField = "Code";
                    CostCenter myCost = new CostCenter();
                    myCost.Branch = short.Parse(Session["Branch"].ToString());
                    ddlSection.DataSource = myCost.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlSection.DataBind();
                    ddlSection.Items.Insert(0, new ListItem("--- أختر الفرع ---", "-1", true));

                    BtnClear_Click(sender, null);

                    if (Request.QueryString["FNum"] != null)
                    {
                        int vLevel = int.Parse(Request.QueryString["FLevel"].ToString());
                        bool Transfer = false;
                        eServices myService = new eServices();
                        myService.DocType = short.Parse(DocType);
                        myService.DocNo = int.Parse(Request.QueryString["FNum"].ToString());
                        myService = myService.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myService != null)
                        {
                            if (myService.TransferUser != "")
                            {
                                Transfer = true;
                                eServicesAgree myServiceAgree = new eServicesAgree();
                                myServiceAgree.DocType = short.Parse(DocType);
                                myServiceAgree.DocNo = int.Parse(Request.QueryString["FNum"].ToString());
                                vLevel = (int)myServiceAgree.GetMaxFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }
                        }

                        //if (vLevel != 0) 
                        SetDisplayLevel(vLevel.ToString(), Request.QueryString["FNum"].ToString());
                        SearchDoc(Request.QueryString["FNum"].ToString());
                        if (Request.QueryString["FMode"].ToString() != "0")
                        {
                            if (vLevel != 0) EnableLevel((Transfer ? (int.Parse(Request.QueryString["FLevel"].ToString())).ToString() : Request.QueryString["FLevel"].ToString()));
                            else EnableLevel("0");
                        }
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

        public void SetDisplayLevel(string Level, string FNum)
        {
            bool vDisp = false;
            if (Request.QueryString["FMode"] != null)
                if (Request.QueryString["FMode"].ToString() != "0") vDisp = true;
            vDisp = false;
            Agrees.Visible = true;
            veServices myService = new veServices();
            myService.DocType = short.Parse(DocType);
            myService.DocNo = int.Parse(FNum);
            myService = myService.find0(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myService != null)
            {
                litAgree1.Text = "أعتماد " + (myService.FStep1 == "1" ? "المدير المباشر" : myService.FStep1);
                litAgree2.Text = "أعتماد " + (myService.FStep2 == "1" ? "المدير المباشر" : myService.FStep2);
                litAgree3.Text = "أعتماد " + (myService.FStep3 == "1" ? "المدير المباشر" : myService.FStep3);
                litAgree4.Text = "أعتماد " + (myService.FStep4 == "1" ? "المدير المباشر" : myService.FStep4);
                litAgree5.Text = "أعتماد " + (myService.FStep5 == "1" ? "المدير المباشر" : myService.FStep5);
                litAgree6.Text = "أعتماد " + (myService.FStep6 == "1" ? "المدير المباشر" : myService.FStep6);
                litAgree7.Text = "أعتماد " + (myService.FStep7 == "1" ? "المدير المباشر" : myService.FStep7);
                litAgree8.Text = "أعتماد " + (myService.FStep8 == "1" ? "المدير المباشر" : myService.FStep8);
                litAgree9.Text = "أعتماد " + (myService.FStep8 == "1" ? "المدير المباشر" : myService.FStep8);
                if (Level == "99" || Level == "-1" || Level == "88")
                {
                    if (Level == "-1") EditMode(true);

                    eServicesAgree vService = new eServicesAgree();
                    vService.DocType = short.Parse(DocType);
                    vService.DocNo = int.Parse(FNum);
                    short? r = vService.GetMaxFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (r != null) Level = r.ToString();

                    if (Level == "-1") EditMode(true);
                }
                else
                {
                    eServicesAgree vService = new eServicesAgree();
                    vService.DocType = short.Parse(DocType);
                    vService.DocNo = int.Parse(FNum);
                    short? r = vService.GetMaxFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (r != null && short.Parse(Level) < (short)r) Level = r.ToString();
                }
            }

            switch (int.Parse(Level))
            {
                case 9:
                    {
                        divAgree9.Visible = true;
                        divAgree8.Visible = true;
                        divAgree7.Visible = true;
                        divAgree6.Visible = true;
                        divAgree5.Visible = true;
                        divAgree4.Visible = true;
                        divAgree3.Visible = true;
                        divAgree2.Visible = true;
                        divAgree1.Visible = true;
                        cpeDemo01.Collapsed = false;
                        cpeDemo01.ClientState = "false";
                        cpeDemo02.Collapsed = false;
                        cpeDemo02.ClientState = "false";
                        cpeDemo03.Collapsed = false;
                        cpeDemo03.ClientState = "false";
                        cpeDemo04.Collapsed = false;
                        cpeDemo04.ClientState = "false";
                        cpeDemo05.Collapsed = false;
                        cpeDemo05.ClientState = "false";
                        cpeDemo06.Collapsed = false;
                        cpeDemo06.ClientState = "false";
                        cpeDemo07.Collapsed = false;
                        cpeDemo07.ClientState = "false";
                        cpeDemo08.Collapsed = false;
                        cpeDemo08.ClientState = "false";
                        cpeDemo09.Collapsed = false;
                        cpeDemo09.ClientState = "false";
                        GetAgree("1", FNum);
                        GetAgree("2", FNum);
                        GetAgree("3", FNum);
                        GetAgree("4", FNum);
                        GetAgree("5", FNum);
                        GetAgree("6", FNum);
                        GetAgree("7", FNum);
                        GetAgree("8", FNum);
                        GetAgree("9", FNum);
                        break;
                    }
                case 8:
                    {
                        divAgree8.Visible = true;
                        divAgree7.Visible = true;
                        divAgree6.Visible = true;
                        divAgree5.Visible = true;
                        divAgree4.Visible = true;
                        divAgree3.Visible = true;
                        divAgree2.Visible = true;
                        divAgree1.Visible = true;
                        cpeDemo01.Collapsed = false;
                        cpeDemo01.ClientState = "false";
                        cpeDemo02.Collapsed = false;
                        cpeDemo02.ClientState = "false";
                        cpeDemo03.Collapsed = false;
                        cpeDemo03.ClientState = "false";
                        cpeDemo04.Collapsed = false;
                        cpeDemo04.ClientState = "false";
                        cpeDemo05.Collapsed = false;
                        cpeDemo05.ClientState = "false";
                        cpeDemo06.Collapsed = false;
                        cpeDemo06.ClientState = "false";
                        cpeDemo07.Collapsed = false;
                        cpeDemo07.ClientState = "false";
                        cpeDemo08.Collapsed = false;
                        cpeDemo08.ClientState = "false";
                        GetAgree("1", FNum);
                        GetAgree("2", FNum);
                        GetAgree("3", FNum);
                        GetAgree("4", FNum);
                        GetAgree("5", FNum);
                        GetAgree("6", FNum);
                        GetAgree("7", FNum);
                        GetAgree("8", FNum);

                        if (vDisp)
                        {
                            if (myService != null)
                            {
                                BtnDisagree8.Visible = (myService.SType8 == 0);
                                BtnTransfer8.Visible = (myService.SType8 == 0);
                                lblTransfer8.Visible = false; // (myService.SType8 == 0);
                                ddlTransfer8.Visible = false; // (myService.SType8 == 0);
                            }
                        }
                        break;
                    }
                case 7:
                    {
                        divAgree7.Visible = true;
                        divAgree6.Visible = true;
                        divAgree5.Visible = true;
                        divAgree4.Visible = true;
                        divAgree3.Visible = true;
                        divAgree2.Visible = true;
                        divAgree1.Visible = true;
                        cpeDemo01.Collapsed = false;
                        cpeDemo01.ClientState = "false";
                        cpeDemo02.Collapsed = false;
                        cpeDemo02.ClientState = "false";
                        cpeDemo03.Collapsed = false;
                        cpeDemo03.ClientState = "false";
                        cpeDemo04.Collapsed = false;
                        cpeDemo04.ClientState = "false";
                        cpeDemo05.Collapsed = false;
                        cpeDemo05.ClientState = "false";
                        cpeDemo06.Collapsed = false;
                        cpeDemo06.ClientState = "false";
                        cpeDemo07.Collapsed = false;
                        cpeDemo07.ClientState = "false";
                        GetAgree("1", FNum);
                        GetAgree("2", FNum);
                        GetAgree("3", FNum);
                        GetAgree("4", FNum);
                        GetAgree("5", FNum);
                        GetAgree("6", FNum);
                        GetAgree("7", FNum);

                        if (vDisp)
                        {
                            if (myService != null)
                            {
                                BtnDisagree7.Visible = (myService.SType7 == 0);
                                BtnTransfer7.Visible = (myService.SType7 == 0);
                                lblTransfer7.Visible = false; // (myService.SType7 == 0);
                                ddlTransfer7.Visible = false; // (myService.SType7 == 0);
                            }
                        }
                        break;
                    }
                case 6:
                    {
                        divAgree6.Visible = true;
                        divAgree5.Visible = true;
                        divAgree4.Visible = true;
                        divAgree3.Visible = true;
                        divAgree2.Visible = true;
                        divAgree1.Visible = true;
                        cpeDemo01.Collapsed = false;
                        cpeDemo01.ClientState = "false";
                        cpeDemo02.Collapsed = false;
                        cpeDemo02.ClientState = "false";
                        cpeDemo03.Collapsed = false;
                        cpeDemo03.ClientState = "false";
                        cpeDemo04.Collapsed = false;
                        cpeDemo04.ClientState = "false";
                        cpeDemo05.Collapsed = false;
                        cpeDemo05.ClientState = "false";
                        cpeDemo06.Collapsed = false;
                        cpeDemo06.ClientState = "false";
                        GetAgree("1", FNum);
                        GetAgree("2", FNum);
                        GetAgree("3", FNum);
                        GetAgree("4", FNum);
                        GetAgree("5", FNum);
                        GetAgree("6", FNum);

                        if (vDisp)
                        {
                            if (myService != null)
                            {
                                BtnDisagree6.Visible = (myService.SType6 == 0);
                                BtnTransfer6.Visible = (myService.SType6 == 0);
                                lblTransfer6.Visible = false; // (myService.SType6 == 0);
                                ddlTransfer6.Visible = false; // (myService.SType6 == 0);
                            }
                        }
                        break;
                    }
                case 5:
                    {
                        divAgree5.Visible = true;
                        divAgree4.Visible = true;
                        divAgree3.Visible = true;
                        divAgree2.Visible = true;
                        divAgree1.Visible = true;
                        cpeDemo01.Collapsed = false;
                        cpeDemo01.ClientState = "false";
                        cpeDemo02.Collapsed = false;
                        cpeDemo02.ClientState = "false";
                        cpeDemo03.Collapsed = false;
                        cpeDemo03.ClientState = "false";
                        cpeDemo04.Collapsed = false;
                        cpeDemo04.ClientState = "false";
                        cpeDemo05.Collapsed = false;
                        cpeDemo05.ClientState = "false";
                        GetAgree("1", FNum);
                        GetAgree("2", FNum);
                        GetAgree("3", FNum);
                        GetAgree("4", FNum);
                        GetAgree("5", FNum);

                        if (vDisp)
                        {
                            if (myService != null)
                            {
                                BtnDisagree5.Visible = (myService.SType5 == 0);
                                BtnTransfer5.Visible = (myService.SType5 == 0);
                                lblTransfer5.Visible = false; // (myService.SType5 == 0);
                                ddlTransfer5.Visible = false; // (myService.SType5 == 0);
                            }
                        }
                        break;
                    }
                case 4:
                    {
                        divAgree4.Visible = true;
                        divAgree3.Visible = true;
                        divAgree2.Visible = true;
                        divAgree1.Visible = true;
                        cpeDemo01.Collapsed = false;
                        cpeDemo01.ClientState = "false";
                        cpeDemo02.Collapsed = false;
                        cpeDemo02.ClientState = "false";
                        cpeDemo03.Collapsed = false;
                        cpeDemo03.ClientState = "false";
                        cpeDemo04.Collapsed = false;
                        cpeDemo04.ClientState = "false";
                        GetAgree("1", FNum);
                        GetAgree("2", FNum);
                        GetAgree("3", FNum);
                        GetAgree("4", FNum);

                        if (vDisp)
                        {
                            if (myService != null)
                            {
                                BtnDisagree4.Visible = (myService.SType4 == 0);
                                BtnTransfer4.Visible = (myService.SType4 == 0);
                                lblTransfer4.Visible = false; // (myService.SType4 == 0);
                                ddlTransfer4.Visible = false; // (myService.SType4 == 0);
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        divAgree3.Visible = true;
                        divAgree2.Visible = true;
                        divAgree1.Visible = true;
                        cpeDemo01.Collapsed = false;
                        cpeDemo01.ClientState = "false";
                        cpeDemo02.Collapsed = false;
                        cpeDemo02.ClientState = "false";
                        cpeDemo03.Collapsed = false;
                        cpeDemo03.ClientState = "false";
                        GetAgree("1", FNum);
                        GetAgree("2", FNum);
                        GetAgree("3", FNum);

                        if (vDisp)
                        {
                            if (myService != null)
                            {
                                BtnDisagree3.Visible = (myService.SType3 == 0);
                                BtnTransfer3.Visible = (myService.SType3 == 0);
                                lblTransfer3.Visible = false; // (myService.SType3 == 0);
                                ddlTransfer3.Visible = false; // (myService.SType3 == 0);
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        divAgree2.Visible = true;
                        divAgree1.Visible = true;
                        cpeDemo01.Collapsed = false;
                        cpeDemo01.ClientState = "false";
                        cpeDemo02.Collapsed = false;
                        cpeDemo02.ClientState = "false";
                        GetAgree("1", FNum);
                        GetAgree("2", FNum);

                        if (vDisp)
                        {
                            if (myService != null)
                            {
                                BtnDisagree2.Visible = (myService.SType2 == 0);
                                BtnTransfer2.Visible = (myService.SType2 == 0);
                                lblTransfer2.Visible = false; // (myService.SType2 == 0);
                                ddlTransfer2.Visible = false; // (myService.SType2 == 0);
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        divAgree1.Visible = true;
                        cpeDemo01.Collapsed = false;
                        cpeDemo01.ClientState = "false";
                        GetAgree("1", FNum);

                        if (vDisp)
                        {
                            if (myService != null)
                            {
                                BtnDisagree1.Visible = (myService.SType1 == 0);
                                BtnTransfer1.Visible = (myService.SType1 == 0);
                                lblTransfer1.Visible = false; // (myService.SType1 == 0);
                                ddlTransfer1.Visible = false; // (myService.SType1 == 0);
                            }
                        }
                        break;
                    }
            }
        }


        public void SetMyDisplayLevel(string Level, string FNum)
        {
            bool vDisp = false;
            if (Request.QueryString["FMode"] != null)
                if (Request.QueryString["FMode"].ToString() != "0") vDisp = true;
            vDisp = false;
            Agrees.Visible = true;
            veServices myService = new veServices();
            myService.DocType = short.Parse(DocType);
            myService.DocNo = int.Parse(FNum);
            myService = myService.find0(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myService != null)
            {
                litAgree1.Text = "أعتماد " + (myService.FStep1 == "1" ? "المدير المباشر" : myService.FStep1);
                litAgree2.Text = "أعتماد " + (myService.FStep2 == "1" ? "المدير المباشر" : myService.FStep2);
                litAgree3.Text = "أعتماد " + (myService.FStep3 == "1" ? "المدير المباشر" : myService.FStep3);
                litAgree4.Text = "أعتماد " + (myService.FStep4 == "1" ? "المدير المباشر" : myService.FStep4);
                litAgree5.Text = "أعتماد " + (myService.FStep5 == "1" ? "المدير المباشر" : myService.FStep5);
                litAgree6.Text = "أعتماد " + (myService.FStep6 == "1" ? "المدير المباشر" : myService.FStep6);
                litAgree7.Text = "أعتماد " + (myService.FStep7 == "1" ? "المدير المباشر" : myService.FStep7);
                litAgree8.Text = "أعتماد " + (myService.FStep8 == "1" ? "المدير المباشر" : myService.FStep8);
                litAgree9.Text = "أعتماد " + (myService.FStep8 == "1" ? "المدير المباشر" : myService.FStep8);
                if (Level == "99" || Level == "-1" || Level == "88")
                {
                    if (Level == "-1") EditMode(true);

                    eServicesAgree vService = new eServicesAgree();
                    vService.DocType = short.Parse(DocType);
                    vService.DocNo = int.Parse(FNum);
                    short? r = vService.GetMaxFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (r != null) Level = r.ToString();

                    if (Level == "-1") EditMode(true);
                }
                else
                {
                    eServicesAgree vService = new eServicesAgree();
                    vService.DocType = short.Parse(DocType);
                    vService.DocNo = int.Parse(FNum);
                    short? r = vService.GetMaxFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (r != null && short.Parse(Level) < (short)r) Level = r.ToString();
                }
            }

            switch (int.Parse(Level))
            {
                case 9:
                    {
                        divAgree9.Visible = true;
                        divAgree8.Visible = true;
                        divAgree7.Visible = true;
                        divAgree6.Visible = true;
                        divAgree5.Visible = true;
                        divAgree4.Visible = true;
                        divAgree3.Visible = true;
                        divAgree2.Visible = true;
                        divAgree1.Visible = true;
                        cpeDemo01.Collapsed = false;
                        cpeDemo01.ClientState = "false";
                        cpeDemo02.Collapsed = false;
                        cpeDemo02.ClientState = "false";
                        cpeDemo03.Collapsed = false;
                        cpeDemo03.ClientState = "false";
                        cpeDemo04.Collapsed = false;
                        cpeDemo04.ClientState = "false";
                        cpeDemo05.Collapsed = false;
                        cpeDemo05.ClientState = "false";
                        cpeDemo06.Collapsed = false;
                        cpeDemo06.ClientState = "false";
                        cpeDemo07.Collapsed = false;
                        cpeDemo07.ClientState = "false";
                        cpeDemo08.Collapsed = false;
                        cpeDemo08.ClientState = "false";
                        cpeDemo09.Collapsed = false;
                        cpeDemo09.ClientState = "false";
                        GetAgree("1", FNum);
                        GetAgree("2", FNum);
                        GetAgree("3", FNum);
                        GetAgree("4", FNum);
                        GetAgree("5", FNum);
                        GetAgree("6", FNum);
                        GetAgree("7", FNum);
                        GetAgree("8", FNum);
                        GetAgree("9", FNum);
                        break;
                    }
                case 8:
                    {
                        divAgree8.Visible = true;
                        divAgree7.Visible = true;
                        divAgree6.Visible = true;
                        divAgree5.Visible = true;
                        divAgree4.Visible = true;
                        divAgree3.Visible = true;
                        divAgree2.Visible = true;
                        divAgree1.Visible = true;
                        cpeDemo01.Collapsed = false;
                        cpeDemo01.ClientState = "false";
                        cpeDemo02.Collapsed = false;
                        cpeDemo02.ClientState = "false";
                        cpeDemo03.Collapsed = false;
                        cpeDemo03.ClientState = "false";
                        cpeDemo04.Collapsed = false;
                        cpeDemo04.ClientState = "false";
                        cpeDemo05.Collapsed = false;
                        cpeDemo05.ClientState = "false";
                        cpeDemo06.Collapsed = false;
                        cpeDemo06.ClientState = "false";
                        cpeDemo07.Collapsed = false;
                        cpeDemo07.ClientState = "false";
                        cpeDemo08.Collapsed = false;
                        cpeDemo08.ClientState = "false";
                        GetAgree("1", FNum);
                        GetAgree("2", FNum);
                        GetAgree("3", FNum);
                        GetAgree("4", FNum);
                        GetAgree("5", FNum);
                        GetAgree("6", FNum);
                        GetAgree("7", FNum);
                        GetAgree("8", FNum);

                        if (vDisp)
                        {
                            if (myService != null)
                            {
                                BtnDisagree8.Visible = (myService.SType8 == 0);
                                BtnTransfer8.Visible = (myService.SType8 == 0);
                                lblTransfer8.Visible = false; // (myService.SType8 == 0);
                                ddlTransfer8.Visible = false; // (myService.SType8 == 0);
                            }
                        }
                        break;
                    }
                case 7:
                    {
                        divAgree7.Visible = true;
                        divAgree6.Visible = true;
                        divAgree5.Visible = true;
                        divAgree4.Visible = true;
                        divAgree3.Visible = true;
                        divAgree2.Visible = true;
                        divAgree1.Visible = true;
                        cpeDemo01.Collapsed = false;
                        cpeDemo01.ClientState = "false";
                        cpeDemo02.Collapsed = false;
                        cpeDemo02.ClientState = "false";
                        cpeDemo03.Collapsed = false;
                        cpeDemo03.ClientState = "false";
                        cpeDemo04.Collapsed = false;
                        cpeDemo04.ClientState = "false";
                        cpeDemo05.Collapsed = false;
                        cpeDemo05.ClientState = "false";
                        cpeDemo06.Collapsed = false;
                        cpeDemo06.ClientState = "false";
                        cpeDemo07.Collapsed = false;
                        cpeDemo07.ClientState = "false";
                        GetAgree("1", FNum);
                        GetAgree("2", FNum);
                        GetAgree("3", FNum);
                        GetAgree("4", FNum);
                        GetAgree("5", FNum);
                        GetAgree("6", FNum);
                        GetAgree("7", FNum);

                        if (vDisp)
                        {
                            if (myService != null)
                            {
                                BtnDisagree7.Visible = (myService.SType7 == 0);
                                BtnTransfer7.Visible = (myService.SType7 == 0);
                                lblTransfer7.Visible = false; // (myService.SType7 == 0);
                                ddlTransfer7.Visible = false; // (myService.SType7 == 0);
                            }
                        }
                        break;
                    }
                case 6:
                    {
                        divAgree6.Visible = true;
                        divAgree5.Visible = true;
                        divAgree4.Visible = true;
                        divAgree3.Visible = true;
                        divAgree2.Visible = true;
                        divAgree1.Visible = true;
                        cpeDemo01.Collapsed = false;
                        cpeDemo01.ClientState = "false";
                        cpeDemo02.Collapsed = false;
                        cpeDemo02.ClientState = "false";
                        cpeDemo03.Collapsed = false;
                        cpeDemo03.ClientState = "false";
                        cpeDemo04.Collapsed = false;
                        cpeDemo04.ClientState = "false";
                        cpeDemo05.Collapsed = false;
                        cpeDemo05.ClientState = "false";
                        cpeDemo06.Collapsed = false;
                        cpeDemo06.ClientState = "false";
                        GetAgree("1", FNum);
                        GetAgree("2", FNum);
                        GetAgree("3", FNum);
                        GetAgree("4", FNum);
                        GetAgree("5", FNum);
                        GetAgree("6", FNum);

                        if (vDisp)
                        {
                            if (myService != null)
                            {
                                BtnDisagree6.Visible = (myService.SType6 == 0);
                                BtnTransfer6.Visible = (myService.SType6 == 0);
                                lblTransfer6.Visible = false; // (myService.SType6 == 0);
                                ddlTransfer6.Visible = false; // (myService.SType6 == 0);
                            }
                        }
                        break;
                    }
                case 5:
                    {
                        divAgree5.Visible = true;
                        divAgree4.Visible = true;
                        divAgree3.Visible = true;
                        divAgree2.Visible = true;
                        divAgree1.Visible = true;
                        cpeDemo01.Collapsed = false;
                        cpeDemo01.ClientState = "false";
                        cpeDemo02.Collapsed = false;
                        cpeDemo02.ClientState = "false";
                        cpeDemo03.Collapsed = false;
                        cpeDemo03.ClientState = "false";
                        cpeDemo04.Collapsed = false;
                        cpeDemo04.ClientState = "false";
                        cpeDemo05.Collapsed = false;
                        cpeDemo05.ClientState = "false";
                        GetAgree("1", FNum);
                        GetAgree("2", FNum);
                        GetAgree("3", FNum);
                        GetAgree("4", FNum);
                        GetAgree("5", FNum);

                        if (vDisp)
                        {
                            if (myService != null)
                            {
                                BtnDisagree5.Visible = (myService.SType5 == 0);
                                BtnTransfer5.Visible = (myService.SType5 == 0);
                                lblTransfer5.Visible = false; // (myService.SType5 == 0);
                                ddlTransfer5.Visible = false; // (myService.SType5 == 0);
                            }
                        }
                        break;
                    }
                case 4:
                    {
                        divAgree4.Visible = true;
                        divAgree3.Visible = true;
                        divAgree2.Visible = true;
                        divAgree1.Visible = true;
                        cpeDemo01.Collapsed = false;
                        cpeDemo01.ClientState = "false";
                        cpeDemo02.Collapsed = false;
                        cpeDemo02.ClientState = "false";
                        cpeDemo03.Collapsed = false;
                        cpeDemo03.ClientState = "false";
                        cpeDemo04.Collapsed = false;
                        cpeDemo04.ClientState = "false";
                        GetAgree("1", FNum);
                        GetAgree("2", FNum);
                        GetAgree("3", FNum);
                        GetAgree("4", FNum);

                        if (vDisp)
                        {
                            if (myService != null)
                            {
                                BtnDisagree4.Visible = (myService.SType4 == 0);
                                BtnTransfer4.Visible = (myService.SType4 == 0);
                                lblTransfer4.Visible = false; // (myService.SType4 == 0);
                                ddlTransfer4.Visible = false; // (myService.SType4 == 0);
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        divAgree3.Visible = true;
                        divAgree2.Visible = true;
                        divAgree1.Visible = true;
                        cpeDemo01.Collapsed = false;
                        cpeDemo01.ClientState = "false";
                        cpeDemo02.Collapsed = false;
                        cpeDemo02.ClientState = "false";
                        cpeDemo03.Collapsed = false;
                        cpeDemo03.ClientState = "false";
                        GetAgree("1", FNum);
                        GetAgree("2", FNum);
                        GetAgree("3", FNum);

                        if (vDisp)
                        {
                            if (myService != null)
                            {
                                BtnDisagree3.Visible = (myService.SType3 == 0);
                                BtnTransfer3.Visible = (myService.SType3 == 0);
                                lblTransfer3.Visible = false; // (myService.SType3 == 0);
                                ddlTransfer3.Visible = false; // (myService.SType3 == 0);
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        divAgree2.Visible = true;
                        divAgree1.Visible = true;
                        cpeDemo01.Collapsed = false;
                        cpeDemo01.ClientState = "false";
                        cpeDemo02.Collapsed = false;
                        cpeDemo02.ClientState = "false";
                        GetAgree("1", FNum);
                        GetAgree("2", FNum);

                        if (vDisp)
                        {
                            if (myService != null)
                            {
                                BtnDisagree2.Visible = (myService.SType2 == 0);
                                BtnTransfer2.Visible = (myService.SType2 == 0);
                                lblTransfer2.Visible = false; // (myService.SType2 == 0);
                                ddlTransfer2.Visible = false; // (myService.SType2 == 0);
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        divAgree1.Visible = true;
                        cpeDemo01.Collapsed = false;
                        cpeDemo01.ClientState = "false";
                        GetAgree("1", FNum);

                        if (vDisp)
                        {
                            if (myService != null)
                            {
                                BtnDisagree1.Visible = (myService.SType1 == 0);
                                BtnTransfer1.Visible = (myService.SType1 == 0);
                                lblTransfer1.Visible = false; // (myService.SType1 == 0);
                                ddlTransfer1.Visible = false; // (myService.SType1 == 0);
                            }
                        }
                        break;
                    }
            }
        }


        public void GetAgree(string Level, string FNum)
        {
            eServicesAgree vService = new eServicesAgree();
            vService.DocType = short.Parse(DocType);
            vService.DocNo = int.Parse(FNum);
            vService.FNo = short.Parse(Level);
            vService = vService.findFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (vService != null)
            {
                if (Level == "1")
                {
                    txtAgree1User.Text = vService.AgreeUser;
                    txtAgree1User.ToolTip = vService.AgreeUser;
                    txtAgree1UserDate.Text = vService.AgreeUserDate;
                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ax.UserName = vService.AgreeUser;
                    ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                          where uitm.UserName == ax.UserName
                          select uitm).FirstOrDefault();
                    if (ax != null) txtAgree1User.Text = ax.FName;

                    txtRemark1.Text = vService.AgreeRemark;
                    txtRemark1.ReadOnly = true;

                    //BtnAgree1.Enabled = false;
                    //BtnDisagree1.Enabled = false;
                    //BtnTransfer1.Enabled = false;
                    //ddlTransfer1.Enabled = false;

                    BtnAgree1.Visible = (vService.Agree == 1);
                    BtnDisagree1.Visible = (vService.Agree == 0);
                    BtnTransfer1.Visible = (vService.Agree == 2);
                    ddlTransfer1.Visible = false; // (vService.Agree == 2);
                    lblTransfer1.Visible = false; // (vService.Agree == 2);

                    if (BtnAgree1.Visible)
                    {
                        BtnAgree1.ImageUrl = "~/images/doAgree_641.png";
                        BtnAgree1.CssClass = "";
                    }
                    else if (BtnDisagree1.Visible)
                    {
                        BtnDisagree1.ImageUrl = "~/images/doDisAgree_641.png";
                        BtnDisagree1.CssClass = "";
                    }
                    else
                    {
                        BtnTransfer1.ImageUrl = "~/images/doForward_A.png";
                        BtnTransfer1.CssClass = "";
                    }

                    if (ddlTransfer1.Visible && vService.TransferUser != "")
                    {
                        ddlTransfer1.Items.Clear();
                        ax = new TblUsers();
                        ax.UserName = vService.TransferUser;
                        ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                              where uitm.UserName == ax.UserName
                              select uitm).FirstOrDefault();
                        if (ax != null)
                        {
                            ddlTransfer1.Items.Add(new ListItem(ax.FName, vService.TransferUser));
                            ddlTransfer1.SelectedIndex = 0;
                        }
                    }
                }
                else if (Level == "2")
                {
                    txtAgree2User.Text = vService.AgreeUser;
                    txtAgree2User.ToolTip = vService.AgreeUser;
                    txtAgree2UserDate.Text = vService.AgreeUserDate;
                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ax.UserName = vService.AgreeUser;
                    ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                          where uitm.UserName == ax.UserName
                          select uitm).FirstOrDefault();
                    if (ax != null) txtAgree2User.Text = ax.FName;

                    txtRemark2.Text = vService.AgreeRemark;
                    txtRemark2.ReadOnly = true;

                    //BtnAgree2.Enabled = false;
                    //BtnDisagree2.Enabled = false;
                    //BtnTransfer2.Enabled = false;
                    //ddlTransfer2.Enabled = false;

                    BtnAgree2.Visible = (vService.Agree == 1);
                    BtnDisagree2.Visible = (vService.Agree == 0);
                    BtnTransfer2.Visible = (vService.Agree == 2);
                    ddlTransfer2.Visible = false; // (vService.Agree == 2);
                    lblTransfer2.Visible = false; // (vService.Agree == 2);

                    if (BtnAgree2.Visible)
                    {
                        BtnAgree2.ImageUrl = "~/images/doAgree_641.png";
                        BtnAgree2.CssClass = "";
                    }
                    else if (BtnDisagree2.Visible)
                    {
                        BtnDisagree2.ImageUrl = "~/images/doDisAgree_641.png";
                        BtnDisagree2.CssClass = "";
                    }
                    else
                    {
                        BtnTransfer2.ImageUrl = "~/images/doForward_A.png";
                        BtnTransfer2.CssClass = "";
                    }

                    if (ddlTransfer2.Visible && vService.TransferUser != "")
                    {
                        ddlTransfer2.Items.Clear();
                        ax = new TblUsers();
                        ax.UserName = vService.TransferUser;
                        ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                              where uitm.UserName == ax.UserName
                              select uitm).FirstOrDefault();
                        if (ax != null)
                        {
                            ddlTransfer2.Items.Add(new ListItem(ax.FName, vService.TransferUser));
                            ddlTransfer2.SelectedIndex = 0;
                        }
                    }
                }
                else if (Level == "3")
                {
                    txtAgree3User.Text = vService.AgreeUser;
                    txtAgree3User.ToolTip = vService.AgreeUser;
                    txtAgree3UserDate.Text = vService.AgreeUserDate;
                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ax.UserName = vService.AgreeUser;
                    ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                          where uitm.UserName == ax.UserName
                          select uitm).FirstOrDefault();
                    if (ax != null) txtAgree3User.Text = ax.FName;

                    txtRemark3.Text = vService.AgreeRemark;
                    txtRemark3.ReadOnly = true;

                    //BtnAgree3.Enabled = false;
                    //BtnDisagree3.Enabled = false;
                    //BtnTransfer3.Enabled = false;
                    //ddlTransfer3.Enabled = false;

                    BtnAgree3.Visible = (vService.Agree == 1);
                    BtnDisagree3.Visible = (vService.Agree == 0);
                    BtnTransfer3.Visible = (vService.Agree == 2);
                    ddlTransfer3.Visible = false; // (vService.Agree == 2);
                    lblTransfer3.Visible = false; // (vService.Agree == 2);

                    if (BtnAgree3.Visible)
                    {
                        BtnAgree3.ImageUrl = "~/images/doAgree_641.png";
                        BtnAgree3.CssClass = "";
                    }
                    else if (BtnDisagree3.Visible)
                    {
                        BtnDisagree3.ImageUrl = "~/images/doDisAgree_641.png";
                        BtnDisagree3.CssClass = "";
                    }
                    else
                    {
                        BtnTransfer3.ImageUrl = "~/images/doForward_A.png";
                        BtnTransfer3.CssClass = "";
                    }

                    if (ddlTransfer3.Visible && vService.TransferUser != "")
                    {
                        ddlTransfer3.Items.Clear();
                        ax = new TblUsers();
                        ax.UserName = vService.TransferUser;
                        ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                              where uitm.UserName == ax.UserName
                              select uitm).FirstOrDefault();
                        if (ax != null)
                        {
                            ddlTransfer3.Items.Add(new ListItem(ax.FName, vService.TransferUser));
                            ddlTransfer3.SelectedIndex = 0;
                        }
                    }
                }
                else if (Level == "4")
                {
                    txtAgree4User.Text = vService.AgreeUser;
                    txtAgree4User.ToolTip = vService.AgreeUser;
                    txtAgree4UserDate.Text = vService.AgreeUserDate;
                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ax.UserName = vService.AgreeUser;
                    ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                          where uitm.UserName == ax.UserName
                          select uitm).FirstOrDefault();
                    if (ax != null) txtAgree4User.Text = ax.FName;

                    txtRemark4.Text = vService.AgreeRemark;
                    txtRemark4.ReadOnly = true;

                    //BtnAgree4.Enabled = false;
                    //BtnDisagree4.Enabled = false;
                    //BtnTransfer4.Enabled = false;
                    //ddlTransfer4.Enabled = false;

                    BtnAgree4.Visible = (vService.Agree == 1);
                    BtnDisagree4.Visible = (vService.Agree == 0);
                    BtnTransfer4.Visible = (vService.Agree == 2);
                    ddlTransfer4.Visible = false; // (vService.Agree == 2);
                    lblTransfer4.Visible = false; // (vService.Agree == 2);

                    if (BtnAgree4.Visible)
                    {
                        BtnAgree4.ImageUrl = "~/images/doAgree_641.png";
                        BtnAgree4.CssClass = "";
                    }
                    else if (BtnDisagree4.Visible)
                    {
                        BtnDisagree4.ImageUrl = "~/images/doDisAgree_641.png";
                        BtnDisagree4.CssClass = "";
                    }
                    else
                    {
                        BtnTransfer4.ImageUrl = "~/images/doForward_A.png";
                        BtnTransfer4.CssClass = "";
                    }

                    if (ddlTransfer4.Visible && vService.TransferUser != "")
                    {
                        ddlTransfer4.Items.Clear();
                        ax = new TblUsers();
                        ax.UserName = vService.TransferUser;
                        ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                              where uitm.UserName == ax.UserName
                              select uitm).FirstOrDefault();
                        if (ax != null)
                        {
                            ddlTransfer4.Items.Add(new ListItem(ax.FName, vService.TransferUser));
                            ddlTransfer4.SelectedIndex = 0;
                        }
                    }
                }
                else if (Level == "5")
                {
                    txtAgree5User.Text = vService.AgreeUser;
                    txtAgree5User.ToolTip = vService.AgreeUser;
                    txtAgree5UserDate.Text = vService.AgreeUserDate;
                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ax.UserName = vService.AgreeUser;
                    ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                          where uitm.UserName == ax.UserName
                          select uitm).FirstOrDefault();
                    if (ax != null) txtAgree5User.Text = ax.FName;

                    txtRemark5.Text = vService.AgreeRemark;
                    txtRemark5.ReadOnly = true;

                    //BtnAgree5.Enabled = false;
                    //BtnDisagree5.Enabled = false;
                    //BtnTransfer5.Enabled = false;
                    //ddlTransfer5.Enabled = false;

                    BtnAgree5.Visible = (vService.Agree == 1);
                    BtnDisagree5.Visible = (vService.Agree == 0);
                    BtnTransfer5.Visible = (vService.Agree == 2);
                    ddlTransfer5.Visible = false; // (vService.Agree == 2);
                    lblTransfer5.Visible = false; // (vService.Agree == 2);

                    if (BtnAgree5.Visible)
                    {
                        BtnAgree5.ImageUrl = "~/images/doAgree_641.png";
                        BtnAgree5.CssClass = "";
                    }
                    else if (BtnDisagree5.Visible)
                    {
                        BtnDisagree5.ImageUrl = "~/images/doDisAgree_641.png";
                        BtnDisagree5.CssClass = "";
                    }
                    else
                    {
                        BtnTransfer5.ImageUrl = "~/images/doForward_A.png";
                        BtnTransfer5.CssClass = "";
                    }

                    if (ddlTransfer5.Visible && vService.TransferUser != "")
                    {
                        ddlTransfer5.Items.Clear();
                        ax = new TblUsers();
                        ax.UserName = vService.TransferUser;
                        ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                              where uitm.UserName == ax.UserName
                              select uitm).FirstOrDefault();
                        if (ax != null)
                        {
                            ddlTransfer5.Items.Add(new ListItem(ax.FName, vService.TransferUser));
                            ddlTransfer5.SelectedIndex = 0;
                        }
                    }
                }
                else if (Level == "6")
                {
                    txtAgree6User.Text = vService.AgreeUser;
                    txtAgree6User.ToolTip = vService.AgreeUser;
                    txtAgree6UserDate.Text = vService.AgreeUserDate;
                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ax.UserName = vService.AgreeUser;
                    ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                          where uitm.UserName == ax.UserName
                          select uitm).FirstOrDefault();
                    if (ax != null) txtAgree6User.Text = ax.FName;

                    txtRemark6.Text = vService.AgreeRemark;
                    txtRemark6.ReadOnly = true;

                    //BtnAgree6.Enabled = false;
                    //BtnDisagree6.Enabled = false;
                    //BtnTransfer6.Enabled = false;
                    //ddlTransfer6.Enabled = false;

                    BtnAgree6.Visible = (vService.Agree == 1);
                    BtnDisagree6.Visible = (vService.Agree == 0);
                    BtnTransfer6.Visible = (vService.Agree == 2);
                    ddlTransfer6.Visible = false; // (vService.Agree == 2);
                    lblTransfer6.Visible = false; // (vService.Agree == 2);

                    if (BtnAgree6.Visible)
                    {
                        BtnAgree6.ImageUrl = "~/images/doAgree_641.png";
                        BtnAgree6.CssClass = "";
                    }
                    else if (BtnDisagree6.Visible)
                    {
                        BtnDisagree6.ImageUrl = "~/images/doDisAgree_641.png";
                        BtnDisagree6.CssClass = "";
                    }
                    else
                    {
                        BtnTransfer6.ImageUrl = "~/images/doForward_A.png";
                        BtnTransfer6.CssClass = "";
                    }

                    if (ddlTransfer6.Visible && vService.TransferUser != "")
                    {
                        ddlTransfer6.Items.Clear();
                        ax = new TblUsers();
                        ax.UserName = vService.TransferUser;
                        ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                              where uitm.UserName == ax.UserName
                              select uitm).FirstOrDefault();
                        if (ax != null)
                        {
                            ddlTransfer6.Items.Add(new ListItem(ax.FName, vService.TransferUser));
                            ddlTransfer6.SelectedIndex = 0;
                        }
                    }
                }
                else if (Level == "7")
                {
                    txtAgree7User.Text = vService.AgreeUser;
                    txtAgree7User.ToolTip = vService.AgreeUser;
                    txtAgree7UserDate.Text = vService.AgreeUserDate;
                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ax.UserName = vService.AgreeUser;
                    ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                          where uitm.UserName == ax.UserName
                          select uitm).FirstOrDefault();
                    if (ax != null) txtAgree7User.Text = ax.FName;

                    txtRemark7.Text = vService.AgreeRemark;
                    txtRemark7.ReadOnly = true;

                    //BtnAgree7.Enabled = false;
                    //BtnDisagree7.Enabled = false;
                    //BtnTransfer7.Enabled = false;
                    //ddlTransfer7.Enabled = false;

                    BtnAgree7.Visible = (vService.Agree == 1);
                    BtnDisagree7.Visible = (vService.Agree == 0);
                    BtnTransfer7.Visible = (vService.Agree == 2);
                    ddlTransfer7.Visible = false; // (vService.Agree == 2);
                    lblTransfer7.Visible = false; // (vService.Agree == 2);
                    if (ddlTransfer7.Visible && vService.TransferUser != "")
                    {
                        ddlTransfer7.Items.Clear();
                        ax = new TblUsers();
                        ax.UserName = vService.TransferUser;
                        ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                              where uitm.UserName == ax.UserName
                              select uitm).FirstOrDefault();
                        if (ax != null)
                        {
                            ddlTransfer7.Items.Add(new ListItem(ax.FName, vService.TransferUser));
                            ddlTransfer7.SelectedIndex = 0;
                        }
                    }
                }
                else if (Level == "8")
                {
                    txtAgree8User.Text = vService.AgreeUser;
                    txtAgree8User.ToolTip = vService.AgreeUser;
                    txtAgree8UserDate.Text = vService.AgreeUserDate;
                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ax.UserName = vService.AgreeUser;
                    ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                          where uitm.UserName == ax.UserName
                          select uitm).FirstOrDefault();
                    if (ax != null) txtAgree8User.Text = ax.FName;

                    txtRemark8.Text = vService.AgreeRemark;
                    txtRemark8.ReadOnly = true;

                    //BtnAgree8.Enabled = false;
                    //BtnDisagree8.Enabled = false;
                    //BtnTransfer8.Enabled = false;
                    //ddlTransfer8.Enabled = false;

                    BtnAgree8.Visible = (vService.Agree == 1);
                    BtnDisagree8.Visible = (vService.Agree == 0);
                    BtnTransfer8.Visible = (vService.Agree == 2);
                    ddlTransfer8.Visible = false; // (vService.Agree == 2);
                    lblTransfer8.Visible = false; // (vService.Agree == 2);
                    if (ddlTransfer8.Visible && vService.TransferUser != "")
                    {
                        ddlTransfer8.Items.Clear();
                        ax = new TblUsers();
                        ax.UserName = vService.TransferUser;
                        ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                              where uitm.UserName == ax.UserName
                              select uitm).FirstOrDefault();
                        if (ax != null)
                        {
                            ddlTransfer8.Items.Add(new ListItem(ax.FName, vService.TransferUser));
                            ddlTransfer8.SelectedIndex = 0;
                        }
                    }
                }
                else if (Level == "9")
                {
                    txtAgree9User.Text = vService.AgreeUser;
                    txtAgree9User.ToolTip = vService.AgreeUser;
                    txtAgree9UserDate.Text = vService.AgreeUserDate;
                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ax.UserName = vService.AgreeUser;
                    ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                          where uitm.UserName == ax.UserName
                          select uitm).FirstOrDefault();
                    if (ax != null) txtAgree9User.Text = ax.FName;

                    txtRemark9.Text = vService.AgreeRemark;
                    txtRemark9.ReadOnly = true;

                    //BtnAgree9.Enabled = false;
                    //BtnDisagree9.Enabled = false;
                    //BtnTransfer9.Enabled = false;
                    //ddlTransfer9.Enabled = false;

                    BtnAgree9.Visible = (vService.Agree == 1);
                    BtnDisagree9.Visible = (vService.Agree == 0);
                    BtnTransfer9.Visible = (vService.Agree == 2);
                    ddlTransfer9.Visible = false; // (vService.Agree == 2);
                    lblTransfer9.Visible = false; // (vService.Agree == 2);
                    if (ddlTransfer9.Visible && vService.TransferUser != "")
                    {
                        ddlTransfer9.Items.Clear();
                        ax = new TblUsers();
                        ax.UserName = vService.TransferUser;
                        ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                              where uitm.UserName == ax.UserName
                              select uitm).FirstOrDefault();
                        if (ax != null)
                        {
                            ddlTransfer9.Items.Add(new ListItem(ax.FName, vService.TransferUser));
                            ddlTransfer9.SelectedIndex = 0;
                        }
                    }
                }
                LoadAttachData(Level);
            }
        }

        public void EnableLevel(string Level)
        {
            bool vDisp = false;
            if (Request.QueryString["FMode"] != null)
                if (Request.QueryString["FMode"].ToString() != "0") vDisp = true;

            doAgree myAgree = new doAgree();
            myAgree.FType = short.Parse(DocType);
            myAgree.LocType = 0;
            myAgree.LocNumber = 0;
            myAgree.Number = int.Parse(txtDocNo.Text);
            myAgree.FNo = short.Parse(Level);
            myAgree = myAgree.FindFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myAgree == null) return;

            Agrees.Visible = true;
            veServices myService = new veServices();
            myService.DocType = short.Parse(DocType);
            myService.DocNo = int.Parse(txtDocNo.Text);
            myService = myService.find0(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

            switch (int.Parse(Level))
            {
                case 9:
                    {
                        txtDaysOff9.ReadOnly = false;
                        txtDiscount9.ReadOnly = false;
                        txtRemark9.ReadOnly = false;

                        if (false)
                        //if (BtnAgree9.CssClass == "" || BtnTransfer1.CssClass == "" || BtnDisagree9.CssClass == "")
                        {

                        }
                        else
                        {
                            BtnAgree9.Visible = true;
                            BtnAgree9.Enabled = true;
                            BtnDisagree9.Enabled = true;
                            BtnTransfer9.Enabled = true;
                            /*
                            ddlTransfer9.Enabled = true;
                            ddlTransfer9.Items.Clear();
                            ddlTransfer9.Items.Add(new ListItem("--- المحول إليه ---", "-1"));
                            ddlTransfer9.Items.Add(new ListItem(txtUserName.Text, txtUserName.ToolTip));
                            ddlTransfer9.Items.Add(new ListItem(txtAgree1User.Text, txtAgree1User.ToolTip));
                            ddlTransfer9.Items.Add(new ListItem(txtAgree2User.Text, txtAgree2User.ToolTip));
                            ddlTransfer9.Items.Add(new ListItem(txtAgree3User.Text, txtAgree3User.ToolTip));
                            ddlTransfer9.Items.Add(new ListItem(txtAgree4User.Text, txtAgree4User.ToolTip));
                            ddlTransfer9.Items.Add(new ListItem(txtAgree5User.Text, txtAgree5User.ToolTip));
                            ddlTransfer9.Items.Add(new ListItem(txtAgree6User.Text, txtAgree6User.ToolTip));
                            ddlTransfer9.Items.Add(new ListItem(txtAgree7User.Text, txtAgree7User.ToolTip));
                            ddlTransfer9.Items.Add(new ListItem(txtAgree8User.Text, txtAgree8User.ToolTip));
                             */

                            if (vDisp)
                            {
                                if (myService == null)
                                {
                                    BtnDisagree9.Visible = true;
                                    BtnTransfer9.Visible = true;
                                    lblTransfer9.Visible = false; // true;
                                    ddlTransfer9.Visible = false; // true;
                                }
                                else
                                {
                                    BtnDisagree9.Visible = (myService.SType8 == 0);
                                    BtnTransfer9.Visible = (myService.SType8 == 0);
                                    lblTransfer9.Visible = false; // (myService.SType8 == 0);
                                    ddlTransfer9.Visible = false; // (myService.SType8 == 0);
                                }
                            }

                            foreach (GridViewRow itm in grdAgree9A1.Rows)
                            {
                                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                                if (BtnDelete != null) BtnDelete.Visible = true;
                            }
                            FldAgree9A1.Enabled = true;
                            BtnAttachAgree9A1.Enabled = true;
                        }
                        break;
                    }
                case 8:
                    {
                        txtDaysOff8.ReadOnly = false;
                        txtDiscount8.ReadOnly = false;
                        txtRemark8.ReadOnly = false;
                        if (false)
                        //if (BtnAgree8.CssClass == "" || BtnTransfer8.CssClass == "" || BtnDisagree8.CssClass == "")
                        {

                        }
                        else
                        {
                            BtnAgree8.Visible = true;
                            BtnAgree8.Enabled = true;
                            BtnDisagree8.Enabled = true;
                            BtnTransfer8.Enabled = true;
                            /*
                            ddlTransfer8.Enabled = true;

                            ddlTransfer8.Items.Clear();
                            ddlTransfer8.Items.Add(new ListItem("--- المحول إليه ---", "-1"));
                            ddlTransfer8.Items.Add(new ListItem(txtUserName.Text, txtUserName.ToolTip));
                            ddlTransfer8.Items.Add(new ListItem(txtAgree1User.Text, txtAgree1User.ToolTip));
                            ddlTransfer8.Items.Add(new ListItem(txtAgree2User.Text, txtAgree2User.ToolTip));
                            ddlTransfer8.Items.Add(new ListItem(txtAgree3User.Text, txtAgree3User.ToolTip));
                            ddlTransfer8.Items.Add(new ListItem(txtAgree4User.Text, txtAgree4User.ToolTip));
                            ddlTransfer8.Items.Add(new ListItem(txtAgree5User.Text, txtAgree5User.ToolTip));
                            ddlTransfer8.Items.Add(new ListItem(txtAgree6User.Text, txtAgree6User.ToolTip));
                            ddlTransfer8.Items.Add(new ListItem(txtAgree7User.Text, txtAgree7User.ToolTip));
                             */

                            if (vDisp)
                            {
                                if (myService == null)
                                {
                                    BtnDisagree8.Visible = true;
                                    BtnTransfer8.Visible = true;
                                    lblTransfer8.Visible = false; // true;
                                    ddlTransfer8.Visible = false; // true;
                                }
                                else
                                {
                                    BtnDisagree8.Visible = (myService.SType8 == 0);
                                    BtnTransfer8.Visible = (myService.SType8 == 0);
                                    lblTransfer8.Visible = false; // (myService.SType8 == 0);
                                    ddlTransfer8.Visible = false; // (myService.SType8 == 0);
                                }
                            }

                            foreach (GridViewRow itm in grdAgree8A1.Rows)
                            {
                                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                                if (BtnDelete != null) BtnDelete.Visible = true;
                            }
                            FldAgree8A1.Enabled = true;
                            BtnAttachAgree8A1.Enabled = true;
                        }
                        break;
                    }
                case 7:
                    {
                        txtDaysOff7.ReadOnly = false;
                        txtDiscount7.ReadOnly = false;
                        txtRemark7.ReadOnly = false;
                        if (false)
                        //if (BtnAgree7.CssClass == "" || BtnTransfer7.CssClass == "" || BtnDisagree7.CssClass == "")
                        {

                        }
                        else
                        {
                            BtnAgree7.Visible = true;
                            BtnAgree7.Enabled = true;
                            BtnDisagree7.Enabled = true;
                            BtnTransfer7.Enabled = true;
                            /*
                            ddlTransfer7.Enabled = true;

                            ddlTransfer7.Items.Clear();
                            ddlTransfer7.Items.Add(new ListItem("--- المحول إليه ---", "-1"));
                            ddlTransfer7.Items.Add(new ListItem(txtUserName.Text, txtUserName.ToolTip));
                            ddlTransfer7.Items.Add(new ListItem(txtAgree1User.Text, txtAgree1User.ToolTip));
                            ddlTransfer7.Items.Add(new ListItem(txtAgree2User.Text, txtAgree2User.ToolTip));
                            ddlTransfer7.Items.Add(new ListItem(txtAgree3User.Text, txtAgree3User.ToolTip));
                            ddlTransfer7.Items.Add(new ListItem(txtAgree4User.Text, txtAgree4User.ToolTip));
                            ddlTransfer7.Items.Add(new ListItem(txtAgree5User.Text, txtAgree5User.ToolTip));
                            ddlTransfer7.Items.Add(new ListItem(txtAgree6User.Text, txtAgree6User.ToolTip));
                             */

                            if (vDisp)
                            {
                                if (myService == null)
                                {
                                    BtnDisagree7.Visible = true;
                                    BtnTransfer7.Visible = true;
                                    lblTransfer7.Visible = false; // true;
                                    ddlTransfer7.Visible = false; // true;
                                }
                                else
                                {
                                    BtnDisagree7.Visible = (myService.SType7 == 0);
                                    BtnTransfer7.Visible = (myService.SType7 == 0);
                                    lblTransfer7.Visible = false; // (myService.SType7 == 0);
                                    ddlTransfer7.Visible = false; // (myService.SType7 == 0);
                                }
                            }

                            foreach (GridViewRow itm in grdAgree7A1.Rows)
                            {
                                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                                if (BtnDelete != null) BtnDelete.Visible = true;
                            }
                            FldAgree7A1.Enabled = true;
                            BtnAttachAgree7A1.Enabled = true;
                        }
                        break;
                    }
                case 6:
                    {
                        txtDaysOff6.ReadOnly = false;
                        txtDiscount6.ReadOnly = false;
                        txtRemark6.ReadOnly = false;
                        if (false)
                        //if (BtnAgree6.CssClass == "" || BtnTransfer6.CssClass == "" || BtnDisagree6.CssClass == "")
                        {

                        }
                        else
                        {
                            BtnAgree6.Visible = true;
                            BtnDisagree6.Visible = true;
                            BtnTransfer6.Visible = true;
                            //lblTransfer6.Visible = true;
                            //ddlTransfer6.Visible = true;
                            BtnAgree6.Enabled = true;
                            BtnDisagree6.Enabled = true;
                            BtnTransfer6.Enabled = true;
                            /*
                            ddlTransfer6.Enabled = true;

                            ddlTransfer6.Items.Clear();
                            ddlTransfer6.Items.Add(new ListItem("--- المحول إليه ---", "-1"));
                            ddlTransfer6.Items.Add(new ListItem(txtUserName.Text, txtUserName.ToolTip));
                            ddlTransfer6.Items.Add(new ListItem(txtAgree1User.Text, txtAgree1User.ToolTip));
                            ddlTransfer6.Items.Add(new ListItem(txtAgree2User.Text, txtAgree2User.ToolTip));
                            ddlTransfer6.Items.Add(new ListItem(txtAgree3User.Text, txtAgree3User.ToolTip));
                            ddlTransfer6.Items.Add(new ListItem(txtAgree4User.Text, txtAgree4User.ToolTip));
                            ddlTransfer6.Items.Add(new ListItem(txtAgree5User.Text, txtAgree5User.ToolTip));
                             */

                            if (vDisp)
                            {
                                if (myService == null)
                                {
                                    BtnDisagree6.Visible = true;
                                    BtnTransfer6.Visible = true;
                                    lblTransfer6.Visible = false; // true;
                                    ddlTransfer6.Visible = false; // true;
                                }
                                else
                                {
                                    BtnDisagree6.Visible = (myService.SType6 == 0);
                                    BtnTransfer6.Visible = (myService.SType6 == 0);
                                    lblTransfer6.Visible = false; // (myService.SType6 == 0);
                                    ddlTransfer6.Visible = false; // (myService.SType6 == 0);
                                }
                            }

                            foreach (GridViewRow itm in grdAgree6A1.Rows)
                            {
                                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                                if (BtnDelete != null) BtnDelete.Visible = true;
                            }
                            FldAgree6A1.Enabled = true;
                            BtnAttachAgree6A1.Enabled = true;
                        }
                        break;
                    }
                case 5:
                    {
                        txtDaysOff5.ReadOnly = false;
                        txtDiscount5.ReadOnly = false;
                        txtRemark5.ReadOnly = false;

                        if (false)
                        //if (BtnAgree5.CssClass == "" || BtnTransfer5.CssClass == "" || BtnDisagree5.CssClass == "")
                        {

                        }
                        else
                        {
                            BtnAgree5.Visible = true;
                            BtnAgree5.Enabled = true;
                            BtnDisagree5.Enabled = true;
                            BtnTransfer5.Enabled = true;
                            /*
                            ddlTransfer5.Enabled = true;

                            ddlTransfer5.Items.Clear();
                            ddlTransfer5.Items.Add(new ListItem("--- المحول إليه ---", "-1"));
                            ddlTransfer5.Items.Add(new ListItem(txtUserName.Text, txtUserName.ToolTip));
                            ddlTransfer5.Items.Add(new ListItem(txtAgree1User.Text, txtAgree1User.ToolTip));
                            ddlTransfer5.Items.Add(new ListItem(txtAgree2User.Text, txtAgree2User.ToolTip));
                            ddlTransfer5.Items.Add(new ListItem(txtAgree3User.Text, txtAgree3User.ToolTip));
                            ddlTransfer5.Items.Add(new ListItem(txtAgree4User.Text, txtAgree4User.ToolTip));
                             */

                            if (vDisp)
                            {
                                if (myService == null)
                                {
                                    BtnDisagree5.Visible = true;
                                    BtnTransfer5.Visible = true;
                                    lblTransfer5.Visible = false; // true;
                                    ddlTransfer5.Visible = false; // true;
                                }
                                else
                                {
                                    BtnDisagree5.Visible = (myService.SType5 == 0);
                                    BtnTransfer5.Visible = (myService.SType5 == 0);
                                    lblTransfer5.Visible = false; // (myService.SType5 == 0);
                                    ddlTransfer5.Visible = false; // (myService.SType5 == 0);
                                }
                            }

                            foreach (GridViewRow itm in grdAgree5A1.Rows)
                            {
                                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                                if (BtnDelete != null) BtnDelete.Visible = true;
                            }
                            FldAgree5A1.Enabled = true;
                            BtnAttachAgree5A1.Enabled = true;
                        }
                        break;
                    }
                case 4:
                    {
                        txtDaysOff4.ReadOnly = false;
                        txtDiscount4.ReadOnly = false;
                        txtRemark4.ReadOnly = false;

                        if (false)
                        //if (BtnAgree4.CssClass == "" || BtnTransfer4.CssClass == "" || BtnDisagree4.CssClass == "")
                        {

                        }
                        else
                        {
                            BtnAgree4.Visible = true;
                            BtnAgree4.Enabled = true;
                            BtnDisagree4.Enabled = true;
                            BtnTransfer4.Enabled = true;
                            /*
                            ddlTransfer4.Enabled = true;

                            ddlTransfer4.Items.Clear();
                            ddlTransfer4.Items.Add(new ListItem("--- المحول إليه ---", "-1"));
                            ddlTransfer4.Items.Add(new ListItem(txtUserName.Text, txtUserName.ToolTip));
                            ddlTransfer4.Items.Add(new ListItem(txtAgree1User.Text, txtAgree1User.ToolTip));
                            ddlTransfer4.Items.Add(new ListItem(txtAgree2User.Text, txtAgree2User.ToolTip));
                            ddlTransfer4.Items.Add(new ListItem(txtAgree3User.Text, txtAgree3User.ToolTip));
                             */

                            if (vDisp)
                            {
                                if (myService == null)
                                {
                                    BtnDisagree4.Visible = true;
                                    BtnTransfer4.Visible = true;
                                    lblTransfer4.Visible = false; // true;
                                    ddlTransfer4.Visible = false; // true;
                                }
                                else
                                {
                                    BtnDisagree4.Visible = (myService.SType4 == 0);
                                    BtnTransfer4.Visible = (myService.SType4 == 0);
                                    lblTransfer4.Visible = false; // (myService.SType4 == 0);
                                    ddlTransfer4.Visible = false; // (myService.SType4 == 0);
                                }
                            }

                            foreach (GridViewRow itm in grdAgree4A1.Rows)
                            {
                                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                                if (BtnDelete != null) BtnDelete.Visible = true;
                            }
                            FldAgree4A1.Enabled = true;
                            BtnAttachAgree4A1.Enabled = true;
                        }
                        break;
                    }
                case 3:
                    {
                        txtDaysOff3.ReadOnly = false;
                        txtDiscount3.ReadOnly = false;
                        txtRemark3.ReadOnly = false;

                        if (false)
                        //if (BtnAgree3.CssClass == "" || BtnTransfer3.CssClass == "" || BtnDisagree3.CssClass == "")
                        {

                        }
                        else
                        {
                            BtnAgree3.Visible = true;
                            BtnAgree3.Enabled = true;
                            BtnDisagree3.Enabled = true;
                            BtnTransfer3.Enabled = true;
                            /*
                            ddlTransfer3.Enabled = true;

                            ddlTransfer3.Items.Clear();
                            ddlTransfer3.Items.Add(new ListItem("--- المحول إليه ---", "-1"));
                            ddlTransfer3.Items.Add(new ListItem(txtUserName.Text, txtUserName.ToolTip));
                            ddlTransfer3.Items.Add(new ListItem(txtAgree1User.Text, txtAgree1User.ToolTip));
                            ddlTransfer3.Items.Add(new ListItem(txtAgree2User.Text, txtAgree2User.ToolTip));
                             */

                            if (vDisp)
                            {
                                if (myService == null)
                                {
                                    BtnDisagree3.Visible = true;
                                    BtnTransfer3.Visible = true;
                                    lblTransfer3.Visible = false; // true;
                                    ddlTransfer3.Visible = false; // true;
                                }
                                else
                                {
                                    BtnDisagree3.Visible = (myService.SType3 == 0);
                                    BtnTransfer3.Visible = (myService.SType3 == 0);
                                    lblTransfer3.Visible = false; // (myService.SType3 == 0);
                                    ddlTransfer3.Visible = false; // (myService.SType3 == 0);
                                }
                            }


                            foreach (GridViewRow itm in grdAgree3A1.Rows)
                            {
                                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                                if (BtnDelete != null) BtnDelete.Visible = true;
                            }
                            FldAgree3A1.Enabled = true;
                            BtnAttachAgree3A1.Enabled = true;
                        }
                        break;
                    }
                case 2:
                    {
                        txtDaysOff2.ReadOnly = false;
                        txtDiscount2.ReadOnly = false;
                        txtRemark2.ReadOnly = false;

                        if (false)
                        //if (BtnAgree2.CssClass == "" || BtnTransfer2.CssClass == "" || BtnDisagree2.CssClass == "")
                        {

                        }
                        else
                        {
                            BtnAgree2.Visible = true;
                            BtnAgree2.Enabled = true;
                            BtnDisagree2.Enabled = true;
                            BtnTransfer2.Enabled = true;
                            /*
                            ddlTransfer2.Enabled = true;

                            ddlTransfer2.Items.Clear();
                            ddlTransfer2.Items.Add(new ListItem("--- المحول إليه ---", "-1"));
                            ddlTransfer2.Items.Add(new ListItem(txtUserName.Text, txtUserName.ToolTip));
                            ddlTransfer2.Items.Add(new ListItem(txtAgree1User.Text, txtAgree1User.ToolTip));
                             */

                            if (vDisp)
                            {
                                if (myService == null)
                                {
                                    BtnDisagree2.Visible = true;
                                    BtnTransfer2.Visible = true;
                                    lblTransfer2.Visible = false; // true;
                                    ddlTransfer2.Visible = false; // true;
                                }
                                else
                                {
                                    BtnDisagree2.Visible = (myService.SType2 == 0);
                                    BtnTransfer2.Visible = (myService.SType2 == 0);
                                    lblTransfer2.Visible = false; // (myService.SType2 == 0);
                                    ddlTransfer2.Visible = false; // (myService.SType2 == 0);
                                }
                            }

                            foreach (GridViewRow itm in grdAgree2A1.Rows)
                            {
                                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                                if (BtnDelete != null) BtnDelete.Visible = true;
                            }
                            FldAgree2A1.Enabled = true;
                            BtnAttachAgree2A1.Enabled = true;
                        }
                        break;
                    }
                case 1:
                    {
                        txtDaysOff1.ReadOnly = false;
                        txtDiscount1.ReadOnly = false;
                        txtRemark1.ReadOnly = false;

                        if (false)
                        //if (BtnAgree1.CssClass == "" || BtnTransfer1.CssClass == "" || BtnDisagree1.CssClass == "")
                        {

                        }
                        else
                        {
                            BtnAgree1.Visible = true;
                            BtnAgree1.Enabled = true;
                            BtnDisagree1.Enabled = true;
                            BtnTransfer1.Enabled = true;
                            /*
                            ddlTransfer1.Enabled = true;

                            ddlTransfer1.Items.Clear();
                            ddlTransfer1.Items.Add(new ListItem("--- المحول إليه ---", "-1"));
                            ddlTransfer1.Items.Add(new ListItem(txtUserName.Text, txtUserName.ToolTip));\
                             */

                            if (vDisp)
                            {
                                if (myService == null)
                                {
                                    BtnDisagree1.Visible = true;
                                    BtnTransfer1.Visible = true;
                                    lblTransfer1.Visible = false; // true;
                                    ddlTransfer1.Visible = false; // true;
                                }
                                else
                                {
                                    BtnDisagree1.Visible = (myService.SType1 == 0);
                                    BtnTransfer1.Visible = (myService.SType1 == 0);
                                    lblTransfer1.Visible = false; // (myService.SType1 == 0);
                                    ddlTransfer1.Visible = false; // (myService.SType1 == 0);
                                }
                            }

                            foreach (GridViewRow itm in grdAgree1A1.Rows)
                            {
                                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                                if (BtnDelete != null) BtnDelete.Visible = true;
                            }
                            FldAgree1A1.Enabled = true;
                            BtnAttachAgree1A1.Enabled = true;
                        }
                        break;
                    }
                case 0:
                    {
                        txtEmpCode.ReadOnly = false;
                        txtName.ReadOnly = false;
                        txtEmpCode2.ReadOnly = false;
                        txtName2.ReadOnly = false;
                        txtFNote.ReadOnly = false;
                        txtName.ReadOnly = false;
                        ddlFType.Enabled = true;
                        txtSDate.Enabled = true;
                        CalendarExtender1.Enabled = true;
                        CalendarExtender2.Enabled = true;
                        foreach (GridViewRow itm in grdAttach.Rows)
                        {
                            ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                            if (BtnDelete != null) BtnDelete.Visible = true;
                        }
                        FileUpload1.Enabled = true;
                        BtnAttach.Enabled = true;
                        EditMode(true);
                        break;
                    }
            }
        }

        public void ControlsOnOff(bool State)
        {
            try
            {
                txtDept.ReadOnly = !State;
                txtEmpCode.ReadOnly = !State;
                txtName.ReadOnly = !State;
                txtEmpCode2.ReadOnly = !State;
                txtName2.ReadOnly = !State;
                txtFNote.ReadOnly = !State;                
                ddlFType.Enabled = State;
                ddlSection.Enabled = State;
                //txtVacDays.ReadOnly = State;
                txtSDate.Enabled = State;
                CalendarExtender1.Enabled = State;
                CalendarExtender2.Enabled = State;
                foreach (GridViewRow itm in grdAttach.Rows)
                {
                    ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                    if (BtnDelete != null) BtnDelete.Visible = State;
                }
                //FileUpload1.Enabled = State;
                //BtnAttach.Enabled = State;

                if (divAgree1.Visible)
                {
                    txtDaysOff1.ReadOnly = !State;
                    txtDiscount1.ReadOnly = !State;
                    txtRemark1.ReadOnly = !State;

                    foreach (GridViewRow itm in grdAgree1A1.Rows)
                    {
                        ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                        if (BtnDelete != null) BtnDelete.Visible = State;
                    }
                    //FldAgree1A1.Enabled = State;
                    //BtnAttachAgree1A1.Enabled = State;

                }

                if (divAgree2.Visible)
                {
                    txtDaysOff2.ReadOnly = !State;
                    txtDiscount2.ReadOnly = !State;
                    txtRemark2.ReadOnly = !State;

                    foreach (GridViewRow itm in grdAgree2A1.Rows)
                    {
                        ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                        if (BtnDelete != null) BtnDelete.Visible = State;
                    }
                    //FldAgree2A1.Enabled = State;
                    //BtnAttachAgree2A1.Enabled = State;
                }

                if (divAgree3.Visible)
                {
                    txtDaysOff3.ReadOnly = !State;
                    txtDiscount3.ReadOnly = !State;
                    txtRemark3.ReadOnly = !State;

                    foreach (GridViewRow itm in grdAgree3A1.Rows)
                    {
                        ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                        if (BtnDelete != null) BtnDelete.Visible = State;
                    }
                    //FldAgree3A1.Enabled = State;
                    //BtnAttachAgree3A1.Enabled = State;
                }

                if (divAgree4.Visible)
                {
                    txtDaysOff4.ReadOnly = !State;
                    txtDiscount4.ReadOnly = !State;
                    txtRemark4.ReadOnly = !State;

                    foreach (GridViewRow itm in grdAgree4A1.Rows)
                    {
                        ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                        if (BtnDelete != null) BtnDelete.Visible = State;
                    }
                    //FldAgree4A1.Enabled = State;
                    //BtnAttachAgree4A1.Enabled = State;
                }

                if (divAgree5.Visible)
                {
                    txtDaysOff5.ReadOnly = !State;
                    txtDiscount5.ReadOnly = !State;
                    txtRemark5.ReadOnly = !State;

                    foreach (GridViewRow itm in grdAgree5A1.Rows)
                    {
                        ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                        if (BtnDelete != null) BtnDelete.Visible = State;
                    }
                    //FldAgree5A1.Enabled = State;
                    //BtnAttachAgree5A1.Enabled = State;
                }

                if (divAgree6.Visible)
                {
                    txtDaysOff6.ReadOnly = !State;
                    txtDiscount6.ReadOnly = !State;
                    txtRemark6.ReadOnly = !State;

                    foreach (GridViewRow itm in grdAgree6A1.Rows)
                    {
                        ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                        if (BtnDelete != null) BtnDelete.Visible = State;
                    }
                    //FldAgree6A1.Enabled = State;
                    //BtnAttachAgree6A1.Enabled = State;
                }

                if (divAgree7.Visible)
                {
                    txtDaysOff7.ReadOnly = !State;
                    txtDiscount7.ReadOnly = !State;
                    txtRemark7.ReadOnly = !State;

                    foreach (GridViewRow itm in grdAgree7A1.Rows)
                    {
                        ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                        if (BtnDelete != null) BtnDelete.Visible = State;
                    }
                    //FldAgree7A1.Enabled = State;
                    //BtnAttachAgree7A1.Enabled = State;
                }

                if (divAgree8.Visible)
                {
                    txtDaysOff8.ReadOnly = !State;
                    txtDiscount8.ReadOnly = !State;
                    txtRemark8.ReadOnly = !State;

                    foreach (GridViewRow itm in grdAgree8A1.Rows)
                    {
                        ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                        if (BtnDelete != null) BtnDelete.Visible = State;
                    }
                    //FldAgree8A1.Enabled = State;
                    //BtnAttachAgree8A1.Enabled = State;
                }

                if (divAgree9.Visible)
                {
                    txtDaysOff9.ReadOnly = !State;
                    txtDiscount9.ReadOnly = !State;
                    txtRemark9.ReadOnly = !State;

                    foreach (GridViewRow itm in grdAgree9A1.Rows)
                    {
                        ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                        if (BtnDelete != null) BtnDelete.Visible = State;
                    }
                    //FldAgree9A1.Enabled = State;
                    //BtnAttachAgree9A1.Enabled = State;
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


        protected void BtnClear_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                NewMode();
                LblCodesResult.Text = "";
                txtDept.Text = "";
                txtJob.Text = "";
                txtNational.Text = "";
                txtEmpCode.Text = "";
                txtName.Text = "";
                txtEmpCode2.Text = "";
                txtName2.Text = "";
                txtFNote.Text = "";                
                ddlFType.SelectedIndex = 0;
                ddlFType_SelectedIndexChanged(sender, e);
                ddlSection.SelectedIndex = 0;
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                txtSDate.Text = "";
                txtFDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                txtFTime.Text = String.Format("{0:HH:mm:ss}", moh.Nows());
                grdAttach.DataSource = null;
                grdAttach.DataBind();

                eServices myInv = new eServices();
                myInv.DocType = short.Parse(DocType);
                int? i1 = myInv.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (i1 == 0 || i1 == null)
                {
                    i1 = 1;
                }
                else
                {
                    i1++;
                }
                txtDocNo.Text = i1.ToString();

                ClearAgree();
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

        public void ClearAgree()
        {
            Agrees.Visible = false;

            BtnAgree1.ImageUrl = "~/images/Agree_641.png";
            BtnAgree2.ImageUrl = "~/images/Agree_641.png";
            BtnAgree3.ImageUrl = "~/images/Agree_641.png";
            BtnAgree4.ImageUrl = "~/images/Agree_641.png";
            BtnAgree5.ImageUrl = "~/images/Agree_641.png";
            BtnAgree6.ImageUrl = "~/images/Agree_641.png";
            BtnAgree7.ImageUrl = "~/images/Agree_641.png";
            BtnAgree8.ImageUrl = "~/images/Agree_641.png";
            BtnAgree9.ImageUrl = "~/images/Agree_641.png";

            BtnDisagree1.ImageUrl = "~/images/DisAgree_641.png";
            BtnDisagree2.ImageUrl = "~/images/DisAgree_641.png";
            BtnDisagree3.ImageUrl = "~/images/DisAgree_641.png";
            BtnDisagree4.ImageUrl = "~/images/DisAgree_641.png";
            BtnDisagree5.ImageUrl = "~/images/DisAgree_641.png";
            BtnDisagree6.ImageUrl = "~/images/DisAgree_641.png";
            BtnDisagree7.ImageUrl = "~/images/DisAgree_641.png";
            BtnDisagree8.ImageUrl = "~/images/DisAgree_641.png";
            BtnDisagree9.ImageUrl = "~/images/DisAgree_641.png";

            BtnTransfer1.ImageUrl = "~/images/Forward_A.png";
            BtnTransfer2.ImageUrl = "~/images/Forward_A.png";
            BtnTransfer3.ImageUrl = "~/images/Forward_A.png";
            BtnTransfer4.ImageUrl = "~/images/Forward_A.png";
            BtnTransfer5.ImageUrl = "~/images/Forward_A.png";
            BtnTransfer6.ImageUrl = "~/images/Forward_A.png";
            BtnTransfer7.ImageUrl = "~/images/Forward_A.png";
            BtnTransfer8.ImageUrl = "~/images/Forward_A.png";
            BtnTransfer9.ImageUrl = "~/images/Forward_A.png";

            BtnAgree1.CssClass = "ops";
            BtnAgree2.CssClass = "ops";
            BtnAgree3.CssClass = "ops";
            BtnAgree4.CssClass = "ops";
            BtnAgree5.CssClass = "ops";
            BtnAgree6.CssClass = "ops";
            BtnAgree7.CssClass = "ops";
            BtnAgree8.CssClass = "ops";
            BtnAgree9.CssClass = "ops";

            BtnDisagree1.CssClass = "ops";
            BtnDisagree2.CssClass = "ops";
            BtnDisagree3.CssClass = "ops";
            BtnDisagree4.CssClass = "ops";
            BtnDisagree5.CssClass = "ops";
            BtnDisagree6.CssClass = "ops";
            BtnDisagree7.CssClass = "ops";
            BtnDisagree8.CssClass = "ops";
            BtnDisagree9.CssClass = "ops";

            BtnTransfer1.CssClass = "ops";
            BtnTransfer2.CssClass = "ops";
            BtnTransfer3.CssClass = "ops";
            BtnTransfer4.CssClass = "ops";
            BtnTransfer5.CssClass = "ops";
            BtnTransfer6.CssClass = "ops";
            BtnTransfer7.CssClass = "ops";
            BtnTransfer8.CssClass = "ops";
            BtnTransfer9.CssClass = "ops";

            BtnAgree1.Visible = true;
            BtnAgree2.Visible = true;
            BtnAgree3.Visible = true;
            BtnAgree4.Visible = true;
            BtnAgree5.Visible = true;
            BtnAgree6.Visible = true;
            BtnAgree7.Visible = true;
            BtnAgree8.Visible = true;
            BtnAgree9.Visible = true;

            BtnDisagree1.Visible = true;
            BtnDisagree2.Visible = true;
            BtnDisagree3.Visible = true;
            BtnDisagree4.Visible = true;
            BtnDisagree5.Visible = true;
            BtnDisagree6.Visible = true;
            BtnDisagree7.Visible = true;
            BtnDisagree8.Visible = true;
            BtnDisagree9.Visible = true;

            BtnTransfer1.Visible = true;
            BtnTransfer2.Visible = true;
            BtnTransfer3.Visible = true;
            BtnTransfer4.Visible = true;
            BtnTransfer5.Visible = true;
            BtnTransfer6.Visible = true;
            BtnTransfer7.Visible = true;
            BtnTransfer8.Visible = true;
            BtnTransfer9.Visible = true;

            BtnAgree1.Enabled = false;
            BtnAgree2.Enabled = false;
            BtnAgree3.Enabled = false;
            BtnAgree4.Enabled = false;
            BtnAgree5.Enabled = false;
            BtnAgree6.Enabled = false;
            BtnAgree7.Enabled = false;
            BtnAgree8.Enabled = false;
            BtnAgree9.Enabled = false;

            BtnDisagree1.Enabled = false;
            BtnDisagree2.Enabled = false;
            BtnDisagree3.Enabled = false;
            BtnDisagree4.Enabled = false;
            BtnDisagree5.Enabled = false;
            BtnDisagree6.Enabled = false;
            BtnDisagree7.Enabled = false;
            BtnDisagree8.Enabled = false;
            BtnDisagree9.Enabled = false;

            BtnTransfer1.Enabled = false;
            BtnTransfer2.Enabled = false;
            BtnTransfer3.Enabled = false;
            BtnTransfer4.Enabled = false;
            BtnTransfer5.Enabled = false;
            BtnTransfer6.Enabled = false;
            BtnTransfer7.Enabled = false;
            BtnTransfer8.Enabled = false;
            BtnTransfer9.Enabled = false;

            ddlTransfer1.Enabled = false;
            ddlTransfer2.Enabled = false;
            ddlTransfer3.Enabled = false;
            ddlTransfer4.Enabled = false;
            ddlTransfer5.Enabled = false;
            ddlTransfer6.Enabled = false;
            ddlTransfer7.Enabled = false;
            ddlTransfer8.Enabled = false;
            ddlTransfer9.Enabled = false;

            LblCodesResult1.Text = "";
            LblCodesResult2.Text = "";
            LblCodesResult3.Text = "";
            LblCodesResult4.Text = "";
            LblCodesResult5.Text = "";
            LblCodesResult6.Text = "";
            LblCodesResult7.Text = "";
            LblCodesResult8.Text = "";
            LblCodesResult9.Text = "";

            divAgree1.Visible = false;
            txtDaysOff1.Text = "";
            txtDiscount1.Text = "";
            txtRemark1.Text = "";
            txtAgree1User.Text = "";
            txtAgree1UserDate.Text = "";
            grdAgree1A1.DataSource = null;
            grdAgree1A1.DataBind();

            divAgree2.Visible = false;
            txtDaysOff2.Text = "";
            txtDiscount2.Text = "";
            txtRemark2.Text = "";
            txtAgree2User.Text = "";
            txtAgree2UserDate.Text = "";
            grdAgree2A1.DataSource = null;
            grdAgree2A1.DataBind();

            divAgree3.Visible = false;
            txtDaysOff3.Text = "";
            txtDiscount3.Text = "";
            txtRemark3.Text = "";
            txtAgree3User.Text = "";
            txtAgree3UserDate.Text = "";
            grdAgree3A1.DataSource = null;
            grdAgree3A1.DataBind();

            divAgree4.Visible = false;
            txtDaysOff4.Text = "";
            txtDiscount4.Text = "";
            txtRemark4.Text = "";
            txtAgree4User.Text = "";
            txtAgree4UserDate.Text = "";
            grdAgree4A1.DataSource = null;
            grdAgree4A1.DataBind();

            divAgree5.Visible = false;
            txtDaysOff5.Text = "";
            txtDiscount5.Text = "";
            txtRemark5.Text = "";
            txtAgree5User.Text = "";
            txtAgree5UserDate.Text = "";
            grdAgree5A1.DataSource = null;
            grdAgree5A1.DataBind();

            divAgree6.Visible = false;
            txtDaysOff6.Text = "";
            txtDiscount6.Text = "";
            txtRemark6.Text = "";
            txtAgree6User.Text = "";
            txtAgree6UserDate.Text = "";
            grdAgree6A1.DataSource = null;
            grdAgree6A1.DataBind();

            divAgree7.Visible = false;
            txtDaysOff7.Text = "";
            txtDiscount7.Text = "";
            txtRemark7.Text = "";
            txtAgree7User.Text = "";
            txtAgree7UserDate.Text = "";
            grdAgree7A1.DataSource = null;
            grdAgree7A1.DataBind();

            divAgree8.Visible = false;
            txtDaysOff8.Text = "";
            txtDiscount8.Text = "";
            txtRemark8.Text = "";
            txtAgree8User.Text = "";
            txtAgree8UserDate.Text = "";
            grdAgree8A1.DataSource = null;
            grdAgree8A1.DataBind();

            divAgree9.Visible = false;
            txtDaysOff9.Text = "";
            txtDiscount9.Text = "";
            txtRemark9.Text = "";
            txtAgree9User.Text = "";
            txtAgree9UserDate.Text = "";
            grdAgree9A1.DataSource = null;
            grdAgree9A1.DataBind();
            grdCodes.DataSource = null;
            grdCodes.DataBind();

        }

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (txtEmpCode.Text != "")
                    {
                        SEmp myEmp = new SEmp();
                        myEmp.EmpCode = int.Parse(txtEmpCode.Text);
                        myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myEmp == null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم الموظف غير معرف من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>','');", true);
                            return;
                        }
                        else if (myEmp.Status != 0)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "يجب أن تكون حالة الموظف على رأس العمل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>','');", true);
                            return;
                        }
                        if (txtSDate.Text == "")
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "يجب إدخال التاريخ";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>','');", true);
                            return;
                        }
                        else  //if (CheckVac())
                        {
                            eServices myService = new eServices();
                            myService.DocType = short.Parse(DocType);
                            myService.EmpCode = int.Parse(txtEmpCode.Text);
                            myService = myService.GetActive(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myService != null)
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "توجد معاملة حاليه تحت الأجراء لنفس الموظف " +myService.DocNo.ToString();
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }

                            myService = new eServices();
                            myService.DocType = short.Parse(DocType);
                            myService.DocNo = int.Parse(txtDocNo.Text);
                            myService = myService.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myService != null)
                            {
                                if (myService.UserName == txtUserName.ToolTip)
                                {
                                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                    LblCodesResult.Text = "رقم المعاملة مكرر";
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                    return;
                                }
                                else
                                {
                                    myService = new eServices();
                                    myService.DocType = short.Parse(DocType);
                                    myService.DocNo = int.Parse(txtDocNo.Text);
                                    int? i = myService.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (i == 0 || i == null)
                                    {
                                        i = 1;
                                    }
                                    else
                                    {
                                        i++;
                                    }
                                    txtDocNo.Text = i.ToString();
                                }
                            }
                            myService = new eServices();
                            myService.DocType = moh.StrToShort(DocType);
                            myService.DocNo = moh.StrToInt(txtDocNo.Text);
                            myService.DocDate = txtFDate.Text;
                            myService.DocTime = txtFTime.Text;
                            myService.EmpCode = moh.StrToInt(txtEmpCode.Text);
                            myService.Field1 = moh.StrToInt(txtEmpCode2.Text);
                            myService.Field01 = ddlSection.SelectedValue;
                            myService.Notes2 = ddlFType.SelectedValue;
                            //myService.Notes2 = txtNotes2.Text;
                            myService.Notes = txtFNote.Text;
                            myService.Status = 0;
                            myService.SDate = txtSDate.Text;
                            myService.UserName = txtUserName.ToolTip;
                            myService.UserDate = txtUserDate.Text;
                            if (myService.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                                {
                                    Transactions UserTran = new Transactions();
                                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                    UserTran.UserName = Session["CurrentUser"].ToString();
                                    UserTran.FormName = "البوابة الالكترونية";
                                    UserTran.FormAction = "اضافة";
                                    UserTran.Description = "اضافة " + DocName + " للموظف رقم " + txtEmpCode.Text + " طلب رقم " + txtDocNo.Text;
                                    UserTran.IP = IPNetworking.GetIP4Address();
                                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                }

                                //----------------------------------------------------------------------------------
                                veServices myeService = new veServices();
                                myeService.DocType = short.Parse(DocType);
                                myeService.DocNo = int.Parse(txtDocNo.Text);
                                myeService = myeService.find0(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (myeService != null)
                                {
                                    if (myeService.FStep1 != "-1")
                                    {
                                        doAgree myAgree = new doAgree();
                                        myAgree.FType = short.Parse(DocType);
                                        myAgree.LocType = 0;
                                        myAgree.LocNumber = 0;
                                        myAgree.Number = int.Parse(txtDocNo.Text);
                                        myAgree.FNo = 1;
                                        if (myeService.FStep1 == "1")
                                        {
                                            myAgree.UserName = myeService.Manag1;
                                            myAgree.UserName2 = myeService.Manag2;
                                            myAgree.UserGroup = "";
                                        }
                                        else
                                        {
                                            myAgree.UserName = myeService.FStep1;
                                            myAgree.UserName2 = "";
                                            myAgree.UserGroup = myeService.FStep1;
                                        }
                                        myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    }
                                }
                                //------------------------------------------------------------------------------------


                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                                string vNumber = txtDocNo.Text;
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(1,'" + LblCodesResult.Text + "');", true);
                                // Print ****????
                                BtnClear_Click(sender, e);
                                PrintMe(vNumber);
                            }
                            else
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ اثناء أضافة البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>');", true);
                            }
                        }
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب إدخال رقم الموظف";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>','');", true);
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

        protected void txtEmpCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtEmpCode.Text != "")
                {
                    vSEmp myvEmp = new vSEmp();
                    SEmp myEmp = new SEmp();
                    myEmp.EmpCode = int.Parse(txtEmpCode.Text);
                    myvEmp = myEmp.vfind(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myvEmp != null)
                    {
                        if (((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("admin") ||
                            myvEmp.UserName == txtUserName.ToolTip || myvEmp.Manag1 == txtUserName.ToolTip || myvEmp.Manag2 == txtUserName.ToolTip
                            || txtUserName.ToolTip != Session["CurrentUser"].ToString())
                        {
                            txtName.Text = myvEmp.Name;
                            txtNational.Text = myvEmp.NatName1;
                            txtJob.Text = myvEmp.JobName1;
                            txtDept.Text = myvEmp.SectionName1;
                            ddlFType.Focus();
                            LoadDocData();
                        }
                        else
                        {
                            txtEmpCode.Text = "";
                            txtName.Text = "";
                            txtNational.Text = "";
                            txtJob.Text = "";
                            txtDept.Text = "";

                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لا توجد لك صلاحية";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>','');", true);
                        }
                    }
                    else
                    {
                        txtEmpCode.Text = "";
                        txtName.Text = "";
                        txtNational.Text = "";
                        txtJob.Text = "";
                        txtDept.Text = "";
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

        public void SearchDoc(string DocNo)
        {
            try
            {
                eServices myService = new eServices();
                myService.DocType = short.Parse(DocType);
                myService.DocNo = int.Parse(DocNo);
                myService = myService.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myService != null)
                {
                    txtDocNo.Text = DocNo;
                    txtFDate.Text = myService.DocDate;
                    txtFTime.Text = myService.DocTime;
                    txtEmpCode.Text = myService.EmpCode.ToString();
                    ddlFType.SelectedValue = myService.Notes2;
                    ddlFType_SelectedIndexChanged(BtnAgree1, null);
                    ddlSection.SelectedValue = myService.Field01;
                    txtFNote.Text = myService.Notes;
                    txtSDate.Text = myService.SDate;
                    txtEmpCode2.Text = myService.Field1.ToString();
                    if (moh.StrToInt(txtEmpCode2.Text) > 0)
                    {
                        SEmp myEmp = new SEmp();
                        myEmp.EmpCode = moh.StrToInt(txtEmpCode2.Text);
                        myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myEmp != null) txtName2.Text = myEmp.Name;
                    }
                    //txtNotes2.Text = myService.Notes2;
                    txtUserDate.Text = myService.UserDate;
                    txtUserName.ToolTip = myService.UserName;
                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ax.UserName = myService.UserName;
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
                    txtEmpCode_TextChanged(txtEmpCode, null);
                    LoadAttachData("0");
                    bool vDisp = false;
                    if (Request.QueryString["FMode"] != null)
                        if (Request.QueryString["FMode"].ToString() != "0") vDisp = true;
                    if (!vDisp) if (myService.Status > 0) SetDisplayLevel(myService.Status.ToString(), DocNo);
                    EditMode(false);
                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = "البوابة الالكترونية";
                        UserTran.FormAction = "عرض";
                        UserTran.Description = "عرض بيانات " + DocName + " للموظف رقم " + txtEmpCode.Text + " طلب رقم " + txtDocNo.Text;
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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

        public void LoadDocData()
        {
            try
            {
                eServices myService = new eServices();
                myService.EmpCode = int.Parse(txtEmpCode.Text);
                myService.DocType = short.Parse(DocType);
                grdCodes.DataSource = myService.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                grdCodes.DataBind();
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

        protected void grdCodes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                string DocNo = grdCodes.DataKeys[e.NewSelectedIndex]["DocNo"].ToString();
                ClearAgree();
                SearchDoc(DocNo);
                e.NewSelectedIndex = -1;
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

        protected void grdCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdCodes.PageIndex = e.NewPageIndex;
                LoadDocData();
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

        public void PrintMe(String Number)
        {
            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "طلب نقل موظف", "طباعة", "طباعة طلب نقل موظف رقم " + Number, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=9" + DocType + "&DocType=" + DocType + "&AreaNo=" + AreaNo + "&Number=" + Number + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
            return;
        }

        protected void BtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    PrintMe(txtDocNo.Text);
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

        //--------------------Attach ------------------------------------------------------------------------------------------------
        #region Attach
        protected void BtnAttach_Click(object sender, ImageClickEventArgs e)
        {
            DoAttach(FileUpload1, "0");
        }

        protected void grdAttach_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string FNo = grdAttach.DataKeys[e.RowIndex]["FNo"].ToString();
                DeleteAttach(FNo, "0");
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

        protected void grdAgree1A1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string FNo = grdAgree1A1.DataKeys[e.RowIndex]["FNo"].ToString();
                DeleteAttach(FNo, "1");
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

        protected void grdAgree2A1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string FNo = grdAgree2A1.DataKeys[e.RowIndex]["FNo"].ToString();
                DeleteAttach(FNo, "2");
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

        protected void grdAgree3A1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string FNo = grdAgree3A1.DataKeys[e.RowIndex]["FNo"].ToString();
                DeleteAttach(FNo, "3");
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

        protected void grdAgree4A1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string FNo = grdAgree4A1.DataKeys[e.RowIndex]["FNo"].ToString();
                DeleteAttach(FNo, "4");
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

        protected void grdAgree5A1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string FNo = grdAgree5A1.DataKeys[e.RowIndex]["FNo"].ToString();
                DeleteAttach(FNo, "5");
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

        protected void grdAgree6A1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string FNo = grdAgree6A1.DataKeys[e.RowIndex]["FNo"].ToString();
                DeleteAttach(FNo, "6");
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

        protected void grdAgree7A1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string FNo = grdAgree7A1.DataKeys[e.RowIndex]["FNo"].ToString();
                DeleteAttach(FNo, "7");
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

        protected void grdAgree8A1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string FNo = grdAgree8A1.DataKeys[e.RowIndex]["FNo"].ToString();
                DeleteAttach(FNo, "8");
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

        protected void grdAgree9A1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string FNo = grdAgree9A1.DataKeys[e.RowIndex]["FNo"].ToString();
                DeleteAttach(FNo, "9");
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

        public void LoadAttachData(string step)
        {
            if (this.txtDocNo.Text != "")
            {
                Arch myArch = new Arch();
                myArch.LocNumber = short.Parse(step);
                myArch.DocType = int.Parse("9" + DocType.ToString());
                myArch.Number = int.Parse(this.txtDocNo.Text);
                if (step == "0")
                {
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
                else if (step == "1")
                {
                    grdAgree1A1.DataSource = myArch.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    grdAgree1A1.DataBind();
                    if (((List<Arch>)grdAgree1A1.DataSource).Count > 0)
                    {
                        cpeDemo1.Collapsed = false;
                        cpeDemo1.ClientState = "false";
                    }
                    else
                    {
                        cpeDemo1.Collapsed = true;
                        cpeDemo1.ClientState = "true";
                    }
                }
                else if (step == "2")
                {
                    grdAgree2A1.DataSource = myArch.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    grdAgree2A1.DataBind();
                    if (((List<Arch>)grdAgree2A1.DataSource).Count > 0)
                    {
                        cpeDemo2.Collapsed = false;
                        cpeDemo2.ClientState = "false";
                    }
                    else
                    {
                        cpeDemo2.Collapsed = true;
                        cpeDemo2.ClientState = "true";
                    }
                }
                else if (step == "3")
                {
                    grdAgree3A1.DataSource = myArch.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    grdAgree3A1.DataBind();
                    if (((List<Arch>)grdAgree3A1.DataSource).Count > 0)
                    {
                        cpeDemo3.Collapsed = false;
                        cpeDemo3.ClientState = "false";
                    }
                    else
                    {
                        cpeDemo3.Collapsed = true;
                        cpeDemo3.ClientState = "true";
                    }
                }
                else if (step == "4")
                {
                    grdAgree4A1.DataSource = myArch.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    grdAgree4A1.DataBind();
                    if (((List<Arch>)grdAgree4A1.DataSource).Count > 0)
                    {
                        cpeDemo4.Collapsed = false;
                        cpeDemo4.ClientState = "false";
                    }
                    else
                    {
                        cpeDemo4.Collapsed = true;
                        cpeDemo4.ClientState = "true";
                    }
                }
                else if (step == "5")
                {
                    grdAgree5A1.DataSource = myArch.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    grdAgree5A1.DataBind();
                    if (((List<Arch>)grdAgree5A1.DataSource).Count > 0)
                    {
                        cpeDemo5.Collapsed = false;
                        cpeDemo5.ClientState = "false";
                    }
                    else
                    {
                        cpeDemo5.Collapsed = true;
                        cpeDemo5.ClientState = "true";
                    }
                }
                else if (step == "6")
                {
                    grdAgree6A1.DataSource = myArch.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    grdAgree6A1.DataBind();
                    if (((List<Arch>)grdAgree6A1.DataSource).Count > 0)
                    {
                        cpeDemo6.Collapsed = false;
                        cpeDemo6.ClientState = "false";
                    }
                    else
                    {
                        cpeDemo6.Collapsed = true;
                        cpeDemo6.ClientState = "true";
                    }
                }
                else if (step == "7")
                {
                    grdAgree7A1.DataSource = myArch.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    grdAgree7A1.DataBind();
                    if (((List<Arch>)grdAgree7A1.DataSource).Count > 0)
                    {
                        cpeDemo7.Collapsed = false;
                        cpeDemo7.ClientState = "false";
                    }
                    else
                    {
                        cpeDemo7.Collapsed = true;
                        cpeDemo7.ClientState = "true";
                    }
                }
                else if (step == "8")
                {
                    grdAgree8A1.DataSource = myArch.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    grdAgree8A1.DataBind();
                    if (((List<Arch>)grdAgree8A1.DataSource).Count > 0)
                    {
                        cpeDemo8.Collapsed = false;
                        cpeDemo8.ClientState = "false";
                    }
                    else
                    {
                        cpeDemo8.Collapsed = true;
                        cpeDemo8.ClientState = "true";
                    }
                }
                else if (step == "9")
                {
                    grdAgree9A1.DataSource = myArch.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    grdAgree9A1.DataBind();
                    if (((List<Arch>)grdAgree9A1.DataSource).Count > 0)
                    {
                        cpeDemo9.Collapsed = false;
                        cpeDemo9.ClientState = "false";
                    }
                    else
                    {
                        cpeDemo9.Collapsed = true;
                        cpeDemo9.ClientState = "true";
                    }
                }
            }
        }

        protected void BtnAttachAgree1A1_Click(object sender, ImageClickEventArgs e)
        {
            DoAttach(FldAgree1A1, "1");
        }

        protected void BtnAttachAgree2A1_Click(object sender, ImageClickEventArgs e)
        {
            DoAttach(FldAgree2A1, "2");
        }

        protected void BtnAttachAgree3A1_Click(object sender, ImageClickEventArgs e)
        {
            DoAttach(FldAgree3A1, "3");
        }

        protected void BtnAttachAgree4A1_Click(object sender, ImageClickEventArgs e)
        {
            DoAttach(FldAgree4A1, "4");
        }

        protected void BtnAttachAgree5A1_Click(object sender, ImageClickEventArgs e)
        {
            DoAttach(FldAgree5A1, "5");
        }

        protected void BtnAttachAgree6A1_Click(object sender, ImageClickEventArgs e)
        {
            DoAttach(FldAgree6A1, "6");
        }

        protected void BtnAttachAgree7A1_Click(object sender, ImageClickEventArgs e)
        {
            DoAttach(FldAgree7A1, "7");
        }

        protected void BtnAttachAgree8A1_Click(object sender, ImageClickEventArgs e)
        {
            DoAttach(FldAgree8A1, "8");
        }

        protected void BtnAttachAgree9A1_Click(object sender, ImageClickEventArgs e)
        {
            DoAttach(FldAgree9A1, "9");
        }

        public void DoAttach(FileUpload fp, string step)
        {
            if (fp.HasFile)
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
                        fp.SaveAs(mySetting.ImagePath + FileName);

                        Arch myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(step);
                        myArch.Number = int.Parse(this.txtDocNo.Text);
                        myArch.DocType = int.Parse("9" + DocType.ToString());

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(step);
                        myArch.DocType = int.Parse("9" + DocType.ToString());
                        myArch.Number = int.Parse(this.txtDocNo.Text);
                        myArch.FileName = fp.FileName;
                        myArch.FileName2 = mySetting.ImagePath2 + FileName;
                        myArch.FNo = (short)i;
                        myArch.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), this.Page.Title, "اضافة مرفقات", "اضافة مرفقات للطلب رقم " + txtDocNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        LoadAttachData(step);
                    }
                    //    LblCodesResult.Text = "File name: " + FileUpload1.PostedFile.FileName + "<br>" + FileUpload1.PostedFile.ContentLength + " kb<br>" + "Content type: " + FileUpload1.PostedFile.ContentType;
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

        public void DeleteAttach(string FNo, string step)
        {
            Arch myArch = new Arch();
            myArch.Branch = short.Parse(Session["Branch"].ToString());
            myArch.LocNumber = short.Parse(step);
            myArch.DocType = int.Parse("9" + DocType.ToString());
            myArch.Number = int.Parse(this.txtDocNo.Text);
            myArch.FNo = short.Parse(FNo);
            myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), this.Page.Title, "الغاء مرفقات", "الغاء مرفقات للطلب رقم " + txtDocNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
            LoadAttachData(step);
        }
        #endregion Attach

        protected void BtnAgree1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string vOption = e.CommandArgument.ToString();
                eServicesAgree myServiceAgree = new eServicesAgree();
                myServiceAgree.DocType = short.Parse(DocType);
                myServiceAgree.DocNo = int.Parse(txtDocNo.Text);
                myServiceAgree.FNo = short.Parse(e.CommandArgument.ToString());
                myServiceAgree = myServiceAgree.findFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myServiceAgree != null) myServiceAgree.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                //----------------------------------------------------------------------------------
                veServices myService = new veServices();
                myService.DocType = short.Parse(DocType);
                myService.DocNo = int.Parse(txtDocNo.Text);
                myService = myService.find0(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                //------------------------------------------------------------------------------------
                myServiceAgree = new eServicesAgree();
                myServiceAgree.DocType = short.Parse(DocType);
                myServiceAgree.DocNo = int.Parse(txtDocNo.Text);
                myServiceAgree.FNo = short.Parse(e.CommandArgument.ToString());


                if (vOption == "1")
                {
                    //----------------------------------------------------------------------------------
                    if (myService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 0;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 1;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 2;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myService.FStep2 != "-1")
                        {
                            myAgree = new doAgree();
                            myAgree.FType = short.Parse(DocType);
                            myAgree.LocType = 0;
                            myAgree.LocNumber = 0;
                            myAgree.Number = int.Parse(txtDocNo.Text);
                            myAgree.FNo = 2;
                            if (myService.FStep2 == "1")
                            {
                                myAgree.UserName = myService.Manag1;
                                myAgree.UserName2 = myService.Manag2;
                                myAgree.UserGroup = "";
                            }
                            else
                            {
                                myAgree.UserName = myService.FStep2;
                                myAgree.UserName2 = "";
                                myAgree.UserGroup = myService.FStep2;
                            }
                            myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                    }
                    //----------------------------------------------------------------------------------

                    txtAgree1User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree1User.Text = Session["FullUser"].ToString();
                    txtAgree1UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult1.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult1.Text = "تم الموافقة على المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark1.Text;
                    myServiceAgree.AgreeUser = txtAgree1User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree1UserDate.Text;
                    if ((bool)myService.Action1) doAgree();
                }
                else if (vOption == "2")
                {
                    //----------------------------------------------------------------------------------
                    if (myService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 2;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 3;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myService.FStep3 != "-1")
                        {
                            myAgree = new doAgree();
                            myAgree.FType = short.Parse(DocType);
                            myAgree.LocType = 0;
                            myAgree.LocNumber = 0;
                            myAgree.Number = int.Parse(txtDocNo.Text);
                            myAgree.FNo = 3;
                            if (myService.FStep3 == "1")
                            {
                                myAgree.UserName = myService.Manag1;
                                myAgree.UserName2 = myService.Manag2;
                                myAgree.UserGroup = "";
                            }
                            else
                            {
                                myAgree.UserName = myService.FStep3;
                                myAgree.UserName2 = "";
                                myAgree.UserGroup = myService.FStep3;
                            }
                            myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                    }
                    //----------------------------------------------------------------------------------

                    txtAgree2User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree2User.Text = Session["FullUser"].ToString();
                    txtAgree2UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult2.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult2.Text = "تم الموافقة على المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark2.Text;
                    myServiceAgree.AgreeUser = txtAgree2User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree2UserDate.Text;

                    if ((bool)myService.Action2) doAgree();
                }
                else if (vOption == "3")
                {
                    //----------------------------------------------------------------------------------
                    if (myService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 3;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 4;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myService.FStep4 != "-1")
                        {
                            myAgree = new doAgree();
                            myAgree.FType = short.Parse(DocType);
                            myAgree.LocType = 0;
                            myAgree.LocNumber = 0;
                            myAgree.Number = int.Parse(txtDocNo.Text);
                            myAgree.FNo = 4;
                            if (myService.FStep4 == "1")
                            {
                                myAgree.UserName = myService.Manag1;
                                myAgree.UserName2 = myService.Manag2;
                                myAgree.UserGroup = "";
                            }
                            else
                            {
                                myAgree.UserName = myService.FStep4;
                                myAgree.UserName2 = "";
                                myAgree.UserGroup = myService.FStep4;
                            }
                            myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                    }
                    //----------------------------------------------------------------------------------

                    txtAgree3User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree3User.Text = Session["FullUser"].ToString();
                    txtAgree3UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult3.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult3.Text = "تم الموافقة على المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark3.Text;
                    myServiceAgree.AgreeUser = txtAgree3User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree3UserDate.Text;
                    if ((bool)myService.Action3) doAgree();
                }
                else if (vOption == "4")
                {
                    //----------------------------------------------------------------------------------
                    if (myService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 4;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 5;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myService.FStep5 != "-1")
                        {
                            myAgree = new doAgree();
                            myAgree.FType = short.Parse(DocType);
                            myAgree.LocType = 0;
                            myAgree.LocNumber = 0;
                            myAgree.Number = int.Parse(txtDocNo.Text);
                            myAgree.FNo = 5;
                            if (myService.FStep5 == "1")
                            {
                                myAgree.UserName = myService.Manag1;
                                myAgree.UserName2 = myService.Manag2;
                                myAgree.UserGroup = "";
                            }
                            else
                            {
                                myAgree.UserName = myService.FStep5;
                                myAgree.UserName2 = "";
                                myAgree.UserGroup = myService.FStep5;
                            }
                            myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                    }
                    //----------------------------------------------------------------------------------

                    txtAgree4User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree4User.Text = Session["FullUser"].ToString();
                    txtAgree4UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult4.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult4.Text = "تم الموافقة على المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark4.Text;
                    myServiceAgree.AgreeUser = txtAgree4User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree4UserDate.Text;
                    if ((bool)myService.Action4) doAgree();
                }
                else if (vOption == "5")
                {
                    //----------------------------------------------------------------------------------
                    if (myService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 5;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 6;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myService.FStep6 != "-1")
                        {
                            myAgree = new doAgree();
                            myAgree.FType = short.Parse(DocType);
                            myAgree.LocType = 0;
                            myAgree.LocNumber = 0;
                            myAgree.Number = int.Parse(txtDocNo.Text);
                            myAgree.FNo = 6;
                            if (myService.FStep6 == "1")
                            {
                                myAgree.UserName = myService.Manag1;
                                myAgree.UserName2 = myService.Manag2;
                                myAgree.UserGroup = "";
                            }
                            else
                            {
                                myAgree.UserName = myService.FStep6;
                                myAgree.UserName2 = "";
                                myAgree.UserGroup = myService.FStep6;
                            }
                            myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                    }
                    //----------------------------------------------------------------------------------

                    txtAgree5User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree5User.Text = Session["FullUser"].ToString();
                    txtAgree5UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult5.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult5.Text = "تم الموافقة على المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark5.Text;
                    myServiceAgree.AgreeUser = txtAgree5User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree5UserDate.Text;
                    if ((bool)myService.Action5) doAgree();
                }
                else if (vOption == "6")
                {
                    //----------------------------------------------------------------------------------
                    if (myService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 6;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 7;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myService.FStep7 != "-1")
                        {
                            myAgree = new doAgree();
                            myAgree.FType = short.Parse(DocType);
                            myAgree.LocType = 0;
                            myAgree.LocNumber = 0;
                            myAgree.Number = int.Parse(txtDocNo.Text);
                            myAgree.FNo = 7;
                            if (myService.FStep7 == "1")
                            {
                                myAgree.UserName = myService.Manag1;
                                myAgree.UserName2 = myService.Manag2;
                                myAgree.UserGroup = "";
                            }
                            else
                            {
                                myAgree.UserName = myService.FStep7;
                                myAgree.UserName2 = "";
                                myAgree.UserGroup = myService.FStep7;
                            }
                            myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                    }
                    //----------------------------------------------------------------------------------

                    txtAgree6User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree6User.Text = Session["FullUser"].ToString();
                    txtAgree6UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult6.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult6.Text = "تم الموافقة على المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark6.Text;
                    myServiceAgree.AgreeUser = txtAgree6User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree6UserDate.Text;
                    if ((bool)myService.Action6) doAgree();
                }
                else if (vOption == "7")
                {
                    //----------------------------------------------------------------------------------
                    if (myService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 7;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 8;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myService.FStep8 != "-1")
                        {
                            myAgree = new doAgree();
                            myAgree.FType = short.Parse(DocType);
                            myAgree.LocType = 0;
                            myAgree.LocNumber = 0;
                            myAgree.Number = int.Parse(txtDocNo.Text);
                            myAgree.FNo = 8;
                            if (myService.FStep8 == "1")
                            {
                                myAgree.UserName = myService.Manag1;
                                myAgree.UserName2 = myService.Manag2;
                                myAgree.UserGroup = "";
                            }
                            else
                            {
                                myAgree.UserName = myService.FStep8;
                                myAgree.UserName2 = "";
                                myAgree.UserGroup = myService.FStep8;
                            }
                            myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                    }
                    //----------------------------------------------------------------------------------

                    txtAgree7User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree7User.Text = Session["FullUser"].ToString();
                    txtAgree7UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult7.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult7.Text = "تم الموافقة على المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark7.Text;
                    myServiceAgree.AgreeUser = txtAgree7User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree7UserDate.Text;
                    if ((bool)myService.Action7) doAgree();
                }
                else if (vOption == "8")
                {
                    //----------------------------------------------------------------------------------
                    /*
                    if (myeService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 8;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 9;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 9;
                        if (myeService.FStep9 == "1")
                        {
                            myAgree.UserName = myeService.Manag1;
                            myAgree.UserName2 = myeService.Manag2;
                            myAgree.UserGroup = "";
                        }
                        else
                        {
                            myAgree.UserName = myeService.FStep9;
                            myAgree.UserName2 = "";
                            myAgree.UserGroup = myeService.FStep9;
                        }
                        myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                     */
                    //----------------------------------------------------------------------------------

                    txtAgree8User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree8User.Text = Session["FullUser"].ToString();
                    txtAgree8UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult8.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult8.Text = "تم الموافقة على المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark8.Text;
                    myServiceAgree.AgreeUser = txtAgree8User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree8UserDate.Text;
                    if ((bool)myService.Action8) doAgree();
                }
                else if (vOption == "9")
                {
                    txtAgree9User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree9User.Text = Session["FullUser"].ToString();
                    txtAgree9UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult9.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult9.Text = "تم الموافقة على المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark9.Text;
                    myServiceAgree.AgreeUser = txtAgree9User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree9UserDate.Text;
                    if ((bool)myService.Action8) doAgree();
                }

                eServices myService2 = new eServices();
                if (myService != null)
                {
                    myService2.Status = short.Parse(vOption);
                    if (vOption == "1" && myService.FStep2 == "-1") myService2.Status = 99;
                    else if (vOption == "2" && myService.FStep3 == "-1") myService2.Status = 99;
                    else if (vOption == "3" && myService.FStep4 == "-1") myService2.Status = 99;
                    else if (vOption == "4" && myService.FStep5 == "-1") myService2.Status = 99;
                    else if (vOption == "5" && myService.FStep6 == "-1") myService2.Status = 99;
                    else if (vOption == "6" && myService.FStep7 == "-1") myService2.Status = 99;
                    else if (vOption == "7" && myService.FStep8 == "-1") myService2.Status = 99;
                    else if (vOption == "8") myService2.Status = 99;
                    else if (vOption == "9") myService2.Status = 99;
                    myService2.DocType = short.Parse(DocType);
                    myService2.DocNo = int.Parse(txtDocNo.Text);
                    myService2.TransferUser = "";
                    if (myService2.StatusUpdate(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        myServiceAgree.FNo = short.Parse(e.CommandArgument.ToString());


                        myServiceAgree.Agree = 1;
                        if (myServiceAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.Description = "تم الموافقة على " + DocName + " رقم  " + txtDocNo.Text;
                            UserTran.FormAction = "الموافقة";
                            UserTran.FormName = DocName;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                            ShowAgreeButton(vOption);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage("تم الموافقة على المستند بنجاح", false, true), true);
                        }
                        else
                        {
                            SetError(vOption);
                        }
                    }
                    else
                    {
                        SetError(vOption);
                    }
                }
                else
                {
                    SetError(vOption);
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }

        }

        public void ShowAgreeButton(string vOption)
        {
            if (vOption == "1")
            {
                BtnAgree1.Enabled = false;
                BtnDisagree1.Visible = false;
                BtnTransfer1.Visible = false;
                lblTransfer1.Visible = false;
                ddlTransfer1.Visible = false;
            }
            else if (vOption == "2")
            {
                BtnAgree2.Enabled = false;
                BtnDisagree2.Visible = false;
                BtnTransfer2.Visible = false;
                lblTransfer2.Visible = false;
                ddlTransfer2.Visible = false;
            }
            else if (vOption == "3")
            {
                BtnAgree3.Enabled = false;
                BtnDisagree3.Visible = false;
                BtnTransfer3.Visible = false;
                lblTransfer3.Visible = false;
                ddlTransfer3.Visible = false;
            }
            else if (vOption == "4")
            {
                BtnAgree4.Enabled = false;
                BtnDisagree4.Visible = false;
                BtnTransfer4.Visible = false;
                lblTransfer4.Visible = false;
                ddlTransfer4.Visible = false;
            }
            else if (vOption == "5")
            {
                BtnAgree5.Enabled = false;
                BtnDisagree5.Visible = false;
                BtnTransfer5.Visible = false;
                lblTransfer5.Visible = false;
                ddlTransfer5.Visible = false;
            }
            else if (vOption == "6")
            {
                BtnAgree6.Enabled = false;
                BtnDisagree6.Visible = false;
                BtnTransfer6.Visible = false;
                lblTransfer6.Visible = false;
                ddlTransfer6.Visible = false;
            }
            else if (vOption == "7")
            {
                BtnAgree7.Enabled = false;
                BtnDisagree7.Visible = false;
                BtnTransfer7.Visible = false;
                lblTransfer7.Visible = false;
                ddlTransfer7.Visible = false;
            }
            else if (vOption == "8")
            {
                BtnAgree8.Enabled = false;
                BtnDisagree8.Visible = false;
                BtnTransfer8.Visible = false;
                lblTransfer8.Visible = false;
                ddlTransfer8.Visible = false;
            }
            else if (vOption == "9")
            {
                BtnAgree9.Enabled = false;
                BtnDisagree9.Visible = false;
                BtnTransfer9.Visible = false;
                lblTransfer9.Visible = false;
                ddlTransfer9.Visible = false;
            }
        }

        public void ShowDisAgreeButton(string vOption)
        {
            if (vOption == "1")
            {
                BtnAgree1.Visible = false;
                BtnDisagree1.Enabled = false;
                BtnTransfer1.Visible = false;
                lblTransfer1.Visible = false;
                ddlTransfer1.Visible = false;
            }
            else if (vOption == "2")
            {
                BtnAgree2.Visible = false;
                BtnDisagree2.Enabled = false;
                BtnTransfer2.Visible = false;
                lblTransfer2.Visible = false;
                ddlTransfer2.Visible = false;
            }
            else if (vOption == "3")
            {
                BtnAgree3.Visible = false;
                BtnDisagree3.Enabled = false;
                BtnTransfer3.Visible = false;
                lblTransfer3.Visible = false;
                ddlTransfer3.Visible = false;
            }
            else if (vOption == "4")
            {
                BtnAgree4.Visible = false;
                BtnDisagree4.Enabled = false;
                BtnTransfer4.Visible = false;
                lblTransfer4.Visible = false;
                ddlTransfer4.Visible = false;
            }
            else if (vOption == "5")
            {
                BtnAgree5.Visible = false;
                BtnDisagree5.Enabled = false;
                BtnTransfer5.Visible = false;
                lblTransfer5.Visible = false;
                ddlTransfer5.Visible = false;
            }
            else if (vOption == "6")
            {
                BtnAgree6.Visible = false;
                BtnDisagree6.Enabled = false;
                BtnTransfer6.Visible = false;
                lblTransfer6.Visible = false;
                ddlTransfer6.Visible = false;
            }
            else if (vOption == "7")
            {
                BtnAgree7.Visible = false;
                BtnDisagree7.Enabled = false;
                BtnTransfer7.Visible = false;
                lblTransfer7.Visible = false;
                ddlTransfer7.Visible = false;
            }
            else if (vOption == "8")
            {
                BtnAgree8.Visible = false;
                BtnDisagree8.Enabled = false;
                BtnTransfer8.Visible = false;
                lblTransfer8.Visible = false;
                ddlTransfer8.Visible = false;
            }
            else if (vOption == "9")
            {
                BtnAgree9.Visible = false;
                BtnDisagree9.Enabled = false;
                BtnTransfer9.Visible = false;
                lblTransfer9.Visible = false;
                ddlTransfer9.Visible = false;
            }
        }

        public void ShowTransferButton(string vOption)
        {
            if (vOption == "1")
            {
                BtnAgree1.Visible = false;
                BtnDisagree1.Visible = false;

                BtnTransfer1.Visible = true;
                lblTransfer1.Visible = false; // true;
                ddlTransfer1.Visible = false; // true;

                //ddlTransfer1.Enabled = false;
                BtnTransfer1.Enabled = false;
            }
            else if (vOption == "2")
            {
                BtnAgree2.Visible = false;
                BtnDisagree2.Visible = false;

                BtnTransfer2.Visible = true;
                lblTransfer2.Visible = false; // true;
                ddlTransfer2.Visible = false; // true;

                //ddlTransfer2.Enabled = false;
                BtnTransfer2.Enabled = false;
            }
            else if (vOption == "3")
            {
                BtnAgree3.Visible = false;
                BtnDisagree3.Visible = false;

                BtnTransfer3.Visible = true;
                lblTransfer3.Visible = false; // true;
                ddlTransfer3.Visible = false; // true;

                //ddlTransfer3.Enabled = false;
                BtnTransfer3.Enabled = false;
            }
            else if (vOption == "4")
            {
                BtnAgree4.Visible = false;
                BtnDisagree4.Visible = false;

                BtnTransfer4.Visible = true;
                lblTransfer4.Visible = false; // true;
                ddlTransfer4.Visible = false; // true;

                //ddlTransfer4.Enabled = false;
                BtnTransfer4.Enabled = false;
            }
            else if (vOption == "5")
            {
                BtnAgree5.Visible = false;
                BtnDisagree5.Visible = false;

                BtnTransfer5.Visible = true;
                lblTransfer5.Visible = false; // true;
                ddlTransfer5.Visible = false; // true;

                //ddlTransfer5.Enabled = false;
                BtnTransfer5.Enabled = false;
            }
            else if (vOption == "6")
            {
                BtnAgree6.Visible = false;
                BtnDisagree6.Visible = false;

                BtnTransfer6.Visible = true;
                lblTransfer6.Visible = false; // true;
                ddlTransfer6.Visible = false; // true;

                //ddlTransfer6.Enabled = false;
                BtnTransfer6.Enabled = false;
            }
            else if (vOption == "7")
            {
                BtnAgree7.Visible = false;
                BtnDisagree7.Visible = false;

                BtnTransfer7.Visible = true;
                lblTransfer7.Visible = false; // true;
                ddlTransfer7.Visible = false; // true;

                //ddlTransfer7.Enabled = false;
                BtnTransfer7.Enabled = false;
            }
            else if (vOption == "8")
            {
                BtnAgree8.Visible = false;
                BtnDisagree8.Visible = false;

                BtnTransfer8.Visible = true;
                lblTransfer8.Visible = false; // true;
                ddlTransfer8.Visible = false; // true;

                //ddlTransfer8.Enabled = false;
                BtnTransfer8.Enabled = false;
            }
            else if (vOption == "9")
            {
                BtnAgree9.Visible = false;
                BtnDisagree9.Visible = false;

                BtnTransfer9.Visible = true;
                lblTransfer9.Visible = false; // true;
                ddlTransfer9.Visible = false; // true;

                //ddlTransfer9.Enabled = false;
                BtnTransfer9.Enabled = false;
            }
        }

        public void SetError(string vOption)
        {
            if (vOption == "1")
            {
                LblCodesResult1.ForeColor = System.Drawing.Color.Red;
                LblCodesResult1.Text = "خطأ أثناء أعتماد المستند ... حاول مرة أخرى";
            }
            else if (vOption == "2")
            {
                LblCodesResult2.ForeColor = System.Drawing.Color.Red;
                LblCodesResult2.Text = "خطأ أثناء أعتماد المستند ... حاول مرة أخرى";
            }
            else if (vOption == "3")
            {
                LblCodesResult3.ForeColor = System.Drawing.Color.Red;
                LblCodesResult3.Text = "خطأ أثناء أعتماد المستند ... حاول مرة أخرى";
            }
            else if (vOption == "4")
            {
                LblCodesResult4.ForeColor = System.Drawing.Color.Red;
                LblCodesResult4.Text = "خطأ أثناء أعتماد المستند ... حاول مرة أخرى";
            }
            else if (vOption == "5")
            {
                LblCodesResult5.ForeColor = System.Drawing.Color.Red;
                LblCodesResult5.Text = "خطأ أثناء أعتماد المستند ... حاول مرة أخرى";
            }
            else if (vOption == "6")
            {
                LblCodesResult6.ForeColor = System.Drawing.Color.Red;
                LblCodesResult6.Text = "خطأ أثناء أعتماد المستند ... حاول مرة أخرى";
            }
            else if (vOption == "7")
            {
                LblCodesResult7.ForeColor = System.Drawing.Color.Red;
                LblCodesResult7.Text = "خطأ أثناء أعتماد المستند ... حاول مرة أخرى";
            }
            else if (vOption == "8")
            {
                LblCodesResult8.ForeColor = System.Drawing.Color.Red;
                LblCodesResult8.Text = "خطأ أثناء أعتماد المستند ... حاول مرة أخرى";
            }
            else if (vOption == "9")
            {
                LblCodesResult9.ForeColor = System.Drawing.Color.Red;
                LblCodesResult9.Text = "خطأ أثناء أعتماد المستند ... حاول مرة أخرى";
            }
        }

        protected void BtnDisagree1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string vOption = e.CommandArgument.ToString();
                eServicesAgree myServiceAgree = new eServicesAgree();
                myServiceAgree.DocType = short.Parse(DocType);
                myServiceAgree.DocNo = int.Parse(txtDocNo.Text);
                myServiceAgree.FNo = short.Parse(e.CommandArgument.ToString());
                myServiceAgree = myServiceAgree.findFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myServiceAgree != null) myServiceAgree.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                //----------------------------------------------------------------------------------
                veServices myeService = new veServices();
                myeService.DocType = short.Parse(DocType);
                myeService.DocNo = int.Parse(txtDocNo.Text);
                myeService = myeService.find0(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                //------------------------------------------------------------------------------------

                myServiceAgree = new eServicesAgree();
                myServiceAgree.DocType = short.Parse(DocType);
                myServiceAgree.DocNo = int.Parse(txtDocNo.Text);
                myServiceAgree.FNo = short.Parse(e.CommandArgument.ToString());

                if (vOption == "1")
                {
                    //----------------------------------------------------------------------------------
                    if (myeService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 0;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 1;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    //----------------------------------------------------------------------------------
                    txtAgree1User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree1User.Text = Session["FullUser"].ToString();
                    txtAgree1UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult1.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult1.Text = "تم رفض المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark1.Text;
                    myServiceAgree.AgreeUser = txtAgree1User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree1UserDate.Text;
                }
                else if (vOption == "2")
                {
                    //----------------------------------------------------------------------------------
                    if (myeService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 1;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 2;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    //----------------------------------------------------------------------------------
                    txtAgree2User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree2User.Text = Session["FullUser"].ToString();
                    txtAgree2UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult2.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult2.Text = "تم رفض المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark2.Text;
                    myServiceAgree.AgreeUser = txtAgree2User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree2UserDate.Text;
                }
                else if (vOption == "3")
                {
                    //----------------------------------------------------------------------------------
                    if (myeService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 2;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 3;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    //----------------------------------------------------------------------------------
                    txtAgree3User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree3User.Text = Session["FullUser"].ToString();
                    txtAgree3UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult3.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult3.Text = "تم رفض المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark3.Text;
                    myServiceAgree.AgreeUser = txtAgree3User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree3UserDate.Text;
                }
                else if (vOption == "4")
                {
                    //----------------------------------------------------------------------------------
                    if (myeService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 3;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 4;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    //----------------------------------------------------------------------------------
                    txtAgree4User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree4User.Text = Session["FullUser"].ToString();
                    txtAgree4UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult4.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult4.Text = "تم رفض المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark4.Text;
                    myServiceAgree.AgreeUser = txtAgree4User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree4UserDate.Text;
                }
                else if (vOption == "5")
                {
                    //----------------------------------------------------------------------------------
                    if (myeService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 4;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 5;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    //----------------------------------------------------------------------------------
                    txtAgree5User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree5User.Text = Session["FullUser"].ToString();
                    txtAgree5UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult5.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult5.Text = "تم رفض المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark5.Text;
                    myServiceAgree.AgreeUser = txtAgree5User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree5UserDate.Text;
                }
                else if (vOption == "6")
                {
                    //----------------------------------------------------------------------------------
                    if (myeService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 5;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 6;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    //----------------------------------------------------------------------------------
                    txtAgree6User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree6User.Text = Session["FullUser"].ToString();
                    txtAgree6UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult6.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult6.Text = "تم رفض المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark6.Text;
                    myServiceAgree.AgreeUser = txtAgree6User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree6UserDate.Text;
                }
                else if (vOption == "7")
                {
                    //----------------------------------------------------------------------------------
                    if (myeService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 6;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 7;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    //----------------------------------------------------------------------------------
                    txtAgree7User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree7User.Text = Session["FullUser"].ToString();
                    txtAgree7UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult7.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult7.Text = "تم رفض المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark7.Text;
                    myServiceAgree.AgreeUser = txtAgree7User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree7UserDate.Text;
                }
                else if (vOption == "8")
                {
                    //----------------------------------------------------------------------------------
                    if (myeService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 6;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 7;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    //----------------------------------------------------------------------------------
                    txtAgree8User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree8User.Text = Session["FullUser"].ToString();
                    txtAgree8UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult8.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult8.Text = "تم رفض المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark8.Text;
                    myServiceAgree.AgreeUser = txtAgree8User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree8UserDate.Text;
                }
                else if (vOption == "9")
                {
                    //----------------------------------------------------------------------------------
                    if (myeService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 7;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 8;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    //----------------------------------------------------------------------------------
                    txtAgree9User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree9User.Text = Session["FullUser"].ToString();
                    txtAgree9UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult9.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult9.Text = "تم رفض المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark9.Text;
                    myServiceAgree.AgreeUser = txtAgree9User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree9UserDate.Text;

                }

                eServices myService = new eServices();
                myService.DocType = short.Parse(DocType);
                myService.DocNo = int.Parse(txtDocNo.Text);
                myService = myService.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myService != null)
                {
                    myService.Status = -1;
                    myService.TransferUser = "";
                    if (myService.StatusUpdate(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        myServiceAgree.FNo = short.Parse(e.CommandArgument.ToString());
                        myServiceAgree.Agree = 0;
                        if (myServiceAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.Description = "تم الرفض على " + DocName + " رقم  " + txtDocNo.Text;
                            UserTran.FormAction = "الرفض";
                            UserTran.FormName = DocName;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                            ShowDisAgreeButton(vOption);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage("تم رفض المستند بنجاح", false, true), true);
                        }
                        else
                        {
                            SetError(vOption);
                        }
                    }
                    else
                    {
                        SetError(vOption);
                    }
                }
                else
                {
                    SetError(vOption);
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void BtnTransfer1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string vOption = e.CommandArgument.ToString();
                eServicesAgree myServiceAgree = new eServicesAgree();
                myServiceAgree.DocType = short.Parse(DocType);
                myServiceAgree.DocNo = int.Parse(txtDocNo.Text);
                myServiceAgree.FNo = short.Parse(e.CommandArgument.ToString());
                myServiceAgree = myServiceAgree.findFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myServiceAgree != null) myServiceAgree.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                //----------------------------------------------------------------------------------
                veServices myeService = new veServices();
                myeService.DocType = short.Parse(DocType);
                myeService.DocNo = int.Parse(txtDocNo.Text);
                myeService = myeService.find0(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                //------------------------------------------------------------------------------------

                myServiceAgree = new eServicesAgree();
                myServiceAgree.DocType = short.Parse(DocType);
                myServiceAgree.DocNo = int.Parse(txtDocNo.Text);
                myServiceAgree.FNo = short.Parse(e.CommandArgument.ToString());

                if (vOption == "1")
                {
                    //----------------------------------------------------------------------------------
                    if (myeService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 0;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 1;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 0;
                        myAgree.UserName = txtUserName.ToolTip;
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    //----------------------------------------------------------------------------------


                    txtAgree1User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree1User.Text = Session["FullUser"].ToString();
                    txtAgree1UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult1.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult1.Text = "تم إعادة المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark1.Text;
                    myServiceAgree.AgreeUser = txtAgree1User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree1UserDate.Text;
                }
                else if (vOption == "2")
                {
                    //----------------------------------------------------------------------------------
                    if (myeService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 1;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 2;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 1;
                        if (myeService.FStep1 == "1")
                        {
                            myAgree.UserName = myeService.Manag1;
                            myAgree.UserName2 = myeService.Manag2;
                            myAgree.UserGroup = "";
                        }
                        else
                        {
                            myAgree.UserName = myeService.FStep1;
                            myAgree.UserName2 = "";
                            myAgree.UserGroup = myeService.FStep1;
                        }
                        myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    //----------------------------------------------------------------------------------

                    txtAgree2User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree2User.Text = Session["FullUser"].ToString();
                    txtAgree2UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult2.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult2.Text = "تم إعادة المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark2.Text;
                    myServiceAgree.AgreeUser = txtAgree2User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree2UserDate.Text;
                }
                else if (vOption == "3")
                {
                    //----------------------------------------------------------------------------------
                    if (myeService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 2;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 3;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 2;
                        if (myeService.FStep2 == "1")
                        {
                            myAgree.UserName = myeService.Manag1;
                            myAgree.UserName2 = myeService.Manag2;
                            myAgree.UserGroup = "";
                        }
                        else
                        {
                            myAgree.UserName = myeService.FStep2;
                            myAgree.UserName2 = "";
                            myAgree.UserGroup = myeService.FStep2;
                        }
                        myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    //----------------------------------------------------------------------------------

                    txtAgree3User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree3User.Text = Session["FullUser"].ToString();
                    txtAgree3UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult3.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult3.Text = "تم إعادة المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark3.Text;
                    myServiceAgree.AgreeUser = txtAgree3User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree3UserDate.Text;
                }
                else if (vOption == "4")
                {
                    //----------------------------------------------------------------------------------
                    if (myeService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 3;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 4;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 3;
                        if (myeService.FStep3 == "1")
                        {
                            myAgree.UserName = myeService.Manag1;
                            myAgree.UserName2 = myeService.Manag2;
                            myAgree.UserGroup = "";
                        }
                        else
                        {
                            myAgree.UserName = myeService.FStep3;
                            myAgree.UserName2 = "";
                            myAgree.UserGroup = myeService.FStep3;
                        }
                        myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    //----------------------------------------------------------------------------------

                    txtAgree4User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree4User.Text = Session["FullUser"].ToString();
                    txtAgree4UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult4.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult4.Text = "تم إعادة المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark4.Text;
                    myServiceAgree.AgreeUser = txtAgree4User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree4UserDate.Text;
                }
                else if (vOption == "5")
                {
                    //----------------------------------------------------------------------------------
                    if (myeService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 4;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 5;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 4;
                        if (myeService.FStep4 == "1")
                        {
                            myAgree.UserName = myeService.Manag1;
                            myAgree.UserName2 = myeService.Manag2;
                            myAgree.UserGroup = "";
                        }
                        else
                        {
                            myAgree.UserName = myeService.FStep4;
                            myAgree.UserName2 = "";
                            myAgree.UserGroup = myeService.FStep4;
                        }
                        myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    //----------------------------------------------------------------------------------

                    txtAgree5User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree5User.Text = Session["FullUser"].ToString();
                    txtAgree5UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult5.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult5.Text = "تم إعادة المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark5.Text;
                    myServiceAgree.AgreeUser = txtAgree5User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree5UserDate.Text;
                }
                else if (vOption == "6")
                {
                    //----------------------------------------------------------------------------------
                    if (myeService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 5;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 6;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 5;
                        if (myeService.FStep5 == "1")
                        {
                            myAgree.UserName = myeService.Manag1;
                            myAgree.UserName2 = myeService.Manag2;
                            myAgree.UserGroup = "";
                        }
                        else
                        {
                            myAgree.UserName = myeService.FStep5;
                            myAgree.UserName2 = "";
                            myAgree.UserGroup = myeService.FStep5;
                        }
                        myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    //----------------------------------------------------------------------------------

                    txtAgree6User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree6User.Text = Session["FullUser"].ToString();
                    txtAgree6UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult6.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult6.Text = "تم إعادة المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark6.Text;
                    myServiceAgree.AgreeUser = txtAgree6User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree6UserDate.Text;
                }
                else if (vOption == "7")
                {
                    //----------------------------------------------------------------------------------
                    if (myeService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 6;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 7;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 6;
                        if (myeService.FStep6 == "1")
                        {
                            myAgree.UserName = myeService.Manag1;
                            myAgree.UserName2 = myeService.Manag2;
                            myAgree.UserGroup = "";
                        }
                        else
                        {
                            myAgree.UserName = myeService.FStep6;
                            myAgree.UserName2 = "";
                            myAgree.UserGroup = myeService.FStep6;
                        }
                        myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    //----------------------------------------------------------------------------------

                    txtAgree7User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree7User.Text = Session["FullUser"].ToString();
                    txtAgree7UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult7.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult7.Text = "تم إعادة المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark7.Text;
                    myServiceAgree.AgreeUser = txtAgree7User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree7UserDate.Text;
                }
                else if (vOption == "8")
                {
                    //----------------------------------------------------------------------------------
                    if (myeService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 6;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 7;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 6;
                        if (myeService.FStep6 == "1")
                        {
                            myAgree.UserName = myeService.Manag1;
                            myAgree.UserName2 = myeService.Manag2;
                            myAgree.UserGroup = "";
                        }
                        else
                        {
                            myAgree.UserName = myeService.FStep6;
                            myAgree.UserName2 = "";
                            myAgree.UserGroup = myeService.FStep6;
                        }
                        myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    //----------------------------------------------------------------------------------

                    txtAgree8User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree8User.Text = Session["FullUser"].ToString();
                    txtAgree8UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult8.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult8.Text = "تم إعادة المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark8.Text;
                    myServiceAgree.AgreeUser = txtAgree8User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree8UserDate.Text;
                }
                else if (vOption == "9")
                {
                    //----------------------------------------------------------------------------------
                    if (myeService != null)
                    {
                        doAgree myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 7;
                        myAgree.UserName = "";
                        myAgree.UserName2 = "";
                        myAgree.UserGroup = "";
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        myAgree.FNo = 8;
                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        myAgree = new doAgree();
                        myAgree.FType = short.Parse(DocType);
                        myAgree.LocType = 0;
                        myAgree.LocNumber = 0;
                        myAgree.Number = int.Parse(txtDocNo.Text);
                        myAgree.FNo = 7;
                        if (myeService.FStep7 == "1")
                        {
                            myAgree.UserName = myeService.Manag1;
                            myAgree.UserName2 = myeService.Manag2;
                            myAgree.UserGroup = "";
                        }
                        else
                        {
                            myAgree.UserName = myeService.FStep7;
                            myAgree.UserName2 = "";
                            myAgree.UserGroup = myeService.FStep7;
                        }
                        myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    //----------------------------------------------------------------------------------

                    txtAgree9User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree9User.Text = Session["FullUser"].ToString();
                    txtAgree9UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult9.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult9.Text = "تم إعادة المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark9.Text;
                    myServiceAgree.AgreeUser = txtAgree9User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree9UserDate.Text;

                }

                eServices myService = new eServices();
                myService.DocType = short.Parse(DocType);
                myService.DocNo = int.Parse(txtDocNo.Text);
                myService = myService.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myService != null)
                {
                    myService.Status = 88;
                    myService.TransferUser = "";
                    if (myService.StatusUpdate(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        myServiceAgree.FNo = short.Parse(e.CommandArgument.ToString());
                        myServiceAgree.Agree = 88;
                        if (myServiceAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.Description = "تم إعادة على " + DocName + " رقم  " + txtDocNo.Text;
                            UserTran.FormAction = "إعادة";
                            UserTran.FormName = DocName;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                            ShowDisAgreeButton(vOption);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage("تم إعادة المستند بنجاح", false, true), true);
                        }
                        else
                        {
                            SetError(vOption);
                        }
                    }
                    else
                    {
                        SetError(vOption);
                    }
                }
                else
                {
                    SetError(vOption);
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }

            /*
            try
            {
                string vOption = e.CommandArgument.ToString();
                int vStatus = 0;
                eServicesAgree myServiceAgree = new eServicesAgree();
                myServiceAgree.DocType = short.Parse(DocType);
                myServiceAgree.DocNo = int.Parse(txtDocNo.Text);
                myServiceAgree.FNo = short.Parse(e.CommandArgument.ToString());
                myServiceAgree = myServiceAgree.findFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myServiceAgree != null) myServiceAgree.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                //----------------------------------------------------------------------------------
                veServices myeService = new veServices();
                myeService.DocType = short.Parse(DocType);
                myeService.DocNo = int.Parse(txtDocNo.Text);
                myeService = myeService.find0(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                //------------------------------------------------------------------------------------


                myServiceAgree = new eServicesAgree();
                myServiceAgree.DocType = short.Parse(DocType);
                myServiceAgree.DocNo = int.Parse(txtDocNo.Text);
                myServiceAgree.FNo = short.Parse(e.CommandArgument.ToString());

                if (vOption == "1")
                {
                    if (ddlTransfer1.SelectedIndex == 0)
                    {
                        LblCodesResult1.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult1.Text = "يجب أختيار المحول إليه";
                        ddlTransfer1.Focus();
                        return;
                    }
                    txtAgree1User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree1User.Text = Session["FullUser"].ToString();
                    txtAgree1UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult1.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult1.Text = "تم اعتماد تحويل المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark1.Text;
                    myServiceAgree.AgreeUser = txtAgree1User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree1UserDate.Text;
                    myServiceAgree.TransferUser = ddlTransfer1.SelectedValue;
                    vStatus = ddlTransfer1.SelectedIndex - 1;
                }
                else if (vOption == "2")
                {
                    if (ddlTransfer2.SelectedIndex == 0)
                    {
                        LblCodesResult2.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult2.Text = "يجب أختيار المحول إليه";
                        ddlTransfer2.Focus();
                        return;
                    }
                    txtAgree2User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree2User.Text = Session["FullUser"].ToString();
                    txtAgree2UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult2.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult2.Text = "تم اعتماد تحويل المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark2.Text;
                    myServiceAgree.AgreeUser = txtAgree2User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree2UserDate.Text;
                    myServiceAgree.TransferUser = ddlTransfer2.SelectedValue;
                    vStatus = ddlTransfer2.SelectedIndex - 1;
                }
                else if (vOption == "3")
                {
                    if (ddlTransfer3.SelectedIndex == 0)
                    {
                        LblCodesResult3.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult3.Text = "يجب أختيار المحول إليه";
                        ddlTransfer3.Focus();
                        return;
                    }
                    txtAgree3User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree3User.Text = Session["FullUser"].ToString();
                    txtAgree3UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult3.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult3.Text = "تم اعتماد تحويل المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark3.Text;
                    myServiceAgree.AgreeUser = txtAgree3User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree3UserDate.Text;
                    myServiceAgree.TransferUser = ddlTransfer3.SelectedValue;
                    vStatus = ddlTransfer3.SelectedIndex - 1;
                }
                else if (vOption == "4")
                {
                    if (ddlTransfer4.SelectedIndex == 0)
                    {
                        LblCodesResult4.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult4.Text = "يجب أختيار المحول إليه";
                        ddlTransfer4.Focus();
                        return;
                    }
                    txtAgree4User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree4User.Text = Session["FullUser"].ToString();
                    txtAgree4UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult4.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult4.Text = "تم اعتماد تحويل المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark4.Text;
                    myServiceAgree.AgreeUser = txtAgree4User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree4UserDate.Text;
                    myServiceAgree.TransferUser = ddlTransfer4.SelectedValue;
                    vStatus = ddlTransfer4.SelectedIndex - 1;
                }
                else if (vOption == "5")
                {
                    if (ddlTransfer5.SelectedIndex == 0)
                    {
                        LblCodesResult5.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult5.Text = "يجب أختيار المحول إليه";
                        ddlTransfer5.Focus();
                        return;
                    }
                    txtAgree5User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree5User.Text = Session["FullUser"].ToString();
                    txtAgree5UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult5.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult5.Text = "تم اعتماد تحويل المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark5.Text;
                    myServiceAgree.AgreeUser = txtAgree5User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree5UserDate.Text;
                    myServiceAgree.TransferUser = ddlTransfer5.SelectedValue;
                    vStatus = ddlTransfer5.SelectedIndex - 1;
                }
                else if (vOption == "6")
                {
                    if (ddlTransfer6.SelectedIndex == 0)
                    {
                        LblCodesResult6.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult6.Text = "يجب أختيار المحول إليه";
                        ddlTransfer6.Focus();
                        return;
                    }
                    txtAgree6User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree6User.Text = Session["FullUser"].ToString();
                    txtAgree6UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult6.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult6.Text = "تم اعتماد تحويل المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark6.Text;
                    myServiceAgree.AgreeUser = txtAgree6User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree6UserDate.Text;
                    myServiceAgree.TransferUser = ddlTransfer6.SelectedValue;
                    vStatus = ddlTransfer6.SelectedIndex - 1;
                }
                else if (vOption == "7")
                {
                    if (ddlTransfer7.SelectedIndex == 0)
                    {
                        LblCodesResult7.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult7.Text = "يجب أختيار المحول إليه";
                        ddlTransfer7.Focus();
                        return;
                    }
                    txtAgree7User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree7User.Text = Session["FullUser"].ToString();
                    txtAgree7UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult7.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult7.Text = "تم اعتماد تحويل المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark7.Text;
                    myServiceAgree.AgreeUser = txtAgree7User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree7UserDate.Text;
                    myServiceAgree.TransferUser = ddlTransfer7.SelectedValue;
                    vStatus = ddlTransfer7.SelectedIndex - 1;
                }
                else if (vOption == "8")
                {
                    if (ddlTransfer8.SelectedIndex == 0)
                    {
                        LblCodesResult8.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult8.Text = "يجب أختيار المحول إليه";
                        ddlTransfer8.Focus();
                        return;
                    }
                    txtAgree8User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree8User.Text = Session["FullUser"].ToString();
                    txtAgree8UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult8.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult8.Text = "تم اعتماد تحويل المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark8.Text;
                    myServiceAgree.AgreeUser = txtAgree8User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree8UserDate.Text;
                    myServiceAgree.TransferUser = ddlTransfer8.SelectedValue;
                    vStatus = ddlTransfer8.SelectedIndex - 1;
                }
                else if (vOption == "9")
                {
                    if (ddlTransfer9.SelectedIndex == 0)
                    {
                        LblCodesResult9.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult9.Text = "يجب أختيار المحول إليه";
                        ddlTransfer9.Focus();
                        return;
                    }
                    txtAgree9User.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgree9User.Text = Session["FullUser"].ToString();
                    txtAgree9UserDate.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
                    LblCodesResult9.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult9.Text = "تم اعتماد تحويل المستند بنجاح";
                    myServiceAgree.AgreeRemark = txtRemark9.Text;
                    myServiceAgree.AgreeUser = txtAgree9User.ToolTip;
                    myServiceAgree.AgreeUserDate = txtAgree9UserDate.Text;
                    myServiceAgree.TransferUser = ddlTransfer9.SelectedValue;
                    vStatus = ddlTransfer9.SelectedIndex - 1;
                }

                //----------------------------------------------------------------------------------
                if (myeService != null)
                {
                    doAgree myAgree = new doAgree();
                    myAgree.FType = short.Parse(DocType);
                    myAgree.LocType = 0;
                    myAgree.LocNumber = 0;
                    myAgree.Number = int.Parse(txtDocNo.Text);
                    myAgree.FNo = 1;
                    myAgree.UserName = "";
                    myAgree.UserName2 = "";
                    myAgree.UserGroup = "";
                    myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    myAgree.FNo = 2;
                    myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    myAgree.FNo = 3;
                    myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    myAgree.FNo = 4;
                    myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    myAgree.FNo = 5;
                    myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    myAgree.FNo = 6;
                    myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    myAgree.FNo = 7;
                    myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    myAgree.FNo = 8;
                    myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    myAgree.FNo = 9;
                    myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);


                    short vStep = 0;
                    if (myServiceAgree.TransferUser == myeService.Manag1 || myServiceAgree.TransferUser == myeService.Manag2)
                    {
                        if (myeService.FStep1 == "1") vStep = 1;
                        else if (myServiceAgree.TransferUser == "1") vStep = 2;
                        else if (myServiceAgree.TransferUser == "1") vStep = 3;
                        else if (myServiceAgree.TransferUser == "1") vStep = 4;
                        else if (myServiceAgree.TransferUser == "1") vStep = 5;
                        else if (myServiceAgree.TransferUser == "1") vStep = 6;
                        else if (myServiceAgree.TransferUser == "1") vStep = 7;
                        else if (myServiceAgree.TransferUser == "1") vStep = 8;
                    }
                    else
                    {
                        if (myServiceAgree.TransferUser == myeService.FStep1) vStep = 1;
                        else if (myServiceAgree.TransferUser == myeService.FStep2) vStep = 2;
                        else if (myServiceAgree.TransferUser == myeService.FStep3) vStep = 3;
                        else if (myServiceAgree.TransferUser == myeService.FStep4) vStep = 4;
                        else if (myServiceAgree.TransferUser == myeService.FStep5) vStep = 5;
                        else if (myServiceAgree.TransferUser == myeService.FStep6) vStep = 6;
                        else if (myServiceAgree.TransferUser == myeService.FStep7) vStep = 7;
                        else if (myServiceAgree.TransferUser == myeService.FStep8) vStep = 8;
                    }

                    myAgree = new doAgree();
                    myAgree.FType = short.Parse(DocType);
                    myAgree.LocType = 0;
                    myAgree.LocNumber = 0;
                    myAgree.Number = int.Parse(txtDocNo.Text);
                    myAgree.FNo = vStep;
                    myAgree.UserName = myServiceAgree.TransferUser;
                    myAgree.UserName2 = "";
                    myAgree.UserGroup = myServiceAgree.TransferUser;
                    myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }
                //----------------------------------------------------------------------------------

                eServices myService = new eServices();
                myService.DocType = short.Parse(DocType);
                myService.DocNo = int.Parse(txtDocNo.Text);
                myService = myService.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myService != null)
                {
                    myService.Status = (short)vStatus;
                    myService.TransferUser = myServiceAgree.TransferUser;
                    if (myService.StatusUpdate(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        myServiceAgree.FNo = short.Parse(e.CommandArgument.ToString());
                        myServiceAgree.Agree = 2;
                        if (myServiceAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.Description = "أعتماد تحويل " + DocName + " رقم  " + txtDocNo.Text;
                            UserTran.FormAction = "أعتماد";
                            UserTran.FormName = DocName;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                            ShowTransferButton(vOption);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage("تم اعتماد تحويل المستند بنجاح", false, true), true);
                        }
                        else
                        {
                            SetError(vOption);
                        }
                    }
                    else
                    {
                        SetError(vOption);
                    }
                }
                else
                {
                    SetError(vOption);
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
             */
        }

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (txtEmpCode.Text != "")
                    {
                        SEmp myEmp = new SEmp();
                        myEmp.EmpCode = int.Parse(txtEmpCode.Text);
                        myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myEmp == null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم الموظف غير معرف من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>','');", true);
                        }
                        else if (this.txtSDate.Text == "")
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "يجب إدخال التاريخ";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>','');", true);
                        }
                        else //if (CheckVac())
                        {
                            eServices myService = new eServices();
                            myService.DocType = short.Parse(DocType);
                            myService.DocNo = int.Parse(txtDocNo.Text);
                            myService = myService.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myService != null)
                            {
                                myService.DocDate = txtFDate.Text;
                                myService.DocTime = txtFTime.Text;
                                myService.EmpCode = int.Parse(txtEmpCode.Text);
                                myService.FType = short.Parse(ddlFType.SelectedValue);
                                myService.Notes = txtFNote.Text;
                                //myService.Notes2 = txtNotes2.Text;
                                myService.Status = 0;
                                myService.SDate = txtSDate.Text;
                                myService.UserName = txtUserName.ToolTip;
                                myService.UserDate = txtUserDate.Text;
                                myService.TransferUser = "";
                                if (myService.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                {
                                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                                    {
                                        Transactions UserTran = new Transactions();
                                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                        UserTran.UserName = Session["CurrentUser"].ToString();
                                        UserTran.FormName = "البوابة الالكترونية";
                                        UserTran.FormAction = "تعديل";
                                        UserTran.Description = "تعديل " + DocName + " للموظف رقم " + txtEmpCode.Text + " طلب رقم " + txtDocNo.Text;
                                        UserTran.IP = IPNetworking.GetIP4Address();
                                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                    }


                                    //----------------------------------------------------------------------------------
                                    veServices myeService = new veServices();
                                    myeService.DocType = short.Parse(DocType);
                                    myeService.DocNo = int.Parse(txtDocNo.Text);
                                    myeService = myeService.find0(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (myeService != null)
                                    {
                                        doAgree myAgree = new doAgree();
                                        myAgree.FType = short.Parse(DocType);
                                        myAgree.LocType = 0;
                                        myAgree.LocNumber = 0;
                                        myAgree.Number = int.Parse(txtDocNo.Text);
                                        myAgree.FNo = 0;
                                        myAgree.UserName = "";
                                        myAgree.UserName2 = "";
                                        myAgree.UserGroup = "";
                                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        myAgree.FNo = 1;
                                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        myAgree.FNo = 2;
                                        myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                        myAgree = new doAgree();
                                        myAgree.FType = short.Parse(DocType);
                                        myAgree.LocType = 0;
                                        myAgree.LocNumber = 0;
                                        myAgree.Number = int.Parse(txtDocNo.Text);
                                        myAgree.FNo = 1;
                                        if (myeService.FStep1 == "1")
                                        {
                                            myAgree.UserName = myeService.Manag1;
                                            myAgree.UserName2 = myeService.Manag2;
                                            myAgree.UserGroup = "";
                                        }
                                        else
                                        {
                                            myAgree.UserName = myeService.FStep1;
                                            myAgree.UserName2 = "";
                                            myAgree.UserGroup = myeService.FStep1;
                                        }
                                        myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    }
                                    //------------------------------------------------------------------------------------

                                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                    LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                                    string vNumber = txtDocNo.Text;
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(1,'" + LblCodesResult.Text + "');", true);
                                    BtnClear_Click(sender, e);
                                    PrintMe(vNumber);
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
                                LblCodesResult.Text = "رقم الطلب غير معرف من قبل";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>');", true);
                            }
                        }
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب إدخال رقم الموظف";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>','');", true);
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


        public void doAgree()
        {
            if (moh.StrToInt(txtEmpCode2.Text) > 0)
            {
                int? vSection = 0;
                int? vDep = 0;
                string vArea = "-1",vCostCenter = "-1" ,vProject = "-1" ,vCostAcc = "-1",vUserName="",vUserName2="",vManag1="",vManag2="";

                SEmp myEmp = new SEmp();
                myEmp.EmpCode = int.Parse(txtEmpCode2.Text);
                myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myEmp != null)
                {
                    vUserName2 = myEmp.UserName;
                    vSection = myEmp.Section;
                    vDep = myEmp.Dep;
                    vManag1 = myEmp.Manag1;
                    vManag2 = myEmp.Manag2;
                }

                myEmp = new SEmp();
                myEmp.EmpCode = int.Parse(txtEmpCode.Text);
                myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myEmp != null)
                {
                    vUserName = myEmp.UserName;
                }

                myEmp = new SEmp();
                myEmp.EmpCode = int.Parse(txtEmpCode.Text);
                myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myEmp != null)
                {
                    myEmp.Section = vSection;
                    myEmp.Dep = vDep;
                    myEmp.Manag1 = vManag1;
                    myEmp.Manag2 = vManag2;
                    myEmp.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    Cache.Remove("Emps" + Session["CNN2"].ToString());
                    Cache.Insert("Emps" + Session["CNN2"].ToString(), myEmp.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                }

                TblUsers myUser = new TblUsers();
                if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), myUser.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myUser.UserName = vUserName;
                myUser = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                          where uitm.UserName == myUser.UserName
                          select uitm).FirstOrDefault();
                
                TblUsers myUser2 = new TblUsers();
                myUser2.UserName = vUserName2;
                myUser2 = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                          where uitm.UserName == myUser.UserName
                          select uitm).FirstOrDefault();

                string[] k = myUser2.Branchs.Split(';');
                string vBran="";
                foreach (string m in k)
                {
                    for (int i = 0; i < k.Count(); i++)
                    {
                        if (k[i] != ddlSection.SelectedValue)
                        {
                            if (vBran == "") vBran = k[i];
                            else vBran += ";" + k[i];
                        }
                    }
                }



                myUser.MainBran = ddlSection.SelectedValue;
                myUser.Branchs = vBran;
                myUser.Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                TblUsersInRole UR2 = new TblUsersInRole();
                UR2.UserName = myUser.UserName;
                UR2.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                TblUsersInRole UR = new TblUsersInRole();
                UR.UserName = myUser.UserName;
                UR.RoleName = ddlFType.SelectedValue;
                UR.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                if (Cache["Users" + Session["CNN2"].ToString()] != null) Cache.Remove("Users" + Session["CNN2"].ToString());
                TblUsers ax = new TblUsers();
                if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                Acc myacc = new Acc();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                myacc.Code = "12050" + txtEmpCode2.Text.Trim();
                if (myacc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    vArea = myacc.Area;
                    vCostCenter = myacc.CostCenter;
                    vProject = myacc.Project;
                    vCostAcc = myacc.CostAcc;
                }

                myacc = new Acc();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                myacc.Code = "12050" + txtEmpCode.Text.Trim();
                if (myacc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    myacc.Area = vArea;
                    myacc.CostCenter = vCostCenter;
                    myacc.Project = vProject;
                    myacc.CostAcc = vCostAcc;
                    myacc.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    Acc myAcc = new Acc();
                    myAcc.Branch = short.Parse(Session["Branch"].ToString());
                    Cache["LastACC" + Session["CNN2"].ToString()] = myAcc.GetLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    Cache["AllACC" + Session["CNN2"].ToString()] = myAcc.Getall(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }


            }
            return;
        }


        protected void ddlFType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

    }
}