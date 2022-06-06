using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Configuration;
using System.Web.Configuration;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class WebTSupport : System.Web.UI.Page
    {
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
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.QueryString["AreaNo"] != null) 
                this.Page.MasterPageFile = "~/MySite.master";
            else
                this.Page.MasterPageFile = "~/SupportSite.master";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "البيانات الأساسية";
                    TSupport myEmp = new TSupport();
                    ddlUser.DataSource = myEmp.GetAllUsers(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlUser.DataBind();
                    if (ddlUser.Items.FindByText(Session["CurrentUser"].ToString()) == null)
                        ddlUser.Items.Insert(0, new ListItem(Session["CurrentUser"].ToString(), Session["CurrentUser"].ToString(), true));
                    else ddlUser.SelectedValue = Session["CurrentUser"].ToString();
                    ddlUser.Enabled = ((((List<TblRoles>)(Session["Roll"]))[0].RoleName.ToLower().Contains("admin")));
                    BtnClear_Click(sender, null);
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
                    TSupport myEmp = new TSupport();
                    myEmp.FDate = txtFDate.Text;
                    myEmp.FTime = txtFTime.Text;
                    myEmp.UserName = Session["CurrentUser"].ToString();
                    if (myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) != null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "البيانات تم ادخالها من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>','');", true);
                    }
                    else
                    {
                        myEmp = new TSupport();
                        myEmp.FDate = txtFDate.Text;
                        myEmp.FTime = txtFTime.Text;
                        myEmp.UserName = Session["CurrentUser"].ToString();
                        myEmp.Customer = txtCustomer.Text;
                        myEmp.InvNo = txtInvNo.Text;
                        myEmp.MobileNo = txtMobileNo.Text;
                        myEmp.PlateNo = txtPlateNo.Text;
                        myEmp.Reply = txtReply.Text;
                        myEmp.Remark = txtRemark.Text;

                        string vstype = "";
                        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                        {
                            if (CheckBoxList1.Items[i].Selected) vstype = (vstype == "" ? "" : ";") + CheckBoxList1.Items[i].Value;
                        }                        
                        myEmp.SType = vstype;
                        if (myEmp.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.FormName = "خدمة العملاء";
                                UserTran.FormAction = "اضافة";
                                UserTran.Description = "اضافة بيانات طلب الخدمة " + txtFDate.Text + " " + txtFTime.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }

                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(1,'" + LblCodesResult.Text + "');", true);
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ اثناء أضافة البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>');", true);
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
            txtCustomer.Text = "";
            txtFDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());
            txtFTime.Text = String.Format("{0:HH:mm:ss}", moh.Nows());
            txtInvNo.Text = "";
            txtMobileNo.Text = "";
            txtPlateNo.Text = "";
            txtRemark.Text = "";
            txtRemark2.Text = "";
            txtReply.Text = "";
            txtCustomer.ReadOnly = false;
            txtFDate.ReadOnly = false;
            txtFTime.ReadOnly = false;
            txtInvNo.ReadOnly = false;
            txtMobileNo.ReadOnly = false;
            txtPlateNo.ReadOnly = false;
            txtRemark.ReadOnly = false;
            txtReply.ReadOnly = false;
            txtRemark2.Visible = false;
            BtnEdit.Visible = false;
            txtRemark2.Visible = false;
            CheckBoxList1.Enabled = true;
            BtnNew.Visible = true;
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                CheckBoxList1.Items[i].Selected = false;
            }
            LoadData();
        }

        protected void LoadData()
        {
            try
            {
                TSupport myEmp = new TSupport();
                myEmp.UserName = ddlUser.SelectedValue;
                grdCodes.DataSource = (from itm in myEmp.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                       where ChkPeriod.Checked || (txtMyFDate.Text != "" && txtMyEDate.Text != "" && DateTime.Parse(itm.FDate) >= DateTime.Parse(txtMyFDate.Text) && DateTime.Parse(itm.FDate) <= DateTime.Parse(txtMyEDate.Text))
                                       orderby DateTime.Parse(itm.FDate) descending
                                       select itm).ToList();
                lblCount.Text = ((List<TSupport>)(grdCodes.DataSource)).Count().ToString() + " سجل ";
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


        protected void grdCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdCodes.PageIndex = e.NewPageIndex;
                LoadData();
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
                string FDate = grdCodes.DataKeys[e.NewSelectedIndex]["FDate"].ToString();
                string FTime = grdCodes.DataKeys[e.NewSelectedIndex]["FTime"].ToString();
                if (FDate != null && FTime != null)
                {
                    TSupport myEmp = new TSupport();
                    myEmp.FDate = FDate;
                    myEmp.FTime = FTime;
                    myEmp.UserName = ddlUser.SelectedValue;
                    myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myEmp != null)
                    {
                        txtCustomer.Text = myEmp.Customer;
                        txtFDate.Text = myEmp.FDate;
                        txtFTime.Text = myEmp.FTime;
                        txtInvNo.Text = myEmp.InvNo;
                        txtMobileNo.Text = myEmp.MobileNo;
                        txtPlateNo.Text = myEmp.PlateNo;
                        txtRemark.Text = myEmp.Remark;
                        txtReply.Text = myEmp.Reply;
                        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                        {
                            CheckBoxList1.Items[i].Selected = false;
                        }
                        string[] items = myEmp.SType.Split(';');
                        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                        {
                            if (items.Contains(CheckBoxList1.Items[i].Value))
                            {
                                CheckBoxList1.Items[i].Selected = true;
                            }
                        }

                        CheckBoxList1.Enabled = false;
                        txtCustomer.ReadOnly = true;
                        txtFDate.ReadOnly = true;
                        txtFTime.ReadOnly = true;
                        txtInvNo.ReadOnly = true;
                        txtMobileNo.ReadOnly = true;
                        txtPlateNo.ReadOnly = true;
                        txtRemark.ReadOnly = true;
                        txtReply.ReadOnly = true;
                        txtRemark2.Visible = true;
                        BtnEdit.Visible = true;
                        BtnNew.Visible = false;
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
                    e.NewSelectedIndex = -1;
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }

        protected void ddlRecordsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlRecordsPerPage.SelectedValue == "-1")
                {
                    grdCodes.AllowPaging = false;
                }
                else
                {
                    grdCodes.AllowPaging = true;
                    grdCodes.PageSize = int.Parse(ddlRecordsPerPage.SelectedValue);
                }
                LoadData();
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

        protected void ChkPeriod_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtMyFDate.Visible = !ChkPeriod.Checked;
                txtMyEDate.Visible = !ChkPeriod.Checked;
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

        protected void BtnProcess_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                LoadData();
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
                    TSupport myEmp = new TSupport();
                    myEmp.FDate = txtFDate.Text;
                    myEmp.FTime = txtFTime.Text;
                    myEmp.UserName = Session["CurrentUser"].ToString();
                    myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if ( myEmp == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "البيانات لم يتم ادخالها من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>','');", true);
                    }
                    else
                    {
                        myEmp.Remark += (txtRemark.Text != "" ? "\n" : "") +txtRemark2.Text;
                        if (myEmp.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.FormName = "خدمة العملاء";
                                UserTran.FormAction = "تعديل";
                                UserTran.Description = "تعديل بيانات طلب الخدمة " + txtFDate.Text + " " + txtFTime.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }

                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(1,'" + LblCodesResult.Text + "');", true);
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ اثناء تعديل البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), @"DispMessage(0,'<p>" + LblCodesResult.Text + @"</p>');", true);
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

    }
}