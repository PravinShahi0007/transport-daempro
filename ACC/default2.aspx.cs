using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using BLL;
using System.Web.Configuration;
using System.Configuration;

namespace ACC
{
    public partial class default2 : System.Web.UI.Page
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
        public string StoreNo
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

                    if (Request.QueryString["StoreNo"] != null) StoreNo = Request.QueryString["StoreNo"].ToString();
                    else StoreNo = Session["StoreNo"].ToString();
                    if ((bool)Session["DispMessage"])
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(
                        "أهلا وسهلا بك " + Session["FullUser"].ToString() + " في نظام الناقلات البرية", false, false), true);
                        Session.Add("DispMessage", false);
                    }
                }
            }
            catch
            {
            }

        }

        /*
        public void ProcessTrackMove()
        {
            if (HttpRuntime.Cache["OverTrack2_" + AreaNo + Session["CNN2"].ToString()] == null)
            {
                List<TrackMove> MyOverTrack2 = new List<TrackMove>();

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
                                if (Rcv != null)
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
                                        Status = "تم الوصول"
                                    });
                                }
                            }
                        }
                    }
                }


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
            }
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


        public void CheckTrack(List<TrackMove> lTrack)
        {
            foreach (TrackMove itm in lTrack)
            {
                foreach (vRepairReq sitm in WSCarMoveData)
                {
                    if (sitm.Vehicle == itm.Code && !itm.CarMoveFromLoc.Contains("الورشة"))
                    {
                        itm.CarMoveFromLoc += @"<br/>(مروراً بالورشة)";
                        itm.RCVFTime = @"<br/>(مروراً بالورشة)";
                    }
                }

                foreach (vRepairReq sitm in WSCarInMoveData)
                {
                    if (sitm.Vehicle == itm.Code && !itm.CarMoveFromLoc.Contains("الورشة"))
                    {
                        itm.CarMoveFromLoc += @"<br/>(مروراً بالورشة)";
                        itm.RCVFTime = @"<br/>(مروراً بالورشة)";
                    }
                }
            }
        }
         */


    }
}