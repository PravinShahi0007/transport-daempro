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
    public partial class WebCarRCVNotSMS : System.Web.UI.Page
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
                    this.Page.Header.Title = "متابعة رسائل الوصول";

                    if (Request.QueryString["AreaNo"] != null)
                    {
                        ((HiddenField)this.Master.FindControl("MyArea")).Value = Request.QueryString["AreaNo"].ToString(); ;
                        AreaNo = Request.QueryString["AreaNo"].ToString(); ;
                    }
                    else
                    {
                        ((HiddenField)this.Master.FindControl("MyArea")).Value = Session["AreaNo"].ToString();
                        AreaNo = Session["AreaNo"].ToString();
                    }

                    if (Request.QueryString["StoreNo"] != null) StoreNo = Request.QueryString["StoreNo"].ToString();
                    else StoreNo = Session["StoreNo"].ToString();

                    ProcessTrackMove();
                }
            }
            catch
            {
            }
        }

        public void ProcessTrackMove()
        {
            vCarRcvSite vCarSite = new vCarRcvSite();
            OverCarsIn = vCarSite.GetNotSMS(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
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
                            case 3: return "~/WebInvoice.aspx?Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&StoreNo=" + StoreNo;
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
                            case 3: return "~/WebInvoice.aspx?Support=1&Flag=0&FNum=" + vs[1] + "&AreaNo=" + moh.MakeMask(vs[0], 5) + "&StoreNo=" + StoreNo;
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

        protected void Image2_Click(object sender, ImageClickEventArgs e)
        {

            ImageButton btnInsert = sender as ImageButton;
            GridViewRow gvr = btnInsert.NamingContainer as GridViewRow;
            Label lblMobileNo = gvr.FindControl("lblMobileNo") as Label;
            string myStatus = "0";

            myStatus = sms.SendMessage("شكرا لتعاملك مع ناقلات البرية شحنتك وصلت للاستفسار اتصل ب0115283100 أو 920028833", "naqelat", "966" + OverCarsIn[gvr.RowIndex].RecMobileNo.Substring(1, 9));

            OverCarsIn[gvr.RowIndex].Status = myStatus;
            InvDetails myInvDetails = new InvDetails();
            myInvDetails.Branch = 1;
            myInvDetails.VouLoc = moh.MakeMask(OverCarsIn[gvr.RowIndex].InvNo.Split('/')[0], 5);
            myInvDetails.VouNo = int.Parse(OverCarsIn[gvr.RowIndex].InvNo.Split('/')[1]);
            myInvDetails.FNo = (short)OverCarsIn[gvr.RowIndex].InvoiceFNo;
            myInvDetails.Status = myStatus;
            myInvDetails.SetStatus(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            btnInsert.ImageUrl.Replace("Cross", "accept");
            grdDCars.DataSource = OverCarsIn;
            grdDCars.DataBind();
            
        }


    }
}