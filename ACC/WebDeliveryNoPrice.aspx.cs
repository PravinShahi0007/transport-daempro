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
    public partial class WebDeliveryNoPrice : System.Web.UI.Page
    {
        public List<STP> MyOver
        {
            get
            {
                if (ViewState["MyOver"] == null)
                {
                    ViewState["MyOver"] = new List<STP>();
                }
                return (List<STP>)ViewState["MyOver"];
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
                    this.Page.Header.Title = "بيان سندات استلام غير مرتبطة بفواتير شراء";

                    Transactions UserTran = new Transactions();
                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                    UserTran.UserName = Session["CurrentUser"].ToString();
                    UserTran.FormName = "الرئيسية";
                    UserTran.FormAction = "اختيار";
                    UserTran.Description = "اختيار عرض بيان سندات استلام غير مرتبطة بفواتير شراء";
                    UserTran.IP = IPNetworking.GetIP4Address();
                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                    BtnProcess_Click(sender, null);
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
                /*
                iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), -50, -50, 80, 50);
                HttpContext.Current.Response.ContentType = "application/pdf";
                PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
                pdfPage page = new pdfPage();
                MyConfig mySetting = new MyConfig();
                mySetting.Branch = short.Parse(Session["Branch"].ToString());
                mySetting = mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
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
                myCost = myCost.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                page.vStr4 = myCost != null ? myCost.Name1 : "";
                //-------------------------------------------------------------------------------------------                    
                document.Open();
                //-------------------------------------------------------------------------------------------                    

                //string arialunicodepath = Server.MapPath("Fonts") + @"\arial.ttf";
                string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 11f, iTextSharp.text.Font.NORMAL);
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
                cell2.Phrase = new iTextSharp.text.Phrase(" مراقبة تحصيل الفواتير ", nationalTextFont16);
                table.AddCell(cell2);

                document.Add(table);
                //-------------------------------------------------------------------------------------------
                document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                //-------------------------------------------------------------------------------------------
                cols = new[] { 200, 120, 100, 120, 120, 100, 100, 50 };
                table = new PdfPTable(8);
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
                cell.Phrase = new iTextSharp.text.Phrase("م", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("اتفاقية شحن", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("التاريخ", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("فروع", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("عملاء", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("قيمة التسوية", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("الفرق", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("سندات التسوية", nationalTextFont2);
                table.AddCell(cell);

                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;

                if (MyOver != null && MyOver.Count > 0)
                {
                    foreach (vInvError inv in MyOver)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(inv.FNo.ToString(), nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.InvNo2, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.GDate, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.SiteAmount), nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.CustomerAmount), nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.VouNo2, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.JvAmount), nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N0}", inv.Diff), nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase("    ", nationalTextFont);
                        table.AddCell(cell);
                    }
                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الاجمالي", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(TotalSiteAmount, nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(TotalCustomerAmount, nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);


                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);
                }
                document.Add(table);
                //-------------------------------------------------------------
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
                document.Close();
                 */
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
                lblCount.Text = "";
                MyOver.Clear();

                STP myInv = new STP();
                MyOver = myInv.FindNoPrice(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
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
                    case 1: return "~/WebDeliveryNote.aspx?AreaNo=" + Request.QueryString["AreaNo"].ToString() + "&FNum=" + vs[1] + "&StoreNo=" + moh.MakeMask(vs[0], 5);
                    default: return "";
                }
            }
            else return "";
        }
    }
}