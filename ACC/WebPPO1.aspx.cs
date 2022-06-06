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
    public partial class WebPPO1 : System.Web.UI.Page
    {
        public List<MyPO> VouData
        {
            get
            {
                if (ViewState["VouData"] == null)
                {
                    ViewState["VouData"] = new List<MyPO>();
                }
                return (List<MyPO>)ViewState["VouData"];
            }
            set
            {
                ViewState["VouData"] = value;

            }
        }
        public short FType
        {
            get
            {
                if (ViewState["FType"] == null)
                {
                    ViewState["FType"] = "2";
                }
                return short.Parse(ViewState["FType"].ToString());
            }
            set { ViewState["FType"] = value.ToString(); }
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
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass275;
            BtnEdit.Visible = true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass272;
            BtnNew.Visible = false;
            BtnDelete.Visible = true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass273;

            if (Request.QueryString["FMode"] != null)
            {
                BtnNew.Visible = false;
                BtnEdit.Visible = false;
                BtnDelete.Visible = false;
            }
            if (!BtnEdit.Visible) ControlsOnOff(false);
        }

        public void NewMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass271;
            BtnDelete.Visible = false;

            if (Request.QueryString["FMode"] != null)
            {
                BtnNew.Visible = false;
                BtnEdit.Visible = false;
                BtnDelete.Visible = false;
            }
            if (!(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass272) ControlsOnOff(true);
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
                    this.Page.Header.Title = "طلب دفع";
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
                        AreaNo = Session["AreaNo"].ToString();
                        vAreaNo = AreaNo;
                        if (Request.QueryString["Flag"] == null)
                        {
                            SiteInfo = (CostCenter)Session["SiteInfo"];
                        }
                    }
                    if (Request.QueryString["StoreNo"] != null) StoreNo = Request.QueryString["StoreNo"].ToString();
                    else
                    {
                        if (Session["StoreNo"] == null) Session["StoreNo"] = 1;
                        StoreNo = Session["StoreNo"].ToString();
                    }

                    if (Request.QueryString["Flag"] != null)
                    {
                        if (Request.QueryString["Flag"].ToString() == "0") vAreaNo = "00000";
                    }
                    if (Request.QueryString["FType"] != null) FType = short.Parse(Request.QueryString["FType"].ToString());
                    if (FType == 4)
                    {
                        if (Request.QueryString["StoreNo"] != null) vAreaNo = Request.QueryString["StoreNo"].ToString();
                    }
                    else if (FType == 6)
                    {
                        if (Request.QueryString["StoreNo"] != null) vAreaNo = "00001";
                    }
                    lblBranch2.Text = "/" + (FType == 6 ? "01" : FType == 4 ? "00" + short.Parse(vAreaNo).ToString() : short.Parse(vAreaNo).ToString());
                    lblBranch2.Visible = (vAreaNo != "00000");

                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    vRoleName = moh.GetCurrentRole(vAreaNo != "00000" ? vAreaNo : "00001", (from useritm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                                                                           where useritm.UserName == Session["CurrentUser"].ToString()
                                                                                           select useritm).FirstOrDefault());
                    if (Session[vRoleName] == null)
                    {
                        Response.Redirect("WebNotPrev.aspx", false);
                        return;
                    }
                    BtnNew.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass271;
                    BtnEdit.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass272;
                    BtnDelete.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass273;
                    BtnSearch.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass274;
                    BtnFind.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass274;
                    BtnPrint.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass275;

                    if (Request.QueryString["FMode"] != null)
                    {
                        BtnNew.Visible = false;
                        BtnEdit.Visible = false;
                        BtnDelete.Visible = false;
                    }

                    if (Request.QueryString["FNum"] != null)
                    {
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
                txtVouNo.Text = "";
                txtVouDate.Text = "";
                txtAmount.Text = "";
                lblStatus.Text = "";
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                if (sender != null)
                {
                    MyPO myJv = new MyPO();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = FType;
                    myJv.LocNumber = short.Parse(vAreaNo);
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
                VouData.Clear();
                LoadVouData();
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
            txtVouDate.Enabled = State;
            txtAmount.ReadOnly = !State;
            txtVouDate.ReadOnly = !State;
            //grdAttach.Enabled = State;
            foreach (GridViewRow itm in grdAttach.Rows)
            {
                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                if (BtnDelete != null) BtnDelete.Visible = State;
            }
            //grdCodes.Enabled = State;
            grdCodes.ShowFooter = State;
            foreach (GridViewRow itm in grdCodes.Rows)
            {
                ImageButton BtnDelete = itm.FindControl("btnDelete") as ImageButton;
                if (BtnDelete != null)
                {
                    BtnDelete.Visible = State;
                    BtnDelete.Enabled = State;
                }
            }
            FileUpload1.Enabled = State;
            BtnAttach.Enabled = State;
        }


        protected void LoadVouData()
        {
            try
            {
                grdCodes.DataSource = VouData;
                grdCodes.DataBind();
                if (grdCodes.Rows == null || grdCodes.Rows.Count < 1)
                {
                    MyPO inv = new MyPO();
                    List<MyPO> Listax = new List<MyPO>();
                    Listax.Add(inv);
                    grdCodes.DataSource = Listax;
                    grdCodes.DataBind();
                    grdCodes.Rows[0].Cells.Clear();
                }
                else
                {
                    if (Request.QueryString["FMode"] != null && (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass341)
                    {
                        grdCodes.Enabled = true;
                        for (int i = 0; i < grdCodes.Rows.Count; i++)
                        {
                            grdCodes.Rows[i].Cells[5].Enabled = false;
                            DropDownList ddlApproved = grdCodes.Rows[i].FindControl("ddlApproved") as DropDownList;
                            DropDownList ddlApproved2 = grdCodes.FooterRow.FindControl("ddlApproved2") as DropDownList;                           
                            if (ddlApproved != null) ddlApproved.Enabled = true;
                            if (ddlApproved != null) ddlApproved2.Enabled = true;
                        }
                    }
                }
                if (FType == 4) grdCodes.HeaderRow.Cells[2].Text = "سند صرف/مشتريات";

                //if (grdCodes.FooterRow != null)
                //{
                //    TextBox txtVouNo2 = grdCodes.FooterRow.FindControl("txtVouNo2") as TextBox;
                //    TextBox txtPrice = grdCodes.FooterRow.FindControl("txtPrice") as TextBox;
                //    TextBox txtItem = grdCodes.FooterRow.FindControl("txtItem") as TextBox;
                //    txtVouNo2.Attributes.Add("onchange", "javascript:CallMe('" + txtVouNo2.ClientID + "', ['" + txtPrice.ClientID + "', '" + txtItem.ClientID + "'])");
                //    txtVouNo2.ReadOnly = false;
                //}
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

                    BtnNew.Enabled = false;
                    if (txtAmount.Text != "" && (vAreaNo != "00000"  && FType==2))
                    {
                        if (moh.StrToDouble(txtAmount.Text) > SiteInfo.CrLimit)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تجاوزت حد الائتمان المخصص لك";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    } 
                    MyPO inv = new MyPO();
                    inv.Branch = short.Parse(Session["Branch"].ToString());
                    inv.FType = FType;
                    inv.LocNumber = short.Parse(vAreaNo); 
                    inv.Number = int.Parse(txtVouNo.Text);
                    inv = inv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (inv != null)
                    {
                        if (inv.UserName == txtUserName.ToolTip)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم الطلب مكرر";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }
                        else
                        {
                            inv = new MyPO();
                            inv.Branch = short.Parse(Session["Branch"].ToString());
                            inv.FType = FType;
                            inv.LocNumber = short.Parse(vAreaNo);
                            int? i = inv.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
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
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        BtnClear_Click(sender, e);
                        BtnNew.Enabled = true;
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        BtnNew.Enabled = true;
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
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
                        if (DateTime.Parse(txtVouDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }
                    }

                    if (txtAmount.Text != "" && vAreaNo != "00000" && FType == 2)
                    {
                        if (moh.StrToDouble(txtAmount.Text) > SiteInfo.CrLimit)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تجاوزت حد الائتمان المخصص لك";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
                    MyPO inv = new MyPO();
                    inv.Branch = short.Parse(Session["Branch"].ToString());
                    inv.FType = FType;
                    inv.LocNumber = short.Parse(vAreaNo);
                    inv.Number = int.Parse(txtVouNo.Text);
                    inv = inv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (inv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الطلب غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    }
                    else
                    {
                        inv.Branch = short.Parse(Session["Branch"].ToString());
                        inv.FType = FType;
                        inv.LocNumber = short.Parse(vAreaNo);
                        inv.Number = int.Parse(txtVouNo.Text);
                        if (inv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (Saveall())
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                                BtnClear_Click(sender, e);
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

                    MyPO inv = new MyPO();
                    inv.Branch = short.Parse(Session["Branch"].ToString());
                    inv.FType = FType;
                    inv.LocNumber = short.Parse(vAreaNo);
                    inv.Number = int.Parse(txtVouNo.Text);
                    inv = inv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (inv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الطلب غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    }
                    else
                    {
                        inv.Branch = short.Parse(Session["Branch"].ToString());
                        inv.FType = FType;
                        inv.LocNumber = short.Parse(vAreaNo);
                        inv.Number = int.Parse(txtVouNo.Text);
                        if (inv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormAction = "الغاء";
                            UserTran.FormName = "طلب دفع";
                            UserTran.Description = "الغاء بيانات طلب دفع رقم " + txtVouNo.Text;
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

        protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtSearch.Text != "")
                {
                    string vs = txtSearch.Text;
                    BtnClear_Click(sender, e);
                    txtSearch.Text = vs;

                    List<MyPO> lJv = new List<MyPO>();
                    MyPO inv = new MyPO();
                    inv.Branch = short.Parse(Session["Branch"].ToString());
                    inv.FType = FType;
                    inv.LocNumber = short.Parse(vAreaNo);
                    inv.Number = int.Parse(txtSearch.Text);
                    lJv = inv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (lJv == null || lJv.Count == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الطلب غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    }
                    else
                    {
                        bool approve = false;
                        foreach (MyPO itm in lJv)
                        {
                            if (itm.Approved != 0)
                            {
                                approve = true;
                                break;
                            }
                        }                        

                        txtVouNo.Text = txtSearch.Text;
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
                        VouData.Clear();
                        VouData.AddRange(lJv);
                        LoadVouData();
                        MakeSum();
                        LoadAttachData();
                        if (approve)
                        {
                            BtnNew.Visible = false;
                            BtnEdit.Visible = false;
                            BtnDelete.Visible = false;
                            ControlsOnOff(false);
                            BtnPrint.Visible = true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass275;

                            string InvNo = (FType == 6 ? "01" : FType == 4 ? "00" :"") + inv.LocNumber.ToString() + "/" + inv.Number.ToString();
                            Jv vJv = new Jv();
                            vJv.Branch = short.Parse(HttpContext.Current.Session["Branch"].ToString());
                            vJv.FType = 102;
                            vJv.LocType = 1;
                            vJv.InvNo = InvNo;
                            vJv.DocType = 0;
                            string vError = "";
                            bool vGet = true;
                            foreach (Jv itm in vJv.findInvNo200(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
                            {
                                if (vGet)
                                {
                                    vError += "تم أدراج المستند في سند الصرف رقم  ";
                                    vGet = false;
                                }
                                vError += "  " + @"<a href='WebPay12.aspx?Flag=0&AreaNo=" + moh.MakeMask(itm.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + @"' target='_blank'>" + itm.LocNumber.ToString() + @"/" + itm.Number.ToString() + @"</a>";
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
                                    if (vError != "") vError += "  " + "تم أدراج المستند في التحويل البنكي رقم  ";
                                    else vError = "تم أدراج المستند في التحويل البنكي رقم  ";
                                    vGet = false;
                                }
                                vError += "  " + @"<a href='WebBankTrans.aspx?Flag=0&AreaNo=" + moh.MakeMask(itm.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + @"' target='_blank'>" + itm.LocNumber.ToString() + @"/" + itm.Number.ToString() + @"</a>";
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
                                    if (vError != "") vError += "  " + "تم أدراج المستند في قيد يومية رقم  ";
                                    else vError = "تم أدراج المستند في قيد يومية رقم  ";
                                    vGet = false;
                                }
                                vError += "  " +@"<a href='WebJVou.aspx?Flag=0&AreaNo=" + moh.MakeMask(itm.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + @"' target='_blank'>" + itm.LocNumber.ToString() + @"/" + itm.Number.ToString() + @"</a>";
                            }
                            lblStatus.Text = vError;
                        }
                        else EditMode();
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم الطلب";
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
            try
            {
                      if (Page.IsValid)
                      {
                          iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, -50, -50, 80, 50);
                          HttpContext.Current.Response.ContentType = "application/pdf";
                          PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
                          pdfPage page = new pdfPage();
                          MyConfig mySetting = new MyConfig();
                          mySetting.Branch = short.Parse(Session["Branch"].ToString());
                          if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                          mySetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                          if (mySetting != null)
                          {
                              page.vCompanyName = mySetting.CompanyName;
                          }

                          writer.PageEvent = page;

                          page.vStr1 = "";
                          page.vStr2 = "";
                          page.PageNo = "1";
                          page.UserName = Session["FullUser"].ToString();
                          //page.vStr3 = Session["AreaName"].ToString();
                          if (vAreaNo != "00000")
                          {
                              if (FType == 4) page.vStr3 = "الصيانة";
                              else if (FType == 6) page.vStr3 = "الشئون الإدارية";
                              else page.vStr3 = SiteInfo.Name1;
                          }
                          else page.vStr3 = "الإدارة المالية";
                          string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                          BaseFont nationalBase;
                          nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                          iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);
                          iTextSharp.text.Font nationalTextFont16 = new iTextSharp.text.Font(nationalBase, 16f, iTextSharp.text.Font.NORMAL);

                          int ColCount = 5;
                          var cols = new[] { 125, 125, 125, 150, 225 };

                          document.Open();

                          PdfPTable table10 = new PdfPTable(ColCount);
                          table10.TotalWidth = document.PageSize.Width; //100f;
                          table10.SetWidths(cols);
                          PdfPCell cell = new PdfPCell();
                          cell.Border = 0;
                          cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                          //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                          table10.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                          table10.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                          cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                          table10.AddCell(cell);

                          cell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                          cell.Phrase = new iTextSharp.text.Phrase(" طلب دفع رقم ", nationalTextFont16);
                          table10.AddCell(cell);

                          PdfPCell cell22 = new PdfPCell();
                          cell22.ArabicOptions = ColumnText.DIGITS_EN2AN;
                          cell22.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                          cell22.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                          cell22.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                          cell22.Phrase = new iTextSharp.text.Phrase(txtVouNo.Text + lblBranch2.Text, nationalTextFont16);
                          table10.AddCell(cell22);

                          cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                          table10.AddCell(cell);

                          var TextCell = new PdfPCell(table10.DefaultCell);
                          TextCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                          TextCell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                          //TextCell.Border = 0;
                          TextCell.BorderColor = iTextSharp.text.BaseColor.WHITE;
                          PdfContentByte cb = writer.DirectContent;
                          var bc128 = new Barcode128();
                          bc128.CodeType = Barcode.CODE128;
                          bc128.Code = lblBranch2.Text + txtVouNo.Text;
                          bc128.GenerateChecksum = true;
                          bc128.AltText = "";
                          bc128.StartStopText = true;

                          TextCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                          //cell.AddElement(bc128.CreateImageWithBarcode(cb, null, null));                    
                          var bi = bc128.CreateImageWithBarcode(cb, null, null);
                          bi.ScalePercent(100);
                          bi.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                          TextCell.AddElement(bi);

                          //cell.Image = bc128.CreateImageWithBarcode(cb, null, null);                    
                          //table.AddCell(cell);
                          table10.AddCell(TextCell);
                          document.Add(table10);
                          document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                          //-------------------------------------------------------------------------------------------

                          ColCount = 4;
                          cols = new[] { 125, 125, 300, 200 };
                          PdfPTable table = new PdfPTable(ColCount);
                          table.TotalWidth = document.PageSize.Width; //100f;
                          table.SetWidths(cols);
                          cell = new PdfPCell();
                          cell.Border = 0;
                          cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                          //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                          table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                          table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                          cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                          cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                          table.AddCell(cell);

                          cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                          table.AddCell(cell);

                          cell.Phrase = new iTextSharp.text.Phrase("التاريخ", nationalTextFont);
                          table.AddCell(cell);

                          cell.Phrase = new iTextSharp.text.Phrase(txtVouDate.Text, nationalTextFont);
                          table.AddCell(cell);
                          //
                          document.Add(table);


                          ColCount = 4;
                          cols = new[] { 150, 350, 120, 100 };
                          table = new PdfPTable(ColCount);
                          table.TotalWidth = document.PageSize.Width; //100f;
                          table.SetWidths(cols);
                          cell = new PdfPCell();
                          cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                          //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                          table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                          table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                          cell.BackgroundColor = iTextSharp.text.BaseColor.GRAY;
                          cell.Phrase = new iTextSharp.text.Phrase("تسلسل", nationalTextFont);
                          table.AddCell(cell);

                          if (FType == 4) cell.Phrase = new iTextSharp.text.Phrase("صرف/مشتريات", nationalTextFont);
                          else cell.Phrase = new iTextSharp.text.Phrase("سند الصرف", nationalTextFont);
                          table.AddCell(cell);
                          //
                          cell.Phrase = new iTextSharp.text.Phrase("البند", nationalTextFont);
                          table.AddCell(cell);

                          cell.Phrase = new iTextSharp.text.Phrase("المبلغ", nationalTextFont);
                          table.AddCell(cell);
                          //

                          foreach (MyPO itm in VouData)
                          {
                              cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                              cell.Phrase = new iTextSharp.text.Phrase(itm.FNo.ToString(), nationalTextFont);
                              table.AddCell(cell);

                              cell.Phrase = new iTextSharp.text.Phrase(itm.VouNo, nationalTextFont);
                              table.AddCell(cell);
                              //
                              cell.Phrase = new iTextSharp.text.Phrase(itm.Item, nationalTextFont);
                              table.AddCell(cell);

                              cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Price), nationalTextFont);
                              table.AddCell(cell);
                          }

                          cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                          cell.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                          table.AddCell(cell);

                          cell.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                          table.AddCell(cell);
                          //
                          cell.Phrase = new iTextSharp.text.Phrase("الاجمالي", nationalTextFont);
                          table.AddCell(cell);

                          cell.Phrase = new iTextSharp.text.Phrase(txtAmount.Text, nationalTextFont);
                          table.AddCell(cell);
                          document.Add(table);


                          var cols5 = new[] { 275, 125, 300, 100 };
                          PdfPTable table50 = new PdfPTable(5);
                          table50.TotalWidth = 100f;
                          PdfPCell cell5 = new PdfPCell();
                          cols5 = new[] { 150, 150, 150, 150, 150 };
                          table50.SetWidths(cols5);
                          cell5.ArabicOptions = ColumnText.DIGITS_EN2AN;
                          table50.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                          table50.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                          cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                          cell5.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                          cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                          cell5.Border = 0;
                          table50.AddCell(cell5);
                          table50.AddCell(cell5);
                          table50.AddCell(cell5);
                          table50.AddCell(cell5);
                          table50.AddCell(cell5);
                          table50.AddCell(cell5);

                          cell5.Phrase = new iTextSharp.text.Phrase("إدخلت بواسطة", nationalTextFont);
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

                          cell5.Phrase = new iTextSharp.text.Phrase(txtUserName.Text, nationalTextFont);
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
                var cols2 = new[] { 225, 300, 225 };
                headerTbl.SetWidths(cols2);

                headerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                //set the width of the table to be the same as the document
                headerTbl.TotalWidth = doc.PageSize.Width;

                PdfPCell cell2 = new PdfPCell();
                cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell2.Border = 0;
                cell2.PaddingRight = 15;
                cell2.Phrase = new iTextSharp.text.Phrase(vCompanyName + "\n" + vStr3, nationalTextFont);
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
                var cols2 = new[] { 175, 175, 275, 175 }; 
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
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                //set cell border to 0
                cell.Border = 2;

                if (moh.PrintDateofPrint) cell.Phrase = new iTextSharp.text.Phrase("تاريخ الطباعة : " + String.Format("{0:dd/MM/yyyy}", moh.Nows()), footer);
                else cell.Phrase = new iTextSharp.text.Phrase(" ", footer);
                footerTbl.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("طبعت بواسطة " + UserName, footer);
                footerTbl.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("عدد مرات الطباعة " + PageNo, footer);
                footerTbl.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("صفحة رقم " + writer.PageNumber.ToString(), footer);
                footerTbl.AddCell(cell);

                //write the rows out to the PDF output stream.
                footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin - 10), writer.DirectContent);
            }
        }

        private bool Saveall()
        {
            try
            {
                foreach (MyPO itm in VouData)
                {
                    itm.Branch = short.Parse(Session["Branch"].ToString());
                    itm.FType = FType;
                    itm.LocNumber = short.Parse(vAreaNo);
                    itm.Number = int.Parse(txtVouNo.Text);
                    itm.FDate = moh.CheckDate(txtVouDate.Text);
                    itm.UserName = txtUserName.ToolTip;
                    itm.UserDate = txtUserDate.Text;
                    itm.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }
                return true;
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


        protected void grdCodes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Insert"))
                {
                    ImageButton btnInsert = e.CommandSource as ImageButton;
                    if (btnInsert == null)
                    {
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    GridViewRow gvr = btnInsert.NamingContainer as GridViewRow;
                    if (gvr == null)
                    {
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    TextBox txtItem = gvr.FindControl("txtItem") as TextBox;
                    TextBox txtVouNo2 = gvr.FindControl("txtVouNo2") as TextBox;
                    TextBox txtPrice = gvr.FindControl("txtPrice") as TextBox;

                    if (txtItem == null || txtPrice == null || txtVouNo2 == null)
                    {
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    if (txtVouNo2.Text == "")
                    {
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب إدخال رقم سند الصرف";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                    else
                    {
                        int Number = 0;
                        if (txtVouNo2.Text.Split('/').Count() < 2)
                        {
                            txtVouNo2.Text = int.Parse(vAreaNo).ToString() + "/" +txtVouNo2.Text;
                        }
                        Number = int.Parse(moh.MakeMask(txtVouNo2.Text.Split('/')[1], 5));

                        if (FType == 4 && txtVouNo2.Text.Split('/')[0].Length < 2)
                        {
                            Jv myJv = new Jv();
                            vJv myJv2 = new vJv();
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.FType = 501;
                            myJv.LocType = 2;
                            myJv.LocNumber = 1;
                            myJv.Number = Number;
                            myJv2 = myJv.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).LastOrDefault();
                            if (myJv2 == null)
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "رقم فاتورة المشتريات غير معرف من قبل";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.FType = 502;
                            myJv.InvNo = Number.ToString();
                            myJv = myJv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myJv != null)
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "تم ارجاع  فاتورة المشتريات بفاتورة مرتجع مشتريات رقم " + myJv.Number.ToString() + "/" + myJv.LocNumber.ToString();
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }

                            if (Number < 417)
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "تسلسل الفاتورة مسدد من قبل";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }

                            if (myJv2.CrCode != "120103014")
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "فاتورة المشتريات غير مسدده من حساب العهدة";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }

                            MyPO inv = new MyPO();
                            inv.Branch = short.Parse(Session["Branch"].ToString());
                            inv.FType = FType;
                            inv.LocNumber = short.Parse(vAreaNo);
                            inv.VouNo = txtVouNo2.Text;
                            inv = inv.GetVouNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (inv != null)
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد تم ادراج فاتورة المشتريات من قبل في طلب الدفع رقم " + inv.Number.ToString();
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }

                            for (int i = 0; i < VouData.Count(); i++)
                            {
                                if (VouData[i].VouNo == txtVouNo2.Text)
                                {
                                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                    LblCodesResult.Text = "لقد تم ادراج فاتورة المشتريات من قبل ";
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                    return;
                                }
                            }

                            txtPrice.Text = myJv2.Amount.ToString();
                            if (txtItem.Text == "") txtItem.Text = "فاتورة مشتريات رقم " + txtVouNo2.Text;
                            VouData.Add(new MyPO { FNo = (short)(VouData.Count() + 1), Item = txtItem.Text, Price = moh.StrToDouble(txtPrice.Text), VouNo = txtVouNo2.Text });
                        }
                        else
                        {
                            Jv myJv = new Jv();
                            vJv myJv2 = new vJv();
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.FType = 102;
                            myJv.LocNumber = short.Parse(vAreaNo);

                            if (vAreaNo == "00000") myJv.LocType = 1;
                            else if (FType == 4)
                            {
                                myJv.LocType = 4;
                                myJv.LocNumber = 1;
                            }
                            else if (FType == 6)
                            {
                                myJv.LocType = 3;
                                myJv.LocNumber = 1;
                            }
                            else
                            {
                                myJv.LocType = 2;
                                myJv.LocNumber = short.Parse(txtVouNo2.Text.Split('/')[0]);
                            }

                            myJv.Number = Number;
                            myJv2 = myJv.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).LastOrDefault();
                            if (myJv2 == null)
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "رقم السند الصرف غير معرف من قبل";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                            if ((DateTime.Parse(txtVouDate.Text) - DateTime.Parse(myJv2.FDate)).TotalDays >= 60 && Session["CurrentUser"].ToString() != "sameh")
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد تم اغلاق الفترة";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }

                            MyPO inv = new MyPO();
                            inv.Branch = short.Parse(Session["Branch"].ToString());
                            inv.FType = FType;
                            inv.LocNumber = short.Parse(vAreaNo);
                            inv.VouNo = txtVouNo2.Text;
                            inv = inv.GetVouNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (inv != null)
                            {
                                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = "لقد تم ادراج سند الصرف من قبل في طلب الدفع رقم " + inv.Number.ToString();
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }

                            for (int i = 0; i < VouData.Count(); i++)
                            {
                                if (VouData[i].VouNo == txtVouNo2.Text)
                                {
                                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                    LblCodesResult.Text = "لقد تم ادراج سند الصرف من قبل ";
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                    return;
                                }
                            }

                            txtPrice.Text = myJv2.Amount.ToString();
                            if (txtItem.Text == "") txtItem.Text = myJv2.Remark;
                            VouData.Add(new MyPO { FNo = (short)(VouData.Count() + 1), Item = txtItem.Text, Price = moh.StrToDouble(txtPrice.Text), VouNo = txtVouNo2.Text });
                        }
                        MakeSum();
                        LoadVouData();
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

        protected void grdCodes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string FNo = grdCodes.DataKeys[e.RowIndex]["FNo"].ToString();
                VouData.RemoveAt(int.Parse(FNo) - 1);
                for (int i = 0; i < VouData.Count; i++)
                {
                    VouData[i].FNo = (short)(i + 1);
                }
                e.Cancel = false;
                MakeSum();
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

        private void MakeSum()
        {
            try
            {
                double Amount = 0;
                double Amount2 = 0;
                foreach (MyPO itm in VouData)
                {
                    Amount += (double)itm.Amount;
                    if (itm.Approved == 1) Amount2 += (double)itm.Amount;
                }
                txtAmount.Text = string.Format("{0:N2}", Amount);
                txtAmount2.Text = string.Format("{0:N2}", Amount2);
                if (txtAmount.Text != "" && vAreaNo != "00000" && Request.QueryString["FMode"] == null)
                {
                    if (moh.StrToDouble(txtAmount.Text) > SiteInfo.CrLimit)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد تجاوزت حد الائتمان المخصص لك";
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

        protected void BtnAttach_Click(object sender, ImageClickEventArgs e)
        {
            if (FileUpload1.HasFile)
                try
                {
                    MyConfig mySetting = new MyConfig();
                    mySetting.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    mySetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                    if(mySetting!=null)
                    {
                        string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
                        String FileName = Config.GetImageName(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + fileExt;
                        FileUpload1.SaveAs(mySetting.ImagePath+FileName);

                        Arch myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(vAreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = (FType == 4 ? 512 : FType == 2 ? 513 : 501);

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(vAreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = (FType == 4 ? 512 : FType == 2 ? 513 : 501);
                        myArch.FileName = FileUpload1.FileName;
                        myArch.FileName2 = mySetting.ImagePath2+FileName;
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
                myArch.LocNumber = short.Parse(vAreaNo);
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = (FType == 4 ? 512 : FType == 2 ? 513 : 501);
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
            Arch myArch = new Arch();
            myArch.Branch = short.Parse(Session["Branch"].ToString());
            myArch.LocNumber = short.Parse(vAreaNo);
            myArch.Number = int.Parse(txtVouNo.Text);
            myArch.DocType = (FType == 4 ? 512 : FType == 2 ? 513 : 501);
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

        [System.Web.Services.WebMethod (EnableSession = true)]
        public static string[] GetDate(string VouNo)
        {
            string vstr = "";
            string vstr1 = "";
            try
            {
                CarMove myCar = new CarMove();
                myCar.Branch = 1;
                myCar.VouLoc = moh.MakeMask(VouNo.Split('/')[0], 5);
                myCar.Number = int.Parse(VouNo.Split('/')[1]);

                myCar = myCar.Find(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                if (myCar != null)
                {
                    CarPrices myPrice = new CarPrices();
                    myPrice.Branch = 1;
                    myPrice.MonthNo = 0;
                    myPrice.FromCode = myCar.FromLoc;
                    myPrice.toCode = myCar.ToLoc;
                    myPrice.PLevel = "00002";
                    myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
                    if (myPrice != null)
                    {
                        vstr = string.Format("{0:N2}", myPrice.CostAmount);
                        Drivers myDrive = new Drivers();
                        myDrive.Branch = 1;
                        if (HttpRuntime.Cache["Drivers" + HttpContext.Current.Session["CNN2"].ToString()] == null) HttpRuntime.Cache.Insert("Drivers" + HttpContext.Current.Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString));
                        myDrive.Code = myCar.DriverCode;
                        myDrive = (from sitm in (List<Drivers>)(HttpRuntime.Cache["Drivers" + HttpContext.Current.Session["CNN2"].ToString()])
                                   where sitm.Code == myDrive.Code
                                   select sitm).FirstOrDefault();
                        if (myDrive != null)
                        {
                            vstr1 = myDrive.Name1;
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                vstr = ex.Message;
                vstr = "";
                vstr1 = "";
            }            
            return new string[] { vstr,vstr1 };
        }

        protected void ddlApproved_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddlApproved = sender as DropDownList;
                GridViewRow gvr = ddlApproved.NamingContainer as GridViewRow;
                string FNo = grdCodes.DataKeys[gvr.RowIndex]["FNo"].ToString();

                MyPO myPo = new MyPO();
                myPo.Branch = short.Parse(Session["Branch"].ToString());
                myPo.FType = FType;
                myPo.LocNumber = short.Parse(vAreaNo);
                myPo.Number = int.Parse(txtVouNo.Text);
                myPo.FNo = short.Parse(FNo);
                myPo.Approved = short.Parse(ddlApproved.SelectedValue);
                myPo.UpdateStatus(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                {
                    Transactions UserTran = new Transactions();
                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                    UserTran.UserName = Session["CurrentUser"].ToString();
                    UserTran.FormName = "طلب دفع";
                    UserTran.FormAction = ddlApproved.SelectedItem.Text;
                    UserTran.Description = ddlApproved.SelectedItem.Text + " على بند طلب دفع رقم " + lblBranch2.Text + "/" + txtVouNo.Text + "-" + myPo.FNo.ToString();
                    UserTran.IP = IPNetworking.GetIP4Address();
                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                }

                VouData[myPo.FNo - 1].Approved = myPo.Approved;
                LoadVouData();
                MakeSum();
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


        protected void ddlApproved2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddlApproved2 = sender as DropDownList;
                foreach (MyPO itm in VouData)
                {
                    MyPO myPo = new MyPO();
                    myPo.Branch = short.Parse(Session["Branch"].ToString());
                    myPo.FType = FType;
                    myPo.LocNumber = short.Parse(vAreaNo);
                    myPo.Number = int.Parse(txtVouNo.Text);
                    myPo.FNo = itm.FNo;
                    myPo.Approved = short.Parse(ddlApproved2.SelectedValue);
                    myPo.UpdateStatus(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = "طلب دفع";
                        UserTran.FormAction = ddlApproved2.SelectedItem.Text;
                        UserTran.Description = ddlApproved2.SelectedItem.Text + " على بند طلب دفع رقم " + lblBranch2.Text + "/" + txtVouNo.Text + "-" + myPo.FNo.ToString();
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }
                    itm.Approved = myPo.Approved;
                }
                LoadVouData();
                MakeSum();
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

        protected string UrlHelper(object FType, object Number)
        {
            string[] vs = Number.ToString().Split('/');
            if (vs.Count() > 1)
            {
                switch (short.Parse(FType.ToString()))
                {
                    case 1: if(vs[0] == "001")
                        return (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass415 ? "~/WebPay1.aspx?FType=200&FNum=" + vs[1] + "&AreaNo=" + AreaNo + "&Flag=0&StoreNo=" + StoreNo : "";
                        else return (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass415 ? "~/WebPay1.aspx?FType=2&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&Flag=0&StoreNo=" + StoreNo : "";
                    default: return "";
                }
            }
            else return "";
        }
    }
}
