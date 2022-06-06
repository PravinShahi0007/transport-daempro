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
    public partial class WebTrackMoveRep2 : System.Web.UI.Page
    {
        public List<TrackMove> MyOver
        {
            get
            {
                if (ViewState["MyOver"] == null)
                {
                    ViewState["MyOver"] = new List<TrackMove>();
                }
                return (List<TrackMove>)ViewState["MyOver"];
            }
            set { ViewState["MyOver"] = value; }
        }
        public string vRoleName
        {
            get
            {
                if (ViewState["RoleName"] == null)
                {
                    ViewState["RoleName"] = "Roll";
                }
                return ViewState["RoleName"].ToString();
            }
            set { ViewState["RoleName"] = value; }
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
                //BtnPrint1.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                //BtnExcel.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                //ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnPrint1);
                //ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnExcel);

                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "بيان حركة الشاحنات";
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

                    /*
                    Transactions UserTran = new Transactions();
                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                    UserTran.UserName = Session["CurrentUser"].ToString();
                    UserTran.FormName = "الرئيسية";
                    UserTran.FormAction = "اختيار";
                    UserTran.Description = "اختيار عرض الحركة اليومية للفرع";
                    UserTran.IP = IPNetworking.GetIP4Address();
                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    */

                    CostCenter myCostCenter = new CostCenter();
                    myCostCenter.Branch = 1;
                    if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlBranch.DataTextField = "Name1";
                    ddlBranch.DataValueField = "Code";
                    ddlBranch.DataSource = (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()]);
                    ddlBranch.DataBind();
                    ddlBranch.Items.Insert(0, new ListItem("جميع الفروع", "-1", true));

                    ddlBranch.SelectedValue = AreaNo;
                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    vRoleName = moh.GetCurrentRole(ddlBranch.SelectedValue, (from useritm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                                                             where useritm.UserName == Session["CurrentUser"].ToString()
                                                                             select useritm).FirstOrDefault());
                    if (Session[vRoleName] == null)
                    {
                        Response.Redirect("WebNotPrev.aspx", false);
                        return;
                    }
                    ddlBranch.Enabled = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass421;
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
                lblNow.Text = moh.Nows().ToString();
                grdCodes.DataSource = MyOver;
                grdCodes.DataBind();
                lblCount.Text = MyOver.Count().ToString();
                //BtnPrint1.Visible = MyOver.Count() > 0;
                //BtnExcel.Visible = MyOver.Count() > 0;
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
                iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), -50, -50, 80, 50);
                HttpContext.Current.Response.ContentType = "application/pdf";
                PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
                pdfPage page = new pdfPage();
                MyConfig mySetting = new MyConfig();
                mySetting.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                mySetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                if (mySetting != null)
                {
                    page.vCompanyName = mySetting.CompanyName;
                }

                writer.PageEvent = page;
                page.PageNo = "1";
                page.UserName = Session["FullUser"].ToString();

                CostCenter myCost = new CostCenter();
                myCost.Branch = 1;
                if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCost.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myCost.Code = Request.QueryString["AreaNo"] != null ? Request.QueryString["AreaNo"].ToString() : Session["AreaNo"].ToString();
                myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                          where citm.Code == myCost.Code
                          select citm).FirstOrDefault();
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
                cell2.Phrase = new iTextSharp.text.Phrase("بيان حركة الشاحنات", nationalTextFont16);
                table.AddCell(cell2);

                document.Add(table);
                //-------------------------------------------------------------------------------------------
                document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                //-------------------------------------------------------------------------------------------
                cols = new[] { 800, 250, 150 };
                table = new PdfPTable(3);
                table.TotalWidth = document.PageSize.Width / 4;
                table.SetWidths(cols);
                cell2 = new PdfPCell();
                cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell2.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                cell2.Phrase = new iTextSharp.text.Phrase("الفرع", nationalTextFont);
                table.AddCell(cell2);

                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell2.Phrase = new iTextSharp.text.Phrase(ddlBranch.SelectedItem.Text, nationalTextFont);
                table.AddCell(cell2);

                cell2.Border = 0;
                cell2.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell2);

                document.Add(table);

                //-------------------------------------------------------------------------------------------
                document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                //-------------------------------------------------------------------------------------------
                cols = new[] { 50, 100, 100, 75, 100, 100, 100, 100, 100, 100, 100, 100, 100, 150, 50 };
                table = new PdfPTable(15);
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

                cell.Phrase = new iTextSharp.text.Phrase("اسم السائق", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("رقم الشاحنة", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("رقم اللوحة", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("بيان الترحيل", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("التاريخ", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("الوقت", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("جهة الترحيل", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("جهة الوصول", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("الحالة", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("وقت الوصول المتوقع", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("بيان الوصول", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("التاريخ", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("الوقت", nationalTextFont2);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("فرق الوصول", nationalTextFont2);
                table.AddCell(cell);

                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;

                if (MyOver != null && MyOver.Count > 0)
                {
                    foreach (TrackMove inv in MyOver)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(inv.FNo.ToString(), nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.Driver, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.Code, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.PlateNo, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.CarMoveNo, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.CarMoveDate, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.CarMoveFTime, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.CarMoveFromLoc, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.CarMoveToLoc, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.Status, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.RCVFTime2, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.CarMoveRCVNo, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.CarMoveRCVDate, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.CarMoveRCVFTime, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(inv.Diff.ToString(), nationalTextFont);
                        table.AddCell(cell);
                    }
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
                lblNow.Text = moh.Nows().ToString();
                lblCount.Text = "";
                //MyOver.Clear();

                List<TrackMove> inline = new List<TrackMove>();

                List<Drivers> dr = new List<Drivers>();
                Drivers myDrive = new Drivers();
                myDrive.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                dr = (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()]);

                List<Cities> lcity = new List<Cities>();
                Cities myCity = new Cities();
                myCity.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                lcity = (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()]);

                int i = 1;
                Cars myCar = new Cars();
                myCar.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myCar.CarsType = 1;
                inline = (from itm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                          where (bool)itm.Status && (itm.CarsType == 1 || itm.CarsType == 3 || itm.CarsType == 32 || itm.CarsType == 33)
                          orderby itm.PlateNo                         
                          select new TrackMove
                          {
                              FNo = i++,
                              Code = itm.Code,
                              Driver = (from d in dr
                                        where d.Code == itm.DriverCode
                                        select d.Name1).FirstOrDefault(),
                              PlateNo = itm.PlateNo
                          }).ToList();


                foreach (TrackMove itm in inline)
                {
                    CarMove cm = new CarMove();
                    cm.CarCode = itm.Code;
                    cm = cm.FindLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (cm != null)
                    {
                        itm.CarMoveNo = int.Parse(cm.VouLoc).ToString() + "/" + cm.Number.ToString();
                        itm.CarMoveFTime = cm.FTime;
                        itm.CarMoveDate = cm.GDate;
                        itm.CarMoveFrom = cm.FromLoc;
                        itm.CarMoveFromLoc = (from d in lcity
                                              where d.Code == cm.FromLoc
                                              select d.Name1).FirstOrDefault();
                        itm.CarMoveTo = cm.ToLoc;
                        itm.CarMoveToLoc = (from d in lcity
                                            where d.Code == cm.ToLoc
                                            select d.Name1).FirstOrDefault();
                        if (string.IsNullOrEmpty(itm.Driver)) itm.Driver = (from d in dr
                                                                            where d.Code == cm.DriverCode
                                                                            select d.Name1).FirstOrDefault();
                        CarPrices myPrice = new CarPrices();
                        myPrice.Branch = short.Parse(Session["Branch"].ToString());
                        myPrice.MonthNo = 0;
                        myPrice.FromCode = cm.FromLoc;
                        myPrice.toCode = cm.FromLoc;
                        myPrice.PLevel = "00002";
                        myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myPrice != null && !string.IsNullOrEmpty(myPrice.FTime) && !string.IsNullOrEmpty(cm.FTime))
                        {
                            double add = 0;
                            double.TryParse(myPrice.FTime, out add);
                            DateTime DFrom = new DateTime();
                            DFrom = DateTime.Parse(cm.GDate + " " + cm.FTime.Replace("ص", "AM").Replace("م", "PM"));
                            itm.RCVFTime = DFrom.AddHours(add).ToString();
                            itm.RCVFTime2 = DFrom.AddHours(add).ToShortTimeString();
                        }

                        CarMoveRCV Rcv = new CarMoveRCV();
                        Rcv.Branch = short.Parse(Session["Branch"].ToString());
                        Rcv.CarMove = int.Parse(cm.VouLoc).ToString() + "/" + cm.Number.ToString();
                        Rcv = Rcv.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (Rcv != null)
                        {
                            itm.CarMoveRCVNo = Rcv.LocNumber.ToString() + "/" + Rcv.Number.ToString();
                            itm.CarMoveRCVDate = Rcv.GDate;
                            itm.CarMoveRCVFTime = Rcv.FTime;
                            itm.Status = "تم الوصول";

                            //if (itm.Diff < 0)
                            //{
                            //    itm.Status = "وصلت متاخره";
                            //}
                            //else
                            //{
                            //    itm.Status = "تم الوصول";
                            //}
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(itm.RCVFTime))
                            {
                                itm.Status = " *****في الطريق";
                            }
                            else if (DateTime.Now > DateTime.Parse(itm.RCVFTime))
                            {
                                itm.Status = "تأخرت في الطريق";
                            }
                            else
                            {
                                itm.Status = "في الطريق";
                            }
                        }
                    }
                }
                if (ddlBranch.SelectedValue != "-1")
                {
                    List<Cities> lc = new List<Cities>();
                    Cities mc = new Cities();
                    mc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), mc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    lc = mc.GetMySites(ddlBranch.SelectedValue, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()]), (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()]));
                    inline = (from itm in inline
                              //where CheckSite(itm.CarMoveTo, lc) || CheckSite(itm.CarMoveFrom, lc)
                              where CheckSite(itm.CarMoveTo, lc) 
                              select itm).ToList();
                }
                i = 1;
                foreach (TrackMove itm in inline)
                {
                    itm.FNo = i++;
                }

                
                if (MyOver != null && MyOver.Count()>0)
                {
                    IEnumerable<TrackMove> x = inline.Except(MyOver, new ProductComparer());
                    if (x.Count() > 0)
                    {
                        MyOver.Clear();
                        MyOver.AddRange(inline);
                        LoadCodesData();
                    }
                }
                else
                {
                    MyOver.Clear();
                    MyOver.AddRange(inline);
                    LoadCodesData();
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

        public bool CheckSite(string CurrentCity, List<Cities> lc)
        {
            bool vFound = false;
            foreach (Cities itm in lc)
            {
                if (CurrentCity == itm.Code)
                {
                    vFound = true;
                    break;
                }
            }
            return vFound;
        }

        protected string UrlHelper(object FType, object Number)
        {
            if (Number != null)
            {
                string[] vs = Number.ToString().Split('/');
                if (vs.Count() > 1)
                {
                    switch (short.Parse(FType.ToString()))
                    {
                        case 1: return (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass422 ? "~/WebCarMove.aspx?FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&Flag=0&StoreNo=" + StoreNo : "";
                        case 2: return (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass423 ? "~/WebCarMoveRCV.aspx?FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&Flag=0&StoreNo=" + StoreNo : "";
                        default: return "";
                    }
                }
                else return "";
            }
            else return "";
        }

        protected void grdCodes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (DataControlRowType.DataRow == e.Row.RowType)
            {
                string FNo = grdCodes.DataKeys[e.Row.RowIndex]["FNo"].ToString();

                if (MyOver[int.Parse(FNo) - 1].Diff < 0)
                {
                    //e.Row.CssClass = "UnreadRowStyle";
                    //e.Row.BackColor = ColorTranslator.FromHtml("#ECFFD9");
                    e.Row.Cells[9].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[14].ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            BtnProcess_Click(sender,null);
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnProcess_Click(sender, null);
        }

        class ProductComparer : IEqualityComparer<TrackMove>
        {
            public bool Equals(TrackMove x, TrackMove y)
            {
                if (Object.ReferenceEquals(x, y)) return true;
                if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                    return false;
                return x.Code == y.Code && x.PlateNo == y.PlateNo && x.DriverCode == y.DriverCode && x.CarMoveNo == y.CarMoveNo 
                    && x.CarMoveFrom == y.CarMoveFrom && x.CarMoveTo == y.CarMoveTo  && x.CarMoveRCVNo == y.CarMoveRCVNo;
		    }

            public int GetHashCode(TrackMove x)
            {
                if (Object.ReferenceEquals(x, null)) return 0;

                //Get hash code for the Name field if it is not null.
                int hashProductName = x.PlateNo == null ? 0 : x.PlateNo.GetHashCode();

                //Get hash code for the Code field.
                int hashProductCode = x.Code.GetHashCode();

                //Calculate the hash code for the product.
                return hashProductName ^ hashProductCode;
            }

        }


    }
}