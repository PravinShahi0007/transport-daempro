using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using System.Threading;
using System.Globalization;

namespace WHS
{
    public partial class WebStores : System.Web.UI.Page
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
            txtNumber.ReadOnly = true;
            txtNumber.BackColor = System.Drawing.Color.LightGray;

            BtnEdit.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass192;
            BtnNew.Visible = false;
            BtnDelete.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass193;
        }

        public void NewMode()
        {
            txtNumber.ReadOnly = false;
            txtNumber.BackColor = System.Drawing.Color.White;

            BtnEdit.Visible = false;
            BtnNew.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass191;
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
                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "بيانات المخازن / الورش";
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

                    Acc myacc = new Acc();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.FType = "2";
                    myacc.SType = "2";
                    myacc.Stype1 = "2";
                    ddlCash.DataSource = myacc.GetAllAccByType(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlCash.DataTextField = "Name1";
                    ddlCash.DataValueField = "Code";
                    ddlCash.DataBind();
                    ddlCash.Items.Insert(0, new ListItem("-----  أختر حساب النقدية  -----", "-1", true));
                    ddlCash.SelectedIndex = 0;

                    myacc.FType = "5";
                    myacc.SType = "B";
                    myacc.Stype1 = "8";
                    myacc.FCode = "12";
                    //ddlCSal.DataSource = myacc.GetAllAccByType(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlCSal.DataSource = myacc.GetAllAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlCSal.DataTextField = "Name1";
                    ddlCSal.DataValueField = "Code";
                    ddlCSal.DataBind();
                    ddlCSal.Items.Insert(0, new ListItem("-----  أختر حساب المبيعات النقدية  -----", "-1", true));
                    ddlCSal.SelectedIndex = 0;

                    ddlCRSal.DataSource = ddlCSal.DataSource;
                    ddlCRSal.DataTextField = "Name1";
                    ddlCRSal.DataValueField = "Code";
                    ddlCRSal.DataBind();
                    ddlCRSal.Items.Insert(0, new ListItem("-----  أختر حساب المبيعات الآجلة  -----", "-1", true));
                    ddlCRSal.SelectedIndex = 0;

                    myacc.FType = "6";
                    myacc.SType = "B";
                    myacc.Stype1 = "8";
                    ddlCPur.DataSource = ddlCSal.DataSource;
                    //ddlCPur.DataSource = myacc.GetAllAccByType(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlCPur.DataTextField = "Name1";
                    ddlCPur.DataValueField = "Code";
                    ddlCPur.DataBind();
                    ddlCPur.Items.Insert(0, new ListItem("-----  أختر حساب المشتريات النقدية  -----", "-1", true));
                    ddlCPur.SelectedIndex = 0;

                    ddlCRPur.DataSource = ddlCPur.DataSource;
                    ddlCRPur.DataTextField = "Name1";
                    ddlCRPur.DataValueField = "Code";
                    ddlCRPur.DataBind();
                    ddlCRPur.Items.Insert(0, new ListItem("-----  أختر حساب المشتريات الآجلة  -----", "-1", true));
                    ddlCRPur.SelectedIndex = 0;

                    ddlRCSal.DataSource = ddlCSal.DataSource;
                    //ddlRCSal.DataSource = myacc.GetAllReturnType(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlRCSal.DataTextField = "Name1";
                    ddlRCSal.DataValueField = "Code";
                    ddlRCSal.DataBind();
                    ddlRCSal.Items.Insert(0, new ListItem("-----  أختر حساب ترجيع المبيعات النقدية  -----", "-1", true));
                    ddlRCSal.SelectedIndex = 0;

                    ddlRCRSal.DataSource = ddlRCSal.DataSource;
                    ddlRCRSal.DataTextField = "Name1";
                    ddlRCRSal.DataValueField = "Code";
                    ddlRCRSal.DataBind();
                    ddlRCRSal.Items.Insert(0, new ListItem("-----  أختر حساب ترجيع المبيعات الآجلة  -----", "-1", true));
                    ddlRCRSal.SelectedIndex = 0;

                    ddlRCPur.DataSource = ddlRCSal.DataSource;
                    ddlRCPur.DataTextField = "Name1";
                    ddlRCPur.DataValueField = "Code";
                    ddlRCPur.DataBind();
                    ddlRCPur.Items.Insert(0, new ListItem("-----  أختر حساب ترجيع المشتريات النقدية  -----", "-1", true));
                    ddlRCPur.SelectedIndex = 0;

                    ddlRCRPur.DataSource = ddlRCSal.DataSource;
                    ddlRCRPur.DataTextField = "Name1";
                    ddlRCRPur.DataValueField = "Code";
                    ddlRCRPur.DataBind();
                    ddlRCRPur.Items.Insert(0, new ListItem("-----  أختر حساب ترجيع المشتريات الآجلة  -----", "-1", true));
                    ddlRCRPur.SelectedIndex = 0;

                    myacc.FType = "5";
                    myacc.SType = "C";
                    myacc.Stype1 = "8";
                    ddlService.DataSource = ddlCSal.DataSource;
                    //ddlService.DataSource = myacc.GetAllAccByType(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlService.DataTextField = "Name1";
                    ddlService.DataValueField = "Code";
                    ddlService.DataBind();
                    ddlService.Items.Insert(0, new ListItem("-----  أختر حساب الخدمات  -----", "-1", true));
                    ddlService.SelectedIndex = 0;

                    ddlPDisc.DataSource = ddlService.DataSource;
                    ddlPDisc.DataTextField = "Name1";
                    ddlPDisc.DataValueField = "Code";
                    ddlPDisc.DataBind();
                    ddlPDisc.Items.Insert(0, new ListItem("-----  أختر حساب الخصم المكتسب  -----", "-1", true));
                    ddlPDisc.SelectedIndex = 0;

                    myacc.FType = "7";
                    myacc.SType = "C";
                    myacc.Stype1 = "8";
                    ddlSDisc.DataSource = ddlCSal.DataSource;
                    //ddlSDisc.DataSource = myacc.GetAllAccByType(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlSDisc.DataTextField = "Name1";
                    ddlSDisc.DataValueField = "Code";
                    ddlSDisc.DataBind();
                    ddlSDisc.Items.Insert(0, new ListItem("-----  أختر حساب الخصم المسوح به  -----", "-1", true));
                    ddlSDisc.SelectedIndex = 0;

                    BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass191;
                    BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass192;
                    BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass193;
                    BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass194;
                    BtnFind.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass194;

                    LoadStoresData();
                    BtnClear_Click(sender, null);
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

        protected void LoadStoresData()
        {
            try
            {
                Shop myShop = new Shop();
                myShop.FType = 2;
                myShop.Bran = 1;
                grdCodes.DataSource = myShop.GetAllType(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                grdCodes.DataBind();

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
                txtName1.Text = "";
                txtName2.Text = "";
                txtAddress.Text = "";
                txtManager.Text = "";
                txtRemark.Text = "";
                txtTel.Text = "";

                ddlCash.SelectedIndex = 0;
                ddlCPur.SelectedIndex = 0;
                ddlCRPur.SelectedIndex = 0;
                ddlCRSal.SelectedIndex = 0;
                ddlCSal.SelectedIndex = 0;
                ddlPDisc.SelectedIndex = 0;
                ddlRCPur.SelectedIndex = 0;
                ddlRCRPur.SelectedIndex = 0;
                ddlRCRSal.SelectedIndex = 0;
                ddlRCSal.SelectedIndex = 0;
                ddlSDisc.SelectedIndex = 0;
                ddlService.SelectedIndex = 0;

                Shop myShop = new Shop();
                myShop.FType = 2;
                myShop.Bran = 1;
                string s = myShop.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (s != null && s != "")
                {
                    txtNumber.Text = (Int32.Parse(s) + 1).ToString();
                }
                else
                {
                    txtNumber.Text = "1";
                }

            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void ddlBran_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadStoresData();
        }

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    Shop myShop = new Shop();
                    myShop.FType = 2;
                    myShop.Bran = 1;
                    myShop.Number = short.Parse(txtNumber.Text);

                    bool vfound = myShop.GetShop(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    while (vfound)
                    {
                        txtNumber.Text = (myShop.Number + 1).ToString();
                        myShop.Number = short.Parse(txtNumber.Text);
                        vfound = myShop.GetShop(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    myShop.Name1 = txtName1.Text;
                    myShop.Name2 = txtName2.Text;
                    myShop.Address = txtAddress.Text;
                    myShop.Manager = txtManager.Text;
                    myShop.Tel = txtTel.Text;
                    myShop.Remark = txtRemark.Text;

                    myShop.CSal_Acc = ddlCSal.SelectedValue;
                    myShop.CrSal_Acc = ddlCRSal.SelectedValue;
                    myShop.CPur_Acc = ddlCPur.SelectedValue;
                    myShop.CrPur_Acc = ddlCRPur.SelectedValue;
                    myShop.RCSal_Acc = ddlRCSal.SelectedValue;
                    myShop.RCRSal_Acc = ddlRCRSal.SelectedValue;
                    myShop.RCPur_Acc = ddlRCPur.SelectedValue;
                    myShop.RCRPur_Acc = ddlRCRPur.SelectedValue;
                    myShop.Cash_Acc = ddlCash.SelectedValue;
                    myShop.Service_Acc = ddlService.SelectedValue;
                    myShop.PDisc_Acc = ddlPDisc.SelectedValue;
                    myShop.SDisc_Acc = ddlSDisc.SelectedValue;

                    if (myShop.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        LoadStoresData();
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تم حفظ البيانات بنجاح";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ اثناء حفظ البيانات ... حاول مرة أخرى";
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

        protected void grdCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdCodes.PageIndex = e.NewPageIndex;
                LoadStoresData();
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
                    Shop myShop = new Shop();
                    myShop.FType = 2;
                    myShop.Bran = 1;
                    myShop.Number = short.Parse(txtNumber.Text);
                    if (myShop.GetShop(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        EditMode();
                        txtName1.Text = myShop.Name1;
                        txtName2.Text = myShop.Name2;
                        txtManager.Text = myShop.Manager;
                        txtAddress.Text = myShop.Address;
                        txtTel.Text = myShop.Tel;

                        ddlCSal.SelectedValue = myShop.CSal_Acc;
                        ddlCRSal.SelectedValue = myShop.CrSal_Acc;
                        ddlCPur.SelectedValue = myShop.CPur_Acc;
                        ddlCRPur.SelectedValue = myShop.CrPur_Acc;
                        ddlRCSal.SelectedValue = myShop.RCSal_Acc;
                        ddlRCRSal.SelectedValue = myShop.RCRSal_Acc;
                        ddlRCPur.SelectedValue = myShop.RCPur_Acc;
                        ddlRCRPur.SelectedValue = myShop.RCRPur_Acc;
                        ddlCash.SelectedValue = myShop.Cash_Acc;
                        ddlService.SelectedValue = myShop.Service_Acc;
                        ddlPDisc.SelectedValue = myShop.PDisc_Acc;
                        ddlSDisc.SelectedValue = myShop.SDisc_Acc;
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم المخزن/المعرض غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم المخزن/المعرض";
                    txtNumber.Focus();
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
                    Shop myShop = new Shop();
                    myShop.FType = 2;
                    myShop.Bran = 1;
                    myShop.Number = short.Parse(txtNumber.Text);
                    if (myShop.GetShop(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        myShop.Name1 = txtName1.Text;
                        myShop.Name2 = txtName2.Text;
                        myShop.Address = txtAddress.Text;
                        myShop.Manager = txtManager.Text;
                        myShop.Tel = txtTel.Text;
                        myShop.Remark = txtRemark.Text;

                        myShop.CSal_Acc = ddlCSal.SelectedValue;
                        myShop.CrSal_Acc = ddlCRSal.SelectedValue;
                        myShop.CPur_Acc = ddlCPur.SelectedValue;
                        myShop.CrPur_Acc = ddlCRPur.SelectedValue;
                        myShop.RCSal_Acc = ddlRCSal.SelectedValue;
                        myShop.RCRSal_Acc = ddlRCRSal.SelectedValue;
                        myShop.RCPur_Acc = ddlRCPur.SelectedValue;
                        myShop.RCRPur_Acc = ddlRCRPur.SelectedValue;
                        myShop.Cash_Acc = ddlCash.SelectedValue;
                        myShop.Service_Acc = ddlService.SelectedValue;
                        myShop.PDisc_Acc = ddlPDisc.SelectedValue;
                        myShop.SDisc_Acc = ddlSDisc.SelectedValue;

                        if (myShop.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LoadStoresData();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم حفظ البيانات بنجاح";
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
                        LblCodesResult.Text = "لقد حدث خطأ اثناء حفظ البيانات ... حاول مرة أخرى";
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

        protected void BtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtNumber.Text != "")
                {
                    Shop myShop = new Shop();
                    myShop.FType = 2;
                    myShop.Bran = 1;
                    myShop.Number = short.Parse(txtNumber.Text);
                    if (myShop.GetShop(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        // Pending Work Check for Transaction....

                        if (myShop.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LoadStoresData();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقم تم الغاء بيانات الموقع بنجاح";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "الفرع غير معرف من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم المخزن/المعرض";
                    txtNumber.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void grdCodes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                BtnClear_Click(sender, null);
                string Number = grdCodes.DataKeys[e.NewSelectedIndex]["number"].ToString();
                txtNumber.Text = Number;
                BtnSearch_Click(sender, null);
                e.NewSelectedIndex = -1;
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
                e.NewSelectedIndex = -1;
            }
        }

        protected void BtnFind_Click(object sender, ImageClickEventArgs e)
        {
            BtnSearch_Click(sender, e);
        }
    }
}