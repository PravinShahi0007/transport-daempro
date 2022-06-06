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
using System.Web.UI.HtmlControls;

namespace ACC
{
    public partial class WebCars : System.Web.UI.Page
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
            txtCode.ReadOnly = true;
            txtCode.BackColor = System.Drawing.Color.LightGray;
            ddlCarsType.Enabled = false;
            ddlCarsType.BackColor = System.Drawing.Color.LightGray;

            BtnEdit.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass182;
            BtnNew.Visible = false;
            BtnDelete.Visible = false; // && (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass183; // true
        }

        public void NewMode()
        {
            txtCode.ReadOnly = false;
            txtCode.BackColor = System.Drawing.Color.White;
            ddlCarsType.BackColor = System.Drawing.Color.White;
            ddlCarsType.Enabled = true;

            BtnEdit.Visible = false;
            BtnNew.Visible = false;  // && (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass181;  // true
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
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttach);
                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "بيانات الشاحنات";

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

                    CarsType myCarsType = new CarsType();
                    myCarsType.Branch = short.Parse(Session["Branch"].ToString());
                    ddlCarsType.DataTextField = "Name1";
                    ddlCarsType.DataValueField = "Code";
                    ddlCarsType.DataSource = myCarsType.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlCarsType.DataBind();

                    ddlFollowType.DataTextField = "Name1";
                    ddlFollowType.DataValueField = "Code";
                    ddlFollowType.DataSource = (from itm in myCarsType.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                                where itm.Code > 1 && itm.Code < 6
                                                select itm).ToList();
                    ddlFollowType.DataBind();
                    ddlFollowType.Items.Insert(0, new ListItem("--- أختار نوع الملحق ---", "-1", true));

                    ddlFollow2.Items.Insert(0, new ListItem("--- أختار الملحق ---", "-1", true));

                    Acc myAcc = new Acc();
                    myAcc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastACC" + Session["CNN2"].ToString()] == null) Cache.Insert("LastACC" + Session["CNN2"].ToString(), myAcc.GetLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlFixAssetCode.DataTextField = "Name1";
                    ddlFixAssetCode.DataValueField = "Code";
                    ddlFixAssetCode.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                                  where itm.FCode.StartsWith("1101")
                                                  select itm).ToList();
                    ddlFixAssetCode.DataBind();
                    ddlFixAssetCode.Items.Insert(0, new ListItem("--- أختار حساب الاصل ---", "-1", true));

                    Codes myCodes = new Codes();
                    myCodes.Branch = short.Parse(Session["Branch"].ToString());
                    myCodes.Ftype = 30;
                    if (Cache["LastCodes" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCodes" + Session["CNN2"].ToString(), myCodes.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlFType2.DataTextField = "Name1";
                    ddlFType2.DataValueField = "Code";
                    ddlFType2.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                            where itm.Ftype == 30
                                            select itm).ToList();
                    ddlFType2.DataBind();
                    ddlFType2.Items.Insert(0, new ListItem("--- أختار ملحقات الشاحنة ---", "-1", true));

                    ddlFollow2.Items.Insert(0, new ListItem("--- أختار الملحق ---", "-1", true));

                    Drivers myDrive = new Drivers();
                    myDrive.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlDrivers.DataTextField = "Name1";
                    ddlDrivers.DataValueField = "Code";
                    ddlDrivers.DataSource = (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()]);
                    ddlDrivers.DataBind();
                    ddlDrivers.Items.Insert(0, new ListItem("--- أختار السائق ---", "-1", true));

                    BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass181;
                    BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass182;
                    BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass183;
                    BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass184;
                    BtnFind.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass184;

                    LoadDriversData();
                    BtnClear_Click(sender, null);
                    if (Request.QueryString["CarNo"] != null)
                    {
                        if (!(bool)((List<TblRoles>)(Session["Roll"]))[1].Pass182)
                        {
                            BtnEdit.Visible = false;
                            BtnDelete.Visible = false;
                            BtnClear.Visible = false;
                            ((HtmlGenericControl)this.Master.FindControl("menu")).Visible = false;
                        }
                        txtCode.Text = Request.QueryString["CarNo"].ToString();
                        BtnSearch_Click(sender, null);
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


        protected void LoadDriversData()
        {
            try
            {
                Cars myacc = new Cars();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myacc.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myacc.CarsType = int.Parse(ddlCarsType.SelectedValue);
                grdCodes.DataSource = (from itm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                       where itm.CarsType == myacc.CarsType
                                       select itm).ToList();
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
                string Code = grdCodes.DataKeys[e.NewSelectedIndex]["Code"].ToString();
                txtCode.Text = Code;
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
                LoadDriversData();
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
                ddlFollowType.SelectedIndex = 0;
                ddlFollowType_SelectedIndexChanged(sender, e);
                ddlFixAssetCode.SelectedIndex = 0;
                ddlDrivers.SelectedIndex = 0;
                ddlFType2.SelectedIndex = 0;
                txtCarType.Text = "";
                txtCarType2.Text = "";
                txtChDezelDate.Text = "";
                txtChDezelKMeter.Text = "";
                txtChOilDate.Text = "";
                txtChOilKMeter.Text = "";
                txtCode.Text = "";
                txtKMeter.Text = "";
                txtPlateNo.Text = "";
                txtTaraz.Text = "";
                txtModel.Text = "";
                txtWorkShopCode.Text = "";
                ChkStatus.Checked = true;
                txtPHDate1.Text = "";
                txtPHDate2.Text = "";
                txtPHDate3.Text = "";
                txtPHDate4.Text = "";
                txtPHDate5.Text = "";
                txtPLoc1.Text = "";
                txtPLoc2.Text = "";
                txtPLoc3.Text = "";
                txtPLoc4.Text = "";
                txtPLoc5.Text = "";
                txtPLoc.Text = "";
                txtBrand.Text = "";
                txtCarStruct.Text = "";
                txtCarSerial.Text = "";
                txtamP1.Text = "";
                txtamP2.Text = "";
                txtamP3.Text = "";
                txtamP4.Text = "";
                txtamP5.Text = "";
                txtamP6.Text = "";
                txtMP1.Text = "";
                txtMP2.Text = "";
                txtMP3.Text = "";
                txtMP4.Text = "";
                txtMP5.Text = "";
                txtMP6.Text = "";
                txtP1LDate.Text = "";
                txtP2LDate.Text = "";
                txtP3LDate.Text = "";
                txtP4LDate.Text = "";
                txtP5LDate.Text = "";
                txtP6LDate.Text = "";
                Cars myacc = new Cars();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                myacc.CarsType = int.Parse(ddlCarsType.SelectedValue);
                string s = myacc.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (s != null)
                {
                    txtCode.Text = moh.MakeMask((Int32.Parse(s) + 1).ToString(), 5);
                }
                else
                {
                    txtCode.Text = "00001";
                }

                grdMan.DataSource = null;
                grdMan.DataBind();

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

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    txtCode.Text = moh.MakeMask(txtCode.Text, 5);
                    Cars myacc = new Cars();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myacc.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myacc.CarsType = int.Parse(ddlCarsType.SelectedValue);
                    myacc.Code = txtCode.Text;
                    myacc = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                             where sitm.Code == myacc.Code
                             select sitm).FirstOrDefault();
                    if (myacc == null)
                    {
                        if (txtWorkShopCode.Text.Trim() != "")
                        {
                            myacc = new Cars();
                            myacc.Branch = short.Parse(Session["Branch"].ToString());
                            myacc.WorkShopCode = txtWorkShopCode.Text.Trim();
                            myacc = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                     where sitm.WorkShopCode == myacc.WorkShopCode
                                     select sitm).FirstOrDefault();
                            if (myacc != null)
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "كود الورشة مكرر";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }
                        if (txtKMeter.Text == "") txtKMeter.Text = "0";
                        if (txtChDezelKMeter.Text == "") txtChDezelKMeter.Text = "0";
                        if (txtChDezelKMeter.Text == "") txtChDezelKMeter.Text = "0";
                        myacc = new Cars();
                        myacc.Branch = short.Parse(Session["Branch"].ToString());
                        myacc.CarsType = int.Parse(ddlCarsType.SelectedValue);
                        myacc.Code = txtCode.Text;
                        myacc.CarType = txtCarType.Text;
                        myacc.CarType2 = txtCarType2.Text;
                        myacc.ChDezelDate = txtChDezelDate.Text;
                        myacc.ChDezelKMeter = int.Parse(txtChDezelKMeter.Text);
                        myacc.ChOilDate = txtChOilDate.Text;
                        myacc.ChOilKMeter = int.Parse(txtChOilKMeter.Text);
                        myacc.PlateNo = txtPlateNo.Text;
                        myacc.KMeter = int.Parse(txtKMeter.Text);
                        myacc.DriverCode = ddlDrivers.SelectedValue;
                        myacc.Taraz = txtTaraz.Text;
                        myacc.Model = txtModel.Text;
                        myacc.FType2 = ddlFType2.SelectedValue;
                        myacc.WorkShopCode = txtWorkShopCode.Text;
                        myacc.FixAssetCode = ddlFixAssetCode.SelectedValue;
                        myacc.FollowType = int.Parse(ddlFollowType.SelectedValue);
                        myacc.Follow2 = int.Parse(ddlFollow2.SelectedValue);
                        myacc.Status = ChkStatus.Checked;
                        myacc.PHDate1 = txtPHDate1.Text;
                        myacc.PHDate2 = txtPHDate2.Text;
                        myacc.PHDate3 = txtPHDate3.Text;
                        myacc.PHDate4 = txtPHDate4.Text;
                        myacc.PHDate5 = txtPHDate5.Text;
                        myacc.PLoc1 = txtPLoc1.Text;
                        myacc.PLoc2 = txtPLoc2.Text;
                        myacc.PLoc3 = txtPLoc3.Text;
                        myacc.PLoc4 = txtPLoc4.Text;
                        myacc.PLoc5 = txtPLoc5.Text;
                        myacc.PLoc = txtPLoc.Text;
                        myacc.Brand = txtBrand.Text;
                        myacc.CarStruct = txtCarStruct.Text;
                        myacc.CarSerial = txtCarSerial.Text;
                        myacc.P1am = moh.StrToDouble(txtamP1.Text);
                        myacc.P2am = moh.StrToDouble(txtamP2.Text);
                        myacc.P3am = moh.StrToDouble(txtamP3.Text);
                        myacc.P4am = moh.StrToDouble(txtamP4.Text);
                        myacc.P5am = moh.StrToDouble(txtamP5.Text);
                        myacc.P6am = moh.StrToDouble(txtamP6.Text);
                        myacc.P1m = moh.StrToShort(txtMP1.Text);
                        myacc.P2m = moh.StrToShort(txtMP2.Text);
                        myacc.P3m = moh.StrToShort(txtMP3.Text);
                        myacc.P4m = moh.StrToShort(txtMP4.Text);
                        myacc.P5m = moh.StrToShort(txtMP5.Text);
                        myacc.P6m = moh.StrToShort(txtMP6.Text);
                        myacc.P1LDate = txtP1LDate.Text;
                        myacc.P2LDate = txtP2LDate.Text;
                        myacc.P3LDate = txtP3LDate.Text;
                        myacc.P4LDate = txtP4LDate.Text;
                        myacc.P5LDate = txtP5LDate.Text;
                        myacc.P6LDate = txtP6LDate.Text;
                        if (myacc.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            updatecache();
                            ChkAccAccount();
                            LoadDriversData();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم حفظ البيانات بنجاح";
                            BtnClear_Click(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ اثناء حفظ البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الشاحنة مكرر";
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

        public void ChkAccAccount()
        {
            string FCode = "1101" + moh.MakeMask(ddlCarsType.SelectedValue, 2);
            Acc myAcc = new Acc();
            myAcc.Branch = short.Parse(Session["Branch"].ToString());
            myAcc.Code = FCode + txtCode.Text.Substring(2, 3);
            if (!myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            {
                myAcc = new Acc();
                myAcc.Branch = short.Parse(Session["Branch"].ToString());
                myAcc.Code = FCode + txtCode.Text.Substring(2, 3);
                myAcc.FCode = FCode;
                myAcc.MCode = txtCode.Text.Substring(2, 3);
                myAcc.FLevel = 5;
                myAcc.Name1 = txtCarType.Text + " " + txtPlateNo.Text;
                myAcc.Name2 = txtCarType2.Text;
                myAcc.LastLevel = true;
                myAcc.FType = "1";
                myAcc.SType = "1";
                myAcc.Stype1 = "1";
                myAcc.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            }
            else
            {
                double? x = GetPer();
                if (x != -1)
                {
                    myAcc.DepPer = x;
                    myAcc.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }
            }
        }

        public double GetPer()
        {
            switch (int.Parse(ddlCarsType.SelectedValue)) 
            {
                case 1: return (ChkStatus.Checked ? 9 : txtPLoc.Text.Contains("مباع") ? 0 : 4.5);
                case 2: return (ChkStatus.Checked ? 5 : txtPLoc.Text.Contains("مباع") ? 0 : 2.5);
                case 3: return (ChkStatus.Checked ? 9 : txtPLoc.Text.Contains("مباع") ? 0 : 4.5);
                case 4: return (ChkStatus.Checked ? 5 : txtPLoc.Text.Contains("مباع") ? 0 : 2.5);
                case 5: return (ChkStatus.Checked ? 5 : txtPLoc.Text.Contains("مباع") ? 0 : 2.5);
                case 6: return (ChkStatus.Checked ? 15 : txtPLoc.Text.Contains("مباع") ? 0 : 7.5);
                case 7: return (ChkStatus.Checked ? 25 : txtPLoc.Text.Contains("مباع") ? 0 : 12.5);
                case 23: return (ChkStatus.Checked ? 0 : txtPLoc.Text.Contains("مباع") ? 0 : 0);
                case 24: return (ChkStatus.Checked ? 4.5 : txtPLoc.Text.Contains("مباع") ? 0 : 4.5);
                case 28: return (ChkStatus.Checked ? 10 : txtPLoc.Text.Contains("مباع") ? 0 : 10);
                case 29: return (ChkStatus.Checked ? 0 : txtPLoc.Text.Contains("مباع") ? 0 : 0);
                case 27: return (ChkStatus.Checked ? 10 : txtPLoc.Text.Contains("مباع") ? 0 : 5);
                case 37: return (ChkStatus.Checked ? 9 : txtPLoc.Text.Contains("مباع") ? 0 : 4.5);
                case 34: return (ChkStatus.Checked ? 3 : txtPLoc.Text.Contains("مباع") ? 0 : 3);
                case 35: return (ChkStatus.Checked ? 3 : txtPLoc.Text.Contains("مباع") ? 0 : 3);
                case 32: return (ChkStatus.Checked ? 20 : txtPLoc.Text.Contains("مباع") ? 0 : 10);
                case 33: return (ChkStatus.Checked ? 25 : txtPLoc.Text.Contains("مباع") ? 0 : 12.5);
                default: return -1;
            }
        }

        protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtCode.Text != "")
                {
                    txtCode.Text = moh.MakeMask(txtCode.Text, 5);
                    //if (ddlCarsType.SelectedValue != txtCode.Text.Substring(0, 2))
                    //{
                    //    ddlCarsType.SelectedValue = int.Parse(txtCode.Text.Substring(0, 2)).ToString();
                    //    ddlCarsType_SelectedIndexChanged(sender, e);
                    //}
                    Cars myacc = new Cars();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myacc.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myacc.CarsType = int.Parse(ddlCarsType.SelectedValue);
                    myacc.Code = txtCode.Text;
                    myacc = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                             where sitm.Code == myacc.Code
                             select sitm).FirstOrDefault();
                    if (myacc != null)
                    {
                        EditMode();
                        txtCarType.Text = myacc.CarType;
                        txtCarType2.Text = myacc.CarType2;
                        txtChDezelDate.Text = myacc.ChDezelDate;
                        txtChDezelKMeter.Text = myacc.ChDezelKMeter.ToString();
                        txtChOilDate.Text = myacc.ChOilDate;
                        txtChOilKMeter.Text = myacc.ChOilKMeter.ToString();
                        txtPlateNo.Text = myacc.PlateNo;
                        txtKMeter.Text = myacc.KMeter.ToString();
                        if (ddlDrivers.Items.FindByValue(myacc.DriverCode) != null) ddlDrivers.SelectedValue = myacc.DriverCode;
                        else ddlDrivers.SelectedValue = "-1";
                        txtTaraz.Text = myacc.Taraz;
                        txtModel.Text = myacc.Model;
                        if (ddlFType2.Items.FindByValue(myacc.FType2) != null) ddlFType2.SelectedValue = myacc.FType2;
                        else ddlFType2.SelectedValue = "-1";
                        txtWorkShopCode.Text = myacc.WorkShopCode;
                        if (ddlFixAssetCode.Items.FindByValue(myacc.FixAssetCode) != null) ddlFixAssetCode.SelectedValue = myacc.FixAssetCode;
                        else ddlFixAssetCode.SelectedValue = "-1";
                        if (ddlFollowType.Items.FindByValue(myacc.FollowType.ToString()) != null) ddlFollowType.SelectedValue = myacc.FollowType.ToString();
                        else ddlFollowType.SelectedValue = "-1";
                        if (ddlFollow2.Items.FindByValue(myacc.Follow2.ToString()) != null) ddlFollow2.SelectedValue = myacc.Follow2.ToString();
                        else ddlFollow2.SelectedValue = "-1";
                        ChkStatus.Checked = (bool)myacc.Status;
                        txtPHDate1.Text = myacc.PHDate1;
                        txtPHDate2.Text = myacc.PHDate2;
                        txtPHDate3.Text = myacc.PHDate3;
                        txtPHDate4.Text = myacc.PHDate4;
                        txtPHDate5.Text = myacc.PHDate5;
                        txtPLoc1.Text = myacc.PLoc1;
                        txtPLoc2.Text = myacc.PLoc2;
                        txtPLoc3.Text = myacc.PLoc3;
                        txtPLoc4.Text = myacc.PLoc4;
                        txtPLoc5.Text = myacc.PLoc5;
                        txtPLoc.Text = myacc.PLoc;
                        txtBrand.Text = myacc.Brand;
                        txtCarStruct.Text = myacc.CarStruct;
                        txtCarSerial.Text = myacc.CarSerial;

                        txtamP1.Text = myacc.P1am == 0 ? "" : myacc.P1am.ToString();
                        txtamP2.Text = myacc.P2am == 0 ? "" : myacc.P2am.ToString();
                        txtamP3.Text = myacc.P3am == 0 ? "" : myacc.P3am.ToString();
                        txtamP4.Text = myacc.P4am == 0 ? "" : myacc.P4am.ToString();
                        txtamP5.Text = myacc.P5am == 0 ? "" : myacc.P5am.ToString();
                        txtamP6.Text = myacc.P6am == 0 ? "" : myacc.P6am.ToString();

                        txtMP1.Text = myacc.P1m == 0 ? "" : myacc.P1m.ToString();
                        txtMP2.Text = myacc.P2m == 0 ? "" : myacc.P2m.ToString();
                        txtMP3.Text = myacc.P3m == 0 ? "" : myacc.P3m.ToString();
                        txtMP4.Text = myacc.P4m == 0 ? "" : myacc.P4m.ToString();
                        txtMP5.Text = myacc.P5m == 0 ? "" : myacc.P5m.ToString();
                        txtMP6.Text = myacc.P6m == 0 ? "" : myacc.P6m.ToString();

                        txtP1LDate.Text = myacc.P1LDate;
                        txtP2LDate.Text = myacc.P2LDate;
                        txtP3LDate.Text = myacc.P3LDate;
                        txtP4LDate.Text = myacc.P4LDate;
                        txtP5LDate.Text = myacc.P5LDate;
                        txtP6LDate.Text = myacc.P6LDate;
                        LoadAttachData();
                        LoadManData();
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الشاحنة غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم الشاحنة";
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
                    txtCode.Text = moh.MakeMask(txtCode.Text, 5);
                    Cars myacc = new Cars();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myacc.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myacc.CarsType = int.Parse(ddlCarsType.SelectedValue);
                    myacc.Code = txtCode.Text;
                    myacc = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                             where sitm.Code == myacc.Code
                             select sitm).FirstOrDefault();
                    if (myacc != null)
                    {
                        if (txtWorkShopCode.Text.Trim() != "")
                        {
                            myacc = new Cars();
                            myacc.Branch = short.Parse(Session["Branch"].ToString());
                            myacc.WorkShopCode = txtWorkShopCode.Text.Trim();
                            myacc = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                     where sitm.WorkShopCode == myacc.WorkShopCode
                                     select sitm).FirstOrDefault();
                            if (myacc != null && myacc.Code != txtCode.Text)
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "كود الورشة مكرر";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }
                        myacc.CarType = txtCarType.Text;
                        myacc.CarType2 = txtCarType2.Text;
                        myacc.ChDezelDate = txtChDezelDate.Text;
                        myacc.ChDezelKMeter = int.Parse(txtChDezelKMeter.Text);
                        myacc.ChOilDate = txtChOilDate.Text;
                        myacc.ChOilKMeter = int.Parse(txtChOilKMeter.Text);
                        myacc.PlateNo = txtPlateNo.Text;
                        myacc.KMeter = int.Parse(txtKMeter.Text);
                        myacc.DriverCode = ddlDrivers.SelectedValue;
                        myacc.Taraz = txtTaraz.Text;
                        myacc.Model = txtModel.Text;
                        myacc.FType2 = ddlFType2.SelectedValue;
                        myacc.WorkShopCode = txtWorkShopCode.Text;
                        myacc.FixAssetCode = ddlFixAssetCode.SelectedValue;
                        myacc.FollowType = int.Parse(ddlFollowType.SelectedValue);
                        myacc.Follow2 = int.Parse(ddlFollow2.SelectedValue);
                        myacc.Status = ChkStatus.Checked;
                        myacc.PHDate1 = txtPHDate1.Text;
                        myacc.PHDate2 = txtPHDate2.Text;
                        myacc.PHDate3 = txtPHDate3.Text;
                        myacc.PHDate4 = txtPHDate4.Text;
                        myacc.PHDate5 = txtPHDate5.Text;
                        myacc.PLoc1 = txtPLoc1.Text;
                        myacc.PLoc2 = txtPLoc2.Text;
                        myacc.PLoc3 = txtPLoc3.Text;
                        myacc.PLoc4 = txtPLoc4.Text;
                        myacc.PLoc5 = txtPLoc5.Text;
                        myacc.PLoc = txtPLoc.Text;
                        myacc.Brand = txtBrand.Text;
                        myacc.CarStruct = txtCarStruct.Text;
                        myacc.CarSerial = txtCarSerial.Text;
                        myacc.P1am = moh.StrToDouble(txtamP1.Text);
                        myacc.P2am = moh.StrToDouble(txtamP2.Text);
                        myacc.P3am = moh.StrToDouble(txtamP3.Text);
                        myacc.P4am = moh.StrToDouble(txtamP4.Text);
                        myacc.P5am = moh.StrToDouble(txtamP5.Text);
                        myacc.P6am = moh.StrToDouble(txtamP6.Text);
                        myacc.P1m = moh.StrToShort(txtMP1.Text);
                        myacc.P2m = moh.StrToShort(txtMP2.Text);
                        myacc.P3m = moh.StrToShort(txtMP3.Text);
                        myacc.P4m = moh.StrToShort(txtMP4.Text);
                        myacc.P5m = moh.StrToShort(txtMP5.Text);
                        myacc.P6m = moh.StrToShort(txtMP6.Text);
                        myacc.P1LDate = txtP1LDate.Text;
                        myacc.P2LDate = txtP2LDate.Text;
                        myacc.P3LDate = txtP3LDate.Text;
                        myacc.P4LDate = txtP4LDate.Text;
                        myacc.P5LDate = txtP5LDate.Text;
                        myacc.P6LDate = txtP6LDate.Text;
                        if (myacc.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            updatecache();
                            ChkAccAccount();
                            LoadDriversData();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم حفظ البيانات بنجاح";
                            BtnClear_Click(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ اثناء حفظ البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الشاحنة غير معرف من قبل";
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

        protected void BtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtCode.Text != "")
                {
                    txtCode.Text = moh.MakeMask(txtCode.Text, 5);
                    Cars myacc = new Cars();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myacc.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myacc.CarsType = int.Parse(ddlCarsType.SelectedValue);
                    myacc.Code = txtCode.Text;
                    myacc = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                             where sitm.Code == myacc.Code
                             select sitm).FirstOrDefault();
                    if (myacc != null)
                    {
                        // Check for Delete Clients
                        if (myacc.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            updatecache();
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());  //moh.Nows().ToShortTimeString();
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.Description = "الغاء بيانات الشاحنة " + myacc.PlateNo;
                            UserTran.FormAction = "الغاء";
                            UserTran.FormName = "الشاحنات";
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            LoadDriversData();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقم تم الغاء بيانات الشاحنة بنجاح";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ أثناء الغاء البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم الشاحنة";
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

        protected void ddlCarsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDriversData();
            BtnClear_Click(sender, null);

            if (ddlCarsType.SelectedValue != "7")
            {
                Drivers myDrive = new Drivers();
                myDrive.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                ddlDrivers.DataTextField = "Name1";
                ddlDrivers.DataValueField = "Code";
                ddlDrivers.DataSource = (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()]);
                ddlDrivers.DataBind();
                ddlDrivers.Items.Insert(0, new ListItem("--- أختار السائق ---", "-1", true));
            }
            else
            {
                Acc myacc = new Acc();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["LastACC" + Session["CNN2"].ToString()] == null) Cache.Insert("LastACC" + Session["CNN2"].ToString(), myacc.GetLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                ddlDrivers.DataTextField = "Name1";
                ddlDrivers.DataValueField = "Code";
                ddlDrivers.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                         where itm.FCode.StartsWith("1205")
                                         select itm).ToList();
                ddlDrivers.DataBind();
                ddlDrivers.Items.Insert(0, new ListItem("--- أختار الموظف ---", "-1", true));
            }
            ddlDrivers.SelectedIndex = 0;
        }

        protected void ddlFollowType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFollowType.SelectedIndex > 0)
            {
                Cars myacc = new Cars();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myacc.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myacc.CarsType = int.Parse(ddlFollowType.SelectedValue);
                ddlFollow2.DataTextField = "Name";
                ddlFollow2.DataValueField = "Code";
                ddlFollow2.DataSource = (from itm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                         where itm.CarsType == myacc.CarsType && (bool)itm.Status
                                         select itm).ToList();
                ddlFollow2.DataBind();
                ddlFollow2.Items.Insert(0, new ListItem("--- أختار الملحق ---", "-1", true));
            }
            else
            {
                ddlFollow2.Items.Clear();
                ddlFollow2.Items.Insert(0, new ListItem("--- أختار الملحق ---", "-1", true));
            }
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
                        myArch.LocNumber = 0;
                        myArch.Number = int.Parse(txtCode.Text);
                        myArch.DocType = 999;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = 0;
                        myArch.Number = int.Parse(txtCode.Text);
                        myArch.DocType = 999;
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

        protected void grdAttach_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string FNo = grdAttach.DataKeys[e.RowIndex]["FNo"].ToString();
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(Session["Branch"].ToString());
                myArch.LocNumber = 0;
                myArch.Number = int.Parse(txtCode.Text);
                myArch.DocType = 999;
                myArch.FNo = short.Parse(FNo);
                myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

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
            if (txtCode.Text != "")
            {
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(Session["Branch"].ToString());
                myArch.LocNumber = 0;
                myArch.Number = int.Parse(txtCode.Text);
                myArch.DocType = 999;
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

        public void LoadManData()
        {
            if (txtCode.Text != "")
            {
                CarRepair myRepair = new CarRepair();
                myRepair.CarNo = txtCode.Text;
                grdMan.DataSource = myRepair.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                grdMan.DataBind();
            }
        }

        public void updatecache()
        {
          if (Cache["CarAlert" + Session["CNN2"].ToString()] != null) Cache.Remove("CarAlert" + Session["CNN2"].ToString());
          if (Cache["CarAlert2" + Session["CNN2"].ToString()] != null) Cache.Remove("CarAlert2" + Session["CNN2"].ToString());
          if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Remove("Cars" + Session["CNN2"].ToString());

          Cars myCar = new Cars();
          myCar.Branch = 1;
          if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
        }
    }
}