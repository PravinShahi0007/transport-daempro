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
using System.Configuration;
using System.Threading;
using System.Globalization;
using BLL;

namespace ACC
{
    public partial class WebMontlyAttend : System.Web.UI.Page
    {
        public List<AttLog> MyOver
        {
            get
            {
                if (ViewState["MyOver"] == null)
                {
                    ViewState["MyOver"] = new List<AttLog>();
                }
                return (List<AttLog>)ViewState["MyOver"];
            }
            set { ViewState["MyOver"] = value; }
        }

        public List<Absent> MyOverAbs
        {
            get
            {
                if (ViewState["MyOverAbs"] == null)
                {
                    ViewState["MyOverAbs"] = new List<Absent>();
                }
                return (List<Absent>)ViewState["MyOverAbs"];
            }
            set { ViewState["MyOverAbs"] = value; }
        }

        public string AbsStr
        {
            get
            {
                if (ViewState["AbsStr"] == null)
                {
                    ViewState["AbsStr"] = "";
                }
                return ViewState["AbsStr"].ToString();
            }
            set { ViewState["AbsStr"] = value; }
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
                    AttLog myAttlog = new AttLog();
                    ddlEmp.DataSource = myAttlog.GetEmp(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlEmp.DataBind();
                    ddlEmp.Items.Insert(0, new ListItem("--- إختار رقم الموظف ---", "-1", true));

                    ddlMonth.DataSource = myAttlog.GetMonth(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlMonth.DataBind();
                    ddlMonth.Items.Insert(0, new ListItem("--- إختار الشهر ---", "-1", true));

                    this.Page.Header.Title = "كشف الحضور والانصراف الشهري";
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
                        UserTran.Description = "اختيار عرض كشف الحضور والانصراف الشهري";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    if (Request.QueryString["EmpCode"] != null)
                    {
                        for (int i = 0; i < ddlEmp.Items.Count - 1; i++)
                        {
                            if(ddlEmp.Items[i].Text.StartsWith(Request.QueryString["EmpCode"].ToString())) 
                            {
                                ddlEmp.SelectedIndex = i;
                                break;
                            }
                        }
                        ddlEmp_SelectedIndexChanged(sender, e);
                        ddlMonth.SelectedValue = moh.MakeMask(Request.QueryString["FMonth"].ToString(), 2) + "/" + Request.QueryString["FYear"].ToString();
                        ddlMonth_SelectedIndexChanged(sender, e);
                        BtnProcess_Click(sender, null);
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

        protected void LoadCodesData()
        {
            try
            {
                grdCodes.DataSource = MyOver;
                grdCodes.DataBind();
                lblCount.Text = MyOver.Count().ToString();
            
                grdAbs.DataSource = MyOverAbs;
                grdAbs.DataBind();

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

                page.PageNo = "1";
                page.UserName = Session["FullUser"].ToString();
                pw.PageEvent = page;
                document.Open();
                //PdfPTable table = new PdfPTable(grdCodes.HeaderRow.Cells.Count);
                PdfPTable table = new PdfPTable(5);                
                float[] colWidths = { 250, 100,50, 200, 100 };
                table.SetWidths(colWidths);
                PdfPCell cell = new PdfPCell();
                //cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                
                string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 10f, iTextSharp.text.Font.NORMAL);

                cell.Phrase = new iTextSharp.text.Phrase("الشهر", nationalTextFont);
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);

                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell.Phrase = new iTextSharp.text.Phrase(ddlMonth.SelectedItem.Text, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell);

                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell.Phrase = new iTextSharp.text.Phrase("الموظف", nationalTextFont);
                table.AddCell(cell);

                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell.Phrase = new iTextSharp.text.Phrase(ddlEmp.SelectedItem.Text, nationalTextFont);
                table.AddCell(cell);
                document.Add(table);

                var cols5 = new[] { 300, 60, 80, 80, 60,90,90,200,90,60 };
                table = new PdfPTable(10);
                table.TotalWidth = 100f;
                table.SetWidths(cols5);
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;

                cell.Phrase = new iTextSharp.text.Phrase("اليوم", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("التاريخ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("الوردية", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("وقت الحضور", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("وقت الانصراف", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("الحضور", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("أذن حضور", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("أذن أنصراف", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("التاخير", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("ملاحظات", nationalTextFont);
                table.AddCell(cell);

                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                foreach (AttLog itm in MyOver)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(itm.FDate2.Split(' ')[0], nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.FDate2.Split(' ')[1], nationalTextFont);
                    table.AddCell(cell);

                    Codes ax = new Codes();
                    ax.Branch = short.Parse(Session["Branch"].ToString());
                    ax.Ftype = 20;
                    ax.Code = (int)itm.Shift;
                    if (Cache["LastCodes" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCodes" + Session["CNN2"].ToString(), ax.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ax = (from sitm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                          where sitm.Ftype == 20 && sitm.Code == (int)itm.Shift
                              select sitm).FirstOrDefault();

                    //ax = ax.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    cell.Phrase = new iTextSharp.text.Phrase((ax != null ? ax.Name1 : ""), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.STime, nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.ETime, nationalTextFont);
                    table.AddCell(cell);

                    //cell.Phrase = new iTextSharp.text.Phrase(CountAttend(itm.ETime,itm.STime), nationalTextFont);
                    cell.Phrase = new iTextSharp.text.Phrase(itm.MyAttend, nationalTextFont);
                    table.AddCell(cell);



                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath((bool)itm.SPer ? "images/ZA001117936.Gif" : "images/Blank.gif"));
                    //I used a large version of the logo to maintain the quality when the size was reduced. I guess you could reduce the size manually and use a smaller version, but I used iTextSharp to reduce the scale. As you can see, I reduced it down to 7% of original size.
                    logo.ScalePercent(50);

                    //create instance of a table cell to contain the logo
                    PdfPCell cell20 = new PdfPCell(logo);

                    //align the logo to the right of the cell
                    cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell20.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;

                    //Add the cell to the table
                    table.AddCell(cell20);


                    logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath((bool)itm.EPer ? "images/ZA001117936.Gif" : "images/Blank.gif"));
                    //I used a large version of the logo to maintain the quality when the size was reduced. I guess you could reduce the size manually and use a smaller version, but I used iTextSharp to reduce the scale. As you can see, I reduced it down to 7% of original size.
                    logo.ScalePercent(50);

                    //create instance of a table cell to contain the logo
                    cell20 = new PdfPCell(logo);

                    //align the logo to the right of the cell
                    cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell20.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;

                    //Add the cell to the table
                    table.AddCell(cell20);


                    cell.Phrase = new iTextSharp.text.Phrase(itm.Delay.ToString(), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.Remark + ((itm.SRemark != "" ? (itm.Remark != "" ? "\n" : "") + itm.SRemark : "") + (itm.ERemark != "" ? (itm.Remark != "" ? "\n" : "") + itm.ERemark : "")), nationalTextFont);
                    table.AddCell(cell);
                }
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell.Phrase = new iTextSharp.text.Phrase("الاجمالي", nationalTextFont);
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

                Label lblTotDelay = grdCodes.FooterRow.FindControl("lblTotDelay") as Label;
                Label lblSRemark = grdCodes.FooterRow.FindControl("lblSRemark") as Label;
                Label txttotal2 = grdCodes.FooterRow.FindControl("txttotal2") as Label;

                
                cell.Phrase = new iTextSharp.text.Phrase(txttotal2.Text, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(lblTotDelay.Text, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(lblSRemark.Text, nationalTextFont);
                table.AddCell(cell);

                document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                document.Add(table);
                document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));

                cols5 = new[] { 300, 140,100,60 };
                table = new PdfPTable(4);
                table.TotalWidth = 50f;
                table.SetWidths(cols5);
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;

                cell.Phrase = new iTextSharp.text.Phrase("اليوم", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("أيام الغياب", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("نوع الغياب", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("ملاحظات", nationalTextFont);
                table.AddCell(cell);

                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                foreach (Absent itm in MyOverAbs)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(moh.Days[(int)DateTime.Parse(itm.FDate).DayOfWeek + 1], nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.FDate, nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.FType2.ToString(), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.Remark, nationalTextFont);
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
                cell2.Phrase = new iTextSharp.text.Phrase(vCompanyName + "\n" + "الشئون الإدارية", nationalTextFont);
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                headerTbl.AddCell(cell2);

                cell2.PaddingRight = 0;
                cell2.Phrase = new iTextSharp.text.Phrase("كشف الحضور و الأنصراف الشهري", nationalTextFont);
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
            grdCodes.Columns[4].Visible = false;
            grdCodes.Columns[5].Visible = false;

            LoadCodesData();

            foreach (GridViewRow gvr in grdCodes.Rows)
            {
                Button BtnSwap = gvr.FindControl("BtnSwap") as Button;
                if (BtnSwap != null)
                {
                    BtnSwap.Visible = false;
                }
                Button BtnSwap2 = gvr.FindControl("BtnSwap2") as Button;
                if (BtnSwap2 != null)
                {
                    BtnSwap2.Visible = false;
                }
                DropDownList ddlShift = gvr.FindControl("BtnSwap") as DropDownList;
                if (ddlShift != null)
                {
                    ddlShift.Visible = false;
                }
            }

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
            grdCodes.Columns[4].Visible = true;
            grdCodes.Columns[5].Visible = true;
            grdCodes.AllowPaging = true;
            LoadCodesData();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void BtnProcess_Click(object sender, ImageClickEventArgs e)
        {
            
            if (ddlMonth.SelectedIndex == 0)
            {
                return;
            }
            if (ddlEmp.SelectedIndex == 0)
            {
                return;
            }

            SEmp myEmp = new SEmp();
            myEmp.EmpCode = int.Parse(ddlEmp.SelectedValue.Split(' ')[0]);
            myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

            AttLog mytime = new AttLog();
            mytime.EmpCode = int.Parse(ddlEmp.SelectedValue.Split(' ')[0]);
            mytime.FDate = "01/" + ddlMonth.SelectedValue;
            MyOver = mytime.GetByEmpMonth(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

            MyOverAbs.Clear();

            vAttLogShift myshift = new vAttLogShift();
            myshift.EmpCode = int.Parse(ddlEmp.SelectedValue.Split(' ')[0]);
            foreach (vAttLogShift itm in myshift.Late(int.Parse(ddlMonth.SelectedValue.Split('/')[1]), int.Parse(ddlMonth.SelectedValue.Split('/')[0]), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            {
                lblCount.Text = HDate.Ch_Date(HDate.DatetoHjiri(itm.FDate)).Month.ToString();

                if (HDate.Ch_Date(itm.FDate) >= DateTime.Parse("01/" + ddlMonth.SelectedValue))
                {
                    foreach(AttLog sitm in MyOver)
                    {
                        if (itm.FDate == sitm.FDate)
                        {
                            if(itm.FMonth > 0)
                            {
                                sitm.Delay += itm.FMonth;
                                sitm.YAllowMin += itm.FYear;
                                sitm.MAllowMin += itm.FMonth2;
                            }
                            break;
                        }
                    }
                }
            }

            myshift = new vAttLogShift();
            myshift.EmpCode = int.Parse(ddlEmp.SelectedValue.Split(' ')[0]);
            foreach (vAttLogShift itm in myshift.AllowLate(int.Parse(ddlMonth.SelectedValue.Split('/')[1]), int.Parse(ddlMonth.SelectedValue.Split('/')[0]), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            {
                if (HDate.Ch_Date(itm.FDate) >= DateTime.Parse("01/" + ddlMonth.SelectedValue))
                {
                    foreach (AttLog sitm in MyOver)
                    {
                        if (itm.FDate == sitm.FDate)
                        {
                            if (itm.delay > 0)
                            {
                                sitm.Delay2 += itm.delay;
                                sitm.MAllowMin += itm.FMonth0;
                                sitm.MAllowCount += itm.FMonth2;
                                sitm.YAllowMin += itm.FMonth;
                                sitm.YAllowCount += itm.FYear;
                            }
                            break;
                        }
                    }
                }
            }

            myshift = new vAttLogShift();
            myshift.EmpCode = int.Parse(ddlEmp.SelectedValue.Split(' ')[0]);
            foreach (vAttLogShift itm in myshift.Early(int.Parse(ddlMonth.SelectedValue.Split('/')[1]), int.Parse(ddlMonth.SelectedValue.Split('/')[0]), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            {
                if (HDate.Ch_Date(itm.FDate) >= DateTime.Parse("01/" + ddlMonth.SelectedValue))
                {
                    foreach (AttLog sitm in MyOver)
                    {
                        if (itm.FDate == sitm.FDate)
                        {
                            if (itm.FMonth > 0)
                            {
                                sitm.Early += itm.FMonth;
                                sitm.eYAllowMin += itm.FYear;
                                sitm.eMAllowMin += itm.FMonth2;
                            }
                            break;
                        }
                    }
                }
            }

            myshift = new vAttLogShift();
            myshift.EmpCode = int.Parse(ddlEmp.SelectedValue.Split(' ')[0]);
            foreach (vAttLogShift itm in myshift.AllowEarly(int.Parse(ddlMonth.SelectedValue.Split('/')[1]), int.Parse(ddlMonth.SelectedValue.Split('/')[0]), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            {
                if (HDate.Ch_Date(itm.FDate) >= DateTime.Parse("01/" + ddlMonth.SelectedValue))
                {
                    foreach (AttLog sitm in MyOver)
                    {
                        if (itm.FDate == sitm.FDate)
                        {
                            if (itm.delay > 0)
                            {
                                sitm.Early2 += itm.delay;
                                sitm.eMAllowMin += itm.FMonth0;
                                sitm.eMAllowCount += itm.FMonth2;
                                sitm.eYAllowMin += itm.FMonth;
                                sitm.eYAllowCount += itm.FYear;
                            }
                            break;
                        }
                    }
                }
            }

            AbsStr = "";

            int? YMLate = 0 , MMLate = 0;
            int? YMLCount = 0, MMLCount = 0;

            int? YMEarly = 0, MMEarly = 0;
            int? YMECount = 0, MMECount = 0;

            foreach (AttLog sitm in MyOver)
            {
                bool vEmpty = false;
                if (sitm.Delay > 0)
                {
                    if (sitm.STime == "" || sitm.ETime == "")
                    {
                    }
                    else
                    {
                        if (YMLate == 0 && MMLate == 0)
                        {
                            YMLate += sitm.YAllowMin;
                            MMLate += sitm.MAllowMin + sitm.Delay;
                        }
                        else
                        {
                           YMLate += sitm.Delay;
                           MMLate += sitm.Delay;                        
                        }
                    }

                    sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " تاخير " +YMLate.ToString() + "/" + MMLate.ToString();
                    if (!vEmpty && ((!(bool)sitm.SPer && sitm.STime == "") || (!(bool)sitm.EPer && sitm.ETime == "")) && HDate.Ch_Date(sitm.FDate) < HDate.Ch_Date(moh.Nows().ToShortDateString()))
                    {
                        sitm.Delay += (sitm.Forget * 60);
                        sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " نسيان تسجيل " + (!(bool)sitm.SPer && sitm.STime == "" ? "حضور " : "أنصراف ");
                        vEmpty = true;
                    }
                }


                if (sitm.Delay2 > 0)
                {
                    if (YMLCount == 0 && MMLCount == 0)
                    {
                        YMLCount += sitm.YAllowCount;
                        MMLCount += sitm.MAllowCount;
                    }
                    else
                    {
                        YMLCount++;
                        MMLCount++;
                    }
                    if (YMLate == 0 && MMLate == 0)
                    {
                        YMLate += sitm.YAllowMin;
                        MMLate += sitm.MAllowMin + sitm.Delay2;
                    }
                    else
                    {
                        YMLate += sitm.Delay2;
                        MMLate += sitm.Delay2;
                    }

                    //if (YMLCount > 63 || MMLCount > 7 || YMLate > 480 || MMLate > 90)
                    if (YMLCount > sitm.YDLateNo || MMLCount > sitm.MDLateNo || YMLate > sitm.YDLate || MMLate > sitm.MDLate)
                    {
                        sitm.Delay = sitm.Delay2;
                        sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " تاخير " + YMLate.ToString() + "/" + MMLate.ToString();
                    }
                    else sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " مهلة تاخير " + YMLCount.ToString() + "/" + MMLCount.ToString() + " " + YMLate.ToString() + "/" + MMLate.ToString();

                    if (!vEmpty && ((!(bool)sitm.SPer && sitm.STime == "") || (!(bool)sitm.EPer && sitm.ETime == "")) && HDate.Ch_Date(sitm.FDate) < HDate.Ch_Date(moh.Nows().ToShortDateString()))
                    {
                        sitm.Delay += (sitm.Forget * 60);
                        sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " نسيان تسجيل " + (!(bool)sitm.SPer && sitm.STime == "" ? "حضور " : "أنصراف ");
                        vEmpty = true;
                    }
                }

                if (sitm.Early > 0)
                {
                    if (YMEarly == 0 && MMEarly == 0)
                    {
                        // YMEarly += sitm.eYAllowMin;
                        // MMEarly += sitm.eMAllowMin + sitm.Early;
                    }
                    else
                    {
                        // YMEarly += sitm.Early;
                        // MMEarly += sitm.Early;
                    }
                    sitm.Delay += sitm.Early;
                    sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " أنصراف مبكر "; // +YMEarly.ToString() + "/" + MMEarly.ToString();

                    if (!vEmpty && ((!(bool)sitm.SPer && sitm.STime == "") || (!(bool)sitm.EPer && sitm.ETime == "")) && HDate.Ch_Date(sitm.FDate) < HDate.Ch_Date(moh.Nows().ToShortDateString()))
                    {
                        sitm.Delay += (sitm.Forget * 60);
                        sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " نسيان تسجيل " + (!(bool)sitm.SPer && sitm.STime == "" ? "حضور " : "أنصراف ");
                        vEmpty = true;
                    }
                }
                if (sitm.Early2 > 0)
                {
                    if (YMECount == 0 && MMECount == 0)
                    {
                        YMECount += ++sitm.eYAllowCount;
                        MMECount += ++sitm.eMAllowCount;
                    }
                    else
                    {
                        YMECount++;
                        MMECount++;
                    }
                    if (YMEarly == 0 && MMEarly == 0)
                    {
                        YMEarly += sitm.eYAllowMin;
                        MMEarly += sitm.eMAllowMin + sitm.Early2;
                    }
                    else
                    {
                        YMEarly += sitm.Early2;
                        MMEarly += sitm.Early2;
                    }

                    //if (YMLCount > 63 || MMLCount > 7 || YMLate > 480 || MMLate > 90)
                    if (YMECount > sitm.YDEarlyNo || MMECount > sitm.MDEarlyNo || YMEarly > sitm.YDEarly || MMEarly > sitm.MDEarly)
                    {
                        sitm.Delay += sitm.Early2;
                        sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " أنصراف مبكر "; // +YMEarly.ToString() + "/" + MMEarly.ToString();
                    }
                    else sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " مهلة أنصراف مبكر " + YMECount.ToString() + "/" + MMECount.ToString() + " " + YMEarly.ToString() + "/" + MMEarly.ToString();

                    if (!vEmpty && ((!(bool)sitm.SPer && sitm.STime == "") || (!(bool)sitm.EPer && sitm.ETime == "")) && HDate.Ch_Date(sitm.FDate) < HDate.Ch_Date(moh.Nows().ToShortDateString()))
                    {
                        sitm.Delay += (sitm.Forget * 60);
                        sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " نسيان تسجيل " + (!(bool)sitm.SPer && sitm.STime == "" ? "حضور " : "أنصراف ");
                        vEmpty = true;
                    }

                }

                if (!vEmpty && ((!(bool)sitm.SPer && sitm.STime == "") || (!(bool)sitm.EPer && sitm.ETime == "")) && HDate.Ch_Date(sitm.FDate) < HDate.Ch_Date(moh.Nows().ToShortDateString()))
                {
                    sitm.Delay += (sitm.Forget * 60);
                    sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " نسيان تسجيل " + (!(bool)sitm.SPer && sitm.STime == "" ? "حضور " : "أنصراف ");
                    vEmpty = true;
                }

            }

            if (MyOver.Count() > 0)
            {
                int abs = 0;
                for (int i = 1; i <= DateTime.DaysInMonth(int.Parse(ddlMonth.SelectedValue.Split('/')[1]), int.Parse(ddlMonth.SelectedValue.Split('/')[0])); i++)
                {
                    bool vFound = false;
                    DateTime vDate = HDate.Ch_Date(moh.MakeMask(i.ToString(), 2) + "/" + ddlMonth.SelectedValue);
                    string vDate2 = ddlMonth.SelectedValue.Split('/')[1] + "/" + ddlMonth.SelectedValue.Split('/')[0] + "/" +  moh.MakeMask(i.ToString(), 2);
                    int r = (int)vDate.DayOfWeek;
                    if (r != 5 && !moh.CheckVac(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString,vDate.ToString("dd/MM/yyyy")))
                    {
                        if (r == 6)
                        {
                            if (MyOver[0].SETime != "")
                            {
                                foreach (AttLog sitm in MyOver)
                                {
                                    if (sitm.FDate == vDate2)
                                    {
                                        vFound = true;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            foreach (AttLog sitm in MyOver)
                            {
                                if (sitm.FDate == vDate2)
                                {
                                    vFound = true;
                                    break;
                                }
                            }
                        }
                        if (!vFound)
                        {
                            if (!string.IsNullOrEmpty(myEmp.JoinDate))
                            {
                                if (vDate < HDate.Ch_Date(myEmp.JoinDate)) continue;
                            }

                            if (!string.IsNullOrEmpty(myEmp.ReturnDate) && !string.IsNullOrEmpty(myEmp.VacDate))
                            {
                               // if (vDate > HDate.Ch_Date(myEmp.VacDate) && vDate < HDate.Ch_Date(myEmp.ReturnDate)) continue;
                            }

                            if (!string.IsNullOrEmpty(myEmp.EndDate))
                            {
                                if (vDate >= HDate.Ch_Date(myEmp.EndDate)) continue;
                            }

                            if (moh.Nows() >= vDate)
                            {

                                int vNoofDays = 35;
                                bool vCrThSat = false;
                                foreach (AttLog sitm in MyOver)
                                {
                                    TimeSpan ts = DateTime.Parse(sitm.FDate) - vDate;
                                    if (Math.Abs(ts.Days) < vNoofDays)
                                    {
                                        vNoofDays = Math.Abs(ts.Days);
                                        vCrThSat = (bool)sitm.ThSat;
                                    }
                                }
                                //if((bool)MyOver[0].ThSat)
                                if(vCrThSat)
                                {
                                    DateTime vDateoff = vDate;
                                    string vDateoff2 = "";
                                    bool vFound2 = false;
                                    if (vDate.DayOfWeek == DayOfWeek.Saturday)
                                    {
                                        vDateoff = vDateoff.AddDays(-2);
                                        vDateoff2 = vDateoff.Year.ToString()+"/"+moh.MakeMask(vDateoff.Month.ToString(),2)+"/"+moh.MakeMask(vDateoff.Day.ToString(),2);
                                        AttLog vAtt = new AttLog();
                                        vAtt.EmpCode = myEmp.EmpCode;
                                        vAtt.FDate = vDateoff2;
                                        vAtt = vAtt.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        vFound2 = (vAtt != null);
                                    }
                                    else if (vDate.DayOfWeek == DayOfWeek.Thursday)
                                    {
                                        vDateoff = vDateoff.AddDays(2);
                                        vDateoff2 = vDateoff.Year.ToString() + "/" + moh.MakeMask(vDateoff.Month.ToString(), 2) + "/" + moh.MakeMask(vDateoff.Day.ToString(), 2);
                                        AttLog vAtt = new AttLog();
                                        vAtt.EmpCode = myEmp.EmpCode;
                                        vAtt.FDate = vDateoff2;
                                        vAtt = vAtt.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        vFound2 = (vAtt != null);
                                    }
                                    if (vFound2)
                                    {
                                        continue;
                                    }
                                }

                                vDate2 = vDate.Year.ToString() + "/" + moh.MakeMask(vDate.Month.ToString(), 2) + "/" + moh.MakeMask(vDate.Day.ToString(), 2);
                                vFound = false;
                                foreach (AttLog sitm in MyOver)
                                {
                                    if (sitm.FDate == vDate2)
                                    {
                                        vFound = true;
                                        break;
                                    }
                                }


                                Absent abs0 = new Absent();
                                if (!vFound)
                                {           
                         
                                    // Check WorkFlow
                                    string vWorkFlow = "";
                                    vWorkFlow = CheckWorkFlow(myEmp.EmpCode, vDate.ToString("dd/MM/yyyy"));
                                    if(vWorkFlow != "")
                                    {
                                       abs0 = new Absent();
                                       abs0.EmpCode = myEmp.EmpCode;
                                       abs0.FDate = vDate.ToString("dd/MM/yyyy");
                                       abs0 = abs0.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if (abs0 == null)
                                        {
                                            abs0 = new Absent();
                                            abs0.EmpCode = myEmp.EmpCode;
                                            abs0.FDate = vDate.ToString("dd/MM/yyyy");
                                            abs0.FType = 9;
                                            abs0.Remark = vWorkFlow;
                                            abs0.FNo2 = vWorkFlow.Split(' ')[3];
                                            abs0.Remark2 = "WebVac2.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + vWorkFlow.Split(' ')[3] + "&FMode=0&FLevel=99";
                                            abs0.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                            MyOverAbs.Add(abs0);
                                            abs++;
                                        }
                                        else
                                        {
                                            abs0 = new Absent();
                                            abs0.EmpCode = myEmp.EmpCode;
                                            abs0.FDate = vDate.ToString("dd/MM/yyyy");
                                            abs0.FType = 9;
                                            abs0.Remark = vWorkFlow;
                                            abs0.FNo2 = vWorkFlow.Split(' ')[3];
                                            abs0.Remark2 = "WebVac2.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + vWorkFlow.Split(' ')[3] + "&FMode=0&FLevel=99";
                                            abs0.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                            vFound = false;
                                            foreach (Absent itm in MyOverAbs)
                                            {
                                                if (itm.FDate == vDate.ToString("dd/MM/yyyy"))
                                                {
                                                    vFound = true;
                                                    itm.FType = abs0.FType;
                                                    itm.Remark = abs0.Remark;
                                                    itm.FNo2 = vWorkFlow.Split(' ')[3];
                                                    itm.Remark2 = "WebVac2.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + vWorkFlow.Split(' ')[3] + "&FMode=0&FLevel=99";
                                                    break;
                                                }
                                            }
                                            if (!vFound)
                                            {
                                                MyOverAbs.Add(abs0);
                                                abs++;
                                            }
                                        }
                                        vFound = true;
                                }




                                    if (!vFound)
                                    {
                                        abs0 = new Absent();
                                        abs0.EmpCode = myEmp.EmpCode;
                                        abs0.FDate = vDate.ToString("dd/MM/yyyy");

                                        abs0 = abs0.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if (abs0 == null)
                                        {
                                            abs0 = new Absent();
                                            abs0.EmpCode = myEmp.EmpCode;
                                            abs0.FDate = vDate.ToString("dd/MM/yyyy");
                                            abs0.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        }
                                        vFound = false;
                                        foreach (Absent itm in MyOverAbs)
                                        {
                                            if (itm.FDate == vDate.ToString("dd/MM/yyyy"))
                                            {
                                                vFound = true;
                                                break;
                                            }
                                        }
                                        if (!vFound)
                                        {
                                            MyOverAbs.Add(abs0);
                                            abs++;
                                        }
                                    }
                                }

                                if (vDate.DayOfWeek == DayOfWeek.Thursday)
                                {
                                    vDate2 = vDate.AddDays(1).Year.ToString() + "/" + moh.MakeMask(vDate.AddDays(1).Month.ToString(), 2) + "/" + moh.MakeMask(vDate.AddDays(1).Day.ToString(), 2);
                                    vFound = false;
                                    foreach (AttLog sitm in MyOver)
                                    {
                                        if (sitm.FDate == vDate2)
                                        {
                                            vFound = true;
                                            break;
                                        }
                                    }
                                    if (!vFound)
                                    {
                                        // Check WorkFlow
                                        string vWorkFlow = "";
                                        vWorkFlow = CheckWorkFlow(myEmp.EmpCode, vDate.AddDays(1).ToString("dd/MM/yyyy"));
                                        if (vWorkFlow != "")
                                        {
                                            abs0 = new Absent();
                                            abs0.EmpCode = myEmp.EmpCode;
                                            abs0.FDate = vDate.AddDays(1).ToString("dd/MM/yyyy");
                                            abs0.Remark = vWorkFlow;
                                            abs0 = abs0.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                            if (abs0 == null)
                                            {
                                                abs0 = new Absent();
                                                abs0.EmpCode = myEmp.EmpCode;
                                                abs0.FDate = vDate.AddDays(1).ToString("dd/MM/yyyy");
                                                abs0.FType = 9;
                                                abs0.Remark = vWorkFlow;
                                                abs0.FNo2 = vWorkFlow.Split(' ')[3];
                                                abs0.Remark2 = "WebVac2.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + vWorkFlow.Split(' ')[3] + "&FMode=0&FLevel=99";
                                                abs0.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                                MyOverAbs.Add(abs0);
                                                abs++;
                                            }
                                            else
                                            {
                                                abs0 = new Absent();
                                                abs0.EmpCode = myEmp.EmpCode;
                                                abs0.FDate = vDate.AddDays(1).ToString("dd/MM/yyyy");
                                                abs0.FType = 9;
                                                abs0.Remark = vWorkFlow;
                                                abs0.FNo2 = vWorkFlow.Split(' ')[3];
                                                abs0.Remark2 = "WebVac2.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + vWorkFlow.Split(' ')[3] + "&FMode=0&FLevel=99";
                                                abs0.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                                vFound = false;
                                                foreach (Absent itm in MyOverAbs)
                                                {
                                                    if (itm.FDate == abs0.FDate)
                                                    {
                                                        vFound = true;
                                                        itm.FType = abs0.FType;
                                                        itm.Remark = abs0.Remark;
                                                        itm.FNo2 = vWorkFlow.Split(' ')[3];
                                                        itm.Remark2 = "WebVac2.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + vWorkFlow.Split(' ')[3] + "&FMode=0&FLevel=99";
                                                        break;
                                                    }
                                                }
                                                if (!vFound)
                                                {
                                                    MyOverAbs.Add(abs0);
                                                    abs++;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            abs0 = new Absent();
                                            abs0.EmpCode = myEmp.EmpCode;
                                            abs0.FDate = vDate.AddDays(1).ToString("dd/MM/yyyy");
                                            abs0.FType = 9;

                                            abs0 = abs0.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                            if (abs0 == null)
                                            {
                                                abs0 = new Absent();
                                                abs0.EmpCode = myEmp.EmpCode;
                                                abs0.FDate = vDate.AddDays(1).ToString("dd/MM/yyyy");
                                                abs0.FType = 9;
                                                abs0.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                            }

                                            vFound = false;
                                            foreach (Absent itm in MyOverAbs)
                                            {
                                                if (itm.FDate == vDate.AddDays(1).ToString("dd/MM/yyyy"))
                                                {
                                                    vFound = true;
                                                    break;
                                                }
                                            }
                                            if (!vFound)
                                            {
                                                MyOverAbs.Add(abs0);
                                                abs++;
                                            }
                                        }

                                    }

                                    vDate2 = vDate.AddDays(2).Year.ToString() + "/" + moh.MakeMask(vDate.AddDays(2).Month.ToString(),2) + "/" + moh.MakeMask(vDate.AddDays(2).Day.ToString(),2);
                                    vFound = false;
                                    foreach (AttLog sitm in MyOver)
                                    {
                                        if (sitm.FDate == vDate2)
                                        {
                                            vFound = true;
                                            break;
                                        }
                                    }

                                    if(!vFound)
                                    {
                                        abs0 = new Absent();
                                        abs0.EmpCode = myEmp.EmpCode;
                                        abs0.FDate = vDate.AddDays(2).ToString("dd/MM/yyyy");
                                        abs0.FType = 9;

                                        abs0 = abs0.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if (abs0 == null)
                                        {
                                            abs0 = new Absent();
                                            abs0.EmpCode = myEmp.EmpCode;
                                            abs0.FDate = vDate.AddDays(2).ToString("dd/MM/yyyy");
                                            abs0.FType = 9;
                                            abs0.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        }
                                        vFound = false;
                                        foreach (Absent itm in MyOverAbs)
                                        {
                                            if (itm.FDate == vDate.AddDays(2).ToString("dd/MM/yyyy"))
                                            {
                                                vFound = true;
                                                break;
                                            }
                                        }
                                        if (!vFound)
                                        {
                                            MyOverAbs.Add(abs0);
                                            abs++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Absent vabs = new Absent();
                vabs.EmpCode = myEmp.EmpCode;
                vabs.FDate = MyOver[0].FDate;
                foreach (Absent absitm in vabs.GetByMonthEmp(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    bool vFound0 = false;
                    foreach (Absent kitm in MyOverAbs)
                    {
                        if (kitm.FDate == absitm.FDate)
                        {
                            vFound0 = true;
                            break;
                        }
                    }
                    if (!vFound0)
                    {
                        absitm.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                }



                if (abs > 0)
                {
                    AbsStr = " الغياب = " + abs.ToString() + " يوم ";
                }
            }


            LoadCodesData();
            MakeSum();
            MakeSumAttend();
        }

        public string CheckWorkFlow(int EmpCode,string vDate)
        {
            string Result = "";
            eServices myService = new eServices();
            myService.EmpCode = EmpCode;
            myService.DocType = 201;
            myService = (from itm in myService.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                            where itm.Status == 99 && DateTime.Parse(itm.SDate) <= DateTime.Parse(vDate) && DateTime.Parse(itm.EDate) >= DateTime.Parse(vDate)
                            select itm).FirstOrDefault();

            if (myService != null) Result = "طلب اجازة رقم " + myService.DocNo.ToString() +" "+ (from qitm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                                                                             where qitm.Ftype == 10 && qitm.Code == int.Parse(myService.FType.ToString())
                                                                                                           select qitm.Name1).FirstOrDefault(); 
            return Result;
        }


        public String CountDelay(String e, String s)
        {
            String delay = "00:00";

            if ((e != null & e != "" & e != " ") & (s != null & s != "" & s != " "))
            {
                string[] sTemp = s.Split(':');
                string[] eTemp = e.Split(':');                

                // (year, month, day, hour, minute, second)
                DateTime sTime = new DateTime(1, 1, 1, int.Parse(sTemp[0]), int.Parse(sTemp[1]), int.Parse(sTemp[2]));
                DateTime eTime = new DateTime(1, 1, 1, int.Parse(eTemp[0]), int.Parse(eTemp[1]), int.Parse(eTemp[2]));

                TimeSpan workedTime = eTime.Subtract(sTime);
                TimeSpan fullTime = new TimeSpan(8, 0, 0);
                TimeSpan delayTime = fullTime.Subtract(workedTime);

                string h = "00";
                string m = "00";

                if (delayTime.Hours > 0)
                    h = (delayTime.Hours > 9) ? ("" + delayTime.Hours) : ("0" + delayTime.Hours);
                if (delayTime.Minutes > 0)
                    m = (delayTime.Minutes > 9) ? ("" + delayTime.Minutes) : ("0" + delayTime.Minutes);

                delay = h + ":" + m;  
            }


            return delay;
        }


        public String CountAttend(String e, String s)
        {
            String attend = "00:00";

            if ((e != null & e != "" & e != " ") & (s != null & s != "" & s != " "))
            {
                string[] sTemp = s.Split(':');
                string[] eTemp = e.Split(':');

                // (year, month, day, hour, minute, second)
                DateTime sTime = new DateTime(1, 1, 1, int.Parse(sTemp[0]), int.Parse(sTemp[1]), int.Parse(sTemp[2]));
                DateTime eTime = new DateTime(1, 1, 1, int.Parse(eTemp[0]), int.Parse(eTemp[1]), int.Parse(eTemp[2]));
                TimeSpan workedTime = eTime.Subtract(sTime);

                if (eTime < sTime && eTime < DateTime.Parse("03:30"))
                {
                    workedTime = DateTime.Parse("23:59:59").Subtract(sTime);
                    workedTime += eTime.Subtract(DateTime.Parse("00:00:01"));

                }

                    string h = "00";
                    string m = "00";

                    if (workedTime.Hours > 0)
                        h = (workedTime.Hours > 9) ? ("" + workedTime.Hours) : ("0" + workedTime.Hours);
                    if (workedTime.Minutes > 0)
                        m = (workedTime.Minutes > 9) ? ("" + workedTime.Minutes) : ("0" + workedTime.Minutes);

                    attend = h + ":" + m;
            }


            return attend;
        }



        public String CountIn(String s)
        {
            String In2 = "00:00";

            if (s != null & s != "" & s != " ")
            {
                string[] sTemp = s.Split(':');
              

                // (year, month, day, hour, minute, second)
                TimeSpan sTime = new TimeSpan(int.Parse(sTemp[0]), int.Parse(sTemp[1]), int.Parse(sTemp[2]));
             
               
                TimeSpan startTime = new TimeSpan(9, 0, 0);
                TimeSpan delayTime = sTime.Subtract(startTime);

                string h = "00";
                string m = "00";

                if (delayTime.Hours > 0)
                    h = (delayTime.Hours > 9) ? ("" + delayTime.Hours) : ("0" + delayTime.Hours);
                if (delayTime.Minutes > 0)
                    m = (delayTime.Minutes > 9) ? ("" + delayTime.Minutes) : ("0" + delayTime.Minutes);

                In2 = h + ":" + m;
            }


            return In2;
        }


        public String CountOut(String e)
        {
            String Out2 = "00:00";

            if (e != null & e != "" & e != " ")
            {
                string[] eTemp = e.Split(':');


                // (year, month, day, hour, minute, second)
                TimeSpan eTime = new TimeSpan(int.Parse(eTemp[0]), int.Parse(eTemp[1]), int.Parse(eTemp[2]));


                TimeSpan endTime = new TimeSpan(17, 0, 0);
                TimeSpan delayTime = endTime.Subtract(eTime);

                string h = "00";
                string m = "00";

                if (delayTime.Hours > 0)
                    h = (delayTime.Hours > 9) ? ("" + delayTime.Hours) : ("0" + delayTime.Hours);
                if (delayTime.Minutes > 0)
                    m = (delayTime.Minutes > 9) ? ("" + delayTime.Minutes) : ("0" + delayTime.Minutes);

                Out2 = h + ":" + m;
            }


            return Out2;
        }

        public void MakeSum()
        {
            try
            {
                Label lblTotDelay = grdCodes.FooterRow.FindControl("lblTotDelay") as Label;
                Label lblSRemark = grdCodes.FooterRow.FindControl("lblSRemark") as Label;
                lblTotDelay.Text = MyOver.Sum(p => p.Delay).ToString();

                    if (moh.StrToDouble(lblTotDelay.Text) > 0 || AbsStr != "")
                    {
                        SEmp myEmp = new SEmp();
                        myEmp.EmpCode = int.Parse(ddlEmp.SelectedValue.Split(' ')[0]);
                        myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myEmp != null)
                        {
                            lblSRemark.Text = string.Format("التاخير = {0:N2} ريال", (moh.StrToDouble(lblTotDelay.Text) * myEmp.Basic / 14400)) + AbsStr;
                        }
                    }
            }
            catch (Exception)
            {
            }
        }

        public void MakeSumAttend()
        {
            try
            {
                Label txttotal2 = grdCodes.FooterRow.FindControl("txttotal2") as Label;

                int vHour = 0, vMinute = 0;
                foreach (AttLog itm in MyOver)
                {
                    if (itm.STime != "" && itm.ETime != "")
                    {
                        if (DateTime.Parse(itm.ETime) < DateTime.Parse(itm.STime) && DateTime.Parse(itm.ETime) < DateTime.Parse("03:30"))
                        {
                            vHour += (DateTime.Parse("23:59:59") - DateTime.Parse(itm.STime)).Hours;
                            vMinute += (DateTime.Parse("23:59:59") - DateTime.Parse(itm.STime)).Minutes;

                            vHour += (DateTime.Parse(itm.ETime) - DateTime.Parse("00:00:01")).Hours;
                            vMinute += (DateTime.Parse(itm.ETime) - DateTime.Parse("00:00:01")).Minutes;
                       
                        }
                        else
                        {
                            vHour += (DateTime.Parse(itm.ETime) - DateTime.Parse(itm.STime)).Hours;
                            vMinute += (DateTime.Parse(itm.ETime) - DateTime.Parse(itm.STime)).Minutes;
                        }
                    }
                }
                vHour += vMinute / 60;
                vMinute = vMinute - ((vMinute / 60) * 60);
                txttotal2.Text = vHour.ToString() + ":" + vMinute.ToString();
            }
            catch (Exception)
            {

            }
        }


        public void MakeSumIn()
        {
            try
            {
                TextBox txttotal3 = grdCodes.FooterRow.FindControl("txttotal3") as TextBox;


                TimeSpan totalTime = TimeSpan.FromSeconds(1);
                foreach (GridViewRow gvr in grdCodes.Rows)
                {
                    Label LblCountIn = gvr.FindControl("LblCountIn") as Label;
                    if (LblCountIn != null)
                    {
                        if (LblCountIn.Text == "") LblCountIn.Text = "00:00";
                        string tmp = LblCountIn.Text + ":00";
                        string[] sTemp = tmp.Split(':');
                        TimeSpan sTime = new TimeSpan(int.Parse(sTemp[0]), int.Parse(sTemp[1]), int.Parse(sTemp[2]));
                        totalTime = totalTime.Add(sTime);

                    }
                }

                int tot;
                tot = (int)totalTime.TotalHours;

                txttotal3.Text = tot.ToString() + ":" + totalTime.Minutes;
                
            }
            catch (Exception)
            {
            }
        }


        public void MakeSumOut()
        {
            try
            {
                TextBox txttotal4 = grdCodes.FooterRow.FindControl("txttotal4") as TextBox;


                TimeSpan totalTime = TimeSpan.FromSeconds(1);
                foreach (GridViewRow gvr in grdCodes.Rows)
                {
                    Label LblCountOut = gvr.FindControl("LblCountOut") as Label;
                    if (LblCountOut != null)
                    {
                        if (LblCountOut.Text == "") LblCountOut.Text = "00:00";
                        string tmp = LblCountOut.Text + ":00";
                        string[] sTemp = tmp.Split(':');
                        TimeSpan sTime = new TimeSpan(int.Parse(sTemp[0]), int.Parse(sTemp[1]), int.Parse(sTemp[2]));
                        totalTime = totalTime.Add(sTime);

                    }
                }

                int tot;
                tot = (int)totalTime.TotalHours;


                txttotal4.Text = tot.ToString() + ":" + totalTime.Minutes;
            }
            catch (Exception)
            {
            }
        }

        protected void ddlEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
                grdCodes.DataSource = null;
                grdCodes.DataBind();

                grdAbs.DataSource = null;
                grdAbs.DataBind();
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
                grdCodes.DataSource = null;
                grdCodes.DataBind();

                grdAbs.DataSource = null;
                grdAbs.DataBind();
        }

        protected void ChkSPer_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ChkSPer = sender as CheckBox;
            GridViewRow gvr = ChkSPer.NamingContainer as GridViewRow;
            MyOver[gvr.RowIndex].SPer = ChkSPer.Checked;
            MyOver[gvr.RowIndex].Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            BtnProcess_Click(sender, null);
        }

        protected void ChkEPer_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ChkEPer = sender as CheckBox;
            GridViewRow gvr = ChkEPer.NamingContainer as GridViewRow;
            MyOver[gvr.RowIndex].EPer = ChkEPer.Checked;
            MyOver[gvr.RowIndex].Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            BtnProcess_Click(sender, null);
        }

        protected void ddlFType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlFType = sender as DropDownList;
            GridViewRow gvr = ddlFType.NamingContainer as GridViewRow;
            MyOverAbs[gvr.RowIndex].FType = short.Parse(ddlFType.SelectedValue);
            MyOverAbs[gvr.RowIndex].update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
        }

        protected void BtnSwap_Click(object sender, EventArgs e)
        {
            Button BtnSwap = sender as Button;
            GridViewRow gvr = BtnSwap.NamingContainer as GridViewRow;
            MyOver[gvr.RowIndex].ETime = MyOver[gvr.RowIndex].STime;
            MyOver[gvr.RowIndex].STime = "";
            MyOver[gvr.RowIndex].Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            BtnProcess_Click(sender, null);
        }

        protected void BtnSwap2_Click(object sender, EventArgs e)
        {
            Button BtnSwap2 = sender as Button;
            GridViewRow gvr = BtnSwap2.NamingContainer as GridViewRow;
            MyOver[gvr.RowIndex].STime = MyOver[gvr.RowIndex].ETime;
            MyOver[gvr.RowIndex].ETime = "";
            MyOver[gvr.RowIndex].Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            BtnProcess_Click(sender, null);
        }

        protected void ddlShift_Init(object sender, EventArgs e)
        {
            DropDownList ddlShift = sender as DropDownList;
            Codes ax = new Codes();
            ax.Branch = short.Parse(Session["Branch"].ToString());
            ax.Ftype = 20;
            if (Cache["LastCodes" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCodes" + Session["CNN2"].ToString(), ax.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            ddlShift.Items.Clear();
            foreach (Codes itm in (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                   where itm.Ftype == 20
                                   select itm).ToList())
            {
                ddlShift.Items.Add(new ListItem(itm.Name1, itm.Code.ToString()));
            }
        }

        protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlShift = sender as DropDownList;
            GridViewRow gvr = ddlShift.NamingContainer as GridViewRow;
            MyOver[gvr.RowIndex].Shift = int.Parse(ddlShift.SelectedValue);
            MyOver[gvr.RowIndex].Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            BtnProcess_Click(sender, null);
        }

        protected void txtSRemark_TextChanged(object sender, EventArgs e)
        {
            TextBox txtSRemark = sender as TextBox;
            GridViewRow gvr = txtSRemark.NamingContainer as GridViewRow;
            MyOver[gvr.RowIndex].SRemark = txtSRemark.Text;
            MyOver[gvr.RowIndex].Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
        }

        protected void txtERemark_TextChanged(object sender, EventArgs e)
        {
            TextBox txtERemark = sender as TextBox;
            GridViewRow gvr = txtERemark.NamingContainer as GridViewRow;
            MyOver[gvr.RowIndex].ERemark = txtERemark.Text;
            MyOver[gvr.RowIndex].Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
        }

        protected void txtRemark_TextChanged(object sender, EventArgs e)
        {
            TextBox txtRemark = sender as TextBox;
            GridViewRow gvr = txtRemark.NamingContainer as GridViewRow;
            MyOverAbs[gvr.RowIndex].Remark = txtRemark.Text;
            MyOverAbs[gvr.RowIndex].update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
        }

        protected void txtInTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtInTime = sender as TextBox;
                if(txtInTime.Text != "" && moh.CheckTime(txtInTime.Text))
                {
                    GridViewRow gvr = txtInTime.NamingContainer as GridViewRow;
                    MyOver[gvr.RowIndex].STime = txtInTime.Text;
                    MyOver[gvr.RowIndex].Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    BtnProcess_Click(sender, null);
                }
            }
            catch (Exception)
            {
            }
        }

        protected void txtOutTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtOutTime = sender as TextBox;
                if (txtOutTime.Text != "" && moh.CheckTime(txtOutTime.Text))
                {
                    GridViewRow gvr = txtOutTime.NamingContainer as GridViewRow;
                    MyOver[gvr.RowIndex].ETime = txtOutTime.Text;
                    MyOver[gvr.RowIndex].Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    BtnProcess_Click(sender, null);
                }
            }
            catch (Exception)
            {
            }
        }

        protected void grdCodes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdCodes.EditIndex = -1;
                LoadCodesData();
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


        protected void grdCodes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                //LoadCodesData();
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


        protected void grdCodes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                /*
                string sno = grdCodes.DataKeys[e.RowIndex]["sno"].ToString();
                GridViewRow gvr = grdCodes.Rows[e.RowIndex];

                if (sno == null || gvr == null)
                {
                    e.Cancel = true;
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "لقد حدث خطأ أثناء تعديل البيانات ... حاول مرة أخرى";
                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    return;
                }

                TextBox txtDebit = gvr.FindControl("txtDebit2") as TextBox;
                TextBox txtCredit = gvr.FindControl("txtCredit2") as TextBox;
                TextBox txtCode = gvr.FindControl("txtCode2") as TextBox;
                TextBox txtName = gvr.FindControl("txtName2") as TextBox;
                TextBox txtRemark = gvr.FindControl("txtRemark2") as TextBox;
                TextBox txtInvNo = gvr.FindControl("txtInvNo2") as TextBox;
                DropDownList ddlArea = gvr.FindControl("ddlArea") as DropDownList;
                DropDownList ddlCostCenter = gvr.FindControl("ddlCostCenter") as DropDownList;
                DropDownList ddlProject = gvr.FindControl("ddlProject") as DropDownList;
                DropDownList ddlCostAcc = gvr.FindControl("ddlCostAcc") as DropDownList;
                DropDownList ddlEmp = gvr.FindControl("ddlEmp") as DropDownList;
                TextBox txtCarNo = gvr.FindControl("txtCarNo") as TextBox;

                if (txtDebit == null || txtCredit == null || txtCode == null || txtName == null || txtRemark == null || txtInvNo == null || ddlArea == null || ddlCostCenter == null || ddlCostAcc == null || ddlProject == null || ddlEmp == null || txtCarNo == null)
                {
                    e.Cancel = true;
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "لقد حدث خطأ أثناء تعديل البيانات ... حاول مرة أخرى";
                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    return;
                }

                if (txtDebit.Text == "") txtDebit.Text = "0.00";
                if (txtCredit.Text == "") txtCredit.Text = "0.00";

                if (moh.StrToDouble(txtDebit.Text) > 0 && moh.StrToDouble(txtCredit.Text) > 0)
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب ان يكون الحساب أما مدين أو دائن";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    return;
                }

                if (moh.StrToDouble(txtDebit.Text) == 0 && moh.StrToDouble(txtCredit.Text) == 0)
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال مبلغ مدين أو دائن";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    return;
                }

                Acc myAcc = new Acc();
                myAcc.Branch = short.Parse(Session["Branch"].ToString());
                myAcc.Code = txtCode.Text;
                if (!myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "رقم الحساب غير معرف من قبل";
                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    return;
                }
                else
                {
                    // Check to force Entering of Area
                    if ((bool)myAcc.CheckArea && ddlArea.SelectedValue == "-1")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الحساب مرتبط بمنطقة ... يجب أختيار المنطقة";
                        //if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    // Check to force Entering of Cost Center
                    if ((bool)myAcc.CheckCostCenter && ddlCostCenter.SelectedValue == "-1")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الحساب مرتبط بفرع ... يجب أختيار الفرع";
                        //if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    // Check to force Entering of Project
                    if ((bool)myAcc.CheckProject && ddlProject.SelectedValue == "-1")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الحساب مرتبط بمشروع ... يجب أختيار المشروع";
                        //if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    // Check to force Entering of Cost Acc
                    if ((bool)myAcc.CheckCostAcc && ddlCostAcc.SelectedValue == "-1")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الحساب مرتبط بحسابات التكاليف ... يجب أختيار حساب التكاليف";
                        //if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    // Check to force Entering of Emp
                    if ((bool)myAcc.CheckEmp && ddlEmp.SelectedValue == "-1")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الحساب مرتبط بالموظفين ... يجب أختيار الموظف";
                        //if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    // Check to force Entering of Emp
                    if ((bool)myAcc.CheckCarNo && txtCarNo.Text.Trim() == "")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "الحساب مرتبط بشاحنة ... يجب أختيار الشاحنة";
                        //if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }


                }

                VouData[int.Parse(sno) - 1].Debit = moh.StrToDouble(txtDebit.Text);
                VouData[int.Parse(sno) - 1].Credit = moh.StrToDouble(txtCredit.Text);
                VouData[int.Parse(sno) - 1].Code = txtCode.Text;
                VouData[int.Parse(sno) - 1].Name = txtName.Text;
                if (ddlProject.SelectedIndex > 0)
                {
                    VouData[int.Parse(sno) - 1].Project = ddlProject.SelectedItem.Text;
                    VouData[int.Parse(sno) - 1].ProjectCode = ddlProject.SelectedValue;
                }
                else
                {
                    VouData[int.Parse(sno) - 1].Project = "";
                    VouData[int.Parse(sno) - 1].ProjectCode = "-1";
                }
                if (ddlCostCenter.SelectedIndex > 0)
                {
                    VouData[int.Parse(sno) - 1].CostCenter = ddlCostCenter.SelectedItem.Text;
                    VouData[int.Parse(sno) - 1].CostCenterCode = ddlCostCenter.SelectedValue;
                }
                else
                {
                    VouData[int.Parse(sno) - 1].CostCenter = "";
                    VouData[int.Parse(sno) - 1].CostCenterCode = "-1";
                }
                if (ddlArea.SelectedIndex > 0)
                {
                    VouData[int.Parse(sno) - 1].Area = ddlArea.SelectedItem.Text;
                    VouData[int.Parse(sno) - 1].AreaCode = ddlArea.SelectedValue;
                }
                else
                {
                    VouData[int.Parse(sno) - 1].Area = "";
                    VouData[int.Parse(sno) - 1].AreaCode = "-1";
                }
                if (ddlCostAcc.SelectedIndex > 0)
                {
                    VouData[int.Parse(sno) - 1].CostAcc = ddlCostAcc.SelectedItem.Text;
                    VouData[int.Parse(sno) - 1].CostAccCode = ddlCostAcc.SelectedValue;
                }
                else
                {
                    VouData[int.Parse(sno) - 1].CostAcc = "";
                    VouData[int.Parse(sno) - 1].CostAccCode = "-1";
                }
                if (ddlEmp.SelectedIndex > 0)
                {
                    VouData[int.Parse(sno) - 1].Emp = ddlEmp.SelectedItem.Text;
                    VouData[int.Parse(sno) - 1].EmpCode = ddlEmp.SelectedValue;
                }
                else
                {
                    VouData[int.Parse(sno) - 1].Emp = "";
                    VouData[int.Parse(sno) - 1].EmpCode = "-1";
                }
                if (txtCarNo.Text != "")
                {
                    Cars myCar = new Cars();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                    myCar.Code = txtCarNo.Text;
                    myCar = myCar.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myCar != null)
                    {
                        VouData[int.Parse(sno) - 1].CarNo2 = myCar.CodeName;
                        VouData[int.Parse(sno) - 1].CarNo = myCar.Code;
                    }
                }
                else
                {
                    VouData[int.Parse(sno) - 1].CarNo2 = "";
                    VouData[int.Parse(sno) - 1].CarNo = "-1";
                }
                VouData[int.Parse(sno) - 1].Remark = txtRemark.Text;
                VouData[int.Parse(sno) - 1].InvNo = txtInvNo.Text;
                SavemyCookie();

                grdCodes.EditIndex = -1;
                MakeSum();
                LoadVouData();

                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                LblCodesResult.Text = "لقد تم تعديل البند بنجاح";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, false), true);
                 */
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

 
    }
}