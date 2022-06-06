using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using System.Configuration;
using System.Text;
using AjaxControlToolkit;
using System.Threading;
using System.Globalization;
using System.Web.UI.DataVisualization.Charting;


namespace ACC
{
    public partial class _default : System.Web.UI.Page
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
        public bool AutoRefresh
        {
            get
            {
                if (ViewState["AutoRefresh"] == null)
                {
                    ViewState["AutoRefresh"] = false;
                }
                return bool.Parse(ViewState["AutoRefresh"].ToString());
            }
            set { ViewState["AutoRefresh"] = value; }
        }
        public CostCenter SiteInfo
        {
            get
            {
                if (ViewState["SiteInfo"] == null)
                {
                    ViewState["SiteInfo"] = new CostCenter();
                }
                return (CostCenter)ViewState["SiteInfo"];
            }
            set { ViewState["SiteInfo"] = value; }
        }
        public string  StoreNo
        {
            get
            {
                if (ViewState["StoreNo"] == null)
                {
                    ViewState["StoreNo"] = "00001";
                }
                return ViewState["StoreNo"].ToString();
            }
            set { ViewState["StoreNo"] = value; }
        }
        public List<myInv2> CarMoveData
        {
            get
            {
                if (ViewState["CarMoveData"] == null)
                {
                    ViewState["CarMoveData"] = new List<myInv2>();
                }
                return (List<myInv2>)ViewState["CarMoveData"];
            }
            set
            {
                ViewState["CarMoveData"] = value;

            }
        }
        public List<CarMoveTrip> OverCarMoveTrip
        {
            get
            {
                if (ViewState["OverCarMoveTrip"] == null)
                {
                    ViewState["OverCarMoveTrip"] = new List<CarMoveTrip>();
                }
                return (List<CarMoveTrip>)ViewState["OverCarMoveTrip"];
            }
            set
            {
                ViewState["OverCarMoveTrip"] = value;

            }
        }
        public List<CarMoveTrip> OverCarMoveChart
        {
            get
            {
                if (ViewState["OverCarMoveChart"] == null)
                {
                    ViewState["OverCarMoveChart"] = new List<CarMoveTrip>();
                }
                return (List<CarMoveTrip>)ViewState["OverCarMoveChart"];
            }
            set
            {
                ViewState["OverCarMoveChart"] = value;

            }
        }
        public List<TrackMove> MyOverTrack
        {
            get
            {
                if (ViewState["MyOverTrack"] == null)
                {
                    ViewState["MyOverTrack"] = new List<TrackMove>();
                }
                return (List<TrackMove>)ViewState["MyOverTrack"];
            }
            set { ViewState["MyOverTrack"] = value; }
        }
        public List<TrackMove> MyOverTrack1
        {
            get
            {
                if (ViewState["MyOverTrack1"] == null)
                {
                    ViewState["MyOverTrack1"] = new List<TrackMove>();
                }
                return (List<TrackMove>)ViewState["MyOverTrack1"];
            }
            set { ViewState["MyOverTrack1"] = value; }
        }
        public List<TrackMove> MyOverTrack2
        {
            get
            {
                if (ViewState["MyOverTrack2"] == null)
                {
                    ViewState["MyOverTrack2"] = new List<TrackMove>();
                }
                return (List<TrackMove>)ViewState["MyOverTrack2"];
            }
            set { ViewState["MyOverTrack2"] = value; }
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
                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "الصفحة الرئيسية";

                    if (Request.QueryString["AreaNo"] != null)
                    {
                        ((HiddenField)this.Master.FindControl("MyArea")).Value = Request.QueryString["AreaNo"].ToString(); ;
                        AreaNo = Request.QueryString["AreaNo"].ToString(); ;
                        CostCenter myCost = new CostCenter();
                        myCost.Branch = 1;
                        myCost.Code = Request.QueryString["AreaNo"].ToString();
                        myCost = myCost.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myCost != null) SiteInfo = myCost;
                    }
                    else
                    {
                        ((HiddenField)this.Master.FindControl("MyArea")).Value = Session["AreaNo"].ToString();
                        AreaNo = Session["AreaNo"].ToString();
                        SiteInfo = (CostCenter)Session["SiteInfo"];
                    }

                    if (Request.QueryString["StoreNo"] != null) StoreNo = Request.QueryString["StoreNo"].ToString();
                    else StoreNo = Session["StoreNo"].ToString();

