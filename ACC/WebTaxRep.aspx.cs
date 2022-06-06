using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using iTextSharp.text.pdf;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Configuration;
using System.Threading;

namespace ACC
{
    public partial class WebTaxRep : System.Web.UI.Page
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
                BtnPrint1.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnPrint1);

                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "الاقرار الضريبي";
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


                    for (int i = 2018; i < (DateTime.Now.Year + 1); i++)
                    {
                        ddlMonth.Items.Add(new ListItem("الربع الاول من " + i.ToString(), "1-" + i.ToString()));
                        ddlMonth.Items.Add(new ListItem("الربع الثاني من " + i.ToString(), "2-" + i.ToString()));
                        ddlMonth.Items.Add(new ListItem("الربع الثالث من " + i.ToString(), "3-" + i.ToString()));
                        ddlMonth.Items.Add(new ListItem("الربع االرابع من " + i.ToString(), "4-" + i.ToString()));
                    }
                    ddlMonth.Items.Insert(0,new ListItem("--- اختر الفترة ---", "-1"));
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

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblNetTax.Text = "";
                LblCodesResult.Text = "";
                lblTotPTax.Text = "";
                lblTotPurchases.Text = "";
                lblTotSales.Text = "";
                lblTotSTax.Text = "";
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
                if (ddlMonth.SelectedValue != "-1")
                {
                    string s = ddlMonth.SelectedValue.Split('-')[0];
                    string vYear = ddlMonth.SelectedValue.Split('-')[1];
                    string Fdate = "";
                    string Edate = "";
                    if (s == "1")
                    {
                        Fdate = "01/01/" + vYear;
                        Edate = "31/03/" + vYear;
                    }
                    else if (s == "2")
                    {
                        Fdate = "01/04/" + vYear;
                        Edate = "30/06/" + vYear;
                    }
                    else if (s == "3")
                    {
                        Fdate = "01/07/" + vYear;
                        Edate = "30/09/" + vYear;
                    }
                    else if (s == "4")
                    {
                        Fdate = "01/10/" + vYear;
                        Edate = "31/12/" + vYear;
                    }

                    lblTotSTax.Text = string.Format("{0:N2}", Math.Abs(moh.GetBal0("240601001", Fdate, Edate, true, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)));
                    lblTotPTax.Text = string.Format("{0:N2}", Math.Abs(moh.GetBal0("120409001", Fdate, Edate, true, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)));

                    double vDesel = 0;
                    if (moh.StrToInt(vYear) < 2021) vDesel = Math.Abs(moh.GetBal0("310201001", Fdate, Edate, true, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    lblTotPTax.Text = string.Format("{0:N2}", moh.StrToDouble(lblTotPTax.Text) + (vDesel * moh.doTax(Fdate)));
                    lblTotSales.Text = string.Format("{0:N2}", moh.StrToDouble(lblTotSTax.Text) * (1/moh.doTax(Fdate)));
                    lblTotPurchases.Text = string.Format("{0:N2}", moh.StrToDouble(lblTotPTax.Text) * (1/moh.doTax(Fdate)));
                    lblNetTax.Text = string.Format("{0:N2}", moh.StrToDouble(lblTotSTax.Text) - moh.StrToDouble(lblTotPTax.Text));
                }
                else
                {
                    lblNetTax.Text = "";
                    LblCodesResult.Text = "";
                    lblTotPTax.Text = "";
                    lblTotPurchases.Text = "";
                    lblTotSales.Text = "";
                    lblTotSTax.Text = "";
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

        protected void BtnPrint1_Command(object sender, CommandEventArgs e)
        {

        }

    }
}