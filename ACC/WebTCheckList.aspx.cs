using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using BLL;
using System.Web.Configuration;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace ACC
{
    public partial class WebTCheckList : System.Web.UI.Page
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
        public string VouType
        {
            get
            {
                if (ViewState["VouType"] == null)
                {
                    ViewState["VouType"] = "1";
                }
                return ViewState["VouType"].ToString();
            }
            set { ViewState["VouType"] = value; }
        }
        public void EditMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            BtnEdit.Visible = true;     // && (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass182;
            BtnNew.Visible = false;
            BtnDelete.Visible = true;       // && (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass183;
        }

        public void NewMode()
        {
            txtVouNo.ReadOnly = false;
            txtVouNo.BackColor = System.Drawing.Color.White;

            BtnEdit.Visible = false;
            BtnNew.Visible = true;      // && (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass181;
            BtnDelete.Visible = false;
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
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad01);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad02);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad03);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad04);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad05);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad06);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad07);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad08);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad09);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad10);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad11);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad12);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad13);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad14);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad15);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad16);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad17);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad18);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad19);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad20);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad21);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad22);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad23);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad24);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad25);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad26);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad27);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad28);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad29);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad30);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad31);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad32);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad33);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad34);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad35);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad36);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad37);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad38);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad39);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad40);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad41);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad42);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad43);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad44);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad45);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad46);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad47);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad48);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad49);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad50);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad51);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad52);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad53);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad54);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad55);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnLoad56);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttach);
                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = GetLocalResourceObject("Header2").ToString();   // "Vehical Movement Check List";

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

                    if (Request.QueryString["FType"] != null) VouType = Request.QueryString["FType"].ToString();

                    if (VouType == "1")
                    {
                        this.Page.Header.Title = GetLocalResourceObject("Note1").ToString();  // "بيان تسليم شاحنة";   // "Vehical Movement Check List";
                        lblHeader.Text = GetLocalResourceObject("Note1").ToString();  // "بيان تسليم شاحنة";
                    }
                    else if (VouType == "2")
                    {
                        this.Page.Header.Title = GetLocalResourceObject("Note2").ToString();  // "بيان تحويل شاحنة";  // "Vehical Movement Check List";
                        lblHeader.Text = GetLocalResourceObject("Note2").ToString();    // "بيان تحويل شاحنة";
                    }
                    else
                    {
                        this.Page.Header.Title = GetLocalResourceObject("Note3").ToString();    // "بيان استلام شاحنة";   // "Vehical Movement Check List";
                        lblHeader.Text = GetLocalResourceObject("Note3").ToString();    // "بيان استلام شاحنة";
                    }

                    CarsType myCarsType = new CarsType();
                    myCarsType.Branch = short.Parse(Session["Branch"].ToString());
                    ddlVehType.DataTextField = "Name1";
                    ddlVehType.DataValueField = "Code";
                    ddlVehType.DataSource = myCarsType.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlVehType.DataBind();
                    ddlVehType.Items.Insert(0, new ListItem(GetLocalResourceObject("VType").ToString(), "-1", true));  // "--- Select Vehical Type ---"

                    ddlVehicle.Items.Insert(0, new ListItem(GetLocalResourceObject("SVehical").ToString(), "-1", true)); // "--- Select Vehical ---"

                    Drivers myDrive = new Drivers();
                    myDrive.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlFrom.DataTextField = GetLocalResourceObject("Name2").ToString(); // "Name2";
                    ddlFrom.DataValueField = "Code";
                    ddlFrom.DataSource = (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()]);
                    ddlFrom.DataBind();
                    ddlFrom.Items.Insert(0, new ListItem(GetLocalResourceObject("WorkShop").ToString(), "-1", true));  // "WorkShop"
                    ddlFrom.Items.Add(new ListItem(GetLocalResourceObject("Others").ToString(), "0"));  // "WorkShop"

                    ddlTo.DataTextField = GetLocalResourceObject("Name2").ToString();  // "Name2";
                    ddlTo.DataValueField = "Code";
                    ddlTo.DataSource = (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()]);
                    ddlTo.DataBind();
                    ddlTo.Items.Insert(0, new ListItem(GetLocalResourceObject("WorkShop").ToString(), "-1", true));
                    ddlTo.Items.Add(new ListItem(GetLocalResourceObject("Others").ToString(), "0"));  // "WorkShop"

                    Cars myCar = new Cars();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                    myCar.CarsType = 2;
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlItem00.DataTextField = "CarType2";
                    ddlItem00.DataValueField = "Code";
                    ddlItem00.DataSource = (from itm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                            where itm.CarsType == 2 || itm.CarsType == 4 || itm.CarsType == 5 || itm.CarsType == 29
                                             select new Cars
                                             {
                                                 Code = itm.Code,
                                                 CarType2 = itm.CarType2   // .Substring(0, 10)
                                             }).ToList();
                    ddlItem00.DataBind();
                    ddlItem00.Items.Insert(0, new ListItem("Select", "-1", true));
                  
                    //BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass181;
                    //BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass182;
                    //BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass183;
                    //BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass184;
                    //BtnFind.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass184;
                    rdoType.SelectedValue = VouType;
                    rdoType_SelectedIndexChanged(sender, e);

                    BtnClear_Click(sender, null);
                }
                else
                {
                    SetImages();
                    LblCodesResult.Text = "";
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString() + "11111";
            }
        }

        protected void BtnClear_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                NewMode();
                txtVouNo.Text = "";
                txtVouDate.Text = "";
                txtModel.Text = "";
                txtInTime.Text = "";
                txtInTime.Text = String.Format("{0:HH:mm:ss}", moh.Nows());  //moh.Nows().ToShortTimeString();
                txtCarNo.Text = "";
                ddlFrom.SelectedIndex = 0;
                ddlFrom_SelectedIndexChanged(sender, e);
                txtFrom2.Text = "";
                ddlTo.SelectedIndex = 0;
                ddlTo_SelectedIndexChanged(sender, e);
                txtTo2.Text = "";
                ddlVehType.SelectedIndex = 1;
                ddlVehType_SelectedIndexChanged(sender, e);
                ddlVehicle.SelectedIndex = 0;
                ddlPCheck.Items.Clear();
                ddlPCheck.SelectedIndex = -1;
                txtACSNo.Text = "";
                txtACType.Text = "";
                txtEngineSNo.Text = "";
                txtEngineType.Text = "";
                txtGearSNo.Text = "";
                txtGearType.Text = "";
                txtIPSNo.Text = "";
                txtIPType.Text = "";
                txtModel.Text = "";
                ClearSItems();

                ddlItem00.SelectedIndex = 0;
                txtItem01.Text = "";
                txtItem02.Text = "";
                txtItem03.Text = "";
                txtItem04.Text = "";
                txtItem05.Text = "";
                txtItem06.Text = "";
                txtItem07.Text = "";
                txtItem08.Text = "";
                txtItem09.Text = "";
                txtItem10.Text = "";
                txtItem11.Text = "";
                txtItem12.Text = "";
                txtItem13.Text = "";
                txtItem14.Text = "";
                txtItem15.Text = "";
                txtItem16.Text = "";
                txtItem17.Text = "";
                txtItem18.Text = "";
                txtItem19.Text = "";
                txtItem20.Text = "";
                txtItem21.Text = "";
                txtItem22.Text = "";
                txtItem23.Text = "";
                txtItem24.Text = "";
                txtItem25.Text = "";
                txtItem26.Text = "";
                txtItem27.Text = "";
                txtItem28.Text = "";
                txtItem29.Text = "";
                txtItem30.Text = "";
                txtItem31.Text = "";
                txtItem32.Text = "";
                txtItem33.Text = "";
                txtItem34.Text = "";
                txtItem35.Text = "";
                txtItem36.Text = "";
                txtItem37.Text = "";
                txtItem38.Text = "";
                txtItem39.Text = "";
                txtItem40.Text = "";
                txtItem41.Text = "";
                txtItem42.Text = "";
                txtItem43.Text = "";
                txtItem44.Text = "";
                txtItem45.Text = "";
                txtItem46.Text = "";
                txtItem47.Text = "";
                txtItem48.Text = "";
                txtItem49.Text = "";
                txtItem50.Text = "";
                txtItem51.Text = "";
                txtItem52.Text = "";
                txtItem53.Text = "";
                txtItem54.Text = "";
                txtItem55.Text = "";
                txtItem56.Text = "";

                Img01.Src = "~/images/True.gif";
                Img02.Src = "~/images/True.gif";
                Img03.Src = "~/images/True.gif";
                Img04.Src = "~/images/True.gif";
                Img05.Src = "~/images/True.gif";
                Img06.Src = "~/images/True.gif";
                Img07.Src = "~/images/True.gif";
                Img08.Src = "~/images/True.gif";
                Img09.Src = "~/images/True.gif";
                Img10.Src = "~/images/True.gif";
                Img11.Src = "~/images/True.gif";
                Img12.Src = "~/images/True.gif";
                Img13.Src = "~/images/True.gif";
                Img14.Src = "~/images/True.gif";
                Img15.Src = "~/images/True.gif";
                Img16.Src = "~/images/True.gif";
                Img17.Src = "~/images/True.gif";
                Img18.Src = "~/images/True.gif";
                Img19.Src = "~/images/True.gif";
                Img20.Src = "~/images/True.gif";
                Img21.Src = "~/images/True.gif";
                Img22.Src = "~/images/True.gif";
                Img23.Src = "~/images/True.gif";
                Img24.Src = "~/images/True.gif";
                Img25.Src = "~/images/True.gif";
                Img26.Src = "~/images/True.gif";
                Img27.Src = "~/images/True.gif";
                Img28.Src = "~/images/True.gif";
                Img29.Src = "~/images/True.gif";
                Img30.Src = "~/images/True.gif";
                Img31.Src = "~/images/True.gif";
                Img32.Src = "~/images/True.gif";
                Img33.Src = "~/images/True.gif";
                Img34.Src = "~/images/True.gif";
                Img35.Src = "~/images/True.gif";
                Img36.Src = "~/images/True.gif";
                Img37.Src = "~/images/True.gif";
                Img38.Src = "~/images/True.gif";
                Img39.Src = "~/images/True.gif";
                Img40.Src = "~/images/True.gif";
                Img41.Src = "~/images/True.gif";
                Img42.Src = "~/images/True.gif";
                Img43.Src = "~/images/True.gif";
                Img44.Src = "~/images/True.gif";
                Img45.Src = "~/images/True.gif";
                Img46.Src = "~/images/True.gif";
                Img47.Src = "~/images/True.gif";
                Img48.Src = "~/images/True.gif";
                Img49.Src = "~/images/True.gif";
                Img50.Src = "~/images/True.gif";
                Img51.Src = "~/images/True.gif";
                Img52.Src = "~/images/True.gif";
                Img53.Src = "~/images/True.gif";
                Img54.Src = "~/images/True.gif";
                Img55.Src = "~/images/True.gif";
                Img56.Src = "~/images/True.gif";

                BtnView001.Visible = false;
                BtnView002.Visible = false;
                BtnView003.Visible = false;
                BtnView004.Visible = false;
                BtnView005.Visible = false;
                BtnView006.Visible = false;
                BtnView007.Visible = false;
                BtnView008.Visible = false;
                BtnView009.Visible = false;
                BtnView010.Visible = false;
                BtnView011.Visible = false;
                BtnView012.Visible = false;
                BtnView013.Visible = false;
                BtnView014.Visible = false;
                BtnView015.Visible = false;
                BtnView016.Visible = false;
                BtnView017.Visible = false;
                BtnView018.Visible = false;
                BtnView019.Visible = false;
                BtnView020.Visible = false;
                BtnView021.Visible = false;
                BtnView022.Visible = false;
                BtnView023.Visible = false;
                BtnView024.Visible = false;
                BtnView025.Visible = false;
                BtnView026.Visible = false;
                BtnView027.Visible = false;
                BtnView028.Visible = false;
                BtnView029.Visible = false;
                BtnView030.Visible = false;
                BtnView031.Visible = false;
                BtnView032.Visible = false;
                BtnView033.Visible = false;
                BtnView034.Visible = false;
                BtnView035.Visible = false;
                BtnView036.Visible = false;
                BtnView037.Visible = false;
                BtnView038.Visible = false;
                BtnView039.Visible = false;
                BtnView040.Visible = false;
                BtnView041.Visible = false;
                BtnView042.Visible = false;
                BtnView043.Visible = false;
                BtnView044.Visible = false;
                BtnView045.Visible = false;
                BtnView046.Visible = false;
                BtnView047.Visible = false;
                BtnView048.Visible = false;
                BtnView049.Visible = false;
                BtnView050.Visible = false;
                BtnView051.Visible = false;
                BtnView052.Visible = false;
                BtnView053.Visible = false;
                BtnView054.Visible = false;
                BtnView055.Visible = false;
                BtnView056.Visible = false;

                BtnView001.PostBackUrl = "";
                BtnView002.PostBackUrl = "";
                BtnView003.PostBackUrl = "";
                BtnView004.PostBackUrl = "";
                BtnView005.PostBackUrl = "";
                BtnView006.PostBackUrl = "";
                BtnView007.PostBackUrl = "";
                BtnView008.PostBackUrl = "";
                BtnView009.PostBackUrl = "";
                BtnView010.PostBackUrl = "";
                BtnView011.PostBackUrl = "";
                BtnView012.PostBackUrl = "";
                BtnView013.PostBackUrl = "";
                BtnView014.PostBackUrl = "";
                BtnView015.PostBackUrl = "";
                BtnView016.PostBackUrl = "";
                BtnView017.PostBackUrl = "";
                BtnView018.PostBackUrl = "";
                BtnView019.PostBackUrl = "";
                BtnView020.PostBackUrl = "";
                BtnView021.PostBackUrl = "";
                BtnView022.PostBackUrl = "";
                BtnView023.PostBackUrl = "";
                BtnView024.PostBackUrl = "";
                BtnView025.PostBackUrl = "";
                BtnView026.PostBackUrl = "";
                BtnView027.PostBackUrl = "";
                BtnView028.PostBackUrl = "";
                BtnView029.PostBackUrl = "";
                BtnView030.PostBackUrl = "";
                BtnView031.PostBackUrl = "";
                BtnView032.PostBackUrl = "";
                BtnView033.PostBackUrl = "";
                BtnView034.PostBackUrl = "";
                BtnView035.PostBackUrl = "";
                BtnView036.PostBackUrl = "";
                BtnView037.PostBackUrl = "";
                BtnView038.PostBackUrl = "";
                BtnView039.PostBackUrl = "";
                BtnView040.PostBackUrl = "";
                BtnView041.PostBackUrl = "";
                BtnView042.PostBackUrl = "";
                BtnView043.PostBackUrl = "";
                BtnView044.PostBackUrl = "";
                BtnView045.PostBackUrl = "";
                BtnView046.PostBackUrl = "";
                BtnView047.PostBackUrl = "";
                BtnView048.PostBackUrl = "";
                BtnView049.PostBackUrl = "";
                BtnView050.PostBackUrl = "";
                BtnView051.PostBackUrl = "";
                BtnView052.PostBackUrl = "";
                BtnView053.PostBackUrl = "";
                BtnView054.PostBackUrl = "";
                BtnView055.PostBackUrl = "";
                BtnView056.PostBackUrl = "";
                HImgS.Value = "000000000000000000000000000000000000000000000000000000000000";
                txtRemarks.Text = "";
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                if (sender != null)
                {
                    ChList myJv = new ChList();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.VouType = short.Parse(VouType);
                    myJv.VouLoc = short.Parse(StoreNo);
                    int? i = myJv.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (i == 0 || i == null)
                    {
                        i = 1;
                    }
                    else
                    {
                        i++;
                    }
                    txtVouNo.Text = i.ToString();
                }
                txtVouDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                //rdoType_SelectedIndexChanged(sender, e);
                LoadListData();
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString() + "22222";
            }
        }

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    txtVouNo.Text = txtVouNo.Text.Trim();
                    ChList myacc = new ChList();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.VouType = short.Parse(VouType);
                    myacc.VouLoc = short.Parse(StoreNo);
                    myacc.VouNo = int.Parse(txtVouNo.Text);
                    myacc = myacc.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc == null)
                    {
                        myacc = new ChList();
                        myacc.Branch = short.Parse(Session["Branch"].ToString());
                        myacc.VouLoc = short.Parse(StoreNo);
                        myacc.VouNo = int.Parse(txtVouNo.Text);
                        PutItem(myacc);
                        if (myacc.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = GetLocalResourceObject("SaveData").ToString();  //"Saving Data Successfully Done";

                            Cars myInv = new Cars();
                            myInv.Branch = short.Parse(Session["Branch"].ToString());
                            if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myInv.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                            myInv.Code = ddlVehicle.SelectedValue;
                            myInv.CarsType = int.Parse(ddlVehType.SelectedValue);
                            myInv = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                     where sitm.Code == myInv.Code
                                     select sitm).FirstOrDefault();
                            if (myInv != null)
                            {
                                if (myacc.ToPerson == "0" || myacc.ToPerson == "-1")
                                {
                                    myInv.DriverCode = "-1";
                                    myInv.PLoc = myacc.ToPerson == "-1" ? "في الورشة" : txtTo2.Text; 
                                }
                                else
                                {
                                    myInv.PLoc = "التشغيل";
                                    myInv.DriverCode = myacc.ToPerson;
                                }
                                
                                myInv.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }                        


                            string vNumber = txtVouNo.Text;
                            BtnClear_Click(sender, e);
                            BtnNew.Enabled = true;
                            PrintMe(vNumber);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("SaveError").ToString();  // "Error During Saving Data ... Try Again";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("DuplicateNo").ToString();  // "Duplicate Repair Check List No.";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }

                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        public void PutItem(ChList myacc)
        {
            myacc.VouType = short.Parse(VouType);
            myacc.InTime = txtInTime.Text;            
            myacc.Vechicle = ddlVehicle.SelectedValue;
            myacc.FromPerson = ddlFrom.SelectedValue;
            myacc.ToPerson = ddlTo.SelectedValue;
            myacc.VehType = int.Parse(ddlVehType.SelectedValue);
            myacc.VouDate = txtVouDate.Text;
            myacc.ACSNo = txtACSNo.Text;
            myacc.ACType = txtACType.Text;
            myacc.EngineSNo = txtEngineSNo.Text;
            myacc.EngineType = txtEngineType.Text;
            myacc.GearSNo = txtGearSNo.Text;
            myacc.GearType = txtGearType.Text;
            myacc.IPSNo = txtIPSNo.Text;
            myacc.IPType = txtIPType.Text;
            if(ddlPCheck.SelectedIndex != -1) myacc.PVouNo = ddlPCheck.SelectedValue;
            myacc.Pic01 = BtnView001.PostBackUrl;
            myacc.Pic02 = BtnView002.PostBackUrl;
            myacc.Pic03 = BtnView003.PostBackUrl;
            myacc.Pic04 = BtnView004.PostBackUrl;
            myacc.Pic05 = BtnView005.PostBackUrl;
            myacc.Pic06 = BtnView006.PostBackUrl;
            myacc.Pic07 = BtnView007.PostBackUrl;
            myacc.Pic08 = BtnView008.PostBackUrl;
            myacc.Pic09 = BtnView009.PostBackUrl;
            myacc.Pic10 = BtnView010.PostBackUrl;
            myacc.Pic11 = BtnView011.PostBackUrl;
            myacc.Pic12 = BtnView012.PostBackUrl;
            myacc.Pic13 = BtnView013.PostBackUrl;
            myacc.Pic14 = BtnView014.PostBackUrl;
            myacc.Pic15 = BtnView015.PostBackUrl;
            myacc.Pic16 = BtnView016.PostBackUrl;
            myacc.Pic17 = BtnView017.PostBackUrl;
            myacc.Pic18 = BtnView018.PostBackUrl;
            myacc.Pic19 = BtnView019.PostBackUrl;
            myacc.Pic20 = BtnView020.PostBackUrl;
            myacc.Pic21 = BtnView021.PostBackUrl;
            myacc.Pic22 = BtnView022.PostBackUrl;
            myacc.Pic23 = BtnView023.PostBackUrl;
            myacc.Pic24 = BtnView024.PostBackUrl;
            myacc.Pic25 = BtnView025.PostBackUrl;
            myacc.Pic26 = BtnView026.PostBackUrl;
            myacc.Pic27 = BtnView027.PostBackUrl;
            myacc.Pic28 = BtnView028.PostBackUrl;
            myacc.Pic29 = BtnView029.PostBackUrl;
            myacc.Pic30 = BtnView030.PostBackUrl;
            myacc.Pic31 = BtnView031.PostBackUrl;
            myacc.Pic32 = BtnView032.PostBackUrl;
            myacc.Pic33 = BtnView033.PostBackUrl;
            myacc.Pic34 = BtnView034.PostBackUrl;
            myacc.Pic35 = BtnView035.PostBackUrl;
            myacc.Pic36 = BtnView036.PostBackUrl;
            myacc.Pic37 = BtnView037.PostBackUrl;
            myacc.Pic38 = BtnView038.PostBackUrl;
            myacc.Pic39 = BtnView039.PostBackUrl;
            myacc.Pic40 = BtnView040.PostBackUrl;
            myacc.Pic41 = BtnView041.PostBackUrl;
            myacc.Pic42 = BtnView042.PostBackUrl;
            myacc.Pic43 = BtnView043.PostBackUrl;
            myacc.Pic44 = BtnView044.PostBackUrl;
            myacc.Pic45 = BtnView045.PostBackUrl;
            myacc.Pic46 = BtnView046.PostBackUrl;
            myacc.Pic47 = BtnView047.PostBackUrl;
            myacc.Pic48 = BtnView048.PostBackUrl;
            myacc.Pic49 = BtnView049.PostBackUrl;
            myacc.Pic50 = BtnView050.PostBackUrl;
            myacc.Pic51 = BtnView051.PostBackUrl;
            myacc.Pic52 = BtnView052.PostBackUrl;
            myacc.Pic53 = BtnView053.PostBackUrl;
            myacc.Pic54 = BtnView054.PostBackUrl;
            myacc.Pic55 = BtnView055.PostBackUrl;
            myacc.Pic56 = BtnView056.PostBackUrl;

            myacc.Item00 = ddlItem00.SelectedValue;
            myacc.Item01 = txtItem01.Text;
            myacc.Item02 = txtItem02.Text;
            myacc.Item03 = txtItem03.Text;
            myacc.Item04 = txtItem04.Text;
            myacc.Item05 = txtItem05.Text;
            myacc.Item06 = txtItem06.Text;
            myacc.Item07 = txtItem07.Text;
            myacc.Item08 = txtItem08.Text;
            myacc.Item09 = txtItem09.Text;
            myacc.Item10 = txtItem10.Text;
            myacc.Item11 = txtItem11.Text;
            myacc.Item12 = txtItem12.Text;
            myacc.Item13 = txtItem13.Text;
            myacc.Item14 = txtItem14.Text;
            myacc.Item15 = txtItem15.Text;
            myacc.Item16 = txtItem16.Text;
            myacc.Item17 = txtItem17.Text;
            myacc.Item18 = txtItem18.Text;
            myacc.Item19 = txtItem19.Text;
            myacc.Item20 = txtItem20.Text;
            myacc.Item21 = txtItem21.Text;
            myacc.Item22 = txtItem22.Text;
            myacc.Item23 = txtItem23.Text;
            myacc.Item24 = txtItem24.Text;
            myacc.Item25 = txtItem25.Text;
            myacc.Item26 = txtItem26.Text;
            myacc.Item27 = txtItem27.Text;
            myacc.Item28 = txtItem28.Text;
            myacc.Item29 = txtItem29.Text;
            myacc.Item30 = txtItem30.Text;
            myacc.Item31 = txtItem31.Text;
            myacc.Item32 = txtItem32.Text;
            myacc.Item33 = txtItem33.Text;
            myacc.Item34 = txtItem34.Text;
            myacc.Item35 = txtItem35.Text;
            myacc.Item36 = txtItem36.Text;
            myacc.Item37 = txtItem37.Text;
            myacc.Item38 = txtItem38.Text;
            myacc.Item39 = txtItem39.Text;
            myacc.Item40 = txtItem40.Text;
            myacc.Item41 = txtItem41.Text;
            myacc.Item42 = txtItem42.Text;
            myacc.Item43 = txtItem43.Text;
            myacc.Item44 = txtItem44.Text;
            myacc.Item45 = txtItem45.Text;
            myacc.Item46 = txtItem46.Text;
            myacc.Item47 = txtItem47.Text;
            myacc.Item48 = txtItem48.Text;
            myacc.Item49 = txtItem49.Text;
            myacc.Item50 = txtItem50.Text;
            myacc.Item51 = txtItem51.Text;
            myacc.Item52 = txtItem52.Text;
            myacc.Item53 = txtItem53.Text;
            myacc.Item54 = txtItem54.Text;
            myacc.Item55 = txtItem55.Text;
            myacc.Item56 = txtItem56.Text;

            myacc.I01 = short.Parse(this.HImgS.Value.Substring(0, 1));
            myacc.I02 = short.Parse(this.HImgS.Value.Substring(1, 1));
            myacc.I03 = short.Parse(this.HImgS.Value.Substring(2, 1));
            myacc.I04 = short.Parse(this.HImgS.Value.Substring(3, 1));
            myacc.I05 = short.Parse(this.HImgS.Value.Substring(4, 1));
            myacc.I06 = short.Parse(this.HImgS.Value.Substring(5, 1));
            myacc.I07 = short.Parse(this.HImgS.Value.Substring(6, 1));
            myacc.I08 = short.Parse(this.HImgS.Value.Substring(7, 1));
            myacc.I09 = short.Parse(this.HImgS.Value.Substring(8, 1));
            myacc.I10 = short.Parse(this.HImgS.Value.Substring(9, 1));
            myacc.I11 = short.Parse(this.HImgS.Value.Substring(10, 1));
            myacc.I12 = short.Parse(this.HImgS.Value.Substring(11, 1));
            myacc.I13 = short.Parse(this.HImgS.Value.Substring(12, 1));
            myacc.I14 = short.Parse(this.HImgS.Value.Substring(13, 1));
            myacc.I15 = short.Parse(this.HImgS.Value.Substring(14, 1));
            myacc.I16 = short.Parse(this.HImgS.Value.Substring(15, 1));
            myacc.I17 = short.Parse(this.HImgS.Value.Substring(16, 1));
            myacc.I18 = short.Parse(this.HImgS.Value.Substring(17, 1));
            myacc.I19 = short.Parse(this.HImgS.Value.Substring(18, 1));
            myacc.I20 = short.Parse(this.HImgS.Value.Substring(19, 1));
            myacc.I21 = short.Parse(this.HImgS.Value.Substring(20, 1));
            myacc.I22 = short.Parse(this.HImgS.Value.Substring(21, 1));
            myacc.I23 = short.Parse(this.HImgS.Value.Substring(22, 1));
            myacc.I24 = short.Parse(this.HImgS.Value.Substring(23, 1));
            myacc.I25 = short.Parse(this.HImgS.Value.Substring(24, 1));
            myacc.I26 = short.Parse(this.HImgS.Value.Substring(25, 1));
            myacc.I27 = short.Parse(this.HImgS.Value.Substring(26, 1));
            myacc.I28 = short.Parse(this.HImgS.Value.Substring(27, 1));
            myacc.I29 = short.Parse(this.HImgS.Value.Substring(28, 1));
            myacc.I30 = short.Parse(this.HImgS.Value.Substring(29, 1));
            myacc.I31 = short.Parse(this.HImgS.Value.Substring(30, 1));
            myacc.I32 = short.Parse(this.HImgS.Value.Substring(31, 1));
            myacc.I33 = short.Parse(this.HImgS.Value.Substring(32, 1));
            myacc.I34 = short.Parse(this.HImgS.Value.Substring(33, 1));
            myacc.I35 = short.Parse(this.HImgS.Value.Substring(34, 1));
            myacc.I36 = short.Parse(this.HImgS.Value.Substring(35, 1));
            myacc.I37 = short.Parse(this.HImgS.Value.Substring(36, 1));
            myacc.I38 = short.Parse(this.HImgS.Value.Substring(37, 1));
            myacc.I39 = short.Parse(this.HImgS.Value.Substring(38, 1));
            myacc.I40 = short.Parse(this.HImgS.Value.Substring(39, 1));
            myacc.I41 = short.Parse(this.HImgS.Value.Substring(40, 1));
            myacc.I42 = short.Parse(this.HImgS.Value.Substring(41, 1));
            myacc.I43 = short.Parse(this.HImgS.Value.Substring(42, 1));
            myacc.I44 = short.Parse(this.HImgS.Value.Substring(43, 1));
            myacc.I45 = short.Parse(this.HImgS.Value.Substring(44, 1));
            myacc.I46 = short.Parse(this.HImgS.Value.Substring(45, 1));
            myacc.I47 = short.Parse(this.HImgS.Value.Substring(46, 1));
            myacc.I48 = short.Parse(this.HImgS.Value.Substring(47, 1));
            myacc.I49 = short.Parse(this.HImgS.Value.Substring(48, 1));
            myacc.I50 = short.Parse(this.HImgS.Value.Substring(49, 1));
            myacc.I51 = short.Parse(this.HImgS.Value.Substring(50, 1));
            myacc.I52 = short.Parse(this.HImgS.Value.Substring(51, 1));
            myacc.I53 = short.Parse(this.HImgS.Value.Substring(52, 1));
            myacc.I54 = short.Parse(this.HImgS.Value.Substring(53, 1));
            myacc.I55 = short.Parse(this.HImgS.Value.Substring(54, 1));
            myacc.I56 = short.Parse(this.HImgS.Value.Substring(55, 1));
            myacc.Remarks = txtRemarks.Text;
            myacc.From2 = txtFrom2.Text;
            myacc.To2 = txtTo2.Text;
            myacc.UserName = txtUserName.ToolTip;
            myacc.UserDate = txtUserDate.Text;
        }

        public short? GetValue(String Tick)
        {
            short? vResult = 0;
            if(Tick.Contains("True2")) vResult = 1;
            else if(Tick.Contains("True")) vResult = 0;
            else if (Tick.Contains("False")) vResult = 2;
            else vResult = 3;
            return vResult;
        }

        public string RetValue(short? Tick)
        {
            string vResult = "~/images/True.gif";
            if (Tick == 0) vResult = "~/images/True.gif";
            else if(Tick == 1) vResult = "~/images/True2.gif";
            else if(Tick == 2) vResult = "~/images/False.gif";
            else vResult = "~/images/Miss.gif";
            return vResult;
        }


        public void GetItem(ChList myacc)
        {
            //rdoType.SelectedIndex = (int)myacc.VouType;
            txtInTime.Text = myacc.InTime;
            ddlVehType.SelectedValue = myacc.VehType.ToString();
            ddlVehType_SelectedIndexChanged(ddlVehType, null);
            // Check Type
            ddlVehicle.SelectedValue = myacc.Vechicle;
            txtCarNo.Text = myacc.Vechicle;
            ddlFrom.SelectedValue = myacc.FromPerson;
            ddlFrom_SelectedIndexChanged(ddlFrom, null);
            ddlTo.SelectedValue = myacc.ToPerson;
            ddlTo_SelectedIndexChanged(ddlTo, null);
            if(myacc.PVouNo == "") ddlPCheck.SelectedIndex = -1;
            else ddlPCheck.SelectedValue = myacc.PVouNo;    
            Cars myInv = new Cars();
            myInv.Branch = short.Parse(Session["Branch"].ToString());
            if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myInv.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            myInv.Code = ddlVehicle.SelectedValue;
            myInv.CarsType = int.Parse(ddlVehType.SelectedValue);
            myInv = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                     where sitm.Code == myInv.Code
                     select sitm).FirstOrDefault();
            if (myInv != null)
            {
                txtModel.Text = myInv.Model;
            }                        

            txtVouDate.Text = myacc.VouDate;
            txtACSNo.Text = myacc.ACSNo;
            txtACType.Text = myacc.ACType;
            txtEngineSNo.Text = myacc.EngineSNo;
            txtEngineType.Text = myacc.EngineType;
            txtGearSNo.Text = myacc.GearSNo;
            txtGearType.Text = myacc.GearType;
            txtIPSNo.Text = myacc.IPSNo;
            txtIPType.Text = myacc.IPType;
            if(myacc.PVouNo != "")
            {
                LoadPCheckList("-1");
                ddlPCheck.SelectedValue = myacc.PVouNo;
                ddlPCheck_SelectedIndexChanged(null, null);                
            }
            else ddlPCheck.SelectedIndex = -1;

            BtnView001.PostBackUrl = myacc.Pic01;
            BtnView001.Visible = (myacc.Pic01 != "");
            BtnView002.PostBackUrl = myacc.Pic02;
            BtnView002.Visible = (myacc.Pic02 != "");
            BtnView003.PostBackUrl = myacc.Pic03;
            BtnView003.Visible = (myacc.Pic03 != "");
            BtnView004.PostBackUrl = myacc.Pic04;
            BtnView004.Visible = (myacc.Pic04 != "");
            BtnView005.PostBackUrl = myacc.Pic05;
            BtnView005.Visible = (myacc.Pic05 != "");
            BtnView006.PostBackUrl = myacc.Pic06;
            BtnView006.Visible = (myacc.Pic06 != "");
            BtnView007.PostBackUrl = myacc.Pic07;
            BtnView007.Visible = (myacc.Pic07 != "");
            BtnView008.PostBackUrl = myacc.Pic08;
            BtnView008.Visible = (myacc.Pic08 != "");
            BtnView009.PostBackUrl = myacc.Pic09;
            BtnView009.Visible = (myacc.Pic09 != "");
            BtnView010.PostBackUrl = myacc.Pic10;
            BtnView010.Visible = (myacc.Pic10 != "");
            BtnView011.PostBackUrl = myacc.Pic11;
            BtnView011.Visible = (myacc.Pic11 != "");
            BtnView012.PostBackUrl = myacc.Pic12;
            BtnView012.Visible = (myacc.Pic12 != "");
            BtnView013.PostBackUrl = myacc.Pic13;
            BtnView013.Visible = (myacc.Pic13 != "");
            BtnView014.PostBackUrl = myacc.Pic14;
            BtnView014.Visible = (myacc.Pic14 != "");
            BtnView015.PostBackUrl = myacc.Pic15;
            BtnView015.Visible = (myacc.Pic15 != "");
            BtnView016.PostBackUrl = myacc.Pic16;
            BtnView016.Visible = (myacc.Pic16 != "");
            BtnView017.PostBackUrl = myacc.Pic17;
            BtnView017.Visible = (myacc.Pic17 != "");
            BtnView018.PostBackUrl = myacc.Pic18;
            BtnView018.Visible = (myacc.Pic18 != "");
            BtnView019.PostBackUrl = myacc.Pic19;
            BtnView019.Visible = (myacc.Pic19 != "");
            BtnView020.PostBackUrl = myacc.Pic20;
            BtnView020.Visible = (myacc.Pic20 != "");
            BtnView021.PostBackUrl = myacc.Pic21;
            BtnView021.Visible = (myacc.Pic21 != "");
            BtnView022.PostBackUrl = myacc.Pic22;
            BtnView022.Visible = (myacc.Pic22 != "");
            BtnView023.PostBackUrl = myacc.Pic23;
            BtnView023.Visible = (myacc.Pic23 != "");
            BtnView024.PostBackUrl = myacc.Pic24;
            BtnView024.Visible = (myacc.Pic24 != "");
            BtnView025.PostBackUrl = myacc.Pic25;
            BtnView025.Visible = (myacc.Pic25 != "");
            BtnView026.PostBackUrl = myacc.Pic26;
            BtnView026.Visible = (myacc.Pic26 != "");
            BtnView027.PostBackUrl = myacc.Pic27;
            BtnView027.Visible = (myacc.Pic27 != "");
            BtnView028.PostBackUrl = myacc.Pic28;
            BtnView028.Visible = (myacc.Pic28 != "");
            BtnView029.PostBackUrl = myacc.Pic29;
            BtnView029.Visible = (myacc.Pic29 != "");
            BtnView030.PostBackUrl = myacc.Pic30;
            BtnView030.Visible = (myacc.Pic30 != "");
            BtnView031.PostBackUrl = myacc.Pic31;
            BtnView031.Visible = (myacc.Pic31 != "");
            BtnView032.PostBackUrl = myacc.Pic32;
            BtnView032.Visible = (myacc.Pic32 != "");
            BtnView033.PostBackUrl = myacc.Pic33;
            BtnView033.Visible = (myacc.Pic33 != "");
            BtnView034.PostBackUrl = myacc.Pic34;
            BtnView034.Visible = (myacc.Pic34 != "");
            BtnView035.PostBackUrl = myacc.Pic35;
            BtnView035.Visible = (myacc.Pic35 != "");
            BtnView036.PostBackUrl = myacc.Pic36;
            BtnView036.Visible = (myacc.Pic36 != "");
            BtnView037.PostBackUrl = myacc.Pic37;
            BtnView037.Visible = (myacc.Pic37 != "");
            BtnView038.PostBackUrl = myacc.Pic38;
            BtnView038.Visible = (myacc.Pic38 != "");
            BtnView039.PostBackUrl = myacc.Pic39;
            BtnView039.Visible = (myacc.Pic39 != "");
            BtnView040.PostBackUrl = myacc.Pic40;
            BtnView040.Visible = (myacc.Pic40 != "");
            BtnView041.PostBackUrl = myacc.Pic41;
            BtnView041.Visible = (myacc.Pic41 != "");
            BtnView042.PostBackUrl = myacc.Pic42;
            BtnView042.Visible = (myacc.Pic42 != "");
            BtnView043.PostBackUrl = myacc.Pic43;
            BtnView043.Visible = (myacc.Pic43 != "");
            BtnView044.PostBackUrl = myacc.Pic44;
            BtnView044.Visible = (myacc.Pic44 != "");
            BtnView045.PostBackUrl = myacc.Pic45;
            BtnView045.Visible = (myacc.Pic45 != "");
            BtnView046.PostBackUrl = myacc.Pic46;
            BtnView046.Visible = (myacc.Pic46 != "");
            BtnView047.PostBackUrl = myacc.Pic47;
            BtnView047.Visible = (myacc.Pic47 != "");
            BtnView048.PostBackUrl = myacc.Pic48;
            BtnView048.Visible = (myacc.Pic48 != "");
            BtnView049.PostBackUrl = myacc.Pic49;
            BtnView049.Visible = (myacc.Pic49 != "");
            BtnView050.PostBackUrl = myacc.Pic50;
            BtnView050.Visible = (myacc.Pic50 != "");
            BtnView051.PostBackUrl = myacc.Pic51;
            BtnView051.Visible = (myacc.Pic51 != "");
            BtnView052.PostBackUrl = myacc.Pic52;
            BtnView052.Visible = (myacc.Pic52 != "");
            BtnView053.PostBackUrl = myacc.Pic53;
            BtnView053.Visible = (myacc.Pic53 != "");
            BtnView054.PostBackUrl = myacc.Pic54;
            BtnView054.Visible = (myacc.Pic54 != "");
            BtnView055.PostBackUrl = myacc.Pic55;
            BtnView055.Visible = (myacc.Pic55 != "");
            BtnView056.PostBackUrl = myacc.Pic56;
            BtnView056.Visible = (myacc.Pic56 != "");

            ddlItem00.SelectedValue = myacc.Item00;
            txtItem01.Text = myacc.Item01;
            txtItem02.Text = myacc.Item02;
            txtItem03.Text = myacc.Item03;
            txtItem04.Text = myacc.Item04;
            txtItem05.Text = myacc.Item05;
            txtItem06.Text = myacc.Item06;
            txtItem07.Text = myacc.Item07;
            txtItem08.Text = myacc.Item08;
            txtItem09.Text = myacc.Item09;
            txtItem10.Text = myacc.Item10;
            txtItem11.Text = myacc.Item11;
            txtItem12.Text = myacc.Item12;
            txtItem13.Text = myacc.Item13;
            txtItem14.Text = myacc.Item14;
            txtItem15.Text = myacc.Item15;
            txtItem16.Text = myacc.Item16;
            txtItem17.Text = myacc.Item17;
            txtItem18.Text = myacc.Item18;
            txtItem19.Text = myacc.Item19;
            txtItem20.Text = myacc.Item20;
            txtItem21.Text = myacc.Item21;
            txtItem22.Text = myacc.Item22;
            txtItem23.Text = myacc.Item23;
            txtItem24.Text = myacc.Item24;
            txtItem25.Text = myacc.Item25;
            txtItem26.Text = myacc.Item26;
            txtItem27.Text = myacc.Item27;
            txtItem28.Text = myacc.Item28;
            txtItem29.Text = myacc.Item29;
            txtItem30.Text = myacc.Item30;
            txtItem31.Text = myacc.Item31;
            txtItem32.Text = myacc.Item32;
            txtItem33.Text = myacc.Item33;
            txtItem34.Text = myacc.Item34;
            txtItem35.Text = myacc.Item35;
            txtItem36.Text = myacc.Item36;
            txtItem37.Text = myacc.Item37;
            txtItem38.Text = myacc.Item38;
            txtItem39.Text = myacc.Item39;
            txtItem40.Text = myacc.Item40;
            txtItem41.Text = myacc.Item41;
            txtItem42.Text = myacc.Item42;
            txtItem43.Text = myacc.Item43;
            txtItem44.Text = myacc.Item44;
            txtItem45.Text = myacc.Item45;
            txtItem46.Text = myacc.Item46;
            txtItem47.Text = myacc.Item47;
            txtItem48.Text = myacc.Item48;
            txtItem49.Text = myacc.Item49;
            txtItem50.Text = myacc.Item50;
            txtItem51.Text = myacc.Item51;
            txtItem52.Text = myacc.Item52;
            txtItem53.Text = myacc.Item53;
            txtItem54.Text = myacc.Item54;
            txtItem55.Text = myacc.Item55;
            txtItem56.Text = myacc.Item56;

            this.HImgS.Value = myacc.I01.ToString().Trim() + myacc.I02.ToString().Trim() + myacc.I03.ToString().Trim() + myacc.I04.ToString().Trim() + myacc.I05.ToString().Trim() + myacc.I06.ToString().Trim() + myacc.I07.ToString().Trim() + myacc.I08.ToString().Trim() + myacc.I09.ToString().Trim() + myacc.I10.ToString().Trim()
                            + myacc.I11.ToString().Trim() + myacc.I12.ToString().Trim() + myacc.I13.ToString().Trim() + myacc.I14.ToString().Trim() + myacc.I15.ToString().Trim() + myacc.I16.ToString().Trim() + myacc.I17.ToString().Trim() + myacc.I18.ToString().Trim() + myacc.I19.ToString().Trim() + myacc.I20.ToString().Trim()
                            + myacc.I21.ToString().Trim() + myacc.I22.ToString().Trim() + myacc.I23.ToString().Trim() + myacc.I24.ToString().Trim() + myacc.I25.ToString().Trim() + myacc.I26.ToString().Trim() + myacc.I27.ToString().Trim() + myacc.I28.ToString().Trim() + myacc.I29.ToString().Trim() + myacc.I30.ToString().Trim()
                            + myacc.I31.ToString().Trim() + myacc.I32.ToString().Trim() + myacc.I33.ToString().Trim() + myacc.I34.ToString().Trim() + myacc.I35.ToString().Trim() + myacc.I36.ToString().Trim() + myacc.I37.ToString().Trim() + myacc.I38.ToString().Trim() + myacc.I39.ToString().Trim() + myacc.I40.ToString().Trim()
                            + myacc.I41.ToString().Trim() + myacc.I42.ToString().Trim() + myacc.I43.ToString().Trim() + myacc.I44.ToString().Trim() + myacc.I45.ToString().Trim() + myacc.I46.ToString().Trim() + myacc.I47.ToString().Trim() + myacc.I48.ToString().Trim() + myacc.I49.ToString().Trim() + myacc.I50.ToString().Trim()
                            + myacc.I51.ToString().Trim() + myacc.I52.ToString().Trim() + myacc.I53.ToString().Trim() + myacc.I54.ToString().Trim() + myacc.I55.ToString().Trim() + myacc.I56.ToString().Trim();
            SetImages();

            txtRemarks.Text = myacc.Remarks;
            txtFrom2.Text = myacc.From2;
            txtTo2.Text = myacc.To2;

            myacc.UserName = txtUserName.ToolTip;
            myacc.UserDate = txtUserDate.Text;
            TblUsers ax = new TblUsers();
            if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            ax.UserName = myacc.UserName;

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

        }

        public void SetImages()
        {
            Img01.Src = RetValue(short.Parse(this.HImgS.Value.Substring(0, 1)));
            Img02.Src = RetValue(short.Parse(this.HImgS.Value.Substring(1, 1)));
            Img03.Src = RetValue(short.Parse(this.HImgS.Value.Substring(2, 1)));
            Img04.Src = RetValue(short.Parse(this.HImgS.Value.Substring(3, 1)));
            Img05.Src = RetValue(short.Parse(this.HImgS.Value.Substring(4, 1)));
            Img06.Src = RetValue(short.Parse(this.HImgS.Value.Substring(5, 1)));
            Img07.Src = RetValue(short.Parse(this.HImgS.Value.Substring(6, 1)));
            Img08.Src = RetValue(short.Parse(this.HImgS.Value.Substring(7, 1)));
            Img09.Src = RetValue(short.Parse(this.HImgS.Value.Substring(8, 1)));
            Img10.Src = RetValue(short.Parse(this.HImgS.Value.Substring(9, 1)));
            Img11.Src = RetValue(short.Parse(this.HImgS.Value.Substring(10, 1)));
            Img12.Src = RetValue(short.Parse(this.HImgS.Value.Substring(11, 1)));
            Img13.Src = RetValue(short.Parse(this.HImgS.Value.Substring(12, 1)));
            Img14.Src = RetValue(short.Parse(this.HImgS.Value.Substring(13, 1)));
            Img15.Src = RetValue(short.Parse(this.HImgS.Value.Substring(14, 1)));
            Img16.Src = RetValue(short.Parse(this.HImgS.Value.Substring(15, 1)));
            Img17.Src = RetValue(short.Parse(this.HImgS.Value.Substring(16, 1)));
            Img18.Src = RetValue(short.Parse(this.HImgS.Value.Substring(17, 1)));
            Img19.Src = RetValue(short.Parse(this.HImgS.Value.Substring(18, 1)));
            Img20.Src = RetValue(short.Parse(this.HImgS.Value.Substring(19, 1)));
            Img21.Src = RetValue(short.Parse(this.HImgS.Value.Substring(20, 1)));
            Img22.Src = RetValue(short.Parse(this.HImgS.Value.Substring(21, 1)));
            Img23.Src = RetValue(short.Parse(this.HImgS.Value.Substring(22, 1)));
            Img24.Src = RetValue(short.Parse(this.HImgS.Value.Substring(23, 1)));
            Img25.Src = RetValue(short.Parse(this.HImgS.Value.Substring(24, 1)));
            Img26.Src = RetValue(short.Parse(this.HImgS.Value.Substring(25, 1)));
            Img27.Src = RetValue(short.Parse(this.HImgS.Value.Substring(26, 1)));
            Img28.Src = RetValue(short.Parse(this.HImgS.Value.Substring(27, 1)));
            Img29.Src = RetValue(short.Parse(this.HImgS.Value.Substring(28, 1)));
            Img30.Src = RetValue(short.Parse(this.HImgS.Value.Substring(29, 1)));
            Img31.Src = RetValue(short.Parse(this.HImgS.Value.Substring(30, 1)));
            Img32.Src = RetValue(short.Parse(this.HImgS.Value.Substring(31, 1)));
            Img33.Src = RetValue(short.Parse(this.HImgS.Value.Substring(32, 1)));
            Img34.Src = RetValue(short.Parse(this.HImgS.Value.Substring(33, 1)));
            Img35.Src = RetValue(short.Parse(this.HImgS.Value.Substring(34, 1)));
            Img36.Src = RetValue(short.Parse(this.HImgS.Value.Substring(35, 1)));
            Img37.Src = RetValue(short.Parse(this.HImgS.Value.Substring(36, 1)));
            Img38.Src = RetValue(short.Parse(this.HImgS.Value.Substring(37, 1)));
            Img39.Src = RetValue(short.Parse(this.HImgS.Value.Substring(38, 1)));
            Img40.Src = RetValue(short.Parse(this.HImgS.Value.Substring(39, 1)));
            Img41.Src = RetValue(short.Parse(this.HImgS.Value.Substring(40, 1)));
            Img42.Src = RetValue(short.Parse(this.HImgS.Value.Substring(41, 1)));
            Img43.Src = RetValue(short.Parse(this.HImgS.Value.Substring(42, 1)));
            Img44.Src = RetValue(short.Parse(this.HImgS.Value.Substring(43, 1)));
            Img45.Src = RetValue(short.Parse(this.HImgS.Value.Substring(44, 1)));
            Img46.Src = RetValue(short.Parse(this.HImgS.Value.Substring(45, 1)));
            Img47.Src = RetValue(short.Parse(this.HImgS.Value.Substring(46, 1)));
            Img48.Src = RetValue(short.Parse(this.HImgS.Value.Substring(47, 1)));
            Img49.Src = RetValue(short.Parse(this.HImgS.Value.Substring(48, 1)));
            Img50.Src = RetValue(short.Parse(this.HImgS.Value.Substring(49, 1)));
            Img51.Src = RetValue(short.Parse(this.HImgS.Value.Substring(50, 1)));
            Img52.Src = RetValue(short.Parse(this.HImgS.Value.Substring(51, 1)));
            Img53.Src = RetValue(short.Parse(this.HImgS.Value.Substring(52, 1)));
            Img54.Src = RetValue(short.Parse(this.HImgS.Value.Substring(53, 1)));
            Img55.Src = RetValue(short.Parse(this.HImgS.Value.Substring(54, 1)));
            Img56.Src = RetValue(short.Parse(this.HImgS.Value.Substring(55, 1)));    
        }


        protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtVouNo.Text.Trim() != "")
                {
                    txtVouNo.Text = txtVouNo.Text.Trim();
                    ChList myacc = new ChList();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.VouLoc = short.Parse(StoreNo);
                    myacc.VouType = short.Parse(VouType);
                    myacc.VouNo = int.Parse(txtVouNo.Text);
                    myacc = myacc.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc != null)
                    {
                        BtnClear_Click(sender, e);
                        txtVouNo.Text = myacc.VouNo.ToString();
                        EditMode();
                        GetItem(myacc);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("NotFound").ToString();  // "Check List No. Not Found";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = GetLocalResourceObject("EnterCheckList").ToString();  // "You Should Enter Check List No.";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
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
                    txtVouNo.Text = txtVouNo.Text.Trim();
                    ChList myacc = new ChList();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.VouLoc = short.Parse(StoreNo);
                    myacc.VouType = short.Parse(VouType);
                    myacc.VouNo = int.Parse(txtVouNo.Text);
                    myacc = myacc.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc != null)
                    {
                        PutItem(myacc);
                        if (myacc.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = GetLocalResourceObject("SaveData").ToString();  // "Saving Data Successfully Done";

                            Cars myInv = new Cars();
                            myInv.Branch = short.Parse(Session["Branch"].ToString());
                            if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myInv.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                            myInv.Code = ddlVehicle.SelectedValue;
                            myInv.CarsType = int.Parse(ddlVehType.SelectedValue);
                            myInv = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                     where sitm.Code == myInv.Code
                                     select sitm).FirstOrDefault();
                            if (myInv != null)
                            {
                                if (myacc.ToPerson == "0" || myacc.ToPerson == "-1")
                                {
                                    myInv.DriverCode = "-1";
                                    myInv.PLoc = (myacc.ToPerson == "-1" ? "في الورشة" : txtTo2.Text);
                                }
                                else
                                {
                                    myInv.PLoc = "التشغيل";
                                    myInv.DriverCode = myacc.ToPerson;
                                }

                                myInv.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }                        

                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            string vNumber = txtVouNo.Text;
                            BtnClear_Click(sender, e);
                            BtnNew.Enabled = true;
                            PrintMe(vNumber);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("SaveError").ToString();  // "Error During Saving Data ... Try Again";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("NotFound").ToString();  // "Check List No. Not Found";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }


        public void PrintMe(String Number)
        {
            //if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
            //{
            //    Transactions UserTran = new Transactions();
            //    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
            //    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
            //    UserTran.UserName = Session["CurrentUser"].ToString();
            //    UserTran.FormName = "اتفاقية شحن";
            //    UserTran.FormAction = "طباعة";
            //    UserTran.Description = "طباعة بيانات اتفاقية الشحن رقم " + Number;
            //    UserTran.IP = IPNetworking.GetIP4Address();
            //    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
            //}

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=800&VouType=" + VouType + "&AreaNo=" + StoreNo + "&Number=" + Number + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
            return;
        }

        protected void BtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtVouNo.Text.Trim() != "")
                {
                    txtVouNo.Text = txtVouNo.Text.Trim();
                    ChList myacc = new ChList();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.VouLoc = short.Parse(StoreNo);
                    myacc.VouType = short.Parse(VouType);
                    myacc.VouNo = int.Parse(txtVouNo.Text);
                    myacc = myacc.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc != null)
                    {
                        // Check for Delete Clients
                        if (myacc.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());  //moh.Nows().ToShortTimeString();
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.Description = GetLocalResourceObject("DeleteCheckList").ToString() + myacc.VouNo;  // "Delete Check List No. " 
                            UserTran.FormAction = GetLocalResourceObject("Delete").ToString();  //"Delete";
                            UserTran.FormName = GetLocalResourceObject("Header2").ToString();  //  "Movement Check List";
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = GetLocalResourceObject("DeleteSuccess").ToString();  // "Deleting Check List Successfully Done";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("ErrorDelete").ToString();  // "Error During Deleting Check List ... Try Again";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = GetLocalResourceObject("EnterCheckList").ToString();  // "You Should Enter Check List No.";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void BtnFind_Click(object sender, ImageClickEventArgs e)
        {
            BtnSearch_Click(sender, e);
        }


        protected void BtnAttach_Click(object sender, ImageClickEventArgs e)
        {
            if (FileUpload1.HasFile)
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
                        FileUpload1.SaveAs(mySetting.ImagePath + FileName);

                        Arch myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(StoreNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 980;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(StoreNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 980;
                        myArch.FileName = FileUpload1.FileName;
                        myArch.FileName2 = mySetting.ImagePath2 + FileName;
                        myArch.FNo = (short)i;
                        myArch.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        LoadAttachData();
                    }

                    //    LblCodesResult.Text = "File name: " + FileUpload1.PostedFile.FileName + "<br>" + FileUpload1.PostedFile.ContentLength + " kb<br>" + "Content type: " + FileUpload1.PostedFile.ContentType;
                }
                catch (Exception ex)
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "ERROR: " + ex.Message.ToString();
                }
            else
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = GetLocalResourceObject("NoFile").ToString();  // "لم بتم اختيار الملف";
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
                myArch.LocNumber = short.Parse(StoreNo);
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = 980;
                myArch.FNo = short.Parse(FNo);
                myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                LoadAttachData();
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        public void LoadAttachData()
        {
            Arch myArch = new Arch();
            myArch.Branch = short.Parse(Session["Branch"].ToString());
            myArch.LocNumber = short.Parse(StoreNo);
            myArch.Number = int.Parse(txtVouNo.Text);
            myArch.DocType = 980;
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

        protected void ddlVehType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlVehType.SelectedIndex > 0)
            {
                Cars myCar = new Cars();
                myCar.Branch = short.Parse(Session["Branch"].ToString());
                myCar.CarsType = int.Parse(ddlVehType.SelectedValue);
                if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                ddlVehicle.DataTextField = "Name";
                ddlVehicle.DataValueField = "Code";
                ddlVehicle.DataSource = (from itm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                         where itm.CarsType == int.Parse(ddlVehType.SelectedValue)
                                         select itm).ToList();
                ddlVehicle.DataBind();
                ddlVehicle.Items.Insert(0, new ListItem(GetLocalResourceObject("SVehical").ToString(), "-1", true));
            }
            else
            {
                ddlVehicle.Items.Clear();
                ddlVehicle.Items.Insert(0, new ListItem(GetLocalResourceObject("SVehical").ToString(), "-1", true));
            }

       }

        protected void BtnLoad1_Click(object sender, EventArgs e)
        {
            try
            {
                string Tag = ((Button)sender).ID.Substring(7, ((Button)sender).ID.Length - 7);
                string ImageUrl = "";
                MyConfig mysetting = new MyConfig();
                mysetting.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mysetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                mysetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                if (mysetting != null) ImageUrl = mysetting.ImagePath2;

                ContentPlaceHolder con = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
                FileUpload fp = con.FindControl("Fld" + Tag) as FileUpload;

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
                            LinkButton BtnView = con.FindControl("BtnView0" + Tag) as LinkButton;
                            if (BtnView != null)
                            {
                                BtnView.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                                BtnView.PostBackUrl = url;
                                BtnView.Visible = true;
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
                        LblCodesResult.Text = GetLocalResourceObject("NoFile").ToString();  // "لم بتم اختيار الملف";
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

     
        protected void rdoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlFrom.Enabled = true;
            ddlTo.Enabled = true;
            if (rdoType.SelectedIndex == 0)
            {
                ddlFrom.SelectedIndex = 0;
                ddlFrom_SelectedIndexChanged(sender, e);
                ddlFrom.Enabled = false;
            }
            else if (rdoType.SelectedIndex == 1)
            {
                ddlFrom.Enabled = true;
                ddlTo.Enabled = true;
            }
            else
            {
                ddlTo.SelectedIndex = 0;
                ddlTo_SelectedIndexChanged(sender, e);
                ddlTo.Enabled = false;
            }
            if (ddlVehicle.SelectedIndex > 0) ddlVehicle_SelectedIndexChanged(sender, e);
        }

        protected void BtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    string vNumber = txtVouNo.Text;
                    PrintMe(vNumber);
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
            finally
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
            }

        }

        protected void ddlVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cars myCar = new Cars();
            myCar.Branch = short.Parse(Session["Branch"].ToString());
            if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            myCar.Code = ddlVehicle.SelectedValue;
            myCar = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                     where sitm.Code == myCar.Code
                     select sitm).FirstOrDefault();
            if (myCar != null && myCar.DriverCode != "" && myCar.DriverCode != "")
            {
                if (rdoType.SelectedIndex == 0)
                {
                    ddlTo.SelectedValue = myCar.DriverCode;

                }
                else if (rdoType.SelectedIndex == 1)
                {
                    ddlFrom.SelectedValue = myCar.DriverCode;
                }
                else
                {
                    ddlFrom.SelectedValue = myCar.DriverCode;
                }

                ChList myacc = new ChList();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                myacc.Vechicle = ddlVehicle.SelectedValue;
                myacc = myacc.FindByCar(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).LastOrDefault();
                if(myacc != null)
                {
                    txtACSNo.Text = myacc.ACSNo;
                    txtACType.Text = myacc.ACType;
                    txtEngineSNo.Text = myacc.EngineSNo;
                    txtEngineType.Text = myacc.EngineType;
                    txtGearSNo.Text = myacc.GearSNo;
                    txtGearType.Text = myacc.GearType;
                    txtIPSNo.Text = myacc.IPSNo;
                    txtIPType.Text = myacc.IPType;
                    LoadPCheckList("0");
                    ddlPCheck_SelectedIndexChanged(sender, e);
                    LoadListData();
                }
            }
        }

        public void LoadPCheckList(string Step)
        {
            ddlPCheck.Items.Clear();
            ChList myacc = new ChList();
            myacc.Branch = short.Parse(Session["Branch"].ToString());
            myacc.Vechicle = ddlVehicle.SelectedValue;
            int i = -1;
            foreach(ChList itm in myacc.FindByCar(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            {
                ChList myacc2 = new ChList();
                myacc2.Branch = short.Parse(Session["Branch"].ToString());
                myacc2.VouLoc = short.Parse(StoreNo);
                myacc2.VouType = short.Parse(VouType);
                myacc2.VouNo = int.Parse(txtVouNo.Text);
                myacc2.PVouNo = (itm.VouType).ToString() + "/" + itm.VouNo.ToString();
                if (myacc2.FindPList(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault() == null)
                {
                    if (VouType == "1" && itm.VouType == 3)
                    {
                        ddlPCheck.Items.Add((itm.VouType).ToString() + "/" + itm.VouNo.ToString());
                        i++;
                    }
                    else if (VouType == "2" && itm.VouType < 3)
                    {
                        ddlPCheck.Items.Add((itm.VouType).ToString() + "/" + itm.VouNo.ToString());
                        i++;
                    }
                    else if (VouType == "3" && itm.VouType < 3)
                    {
                        ddlPCheck.Items.Add((itm.VouType).ToString() + "/" + itm.VouNo.ToString());
                        i++;
                    }
                }
            }
            ddlPCheck.Items.Add(new ListItem("-----", "-1"));
            ddlPCheck.SelectedIndex = (Step == "-1" ? -1 : i);
            ddlPCheck_SelectedIndexChanged(null, null);
        }

        protected void ddlFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFrom2.Visible = (ddlFrom.SelectedValue == "0");
        }

        protected void ddlTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTo2.Visible = (ddlTo.SelectedValue == "0");
        }

        protected void LoadListData()
        {
            try
            {
                ChList myacc = new ChList();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                myacc.Vechicle = ddlVehicle.SelectedValue;
                grdCodes.DataSource = myacc.FindByCar(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
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

        protected void grdCodes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                string Code = grdCodes.DataKeys[e.NewSelectedIndex]["VouNo"].ToString();
                string myVouType = grdCodes.DataKeys[e.NewSelectedIndex]["VouType"].ToString();
                if (myVouType != VouType)
                {
                    VouType = myVouType;
                    rdoType.SelectedValue = VouType;
                    rdoType_SelectedIndexChanged(sender, e);
                }
                txtVouNo.Text = Code;
                BtnSearch_Click(sender, null);
                e.NewSelectedIndex = -1;
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
                e.NewSelectedIndex = -1;
            }
        }

        protected void grdCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdCodes.PageIndex = e.NewPageIndex;
                LoadListData();
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

        protected void txtCarNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cars myCar = new Cars();
                myCar.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myCar.Code = moh.MakeMask(txtCarNo.Text, 5);
                myCar = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                         where sitm.Code == myCar.Code
                         select sitm).FirstOrDefault();
                if (myCar != null)
                {
                    ddlVehType.SelectedValue = int.Parse(myCar.Code.Substring(0, 2)).ToString();
                    ddlVehType_SelectedIndexChanged(sender, e);
                    ddlVehicle.SelectedValue = myCar.Code;
                    ddlVehicle_SelectedIndexChanged(sender, e);
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

        public void ClearSItems()
        {
            BtnSame.Visible = false;
            txtSItem00.Text = "";
            txtSItem00.ToolTip = "-1";
            txtSItem01.Text = "";
            txtSItem02.Text = "";
            txtSItem03.Text = "";
            txtSItem04.Text = "";
            txtSItem05.Text = "";
            txtSItem06.Text = "";
            txtSItem07.Text = "";
            txtSItem08.Text = "";
            txtSItem09.Text = "";
            txtSItem10.Text = "";
            txtSItem11.Text = "";
            txtSItem12.Text = "";
            txtSItem13.Text = "";
            txtSItem14.Text = "";
            txtSItem15.Text = "";
            txtSItem16.Text = "";
            txtSItem17.Text = "";
            txtSItem18.Text = "";
            txtSItem19.Text = "";
            txtSItem20.Text = "";
            txtSItem21.Text = "";
            txtSItem22.Text = "";
            txtSItem23.Text = "";
            txtSItem24.Text = "";
            txtSItem25.Text = "";
            txtSItem26.Text = "";
            txtSItem27.Text = "";
            txtSItem28.Text = "";
            txtSItem29.Text = "";
            txtSItem30.Text = "";
            txtSItem31.Text = "";
            txtSItem32.Text = "";
            txtSItem33.Text = "";
            txtSItem34.Text = "";
            txtSItem35.Text = "";
            txtSItem36.Text = "";
            txtSItem37.Text = "";
            txtSItem38.Text = "";
            txtSItem39.Text = "";
            txtSItem40.Text = "";
            txtSItem41.Text = "";
            txtSItem42.Text = "";
            txtSItem43.Text = "";
            txtSItem44.Text = "";
            txtSItem45.Text = "";
            txtSItem46.Text = "";
            txtSItem47.Text = "";
            txtSItem48.Text = "";
            txtSItem49.Text = "";
            txtSItem50.Text = "";
            txtSItem51.Text = "";
            txtSItem52.Text = "";
            txtSItem53.Text = "";
            txtSItem54.Text = "";
            txtSItem55.Text = "";
            txtSItem56.Text = "";

            BtnViewS01.Visible = false;
            BtnViewS02.Visible = false;
            BtnViewS03.Visible = false;
            BtnViewS04.Visible = false;
            BtnViewS05.Visible = false;
            BtnViewS06.Visible = false;
            BtnViewS07.Visible = false;
            BtnViewS08.Visible = false;
            BtnViewS09.Visible = false;
            BtnViewS10.Visible = false;
            BtnViewS11.Visible = false;
            BtnViewS12.Visible = false;
            BtnViewS13.Visible = false;
            BtnViewS14.Visible = false;
            BtnViewS15.Visible = false;
            BtnViewS16.Visible = false;
            BtnViewS17.Visible = false;
            BtnViewS18.Visible = false;
            BtnViewS19.Visible = false;
            BtnViewS20.Visible = false;
            BtnViewS21.Visible = false;
            BtnViewS22.Visible = false;
            BtnViewS23.Visible = false;
            BtnViewS24.Visible = false;
            BtnViewS25.Visible = false;
            BtnViewS26.Visible = false;
            BtnViewS27.Visible = false;
            BtnViewS28.Visible = false;
            BtnViewS29.Visible = false;
            BtnViewS30.Visible = false;
            BtnViewS31.Visible = false;
            BtnViewS32.Visible = false;
            BtnViewS33.Visible = false;
            BtnViewS34.Visible = false;
            BtnViewS35.Visible = false;
            BtnViewS36.Visible = false;
            BtnViewS37.Visible = false;
            BtnViewS38.Visible = false;
            BtnViewS39.Visible = false;
            BtnViewS40.Visible = false;
            BtnViewS41.Visible = false;
            BtnViewS42.Visible = false;
            BtnViewS43.Visible = false;
            BtnViewS44.Visible = false;
            BtnViewS45.Visible = false;
            BtnViewS46.Visible = false;
            BtnViewS47.Visible = false;
            BtnViewS48.Visible = false;
            BtnViewS49.Visible = false;
            BtnViewS50.Visible = false;
            BtnViewS51.Visible = false;
            BtnViewS52.Visible = false;
            BtnViewS53.Visible = false;
            BtnViewS54.Visible = false;
            BtnViewS55.Visible = false;
            BtnViewS56.Visible = false;

            ImgS01.Src = "~/images/True.gif";
            ImgS02.Src = "~/images/True.gif";
            ImgS03.Src = "~/images/True.gif";
            ImgS04.Src = "~/images/True.gif";
            ImgS05.Src = "~/images/True.gif";
            ImgS06.Src = "~/images/True.gif";
            ImgS07.Src = "~/images/True.gif";
            ImgS08.Src = "~/images/True.gif";
            ImgS09.Src = "~/images/True.gif";
            ImgS10.Src = "~/images/True.gif";
            ImgS11.Src = "~/images/True.gif";
            ImgS12.Src = "~/images/True.gif";
            ImgS13.Src = "~/images/True.gif";
            ImgS14.Src = "~/images/True.gif";
            ImgS15.Src = "~/images/True.gif";
            ImgS16.Src = "~/images/True.gif";
            ImgS17.Src = "~/images/True.gif";
            ImgS18.Src = "~/images/True.gif";
            ImgS19.Src = "~/images/True.gif";
            ImgS20.Src = "~/images/True.gif";
            ImgS21.Src = "~/images/True.gif";
            ImgS22.Src = "~/images/True.gif";
            ImgS23.Src = "~/images/True.gif";
            ImgS24.Src = "~/images/True.gif";
            ImgS25.Src = "~/images/True.gif";
            ImgS26.Src = "~/images/True.gif";
            ImgS27.Src = "~/images/True.gif";
            ImgS28.Src = "~/images/True.gif";
            ImgS29.Src = "~/images/True.gif";
            ImgS30.Src = "~/images/True.gif";
            ImgS31.Src = "~/images/True.gif";
            ImgS32.Src = "~/images/True.gif";
            ImgS33.Src = "~/images/True.gif";
            ImgS34.Src = "~/images/True.gif";
            ImgS35.Src = "~/images/True.gif";
            ImgS36.Src = "~/images/True.gif";
            ImgS37.Src = "~/images/True.gif";
            ImgS38.Src = "~/images/True.gif";
            ImgS39.Src = "~/images/True.gif";
            ImgS40.Src = "~/images/True.gif";
            ImgS41.Src = "~/images/True.gif";
            ImgS42.Src = "~/images/True.gif";
            ImgS43.Src = "~/images/True.gif";
            ImgS44.Src = "~/images/True.gif";
            ImgS45.Src = "~/images/True.gif";
            ImgS46.Src = "~/images/True.gif";
            ImgS47.Src = "~/images/True.gif";
            ImgS48.Src = "~/images/True.gif";
            ImgS49.Src = "~/images/True.gif";
            ImgS50.Src = "~/images/True.gif";
            ImgS51.Src = "~/images/True.gif";
            ImgS52.Src = "~/images/True.gif";
            ImgS53.Src = "~/images/True.gif";
            ImgS54.Src = "~/images/True.gif";
            ImgS55.Src = "~/images/True.gif";
            ImgS56.Src = "~/images/True.gif";


        }

        protected void ddlPCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearSItems();
                if (ddlPCheck.SelectedValue != "-1")
                {
                    ChList myacc = new ChList();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.VouType = (short)(int.Parse(ddlPCheck.SelectedValue.Split('/')[0]));
                    myacc.VouLoc = short.Parse(StoreNo);
                    myacc.VouNo = int.Parse(ddlPCheck.SelectedValue.Split('/')[1]);
                    myacc = myacc.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc != null)
                    {
                        BtnSame.Visible = true;
                        BtnViewS01.PostBackUrl = myacc.Pic01;
                        BtnViewS01.Visible = (myacc.Pic01 != "");
                        BtnViewS02.PostBackUrl = myacc.Pic02;
                        BtnViewS02.Visible = (myacc.Pic02 != "");
                        BtnViewS03.PostBackUrl = myacc.Pic03;
                        BtnViewS03.Visible = (myacc.Pic03 != "");
                        BtnViewS04.PostBackUrl = myacc.Pic04;
                        BtnViewS04.Visible = (myacc.Pic04 != "");
                        BtnViewS05.PostBackUrl = myacc.Pic05;
                        BtnViewS05.Visible = (myacc.Pic05 != "");
                        BtnViewS06.PostBackUrl = myacc.Pic06;
                        BtnViewS06.Visible = (myacc.Pic06 != "");
                        BtnViewS07.PostBackUrl = myacc.Pic07;
                        BtnViewS07.Visible = (myacc.Pic07 != "");
                        BtnViewS08.PostBackUrl = myacc.Pic08;
                        BtnViewS08.Visible = (myacc.Pic08 != "");
                        BtnViewS09.PostBackUrl = myacc.Pic09;
                        BtnViewS09.Visible = (myacc.Pic09 != "");
                        BtnViewS10.PostBackUrl = myacc.Pic10;
                        BtnViewS10.Visible = (myacc.Pic10 != "");
                        BtnViewS11.PostBackUrl = myacc.Pic11;
                        BtnViewS11.Visible = (myacc.Pic11 != "");
                        BtnViewS12.PostBackUrl = myacc.Pic12;
                        BtnViewS12.Visible = (myacc.Pic12 != "");
                        BtnViewS13.PostBackUrl = myacc.Pic13;
                        BtnViewS13.Visible = (myacc.Pic13 != "");
                        BtnViewS14.PostBackUrl = myacc.Pic14;
                        BtnViewS14.Visible = (myacc.Pic14 != "");
                        BtnViewS15.PostBackUrl = myacc.Pic15;
                        BtnViewS15.Visible = (myacc.Pic15 != "");
                        BtnViewS16.PostBackUrl = myacc.Pic16;
                        BtnViewS16.Visible = (myacc.Pic16 != "");
                        BtnViewS17.PostBackUrl = myacc.Pic17;
                        BtnViewS17.Visible = (myacc.Pic17 != "");
                        BtnViewS18.PostBackUrl = myacc.Pic18;
                        BtnViewS18.Visible = (myacc.Pic18 != "");
                        BtnViewS19.PostBackUrl = myacc.Pic19;
                        BtnViewS19.Visible = (myacc.Pic19 != "");
                        BtnViewS20.PostBackUrl = myacc.Pic20;
                        BtnViewS20.Visible = (myacc.Pic20 != "");
                        BtnViewS21.PostBackUrl = myacc.Pic21;
                        BtnViewS21.Visible = (myacc.Pic21 != "");
                        BtnViewS22.PostBackUrl = myacc.Pic22;
                        BtnViewS22.Visible = (myacc.Pic22 != "");
                        BtnViewS23.PostBackUrl = myacc.Pic23;
                        BtnViewS23.Visible = (myacc.Pic23 != "");
                        BtnViewS24.PostBackUrl = myacc.Pic24;
                        BtnViewS24.Visible = (myacc.Pic24 != "");
                        BtnViewS25.PostBackUrl = myacc.Pic25;
                        BtnViewS25.Visible = (myacc.Pic25 != "");
                        BtnViewS26.PostBackUrl = myacc.Pic26;
                        BtnViewS26.Visible = (myacc.Pic26 != "");
                        BtnViewS27.PostBackUrl = myacc.Pic27;
                        BtnViewS27.Visible = (myacc.Pic27 != "");
                        BtnViewS28.PostBackUrl = myacc.Pic28;
                        BtnViewS28.Visible = (myacc.Pic28 != "");
                        BtnViewS29.PostBackUrl = myacc.Pic29;
                        BtnViewS29.Visible = (myacc.Pic29 != "");
                        BtnViewS30.PostBackUrl = myacc.Pic30;
                        BtnViewS30.Visible = (myacc.Pic30 != "");
                        BtnViewS31.PostBackUrl = myacc.Pic31;
                        BtnViewS31.Visible = (myacc.Pic31 != "");
                        BtnViewS32.PostBackUrl = myacc.Pic32;
                        BtnViewS32.Visible = (myacc.Pic32 != "");
                        BtnViewS33.PostBackUrl = myacc.Pic33;
                        BtnViewS33.Visible = (myacc.Pic33 != "");
                        BtnViewS34.PostBackUrl = myacc.Pic34;
                        BtnViewS34.Visible = (myacc.Pic34 != "");
                        BtnViewS35.PostBackUrl = myacc.Pic35;
                        BtnViewS35.Visible = (myacc.Pic35 != "");
                        BtnViewS36.PostBackUrl = myacc.Pic36;
                        BtnViewS36.Visible = (myacc.Pic36 != "");
                        BtnViewS37.PostBackUrl = myacc.Pic37;
                        BtnViewS37.Visible = (myacc.Pic37 != "");
                        BtnViewS38.PostBackUrl = myacc.Pic38;
                        BtnViewS38.Visible = (myacc.Pic38 != "");
                        BtnViewS39.PostBackUrl = myacc.Pic39;
                        BtnViewS39.Visible = (myacc.Pic39 != "");
                        BtnViewS40.PostBackUrl = myacc.Pic40;
                        BtnViewS40.Visible = (myacc.Pic40 != "");
                        BtnViewS41.PostBackUrl = myacc.Pic41;
                        BtnViewS41.Visible = (myacc.Pic41 != "");
                        BtnViewS42.PostBackUrl = myacc.Pic42;
                        BtnViewS42.Visible = (myacc.Pic42 != "");
                        BtnViewS43.PostBackUrl = myacc.Pic43;
                        BtnViewS43.Visible = (myacc.Pic43 != "");
                        BtnViewS44.PostBackUrl = myacc.Pic44;
                        BtnViewS44.Visible = (myacc.Pic44 != "");
                        BtnViewS45.PostBackUrl = myacc.Pic45;
                        BtnViewS45.Visible = (myacc.Pic45 != "");
                        BtnViewS46.PostBackUrl = myacc.Pic46;
                        BtnViewS46.Visible = (myacc.Pic46 != "");
                        BtnViewS47.PostBackUrl = myacc.Pic47;
                        BtnViewS47.Visible = (myacc.Pic47 != "");
                        BtnViewS48.PostBackUrl = myacc.Pic48;
                        BtnViewS48.Visible = (myacc.Pic48 != "");
                        BtnViewS49.PostBackUrl = myacc.Pic49;
                        BtnViewS49.Visible = (myacc.Pic49 != "");
                        BtnViewS50.PostBackUrl = myacc.Pic50;
                        BtnViewS50.Visible = (myacc.Pic50 != "");
                        BtnViewS51.PostBackUrl = myacc.Pic51;
                        BtnViewS51.Visible = (myacc.Pic51 != "");
                        BtnViewS52.PostBackUrl = myacc.Pic52;
                        BtnViewS52.Visible = (myacc.Pic52 != "");
                        BtnViewS53.PostBackUrl = myacc.Pic53;
                        BtnViewS53.Visible = (myacc.Pic53 != "");
                        BtnViewS54.PostBackUrl = myacc.Pic54;
                        BtnViewS54.Visible = (myacc.Pic54 != "");
                        BtnViewS55.PostBackUrl = myacc.Pic55;
                        BtnViewS55.Visible = (myacc.Pic55 != "");
                        BtnViewS56.PostBackUrl = myacc.Pic55;
                        BtnViewS56.Visible = (myacc.Pic55 != "");

                        txtSItem00.ToolTip = myacc.Item00;
                        if (myacc.Item00 != "-1")
                        {
                            Cars myInv = new Cars();
                            myInv.Branch = short.Parse(Session["Branch"].ToString());
                            if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myInv.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                            myInv.CarsType = 2;
                            myInv.Code = myacc.Item00;
                            myInv = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                     where sitm.Code == myInv.Code
                                     select sitm).FirstOrDefault();
                            if (myInv != null)
                            {
                                txtSItem00.Text = myInv.CarType2.Substring(0, 10);
                            }
                        }
                        txtSItem01.Text = myacc.Item01;
                        txtSItem02.Text = myacc.Item02;
                        txtSItem03.Text = myacc.Item03;
                        txtSItem04.Text = myacc.Item04;
                        txtSItem05.Text = myacc.Item05;
                        txtSItem06.Text = myacc.Item06;
                        txtSItem07.Text = myacc.Item07;
                        txtSItem08.Text = myacc.Item08;
                        txtSItem09.Text = myacc.Item09;
                        txtSItem10.Text = myacc.Item10;
                        txtSItem11.Text = myacc.Item11;
                        txtSItem12.Text = myacc.Item12;
                        txtSItem13.Text = myacc.Item13;
                        txtSItem14.Text = myacc.Item14;
                        txtSItem15.Text = myacc.Item15;
                        txtSItem16.Text = myacc.Item16;
                        txtSItem17.Text = myacc.Item17;
                        txtSItem18.Text = myacc.Item18;
                        txtSItem19.Text = myacc.Item19;
                        txtSItem20.Text = myacc.Item20;
                        txtSItem21.Text = myacc.Item21;
                        txtSItem22.Text = myacc.Item22;
                        txtSItem23.Text = myacc.Item23;
                        txtSItem24.Text = myacc.Item24;
                        txtSItem25.Text = myacc.Item25;
                        txtSItem26.Text = myacc.Item26;
                        txtSItem27.Text = myacc.Item27;
                        txtSItem28.Text = myacc.Item28;
                        txtSItem29.Text = myacc.Item29;
                        txtSItem30.Text = myacc.Item30;
                        txtSItem31.Text = myacc.Item31;
                        txtSItem32.Text = myacc.Item32;
                        txtSItem33.Text = myacc.Item33;
                        txtSItem34.Text = myacc.Item34;
                        txtSItem35.Text = myacc.Item35;
                        txtSItem36.Text = myacc.Item36;
                        txtSItem37.Text = myacc.Item37;
                        txtSItem38.Text = myacc.Item38;
                        txtSItem39.Text = myacc.Item39;
                        txtSItem40.Text = myacc.Item40;
                        txtSItem41.Text = myacc.Item41;
                        txtSItem42.Text = myacc.Item42;
                        txtSItem43.Text = myacc.Item43;
                        txtSItem44.Text = myacc.Item44;
                        txtSItem45.Text = myacc.Item45;
                        txtSItem46.Text = myacc.Item46;
                        txtSItem47.Text = myacc.Item47;
                        txtSItem48.Text = myacc.Item48;
                        txtSItem49.Text = myacc.Item49;
                        txtSItem50.Text = myacc.Item50;
                        txtSItem51.Text = myacc.Item51;
                        txtSItem52.Text = myacc.Item52;
                        txtSItem53.Text = myacc.Item53;
                        txtSItem54.Text = myacc.Item54;
                        txtSItem55.Text = myacc.Item55;
                        txtSItem56.Text = myacc.Item56;

                        ImgS01.Src = RetValue(myacc.I01);
                        ImgS02.Src = RetValue(myacc.I02);
                        ImgS03.Src = RetValue(myacc.I03);
                        ImgS04.Src = RetValue(myacc.I04);
                        ImgS05.Src = RetValue(myacc.I05);
                        ImgS06.Src = RetValue(myacc.I06);
                        ImgS07.Src = RetValue(myacc.I07);
                        ImgS08.Src = RetValue(myacc.I08);
                        ImgS09.Src = RetValue(myacc.I09);
                        ImgS10.Src = RetValue(myacc.I10);
                        ImgS11.Src = RetValue(myacc.I11);
                        ImgS12.Src = RetValue(myacc.I12);
                        ImgS13.Src = RetValue(myacc.I13);
                        ImgS14.Src = RetValue(myacc.I14);
                        ImgS15.Src = RetValue(myacc.I15);
                        ImgS16.Src = RetValue(myacc.I16);
                        ImgS17.Src = RetValue(myacc.I17);
                        ImgS18.Src = RetValue(myacc.I18);
                        ImgS19.Src = RetValue(myacc.I19);
                        ImgS20.Src = RetValue(myacc.I20);
                        ImgS21.Src = RetValue(myacc.I21);
                        ImgS22.Src = RetValue(myacc.I22);
                        ImgS23.Src = RetValue(myacc.I23);
                        ImgS24.Src = RetValue(myacc.I24);
                        ImgS25.Src = RetValue(myacc.I25);
                        ImgS26.Src = RetValue(myacc.I26);
                        ImgS27.Src = RetValue(myacc.I27);
                        ImgS28.Src = RetValue(myacc.I28);
                        ImgS29.Src = RetValue(myacc.I29);
                        ImgS30.Src = RetValue(myacc.I30);
                        ImgS31.Src = RetValue(myacc.I31);
                        ImgS32.Src = RetValue(myacc.I32);
                        ImgS33.Src = RetValue(myacc.I33);
                        ImgS34.Src = RetValue(myacc.I34);
                        ImgS35.Src = RetValue(myacc.I35);
                        ImgS36.Src = RetValue(myacc.I36);
                        ImgS37.Src = RetValue(myacc.I37);
                        ImgS38.Src = RetValue(myacc.I38);
                        ImgS39.Src = RetValue(myacc.I39);
                        ImgS40.Src = RetValue(myacc.I40);
                        ImgS41.Src = RetValue(myacc.I41);
                        ImgS42.Src = RetValue(myacc.I42);
                        ImgS43.Src = RetValue(myacc.I43);
                        ImgS44.Src = RetValue(myacc.I44);
                        ImgS45.Src = RetValue(myacc.I45);
                        ImgS46.Src = RetValue(myacc.I46);
                        ImgS47.Src = RetValue(myacc.I47);
                        ImgS48.Src = RetValue(myacc.I48);
                        ImgS49.Src = RetValue(myacc.I49);
                        ImgS50.Src = RetValue(myacc.I50);
                        ImgS51.Src = RetValue(myacc.I51);
                        ImgS52.Src = RetValue(myacc.I52);
                        ImgS53.Src = RetValue(myacc.I53);
                        ImgS54.Src = RetValue(myacc.I54);
                        ImgS55.Src = RetValue(myacc.I55);
                        ImgS56.Src = RetValue(myacc.I56);
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

        protected void BtnSame_Click(object sender, EventArgs e)
        {
            try
            {
                BtnView001.PostBackUrl = BtnViewS01.PostBackUrl;
                BtnView001.Visible = BtnViewS01.Visible;
                BtnView002.PostBackUrl = BtnViewS02.PostBackUrl;
                BtnView002.Visible = BtnViewS02.Visible;
                BtnView003.PostBackUrl = BtnViewS03.PostBackUrl;
                BtnView003.Visible = BtnViewS03.Visible;
                BtnView004.PostBackUrl = BtnViewS04.PostBackUrl;
                BtnView004.Visible = BtnViewS04.Visible;
                BtnView005.PostBackUrl = BtnViewS05.PostBackUrl;
                BtnView005.Visible = BtnViewS05.Visible;
                BtnView006.PostBackUrl = BtnViewS06.PostBackUrl;
                BtnView006.Visible = BtnViewS06.Visible;
                BtnView007.PostBackUrl = BtnViewS07.PostBackUrl;
                BtnView007.Visible = BtnViewS07.Visible;
                BtnView008.PostBackUrl = BtnViewS08.PostBackUrl;
                BtnView008.Visible = BtnViewS08.Visible;
                BtnView009.PostBackUrl = BtnViewS09.PostBackUrl;
                BtnView009.Visible = BtnViewS09.Visible;
                BtnView010.PostBackUrl = BtnViewS10.PostBackUrl;
                BtnView010.Visible = BtnViewS10.Visible;
                BtnView011.PostBackUrl = BtnViewS11.PostBackUrl;
                BtnView011.Visible = BtnViewS11.Visible;
                BtnView012.PostBackUrl = BtnViewS12.PostBackUrl;
                BtnView012.Visible = BtnViewS12.Visible;
                BtnView013.PostBackUrl = BtnViewS13.PostBackUrl;
                BtnView013.Visible = BtnViewS13.Visible;
                BtnView014.PostBackUrl = BtnViewS14.PostBackUrl;
                BtnView014.Visible = BtnViewS14.Visible;
                BtnView015.PostBackUrl = BtnViewS15.PostBackUrl;
                BtnView015.Visible = BtnViewS15.Visible;
                BtnView016.PostBackUrl = BtnViewS16.PostBackUrl;
                BtnView016.Visible = BtnViewS16.Visible;
                BtnView017.PostBackUrl = BtnViewS17.PostBackUrl;
                BtnView017.Visible = BtnViewS17.Visible;
                BtnView018.PostBackUrl = BtnViewS18.PostBackUrl;
                BtnView018.Visible = BtnViewS18.Visible;
                BtnView019.PostBackUrl = BtnViewS19.PostBackUrl;
                BtnView019.Visible = BtnViewS19.Visible;
                BtnView020.PostBackUrl = BtnViewS20.PostBackUrl;
                BtnView020.Visible = BtnViewS20.Visible;
                BtnView021.PostBackUrl = BtnViewS21.PostBackUrl;
                BtnView021.Visible = BtnViewS21.Visible;
                BtnView022.PostBackUrl = BtnViewS22.PostBackUrl;
                BtnView022.Visible = BtnViewS22.Visible;
                BtnView023.PostBackUrl = BtnViewS23.PostBackUrl;
                BtnView023.Visible = BtnViewS23.Visible;
                BtnView024.PostBackUrl = BtnViewS24.PostBackUrl;
                BtnView024.Visible = BtnViewS24.Visible;
                BtnView025.PostBackUrl = BtnViewS25.PostBackUrl;
                BtnView025.Visible = BtnViewS25.Visible;
                BtnView026.PostBackUrl = BtnViewS26.PostBackUrl;
                BtnView026.Visible = BtnViewS26.Visible;
                BtnView027.PostBackUrl = BtnViewS27.PostBackUrl;
                BtnView027.Visible = BtnViewS27.Visible;
                BtnView028.PostBackUrl = BtnViewS28.PostBackUrl;
                BtnView028.Visible = BtnViewS28.Visible;
                BtnView029.PostBackUrl = BtnViewS29.PostBackUrl;
                BtnView029.Visible = BtnViewS29.Visible;
                BtnView030.PostBackUrl = BtnViewS30.PostBackUrl;
                BtnView030.Visible = BtnViewS30.Visible;
                BtnView031.PostBackUrl = BtnViewS31.PostBackUrl;
                BtnView031.Visible = BtnViewS31.Visible;
                BtnView032.PostBackUrl = BtnViewS32.PostBackUrl;
                BtnView032.Visible = BtnViewS32.Visible;
                BtnView033.PostBackUrl = BtnViewS33.PostBackUrl;
                BtnView033.Visible = BtnViewS33.Visible;
                BtnView034.PostBackUrl = BtnViewS34.PostBackUrl;
                BtnView034.Visible = BtnViewS34.Visible;
                BtnView035.PostBackUrl = BtnViewS35.PostBackUrl;
                BtnView035.Visible = BtnViewS35.Visible;
                BtnView036.PostBackUrl = BtnViewS36.PostBackUrl;
                BtnView036.Visible = BtnViewS36.Visible;
                BtnView037.PostBackUrl = BtnViewS37.PostBackUrl;
                BtnView037.Visible = BtnViewS37.Visible;
                BtnView038.PostBackUrl = BtnViewS38.PostBackUrl;
                BtnView038.Visible = BtnViewS38.Visible;
                BtnView039.PostBackUrl = BtnViewS39.PostBackUrl;
                BtnView039.Visible = BtnViewS39.Visible;
                BtnView040.PostBackUrl = BtnViewS40.PostBackUrl;
                BtnView040.Visible = BtnViewS40.Visible;
                BtnView041.PostBackUrl = BtnViewS41.PostBackUrl;
                BtnView041.Visible = BtnViewS41.Visible;
                BtnView042.PostBackUrl = BtnViewS42.PostBackUrl;
                BtnView042.Visible = BtnViewS42.Visible;
                BtnView043.PostBackUrl = BtnViewS43.PostBackUrl;
                BtnView043.Visible = BtnViewS43.Visible;
                BtnView044.PostBackUrl = BtnViewS44.PostBackUrl;
                BtnView044.Visible = BtnViewS44.Visible;
                BtnView045.PostBackUrl = BtnViewS45.PostBackUrl;
                BtnView045.Visible = BtnViewS45.Visible;
                BtnView046.PostBackUrl = BtnViewS46.PostBackUrl;
                BtnView046.Visible = BtnViewS46.Visible;
                BtnView047.PostBackUrl = BtnViewS47.PostBackUrl;
                BtnView047.Visible = BtnViewS47.Visible;
                BtnView048.PostBackUrl = BtnViewS48.PostBackUrl;
                BtnView048.Visible = BtnViewS48.Visible;
                BtnView049.PostBackUrl = BtnViewS49.PostBackUrl;
                BtnView049.Visible = BtnViewS49.Visible;
                BtnView050.PostBackUrl = BtnViewS50.PostBackUrl;
                BtnView050.Visible = BtnViewS50.Visible;
                BtnView051.PostBackUrl = BtnViewS51.PostBackUrl;
                BtnView051.Visible = BtnViewS51.Visible;
                BtnView052.PostBackUrl = BtnViewS52.PostBackUrl;
                BtnView052.Visible = BtnViewS52.Visible;
                BtnView053.PostBackUrl = BtnViewS53.PostBackUrl;
                BtnView053.Visible = BtnViewS53.Visible;
                BtnView054.PostBackUrl = BtnViewS54.PostBackUrl;
                BtnView054.Visible = BtnViewS54.Visible;
                BtnView055.PostBackUrl = BtnViewS55.PostBackUrl;
                BtnView055.Visible = BtnViewS55.Visible;
                BtnView056.PostBackUrl = BtnViewS56.PostBackUrl;
                BtnView056.Visible = BtnViewS56.Visible;

                if (txtSItem00.ToolTip != "") ddlItem00.SelectedValue = txtSItem00.ToolTip;
                txtItem01.Text = txtSItem01.Text;
                txtItem02.Text = txtSItem02.Text;
                txtItem03.Text = txtSItem03.Text;
                txtItem04.Text = txtSItem04.Text;
                txtItem05.Text = txtSItem05.Text;
                txtItem06.Text = txtSItem06.Text;
                txtItem07.Text = txtSItem07.Text;
                txtItem08.Text = txtSItem08.Text;
                txtItem09.Text = txtSItem09.Text;
                txtItem10.Text = txtSItem10.Text;
                txtItem11.Text = txtSItem11.Text;
                txtItem12.Text = txtSItem12.Text;
                txtItem13.Text = txtSItem13.Text;
                txtItem14.Text = txtSItem14.Text;
                txtItem15.Text = txtSItem15.Text;
                txtItem16.Text = txtSItem16.Text;
                txtItem17.Text = txtSItem17.Text;
                txtItem18.Text = txtSItem18.Text;
                txtItem19.Text = txtSItem19.Text;
                txtItem20.Text = txtSItem20.Text;
                txtItem21.Text = txtSItem21.Text;
                txtItem22.Text = txtSItem22.Text;
                txtItem23.Text = txtSItem23.Text;
                txtItem24.Text = txtSItem24.Text;
                txtItem25.Text = txtSItem25.Text;
                txtItem26.Text = txtSItem26.Text;
                txtItem27.Text = txtSItem27.Text;
                txtItem28.Text = txtSItem28.Text;
                txtItem29.Text = txtSItem29.Text;
                txtItem30.Text = txtSItem30.Text;
                txtItem31.Text = txtSItem31.Text;
                txtItem32.Text = txtSItem32.Text;
                txtItem33.Text = txtSItem33.Text;
                txtItem34.Text = txtSItem34.Text;
                txtItem35.Text = txtSItem35.Text;
                txtItem36.Text = txtSItem36.Text;
                txtItem37.Text = txtSItem37.Text;
                txtItem38.Text = txtSItem38.Text;
                txtItem39.Text = txtSItem39.Text;
                txtItem40.Text = txtSItem40.Text;
                txtItem41.Text = txtSItem41.Text;
                txtItem42.Text = txtSItem42.Text;
                txtItem43.Text = txtSItem43.Text;
                txtItem44.Text = txtSItem44.Text;
                txtItem45.Text = txtSItem45.Text;
                txtItem46.Text = txtSItem46.Text;
                txtItem47.Text = txtSItem47.Text;
                txtItem48.Text = txtSItem48.Text;
                txtItem49.Text = txtSItem49.Text;
                txtItem50.Text = txtSItem50.Text;
                txtItem51.Text = txtSItem51.Text;
                txtItem52.Text = txtSItem52.Text;
                txtItem53.Text = txtSItem53.Text;
                txtItem54.Text = txtSItem54.Text;
                txtItem55.Text = txtSItem55.Text;
                txtItem56.Text = txtSItem56.Text;

                Img01.Src = ImgS01.Src;
                Img02.Src = ImgS02.Src;
                Img03.Src = ImgS03.Src;
                Img04.Src = ImgS04.Src;
                Img05.Src = ImgS05.Src;
                Img06.Src = ImgS06.Src;
                Img07.Src = ImgS07.Src;
                Img08.Src = ImgS08.Src;
                Img09.Src = ImgS09.Src;
                Img10.Src = ImgS10.Src;
                Img11.Src = ImgS11.Src;
                Img12.Src = ImgS12.Src;
                Img13.Src = ImgS13.Src;
                Img14.Src = ImgS14.Src;
                Img15.Src = ImgS15.Src;
                Img16.Src = ImgS16.Src;
                Img17.Src = ImgS17.Src;
                Img18.Src = ImgS18.Src;
                Img19.Src = ImgS19.Src;
                Img20.Src = ImgS20.Src;
                Img21.Src = ImgS21.Src;
                Img22.Src = ImgS22.Src;
                Img23.Src = ImgS23.Src;
                Img24.Src = ImgS24.Src;
                Img25.Src = ImgS25.Src;
                Img26.Src = ImgS26.Src;
                Img27.Src = ImgS27.Src;
                Img28.Src = ImgS28.Src;
                Img29.Src = ImgS29.Src;
                Img30.Src = ImgS30.Src;
                Img31.Src = ImgS31.Src;
                Img32.Src = ImgS32.Src;
                Img33.Src = ImgS33.Src;
                Img34.Src = ImgS34.Src;
                Img35.Src = ImgS35.Src;
                Img36.Src = ImgS36.Src;
                Img37.Src = ImgS37.Src;
                Img38.Src = ImgS38.Src;
                Img39.Src = ImgS39.Src;
                Img40.Src = ImgS40.Src;
                Img41.Src = ImgS41.Src;
                Img42.Src = ImgS42.Src;
                Img43.Src = ImgS43.Src;
                Img44.Src = ImgS44.Src;
                Img45.Src = ImgS45.Src;
                Img46.Src = ImgS46.Src;
                Img47.Src = ImgS47.Src;
                Img48.Src = ImgS48.Src;
                Img49.Src = ImgS49.Src;
                Img50.Src = ImgS50.Src;
                Img51.Src = ImgS51.Src;
                Img52.Src = ImgS52.Src;
                Img53.Src = ImgS53.Src;
                Img54.Src = ImgS54.Src;
                Img55.Src = ImgS55.Src;
                Img56.Src = ImgS56.Src;
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