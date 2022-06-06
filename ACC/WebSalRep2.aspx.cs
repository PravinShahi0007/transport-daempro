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
    public partial class WebSalRep2 : System.Web.UI.Page
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
        public string TotalAdd00
        {
            get
            {
                if (ViewState["TotalAdd00"] == null)
                {
                    ViewState["TotalAdd00"] = "0.00";
                }
                return ViewState["TotalAdd00"].ToString();
            }
            set { ViewState["TotalAdd00"] = value; }
        }
        public string TotalDed00
        {
            get
            {
                if (ViewState["TotalDed00"] == null)
                {
                    ViewState["TotalDed00"] = "0.00";
                }
                return ViewState["TotalDed00"].ToString();
            }
            set { ViewState["TotalDed00"] = value; }
        }
        public string TotalNet
        {
            get
            {
                if (ViewState["TotalNet"] == null)
                {
                    ViewState["TotalNet"] = "0.00";
                }
                return ViewState["TotalNet"].ToString();
            }
            set { ViewState["TotalNet"] = value; }
        }

        public List<Salaries> MyOver
        {
            get
            {
                if (ViewState["MyOver"] == null)
                {
                    ViewState["MyOver"] = new List<Salaries>();
                }
                return (List<Salaries>)ViewState["MyOver"];
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
                    this.Page.Header.Title = "كشف الرواتب البنك";

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
                        UserTran.Description = "اختيار عرض كشف الرواتب البنك";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    ChkSection.DataTextField = "Name1";
                    ChkSection.DataValueField = "Code";
                  

                    Codes myCode = new Codes();
                    myCode.Branch = short.Parse(Session["Branch"].ToString());
                    myCode.Ftype = 3;
                    if (Cache["LastCodes" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCodes" + Session["CNN2"].ToString(), myCode.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ChkSection.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                             where itm.Ftype == 3
                                             select itm).ToList();
                    ChkSection.DataBind();

                    Salaries mySal = new Salaries();
                    ddlMonth.DataSource = mySal.GetMonth(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlMonth.DataBind();
                    ddlMonth.Items.Insert(0, new ListItem("---  الاساسي  ---", "-1", true));
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

        public bool CheckSection(string sec)
        {
            bool vResult = false;
            for (int i=0; i<ChkSection.Items.Count; i++)
            {
                if (ChkSection.Items[i].Selected && ChkSection.Items[i].Value == sec)
                {
                    vResult = true;
                    break;
                }
            }
            return vResult;
         }


        protected void LoadCodesData()
        {
            try
            {
                int fno = 1;
                if (ddlMonth.SelectedIndex == 0)
                {                    
                    SEmp myacc = new SEmp();
                    MyOver = (from itm in myacc.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                              where CheckSection(itm.Section.ToString()) && itm.ATM != "" 
                              select new Salaries
                              {
                                  FNo = (short)fno++,
                                  Year1 = 0,
                                  Month1 = 0,
                                  EmpCode = itm.EmpCode,
                                  Basic = itm.Basic,
                                  Add02 = itm.Add02,
                                  Add00 = itm.Add01 + itm.Add03 + itm.Add04 + itm.Add05 + itm.Add06 + itm.Add13 + +itm.Add14,
                                  Ded00 = (itm.Ded01 - itm.Add07 - itm.Add08 )+ itm.Ded02 + itm.Ded03 + itm.Ded04 + itm.Ded09 + itm.Ded10 + itm.Ded12 + itm.Ded13 + itm.Ded14 + itm.Ded15,
                                  Add01 = itm.Add01,
                                  Add03 = itm.Add03,
                                  Add04 = itm.Add04,
                                  Add05 = itm.Add05,
                                  Add06 = itm.Add06,
                                  Add07 = itm.Add07,
                                  Add08 = itm.Add08,
                                  Add09 = itm.Add09,
                                  Add10 = itm.Add10,
                                  Add11 = itm.Add11,
                                  Add12 = itm.Add12,
                                  Add13 = itm.Add13,
                                  Add14 = itm.Add14,
                                  Add15 = itm.Add15,
                                  Ded01 = itm.Ded01,
                                  Ded02 = itm.Ded02,
                                  Ded03 = itm.Ded03,
                                  Ded04 = itm.Ded04,
                                  Ded05 = itm.Ded05,
                                  Ded06 = itm.Ded06,
                                  Ded07 = itm.Ded07,
                                  Ded08 = itm.Ded08,
                                  Ded09 = itm.Ded09,
                                  Ded10 = itm.Ded10,
                                  Ded11 = itm.Ded11,
                                  Ded12 = itm.Ded12,
                                  Ded13 = itm.Ded13,
                                  Ded14 = itm.Ded14,
                                  Ded15 = itm.Ded15,
                                  Name = itm.Name2,                                 
                                  ATM = itm.ATM,
                                  PaperNo1 = itm.PaperNo1
                              }).ToList();
                }
                else
                {
                    Salaries myacc = new Salaries();
                    myacc.Year1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                    myacc.Month1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                    MyOver = (from itm in myacc.GetAllSalary(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                              where CheckSection(itm.Section.ToString()) && itm.ATM != "" && itm.Net != 0 &&
                            (this.rdotype.SelectedValue == "2" || (this.rdotype.SelectedValue == "0" && (bool)itm.Status) || (this.rdotype.SelectedValue == "1" && !(bool)itm.Status))
                                select new Salaries
                                {
                                    FNo = (short)fno++,
                                    Year1 = 0,
                                    Month1 = 0,
                                    EmpCode = itm.EmpCode,
                                    Basic = itm.Basic,
                                    Add02 = itm.Add02,
                                    Add00 = itm.Add01 + itm.Add03 + itm.Add04 + itm.Add05 + itm.Add06 + itm.Add13 + +itm.Add14,
                                    Ded00 = (itm.Ded01 - itm.Add07 - itm.Add08) + itm.Ded02 + itm.Ded03 + itm.Ded04 + itm.Ded09 + itm.Ded10 + itm.Ded12 + itm.Ded13 + itm.Ded14 + itm.Ded15,
                                    Add01 = itm.Add01,
                                    Add03 = itm.Add03,
                                    Add04 = itm.Add04,
                                    Add05 = itm.Add05,
                                    Add06 = itm.Add06,
                                    Add07 = itm.Add07,
                                    Add08 = itm.Add08,
                                    Add09 = itm.Add09,
                                    Add10 = itm.Add10,
                                    Add11 = itm.Add11,
                                    Add12 = itm.Add12,
                                    Add13 = itm.Add13,
                                    Add14 = itm.Add14,
                                    Add15 = itm.Add15,
                                    Ded01 = itm.Ded01,
                                    Ded02 = itm.Ded02,
                                    Ded03 = itm.Ded03,
                                    Ded04 = itm.Ded04,
                                    Ded05 = itm.Ded05,
                                    Ded06 = itm.Ded06,
                                    Ded07 = itm.Ded07,
                                    Ded08 = itm.Ded08,
                                    Ded09 = itm.Ded09,
                                    Ded10 = itm.Ded10,
                                    Ded11 = itm.Ded11,
                                    Ded12 = itm.Ded12,
                                    Ded13 = itm.Ded13,
                                    Ded14 = itm.Ded14,
                                    Ded15 = itm.Ded15,
                                    Name = itm.Name2,                                 
                                    ATM = itm.ATM,
                                    PaperNo1 = itm.PaperNo1
                                }).ToList();
                }
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
                Label lblTotalAdd02 = grdCodes.FooterRow.FindControl("lblTotalAdd02") as Label;
                Label lblTotalAdd00 = grdCodes.FooterRow.FindControl("lblTotalAdd00") as Label;
                Label lblTotalDed00 = grdCodes.FooterRow.FindControl("lblTotalDed00") as Label;
                Label lblTotalNet = grdCodes.FooterRow.FindControl("lblTotalNet") as Label;

                double Basic = 0, Add01 = 0, Add02 = 0, Add00 = 0 , Ded00 = 0 , Net = 0;
                foreach (Salaries itm in MyOver)
                {
                    Basic += (double)itm.Basic;
                    Add01 += (double)itm.Add01;
                    Add02 += (double)itm.Add02;
                    Add00 += (double)itm.Add00;
                    Ded00 += (double)itm.Ded00;
                    Net += (double)itm.Net;
                }

                if (lblTotalNet != null)
                {
                    lblTotalNet.Text = string.Format("{0:N2}", Math.Round(Net, 2));
                    TotalNet = lblTotalNet.Text;
                }

                if (lblTotalDed00 != null)
                {
                    lblTotalDed00.Text = string.Format("{0:N2}", Ded00);
                    TotalDed00 = lblTotalDed00.Text;
                }

                if (lblTotalAdd00 != null)
                {
                    lblTotalAdd00.Text = string.Format("{0:N2}", Add00);
                    TotalAdd00 = lblTotalAdd00.Text;
                }

                if (lblTotalAdd02 != null)
                {
                    lblTotalAdd02.Text = string.Format("{0:N2}", Add02);
                    TotalAdd02 = lblTotalAdd02.Text;
                }


                if (lblTotalBasic != null)
                {
                    lblTotalBasic.Text = string.Format("{0:N2}", Basic);
                    TotalBasic = lblTotalBasic.Text;
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
                var cols = new[] { 100, 100, 100, 100, 100, 100, 250, 150, 60, 30 };

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
                MyConfig mysetting = new MyConfig();
                mysetting.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mysetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                mysetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);

                page.vStr1 = (ddlMonth.SelectedIndex == 0 ? "" : "لشهر  " + ddlMonth.SelectedItem.Text.Split('/')[1] + "/" + ddlMonth.SelectedItem.Text.Split('/')[0]);

                for (int i = 0; i < ChkSection.Items.Count; i++)
                {
                    if (ChkSection.Items[i].Selected)
                    {
                        page.vStr1 += " - " + ChkSection.Items[i].Text;
                    }
                }
                pw.PageEvent = page;

                BaseFont nationalBase;
                string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);
                document.Open();

                PdfPTable table = new PdfPTable(10);
                table.SetWidths(cols);
                PdfPCell cell = new PdfPCell();
                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                foreach (Salaries itm in MyOver)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(itm.FNo.ToString(), nationalTextFont);
                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.EmpCode.ToString(), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.ATM, nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.Name, nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.PaperNo1, nationalTextFont);
                    table.AddCell(cell);


                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Net), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Basic), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Add02), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Add00), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Ded00), nationalTextFont);
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

                cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalNet, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalBasic, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalAdd02, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalAdd00, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalDed00, nationalTextFont);
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
                cell2.Phrase = new iTextSharp.text.Phrase("كشف تحويلات رواتب البنك " + vStr1, nationalTextFont);
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
                nationalTextFont = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);

                    PdfPTable table = new PdfPTable(10);
                    var cols = new[] { 100, 100, 100, 100, 100, 100, 250, 150, 60, 30 };
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

                    cell.Phrase = new iTextSharp.text.Phrase("ATM", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الاسم", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("ID", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الصافي", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الاساسي", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("بدل السكن", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("أخرى", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("حسميات أخرى", nationalTextFont);
                    table.AddCell(cell);

                    //headerTbl.WriteSelectedRows(0, -1, -1, (doc.PageSize.Height - 20), writer.DirectContent);
                    doc.Add(table);
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

            for (int i = 0; i < grdCodes.Rows.Count; i++)
            {
                GridViewRow row = grdCodes.Rows[i];

                //    //Change Color back to white
                //    row.BackColor = System.Drawing.Color.White;

                //    //Apply text style to each Row
                row.Attributes.Add("class", "textmode");
                row.Cells[2].Style.Add("mso-number-format", @"\@"); // ATM Card
                row.Cells[3].Style.Add("text-align", "left");
                row.Cells[5].Style.Add("text-align", "left");
                row.Cells[6].Style.Add("text-align", "left");
                row.Cells[7].Style.Add("text-align", "right");
                row.Cells[8].Style.Add("text-align", "right");
                row.Cells[9].Style.Add("text-align", "right");
                row.Cells[10].Style.Add("text-align", "right");

                //    //Apply style to Individual Cells of Alternating Row
                //    if (i % 2 != 0)
                //    {
                //for (int r = 0; r < row.Cells.Count; r++)
                //{
                //    row.Cells[r].Style.Add("background-color", "#C2D69B");
                //    row.Cells[r].Style.Add("mso-number-format", @"\@");
                //}
                //        row.Cells[1].Style.Add("background-color", "#C2D69B");
                //        row.Cells[2].Style.Add("background-color", "#C2D69B");
                //        row.Cells[3].Style.Add("background-color", "#C2D69B");
                //    }
            }
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
            LoadCodesData();
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void ChkSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void rdotype_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void ChkDep_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ChkSection.Items.Count;i++ )
            {
                ChkSection.Items[i].Selected = ChkDep.Checked;
            }
        }

    }
}