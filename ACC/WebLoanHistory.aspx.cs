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
using System.Reflection;

namespace ACC
{
    public partial class WebLoanHistory : System.Web.UI.Page
    {
        public string[] Amount_Name 
        {
            get
            {
                if (ViewState["Amount_Name"] == null)
                {
                    string[] AmountName = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                    ViewState["Amount_Name"] = AmountName;
                }
                return (string[])ViewState["Amount_Name"];
            }
            set { ViewState["Amount_Name"] = value; }
        }
        public int[] Amount_Year
        {
            get
            {
                if (ViewState["Amount_Year"] == null)
                {
                    int[] AmountYear = { 2014, 2014, 2014, 2014, 2014, 2014, 2014, 2014, 2014, 2014, 2014, 2014, 2015, 2015, 2015, 2015, 2015, 2015, 2015, 2015, 2015, 2015, 2015, 2015 };
                    ViewState["Amount_Year"] = AmountYear;
                }
                return (int[])ViewState["Amount_Year"];
            }
            set { ViewState["Amount_Year"] = value; }
        }
        public int[] Amount_Month
        {
            get
            {
                if (ViewState["Amount_Month"] == null)
                {
                    int[] AmountMonth = { 1,2,3,4,5,6,7,8,9,10,11,12,1,2,3,4,5,6,7,8,9,10,11,12 };
                    ViewState["Amount_Month"] = AmountMonth;
                }
                return (int[])ViewState["Amount_Month"];
            }
            set { ViewState["Amount_Month"] = value; }
        }
        public string TotalDbAmount
        {
            get
            {
                if (ViewState["TotalDbAmount"] == null)
                {
                    ViewState["TotalDbAmount"] = "0.00";
                }
                return ViewState["TotalDbAmount"].ToString();
            }
            set { ViewState["TotalDbAmount"] = value; }
        }
        public string TotalDbAmount1
        {
            get
            {
                if (ViewState["TotalDbAmount1"] == null)
                {
                    ViewState["TotalDbAmount1"] = "0.00";
                }
                return ViewState["TotalDbAmount1"].ToString();
            }
            set { ViewState["TotalDbAmount1"] = value; }
        }
        public string TotalDbAmount2
        {
            get
            {
                if (ViewState["TotalDbAmount2"] == null)
                {
                    ViewState["TotalDbAmount2"] = "0.00";
                }
                return ViewState["TotalDbAmount2"].ToString();
            }
            set { ViewState["TotalDbAmount2"] = value; }
        }
        public string TotalDbAmount3
        {
            get
            {
                if (ViewState["TotalDbAmount3"] == null)
                {
                    ViewState["TotalDbAmount3"] = "0.00";
                }
                return ViewState["TotalDbAmount3"].ToString();
            }
            set { ViewState["TotalDbAmount3"] = value; }
        }
        public string TotalDbAmount4
        {
            get
            {
                if (ViewState["TotalDbAmount4"] == null)
                {
                    ViewState["TotalDbAmount4"] = "0.00";
                }
                return ViewState["TotalDbAmount4"].ToString();
            }
            set { ViewState["TotalDbAmount4"] = value; }
        }
        public string TotalDbAmount5
        {
            get
            {
                if (ViewState["TotalDbAmount5"] == null)
                {
                    ViewState["TotalDbAmount5"] = "0.00";
                }
                return ViewState["TotalDbAmount5"].ToString();
            }
            set { ViewState["TotalDbAmount5"] = value; }
        }
        public string TotalDbAmount6
        {
            get
            {
                if (ViewState["TotalDbAmount6"] == null)
                {
                    ViewState["TotalDbAmount6"] = "0.00";
                }
                return ViewState["TotalDbAmount6"].ToString();
            }
            set { ViewState["TotalDbAmount6"] = value; }
        }
        public string TotalDbAmount7
        {
            get
            {
                if (ViewState["TotalDbAmount7"] == null)
                {
                    ViewState["TotalDbAmount7"] = "0.00";
                }
                return ViewState["TotalDbAmount7"].ToString();
            }
            set { ViewState["TotalDbAmount7"] = value; }
        }
        public string TotalDbAmount8
        {
            get
            {
                if (ViewState["TotalDbAmount8"] == null)
                {
                    ViewState["TotalDbAmount8"] = "0.00";
                }
                return ViewState["TotalDbAmount8"].ToString();
            }
            set { ViewState["TotalDbAmount8"] = value; }
        }
        public string TotalDbAmount9
        {
            get
            {
                if (ViewState["TotalDbAmount9"] == null)
                {
                    ViewState["TotalDbAmount9"] = "0.00";
                }
                return ViewState["TotalDbAmount9"].ToString();
            }
            set { ViewState["TotalDbAmount9"] = value; }
        }
        public string TotalDbAmount10
        {
            get
            {
                if (ViewState["TotalDbAmount10"] == null)
                {
                    ViewState["TotalDbAmount10"] = "0.00";
                }
                return ViewState["TotalDbAmount10"].ToString();
            }
            set { ViewState["TotalDbAmount10"] = value; }
        }
        public string TotalDbAmount11
        {
            get
            {
                if (ViewState["TotalDbAmount11"] == null)
                {
                    ViewState["TotalDbAmount11"] = "0.00";
                }
                return ViewState["TotalDbAmount11"].ToString();
            }
            set { ViewState["TotalDbAmount11"] = value; }
        }
        public string TotalDbAmount12
        {
            get
            {
                if (ViewState["TotalDbAmount12"] == null)
                {
                    ViewState["TotalDbAmount12"] = "0.00";
                }
                return ViewState["TotalDbAmount12"].ToString();
            }
            set { ViewState["TotalDbAmount12"] = value; }
        }
        public string TotalOpenBal
        {
            get
            {
                if (ViewState["TotalOpenBal"] == null)
                {
                    ViewState["TotalOpenBal"] = "0.00";
                }
                return ViewState["TotalOpenBal"].ToString();
            }
            set { ViewState["TotalOpenBal"] = value; }
        }

        public string TotalCrAmount1
        {
            get
            {
                if (ViewState["TotalCrAmount1"] == null)
                {
                    ViewState["TotalCrAmount1"] = "0.00";
                }
                return ViewState["TotalCrAmount1"].ToString();
            }
            set { ViewState["TotalCrAmount1"] = value; }
        }
        public string TotalCrAmount2
        {
            get
            {
                if (ViewState["TotalCrAmount2"] == null)
                {
                    ViewState["TotalCrAmount2"] = "0.00";
                }
                return ViewState["TotalCrAmount2"].ToString();
            }
            set { ViewState["TotalCrAmount2"] = value; }
        }
        public string TotalCrAmount3
        {
            get
            {
                if (ViewState["TotalCrAmount3"] == null)
                {
                    ViewState["TotalCrAmount3"] = "0.00";
                }
                return ViewState["TotalCrAmount3"].ToString();
            }
            set { ViewState["TotalCrAmount3"] = value; }
        }
        public string TotalCrAmount4
        {
            get
            {
                if (ViewState["TotalCrAmount4"] == null)
                {
                    ViewState["TotalCrAmount4"] = "0.00";
                }
                return ViewState["TotalCrAmount4"].ToString();
            }
            set { ViewState["TotalCrAmount4"] = value; }
        }
        public string TotalCrAmount5
        {
            get
            {
                if (ViewState["TotalCrAmount5"] == null)
                {
                    ViewState["TotalCrAmount5"] = "0.00";
                }
                return ViewState["TotalCrAmount5"].ToString();
            }
            set { ViewState["TotalCrAmount5"] = value; }
        }
        public string TotalCrAmount6
        {
            get
            {
                if (ViewState["TotalCrAmount6"] == null)
                {
                    ViewState["TotalCrAmount6"] = "0.00";
                }
                return ViewState["TotalCrAmount6"].ToString();
            }
            set { ViewState["TotalCrAmount6"] = value; }
        }
        public string TotalCrAmount7
        {
            get
            {
                if (ViewState["TotalCrAmount7"] == null)
                {
                    ViewState["TotalCrAmount7"] = "0.00";
                }
                return ViewState["TotalCrAmount7"].ToString();
            }
            set { ViewState["TotalCrAmount7"] = value; }
        }
        public string TotalCrAmount8
        {
            get
            {
                if (ViewState["TotalCrAmount8"] == null)
                {
                    ViewState["TotalCrAmount8"] = "0.00";
                }
                return ViewState["TotalCrAmount8"].ToString();
            }
            set { ViewState["TotalCrAmount8"] = value; }
        }
        public string TotalCrAmount9
        {
            get
            {
                if (ViewState["TotalCrAmount9"] == null)
                {
                    ViewState["TotalCrAmount9"] = "0.00";
                }
                return ViewState["TotalCrAmount9"].ToString();
            }
            set { ViewState["TotalCrAmount9"] = value; }
        }
        public string TotalCrAmount10
        {
            get
            {
                if (ViewState["TotalCrAmount10"] == null)
                {
                    ViewState["TotalCrAmount10"] = "0.00";
                }
                return ViewState["TotalCrAmount10"].ToString();
            }
            set { ViewState["TotalCrAmount10"] = value; }
        }
        public string TotalCrAmount11
        {
            get
            {
                if (ViewState["TotalCrAmount11"] == null)
                {
                    ViewState["TotalCrAmount11"] = "0.00";
                }
                return ViewState["TotalCrAmount11"].ToString();
            }
            set { ViewState["TotalCrAmount11"] = value; }
        }
        public string TotalCrAmount12
        {
            get
            {
                if (ViewState["TotalCrAmount12"] == null)
                {
                    ViewState["TotalCrAmount12"] = "0.00";
                }
                return ViewState["TotalCrAmount12"].ToString();
            }
            set { ViewState["TotalCrAmount12"] = value; }
        }

