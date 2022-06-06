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
    public partial class WebLines : System.Web.UI.Page
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
        public List<Lines> MyOver
        {
            get
            {
                if (ViewState["MyOver"] == null)
                {
                    ViewState["MyOver"] = new List<Lines>();
                }
                return (List<Lines>)ViewState["MyOver"];
            }
            set { ViewState["MyOver"] = value; }
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
                    this.Page.Header.Title = "خط سير الرحلة";
                    //BtnEdit.Visible = (bool)((TblRoles)(Session["Roll"])).Pass211;
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

                    Cities myCity = new Cities();
                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlToCity.DataTextField = "Name1";
                    ddlToCity.DataValueField = "Code";
                    ddlFromCity.DataTextField = "Name1";
                    ddlFromCity.DataValueField = "Code";
                    ddlToCity.DataSource = (from itm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                            orderby itm.Name1
                                            select itm).ToList();
                    ddlFromCity.DataSource = ddlToCity.DataSource;
                    ddlToCity.DataBind();
                    ddlFromCity.DataBind();
                    ddlFromCity_SelectedIndexChanged(sender, e);
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

        private void DisplayData()
        {
            try
            {
                grdCodes.DataSource = MyOver;
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

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    foreach (GridViewRow gvr in grdCodes.Rows)
                    {
                        Label FNo = gvr.FindControl("lblFNo") as Label;
                        TextBox Area1 = gvr.FindControl("txtArea1") as TextBox;
                        TextBox Area2 = gvr.FindControl("txtArea2") as TextBox;
                        TextBox KM = gvr.FindControl("txtKM") as TextBox;
                        TextBox Cost = gvr.FindControl("txtCost") as TextBox;
                        DropDownList CustCode = gvr.FindControl("ddlCust") as DropDownList;

                        if (FNo != null && Area1 != null && Area2 != null && KM != null && Cost != null && CustCode != null)  
                        {
                            if (KM.Text.Trim() == "") KM.Text = "0";
                            if (Cost.Text.Trim() == "") Cost.Text = "0";
                            if (MyOver[int.Parse(FNo.Text)-1].Area1 != Area1.Text || MyOver[int.Parse(FNo.Text)-1].Area2 != Area2.Text || MyOver[int.Parse(FNo.Text)-1].KM != int.Parse(KM.Text) || MyOver[int.Parse(FNo.Text)-1].Cost != moh.StrToDouble(Cost.Text) || MyOver[int.Parse(FNo.Text)-1].CustCode != CustCode.SelectedValue)
                            {
                                MyOver[int.Parse(FNo.Text) - 1].Area1 = Area1.Text;
                                MyOver[int.Parse(FNo.Text) - 1].Area2 = Area2.Text;
                                MyOver[int.Parse(FNo.Text) - 1].KM = int.Parse(KM.Text);
                                MyOver[int.Parse(FNo.Text) - 1].Cost = moh.StrToDouble(Cost.Text);
                                MyOver[int.Parse(FNo.Text) - 1].CustCode = CustCode.SelectedValue;
                                if (MyOver[int.Parse(FNo.Text) - 1].find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) != null)
                                {
                                    if(Area1.Text.Trim() != "" || Area2.Text.Trim()!="") MyOver[int.Parse(FNo.Text) - 1].update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    else MyOver[int.Parse(FNo.Text) - 1].Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                }
                                else
                                {
                                    if (Area1.Text.Trim() != "" || Area2.Text.Trim() != "") MyOver[int.Parse(FNo.Text) - 1].Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    else MyOver[int.Parse(FNo.Text) - 1].Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);                                    
                                }
                            }
                        }
                    }
                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(1,'" + LblCodesResult.Text + "');", true);
                    DisplayData();
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

        protected void ddlFromCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Lines myLine = new Lines();
                myLine.FromCity = ddlFromCity.SelectedValue;
                myLine.ToCity = ddlToCity.SelectedValue;
                MyOver = myLine.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                for (int i = MyOver.Count(); i < 30; i++)
                {
                    MyOver.Add(new Lines
                    {
                        Area1 = "",
                        Area2 = "",
                        Cost = 0,
                        KM = 0,
                        CustCode = "-1",
                        FNo = short.Parse((i + 1).ToString()),
                        FromCity = ddlFromCity.SelectedValue,
                        ToCity = ddlToCity.SelectedValue
                    });
                }
                DisplayData();
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void ddlCust_Init(object sender, EventArgs e)
        {
            DropDownList ddlCust = sender as DropDownList;

            GridViewRow gvr = ddlCust.NamingContainer as GridViewRow;
            string FNo = grdCodes.DataKeys[gvr.RowIndex]["FNo"].ToString();
            Clients myacc = new Clients();
            myacc.Branch = short.Parse(Session["Branch"].ToString());
            ddlCust.DataTextField = "name1";
            ddlCust.DataValueField = "Code";
            foreach (Clients itm in myacc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            {
                ddlCust.Items.Add(new ListItem(itm.Name1,itm.Code));
            }
            
            ddlCust.Items.Insert(0, new ListItem("--- أختار العميل ---", "-1", true));
            if (FNo != null)
            {
                ddlCust.SelectedValue = MyOver[int.Parse(FNo) - 1].CustCode;
            }
        }

    }
}