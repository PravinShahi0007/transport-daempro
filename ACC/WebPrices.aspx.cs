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
    public partial class WebPrices : System.Web.UI.Page
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
                    ViewState["StoreNo"] = "00001";
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
                    this.Page.Header.Title = "بيانات سياسات التسعير";
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

                    PLevel myPLevel = new PLevel();
                    myPLevel.Branch = short.Parse(Session["Branch"].ToString());
                    ddlLevel.DataTextField = "name1";
                    ddlLevel.DataValueField = "Code";
                    ddlLevel.DataSource = myPLevel.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlLevel.DataBind();

                    Cities myCity = new Cities();
                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlCity.DataTextField = "Name1";
                    ddlCity.DataValueField = "Code";
                    ddlCity.DataSource = (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()]);
                    ddlCity.DataBind();
                    ddlCity.Items.Insert(0, new ListItem("--- جميع المدن ---", "-1", true));

                    Acc myAcc = new Acc();
                    myAcc.Branch = short.Parse(Session["Branch"].ToString());
                    myAcc.FCode = "120301";
                    ddlCustomer.DataTextField = "Name1";
                    ddlCustomer.DataValueField = "Code";
                    ddlCustomer.DataSource = myAcc.GetAllAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlCustomer.DataBind();
                    ddlCustomer.Items.Insert(0, new ListItem("--- جميع الافراد ---", "-1", true));
                   
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
                NewVer.HRef = string.Format("WebPrices2.aspx?AreaNo={0}&StoreNo={1}&Customer={2}&Level={3}&City={4}", AreaNo, StoreNo, ddlCustomer.SelectedValue, ddlLevel.SelectedValue, ddlCity.SelectedValue);
                grdCodes.ShowFooter = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass121;
                CarPrices ax = new CarPrices();
                ax.Branch = short.Parse(Session["Branch"].ToString());
                //ax.MonthNo = 0;  // short.Parse(ddlMonth.SelectedValue);
                ax.MonthNo = 0;
                ax.AccountNo = ddlCustomer.SelectedValue;
                ax.PLevel = ddlLevel.SelectedValue;
                if (ddlCity.SelectedIndex == 0)
                {
                    grdCodes.DataSource = ax.GetMonth(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }
                else
                {
                    ax.FromCode = ddlCity.SelectedValue;
                    grdCodes.DataSource = ax.GetMonth2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }
                grdCodes.DataBind();

                if (grdCodes.Rows.Count < 1)
                {
                    List<CarPrices> Listax = new List<CarPrices>();
                    Listax.Add(ax);
                    grdCodes.DataSource = Listax;
                    grdCodes.DataBind();
                    grdCodes.Rows[0].Cells.Clear();
                }

                DropDownList ddlFromCode2 = grdCodes.FooterRow.FindControl("ddlFromCode2") as DropDownList;
                DropDownList ddlToCode2 = grdCodes.FooterRow.FindControl("ddlToCode2") as DropDownList;
                if (ddlFromCode2 != null)
                {
                    Cities myCity = new Cities();
                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlFromCode2.DataTextField = "Name1";
                    ddlFromCode2.DataValueField = "Code";
                    ddlFromCode2.DataSource= (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()]);
                    ddlFromCode2.DataBind();
                }
                if (ddlToCode2 != null)
                {
                    Cities myCity = new Cities();
                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlToCode2.DataTextField = "Name1";
                    ddlToCode2.DataValueField = "Code";
                    ddlToCode2.DataSource = (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()]);
                    ddlToCode2.DataBind();
                }

                foreach (GridViewRow itm in grdCodes.Rows)
                {
                    ImageButton BtnEdit = itm.FindControl("BtnEdit") as ImageButton;
                    ImageButton BtnDelete = itm.FindControl("BtnDelete") as ImageButton;
                    if (BtnEdit != null) BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass122;
                    if (BtnDelete != null) BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass123;
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
                string FromCode = grdCodes.DataKeys[e.RowIndex]["FromCode"].ToString();
                string ToCode = grdCodes.DataKeys[e.RowIndex]["ToCode"].ToString();
                
                GridViewRow gvr = grdCodes.Rows[e.RowIndex];
                TextBox txtKMeter = gvr.FindControl("txtKMeter") as TextBox;
                TextBox txtLOneWay = gvr.FindControl("txtLOneWay") as TextBox;
                TextBox txtHOneWay = gvr.FindControl("txtHOneWay") as TextBox;
                TextBox txtLTwoWay = gvr.FindControl("txtLTwoWay") as TextBox;
                TextBox txtHTwoWay = gvr.FindControl("txtHTwoWay") as TextBox;
                //TextBox txtCostAmount = gvr.FindControl("txtCostAmount") as TextBox;
                TextBox txtEPrice1 = gvr.FindControl("txtEPrice1") as TextBox;
                TextBox txtEPrice2 = gvr.FindControl("txtEPrice2") as TextBox;
                TextBox txtEPrice3 = gvr.FindControl("txtEPrice3") as TextBox;
                TextBox txtFTime = gvr.FindControl("txtFTime") as TextBox;

                if (txtKMeter == null || txtLOneWay == null || txtHOneWay == null || txtLTwoWay == null || txtHTwoWay == null || txtFTime == null || txtEPrice1 == null || txtEPrice2 == null || txtEPrice3 == null)
                {
                    e.Cancel = true;
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    return;
                }

                CarPrices myAccess = new CarPrices();
                myAccess.Branch = short.Parse(Session["Branch"].ToString());
                myAccess.MonthNo = 0;  // short.Parse(ddlMonth.SelectedValue);
                myAccess.AccountNo = ddlCustomer.SelectedValue;
                myAccess.PLevel = ddlLevel.SelectedValue;
                myAccess.FromCode = FromCode;
                myAccess.toCode = ToCode;
                myAccess.FTime = txtFTime.Text;

                if (txtKMeter.Text == "") txtKMeter.Text = "0";
                if (txtLOneWay.Text == "") txtLOneWay.Text = "0";
                if (txtLTwoWay.Text == "") txtLTwoWay.Text = "0";
                if (txtHOneWay.Text == "") txtHOneWay.Text = "0";
                if (txtHTwoWay.Text == "") txtHTwoWay.Text = "0";
                //if (txtCostAmount.Text == "") txtCostAmount.Text = "0";
                if (txtEPrice1.Text == "") txtEPrice1.Text = "0";
                if (txtEPrice2.Text == "") txtEPrice2.Text = "0";
                if (txtEPrice3.Text == "") txtEPrice3.Text = "0";

                myAccess.LTwoWay = moh.StrToDouble(txtLTwoWay.Text);
                myAccess.LOneWay = moh.StrToDouble(txtLOneWay.Text);
                myAccess.HTwoWay = moh.StrToDouble(txtHTwoWay.Text);
                myAccess.HOneWay = moh.StrToDouble(txtHOneWay.Text);
                myAccess.KMeter = moh.StrToDouble(txtKMeter.Text);
                //myAccess.CostAmount = moh.StrToDouble(txtCostAmount.Text);
                myAccess.UserName = Session["CurrentUser"].ToString();
                myAccess.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                myAccess.ExPrice1 = moh.StrToDouble(txtEPrice1.Text);
                myAccess.ExPrice2 = moh.StrToDouble(txtEPrice2.Text);
                myAccess.ExPrice3 = moh.StrToDouble(txtEPrice3.Text);
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

                    TextBox txtKMeter = gvr.FindControl("txtKMeter2") as TextBox;
                    TextBox txtLOneWay = gvr.FindControl("txtLOneWay2") as TextBox;
                    TextBox txtHOneWay = gvr.FindControl("txtHOneWay2") as TextBox;
                    TextBox txtLTwoWay = gvr.FindControl("txtLTwoWay2") as TextBox;
                    TextBox txtHTwoWay = gvr.FindControl("txtHTwoWay2") as TextBox;
                    //TextBox txtCostAmount = gvr.FindControl("txtCostAmount2") as TextBox;
                    TextBox txtFTime = gvr.FindControl("txtFTime2") as TextBox;
                    DropDownList ddlFromCode2 = grdCodes.FooterRow.FindControl("ddlFromCode2") as DropDownList;
                    DropDownList ddlToCode2 = grdCodes.FooterRow.FindControl("ddlToCode2") as DropDownList;
                    TextBox txtE21Price = gvr.FindControl("txtE21Price") as TextBox;
                    TextBox txtE22Price = gvr.FindControl("txtE22Price") as TextBox;
                    TextBox txtE23Price = gvr.FindControl("txtE23Price") as TextBox;
                    if (txtKMeter == null || txtLOneWay == null || txtHOneWay == null || txtLTwoWay == null || txtHTwoWay == null || ddlFromCode2 == null || ddlToCode2 == null || txtFTime == null || txtE21Price == null || txtE22Price == null || txtE23Price == null)
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    CarPrices myAccess = new CarPrices();
                    myAccess.Branch = short.Parse(Session["Branch"].ToString());
                    myAccess.MonthNo = 0;  // short.Parse(ddlMonth.SelectedValue);
                    myAccess.PLevel = ddlLevel.SelectedValue;
                    myAccess.FromCode = ddlFromCode2.SelectedValue;
                    myAccess.toCode = ddlToCode2.SelectedValue;
                    myAccess.AccountNo = ddlCustomer.SelectedValue;
                    myAccess = myAccess.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myAccess != null)
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "المسار مدخل من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    if (txtKMeter.Text == "") txtKMeter.Text = "0";
                    if (txtLOneWay.Text == "") txtLOneWay.Text = "0";
                    if (txtLTwoWay.Text == "") txtLTwoWay.Text = "0";
                    if (txtHOneWay.Text == "") txtHOneWay.Text = "0";
                    if (txtHTwoWay.Text == "") txtHTwoWay.Text = "0";
                    if (txtE21Price.Text == "") txtE21Price.Text = "0";
                    if (txtE22Price.Text == "") txtE22Price.Text = "0";
                    if (txtE23Price.Text == "") txtE23Price.Text = "0";

                    myAccess = new CarPrices();
                    myAccess.Branch = short.Parse(Session["Branch"].ToString());
                    myAccess.MonthNo = 0; // short.Parse(ddlMonth.SelectedValue);
                    myAccess.AccountNo = ddlCustomer.SelectedValue;
                    myAccess.PLevel = ddlLevel.SelectedValue;
                    myAccess.FromCode = ddlFromCode2.SelectedValue;
                    myAccess.toCode = ddlToCode2.SelectedValue;
                    myAccess.KMeter = moh.StrToDouble(txtKMeter.Text);
                    myAccess.LTwoWay = moh.StrToDouble(txtLTwoWay.Text);
                    myAccess.LOneWay = moh.StrToDouble(txtLOneWay.Text);
                    myAccess.HTwoWay = moh.StrToDouble(txtHTwoWay.Text);
                    myAccess.HOneWay = moh.StrToDouble(txtHOneWay.Text);
                    myAccess.FTime = txtFTime.Text;
                    myAccess.UserName = Session["CurrentUser"].ToString();
                    myAccess.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    myAccess.ExPrice1 = moh.StrToDouble(txtE21Price.Text);
                    myAccess.ExPrice2 = moh.StrToDouble(txtE22Price.Text);
                    myAccess.ExPrice3 = moh.StrToDouble(txtE23Price.Text);
                    if (myAccess.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        //if (myAccess.MonthNo == 0)
                        //{
                        //    for (int i = 1; i < 13; i++)
                        //    {
                        //        myAccess.MonthNo = (short)i;
                        //        myAccess.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        //    }
                        //}
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
                string FromCode = grdCodes.DataKeys[e.RowIndex]["FromCode"].ToString();
                string ToCode = grdCodes.DataKeys[e.RowIndex]["ToCode"].ToString();

                CarPrices myAccess = new CarPrices();
                myAccess.Branch = short.Parse(Session["Branch"].ToString());
                myAccess.MonthNo = 0;  // short.Parse(ddlMonth.SelectedValue);
                myAccess.PLevel = ddlLevel.SelectedValue;
                myAccess.AccountNo = ddlCustomer.SelectedValue;
                myAccess.FromCode = FromCode;
                myAccess.toCode = ToCode;

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
                    //Transactions UserTran = new Transactions();
                    //UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    //UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                    //UserTran.UserName = Session["CurrentUser"].ToString();
                    //UserTran.Description = "الغاء بيانات المسار " + myAccess.Name1;
                    //UserTran.FormAction = "الغاء";
                    //UserTran.FormName = "اتفاقية الشحن";
                    //UserTran.IP = IPNetworking.GetIP4Address();
                    //UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

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

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
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

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    CarPrices ax = new CarPrices();
        //    List<CarPrices> lax = new List<CarPrices>();
        //    ax.Branch = 1;
        //    ax.MonthNo = 0;
        //    ax.PLevel = "00001";
        //    lax = ax.GetMonth(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
        //    foreach (CarPrices itm in lax)
        //    {
        //        itm.PLevel = "00005";
        //        itm.HOneWay = itm.HOneWay * 4;
        //        itm.LOneWay = itm.LOneWay * 4;
        //        itm.HTwoWay = itm.HTwoWay * 4;
        //        itm.LTwoWay = itm.LTwoWay * 4;
        //        itm.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
        //    }
        //    LblCodesResult.ForeColor = System.Drawing.Color.Green;
        //    LblCodesResult.Text = "تم تحديث البيانات بنجاح";
        //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
        //}

    }
}