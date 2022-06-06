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
    public partial class WebeServices : System.Web.UI.Page
    {
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
                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "بوابة الخدمات الالكترونية";
                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = "الرئيسية";
                        UserTran.FormAction = "اختيار";
                        UserTran.Description = "اختيار بوابة الخدمات الالكترونية";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    if (Request.QueryString["AreaNo"] != null)
                    {
                        AreaNo = Request.QueryString["AreaNo"].ToString();
                    }
                    else
                    {
                        AreaNo = Session["AreaNo"].ToString();
                    }

                    if (Request.QueryString["StoreNo"] != null) StoreNo = Request.QueryString["StoreNo"].ToString();
                    else
                    {
                        if (Session["StoreNo"] == null) Session["StoreNo"] = 1;
                        StoreNo = Session["StoreNo"].ToString();
                    }

                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    string vRoleName = ((List<TblRoles>)(Session[moh.GetCurrentRole(AreaNo, (from useritm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                                                                             where useritm.UserName == Session["CurrentUser"].ToString()
                                                                                             select useritm).FirstOrDefault())]))[0].RoleName;

                    
                    Functions1 myFun = new Functions1();
                    List<Functions1> lf = new List<Functions1>();

                    lf = (from itm in myFun.GetAll((Request.QueryString["Support"] != null),AreaNo,StoreNo,WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                                //where itm.FCreate == "-1" || itm.FCreate == "*" || itm.FCreate.Contains(Session["CurrentUser"].ToString()) || itm.FCreate.Contains(vRoleName)
                                                select itm).ToList();

                    BulletedList1.DataTextField = "Name";
                    BulletedList1.DataValueField = "FormName";
                    BulletedList1.DataSource = lf;
                    BulletedList1.DataBind();

                    ddlType.DataTextField = "Name";
                    ddlType.DataValueField = "FType";
                    ddlType.DataSource = lf;
                    ddlType.DataBind();
                    ddlType.Items.Insert(0, new ListItem("--- الجميع ---", "-1", true));

                    ddlType2.DataTextField = "Name";
                    ddlType2.DataValueField = "FType";
                    ddlType2.DataSource = lf;
                    ddlType2.DataBind();
                    ddlType2.Items.Insert(0, new ListItem("--- الجميع ---", "-1", true));

                    int vY = 2018;
                    int vM = 11;
                    int vY2 = moh.Nows().Year;
                    int vM2 = moh.Nows().Month;

                    while (vY <= vY2)
                    {
                        for (int i = vM; i < 13; i++)
                        {
                            ddlMonth.Items.Add(new ListItem(vY.ToString() + "/" + moh.MakeMask(i.ToString(), 2), vY.ToString() + "/" + moh.MakeMask(i.ToString(), 2)));
                            ddlMonth2.Items.Add(new ListItem(vY.ToString() + "/" + moh.MakeMask(i.ToString(), 2), vY.ToString() + "/" + moh.MakeMask(i.ToString(), 2)));
                        }
                        vY++;
                        vM = 1;
                    }
                    ddlMonth.Items.Insert(0, new ListItem("--- الجميع ---", "-1", true));
                    ddlMonth2.Items.Insert(0, new ListItem("--- الجميع ---", "-1", true));                                       

                    if (Request.QueryString["AreaNo"] != null)
                    {
                        AreaNo = Request.QueryString["AreaNo"].ToString();
                    }
                    else
                    {
                        AreaNo = Session["AreaNo"].ToString();
                    }
                    if (Request.QueryString["StoreNo"] != null) StoreNo = Request.QueryString["StoreNo"].ToString();

                    LoadActiveTran();
                    LoadHistoryTran();
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

        public void LoadActiveTran()
        {
            try
            {               
                eServices myService = new eServices();
                myService.DocType = -1;
                myService.Status = 0;
                myService.UserName = Session["CurrentUser"].ToString();
                grdActiveTran.DataSource = (from itm in myService.GetByStatus(((List<TblRoles>)(Session[vRoleName]))[0].RoleName, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                            where (ddlMonth.SelectedIndex == 0 || (DateTime.Parse(itm.DocDate).Year == int.Parse(ddlMonth.SelectedItem.Text.Split('/')[0])) && (DateTime.Parse(itm.DocDate).Month == int.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]))) && (ddlType.SelectedIndex == 0 || itm.DocType.ToString() == ddlType.SelectedValue)
                                            select itm).ToList();                                           
                grdActiveTran.DataBind();                    
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

        public void LoadHistoryTran()
        {
            try
            {
                eServices myService = new eServices();
                myService.DocType = -1;
                myService.Status = -1;
                myService.UserName = Session["CurrentUser"].ToString();
                string vrole = ((List<TblRoles>)(Session[vRoleName]))[0].RoleName;
                grdTranHistory.DataSource = (from itm in myService.GetByStatus(vrole,WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                             where (ddlMonth2.SelectedIndex == 0 || (DateTime.Parse(itm.DocDate).Year == int.Parse(ddlMonth2.SelectedItem.Text.Split('/')[0])) && (DateTime.Parse(itm.DocDate).Month == int.Parse(ddlMonth2.SelectedItem.Text.Split('/')[1]))) && (ddlType2.SelectedIndex == 0 || itm.DocType.ToString() == ddlType2.SelectedValue)
                                             select itm).ToList();
                grdTranHistory.DataBind();                    
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

        protected void grdTranHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdTranHistory.PageIndex = e.NewPageIndex;
                LoadHistoryTran();
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

        protected void ddlMonth2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHistoryTran();
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadActiveTran();
        }

    }
}