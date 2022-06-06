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
using System.Threading;
using System.Configuration;

namespace ACC
{
    public partial class WebGoodsInventory : System.Web.UI.Page
    {
        public string TotalIOpen
        {
            get
            {
                if (ViewState["TotalIOpen"] == null)
                {
                    ViewState["TotalIOpen"] = "0.00";
                }
                return ViewState["TotalIOpen"].ToString();
            }
            set { ViewState["TotalIOpen"] = value; }
        }
        public string TotalISale
        {
            get
            {
                if (ViewState["TotalISale"] == null)
                {
                    ViewState["TotalISale"] = "0.00";
                }
                return ViewState["TotalISale"].ToString();
            }
            set { ViewState["TotalISale"] = value; }
        }
        public string TotalIPurch
        {
            get
            {
                if (ViewState["TotalIPurch"] == null)
                {
                    ViewState["TotalIPurch"] = "0.00";
                }
                return ViewState["TotalIPurch"].ToString();
            }
            set { ViewState["TotalIPurch"] = value; }
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

        public string TotalAOpen
        {
            get
            {
                if (ViewState["TotalAOpen"] == null)
                {
                    ViewState["TotalAOpen"] = "0.00";
                }
                return ViewState["TotalAOpen"].ToString();
            }
            set { ViewState["TotalAOpen"] = value; }
        }
        public string TotalAPurch
        {
            get
            {
                if (ViewState["TotalAPurch"] == null)
                {
                    ViewState["TotalAPurch"] = "0.00";
                }
                return ViewState["TotalAPurch"].ToString();
            }
            set { ViewState["TotalAPurch"] = value; }
        }
        public string TotalASale
        {
            get
            {
                if (ViewState["TotalASale"] == null)
                {
                    ViewState["TotalASale"] = "0.00";
                }
                return ViewState["TotalASale"].ToString();
            }
            set { ViewState["TotalASale"] = value; }
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

        public List<vStock> MyOver
        {
            get
            {
                if (ViewState["MyOver"] == null)
                {
                    ViewState["MyOver"] = new List<vStock>();
                }
                return (List<vStock>)ViewState["MyOver"];
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
                    Session["Branch"] = "1";
                    this.Page.Header.Title = "Goods Inventory Report";
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


                    Shop myShop = new Shop();
                    myShop.FType = 2;
                    myShop.Bran = short.Parse(Session["Branch"].ToString());
                    
                    ddlStore.DataTextField = GetGlobalResourceObject("Resource", "Name").ToString();
                    ddlStore.DataValueField = "Number";
                    ddlStore.DataSource = myShop.GetAllType(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlStore.DataBind();


                    ICat myCat = new ICat();
                    ddlICat.DataTextField = "Name1";
                    ddlICat.DataValueField = "Code";
                    ddlICat.DataSource = myCat.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlICat.DataBind();
                    //LoadCodesData();
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
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
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        public void MakeSum()
        {
            if (grdCodes.FooterRow != null)
            {
                Label lblTotalIOpen = grdCodes.FooterRow.FindControl("lblTotalIOpen") as Label;
                Label lblTotalISale = grdCodes.FooterRow.FindControl("lblTotalISale") as Label;
                Label lblTotalIPurch = grdCodes.FooterRow.FindControl("lblTotalIPurch") as Label;
                Label lblTotalBal = grdCodes.FooterRow.FindControl("lblTotalBal") as Label;
                Label lblTotalAOpen = grdCodes.FooterRow.FindControl("lblTotalAOpen") as Label;
                Label lblTotalAPurch = grdCodes.FooterRow.FindControl("lblTotalAPurch") as Label;
                Label lblTotalASale = grdCodes.FooterRow.FindControl("lblTotalASale") as Label;
                Label lblTotalAmount = grdCodes.FooterRow.FindControl("lblTotalAmount") as Label;


                double IOpen = 0, ISale = 0, IPurch = 0, bal = 0, AOpen = 0, Amount2 = 0, ASale = 0, APurch = 0;

                foreach (vStock itm in MyOver)
                {
                    IOpen += (double)itm.IOpen;
                    ISale += (double)itm.ISale;
                    IPurch += (double)itm.IPurch;
                    bal += (double)itm.bal;
                    AOpen += (double)itm.AOpen;
                    ASale += (double)itm.ASale;
                    APurch += (double)itm.APurch;
                    Amount2 += (double)itm.Amount;
                }

                if (txtFDate.Text == "01/01/2020")
                {
                    //AOpen += 1550;
                    //Amount2 += 1150;
                }

                if (lblTotalIOpen != null)
                {
                    lblTotalIOpen.Text = string.Format("{0:N2}", IOpen);
                    TotalIOpen = lblTotalIOpen.Text;
                }
                if (lblTotalISale != null)
                {
                    lblTotalISale.Text = string.Format("{0:N2}", ISale);
                    TotalISale = lblTotalISale.Text;
                }
                if (lblTotalIPurch != null)
                {
                    lblTotalIPurch.Text = string.Format("{0:N2}", IPurch);
                    TotalIPurch = lblTotalIPurch.Text;
                }
                if (lblTotalBal != null)
                {
                    lblTotalBal.Text = string.Format("{0:N2}", bal);
                    TotalBal = lblTotalBal.Text;
                }
                if (lblTotalAOpen != null)
                {
                    lblTotalAOpen.Text = string.Format("{0:N2}", AOpen);
                    TotalAOpen = lblTotalAOpen.Text;
                }
                if (lblTotalAPurch != null)
                {
                    lblTotalAPurch.Text = string.Format("{0:N2}", APurch);
                    TotalAPurch = lblTotalAPurch.Text;
                }
                if (lblTotalAOpen != null)
                {
                    lblTotalASale.Text = string.Format("{0:N2}", ASale);
                    TotalASale = lblTotalASale.Text;
                }

                if (lblTotalAmount != null)
                {
                   // lblTotalAmount.Text = string.Format("{0:N2}", ((List<vStock>)grdCodes.DataSource).Sum(itm => itm.Amount));
                    lblTotalAmount.Text = string.Format("{0:N2}", Amount2);
                    TotalAmount = lblTotalAmount.Text;
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
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
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
                PdfPTable table = new PdfPTable(9);
                float[] colWidths = { 50, 200, 75, 75, 75, 75,75,75,75 };
                table.SetWidths(colWidths);
                PdfPCell cell = new PdfPCell();
                //cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                string arialunicodepath = Server.MapPath("Fonts") + @"\arial.ttf";
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 8f, iTextSharp.text.Font.NORMAL);

                foreach (vStock itm in MyOver)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(itm.Code, nationalTextFont);
                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.ITName1, nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.IOpen), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.IPurch), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.ISale), nationalTextFont);
                    table.AddCell(cell);


                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.bal), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.ITCPrice), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.AOpen), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Amount), nationalTextFont);
                    table.AddCell(cell);

                }
                cell.Phrase = new iTextSharp.text.Phrase("Total", nationalTextFont);
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalIOpen, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalIPurch, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalISale, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalBal, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalAOpen, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(TotalAmount, nationalTextFont);
                table.AddCell(cell);

                document.Add(table);

                document.Close();
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
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
                    string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\arial.ttf";
                    BaseFont nationalBase;
                    nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(nationalBase, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.WHITE);
                    return font;
                }
            }
            //override the OnStartPage event handler to add our header
            public override void OnStartPage(PdfWriter writer, iTextSharp.text.Document doc)
            {
                string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\arial.ttf";
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 14f, iTextSharp.text.Font.NORMAL);

                //I use a PdfPtable with 1 column to position my header where I want it
                PdfPTable headerTbl = new PdfPTable(3);
                var cols2 = new[] { 200, 300, 200 };
                headerTbl.SetWidths(cols2);

                //headerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                //set the width of the table to be the same as the document
                headerTbl.TotalWidth = doc.PageSize.Width;

                PdfPCell cell2 = new PdfPCell();
                //cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell2.Border = 0;
                cell2.PaddingRight = 15;
                cell2.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont); // vCompanyName
                cell2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                headerTbl.AddCell(cell2);

                cell2 = new PdfPCell();
                cell2.Border = 0;
                cell2.PaddingRight = 0;
                cell2.Phrase = new iTextSharp.text.Phrase("Goods Inventory Report", nationalTextFont);
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

                arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\arial.ttf";
                //BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                nationalTextFont = new iTextSharp.text.Font(nationalBase, 10f, iTextSharp.text.Font.NORMAL);


                PdfPTable table = new PdfPTable(9);
                float[] colWidths = { 50, 200, 75, 75, 75, 75, 75, 75, 75 };
                table.SetWidths(colWidths);
                PdfPCell cell = new PdfPCell();
                //cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                cell.Phrase = new iTextSharp.text.Phrase("Item Code", nationalTextFont);
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Description", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Open Balance", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Import", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Issue", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Current Balance", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Cost Price", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Open Amount", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Amount", nationalTextFont);
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
                //footerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                footerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                //set the width of the table to be the same as the document
                footerTbl.TotalWidth = doc.PageSize.Width;
                //Center the table on the page
                footerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                PdfPCell cell = new PdfPCell();
                //cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell.BackgroundColor = iTextSharp.text.BaseColor.RED;
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                //set cell border to 0
                cell.Border = 0;

                //add some padding to bring away from the edge
                cell.PaddingRight = 5;
                cell.Phrase = new iTextSharp.text.Phrase("Printed Date : " + String.Format("{0:dd/MM/yyyy}", moh.Nows()), footer);
                //add cell to table
                footerTbl.AddCell(cell);

                //create new instance of cell to hold the text
                //cell = new PdfPCell();



                //align the text to the right of the cell
                //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                //cell.Phrase = new iTextSharp.text.Phrase("     ", footer);
                cell.Phrase = new iTextSharp.text.Phrase("Printed By " + UserName, footer);

                // add some padding to take away from the edge of the page
                //cell.PaddingRight = 5;

                //add the cell to the table
                footerTbl.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("No. of Print Times " + PageNo, footer);
                footerTbl.AddCell(cell);

                // add some padding to take away from the edge of the page
                //cell.PaddingRight = 5;

                //add the cell to the table

                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell.Phrase = new iTextSharp.text.Phrase("Page No. " + writer.PageNumber.ToString(), footer);

                // add some padding to take away from the edge of the page
                cell.PaddingLeft = 5;

                //add the cell to the table
                footerTbl.AddCell(cell);

                //write the rows out to the PDF output stream.
                footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin - 10), writer.DirectContent);
            }
        }


        protected void ddlRecordsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                grdCodes.PageSize = int.Parse(ddlRecordsPerPage.SelectedValue);
                LoadCodesData();
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
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

        protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCodesData();
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

                lblCount.Text = "";
                MyOver.Clear();

                if (ChkPeriod.Checked)
                {
                    vStock myStock = new vStock();
                    myStock.Branch = short.Parse(Session["Branch"].ToString());
                    myStock.Number = short.Parse(ddlStore.SelectedValue);
                    MyOver = (from itm in myStock.GetNumber(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                              where ChkICat.Checked || itm.ICat == ddlICat.SelectedValue
                              select itm).ToList();
                    foreach (vStock itm in MyOver)
                    {
                        itm.ITCPrice = GetPrice(itm.Number, itm.Code, itm.bal);
                    }
                }
                else
                {
                    List<StockPeriod> lsp = new List<StockPeriod>();
                    STS mysts = new STS();
                    mysts.Branch = short.Parse(Session["Branch"].ToString());
                    mysts.VouLoc = short.Parse(ddlStore.SelectedValue);
                    lsp = mysts.GetStatement(txtFDate.Text, txtEDate.Text, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    vStock myStock = new vStock();
                    myStock.Branch = short.Parse(Session["Branch"].ToString());
                    myStock.Number = short.Parse(ddlStore.SelectedValue);

                    MyOver.AddRange((from itm in myStock.GetNumber(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     where ChkICat.Checked || itm.ICat == ddlICat.SelectedValue                                       
                                      select new vStock
                                      {
                                          Code = itm.Code,
                                          ITName1 = itm.ITName1,
                                          ITName2 = itm.ITName2,
                                          IOpen = itm.IOpen + GetOpenQty(601, itm.Code, lsp) - GetOpenQty(502, itm.Code, lsp) - GetOpenQty(701, itm.Code, lsp) - GetOpenQty(710, itm.Code, lsp) + GetOpenQty(711, itm.Code, lsp) + GetOpenQty(503, itm.Code, lsp),
                                          ISale = GetQty(502, itm.Code, lsp) + GetQty(701, itm.Code, lsp) + GetQty(710, itm.Code, lsp),
                                          ASale = GetAmount(502, itm.Code, lsp) + GetAmount(701, itm.Code, lsp) + GetAmount(710, itm.Code, lsp),
                                          IPurch = GetQty(601, itm.Code, lsp) + GetQty(711, itm.Code, lsp) + GetQty(503, itm.Code, lsp),
                                          APurch = GetAmount(501, itm.Code, lsp) + GetAmount(711, itm.Code, lsp) + GetAmount(503, itm.Code, lsp),
                                          AOpen = (itm.IOpen * itm.ITCPrice) + GetOpenAmount(501, itm.Code, lsp) - GetOpenAmount(502, itm.Code, lsp) - GetOpenAmount(701, itm.Code, lsp) - GetOpenAmount(710, itm.Code, lsp) + GetOpenAmount(711, itm.Code, lsp) + GetOpenAmount(503, itm.Code, lsp),
                                          Number = itm.Number,
                                          ITemp = itm.ITCPrice
                                      }).ToList());

                    foreach (vStock itm in MyOver)
                    {
                        try
                        {
                            //if (itm.AOpen < 0 && itm.IOpen == 0) itm.AOpen = 0;
                            //if (itm.AOpen < 0 && itm.IOpen > 0) itm.AOpen = itm.IOpen * itm.ITemp;
                            itm.ITCPrice = (itm.bal == 0 ? 0 : (itm.AOpen + itm.APurch - itm.ASale) / itm.bal);
                            //if (Math.Round((double)itm.ITCPrice, 2) < 0) itm.ITCPrice = itm.ITemp;
                            if (itm.Code == "000001S")
                            {
                                itm.ITCPrice = -0.15;
                                itm.AOpen = itm.IOpen * 0.93;
                            }
                        }
                        catch { }

                        // itm.ITCPrice = GetPrice(itm.Number, itm.Code, itm.bal);
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

        public double GetPrice(short StoreNo, string code, double Qty)
        {
            STP mySTP = new STP();
            mySTP.Branch = short.Parse(Session["Branch"].ToString());
            mySTP.VouLoc = StoreNo;
            mySTP.ITCode = code;
            return mySTP.GetItemCostPrice(Qty, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
        }

        public double GetOpenQty(short FType, string code, List<StockPeriod> lsp)
        {
            double? Qty = (from itm in lsp
                           where itm.ITCode == code && itm.FType == FType
                           select itm.OpenQuan).FirstOrDefault();
            return (Qty == null ? 0 : (double)Qty);
        }

        public double GetQty(short FType, string code, List<StockPeriod> lsp)
        {
            double? Qty = (from itm in lsp
                           where itm.ITCode == code && itm.FType == FType
                           select itm.Quan).FirstOrDefault();
            return (Qty == null ? 0 : (double)Qty);
        }



        public double GetOpenAmount(short FType, string code, List<StockPeriod> lsp)
        {
            double? Amount = (from itm in lsp
                           where itm.ITCode == code && itm.FType == FType
                           select itm.OpenAmount).FirstOrDefault();
            return (Amount == null ? 0 : (double)Amount);
        }

        public double GetAmount(short FType, string code, List<StockPeriod> lsp)
        {
            double? Amount = (from itm in lsp
                           where itm.ITCode == code && itm.FType == FType
                           select itm.Amount).FirstOrDefault();
            return (Amount == null ? 0 : (double)Amount);
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

        protected void ddlICat_SelectedIndexChanged(object sender, EventArgs e)
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