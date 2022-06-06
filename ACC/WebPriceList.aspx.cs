using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Threading;
using System.Globalization;
using System.Configuration;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;

namespace ACC
{
    public partial class WebPriceList : System.Web.UI.Page
    {
        public List<PriceListDetails> VouData
        {
            get
            {
                if (ViewState["VouData"] == null)
                {
                    ViewState["VouData"] = new List<PriceListDetails>();
                }
                return (List<PriceListDetails>)ViewState["VouData"];
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
        public string Total20
        {
            get
            {
                if (ViewState["Total20"] == null)
                {
                    ViewState["Total20"] = "0.00";
                }
                return ViewState["Total20"].ToString();
            }
            set { ViewState["Total20"] = value; }
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
        public void EditMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = true; // && (Request.QueryString["Support"] != null || (Session[vRoleName] != null && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass205));
            BtnEdit.Visible = true; // && Session[vRoleName] != null && Request.QueryString["Support"] == null && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass202;
            BtnNew.Visible = false;
            BtnDelete.Visible = true;   // && Session[vRoleName] != null && Request.QueryString["Support"] == null && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass203;
            if (Request.QueryString["Flag"] != null)
            {
                if (Request.QueryString["Flag"].ToString() == "0")
                {
                    if ((Session[vRoleName] != null && Request.QueryString["Support"] == null && !(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass40) || Request.QueryString["Support"] != null)
                    {
                        BtnEdit.Visible = false;
                        BtnDelete.Visible = false;
                        BtnClear.Visible = false;
                    }

                }
            }
            if (Request.QueryString["Support"] != null || !(bool)(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass202 || !BtnEdit.Visible) ControlsOnOff(false);

            if (BtnEdit.Visible || BtnDelete.Visible)
            {
                txtReason.Visible = true;
                ValReason.Enabled = true;
                lblReason.Visible = true;
            }
        }

        public void NewMode()
        {
            //txtVouNo.ReadOnly = false;
            //txtVouNo.BackColor = System.Drawing.Color.White;
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = true; // && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass201;
            BtnDelete.Visible = false;
            txtReason.Visible = false;
            ValReason.Enabled = false;
            lblReason.Visible = false;

            //if (!(bool)(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass202 || !BtnEdit.Visible) ControlsOnOff(true);
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
                    this.Page.Header.Title = "عرض سعر";

                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = "الرئيسية";
                        UserTran.FormAction = "اختيار";
                        UserTran.Description = "اختيار عرض سعر";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

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

                    PriceList myList = new PriceList();
                    ddlName.DataTextField = "Name";
                    ddlName.DataValueField = "Name";
                    ddlName.DataSource = myList.GetName(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlName.DataBind();
                    ddlName.Items.Insert(0, new ListItem(" ", "-1", true));



                    if (Session[vRoleName] != null && Request.QueryString["Support"] == null)
                    {
                        //BtnNew.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass201;
                        //BtnEdit.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass202;
                        //BtnDelete.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass203;
                        //BtnSearch.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass204;
                        //BtnFind.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass204;
                        //BtnPrint.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass205;
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
                            txtSearch.Text = Request.QueryString["FNum"].ToString();
                            BtnSearch_Click(sender, null);
                        }
                        else
                        {
                            txtSearch.Text = Request.QueryString["FNum"].ToString();
                            BtnSearch_Click(sender, null);
                        }
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


        public bool ValidateInv()
        {

            if (txtName.Text == "")
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يجب أدخال أسم المرسل";
                txtName.Focus();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }

            bool vPass = true;
            foreach (PriceListDetails itm in VouData)
            {
                if (itm.PlaceofLoading == "" || itm.PlaceofLoading == "-1")
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب أختيار مكان الشحن";
                    vPass = false;
                    break;
                }

                if (itm.Destination == "" || itm.Destination == "-1")
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب أختيار جهة الترحيل";
                    vPass = false;
                    break;
                }
            }

            if (!vPass)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }

            return true;
        }

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    {
                        if (DateTime.Parse(txtGDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                    }

                    BtnNew.Enabled = false;
                    if (!ValidateInv())
                    {
                        BtnNew.Enabled = true;
                        return;
                    }
                    PriceList myInv = new PriceList();
                    myInv.VouNo = int.Parse(txtVouNo.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myInv != null)
                    {
                        if (myInv.UserName == txtUserName.ToolTip)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم العرض مكرر";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            BtnNew.Enabled = true;
                            return;
                        }
                        else
                        {
                            myInv = new PriceList();
                            int? i = myInv.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
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

                    myInv = new PriceList();
                    myInv.VouNo = int.Parse(txtVouNo.Text);
                    PutInv(myInv);                    
                    if (myInv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        SaveGridInfo();
                        PriceListDetails myInv2 = new PriceListDetails();
                        foreach (PriceListDetails itm in VouData)
                        {
                            myInv2.VouNo = int.Parse(txtVouNo.Text);
                            myInv2.FNo = (short)itm.FNo;
                            myInv2.Name = itm.Name;
                            myInv2.CarType = itm.CarType;
                            myInv2.Model = itm.Model;
                            myInv2.Price = itm.Price;
                            myInv2.Qty = itm.Qty;
                            myInv2.PlaceofLoading = itm.PlaceofLoading;
                            myInv2.Destination = itm.Destination;
                            myInv2.From2 = itm.From2;
                            myInv2.To2 = itm.To2;
                            myInv2.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }

                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";


                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormName = "عرض سعر";
                            UserTran.FormAction = "اضافة";
                            UserTran.Description = "اضافة بيانات عرض سعر رقم " + txtVouNo.Text;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }

                        //UpdateCache();
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        string vNumber = txtVouNo.Text;
                        BtnClear_Click(sender, e);
                        BtnNew.Enabled = true;
                        PrintMe(vNumber);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        BtnNew.Enabled = true;
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                }
            }
            catch (Exception ex)
            {
                BtnNew.Enabled = true;
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
                    if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    {
                        if (DateTime.Parse(txtGDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                    }

                    if (!ValidateInv()) return;
                    PriceList myInv = new PriceList();
                    myInv.VouNo = int.Parse(txtVouNo.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم عرض السعر غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    else
                    {
                        PriceListDetails myInv2 = new PriceListDetails();
                        myInv2.VouNo = int.Parse(txtVouNo.Text);
                        myInv2.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        PutInv(myInv);
                        if (myInv.Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            SaveGridInfo();
                            myInv2 = new PriceListDetails();
                            foreach (PriceListDetails itm in VouData)
                            {
                                myInv2.VouNo = int.Parse(txtVouNo.Text);
                                myInv2.FNo = (short)itm.FNo;
                                myInv2.Name = itm.Name;
                                myInv2.Price = itm.Price;
                                myInv2.CarType = itm.CarType;
                                myInv2.Model = itm.Model;
                                myInv2.Qty = itm.Qty;
                                myInv2.PlaceofLoading = itm.PlaceofLoading;
                                myInv2.Destination = itm.Destination;
                                myInv2.From2 = itm.From2;
                                myInv2.To2 = itm.To2;
                                myInv2.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }

                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";

                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.FormName = "عرض سعر";
                                UserTran.FormAction = "تعديل";
                                UserTran.Description = "تعديل بيانات عرض السعر رقم " + txtVouNo.Text;
                                UserTran.Reason = txtReason.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }
                            txtReason.Text = "";
                            // UpdateCache();
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            string vNumber = txtVouNo.Text;
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

        protected void BtnClear_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                NewMode();
                VouData.Clear();
                for (int i1 = 1; i1 < 11; i1++)
                {
                    VouData.Add(new PriceListDetails
                    {
                        FNo = (short)i1
                    });
                }
                ddlName.SelectedIndex = 0;
                ddlName_SelectedIndexChanged(sender, e);
                DispVouData();
                rdoVouType.SelectedIndex = 0;
                rdoVouType_SelectedIndexChanged(sender, e);
                ddlItems.SelectedValue = "6";
                ddlItems_SelectedIndexChanged(sender, e);
                ChkPrintTot.Checked = true;
                this.ChkLoc.Checked = false;
                txtVouNo.Text = "";
                txtReason.Text = "";
                txtSearch.Text = "";
                txtGDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                LblTax.Text = moh.doTax(txtGDate.Text, 1);
                txtHDate.Text = HDate.getNow();
                txtName.Text = "";
                txtSubject.Text = "";
                txtTax.Text = "";
                txtTotal.Text = "";
                Total20 = "0";
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                PriceList myInv = new PriceList();
                int? i = myInv.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (i == 0 || i == null)
                {
                    i = 1;
                }
                else
                {
                    i++;
                }
                txtVouNo.Text = i.ToString();
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

        public void ControlsOnOff(bool State)
        {
            txtGDate.ReadOnly = !State;
            txtHDate.ReadOnly = !State;
            txtName.ReadOnly = !State;
            txtSubject.ReadOnly = !State;
            //grdAttach.Enabled = State;
            foreach (GridViewRow itm in grdAttach.Rows)
            {
                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                if (BtnDelete != null) BtnDelete.Visible = State;
            }
            FileUpload1.Enabled = State;
            BtnAttach.Enabled = State;
            txtReason.ReadOnly = !State;
            ChkPrintTot.Enabled = State;
            grdCodes.Enabled = State;
        }

        protected void BtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    {
                        if (DateTime.Parse(txtGDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                    }

                    PriceList myInv = new PriceList();
                    myInv.VouNo = int.Parse(txtVouNo.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم عرض السعر غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    else
                    {
                        if (myInv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            PriceListDetails myInv2 = new PriceListDetails();
                            myInv2.VouNo = int.Parse(txtVouNo.Text);
                            myInv2.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.Description = "الغاء بيانات عرض السعر رقم " + txtVouNo.Text;
                                UserTran.FormAction = "الغاء";
                                UserTran.FormName = "عرض سعر";
                                UserTran.Reason = txtReason.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }
                            txtReason.Text = "";

                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم الغاء البيانات بنجاح";
                            // UpdateCache();
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
                if (txtSearch.Text != "")
                {
                    string vs = txtSearch.Text;
                    BtnClear_Click(sender, e);
                    txtSearch.Text = vs;

                    PriceList myInv = new PriceList();
                    myInv.VouNo = int.Parse(txtSearch.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم عرض السعر غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    else
                    {
                        txtVouNo.Text = myInv.VouNo.ToString();

                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormName = "عرض سعر";
                            UserTran.FormAction = "عرض";
                            UserTran.Description = "عرض بيانات عرض السعر رقم " + txtVouNo.Text;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }

                        EditMode();
                        GetInv(myInv);

                        VouData.Clear();
                        PriceListDetails myInv2 = new PriceListDetails();
                        myInv2.VouNo = int.Parse(txtVouNo.Text);
                        double tot = 0;
                        foreach (PriceListDetails itm in myInv2.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            VouData.Add(new PriceListDetails
                            {
                                FNo = itm.FNo,
                                Name = itm.Name,
                                Price = itm.Price,
                                Qty = itm.Qty,
                                Total = itm.Price * itm.Qty,
                                CarType = itm.CarType,
                                Model = itm.Model,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                From2 = itm.From2,
                                To2 = itm.To2
                            });
                            tot += (double)(itm.Price * itm.Qty);
                        }
                        Total20 = string.Format("{0:N2}", tot);

                        DispVouData();
                        ddlItems.SelectedValue = VouData.Count().ToString();
                        ddlItems_SelectedIndexChanged(sender, e);
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


        public void PrintMe(String Number)
        {
            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
            {
                Transactions UserTran = new Transactions();
                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                UserTran.UserName = Session["CurrentUser"].ToString();
                UserTran.FormName = "عرض سعر";
                UserTran.FormAction = "طباعة";
                UserTran.Description = "طباعة بيانات عرض السعر رقم " + Number;
                UserTran.IP = IPNetworking.GetIP4Address();
                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=52&Number=" + Number +  "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
            return;
        }

        protected void BtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (!ValidateInv()) return;
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
                        myArch.LocNumber = short.Parse(AreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 998;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(AreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 998;
                        myArch.FileName = FileUpload1.FileName;
                        myArch.FileName2 = mySetting.ImagePath2 + FileName;
                        myArch.FNo = (short)i;
                        myArch.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormName = "عرض سعر";
                            UserTran.FormAction = "اضافة مرفقات";
                            UserTran.Description = "أضافة مرفقات لعرض السعر رقم " + txtVouNo.Text;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }

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
                myArch.LocNumber = short.Parse(AreaNo);
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = 998;
                myArch.FNo = short.Parse(FNo);
                myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                {
                    Transactions UserTran = new Transactions();
                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                    UserTran.UserName = Session["CurrentUser"].ToString();
                    UserTran.FormName = "عرض سعر";
                    UserTran.FormAction = "الغاء مرفقات";
                    UserTran.Description = "الغاء مرفقات عرض السعر رقم " + txtVouNo.Text;
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
            try
            {
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(Session["Branch"].ToString());
                myArch.LocNumber = short.Parse(AreaNo);
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = 998;
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

        protected void ddlPlaceofLoading_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            try
            {
                if (ddlDestination.SelectedIndex > 0 && ddlPlaceofLoading.SelectedIndex > 0)
                {
                    if (rdoVouType.SelectedIndex == 0)
                    {
                        foreach (GridViewRow gvr in grdCodes.Rows)
                        {
                            DropDownList ddlModel = gvr.FindControl("ddlModel") as DropDownList;
                            if (ddlModel != null)
                            {
                                ddlModel_SelectedIndexChanged(ddlModel, e);
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
             */
        }

        public void PutInv(PriceList myInv)
        {
            myInv.VouNo = int.Parse(txtVouNo.Text);
            myInv.Name = txtName.Text;
            myInv.HDate = txtHDate.Text;
            myInv.GDate = moh.CheckDate(txtGDate.Text);
            myInv.UserName = txtUserName.ToolTip;
            myInv.UserDate = txtUserDate.Text;
            myInv.Subject = txtSubject.Text;
            myInv.VouType = short.Parse(rdoVouType.SelectedValue);
            myInv.PrintTot = ChkPrintTot.Checked;
        }

        public void GetInv(PriceList myInv)
        {
            txtName.Text = myInv.Name;
            rdoVouType.SelectedValue = myInv.VouType.ToString();
            rdoVouType_SelectedIndexChanged(rdoVouType, null);
            txtHDate.Text = myInv.HDate;
            txtGDate.Text = myInv.GDate;
            txtSubject.Text = myInv.Subject;            
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
            ChkPrintTot.Checked = (bool)myInv.PrintTot;
            txtUserDate.Text = myInv.UserDate;
            LoadAttachData();
        }

        protected void ddlItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveGridInfo();
            if (VouData.Count > ddlItems.SelectedIndex + 1)
            {
                for (int i = VouData.Count; i > (ddlItems.SelectedIndex + 1); i--)
                {
                    VouData.RemoveAt(i - 1);
                }
            }
            else
            {
                for (int i = VouData.Count; i <= ddlItems.SelectedIndex; i++)
                {
                    VouData.Add(new PriceListDetails { FNo = (short)(i + 1) });
                }
            }
            DispVouData();
        }

        public void DispVouData()
        {
            grdCodes.DataSource = VouData;
            grdCodes.DataBind();
            for (int i = 0; i < grdCodes.Columns.Count; i++)
            {
                grdCodes.Columns[i].Visible = true;
            }
            if (rdoVouType.SelectedIndex == 0)
            {
                grdCodes.Columns[5].Visible = false;
            }
            else
            {
                grdCodes.Columns[3].Visible = false;
                grdCodes.Columns[4].Visible = false;
            }

            int ii = 1;

            foreach (GridViewRow gvr in grdCodes.Rows)
            {
                DropDownList ddlCarType = gvr.FindControl("ddlCarType") as DropDownList;
                DropDownList ddlModel = gvr.FindControl("ddlModel") as DropDownList;
                DropDownList ddlPlaceofLoading2 = gvr.FindControl("ddlPlaceofLoading") as DropDownList;
                DropDownList ddlDestination2 = gvr.FindControl("ddlDestination") as DropDownList;

                if (ddlCarType != null && ddlModel != null && ddlPlaceofLoading2 != null && ddlDestination2 != null)
                {
                    Cities myCity = new Cities();
                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlDestination2.DataTextField = "Name1";
                    ddlDestination2.DataValueField = "Code";
                    ddlPlaceofLoading2.DataTextField = "Name1";
                    ddlPlaceofLoading2.DataValueField = "Code";
                    ddlDestination2.DataSource = (from itm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                                  orderby itm.Name1
                                                  select itm).ToList();
                    ddlPlaceofLoading2.DataSource = ddlDestination2.DataSource;
                    ddlDestination2.DataBind();
                    ddlPlaceofLoading2.DataBind();
                    ddlDestination2.Items.Insert(0, new ListItem("[" + ii.ToString() + "]", "-1", true));
                    ddlPlaceofLoading2.Items.Insert(0, new ListItem("[" + ii.ToString() + "]", "-1", true));

                    ddlDestination2.SelectedValue = VouData[ii - 1].Destination;
                    ddlPlaceofLoading2.SelectedValue = VouData[ii - 1].PlaceofLoading;

                    CarType myCarType = new CarType();
                    myCarType.cnn = WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString;
                    myCarType.Branch = short.Parse(Session["Branch"].ToString());
                    myCarType.FCode = "";
                    ddlCarType.DataTextField = "Name1";
                    ddlCarType.DataValueField = "Code";
                    ddlCarType.DataSource = myCarType.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlCarType.DataBind();
                    ddlCarType.Items.Insert(0, new ListItem("[" + ii.ToString() + "]", "-1", true));

                    ddlCarType.SelectedValue = VouData[ii-1].CarType;
                    if (ddlCarType.SelectedIndex > 0)
                    {
                        myCarType = new CarType();
                        myCarType.cnn = WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString;
                        myCarType.Branch = short.Parse(Session["Branch"].ToString());
                        myCarType.FCode = ddlCarType.SelectedValue;
                        ddlModel.DataTextField = "Name1";
                        ddlModel.DataValueField = "Code";

                        ddlModel.DataSource = myCarType.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        ddlModel.DataBind();

                        ddlModel.SelectedValue = VouData[ii - 1].Model;
                    }
                }
                ii++;
            }
            if (grdCodes.FooterRow != null)
            {
                Label vlblTotal2 = grdCodes.FooterRow.FindControl("lblTotal2") as Label;
                if (vlblTotal2 != null) vlblTotal2.Text = Total20;
            }
            txtTax.Text = (moh.StrToDouble(Total20) * moh.doTax(txtGDate.Text)).ToString();            
            txtTotal.Text = (moh.StrToDouble(Total20) + moh.StrToDouble(txtTax.Text)).ToString();
        }

        public void SaveGridInfo()
        {
            VouData.Clear();
            int i = 1;
            double tot = 0;
            foreach (GridViewRow gvr in grdCodes.Rows)
            {
                string FNo = grdCodes.DataKeys[gvr.RowIndex]["FNo"].ToString();
                TextBox vtxtName = gvr.FindControl("txtName") as TextBox;
                TextBox vtxtQty = gvr.FindControl("txtQty") as TextBox;
                TextBox vtxtPrice = gvr.FindControl("txtPrice") as TextBox;
                TextBox txtFrom2 = gvr.FindControl("txtFrom2") as TextBox;
                TextBox txtTo2 = gvr.FindControl("txtTo2") as TextBox;
                Label lblTotal = gvr.FindControl("lblTotal") as Label;
                DropDownList ddlCarType = gvr.FindControl("ddlCarType") as DropDownList;
                DropDownList ddlModel = gvr.FindControl("ddlModel") as DropDownList;
                DropDownList ddlPlaceofLoading2 = gvr.FindControl("ddlPlaceofLoading") as DropDownList;
                DropDownList ddlDestination2 = gvr.FindControl("ddlDestination") as DropDownList;

                if (FNo != null && vtxtName != null && vtxtQty != null && vtxtPrice != null && lblTotal != null && txtFrom2 != null && txtTo2 != null && ddlPlaceofLoading2 != null && ddlDestination2 != null)
                {
                    VouData.Add(new PriceListDetails
                    {
                        FNo = (short)i,
                        Name = vtxtName.Text,
                        Qty = moh.StrToInt(vtxtQty.Text),
                        Price = moh.StrToDouble(vtxtPrice.Text),
                        Total = moh.StrToDouble(vtxtPrice.Text) * moh.StrToInt(vtxtQty.Text),
                        CarType = ddlCarType.SelectedValue,
                        Model = ddlModel.SelectedValue,
                        PlaceofLoading = ddlPlaceofLoading2.SelectedValue,
                        Destination = ddlDestination2.SelectedValue,
                        From2 = txtFrom2.Text,
                        To2 = txtTo2.Text
                    });
                    tot += moh.StrToDouble(vtxtPrice.Text) * moh.StrToInt(vtxtQty.Text);
                }
                i++;
                Total20 = string.Format("{0:N2}", tot);
            }

            if (grdCodes.FooterRow != null)
            {
                Label vlblTotal2 = grdCodes.FooterRow.FindControl("lblTotal2") as Label;
                if (vlblTotal2 != null) vlblTotal2.Text = Total20;
            }
            txtTax.Text = (moh.StrToDouble(Total20) * moh.doTax(txtGDate.Text)).ToString();
            txtTotal.Text = (moh.StrToDouble(Total20) + moh.StrToDouble(txtTax.Text)).ToString();
        }

        protected void txtPrice_TextChanged1(object sender, EventArgs e)
        {
            SaveGridInfo();
            DispVouData();
        }

        protected void rdoVouType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveGridInfo();
            DispVouData();
        }

        protected void ddlCarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SaveGridInfo();
                DropDownList ddlCarType = sender as DropDownList;
                if (ddlCarType != null && ddlCarType.SelectedIndex > 0)
                {
                    GridViewRow gvr = ddlCarType.NamingContainer as GridViewRow;
                    string FNo = grdCodes.DataKeys[gvr.RowIndex]["FNo"].ToString();
                    VouData[int.Parse(FNo) - 1].CarType = ddlCarType.SelectedValue;
                    DropDownList ddlModel = gvr.FindControl("ddlModel") as DropDownList;
                    if (ddlModel != null)
                    {
                        CarType myCarType = new CarType();
                        myCarType.cnn = WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString;
                        myCarType.Branch = short.Parse(Session["Branch"].ToString());
                        myCarType.FCode = ddlCarType.SelectedValue;
                        ddlModel.DataTextField = "Name1";
                        ddlModel.DataValueField = "Code";
                        ddlModel.DataSource = myCarType.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        ddlModel.DataBind();
                        VouData[int.Parse(FNo) - 1].Model = ddlModel.SelectedValue;
                        

                        foreach (GridViewRow gvri in grdCodes.Rows)
                        {
                            Label lblTotal = gvri.FindControl("lblTotal") as Label;

                            if (lblTotal != null)
                            {
                                lblTotal.Text = VouData[gvri.RowIndex].Total.ToString();
                            }
                        }
                        ddlModel_SelectedIndexChanged(ddlModel, e);

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


        protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SaveGridInfo(); 
                DropDownList ddlModel = sender as DropDownList;
                if (ddlModel != null)
                {
                    GridViewRow gvr = ddlModel.NamingContainer as GridViewRow;
                    string FNo = grdCodes.DataKeys[gvr.RowIndex]["FNo"].ToString();
                    DropDownList ddlCarType = gvr.FindControl("ddlCarType") as DropDownList;
                    DropDownList ddlPlaceofLoading2 = gvr.FindControl("ddlPlaceofLoading") as DropDownList;
                    DropDownList ddlDestination2 = gvr.FindControl("ddlDestination") as DropDownList;
                    TextBox vtxtPrice = gvr.FindControl("txtPrice") as TextBox;
                    Label lblTotal = gvr.FindControl("lblTotal") as Label;

                    VouData[int.Parse(FNo) - 1].Model = ddlModel.SelectedValue;
                    CarType myCarType = new CarType();
                    myCarType.cnn = WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString;
                    myCarType.Branch = short.Parse(Session["Branch"].ToString());
                    myCarType.Code = ddlModel.SelectedValue;
                    myCarType = myCarType.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myCarType != null && ddlDestination2 != null && ddlPlaceofLoading2 != null && ddlDestination2.SelectedIndex > 0 && ddlPlaceofLoading2.SelectedIndex > 0)
                    {
                        CarPrices myPrice = new CarPrices();
                        myPrice.Branch = short.Parse(Session["Branch"].ToString());
                        myPrice.MonthNo = 0;
                        myPrice.FromCode = ddlPlaceofLoading2.SelectedValue;
                        myPrice.toCode = ddlDestination2.SelectedValue;
                        myPrice.PLevel = myCarType.LevelCode;
                        myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myPrice != null && vtxtPrice != null)
                        {
                            double vPer = 0;
                            /*
                            Offers myOffer = new Offers();
                            myOffer.Branch = short.Parse(Session["Branch"].ToString());                            
                            foreach (Offers itm in myOffer.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                if ((bool)itm.OfferActive)
                                {
                                    if (DateTime.Parse(txtGDate.Text) >= DateTime.Parse(itm.FDate) && DateTime.Parse(txtGDate.Text) <= DateTime.Parse(itm.EDate))
                                    {
                                        vPer = (double)itm.Discount;
                                        if (itm.FTime != "" && itm.ETime != "")
                                        {
                                            if (moh.Nows().TimeOfDay >= TimeSpan.Parse(itm.FTime) && moh.Nows().TimeOfDay <= TimeSpan.Parse(itm.ETime))
                                            {
                                                vPer = (double)itm.Discount;
                                            }
                                            else vPer = 0;
                                        }

                                        break;
                                    }
                                }
                            }
                             */

                            vtxtPrice.Text = (rdoVouType.SelectedValue == "0" ? (myPrice.HOneWay + (myPrice.HOneWay * vPer / 100)).ToString() : (myPrice.HTwoWay + (myPrice.HTwoWay * vPer / 100)).ToString());
                            //txtPrice2.Value = (rdoVouType.SelectedValue == "0" ? (myPrice.LOneWay + (myPrice.LOneWay * vPer / 100)).ToString() : (myPrice.LTwoWay + (myPrice.LTwoWay * vPer / 100)).ToString());
                            VouData[int.Parse(FNo) - 1].Price = moh.StrToDouble(vtxtPrice.Text);
                            VouData[int.Parse(FNo) - 1].Total = VouData[int.Parse(FNo) - 1].Price * VouData[int.Parse(FNo) - 1].Qty;
                            lblTotal.Text = VouData[int.Parse(FNo) - 1].Total.ToString();
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

        protected void ChkLoc_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkLoc.Checked)
            {
                SaveGridInfo();
                if (VouData.Count() > 0)
                {
                    if (VouData[0].PlaceofLoading != "" && VouData[0].PlaceofLoading != "-1")
                    {
                        for (int i = 1; i < VouData.Count(); i++)
                        {
                            VouData[i].PlaceofLoading = VouData[0].PlaceofLoading;
                            VouData[i].Destination = VouData[0].Destination;
                            VouData[i].From2 = VouData[0].From2;
                            VouData[i].To2 = VouData[0].To2;
                        }
                    }
                }
                DispVouData();
            }
        }

        protected void grdList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                string Code = grdList.DataKeys[e.NewSelectedIndex]["VouNo"].ToString();
                txtSearch.Text = Code;
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

        protected void grdList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdList.PageIndex = e.NewPageIndex;
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

        public void LoadListData()
        {
            try
            {
                PriceList myacc = new PriceList();
                myacc.Name = (this.ddlName.SelectedIndex == 0 ? "" : ddlName.SelectedItem.Text);
                grdList.DataSource = myacc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                grdList.DataBind();
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

        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName.Text = ddlName.SelectedItem.Text;
            LoadListData();
        }

        protected void txtGDate_TextChanged(object sender, EventArgs e)
        {
            LblTax.Text = moh.doTax(txtGDate.Text, 1);
        }
    }
}