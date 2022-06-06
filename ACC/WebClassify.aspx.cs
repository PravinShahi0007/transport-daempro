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
    public partial class WebClassify : System.Web.UI.Page
    {
        public bool AccountType = false; // Should Change and Switch According to Clients
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
        private short TypeFlag
        {
            get
            {
                if (ViewState["TypeFlag"] == null)
                {
                    ViewState["TypeFlag"] = 0;
                }
                return short.Parse(ViewState["TypeFlag"].ToString());
            }
            set { ViewState["TypeFlag"] = value; }
        }

        private short CurLevel
        {
            get
            {
                if (ViewState["CurLevel"] == null)
                {
                    ViewState["CurLevel"] = 1;
                }
                return short.Parse(ViewState["CurLevel"].ToString());
            }
            set { ViewState["CurLevel"] = value; }
        }

        private short Levels
        {
            get
            {
                if (ViewState["Levels"] == null)
                {
                    ViewState["Levels"] = 1;
                }
                return short.Parse(ViewState["Levels"].ToString());
            }
            set { ViewState["Levels"] = value; }
        }

        private string fcode
        {
            get
            {
                if (ViewState["fcode"] == null)
                {
                    ViewState["fcode"] = "";
                }
                return ViewState["fcode"].ToString();
            }
            set { ViewState["fcode"] = value; }
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
                    if (Request.QueryString["FType"] == null)
                    {
                        TypeFlag = 1;
                        fcode = "";
                        Levels = 2;
                        LbtnLevel1.Text = "أنواع الأصناف";
                        string[] ax = new string[2];
                        ax[0] = "FCode";
                        ax[1] = "Code";
                        grdCodes.DataKeyNames = ax;
                        LoadCodesData();
                    }
                    else
                    {
                        if (Request.QueryString["FType"].ToString() == "1")
                        {
                            TypeFlag = 2;
                            fcode = "";
                            Levels = 2;
                            LbtnLevel1.Text = "تصنيف المنتجات";
                            string[] ax = new string[2];
                            ax[0] = "FCode";
                            ax[1] = "Code";
                            grdCodes.DataKeyNames = ax;
                            LoadCodesData();
                        }
                        else if (Request.QueryString["FType"].ToString() == "2")
                        {
                            TypeFlag = 3;
                            fcode = "";
                            Levels = 3;
                            LbtnLevel1.Text = "الهيكل الاداري";
                            string[] ax = new string[2];
                            ax[0] = "FCode";
                            ax[1] = "Code";
                            grdCodes.DataKeyNames = ax;
                            LoadCodesData();
                        }
                        else if (Request.QueryString["FType"].ToString() == "3")
                        {
                            TypeFlag = 4;
                            fcode = "";
                            Levels = 4;
                            LbtnLevel1.Text = "تصنيف الحسابات";
                            grdCodes.Columns[3].Visible = true;
                            string[] ax = new string[2];
                            ax[0] = "FCode";
                            ax[1] = "Code";
                            grdCodes.DataKeyNames = ax;
                            LoadCodesData();
                        }
                        else if (Request.QueryString["FType"].ToString() == "4")
                        {
                            TypeFlag = 5;
                            fcode = "";
                            Levels = 1;
                            LbtnLevel1.Text = "المشاريع";
                            grdCodes.Columns[3].Visible = true;
                            string[] ax = new string[1];
                            ax[0] = "Code";
                            grdCodes.DataKeyNames = ax;
                            LoadCodesData();
                        }
                        else if (Request.QueryString["FType"].ToString() == "5")
                        {
                            TypeFlag = 6;
                            fcode = "";
                            Levels = 1;
                            LbtnLevel1.Text = "مراكز التكلفة";
                            grdCodes.Columns[3].Visible = true;
                            string[] ax = new string[1];
                            ax[0] = "Code";
                            grdCodes.DataKeyNames = ax;
                            LoadCodesData();
                        }
                        else if (Request.QueryString["FType"].ToString() == "6")
                        {
                            TypeFlag = 7;
                            fcode = "";
                            Levels = 1;
                            LbtnLevel1.Text = "مركز الحسابات";
                            grdCodes.Columns[3].Visible = true;
                            string[] ax = new string[1];
                            ax[0] = "Code";
                            grdCodes.DataKeyNames = ax;
                            LoadCodesData();
                        }
                        else if (Request.QueryString["FType"].ToString() == "7")
                        {
                            TypeFlag = 8;
                            fcode = "";
                            Levels = 1;
                            LbtnLevel1.Text = "الالوان";
                            grdCodes.Columns[3].Visible = true;
                            string[] ax = new string[1];
                            ax[0] = "Code";
                            grdCodes.DataKeyNames = ax;
                            LoadCodesData();
                        }
                        else if (Request.QueryString["FType"].ToString() == "8")
                        {
                            TypeFlag = 9;
                            fcode = "";
                            Levels = 1;
                            LbtnLevel1.Text = "المقاسات";
                            grdCodes.Columns[3].Visible = true;
                            string[] ax = new string[1];
                            ax[0] = "Code";
                            grdCodes.DataKeyNames = ax;
                            LoadCodesData();
                        }
                        else if (Request.QueryString["FType"].ToString() == "9")
                        {
                            TypeFlag = 10;
                            fcode = "";
                            Levels = 1;
                            LbtnLevel1.Text = "الاحجام";
                            grdCodes.Columns[3].Visible = true;
                            string[] ax = new string[1];
                            ax[0] = "Code";
                            grdCodes.DataKeyNames = ax;
                            LoadCodesData();
                        }
                        else if (Request.QueryString["FType"].ToString() == "10")
                        {
                            TypeFlag = 11;
                            fcode = "";
                            Levels = 1;
                            LbtnLevel1.Text = "بلد المنشأ";
                            grdCodes.Columns[3].Visible = true;
                            string[] ax = new string[1];
                            ax[0] = "Code";
                            grdCodes.DataKeyNames = ax;
                            LoadCodesData();
                        }
                        else if (Request.QueryString["FType"].ToString() == "11")
                        {
                            TypeFlag = 12;
                            fcode = "";
                            Levels = 1;
                            LbtnLevel1.Text = "مندوبين البيع";
                            grdCodes.Columns[3].Visible = true;
                            string[] ax = new string[1];
                            ax[0] = "Code";
                            grdCodes.DataKeyNames = ax;
                            LoadCodesData();
                        }
                        else if (Request.QueryString["FType"].ToString() == "12")
                        {
                            TypeFlag = 13;
                            fcode = "";
                            Levels = 1;
                            LbtnLevel1.Text = "الوحدات";
                            grdCodes.Columns[3].Visible = true;
                            string[] ax = new string[1];
                            ax[0] = "Code";
                            grdCodes.DataKeyNames = ax;
                            LoadCodesData();
                        }
                        else if (Request.QueryString["FType"].ToString() == "13")
                        {
                            TypeFlag = 14;
                            fcode = "";
                            Levels = 1;
                            LbtnLevel1.Text = "المناطق";
                            grdCodes.Columns[3].Visible = true;
                            string[] ax = new string[1];
                            ax[0] = "Code";
                            grdCodes.DataKeyNames = ax;
                            LoadCodesData();
                        }
                        else if (Request.QueryString["FType"].ToString() == "14")
                        {
                            TypeFlag = 15;
                            fcode = "";
                            Levels = 1;
                            LbtnLevel1.Text = "حسابات التكاليف";
                            grdCodes.Columns[3].Visible = true;
                            string[] ax = new string[1];
                            ax[0] = "Code";
                            grdCodes.DataKeyNames = ax;
                            LoadCodesData();
                        }
                        else if (Request.QueryString["FType"].ToString() == "15")
                        {
                            TypeFlag = 16;
                            fcode = "";
                            Levels = 2;
                            LbtnLevel1.Text = "أنواع و طرز السيارات";
                            string[] ax = new string[2];
                            ax[0] = "FCode";
                            ax[1] = "Code";
                            grdCodes.Columns[3].Visible = true;
                            grdCodes.DataKeyNames = ax;
                            LoadCodesData();
                        }
                        else if (Request.QueryString["FType"].ToString() == "16")
                        {
                            TypeFlag = 17;
                            fcode = "";
                            Levels = 1;
                            LbtnLevel1.Text = "مستويات التسعير";
                            grdCodes.Columns[3].Visible = true;
                            string[] ax = new string[1];
                            ax[0] = "Code";
                            grdCodes.DataKeyNames = ax;
                            LoadCodesData();
                        }
                        else if (Request.QueryString["FType"].ToString() == "17")
                        {
                            TypeFlag = 17;
                            fcode = "";
                            Levels = 1;
                            LbtnLevel1.Text = "ملحقات الشاحنات";
                            grdCodes.Columns[3].Visible = true;
                            string[] ax = new string[1];
                            ax[0] = "Code";
                            grdCodes.DataKeyNames = ax;
                            LoadCodesData();
                        }
                        this.Page.Header.Title = LbtnLevel1.Text;
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "الرئيسية", "اختيار", "اختيار صفحة " + LbtnLevel1.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }
                }
                else
                {
                    LblCodesResult.Text = "";
                }

                if (CurLevel == 4)
                {
                    grdCodes.Columns[3].Visible = false;
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

        protected void LoadCodesData()
        {
            try
            {
                switch (TypeFlag)
                {
                    case 1:
                        ICat ax = new ICat();
                        ax.Branch = short.Parse(Session["Branch"].ToString());
                        ax.FCode = fcode;
                        grdCodes.DataSource = ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        grdCodes.DataBind();

                        if (grdCodes.Rows.Count < 1)
                        {
                            List<ICat> Listax = new List<ICat>();
                            Listax.Add(ax);
                            grdCodes.DataSource = Listax;
                            grdCodes.DataBind();
                            grdCodes.Rows[0].Cells.Clear();
                        }
                        grdCodes.Columns[3].Visible = false;
                        break;

                    case 2:
                        PCat Pax = new PCat();
                        Pax.Branch = short.Parse(Session["Branch"].ToString());
                        Pax.FCode = fcode;
                        grdCodes.DataSource = Pax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        grdCodes.DataBind();

                        if (grdCodes.Rows.Count < 1)
                        {
                            List<PCat> Listax = new List<PCat>();
                            Listax.Add(Pax);
                            grdCodes.DataSource = Listax;
                            grdCodes.DataBind();
                            grdCodes.Rows[0].Cells.Clear();
                        }
                        grdCodes.Columns[3].Visible = false;
                        break;

                    case 3:
                        ECat Eax = new ECat();
                        Eax.Branch = short.Parse(Session["Branch"].ToString());
                        Eax.FCode = fcode;
                        grdCodes.DataSource = Eax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        grdCodes.DataBind();

                        if (grdCodes.Rows.Count < 1)
                        {
                            List<ECat> Listax = new List<ECat>();
                            Listax.Add(Eax);
                            grdCodes.DataSource = Listax;
                            grdCodes.DataBind();
                            grdCodes.Rows[0].Cells.Clear();
                        }
                        grdCodes.Columns[3].Visible = false;
                        break;

                    case 4:
                        Acc myacc = new Acc();
                        myacc.Branch = short.Parse(Session["Branch"].ToString());
                        myacc.FCode = fcode;
                        grdCodes.DataSource = myacc.GetAllAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        grdCodes.DataBind();

                        if (grdCodes.Rows.Count < 1)
                        {
                            List<Acc> Listax = new List<Acc>();
                            Listax.Add(myacc);
                            grdCodes.DataSource = Listax;
                            grdCodes.DataBind();
                            grdCodes.Rows[0].Cells.Clear();
                        }

                        DropDownList ddlFType = grdCodes.FooterRow.FindControl("ddlFType") as DropDownList;
                        if (ddlFType != null)
                        {
                            if (CurLevel < 4)
                            {
                                grdCodes.Columns[3].Visible = true;
                                CheckType(ddlFType);
                            }
                            else
                            {
                                grdCodes.Columns[3].Visible = false;
                            }

                        }
                        break;

                    case 5:
                        AccProject myProject = new AccProject();
                        myProject.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["LastProject" + Session["CNN2"].ToString()] == null) Cache.Insert("LastProject" + Session["CNN2"].ToString(), myProject.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        grdCodes.DataSource = (List<AccProject>)(Cache["LastProject" + Session["CNN2"].ToString()]);
                        grdCodes.DataBind();

                        if (grdCodes.Rows.Count < 1)
                        {
                            List<AccProject> Listax = new List<AccProject>();
                            Listax.Add(myProject);
                            grdCodes.DataSource = Listax;
                            grdCodes.DataBind();
                            grdCodes.Rows[0].Cells.Clear();
                        }
                        grdCodes.Columns[3].Visible = false;
                        break;

                    case 6:
                        CostCenter myCostCenter = new CostCenter();
                        myCostCenter.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        grdCodes.DataSource = (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()]);
                        grdCodes.DataBind();

                        if (grdCodes.Rows.Count < 1)
                        {
                            List<CostCenter> Listax = new List<CostCenter>();
                            Listax.Add(myCostCenter);
                            grdCodes.DataSource = Listax;
                            grdCodes.DataBind();
                            grdCodes.Rows[0].Cells.Clear();
                        }
                        grdCodes.Columns[3].Visible = false;
                        break;

                    case 7:
                        AccCenter myCenter = new AccCenter();
                        myCenter.Branch = short.Parse(Session["Branch"].ToString());
                        grdCodes.DataSource = myCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        grdCodes.DataBind();

                        if (grdCodes.Rows.Count < 1)
                        {
                            List<AccCenter> Listax = new List<AccCenter>();
                            Listax.Add(myCenter);
                            grdCodes.DataSource = Listax;
                            grdCodes.DataBind();
                            grdCodes.Rows[0].Cells.Clear();
                        }
                        grdCodes.Columns[3].Visible = false;
                        break;

                    case 8:
                        IColor myColor = new IColor();
                        myColor.Branch = short.Parse(Session["Branch"].ToString());
                        grdCodes.DataSource = myColor.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        grdCodes.DataBind();

                        if (grdCodes.Rows.Count < 1)
                        {
                            List<IColor> Listax = new List<IColor>();
                            Listax.Add(myColor);
                            grdCodes.DataSource = Listax;
                            grdCodes.DataBind();
                            grdCodes.Rows[0].Cells.Clear();
                        }
                        grdCodes.Columns[3].Visible = false;
                        break;

                    case 9:
                        ISize mySize = new ISize();
                        mySize.Branch = short.Parse(Session["Branch"].ToString());
                        grdCodes.DataSource = mySize.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        grdCodes.DataBind();

                        if (grdCodes.Rows.Count < 1)
                        {
                            List<ISize> Listax = new List<ISize>();
                            Listax.Add(mySize);
                            grdCodes.DataSource = Listax;
                            grdCodes.DataBind();
                            grdCodes.Rows[0].Cells.Clear();
                        }
                        grdCodes.Columns[3].Visible = false;
                        break;

                    case 10:
                        IWidth myWidth = new IWidth();
                        myWidth.Branch = short.Parse(Session["Branch"].ToString());
                        grdCodes.DataSource = myWidth.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        grdCodes.DataBind();

                        if (grdCodes.Rows.Count < 1)
                        {
                            List<IWidth> Listax = new List<IWidth>();
                            Listax.Add(myWidth);
                            grdCodes.DataSource = Listax;
                            grdCodes.DataBind();
                            grdCodes.Rows[0].Cells.Clear();
                        }
                        grdCodes.Columns[3].Visible = false;
                        break;

                    case 11:
                        ICOO myCoo = new ICOO();
                        myCoo.Branch = short.Parse(Session["Branch"].ToString());
                        grdCodes.DataSource = myCoo.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        grdCodes.DataBind();

                        if (grdCodes.Rows.Count < 1)
                        {
                            List<ICOO> Listax = new List<ICOO>();
                            Listax.Add(myCoo);
                            grdCodes.DataSource = Listax;
                            grdCodes.DataBind();
                            grdCodes.Rows[0].Cells.Clear();
                        }
                        grdCodes.Columns[3].Visible = false;
                        break;

                    case 12:
                        Salesmen mySales = new Salesmen();
                        mySales.Branch = short.Parse(Session["Branch"].ToString());
                        grdCodes.DataSource = mySales.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        grdCodes.DataBind();

                        if (grdCodes.Rows.Count < 1)
                        {
                            List<Salesmen> Listax = new List<Salesmen>();
                            Listax.Add(mySales);
                            grdCodes.DataSource = Listax;
                            grdCodes.DataBind();
                            grdCodes.Rows[0].Cells.Clear();
                        }
                        grdCodes.Columns[3].Visible = false;
                        break;

                    case 13:
                        IUnit myUnit = new IUnit();
                        myUnit.Branch = short.Parse(Session["Branch"].ToString());
                        grdCodes.DataSource = myUnit.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        grdCodes.DataBind();

                        if (grdCodes.Rows.Count < 1)
                        {
                            List<IUnit> Listax = new List<IUnit>();
                            Listax.Add(myUnit);
                            grdCodes.DataSource = Listax;
                            grdCodes.DataBind();
                            grdCodes.Rows[0].Cells.Clear();
                        }
                        grdCodes.Columns[3].Visible = false;
                        break;

                    case 14:
                        Area myArea = new Area();
                        myArea.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["LastArea" + Session["CNN2"].ToString()] == null) Cache.Insert("LastArea" + Session["CNN2"].ToString(), myArea.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        grdCodes.DataSource = (List<Area>)(Cache["LastArea" + Session["CNN2"].ToString()]);
                        grdCodes.DataBind();

                        if (grdCodes.Rows.Count < 1)
                        {
                            List<Area> Listax = new List<Area>();
                            Listax.Add(myArea);
                            grdCodes.DataSource = Listax;
                            grdCodes.DataBind();
                            grdCodes.Rows[0].Cells.Clear();
                        }
                        grdCodes.Columns[3].Visible = false;
                        break;

                    case 15:
                        CostAcc myCostAcc = new CostAcc();
                        myCostAcc.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["LastCostAcc" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostAcc" + Session["CNN2"].ToString(), myCostAcc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        grdCodes.DataSource = (List<CostAcc>)(Cache["LastCostAcc" + Session["CNN2"].ToString()]);
                        grdCodes.DataBind();

                        if (grdCodes.Rows.Count < 1)
                        {
                            List<CostAcc> Listax = new List<CostAcc>();
                            Listax.Add(myCostAcc);
                            grdCodes.DataSource = Listax;
                            grdCodes.DataBind();
                            grdCodes.Rows[0].Cells.Clear();
                        }
                        grdCodes.Columns[3].Visible = false;
                        break;

                    case 16:
                        grdCodes.ShowFooter = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass111;
                        CarType myCarType = new CarType();
                        myCarType.cnn = WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString;
                        myCarType.Branch = short.Parse(Session["Branch"].ToString());
                        myCarType.FCode = fcode;
                        grdCodes.DataSource = myCarType.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        grdCodes.DataBind();

                        if (grdCodes.Rows.Count < 1)
                        {
                            List<CarType> Listax = new List<CarType>();
                            Listax.Add(myCarType);
                            grdCodes.DataSource = Listax;
                            grdCodes.DataBind();
                            grdCodes.Rows[0].Cells.Clear();
                        }
                        foreach (GridViewRow itm in grdCodes.Rows)
                        {
                            ImageButton BtnEdit = itm.FindControl("BtnEdit") as ImageButton;
                            ImageButton BtnDelete = itm.FindControl("BtnDelete") as ImageButton;
                            if (BtnEdit != null) BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass112;
                            if (BtnDelete != null) BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass113;
                        }
                        if (CurLevel == 2)
                        {
                            grdCodes.Columns[3].Visible = true;
                            DropDownList ddlFType2 = grdCodes.FooterRow.FindControl("ddlFType") as DropDownList;
                            if (ddlFType2 != null)
                            {
                                PLevel myLevel = new PLevel();
                                myLevel.Branch = short.Parse(Session["Branch"].ToString());
                                ddlFType2.DataTextField = "name1";
                                ddlFType2.DataValueField = "Code";
                                ddlFType2.DataSource = myLevel.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                ddlFType2.DataBind();
                            }
                        }
                        else grdCodes.Columns[3].Visible = false;
                        break;

                    case 17:
                        PLevel myPLevel = new PLevel();
                        myPLevel.Branch = short.Parse(Session["Branch"].ToString());
                        grdCodes.DataSource = myPLevel.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        grdCodes.DataBind();

                        if (grdCodes.Rows.Count < 1)
                        {
                            List<PLevel> Listax = new List<PLevel>();
                            Listax.Add(myPLevel);
                            grdCodes.DataSource = Listax;
                            grdCodes.DataBind();
                            grdCodes.Rows[0].Cells.Clear();
                        }
                        grdCodes.Columns[3].Visible = false;
                        break;
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


        protected void grdCodes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string FCode = "";
                if (TypeFlag < 5) FCode = grdCodes.DataKeys[e.RowIndex]["FCode"].ToString();
                string Code = grdCodes.DataKeys[e.RowIndex]["Code"].ToString();
                GridViewRow gvr = grdCodes.Rows[e.RowIndex];
                TextBox txtName1 = gvr.FindControl("txtName1") as TextBox;
                TextBox txtName2 = gvr.FindControl("txtName2") as TextBox;

                if (txtName2 == null || txtName1 == null)
                {
                    e.Cancel = true;
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    return;
                }
                if (txtName2.Text == "") txtName2.Text = txtName1.Text;

                switch (TypeFlag)
                {
                    case 1:
                        ICat myAccess = new ICat();
                        myAccess.Branch = short.Parse(Session["Branch"].ToString());
                        myAccess.Code = Code;
                        myAccess = myAccess.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myAccess != null)
                        {
                            myAccess.FCode = FCode;
                            myAccess.Name1 = txtName1.Text;
                            myAccess.Name2 = txtName2.Text;
                            myAccess.FUpdate = false;

                            if (!myAccess.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                e.Cancel = true;
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }
                        break;

                    case 2:
                        PCat myPAccess = new PCat();
                        myPAccess.Branch = short.Parse(Session["Branch"].ToString());
                        myPAccess.Code = Code;
                        myPAccess = myPAccess.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myPAccess != null)
                        {
                            myPAccess.FCode = FCode;
                            myPAccess.Name1 = txtName1.Text;
                            myPAccess.Name2 = txtName2.Text;
                            myPAccess.FUpdate = false;

                            if (!myPAccess.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                e.Cancel = true;
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }
                        break;

                    case 3:
                        ECat myEAccess = new ECat();
                        myEAccess.Branch = short.Parse(Session["Branch"].ToString());
                        myEAccess.Code = Code;
                        myEAccess = myEAccess.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myEAccess != null)
                        {
                            myEAccess.FCode = FCode;
                            myEAccess.Name1 = txtName1.Text;
                            myEAccess.Name2 = txtName2.Text;
                            myEAccess.FUpdate = false;

                            if (!myEAccess.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                e.Cancel = true;
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }
                        break;
                    case 4:
                        Acc myacc = new Acc();
                        myacc.Branch = short.Parse(Session["Branch"].ToString());
                        if (CurLevel == 4)
                        {
                            myacc.Code = FCode;
                            myacc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                        else if (CurLevel == 3)
                        {
                            myacc.Code = FCode;
                            myacc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            DropDownList ddlFType = gvr.FindControl("dllFType2") as DropDownList;
                            if (ddlFType != null)
                            {
                                myacc.SType = ddlFType.SelectedValue;
                            }
                        }
                        else
                        {
                            DropDownList ddlFType = gvr.FindControl("dllFType2") as DropDownList;
                            if (ddlFType != null)
                            {
                                myacc.FType = ddlFType.SelectedValue;
                            }
                        }
                        myacc.FCode = FCode;
                        myacc.Name1 = txtName1.Text;
                        myacc.Name2 = txtName2.Text;
                        myacc.FLevel = CurLevel;
                        myacc.Code = Code;
                        myacc.MCode = Code;

                        if (!myacc.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {                            
                            e.Cancel = true;
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                        else if(myacc.FLevel == 4) PutCarType(myacc, myacc.Code.Substring(4, 2));
                        break;

                    case 5:
                        AccProject myProject = new AccProject();
                        myProject.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["LastProject" + Session["CNN2"].ToString()] == null) Cache.Insert("LastProject" + Session["CNN2"].ToString(), myProject.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myProject.Code = Code;
                        myProject = (from itm in (List<AccProject>)(Cache["LastProject" + Session["CNN2"].ToString()])
                                     where itm.Code == myProject.Code
                                     select itm).FirstOrDefault();
                        if (myProject != null)
                        {
                            myProject.Name1 = txtName1.Text;
                            myProject.Name2 = txtName2.Text;

                            if (!myProject.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                e.Cancel = true;
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }
                        break;
                    case 6:
                        CostCenter myCost = new CostCenter();
                        myCost.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCost.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCost.Code = Code;
                        myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                  where citm.Code == myCost.Code
                                  select citm).FirstOrDefault();
                        if (myCost != null)
                        {
                            myCost.Name1 = txtName1.Text;
                            myCost.Name2 = txtName2.Text;

                            if (!myCost.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                e.Cancel = true;
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }                            
                        }
                        break;

                    case 7:
                        AccCenter myCenter = new AccCenter();
                        myCenter.Branch = short.Parse(Session["Branch"].ToString());
                        myCenter.Code = Code;
                        myCenter = myCenter.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myCenter != null)
                        {
                            myCenter.Name1 = txtName1.Text;
                            myCenter.Name2 = txtName2.Text;

                            if (!myCenter.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                e.Cancel = true;
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }
                        break;
                    case 8:
                        IColor myColor = new IColor();
                        myColor.Branch = short.Parse(Session["Branch"].ToString());
                        myColor.Code = Code;
                        myColor = myColor.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if(myColor != null)
                        {
                            myColor.Name1 = txtName1.Text;
                            myColor.Name2 = txtName2.Text;

                            if (!myColor.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                e.Cancel = true;
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }
                        break;

                    case 9:
                        ISize mySize = new ISize();
                        mySize.Branch = short.Parse(Session["Branch"].ToString());
                        mySize.Code = Code;
                        mySize = mySize.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (mySize != null)
                        {
                            mySize.Name1 = txtName1.Text;
                            mySize.Name2 = txtName2.Text;

                            if (!mySize.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                e.Cancel = true;
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }
                        break;

                    case 10:
                        IWidth myWidth = new IWidth();
                        myWidth.Branch = short.Parse(Session["Branch"].ToString());
                        myWidth.Code = Code;
                        myWidth = myWidth.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myWidth != null)
                        {
                            myWidth.Name1 = txtName1.Text;
                            myWidth.Name2 = txtName2.Text;

                            if (!myWidth.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                e.Cancel = true;
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }
                        break;

                    case 11:
                        ICOO myCoo = new ICOO();
                        myCoo.Branch = short.Parse(Session["Branch"].ToString());
                        myCoo.Code = Code;
                        myCoo = myCoo.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myCoo != null)
                        {
                            myCoo.Name1 = txtName1.Text;
                            myCoo.Name2 = txtName2.Text;

                            if (!myCoo.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                e.Cancel = true;
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }
                        break;

                    case 12:
                        Salesmen mySalesmen = new Salesmen();
                        mySalesmen.Branch = short.Parse(Session["Branch"].ToString());
                        mySalesmen.Code = Code;
                        mySalesmen = mySalesmen.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (mySalesmen != null)
                        {
                            mySalesmen.Name1 = txtName1.Text;
                            mySalesmen.Name2 = txtName2.Text;

                            if (!mySalesmen.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                e.Cancel = true;
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }
                        break;

                    case 13:
                        IUnit myUnit = new IUnit();
                        myUnit.Branch = short.Parse(Session["Branch"].ToString());
                        myUnit.Code = Code;
                        myUnit = myUnit.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myUnit != null)
                        {
                            myUnit.Name1 = txtName1.Text;
                            myUnit.Name2 = txtName2.Text;

                            if (!myUnit.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                e.Cancel = true;
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }
                        break;

                    case 14:
                        Area myArea = new Area();
                        myArea.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["LastArea" + Session["CNN2"].ToString()] == null) Cache.Insert("LastArea" + Session["CNN2"].ToString(), myArea.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myArea.Code = Code;
                        myArea = (from itm in (List<Area>)(Cache["LastArea" + Session["CNN2"].ToString()])
                                  where itm.Code == myArea.Code
                                  select itm).FirstOrDefault();
                        if(myArea != null)
                        {
                            myArea.Name1 = txtName1.Text;
                            myArea.Name2 = txtName2.Text;

                            if (!myArea.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                e.Cancel = true;
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }
                        break;

                    case 15:
                        CostAcc myCostAcc = new CostAcc();
                        myCostAcc.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["LastCostAcc" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostAcc" + Session["CNN2"].ToString(), myCostAcc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCostAcc.Code = Code;
                        myCostAcc = (from itm in (List<CostAcc>)(Cache["LastCostAcc" + Session["CNN2"].ToString()])
                                     where itm.Code == myCostAcc.Code
                                     select itm).FirstOrDefault();
                        if (myCostAcc != null)
                        {
                            myCostAcc.Name1 = txtName1.Text;
                            myCostAcc.Name2 = txtName2.Text;

                            if (!myCostAcc.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                e.Cancel = true;
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }
                        break;

                    case 16:
                        CarType myCarType = new CarType();
                        myCarType.cnn = WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString;
                        myCarType.Branch = short.Parse(Session["Branch"].ToString());
                        myCarType.FCode = FCode;
                        myCarType.Code = Code;

                        myCarType = myCarType.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        if (myCarType != null)
                        {
                            myCarType.Name1 = txtName1.Text;
                            myCarType.Name2 = txtName2.Text;
                            myCarType.FUpdate = false;
                            if (CurLevel == 2)
                            {
                                DropDownList ddlFType = gvr.FindControl("dllFType2") as DropDownList;
                                if (ddlFType != null)
                                {
                                    myCarType.LevelCode = ddlFType.SelectedValue;
                                }
                            }

                            if (!myCarType.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                e.Cancel = true;
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }
                        break;

                    case 17:
                        PLevel myPLevel = new PLevel();
                        myPLevel.Branch = short.Parse(Session["Branch"].ToString());
                        myPLevel.Code = Code;
                        myPLevel = myPLevel.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myPLevel != null)
                        {
                            myPLevel.Name1 = txtName1.Text;
                            myPLevel.Name2 = txtName2.Text;

                            if (!myPLevel.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                e.Cancel = true;
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }
                        break;
                }
                updateCache(TypeFlag);
                grdCodes.EditIndex = -1;
                LoadCodesData();
                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";

                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), LbtnLevel1.Text, "تعديل", "تعديل بيانات البند " + txtName1.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
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
                if (CurLevel < Levels)
                {
                    string FCode = grdCodes.DataKeys[e.NewSelectedIndex]["FCode"].ToString();
                    string Code = grdCodes.DataKeys[e.NewSelectedIndex]["Code"].ToString();
                    GridViewRow gvr = grdCodes.Rows[e.NewSelectedIndex];
                    Label txtName1 = gvr.FindControl("lblName1") as Label;

                    CurLevel++;
                    fcode = Code;
                    LoadCodesData();

                    switch (CurLevel)
                    {
                        case 1:
                            LbtnLevel1.Visible = true;
                            LbtnLevel2.Visible = false;
                            LbtnLevel3.Visible = false;
                            LbtnLevel4.Visible = false;
                            LbtnLevel5.Visible = false;
                            break;
                        case 2:
                            LbtnLevel1.Visible = true;
                            LbtnLevel2.Visible = true;
                            LbtnLevel2.Text = " :: " + txtName1.Text;
                            LbtnLevel2.ToolTip = Code.ToString();
                            LbtnLevel3.Visible = false;
                            LbtnLevel4.Visible = false;
                            LbtnLevel5.Visible = false;
                            break;
                        case 3:
                            LbtnLevel1.Visible = true;
                            LbtnLevel2.Visible = true;
                            LbtnLevel3.Visible = true;
                            LbtnLevel3.Text = " :: " + txtName1.Text;
                            LbtnLevel3.ToolTip = Code.ToString();
                            LbtnLevel4.Visible = false;
                            LbtnLevel5.Visible = false;
                            break;
                        case 4:
                            LbtnLevel1.Visible = true;
                            LbtnLevel2.Visible = true;
                            LbtnLevel3.Visible = true;
                            LbtnLevel4.Visible = true;
                            LbtnLevel4.Text = " :: " + txtName1.Text;
                            LbtnLevel4.ToolTip = Code.ToString();
                            LbtnLevel5.Visible = false;
                            break;
                    }
                    e.NewSelectedIndex = -1;
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "لقد تم الوصول الى أخر مستوى للتصنيف";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
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

        protected void grdCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdCodes.PageIndex = e.NewPageIndex;
                LoadCodesData();
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

        protected void grdCodes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdCodes.EditIndex = -1;
                LoadCodesData();
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

        protected void grdCodes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Insert"))
                {
                    ImageButton btnInsert = e.CommandSource as ImageButton;
                    if (btnInsert == null)
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    GridViewRow gvr = btnInsert.NamingContainer as GridViewRow;
                    if (gvr == null)
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    TextBox txtName1 = gvr.FindControl("txtName1") as TextBox;
                    TextBox txtName2 = gvr.FindControl("txtName2") as TextBox;

                    if (txtName1 == null || txtName2 == null)
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                    if (txtName2.Text == "") txtName2.Text = txtName1.Text;
                    if (txtName1.Text == "")
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "تاكد من أدخال البيانات المطلوبة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }


                    switch (TypeFlag)
                    {
                        case 1:
                            ICat myAccess = new ICat();
                            myAccess.Branch = short.Parse(Session["Branch"].ToString());
                            myAccess.FCode = fcode;
                            myAccess.Name1 = txtName1.Text;
                            myAccess.Name2 = txtName2.Text;
                            myAccess.FUpdate = false;

                            string s = myAccess.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (s == "0" || s == null)
                            {
                                s = fcode + "0001";
                            }
                            else
                            {
                                s = moh.MakeMask((Int32.Parse(s) + 1).ToString(), 4);
                            }
                            if (myAccess.FCode == "")
                            {
                                s = moh.MakeMask(s, 4);
                            }
                            else
                            {
                                s = moh.MakeMask(s, 8);
                            }
                            myAccess.Code = s;

                            if (myAccess.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم اضافة البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            }
                            else
                            {
                                grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                            break;

                        case 2:
                            PCat myPAccess = new PCat();
                            myPAccess.Branch = short.Parse(Session["Branch"].ToString());
                            myPAccess.FCode = fcode;
                            myPAccess.Name1 = txtName1.Text;
                            myPAccess.Name2 = txtName2.Text;
                            myPAccess.FUpdate = false;

                            string s1 = myPAccess.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (s1 == "0" || s1 == null)
                            {
                                s1 = fcode + "0001";
                            }
                            else
                            {
                                s1 = moh.MakeMask((Int32.Parse(s1) + 1).ToString(), 4);
                            }
                            if (myPAccess.FCode == "")
                            {
                                s1 = moh.MakeMask(s1, 4);
                            }
                            else
                            {
                                s1 = moh.MakeMask(s1, 8);
                            }
                            myPAccess.Code = s1;

                            if (myPAccess.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم اضافة البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            }
                            else
                            {
                                grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                            break;

                        case 3:
                            ECat myEAccess = new ECat();
                            myEAccess.Branch = short.Parse(Session["Branch"].ToString());
                            myEAccess.FCode = fcode;
                            myEAccess.Name1 = txtName1.Text;
                            myEAccess.Name2 = txtName2.Text;
                            myEAccess.FUpdate = false;

                            string s2 = myEAccess.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (s2 == "0" || s2 == null)
                            {
                                s2 = fcode + "001";
                            }
                            else
                            {
                                s2 = (Int32.Parse(s2) + 1).ToString();
                            }
                            if (myEAccess.FCode == "")
                            {
                                s2 = moh.MakeMask(s2, 3);
                            }
                            else if (CurLevel == 2)
                            {
                                s2 = moh.MakeMask(s2, 6);
                            }
                            else if (CurLevel == 3)
                            {
                                s2 = moh.MakeMask(s2, 9);
                            }
                            myEAccess.Code = s2;

                            if (myEAccess.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم اضافة البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            }
                            else
                            {
                                grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                            break;

                        case 4:
                            Acc myAcc = new Acc();
                            myAcc.Branch = short.Parse(Session["Branch"].ToString());
                            if (CurLevel == 4)
                            {
                                myAcc.Code = fcode;
                                myAcc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }
                            else if (CurLevel == 3)
                            {
                                myAcc.Code = fcode;
                                myAcc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                DropDownList ddlFType = gvr.FindControl("ddlFType") as DropDownList;
                                if (ddlFType != null)
                                {
                                    myAcc.SType = ddlFType.SelectedValue;
                                }
                            }
                            else
                            {
                                DropDownList ddlFType = gvr.FindControl("ddlFType") as DropDownList;
                                if (ddlFType != null)
                                {
                                    myAcc.FType = ddlFType.SelectedValue;
                                }
                            }
                            myAcc.FCode = fcode;
                            myAcc.Name1 = txtName1.Text;
                            myAcc.Name2 = txtName2.Text;
                            myAcc.FLevel = CurLevel;
                            myAcc.DAcc = 0;
                            myAcc.CAcc = 0;
                            myAcc.ODAcc = 0;
                            myAcc.OCAcc = 0;
                            myAcc.FUpdate = false;

                            string s4 = myAcc.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (s4 == "0" || s4 == null)
                            {
                                if (CurLevel == 1) s4 = "1";
                                else if (CurLevel == 2) s4 = fcode+"1";
                                else if (CurLevel == 3) s4 = fcode+"01";
                                else if (CurLevel == 4) s4 = fcode+"01";
                            }
                            else
                            {
                                s4 = (Int32.Parse(s4) + 1).ToString();
                            }

                            //if (myAcc.FCode == "")
                            //{
                            //    s4 = moh.MakeMask(s4, 1);
                            //}
                            //else if (CurLevel == 2)
                            //{
                            //    s4 = moh.MakeMask(s4, 1);
                            //}
                            //else if (CurLevel == 3)
                            //{
                            //    s4 = moh.MakeMask(s4, 2);
                            //}
                            //else if (CurLevel == 4)
                            //{
                            //    s4 = moh.MakeMask(s4, 2);
                            //}
                            
                            myAcc.Code =  s4;
                            myAcc.MCode = s4;

                            if (myAcc.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                if (myAcc.FLevel == 4) PutCarType(myAcc, s4.Substring(4, 2));
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم اضافة البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            }
                            else
                            {
                                grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                            break;

                        case 5:
                            AccProject myProject = new AccProject();
                            myProject.Branch = short.Parse(Session["Branch"].ToString());
                            myProject.Name1 = txtName1.Text;
                            myProject.Name2 = txtName2.Text;

                            string s5 = myProject.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (s5 == "0" || s5 == null)
                            {
                                s5 = fcode + "00001";
                            }
                            else
                            {
                                s5 = (Int32.Parse(s5) + 1).ToString();
                            }
                            myProject.Code = moh.MakeMask(s5, 5);

                            if (myProject.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم اضافة البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            }
                            else
                            {
                                grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                            break;

                        case 6:
                            CostCenter myCost = new CostCenter();
                            myCost.Branch = short.Parse(Session["Branch"].ToString());
                            myCost.Name1 = txtName1.Text;
                            myCost.Name2 = txtName2.Text;

                            string s6 = myCost.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (s6 == "0" || s6 == null)
                            {
                                s6 = fcode + "00001";
                            }
                            else
                            {
                                s6 = (Int32.Parse(s6) + 1).ToString();
                            }
                            myCost.Code = moh.MakeMask(s6, 5);

                            if (myCost.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                updateCache(TypeFlag);
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم اضافة البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            }
                            else
                            {
                                grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                            break;

                        case 7:
                            AccCenter myCenter = new AccCenter();
                            myCenter.Branch = short.Parse(Session["Branch"].ToString());
                            myCenter.Name1 = txtName1.Text;
                            myCenter.Name2 = txtName2.Text;

                            string s7 = myCenter.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (s7 == "0" || s7 == null)
                            {
                                s7 = fcode + "00001";
                            }
                            else
                            {
                                s7 = (Int32.Parse(s7) + 1).ToString();
                            }
                            myCenter.Code = moh.MakeMask(s7, 5);
                            if (myCenter.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم اضافة البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            }
                            else
                            {
                                grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                            break;

                        case 8:
                            IColor myColor = new IColor();
                            myColor.Branch = short.Parse(Session["Branch"].ToString());
                            myColor.Name1 = txtName1.Text;
                            myColor.Name2 = txtName2.Text;

                            string s8 = myColor.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (s8 == "0" || s8 == null)
                            {
                                s8 = fcode + "00001";
                            }
                            else
                            {
                                s8 = (Int32.Parse(s8) + 1).ToString();
                            }
                            myColor.Code = moh.MakeMask(s8, 5);

                            if (myColor.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم اضافة البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            }
                            else
                            {
                                grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                            break;

                        case 9:
                            ISize mySize = new ISize();
                            mySize.Branch = short.Parse(Session["Branch"].ToString());
                            mySize.Name1 = txtName1.Text;
                            mySize.Name2 = txtName2.Text;

                            string s9 = mySize.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (s9 == "0" || s9 == null)
                            {
                                s9 = fcode + "00001";
                            }
                            else
                            {
                                s9 = (Int32.Parse(s9) + 1).ToString();
                            }
                            mySize.Code = moh.MakeMask(s9, 5);

                            if (mySize.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم اضافة البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            }
                            else
                            {
                                grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                            break;

                        case 10:
                            IWidth myWidth = new IWidth();
                            myWidth.Branch = short.Parse(Session["Branch"].ToString());
                            myWidth.Name1 = txtName1.Text;
                            myWidth.Name2 = txtName2.Text;

                            string s10 = myWidth.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (s10 == "0" || s10 == null)
                            {
                                s10 = fcode + "00001";
                            }
                            else
                            {
                                s10 = (Int32.Parse(s10) + 1).ToString();
                            }
                            myWidth.Code = moh.MakeMask(s10, 5);

                            if (myWidth.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم اضافة البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            }
                            else
                            {
                                grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                            break;

                        case 11:
                            ICOO myCOO = new ICOO();
                            myCOO.Branch = short.Parse(Session["Branch"].ToString());
                            myCOO.Name1 = txtName1.Text;
                            myCOO.Name2 = txtName2.Text;

                            string s11 = myCOO.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (s11 == "0" || s11 == null)
                            {
                                s11 = fcode + "00001";
                            }
                            else
                            {
                                s11 = (Int32.Parse(s11) + 1).ToString();
                            }
                            myCOO.Code = moh.MakeMask(s11, 5);

                            if (myCOO.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم اضافة البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            }
                            else
                            {
                                grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                            break;

                        case 12:
                            Salesmen mySalesmen = new Salesmen();
                            mySalesmen.Branch = short.Parse(Session["Branch"].ToString());
                            mySalesmen.Name1 = txtName1.Text;
                            mySalesmen.Name2 = txtName2.Text;

                            string s12 = mySalesmen.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (s12 == "0" || s12 == null)
                            {
                                s12 = fcode + "00001";
                            }
                            else
                            {
                                s12 = (Int32.Parse(s12) + 1).ToString();
                            }
                            mySalesmen.Code = moh.MakeMask(s12, 5);

                            if (mySalesmen.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم اضافة البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            }
                            else
                            {
                                grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                            break;

                        case 13:
                            IUnit myUnit = new IUnit();
                            myUnit.Branch = short.Parse(Session["Branch"].ToString());
                            myUnit.Name1 = txtName1.Text;
                            myUnit.Name2 = txtName2.Text;

                            string s13 = myUnit.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (s13 == "0" || s13 == null)
                            {
                                s13 = fcode + "00001";
                            }
                            else
                            {
                                s13 = (Int32.Parse(s13) + 1).ToString();
                            }
                            myUnit.Code = moh.MakeMask(s13, 5);

                            if (myUnit.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم اضافة البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            }
                            else
                            {
                                grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                            break;

                        case 14:
                            Area myArea = new Area();
                            myArea.Branch = short.Parse(Session["Branch"].ToString());
                            myArea.Name1 = txtName1.Text;
                            myArea.Name2 = txtName2.Text;

                            string s14 = myArea.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (s14 == "0" || s14 == null)
                            {
                                s14 = fcode + "00001";
                            }
                            else
                            {
                                s14 = (Int32.Parse(s14) + 1).ToString();
                            }
                            myArea.Code = moh.MakeMask(s14, 5);

                            if (myArea.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم اضافة البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            }
                            else
                            {
                                grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                            break;

                        case 15:
                            CostAcc myCostAcc = new CostAcc();
                            myCostAcc.Branch = short.Parse(Session["Branch"].ToString());
                            myCostAcc.Name1 = txtName1.Text;
                            myCostAcc.Name2 = txtName2.Text;

                            string s15 = myCostAcc.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (s15 == "0" || s15 == null)
                            {
                                s15 = fcode + "00001";
                            }
                            else
                            {
                                s15 = (Int32.Parse(s15) + 1).ToString();
                            }
                            myCostAcc.Code = moh.MakeMask(s15, 5);

                            if (myCostAcc.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم اضافة البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            }
                            else
                            {
                                grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                            break;

                        case 16:
                            CarType myCarType = new CarType();
                            myCarType.cnn = WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString;
                            myCarType.Branch = short.Parse(Session["Branch"].ToString());
                            myCarType.FCode = fcode;
                            myCarType.Name1 = txtName1.Text;
                            myCarType.Name2 = txtName2.Text;
                            myCarType.FUpdate = false;
                            myCarType.LevelCode = "0001";
                            if (CurLevel == 2)
                            {
                                DropDownList ddlFType = gvr.FindControl("dllFType2") as DropDownList;
                                if (ddlFType != null)
                                {
                                    myCarType.LevelCode = ddlFType.SelectedValue;
                                }
                            }

                            string s16 = myCarType.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (s16 == "0" || s16 == null)
                            {
                                s16 = fcode + "0001";
                            }
                            else
                            {
                                s16 = moh.MakeMask((Int32.Parse(s16) + 1).ToString(), 4);

                            }
                            if (myCarType.FCode == "")
                            {
                                s1 = moh.MakeMask(s16, 4);
                            }
                            else
                            {
                                s16 = moh.MakeMask(s16, 8);
                            }
                            myCarType.Code = s16;

                            if (myCarType.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم اضافة البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            }
                            else
                            {
                                grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                            break;

                        case 17:
                            PLevel myPLevel = new PLevel();
                            myPLevel.Branch = short.Parse(Session["Branch"].ToString());
                            myPLevel.Name1 = txtName1.Text;
                            myPLevel.Name2 = txtName2.Text;

                            string s17 = myPLevel.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (s17 == "0" || s17 == null)
                            {
                                s17 = fcode + "00001";
                            }
                            else
                            {
                                s17 = (Int32.Parse(s17) + 1).ToString();
                            }
                            myPLevel.Code = moh.MakeMask(s17, 5);

                            if (myPLevel.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم اضافة البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            }
                            else
                            {
                                grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }                            
                            break;
                    }
                    updateCache(TypeFlag);
                    LoadCodesData();
                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), LbtnLevel1.Text, "اضافة", "اضافة بيانات البند " + txtName1.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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

        protected void grdCodes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string Code = grdCodes.DataKeys[e.RowIndex]["Code"].ToString();
                String FCode = "";
                switch (TypeFlag)
                {
                    case 1:
                        FCode = grdCodes.DataKeys[e.RowIndex]["FCode"].ToString();
                        ICat myAccess = new ICat();
                        myAccess.Branch = short.Parse(Session["Branch"].ToString());
                        myAccess.FCode = FCode;
                        myAccess.Code = Code;

                        if (myAccess.IsFather(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لا يمكن الغاء البند حيث انه مرتبط ببنود أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            e.Cancel = true;
                        }
                        else
                        {
                            if (!myAccess.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                e.Cancel = true;
                            }
                            else
                            {
                                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), LbtnLevel1.Text, "الغاء", "الغاء بيانات البند " + myAccess.Name1, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);                                
                            }
                        }
                        break;

                    case 2:
                        FCode = grdCodes.DataKeys[e.RowIndex]["FCode"].ToString();
                        PCat myPAccess = new PCat();
                        myPAccess.Branch = short.Parse(Session["Branch"].ToString());
                        myPAccess.FCode = FCode;
                        myPAccess.Code = Code;

                        if (myPAccess.IsFather(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لا يمكن الغاء البند حيث انه مرتبط ببنود أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            e.Cancel = true;
                        }
                        else
                        {
                            if (!myPAccess.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                e.Cancel = true;
                            }
                            else
                            {
                                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), LbtnLevel1.Text, "الغاء", "الغاء بيانات البند " + myPAccess.Name1, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);                                
                            }
                        }
                        break;

                    case 3:
                        FCode = grdCodes.DataKeys[e.RowIndex]["FCode"].ToString();
                        ECat myEAccess = new ECat();
                        myEAccess.Branch = short.Parse(Session["Branch"].ToString());
                        myEAccess.FCode = FCode;
                        myEAccess.Code = Code;

                        if (myEAccess.IsFather(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لا يمكن الغاء البند حيث انه مرتبط ببنود أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            e.Cancel = true;
                        }
                        else
                        {
                            if (!myEAccess.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                e.Cancel = true;
                            }
                            else
                            {
                                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), LbtnLevel1.Text, "الغاء", "الغاء بيانات البند " + myEAccess.Name1, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);                                
                            }
                        }
                        break;

                    case 4:
                        Acc myAcc = new Acc();
                        myAcc.Branch = short.Parse(Session["Branch"].ToString());
                        myAcc.FCode = FCode;
                        myAcc.Code = Code;

                        if (myAcc.IsFather(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لا يمكن الغاء البند حيث انه مرتبط ببنود أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            e.Cancel = true;
                        }
                        else
                        {
                            if (!myAcc.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                e.Cancel = true;
                            }
                            else
                            {

                                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), LbtnLevel1.Text, "الغاء", "الغاء بيانات البند " + myAcc.Name1, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString); 
                            }
                        }
                        break;

                    case 5:
                        AccProject myProject = new AccProject();
                        myProject.Branch = short.Parse(Session["Branch"].ToString());
                        myProject.Code = Code;

                        // Pending Work Check if Project Used Before

                        if (!myProject.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            e.Cancel = true;
                        }
                        else
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), LbtnLevel1.Text, "الغاء", "الغاء بيانات البند " + myProject.Name1, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }
                        break;

                    case 6:
                        CostCenter myCost = new CostCenter();
                        myCost.Branch = short.Parse(Session["Branch"].ToString());
                        myCost.Code = Code;

                        // Pending Work Check if Cost Center Used Before

                        if (!myCost.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            e.Cancel = true;
                        }
                        else
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), LbtnLevel1.Text, "الغاء", "الغاء بيانات البند " + myCost.Name1, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }
                        break;

                    case 7:
                        AccCenter myCenter = new AccCenter();
                        myCenter.Branch = short.Parse(Session["Branch"].ToString());
                        myCenter.Code = Code;

                        // Pending Work Check if Cost Center Used Before

                        if (!myCenter.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            e.Cancel = true;
                        }
                        else
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), LbtnLevel1.Text, "الغاء", "الغاء بيانات البند " + myCenter.Name1, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }
                        break;

                    case 8:
                        IColor myColor = new IColor();
                        myColor.Branch = short.Parse(Session["Branch"].ToString());
                        myColor.Code = Code;

                        // Pending Work Check if Color Used Before

                        if (!myColor.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            e.Cancel = true;
                        }
                        else
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), LbtnLevel1.Text, "الغاء", "الغاء بيانات البند " + myColor.Name1, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }
                        break;

                    case 9:
                        ISize mySize = new ISize();
                        mySize.Branch = short.Parse(Session["Branch"].ToString());
                        mySize.Code = Code;

                        // Pending Work Check if Size Used Before

                        if (!mySize.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            e.Cancel = true;
                        }
                        else
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), LbtnLevel1.Text, "الغاء", "الغاء بيانات البند " + mySize.Name1, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }
                        break;

                    case 10:
                        IWidth myWidth = new IWidth();
                        myWidth.Branch = short.Parse(Session["Branch"].ToString());
                        myWidth.Code = Code;

                        // Pending Work Check if Width Used Before

                        if (!myWidth.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            e.Cancel = true;
                        }
                        else
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), LbtnLevel1.Text, "الغاء", "الغاء بيانات البند " + myWidth.Name1, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }
                        break;

                    case 11:
                        ICOO myCity = new ICOO();
                        myCity.Branch = short.Parse(Session["Branch"].ToString());
                        myCity.Code = Code;

                        // Pending Work Check if City Used Before

                        if (!myCity.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            e.Cancel = true;
                        }
                        else
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), LbtnLevel1.Text, "الغاء", "الغاء بيانات البند " + myCity.Name1, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }
                        break;

                    case 12:
                        Salesmen mySales = new Salesmen();
                        mySales.Branch = short.Parse(Session["Branch"].ToString());
                        mySales.Code = Code;

                        // Pending Work Check if Salesmen Used Before

                        if (!mySales.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            e.Cancel = true;
                        }
                        else
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), LbtnLevel1.Text, "الغاء", "الغاء بيانات البند " + mySales.Name1, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }
                        break;

                    case 13:
                        IUnit myUnit = new IUnit();
                        myUnit.Branch = short.Parse(Session["Branch"].ToString());
                        myUnit.Code = Code;

                        // Pending Work Check if Salesmen Used Before

                        if (!myUnit.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            e.Cancel = true;
                        }
                        else
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), LbtnLevel1.Text, "الغاء", "الغاء بيانات البند " + myUnit.Name1, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }
                        break;

                    case 14:
                        Area myArea = new Area();
                        myArea.Branch = short.Parse(Session["Branch"].ToString());
                        myArea.Code = Code;

                        // Pending Work Check if Project Used Before

                        if (!myArea.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            e.Cancel = true;
                        }
                        else
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), LbtnLevel1.Text, "الغاء", "الغاء بيانات البند " + myArea.Name1, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }
                        break;

                    case 15:
                        CostAcc myCostAcc = new CostAcc();
                        myCostAcc.Branch = short.Parse(Session["Branch"].ToString());
                        myCostAcc.Code = Code;

                        // Pending Work Check if Project Used Before

                        if (!myCostAcc.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            e.Cancel = true;
                        }
                        else
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), LbtnLevel1.Text, "الغاء", "الغاء بيانات البند " + myCostAcc.Name1, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }
                        break;

                    case 16:
                        FCode = grdCodes.DataKeys[e.RowIndex]["FCode"].ToString();
                        CarType myCarType = new CarType();
                        myCarType.cnn = WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString;
                        myCarType.Branch = short.Parse(Session["Branch"].ToString());
                        myCarType.FCode = FCode;
                        myCarType.Code = Code;

                        if (myCarType.IsFather(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لا يمكن الغاء البند حيث انه مرتبط ببنود أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            e.Cancel = true;
                        }
                        else
                        {
                            if (!myCarType.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                e.Cancel = true;
                            }
                            else
                            {
                                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), LbtnLevel1.Text, "الغاء", "الغاء بيانات البند " + myCarType.Name1, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }
                        }
                        break;

                    case 17:
                        PLevel myPLevel = new PLevel();
                        myPLevel.Branch = short.Parse(Session["Branch"].ToString());
                        myPLevel.Code = Code;

                        // Pending Work Check if Project Used Before

                        if (!myPLevel.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            e.Cancel = true;
                        }
                        else
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), LbtnLevel1.Text, "الغاء", "الغاء بيانات البند " + myPLevel.Name1, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }
                        break;
                }

                if (!e.Cancel)
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult.Text = "لقد تم حذف السجل بنجاح";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                    LoadCodesData();
                    updateCache(TypeFlag);
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

        protected void grdCodes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                LoadCodesData();
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


        protected void LbtnLevel1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                switch (int.Parse(e.CommandName))
                {
                    case 1:
                        LbtnLevel1.Visible = true;
                        LbtnLevel2.Visible = false;
                        LbtnLevel3.Visible = false;
                        LbtnLevel4.Visible = false;
                        LbtnLevel5.Visible = false;
                        fcode = "";
                        CurLevel = 1;
                        LoadCodesData();
                        break;
                    case 2:
                        LbtnLevel1.Visible = true;
                        LbtnLevel2.Visible = true;
                        LbtnLevel3.Visible = false;
                        LbtnLevel4.Visible = false;
                        LbtnLevel5.Visible = false;
                        fcode = LbtnLevel2.ToolTip;
                        CurLevel = 2;
                        LoadCodesData();
                        break;
                    case 3:
                        LbtnLevel1.Visible = true;
                        LbtnLevel2.Visible = true;
                        LbtnLevel3.Visible = true;
                        LbtnLevel4.Visible = false;
                        LbtnLevel5.Visible = false;
                        fcode = LbtnLevel3.ToolTip;
                        CurLevel = 3;
                        LoadCodesData();
                        break;
                    case 4:
                        LbtnLevel1.Visible = true;
                        LbtnLevel2.Visible = true;
                        LbtnLevel3.Visible = true;
                        LbtnLevel4.Visible = true;
                        LbtnLevel5.Visible = false;
                        fcode = LbtnLevel4.ToolTip;
                        CurLevel = 4;
                        LoadCodesData();
                        break;
                    case 5:
                        LbtnLevel1.Visible = true;
                        LbtnLevel2.Visible = true;
                        LbtnLevel3.Visible = true;
                        LbtnLevel4.Visible = true;
                        LbtnLevel5.Visible = true;
                        fcode = LbtnLevel5.ToolTip;
                        CurLevel = 5;
                        LoadCodesData();
                        break;
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

        protected void dllFType2_Init(object sender, EventArgs e)
        {
            DropDownList ddlFType = sender as DropDownList;
            if (TypeFlag == 16)
            {
                GridViewRow gvr = ddlFType.NamingContainer as GridViewRow;
                string FCode = grdCodes.DataKeys[gvr.RowIndex]["FCode"].ToString();
                string Code = grdCodes.DataKeys[gvr.RowIndex]["Code"].ToString();
                PLevel myacc = new PLevel();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                ddlFType.DataTextField = "name1";
                ddlFType.DataValueField = "Code";
                ddlFType.DataSource = myacc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                ddlFType.DataBind();
                if (Code != null && FCode != null)
                {
                    CarType myCarType = new CarType();
                    myCarType.cnn = WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString;
                    myCarType.Branch = short.Parse(Session["Branch"].ToString());
                    myCarType.FCode = FCode;
                    myCarType.Code = Code;
                    myCarType = myCarType.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myCarType != null)
                    {
                        ddlFType.SelectedValue = myCarType.LevelCode;
                    }
                }
            }
            else
            {
                if (ddlFType.Items.Count == 0 && TypeFlag == 4)
                {
                    GridViewRow gvr = ddlFType.NamingContainer as GridViewRow;
                    string FCode = grdCodes.DataKeys[gvr.RowIndex]["FCode"].ToString();
                    string Code = grdCodes.DataKeys[gvr.RowIndex]["Code"].ToString();
                    Acc myacc = new Acc();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.FCode = FCode;
                    myacc.Code = Code;
                    CheckType(ddlFType);
                    if (myacc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        ddlFType.SelectedValue = myacc.FType;
                    }
                }
            }
        }

        protected void CheckType(DropDownList ddltype)
        {
            Acc myacc = new Acc();
            if (AccountType)
            {
                if (CurLevel == 1)
                {
                    ddltype.Items.Clear();
                    ddltype.Items.Add(new ListItem("حساب ميزانية - أصول", "1"));
                    ddltype.Items.Add(new ListItem("حساب ميزانية - مطلوبات وحقوق ملكية", "2"));
                    ddltype.Items.Add(new ListItem("الارباح والخسائر - الايرادات", "3"));
                    ddltype.Items.Add(new ListItem("الارباح والخسائر - المصروفات", "4"));
                    ddltype.Items.Add(new ListItem("التشغيل والمتاجرة - الايرادات", "5"));
                    ddltype.Items.Add(new ListItem("التشغيل والمتاجرة - المصروفات", "6"));
                }
                else if (CurLevel == 2)
                {
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.Code = fcode;
                    if (myacc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        if (myacc.FType == "1")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("حساب ميزانية - أصول ثابتة", "1"));
                            ddltype.Items.Add(new ListItem("حساب ميزانية - أصول متداولة", "2"));
                        }
                        else if (myacc.FType == "2")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("حساب ميزانية - مطلوبات متداولة", "3"));
                            ddltype.Items.Add(new ListItem("حساب ميزانية - حقوق الملكية", "4"));
                        }
                        else if (myacc.FType == "3")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("الارباح والخسائر - الايرادات", "5"));
                            ddltype.SelectedIndex = 0;
                        }
                        else if (myacc.FType == "4")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("الارباح والخسائر - المصروفات", "6"));
                            ddltype.SelectedIndex = 0;
                        }
                        else if (myacc.FType == "5")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("التشغيل والمتاجرة - الايرادات", "7"));
                            ddltype.SelectedIndex = 0;
                        }
                        else if (myacc.FType == "6")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("التشغيل والمتاجرة - المصروفات", "8"));
                            ddltype.SelectedIndex = 0;
                        }
                    }
                }
                else if (CurLevel == 3)
                {
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.Code = fcode;
                    if (myacc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        if (myacc.FType == "1")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("حساب ميزانية - أصول ثابتة", "1"));
                            ddltype.SelectedIndex = 0;
                        }
                        else if (myacc.FType == "2")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("حساب ميزانية - أصول متداولة", "2"));
                            ddltype.SelectedIndex = 0;
                        }
                        else if (myacc.FType == "3")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("حساب ميزانية - مطلوبات متداولة", "3"));
                            ddltype.SelectedIndex = 0;
                        }
                        else if (myacc.FType == "4")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("حساب ميزانية - حقوق الملكية", "4"));
                            ddltype.SelectedIndex = 0;
                        }
                        else if (myacc.FType == "5")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("الارباح والخسائر - الايرادات", "5"));
                            ddltype.SelectedIndex = 0;
                        }
                        else if (myacc.FType == "6")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("الارباح والخسائر - المصروفات", "6"));
                            ddltype.SelectedIndex = 0;
                        }
                        else if (myacc.FType == "7")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("التشغيل والمتاجرة - الايرادات", "7"));
                            ddltype.SelectedIndex = 0;
                        }
                        else if (myacc.FType == "8")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("التشغيل والمتاجرة - المصروفات", "8"));
                            ddltype.SelectedIndex = 0;
                        }
                    }
                 }
            }
            else
            {
                if (CurLevel == 1)
                {
                    ddltype.Items.Clear();
                    ddltype.Items.Add(new ListItem("حساب ميزانية - أصول", "1"));
                    ddltype.Items.Add(new ListItem("حساب ميزانية - مطلوبات وحقوق ملكية", "2"));
                    ddltype.Items.Add(new ListItem("قائمة الدخل - الايرادات", "3"));
                    ddltype.Items.Add(new ListItem("قائمة الدخل - المصروفات", "4"));
                }
                else if (CurLevel == 2)
                {
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.Code = fcode;
                    if (myacc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        if (myacc.FType == "1")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("حساب ميزانية - أصول ثابتة", "1"));
                            ddltype.Items.Add(new ListItem("حساب ميزانية - أصول متداولة", "2"));
                        }
                        else if (myacc.FType == "2")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("حساب ميزانية - مطلوبات متداولة", "3"));
                            ddltype.Items.Add(new ListItem("حساب ميزانية - حقوق الملكية", "4"));
                        }
                        else if (myacc.FType == "3")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("قائمة الدخل - الايرادات", "5"));
                            ddltype.SelectedIndex = 0;
                        }
                        else if (myacc.FType == "4")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("قائمة الدخل - المصروفات", "6"));
                            ddltype.SelectedIndex = 0;
                        }
                    }
                }
                else if (CurLevel == 3)
                {
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.Code = fcode;
                    if (myacc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        if (myacc.FType == "1")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("حساب ميزانية - أصول ثابتة", "1"));
                            ddltype.SelectedIndex = 0;
                        }
                        else if (myacc.FType == "2")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("حساب ميزانية - أصول متداولة", "2"));
                            ddltype.SelectedIndex = 0;
                        }
                        else if (myacc.FType == "3")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("حساب ميزانية - مطلوبات متداولة", "3"));
                            ddltype.SelectedIndex = 0;
                        }
                        else if (myacc.FType == "4")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("حساب ميزانية - حقوق الملكية", "4"));
                            ddltype.SelectedIndex = 0;
                        }
                        else if (myacc.FType == "5")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("قائمة الدخل - الايرادات", "5"));
                            ddltype.SelectedIndex = 0;
                        }
                        else if (myacc.FType == "6")
                        {
                            ddltype.Items.Clear();
                            ddltype.Items.Add(new ListItem("قائمة الدخل - المصروفات", "6"));
                            ddltype.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        protected void btnUpdate_Load(object sender, EventArgs e)
        {
            ((ImageButton)sender).Visible = true;
        }



        public void PutCarType(Acc myAcc,string s4)
        {
            if (myAcc.FCode == "1101" && myAcc.FLevel == 4)
            {
                CarsType myacc = new CarsType();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                myacc.Code = int.Parse(s4);
                myacc = myacc.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myacc == null)
                {
                    myacc = new CarsType();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.Code = int.Parse(s4);
                    myacc.Name1 = myAcc.Name1;
                    myacc.Name2 = myAcc.Name2;
                    myacc.ExpAcc = "-1";
                    myacc.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }
                else
                {
                    myacc.Name1 = myAcc.Name1;
                    myacc.Name2 = myAcc.Name2;
                    //myacc.ExpAcc = "-1";
                    myacc.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }
            }
        }

        public void updateCache(short FType)
        {
            switch (FType)
            {
                case 4:
                        if (Cache["AllACC" + Session["CNN2"].ToString()] != null) Cache.Remove("AllACC" + Session["CNN2"].ToString());
                        Acc myAcc = new Acc();
                        myAcc.Branch = short.Parse(Session["Branch"].ToString());
                        //Cache["LastACC" + Session["CNN2"].ToString()] = myAcc.GetLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        Cache.Insert("AllACC" + Session["CNN2"].ToString(), myAcc.Getall(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        break;
                case 5:
                        if (Cache["LastProject" + Session["CNN2"].ToString()] != null) Cache.Remove("LastProject" + Session["CNN2"].ToString());
                        AccProject myProject = new AccProject();
                        myProject.Branch = short.Parse(Session["Branch"].ToString());
                        Cache.Insert("LastProject" + Session["CNN2"].ToString(), myProject.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        break;
                case 6:
                        if (Cache["LastCostCenter" + Session["CNN2"].ToString()] != null) Cache.Remove("LastCostCenter" + Session["CNN2"].ToString());
                        CostCenter myCostCenter = new CostCenter();
                        myCostCenter.Branch = 1;
                        Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        break;
                case 14:
                        if (Cache["LastArea" + Session["CNN2"].ToString()] != null) Cache.Remove("LastArea" + Session["CNN2"].ToString());
                        Area myArea = new Area();
                        myArea.Branch = 1;
                        Cache.Insert("LastArea" + Session["CNN2"].ToString(), myArea.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        break;
                case 15:
                        if (Cache["LastCostAcc" + Session["CNN2"].ToString()] != null) Cache.Remove("LastCostAcc" + Session["CNN2"].ToString());
                        CostAcc myCostAcc = new CostAcc();
                        myCostAcc.Branch = short.Parse(Session["Branch"].ToString());
                        Cache.Insert("LastCostAcc" + Session["CNN2"].ToString(), myCostAcc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        break;                       
            }
                           
        }

    }
}