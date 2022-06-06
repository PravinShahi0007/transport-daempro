using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Threading;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Configuration;
using iTextSharp.text.pdf;
using System.Web.Configuration;
using System.IO;

namespace ACC
{
    public partial class WebIncomeExpens : System.Web.UI.Page
    {
        public string TotalIncome1
        {
            get
            {
                if (ViewState["TotalIncome1"] == null)
                {
                    ViewState["TotalIncome1"] = "0.00";
                }
                return ViewState["TotalIncome1"].ToString();
            }
            set { ViewState["TotalIncome1"] = value; }
        }
        public string TotalIncome2
        {
            get
            {
                if (ViewState["TotalIncome2"] == null)
                {
                    ViewState["TotalIncome2"] = "0.00";
                }
                return ViewState["TotalIncome2"].ToString();
            }
            set { ViewState["TotalIncome2"] = value; }
        }
        public string TotalIncome3
        {
            get
            {
                if (ViewState["TotalIncome3"] == null)
                {
                    ViewState["TotalIncome3"] = "0.00";
                }
                return ViewState["TotalIncome3"].ToString();
            }
            set { ViewState["TotalIncome3"] = value; }
        }
        public string TotalIncome4
        {
            get
            {
                if (ViewState["TotalIncome4"] == null)
                {
                    ViewState["TotalIncome4"] = "0.00";
                }
                return ViewState["TotalIncome4"].ToString();
            }
            set { ViewState["TotalIncome4"] = value; }
        }
        public string TotalIncome5
        {
            get
            {
                if (ViewState["TotalIncome5"] == null)
                {
                    ViewState["TotalIncome5"] = "0.00";
                }
                return ViewState["TotalIncome5"].ToString();
            }
            set { ViewState["TotalIncome5"] = value; }
        }
        public string TotalIncome6
        {
            get
            {
                if (ViewState["TotalIncome6"] == null)
                {
                    ViewState["TotalIncome6"] = "0.00";
                }
                return ViewState["TotalIncome6"].ToString();
            }
            set { ViewState["TotalIncome6"] = value; }
        }
        public string TotalIncome7
        {
            get
            {
                if (ViewState["TotalIncome7"] == null)
                {
                    ViewState["TotalIncome7"] = "0.00";
                }
                return ViewState["TotalIncome7"].ToString();
            }
            set { ViewState["TotalIncome7"] = value; }
        }
        public string TotalIncome8
        {
            get
            {
                if (ViewState["TotalIncome8"] == null)
                {
                    ViewState["TotalIncome8"] = "0.00";
                }
                return ViewState["TotalIncome8"].ToString();
            }
            set { ViewState["TotalIncome8"] = value; }
        }
        public string TotalIncome9
        {
            get
            {
                if (ViewState["TotalIncome9"] == null)
                {
                    ViewState["TotalIncome9"] = "0.00";
                }
                return ViewState["TotalIncome9"].ToString();
            }
            set { ViewState["TotalIncome9"] = value; }
        }
        public string TotalIncome10
        {
            get
            {
                if (ViewState["TotalIncome10"] == null)
                {
                    ViewState["TotalIncome10"] = "0.00";
                }
                return ViewState["TotalIncome10"].ToString();
            }
            set { ViewState["TotalIncome10"] = value; }
        }
        public string TotalIncome11
        {
            get
            {
                if (ViewState["TotalIncome11"] == null)
                {
                    ViewState["TotalIncome11"] = "0.00";
                }
                return ViewState["TotalIncome11"].ToString();
            }
            set { ViewState["TotalIncome11"] = value; }
        }
        public string TotalIncome12
        {
            get
            {
                if (ViewState["TotalIncome12"] == null)
                {
                    ViewState["TotalIncome12"] = "0.00";
                }
                return ViewState["TotalIncome12"].ToString();
            }
            set { ViewState["TotalIncome12"] = value; }
        }

        public string TotalExpenses1
        {
            get
            {
                if (ViewState["TotalExpenses1"] == null)
                {
                    ViewState["TotalExpenses1"] = "0.00";
                }
                return ViewState["TotalExpenses1"].ToString();
            }
            set { ViewState["TotalExpenses1"] = value; }
        }
        public string TotalExpenses2
        {
            get
            {
                if (ViewState["TotalExpenses2"] == null)
                {
                    ViewState["TotalExpenses2"] = "0.00";
                }
                return ViewState["TotalExpenses2"].ToString();
            }
            set { ViewState["TotalExpenses2"] = value; }
        }
        public string TotalExpenses3
        {
            get
            {
                if (ViewState["TotalExpenses3"] == null)
                {
                    ViewState["TotalExpenses3"] = "0.00";
                }
                return ViewState["TotalExpenses3"].ToString();
            }
            set { ViewState["TotalExpenses3"] = value; }
        }
        public string TotalExpenses4
        {
            get
            {
                if (ViewState["TotalExpenses4"] == null)
                {
                    ViewState["TotalExpenses4"] = "0.00";
                }
                return ViewState["TotalExpenses4"].ToString();
            }
            set { ViewState["TotalExpenses4"] = value; }
        }
        public string TotalExpenses5
        {
            get
            {
                if (ViewState["TotalExpenses5"] == null)
                {
                    ViewState["TotalExpenses5"] = "0.00";
                }
                return ViewState["TotalExpenses5"].ToString();
            }
            set { ViewState["TotalExpenses5"] = value; }
        }
        public string TotalExpenses6
        {
            get
            {
                if (ViewState["TotalExpenses6"] == null)
                {
                    ViewState["TotalExpenses6"] = "0.00";
                }
                return ViewState["TotalExpenses6"].ToString();
            }
            set { ViewState["TotalExpenses6"] = value; }
        }
        public string TotalExpenses7
        {
            get
            {
                if (ViewState["TotalExpenses7"] == null)
                {
                    ViewState["TotalExpenses7"] = "0.00";
                }
                return ViewState["TotalExpenses7"].ToString();
            }
            set { ViewState["TotalExpenses7"] = value; }
        }
        public string TotalExpenses8
        {
            get
            {
                if (ViewState["TotalExpenses8"] == null)
                {
                    ViewState["TotalExpenses8"] = "0.00";
                }
                return ViewState["TotalExpenses8"].ToString();
            }
            set { ViewState["TotalExpenses8"] = value; }
        }
        public string TotalExpenses9
        {
            get
            {
                if (ViewState["TotalExpenses9"] == null)
                {
                    ViewState["TotalExpenses9"] = "0.00";
                }
                return ViewState["TotalExpenses9"].ToString();
            }
            set { ViewState["TotalExpenses9"] = value; }
        }
        public string TotalExpenses10
        {
            get
            {
                if (ViewState["TotalExpenses10"] == null)
                {
                    ViewState["TotalExpenses10"] = "0.00";
                }
                return ViewState["TotalExpenses10"].ToString();
            }
            set { ViewState["TotalExpenses10"] = value; }
        }
        public string TotalExpenses11
        {
            get
            {
                if (ViewState["TotalExpenses11"] == null)
                {
                    ViewState["TotalExpenses11"] = "0.00";
                }
                return ViewState["TotalExpenses11"].ToString();
            }
            set { ViewState["TotalExpenses11"] = value; }
        }
        public string TotalExpenses12
        {
            get
            {
                if (ViewState["TotalExpenses12"] == null)
                {
                    ViewState["TotalExpenses12"] = "0.00";
                }
                return ViewState["TotalExpenses12"].ToString();
            }
            set { ViewState["TotalExpenses12"] = value; }
        }

