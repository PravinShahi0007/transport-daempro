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
    public partial class WebClaim : System.Web.UI.Page
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
        public bool Chkall
        {
            get
            {
                if (ViewState["Chkall"] == null)
                {
                    ViewState["Chkall"] = true;
                }
                return (bool)ViewState["Chkall"];
            }
            set { ViewState["Chkall"] = value; }
        }
        public List<Claim> VouData
        {
            get
            {
                if (ViewState["VouData"] == null)
                {
                    ViewState["VouData"] = new List<Claim>();
                }
                return (List<Claim>)ViewState["VouData"];
            }
            set
            {
                ViewState["VouData"] = value;
            }
        }
        public string Tot
        {
            get
            {
                if (ViewState["Tot"] == null)
                {
                    ViewState["Tot"] = "0";
                }
                return ViewState["Tot"].ToString();
            }
            set { ViewState["Tot"] = value; }
        }
        public string TotQty
        {
            get
            {
                if (ViewState["TotQty"] == null)
                {
                    ViewState["TotQty"] = "0";
                }
                return ViewState["TotQty"].ToString();
            }
            set { ViewState["TotQty"] = value; }
        }
        public string TotTax
        {
            get
            {
                if (ViewState["TotTax"] == null)
                {
                    ViewState["TotTax"] = "0";
                }
                return ViewState["TotTax"].ToString();
            }
            set { ViewState["TotTax"] = value; }
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
            txtDocNo.ReadOnly = true;
            txtDocNo.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = true; //&& (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass285;
            BtnEdit.Visible = true; //&& (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass282;
            BtnNew.Visible = false;
            BtnDelete.Visible = true; //&& (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass283;

            if (BtnEdit.Visible || BtnDelete.Visible)
            {
                txtReason.Visible = true;
                ValReason.Enabled = true;
                lblReason.Visible = true;
            }
            //if (!(bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass282) ControlsOnOff(false);
        }

        public void NewMode()
        {
            txtDocNo.ReadOnly = true;
            txtDocNo.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = true; // && (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass281;
            BtnDelete.Visible = false;

            txtReason.Visible = false;
            ValReason.Enabled = false;
            lblReason.Visible = false;
            //if (!(bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass282) ControlsOnOff(true);
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
                    this.Page.Header.Title = "المطالبة المالية";

                    if (Request.QueryString["AreaNo"] != null)
                    {
                        AreaNo = Request.QueryString["AreaNo"].ToString();
                    }
                    else
                    {
                        AreaNo = Session["AreaNo"].ToString();
                    }
                    if (Request.QueryString["StoreNo"] != null)
                    {
                        StoreNo = Request.QueryString["StoreNo"].ToString();
                    }
                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "الرئيسية", "اختيار", "اختيار المطالبة المالية", "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    Acc myAcc = new Acc();
                    myAcc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastACC" + Session["CNN2"].ToString()] == null) Cache.Insert("LastACC" + Session["CNN2"].ToString(), myAcc.GetLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlCustomer.DataTextField = "CustomerName";
                    ddlCustomer.DataValueField = "Customer";
                    ddlCustomer.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                              where itm.Code.StartsWith("1203")
                                              select new vInvError {
                                              Customer = itm.Code,
                                              CustomerName = itm.Name1
                                              }).ToList();
                    ddlCustomer.DataBind();
                    ddlCustomer.Items.Insert(0, new ListItem("--- أختار حساب العميل  ---", "-1", true));

                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    vRoleName = moh.GetCurrentRole(Request.QueryString["AreaNo"].ToString(),(from useritm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                                                                            where useritm.UserName == Session["CurrentUser"].ToString()
                                                                                            select useritm).FirstOrDefault());
                    if (Session[vRoleName] == null)
                    {
                        Response.Redirect("WebNotPrev.aspx", false);
                        return;
                    }

                    //BtnNew.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass281;
                    //BtnEdit.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass282;
                    //BtnDelete.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass283;
                    //BtnSearch.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass284;
                    //BtnFind.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass284;
                    //BtnPrint.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass285;


                    if (Request.QueryString["FNum"] != null)
                    {
                        Claim myJv = new Claim();
                        myJv.DocNo = int.Parse(Request.QueryString["FNum"].ToString());
                        myJv = myJv.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                        if (myJv != null)
                        {
                            BtnPay.HRef = @"~/WebRVou1.aspx?Flag=1&AreaNo=" + moh.MakeMask(myJv.DocLoc.ToString(),5) + "&StoreNo=" + StoreNo + "&Claim=" + Request.QueryString["FNum"].ToString();
                            BtnPay.Visible = true;
                            txtSearch.Text = Request.QueryString["FNum"].ToString();
                            BtnSearch_Click(sender, null);
                        }
                    }
                    else
                    {
                        BtnPay.Visible = false;
                        BtnClear_Click(sender, null);
                    }
                }
                else
                {
                    LblCodesResult.Text = "";
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("GeneralServerError.aspx",false);
            }
        }

        protected void BtnClear_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                NewMode();
                txtDocDate.Text = "";
                ddlCustomer.SelectedIndex = 0;
                txtFDate.Text = "";
                txtEDate.Text = "";
                lblStatus.Text = "";
                txtCustomer.Text = "";
                Tot = "";
                TotQty = "";
                TotTax = "";
                ChkPeriod.Checked = true;
                ChkPeriod_CheckedChanged(sender, e);
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                if (sender != null)
                {
                    txtDocNo.Text = "";
                    Claim myJv = new Claim();
                    int? i = myJv.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
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
                txtDocDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                VouData.Clear();
                LoadVouData(false);
                LoadAttachData();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("GeneralServerError.aspx",false);
            }
        }

        public void ControlsOnOff(bool State)
        {
            txtDocDate.ReadOnly = !State;
        }

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    {
                        if (DateTime.Parse(txtDocDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                    }

                    if (double.Parse(Tot) == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "مبلغ المطالبة يجب ان يكون اكبر من صفر";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;

                    }

                    Claim myJv = new Claim();
                    myJv.DocNo = int.Parse(txtDocNo.Text);
                    myJv = myJv.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myJv != null)
                    {
                        if (myJv.UserName == txtUserName.ToolTip)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم السند مكرر";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                        else
                        {
                            myJv = new Claim();
                            int? i = myJv.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
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

                    if (Saveall())
                    {
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "المطالبة المالية", "اضافة", "اضافة بيانات المطالبة المالية رقم " +  txtDocNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        UpdateCache();
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                        string vNumber = txtDocNo.Text;
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
                Session.Add("Error", ex);
                Response.Redirect("GeneralServerError.aspx",false);
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
                        if (DateTime.Parse(txtDocDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                    }

                    if (double.Parse(Tot) == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "مبلغ المطالبة يجب ان يكون اكبر من صفر";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    Claim myJv = new Claim();
                    myJv.DocNo = int.Parse(txtDocNo.Text);
                    myJv = myJv.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myJv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم المطالبة المالية غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        if (myJv.DocLoc != short.Parse(AreaNo))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لا توجد لك صلاحية لتعديل بيانات المطالبة";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                if (Saveall())
                                {
                                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "المطالبة المالية", "تعديل", "تعديل بيانات المطالبة المالية رقم " + txtDocNo.Text, txtReason.Text, IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                    UpdateCache();
                                    txtReason.Text = "";
                                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                    LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                                    string vNumber = txtDocNo.Text;
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
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("GeneralServerError.aspx",false);
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
                        if (DateTime.Parse(txtDocDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                    }

                    Claim myJv = new Claim();
                    myJv.DocNo = int.Parse(txtDocNo.Text);
                    myJv = myJv.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myJv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم المطالبة المالية غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        myJv.DocNo = int.Parse(txtDocNo.Text);
                        if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "المطالبة المالية", "الغاء", "الغاء المطالبة المالية رقم " + txtDocNo.Text, txtReason.Text, IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            UpdateCache();
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
                //LblCodesResult.ForeColor = System.Drawing.Color.Red;
                //LblCodesResult.Text = ex.Message.ToString();
                Session.Add("Error", ex);
                Response.Redirect("GeneralServerError.aspx",false);
            }
        }

        public void PrintMe(String Number)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=222&Number=" + Number + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
            return;
        }

        protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtSearch.Text != "")
                {
                    bool Prev = false;
                    bool state = false;
                    string vs = txtSearch.Text;
                    BtnClear_Click(sender, e);
                    txtSearch.Text = vs;
                    Claim myJv = new Claim();
                    txtDocNo.Text = txtSearch.Text;
                    myJv.DocNo = int.Parse(txtDocNo.Text);
                    BtnClear_Click(null, e);
                    int InvNo = 0;
                    short InvFNo = 0;
                    foreach(Claim itm in myJv.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        if (itm.FNo == 1)
                        {
                            BtnPay.HRef = @"~/WebRVou1.aspx?Flag=1&AreaNo=" + moh.MakeMask(itm.DocLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&Claim=" + itm.DocNo.ToString();

                            state = (bool)itm.State;
                            if (short.Parse(AreaNo) != itm.DocLoc)
                            { 
                                string vr = ((List<TblRoles>)(Session[vRoleName]))[0].RoleName;
                                if (vr.Contains("الحسابات") || vr.ToLower().Contains("admin") || vr.Contains("مدير التشغيل"))
                                {

                                }
                                else
                                {
                                    Prev = true;
                                    break;
                                }
                            }

                            if (string.IsNullOrEmpty(itm.FDate))
                            {
                                ChkPeriod.Checked = true;
                                txtFDate.Text = "";
                                txtEDate.Text = "";
                            }
                            else
                            {
                                ChkPeriod.Checked = false;
                                txtFDate.Text = itm.FDate;
                                txtEDate.Text = itm.EDate;
                            }
                            ChkPeriod_CheckedChanged(sender, e);
                            txtDocNo.Text = itm.DocNo.ToString();
                            ddlCustomer.SelectedValue = itm.CustCode;
                            txtCustomer.Text = itm.Customer;
                            txtDocDate.Text = itm.DocDate;
                            txtUserDate.Text = itm.UserDate;
                            txtUserName.ToolTip = itm.UserName;
                            TblUsers ax = new TblUsers();
                            if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                            ax.UserName = itm.UserName;
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


                        if (itm.InvLoc == 0)
                        {
                            Jv mJv = new Jv();
                            mJv.Branch = short.Parse(Session["Branch"].ToString());
                            mJv.FType = 100;
                            mJv.LocNumber = 1;
                            mJv.LocType = 1;
                            mJv.Number = (int)itm.InvNo;
                            if (InvNo == mJv.Number)
                            {
                                mJv = (from sitm in mJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                       where sitm.DbCode == itm.CustCode && sitm.FNo != InvFNo
                                       select sitm).FirstOrDefault();
                            }
                            else
                            {
                                mJv = (from sitm in mJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                       where sitm.DbCode == itm.CustCode
                                       select sitm).FirstOrDefault();
                            }
                            if (mJv != null)
                            {
                                InvNo = mJv.Number;
                                InvFNo = mJv.FNo;
                                VouData.Add(new Claim
                                {
                                    DocNo = itm.DocNo,
                                    FNo = itm.FNo,
                                    State = true,
                                    UserName = itm.UserName,
                                    Customer = itm.Customer,
                                    UserDate = itm.UserDate,
                                    Ref = itm.Ref,
                                    Flag = itm.Flag,
                                    InvNo2 = itm.InvNo.ToString(),
                                    amount = mJv.Amount,
                                    FDate = itm.FDate,
                                    EDate = itm.EDate,
                                    InvNo = itm.InvNo,
                                    InvLoc = itm.InvLoc,
                                    Qty = itm.Qty,
                                    DocDate = mJv.FDate,
                                    Destination = "تسوية",
                                    Source = "تسوية",
                                    CustCode = itm.CustCode
                                });
                            }
                        }
                        else
                        {
                            if (itm.Flag == "L")
                            {
                                LShipment inv1 = new LShipment();
                                inv1.Branch = short.Parse(Session["Branch"].ToString());
                                inv1.VouLoc = moh.MakeMask(itm.InvLoc.ToString(), 5);
                                inv1.VouNo = (int)itm.InvNo;
                                inv1 = inv1.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (inv1 != null)
                                {
                                    Cities myCity = new Cities();
                                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                                    myCity.Code = inv1.PlaceofLoading;
                                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                    myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                              where sitm.Code == myCity.Code
                                              select sitm).FirstOrDefault();

                                    Cities myCity2 = new Cities();
                                    myCity2.Branch = short.Parse(Session["Branch"].ToString());
                                    myCity2.Code = inv1.Destination;
                                    myCity2 = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                              where sitm.Code == myCity2.Code
                                              select sitm).FirstOrDefault();

                                    VouData.Add(new Claim
                                    {
                                        DocNo = itm.DocNo,
                                        FNo = itm.FNo,
                                        State = true,
                                        UserName = itm.UserName,
                                        UserDate = itm.UserDate,
                                        Ref = itm.Ref,
                                        Flag = itm.Flag,
                                        InvNo2 = itm.Flag + itm.InvLoc.ToString() + "/" + itm.InvNo.ToString(),
                                        amount = inv1.CustomerAmount,
                                        FDate = itm.FDate,
                                        EDate = itm.EDate,
                                        InvNo = itm.InvNo,
                                        Customer = itm.Customer,
                                        InvLoc = itm.InvLoc,
                                        Qty = inv1.Qty,
                                        DocDate = inv1.GDate,
                                        Destination = myCity2.Name1,
                                        Source = myCity.Name1,
                                        CustCode = itm.CustCode
                                    });
                                }
                            }
                            else if (itm.Flag == "E")
                            {
                                Shipment inv2 = new Shipment();
                                inv2.Branch = short.Parse(Session["Branch"].ToString());
                                inv2.VouLoc = moh.MakeMask(itm.InvLoc.ToString(), 5);
                                inv2.VouNo = (int)itm.InvNo;
                                inv2 = inv2.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (inv2 != null)
                                {
                                    Cities myCity = new Cities();
                                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                                    myCity.Code = inv2.PlaceofLoading;
                                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                    myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                              where sitm.Code == myCity.Code
                                              select sitm).FirstOrDefault();


                                    Cities myCity2 = new Cities();
                                    myCity2.Branch = short.Parse(Session["Branch"].ToString());
                                    myCity2.Code = inv2.Destination;
                                    myCity2 = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                               where sitm.Code == myCity2.Code
                                               select sitm).FirstOrDefault();


                                    VouData.Add(new Claim
                                    {
                                        DocNo = itm.DocNo,
                                        FNo = itm.FNo,
                                        State = true,
                                        UserName = itm.UserName,
                                        UserDate = itm.UserDate,
                                        Ref = itm.Ref,
                                        Flag = itm.Flag,
                                        InvNo2 = itm.Flag + itm.InvLoc.ToString() + "/" + itm.InvNo.ToString(),
                                        amount = inv2.CustomerAmount,
                                        FDate = itm.FDate,
                                        EDate = itm.EDate,
                                        InvNo = itm.InvNo,
                                        Customer = itm.Customer,
                                        InvLoc = itm.InvLoc,
                                        Qty = inv2.Qty,
                                        DocDate = inv2.GDate,
                                        Destination = myCity2.Name1,
                                        Source = myCity.Name1,
                                        CustCode = itm.CustCode
                                    });
                                }
                            }
                            else
                            {
                                Invoice inv = new Invoice();
                                inv.Branch = short.Parse(Session["Branch"].ToString());
                                inv.VouLoc = moh.MakeMask(itm.InvLoc.ToString(), 5);
                                inv.VouNo = (int)itm.InvNo;
                                inv = inv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (inv != null)
                                {
                                    Cities myCity = new Cities();
                                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                                    myCity.Code = inv.PlaceofLoading;
                                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                    myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                              where sitm.Code == myCity.Code
                                              select sitm).FirstOrDefault();

                                    Cities myCity2 = new Cities();
                                    myCity2.Branch = short.Parse(Session["Branch"].ToString());
                                    myCity2.Code = inv.Destination;
                                    myCity2 = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                               where sitm.Code == myCity2.Code
                                               select sitm).FirstOrDefault();


                                    VouData.Add(new Claim
                                    {
                                        DocNo = itm.DocNo,
                                        FNo = itm.FNo,
                                        State = true,
                                        UserName = itm.UserName,
                                        UserDate = itm.UserDate,
                                        Ref = itm.Ref,
                                        Flag = itm.Flag,
                                        InvNo2 = itm.Flag + itm.InvLoc.ToString() + "/" + itm.InvNo.ToString(),
                                        amount = inv.CustomerAmount,
                                        tax = inv.Tax,
                                        Customer = itm.Customer,
                                        FDate = itm.FDate,
                                        EDate = itm.EDate,
                                        InvNo = itm.InvNo,
                                        InvLoc = itm.InvLoc,
                                        Qty = inv.Qty,
                                        DocDate = inv.GDate,
                                        Destination = myCity2.Name1,
                                        Source = myCity.Name1,
                                        CustCode = itm.CustCode
                                    });
                                }
                            }
                        }                        
                    }

                    if (Prev || VouData == null || VouData.Count == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = Prev ? "لا توجد لك صلاحية لعرض بيانات المطالبة" : "رقم المطالبة المالية غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        BtnClear_Click(sender, e);
                    }
                    else
                    {
                        Jv vJv = new Jv();
                        vJv.Branch  = short.Parse(Session["Branch"].ToString());
                        vJv.Claim = int.Parse(txtDocNo.Text);
                        vJv = vJv.JvGetClaim(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                        if (vJv == null)
                        {
                            vJv = new Jv();
                            vJv.Branch = short.Parse(Session["Branch"].ToString());
                            vJv.FType = 101;
                            vJv.LocType = 2;
                            vJv.LocNumber = short.Parse(AreaNo);
                            vJv.InvNo = VouData[0].InvLoc.ToString().Trim() + "/" + VouData[0].InvNo.ToString();
                            vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (vJv == null)
                            {
                                vJv = new Jv();
                                vJv.Branch = short.Parse(Session["Branch"].ToString());
                                vJv.FType = 100;
                                vJv.LocType = 1;
                                vJv.LocNumber = short.Parse(AreaNo);
                                vJv.InvNo = VouData[0].InvLoc.ToString().Trim() + "/" + VouData[0].InvNo.ToString();
                                vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }
                        }

                        lblStatus.Text =  (state && vJv != null  ?
                                           vJv.FType == 100 ? @"<a href='WebJVou.aspx?Flag=0&AreaNo=" + moh.MakeMask(vJv.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + vJv.Number.ToString() + @"' target='_blank'>محصله بالقيد رقم " + vJv.Number.ToString() + @"</a>"
                                           : @"<a href='WebRVou1.aspx?Flag=0&AreaNo=" + moh.MakeMask(vJv.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + vJv.Number.ToString() +@"' target='_blank'>محصله بالسند رقم " + vJv.LocNumber.ToString()+@"/" + vJv.Number.ToString()  + @"</a>" : "غير محصله");
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "المطالبة المالية", "عرض", "عرض بيانات المطالبة المالية رقم " + txtDocNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        EditMode();
                        BtnDelete.Visible = !state;
                        BtnEdit.Visible = !state;
                        BtnPay.Visible = !state;

                        LoadVouData(true);
                        LoadAttachData();
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم المطالبة المالية";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    BtnClear_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
          //      Session.Add("Error", ex);
          //      Response.Redirect("GeneralServerError.aspx",false);
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
                Session.Add("Error", ex);
                Response.Redirect("GeneralServerError.aspx",false);
            }
        }

        protected void BtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    PrintMe(txtDocNo.Text);
                    return;
                }
            }
            catch (Exception ex)
            {
                //LblCodesResult.ForeColor = System.Drawing.Color.Red;
                //LblCodesResult.Text = ex.Message.ToString();
                Session.Add("Error", ex);
                Response.Redirect("GeneralServerError.aspx",false);
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
            }
        }

        private bool Saveall()
        {
            try
            {
                short FNo = 1;
                foreach (Claim itm in VouData)
                {
                    if ((bool)itm.State)
                    { 
                        Claim vJv2 = new Claim();
                        vJv2.DocNo = int.Parse(txtDocNo.Text);
                        vJv2.DocDate = moh.CheckDate(txtDocDate.Text);
                        vJv2.FNo = (short)FNo++;
                        vJv2.CustCode = ddlCustomer.SelectedValue;
                        vJv2.InvNo = itm.InvNo;
                        vJv2.InvLoc = itm.InvLoc;
                        vJv2.Ref = itm.Ref;
                        vJv2.State = false;
                        vJv2.UserName = txtUserName.ToolTip;
                        vJv2.UserDate = txtUserDate.Text;
                        vJv2.FDate = txtFDate.Text;
                        vJv2.EDate = txtEDate.Text;
                        vJv2.Customer = txtCustomer.Text;
                        vJv2.DocLoc = short.Parse(AreaNo);
                        vJv2.Flag = (itm.InvNo2.Substring(0, 1) == "L" || itm.InvNo2.Substring(0, 1) == "E" ? itm.InvNo2.Substring(0, 1) : "");
                        vJv2.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("GeneralServerError.aspx",false);
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
                        myArch.LocNumber = 1;
                        myArch.Number = int.Parse(txtDocNo.Text);
                        myArch.DocType = 222;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = 1;
                        myArch.Number = int.Parse(txtDocNo.Text);
                        myArch.DocType = 222;
                        myArch.FileName = FileUpload1.FileName;
                        myArch.FileName2 = mySetting.ImagePath2 + FileName;
                        myArch.FNo = (short)i;
                        myArch.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "المطالبة المالية", "اضافة مرفقات", "أضافة مرفقات للمطالبة المالية رقم " + txtDocNo.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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
                myArch.LocNumber = 1;
                myArch.Number = int.Parse(txtDocNo.Text);
                myArch.DocType = 222;
                myArch.FNo = short.Parse(FNo);
                myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "المطالبة المالية", "الغاء مرفقات", "الغاء مرفقات المطالبة المالية رقم " + txtDocNo.Text, txtReason.Text, IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                txtReason.Text = "";
                LoadAttachData();
            }
            catch (Exception ex)
            {
                //LblCodesResult.ForeColor = System.Drawing.Color.Red;
                //LblCodesResult.Text = ex.Message.ToString();
                Session.Add("Error", ex);
                Response.Redirect("GeneralServerError.aspx",false);
            }
        }

        public void LoadAttachData()
        {
            if (txtDocNo.Text != "")
            {
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(Session["Branch"].ToString());
                myArch.LocNumber = 1;
                myArch.Number = int.Parse(txtDocNo.Text);
                myArch.DocType = 222;
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


        public void MakeSum(bool flag)
        {
            
            double amount = 0;
            double qty = 0;
            double tax = 0;
            foreach (Claim itm in VouData)
            {
                if (flag || (bool)itm.State)
                {
                    amount += (double)itm.amount0;
                    qty += (double)itm.Qty;
                    tax += (double)itm.tax;
                }
            }
            Tot = string.Format("{0:N2}", amount);
            TotQty = string.Format("{0:N2}", qty);
            TotTax = string.Format("{0:N2}", tax);
            if (grdCodes.FooterRow != null)
            {
                Label lblTot = grdCodes.FooterRow.FindControl("lblTot") as Label;
                Label lblTotQty = grdCodes.FooterRow.FindControl("lblTotQty") as Label;
                Label lblTotTax = grdCodes.FooterRow.FindControl("lblTotTax") as Label;
                if (lblTot != null) lblTot.Text = Tot;
                if (lblTotQty != null) lblTotQty.Text = TotQty;
                if (lblTotTax != null) lblTotTax.Text = TotTax;
            }            
        }

        protected void LoadVouData(bool flag)
        {
            try
            {
                grdCodes.DataSource = VouData;
                grdCodes.DataBind();
                MakeSum(flag);
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

        protected void ChkState_CheckedChanged(object sender, EventArgs e)
        {
            Label FNo = ((CheckBox)sender).NamingContainer.FindControl("lblFNo") as Label;
            VouData[int.Parse(FNo.Text)-1].State = ((CheckBox)sender).Checked;
            LoadVouData(false);
        }

        protected void ChkState2_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < VouData.Count(); i++)
            {
                VouData[i].State = ((CheckBox)sender).Checked;
            }
            Chkall = ((CheckBox)sender).Checked;
            LoadVouData(false);
        }

        protected void ChkPeriod_CheckedChanged(object sender, EventArgs e)
        {
            LblFDate.Visible = !ChkPeriod.Checked;
            LblEDate.Visible = !ChkPeriod.Checked;
            txtFDate.Visible = !ChkPeriod.Checked;
            txtEDate.Visible = !ChkPeriod.Checked;
        }

        protected void BtnProcess_Click(object sender, ImageClickEventArgs e)
        {
            if (ChkPeriod.Checked)
            {
                txtFDate.Text = "";
                txtEDate.Text = "";
            }

            VouData.Clear();
            if (ddlCustomer.SelectedIndex != 0)
            {
                vInvError myInv = new vInvError();
                myInv.VouLoc = "-1";
                myInv.Site = "-1";
                myInv.Customer = ddlCustomer.SelectedValue;
                int i = 1;
                VouData = (from itm in myInv.NotPaidGetAll20(txtFDate.Text, txtEDate.Text, true, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                           where CheckItem(itm.VouNo, short.Parse(itm.VouLoc), (itm.InvNo[0] == 'E' ? "E" : itm.InvNo[0] == 'L' ? "L" : ""))
                           select new Claim
                           {
                               DocNo = int.Parse(txtDocNo.Text),
                               FNo = (short)i++,
                               State = true,
                               CustCode = ddlCustomer.SelectedValue,
                               DocDate = itm.GDate,
                               Ref = "",
                               InvLoc = short.Parse(itm.VouLoc),
                               InvNo = itm.VouNo,
                               InvNo2  = itm.InvNo,
                               amount = itm.CustomerAmount,
                               Qty = itm.Qty,
                               Destination = itm.Destination,
                               Source = itm.Source
                           }).OrderBy(o => DateTime.Parse(o.DocDate)).ThenBy(p => p.InvNo2).ToList();

                Jv myJv = new Jv();
                myJv.DbCode = ddlCustomer.SelectedValue;
                foreach (Jv itm in myJv.JvDBCust(txtFDate.Text, txtEDate.Text, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                      Jv vJv = new Jv();
                      vJv.Branch = short.Parse(Session["Branch"].ToString());
                      vJv.FType = 101;
                      vJv.InvNo = itm.Number.ToString();
                      vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                      if (vJv != null) continue;

                      vJv = new Jv();
                      vJv.Branch = short.Parse(Session["Branch"].ToString());
                      vJv.FType = 100;
                      vJv.InvNo = itm.Number.ToString();
                      vJv = vJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                      if (vJv != null) continue;

                      VouData.Add(new Claim
                           {
                               DocNo = int.Parse(txtDocNo.Text),
                               FNo = (short)i++,
                               State = true,
                               CustCode = ddlCustomer.SelectedValue,
                               DocDate = itm.FDate,
                               Ref = "",
                               InvLoc = 0,
                               InvNo = itm.Number,
                               InvNo2 = itm.Number.ToString(),
                               amount = itm.Amount,
                               Qty = 0,
                               Destination = "تسوية",
                               Source = "تسوية"
                           });               
               }

                int r = 1;
                foreach(Claim itm in VouData)
                {
                    itm.FNo = (short)r++;
                }
            }

            LoadVouData(false);

        }

        public bool CheckItem(int InvNo , short InvLoc, string Flag)
        {
            Claim myClaim = new Claim();
            myClaim.InvNo = InvNo;
            myClaim.InvLoc = InvLoc;
            myClaim.Flag = Flag;
            myClaim = myClaim.GetByInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            return (myClaim == null);
        }

        protected void txtRef_TextChanged(object sender, EventArgs e)
        {
            Label FNo = ((TextBox)sender).NamingContainer.FindControl("lblFNo") as Label;
            VouData[int.Parse(FNo.Text) - 1].Ref = ((TextBox)sender).Text;
            LoadVouData(false);
        }

        protected void BtnPay_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCustomer.SelectedIndex > 0 && txtCustomer.Text == "")
            {
                Claim myClaim = new Claim();
                myClaim.CustCode = ddlCustomer.SelectedValue;
                myClaim = myClaim.GetByCustCode2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myClaim != null) txtCustomer.Text = myClaim.Customer;

                LoadListData();
            }
        }

        protected string UrlHelper(object Number)
        {
            if (Number != null)
            {
                string[] vs = Number.ToString().Split('/');
                if (vs.Count() > 1)
                {
                    if (vs[0][0] == 'L') return "~/WebLShipment.aspx?Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0].Substring(1, vs[0].Length - 1), 5) + "&StoreNo=" + StoreNo;
                    else if (vs[0][0] == 'E') return "~/WebShipment.aspx?Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0].Substring(1, vs[0].Length - 1), 5) + "&StoreNo=" + StoreNo;
                    else return "~/WebInvoice.aspx?Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&StoreNo=" + StoreNo;
                }
                else
                {
                    return "";
                }
            }
            else return "";
        }

        protected void grdList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                string Code = grdList.DataKeys[e.NewSelectedIndex]["DocNo"].ToString();
                txtSearch.Text = Code;
                BtnSearch_Click(sender, null);
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
                    Response.Redirect("GeneralServerError.aspx", false);
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

                Claim myacc = new Claim();
                myacc.CustCode = ddlCustomer.SelectedValue;
                grdList.DataSource = myacc.GetForCustCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                grdList.DataBind();
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

        public void UpdateCache()
        {
            if (Cache["ClaimPending" + Session["CNN2"].ToString()] != null) Cache.Remove("ClaimPending" + Session["CNN2"].ToString());
            Claim myClaim = new Claim();
            myClaim.DocLoc = -1;
            Cache.Insert("ClaimPending" + Session["CNN2"].ToString(), myClaim.GetPending(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
        }

    }
}