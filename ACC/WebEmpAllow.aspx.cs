using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using iTextSharp.text.pdf;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Configuration;
using System.Threading;
using BLL;

namespace ACC
{
    public partial class WebEmpAllow : System.Web.UI.Page
    {
        public string TotalBasic
        {
            get
            {
                if (ViewState["TotalBasic"] == null)
                {
                    ViewState["TotalBasic"] = "0.00";
                }
                return ViewState["TotalBasic"].ToString();
            }
            set { ViewState["TotalBasic"] = value; }
        }
        public string TotalAdd01
        {
            get
            {
                if (ViewState["TotalAdd01"] == null)
                {
                    ViewState["TotalAdd01"] = "0.00";
                }
                return ViewState["TotalAdd01"].ToString();
            }
            set { ViewState["TotalAdd01"] = value; }
        }
        public string TotalAdd02
        {
            get
            {
                if (ViewState["TotalAdd02"] == null)
                {
                    ViewState["TotalAdd02"] = "0.00";
                }
                return ViewState["TotalAdd02"].ToString();
            }
            set { ViewState["TotalAdd02"] = value; }
        }
        public string TotalAddAll0
        {
            get
            {
                if (ViewState["TotalAddAll0"] == null)
                {
                    ViewState["TotalAddAll0"] = "0.00";
                }
                return ViewState["TotalAddAll0"].ToString();
            }
            set { ViewState["TotalAddAll0"] = value; }
        }
        public string TotalTotVac
        {
            get
            {
                if (ViewState["TotalTotVac"] == null)
                {
                    ViewState["TotalTotVac"] = "0.00";
                }
                return ViewState["TotalTotVac"].ToString();
            }
            set { ViewState["TotalTotVac"] = value; }
        }
        public string TotalAward
        {
            get
            {
                if (ViewState["TotalAward"] == null)
                {
                    ViewState["TotalAward"] = "0.00";
                }
                return ViewState["TotalAward"].ToString();
            }
            set { ViewState["TotalAward"] = value; }
        }
        public string TotalTotTicket
        {
            get
            {
                if (ViewState["TotalTotTicket"] == null)
                {
                    ViewState["TotalTotTicket"] = "0.00";
                }
                return ViewState["TotalTotTicket"].ToString();
            }
            set { ViewState["TotalTotTicket"] = value; }
        }
        public string TotalTicketam
        {
            get
            {
                if (ViewState["TotalTicketam"] == null)
                {
                    ViewState["TotalTicketam"] = "0.00";
                }
                return ViewState["TotalTicketam"].ToString();
            }
            set { ViewState["TotalTicketam"] = value; }
        }
        public string TotalVacam
        {
            get
            {
                if (ViewState["TotalVacam"] == null)
                {
                    ViewState["TotalVacam"] = "0.00";
                }
                return ViewState["TotalVacam"].ToString();
            }
            set { ViewState["TotalVacam"] = value; }
        }
        public string TotalIDam
        {
            get
            {
                if (ViewState["TotalIDam"] == null)
                {
                    ViewState["TotalIDam"] = "0.00";
                }
                return ViewState["TotalIDam"].ToString();
            }
            set { ViewState["TotalIDam"] = value; }
        }
        public string TotalWorkeram
        {
            get
            {
                if (ViewState["TotalWorkeram"] == null)
                {
                    ViewState["TotalWorkeram"] = "0.00";
                }
                return ViewState["TotalWorkeram"].ToString();
            }
            set { ViewState["TotalWorkeram"] = value; }
        }
        public string TotalInsam
        {
            get
            {
                if (ViewState["TotalInsam"] == null)
                {
                    ViewState["TotalInsam"] = "0.00";
                }
                return ViewState["TotalInsam"].ToString();
            }
            set { ViewState["TotalInsam"] = value; }
        }
        public string TotalAwardam
        {
            get
            {
                if (ViewState["TotalAwardam"] == null)
                {
                    ViewState["TotalAwardam"] = "0.00";
                }
                return ViewState["TotalAwardam"].ToString();
            }
            set { ViewState["TotalAwardam"] = value; }
        }

        public List<SalAllow> MyOver
        {
            get
            {
                if (ViewState["MyOver"] == null)
                {
                    ViewState["MyOver"] = new List<SalAllow>();
                }
                return (List<SalAllow>)ViewState["MyOver"];
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
                    this.Page.Header.Title = "كشف مستحقات الموظفين";
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
                        UserTran.Description = "اختيار عرض كشف مستحقات الموظفين";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }
                    ddlSection.DataTextField = "Name1";
                    ddlSection.DataValueField = "Code";
                    Codes myCode = new Codes();
                    myCode.Branch = short.Parse(Session["Branch"].ToString());
                    myCode.Ftype = 3;
                    if (Cache["LastCodes" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCodes" + Session["CNN2"].ToString(), myCode.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlSection.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                             where itm.Ftype == 3
                                             select itm).ToList();
                    ddlSection.DataBind();
                    ddlSection.Items.Insert(0, new ListItem("-----  جميع الاقسام  -----", "-1", true));
                    txtEDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());
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
                Label lblTotalBasic = grdCodes.FooterRow.FindControl("lblTotalBasic") as Label;
                Label lblTotalAdd01 = grdCodes.FooterRow.FindControl("lblTotalAdd01") as Label;
                Label lblTotalAdd02 = grdCodes.FooterRow.FindControl("lblTotalAdd02") as Label;
                Label lblTotalAddAll0 = grdCodes.FooterRow.FindControl("lblTotalAddAll0") as Label;
                Label lblTotaltotTicket = grdCodes.FooterRow.FindControl("lblTotaltotTicket") as Label;
                Label lblTotalTicketam = grdCodes.FooterRow.FindControl("lblTotalTicketam") as Label;
                Label lblTotalVacam = grdCodes.FooterRow.FindControl("lblTotalVacam") as Label;
                Label lblTotalAwardam = grdCodes.FooterRow.FindControl("lblTotalAwardam") as Label;
                Label lblTotalIDam = grdCodes.FooterRow.FindControl("lblTotalIDam") as Label;
                Label lblTotalWorkeram = grdCodes.FooterRow.FindControl("lblTotalWorkeram") as Label;
                Label lblTotalInsam = grdCodes.FooterRow.FindControl("lblTotalInsam") as Label;

                double Basic = 0, Add01 = 0, Add02 = 0, AddAll0 = 0, totTicket = 0, Ticketam = 0, Vacam = 0, Awardam = 0, IDam = 0, Workeram = 0, Insam = 0;
                foreach (SalAllow itm in MyOver)
                {
                    Basic += (double)itm.Basic;
                    Add01 += (double)itm.Add01;
                    Add02 += (double)itm.Add02;
                    AddAll0 += (double)itm.AddAll0;
                    totTicket += (double)itm.totTicket;
                    Ticketam += (double)itm.Ticketam;
                    Vacam += (double)itm.Vacam;
                    Awardam += (double)itm.Awardam;
                    IDam += (double)itm.IDam;
                    Workeram += (double)itm.Workeram;
                    Insam += (double)itm.Insam;
                }

                if (lblTotalBasic != null)
                {
                    lblTotalBasic.Text = string.Format("{0:N2}", Math.Round(Basic, 0));
                    TotalBasic = lblTotalBasic.Text;
                }

                if (lblTotalAdd01 != null)
                {
                    lblTotalAdd01.Text = string.Format("{0:N2}", Add01);
                    TotalAdd01 = lblTotalAdd01.Text;
                }

                if (lblTotalAdd02 != null)
                {
                    lblTotalAdd02.Text = string.Format("{0:N2}", Add02);
                    TotalAdd02 = lblTotalAdd02.Text;
                }

                if (lblTotalAddAll0 != null)
                {
                    lblTotalAddAll0.Text = string.Format("{0:N2}", AddAll0);
                    TotalAddAll0 = lblTotalAddAll0.Text;
                }

                if (lblTotaltotTicket != null)
                {
                    lblTotaltotTicket.Text = string.Format("{0:N2}", totTicket);
                    TotalTotTicket = lblTotaltotTicket.Text;
                }

                if (lblTotalTicketam != null)
                {
                    lblTotalTicketam.Text = string.Format("{0:N2}", Ticketam);
                    TotalTicketam = lblTotalTicketam.Text;
                }

                if (lblTotalVacam != null)
                {
                    lblTotalVacam.Text = string.Format("{0:N2}", Vacam);
                    TotalVacam = lblTotalVacam.Text;
                }

                if (lblTotalAwardam != null)
                {
                    lblTotalAwardam.Text = string.Format("{0:N2}", Awardam);
                    TotalAwardam = lblTotalAwardam.Text;
                }

                if (lblTotalIDam != null)
                {
                    lblTotalIDam.Text = string.Format("{0:N2}", IDam);
                    TotalIDam = lblTotalIDam.Text;
                }

                if (lblTotalWorkeram != null)
                {
                    lblTotalWorkeram.Text = string.Format("{0:N2}", Workeram);
                    TotalWorkeram = lblTotalWorkeram.Text;
                }

                if (lblTotalInsam != null)
                {
                    lblTotalInsam.Text = string.Format("{0:N2}", Insam);
                    TotalInsam = lblTotalInsam.Text;
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
                var cols = new[] { 45,45,45,45, 55, 45, 45,45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 115, 45, 30 };

                iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), -100, -100, 80, 50);
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
                page.PageNo = "1";
                page.UserName = Session["FullUser"].ToString();
                page.vStr1 = (ddlSection.SelectedValue == "-1" ? "" : ddlSection.SelectedItem.Text) + (ChkFDate.Checked ? "" : " من تاريخ " + txtFDate.Text )+ " بتاريخ " + txtEDate.Text;
                pw.PageEvent = page;                

