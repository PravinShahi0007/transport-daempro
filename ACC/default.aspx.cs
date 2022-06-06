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
        public List<vRepairReq> WSCarMoveData
        {
            get
            {
                if (ViewState["WSCarMoveData"] == null)
                {
                    ViewState["WSCarMoveData"] = new List<vRepairReq>();
                }
                return (List<vRepairReq>)ViewState["WSCarMoveData"];
            }
            set
            {
                ViewState["WSCarMoveData"] = value;

            }
        }
        public List<vRepairReq> WSCarInMoveData
        {
            get
            {
                if (ViewState["WSCarInMoveData"] == null)
                {
                    ViewState["WSCarInMoveData"] = new List<vRepairReq>();
                }
                return (List<vRepairReq>)ViewState["WSCarInMoveData"];
            }
            set
            {
                ViewState["WSCarInMoveData"] = value;

            }
        }
        public List<vRepairReq> WSCarOutMoveData
        {
            get
            {
                if (ViewState["WSCarOutMoveData"] == null)
                {
                    ViewState["WSCarOutMoveData"] = new List<vRepairReq>();
                }
                return (List<vRepairReq>)ViewState["WSCarOutMoveData"];
            }
            set
            {
                ViewState["WSCarOutMoveData"] = value;

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
                    this.Page.Header.Title = GetLocalResourceObject("Home").ToString(); // "الصفحة الرئيسية";

                    if (Request.QueryString["AreaNo"] != null)
                    {
                        ((HiddenField)this.Master.FindControl("MyArea")).Value = Request.QueryString["AreaNo"].ToString(); ;
                        AreaNo = Request.QueryString["AreaNo"].ToString(); ;
                        CostCenter myCost = new CostCenter();
                        myCost.Branch = 1;
                        if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCost.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCost.Code = Request.QueryString["AreaNo"].ToString();
                        myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                  where citm.Code == myCost.Code
                                  select citm).FirstOrDefault();
                        if (myCost != null) SiteInfo = myCost;
                    }
                    else
                    {
                        ((HiddenField)this.Master.FindControl("MyArea")).Value = Session["AreaNo"].ToString();
                        AreaNo = Session["AreaNo"].ToString();
                        SiteInfo = (CostCenter)Session["SiteInfo"];
                    }

                    //grdWSTrackMove.Visible = (AreaNo == "00015");

                    if (Request.QueryString["StoreNo"] != null) StoreNo = Request.QueryString["StoreNo"].ToString();
                    else StoreNo = Session["StoreNo"].ToString();

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


                    if ((bool)Session["DispMessage"])
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(
                            GetLocalResourceObject("Welcome").ToString() + Session["FullUser"].ToString() + " " + GetLocalResourceObject("Welcome").ToString(), false, false), true);
                        //"أهلا وسهلا بك " + Session["FullUser"].ToString() + " في نظام الناقلات البرية", false, false), true);
                        Session.Add("DispMessage", false);
                    }
                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans2(Session["CurrentUser"].ToString(), GetLocalResourceObject("Home").ToString(), GetLocalResourceObject("Select").ToString(), GetLocalResourceObject("DisplayHome").ToString(), "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString, Session["myLat"].ToString(), Session["myLng"].ToString());

                    if (Session["CurrentUser"].ToString().ToUpper() == "SAM")
                    {
                        Response.Redirect("WebUsersTranRep.aspx?AreaNo=1&StoreNo=1&Support=1");
                        return;
                    }



                    if (Session["CNN"].ToString().ToUpper() == "MYCNN")
                    {
                        SEmp myEmp = new SEmp();
                        myEmp.UserName = Session["CurrentUser"].ToString();
                        int? EmpNo = 0;
                        EmpNo = myEmp.FindByUserName(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (EmpNo != null && EmpNo > 0)
                        {
                            string vResult = "";
                            bool done = false;
                            vResult += @"$.sticky('<i style=""color:Red;"" class=""fa fa-exclamation-triangle  fa-lg fa-fw""></i></br><table dir=""rtl"" class=""responstable""><tr><td>" + GetLocalResourceObject("Day").ToString() + 
                                       @"</td><td>" + GetLocalResourceObject("TimeIn").ToString() + @"</td><td>" + GetLocalResourceObject("TimeOut").ToString() + "</td></tr>";
                            AttLog mytime = new AttLog();
                            mytime.EmpCode = (int)EmpNo;
                            mytime.FDate = String.Format("{0:dd/MM/yyyy}", moh.Nows().AddMonths(-1));
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
                        divPaperAlert.Visible = ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("الحسابات") || ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("شئون") || ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("admin") || ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("القسم النســـائي - التأمين") || Session["CurrentUser"].ToString().ToUpper() == "EID";                        
                        DisplayCounter();

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
                                //moh.PActiveEmps(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }
                            catch { }
                        }

                        if ((((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("الحسابات") || Session["CurrentUser"].ToString().ToUpper() == "MAI" || ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("admin")))
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
                                    vResult += @"$.sticky('<i style=""color:Red;"" class=""fa fa-exclamation-triangle  fa-lg fa-fw""></i><a target=""_blank"" href=""WebJVou.aspx?AreaNo=" + AreaNo + @"&StoreNo=" + StoreNo + @"&FNum=" + ii.ToString() + @""">" + ii.ToString() + @"</a>" + GetLocalResourceObject("RunJVou").ToString() +  @"' ); ";
                                }
                            }


                            if (vResult != "")
                            {
                                vResult = @"$(function() {" + vResult + @" return false; }); ";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), vResult, true);
                            }
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
       
        public bool CompareDate(string vDocDate,DateTime dt,bool? eq)
        {
            bool vRet = false;
            try
            {
               vRet = (eq == null ? HDate.Ch_Date(vDocDate) <= dt : ((bool)eq ?  (HDate.Ch_Date(vDocDate).AddDays(-30) <= dt) : (HDate.Ch_Date(vDocDate).AddDays(-30) < dt)));
            }
            catch
            {
                return vRet;
            }
            return vRet;
        }

        public void DisplayCounter()
        {
            
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
                                              where (bool)itm.Status && itm.CarsType == myCar.CarsType && ((string.IsNullOrEmpty(itm.PHDate1) || CompareDate(itm.PHDate1, dt, false)) ||
                                                     (string.IsNullOrEmpty(itm.PHDate2) || CompareDate(itm.PHDate2, dt, false)) ||
                                                     (string.IsNullOrEmpty(itm.PHDate3) || CompareDate(itm.PHDate3, dt, false)) ||
                                                     (string.IsNullOrEmpty(itm.PHDate4) || CompareDate(itm.PHDate4, dt, false)) ||
                                                     (string.IsNullOrEmpty(itm.PHDate5) || CompareDate(itm.PHDate5, dt, false)))
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
                                                  strDate1 = (string.IsNullOrEmpty(itm.PHDate1) ? GetLocalResourceObject("DocNotFound").ToString() :
                                                              CompareDate(itm.PHDate1, dt, null) ? @"<a href='" + moh.GetPic(1, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + GetLocalResourceObject("Finished").ToString() + " " + dt.Subtract(HDate.Ch_Date(itm.PHDate1)).Days.ToString() + " " + GetLocalResourceObject("Day2").ToString() + @"</a>" :
                                                              CompareDate(itm.PHDate1, dt, true) ? GetLocalResourceObject("WillFinish").ToString() + " " + HDate.Ch_Date(itm.PHDate1).Subtract(dt).Days.ToString() + " " + GetLocalResourceObject("Day2").ToString() + @"</a>" : @"<a href='" + moh.GetPic(1, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>"),
                                                  strDate2 = (string.IsNullOrEmpty(itm.PHDate2) ? GetLocalResourceObject("DocNotFound").ToString() :
                                                              CompareDate(itm.PHDate2, dt, null) ? @"<a href='" + moh.GetPic(2, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + GetLocalResourceObject("Finished").ToString() + " " + dt.Subtract(HDate.Ch_Date(itm.PHDate2)).Days.ToString() + " " + GetLocalResourceObject("Day2").ToString() + @"</a>" :
                                                              CompareDate(itm.PHDate2, dt, true) ? GetLocalResourceObject("WillFinish").ToString() + " " + HDate.Ch_Date(itm.PHDate2).Subtract(dt).Days.ToString() + " " + GetLocalResourceObject("Day2").ToString() + @"</a>" : @"<a href='" + moh.GetPic(2, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>"),
                                                  strDate3 = (string.IsNullOrEmpty(itm.PHDate3) ? GetLocalResourceObject("DocNotFound").ToString() :
                                                              CompareDate(itm.PHDate3, dt, null) ? @"<a href='" + moh.GetPic(3, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + GetLocalResourceObject("Finished").ToString() + " " + dt.Subtract(HDate.Ch_Date(itm.PHDate3)).Days.ToString() + " " + GetLocalResourceObject("Day2").ToString() + @"</a>" :
                                                              CompareDate(itm.PHDate3, dt, true) ? GetLocalResourceObject("WillFinish").ToString() + " " + HDate.Ch_Date(itm.PHDate3).Subtract(dt).Days.ToString() + " " + GetLocalResourceObject("Day2").ToString() + @"</a>" : @"<a href='" + moh.GetPic(3, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>"),
                                                  strDate4 = (string.IsNullOrEmpty(itm.PHDate4) ? GetLocalResourceObject("DocNotFound").ToString() :
                                                              CompareDate(itm.PHDate4, dt, null) ? @"<a href='" + moh.GetPic(4, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + GetLocalResourceObject("Finished").ToString() + " " + dt.Subtract(HDate.Ch_Date(itm.PHDate4)).Days.ToString() + " " + GetLocalResourceObject("Day2").ToString() + @"</a>" :
                                                              CompareDate(itm.PHDate4, dt, true) ? GetLocalResourceObject("WillFinish").ToString() + " " + HDate.Ch_Date(itm.PHDate4).Subtract(dt).Days.ToString() + " " + GetLocalResourceObject("Day2").ToString() + @"</a>" : @"<a href='" + moh.GetPic(4, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>"),
                                                  strDate5 = (string.IsNullOrEmpty(itm.PHDate5) ? GetLocalResourceObject("DocNotFound").ToString() :
                                                              CompareDate(itm.PHDate5, dt, null) ? GetLocalResourceObject("Finished").ToString() + " " + dt.Subtract(HDate.Ch_Date(itm.PHDate5)).Days.ToString() + " " + GetLocalResourceObject("Day2").ToString() :
                                                              CompareDate(itm.PHDate5, dt, true) ? GetLocalResourceObject("WillFinish").ToString() + " " + HDate.Ch_Date(itm.PHDate5).Subtract(dt).Days.ToString() + " " + GetLocalResourceObject("Day2").ToString() : @"<img src='images/accept.png'/>")
                                              }).ToList());
                }
                grdCarAlert.DataSource = (List<Cars>)(Cache["CarAlert" + Session["CNN2"].ToString()]);
                grdCarAlert.DataBind();
                if (((List<Cars>)grdCarAlert.DataSource).Count > 0)
                {
                    int i1 = 0, i2 = 0, i3 = 0, i4 = 0, i5 = 0;
                    foreach (Cars itm in (List<Cars>)grdCarAlert.DataSource)
                    {
                        if (itm.strDate1.Contains(GetLocalResourceObject("Doc").ToString()) || itm.strDate1.Contains(GetLocalResourceObject("Finish").ToString())) i1++;
                        if (itm.strDate2.Contains(GetLocalResourceObject("Doc").ToString()) || itm.strDate2.Contains(GetLocalResourceObject("Finish").ToString())) i2++;
                        if (itm.strDate3.Contains(GetLocalResourceObject("Doc").ToString()) || itm.strDate3.Contains(GetLocalResourceObject("Finish").ToString())) i3++;
                        if (itm.strDate4.Contains(GetLocalResourceObject("Doc").ToString()) || itm.strDate4.Contains(GetLocalResourceObject("Finish").ToString())) i4++;
                        if (itm.strDate5.Contains(GetLocalResourceObject("Doc").ToString()) || itm.strDate5.Contains(GetLocalResourceObject("Finish").ToString())) i5++;
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
                                                                            where (bool)itm.Status && (itm.CarsType == 3 || itm.CarsType == 6 || itm.CarsType == 7) && ((string.IsNullOrEmpty(itm.PHDate1) || CompareDate(itm.PHDate1, dt, false)) ||
                                                                                 (string.IsNullOrEmpty(itm.PHDate2) || CompareDate(itm.PHDate2, dt, false)) ||
                                                                                 (string.IsNullOrEmpty(itm.PHDate3) || CompareDate(itm.PHDate3, dt, false)) ||
                                                                                 (string.IsNullOrEmpty(itm.PHDate4) || CompareDate(itm.PHDate4, dt, false)) ||
                                                                                 (string.IsNullOrEmpty(itm.PHDate5) || CompareDate(itm.PHDate5, dt, false)))
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
                                                                               strDate1 = (string.IsNullOrEmpty(itm.PHDate1) ? GetLocalResourceObject("DocNotFound").ToString() :
                                                                                           CompareDate(itm.PHDate1, dt, null) ? @"<a href='" + moh.GetPic(1, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + GetLocalResourceObject("Finished").ToString() + " " + dt.Subtract(HDate.Ch_Date(itm.PHDate1)).Days.ToString() + " " + GetLocalResourceObject("Day2").ToString() + @"</a>" :
                                                                                           CompareDate(itm.PHDate1, dt, true) ? GetLocalResourceObject("WillFinish").ToString() + " " + HDate.Ch_Date(itm.PHDate1).Subtract(dt).Days.ToString() + " " + GetLocalResourceObject("Day2").ToString() + @"</a>" : @"<a href='" + moh.GetPic(1, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>"),
                                                                               strDate2 = (string.IsNullOrEmpty(itm.PHDate2) ? GetLocalResourceObject("DocNotFound").ToString() :
                                                                                           CompareDate(itm.PHDate2, dt, null) ? @"<a href='" + moh.GetPic(2, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + GetLocalResourceObject("Finished").ToString() + " " + dt.Subtract(HDate.Ch_Date(itm.PHDate2)).Days.ToString() + " " + GetLocalResourceObject("Day2").ToString() + @"</a>" :
                                                                                           CompareDate(itm.PHDate2, dt, true) ? GetLocalResourceObject("WillFinish").ToString() + " " + HDate.Ch_Date(itm.PHDate2).Subtract(dt).Days.ToString() + " " + GetLocalResourceObject("Day2").ToString() + @"</a>" : @"<a href='" + moh.GetPic(2, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>"),
                                                                               strDate4 = (string.IsNullOrEmpty(itm.PHDate4) ? GetLocalResourceObject("DocNotFound").ToString() :
                                                                                           CompareDate(itm.PHDate4, dt, null) ? @"<a href='" + moh.GetPic(4, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + @"' target='_blank'>" + GetLocalResourceObject("Finished").ToString() + " " + dt.Subtract(HDate.Ch_Date(itm.PHDate4)).Days.ToString() + " " + GetLocalResourceObject("Day2").ToString() + @"</a>" :
                                                                                           CompareDate(itm.PHDate4, dt, true) ? GetLocalResourceObject("WillFinish").ToString() + " " + HDate.Ch_Date(itm.PHDate4).Subtract(dt).Days.ToString() + " " + GetLocalResourceObject("Day2").ToString() + @"</a>" : @"<a href='" + moh.GetPic(4, itm.Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + "' target='_blank' ><img src='images/accept.png'/></a>")
                                                                           }).ToList());
                }
                grdCarAlert2.DataSource = (List<Cars>)(Cache["CarAlert2" + Session["CNN2"].ToString()]);
                grdCarAlert2.DataBind();

                if (((List<Cars>)grdCarAlert2.DataSource).Count > 0)
                {
                    int i1 = 0, i2 = 0,  i4 = 0;
                    foreach (Cars itm in (List<Cars>)grdCarAlert2.DataSource)
                    {
                        if (itm.strDate1.Contains(GetLocalResourceObject("Doc").ToString()) || itm.strDate1.Contains(GetLocalResourceObject("Finish").ToString())) i1++;
                        if (itm.strDate2.Contains(GetLocalResourceObject("Doc").ToString()) || itm.strDate2.Contains(GetLocalResourceObject("Finish").ToString())) i2++;
                        if (itm.strDate4.Contains(GetLocalResourceObject("Doc").ToString()) || itm.strDate4.Contains(GetLocalResourceObject("Finish").ToString())) i4++;
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
                    Cache.Insert("EmpAlert2" + Session["CNN2"].ToString(),(from itm in myEmp.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                                where ( itm.Nat != 1 && itm.Nat != 203 &&
                                                        (string.IsNullOrEmpty(itm.ExpDate1) || CompareDate(itm.ExpDate1,dt,false)))
                                                        //|| (string.IsNullOrEmpty(itm.ExpDate2))) // || HDate.Ch_Date(itm.PHDate2).AddDays(-30) < dt))
                                                orderby itm.EmpCode
                                                select new CostCenter
                                                {
                                                    InvNo = ++rt,
                                                    Code = itm.EmpCode.ToString(),
                                                    Name1 = itm.Name,
                                                    SiteAcc = (string.IsNullOrEmpty(itm.FileName1) ? GetLocalResourceObject("DocNotFound").ToString() :
                                                                !string.IsNullOrEmpty(itm.ExpDate1) && CompareDate(itm.ExpDate1, dt, null) ? @"<a href='" + @"/Arch/" + itm.FileName1 + @"' target='_blank'>" + GetLocalResourceObject("Finished").ToString() + " " + dt.Subtract(HDate.Ch_Date(itm.ExpDate1)).Days.ToString() + " " + GetLocalResourceObject("Day2").ToString() + @"</a>" :
                                                                !string.IsNullOrEmpty(itm.ExpDate1) && CompareDate(itm.ExpDate1, dt, true) ? GetLocalResourceObject("WillFinish").ToString() + " " + HDate.Ch_Date(itm.ExpDate1).Subtract(dt).Days.ToString() + " " + GetLocalResourceObject("Day2").ToString() + @"</a>" : @"<a href='" + @"/Arch/" + itm.FileName1 + "' target='_blank' ><img src='images/accept.png'/></a>"),
                                                    TripAcc = (string.IsNullOrEmpty(itm.FileName2) ? GetLocalResourceObject("DocNotFound").ToString() : @"<img src='images/accept.png'/>")                                               
                                                }).ToList());
                }
                grdPaperAlert.DataSource = (List<CostCenter>)(Cache["EmpAlert2" + Session["CNN2"].ToString()]);
                grdPaperAlert.DataBind();

                if (((List<CostCenter>)grdPaperAlert.DataSource).Count > 0)
                {
                    int i1 = 0, i2 = 0;
                    foreach (CostCenter itm in (List<CostCenter>)grdPaperAlert.DataSource)
                    {
                        if (itm.SiteAcc.Contains(GetLocalResourceObject("Doc").ToString()) || itm.SiteAcc.Contains(GetLocalResourceObject("Finish").ToString())) i1++;
                        if (itm.TripAcc.Contains(GetLocalResourceObject("Doc").ToString()) || itm.TripAcc.Contains(GetLocalResourceObject("Finish").ToString())) i2++;
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
                if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                BulletedList1.DataTextField = "Name1";
                BulletedList1.DataValueField = "Name2";
                BulletedList1.DataSource = (from itm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()]) 
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

            /*
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
             */

            try
            {
                CostCenter myCostCenter = new CostCenter();
                myCostCenter.Branch = 1;
                if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                BulletedList1.DataTextField = "Name1";
                BulletedList1.DataValueField = "Name2";
                BulletedList1.DataSource = (from itm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                            where CheckItem(itm.Code)
                                            select new CostCenter { Name1 = itm.Name1, Name2 = "default.aspx?AreaNo=" + itm.Code + "&StoreNo=" + StoreNo }).ToList();
                BulletedList1.DataBind();
            }
            catch
            {

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
                                  Name1 = string.Format("{0}  {1}", GetLocalResourceObject("PReq").ToString() + " ", itm.VouNo.ToString() + "/" + itm.VouLoc.ToString())
                                  ,
                                  Name2 = (bool)((List<TblRoles>)(Session[vRoleName]))[0].Pass343 ? "WebPurchaseRequest.aspx?AreaNo=" + AreaNo + "&StoreNo=" + itm.VouLoc.ToString() + "&FNum=" + itm.VouNo.ToString() + "&FMode=1" : "WebPurchaseRequest.aspx?AreaNo=" + AreaNo + "&StoreNo=" + itm.VouLoc.ToString() + "&FNum=" + itm.VouNo.ToString()
                                  ,
                                  FType2 = itm.VouDate.Substring(3,7)
                                  ,
                                  Address = GetLocalResourceObject("PReq").ToString(),
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
                                     itm.FType == 1 || itm.FType == 3 || itm.FType == 5 ? GetLocalResourceObject("PReq").ToString() + " " : GetLocalResourceObject("PaymentNo").ToString() + " ", ((itm.FType == 3 || itm.FType == 4) ? "00" : "") + itm.LocNumber.ToString() + "/" + itm.Number.ToString(), itm.FType == 1 || itm.FType == 2 ? (itm.LocNumber != 0 ? GetLocalResourceObject("Branch2").ToString() : GetLocalResourceObject("Dep").ToString()) : (itm.FType == 3 || itm.FType == 4) ? GetLocalResourceObject("Man").ToString() : GetLocalResourceObject("Emp").ToString())
                                     ,
                                     Name2 =
                                     itm.FType == 1 || itm.FType == 3 || itm.FType == 5 ?
                                                           itm.LocNumber == 0 ? "WebPPO.aspx?Flag=0&FType=" + itm.FType.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0" :
                                                             "WebPPO.aspx?FType=" + itm.FType.ToString() + "&AreaNo=" + ((itm.FType == 3 || itm.FType == 4) ?  AreaNo : moh.MakeMask(itm.LocNumber.ToString(), 5)) + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0"
                                                    :
                                                            itm.LocNumber == 0 ? "WebPPO1.aspx?FType=" + itm.FType.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0" :
                                                            "WebPPO1.aspx?FType=" + itm.FType.ToString() + "&AreaNo=" + ((itm.FType == 3 || itm.FType == 4) ?  AreaNo : moh.MakeMask(itm.LocNumber.ToString(), 5)) + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0"
                                     ,
                                     CrLimit = 0,
                                     FType2 = itm.FDate.Substring(3,7),
                                     Address = itm.FType == 1 || itm.FType == 3 || itm.FType == 5 ? GetLocalResourceObject("Purch").ToString() : GetLocalResourceObject("Payment").ToString(),
                                     PayNo = 999
                                 }).ToList());
            }
            catch
            {

            }


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
                        mydata.Add(new CostCenter {
                            Name1 = string.Format(GetLocalResourceObject("SalEffects").ToString() + " {0}", moh.MakeMask(itm.LocNumber.ToString(), 2) + "/" + moh.MakeMask(itm.LocType.ToString(), 4))
                                                         ,
                                                          Name2 = "WebEmpSalOp.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&Month="+itm.LocNumber.ToString() + "&Year=" +  itm.LocType.ToString() + "&Dep=" + itm.Number.ToString() + "&FStep=" + itm.FNo.ToString() + "&FMode=1"

                                                         ,
                                                          FType2 = moh.MakeMask(itm.LocNumber.ToString(),2)+"/"+moh.MakeMask(itm.LocType.ToString(),4),
                            Address = GetLocalResourceObject("SalEffects").ToString()
                        });
                    }
                    else if (itm.FType == 101)
                    {
                        SalOP mySal = new SalOP();
                        mydata.Add(new CostCenter
                        {
                            Name1 = string.Format(GetLocalResourceObject("StartWork").ToString() + " {0}", itm.Number.ToString())
                               ,
                            Name2 = "WebStartwork2.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FLevel=" + itm.FNo.ToString() + "&FMode=1"
                               ,
                            FType2 = String.Format("{0:dd/MM/yyyy}", moh.Nows()).Substring(3, 7),
                            Address = GetLocalResourceObject("StartWork").ToString()
                        });
                    }
                    else if (itm.FType == 201)
                    {
                        SalOP mySal = new SalOP();
                        mydata.Add(new CostCenter
                        {
                            Name1 = string.Format(GetLocalResourceObject("EmpVac").ToString() + " {0}", itm.Number.ToString())
                               ,
                            Name2 = "WebVac2.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FLevel=" + itm.FNo.ToString() + "&FMode=1"
                               ,
                            FType2 = String.Format("{0:dd/MM/yyyy}", moh.Nows()).Substring(3, 7),
                            Address = GetLocalResourceObject("EmpVac").ToString()
                        });
                    }
                    else if (itm.FType == 301)
                    {
                        SalOP mySal = new SalOP();
                        mydata.Add(new CostCenter
                        {
                            Name1 = string.Format(GetLocalResourceObject("EmpLeave").ToString() + " {0}", itm.Number.ToString())
                               ,
                            Name2 = "WebDisclaimer.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FLevel=" + itm.FNo.ToString() + "&FMode=1"
                               ,
                            FType2 = String.Format("{0:dd/MM/yyyy}", moh.Nows()).Substring(3, 7),
                            Address = GetLocalResourceObject("EmpLeave").ToString()
                        });
                    }
                    else if (itm.FType == 401)
                    {
                        SalOP mySal = new SalOP();
                        mydata.Add(new CostCenter
                        {
                            Name1 = string.Format(GetLocalResourceObject("EmpTransfer").ToString() + " {0}", itm.Number.ToString())
                               ,
                            Name2 = "WebTransferEmp.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FLevel=" + itm.FNo.ToString() + "&FMode=1"
                               ,
                            FType2 = String.Format("{0:dd/MM/yyyy}", moh.Nows()).Substring(3, 7),
                            Address = GetLocalResourceObject("EmpTransfer").ToString()
                        });
                    }


                }




            }
            catch
            {

            }


            if (((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("مدير الصيانة") || ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("مدير الورشة") || Session["CurrentUser"].ToString().ToUpper() == "MAI")
            {
                try
                {
                    STS mySts = new STS();
                    mydata.AddRange((from itm in mySts.GetNotAgree(1, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     select new CostCenter
                                     {
                                         Name1 = string.Format(GetLocalResourceObject("IssueNo").ToString() + " {0}", itm.VouLoc.ToString() + "/" + itm.VouNo.ToString())
                                        ,
                                         Name2 = "WebIssueNote.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + itm.VouLoc.ToString() + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType=1"
                                        ,FType2 = itm.VouDate.Substring(3,7),
                                         Address = GetLocalResourceObject("Issue").ToString()
                                     }).ToList());

                    STP myStp = new STP();
                    mydata.AddRange((from itm in myStp.GetNotAgree(1, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     select new CostCenter
                                     {
                                         Name1 = string.Format(GetLocalResourceObject("PurchNo").ToString() + " {0}", itm.VouLoc.ToString() + "/" + itm.VouNo.ToString())
                                        ,
                                         Name2 = "WebDeliveryNote.aspx?Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType=1"
                                        ,
                                         FType2 = itm.VouDate.Substring(3, 7),
                                         Address = GetLocalResourceObject("Purch").ToString()
                                     }).ToList());

                }
                catch
                {

                }


                try
                {
                    PettyCash myPetty = new PettyCash();
                    mydata.AddRange((from itm in myPetty.GetNotAgree(1, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     where itm.LocType == 3
                                     select new CostCenter
                                     {
                                         Name1 = string.Format(GetLocalResourceObject("PettyNo").ToString() + " {0}", (itm.LocType == 3 ? "00" : "") + itm.VouLoc.ToString() + "/" + itm.VouNo.ToString())
                                        ,
                                         Name2 = itm.LocType == 2 ? "WebPettyCash.aspx?Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType2=1" :
                                         "WebPettyCash.aspx?FType=1&Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType2=1"
                                        ,
                                         FType2 = itm.VouDate.Substring(3, 7),
                                         Address = GetLocalResourceObject("Petty").ToString()
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
                                         Name1 = string.Format(GetLocalResourceObject("RepairNo").ToString() + " {0}",(itm.LocType == 3 ? "00" : "")+ itm.VouLoc.ToString() + "/" +  itm.VouNo.ToString())
                                        ,
                                         Name2 = itm.LocType == 2 ? "WebFastRepair.aspx?Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType2=1" :
                                         "WebFastRepair.aspx?FType=1&Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType2=1"
                                         ,
                                         CrLimit = itm.Am1 + itm.Am2 + itm.Am3 + itm.Am4 + itm.Am5 + itm.Am6 + itm.Am7 + itm.Am8 + itm.Am9 + itm.Am10 + itm.Am11 + itm.Am12 + itm.Am13 + itm.Am14 + itm.Am15 + itm.Am16 + itm.Am17 + itm.Am18 + itm.Am19 + itm.Am20 + itm.Am21 + itm.Am22 + itm.Am23 + itm.Am24 + itm.Am25 + itm.Am26 + itm.Am27 + itm.Am28 + itm.Am29 + itm.Am30 + itm.Am31 + itm.Am32,
                                         PayNo = 999
                                         ,
                                         FType2 = itm.VouDate.Substring(3, 7),
                                         Address = GetLocalResourceObject("Repair").ToString()
                                     }).ToList());
                }
                catch
                {

                }
            }


            try
            {
                if (((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("مدير التشغيل") || Session["CurrentUser"].ToString().ToUpper() == "MAI" || ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("admin"))
                {
                    try
                    {
                        PettyCash myPetty = new PettyCash();
                        mydata.AddRange((from itm in myPetty.GetNotAgree(1, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                         where itm.LocType == 2  && itm.VouLoc != 14
                                         select new CostCenter
                                         {
                                             Name1 = string.Format(GetLocalResourceObject("PettyNo").ToString() + " {0}", (itm.LocType == 3 ? "00" : "") + itm.VouLoc.ToString() + "/" + itm.VouNo.ToString())
                                            ,
                                             Name2 = itm.LocType == 2 ? "WebPettyCash.aspx?Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType2=1" :
                                             "WebPettyCash.aspx?FType=1&Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType2=1"
                                            ,FType2 = itm.VouDate.Substring(3, 7)
                                            ,Address = GetLocalResourceObject("Petty").ToString()
                                         }).ToList());
                    }
                    catch
                    {

                    }

                }
            }
            catch
            {

            }





            try
            {
                if (((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("مدير الحسابات") || Session["CurrentUser"].ToString().ToUpper() == "MAI"  || ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("admin"))
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
                                         itm.FType == 1 || itm.FType == 3 || itm.FType == 5 ? GetLocalResourceObject("PurchNo").ToString() + " " : GetLocalResourceObject("PaymentNo").ToString() + " ", itm.LocNumber.ToString() + "/" + itm.Number.ToString(), itm.FType == 1 || itm.FType == 2 ? (itm.LocNumber != 0 ? GetLocalResourceObject("Branch2").ToString() : GetLocalResourceObject("Dep").ToString()) : itm.FType == 3 || itm.FType == 4 ? GetLocalResourceObject("Man").ToString() : GetLocalResourceObject("Emp").ToString()) + @"  " + GetLocalResourceObject("NotPaid").ToString()
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
                                         PayNo = 999,
                                         FType2 = itm.FDate.Substring(3, 7),
                                         Address = itm.FType == 1 || itm.FType == 3 || itm.FType == 5 ? GetLocalResourceObject("Purch").ToString() : GetLocalResourceObject("Payment").ToString()
                                     }).ToList());


                    try
                    {
                        FastRepair myFast = new FastRepair();
                        mydata.AddRange((from itm in myFast.GetNotAgree(3, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                         where DateTime.Parse(itm.VouDate) >= DateTime.Parse("25/10/2020")
                                         select new CostCenter
                                         {
                                             Name1 = string.Format(GetLocalResourceObject("RepairNo").ToString() + " {0}", (itm.LocType == 3 ? "00" : "") + itm.VouLoc.ToString() + "/" + itm.VouNo.ToString())
                                            ,
                                             Name2 = itm.LocType == 2 ? "WebFastRepair.aspx?Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType2=3" :
                                             "WebFastRepair.aspx?FType=1&Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType2=3"
                                             ,
                                             CrLimit = itm.Am1 + itm.Am2 + itm.Am3 + itm.Am4 + itm.Am5 + itm.Am6 + itm.Am7 + itm.Am8 + itm.Am9 + itm.Am10 + itm.Am11 + itm.Am12 + itm.Am13 + itm.Am14 + itm.Am15 + itm.Am16 + itm.Am17 + itm.Am18 + itm.Am19 + itm.Am20 + itm.Am21 + itm.Am22 + itm.Am23 + itm.Am24 + itm.Am25 + itm.Am26 + itm.Am27 + itm.Am28 + itm.Am29 + itm.Am30 + itm.Am31 + itm.Am32,
                                             PayNo = 999
                                            ,
                                             FType2 = itm.VouDate.Substring(3, 7),
                                             Address = GetLocalResourceObject("Repair").ToString()
                                         }).ToList());
                    }
                    catch
                    {

                    }




                    try
                    {
                        PettyCash myPetty = new PettyCash();
                        mydata.AddRange((from itm in myPetty.GetNotAgree(3, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                         where DateTime.Parse(itm.VouDate) >= DateTime.Parse("01/10/2020")
                                         select new CostCenter
                                         {
                                             Name1 = string.Format(GetLocalResourceObject("PettyNo").ToString() + " {0}", (itm.LocType == 3 ? "00" : "") + itm.VouLoc.ToString() + "/" + itm.VouNo.ToString())
                                            ,
                                             Name2 = itm.LocType == 2 ? "WebPettyCash.aspx?Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType2=3" :
                                             "WebPettyCash.aspx?FType=1&Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType2=3"
                                            ,
                                             FType2 = itm.VouDate.Substring(3, 7),
                                             Address = GetLocalResourceObject("Petty").ToString()
                                         }).ToList());
                                                myPetty = new PettyCash();
                                                mydata.AddRange((from itm in myPetty.GetNotAgree(1, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                                                 where itm.LocType == 2 && itm.VouLoc == 14
                                                                 select new CostCenter
                                                                 {
                                                                     Name1 = string.Format(GetLocalResourceObject("PettyNo").ToString() + " {0}", (itm.LocType == 3 ? "00" : "") + itm.VouLoc.ToString() + "/" + itm.VouNo.ToString())
                                                                    ,
                                                                     Name2 = itm.LocType == 2 ? "WebPettyCash.aspx?Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType2=1" :
                                                                     "WebPettyCash.aspx?FType=1&Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType2=1"
                                                                    ,
                                                                     FType2 = itm.VouDate.Substring(3, 7),
                                                                     Address = GetLocalResourceObject("Petty").ToString()
                                                                 }).ToList());

                    }
                    catch
                    {

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
                                 where itm.DocType == 101
                                 select new CostCenter
                                 {
                                     Name1 = string.Format("{0} رقم {1}", itm.Name2, itm.DocNo.ToString())
                                    ,
                                     Name2 = itm.FormName + "?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.DocNo.ToString() + "&FLevel=" + ((int)itm.Status + 1).ToString() + "&FMode=1"
                                    ,
                                     FType2 = itm.DocDate.Substring(3, 7)
                                 }).ToList());
            }
            catch
            {

            }

 */
            if (((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("الحسابات") )
            {
                try
                {
                    Jv myJv = new Jv();
                    myJv.FType = 100;
                    myJv.LocType = -1;
                    mydata.AddRange((from itm in myJv.GetNotAgree(1, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     select new CostCenter
                                     {
                                         Name1 = string.Format(GetLocalResourceObject("JVNo").ToString() + " {0}", itm.Number.ToString())
                                        ,
                                         Name2 = "WebJVou.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0&FType=1"
                                        ,
                                         FType2 = itm.FDate.Substring(3, 7),
                                         Address = GetLocalResourceObject("JV").ToString()
                                     }).ToList());
                }
                catch
                {

                }

                try
                {
                    PettyCash myPetty = new PettyCash();
                    mydata.AddRange((from itm in myPetty.GetNotAgree(2, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     select new CostCenter
                                     {
                                         Name1 = string.Format(GetLocalResourceObject("PettyNo").ToString() + " {0}", (itm.LocType == 3 ? "00" : "") + itm.VouLoc.ToString() + "/" + itm.VouNo.ToString())
                                        ,
                                         Name2 = itm.LocType == 2 ? "WebPettyCash.aspx?Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType2=2" :
                                         "WebPettyCash.aspx?FType=1&Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType2=2"
                                        ,
                                         FType2 = itm.VouDate.Substring(3, 7),
                                         Address = GetLocalResourceObject("Petty").ToString()
                                     }).ToList());


                }
                catch
                {

                }


            }


            if (((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("مدير الحسابات"))
            {
                try
                {
                    Jv myJv = new Jv();
                    myJv.FType = 100;
                    myJv.LocType = -1;
                    mydata.AddRange((from itm in myJv.GetNotAgree(2, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     select new CostCenter
                                     {
                                         Name1 = string.Format(GetLocalResourceObject("JVNo").ToString() + " {0}", itm.Number.ToString())
                                        ,
                                         Name2 = "WebJVou.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0&FType=2"
                                        ,
                                         FType2 = itm.FDate.Substring(3, 7),
                                         Address = GetLocalResourceObject("JV").ToString()
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
                                         Name1 = string.Format(GetLocalResourceObject("BankTransferNo").ToString() + " {0}", itm.Number.ToString())
                                        ,
                                         Name2 = "WebBankTrans.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0&FType=1"
                                        ,
                                         FType2 = itm.FDate.Substring(3, 7),
                                         Address = GetLocalResourceObject("BankTransfer").ToString()
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
                                         Name1 = string.Format(GetLocalResourceObject("ChIssueNo").ToString() + " {0}", itm.Number.ToString())
                                        ,
                                         Name2 = "WebPay12.aspx?FType=2&Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0&FType0=1"
                                        ,
                                         FType2 = itm.FDate.Substring(3, 7),
                                         Address = GetLocalResourceObject("ChIssue").ToString()
                                     }).ToList());
                }
                catch
                {

                }
            }

            if (Session["CurrentUser"].ToString().ToUpper() == "ADMIN" || Session["CurrentUser"].ToString().ToUpper() == "MAI")
            {
                try
                {
                    Jv myJv = new Jv();
                    myJv.FType = 100;
                    myJv.LocType = -1;
                    mydata.AddRange((from itm in myJv.GetNotAgree(2, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     select new CostCenter
                                     {
                                         Name1 = string.Format(GetLocalResourceObject("JVNo").ToString() + " {0}", itm.Number.ToString())
                                        ,
                                         Name2 = "WebJVou.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0&FType=2"
                                        ,
                                         FType2 = itm.FDate.Substring(3, 7),
                                         Address = GetLocalResourceObject("JV").ToString()
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
                                         Name1 = string.Format(GetLocalResourceObject("BankTransferNo").ToString() + " {0}", itm.Number.ToString())
                                        ,
                                         Name2 = "WebBankTrans.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0&FType=2"
                                        ,
                                         FType2 = itm.FDate.Substring(3, 7),
                                         Address = GetLocalResourceObject("BankTransfer").ToString()
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
                                         Name1 = string.Format(GetLocalResourceObject("ChIssueNo").ToString() + " {0}", itm.Number.ToString())
                                        ,
                                         Name2 = "WebPay12.aspx?FType=2&Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.Number.ToString() + "&FMode=0&FType0=2"
                                        ,
                                         FType2 = itm.FDate.Substring(3, 7),
                                         Address = GetLocalResourceObject("ChIssue").ToString()
                                     }).ToList());
                }
                catch
                {

                }
            }
            if(((List<TblRoles>)(Session[vRoleName]))[0].RoleName == "الحسابات") grdPaperAlert.Visible = false;
            if (((List<TblRoles>)(Session[vRoleName]))[0].RoleName.Contains("الحسابات") || ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("admin"))
            {
                try
                {
                    STS mySts = new STS();
                    mydata.AddRange((from itm in mySts.GetNotAgree(2, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     select new CostCenter
                                     {
                                         Name1 = string.Format(GetLocalResourceObject("IssueNo").ToString() + " {0}", itm.VouLoc.ToString() + "/" + itm.VouNo.ToString())
                                        ,
                                         Name2 = "WebIssueNote.aspx?Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType=2"
                                        ,
                                         FType2 = itm.VouDate.Substring(3, 7),
                                         Address = GetLocalResourceObject("Issue").ToString()
                                     }).ToList());

                    STP myStp = new STP();
                    mydata.AddRange((from itm in myStp.GetNotAgree(2, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     select new CostCenter
                                     {
                                         Name1 = string.Format(GetLocalResourceObject("DeliveryNo").ToString() + " {0}", itm.VouLoc.ToString() + "/" + itm.VouNo.ToString())
                                        ,
                                         Name2 = "WebDeliveryNote.aspx?Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType=2"
                                        ,
                                         FType2 = itm.VouDate.Substring(3, 7),
                                         Address = GetLocalResourceObject("Delivery").ToString()
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
                                         Name1 = string.Format(GetLocalResourceObject("RepairNo").ToString() + " {0}", (itm.LocType == 3 ? "00" : "") + itm.VouLoc.ToString() + "/" + itm.VouNo.ToString())
                                        ,
                                         Name2 = itm.LocType == 2 ? "WebFastRepair.aspx?Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType2=2" :
                                         "WebFastRepair.aspx?FType=1&Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + "&FMode=0&FType2=2"
                                         ,
                                         CrLimit = itm.Am1 + itm.Am2 + itm.Am3 + itm.Am4 + itm.Am5 + itm.Am6 + itm.Am7 + itm.Am8 + itm.Am9 + itm.Am10 + itm.Am11 + itm.Am12 + itm.Am13 + itm.Am14 + itm.Am15 + itm.Am16 + itm.Am17 + itm.Am18 + itm.Am19 + itm.Am20 + itm.Am21 + itm.Am22 + itm.Am23 + itm.Am24 + itm.Am25 + itm.Am26 + itm.Am27 + itm.Am28 + itm.Am29 + itm.Am30 + itm.Am31 + itm.Am32,
                                         PayNo = 999
                                        ,
                                         FType2 = itm.VouDate.Substring(3, 7),
                                         Address = GetLocalResourceObject("Repair").ToString()
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
                    if (Cache["ClaimPending" + Session["CNN2"].ToString()] == null)
                    {
                        cl.DocLoc = -1;
                        Cache.Insert("ClaimPending" + Session["CNN2"].ToString(), cl.GetPending(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    }
                        
                    //(((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("مدير التشغيل") ? (short)-1 : short.Parse(AreaNo));
                    //mydata.AddRange((from itm in cl.GetPending(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)

                    mydata.AddRange((from itm in (List<Claim>)(Cache["ClaimPending" + Session["CNN2"].ToString()])
                                     where ((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("مدير التشغيل") || itm.DocLoc == short.Parse(AreaNo)
                                     orderby itm.DocNo
                                     select new CostCenter
                                     {
                                         Name1 = string.Format("{0}  {1} # {2}", GetLocalResourceObject("Claim").ToString(), itm.DocNo.ToString(), itm.CustName.Substring(0, itm.CustName.Length < 15 ? itm.CustName.Length : 15)),
                                         Name2 = "WebClaim.aspx?Flag=0&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + itm.DocNo.ToString(),
                                         CrLimit = itm.amount,
                                         PayNo = 0,
                                         City = itm.CustName
                                        ,
                                         FType2 = itm.DocDate.Substring(3, 7),
                                         Address = GetLocalResourceObject("Claims").ToString()
                                     }).ToList());
                }
                catch
                {

                }
            }

            List<string> vTypes = new List<string>();
            vTypes = (from itm in mydata
                     group itm by new { itm.Address }
                         into g
                         orderby g.Key.Address
                         select g.Key.Address).ToList();

            List<string> vdays = new List<string>();
            vdays = (from itm in mydata                      
                      group itm by new {itm.FType2}
                      into g
                         orderby g.Key.FType2.Substring(3, 4) + "-" + g.Key.FType2.Substring(0,2)
                      select g.Key.FType2).ToList();

            foreach(string s in vdays)
            {
                ddlDays.Items.Add(s);
            }
            ddlDays.Items.Insert(0, new ListItem(GetLocalResourceObject("All").ToString(), "-1", true));

            foreach (string s in vTypes)
            {
                ddlTypes.Items.Add(s);
            }
            ddlTypes.Items.Insert(0, new ListItem(GetLocalResourceObject("All").ToString(), "-1", true));

            PendingDocs = mydata;
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
                Label2.Text = " [ " + (s > 0 ? string.Format("{0:N0}", s) : "") + GetLocalResourceObject("PendingOrders").ToString() + " ] ";
            }
            catch
            {

            }

            LoadInvData();

            ProcessDiv.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass01;
            if ((bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass01)
            {
                ProcessWSTrack();
                ProcessTrackMove();
            }

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
                        LblBanks.Text = " [ " + string.Format("{0:N0}", lcost.Sum(p => p.CrLimit)) + GetLocalResourceObject("Banks").ToString() + " ] ";
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
                    
                    CostCenter myCostCenter = new CostCenter();
                    myCostCenter.Branch = short.Parse(Session["Branch"].ToString());//here pass error
                    if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    Label8.Text = " [ " + string.Format("{0:N0}", lcost.Sum(p => p.CrLimit)) + GetLocalResourceObject("Cash").ToString() + " ] ";
                    int i = 0;
                    foreach (ListItem itm in bllCash.Items)
                    {
                        if (lcost[i].CrLimit < 0) itm.Attributes.Add("style", "color:Red");
                        itm.Attributes.Add("title", lcost[i].City);
                        itm.Attributes.Add("data-title", lcost[i].Location);
                        itm.Attributes.Add("id", lcost[i].Code);
                        double loan = 0;
                        loan = moh.GetLoanBal(lcost[i].Code, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()]));
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
                    Label9.Text = " [ " + string.Format("{0:N0}", lcost.Sum(p => p.CrLimit)) + GetLocalResourceObject("Loan").ToString() + " ] ";
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
                    Label22.Text = " [ " + string.Format("{0:N0}", lcost.Sum(p => p.CrLimit)) + GetLocalResourceObject("Customers").ToString() + " ] ";
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
                    Label7.Text = " [ " + string.Format("{0:N0}", lcost.Sum(p => p.CrLimit)) + GetLocalResourceObject("Vendors").ToString() + " ] ";
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
                    if (Cache["ClaimPending" + Session["CNN2"].ToString()] == null)
                    {
                        cl.DocLoc = -1;
                        Cache.Insert("ClaimPending" + Session["CNN2"].ToString(), cl.GetPending(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    }
                    lcost = (from itm in (List<Claim>)(Cache["ClaimPending" + Session["CNN2"].ToString()])
                             orderby itm.DocNo
                             select new CostCenter
                             {
                                 Name1 = string.Format("{0}  {1} # {2}", GetLocalResourceObject("Claim").ToString(), itm.DocNo.ToString(), itm.CustName.Substring(0, itm.CustName.Length < 15 ? itm.CustName.Length : 15)),
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
                    Label10.Text = " [ " + string.Format("{0:N0}", lcost.Sum(p => p.CrLimit)) + GetLocalResourceObject("PendingClaims").ToString() + " ] ";
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
                    Label11.Text = " [ " + string.Format("{0:N0}", lcost.Sum(p => p.CrLimit)) + GetLocalResourceObject("AccruedExp").ToString() + " ] ";                    
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
                    Label12.Text = " [ " + string.Format("{0:N0}", lcost.Sum(p => p.CrLimit)) + GetLocalResourceObject("InstallmentDue").ToString() + " ] ";
                }
                catch
                {

                }

                lblTime.Text = GetLocalResourceObject("UpdatedIn").ToString() + " " + moh.Nows().ToString();
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
                               Area = itm.VouLoc,
                               Code = "1"
                               ,
                               Name1 = string.Format("{0}  {1}", itm.VouNo.ToString(), itm.GDate.ToString())
                               ,
                               Name2 = "WebInvoice.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FMode=99" + "&FNum=" + itm.VouNo.ToString()
                           }).OrderByDescending(x => x.InvNo).ToList();
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



            if (((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("admin"))
            {
                try
                {
                    TripCollect InvNet = new TripCollect();
                    InvNet.Branch = 1;
                    InvNet.VouLoc = AreaNo;
                    InvNet.Status = 99;
                    mydata2.AddRange((from itm in InvNet.GetStatus2(WebConfigurationManager.ConnectionStrings["MyCnn"].ConnectionString)
                               select new CostCenter
                               {
                                   InvNo = itm.Number,
                                   Area = AreaNo,
                                   Code = "10"
                                   ,
                                   Name1 = string.Format(GetLocalResourceObject("Deliver").ToString() + " {0}  {1}", itm.Number.ToString(), itm.Remark.ToString())
                                   ,
                                   Name2 = "WebTripCol.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FMode=99" + "&FNum=" + itm.Number.ToString()
                               }).OrderByDescending(x => x.InvNo).ToList());

                }
                catch
                {

                }
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
                                      Name2 = "WebEmergInv.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FMode=99" + "&InvNo=" + itm.VouNo.ToString()
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
                                      Name2 = "WebWater.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FMode=99" + "&InvNo=" + itm.VouNo.ToString()
                                  }).OrderByDescending(x => x.InvNo).ToList());
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
                               Area = itm.VouLoc,
                               Code = "4"
                               ,
                               Name1 = string.Format("E{0}  {1}", itm.VouNo.ToString() , itm.GDate.ToString())
                               ,
                               Name2 = "WebShipment.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FMode=99" + "&FNum=" + itm.VouNo.ToString()
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
                                      Name2 = "WebGas.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FMode=99" + "&InvNo=" + itm.VouNo.ToString()
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
                if (Session["CurrentUser"].ToString().ToLower().Contains("admin") || Session["CurrentUser"].ToString().ToLower().Contains("eid222") || Session["CurrentUser"].ToString().ToUpper() == "MAI")
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
            if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            ax.UserName = Session["CurrentUser"].ToString();
            ax = (from itm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                  where itm.UserName == ax.UserName
                  select itm).FirstOrDefault();
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
                if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCost2.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myCost2.Code = AreaNo;
                myCost2 = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                           where citm.Code == myCost2.Code
                           select citm).FirstOrDefault();

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
                lblSMSBal.Text = sms.GetBalance().Split(':')[1] + " " + GetLocalResourceObject("Message").ToString();
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
                if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCost.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myCost.Code = myInv.VouLoc2;
                myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                          where citm.Code == myCost.Code
                          select citm).FirstOrDefault();

                Cities myCity = new Cities();
                myCity.Branch = 1;
                if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myCity.Code = string.IsNullOrEmpty(myInv.PlaceofLoading) ? myInv.FromName : myInv.PlaceofLoading;
                myCity = (from itm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                          where itm.Code == myCity.Code
                          select itm).FirstOrDefault();

                Cities myCity2 = new Cities();
                myCity2.Branch = 1;
                myCity2.Code = string.IsNullOrEmpty(myInv.Destination) ? myInv.ToName : myInv.Destination;
                myCity2 = (from itm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                           where itm.Code == myCity2.Code
                           select itm).FirstOrDefault();

                InvDetails sinv = new InvDetails();
                sinv.Branch = myInv.Branch;
                sinv.VouLoc = myInv.VouLoc;
                sinv.VouNo = myInv.VouNo;
                foreach (InvDetails itm in sinv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    if (option == 0 || (option == 1 && itm.PlateNo == PlateNo) || (option == 2 && itm.ChassisNo == ChassisNo))
                    {
                        myStatus.Add(new CarStatus
                        {
                            ChassisNo = itm.ChassisNo,
                            DocNumber = @"<a target='_blank' href='WebInvoice.aspx?Support=1&FNum=" + itm.VouNo.ToString() + "&AreaNo=" + itm.VouLoc + "&StoreNo=" + StoreNo + "&Flag=0'>" + GetLocalResourceObject("Invoice").ToString() + " " + int.Parse(itm.VouLoc).ToString() + "/" + itm.VouNo.ToString() + @"</a>",
                            PlateNo = itm.PlateNo,
                            TranDate = myInv.RDate,
                            Area = myCity.Name1 + " - " + myCost.Name1,
                            Remark = GetLocalResourceObject("Reserved").ToString() + " " + myInv.RDate 
                        });

                        myStatus.Add(new CarStatus
                        {
                            ChassisNo = itm.ChassisNo,
                            DocNumber = @"<a target='_blank' href='WebInvoice.aspx?Support=1&FNum=" + itm.VouNo.ToString() + "&AreaNo=" + itm.VouLoc + "&StoreNo=" + StoreNo + "&Flag=0'>" + GetLocalResourceObject("Invoice").ToString() + " " + int.Parse(itm.VouLoc).ToString() + "/" + itm.VouNo.ToString() + @"</a>",
                            PlateNo = itm.PlateNo,
                            TranDate = myInv.GDate + " " + myInv.FTime,
                            Area = myCity.Name1 + " - " + myCost.Name1,
                            Remark = GetLocalResourceObject("PickedUp").ToString() + " " + myInv.Name + Environment.NewLine + " - " + GetLocalResourceObject("RCVDest").ToString() + " " + myCity2.Name1
                            
                        });

                        if ((bool)itm.FClosed)
                        {
                            myStatus.Add(new CarStatus
                            {
                                ChassisNo = itm.ChassisNo,
                                DocNumber = @"<a target='_blank' href='WebInvoice.aspx?Support=1&FNum=" + itm.VouNo.ToString() + "&AreaNo=" + itm.VouLoc + "&StoreNo=" + StoreNo + "&Flag=0'>" + GetLocalResourceObject("Invoice").ToString() + " " + int.Parse(itm.VouLoc).ToString() + "/" + itm.VouNo.ToString() + @"</a>",
                                PlateNo = itm.PlateNo,
                                TranDate = itm.ClosedDateTime,
                                Area = myCity.Name1 + " - " + myCost.Name1,
                                Remark = GetLocalResourceObject("ClosedInv").ToString() + " " + itm.ClosedUser + Environment.NewLine + " - " + GetLocalResourceObject("Date").ToString() + " " + itm.ClosedDateTime
                            });
                        }
                    }

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
                        FromCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                    where sitm.Code == FromCity.Code
                                    select sitm).FirstOrDefault();


                        Cities ToCity = new Cities();
                        ToCity.Branch = 1;
                        ToCity.Code = CarMoveitm.ToLoc;
                        ToCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                  where sitm.Code == ToCity.Code
                                  select sitm).FirstOrDefault();

                        Drivers myDrive = new Drivers();
                        myDrive.Branch = 1;
                        if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myDrive.Code = CarMoveitm.DriverCode;
                        myDrive = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                                   where sitm.Code == myDrive.Code
                                   select sitm).FirstOrDefault();

                        Cars myCar = new Cars();
                        myCar.Branch = 1;
                        if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCar.Code = CarMoveitm.CarCode;
                        myCar = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                 where sitm.Code == myCar.Code
                                 select sitm).FirstOrDefault();
                        CostCenter CarMoveArea = new CostCenter();
                        CarMoveArea.Branch = 1;
                        CarMoveArea.Code = CarMoveitm.VouLoc;
                        CarMoveArea = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                       where citm.Code == CarMoveArea.Code
                                       select citm).FirstOrDefault();

                        if (option == 0 || (option == 1 && itm.PlateNo == PlateNo) || (option == 2 && itm.ChassisNo == ChassisNo))
                        myStatus.Add(new CarStatus
                        {
                            ChassisNo = itm.ChassisNo,
                            DocNumber = @"<a target='_blank' href='WebCarMove.aspx?Support=1&FNum=" + CarMoveitm.Number.ToString() + "&AreaNo=" + CarMoveitm.VouLoc + "&StoreNo=" + StoreNo + "&Flag=0'>" + GetLocalResourceObject("CarMove").ToString() + " " + short.Parse(CarMoveitm.VouLoc).ToString() + "/" + CarMoveitm.Number.ToString() + @"</a>",
                            PlateNo = itm.PlateNo,
                            TranDate = CarMoveitm.GDate + " " + CarMoveitm.FTime,
                            Area = FromCity.Name1 + " - " + CarMoveArea.Name1,
                            Remark = (myDrive == null ? (CarMoveitm.RentDriver != null ? GetLocalResourceObject("DriverPickedUp").ToString() + " " + CarMoveitm.RentDriver + " " + GetLocalResourceObject("RentTruck").ToString() + " " + CarMoveitm.RentPlateNo + " - " + GetLocalResourceObject("RCVDest").ToString() + " " + ToCity.Name1 : "")
                            : GetLocalResourceObject("DriverPickedUp").ToString() + " " + myDrive.Name1 + " " + GetLocalResourceObject("InTruck").ToString() + " " + myCar.PlateNo + " - " + GetLocalResourceObject("RCVDest").ToString() + " " + ToCity.Name1)
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
                            CarMoveRCVArea = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                              where citm.Code == CarMoveRCVArea.Code
                                              select citm).FirstOrDefault();

                            if (option == 0 || (option == 1 && itm.PlateNo == PlateNo) || (option == 2 && itm.ChassisNo == ChassisNo))
                            myStatus.Add(new CarStatus
                            {
                                ChassisNo = itm.ChassisNo,
                                DocNumber = @"<a target='_blank' href='WebCarMoveRCV.aspx?Support=1&FNum=" + vCarMoveRCV.Number.ToString() + "&AreaNo=" + moh.MakeMask(vCarMoveRCV.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&Flag=0'>" + GetLocalResourceObject("CarMoveRCV").ToString() + " " + vCarMoveRCV.LocNumber.ToString() + "/" + vCarMoveRCV.Number.ToString() + @"</a>",
                                PlateNo = itm.PlateNo,
                                TranDate = vCarMoveRCV.GDate + " " + vCarMoveRCV.FTime,
                                Area = CarMoveRCVArea.Name1,
                                Remark = CarMoveitm.ToLoc != myInv.Destination ? GetLocalResourceObject("ReachtoTransit").ToString() : GetLocalResourceObject("Reached").ToString()
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
                        CarRcvArea = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                      where citm.Code == CarRcvArea.Code
                                      select citm).FirstOrDefault();

                        if (option == 0 || (option == 1 && itm.PlateNo == PlateNo) || (option == 2 && itm.ChassisNo == ChassisNo))
                        myStatus.Add(new CarStatus
                        {
                            ChassisNo = itm.ChassisNo,
                            DocNumber = @"<a target='_blank' href='WebCarRCV.aspx?Support=1&FNum=" + vCarRcv.Number.ToString() + "&AreaNo=" + moh.MakeMask(vCarRcv.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&Flag=0'>" + GetLocalResourceObject("DeliveryNote").ToString() + " " + vCarRcv.LocNumber.ToString() + "/" + vCarRcv.Number.ToString() + @"</a>",
                            PlateNo = itm.PlateNo,
                            TranDate = vCarRcv.GDate + " " + vCarRcv.GTime,
                            Area = CarRcvArea.Name1,
                            Remark = GetLocalResourceObject("DelivertoCustomer").ToString() + " " + vCarRcv.Customer
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
                if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCost.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myCost.Code = myInv.VouLoc;
                myCost = (from itm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                               where itm.Code == myCost.Code
                               select itm).FirstOrDefault();


                Cities myCity = new Cities();
                myCity.Branch = 1;
                myCity.Code = myInv.PlaceofLoading;
                if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));               
                myCity = (from itm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                               where itm.Code == myInv.PlaceofLoading
                               select itm).FirstOrDefault();

                Cities myCity2 = new Cities();
                myCity2.Branch = 1;
                myCity2.Code = myInv.Destination;
                myCity2 = (from itm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                where itm.Code == myInv.Destination
                                select itm).FirstOrDefault();

                myStatus.Add(new CarStatus
                {
                    ChassisNo = "",
                    DocNumber = @"<a target='_blank' href='WebShipment.aspx?Support=1&FNum=" + myInv.VouNo.ToString() + "&AreaNo=" + myInv.VouLoc + "&StoreNo=" + StoreNo + "&Flag=0'>" + GetLocalResourceObject("Invoice").ToString() + " E" + int.Parse(myInv.VouLoc).ToString() + "/" + myInv.VouNo.ToString() + @"</a>",
                    PlateNo = GetLocalResourceObject("Package").ToString(),
                    TranDate = myInv.GDate + " " + myInv.FTime,
                    Area = myCity.Name1 + " - " + myCost.Name1,
                    Remark = GetLocalResourceObject("PickedUp").ToString() + " " + myInv.Name + Environment.NewLine + " - " + GetLocalResourceObject("RCVDest").ToString() + " " + myCity2.Name1
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
                    FromCity = (from itm2 in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                     where itm2.Code == CarMoveitm.FromLoc
                                     select itm2).FirstOrDefault();

                    Cities ToCity = new Cities();
                    ToCity.Branch = 1;
                    ToCity.Code = CarMoveitm.ToLoc;
                    ToCity = (from itm2 in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                   where itm2.Code == CarMoveitm.ToLoc
                                   select itm2).FirstOrDefault();


                    Drivers myDrive = new Drivers();
                    myDrive.Branch = 1;
                    if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myDrive.Code = CarMoveitm.DriverCode;
                    //myDrive = myDrive.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    myDrive = (from itm2 in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                                    where itm2.Code == CarMoveitm.DriverCode
                                    select itm2).FirstOrDefault();

                    Cars myCar = new Cars();
                    myCar.Branch = 1;
                    myCar.Code = CarMoveitm.CarCode;
                    myCar = (from itm2 in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                  where itm2.Code == CarMoveitm.CarCode
                                  select itm2).FirstOrDefault();

                    CostCenter CarMoveArea = new CostCenter();
                    CarMoveArea.Branch = 1;
                    if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), CarMoveArea.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    CarMoveArea.Code = CarMoveitm.VouLoc;
                    CarMoveArea = (from itm2 in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                        where itm2.Code == CarMoveitm.VouLoc
                                        select itm2).FirstOrDefault();

                    myStatus.Add(new CarStatus
                    {
                        ChassisNo = "",
                        DocNumber = @"<a target='_blank' href='WebCarMove.aspx?Support=1&FNum=" + CarMoveitm.Number.ToString() + "&AreaNo=" + CarMoveitm.VouLoc + "&StoreNo=" + StoreNo + "&Flag=0'>" + GetLocalResourceObject("CarMove").ToString() + " " + short.Parse(CarMoveitm.VouLoc).ToString() + "/" + CarMoveitm.Number.ToString() + @"</a>",
                        PlateNo = GetLocalResourceObject("Package").ToString(),
                        TranDate = CarMoveitm.GDate + " " + CarMoveitm.FTime,
                        Area = FromCity.Name1 + " - " + CarMoveArea.Name1,
                        Remark = (myDrive == null ? (CarMoveitm.RentDriver != null ? GetLocalResourceObject("DriverPickedUp").ToString() + " " + CarMoveitm.RentDriver + " " + GetLocalResourceObject("RentTruck").ToString() + " " + CarMoveitm.RentPlateNo + " - " + GetLocalResourceObject("RCVDest").ToString() + " " + ToCity.Name1 : "")
                        : GetLocalResourceObject("DriverPickedUp").ToString() + " " + myDrive.Name1 + " " + GetLocalResourceObject("InTruck").ToString() + " " + myCar.PlateNo + " -  " + GetLocalResourceObject("RCVDest").ToString() + " " + ToCity.Name1)
                    });

                    CarMoveRCV vCarMoveRCV = new CarMoveRCV();
                    vCarMoveRCV.Branch = 1;
                    vCarMoveRCV.CarMove = short.Parse(CarMoveitm.VouLoc).ToString() + "/" + CarMoveitm.Number.ToString();
                    vCarMoveRCV = vCarMoveRCV.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (vCarMoveRCV != null)
                    {
                        CostCenter CarMoveRCVArea = new CostCenter();
                        CarMoveRCVArea.Branch = 1;
                        if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), CarMoveRCVArea.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        CarMoveRCVArea.Code = moh.MakeMask(vCarMoveRCV.LocNumber.ToString(), 5);
                        CarMoveRCVArea = (from itm2 in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                               where itm2.Code == CarMoveRCVArea.Code
                                               select itm2).FirstOrDefault();

                        myStatus.Add(new CarStatus
                        {
                            ChassisNo = "",
                            DocNumber = @"<a target='_blank' href='WebCarMoveRCV.aspx?Support=1&FNum=" + vCarMoveRCV.Number.ToString() + "&AreaNo=" + moh.MakeMask(vCarMoveRCV.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&Flag=0'>" + GetLocalResourceObject("CarMoveRCV").ToString() + " " + vCarMoveRCV.LocNumber.ToString() + "/" + vCarMoveRCV.Number.ToString() + @"</a>",
                            PlateNo = GetLocalResourceObject("Package").ToString(),
                            TranDate = vCarMoveRCV.GDate + " " + vCarMoveRCV.FTime,
                            Area = CarMoveRCVArea.Name1,
                            Remark = CarMoveitm.ToLoc != myInv.Destination ? GetLocalResourceObject("ReachtoTransit").ToString() : GetLocalResourceObject("Reached").ToString()
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
                    CarRcvArea = (from itm2 in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                       where itm2.Code == CarRcvArea.Code
                                       select itm2).FirstOrDefault();

                    myStatus.Add(new CarStatus
                    {
                        ChassisNo = "",
                        DocNumber = @"<a target='_blank' href='WebCarRCV.aspx?Support=1&FNum=" + vCarRcv.Number.ToString() + "&AreaNo=" + moh.MakeMask(vCarRcv.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&Flag=0'>" + GetLocalResourceObject("DeliveryNote").ToString() + " " + vCarRcv.LocNumber.ToString() + "/" + vCarRcv.Number.ToString() + @"</a>",
                        PlateNo = GetLocalResourceObject("Package").ToString(),
                        TranDate = vCarRcv.GDate + " " + vCarRcv.GTime,
                        Area = CarRcvArea.Name1,
                        Remark = GetLocalResourceObject("DelivertoCustomer").ToString() + " " + vCarRcv.Customer
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
                if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCost.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myCost.Code = myInv.VouLoc;
                myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                          where citm.Code == myCost.Code
                          select citm).FirstOrDefault();

                Cities myCity = new Cities();
                myCity.Branch = 1;
                if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myCity.Code = myInv.PlaceofLoading;
                myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                          where sitm.Code == myCity.Code
                          select sitm).FirstOrDefault();

                Cities myCity2 = new Cities();
                myCity2.Branch = 1;
                myCity2.Code = myInv.Destination;
                myCity2 = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                           where sitm.Code == myCity2.Code
                           select sitm).FirstOrDefault();

                ShipDetails sinv = new ShipDetails();
                sinv.Branch = myInv.Branch;
                sinv.VouLoc = myInv.VouLoc;
                sinv.VouNo = myInv.VouNo;
                foreach (ShipDetails itm in sinv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    myStatus.Add(new CarStatus
                    {
                        ChassisNo = itm.Qty.ToString(),
                        DocNumber = @"<a target='_blank' href='WebLShipment.aspx?Support=1&FNum=" + itm.VouNo.ToString() + "&AreaNo=" + itm.VouLoc + "&StoreNo=" + StoreNo + "&Flag=0'>" + GetLocalResourceObject("Invoice").ToString() + " " + int.Parse(itm.VouLoc).ToString() + "/" + itm.VouNo.ToString() + @"</a>",
                        PlateNo = itm.Name,
                        TranDate = myInv.GDate + " " + myInv.FTime,
                        Area = myCity.Name1 + " - " + myCost.Name1,
                        Remark = GetLocalResourceObject("PickedUp").ToString() + " " + myInv.Name + Environment.NewLine + " - " + GetLocalResourceObject("RCVDest").ToString() + " " + myCity2.Name1
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
                        FromCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                    where sitm.Code == FromCity.Code
                                    select sitm).FirstOrDefault();

                        Cities ToCity = new Cities();
                        ToCity.Branch = 1;
                        ToCity.Code = CarMoveitm.ToLoc;
                        ToCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                  where sitm.Code == ToCity.Code
                                  select sitm).FirstOrDefault();

                        Drivers myDrive = new Drivers();
                        myDrive.Branch = 1;
                        if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myDrive.Code = CarMoveitm.DriverCode;
                        myDrive = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                                   where sitm.Code == myDrive.Code
                                   select sitm).FirstOrDefault();

                        Cars myCar = new Cars();
                        myCar.Branch = 1;
                        myCar.Code = CarMoveitm.CarCode;
                        myCar = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                 where sitm.Code == myCar.Code
                                 select sitm).FirstOrDefault();

                        CostCenter CarMoveArea = new CostCenter();
                        CarMoveArea.Branch = 1;
                        CarMoveArea.Code = CarMoveitm.VouLoc;
                        CarMoveArea = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                       where citm.Code == CarMoveArea.Code
                                       select citm).FirstOrDefault();

                        myStatus.Add(new CarStatus
                        {
                            ChassisNo = itm.Qty.ToString(),
                            DocNumber = @"<a target='_blank' href='WebCarMove.aspx?Support=1&FNum=" + CarMoveitm.Number.ToString() + "&AreaNo=" + CarMoveitm.VouLoc + "&StoreNo=" + StoreNo + "&Flag=0'>" + GetLocalResourceObject("CarMove").ToString() + " " + short.Parse(CarMoveitm.VouLoc).ToString() + "/" + CarMoveitm.Number.ToString() + @"</a>",
                            PlateNo = itm.Name,
                            TranDate = CarMoveitm.GDate + " " + CarMoveitm.FTime,
                            Area = FromCity.Name1 + " - " + CarMoveArea.Name1,
                            Remark = (myDrive == null ? (CarMoveitm.RentDriver != null ? GetLocalResourceObject("DriverPickedUp").ToString() + " " + CarMoveitm.RentDriver + " " + GetLocalResourceObject("RentTruck").ToString() + " " + CarMoveitm.RentPlateNo + " - " + GetLocalResourceObject("RCVDest").ToString() + " " + ToCity.Name1 : "")
                            : GetLocalResourceObject("DriverPickedUp").ToString() + " " + myDrive.Name1 + " " + GetLocalResourceObject("InTruck").ToString() + " " + myCar.PlateNo + " - " + GetLocalResourceObject("RCVDest").ToString() + " " + ToCity.Name1)
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
                            CarMoveRCVArea = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                              where citm.Code == CarMoveRCVArea.Code
                                              select citm).FirstOrDefault();

                            myStatus.Add(new CarStatus
                            {
                                ChassisNo = itm.Qty.ToString(),
                                DocNumber = @"<a target='_blank' href='WebCarMoveRCV.aspx?Support=1&FNum=" + vCarMoveRCV.Number.ToString() + "&AreaNo=" + moh.MakeMask(vCarMoveRCV.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&Flag=0'>" + GetLocalResourceObject("CarMoveRCV").ToString() + " " + vCarMoveRCV.LocNumber.ToString() + "/" + vCarMoveRCV.Number.ToString() + @"</a>",
                                PlateNo = itm.Name,
                                TranDate = vCarMoveRCV.GDate + " " + vCarMoveRCV.FTime,
                                Area = CarMoveRCVArea.Name1,
                                Remark = CarMoveitm.ToLoc != myInv.Destination ? GetLocalResourceObject("ReachtoTransit").ToString() : GetLocalResourceObject("Reached").ToString()
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
                        CarRcvArea = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                      where citm.Code == CarRcvArea.Code
                                      select citm).FirstOrDefault();

                        myStatus.Add(new CarStatus
                        {
                            ChassisNo = itm.Qty.ToString(),
                            DocNumber = @"<a target='_blank' href='WebCarRCV.aspx?Support=1&FNum=" + vCarRcv.Number.ToString() + "&AreaNo=" + moh.MakeMask(vCarRcv.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&Flag=0'>" + GetLocalResourceObject("DeliveryNote").ToString() + " " + vCarRcv.LocNumber.ToString() + "/" + vCarRcv.Number.ToString() + @"</a>",
                            PlateNo = itm.Name,
                            TranDate = vCarRcv.GDate + " " + vCarRcv.GTime,
                            Area = CarRcvArea.Name1,
                            Remark = GetLocalResourceObject("DelivertoCustomer").ToString() + " " + vCarRcv.Customer
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


        public void ProcessWSTrack()
        {
            if (HttpRuntime.Cache["WSOverCarMove_" + StoreNo + Session["CNN2"].ToString()] == null)
            {
                WSCarMoveData.Clear();
                WSCarInMoveData.Clear();
                WSCarOutMoveData.Clear();
                SetWSCarMove(AreaNo);
            }
            WSCarMoveData = (List<vRepairReq>)(HttpRuntime.Cache["WSOverCarMove_" + StoreNo + Session["CNN2"].ToString()]);
            WSCarInMoveData = (List<vRepairReq>)(HttpRuntime.Cache["WSOverInCarMove_" + StoreNo + Session["CNN2"].ToString()]);
            WSCarOutMoveData = (List<vRepairReq>)(HttpRuntime.Cache["WSOverOutCarMove_" + StoreNo + Session["CNN2"].ToString()]);

            this.grdWSTrackMove.DataSource = WSCarMoveData;
            this.grdWSTrackMove.DataBind();

            this.grdWSInTrackMove.DataSource = WSCarInMoveData;
            this.grdWSInTrackMove.DataBind();

        }


        public void CheckTrack(List<TrackMove> lTrack)
        {
            foreach (TrackMove itm in lTrack)
            {
                foreach (vRepairReq sitm in WSCarMoveData)
                {
                    if (sitm.Vehicle == itm.Code && !itm.CarMoveFromLoc.Contains(GetLocalResourceObject("WorkShop").ToString()))
                    {
                        itm.CarMoveFromLoc += @"<br/>(" + GetLocalResourceObject("ThroughWorkShop").ToString() + ")";
                        itm.RCVFTime = @"<br/>(" + GetLocalResourceObject("ThroughWorkShop").ToString() + ")";
                    }
                }

                foreach (vRepairReq sitm in WSCarInMoveData)
                {
                    if (sitm.Vehicle == itm.Code && !itm.CarMoveFromLoc.Contains(GetLocalResourceObject("WorkShop").ToString()))
                    {
                        itm.CarMoveFromLoc += @"<br/>(" + GetLocalResourceObject("ThroughWorkShop").ToString() + ")";
                        itm.RCVFTime = @"<br/>(" + GetLocalResourceObject("ThroughWorkShop").ToString() + ")";
                    }
                }
            }
        }


        public void ProcessTrackMove()
        {
            //try
            //{
            if (HttpRuntime.Cache["OverTrack_" + AreaNo + Session["CNN2"].ToString()] != null)
                {
                    MyOverTrack = (List<TrackMove>)(HttpRuntime.Cache["OverTrack_" + AreaNo + Session["CNN2"].ToString()]);
                    CheckTrack(MyOverTrack);
                    grdTrackMove.DataSource = MyOverTrack;
                    grdTrackMove.DataBind();

                    MyOverTrack2 = (List<TrackMove>)(HttpRuntime.Cache["OverTrack2_" + AreaNo + Session["CNN2"].ToString()]);
                    CheckTrack(MyOverTrack2);
                    grdTrackMove2.DataSource = (from itm in MyOverTrack2
                                                where !itm.CarMoveFromLoc.Contains(GetLocalResourceObject("Through").ToString())
                                                select itm).ToList();
                    grdTrackMove2.DataBind();

                    MyOverTrack1 = (List<TrackMove>)(HttpRuntime.Cache["OverTrack1_" + AreaNo + Session["CNN2"].ToString()]);
                    CheckTrack(MyOverTrack1);
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
                    if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), Drive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    dr = (from itm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                          where (bool)itm.Status
                          select itm).ToList();

                    List<Cities> lcity = new List<Cities>();
                    Cities myCity = new Cities();
                    myCity.Branch = 1;
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    lcity = (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()]);

                    List<Cities> lc = new List<Cities>();
                    Cities mc = new Cities();
                    mc.Branch = 1;
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), mc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    lc = mc.GetMySites(AreaNo, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()]),(List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()]));

                    int i = 1;
                    int i1 = 1;
                    int i2 = 1;
                    Cars myCar = new Cars();
                    myCar.Branch = 1;
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myCar.CarsType = 1;
                    foreach (Cars itm in (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                          where (sitm.CarsType == 1 || sitm.CarsType == 3 || sitm.CarsType == 32 || sitm.CarsType == 33) && (bool)sitm.Status
                                          orderby sitm.PlateNo
                                          select sitm
                                          ).ToList())
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
                                            DriverCode = cm.DriverCode,
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
                                            DriverCode = cm.DriverCode,
                                            Driver = (from d in dr
                                                      where d.Code == cm.DriverCode
                                                      select d.Name1).FirstOrDefault(),
                                            CarMoveRCVNo = Rcv.LocNumber.ToString() + "/" + Rcv.Number.ToString(),
                                            CarMoveRCVDate = Rcv.GDate,
                                            CarMoveRCVFTime = Rcv.FTime,
                                            Status = GetLocalResourceObject("Reached").ToString()
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
                                            DriverCode = cm.DriverCode,
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

                    CostCenter myCostCenter = new CostCenter();
                    myCostCenter.Branch = 1;
                    if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    CarMove mycm = new CarMove();
                    mycm.VouLoc = AreaNo;
                    foreach (CarMove cr in mycm.CarMoveNotRcv(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString,(List<CostCenter>)(HttpRuntime.Cache["LastCostCenter" + Session["CNN2"].ToString()])))
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
                                            Code = GetLocalResourceObject("Rent").ToString(),
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
                                            DriverCode = cr.DriverCode,
                                            Driver = cr.RentDriver + " " + cr.RentValue.ToString() + " " + GetLocalResourceObject("SR").ToString() + " ",
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
                                    Code = GetLocalResourceObject("Rent").ToString(),
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
                                    DriverCode = cr.DriverCode,
                                    Driver = cr.RentDriver + " " + cr.RentValue.ToString() + " " + GetLocalResourceObject("SR").ToString() + " "
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
                    CheckTrack(MyOverTrack);
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
                    CheckTrack(MyOverTrack2);
                    grdTrackMove2.DataSource = (from itm in MyOverTrack2
                                                where !itm.CarMoveFromLoc.Contains(GetLocalResourceObject("Through").ToString())
                                                select itm).ToList();
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
                    CheckTrack(MyOverTrack1);
                    grdTrackMove1.DataSource = MyOverTrack1;
                    grdTrackMove1.DataBind();
                }

            CostCenter myCost = new CostCenter();
            myCost.Branch = 1;
            if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCost.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            ddlBranch.DataTextField = "Name1";
            ddlBranch.DataValueField = "Code";

            ddlBranch.DataSource = (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()]);
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

        public void SetWSCarMove(string myArea)
        {
            RepairReq rq = new RepairReq();
            if (HttpRuntime.Cache["WSOverCarMove_" + StoreNo + Session["CNN2"].ToString()] != null) Cache.Remove("WSOverCarMove_" + StoreNo + Session["CNN2"].ToString());
            if (HttpRuntime.Cache["WSOverInCarMove_" + StoreNo + Session["CNN2"].ToString()] != null) Cache.Remove("WSOverInCarMove_" + StoreNo + Session["CNN2"].ToString());
            if (HttpRuntime.Cache["WSOverOutCarMove_" + StoreNo + Session["CNN2"].ToString()] != null) Cache.Remove("WSOverOutCarMove_" + StoreNo + Session["CNN2"].ToString());

            Cache.Insert("WSOverCarMove_" + StoreNo + Session["CNN2"].ToString(), rq.GetAllNotJobWork(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            Cache.Insert("WSOverInCarMove_" + StoreNo + Session["CNN2"].ToString(), rq.GetAllInJobWork(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            Cache.Insert("WSOverOutCarMove_" + StoreNo + Session["CNN2"].ToString(), rq.GetAllNotJobWork(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
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

            TripCollect tinv = new TripCollect();
            tinv.Branch = 1;
            tinv.VouLoc = myArea;
            myInv.AddRange(tinv.GetTripMove(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

            CostCenter myCost = new CostCenter();
            myCost.Branch = 1;
            if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCost.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            myCost.Code = myArea;
            myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                      where citm.Code == myCost.Code
                      select citm).FirstOrDefault();

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


            myInv = myInv.OrderBy(c => c.Destination + "-" + c.VouLoc.ToString() + "-" + c.VouNo.ToString() + "-" + c.InvoiceFNo.ToString()).ToList();
            i = 1;
            foreach (myInv2 itm in myInv)
            {
                itm.FNo = i++;
            }




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
                b.Append("<center><b>" + HttpContext.GetLocalResourceObject("~/App_LocalResources/Default.aspx", "ViewCarMoveNo").ToString() + " " + contextKey + "</b></center>");
                b.Append("</td></tr>");
                b.Append("<tr><td  style='text-align:center;width:25px;'><b>م</b></td>");
                b.Append("<td style='text-align:center;width:200px;'><b>" + HttpContext.GetLocalResourceObject("~/App_LocalResources/Default.aspx", "Sender").ToString() + "</b></td>");
                b.Append("<td style='text-align:center;width:100px;'><b>" + HttpContext.GetLocalResourceObject("~/App_LocalResources/Default.aspx", "FType4").ToString() + "</b></td>");
                b.Append("<td style='text-align:center;width:150px;'><b>" + HttpContext.GetLocalResourceObject("~/App_LocalResources/Default.aspx", "CarType").ToString() + "</b></td>");
                b.Append("<td style='text-align:center;width:150px;'><b>" + HttpContext.GetLocalResourceObject("~/App_LocalResources/Default.aspx", "PlateNo").ToString() + "</b></td>");
                b.Append("<td style='text-align:center;width:150px;'><b>" + HttpContext.GetLocalResourceObject("~/App_LocalResources/Default.aspx", "Taraz").ToString() + "</b></td>");
                b.Append("<td style='text-align:center;width:200px;'><b>" + HttpContext.GetLocalResourceObject("~/App_LocalResources/Default.aspx", "Receiver").ToString() + "</b></td>");
                b.Append("<td style='text-align:center;width:125px;'><b>" + HttpContext.GetLocalResourceObject("~/App_LocalResources/Default.aspx", "Dest").ToString() + "</b></td></tr>");
                b.Append("<tr><td colspan='8'><center><b>" + HttpContext.GetLocalResourceObject("~/App_LocalResources/Default.aspx", "WithoutCars").ToString() + "</b></center>");
                b.Append("</td></tr>");
                b.Append("</table>");
                return b.ToString();
            }
        }

        protected void grdTrackMove_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (DataControlRowType.DataRow == e.Row.RowType)
            {
                if (DataBinder.Eval(e.Row.DataItem, "Code").ToString() == GetLocalResourceObject("Rent").ToString())
                {
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Green;
                }
                if (DataBinder.Eval(e.Row.DataItem, "CarMoveFromLoc").ToString().Contains(GetLocalResourceObject("WorkShops").ToString()))
                {
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                }
                if (DataBinder.Eval(e.Row.DataItem, "CarMoveToLoc").ToString().Contains(GetLocalResourceObject("WorkShops").ToString()))
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

        protected void grdWSTrackMove_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                PopupControlExtender pce = e.Row.FindControl("PopupControlExtender100") as PopupControlExtender;
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

        protected void grdWSInTrackMove_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                PopupControlExtender pce = e.Row.FindControl("PopupControlExtender101") as PopupControlExtender;
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

        protected void grdWSOutTrackMove_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                PopupControlExtender pce = e.Row.FindControl("PopupControlExtender102") as PopupControlExtender;
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
                        case 8: return (vs[0].StartsWith("00") ?
                                 "~/WebRepairReq.aspx?FType=1&Flag=0&FNum=" + vs[1] + "&AreaNo=" + AreaNo + "&StoreNo=" + int.Parse(moh.MakeMask(vs[0], 5)).ToString()
                                :  "~/WebRepairReq.aspx?Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&StoreNo=" + StoreNo);
                        case 9: return "~/WebJobOrder.aspx?FMode=0&Flag=0&FNum=" + vs[1] + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo;
                        case 90: return "~/WebJobOrder.aspx?FMode=99&Flag=0&FNum=" + Number.ToString() + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&StoreNo=" + StoreNo;
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
            if (HttpRuntime.Cache["WSOverCarMove_" + StoreNo + Session["CNN2"].ToString()] != null) Cache.Remove("WSOverCarMove_" + StoreNo + Session["CNN2"].ToString());
            if (HttpRuntime.Cache["WSOverInCarMove_" + StoreNo + Session["CNN2"].ToString()] != null) Cache.Remove("WSOverInCarMove_" + StoreNo + Session["CNN2"].ToString());
            if (HttpRuntime.Cache["WSOverOutCarMove_" + StoreNo + Session["CNN2"].ToString()] != null) Cache.Remove("WSOverOutCarMove_" + StoreNo + Session["CNN2"].ToString());
            ProcessWSTrack();
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
                if (ts.Days < 7) return GetLocalResourceObject("NoLand").ToString();
                else if (ts.Days == 7 && ts.Hours < 1) return GetLocalResourceObject("NoLand").ToString();
                else
                {
                    double value = (ts.Days - 7) * (double)SiteInfo.LandDay + ts.Hours * (double)SiteInfo.LandHour;
                    return string.Format("{0:N0} " + GetLocalResourceObject("Land").ToString(), value);
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
            string result = string.Format("{0} \t {1} \t {2}      \t {3}          \t {4}      \t {5} \n", moh.MakeSize(GetLocalResourceObject("Doc2").ToString(), 12), moh.MakeSize(GetLocalResourceObject("TruckNo").ToString(), 6), moh.MakeSize(GetLocalResourceObject("FDate").ToString() + "    ", 12), moh.MakeSize(GetLocalResourceObject("Amount").ToString(), 12), GetLocalResourceObject("Balance").ToString(), moh.MakeSize(GetLocalResourceObject("Descr").ToString(), 20));
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
                                                               "WebPay1.aspx?FType=200&FNum=" + Number + "&LocNumber=" + LocNumber + "&LocType=" + LocType + "&AreaNo=" + moh.MakeMask(LocNumber, 5) + "&StoreNo=" + StoreNo + "&Flag=0";
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
            b.Append("<img src='images/close.png' onclick='fnClose();'/><center><b>" + GetLocalResourceObject("Descr").ToString() + "    " + AccountName + "</b></center>");
            b.Append("</td></tr>");
            b.Append("<td style='text-align:center;width:100px;'><b>" + GetLocalResourceObject("Doc2").ToString() + "</b></td>");
            b.Append("<td style='text-align:center;width:100px;'><b>" + GetLocalResourceObject("TruckNo").ToString() + "</b></td>");
            b.Append("<td style='text-align:center;width:100px;'><b>" + GetLocalResourceObject("FDate").ToString() + "</b></td>");
            b.Append("<td style='text-align:center;width:100px;'><b>" + GetLocalResourceObject("Debit").ToString() + "</b></td>");
            b.Append("<td style='text-align:center;width:100px;'><b>" + GetLocalResourceObject("Credit").ToString() + "</b></td>");
            b.Append("<td style='text-align:center;width:100px;'><b>" + GetLocalResourceObject("Balance").ToString() + "</b></td>");
            b.Append("<td style='text-align:center;width:400px;'><b>" + GetLocalResourceObject("Descr").ToString() + "</b></td></tr>");

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
                if (DataBinder.Eval(e.Row.DataItem, "Code").ToString() == GetLocalResourceObject("Rent").ToString())
                {
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Green;
                }
                if (DataBinder.Eval(e.Row.DataItem, "CarMoveFromLoc").ToString().Contains(GetLocalResourceObject("WorkShops").ToString()))
                {
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                }
                if (DataBinder.Eval(e.Row.DataItem, "CarMoveToLoc").ToString().Contains(GetLocalResourceObject("WorkShops").ToString()))
                {
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void grdTrackMove2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (DataControlRowType.DataRow == e.Row.RowType)
            {
                if (DataBinder.Eval(e.Row.DataItem, "Code").ToString() == GetLocalResourceObject("Rent").ToString())
                {
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Green;
                }
                if (DataBinder.Eval(e.Row.DataItem, "CarMoveFromLoc").ToString().Contains(GetLocalResourceObject("WorkShops").ToString()))
                {
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                }
                if (DataBinder.Eval(e.Row.DataItem, "CarMoveToLoc").ToString().Contains(GetLocalResourceObject("WorkShops").ToString()))
                {
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                }
            }

        }

        protected void grdWSTrackMove_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (DataControlRowType.DataRow == e.Row.RowType)
            {
                if (DataBinder.Eval(e.Row.DataItem, "Code").ToString() == GetLocalResourceObject("Rent").ToString())
                {
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Green;
                }
                if (DataBinder.Eval(e.Row.DataItem, "CarMoveFromLoc").ToString().Contains(GetLocalResourceObject("WorkShops").ToString()))
                {
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                }
                if (DataBinder.Eval(e.Row.DataItem, "CarMoveToLoc").ToString().Contains(GetLocalResourceObject("WorkShops").ToString()))
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


        public string getStartData(short Task)
        {
            string htmlStr = "";
            TblStart myStart = new TblStart();
            myStart.FType = Task;
            foreach(TblStart itm in (List<TblStart>)Cache["Starter" + Session["CNN2"].ToString()])
            {
                if (itm.FType == Task && itm.Fd1 != "")
                {
                    if(Task == 1) htmlStr += "<tr><td>" + itm.Fd1 + "</td><td>" + itm.Fd2 + "</td><td>" + itm.Fd3 + "</td></tr>";
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

        protected void ddlDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<CostCenter> mydata = new List<CostCenter>();
            if (ddlDays.SelectedIndex == 0 && ddlTypes.SelectedIndex == 0)
            {
                mydata = PendingDocs;
            }
            else
            {
                mydata = (from itm in PendingDocs
                          where  (ddlDays.SelectedIndex==0 || itm.FType2 == ddlDays.SelectedValue) && (ddlTypes.SelectedIndex == 0 || itm.Address == ddlTypes.SelectedValue)
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
                Label2.Text = " [ " + (s > 0 ? string.Format("{0:N0}", s) : "") + " " + GetLocalResourceObject("PendingOrders").ToString() + " ] ";
            }
            catch
            {

            }

        }


        protected void BtnClear_Click(object sender, ImageClickEventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

    }
}