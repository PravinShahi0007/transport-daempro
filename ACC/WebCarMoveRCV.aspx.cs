using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;
using iTextSharp.text.pdf;
using System.IO;
using System.Configuration;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class WebCarMoveRCV : System.Web.UI.Page
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
        public List<myInv2> MyOver
        {
            get
            {
                if (ViewState["MyOver"] == null)
                {
                    ViewState["MyOver"] = new List<myInv2>();
                }
                return (List<myInv2>)ViewState["MyOver"];
            }
            set { ViewState["MyOver"] = value; }
        }

        public void EditMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            //BtnPrint.Visible = true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass225;
            BtnEdit.Visible = true && (Request.QueryString["Support"] != null ||  (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass222);
            BtnNew.Visible = false;
            BtnDelete.Visible = true && Request.QueryString["Support"] == null && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass223;
            if (Request.QueryString["Flag"] != null)
            {
                if (Request.QueryString["Flag"].ToString() == "0")
                {
                    if (Request.QueryString["Support"] != null || !(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass40)
                    {
                        BtnEdit.Visible = false;
                        BtnDelete.Visible = false;
                        BtnClear.Visible = false;
                    }
                }
            }

            if (BtnEdit.Visible || BtnDelete.Visible)
            {
                txtReason.Visible = true;
                ValReason.Enabled = true;
                lblReason.Visible = true;
            }

            if (Request.QueryString["Support"] != null || !(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass222 || !BtnEdit.Visible) ControlsOnOff(false);
        }

        public void NewMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            //BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass221;
            BtnDelete.Visible = false;

            txtReason.Visible = false;
            ValReason.Enabled = false;
            lblReason.Visible = false;

            if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass222 || !BtnEdit.Visible) ControlsOnOff(true);
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
                    this.Page.Header.Title = "بيان الوصول";
                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "الرئيسية", "اختيار", "اختيار بيان الوصول", "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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
                    if (Request.QueryString["StoreNo"] != null) StoreNo = Request.QueryString["StoreNo"].ToString();
                    else
                    {
                        if (Session["StoreNo"] == null) Session["StoreNo"] = 1;
                        StoreNo = Session["StoreNo"].ToString();
                    }
                    lblBranch2.Text = "/" + short.Parse(AreaNo).ToString();

                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    vRoleName = moh.GetCurrentRole(AreaNo,(from useritm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                                          where useritm.UserName == Session["CurrentUser"].ToString()
                                                          select useritm).FirstOrDefault());
                    if (Session[vRoleName] == null)
                    {
                        Response.Redirect("WebNotPrev.aspx", false);
                        return;
                    }

                    if (Session[vRoleName] != null && Request.QueryString["Support"] == null)
                    {
                        BtnNew.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass221;
                        BtnEdit.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass222;
                        BtnDelete.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass223;
                        BtnSearch.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass224;
                        BtnFind.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass224;
                        //BtnPrint.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass225;
                    }

                    if (Request.QueryString["FNum"] != null)
                    {
                        if (Request.QueryString["Flag"] != null)
                        {
                            if (Request.QueryString["Flag"].ToString() == "0")
                            {
                                if (Session[vRoleName] != null && Request.QueryString["Support"] == null && !(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass40)
                                {
                                    BtnEdit.Visible = false;
                                    BtnDelete.Visible = false;
                                    BtnClear.Visible = false;
                                    ((HtmlGenericControl)this.Master.FindControl("menu")).Visible = false;
                                }
                            }
                        }
                        txtSearch.Text = Request.QueryString["FNum"].ToString();
                        BtnSearch_Click(sender, null);
                    }
                    else BtnClear_Click(sender, null);
                    if (Request.QueryString["CarMove"] != null)
                    {
                        txtCarMove.Text = Request.QueryString["CarMove"].ToString();
                        BtnFind2_Click(sender, null);
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

        protected void BtnClear_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                NewMode();
                MyOver.Clear();
                txtSearch.Text = "";
                txtReason.Text = "";
                txtVouNo.Text = "";
                txtRemark.Text = "";
                txtCarMove.Text = "";
                lblCap.Text = "";
                lblFrom.Text = "";
                lblTo.Text = "";
                lblCar.Text = "";
                lblCar.ToolTip = "";
                lblDriver.Text = "";
                lblFType2.Text = "";
                CarAlert.Visible = false;
                LblFTime.Text = String.Format("{0:HH:mm:ss}", moh.Nows());  //moh.Nows().ToShortTimeString();
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                if (sender != null)
                {
                    CarMoveRCV myJv = new CarMoveRCV();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.LocNumber = short.Parse(AreaNo);
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
                grdStatus.DataSource = null;
                LoadVouData();
                LoadAttachData();
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

        public void ControlsOnOff(bool State)
        {
            txtRemark.ReadOnly = !State;
            txtCarMove.ReadOnly = !State;
            txtVouDate.ReadOnly = !State;
            //grdAttach.Enabled = State;
            foreach (GridViewRow itm in grdAttach.Rows)
            {
                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                if (BtnDelete != null) BtnDelete.Visible = State;
            }
            grdCodes.Enabled = State;
            FileUpload1.Enabled = State;
            BtnAttach.Enabled = State;
            txtReason.ReadOnly = !State;
        }

        protected void LoadVouData()
        {
            try
            {
                bool vnew = false;
                if (txtCarMove.Text != "")
                {
                    if (txtCarMove.Text.Split('/').Count() < 2)
                    {
                        txtCarMove.Text = short.Parse(AreaNo).ToString() + "/" + txtCarMove.Text;
                    }
                    txtCarMove.Text = txtCarMove.Text.Trim();
                    txtCarMove.Text = int.Parse(txtCarMove.Text.Split('/')[0]).ToString().Trim() + "/" + int.Parse(txtCarMove.Text.Split('/')[1]).ToString().Trim();

                    CarMoveRCV vCMR = new CarMoveRCV();
                    vCMR.Branch = short.Parse(Session["Branch"].ToString());
                    vCMR.CarMove = txtCarMove.Text;
                    vCMR = vCMR.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (vCMR == null) vnew = true;
                    else if (vCMR.Number != int.Parse(txtVouNo.Text) || vCMR.LocNumber != short.Parse(AreaNo)) 
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم بيان الترحيل تم ادراجة في بيان الوصول رقم " + vCMR.LocNumber.ToString() + '/' + vCMR.Number.ToString();
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                    List<Cities> lc = new List<Cities>();
                    Cities mc = new Cities();
                    mc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), mc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    lc = mc.GetMySites(AreaNo, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()]), (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()]));

                    CarMove myInv = new CarMove();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = moh.MakeMask(txtCarMove.Text.Split('/')[0], 5);
                    myInv.Number = int.Parse(txtCarMove.Text.Split('/')[1]);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "بيان الترحيل غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                    else if (vnew && !(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass226 && !CheckSite(myInv.ToLoc,lc))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "جهة الوصول في بيان الترجيل تختلف عن موقعك";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    MyOver = myInv.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (vnew)
                    {
                        foreach (myInv2 itm in MyOver)
                        {
                            if (!CheckSite(itm.Destination, lc)) itm.Transit = true;
                            else itm.Transit = false;
                            itm.SendStatus = "0";
                        }
                    }

                    if (MyOver != null && MyOver.Count > 0)
                    {
                        foreach (myInv2 itm in MyOver)
                        {
                            CarRcv myCar20 = new CarRcv();
                            myCar20.Branch = short.Parse(Session["Branch"].ToString());
                            myCar20.InvFNo = (short)itm.InvoiceFNo;
                            myCar20.InvNo = itm.VouNo2;
                            myCar20 = myCar20.GetByInvFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myCar20 != null)
                            {
                                itm.RcvNo2 = myCar20.LocNumber.ToString() + "/" + myCar20.Number.ToString();
                            }
                            else itm.RcvNo2 = "";
                        }
                    }

                    grdCodes.DataSource = MyOver;
                    grdStatus.DataSource = MyOver;
                    grdStatus.DataBind();


                    lblFrom.Text = "";
                    Cities myCity = new Cities();
                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));                    
                    myCity.Code = myInv.FromLoc;
                    myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                              where sitm.Code == myCity.Code
                              select sitm).FirstOrDefault();
                    if (myCity != null) lblFrom.Text = myCity.Name1;


                    lblTo.Text = "";
                    myCity = new Cities();
                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                    myCity.Code = myInv.ToLoc;
                    myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                              where sitm.Code == myCity.Code
                              select sitm).FirstOrDefault();
                    if (myCity != null) lblTo.Text = myCity.Name1;


                    lblCar.Text = "";
                    lblCar.ToolTip = "";
                    lblFType2.Text = "";
                    lblCap.Text = "";
                    Cars myCar = new Cars();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myCar.Code = myInv.CarCode;
                    myCar = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                             where sitm.Code == myCar.Code
                             select sitm).FirstOrDefault();
                    if (myCar != null)
                    {
                        lblCar.ToolTip = myCar.Code;
                        lblCar.Text = myCar.PlateNo;
                        if (myCar.FType2 != "-1")
                        {
                            Codes myCode = new Codes();
                            myCode.Branch = short.Parse(Session["Branch"].ToString());
                            myCode.Ftype = 30;
                            myCode.Code = int.Parse(myCar.FType2);
                            if (Cache["LastCodes" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCodes" + Session["CNN2"].ToString(), myCode.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                            myCode = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                      where itm.Ftype == myCode.Ftype && itm.Code == myCode.Code
                                      select itm).FirstOrDefault();
                            if (myCode != null)
                            {
                                lblCap.Text = myCode.FType2;
                                lblFType2.Text = myCode.Name1;
                            }
                        }
                        try
                        {
                            DateTime dt = HDate.Ch_Date(HDate.getNow());
                            List<Cars> lcar = new List<Cars>();

                            lcar.Add(new Cars
                            {
                                WorkShopCode = "1",
                                Code = myCar.Code,
                                PlateNo = myCar.PlateNo,
                                PHDate1 = moh.GetPic(1, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString),
                                PHDate2 = moh.GetPic(2, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString),
                                PHDate3 = moh.GetPic(3, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString),
                                PHDate4 = moh.GetPic(4, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString),
                                PLoc1 = myCar.PLoc1,
                                PLoc2 = myCar.PLoc2,
                                PLoc3 = myCar.PLoc3,
                                PLoc4 = myCar.PLoc4,
                                strDate1 = (string.IsNullOrEmpty(myCar.PHDate1) ? "المستند غير مدرج" :
                                            HDate.Ch_Date(myCar.PHDate1) <= dt ? @"<a href='" + moh.GetPic(1, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + "منتهي من " + dt.Subtract(HDate.Ch_Date(myCar.PHDate1)).Days.ToString() + " يوم" + @"</a>" :
                                            HDate.Ch_Date(myCar.PHDate1).AddDays(-30) <= dt ? "ينتهي خلال " + HDate.Ch_Date(myCar.PHDate1).Subtract(dt).Days.ToString() + " يوم" + @"</a>" : @"<a href='" + moh.GetPic(1, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>"),
                                strDate2 = (string.IsNullOrEmpty(myCar.PHDate2) ? "المستند غير مدرج" :
                                            HDate.Ch_Date(myCar.PHDate2) <= dt ? @"<a href='" + moh.GetPic(2, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + "منتهي من " + dt.Subtract(HDate.Ch_Date(myCar.PHDate2)).Days.ToString() + " يوم" + @"</a>" :
                                            HDate.Ch_Date(myCar.PHDate2).AddDays(-30) <= dt ? "ينتهي خلال " + HDate.Ch_Date(myCar.PHDate2).Subtract(dt).Days.ToString() + " يوم" + @"</a>" : @"<a href='" + moh.GetPic(2, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>"),
                                strDate3 = (string.IsNullOrEmpty(myCar.PHDate3) ? "المستند غير مدرج" :
                                            HDate.Ch_Date(myCar.PHDate3) <= dt ? @"<a href='" + moh.GetPic(3, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + "منتهي من " + dt.Subtract(DateTime.Parse(myCar.PHDate3)).Days.ToString() + " يوم" + @"</a>" :
                                            HDate.Ch_Date(myCar.PHDate3).AddDays(-30) <= dt ? "ينتهي خلال " + HDate.Ch_Date(myCar.PHDate3).Subtract(dt).Days.ToString() + " يوم" + @"</a>" : @"<a href='" + moh.GetPic(3, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>"),
                                strDate4 = (string.IsNullOrEmpty(myCar.PHDate4) ? "المستند غير مدرج" :
                                            HDate.Ch_Date(myCar.PHDate4) <= dt ? @"<a href='" + moh.GetPic(4, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + "منتهي من " + dt.Subtract(DateTime.Parse(myCar.PHDate4)).Days.ToString() + " يوم" + @"</a>" :
                                            HDate.Ch_Date(myCar.PHDate4).AddDays(-30) <= dt ? "ينتهي خلال " + HDate.Ch_Date(myCar.PHDate4).Subtract(dt).Days.ToString() + " يوم" + @"</a>" : @"<a href='" + moh.GetPic(4, myCar.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>")
                            });
                            grdCarAlert.DataSource = lcar;
                            grdCarAlert.DataBind();
                            CarAlert.Visible = true;
                        }
                        catch { }
                    }


                    lblDriver.Text = "";
                    Drivers myDrive = new Drivers();
                    myDrive.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myDrive.Code = myInv.DriverCode;
                    myDrive = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                               where sitm.Code == myDrive.Code
                               select sitm).FirstOrDefault();
                    if (myDrive != null) lblDriver.Text = myDrive.Name1;


                }
                else grdCodes.DataSource = null;
                grdCodes.DataBind();


                /*
                if (vnew)
                {
                    foreach (GridViewRow gvr in grdCodes.Rows)
                    {
                        CheckBox ChkTrans = gvr.FindControl("ChkTrans") as CheckBox;
                        ChkTrans.Checked = false;
                    }
                }
                 */
            }
            catch (Exception ex)
            {
                if (ConfigurationManager.AppSettings["ExitOnError"].ToString() == "100000")
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

        public bool CheckCarJobWork(string CarNo)
        {
            JobWork jw = new JobWork();
            jw.CarNo = CarNo;
            jw = jw.GetOpenCarNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (jw != null)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يوجد للشاحنة امر تشغيل مفتوح حاليا في الصيانة برقم " + jw.VouNo.ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return true;
            }
            else return false;
        }

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    {
                        if (DateTime.Parse(txtVouDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                    }

                    if (CheckCarJobWork(lblCar.ToolTip)) return;

                    BtnNew.Enabled = false;
                    CarMoveRCV myJv = new CarMoveRCV();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.LocNumber = short.Parse(AreaNo);
                    myJv.Number = int.Parse(txtVouNo.Text);
                    myJv = myJv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    if (myJv != null)
                    {
                        if (myJv.UserName == txtUserName.ToolTip)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم بيان الوصول مكرر";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                        else
                        {
                            myJv = new CarMoveRCV();
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.LocNumber = short.Parse(AreaNo);
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
                    }

                    myJv = new CarMoveRCV();
                    Saveall(myJv);
                    if (myJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        Sendsms();

                        CarMove myInv = new CarMove();
                        myInv.Branch = short.Parse(Session["Branch"].ToString());
                        myInv.VouLoc = moh.MakeMask(txtCarMove.Text.Split('/')[0], 5);
                        myInv.Number = int.Parse(txtCarMove.Text.Split('/')[1]);
                        myInv.Status = 2;
                        myInv.UpdateStatue(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان الوصول", "اضافة", "اضافة بيان الوصول رقم " + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                        if (HttpRuntime.Cache["OverTrack_" + AreaNo + Session["CNN2"].ToString()] != null)
                        {
                            Cache.Remove("OverTrack_" + AreaNo + Session["CNN2"].ToString());
                            Cache.Remove("OverTrack1_" + AreaNo + Session["CNN2"].ToString());
                            Cache.Remove("OverTrack2_" + AreaNo + Session["CNN2"].ToString());
                        }
                        if (HttpRuntime.Cache["OverCarMove_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMove_" + AreaNo + Session["CNN2"].ToString());
                        if (HttpRuntime.Cache["OverCarMoveTrip_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMoveTrip_" + AreaNo + Session["CNN2"].ToString());
                        if (HttpRuntime.Cache["OverCarMoveChart_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMoveChart_" + AreaNo + Session["CNN2"].ToString());
                        if (HttpRuntime.Cache["OverCarsIn_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarsIn_" + AreaNo + Session["CNN2"].ToString());
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        BtnClear_Click(sender, e);
                        BtnNew.Enabled = true;
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        BtnNew.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                BtnNew.Enabled = true;
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

        public void Sendsms()
        {
            try
            {
                if (txtCarMove.Text != "")
                {
                    var strmobile = new string[] { "", "", "", "" , "" , "" , "" , "" , "" , "" };
                    CarMove myInv = new CarMove();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    if (txtCarMove.Text.Split('/').Count() <2)
                    {
                        txtCarMove.Text =  short.Parse(AreaNo).ToString() + "/" + txtCarMove.Text;
                    }
                    myInv.VouLoc = moh.MakeMask(txtCarMove.Text.Split('/')[0], 5);
                    myInv.Number = int.Parse(txtCarMove.Text.Split('/')[1]);
                    int i = 0;
                    try
                    {
                        foreach (myInv2 inv in myInv.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {                            
                            if (!(bool)inv.Transit && inv.RecMobileNo.Trim()!="")
                            {
                                if (inv.ToLoc == inv.Destination)
                                {
                                    bool vfound = false;
                                    for (int r = 0; r < 10; r++)
                                    {
                                        if (strmobile[r] == inv.RecMobileNo)
                                        {
                                            vfound = true;
                                            break;
                                        }
                                    }
                                    if (!vfound)
                                    {
                                        strmobile[i] = inv.RecMobileNo;
                                        i++;
                                    }
                                }
                            }
                        }

                        string myStatus = "0";
                        for (int r = 0; r < 10; r++)
                        {
                            if (strmobile[r] != "")
                            {
                                try
                                {
                                    //myStatus = sms.SendMessage("شكرا لتعاملك مع ناقلات البرية ارساليتك وصلت للاستفسار اتصل ب 5283100(011) أو 920028833", "naqelat", "966" + strmobile[r].Substring(1, 9));
                                    myStatus = sms.SendMessage("شكرا لتعاملك مع ناقلات البرية شحنتك وصلت للاستفسار اتصل ب0115283100 أو 920028833", "naqelat", "966" + strmobile[r].Substring(1, 9));
                                    foreach (myInv2 itm in MyOver)
                                    {
                                        if (itm.MobileNo2 == strmobile[r] && itm.Flag == "")
                                        {
                                            itm.SendStatus = myStatus;
                                            InvDetails myInvDetails = new InvDetails();
                                            myInvDetails.Branch = itm.Branch;
                                            myInvDetails.VouLoc = itm.InvoiceVouLoc;
                                            myInvDetails.VouNo = itm.VouNo;
                                            myInvDetails.FNo = (short)itm.InvoiceFNo;
                                            myInvDetails.Status = myStatus;
                                            myInvDetails.SetStatus(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        }
                                    }
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                    }
                    catch(Exception)
                    {                    
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

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    {
                        if (DateTime.Parse(txtVouDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                    }

                    CarMoveRCV myJv = new CarMoveRCV();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.LocNumber = short.Parse(AreaNo);
                    myJv.Number = int.Parse(txtVouNo.Text);
                    myJv = myJv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myJv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم بيان الوصول غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        Saveall(myJv);
                        if (myJv.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            CarMove myInv = new CarMove();
                            myInv.Branch = short.Parse(Session["Branch"].ToString());
                            myInv.VouLoc = moh.MakeMask(txtCarMove.Text.Split('/')[0], 5);
                            myInv.Number = int.Parse(txtCarMove.Text.Split('/')[1]);
                            myInv.Status = 2;
                            myInv.UpdateStatue(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";

                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان الوصول", "تعديل", "تعديل بيان الوصول رقم " + lblBranch2.Text + "/" + txtVouNo.Text, txtReason.Text, IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            txtReason.Text = "";

                            if (HttpRuntime.Cache["OverTrack_" + AreaNo + Session["CNN2"].ToString()] != null)
                            {
                                Cache.Remove("OverTrack_" + AreaNo + Session["CNN2"].ToString());
                                Cache.Remove("OverTrack1_" + AreaNo + Session["CNN2"].ToString());
                                Cache.Remove("OverTrack2_" + AreaNo + Session["CNN2"].ToString());
                            }
                            if (HttpRuntime.Cache["OverCarMove_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMove_" + AreaNo + Session["CNN2"].ToString());
                            if (HttpRuntime.Cache["OverCarMoveTrip_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMoveTrip_" + AreaNo + Session["CNN2"].ToString());
                            if (HttpRuntime.Cache["OverCarMoveChart_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMoveChart_" + AreaNo + Session["CNN2"].ToString());
                            if (HttpRuntime.Cache["OverCarsIn_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarsIn_" + AreaNo + Session["CNN2"].ToString());
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ أثناء تعديل البيانات ... حاول مرة أخرى";
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
                    Response.Redirect("GeneralServerError.aspx", false);
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
                    if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    {
                        if (DateTime.Parse(txtVouDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                    }

                    CarMoveRCV myJv = new CarMoveRCV();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.LocNumber = short.Parse(AreaNo);
                    myJv.Number = int.Parse(txtVouNo.Text);
                    myJv = myJv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myJv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم بيان الوصول غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        CarRcv vCarRcv = new CarRcv();
                        vCarRcv.Branch = short.Parse(Session["Branch"].ToString());
                        vCarRcv.LocNumber = short.Parse(AreaNo);
                        vCarRcv.InvNo = short.Parse(AreaNo).ToString() + "/" + int.Parse(txtVouNo.Text); 
                        vCarRcv = vCarRcv.GetByInv(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                        if (vCarRcv != null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لا يمكن الغاء بيان الوصول المرتبط ببيان التسليم رقم " + vCarRcv.LocNumber.ToString() + "/" + vCarRcv.Number.ToString();
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }


                        myJv = new CarMoveRCV();
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.LocNumber = short.Parse(AreaNo);
                        myJv.Number = int.Parse(txtVouNo.Text);
                        if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان الوصول", "الغاء", "الغاء بيان الوصول رقم " + lblBranch2.Text + "/" + txtVouNo.Text, txtReason.Text, IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            txtReason.Text = "";

                            if (HttpRuntime.Cache["OverTrack_" + AreaNo + Session["CNN2"].ToString()] != null)
                            {
                                Cache.Remove("OverTrack_" + AreaNo + Session["CNN2"].ToString());
                                Cache.Remove("OverTrack1_" + AreaNo + Session["CNN2"].ToString());
                                Cache.Remove("OverTrack2_" + AreaNo + Session["CNN2"].ToString());
                            }
                            if (HttpRuntime.Cache["OverCarMove_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMove_" + AreaNo + Session["CNN2"].ToString());
                            if (HttpRuntime.Cache["OverCarMoveTrip_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMoveTrip_" + AreaNo + Session["CNN2"].ToString());
                            if (HttpRuntime.Cache["OverCarMoveChart_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMoveChart_" + AreaNo + Session["CNN2"].ToString());
                            if (HttpRuntime.Cache["OverCarsIn_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarsIn_" + AreaNo + Session["CNN2"].ToString());
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم الغاء البيانات بنجاح";
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

        protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtSearch.Text != "")
                {
                    string vs = txtSearch.Text;
                    BtnClear_Click(sender, e);
                    txtSearch.Text = vs;

                    CarMoveRCV myJv = new CarMoveRCV();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.LocNumber = short.Parse(AreaNo);
                    myJv.Number = int.Parse(txtSearch.Text);
                    myJv = myJv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myJv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم بيان الوصول غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان الوصول", "عرض", "عرض بيان الوصول رقم " + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                        EditMode();
                        txtVouNo.Text = txtSearch.Text;
                        txtVouDate.Text = myJv.GDate;
                        LblFTime.Text = myJv.FTime;
                        txtCarMove.Text = myJv.CarMove;
                        txtRemark.Text = myJv.Remark;
                        txtUserDate.Text = myJv.UserDate;
                        txtUserName.ToolTip = myJv.UserName;
                        TblUsers ax = new TblUsers();
                        if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        ax.UserName = myJv.UserName;
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
                        LoadVouData();
                        LoadAttachData();
                        bool vFound = false;
                        string CarRcvNo = "";
                        string CarRcvLoc = "";

                        if (grdCodes.DataSource != null)
                        {
                            foreach (myInv2 itm in (List<myInv2>)grdCodes.DataSource)
                            {
                                CarRcv myCar = new CarRcv();
                                myCar.Branch = short.Parse(Session["Branch"].ToString());
                                myCar.InvFNo = (short)itm.InvoiceFNo;
                                myCar.InvNo = itm.VouNo2;
                                myCar = myCar.GetByInvFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (myCar != null)
                                {
                                    vFound = true;
                                    CarRcvNo = myCar.Number.ToString();
                                    CarRcvLoc = myCar.LocNumber.ToString();
                                    break;
                                }
                            }
                            if (vFound)
                            {
                                //BtnEdit.Visible = false;
                                BtnDelete.Visible = false;
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لا يمكن الغاء بيان الوصول لانه مرتبط ببيان الاستلام رقم " + @"<a href='WebCarRCV.aspx?"+ (Request.QueryString["Support"] != null  ?  @"Support=1&" : "") + @"Flag=0&AreaNo=" + moh.MakeMask(CarRcvLoc, 5) + @"&FNum=" + CarRcvNo + @"' target='_blank'>" + CarRcvLoc + '/' + CarRcvNo + @"</a>";
                                return;
                            }
                        }
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم بيان الوصول";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
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

        protected void BtnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BtnSearch_Click(sender, e);
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

        private bool Saveall(CarMoveRCV itm)
        {
            try
            {
                if (txtCarMove.Text != "")
                {
                    CarMove myInv = new CarMove();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    if (txtCarMove.Text.Split('/').Count() <2)
                    {
                        txtCarMove.Text =  short.Parse(AreaNo).ToString() + "/" + txtCarMove.Text;
                    }
                    myInv.VouLoc = moh.MakeMask(txtCarMove.Text.Split('/')[0], 5);
                    myInv.Number = int.Parse(txtCarMove.Text.Split('/')[1]);
                    int i = 0;
                    try
                    {
                        foreach (myInv2 inv in myInv.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            GridViewRow gvr = grdCodes.Rows[i];
                            CheckBox ChkTrans = gvr.FindControl("ChkTrans") as CheckBox;
                            if (inv.Flag == "")
                            {
                                InvDetails myInvDetails = new InvDetails();
                                myInvDetails.Branch = inv.Branch;
                                myInvDetails.VouLoc = inv.InvoiceVouLoc;
                                myInvDetails.VouNo = inv.VouNo;
                                myInvDetails.FNo = (short)inv.InvoiceFNo;
                                myInvDetails.Transit = ChkTrans.Checked;
                                myInvDetails.SetTransit(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (ChkTrans.Checked)
                                {
                                    MyOver[i].Transit = ChkTrans.Checked;
                                    MyOver[i].SendStatus = "0";
                                    myInvDetails.Status = "0";
                                    myInvDetails.SetStatus(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                }
                            }
                            else if (inv.Flag == "L")
                            {
                                ShipDetails myInvDetails = new ShipDetails();
                                myInvDetails.Branch = inv.Branch;
                                myInvDetails.VouLoc = inv.InvoiceVouLoc;
                                myInvDetails.VouNo = inv.VouNo;
                                myInvDetails.FNo = (short)inv.InvoiceFNo;
                                myInvDetails.Transit = ChkTrans.Checked;
                                myInvDetails.UpdateTransit(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }
                            else if (inv.Flag == "E")
                            {
                                Shipment myInvDetails = new Shipment();
                                myInvDetails.Branch = inv.Branch;
                                myInvDetails.VouLoc = inv.InvoiceVouLoc;
                                myInvDetails.VouNo = inv.VouNo;
                                myInvDetails.Transit = ChkTrans.Checked;
                                myInvDetails.UpdateTransit(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }
                            i++;
                        }
                    }
                    catch(Exception)
                    {                    
                    }
                }

                itm.Branch = short.Parse(Session["Branch"].ToString());
                itm.LocNumber = short.Parse(AreaNo);
                itm.Number = int.Parse(txtVouNo.Text);
                itm.CarMove = txtCarMove.Text;
                itm.GDate = txtVouDate.Text;
                itm.FTime = LblFTime.Text;
                itm.Remark = txtRemark.Text;
                itm.UserName = txtUserName.ToolTip;
                itm.UserDate = txtUserDate.Text;
                return true;
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
                return false;
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
                        myArch.LocNumber = short.Parse(AreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 507;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(AreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 507;
                        myArch.FileName = FileUpload1.FileName;
                        myArch.FileName2 = mySetting.ImagePath2 + FileName;
                        myArch.FNo = (short)i;
                        myArch.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان الوصول", "اضافة مرفقات", "اضافة مرفقات لبيان الوصول رقم " + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                        LoadAttachData();
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
                myArch.LocNumber = short.Parse(AreaNo);
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = 507;
                myArch.FNo = short.Parse(FNo);
                myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان الوصول", "الغاء مرفقات", "الغاء مرفقات لبيان الوصول رقم " + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                LoadAttachData();
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

        public void LoadAttachData()
        {
            Arch myArch = new Arch();
            myArch.Branch = short.Parse(Session["Branch"].ToString());
            myArch.LocNumber = short.Parse(AreaNo);
            myArch.Number = int.Parse(txtVouNo.Text);
            myArch.DocType = 507;
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

        protected void BtnFind2_Click(object sender, ImageClickEventArgs e)
        {
            LoadVouData();
        }

        protected void txtCarMove_TextChanged(object sender, EventArgs e)
        {
            LoadVouData();
        }

        public bool CheckSite(string CurrentCity, List<Cities> lc)
        {
            bool vFound = false;
            foreach (Cities itm in lc)
            {
                if (CurrentCity == itm.Code)
                {
                    vFound = true;
                    break;
                }
            }
            return vFound;
        }

        protected string UrlHelper33(object Number, object LocNumber, object Flag)
        {
            if (Flag.ToString() == "L") return "~/WebLShipment.aspx?Flag=0&FNum=" + Number.ToString() + "&AreaNo=" + moh.MakeMask(LocNumber.ToString(), 5) + "&StoreNo=00001";
            else if (Flag.ToString() == "E") return "~/WebShipment.aspx?Flag=0&FNum=" + Number.ToString() + "&AreaNo=" + moh.MakeMask(LocNumber.ToString(), 5) + "&StoreNo=00001";
            else return "~/WebInvoice.aspx?Flag=0&FNum=" + Number.ToString() + "&AreaNo=" + moh.MakeMask(LocNumber.ToString(), 5) + "&StoreNo=00001";
        }

        protected string UrlHelper330(object Number)
        {
            return (Number != "" ? "~/WebCarRCV.aspx?" + (Request.QueryString["Support"] != null ? @"Support=1&" : "") + @"Flag=0&AreaNo=" + moh.MakeMask(Number.ToString().Split('/')[0], 5) + @"&FNum=" + Number.ToString().Split('/')[1] : "");
        }

        protected string UrlHelper(object FType, object Number)
        {
            if (Number != null)
            {
                return "~/WebCars.aspx?&AreaNo=" + AreaNo + "&CarNo=" + Number.ToString();
            }
            else return "";
        }

        protected void Image2_Click(object sender, ImageClickEventArgs e)
        {

            ImageButton btnInsert = sender as ImageButton;
            GridViewRow gvr = btnInsert.NamingContainer as GridViewRow;
            Label lblMobileNo = gvr.FindControl("lblMobileNo") as Label;
            string myStatus = "0";

            myStatus = sms.SendMessage("شكرا لتعاملك مع ناقلات البرية شحنتك وصلت للاستفسار اتصل ب0115283100 أو 920028833", "naqelat", "966" + lblMobileNo.Text.Substring(1, 9));
            MyOver[gvr.RowIndex].SendStatus = myStatus;
            if (MyOver[gvr.RowIndex].Flag == "")
            {
                InvDetails myInvDetails = new InvDetails();
                myInvDetails.Branch = MyOver[gvr.RowIndex].Branch;
                myInvDetails.VouLoc = MyOver[gvr.RowIndex].InvoiceVouLoc;
                myInvDetails.VouNo = MyOver[gvr.RowIndex].VouNo;
                myInvDetails.FNo = (short)MyOver[gvr.RowIndex].InvoiceFNo;
                myInvDetails.Status = myStatus;
                myInvDetails.SetStatus(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            }
            LoadVouData();
        }

    }
}
