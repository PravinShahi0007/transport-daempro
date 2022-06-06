using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class WebBarCode : System.Web.UI.Page
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
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnPrint);
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

                    if (Session["Barcode_" + Session["CurrentUser"].ToString()] == null)
                    {
                        LblError.Text = "لا توجد بيانات للطباعة";
                    }
                }
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message.ToString();
            }
        }

        protected void BtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    List<string> mybar = new List<string>();

                    foreach (vSTP itm in (List<vSTP>)Session["Barcode_" + Session["CurrentUser"].ToString()])
                    {
                        if (itm.UnitCode == "00002")
                        {
                            mybar.Add(itm.ITCode+"-"+itm.Quan.ToString());
                        }
                        else
                        {
                            for (int i = 0; i < itm.Quan; i++) mybar.Add(itm.ITCode);
                        }
                    }
                    Document document = new Document(PageSize.A4, (rdoDesign.SelectedIndex == 0 ? -100 : -75), -75, (rdoDesign.SelectedIndex == 0 ? 35 : 60), (rdoDesign.SelectedIndex == 0 ? 20 : 20));
                    HttpContext.Current.Response.ContentType = "application/pdf";
                    PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
                    document.Open();
                    PdfPTable table = new PdfPTable(4);
                    PdfPCell cell = new PdfPCell();
                    table.RunDirection = PdfWriter.RUN_DIRECTION_LTR;
                    table.HorizontalAlignment = Element.ALIGN_CENTER;

                    var cols2 = new[] { (rdoDesign.SelectedIndex == 0 ? 200 : 225), (rdoDesign.SelectedIndex == 0 ? 200 : 175), 200, 200 };
                    table.SetWidths(cols2);



                    //I use an image logo in the header so I need to get an instance of the image to be able to insert it. I believe this is something you couldn't do with older versions of iTextSharp
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("images/logo_naqlyat.png"));
                    //I used a large version of the logo to maintain the quality when the size was reduced. I guess you could reduce the size manually and use a smaller version, but I used iTextSharp to reduce the scale. As you can see, I reduced it down to 7% of original size.
                    logo.ScalePercent(25);
                    //create instance of a table cell to contain the logo
                    PdfPCell cell20 = new PdfPCell(logo);
                    //align the logo to the right of the cell
                    cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell20.VerticalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    //add a bit of padding to bring it away from the right edge
                    cell20.PaddingTop = 0;
                    cell20.PaddingRight = 0;
                    //remove the border
                    cell20.Border = 0;


                    string arialunicodepath = Server.MapPath("Fonts") + @"\ARIALUNI.TTF";
                    BaseFont nationalBase;
                    nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    Font nationalTextFont = new Font(nationalBase, 8f, Font.BOLD);

                    int Sticker = 0;
                    int rr = 0;
                    int[] arr = new int[11] { 0, -2, -4, -4 , -8 , 0, 1, 2 ,3 ,4 , 5 };
                    if(rdoDesign.SelectedIndex == 1) arr = new int[11]  { -2, -3, -4, -4, -5, -5, -6,-6,-7,-7,-8 };
                    for (int i = 0; i < 40; i = i + 4)
                    {
                        for (int x = 0; x < 4; x++)
                        {
                            CheckBox myCheck = Panel1.FindControl("ChkPrint" + (i + x + 1).ToString()) as CheckBox;
                            if (myCheck != null && myCheck.Checked)
                            {
                            }
                            else
                            {
                                cell.Phrase = new Phrase(" ", nationalTextFont);
                                cell.Border = 0;
                                cell.BorderColor = BaseColor.WHITE;
                                cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.FixedHeight = 20;
                                table.AddCell(cell);
                                Sticker++;
                            }
                        }

                        for (int x = 0; x < 4; x++)
                        {
                            CheckBox myCheck = Panel1.FindControl("ChkPrint" + (i + x + 1).ToString()) as CheckBox;
                            if (myCheck != null && myCheck.Checked)
                            {
                            }
                            else
                            {
                                cell.Phrase = new Phrase(" ", nationalTextFont);
                                cell.Border = 0;
                                cell.BorderColor = BaseColor.WHITE;
                                cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.FixedHeight = 40;
                                table.AddCell(cell);
                                Sticker++;
                            }
                        }

                        for (int x = 0; x < 4; x++)
                        {
                             CheckBox myCheck = Panel1.FindControl("ChkPrint" + (i + x + 1).ToString()) as CheckBox;
                             if (myCheck != null && myCheck.Checked)
                             {
                             }
                             else
                             {
                                 cell.Border = 0;
                                 cell.Phrase = new Phrase(" ", nationalTextFont);
                                 cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                 cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                 cell.FixedHeight = 20 + arr[rr];
                                 table.AddCell(cell);
                                 Sticker++;
                             }
                        }                        
                    }

                    for (int i = 0; i < mybar.Count(); i = i + 4)
                    {

                        for (int x = 0; x < 4; x++)
                        {
                            if (mybar.Count() <= (i + x))
                            {
                                cell.Phrase = new Phrase(" ", nationalTextFont);
                                cell.Border = 0;
                                cell.BorderColor = BaseColor.WHITE;
                                cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                table.AddCell(cell);
                                Sticker++;
                            }
                            else
                            {
                                table.AddCell(cell20);
                                Sticker++;
                            }
                        }

                        for (int x = 0; x < 4; x++)
                        {
                            if (mybar.Count() <= (i + x))
                            {
                                cell.Phrase = new Phrase(" ", nationalTextFont);
                                cell.Border = 0;
                                cell.BorderColor = BaseColor.WHITE;
                                cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                table.AddCell(cell);
                                Sticker++;
                            }
                            else
                            {
                                var TextCell = new PdfPCell(table.DefaultCell);
                                TextCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                TextCell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                TextCell.Border = 0;
                                TextCell.BorderColor = BaseColor.WHITE;
                                PdfContentByte cb = writer.DirectContent;
                                var bc128 = new Barcode128();
                                bc128.CodeType = Barcode.CODE128;
                                bc128.Code = mybar[i + x].ToString();
                                bc128.GenerateChecksum = true;
                                bc128.AltText = bc128.Code;
                                bc128.StartStopText = true;
                                TextCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                var bi = bc128.CreateImageWithBarcode(cb, null, null);
                                bi.ScalePercent(100);
                                bi.Alignment = Element.ALIGN_CENTER;
                                TextCell.AddElement(bi);
                                TextCell.FixedHeight = 40;
                                table.AddCell(TextCell);
                                Sticker++;
                            }
                        }

                        for (int x = 0; x < 4; x++)
                        {
                            cell.Border = 0;
                            cell.Phrase = new Phrase(" ", nationalTextFont);
                            cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.FixedHeight = 20 + arr[rr];
                            table.AddCell(cell);
                            Sticker++;
                        }                        
                        rr += 1;

                        if (rr == 10) rr = 0;
                    }
                    document.Add(table);
                    document.Close();
                }
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message.ToString();
            }
        }

        protected void BtnClear_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < 44; i++)
            {
                CheckBox myCheck = Panel1.FindControl("ChkPrint" + (i + 1).ToString()) as CheckBox;
                myCheck.Checked = true;
            }
        }

    }
}