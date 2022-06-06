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
    public partial class WebClients : System.Web.UI.Page
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
        public List<CustDetails> VouData
        {
            get
            {
                if (ViewState["VouData"] == null)
                {
                    ViewState["VouData"] = new List<CustDetails>();
                }
                return (List<CustDetails>)ViewState["VouData"];
            }
            set
            {
                ViewState["VouData"] = value;
            }
        }

        public void EditMode()
        {
            txtCode.ReadOnly = true;
            txtCode.BackColor = System.Drawing.Color.LightGray;

            BtnEdit.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass152;
            BtnNew.Visible = false;
            BtnDelete.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass153;
        }

        public void NewMode()
        {
            txtCode.ReadOnly = false;
            txtCode.BackColor = System.Drawing.Color.White;

            BtnEdit.Visible = false;
            BtnNew.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass151;
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
                    this.Page.Header.Title = "بيانات العملاء";

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


                    BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass151;
                    BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass152;
                    BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass153;
                    BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass154;
                    BtnFind.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass154;

                    Acc myacc = new Acc();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastACC" + Session["CNN2"].ToString()] == null) Cache.Insert("LastACC" + Session["CNN2"].ToString(), myacc.GetLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlAccount.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                               where itm.FCode.StartsWith("120301")
                                               orderby itm.Name1
                                               select itm).ToList();
                    ddlAccount.DataTextField = "Name1";
                    ddlAccount.DataValueField = "Code";
                    ddlAccount.DataBind();
                    ddlAccount.Items.Insert(0, new ListItem("--- أختار حساب العميل ---", "-1", true));

                    LoadDriversData();
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
                    Response.Redirect("GeneralServerError.aspx",false);
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }


        protected void LoadDriversData()
        {
            try
            {
                Clients myacc = new Clients();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                grdCodes.DataSource = myacc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                grdCodes.DataBind();
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
            try
            {
                string Code = grdCodes.DataKeys[e.NewSelectedIndex]["Code"].ToString();
                txtCode.Text = Code;
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

        protected void grdCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdCodes.PageIndex = e.NewPageIndex;
                LoadDriversData();
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
                txtCode.Text = "";
                txtName1.Text = "";
                txtName2.Text = "";
                txtAddress.Text = "";
                txtIqamaDate.Text = "";
                txtIqamaFrom.Text = "";
                txtIqamaNo.Text = "";
                txtMobileNo.Text = "";
                rdoIDType.SelectedIndex = 0;
                txtEmail.Text = "";
                txtJob1.Text = "";
                txtJob2.Text = "";
                txtJob2.Text = "";
                txtManage1.Text = "";
                txtManage2.Text = "";
                txtManage3.Text = "";
                txtMobileNo1.Text = "";
                txtMobileNo2.Text = "";
                txtMobileNo3.Text = "";
                txtOfficeNo.Text = "";
                txtPostal.Text = "";
                txtEmail1.Text = "";
                txtEmail2.Text = "";
                txtEmail3.Text = "";
                txtAddr1.Text = "";
                txtAddr2.Text = "";
                txtAddr3.Text = "";
                txtAddr4.Text = "";
                txtAddr5.Text = "";
                txtAddr6.Text = "";
                txtAddr7.Text = "";
                txtAddr8.Text = "";
                rdoPayment.SelectedIndex = 0;
                rdoPayment_SelectedIndexChanged(sender, e);
                ddlAccount.SelectedIndex = 0;
               
                Clients myacc = new Clients();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                string s = myacc.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (s != null)
                {
                    txtCode.Text = moh.MakeMask((Int32.Parse(s) + 1).ToString(), 5);
                }
                else
                {
                    txtCode.Text = "00001";
                }

                VouData.Clear();
                LoadCodesData();
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
                    txtCode.Text = moh.MakeMask(txtCode.Text, 5);
                    Clients myacc = new Clients();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.Code = txtCode.Text;
                    myacc = myacc.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc == null)
                    {
                        myacc = new Clients();
                        myacc.Branch = short.Parse(Session["Branch"].ToString());
                        myacc.Code = txtCode.Text;
                        myacc.Name1 = txtName1.Text;
                        myacc.Name2 = txtName2.Text;
                        myacc.MobileNo = txtMobileNo.Text;
                        myacc.Address = txtAddress.Text;
                        myacc.IdDate = txtIqamaDate.Text;
                        myacc.IdNo = txtIqamaNo.Text;
                        myacc.IdFrom = txtIqamaFrom.Text;
                        myacc.IdType = short.Parse(rdoIDType.SelectedValue);
                        myacc.Email = txtEmail.Text;
                        myacc.Job1 = txtJob1.Text;
                        myacc.Manage1 = txtManage1.Text;
                        myacc.MobileNo1 = txtMobileNo1.Text;
                        myacc.Job2 = txtJob2.Text;
                        myacc.Manage2 = txtManage2.Text;
                        myacc.MobileNo2 = txtMobileNo2.Text;
                        myacc.Job3 = txtJob3.Text;
                        myacc.Manage3 = txtManage3.Text;
                        myacc.MobileNo3 = txtMobileNo3.Text;
                        myacc.OfficeNo = txtOfficeNo.Text;
                        myacc.Postal = txtPostal.Text;
                        myacc.Email1 = txtEmail1.Text;
                        myacc.Email2 = txtEmail2.Text;
                        myacc.Email3 = txtEmail3.Text;
                        myacc.Payment = short.Parse(rdoPayment.SelectedValue);
                        myacc.Account = ddlAccount.SelectedValue;
                        myacc.Addr1 = txtAddr1.Text;
                        myacc.Addr2 = txtAddr2.Text;
                        myacc.Addr3 = txtAddr3.Text;
                        myacc.Addr4 = txtAddr4.Text;
                        myacc.Addr5 = txtAddr5.Text;
                        myacc.Addr6 = txtAddr6.Text;
                        myacc.Addr7 = txtAddr7.Text;
                        myacc.Addr8 = txtAddr8.Text;
                        if (myacc.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            foreach (CustDetails cd in VouData)
                            {
                                cd.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }
                            LoadDriversData();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم حفظ البيانات بنجاح";
                            BtnClear_Click(sender, null);
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
                        LblCodesResult.Text = "رقم العميل مكرر";
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

        protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtCode.Text != "")
                {
                    txtCode.Text = moh.MakeMask(txtCode.Text, 5);
                    Clients myacc = new Clients();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.Code = txtCode.Text;
                    myacc = myacc.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc != null)
                    {
                        EditMode();
                        txtName1.Text = myacc.Name1;
                        txtName2.Text = myacc.Name2;
                        txtMobileNo.Text = myacc.MobileNo;
                        txtAddress.Text = myacc.Address;
                        txtIqamaDate.Text = myacc.IdDate;
                        txtIqamaNo.Text = myacc.IdNo;
                        txtIqamaFrom.Text = myacc.IdFrom;
                        rdoIDType.SelectedValue = myacc.IdType.ToString();
                        txtEmail.Text = myacc.Email;
                        txtJob1.Text = myacc.Job1;
                        txtManage1.Text = myacc.Manage1;
                        txtMobileNo1.Text = myacc.MobileNo1;
                        txtJob2.Text = myacc.Job2;
                        txtManage2.Text = myacc.Manage2;
                        txtMobileNo2.Text = myacc.MobileNo2;
                        txtJob3.Text = myacc.Job3;
                        txtManage3.Text = myacc.Manage3;
                        txtMobileNo3.Text = myacc.MobileNo3;
                        txtOfficeNo.Text = myacc.OfficeNo;
                        txtPostal.Text = myacc.Postal;
                        txtEmail1.Text = myacc.Email1;
                        txtEmail2.Text = myacc.Email2;
                        txtEmail3.Text = myacc.Email3;
                        rdoPayment.SelectedValue = myacc.Payment.ToString();
                        rdoPayment_SelectedIndexChanged(sender, e);
                        ddlAccount.SelectedValue = myacc.Account;
                        txtAddr1.Text = myacc.Addr1;
                        txtAddr2.Text = myacc.Addr2;
                        txtAddr3.Text = myacc.Addr3;
                        txtAddr4.Text = myacc.Addr4;
                        txtAddr5.Text = myacc.Addr5;
                        txtAddr6.Text = myacc.Addr6;
                        txtAddr7.Text = myacc.Addr7;
                        txtAddr8.Text = myacc.Addr8;

                        CustDetails myCust = new CustDetails();
                        myCust.Branch = short.Parse(Session["Branch"].ToString());
                        myCust.Code = txtCode.Text;
                        VouData = myCust.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        LoadCodesData();
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم العميل غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم العميل";
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

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    txtCode.Text = moh.MakeMask(txtCode.Text, 5);
                    Clients myacc = new Clients();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.Code = txtCode.Text;
                    myacc = myacc.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc != null)
                    {
                        myacc.Name1 = txtName1.Text;
                        myacc.Name2 = txtName2.Text;
                        myacc.MobileNo = txtMobileNo.Text;
                        myacc.Address = txtAddress.Text;
                        myacc.IdDate = txtIqamaDate.Text;
                        myacc.IdNo = txtIqamaNo.Text;
                        myacc.IdFrom = txtIqamaFrom.Text;
                        myacc.IdType = short.Parse(rdoIDType.SelectedValue);
                        myacc.Email = txtEmail.Text;
                        myacc.Job1 = txtJob1.Text;
                        myacc.Manage1 = txtManage1.Text;
                        myacc.MobileNo1 = txtMobileNo1.Text;
                        myacc.Job2 = txtJob2.Text;
                        myacc.Manage2 = txtManage2.Text;
                        myacc.MobileNo2 = txtMobileNo2.Text;
                        myacc.Job3 = txtJob3.Text;
                        myacc.Manage3 = txtManage3.Text;
                        myacc.MobileNo3 = txtMobileNo3.Text;
                        myacc.OfficeNo = txtOfficeNo.Text;
                        myacc.Postal = txtPostal.Text;
                        myacc.Email1 = txtEmail1.Text;
                        myacc.Email2 = txtEmail2.Text;
                        myacc.Email3 = txtEmail3.Text;
                        myacc.Payment = short.Parse(rdoPayment.SelectedValue);
                        myacc.Account = ddlAccount.SelectedValue;
                        myacc.Addr1 = txtAddr1.Text;
                        myacc.Addr2 = txtAddr2.Text;
                        myacc.Addr3 = txtAddr3.Text;
                        myacc.Addr4 = txtAddr4.Text;
                        myacc.Addr5 = txtAddr5.Text;
                        myacc.Addr6 = txtAddr6.Text;
                        myacc.Addr7 = txtAddr7.Text;
                        myacc.Addr8 = txtAddr8.Text;
                        if (myacc.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            CustDetails myCust = new CustDetails();
                            myCust.Branch = short.Parse(Session["Branch"].ToString());
                            myCust.Code = txtCode.Text;
                            myCust.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            foreach (CustDetails cd in VouData)
                            {
                                cd.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }
                            LoadDriversData();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم حفظ البيانات بنجاح";
                            BtnClear_Click(sender, null);
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
                        LblCodesResult.Text = "رقم العميل غير معرف من قبل";
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

        protected void BtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtCode.Text != "")
                {
                    txtCode.Text = moh.MakeMask(txtCode.Text, 5);
                    Clients myacc = new Clients();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.Code = txtCode.Text;
                    myacc = myacc.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc != null)
                    {
                        // Check for Delete Clients
                        if (myacc.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            CustDetails myCust = new CustDetails();
                            myCust.Branch = short.Parse(Session["Branch"].ToString());
                            myCust.Code = txtCode.Text;
                            myCust.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.Description = "الغاء بيانات العميل " + myacc.Name1;
                            UserTran.FormAction = "الغاء";
                            UserTran.FormName = "العملاء";
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                            LoadDriversData();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقم تم الغاء بيانات العميل بنجاح";
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
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم العميل";
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

        protected void grdDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Insert"))
                {
                    ImageButton btnInsert = e.CommandSource as ImageButton;
                    if (btnInsert == null)
                    {
                        if (VouData.Count() < 1) grdDetails_RowCancelingEdit(sender, null);
                        return;
                    }

                    GridViewRow gvr = btnInsert.NamingContainer as GridViewRow;
                    if (gvr == null)
                    {
                        if (VouData.Count() < 1) grdDetails_RowCancelingEdit(sender, null);
                        return;
                    }

                    DropDownList ddlCity = gvr.FindControl("ddlCity") as DropDownList;
                    TextBox txtName = gvr.FindControl("txtName") as TextBox;
                    TextBox txtMobileNo = gvr.FindControl("txtMobileNo") as TextBox;
                    TextBox txtRecName = gvr.FindControl("txtRecName") as TextBox;
                    TextBox txtRecMobileNo = gvr.FindControl("txtRecMobileNo") as TextBox;

                    if (ddlCity == null || txtName == null || txtMobileNo == null || txtRecName == null || txtRecMobileNo == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        if (VouData.Count() < 1) grdDetails_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    CustDetails myCust = new CustDetails();
                    myCust.Branch = short.Parse(Session["Branch"].ToString());
                    myCust.Code = txtCode.Text;
                    myCust.City = ddlCity.SelectedValue;
                    myCust = myCust.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myCust != null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "المدينة معرفة من قبل لنفس العميل";
                        if (VouData.Count() < 1) grdDetails_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    foreach (CustDetails cd in VouData)
                    {
                        if (cd.Code == txtCode.Text && cd.City == ddlCity.SelectedValue)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "المدينة معرفة من قبل لنفس العميل";
                            if (VouData.Count() < 1) grdDetails_RowCancelingEdit(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }
                    }

                    CustDetails myAccess = new CustDetails();
                    myAccess.FNo = (short)(VouData.Count + 1);
                    myAccess.Branch = short.Parse(Session["Branch"].ToString());
                    myAccess.Code = txtCode.Text;
                    myAccess.City = ddlCity.SelectedValue;
                    myAccess.City2 = ddlCity.SelectedItem.Text;
                    myAccess.Name = txtName.Text;
                    myAccess.MobileNo = txtMobileNo.Text;
                    myAccess.RecName = txtRecName.Text;
                    myAccess.RecMobileNo = txtRecMobileNo.Text;
                    VouData.Add(myAccess);
                    LoadCodesData();

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
                    Response.Redirect("GeneralServerError.aspx", false);
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }

        protected void grdDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string FNo = grdDetails.DataKeys[e.RowIndex]["FNo"].ToString();
                VouData.RemoveAt((int)moh.StrToDouble(FNo) - 1);
                for (int i = 0; i < VouData.Count; i++)
                {
                    VouData[i].FNo = (short)(i + 1);
                }
                e.Cancel = false;
                LoadCodesData();
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

        protected void grdDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdDetails.EditIndex = -1;
                LoadCodesData();
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


        protected void LoadCodesData()
        {
            try
            {
                grdDetails.DataSource = VouData;
                grdDetails.DataBind();

                if (grdDetails.Rows.Count < 1)
                {
                    CustDetails cs = new CustDetails();
                    List<CustDetails> Listax = new List<CustDetails>();
                    Listax.Add(cs);
                    grdDetails.DataSource = Listax;
                    grdDetails.DataBind();
                    grdDetails.Rows[0].Cells.Clear();
                }

                DropDownList ddlCity = grdDetails.FooterRow.FindControl("ddlCity") as DropDownList;
                if (ddlCity != null)
                {
                    Cities myCity = new Cities();
                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlCity.DataTextField = "Name1";
                    ddlCity.DataValueField = "Code";
                    ddlCity.DataSource = (from itm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                          orderby itm.Name1
                                          select itm).ToList();
                    ddlCity.DataBind();
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

        protected void rdoPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCust.Visible = (rdoPayment.SelectedIndex == 1);
            ddlAccount.Visible = (rdoPayment.SelectedIndex == 1);
            if (VouData.Count() < 1) grdDetails_RowCancelingEdit(sender, null);                
        }
    }
}