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
    public partial class WebDetailsItemCard : System.Web.UI.Page
    {
        public string TotalQuan
        {
            get
            {
                if (ViewState["TotalQuan"] == null)
                {
                    ViewState["TotalQuan"] = "0.00";
                }
                return ViewState["TotalQuan"].ToString();
            }
            set { ViewState["TotalQuan"] = value; }
        }
        public string TotalQuan2
        {
            get
            {
                if (ViewState["TotalQuan2"] == null)
                {
                    ViewState["TotalQuan2"] = "0.00";
                }
                return ViewState["TotalQuan2"].ToString();
            }
            set { ViewState["TotalQuan2"] = value; }
        }
        public string TotalAmount
        {
            get
            {
                if (ViewState["TotalAmount"] == null)
                {
                    ViewState["TotalAmount"] = "0.00";
                }
                return ViewState["TotalAmount"].ToString();
            }
            set { ViewState["TotalAmount"] = value; }
        }
        public string TotalAmount2
        {
            get
            {
                if (ViewState["TotalAmount2"] == null)
                {
                    ViewState["TotalAmount2"] = "0.00";
                }
                return ViewState["TotalAmount2"].ToString();
            }
            set { ViewState["TotalAmount2"] = value; }
        }
        public string TotalRemark
        {
            get
            {
                if (ViewState["TotalRemark"] == null)
                {
                    ViewState["TotalRemark"] = "";
                }
                return ViewState["TotalRemark"].ToString();
            }
            set { ViewState["TotalRemark"] = value; }
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
        public List<vSTS> MyOver
        {
            get
            {
                if (ViewState["MyOver"] == null)
                {
                    ViewState["MyOver"] = new List<vSTS>();
                }
                return (List<vSTS>)ViewState["MyOver"];
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
                BtnPrint1.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                BtnExcel.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnPrint1);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnExcel);

                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "حركة تفصيلية لصنف";

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
                        UserTran.Description = "اختيار عرض حركة تفصيلية لصنف";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    ICat myCat = new ICat();
                    ddlICat.DataTextField = "Name1";
                    ddlICat.DataValueField = "Code";
                    ddlICat.DataSource = myCat.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlICat.DataBind();

                    STS mysts = new STS();
                    ddlJob.DataSource = mysts.GetAllRef(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlJob.DataBind();

                    Cars myCar = new Cars();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlCar.DataTextField = "CarType2";
                    ddlCar.DataValueField = "Code";
                    ddlCar.DataSource = (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()]);
                    ddlCar.DataBind();
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

        protected void ChkCars_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ddlCar.Visible = !ChkCars.Checked;
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

        protected void ChkJob_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ddlJob.Visible = !ChkJob.Checked;
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

        protected void ChkICat_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ddlICat.Visible = !ChkICat.Checked;
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

        protected void ChkItems_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtItemCode.Visible = !ChkItems.Checked;
                txtITName.Visible = !ChkItems.Checked;
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



        protected void LoadCodesData()
        {
            try
            {
                grdCodes.DataSource = MyOver;
                grdCodes.DataBind();
                if (MyOver.Count() > 0)
                {
                    if (ChkItems.Checked)
                    {
                        grdCodes.Columns[3].Visible = true;
                        grdCodes.Columns[4].Visible = true;
                        grdCodes.Columns[7].Visible = false;
                    }
                    else
                    {
                        grdCodes.Columns[3].Visible = false;
                        grdCodes.Columns[4].Visible = false;
                        grdCodes.Columns[7].Visible = true;
                    }
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
                    Label lblTotalQuan = grdCodes.FooterRow.FindControl("lblTotalQuan") as Label;
                    Label lblTotalQuan2 = grdCodes.FooterRow.FindControl("lblTotalQuan2") as Label;
                    Label lblTotalAmount = grdCodes.FooterRow.FindControl("lblTotalAmount") as Label;
                    Label lblTotalAmount2 = grdCodes.FooterRow.FindControl("lblTotalAmount2") as Label;
                    Label lblTotalRemark = grdCodes.FooterRow.FindControl("lblTotalRemark") as Label;

                    if (lblTotalQuan != null)
                    {
                        lblTotalQuan.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Quan));
                        TotalQuan = lblTotalQuan.Text;
                    }
                    if (lblTotalQuan2 != null)
                    {
                        lblTotalQuan2.Text = string.Format("{0:N0}", MyOver.Sum(itm => itm.Quan2));
                        TotalQuan2 = lblTotalQuan2.Text;
                    }
                    if (lblTotalAmount != null)
                    {
                        lblTotalAmount.Text = string.Format("{0:N2}", MyOver.Sum(itm => itm.Amount));
                        TotalAmount = lblTotalAmount.Text;
                    }
                    if (lblTotalAmount2 != null)
                    {
                        lblTotalAmount2.Text = string.Format("{0:N2}", MyOver.Sum(itm => itm.Amount2));
                        TotalAmount2 = lblTotalAmount2.Text;
                    }
                    if (lblTotalRemark != null)
                    {
                        lblTotalRemark.Text = string.Format("الصافي : {0:N2}", moh.StrToDouble(TotalAmount2) - moh.StrToDouble(TotalAmount));
                        TotalRemark = lblTotalRemark.Text;
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
                    UserTran.FormName = "حركة تفصيلية لصنف";
                    UserTran.FormAction = "طباعة";
                    UserTran.Description = "اختيار حركة تفصيلية صنف " + (ChkItems.Checked ? "جميع الاصناف" : txtItemCode.Text) + " " + (this.ChkICat.Checked ? "جميع الانواع " : this.ddlICat.SelectedItem.Text) + " " + (this.ChkJob.Checked ? "جميع أوامر التشغيل " : this.ddlJob.SelectedItem.Text) + " " + (this.ChkCars.Checked ? "جميع الشاحنات " : this.ddlCar.SelectedItem.Text) + (ChkPeriod.Checked ? "جميع الفترات " : txtFDate.Text + " إلى " + txtEDate.Text);
                    UserTran.IP = IPNetworking.GetIP4Address();
                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                }

                iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), -50, -50, 80, 50);
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

                Shop myShop = new Shop();
                myShop.FType = 2;
                myShop.Bran = 1;
                myShop.Number = (Request.QueryString["StoreNo"] != null ? short.Parse(Request.QueryString["StoreNo"].ToString()) : short.Parse(Session["StoreNo"].ToString()));
                if (myShop.GetShop(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    page.vStr4 = myShop.Name1;
                }
                //-------------------------------------------------------------------------------------------                    
                document.Open();
                //-------------------------------------------------------------------------------------------                    
                //string arialunicodepath = Server.MapPath("Fonts") + @"\arial.ttf";
                string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 10f, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font nationalTextFont2 = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font nationalTextFont14 = new iTextSharp.text.Font(nationalBase, 14f, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font nationalTextFont16 = new iTextSharp.text.Font(nationalBase, 16f, iTextSharp.text.Font.NORMAL);
                //-------------------------------------------------------------------------------------------                    
                //document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                //-------------------------------------------------------------------------------------------                    
                var cols = new[] { 1200 };
                document.Open();
                PdfPTable table = new PdfPTable(1);
                table.TotalWidth = document.PageSize.Width; //100f;
                table.SetWidths(cols);
                PdfPCell cell2 = new PdfPCell();
                //cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                //table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell2.Border = 0;
                cell2.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell2);

                cell2.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                cell2.Phrase = new iTextSharp.text.Phrase("Details Item Card", nationalTextFont16);
                table.AddCell(cell2);
                document.Add(table);
                //-------------------------------------------------------------------------------------------
                document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                //-------------------------------------------------------------------------------------------
                cols = new[] { 300,500,300,400 };
                table = new PdfPTable(4);
                table.TotalWidth = document.PageSize.Width; //100f;
                table.SetWidths(cols);
                cell2 = new PdfPCell();
                cell2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                //cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                //table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;

                cell2.Phrase = new iTextSharp.text.Phrase("From Date", nationalTextFont2);
                table.AddCell(cell2);
                cell2.Phrase = new iTextSharp.text.Phrase(ChkPeriod.Checked ? "All Period" : txtFDate.Text, nationalTextFont);
                table.AddCell(cell2);
                cell2.Phrase = new iTextSharp.text.Phrase("To Date", nationalTextFont2);
                table.AddCell(cell2);
                cell2.Phrase = new iTextSharp.text.Phrase(ChkPeriod.Checked ? "All Period" : txtEDate.Text, nationalTextFont);
                table.AddCell(cell2);

                cell2.Phrase = new iTextSharp.text.Phrase("Item Category", nationalTextFont2);
                table.AddCell(cell2);
                cell2.Phrase = new iTextSharp.text.Phrase(ChkICat.Checked ? "All Category" : ddlICat.SelectedItem.Text, nationalTextFont);
                table.AddCell(cell2);
                cell2.Phrase = new iTextSharp.text.Phrase("Job Order No.", nationalTextFont2);
                table.AddCell(cell2);
                cell2.Phrase = new iTextSharp.text.Phrase(ChkJob.Checked ? "All Job Orders" : ddlJob.SelectedItem.Text, nationalTextFont);
                table.AddCell(cell2);

                cell2.Phrase = new iTextSharp.text.Phrase("Item Code", nationalTextFont2);
                table.AddCell(cell2);
                cell2.Phrase = new iTextSharp.text.Phrase(ChkItems.Checked ? "All Items" : txtItemCode.Text, nationalTextFont);
                table.AddCell(cell2);
                cell2.Phrase = new iTextSharp.text.Phrase("Item Description", nationalTextFont2);
                table.AddCell(cell2);
                cell2.Phrase = new iTextSharp.text.Phrase(ChkItems.Checked ? "All Items" : this.txtITName.Text, nationalTextFont);
                table.AddCell(cell2);

                cell2.Phrase = new iTextSharp.text.Phrase("Car No.", nationalTextFont2);
                table.AddCell(cell2);
                cell2.Phrase = new iTextSharp.text.Phrase(ChkCars.Checked ? "All Cars" : ddlCar.SelectedItem.Text, nationalTextFont);
                table.AddCell(cell2);
                cell2.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell2);
                cell2.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell2);

                document.Add(table);
                //-------------------------------------------------------------------------------------------
                document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                //-------------------------------------------------------------------------------------------

                if(ChkItems.Checked)
                {
                    cols = new[] { 120,100,100,100,250,100,100,100,100,100,120};
                    table = new PdfPTable(11);
                }
                else
                {
                    cols = new[] { 120, 100, 100, 100, 100, 100 ,100 ,100,100,120 };
                    table = new PdfPTable(10);                
                }
                PdfPCell cell = new PdfPCell();
                //cell.FixedHeight = 20f;
                //cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                //table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.Phrase = new iTextSharp.text.Phrase("Document Type", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("No.", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Date", nationalTextFont2);
                table.AddCell(cell);
                if (ChkItems.Checked)
                {
                    cell.Phrase = new iTextSharp.text.Phrase("Item Code", nationalTextFont2);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("Description", nationalTextFont2);
                    table.AddCell(cell);
                }

                cell.Phrase = new iTextSharp.text.Phrase("Receipt", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Issue", nationalTextFont2);
                table.AddCell(cell);

                if (!ChkItems.Checked)
                {
                    cell.Phrase = new iTextSharp.text.Phrase("Balance", nationalTextFont2);
                    table.AddCell(cell);
                }

                cell.Phrase = new iTextSharp.text.Phrase("Price", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Issue Amount", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Receipt Amount", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Remark", nationalTextFont2);
                table.AddCell(cell);

                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;

                if (MyOver != null && MyOver.Count > 0)
                {
                    foreach (vSTS inv in MyOver)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(inv.FType3, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.VouNo2, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.VouDate, nationalTextFont);
                        table.AddCell(cell);
                        if (ChkItems.Checked)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(inv.ITCode, nationalTextFont);
                            table.AddCell(cell);

                            cell.Phrase = new iTextSharp.text.Phrase(inv.ITName1, nationalTextFont);
                            table.AddCell(cell);
                        }

                        cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Quan2), nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Quan), nationalTextFont);
                        table.AddCell(cell);

                        if (!ChkItems.Checked)
                        {
                            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Bal), nationalTextFont);
                            table.AddCell(cell);
                        }

                        cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.Price), nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.Amount), nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", inv.Amount2), nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.Remark, nationalTextFont);
                        table.AddCell(cell);
                    }
                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;

                    cell.Phrase = new iTextSharp.text.Phrase("Total", nationalTextFont);
                    table.AddCell(cell);


                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    if (ChkItems.Checked)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                        table.AddCell(cell);
                    }

                    cell.Phrase = new iTextSharp.text.Phrase(TotalQuan2, nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(TotalQuan, nationalTextFont);
                    table.AddCell(cell);

                    if (!ChkItems.Checked)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                        table.AddCell(cell);
                    }

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(TotalAmount, nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(TotalAmount2, nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("Net: {0:N2}", moh.StrToDouble(TotalAmount2) - moh.StrToDouble(TotalAmount)), nationalTextFont);
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
                //cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
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
                //cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell.BackgroundColor = iTextSharp.text.BaseColor.RED;
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                //set cell border to 0
                cell.Border = 2;

                //add some padding to bring away from the edge
                cell.PaddingRight = 5;
                if (moh.PrintDateofPrint) cell.Phrase = new iTextSharp.text.Phrase("تاريخ الطباعة : " + String.Format("{0:dd/MM/yyyy}", moh.Nows()), footer);
                else cell.Phrase = new iTextSharp.text.Phrase(" ", footer);
                //add cell to table
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
            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
            {
                Transactions UserTran = new Transactions();
                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                UserTran.UserName = Session["CurrentUser"].ToString();
                UserTran.FormName = "حركة تفصيلية لصنف";
                UserTran.FormAction = "تصدير";
                UserTran.Description = "اختيار حركة تفصيلية صنف " + (ChkItems.Checked ? "جميع الاصناف" : txtItemCode.Text) + " " + (this.ChkICat.Checked ? "جميع الانواع " : this.ddlICat.SelectedItem.Text) + " " + (this.ChkJob.Checked ? "جميع أوامر التشغيل " : this.ddlJob.SelectedItem.Text) + " " + (this.ChkCars.Checked ? "جميع الشاحنات " : this.ddlCar.SelectedItem.Text) + (ChkPeriod.Checked ? "جميع الفترات " : txtFDate.Text + " إلى " + txtEDate.Text);
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

                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                {
                    Transactions UserTran = new Transactions();
                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                    UserTran.UserName = Session["CurrentUser"].ToString();
                    UserTran.FormName = "حركة تفصيلية لصنف";
                    UserTran.FormAction = "عرض";
                    UserTran.Description = "اختيار حركة تفصيلية صنف " + (ChkItems.Checked ? "جميع الاصناف" : txtItemCode.Text) + " " + (this.ChkICat.Checked ? "جميع الانواع " : this.ddlICat.SelectedItem.Text) + " " + (this.ChkJob.Checked ? "جميع أوامر التشغيل " : this.ddlJob.SelectedItem.Text) + " " + (this.ChkCars.Checked ? "جميع الشاحنات " : this.ddlCar.SelectedItem.Text) + (ChkPeriod.Checked ? "جميع الفترات " : txtFDate.Text + " إلى " + txtEDate.Text);
                    UserTran.IP = IPNetworking.GetIP4Address();
                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                }
                lblCount.Text = "";
                MyOver.Clear();
                List<vSTS> myList = new List<vSTS>();
                STS myInv = new STS();
                myInv.Branch = short.Parse(Session["Branch"].ToString()); 
                myList = myInv.GetStatement(ChkPeriod.Checked ? "" : txtFDate.Text,ChkPeriod.Checked ? "" : txtEDate.Text,
                                            ChkICat.Checked ? "" : ddlICat.SelectedValue,
                                            ChkItems.Checked ? "" : txtItemCode.Text,
                                            ChkJob.Checked ? -1 : int.Parse(ddlJob.SelectedValue),
                                            ChkCars.Checked ? "" : ddlCar.SelectedValue,WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                STP mySTP = new STP();
                mySTP.Branch = short.Parse(Session["Branch"].ToString());
                myList.AddRange((from itm in mySTP.GetStatement(ChkPeriod.Checked ? "" : txtFDate.Text, ChkPeriod.Checked ? "" : txtEDate.Text,
                                                                ChkICat.Checked ? "" : ddlICat.SelectedValue,
                                                                ChkItems.Checked ? "" : txtItemCode.Text,
                                                                ChkJob.Checked ? -1 : int.Parse(ddlJob.SelectedValue),
                                                                ChkCars.Checked ? "" : ddlCar.SelectedValue, 
                                                                rdoInVou.Items[0].Selected ,WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                 select new vSTS {
                                      Branch = itm.Branch,
                                      CrCode = itm.CrCode,
                                      DbCode = itm.DbCode,
                                      VouNo = itm.VouNo,
                                      VouLoc = itm.VouLoc,
                                      VouDate = itm.VouDate,
                                      UserName = itm.UserName,
                                      UserDate = itm.UserDate,
                                      ExpAmount = itm.ExpAmount,
                                      ExpPer = itm.ExpPer,
                                      ExpRef = itm.ExpRef,
                                      FNo = itm.FNo,
                                      FNo2 = itm.FNo2,
                                      FType = itm.FType,
                                      InvType = itm.InvType,
                                      ITCode = itm.ITCode,
                                      ITName1 = itm.ITName1,
                                      ITName2 = itm.ITName2,
                                      Price = itm.Price,
                                      RefNo = itm.RefNo,
                                      RefNoLoc = itm.RefNoLoc,
                                      Remark = itm.Remark,
                                      RefType = itm.RefType,
                                      UnitCode = itm.UnitCode,
                                      UnitName1 = itm.UnitName1,
                                      UnitName2 = itm.UnitName2,
                                      Quan2 = itm.FType != 502 ? itm.Quan : 0,
                                      Quan= itm.FType == 502 ? itm.Quan : 0
                                 }).ToList());
                double openbal = 0 , price = 0, openbal2 = 0;
                if (!ChkItems.Checked)
                {
                    Item myItem = new Item();
                    myItem.Branch = short.Parse(Session["Branch"].ToString());
                    myItem.ITCode = txtItemCode.Text;
                    myItem = myItem.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myItem != null) price = (double)myItem.ITCPrice;
                    Stock mystock = new Stock();
                    mystock.Branch = short.Parse(Session["Branch"].ToString());
                    mystock.Number = 1;
                    mystock.Code = txtItemCode.Text;
                    mystock = mystock.GetItem(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (mystock != null) openbal = (double)mystock.IOpen;
                    openbal2 = openbal;
                    myList.Add(new vSTS
                    {
                        FType = 0,
                        VouDate = "01/01/2014",
                        Quan2 = openbal,
                        Bal = openbal,
                        Price = price
                    });
                }
                MyOver = (from itm in myList
                          orderby DateTime.Parse(itm.VouDate),itm.FType
                          select new vSTS {
                                      Branch = itm.Branch,
                                      CrCode = itm.CrCode,
                                      DbCode = itm.DbCode,
                                      VouNo = itm.VouNo,
                                      VouLoc = itm.VouLoc,
                                      VouDate = itm.VouDate,
                                      UserName = itm.UserName,
                                      UserDate = itm.UserDate,
                                      ExpAmount = itm.ExpAmount,
                                      ExpPer = itm.ExpPer,
                                      ExpRef = itm.ExpRef,
                                      FNo = itm.FNo,
                                      FNo2 = itm.FNo2,
                                      FType = itm.FType,
                                      InvType = itm.InvType,
                                      ITCode = itm.ITCode,
                                      ITName1 = itm.ITName1,
                                      ITName2 = itm.ITName2,
                                      Price = itm.Price,
                                      RefNo = itm.RefNo,
                                      RefNoLoc = itm.RefNoLoc,
                                      Remark = itm.Remark,
                                      RefType = itm.RefType,
                                      UnitCode = itm.UnitCode,
                                      UnitName1 = itm.UnitName1,
                                      UnitName2 = itm.UnitName2,
                                      Quan2 = itm.Quan2,
                                      Quan= itm.Quan,
                                      Bal = itm.Bal
                                 }).ToList();
                foreach (vSTS itm in MyOver)
                {
                    if (itm.FType != 0)
                    {
                        openbal += (double)(itm.Quan2 - itm.Quan);
                        itm.Bal = openbal;
                    }                    
                }


                if (!ChkPeriod.Checked && txtFDate.Text != "" && txtEDate.Text != "")
                {
                    foreach (vSTS itm in MyOver)
                    {
                        if(DateTime.Parse(itm.VouDate) < DateTime.Parse(txtFDate.Text))  openbal2 = (double)itm.Bal;
                        if (DateTime.Parse(itm.VouDate) >= DateTime.Parse(txtFDate.Text) && DateTime.Parse(itm.VouDate) <= DateTime.Parse(txtEDate.Text)) break;
                    }

                    myList = MyOver;
                    MyOver = (from itm in myList
                              where (DateTime.Parse(itm.VouDate) >= DateTime.Parse(txtFDate.Text) && DateTime.Parse(itm.VouDate) <= DateTime.Parse(txtEDate.Text)) && itm.FType != 0
                              //orderby DateTime.Parse(itm.VouDate), itm.FType
                              select itm).ToList();

                    MyOver.Insert(0, new vSTS
                    {
                        FType = 0,
                        VouDate = String.Format("{0:dd/MM/yyyy}",DateTime.Parse(txtFDate.Text).AddDays(-1)),
                        Quan2 = openbal2,
                        Bal = openbal2,
                        Price = price
                    });
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

        protected string UrlHelper(object FType, object Number)
        {
                string[] vs = Number.ToString().Split('/');
                if (vs.Count() > 1)
                {
                    switch (short.Parse(FType.ToString()))
                    {
                        case 501: return "~/WebPurchaseInvoice.aspx?FNum=" + vs[1] + "&StoreNo=" + vs[0] + "&AreaNo=" + AreaNo;
                        case 502: return "~/WebReturnPurchaseInvoice.aspx?FNum=" + vs[1] + "&StoreNo=" + vs[0] + "&AreaNo=" + AreaNo;
                        case 701: return "~/WebIssueNote.aspx?FNum=" + vs[1] + "&StoreNo=" + vs[0] + "&AreaNo=" + AreaNo;
                        case 601: return "~/WebDeliveryNote.aspx?FNum=" + vs[1] + "&StoreNo=" + vs[0] + "&AreaNo=" + AreaNo;
                        case 503: return "~/WebUImportNote.aspx?FNum=" + vs[1] + "&StoreNo=" + vs[0] + "&AreaNo=" + AreaNo;
                        default: return "";
                    }
                }
                else return "";
        }

        protected void rdoInVou_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void ddlICat_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void ddlJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void ddlCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void txtITName_TextChanged(object sender, EventArgs e)
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