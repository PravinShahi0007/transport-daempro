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
using System.Configuration;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class WebDaleel : System.Web.UI.Page
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
        public List<Acc> MyOver
        {
            get
            {
                if (ViewState["MyOver"] == null)
                {
                    ViewState["MyOver"] = new List<Acc>();
                }
                return (List<Acc>)ViewState["MyOver"];
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

                    Acc myacc = new Acc();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["AllACC" + Session["CNN2"].ToString()] == null) Cache.Insert("AllACC" + Session["CNN2"].ToString(), myacc.Getall(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    MyOver = (from itm in (List<Acc>)(Cache["AllACC" + Session["CNN2"].ToString()])
                                           select new Acc
                                           {
                                               Branch = itm.Branch,
                                               Code = itm.Code,
                                               FCode = itm.FCode,
                                               MCode = itm.MCode,
                                               FLevel = itm.FLevel,
                                               Name1 = itm.Name1,
                                               Name2 = itm.Name2,
                                               DAcc = itm.DAcc,
                                               CAcc = itm.CAcc,
                                               MDAcc = itm.MDAcc,
                                               MCAcc = itm.MCAcc,
                                               TDAcc = itm.TDAcc,
                                               TCAcc = itm.TCAcc,
                                               ODAcc = itm.ODAcc,
                                               OCAcc = itm.OCAcc,
                                               FDAcc = itm.FDAcc,
                                               FCAcc = itm.FCAcc,
                                               Coin = itm.Coin,
                                               LastLevel = itm.LastLevel,
                                               DepPer = itm.DepPer,
                                               DepCode = itm.DepCode,
                                               FixPurch = itm.FixPurch,
                                               FixCurrent = itm.FixCurrent,
                                               FixPurDate = itm.FixPurDate,
                                               DepAmount = itm.DepAmount,
                                               TelNo = itm.TelNo,
                                               FaxNo = itm.FaxNo,
                                               MobileNo = itm.MobileNo,
                                               FixCurDate = itm.FixCurDate,
                                               Address = itm.Address,
                                               CRLimit = itm.CRLimit,
                                               HCRLimit = itm.HCRLimit,
                                               LCRLimit = itm.LCRLimit,
                                               CustPer = itm.CustPer,
                                               Salesman = itm.Salesman,
                                               BatchCode = itm.BatchCode,
                                               DepDo = itm.DepDo,
                                               DepMethod = itm.DepMethod,
                                               DDAcc = itm.DDAcc,
                                               DCAcc = itm.DCAcc,
                                               Remark = itm.Remark,
                                               FType = itm.FType,
                                               SType = itm.SType,
                                               Stype1 = itm.Stype1,
                                               HCRPeriod = itm.HCRPeriod,
                                               TranType = itm.TranType,
                                               TranBal = itm.TranBal,
                                               TranNo = itm.TranNo,
                                               ACDep = itm.ACDep,
                                               FUpdate = itm.FUpdate
                                           }).ToList();
                    grdCodes.DataBind();

                    ddlFather.DataValueField = "Code";
                    ddlFather.DataTextField = "Name1";
                    ddlFather.DataSource = (from itm in MyOver
                                            where itm.FLevel != 5
                                            select new
                                            {
                                                Code = itm.Code,
                                                Name1 = itm.Name1
                                            }).ToList();
                    ddlFather.DataBind();
                    ddlFather.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--- جميع الحسابات ---", "0", true));
                    ddlFather.SelectedIndex = 0;
                    this.Page.Header.Title = "دليل الحسابات";

                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = "الرئيسية";
                        UserTran.FormAction = "اختيار";
                        UserTran.Description = "اختيار عرض دليل الحسابات";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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

        public bool getitem(Acc itm)
        {
            if (ddlLevel.SelectedValue == "0")
            {
                if (ddlFather.SelectedIndex < 1)
                {
                    return true;
                }
                else
                {
                    return (itm.FCode.StartsWith(ddlFather.SelectedValue));
                }
            }
            else
            {
                if (ddlFather.SelectedIndex < 1)
                {
                    return (itm.FLevel == short.Parse(ddlLevel.SelectedValue));
                }
                else
                {
                    return (itm.FLevel == short.Parse(ddlLevel.SelectedValue)) && (itm.FCode.StartsWith(ddlFather.SelectedValue));
                }            
            }
        }
        protected void LoadCodesData()
        {
            try
            {
                Acc myacc = new Acc();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                grdCodes.DataSource = (from itm in MyOver
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
                                           DAcc = itm.DAcc,
                                           CAcc = itm.CAcc,
                                           MDAcc = itm.MDAcc,
                                           MCAcc = itm.MCAcc,
                                           TDAcc = itm.TDAcc,
                                           TCAcc = itm.TCAcc,
                                           ODAcc = itm.ODAcc,
                                           OCAcc = itm.OCAcc,
                                           FDAcc = itm.FDAcc,
                                           FCAcc = itm.FCAcc,
                                           Coin = itm.Coin,
                                           LastLevel = itm.LastLevel,
                                           DepPer = itm.DepPer,
                                           DepCode = itm.DepCode,
                                           FixPurch = itm.FixPurch,
                                           FixCurrent = itm.FixCurrent,
                                           FixPurDate = itm.FixPurDate,
                                           DepAmount = itm.DepAmount,
                                           TelNo = itm.TelNo,
                                           FaxNo = itm.FaxNo,
                                           MobileNo = itm.MobileNo,
                                           FixCurDate = itm.FixCurDate,
                                           Address = itm.Address,
                                           CRLimit = itm.CRLimit,
                                           HCRLimit = itm.HCRLimit,
                                           LCRLimit = itm.LCRLimit,
                                           CustPer = itm.CustPer,
                                           Salesman = itm.Salesman,
                                           BatchCode = itm.BatchCode,
                                           DepDo = itm.DepDo,
                                           DepMethod = itm.DepMethod,
                                           DDAcc = itm.DDAcc,
                                           DCAcc = itm.DCAcc,
                                           Remark = itm.Remark,
                                           FType = itm.FType,
                                           SType = itm.SType,
                                           Stype1 = itm.Stype1,
                                           HCRPeriod = itm.HCRPeriod,
                                           TranType = itm.TranType,
                                           TranBal = itm.TranBal,
                                           TranNo = itm.TranNo,
                                           ACDep = itm.ACDep,
                                           FUpdate = itm.FUpdate
                                       }).ToList();
                grdCodes.DataBind();
                lblCount.Text = ((List<Acc>)grdCodes.DataSource).Count().ToString();
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
                iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, -50, -50, 80, 50);
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
                pw.PageEvent = page;
                document.Open();
                //PdfPTable table = new PdfPTable(grdCodes.HeaderRow.Cells.Count);
                PdfPTable table = new PdfPTable(4);
                float[] colWidths = { 120, 200, 200, 100 };
                table.SetWidths(colWidths);
                PdfPCell cell = new PdfPCell();
                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";                    
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 8f, iTextSharp.text.Font.NORMAL);

                foreach (Acc itm in (from itm in MyOver
                                       where getitem(itm)                                       
                                       select itm).ToList())
                {
                    cell.Phrase = new iTextSharp.text.Phrase(itm.Code, nationalTextFont);
                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.Name1, nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.Name2, nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.ftype2, nationalTextFont);
                    table.AddCell(cell);
                }
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
            public string UserName, PageNo, vCompanyName;
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
                cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell2.Phrase = new iTextSharp.text.Phrase(vCompanyName + "\n" + "الإدارة المالية", nationalTextFont);
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                headerTbl.AddCell(cell2);

                cell2.PaddingRight = 0;
                cell2.Phrase = new iTextSharp.text.Phrase("دليل الحسابات", nationalTextFont);
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
                nationalTextFont = new iTextSharp.text.Font(nationalBase, 10f, iTextSharp.text.Font.NORMAL);


                PdfPTable table = new PdfPTable(4);
                float[] colWidths = { 120, 200, 200, 100 };
                table.SetWidths(colWidths);
                PdfPCell cell = new PdfPCell();
                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                cell.Phrase = new iTextSharp.text.Phrase("كود الحساب", nationalTextFont);
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("الوصف عربي", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("الوصف أنجليزي", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("النوع", nationalTextFont);
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


                //align the text to the right of the cell
                //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                //cell.Phrase = new iTextSharp.text.Phrase("     ", footer);
                cell.Phrase = new iTextSharp.text.Phrase("طبعت بواسطة " + UserName, footer);
                footerTbl.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("عدد مرات الطباعة " + PageNo, footer);
                footerTbl.AddCell(cell);

                // add some padding to take away from the edge of the page
                //cell.PaddingRight = 5;

                //add the cell to the table

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

    }
}