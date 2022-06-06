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
using System.Configuration;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class WebUsersTranRep : System.Web.UI.Page
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
        public List<Transactions> MyOver
        {
            get
            {
                if (ViewState["MyOver"] == null)
                {
                    ViewState["MyOver"] = new List<Transactions>();
                }
                return (List<Transactions>)ViewState["MyOver"];
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
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnPrint);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnExcel);
                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "كشف متابعة المستخدمين";
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
                        UserTran.Description = "تم اختيار عرض كشف متابعة المستخدمين";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    Transactions tr = new Transactions();
                    ddlFormAction.DataTextField = "FormAction";
                    ddlFormAction.DataValueField = "FormAction";
                    ddlFormAction.DataSource = tr.GetFormAction(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    ddlFormAction.DataBind();
                    ddlFormAction.Items.Insert(0, new ListItem("--- جميع الاحداث ---", "-1", true));
                    ddlFormAction.SelectedIndex = 0;

                    ddlFormName.DataTextField = "FormName";
                    ddlFormName.DataValueField = "FormName";
                    ddlFormName.DataSource = tr.GetFormName(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    ddlFormName.DataBind();
                    ddlFormName.Items.Insert(0, new ListItem("--- جميع الصفحات---", "-1", true));
                    ddlFormName.SelectedIndex = 0;

                    ddlUserName.DataTextField = "UserName";
                    ddlUserName.DataValueField = "UserName";
                    ddlUserName.DataSource = tr.GetUserName(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    ddlUserName.DataBind();
                    ddlUserName.Items.Insert(0, new ListItem("--- جميع المستخدمين ---", "-1", true));
                    ddlUserName.SelectedIndex = 0;

                    Calendar1.SelectedDate = Calendar1.TodaysDate;
                    DisplayData();
                }
                else
                {
                    LblCodesResult.Text = "";
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

        protected void ddlRecordsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                grdCodes.PageSize = int.Parse((sender as DropDownList).SelectedValue);
                DisplayData();
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

        public void DisplayData()
        {
            try
            {
                Transactions myTran = new Transactions();
                myTran.TranDate = String.Format("{0:dd/MM/yyyy}", Calendar1.SelectedDate);
                myTran.UserName = ddlUserName.SelectedValue;
                myTran.FormName = ddlFormName.SelectedValue;
                myTran.FormAction = ddlFormAction.SelectedValue;
                grdCodes.DataSource = myTran.GetAll(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                grdCodes.DataBind();
                MyOver = (List<Transactions>)grdCodes.DataSource;
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

        protected void BtnProcess_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                DisplayData();
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
                DisplayData();
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

        protected void BtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            /*            try
                        {
                            if (Page.IsValid)
                            {
                                iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), -50, -50, 80, 50);
                                HttpContext.Current.Response.ContentType = "application/pdf";
                                PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
                                pdfPage page = new pdfPage();
                                page.PageNo = "1";
                                page.UserName = Session["FullUser"].ToString();

                                string vStr = "";
                                int CheckedItems = 0;
                                for (int i = 0; i < ChkMonth.Items.Count; i++)
                                {
                                    if (ChkMonth.Items[i].Selected)
                                    {
                                        if (vStr == "") vStr += ChkMonth.Items[i].Text;
                                        else vStr += " , " + ChkMonth.Items[i].Text;
                                    }
                                }
                                page.vStr1 = vStr;
                                page.vStr2 = RdoPayType.SelectedItem.Text;
                                writer.PageEvent = page;
                                document.Open();

                                string arialunicodepath = Server.MapPath("Fonts") + @"\arial.ttf";
                                BaseFont nationalBase;
                                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);

                                PdfPTable table = new PdfPTable(11);
                                table.TotalWidth = document.PageSize.Width; //100f;
                                var cols = new[] { 120, 120, 120, 120, 120, 120, 120, 300, 300, 100, 80 };
                                table.SetWidths(cols);
                                PdfPCell cell = new PdfPCell();
                                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                                string[] str = new string[20];
                                for (int i = 0; i < 20; i++)
                                {
                                    str[i] = " ";
                                }

                                CheckedItems = 0;
                                for (int i = 0; i < ChkMonth.Items.Count; i++)
                                {
                                    if (ChkMonth.Items[i].Selected)
                                    {
                                        str[CheckedItems] = ChkMonth.Items[i].Text;
                                        CheckedItems++;
                                    }
                                }
                                List<Insurance> listPay = new List<Insurance>();
                                listPay = MyOver;

                                //String vDep = "";
                                int Counter = 1;
                                double totFixEmp = 0, totVarEmp = 0, totFixFri = 0, totVarFri = 0, totTEmp = 0, totTFri = 0, totTotal = 0;
                                foreach (Insurance itm in listPay)
                                {
                                    cell.Phrase = new iTextSharp.text.Phrase(Counter.ToString(), nationalTextFont);
                                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                    table.AddCell(cell);

                                    cell.Phrase = new iTextSharp.text.Phrase(itm.EmpCode.ToString(), nationalTextFont);
                                    table.AddCell(cell);

                                    cell.Phrase = new iTextSharp.text.Phrase(itm.Name, nationalTextFont);
                                    table.AddCell(cell);

                                    cell.Phrase = new iTextSharp.text.Phrase(itm.DepName, nationalTextFont);
                                    table.AddCell(cell);

                                    totFixEmp += (double)itm.FixEmp;
                                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", itm.FixEmp), nationalTextFont);
                                    table.AddCell(cell);

                                    totVarEmp += (double)itm.VarEmp;
                                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", itm.VarEmp), nationalTextFont);
                                    table.AddCell(cell);

                                    totFixFri += (double)itm.FixFri;
                                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", itm.FixFri), nationalTextFont);
                                    table.AddCell(cell);

                                    totVarFri += (double)itm.VarFri;
                                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", itm.VarFri), nationalTextFont);
                                    table.AddCell(cell);

                                    totTEmp += (double)itm.TEmp;
                                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", itm.TEmp), nationalTextFont);
                                    table.AddCell(cell);

                                    totTFri += (double)itm.TFri;
                                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", itm.TFri), nationalTextFont);
                                    table.AddCell(cell);

                                    totTotal += (double)itm.Total;
                                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", itm.Total), nationalTextFont);
                                    table.AddCell(cell);

                                    document.Add(table);
                                    table.Rows.Clear();
                                    Counter++;
                                }

                                if (totFixEmp != 0 || totVarEmp != 0 || totFixFri != 0 || totVarFri != 0 || totTEmp != 0 || totTFri != 0 || totTotal != 0)
                                {
                                    cell.Phrase = new iTextSharp.text.Phrase("الاجمالي", nationalTextFont);
                                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                    table.AddCell(cell);

                                    cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                                    table.AddCell(cell);

                                    cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                                    table.AddCell(cell);

                                    cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                                    table.AddCell(cell);

                                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", totFixEmp), nationalTextFont);
                                    table.AddCell(cell);

                                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", totVarEmp), nationalTextFont);
                                    table.AddCell(cell);

                                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", totFixFri), nationalTextFont);
                                    table.AddCell(cell);

                                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", totVarFri), nationalTextFont);
                                    table.AddCell(cell);

                                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", totTEmp), nationalTextFont);
                                    table.AddCell(cell);

                                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", totTFri), nationalTextFont);
                                    table.AddCell(cell);

                                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N3}", totTotal), nationalTextFont);
                                    table.AddCell(cell);
                                }
                                document.Add(table);
                                document.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = ex.Message.ToString();
                        }
                        finally
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true), true);
                        }*/
        }



        // *************************************************** ITextSharp ****************************************************************
        public class pdfPage : iTextSharp.text.pdf.PdfPageEventHelper
        {
            public string vStr1, vStr2;
            public string UserName, PageNo;
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
                string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\DTNASKH1.TTF";
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 16f, iTextSharp.text.Font.NORMAL);

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
                cell2.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                headerTbl.AddCell(cell2);

                cell2.PaddingRight = 0;
                cell2.Phrase = new iTextSharp.text.Phrase("كشف التأمينات مفصل", nationalTextFont);
                cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                headerTbl.AddCell(cell2);

                cell2.PaddingRight = 15;

                //I use an image logo in the header so I need to get an instance of the image to be able to insert it. I believe this is something you couldn't do with older versions of iTextSharp
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("images/yayat.jpg"));

                //I used a large version of the logo to maintain the quality when the size was reduced. I guess you could reduce the size manually and use a smaller version, but I used iTextSharp to reduce the scale. As you can see, I reduced it down to 7% of original size.
                logo.ScalePercent(15);

                //create instance of a table cell to contain the logo
                PdfPCell cell20 = new PdfPCell(logo);
                cell20.ArabicOptions = ColumnText.DIGITS_EN2AN;
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
                nationalTextFont = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);
                if (vStr1 != "")
                {
                    PdfPTable table5 = new PdfPTable(4);
                    table5.TotalWidth = 100f;

                    var cols5 = new[] { 175, 75, 175, 75 };
                    table5.SetWidths(cols5);
                    PdfPCell cell5 = new PdfPCell();
                    cell5.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    table5.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table5.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    cell5.Phrase = new iTextSharp.text.Phrase("الشهر/الفترة", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    //cell.Border = 0;
                    table5.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase(vStr1, nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table5.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("نوع الصرفية", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table5.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase(vStr2, nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table5.AddCell(cell5);

                    doc.Add(table5);
                    doc.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    vStr1 = "";
                }

                PdfPTable table = new PdfPTable(11);
                table.TotalWidth = doc.PageSize.Width;

                var cols = new[] { 120, 120, 120, 120, 120, 120, 120, 300, 300, 100, 80 };
                table.SetWidths(cols);
                PdfPCell cell = new PdfPCell();
                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                cell.Phrase = new iTextSharp.text.Phrase("رقم مسلسل", nationalTextFont);
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("رقم الموظف", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("الاسم", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("الإدارة", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("تامينات ثابتة العامل", nationalTextFont);
                //cell.Border = 0;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("تامينات متغيرة العامل", nationalTextFont);
                //cell.Border = 0;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("تامينات ثابتة صاحب العمل", nationalTextFont);
                //cell.Border = 0;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("تامينات متغيرة صاحب العمل", nationalTextFont);
                //cell.Border = 0;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("أجمالي حصة العامل", nationalTextFont);
                //cell.Border = 0;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("أجمالي حصة صاحب العمل", nationalTextFont);
                //cell.Border = 0;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("أجمالي التامينات", nationalTextFont);
                //cell.Border = 0;
                table.AddCell(cell);

                ////I use an image logo in the header so I need to get an instance of the image to be able to insert it. I believe this is something you couldn't do with older versions of iTextSharp
                //iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/images/Signa_NEW.gif"));

                ////I used a large version of the logo to maintain the quality when the size was reduced. I guess you could reduce the size manually and use a smaller version, but I used iTextSharp to reduce the scale. As you can see, I reduced it down to 7% of original size.
                //logo.ScalePercent(20);

                ////create instance of a table cell to contain the logo
                //PdfPCell cell = new PdfPCell(logo);

                ////align the logo to the right of the cell
                //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                ////add a bit of padding to bring it away from the right edge
                ////cell.PaddingRight = 20;

                ////remove the border
                //cell.Border = 0;

                ////Add the cell to the table
                //headerTbl.AddCell(cell);

                //cell2.Phrase = new iTextSharp.text.Phrase("             ", nationalTextFont);
                //headerTbl.AddCell(cell2);

                //write the rows out to the PDF output stream. I use the height of the document to position the table. Positioning seems quite strange in iTextSharp and caused me the biggest headache.. It almost seems like it starts from the bottom of the page and works up to the top, so you may ned to play around with this.
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
            DisplayData();
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

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DisplayData();
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

        protected void ddlUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void ddlFormName_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void ddlFormAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }
    }
}