using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using System.Configuration;
using BLL;
using System.Web.Configuration;

namespace ACC
{
    public partial class Default_Support : System.Web.UI.Page
    {
        public string[] vBranch = {"","فرع النسيم",
                                      "فرع الشفا",
                                      "فرع الدمام",
                                      "فرع شمال جدة",
                                      "فرع جنوب جدة",
                                      "فرع المدينة",
                                      "فرع الطائف",
                                      "فرع أبها",
                                      "فرع بريدة",
                                      "فرع تبوك",
                                      "فرع القريات",
                                      "فرع الحفر",
                                      "فرع القادسية"
                                  };
        public string[] vLat = {"",@"http://bit.ly/1osch0b",
                                      @"http://bit.ly/221JZH3",
                                      @"http://bit.ly/221KnFj",
                                      @"http://bit.ly/1RxgDPg",
                                      @"http://bit.ly/1pWDARk",
                                      @"http://bit.ly/30vPnLO",
                                      @"http://bit.ly/1UBgk8o",
                                      @"http://bit.ly/3LP4qFc",     //  @"https://bit.ly/3pgbzEw",
                                      @"http://bit.ly/231ZjJr",
                                      @"http://bit.ly/35mHFoC",
                                      @"http://bit.ly/1ZW3bXg",
                                      @"http://bit.ly/1RGj7rf",
                                      @"http://bit.ly/2uaBsIJ"
                               };

        public List<CostCenter> PendingDocs
        {
            get
            {
                if (ViewState["PendingDocs"] == null)
                {
                    ViewState["PendingDocs"] = new List<CostCenter>();
                }
                return (List<CostCenter>)ViewState["PendingDocs"];
            }
            set { ViewState["PendingDocs"] = value; }
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
            if (!Page.IsPostBack)
            {
                this.Page.Header.Title = "الصفحة الرئيسية";
                if ((bool)Session["DispMessage"])
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(
                    "أهلا وسهلا بك المستخدم / " + Session["FullUser"].ToString() + " في نظام الناقلات البرية", false, false), true);
                    Session.Add("DispMessage", false);
                }
                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans2(Session["CurrentUser"].ToString(), "الرئيسية", "اختيار", "تم عرض الصفحة الرئيسية", "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString, Session["myLat"].ToString(), Session["myLng"].ToString());

                TblUsers ax = new TblUsers();
                if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                vRoleName = moh.GetCurrentRole(AreaNo,(from useritm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                                      where useritm.UserName == Session["CurrentUser"].ToString()
                                                      select useritm).FirstOrDefault());
                if (Session[vRoleName] == null)
                {
                    Response.Redirect("WebNotPrev.aspx", false);
                    return;
                }

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
                    mytime.FDate = String.Format("{0:dd/MM/yyyy}", moh.Nows().AddMonths(-1));
                    foreach (AttLog itm in mytime.GetByEmpMonth(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        done = true;
                        vResult += @"<tr><td>" + moh.MakeMask(DateTime.Parse(itm.FDate).Day.ToString(), 2) + " " + itm.FDate2.Split(' ')[0] + @"</td><td>" + itm.STime2 +
                            @"</td><td>" + itm.ETime2 + @"</td></tr>";
                    }

                    if (vResult != "" && done)
                    {
                        vResult += @"</table>');";
                        vResult = @"$(function() {" + vResult + @" return false; }); ";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), vResult, true);
                    }
                }

