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
using System.Web.UI.HtmlControls;
using System.Web.Configuration;

namespace ACC
{
    public partial class WebJobOrder : System.Web.UI.Page
    {
        public List<JobDetails> VouData
        {
            get
            {
                if (ViewState["VouData"] == null)
                {
                    ViewState["VouData"] = new List<JobDetails>();
                }
                return (List<JobDetails>)ViewState["VouData"];
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

        public short LocType
        {
            get
            {
                if (ViewState["LocType"] == null)
                {
                    ViewState["LocType"] = 2;
                }
                return short.Parse(ViewState["LocType"].ToString());
            }
            set { ViewState["LocType"] = value; }
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
        public string TotalAmount
        {
            get
            {
                if (ViewState["TotalAmount"] == null)
                {
                    ViewState["TotalAmount"] = "0.00";
                }
                return ViewState["TotalAmount"].ToString();
            }
            set { ViewState["TotalAmount"] = value; }
        }
        public string TotalImportAmount
        {
            get
            {
                if (ViewState["TotalImportAmount"] == null)
                {
                    ViewState["TotalImportAmount"] = "0.00";
                }
                return ViewState["TotalImportAmount"].ToString();
            }
            set { ViewState["TotalImportAmount"] = value; }
        }
        public string TotalAm
        {
            get
            {
                if (ViewState["TotalAm"] == null)
                {
                    ViewState["TotalAm"] = "0.00";
                }
                return ViewState["TotalAm"].ToString();
            }
            set { ViewState["TotalAm"] = value; }
        }
        public string TotalAm2
        {
            get
            {
                if (ViewState["TotalAm2"] == null)
                {
                    ViewState["TotalAm2"] = "0.00";
                }
                return ViewState["TotalAm2"].ToString();
            }
            set { ViewState["TotalAm2"] = value; }
        }
        public void EditMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = true; // (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass275 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass245;
            BtnEdit.Visible = true; // (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass272 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass242;
            BtnNew.Visible = false;
            BtnDelete.Visible = true; // (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass273 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass243;

            if (Request.QueryString["FMode"] != null)
            {
                if (Request.QueryString["FMode"].ToString() == "0")
                {
                    if (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0")
                    {

                    }
                    else
                    {
                        if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass40)
                        {
                            BtnEdit.Visible = false;
                            BtnDelete.Visible = false;
                            BtnClear.Visible = false;
                        }
                    }
                }
            }

            if (BtnEdit.Visible || BtnDelete.Visible)
            {
                txtReason.Visible = true;
                ValReason.Enabled = true;
                lblReason.Visible = true;
            }
            //if (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0")
            // {
            //     if (!(bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass272) ControlsOnOff(false);
            // }
            // else if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass242) ControlsOnOff(false);
        }

        public void NewMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = true; // (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass271 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass241;
            BtnDelete.Visible = false;

            txtReason.Visible = false;
            ValReason.Enabled = false;
            lblReason.Visible = false;
            //if (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0")
            //{
            //    if (!(bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass272) ControlsOnOff(true);
            //}
            //else if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass242) ControlsOnOff(true);
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
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttach);

                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "Job Work Order";

                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "الرئيسية", "اختيار", "اختيار بيان امر العمل", "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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

                    lblBranch2.Text = "/" + "00" + short.Parse(StoreNo).ToString();

                    Drivers myDrive = new Drivers();
                    myDrive.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlDriver.DataTextField = "Name2";
                    ddlDriver.DataValueField = "Code";
                    ddlDriver.DataSource = (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()]);
                    ddlDriver.DataBind();
                    ddlDriver.Items.Insert(0, new ListItem("--- أختار السائق ---", "-1", true));  // "WorkShop"

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

                    //BtnNew.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass271 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass241;
                    //BtnEdit.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass272 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass242;
                    //BtnDelete.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass273 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass243;
                    //BtnSearch.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass274 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass244;
                    //BtnFind.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass274 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass244;
                    //BtnPrint.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass275 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass245;

