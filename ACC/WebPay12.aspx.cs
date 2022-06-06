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
    public partial class WebPay12 : System.Web.UI.Page
    {
        public short LocType
        {
            get
            {
                if (ViewState["LocType"] == null)
                {
                    ViewState["LocType"] = 1;
                }
                return (short)(ViewState["LocType"]);
            }
            set { ViewState["LocType"] = value; }
        }
        public short LocNumber
        {
            get
            {
                if (ViewState["LocNumber"] == null)
                {
                    ViewState["LocNumber"] = 1;
                }
                return (short)(ViewState["LocNumber"]);
            }
            set { ViewState["LocNumber"] = value; }
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

        public List<Vou> VouData
        {
            get
            {
                if (ViewState["VouData"] == null)
                {
                    ViewState["VouData"] = new List<Vou>();
                }
                return (List<Vou>)ViewState["VouData"];
            }
            set
            {
                ViewState["VouData"] = value;
            }
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

            BtnPrint.Visible = true && (Request.QueryString["FType"].ToString() == "1" ? (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass245 : (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass255);
            BtnEdit.Visible = true && (Request.QueryString["FType"].ToString() == "1" ? (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass242 : (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass252);
            BtnNew.Visible = false;
            BtnDelete.Visible = true && (Request.QueryString["FType"].ToString() == "1" ? (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass243 : (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass253);

            if (BtnEdit.Visible || BtnDelete.Visible)
            {
                txtReason.Visible = true;
                ValReason.Enabled = true;
                lblReason.Visible = true;
            }
            if (!(Request.QueryString["FType"].ToString() == "1" ? (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass242 : (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass252)) ControlsOnOff(false);
        }

        public void NewMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            //txtVouNo.ReadOnly = false;
            //txtVouNo.BackColor = System.Drawing.Color.White;

            BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = true && (Request.QueryString["FType"].ToString() == "1" ? (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass241 : (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass251);
            BtnDelete.Visible = false;

            txtReason.Visible = false;
            ValReason.Enabled = false;
            lblReason.Visible = false;
            if (!(Request.QueryString["FType"].ToString() == "1" ? (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass242 : (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass252)) ControlsOnOff(true);
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
                    if (Request.QueryString["FType"] == null) Response.Redirect("default.aspx");
                    else if (Request.QueryString["FType"].ToString() == "1")
                    {
                        this.Page.Header.Title = "سندات القبض";
                        BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass241;
                        BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass242;
                        BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass243;
                        BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass244;
                        BtnFind.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass244;
                        BtnPrint.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass245;
                        ddlDocType.Visible = false;
                        //BtnInvFind.Visible = false;
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormName = "الرئيسية";
                            UserTran.FormAction = "اختيار";
                            UserTran.Description = "تم اختيار صفحة سندات القبض";
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }
                    }
                    else
                    {
                        if (!(bool)((List<TblRoles>)(Session["Roll"]))[0].Pass25)
                        {
                            Response.Redirect("WebNotPrev.aspx", false);
                            return;
                        }

                        this.Page.Header.Title = "سند صرف شيك";
                        lblHead.Text = "[ سند صرف شيك ]";
                        Label6.Text = "ادفعوا لأمر";
                        BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass251;
                        BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass252;
                        BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass253;
                        BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass254;
                        BtnFind.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass254;
                        BtnPrint.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass255;

                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormName = "الرئيسية";
                            UserTran.FormAction = "اختيار";
                            UserTran.Description = "تم اختيار صفحة سند صرف شيك";
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }
                    }

                    if (Request.QueryString["AreaNo"] != null)
                    {
                        AreaNo = Request.QueryString["AreaNo"].ToString(); ;
                    }
                    else
                    {
                        AreaNo = Session["AreaNo"].ToString();
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

                    Acc myacc = new Acc();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastACC" + Session["CNN2"].ToString()] == null) Cache.Insert("LastACC" + Session["CNN2"].ToString(), myacc.GetLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlDbCode.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                            where itm.FCode.StartsWith("120101") || itm.FCode.StartsWith("120102") || itm.FCode.StartsWith("120103") || itm.FCode.StartsWith("1205") || itm.Code.StartsWith("120502001")
                                            select itm).ToList();
                    ddlDbCode.DataTextField = "Name1";
                    ddlDbCode.DataValueField = "Code";
                    ddlDbCode.DataBind();
                    ddlDbCode.Items.Insert(0, new ListItem("--- أختار البنك  ---", "-1", true));

             
                    LocType = 1;
                    LocNumber = 1;

                    if (Request.QueryString["FNum"] != null)
                    {
                        txtSearch.Text = Request.QueryString["FNum"].ToString();
                        if (Request.QueryString["LocNumber"] != null) LocNumber = short.Parse(Request.QueryString["LocNumber"].ToString());
                        if (Request.QueryString["LocType"] != null) LocType = short.Parse(Request.QueryString["LocType"].ToString());
                        BtnSearch_Click(sender, null);

                        if (Request.QueryString["FType0"] != null)
                        {
                            if (Request.QueryString["FType0"].ToString() == "1")
                            {
                                txtAgreeRemark1.Enabled = true;
                                chkAgree1.Enabled = true;
                            }
                            else if (Request.QueryString["FType0"].ToString() == "2")
                            {
                                txtAgreeRemark2.Enabled = true;
                                chkAgree2.Enabled = true;
                            }
                        }
                    }
                    else
                    {
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
                txtVouNo.Text = "";
                txtSearch.Text = "";
                txtVouDate.Text = "";
                txtReason.Text = "";
                txtAmount.Text = "";
                txtRemark.Text = "";
                txtTotal.Text = "";
                VouData.Clear();
                LoadVouData();
                txtBankName.Text = "";
                txtchqNo.Text = "";
                txtChqDate.Text = "";
                txtPerson.Text = "";
                ddlDocType.SelectedValue = "1";
                ChkCheque.Checked = false;
                ChkCheque_CheckedChanged(sender, e);
                ddlDbCode.SelectedIndex = 0;
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                ChkCheque.Checked = true;
                ChkCheque_CheckedChanged(sender, e);
                NewMode();
                if (sender != null)
                {
                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 102;
                    myJv.LocType = LocType;
                    myJv.LocNumber = LocNumber;
                    int? i = myJv.GetNewNumber(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
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
                LoadTransData();

                txtAgreeRemark1.Enabled = false;
                chkAgree1.Enabled = false;
                txtAgreeRemark2.Enabled = false;
                chkAgree2.Enabled = false;

                txtAgreeRemark1.Text = "";
                txtAgreeRemark2.Text = "";
                txtAgreeUser1.Text = "";
                txtAgreeUser2.Text = "";
                txtAgreeUserDate1.Text = "";                
                txtAgreeUserDate2.Text = "";
                chkAgree1.Checked = false;
                chkAgree2.Checked = false;
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
            txtVouDate.ReadOnly = !State;
            CalendarExtender1.Enabled = State;
            CalendarExtender2.Enabled = State;
            txtReason.ReadOnly = !State;
            txtAmount.ReadOnly = !State;
            txtRemark.ReadOnly = !State;
            grdCodes.Enabled = State;
            txtBankName.ReadOnly = !State;
            txtchqNo.ReadOnly = !State;
            txtChqDate.ReadOnly = !State;
            ChkCheque.Enabled = State;
            ddlDbCode.Enabled = State;
            ddlDocType.Enabled = State;
            txtPerson.ReadOnly = !State;
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
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }
                    }

                    ValidateNum();
                    if (double.Parse(txtAmount.Text) != double.Parse(txtTotal.Text))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "مبلغ الشيك لا يساوي أجمالي الحسابات المدينة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
           
                    }

                    if(VouData.Count()<1)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب إدخال الحسابات المدينة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    }
                    else
                    {
                        List<Jv> ljv = new List<Jv>();
                        Jv myJv = new Jv();
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.FType = 102;
                        myJv.LocType = LocType;
                        myJv.LocNumber = LocNumber;
                        myJv.Number = int.Parse(txtVouNo.Text);
                        ljv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (ljv != null && ljv.Count() > 0)
                        {
                            if (ljv[0].UserName == txtUserName.ToolTip)
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "رقم السند مكرر";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                return;
                            }
                            else
                            {
                                myJv = new Jv();
                                myJv.Branch = short.Parse(Session["Branch"].ToString());
                                myJv.FType = 102;
                                myJv.LocType = LocType;
                                myJv.LocNumber = LocNumber;
                                int? i = myJv.GetNewNumber(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
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

                        if (Saveall())
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.FormName = (Request.QueryString["FType"].ToString() == "1") ? "سند القبض" : "سند الصرف شيكات";
                                UserTran.FormAction = "اضافة";
                                UserTran.Description = "اضافة " + UserTran.FormName + " رقم " + txtVouNo.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }

                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                            SaveTrans(1);
                            string vNumber = txtVouNo.Text;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                            PrintMe(vNumber);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
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
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }
                    }
                    ValidateNum();
                    if (double.Parse(txtAmount.Text) != double.Parse(txtTotal.Text))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "مبلغ الشيك لا يساوي أجمالي الحسابات المدينة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    if(VouData.Count()<1)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب إدخال الحسابات المدينة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    }
                    else
                    {
                        List<Jv> ljv = new List<Jv>();
                        Jv myJv = new Jv();
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.FType = 102;
                        myJv.LocType = LocType;
                        myJv.LocNumber = LocNumber;
                        myJv.Number = int.Parse(txtVouNo.Text);
                        ljv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (ljv == null || ljv.Count() == 0)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم السند غير معرف من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        }
                        else
                        {

                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.FType = 102;
                            myJv.LocType = LocType;
                            myJv.LocNumber = LocNumber;
                            myJv.Number = int.Parse(txtVouNo.Text);
                            if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                foreach (Jv sitm in ljv)
                                {
                                    if (sitm.DbCode != "" && sitm.DocType == 0 && sitm.InvNo != "")
                                    {
                                        List<MyPO> lJv0 = new List<MyPO>();
                                        MyPO inv = new MyPO();
                                        inv.Branch = short.Parse(Session["Branch"].ToString());
                                        if (sitm.InvNo.Split('/')[0] == "01")
                                        {
                                            inv.FType = 6;
                                            inv.LocNumber = short.Parse(sitm.InvNo.Split('/')[0]);
                                        }
                                        else if (sitm.InvNo.Split('/')[0] == "001")
                                        {
                                            inv.FType = 4;
                                            inv.LocNumber = short.Parse(sitm.InvNo.Split('/')[0]);
                                        }
                                        else
                                        {
                                            inv.FType = 2;
                                            inv.LocNumber = short.Parse(sitm.InvNo.Split('/')[0]);
                                        }
                                        inv.Number = int.Parse(sitm.InvNo.Split('/')[1]);
                                        lJv0 = inv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if (lJv0 == null || lJv0.Count == 0)
                                        {
                                        }
                                        else
                                        {
                                            foreach (MyPO itm in lJv0)
                                            {
                                                if (itm.Approved == 3)
                                                {
                                                    MyPO myPo = new MyPO();
                                                    myPo.Branch = short.Parse(Session["Branch"].ToString());
                                                    myPo.FType = inv.FType;
                                                    myPo.LocNumber = itm.LocNumber;
                                                    myPo.Number = itm.Number;
                                                    myPo.FNo = itm.FNo;
                                                    myPo.Approved = 1;
                                                    myPo.UpdateStatus(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                                                    {
                                                        Transactions UserTran = new Transactions();
                                                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                                        UserTran.UserName = Session["CurrentUser"].ToString();
                                                        UserTran.FormName = "طلب دفع";
                                                        UserTran.FormAction = "الغاء";
                                                        UserTran.Description = " الغاء سداد بند طلب دفع رقم " + itm.LocNumber.ToString() + "/" + itm.Number.ToString() + "-" + itm.FNo.ToString();
                                                        UserTran.IP = IPNetworking.GetIP4Address();
                                                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (Saveall())
                                {
                                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                                    {
                                        Transactions UserTran = new Transactions();
                                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                        UserTran.UserName = Session["CurrentUser"].ToString();
                                        UserTran.FormName = (Request.QueryString["FType"].ToString() == "1") ? "سند القبض" : "سند الصرف شيكات";
                                        UserTran.FormAction = "تعديل";
                                        UserTran.Description = "تعديل " + UserTran.FormName + " رقم " + txtVouNo.Text;
                                        UserTran.Reason = txtReason.Text;
                                        UserTran.IP = IPNetworking.GetIP4Address();
                                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                    }
                                    txtReason.Text = "";

                                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                    LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                                    SaveTrans(2);
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
                                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                }
                            }
                            else
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد حدث خطأ أثناء تعديل البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
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
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }
                    }

                    List<Jv> ljv = new List<Jv>();
                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 102;
                    myJv.LocType = LocType;
                    myJv.LocNumber = LocNumber;
                    myJv.Number = int.Parse(txtVouNo.Text);
                    ljv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (ljv == null || ljv.Count() == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم السند غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    }
                    else
                    {
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.FType = 102;
                        myJv.LocType = LocType;
                        myJv.LocNumber = LocNumber;
                        myJv.Number = int.Parse(txtVouNo.Text);
                        if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            foreach (Jv sitm in ljv)
                            {
                                if (sitm.DbCode != "" && sitm.DocType == 0 && sitm.InvNo != "")
                                {
                                    List<MyPO> lJv0 = new List<MyPO>();
                                    MyPO inv = new MyPO();
                                    inv.Branch = short.Parse(Session["Branch"].ToString());
                                    if (sitm.InvNo.Split('/')[0] == "01")
                                    {
                                        inv.FType = 6;
                                        inv.LocNumber = short.Parse(sitm.InvNo.Split('/')[0]);
                                    }
                                    else if (sitm.InvNo.Split('/')[0] == "001")
                                    {
                                        inv.FType = 4;
                                        inv.LocNumber = short.Parse(sitm.InvNo.Split('/')[0]);
                                    }
                                    else
                                    {
                                        inv.FType = 2;
                                        inv.LocNumber = short.Parse(sitm.InvNo.Split('/')[0]);
                                    }
                                    inv.Number = int.Parse(sitm.InvNo.Split('/')[1]);
                                    lJv0 = inv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (lJv0 == null || lJv0.Count == 0)
                                    {
                                    }
                                    else
                                    {
                                        foreach (MyPO itm in lJv0)
                                        {
                                            if (itm.Approved == 3)
                                            {
                                                MyPO myPo = new MyPO();
                                                myPo.Branch = short.Parse(Session["Branch"].ToString());
                                                myPo.FType = inv.FType;
                                                myPo.LocNumber = itm.LocNumber;
                                                myPo.Number = itm.Number;
                                                myPo.FNo = itm.FNo;
                                                myPo.Approved = 1;
                                                myPo.UpdateStatus(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                                                {
                                                    Transactions UserTran = new Transactions();
                                                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                                    UserTran.UserName = Session["CurrentUser"].ToString();
                                                    UserTran.FormName = "طلب دفع";
                                                    UserTran.FormAction = "الغاء";
                                                    UserTran.Description = " الغاء سداد بند طلب دفع رقم " + itm.LocNumber.ToString() + "/" + itm.Number.ToString() + "-" + itm.FNo.ToString();
                                                    UserTran.IP = IPNetworking.GetIP4Address();
                                                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.FormName = (Request.QueryString["FType"].ToString() == "1") ? "سند القبض" : "سند الصرف شيكات";
                                UserTran.FormAction = "الغاء";
                                UserTran.Description = "الغاء " + UserTran.FormName + " رقم " + txtVouNo.Text;
                                UserTran.Reason = txtReason.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }
                            txtReason.Text = "";


                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم الغاء البيانات بنجاح";
                            SaveTrans(3);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ أثناء الغاء البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
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

        public void ValidateNum()
        {
            if (txtAmount.Text.Trim() == "") txtAmount.Text = "0";
            if (txtTotal.Text.Trim() == "") txtTotal.Text = "0";
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
                    List<vJv> lJv = new List<vJv>();
                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 102;
                    myJv.LocType = LocType;
                    myJv.LocNumber = LocNumber;
                    myJv.Number = int.Parse(txtSearch.Text);
                    lJv = myJv.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (lJv == null || lJv.Count == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم السند غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    }
                    else
                    {
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormName = (Request.QueryString["FType"].ToString() == "1") ? "سند القبض" : "سند الصرف شيكات";
                            UserTran.FormAction = "عرض";
                            UserTran.Description = "عرض بيانات " + UserTran.FormName + " رقم " + txtVouNo.Text;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }

                        EditMode();
                        txtVouNo.Text = lJv[0].Number.ToString();
                        txtVouDate.Text = lJv[0].FDate;
                        txtUserDate.Text = lJv[0].UserDate;
                        txtUserName.ToolTip = lJv[0].UserName;
                        TblUsers ax = new TblUsers();
                        if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        ax.UserName = lJv[0].UserName;
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
                        if (Request.QueryString["FType"].ToString() == "1")
                        {
                            //ddlDbCode.SelectedValue = lJv[0].DbCode;
                            //txtCode.Text = lJv[1].CrCode;
                            //txtName.Text = lJv[1].AccName1;
                            //ddlArea.SelectedValue = lJv[1].Area;
                            //ddlCostAcc.SelectedValue = lJv[1].CostAcc;
                            //ddlCostCenter.SelectedValue = lJv[1].CostCenter;
                            //ddlEmp.SelectedValue = lJv[1].EmpCode;
                            //ddlProject.SelectedValue = lJv[1].Project;
                        }
                        else
                        {
                            ddlDbCode.SelectedValue = lJv[lJv.Count-1].CrCode;
                            txtAmount.Text = string.Format("{0:N2}", lJv[lJv.Count - 1].Amount);

                            foreach (vJv itm in lJv)
                            {
                                if (itm.DbCode != "")
                                {
                                    VouData.Add(new Vou
                                    {
                                        Code = itm.DbCode == "" ? itm.CrCode : itm.DbCode,
                                        Credit = itm.DbCode == "" ? (double)itm.Amount : 0,
                                        Debit = itm.DbCode == "" ? 0 : (double)itm.Amount,
                                        CostCenter = itm.CostName1,
                                        CostCenter2 = itm.CostName2,
                                        CostCenterCode = itm.CostCenter,
                                        Project = itm.ProjectName1,
                                        Project2 = itm.ProjectName2,
                                        ProjectCode = itm.Project,
                                        CarNo = itm.CarNo,
                                        CarNo2 = itm.PlateNo,
                                        Area = itm.AreaName1,
                                        Area2 = itm.AreaName2,
                                        AreaCode = itm.Area,
                                        CostAcc = itm.CostAccName1,
                                        CostAcc2 = itm.CostAccName2,
                                        CostAccCode = itm.CostAcc,
                                        Remark = itm.Remark,
                                        InvNo = itm.InvNo,
                                        Name = itm.AccName1,
                                        Name2 = itm.AccName2,
                                        sno = itm.FNo,
                                        InvType = itm.DocType
                                    });
                                }
                            }
                           LoadVouData();
                           //MakeSum();
                        }
                        ddlDocType.SelectedValue = lJv[lJv.Count - 1].DocType.ToString();
                        ddlDocType_SelectedIndexChanged(null, null);
                        txtPerson.Text = lJv[lJv.Count - 1].Person;
                        txtBankName.Text = lJv[lJv.Count - 1].BankName;
                        txtChqDate.Text = lJv[lJv.Count - 1].ChequeDate;
                        txtchqNo.Text = lJv[lJv.Count - 1].ChequeNo;
                        //txtInvNo.Text = lJv[0].InvNo;
                        txtRemark.Text = lJv[lJv.Count - 1].Remark;
                        LoadAttachData();
                        LoadTransData();

                        Agreement myAgree = new Agreement();
                        myAgree.FType = 102;
                        myAgree.LocType = LocType;
                        myAgree.LocNumber = LocNumber;
                        myAgree.Number = int.Parse(txtVouNo.Text);
                        foreach (Agreement itm in myAgree.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (itm.FNo == 1)
                            {
                                txtAgreeRemark1.Text = itm.AgreeRemark;
                                chkAgree1.Checked = (itm.Agree == 1);
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
                                }
                            }
                        }
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم المستند";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
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

        protected void BtnFind_Click(object sender, ImageClickEventArgs e)
        {
            BtnSearch_Click(sender, e);
        }

        public void PrintMe(String Number)
        {
            if (Request.QueryString["FType"].ToString() == "1")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=101&LocType=" + LocType.ToString() + "&LocNumber=" + LocNumber.ToString() + "&Number=" + Number + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=107&LocType=" + LocType.ToString() + "&LocNumber=" + LocNumber.ToString() + "&Number=" + Number + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
            }
            return;
        }

        protected void BtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    SaveTrans(4);
                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = (Request.QueryString["FType"].ToString() == "1") ? "سند القبض" : "سند الصرف شيكات";
                        UserTran.FormAction = "طباعة";
                        UserTran.Description = "طباعة بيانات " + UserTran.FormName + " رقم " + txtVouNo.Text;
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }
                    PrintMe(txtVouNo.Text);
                    return;

                    /*
                    iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, -50, -50, 80, 50);
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
                    if (Request.QueryString["FType"].ToString() == "1")
                    {
                        page.vStr1 = "سند القبض";
                        page.vStr2 = "أستلمنا من";
                    }
                    else
                    {
                        page.vStr1 = "سند الصرف شيكات";
                        page.vStr2 = "صرفنا على";
                    }
                    page.PageNo = "1";
                    page.UserName = Session["FullUser"].ToString();

                    int ColCount = 4;                    
                    var cols = new[] { 275,125, 300, 100 };
                    document.Open();
                    PdfPTable table = new PdfPTable(ColCount);
                    table.TotalWidth = document.PageSize.Width; //100f;
                    table.SetWidths(cols);
                    PdfPCell cell = new PdfPCell();
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell.FixedHeight = 20f;

                    //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";                    
                    BaseFont nationalBase;
                    nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    //cell.Border = 0;
                    cell.Phrase = new iTextSharp.text.Phrase("رقم السند", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(txtVouNo.Text, nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("التاريخ", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(txtVouDate.Text, nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase(page.vStr2, nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(txtName.Text, nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("رقم المستند", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(txtInvNo.Text, nationalTextFont);
                    table.AddCell(cell);


                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("المنطقة", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if(ddlArea.SelectedIndex>0) cell.Phrase = new iTextSharp.text.Phrase(ddlArea.SelectedItem.Text, nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("نوع الدفع", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if (ChkCheque.Checked) cell.Phrase = new iTextSharp.text.Phrase("بشيك", nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("نقداً", nationalTextFont);
                    table.AddCell(cell);


                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("الفرع", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if(ddlCostCenter.SelectedIndex>0) cell.Phrase = new iTextSharp.text.Phrase(ddlCostCenter.SelectedItem.Text, nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    if (ChkCheque.Checked) cell.Phrase = new iTextSharp.text.Phrase("تاريخ الشيك", nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if (ChkCheque.Checked) cell.Phrase = new iTextSharp.text.Phrase(txtChqDate.Text, nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);

                    table.AddCell(cell);


                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("المشروع", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if(ddlProject.SelectedIndex>0) cell.Phrase = new iTextSharp.text.Phrase(ddlProject.SelectedItem.Text, nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    if (ChkCheque.Checked) cell.Phrase = new iTextSharp.text.Phrase("رقم الشيك", nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if (ChkCheque.Checked) cell.Phrase = new iTextSharp.text.Phrase(txtchqNo.Text, nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                    table.AddCell(cell);


                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("حساب التكاليف", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if(ddlCostAcc.SelectedIndex>0) cell.Phrase = new iTextSharp.text.Phrase(ddlCostAcc.SelectedItem.Text, nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    if (ChkCheque.Checked) cell.Phrase = new iTextSharp.text.Phrase("مسحوب على بنك", nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if (ChkCheque.Checked) cell.Phrase = new iTextSharp.text.Phrase(txtBankName.Text, nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                    table.AddCell(cell);


                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("الموظف", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    if(ddlEmp.SelectedIndex>0) cell.Phrase = new iTextSharp.text.Phrase(ddlEmp.SelectedItem.Text, nationalTextFont);
                    else cell.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("مبلغ وقدرة", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(txtAmount.Text + " ريال", nationalTextFont);
                    table.AddCell(cell);
                    document.Add(table);

                    cols = new[] { 700, 100 };                    
                    PdfPTable table9 = new PdfPTable(2);
                    table9.TotalWidth = document.PageSize.Width; //100f;
                    table9.SetWidths(cols);
                    PdfPCell cell9 = new PdfPCell();
                    cell9.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    table9.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table9.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    cell9.Phrase = new iTextSharp.text.Phrase("وذلك عن", nationalTextFont);
                    cell9.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    //cell.Border = 0;
                    table9.AddCell(cell9);

                    cell9.Phrase = new iTextSharp.text.Phrase(txtRemark.Text, nationalTextFont);
                    cell9.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    //cell.Border = 0;
                    table9.AddCell(cell9);


                    document.Add(table9);


                    PdfPTable table5 = new PdfPTable(4);
                    table5.TotalWidth = 100f;

                    var cols5 = new[] { 275, 125, 300, 100 };
                    table5.SetWidths(cols5);
                    PdfPCell cell5 = new PdfPCell();
                    cell5.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell5.FixedHeight = 20f;

                    table5.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table5.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    cell5.Phrase = new iTextSharp.text.Phrase("إدخلت بواسطة", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    //cell.Border = 0;
                    table5.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase(txtUserName.Text, nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table5.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("تاريخ الإدخال", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table5.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase(txtUserDate.Text, nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table5.AddCell(cell5);

                    document.Add(table5);
                    document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));

                    PdfPTable table50 = new PdfPTable(5);
                    table50.TotalWidth = 100f;
                    cell5 = new PdfPCell();
                    cols5 = new[] { 150, 150,150, 150, 150 };
                    table50.SetWidths(cols5);
                    cell5.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    table50.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table50.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    cell5.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("المستلم", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Border = 0;
                    table50.AddCell(cell5);


                    cell5.Phrase = new iTextSharp.text.Phrase("الحسابات", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

//
                    cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

//
                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);


                    cell5.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 2;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 2;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    document.Add(table50);
                    document.Close();
                     */
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


        // *************************************************** ITextSharp ****************************************************************
        /*
        public class pdfPage : iTextSharp.text.pdf.PdfPageEventHelper
        {
            public string vStr1, vStr2, vStr3, vStr4, UserName, PageNo , vCompanyName;
            //I create a font object to use within my footer
            protected iTextSharp.text.Font footer
            {
                get
                {
                    // create a basecolor to use for the footer font, if needed.
                    iTextSharp.text.BaseColor grey = new iTextSharp.text.BaseColor(128, 128, 128);
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
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 16f, iTextSharp.text.Font.NORMAL);

                //I use a PdfPtable with 1 column to position my header where I want it
                PdfPTable headerTbl = new PdfPTable(3);
                var cols2 = new[] { 200, 300, 200 };
                headerTbl.SetWidths(cols2);

                headerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                //set the width of the table to be the same as the document
                headerTbl.TotalWidth = doc.PageSize.Width;

                PdfPCell cell2 = new PdfPCell();
                cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell2.Border = 0;
                cell2.PaddingRight = 15;
                cell2.Phrase = new iTextSharp.text.Phrase(vCompanyName, nationalTextFont);
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

        protected void ChkCheque_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                lblChqNo.Visible = ChkCheque.Checked;
                lblChqDate.Visible = ChkCheque.Checked;
                lblBankName.Visible = ChkCheque.Checked;
                txtchqNo.Visible = ChkCheque.Checked;
                txtChqDate.Visible = ChkCheque.Checked;
                txtBankName.Visible = ChkCheque.Checked;
                if (ChkCheque.Checked && ddlDbCode.SelectedIndex > 0) txtBankName.Text = ddlDbCode.SelectedItem.Text;
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

        private bool Saveall()
        {
            int FNo = 1;
            foreach(Vou itm in VouData)
            {
               Jv vJv2 = new Jv();
               vJv2.Branch = short.Parse(Session["Branch"].ToString());
               vJv2.FType = 102;
               vJv2.LocType = LocType;
               vJv2.LocNumber = LocNumber;
               vJv2.FNo = (short)FNo++;
               vJv2.Number = int.Parse(txtVouNo.Text);
               vJv2.Post = 1;
               vJv2.FDate = moh.CheckDate(txtVouDate.Text);
               vJv2.DbCode = itm.Code;
               vJv2.CrCode = "";
               if (!string.IsNullOrEmpty(itm.AreaCode) && itm.AreaCode != "-1") vJv2.Area = itm.AreaCode;
               else vJv2.Area = "-1";
               if (!string.IsNullOrEmpty(itm.CostCenterCode) && itm.CostCenterCode != "-1") vJv2.CostCenter = itm.CostCenterCode;
               else vJv2.CostCenter = "-1";
               if (!string.IsNullOrEmpty(itm.ProjectCode) && itm.ProjectCode != "-1") vJv2.Project = itm.ProjectCode;
               else vJv2.Project = "-1";
               if (!string.IsNullOrEmpty(itm.CostAccCode) && itm.CostAccCode != "-1") vJv2.CostAcc = itm.CostAccCode;
               else vJv2.CostAcc = "-1";
               if (!string.IsNullOrEmpty(itm.EmpCode) && itm.EmpCode != "-1") vJv2.EmpCode = itm.EmpCode;
               else vJv2.EmpCode = "-1";
               if (!string.IsNullOrEmpty(itm.CarNo) && itm.CarNo != "-1") vJv2.CarNo = itm.CarNo;
               else vJv2.CarNo = "-1";
               vJv2.DocType = itm.InvType; // short.Parse(ddlDocType.SelectedValue);
               vJv2.Person = txtPerson.Text;
               vJv2.Remark = itm.Remark;
               vJv2.BankName = txtBankName.Text;
               vJv2.ChequeDate = txtChqDate.Text;
               vJv2.ChequeNo = txtchqNo.Text;
               vJv2.InvNo = itm.InvNo;
               vJv2.Amount = itm.Debit;
               vJv2.UserName = txtUserName.ToolTip;
               vJv2.UserDate = txtUserDate.Text;
               vJv2.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

               if (itm.InvType == 0 && itm.InvNo != "")
               {
                   List<MyPO> lJv0 = new List<MyPO>();
                   MyPO inv = new MyPO();
                   inv.Branch = short.Parse(Session["Branch"].ToString());
                   if (itm.InvNo.Split('/')[0] == "01")
                   {
                       inv.FType = 6;
                       inv.LocNumber = short.Parse(itm.InvNo.Split('/')[0]);
                   }
                   else if (itm.InvNo.Split('/')[0] == "001")
                   {
                       inv.FType = 4;
                       inv.LocNumber = short.Parse(itm.InvNo.Split('/')[0]);
                   }
                   else
                   {
                       inv.FType = 2;
                       inv.LocNumber = short.Parse(itm.InvNo.Split('/')[0]);
                   }
                   inv.Number = int.Parse(itm.InvNo.Split('/')[1]);
                   lJv0 = inv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                   if (lJv0 == null || lJv0.Count == 0)
                   {
                   }
                   else
                   {
                       foreach (MyPO sitm in lJv0)
                       {
                           if (sitm.Approved == 1)
                           {
                               MyPO myPo = new MyPO();
                               myPo.Branch = short.Parse(Session["Branch"].ToString());
                               myPo.FType = inv.FType;
                               myPo.LocNumber = sitm.LocNumber;
                               myPo.Number = sitm.Number;
                               myPo.FNo = sitm.FNo;
                               myPo.Approved = 3;
                               myPo.UpdateStatus(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                               if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                               {
                                   Transactions UserTran = new Transactions();
                                   UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                   UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                   UserTran.UserName = Session["CurrentUser"].ToString();
                                   UserTran.FormName = "طلب دفع";
                                   UserTran.FormAction = "سداد";
                                   UserTran.Description = " سداد بند طلب دفع رقم " + sitm.LocNumber.ToString() + "/" + sitm.Number.ToString() + "-" + sitm.FNo.ToString();
                                   UserTran.IP = IPNetworking.GetIP4Address();
                                   UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                               }
                           }
                       }
                   }
               }
            }

            Jv vJv = new Jv();
            vJv.Branch = short.Parse(Session["Branch"].ToString());
            vJv.FType = 102;
            vJv.LocType = LocType;
            vJv.LocNumber = LocNumber;
            vJv.Number = int.Parse(txtVouNo.Text);
            vJv.Post = 1;
            vJv.FDate = moh.CheckDate(txtVouDate.Text);
            vJv.CrCode = ddlDbCode.SelectedValue;
            vJv.DbCode = "";
            vJv.Area = "-1";
            vJv.CostCenter = "-1";
            vJv.Project = "-1";
            vJv.CostAcc = "-1";
            vJv.EmpCode = "-1";
            vJv.Remark = txtRemark.Text;
            vJv.BankName = txtBankName.Text;
            vJv.ChequeDate = txtChqDate.Text;
            vJv.ChequeNo = txtchqNo.Text;
            vJv.InvNo = "";
            vJv.Amount = moh.StrToDouble(txtAmount.Text);
            vJv.FNo = (short)FNo++;
            vJv.UserName = txtUserName.ToolTip;
            vJv.UserDate = txtUserDate.Text;
            vJv.Person = txtPerson.Text;
            vJv.DocType = short.Parse(ddlDocType.SelectedValue);
            vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            return true;
        }

        protected void ddlArea_Init(object sender, EventArgs e)
        {
            DropDownList ddlArea = sender as DropDownList;
            if (ddlArea.Items.Count == 0)
            {
                GridViewRow gvr = ddlArea.NamingContainer as GridViewRow;
                string sno = grdCodes.DataKeys[gvr.RowIndex]["sno"].ToString();
                foreach (Area itm in (List<Area>)(HttpRuntime.Cache["LastArea" + HttpContext.Current.Session["CNN2"].ToString()]))
                {
                    ddlArea.Items.Add(new ListItem(itm.Name1, itm.Code));
                }
                ddlArea.Items.Insert(0, new ListItem("--- أختار المنطقة---", "-1", true));
                if (VouData[int.Parse(sno) - 1].AreaCode != "") ddlArea.SelectedValue = VouData[int.Parse(sno) - 1].AreaCode;
            }
        }

        protected void ddlCostCenter_Init(object sender, EventArgs e)
        {
            DropDownList ddlCostCenter = sender as DropDownList;
            if (ddlCostCenter.Items.Count == 0)
            {
                GridViewRow gvr = ddlCostCenter.NamingContainer as GridViewRow;
                string sno = grdCodes.DataKeys[gvr.RowIndex]["sno"].ToString();
                foreach (CostCenter itm in (List<CostCenter>)(HttpRuntime.Cache["LastCostCenter" + HttpContext.Current.Session["CNN2"].ToString()]))
                {
                    ddlCostCenter.Items.Add(new ListItem(itm.Name1, itm.Code));
                }
                ddlCostCenter.Items.Insert(0, new ListItem("--- أختار الفرع---", "-1", true));
                if (VouData[int.Parse(sno) - 1].CostCenterCode != "") ddlCostCenter.SelectedValue = VouData[int.Parse(sno) - 1].CostCenterCode;
            }
        }

        protected void ddlProject_Init(object sender, EventArgs e)
        {
            DropDownList ddlProject = sender as DropDownList;
            if (ddlProject.Items.Count == 0)
            {
                GridViewRow gvr = ddlProject.NamingContainer as GridViewRow;
                string sno = grdCodes.DataKeys[gvr.RowIndex]["sno"].ToString();
                foreach (AccProject itm in (List<AccProject>)(HttpRuntime.Cache["LastProject" + HttpContext.Current.Session["CNN2"].ToString()]))
                {
                    ddlProject.Items.Add(new ListItem(itm.Name1, itm.Code));
                }
                ddlProject.Items.Insert(0, new ListItem("--- أختار المشروع---", "-1", true));
                if (VouData[int.Parse(sno) - 1].ProjectCode != "") ddlProject.SelectedValue = VouData[int.Parse(sno) - 1].ProjectCode;
            }
        }

        protected void ddlCarNo_Init(object sender, EventArgs e)
        {
            DropDownList ddlCarNo = sender as DropDownList;
            if (ddlCarNo.Items.Count == 0)
            {
                GridViewRow gvr = ddlCarNo.NamingContainer as GridViewRow;
                string sno = grdCodes.DataKeys[gvr.RowIndex]["sno"].ToString();
                Cars myCar = new Cars();
                myCar.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                ddlCarNo.DataTextField = "CodeName";
                ddlCarNo.DataValueField = "Code";
                ddlCarNo.DataSource = (from itm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                       orderby itm.Code
                                       select itm).ToList();
                ddlCarNo.DataBind();
                ddlCarNo.Items.Insert(0, new ListItem("--- أختار الشاحنة---", "-1", true));
                if (VouData[int.Parse(sno) - 1].CarNo != "") ddlCarNo.SelectedValue = VouData[int.Parse(sno) - 1].CarNo;
            }
        }

        protected void ddlCostAcc_Init(object sender, EventArgs e)
        {
            DropDownList ddlCostAcc = sender as DropDownList;
            if (ddlCostAcc.Items.Count == 0)
            {
                GridViewRow gvr = ddlCostAcc.NamingContainer as GridViewRow;
                string sno = grdCodes.DataKeys[gvr.RowIndex]["sno"].ToString();
                foreach (CostAcc itm in (List<CostAcc>)(HttpRuntime.Cache["LastCostAcc" + HttpContext.Current.Session["CNN2"].ToString()]))
                {
                    ddlCostAcc.Items.Add(new ListItem(itm.Name1, itm.Code));
                }
                ddlCostAcc.Items.Insert(0, new ListItem("--- أختار حساب التكاليف---", "-1", true));
                if (VouData[int.Parse(sno) - 1].CostAccCode != "") ddlCostAcc.SelectedValue = VouData[int.Parse(sno) - 1].CostAccCode;
            }
        }

        protected void ddlEmp_Init(object sender, EventArgs e)
        {
            DropDownList ddlEmp = sender as DropDownList;
            if (ddlEmp.Items.Count == 0)
            {
                GridViewRow gvr = ddlEmp.NamingContainer as GridViewRow;
                string sno = grdCodes.DataKeys[gvr.RowIndex]["sno"].ToString();
                SEmp myemp = new SEmp();
                if (Cache["Emps" + Session["CNN2"].ToString()] == null) Cache.Insert("Emps" + Session["CNN2"].ToString(), myemp.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                foreach (SEmp itm in (List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()]))
                {
                    ddlEmp.Items.Add(new ListItem(itm.Name, itm.EmpCode.ToString()));
                }
                //ddlEmp.DataTextField = "Name";
                //ddlEmp.DataValueField = "EmpCode";
                //ddlEmp.DataSource = myemp.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                //ddlEmp.DataBind();
                ddlEmp.Items.Insert(0, new ListItem("--- أختار الموظف---", "-1", true));
                if (VouData[int.Parse(sno) - 1].EmpCode != "") ddlEmp.SelectedValue = VouData[int.Parse(sno) - 1].EmpCode;
            }
        }

        protected void ddlEmp2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlEmp = grdCodes.FooterRow.FindControl("ddlEmp2") as DropDownList;
            GridViewRow gvr = ddlEmp.NamingContainer as GridViewRow;
            DropDownList ddlArea2 = gvr.FindControl("ddlArea2") as DropDownList;
            DropDownList ddlCostCenter2 = gvr.FindControl("ddlCostCenter2") as DropDownList;
            DropDownList ddlProject2 = gvr.FindControl("ddlProject2") as DropDownList;

            Acc myAcc = new Acc();
            myAcc.Branch = short.Parse(Session["Branch"].ToString());
            myAcc.Code = "12050" + ddlEmp.SelectedValue;
            if (myAcc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            {
                ddlArea2.SelectedValue = myAcc.Area;
                ddlCostCenter2.SelectedValue = myAcc.CostCenter;
                ddlProject2.SelectedValue = myAcc.Project;
            }
        }

        
        protected void ddlEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlEmp = sender as DropDownList;
            if (ddlEmp.SelectedIndex > 0)
            {
                GridViewRow gvr = ddlEmp.NamingContainer as GridViewRow;
                DropDownList ddlArea2 = gvr.FindControl("ddlArea") as DropDownList;
                DropDownList ddlCostCenter2 = gvr.FindControl("ddlCostCenter") as DropDownList;
                DropDownList ddlProject2 = gvr.FindControl("ddlProject") as DropDownList;

                Acc myAcc = new Acc();
                myAcc.Branch = short.Parse(Session["Branch"].ToString());
                myAcc.Code = "12050" + ddlEmp.SelectedValue;
                if (myAcc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    ddlArea2.SelectedValue = myAcc.Area;
                    ddlCostCenter2.SelectedValue = myAcc.CostCenter;
                    ddlProject2.SelectedValue = myAcc.Project;
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

                    TextBox txtDebit = gvr.FindControl("txtDebit") as TextBox;
                    TextBox txtCode = gvr.FindControl("txtCode") as TextBox;
                    TextBox txtName = gvr.FindControl("txtName") as TextBox;
                    TextBox txtRemark = gvr.FindControl("txtRemark") as TextBox;
                    TextBox txtInvNo = gvr.FindControl("txtInvNo") as TextBox;

                    DropDownList ddlCostCenter = gvr.FindControl("ddlCostCenter2") as DropDownList;
                    DropDownList ddlProject = gvr.FindControl("ddlProject2") as DropDownList;
                    DropDownList ddlEmp = gvr.FindControl("ddlEmp2") as DropDownList;
                    DropDownList ddlArea = gvr.FindControl("ddlArea2") as DropDownList;
                    DropDownList ddlCostAcc = gvr.FindControl("ddlCostAcc2") as DropDownList;
                    TextBox txtCarNo = gvr.FindControl("txtCarNo2") as TextBox;


                    if (txtDebit == null || txtCode == null || txtName == null || txtRemark == null || ddlCostCenter == null || ddlProject == null || ddlEmp == null || ddlArea == null || ddlCostAcc == null || txtCarNo == null || txtInvNo == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    if (txtInvNo.Text != "" && (ddlDocType.SelectedValue== "0" || ddlDocType.SelectedValue == "2" ) && VouData.FindIndex(p => p.InvNo == txtInvNo.Text) > -1)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم المستند مدرج في نفس السند من قبل";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }
                        
                    if (txtDebit.Text == "") txtDebit.Text = "0.00";
                    if (moh.StrToDouble(txtDebit.Text) == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب إدخال مبلغ ";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    Acc myAcc = new Acc();
                    myAcc.Branch = short.Parse(Session["Branch"].ToString());
                    myAcc.Code = txtCode.Text;
                    if (!myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الحساب غير معرف من قبل";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }
                    else
                    {
                        // Check to force Entering of Area
                        if ((bool)myAcc.CheckArea && ddlArea.SelectedIndex > 0)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الحساب مرتبط بمنطقة ... يجب أختيار المنطقة";
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }

                        // Check to force Entering of Cost Center
                        if ((bool)myAcc.CheckCostCenter && ddlCostCenter.SelectedIndex > 0)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الحساب مرتبط بفرع ... يجب أختيار الفرع";
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }

                        // Check to force Entering of Project
                        if ((bool)myAcc.CheckProject && ddlProject.SelectedIndex > 0)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الحساب مرتبط بمشروع ... يجب أختيار المشروع";
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }

                        // Check to force Entering of Cost Acc
                        if ((bool)myAcc.CheckCostAcc && ddlCostAcc.SelectedIndex > 0)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الحساب مرتبط بحسابات التكاليف ... يجب أختيار حساب التكاليف";
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }

                        // Check to force Entering of Emp
                        if ((bool)myAcc.CheckEmp && ddlEmp.SelectedIndex > 0)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الحساب مرتبط بالموظفين ... يجب أختيار الموظف";
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }
                    }

                    Vou myAccess = new Vou();
                    myAccess.sno = (short)(VouData.Count + 1);
                    myAccess.Debit = moh.StrToDouble(txtDebit.Text);
                    myAccess.Credit = 0;
                    myAccess.Code = txtCode.Text;
                    myAccess.Name = txtName.Text;
                    if (ddlProject.SelectedIndex > 0)
                    {
                        myAccess.Project = ddlProject.SelectedItem.Text;
                        myAccess.ProjectCode = ddlProject.SelectedValue;
                    }
                    else
                    {
                        myAccess.Project = "";
                        myAccess.ProjectCode = "-1";
                    }
                    if (ddlCostCenter.SelectedIndex > 0)
                    {
                        myAccess.CostCenter = ddlCostCenter.SelectedItem.Text;
                        myAccess.CostCenterCode = ddlCostCenter.SelectedValue;
                    }
                    else
                    {
                        myAccess.CostCenter = "";
                        myAccess.CostCenterCode = "-1";
                    }
                    if (ddlArea.SelectedIndex > 0)
                    {
                        myAccess.Area = ddlArea.SelectedItem.Text;
                        myAccess.AreaCode = ddlArea.SelectedValue;
                    }
                    else
                    {
                        myAccess.Area = "";
                        myAccess.AreaCode = "-1";
                    }
                    if (ddlCostAcc.SelectedIndex > 0)
                    {
                        myAccess.CostAcc = ddlCostAcc.SelectedItem.Text;
                        myAccess.CostAccCode = ddlCostAcc.SelectedValue;
                    }
                    else
                    {
                        myAccess.CostAcc = "";
                        myAccess.CostAccCode = "-1";
                    }
                    if (ddlEmp.SelectedIndex > 0)
                    {
                        myAccess.Emp = ddlEmp.SelectedItem.Text;
                        myAccess.EmpCode = ddlEmp.SelectedValue;
                    }
                    else
                    {
                        myAccess.Emp = "";
                        myAccess.EmpCode = "-1";
                    }

                    if (txtCarNo.Text != "")
                    {
                        Cars myCar = new Cars();
                        myCar.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCar.Code = txtCarNo.Text;
                        myCar = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                 where sitm.Code == myCar.Code
                                 select sitm).FirstOrDefault();
                        if (myCar != null)
                        {
                            myAccess.CarNo2 = myCar.CodeName;
                            myAccess.CarNo = myCar.Code;
                        }
                    }
                    else
                    {
                        myAccess.CarNo2 = "";
                        myAccess.CarNo = "-1";
                    }
                    myAccess.InvNo = txtInvNo.Text;
                    myAccess.Remark = txtRemark.Text;
                    myAccess.InvType = short.Parse(ddlDocType.SelectedValue);
                    VouData.Add(myAccess);

                    //MakeSum();
                    LoadVouData();

                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult.Text = "لقد تم اضافة البند بنجاح";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, false), true);
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

        public void MakeSum()
        {
            double db = 0;
            foreach (Vou itm in VouData)
            {
                db += itm.Debit;
            }
            txtTotal.Text = string.Format("{0:N2}", db);
            if (db > 0) ddlDocType.Enabled = false;
            else ddlDocType.Enabled = true;
        }

        protected void grdCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdCodes.PageIndex = e.NewPageIndex;
                LoadVouData();
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
                LoadVouData();
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
            {
                try
                {
                    //e.NewSelectedIndex = -1;
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
        }

        protected void grdCodes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string sno = grdCodes.DataKeys[e.RowIndex]["sno"].ToString();
                VouData.RemoveAt((int)moh.StrToDouble(sno) - 1);
                for (int i = 0; i < VouData.Count; i++)
                {
                    VouData[i].sno = (short)(i + 1);
                }

                e.Cancel = false;
                //MakeSum();
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
                    Response.Redirect("GeneralServerError.aspx",false);
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
                if (grdCodes.Rows.Count < 1)
                {
                    Vou ax = new Vou();
                    VouData.Add(ax);
                    grdCodes.DataSource = VouData;
                    grdCodes.DataBind();
                    grdCodes.Rows[0].Visible = false;
                    grdCodes.Rows[0].Controls.Clear();
                    grdCodes.Rows[0].Cells.Clear();
                    VouData.Remove(ax);                
                }
                
                if (grdCodes.EditIndex>-1 &&  (VouData[grdCodes.EditIndex].InvType == 0 || VouData[grdCodes.EditIndex].InvType == 1)) // (ddlDocType.SelectedValue == "0" || ddlDocType.SelectedValue == "2"))
                {
                    TextBox txtDebit = grdCodes.Rows[grdCodes.EditIndex].FindControl("txtDebit2") as TextBox;
                    TextBox txtCode = grdCodes.Rows[grdCodes.EditIndex].FindControl("txtCode2") as TextBox;
                    TextBox txtName = grdCodes.Rows[grdCodes.EditIndex].FindControl("txtName2") as TextBox;
                    TextBox txtInvNo = grdCodes.Rows[grdCodes.EditIndex].FindControl("txtInvNo2") as TextBox;
                    if (txtDebit != null) txtDebit.Enabled = false;
                    if (txtCode != null) txtCode.Enabled = false;
                    if (txtName != null) txtName.Enabled = false;
                    if (txtInvNo != null) txtInvNo.Enabled = false;
                }
                DropDownList ddlArea = grdCodes.FooterRow.FindControl("ddlArea2") as DropDownList;
                ddlArea.DataTextField = "Name1";
                ddlArea.DataValueField = "Code";
                ddlArea.DataSource = (List<Area>)(HttpRuntime.Cache["LastArea" + HttpContext.Current.Session["CNN2"].ToString()]);
                ddlArea.DataBind();
                ddlArea.Items.Insert(0, new ListItem("--- أختار المنطقة---", "-1", true));

                DropDownList ddlCostCenter = grdCodes.FooterRow.FindControl("ddlCostCenter2") as DropDownList;
                ddlCostCenter.DataTextField = "Name1";
                ddlCostCenter.DataValueField = "Code";
                ddlCostCenter.DataSource = (List<CostCenter>)(HttpRuntime.Cache["LastCostCenter" + HttpContext.Current.Session["CNN2"].ToString()]);
                ddlCostCenter.DataBind();
                ddlCostCenter.Items.Insert(0, new ListItem("--- أختار الفرع---", "-1", true));

                DropDownList ddlProject = grdCodes.FooterRow.FindControl("ddlProject2") as DropDownList;
                ddlProject.DataTextField = "Name1";
                ddlProject.DataValueField = "Code";
                ddlProject.DataSource = (List<AccProject>)(HttpRuntime.Cache["LastProject" + HttpContext.Current.Session["CNN2"].ToString()]);
                ddlProject.DataBind();
                ddlProject.Items.Insert(0, new ListItem("--- أختار المشروع---", "-1", true));

                DropDownList ddlCostAcc = grdCodes.FooterRow.FindControl("ddlCostAcc2") as DropDownList;
                ddlCostAcc.DataTextField = "Name1";
                ddlCostAcc.DataValueField = "Code";
                ddlCostAcc.DataSource = (List<CostAcc>)(HttpRuntime.Cache["LastCostAcc" + HttpContext.Current.Session["CNN2"].ToString()]);
                ddlCostAcc.DataBind();
                ddlCostAcc.Items.Insert(0, new ListItem("--- أختار حساب التكاليف---", "-1", true));

                DropDownList ddlEmp = grdCodes.FooterRow.FindControl("ddlEmp2") as DropDownList;
                SEmp myemp = new SEmp();
                if (Cache["Emps" + Session["CNN2"].ToString()] == null) Cache.Insert("Emps" + Session["CNN2"].ToString(), myemp.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                ddlEmp.DataTextField = "Name";
                ddlEmp.DataValueField = "EmpCode";
                ddlEmp.DataSource = (List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()]);
                ddlEmp.DataBind();
                ddlEmp.Items.Insert(0, new ListItem("--- أختار الموظف---", "-1", true));

                if (grdCodes.FooterRow != null)
                {
                    TextBox txtCode = grdCodes.FooterRow.FindControl("txtCode") as TextBox;
                    TextBox txtName = grdCodes.FooterRow.FindControl("txtName") as TextBox;
                    TextBox txtDebit = grdCodes.FooterRow.FindControl("txtDebit") as TextBox;
                    TextBox txtInvNo = grdCodes.FooterRow.FindControl("txtInvNo") as TextBox;
                    if (ddlDocType.SelectedValue == "0" || ddlDocType.SelectedValue == "2" || ddlDocType.SelectedValue == "5")
                    {
                        txtInvNo.Attributes.Add("onchange", "javascript:CallMe('" + txtInvNo.ClientID + "','" + ddlDocType.SelectedValue + "',  ['" + txtCode.ClientID + "', '" + txtName.ClientID + "', '" + txtDebit.ClientID + "', '" + txtInvNo.ClientID + "', '" + LblCodesResult.ClientID + "'])");
                        txtCode.Enabled = false;
                        txtName.Enabled = false;
                        if (ddlDocType.SelectedValue == "0" || ddlDocType.SelectedValue == "2")
                        {
                            if (!((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("admin")) txtDebit.Enabled = false;
                        }
                        else txtDebit.Enabled = false;
                    }
                    else if (!txtCode.Enabled)
                    {
                        txtInvNo.Attributes.Clear();
                        txtCode.Enabled = true;
                        txtName.Enabled = true;
                        txtDebit.Enabled = true;
                    }
                }

                MakeSum();

                //DropDownList ddlCarNo = grdCodes.FooterRow.FindControl("ddlCarNo2") as DropDownList;
                //Cars myCar = new Cars();
                //myCar.Branch = short.Parse(Session["Branch"].ToString());
                //ddlCarNo.DataTextField = "CodeName";
                //ddlCarNo.DataValueField = "Code";
                //ddlCarNo.DataSource = (from itm in myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                //                       orderby itm.Code
                //                       select itm).ToList();

                //ddlCarNo.DataBind();
                //ddlCarNo.Items.Insert(0, new ListItem("--- أختار الشاحنة---", "-1", true));
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

        protected void ddlDocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grdCodes.FooterRow != null)
            {
                TextBox txtDebit = grdCodes.FooterRow.FindControl("txtDebit") as TextBox;
                TextBox txtCode = grdCodes.FooterRow.FindControl("txtCode") as TextBox;
                TextBox txtName = grdCodes.FooterRow.FindControl("txtName") as TextBox;
                TextBox txtInvNo = grdCodes.FooterRow.FindControl("txtInvNo") as TextBox;
                if (ddlDocType.SelectedValue == "0" || ddlDocType.SelectedValue == "2")
                {
                    txtInvNo.Attributes.Add("onchange", "javascript:CallMe('" + txtInvNo.ClientID + "','" + ddlDocType.SelectedValue + "',  ['" + txtCode.ClientID + "', '" + txtName.ClientID + "', '" + txtDebit.ClientID + "', '" + txtInvNo.ClientID + "', '" + LblCodesResult.ClientID + "'])");
                    txtCode.Enabled = false;
                    txtName.Enabled = false;
                    if (ddlDocType.SelectedValue == "0" || ddlDocType.SelectedValue == "2")
                    {
                        if (!((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("admin")) txtDebit.Enabled = false;
                    }
                    else txtDebit.Enabled = false;
                }
                else
                {
                    if(!txtCode.Enabled) txtInvNo.Attributes.Clear();
                    txtCode.Enabled = true;
                    txtName.Enabled = true;
                    txtDebit.Enabled = true;
                }
                grdCodes_RowCancelingEdit(sender, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string[] GetDate(string InvNo , string FType)
        {
            string Code00 = "";
            string Name00 = "";
            string Debit00 = "";
            string InvNo00 = "";
            string Error00 = "";
            InvNo00 = InvNo;

            if (FType == "0")
            {
                List<MyPO> lJv = new List<MyPO>();
                MyPO inv = new MyPO();
                inv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                if (InvNo.Split('/')[0] == "01")
                {
                    inv.FType = 6;
                    inv.LocNumber = short.Parse(InvNo.Split('/')[0]);
                }
                else if (InvNo.Split('/')[0] == "001")
                {
                    inv.FType = 4;
                    inv.LocNumber = short.Parse(InvNo.Split('/')[0]);
                }
                else
                {
                    inv.FType = 2;
                    inv.LocNumber = short.Parse(InvNo.Split('/')[0]);
                }
                inv.Number = int.Parse(InvNo.Split('/')[1]);
                lJv = inv.Find(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
                if (lJv == null || lJv.Count == 0)
                {
                    Error00 = "رقم المستند غير معرف من قبل";
                    return new string[] { Code00, Name00, Debit00, InvNo00, Error00 };
                }

                Jv vJv = new Jv();
                vJv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                vJv.FType = 102;
                vJv.LocType = 1;
                vJv.InvNo = InvNo;
                vJv.DocType = 0;
               // vJv = vJv.findInvNo20(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
                double totamount = 0;
                string vError = "";
                bool vGet = true;
                foreach (Jv itm in vJv.findInvNo200(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
                {
                    if (vGet)
                    {
                        vError += "تم أدراج المستند في سند الصرف رقم  ";
                        vGet = false;
                    }
                    vError += "  " + itm.LocNumber.ToString() + "/" + itm.Number.ToString();
                    totamount += (double)itm.Amount;
                }

                vJv = new Jv();
                vJv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                vJv.FType = 106;
                vJv.LocType = 1;
                vJv.InvNo = InvNo;
                vJv.DocType = 0;
                vGet = true;
                foreach (Jv itm in vJv.findInvNo200(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
                {
                    if (vGet)
                    {
                        if (totamount > 0) vError += "  " + "تم أدراج المستند في التحويل البنكي رقم  ";
                        else vError = "تم أدراج المستند في التحويل البنكي رقم  ";
                        vGet = false;
                    }
                    vError += "  " + itm.LocNumber.ToString() + "/" + itm.Number.ToString();
                    totamount += (double)itm.Amount;
                }

                vJv = new Jv();
                vJv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                vJv.FType = 100;
                vJv.LocType = 1;
                vJv.InvNo = "P" + InvNo;
                vJv.DocType = 0;
                vGet = true;
                foreach (Jv itm in vJv.findInvNo200(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
                {
                    if (vGet)
                    {
                        if (totamount > 0) vError += "  " + "تم أدراج المستند في قيد يومية رقم  ";
                        else vError = "تم أدراج المستند في قيد يومية رقم  ";
                        vGet = false;
                    }
                    vError += "  " + itm.LocNumber.ToString() + "/" + itm.Number.ToString();
                    totamount += (double)itm.Amount;
                }

                double amount = 0;
                foreach (MyPO itm in lJv)
                {
                    if (itm.Approved == 1 || itm.Approved == 3) amount += itm.Amount;
                }

                if (inv.FType == 4)
                {
                    Code00 = "120103014";

                    Acc myAcc = new Acc();
                    myAcc.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                    myAcc.Code = Code00;
                    if (myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
                    {
                        Name00 = myAcc.Name1;
                    }

                }
                else if (inv.FType == 6)
                {
                    Code00 = "120103013";

                    Acc myAcc = new Acc();
                    myAcc.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                    myAcc.Code = Code00;
                    if (myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
                    {
                        Name00 = myAcc.Name1;
                    }

                }
                else
                {
                    CostCenter myCost = new CostCenter();
                    myCost.Branch = 1;
                    if (HttpRuntime.Cache["LastCostCenter" + HttpContext.Current.Session["CNN2"].ToString()] == null) HttpRuntime.Cache.Insert("LastCostCenter" + HttpContext.Current.Session["CNN2"].ToString(), myCost.GetAll(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString));
                    myCost.Code = moh.MakeMask(inv.LocNumber.ToString(), 5);
                    myCost = (from citm in (List<CostCenter>)(HttpRuntime.Cache["LastCostCenter" + HttpContext.Current.Session["CNN2"].ToString()])
                              where citm.Code == myCost.Code
                              select citm).FirstOrDefault();
                    if (myCost != null)
                    {
                        Code00 = myCost.LoanAcc;

                        Acc myAcc = new Acc();
                        myAcc.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                        myAcc.Code = myCost.LoanAcc;
                        if (myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
                        {
                            Name00 = myAcc.Name1;
                        }
                    }
                }
                Debit00 = string.Format("{0:N2}", amount);

                if (totamount >= double.Parse(Debit00))
                {
                    return new string[] { "", "", "", InvNo00, vError };
                }
                else Debit00 = string.Format("{0:N2}", double.Parse(Debit00) - totamount);
            }
            else if (FType == "2")
            {
                Jv vJv = new Jv();
                vJv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                vJv.FType = 102;
                vJv.InvNo = InvNo;
                vJv.DocType = 2;
                double totamount = 0;
                string vError = "";
                bool vGet = true;
                foreach (Jv itm in vJv.findInvNo200(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
                {
                    if (vGet)
                    {
                        vError += "تم أدراج المستند في سند الصرف رقم  ";
                        vGet = false;
                    }
                    vError +=  "  " + itm.LocNumber.ToString() + "/" + itm.Number.ToString();
                    totamount += (double)itm.Amount;
                }


                vJv = new Jv();
                vJv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                vJv.FType = 106;
                vJv.InvNo = InvNo;
                vJv.DocType = 2;
                vGet = true;
                foreach (Jv itm in vJv.findInvNo200(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
                {
                    if (vGet)
                    {
                        if (totamount > 0) vError += "  " + "تم أدراج المستند في التحويل البنكي رقم  ";
                        else vError = "تم أدراج المستند في التحويل البنكي رقم  ";
                        vGet = false;
                    }
                    vError += "  " + itm.LocNumber.ToString() + "/" + itm.Number.ToString();
                    totamount += (double)itm.Amount;
                }


                CarMove myCar = new CarMove();
                myCar.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                myCar.VouLoc =  moh.MakeMask(InvNo.Split('/')[0],5);
                myCar.Number = int.Parse(InvNo.Split('/')[1]);
                myCar = myCar.Find(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                if (myCar != null)
                {
                    CarMoveRCV rcv = new CarMoveRCV();
                    rcv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                    rcv.CarMove = myCar.CarMoveNo2;
                    rcv = rcv.Find2(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
                    if (rcv == null)
                    {
                        Error00 = "يجب تسجيل بيان وصول قبل سند الصرف";
                        return new string[] { Code00, Name00, Debit00, InvNo00, Error00 };
                    }

                    InvNo00 = InvNo;
                    if ((bool)myCar.Rent)
                    {
                        Code00 = "240104005";
                        Acc myAcc = new Acc();
                        myAcc.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                        myAcc.Code = Code00;
                        if (myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
                        {
                            Name00 = myAcc.Name1;
                        }
                        Debit00 = string.Format("{0:N2}", (double)myCar.RentValue);
                    }
                    else
                    {
                        CarPrices myPrice = new CarPrices();
                        myPrice.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                        myPrice.MonthNo = 0;
                        myPrice.FromCode = myCar.FromLoc;
                        myPrice.PLevel = "00002";
                        myPrice.toCode = myCar.ToLoc;
                        myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
                        if (myPrice != null)
                        {
                            double Amount = (double)myPrice.CostAmount;
                            CarMoveLines myCarMoveLine = new CarMoveLines();
                            myCarMoveLine.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                            myCarMoveLine.VouLoc = moh.MakeMask(InvNo.Split('/')[0], 5);
                            myCarMoveLine.Number = int.Parse(InvNo.Split('/')[1]);
                            foreach (CarMoveLines itm in myCarMoveLine.find(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
                            {
                                if (itm.FromLoc == "-1" && itm.LineFNo != 1) Amount -= (double)itm.Cost;
                                else Amount += (double)itm.Cost;
                            }
                            Debit00 = string.Format("{0:N2}", Amount);

                            CostCenter myCost = new CostCenter();
                            myCost.Branch = 1;
                            myCost.Code = "00001";
                            myCost = (from citm in (List<CostCenter>)(HttpRuntime.Cache["LastCostCenter" + HttpContext.Current.Session["CNN2"].ToString()])
                                      where citm.Code == myCost.Code
                                      select citm).FirstOrDefault();
                            if (myCost != null)
                            {
                                Code00 = myCost.CurExpAcc;
                                Acc myAcc = new Acc();
                                myAcc.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                                myAcc.Code = Code00;
                                if (myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
                                {
                                    Name00 = myAcc.Name1;
                                }
                            }
                        }
                    }
                    if (totamount >= double.Parse(Debit00))
                    {
                        return new string[] { "", "", "", InvNo00, vError };
                    }
                    else Debit00 = string.Format("{0:N2}", double.Parse(Debit00) - totamount);
                }
            }
            else if (FType == "5")
            {
                Jv vJv = new Jv();
                vJv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                vJv.FType = 102;
                vJv.InvNo = InvNo;
                vJv.DocType = 5;
                vJv = vJv.findInvNo20(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
                if (vJv != null)
                {
                    Error00 = "تم أدراج المستند في سند الصرف رقم " + vJv.LocNumber.ToString() + "/" + vJv.Number.ToString();
                    return new string[] { Code00, Name00, Debit00, InvNo00, Error00 };
                }

                vJv = new Jv();
                vJv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                vJv.FType = 106;
                vJv.InvNo = InvNo;
                vJv.DocType = 5;
                vJv = vJv.findInvNo20(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
                if (vJv != null)
                {
                    Error00 = "تم أدراج المستند في التحويل البنكي رقم " + vJv.LocNumber.ToString() + "/" + vJv.Number.ToString();
                    return new string[] { Code00, Name00, Debit00, InvNo00, Error00 };
                }

                vJv = new Jv();
                vJv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                vJv.FType = 100;
                vJv.InvNo = InvNo;
                vJv.DocType = 5;
                vJv = vJv.findInvNo20(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
                if (vJv != null)
                {
                    Error00 = "تم أدراج المستند في قيد اليومية رقم " + vJv.LocNumber.ToString() + "/" + vJv.Number.ToString();
                    return new string[] { Code00, Name00, Debit00, InvNo00, Error00 };
                }

                FastRepair myRepair = new FastRepair();
                myRepair.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                myRepair.VouLoc = (short)(InvNo.Split('/')[0] == "001" ? 3 : 2);
                myRepair.VouLoc = short.Parse(InvNo.Split('/')[0]);
                myRepair.VouNo = int.Parse(InvNo.Split('/')[1]);
                myRepair = myRepair.find(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
                if (myRepair != null)
                {
                    Agreement myAgree = new Agreement();
                    myAgree.FType = 801;
                    myAgree.LocType = 2;
                    myAgree.LocNumber = short.Parse(InvNo.Split('/')[0]);
                    myAgree.Number = int.Parse(InvNo.Split('/')[1]);
                    myAgree.FNo = 1;
                    myAgree = myAgree.Find(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myAgree != null)
                    {
                        Error00 = "لم يتم اعتماد بيان الاصلاح بعد";
                        return new string[] { Code00, Name00, Debit00, InvNo00, Error00 };
                    }                   

                    Jv myJv = new Jv();
                    vJv mJv = new vJv();
                    myJv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                    myJv.FType = 801;
                    myJv.LocType = 2;
                    myJv.LocNumber = short.Parse(InvNo.Split('/')[0]);
                    myJv.Number = int.Parse(InvNo.Split('/')[1]);
                    mJv = (from itm in myJv.find2(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString)
                           where itm.CrCode != ""
                           select itm).FirstOrDefault();
                    Code00 = mJv.CrCode;
                    Name00 = mJv.AccName1;
                    Debit00 = string.Format("{0:N2}", (double)mJv.Amount);
                    InvNo00 = InvNo;
                }
                else
                {
                    Error00 = "رقم بيان الاصلاح الخارجي غير مدرج من قبل";
                }
            }
            return new string[] { Code00,Name00,Debit00,InvNo00,Error00 };
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
                        myArch.LocNumber = LocNumber;
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 596;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = LocNumber;
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 596;
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
                            UserTran.FormName = "سند صرف شيك";
                            UserTran.FormAction = "اضافة مرفقات";
                            UserTran.Description = "أضافة مرفقات سند صرف شيك رقم " +  txtVouNo.Text;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }

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
                myArch.LocNumber = LocNumber;
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = 596;
                myArch.FNo = short.Parse(FNo);
                myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                {
                    Transactions UserTran = new Transactions();
                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                    UserTran.UserName = Session["CurrentUser"].ToString();
                    UserTran.FormName = "سند صرف شيك";
                    UserTran.FormAction = "الغاء مرفقات";
                    UserTran.Description = "الغاء مرفقات من سند صرف شيك رقم " + txtVouNo.Text;
                    UserTran.IP = IPNetworking.GetIP4Address();
                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                }

                LoadAttachData();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("GeneralServerError.aspx",false);
            }
        }

        public void LoadAttachData()
        {
            if (txtVouNo.Text != "")
            {
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(Session["Branch"].ToString());
                myArch.LocNumber = LocNumber;
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = 596;
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

        protected void grdCodes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string sno = grdCodes.DataKeys[e.RowIndex]["sno"].ToString();
                GridViewRow gvr = grdCodes.Rows[e.RowIndex];

                if (sno == null || gvr == null)
                {
                    e.Cancel = true;
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "لقد حدث خطأ أثناء تعديل البيانات ... حاول مرة أخرى";
                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    return;
                }

                TextBox txtDebit = gvr.FindControl("txtDebit2") as TextBox;
                TextBox txtCode = gvr.FindControl("txtCode2") as TextBox;
                TextBox txtName = gvr.FindControl("txtName2") as TextBox;
                TextBox txtRemark = gvr.FindControl("txtRemark2") as TextBox;
                TextBox txtInvNo = gvr.FindControl("txtInvNo2") as TextBox;
                DropDownList ddlArea = gvr.FindControl("ddlArea") as DropDownList;
                DropDownList ddlCostCenter = gvr.FindControl("ddlCostCenter") as DropDownList;
                DropDownList ddlProject = gvr.FindControl("ddlProject") as DropDownList;
                DropDownList ddlCostAcc = gvr.FindControl("ddlCostAcc") as DropDownList;
                DropDownList ddlEmp = gvr.FindControl("ddlEmp") as DropDownList;
                TextBox txtCarNo = gvr.FindControl("txtCarNo") as TextBox;

                if (txtDebit == null || txtCode == null || txtName == null || txtRemark == null || txtInvNo == null || ddlArea == null || ddlCostCenter == null || ddlCostAcc == null || ddlProject == null || ddlEmp == null || txtCarNo == null)
                {
                    e.Cancel = true;
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "لقد حدث خطأ أثناء تعديل البيانات ... حاول مرة أخرى";
                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    return;
                }

                if (txtDebit.Text == "") txtDebit.Text = "0.00";

                if (moh.StrToDouble(txtDebit.Text) == 0)
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب أدخال المبلغ المدين";
                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    return;
                }

                Acc myAcc = new Acc();
                myAcc.Branch = short.Parse(Session["Branch"].ToString());
                myAcc.Code = txtCode.Text;
                if (!myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "رقم الحساب غير معرف من قبل";
                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    return;
                }
                else
                {
                    // Check to force Entering of Area
                    if ((bool)myAcc.CheckArea && ddlArea.SelectedIndex == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الحساب مرتبط بمنطقة ... يجب أختيار المنطقة";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    // Check to force Entering of Cost Center
                    if ((bool)myAcc.CheckCostCenter && ddlCostCenter.SelectedIndex == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الحساب مرتبط بفرع ... يجب أختيار الفرع";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    // Check to force Entering of Project
                    if ((bool)myAcc.CheckProject && ddlProject.SelectedIndex == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الحساب مرتبط بمشروع ... يجب أختيار المشروع";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    // Check to force Entering of Cost Acc
                    if ((bool)myAcc.CheckCostAcc && ddlCostAcc.SelectedIndex == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الحساب مرتبط بحسابات التكاليف ... يجب أختيار حساب التكاليف";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    // Check to force Entering of Emp
                    if ((bool)myAcc.CheckEmp && ddlEmp.SelectedIndex == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الحساب مرتبط بالموظفين ... يجب أختيار الموظف";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                }

                VouData[int.Parse(sno) - 1].Debit = moh.StrToDouble(txtDebit.Text);
                VouData[int.Parse(sno) - 1].Credit = 0;
                VouData[int.Parse(sno) - 1].Code = txtCode.Text;
                VouData[int.Parse(sno) - 1].Name = txtName.Text;
                if (ddlProject.SelectedIndex > 0)
                {
                    VouData[int.Parse(sno) - 1].Project = ddlProject.SelectedItem.Text;
                    VouData[int.Parse(sno) - 1].ProjectCode = ddlProject.SelectedValue;
                }
                else
                {
                    VouData[int.Parse(sno) - 1].Project = "";
                    VouData[int.Parse(sno) - 1].ProjectCode = "-1";
                }
                if (ddlCostCenter.SelectedIndex > 0)
                {
                    VouData[int.Parse(sno) - 1].CostCenter = ddlCostCenter.SelectedItem.Text;
                    VouData[int.Parse(sno) - 1].CostCenterCode = ddlCostCenter.SelectedValue;
                }
                else
                {
                    VouData[int.Parse(sno) - 1].CostCenter = "";
                    VouData[int.Parse(sno) - 1].CostCenterCode = "-1";
                }
                if (ddlArea.SelectedIndex > 0)
                {
                    VouData[int.Parse(sno) - 1].Area = ddlArea.SelectedItem.Text;
                    VouData[int.Parse(sno) - 1].AreaCode = ddlArea.SelectedValue;
                }
                else
                {
                    VouData[int.Parse(sno) - 1].Area = "";
                    VouData[int.Parse(sno) - 1].AreaCode = "-1";
                }
                if (ddlCostAcc.SelectedIndex > 0)
                {
                    VouData[int.Parse(sno) - 1].CostAcc = ddlCostAcc.SelectedItem.Text;
                    VouData[int.Parse(sno) - 1].CostAccCode = ddlCostAcc.SelectedValue;
                }
                else
                {
                    VouData[int.Parse(sno) - 1].CostAcc = "";
                    VouData[int.Parse(sno) - 1].CostAccCode = "-1";
                }
                if (ddlEmp.SelectedIndex > 0)
                {
                    VouData[int.Parse(sno) - 1].Emp = ddlEmp.SelectedItem.Text;
                    VouData[int.Parse(sno) - 1].EmpCode = ddlEmp.SelectedValue;
                }
                else
                {
                    VouData[int.Parse(sno) - 1].Emp = "";
                    VouData[int.Parse(sno) - 1].EmpCode = "-1";
                }
                if (txtCarNo.Text != "")
                {
                    Cars myCar = new Cars();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myCar.Code = txtCarNo.Text;
                    myCar = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                             where sitm.Code == myCar.Code
                             select sitm).FirstOrDefault();
                    if (myCar != null)
                    {
                        VouData[int.Parse(sno) - 1].CarNo2 = myCar.CodeName;
                        VouData[int.Parse(sno) - 1].CarNo = myCar.Code;
                    }
                }
                else
                {
                    VouData[int.Parse(sno) - 1].CarNo2 = "";
                    VouData[int.Parse(sno) - 1].CarNo = "-1";
                }
                VouData[int.Parse(sno) - 1].Remark = txtRemark.Text;
                VouData[int.Parse(sno) - 1].InvNo = txtInvNo.Text;

                grdCodes.EditIndex = -1;
                //MakeSum();
                LoadVouData();

                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                LblCodesResult.Text = "لقد تم تعديل البند بنجاح";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, false), true);
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

        protected void grdCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.EditIndex = grdCodes.SelectedIndex;
            LoadVouData();
        }

        public void SaveTrans(short? UOP)
        {
            string vUserDate2 = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
            int FNo = 1;
            foreach (Vou itm in VouData)
            {
                Jv vJv2 = new Jv();
                vJv2.UserDate2 = vUserDate2;
                vJv2.UserOP = UOP;
                vJv2.Branch = short.Parse(Session["Branch"].ToString());
                vJv2.FType = 102;
                vJv2.LocType = LocType;
                vJv2.LocNumber = LocNumber;
                vJv2.FNo = (short)FNo++;
                vJv2.Number = int.Parse(txtVouNo.Text);
                vJv2.Post = 1;
                vJv2.FDate = moh.CheckDate(txtVouDate.Text);
                vJv2.DbCode = itm.Code;
                vJv2.CrCode = "";
                if (!string.IsNullOrEmpty(itm.AreaCode) && itm.AreaCode != "-1") vJv2.Area = itm.AreaCode;
                else vJv2.Area = "-1";
                if (!string.IsNullOrEmpty(itm.CostCenterCode) && itm.CostCenterCode != "-1") vJv2.CostCenter = itm.CostCenterCode;
                else vJv2.CostCenter = "-1";
                if (!string.IsNullOrEmpty(itm.ProjectCode) && itm.ProjectCode != "-1") vJv2.Project = itm.ProjectCode;
                else vJv2.Project = "-1";
                if (!string.IsNullOrEmpty(itm.CostAccCode) && itm.CostAccCode != "-1") vJv2.CostAcc = itm.CostAccCode;
                else vJv2.CostAcc = "-1";
                if (!string.IsNullOrEmpty(itm.EmpCode) && itm.EmpCode != "-1") vJv2.EmpCode = itm.EmpCode;
                else vJv2.EmpCode = "-1";
                if (!string.IsNullOrEmpty(itm.CarNo) && itm.CarNo != "-1") vJv2.CarNo = itm.CarNo;
                else vJv2.CarNo = "-1";
                vJv2.DocType = itm.InvType; //  short.Parse(ddlDocType.SelectedValue);
                vJv2.Person = txtPerson.Text;
                vJv2.Remark = itm.Remark;
                vJv2.BankName = txtBankName.Text;
                vJv2.ChequeDate = txtChqDate.Text;
                vJv2.ChequeNo = txtchqNo.Text;
                vJv2.InvNo = itm.InvNo;
                vJv2.Amount = itm.Debit;
                vJv2.UserName = Session["FullUser"].ToString();
                vJv2.UserDate = txtUserDate.Text;
                vJv2.pAdd(WebConfigurationManager.ConnectionStrings["MyCnnTrans"].ConnectionString);
            }

            Jv vJv = new Jv();
            vJv.UserDate2 = vUserDate2;
            vJv.UserOP = UOP;
            vJv.Branch = short.Parse(Session["Branch"].ToString());
            vJv.FType = 102;
            vJv.LocType = LocType;
            vJv.LocNumber = LocNumber;
            vJv.Number = int.Parse(txtVouNo.Text);
            vJv.Post = 1;
            vJv.FDate = moh.CheckDate(txtVouDate.Text);
            vJv.CrCode = ddlDbCode.SelectedValue;
            vJv.DbCode = "";
            vJv.Area = "-1";
            vJv.CostCenter = "-1";
            vJv.Project = "-1";
            vJv.CostAcc = "-1";
            vJv.EmpCode = "-1";
            vJv.Remark = txtRemark.Text;
            vJv.BankName = txtBankName.Text;
            vJv.ChequeDate = txtChqDate.Text;
            vJv.ChequeNo = txtchqNo.Text;
            vJv.InvNo = "";
            vJv.Amount = moh.StrToDouble(txtAmount.Text);
            vJv.FNo = (short)FNo++;
            vJv.UserName = Session["FullUser"].ToString();
            vJv.UserDate = txtUserDate.Text;
            vJv.Person = txtPerson.Text;
            vJv.DocType = short.Parse(ddlDocType.SelectedValue);
            vJv.pAdd(WebConfigurationManager.ConnectionStrings["MyCnnTrans"].ConnectionString);
        }

        protected void grdTrans_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string UserDate2 = grdTrans.DataKeys[e.NewSelectedIndex]["UserDate2"].ToString();
            List<vJv> lJv = new List<vJv>();
            Jv myJv = new Jv();
            myJv.UserDate2 = UserDate2;
            myJv.Branch = short.Parse(Session["Branch"].ToString());
            myJv.FType = 102;
            myJv.LocType = LocType;
            myJv.LocNumber = LocNumber;
            myJv.Number = int.Parse(txtVouNo.Text);
            lJv = myJv.pfind2(WebConfigurationManager.ConnectionStrings["MyCnnTrans"].ConnectionString);
            if (lJv == null || lJv.Count == 0)
            {
            }
            else
            {
                //if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                //{
                //    Transactions UserTran = new Transactions();
                //    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                //    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                //    UserTran.UserName = Session["CurrentUser"].ToString();
                //    UserTran.FormName = (Request.QueryString["FType"].ToString() == "1") ? "سند القبض" : "سند الصرف شيكات";
                //    UserTran.FormAction = "عرض";
                //    UserTran.Description = "عرض بيانات " + UserTran.FormName + " رقم " + txtVouNo.Text;
                //    UserTran.IP = IPNetworking.GetIP4Address();
                //    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                //}

                EditMode();
                VouData.Clear();
                txtVouNo.Text = lJv[0].Number.ToString();
                txtVouDate.Text = lJv[0].FDate;
                txtUserDate.Text = lJv[0].UserDate;
                txtUserName.ToolTip = lJv[0].UserName;
                TblUsers ax = new TblUsers();
                if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                ax.UserName = lJv[0].UserName;
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
                if (Request.QueryString["FType"].ToString() == "1")
                {
                    //ddlDbCode.SelectedValue = lJv[0].DbCode;
                    //txtCode.Text = lJv[1].CrCode;
                    //txtName.Text = lJv[1].AccName1;
                    //ddlArea.SelectedValue = lJv[1].Area;
                    //ddlCostAcc.SelectedValue = lJv[1].CostAcc;
                    //ddlCostCenter.SelectedValue = lJv[1].CostCenter;
                    //ddlEmp.SelectedValue = lJv[1].EmpCode;
                    //ddlProject.SelectedValue = lJv[1].Project;
                }
                else
                {
                    ddlDbCode.SelectedValue = lJv[lJv.Count - 1].CrCode;
                    txtAmount.Text = string.Format("{0:N2}", lJv[lJv.Count - 1].Amount);

                    foreach (vJv itm in lJv)
                    {
                        if (itm.DbCode != "")
                        {
                            VouData.Add(new Vou
                            {
                                Code = itm.DbCode == "" ? itm.CrCode : itm.DbCode,
                                Credit = itm.DbCode == "" ? (double)itm.Amount : 0,
                                Debit = itm.DbCode == "" ? 0 : (double)itm.Amount,
                                CostCenter = itm.CostName1,
                                CostCenter2 = itm.CostName2,
                                CostCenterCode = itm.CostCenter,
                                Project = itm.ProjectName1,
                                Project2 = itm.ProjectName2,
                                ProjectCode = itm.Project,
                                CarNo = itm.CarNo,
                                CarNo2 = itm.PlateNo,
                                Area = itm.AreaName1,
                                Area2 = itm.AreaName2,
                                AreaCode = itm.Area,
                                CostAcc = itm.CostAccName1,
                                CostAcc2 = itm.CostAccName2,
                                CostAccCode = itm.CostAcc,
                                Remark = itm.Remark,
                                InvNo = itm.InvNo,
                                Name = itm.AccName1,
                                Name2 = itm.AccName2,
                                sno = itm.FNo
                            });
                        }
                    }
                    LoadVouData();
                    //MakeSum();
                }
                ddlDocType.SelectedValue = lJv[lJv.Count - 1].DocType.ToString();
                ddlDocType_SelectedIndexChanged(null, null);
                txtPerson.Text = lJv[lJv.Count - 1].Person;
                txtBankName.Text = lJv[lJv.Count - 1].BankName;
                txtChqDate.Text = lJv[lJv.Count - 1].ChequeDate;
                txtchqNo.Text = lJv[lJv.Count - 1].ChequeNo;
                //txtInvNo.Text = lJv[0].InvNo;
                txtRemark.Text = lJv[lJv.Count - 1].Remark;
                LoadAttachData();
                BtnNew.Visible = false;
                BtnEdit.Visible = false;
                BtnDelete.Visible = false;
                BtnPrint.Visible = false;
            }
        }

        public void LoadTransData()
        {
            if (txtVouNo.Text != "")
            {
                Jv myJv = new Jv();
                myJv.Branch = short.Parse(Session["Branch"].ToString());
                myJv.FType = 102;
                myJv.LocType = LocType;
                myJv.LocNumber = LocNumber;
                myJv.Number = int.Parse(txtVouNo.Text);

                List<Jv> lJv = new List<Jv>();
                lJv = myJv.pGetList(WebConfigurationManager.ConnectionStrings["MyCnnTrans"].ConnectionString);
                grdTrans.DataSource = lJv;
                grdTrans.DataBind();

                if (lJv == null || lJv.Count == 0)
                {
                    cpeDemo2.Collapsed = true;
                    cpeDemo2.ClientState = "true";
                }
                else
                {
                    cpeDemo2.Collapsed = false;
                    cpeDemo2.ClientState = "false";
                }
            }
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
                    myAgree.FType = 102;
                    myAgree.LocType = LocType;
                    myAgree.LocNumber = LocNumber;
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
                        UserTran.Description = "أعتماد سند صرف شيكات رقم  " + txtVouNo.Text;
                        UserTran.FormAction = "أعتماد";
                        UserTran.FormName = "سند صرف شيك";
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
                    myAgree.FType = 102;
                    myAgree.LocType = LocType;
                    myAgree.LocNumber = LocNumber;
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
                        UserTran.Description = "أعتماد سند صرف شيكات رقم  " + txtVouNo.Text;
                        UserTran.FormAction = "أعتماد";
                        UserTran.FormName = "سند صرف شيك";
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
    }
}


// public static string[] GetDate(string InvNo , string FType)
        //{
        //    string Code00 = "";
        //    string Name00 = "";
        //    string Debit00 = "";
        //    string InvNo00 = "";
        //    string Error00 = "";
        //    InvNo00 = InvNo;

        //    if (FType == "0")
        //    {
        //        List<MyPO> lJv = new List<MyPO>();
        //        MyPO inv = new MyPO();
        //        inv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
        //        if (InvNo.Split('/')[0] == "01")
        //        {
        //            inv.FType = 6;
        //            inv.LocNumber = short.Parse(InvNo.Split('/')[0]);
        //        }
        //        else if (InvNo.Split('/')[0] == "001")
        //        {
        //            inv.FType = 4;
        //            inv.LocNumber = short.Parse(InvNo.Split('/')[0]);
        //        }
        //        else
        //        {
        //            inv.FType = 2;
        //            inv.LocNumber = short.Parse(InvNo.Split('/')[0]);
        //        }
        //        inv.Number = int.Parse(InvNo.Split('/')[1]);
        //        lJv = inv.Find(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
        //        if (lJv == null || lJv.Count == 0)
        //        {
        //            Error00 = "رقم المستند غير معرف من قبل";
        //            return new string[] { Code00, Name00, Debit00, InvNo00, Error00 };
        //        }

        //        Jv vJv = new Jv();
        //        vJv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
        //        vJv.FType = 102;
        //        vJv.LocType = 1;
        //        vJv.InvNo = InvNo;
        //        vJv.DocType = 0;
        //        vJv = vJv.findInvNo20(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
        //        double totamount = 0;
        //        string vError = "تم أدراج المستند في سند الصرف رقم  ";
        //        foreach (Jv itm in vJv.findInvNo200(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
        //        {
        //            vError += "  " + itm.LocNumber.ToString() + "/" + itm.Number.ToString();
        //            totamount += (double)itm.Amount;
        //        }




        //        if (vJv != null)
        //        {
        //            Error00 = "تم أدراج المستند في سند الصرف رقم " + vJv.LocNumber.ToString() + "/" + vJv.Number.ToString();
        //            return new string[] { Code00, Name00, Debit00, InvNo00, Error00 };
        //        }
        //        else
        //        {
        //            vJv = new Jv();
        //            vJv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
        //            vJv.FType = 106;
        //            vJv.LocType = 1;
        //            vJv.InvNo = InvNo;
        //            vJv.DocType = 0;
        //            vJv = vJv.findInvNo20(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
        //            if (vJv != null)
        //            {
        //                Error00 = "تم أدراج المستند في التحويل البنكي رقم " + vJv.LocNumber.ToString() + "/" + vJv.Number.ToString();
        //                return new string[] { Code00, Name00, Debit00, InvNo00, Error00 };
        //            }
        //            else
        //            {
        //                vJv = new Jv();
        //                vJv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
        //                vJv.FType = 100;
        //                vJv.LocType = 1;
        //                vJv.InvNo = InvNo;
        //                vJv.DocType = 0;
        //                vJv = vJv.findInvNo20(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
        //                if (vJv != null)
        //                {
        //                    Error00 = "تم أدراج المستند في قيد يومية رقم " + vJv.LocNumber.ToString() + "/" + vJv.Number.ToString();
        //                    return new string[] { Code00, Name00, Debit00, InvNo00, Error00 };
        //                }
        //            }
        //        }
        //        double amount = 0;
        //        foreach (MyPO itm in lJv)
        //        {
        //            if (itm.Approved == 1) amount += itm.Amount;
        //        }
        //        if (inv.FType == 4)
        //        {
        //            Code00 = "120103014";

        //            Acc myAcc = new Acc();
        //            myAcc.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
        //            myAcc.Code = Code00;
        //            if (myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
        //            {
        //                Name00 = myAcc.Name1;
        //            }

        //        }
        //        else if (inv.FType == 6)
        //        {
        //            Code00 = "120103013";

        //            Acc myAcc = new Acc();
        //            myAcc.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
        //            myAcc.Code = Code00;
        //            if (myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
        //            {
        //                Name00 = myAcc.Name1;
        //            }

        //        }
        //        else
        //        {
        //            CostCenter myCost = new CostCenter();
        //            myCost.Branch = 1;
        //            myCost.Code = moh.MakeMask(inv.LocNumber.ToString(), 5);
        //            myCost = myCost.find(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
        //            if (myCost != null)
        //            {
        //                Code00 = myCost.LoanAcc;

        //                Acc myAcc = new Acc();
        //                myAcc.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
        //                myAcc.Code = myCost.LoanAcc;
        //                if (myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
        //                {
        //                    Name00 = myAcc.Name1;
        //                }
        //            }
        //        }
        //        Debit00 = string.Format("{0:N2}", amount);
        //    }
        //    else if (FType == "2")
        //    {

        //        Jv vJv = new Jv();
        //        vJv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
        //        vJv.FType = 102;
        //        vJv.InvNo = InvNo;
        //        vJv.DocType = 2;
        //        double totamount = 0;
        //        string vError = "تم أدراج المستند في سند الصرف رقم  ";
        //        foreach (Jv itm in vJv.findInvNo200(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
        //        {
        //            vError +=  "  " + itm.LocNumber.ToString() + "/" + itm.Number.ToString();
        //            totamount += (double)itm.Amount;
        //        }


        //        vJv = new Jv();
        //        vJv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
        //        vJv.FType = 106;
        //        vJv.InvNo = InvNo;
        //        vJv.DocType = 2;
        //        if(totamount > 0) vError += "  " + "تم أدراج المستند في التحويل البنكي رقم  ";
        //        else vError = "تم أدراج المستند في التحويل البنكي رقم  ";
        //        foreach (Jv itm in vJv.findInvNo200(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
        //        {
        //            vError += "  " + itm.LocNumber.ToString() + "/" + itm.Number.ToString();
        //            totamount += (double)itm.Amount;
        //        }


        //        CarMove myCar = new CarMove();
        //        myCar.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
        //        myCar.VouLoc =  moh.MakeMask(InvNo.Split('/')[0],5);
        //        myCar.Number = int.Parse(InvNo.Split('/')[1]);
        //        myCar = myCar.Find(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
        //        if (myCar != null)
        //        {
        //            CarMoveRCV rcv = new CarMoveRCV();
        //            rcv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
        //            rcv.CarMove = myCar.CarMoveNo2;
        //            rcv = rcv.Find2(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
        //            if (rcv == null)
        //            {
        //                Error00 = "يجب تسجيل بيان وصول قبل سند الصرف";
        //                return new string[] { Code00, Name00, Debit00, InvNo00, Error00 };
        //            }

        //            InvNo00 = InvNo;
        //            if ((bool)myCar.Rent)
        //            {
        //                Code00 = "240104005";
        //                Acc myAcc = new Acc();
        //                myAcc.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
        //                myAcc.Code = Code00;
        //                if (myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
        //                {
        //                    Name00 = myAcc.Name1;
        //                }
        //                Debit00 = string.Format("{0:N2}", (double)myCar.RentValue);
        //            }
        //            else
        //            {
        //                CarPrices myPrice = new CarPrices();
        //                myPrice.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
        //                myPrice.MonthNo = 0;
        //                myPrice.FromCode = myCar.FromLoc;
        //                myPrice.PLevel = "00002";
        //                myPrice.toCode = myCar.ToLoc;
        //                myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
        //                if (myPrice != null)
        //                {
        //                    double Amount = (double)myPrice.CostAmount;
        //                    CarMoveLines myCarMoveLine = new CarMoveLines();
        //                    myCarMoveLine.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
        //                    myCarMoveLine.VouLoc = moh.MakeMask(InvNo.Split('/')[0], 5);
        //                    myCarMoveLine.Number = int.Parse(InvNo.Split('/')[1]);
        //                    foreach (CarMoveLines itm in myCarMoveLine.find(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
        //                    {
        //                        if (itm.FromLoc == "-1" && itm.LineFNo != 1) Amount -= (double)itm.Cost;
        //                        else Amount += (double)itm.Cost;
        //                    }
        //                    Debit00 = string.Format("{0:N2}", Amount);

        //                    CostCenter myCost = new CostCenter();
        //                    myCost.Branch = 1;
        //                    myCost.Code = "00001";
        //                    myCost = myCost.find(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
        //                    if (myCost != null)
        //                    {
        //                        Code00 = myCost.CurExpAcc;
        //                        Acc myAcc = new Acc();
        //                        myAcc.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
        //                        myAcc.Code = Code00;
        //                        if (myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
        //                        {
        //                            Name00 = myAcc.Name1;
        //                        }
        //                    }
        //                }
        //            }
        //            if (totamount >= double.Parse(Debit00))
        //            {
        //                return new string[] { "", "", "", InvNo00, vError };
        //            }
        //            else Debit00 = string.Format("{0:N2}", double.Parse(Debit00) - totamount);
        //        }
        //    }
        //    else if (FType == "5")
        //    {
        //        Jv vJv = new Jv();
        //        vJv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
        //        vJv.FType = 102;
        //        vJv.InvNo = InvNo;
        //        vJv.DocType = 5;
        //        vJv = vJv.findInvNo20(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
        //        if (vJv != null)
        //        {
        //            Error00 = "تم أدراج المستند في سند الصرف رقم " + vJv.LocNumber.ToString() + "/" + vJv.Number.ToString();
        //            return new string[] { Code00, Name00, Debit00, InvNo00, Error00 };
        //        }

        //        vJv = new Jv();
        //        vJv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
        //        vJv.FType = 106;
        //        vJv.InvNo = InvNo;
        //        vJv.DocType = 5;
        //        vJv = vJv.findInvNo20(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
        //        if (vJv != null)
        //        {
        //            Error00 = "تم أدراج المستند في التحويل البنكي رقم " + vJv.LocNumber.ToString() + "/" + vJv.Number.ToString();
        //            return new string[] { Code00, Name00, Debit00, InvNo00, Error00 };
        //        }

        //        vJv = new Jv();
        //        vJv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
        //        vJv.FType = 100;
        //        vJv.InvNo = InvNo;
        //        vJv.DocType = 5;
        //        vJv = vJv.findInvNo20(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
        //        if (vJv != null)
        //        {
        //            Error00 = "تم أدراج المستند في قيد اليومية رقم " + vJv.LocNumber.ToString() + "/" + vJv.Number.ToString();
        //            return new string[] { Code00, Name00, Debit00, InvNo00, Error00 };
        //        }

        //        FastRepair myRepair = new FastRepair();
        //        myRepair.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
        //        myRepair.VouLoc = (short)(InvNo.Split('/')[0] == "001" ? 3 : 2);
        //        myRepair.VouLoc = short.Parse(InvNo.Split('/')[0]);
        //        myRepair.VouNo = int.Parse(InvNo.Split('/')[1]);
        //        myRepair = myRepair.find(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
        //        if (myRepair != null)
        //        {
        //            Agreement myAgree = new Agreement();
        //            myAgree.FType = 801;
        //            myAgree.LocType = 2;
        //            myAgree.LocNumber = short.Parse(InvNo.Split('/')[0]);
        //            myAgree.Number = int.Parse(InvNo.Split('/')[1]);
        //            myAgree.FNo = 1;
        //            myAgree = myAgree.Find(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
        //            if (myAgree != null)
        //            {
        //                Error00 = "لم يتم اعتماد بيان الاصلاح بعد";
        //                return new string[] { Code00, Name00, Debit00, InvNo00, Error00 };
        //            }                   

        //            Jv myJv = new Jv();
        //            vJv mJv = new vJv();
        //            myJv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
        //            myJv.FType = 801;
        //            myJv.LocType = 2;
        //            myJv.LocNumber = short.Parse(InvNo.Split('/')[0]);
        //            myJv.Number = int.Parse(InvNo.Split('/')[1]);
        //            mJv = (from itm in myJv.find2(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString)
        //                   where itm.CrCode != ""
        //                   select itm).FirstOrDefault();
        //            Code00 = mJv.CrCode;
        //            Name00 = mJv.AccName1;
        //            Debit00 = string.Format("{0:N2}", (double)mJv.Amount);
        //            InvNo00 = InvNo;
        //        }
        //        else
        //        {
        //            Error00 = "رقم بيان الاصلاح الخارجي غير مدرج من قبل";
        //        }
        //    }
        //    return new string[] { Code00,Name00,Debit00,InvNo00,Error00 };
        //}