        public List<vCostCenterResult> MyOver
        {
            get
            {
                if (ViewState["MyOver"] == null)
                {
                    ViewState["MyOver"] = new List<vCostCenterResult>();
                }
                return (List<vCostCenterResult>)ViewState["MyOver"];
            }
            set { ViewState["MyOver"] = value; }
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
                BtnExcel.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnPrint1);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnExcel);

                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "حساب الأيرادات و المصروفات";

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

                    Jv myJv = new Jv();
                    foreach (string itm in myJv.JvGetMonths(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        ChkPeriods.Items.Add(new ListItem(itm));
                    foreach (string itm in myJv.JvGetYears(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        ChkPeriods.Items.Add(new ListItem(itm));
                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "الرئيسية", "اختيار", "اختيار عرض تقييم مراكز الفروع ", "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

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
                grdCodes.DataSource = MyOver;
                grdCodes.DataBind();
                if (lblCount.Text == "")
                {
                    lblCount.Text = MyOver.Count().ToString();
                    MakeSum();
                }
                if (ChkPeriod0.Checked)
                {
                    grdCodes.Columns[0].Visible = true;
                    grdCodes.Columns[1].Visible = true;
                    grdCodes.Columns[2].Visible = double.Parse(TotalExpenses1) > 0;
                    grdCodes.Columns[3].Visible = double.Parse(TotalExpenses2) > 0;
                    grdCodes.Columns[4].Visible = double.Parse(TotalExpenses3) > 0;
                    grdCodes.Columns[5].Visible = double.Parse(TotalExpenses4) > 0;
                    grdCodes.Columns[6].Visible = double.Parse(TotalExpenses5) > 0;
                    grdCodes.Columns[7].Visible = double.Parse(TotalExpenses6) > 0;
                    grdCodes.Columns[8].Visible = double.Parse(TotalExpenses7) > 0;
                    grdCodes.Columns[9].Visible = double.Parse(TotalExpenses8) > 0;
                    grdCodes.Columns[10].Visible = double.Parse(TotalExpenses9) > 0;
                    grdCodes.Columns[11].Visible = double.Parse(TotalExpenses10) > 0;
                    grdCodes.Columns[12].Visible = double.Parse(TotalExpenses11) > 0;
                    grdCodes.Columns[13].Visible = double.Parse(TotalExpenses12) > 0;
                    grdCodes.Columns[14].Visible = true;
                    grdCodes.Columns[15].Visible = true;
                    grdCodes.Columns[16].Visible = double.Parse(TotalIncome1) > 0;
                    grdCodes.Columns[17].Visible = double.Parse(TotalIncome2) > 0;
                    grdCodes.Columns[18].Visible = double.Parse(TotalIncome3) > 0;
                    grdCodes.Columns[19].Visible = double.Parse(TotalIncome4) > 0;
                    grdCodes.Columns[20].Visible = double.Parse(TotalIncome5) > 0;
                    grdCodes.Columns[21].Visible = double.Parse(TotalIncome6) > 0;
                    grdCodes.Columns[22].Visible = double.Parse(TotalIncome7) > 0;
                    grdCodes.Columns[23].Visible = double.Parse(TotalIncome8) > 0;
                    grdCodes.Columns[24].Visible = double.Parse(TotalIncome9) > 0;
                    grdCodes.Columns[25].Visible = double.Parse(TotalIncome10) > 0;
                    grdCodes.Columns[26].Visible = double.Parse(TotalIncome11) > 0;
                    grdCodes.Columns[27].Visible = double.Parse(TotalIncome12) > 0;

                    int r = 2;
                    int i = 1;
                    foreach (ListItem sitm in ChkPeriods.Items)
                    {
                        if (sitm.Selected)
                        {
                            grdCodes.HeaderRow.Cells[r].Text = sitm.Text;
                            grdCodes.HeaderRow.Cells[r + 14].Text = sitm.Text;
                            r++;
                            i++;
                            if (i > 12) break;
                        }
                    }

                }
                else
                {
                    grdCodes.Columns[0].Visible = true;
                    grdCodes.Columns[1].Visible = true;
                    grdCodes.Columns[2].Visible = true;
                    grdCodes.Columns[3].Visible = false;
                    grdCodes.Columns[4].Visible = false;
                    grdCodes.Columns[5].Visible = false;
                    grdCodes.Columns[6].Visible = false;
                    grdCodes.Columns[7].Visible = false;
                    grdCodes.Columns[8].Visible = false;
                    grdCodes.Columns[9].Visible = false;
                    grdCodes.Columns[10].Visible = false;
                    grdCodes.Columns[11].Visible = false;
                    grdCodes.Columns[12].Visible = false;
                    grdCodes.Columns[13].Visible = false;
                    grdCodes.Columns[14].Visible = true;
                    grdCodes.Columns[15].Visible = true;
                    grdCodes.Columns[16].Visible = true;
                    grdCodes.Columns[17].Visible = false;
                    grdCodes.Columns[18].Visible = false;
                    grdCodes.Columns[19].Visible = false;
                    grdCodes.Columns[20].Visible = false;
                    grdCodes.Columns[21].Visible = false;
                    grdCodes.Columns[22].Visible = false;
                    grdCodes.Columns[23].Visible = false;
                    grdCodes.Columns[24].Visible = false;
                    grdCodes.Columns[25].Visible = false;
                    grdCodes.Columns[26].Visible = false;
                    grdCodes.Columns[27].Visible = false;   
                }
                BtnPrint1.Visible = MyOver.Count() > 0;
                BtnExcel.Visible = MyOver.Count() > 0;
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

        public void MakeSum()
        {
            try
            {
                if (grdCodes.FooterRow != null)
                {
                    Label lblTotalIncome1 = grdCodes.FooterRow.FindControl("lblTotalIncome1") as Label;
                    Label lblTotalIncome2 = grdCodes.FooterRow.FindControl("lblTotalIncome2") as Label;
                    Label lblTotalIncome3 = grdCodes.FooterRow.FindControl("lblTotalIncome3") as Label;
                    Label lblTotalIncome4 = grdCodes.FooterRow.FindControl("lblTotalIncome4") as Label;
                    Label lblTotalIncome5 = grdCodes.FooterRow.FindControl("lblTotalIncome5") as Label;
                    Label lblTotalIncome6 = grdCodes.FooterRow.FindControl("lblTotalIncome6") as Label;
                    Label lblTotalIncome7 = grdCodes.FooterRow.FindControl("lblTotalIncome7") as Label;
                    Label lblTotalIncome8 = grdCodes.FooterRow.FindControl("lblTotalIncome8") as Label;
                    Label lblTotalIncome9 = grdCodes.FooterRow.FindControl("lblTotalIncome9") as Label;
                    Label lblTotalIncome10 = grdCodes.FooterRow.FindControl("lblTotalIncome10") as Label;
                    Label lblTotalIncome11 = grdCodes.FooterRow.FindControl("lblTotalIncome11") as Label;
                    Label lblTotalIncome12 = grdCodes.FooterRow.FindControl("lblTotalIncome12") as Label;
                    Label lblTotalExpenses1 = grdCodes.FooterRow.FindControl("lblTotalExpenses1") as Label;
                    Label lblTotalExpenses2 = grdCodes.FooterRow.FindControl("lblTotalExpenses2") as Label;
                    Label lblTotalExpenses3 = grdCodes.FooterRow.FindControl("lblTotalExpenses3") as Label;
                    Label lblTotalExpenses4 = grdCodes.FooterRow.FindControl("lblTotalExpenses4") as Label;
                    Label lblTotalExpenses5 = grdCodes.FooterRow.FindControl("lblTotalExpenses5") as Label;
                    Label lblTotalExpenses6 = grdCodes.FooterRow.FindControl("lblTotalExpenses6") as Label;
                    Label lblTotalExpenses7 = grdCodes.FooterRow.FindControl("lblTotalExpenses7") as Label;
                    Label lblTotalExpenses8 = grdCodes.FooterRow.FindControl("lblTotalExpenses8") as Label;
                    Label lblTotalExpenses9 = grdCodes.FooterRow.FindControl("lblTotalExpenses9") as Label;
                    Label lblTotalExpenses10 = grdCodes.FooterRow.FindControl("lblTotalExpenses10") as Label;
                    Label lblTotalExpenses11 = grdCodes.FooterRow.FindControl("lblTotalExpenses11") as Label;
                    Label lblTotalExpenses12 = grdCodes.FooterRow.FindControl("lblTotalExpenses12") as Label;
                    
                    if (lblTotalIncome1 != null)
                    {
                        lblTotalIncome1.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Income1));
                        TotalIncome1 = lblTotalIncome1.Text;
                    }
                    if (lblTotalExpenses1 != null)
                    {
                        lblTotalExpenses1.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Expenses1));
                        TotalExpenses1 = lblTotalExpenses1.Text;
                    }

                    if (lblTotalIncome2 != null)
                    {
                        lblTotalIncome2.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Income2));
                        TotalIncome2 = lblTotalIncome2.Text;
                    }
                    if (lblTotalExpenses2 != null)
                    {
                        lblTotalExpenses2.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Expenses2));
                        TotalExpenses2 = lblTotalExpenses2.Text;
                    }

                    if (lblTotalIncome3 != null)
                    {
                        lblTotalIncome3.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Income3));
                        TotalIncome3 = lblTotalIncome3.Text;
                    }
                    if (lblTotalExpenses3 != null)
                    {
                        lblTotalExpenses3.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Expenses3));
                        TotalExpenses3 = lblTotalExpenses3.Text;
                    }

                    if (lblTotalIncome4 != null)
                    {
                        lblTotalIncome4.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Income4));
                        TotalIncome4 = lblTotalIncome4.Text;
                    }
                    if (lblTotalExpenses4 != null)
                    {
                        lblTotalExpenses4.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Expenses4));
                        TotalExpenses4 = lblTotalExpenses4.Text;
                    }

                    if (lblTotalIncome5 != null)
                    {
                        lblTotalIncome5.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Income5));
                        TotalIncome5 = lblTotalIncome5.Text;
                    }
                    if (lblTotalExpenses5 != null)
                    {
                        lblTotalExpenses5.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Expenses5));
                        TotalExpenses5 = lblTotalExpenses5.Text;
                    }

                    if (lblTotalIncome6 != null)
                    {
                        lblTotalIncome6.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Income6));
                        TotalIncome6 = lblTotalIncome6.Text;
                    }
                    if (lblTotalExpenses6 != null)
                    {
                        lblTotalExpenses6.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Expenses6));
                        TotalExpenses6 = lblTotalExpenses6.Text;
                    }
                    if (lblTotalIncome7 != null)
                    {
                        lblTotalIncome7.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Income7));
                        TotalIncome7 = lblTotalIncome7.Text;
                    }
                    if (lblTotalExpenses7 != null)
                    {
                        lblTotalExpenses7.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Expenses7));
                        TotalExpenses7 = lblTotalExpenses7.Text;
                    }
                    if (lblTotalIncome8 != null)
                    {
                        lblTotalIncome8.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Income8));
                        TotalIncome8 = lblTotalIncome8.Text;
                    }
                    if (lblTotalExpenses8 != null)
                    {
                        lblTotalExpenses8.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Expenses8));
                        TotalExpenses8 = lblTotalExpenses8.Text;
                    }
                    if (lblTotalIncome9 != null)
                    {
                        lblTotalIncome9.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Income9));
                        TotalIncome9 = lblTotalIncome9.Text;
                    }
                    if (lblTotalExpenses9 != null)
                    {
                        lblTotalExpenses9.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Expenses9));
                        TotalExpenses9 = lblTotalExpenses9.Text;
                    }
                    if (lblTotalIncome10 != null)
                    {
                        lblTotalIncome10.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Income10));
                        TotalIncome10 = lblTotalIncome10.Text;
                    }
                    if (lblTotalExpenses10 != null)
                    {
                        lblTotalExpenses10.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Expenses10));
                        TotalExpenses10 = lblTotalExpenses10.Text;
                    }
                    if (lblTotalIncome11 != null)
                    {
                        lblTotalIncome11.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Income11));
                        TotalIncome11 = lblTotalIncome11.Text;
                    }
                    if (lblTotalExpenses11 != null)
                    {
                        lblTotalExpenses11.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Expenses11));
                        TotalExpenses11 = lblTotalExpenses11.Text;
                    }
                    if (lblTotalIncome12 != null)
                    {
                        lblTotalIncome12.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Income12));
                        TotalIncome12 = lblTotalIncome12.Text;
                    }
                    if (lblTotalExpenses12 != null)
                    {
                        lblTotalExpenses12.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Expenses12));
                        TotalExpenses12 = lblTotalExpenses12.Text;
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

        protected void BtnPrint1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                {
                    moh.AddUserTrans(Session["CurrentUser"].ToString(), "تقييم مراكز الفروع", "طباعة", "اختيار طباعة تقييم مراكز الفروع ", "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                }

                iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), -75, -75, 80, 50);
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
                page.PageNo = "1";
                page.UserName = Session["FullUser"].ToString();

                //CostCenter myCost = new CostCenter();
                //myCost.Branch = 1;
                //myCost.Code = Request.QueryString["AreaNo"] != null ? Request.QueryString["AreaNo"].ToString() : Session["AreaNo"].ToString();
                //myCost = myCost.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                page.vStr4 = "الإدارة المالية";
                //-------------------------------------------------------------------------------------------                    
                document.Open();
                //-------------------------------------------------------------------------------------------                    

                //string arialunicodepath = Server.MapPath("Fonts") + @"\arial.ttf";
                string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 8f, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font nationalTextFont2 = new iTextSharp.text.Font(nationalBase, 10f, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font nationalTextFont14 = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font nationalTextFont16 = new iTextSharp.text.Font(nationalBase, 14f, iTextSharp.text.Font.NORMAL);
                //-------------------------------------------------------------------------------------------                    
                //document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                //-------------------------------------------------------------------------------------------                    
                var cols = new[] { 1200 };
                document.Open();
                PdfPTable table = new PdfPTable(1);
                table.TotalWidth = document.PageSize.Width; //100f;
                table.SetWidths(cols);
                PdfPCell cell2 = new PdfPCell();
                cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell2.Border = 0;
                cell2.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell2);

                cell2.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                if (ChkPeriod.Checked)
                {
                    cell2.Phrase = new iTextSharp.text.Phrase("حساب الأيرادات و المصروفات  " , nationalTextFont14);
                }
                else
                {
                    cell2.Phrase = new iTextSharp.text.Phrase("حساب الأيرادات و المصروفات  -  "  + txtFDate.Text + " إلى " + txtEDate.Text, nationalTextFont14);
                }
                table.AddCell(cell2);

                document.Add(table);
                //-------------------------------------------------------------------------------------------
                document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                //-------------------------------------------------------------------------------------------
                cols = new[] { 40, 40, 40, 40, 40, 40, 40, 40, 40, 40, 40, 40, 100, 60, 40, 40, 40, 40, 40, 40,40, 40, 40, 40, 40, 40, 100, 60 };
                int ColCount = 28;
                for (int i = 0; i < 28; i++)
                    if (!grdCodes.Columns[i].Visible) ColCount--;
                else if (ColCount == 26) cols = new[] { 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 100, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 100, 60 };
                else if (ColCount == 24) cols = new[] { 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 100, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 100, 60 };
                else if (ColCount == 22) cols = new[] { 65, 65, 65, 65, 65, 65, 65, 65, 65, 100, 60, 65, 65, 65, 65, 65, 65, 65, 65, 65, 100, 60 };
                else if (ColCount == 20) cols = new[] { 70, 70, 70, 70, 70, 70, 70, 70, 100, 60, 70, 70, 70, 70, 70, 70, 70, 70, 100, 60 };
                else if (ColCount == 18) cols = new[] { 70, 70, 70, 70, 70, 70, 70, 100, 60, 70, 70, 70, 70, 70, 70, 70, 100, 60 };
                else if (ColCount == 16) cols = new[] { 75, 75, 75, 75, 75, 75, 100, 60, 75, 75, 75, 75, 75, 75, 100, 60 };
                else if (ColCount == 14) cols = new[] { 80, 80, 80, 80, 80, 200, 80, 80, 80, 80, 80, 80, 200, 80 };
                else if (ColCount == 12) cols = new[] { 100, 100, 100, 100, 200, 100, 100, 100, 100, 100, 200, 100 };
                else if (ColCount == 10) cols = new[] { 120, 120, 120, 200, 100, 120, 120, 120, 200, 100 };
                else if (ColCount == 8) cols = new[] { 150, 150, 200, 100, 150, 150, 200, 100 };
                else if (ColCount == 6) cols = new[] { 200, 300, 100, 200, 300, 100 };

                table = new PdfPTable(ColCount);

                table.TotalWidth = document.PageSize.Width; //100f;
                table.SetWidths(cols);
                PdfPCell cell = new PdfPCell();
                //cell.FixedHeight = 20f;

                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;


                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                for (int i = 0; i < 28; i++)
                    if (grdCodes.Columns[i].Visible)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(grdCodes.HeaderRow.Cells[i].Text, nationalTextFont2);
                        table.AddCell(cell);
                    }

                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;

                if (MyOver != null && MyOver.Count > 0)
                {
                    foreach (vCostCenterResult inv in MyOver)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(inv.Code, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.Name1, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Expenses1), nationalTextFont);
                        table.AddCell(cell);

                        if (ColCount > 6)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Expenses2), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (ColCount > 8)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Expenses3), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (ColCount > 10)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Expenses4), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (ColCount > 12)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Expenses5), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (ColCount > 14)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Expenses6), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (ColCount > 16)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Expenses7), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (ColCount > 18)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Expenses8), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (ColCount > 20)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Expenses9), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (ColCount > 22)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Expenses10), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (ColCount > 24)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Expenses11), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (ColCount > 26)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Expenses12), nationalTextFont);
                            table.AddCell(cell);
                        }

                        cell.Phrase = new iTextSharp.text.Phrase(inv.Code2, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.Name2, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Income1), nationalTextFont);
                        table.AddCell(cell);

                        if (ColCount > 6)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Income2), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (ColCount > 8)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Income3), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (ColCount > 10)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Income4), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (ColCount > 12)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Income5), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (ColCount > 14)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Income6), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (ColCount > 16)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Income7), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (ColCount > 18)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Income8), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (ColCount > 20)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Income9), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (ColCount > 22)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Income10), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (ColCount > 24)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Income11), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (ColCount > 26)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Income12), nationalTextFont);
                            table.AddCell(cell);
                        }

                    }
                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الاجمالي", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(TotalExpenses1, nationalTextFont);
                    table.AddCell(cell);

                    if (ColCount > 6)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome2, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (ColCount > 8)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome3, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (ColCount > 10)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome4, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (ColCount > 12)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome5, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (ColCount > 14)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome6, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (ColCount > 16)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome7, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (ColCount > 18)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome8, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (ColCount > 20)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome9, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (ColCount > 22)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome10, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (ColCount > 24)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome11, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (ColCount > 26)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome12, nationalTextFont);
                        table.AddCell(cell);
                    }

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(TotalIncome1, nationalTextFont);
                    table.AddCell(cell);

                    if (ColCount > 6)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome2, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (ColCount > 8)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome3, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (ColCount > 10)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome4, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (ColCount > 12)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome5, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (ColCount > 14)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome6, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (ColCount > 16)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome7, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (ColCount > 18)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome8, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (ColCount > 20)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome9, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (ColCount > 22)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome10, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (ColCount > 24)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome11, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (ColCount > 26)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalIncome12, nationalTextFont);
                        table.AddCell(cell);
                    }

                }
                document.Add(table);
                document.Close();
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
                    //string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\arial.ttf";
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
                //string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\DTNASKH1.TTF";
                //string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\arial.ttf";
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);


                //I use a PdfPtable with 1 column to position my header where I want it
                PdfPTable headerTbl = new PdfPTable(3);
                var cols2 = new[] { 300, 550, 350 };
                headerTbl.TotalWidth = doc.PageSize.Width;
                headerTbl.SetWidths(cols2);
                headerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                //set the width of the table to be the same as the document


                PdfPCell cell2 = new PdfPCell();
                cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell2.Border = 0;
                cell2.PaddingRight = 15;
                cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell2.Phrase = new iTextSharp.text.Phrase(vCompanyName + "\n" + vStr4, nationalTextFont);
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

                //create new instance of cell to hold the text
                //cell = new PdfPCell();

                //align the text to the right of the cell
                //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
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

        protected void BtnExcel_Click(object sender, ImageClickEventArgs e)
        {
            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "أجمالي أنشطة العملاء", "تصدير", "اختيار تصدير أجمالي أنشطة العملاء " + (ChkPeriod.Checked ? "جميع الفترات " : txtFDate.Text + " إلى " + txtEDate.Text), "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.BufferOutput = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            Response.OutputStream.Write(new byte[] { 0xef, 0xbb, 0xbf }, 0, 3);

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grdCodes.AllowPaging = false;
            LoadCodesData();
            //Change the Header Row back to white color
            //grdCodes.HeaderRow.Style.Add("background-color", "#FFFFFF");

            //Apply style to Individual Cells
            //Gridview1.HeaderRow.Cells[0].Style.Add("background-color", "green");
            //Gridview1.HeaderRow.Cells[1].Style.Add("background-color", "green");
            //Gridview1.HeaderRow.Cells[2].Style.Add("background-color", "green");
            //Gridview1.HeaderRow.Cells[3].Style.Add("background-color", "green");

            //for (int i = 0; i < CardsDataGridView.Rows.Count; i++)
            //{
            //    GridViewRow row = CardsDataGridView.Rows[i];

            //    //Change Color back to white
            //    row.BackColor = System.Drawing.Color.White;

            //    //Apply text style to each Row
            //    row.Attributes.Add("class", "textmode");

            //    //Apply style to Individual Cells of Alternating Row
            //    if (i % 2 != 0)
            //    {
            //        row.Cells[0].Style.Add("background-color", "#C2D69B");
            //        row.Cells[1].Style.Add("background-color", "#C2D69B");
            //        row.Cells[2].Style.Add("background-color", "#C2D69B");
            //        row.Cells[3].Style.Add("background-color", "#C2D69B");
            //    }
            //}
            grdCodes.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            grdCodes.AllowPaging = true;

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered  */
        }

        protected void ChkPeriod_CheckedChanged(object sender, EventArgs e)
        {
            LblFDate.Visible = !ChkPeriod.Checked;
            LblEDate.Visible = !ChkPeriod.Checked;
            txtFDate.Visible = !ChkPeriod.Checked;
            txtEDate.Visible = !ChkPeriod.Checked;
            if (!ChkPeriod.Checked)
            {
                ChkPeriod0.Checked = false;
                ChkPeriod0_CheckedChanged(sender, e);
            }

            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void BtnProcess_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (!ChkPeriod.Checked)
                {
                    if (txtFDate.Text == "")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب إدخال التاريخ";
                        txtFDate.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }
                    if (txtEDate.Text == "")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب إدخال التاريخ";
                        txtEDate.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }
                }
                else
                {
                    txtFDate.Text = "";
                    txtEDate.Text = "";
                }

                if (ChkPeriod0.Checked)
                {
                    bool vfound2 = false;
                    foreach (ListItem sitm in ChkPeriods.Items)
                    {
                        if (sitm.Selected)
                        {
                            vfound2 = true;
                            break;
                        }
                    }
                    if (!vfound2)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أختيار فترة المقارنة";
                        ChkPeriods.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }
                }

                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "أجمالي أنشطة العملاء", "عرض", "اختيار عرض أجمالي أنشطة العملاء " + (ChkPeriod.Checked ? "جميع الفترات " : txtFDate.Text + " إلى " + txtEDate.Text), "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                lblCount.Text = "";
                MyOver.Clear();
                if (ChkPeriod0.Checked)
                {
                    List<Acc> lacc = new List<Acc>();
                    Acc myacc = new Acc();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["AllACC" + Session["CNN2"].ToString()] == null) Cache.Insert("AllACC" + Session["CNN2"].ToString(), myacc.Getall(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    lacc = (from itm in (List<Acc>)(Cache["AllACC" + Session["CNN2"].ToString()])
                            where getitem(itm)
                            select new Acc
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                FCode = itm.FCode,
                                MCode = itm.MCode,
                                FLevel = itm.FLevel,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                DAcc = 0,
                                CAcc = 0,
                                MDAcc = itm.MDAcc,
                                MCAcc = itm.MCAcc,
                                TDAcc = itm.TDAcc,
                                TCAcc = itm.TCAcc,
                                ODAcc = 0,
                                OCAcc = 0,
                                FDAcc = itm.FDAcc,
                                FCAcc = itm.FCAcc,
                            }).ToList();
                    int ritem = 1;
                    foreach (ListItem sitm in ChkPeriods.Items)
                    {
                        if (sitm.Selected)
                        {
                            PeriodAcc pa = new PeriodAcc();
                            List<PeriodAcc> lp = new List<PeriodAcc>();
                            lp = pa.GetPeriod(short.Parse(Session["Branch"].ToString()), 
                                (sitm.Text.Length == 4 ? "01/01/" + sitm.Text.Trim() : "01/" + moh.MakeMask(sitm.Text.Trim().Split('/')[1], 2) + "/" + sitm.Text.Trim().Split('/')[0]),
                                (sitm.Text.Length == 4 ? "31/12/" + sitm.Text.Trim() : DateTime.DaysInMonth(int.Parse(sitm.Text.Trim().Split('/')[0]),int.Parse(sitm.Text.Trim().Split('/')[1])).ToString() +"/" + moh.MakeMask(sitm.Text.Trim().Split('/')[1], 2) + "/" + sitm.Text.Trim().Split('/')[0]),
                                 WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            foreach (PeriodAcc itm in lp)
                            {
                                if (!string.IsNullOrEmpty(itm.DbCode))
                                {
                                    if (!string.IsNullOrEmpty(itm.DbCode) && itm.DbCode != "-1")
                                    {
                                        foreach (Acc myAcc in lacc)
                                        {
                                            if (myAcc.Code == itm.DbCode.Substring(0, 1))
                                            {
                                                myAcc.DAcc += itm.Amount;
                                            }
                                            else if (int.Parse(ddlLevel.SelectedValue)>1 && myAcc.Code == itm.DbCode.Substring(0, 2))
                                            {
                                                myAcc.DAcc += itm.Amount;
                                            }
                                            else if (int.Parse(ddlLevel.SelectedValue)>2 && myAcc.Code == itm.DbCode.Substring(0, 4))
                                            {
                                                myAcc.DAcc += itm.Amount;
                                            }
                                            else if (int.Parse(ddlLevel.SelectedValue)>3 && myAcc.Code == itm.DbCode.Substring(0, 6))
                                            {
                                                myAcc.DAcc += itm.Amount;
                                            }
                                            else if (int.Parse(ddlLevel.SelectedValue) > 4 && myAcc.Code == itm.DbCode)
                                            {
                                                myAcc.DAcc += itm.Amount;
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (Acc myAcc in lacc)
                                    {
                                        if (!string.IsNullOrEmpty(itm.CrCode) && itm.CrCode != "-1")
                                        {
                                            if (myAcc.Code == itm.CrCode.Substring(0, 1))
                                            {
                                                myAcc.CAcc += itm.Amount;
                                            }
                                            else if (int.Parse(ddlLevel.SelectedValue) > 1 && myAcc.Code == itm.CrCode.Substring(0, 2))
                                            {
                                                myAcc.CAcc += itm.Amount;
                                            }
                                            else if (int.Parse(ddlLevel.SelectedValue) > 2 && myAcc.Code == itm.CrCode.Substring(0, 4))
                                            {
                                                myAcc.CAcc += itm.Amount;
                                            }
                                            else if (int.Parse(ddlLevel.SelectedValue) > 3 && myAcc.Code == itm.CrCode.Substring(0, 6))
                                            {
                                                myAcc.CAcc += itm.Amount;
                                            }
                                            else if (int.Parse(ddlLevel.SelectedValue) > 4 && myAcc.Code == itm.CrCode)
                                            {
                                                myAcc.CAcc += itm.Amount;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            foreach (Acc myAcc in lacc)
                            {
                                if (myAcc.Code.StartsWith("3"))
                                {
                                    if (myAcc.DAcc - myAcc.CAcc != 0)
                                    {
                                        bool vfound = false;
                                        foreach (vCostCenterResult Over in MyOver)
                                        {
                                            if (Over.Code == myAcc.Code)
                                            {
                                                vfound = true;
                                                if (ritem == 1) Over.Expenses1 = myAcc.DAcc - myAcc.CAcc;
                                                else if (ritem == 2) Over.Expenses2 = myAcc.DAcc - myAcc.CAcc;
                                                else if (ritem == 3) Over.Expenses3 = myAcc.DAcc - myAcc.CAcc;
                                                else if (ritem == 4) Over.Expenses4 = myAcc.DAcc - myAcc.CAcc;
                                                else if (ritem == 5) Over.Expenses5 = myAcc.DAcc - myAcc.CAcc;
                                                else if (ritem == 6) Over.Expenses6 = myAcc.DAcc - myAcc.CAcc;
                                                else if (ritem == 7) Over.Expenses7 = myAcc.DAcc - myAcc.CAcc;
                                                else if (ritem == 8) Over.Expenses8 = myAcc.DAcc - myAcc.CAcc;
                                                else if (ritem == 9) Over.Expenses9 = myAcc.DAcc - myAcc.CAcc;
                                                else if (ritem == 10) Over.Expenses10 = myAcc.DAcc - myAcc.CAcc;
                                                else if (ritem == 11) Over.Expenses11 = myAcc.DAcc - myAcc.CAcc;
                                                else if (ritem == 12) Over.Expenses12 = myAcc.DAcc - myAcc.CAcc;
                                                break;
                                            }
                                        }
                                        if(!vfound)
                                        {                                            
                                            MyOver.Add(new vCostCenterResult
                                            {
                                                Code = myAcc.Code,
                                                Name1 = myAcc.Name1,
                                                Expenses1 = (ritem == 1 ? myAcc.DAcc - myAcc.CAcc : 0),
                                                Expenses2 = (ritem == 2 ? myAcc.DAcc - myAcc.CAcc : 0),
                                                Expenses3 = (ritem == 3 ? myAcc.DAcc - myAcc.CAcc : 0),
                                                Expenses4 = (ritem == 4 ? myAcc.DAcc - myAcc.CAcc : 0),
                                                Expenses5 = (ritem == 5 ? myAcc.DAcc - myAcc.CAcc : 0),
                                                Expenses6 = (ritem == 6 ? myAcc.DAcc - myAcc.CAcc : 0),
                                                Expenses7 = (ritem == 7 ? myAcc.DAcc - myAcc.CAcc : 0),
                                                Expenses8 = (ritem == 8 ? myAcc.DAcc - myAcc.CAcc : 0),
                                                Expenses9 = (ritem == 9 ? myAcc.DAcc - myAcc.CAcc : 0),
                                                Expenses10 = (ritem == 10 ? myAcc.DAcc - myAcc.CAcc : 0),
                                                Expenses11 = (ritem == 11 ? myAcc.DAcc - myAcc.CAcc : 0),
                                                Expenses12 = (ritem == 12 ? myAcc.DAcc - myAcc.CAcc : 0)
                                            });
                                        }
                                    }
                                }
                                else if (myAcc.Code.StartsWith("4"))
                                {
                                    if (myAcc.DAcc - myAcc.CAcc != 0)
                                    {
                                        bool vfound = false;
                                        foreach (vCostCenterResult Over in MyOver)
                                        {
                                            if (Over.Code2 == myAcc.Code)
                                            {
                                                vfound = true;
                                                if (ritem == 1) Over.Income1 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                else if (ritem == 2) Over.Income2 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                else if (ritem == 3) Over.Income3 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                else if (ritem == 4) Over.Income4 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                else if (ritem == 5) Over.Income5 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                else if (ritem == 6) Over.Income6 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                else if (ritem == 7) Over.Income7 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                else if (ritem == 8) Over.Income8 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                else if (ritem == 9) Over.Income9 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                else if (ritem == 10) Over.Income10 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                else if (ritem == 11) Over.Income11 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                else if (ritem == 12) Over.Income12 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                break;
                                            }
                                        }
                                        if (!vfound)
                                        {
                                            foreach (vCostCenterResult Over in MyOver)
                                            {
                                                if (string.IsNullOrEmpty(Over.Code2))
                                                {
                                                    vfound = true;
                                                    Over.Code2 = myAcc.Code;
                                                    Over.Name2 = myAcc.Name1;
                                                    if (ritem == 1) Over.Income1 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                    else if (ritem == 2) Over.Income2 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                    else if (ritem == 3) Over.Income3 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                    else if (ritem == 4) Over.Income4 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                    else if (ritem == 5) Over.Income5 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                    else if (ritem == 6) Over.Income6 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                    else if (ritem == 7) Over.Income7 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                    else if (ritem == 8) Over.Income8 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                    else if (ritem == 9) Over.Income9 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                    else if (ritem == 10) Over.Income10 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                    else if (ritem == 11) Over.Income11 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                    else if (ritem == 12) Over.Income12 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                                    break;
                                                }
                                            }
                                            if(!vfound)
                                            {
                                                MyOver.Add(new vCostCenterResult
                                                {
                                                    Code2 = myAcc.Code,
                                                    Name2 = myAcc.Name1,
                                                    Income1 = (ritem == 1 ? (myAcc.DAcc - myAcc.CAcc) * -1 : 0),
                                                    Income2 = (ritem == 2 ? (myAcc.DAcc - myAcc.CAcc) * -1 : 0),
                                                    Income3 = (ritem == 3 ? (myAcc.DAcc - myAcc.CAcc) * -1 : 0),
                                                    Income4 = (ritem == 4 ? (myAcc.DAcc - myAcc.CAcc) * -1 : 0),
                                                    Income5 = (ritem == 5 ? (myAcc.DAcc - myAcc.CAcc) * -1 : 0),
                                                    Income6 = (ritem == 6 ? (myAcc.DAcc - myAcc.CAcc) * -1 : 0),
                                                    Income7 = (ritem == 7 ? (myAcc.DAcc - myAcc.CAcc) * -1 : 0),
                                                    Income8 = (ritem == 8 ? (myAcc.DAcc - myAcc.CAcc) * -1 : 0),
                                                    Income9 = (ritem == 9 ? (myAcc.DAcc - myAcc.CAcc) * -1 : 0),
                                                    Income10 = (ritem == 10 ? (myAcc.DAcc - myAcc.CAcc) * -1 : 0),
                                                    Income11 = (ritem == 11 ? (myAcc.DAcc - myAcc.CAcc) * -1 : 0),
                                                    Income12 = (ritem == 12 ? (myAcc.DAcc - myAcc.CAcc) * -1 : 0)
                                                });                                            
                                            }
                                        }
                                    }
                                }
                            }
                            foreach (Acc myAcc in lacc)
                            {
                                myAcc.DAcc = 0;
                                myAcc.CAcc = 0;
                            }
                            ritem++;
                            if(ritem > 12 ) break;
                        }
                        if (ritem > 12) break;
                      }
                    double vcr1 = 0, vcr2 = 0, vcr3 = 0, vcr4 = 0, vcr5 = 0, vcr6 = 0, vdb1 = 0, vdb2 = 0, vdb3 = 0, vdb4 = 0, vdb5 = 0, vdb6 = 0, vcr7 = 0, vcr8 = 0, vcr9 = 0, vcr10 = 0, vcr11 = 0, vcr12 = 0, vdb7 = 0, vdb8 = 0, vdb9 = 0, vdb10 = 0, vdb11 = 0, vdb12 = 0;
                    foreach (vCostCenterResult Over in MyOver)
                    {
                        if (ritem >= 1)
                        {
                            vdb1 += (double)Over.Expenses1;
                            vcr1 += (double)Over.Income1;
                        }
                        if (ritem >= 2)
                        {
                            vdb2 += (double)Over.Expenses2;
                            vcr2 += (double)Over.Income2;
                        }
                        if (ritem >= 3)
                        {
                            vdb3 += (double)Over.Expenses3;
                            vcr3 += (double)Over.Income3;
                        }
                        if (ritem >= 4)
                        {
                            vdb4 += (double)Over.Expenses4;
                            vcr4 += (double)Over.Income4;
                        }
                        if (ritem >= 5)
                        {
                            vdb5 += (double)Over.Expenses5;
                            vcr5 += (double)Over.Income5;
                        }
                        if (ritem >= 6)
                        {
                            vdb6 += (double)Over.Expenses6;
                            vcr6 += (double)Over.Income6;
                        }
                        if (ritem >= 7)
                        {
                            vdb7 += (double)Over.Expenses7;
                            vcr7 += (double)Over.Income7;
                        }
                        if (ritem >= 8)
                        {
                            vdb8 += (double)Over.Expenses8;
                            vcr8 += (double)Over.Income8;
                        }
                        if (ritem >= 9)
                        {
                            vdb9 += (double)Over.Expenses9;
                            vcr9 += (double)Over.Income9;
                        }
                        if (ritem >= 10)
                        {
                            vdb10 += (double)Over.Expenses10;
                            vcr10 += (double)Over.Income10;
                        }
                        if (ritem >= 11)
                        {
                            vdb11 += (double)Over.Expenses11;
                            vcr11 += (double)Over.Income11;
                        }
                        if (ritem >= 12)
                        {
                            vdb12 += (double)Over.Expenses12;
                            vcr12 += (double)Over.Income12;
                        }
                    }
                    if (ritem >= 1)
                    {
                        if (vdb1 > vcr1)
                        {
                            MyOver.Add(new vCostCenterResult
                            {
                                Code2 = "",
                                Name2 = "صافي حسارة",
                                Income1 = vdb1 - vcr1
                            });

                        }
                        else if (vcr1 > vdb1)
                        {
                            MyOver.Add(new vCostCenterResult
                            {
                                Code = "",
                                Name1 = "صافي ربح",
                                Expenses1 = vcr1 - vdb1
                            });
                        }
                    }
                    if (ritem >= 2)
                    {
                        if (vdb2 > vcr2)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name2 == "صافي حسارة")                                    
                                {
                                    Over.Income2 = vdb2 - vcr2;
                                    break;
                                }
                                else if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Name2 = "صافي حسارة";
                                    Over.Income2 = vdb2 - vcr2;
                                    break;
                                }
                            }
                        }
                        else if (vcr2 > vdb2)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Expenses2 = vcr2 - vdb2;
                                    break;
                                }
                                else if (Over.Name2 == "صافي حسارة")
                                {
                                    Over.Name1 = "صافي ربح";
                                    Over.Expenses2 = vcr2 - vdb2;
                                    break;
                                }
                            }
                        }
                    }
                    if (ritem >= 3)
                    {
                        if (vdb3 > vcr3)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name2 == "صافي حسارة")
                                {
                                    Over.Income3 = vdb3 - vcr3;
                                    break;
                                }
                                else if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Name2 = "صافي حسارة";
                                    Over.Income3 = vdb3 - vcr3;
                                    break;
                                }
                            }
                        }
                        else if (vcr3 > vdb3)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Expenses3 = vcr3 - vdb3;
                                    break;
                                }
                                else if (Over.Name2 == "صافي حسارة")
                                {
                                    Over.Name1 = "صافي ربح";
                                    Over.Expenses3 = vcr3 - vdb3;
                                    break;
                                }
                            }
                        }
                    }
                    if (ritem >= 4)
                    {
                        if (vdb4 > vcr4)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name2 == "صافي حسارة")
                                {
                                    Over.Income4 = vdb4 - vcr4;
                                    break;
                                }
                                else if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Name2 = "صافي حسارة";
                                    Over.Income4 = vdb4 - vcr4;
                                    break;
                                }
                            }
                        }
                        else if (vcr4 > vdb4)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Expenses4 = vcr4 - vdb4;
                                    break;
                                }
                                else if (Over.Name2 == "صافي حسارة")
                                {
                                    Over.Name1 = "صافي ربح";
                                    Over.Expenses4 = vcr4 - vdb4;
                                    break;
                                }
                            }
                        }
                    }
                    if (ritem >= 5)
                    {
                        if (vdb5 > vcr5)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name2 == "صافي حسارة")
                                {
                                    Over.Income5 = vdb5 - vcr5;
                                    break;
                                }
                                else if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Name2 = "صافي حسارة";
                                    Over.Income5 = vdb5 - vcr5;
                                    break;
                                }
                            }
                        }
                        else if (vcr5 > vdb5)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Expenses5 = vcr5 - vdb5;
                                    break;
                                }
                                else if (Over.Name2 == "صافي حسارة")
                                {
                                    Over.Name1 = "صافي ربح";
                                    Over.Expenses5 = vcr5 - vdb5;
                                    break;
                                }
                            }
                        }
                    }
                    if (ritem >= 6)
                    {
                        if (vdb6 > vcr6)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name2 == "صافي حسارة")
                                {
                                    Over.Income6 = vdb6 - vcr6;
                                    break;
                                }
                                else if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Name2 = "صافي حسارة";
                                    Over.Income6 = vdb6 - vcr6;
                                    break;
                                }
                            }
                        }
                        else if (vcr6 > vdb6)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Expenses6 = vcr6 - vdb6;
                                    break;
                                }
                                else if (Over.Name2 == "صافي حسارة")
                                {
                                    Over.Name1 = "صافي ربح";
                                    Over.Expenses6 = vcr6 - vdb6;
                                    break;
                                }
                            }
                        }
                    }
                    if (ritem >= 7)
                    {
                        if (vdb7 > vcr7)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name2 == "صافي حسارة")
                                {
                                    Over.Income7 = vdb7 - vcr7;
                                    break;
                                }
                                else if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Name2 = "صافي حسارة";
                                    Over.Income7 = vdb7 - vcr7;
                                    break;
                                }
                            }
                        }
                        else if (vcr7 > vdb7)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Expenses7 = vcr7 - vdb7;
                                    break;
                                }
                                else if (Over.Name2 == "صافي حسارة")
                                {
                                    Over.Name1 = "صافي ربح";
                                    Over.Expenses7 = vcr7 - vdb7;
                                    break;
                                }
                            }
                        }
                    }
                    if (ritem >= 8)
                    {
                        if (vdb8 > vcr8)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name2 == "صافي حسارة")
                                {
                                    Over.Income8 = vdb8 - vcr8;
                                    break;
                                }
                                else if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Name2 = "صافي حسارة";
                                    Over.Income8 = vdb8 - vcr8;
                                    break;
                                }
                            }
                        }
                        else if (vcr8 > vdb8)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Expenses8 = vcr8 - vdb8;
                                    break;
                                }
                                else if (Over.Name2 == "صافي حسارة")
                                {
                                    Over.Name1 = "صافي ربح";
                                    Over.Expenses8 = vcr8 - vdb8;
                                    break;
                                }
                            }
                        }
                    }
                    if (ritem >= 9)
                    {
                        if (vdb9 > vcr9)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name2 == "صافي حسارة")
                                {
                                    Over.Income9 = vdb9 - vcr9;
                                    break;
                                }
                                else if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Name2 = "صافي حسارة";
                                    Over.Income9 = vdb9 - vcr9;
                                    break;
                                }
                            }
                        }
                        else if (vcr9 > vdb9)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Expenses9 = vcr9 - vdb9;
                                    break;
                                }
                                else if (Over.Name2 == "صافي حسارة")
                                {
                                    Over.Name1 = "صافي ربح";
                                    Over.Expenses9 = vcr9 - vdb9;
                                    break;
                                }
                            }
                        }
                    }
                    if (ritem >= 10)
                    {
                        if (vdb10 > vcr10)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name2 == "صافي حسارة")
                                {
                                    Over.Income10 = vdb10 - vcr10;
                                    break;
                                }
                                else if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Name2 = "صافي حسارة";
                                    Over.Income10 = vdb10 - vcr10;
                                    break;
                                }
                            }
                        }
                        else if (vcr10 > vdb10)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Expenses10 = vcr10 - vdb10;
                                    break;
                                }
                                else if (Over.Name2 == "صافي حسارة")
                                {
                                    Over.Name1 = "صافي ربح";
                                    Over.Expenses10 = vcr10 - vdb10;
                                    break;
                                }
                            }
                        }
                    }
                    if (ritem >= 11)
                    {
                        if (vdb11 > vcr11)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name2 == "صافي حسارة")
                                {
                                    Over.Income11 = vdb11 - vcr11;
                                    break;
                                }
                                else if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Name2 = "صافي حسارة";
                                    Over.Income11 = vdb11 - vcr11;
                                    break;
                                }
                            }
                        }
                        else if (vcr11 > vdb11)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Expenses11 = vcr11 - vdb11;
                                    break;
                                }
                                else if (Over.Name2 == "صافي حسارة")
                                {
                                    Over.Name1 = "صافي ربح";
                                    Over.Expenses11 = vcr11 - vdb11;
                                    break;
                                }
                            }
                        }
                    }
                    if (ritem >= 12)
                    {
                        if (vdb12 > vcr12)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name2 == "صافي حسارة")
                                {
                                    Over.Income12 = vdb12 - vcr12;
                                    break;
                                }
                                else if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Name2 = "صافي حسارة";
                                    Over.Income12 = vdb12 - vcr12;
                                    break;
                                }
                            }
                        }
                        else if (vcr12 > vdb12)
                        {
                            foreach (vCostCenterResult Over in MyOver)
                            {
                                if (Over.Name1 == "صافي ربح")
                                {
                                    Over.Expenses12 = vcr12 - vdb12;
                                    break;
                                }
                                else if (Over.Name2 == "صافي حسارة")
                                {
                                    Over.Name1 = "صافي ربح";
                                    Over.Expenses12 = vcr12 - vdb12;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    List<Acc> lacc = new List<Acc>();
                    PeriodAcc pa = new PeriodAcc();
                    List<PeriodAcc> lp = new List<PeriodAcc>();
                    if (!ChkPeriod.Checked)
                    {
                        lp = pa.GetPeriod(short.Parse(Session["Branch"].ToString()), txtFDate.Text, txtEDate.Text, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    Acc myacc = new Acc();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["AllACC" + Session["CNN2"].ToString()] == null) Cache.Insert("AllACC" + Session["CNN2"].ToString(), myacc.Getall(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    lacc = (from itm in (List<Acc>)(Cache["AllACC" + Session["CNN2"].ToString()])
                            where getitem(itm)
                            select new Acc
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                FCode = itm.FCode,
                                MCode = itm.MCode,
                                FLevel = itm.FLevel,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                DAcc = ChkPeriod.Checked ? itm.DAcc : 0,
                                CAcc = ChkPeriod.Checked ? itm.CAcc : 0,
                                MDAcc = itm.MDAcc,
                                MCAcc = itm.MCAcc,
                                TDAcc = itm.TDAcc,
                                TCAcc = itm.TCAcc,
                                ODAcc = 0,
                                OCAcc = 0,
                                FDAcc = itm.FDAcc,
                                FCAcc = itm.FCAcc,
                            }).ToList();

                    if (!ChkPeriod.Checked)
                    {
                        foreach (PeriodAcc itm in lp)
                        {
                            if (!string.IsNullOrEmpty(itm.DbCode))
                            {
                                if (!string.IsNullOrEmpty(itm.DbCode) && itm.DbCode != "-1")
                                {
                                    foreach (Acc myAcc in lacc)
                                    {
                                        if (myAcc.Code == itm.DbCode.Substring(0, 1))
                                        {
                                            myAcc.DAcc += itm.Amount;
                                        }
                                        else if (int.Parse(ddlLevel.SelectedValue) > 1 && myAcc.Code == itm.DbCode.Substring(0, 2))
                                        {
                                            myAcc.DAcc += itm.Amount;
                                        }
                                        else if (int.Parse(ddlLevel.SelectedValue) > 2 && myAcc.Code == itm.DbCode.Substring(0, 4))
                                        {
                                            myAcc.DAcc += itm.Amount;
                                        }
                                        else if (int.Parse(ddlLevel.SelectedValue) > 3 && myAcc.Code == itm.DbCode.Substring(0, 6))
                                        {
                                            myAcc.DAcc += itm.Amount;
                                        }
                                        else if (int.Parse(ddlLevel.SelectedValue) > 4 && myAcc.Code == itm.DbCode)
                                        {
                                            myAcc.DAcc += itm.Amount;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (Acc myAcc in lacc)
                                {
                                    if (!string.IsNullOrEmpty(itm.CrCode) && itm.CrCode != "-1")
                                    {
                                        if (myAcc.Code == itm.CrCode.Substring(0, 1))
                                        {
                                            myAcc.CAcc += itm.Amount;
                                        }
                                        else if (int.Parse(ddlLevel.SelectedValue) > 1 && myAcc.Code == itm.CrCode.Substring(0, 2))
                                        {
                                            myAcc.CAcc += itm.Amount;
                                        }
                                        else if (int.Parse(ddlLevel.SelectedValue) > 2 && myAcc.Code == itm.CrCode.Substring(0, 4))
                                        {
                                            myAcc.CAcc += itm.Amount;
                                        }
                                        else if (int.Parse(ddlLevel.SelectedValue) > 3 && myAcc.Code == itm.CrCode.Substring(0, 6))
                                        {
                                            myAcc.CAcc += itm.Amount;
                                        }
                                        else if (int.Parse(ddlLevel.SelectedValue) > 4 && myAcc.Code == itm.CrCode)
                                        {
                                            myAcc.CAcc += itm.Amount;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    double vcr = 0, vdb = 0;
                    foreach (Acc myAcc in lacc)
                    {
                        if (myAcc.Code.StartsWith("3"))
                        {
                            if (myAcc.DAcc - myAcc.CAcc != 0)
                            {
                                MyOver.Add(new vCostCenterResult
                                {
                                    Code = myAcc.Code,
                                    Name1 = myAcc.Name1,
                                    Expenses1 = myAcc.DAcc - myAcc.CAcc
                                });
                                vdb += (double)(myAcc.DAcc - myAcc.CAcc);
                            }
                        }
                        else if (myAcc.Code.StartsWith("4"))
                        {
                            if (myAcc.DAcc - myAcc.CAcc != 0)
                            {
                                bool vfound = false;
                                foreach (vCostCenterResult itm in MyOver)
                                {

                                    if (string.IsNullOrEmpty(itm.Code2))
                                    {
                                        vfound = true;
                                        itm.Code2 = myAcc.Code;
                                        itm.Name2 = myAcc.Name1;
                                        itm.Income1 = (myAcc.DAcc - myAcc.CAcc) * -1;
                                        break;
                                    }
                                }
                                if (!vfound)
                                {
                                    MyOver.Add(new vCostCenterResult
                                    {
                                        Code2 = myAcc.Code,
                                        Name2 = myAcc.Name1,
                                        Income1 = (myAcc.DAcc - myAcc.CAcc) * -1
                                    });
                                }
                                vcr += (double)((myAcc.DAcc - myAcc.CAcc) * -1);
                            }
                        }

                    }
                    if (vdb > vcr)
                    {
                        MyOver.Add(new vCostCenterResult
                        {
                            Code2 = "",
                            Name2 = "صافي حسارة",
                            Income1 = vdb - vcr
                        });

                    }
                    else if (vcr > vdb)
                    {
                        MyOver.Add(new vCostCenterResult
                            {
                                Code = "",
                                Name1 = "صافي ربح",
                                Expenses1 = vcr - vdb
                            });
                    }
                }
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

        protected string UrlHelper(object Code)
        {
            return ChkPeriod.Checked ? "~/WebCostCenterDetails.aspx?FType=":""; //+ ddlCenter.SelectedValue + "&Center=" + Code + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo : "~/WebCostCenterDetails.aspx?FType=" + ddlCenter.SelectedValue + "&Center=" + Code + "&FDate=" + txtFDate.Text + "&EDate=" + txtEDate.Text + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo;
        }

        public bool getitem(Acc itm)
        {
            return (itm.FLevel == short.Parse(ddlLevel.SelectedValue)) && (itm.FCode.StartsWith("3") || itm.FCode.StartsWith("4"));
        }

        protected void grdCodes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string  s = MyOver[e.Row.RowIndex].Name1;
                string  s1 = MyOver[e.Row.RowIndex].Name2;
                if (s == "صافي ربح")
                {
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        if (cell.UniqueID.EndsWith("$ctl01")) cell.ForeColor = System.Drawing.Color.Green;

                    }
                }
                if (s1 == "صافي حسارة")
                {
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        if (cell.UniqueID.EndsWith("$ctl15")) cell.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        protected void ChkPeriod0_CheckedChanged(object sender, EventArgs e)
        {
            divPeriod.Visible = ChkPeriod0.Checked;
            if (ChkPeriod0.Checked)
            {
                ChkPeriod.Checked = true;
                ChkPeriod_CheckedChanged(sender, e);
            }
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void ChkPeriods_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void txtFDate_TextChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void txtEDate_TextChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

    }
}
