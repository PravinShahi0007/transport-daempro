using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using BLL;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class WebCarMove2 : System.Web.UI.Page
    {
        public List<myInv2> VouData
        {
            get
            {
                if (ViewState["VouData"] == null)
                {
                    ViewState["VouData"] = new List<myInv2>();
                }
                return (List<myInv2>)ViewState["VouData"];
            }
            set
            {
                ViewState["VouData"] = value;

            }
        }
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
        public string RoleName
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

        public void EditMode()
        {
            txtNumber.ReadOnly = true;
            txtNumber.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = true && (bool)((List<TblRoles>)(Session[RoleName]))[1].Pass215;
            BtnEdit.Visible = true && (bool)((List<TblRoles>)(Session[RoleName]))[1].Pass212;
            BtnNew.Visible = false;
            BtnDelete.Visible = true && (bool)((List<TblRoles>)(Session[RoleName]))[1].Pass213;
        }

        public void NewMode()
        {
            txtNumber.ReadOnly = false;
            txtNumber.BackColor = System.Drawing.Color.White;

            BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = true && (bool)((List<TblRoles>)(Session[RoleName]))[1].Pass211;
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
                    this.Page.Header.Title = "بيان الترحيل";

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
                    lblBranch.Text = "/" + short.Parse(AreaNo).ToString();

                    Cities myCity = new Cities();
                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlTo.DataTextField = "Name1";
                    ddlTo.DataValueField = "Code";
                    ddlFrom.DataTextField = "Name1";
                    ddlFrom.DataValueField = "Code";
                    ddlTo.DataSource = (from itm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                        orderby itm.Name1
                                        select itm).ToList();
                    ddlFrom.DataSource = ddlTo.DataSource;

                    Drivers myDrive = new Drivers();
                    myDrive.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlDriver.DataTextField = "Name1";
                    ddlDriver.DataValueField = "Code";
                    ddlDriver.DataSource = (from itm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                                            where (bool)itm.Status
                                            orderby itm.Name1
                                            select itm).ToList();                        

                    Cars myCar = new Cars();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlCar.DataTextField = "PlateNo";
                    ddlCar.DataValueField = "Code";
                    ddlCar.DataSource = (from itm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                         where (bool)itm.Status && itm.CarsType == myCar.CarsType
                                         select itm).ToList();

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
                    RoleName = vRoleName;
                    BtnNew.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass211;
                    BtnEdit.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass212;
                    BtnDelete.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass213;
                    BtnSearch.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass214;
                    BtnPrint.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass215;
                    BtnFind.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass214;

                    ddlTo.DataBind();
                    ddlFrom.DataBind();
                    ddlDriver.DataBind();
                    ddlCar.DataBind();
                    ddlTo.Items.Insert(0, new ListItem("--- أختار من ---", "-1", true));
                    ddlFrom.Items.Insert(0, new ListItem("--- أختار إلى ---", "-1", true));
                    ddlCar.Items.Insert(0, new ListItem("--- أختار الشاحنة ---", "-1", true));
                    ddlDriver.Items.Insert(0, new ListItem("--- أختار السائق ---", "-1", true));

                    if (Request.QueryString["FNum"] != null)
                    {
                        txtNumber.Text = Request.QueryString["FNum"].ToString();
                        BtnSearch_Click(sender, null);
                    }
                    else BtnClear_Click(sender, null);
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

        protected void BtnClear_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                NewMode();
                txtNumber.Text = "";
                txtCarNo.Text = "";
                txtCap.Text = "";
                txtFType2.Text = "";
                txtFType2.ToolTip = "";
                txtGDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                txtHDate.Text = HDate.getNow();
                LblFTime.Text = String.Format("{0:HH:mm:ss}", moh.Nows());  //moh.Nows().ToShortTimeString();
                ddlFrom.SelectedIndex = 0;
                ddlTo.SelectedIndex = 0;
                ddlDriver.SelectedIndex = 0;
                ddlCar.SelectedIndex = 0;
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                VouData.Clear();

                CarMove myInv = new CarMove();
                myInv.Branch = short.Parse(Session["Branch"].ToString());
                myInv.VouLoc = AreaNo;
                int? i1 = myInv.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (i1 == 0 || i1 == null)
                {
                    i1 = SiteInfo.CarMoveNo;
                }
                else
                {
                    i1++;
                }
                txtNumber.Text = i1.ToString();
                LoadVouData();
                LoadAttachData();
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void LoadVouData()
        {
            try
            {
                grdCodes.DataSource = (List<myInv2>)VouData;
                grdCodes.DataBind();
                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                LblCodesResult.Text = "عدد السيارات " + VouData.Count.ToString();

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
                    if (!ValidateInv()) return;
                    CarMove myInv = new CarMove();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.Number = int.Parse(txtNumber.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();

                    if (myInv != null)
                    {
                        myInv = new CarMove();
                        myInv.Branch = short.Parse(Session["Branch"].ToString());
                        myInv.VouLoc = AreaNo;
                        int? i = myInv.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == 0 || i == null)
                        {
                            i = 1;
                        }
                        else
                        {
                            i++;
                        }
                        txtNumber.Text = i.ToString();
                    }
                    myInv = new CarMove();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.Number = int.Parse(txtNumber.Text);
                    PutInv(myInv);

                    int r  = 0;
                    int FNo = 1;
                    bool Add = true;
                    foreach (GridViewRow gvr in grdCodes.Rows)
                    {
                        CheckBox ChkStatus = gvr.FindControl("ChkStatus") as CheckBox;
                        if (ChkStatus.Checked)
                        {
                            myInv.FNo = (short)FNo;
                            myInv.InvoiceNo = VouData[r].VouNo;
                            myInv.InvoiceFNo = VouData[r].InvoiceFNo;
                            myInv.CarMoveNo = VouData[r].CarMoveNo;
                            myInv.CarMoveLoc = VouData[r].CarMoveLoc;
                            myInv.InvoiceVouLoc = VouData[r].InvoiceVouLoc;
                            myInv.FTime = LblFTime.Text;
                            if (txtFType2.ToolTip != "") myInv.FType2 = txtFType2.ToolTip;
                            else myInv.FType2 = "-1";
                            Add = myInv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString , (VouData[r].Destination == ddlTo.SelectedValue));
                            FNo++;
                        }
                        r++;
                    }

                    if (FNo == 1)
                    {
                        myInv.FNo = (short)FNo;
                        myInv.InvoiceNo = 0;
                        myInv.InvoiceFNo = 0;
                        myInv.CarMoveNo = 0;
                        myInv.CarMoveLoc = "";
                        myInv.InvoiceVouLoc = "";
                        myInv.FTime = LblFTime.Text;
                        Add = myInv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, false);                    
                    }

                    if (Add)
                    {
                        double CostAmount = 0;
                        CarPrices myPrice = new CarPrices();
                        myPrice.Branch = short.Parse(Session["Branch"].ToString());
                        myPrice.MonthNo = 0;
                        myPrice.FromCode = this.ddlFrom.SelectedValue;
                        myPrice.toCode = this.ddlTo.SelectedValue;
                        myPrice.PLevel = "00002";
                        myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myPrice != null)
                        {
                            CostAmount = (double)myPrice.CostAmount;
                        }

                        if (CostAmount != 0)
                        {
                            myInv.Post(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString,CostAmount,SiteInfo.DezelAcc,SiteInfo.TripAcc,SiteInfo.CurExpAcc,SiteInfo.Project,SiteInfo.Area,"00002",0);
                        }

                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                        string vNumber = txtNumber.Text;
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        BtnClear_Click(sender, e);
                        PrintMe(vNumber);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
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

        public bool ValidateInv()
        {
            int Count = 0;
            foreach (GridViewRow gvr in grdCodes.Rows)
            {
                CheckBox ChkStatus = gvr.FindControl("ChkStatus") as CheckBox;
                if (ChkStatus.Checked) Count++;
            }

            //if (Count == 0)
            //{
            //    LblCodesResult.ForeColor = System.Drawing.Color.Red;
            //    LblCodesResult.Text = "يجب أختيار 8 الى 10 سيارات للشحن";
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
            //    return false;
            //}

            if (Count > 10)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "لقد تجاوزت حمولة الشحن القصوى 10 سيارات";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }
            return true;
        }

        public void PutInv(CarMove myInv)
        {
            myInv.DriverCode = ddlDriver.SelectedValue;
            myInv.CarCode = ddlCar.SelectedValue;
            myInv.FromLoc = ddlFrom.SelectedValue;
            myInv.ToLoc = ddlTo.SelectedValue;
            myInv.HDate = txtHDate.Text;
            myInv.GDate = txtGDate.Text;
            myInv.UserName = txtUserName.ToolTip;
            myInv.UserDate = txtUserDate.Text;
            myInv.FTime = LblFTime.Text;
        }

        public void GetInv(CarMove myInv)
        {
            ddlDriver.SelectedValue = myInv.DriverCode;
            ddlCar.SelectedValue = myInv.CarCode;
            ddlFrom.SelectedValue = myInv.FromLoc;
            ddlTo.SelectedValue = myInv.ToLoc;
            txtHDate.Text = myInv.HDate;
            txtGDate.Text = myInv.GDate;
            LblFTime.Text = myInv.FTime;
            txtCarNo.Text = myInv.CarCode;
            if (myInv.FType2 == "-1") txtFType2.ToolTip = "";
            else
            {
                txtFType2.ToolTip = myInv.FType2;
                Codes myCode = new Codes();
                myCode.Branch = short.Parse(Session["Branch"].ToString());
                myCode.Ftype = 30;
                myCode.Code = int.Parse(myInv.FType2);
                if (Cache["LastCodes" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCodes" + Session["CNN2"].ToString(), myCode.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myCode = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                          where itm.Ftype == myCode.Ftype && itm.Code == myCode.Code
                          select itm).FirstOrDefault();
                if (myCode != null)
                {
                    txtCap.Text = myCode.FType2;
                    txtFType2.Text = myCode.Name1;
                }
                else
                {
                    txtCap.Text = "";
                    txtFType2.Text = "";
                    txtFType2.ToolTip = "";
                }
            }
            txtUserName.ToolTip = myInv.UserName;
            TblUsers ax = new TblUsers();
            if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            ax.UserName = myInv.UserName;
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
            txtUserDate.Text = myInv.UserDate;
        }

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (!ValidateInv()) return;
                    CarMove myInv = new CarMove();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.Number = int.Parse(txtNumber.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم بيان الحركة غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    else
                    {
                        PutInv(myInv);
                        if (myInv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            myInv = new CarMove();
                            myInv.Branch = short.Parse(Session["Branch"].ToString());
                            myInv.VouLoc = AreaNo;
                            myInv.Number = int.Parse(txtNumber.Text);
                            PutInv(myInv);

                            int r = 0;
                            int FNo = 1;
                            bool Add = true;
                            foreach (GridViewRow gvr in grdCodes.Rows)
                            {
                                CheckBox ChkStatus = gvr.FindControl("ChkStatus") as CheckBox;
                                if (ChkStatus.Checked)
                                {
                                    myInv.FNo = (short)FNo;
                                    myInv.InvoiceNo = VouData[r].VouNo;
                                    myInv.InvoiceFNo = VouData[r].InvoiceFNo;
                                    myInv.CarMoveNo = VouData[r].CarMoveNo;
                                    myInv.CarMoveLoc = VouData[r].CarMoveLoc;
                                    myInv.InvoiceVouLoc = VouData[r].InvoiceVouLoc;
                                    myInv.FTime = VouData[r].FTime;
                                    if (txtFType2.ToolTip != "") myInv.FType2 = txtFType2.ToolTip;
                                    else myInv.FType2 = "-1";
                                    Add = myInv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, (VouData[r].Destination == ddlTo.SelectedValue));
                                    FNo++;
                                }
                                r++;
                            }

                            if (FNo == 1)
                            {
                                myInv.FNo = (short)FNo;
                                myInv.InvoiceNo = 0;
                                myInv.InvoiceFNo = 0;
                                myInv.CarMoveNo = 0;
                                myInv.CarMoveLoc = "";
                                myInv.InvoiceVouLoc = "";
                                myInv.FTime = LblFTime.Text;
                                Add = myInv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, false);
                            }

                            if (Add)
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                                string vNumber = txtNumber.Text;
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                                BtnClear_Click(sender, e);
                                PrintMe(vNumber);
                            }
                            else
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء تعديل البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            }
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
                    CarMove myInv = new CarMove();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.Number = int.Parse(txtNumber.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم بيان الحركة غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    else
                    {
                        if (myInv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormAction = "الغاء";
                            UserTran.FormName = "بيان الترحيل";
                            UserTran.Description = "الغاء بيانات بيان الحركة رقم " + txtNumber.Text;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);


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
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtNumber.Text != "")
                {
                    CarMove myInv = new CarMove();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.Number = int.Parse(txtNumber.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم بيان الحركة غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    else
                    {
                        EditMode();
                        GetInv(myInv);
                        VouData = myInv.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        LoadVouData();
                        LoadAttachData();
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم الفاتورة";
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

        public void PrintMe(String Number)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=1&AreaNo=" + AreaNo + "&Number=" + Number + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
                    return;    
        }

        protected void BtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (!ValidateInv()) return;
                    PrintMe(txtNumber.Text);
                    return;

                    /*
                    string Number = txtNumber.Text;
                    string Branch = lblBranch.Text;
                    string From2 = ddlFrom.SelectedItem.Text;
                    string To2 = ddlTo.SelectedItem.Text;
                    string Car = ddlCar.SelectedValue;
                    string Hdate = HDate.RotateDate2(txtHDate.Text) + " هـ ";
                    string GDate = txtGDate.Text + " م " + LblFTime.Text;
                    string Driver = ddlDriver.SelectedItem.Text;
                    string DriverCode = ddlDriver.SelectedValue;
                    List<myInv2> lstCar = new List<myInv2>();
                    int i = 0;
                    if (grdCodes.Rows.Count > 0)
                    {
                        foreach (GridViewRow gvr in grdCodes.Rows)
                        {
                            CheckBox ChkStatus = gvr.FindControl("ChkStatus") as CheckBox;
                            if (ChkStatus.Checked)
                            {
                                lstCar.Add(new myInv2
                                {
                                    Name = VouData[i].Name,
                                    VouNo = VouData[i].VouNo,
                                    InvoiceVouLoc = VouData[i].InvoiceVouLoc,
                                    CarType = VouData[i].CarType,
                                    PlateNo = VouData[i].PlateNo,
                                    ChassisNo = VouData[i].ChassisNo,
                                    Model = VouData[i].Model,
                                    Color = VouData[i].Color,
                                    RecName = VouData[i].RecName,
                                    DestinationName1 = VouData[i].DestinationName1
                                });
                            }
                            i++;
                        }
                    }

                    CarMove myInv = new CarMove();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.Number = int.Parse(txtNumber.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myInv == null) BtnNew_Click(sender, e);
                    //else BtnEdit_Click(sender, e);

                    iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), -50, -50, 80, 50);
                    HttpContext.Current.Response.ContentType = "application/pdf";
                    PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
                    pdfPage page = new pdfPage();
                    MyConfig mySetting = new MyConfig();
                    mySetting.Branch = short.Parse(Session["Branch"].ToString());
                    mySetting = mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (mySetting != null)
                    {
                        page.vCompanyName = mySetting.CompanyName;
                    }
                    
                    writer.PageEvent = page;
                    page.PageNo = "1";
                    page.UserName = Session["FullUser"].ToString();

                    page.vStr4 = ((Label)this.Master.FindControl("LblBranchName")).Text;    //Session["AreaName"].ToString();
                    //-------------------------------------------------------------------------------------------                    
                    document.Open();
                    //-------------------------------------------------------------------------------------------                    

                    //string arialunicodepath = Server.MapPath("Fonts") + @"\arial.ttf";
                    string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";                    
                    BaseFont nationalBase;
                    nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 11f, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font nationalTextFont2 = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font nationalTextFont14 = new iTextSharp.text.Font(nationalBase, 14f, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font nationalTextFont16 = new iTextSharp.text.Font(nationalBase, 16f, iTextSharp.text.Font.NORMAL);
                    //-------------------------------------------------------------------------------------------                    
                    //document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    //-------------------------------------------------------------------------------------------                    
                    var cols = new[] { 200,200, 150,250,400};
                    document.Open();
                    PdfPTable table = new PdfPTable(5);
                    table.TotalWidth = document.PageSize.Width; //100f;
                    table.SetWidths(cols);
                    PdfPCell cell2 = new PdfPCell();
                    cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    PdfPCell cell22 = new PdfPCell();
                    cell22.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell22.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell22.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;


                    cell2.Border = 0;
                    Cars myCar = new Cars();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                    myCar.Code = Car;
                    myCar = myCar.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    cell2.Phrase = new iTextSharp.text.Phrase(" " , nationalTextFont);
                    table.AddCell(cell2);

                    cell2.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell2.Phrase = new iTextSharp.text.Phrase(" بيان ترحيل سيارات رقم ", nationalTextFont16);
                    table.AddCell(cell2);

                    cell22.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    cell22.Phrase = new iTextSharp.text.Phrase(Number + Branch, nationalTextFont16);
                    table.AddCell(cell22);

                    cell2.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell2);


                    var TextCell = new PdfPCell(table.DefaultCell);
                    TextCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    TextCell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    //TextCell.Border = 0;
                    TextCell.BorderColor = iTextSharp.text.BaseColor.WHITE;
                    PdfContentByte cb = writer.DirectContent;
                    var bc128 = new Barcode128();
                    bc128.CodeType = Barcode.CODE128;
                    bc128.Code = Branch + Number;
                    bc128.GenerateChecksum = true;
                    bc128.AltText = "" ;
                    bc128.StartStopText = true;
                    

                    //bc128.BarHeight = 8;
                    //bc128.Extended = true; 

                    //bc128.Baseline = 20;   // Doesn't affect rendering.
                    //bc128.Size = 20;       // Doesn't affect rendering.
                    //bc128.BarHeight = 60;  // DOES affect rendering.
                    //bc128.X = 2;                          

                    TextCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    //cell.AddElement(bc128.CreateImageWithBarcode(cb, null, null));                    
                    var bi = bc128.CreateImageWithBarcode(cb, null, null);
                    bi.ScalePercent(100);
                    bi.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    TextCell.AddElement(bi);

                    //cell.Image = bc128.CreateImageWithBarcode(cb, null, null);                    
                    //table.AddCell(cell);
                    table.AddCell(TextCell);
                    document.Add(table);
                    //-------------------------------------------------------------------------------------------
                      document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    //-------------------------------------------------------------------------------------------
                    cols = new[] { 400, 120, 210, 120, 170, 120};
                    table = new PdfPTable(6);
                    table.TotalWidth = document.PageSize.Width; //100f;
                    table.SetWidths(cols);
                    PdfPCell cell = new PdfPCell();
                    cell.FixedHeight = 20f;

                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    //cell.Border = 0;
                    cell.Phrase = new iTextSharp.text.Phrase("من", nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(From2, nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("إلى", nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(To2, nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("الشاحنة", nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(myCar.CarType + " " + myCar.PlateNo + " نقل السعودية ", nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("التاريخ", nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(Hdate, nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("الموافق", nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(GDate, nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("السائق", nationalTextFont2);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(Driver, nationalTextFont2);
                    table.AddCell(cell);
                    document.Add(table);
                    //-------------------------------------------------------------------------------------------
                   // document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    //-------------------------------------------------------------------------------------------
                    int ColCount = 9;
                    cols = new[] { 200,175,250,150,150,150,120,250,50};                    
                    table = new PdfPTable(ColCount);
                    table.TotalWidth = document.PageSize.Width; //100f;
                    table.SetWidths(cols);
                    cell = new PdfPCell();
                    cell.FixedHeight = 20f;
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    //cell.Border = 0;
                    cell.Phrase = new iTextSharp.text.Phrase("م", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("مرسل السيارة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("رقم الفاتورة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("نوع السيارة", nationalTextFont);
                    table.AddCell(cell);

                    //cell.Phrase = new iTextSharp.text.Phrase("رقم اللوحة أو الهيكل", nationalTextFont);
                    cell.Phrase = new iTextSharp.text.Phrase("رقم اللوحة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الموديل و اللون", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("أسم مستلم السيارة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("جهة الترحيل", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("ملاحظات", nationalTextFont);
                    table.AddCell(cell);

                    //-------------------------------------------------------------------------------------------
                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    int FNo = 1;
                    bool vClient = true;
                    string vClientName = "-1";
                    if (lstCar.Count>0)
                    {
                        foreach (myInv2 inv in lstCar)
                        {

                                cell.Phrase = new iTextSharp.text.Phrase(FNo.ToString(), nationalTextFont);
                                table.AddCell(cell);
                                if (vClientName == "-1") vClientName = inv.Name;
                                else if (vClientName != inv.Name) vClient = false;
                                cell.Phrase = new iTextSharp.text.Phrase(inv.Name, nationalTextFont);
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(inv.VouNo.ToString() + '/' + int.Parse(inv.InvoiceVouLoc).ToString(), nationalTextFont);
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(inv.CarType, nationalTextFont);
                                table.AddCell(cell);

                                if (inv.PlateNo != "") cell.Phrase = new iTextSharp.text.Phrase(inv.PlateNo, nationalTextFont);
                                else cell.Phrase = new iTextSharp.text.Phrase(inv.ChassisNo, nationalTextFont);
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(inv.Model + " " + inv.Color, nationalTextFont);
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(inv.RecName, nationalTextFont);
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase(inv.DestinationName1, nationalTextFont);
                                table.AddCell(cell);

                                cell.Phrase = new iTextSharp.text.Phrase("    ", nationalTextFont);
                                table.AddCell(cell);
                                FNo++;
                            }
                    }
                    cell.Border = 0;
                    cell.Phrase = new iTextSharp.text.Phrase("    ", nationalTextFont);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    document.Add(table);
                    //document.Add(Environment.NewLine);
                    //document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    //-------------------------------------------------------------------------------------------
                    string vs = "\nأقر أنا السائق / " + ddlDriver.SelectedItem.Text + " هوية رقم ";
                    Drivers myDrive = new Drivers();
                    myDrive.Branch = short.Parse(Session["Branch"].ToString());
                    myDrive.Code = DriverCode;
                    myDrive = myDrive.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    vs += myDrive.IqamaNo + " على كفالة " + myDrive.Sponsor + "أنني أستلمت السيارات الموضحة أعلاه.";
                    if (vClient) vs += "وعددها " + (FNo - 1).ToString() + " سليمة و مسئول عنها و عن محتوياتها حتى يتم تسليمها إلى العميل/ " + vClientName + " وعلى ذلك أوقع. ";
                    else vs += "وعددها " + (FNo - 1).ToString() + " سليمة و مسئول عنها و عن محتوياتها حتى يتم تسليمها إلى /  " + To2 + " وعلى ذلك أوقع. ";
                    table = new PdfPTable(3);
                    table.TotalWidth = document.PageSize.Width; //100f;
                    cols = new[] { 500,300,500 };
                    table.SetWidths(cols);
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell = new PdfPCell();
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Phrase = new iTextSharp.text.Phrase(vs , nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont2);
                    table.AddCell(cell);

                    if(vClient) vs = "\nأقر أنا المستلم/"+vClientName+" بأنني أستلمت السيارات الموضحة بعالية كماهي مثبتة بالفواتير أو بالملاحظات المثبتة بأعلاه ";
                    else vs = "\nأقر أنا المستلم (موظف الفرع) /                                 بأنني أستلمت السيارات الموضحة بعالية كماهي مثبتة بالفواتير أو بالملاحظات المثبتة بأعلاه ";
                    cell.Phrase = new iTextSharp.text.Phrase(vs, nationalTextFont2);
                    table.AddCell(cell);

                    document.Add(table);
                  //  document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    //-------------------------------------------------------------------------------------------
                    table = new PdfPTable(7);
                    table.TotalWidth = document.PageSize.Width; //100f;
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cols = new[] { 125, 300, 75, 300, 100, 300, 100};
                    table.SetWidths(cols);

                    cell = new PdfPCell();
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.Border = 0;
                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("السائق :", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("المرسل : (موظف الفرع)", nationalTextFont2);                   
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    if(vClient) cell.Phrase = new iTextSharp.text.Phrase("المرسل إليه : (العميل)", nationalTextFont2);
                    else cell.Phrase = new iTextSharp.text.Phrase("المرسل إليه : (موظف الفرع)", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    //-------------------------------------------------------------------------------------------

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الاســم : " + Driver, nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الاســم : " + txtUserName.Text, nationalTextFont2);                    
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    if(vClient) cell.Phrase = new iTextSharp.text.Phrase("الاســم : "+vClientName , nationalTextFont2);
                    else cell.Phrase = new iTextSharp.text.Phrase("الاســم : ", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    //-------------------------------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("التوقيع : ", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("التوقيع : ", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("التوقيع : ", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);
                    document.Add(table);
                    //-------------------------------------------------------------------------------------------
                    //document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    //-------------------------------------------------------------------------------------------
                    //-------------------------------------------------------------------------------------------
                    document.Close();
                     */
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
            }
        }


        // *************************************************** ITextSharp ****************************************************************
        /*
         public class pdfPage : iTextSharp.text.pdf.PdfPageEventHelper
         {
             public string vStr1, vStr2, vStr3, vStr4, UserName, PageNo, vCompanyName;
             //I create a font object to use within my footer
             protected iTextSharp.text.Font footer
             {
                 get
                 {
                     // create a basecolor to use for the footer font, if needed.
                     iTextSharp.text.BaseColor grey = new iTextSharp.text.BaseColor(128, 128, 128);
                     //string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\arial.ttf";
                     string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                    
                     BaseFont nationalBase;
                     nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                     iTextSharp.text.Font font = new iTextSharp.text.Font(nationalBase, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.WHITE);
                     return font;
                 }
             }
             //override the OnStartPage event handler to add our header
             public override void OnStartPage(PdfWriter writer, iTextSharp.text.Document doc)
             {
                 string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                 //string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\DTNASKH1.TTF";
                 //string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\arial.ttf";
                 BaseFont nationalBase;
                 nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                 iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 18f, iTextSharp.text.Font.NORMAL);


                 //I use a PdfPtable with 1 column to position my header where I want it
                 PdfPTable headerTbl = new PdfPTable(3);
                 var cols2 = new[] { 300, 600, 300 };
                 headerTbl.TotalWidth = doc.PageSize.Width;
                 headerTbl.SetWidths(cols2);
                 headerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                 headerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                 //set the width of the table to be the same as the document
                

                 PdfPCell cell2 = new PdfPCell();
                 cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                 cell2.Border = 0;
                 cell2.PaddingRight = 15;
                 cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                 cell2.Phrase = new iTextSharp.text.Phrase(vCompanyName + "\n" + vStr4, nationalTextFont);
                 cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                 headerTbl.AddCell(cell2);

                 cell2.PaddingRight = 0;
                 cell2.Phrase = new iTextSharp.text.Phrase(vStr1, nationalTextFont);
                 cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                 cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                 headerTbl.AddCell(cell2);

                 //I use an image logo in the header so I need to get an instance of the image to be able to insert it. I believe this is something you couldn't do with older versions of iTextSharp
                 iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("images/logo_naqlyat.png"));

                 //I used a large version of the logo to maintain the quality when the size was reduced. I guess you could reduce the size manually and use a smaller version, but I used iTextSharp to reduce the scale. As you can see, I reduced it down to 7% of original size.
                 logo.ScalePercent(70);

                 //create instance of a table cell to contain the logo
                 PdfPCell cell20 = new PdfPCell(logo);

                 //align the logo to the right of the cell
                 cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                 //add a bit of padding to bring it away from the right edge
                 cell20.PaddingTop = 0;
                 cell20.PaddingRight = 30;

                 //remove the border
                 cell20.Border = 0;

                 //Add the cell to the table
                 headerTbl.AddCell(cell20);
                 headerTbl.WriteSelectedRows(0, -1, -1, (doc.PageSize.Height - 20), writer.DirectContent);
             }

             //override the OnPageEnd event handler to add our footer
             public override void OnEndPage(PdfWriter writer, iTextSharp.text.Document doc)
             {
                 //I use a PdfPtable with 2 columns to position my footer where I want it
                 PdfPTable footerTbl = new PdfPTable(4);
                 var cols2 = new[] { 200, 200, 200, 200 };
                 footerTbl.SetWidths(cols2);
                 footerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                 footerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                 //set the width of the table to be the same as the document
                 footerTbl.TotalWidth = doc.PageSize.Width;
                 //Center the table on the page
                 footerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                 PdfPCell cell = new PdfPCell();
                 cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                 cell.BackgroundColor = iTextSharp.text.BaseColor.RED;
                 cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                 //set cell border to 0
                 cell.Border = 2;

                 //add some padding to bring away from the edge
                 cell.PaddingRight = 5;
                 cell.Phrase = new iTextSharp.text.Phrase("تاريخ الطباعة : " + String.Format("{0:dd/MM/yyyy}", moh.Nows()), footer);
                 //add cell to table
                 footerTbl.AddCell(cell);

                 //create new instance of cell to hold the text
                 //cell = new PdfPCell();

                 //align the text to the right of the cell
                 //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                 cell.Phrase = new iTextSharp.text.Phrase("طبعت بواسطة " + UserName, footer);

                 // add some padding to take away from the edge of the page
                 //cell.PaddingRight = 5;

                 //add the cell to the table
                 footerTbl.AddCell(cell);

                 cell.Phrase = new iTextSharp.text.Phrase("عدد مرات الطباعة " + PageNo, footer);
                 footerTbl.AddCell(cell);

                 cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                 cell.Phrase = new iTextSharp.text.Phrase("صفحة رقم " + writer.PageNumber.ToString(), footer);

                 // add some padding to take away from the edge of the page
                 cell.PaddingLeft = 5;

                 //add the cell to the table
                 footerTbl.AddCell(cell);

                 //write the rows out to the PDF output stream.
                 footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin - 10), writer.DirectContent);
             }        
         }
         */

        protected void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Invoice inv = new Invoice();
                inv.Branch = short.Parse(Session["Branch"].ToString());
                inv.VouLoc = AreaNo;
                if (ChkAll.Checked) VouData = inv.GetInvMove(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                else if (ddlTo.SelectedIndex > 0)
                {
                    inv.Destination = ddlTo.SelectedValue;
                    VouData = inv.GetInvMove2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }

                List<myInv2> myList2 = new List<myInv2>();
                CarMove myCarMove = new CarMove();
                myCarMove.Branch = short.Parse(Session["Branch"].ToString());
                myCarMove.VouLoc = AreaNo;
                myCarMove.ToLoc = ddlTo.SelectedValue;
                myList2 = myCarMove.Gettr(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, ChkAll.Checked, SiteInfo.City,AreaNo);

                if(myList2 != null) VouData.AddRange(myList2);

                LoadVouData();
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void ddlCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(ddlCar.SelectedIndex>0)
                {
                    Cars myCar = new Cars();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myCar.Code = ddlCar.SelectedValue;
                    myCar = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                             where sitm.Code == myCar.Code
                             select sitm).FirstOrDefault();
                    if (myCar != null)
                    {
                        txtCarNo.Text = myCar.Code;
                        if (myCar.DriverCode != "-1") ddlDriver.SelectedValue = myCar.DriverCode;
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
                                txtCap.Text = myCode.FType2;
                                txtFType2.Text = myCode.Name1;
                                txtFType2.ToolTip = myCar.FType2;
                            }
                            else
                            {
                                txtCap.Text = "";
                                txtFType2.Text = "";
                                txtFType2.ToolTip = "";
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

        protected string UrlHelper(object Number, object LocNumber)
        {
            return "~/WebInvoice.aspx?FNum=" + Number.ToString() + "&AreaNo=" + moh.MakeMask(LocNumber.ToString(), 5);
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
                        myArch.Number = int.Parse(txtNumber.Text);
                        myArch.DocType = 504;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(AreaNo);
                        myArch.Number = int.Parse(txtNumber.Text);
                        myArch.DocType = 504;
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
                myArch.Number = int.Parse(txtNumber.Text);
                myArch.DocType = 504;
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
            myArch.LocNumber = short.Parse(AreaNo);
            myArch.Number = int.Parse(txtNumber.Text);
            myArch.DocType = 504;
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
            try
            {
                if (txtCarNo.Text != "")
                {
                    txtCarNo.Text = moh.MakeMask(txtCarNo.Text, 5);
                    Cars myInv = new Cars();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myInv.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myInv.Code = txtCarNo.Text;
                    myInv = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                             where sitm.Code == myInv.Code
                             select sitm).FirstOrDefault();
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الباب غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    else
                    {
                        ddlCar.SelectedValue = txtCarNo.Text;
                        ddlCar_SelectedIndexChanged(sender, e);
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم الباب";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }

        }

        protected void ddlDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDriver.SelectedIndex > 0)
                {
                    Cars myCar = new Cars();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myCar.DriverCode = ddlDriver.SelectedValue;
                    myCar = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                             where sitm.DriverCode == myCar.DriverCode && (bool)sitm.Status
                             select sitm).FirstOrDefault();
                    if (myCar != null)
                    {
                        txtCarNo.Text = myCar.Code;
                        ddlCar.SelectedValue = myCar.Code;
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
                                txtCap.Text = myCode.FType2;
                                txtFType2.Text = myCode.Name1;
                                txtFType2.ToolTip = myCar.FType2;
                            }
                            else
                            {
                                txtCap.Text = "";
                                txtFType2.Text = "";
                                txtFType2.ToolTip = "";
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
    }
}