        public string TotalBal
        {
            get
            {
                if (ViewState["TotalBal"] == null)
                {
                    ViewState["TotalBal"] = "0.00";
                }
                return ViewState["TotalBal"].ToString();
            }
            set { ViewState["TotalBal"] = value; }
        }
        public List<vJv2> MyOver
        {
            get
            {
                if (ViewState["MyOver"] == null)
                {
                    ViewState["MyOver"] = new List<vJv2>();
                }
                return (List<vJv2>)ViewState["MyOver"];
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
                    this.Page.Header.Title = "بيان أعمار الديون";
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

                    Transactions UserTran = new Transactions();
                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                    UserTran.UserName = Session["CurrentUser"].ToString();
                    UserTran.FormName = "الرئيسية";
                    UserTran.FormAction = "اختيار";
                    UserTran.Description = "اختيار عرض بيان أعمار الديون";
                    UserTran.IP = IPNetworking.GetIP4Address();
                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                    vInvError myInv = new vInvError();
                    myInv.VouLoc = "-1";
                    ddlCustomer.DataTextField = "CustomerName";
                    ddlCustomer.DataValueField = "Customer";
                    ddlCustomer.DataSource = myInv.NotPaidGetCustomer(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlCustomer.DataBind();
                    ddlCustomer.Items.Insert(0, new ListItem("--- أختار العميل ---", "-1", true));
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
                grdCodes.DataSource = (from itm in MyOver
                                       orderby itm.Code
                                       select itm).ToList();
                grdCodes.DataBind();
                lblCount.Text = MyOver.Count().ToString();
                MakeSum();
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
                TotalDbAmount12 = "0";
                TotalDbAmount11 = "0";
                TotalDbAmount10 = "0";
                TotalDbAmount9 = "0";
                TotalDbAmount8 = "0";
                TotalDbAmount7 = "0";
                TotalDbAmount6 = "0";
                TotalDbAmount5 = "0";
                TotalDbAmount4 = "0";
                TotalDbAmount3 = "0";
                TotalDbAmount2 = "0";
                TotalDbAmount1 = "0";
                TotalCrAmount12 = "0";
                TotalCrAmount11 = "0";
                TotalCrAmount10 = "0";
                TotalCrAmount9 = "0";
                TotalCrAmount8 = "0";
                TotalCrAmount7 = "0";
                TotalCrAmount6 = "0";
                TotalCrAmount5 = "0";
                TotalCrAmount4 = "0";
                TotalCrAmount3 = "0";
                TotalCrAmount2 = "0";
                TotalCrAmount1 = "0";
                TotalDbAmount = "0";

                if (grdCodes.FooterRow != null)
                {

                    Label lblTotalDbAmount = grdCodes.FooterRow.FindControl("lblTotalDbAmount") as Label;
                    Label lblTotalDbAmount1 = grdCodes.FooterRow.FindControl("lblTotalDbAmount1") as Label;
                    Label lblTotalDbAmount2 = grdCodes.FooterRow.FindControl("lblTotalDbAmount2") as Label;
                    Label lblTotalDbAmount3 = grdCodes.FooterRow.FindControl("lblTotalDbAmount3") as Label;
                    Label lblTotalDbAmount4 = grdCodes.FooterRow.FindControl("lblTotalDbAmount4") as Label;
                    Label lblTotalDbAmount5 = grdCodes.FooterRow.FindControl("lblTotalDbAmount5") as Label;
                    Label lblTotalDbAmount6 = grdCodes.FooterRow.FindControl("lblTotalDbAmount6") as Label;
                    Label lblTotalDbAmount7 = grdCodes.FooterRow.FindControl("lblTotalDbAmount7") as Label;
                    Label lblTotalDbAmount8 = grdCodes.FooterRow.FindControl("lblTotalDbAmount8") as Label;
                    Label lblTotalDbAmount9 = grdCodes.FooterRow.FindControl("lblTotalDbAmount9") as Label;
                    Label lblTotalDbAmount10 = grdCodes.FooterRow.FindControl("lblTotalDbAmount10") as Label;
                    Label lblTotalDbAmount11 = grdCodes.FooterRow.FindControl("lblTotalDbAmount11") as Label;
                    Label lblTotalDbAmount12 = grdCodes.FooterRow.FindControl("lblTotalDbAmount12") as Label;
                    Label lblTotalCrAmount1 = grdCodes.FooterRow.FindControl("lblTotalCrAmount1") as Label;
                    Label lblTotalCrAmount2 = grdCodes.FooterRow.FindControl("lblTotalCrAmount2") as Label;
                    Label lblTotalCrAmount3 = grdCodes.FooterRow.FindControl("lblTotalCrAmount3") as Label;
                    Label lblTotalCrAmount4 = grdCodes.FooterRow.FindControl("lblTotalCrAmount4") as Label;
                    Label lblTotalCrAmount5 = grdCodes.FooterRow.FindControl("lblTotalCrAmount5") as Label;
                    Label lblTotalCrAmount6 = grdCodes.FooterRow.FindControl("lblTotalCrAmount6") as Label;
                    Label lblTotalCrAmount7 = grdCodes.FooterRow.FindControl("lblTotalCrAmount7") as Label;
                    Label lblTotalCrAmount8 = grdCodes.FooterRow.FindControl("lblTotalCrAmount8") as Label;
                    Label lblTotalCrAmount9 = grdCodes.FooterRow.FindControl("lblTotalCrAmount9") as Label;
                    Label lblTotalCrAmount10 = grdCodes.FooterRow.FindControl("lblTotalCrAmount10") as Label;
                    Label lblTotalCrAmount11 = grdCodes.FooterRow.FindControl("lblTotalCrAmount11") as Label;
                    Label lblTotalCrAmount12 = grdCodes.FooterRow.FindControl("lblTotalCrAmount12") as Label;
                    Label lblTotalBal = grdCodes.FooterRow.FindControl("lblTotalBal") as Label;

                    if (lblTotalDbAmount != null)
                    {
                        lblTotalDbAmount.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.DbAmount));
                        TotalDbAmount = lblTotalDbAmount.Text;
                    }
                    if (Amount_Name[0] != "" && lblTotalCrAmount1 != null)
                    {
                        lblTotalCrAmount1.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.CrAmount1));
                        TotalCrAmount1 = lblTotalCrAmount1.Text;
                    }
                    if (Amount_Name[1] != "" && lblTotalCrAmount2 != null)
                    {
                        lblTotalCrAmount2.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.CrAmount2));
                        TotalCrAmount2 = lblTotalCrAmount2.Text;
                    }
                    if (Amount_Name[2] != "" && lblTotalCrAmount3 != null)
                    {
                        lblTotalCrAmount3.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.CrAmount3));
                        TotalCrAmount3 = lblTotalCrAmount3.Text;
                    }
                    if (Amount_Name[3] != "" && lblTotalCrAmount4 != null)
                    {
                        lblTotalCrAmount4.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.CrAmount4));
                        TotalCrAmount4 = lblTotalCrAmount4.Text;
                    }
                    if (Amount_Name[4] != "" && lblTotalCrAmount5 != null)
                    {
                        lblTotalCrAmount5.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.CrAmount5));
                        TotalCrAmount5 = lblTotalCrAmount5.Text;
                    }
                    if (Amount_Name[5] != "" && lblTotalCrAmount6 != null)
                    {
                        lblTotalCrAmount6.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.CrAmount6));
                        TotalCrAmount6 = lblTotalCrAmount6.Text;
                    }
                    if (Amount_Name[6] != "" && lblTotalCrAmount7 != null)
                    {
                        lblTotalCrAmount7.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.CrAmount7));
                        TotalCrAmount7 = lblTotalCrAmount7.Text;
                    }
                    if (Amount_Name[7] != "" && lblTotalCrAmount8 != null)
                    {
                        lblTotalCrAmount8.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.CrAmount8));
                        TotalCrAmount8 = lblTotalCrAmount8.Text;
                    }
                    if (Amount_Name[8] != "" && lblTotalCrAmount9 != null)
                    {
                        lblTotalCrAmount9.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.CrAmount9));
                        TotalCrAmount9 = lblTotalCrAmount9.Text;
                    }
                    if (Amount_Name[9] != "" && lblTotalCrAmount10 != null)
                    {
                        lblTotalCrAmount10.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.CrAmount10));
                        TotalCrAmount10 = lblTotalCrAmount10.Text;
                    }
                    if (Amount_Name[10] != "" && lblTotalCrAmount11 != null)
                    {
                        lblTotalCrAmount11.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.CrAmount11));
                        TotalCrAmount11 = lblTotalCrAmount11.Text;
                    }
                    if (Amount_Name[11] != "" && lblTotalCrAmount12 != null)
                    {
                        lblTotalCrAmount12.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.CrAmount12));
                        TotalCrAmount12 = lblTotalCrAmount12.Text;
                    }

                    if (Amount_Name[12] != "" && lblTotalDbAmount1 != null)
                    {
                        lblTotalDbAmount1.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.DbAmount1));
                        TotalDbAmount1 = lblTotalDbAmount1.Text;
                    }
                    if (Amount_Name[13] != "" && lblTotalDbAmount2 != null)
                    {
                        lblTotalDbAmount2.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.DbAmount2));
                        TotalDbAmount2 = lblTotalDbAmount2.Text;
                    }
                    if (Amount_Name[14] != "" && lblTotalDbAmount3 != null)
                    {
                        lblTotalDbAmount3.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.DbAmount3));
                        TotalDbAmount3 = lblTotalDbAmount3.Text;
                    }
                    if (Amount_Name[15] != "" && lblTotalDbAmount4 != null)
                    {
                        lblTotalDbAmount4.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.DbAmount4));
                        TotalDbAmount4 = lblTotalDbAmount4.Text;
                    }
                    if (Amount_Name[16] != "" && lblTotalDbAmount5 != null)
                    {
                        lblTotalDbAmount5.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.DbAmount5));
                        TotalDbAmount5 = lblTotalDbAmount5.Text;
                    }
                    if (Amount_Name[17] != "" && lblTotalDbAmount6 != null)
                    {
                        lblTotalDbAmount6.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.DbAmount6));
                        TotalDbAmount6 = lblTotalDbAmount6.Text;
                    }
                    if (Amount_Name[18] != "" && lblTotalDbAmount7 != null)
                    {
                        lblTotalDbAmount7.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.DbAmount7));
                        TotalDbAmount7 = lblTotalDbAmount7.Text;
                    }
                    if (Amount_Name[19] != "" && lblTotalDbAmount8 != null)
                    {
                        lblTotalDbAmount8.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.DbAmount8));
                        TotalDbAmount8 = lblTotalDbAmount8.Text;
                    }
                    if (Amount_Name[20] != "" && lblTotalDbAmount9 != null)
                    {
                        lblTotalDbAmount9.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.DbAmount9));
                        TotalDbAmount9 = lblTotalDbAmount9.Text;
                    }
                    if (Amount_Name[21] != "" && lblTotalDbAmount10 != null)
                    {
                        lblTotalDbAmount10.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.DbAmount10));
                        TotalDbAmount10 = lblTotalDbAmount10.Text;
                    }
                    if (Amount_Name[22] != "" && lblTotalDbAmount11 != null)
                    {
                        lblTotalDbAmount11.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.DbAmount11));
                        TotalDbAmount11 = lblTotalDbAmount11.Text;
                    }
                    if (Amount_Name[23] != "" && lblTotalDbAmount12 != null)
                    {
                        lblTotalDbAmount12.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.DbAmount12));
                        TotalDbAmount12 = lblTotalDbAmount12.Text;
                    }
                    if (lblTotalBal != null)
                    {
                        lblTotalBal.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.OpenBal));
                        TotalBal = lblTotalBal.Text;
                    }
                }

                for (int i = 0; i < 28; i++) grdCodes.Columns[i].Visible = true;
                for (int i = 0; i < 24; i++) grdCodes.HeaderRow.Cells[i+3].Text = Amount_Name[i];

                if (moh.StrToDouble(TotalDbAmount12) == 0) grdCodes.Columns[26].Visible = false;
                if (moh.StrToDouble(TotalDbAmount11) == 0) grdCodes.Columns[25].Visible = false;
                if (moh.StrToDouble(TotalDbAmount10) == 0) grdCodes.Columns[24].Visible = false;
                if (moh.StrToDouble(TotalDbAmount9) == 0) grdCodes.Columns[23].Visible = false;
                if (moh.StrToDouble(TotalDbAmount8) == 0) grdCodes.Columns[22].Visible = false;
                if (moh.StrToDouble(TotalDbAmount7) == 0) grdCodes.Columns[21].Visible = false;
                if (moh.StrToDouble(TotalDbAmount6) == 0) grdCodes.Columns[20].Visible = false;
                if (moh.StrToDouble(TotalDbAmount5) == 0) grdCodes.Columns[19].Visible = false;
                if (moh.StrToDouble(TotalDbAmount4) == 0) grdCodes.Columns[18].Visible = false;
                if (moh.StrToDouble(TotalDbAmount3) == 0) grdCodes.Columns[17].Visible = false;
                if (moh.StrToDouble(TotalDbAmount2) == 0) grdCodes.Columns[16].Visible = false;
                if (moh.StrToDouble(TotalDbAmount1) == 0) grdCodes.Columns[15].Visible = false;
                if (moh.StrToDouble(TotalCrAmount12) == 0) grdCodes.Columns[14].Visible = false;
                if (moh.StrToDouble(TotalCrAmount11) == 0) grdCodes.Columns[13].Visible = false;
                if (moh.StrToDouble(TotalCrAmount10) == 0) grdCodes.Columns[12].Visible = false;
                if (moh.StrToDouble(TotalCrAmount9) == 0) grdCodes.Columns[11].Visible = false;
                if (moh.StrToDouble(TotalCrAmount8) == 0) grdCodes.Columns[10].Visible = false;
                if (moh.StrToDouble(TotalCrAmount7) == 0) grdCodes.Columns[9].Visible = false;
                if (moh.StrToDouble(TotalCrAmount6) == 0) grdCodes.Columns[8].Visible = false;
                if (moh.StrToDouble(TotalCrAmount5) == 0) grdCodes.Columns[7].Visible = false;
                if (moh.StrToDouble(TotalCrAmount4) == 0) grdCodes.Columns[6].Visible = false;
                if (moh.StrToDouble(TotalCrAmount3) == 0) grdCodes.Columns[5].Visible = false;
                if (moh.StrToDouble(TotalCrAmount2) == 0) grdCodes.Columns[4].Visible = false;
                if (moh.StrToDouble(TotalCrAmount1) == 0) grdCodes.Columns[3].Visible = false;
                if (moh.StrToDouble(TotalDbAmount) == 0) grdCodes.Columns[2].Visible = false;             
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
                int ColCount = 28;
                if (moh.StrToDouble(TotalDbAmount12) == 0) ColCount--;
                if (moh.StrToDouble(TotalDbAmount11) == 0) ColCount--;
                if (moh.StrToDouble(TotalDbAmount10) == 0) ColCount--;
                if (moh.StrToDouble(TotalDbAmount9) == 0) ColCount--;
                if (moh.StrToDouble(TotalDbAmount8) == 0) ColCount--;
                if (moh.StrToDouble(TotalDbAmount7) == 0) ColCount--;
                if (moh.StrToDouble(TotalDbAmount6) == 0) ColCount--;
                if (moh.StrToDouble(TotalDbAmount5) == 0) ColCount--;
                if (moh.StrToDouble(TotalDbAmount4) == 0) ColCount--;
                if (moh.StrToDouble(TotalDbAmount3) == 0) ColCount--;
                if (moh.StrToDouble(TotalDbAmount2) == 0) ColCount--;
                if (moh.StrToDouble(TotalDbAmount1) == 0) ColCount--;
                if (moh.StrToDouble(TotalCrAmount12) == 0) ColCount--;
                if (moh.StrToDouble(TotalCrAmount11) == 0) ColCount--;
                if (moh.StrToDouble(TotalCrAmount10) == 0) ColCount--;
                if (moh.StrToDouble(TotalCrAmount9) == 0) ColCount--;
                if (moh.StrToDouble(TotalCrAmount8) == 0) ColCount--;
                if (moh.StrToDouble(TotalCrAmount7) == 0) ColCount--;
                if (moh.StrToDouble(TotalCrAmount6) == 0) ColCount--;
                if (moh.StrToDouble(TotalCrAmount5) == 0) ColCount--;
                if (moh.StrToDouble(TotalCrAmount4) == 0) ColCount--;
                if (moh.StrToDouble(TotalCrAmount3) == 0) ColCount--;
                if (moh.StrToDouble(TotalCrAmount2) == 0) ColCount--;
                if (moh.StrToDouble(TotalCrAmount1) == 0) ColCount--;
                if (moh.StrToDouble(TotalDbAmount) == 0) ColCount--;


                float s7 = 7;
                float s8 = 8;
                if (ColCount == 28)      { s7 = 7; s8 = 8; }
                else if (ColCount == 27) { s7 = 7; s8 = 8; }
                else if (ColCount == 26) { s7 = 7; s8 = 8; }
                else if (ColCount == 25) { s7 = 7; s8 = 8; }
                else if (ColCount == 24) { s7 = 7; s8 = 8; }
                else if (ColCount == 23) { s7 = 7; s8 = 8; }
                else if (ColCount == 22) { s7 = 7; s8 = 8; }
                else if (ColCount == 21) { s7 = 8; s8 = 9; }
                else if (ColCount == 20) { s7 = 8; s8 = 9; }
                else if (ColCount == 19) { s7 = 8; s8 = 9; }
                else if (ColCount == 18) { s7 = 8; s8 = 9; }
                else if (ColCount == 17) { s7 = 8; s8 = 9; }
                else if (ColCount == 16) { s7 = 8; s8 = 9; }
                else if (ColCount == 15) { s7 = 8; s8 = 9; }
                else if (ColCount == 14) { s7 = 9; s8 = 10; }
                else if (ColCount == 13) { s7 = 9; s8 = 10; }
                else if (ColCount == 12) { s7 = 9; s8 = 10; }
                else if (ColCount == 11) { s7 = 9; s8 = 10; }
                else if (ColCount == 10) { s7 = 9; s8 = 10; }
                else if (ColCount == 9)  { s7 = 9; s8 = 10; }
                else if (ColCount == 8)  { s7 = 9; s8 = 10; }
                else if (ColCount == 7)  { s7 = 10; s8 = 11; }
                else if (ColCount == 6)  { s7 = 10; s8 = 11; }
                else if (ColCount == 5)  { s7 = 10; s8 = 11; }
                else if (ColCount == 4)  { s7 = 10; s8 = 11; }
                else if (ColCount == 3)  { s7 = 10; s8 = 11; }


                iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), -100, -100, 80, 50);
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
                page.ColCount = ColCount;
                CostCenter myCost = new CostCenter();
                myCost.Branch = 1;
                if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCost.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myCost.Code = Request.QueryString["AreaNo"] != null ? Request.QueryString["AreaNo"].ToString() : Session["AreaNo"].ToString();
                myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                          where citm.Code == myCost.Code
                          select citm).FirstOrDefault();
                page.vStr4 = "الإدارة المالية";
                page.vStr1 = ChkPeriod.Checked ? "جميع الفترات" : "من " + txtFDate.Text + " إلى " + txtEDate.Text;
                page.vStr2 = ChkCustomer.Checked ? "جميع العملاء" : ddlCustomer.SelectedIndex == 0 ? "لا يوجد" : ddlCustomer.SelectedItem.Text;
                page.vStr3 = ChkSite.Checked ? "جميع الفروع" : "لا يوجد";
                page.DbAmount = TotalDbAmount;
                page.DbAmount1 = TotalDbAmount1;
                page.DbAmount2 = TotalDbAmount2;
                page.DbAmount3 = TotalDbAmount3;
                page.DbAmount4 = TotalDbAmount4;
                page.DbAmount5 = TotalDbAmount5;
                page.DbAmount6 = TotalDbAmount6;
                page.DbAmount7 = TotalDbAmount7;
                page.DbAmount8 = TotalDbAmount8;
                page.DbAmount9 = TotalDbAmount9;
                page.DbAmount10 = TotalDbAmount10;
                page.DbAmount11 = TotalDbAmount11;
                page.DbAmount12 = TotalDbAmount12;
                page.CrAmount1 = TotalCrAmount1;
                page.CrAmount2 = TotalCrAmount2;
                page.CrAmount3 = TotalCrAmount3;
                page.CrAmount4 = TotalCrAmount4;
                page.CrAmount5 = TotalCrAmount5;
                page.CrAmount6 = TotalCrAmount6;
                page.CrAmount7 = TotalCrAmount7;
                page.CrAmount8 = TotalCrAmount8;
                page.CrAmount9 = TotalCrAmount9;
                page.CrAmount10 = TotalCrAmount10;
                page.CrAmount11 = TotalCrAmount11;
                page.CrAmount12 = TotalCrAmount12;
                page.AmName = Amount_Name;
 
                 
                //-------------------------------------------------------------------------------------------                    
                document.Open();
                //-------------------------------------------------------------------------------------------                    

                //string arialunicodepath = Server.MapPath("Fonts") + @"\arial.ttf";
                string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont0 = new iTextSharp.text.Font(nationalBase, s7, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, s8, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font nationalTextFont2 = new iTextSharp.text.Font(nationalBase, s8, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font nationalTextFont14 = new iTextSharp.text.Font(nationalBase, 9f, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font nationalTextFont16 = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);
                //-------------------------------------------------------------------------------------------                    
                //document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                //-------------------------------------------------------------------------------------------                    
                var cols = new[] { 1300 };
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
                /*
                cell2.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell2);

                cell2.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                if (ChkPeriod.Checked)
                {
                    cell2.Phrase = new iTextSharp.text.Phrase(" بيان أعمار الديون جميع الفترات ", nationalTextFont16);
                }
                else
                {
                    cell2.Phrase = new iTextSharp.text.Phrase(" بيان أعمار الديون عن الفترة من  " + txtFDate.Text + " إلى " + txtEDate.Text, nationalTextFont16);
                }
                table.AddCell(cell2);

                document.Add(table);
                //-------------------------------------------------------------------------------------------
                document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                //-------------------------------------------------------------------------------------------
                /*
                cols = new[] { 250, 150, 250, 150, 250, 150 };
                table = new PdfPTable(6);
                table.TotalWidth = document.PageSize.Width; //100f;
                table.SetWidths(cols);
                cell2 = new PdfPCell();
                cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell2.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell2.Phrase = new iTextSharp.text.Phrase("فرع الاصدار", nationalTextFont);
                table.AddCell(cell2);

                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell2.Phrase = new iTextSharp.text.Phrase(ddlBranch.SelectedItem.Text, nationalTextFont);
                table.AddCell(cell2);

                cell2.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell2.Phrase = new iTextSharp.text.Phrase("فرع التحصيل", nationalTextFont);
                table.AddCell(cell2);

                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell2.Phrase = new iTextSharp.text.Phrase(ChkSite.Checked ? "جميع الفروع" : ddlSite.SelectedItem.Text, nationalTextFont);
                table.AddCell(cell2);

                cell2.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell2.Phrase = new iTextSharp.text.Phrase("العميل", nationalTextFont);
                table.AddCell(cell2);

                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell2.Phrase = new iTextSharp.text.Phrase(ChkCustomer.Checked ? "جميع العملاء" : ddlCustomer.SelectedItem.Text, nationalTextFont);
                table.AddCell(cell2);
                document.Add(table);
               
                //-------------------------------------------------------------------------------------------
                document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                //-------------------------------------------------------------------------------------------
                 */
                if(ColCount == 28)      cols = new[] { 60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,115,65};
                else if(ColCount == 27) cols = new[] { 60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,115,65};
                else if(ColCount == 26) cols = new[] { 60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,115,65};
                else if(ColCount == 25) cols = new[] { 60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,115,65};
                else if(ColCount == 24) cols = new[] { 60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,115,65};
                else if(ColCount == 23) cols = new[] { 60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,115,65};
                else if(ColCount == 22) cols = new[] { 60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,115,65};
                else if(ColCount == 21) cols = new[] { 60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,115,65};
                else if(ColCount == 20) cols = new[] { 60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,115,65};
                else if(ColCount == 19) cols = new[] { 60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,115,65};
                else if(ColCount == 18) cols = new[] { 60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,115,65};
                else if(ColCount == 17) cols = new[] { 60,60,60,60,60,60,60,60,60,60,60,60,60,60,60,115,65};
                else if(ColCount == 16) cols = new[] { 60,60,60,60,60,60,60,60,60,60,60,60,60,60,115,65};
                else if(ColCount == 15) cols = new[] { 60,60,60,60,60,60,60,60,60,60,60,60,60,115,65};
                else if(ColCount == 14) cols = new[] { 60,60,60,60,60,60,60,60,60,60,60,60,115,65};
                else if(ColCount == 13) cols = new[] { 60,60,60,60,60,60,60,60,60,60,60,115,65};
                else if(ColCount == 12) cols = new[] { 60,60,60,60,60,60,60,60,60,60,115,65};
                else if(ColCount == 11) cols = new[] { 60,60,60,60,60,60,60,60,60,115,65};
                else if(ColCount == 10) cols = new[] { 60,60,60,60,60,60,60,60,115,65};
                else if(ColCount == 9)  cols = new[] { 60,60,60,60,60,60,60,115,65};
                else if(ColCount == 8)  cols = new[] { 60,60,60,60,60,60,115,65};
                else if(ColCount == 7)  cols = new[] { 60,60,60,60,60,115,65};
                else if(ColCount == 6)  cols = new[] { 60,60,60,60,115,65};
                else if(ColCount == 5)  cols = new[] { 60,60,60,115,65};
                else if(ColCount == 4)  cols = new[] { 60,60,115,65};
                else if(ColCount == 3)  cols = new[] { 60,115,65};

                
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
                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;

                if (MyOver != null && MyOver.Count > 0)
                {
                    foreach (vJv2 inv in (from itm in MyOver
                                          orderby itm.Code
                                          select itm).ToList())
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(inv.Code, nationalTextFont0);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.AccName1, nationalTextFont0);
                        table.AddCell(cell);

                        if (moh.StrToDouble(TotalDbAmount) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.DbAmount), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalCrAmount1) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.CrAmount1), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalCrAmount2) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.CrAmount2), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalCrAmount3) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.CrAmount3), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalCrAmount4) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.CrAmount4), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalCrAmount5) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.CrAmount5), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalCrAmount6) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.CrAmount6), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalCrAmount7) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.CrAmount7), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalCrAmount8) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.CrAmount8), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalCrAmount9) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.CrAmount9), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalCrAmount10) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.CrAmount10), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalCrAmount11) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.CrAmount11), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalCrAmount12) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.CrAmount12), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalDbAmount1) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.DbAmount1), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalDbAmount2) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.DbAmount2), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalDbAmount3) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.DbAmount3), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalDbAmount4) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.DbAmount4), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalDbAmount5) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.DbAmount5), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalDbAmount6) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.DbAmount6), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalDbAmount7) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.DbAmount7), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalDbAmount8) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.DbAmount8), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalDbAmount9) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.DbAmount9), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalDbAmount10) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.DbAmount10), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalDbAmount11) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.DbAmount11), nationalTextFont);
                            table.AddCell(cell);
                        }

                        if (moh.StrToDouble(TotalDbAmount12) != 0)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.DbAmount12), nationalTextFont);
                            table.AddCell(cell);
                        }

                        cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.OpenBal), nationalTextFont);
                        table.AddCell(cell);

                    }
                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase("الاجمالي", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    if (moh.StrToDouble(TotalDbAmount) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalDbAmount, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (moh.StrToDouble(TotalCrAmount1) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalCrAmount1, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (moh.StrToDouble(TotalCrAmount2) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalCrAmount2, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalCrAmount3) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalCrAmount3, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalCrAmount4) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalCrAmount4, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalCrAmount5) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalCrAmount5, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalCrAmount6) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalCrAmount6, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalCrAmount7) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalCrAmount7, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalCrAmount8) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalCrAmount8, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalCrAmount9) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalCrAmount9, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalCrAmount10) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalCrAmount10, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalCrAmount11) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalCrAmount11, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalCrAmount12) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalCrAmount12, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalDbAmount1) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalDbAmount1, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalDbAmount2) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalDbAmount2, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalDbAmount3) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalDbAmount3, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalDbAmount4) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalDbAmount4, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalDbAmount5) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalDbAmount5, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalDbAmount6) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalDbAmount6, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalDbAmount7) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalDbAmount7, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalDbAmount8) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalDbAmount8, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalDbAmount9) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalDbAmount9, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalDbAmount10) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalDbAmount10, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalDbAmount11) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalDbAmount11, nationalTextFont);
                        table.AddCell(cell);
                    }
                    if (moh.StrToDouble(TotalDbAmount12) != 0)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(TotalDbAmount12, nationalTextFont);
                        table.AddCell(cell);
                    }
                    cell.Phrase = new iTextSharp.text.Phrase(TotalBal, nationalTextFont0);
                    table.AddCell(cell);
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
            public string vStr1, vStr2, vStr3, vStr4,vStr5, UserName, PageNo, vCompanyName;
            public string DbAmount,DbAmount1,DbAmount2,DbAmount3,DbAmount4,DbAmount5,DbAmount6,DbAmount7,DbAmount8,DbAmount9,DbAmount10,DbAmount11,DbAmount12;
            public string CrAmount1,CrAmount2,CrAmount3,CrAmount4,CrAmount5,CrAmount6,CrAmount7,CrAmount8,CrAmount9,CrAmount10,CrAmount11,CrAmount12;
            public string[] AmName;
            public int ColCount;
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
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 18f, iTextSharp.text.Font.NORMAL);


                //I use a PdfPtable with 1 column to position my header where I want it
                PdfPTable headerTbl = new PdfPTable(3);
                var cols2 = new[] { 300, 600, 300 };
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
                cell2.Phrase = new iTextSharp.text.Phrase("بيان أعمار الديون", nationalTextFont);
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

                float s8 = 8;
                if (ColCount == 28) { s8 = 8; }
                else if (ColCount == 27) { s8 = 8; }
                else if (ColCount == 26) { s8 = 8; }
                else if (ColCount == 25) { s8 = 8; }
                else if (ColCount == 24) { s8 = 8; }
                else if (ColCount == 23) { s8 = 8; }
                else if (ColCount == 22) { s8 = 8; }
                else if (ColCount == 21) { s8 = 9; }
                else if (ColCount == 20) { s8 = 9; }
                else if (ColCount == 19) { s8 = 9; }
                else if (ColCount == 18) { s8 = 9; }
                else if (ColCount == 17) { s8 = 9; }
                else if (ColCount == 16) { s8 = 9; }
                else if (ColCount == 15) { s8 = 9; }
                else if (ColCount == 14) { s8 = 10; }
                else if (ColCount == 13) { s8 = 10; }
                else if (ColCount == 12) { s8 = 10; }
                else if (ColCount == 11) { s8 = 10; }
                else if (ColCount == 10) { s8 = 10; }
                else if (ColCount == 9)  { s8 = 10; }
                else if (ColCount == 8)  { s8 = 10; }
                else if (ColCount == 7)  { s8 = 11; }
                else if (ColCount == 6)  { s8 = 11; }
                else if (ColCount == 5)  { s8 = 11; }
                else if (ColCount == 4)  { s8 = 11; }
                else if (ColCount == 3)  { s8 = 11; }

                arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                //BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont2 = new iTextSharp.text.Font(nationalBase, s8, iTextSharp.text.Font.NORMAL);


                var cols = new[] { 150, 100, 200, 100, 200, 100 };
                PdfPTable table = new PdfPTable(6);
                table.TotalWidth = doc.PageSize.Width; //100f;
                table.SetWidths(cols);
                PdfPCell cell = new PdfPCell();
                //cell.FixedHeight = 20f;

                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.Phrase = new iTextSharp.text.Phrase("الفترة", nationalTextFont2);
                table.AddCell(cell);

                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell.Phrase = new iTextSharp.text.Phrase(vStr1, nationalTextFont2);
                table.AddCell(cell);

                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell.Phrase = new iTextSharp.text.Phrase("العملاء", nationalTextFont2);
                table.AddCell(cell);

                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell.Phrase = new iTextSharp.text.Phrase(vStr2, nationalTextFont2);
                table.AddCell(cell);

                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell.Phrase = new iTextSharp.text.Phrase("الفروع", nationalTextFont2);
                table.AddCell(cell);

                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell.Phrase = new iTextSharp.text.Phrase(vStr3, nationalTextFont2);
                table.AddCell(cell);

                doc.Add(table);

                doc.Add(new iTextSharp.text.Phrase("            ", nationalTextFont2));

                if (ColCount == 28) cols = new[] { 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 27) cols = new[] { 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 26) cols = new[] { 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 25) cols = new[] { 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 24) cols = new[] { 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 23) cols = new[] { 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 22) cols = new[] { 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 21) cols = new[] { 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 20) cols = new[] { 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 19) cols = new[] { 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 18) cols = new[] { 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 17) cols = new[] { 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 16) cols = new[] { 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 15) cols = new[] { 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 14) cols = new[] { 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 13) cols = new[] { 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 12) cols = new[] { 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 11) cols = new[] { 60, 60, 60, 60, 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 10) cols = new[] { 60, 60, 60, 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 9) cols = new[] { 60, 60, 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 8) cols = new[] { 60, 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 7) cols = new[] { 60, 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 6) cols = new[] { 60, 60, 60, 60, 115, 65 };
                else if (ColCount == 5) cols = new[] { 60, 60, 60, 115, 65 };
                else if (ColCount == 4) cols = new[] { 60, 60, 115, 65 };
                else if (ColCount == 3) cols = new[] { 60, 115, 65 };



                table = new PdfPTable(ColCount);
                table.TotalWidth = doc.PageSize.Width; //100f;
                table.SetWidths(cols);
                cell = new PdfPCell();
                //cell.FixedHeight = 20f;

                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.Phrase = new iTextSharp.text.Phrase("كود", nationalTextFont2);
                table.AddCell(cell);
                
                cell.Phrase = new iTextSharp.text.Phrase("الاسم", nationalTextFont2);
                table.AddCell(cell);
                if (moh.StrToDouble(DbAmount) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase("أول المدة", nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(CrAmount1) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[0], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(CrAmount2) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[1], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(CrAmount3) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[2], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(CrAmount4) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[3], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(CrAmount5) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[4], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(CrAmount6) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[5], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(CrAmount7) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[6], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(CrAmount8) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[7], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(CrAmount9) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[8], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(CrAmount10) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[9], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(CrAmount11) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[10], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(CrAmount12) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[11], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(DbAmount1) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[12], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(DbAmount2) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[13], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(DbAmount3) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[14], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(DbAmount4) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[15], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(DbAmount5) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[16], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(DbAmount6) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[17], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(DbAmount7) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[18], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(DbAmount8) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[19], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(DbAmount9) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[20], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(DbAmount10) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[21], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(DbAmount11) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[22], nationalTextFont2);
                    table.AddCell(cell);
                }
                if (moh.StrToDouble(DbAmount12) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(AmName[23], nationalTextFont2);
                    table.AddCell(cell);
                }
                cell.Phrase = new iTextSharp.text.Phrase("الرصيد", nationalTextFont2);
                table.AddCell(cell);               
                headerTbl.WriteSelectedRows(0, -1, -1, (doc.PageSize.Height - 20), writer.DirectContent);
                doc.Add(table);
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
              //  LoadCodesData();
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

            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void BtnProcess_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                grdCodes.DataSource = null;
                grdCodes.DataBind();

                for (int i = 0; i < 24; i++) Amount_Name[i] = "";
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

                    TimeSpan ts = DateTime.Parse(txtEDate.Text).Subtract(DateTime.Parse(txtFDate.Text));
                    if (ts.Days > (365 + 366))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الفترة تزيد عن أقصى  مدة وهي 24 شهر";
                        txtEDate.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }


                    if (DateTime.Parse(txtFDate.Text) < DateTime.Parse("01/01/2014"))
                    {
                        DateTime vDate = DateTime.Parse("01/01/2014");
                        for (int i = 0; i < 24; i++)
                        {
                            Amount_Name[i] = moh.MonthName[vDate.Month-1] + " " + vDate.Year;
                            Amount_Year[i] = vDate.Year;
                            Amount_Month[i] = vDate.Month;
                            vDate = vDate.AddMonths(1);
                            if (vDate > DateTime.Parse(txtEDate.Text)) break;
                        }
                    }
                    else
                    {
                        DateTime vDate = DateTime.Parse(txtFDate.Text);
                        for (int i = 0; i < 24; i++)
                        {
                            Amount_Name[i] = moh.MonthName[vDate.Month-1] + " " + vDate.Year;
                            Amount_Year[i] = vDate.Year;
                            Amount_Month[i] = vDate.Month;
                            vDate = vDate.AddMonths(1);
                            if (vDate > DateTime.Parse(txtEDate.Text)) break;
                        }
                    }
                }
                else
                {
                    if (moh.Nows().AddMonths(-24) < DateTime.Parse("01/01/2014"))
                    {
                        DateTime vDate = DateTime.Parse("01/01/2014");
                        for (int i = 0; i < 24; i++)
                        {
                            Amount_Name[i] = moh.MonthName[vDate.Month-1] + " " + vDate.Year;
                            Amount_Year[i] = vDate.Year;
                            Amount_Month[i] = vDate.Month;
                            vDate = vDate.AddMonths(1);
                        }
                    }
                    else
                    {
                        DateTime vDate = moh.Nows().AddMonths(-24);
                        for (int i = 0; i < 24; i++)                        
                        {
                            Amount_Name[i] = moh.MonthName[vDate.Month-1] + " " + vDate.Year;
                            Amount_Year[i] = vDate.Year;
                            Amount_Month[i] = vDate.Month;
                            vDate = vDate.AddMonths(1);
                        }
                    }
                    txtFDate.Text = "";
                    txtEDate.Text = "";
                }

                lblCount.Text = "";
                MyOver.Clear();
                vInvError myInv = new vInvError();
                myInv.VouLoc = "-1";
                myInv.Site = "-1";
                myInv.Customer = "-1";
                int iCount = 0;
                foreach (vInvError itm in myInv.NotPaidGetAll2(txtFDate.Text, txtEDate.Text, true, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    if (!ChkSite.Checked)
                    {
                        if (itm.SiteAmount != 0) continue;
                    }
                    if (!ChkCustomer.Checked)
                    {
                        if (ddlCustomer.SelectedIndex == 0)
                        {
                            if(itm.LowAmount != 0) continue;
                        }
                        else
                        {
                            if (itm.Customer != ddlCustomer.SelectedValue) continue;
                        }
                    }
                    double am = 0;
                    if (itm.LowAmount != 0)
                    {
                        iCount = MyOver.FindIndex(p => p.Code == itm.Customer);
                        if (iCount > -1)
                        {
                            if ((ChkPeriod.Checked && DateTime.Parse(itm.GDate) < DateTime.Parse("01/01/2014")) || (!ChkPeriod.Checked && DateTime.Parse(itm.GDate) < DateTime.Parse(txtFDate.Text)))
                            {
                                MyOver[iCount].DbAmount += itm.LowAmount;
                            }
                            else
                            {
                                for (int i = 0; i < 24; i++)
                                {
                                    if (Amount_Name[i]!="" && DateTime.Parse(itm.GDate).Year == Amount_Year[i] && DateTime.Parse(itm.GDate).Month == Amount_Month[i])
                                    {
                                        if (i < 12)
                                        {
                                            PropertyInfo propertyInfo = typeof(vJv2).GetProperty("CrAmount" + (i + 1).ToString());
                                            am = (double)propertyInfo.GetValue(MyOver[iCount], null);
                                            propertyInfo.SetValue(MyOver[iCount], (am + itm.LowAmount), null);

                                            string am0 = "";
                                            PropertyInfo propertyInfo2 = typeof(vJv2).GetProperty("Cr" + (i + 1).ToString());
                                            am0 = (string)propertyInfo2.GetValue(MyOver[iCount], null);
                                            propertyInfo2.SetValue(MyOver[iCount], (am0 + "\n" + itm.InvNo + "\t" + itm.GDate+ "\t" + string.Format("{0:N2}", itm.LowAmount)), null);
                                        }
                                        else
                                        {
                                            PropertyInfo propertyInfo = typeof(vJv2).GetProperty("DbAmount" + (i + 1 - 12).ToString());
                                            am = (double)propertyInfo.GetValue(MyOver[iCount], null);
                                            propertyInfo.SetValue(MyOver[iCount], (am + itm.LowAmount), null);

                                            string am0 = "";
                                            PropertyInfo propertyInfo2 = typeof(vJv2).GetProperty("Db" + (i + 1 - 12).ToString());
                                            am0 = (string)propertyInfo2.GetValue(MyOver[iCount], null);
                                            propertyInfo2.SetValue(MyOver[iCount], (am0 + "\n" + itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount)), null);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MyOver.Add(new vJv2
                            {
                                Code = itm.Customer,
                                AccName1 = itm.CustomerName,
                                AccName2 = itm.CustomerName,
                                DbAmount = ((ChkPeriod.Checked && DateTime.Parse(itm.GDate) < DateTime.Parse("01/01/2014"))
                                                || (!ChkPeriod.Checked && DateTime.Parse(itm.GDate) < DateTime.Parse(txtFDate.Text)) ? itm.LowAmount : 0),
                                CrAmount1 = (Amount_Name[0] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[0] && DateTime.Parse(itm.GDate).Month == Amount_Month[0] ? itm.LowAmount : 0),
                                CrAmount2 = (Amount_Name[1] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[1] && DateTime.Parse(itm.GDate).Month == Amount_Month[1] ? itm.LowAmount : 0),
                                CrAmount3 = (Amount_Name[2] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[2] && DateTime.Parse(itm.GDate).Month == Amount_Month[2] ? itm.LowAmount : 0),
                                CrAmount4 = (Amount_Name[3] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[3] && DateTime.Parse(itm.GDate).Month == Amount_Month[3] ? itm.LowAmount : 0),
                                CrAmount5 = (Amount_Name[4] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[4] && DateTime.Parse(itm.GDate).Month == Amount_Month[4] ? itm.LowAmount : 0),
                                CrAmount6 = (Amount_Name[5] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[5] && DateTime.Parse(itm.GDate).Month == Amount_Month[5] ? itm.LowAmount : 0),
                                CrAmount7 = (Amount_Name[6] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[6] && DateTime.Parse(itm.GDate).Month == Amount_Month[6] ? itm.LowAmount : 0),
                                CrAmount8 = (Amount_Name[7] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[7] && DateTime.Parse(itm.GDate).Month == Amount_Month[7] ? itm.LowAmount : 0),
                                CrAmount9 = (Amount_Name[8] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[8] && DateTime.Parse(itm.GDate).Month == Amount_Month[8] ? itm.LowAmount : 0),
                                CrAmount10 = (Amount_Name[9] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[9] && DateTime.Parse(itm.GDate).Month == Amount_Month[9] ? itm.LowAmount : 0),
                                CrAmount11 = (Amount_Name[10] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[10] && DateTime.Parse(itm.GDate).Month == Amount_Month[10] ? itm.LowAmount : 0),
                                CrAmount12 = (Amount_Name[11] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[11] && DateTime.Parse(itm.GDate).Month == Amount_Month[11] ? itm.LowAmount : 0),
                                DbAmount1 = (Amount_Name[12] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[12] && DateTime.Parse(itm.GDate).Month == Amount_Month[12] ? itm.LowAmount : 0),
                                DbAmount2 = (Amount_Name[13] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[13] && DateTime.Parse(itm.GDate).Month == Amount_Month[13] ? itm.LowAmount : 0),
                                DbAmount3 = (Amount_Name[14] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[14] && DateTime.Parse(itm.GDate).Month == Amount_Month[14] ? itm.LowAmount : 0),
                                DbAmount4 = (Amount_Name[15] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[15] && DateTime.Parse(itm.GDate).Month == Amount_Month[15] ? itm.LowAmount : 0),
                                DbAmount5 = (Amount_Name[16] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[16] && DateTime.Parse(itm.GDate).Month == Amount_Month[16] ? itm.LowAmount : 0),
                                DbAmount6 = (Amount_Name[17] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[17] && DateTime.Parse(itm.GDate).Month == Amount_Month[17] ? itm.LowAmount : 0),
                                DbAmount7 = (Amount_Name[18] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[18] && DateTime.Parse(itm.GDate).Month == Amount_Month[18] ? itm.LowAmount : 0),
                                DbAmount8 = (Amount_Name[19] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[19] && DateTime.Parse(itm.GDate).Month == Amount_Month[19] ? itm.LowAmount : 0),
                                DbAmount9 = (Amount_Name[20] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[20] && DateTime.Parse(itm.GDate).Month == Amount_Month[20] ? itm.LowAmount : 0),
                                DbAmount10 = (Amount_Name[21] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[21] && DateTime.Parse(itm.GDate).Month == Amount_Month[21] ? itm.LowAmount : 0),
                                DbAmount11 = (Amount_Name[22] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[22] && DateTime.Parse(itm.GDate).Month == Amount_Month[22] ? itm.LowAmount : 0),
                                DbAmount12 = (Amount_Name[23] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[23] && DateTime.Parse(itm.GDate).Month == Amount_Month[23] ? itm.LowAmount : 0),
                                Cr1 = (Amount_Name[0] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[0] && DateTime.Parse(itm.GDate).Month == Amount_Month[0] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Cr2 = (Amount_Name[1] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[1] && DateTime.Parse(itm.GDate).Month == Amount_Month[1] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Cr3 = (Amount_Name[2] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[2] && DateTime.Parse(itm.GDate).Month == Amount_Month[2] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Cr4 = (Amount_Name[3] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[3] && DateTime.Parse(itm.GDate).Month == Amount_Month[3] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Cr5 = (Amount_Name[4] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[4] && DateTime.Parse(itm.GDate).Month == Amount_Month[4] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Cr6 = (Amount_Name[5] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[5] && DateTime.Parse(itm.GDate).Month == Amount_Month[5] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Cr7 = (Amount_Name[6] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[6] && DateTime.Parse(itm.GDate).Month == Amount_Month[6] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Cr8 = (Amount_Name[7] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[7] && DateTime.Parse(itm.GDate).Month == Amount_Month[7] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Cr9 = (Amount_Name[8] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[8] && DateTime.Parse(itm.GDate).Month == Amount_Month[8] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Cr10 = (Amount_Name[9] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[9] && DateTime.Parse(itm.GDate).Month == Amount_Month[9] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Cr11 = (Amount_Name[10] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[10] && DateTime.Parse(itm.GDate).Month == Amount_Month[10] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Cr12 = (Amount_Name[11] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[11] && DateTime.Parse(itm.GDate).Month == Amount_Month[11] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Db1 = (Amount_Name[12] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[12] && DateTime.Parse(itm.GDate).Month == Amount_Month[12] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Db2 = (Amount_Name[13] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[13] && DateTime.Parse(itm.GDate).Month == Amount_Month[13] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Db3 = (Amount_Name[14] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[14] && DateTime.Parse(itm.GDate).Month == Amount_Month[14] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Db4 = (Amount_Name[15] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[15] && DateTime.Parse(itm.GDate).Month == Amount_Month[15] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Db5 = (Amount_Name[16] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[16] && DateTime.Parse(itm.GDate).Month == Amount_Month[16] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Db6 = (Amount_Name[17] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[17] && DateTime.Parse(itm.GDate).Month == Amount_Month[17] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Db7 = (Amount_Name[18] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[18] && DateTime.Parse(itm.GDate).Month == Amount_Month[18] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Db8 = (Amount_Name[19] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[19] && DateTime.Parse(itm.GDate).Month == Amount_Month[19] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Db9 = (Amount_Name[20] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[20] && DateTime.Parse(itm.GDate).Month == Amount_Month[20] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Db10 = (Amount_Name[21] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[21] && DateTime.Parse(itm.GDate).Month == Amount_Month[21] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Db11 = (Amount_Name[22] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[22] && DateTime.Parse(itm.GDate).Month == Amount_Month[22] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                                Db12 = (Amount_Name[23] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[23] && DateTime.Parse(itm.GDate).Month == Amount_Month[23] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.LowAmount) : ""),
                            });
                        }
                    }
                    else if (itm.SiteAmount != 0)
                    {
                        iCount = MyOver.FindIndex(p => p.Code == itm.Site);
                        if (iCount > -1)
                        {
                            for (int i = 0; i < 24; i++)
                            {
                                if (Amount_Name[i] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[i] && DateTime.Parse(itm.GDate).Month == Amount_Month[i])
                                {
                                    if (i < 12)
                                    {
                                        PropertyInfo propertyInfo = typeof(vJv2).GetProperty("CrAmount" + (i + 1).ToString());
                                        am = (double)propertyInfo.GetValue(MyOver[iCount], null);
                                        propertyInfo.SetValue(MyOver[iCount], (am + itm.SiteAmount), null);

                                        string am0 = "";
                                        PropertyInfo propertyInfo2 = typeof(vJv2).GetProperty("Cr" + (i + 1).ToString());
                                        am0 = (string)propertyInfo2.GetValue(MyOver[iCount], null);
                                        propertyInfo2.SetValue(MyOver[iCount], (am0 + "\n" + itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount)), null);
                                    }
                                    else
                                    {
                                        PropertyInfo propertyInfo = typeof(vJv2).GetProperty("DbAmount" + (i + 1 - 12).ToString());
                                        am = (double)propertyInfo.GetValue(MyOver[iCount], null);
                                        propertyInfo.SetValue(MyOver[iCount], (am + itm.SiteAmount), null);

                                        string am0 = "";
                                        PropertyInfo propertyInfo2 = typeof(vJv2).GetProperty("Db" + (i + 1 - 12).ToString());
                                        am0 = (string)propertyInfo2.GetValue(MyOver[iCount], null);
                                        propertyInfo2.SetValue(MyOver[iCount], (am0 + "\n" + itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount)), null);
                                    }
                                }
                            }
                        }
                        else
                        {
                            MyOver.Add(new vJv2
                            {
                                Code = itm.Site,
                                AccName1 = itm.SiteName,
                                AccName2 = itm.SiteName,
                                DbAmount = ((ChkPeriod.Checked && DateTime.Parse(itm.GDate) < DateTime.Parse("01/01/2014")) || (!ChkPeriod.Checked && DateTime.Parse(itm.GDate) < DateTime.Parse(txtFDate.Text)) ? itm.SiteAmount : 0),
                                CrAmount1 = (Amount_Name[0] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[0] && DateTime.Parse(itm.GDate).Month == Amount_Month[0] ? itm.SiteAmount : 0),
                                CrAmount2 = (Amount_Name[1] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[1] && DateTime.Parse(itm.GDate).Month == Amount_Month[1] ? itm.SiteAmount : 0),
                                CrAmount3 = (Amount_Name[2] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[2] && DateTime.Parse(itm.GDate).Month == Amount_Month[2] ? itm.SiteAmount : 0),
                                CrAmount4 = (Amount_Name[3] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[3] && DateTime.Parse(itm.GDate).Month == Amount_Month[3] ? itm.SiteAmount : 0),
                                CrAmount5 = (Amount_Name[4] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[4] && DateTime.Parse(itm.GDate).Month == Amount_Month[4] ? itm.SiteAmount : 0),
                                CrAmount6 = (Amount_Name[5] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[5] && DateTime.Parse(itm.GDate).Month == Amount_Month[5] ? itm.SiteAmount : 0),
                                CrAmount7 = (Amount_Name[6] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[6] && DateTime.Parse(itm.GDate).Month == Amount_Month[6] ? itm.SiteAmount : 0),
                                CrAmount8 = (Amount_Name[7] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[7] && DateTime.Parse(itm.GDate).Month == Amount_Month[7] ? itm.SiteAmount : 0),
                                CrAmount9 = (Amount_Name[8] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[8] && DateTime.Parse(itm.GDate).Month == Amount_Month[8] ? itm.SiteAmount : 0),
                                CrAmount10 = (Amount_Name[9] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[9] && DateTime.Parse(itm.GDate).Month == Amount_Month[9] ? itm.SiteAmount : 0),
                                CrAmount11 = (Amount_Name[10] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[10] && DateTime.Parse(itm.GDate).Month == Amount_Month[10] ? itm.SiteAmount : 0),
                                CrAmount12 = (Amount_Name[11] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[11] && DateTime.Parse(itm.GDate).Month == Amount_Month[11] ? itm.SiteAmount : 0),
                                DbAmount1 = (Amount_Name[12] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[12] && DateTime.Parse(itm.GDate).Month == Amount_Month[12] ? itm.SiteAmount : 0),
                                DbAmount2 = (Amount_Name[13] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[13] && DateTime.Parse(itm.GDate).Month == Amount_Month[13] ? itm.SiteAmount : 0),
                                DbAmount3 = (Amount_Name[14] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[14] && DateTime.Parse(itm.GDate).Month == Amount_Month[14] ? itm.SiteAmount : 0),
                                DbAmount4 = (Amount_Name[15] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[15] && DateTime.Parse(itm.GDate).Month == Amount_Month[15] ? itm.SiteAmount : 0),
                                DbAmount5 = (Amount_Name[16] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[16] && DateTime.Parse(itm.GDate).Month == Amount_Month[16] ? itm.SiteAmount : 0),
                                DbAmount6 = (Amount_Name[17] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[17] && DateTime.Parse(itm.GDate).Month == Amount_Month[17] ? itm.SiteAmount : 0),
                                DbAmount7 = (Amount_Name[18] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[18] && DateTime.Parse(itm.GDate).Month == Amount_Month[18] ? itm.SiteAmount : 0),
                                DbAmount8 = (Amount_Name[19] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[19] && DateTime.Parse(itm.GDate).Month == Amount_Month[19] ? itm.SiteAmount : 0),
                                DbAmount9 = (Amount_Name[20] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[20] && DateTime.Parse(itm.GDate).Month == Amount_Month[20] ? itm.SiteAmount : 0),
                                DbAmount10 = (Amount_Name[21] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[21] && DateTime.Parse(itm.GDate).Month == Amount_Month[21] ? itm.SiteAmount : 0),
                                DbAmount11 = (Amount_Name[22] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[22] && DateTime.Parse(itm.GDate).Month == Amount_Month[22] ? itm.SiteAmount : 0),
                                DbAmount12 = (Amount_Name[23] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[23] && DateTime.Parse(itm.GDate).Month == Amount_Month[23] ? itm.SiteAmount : 0),
                                Cr1 = (Amount_Name[0] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[0] && DateTime.Parse(itm.GDate).Month == Amount_Month[0] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Cr2 = (Amount_Name[1] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[1] && DateTime.Parse(itm.GDate).Month == Amount_Month[1] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Cr3 = (Amount_Name[2] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[2] && DateTime.Parse(itm.GDate).Month == Amount_Month[2] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Cr4 = (Amount_Name[3] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[3] && DateTime.Parse(itm.GDate).Month == Amount_Month[3] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Cr5 = (Amount_Name[4] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[4] && DateTime.Parse(itm.GDate).Month == Amount_Month[4] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Cr6 = (Amount_Name[5] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[5] && DateTime.Parse(itm.GDate).Month == Amount_Month[5] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Cr7 = (Amount_Name[6] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[6] && DateTime.Parse(itm.GDate).Month == Amount_Month[6] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Cr8 = (Amount_Name[7] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[7] && DateTime.Parse(itm.GDate).Month == Amount_Month[7] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Cr9 = (Amount_Name[8] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[8] && DateTime.Parse(itm.GDate).Month == Amount_Month[8] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Cr10 = (Amount_Name[9] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[9] && DateTime.Parse(itm.GDate).Month == Amount_Month[9] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Cr11 = (Amount_Name[10] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[10] && DateTime.Parse(itm.GDate).Month == Amount_Month[10] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Cr12 = (Amount_Name[11] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[11] && DateTime.Parse(itm.GDate).Month == Amount_Month[11] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Db1 = (Amount_Name[12] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[12] && DateTime.Parse(itm.GDate).Month == Amount_Month[12] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Db2 = (Amount_Name[13] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[13] && DateTime.Parse(itm.GDate).Month == Amount_Month[13] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Db3 = (Amount_Name[14] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[14] && DateTime.Parse(itm.GDate).Month == Amount_Month[14] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Db4 = (Amount_Name[15] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[15] && DateTime.Parse(itm.GDate).Month == Amount_Month[15] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Db5 = (Amount_Name[16] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[16] && DateTime.Parse(itm.GDate).Month == Amount_Month[16] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Db6 = (Amount_Name[17] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[17] && DateTime.Parse(itm.GDate).Month == Amount_Month[17] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Db7 = (Amount_Name[18] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[18] && DateTime.Parse(itm.GDate).Month == Amount_Month[18] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Db8 = (Amount_Name[19] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[19] && DateTime.Parse(itm.GDate).Month == Amount_Month[19] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Db9 = (Amount_Name[20] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[20] && DateTime.Parse(itm.GDate).Month == Amount_Month[20] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Db10 = (Amount_Name[21] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[21] && DateTime.Parse(itm.GDate).Month == Amount_Month[21] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Db11 = (Amount_Name[22] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[22] && DateTime.Parse(itm.GDate).Month == Amount_Month[22] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                                Db12 = (Amount_Name[23] != "" && DateTime.Parse(itm.GDate).Year == Amount_Year[23] && DateTime.Parse(itm.GDate).Month == Amount_Month[23] ? itm.InvNo + "\t" + itm.GDate + "\t" + string.Format("{0:N2}", itm.SiteAmount) : ""),
                            });
                        }
                    }
                }

                Acc myAcc = new Acc();
                myAcc.Branch = 1;
                myAcc.FCode = "120301";
                foreach (Acc itm in myAcc.GetAllAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    if (!ChkCustomer.Checked)
                    {
                        if (ddlCustomer.SelectedIndex == 0)
                        {
                            continue;
                        }
                        else
                        {
                            if (itm.Code != ddlCustomer.SelectedValue) continue;
                        }                       
                    }
                    iCount = MyOver.FindIndex(p => p.Code == itm.Code);
                    if (iCount > -1) continue;
                    MyOver.Add(new vJv2
                    {
                        Code = itm.Code,
                        AccName1 = itm.Name1,
                        AccName2 = itm.Name2,
                        DbAmount = itm.Bal
                    });                    
                }
                
                foreach (vJv2 itm in MyOver)
                {
                    itm.OpenBal = itm.DbAmount + itm.DbAmount1 + itm.DbAmount2 + itm.DbAmount3 + itm.DbAmount4 + itm.DbAmount5 + itm.DbAmount6 + itm.DbAmount7 + itm.DbAmount8 + itm.DbAmount9 + itm.DbAmount10 + itm.DbAmount11 + itm.DbAmount12 + itm.CrAmount1 + itm.CrAmount2 + itm.CrAmount3 + itm.CrAmount4 + itm.CrAmount5 + itm.CrAmount6 + itm.CrAmount7 + itm.CrAmount8 + itm.CrAmount9 + itm.CrAmount10 + itm.CrAmount11 + itm.CrAmount12;
                    if (itm.Code.Trim().Length > 5)
                    {
                        if (ChkPeriod.Checked)
                        {
                            myAcc = new Acc();
                            myAcc.Branch = 1;
                            myAcc.Code = itm.Code;
                            if (myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                if (myAcc.Bal != itm.OpenBal)
                                {
                                    itm.DbAmount += (myAcc.Bal - itm.OpenBal);
                                    itm.OpenBal = itm.DbAmount + itm.DbAmount1 + itm.DbAmount2 + itm.DbAmount3 + itm.DbAmount4 + itm.DbAmount5 + itm.DbAmount6 + itm.DbAmount7 + itm.DbAmount8 + itm.DbAmount9 + itm.DbAmount10 + itm.DbAmount11 + itm.DbAmount12 + itm.CrAmount1 + itm.CrAmount2 + itm.CrAmount3 + itm.CrAmount4 + itm.CrAmount5 + itm.CrAmount6 + itm.CrAmount7 + itm.CrAmount8 + itm.CrAmount9 + itm.CrAmount10 + itm.CrAmount11 + itm.CrAmount12;
                                }
                            }
                        }
                        else
                        {
                            double bal = 0;
                            bal = moh.GetBal(itm.Code, txtEDate.Text, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myAcc.Bal != itm.OpenBal)
                            {
                                itm.DbAmount += (bal - itm.OpenBal);
                                itm.OpenBal = itm.DbAmount + itm.DbAmount1 + itm.DbAmount2 + itm.DbAmount3 + itm.DbAmount4 + itm.DbAmount5 + itm.DbAmount6 + itm.DbAmount7 + itm.DbAmount8 + itm.DbAmount9 + itm.DbAmount10 + itm.DbAmount11 + itm.DbAmount12 + itm.CrAmount1 + itm.CrAmount2 + itm.CrAmount3 + itm.CrAmount4 + itm.CrAmount5 + itm.CrAmount6 + itm.CrAmount7 + itm.CrAmount8 + itm.CrAmount9 + itm.CrAmount10 + itm.CrAmount11 + itm.CrAmount12;
                            }
                        }
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

        protected void ChkCustomer_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ddlCustomer.Visible = !ChkCustomer.Checked;

                grdCodes.DataSource = null;
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

        protected void ChkSite_CheckedChanged(object sender, EventArgs e)
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

        protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

    }
}