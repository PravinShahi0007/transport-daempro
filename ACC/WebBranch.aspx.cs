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

namespace ACC
{
    public partial class WebBranch : System.Web.UI.Page
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

            BtnEdit.Visible = true; // && (bool)((List<TblRoles>)(Session[RoleName]))[1].Pass212;
            BtnNew.Visible = false;
            BtnDelete.Visible = true; // && (bool)((List<TblRoles>)(Session[RoleName]))[1].Pass213;
        }

        public void NewMode()
        {
            txtNumber.ReadOnly = false;
            txtNumber.BackColor = System.Drawing.Color.White;

            BtnEdit.Visible = false;
            BtnNew.Visible = true; // && (bool)((List<TblRoles>)(Session[RoleName]))[1].Pass211;
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
                    this.Page.Header.Title = GetLocalResourceObject("Title").ToString();  // "بيانات الفروع";
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

                    LoadShopData();
                    BtnClear_Click(sender, null);
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

        protected void LoadShopData()
        {
            try
            {
                Shop myShop = new Shop();
                myShop.FType = 1;
                grdCodes.DataSource = myShop.GetAllType2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                grdCodes.DataBind();

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
                txtNumber.Text = "";
                txtName1.Text = "";
                txtName2.Text = "";
                txtAddress.Text = "";
                txtManager.Text = "";
                txtRemark.Text = "";
                txtTel.Text = "";

                NewMode();
                Shop myShop = new Shop();
                myShop.FType = 1;
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

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    Shop myShop = new Shop();

                    myShop.FType = 1;
                    myShop.Bran = short.Parse(txtNumber.Text);
                    myShop.Number = short.Parse(txtNumber.Text);
                    bool vfound = myShop.GetShop(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    while (vfound)
                    {
                        txtNumber.Text = (myShop.Bran + 1).ToString();
                        myShop.Bran = short.Parse(txtNumber.Text);
                        myShop.Number = short.Parse(txtNumber.Text);
                        vfound = myShop.GetShop(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    myShop.Name1 = txtName1.Text;
                    myShop.Name2 = txtName2.Text;
                    myShop.Address = txtAddress.Text;
                    myShop.Manager = txtManager.Text;
                    myShop.Tel = txtTel.Text;
                    myShop.Remark = txtRemark.Text;

                    myShop.CSal_Acc = "";
                    myShop.CrSal_Acc = "";
                    myShop.CPur_Acc = "";
                    myShop.CrPur_Acc = "";
                    myShop.RCSal_Acc = "";
                    myShop.RCRSal_Acc = "";
                    myShop.RCPur_Acc = "";
                    myShop.RCRPur_Acc = "";
                    myShop.Cash_Acc = "";
                    myShop.Service_Acc = "";
                    myShop.PDisc_Acc = "";
                    myShop.SDisc_Acc = "";

                    if (myShop.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        LoadShopData();
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = GetLocalResourceObject("SuccessAdd").ToString(); // "لقد تم حفظ البيانات بنجاح";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("ErrorAdd").ToString();  // "لقد حدث خطأ اثناء حفظ البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
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

        protected void grdCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdCodes.PageIndex = e.NewPageIndex;
                LoadShopData();
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
                if (txtNumber.Text != "")
                {
                    Shop myShop = new Shop();
                    myShop.FType = 1;
                    myShop.Bran = short.Parse(txtNumber.Text);
                    myShop.Number = short.Parse(txtNumber.Text);
                    if (myShop.GetShop(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        txtName1.Text = myShop.Name1;
                        txtName2.Text = myShop.Name2;
                        txtManager.Text = myShop.Manager;
                        txtAddress.Text = myShop.Address;
                        txtTel.Text = myShop.Tel;
                        EditMode();
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("BranchNotFound").ToString();   // "رقم الفرع غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = GetLocalResourceObject("SelectBranch2").ToString();  // "يجب إدخال رقم الفرع";
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

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    Shop myShop = new Shop();
                    myShop.FType = 1;
                    myShop.Bran = short.Parse(txtNumber.Text);
                    myShop.Number = short.Parse(txtNumber.Text);
                    if (myShop.GetShop(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        myShop.Name1 = txtName1.Text;
                        myShop.Name2 = txtName2.Text;
                        myShop.Address = txtAddress.Text;
                        myShop.Manager = txtManager.Text;
                        myShop.Tel = txtTel.Text;
                        myShop.Remark = txtRemark.Text;

                        myShop.CSal_Acc = "";
                        myShop.CrSal_Acc = "";
                        myShop.CPur_Acc = "";
                        myShop.CrPur_Acc = "";
                        myShop.RCSal_Acc = "";
                        myShop.RCRSal_Acc = "";
                        myShop.RCPur_Acc = "";
                        myShop.RCRPur_Acc = "";
                        myShop.Cash_Acc = "";
                        myShop.Service_Acc = "";
                        myShop.PDisc_Acc = "";
                        myShop.SDisc_Acc = "";

                        if (myShop.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LoadShopData();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = GetLocalResourceObject("SuccessAdd").ToString(); // "لقد تم حفظ البيانات بنجاح";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("ErrorAdd").ToString(); // "لقد حدث خطأ اثناء حفظ البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("ErrorAdd").ToString(); // "لقد حدث خطأ اثناء حفظ البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
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
                if (txtNumber.Text != "")
                {
                    Shop myShop = new Shop();
                    myShop.FType = 1;
                    myShop.Bran = short.Parse(txtNumber.Text);
                    myShop.Number = short.Parse(txtNumber.Text);
                    if (myShop.GetShop(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        // Pending Work Check for Transaction....

                        if (myShop.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.Description = GetLocalResourceObject("BranchDelete").ToString() + " " + myShop.Name1;
                            UserTran.FormName = GetLocalResourceObject("Title").ToString(); // "الفروع";
                            UserTran.FormAction = GetLocalResourceObject("Delete").ToString(); // "الغاء";
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                            LoadShopData();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = GetLocalResourceObject("SuccessDelete").ToString();  // "لقم تم الغاء بيانات الفرع بنجاح";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("BranchNotFound").ToString(); // "الفرع غير معرف من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = GetLocalResourceObject("SelectBranch2").ToString();  // "يجب إدخال رقم الفرع";
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
                if (ConfigurationManager.AppSettings["ExitOnError"].ToString() == "1")
                {
                    Session.Add("Error", ex);
                    Response.Redirect("GeneralServerError.aspx", false);
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
}