                    Tech myTech = new Tech();                   
                    this.ddlFormen.DataTextField = "Name2";
                    this.ddlFormen.DataValueField = "Code";
                    this.ddlFormen.DataSource = (from itm in myTech.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                                 where (bool)itm.Formen
                                                 select itm).ToList();
                    this.ddlFormen.DataBind();
                    this.ddlFormen.Items.Insert(0, new ListItem("--- أختار مشرف الصيانة ---", "-1", true));  // "WorkShop"

                    CarsType myCarsType = new CarsType();
                    myCarsType.Branch = short.Parse(Session["Branch"].ToString());
                    ddlVehType.DataTextField = "Name1";
                    ddlVehType.DataValueField = "Code";
                    ddlVehType.DataSource = myCarsType.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlVehType.DataBind();
                    ddlVehType.Items.Insert(0,new ListItem("--- Select Vehical Type ---", "-1", true));

                    ddlCar.Items.Insert(0, new ListItem("--- Select Vehical ---", "-1", true));  // "--- Select Vehical ---"

                    if (Request.QueryString["FNum"] != null)
                    {
                        if (Request.QueryString["FMode"] != null)
                        {
                            if (Request.QueryString["FMode"].ToString() == "0")
                            {
                                if (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0")
                                {
                                    BtnEdit.Visible = false;
                                    BtnDelete.Visible = false;
                                    BtnClear.Visible = false;
                                }
                            }
                            else if (Request.QueryString["FMode"].ToString() == "99")
                            {
                                BtnClear_Click(sender, null);
                                txtRepairReq.Text = Request.QueryString["FNum"].ToString();
                                BtnFind2_Click(sender, null);
                                return;
                            }
                        }
                        txtSearch.Text = Request.QueryString["FNum"].ToString();
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
                txtSearch.Text = "";
                ddlDriver.SelectedIndex = 0;
                ddlCar.SelectedIndex = 0;
                ddlFormen.SelectedIndex = 0;
                ddlStatus.SelectedIndex = 0;
                ddlVehType.SelectedIndex = 0;
                txtEndDateTime.Text = "";
                txtKMReading.Text = "";
                txtKMReading2.Text = "";
                txtRemark.Text = "";
                txtRemark1.Text = "";
                txtRepairReq.Text = "";
                txtVouDate.Text = "";
                txtReason.Text = "";
                txtRemark.Text = "";
                txtWorkDone.Text = "";
                txtWorkRequest.Text = "";
                txtCarNo.Text = "";
                for(int i=0; i< this.ChkRepairType.Items.Count; i++)
                {
                    this.ChkRepairType.Items[i].Selected = false;                
                }
                for (int i = 0; i < ChkFaultType.Items.Count; i++)
                {
                    ChkFaultType.Items[i].Selected = false;
                }

                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                if (sender != null)
                {
                    txtVouNo.Text = "";
                    JobWork myJv = new JobWork();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
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

                txtVouDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                txtVouTime.Text = String.Format("{0:HH:mm:ss}", moh.Nows());
                VouData.Clear();
                LoadJobDetailsData();
                LoadAttachData();
                GetData(txtVouNo.Text);
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
            ChkFaultType.Enabled = State;
            //ddlVehType.Enabled = State;
            ddlDriver.Enabled = State;
            //ddlCar.Enabled = State;
            ddlFormen.Enabled = State;
            ddlStatus.Enabled = State;
            //txtCarNo.ReadOnly = !State;
            txtVouDate.ReadOnly = !State;
            txtReason.ReadOnly = !State;
            txtRemark.ReadOnly = !State;
            txtVouDate.ReadOnly = !State;
            txtEndDateTime.ReadOnly = !State;
            txtKMReading.ReadOnly = !State;
            txtKMReading2.ReadOnly = !State;
            txtReason.ReadOnly = !State;
            txtRemark.ReadOnly = !State;
            txtRemark1.ReadOnly = !State;
            txtRepairReq.ReadOnly = !State;
            txtVouDate.ReadOnly = !State;
            txtWorkDone.ReadOnly = !State;
            txtWorkRequest.ReadOnly = !State;
            //grdAttach.Enabled = State;
            foreach (GridViewRow itm in grdAttach.Rows)
            {
                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                if (BtnDelete != null) BtnDelete.Visible = State;
            }
            FileUpload1.Enabled = State;
            BtnAttach.Enabled = State;
        }

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    /*
                    if (ddlDriver.SelectedIndex == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أختيار السائق";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                     */
                    if (this.ddlVehType.SelectedIndex == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أختيار نوع الشاحنة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                    if (this.ddlCar.SelectedIndex == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أختيار الشاحنة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    if (!CheckRepairReq()) return;

                    JobWork myJv = new JobWork();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.VouLoc = short.Parse(StoreNo);
                    myJv.VouNo = int.Parse(txtVouNo.Text);
                    myJv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myJv != null)
                    {
                        if (myJv.UserName == txtUserName.ToolTip)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم بيان التشغيل مكرر";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                        else
                        {
                            myJv = new JobWork();
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
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
                    }

                    if (Saveall(true))
                    {
                        updateCache();
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان اصلاح خارجي", "اضافة", "أضافة بيان الاصلاح رقم " + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                        String vNumber = txtVouNo.Text;
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
                    /*
                    if (ddlDriver.SelectedIndex == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أختيار السائق";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                     */
                    if (this.ddlVehType.SelectedIndex == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أختيار نوع الشاحنة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                    if (this.ddlCar.SelectedIndex == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أختيار الشاحنة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    if (!CheckRepairReq()) return;

                    JobWork myJv = new JobWork();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.VouLoc = short.Parse(StoreNo);
                    myJv.VouNo = int.Parse(txtVouNo.Text);
                    myJv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myJv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم البيان غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        JobDetails jb = new JobDetails();
                        jb.Branch = short.Parse(Session["Branch"].ToString());
                        jb.VouLoc = short.Parse(StoreNo);
                        jb.VouNo = int.Parse(txtVouNo.Text);
                        if (jb.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (Saveall(false))
                            {
                                updateCache();
                                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان اصلاح خارجي", "تعديل", "تعديل بيانات بيان الأصلاح رقم " + lblBranch2.Text + "/" + txtVouNo.Text, txtReason.Text, IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                txtReason.Text = "";
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                                string vNumber = txtVouNo.Text;
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
                    JobWork myJv = new JobWork();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.VouLoc = short.Parse(StoreNo);
                    myJv.VouNo = int.Parse(txtVouNo.Text);
                    myJv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myJv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم البيان غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            txtReason.Text = "";
                            updateCache();
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

                    JobWork myJv = new JobWork();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.VouLoc = short.Parse(StoreNo);
                    myJv.VouNo = int.Parse(vs);
                    BtnClear_Click(null, e);
                    myJv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myJv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم البيان غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        txtVouNo.Text = myJv.VouNo.ToString();
                        txtEndDateTime.Text = myJv.EndDateTime;
                        txtKMReading.Text = myJv.KMReading.ToString();
                        txtKMReading2.Text = myJv.KMReading2.ToString();
                        txtRemark.Text = myJv.Remark;
                        txtWorkRequest.Text = myJv.WorkRequset;
                        txtWorkDone.Text = myJv.WorkDone;
                        txtRepairReq.Text = myJv.RepairReq;
                        txtVouDate.Text = myJv.VouDate;
                        txtVouTime.Text = myJv.VouTime;
                        txtCarNo.Text = myJv.CarNo;

                        string[] FaultType = myJv.FaultType.Split(new []{", "}, StringSplitOptions.None);
                        string[] RepairType = myJv.RepairType.Split(new[] { ", " }, StringSplitOptions.None);

                        foreach (ListItem li in ChkFaultType.Items)
                            li.Selected = FaultType.Contains(li.Text);

                        foreach (ListItem li in ChkRepairType.Items)
                            li.Selected = RepairType.Contains(li.Text);

                        ddlVehType.SelectedValue = int.Parse(myJv.CarNo.Substring(0, 2)).ToString();
                        ddlVehType_SelectedIndexChanged(sender, e);
                        ddlCar.SelectedValue = myJv.CarNo;
                        ddlCar_SelectedIndexChanged(sender, e);
                        ddlDriver.SelectedValue = myJv.DriverNo;
                        ddlFormen.SelectedValue = myJv.Forman;
                        ddlStatus.SelectedIndex = (int)myJv.Status;
                        EditMode();
                        GetData(vs);

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
                        MakeSum();
                    }

                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم البيان";
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

        public void GetData(string vs)
        {
            STS mySts = new STS();
            List<vSTS> ls = new List<vSTS>();
            mySts.Branch = short.Parse(Session["Branch"].ToString());
            mySts.Ftype = 701;
            mySts.RefNo = int.Parse(vs);
            mySts.RefNoLoc = short.Parse(StoreNo);
            mySts.InvType = 0;
            ls = mySts.FindRef(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            TotalAmount = ls.Sum(itm => itm.Amount).ToString();
            grdCodes.DataSource = ls;
            grdCodes.DataBind();

            string[] myList = new string[33];
            myList[0] = GetGlobalResourceObject("FastRepairRes", "Washing").ToString();
            myList[1] = GetGlobalResourceObject("FastRepairRes", "OilsGreas").ToString();
            myList[2] = GetGlobalResourceObject("FastRepairRes", "Punter").ToString();
            myList[3] = GetGlobalResourceObject("FastRepairRes", "MechLabor").ToString();
            myList[4] = GetGlobalResourceObject("FastRepairRes", "NewTires").ToString();
            myList[5] = GetGlobalResourceObject("FastRepairRes", "UsedTires").ToString();
            myList[6] = GetGlobalResourceObject("FastRepairRes", "ComputerChecking").ToString();
            myList[7] = GetGlobalResourceObject("FastRepairRes", "ElecLabor").ToString();
            myList[8] = GetGlobalResourceObject("FastRepairRes", "Battery").ToString();
            myList[9] = GetGlobalResourceObject("FastRepairRes", "LathLabor").ToString();
            myList[10] = GetGlobalResourceObject("FastRepairRes", "DisWater").ToString();
            myList[11] = GetGlobalResourceObject("FastRepairRes", "WeldLabor").ToString();
            myList[12] = GetGlobalResourceObject("FastRepairRes", "SpareParts").ToString();
            myList[13] = GetGlobalResourceObject("FastRepairRes", "WelderLabor").ToString();
            myList[14] = GetGlobalResourceObject("FastRepairRes", "NozelLabor").ToString();
            myList[15] = GetGlobalResourceObject("FastRepairRes", "HydroPiston").ToString();
            myList[16] = GetGlobalResourceObject("FastRepairRes", "Brakes").ToString();
            myList[17] = GetGlobalResourceObject("FastRepairRes", "Danter").ToString();
            myList[18] = GetGlobalResourceObject("FastRepairRes", "Starter").ToString();
            myList[19] = GetGlobalResourceObject("FastRepairRes", "HydroCaps").ToString();
            myList[20] = GetGlobalResourceObject("FastRepairRes", "ACRepair").ToString();
            myList[21] = GetGlobalResourceObject("FastRepairRes", "Raditer").ToString();
            myList[22] = GetGlobalResourceObject("FastRepairRes", "DieselTankWeld").ToString();
            myList[23] = GetGlobalResourceObject("FastRepairRes", "Balance").ToString();
            myList[24] = GetGlobalResourceObject("FastRepairRes", "Wheel5").ToString();
            myList[25] = GetGlobalResourceObject("FastRepairRes", "ChGlass").ToString();
            myList[26] = GetGlobalResourceObject("FastRepairRes", "MVPI").ToString();
            myList[27] = GetGlobalResourceObject("FastRepairRes", "Other").ToString();
            myList[28] = GetGlobalResourceObject("FastRepairRes", "AirBluff").ToString();
            myList[29] = GetGlobalResourceObject("FastRepairRes", "AccEstimates").ToString();
            myList[30] = GetGlobalResourceObject("FastRepairRes", "ConsItems").ToString();
            myList[31] = GetGlobalResourceObject("FastRepairRes", "SeatBeds").ToString();
            myList[32] = GetGlobalResourceObject("FastRepairRes", "Tax").ToString();

            FastRepair fr = new FastRepair();
            List<FRepair> lfr = new List<FRepair>();
            fr.Branch = short.Parse(Session["Branch"].ToString());
            fr.JobOrder = int.Parse(vs);
            lfr = fr.FindRef(myList, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            TotalAm = lfr.Sum(itm => itm.Am).ToString();
            TotalAm2 = (double.Parse(TotalAmount) + double.Parse(TotalAm)).ToString();
            GrdFastRepair.DataSource = lfr;
            GrdFastRepair.DataBind();

            STP myStp = new STP();
            List<vSTP> lp = new List<vSTP>();
            myStp.Branch = short.Parse(Session["Branch"].ToString());
            myStp.Ftype = 503;
            myStp.RefNo = int.Parse(vs);
            myStp.RefNoLoc = short.Parse(StoreNo);
            myStp.InvType = 0;
            lp = myStp.FindRef0(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            TotalImportAmount = lp.Sum(itm => itm.Amount).ToString();
            grdImport.DataSource = lp;
            grdImport.DataBind();

            LoadJobDetailsData();
            LoadAttachData();

            cpeDemo001.Collapsed = false;
            cpeDemo001.ClientState = "false";
            cpeDemo01.Collapsed = false;
            cpeDemo01.ClientState = "false";
            cpeDemo02.Collapsed = false;
            cpeDemo02.ClientState = "false";
            cpeDemo03.Collapsed = false;
            cpeDemo03.ClientState = "false";
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
                    Response.Redirect("GeneralServerError.aspx",false);
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }

        protected void BtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            /*
            try
            {
                PrintMe(txtVouNo.Text);
                return;
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
             */
        }

        private bool Saveall(bool Add)
        {
            try
            {
                JobWork vJv = new JobWork();
                vJv.Branch = short.Parse(Session["Branch"].ToString());
                vJv.VouLoc = short.Parse(StoreNo);
                vJv.VouNo = int.Parse(txtVouNo.Text);
                vJv.DriverNo = ddlDriver.SelectedValue;
                vJv.CarNo = ddlCar.SelectedValue;
                //vJv.VouDate = moh.CheckDate(txtVouDate.Text);
                vJv.FaultType = String.Join(", ", ChkFaultType.Items.Cast<ListItem>()
                                           .Where(i => i.Selected));
                vJv.RepairType = String.Join(", ", this.ChkRepairType.Items.Cast<ListItem>()
                                           .Where(i => i.Selected));

                vJv.EndDateTime = txtEndDateTime.Text;
                vJv.KMReading = moh.StrToInt(txtKMReading.Text);
                vJv.KMReading2 = moh.StrToInt(txtKMReading2.Text);
                vJv.Remark = txtRemark.Text;
                vJv.WorkRequset = txtWorkRequest.Text;
                vJv.WorkDone = txtWorkDone.Text;
                vJv.RepairReq = txtRepairReq.Text;
                vJv.VouDate = moh.CheckDate(txtVouDate.Text);
                vJv.VouTime = txtVouTime.Text;
                vJv.Forman = ddlFormen.SelectedValue;
                vJv.Status = (short)ddlStatus.SelectedIndex;
                bool vret = false;
                if (Add)
                {
                    vret = vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }
                else
                {
                    vret = vJv.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }

                foreach (JobDetails jb in VouData)
                {
                    jb.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }

                return vret;
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
                return false;
            }
        }

        protected void LoadJobDetailsData()
        {
            try
            {
                grdTimeSheet.DataSource = VouData;
                grdTimeSheet.DataBind();
                if (grdTimeSheet.Rows.Count < 1)
                {
                    JobDetails ax = new JobDetails();
                    VouData.Add(ax);
                    grdTimeSheet.DataSource = VouData;
                    grdTimeSheet.DataBind();
                    grdTimeSheet.Rows[0].Visible = false;
                    grdTimeSheet.Rows[0].Controls.Clear();
                    grdTimeSheet.Rows[0].Cells.Clear();
                    VouData.Remove(ax);
                }
                MakeSum();
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
                        myArch.DocType = 990;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(AreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 990;
                        myArch.FileName = FileUpload1.FileName;
                        myArch.FileName2 = mySetting.ImagePath2 + FileName;
                        myArch.FNo = (short)i;
                        myArch.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        if (myArch.FileName.Contains("الفحص الدوري"))
                        {
                            myArch = new Arch();
                            myArch.Branch = short.Parse(Session["Branch"].ToString());
                            myArch.LocNumber = 0;
                            myArch.Number = int.Parse(txtCarNo.Text);
                            myArch.DocType = 999;

                            i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (i == null) i = 1;
                            else i++;

                            myArch = new Arch();
                            myArch.Branch = short.Parse(Session["Branch"].ToString());
                            myArch.LocNumber = 0;
                            myArch.Number = int.Parse(txtCarNo.Text);
                            myArch.DocType = 999;
                            myArch.FileName = FileUpload1.FileName;
                            myArch.FileName2 = mySetting.ImagePath2 + FileName;
                            myArch.FNo = (short)i;
                            myArch.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }

                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان اصلاح خارجي", "اضافة مرفقات", "اضافة مرفقات لبيان اصلاح خارجي رقم " + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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
                myArch.LocNumber = short.Parse(AreaNo);
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = 990;
                myArch.FNo = short.Parse(FNo);
                myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان اصلاح خارجي", "الغاء مرفقات", "الغاء مرفقات لبيان اصلاح خارجي رقم " + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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
            if (txtVouNo.Text != "")
            {
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(Session["Branch"].ToString());
                myArch.LocNumber = short.Parse(AreaNo);
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = 990;
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

        protected void txtCarNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BtnFindCar_Click(sender, null);
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
                        //ddlVehicle.SelectedValue = myCar.Code;
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

        public void PrintMe(String Number)
        {
            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان اصلاح خارجي", "طباعة", "طباعة بيانات بيان اصلاح خارجي رقم " + Number, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=801&LocType=" + LocType.ToString() + "&LocNumber=" + short.Parse(AreaNo).ToString() + "&Number=" + Number + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
            return;
        }

        protected void ddlTech_Init(object sender, EventArgs e)
        {
            DropDownList ddlTech = sender as DropDownList;
            if (ddlTech.Items.Count == 0)
            {
                Tech myTech = new Tech();
                foreach (Tech itm in myTech.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    ddlTech.Items.Add(new ListItem(itm.Name2, itm.Code.ToString()));
                }
                ddlTech.Items.Insert(0, new ListItem("--- Select Technical ---", "-1", true));
            }
        }

        protected void grdTimeSheet_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdTimeSheet.EditIndex = -1;
                LoadJobDetailsData();
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

        protected void grdTimeSheet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string sno = grdTimeSheet.DataKeys[e.RowIndex]["FNo"].ToString();
                VouData.RemoveAt((int)moh.StrToDouble(sno) - 1);
                for (int i = 0; i < VouData.Count; i++)
                {
                    VouData[i].FNo = (short)(i + 1);
                }

                e.Cancel = false;
                LoadJobDetailsData();
                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                LblCodesResult.Text = "لقد تم الغاء البند بنجاح";
                // ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, false), true);
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


        protected void grdTimeSheet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Insert"))
                {
                    ImageButton btnInsert = e.CommandSource as ImageButton;
                    if (btnInsert == null)
                    {
                        if (VouData.Count() < 1) grdTimeSheet_RowCancelingEdit(sender, null);
                        return;
                    }

                    GridViewRow gvr = btnInsert.NamingContainer as GridViewRow;
                    if (gvr == null)
                    {
                        if (VouData.Count() < 1) grdTimeSheet_RowCancelingEdit(sender, null);
                        return;
                    }
                    
                    DropDownList ddlTech = gvr.FindControl("ddlTech") as DropDownList;
                    TextBox txtFDate = gvr.FindControl("txtFDate") as TextBox;
                    TextBox txtFTime = gvr.FindControl("txtFTime") as TextBox;
                    TextBox txtETime = gvr.FindControl("txtETime") as TextBox;
                    TextBox txtRemark0 = gvr.FindControl("txtRemark") as TextBox;


                    if (ddlTech == null || txtFDate == null || txtFTime == null || txtETime == null || txtRemark0 == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        if (VouData.Count() < 1) grdTimeSheet_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    if (ddlTech.SelectedIndex == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أختيار الفني";
                        if (VouData.Count() < 1) grdTimeSheet_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }


                    if (txtFDate.Text == "") 
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أدخال التاريخ";
                        if (VouData.Count() < 1) grdTimeSheet_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    if (txtFTime.Text == "") 
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أدخال وقت البدء بالعمل";
                        if (VouData.Count() < 1) grdTimeSheet_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    if (txtETime.Text == "") 
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أدخال وقت أنتهاء العمل";
                        if (VouData.Count() < 1) grdTimeSheet_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }


                    Tech myTech = new Tech();
                    myTech.Code = int.Parse(ddlTech.SelectedValue);
                    myTech = myTech.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myTech == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الفني غير معرف من قبل";
                        if (VouData.Count() < 1) grdTimeSheet_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }
                    else
                    {
                        JobDetails myAccess = new JobDetails();
                        myAccess.Branch = short.Parse(Session["Branch"].ToString());
                        myAccess.VouLoc = short.Parse(StoreNo);
                        myAccess.VouNo = int.Parse(txtVouNo.Text);
                        myAccess.FNo = (short)(VouData.Count + 1);
                        myAccess.Name = ddlTech.SelectedItem.Text;
                        myAccess.FDate = txtFDate.Text;
                        myAccess.FTime = DateTime.Parse(txtFTime.Text).AddMinutes(1).ToString("HH:mm");
                        myAccess.ETime = DateTime.Parse(txtETime.Text).AddMinutes(1).ToString("HH:mm");
                        myAccess.Price = myTech.HourRate;
                        myAccess.Remark = txtRemark0.Text;
                        VouData.Add(myAccess);
                        LoadJobDetailsData();
                        //MakeSum();

                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تم اضافة البند بنجاح";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, false), true);
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

        public void MakeSum()
        {
            TotIssue.Text = string.Format("{0:N2}", double.Parse(TotalAmount)); 
            TotFast.Text = string.Format("{0:N2}", double.Parse(TotalAm));
            TotTime.Text = string.Format("{0:N2}", VouData.Sum(itm => itm.Amount));
            TotImport.Text = string.Format("{0:N2}", double.Parse(TotalImportAmount) * -1);
            TotAll.Text = string.Format("{0:N2}", (double.Parse(TotalAmount) - double.Parse(TotalImportAmount) + double.Parse(TotTime.Text) + double.Parse(TotalAm)));
        }

        protected void BtnFind2_Click(object sender, ImageClickEventArgs e)
        {
            CheckRepairReq();
        }


        public bool CheckRepairReq()
        {
            try
            {
                RepairReq rq = new RepairReq();
                rq.Branch = short.Parse(Session["Branch"].ToString());
                rq.LocType = (short)(txtRepairReq.Text.Split('/')[0].StartsWith("00") ? 3 : 2);
                rq.VouLoc = short.Parse(txtRepairReq.Text.Split('/')[0]);
                rq.VouNo = int.Parse(txtRepairReq.Text.Split('/')[1]);
                rq = rq.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (rq != null)
                {
                    //
                    JobWork Jb = new JobWork();
                    Jb.RepairReq = txtRepairReq.Text;
                    Jb = Jb.GetByRepairReq(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (Jb != null)
                    {
                        if (Jb.VouNo != int.Parse(txtVouNo.Text))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "طلب الاصلاح مرتبط بأمر تشغيل  رقم " + Jb.VouNo.ToString();
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);

                            txtRepairReq.Text = "";
                            txtCarNo.Text = "";
                            ddlVehType.SelectedIndex = 0;
                            ddlCar.SelectedIndex = 0;
                            return false;
                        }
                    }
                    ddlVehType.SelectedValue = int.Parse(rq.Vehicle.Substring(0, 2)).ToString();
                    ddlVehType_SelectedIndexChanged(ddlVehType, null);
                    txtCarNo.Text = rq.Vehicle;
                    ddlCar.SelectedValue = rq.Vehicle;
                    ddlCar_SelectedIndexChanged(ddlCar, null);
                    ddlDriver.SelectedValue = rq.Driver;
                    return true;
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "لم يتم العثور على طلب الاصلاح";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);

                    txtRepairReq.Text = "";
                    txtCarNo.Text = "";
                    ddlVehType.SelectedIndex = 0;
                    ddlCar.SelectedIndex = 0;
                    return false;
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
                return false;
            }
        }


        protected void ddlVehType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVehType.SelectedIndex > 0)
            {
                Cars myacc = new Cars();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myacc.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myacc.CarsType = int.Parse(ddlVehType.SelectedValue);

                ddlCar.DataTextField = "Name";
                ddlCar.DataValueField = "Code";
                ddlCar.DataSource = (from itm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                     where itm.CarsType == myacc.CarsType
                                     select itm).ToList();
                ddlCar.DataBind();
                ddlCar.Items.Insert(0, new ListItem("--- Select Vehical ---", "-1", true));  // "--- Select Vehical ---"
            }
            else
            {
                ddlCar.Items.Clear();
                ddlCar.Items.Insert(0, new ListItem("--- Select Vehical ---", "-1", true));   // "--- Select Vehical ---"
            }
        }

        protected void ddlCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCarNo.Text = ddlCar.SelectedValue;
            BtnFindCar_Click(sender, null);
        }


        protected void BtnFindCar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (this.txtCarNo.Text != "" && ddlVehType.SelectedIndex > 0)
                {
                    txtCarNo.Text = moh.MakeMask(txtCarNo.Text, 5);
                    Cars myInv = new Cars();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myInv.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myInv.Code = txtCarNo.Text;
                    myInv.CarsType = int.Parse(ddlVehType.SelectedValue);
                    myInv = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                             where sitm.Code == myInv.Code
                             select sitm).FirstOrDefault();
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("CarNotFound").ToString();  // "Car No. Not Found";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    else
                    {
                        ddlCar.SelectedValue = myInv.Code;
                        ddlDriver.SelectedValue = myInv.DriverCode;
                        //txtModel.Text = myInv.Model;
                    }
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            } 
        }

        protected void txtRepairReq_TextChanged(object sender, EventArgs e)
        {
            BtnFind2_Click(sender, null);
        }

        public void updateCache()
        {
            if (HttpRuntime.Cache["WSOverCarMove_" + StoreNo + Session["CNN2"].ToString()] != null) Cache.Remove("WSOverCarMove_" + StoreNo + Session["CNN2"].ToString());
            if (HttpRuntime.Cache["WSOverInCarMove_" + StoreNo + Session["CNN2"].ToString()] != null) Cache.Remove("WSOverInCarMove_" + StoreNo + Session["CNN2"].ToString());
            if (HttpRuntime.Cache["WSOverOutCarMove_" + StoreNo + Session["CNN2"].ToString()] != null) Cache.Remove("WSOverOutCarMove_" + StoreNo + Session["CNN2"].ToString());
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlStatus.SelectedIndex == 2)
            {
                txtEndDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            }
        }
    }
}


//string hobby = GetHobbyFromDB();
//string[] hobbies = hobby.Split(new []{", "}, StringSplitOptions.None);

//foreach (ListItem li in cblHobbies.Items)
//    li.Selected = hobbies.Contains(li.Text);