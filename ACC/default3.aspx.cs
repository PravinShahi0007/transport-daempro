using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using BLL;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class default3 : System.Web.UI.Page
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
                    ViewState["StoreNo"] = "00001";
                }
                return ViewState["StoreNo"].ToString();
            }
            set { ViewState["StoreNo"] = value; }
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
        public List<vCarRcvSite> OverCarsIn
        {
            get
            {
                if (ViewState["OverCarsIn"] == null)
                {
                    ViewState["OverCarsIn"] = new List<vCarRcvSite>();
                }
                return (List<vCarRcvSite>)ViewState["OverCarsIn"];
            }
            set
            {
                ViewState["OverCarsIn"] = value;

            }
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
                    this.Page.Header.Title = GetLocalResourceObject("Title").ToString(); // "سيارات جاهزة للتسليم";

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

                    CostCenter myCostCenter = new CostCenter();
                    myCostCenter.Branch = 1;
                    if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlBranch.DataTextField = "Name1";
                    ddlBranch.DataValueField = "Code";
                    ddlBranch.DataSource = (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()]);
                    ddlBranch.DataBind();
                    //ddlBranch.Items.Insert(0, new ListItem("جميع الفروع", "-1", true));            
                    ddlBranch.SelectedValue = AreaNo;
                    ddlBranch.Enabled = (Request.QueryString["Support"] != null);
                    ProcessTrackMove(ddlBranch.SelectedValue);
                }
            }
            catch
            {
            }
        }

        protected void BtnRefresh2_Click(object sender, EventArgs e)
        {
            if (HttpRuntime.Cache["OverCarsIn_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarsIn_" + AreaNo + Session["CNN2"].ToString());
            ProcessTrackMove(ddlBranch.SelectedValue);
        }

        public void ProcessTrackMove(string AreaNo2)
        {
            if (HttpRuntime.Cache["OverCarsIn_" + AreaNo2 + Session["CNN2"].ToString()] == null)
            {
                vCarRcvSite vCarSite = new vCarRcvSite();
                vCarSite.RCVLocNumber = short.Parse(AreaNo2);
                Cache.Insert("OverCarsIn_" + AreaNo2 + Session["CNN2"].ToString(), vCarSite.Get22(int.Parse(RadioButtonList1.SelectedValue),WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            }

            OverCarsIn = (List<vCarRcvSite>)(HttpRuntime.Cache["OverCarsIn_" + AreaNo2 + Session["CNN2"].ToString()]);
            grdDCars.DataSource = OverCarsIn;
            grdDCars.DataBind();
        }

        protected string UrlHelper(object FType, object Number)
        {
            if (Number != null)
            {
                string[] vs = Number.ToString().Split('/');
                if (vs.Count() > 1)
                {
                    if (Request.QueryString["Support"] == null)
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
                            default: return "";
                        }
                    }
                    else
                    {
                        switch (short.Parse(FType.ToString()))
                        {
                            case 1: return "~/WebCarMove.aspx?Support=1&Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&StoreNo=" + StoreNo;
                            case 2: return "~/WebCarMoveRCV.aspx?Support=1&Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&StoreNo=" + StoreNo;
                            case 3:
                                {
                                    if (vs[0][0] == 'L') return "~/WebLShipment.aspx?Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0].Substring(1, vs[0].Length - 1), 5) + "&StoreNo=" + StoreNo;
                                    else if (vs[0][0] == 'E') return "~/WebShipment.aspx?Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0].Substring(1, vs[0].Length - 1), 5) + "&StoreNo=" + StoreNo;
                                    else return "~/WebInvoice.aspx?Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&StoreNo=" + StoreNo;
                                }                                                                    
 
                            case 20: return "~/WebCarMoveRCV.aspx?Support=1&CarMove=" + Number.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo;
                            case 210: return "~/WebCarRCV.aspx?Support=1&InvNo=" + Number.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo;
                            case 211: return "~/WebRVou1.aspx?Support=1&InvNo=" + Number.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo;
                            case 21: return "~/WebPay1.aspx?Support=1&FType=2&CarMove=" + Number.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo;
                            default: return "";
                        }
                    }
                }
                else return "";
            }
            else return "";
        }

        public string GetLandCost(string FDate, string FTime)
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

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcessTrackMove(ddlBranch.SelectedValue);
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HttpRuntime.Cache["OverCarsIn_" + AreaNo + Session["CNN2"].ToString()] != null) Cache.Remove("OverCarsIn_" + AreaNo + Session["CNN2"].ToString());
            ProcessTrackMove(ddlBranch.SelectedValue);
        }

    }
}