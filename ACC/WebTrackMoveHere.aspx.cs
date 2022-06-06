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
    public partial class WebTrackMoveHere : System.Web.UI.Page
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
                    this.Page.Header.Title = "الشاحنات المتاحة";
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

        protected void BtnProcess_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                lblNow.Text = moh.Nows().ToString();
                //MyOver.Clear();

                if (MyOver != null && MyOver.Count() > 0)
                {
                    IEnumerable<TrackMove> x = ((List<TrackMove>)(HttpRuntime.Cache["OverTrack2_" + AreaNo + Session["CNN2"].ToString()])).Except(MyOver, new ProductComparer());
                    if (x.Count() > 0)
                    {
                        MyOver.Clear();
                        MyOver.AddRange((List<TrackMove>)(HttpRuntime.Cache["OverTrack2_" + AreaNo + Session["CNN2"].ToString()]));
                        LoadCodesData();
                    }
                }
                else
                {
                    MyOver.Clear();
                    MyOver.AddRange((List<TrackMove>)(HttpRuntime.Cache["OverTrack2_" + AreaNo + Session["CNN2"].ToString()]));
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
            BtnProcess_Click(sender, null);
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
                    && x.CarMoveFrom == y.CarMoveFrom && x.CarMoveTo == y.CarMoveTo && x.CarMoveRCVNo == y.CarMoveRCVNo;
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