                document.Open();
                BaseFont nationalBase;
                string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 6f, iTextSharp.text.Font.NORMAL);


                PdfPTable table = new PdfPTable(24);
                table.SetWidths(cols);
                PdfPCell cell = new PdfPCell();
                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                foreach (SalAllow itm in MyOver)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(itm.FNo.ToString(), nationalTextFont);
                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.EmpCode.ToString(), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.Name, nationalTextFont);
                    table.AddCell(cell);


                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", itm.Basic), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", itm.Add01), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", itm.Add02), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", itm.AddAll0), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", itm.totVac), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", itm.totAward), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.JoinDate, nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.VacDate, nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.ReturnDate, nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", itm.DutyDays), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", itm.VacDays), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Vac), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.TicketValue), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", itm.TicketNo), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.totTicket), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Ticketam), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Vacam), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Awardam), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.IDam), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Workeram), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Insam), nationalTextFont);
                    table.AddCell(cell);
                }
                cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("الاجمالي", nationalTextFont);
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalBasic, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalAdd01, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalAdd02, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalAddAll0, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalTicketam, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalVacam, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalAwardam, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalIDam, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalWorkeram, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalInsam, nationalTextFont);
                table.AddCell(cell);

                document.Add(table);

                document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
 
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
            public string UserName, PageNo, vCompanyName, vStr1;

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
                //cell2.PaddingRight = 0;
                cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell2.Phrase = new iTextSharp.text.Phrase(vCompanyName + "\n" + "المـرتبـــــات", nationalTextFont);
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                headerTbl.AddCell(cell2);

                //cell2.PaddingRight = 0;
                cell2.Phrase = new iTextSharp.text.Phrase("كشف مستحقات الموظفين " + vStr1, nationalTextFont);
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

                arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                //BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                nationalTextFont = new iTextSharp.text.Font(nationalBase, 6f, iTextSharp.text.Font.NORMAL);

                var cols = new[] { 45, 45, 45, 45, 55, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 115, 45, 30 };
                    PdfPTable table = new PdfPTable(24);
                    table.SetWidths(cols);
                    PdfPCell cell = new PdfPCell();
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    cell.Phrase = new iTextSharp.text.Phrase("م", nationalTextFont);
                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("رقم الموظف", nationalTextFont);
                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الاسم", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الاساسي", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("انتقال", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("السكن", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("أخرى", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الإجمالي للإجازة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الإجمالي للمكافأة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("تاريخ بداية التعيين", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("تاريخ أخر إجازة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("تاريخ العودة من أخر الإجازة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("مدة الخدمة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("المدة المستحق عنها الإجازة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("عدد أيام الإجازة المستحقة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("قيمة التذكرة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("عدد التذاكر", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("قيمة التذاكر", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("تذاكر السفر", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("بدل الإجازة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("نهاية الخدمة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الاقامة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("المقابل المالي", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("تأمين طبي", nationalTextFont);
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
                cell.Border = 0;

                if (moh.PrintDateofPrint) cell.Phrase = new iTextSharp.text.Phrase("تاريخ الطباعة : " + String.Format("{0:dd/MM/yyyy}", moh.Nows()), footer);
                else cell.Phrase = new iTextSharp.text.Phrase(" ", footer);
                footerTbl.AddCell(cell);

                //create new instance of cell to hold the text
                //cell = new PdfPCell();



                //align the text to the right of the cell
                //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                //cell.Phrase = new iTextSharp.text.Phrase("     ", footer);
                cell.Phrase = new iTextSharp.text.Phrase("طبعت بواسطة " + UserName, footer);
                footerTbl.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("عدد مرات الطباعة " + PageNo, footer);
                footerTbl.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("صفحة رقم " + writer.PageNumber.ToString() , footer);
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
            MyOver.Clear();
            int fno = 1;
            SEmp myacc = new SEmp();
            if (Cache["Emps" + Session["CNN2"].ToString()] == null) Cache.Insert("Emps" + Session["CNN2"].ToString(), myacc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            MyOver = (from itm in (List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()])
                      where (ddlSection.SelectedIndex == 0 || itm.Section == int.Parse(ddlSection.SelectedValue)) &&
                      (itm.Status != 2 || (itm.EndDate != "" && DateTime.Parse(itm.EndDate) > DateTime.Parse(txtEDate.Text))) && 
                      itm.JoinDate != "" && DateTime.Parse(itm.JoinDate)<=DateTime.Parse(txtEDate.Text)
                      select new SalAllow
                      {
                          FNo = (short)fno++,
                          EmpCode = itm.EmpCode,
                          Basic = itm.Basic,
                          Add01 = itm.Add01,
                          Add02 = itm.Add02,
                          AddAll0 = itm.Add03 + itm.Add05 + itm.Add13 + itm.Add14,
                          totVac = itm.Basic + itm.Add02,
                          totAward = itm.Basic + itm.Add01 + itm.Add02 + itm.Add03 + itm.Add05 + itm.Add13 + itm.Add14,
                          DutyDays = DutyDay(itm,txtEDate.Text),
                          VacDays = string.IsNullOrEmpty(itm.ReturnDate) ? 
                                      (string.IsNullOrEmpty(itm.VacDate) ? DateTime.Parse(txtEDate.Text).Subtract(DateTime.Parse(itm.JoinDate)).Days : 0) :
                                      (string.IsNullOrEmpty(itm.VacDate) ? DateTime.Parse(txtEDate.Text).Subtract(DateTime.Parse(itm.ReturnDate)).Days :
                                        DateTime.Parse(itm.VacDate) >= DateTime.Parse(itm.ReturnDate) ? 0 : DateTime.Parse(txtEDate.Text).Subtract(DateTime.Parse(itm.ReturnDate)).Days),
                          Vac = CalcVacDay(itm, txtEDate.Text),
                          Name = itm.Name,
                          JoinDate = itm.JoinDate,
                          ReturnDate = itm.ReturnDate,
                          VacDate = itm.VacDate,
                          TicketNo = itm.TicketNo,
                          TicketValue = itm.TicketValue,
                          totTicket = itm.TicketNo * itm.TicketValue,
                          Ticketam = (CalcVacDay(itm, txtEDate.Text) < 0 ? 0 : CalcVacDay(itm, txtEDate.Text) >= itm.VacDays ? itm.TicketNo * itm.TicketValue :
                                                        itm.TicketNo * itm.TicketValue * CalcVacDay(itm, txtEDate.Text) / itm.VacDays),
                          Vacam = ((itm.Basic + itm.Add02) / 30.00) * (CalcVacDay(itm, txtEDate.Text) > 0 ? CalcVacDay(itm, txtEDate.Text) : 0),
                          Awardam = itm.VacDate == "01/01/2999" ? 0 :                          
                          (itm.Basic + itm.Add01 + itm.Add02 + itm.Add03 + itm.Add05 + itm.Add13 + itm.Add14) *
                                    (DutyDay(itm, txtEDate.Text) > (5 * 365) ?
                                    (2.5 + ((DutyDay(itm, txtEDate.Text) / 365.00) - 5) * 1)
                                    : (DutyDay(itm, txtEDate.Text) / 365.00 * 0.5)),
                         IDam = (itm.Nat == 1 || itm.Nat==203 ? 0: (ChkFDate.Checked ? 750 : (double)Math.Round((decimal)750/12,2))),
                         Workeram = (itm.Nat == 1 || itm.Nat==203 ? 0: (ChkFDate.Checked ? 9600 : 800)),
                         Insam = (ChkFDate.Checked ? itm.P11am : (double)Math.Round((decimal)itm.P11am / 12, 2))
                      }).ToList();

            if (!ChkFDate.Checked && txtFDate.Text != "")
            {
                string vFDate = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(txtFDate.Text).AddDays(-1)); 
                List<SalAllow> sallow = new List<SalAllow>();
                SEmp myacc2 = new SEmp();
                sallow = (from itm in myacc2.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                          where (ddlSection.SelectedIndex == 0 || itm.Section == int.Parse(ddlSection.SelectedValue)) && itm.Status != 2 &&
                          itm.JoinDate != "" && DateTime.Parse(itm.JoinDate) <= DateTime.Parse(vFDate)
                          select new SalAllow
                          {
                              FNo = (short)fno++,
                              EmpCode = itm.EmpCode,
                              Basic = itm.Basic,
                              Add01 = itm.Add01,
                              Add02 = itm.Add02,
                              AddAll0 = itm.Add03 + itm.Add05 + itm.Add13 + itm.Add14,
                              totVac = itm.Basic + itm.Add02,
                              totAward = itm.Basic + itm.Add01 + itm.Add02 + itm.Add03 + itm.Add05 + itm.Add13 + itm.Add14,
                              DutyDays = DutyDay(itm, vFDate),
                              VacDays = string.IsNullOrEmpty(itm.ReturnDate) ?
                                          (string.IsNullOrEmpty(itm.VacDate) ? DateTime.Parse(vFDate).Subtract(DateTime.Parse(itm.JoinDate)).Days : 0) :
                                          (string.IsNullOrEmpty(itm.VacDate) ? DateTime.Parse(vFDate).Subtract(DateTime.Parse(itm.ReturnDate)).Days :
                                            DateTime.Parse(itm.VacDate) >= DateTime.Parse(itm.ReturnDate) ? 0 : DateTime.Parse(vFDate).Subtract(DateTime.Parse(itm.ReturnDate)).Days),
                              Vac = CalcVacDay(itm, vFDate),
                              Name = itm.Name,
                              JoinDate = itm.JoinDate,
                              ReturnDate = itm.ReturnDate,
                              VacDate = itm.VacDate,
                              TicketNo = itm.TicketNo,
                              TicketValue = itm.TicketValue,
                              totTicket = itm.TicketNo * itm.TicketValue,
                              Ticketam = (CalcVacDay(itm, vFDate) < 0 ? 0 : CalcVacDay(itm, vFDate) >= itm.VacDays ? itm.TicketNo * itm.TicketValue :
                                                            itm.TicketNo * itm.TicketValue * CalcVacDay(itm, vFDate) / itm.VacDays),
                              Vacam = ((itm.Basic + itm.Add02) / 30.00) * (CalcVacDay(itm, vFDate) > 0 ? CalcVacDay(itm, vFDate) : 0),
                              Awardam = itm.VacDate == "01/01/2999" ? 0 :
                              (itm.Basic + itm.Add01 + itm.Add02 + itm.Add03 + itm.Add05 + itm.Add13 + itm.Add14) *
                                        (DutyDay(itm, vFDate) > (5 * 365) ?
                                        (2.5 + ((DutyDay(itm, vFDate) / 365.00) - 5) * 1)
                                        : (DutyDay(itm, vFDate) / 365.00 * 0.5))
                          }).ToList();

                foreach (SalAllow itm in sallow)
                {
                    foreach (SalAllow sitm in MyOver)
                    {
                        if (sitm.EmpCode == itm.EmpCode)
                        {
                            sitm.Vacam -= itm.Vacam;
                            sitm.Ticketam -= itm.Ticketam;
                            sitm.Awardam -= itm.Awardam;
                        }
                    }
                }
            }

            LoadCodesData();
        }


        public double? CalcVacDay(SEmp itm, string myDate)
        {
            double vac = 0;
            if(string.IsNullOrEmpty(itm.ReturnDate))
            {
                if (string.IsNullOrEmpty(itm.VacDate))
                {
                    if (DateTime.Parse(myDate) < DateTime.Parse(itm.JoinDate))
                    {
                        vac = 0;
                    }
                    else
                    {
                        vac = DateTime.Parse(myDate).Subtract(DateTime.Parse(itm.JoinDate)).Days;
                    }
                }
                else
                {
                    if (itm.VacDate == "01/01/2999")
                    {
                        return vac;
                    }
                    if (!string.IsNullOrEmpty(txtFDate.Text) && !string.IsNullOrEmpty(txtEDate.Text))
                    {
                        if (DateTime.Parse(itm.VacDate) > DateTime.Parse(myDate))
                        {
                            vac = DateTime.Parse(myDate).Subtract(DateTime.Parse(itm.JoinDate)).Days;
                        }
                        else
                        {
                            if (DateTime.Parse(itm.VacDate) > DateTime.Parse(txtFDate.Text) && DateTime.Parse(itm.VacDate) < DateTime.Parse(txtEDate.Text))
                            {
                                vac = 0;
                            }
                            else vac = DateTime.Parse(itm.VacDate).Subtract(DateTime.Parse(itm.JoinDate)).Days;                            
                        }
                    }
                    else
                    {
                        if (DateTime.Parse(itm.VacDate) > DateTime.Parse(myDate))
                        {
                            vac = DateTime.Parse(myDate).Subtract(DateTime.Parse(itm.JoinDate)).Days;
                        }
                        else
                        {
                            vac = 0;
                        }
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(itm.VacDate))
                {
                    if (DateTime.Parse(myDate) < DateTime.Parse(itm.ReturnDate))
                    {
                        vac = 0;
                    }
                    else
                    {
                        vac = DateTime.Parse(myDate).Subtract(DateTime.Parse(itm.ReturnDate)).Days;
                    }
                }
                else
                {
                    if (itm.VacDate == "01/01/2999")
                    {
                        return vac;
                    }
                    if (DateTime.Parse(itm.VacDate) >= DateTime.Parse(itm.ReturnDate))
                    {
                        if (!string.IsNullOrEmpty(txtFDate.Text) && !string.IsNullOrEmpty(txtEDate.Text))
                        {
                            if (DateTime.Parse(itm.VacDate) > DateTime.Parse(myDate))
                            {
                                if (DateTime.Parse(itm.VacDate) > DateTime.Parse(txtFDate.Text) && DateTime.Parse(itm.VacDate) < DateTime.Parse(txtEDate.Text))
                                {
                                    vac = 0;
                                }
                                else vac = DateTime.Parse(myDate).Subtract(DateTime.Parse(itm.ReturnDate)).Days;
                            }
                            else
                            {
                                if (DateTime.Parse(itm.VacDate) > DateTime.Parse(txtFDate.Text) && DateTime.Parse(itm.VacDate) < DateTime.Parse(txtEDate.Text))
                                {
                                    vac = 0;
                                }
                                else vac = DateTime.Parse(itm.VacDate).Subtract(DateTime.Parse(itm.ReturnDate)).Days;
                            }
                        }
                        else
                        {
                            if (DateTime.Parse(itm.VacDate) > DateTime.Parse(myDate))
                            {
                                vac = DateTime.Parse(myDate).Subtract(DateTime.Parse(itm.ReturnDate)).Days;
                            }
                            else
                            {
                                vac = 0;
                            }
                        }
                    }
                    else
                    {
                        vac = DateTime.Parse(myDate).Subtract(DateTime.Parse(itm.ReturnDate)).Days;
                    }
                }
            }

            if(vac > 0) vac = (double)((vac / (itm.ContractType == 0 ? 330.00 : 690.00)) * itm.VacDays);








            //vac = (double)(((string.IsNullOrEmpty(itm.ReturnDate) ?
            //                      (string.IsNullOrEmpty(itm.VacDate) ? DateTime.Parse(myDate).Subtract(DateTime.Parse(itm.JoinDate)).Days :                                 
            //                      (DateTime.Parse(txtFDate.Text) <= DateTime.Parse(itm.VacDate) && DateTime.Parse(txtEDate.Text) >= DateTime.Parse(itm.VacDate) ?
            //                        DateTime.Parse(itm.VacDate) > DateTime.Parse(myDate) ? DateTime.Parse(itm.VacDate).Subtract(DateTime.Parse(itm.JoinDate)).Days : DateTime.Parse(myDate).Subtract(DateTime.Parse(itm.JoinDate)).Days : 0)) :
            //                      (string.IsNullOrEmpty(itm.VacDate) ? DateTime.Parse(myDate).Subtract(DateTime.Parse(itm.ReturnDate)).Days :
            //                        DateTime.Parse(itm.VacDate) >= DateTime.Parse(itm.ReturnDate) ?
            //                       (DateTime.Parse(txtFDate.Text) <= DateTime.Parse(itm.VacDate) && DateTime.Parse(txtEDate.Text) >= DateTime.Parse(itm.VacDate) ?
            //                        DateTime.Parse(itm.VacDate) > DateTime.Parse(myDate) ? DateTime.Parse(itm.VacDate).Subtract(DateTime.Parse(itm.ReturnDate)).Days : DateTime.Parse(myDate).Subtract(DateTime.Parse(itm.ReturnDate)).Days : 0)                                                                        
            //                        : DateTime.Parse(myDate).Subtract(DateTime.Parse(itm.ReturnDate)).Days)) / (itm.ContractType == 0 ? 330.00 : 690.00)) * itm.VacDays);
            return (vac < 0 ? 0 : vac);
        }

        public double?  DutyDay(SEmp itm, string myDate)
        {
            return (double)(!string.IsNullOrEmpty(itm.EndDate) && DateTime.Parse(itm.EndDate) < DateTime.Parse(myDate) ? DateTime.Parse(itm.EndDate).Subtract(DateTime.Parse(itm.JoinDate)).Days - itm.OffDays :
                          DateTime.Parse(myDate).Subtract(DateTime.Parse(itm.JoinDate)).Days - itm.OffDays);
        }

        protected void ChkFDate_CheckedChanged(object sender, EventArgs e)
        {
            txtFDate.Visible = !ChkFDate.Checked;
            CompareValidator1.Enabled = !ChkFDate.Checked;
            CalendarExtender1.Enabled = !ChkFDate.Checked;
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void BtnPostJv_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                MyConfig mysetting = new MyConfig();
                mysetting.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mysetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                mysetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                if (mysetting != null)
                {
                    Jv myJv = new Jv();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.FType = 100;
                    myJv.LocType = 1;
                    myJv.LocNumber = 1;
                    int? i = myJv.GetNewNumber(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (i == 0 || i == null)
                    {
                        i = 1;
                    }
                    else
                    {
                        i++;
                    }
                    int FNo = 1;
                    int FNo2 = 800;
                    // int vDiff = DateTime.Parse(txtEDate.Text).Subtract(DateTime.Parse(txtFDate.Text)).Days / 30;
                    // double Ticketam = 0, Vacam = 0, Awardam = 0, IDam = 0, Workeram = 0, Insam = 0;
                    foreach (SalAllow itm in MyOver)
                    {
                        Acc myAcc = new Acc();
                        myAcc.Branch = short.Parse(Session["Branch"].ToString());
                        myAcc.Code = "12050" + itm.EmpCode;
                        if (myAcc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (itm.Ticketam > 0)
                            {
                                Jv vJv = new Jv();
                                vJv.Branch = short.Parse(Session["Branch"].ToString());
                                vJv.FType = 100;
                                vJv.LocType = 1;
                                vJv.LocNumber = 1;
                                vJv.Number = (int)i;
                                vJv.Post = 1;
                                vJv.FDate = txtEDate.Text;
                                vJv.CostCenter = myAcc.CostCenter;
                                vJv.Project = myAcc.Project;
                                vJv.CarNo = myAcc.CarNo;
                                vJv.Area = myAcc.Area;
                                vJv.CostAcc = (mysetting.AddAcc10.StartsWith("3") ? myAcc.CostAcc : "-1");
                                vJv.EmpCode = myAcc.EmpCode;
                                vJv.Remark = "بدل تذاكر سفر للموظف " + itm.Name + " عن شهر " + HDate.Ch_Date(txtEDate.Text).Month.ToString() + "/" + HDate.Ch_Date(txtEDate.Text).Year.ToString();
                                vJv.InvNo = "";
                                vJv.FNo = (short)FNo++;
                                vJv.Amount = Math.Round((double)itm.Ticketam,2);
                                vJv.DbCode = mysetting.AddAcc10;
                                vJv.UserName = Session["CurrentUser"].ToString();
                                vJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                vJv = new Jv();
                                vJv.Branch = short.Parse(Session["Branch"].ToString());
                                vJv.FType = 100;
                                vJv.LocType = 1;
                                vJv.LocNumber = 1;
                                vJv.Number = (int)i;
                                vJv.Post = 1;
                                vJv.FDate = txtEDate.Text;
                                vJv.CostCenter = myAcc.CostCenter;
                                vJv.Project = myAcc.Project;
                                vJv.CarNo = myAcc.CarNo;
                                vJv.Area = myAcc.Area;
                                vJv.CostAcc = (mysetting.DedAcc07.StartsWith("3") ? myAcc.CostAcc : "-1");
                                vJv.EmpCode = myAcc.EmpCode;
                                vJv.Remark = "بدل تذاكر سفر للموظف " + itm.Name + " عن شهر " + HDate.Ch_Date(txtEDate.Text).Month.ToString() + "/" + HDate.Ch_Date(txtEDate.Text).Year.ToString();
                                vJv.InvNo = "";
                                vJv.FNo = (short)FNo2++;
                                vJv.Amount = Math.Round((double)itm.Ticketam, 2);
                                vJv.CrCode = mysetting.DedAcc07;
                                vJv.UserName = Session["CurrentUser"].ToString();
                                vJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);                                
                            }

                            if (itm.Vacam > 0)
                            {
                                Jv vJv = new Jv();
                                vJv.Branch = short.Parse(Session["Branch"].ToString());
                                vJv.FType = 100;
                                vJv.LocType = 1;
                                vJv.LocNumber = 1;
                                vJv.Number = (int)i;
                                vJv.Post = 1;
                                vJv.FDate = txtEDate.Text;
                                vJv.CostCenter = myAcc.CostCenter;
                                vJv.Project = myAcc.Project;
                                vJv.CarNo = myAcc.CarNo;
                                vJv.Area = myAcc.Area;
                                vJv.CostAcc = (mysetting.AddAcc09.StartsWith("3") ? myAcc.CostAcc : "-1");
                                vJv.EmpCode = myAcc.EmpCode;
                                vJv.Remark = "بدل إجازة للموظف " + itm.Name + " عن شهر " + HDate.Ch_Date(txtEDate.Text).Month.ToString() + "/" + HDate.Ch_Date(txtEDate.Text).Year.ToString();
                                vJv.InvNo = "";
                                vJv.FNo = (short)FNo++;
                                vJv.Amount = Math.Round((double)itm.Vacam, 2); 
                                vJv.DbCode = mysetting.AddAcc09;
                                vJv.UserName = Session["CurrentUser"].ToString();
                                vJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                vJv = new Jv();
                                vJv.Branch = short.Parse(Session["Branch"].ToString());
                                vJv.FType = 100;
                                vJv.LocType = 1;
                                vJv.LocNumber = 1;
                                vJv.Number = (int)i;
                                vJv.Post = 1;
                                vJv.FDate = txtEDate.Text;
                                vJv.CostCenter = myAcc.CostCenter;
                                vJv.Project = myAcc.Project;
                                vJv.CarNo = myAcc.CarNo;
                                vJv.Area = myAcc.Area;
                                vJv.CostAcc = (mysetting.DedAcc06.StartsWith("3") ? myAcc.CostAcc : "-1");
                                vJv.EmpCode = myAcc.EmpCode;
                                vJv.Remark = "بدل إجازة للموظف " + itm.Name + " عن شهر " + HDate.Ch_Date(txtEDate.Text).Month.ToString() + "/" + HDate.Ch_Date(txtEDate.Text).Year.ToString();
                                vJv.InvNo = "";
                                vJv.FNo = (short)FNo2++;
                                vJv.Amount = Math.Round((double)itm.Vacam, 2);
                                vJv.CrCode = mysetting.DedAcc06;
                                vJv.UserName = Session["CurrentUser"].ToString();
                                vJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }

                            if (itm.Awardam > 0)
                            {
                                Jv vJv = new Jv();
                                vJv.Branch = short.Parse(Session["Branch"].ToString());
                                vJv.FType = 100;
                                vJv.LocType = 1;
                                vJv.LocNumber = 1;
                                vJv.Number = (int)i;
                                vJv.Post = 1;
                                vJv.FDate = txtEDate.Text;
                                vJv.CostCenter = myAcc.CostCenter;
                                vJv.Project = myAcc.Project;
                                vJv.CarNo = myAcc.CarNo;                               
                                vJv.Area = myAcc.Area;
                                vJv.CostAcc = (mysetting.AddAcc11.StartsWith("3") ? myAcc.CostAcc : "-1");
                                vJv.EmpCode = myAcc.EmpCode;
                                vJv.Remark = "مخصص مكافأة نهاية الخدمة للموظف " + itm.Name + " عن شهر " + HDate.Ch_Date(txtEDate.Text).Month.ToString() + "/" + HDate.Ch_Date(txtEDate.Text).Year.ToString();
                                vJv.InvNo = "";
                                vJv.FNo = (short)FNo++;
                                vJv.Amount = Math.Round((double)itm.Awardam, 2); 
                                vJv.DbCode = mysetting.AddAcc11;
                                vJv.UserName = Session["CurrentUser"].ToString();
                                vJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                vJv = new Jv();
                                vJv.Branch = short.Parse(Session["Branch"].ToString());
                                vJv.FType = 100;
                                vJv.LocType = 1;
                                vJv.LocNumber = 1;
                                vJv.Number = (int)i;
                                vJv.Post = 1;
                                vJv.FDate = txtEDate.Text;
                                vJv.CostCenter = myAcc.CostCenter;
                                vJv.Project = myAcc.Project;
                                vJv.CarNo = myAcc.CarNo;
                                vJv.Area = myAcc.Area;
                                vJv.CostAcc = (mysetting.DedAcc08.StartsWith("3") ? myAcc.CostAcc : "-1");
                                vJv.EmpCode = myAcc.EmpCode;
                                vJv.Remark = "مخصص مكافأة نهاية الخدمة للموظف " + itm.Name + " عن شهر " + HDate.Ch_Date(txtEDate.Text).Month.ToString() + "/" + HDate.Ch_Date(txtEDate.Text).Year.ToString();
                                vJv.InvNo = "";
                                vJv.FNo = (short)FNo2++;
                                vJv.Amount = Math.Round((double)itm.Awardam, 2);
                                vJv.CrCode = mysetting.DedAcc08;
                                vJv.UserName = Session["CurrentUser"].ToString();
                                vJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);                               
                            }

                            if (itm.IDam > 0)
                            {
                                Jv vJv = new Jv();
                                vJv.Branch = short.Parse(Session["Branch"].ToString());
                                vJv.FType = 100;
                                vJv.LocType = 1;
                                vJv.LocNumber = 1;
                                vJv.Number = (int)i;
                                vJv.Post = 1;
                                vJv.FDate = txtEDate.Text;
                                vJv.CostCenter = myAcc.CostCenter;
                                vJv.Project = myAcc.Project;
                                vJv.CarNo = myAcc.CarNo;
                                vJv.Area = myAcc.Area;
                                vJv.CostAcc = (mysetting.P10db.StartsWith("3") ? myAcc.CostAcc : "-1");
                                vJv.EmpCode = myAcc.EmpCode;
                                vJv.Remark = "أطفاء رسوم تجديد الاقامة ورخصة العمل عن  للموظف " + itm.Name + " عن شهر " + HDate.Ch_Date(txtEDate.Text).Month.ToString() + "/" + HDate.Ch_Date(txtEDate.Text).Year.ToString();
                                vJv.InvNo = "";
                                vJv.FNo = (short)FNo++;
                                vJv.Amount = Math.Round((double)itm.IDam, 2);
                                vJv.DbCode = mysetting.P10db;
                                vJv.UserName = Session["CurrentUser"].ToString();
                                vJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                double vBal = 0;
                                vBal = Math.Round(moh.GetBal(mysetting.P10cr, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString),2);

                                if (vBal <= 0)
                                {
                                    vJv = new Jv();
                                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                                    vJv.FType = 100;
                                    vJv.LocType = 1;
                                    vJv.LocNumber = 1;
                                    vJv.Number = (int)i;
                                    vJv.Post = 1;
                                    vJv.FDate = txtEDate.Text;
                                    vJv.CostCenter = myAcc.CostCenter;
                                    vJv.Project = myAcc.Project;
                                    vJv.CarNo = myAcc.CarNo;
                                    vJv.Area = myAcc.Area;
                                    vJv.CostAcc = "-1";  // myAcc.CostAcc;
                                    vJv.EmpCode = myAcc.EmpCode;
                                    vJv.Remark = "أطفاء رسوم تجديد الاقامة ورخصة العمل عن  للموظف " + itm.Name + " عن شهر " + HDate.Ch_Date(txtEDate.Text).Month.ToString() + "/" + HDate.Ch_Date(txtEDate.Text).Year.ToString();
                                    vJv.InvNo = "";
                                    vJv.FNo = (short)FNo2++;
                                    vJv.Amount = Math.Round((double)itm.IDam, 2);
                                    vJv.CrCode = "240101004";
                                    vJv.UserName = Session["CurrentUser"].ToString();
                                    vJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                    vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                }
                                else if (vBal < Math.Round((double)itm.IDam, 2))
                                {
                                    vJv = new Jv();
                                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                                    vJv.FType = 100;
                                    vJv.LocType = 1;
                                    vJv.LocNumber = 1;
                                    vJv.Number = (int)i;
                                    vJv.Post = 1;
                                    vJv.FDate = txtEDate.Text;
                                    vJv.CostCenter = myAcc.CostCenter;
                                    vJv.Project = myAcc.Project;
                                    vJv.CarNo = myAcc.CarNo;
                                    vJv.Area = myAcc.Area;
                                    vJv.CostAcc = (mysetting.P10cr.StartsWith("3") ? myAcc.CostAcc : "-1");
                                    vJv.EmpCode = myAcc.EmpCode;
                                    vJv.Remark = "أطفاء رسوم تجديد الاقامة ورخصة العمل عن  للموظف " + itm.Name + " عن شهر " + HDate.Ch_Date(txtEDate.Text).Month.ToString() + "/" + HDate.Ch_Date(txtEDate.Text).Year.ToString();
                                    vJv.InvNo = "";
                                    vJv.FNo = (short)FNo2++;
                                    vJv.Amount = Math.Round((double)vBal, 2);
                                    vJv.CrCode = mysetting.P10cr;
                                    vJv.UserName = Session["CurrentUser"].ToString();
                                    vJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                    vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                    vJv = new Jv();
                                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                                    vJv.FType = 100;
                                    vJv.LocType = 1;
                                    vJv.LocNumber = 1;
                                    vJv.Number = (int)i;
                                    vJv.Post = 1;
                                    vJv.FDate = txtEDate.Text;
                                    vJv.CostCenter = myAcc.CostCenter;
                                    vJv.Project = myAcc.Project;
                                    vJv.CarNo = myAcc.CarNo;
                                    vJv.Area = myAcc.Area;
                                    vJv.CostAcc = "-1"; // myAcc.CostAcc;
                                    vJv.EmpCode = myAcc.EmpCode;
                                    vJv.Remark = "أطفاء رسوم تجديد الاقامة ورخصة العمل عن  للموظف " + itm.Name + " عن شهر " + HDate.Ch_Date(txtEDate.Text).Month.ToString() + "/" + HDate.Ch_Date(txtEDate.Text).Year.ToString();
                                    vJv.InvNo = "";
                                    vJv.FNo = (short)FNo2++;
                                    vJv.Amount = Math.Round((double)itm.IDam - vBal, 2);
                                    vJv.CrCode = "240101004";
                                    vJv.UserName = Session["CurrentUser"].ToString();
                                    vJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                    vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                }
                                else
                                {
                                    vJv = new Jv();
                                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                                    vJv.FType = 100;
                                    vJv.LocType = 1;
                                    vJv.LocNumber = 1;
                                    vJv.Number = (int)i;
                                    vJv.Post = 1;
                                    vJv.FDate = txtEDate.Text;
                                    vJv.CostCenter = myAcc.CostCenter;
                                    vJv.Project = myAcc.Project;
                                    vJv.CarNo = myAcc.CarNo;
                                    vJv.Area = myAcc.Area;
                                    vJv.CostAcc = (mysetting.P10cr.StartsWith("3") ? myAcc.CostAcc : "-1");
                                    vJv.EmpCode = myAcc.EmpCode;
                                    vJv.Remark = "أطفاء رسوم تجديد الاقامة ورخصة العمل عن  للموظف " + itm.Name + " عن شهر " + HDate.Ch_Date(txtEDate.Text).Month.ToString() + "/" + HDate.Ch_Date(txtEDate.Text).Year.ToString();
                                    vJv.InvNo = "";
                                    vJv.FNo = (short)FNo2++;
                                    vJv.Amount = Math.Round((double)itm.IDam, 2);
                                    vJv.CrCode = mysetting.P10cr;
                                    vJv.UserName = Session["CurrentUser"].ToString();
                                    vJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                    vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                }
                            }

                            if (itm.Insam > 0)
                            {
                                Jv vJv = new Jv();
                                vJv.Branch = short.Parse(Session["Branch"].ToString());
                                vJv.FType = 100;
                                vJv.LocType = 1;
                                vJv.LocNumber = 1;
                                vJv.Number = (int)i;
                                vJv.Post = 1;
                                vJv.FDate = txtEDate.Text;
                                vJv.CostCenter = myAcc.CostCenter;
                                vJv.Project = myAcc.Project;
                                vJv.CarNo = myAcc.CarNo;
                                vJv.Area = myAcc.Area;
                                vJv.CostAcc = (mysetting.P11db.StartsWith("3") ? myAcc.CostAcc : "-1");
                                vJv.EmpCode = myAcc.EmpCode;
                                vJv.Remark = "أطفاء تأمين صحي عن  للموظف " + itm.Name + " عن شهر " + HDate.Ch_Date(txtEDate.Text).Month.ToString() + "/" + HDate.Ch_Date(txtEDate.Text).Year.ToString();
                                vJv.InvNo = "";
                                vJv.FNo = (short)FNo++;
                                vJv.Amount = Math.Round((double)itm.Insam, 2);
                                vJv.DbCode = mysetting.P11db;
                                vJv.UserName = Session["CurrentUser"].ToString();
                                vJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);


                                double vBal = 0;
                                vBal = Math.Round((double)moh.GetBal(mysetting.P11cr, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString),2);
                                if (vBal <= 0)
                                {
                                    vJv = new Jv();
                                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                                    vJv.FType = 100;
                                    vJv.LocType = 1;
                                    vJv.LocNumber = 1;
                                    vJv.Number = (int)i;
                                    vJv.Post = 1;
                                    vJv.FDate = txtEDate.Text;
                                    vJv.CostCenter = myAcc.CostCenter;
                                    vJv.Project = myAcc.Project;
                                    vJv.CarNo = myAcc.CarNo;
                                    vJv.Area = myAcc.Area;
                                    vJv.CostAcc = "-1"; // myAcc.CostAcc;
                                    vJv.EmpCode = myAcc.EmpCode;
                                    vJv.Remark = "أطفاء تأمين صحي عن  للموظف " + itm.Name + " عن شهر " + HDate.Ch_Date(txtEDate.Text).Month.ToString() + "/" + HDate.Ch_Date(txtEDate.Text).Year.ToString();
                                    vJv.InvNo = "";
                                    vJv.FNo = (short)FNo2++;
                                    vJv.Amount = Math.Round((double)itm.Insam, 2);
                                    vJv.CrCode = "240101005";
                                    vJv.UserName = Session["CurrentUser"].ToString();
                                    vJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                    vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                }
                                else if (vBal < Math.Round((double)itm.Insam, 2))
                                {
                                    vJv = new Jv();
                                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                                    vJv.FType = 100;
                                    vJv.LocType = 1;
                                    vJv.LocNumber = 1;
                                    vJv.Number = (int)i;
                                    vJv.Post = 1;
                                    vJv.FDate = txtEDate.Text;
                                    vJv.CostCenter = myAcc.CostCenter;
                                    vJv.Project = myAcc.Project;
                                    vJv.CarNo = myAcc.CarNo;
                                    vJv.Area = myAcc.Area;
                                    vJv.CostAcc = (mysetting.P11cr.StartsWith("3") ? myAcc.CostAcc : "-1");
                                    vJv.EmpCode = myAcc.EmpCode;
                                    vJv.Remark = "أطفاء تأمين صحي عن  للموظف " + itm.Name + " عن شهر " + HDate.Ch_Date(txtEDate.Text).Month.ToString() + "/" + HDate.Ch_Date(txtEDate.Text).Year.ToString();
                                    vJv.InvNo = "";
                                    vJv.FNo = (short)FNo2++;
                                    vJv.Amount = Math.Round((double)vBal, 2);
                                    vJv.CrCode = mysetting.P11cr;
                                    vJv.UserName = Session["CurrentUser"].ToString();
                                    vJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                    vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                    vJv = new Jv();
                                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                                    vJv.FType = 100;
                                    vJv.LocType = 1;
                                    vJv.LocNumber = 1;
                                    vJv.Number = (int)i;
                                    vJv.Post = 1;
                                    vJv.FDate = txtEDate.Text;
                                    vJv.CostCenter = myAcc.CostCenter;
                                    vJv.Project = myAcc.Project;
                                    vJv.CarNo = myAcc.CarNo;
                                    vJv.Area = myAcc.Area;
                                    vJv.CostAcc = "-1";  // myAcc.CostAcc;
                                    vJv.EmpCode = myAcc.EmpCode;
                                    vJv.Remark = "أطفاء تأمين صحي عن  للموظف " + itm.Name + " عن شهر " + HDate.Ch_Date(txtEDate.Text).Month.ToString() + "/" + HDate.Ch_Date(txtEDate.Text).Year.ToString();
                                    vJv.InvNo = "";
                                    vJv.FNo = (short)FNo2++;
                                    vJv.Amount = Math.Round((double)itm.Insam - vBal, 2);
                                    vJv.CrCode = "240101005";
                                    vJv.UserName = Session["CurrentUser"].ToString();
                                    vJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                    vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                }
                                else
                                {
                                    vJv = new Jv();
                                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                                    vJv.FType = 100;
                                    vJv.LocType = 1;
                                    vJv.LocNumber = 1;
                                    vJv.Number = (int)i;
                                    vJv.Post = 1;
                                    vJv.FDate = txtEDate.Text;
                                    vJv.CostCenter = myAcc.CostCenter;
                                    vJv.Project = myAcc.Project;
                                    vJv.CarNo = myAcc.CarNo;
                                    vJv.Area = myAcc.Area;
                                    vJv.CostAcc = (mysetting.P11cr.StartsWith("3") ? myAcc.CostAcc : "-1");
                                    vJv.EmpCode = myAcc.EmpCode;
                                    vJv.Remark = "أطفاء تأمين صحي عن  للموظف " + itm.Name + " عن شهر " + HDate.Ch_Date(txtEDate.Text).Month.ToString() + "/" + HDate.Ch_Date(txtEDate.Text).Year.ToString();
                                    vJv.InvNo = "";
                                    vJv.FNo = (short)FNo2++;
                                    vJv.Amount = Math.Round((double)itm.Insam, 2);
                                    vJv.CrCode = mysetting.P11cr;
                                    vJv.UserName = Session["CurrentUser"].ToString();
                                    vJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                    vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                }
                            }

                            if (itm.Workeram > 0)
                            {
                                Jv vJv = new Jv();
                                vJv.Branch = short.Parse(Session["Branch"].ToString());
                                vJv.FType = 100;
                                vJv.LocType = 1;
                                vJv.LocNumber = 1;
                                vJv.Number = (int)i;
                                vJv.Post = 1;
                                vJv.FDate = txtEDate.Text;
                                vJv.CostCenter = myAcc.CostCenter;
                                vJv.Project = myAcc.Project;
                                vJv.CarNo = myAcc.CarNo;
                                vJv.Area = myAcc.Area;
                                vJv.CostAcc = (mysetting.P12db.StartsWith("3") ? myAcc.CostAcc : "-1");
                                vJv.EmpCode = myAcc.EmpCode;
                                vJv.Remark = "أطفاء رسوم المقابل المالي عن  للموظف " + itm.Name + " عن شهر " + HDate.Ch_Date(txtEDate.Text).Month.ToString() + "/" + HDate.Ch_Date(txtEDate.Text).Year.ToString();
                                vJv.InvNo = "";
                                vJv.FNo = (short)FNo++;
                                vJv.Amount = Math.Round((double)itm.Workeram, 2);
                                vJv.DbCode = mysetting.P12db;
                                vJv.UserName = Session["CurrentUser"].ToString();
                                vJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                double vBal = 0;
                                vBal = Math.Round(moh.GetBal(mysetting.P12cr, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString),2);
                                if (vBal <= 0)
                                {
                                    vJv = new Jv();
                                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                                    vJv.FType = 100;
                                    vJv.LocType = 1;
                                    vJv.LocNumber = 1;
                                    vJv.Number = (int)i;
                                    vJv.Post = 1;
                                    vJv.FDate = txtEDate.Text;
                                    vJv.CostCenter = myAcc.CostCenter;
                                    vJv.Project = myAcc.Project;
                                    vJv.CarNo = myAcc.CarNo;
                                    vJv.Area = myAcc.Area;
                                    vJv.CostAcc = "-1"; // myAcc.CostAcc;
                                    vJv.EmpCode = myAcc.EmpCode;
                                    vJv.Remark = "أطفاء رسوم المقابل المالي عن  للموظف " + itm.Name + " عن شهر " + HDate.Ch_Date(txtEDate.Text).Month.ToString() + "/" + HDate.Ch_Date(txtEDate.Text).Year.ToString();
                                    vJv.InvNo = "";
                                    vJv.FNo = (short)FNo2++;
                                    vJv.Amount = Math.Round((double)itm.Workeram, 2);
                                    vJv.CrCode = "240101007";
                                    vJv.UserName = Session["CurrentUser"].ToString();
                                    vJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                    vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                }
                                else if (vBal < Math.Round((double)itm.Workeram, 2))
                                {
                                    vJv = new Jv();
                                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                                    vJv.FType = 100;
                                    vJv.LocType = 1;
                                    vJv.LocNumber = 1;
                                    vJv.Number = (int)i;
                                    vJv.Post = 1;
                                    vJv.FDate = txtEDate.Text;
                                    vJv.CostCenter = myAcc.CostCenter;
                                    vJv.Project = myAcc.Project;
                                    vJv.CarNo = myAcc.CarNo;
                                    vJv.Area = myAcc.Area;
                                    vJv.CostAcc = (mysetting.P12cr.StartsWith("3") ? myAcc.CostAcc : "-1");
                                    vJv.EmpCode = myAcc.EmpCode;
                                    vJv.Remark = "أطفاء رسوم المقابل المالي عن  للموظف " + itm.Name + " عن شهر " + HDate.Ch_Date(txtEDate.Text).Month.ToString() + "/" + HDate.Ch_Date(txtEDate.Text).Year.ToString();
                                    vJv.InvNo = "";
                                    vJv.FNo = (short)FNo2++;
                                    vJv.Amount = Math.Round((double)vBal, 2);
                                    vJv.CrCode = mysetting.P12cr;
                                    vJv.UserName = Session["CurrentUser"].ToString();
                                    vJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                    vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                    vJv = new Jv();
                                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                                    vJv.FType = 100;
                                    vJv.LocType = 1;
                                    vJv.LocNumber = 1;
                                    vJv.Number = (int)i;
                                    vJv.Post = 1;
                                    vJv.FDate = txtEDate.Text;
                                    vJv.CostCenter = myAcc.CostCenter;
                                    vJv.Project = myAcc.Project;
                                    vJv.CarNo = myAcc.CarNo;
                                    vJv.Area = myAcc.Area;
                                    vJv.CostAcc = "-1";  // myAcc.CostAcc;
                                    vJv.EmpCode = myAcc.EmpCode;
                                    vJv.Remark = "أطفاء رسوم المقابل المالي عن  للموظف " + itm.Name + " عن شهر " + HDate.Ch_Date(txtEDate.Text).Month.ToString() + "/" + HDate.Ch_Date(txtEDate.Text).Year.ToString();
                                    vJv.InvNo = "";
                                    vJv.FNo = (short)FNo2++;
                                    vJv.Amount = Math.Round((double)itm.Workeram - vBal, 2);
                                    vJv.CrCode = "240101007";
                                    vJv.UserName = Session["CurrentUser"].ToString();
                                    vJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                    vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                }
                                else
                                {
                                    vJv = new Jv();
                                    vJv.Branch = short.Parse(Session["Branch"].ToString());
                                    vJv.FType = 100;
                                    vJv.LocType = 1;
                                    vJv.LocNumber = 1;
                                    vJv.Number = (int)i;
                                    vJv.Post = 1;
                                    vJv.FDate = txtEDate.Text;
                                    vJv.CostCenter = myAcc.CostCenter;
                                    vJv.Project = myAcc.Project;
                                    vJv.CarNo = myAcc.CarNo;
                                    vJv.Area = myAcc.Area;
                                    vJv.CostAcc = (mysetting.P12cr.StartsWith("3") ? myAcc.CostAcc : "-1");
                                    vJv.EmpCode = myAcc.EmpCode;
                                    vJv.Remark = "أطفاء رسوم المقابل المالي عن  للموظف " + itm.Name + " عن شهر " + HDate.Ch_Date(txtEDate.Text).Month.ToString() + "/" + HDate.Ch_Date(txtEDate.Text).Year.ToString();
                                    vJv.InvNo = "";
                                    vJv.FNo = (short)FNo2++;
                                    vJv.Amount = Math.Round((double)itm.Workeram, 2);
                                    vJv.CrCode = mysetting.P12cr;
                                    vJv.UserName = Session["CurrentUser"].ToString();
                                    vJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                    vJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                }
                            }

                        }
                    }


                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = "قيد يومية";
                        UserTran.FormAction = "اضافة";
                        UserTran.Description = "اضافة قيد يومية رقم " + i.ToString();
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult.Text = "لقد تمت أضافة بيانات القيد يومية رقم " + i.ToString() + " بنجاح";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
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

        protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
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

    [Serializable]
    public class SalAllow
    {
        public int? FNo { get; set; }
        public int EmpCode { get; set; }
        public string Name { get; set; }
        public string JoinDate { get; set; }
        public string ReturnDate { get; set; }
        public string VacDate { get; set; }
        public double? Basic { get; set; }
        public double? Add01 { get; set; }
        public double? Add02 { get; set; }
        public double? AddAll0 { get; set; }
        public double? totVac { get; set; }
        public double? totAward { get; set; }
        public double? DutyDays { get; set; }
        public double? VacDays { get; set; }
        public double? Vac { get; set; }
        public double? TicketValue { get; set; }
        public double? TicketNo { get; set; }
        public double? totTicket { get; set; }
        public double? Ticketam { get; set; }
        public double? Vacam { get; set; }
        public double? Awardam { get; set; }
        public double? IDam { get; set; }
        public double? Workeram { get; set; }
        public double? Insam { get; set; }

        public SalAllow()
        {
            this.FNo = 0;
            this.EmpCode = 0;
            this.Name = "";
            this.JoinDate = "";
            this.ReturnDate = "";
            this.VacDate = "";
            this.Basic = 0;
            this.Add01 = 0;
            this.Add02 = 0;
            this.AddAll0 = 0;
            this.totVac = 0;
            this.totAward = 0;
            this.DutyDays = 0;
            this.VacDays = 0;
            this.Vac = 0;
            this.TicketValue = 0;
            this.TicketNo = 0;
            this.totTicket = 0;
            this.Ticketam = 0;
            this.Vacam = 0;
            this.Awardam = 0;
            this.IDam = 0;
            this.Workeram = 0;
            this.Insam = 0;
        }
    }
}