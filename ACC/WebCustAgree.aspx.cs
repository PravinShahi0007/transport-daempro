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
    public partial class WebCustAgree : System.Web.UI.Page
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
                BtnPrint.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnPrint);

                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "مصادقة على صحة رصيد حساب";
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
                        UserTran.Description = "اختيار مصادقة على صحة رصيد حساب";
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

        protected void BtnPrint_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (txtFDate.Text == "")
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال التاريخ";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    return;
                }
                if (RdoType.SelectedIndex < 2 && txtCode.Text == "")
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال الحساب";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    return;
                }
                iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, -50, -50, 80, 50);
                HttpContext.Current.Response.ContentType = "application/pdf";
                PdfWriter pw = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
                pdfPage page = new pdfPage();

                string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);

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


                Acc myAcc = new Acc();
                List<Acc1> lacc = new List<Acc1>();
                myAcc.Branch = 1;
                if (Cache["LastACC" + Session["CNN2"].ToString()] == null) Cache.Insert("LastACC" + Session["CNN2"].ToString(), myAcc.GetLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                if (RdoType.SelectedIndex < 2)
                {
                    lacc = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                            where itm.Code.StartsWith((RdoType.SelectedIndex == 0 ? "1203" : "220401"))
                            select itm).ToList();
                }
                else if (txtCode.Text != "")
                {
                    myAcc.Code = txtCode.Text.Split('.')[0].Trim();
                    if(myAcc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        lacc.Add(new Acc1
                        {
                            Code = myAcc.Code,
                            FCode = myAcc.FCode,
                            Name1 = myAcc.Name1,
                            Name2 = myAcc.Name2,
                            FType = myAcc.FType,
                            Branch = myAcc.Branch
                        });
                    }
                }



                foreach (Acc1 itm in lacc)                                          
                {
                    PdfPTable table = new PdfPTable(1);
                    float[] colWidths = { 800 };
                    table.SetWidths(colWidths);
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    PdfPCell cell0 = new PdfPCell();
                    cell0.RunDirection = PdfWriter.RUN_DIRECTION_LTR;
                    cell0.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell0.Border = 0;

                    PdfPCell cell = new PdfPCell();
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Border = 0;

                    table = new PdfPTable(2);
                    float[] colWidths2 = { 400, 400 };
                    table.SetWidths(colWidths2);
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    cell = new PdfPCell();
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    //---------------------------------------------------------------------
                    cell.Border = PdfPCell.TOP_BORDER | PdfPCell.RIGHT_BORDER | PdfPCell.LEFT_BORDER;
                    cell0.Border = PdfPCell.TOP_BORDER | PdfPCell.RIGHT_BORDER | PdfPCell.LEFT_BORDER;

                    cell.Phrase = new iTextSharp.text.Phrase("رقم الحساب : " + itm.Code, nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("Account No. : " + itm.Code, nationalTextFont);
                    table.AddCell(cell0);
                                                           
                    //---------------------------------------------------------------------
                    cell.Border = PdfPCell.RIGHT_BORDER | PdfPCell.LEFT_BORDER;
                    cell0.Border = PdfPCell.RIGHT_BORDER | PdfPCell.LEFT_BORDER;
                    cell.Phrase = new iTextSharp.text.Phrase("السادة / " + itm.Name1, nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("M/s: " + itm.Name2, nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("بمناسـبـة فحــص حســـاباتنا المعتــادة ، نود أن نطــلب منكـم ", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("In Connection with the regular internal audit of our", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("التصــديـق علـى صحـــة رصــيدكـم بدفاتـرنا حتــى تـاريـخ " , nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("accounts. we  would like to request you to confirm", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    double x = moh.GetBal(itm.Code,DateTime.Parse(txtFDate.Text).ToString(),WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    string bal = string.Format("{0:N2}", x);

                    cell.Phrase = new iTextSharp.text.Phrase(  txtFDate.Text + "م الموافق " + HDate.DatetoHjiri(txtFDate.Text) + " هـ البالغ قدره " + bal, nationalTextFont);       // + );
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("your balance with us as shown below: ", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("ريال سعودي " + moh.NTOC(x,1), nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("Balance as on " + txtFDate.Text + " SR." + bal, nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("يرجـي التكــرم بكتابـة الإســــم و التوقيــع ومـن ثـم ختمــه", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("Please sign and stamp this confirmation letter noting", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("بالختم الرسمي مع الادلاء باية إعتراضات أو فروقات إن وجدت", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("details of any differrences found and send it directly", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("وإرسالها مباشرة إلى الناقلات البرية العربية", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("to Arabian Land Transporters", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("ص.ب 87677", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("P.O.Box 87677 ", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("الرياض 11652", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("RIYADH 11652 ", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("فاكس : 4825357-011", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("Fax # 011-4825357 ", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("إن هذا الخطاب ليس مطالبة بالسداد بل لأغراض المراجعة", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("This is not a request for payment", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("وتفضلوا بقبول خالص تحياتنا", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("Best Regards,", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    //cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont14);
                    //table10.AddCell(cell);
                    //I use an image logo in the header so I need to get an instance of the image to be able to insert it. I believe this is something you couldn't do with older versions of iTextSharp
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("images/Sameh.png"));
                    iTextSharp.text.Image logo2 = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("images/Stamp.png"));
                   
                    //I used a large version of the logo to maintain the quality when the size was reduced. I guess you could reduce the size manually and use a smaller version, but I used iTextSharp to reduce the scale. As you can see, I reduced it down to 7% of original size.
                    logo.ScalePercent(100);

                    //create instance of a table cell to contain the logo
                    PdfPCell cell20 = new PdfPCell(logo);

                    //align the logo to the right of the cell

                    //add a bit of padding to bring it away from the right edge
                    cell20.PaddingTop = 0;
                    cell20.PaddingRight = 30;

                    //remove the border
                    cell20.Border = 0;

                    //Add the cell to the table
                    cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell20.Border = PdfPCell.RIGHT_BORDER | PdfPCell.LEFT_BORDER;

                    table.AddCell(cell20);
                    cell20 = new PdfPCell(logo2);
                    cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell20.PaddingRight = 0;
                    cell20.PaddingLeft = 15;
                    table.AddCell(cell20);

                    //cell.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    //table.AddCell(cell);

                    //cell0.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    //table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("الناقلات البرية العربية", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("Arabian Land Transporters", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Border = PdfPCell.TOP_BORDER | PdfPCell.RIGHT_BORDER | PdfPCell.LEFT_BORDER;
                    cell0.Border = PdfPCell.TOP_BORDER | PdfPCell.RIGHT_BORDER | PdfPCell.LEFT_BORDER;
                    cell.Phrase = new iTextSharp.text.Phrase("إلى السادة/الناقلات البرية العربية ", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("To M/s:Arabian Land Transporters", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Border = PdfPCell.RIGHT_BORDER | PdfPCell.LEFT_BORDER;
                    cell0.Border = PdfPCell.RIGHT_BORDER | PdfPCell.LEFT_BORDER;
                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("إن رصيد حسابنا معكم ................ ريال سعودي كما في", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("We confirm that the receivable balance of SR...............", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("تاريخ .................. صحيح مع عدا الإختلافات في الأسفل", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("with you as on.............is correct except as noted below", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("...........................................................................", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("...............................................................................", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("...........................................................................", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("...............................................................................", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("...........................................................................", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("...............................................................................", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("الاسم ...................................................................", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("Name : ....................................................................", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("الوظيفة ...............................................................", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("Designation: ............................................................", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("    ", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("    ", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("التوقيع", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("Signature:", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("التاريخ", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("Date:", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("الختم الرسمي", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("Stamp:", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------
                    cell.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.RIGHT_BORDER | PdfPCell.LEFT_BORDER;
                    cell0.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.RIGHT_BORDER | PdfPCell.LEFT_BORDER;
                    cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    table.AddCell(cell);

                    cell0.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    table.AddCell(cell0);
                    //---------------------------------------------------------------------

                    document.Add(table);
                    if (RdoType.SelectedIndex < 2) document.NewPage();
                }

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
                cell2.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
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

        protected void RdoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblAccount.Visible = (RdoType.SelectedIndex == 2);
            txtCode.Visible = (RdoType.SelectedIndex == 2);
        }


    }
}