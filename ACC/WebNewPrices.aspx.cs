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
    public partial class WebNewPrices : System.Web.UI.Page
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
                //NewVer.HRef = string.Format("WebPrices2.aspx?AreaNo={0}&StoreNo={1}&Customer={2}&Level={3}&City={4}", AreaNo, StoreNo, ddlCustomer.SelectedValue, ddlLevel.SelectedValue, ddlCity.SelectedValue);
                //grdCodes.ShowFooter = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass121;
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

                /*
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
                    ddlFromCode2.DataSource = (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()]);
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
                 */

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


        protected void grdCodes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string FromCode = grdCodes.DataKeys[e.RowIndex]["FromCode"].ToString();
                string ToCode = grdCodes.DataKeys[e.RowIndex]["ToCode"].ToString();

                GridViewRow gvr = grdCodes.Rows[e.RowIndex];
                TextBox txtKMeter = gvr.FindControl("txtKMeter") as TextBox;
                TextBox txtPrice = gvr.FindControl("txtPrice") as TextBox;
                TextBox txtPriceDiff = gvr.FindControl("txtPriceDiff") as TextBox;
                TextBox txtCollectPrice = gvr.FindControl("txtCollectPrice") as TextBox;
                TextBox txtCollectPrice2 = gvr.FindControl("txtCollectPrice2") as TextBox;
                TextBox txtDisPrice = gvr.FindControl("txtDisPrice") as TextBox;
                TextBox txtDisPrice2 = gvr.FindControl("txtDisPrice2") as TextBox;
                TextBox txtXPrice1 = gvr.FindControl("txtXPrice1") as TextBox;
                TextBox txtXPrice2 = gvr.FindControl("txtXPrice2") as TextBox;
                TextBox txtHTwoWay = gvr.FindControl("txtHTwoWay") as TextBox;
                TextBox txtLTwoWay = gvr.FindControl("txtLTwoWay") as TextBox;
                TextBox txtTruckPrice = gvr.FindControl("txtTruckPrice") as TextBox;
                TextBox txtTruckPrice2 = gvr.FindControl("txtTruckPrice2") as TextBox;
                TextBox txtTruck2Price = gvr.FindControl("txtTruck2Price") as TextBox;
                TextBox txtTruck2Price2 = gvr.FindControl("txtTruck2Price2") as TextBox;
                TextBox txtFTime = gvr.FindControl("txtFTime") as TextBox;
                TextBox txtCostAmount = gvr.FindControl("txtCostAmount") as TextBox;
                TextBox txtHOneWay = gvr.FindControl("HOneWay") as TextBox;
                TextBox txtLOneWay = gvr.FindControl("LOneWay") as TextBox;
                TextBox txtExPrice1 = gvr.FindControl("txtExPrice1") as TextBox;
                TextBox txtExPrice01 = gvr.FindControl("txtExPrice01") as TextBox;
                TextBox txtExPrice12 = gvr.FindControl("txtExPrice12") as TextBox;
                TextBox txtExPrice012 = gvr.FindControl("txtExPrice012") as TextBox;
                TextBox txtExPrice4 = gvr.FindControl("txtExPrice4") as TextBox;
                TextBox txtExPrice04 = gvr.FindControl("txtExPrice04") as TextBox;
                TextBox txtExPrice42 = gvr.FindControl("txtExPrice42") as TextBox;
                TextBox txtExPrice042 = gvr.FindControl("txtExPrice042") as TextBox;
                TextBox txtExPrice2 = gvr.FindControl("txtExPrice2") as TextBox;
                TextBox txtExPrice02 = gvr.FindControl("txtExPrice02") as TextBox;
                TextBox txtExPrice22 = gvr.FindControl("txtExPrice22") as TextBox;
                TextBox txtExPrice022 = gvr.FindControl("txtExPrice022") as TextBox;
                TextBox txtExPrice3 = gvr.FindControl("txtExPrice3") as TextBox;
                TextBox txtExPrice03 = gvr.FindControl("txtExPrice03") as TextBox;
                TextBox txtExPrice32 = gvr.FindControl("txtExPrice32") as TextBox;
                TextBox txtExPrice032 = gvr.FindControl("txtExPrice032") as TextBox;
                TextBox txtFTime2 = gvr.FindControl("txtFTime2") as TextBox;
                TextBox txtXPrice3 = gvr.FindControl("txtXPrice3") as TextBox;
                TextBox txtXPrice4 = gvr.FindControl("txtXPrice4") as TextBox;
                TextBox txtXPrice5 = gvr.FindControl("txtXPrice5") as TextBox;

                if (txtKMeter == null || txtPrice == null || txtPriceDiff == null || txtCollectPrice == null || txtCollectPrice2 == null || txtDisPrice == null || txtDisPrice2 == null || txtXPrice1 == null || txtXPrice2 == null || txtHTwoWay == null || txtLTwoWay == null || txtTruckPrice == null || 
                    txtTruckPrice2 == null || txtTruck2Price == null || txtTruck2Price2 == null || txtFTime == null || txtCostAmount == null || txtLOneWay == null || txtHOneWay == null || txtExPrice1 == null || txtExPrice01 == null || txtExPrice12 == null || txtExPrice012 == null || txtExPrice4 == null || 
                    txtExPrice04 == null || txtExPrice42 == null || txtExPrice042 == null || txtExPrice2 == null || txtExPrice02 == null || txtExPrice22 == null || txtExPrice022 == null || txtExPrice3 == null || txtExPrice03 == null || txtExPrice32 == null || txtExPrice032 == null || txtFTime2 == null || txtXPrice3 == null || txtXPrice4 == null || txtXPrice5 == null)
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
                myAccess = myAccess.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if(myAccess != null)
                {
                    myAccess.FTime = txtFTime.Text;
                    myAccess.KMeter = moh.StrToDouble(txtKMeter.Text);
                    myAccess.Price = moh.StrToDouble(txtPrice.Text);
                    myAccess.PriceDiff = moh.StrToDouble(txtPriceDiff.Text);
                    myAccess.CollectPrice = moh.StrToDouble(txtCollectPrice.Text);
                    myAccess.CollectPrice2 = moh.StrToDouble(txtCollectPrice2.Text);
                    myAccess.DisPrice = moh.StrToDouble(txtDisPrice.Text);
                    myAccess.DisPrice2 = moh.StrToDouble(txtDisPrice2.Text);
                    //myAccess.XPrice1 = moh.StrToDouble(txtXPrice1.Text);
                    myAccess.XPrice1 = moh.StrToDouble(txtPriceDiff.Text) + moh.StrToDouble(txtPrice.Text);
                    myAccess.XPrice2 = moh.StrToDouble(txtXPrice2.Text);
                    myAccess.HTwoWay = moh.StrToDouble(txtHTwoWay.Text);
                    myAccess.LTwoWay = moh.StrToDouble(txtLTwoWay.Text);
                    myAccess.TruckPrice = moh.StrToDouble(txtTruckPrice.Text);
                    myAccess.TruckPrice2 = moh.StrToDouble(txtTruckPrice2.Text);
                    myAccess.Truck2Price = moh.StrToDouble(txtTruck2Price.Text);
                    myAccess.Truck2Price2 = moh.StrToDouble(txtTruck2Price2.Text);
                    myAccess.FTime = txtFTime.Text;
                    myAccess.CostAmount = moh.StrToDouble(txtCostAmount.Text);
                    myAccess.HOneWay = moh.StrToDouble(txtHOneWay.Text);
                    myAccess.LOneWay = moh.StrToDouble(txtLOneWay.Text);
                    myAccess.ExPrice1 = moh.StrToDouble(txtExPrice1.Text);
                    myAccess.ExPrice01 = moh.StrToDouble(txtExPrice01.Text);
                    myAccess.ExPrice12 = moh.StrToDouble(txtExPrice12.Text);
                    myAccess.ExPrice012 = moh.StrToDouble(txtExPrice012.Text);
                    myAccess.ExPrice4 = moh.StrToDouble(txtExPrice4.Text);
                    myAccess.ExPrice04 = moh.StrToDouble(txtExPrice04.Text);
                    myAccess.ExPrice42 = moh.StrToDouble(txtExPrice42.Text);
                    myAccess.ExPrice042 = moh.StrToDouble(txtExPrice042.Text);
                    myAccess.ExPrice2 = moh.StrToDouble(txtExPrice2.Text);
                    myAccess.ExPrice02 = moh.StrToDouble(txtExPrice02.Text);
                    myAccess.ExPrice22 = moh.StrToDouble(txtExPrice22.Text);
                    myAccess.ExPrice022 = moh.StrToDouble(txtExPrice022.Text);
                    myAccess.ExPrice3 = moh.StrToDouble(txtExPrice3.Text);
                    myAccess.ExPrice03 = moh.StrToDouble(txtExPrice03.Text);
                    myAccess.ExPrice32 = moh.StrToDouble(txtExPrice32.Text);
                    myAccess.ExPrice032 = moh.StrToDouble(txtExPrice032.Text);
                    myAccess.FTime2 = txtFTime2.Text;
                    myAccess.XPrice3 = moh.StrToDouble(txtXPrice3.Text);
                    myAccess.XPrice4 = moh.StrToDouble(txtXPrice4.Text);
                    myAccess.XPrice5 = moh.StrToDouble(txtXPrice5.Text);
                    myAccess.UserName = Session["CurrentUser"].ToString();
                    myAccess.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    if (!myAccess.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        e.Cancel = true;
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                }
                else
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
                    Response.Redirect("GeneralServerError.aspx", false);
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
                    Response.Redirect("GeneralServerError.aspx", false);
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
                    Response.Redirect("GeneralServerError.aspx", false);
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
                    Response.Redirect("GeneralServerError.aspx", false);
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
                    Response.Redirect("GeneralServerError.aspx", false);
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