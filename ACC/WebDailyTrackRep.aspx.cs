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
    public partial class WebDailyTrackRep : System.Web.UI.Page
    {
        public string TotalCars
        {
            get
            {
                if (ViewState["TotalCars"] == null)
                {
                    ViewState["TotalCars"] = "";
                }
                return ViewState["TotalCars"].ToString();
            }
            set { ViewState["TotalCars"] = value; }
        }
        public string TotalSiteAmount
        {
            get
            {
                if (ViewState["TotalSiteAmount"] == null)
                {
                    ViewState["TotalSiteAmount"] = "0.00";
                }
                return ViewState["TotalSiteAmount"].ToString();
            }
            set { ViewState["TotalSiteAmount"] = value; }
        }
        public string TotalCashAmount
        {
            get
            {
                if (ViewState["TotalCashAmount"] == null)
                {
                    ViewState["TotalCashAmount"] = "0.00";
                }
                return ViewState["TotalCashAmount"].ToString();
            }
            set { ViewState["TotalCashAmount"] = value; }
        }
        public double? TotalCashAmount2
        {
            get
            {
                if (ViewState["TotalCashAmount2"] == null)
                {
                    ViewState["TotalCashAmount2"] = "0.00";
                }
                return moh.StrToDouble(ViewState["TotalCashAmount2"].ToString());
            }
            set { ViewState["TotalCashAmount2"] = value.ToString(); }
        }
        public string TotalCreditAmount
        {
            get
            {
                if (ViewState["TotalCreditAmount"] == null)
                {
                    ViewState["TotalCreditAmount"] = "0.00";
                }
                return ViewState["TotalCreditAmount"].ToString();
            }
            set { ViewState["TotalCreditAmount"] = value; }
        }
        public string TotalCustomerAmount
        {
            get
            {
                if (ViewState["TotalCustomerAmount"] == null)
                {
                    ViewState["TotalCustomerAmount"] = "0.00";
                }
                return ViewState["TotalCustomerAmount"].ToString();
            }
            set { ViewState["TotalCustomerAmount"] = value; }
        }
        public string TotalShabakaAmount
        {
            get
            {
                if (ViewState["TotalShabakaAmount"] == null)
                {
                    ViewState["TotalShabakaAmount"] = "0.00";
                }
                return ViewState["TotalShabakaAmount"].ToString();
            }
            set { ViewState["TotalShabakaAmount"] = value; }
        }
        public double? TotalShabakaAmount2
        {
            get
            {
                if (ViewState["TotalShabakaAmount2"] == null)
                {
                    ViewState["TotalShabakaAmount2"] = "0.00";
                }
                return moh.StrToDouble(ViewState["TotalShabakaAmount2"].ToString());
            }
            set { ViewState["TotalShabakaAmount2"] = value.ToString(); }
        }
        public string TotalShabakaDiscount
        {
            get
            {
                if (ViewState["TotalShabakaDiscount"] == null)
                {
                    ViewState["TotalShabakaDiscount"] = "0.00";
                }
                return ViewState["TotalShabakaDiscount"].ToString();
            }
            set { ViewState["TotalShabakaDiscount"] = value; }
        }        
        public string TotalDepositAmount
        {
            get
            {
                if (ViewState["TotalDepositAmount"] == null)
                {
                    ViewState["TotalDepositAmount"] = "0.00";
                }
                return ViewState["TotalDepositAmount"].ToString();
            }
            set { ViewState["TotalDepositAmount"] = value; }
        }
        public string TotalDepositAmount2
        {
            get
            {
                if (ViewState["TotalDepositAmount2"] == null)
                {
                    ViewState["TotalDepositAmount2"] = "0.00";
                }
                return ViewState["TotalDepositAmount2"].ToString();
            }
            set { ViewState["TotalDepositAmount2"] = value; }
        }
        public string TotalDiscountAmount
        {
            get
            {
                if (ViewState["TotalDiscountAmount"] == null)
                {
                    ViewState["TotalDiscountAmount"] = "0.00";
                }
                return ViewState["TotalDiscountAmount"].ToString();
            }
            set { ViewState["TotalDiscountAmount"] = value; }
        }
        public string TotalVAT
        {
            get
            {
                if (ViewState["TotalVAT"] == null)
                {
                    ViewState["TotalVAT"] = "0.00";
                }
                return ViewState["TotalVAT"].ToString();
            }
            set { ViewState["TotalVAT"] = value; }
        }
        public string TotalLoanAmount
        {
            get
            {
                if (ViewState["TotalLoanAmount"] == null)
                {
                    ViewState["TotalLoanAmount"] = "0.00";
                }
                return ViewState["TotalLoanAmount"].ToString();
            }
            set { ViewState["TotalLoanAmount"] = value; }
        }
        public string TotalPayAmount
        {
            get
            {
                if (ViewState["TotalPayAmount"] == null)
                {
                    ViewState["TotalPayAmount"] = "0.00";
                }
                return ViewState["TotalPayAmount"].ToString();
            }
            set { ViewState["TotalPayAmount"] = value; }
        }
        public string TotalPayAdd
        {
            get
            {
                if (ViewState["TotalPayAdd"] == null)
                {
                    ViewState["TotalPayAdd"] = "0.00";
                }
                return ViewState["TotalPayAdd"].ToString();
            }
            set { ViewState["TotalPayAdd"] = value; }
        }
        public string TotalLoanAmount2
        {
            get
            {
                if (ViewState["TotalLoanAmount2"] == null)
                {
                    ViewState["TotalLoanAmount2"] = "0.00";
                }
                return ViewState["TotalLoanAmount2"].ToString();
            }
            set { ViewState["TotalLoanAmount2"] = value; }
        }
        public List<InvoiceStatement> MyOver
        {
            get
            {
                if (ViewState["MyOver"] == null)
                {
                    ViewState["MyOver"] = new List<InvoiceStatement>();
                }
                return (List<InvoiceStatement>)ViewState["MyOver"];
            }
            set { ViewState["MyOver"] = value; }
        }
        public string vRoleName
        {
            get
            {
                if (ViewState["RoleName"] == null)
                {
                    ViewState["RoleName"] = "Roll";
                }
                return ViewState["RoleName"].ToString();
            }
            set { ViewState["RoleName"] = value; }
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
                    this.Page.Header.Title = "الحركة اليومية للفرع";

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
                        UserTran.Description = "اختيار عرض الحركة اليومية للفرع";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    CostCenter myCostCenter = new CostCenter();
                    myCostCenter.Branch =1 ;
                    if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlBranch.DataTextField = "Name1";
                    ddlBranch.DataValueField = "Code";
                    ddlBranch.DataSource = (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()]);
                    ddlBranch.DataBind();
                    ddlBranch.Items.Insert(0, new ListItem("جميع الفروع", "-1", true));
                    ddlBranch.Items.Insert(0, new ListItem("أجماليات الفروع", "-2", true));

                    
                    ddlBranch.SelectedValue = AreaNo;

                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    vRoleName = moh.GetCurrentRole(ddlBranch.SelectedValue, (from useritm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                                                            where useritm.UserName == Session["CurrentUser"].ToString()
                                                                            select useritm).FirstOrDefault());
                    if (Session[vRoleName] == null)
                    {
                        Response.Redirect("WebNotPrev.aspx", false);
                        return;
                    }
                    ddlBranch.Enabled = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass411;
                    ChkPeriod.Text = String.Format("يوم : {0:dd/MM/yyyy}", moh.Nows());

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
                if (grdCodes.Columns != null)
                {
                    grdCodes.Columns[2].Visible = (ddlBranch.SelectedValue != "-2");
                    grdCodes.Columns[3].Visible = (ddlBranch.SelectedValue != "-2");
                    grdCodes.Columns[4].Visible = (ddlBranch.SelectedValue != "-2");
                    grdCodes.Columns[5].Visible = (ddlBranch.SelectedValue != "-2");
                    grdCodes.Columns[14].Visible = (ddlBranch.SelectedValue != "-2");
                    grdCodes.Columns[17].Visible = (ddlBranch.SelectedValue == "-2");
                    grdCodes.Columns[18].Visible = (ddlBranch.SelectedValue != "-2");
                    grdCodes.Columns[21].Visible = (ddlBranch.SelectedValue != "-2");
                }

                if (lblCount.Text == "")
                {
                    lblCount.Text = MyOver.Count().ToString();
                    MakeSum();
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
                    Label lblTotalCar = grdCodes.FooterRow.FindControl("lblTotalCar") as Label;
                    Label lblTotalSiteAmount = grdCodes.FooterRow.FindControl("lblTotalSiteAmount") as Label;
                    Label lblTotalCashAmount = grdCodes.FooterRow.FindControl("lblTotalCashAmount") as Label;
                    Label lblTotalCreditAmount = grdCodes.FooterRow.FindControl("lblTotalCreditAmount") as Label;
                    Label lblTotalCustomerAmount = grdCodes.FooterRow.FindControl("lblTotalCustomerAmount") as Label;
                    Label lblTotalDiscountAmount = grdCodes.FooterRow.FindControl("lblTotalDiscountAmount") as Label;
                    Label lblTotalDepositAmount = grdCodes.FooterRow.FindControl("lblTotalDepositAmount") as Label;
                    Label lblTotalDepositAmount2 = grdCodes.FooterRow.FindControl("lblTotalDepositAmount2") as Label;
                    Label lblTotalLoanAmount = grdCodes.FooterRow.FindControl("lblTotalLoanAmount") as Label;
                    Label lblTotalPayAmount = grdCodes.FooterRow.FindControl("lblTotalPayAmount") as Label;
                    Label lblTotalVAT = grdCodes.FooterRow.FindControl("lblTotalVAT") as Label;
                    Label lblTotalLoanAmount2 = grdCodes.FooterRow.FindControl("lblTotalLoanAmount2") as Label;
                    Label lblTotalShabakaAmount = grdCodes.FooterRow.FindControl("lblTotalShabakaAmount") as Label;
                    Label lblTotalShabakaDiscount = grdCodes.FooterRow.FindControl("lblTotalShabakaDiscount") as Label;
                    Label lblTotalPayAdd = grdCodes.FooterRow.FindControl("lblTotalPayAdd") as Label;

                    double SiteAmount = 0, CashAmount = 0, CreditAmount = 0, CustomerAmount = 0, DiscountAmount = 0, DepositAmount = 0, DepositAmount2 = 0, LoanAmount = 0, PayAmount = 0, LoanAmount2 = 0, ShabakaAmount = 0, ShabakaDiscount = 0 , PayAdd = 0 , VAT = 0;
                    int CarIn = 0, CarOut = 0;
                    TotalCashAmount2 = 0;
                    TotalShabakaAmount2 = 0;

                    foreach (InvoiceStatement itm in MyOver)
                    {
                        if (itm.CarType != "")
                        {
                            int k = 0;
                            if (itm.CarType.Contains('س'))
                            {
                                int.TryParse(itm.CarType.Split(' ')[0],out k);
                                CarOut += k;
                                TotalCashAmount2 += itm.CashAmount;
                                TotalShabakaAmount2 += itm.ShabakaAmount;
                            }
                            else
                            {
                                int.TryParse(itm.CarType.Split(' ')[0],out k);
                                CarIn += k;
                            }
                        }
                        SiteAmount += itm.SiteAmount;
                        CashAmount += itm.CashAmount;
                        CreditAmount += itm.CreditAmount;
                        CustomerAmount += itm.CustomerAmount;
                        DiscountAmount += itm.DiscountAmount;
                        DepositAmount += itm.DepositAmount;
                        VAT += itm.VAT;
                        if (ddlBranch.SelectedValue == "-2")
                        {
                            DepositAmount2 += itm.DepositAmount2;
                        }
                        else
                        {
                            DepositAmount2 = itm.DepositAmount2;
                        }
                        
                        LoanAmount += itm.LoanAmount;
                        PayAmount += itm.PayAmount;
                        PayAdd += itm.PayAdd;
                        LoanAmount2 += itm.LoanAmount2;
                        ShabakaAmount += itm.ShabakaAmount;
                        ShabakaDiscount += itm.ShabakaDiscount;
                    }

                    if (lblTotalCar != null)
                    {
                        lblTotalCar.Text = string.Format("{0} س & {1} و", CarOut.ToString(), CarIn.ToString());
                        TotalCars = lblTotalCar.Text;
                    }
                    if (lblTotalSiteAmount != null)
                    {
                        lblTotalSiteAmount.Text = string.Format("{0:N2}", SiteAmount);
                        TotalSiteAmount = lblTotalSiteAmount.Text;
                    }
                    if (lblTotalCashAmount != null)
                    {
                        lblTotalCashAmount.Text = string.Format("{0:N2}", CashAmount);
                        TotalCashAmount = lblTotalCashAmount.Text;
                    }
                    if (lblTotalCreditAmount != null)
                    {
                        lblTotalCreditAmount.Text = string.Format("{0:N2}", CreditAmount);
                        TotalCreditAmount = lblTotalCreditAmount.Text;
                    }
                    if (lblTotalCustomerAmount != null)
                    {
                        lblTotalCustomerAmount.Text = string.Format("{0:N2}", CustomerAmount);
                        TotalCustomerAmount = lblTotalCustomerAmount.Text;
                    }
                    if (lblTotalVAT != null)
                    {
                        lblTotalVAT.Text = string.Format("{0:N2}", VAT);
                        TotalVAT = lblTotalVAT.Text;
                    }
                    if (lblTotalDiscountAmount != null)
                    {
                        lblTotalDiscountAmount.Text = string.Format("{0:N2}", DiscountAmount);
                        TotalDiscountAmount = lblTotalDiscountAmount.Text;
                    }
                    if (lblTotalDepositAmount != null)
                    {
                        lblTotalDepositAmount.Text = string.Format("{0:N2}", DepositAmount);
                        TotalDepositAmount = lblTotalDepositAmount.Text;
                    }
                    if (lblTotalDepositAmount2 != null)
                    {
                        lblTotalDepositAmount2.Text = string.Format("{0:N2}", DepositAmount2);
                        TotalDepositAmount2 = lblTotalDepositAmount2.Text;
                    }
                    if (lblTotalLoanAmount != null)
                    {
                        lblTotalLoanAmount.Text = string.Format("{0:N2}", LoanAmount);
                        TotalLoanAmount = lblTotalLoanAmount.Text;
                    }
                    if (lblTotalPayAmount != null)
                    {
                        lblTotalPayAmount.Text = string.Format("{0:N2}", PayAmount);
                        TotalPayAmount = lblTotalPayAmount.Text;
                    }
                    if (lblTotalPayAdd != null)
                    {
                        lblTotalPayAdd.Text = string.Format("{0:N2}", PayAdd);
                        TotalPayAdd = lblTotalPayAdd.Text;
                    }
                    if (lblTotalLoanAmount2 != null)
                    {
                        if (ddlBranch.SelectedValue == "-2")
                        {
                            lblTotalLoanAmount2.Text = string.Format("{0:N2}", LoanAmount2);
                            TotalLoanAmount2 = lblTotalLoanAmount2.Text;
                        }
                        else
                        {
                            lblTotalLoanAmount2.Text = TotalLoanAmount2;
                        }
                        
                    }
                    if (lblTotalShabakaAmount != null)
                    {
                        lblTotalShabakaAmount.Text = string.Format("{0:N2}", ShabakaAmount);
                        TotalShabakaAmount = lblTotalShabakaAmount.Text;
                    }
                    if (lblTotalShabakaDiscount != null)
                    {
                        lblTotalShabakaDiscount.Text = string.Format("{0:N2}", ShabakaDiscount);
                        TotalShabakaDiscount = lblTotalShabakaDiscount.Text;
                    }

                    lblLoanAdd.Text = lblTotalPayAdd.Text;
                    lblDeposit.Text = lblTotalDepositAmount.Text;
                    lblShabaka.Text = lblTotalShabakaAmount.Text;                    
                    lblShabakaDiscount.Text = lblTotalShabakaDiscount.Text;
                    lblShabakaNet.Text = string.Format("{0:N2}", moh.StrToDouble(lblShabaka.Text) - moh.StrToDouble(lblShabakaDiscount.Text));
                    lblCash.Text = string.Format("{0:N2}", moh.StrToDouble(lblTotalSiteAmount.Text) + moh.StrToDouble(lblTotalCashAmount.Text));
                    lblDiscount.Text = lblTotalDiscountAmount.Text;
                    lblTot.Text = string.Format("{0:N2}", moh.StrToDouble(lblOldBal.Text) + moh.StrToDouble(lblCash.Text));
                    //lblBal.Text = string.Format("{0:N2}", moh.StrToDouble(lblTot.Text) - (moh.StrToDouble(lblDeposit.Text) - moh.StrToDouble(lblShabakaNet.Text)));
                    lblBal.Text = lblTot.Text;
                    //lblIncome.Text = string.Format("{0:N2}", moh.StrToDouble(lblTotalCashAmount.Text) + moh.StrToDouble(lblTotalCreditAmount.Text) + moh.StrToDouble(lblTotalCustomerAmount.Text) - moh.StrToDouble(lblTotalVAT.Text));
                    lblIncome.Text = string.Format("{0:N2}", TotalCashAmount2 + TotalShabakaAmount2 + moh.StrToDouble(lblTotalCreditAmount.Text) + moh.StrToDouble(lblTotalCustomerAmount.Text) - moh.StrToDouble(lblTotalVAT.Text));
                    lblVat2.Text = lblTotalVAT.Text;
                    lblPay.Text = lblTotalPayAmount.Text;
                    lblNetDeposit.Text = string.Format("{0:N2}", moh.StrToDouble(lblDeposit.Text) - moh.StrToDouble(lblShabakaNet.Text));
                    if (ddlBranch.SelectedValue == "-1" || ddlBranch.SelectedValue == "-2")
                    {
                       // lblLoan.Text = lblTotalLoanAmount.Text;
                       // lblLoan2.Text = string.Format("{0:N2}", moh.StrToDouble(lblLoan.Text) - moh.StrToDouble(lblPay.Text));
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
                    Transactions UserTran = new Transactions();
                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                    UserTran.UserName = Session["CurrentUser"].ToString();
                    UserTran.FormName = "الحركة اليومية للفرع";
                    UserTran.FormAction = "طباعة";
                    UserTran.Description = "اختيار طباعة الحركة اليومية للفرع " + ddlBranch.SelectedItem.Text + " " + (ChkPeriod.Checked ? String.Format("{0:dd/MM/yyyy}", moh.Nows()) :   " عن الفترة من " + txtFDate.Text + " إلى " + txtEDate.Text);
                    UserTran.IP = IPNetworking.GetIP4Address();
                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                }

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

                CostCenter myCost = new CostCenter();
                myCost.Branch = 1;
                myCost.Code = Request.QueryString["AreaNo"] != null ? Request.QueryString["AreaNo"].ToString() : Session["AreaNo"].ToString();
                myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                          where citm.Code == myCost.Code
                          select citm).FirstOrDefault();
                page.vStr4 = myCost!=null ? myCost.Name1 : "";
                if (ddlBranch.SelectedIndex > 1)
                {
                    if (ChkPeriod.Checked)
                    {
                        page.vStr1 = " حركة " + ddlBranch.SelectedItem.Text + " عن يوم " + moh.Days[((int)moh.Nows().DayOfWeek) + 1 == 7 ? 0 : ((int)moh.Nows().DayOfWeek) + 1] + " الموافق " + String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    }
                    else
                    {
                        page.vStr1 = " حركة " + ddlBranch.SelectedItem.Text + " عن الفترة من " + txtFDate.Text + " إلى " + txtEDate.Text;
                    }
                }
                else
                {
                    if (ChkPeriod.Checked)
                    {
                        page.vStr1 = (ddlBranch.SelectedValue=="-2" ? "أجمالي " : "") +  " حركة جميع الفروع " + " عن يوم " + moh.Days[((int)moh.Nows().DayOfWeek) + 1] + " الموافق " + String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    }
                    else
                    {
                        page.vStr1 = (ddlBranch.SelectedValue=="-2" ? "أجمالي " : "") + " حركة جميع الفروع " + " عن الفترة من " + txtFDate.Text + " إلى " + txtEDate.Text;
                    }             
                }
                page.Branch2 = ddlBranch.SelectedValue;

                //-------------------------------------------------------------------------------------------                    
                document.Open();
                //-------------------------------------------------------------------------------------------                    

                //string arialunicodepath = Server.MapPath("Fonts") + @"\arial.ttf";
                string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                float hsize = (ddlBranch.SelectedValue == "-2" ? 11f : 9f);
                float dsize = (ddlBranch.SelectedValue == "-2" ? 10f : 8f);

                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, dsize, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font nationalTextFont2 = new iTextSharp.text.Font(nationalBase, hsize, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font nationalTextFont14 = new iTextSharp.text.Font(nationalBase, 13f, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font nationalTextFont16 = new iTextSharp.text.Font(nationalBase, 15f, iTextSharp.text.Font.NORMAL);
                //-------------------------------------------------------------------------------------------                    
                //document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                //-------------------------------------------------------------------------------------------                    
                var cols = new[] { 1200 };
                document.Open();
                PdfPTable table = new PdfPTable(1);
                if (ddlBranch.SelectedValue == "-2")
                {
                    cols = new[] { 85,85,85,85,85,85,85,85,85,85,85,85,85,85,85,180,50 };
                    table = new PdfPTable(17);
                }
                else
                {
                    cols = new[] { 67,67,67,67,67,67,67,67,67,67,67,67,67,67,67,67,67,67,67,67,67,67, 150, 50 };
                    table = new PdfPTable(24);
                }
                table.TotalWidth = document.PageSize.Width; //100f;
                table.SetWidths(cols);
                PdfPCell cell = new PdfPCell();
                //cell.FixedHeight = 20f;

                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                if (MyOver != null && MyOver.Count > 0)
                {
                    foreach (InvoiceStatement inv in MyOver)
                    {
                        if (ddlBranch.SelectedValue == "-2")
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(inv.FNo.ToString(), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(inv.Customer, nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.SiteAmount), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.CashAmount), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.ShabakaAmount), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.ShabakaDiscount), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.CreditAmount), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.CustomerAmount), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.DiscountAmount), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.VAT), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.DepositAmount), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.DepositAmount2), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.LoanAmount), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.PayAmount), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.PayAdd), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.LoanAmount2), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase("    ", nationalTextFont);
                            table.AddCell(cell);

                        }
                        else
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(inv.FNo.ToString(), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(inv.Customer, nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(inv.CarType, nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(inv.Location, nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(inv.InvoiceNo, nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(inv.VouNo, nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.SiteAmount), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.CashAmount), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.ShabakaAmount), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.ShabakaDiscount), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.CreditAmount), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.CustomerAmount), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.DiscountAmount), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.VAT), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(inv.DepositNo, nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.DepositAmount), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.DepositAmount2), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.LoanAmount), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(inv.PayNo, nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.PayAmount), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(inv.CarMoveNo, nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.PayAdd), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.LoanAmount2), nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase("    ", nationalTextFont);
                            table.AddCell(cell);
                        }
                    }


                    if (ddlBranch.SelectedValue == "-2")
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("الاجمالي", nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalSiteAmount, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalCashAmount, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalShabakaAmount, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalShabakaDiscount, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalCreditAmount, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalCustomerAmount, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalDiscountAmount, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalVAT, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalDepositAmount, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalDepositAmount2, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalLoanAmount, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalPayAmount, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalPayAdd, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalLoanAmount2, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("    ", nationalTextFont);
                        table.AddCell(cell);

                    }
                    else
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("الاجمالي", nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalCars, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalSiteAmount, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalCashAmount, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalShabakaAmount, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalShabakaDiscount, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalCreditAmount, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalCustomerAmount, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalDiscountAmount, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalVAT, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalDepositAmount, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalDepositAmount2, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalLoanAmount, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalPayAmount, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalPayAdd, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(TotalLoanAmount2, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("    ", nationalTextFont);
                        table.AddCell(cell);
                    }

                }
                cell.Border = 0;
                cell.Phrase = new iTextSharp.text.Phrase("    ", nationalTextFont);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                if (ddlBranch.SelectedValue != "-2")
                {
                    table.AddCell(cell);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    table.AddCell(cell);
                }
                document.Add(table);

                page.Header = false;
                table = new PdfPTable(1);
                table.TotalWidth = document.PageSize.Width; //100f;
                cols = new[] { 1400 };
                table.SetWidths(cols);
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell = new PdfPCell();
                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.Border = 0;

                if (ddlBranch.SelectedIndex > 1)
                {
                    if (ChkPeriod.Checked)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(" ملخص حركة " + ddlBranch.SelectedItem.Text + " عن يوم " + moh.Days[((int)moh.Nows().DayOfWeek) + 1 == 7 ? 0 : ((int)moh.Nows().DayOfWeek) + 1] + " الموافق " + String.Format("{0:dd/MM/yyyy}", moh.Nows()), nationalTextFont16);
                    }
                    else
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(" ملخص حركة " + ddlBranch.SelectedItem.Text + " عن الفترة من " + txtFDate.Text + " إلى " + txtEDate.Text, nationalTextFont16);
                    }
                }
                else
                {
                    if (ChkPeriod.Checked)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase((ddlBranch.SelectedValue == "-2" ? "ملخص أجمالي " : " ملخص ") + " حركة جميع الفروع " + " عن يوم " + moh.Days[((int)moh.Nows().DayOfWeek) + 1] + " الموافق " + String.Format("{0:dd/MM/yyyy}", moh.Nows()), nationalTextFont16);
                    }
                    else
                    {
                        cell.Phrase = new iTextSharp.text.Phrase((ddlBranch.SelectedValue == "-2" ? "ملخص أجمالي " : " ملخص ") + " حركة جميع الفروع " + " عن الفترة من " + txtFDate.Text + " إلى " + txtEDate.Text, nationalTextFont16);
                    }
                }
                table.AddCell(cell);
                document.Add(table);

                table = new PdfPTable(14);
                table.TotalWidth = document.PageSize.Width; //100f;
                cols = new[] {110,110,110,110,110,110,110,110,110,110,110,110,110,110};
                table.SetWidths(cols);
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell = new PdfPCell();
                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                cell.Phrase = new iTextSharp.text.Phrase("الأجمالي", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("عملاء", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("آجل", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("نقدي", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("رصيد النقدية مرحل", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("متحصلات نقدية", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("الخصومات", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("الضريبة", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("أيداعات نقدية", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("رصيد النقدية نهاية الفترة", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("أيداع الشبكة", nationalTextFont2);
                table.AddCell(cell);


                cell.Phrase = new iTextSharp.text.Phrase("رصيد العهده قبل", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("قيمة الصرف", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("رصيد العهدة بعد", nationalTextFont2);
                table.AddCell(cell);
//------------------------------------------

                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", moh.StrToDouble(TotalCustomerAmount) + moh.StrToDouble(TotalCreditAmount) + moh.StrToDouble(TotalCashAmount)), nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalCustomerAmount, nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalCreditAmount, nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalCashAmount, nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(lblOldBal.Text, nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(lblCash.Text, nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalDiscountAmount, nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalVAT, nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalDepositAmount, nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(lblBal.Text, nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(lblShabakaNet.Text, nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(lblLoan.Text, nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(lblPay.Text, nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(lblLoan2.Text, nationalTextFont2);
                table.AddCell(cell);

                document.Add(table);
//------------------------------------------------------------------------------
                if (ddlBranch.SelectedValue == "-2")
                {
                    table = new PdfPTable(5);
                    table.TotalWidth = document.PageSize.Width; //100f;
                    cols = new[] { 250, 250, 250, 250, 250 };
                    table.SetWidths(cols);
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell = new PdfPCell();
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.Border = 0;

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont2);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    //--------------------------------------------------------
                    table.AddCell(cell);
                    cell.Phrase = new iTextSharp.text.Phrase("موظف الاستقبال", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont2);
                    table.AddCell(cell);
                    cell.Phrase = new iTextSharp.text.Phrase("مراقب الفرع", nationalTextFont2);
                    table.AddCell(cell);
                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont2);
                    table.AddCell(cell);
                    //--------------------------------------------------------------
                    table.AddCell(cell);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    table.AddCell(cell);
                    //--------------------------------------------------------
                    table.AddCell(cell);
                    cell.Phrase = new iTextSharp.text.Phrase("--------------------", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont2);
                    table.AddCell(cell);
                    cell.Phrase = new iTextSharp.text.Phrase("--------------------", nationalTextFont2);
                    table.AddCell(cell);
                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont2);
                    table.AddCell(cell);
                    //----------------------------------------------------------------------------------------
                    document.Add(table);
                }
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
            public string vStr1, vStr2, vStr3, vStr4, UserName, PageNo, vCompanyName,Branch2;
            public bool Header = true;
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
                iTextSharp.text.Font nationalTextFont16 = new iTextSharp.text.Font(nationalBase, 16f, iTextSharp.text.Font.NORMAL);

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
                cell2.Phrase = new iTextSharp.text.Phrase(vStr1, nationalTextFont16);
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
                if (Header)
                {
                    float hsize = (Branch2 == "-2" ? 11f : 9f);
                    iTextSharp.text.Font nationalTextFont2 = new iTextSharp.text.Font(nationalBase, hsize, iTextSharp.text.Font.NORMAL);
                    PdfPTable table = new PdfPTable(1);
                    //doc.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    //-------------------------------------------------------------------------------------------
                    var cols = new[] { 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 180, 50 };
                    if (Branch2 == "-2")
                    {
                        cols = new[] { 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 85, 180, 50 };
                        table = new PdfPTable(17);
                    }
                    else
                    {
                        cols = new[] { 67, 67, 67, 67, 67, 67, 67, 67, 67, 67, 67, 67, 67, 67, 67, 67, 67, 67, 67, 67, 67, 67, 150, 50 };
                        table = new PdfPTable(24);
                    }
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


                    cell.Phrase = new iTextSharp.text.Phrase("م", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("مرسل السيارة/العميل", nationalTextFont2);
                    table.AddCell(cell);

                    if (Branch2 != "-2")
                    {
                        cell.Phrase = new iTextSharp.text.Phrase("نوع السيارة", nationalTextFont2);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("جهة الترحيل", nationalTextFont2);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("اتفاقية شحن", nationalTextFont2);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("سند قبض", nationalTextFont2);
                        table.AddCell(cell);
                    }
                    //
                    cell.Phrase = new iTextSharp.text.Phrase("فروع", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("نقدي", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("شبكة", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("خصم شبكة", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("آجل", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("عملاء", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("خصومات", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الضريبة", nationalTextFont2);
                    table.AddCell(cell);

                    if (Branch2 != "-2")
                    {
                        cell.Phrase = new iTextSharp.text.Phrase("قسيمة الايداع", nationalTextFont2);
                        table.AddCell(cell);
                    }

                    cell.Phrase = new iTextSharp.text.Phrase("ايداع بنكي", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الرصيد بدون ايداع", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("رصيد العهده", nationalTextFont2);
                    table.AddCell(cell);

                    if (Branch2 != "-2")
                    {
                        cell.Phrase = new iTextSharp.text.Phrase("سند الصرف", nationalTextFont2);
                        table.AddCell(cell);
                    }

                    cell.Phrase = new iTextSharp.text.Phrase("قيمة الصرف", nationalTextFont2);
                    table.AddCell(cell);

                    if (Branch2 != "-2")
                    {
                        cell.Phrase = new iTextSharp.text.Phrase("بيان ترحيل", nationalTextFont2);
                        table.AddCell(cell);
                    }

                    cell.Phrase = new iTextSharp.text.Phrase("استعاضة العهدة", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("رصيد العهده بعد", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("ملاحظات", nationalTextFont2);
                    table.AddCell(cell);
                    doc.Add(table);
                }
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
            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
            {
                Transactions UserTran = new Transactions();
                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                UserTran.UserName = Session["CurrentUser"].ToString();
                UserTran.FormName = "الحركة اليومية للفرع";
                UserTran.FormAction = "تصدير";
                UserTran.Description = "اختيار تصدير الحركة اليومية للفرع " + ddlBranch.SelectedItem.Text + " " + (ChkPeriod.Checked ? String.Format("{0:dd/MM/yyyy}", moh.Nows()) : " عن الفترة من " + txtFDate.Text + " إلى " + txtEDate.Text);
                UserTran.IP = IPNetworking.GetIP4Address();
                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
            }

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

        protected void ChkPeriod_CheckedChanged(object sender, EventArgs e)
        {
            LblFDate.Visible = !ChkPeriod.Checked;
            LblEDate.Visible = !ChkPeriod.Checked;
            txtFDate.Visible = !ChkPeriod.Checked;
            txtEDate.Visible = !ChkPeriod.Checked;

            ChkPeriod.Text = ChkPeriod.Checked ? String.Format("يوم : {0:dd/MM/yyyy}", moh.Nows()) : "خلال الفترة";

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

                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                {
                    Transactions UserTran = new Transactions();
                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                    UserTran.UserName = Session["CurrentUser"].ToString();
                    UserTran.FormName = "الحركة اليومية للفرع";
                    UserTran.FormAction = "عرض";
                    UserTran.Description = "اختيار عرض الحركة اليومية للفرع " + ddlBranch.SelectedItem.Text + " " + (ChkPeriod.Checked ? String.Format("{0:dd/MM/yyyy}", moh.Nows()) : " عن الفترة من " + txtFDate.Text + " إلى " + txtEDate.Text);
                    UserTran.IP = IPNetworking.GetIP4Address();
                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                }

                lblCount.Text = "";
                string vLoanCode = "";
                MyOver.Clear();
                if (ddlBranch.SelectedValue == "-1" || ddlBranch.SelectedValue == "-2")
                {
                    lblOldBal.Text = string.Format("{0:N2}", moh.GetBal("120102", String.Format("{0:dd/MM/yyyy}", ChkPeriod.Checked ? moh.Nows().AddDays(-1) : DateTime.Parse(txtFDate.Text).AddDays(-1)), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    lblLoan.Text = string.Format("{0:N2}", moh.GetBal("120103", String.Format("{0:dd/MM/yyyy}", ChkPeriod.Checked ? moh.Nows().AddDays(-1) : DateTime.Parse(txtFDate.Text).AddDays(-1)), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)); // - moh.GetBal("120103016", String.Format("{0:dd/MM/yyyy}", ChkPeriod.Checked ? moh.Nows().AddDays(-1) : DateTime.Parse(txtFDate.Text).AddDays(-1)), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    lblLoan2.Text = string.Format("{0:N2}", moh.GetBal("120103", String.Format("{0:dd/MM/yyyy}", ChkPeriod.Checked ? moh.Nows() : DateTime.Parse(txtEDate.Text)), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)); // - moh.GetBal("120103016", String.Format("{0:dd/MM/yyyy}", ChkPeriod.Checked ? moh.Nows() : DateTime.Parse(txtEDate.Text)), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    vLoanCode = "120103";
                }
                else
                {                   
                    CostCenter myCost = new CostCenter();
                    myCost.Branch = 1;
                    if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCost.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myCost.Code = ddlBranch.SelectedValue;
                    myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                              where citm.Code == myCost.Code
                              select citm).FirstOrDefault();
                    if (myCost != null)
                    {
                        lblOldBal.Text = string.Format("{0:N2}", moh.GetBal(myCost.CashAcc, String.Format("{0:dd/MM/yyyy}", ChkPeriod.Checked ? moh.Nows().AddDays(-1) : DateTime.Parse(txtFDate.Text).AddDays(-1)), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        lblLoan.Text = string.Format("{0:N2}", moh.GetBal(myCost.LoanAcc, String.Format("{0:dd/MM/yyyy}", ChkPeriod.Checked ? moh.Nows().AddDays(-1) : DateTime.Parse(txtFDate.Text).AddDays(-1)), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        lblLoan2.Text = string.Format("{0:N2}", moh.GetBal(myCost.LoanAcc, String.Format("{0:dd/MM/yyyy}", ChkPeriod.Checked ? moh.Nows() : DateTime.Parse(txtEDate.Text)), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        vLoanCode = myCost.LoanAcc;
                    }
                    else
                    {
                        lblOldBal.Text = string.Format("{0:N2}", 0);
                        lblLoan.Text = string.Format("{0:N2}", 0);
                        lblLoan2.Text = string.Format("{0:N2}", 0);
                    }
                }
                Invoice myInv = new Invoice();
                myInv.Branch = short.Parse(Session["Branch"].ToString());
                myInv.VouLoc = (ddlBranch.SelectedValue == "-2" ? "-1" : ddlBranch.SelectedValue);
                int i = 1;
                string vOldLoc = "";
                string vLoc = "";
                foreach (Invoice inv in myInv.GetStatement(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, ChkPeriod.Checked ? String.Format("{0:dd/MM/yyyy}", moh.Nows()) : txtFDate.Text, ChkPeriod.Checked ? "" : txtEDate.Text))
                {
                    if (ddlBranch.SelectedValue == "-2" && vOldLoc != inv.VouLoc )
                    {
                        CostCenter myCost = new CostCenter();
                        myCost.Branch = 1;
                        myCost.Code = inv.VouLoc;
                        myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                  where citm.Code == myCost.Code
                                  select citm).FirstOrDefault();
                        if (myCost != null)
                        {
                            vLoc = myCost.Name1;
                            vOldLoc = inv.VouLoc;
                        }
                    }
                    Cities myCity = new Cities();
                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                    myCity.Code = inv.Destination;
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                              where sitm.Code == myCity.Code
                              select sitm).FirstOrDefault();

                    MyOver.Add(new InvoiceStatement
                    {
                        FNo = i++,
                        Customer = (ddlBranch.SelectedValue == "-2" ? vLoc : inv.Name),
                        CashAmount = (double)inv.CashAmount,
                        ShabakaAmount = (double)inv.ShAmount,
                        ShabakaDiscount = (double)(inv.ShAmount !=0  ? (Math.Round((double)inv.ShAmount * ((double)inv.ShAmount <= 100 ? 0.007 : 0.008), 2) > 160 ? 160 : Math.Round((double)inv.ShAmount * ((double)inv.ShAmount <= 100 ? 0.007 : 0.008), 2)) : 0),
                        Site = inv.VouLoc,
                        OpenBal = 0,
                        SiteAmount = 0,
                        VAT = (double)inv.Tax,
                        CustomerAmount = (double)inv.CustomerAmount,
                        CreditAmount = (double)inv.SiteAmount,
                        DiscountAmount = 0,
                        CarType = inv.Qty.ToString() + " س ",
                        Location = myCity != null ? myCity.Name1 : "",
                        DepositAmount = (double)(inv.ShAmount != 0 ? inv.ShAmount - (Math.Round((double)inv.ShAmount * ((double)inv.ShAmount <= 100 ? 0.007 : 0.008), 2) > 160 ? 160 : Math.Round((double)inv.ShAmount * ((double)inv.ShAmount <= 100 ? 0.007 : 0.008), 2)) : 0),
                        DepositNo = "",
                        InvoiceNo = int.Parse(inv.VouLoc).ToString() + "/" + inv.VouNo.ToString(),
                        VouNo = "",
                        LoanAmount = 0,
                        PayAmount = 0,
                        PayNo = "",
                        CarMoveNo = "",
                        PayAdd = 0,
                        Qty = 0
                    });
                }

                Shipment myInv1 = new Shipment();
                myInv1.Branch = short.Parse(Session["Branch"].ToString());
                myInv1.VouLoc = (ddlBranch.SelectedValue == "-2" ? "-1" : ddlBranch.SelectedValue);                
                vOldLoc = "";
                vLoc = "";
                foreach (Shipment inv in myInv1.GetStatement(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, ChkPeriod.Checked ? String.Format("{0:dd/MM/yyyy}", moh.Nows()) : txtFDate.Text, ChkPeriod.Checked ? "" : txtEDate.Text))
                {
                    if (ddlBranch.SelectedValue == "-2" && vOldLoc != inv.VouLoc)
                    {
                        CostCenter myCost = new CostCenter();
                        myCost.Branch = 1;
                        myCost.Code = inv.VouLoc;
                        myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                  where citm.Code == myCost.Code
                                  select citm).FirstOrDefault();
                        if (myCost != null)
                        {
                            vLoc = myCost.Name1;
                            vOldLoc = inv.VouLoc;
                        }
                    }
                    Cities myCity = new Cities();
                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                    myCity.Code = inv.Destination;
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                              where sitm.Code == myCity.Code
                              select sitm).FirstOrDefault();

                    MyOver.Add(new InvoiceStatement
                    {
                        FNo = i++,
                        Customer = (ddlBranch.SelectedValue == "-2" ? vLoc : inv.Name),
                        CashAmount = (double)inv.CashAmount,
                        ShabakaAmount = (double)inv.ShabakaAmount,
                        ShabakaDiscount = (double)(inv.ShabakaAmount > 0 ? (Math.Round((double)inv.ShabakaAmount * 0.004, 2) > 40 ? 40 : Math.Round((double)inv.ShabakaAmount * 0.004, 2)) : 0),
                        Site = inv.VouLoc,
                        OpenBal = 0,
                        SiteAmount = 0,
                        CustomerAmount = (double)inv.CustomerAmount,
                        CreditAmount = (double)inv.SiteAmount,
                        DiscountAmount = 0,
                        VAT = (double)inv.Tax,
                        CarType = inv.Qty.ToString() + " ط ",
                        Location = myCity != null ? myCity.Name1 : "",
                        DepositAmount = (double)(inv.CashAmount + inv.ShabakaAmount - (Math.Round((double)inv.ShabakaAmount * 0.004, 2) > 40 ? 40 : Math.Round((double)inv.ShabakaAmount * 0.004, 2))),
                        DepositNo = "",
                        InvoiceNo = "E"+int.Parse(inv.VouLoc).ToString() + "/" + inv.VouNo.ToString(),
                        VouNo = "",
                        LoanAmount = 0,
                        PayAmount = 0,
                        PayNo = "",
                        CarMoveNo = "",
                        PayAdd = 0,
                        Qty = 0
                    });
                }

                LShipment myInv2 = new LShipment();
                myInv2.Branch = short.Parse(Session["Branch"].ToString());
                myInv2.VouLoc = (ddlBranch.SelectedValue == "-2" ? "-1" : ddlBranch.SelectedValue);
                vOldLoc = "";
                vLoc = "";
                foreach (LShipment inv in myInv2.GetStatement(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, ChkPeriod.Checked ? String.Format("{0:dd/MM/yyyy}", moh.Nows()) : txtFDate.Text, ChkPeriod.Checked ? "" : txtEDate.Text))
                {
                    if (ddlBranch.SelectedValue == "-2" && vOldLoc != inv.VouLoc)
                    {
                        CostCenter myCost = new CostCenter();
                        myCost.Branch = 1;
                        myCost.Code = inv.VouLoc;
                        myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                  where citm.Code == myCost.Code
                                  select citm).FirstOrDefault();
                        if (myCost != null)
                        {
                            vLoc = myCost.Name1;
                            vOldLoc = inv.VouLoc;
                        }
                    }
                    Cities myCity = new Cities();
                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                    myCity.Code = inv.Destination;
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                              where sitm.Code == myCity.Code
                              select sitm).FirstOrDefault();

                    MyOver.Add(new InvoiceStatement
                    {
                        FNo = i++,
                        Customer = (ddlBranch.SelectedValue == "-2" ? vLoc : inv.Name),
                        CashAmount = (double)inv.CashAmount,
                        ShabakaAmount = (double)inv.ShabakaAmount,
                        ShabakaDiscount = (double)(inv.ShabakaAmount > 0 ? (Math.Round((double)inv.ShabakaAmount * 0.004, 2) > 40 ? 40 : Math.Round((double)inv.ShabakaAmount * 0.004, 2)) : 0),
                        Site = inv.VouLoc,
                        OpenBal = 0,
                        SiteAmount = 0,
                        CustomerAmount = (double)inv.CustomerAmount,
                        CreditAmount = (double)inv.SiteAmount,
                        VAT = (double)inv.Tax,
                        DiscountAmount = 0,
                        CarType = inv.Qty.ToString() + " ش ",
                        Location = myCity != null ? myCity.Name1 : "",
                        DepositAmount = (double)(inv.CashAmount + inv.ShabakaAmount - (Math.Round((double)inv.ShabakaAmount * 0.004, 2) > 40 ? 40 : Math.Round((double)inv.ShabakaAmount * 0.004, 2))),
                        DepositNo = "",
                        InvoiceNo = "L" + int.Parse(inv.VouLoc).ToString() + "/" + inv.VouNo.ToString(),
                        VouNo = "",
                        LoanAmount = 0,
                        PayAmount = 0,
                        PayNo = "",
                        CarMoveNo = "",
                        PayAdd = 0,
                        Qty = 0
                    });
                }


                Jv myJv = new Jv();
                myJv.Branch = short.Parse(Session["Branch"].ToString());
                myJv.FType = -1;
                myJv.LocType = -1;
                myJv.LocNumber = short.Parse((ddlBranch.SelectedValue == "-2" ? "-1" : ddlBranch.SelectedValue));
                myJv.LocNumber = -1;
                double vDisc = 0,vSh = 0;
                foreach (Jv itm in myJv.GetStatement(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, ChkPeriod.Checked ? String.Format("{0:dd/MM/yyyy}", moh.Nows()) : txtFDate.Text, ChkPeriod.Checked ? "" : txtEDate.Text))
                {
                        if (itm.FType == 101 && itm.LocType == 2)
                        {
                            if (ddlBranch.SelectedValue != "-1" && ddlBranch.SelectedValue != "-2")
                            {
                                if (itm.LocNumber != short.Parse(ddlBranch.SelectedValue))
                                {
                                    continue;
                                }
                            }

                            if (itm.DocType == 1 && itm.DbCode != "" && !itm.DbCode.StartsWith("310201"))
                            {
                                if (ddlBranch.SelectedValue == "-2" && vOldLoc != moh.MakeMask(itm.LocNumber.ToString(), 5))
                                {
                                    CostCenter myCost = new CostCenter();
                                    myCost.Branch = 1;
                                    myCost.Code = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                    myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                              where citm.Code == myCost.Code
                                              select citm).FirstOrDefault();
                                    if (myCost != null)
                                    {
                                        vLoc = myCost.Name1;
                                        vOldLoc = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                    }
                                }

                                if (itm.DbCode != "" && itm.DbCode.StartsWith("310201"))
                                {
                                    if (ddlBranch.SelectedValue == "-2" && vOldLoc != moh.MakeMask(itm.LocNumber.ToString(), 5))
                                    {
                                        CostCenter myCost = new CostCenter();
                                        myCost.Branch = 1;
                                        myCost.Code = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                        myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                                  where citm.Code == myCost.Code
                                                  select citm).FirstOrDefault();
                                        if (myCost != null)
                                        {
                                            vLoc = myCost.Name1;
                                            vOldLoc = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                        }
                                    }

                                    MyOver.Add(new InvoiceStatement
                                    {
                                        FNo = i++,
                                        Customer = (ddlBranch.SelectedValue == "-2" ? vLoc : "خصومات"),
                                        Site = moh.MakeMask(itm.LocNumber.ToString(), 5),
                                        OpenBal = 0,
                                        CashAmount = 0,
                                        SiteAmount = 0,
                                        CustomerAmount = 0,
                                        CreditAmount = 0,
                                        CarType = " وارد ",
                                        Location = "",
                                        DepositAmount = 0,
                                        DiscountAmount = (double)itm.Amount,
                                        DepositNo = "",
                                        InvoiceNo = "",
                                        VouNo = itm.LocNumber.ToString() + "/" + itm.Number.ToString(),
                                        LoanAmount = 0,
                                        PayAmount = 0,
                                        PayNo = "",
                                        CarMoveNo = "",
                                        PayAdd = 0,
                                        ShabakaAmount = 0,
                                        ShabakaDiscount = 0,
                                        Qty = 0
                                    });
                                    if (itm.DocType == 2) vDisc = (double)itm.Amount;
                                }
                                    //--------------------------------------- New
                                
                                else if (itm.DbCode != "" && itm.DbCode.StartsWith("310102027"))
                                    {
                                        if (ddlBranch.SelectedValue == "-2" && vOldLoc != moh.MakeMask(itm.LocNumber.ToString(), 5))
                                        {
                                            CostCenter myCost = new CostCenter();
                                            myCost.Branch = 1;
                                            myCost.Code = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                            myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                                      where citm.Code == myCost.Code
                                                      select citm).FirstOrDefault();
                                            if (myCost != null)
                                            {
                                                vLoc = myCost.Name1;
                                                vOldLoc = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                            }
                                        }

                                        MyOver.Add(new InvoiceStatement
                                        {
                                            FNo = i++,
                                            Customer = (ddlBranch.SelectedValue == "-2" ? vLoc : "سند قبض شبكة"),
                                            Site = moh.MakeMask(itm.LocNumber.ToString(), 5),
                                            OpenBal = 0,
                                            CashAmount = 0,
                                            SiteAmount = 0,
                                            CustomerAmount = 0,
                                            CreditAmount = 0,
                                            CarType = "0" + " وارد ",
                                            Location = "",
                                            DepositAmount = vSh,
                                            DiscountAmount = 0,
                                            DepositNo = "",
                                            InvoiceNo = "",
                                            VouNo = itm.LocNumber.ToString() + "/" + itm.Number.ToString(),
                                            LoanAmount = 0,
                                            PayAmount = 0,
                                            PayNo = "",
                                            CarMoveNo = "",
                                            PayAdd = 0,
                                            ShabakaAmount = vSh + (double)itm.Amount,
                                            ShabakaDiscount = (double)itm.Amount,
                                            Qty = 0
                                        });
                                        vSh = 0;
                                }
                                else if (itm.DbCode != "" && itm.DbCode.StartsWith(moh.MadaAcc))
                                {
                                    if (ddlBranch.SelectedValue == "-2" && vOldLoc != moh.MakeMask(itm.LocNumber.ToString(), 5))
                                    {
                                        CostCenter myCost = new CostCenter();
                                        myCost.Branch = 1;
                                        myCost.Code = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                        myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                                  where citm.Code == myCost.Code
                                                  select citm).FirstOrDefault();
                                        if (myCost != null)
                                        {
                                            vLoc = myCost.Name1;
                                            vOldLoc = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                        }
                                    }

                                    vSh = (double)itm.Amount;
                                    /*
                                    MyOver.Add(new InvoiceStatement
                                    {
                                        FNo = i++,
                                        Customer = (ddlBranch.SelectedValue == "-2" ? vLoc : "تحصيلات شبكة"),
                                        Site = moh.MakeMask(itm.LocNumber.ToString(), 5),
                                        OpenBal = 0,
                                        CashAmount = 0,
                                        SiteAmount = 0,
                                        CustomerAmount = 0,
                                        CreditAmount = 0,
                                        CarType = " وارد ",
                                        Location = "",
                                        DepositAmount = (double)itm.Amount,
                                        DiscountAmount = 0,
                                        DepositNo = "",
                                        InvoiceNo = "",
                                        VouNo = itm.LocNumber.ToString() + "/" + itm.Number.ToString(),
                                        LoanAmount = 0,
                                        PayAmount = 0,
                                        PayNo = "",
                                        CarMoveNo = "",
                                        PayAdd = 0,
                                        ShabakaAmount = (double)itm.Amount,
                                        ShabakaDiscount = 0
                                    });
                                     */
                                }

                                else if (itm.DbCode != "" && itm.DbCode.StartsWith("120102"))
                                {
                                    MyOver.Add(new InvoiceStatement
                                    {
                                        FNo = i++,
                                        Customer = (ddlBranch.SelectedValue == "-2" ? vLoc : "سند قبض عملاء"),
                                        Site = moh.MakeMask(itm.LocNumber.ToString(), 5),
                                        OpenBal = 0,
                                        CashAmount = (double)itm.Amount,
                                        ShabakaAmount = 0,
                                        ShabakaDiscount = 0,
                                        SiteAmount = 0,
                                        CustomerAmount = 0,
                                        CreditAmount = 0,
                                        DiscountAmount = 0,
                                        CarType = "0" + " وارد ",
                                        Location = "",
                                        DepositAmount = (double)itm.Amount,
                                        DepositNo = "",
                                        InvoiceNo = "",
                                        VouNo = itm.LocNumber.ToString() + "/" + itm.Number.ToString(),
                                        LoanAmount = 0,
                                        PayAmount = 0,
                                        PayNo = "",
                                        CarMoveNo = "",
                                        PayAdd = 0,
                                        Qty = 0
                                    });
                                }
                            }
                            else if (itm.DbCode != "" && itm.DbCode.StartsWith("120102"))
                            {
                                MyOver.Add(new InvoiceStatement
                                {
                                    FNo = i++,
                                    Customer = (ddlBranch.SelectedValue == "-2" ? vLoc : "سند قبض "),
                                    Site = moh.MakeMask(itm.LocNumber.ToString(), 5),
                                    OpenBal = 0,
                                    CashAmount = (double)itm.Amount,
                                    ShabakaAmount = 0,
                                    ShabakaDiscount = 0,
                                    SiteAmount = 0,
                                    CustomerAmount = 0,
                                    CreditAmount = 0,
                                    DiscountAmount = 0,
                                    CarType = "0" + " وارد ",
                                    Location = "",
                                    DepositAmount = (double)itm.Amount,
                                    DepositNo = "",
                                    InvoiceNo = "",
                                    VouNo = itm.LocNumber.ToString() + "/" + itm.Number.ToString(),
                                    LoanAmount = 0,
                                    PayAmount = 0,
                                    PayNo = "",
                                    CarMoveNo = "",
                                    PayAdd = 0,
                                    Qty = 0
                                });
                                vDisc = 0;
                            }
                            else if (itm.InvNo != "")
                            {
                                if (ddlBranch.SelectedValue == "-2" && vOldLoc != moh.MakeMask(itm.LocNumber.ToString(), 5))
                                {
                                    CostCenter myCost = new CostCenter();
                                    myCost.Branch = 1;
                                    myCost.Code = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                    myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                              where citm.Code == myCost.Code
                                              select citm).FirstOrDefault();
                                    if (myCost != null)
                                    {
                                        vLoc = myCost.Name1;
                                        vOldLoc = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                    }
                                }
                                if (itm.InvNo[0] == 'E')
                                {
                                    string vInvNo = itm.InvNo.Substring(1, itm.InvNo.Length - 1);
                                    myInv1 = new Shipment();
                                    myInv1.Branch = short.Parse(Session["Branch"].ToString());
                                    myInv1.VouLoc = moh.MakeMask(vInvNo.Split('/')[0], 5);
                                    myInv1.VouNo = int.Parse(itm.InvNo.Split('/')[1]);
                                    myInv1 = myInv1.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (myInv1 != null)
                                    {
                                        MyOver[MyOver.Count() - 1].Qty = MyOver[MyOver.Count() - 1].Qty + myInv1.Qty;
                                        MyOver[MyOver.Count() - 1].CarType = (MyOver[MyOver.Count() - 1].Qty + myInv1.Qty).ToString() + " وارد ";
                                        /*
                                        Cities myCity = new Cities();
                                        myCity.Branch = short.Parse(Session["Branch"].ToString());
                                        myCity.Code = myInv1.PlaceofLoading;
                                        if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                        myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                                  where sitm.Code == myCity.Code
                                                  select sitm).FirstOrDefault();

                                        MyOver.Add(new InvoiceStatement
                                        {
                                            FNo = i++,
                                            Customer = (ddlBranch.SelectedValue == "-2" ? vLoc : myInv1.Name),
                                            Site = moh.MakeMask(itm.LocNumber.ToString(), 5),
                                            OpenBal = 0,
                                            CashAmount = 0,
                                            ShabakaAmount = (double)(itm.Payment == 2 ? itm.Amount - vDisc : 0),
                                            ShabakaDiscount = (double)(itm.Payment == 2 ? (Math.Round(((double)itm.Amount - vDisc) * 0.004, 2) > 40 ? 40 : Math.Round(((double)itm.Amount - vDisc) * 0.004, 2)) : 0),
                                            SiteAmount = (double)(itm.Payment == 2 ? 0 : itm.Amount - vDisc),
                                            CustomerAmount = 0,
                                            CreditAmount = 0,
                                            DiscountAmount = 0,
                                            CarType = myInv1.Qty.ToString() + " وارد ",
                                            Location = myCity != null ? myCity.Name1 : "",
                                            DepositAmount = (double)(itm.Payment == 2 ? itm.Amount - vDisc - (Math.Round(((double)itm.Amount - vDisc) * 0.004, 2) > 40 ? 40 : Math.Round(((double)itm.Amount - vDisc) * 0.004, 2)) : 0),
                                            DepositNo = "",
                                            InvoiceNo = itm.InvNo,
                                            VouNo = itm.LocNumber.ToString() + "/" + itm.Number.ToString(),
                                            LoanAmount = 0,
                                            PayAmount = 0,
                                            PayNo = "",
                                            CarMoveNo = "",
                                            PayAdd = 0
                                        });
                                        vDisc = 0;
                                         */
                                    }
                                }
                                else if (itm.InvNo[0] == 'L')
                                {
                                    string vInvNo = itm.InvNo.Substring(1, itm.InvNo.Length - 1);
                                    myInv2 = new LShipment();
                                    myInv2.Branch = short.Parse(Session["Branch"].ToString());
                                    myInv2.VouLoc = moh.MakeMask(vInvNo.Split('/')[0], 5);
                                    myInv2.VouNo = int.Parse(itm.InvNo.Split('/')[1]);
                                    myInv2 = myInv2.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (myInv != null)
                                    {
                                        MyOver[MyOver.Count() - 1].Qty = MyOver[MyOver.Count() - 1].Qty + myInv2.Qty;
                                        MyOver[MyOver.Count() - 1].CarType = (MyOver[MyOver.Count() - 1].Qty + myInv2.Qty).ToString() + " وارد ";
                                        /*
                                        Cities myCity = new Cities();
                                        myCity.Branch = short.Parse(Session["Branch"].ToString());
                                        myCity.Code = myInv2.PlaceofLoading;
                                        if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                        myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                                  where sitm.Code == myCity.Code
                                                  select sitm).FirstOrDefault();

                                        MyOver.Add(new InvoiceStatement
                                        {
                                            FNo = i++,
                                            Customer = (ddlBranch.SelectedValue == "-2" ? vLoc : myInv2.Name),
                                            Site = moh.MakeMask(itm.LocNumber.ToString(), 5),
                                            OpenBal = 0,
                                            CashAmount = 0,
                                            ShabakaAmount = (double)(itm.Payment == 2 ? itm.Amount - vDisc : 0),
                                            ShabakaDiscount = (double)(itm.Payment == 2 ? (Math.Round(((double)itm.Amount - vDisc) * 0.004, 2) > 40 ? 40 : Math.Round(((double)itm.Amount - vDisc) * 0.004, 2)) : 0),
                                            SiteAmount = (double)(itm.Payment == 2 ? 0 : itm.Amount - vDisc),
                                            CustomerAmount = 0,
                                            CreditAmount = 0,
                                            DiscountAmount = 0,
                                            CarType = myInv2.Qty.ToString() + " وارد ",
                                            Location = myCity != null ? myCity.Name1 : "",
                                            DepositAmount = (double)(itm.Payment == 2 ? itm.Amount - vDisc - (Math.Round(((double)itm.Amount - vDisc) * 0.004, 2) > 40 ? 40 : Math.Round(((double)itm.Amount - vDisc) * 0.004, 2)) : 0),
                                            DepositNo = "",
                                            InvoiceNo = itm.InvNo,
                                            VouNo = itm.LocNumber.ToString() + "/" + itm.Number.ToString(),
                                            LoanAmount = 0,
                                            PayAmount = 0,
                                            PayNo = "",
                                            CarMoveNo = "",
                                            PayAdd = 0
                                        });
                                        vDisc = 0;
                                         */
                                    }
                                }
                                else
                                {
                                    myInv = new Invoice();
                                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                                    myInv.VouLoc = moh.MakeMask(itm.InvNo.Split('/')[0], 5);
                                    myInv.VouNo = int.Parse(itm.InvNo.Split('/')[1]);
                                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (myInv != null)
                                    {
                                        MyOver[MyOver.Count() - 1].Qty = MyOver[MyOver.Count() - 1].Qty + myInv.Qty;
                                        MyOver[MyOver.Count() - 1].CarType = (MyOver[MyOver.Count() - 1].Qty + myInv.Qty).ToString() + " وارد ";
                                        /*
                                        Cities myCity = new Cities();
                                        myCity.Branch = short.Parse(Session["Branch"].ToString());
                                        myCity.Code = myInv.PlaceofLoading;
                                        if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                        myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                                  where sitm.Code == myCity.Code
                                                  select sitm).FirstOrDefault();

                                        MyOver.Add(new InvoiceStatement
                                        {
                                            FNo = i++,
                                            Customer = (ddlBranch.SelectedValue == "-2" ? vLoc : myInv.Name),
                                            Site = moh.MakeMask(itm.LocNumber.ToString(), 5),
                                            OpenBal = 0,
                                            CashAmount = 0,
                                            ShabakaAmount = (double)(itm.Payment == 2 ? itm.Amount - vDisc : 0),
                                            ShabakaDiscount = (double)(itm.Payment == 2 ? (Math.Round(((double)itm.Amount - vDisc) * 0.004, 2) > 40 ? 40 : Math.Round(((double)itm.Amount - vDisc) * 0.004, 2)) : 0),
                                            SiteAmount = (double)(itm.Payment == 2 ? 0 : itm.Amount - vDisc),
                                            CustomerAmount = 0,
                                            CreditAmount = 0,
                                            DiscountAmount = 0,
                                            CarType = myInv.Qty.ToString() + " وارد ",
                                            Location = myCity != null ? myCity.Name1 : "",
                                            DepositAmount = (double)(itm.Payment == 2 ? itm.Amount - vDisc - (Math.Round(((double)itm.Amount - vDisc) * 0.004, 2) > 40 ? 40 : Math.Round(((double)itm.Amount - vDisc) * 0.004, 2)) : 0),
                                            DepositNo = "",
                                            InvoiceNo = itm.InvNo,
                                            VouNo = itm.LocNumber.ToString() + "/" + itm.Number.ToString(),
                                            LoanAmount = 0,
                                            PayAmount = 0,
                                            PayNo = "",
                                            CarMoveNo = "",
                                            PayAdd = 0
                                        });
                                        vDisc = 0;
                                         */
                                    }
                                }
                            }
                            else if (itm.DbCode != "" && itm.DbCode.StartsWith("310201"))
                            {
                                if (ddlBranch.SelectedValue == "-2" && vOldLoc != moh.MakeMask(itm.LocNumber.ToString(), 5))
                                {
                                    CostCenter myCost = new CostCenter();
                                    myCost.Branch = 1;
                                    myCost.Code = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                    myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                              where citm.Code == myCost.Code
                                              select citm).FirstOrDefault();
                                    if (myCost != null)
                                    {
                                        vLoc = myCost.Name1;
                                        vOldLoc = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                    }
                                }

                                MyOver.Add(new InvoiceStatement
                                {
                                    FNo = i++,
                                    Customer = (ddlBranch.SelectedValue == "-2" ? vLoc : "خصومات"),
                                    Site = moh.MakeMask(itm.LocNumber.ToString(), 5),
                                    OpenBal = 0,
                                    CashAmount = 0,
                                    SiteAmount = 0,
                                    CustomerAmount = 0,
                                    CreditAmount = 0,
                                    CarType = "0" + " وارد ",
                                    Location = "",
                                    DepositAmount = 0,
                                    DiscountAmount = (double)itm.Amount,
                                    DepositNo = "",
                                    InvoiceNo = "",
                                    VouNo = itm.LocNumber.ToString() + "/" + itm.Number.ToString(),
                                    LoanAmount = 0,
                                    PayAmount = 0,
                                    PayNo = "",
                                    CarMoveNo = "",
                                    PayAdd = 0,
                                    ShabakaAmount = 0,
                                    ShabakaDiscount = 0,
                                    Qty = 0
                                });
                                if (itm.DocType == 2) vDisc = (double)itm.Amount;
                            }
                            //--------------------------------------- New
                            else if (itm.DbCode != "" && itm.DbCode.StartsWith("310102027"))
                            {
                                if (ddlBranch.SelectedValue == "-2" && vOldLoc != moh.MakeMask(itm.LocNumber.ToString(), 5))
                                {
                                    CostCenter myCost = new CostCenter();
                                    myCost.Branch = 1;
                                    myCost.Code = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                    myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                              where citm.Code == myCost.Code
                                              select citm).FirstOrDefault();
                                    if (myCost != null)
                                    {
                                        vLoc = myCost.Name1;
                                        vOldLoc = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                    }
                                }

                                MyOver.Add(new InvoiceStatement
                                {
                                    FNo = i++,
                                    Customer = (ddlBranch.SelectedValue == "-2" ? vLoc : "سند قبض شبكة"),
                                    Site = moh.MakeMask(itm.LocNumber.ToString(), 5),
                                    OpenBal = 0,
                                    CashAmount = 0,
                                    SiteAmount = 0,
                                    CustomerAmount = 0,
                                    CreditAmount = 0,
                                    CarType = "0" + " وارد ",
                                    Location = "",
                                    DepositAmount = vSh,
                                    DiscountAmount = 0,
                                    DepositNo = "",
                                    InvoiceNo = "",
                                    VouNo = itm.LocNumber.ToString() + "/" + itm.Number.ToString(),
                                    LoanAmount = 0,
                                    PayAmount = 0,
                                    PayNo = "",
                                    CarMoveNo = "",
                                    PayAdd = 0,
                                    ShabakaAmount = vSh + (double)itm.Amount,
                                    ShabakaDiscount = (double)itm.Amount,
                                    Qty = 0
                                });
                                vSh = 0;
                            }
                            else if (itm.DbCode != "" && itm.DbCode.StartsWith(moh.MadaAcc))
                            {
                                if (ddlBranch.SelectedValue == "-2" && vOldLoc != moh.MakeMask(itm.LocNumber.ToString(), 5))
                                {
                                    CostCenter myCost = new CostCenter();
                                    myCost.Branch = 1;
                                    myCost.Code = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                    myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                              where citm.Code == myCost.Code
                                              select citm).FirstOrDefault();
                                    if (myCost != null)
                                    {
                                        vLoc = myCost.Name1;
                                        vOldLoc = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                    }
                                }

                                vSh = (double)itm.Amount;
                                /*

                                MyOver.Add(new InvoiceStatement
                                {
                                    FNo = i++,
                                    Customer = (ddlBranch.SelectedValue == "-2" ? vLoc : "تحصيلات شبكة"),
                                    Site = moh.MakeMask(itm.LocNumber.ToString(), 5),
                                    OpenBal = 0,
                                    CashAmount = 0,
                                    SiteAmount = 0,
                                    CustomerAmount = 0,
                                    CreditAmount = 0,
                                    CarType = " وارد ",
                                    Location = "",
                                    DepositAmount = 0,
                                    DiscountAmount = 0,
                                    DepositNo = "",
                                    InvoiceNo = "",
                                    VouNo = itm.LocNumber.ToString() + "/" + itm.Number.ToString(),
                                    LoanAmount = 0,
                                    PayAmount = 0,
                                    PayNo = "",
                                    CarMoveNo = "",
                                    PayAdd = 0,
                                    ShabakaAmount = (double)itm.Amount,
                                    ShabakaDiscount = 0
                                });
                                 */
                            }
                             
                        }
                        else if (itm.FType == 105 && itm.LocType == 2)
                        {
                            if (itm.DbCode != "")
                            {
                                if (ddlBranch.SelectedValue != "-1" && ddlBranch.SelectedValue != "-2")
                                {
                                    if (itm.LocNumber != short.Parse(ddlBranch.SelectedValue))
                                    {
                                        continue;
                                    }
                                }

                                if (ddlBranch.SelectedValue == "-2" && vOldLoc != moh.MakeMask(itm.LocNumber.ToString(), 5))
                                {
                                    CostCenter myCost = new CostCenter();
                                    myCost.Branch = 1;
                                    myCost.Code = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                    myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                              where citm.Code == myCost.Code
                                              select citm).FirstOrDefault();
                                    if (myCost != null)
                                    {
                                        vLoc = myCost.Name1;
                                        vOldLoc = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                    }
                                }
                                MyOver.Add(new InvoiceStatement
                                {
                                    FNo = i++,
                                    Customer = (ddlBranch.SelectedValue == "-2" ? vLoc : "قسيمة إيداع بتاريخ " + itm.FDate),
                                    Site = moh.MakeMask(itm.LocNumber.ToString(), 5),
                                    OpenBal = 0,
                                    CashAmount = 0,
                                    SiteAmount = 0,
                                    CustomerAmount = 0,
                                    CreditAmount = 0,
                                    DiscountAmount = 0,
                                    CarType = "",
                                    Location = "",
                                    DepositAmount = (double)itm.Amount,
                                    DepositNo = itm.LocNumber.ToString() + "/" + itm.Number.ToString(),
                                    InvoiceNo = "",
                                    VouNo = "",
                                    LoanAmount = 0,
                                    PayAmount = 0,
                                    PayNo = "",
                                    CarMoveNo = "",
                                    PayAdd = 0,
                                    ShabakaAmount = 0,
                                    ShabakaDiscount = 0,
                                    Qty = 0
                                });
                            }
                        }
                        else if (itm.FType == 102 && itm.LocType == 2)
                        {
                            if (itm.DocType == 2)
                            {
                                if (itm.DbCode != "")
                                {
                                    if (ddlBranch.SelectedValue == "-2" && vOldLoc != moh.MakeMask(itm.LocNumber.ToString(), 5))
                                    {
                                        CostCenter myCost = new CostCenter();
                                        myCost.Branch = 1;
                                        myCost.Code = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                        myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                                  where citm.Code == myCost.Code
                                                  select citm).FirstOrDefault();
                                        if (myCost != null)
                                        {
                                            vLoc = myCost.Name1;
                                            vOldLoc = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                        }
                                    }
                                    if (ddlBranch.SelectedValue != "-1" && ddlBranch.SelectedValue != "-2")
                                    {
                                        if (itm.LocNumber != short.Parse(ddlBranch.SelectedValue))
                                        {
                                            continue;
                                        }
                                    }

                                    MyOver.Add(new InvoiceStatement
                                    {
                                        FNo = i++,
                                        Customer = (ddlBranch.SelectedValue == "-2" ? vLoc : "سند صرف بتاريخ " + itm.FDate),
                                        Site = moh.MakeMask(itm.LocNumber.ToString(), 5),
                                        OpenBal = 0,
                                        CashAmount = 0,
                                        SiteAmount = 0,
                                        CustomerAmount = 0,
                                        CreditAmount = 0,
                                        DiscountAmount = 0,
                                        CarType = "",
                                        Location = "",
                                        DepositAmount = 0,
                                        DepositNo = "",
                                        InvoiceNo = "",
                                        VouNo = "",
                                        LoanAmount = 0,
                                        PayAmount = (double)itm.Amount,
                                        PayNo = itm.LocNumber.ToString() + "/" + itm.Number.ToString(),
                                        CarMoveNo = itm.InvNo,
                                        PayAdd = 0,
                                        ShabakaAmount = 0,
                                        ShabakaDiscount = 0,
                                        Qty = 0
                                    });
                                }
                            }
                            else
                            {
                                if (itm.DbCode != "")
                                {
                                    if (ddlBranch.SelectedValue != "-1" && ddlBranch.SelectedValue != "-2")
                                    {
                                        if (itm.LocNumber != short.Parse(ddlBranch.SelectedValue))
                                        {
                                            continue;
                                        }
                                    }
                                    if (ddlBranch.SelectedValue == "-2" && vOldLoc != moh.MakeMask(itm.LocNumber.ToString(), 5))
                                    {
                                        CostCenter myCost = new CostCenter();
                                        myCost.Branch = 1;
                                        myCost.Code = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                        myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                                  where citm.Code == myCost.Code
                                                  select citm).FirstOrDefault();
                                        if (myCost != null)
                                        {
                                            vLoc = myCost.Name1;
                                            vOldLoc = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                        }
                                    }
                                    MyOver.Add(new InvoiceStatement
                                    {
                                        FNo = i++,
                                        Customer = (ddlBranch.SelectedValue == "-2" ? vLoc : itm.Remark),
                                        Site = moh.MakeMask(itm.LocNumber.ToString(), 5),
                                        OpenBal = 0,
                                        CashAmount = 0,
                                        ShabakaAmount = (double)(itm.Payment == 2 ? itm.Amount : 0),
                                        ShabakaDiscount = (double)(itm.Payment == 2 ? (Math.Round((double)itm.Amount * 0.004, 2) > 40 ? 40 : Math.Round((double)itm.Amount * 0.004, 2)) : 0),
                                        SiteAmount = 0,
                                        CustomerAmount = 0,
                                        CreditAmount = 0,
                                        DiscountAmount = 0,
                                        CarType = "",
                                        Location = "",
                                        DepositAmount = (double)(itm.Payment == 2 ? itm.Amount - (Math.Round((double)itm.Amount * 0.004, 2) > 40 ? 40 : Math.Round((double)itm.Amount * 0.004, 2)) : 0),
                                        DepositNo = "",
                                        InvoiceNo = "",
                                        VouNo = "",
                                        LoanAmount = 0,
                                        PayAmount = (double)itm.Amount,
                                        PayNo = "",
                                        CarMoveNo = itm.InvNo,
                                        PayAdd = 0,
                                        Qty = 0
                                    });
                                }
                            }
                        }
                        else
                        {
                            if (itm.DbCode != "" && itm.DbCode.StartsWith(vLoanCode))
                            {
                                string vSite = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                if (ddlBranch.SelectedValue == "-2")
                                {
                                    CostCenter myCostCenter = new CostCenter();
                                    myCostCenter.Branch = 1;
                                    myCostCenter.Code = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                    if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                    //myCost = myCost.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    bool vFound = false;
                                    foreach (CostCenter itemCost in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])) 
                                    {
                                        if (itm.DbCode == itemCost.LoanAcc)
                                        {
                                            vSite = itemCost.Code;
                                            vOldLoc = vSite;
                                            vLoc = itemCost.Name1;
                                            vFound = true;
                                            break;
                                        }
                                    }
                                    if (!vFound)
                                    {
                                        vSite = itm.DbCode;
                                        vOldLoc = itm.DbCode;
                                        vLoc = "حافظ";
                                    }

                                    //if (myCost != null)
                                    //{
                                    //    vLoc = myCost.Name1;
                                    //    vOldLoc = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                    //    if (itm.CrCode == myCost.LoanAcc)
                                    //    {
                                    //        continue;
                                    //    }
                                    //}
                                }
                                MyOver.Add(new InvoiceStatement
                                {
                                    FNo = i++,
                                    Customer = (ddlBranch.SelectedValue == "-2" ? vLoc : "أستعاضة عهدة بتاريخ " + itm.FDate),
                                    Site = vSite,
                                    OpenBal = 0,
                                    CashAmount = 0,
                                    SiteAmount = 0,
                                    CustomerAmount = 0,
                                    CreditAmount = 0,
                                    DiscountAmount = 0,
                                    CarType = "",
                                    Location = "",
                                    DepositAmount = 0,
                                    DepositNo = "",
                                    InvoiceNo = "",
                                    VouNo = "",
                                    LoanAmount = 0,
                                    PayAdd = (double)itm.Amount,
                                    PayAmount = 0,
                                    PayNo = itm.LocNumber.ToString() + "/" + itm.Number.ToString(),
                                    CarMoveNo = itm.InvNo,
                                    ShabakaAmount = 0,
                                    ShabakaDiscount = 0,
                                    Qty = 0
                                });
                            }
                            else if (itm.CrCode != "" && itm.CrCode.StartsWith(vLoanCode))
                            {
                                string vSite = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                if (ddlBranch.SelectedValue == "-2")
                                {
                                    CostCenter myCostCenter = new CostCenter();
                                    myCostCenter.Branch = 1;
                                    myCostCenter.Code = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                    if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                    //myCost = myCost.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    bool vFound = false;
                                    foreach (CostCenter itemCost in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()]))
                                    {
                                        if (itm.CrCode == itemCost.LoanAcc)
                                        {
                                            vFound = true;
                                            vSite = itemCost.Code;
                                            vOldLoc = vSite;
                                            vLoc = itemCost.Name1;
                                            break;
                                        }
                                    }
                                    if (!vFound)
                                    {
                                        vSite = itm.CrCode;
                                        vOldLoc = itm.CrCode;
                                        vLoc = "حافظ";
                                    }
                                    //if (myCost != null)
                                    //{
                                    //    vLoc = myCost.Name1;
                                    //    vOldLoc = moh.MakeMask(itm.LocNumber.ToString(), 5);
                                    //    if (itm.CrCode == myCost.LoanAcc)
                                    //    {
                                    //        continue;
                                    //    }
                                    //}
                                }
                                MyOver.Add(new InvoiceStatement
                                {
                                    FNo = i++,
                                    Customer = (ddlBranch.SelectedValue == "-2" ? vLoc : " صرف بتاريخ " + itm.FDate),
                                    Site = vSite,
                                    OpenBal = 0,
                                    CashAmount = 0,
                                    SiteAmount = 0,
                                    CustomerAmount = 0,
                                    CreditAmount = 0,
                                    DiscountAmount = 0,
                                    CarType = "",
                                    Location = "",
                                    DepositAmount = 0,
                                    DepositNo = "",
                                    InvoiceNo = "",
                                    VouNo = "",
                                    LoanAmount = 0,
                                    PayAmount = (double)itm.Amount,
                                    PayNo = itm.LocNumber.ToString() + "/" + itm.Number.ToString(),
                                    CarMoveNo = itm.InvNo,
                                    PayAdd = 0,
                                    ShabakaAmount = 0,
                                    ShabakaDiscount = 0,
                                    Qty = 0
                                });
                            }
                        }
                    }

                if (ddlBranch.SelectedValue == "-2")
                {
                    i = 1;
                    List<InvoiceStatement> lInv = new List<InvoiceStatement>();
                    lInv = (from itm in MyOver
                              group itm by new { itm.Customer , itm.Site }
                                  into g
                                  select new InvoiceStatement
                                  {
                                      FNo = i++,
                                      Customer = g.Key.Customer,
                                      Site = g.Key.Site,
                                      ShabakaDiscount = g.Sum(p => p.ShabakaDiscount),
                                      ShabakaAmount = g.Sum(p => p.ShabakaAmount),
                                      CashAmount = g.Sum(p => p.CashAmount),
                                      SiteAmount = g.Sum(p => p.SiteAmount),
                                      CustomerAmount = g.Sum(p => p.CustomerAmount),
                                      CreditAmount = g.Sum(p => p.CreditAmount),
                                      DiscountAmount = g.Sum(p => p.DiscountAmount),
                                      CarType = "",
                                      Location = "",
                                      DepositAmount = g.Sum(p => p.DepositAmount),
                                      DepositNo = "",
                                      InvoiceNo = "",
                                      OpenBal = GetBal(g.Key.Site),
                                      CarMoveNo = "",
                                      PayNo  = "",
                                      LoanAmount = GetBal2(g.Key.Site),
                                      PayAmount = g.Sum(p => p.PayAmount),
                                      LoanAmount2 =  GetBal2(g.Key.Site)  - g.Sum(p => p.PayAmount) + g.Sum(p => p.PayAdd),
                                      PayAdd = g.Sum(p => p.PayAdd),       
                                      VouNo = ""
                                  }).ToList();

                    CostCenter myCostCenter = new CostCenter();
                    myCostCenter.Branch = 1;
                    if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    foreach (CostCenter itm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()]))
                    {
                        bool vfind = false;
                        foreach (InvoiceStatement inv in lInv)
                        {
                            if (itm.Code == inv.Site)
                            {
                                vfind = true;
                                break;
                            }
                        }

                        if (!vfind)
                        {
                            lInv.Add(new InvoiceStatement
                            {
                                FNo = i++,
                                Customer = itm.Name1,
                                Site = itm.Code,
                                CashAmount = 0,
                                SiteAmount = 0,
                                CustomerAmount = 0,
                                CreditAmount = 0,
                                DiscountAmount = 0,
                                CarType = "",
                                Location = "",
                                DepositAmount = 0,
                                DepositNo = "",
                                InvoiceNo = "",
                                OpenBal = GetBal(itm.Code),
                                CarMoveNo = "",
                                PayNo = "",
                                LoanAmount = GetBal2(itm.Code),
                                PayAmount = 0,
                                VouNo = ""
                            });
                        }
                    }

                    bool vb = false;
                    foreach (InvoiceStatement inv in lInv)
                    {
                        if (inv.Site == "120103016")
                        {
                            inv.OpenBal = GetBal("120103016");
                            inv.LoanAmount = GetBal2("120103016");
                            vb = true;
                            break;
                        }
                    }
                    
                    if(!vb)
                    {
                            lInv.Add(new InvoiceStatement
                            {
                                FNo = i++,
                                Customer = "حافظ",
                                Site = "120103016",
                                CashAmount = 0,
                                SiteAmount = 0,
                                CustomerAmount = 0,
                                CreditAmount = 0,
                                DiscountAmount = 0,
                                CarType = "",
                                Location = "",
                                DepositAmount = 0,
                                DepositNo = "",
                                InvoiceNo = "",
                                OpenBal = GetBal("120103016"),
                                CarMoveNo = "",
                                PayNo = "",
                                LoanAmount = GetBal2("120103016"),
                                PayAmount = 0,
                                VouNo = ""
                            });                    
                    }

                    MyOver = lInv;
                }

                if (ddlBranch.SelectedValue != "-2")
                {
                    double loan = moh.StrToDouble(lblLoan.Text);
                    double depositam2 = moh.StrToDouble(lblOldBal.Text);
                    foreach (InvoiceStatement itm in MyOver)
                    {
                        loan += itm.PayAdd - itm.PayAmount;
                        itm.LoanAmount2 = loan;
                        depositam2 += itm.SiteAmount + itm.CashAmount - itm.DepositAmount + itm.ShabakaAmount - itm.ShabakaDiscount;
                        itm.DepositAmount2 = depositam2;
                    }
                    TotalLoanAmount2 = string.Format("{0:N2}", loan);
                }
                else
                {                    
                    foreach (InvoiceStatement itm in MyOver)
                    {
                        double depositam2 = 0;
                        CostCenter myCost = new CostCenter();
                        myCost.Branch = 1;
                        myCost.Code = itm.Site;
                        myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                  where citm.Code == myCost.Code
                                  select citm).FirstOrDefault();
                        if (myCost != null)
                        {
                            depositam2 =  moh.GetBal(myCost.CashAcc, String.Format("{0:dd/MM/yyyy}", ChkPeriod.Checked ? moh.Nows().AddDays(-1) : DateTime.Parse(txtFDate.Text).AddDays(-1)), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                        depositam2 += itm.SiteAmount + itm.CashAmount - itm.DepositAmount + itm.ShabakaAmount - itm.ShabakaDiscount;
                        itm.DepositAmount2 = depositam2;
                        itm.LoanAmount2 = itm.LoanAmount - itm.PayAmount + itm.PayAdd;
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

        public double GetBal(string SiteNo)
        {
            CostCenter myCost = new CostCenter();
            myCost.Branch = 1;
            myCost.Code = SiteNo;
            myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                      where citm.Code == myCost.Code
                      select citm).FirstOrDefault();
            if (myCost != null)
            {
                return moh.GetBal(myCost.CashAcc, String.Format("{0:dd/MM/yyyy}", ChkPeriod.Checked ? moh.Nows().AddDays(-1) : DateTime.Parse(txtFDate.Text).AddDays(-1)), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            }
            else return 0;
        }

        public double GetBal2(string SiteNo)
        {
            CostCenter myCost = new CostCenter();
            myCost.Branch = 1;
            myCost.Code = SiteNo;
            myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                      where citm.Code == myCost.Code
                      select citm).FirstOrDefault();
            if (myCost != null)
            {
                return moh.GetBal(myCost.LoanAcc, String.Format("{0:dd/MM/yyyy}", ChkPeriod.Checked ? moh.Nows().AddDays(-1) : DateTime.Parse(txtFDate.Text).AddDays(-1)), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            }
            else return moh.GetBal(SiteNo, String.Format("{0:dd/MM/yyyy}", ChkPeriod.Checked ? moh.Nows().AddDays(-1) : DateTime.Parse(txtFDate.Text).AddDays(-1)), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            //else return 0;
        }


        public double GetAllLoanBal()
        {
            double vBal = 0;
            CostCenter myCostCenter = new CostCenter();
            myCostCenter.Branch = 1;
            if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            foreach (CostCenter co in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()]))
            {
                vBal += moh.GetBal(co.LoanAcc, String.Format("{0:dd/MM/yyyy}", ChkPeriod.Checked ? moh.Nows().AddDays(-1) : DateTime.Parse(txtFDate.Text).AddDays(-1)), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            }
            return vBal;
        }

        protected string UrlHelper(object FType, object Number)
        {
            string[] vs = Number.ToString().Split('/');
            if (vs.Count() > 1)
            {
                switch (short.Parse(FType.ToString()))
                {
                    case 1: return (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass412 ? "~/WebInvoice.aspx?FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&Flag=0&StoreNo=" + StoreNo : "";
                    case 2: return (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass413 ? "~/WebRVou1.aspx?FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&Flag=0&StoreNo=" + StoreNo : "";
                    case 3: return (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass414 ? "~/WebBankPay.aspx?Flag=1&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&FMode=0&StoreNo=" + StoreNo : "";
                    case 4: return (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass415 ? "~/WebPay1.aspx?FType=2&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&Flag=0&StoreNo=" + StoreNo : "";
                    case 5: return (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass416 ? "~/WebCarMove.aspx?FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&Flag=0&StoreNo=" + StoreNo : "";
                    default: return "";
                }
            }
            else return "";
    }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
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