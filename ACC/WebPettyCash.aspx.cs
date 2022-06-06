using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Configuration;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class WebPettyCash : System.Web.UI.Page
    {
        public string gInTax = "120409001";
        public List<PettyCash> VouData
        {
            get
            {
                if (ViewState["VouData"] == null)
                {
                    ViewState["VouData"] = new List<PettyCash>();
                }
                return (List<PettyCash>)ViewState["VouData"];
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
        public string vAreaNo
        {
            get
            {
                if (ViewState["vAreaNo"] == null)
                {
                    ViewState["vAreaNo"] = "00001";
                }
                return ViewState["vAreaNo"].ToString();
            }
            set { ViewState["vAreaNo"] = value; }
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

            //txtVouNo.ReadOnly = false;
            //txtVouNo.BackColor = System.Drawing.Color.White;

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
                    this.Page.Header.Title = "بيان مصروفات نثرية";

                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "الرئيسية", "اختيار", "اختيار بيان أصلاح خارجي سريع", "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    if (Request.QueryString["AreaNo"] != null)
                    {
                        AreaNo = Request.QueryString["AreaNo"].ToString();
                        vAreaNo = AreaNo;
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
                        if (Session["AreaNo"] != null)
                        {
                            AreaNo = Session["AreaNo"].ToString();
                            vAreaNo = AreaNo;
                            SiteInfo = (CostCenter)Session["SiteInfo"];
                        }
                    }

                    if (Request.QueryString["FType"] != null)
                    {
                        LocType = 3;
                        vAreaNo = "00001";
                        lblBranch2.Text = "/00" + short.Parse(vAreaNo).ToString();
                    }
                    else lblBranch2.Text = "/" + short.Parse(vAreaNo).ToString();


                    if (Request.QueryString["StoreNo"] != null) StoreNo = Request.QueryString["StoreNo"].ToString();

                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    vRoleName = moh.GetCurrentRole(vAreaNo,(from useritm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                                           where useritm.UserName == Session["CurrentUser"].ToString()
                                                           select useritm).FirstOrDefault());
                    if (Session[vRoleName] == null)
                    {
                        Response.Redirect("WebNotPrev.aspx", false);
                        return;
                    }

                    if (LocType == 3)
                    {
                        lblManage1.Text = @"<b>[  أعتماد مدير الصيانة ]</b>";                        
                    }
                    //BtnNew.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass271 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass241;
                    //BtnEdit.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass272 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass242;
                    //BtnDelete.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass273 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass243;
                    //BtnSearch.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass274 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass244;
                    //BtnFind.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass274 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass244;
                    //BtnPrint.Visible = (Request.QueryString["Flag"] != null && Request.QueryString["Flag"].ToString() == "0") ? (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass275 : (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass245;


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
                        }
                        txtSearch.Text = Request.QueryString["FNum"].ToString();
                        BtnSearch_Click(sender, null);

                        if (Request.QueryString["FType2"] != null)
                        {
                            if (Request.QueryString["FType2"].ToString() == "1")
                            {
                                chkAgree1.Enabled = true;
                                txtAgreeRemark1.Enabled = true;
                                BtnAgree1.Enabled = true;
                                BtnDisagree1.Enabled = true;
                            }
                            else if (Request.QueryString["FType2"].ToString() == "2")
                            {
                                txtAgreeRemark2.Enabled = true;
                                chkAgree2.Enabled = true;
                            }
                            else if (Request.QueryString["FType2"].ToString() == "3")
                            {
                                txtAgreeRemark3.Enabled = true;
                                chkAgree3.Enabled = true;
                            }
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
                lblStatus.Text = "";
                txtSearch.Text = "";
                txtVouDate.Text = "";
                txtTotal.Text = "";
                txtReason.Text = "";
                txtRemark2.Text = "";
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                if (sender != null)
                {
                    txtVouNo.Text = "";
                    PettyCash myJv = new PettyCash();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.LocType = LocType;
                    myJv.VouLoc = short.Parse(vAreaNo);
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
                LoadAttachData();

                txtAgreeRemark1.Enabled = false;
                chkAgree1.Enabled = false;
                BtnAgree1.Enabled = false;
                BtnDisagree1.Enabled = false;

                txtAgreeRemark2.Enabled = false;
                chkAgree2.Enabled = false;

                txtAgreeRemark3.Enabled = false;
                chkAgree3.Enabled = false;

                txtAgreeRemark1.Text = "";
                txtAgreeRemark2.Text = "";
                txtAgreeRemark3.Text = "";
                txtAgreeUser1.Text = "";
                txtAgreeUser2.Text = "";
                txtAgreeUser3.Text = "";
                txtAgreeUserDate1.Text = "";
                txtAgreeUserDate2.Text = "";
                txtAgreeUserDate3.Text = "";
                chkAgree1.Checked = false;
                chkAgree2.Checked = false;
                chkAgree3.Checked = false;

                VouData.Clear();
                LoadVouData();

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

        protected void LoadVouData()
        {
            try
            {
                grdCodes.DataSource = VouData;
                grdCodes.DataBind();
                MakeSum();

                if (grdCodes.Rows.Count < 1)
                {
                    PettyCash ax = new PettyCash();
                    VouData.Add(ax);
                    grdCodes.DataSource = VouData;
                    grdCodes.DataBind();
                    grdCodes.Rows[0].Controls.Clear();
                    grdCodes.Rows[0].Cells.Clear();
                    VouData.Remove(ax);
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

        public void ControlsOnOff(bool State)
        {
            txtVouDate.ReadOnly = !State;
            txtReason.ReadOnly = !State;
            txtRemark2.ReadOnly = !State;
            txtVouDate.ReadOnly = !State;
            grdCodes.Enabled = State;
            /*
            foreach (GridViewRow itm in grdAttach.Rows)
            {
                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                if (BtnDelete != null) BtnDelete.Visible = State;
            }
            FileUpload1.Enabled = State;
            BtnAttach.Enabled = State;
             */
        }

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    PettyCash myJv = new PettyCash();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.LocType = LocType;
                    myJv.VouLoc = short.Parse(vAreaNo);
                    myJv.VouNo = int.Parse(txtVouNo.Text);
                    myJv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myJv != null)
                    {
                        if (myJv.UserName == txtUserName.ToolTip)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم بيان المصروفات النثرية مكرر";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                        else
                        {
                            myJv = new PettyCash();
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.LocType = LocType;
                            myJv.VouLoc = short.Parse(vAreaNo);
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

                    if (VouData == null || VouData.Count == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        if (Saveall(true))
                        {
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
                    PettyCash myJv = new PettyCash();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.LocType = LocType;
                    myJv.VouLoc = short.Parse(vAreaNo);
                    myJv.VouNo = int.Parse(txtVouNo.Text);
                    myJv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myJv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم البيان غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        if (VouData == null || VouData.Count == 0)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ أثناء تعديل البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                        else if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (Saveall(true))
                            {
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
                    PettyCash myJv = new PettyCash();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.LocType = LocType;
                    myJv.VouLoc = short.Parse(vAreaNo);
                    myJv.VouNo = int.Parse(txtVouNo.Text);
                    myJv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
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
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان مصروفات نثرية", "الغاء", "الغاء بيانات بيان المصروفات النثرية رقم " + lblBranch2.Text + "/" + txtVouNo.Text, txtReason.Text, IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            txtReason.Text = "";

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
                    PettyCash myJv = new PettyCash();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.LocType = LocType;
                    myJv.VouLoc = short.Parse(vAreaNo);
                    myJv.VouNo = int.Parse(vs);
                    BtnClear_Click(null, e);
                    VouData = myJv.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);                    
                    if (VouData == null || VouData.Count == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم البيان غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        bool vPass = true;
                        if (Request.QueryString["FType2"] == null && ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower() != "admin" && !((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("مدير التشغيل") && !((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("مدير الورشة") && !((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("الحسابات"))
                        {
                            if (myJv.UserName != txtUserName.ToolTip)
                            {
                                vPass = false;
                                Agreement vAgree0 = new Agreement();
                                vAgree0.FType = 802;
                                vAgree0.LocType = LocType;
                                vAgree0.LocNumber = short.Parse(vAreaNo);
                                vAgree0.Number = int.Parse(txtVouNo.Text);
                                foreach (Agreement itm in vAgree0.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                {
                                    if (itm.AgreeUser == txtUserName.ToolTip)
                                    {
                                        vPass = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (!vPass && ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("مراقبي الفروع"))
                        {
                            TblUsers ax2 = new TblUsers();
                            if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax2.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                            ax2.UserName = Session["CurrentUser"].ToString();
                            ax2 = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                  where uitm.UserName == ax2.UserName
                                  select uitm).FirstOrDefault();
                            if (ax2 != null && ax2.MainBran == AreaNo) vPass = true;
                        }
                        if (!vPass)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "المستخدم ليست له صلاحية لعرض البيان";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return; 
                        }

                        LoadVouData();
                        myJv = VouData[0];
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان اصلاح خارجي", "عرض", "عرض بيانات بيان اصلاح خارجي رقم " + lblBranch2.Text + "/" + txtVouNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        EditMode();
                        txtVouNo.Text = myJv.VouNo.ToString();
                        txtVouDate.Text = moh.CheckDate(myJv.VouDate);
                        txtUserDate.Text = myJv.UserDate;
                        txtUserName.ToolTip = myJv.UserName;
                        txtRemark2.Text = myJv.Remark2;
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
                        LoadAttachData();

                        Agreement myAgree = new Agreement();
                        myAgree.FType = 802;
                        myAgree.LocType = LocType;
                        myAgree.LocNumber = short.Parse(vAreaNo);
                        myAgree.Number = int.Parse(txtVouNo.Text);
                        foreach (Agreement itm in myAgree.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (itm.FNo == 1)
                            {
                                txtAgreeRemark1.Text = itm.AgreeRemark;
                                chkAgree1.Checked = (itm.Agree == 1);
                                BtnAgree1.Visible = (itm.Agree == 1);
                                BtnDisagree1.Visible = (itm.Agree != 1);
                                txtAgreeUserDate1.Text = itm.AgreeUserDate;
                                txtAgreeUser1.ToolTip = itm.AgreeUser;

                                ax = new TblUsers();
                                ax.UserName = itm.AgreeUser;
                                ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                      where uitm.UserName == ax.UserName
                                      select uitm).FirstOrDefault();
                                if (ax == null)
                                {
                                    txtAgreeUser1.Text = txtAgreeUser1.ToolTip;
                                }
                                else
                                {
                                    txtAgreeUser1.Text = ax.FName;
                                }
                                if (Request.QueryString["FType2"] == null && Session["CurrentUser"].ToString() != "Admin1" && Session["CurrentUser"].ToString() != "sameh")
                                {
                                    BtnDelete.Visible = false;
                                    BtnEdit.Visible = false;
                                    ControlsOnOff(false);
                                }
                                else
                                {
                                    BtnDelete.Visible = true;
                                    BtnEdit.Visible = true;
                                    ControlsOnOff(true);
                                }
                            }
                            else if (itm.FNo == 2)
                            {
                                txtAgreeRemark2.Text = itm.AgreeRemark;
                                chkAgree2.Checked = (itm.Agree == 1);
                                txtAgreeUserDate2.Text = itm.AgreeUserDate;
                                txtAgreeUser2.ToolTip = itm.AgreeUser;

                                ax = new TblUsers();
                                ax.UserName = itm.AgreeUser;
                                ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                      where uitm.UserName == ax.UserName
                                      select uitm).FirstOrDefault();
                                if (ax == null)
                                {
                                    txtAgreeUser2.Text = txtAgreeUser2.ToolTip;
                                }
                                else
                                {
                                    txtAgreeUser2.Text = ax.FName;
                                    //txtAgreeUser2.Text = ax.FName;
                                }
                                if (Session["CurrentUser"].ToString() != "Admin1" && Session["CurrentUser"].ToString() != "sameh")
                                {
                                    BtnDelete.Visible = false;
                                    BtnEdit.Visible = false;
                                    ControlsOnOff(false);
                                }
                                else
                                {

                                    BtnDelete.Visible = true;
                                    BtnEdit.Visible = true;
                                    ControlsOnOff(true);
                                }
                            }
                            else if (itm.FNo == 3)
                            {
                                txtAgreeRemark3.Text = itm.AgreeRemark;
                                chkAgree3.Checked = (itm.Agree == 1);
                                txtAgreeUserDate3.Text = itm.AgreeUserDate;
                                txtAgreeUser3.ToolTip = itm.AgreeUser;

                                ax = new TblUsers();
                                ax.UserName = itm.AgreeUser;
                                ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                      where uitm.UserName == ax.UserName
                                      select uitm).FirstOrDefault();
                                if (ax == null)
                                {
                                    txtAgreeUser2.Text = txtAgreeUser2.ToolTip;
                                }
                                else
                                {
                                    txtAgreeUser3.Text = ax.FName;
                                    //txtAgreeUser3.Text = ax.FName;
                                }
                                if (Session["CurrentUser"].ToString() != "Admin1")
                                {
                                    BtnDelete.Visible = false;
                                    BtnEdit.Visible = false;
                                    ControlsOnOff(false);
                                }
                            }
                        }

                        Jv vJv = new Jv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 102;
                        vJv.LocType = LocType;
                        vJv.LocNumber = short.Parse(vAreaNo);
                        vJv.InvNo = myJv.VouLoc.ToString()+"/"+myJv.VouNo.ToString();
                        vJv.DocType = 9;                        
                        vJv = vJv.findInvNo30(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (vJv != null)
                        {
                            if (vJv.LocType == 2) lblStatus.Text = "تم أدراج المستند في سند الصرف رقم " + @"<a href='WebPay1.aspx?FType=2&Flag=0&AreaNo=" + moh.MakeMask(vJv.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + vJv.Number.ToString() + @"' target='_blank'>" + vJv.LocNumber.ToString() + @"/" + vJv.Number.ToString() + @"</a>" + " ";
                            else lblStatus.Text = "تم أدراج المستند في سند الصرف رقم " + @"<a href='WebPay1.aspx?FType=200&Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + vJv.Number.ToString() + @"' target='_blank'>" + "00" + vJv.LocNumber.ToString() + @"/" + vJv.Number.ToString() + @"</a>" + " ";
                        }
                        else
                        {
                            vJv = new Jv();
                            vJv.Branch = short.Parse(Session["Branch"].ToString());
                            vJv.FType = 100;
                            vJv.LocType = 1;
                            vJv.LocNumber = short.Parse(vAreaNo);
                            vJv.InvNo = myJv.VouLoc.ToString() + "/" + myJv.VouNo.ToString();
                            vJv.DocType = 9;
                            vJv = vJv.findInvNo20(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (vJv != null)
                            {
                                lblStatus.Text = "تم أدراج المستند في قيد اليومية رقم " + @"<a href='WebJVou.aspx?Flag=0&AreaNo=" + moh.MakeMask(vJv.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + vJv.Number.ToString() + @"' target='_blank'>" + vJv.LocNumber.ToString() + @"/" + vJv.Number.ToString() + @"</a>" + " ";
                            }
                        }

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

        protected void BtnPrint_Click(object sender, ImageClickEventArgs e)
        {
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
                    Response.Redirect("GeneralServerError.aspx", false);
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

        private bool Saveall(bool Add)
        {
            try
            {
                bool vret = false;
                double Tax = 0;
                short FNo = 1;
                Jv vJv = new Jv();
                double Cram = 0;
                foreach (PettyCash itm in VouData)
                {
                    vret = false;
                    itm.Branch = short.Parse(Session["Branch"].ToString());
                    itm.LocType = LocType;
                    itm.VouLoc = short.Parse(vAreaNo);
                    itm.VouNo = int.Parse(txtVouNo.Text);
                    itm.VouDate = moh.CheckDate(txtVouDate.Text);
                    itm.UserName = txtUserName.ToolTip;
                    itm.UserDate = txtUserDate.Text;
                    itm.Remark2 = txtRemark2.Text;
                    itm.FTime = "";
                    if (itm.Code.Split(';').Count() > 1)
                    {
                        itm.Emp = itm.Code.Split(';')[1];
                        itm.Code = itm.Code.Split(';')[0];
                    }
                    vret = itm.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    

                    Acc myAcc = new Acc();
                    Tax += (double)itm.Tax;
                    if (itm.Emp != "")
                    {
                        myAcc.Branch = short.Parse(Session["Branch"].ToString());
                        myAcc.Code = "12050" + itm.Emp;
                        myAcc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }

                    vJv = new Jv();
                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                    vJv.FType = 802;
                    vJv.LocType = LocType;
                    vJv.LocNumber = short.Parse(vAreaNo);
                    vJv.Number = int.Parse(txtVouNo.Text);
                    vJv.Post = 1;
                    vJv.FDate = moh.CheckDate(txtVouDate.Text);
                    vJv.Amount = itm.Amount;
                    vJv.DbCode = itm.Code;
                    vJv.CrCode = "";
                    vJv.Remark = itm.Remark;
                    //if (int.Parse(itm.Code.Substring(0, 1)) > 2)
                    //{
                        vJv.Area = SiteInfo.Area;
                        vJv.CostCenter = SiteInfo.Code;
                        vJv.Project = SiteInfo.Project;
                        vJv.CarNo = "-1";
                        vJv.CostAcc = "-1";
                        vJv.EmpCode = "-1";
                    //}
                    //else
                    //{
                    //    vJv.Area = "-1";
                    //    vJv.CostCenter = "-1";
                    //    vJv.Project = "-1";
                    //    vJv.CostAcc = "-1";
                    //    vJv.EmpCode = "-1";
                    //    vJv.CarNo = "-1";
                    //}
                    if (int.Parse(itm.Code.Substring(0, 1)) > 2 ) vJv.CostAcc = "00001";
                    if (itm.Code == "310102004" || itm.Code == "310102006" || itm.Code == "310102007" || itm.Code == "310102009" || itm.Code == "310102010" || itm.Code == "310102011" ||
                        itm.Code == "310102012" || itm.Code == "310102014" || itm.Code == "310102015" || itm.Code == "310102016" || itm.Code == "310102017" || itm.Code == "310102018" ||
                        itm.Code == "310102021" || itm.Code == "310102022" || itm.Code == "310102023" || itm.Code == "310102024" || itm.Code == "310102025" || itm.Code == "310102026" ||
                        itm.Code == "310102029" || itm.Code == "310102035" || itm.Code == "310102038" || itm.Code == "310102042" || itm.Code == "310201008" || itm.Code == "310201009" ||
                        itm.Code == "310201012" || itm.Code == "310201017" || itm.Code == "310102028")
                    {
                        vJv.CostAcc = "00002";
                    }

                    if (LocType == 3)
                    {
                        vJv.Area = "00001";
                        vJv.CostCenter = "00017";
                    }

                    if (itm.Code == "310201008" || itm.Code == "310201009" || itm.Code == "310201015" || itm.Code == "310201016" || itm.Code == "310201028")
                    {
                        vJv.Area = "00001";
                       vJv.CostCenter = "00016";
                    }

                    if(itm.Code == "240101001" && itm.Emp != "" )
                    {
                        vJv.Area = myAcc.Area;
                        vJv.CostCenter = myAcc.CostCenter;
                        vJv.Project = myAcc.Project;
                        vJv.EmpCode = itm.Emp;
                    }


                    vJv.BankName = "";
                    vJv.ChequeDate = "";
                    vJv.ChequeNo = "";
                    vJv.InvNo = "";
                    Cram += (double)vJv.Amount;
                    vJv.FNo = FNo;
                    vJv.FNo2 = itm.FNo;
                    vJv.UserName = txtUserName.ToolTip;
                    vJv.UserDate = txtUserDate.Text;
                    vJv.DocType = 0;
                    vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    FNo++;
                }

                if (Tax > 0)
                {
                    Acc myAcc = new Acc();
                    myAcc.Branch = short.Parse(Session["Branch"].ToString());
                    myAcc.Code = gInTax;
                    if (myAcc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        vJv = new Jv();
                        vJv.Branch = short.Parse(Session["Branch"].ToString());
                        vJv.FType = 802;
                        vJv.LocType = LocType;
                        vJv.LocNumber = short.Parse(vAreaNo);
                        vJv.Number = int.Parse(txtVouNo.Text);
                        vJv.Post = 1;
                        vJv.FDate = moh.CheckDate(txtVouDate.Text);
                        vJv.Amount = Tax;
                        vJv.DbCode = gInTax;
                        vJv.CrCode = "";
                        vJv.Remark = "";
                        vJv.Area = "-1";
                        vJv.CostCenter = "-1";
                        vJv.Project = "-1";
                        vJv.CostAcc = "-1";
                        vJv.EmpCode = "-1";
                        vJv.CarNo = "-1";
                        vJv.BankName = "";
                        vJv.ChequeDate = "";
                        vJv.ChequeNo = "";
                        vJv.InvNo = "";
                        Cram += (double)vJv.Amount;
                        vJv.FNo = FNo;
                        vJv.FNo2 = 0;
                        vJv.UserName = txtUserName.ToolTip;
                        vJv.UserDate = txtUserDate.Text;
                        vJv.DocType = 0;
                        vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        FNo++;
                    }
                }

                vJv = new Jv();
                vJv.Branch = short.Parse(Session["Branch"].ToString());
                vJv.FType = 802;
                vJv.LocType = LocType;
                vJv.LocNumber = short.Parse(vAreaNo);
                vJv.Number = int.Parse(txtVouNo.Text);
                vJv.Post = 1;
                vJv.FDate = moh.CheckDate(txtVouDate.Text);
                vJv.CrCode = "240101006";
                vJv.DbCode = "";
                vJv.Area = SiteInfo.Area;
                vJv.CostCenter = SiteInfo.Code;
                vJv.Project = SiteInfo.Project;

                if (LocType == 3)
                {
                    vJv.Area = "-1";
                    vJv.CostCenter = "00017";
                }

                vJv.CostAcc = "-1";
                vJv.EmpCode = "-1";
                vJv.Remark = "";
                vJv.BankName = "";
                vJv.ChequeDate = "";
                vJv.ChequeNo = "";
                vJv.Amount = Cram; // moh.StrToDouble(txtNet.Text);
                vJv.FNo = FNo;
                vJv.UserName = txtUserName.ToolTip;
                vJv.UserDate = txtUserDate.Text;
                vJv.DocType = 0;
                vJv.FNo2 = -1;
                FNo++;
                vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                return vret;
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
                        myArch.LocNumber = short.Parse(vAreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = (LocType == 2 ? 190 : 191);

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(vAreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = (LocType == 2 ? 190 : 191);
                        myArch.FileName = FileUpload1.FileName;
                        myArch.FileName2 = mySetting.ImagePath2 + FileName;
                        myArch.FNo = (short)i;
                        myArch.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);


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

        protected void grdAttach_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string FNo = grdAttach.DataKeys[e.RowIndex]["FNo"].ToString();
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(Session["Branch"].ToString());
                myArch.LocNumber = short.Parse(vAreaNo);
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = (LocType == 2 ? 190 : 191);
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
            if (txtVouNo.Text != "")
            {
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(Session["Branch"].ToString());
                myArch.LocNumber = short.Parse(vAreaNo);
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = (LocType == 2 ? 190 : 191);
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


        public void PrintMe(String Number)
        {
            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان مصروفات نثرية", "طباعة", "طباعة بيانات بيان المصروفات النثرية رقم " + Number, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=802&LocType=" + LocType.ToString() + "&LocNumber=" + short.Parse(vAreaNo).ToString() + "&Number=" + Number + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
            return;
        }

        protected void chkAgree1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAgree1.Checked)
                {
                    txtAgreeUser1.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser1.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate1.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Agreement myAgree = new Agreement();
                    myAgree.FType = 802;
                    myAgree.LocType = LocType;
                    myAgree.LocNumber = short.Parse(vAreaNo);
                    myAgree.Number = int.Parse(txtVouNo.Text);
                    myAgree.FNo = 1;
                    myAgree.Agree = 1;
                    myAgree.AgreeRemark = txtAgreeRemark1.Text;
                    myAgree.AgreeUser = txtAgreeUser1.ToolTip;
                    myAgree.AgreeUserDate = txtAgreeUserDate1.Text;
                    if (myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "تم اعتماد المستند بنجاح";

                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.Description = "أعتماد بيان المصروفات النثرية رقم  " + lblBranch2.Text + "/" + txtVouNo.Text;
                        UserTran.FormAction = "أعتماد";
                        UserTran.FormName = "بيان المصروفات النثرية";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, true), true);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "خطأ أثناء تعميد المستند ... حاول مرة أخرى";
                    }
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }

        }

        protected void chkAgree2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAgree2.Checked)
                {
                    txtAgreeUser2.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser2.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate2.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Agreement myAgree = new Agreement();
                    myAgree.FType = 802;
                    myAgree.LocType = LocType;
                    myAgree.LocNumber = short.Parse(vAreaNo);
                    myAgree.Number = int.Parse(txtVouNo.Text);
                    myAgree.FNo = 2;
                    myAgree.Agree = 1;
                    myAgree.AgreeRemark = txtAgreeRemark2.Text;
                    myAgree.AgreeUser = txtAgreeUser2.ToolTip;
                    myAgree.AgreeUserDate = txtAgreeUserDate2.Text;
                    if (myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "تم اعتماد المستند بنجاح";

                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.Description = "أعتماد بيان المصروفات النثرية رقم  " + lblBranch2.Text + "/" + txtVouNo.Text;
                        UserTran.FormAction = "أعتماد";
                        UserTran.FormName = "بيان المصروفات النثرية";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, true), true);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "خطأ أثناء تعميد المستند ... حاول مرة أخرى";
                    }
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }


        protected void chkAgree3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAgree3.Checked)
                {
                    txtAgreeUser3.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser3.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate3.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Agreement myAgree = new Agreement();
                    myAgree.FType = 802;
                    myAgree.LocType = LocType;
                    myAgree.LocNumber = short.Parse(vAreaNo);
                    myAgree.Number = int.Parse(txtVouNo.Text);
                    myAgree.FNo = 3;
                    myAgree.Agree = 1;
                    myAgree.AgreeRemark = txtAgreeRemark3.Text;
                    myAgree.AgreeUser = txtAgreeUser3.ToolTip;
                    myAgree.AgreeUserDate = txtAgreeUserDate3.Text;
                    if (myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "تم اعتماد المستند بنجاح";

                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.Description = "أعتماد بيان المصروفات النثرية رقم  " + lblBranch2.Text + "/" + txtVouNo.Text;
                        UserTran.FormAction = "أعتماد";
                        UserTran.FormName = "بيان المصروفات النثرية";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, true), true);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "خطأ أثناء تعميد المستند ... حاول مرة أخرى";
                    }
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void grdCodes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdCodes.EditIndex = -1;
                LoadVouData();
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

                    DropDownList ddlCode = gvr.FindControl("ddlCode") as DropDownList;
                    TextBox txtAmount2 = gvr.FindControl("txtAmount2") as TextBox;
                    TextBox txtRemark = gvr.FindControl("txtRemark") as TextBox;
                    TextBox txtTax2 = gvr.FindControl("txtTax2") as TextBox;
                    TextBox txtInvNo2 = gvr.FindControl("txtInvNo2") as TextBox;
                    TextBox txtFDate2 = gvr.FindControl("txtFDate2") as TextBox;

                    if (ddlCode == null || txtAmount2 == null || txtTax2 == null || txtInvNo2 == null || txtFDate2 == null || txtRemark.Text == null)
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                    if (txtAmount2.Text == "") txtAmount2.Text = "0";
                    if (txtTax2.Text == "") txtTax2.Text = "0";

                    PettyCash myAccess = new PettyCash();
                    myAccess.Branch = short.Parse(Session["Branch"].ToString());
                    myAccess.FNo = (short)(VouData.Count + 1);
                    myAccess.Code = ddlCode.SelectedValue;
                    myAccess.Name = ddlCode.SelectedItem.Text;
                    myAccess.Amount = moh.StrToDouble(txtAmount2.Text);
                    myAccess.VouDate = moh.CheckDate(txtVouDate.Text);
                    myAccess.FTime = "";
                    myAccess.FDate = txtFDate2.Text;
                    myAccess.Remark = txtRemark.Text;
                    myAccess.Remark2 = txtRemark2.Text;
                    myAccess.InvNo = txtInvNo2.Text;
                    myAccess.Tax = moh.StrToDouble(txtTax2.Text);
                    myAccess.VouNo = moh.StrToInt(txtVouNo.Text);

                    VouData.Add(myAccess);

                    LoadVouData();
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

        protected void grdCodes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string FNo = grdCodes.DataKeys[e.RowIndex]["FNo"].ToString();

                VouData.RemoveAt((int)moh.StrToDouble(FNo) - 1);
                for (int i = 0; i < VouData.Count; i++)
                {
                    VouData[i].FNo = (short)(i + 1);
                }
                e.Cancel = false;
                LoadVouData();

                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                LblCodesResult.Text = "لقد تم الغاء البند بنجاح";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, false), true);                
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


        protected void dllCode2_Init(object sender, EventArgs e)
        {
            DropDownList ddlCode = sender as DropDownList;
            GridViewRow gvr = ddlCode.NamingContainer as GridViewRow;
            Acc myacc = new Acc();
            myacc.Branch = short.Parse(Session["Branch"].ToString());
            myacc.FCode = "310102";
            ddlCode.DataTextField = "name1";
            ddlCode.DataValueField = "Code";
            ddlCode.DataSource = myacc.GetAllAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            ddlCode.DataBind();
        }

        protected void ddlCode_Init(object sender, EventArgs e)
        {
            DropDownList ddlCode = sender as DropDownList;
            GridViewRow gvr = ddlCode.NamingContainer as GridViewRow;
            List<Acc1> myAccs = new List<Acc1>();
            List<Acc1> la = new List<Acc1>();
            myAccs = moh.PettyCashAccGetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

            foreach (Acc1 itm in myAccs)
            {
                if (!string.IsNullOrEmpty(itm.FCode))
                {
                    Acc myacc = new Acc();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.FCode = itm.FCode;
                    la.AddRange(myacc.GetAllAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                }
            }

            foreach (Acc1 itm in myAccs)
            {
                if (!string.IsNullOrEmpty(itm.Code))
                {
                    Acc myAcc = new Acc();
                    myAcc.Branch = short.Parse(Session["Branch"].ToString());
                    myAcc.Code = itm.Code;
                    if (myAcc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        la.Add(new Acc1
                        {
                            Code = myAcc.Code,
                            Name1 = myAcc.Name1,
                            Name2 = myAcc.Name2
                        });

                        if (itm.Code == "240101001")
                        {
                            List<SEmp> lemp = new List<SEmp>();
                            SEmp myemp = new SEmp();
                            if (Cache["Emps" + Session["CNN2"].ToString()] == null) Cache.Insert("Emps" + Session["CNN2"].ToString(), myemp.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                            lemp = (List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()]);
                            foreach (SEmp eitm in lemp)
                            {
                                la.Add(new Acc1
                                {
                                    Code = myAcc.Code + ";" + eitm.EmpCode,
                                    Name1 = eitm.Name + " " + myAcc.Name1,
                                    Name2 = eitm.Name2 + " " + myAcc.Name2 
                                });
                            }
                        }
                    }
                }
            }

            ddlCode.DataTextField = "name1";
            ddlCode.DataValueField = "Code";
            ddlCode.DataSource = la;
            ddlCode.DataBind();
        }

        public void MakeSum()
        {
            double Amount = 0;
            foreach (PettyCash itm in VouData)
            {
                Amount += (double)(itm.Amount + itm.Tax);
            }
            txtTotal.Text = string.Format("{0:N2}", Amount);
        }

    }
}
