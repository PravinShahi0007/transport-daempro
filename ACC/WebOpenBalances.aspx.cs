using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using System.Threading;
using System.Globalization;
using System.Web.UI.HtmlControls;
using iTextSharp.text.pdf;

namespace ACC
{
    public partial class WebOpenBalances : System.Web.UI.Page
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
                BtnPrint1.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                if (!Page.IsPostBack)
                {
                    Session["Branch"] = "1";
                    this.Page.Header.Title = "Inventory Data Entery";
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

                    LoadGridData();
                }
                else
                {
                    LblCodesResult.Text = "";
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        public void LoadGridData()
        {
            vStock myStock = new vStock();
            myStock.Branch = short.Parse(Session["Branch"].ToString());
            myStock.Number = short.Parse(ddlStore.SelectedValue);
            grdCodes.DataSource = myStock.GetNumber(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            grdCodes.DataBind();
        }

        protected void grdCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdCodes.PageIndex = e.NewPageIndex;
                LoadGridData();
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    bool vError = false;
                    foreach (GridViewRow gvr in grdCodes.Rows)
                    {
                        string Code = grdCodes.DataKeys[gvr.RowIndex]["Code"].ToString();
                        TextBox txtNCode = gvr.FindControl("txtNCode") as TextBox;
                        TextBox TxtITCode2 = gvr.FindControl("TxtITCode2") as TextBox;
                        if (txtNCode != null && TxtITCode2 != null)
                        {
                            List<Item> li = new List<Item>();
                            Item myitem = new Item();
                            //if (TxtITCode2.Text != "")
                            //{
                            //    myitem.Branch = short.Parse(Session["Branch"].ToString());
                            //    myitem.ITCode2 = TxtITCode2.Text;
                            //    li = myitem.GetByITCode2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            //    if (li != null && (li.Count() > 1 || (li.Count()>0 && li[0].ITCode != Code)))
                            //    {
                            //        vError = true;
                            //        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            //        LblCodesResult.Text = "Duplicate Part No." + TxtITCode2.Text;
                            //        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(1,'" + LblCodesResult.Text + "');", true);
                            //        break;
                            //    }
                            //}

                            myitem = new Item();
                            if (txtNCode.Text != "")
                            {
                                myitem.Branch = short.Parse(Session["Branch"].ToString());
                                myitem.NCode = txtNCode.Text;
                                li = myitem.GetByNCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (li != null && (li.Count() > 1 || (li.Count() > 0 && li[0].ITCode != Code)))
                                {
                                    vError = true;
                                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                    LblCodesResult.Text = "Duplicate New Code " + txtNCode.Text;
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(1,'" + LblCodesResult.Text + "');", true);
                                    break;
                                }
                            }

                            myitem = new Item();
                            myitem.Branch = short.Parse(Session["Branch"].ToString());
                            myitem.ITCode = Code;
                            myitem = myitem.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myitem != null)
                            {
                                myitem.ITCode2 = TxtITCode2.Text;
                                myitem.NCode = txtNCode.Text;
                                myitem.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }
                        }
                    }

                    if (vError) return;
                    foreach (GridViewRow gvr in grdCodes.Rows)
                    {
                        double vOldQuan = 0;
                        string Code = grdCodes.DataKeys[gvr.RowIndex]["Code"].ToString();
                        TextBox txtLoc = gvr.FindControl("txtLoc") as TextBox;
                        TextBox txtIOpen = gvr.FindControl("txtIOpen") as TextBox;
                        TextBox txtITCPrice = gvr.FindControl("txtITCPrice") as TextBox;

                        if (Code != null && txtLoc != null && txtIOpen != null && txtITCPrice != null)
                        {
                            if (txtIOpen.Text == "") txtIOpen.Text = "0";
                            if (txtITCPrice.Text == "") txtITCPrice.Text = "0";                     
                            Stock myStock = new Stock();
                            myStock.Branch = short.Parse(Session["Branch"].ToString());
                            myStock.Number = short.Parse(ddlStore.SelectedValue);
                            myStock.Code = Code;
                            myStock = myStock.GetItem(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if(myStock!=null)
                            {
                                Item myItem = new Item();
                                myItem.Branch = short.Parse(Session["Branch"].ToString());
                                myItem.ITCode = Code;
                                myItem = myItem.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (myItem != null)
                                {
                                    vOldQuan = (double)myStock.IOpen;
                                    double vQuan = 0;
                                    myStock.Loc = txtLoc.Text;
                                    myStock.IOpen = double.Parse(txtIOpen.Text);
                                    myStock.AOpen = double.Parse(txtIOpen.Text) * double.Parse(txtITCPrice.Text);
                                    myStock.OpenDate = "";  //txtOpenDate.Text;
                                    if (myStock.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {                                    
                                        foreach (Stock itm in myStock.GetItems(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                        {
                                            vQuan += (double)itm.IOpen;
                                        }
                                    }
                                    myItem.ITCPrice = double.Parse(txtITCPrice.Text);
                                    myItem.IOpen = vQuan;
                                    myItem.AOpen = vQuan * myItem.ITCPrice;
                                    if (myItem.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        if ((double)((double.Parse(txtIOpen.Text) - vOldQuan) * myItem.ITCPrice) != 0)
                                        {
                                            String vStockAccount = "";

                                            Shop myShop = new Shop();
                                            myShop.FType = 2;
                                            myShop.Bran = 1;
                                            myShop.Number = short.Parse(ddlStore.SelectedValue);
                                            if (myShop.GetShop(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                            {
                                                vStockAccount = myShop.CPur_Acc + moh.MakeMask(ddlStore.SelectedValue, 2);
                                            }

                                            ICat myCat = new ICat();
                                            myCat.Branch = short.Parse(Session["Branch"].ToString());
                                            myCat.Code = myItem.ICat;
                                            myCat = myCat.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                            if (myCat != null)
                                            {
                                                vStockAccount += myCat.CPur_Acc;
                                            }

                                            Acc myAcc = new Acc();
                                            myAcc.Branch = short.Parse(Session["Branch"].ToString());
                                            myAcc.Code = vStockAccount;
                                            myAcc.Post(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, 1, (double)((double.Parse(txtIOpen.Text) - vOldQuan) * myItem.ITCPrice));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(1,'" + LblCodesResult.Text + "');", true);
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGridData();
        }


        protected void BtnPrint1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, -50, -50, 80, 50);
                HttpContext.Current.Response.ContentType = "application/pdf";
                PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
                pdfPage page = new pdfPage();
                writer.PageEvent = page;
                int ColCount = 7;
                var cols = new[] { 100, 100, 100, 270, 50, 90, 90 };
                document.Open();
                PdfPTable table = new PdfPTable(ColCount);
                table.RunDirection = PdfWriter.RUN_DIRECTION_LTR;
                table.TotalWidth = document.PageSize.Width; //100f;
                table.SetWidths(cols);
                PdfPCell cell = new PdfPCell();
                //cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                string arialunicodepath = Server.MapPath("Fonts") + @"\arial.ttf";
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font nationalTextFont14 = new iTextSharp.text.Font(nationalBase, 14f, iTextSharp.text.Font.NORMAL);
                //cell.Border = 0;

                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.BackgroundColor = iTextSharp.text.BaseColor.GRAY;
                cell.Phrase = new iTextSharp.text.Phrase("Item Code", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("New Code", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Part No.", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Description", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Loc", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Balance", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Cost Price", nationalTextFont);
                table.AddCell(cell);

                vStock myStock = new vStock();
                myStock.Branch = short.Parse(Session["Branch"].ToString());
                myStock.Number = short.Parse(Request.QueryString["Store"].ToString());
                foreach (vStock myItem2 in myStock.GetNumber(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(myItem2.Code, nationalTextFont); // 
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(myItem2.NCode, nationalTextFont); // 
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(myItem2.ITCode2, nationalTextFont); // 
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(myItem2.ITName1, nationalTextFont); // 
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(myItem2.IOpen.ToString(), nationalTextFont); // 
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(myItem2.ITCPrice.ToString(), nationalTextFont);  // 
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase((myItem2.ITCPrice * myItem2.IOpen).ToString(), nationalTextFont);  // 
                    table.AddCell(cell);                    

                }
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
            public string vStr1, vStr2, vStr3, vStr4, UserName, PageNo, vCompanyName;
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
                    iTextSharp.text.Font font = new iTextSharp.text.Font(nationalBase, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                    return font;
                }
            }
            //override the OnStartPage event handler to add our header
            public override void OnStartPage(PdfWriter writer, iTextSharp.text.Document doc)
            {
                string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\arial.TTF";
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 16f, iTextSharp.text.Font.NORMAL);

                //I use a PdfPtable with 1 column to position my header where I want it
                PdfPTable headerTbl = new PdfPTable(1);
                var cols2 = new[] { 700 };

                headerTbl.SetWidths(cols2);
                headerTbl.TotalWidth = doc.PageSize.Width;

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
                cell20.PaddingRight = 0;

                //remove the border
                cell20.Border = 0;

                //Add the cell to the table
                headerTbl.AddCell(cell20);

                headerTbl.WriteSelectedRows(0, -1, -1, (doc.PageSize.Height - 20), writer.DirectContent);
            }

            //override the OnPageEnd event handler to add our footer
            public override void OnEndPage(PdfWriter writer, iTextSharp.text.Document doc)
            {
                PdfPTable footerTbl = new PdfPTable(4);
                footerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                var cols2 = new[] { 175, 175, 175, 175 };
                footerTbl.SetWidths(cols2);
                footerTbl.TotalWidth = doc.PageSize.Width;
                footerTbl.WidthPercentage = 70F;
                footerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                PdfPCell cell = new PdfPCell();
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell.BorderWidthLeft = 1;
                cell.BorderWidthRight = 1;
                cell.BorderWidthTop = 1;
                cell.BorderWidthBottom = 1;

                //add some padding to bring away from the edge
                cell.PaddingLeft = 15;
                cell.Phrase = new iTextSharp.text.Phrase("112", footer);
                //add cell to table
                footerTbl.AddCell(cell);

                //create new instance of cell to hold the text
                //cell = new PdfPCell();

                //align the text to the right of the cell
                //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell.Phrase = new iTextSharp.text.Phrase("Rev.(0) ", footer);

                // add some padding to take away from the edge of the page
                //cell.PaddingRight = 5;

                //add the cell to the table
                footerTbl.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Page  : " + writer.PageNumber.ToString(), footer);
                footerTbl.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("01/01/2015", footer);

                // add some padding to take away from the edge of the page
                cell.PaddingLeft = 5;

                //add the cell to the table
                footerTbl.AddCell(cell);

                //write the rows out to the PDF output stream.
                footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin - 10), writer.DirectContent);
            }
        }
    }
}