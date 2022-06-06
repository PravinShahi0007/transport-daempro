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
    public partial class WebCity : System.Web.UI.Page
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
                    this.Page.Header.Title = "بيانات المدن";
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
                    LoadCodesData();
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

        protected void LoadCodesData()
        {
            try
            {
                Cities ax = new Cities();
                grdCodes.ShowFooter = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass101;
                ax.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                grdCodes.DataSource = (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()]);
                grdCodes.DataBind();

                if (grdCodes.Rows.Count < 1)
                {
                    List<Cities> Listax = new List<Cities>();
                    Listax.Add(ax);
                    grdCodes.DataSource = Listax;
                    grdCodes.DataBind();
                    grdCodes.Rows[0].Cells.Clear();
                }

                foreach (GridViewRow itm in grdCodes.Rows)
                {
                    ImageButton BtnEdit = itm.FindControl("BtnEdit") as ImageButton;
                    ImageButton BtnDelete = itm.FindControl("BtnDelete") as ImageButton;
                    if (BtnEdit != null) BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass102;
                    if (BtnDelete != null) BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass103;
                }

                if (grdCodes.FooterRow != null)
                {
                    DropDownList ddlFType = grdCodes.FooterRow.FindControl("ddlFType") as DropDownList;
                    if (ddlFType != null)
                    {
                        CostCenter myCostCenter = new CostCenter();
                        myCostCenter.Branch = 1;
                        if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        ddlFType.DataTextField = "name1";
                        ddlFType.DataValueField = "Code";
                        ddlFType.DataSource = (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()]);
                        ddlFType.DataBind();
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


        protected void grdCodes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string Code = grdCodes.DataKeys[e.RowIndex]["Code"].ToString();
                GridViewRow gvr = grdCodes.Rows[e.RowIndex];
                TextBox txtName1 = gvr.FindControl("txtName1") as TextBox;
                TextBox txtName2 = gvr.FindControl("txtName2") as TextBox;
                DropDownList dllFType2 = gvr.FindControl("dllFType2") as DropDownList;

                if (txtName2 == null || txtName1 == null || dllFType2 == null)
                {
                    e.Cancel = true;
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    return;
                }

                Cities myAccess = new Cities();
                myAccess.Branch = short.Parse(Session["Branch"].ToString());
                myAccess.Code = Code;
                myAccess.Name1 = txtName1.Text;
                myAccess.Name2 = txtName2.Text;
                myAccess.Site = dllFType2.SelectedValue;

                if (!myAccess.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    e.Cancel = true;
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    return;
                }

                grdCodes.EditIndex = -1;
                LoadCodesData();

                if (Cache["Cities" + Session["CNN2"].ToString()] != null) Cache.Remove("Cities" + Session["CNN2"].ToString());
                Cities myCity = new Cities();
                myCity.Branch = 1;
                Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
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

        protected void grdCodes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdCodes.EditIndex = -1;
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

                    TextBox txtName1 = gvr.FindControl("txtName1") as TextBox;
                    TextBox txtName2 = gvr.FindControl("txtName2") as TextBox;
                    DropDownList dllFType = gvr.FindControl("ddlFType") as DropDownList;

                    if (txtName1 == null || txtName2 == null || dllFType == null)
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                    if (txtName1.Text == "")
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "تاكد من أدخال البيانات المطلوبة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }


                    Cities myAccess = new Cities();
                    myAccess.Branch = short.Parse(Session["Branch"].ToString());
                    string s = myAccess.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (s == "0" || s == null)
                    {
                        s = "00001";
                    }
                    else
                    {
                        s = (Int32.Parse(s) + 1).ToString();
                    }
                    s = moh.MakeMask(s, 5);

                    myAccess.Branch = short.Parse(Session["Branch"].ToString());
                    myAccess.Code = s;
                    myAccess.Name1 = txtName1.Text;
                    myAccess.Name2 = txtName2.Text;
                    myAccess.Site = dllFType.SelectedValue;

                    if (myAccess.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        if (Cache["Cities" + Session["CNN2"].ToString()] != null) Cache.Remove("Cities" + Session["CNN2"].ToString());
                        Cities myCity = new Cities();
                        myCity.Branch = 1;
                        Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تم اضافة البيانات بنجاح";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        LoadCodesData();
                    }
                    else
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
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
                string Code = grdCodes.DataKeys[e.RowIndex]["Code"].ToString();

                Cities myAccess = new Cities();
                myAccess.Branch = short.Parse(Session["Branch"].ToString());
                myAccess.Code = Code;

                // Pending work Check if Coin Releate to any Account 

                if (!myAccess.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    e.Cancel = true;
                }
                else
                {
                    Transactions UserTran = new Transactions();
                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                    UserTran.UserName = Session["CurrentUser"].ToString();
                    UserTran.Description = "الغاء بيانات مدينه " + myAccess.Name1;
                    UserTran.FormAction = "الغاء";
                    UserTran.FormName = "المدن";
                    UserTran.IP = IPNetworking.GetIP4Address();
                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                    if (Cache["Cities" + Session["CNN2"].ToString()] != null) Cache.Remove("Cities" + Session["CNN2"].ToString());
                    Cities myCity = new Cities();
                    myCity.Branch = 1;
                    Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult.Text = "لقد تم حذف السجل بنجاح";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                    LoadCodesData();
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

        protected void grdCodes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
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

        protected void btnUpdate_Load(object sender, EventArgs e)
        {
            ((ImageButton)sender).Visible = true;
        }

        protected void dllFType2_Init(object sender, EventArgs e)
        {
            DropDownList ddlFType = sender as DropDownList;
            GridViewRow gvr = ddlFType.NamingContainer as GridViewRow;
            string Code = grdCodes.DataKeys[gvr.RowIndex]["Code"].ToString();

            CostCenter myCostCenter = new CostCenter();
            myCostCenter.Branch = 1;
            if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            ddlFType.DataTextField = "name1";
            ddlFType.DataValueField = "Code";
            ddlFType.DataSource = (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()]);
            ddlFType.DataBind();

            if (Code != null)
            {
                Cities myCity = new Cities();
                myCity.cnn = WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString;
                myCity.Branch = short.Parse(Session["Branch"].ToString());
                myCity.Code = Code;
                if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                          where sitm.Code == myCity.Code
                          select sitm).FirstOrDefault();
                if (myCity != null)
                {
                    ddlFType.SelectedValue = myCity.Site;
                }
            }
        }


    }
}