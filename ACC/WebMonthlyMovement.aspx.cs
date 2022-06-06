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
    public partial class WebMonthlyMovement : System.Web.UI.Page
    {
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
        public string TotalCrAmount
        {
            get
            {
                if (ViewState["TotalCrAmount"] == null)
                {
                    ViewState["TotalCrAmount"] = "0.00";
                }
                return ViewState["TotalCrAmount"].ToString();
            }
            set { ViewState["TotalCrAmount"] = value; }
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
                    this.Page.Header.Title = "الحركة الشهرية للحسابات";
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

                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = "الرئيسية";
                        UserTran.FormAction = "اختيار";
                        UserTran.Description = "اختيار عرض كشف الحركة الشهرية للحسابات";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    for (int i = 2014 ; i <= moh.Nows().Year ; i++)
                        ddlFYear.Items.Add(i.ToString());

                    ddlFYear.Items.Insert(0, new System.Web.UI.WebControls.ListItem("أختر السنة", "", true));
                    
                    
                    Acc myAcc = new Acc();
                    myAcc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["AllACC" + Session["CNN2"].ToString()] == null) Cache.Insert("AllACC" + Session["CNN2"].ToString(), myAcc.Getall(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlFather.DataValueField = "Code";
                    ddlFather.DataTextField = "Name1";
                    ddlFather.DataSource = (from itm in (List<Acc>)(Cache["AllACC" + Session["CNN2"].ToString()])
                                            where itm.FLevel != 5
                                            select new
                                            {
                                                Code = itm.Code,
                                                Name1 = itm.Name1
                                            }).ToList();
                    ddlFather.DataBind();
                    ddlFather.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--- جميع الحسابات ---", "", true));
                    ddlFather.SelectedIndex = 0;
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
                vJv2 myJv = new vJv2();
                myJv.Branch = short.Parse(Session["Branch"].ToString());
                MyOver = myJv.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, ddlFather.SelectedValue,ddlFYear.SelectedValue);
                grdCodes.DataSource = MyOver ;
                grdCodes.DataBind();
                lblCount.Text = MyOver.Count().ToString();
                MakeSum();
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
            if (grdCodes.FooterRow != null)
            {
                Label lblTotalDbAmount = grdCodes.FooterRow.FindControl("lblTotalDbAmount") as Label;
                Label lblTotalCrAmount = grdCodes.FooterRow.FindControl("lblTotalCrAmount") as Label;
                Label lblTotalDbAmount1 = grdCodes.FooterRow.FindControl("lblTotalDbAmount1") as Label;
                Label lblTotalCrAmount1 = grdCodes.FooterRow.FindControl("lblTotalCrAmount1") as Label;
                Label lblTotalDbAmount2 = grdCodes.FooterRow.FindControl("lblTotalDbAmount2") as Label;
                Label lblTotalCrAmount2 = grdCodes.FooterRow.FindControl("lblTotalCrAmount2") as Label;
                Label lblTotalDbAmount3 = grdCodes.FooterRow.FindControl("lblTotalDbAmount3") as Label;
                Label lblTotalCrAmount3 = grdCodes.FooterRow.FindControl("lblTotalCrAmount3") as Label;
                Label lblTotalDbAmount4 = grdCodes.FooterRow.FindControl("lblTotalDbAmount4") as Label;
                Label lblTotalCrAmount4 = grdCodes.FooterRow.FindControl("lblTotalCrAmount4") as Label;
                Label lblTotalDbAmount5 = grdCodes.FooterRow.FindControl("lblTotalDbAmount5") as Label;
                Label lblTotalCrAmount5 = grdCodes.FooterRow.FindControl("lblTotalCrAmount5") as Label;
                Label lblTotalDbAmount6 = grdCodes.FooterRow.FindControl("lblTotalDbAmount6") as Label;
                Label lblTotalCrAmount6 = grdCodes.FooterRow.FindControl("lblTotalCrAmount6") as Label;
                Label lblTotalDbAmount7 = grdCodes.FooterRow.FindControl("lblTotalDbAmount7") as Label;
                Label lblTotalCrAmount7 = grdCodes.FooterRow.FindControl("lblTotalCrAmount7") as Label;
                Label lblTotalDbAmount8 = grdCodes.FooterRow.FindControl("lblTotalDbAmount8") as Label;
                Label lblTotalCrAmount8 = grdCodes.FooterRow.FindControl("lblTotalCrAmount8") as Label;
                Label lblTotalDbAmount9 = grdCodes.FooterRow.FindControl("lblTotalDbAmount9") as Label;
                Label lblTotalCrAmount9 = grdCodes.FooterRow.FindControl("lblTotalCrAmount9") as Label;
                Label lblTotalDbAmount10 = grdCodes.FooterRow.FindControl("lblTotalDbAmount10") as Label;
                Label lblTotalCrAmount10 = grdCodes.FooterRow.FindControl("lblTotalCrAmount10") as Label;
                Label lblTotalDbAmount11 = grdCodes.FooterRow.FindControl("lblTotalDbAmount11") as Label;
                Label lblTotalCrAmount11 = grdCodes.FooterRow.FindControl("lblTotalCrAmount11") as Label;
                Label lblTotalDbAmount12 = grdCodes.FooterRow.FindControl("lblTotalDbAmount12") as Label;
                Label lblTotalCrAmount12 = grdCodes.FooterRow.FindControl("lblTotalCrAmount12") as Label;
                Label lblTotalBal = grdCodes.FooterRow.FindControl("lblTotalBal") as Label;
                Label lblTotalOpenBal = grdCodes.FooterRow.FindControl("lblTotalOpenBal") as Label;

                double Db1 = 0, Db2 = 0, Db3 = 0, Db4 = 0, Db5 = 0, Db6 = 0, Db7 = 0, Db8 = 0, Db9 = 0, Db10 = 0, Db11 = 0, Db12 = 0, Db = 0, Cr1 = 0, Cr2 = 0, Cr3 = 0, Cr4 = 0, Cr5 = 0, Cr6 = 0, Cr7 = 0, Cr8 = 0, Cr9 = 0, Cr10 = 0, Cr11 = 0, Cr12 = 0, Cr = 0 , Bal = 0, OpenBal = 0;

                foreach (vJv2 itm in MyOver)
                {
                    Db +=  itm.DbAmount != null ? (double)itm.DbAmount :0;
                    Db1 += itm.DbAmount1 != null ? (double)itm.DbAmount1 :0;
                    Db2 += itm.DbAmount2 != null ?  (double)itm.DbAmount2 :0;
                    Db3 += itm.DbAmount3 != null ? (double)itm.DbAmount3 :0;
                    Db4 += itm.DbAmount4 != null ? (double)itm.DbAmount4 :0;
                    Db5 += itm.DbAmount5 != null ?  (double)itm.DbAmount5 :0;
                    Db6 += itm.DbAmount6 != null ?  (double)itm.DbAmount6 :0;
                    Db7 += itm.DbAmount7 != null ?  (double)itm.DbAmount7 :0;
                    Db8 += itm.DbAmount8 != null ?  (double)itm.DbAmount8 :0;
                    Db9 += itm.DbAmount9 != null ?  (double)itm.DbAmount9 :0;
                    Db10 += itm.DbAmount10 != null ?  (double)itm.DbAmount10 :0;
                    Db11 += itm.DbAmount11 != null ?  (double)itm.DbAmount11 :0;
                    Db12 += itm.DbAmount12 != null ? (double)itm.DbAmount12 :0;

                    Cr += itm.CrAmount != null ? (double)itm.CrAmount :0;
                    Cr1 += itm.CrAmount1 != null ? (double)itm.CrAmount1 :0;
                    Cr2 += itm.CrAmount2 != null ? (double)itm.CrAmount2 :0;
                    Cr3 += itm.CrAmount3 != null ? (double)itm.CrAmount3 :0;
                    Cr4 += itm.CrAmount4 != null ? (double)itm.CrAmount4 :0;
                    Cr5 += itm.CrAmount5 != null ? (double)itm.CrAmount5 :0;
                    Cr6 += itm.CrAmount6 != null ? (double)itm.CrAmount6 :0;
                    Cr7 += itm.CrAmount7 != null ? (double)itm.CrAmount7 :0;
                    Cr8 += itm.CrAmount8 != null ? (double)itm.CrAmount8 :0;
                    Cr9 += itm.CrAmount9 != null ? (double)itm.CrAmount9 :0;
                    Cr10 += itm.CrAmount10 != null ? (double)itm.CrAmount10 :0;
                    Cr11 += itm.CrAmount11 != null ? (double)itm.CrAmount11 :0;
                    Cr12 += itm.CrAmount12 != null ? (double)itm.CrAmount12 :0;
                    OpenBal += itm.OpenBal != null ? (double)itm.OpenBal :0;
                    Bal += itm.Bal;
                }

                if (lblTotalOpenBal != null)
                {
                    lblTotalOpenBal.Text = string.Format("{0:N2}", OpenBal);
                    TotalOpenBal = lblTotalOpenBal.Text;
                }
                if (lblTotalBal != null)
                {
                    lblTotalBal.Text = string.Format("{0:N2}", Bal);
                    TotalBal = lblTotalBal.Text;
                }
                if (lblTotalDbAmount != null)
                {
                    lblTotalDbAmount.Text = string.Format("{0:N2}", Db);
                    TotalDbAmount = lblTotalDbAmount.Text;
                }
                if (lblTotalCrAmount != null)
                {
                    lblTotalCrAmount.Text = string.Format("{0:N2}", Cr);
                    TotalCrAmount = lblTotalCrAmount.Text;
                }

                if (lblTotalDbAmount1 != null)
                {
                    lblTotalDbAmount1.Text = string.Format("{0:N2}", Db1);
                    TotalDbAmount1 = lblTotalDbAmount1.Text;
                }
                if (lblTotalCrAmount1 != null)
                {
                    lblTotalCrAmount1.Text = string.Format("{0:N2}", Cr1);
                    TotalCrAmount1 = lblTotalCrAmount1.Text;
                }

                if (lblTotalDbAmount2 != null)
                {
                    lblTotalDbAmount2.Text = string.Format("{0:N2}", Db2);
                    TotalDbAmount2 = lblTotalDbAmount2.Text;
                }
                if (lblTotalCrAmount2 != null)
                {
                    lblTotalCrAmount2.Text = string.Format("{0:N2}", Cr2);
                    TotalCrAmount2 = lblTotalCrAmount2.Text;
                }

                if (lblTotalDbAmount3 != null)
                {
                    lblTotalDbAmount3.Text = string.Format("{0:N2}", Db3);
                    TotalDbAmount3 = lblTotalDbAmount3.Text;
                }
                if (lblTotalCrAmount3 != null)
                {
                    lblTotalCrAmount3.Text = string.Format("{0:N2}", Cr3);
                    TotalCrAmount3 = lblTotalCrAmount3.Text;
                }

                if (lblTotalDbAmount4 != null)
                {
                    lblTotalDbAmount4.Text = string.Format("{0:N2}", Db4);
                    TotalDbAmount4 = lblTotalDbAmount4.Text;
                }
                if (lblTotalCrAmount4 != null)
                {
                    lblTotalCrAmount4.Text = string.Format("{0:N2}", Cr4);
                    TotalCrAmount4 = lblTotalCrAmount4.Text;
                }

                if (lblTotalDbAmount5 != null)
                {
                    lblTotalDbAmount5.Text = string.Format("{0:N2}", Db5);
                    TotalDbAmount5 = lblTotalDbAmount5.Text;
                }
                if (lblTotalCrAmount5 != null)
                {
                    lblTotalCrAmount5.Text = string.Format("{0:N2}", Cr5);
                    TotalCrAmount5 = lblTotalCrAmount5.Text;
                }

                if (lblTotalDbAmount6 != null)
                {
                    lblTotalDbAmount6.Text = string.Format("{0:N2}", Db6);
                    TotalDbAmount6 = lblTotalDbAmount6.Text;
                }
                if (lblTotalCrAmount6 != null)
                {
                    lblTotalCrAmount6.Text = string.Format("{0:N2}", Cr6);
                    TotalCrAmount6 = lblTotalCrAmount6.Text;
                }

                if (lblTotalDbAmount7 != null)
                {
                    lblTotalDbAmount7.Text = string.Format("{0:N2}", Db7);
                    TotalDbAmount7 = lblTotalDbAmount7.Text;
                }
                if (lblTotalCrAmount7 != null)
                {
                    lblTotalCrAmount7.Text = string.Format("{0:N2}", Cr7);
                    TotalCrAmount7 = lblTotalCrAmount7.Text;
                }

                if (lblTotalDbAmount8 != null)
                {
                    lblTotalDbAmount8.Text = string.Format("{0:N2}", Db8);
                    TotalDbAmount8 = lblTotalDbAmount8.Text;
                }
                if (lblTotalCrAmount8 != null)
                {
                    lblTotalCrAmount8.Text = string.Format("{0:N2}", Cr8);
                    TotalCrAmount8 = lblTotalCrAmount8.Text;
                }

                if (lblTotalDbAmount9 != null)
                {
                    lblTotalDbAmount9.Text = string.Format("{0:N2}", Db9);
                    TotalDbAmount9 = lblTotalDbAmount9.Text;
                }
                if (lblTotalCrAmount9 != null)
                {
                    lblTotalCrAmount9.Text = string.Format("{0:N2}", Cr9);
                    TotalCrAmount9 = lblTotalCrAmount9.Text;
                }

                if (lblTotalDbAmount10 != null)
                {
                    lblTotalDbAmount10.Text = string.Format("{0:N2}", Db10);
                    TotalDbAmount10 = lblTotalDbAmount10.Text;
                }
                if (lblTotalCrAmount10 != null)
                {
                    lblTotalCrAmount10.Text = string.Format("{0:N2}", Cr10);
                    TotalCrAmount10 = lblTotalCrAmount10.Text;
                }

                if (lblTotalDbAmount11 != null)
                {
                    lblTotalDbAmount11.Text = string.Format("{0:N2}", Db11);
                    TotalDbAmount11 = lblTotalDbAmount11.Text;
                }
                if (lblTotalCrAmount11 != null)
                {
                    lblTotalCrAmount11.Text = string.Format("{0:N2}", Cr11);
                    TotalCrAmount11 = lblTotalCrAmount11.Text;
                }

                if (lblTotalDbAmount12 != null)
                {
                    lblTotalDbAmount12.Text = string.Format("{0:N2}", Db12);
                    TotalDbAmount12 = lblTotalDbAmount12.Text;
                }
                if (lblTotalCrAmount12 != null)
                {
                    lblTotalCrAmount12.Text = string.Format("{0:N2}", Cr12);
                    TotalCrAmount12 = lblTotalCrAmount12.Text;
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
                iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), -50, -50, 80, 50);
                HttpContext.Current.Response.ContentType = "application/pdf";
                PdfWriter pw = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
                pdfPage page = new pdfPage();
                MyConfig mySetting = new MyConfig();
                mySetting.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                mySetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                if (mySetting != null)
                {
                    page.vCompanyName = mySetting.CompanyName;
                }
                if (ddlFather.SelectedIndex>0) page.vSubTitle = ddlFather.SelectedItem.Text;
                else page.vSubTitle = " ";
                page.PageNo = "1";
                page.UserName = Session["FullUser"].ToString();
                pw.PageEvent = page;
                document.Open();
                //PdfPTable table = new PdfPTable(grdCodes.HeaderRow.Cells.Count);
                PdfPTable table = new PdfPTable(17);
                float[] colWidths = { 80,80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 200, 80};
                table.SetWidths(colWidths);
                PdfPCell cell = new PdfPCell();
                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";                    
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 6f, iTextSharp.text.Font.NORMAL);

                foreach (vJv2 itm in MyOver)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(itm.Code, nationalTextFont);
                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.AccName1, nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.OpenBal), nationalTextFont);
                    table.AddCell(cell);

                    PdfPTable headerTbl3 = new PdfPTable(1);
                    headerTbl3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    headerTbl3.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    PdfPCell cell30 = new PdfPCell(headerTbl3);
                    cell30.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell30.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell30.PaddingRight = 0;
                    PdfPCell cell20 = new PdfPCell();
                    //cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.DbAmount1), nationalTextFont);
                    cell20.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell20.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell20.Border = 0;
                    headerTbl3.AddCell(cell20);
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.CrAmount1), nationalTextFont);
                    headerTbl3.AddCell(cell20);
                    table.AddCell(cell30);

                    headerTbl3 = new PdfPTable(1);
                    headerTbl3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    headerTbl3.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell30 = new PdfPCell(headerTbl3);
                    cell30.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell30.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell30.PaddingRight = 0;
                    cell20 = new PdfPCell();
                    //cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.DbAmount2), nationalTextFont);
                    cell20.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell20.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell20.Border = 0;
                    headerTbl3.AddCell(cell20);
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.CrAmount2), nationalTextFont);
                    headerTbl3.AddCell(cell20);
                    table.AddCell(cell30);

                    headerTbl3 = new PdfPTable(1);
                    headerTbl3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    headerTbl3.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell30 = new PdfPCell(headerTbl3);
                    cell30.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell30.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell30.PaddingRight = 0;
                    cell20 = new PdfPCell();
                    //cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.DbAmount3), nationalTextFont);
                    cell20.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell20.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell20.Border = 0;
                    headerTbl3.AddCell(cell20);
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.CrAmount3), nationalTextFont);
                    headerTbl3.AddCell(cell20);
                    table.AddCell(cell30);

                    headerTbl3 = new PdfPTable(1);
                    headerTbl3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    headerTbl3.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell30 = new PdfPCell(headerTbl3);
                    cell30.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell30.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell30.PaddingRight = 0;
                    cell20 = new PdfPCell();
                    //cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.DbAmount4), nationalTextFont);
                    cell20.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell20.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell20.Border = 0;
                    headerTbl3.AddCell(cell20);
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.CrAmount4), nationalTextFont);
                    headerTbl3.AddCell(cell20);
                    table.AddCell(cell30);

                    headerTbl3 = new PdfPTable(1);
                    headerTbl3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    headerTbl3.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell30 = new PdfPCell(headerTbl3);
                    cell30.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell30.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell30.PaddingRight = 0;
                    cell20 = new PdfPCell();
                    //cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.DbAmount5), nationalTextFont);
                    cell20.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell20.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell20.Border = 0;
                    headerTbl3.AddCell(cell20);
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.CrAmount5), nationalTextFont);
                    headerTbl3.AddCell(cell20);
                    table.AddCell(cell30);

                    headerTbl3 = new PdfPTable(1);
                    headerTbl3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    headerTbl3.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell30 = new PdfPCell(headerTbl3);
                    cell30.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell30.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell30.PaddingRight = 0;
                    cell20 = new PdfPCell();
                    //cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.DbAmount6), nationalTextFont);
                    cell20.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell20.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell20.Border = 0;
                    headerTbl3.AddCell(cell20);
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.CrAmount6), nationalTextFont);
                    headerTbl3.AddCell(cell20);
                    table.AddCell(cell30);

                    headerTbl3 = new PdfPTable(1);
                    headerTbl3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    headerTbl3.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell30 = new PdfPCell(headerTbl3);
                    cell30.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell30.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell30.PaddingRight = 0;
                    cell20 = new PdfPCell();
                    //cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.DbAmount7), nationalTextFont);
                    cell20.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell20.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell20.Border = 0;
                    headerTbl3.AddCell(cell20);
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.CrAmount7), nationalTextFont);
                    headerTbl3.AddCell(cell20);
                    table.AddCell(cell30);

                    headerTbl3 = new PdfPTable(1);
                    headerTbl3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    headerTbl3.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell30 = new PdfPCell(headerTbl3);
                    cell30.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell30.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell30.PaddingRight = 0;
                    cell20 = new PdfPCell();
                    //cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.DbAmount8), nationalTextFont);
                    cell20.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell20.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell20.Border = 0;
                    headerTbl3.AddCell(cell20);
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.CrAmount8), nationalTextFont);
                    headerTbl3.AddCell(cell20);
                    table.AddCell(cell30);

                    headerTbl3 = new PdfPTable(1);
                    headerTbl3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    headerTbl3.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell30 = new PdfPCell(headerTbl3);
                    cell30.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell30.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell30.PaddingRight = 0;
                    cell20 = new PdfPCell();
                    //cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.DbAmount9), nationalTextFont);
                    cell20.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell20.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell20.Border = 0;
                    headerTbl3.AddCell(cell20);
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.CrAmount9), nationalTextFont);
                    headerTbl3.AddCell(cell20);
                    table.AddCell(cell30);

                    headerTbl3 = new PdfPTable(1);
                    headerTbl3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    headerTbl3.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell30 = new PdfPCell(headerTbl3);
                    cell30.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell30.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell30.PaddingRight = 0;
                    cell20 = new PdfPCell();
                    //cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.DbAmount10), nationalTextFont);
                    cell20.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell20.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell20.Border = 0;
                    headerTbl3.AddCell(cell20);
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.CrAmount10), nationalTextFont);
                    headerTbl3.AddCell(cell20);
                    table.AddCell(cell30);

                    headerTbl3 = new PdfPTable(1);
                    headerTbl3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    headerTbl3.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell30 = new PdfPCell(headerTbl3);
                    cell30.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell30.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell30.PaddingRight = 0;
                    cell20 = new PdfPCell();
                    //cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.DbAmount11), nationalTextFont);
                    cell20.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell20.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell20.Border = 0;
                    headerTbl3.AddCell(cell20);
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.CrAmount11), nationalTextFont);
                    headerTbl3.AddCell(cell20);
                    table.AddCell(cell30);

                    headerTbl3 = new PdfPTable(1);
                    headerTbl3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    headerTbl3.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell30 = new PdfPCell(headerTbl3);
                    cell30.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell30.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell30.PaddingRight = 0;
                    cell20 = new PdfPCell();
                    //cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.DbAmount12), nationalTextFont);
                    cell20.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell20.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell20.Border = 0;
                    headerTbl3.AddCell(cell20);
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.CrAmount12), nationalTextFont);
                    headerTbl3.AddCell(cell20);
                    table.AddCell(cell30);

                    headerTbl3 = new PdfPTable(1);
                    headerTbl3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    headerTbl3.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell30 = new PdfPCell(headerTbl3);
                    cell30.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell30.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell30.PaddingRight = 0;
                    cell20 = new PdfPCell();
                    //cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.DbAmount), nationalTextFont);
                    cell20.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell20.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell20.Border = 0;
                    headerTbl3.AddCell(cell20);
                    cell20.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.CrAmount), nationalTextFont);
                    headerTbl3.AddCell(cell20);
                    table.AddCell(cell30);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Bal), nationalTextFont);
                    table.AddCell(cell);
                }
                cell.Phrase = new iTextSharp.text.Phrase("الاجمالي", nationalTextFont);
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalOpenBal, nationalTextFont);
                table.AddCell(cell);

                PdfPTable headerTbl33 = new PdfPTable(1);
                headerTbl33.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl33.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                PdfPCell cell330 = new PdfPCell(headerTbl33);
                cell330.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell330.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell330.PaddingRight = 0;
                PdfPCell cell320 = new PdfPCell();
                //cell320.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell320.Phrase = new iTextSharp.text.Phrase(TotalDbAmount1, nationalTextFont);
                cell320.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell320.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell320.Border = 0;
                headerTbl33.AddCell(cell320);
                cell320.Phrase = new iTextSharp.text.Phrase(TotalCrAmount1, nationalTextFont);
                headerTbl33.AddCell(cell320);
                table.AddCell(cell330);

                headerTbl33 = new PdfPTable(1);
                headerTbl33.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl33.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell330 = new PdfPCell(headerTbl33);
                cell330.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell330.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell330.PaddingRight = 0;
                cell320 = new PdfPCell();
                //cell320.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell320.Phrase = new iTextSharp.text.Phrase(TotalDbAmount2, nationalTextFont);
                cell320.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell320.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell320.Border = 0;
                headerTbl33.AddCell(cell320);
                cell320.Phrase = new iTextSharp.text.Phrase(TotalCrAmount2, nationalTextFont);
                headerTbl33.AddCell(cell320);
                table.AddCell(cell330);

                headerTbl33 = new PdfPTable(1);
                headerTbl33.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl33.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell330 = new PdfPCell(headerTbl33);
                cell330.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell330.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell330.PaddingRight = 0;
                cell320 = new PdfPCell();
                //cell320.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell320.Phrase = new iTextSharp.text.Phrase(TotalDbAmount3, nationalTextFont);
                cell320.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell320.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell320.Border = 0;
                headerTbl33.AddCell(cell320);
                cell320.Phrase = new iTextSharp.text.Phrase(TotalCrAmount3, nationalTextFont);
                headerTbl33.AddCell(cell320);
                table.AddCell(cell330);

                headerTbl33 = new PdfPTable(1);
                headerTbl33.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl33.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell330 = new PdfPCell(headerTbl33);
                cell330.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell330.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell330.PaddingRight = 0;
                cell320 = new PdfPCell();
                //cell320.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell320.Phrase = new iTextSharp.text.Phrase(TotalDbAmount4, nationalTextFont);
                cell320.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell320.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell320.Border = 0;
                headerTbl33.AddCell(cell320);
                cell320.Phrase = new iTextSharp.text.Phrase(TotalCrAmount4, nationalTextFont);
                headerTbl33.AddCell(cell320);
                table.AddCell(cell330);

                headerTbl33 = new PdfPTable(1);
                headerTbl33.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl33.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell330 = new PdfPCell(headerTbl33);
                cell330.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell330.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell330.PaddingRight = 0;
                cell320 = new PdfPCell();
                //cell320.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell320.Phrase = new iTextSharp.text.Phrase(TotalDbAmount5, nationalTextFont);
                cell320.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell320.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell320.Border = 0;
                headerTbl33.AddCell(cell320);
                cell320.Phrase = new iTextSharp.text.Phrase(TotalCrAmount5, nationalTextFont);
                headerTbl33.AddCell(cell320);
                table.AddCell(cell330);

                headerTbl33 = new PdfPTable(1);
                headerTbl33.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl33.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell330 = new PdfPCell(headerTbl33);
                cell330.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell330.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell330.PaddingRight = 0;
                cell320 = new PdfPCell();
                //cell320.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell320.Phrase = new iTextSharp.text.Phrase(TotalDbAmount6, nationalTextFont);
                cell320.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell320.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell320.Border = 0;
                headerTbl33.AddCell(cell320);
                cell320.Phrase = new iTextSharp.text.Phrase(TotalCrAmount6, nationalTextFont);
                headerTbl33.AddCell(cell320);
                table.AddCell(cell330);

                headerTbl33 = new PdfPTable(1);
                headerTbl33.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl33.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell330 = new PdfPCell(headerTbl33);
                cell330.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell330.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell330.PaddingRight = 0;
                cell320 = new PdfPCell();
                //cell320.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell320.Phrase = new iTextSharp.text.Phrase(TotalDbAmount7, nationalTextFont);
                cell320.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell320.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell320.Border = 0;
                headerTbl33.AddCell(cell320);
                cell320.Phrase = new iTextSharp.text.Phrase(TotalCrAmount7, nationalTextFont);
                headerTbl33.AddCell(cell320);
                table.AddCell(cell330);

                headerTbl33 = new PdfPTable(1);
                headerTbl33.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl33.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell330 = new PdfPCell(headerTbl33);
                cell330.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell330.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell330.PaddingRight = 0;
                cell320 = new PdfPCell();
                //cell320.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell320.Phrase = new iTextSharp.text.Phrase(TotalDbAmount8, nationalTextFont);
                cell320.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell320.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell320.Border = 0;
                headerTbl33.AddCell(cell320);
                cell320.Phrase = new iTextSharp.text.Phrase(TotalCrAmount8, nationalTextFont);
                headerTbl33.AddCell(cell320);
                table.AddCell(cell330);

                headerTbl33 = new PdfPTable(1);
                headerTbl33.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl33.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell330 = new PdfPCell(headerTbl33);
                cell330.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell330.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell330.PaddingRight = 0;
                cell320 = new PdfPCell();
                //cell320.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell320.Phrase = new iTextSharp.text.Phrase(TotalDbAmount9, nationalTextFont);
                cell320.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell320.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell320.Border = 0;
                headerTbl33.AddCell(cell320);
                cell320.Phrase = new iTextSharp.text.Phrase(TotalCrAmount9, nationalTextFont);
                headerTbl33.AddCell(cell320);
                table.AddCell(cell330);

                headerTbl33 = new PdfPTable(1);
                headerTbl33.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl33.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell330 = new PdfPCell(headerTbl33);
                cell330.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell330.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell330.PaddingRight = 0;
                cell320 = new PdfPCell();
                //cell320.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell320.Phrase = new iTextSharp.text.Phrase(TotalDbAmount10, nationalTextFont);
                cell320.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell320.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell320.Border = 0;
                headerTbl33.AddCell(cell320);
                cell320.Phrase = new iTextSharp.text.Phrase(TotalCrAmount10, nationalTextFont);
                headerTbl33.AddCell(cell320);
                table.AddCell(cell330);

                headerTbl33 = new PdfPTable(1);
                headerTbl33.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl33.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell330 = new PdfPCell(headerTbl33);
                cell330.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell330.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell330.PaddingRight = 0;
                cell320 = new PdfPCell();
                //cell320.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell320.Phrase = new iTextSharp.text.Phrase(TotalDbAmount11, nationalTextFont);
                cell320.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell320.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell320.Border = 0;
                headerTbl33.AddCell(cell320);
                cell320.Phrase = new iTextSharp.text.Phrase(TotalCrAmount11, nationalTextFont);
                headerTbl33.AddCell(cell320);
                table.AddCell(cell330);

                headerTbl33 = new PdfPTable(1);
                headerTbl33.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl33.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell330 = new PdfPCell(headerTbl33);
                cell330.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell330.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell330.PaddingRight = 0;
                cell320 = new PdfPCell();
                //cell320.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell320.Phrase = new iTextSharp.text.Phrase(TotalDbAmount12, nationalTextFont);
                cell320.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell320.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell320.Border = 0;
                headerTbl33.AddCell(cell320);
                cell320.Phrase = new iTextSharp.text.Phrase(TotalCrAmount12, nationalTextFont);
                headerTbl33.AddCell(cell320);
                table.AddCell(cell330);

                headerTbl33 = new PdfPTable(1);
                headerTbl33.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl33.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell330 = new PdfPCell(headerTbl33);
                cell330.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell330.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell330.PaddingRight = 0;
                cell320 = new PdfPCell();
                //cell320.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell320.Phrase = new iTextSharp.text.Phrase(TotalDbAmount, nationalTextFont);
                cell320.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell320.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell320.Border = 0;
                headerTbl33.AddCell(cell320);
                cell320.Phrase = new iTextSharp.text.Phrase(TotalCrAmount, nationalTextFont);
                headerTbl33.AddCell(cell320);
                table.AddCell(cell330);

                cell.Phrase = new iTextSharp.text.Phrase(TotalBal, nationalTextFont);
                table.AddCell(cell);

                document.Add(table);

                document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));

                var cols5 = new[] { 75, 200, 200, 200, 75 };
                PdfPCell cell5 = new PdfPCell();
                cell5.ArabicOptions = ColumnText.DIGITS_EN2AN;
                PdfPTable table50 = new PdfPTable(5);
                table50.TotalWidth = 100f;
                table50.SetWidths(cols5);
                cell5.ArabicOptions = ColumnText.DIGITS_EN2AN;
                table50.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table50.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                cell5.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell5.Border = 0;
                table50.AddCell(cell5);

                cell5.Phrase = new iTextSharp.text.Phrase("رئيس الحسابات", nationalTextFont);
                cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell5.Border = 0;
                table50.AddCell(cell5);

                cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell.Border = 0;
                table50.AddCell(cell5);

                cell5.Phrase = new iTextSharp.text.Phrase("المحاسب", nationalTextFont);
                cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell5.Border = 0;
                table50.AddCell(cell5);

                cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell5.Border = 0;
                table50.AddCell(cell5);


                cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell5.Border = 0;
                table50.AddCell(cell5);

                cell5.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell5.Border = 0;
                table50.AddCell(cell5);

                cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell5.Border = 0;
                table50.AddCell(cell5);

                cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell5.Border = 0;
                table50.AddCell(cell5);

                cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell5.Border = 0;
                table50.AddCell(cell5);

                cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell5.Border = 0;
                table50.AddCell(cell5);

                cell5.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell5.Border = 2;
                table50.AddCell(cell5);

                cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell5.Border = 0;
                table50.AddCell(cell5);

                cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell5.Border = 2;
                table50.AddCell(cell5);

                cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell5.Border = 0;
                table50.AddCell(cell5);

                document.Add(table50);
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
            public string UserName, PageNo, vSubTitle,vCompanyName;
            //I create a font object to use within my footer
            protected iTextSharp.text.Font footer
            {
                get
                {
                    // create a basecolor to use for the footer font, if needed.
                    iTextSharp.text.BaseColor grey = new iTextSharp.text.BaseColor(128, 128, 128);
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
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);

                //I use a PdfPtable with 1 column to position my header where I want it
                PdfPTable headerTbl = new PdfPTable(3);
                var cols2 = new[] { 200, 300, 200 };
                headerTbl.SetWidths(cols2);

                headerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                //set the width of the table to be the same as the document
                headerTbl.TotalWidth = doc.PageSize.Width;

                PdfPCell cell2 = new PdfPCell();
                cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell2.Border = 0;
                cell2.PaddingRight = 15;
                cell2.Phrase = new iTextSharp.text.Phrase(vCompanyName + "\n" + "الإدارة المالية", nationalTextFont);
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                headerTbl.AddCell(cell2);

                cell2.PaddingRight = 0;
                cell2.Phrase = new iTextSharp.text.Phrase("الحركة الشهرية للحسابات", nationalTextFont);
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

                cell2.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                headerTbl.AddCell(cell2);
                cell2.Phrase = new iTextSharp.text.Phrase(vSubTitle, nationalTextFont);
                headerTbl.AddCell(cell2);
                cell2.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                headerTbl.AddCell(cell2);

                arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";                    
                //BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                nationalTextFont = new iTextSharp.text.Font(nationalBase, 8f, iTextSharp.text.Font.NORMAL);

                PdfPTable table = new PdfPTable(17);
                float[] colWidths = { 80,80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 200, 80 };
                table.SetWidths(colWidths);
                PdfPCell cell = new PdfPCell();
                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                cell.Phrase = new iTextSharp.text.Phrase("رقم الحساب", nationalTextFont);
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("أسم الحساب", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("رصيد أول الفترة", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("يناير", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("فبراير", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("مارس", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("أبريل", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("مايو", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("يونية", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("يوليو", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("أغسطس", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("سبتمبر", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("أكتوبر", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("نوفمبر", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("ديسمبر", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("أجمالي", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("الرصيد", nationalTextFont);
                table.AddCell(cell);

                headerTbl.WriteSelectedRows(0, -1, -1, (doc.PageSize.Height - 20), writer.DirectContent);
                doc.Add(table);
            }

            //override the OnPageEnd event handler to add our footer
            public override void OnEndPage(PdfWriter writer, iTextSharp.text.Document doc)
            {
                //I use a PdfPtable with 2 columns to position my footer where I want it
                PdfPTable footerTbl = new PdfPTable(4);
                var cols2 = new[] { 200, 200, 200, 200 };
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
                cell.Border = 0;

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


        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
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
            /* Verifies that the control is rendered */
        }

        protected void BtnProcess_Click(object sender, ImageClickEventArgs e)
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

        protected void chkCode_CheckedChanged(object sender, EventArgs e)
        {
            Acc myacc = new Acc();
            if (Cache["AllACC" + Session["CNN2"].ToString()] == null) Cache.Insert("AllACC" + Session["CNN2"].ToString(), myacc.Getall(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            if (chkCode.Checked)
            {
                ddlFather.DataTextField = "Code";
            }
            else
            {

                ddlFather.DataTextField = "Name1";
            }
            ddlFather.DataValueField = "Code";
            ddlFather.DataSource = (from itm in (List<Acc>)(Cache["AllACC" + Session["CNN2"].ToString()])
                                    where itm.FLevel != 5
                                    select new
                                    {
                                        Code = itm.Code,
                                        Name1 = itm.Name1
                                    }).ToList();

            ddlFather.DataBind();
            ddlFather.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0", true));
            ddlFather.SelectedIndex = 0;
        }

        protected void ddlFYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void ddlFather_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }


    }
}