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
    public partial class WebSalRep : System.Web.UI.Page
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
        public string TotalBasic
        {
            get
            {
                if (ViewState["TotalBasic"] == null)
                {
                    ViewState["TotalBasic"] = "0.00";
                }
                return ViewState["TotalBasic"].ToString();
            }
            set { ViewState["TotalBasic"] = value; }
        }
        public string TotalAdd01
        {
            get
            {
                if (ViewState["TotalAdd01"] == null)
                {
                    ViewState["TotalAdd01"] = "0.00";
                }
                return ViewState["TotalAdd01"].ToString();
            }
            set { ViewState["TotalAdd01"] = value; }
        }
        public string TotalAdd02
        {
            get
            {
                if (ViewState["TotalAdd02"] == null)
                {
                    ViewState["TotalAdd02"] = "0.00";
                }
                return ViewState["TotalAdd02"].ToString();
            }
            set { ViewState["TotalAdd02"] = value; }
        }
        public string TotalAdd03
        {
            get
            {
                if (ViewState["TotalAdd03"] == null)
                {
                    ViewState["TotalAdd03"] = "0.00";
                }
                return ViewState["TotalAdd03"].ToString();
            }
            set { ViewState["TotalAdd03"] = value; }
        }

        public string TotalAdd04
        {
            get
            {
                if (ViewState["TotalAdd04"] == null)
                {
                    ViewState["TotalAdd04"] = "0.00";
                }
                return ViewState["TotalAdd04"].ToString();
            }
            set { ViewState["TotalAdd04"] = value; }
        }
        public string TotalAdd05
        {
            get
            {
                if (ViewState["TotalAdd05"] == null)
                {
                    ViewState["TotalAdd05"] = "0.00";
                }
                return ViewState["TotalAdd05"].ToString();
            }
            set { ViewState["TotalAdd05"] = value; }
        }
        public string TotalAdd06
        {
            get
            {
                if (ViewState["TotalAdd06"] == null)
                {
                    ViewState["TotalAdd06"] = "0.00";
                }
                return ViewState["TotalAdd06"].ToString();
            }
            set { ViewState["TotalAdd06"] = value; }
        }
        public string TotalAdd07
        {
            get
            {
                if (ViewState["TotalAdd07"] == null)
                {
                    ViewState["TotalAdd07"] = "0.00";
                }
                return ViewState["TotalAdd07"].ToString();
            }
            set { ViewState["TotalAdd07"] = value; }
        }
        public string TotalAdd08
        {
            get
            {
                if (ViewState["TotalAdd08"] == null)
                {
                    ViewState["TotalAdd08"] = "0.00";
                }
                return ViewState["TotalAdd08"].ToString();
            }
            set { ViewState["TotalAdd08"] = value; }
        }
        public string TotalAdd09
        {
            get
            {
                if (ViewState["TotalAdd09"] == null)
                {
                    ViewState["TotalAdd09"] = "0.00";
                }
                return ViewState["TotalAdd09"].ToString();
            }
            set { ViewState["TotalAdd09"] = value; }
        }

        public string TotalAdd10
        {
            get
            {
                if (ViewState["TotalAdd10"] == null)
                {
                    ViewState["TotalAdd10"] = "0.00";
                }
                return ViewState["TotalAdd10"].ToString();
            }
            set { ViewState["TotalAdd10"] = value; }
        }
        public string TotalAdd11
        {
            get
            {
                if (ViewState["TotalAdd11"] == null)
                {
                    ViewState["TotalAdd11"] = "0.00";
                }
                return ViewState["TotalAdd11"].ToString();
            }
            set { ViewState["TotalAdd11"] = value; }
        }
        public string TotalAdd12
        {
            get
            {
                if (ViewState["TotalAdd12"] == null)
                {
                    ViewState["TotalAdd12"] = "0.00";
                }
                return ViewState["TotalAdd12"].ToString();
            }
            set { ViewState["TotalAdd12"] = value; }
        }
        public string TotalAdd13
        {
            get
            {
                if (ViewState["TotalAdd13"] == null)
                {
                    ViewState["TotalAdd13"] = "0.00";
                }
                return ViewState["TotalAdd13"].ToString();
            }
            set { ViewState["TotalAdd13"] = value; }
        }
        public string TotalAdd14
        {
            get
            {
                if (ViewState["TotalAdd14"] == null)
                {
                    ViewState["TotalAdd14"] = "0.00";
                }
                return ViewState["TotalAdd14"].ToString();
            }
            set { ViewState["TotalAdd14"] = value; }
        }
        public string TotalAdd15
        {
            get
            {
                if (ViewState["TotalAdd15"] == null)
                {
                    ViewState["TotalAdd15"] = "0.00";
                }
                return ViewState["TotalAdd15"].ToString();
            }
            set { ViewState["TotalAdd15"] = value; }
        }

        public string TotalAddAll
        {
            get
            {
                if (ViewState["TotalAddAll"] == null)
                {
                    ViewState["TotalAddAll"] = "0.00";
                }
                return ViewState["TotalAddAll"].ToString();
            }
            set { ViewState["TotalAddAll"] = value; }
        }
        public string TotalDed01
        {
            get
            {
                if (ViewState["TotalDed01"] == null)
                {
                    ViewState["TotalDed01"] = "0.00";
                }
                return ViewState["TotalDed01"].ToString();
            }
            set { ViewState["TotalDed01"] = value; }
        }
        public string TotalDed02
        {
            get
            {
                if (ViewState["TotalDed02"] == null)
                {
                    ViewState["TotalDed02"] = "0.00";
                }
                return ViewState["TotalDed02"].ToString();
            }
            set { ViewState["TotalDed02"] = value; }
        }
        public string TotalDed03
        {
            get
            {
                if (ViewState["TotalDed03"] == null)
                {
                    ViewState["TotalDed03"] = "0.00";
                }
                return ViewState["TotalDed03"].ToString();
            }
            set { ViewState["TotalDed03"] = value; }
        }
        public string TotalDed04
        {
            get
            {
                if (ViewState["TotalDed04"] == null)
                {
                    ViewState["TotalDed04"] = "0.00";
                }
                return ViewState["TotalDed04"].ToString();
            }
            set { ViewState["TotalDed04"] = value; }
        }
        public string TotalDed05
        {
            get
            {
                if (ViewState["TotalDed05"] == null)
                {
                    ViewState["TotalDed05"] = "0.00";
                }
                return ViewState["TotalDed05"].ToString();
            }
            set { ViewState["TotalDed05"] = value; }
        }

        public string TotalDed06
        {
            get
            {
                if (ViewState["TotalDed06"] == null)
                {
                    ViewState["TotalDed06"] = "0.00";
                }
                return ViewState["TotalDed06"].ToString();
            }
            set { ViewState["TotalDed06"] = value; }
        }
        public string TotalDed07
        {
            get
            {
                if (ViewState["TotalDed07"] == null)
                {
                    ViewState["TotalDed07"] = "0.00";
                }
                return ViewState["TotalDed07"].ToString();
            }
            set { ViewState["TotalDed07"] = value; }
        }
        public string TotalDed08
        {
            get
            {
                if (ViewState["TotalDed08"] == null)
                {
                    ViewState["TotalDed08"] = "0.00";
                }
                return ViewState["TotalDed08"].ToString();
            }
            set { ViewState["TotalDed08"] = value; }
        }
        public string TotalDed09
        {
            get
            {
                if (ViewState["TotalDed09"] == null)
                {
                    ViewState["TotalDed09"] = "0.00";
                }
                return ViewState["TotalDed09"].ToString();
            }
            set { ViewState["TotalDed09"] = value; }
        }
        public string TotalDed10
        {
            get
            {
                if (ViewState["TotalDed10"] == null)
                {
                    ViewState["TotalDed10"] = "0.00";
                }
                return ViewState["TotalDed10"].ToString();
            }
            set { ViewState["TotalDed10"] = value; }
        }
        public string TotalDed11
        {
            get
            {
                if (ViewState["TotalDed11"] == null)
                {
                    ViewState["TotalDed11"] = "0.00";
                }
                return ViewState["TotalDed11"].ToString();
            }
            set { ViewState["TotalDed11"] = value; }
        }
        public string TotalDed12
        {
            get
            {
                if (ViewState["TotalDed12"] == null)
                {
                    ViewState["TotalDed12"] = "0.00";
                }
                return ViewState["TotalDed12"].ToString();
            }
            set { ViewState["TotalDed12"] = value; }
        }
        public string TotalDed13
        {
            get
            {
                if (ViewState["TotalDed13"] == null)
                {
                    ViewState["TotalDed13"] = "0.00";
                }
                return ViewState["TotalDed13"].ToString();
            }
            set { ViewState["TotalDed13"] = value; }
        }
        public string TotalDed14
        {
            get
            {
                if (ViewState["TotalDed14"] == null)
                {
                    ViewState["TotalDed14"] = "0.00";
                }
                return ViewState["TotalDed14"].ToString();
            }
            set { ViewState["TotalDed14"] = value; }
        }
        public string TotalDed15
        {
            get
            {
                if (ViewState["TotalDed15"] == null)
                {
                    ViewState["TotalDed15"] = "0.00";
                }
                return ViewState["TotalDed15"].ToString();
            }
            set { ViewState["TotalDed15"] = value; }
        }
        public string TotalDedAll
        {
            get
            {
                if (ViewState["TotalDedAll"] == null)
                {
                    ViewState["TotalDedAll"] = "0.00";
                }
                return ViewState["TotalDedAll"].ToString();
            }
            set { ViewState["TotalDedAll"] = value; }
        }
        public string TotalNet
        {
            get
            {
                if (ViewState["TotalNet"] == null)
                {
                    ViewState["TotalNet"] = "0.00";
                }
                return ViewState["TotalNet"].ToString();
            }
            set { ViewState["TotalNet"] = value; }
        }

        public List<Salaries> MyOver
        {
            get
            {
                if (ViewState["MyOver"] == null)
                {
                    ViewState["MyOver"] = new List<Salaries>();
                }
                return (List<Salaries>)ViewState["MyOver"];
            }
            set { ViewState["MyOver"] = value; }
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
                BtnPrint1.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                BtnExcel.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnPrint1);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnExcel);
                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "كشف الرواتب";

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
                        UserTran.Description = "اختيار عرض كشف الرواتب";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    ChkSection.DataTextField = "Name1";
                    ChkSection.DataValueField = "Code";


                    Codes myCode = new Codes();
                    myCode.Branch = short.Parse(Session["Branch"].ToString());
                    myCode.Ftype = 3;
                    if (Cache["LastCodes" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCodes" + Session["CNN2"].ToString(), myCode.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ChkSection.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                             where itm.Ftype == 3
                                             select itm).ToList();
                    ChkSection.DataBind();

                    Salaries mySal = new Salaries();
                    ddlMonth.DataSource = mySal.GetMonth(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlMonth.DataBind();
                    ddlMonth.Items.Insert(0, new ListItem("---  الاساسي  ---", "-1", true));
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

        public bool CheckSection(string sec)
        {
            bool vResult = false;
            for (int i = 0; i < ChkSection.Items.Count; i++)
            {
                if (ChkSection.Items[i].Selected && ChkSection.Items[i].Value == sec)
                {
                    vResult = true;
                    break;
                }
            }
            return vResult;
        }


        protected void LoadCodesData()
        {
            try
            {
                if (ddlMonth.SelectedIndex == 0)
                {
                    int fno = 1;
                    SEmp myacc = new SEmp();
                    MyOver = (from itm in myacc.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                              where CheckSection(itm.Section.ToString()) 
                              select new Salaries{
                                         FNo = (short)fno++,
                                         Year1 = 0,
                                         Month1 = 0,
                                         EmpCode = itm.EmpCode,
                                         Basic = itm.Basic,
                                         Add01 = itm.Add01,
                                         Add02 = itm.Add02,
                                         Add03 = itm.Add03,
                                         Add04 = itm.Add04,
                                         Add05 = itm.Add05,
                                         Add06 = itm.Add06,
                                         Add07 = itm.Add07,
                                         Add08 = itm.Add08,
                                         Add09 = itm.Add09,
                                         Add10 = itm.Add10,
                                         Add11 = itm.Add11,
                                         Add12 = itm.Add12,
                                         Add13 = itm.Add13,
                                         Add14 = itm.Add14,
                                         Add15 = itm.Add15,
                                         Ded01 = itm.Ded01,
                                         Ded02 = itm.Ded02,
                                         Ded03 = itm.Ded03,
                                         Ded04 = itm.Ded04,
                                         Ded05 = itm.Ded05,
                                         Ded06 = itm.Ded06,
                                         Ded07 = itm.Ded07,
                                         Ded08 = itm.Ded08,
                                         Ded09 = itm.Ded09,
                                         Ded10 = itm.Ded10,
                                         Ded11 = itm.Ded11,
                                         Ded12 = itm.Ded12,
                                         Ded13 = itm.Ded13,
                                         Ded14 = itm.Ded14,
                                         Ded15 = itm.Ded15,
                                         Name = itm.Name,
                                         NoDays = 30,
                                         ATM = itm.ATM,
                                         PaperNo1 = itm.PaperNo1
                              }).ToList();
                }
                else
                {
                    Salaries myacc = new Salaries();
                    myacc.Year1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                    myacc.Month1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                    MyOver = (from itm in myacc.GetAllSalary(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                              where CheckSection(itm.Section.ToString()) 
                              select itm).ToList();
                }
                grdCodes.DataSource = MyOver;
                grdCodes.DataBind();
                lblCount.Text = MyOver.Count().ToString();
                MakeSum();
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

        public void MakeSum()
        {
            for (int i = 0; i < 36; i++ )
                this.grdCodes.Columns[i].Visible = true;

            MyConfig mysetting = new MyConfig();
            mysetting.Branch = short.Parse(Session["Branch"].ToString());
            if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mysetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            mysetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
            
            if (grdCodes.FooterRow != null)
            {
                Label lblTotalBasic = grdCodes.FooterRow.FindControl("lblTotalBasic") as Label;
                Label lblTotalAdd01 = grdCodes.FooterRow.FindControl("lblTotalAdd01") as Label;
                Label lblTotalAdd02 = grdCodes.FooterRow.FindControl("lblTotalAdd02") as Label;
                Label lblTotalAdd03 = grdCodes.FooterRow.FindControl("lblTotalAdd03") as Label;
                Label lblTotalAdd04 = grdCodes.FooterRow.FindControl("lblTotalAdd04") as Label;
                Label lblTotalAdd05 = grdCodes.FooterRow.FindControl("lblTotalAdd05") as Label;
                Label lblTotalAdd06 = grdCodes.FooterRow.FindControl("lblTotalAdd06") as Label;
                Label lblTotalAdd07 = grdCodes.FooterRow.FindControl("lblTotalAdd07") as Label;
                Label lblTotalAdd08 = grdCodes.FooterRow.FindControl("lblTotalAdd08") as Label;
                Label lblTotalAdd09 = grdCodes.FooterRow.FindControl("lblTotalAdd09") as Label;
                Label lblTotalAdd10 = grdCodes.FooterRow.FindControl("lblTotalAdd10") as Label;
                Label lblTotalAdd11 = grdCodes.FooterRow.FindControl("lblTotalAdd11") as Label;
                Label lblTotalAdd12 = grdCodes.FooterRow.FindControl("lblTotalAdd12") as Label;
                Label lblTotalAdd13 = grdCodes.FooterRow.FindControl("lblTotalAdd13") as Label;
                Label lblTotalAdd14 = grdCodes.FooterRow.FindControl("lblTotalAdd14") as Label;
                Label lblTotalAdd15 = grdCodes.FooterRow.FindControl("lblTotalAdd15") as Label;
                Label lblTotalAddAll = grdCodes.FooterRow.FindControl("lblTotalAddAll") as Label;
                Label lblTotalDed01 = grdCodes.FooterRow.FindControl("lblTotalDed01") as Label;
                Label lblTotalDed02 = grdCodes.FooterRow.FindControl("lblTotalDed02") as Label;
                Label lblTotalDed03 = grdCodes.FooterRow.FindControl("lblTotalDed03") as Label;
                Label lblTotalDed04 = grdCodes.FooterRow.FindControl("lblTotalDed04") as Label;
                Label lblTotalDed05 = grdCodes.FooterRow.FindControl("lblTotalDed05") as Label;
                Label lblTotalDed06 = grdCodes.FooterRow.FindControl("lblTotalDed06") as Label;
                Label lblTotalDed07 = grdCodes.FooterRow.FindControl("lblTotalDed07") as Label;
                Label lblTotalDed08 = grdCodes.FooterRow.FindControl("lblTotalDed08") as Label;
                Label lblTotalDed09 = grdCodes.FooterRow.FindControl("lblTotalDed09") as Label;
                Label lblTotalDed10 = grdCodes.FooterRow.FindControl("lblTotalDed10") as Label;
                Label lblTotalDed11 = grdCodes.FooterRow.FindControl("lblTotalDed11") as Label;
                Label lblTotalDed12 = grdCodes.FooterRow.FindControl("lblTotalDed12") as Label;
                Label lblTotalDed13 = grdCodes.FooterRow.FindControl("lblTotalDed13") as Label;
                Label lblTotalDed14 = grdCodes.FooterRow.FindControl("lblTotalDed14") as Label;
                Label lblTotalDed15 = grdCodes.FooterRow.FindControl("lblTotalDed15") as Label;
                Label lblTotalDedAll = grdCodes.FooterRow.FindControl("lblTotalDedAll") as Label;
                Label lblTotalNet = grdCodes.FooterRow.FindControl("lblTotalNet") as Label;

                double Basic= 0,Add01= 0,Add02= 0,Add03= 0,Add04= 0,Add05= 0,Add06= 0,Add07= 0,Add08= 0,Add09= 0,Add10= 0,Add11= 0,Add12= 0,Add13= 0,Add14= 0,Add15= 0,AddAll = 0 , DedAll = 0 , Net = 0;
                double Ded01 = 0, Ded02 = 0, Ded03 = 0, Ded04 = 0, Ded05 = 0, Ded06 = 0, Ded07 = 0, Ded08 = 0, Ded09 = 0, Ded10 = 0, Ded11 = 0, Ded12 = 0, Ded13 = 0, Ded14 = 0, Ded15 = Add01;
                foreach (Salaries itm in MyOver)
                {
                    Basic += (double)itm.Basic;
                    Add01 += (double)itm.Add01;
                    Add02 += (double)itm.Add02;
                    Add03 += (double)itm.Add03;
                    Add04 += (double)itm.Add04;
                    Add05 += (double)itm.Add05;
                    Add06 += (double)itm.Add06;
                    Add07 += (double)itm.Add07;
                    Add08 += (double)itm.Add08;
                    Add09 += (double)itm.Add09;
                    Add10 += (double)itm.Add10;
                    Add11 += (double)itm.Add11;
                    Add12 += (double)itm.Add12;
                    Add13 += (double)itm.Add13;
                    Add14 += (double)itm.Add14;
                    Add15 += (double)itm.Add15;
                    AddAll += (double)itm.AddAll;
                    DedAll += (double)itm.DedAll;
                    Net += (double)itm.Net;
                    Ded01 += (double)itm.Ded01;
                    Ded02 += (double)itm.Ded02;
                    Ded03 += (double)itm.Ded03;
                    Ded04 += (double)itm.Ded04;
                    Ded05 += (double)itm.Ded05;
                    Ded06 += (double)itm.Ded06;
                    Ded07 += (double)itm.Ded07;
                    Ded08 += (double)itm.Ded08;
                    Ded09 += (double)itm.Ded09;
                    Ded10 += (double)itm.Ded10;
                    Ded11 += (double)itm.Ded11;
                    Ded12 += (double)itm.Ded12;
                    Ded13 += (double)itm.Ded13;
                    Ded14 += (double)itm.Ded14;
                    Ded15 += (double)itm.Ded15;
                }

                if (lblTotalNet != null)
                {
                    lblTotalNet.Text = string.Format("{0:N2}", Math.Round(Net,2));
                    TotalNet = lblTotalNet.Text;
                }

                if (lblTotalDedAll != null)
                {
                    lblTotalDedAll.Text = string.Format("{0:N2}", DedAll);
                    TotalDedAll = lblTotalDedAll.Text;
                }

                int i = 35;
                if (lblTotalDed15 != null)
                {
                    if (Ded15 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Ded15;
                        lblTotalDed15.Text = string.Format("{0:N2}", Ded15);
                        TotalDed15 = lblTotalDed15.Text;
                    }
                }

                i--;
                if (lblTotalDed14 != null)
                {
                    if (Ded14 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Ded14;
                        lblTotalDed14.Text = string.Format("{0:N2}", Ded14);
                        TotalDed14 = lblTotalDed14.Text;
                    }
                }

                i--;
                if (lblTotalDed13 != null)
                {
                    if (Ded13 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Ded13;
                        lblTotalDed13.Text = string.Format("{0:N2}", Ded13);
                        TotalDed13 = lblTotalDed13.Text;
                    }
                }

                i--;
                if (lblTotalDed12 != null)
                {
                    if (Ded12 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Ded12;
                        lblTotalDed12.Text = string.Format("{0:N2}", Ded12);
                        TotalDed12 = lblTotalDed12.Text;
                    }
                }

                i--;
                if (lblTotalDed11 != null)
                {
                    if (Ded11 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Ded11;
                        lblTotalDed11.Text = string.Format("{0:N2}", Ded11);
                        TotalDed11 = lblTotalDed11.Text;
                    }
                }

                i--;
                if (lblTotalDed10 != null)
                {
                    if (Ded10 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Ded10;
                        lblTotalDed10.Text = string.Format("{0:N2}", Ded10);
                        TotalDed10 = lblTotalDed10.Text;
                    }
                }

                i--;
                if (lblTotalDed09 != null)
                {
                    if (Ded09 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Ded09;
                        lblTotalDed09.Text = string.Format("{0:N2}", Ded09);
                        TotalDed09 = lblTotalDed09.Text;
                    }
                }

                i--;
                if (lblTotalDed08 != null)
                {
                    if (Ded08 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Ded08;
                        lblTotalDed08.Text = string.Format("{0:N2}", Ded08);
                        TotalDed08 = lblTotalDed08.Text;
                    }
                }

                i--;
                if (lblTotalDed07 != null)
                {
                    if (Ded07 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Ded07;
                        lblTotalDed07.Text = string.Format("{0:N2}", Ded07);
                        TotalDed07 = lblTotalDed07.Text;
                    }
                }

                i--;
                if (lblTotalDed06 != null)
                {
                    if (Ded06 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Ded06;
                        lblTotalDed06.Text = string.Format("{0:N2}", Ded06);
                        TotalDed06 = lblTotalDed06.Text;
                    }
                }

                i--;
                if (lblTotalDed05 != null)
                {
                    if (Ded05 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Ded05;
                        lblTotalDed05.Text = string.Format("{0:N2}", Ded05);
                        TotalDed05 = lblTotalDed05.Text;
                    }
                }

                i--;
                if (lblTotalDed04 != null)
                {
                    if (Ded04 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Ded04;
                        lblTotalDed04.Text = string.Format("{0:N2}", Ded04);
                        TotalDed04 = lblTotalDed04.Text;
                    }
                }

                i--;
                if (lblTotalDed03 != null)
                {
                    if (Ded03 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Ded03;
                        lblTotalDed03.Text = string.Format("{0:N2}", Ded03);
                        TotalDed03 = lblTotalDed03.Text;
                    }
                }

                i--;
                if (lblTotalDed02 != null)
                {
                    if (Ded02 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Ded02;
                        lblTotalDed02.Text = string.Format("{0:N2}", Ded02);
                        TotalDed02 = lblTotalDed02.Text;
                    }
                }

                i--;
                if (lblTotalDed01 != null)
                {
                    if (Ded01 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Ded01;
                        lblTotalDed01.Text = string.Format("{0:N2}", Ded01);
                        TotalDed01 = lblTotalDed01.Text;
                    }
                }

                i--;
                if (lblTotalAddAll != null)
                {
                    lblTotalAddAll.Text = string.Format("{0:N2}", AddAll);
                    TotalAddAll = lblTotalAddAll.Text;
                }

                i--;
                if (lblTotalAdd15 != null)
                {
                    if (Add15 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Add15;
                        lblTotalAdd15.Text = string.Format("{0:N2}", Add15);
                        TotalAdd15 = lblTotalAdd15.Text;
                    }
                }

                i--;
                if (lblTotalAdd14 != null)
                {
                    if (Add14 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Add14;
                        lblTotalAdd14.Text = string.Format("{0:N2}", Add14);
                        TotalAdd14 = lblTotalAdd14.Text;
                    }
                }

                i--;
                if (lblTotalAdd13 != null)
                {
                    if (Add13 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Add13;
                        lblTotalAdd13.Text = string.Format("{0:N2}", Add13);
                        TotalAdd13 = lblTotalAdd13.Text;
                    }
                }

                i--;
                if (lblTotalAdd12 != null)
                {
                    if (Add12 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Add12;
                        lblTotalAdd12.Text = string.Format("{0:N2}", Add12);
                        TotalAdd12 = lblTotalAdd12.Text;
                    }
                }

                i--;
                if (lblTotalAdd11 != null)
                {
                    if (Add11 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Add11;
                        lblTotalAdd11.Text = string.Format("{0:N2}", Add11);
                        TotalAdd11 = lblTotalAdd11.Text;
                    }
                }

                i--;
                if (lblTotalAdd10 != null)
                {
                    if (Add10 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Add10;
                        lblTotalAdd10.Text = string.Format("{0:N2}", Add10);
                        TotalAdd10 = lblTotalAdd10.Text;
                    }
                }

                i--;
                if (lblTotalAdd09 != null)
                {
                    if (Add09 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Add09;
                        lblTotalAdd09.Text = string.Format("{0:N2}", Add09);
                        TotalAdd09 = lblTotalAdd09.Text;
                    }
                }

                i--;
                if (lblTotalAdd08 != null)
                {
                    if (Add08 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Add08;
                        lblTotalAdd08.Text = string.Format("{0:N2}", Add08);
                        TotalAdd08 = lblTotalAdd08.Text;
                    }
                }

                i--;
                if (lblTotalAdd07 != null)
                {
                    if (Add07 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Add07;
                        lblTotalAdd07.Text = string.Format("{0:N2}", Add07);
                        TotalAdd07 = lblTotalAdd07.Text;
                    }
                }

                i--;
                if (lblTotalAdd06 != null)
                {
                    if (Add06 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Add06;
                        lblTotalAdd06.Text = string.Format("{0:N2}", Add06);
                        TotalAdd06 = lblTotalAdd06.Text;
                    }
                }

                i--;
                if (lblTotalAdd05 != null)
                {
                    if (Add05 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Add05;
                        lblTotalAdd05.Text = string.Format("{0:N2}", Add05);
                        TotalAdd05 = lblTotalAdd05.Text;
                    }
                }

                i--;
                if (lblTotalAdd04 != null)
                {
                    if (Add04 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Add04;
                        lblTotalAdd04.Text = string.Format("{0:N2}", Add04);
                        TotalAdd04 = lblTotalAdd04.Text;
                    }
                }

                i--;
                if (lblTotalAdd03 != null)
                {
                    if (Add03 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Add03;
                        lblTotalAdd03.Text = string.Format("{0:N2}", Add03);
                        TotalAdd03 = lblTotalAdd03.Text;
                    }
                }

                i--;
                if (lblTotalAdd02 != null)
                {
                    if (Add02 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Add02;
                        lblTotalAdd02.Text = string.Format("{0:N2}", Add02);
                        TotalAdd02 = lblTotalAdd02.Text;
                    }
                }

                i--;
                if (lblTotalAdd01 != null)
                {
                    if (Add01 == 0)
                    {
                        this.grdCodes.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdCodes.HeaderRow.Cells[i].Text = mysetting.Add01;
                        lblTotalAdd01.Text = string.Format("{0:N2}", Add01);
                        TotalAdd01 = lblTotalAdd01.Text;
                    }
                }


                if (lblTotalBasic != null)
                {
                    lblTotalBasic.Text = string.Format("{0:N2}", Basic);
                    TotalBasic = lblTotalBasic.Text;
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
                int ColCount = 38;
                if (moh.StrToDouble(TotalDed15) == 0) ColCount--;
                if (moh.StrToDouble(TotalDed14) == 0) ColCount--;
                if (moh.StrToDouble(TotalDed13) == 0) ColCount--;
                if (moh.StrToDouble(TotalDed12) == 0) ColCount--;
                if (moh.StrToDouble(TotalDed11) == 0) ColCount--;
                if (moh.StrToDouble(TotalDed10) == 0) ColCount--;
                if (moh.StrToDouble(TotalDed09) == 0) ColCount--;
                if (moh.StrToDouble(TotalDed08) == 0) ColCount--;
                if (moh.StrToDouble(TotalDed07) == 0) ColCount--;
                if (moh.StrToDouble(TotalDed06) == 0) ColCount--;
                if (moh.StrToDouble(TotalDed05) == 0) ColCount--;
                if (moh.StrToDouble(TotalDed04) == 0) ColCount--;
                if (moh.StrToDouble(TotalDed03) == 0) ColCount--;
                if (moh.StrToDouble(TotalDed02) == 0) ColCount--;
                if (moh.StrToDouble(TotalDed01) == 0) ColCount--;
                if (moh.StrToDouble(TotalAdd15) == 0) ColCount--;
                if (moh.StrToDouble(TotalAdd14) == 0) ColCount--;
                if (moh.StrToDouble(TotalAdd13) == 0) ColCount--;
                if (moh.StrToDouble(TotalAdd12) == 0) ColCount--;
                if (moh.StrToDouble(TotalAdd11) == 0) ColCount--;
                if (moh.StrToDouble(TotalAdd10) == 0) ColCount--;
                if (moh.StrToDouble(TotalAdd09) == 0) ColCount--;
                if (moh.StrToDouble(TotalAdd08) == 0) ColCount--;
                if (moh.StrToDouble(TotalAdd07) == 0) ColCount--;
                if (moh.StrToDouble(TotalAdd06) == 0) ColCount--;
                if (moh.StrToDouble(TotalAdd05) == 0) ColCount--;
                if (moh.StrToDouble(TotalAdd04) == 0) ColCount--;
                if (moh.StrToDouble(TotalAdd03) == 0) ColCount--;
                if (moh.StrToDouble(TotalAdd02) == 0) ColCount--;
                if (moh.StrToDouble(TotalAdd01) == 0) ColCount--;

                var cols = new[] { 1300 };
                if (ColCount == 38) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 37) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 36) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 35) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 34) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 33) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 32) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 31) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 30) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 29) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 28) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 27) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 26) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 25) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 24) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 23) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 22) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 21) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 20) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 19) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 18) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 17) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 16) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 15) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 14) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 13) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 12) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 11) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 10) cols = new[] { 50, 60, 50, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 9) cols = new[] { 50, 60, 50, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 8) cols = new[] { 50, 60, 50, 50, 50, 130, 60, 30 };
                else if (ColCount == 7) cols = new[] { 50, 60, 50, 50, 130, 60, 30 };

                iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), -100, -100, 80, 50);
                HttpContext.Current.Response.ContentType = "application/pdf";
                PdfWriter pw = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
                pdfPage page = new pdfPage();
                MyConfig mySetting = new MyConfig();
                mySetting.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                mySetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                if (mySetting != null)
                {
                    page.vCompanyName = mySetting.CompanyName;
                }

                for (int i = 0; i < ChkSection.Items.Count; i++)
                {
                    if (ChkSection.Items[i].Selected)
                    {
                        page.vStr1 += " - " + ChkSection.Items[i].Text;
                    }
                }

                page.PageNo = "1";
                page.UserName = Session["FullUser"].ToString();
                page.colWidths = cols;
                page.ColsCount = ColCount;
                MyConfig mysetting = new MyConfig();
                mysetting.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mysetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                mysetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                if (mysetting != null)
                {
                    page.vAdd01 = mysetting.Add01;
                    page.vAdd02 = mysetting.Add02;
                    page.vAdd03 = mysetting.Add03;
                    page.vAdd04 = mysetting.Add04;
                    page.vAdd05 = mysetting.Add05;
                    page.vAdd06 = mysetting.Add06;
                    page.vAdd07 = mysetting.Add07;
                    page.vAdd08 = mysetting.Add08;
                    page.vAdd09 = mysetting.Add09;
                    page.vAdd10 = mysetting.Add10;
                    page.vAdd11 = mysetting.Add11;
                    page.vAdd12 = mysetting.Add12;
                    page.vAdd13 = mysetting.Add13;
                    page.vAdd14 = mysetting.Add14;
                    page.vAdd15 = mysetting.Add15;
                    page.vDed01 = mysetting.Ded01;
                    page.vDed02 = mysetting.Ded02;
                    page.vDed03 = mysetting.Ded03;
                    page.vDed04 = mysetting.Ded04;
                    page.vDed05 = mysetting.Ded05;
                    page.vDed06 = mysetting.Ded06;
                    page.vDed07 = mysetting.Ded07;
                    page.vDed08 = mysetting.Ded08;
                    page.vDed09 = mysetting.Ded09;
                    page.vDed10 = mysetting.Ded10;
                    page.vDed11 = mysetting.Ded11;
                    page.vDed12 = mysetting.Ded12;
                    page.vDed13 = mysetting.Ded13;
                    page.vDed14 = mysetting.Ded14;
                    page.vDed15 = mysetting.Ded15;
                }
                page.Add01 = (moh.StrToDouble(TotalAdd01) != 0);
                page.Add02 = (moh.StrToDouble(TotalAdd02) != 0);
                page.Add03 = (moh.StrToDouble(TotalAdd03) != 0);
                page.Add04 = (moh.StrToDouble(TotalAdd04) != 0);
                page.Add05 = (moh.StrToDouble(TotalAdd05) != 0);
                page.Add06 = (moh.StrToDouble(TotalAdd06) != 0);
                page.Add07 = (moh.StrToDouble(TotalAdd07) != 0);
                page.Add08 = (moh.StrToDouble(TotalAdd08) != 0);
                page.Add09 = (moh.StrToDouble(TotalAdd09) != 0);
                page.Add10 = (moh.StrToDouble(TotalAdd10) != 0);
                page.Add11 = (moh.StrToDouble(TotalAdd11) != 0);
                page.Add12 = (moh.StrToDouble(TotalAdd12) != 0);
                page.Add13 = (moh.StrToDouble(TotalAdd13) != 0);
                page.Add14 = (moh.StrToDouble(TotalAdd14) != 0);
                page.Add15 = (moh.StrToDouble(TotalAdd15) != 0);
                page.Ded01 = (moh.StrToDouble(TotalDed01) != 0);
                page.Ded02 = (moh.StrToDouble(TotalDed02) != 0);
                page.Ded03 = (moh.StrToDouble(TotalDed03) != 0);
                page.Ded04 = (moh.StrToDouble(TotalDed04) != 0);
                page.Ded05 = (moh.StrToDouble(TotalDed05) != 0);
                page.Ded06 = (moh.StrToDouble(TotalDed06) != 0);
                page.Ded07 = (moh.StrToDouble(TotalDed07) != 0);
                page.Ded08 = (moh.StrToDouble(TotalDed08) != 0);
                page.Ded09 = (moh.StrToDouble(TotalDed09) != 0);
                page.Ded10 = (moh.StrToDouble(TotalDed10) != 0);
                page.Ded11 = (moh.StrToDouble(TotalDed11) != 0);
                page.Ded12 = (moh.StrToDouble(TotalDed12) != 0);
                page.Ded13 = (moh.StrToDouble(TotalDed13) != 0);
                page.Ded14 = (moh.StrToDouble(TotalDed14) != 0);
                page.Ded15 = (moh.StrToDouble(TotalDed15) != 0);                                              
                page.vStr1 += " " + (ddlMonth.SelectedIndex == 0 ? "" : "لشهر  " + ddlMonth.SelectedItem.Text.Split('/')[1] + "/" + ddlMonth.SelectedItem.Text.Split('/')[0]);
                pw.PageEvent = page;                
                
                int i123 = 0;
                if (ChkDep.Checked)
                {
                    MyOver = MyOver.OrderBy(p => p.Section).ToList();
                    int TotalPages = 0;
                    foreach (int itm in MyOver.Select(o => o.Section).Distinct().ToList())
                    {
                        int? d = (from sitm in MyOver
                                 where sitm.Section == itm
                                 select sitm).Count();
                        if(d == null) d = 5;
                        else d = d + 5;

                        int? t = (from sitm in MyOver
                                where sitm.Section == itm && sitm.Remark != ""
                                select sitm).Count();
                        if(t == null) t = 0;
                        else t = t + 2;
                        TotalPages += (int)((d+t)/22);
                        if (((d + t) % 22) > 0) TotalPages += 1;
                    }
                    page.TotPages = TotalPages;
                    foreach (int itm in MyOver.Select(o => o.Section).Distinct().ToList())
                    {

                        List<Salaries> ls = (from sitm in MyOver
                                                where sitm.Section == itm
                                                select sitm).ToList();
                        page.vPrintTitle = true;
                        page.vStr1 = (ddlMonth.SelectedIndex == 0 ? "" : "لشهر  " + ddlMonth.SelectedItem.Text.Split('/')[1] + "/" + ddlMonth.SelectedItem.Text.Split('/')[0]) + "\n" + ls[0].Name1;
                        if (i123++ != 0) document.NewPage();
                        else document.Open();
                        PrintSec(document, (int[])cols, ColCount, ls,page);
                    }
                }
                else
                {
                    page.TotPages = 0;
                    page.vPrintTitle = true;
                    document.Open();
                    PrintSec(document, (int[])cols, ColCount, MyOver, page);
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

        public void PrintSec(iTextSharp.text.Document document,int[] cols,int ColCount,List<Salaries> lOver,pdfPage page)
        {
            //PdfPTable table = new PdfPTable(grdCodes.HeaderRow.Cells.Count);
            PdfPTable table = new PdfPTable(ColCount);
            table.SetWidths(cols);
            PdfPCell cell = new PdfPCell();
            cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
            table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

            string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
            BaseFont nationalBase;
            nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 10f, iTextSharp.text.Font.NORMAL);
            bool vR = false;
            double Basic = 0, Add01 = 0, Add02 = 0, Add03 = 0, Add04 = 0, Add05 = 0, Add06 = 0, Add07 = 0, Add08 = 0, Add09 = 0, Add10 = 0, Add11 = 0, Add12 = 0, Add13 = 0, Add14 = 0, Add15 = 0, Ded01 = 0, Ded02 = 0, Ded03 = 0, Ded04 = 0, Ded05 = 0, Ded06 = 0, Ded07 = 0, Ded08 = 0, Ded09 = 0, Ded10 = 0, Ded11 = 0, Ded12 = 0, Ded13 = 0, Ded14 = 0, Ded15 = 0,AddAll = 0 , DedAll = 0 ,  Net = 0;
            int fN = 1;
            foreach (Salaries itm in lOver)
            {
                Basic += (double)itm.Basic;
                Add01 += (double)itm.Add01;
                Add02 += (double)itm.Add02;
                Add03 += (double)itm.Add03;
                Add04 += (double)itm.Add04;
                Add05 += (double)itm.Add05;
                Add06 += (double)itm.Add06;
                Add07 += (double)itm.Add07;
                Add08 += (double)itm.Add08;
                Add09 += (double)itm.Add09;
                Add10 += (double)itm.Add10;
                Add11 += (double)itm.Add11;
                Add12 += (double)itm.Add12;
                Add13 += (double)itm.Add13;
                Add14 += (double)itm.Add14;
                Add15 += (double)itm.Add15;
                Ded01 += (double)itm.Ded01;
                Ded02 += (double)itm.Ded02;
                Ded03 += (double)itm.Ded03;
                Ded04 += (double)itm.Ded04;
                Ded05 += (double)itm.Ded05;
                Ded06 += (double)itm.Ded06;
                Ded07 += (double)itm.Ded07;
                Ded08 += (double)itm.Ded08;
                Ded09 += (double)itm.Ded09;
                Ded10 += (double)itm.Ded10;
                Ded11 += (double)itm.Ded11;
                Ded12 += (double)itm.Ded12;
                Ded13 += (double)itm.Ded13;
                Ded14 += (double)itm.Ded14;
                Ded15 += (double)itm.Ded15;
                AddAll += (double)itm.AddAll;
                DedAll += (double)itm.DedAll;
                Net += (double)itm.Net;

                if (itm.Remark != "") vR = true;
                cell.Phrase = new iTextSharp.text.Phrase(ChkDep.Checked ? (fN++).ToString() : itm.FNo.ToString(), nationalTextFont);
                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(itm.EmpCode.ToString(), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(itm.Name, nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(itm.NoDays2.ToString(), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Basic), nationalTextFont);
                table.AddCell(cell);

                if (moh.StrToDouble(TotalAdd01) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Add01), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalAdd02) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Add02), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalAdd03) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Add03), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalAdd04) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Add04), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalAdd05) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Add05), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalAdd06) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Add06), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalAdd07) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Add07), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalAdd08) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Add08), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalAdd09) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Add09), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalAdd10) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Add10), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalAdd11) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Add11), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalAdd12) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Add12), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalAdd13) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Add13), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalAdd14) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Add14), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalAdd15) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Add15), nationalTextFont);
                    table.AddCell(cell);
                }

                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.AddAll), nationalTextFont);
                table.AddCell(cell);

                if (moh.StrToDouble(TotalDed01) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Ded01), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalDed02) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Ded02), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalDed03) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Ded03), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalDed04) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Ded04), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalDed05) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Ded05), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalDed06) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Ded06), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalDed07) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Ded07), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalDed08) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Ded08), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalDed09) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Ded09), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalDed10) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Ded10), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalDed11) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Ded11), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalDed12) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Ded12), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalDed13) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Ded13), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalDed14) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Ded14), nationalTextFont);
                    table.AddCell(cell);
                }

                if (moh.StrToDouble(TotalDed15) != 0)
                {
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Ded15), nationalTextFont);
                    table.AddCell(cell);
                }

                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.DedAll), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Net), nationalTextFont);
                table.AddCell(cell);
            }
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;

            cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
            table.AddCell(cell);

            cell.Phrase = new iTextSharp.text.Phrase("الاجمالي", nationalTextFont);
            table.AddCell(cell);

            cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
            table.AddCell(cell);

            cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
            table.AddCell(cell);

            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}",Basic), nationalTextFont);
            table.AddCell(cell);

            if (moh.StrToDouble(TotalAdd01) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Add01), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalAdd02) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Add02), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalAdd03) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Add03), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalAdd04) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Add04), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalAdd05) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Add05), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalAdd06) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Add06), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalAdd07) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Add07), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalAdd08) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Add08), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalAdd09) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Add09), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalAdd10) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Add10), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalAdd11) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Add11), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalAdd12) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Add12), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalAdd13) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Add13), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalAdd14) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Add14), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalAdd15) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Add15), nationalTextFont);
                table.AddCell(cell);
            }

            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", AddAll), nationalTextFont);
            table.AddCell(cell);

            if (moh.StrToDouble(TotalDed01) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Ded01 ), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalDed02) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Ded02), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalDed03) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Ded03), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalDed04) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Ded04), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalDed05) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Ded05), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalDed06) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Ded06), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalDed07) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Ded07), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalDed08) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Ded08), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalDed09) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Ded09), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalDed10) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Ded10), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalDed11) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Ded11), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalDed12) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Ded12), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalDed13) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Ded13), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalDed14) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Ded14), nationalTextFont);
                table.AddCell(cell);
            }

            if (moh.StrToDouble(TotalDed15) != 0)
            {
                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Ded15), nationalTextFont);
                table.AddCell(cell);
            }

            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", DedAll), nationalTextFont);
            table.AddCell(cell);

            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", Net), nationalTextFont);
            table.AddCell(cell);

            cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell.Colspan = ColCount;
            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.Phrase = new iTextSharp.text.Phrase("مبلغ وقدرة " + moh.NTOC(Net,1), nationalTextFont);
            table.AddCell(cell);

            document.Add(table);
            page.vPrintTitle = false;
            document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));


            var cols5 = new[] { 1100, 250, 100, 50 };
            PdfPCell cell5 = new PdfPCell();
            cell5.ArabicOptions = ColumnText.DIGITS_EN2AN;
            PdfPTable table50 = new PdfPTable(4);
            table50.TotalWidth = 100f;
            table50.SetWidths(cols5);
            cell5.ArabicOptions = ColumnText.DIGITS_EN2AN;
            table50.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            table50.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

            if (vR)
            {
                cell5.Phrase = new iTextSharp.text.Phrase("م", nationalTextFont);
                cell5.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                table50.AddCell(cell5);

                cell5.Phrase = new iTextSharp.text.Phrase("رقم الموظف", nationalTextFont);
                cell5.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                table50.AddCell(cell5);

                cell5.Phrase = new iTextSharp.text.Phrase("الاسم", nationalTextFont);
                cell5.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                table50.AddCell(cell5);

                cell5.Phrase = new iTextSharp.text.Phrase("ملاحظات", nationalTextFont);
                cell5.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                table50.AddCell(cell5);

                int sno = 1;
                foreach (Salaries itm in lOver)
                {
                    if (itm.Remark != "")
                    {
                        cell5.Phrase = new iTextSharp.text.Phrase((sno++).ToString(), nationalTextFont);
                        cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        table50.AddCell(cell5);

                        cell5.Phrase = new iTextSharp.text.Phrase(itm.EmpCode.ToString(), nationalTextFont);
                        table50.AddCell(cell5);

                        cell5.Phrase = new iTextSharp.text.Phrase(itm.Name, nationalTextFont);
                        table50.AddCell(cell5);

                        cell5.Phrase = new iTextSharp.text.Phrase(itm.Remark, nationalTextFont);
                        table50.AddCell(cell5);
                    }
                }
                document.Add(table50);
                document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
            }

            cols5 = new[] { 75, 200, 200, 200, 200, 200, 70 };
            cell5 = new PdfPCell();
            cell5.ArabicOptions = ColumnText.DIGITS_EN2AN;
            table50 = new PdfPTable(7);
            table50.TotalWidth = 100f;
            table50.SetWidths(cols5);
            cell5.ArabicOptions = ColumnText.DIGITS_EN2AN;
            table50.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            table50.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

            cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
            cell5.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("محاسب الاستحقاق", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("مدير الشئون الادارية", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);


            cell5.Phrase = new iTextSharp.text.Phrase("المحاسب", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);
            //------------------------------------------------------------

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);
            //---------------------------------------------------------------
            cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 2;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 2;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 2;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);
            //------------------------------------------------------------

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);
            //---------------------------------------------------------------

            cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
            cell5.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("رئيس الحسابات", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;

            cell.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("المدير العام", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            cell5.Border = 0;
            table50.AddCell(cell5);


            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);
            //------------------------------------------------------------

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);
            //---------------------------------------------------------------
            cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 2;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 2;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);
            document.Add(table50);        
        }

                

        // *************************************************** ITextSharp ****************************************************************
        public class pdfPage : iTextSharp.text.pdf.PdfPageEventHelper
        {
            public string UserName, PageNo, vCompanyName , vStr1;
            public int[] colWidths;
            public int ColsCount,TotPages;
            public bool Add01 = false, Add02 = false, Add03 = false, Add04 = false, Add05 = false, Add06 = false, Add07 = false, Add08 = false, Add09 = false;
            public bool Add10 = false, Add11 = false, Add12 = false, Add13 = false, Add14 = false, Add15 = false, Ded01 = false, Ded02 = false, Ded03 = false;
            public bool Ded04 = false, Ded05 = false, Ded06 = false, Ded07 = false, Ded08 = false, Ded09 = false, Ded10 = false, Ded11 = false, Ded12 = false;
            public bool Ded13 = false, Ded14 = false, Ded15 = false;
            public string vAdd01 = "", vAdd02 = "", vAdd03 = "", vAdd04 = "", vAdd05 = "", vAdd06 = "", vAdd07 = "", vAdd08 = "", vAdd09 = "", vAdd10 = "", vAdd11 = "", vAdd12 = "";
            public string vAdd13 = "", vAdd14 = "", vAdd15 = "", vDed01 = "", vDed02 = "", vDed03 = "", vDed04 = "", vDed05 = "", vDed06 = "", vDed07 = "", vDed08 = "", vDed09 = "";
            public string vDed10 = "", vDed11 = "", vDed12 = "", vDed13 = "", vDed14 = "", vDed15 = "";
            public Boolean vPrintTitle; 

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
                //cell2.PaddingRight = 0;
                cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell2.Phrase = new iTextSharp.text.Phrase(vCompanyName + "\n" + "المـرتبـــــات", nationalTextFont);
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                headerTbl.AddCell(cell2);

                //cell2.PaddingRight = 0;
                cell2.Phrase = new iTextSharp.text.Phrase("كشف الرواتب " + vStr1, nationalTextFont);
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

                arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                //BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                nationalTextFont = new iTextSharp.text.Font(nationalBase, 8f, iTextSharp.text.Font.NORMAL);

                if (vPrintTitle)
                {
                    PdfPTable table = new PdfPTable(ColsCount);
                    table.SetWidths(colWidths);
                    PdfPCell cell = new PdfPCell();
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    cell.Phrase = new iTextSharp.text.Phrase("م", nationalTextFont);
                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("رقم الموظف", nationalTextFont);
                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الاسم", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("عدد الايام", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الاساسي", nationalTextFont);
                    table.AddCell(cell);

                    if (Add01)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vAdd01, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Add02)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vAdd02, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Add03)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vAdd03, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Add04)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vAdd04, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Add05)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vAdd05, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Add06)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vAdd06, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Add07)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vAdd07, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Add08)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vAdd08, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Add09)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vAdd09, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Add10)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vAdd10, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Add11)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vAdd11, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Add12)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vAdd12, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Add13)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vAdd13, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Add14)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vAdd14, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Add15)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vAdd15, nationalTextFont);
                        table.AddCell(cell);
                    }


                    cell.Phrase = new iTextSharp.text.Phrase("أجمالي استحقاقات", nationalTextFont);
                    table.AddCell(cell);

                    if (Ded01)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vDed01, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Ded02)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vDed02, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Ded03)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vDed03, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Ded04)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vDed04, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Ded05)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vDed05, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Ded06)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vDed06, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Ded07)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vDed07, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Ded08)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vDed08, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Ded09)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vDed09, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Ded10)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vDed10, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Ded11)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vDed11, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Ded12)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vDed12, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Ded13)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vDed13, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Ded14)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vDed14, nationalTextFont);
                        table.AddCell(cell);
                    }

                    if (Ded15)
                    {
                        cell.Phrase = new iTextSharp.text.Phrase(vDed15, nationalTextFont);
                        table.AddCell(cell);
                    }

                    cell.Phrase = new iTextSharp.text.Phrase("أجمالي استقطاعات", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الصافي", nationalTextFont);
                    table.AddCell(cell);

                    headerTbl.WriteSelectedRows(0, -1, -1, (doc.PageSize.Height - 20), writer.DirectContent);
                    doc.Add(table);
                }
                else
                {
                    headerTbl.WriteSelectedRows(0, -1, -1, (doc.PageSize.Height - 20), writer.DirectContent);
                }
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

                cell.Phrase = new iTextSharp.text.Phrase("صفحة رقم " + writer.PageNumber.ToString() + (TotPages >0 ? "/" + TotPages.ToString() : "" ), footer);
                footerTbl.AddCell(cell);

                //write the rows out to the PDF output stream.
                footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin - 10), writer.DirectContent);
            }
        }


        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
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

            //for (int i = 0; i < grdCodes.Rows.Count; i++)
           // {
            //      GridViewRow row = grdCodes.Rows[i];

            //    //Change Color back to white
            //    row.BackColor = System.Drawing.Color.White;

            //    //Apply text style to each Row
            //    row.Attributes.Add("class", "textmode");
            //    row.Cells[38].Style.Add("mso-number-format", @"\@"); // ATM Card

            //    //Apply style to Individual Cells of Alternating Row
            //    if (i % 2 != 0)
            //    {
                //for (int r = 0; r < row.Cells.Count; r++)
                //{
                //    row.Cells[r].Style.Add("background-color", "#C2D69B");
                //    row.Cells[r].Style.Add("mso-number-format", @"\@");
                //}
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
            LoadCodesData();
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void ChkSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

    }
}