                    if ((bool)Session["DispMessage"])
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(
                        "أهلا وسهلا بك " + Session["FullUser"].ToString() + " في نظام الناقلات البرية", false, false), true);
                        Session.Add("DispMessage", false);
                    }
                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans2(Session["CurrentUser"].ToString(), "الرئيسية", "اختيار", "تم عرض الصفحة الرئيسية", "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString, Session["myLat"].ToString(), Session["myLng"].ToString());

                    SEmp myEmp = new SEmp();
                    myEmp.UserName = Session["CurrentUser"].ToString();
                    int? EmpNo = 0;
                    EmpNo = myEmp.FindByUserName(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (EmpNo != null && EmpNo > 0)
                    {
                        string vResult = "";
                        bool done = false;
                        vResult += @"$.sticky('<i style=""color:Red;"" class=""fa fa-exclamation-triangle  fa-lg fa-fw""></i></br><table dir=""rtl"" class=""responstable""><tr><td>اليوم</td><td>الحضور</td><td>الانصراف</td></tr>";
                        AttLog mytime = new AttLog();
                        mytime.EmpCode = (int)EmpNo;
                        mytime.FDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        foreach (AttLog itm in mytime.GetByEmpMonth(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            done = true;
                            vResult += @"<tr><td>" + moh.MakeMask(DateTime.Parse(itm.FDate).Day.ToString(), 2) + " " + itm.FDate2.Split(' ')[0] + @"</td><td>" +
                                //(itm.StartLate == 0 ? "" : itm.StartLate == 1 ? @"<font color=""orange"">" : @"<font color=""red"">") + itm.STime +
                                //(itm.StartLate == 0 ? "" : itm.StartLate == 1 ? @"</font>" : @"</font>") 
                                itm.STime2 + @"</td><td>" +
                                //(itm.EndLate == 0 ? "" : itm.EndLate == 1 ? @"<font color=""orange"">" : @"<font color=""red"">") + itm.ETime +
                                //(itm.StartLate == 0 ? "" : itm.StartLate == 1 ? @"</font>" : @"</font>") 
                                itm.ETime2
                                + @"</td></tr>";
                        }

                        if (vResult != "" && done)
                        {
                            vResult += @"</table>');";
                            vResult = @"$(function() {" + vResult + @" return false; }); ";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), vResult, true);
                        }
                    }

                   // DisplayCounter();

                    if (DateTime.DaysInMonth(moh.Nows().Year, moh.Nows().Month) == moh.Nows().Day)
                    {
                        try
                        {
                            moh.PActiveCars(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                        catch { }

                        try
                        {
                            moh.PActiveCars2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                        catch { }

                        try
                        {
                            moh.PActiveEmps(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                        catch { }
                    }

                    if ((((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("الحسابات") || ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("admin")))
                    {
                        string vResult = "";
                        RJv myRjv = new RJv();
                        List<string> ls = new List<string>();
                        ls = myRjv.GetActive(String.Format("{0:dd/MM/yyyy}", moh.Nows()), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (ls != null && ls.Count() > 0)
                        {
                            Jv myJv = new Jv();
                            myJv.Branch = 1;
                            myJv.FType = 100;
                            myJv.LocType = 1;
                            myJv.LocNumber = 1;
                            int? i = myJv.GetNewNumber(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (i == 0 || i == null)
                            {
                                i = 1;
                            }
                            else
                            {
                                i++;
                            }

                            myRjv = new RJv();
                            int r = myRjv.SetActive(String.Format("{0:dd/MM/yyyy}", moh.Nows()), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            for (int ii = (int)i; ii < r; ii++)
                            {
                                vResult += @"$.sticky('<i style=""color:Red;"" class=""fa fa-exclamation-triangle  fa-lg fa-fw""></i><a target=""_blank"" href=""WebJVou.aspx?AreaNo=" + AreaNo + @"&StoreNo=" + StoreNo + @"&FNum=" + ii.ToString() + @""">" + ii.ToString() + @"</a> تم تنفيذ القيد " + @"' ); ";
                            }
                        }


                        if (vResult != "")
                        {
                            vResult = @"$(function() {" + vResult + @" return false; }); ";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), vResult, true);
                        }
                    }
                }
                else
                {
                    if (AutoRefresh) ChkAutoUpdate.Checked = true;
                }
            }
            catch
            {
            }
        }
       
        public void DisplayCounter()
        {

            try
            {
                Cars myCar = new Cars();
                myCar.Branch = 1;
                DateTime dt = HDate.Ch_Date(HDate.getNow());
                int rt = 0;
                grdCarAlert.DataSource = (from itm in myCar.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                          where ((string.IsNullOrEmpty(itm.PHDate1) || HDate.Ch_Date(itm.PHDate1).AddDays(-30) < dt) ||
                                                 (string.IsNullOrEmpty(itm.PHDate2) || HDate.Ch_Date(itm.PHDate2).AddDays(-30) < dt) ||
                                                 (string.IsNullOrEmpty(itm.PHDate3) || HDate.Ch_Date(itm.PHDate3).AddDays(-30) < dt) ||
                                                 (string.IsNullOrEmpty(itm.PHDate4) || HDate.Ch_Date(itm.PHDate4).AddDays(-30) < dt) ||
                                                 (string.IsNullOrEmpty(itm.PHDate5) || HDate.Ch_Date(itm.PHDate5).AddDays(-30) < dt))
                                          orderby itm.Code
                                          select new Cars
                                          {
                                              WorkShopCode = (++rt).ToString(),
                                              Code = itm.Code,
                                              PlateNo = itm.PlateNo,
                                              PHDate1 = moh.GetPic(1, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString),
                                              PHDate2 = moh.GetPic(2, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString),
                                              PHDate3 = moh.GetPic(3, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString),
                                              PHDate4 = moh.GetPic(4, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString),
                                              PLoc1 = itm.PLoc1,
                                              PLoc2 = itm.PLoc2,
                                              PLoc3 = itm.PLoc3,
                                              PLoc4 = itm.PLoc4,
                                              PLoc5 = itm.PLoc5,
                                              PLoc = itm.PLoc,
                                              strDate1 = (string.IsNullOrEmpty(itm.PHDate1) ? "المستند غير مدرج" :
                                                          HDate.Ch_Date(itm.PHDate1) <= dt ? @"<a href='" + moh.GetPic(1, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + "منتهي من " + dt.Subtract(HDate.Ch_Date(itm.PHDate1)).Days.ToString() + " يوم" + @"</a>" :
                                                          HDate.Ch_Date(itm.PHDate1).AddDays(-30) <= dt ? "ينتهي خلال " + HDate.Ch_Date(itm.PHDate1).Subtract(dt).Days.ToString() + " يوم" + @"</a>" : @"<a href='" + moh.GetPic(1, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>"),
                                              strDate2 = (string.IsNullOrEmpty(itm.PHDate2) ? "المستند غير مدرج" :
                                                          HDate.Ch_Date(itm.PHDate2) <= dt ? @"<a href='" + moh.GetPic(2, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + "منتهي من " + dt.Subtract(HDate.Ch_Date(itm.PHDate2)).Days.ToString() + " يوم" + @"</a>" :
                                                          HDate.Ch_Date(itm.PHDate2).AddDays(-30) <= dt ? "ينتهي خلال " + HDate.Ch_Date(itm.PHDate2).Subtract(dt).Days.ToString() + " يوم" + @"</a>" : @"<a href='" + moh.GetPic(2, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>"),
                                              strDate3 = (string.IsNullOrEmpty(itm.PHDate3) ? "المستند غير مدرج" :
                                                          HDate.Ch_Date(itm.PHDate3) <= dt ? @"<a href='" + moh.GetPic(3, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + "منتهي من " + dt.Subtract(HDate.Ch_Date(itm.PHDate3)).Days.ToString() + " يوم" + @"</a>" :
                                                          HDate.Ch_Date(itm.PHDate3).AddDays(-30) <= dt ? "ينتهي خلال " + HDate.Ch_Date(itm.PHDate3).Subtract(dt).Days.ToString() + " يوم" + @"</a>" : @"<a href='" + moh.GetPic(3, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>"),
                                              strDate4 = (string.IsNullOrEmpty(itm.PHDate4) ? "المستند غير مدرج" :
                                                          HDate.Ch_Date(itm.PHDate4) <= dt ? @"<a href='" + moh.GetPic(4, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + "منتهي من " + dt.Subtract(HDate.Ch_Date(itm.PHDate4)).Days.ToString() + " يوم" + @"</a>" :
                                                          HDate.Ch_Date(itm.PHDate4).AddDays(-30) <= dt ? "ينتهي خلال " + HDate.Ch_Date(itm.PHDate4).Subtract(dt).Days.ToString() + " يوم" + @"</a>" : @"<a href='" + moh.GetPic(4, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>"),
                                              strDate5 = (string.IsNullOrEmpty(itm.PHDate5) ? "المستند غير مدرج" :
                                                          HDate.Ch_Date(itm.PHDate5) <= dt ? "منتهي من " + dt.Subtract(HDate.Ch_Date(itm.PHDate5)).Days.ToString() + " يوم" :
                                                          HDate.Ch_Date(itm.PHDate5).AddDays(-30) <= dt ? "ينتهي خلال " + HDate.Ch_Date(itm.PHDate5).Subtract(dt).Days.ToString() + " يوم" : @"<img src='images/accept.png'/>")
                                          }).ToList();
                grdCarAlert.DataBind();
                if (((List<Cars>)grdCarAlert.DataSource).Count > 0)
                {
                    int i1 = 0, i2 = 0, i3 = 0, i4 = 0, i5 = 0;
                    foreach (Cars itm in (List<Cars>)grdCarAlert.DataSource)
                    {
                        if (itm.strDate1.Contains("مستند") || itm.strDate1.Contains("نتهي")) i1++;
                        if (itm.strDate2.Contains("مستند") || itm.strDate2.Contains("نتهي")) i2++;
                        if (itm.strDate3.Contains("مستند") || itm.strDate3.Contains("نتهي")) i3++;
                        if (itm.strDate4.Contains("مستند") || itm.strDate4.Contains("نتهي")) i4++;
                        if (itm.strDate5.Contains("مستند") || itm.strDate5.Contains("نتهي")) i5++;
                    }

                    if (i1 > 0) grdCarAlert.HeaderRow.Cells[3].Text += "   [" + i1.ToString() + "]";
                    if (i2 > 0) grdCarAlert.HeaderRow.Cells[4].Text += "   [" + i2.ToString() + "]";
                    if (i3 > 0) grdCarAlert.HeaderRow.Cells[5].Text += "   [" + i3.ToString() + "]";
                    if (i4 > 0) grdCarAlert.HeaderRow.Cells[6].Text += "   [" + i4.ToString() + "]";
                    if (i5 > 0) grdCarAlert.HeaderRow.Cells[7].Text += "   [" + i5.ToString() + "]";
                }
            }
            catch
            {

            }

            try
            {
                Cars myCar = new Cars();
                myCar.Branch = 1;
                DateTime dt = HDate.Ch_Date(HDate.getNow());
                int rt = 0;
                grdCarAlert2.DataSource = (from itm in myCar.GetAllPlate(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                           where ((string.IsNullOrEmpty(itm.PHDate1) || HDate.Ch_Date(itm.PHDate1).AddDays(-30) < dt) ||
                                                 (string.IsNullOrEmpty(itm.PHDate2) || HDate.Ch_Date(itm.PHDate2).AddDays(-30) < dt) ||
                                                 (string.IsNullOrEmpty(itm.PHDate3) || HDate.Ch_Date(itm.PHDate3).AddDays(-30) < dt) ||
                                                 (string.IsNullOrEmpty(itm.PHDate4) || HDate.Ch_Date(itm.PHDate4).AddDays(-30) < dt) ||
                                                 (string.IsNullOrEmpty(itm.PHDate5) || HDate.Ch_Date(itm.PHDate5).AddDays(-30) < dt))
                                          orderby itm.Code
                                          select new Cars
                                          {
                                              WorkShopCode = (++rt).ToString(),
                                              Code = itm.Code,
                                              PlateNo = itm.PlateNo,
                                              PHDate1 = moh.GetPic(1, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString),
                                              PHDate2 = moh.GetPic(2, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString),
                                              PHDate3 = moh.GetPic(3, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString),
                                              PHDate4 = moh.GetPic(4, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString),
                                              PLoc1 = itm.PLoc1,
                                              PLoc2 = itm.PLoc2,
                                              PLoc3 = itm.PLoc3,
                                              PLoc4 = itm.PLoc4,
                                              PLoc5 = itm.PLoc5,
                                              PLoc = itm.PLoc,
                                              strDate1 = (string.IsNullOrEmpty(itm.PHDate1) ? "المستند غير مدرج" :
                                                          HDate.Ch_Date(itm.PHDate1) <= dt ? @"<a href='" + moh.GetPic(1, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + "منتهي من " + dt.Subtract(HDate.Ch_Date(itm.PHDate1)).Days.ToString() + " يوم" + @"</a>" :
                                                          HDate.Ch_Date(itm.PHDate1).AddDays(-30) <= dt ? "ينتهي خلال " + HDate.Ch_Date(itm.PHDate1).Subtract(dt).Days.ToString() + " يوم" + @"</a>" : @"<a href='" + moh.GetPic(1, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>"),
                                              strDate2 = (string.IsNullOrEmpty(itm.PHDate2) ? "المستند غير مدرج" :
                                                          HDate.Ch_Date(itm.PHDate2) <= dt ? @"<a href='" + moh.GetPic(2, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + "منتهي من " + dt.Subtract(HDate.Ch_Date(itm.PHDate2)).Days.ToString() + " يوم" + @"</a>" :
                                                          HDate.Ch_Date(itm.PHDate2).AddDays(-30) <= dt ? "ينتهي خلال " + HDate.Ch_Date(itm.PHDate2).Subtract(dt).Days.ToString() + " يوم" + @"</a>" : @"<a href='" + moh.GetPic(2, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>"),
//                                              strDate3 = (string.IsNullOrEmpty(itm.PHDate3) ? "المستند غير مدرج" :
                                              //                                                          HDate.Ch_Date(itm.PHDate3) <= dt ? @"<a href='" + moh.GetPic(3, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + "منتهي من " + dt.Subtract(HDate.Ch_Date(itm.PHDate3)).Days.ToString() + " يوم" + @"</a>" :
//                                                          HDate.Ch_Date(itm.PHDate3).AddDays(-30) <= dt ? "ينتهي خلال " + HDate.Ch_Date(itm.PHDate3).Subtract(dt).Days.ToString() + " يوم" + @"</a>" : @"<a href='" + moh.GetPic(3, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>"),
                                              strDate4 = (string.IsNullOrEmpty(itm.PHDate4) ? "المستند غير مدرج" :
                                                          HDate.Ch_Date(itm.PHDate4) <= dt ? @"<a href='" + moh.GetPic(4, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + "منتهي من " + dt.Subtract(HDate.Ch_Date(itm.PHDate4)).Days.ToString() + " يوم" + @"</a>" :
                                                          HDate.Ch_Date(itm.PHDate4).AddDays(-30) <= dt ? "ينتهي خلال " + HDate.Ch_Date(itm.PHDate4).Subtract(dt).Days.ToString() + " يوم" + @"</a>" : @"<a href='" + moh.GetPic(4, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>")
//                                              strDate5 = (string.IsNullOrEmpty(itm.PHDate5) ? "المستند غير مدرج" :
//                                                          HDate.Ch_Date(itm.PHDate5) <= dt ? "منتهي من " + dt.Subtract(HDate.Ch_Date(itm.PHDate5)).Days.ToString() + " يوم" :
//                                                          HDate.Ch_Date(itm.PHDate5).AddDays(-30) <= dt ? "ينتهي خلال " + HDate.Ch_Date(itm.PHDate5).Subtract(dt).Days.ToString() + " يوم" : @"<img src='images/accept.png'/>")
                                          }).ToList();
                grdCarAlert2.DataBind();

                if (((List<Cars>)grdCarAlert2.DataSource).Count > 0)
                {
                    int i1 = 0, i2 = 0,  i4 = 0;
                    foreach (Cars itm in (List<Cars>)grdCarAlert2.DataSource)
                    {
                        if (itm.strDate1.Contains("مستند") || itm.strDate1.Contains("نتهي")) i1++;
                        if (itm.strDate2.Contains("مستند") || itm.strDate2.Contains("نتهي")) i2++;
                        if (itm.strDate4.Contains("مستند") || itm.strDate4.Contains("نتهي")) i4++;
                    }

                    if (i1 > 0) grdCarAlert2.HeaderRow.Cells[3].Text += "   [" + i1.ToString() + "]";
                    if (i2 > 0) grdCarAlert2.HeaderRow.Cells[4].Text += "   [" + i2.ToString() + "]";
                    if (i4 > 0) grdCarAlert2.HeaderRow.Cells[5].Text += "   [" + i4.ToString() + "]";
                }
            }
            catch
            {

            }

            try
            {
                SEmp myEmp = new SEmp();
                DateTime dt = HDate.Ch_Date(HDate.getNow());
                int rt = 0;
                grdPaperAlert.DataSource = (from itm in myEmp.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                           where (
                                                  (string.IsNullOrEmpty(itm.ExpDate1) || HDate.Ch_Date(itm.ExpDate1).AddDays(-30) < dt))
                                                  //|| (string.IsNullOrEmpty(itm.ExpDate2))) // || HDate.Ch_Date(itm.PHDate2).AddDays(-30) < dt))
                                           orderby itm.EmpCode
                                           select new CostCenter
                                           {
                                               InvNo = ++rt,
                                               Code = itm.EmpCode.ToString(),
                                               Name1 = itm.Name,
                                               SiteAcc = (string.IsNullOrEmpty(itm.FileName1) ? "المستند غير مدرج" :
                                                           !string.IsNullOrEmpty(itm.ExpDate1) && HDate.Ch_Date(itm.ExpDate1) <= dt ? @"<a href='" + @"/Arch/" + itm.FileName1 + @"' target='_blank'>" + "منتهي من " + dt.Subtract(HDate.Ch_Date(itm.ExpDate1)).Days.ToString() + " يوم" + @"</a>" :
                                                           !string.IsNullOrEmpty(itm.ExpDate1) && HDate.Ch_Date(itm.ExpDate1).AddDays(-30) <= dt ? "ينتهي خلال " + HDate.Ch_Date(itm.ExpDate1).Subtract(dt).Days.ToString() + " يوم" + @"</a>" : @"<a href='" + @"/Arch/" + itm.FileName1 + "' target='_blank' ><img src='images/accept.png'/></a>"),
                                               TripAcc = (string.IsNullOrEmpty(itm.FileName2) ? "المستند غير مدرج" : @"<img src='images/accept.png'/>")                                               
                                           }).ToList();
                grdPaperAlert.DataBind();

                if (((List<CostCenter>)grdPaperAlert.DataSource).Count > 0)
                {
                    int i1 = 0, i2 = 0;
                    foreach (CostCenter itm in (List<CostCenter>)grdPaperAlert.DataSource)
                    {
                        if (itm.SiteAcc.Contains("مستند") || itm.SiteAcc.Contains("نتهي")) i1++;
                        if (itm.TripAcc.Contains("مستند") || itm.TripAcc.Contains("نتهي")) i2++;
                    }

                    if (i1 > 0) grdPaperAlert.HeaderRow.Cells[3].Text += "   [" + i1.ToString() + "]";
                    if (i2 > 0) grdPaperAlert.HeaderRow.Cells[4].Text += "   [" + i2.ToString() + "]";
                }
            }
            catch
            {

            }


            try
            {
                CostCenter myCostCenter = new CostCenter();
                myCostCenter.Branch = 1;
                BulletedList1.DataTextField = "Name1";
                BulletedList1.DataValueField = "Name2";
                BulletedList1.DataSource = (from itm in myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                            where CheckItem(itm.Code)
                                            select new CostCenter { Name1 = itm.Name1, Name2 = "default.aspx?AreaNo=" + itm.Code + "&StoreNo=" + StoreNo }).ToList();
                BulletedList1.DataBind();
            }
            catch
            {

            }

            List<CarMove> lmove = new List<CarMove>();
            CarMove vCarMove = new CarMove();
            lmove = vCarMove.NotCarMoveRCV(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

            /*
            try
            {
                List<CostCenter> lcost = new List<CostCenter>();
                Cars myCar = new Cars();
                myCar.Branch = 1;
                myCar.CarsType = 1;
                bllCars.DataTextField = "Name1";
                bllCars.DataValueField = "Name2";
                lcost = (from itm in myCar.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                            select new CostCenter { Name1 = itm.PlateNo + "   "  + itm.Code, Name2 = "", City=itm.Code }).ToList();
                bllCars.DataSource = lcost;
                bllCars.DataBind();
                int i = 0;
                foreach (ListItem itm in bllCars.Items)
                {
                    bool vFound = false;
                    foreach (CarMove sitm in lmove)
                    {
                        if (sitm.CarCode == lcost[i].City)
                        {
                            vFound = true;
                            itm.Attributes.Add("style", "color:Red");
                            itm.Attributes.Add("title", moh.StrToInt(sitm.VouLoc).ToString() + "/" + sitm.Number.ToString());                            
                            break;
                        }
                    }
                    i++;
                }
                lblCars.Text = " [ " + lcost.Count().ToString() + " حالة الشاحنات ] ";
            }
            catch
            {

            }
             */

            try
            {
                List<CostCenter> lcost = new List<CostCenter>();
                List<Drivers> lDrive = new List<Drivers>();
                Drivers myDrive = new Drivers();
                myDrive.Branch = 1;
                lDrive = myDrive.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                bllDrivers.DataTextField = "Name1";
                bllDrivers.DataValueField = "Name2";

                Cars myCar = new Cars();
                myCar.Branch = 1;
                myCar.CarsType = 1;
                lcost = (from itm in myCar.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                         select new CostCenter { Name1 = itm.PlateNo + "  " + (from sitm in lDrive
                                                                               where itm.DriverCode == sitm.Code
                                                                               select sitm.Name1).FirstOrDefault(), Name2 = "", City = itm.Code }).ToList();





                //lcost = (from itm in myDrive.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                //                                    where (bool)itm.Status
                //                      select new CostCenter { Name1 = itm.Name1, Name2 = "" , City=itm.Code }).ToList();

                bllDrivers.DataSource = lcost;
                bllDrivers.DataBind();
                int i = 0;
                foreach (ListItem itm in bllDrivers.Items)
                {
                    foreach (CarMove sitm in lmove)
                    {
                        if (sitm.DriverCode == lcost[i].City)
                        {
                            itm.Attributes.Add("style", "color:Blue");
                            itm.Attributes.Add("title", moh.StrToInt(sitm.VouLoc).ToString() + "/" + sitm.Number.ToString() + " " + sitm.ToLoc);
                            break;
                        }
                    }
                    i++;
                }
                bllDrivers.Text = " [ " + lcost.Count().ToString() + " حالة الشاحنات  ] ";

            }
            catch
            {

            }

            try
            {
                CostCenter myCostCenter = new CostCenter();
                myCostCenter.Branch = 1;
                BulletedList1.DataTextField = "Name1";
                BulletedList1.DataValueField = "Name2";
                BulletedList1.DataSource = (from itm in myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                            where CheckItem(itm.Code)
                                            select new CostCenter { Name1 = itm.Name1, Name2 = "default.aspx?AreaNo=" + itm.Code + "&StoreNo=" + StoreNo }).ToList();
                BulletedList1.DataBind();
            }
            catch
            {

            }

            vRoleName = moh.GetCurrentRole(AreaNo, Session["CurrentUser"].ToString(), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (Session[vRoleName] == null)
            {
                Response.Redirect("WebNotPrev.aspx", false);
                return;
            }


            DispBalDiv(vRoleName);
            //string vRo = ((List<TblRoles>)(Session[vRoleName]))[1].RoleName;

            List<CostCenter> mydata = new List<CostCenter>();

            try
            {                
                PReq myPo1 = new PReq();
                myPo1.Branch = 1;
                myPo1.VouLoc = 0;
                if ((bool)((List<TblRoles>)(Session[vRoleName]))[2].Pass1 || (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass343)
                {
                    mydata = (from itm in myPo1.NotApproved(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString)
                              select new CostCenter
                              {
                                  Name1 = string.Format("{0}  {1}", "P.Request", itm.VouNo.ToString() + "/" + itm.VouLoc.ToString())
                                  ,
                                  Name2 = (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass343 ? "WebPurchaseRequest.aspx?AreaNo=" + AreaNo + "&StoreNo=" + itm.VouLoc.ToString() + "&FNum=" + itm.VouNo.ToString() + "&FMode=1" : "WebPurchaseRequest.aspx?AreaNo=" + AreaNo + "&StoreNo=" + itm.VouLoc.ToString() + "&FNum=" + itm.VouNo.ToString()
                                  ,
                                  PayNo = 0
                              }).ToList();
                }
            }
            catch
            {


            }

            try
            {
                MyPO myPo = new MyPO();
                myPo.Branch = 1;
                if ((bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass34) myPo.LocNumber = 0;
                else myPo.LocNumber = short.Parse(AreaNo);
                bllPO.DataTextField = "Name1";
                bllPO.DataValueField = "Name2";

                mydata.AddRange((from itm in myPo.NotApproved(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                 where (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass34 ? itm.FType == 1 || itm.FType == 2 || itm.FType == 3 || itm.FType == 4 || itm.FType == 5 || itm.FType == 6 : itm.FType < 3 && itm.LocNumber != 0
                                 select new CostCenter
                                 {
                                     Name1 = string.Format("{0}  {1} # {2}",
                                     itm.FType == 1 || itm.FType == 3 || itm.FType == 5 ? "شراء رقم " : "دفع رقم ", itm.LocNumber.ToString() + "/" + itm.Number.ToString(), itm.FType == 1 || itm.FType == 2 ? (itm.LocNumber != 0 ? "فرع" : "إدارة") : (itm.FType == 3 || itm.FType == 4) ? "صيانة" : "ش.إدارية")
                                     ,
                                     Name2 =
                                     itm.FType == 1 || itm.FType == 3 || itm.FType == 5 ?
                                                           itm.LocNumber == 0 ? "WebPPO.aspx?Flag=0&FType=" + itm.FType.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0" :
                                                             "WebPPO.aspx?FType=" + itm.FType.ToString() + "&AreaNo=" + moh.MakeMask(itm.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0"
                                                    :
                                                            itm.LocNumber == 0 ? "WebPPO1.aspx?FType=" + itm.FType.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0" :
                                                            "WebPPO1.aspx?FType=" + itm.FType.ToString() + "&AreaNo=" + moh.MakeMask(itm.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0"
                                     ,
                                     CrLimit = 0,
                                     PayNo = 999
                                 }).ToList());
            }
            catch
            {

            }

            if (((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("مدير الصيانة") || ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("مدير الورشة"))
            {
                try
                {
                    STS mySts = new STS();
                    mydata.AddRange((from itm in mySts.GetNotAgree(1, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     select new CostCenter
                                     {
                                         Name1 = string.Format("صرف بضاعة رقم {0}", itm.VouLoc.ToString() + "/" + itm.VouNo.ToString())
                                        ,
                                         Name2 = "WebIssueNote.aspx?Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType=1"
                                     }).ToList());
                }
                catch
                {

                }


                try
                {
                    FastRepair myFast = new FastRepair();
                    mydata.AddRange((from itm in myFast.GetNotAgree(1,WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     select new CostCenter
                                     {
                                         Name1 = string.Format("أصلاح رقم {0}",(itm.LocType == 3 ? "00" : "")+ itm.VouLoc.ToString() + "/" +  itm.VouNo.ToString())
                                        ,
                                         Name2 = itm.LocType == 2 ? "WebFastRepair.aspx?Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType2=1" :
                                         "WebFastRepair.aspx?FType=1&Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType2=1"
                                         ,
                                         CrLimit = itm.Am1 + itm.Am2 + itm.Am3 + itm.Am4 + itm.Am5 + itm.Am6 + itm.Am7 + itm.Am8 + itm.Am9 + itm.Am10 + itm.Am11 + itm.Am12 + itm.Am13 + itm.Am14 + itm.Am15 + itm.Am16 + itm.Am17 + itm.Am18 + itm.Am19 + itm.Am20 + itm.Am21 + itm.Am22 + itm.Am23 + itm.Am24 + itm.Am25 + itm.Am26 + itm.Am27 + itm.Am28 + itm.Am29 + itm.Am30 + itm.Am31 + itm.Am32,
                                         PayNo = 999
                                     }).ToList());
                }
                catch
                {

                }
            }

            try
            {
                if (((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("مدير الحسابات") || ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("admin"))
                {
                    List<MyPO> lpo = new List<MyPO>();
                    MyPO myPo = new MyPO();
                    myPo.Branch = 1;
                    if ((bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass34) myPo.LocNumber = 0;
                    else myPo.LocNumber = short.Parse(AreaNo);
                    bllPO.DataTextField = "Name1";
                    bllPO.DataValueField = "Name2";
                    lpo = myPo.NotPaid(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    mydata.AddRange((from itm in lpo
                                     where (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass34  //? itm.FType == 1 || itm.FType == 2 || itm.FType == 3 || itm.FType == 4 : itm.FType < 3 && itm.LocNumber != 0
                                     select new CostCenter
                                     {
                                         Name1 = string.Format("{0}  {1} # {2}",
                                         itm.FType == 1 || itm.FType == 3 || itm.FType == 5 ? "شراء رقم " : "دفع رقم ", itm.LocNumber.ToString() + "/" + itm.Number.ToString(), itm.FType == 1 || itm.FType == 2 ? (itm.LocNumber != 0 ? "فرع" : "إدارة") : itm.FType == 3 || itm.FType == 4 ? "صيانة" : "ش.إدارية") + @" لم يسدد"
                                         ,
                                         Name2 =
                                         itm.FType == 1 || itm.FType == 3 || itm.FType == 5 ?
                                                               itm.LocNumber == 0 ? "WebPPO.aspx?Flag=0&FType=" + itm.FType.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0" :
                                                                 "WebPPO.aspx?FType=" + itm.FType.ToString() + "&AreaNo=" + moh.MakeMask(itm.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0"
                                                        :
                                                                itm.LocNumber == 0 ? "WebPPO1.aspx?FType=" + itm.FType.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0" :
                                                                "WebPPO1.aspx?FType=" + itm.FType.ToString() + "&AreaNo=" + moh.MakeMask(itm.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0"
                                        ,
                                         CrLimit = itm.Price,
                                         PayNo = 999
                                     }).ToList());
                }
            }
            catch
            {

            }



            //try
            //{
            //    eServices myService = new eServices();
            //    mydata.AddRange((from itm in myService.GetActive(Session["CurrentUser"].ToString(),vRoleName, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
            //                     select new CostCenter
            //                     {
            //                         Name1 = string.Format("{0} رقم {1}",itm.Name2, itm.DocNo.ToString())
            //                        ,
            //                         Name2 = itm.FormName + "?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.DocNo.ToString() + "&FLevel=" + ((int)itm.Status + 1).ToString()
            //                     }).ToList());
            //}
            //catch
            //{

            //}



            if (((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("مدير الحسابات") || Session["CurrentUser"].ToString().ToUpper() == "ADMIN1")
            {
                try
                {
                    Jv myJv = new Jv();
                    myJv.FType = 100;
                    myJv.LocType = -1;
                    mydata.AddRange((from itm in myJv.GetNotAgree(1, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     select new CostCenter
                                     {
                                         Name1 = string.Format("قيد يومية رقم {0}", itm.Number.ToString())
                                        ,
                                         Name2 = "WebJVou.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0&FType=1"
                                     }).ToList());
                }
                catch
                {

                }


                try
                {
                    Jv myJv = new Jv();
                    myJv.LocType = -1;
                    myJv.FType = 106;
                    mydata.AddRange((from itm in myJv.GetNotAgree(1, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     select new CostCenter
                                     {
                                         Name1 = string.Format("تحويل بنكي رقم {0}", itm.Number.ToString())
                                        ,
                                         Name2 = "WebBankTrans.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0&FType=1"
                                     }).ToList());
                }
                catch
                {

                }


                try
                {
                    Jv myJv = new Jv();
                    myJv.LocType = 1;
                    myJv.FType = 102;
                    mydata.AddRange((from itm in myJv.GetNotAgree(1, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     select new CostCenter
                                     {
                                         Name1 = string.Format("صرف شيكات رقم {0}", itm.Number.ToString())
                                        ,
                                         Name2 = "WebPay12.aspx?FType=2&Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0&FType0=1"
                                     }).ToList());
                }
                catch
                {

                }
            }

            if (Session["CurrentUser"].ToString().ToUpper() == "ADMIN")
            {
                try
                {
                    Jv myJv = new Jv();
                    myJv.FType = 100;
                    myJv.LocType = -1;
                    mydata.AddRange((from itm in myJv.GetNotAgree(2, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     select new CostCenter
                                     {
                                         Name1 = string.Format("قيد يومية رقم {0}", itm.Number.ToString())
                                        ,
                                         Name2 = "WebJVou.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0&FType=2"
                                     }).ToList());
                }
                catch
                {

                }


                try
                {
                    Jv myJv = new Jv();
                    myJv.LocType = -1;
                    myJv.FType = 106;
                    mydata.AddRange((from itm in myJv.GetNotAgree(2, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     select new CostCenter
                                     {
                                         Name1 = string.Format("تحويل بنكي رقم {0}", itm.Number.ToString())
                                        ,
                                         Name2 = "WebBankTrans.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0&FType=2"
                                     }).ToList());
                }
                catch
                {

                }


                try
                {
                    Jv myJv = new Jv();
                    myJv.LocType = 1;
                    myJv.FType = 102;
                    mydata.AddRange((from itm in myJv.GetNotAgree(2, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     select new CostCenter
                                     {
                                         Name1 = string.Format("صرف شيكات رقم {0}", itm.Number.ToString())
                                        ,
                                         Name2 = "WebPay12.aspx?FType=2&Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0&FType0=2"
                                     }).ToList());
                }
                catch
                {

                }
            }

            if (((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("الحسابات"))
            {
                try
                {
                    STS mySts = new STS();
                    mydata.AddRange((from itm in mySts.GetNotAgree(2, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     select new CostCenter
                                     {
                                         Name1 = string.Format("صرف بضاعة رقم {0}", itm.VouLoc.ToString() + "/" + itm.VouNo.ToString())
                                        ,
                                         Name2 = "WebIssueNote.aspx?Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType=2"
                                     }).ToList());
                }
                catch
                {

                }

                try
                {
                    FastRepair myFast = new FastRepair();
                    mydata.AddRange((from itm in myFast.GetNotAgree(2, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     select new CostCenter
                                     {
                                         Name1 = string.Format("أصلاح رقم {0}", (itm.LocType == 3 ? "00" : "") + itm.VouLoc.ToString() + "/" + itm.VouNo.ToString())
                                        ,
                                         Name2 = itm.LocType == 2 ? "WebFastRepair.aspx?Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType2=2" :
                                         "WebFastRepair.aspx?FType=1&Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType2=2"
                                         ,
                                         CrLimit = itm.Am1 + itm.Am2 + itm.Am3 + itm.Am4 + itm.Am5 + itm.Am6 + itm.Am7 + itm.Am8 + itm.Am9 + itm.Am10 + itm.Am11 + itm.Am12 + itm.Am13 + itm.Am14 + itm.Am15 + itm.Am16 + itm.Am17 + itm.Am18 + itm.Am19 + itm.Am20 + itm.Am21 + itm.Am22 + itm.Am23 + itm.Am24 + itm.Am25 + itm.Am26 + itm.Am27 + itm.Am28 + itm.Am29 + itm.Am30 + itm.Am31 + itm.Am32,
                                         PayNo = 999
                                     }).ToList());
                }
                catch
                {

                }


            }
            else if (!((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("admin"))
            {
                try
                {
                    Claim cl = new Claim();
                    cl.DocLoc = (((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("مدير التشغيل") ? (short)-1 : short.Parse(AreaNo));
                    mydata.AddRange((from itm in cl.GetPending(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     orderby itm.DocNo
                                     select new CostCenter
                                     {
                                         Name1 = string.Format("{0}  {1} # {2}", "مطالبة", itm.DocNo.ToString(), itm.CustName.Substring(0, itm.CustName.Length < 15 ? itm.CustName.Length : 15)),
                                         Name2 = "WebClaim.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.DocNo.ToString(),
                                         CrLimit = itm.amount,
                                         PayNo = 0,
                                         City = itm.CustName
                                     }).ToList());
                }
                catch
                {

                }
            }

            bllPO.DataSource = mydata;
            bllPO.DataBind();


            try
            {
                int i = 0;
                foreach (ListItem itm in bllPO.Items)
                {
                    if (mydata[i].CrLimit != 0)
                    {
                        if (mydata[i].PayNo == 0) itm.Attributes.Add("title", string.Format("{0} {1:N2}", mydata[i].City, mydata[i].CrLimit));
                        else itm.Attributes.Add("title", string.Format("{0:N2}", mydata[i].CrLimit));
                    }
                    i++;
                }

                double? s = mydata.Where(p => p.PayNo == 999).Sum(p => p.CrLimit);
                Label2.Text = " [ " + (s > 0 ? string.Format("{0:N0}", s) : "") + " طلبات معلقة ] ";
            }
            catch
            {

            }

            LoadInvData();

            ProcessDiv.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass01;
            if ((bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass01) ProcessTrackMove();

            DivAccBal.Visible = false;
            if (((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("الحسابات") || ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("admin") || ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("مدير التشغيل"))
            {
                DivAccBal.Visible = true;
                List<CostCenter> lcost = new List<CostCenter>();
                try
                {
                    Acc myAcc0 = new Acc();
                    myAcc0.Branch = 1;
                    myAcc0.FCode = "120101";
                    DivBanks.Visible = !((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("مدير التشغيل");
                    DivVendors.Visible = !((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("مدير التشغيل");
                    DivVendors1.Visible = !((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("مدير التشغيل");
                    DivVendors2.Visible = !((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("مدير التشغيل");
                    DivVendors3.Visible = !((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("مدير التشغيل");
                    if (DivBanks.Visible)
                    {
                        bllBank.DataTextField = "Name1";
                        bllBank.DataValueField = "Name2";
                        lcost = (from itm in myAcc0.GetAllAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                 select new CostCenter { Code = itm.Code, Name1 = itm.Name1.Remove(0, 5) + " " + string.Format("{0:N0}", itm.Bal), City = itm.Name1 + " " + string.Format("{0:N2}", itm.Bal), Name2 = itm.Name2, Location = GetLastTran2(itm.Code, itm.Bal, itm.Name1), CrLimit = itm.Bal }).ToList();
                        bllBank.DataSource = lcost;
                        bllBank.DataBind();
                        LblBanks.Text = " [ " + string.Format("{0:N0}", lcost.Sum(p => p.CrLimit)) + " البنوك ] ";
                        int i = 0;
                        foreach (ListItem itm in bllBank.Items)
                        {
                            if (lcost[i].CrLimit < 0) itm.Attributes.Add("style", "color:Red");
                            itm.Attributes.Add("data-title", lcost[i].Location);
                            itm.Attributes.Add("title", lcost[i].City);
                            itm.Attributes.Add("id", lcost[i].Code);
                            i++;
                        }
                    }
                }
                catch
                {

                }

                try
                {
                    Acc myAcc0 = new Acc();
                    myAcc0.Branch = 1;
                    myAcc0.FCode = "120102";
                    bllCash.DataTextField = "Name1";
                    bllCash.DataValueField = "Name2";
                    lcost = (from itm in myAcc0.GetAllAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                             select new CostCenter
                             {
                                 Code = itm.Code,
                                 Name1 = itm.Name1.Remove(0, 6) + " " + string.Format("{0:N0}", itm.Bal),
                                 City = itm.Name1 + " " + string.Format("{0:N2}", itm.Bal),
                                 Name2 = itm.Name2,
                                 Location = GetLastTran2(itm.Code, itm.Bal, itm.Name1),
                                 CrLimit = itm.Bal
                             }).ToList();
                    bllCash.DataSource = lcost;
                    bllCash.DataBind();
                    Label8.Text = " [ " + string.Format("{0:N0}", lcost.Sum(p => p.CrLimit)) + " النقدية ] ";
                    int i = 0;
                    foreach (ListItem itm in bllCash.Items)
                    {
                        if (lcost[i].CrLimit < 0) itm.Attributes.Add("style", "color:Red");
                        itm.Attributes.Add("title", lcost[i].City);
                        itm.Attributes.Add("data-title", lcost[i].Location);
                        itm.Attributes.Add("id", lcost[i].Code);
                        double loan = 0;
                        loan = moh.GetLoanBal(lcost[i].Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (loan > 0) loan = 0;
                        if ((lcost[i].CrLimit + loan) > 5000) itm.Attributes.Add("style", "color:Blue");
                        i++;
                    }
                }
                catch
                {

                }

                try
                {
                    Acc myAcc0 = new Acc();
                    myAcc0.Branch = 1;
                    myAcc0.FCode = "120103";
                    BllLoans.DataTextField = "Name1";
                    BllLoans.DataValueField = "Name2";
                    lcost = (from itm in myAcc0.GetAllAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                             select new CostCenter { Code = itm.Code, Name1 = itm.Name1.Remove(0, 13) + " " + string.Format("{0:N0}", itm.Bal), City = itm.Name1 + " " + string.Format("{0:N2}", itm.Bal), Name2 = itm.Name2, Location = GetLastTran2(itm.Code, itm.Bal, itm.Name1), CrLimit = itm.Bal }).ToList();
                    BllLoans.DataSource = lcost;
                    BllLoans.DataBind();
                    Label9.Text = " [ " + string.Format("{0:N0}", lcost.Sum(p => p.CrLimit)) + " العهد ] ";
                    int i = 0;
                    foreach (ListItem itm in BllLoans.Items)
                    {
                        if (lcost[i].CrLimit < 0) itm.Attributes.Add("style", "color:Red");
                        itm.Attributes.Add("title", lcost[i].City);
                        itm.Attributes.Add("data-title", lcost[i].Location);
                        itm.Attributes.Add("id", lcost[i].Code);
                        i++;
                    }
                }
                catch
                {

                }


                try
                {
                    Acc myAcc0 = new Acc();
                    myAcc0.Branch = 1;
                    myAcc0.FCode = "120301";

                    bllCustomers.DataTextField = "Name1";
                    bllCustomers.DataValueField = "Name2";
                    lcost = (from itm in myAcc0.GetAllAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                             where itm.Bal != 0
                             select new CostCenter { Code = itm.Code, Name1 = itm.Name1 + "\n" + string.Format("{0:N0}", itm.Bal), City = itm.Name1 + "\n" + string.Format("{0:N2}", itm.Bal), Name2 = itm.Name2, Location = GetLastTran2(itm.Code, itm.Bal, itm.Name1), CrLimit = itm.Bal }).ToList();
                    bllCustomers.DataSource = lcost;
                    bllCustomers.DataBind();
                    Label22.Text = " [ " + string.Format("{0:N0}", lcost.Sum(p => p.CrLimit)) + " العملاء ] ";
                    int i = 0;
                    foreach (ListItem itm in bllCustomers.Items)
                    {
                        if (lcost[i].CrLimit < 0) itm.Attributes.Add("style", "color:Red");
                        itm.Attributes.Add("title", lcost[i].City);
                        itm.Attributes.Add("data-title", lcost[i].Location);
                        itm.Attributes.Add("id", lcost[i].Code);
                        i++;
                    }
                }
                catch
                {

                }

            }

            if (DivVendors.Visible)
            {
                try
                {
                    List<CostCenter> lcost = new List<CostCenter>();
                    Acc myAcc0 = new Acc();
                    myAcc0.Branch = 1;
                    myAcc0.FCode = "220401";

                    BllVendors.DataTextField = "Name1";
                    BllVendors.DataValueField = "Name2";
                    lcost = (from itm in myAcc0.GetAllAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                             where itm.Bal != 0
                             select new CostCenter { Code = itm.Code, Name1 = itm.Name1 + "\n" + string.Format("{0:N0}", itm.Bal), City = itm.Name1 + "\n" + string.Format("{0:N2}", itm.Bal), Name2 = itm.Name2, Location = GetLastTran2(itm.Code, itm.Bal, itm.Name1), CrLimit = itm.Bal }).ToList();
                    BllVendors.DataSource = lcost;
                    BllVendors.DataBind();
                    Label7.Text = " [ " + string.Format("{0:N0}", lcost.Sum(p => p.CrLimit)) + " الموردين ] ";
                    int i = 0;
                    foreach (ListItem itm in BllVendors.Items)
                    {
                        if (lcost[i].CrLimit > 0) itm.Attributes.Add("style", "color:Red");
                        itm.Attributes.Add("data-title", lcost[i].Location);
                        itm.Attributes.Add("title", lcost[i].City);
                        itm.Attributes.Add("id", lcost[i].Code);
                        i++;
                    }
                }
                catch
                {

                }

            }

            if (DivVendors1.Visible)
            {
                try
                {
                    List<CostCenter> lcost = new List<CostCenter>();
                    Claim cl = new Claim();
                    cl.DocLoc = -1;
                    lcost = (from itm in cl.GetPending(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                             orderby itm.DocNo
                             select new CostCenter
                             {
                                 Name1 = string.Format("{0}  {1} # {2}", "مطالبة", itm.DocNo.ToString(), itm.CustName.Substring(0, itm.CustName.Length < 15 ? itm.CustName.Length : 15)),
                                 Name2 = "WebClaim.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.DocNo.ToString(),
                                 CrLimit = itm.amount,
                                 PayNo = 0,
                                 City = itm.CustName
                             }).ToList();
                    bllVendors1.DataTextField = "Name1";
                    bllVendors1.DataValueField = "Name2";
                    bllVendors1.DataSource = lcost;
                    bllVendors1.DataBind();
                    int i = 0;
                    foreach (ListItem itm in bllVendors1.Items)
                    {
                        //itm.Attributes.Add("data-title", "");
                        itm.Attributes.Add("title", lcost[i].City + " " + string.Format("{0:N0}", lcost[i].CrLimit));
                        itm.Attributes.Add("id", lcost[i].Code);
                        i++;
                    }
                    Label10.Text = " [ " + string.Format("{0:N0}", lcost.Sum(p => p.CrLimit)) + " مطالبات معلقه ] ";
                }
                catch
                {

                }
            }

           if (DivVendors2.Visible)
            {
                try
                {
                    List<CostCenter> lcost = new List<CostCenter>();
                    Acc myAcc0 = new Acc();
                    myAcc0.Branch = 1;
                    myAcc0.FCode = "240101";

                    bllVendors2.DataTextField = "Name1";
                    bllVendors2.DataValueField = "Name2";
                    lcost = (from itm in myAcc0.GetAllAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                             where itm.Bal != 0
                             select new CostCenter { Code = itm.Code, Name1 = itm.Name1 + "\n" + string.Format("{0:N0}", itm.Bal), City = itm.Name1 + "\n" + string.Format("{0:N2}", itm.Bal), Name2 = itm.Name2, Location = GetLastTran2(itm.Code, itm.Bal, itm.Name1), CrLimit = itm.Bal }).ToList();

                    myAcc0 = new Acc();
                    myAcc0.Branch = 1;
                    myAcc0.FCode = "240102";
                    lcost.AddRange((from itm in myAcc0.GetAllAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                    where itm.Bal != 0
                                    select new CostCenter { Code = itm.Code, Name1 = itm.Name1 + "\n" + string.Format("{0:N0}", itm.Bal), City = itm.Name1 + "\n" + string.Format("{0:N2}", itm.Bal), Name2 = itm.Name2, Location = GetLastTran2(itm.Code, itm.Bal, itm.Name1), CrLimit = itm.Bal }).ToList());


                    myAcc0 = new Acc();
                    myAcc0.Branch = 1;
                    myAcc0.FCode = "240103";
                    lcost.AddRange((from itm in myAcc0.GetAllAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                             where itm.Bal != 0
                             select new CostCenter { Code = itm.Code, Name1 = itm.Name1 + "\n" + string.Format("{0:N0}", itm.Bal), City = itm.Name1 + "\n" + string.Format("{0:N2}", itm.Bal), Name2 = itm.Name2, Location = GetLastTran2(itm.Code, itm.Bal, itm.Name1), CrLimit = itm.Bal }).ToList());

                    myAcc0 = new Acc();
                    myAcc0.Branch = 1;
                    myAcc0.FCode = "240104";
                    lcost.AddRange((from itm in myAcc0.GetAllAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                    where itm.Bal != 0
                                    select new CostCenter { Code = itm.Code, Name1 = itm.Name1 + "\n" + string.Format("{0:N0}", itm.Bal), City = itm.Name1 + "\n" + string.Format("{0:N2}", itm.Bal), Name2 = itm.Name2, Location = GetLastTran2(itm.Code, itm.Bal, itm.Name1), CrLimit = itm.Bal }).ToList());


                    bllVendors2.DataSource = lcost;
                    bllVendors2.DataBind();
                    int i = 0;
                    foreach (ListItem itm in bllVendors2.Items)
                    {
                        itm.Attributes.Add("data-title", lcost[i].Location);
                        itm.Attributes.Add("title", lcost[i].City);
                        itm.Attributes.Add("id", lcost[i].Code);
                        i++;
                    }
                    Label11.Text = " [ " + string.Format("{0:N0}", lcost.Sum(p => p.CrLimit)) + " مصروفات مستحقة ] ";
                }
                catch
                {

                }
            }

            if (DivVendors3.Visible)
            {
                try
                {
                    List<CostCenter> lcost = new List<CostCenter>();
                    Acc myAcc0 = new Acc();
                    myAcc0.Branch = 1;
                    myAcc0.FCode = "240501";

                    bllVendors3.DataTextField = "Name1";
                    bllVendors3.DataValueField = "Name2";
                    lcost = (from itm in myAcc0.GetAllAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                             where itm.Bal != 0
                             select new CostCenter { Code = itm.Code, Name1 = itm.Name1 + "\n" + string.Format("{0:N0}", itm.Bal), City = itm.Name1 + "\n" + string.Format("{0:N2}", itm.Bal), Name2 = itm.Name2, Location = GetLastTran2(itm.Code, itm.Bal, itm.Name1), CrLimit = itm.Bal }).ToList();
                    bllVendors3.DataSource = lcost;
                    bllVendors3.DataBind();
                    int i = 0;
                    foreach (ListItem itm in bllVendors3.Items)
                    {
                        itm.Attributes.Add("data-title", lcost[i].Location);
                        itm.Attributes.Add("title", lcost[i].City);
                        itm.Attributes.Add("id", lcost[i].Code);
                        i++;
                    }
                    Label12.Text = " [ " + string.Format("{0:N0}", lcost.Sum(p => p.CrLimit)) + " أقساط مستحقة ] ";
                }
                catch
                {

                }

                lblTime.Text = "تم التحديث بتاريخ " + moh.Nows().ToString();
            }
        }

        public void LoadInvData()
        {
            List<CostCenter> mydata2 = new List<CostCenter>();
            try
            {
                InvOnLine InvNet = new InvOnLine();
                InvNet.Branch = 1;
                InvNet.VouLoc = "00000";
                InvNet.Site = AreaNo;
                mydata2 = (from itm in InvNet.GetAll(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString)
                           select new CostCenter
                           {
                               InvNo = itm.VouNo,
                               Area = itm.VouLoc
                               ,
                               Name1 = string.Format("{0}  {1}", itm.VouNo.ToString(), itm.GDate.ToString())
                               ,
                               Name2 = "WebInvoice.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FMode=99" + "&FNum=" + itm.VouNo.ToString()
                           }).ToList();
                //grdInv.DataSource = mydata2;
                //grdInv.DataBind();
                //string vRole = moh.GetCurrentRole(AreaNo, Session["CurrentUser"].ToString(), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                //if (Session["CurrentUser"].ToString().ToLower().Contains("admin") || Session["CurrentUser"].ToString().ToLower().Contains("eid"))
                //{

                //}
                //else
                //{
                //    for (int i = 0; i < grdInv.Rows.Count; i++)
                //    {
                //        ImageButton btnDelete = grdInv.Rows[i].FindControl("btnDelete") as ImageButton;
                //        btnDelete.Visible = false;
                //    }
                //}
            }
            catch
            {

            }


            try
            {
                ShipOnLine InvNet = new ShipOnLine();
                mydata2.AddRange((from itm in InvNet.GetAll(AreaNo,WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString)
                           select new CostCenter
                           {
                               InvNo = itm.VouNo,
                               Area = itm.VouLoc
                               ,
                               Name1 = string.Format("E{0}  {1}", itm.VouNo.ToString(), itm.GDate.ToString())
                               ,
                               Name2 = "WebShipment.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FMode=99" + "&FNum=" + itm.VouNo.ToString()
                           }).ToList());
                grdInv.DataSource = mydata2;
                grdInv.DataBind();
                string vRole = moh.GetCurrentRole(AreaNo, Session["CurrentUser"].ToString(), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (Session["CurrentUser"].ToString().ToLower().Contains("admin") || Session["CurrentUser"].ToString().ToLower().Contains("eid"))
                {

                }
                else
                {
                    for (int i = 0; i < grdInv.Rows.Count; i++)
                    {
                        ImageButton btnDelete = grdInv.Rows[i].FindControl("btnDelete") as ImageButton;
                        btnDelete.Visible = false;
                    }
                }
            }
            catch
            {

            }
        }

        public Boolean CheckItem(string BranCode)
        {
            TblUsers ax = new TblUsers();
            ax.UserName = Session["CurrentUser"].ToString();
            ax = ax.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (ax != null)
            {
                bool vRes = false;
                if (ax.MainBran == BranCode) return true;
                if (ax.Branchs != "")
                {
                    string[] k = ax.Branchs.Split(';');
                    foreach (string m in k)
                    {
                        if (m == BranCode)
                        {
                            vRes = true;
                            break;
                        }
                    }
                }
                return vRes;
            }
            else return false;
        }

        public void DispBalDiv(string vRoleName)
        {
            try
            {
                lblCash.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass011;
                lblCashs.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass011;

                lblLoan.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass012;
                lblLoans.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass012;

                lblIncome.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass013;
                lblIncomes.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass013;

                lblMonthIncome.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass014;
                lblMonthIncomes.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass014;

                lblDayIncome.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass015;
                lblDayIncomes.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass015;

                CostCenter myCost2 = new CostCenter();
                myCost2.Branch = 1;
                myCost2.Code = AreaNo;
                myCost2 = myCost2.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                Acc myAcc = new Acc();
                if (lblCash.Visible)
                {
                    myAcc.Branch = 1;
                    myAcc.Code = myCost2.CashAcc;
                    if (myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        lblCash.Text = string.Format("{0:N0}", myAcc.Bal);
                    }
                }

                myAcc = new Acc();
                if (lblLoan.Visible)
                {
                    myAcc.Branch = 1;
                    myAcc.Code = myCost2.LoanAcc;
                    if (myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        lblLoan.Text = string.Format("{0:N0}", myAcc.Bal);
                        if (moh.StrToDouble(lblLoan.Text) < 0) lblLoan.ForeColor = System.Drawing.Color.Red;
                    }
                }

                Jv myJv = new Jv();
                if (lblIncome.Visible || lblMonthIncome.Visible || lblDayIncome.Visible)
                {
                    double bal = 0, bal2 = 0, MonthBal = 0;
                    myJv.Branch = 1;

                    foreach (vJv itm in myJv.GetStatement(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, true, "01/01/2012", "01/01/2012", "41", "-1", AreaNo, "-1", "-1", "-1", "-1", "-1"))
                    {
                        if (DateTime.Parse(itm.FDate).Month == moh.Nows().Month && DateTime.Parse(itm.FDate).Year == moh.Nows().Year)
                        {
                            if (itm.DbCode != "") MonthBal = MonthBal + (double)itm.Amount;
                            else MonthBal = MonthBal - (double)itm.Amount;
                        }

                        if (itm.FDate == String.Format("{0:dd/MM/yyyy}", moh.Nows()))
                        {
                            if (itm.DbCode != "") bal2 = bal2 + (double)itm.Amount;
                            else bal2 = bal2 - (double)itm.Amount;

                        }
                        if (DateTime.Parse(itm.FDate).Year == moh.Nows().Year)
                        {
                            if (itm.DbCode != "") bal = bal + (double)itm.Amount;
                            else bal = bal - (double)itm.Amount;
                        }
                    }
                    lblIncome.Text = string.Format("{0:N0}", bal * -1);
                    lblDayIncome.Text = string.Format("{0:N0}", bal2 * -1);
                    lblMonthIncome.Text = string.Format("{0:N0}", MonthBal * -1);
                }
                lblSMSBal.Text = sms.GetBalance().Split('/')[1] + " رسالة";
            }
            catch
            {

            }
        }


        protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtSearch.Text != "")
                {
                    List<CarStatus> myStatus = new List<CarStatus>();
                    switch (int.Parse(RdoActive.SelectedValue))
                    {
                        case 1:
                            {
                                if (ddlFType.SelectedIndex == 0)
                                {
                                    Invoice vInv = new Invoice();
                                    vInv.RecMobileNo = txtSearch.Text;
                                    foreach (Invoice mInv in vInv.GetByRecMobileNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        if (mInv != null) GetDetails(short.Parse(mInv.VouLoc).ToString() + "/" + mInv.VouNo.ToString(), myStatus, 0, "", "");
                                    }
                                }
                                else if (ddlFType.SelectedIndex == 1)
                                {
                                    Invoice vInv = new Invoice();
                                    vInv.MobileNo = txtSearch.Text;
                                    foreach (Invoice mInv in vInv.GetByMobileNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        if (mInv != null) GetDetails(short.Parse(mInv.VouLoc).ToString() + "/" + mInv.VouNo.ToString(), myStatus, 0, "", "");
                                    }
                                }
                                else if (ddlFType.SelectedIndex == 2)
                                {
                                    Invoice vInv = new Invoice();
                                    vInv.IDNo = txtSearch.Text;
                                    foreach (Invoice mInv in vInv.GetByIDNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        if (mInv != null) GetDetails(short.Parse(mInv.VouLoc).ToString() + "/" + mInv.VouNo.ToString(), myStatus, 0, "", "");
                                    }
                                }
                                else if (ddlFType.SelectedIndex == 3)
                                {
                                    GetDetails(txtSearch.Text, myStatus, 0, "", "");
                                }
                                else if (ddlFType.SelectedIndex == 4)
                                {
                                    InvDetails sinv = new InvDetails();
                                    sinv.Branch = 1;
                                    sinv.PlateNo = txtSearch.Text;
                                    foreach (InvDetails myDetails in sinv.GetByPlateNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        if (myDetails != null) GetDetails(short.Parse(myDetails.VouLoc).ToString() + "/" + myDetails.VouNo.ToString(), myStatus, 1, sinv.PlateNo, "");
                                    }
                                }
                                else if (ddlFType.SelectedIndex == 5)
                                {
                                    InvDetails sinv = new InvDetails();
                                    sinv.Branch = 1;
                                    sinv.ChassisNo = txtSearch.Text;
                                    foreach (InvDetails myDetails in sinv.GetByChassisNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        if (myDetails != null) GetDetails(short.Parse(myDetails.VouLoc).ToString() + "/" + myDetails.VouNo.ToString(), myStatus, 2, "", sinv.ChassisNo);
                                    }
                                }
                                else if (ddlFType.SelectedIndex == 6)
                                {
                                    Invoice vInv = new Invoice();
                                    vInv.Name = txtSearch.Text;
                                    foreach (Invoice mInv in vInv.GetByName(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        if (mInv != null) GetDetails(short.Parse(mInv.VouLoc).ToString() + "/" + mInv.VouNo.ToString(), myStatus, 0, "", "");
                                    }
                                }
                                else if (ddlFType.SelectedIndex == 7)
                                {
                                    Invoice vInv = new Invoice();
                                    vInv.RecName = txtSearch.Text;
                                    foreach (Invoice mInv in vInv.GetByRecName(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        if (mInv != null) GetDetails(short.Parse(mInv.VouLoc).ToString() + "/" + mInv.VouNo.ToString(), myStatus, 0, "", "");
                                    }
                                }
                                break;
                            }
                        case 2:
                            {
                                if (ddlFType.SelectedIndex == 0)
                                {
                                    LShipment vInv = new LShipment();
                                    vInv.RecMobileNo = txtSearch.Text;
                                    foreach (LShipment mInv in vInv.GetByRecMobileNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        if (mInv != null) LShipmentGetDetails(short.Parse(mInv.VouLoc).ToString() + "/" + mInv.VouNo.ToString(), myStatus, 0);
                                    }
                                }
                                else if (ddlFType.SelectedIndex == 1)
                                {
                                    LShipment vInv = new LShipment();
                                    vInv.MobileNo = txtSearch.Text;
                                    foreach (LShipment mInv in vInv.GetByMobileNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        if (mInv != null) LShipmentGetDetails(short.Parse(mInv.VouLoc).ToString() + "/" + mInv.VouNo.ToString(), myStatus, 0);
                                    }
                                }
                                else if (ddlFType.SelectedIndex == 2)
                                {
                                    LShipment vInv = new LShipment();
                                    vInv.IDNo = txtSearch.Text;
                                    foreach (LShipment mInv in vInv.GetByIDNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        if (mInv != null) LShipmentGetDetails(short.Parse(mInv.VouLoc).ToString() + "/" + mInv.VouNo.ToString(), myStatus, 0);
                                    }
                                }
                                else if (ddlFType.SelectedIndex == 3)
                                {
                                    LShipmentGetDetails(txtSearch.Text, myStatus, 0);
                                }
                                else if (ddlFType.SelectedIndex == 4)
                                {
                                    LShipment vInv = new LShipment();
                                    vInv.Name = txtSearch.Text;
                                    foreach (LShipment mInv in vInv.GetByName(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        if (mInv != null) LShipmentGetDetails(short.Parse(mInv.VouLoc).ToString() + "/" + mInv.VouNo.ToString(), myStatus, 0);
                                    }
                                }
                                else if (ddlFType.SelectedIndex == 5)
                                {
                                    LShipment vInv = new LShipment();
                                    vInv.RecName = txtSearch.Text;
                                    foreach (LShipment mInv in vInv.GetByRecName(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        if (mInv != null) LShipmentGetDetails(short.Parse(mInv.VouLoc).ToString() + "/" + mInv.VouNo.ToString(), myStatus,0);
                                    }
                                }
                                break;
                            }
                        case 3:
                            {
                                if (ddlFType.SelectedIndex == 0)
                                {
                                    Shipment vInv = new Shipment();
                                    vInv.RecMobileNo = txtSearch.Text;
                                    foreach (Shipment mInv in vInv.GetByRecMobileNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        if (mInv != null) ShipmentGetDetails(short.Parse(mInv.VouLoc).ToString() + "/" + mInv.VouNo.ToString(), myStatus, 0);
                                    }

                                }
                                else if (ddlFType.SelectedIndex == 1)
                                {
                                    Shipment vInv = new Shipment();
                                    vInv.MobileNo = txtSearch.Text;
                                    foreach (Shipment mInv in vInv.GetByMobileNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        if (mInv != null) ShipmentGetDetails(short.Parse(mInv.VouLoc).ToString() + "/" + mInv.VouNo.ToString(), myStatus, 0);
                                    }
                                }
                                else if (ddlFType.SelectedIndex == 2)
                                {
                                    Shipment vInv = new Shipment();
                                    vInv.IDNo = txtSearch.Text;
                                    foreach (Shipment mInv in vInv.GetByIDNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        if (mInv != null) ShipmentGetDetails(short.Parse(mInv.VouLoc).ToString() + "/" + mInv.VouNo.ToString(), myStatus, 0);
                                    }
                                }
                                else if (ddlFType.SelectedIndex == 3)
                                {
                                    ShipmentGetDetails(txtSearch.Text, myStatus, 0);
                                }
                                else if (ddlFType.SelectedIndex == 4)
                                {
                                    Shipment vInv = new Shipment();
                                    vInv.Name = txtSearch.Text;
                                    foreach (Shipment mInv in vInv.GetByName(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        if (mInv != null) ShipmentGetDetails(short.Parse(mInv.VouLoc).ToString() + "/" + mInv.VouNo.ToString(), myStatus, 0);
                                    }
                                }
                                else if (ddlFType.SelectedIndex == 5)
                                {
                                    Shipment vInv = new Shipment();
                                    vInv.RecName = txtSearch.Text;
                                    foreach (Shipment mInv in vInv.GetByRecName(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        if (mInv != null) ShipmentGetDetails(short.Parse(mInv.VouLoc).ToString() + "/" + mInv.VouNo.ToString(), myStatus, 0);
                                    }
                                }
                                break;
                            }
                    }

                    grdCodes.DataSource = myStatus.OrderByDescending(p => DateTime.Parse(p.TranDate));
                    grdCodes.DataBind();
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        public void GetDetails(string InvNo, List<CarStatus> myStatus,short option , string PlateNo , string ChassisNo)
        {
            Invoice myInv = new Invoice();
            myInv.Branch = 1;
            if (InvNo.Split('/').Count() > 1)
            {
                myInv.VouLoc = moh.MakeMask(InvNo.Split('/')[0], 5);
                myInv.VouNo = int.Parse(InvNo.Split('/')[1]);
            }
            else
            {
                myInv.VouLoc = AreaNo;
                myInv.VouNo = int.Parse(InvNo);
            }
            myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myInv != null)
            {
                if (RdoPeriod.SelectedValue != "0")
                    if (DateTime.Parse(myInv.GDate) < moh.Nows().AddDays(double.Parse(RdoPeriod.SelectedValue) * -1)) return;

                CostCenter myCost = new CostCenter();
                myCost.Branch = 1;
                myCost.Code = myInv.VouLoc;
                myCost = myCost.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                Cities myCity = new Cities();
                myCity.Branch = 1;
                myCity.Code = myInv.PlaceofLoading;
                myCity = myCity.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                Cities myCity2 = new Cities();
                myCity2.Branch = 1;
                myCity2.Code = myInv.Destination;
                myCity2 = myCity2.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                InvDetails sinv = new InvDetails();
                sinv.Branch = myInv.Branch;
                sinv.VouLoc = myInv.VouLoc;
                sinv.VouNo = myInv.VouNo;
                foreach (InvDetails itm in sinv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    if(option == 0 || (option == 1 && itm.PlateNo == PlateNo) || (option == 2 && itm.ChassisNo == ChassisNo))
                    myStatus.Add(new CarStatus
                    {
                        ChassisNo = itm.ChassisNo,
                        DocNumber = @"<a target='_blank' href='WebInvoice.aspx?Support=1&FNum=" + itm.VouNo.ToString() + "&AreaNo=" + itm.VouLoc + "&StoreNo=" + StoreNo + "&Flag=0'>فاتورة " + int.Parse(itm.VouLoc).ToString() + "/" + itm.VouNo.ToString() + @"</a>",
                        PlateNo = itm.PlateNo,
                        TranDate = myInv.GDate + " " + myInv.FTime,
                        Area = myCity.Name1 + " - " + myCost.Name1,
                        Remark = "تم الاستلام من العميل " + myInv.Name + Environment.NewLine + " - جهة الوصول " + myCity2.Name1
                    });

                    CarMove vCarMove = new CarMove();
                    vCarMove.Branch = 1;
                    vCarMove.InvoiceNo = itm.VouNo;
                    vCarMove.InvoiceVouLoc = itm.VouLoc;
                    vCarMove.InvoiceFNo = itm.FNo;
                    foreach (CarMove CarMoveitm in vCarMove.GetByInv(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        Cities FromCity = new Cities();
                        FromCity.Branch = 1;
                        FromCity.Code = CarMoveitm.FromLoc;
                        FromCity = FromCity.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        Cities ToCity = new Cities();
                        ToCity.Branch = 1;
                        ToCity.Code = CarMoveitm.ToLoc;
                        ToCity = ToCity.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        Drivers myDrive = new Drivers();
                        myDrive.Branch = 1;
                        myDrive.Code = CarMoveitm.DriverCode;
                        myDrive = myDrive.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        Cars myCar = new Cars();
                        myCar.Branch = 1;
                        myCar.Code = CarMoveitm.CarCode;
                        myCar = myCar.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        CostCenter CarMoveArea = new CostCenter();
                        CarMoveArea.Branch = 1;
                        CarMoveArea.Code = CarMoveitm.VouLoc;
                        CarMoveArea = CarMoveArea.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        if (option == 0 || (option == 1 && itm.PlateNo == PlateNo) || (option == 2 && itm.ChassisNo == ChassisNo))
                        myStatus.Add(new CarStatus
                        {
                            ChassisNo = itm.ChassisNo,
                            DocNumber = @"<a target='_blank' href='WebCarMove.aspx?Support=1&FNum=" + CarMoveitm.Number.ToString() + "&AreaNo=" + CarMoveitm.VouLoc + "&StoreNo=" + StoreNo + "&Flag=0'>بيان ترحيل " + short.Parse(CarMoveitm.VouLoc).ToString() + "/" + CarMoveitm.Number.ToString() + @"</a>",
                            PlateNo = itm.PlateNo,
                            TranDate = CarMoveitm.GDate + " " + CarMoveitm.FTime,
                            Area = FromCity.Name1 + " - " + CarMoveArea.Name1,
                            Remark = (myDrive == null ? (CarMoveitm.RentDriver != null ? "تم تسليم السائق " + CarMoveitm.RentDriver + " على شاحنة مستأجرة " + CarMoveitm.RentPlateNo + " - جهة الوصول " + ToCity.Name1 : "")
                            : "تم تسليم السائق " +  myDrive.Name1 + " على الشاحنة " + myCar.PlateNo + " - جهة الوصول " + ToCity.Name1)
                        });

                        CarMoveRCV vCarMoveRCV = new CarMoveRCV();
                        vCarMoveRCV.Branch = 1;
                        vCarMoveRCV.CarMove = short.Parse(CarMoveitm.VouLoc).ToString() + "/" + CarMoveitm.Number.ToString();
                        vCarMoveRCV = vCarMoveRCV.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (vCarMoveRCV != null)
                        {
                            CostCenter CarMoveRCVArea = new CostCenter();
                            CarMoveRCVArea.Branch = 1;
                            CarMoveRCVArea.Code = moh.MakeMask(vCarMoveRCV.LocNumber.ToString(), 5);
                            CarMoveRCVArea = CarMoveRCVArea.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            if (option == 0 || (option == 1 && itm.PlateNo == PlateNo) || (option == 2 && itm.ChassisNo == ChassisNo))
                            myStatus.Add(new CarStatus
                            {
                                ChassisNo = itm.ChassisNo,
                                DocNumber = @"<a target='_blank' href='WebCarMoveRCV.aspx?Support=1&FNum=" + vCarMoveRCV.Number.ToString() + "&AreaNo=" + moh.MakeMask(vCarMoveRCV.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&Flag=0'>بيان الوصول " + vCarMoveRCV.LocNumber.ToString() + "/" + vCarMoveRCV.Number.ToString() + @"</a>",
                                PlateNo = itm.PlateNo,
                                TranDate = vCarMoveRCV.GDate + " " + vCarMoveRCV.FTime,
                                Area = CarMoveRCVArea.Name1,
                                Remark = CarMoveitm.ToLoc != myInv.Destination ? "تم الوصول الى محطة الترانزيت" : "تم الوصول"
                            });
                        }
                    }
                    CarRcv vCarRcv = new CarRcv();
                    vCarRcv.Branch = 1;
                    vCarRcv.InvNo = int.Parse(itm.VouLoc).ToString() + "/" + itm.VouNo;
                    vCarRcv.InvFNo = itm.FNo;
                    vCarRcv = vCarRcv.GetByInvFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (vCarRcv != null)
                    {
                        CostCenter CarRcvArea = new CostCenter();
                        CarRcvArea.Branch = 1;
                        CarRcvArea.Code = moh.MakeMask(vCarRcv.LocNumber.ToString(), 5);
                        CarRcvArea = CarRcvArea.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        if (option == 0 || (option == 1 && itm.PlateNo == PlateNo) || (option == 2 && itm.ChassisNo == ChassisNo))
                        myStatus.Add(new CarStatus
                        {
                            ChassisNo = itm.ChassisNo,
                            DocNumber = @"<a target='_blank' href='WebCarRCV.aspx?Support=1&FNum=" + vCarRcv.Number.ToString() + "&AreaNo=" + moh.MakeMask(vCarRcv.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&Flag=0'> بيان تسليم " + vCarRcv.LocNumber.ToString() + "/" + vCarRcv.Number.ToString() + @"</a>",
                            PlateNo = itm.PlateNo,
                            TranDate = vCarRcv.GDate + " " + vCarRcv.GTime,
                            Area = CarRcvArea.Name1,
                            Remark = "تم تسليم العميل " + vCarRcv.Customer
                        });
                    }
                }
            }
        }

        public void ShipmentGetDetails(string InvNo, List<CarStatus> myStatus, short option)
        {
            Shipment myInv = new Shipment();
            myInv.Branch = 1;
            if (InvNo.Split('/').Count() > 1)
            {
                myInv.VouLoc = moh.MakeMask(InvNo.Split('/')[0], 5);
                myInv.VouNo = int.Parse(InvNo.Split('/')[1]);
            }
            else
            {
                myInv.VouLoc = AreaNo;
                myInv.VouNo = int.Parse(InvNo);
            }
            myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myInv != null)
            {
                if (RdoPeriod.SelectedValue != "0")
                    if (DateTime.Parse(myInv.GDate) < moh.Nows().AddDays(double.Parse(RdoPeriod.SelectedValue) * -1)) return;

                CostCenter myCost = new CostCenter();
                myCost.Branch = 1;
                myCost.Code = myInv.VouLoc;
                myCost = myCost.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                Cities myCity = new Cities();
                myCity.Branch = 1;
                myCity.Code = myInv.PlaceofLoading;
                myCity = myCity.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                Cities myCity2 = new Cities();
                myCity2.Branch = 1;
                myCity2.Code = myInv.Destination;
                myCity2 = myCity2.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                myStatus.Add(new CarStatus
                {
                    ChassisNo = "",
                    DocNumber = @"<a target='_blank' href='WebShipment.aspx?Support=1&FNum=" + myInv.VouNo.ToString() + "&AreaNo=" + myInv.VouLoc + "&StoreNo=" + StoreNo + "&Flag=0'>فاتورة E" + int.Parse(myInv.VouLoc).ToString() + "/" + myInv.VouNo.ToString() + @"</a>",
                    PlateNo = "طرد",
                    TranDate = myInv.GDate + " " + myInv.FTime,
                    Area = myCity.Name1 + " - " + myCost.Name1,
                    Remark = "تم الاستلام من العميل " + myInv.Name + Environment.NewLine + " - جهة الوصول " + myCity2.Name1
                });

                CarMove vCarMove = new CarMove();
                vCarMove.Branch = 1;
                vCarMove.InvoiceNo = myInv.VouNo;
                vCarMove.InvoiceVouLoc = myInv.VouLoc;
                vCarMove.Flag = "E";
                vCarMove.InvoiceFNo = 1;
                foreach (CarMove CarMoveitm in vCarMove.GetByInv(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    Cities FromCity = new Cities();
                    FromCity.Branch = 1;
                    FromCity.Code = CarMoveitm.FromLoc;
                    FromCity = FromCity.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    Cities ToCity = new Cities();
                    ToCity.Branch = 1;
                    ToCity.Code = CarMoveitm.ToLoc;
                    ToCity = ToCity.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    Drivers myDrive = new Drivers();
                    myDrive.Branch = 1;
                    myDrive.Code = CarMoveitm.DriverCode;
                    myDrive = myDrive.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    Cars myCar = new Cars();
                    myCar.Branch = 1;
                    myCar.Code = CarMoveitm.CarCode;
                    myCar = myCar.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    CostCenter CarMoveArea = new CostCenter();
                    CarMoveArea.Branch = 1;
                    CarMoveArea.Code = CarMoveitm.VouLoc;
                    CarMoveArea = CarMoveArea.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    myStatus.Add(new CarStatus
                    {
                        ChassisNo = "",
                        DocNumber = @"<a target='_blank' href='WebCarMove.aspx?Support=1&FNum=" + CarMoveitm.Number.ToString() + "&AreaNo=" + CarMoveitm.VouLoc + "&StoreNo=" + StoreNo + "&Flag=0'>بيان ترحيل " + short.Parse(CarMoveitm.VouLoc).ToString() + "/" + CarMoveitm.Number.ToString() + @"</a>",
                        PlateNo = "طرد",
                        TranDate = CarMoveitm.GDate + " " + CarMoveitm.FTime,
                        Area = FromCity.Name1 + " - " + CarMoveArea.Name1,
                        Remark = (myDrive == null ? (CarMoveitm.RentDriver != null ? "تم تسليم السائق " + CarMoveitm.RentDriver + " على شاحنة مستأجرة " + CarMoveitm.RentPlateNo + " - جهة الوصول " + ToCity.Name1 : "")
                        : "تم تسليم السائق " + myDrive.Name1 + " على الشاحنة " + myCar.PlateNo + " - جهة الوصول " + ToCity.Name1)
                    });

                    CarMoveRCV vCarMoveRCV = new CarMoveRCV();
                    vCarMoveRCV.Branch = 1;
                    vCarMoveRCV.CarMove = short.Parse(CarMoveitm.VouLoc).ToString() + "/" + CarMoveitm.Number.ToString();
                    vCarMoveRCV = vCarMoveRCV.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (vCarMoveRCV != null)
                    {
                        CostCenter CarMoveRCVArea = new CostCenter();
                        CarMoveRCVArea.Branch = 1;
                        CarMoveRCVArea.Code = moh.MakeMask(vCarMoveRCV.LocNumber.ToString(), 5);
                        CarMoveRCVArea = CarMoveRCVArea.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        myStatus.Add(new CarStatus
                        {
                            ChassisNo = "",
                            DocNumber = @"<a target='_blank' href='WebCarMoveRCV.aspx?Support=1&FNum=" + vCarMoveRCV.Number.ToString() + "&AreaNo=" + moh.MakeMask(vCarMoveRCV.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&Flag=0'>بيان الوصول " + vCarMoveRCV.LocNumber.ToString() + "/" + vCarMoveRCV.Number.ToString() + @"</a>",
                            PlateNo = "طرد",
                            TranDate = vCarMoveRCV.GDate + " " + vCarMoveRCV.FTime,
                            Area = CarMoveRCVArea.Name1,
                            Remark = CarMoveitm.ToLoc != myInv.Destination ? "تم الوصول الى محطة الترانزيت" : "تم الوصول"
                        });
                    }
                }
                CarRcv vCarRcv = new CarRcv();
                vCarRcv.Branch = 1;
                vCarRcv.InvNo = "E"+int.Parse(myInv.VouLoc).ToString() + "/" + myInv.VouNo;
                vCarRcv.InvFNo = 1;
                vCarRcv = vCarRcv.GetByInvFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (vCarRcv != null)
                {
                    CostCenter CarRcvArea = new CostCenter();
                    CarRcvArea.Branch = 1;
                    CarRcvArea.Code = moh.MakeMask(vCarRcv.LocNumber.ToString(), 5);
                    CarRcvArea = CarRcvArea.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    myStatus.Add(new CarStatus
                    {
                        ChassisNo = "",
                        DocNumber = @"<a target='_blank' href='WebCarRCV.aspx?Support=1&FNum=" + vCarRcv.Number.ToString() + "&AreaNo=" + moh.MakeMask(vCarRcv.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&Flag=0'> بيان تسليم " + vCarRcv.LocNumber.ToString() + "/" + vCarRcv.Number.ToString() + @"</a>",
                        PlateNo = "طرد",
                        TranDate = vCarRcv.GDate + " " + vCarRcv.GTime,
                        Area = CarRcvArea.Name1,
                        Remark = "تم تسليم العميل " + vCarRcv.Customer
                    });
                }
            }
        }

        public void LShipmentGetDetails(string InvNo, List<CarStatus> myStatus, short option)
        {
            LShipment myInv = new LShipment();
            myInv.Branch = 1;
            if (InvNo.Split('/').Count() > 1)
            {
                myInv.VouLoc = moh.MakeMask(InvNo.Split('/')[0], 5);
                myInv.VouNo = int.Parse(InvNo.Split('/')[1]);
            }
            else
            {
                myInv.VouLoc = AreaNo;
                myInv.VouNo = int.Parse(InvNo);
            }
            myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myInv != null)
            {
                if (RdoPeriod.SelectedValue != "0")
                    if (DateTime.Parse(myInv.GDate) < moh.Nows().AddDays(double.Parse(RdoPeriod.SelectedValue) * -1)) return;

                CostCenter myCost = new CostCenter();
                myCost.Branch = 1;
                myCost.Code = myInv.VouLoc;
                myCost = myCost.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                Cities myCity = new Cities();
                myCity.Branch = 1;
                myCity.Code = myInv.PlaceofLoading;
                myCity = myCity.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                Cities myCity2 = new Cities();
                myCity2.Branch = 1;
                myCity2.Code = myInv.Destination;
                myCity2 = myCity2.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                ShipDetails sinv = new ShipDetails();
                sinv.Branch = myInv.Branch;
                sinv.VouLoc = myInv.VouLoc;
                sinv.VouNo = myInv.VouNo;
                foreach (ShipDetails itm in sinv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    myStatus.Add(new CarStatus
                    {
                        ChassisNo = itm.Qty.ToString(),
                        DocNumber = @"<a target='_blank' href='WebLShipment.aspx?Support=1&FNum=" + itm.VouNo.ToString() + "&AreaNo=" + itm.VouLoc + "&StoreNo=" + StoreNo + "&Flag=0'>فاتورة " + int.Parse(itm.VouLoc).ToString() + "/" + itm.VouNo.ToString() + @"</a>",
                        PlateNo = itm.Name,
                        TranDate = myInv.GDate + " " + myInv.FTime,
                        Area = myCity.Name1 + " - " + myCost.Name1,
                        Remark = "تم الاستلام من العميل " + myInv.Name + Environment.NewLine + " - جهة الوصول " + myCity2.Name1
                    });

                    CarMove vCarMove = new CarMove();
                    vCarMove.Branch = 1;
                    vCarMove.InvoiceNo = itm.VouNo;
                    vCarMove.InvoiceVouLoc = itm.VouLoc;
                    vCarMove.InvoiceFNo = itm.FNo;
                    foreach (CarMove CarMoveitm in vCarMove.GetByInv(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        Cities FromCity = new Cities();
                        FromCity.Branch = 1;
                        FromCity.Code = CarMoveitm.FromLoc;
                        FromCity = FromCity.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        Cities ToCity = new Cities();
                        ToCity.Branch = 1;
                        ToCity.Code = CarMoveitm.ToLoc;
                        ToCity = ToCity.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        Drivers myDrive = new Drivers();
                        myDrive.Branch = 1;
                        myDrive.Code = CarMoveitm.DriverCode;
                        myDrive = myDrive.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        Cars myCar = new Cars();
                        myCar.Branch = 1;
                        myCar.Code = CarMoveitm.CarCode;
                        myCar = myCar.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        CostCenter CarMoveArea = new CostCenter();
                        CarMoveArea.Branch = 1;
                        CarMoveArea.Code = CarMoveitm.VouLoc;
                        CarMoveArea = CarMoveArea.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        myStatus.Add(new CarStatus
                        {
                            ChassisNo = itm.Qty.ToString(),
                            DocNumber = @"<a target='_blank' href='WebCarMove.aspx?Support=1&FNum=" + CarMoveitm.Number.ToString() + "&AreaNo=" + CarMoveitm.VouLoc + "&StoreNo=" + StoreNo + "&Flag=0'>بيان ترحيل " + short.Parse(CarMoveitm.VouLoc).ToString() + "/" + CarMoveitm.Number.ToString() + @"</a>",
                            PlateNo = itm.Name,
                            TranDate = CarMoveitm.GDate + " " + CarMoveitm.FTime,
                            Area = FromCity.Name1 + " - " + CarMoveArea.Name1,
                            Remark = (myDrive == null ? (CarMoveitm.RentDriver != null ? "تم تسليم السائق " + CarMoveitm.RentDriver + " على شاحنة مستأجرة " + CarMoveitm.RentPlateNo + " - جهة الوصول " + ToCity.Name1 : "")
                            : "تم تسليم السائق " + myDrive.Name1 + " على الشاحنة " + myCar.PlateNo + " - جهة الوصول " + ToCity.Name1)
                        });

                        CarMoveRCV vCarMoveRCV = new CarMoveRCV();
                        vCarMoveRCV.Branch = 1;
                        vCarMoveRCV.CarMove = short.Parse(CarMoveitm.VouLoc).ToString() + "/" + CarMoveitm.Number.ToString();
                        vCarMoveRCV = vCarMoveRCV.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (vCarMoveRCV != null)
                        {
                            CostCenter CarMoveRCVArea = new CostCenter();
                            CarMoveRCVArea.Branch = 1;
                            CarMoveRCVArea.Code = moh.MakeMask(vCarMoveRCV.LocNumber.ToString(), 5);
                            CarMoveRCVArea = CarMoveRCVArea.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            myStatus.Add(new CarStatus
                            {
                                ChassisNo = itm.Qty.ToString(),
                                DocNumber = @"<a target='_blank' href='WebCarMoveRCV.aspx?Support=1&FNum=" + vCarMoveRCV.Number.ToString() + "&AreaNo=" + moh.MakeMask(vCarMoveRCV.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&Flag=0'>بيان الوصول " + vCarMoveRCV.LocNumber.ToString() + "/" + vCarMoveRCV.Number.ToString() + @"</a>",
                                PlateNo = itm.Name,
                                TranDate = vCarMoveRCV.GDate + " " + vCarMoveRCV.FTime,
                                Area = CarMoveRCVArea.Name1,
                                Remark = CarMoveitm.ToLoc != myInv.Destination ? "تم الوصول الى محطة الترانزيت" : "تم الوصول"
                            });
                        }
                    }
                    CarRcv vCarRcv = new CarRcv();
                    vCarRcv.Branch = 1;
                    vCarRcv.InvNo = "L"+ int.Parse(itm.VouLoc).ToString() + "/" + itm.VouNo;
                    vCarRcv.InvFNo = itm.FNo;
                    vCarRcv = vCarRcv.GetByInvFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (vCarRcv != null)
                    {
                        CostCenter CarRcvArea = new CostCenter();
                        CarRcvArea.Branch = 1;
                        CarRcvArea.Code = moh.MakeMask(vCarRcv.LocNumber.ToString(), 5);
                        CarRcvArea = CarRcvArea.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        myStatus.Add(new CarStatus
                        {
                            ChassisNo = itm.Qty.ToString(),
                            DocNumber = @"<a target='_blank' href='WebCarRCV.aspx?Support=1&FNum=" + vCarRcv.Number.ToString() + "&AreaNo=" + moh.MakeMask(vCarRcv.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&Flag=0'> بيان تسليم " + vCarRcv.LocNumber.ToString() + "/" + vCarRcv.Number.ToString() + @"</a>",
                            PlateNo = itm.Name,
                            TranDate = vCarRcv.GDate + " " + vCarRcv.GTime,
                            Area = CarRcvArea.Name1,
                            Remark = "تم تسليم العميل " + vCarRcv.Customer
                        });
                    }
                }
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static void doTally()
        {
            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(HttpContext.Current.Session["CurrentUser"].ToString(), "الرئيسية", "اختيار", "تم اختيار تشغيل نظام مطابقة الأرصدة", "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
            moh.Tally(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString, short.Parse(HttpContext.Current.Session["Branch"].ToString()));
            //ScriptManager.RegisterStartupScript(Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage("لقد تم تشغيل مطابقة الارصدة بنجاح", false, true), true);
        }

 
        public void ProcessTrackMove()
        {
            //try
            //{
            if (HttpRuntime.Cache["OverTrack_" + AreaNo + Session["CNN2"].ToString()] != null)
                {
                    MyOverTrack = (List<TrackMove>)(HttpRuntime.Cache["OverTrack_" + AreaNo + Session["CNN2"].ToString()]);
                    grdTrackMove.DataSource = MyOverTrack;
                    grdTrackMove.DataBind();

                    MyOverTrack2 = (List<TrackMove>)(HttpRuntime.Cache["OverTrack2_" + AreaNo + Session["CNN2"].ToString()]);
                    grdTrackMove2.DataSource = MyOverTrack2;
                    grdTrackMove2.DataBind();

                    MyOverTrack1 = (List<TrackMove>)(HttpRuntime.Cache["OverTrack1_" + AreaNo + Session["CNN2"].ToString()]);
                    grdTrackMove1.DataSource = MyOverTrack1;
                    grdTrackMove1.DataBind();

                }
                else
                {
                    MyOverTrack.Clear();
                    MyOverTrack1.Clear();
                    MyOverTrack2.Clear();
                    List<Drivers> dr = new List<Drivers>();
                    Drivers Drive = new Drivers();
                    Drive.Branch = 1;
                    dr = Drive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    List<Cities> lcity = new List<Cities>();
                    Cities myCity = new Cities();
                    myCity.Branch = 1;
                    lcity = myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    List<Cities> lc = new List<Cities>();
                    Cities mc = new Cities();
                    mc.Branch = 1;
                    lc = mc.GetMySites(AreaNo, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    int i = 1;
                    int i1 = 1;
                    int i2 = 1;
                    Cars myCar = new Cars();
                    myCar.Branch = 1;
                    myCar.CarsType = 1;
                    foreach (Cars itm in myCar.GetAll20(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        if ((bool)itm.Status)
                        {
                            CarMove cm = new CarMove();
                            cm.CarCode = itm.Code;
                            cm = cm.FindLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (cm != null)
                            {
                                if (CheckSite(cm.ToLoc, lc))
                                {
                                    CarPrices myPrice = new CarPrices();
                                    myPrice.Branch = 1;
                                    myPrice.MonthNo = 0;
                                    myPrice.FromCode = cm.FromLoc;
                                    myPrice.toCode = cm.ToLoc;
                                    myPrice.PLevel = "00002";
                                    myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    DateTime DFrom = new DateTime();
                                    double add = 0;
                                    if (myPrice != null && !string.IsNullOrEmpty(myPrice.FTime) && !string.IsNullOrEmpty(cm.FTime))
                                    {
                                        double.TryParse(myPrice.FTime, out add);
                                        DFrom = DateTime.Parse(cm.GDate + " " + cm.FTime.Replace("ص", "AM").Replace("م", "PM"));
                                    }

                                    CarMoveRCV Rcv = new CarMoveRCV();
                                    Rcv.Branch = 1;
                                    Rcv.CarMove = int.Parse(cm.VouLoc).ToString() + "/" + cm.Number.ToString();
                                    Rcv = Rcv.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (Rcv == null)
                                    {
                                        MyOverTrack.Add(new TrackMove
                                        {
                                            FNo = i++,
                                            Code = itm.Code,
                                            PlateNo = itm.PlateNo,
                                            CarMoveNo = int.Parse(cm.VouLoc).ToString() + "/" + cm.Number.ToString(),
                                            CarMoveFTime = cm.FTime,
                                            CarMoveDate = cm.GDate,
                                            CarMoveFrom = cm.FromLoc,
                                            CarMoveFromLoc = (from d in lcity
                                                              where d.Code == cm.FromLoc
                                                              select d.Name1).FirstOrDefault(),
                                            CarMoveTo = cm.ToLoc,
                                            CarMoveToLoc = (from d in lcity
                                                            where d.Code == cm.ToLoc
                                                            select d.Name1).FirstOrDefault(),
                                            Driver = (from d in dr
                                                      where d.Code == cm.DriverCode
                                                      select d.Name1).FirstOrDefault(),
                                            RCVFTime = (myPrice != null && !string.IsNullOrEmpty(myPrice.FTime) && !string.IsNullOrEmpty(cm.FTime) ? DFrom.AddHours(add).ToString() : ""),
                                            RCVFTime2 = (myPrice != null && !string.IsNullOrEmpty(myPrice.FTime) && !string.IsNullOrEmpty(cm.FTime) ? DFrom.AddHours(add).ToShortTimeString() : "")
                                        });


                                        //if (string.IsNullOrEmpty(itm.RCVFTime))
                                        //{
                                        //    itm.Status = " *****في الطريق";
                                        //}
                                        //else if (DateTime.Now > DateTime.Parse(itm.RCVFTime))
                                        //{
                                        //    itm.Status = "تأخرت في الطريق";
                                        //}
                                        //else
                                        //{
                                        //    itm.Status = "في الطريق";
                                        //}
                                    }
                                    else
                                    {
                                        MyOverTrack2.Add(new TrackMove
                                        {
                                            FNo = i2++,
                                            Code = itm.Code,
                                            PlateNo = itm.PlateNo,
                                            CarMoveNo = int.Parse(cm.VouLoc).ToString() + "/" + cm.Number.ToString(),
                                            CarMoveFTime = cm.FTime,
                                            CarMoveDate = cm.GDate,
                                            CarMoveFrom = cm.FromLoc,
                                            CarMoveFromLoc = (from d in lcity
                                                              where d.Code == cm.FromLoc
                                                              select d.Name1).FirstOrDefault(),
                                            CarMoveTo = cm.ToLoc,
                                            CarMoveToLoc = (from d in lcity
                                                            where d.Code == cm.ToLoc
                                                            select d.Name1).FirstOrDefault(),
                                            Driver = (from d in dr
                                                      where d.Code == cm.DriverCode
                                                      select d.Name1).FirstOrDefault(),
                                            CarMoveRCVNo = Rcv.LocNumber.ToString() + "/" + Rcv.Number.ToString(),
                                            CarMoveRCVDate = Rcv.GDate,
                                            CarMoveRCVFTime = Rcv.FTime,
                                            Status = "تم الوصول"
                                        });
                                    }
                                }
                                else if (CheckSite(cm.FromLoc, lc))
                                {
                                    CarMoveRCV Rcv = new CarMoveRCV();
                                    Rcv.Branch = 1;
                                    Rcv.CarMove = int.Parse(cm.VouLoc).ToString() + "/" + cm.Number.ToString();
                                    Rcv = Rcv.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (Rcv == null)
                                    {
                                        MyOverTrack1.Add(new TrackMove
                                        {
                                            FNo = i1++,
                                            Code = itm.Code,
                                            PlateNo = itm.PlateNo,
                                            CarMoveNo = int.Parse(cm.VouLoc).ToString() + "/" + cm.Number.ToString(),
                                            CarMoveFTime = cm.FTime,
                                            CarMoveDate = cm.GDate,
                                            CarMoveFrom = cm.FromLoc,
                                            CarMoveFromLoc = (from d in lcity
                                                              where d.Code == cm.FromLoc
                                                              select d.Name1).FirstOrDefault(),
                                            CarMoveTo = cm.ToLoc,
                                            CarMoveToLoc = (from d in lcity
                                                            where d.Code == cm.ToLoc
                                                            select d.Name1).FirstOrDefault(),
                                            Driver = (from d in dr
                                                      where d.Code == cm.DriverCode
                                                      select d.Name1).FirstOrDefault()
                                        });

                                        //CarPrices myPrice = new CarPrices();
                                        //myPrice.Branch = 1;
                                        //myPrice.MonthNo = 0;
                                        //myPrice.FromCode = cm.FromLoc;
                                        //myPrice.toCode = cm.FromLoc;
                                        //myPrice.PLevel = "00002";
                                        //myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        //if (myPrice != null && !string.IsNullOrEmpty(myPrice.FTime) && !string.IsNullOrEmpty(cm.FTime))
                                        //{
                                        //    double add = 0;
                                        //    double.TryParse(myPrice.FTime, out add);
                                        //    DateTime DFrom = new DateTime();
                                        //    DFrom = DateTime.Parse(cm.GDate + " " + cm.FTime.Replace("ص", "AM").Replace("م", "PM"));
                                        //    itm.RCVFTime = DFrom.AddHours(add).ToString();
                                        //    itm.RCVFTime2 = DFrom.AddHours(add).ToShortTimeString();
                                        //}

                                        //if (string.IsNullOrEmpty(itm.RCVFTime))
                                        //{
                                        //    itm.Status = " *****في الطريق";
                                        //}
                                        //else if (DateTime.Now > DateTime.Parse(itm.RCVFTime))
                                        //{
                                        //    itm.Status = "تأخرت في الطريق";
                                        //}
                                        //else
                                        //{
                                        //    itm.Status = "في الطريق";
                                        //}
                                    }
                                }
                            }
                        }
                    }

                    CarMove mycm = new CarMove();
                    mycm.VouLoc = AreaNo;
                    foreach (CarMove cr in mycm.CarMoveNotRcv(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        if (cr.Rent != null && (bool)cr.Rent)
                        {
                            if (CheckSite(cr.DriverCode, lc))
                            {
                                    CarPrices myPrice = new CarPrices();
                                    myPrice.Branch = 1;
                                    myPrice.MonthNo = 0;
                                    myPrice.FromCode = cr.FromLoc;
                                    myPrice.toCode = cr.DriverCode;
                                    myPrice.PLevel = "00002";
                                    myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    DateTime DFrom = new DateTime();
                                    double add = 0;
                                    if (myPrice != null && !string.IsNullOrEmpty(myPrice.FTime) && !string.IsNullOrEmpty(cr.FTime))
                                    {
                                        double.TryParse(myPrice.FTime, out add);
                                        DFrom = DateTime.Parse(cr.GDate + " " + cr.FTime.Replace("ص", "AM").Replace("م", "PM"));
                                    }

                                    CarMoveRCV Rcv = new CarMoveRCV();
                                    Rcv.Branch = 1;
                                    Rcv.CarMove = int.Parse(cr.VouLoc).ToString() + "/" + cr.Number.ToString();
                                    Rcv = Rcv.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (Rcv == null)
                                    {
                                        MyOverTrack.Add(new TrackMove
                                        {
                                            FNo = i++,
                                            Code = "مستأجرة",
                                            PlateNo = cr.RentPlateNo,
                                            CarMoveNo = int.Parse(cr.VouLoc).ToString() + "/" + cr.Number.ToString(),
                                            CarMoveFTime = cr.FTime,
                                            CarMoveDate = cr.GDate,
                                            CarMoveFrom = cr.FromLoc,
                                            CarMoveFromLoc = (from d in lcity
                                                              where d.Code == cr.FromLoc
                                                              select d.Name1).FirstOrDefault(),
                                            CarMoveTo = cr.DriverCode,
                                            CarMoveToLoc = (from d in lcity
                                                            where d.Code == cr.DriverCode
                                                            select d.Name1).FirstOrDefault(),
                                            Driver = cr.RentDriver + " " + cr.RentValue.ToString() + " ريال ",
                                            RCVFTime = (myPrice != null && !string.IsNullOrEmpty(myPrice.FTime) && !string.IsNullOrEmpty(cr.FTime) ? DFrom.AddHours(add).ToString() : ""),
                                            RCVFTime2 = (myPrice != null && !string.IsNullOrEmpty(myPrice.FTime) && !string.IsNullOrEmpty(cr.FTime) ? DFrom.AddHours(add).ToShortTimeString() : "")
                                        });

                                    }

                            }
                            else if (CheckSite(cr.FromLoc, lc))
                            {
                                MyOverTrack1.Add(new TrackMove
                                {
                                    FNo = i1++,
                                    Code = "مستأجرة",
                                    PlateNo = cr.RentPlateNo,
                                    CarMoveNo = int.Parse(cr.VouLoc).ToString() + "/" + cr.Number.ToString(),
                                    CarMoveFTime = cr.FTime,
                                    CarMoveDate = cr.GDate,
                                    CarMoveFrom = cr.FromLoc,
                                    CarMoveFromLoc = (from d in lcity
                                                      where d.Code == cr.FromLoc
                                                      select d.Name1).FirstOrDefault(),
                                    CarMoveTo = cr.DriverCode,
                                    CarMoveToLoc = (from d in lcity
                                                    where d.Code == cr.DriverCode
                                                    select d.Name1).FirstOrDefault(),
                                    Driver = cr.RentDriver + " " + cr.RentValue.ToString() + " ريال "
                                });
                            }
                        }
                    }

                    try
                    {
                        i = 1;
                        MyOverTrack = MyOverTrack.OrderBy(c => DateTime.Parse(c.RCVFTime)).ToList();
                    }
                    catch
                    { }
                    foreach (TrackMove itm in MyOverTrack)
                    {
                        itm.FNo = i++;
                    }
                    Cache.Insert("OverTrack_" + AreaNo + Session["CNN2"].ToString(), MyOverTrack);
                    grdTrackMove.DataSource = MyOverTrack;
                    grdTrackMove.DataBind();

                    try
                    {
                        i = 1;
                        MyOverTrack2 = MyOverTrack2.OrderByDescending(c => DateTime.Parse(c.CarMoveRCVDate + " " + c.CarMoveRCVFTime.Replace("ص", "AM").Replace("م", "PM"))).ToList();
                    }
                    catch
                    { }
                    foreach (TrackMove itm in MyOverTrack2)
                    {
                        itm.FNo = i++;
                    }
                    Cache.Insert("OverTrack2_" + AreaNo + Session["CNN2"].ToString(), MyOverTrack2);
                    grdTrackMove2.DataSource = MyOverTrack2;
                    grdTrackMove2.DataBind();

                    try
                    {
                        i = 1;
                        MyOverTrack1 = MyOverTrack1.OrderByDescending(c => DateTime.Parse(c.CarMoveDate + " " + c.CarMoveFTime.Replace("ص", "AM").Replace("م", "PM"))).ToList();
                    }
                    catch
                    { }
                    foreach (TrackMove itm in MyOverTrack1)
                    {
                        itm.FNo = i++;
                    }
                    Cache.Insert("OverTrack1_" + AreaNo + Session["CNN2"].ToString(), MyOverTrack1);
                    grdTrackMove1.DataSource = MyOverTrack1;
                    grdTrackMove1.DataBind();
                }

            CostCenter myCostCenter = new CostCenter();
            myCostCenter.Branch = 1;
            ddlBranch.DataTextField = "Name1";
            ddlBranch.DataValueField = "Code";
            ddlBranch.DataSource = myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            ddlBranch.DataBind();
            //ddlBranch.Items.Insert(0, new ListItem("جميع الفروع", "-1", true));            
            ddlBranch.SelectedValue = AreaNo;
            ddlBranch.Enabled = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass421;

            if (HttpRuntime.Cache["OverCarMove_" + AreaNo + Session["CNN2"].ToString()] == null) SetCarMove(AreaNo);

            CarMoveData = (List<myInv2>)(HttpRuntime.Cache["OverCarMove_" + AreaNo + Session["CNN2"].ToString()]);
            grdOverCarMove.DataSource = CarMoveData;
            grdOverCarMove.DataBind();

            OverCarMoveTrip = (List<CarMoveTrip>)(HttpRuntime.Cache["OverCarMoveTrip_" + AreaNo + Session["CNN2"].ToString()]);
            grdOverTrip.DataSource = OverCarMoveTrip;
            grdOverTrip.DataBind();
            if (OverCarMoveTrip.Count() > 0)
            {
                for (int i = 0; i < grdOverTrip.Rows.Count; i++)
                {
                    CheckBox ChkStatus = grdOverTrip.Rows[i].FindControl("ChkStatus") as CheckBox;
                    ChkStatus.Visible = (OverCarMoveTrip[i].Model != "8");
                }
            }

            OverCarMoveChart = (List<CarMoveTrip>)(HttpRuntime.Cache["OverCarMoveChart_" + AreaNo + Session["CNN2"].ToString()]);
            Chart1.DataSource = OverCarMoveChart;
            this.Chart1.Series[0].BorderWidth = 1;
            this.Chart1.Series[0].BorderColor = System.Drawing.Color.FromArgb(26, 59, 105);
            Chart1.Series[0].SetCustomProperty("PieLabelStyle", "outside");
            Chart1.Series["Categories"].XValueMember = "DestinationName1";
            Chart1.Series["Categories"].YValueMembers = "FNo";
            Chart1.DataBind();
        }

        public void SetCarMove(string myArea)
        {
            List<myInv2> myInv = new List<myInv2>();
            List<CarMoveTrip> myInv9 = new List<CarMoveTrip>();
            List<CarMoveTrip> myInvx = new List<CarMoveTrip>();
            Invoice inv = new Invoice();
            inv.Branch = 1;
            inv.VouLoc = myArea;
            myInv = inv.GetInvMove(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

            CostCenter myCost = new CostCenter();
            myCost.Branch = 1;
            myCost.Code = myArea;
            myCost = myCost.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

            List<myInv2> myList2 = new List<myInv2>();
            CarMove myCarMove = new CarMove();
            myCarMove.Branch = 1;
            myCarMove.VouLoc = myArea;
            myCarMove.ToLoc = "-1";
            myList2 = myCarMove.Gettr(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, true, myCost.City, myArea);
            if (myList2 != null) myInv.AddRange(myList2);

            myInv9 = (from itm in myInv
                      group itm by new { itm.DestinationName1, itm.Destination} into g
                      select new CarMoveTrip {
                       DestinationName1 = g.Key.DestinationName1,
                       Destination = g.Key.Destination,
                       FNo = (short)g.Count()
                      }).ToList();

            foreach (myInv2 itm in myInv)
            {
                itm.RecAddress = moh.MakeMask((from sitm in myInv9 
                               where sitm.DestinationName1 == itm.DestinationName1
                               select sitm.FNo).FirstOrDefault().ToString(),2) + " " + itm.DestinationName1;
            }

            myInv = myInv.OrderByDescending(c => c.RecAddress).ToList(); 
            int i = 1;
            foreach (myInv2 itm in myInv)
            {
                itm.FNo = i++;
            }

            i = 0;
            int r1 = 0;
            foreach (CarMoveTrip itm in myInv9)
            {
                if (itm.FNo <= 8)
                {
                    myInvx.Add(new CarMoveTrip {
                      FNo = int.Parse(int.Parse(myArea).ToString()+moh.MakeMask(i.ToString(),2)),
                      Model = itm.FNo.ToString(),
                      DestinationName1 = itm.DestinationName1,
                      Destination = itm.Destination
                    });
                    i++;
                }
                else
                {
                    r1 = itm.FNo;
                    while (r1 > 0)
                    {
                        myInvx.Add(new CarMoveTrip
                        {
                            FNo = int.Parse(int.Parse(myArea).ToString() + moh.MakeMask(i.ToString(),2)),
                            Model = r1>=8 ? "8" : r1.ToString(),
                            DestinationName1 = itm.DestinationName1,
                            Destination = itm.Destination
                        });
                        r1 = r1 - 8;
                        i++;
                    }
                }
            }
            myInvx = myInvx.OrderByDescending(c => c.Model).ToList();


            if (HttpRuntime.Cache["OverCarMove_" + myArea + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMove_" + myArea + Session["CNN2"].ToString());
            if (HttpRuntime.Cache["OverCarMoveTrip_" + myArea + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMoveTrip_" + myArea + Session["CNN2"].ToString());
            if (HttpRuntime.Cache["OverCarMoveChart_" + myArea + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMoveChart_" + myArea + Session["CNN2"].ToString());

            Cache.Insert("OverCarMoveTrip_" + myArea + Session["CNN2"].ToString(), myInvx);
            Cache.Insert("OverCarMoveChart_" + myArea + Session["CNN2"].ToString(), myInv9);
            Cache.Insert("OverCarMove_" + myArea + Session["CNN2"].ToString(), myInv);
            return;
        }

        public bool CheckSite(string CurrentCity, List<Cities> lc)
        {
            try
            {
                bool vFound = false;
                if (lc != null)
                {
                    foreach (Cities itm in lc)
                    {
                        if (CurrentCity == itm.Code)
                        {
                            vFound = true;
                            break;
                        }
                    }
                }
                return vFound;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [System.Web.Services.WebMethodAttribute(enableSession: true),
            System.Web.Script.Services.ScriptMethodAttribute()]
        public static string GetDynamicContent(string contextKey)
        {
            try
            {
                CarMove myInv = new CarMove();
                myInv.Branch = 1;
                myInv.VouLoc = moh.MakeMask(contextKey.Split('/')[0], 5);
                myInv.Number = int.Parse(contextKey.Split('/')[1]);

                //Balance myBal = new Balance();
                //List<Balance> lBal = new List<Balance>();
                //lBal = myBal.SelectMasterBalance2(contextKey, WebConfigurationManager.ConnectionStrings["SupplyConnectionString"].ConnectionString);
                //Codes mycode = new Codes();
                //List<Codes> lcode = new List<Codes>();
                //lcode = mycode.GetAll("11", WebConfigurationManager.ConnectionStrings["SupplyConnectionString"].ConnectionString);
                StringBuilder b = new StringBuilder();
                b.Append("<table style='background-color:#f3f3f3; border: #336699 3px solid; ");
                b.Append("width:1125px; font-size:10pt; font-family:Verdana;' cellspacing='0' cellpadding='3'>");

                b.Append("<tr><td colspan='8' style='background-color:#336699; color:white;'>");
                b.Append("<center><b>عرض بيان الترحيل رقم " + contextKey + "</b></center>");
                b.Append("</td></tr>");
                b.Append("<tr><td  style='text-align:center;width:25px;'><b>م</b></td>");
                b.Append("<td style='text-align:center;width:200px;'><b>المرسل</b></td>");
                b.Append("<td style='text-align:center;width:100px;'><b>رقم الفاتورة</b></td>");
                b.Append("<td style='text-align:center;width:150px;'><b>نوع السيارة</b></td>");
                b.Append("<td style='text-align:center;width:150px;'><b>رقم اللوحة</b></td>");
                b.Append("<td style='text-align:center;width:150px;'><b>لطراز</b></td>");
                b.Append("<td style='text-align:center;width:200px;'><b>المستلم</b></td>");
                b.Append("<td style='text-align:center;width:125px;'><b>جهة الترحيل</b></td>");

                int i = 1;
                foreach (myInv2 itm in myInv.Get(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
                {
                    b.Append("<tr>");
                    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + (i++).ToString() + "</td>");
                    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.Name + "</td>");
                    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + int.Parse(itm.InvoiceVouLoc).ToString() + "/" + itm.VouNo.ToString() + "</td>");
                    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.CarType + "</td>");
                    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.PlateNo + "</td>");
                    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.Model + "</td>");
                    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.RecName + "</td>");
                    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.DestinationName1 + "</td>");
                    b.Append("</tr>");
                }

                ////foreach (Balance itm in lBal)
                ////{
                //    b.Append("<tr>");
                //    b.Append("<td style='border-top:1px solid #FFFFFF;'>" + (from item in lcode
                //                                                             where item.Fcode2 == itm.SiteNo.ToString()
                //                                                             select item.DescrA).FirstOrDefault() + "</td>");
                //    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.BinLoc.ToString() + "</td>");
                //    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.Bal.ToString() + "</td>");
                //    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.TRecpQty.ToString() + "</td>");
                //    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.AIssue.ToString() + "</td>");
                //    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.Bal2.ToString() + "</td>");
                //    b.Append("</tr>");

                //}
                b.Append("</table>");
                return b.ToString();
            }
            catch (Exception)
            {
                StringBuilder b = new StringBuilder();
                b.Append("<table style='background-color:#f3f3f3; border: #336699 3px solid; ");
                b.Append("width:1125px; font-size:10pt; font-family:Verdana;' cellspacing='0' cellpadding='3'>");
                b.Append("<tr><td colspan='8' style='background-color:#336699; color:white;'>");
                b.Append("<center><b>عرض بيان الترحيل رقم " + contextKey + "</b></center>");
                b.Append("</td></tr>");
                b.Append("<tr><td  style='text-align:center;width:25px;'><b>م</b></td>");
                b.Append("<td style='text-align:center;width:200px;'><b>المرسل</b></td>");
                b.Append("<td style='text-align:center;width:100px;'><b>رقم الفاتورة</b></td>");
                b.Append("<td style='text-align:center;width:150px;'><b>نوع السيارة</b></td>");
                b.Append("<td style='text-align:center;width:150px;'><b>رقم اللوحة</b></td>");
                b.Append("<td style='text-align:center;width:150px;'><b>لطراز</b></td>");
                b.Append("<td style='text-align:center;width:200px;'><b>المستلم</b></td>");
                b.Append("<td style='text-align:center;width:125px;'><b>جهة الترحيل</b></td></tr>");
                b.Append("<tr><td colspan='8'><center><b>بدون سيارات</b></center>");
                b.Append("</td></tr>");
                b.Append("</table>");
                return b.ToString();
            }
        }

        protected void grdTrackMove_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (DataControlRowType.DataRow == e.Row.RowType)
            {
                if (DataBinder.Eval(e.Row.DataItem, "Code").ToString() == "مستأجرة")
                {
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                }

                //string FNo = grdCodes.DataKeys[e.Row.RowIndex]["FNo"].ToString();
                //if (MyOverTrack[int.Parse(FNo) - 1].Diff < 0)
                //{
                //    //e.Row.CssClass = "UnreadRowStyle";
                //    //e.Row.BackColor = ColorTranslator.FromHtml("#ECFFD9");
                //    e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
                //}
            }
        }

 
        protected void grdTrackMove_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                PopupControlExtender pce = e.Row.FindControl("PopupControlExtender1") as PopupControlExtender;
                if (pce != null)
                {
                    string behaviorID = "pce_" + e.Row.RowIndex;
                    pce.BehaviorID = behaviorID;

                    Label img = e.Row.FindControl("lblDriver") as Label;
                    if (img != null)
                    {
                        string OnMouseOverScript = string.Format("$find('{0}').showPopup();", behaviorID);
                        string OnMouseOutScript = string.Format("$find('{0}').hidePopup();", behaviorID);

                        img.Attributes.Add("onmouseover", OnMouseOverScript);
                        img.Attributes.Add("onmouseout", OnMouseOutScript);
                    }
                }
            }
        }


        protected void grdTrackMove2_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                PopupControlExtender pce = e.Row.FindControl("PopupControlExtender2") as PopupControlExtender;
                if (pce != null)
                {
                    string behaviorID = "pce2_" + e.Row.RowIndex;
                    pce.BehaviorID = behaviorID;

                    Label img = e.Row.FindControl("lblDriver2") as Label;
                    if (img != null)
                    {
                        string OnMouseOverScript = string.Format("$find('{0}').showPopup();", behaviorID);
                        string OnMouseOutScript = string.Format("$find('{0}').hidePopup();", behaviorID);

                        img.Attributes.Add("onmouseover", OnMouseOverScript);
                        img.Attributes.Add("onmouseout", OnMouseOutScript);
                    }
                }
            }
        }

        protected void grdTrackMove1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                PopupControlExtender pce = e.Row.FindControl("PopupControlExtender3") as PopupControlExtender;
                if (pce != null)
                {
                    string behaviorID = "pce1_" + e.Row.RowIndex;
                    pce.BehaviorID = behaviorID;

                    Label img = e.Row.FindControl("lblDriver1") as Label;
                    if (img != null)
                    {
                        string OnMouseOverScript = string.Format("$find('{0}').showPopup();", behaviorID);
                        string OnMouseOutScript = string.Format("$find('{0}').hidePopup();", behaviorID);

                        img.Attributes.Add("onmouseover", OnMouseOverScript);
                        img.Attributes.Add("onmouseout", OnMouseOutScript);
                    }
                }
            }
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
                        case 1: return "~/WebCarMove.aspx?Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&StoreNo=" + StoreNo;
                        case 2: return "~/WebCarMoveRCV.aspx?Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&StoreNo=" + StoreNo;
                        case 3:
                            {
                                if (vs[0][0] == 'L') return "~/WebLShipment.aspx?Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0].Substring(1, vs[0].Length - 1), 5) + "&StoreNo=" + StoreNo;
                                else if (vs[0][0] == 'E') return "~/WebShipment.aspx?Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0].Substring(1, vs[0].Length - 1), 5) + "&StoreNo=" + StoreNo;
                                else return "~/WebInvoice.aspx?Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&StoreNo=" + StoreNo;
                            }                                                                    
                        case 20: return "~/WebCarMoveRCV.aspx?CarMove=" + Number.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo;
                        case 210: return "~/WebCarRCV.aspx?InvNo=" + Number.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo;
                        case 211: return "~/WebRVou1.aspx?InvNo=" + Number.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo;
                        case 21: return "~/WebPay1.aspx?FType=2&CarMove=" + Number.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo;
                        case 107: return "~/WebShipment.aspx?Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&StoreNo=" + StoreNo;
                        case 108: return "~/WebLShipment.aspx?Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&StoreNo=" + StoreNo;
                        default: return "";
                    }
                }
                else
                {
                    switch (short.Parse(FType.ToString()))
                    {
                        case 4: return ddlBranch.SelectedValue == AreaNo ? "~/WebCarMove.aspx?&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&Dest=" + Number.ToString() : "";
                        case 110: return "~/WebCars.aspx?&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&CarNo=" + Number.ToString();
                        case 222: if (((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("الحسابات") || ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("admin") || ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("شئون"))
                            {
                                return "~/WebEmp.aspx?FNum=" + Number.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo;
                            }
                            else return "";

                        default: return "";
                    }
                }
            }
            else return "";
        }

        protected void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (HttpRuntime.Cache["OverTrack_" + AreaNo + Session["CNN2"].ToString()] != null)
            {
                Cache.Remove("OverTrack_" + AreaNo + Session["CNN2"].ToString());
                Cache.Remove("OverTrack1_" + AreaNo + Session["CNN2"].ToString());
                Cache.Remove("OverTrack2_" + AreaNo + Session["CNN2"].ToString());
            }
            //ProcessTrackMove();
            DisplayCounter();
        }


        protected void BtnRefresh1_Click(object sender, EventArgs e)
        {            
            if (HttpRuntime.Cache["OverCarMove_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMove_" + AreaNo + Session["CNN2"].ToString());
            if (HttpRuntime.Cache["OverCarMoveTrip_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMoveTrip_" + AreaNo + Session["CNN2"].ToString());
            if (HttpRuntime.Cache["OverCarMoveChart_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarMoveChart_" + AreaNo + Session["CNN2"].ToString());
            //ProcessTrackMove();
            DisplayCounter();
        }


        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
                if (HttpRuntime.Cache["OverCarMove_" + ddlBranch.SelectedValue + Session["CNN2"].ToString()] == null) SetCarMove(ddlBranch.SelectedValue);

                CarMoveData = (List<myInv2>)(HttpRuntime.Cache["OverCarMove_" + ddlBranch.SelectedValue + Session["CNN2"].ToString()]);
                grdOverCarMove.DataSource = CarMoveData;
                grdOverCarMove.DataBind();

                OverCarMoveTrip = (List<CarMoveTrip>)(HttpRuntime.Cache["OverCarMoveTrip_" + ddlBranch.SelectedValue + Session["CNN2"].ToString()]);
                grdOverTrip.DataSource = OverCarMoveTrip;
                grdOverTrip.DataBind();

                OverCarMoveChart = (List<CarMoveTrip>)(HttpRuntime.Cache["OverCarMoveChart_" + ddlBranch.SelectedValue + Session["CNN2"].ToString()]);
                Chart1.DataSource = OverCarMoveChart;
                this.Chart1.Series[0].BorderWidth = 1;
                this.Chart1.Series[0].BorderColor = System.Drawing.Color.FromArgb(26, 59, 105);
                Chart1.Series[0].SetCustomProperty("PieLabelStyle", "outside");
                Chart1.Series["Categories"].XValueMember = "DestinationName1";
                Chart1.Series["Categories"].YValueMembers = "FNo";
                Chart1.DataBind();
        }

        protected void ChkStatus_CheckedChanged(object sender, EventArgs e)
        {
            if(ddlBranch.SelectedValue == AreaNo)
            {
                string vPath = "";
                int r = 0;
                for (int i = 0; i < grdOverTrip.Rows.Count; i++)
                {
                    if(OverCarMoveTrip[i].Model != "8")
                    {
                        CheckBox ChkStatus = grdOverTrip.Rows[i].FindControl("ChkStatus") as CheckBox;
                        if (ChkStatus.Visible)
                        {
                            if (ChkStatus.Checked)
                            {
                                if (r == 0)
                                {
                                    vPath = "~/WebCarMove.aspx?&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&Dest=" + OverCarMoveTrip[i].Destination;
                                }
                                else
                                {
                                    vPath += "&Dest" + r.ToString() + "=" + OverCarMoveTrip[i].Destination;
                                }
                                r++;
                            }
                        }
                    }                    
                }

                for (int i = 0; i < grdOverTrip.Rows.Count; i++)
                {
                    if (OverCarMoveTrip[i].Model != "8")
                    {
                        HyperLink lblFNo1 = grdOverTrip.Rows[i].FindControl("lblFNo1") as HyperLink;
                        CheckBox ChkStatus = grdOverTrip.Rows[i].FindControl("ChkStatus") as CheckBox;
                        if (ChkStatus.Visible)
                        {
                            if (ChkStatus.Checked)
                            {
                                lblFNo1.NavigateUrl = vPath;
                            }
                            else
                            {
                                lblFNo1.NavigateUrl = UrlHelper("4", OverCarMoveTrip[i].Destination);
                            }
                        }
                    }
                }
            }
        }      

        public string GetLandCost(string FDate,string FTime)
        {
            try
            {
                DateTime DFrom = new DateTime();
                DFrom = DateTime.Parse(FDate + " " + FTime.Replace("ص", "AM").Replace("م", "PM"));

                TimeSpan ts = new TimeSpan();
                ts = moh.Nows() - DFrom;
                if (ts.Days < 7) return "لا يوجد أرضية";
                else if (ts.Days == 7 && ts.Hours < 1) return "لا يوجد أرضية";
                else
                {
                    double value = (ts.Days - 7) * (double)SiteInfo.LandDay + ts.Hours * (double)SiteInfo.LandHour;
                    return string.Format("{0:N0} أرضية", value);
                }
            }
            catch
            {
                return "";
            }
        }


        protected void grdInv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string VouNo = grdInv.DataKeys[e.RowIndex]["InvNo"].ToString();
                string VouLoc = grdInv.DataKeys[e.RowIndex]["Area"].ToString();
                if (VouNo != null && VouLoc != null)
                {
                    if (VouLoc == "1")
                    {
                        ShipOnLine myInv = new ShipOnLine();
                        myInv.Branch = 1;
                        myInv.VouLoc = VouLoc;
                        myInv.VouNo = int.Parse(VouNo);
                        myInv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    else
                    {
                        InvOnLine eInv = new InvOnLine();
                        eInv.Branch = 1;
                        eInv.VouLoc = "00000";
                        eInv.VouNo = int.Parse(VouNo);
                        eInv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        InvOnLineDetails Inv = new InvOnLineDetails();
                        Inv.Branch = 1;
                        Inv.VouLoc = "00000";
                        Inv.VouNo = int.Parse(VouNo);
                        Inv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }

                    LoadInvData();
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationManager.AppSettings["ExitOnError"].ToString() == "1")
                {
                    Session.Add("Error", ex);
                    Response.Redirect("GeneralServerError.aspx");
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            DisplayCounter();           
        }

        protected void ChkAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            AutoRefresh = ChkAutoUpdate.Checked;
            Timer1.Enabled = ChkAutoUpdate.Checked;
            DisplayCounter();
        }

        public string GetLastTran(string Account,double? balance)
        {
            string result = string.Format("{0} \t {1} \t {2}      \t {3}          \t {4}      \t {5} \n", moh.MakeSize("المستند", 12), moh.MakeSize("الرقم", 6), moh.MakeSize("التاريخ   ", 12), moh.MakeSize("المبلغ", 12), "الرصيد", moh.MakeSize("البيان", 20));
            Jv myjv = new Jv();
            double? bal = balance;
            foreach (vJv itm in myjv.GetLast10(Account, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            {
                result += moh.MakeSize(itm.FType3, 12) + " \t" + moh.MakeSize(itm.Number.ToString(), 6) + " \t" + moh.MakeSize(itm.FDate, 10) + " \t" + moh.MakeSize(string.Format("{0:N2}", itm.Amount), 12) + " \t" + moh.MakeSize(string.Format("{0:N2}", bal), 12) + " \t" + itm.Remark + "\n";
                if(itm.DbCode == Account) bal -= itm.Amount;
                else bal += itm.Amount;
            }
            return result;
        }

        protected string UrlHelper(string FType, string Number, string LocNumber, string LocType)
        {
            switch (short.Parse(FType))
            {
                case 100: return "WebJVou.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + Number;
                case 101: return LocType == "1" ? "WebRVou12.aspx?FType=1&FNum=" + Number + "&LocNumber=" + LocNumber + "&LocType=" + LocType + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo :
                                                               "WebRVou1.aspx?FType=1&FNum=" + Number + "&LocNumber=" + LocNumber + "&LocType=" + LocType + "&AreaNo=" + moh.MakeMask(LocNumber, 5) + "&StoreNo=" + StoreNo + "&Flag=0";
                case 102: return LocType == "1" ? "WebPay12.aspx?FType=2&FNum=" + Number + "&LocNumber=" + LocNumber + "&LocType=" + LocType + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo :
                                                               "WebPay1.aspx?FType=2&FNum=" + Number + "&LocNumber=" + LocNumber + "&LocType=" + LocType + "&AreaNo=" + moh.MakeMask(LocNumber, 5) + "&StoreNo=" + StoreNo + "&Flag=0";
                case 103: return "WebInvoice.aspx?FNum=" + Number + "&AreaNo=" + moh.MakeMask(LocNumber, 5) + "&StoreNo=" + StoreNo + "&Flag=0";
                case 104: return "WebCarMove.aspx?FNum=" + Number + "&AreaNo=" + moh.MakeMask(LocNumber, 5) + "&StoreNo=" + StoreNo + "&Flag=0";
                case 105: return "WebBankPay.aspx?FNum=" + Number + "&AreaNo=" + moh.MakeMask(LocNumber, 5) + "&StoreNo=" + StoreNo + "&Flag=" + (int.Parse(LocType) - 1).ToString();
                case 106: return "WebBankTrans.aspx?FNum=" + Number + "&AreaNo=" + moh.MakeMask(LocNumber, 5) + "&StoreNo=" + StoreNo + "&Flag=" + (int.Parse(LocType) - 1).ToString();

                case 107: return "WebShipment.aspx?FNum=" + Number + "&AreaNo=" + moh.MakeMask(LocNumber, 5) + "&StoreNo=" + StoreNo + "&Flag=0";
                case 108: return "WebLShipment.aspx?FNum=" + Number + "&AreaNo=" + moh.MakeMask(LocNumber, 5) + "&StoreNo=" + StoreNo + "&Flag=0";


                case 501: return "WebPurchaseInvoice.aspx?FNum=" + Number + "&StoreNo=" + moh.MakeMask(LocNumber, 5) + "&AreaNo=" + AreaNo + "&Flag=0";
                case 502: return "WebReturnPurchaseInvoice.aspx?FNum=" + Number + "&StoreNo=" + moh.MakeMask(LocNumber, 5) + "&AreaNo=" + AreaNo + "&Flag=0";
                case 701: return "WebIssueNote.aspx?FNum=" + Number + "&StoreNo=" + moh.MakeMask(LocNumber, 5) + "&AreaNo=" + AreaNo + "&Flag=0";
                default: return "";
            }
        }

        public string GetLastTran2(string Account, double? balance,string AccountName)
        {
            StringBuilder b = new StringBuilder();
            b.Append("<table style='background-color:#f3f3f3; border: #336699 3px solid; z-index:99999;");
            b.Append("width:1000px; font-size:10pt; font-family:Verdana;' cellspacing='0' cellpadding='3'>");
            b.Append("<tr><td colspan='7' style='background-color:#336699; color:white;'>");
            b.Append("<img src='images/close.png' onclick='fnClose();'/><center><b>عرض أخر معاملات تمت على    " + AccountName + "</b></center>");
            b.Append("</td></tr>");
            b.Append("<td style='text-align:center;width:100px;'><b>المستند</b></td>");
            b.Append("<td style='text-align:center;width:100px;'><b>الرقم</b></td>");
            b.Append("<td style='text-align:center;width:100px;'><b>التاريخ</b></td>");
            b.Append("<td style='text-align:center;width:100px;'><b>مدين</b></td>");
            b.Append("<td style='text-align:center;width:100px;'><b>دائن</b></td>");
            b.Append("<td style='text-align:center;width:100px;'><b>الرصيد</b></td>");
            b.Append("<td style='text-align:center;width:400px;'><b>البيان</b></td></tr>");

            Jv myjv = new Jv();
            double? bal = balance;
           
            foreach (vJv itm in myjv.GetLast10(Account, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            {
                b.Append("<tr>");
                b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.FType3 + "</td>");
                b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'><a href='" + UrlHelper(itm.FType.ToString(), itm.Number.ToString(), itm.LocNumber.ToString(), itm.LocType.ToString()) +"' target='_blank'>" + itm.LocNumber.ToString() + "/" + itm.Number.ToString() + "</a></td>");
                b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.FDate + "</td>");
                b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + (itm.DbCode != "" ? string.Format("{0:N2}", itm.Amount) : " ") + "</td>");
                b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + (itm.CrCode != "" ? string.Format("{0:N2}", itm.Amount) : " ") + "</td>");
                b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + string.Format("{0:N2}", bal) + "</td>");
                b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.Remark + "</td>");
                b.Append("</tr>");
                if (itm.DbCode == Account) bal -= itm.Amount;
                else bal += itm.Amount;
            }
            b.Append("</table>");
            return b.ToString();
        }

        protected void grdTrackMove1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (DataControlRowType.DataRow == e.Row.RowType)
            {
                if (DataBinder.Eval(e.Row.DataItem, "Code").ToString() == "مستأجرة")
                {
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                }
            }

        }

        protected void RdoActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (int.Parse(RdoActive.SelectedValue))
            {
                case 1:
                    {
                        ddlFType.Items.Clear();
                        ddlFType.Items.Add(new ListItem(GetLocalResourceObject("FType1").ToString(), "0"));
                        ddlFType.Items.Add(new ListItem(GetLocalResourceObject("FType2").ToString(), "1"));
                        ddlFType.Items.Add(new ListItem(GetLocalResourceObject("FType3").ToString(), "2"));
                        ddlFType.Items.Add(new ListItem(GetLocalResourceObject("FType4").ToString(), "3"));
                        ddlFType.Items.Add(new ListItem(GetLocalResourceObject("FType5").ToString(), "4"));
                        ddlFType.Items.Add(new ListItem(GetLocalResourceObject("FType6").ToString(), "5"));
                        ddlFType.Items.Add(new ListItem(GetLocalResourceObject("FType7").ToString(), "6"));
                        ddlFType.Items.Add(new ListItem(GetLocalResourceObject("FType8").ToString(), "7"));
                        break;
                    }
                case 2:
                    {
                        ddlFType.Items.Clear();
                        ddlFType.Items.Add(new ListItem(GetLocalResourceObject("FType1").ToString(), "10"));
                        ddlFType.Items.Add(new ListItem(GetLocalResourceObject("FType2").ToString(), "11"));
                        ddlFType.Items.Add(new ListItem(GetLocalResourceObject("FType3").ToString(), "12"));
                        ddlFType.Items.Add(new ListItem(GetLocalResourceObject("FType4").ToString(), "13"));
                        ddlFType.Items.Add(new ListItem(GetLocalResourceObject("FType7").ToString(), "16"));
                        ddlFType.Items.Add(new ListItem(GetLocalResourceObject("FType8").ToString(), "17"));
                        break;
                    }
                case 3:
                    {
                        ddlFType.Items.Clear();
                        ddlFType.Items.Add(new ListItem(GetLocalResourceObject("FType1").ToString(), "20"));
                        ddlFType.Items.Add(new ListItem(GetLocalResourceObject("FType2").ToString(), "21"));
                        ddlFType.Items.Add(new ListItem(GetLocalResourceObject("FType3").ToString(), "22"));
                        ddlFType.Items.Add(new ListItem(GetLocalResourceObject("FType4").ToString(), "23"));
                        ddlFType.Items.Add(new ListItem(GetLocalResourceObject("FType7").ToString(), "26"));
                        ddlFType.Items.Add(new ListItem(GetLocalResourceObject("FType8").ToString(), "27"));
                        break;
                    }
            }


        }

    }
}