                DisplayCounter();
                LoadInvData();
            }
            else
            {
                for (int i = 1; i < 14; i++)
                {
                    if (Request.Form["ctl00$ContentPlaceHolder1$txtMobileNo" + i.ToString()] != null && Request.Form["ctl00$ContentPlaceHolder1$txtMobileNo" + i.ToString()] != "" && Request.Form["ctl00$ContentPlaceHolder1$txtMobileNo" + i.ToString()] != "لقد تم الارسال بنجاح")
                    {
                        string txt = Request.Form["ctl00$ContentPlaceHolder1$txtMobileNo" + i.ToString()];
                        sms.SendMessage("شكرا لتعاملك مع ناقلات البرية موقع " + vBranch[i] + " " + vLat[i], "naqelat", "966" + txt.Substring(1, 9));
                        //Request.Form["ctl00$ContentPlaceHolder1$txtMobileNo" + i.ToString()] = "لقد تم الارسال بنجاح";
                    }
                }
                Response.Redirect(Request.RawUrl);
            }
        }

        public void DisplayCounter()
        {
            List<CostCenter> mydata = new List<CostCenter>();
            bllPO.DataTextField = "Name1";
            bllPO.DataValueField = "Name2";
            try
            {

                try
                {
                    doAgree myAgree = new doAgree();
                    myAgree.UserName = Session["CurrentUser"].ToString();
                    myAgree.UserGroup = ((List<TblRoles>)(Session[vRoleName]))[0].RoleName;

                    foreach (doAgree itm in myAgree.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        if (itm.FType == 400)
                        {
                            SalOP mySal = new SalOP();
                            mydata.Add(new CostCenter
                            {
                                Name1 = string.Format("مؤثرات رواتب {0}", moh.MakeMask(itm.LocNumber.ToString(), 2) + "/" + moh.MakeMask(itm.LocType.ToString(), 4))
                                   ,
                                Name2 = "WebEmpSalOp.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&Month=" + itm.LocNumber.ToString() + "&Year=" + itm.LocType.ToString() + "&Dep=" + itm.Number.ToString() + "&FStep=" + itm.FNo.ToString() + "&FMode=1"

                                   ,
                                FType2 = moh.MakeMask(itm.LocNumber.ToString(), 2) + "/" + moh.MakeMask(itm.LocType.ToString(), 4),
                                Address = "مؤثرات رواتب"
                            });
                        }
                        else if (itm.FType == 101)
                        {
                            SalOP mySal = new SalOP();
                            mydata.Add(new CostCenter
                            {
                                Name1 = string.Format("مباشرة {0}", itm.Number.ToString())
                                   ,
                                Name2 = "WebStartwork2.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FLevel=" + itm.FNo.ToString() + "&FMode=1"
                                   ,
                                FType2 = String.Format("{0:dd/MM/yyyy}", moh.Nows()).Substring(3, 7),
                                Address = "مباشرة"
                            });
                        }
                        else if (itm.FType == 201)
                        {
                            SalOP mySal = new SalOP();
                            mydata.Add(new CostCenter
                            {
                                Name1 = string.Format("طلب أجازة {0}", itm.Number.ToString())
                                   ,
                                Name2 = "WebVac2.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FLevel=" + itm.FNo.ToString() + "&FMode=1"
                                   ,
                                FType2 = String.Format("{0:dd/MM/yyyy}", moh.Nows()).Substring(3, 7),
                                Address = "طلب أجازة"
                            });
                        }
                        else if (itm.FType == 301)
                        {
                            SalOP mySal = new SalOP();
                            mydata.Add(new CostCenter
                            {
                                Name1 = string.Format("إخلاء طرف  {0}", itm.Number.ToString())
                                   ,
                                Name2 = "WebDisclaimer.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FLevel=" + itm.FNo.ToString() + "&FMode=1"
                                   ,
                                FType2 = String.Format("{0:dd/MM/yyyy}", moh.Nows()).Substring(3, 7),
                                Address = "إخلاء طرف"
                            });
                        }
                        else if (itm.FType == 401)
                        {
                            SalOP mySal = new SalOP();
                            mydata.Add(new CostCenter
                            {
                                Name1 = string.Format("نقل موظف  {0}", itm.Number.ToString())
                                   ,
                                Name2 = "WebTransferEmp.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FLevel=" + itm.FNo.ToString() + "&FMode=1"
                                   ,
                                FType2 = String.Format("{0:dd/MM/yyyy}", moh.Nows()).Substring(3, 7),
                                Address = "نقل موظف"
                            });
                        }


                    }




                }
                catch
                {

                }


                /*
                try
                {
                    eServices myService = new eServices();
                    mydata.AddRange((from itm in myService.GetActive((Session["CurrentUser"].ToString() == "alraheenah" ? "eid" : Session["CurrentUser"].ToString())


                                         , ((List<TblRoles>)(Session[vRoleName]))[0].RoleName, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     where itm.DocType != 201
                                     select new CostCenter
                                     {
                                         Name1 = string.Format("{0} رقم {1}", itm.Name2, itm.DocNo.ToString())
                                        ,
                                         Name2 = itm.FormName + "?Support=1&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.DocNo.ToString() + "&FLevel=" + ((int)itm.Status + 1).ToString() + "&FMode=1"
                                        ,
                                         FType2 = itm.DocDate.Substring(3, 7)
                                     }).ToList());
                }
                catch
                {

                }
                 */

                List<string> vdays = new List<string>();
                vdays = (from itm in mydata
                         group itm by new { itm.FType2 }
                             into g
                             orderby g.Key.FType2.Substring(3, 4) + "-" + g.Key.FType2.Substring(0, 2)
                             select g.Key.FType2).ToList();

                foreach (string s in vdays)
                {
                    ddlDays.Items.Add(s);
                }
                ddlDays.Items.Insert(0, new ListItem("الجميع", "-1", true));
                PendingDocs = mydata;
                bllPO.DataSource = mydata;
                bllPO.DataBind();


                try
                {
                    if (Cache["CarAlert" + Session["CNN2"].ToString()] == null)
                    {
                        Cars myCar = new Cars();
                        myCar.Branch = 1;
                        if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        DateTime dt = HDate.Ch_Date(HDate.getNow());
                        int rt = 0;
                        Cache.Insert("CarAlert" + Session["CNN2"].ToString(), (from itm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                                                               where (bool)itm.Status && itm.CarsType == myCar.CarsType &&
                                                                                     ((string.IsNullOrEmpty(itm.PHDate1) || HDate.Ch_Date(itm.PHDate1).AddDays(-30) < dt) ||
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
                                                                               }).ToList());
                    }
                    grdCarAlert.DataSource = (List<Cars>)(Cache["CarAlert" + Session["CNN2"].ToString()]);
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
                    if (Cache["CarAlert2" + Session["CNN2"].ToString()] == null)
                    {
                        Cars myCar = new Cars();
                        myCar.Branch = 1;
                        if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        DateTime dt = HDate.Ch_Date(HDate.getNow());
                        int rt = 0;
                        Cache.Insert("CarAlert2" + Session["CNN2"].ToString(), (from itm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                                                                where (bool)itm.Status && (itm.CarsType == 3 || itm.CarsType == 6 || itm.CarsType == 7) && ((string.IsNullOrEmpty(itm.PHDate1) || HDate.Ch_Date(itm.PHDate1).AddDays(-30) < dt) ||
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
                                                                                }).ToList());
                    }
                    grdCarAlert2.DataSource = (List<Cars>)(Cache["CarAlert2" + Session["CNN2"].ToString()]);
                    grdCarAlert2.DataBind();

                    if (((List<Cars>)grdCarAlert2.DataSource).Count > 0)
                    {
                        int i1 = 0, i2 = 0, i4 = 0;
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
                    if (Cache["EmpAlert2" + Session["CNN2"].ToString()] == null)
                    {
                        SEmp myEmp = new SEmp();
                        DateTime dt = HDate.Ch_Date(HDate.getNow());
                        int rt = 0;
                        Cache.Insert("EmpAlert2" + Session["CNN2"].ToString(), (from itm in myEmp.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                                                                where (itm.Nat != 1 && itm.Nat != 203 &&
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
                                                                                }).ToList());
                    }
                    grdPaperAlert.DataSource = (List<CostCenter>)(Cache["EmpAlert2" + Session["CNN2"].ToString()]);
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
            }
            catch
            {

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
                        case 1: return "~/WebCarMove.aspx?Support=1&Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&StoreNo=" + StoreNo;
                        case 2: return "~/WebCarMoveRCV.aspx?Support=1&Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&StoreNo=" + StoreNo;
                        case 3: return "~/WebInvoice.aspx?Support=1&Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&StoreNo=" + StoreNo;
                        case 20: return "~/WebCarMoveRCV.aspx?Support=1&CarMove=" + Number.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo;
                        case 210: return "~/WebCarRCV.aspx?Support=1&InvNo=" + Number.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo;
                        case 211: return "~/WebRVou1.aspx?Support=1&InvNo=" + Number.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo;
                        case 21: return "~/WebPay1.aspx?Support=1&FType=2&CarMove=" + Number.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo;
                        default: return "";
                    }
                }
                else
                {
                    switch (short.Parse(FType.ToString()))
                    {
                        case 110: return "~/WebCars.aspx?Support=1&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&CarNo=" + Number.ToString();
                        case 222: return "~/WebEmp.aspx?Support=1&FNum=" + Number.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo;
                        default: return "";
                    }
                }
            }
            else return "";
        }

        protected void BtnSend1_Click(object sender, EventArgs e)
        {

            TextBox tx = ((Button)sender).NamingContainer.FindControl("txtMobileNo" + ((Button)sender).CommandArgument) as TextBox;
            if (tx != null)
            {
                sms.SendMessage("شكرا لتعاملك مع ناقلات البرية موقع " + vBranch[int.Parse(((Button)sender).CommandArgument)] + " " + vLat[int.Parse(((Button)sender).CommandArgument)], "naqelat", "966" + tx.Text.Substring(1, 9));
                tx.Text = "لقد تم الارسال بنجاح";
            }
        }

        public string getStartData(short Task)
        {
            string htmlStr = "";
            TblStart myStart = new TblStart();
            myStart.FType = Task;
            foreach (TblStart itm in (List<TblStart>)Cache["Starter" + Session["CNN2"].ToString()])
            {
                if (itm.FType == Task && itm.Fd1 != "")
                {
                    if (Task == 1) htmlStr += "<tr><td>" + itm.Fd1 + "</td><td>" + itm.Fd2 + "</td><td>" + itm.Fd3 + "</td></tr>";
                    else if (Task == 2 || Task == 3) htmlStr += "<tr><td>" + itm.Fd1 + "</td><td>" + itm.Fd2 + "</td><td>" + itm.Fd3 + "</td><td>" + itm.Fd4 + "</td><td>" + itm.Fd5 + "</td></tr>";
                    else if (Task == 4 || Task == 5) htmlStr += "<tr><td>" + itm.Fd1 + "</td><td>" + itm.Fd2 + "</td><td>" + itm.Fd3 + "</td><td>" + itm.Fd4 + "</td></tr>";
                    else if (Task == 6)
                    {
                        htmlStr += "<tr><td>" + @"<a target='_blank' href='http://www.naqelat.com/branches" + itm.FNo.ToString().Trim() + @".html'><i class='fa fa-map-marker'></i>&nbsp;" + itm.Fd1 + @"</a>" + "</td><td>" + itm.Fd2 + "أرقام الاتصال بالفرع:  " + @"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + itm.Fd3 + @"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + itm.Fd4 + @"<br/><br/>أرسال رسالة بموقع الفرع على جوال رقم&nbsp;&nbsp;" + "<input id='ContentPlaceHolder1_txtMobileNo" + itm.FNo.ToString().Trim() + @"' name='ctl00$ContentPlaceHolder1$txtMobileNo" + itm.FNo.ToString().Trim() + "' type='text'><input id='ContentPlaceHolder1_BtnSend" + itm.FNo.ToString().Trim() + @"' name='ctl00$ContentPlaceHolder1$BtnSend" + itm.FNo.ToString().Trim() + @"' value='أرسال' type='submit'>" + "</td></tr>";
                    }  
                }
            }
            return htmlStr;
        }

        public string GetCustomerName(int VouNo)
        {
            string Result = "";
            string vStr = "";
            InvOnLine InvNet = new InvOnLine();
            InvNet.Branch = 1;
            InvNet.VouLoc = "00000";
            InvNet.VouNo = VouNo;
            InvNet = InvNet.Find(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString);
            if (InvNet != null)
            {
                vStr = moh.MakeMask(DateTime.Parse(InvNet.GDate).Month.ToString(), 2) + moh.MakeMask(DateTime.Parse(InvNet.GDate).Day.ToString(), 2) + "" + InvNet.VouNo.ToString() + "" + (100 + int.Parse(InvNet.VouLoc)).ToString();
                int r = 0;
                for (int i = 0; i < vStr.Length; i++)
                {
                    r += int.Parse(vStr[i].ToString());
                }
                vStr = moh.MakeMask(r.ToString(), 2) + vStr;
                Result = "اسم المرسل : " + InvNet.Name + "\n" + "رقم الجوال : "+InvNet.MobileNo + "\n" + "رقم الحجز : "+vStr;
            }
            return Result;
        }

        public void LoadInvData()
        {
            List<CostCenter> mydata2 = new List<CostCenter>();
            try
            {
                InvOnLine InvNet = new InvOnLine();
                InvNet.Branch = 1;
                InvNet.VouLoc = "00000";
                InvNet.Site = "-1";
                mydata2 = (from itm in InvNet.GetAll(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString)
                           select new CostCenter
                           {
                               InvNo = itm.VouNo,
                               Area = itm.VouLoc,
                               Code = "1"
                               ,
                               Name1 = string.Format("{0}  {1}", itm.VouNo.ToString(), itm.GDate.ToString())
                               ,
                               Name2 = "WebInvoice.aspx?Support=1&AreaNo=" + itm.Site + "&StoreNo=1" + "&FMode=99" + "&FNum=" + itm.VouNo.ToString(),
                               City = GetCustomerName(itm.VouNo),
                               UserName = string.Format("window.open({0}); return false;", "\""+"WebSInv.aspx?FMode=99&FNum=" + itm.VouNo.ToString() + "\"")
                           }).OrderByDescending(x => x.InvNo).ToList();
            }
            catch
            {

            }


            try
            {
                Emergency InvNet = new Emergency();
                InvNet.Branch = 1;
                InvNet.VouLoc = "1";
                mydata2.AddRange((from itm in InvNet.GetAll(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString)
                                  select new CostCenter
                                  {
                                      InvNo = itm.VouNo,
                                      Area = itm.VouLoc,
                                      Code = "2"
                                      ,
                                      Name1 = string.Format("R{0}  {1}", itm.VouNo.ToString(), itm.ODateTime.Split(' ')[0])
                                      ,
                                      Name2 = "WebEmergInv.aspx?Support=1&AreaNo=00019" + "&StoreNo=1" + "&FMode=99" + "&InvNo=" + itm.VouNo.ToString()
                                  }).OrderByDescending(x => x.InvNo).ToList());
            }
            catch
            {

            }

            try
            {
                WaterOnline InvNet = new WaterOnline();
                InvNet.Branch = 1;
                InvNet.VouLoc = "1";
                mydata2.AddRange((from itm in InvNet.GetAll(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString)
                                  select new CostCenter
                                  {
                                      InvNo = itm.VouNo,
                                      Area = itm.VouLoc,
                                      Code = "3"
                                      ,
                                      Name1 = string.Format("W{0}  {1}", itm.VouNo.ToString(), itm.OrDateTime.Split(' ')[0])
                                      ,
                                      Name2 = "WebWater.aspx?Support=1&AreaNo=000019" + "&StoreNo=1" + "&FMode=99" + "&InvNo=" + itm.VouNo.ToString()
                                  }).OrderByDescending(x => x.InvNo).ToList());
            }
            catch
            {

            }


            try
            {
                ShipOnLine InvNet = new ShipOnLine();
                mydata2.AddRange((from itm in InvNet.GetAll("-1", WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString)
                                  select new CostCenter
                                  {
                                      InvNo = itm.VouNo,
                                      Area = itm.VouLoc,
                                      Code = "4"
                                      ,
                                      Name1 = string.Format("E{0}  {1}", itm.VouNo.ToString(), itm.GDate.ToString())
                                      ,
                                      Name2 = "WebShipment.aspx?Support=1&AreaNo=" + itm.LocFrom + "&StoreNo=1" + "&FMode=99" + "&FNum=" + itm.VouNo.ToString()
                                  }).OrderByDescending(x => x.InvNo).ToList());
            }
            catch
            {

            }

            try
            {
                GasOnline InvNet = new GasOnline();
                InvNet.Branch = 1;
                InvNet.VouLoc = "1";
                mydata2.AddRange((from itm in InvNet.GetAll(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString)
                                  select new CostCenter
                                  {
                                      InvNo = itm.VouNo,
                                      Area = itm.VouLoc,
                                      Code = "5"
                                      ,
                                      Name1 = string.Format("G{0}  {1}", itm.VouNo.ToString(), itm.ODateTime.Split(' ')[0])
                                      ,
                                      Name2 = "WebGas.aspx?Support=1&AreaNo=00019" + "&StoreNo=1" + "&FMode=99" + "&InvNo=" + itm.VouNo.ToString()
                                  }).OrderByDescending(x => x.InvNo).ToList());
            }
            catch
            {

            }




            try
            {
                grdInv.DataSource = mydata2;
                grdInv.DataBind();

                TblUsers ax = new TblUsers();
                if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                string vRole = moh.GetCurrentRole(AreaNo, (from useritm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                                          where useritm.UserName == Session["CurrentUser"].ToString()
                                                          select useritm).FirstOrDefault());
                if (Session["CurrentUser"].ToString().ToLower().Contains("admin") || Session["CurrentUser"].ToString().ToLower().Contains("eid22"))
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

        protected void grdInv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string VouNo = grdInv.DataKeys[e.RowIndex]["InvNo"].ToString();
                string VouLoc = grdInv.DataKeys[e.RowIndex]["Area"].ToString();
                string Code = grdInv.DataKeys[e.RowIndex]["Code"].ToString();
                if (VouNo != null && VouLoc != null && Code != null)
                {
                    if (Code == "4")
                    {
                        ShipOnLine myInv = new ShipOnLine();
                        myInv.Branch = 1;
                        myInv.VouLoc = VouLoc;
                        myInv.VouNo = int.Parse(VouNo);
                        myInv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    else if (Code == "5")
                    {
                        GasOnline myInv = new GasOnline();
                        myInv.Branch = 1;
                        myInv.VouLoc = VouLoc;
                        myInv.VouNo = int.Parse(VouNo);
                        myInv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    else if (Code == "1")
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
                    else if (Code == "2")
                    {
                        Emergency myInv = new Emergency();
                        myInv.Branch = 1;
                        myInv.VouLoc = VouLoc;
                        myInv.VouNo = int.Parse(VouNo);
                        myInv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    else if (Code == "3")
                    {
                        WaterOnline myInv = new WaterOnline();
                        myInv.Branch = 1;
                        myInv.VouLoc = VouLoc;
                        myInv.VouNo = int.Parse(VouNo);
                        myInv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    LoadInvData();
                }
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


        protected void ddlDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<CostCenter> mydata = new List<CostCenter>();
            if (ddlDays.SelectedIndex == 0)
            {
                mydata = PendingDocs;
            }
            else
            {
                mydata = (from itm in PendingDocs
                          where itm.FType2 == ddlDays.SelectedValue
                          select itm).ToList();
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

        }


    }
}