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
using System.Text;


namespace ACC
{
    public partial class WebEmpSalOp : System.Web.UI.Page
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
         public List<SalOP> MyOver
        {
            get
            {
                if (ViewState["MyOver"] == null)
                {
                    ViewState["MyOver"] = new List<SalOP>();
                }
                return (List<SalOP>)ViewState["MyOver"];
            }
            set { ViewState["MyOver"] = value; }
        }
         public List<SalOP> MyOver2
         {
             get
             {
                 if (ViewState["MyOver2"] == null)
                 {
                     ViewState["MyOver2"] = new List<SalOP>();
                 }
                 return (List<SalOP>)ViewState["MyOver2"];
             }
             set { ViewState["MyOver2"] = value; }
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
                BtnPrint.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnPrint);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(this.BtnAttach);

                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "كشف مؤثرات الرواتب";

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
                        UserTran.Description = "اختيار كشف مؤثرات الرواتب";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    vRoleName = moh.GetCurrentRole(AreaNo, (from useritm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                                            where useritm.UserName == Session["CurrentUser"].ToString()
                                                            select useritm).FirstOrDefault());
                    if (Session[vRoleName] == null)
                    {
                        Response.Redirect("WebNotPrev.aspx", false);
                        return;
                    }

                    ddlSection.DataTextField = "Name1";
                    ddlSection.DataValueField = "Code";

                    List<DepManager> lDepMan = new List<DepManager>();
                    DepManager vDepMan = new DepManager();
                    lDepMan = (from itm in vDepMan.GetManager(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                               where itm.Manag1 == Session["CurrentUser"].ToString() || itm.Manag2 == Session["CurrentUser"].ToString()
                               select itm).ToList();

                    Codes myCode = new Codes();
                    myCode.Branch = short.Parse(Session["Branch"].ToString());
                    myCode.Ftype = 19;
                    if (Cache["LastCodes" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCodes" + Session["CNN2"].ToString(), myCode.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    if (((List<TblRoles>)(Session[vRoleName]))[0].RoleName.ToLower().Contains("admin") || Session["CurrentUser"].ToString() == "m.yousef" || Session["CurrentUser"].ToString() == "wejdan" || Session["CurrentUser"].ToString() == "sameh" || Request.QueryString["FMode"] != null)
                    {
                        ddlSection.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                                 where itm.Ftype == 19
                                                 select itm).ToList();
                    }
                    else ddlSection.DataSource = (from itm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                                  where itm.Ftype == 19 && CheckDep(lDepMan, itm.Code)
                                                  select itm).ToList();
                        
                    ddlSection.DataBind();
                    ddlSection.Items.Insert(0, new ListItem("---  الإدارة  ---", "-1", true));

                    Salaries mySal = new Salaries();
                    ddlMonth.DataSource = mySal.GetMonth2019(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString); 
                    ddlMonth.DataBind();
                    ddlMonth.Items.Insert(0, new ListItem("---  الشهر  ---", "-1", true));

                    txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtUserName.Text = Session["FullUser"].ToString();
                    txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));

                    InitAgree();

                    if (Request.QueryString["FMode"] != null)
                    {
                        if (Request.QueryString["FMode"].ToString() == "1" && Request.QueryString["Month"] != null && Request.QueryString["Year"] != null && Request.QueryString["Dep"] != null && Request.QueryString["FStep"] != null)
                        {
                            ddlMonth.SelectedValue = Request.QueryString["Year"].ToString() + "/" +moh.MakeMask(Request.QueryString["Month"].ToString(),2);
                            ddlSection.SelectedValue = Request.QueryString["Dep"].ToString();
                            ddlSection_SelectedIndexChanged(sender,e);
                            Disableall();
                            EnableAgree(int.Parse(Request.QueryString["FStep"].ToString()));
                            if (Request.QueryString["FStep"].ToString() == "0")
                            {
                                //grdAbs.Enabled = true;
                                grdAbsSwitch(true);
                                BtnEdit.Visible = true;                                
                            }
                        }
                    }



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

        public bool CheckDep(List<DepManager> lDepMan,int? Code)
        {
            bool Result = false;
            foreach (DepManager itm in lDepMan)
            {
                if (itm.Dep == Code)
                {
                    Result = true;
                    break;
                }
            }
            return Result;    
        }

        protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMonth_SelectedIndexChanged(sender, e);
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

        public void Disableall()
        {
            ddlMonth.Enabled = false;
            ddlSection.Enabled = false;
            BtnEdit.Visible = false;
            //grdAbs.Enabled = false;           
            grdAbsSwitch(false);


        }

        public void Enableall()
        {
            ddlMonth.Enabled = true;
            ddlSection.Enabled = true;
            //grdAbs.Enabled = true;
            grdAbsSwitch(true);
        }


        public void grdAbsSwitch(Boolean Enable)
        {
            foreach (GridViewRow itm in grdAbs.Rows)
            {
                TextBox txtAbs0 = itm.FindControl("txtAbs0") as TextBox;
                if (txtAbs0 != null) txtAbs0.Enabled = Enable;
                
                TextBox txtAbs1 = itm.FindControl("txtAbs1") as TextBox;
                if (txtAbs1 != null) txtAbs1.Enabled = Enable;
                
                TextBox txtAbs2 = itm.FindControl("txtAbs2") as TextBox;
                if (txtAbs2 != null) txtAbs2.Enabled = Enable;

                TextBox txtAbs3 = itm.FindControl("txtAbs3") as TextBox;
                if (txtAbs3 != null) txtAbs3.Enabled = Enable;

                TextBox txtAbs4 = itm.FindControl("txtAbs4") as TextBox;
                if (txtAbs4 != null) txtAbs4.Enabled = Enable;

                TextBox txtAbs5 = itm.FindControl("txtAbs5") as TextBox;
                if (txtAbs5 != null) txtAbs5.Enabled = Enable;

                TextBox txtOver0 = itm.FindControl("txtOver0") as TextBox;
                if (txtOver0 != null) txtOver0.Enabled = Enable;

                TextBox txtOver1 = itm.FindControl("txtOver1") as TextBox;
                if (txtOver1 != null) txtOver1.Enabled = Enable;

                TextBox txtOver2 = itm.FindControl("txtOver2") as TextBox;
                if (txtOver2 != null) txtOver2.Enabled = Enable;

                TextBox txtOver3 = itm.FindControl("txtOver3") as TextBox;
                if (txtOver3 != null) txtOver3.Enabled = Enable;

                TextBox txtPen0 = itm.FindControl("txtPen0") as TextBox;
                if (txtPen0 != null) txtPen0.Enabled = Enable;

                TextBox txtRemark = itm.FindControl("txtRemark") as TextBox;
                if (txtRemark != null) txtRemark.Enabled = Enable;
            }
        }


        public void grdCodesSwitch(Boolean Enable)
        {
            foreach (GridViewRow itm in grdCodes.Rows)
            {
                TextBox txtDed03 = itm.FindControl("txtDed03") as TextBox;
                if (txtDed03 != null) txtDed03.Enabled = Enable;

                TextBox txtRemark = itm.FindControl("txtRemark") as TextBox;
                if (txtRemark != null) txtRemark.Enabled = Enable;
            }
        }



        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlMonth.SelectedIndex > 0 && ddlSection.SelectedIndex > 0)
                {
                    DisplayAgree();

                    SalOP mySal = new SalOP();
                    mySal.Year1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                    mySal.Month1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                    mySal.Section = short.Parse(ddlSection.SelectedValue);
                    MyOver2.Clear();
                    MyOver = mySal.GetDep(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (MyOver == null || MyOver.Count() < 1)
                    {
                        txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                        txtUserName.Text = Session["FullUser"].ToString();
                        txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));

                        Salaries myacc = new Salaries();
                        myacc.Year1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                        myacc.Month1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                        foreach (Salaries itm in (from itm in myacc.GetAllSalary(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                                     where itm.Dep == int.Parse(ddlSection.SelectedValue)
                                                     select itm).ToList())
                        {
                            MyOver.Add(new SalOP {
                                EmpCode = itm.EmpCode,
                                Month1 = itm.Month1,
                                Year1 = itm.Year1,
                                Name = itm.Name,
                                Name2 = itm.Name2,
                                Section = (short)itm.Dep,
                                UserName = txtUserName.ToolTip,
                                UserDate = txtUserDate.Text                                                        
                            });


                            //double vBasic = 0, vSal = 0, vDed = 0;
                            //SEmp myEmp = new SEmp();
                            //myEmp.EmpCode = itm.EmpCode;
                            //myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            //if (myEmp != null)
                            //{
                            //    vBasic = (double)myEmp.Basic;
                            //    vSal = (double)(myEmp.Basic + myEmp.Add01 + myEmp.Add02 + myEmp.Add03 + myEmp.Add05 + myEmp.Add13 + myEmp.Add14);
                            //    vDed = (double)(myEmp.Add01 + myEmp.Add03 + myEmp.Add05 + myEmp.Add13 + myEmp.Add14);
                            //}

                            MyOver2.Add(new SalOP {
                                EmpCode = itm.EmpCode,
                                Month1 = itm.Month1,
                                Year1 = itm.Year1,
                                Name = itm.Name,
                                Name2 = itm.Name2,
                                Abs0 = itm.NoDays,
                                Abs1 = (itm.NoDays == 0 ? 0 : itm.Net + itm.Ded03 + itm.Ded13),
                                Ded03 = itm.Ded03,
                                Ded3 = itm.Ded13,
                                Add0 = (itm.NoDays<30 ? itm.AddAll-itm.Ded01 : 0),
                                /*
                                Abs2 = ((vBasic / 240) * 1.5 * 8 * MyOver[MyOver.Count() - 1].Over0) + ((vBasic / 240) * 1.5 * MyOver[MyOver.Count() - 1].Over1),
                                Abs3 = ((vSal / 30) * MyOver[MyOver.Count() - 1].Abs0) +
                                       ((vDed / 30) * MyOver[MyOver.Count() - 1].Abs3) + 
                                       ((vSal / 30) * MyOver[MyOver.Count() - 1].Abs4) +
                                       ((vBasic / 240) * (MyOver[MyOver.Count() - 1].Over3 / 60)) + 
                                       ((vBasic / 30) * MyOver[MyOver.Count() - 1].Pen0),

                                Abs4 = itm.Net + 
                                       ((vBasic / 240) * 1.5 * 8 * MyOver[MyOver.Count() - 1].Over0) + ((vBasic / 240) * 1.5 * MyOver[MyOver.Count() - 1].Over1) - 
                                       (((vSal / 30) * MyOver[MyOver.Count() - 1].Abs0) +
                                       ((vDed / 30) * MyOver[MyOver.Count() - 1].Abs3) + 
                                       ((vSal / 30) * MyOver[MyOver.Count() - 1].Abs4) +
                                       ((vBasic / 240) * (MyOver[MyOver.Count() - 1].Over3 / 60)) + 
                                       ((vBasic / 30) * MyOver[MyOver.Count() - 1].Pen0)),

                                Over0 = Math.Round(moh.GetBal("12050"+itm.EmpCode.ToString(), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString),2),
                                Over1 = 0,
                                Over2 = 0,  //Math.Round(((Over1 + Abs3) / (itm.Net + Abs2)) * 100,2)
                                 */
                            });
 
                        }
                    }
                    else
                    {
                        if (Request.QueryString["FStep"] != null && Request.QueryString["FStep"].ToString() == "0")
                        {
                            bool vFound = false;
                            Salaries myacc = new Salaries();
                            myacc.Year1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                            myacc.Month1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                            foreach (Salaries itm in (from itm in myacc.GetAllSalary(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                                         where itm.Dep == int.Parse(ddlSection.SelectedValue)
                                                         select itm).ToList())
                            {
                                vFound = false;
                                foreach (SalOP sitem in MyOver)
                                {
                                    if (itm.EmpCode == sitem.EmpCode)
                                    {
                                        vFound = true;
                                        break;
                                    }
                                }
                                if (!vFound)
                                {
                                    MyOver.Add(new SalOP
                                    {
                                        EmpCode = itm.EmpCode,
                                        Month1 = itm.Month1,
                                        Year1 = itm.Year1,
                                        Name = itm.Name,
                                        Name2 = itm.Name2,
                                        Section = (short)itm.Dep,
                                        UserName = txtUserName.ToolTip,
                                        UserDate = txtUserDate.Text
                                    });


                                    MyOver2.Add(new SalOP
                                    {
                                        EmpCode = itm.EmpCode,
                                        Month1 = itm.Month1,
                                        Year1 = itm.Year1,
                                        Name = itm.Name,
                                        Name2 = itm.Name2,
                                        Abs0 = itm.NoDays,
                                        Abs1 = (itm.NoDays == 0 ? 0 : itm.Net + itm.Ded03 + itm.Ded13),
                                        Ded03 = itm.Ded03,
                                        Ded3 = itm.Ded13,
                                        Add0 = (itm.NoDays < 30 ? itm.AddAll - itm.Ded01 : 0),
                                    });
                                }                            
                            }
                        }

                        foreach (SalOP sitem in MyOver)
                        {
                            Salaries itm = new Salaries();
                            itm.Year1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                            itm.Month1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                            itm.EmpCode = sitem.EmpCode;
                            itm = itm.GetEmp(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if(itm != null)
                            {
                                MyOver2.Add(new SalOP
                                {
                                    EmpCode = itm.EmpCode,
                                    Month1 = itm.Month1,
                                    Year1 = itm.Year1,
                                    Name = itm.Name,
                                    Name2 = itm.Name2,
                                    Abs0 = itm.NoDays,
                                    Abs1 = (itm.NoDays == 0 ? 0 : itm.Net + itm.Ded03 + itm.Ded13),
                                    Ded3 = itm.Ded13,
                                    Ded03 = itm.Ded03,
                                    Add0 = (itm.NoDays < 30 ? itm.AddAll - itm.Ded01 : 0)
                                });
                            }
                        }
                        txtUserDate.Text = MyOver[0].UserDate;
                        txtUserName.ToolTip = MyOver[0].UserName;
                        TblUsers ax = new TblUsers();
                        if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        ax.UserName = MyOver[0].UserName;
                        ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                              where uitm.UserName == ax.UserName
                              select uitm).FirstOrDefault();
                        if (ax == null)
                        {
                            txtUserName.Text = txtUserName.ToolTip;
                        }
                        else
                        {
                            txtUserName.Text = ax.FName;
                        }
                    }

                    int r = 0;
                    foreach (SalOP itm in MyOver)
                    {
                        EmpTypes eType = new EmpTypes();
                        Absent myabs = new Absent();
                        myabs.EmpCode = itm.EmpCode;
                        eType = myabs.GetEmpTypes(itm.Year1, itm.Month1, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (eType != null && itm.Remark == "")
                        {
                            if (eType.Abs0 != null) itm.Abs0 = eType.Abs0;
                            if (eType.Abs1 != null) itm.Abs1 = eType.Abs1;
                            if (eType.Abs2 != null) itm.Abs2 = eType.Abs2;
                            if (eType.Abs3 != null) itm.Abs3 = eType.Abs3;
                            if (eType.Abs4 != null) itm.Abs4 = eType.Abs4;
                            if (eType.Abs5 != null) itm.Abs5 = eType.Abs5;
                        }



                        string vFDate = "01/" + moh.MakeMask(itm.Month1.ToString(), 2) + "/" + itm.Year1.ToString();
                        string vEDate = DateTime.DaysInMonth((int)itm.Year1, (int)itm.Month1).ToString()+ "/" + moh.MakeMask(itm.Month1.ToString(), 2) + "/" + itm.Year1.ToString();

                        // Check WorkFlow
                        double vAbs5 = 0;
                        eServices myService = new eServices();
                        myService.EmpCode = itm.EmpCode;
                        myService.DocType = 201;
                        foreach(eServices es in (from sitm in myService.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                     where sitm.Status == 99 &&
                                     ((DateTime.Parse(sitm.SDate) >= DateTime.Parse(vFDate) && DateTime.Parse(sitm.SDate) <= DateTime.Parse(vEDate)) ||
                                     (DateTime.Parse(sitm.SDate)<=DateTime.Parse(vFDate) && DateTime.Parse(sitm.EDate)>=DateTime.Parse(vEDate)) ||
                                     (DateTime.Parse(sitm.SDate)<=DateTime.Parse(vFDate) && DateTime.Parse(sitm.EDate)<=DateTime.Parse(vEDate) && DateTime.Parse(sitm.EDate)>=DateTime.Parse(vFDate)))
                                     select sitm).ToList())
                        {

                            if (DateTime.Parse(es.SDate) >= DateTime.Parse(vFDate))
                            {
                                if (DateTime.Parse(es.EDate) >= DateTime.Parse(vEDate))
                                {
                                    vAbs5 = (DateTime.Parse(vEDate) - DateTime.Parse(es.SDate)).Days + 1;
                                    if (DateTime.DaysInMonth((int)itm.Year1, (int)itm.Month1) == 31) vAbs5 -= 1;
                                    else if (DateTime.DaysInMonth((int)itm.Year1, (int)itm.Month1) == 29) vAbs5 += 1;
                                    else if (DateTime.DaysInMonth((int)itm.Year1, (int)itm.Month1) == 28) vAbs5 += 2;
                                }
                                else
                                {
                                    vAbs5 = (DateTime.Parse(es.EDate) - DateTime.Parse(es.SDate)).Days + 1;
                                }
                            }
                            else
                            {
                                if (DateTime.Parse(es.EDate) >= DateTime.Parse(vEDate))
                                {
                                    vAbs5 = (DateTime.Parse(vEDate) - DateTime.Parse(vFDate)).Days + 1;
                                    if (DateTime.DaysInMonth((int)itm.Year1, (int)itm.Month1) == 31) vAbs5 -= 1;
                                    else if (DateTime.DaysInMonth((int)itm.Year1, (int)itm.Month1) == 29) vAbs5 += 1;
                                    else if (DateTime.DaysInMonth((int)itm.Year1, (int)itm.Month1) == 28) vAbs5 += 2;
                                }
                                else
                                {
                                    vAbs5 = (DateTime.Parse(es.EDate) - DateTime.Parse(vFDate)).Days + 1;
                                }
                            }

                            itm.Remark += " طلب اجازة رقم " + es.DocNo.ToString() + " " + (from qitm in (List<Codes>)(Cache["LastCodes" + Session["CNN2"].ToString()])
                                                       where qitm.Ftype == 10 && qitm.Code == int.Parse(es.FType.ToString())
                                                       select qitm.Name1).FirstOrDefault();

                            if (es.FType == 228) itm.Abs2 = vAbs5;
                            else if (es.FType == 290) itm.Abs4 = vAbs5;
                            else itm.Abs5 = vAbs5;
                        }
                        



                        List<AttLog> lAttLog = new List<AttLog>();
                        AttLog mytime = new AttLog();
                        mytime.EmpCode = itm.EmpCode;
                        mytime.FDate = "01/" + moh.MakeMask(itm.Month1.ToString(), 2) + "/" + itm.Year1.ToString();
                        lAttLog = mytime.GetByEmpMonth(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        if (lAttLog != null && lAttLog.Count > 0)
                        {
                            CalDelay(itm, lAttLog);
                            itm.Over3 = lAttLog.Sum(p => p.Delay);
                        }

                        MyOver2[r].Ded03 = itm.Ded03;

                        if (MyOver2[r].Abs0 > 0)
                        {
                            double vBasic = 0, vSal = 0, vDed = 0;
                            SEmp myEmp = new SEmp();
                            myEmp.EmpCode = itm.EmpCode;
                            myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myEmp != null)
                            {
                                vBasic = (double)myEmp.Basic;
                                vSal = (double)(myEmp.Basic + myEmp.Add01 + myEmp.Add02 + myEmp.Add03 + myEmp.Add05 + myEmp.Add13 + myEmp.Add14);
                                vDed = (double)(myEmp.Add01 + myEmp.Add03 + myEmp.Add05 + myEmp.Add13 + myEmp.Add14);
                                MyOver2[r].Abs1 = myEmp.Net;
                                //MyOver2[r].Add0 = myEmp.AddAll - MyOver2[r].Add0;
                            }
                            MyOver2[r].Abs0 = MyOver2[r].Abs0 - itm.Abs0 - (BtnAgree1.Visible ? 0: itm.Abs4);
                            MyOver2[r].Abs1 = MyOver2[r].Abs1;// - Math.Round((double)(vSal / 30 * (itm.Abs0 + itm.Abs4)), 2);
                            MyOver2[r].Abs2 = Math.Round((double)(((vBasic / 240) * 1.5 * 8 * (itm.Over0 + itm.Over2)) + ((vBasic / 240) * 1.5 * itm.Over1)), 2);
                            MyOver2[r].Abs3 = Math.Round((double)(((vSal / 30) * itm.Abs0) + (((vBasic / 240) * (itm.Over3 / 60)) + ((vDed / 30) * itm.Abs3) + ((vBasic / 30) * itm.Pen0))), 2);
                            //MyOver2[r].Abs3 = Math.Round((double)(((vSal / 30) * itm.Abs0) +  ((vSal / 30) * itm.Abs4) + (((vBasic / 240) * (itm.Over3 / 60)) + ((vDed / 30) * itm.Abs3) + ((vBasic / 30) * itm.Pen0))), 2);
                                                //Math.Round((double)(((vBasic / 240) * (itm.Over3 / 60)) + ((vDed / 30) * itm.Abs3) + ((vBasic / 30) * itm.Pen0)), 2);
                            MyOver2[r].Abs4 = MyOver2[r].Abs1 + MyOver2[r].Abs2 - MyOver2[r].Abs3 - (BtnAgree1.Visible ? 0 :((vSal / 30) * itm.Abs4));
                        }
                            //MyOver2[r].Over1 = 0,
                            //MyOver2[r].Over2 = 0,  //Math.Round(((Over1 + Abs3) / (itm.Net + Abs2)) * 100,2)
                            MyOver2[r].Over0 = Math.Round(moh.GetBal("12050" + itm.EmpCode.ToString(), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString), 2);
                        r++;
                        if(r >= MyOver2.Count ) break;
                    }

                    grdAbs.DataSource = MyOver;
                    grdAbs.DataBind();

                    grdCodes.DataSource = MyOver2;
                    grdCodes.DataBind();


                    LoadAttachData();                                        

                }
                else
                {
                    EnableAgree(0);
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

        public void CalDelay(SalOP myItem , List<AttLog> lAttLog)
        {
            string lblCount = "";

            SEmp myEmp = new SEmp();
            myEmp.EmpCode = myItem.EmpCode;
            myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

            vAttLogShift myshift = new vAttLogShift();
            myshift.EmpCode = myItem.EmpCode;
            foreach (vAttLogShift itm in myshift.Late(myItem.Year1, myItem.Month1, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            {
                lblCount = HDate.Ch_Date(HDate.DatetoHjiri(itm.FDate)).Month.ToString();

                if (HDate.Ch_Date(itm.FDate) >= DateTime.Parse("01/" + moh.MakeMask(myItem.Month1.ToString(),2) + "/" + myItem.Year1.ToString() ))
                {
                    foreach (AttLog sitm in lAttLog)
                    {
                        if (itm.FDate == sitm.FDate)
                        {
                            if (itm.FMonth > 0)
                            {
                                sitm.Delay += itm.FMonth;
                                sitm.YAllowMin += itm.FYear;
                                sitm.MAllowMin += itm.FMonth2;
                            }
                            break;
                        }
                    }
                }
            }

            myshift = new vAttLogShift();
            myshift.EmpCode = myItem.EmpCode;
            foreach (vAttLogShift itm in myshift.AllowLate(myItem.Year1, myItem.Month1, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            {
                if (HDate.Ch_Date(itm.FDate) >= DateTime.Parse("01/" + moh.MakeMask(myItem.Month1.ToString(), 2) + "/" + myItem.Year1.ToString()))
                {
                    foreach (AttLog sitm in lAttLog)
                    {
                        if (itm.FDate == sitm.FDate)
                        {
                            if (itm.delay > 0)
                            {
                                sitm.Delay2 += itm.delay;
                                sitm.MAllowMin += itm.FMonth0;
                                sitm.MAllowCount += itm.FMonth2;
                                sitm.YAllowMin += itm.FMonth;
                                sitm.YAllowCount += itm.FYear;
                            }
                            break;
                        }
                    }
                }
            }

            myshift = new vAttLogShift();
            myshift.EmpCode = myItem.EmpCode;
            foreach (vAttLogShift itm in myshift.Early(myItem.Year1, myItem.Month1, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            {
                if (HDate.Ch_Date(itm.FDate) >= DateTime.Parse("01/" + moh.MakeMask(myItem.Month1.ToString(), 2) + "/" + myItem.Year1.ToString()))
                {
                    foreach (AttLog sitm in lAttLog)
                    {
                        if (itm.FDate == sitm.FDate)
                        {
                            if (itm.FMonth > 0)
                            {
                                sitm.Early += itm.FMonth;
                                sitm.eYAllowMin += itm.FYear;
                                sitm.eMAllowMin += itm.FMonth2;
                            }
                            break;
                        }
                    }
                }
            }

            myshift = new vAttLogShift();
            myshift.EmpCode = myItem.EmpCode;
            foreach (vAttLogShift itm in myshift.AllowEarly(myItem.Year1, myItem.Month1, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            {
                if (HDate.Ch_Date(itm.FDate) >= DateTime.Parse("01/" + moh.MakeMask(myItem.Month1.ToString(), 2) + "/" + myItem.Year1.ToString()))
                {
                    foreach (AttLog sitm in lAttLog)
                    {
                        if (itm.FDate == sitm.FDate)
                        {
                            if (itm.delay > 0)
                            {
                                sitm.Early2 += itm.delay;
                                sitm.eMAllowMin += itm.FMonth0;
                                sitm.eMAllowCount += itm.FMonth2;
                                sitm.eYAllowMin += itm.FMonth;
                                sitm.eYAllowCount += itm.FYear;
                            }
                            break;
                        }
                    }
                }
            }


            int? YMLate = 0, MMLate = 0;
            int? YMLCount = 0, MMLCount = 0;

            int? YMEarly = 0, MMEarly = 0;
            int? YMECount = 0, MMECount = 0;

            foreach (AttLog sitm in lAttLog)
            {
                bool vEmpty = false;
                if (sitm.Delay > 0)
                {
                    if (sitm.STime == "" || sitm.ETime == "")
                    {
                    }
                    else
                    {
                        if (YMLate == 0 && MMLate == 0)
                        {
                            YMLate += sitm.YAllowMin;
                            MMLate += sitm.MAllowMin + sitm.Delay;
                        }
                        else
                        {
                            YMLate += sitm.Delay;
                            MMLate += sitm.Delay;
                        }
                    }

                    sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " تاخير " + YMLate.ToString() + "/" + MMLate.ToString();
                    if (!vEmpty && ((!(bool)sitm.SPer && sitm.STime == "") || (!(bool)sitm.EPer && sitm.ETime == "")) && HDate.Ch_Date(sitm.FDate) < HDate.Ch_Date(moh.Nows().ToShortDateString()))
                    {
                        sitm.Delay += (sitm.Forget * 60);
                        sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " نسيان تسجيل " + (!(bool)sitm.SPer && sitm.STime == "" ? "حضور " : "أنصراف ");
                        vEmpty = true;
                    }
                }


                if (sitm.Delay2 > 0)
                {
                    if (YMLCount == 0 && MMLCount == 0)
                    {
                        YMLCount += sitm.YAllowCount;
                        MMLCount += sitm.MAllowCount;
                    }
                    else
                    {
                        YMLCount++;
                        MMLCount++;
                    }
                    if (YMLate == 0 && MMLate == 0)
                    {
                        YMLate += sitm.YAllowMin;
                        MMLate += sitm.MAllowMin + sitm.Delay2;
                    }
                    else
                    {
                        YMLate += sitm.Delay2;
                        MMLate += sitm.Delay2;
                    }

                    //if (YMLCount > 63 || MMLCount > 7 || YMLate > 480 || MMLate > 90)
                    if (YMLCount > sitm.YDLateNo || MMLCount > sitm.MDLateNo || YMLate > sitm.YDLate || MMLate > sitm.MDLate)
                    {
                        sitm.Delay = sitm.Delay2;
                        sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " تاخير " + YMLate.ToString() + "/" + MMLate.ToString();
                    }
                    else sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " مهلة تاخير " + YMLCount.ToString() + "/" + MMLCount.ToString() + " " + YMLate.ToString() + "/" + MMLate.ToString();

                    if (!vEmpty && ((!(bool)sitm.SPer && sitm.STime == "") || (!(bool)sitm.EPer && sitm.ETime == "")) && HDate.Ch_Date(sitm.FDate) < HDate.Ch_Date(moh.Nows().ToShortDateString()))
                    {
                        sitm.Delay += (sitm.Forget * 60);
                        sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " نسيان تسجيل " + (!(bool)sitm.SPer && sitm.STime == "" ? "حضور " : "أنصراف ");
                        vEmpty = true;
                    }
                }

                if (sitm.Early > 0)
                {
                    if (YMEarly == 0 && MMEarly == 0)
                    {
                        // YMEarly += sitm.eYAllowMin;
                        // MMEarly += sitm.eMAllowMin + sitm.Early;
                    }
                    else
                    {
                        // YMEarly += sitm.Early;
                        // MMEarly += sitm.Early;
                    }
                    sitm.Delay += sitm.Early;
                    sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " أنصراف مبكر "; // +YMEarly.ToString() + "/" + MMEarly.ToString();

                    if (!vEmpty && ((!(bool)sitm.SPer && sitm.STime == "") || (!(bool)sitm.EPer && sitm.ETime == "")) && HDate.Ch_Date(sitm.FDate) < HDate.Ch_Date(moh.Nows().ToShortDateString()))
                    {
                        sitm.Delay += (sitm.Forget * 60);
                        sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " نسيان تسجيل " + (!(bool)sitm.SPer && sitm.STime == "" ? "حضور " : "أنصراف ");
                        vEmpty = true;
                    }
                }
                if (sitm.Early2 > 0)
                {
                    if (YMECount == 0 && MMECount == 0)
                    {
                        YMECount += ++sitm.eYAllowCount;
                        MMECount += ++sitm.eMAllowCount;
                    }
                    else
                    {
                        YMECount++;
                        MMECount++;
                    }
                    if (YMEarly == 0 && MMEarly == 0)
                    {
                        YMEarly += sitm.eYAllowMin;
                        MMEarly += sitm.eMAllowMin + sitm.Early2;
                    }
                    else
                    {
                        YMEarly += sitm.Early2;
                        MMEarly += sitm.Early2;
                    }

                    //if (YMLCount > 63 || MMLCount > 7 || YMLate > 480 || MMLate > 90)
                    if (YMECount > sitm.YDEarlyNo || MMECount > sitm.MDEarlyNo || YMEarly > sitm.YDEarly || MMEarly > sitm.MDEarly)
                    {
                        sitm.Delay += sitm.Early2;
                        sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " أنصراف مبكر "; // +YMEarly.ToString() + "/" + MMEarly.ToString();
                    }
                    else sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " مهلة أنصراف مبكر " + YMECount.ToString() + "/" + MMECount.ToString() + " " + YMEarly.ToString() + "/" + MMEarly.ToString();

                    if (!vEmpty && ((!(bool)sitm.SPer && sitm.STime == "") || (!(bool)sitm.EPer && sitm.ETime == "")) && HDate.Ch_Date(sitm.FDate) < HDate.Ch_Date(moh.Nows().ToShortDateString()))
                    {
                        sitm.Delay += (sitm.Forget * 60);
                        sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " نسيان تسجيل " + (!(bool)sitm.SPer && sitm.STime == "" ? "حضور " : "أنصراف ");
                        vEmpty = true;
                    }

                }

                if (!vEmpty && ((!(bool)sitm.SPer && sitm.STime == "") || (!(bool)sitm.EPer && sitm.ETime == "")) && HDate.Ch_Date(sitm.FDate) < HDate.Ch_Date(moh.Nows().ToShortDateString()))
                {
                    sitm.Delay += (sitm.Forget * 60);
                    sitm.Remark += (sitm.Remark.Trim() != "" ? "-" : "") + " نسيان تسجيل " + (!(bool)sitm.SPer && sitm.STime == "" ? "حضور " : "أنصراف ");
                    vEmpty = true;
                }

            }
        }

        public void InitAgree()
        {
            divStep1.Visible = false;
            divStep2.Visible = false;
            divStep3.Visible = false;
            divStep4.Visible = false;
            divStep5.Visible = false;
            divStep6.Visible = false;
            divStep7.Visible = false;

            grdCodes.Visible = false;
            grdCodesSwitch(false);

            BtnAgree1.ImageUrl = "~/images/Agree_641.png";
            BtnAgree2.ImageUrl = "~/images/Agree_641.png";
            BtnAgree3.ImageUrl = "~/images/Agree_641.png";
            BtnAgree4.ImageUrl = "~/images/Agree_641.png";
            BtnAgree5.ImageUrl = "~/images/Agree_641.png";
            BtnAgree6.ImageUrl = "~/images/Agree_641.png";
            BtnAgree7.ImageUrl = "~/images/Agree_641.png";

            BtnDisagree1.ImageUrl = "~/images/DisAgree_641.png";
            BtnDisagree2.ImageUrl = "~/images/DisAgree_641.png";
            BtnDisagree3.ImageUrl = "~/images/DisAgree_641.png";
            BtnDisagree4.ImageUrl = "~/images/DisAgree_641.png";
            BtnDisagree5.ImageUrl = "~/images/DisAgree_641.png";
            BtnDisagree6.ImageUrl = "~/images/DisAgree_641.png";
            BtnDisagree7.ImageUrl = "~/images/DisAgree_641.png";

            BtnAgree1.CssClass = "ops";
            BtnAgree2.CssClass = "ops";
            BtnAgree3.CssClass = "ops";
            BtnAgree4.CssClass = "ops";
            BtnAgree5.CssClass = "ops";
            BtnAgree6.CssClass = "ops";
            BtnAgree7.CssClass = "ops";

            BtnDisagree1.CssClass = "ops";
            BtnDisagree2.CssClass = "ops";
            BtnDisagree3.CssClass = "ops";
            BtnDisagree4.CssClass = "ops";
            BtnDisagree5.CssClass = "ops";
            BtnDisagree6.CssClass = "ops";
            BtnDisagree7.CssClass = "ops";

            txtAgreeRemark1.Text = "";
            txtAgreeUser1.Text = "";
            txtAgreeUserDate1.Text = "";
            BtnAgree1.Visible = true;
            BtnDisagree1.Visible = true;
            txtAgreeRemark1.ReadOnly = true;
            BtnAgree1.Enabled = false;
            BtnDisagree1.Enabled = false;

            txtAgreeRemark2.Text = "";
            txtAgreeUser2.Text = "";
            txtAgreeUserDate2.Text = "";
            BtnAgree2.Visible = true;
            BtnDisagree2.Visible = true;
            txtAgreeRemark2.ReadOnly = true;
            BtnAgree2.Enabled = false;
            BtnDisagree2.Enabled = false;

            txtAgreeRemark3.Text = "";
            txtAgreeUser3.Text = "";
            txtAgreeUserDate3.Text = "";
            BtnAgree3.Visible = true;
            BtnDisagree3.Visible = true;
            txtAgreeRemark3.ReadOnly = true;
            BtnAgree3.Enabled = false;
            BtnDisagree3.Enabled = false;

            txtAgreeRemark4.Text = "";
            txtAgreeUser4.Text = "";
            txtAgreeUserDate4.Text = "";
            BtnAgree4.Visible = true;
            BtnDisagree4.Visible = true;
            txtAgreeRemark4.ReadOnly = true;
            BtnAgree4.Enabled = false;
            BtnDisagree4.Enabled = false;

            txtAgreeRemark5.Text = "";
            txtAgreeUser5.Text = "";
            txtAgreeUserDate5.Text = "";
            BtnAgree5.Visible = true;
            BtnDisagree5.Visible = true;
            txtAgreeRemark5.ReadOnly = true;
            BtnAgree5.Enabled = false;
            BtnDisagree5.Enabled = false;

            txtAgreeRemark6.Text = "";
            txtAgreeUser6.Text = "";
            txtAgreeUserDate6.Text = "";
            BtnAgree6.Visible = true;
            BtnDisagree6.Visible = true;
            txtAgreeRemark6.ReadOnly = true;
            BtnAgree6.Enabled = false;
            BtnDisagree6.Enabled = false;

            txtAgreeRemark7.Text = "";
            txtAgreeUser7.Text = "";
            txtAgreeUserDate7.Text = "";
            BtnAgree7.Visible = true;
            BtnDisagree7.Visible = true;
            txtAgreeRemark7.ReadOnly = true;
            BtnAgree7.Enabled = false;
            BtnDisagree7.Enabled = false;
        }

        public void DisplayAgree()
        {
            InitAgree();
            BtnEdit.Visible = true;

            Agreement myAgree = new Agreement();
            myAgree.FType = 400;
            myAgree.LocType = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
            myAgree.LocNumber = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
            myAgree.Number = int.Parse(ddlSection.SelectedValue);

            TblUsers ax = new TblUsers();
            foreach (Agreement itm in myAgree.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            {
                if (itm.FNo == 1)
                {
                    BtnEdit.Visible = false;
                    grdAbsSwitch(false);
                    divStep1.Visible = true;

                    txtAgreeRemark1.Text = itm.AgreeRemark;
                    BtnAgree1.Visible = (itm.Agree == 1);
                    BtnDisagree1.Visible = (itm.Agree != 1);

                    if (BtnAgree1.Visible)
                    {
                        BtnAgree1.ImageUrl = "~/images/doAgree_641.png";
                        BtnAgree1.CssClass = "";
                    }
                    else
                    {
                        BtnDisagree1.ImageUrl = "~/images/doDisAgree_641.png";
                        BtnDisagree1.CssClass = "";
                    }

                    txtAgreeUserDate1.Text = itm.AgreeUserDate;
                    txtAgreeUser1.ToolTip = itm.AgreeUser;

                    ax = new TblUsers();
                    ax.UserName = itm.AgreeUser;
                    ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                          where uitm.UserName == ax.UserName
                          select uitm).FirstOrDefault();
                    if (ax == null)
                    {
                        txtAgreeUser1.Text = txtAgreeUser1.ToolTip;
                    }
                    else
                    {
                        txtAgreeUser1.Text = ax.FName;
                    }
                    //BtnEdit.Visible = false;
                }
                else if (itm.FNo == 2)
                {
                    BtnEdit.Visible = false;
                    grdAbsSwitch(false);
                    divStep2.Visible = true;

                    txtAgreeRemark2.Text = itm.AgreeRemark;
                    BtnAgree2.Visible = (itm.Agree == 1);
                    BtnDisagree2.Visible = (itm.Agree != 1);
                    txtAgreeUserDate2.Text = itm.AgreeUserDate;
                    txtAgreeUser2.ToolTip = itm.AgreeUser;

                    if (BtnAgree2.Visible)
                    {
                        BtnAgree2.ImageUrl = "~/images/doAgree_641.png";
                        BtnAgree2.CssClass = "";
                    }
                    else
                    {
                        BtnDisagree2.ImageUrl = "~/images/doDisAgree_641.png";
                        BtnDisagree2.CssClass = "";
                    }

                    ax = new TblUsers();
                    ax.UserName = itm.AgreeUser;
                    ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                          where uitm.UserName == ax.UserName
                          select uitm).FirstOrDefault();
                    if (ax == null)
                    {
                        txtAgreeUser2.Text = txtAgreeUser2.ToolTip;
                    }
                    else
                    {
                        txtAgreeUser2.Text = ax.FName;
                    }
                    //BtnEdit.Visible = false;
                }
                else if (itm.FNo == 3)
                {
                    BtnEdit.Visible = false;
                    grdAbsSwitch(false);
                    divStep3.Visible = true;

                    txtAgreeRemark3.Text = itm.AgreeRemark;
                    BtnAgree3.Visible = (itm.Agree == 1);
                    BtnDisagree3.Visible = (itm.Agree != 1);
                    txtAgreeUserDate3.Text = itm.AgreeUserDate;
                    txtAgreeUser3.ToolTip = itm.AgreeUser;

                    grdCodes.Visible = true;

                    if (BtnAgree3.Visible)
                    {
                        BtnAgree3.ImageUrl = "~/images/doAgree_641.png";
                        BtnAgree3.CssClass = "";
                    }
                    else
                    {
                        BtnDisagree3.ImageUrl = "~/images/doDisAgree_641.png";
                        BtnDisagree3.CssClass = "";
                    }

                    ax = new TblUsers();
                    ax.UserName = itm.AgreeUser;
                    ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                          where uitm.UserName == ax.UserName
                          select uitm).FirstOrDefault();
                    if (ax == null)
                    {
                        txtAgreeUser3.Text = txtAgreeUser3.ToolTip;
                    }
                    else
                    {
                        txtAgreeUser3.Text = ax.FName;
                    }
                    //BtnEdit.Visible = false;
                }
                else if (itm.FNo == 4)
                {
                    BtnEdit.Visible = false;
                    grdAbsSwitch(false);
                    divStep4.Visible = true;
                    grdCodes.Visible = true;
                    txtAgreeRemark4.Text = itm.AgreeRemark;
                    BtnAgree4.Visible = (itm.Agree == 1);
                    BtnDisagree4.Visible = (itm.Agree != 1);
                    txtAgreeUserDate4.Text = itm.AgreeUserDate;
                    txtAgreeUser4.ToolTip = itm.AgreeUser;

                    if (BtnAgree4.Visible)
                    {
                        BtnAgree4.ImageUrl = "~/images/doAgree_641.png";
                        BtnAgree4.CssClass = "";
                    }
                    else
                    {
                        BtnDisagree4.ImageUrl = "~/images/doDisAgree_641.png";
                        BtnDisagree4.CssClass = "";
                    }

                    ax = new TblUsers();
                    ax.UserName = itm.AgreeUser;
                    ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                          where uitm.UserName == ax.UserName
                          select uitm).FirstOrDefault();
                    if (ax == null)
                    {
                        txtAgreeUser4.Text = txtAgreeUser4.ToolTip;
                    }
                    else
                    {
                        txtAgreeUser4.Text = ax.FName;
                    }
                    //BtnEdit.Visible = false;
                }
                else if (itm.FNo == 5)
                {
                    BtnEdit.Visible = false;
                    grdAbsSwitch(false);
                    divStep5.Visible = true;
                    grdCodes.Visible = true;
                    txtAgreeRemark5.Text = itm.AgreeRemark;
                    BtnAgree5.Visible = (itm.Agree == 1);
                    BtnDisagree5.Visible = (itm.Agree != 1);
                    txtAgreeUserDate5.Text = itm.AgreeUserDate;
                    txtAgreeUser5.ToolTip = itm.AgreeUser;

                    if (BtnAgree5.Visible)
                    {
                        BtnAgree5.ImageUrl = "~/images/doAgree_641.png";
                        BtnAgree5.CssClass = "";
                    }
                    else
                    {
                        BtnDisagree5.ImageUrl = "~/images/doDisAgree_641.png";
                        BtnDisagree5.CssClass = "";
                    }

                    ax = new TblUsers();
                    ax.UserName = itm.AgreeUser;
                    ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                          where uitm.UserName == ax.UserName
                          select uitm).FirstOrDefault();
                    if (ax == null)
                    {
                        txtAgreeUser5.Text = txtAgreeUser5.ToolTip;
                    }
                    else
                    {
                        txtAgreeUser5.Text = ax.FName;
                    }
                    //BtnEdit.Visible = false;
                }
                else if (itm.FNo == 6)
                {
                    BtnEdit.Visible = false;
                    grdAbsSwitch(false);
                    divStep6.Visible = true;
                    grdCodes.Visible = true;
                    txtAgreeRemark6.Text = itm.AgreeRemark;
                    BtnAgree6.Visible = (itm.Agree == 1);
                    BtnDisagree6.Visible = (itm.Agree != 1);
                    txtAgreeUserDate6.Text = itm.AgreeUserDate;
                    txtAgreeUser6.ToolTip = itm.AgreeUser;

                    if (BtnAgree6.Visible)
                    {
                        BtnAgree6.ImageUrl = "~/images/doAgree_641.png";
                        BtnAgree6.CssClass = "";
                    }
                    else
                    {
                        BtnDisagree6.ImageUrl = "~/images/doDisAgree_641.png";
                        BtnDisagree6.CssClass = "";
                    }

                    ax = new TblUsers();
                    ax.UserName = itm.AgreeUser;
                    ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                          where uitm.UserName == ax.UserName
                          select uitm).FirstOrDefault();
                    if (ax == null)
                    {
                        txtAgreeUser6.Text = txtAgreeUser6.ToolTip;
                    }
                    else
                    {
                        txtAgreeUser6.Text = ax.FName;
                    }
                    //BtnEdit.Visible = false;
                }
                else if (itm.FNo == 7)
                {
                    BtnEdit.Visible = false;
                    grdAbsSwitch(false);
                    divStep7.Visible = true;
                    grdCodes.Visible = true;
                    txtAgreeRemark7.Text = itm.AgreeRemark;
                    BtnAgree7.Visible = (itm.Agree == 1);
                    BtnDisagree7.Visible = (itm.Agree != 1);
                    txtAgreeUserDate7.Text = itm.AgreeUserDate;
                    txtAgreeUser7.ToolTip = itm.AgreeUser;

                    if (BtnAgree7.Visible)
                    {
                        BtnAgree7.ImageUrl = "~/images/doAgree_641.png";
                        BtnAgree7.CssClass = "";
                    }
                    else
                    {
                        BtnDisagree7.ImageUrl = "~/images/doDisAgree_641.png";
                        BtnDisagree7.CssClass = "";
                    }

                    ax = new TblUsers();
                    ax.UserName = itm.AgreeUser;
                    ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                          where uitm.UserName == ax.UserName
                          select uitm).FirstOrDefault();
                    if (ax == null)
                    {
                        txtAgreeUser7.Text = txtAgreeUser7.ToolTip;
                    }
                    else
                    {
                        txtAgreeUser7.Text = ax.FName;
                    }
                    //BtnEdit.Visible = false;
                }
            }
        }

        public void EnableAgree(int Step)
        {            
            if (Step == 0)
            {
               // InitAgree();
            }
            else if (Step == 1)
            {
                divStep1.Visible = true;
                txtAgreeRemark1.ReadOnly = false;
                BtnAgree1.Visible = true;
                BtnDisagree1.Visible = true;
                BtnAgree1.Enabled = true;
                BtnDisagree1.Enabled = true;
            }
            else if (Step == 2)
            {
                divStep1.Visible = true;
                divStep2.Visible = true;
                txtAgreeRemark2.ReadOnly = false;
                BtnAgree2.Visible = true;
                BtnDisagree2.Visible = true;
                BtnAgree2.Enabled = true;
                BtnDisagree2.Enabled = true;                
            }
            else if (Step == 3)
            {
                divStep1.Visible = true;
                divStep2.Visible = true;
                divStep3.Visible = true;
                txtAgreeRemark3.ReadOnly = false;
                BtnAgree3.Visible = true;
                BtnDisagree3.Visible = true;
                BtnAgree3.Enabled = true;
                BtnDisagree3.Enabled = true;
                grdCodes.Visible = true;
                grdCodesSwitch(true);
            }
            else if (Step == 4)
            {
                divStep1.Visible = true;
                divStep2.Visible = true;
                divStep3.Visible = true;
                divStep4.Visible = true;
                BtnAgree4.Visible = true;
                BtnDisagree4.Visible = true;
                txtAgreeRemark4.ReadOnly = false;
                BtnAgree4.Enabled = true;
                BtnDisagree4.Enabled = true;
                grdCodes.Visible = true;
                grdCodesSwitch(true);
            }
            else if (Step == 5)
            {
                divStep1.Visible = true;
                divStep2.Visible = true;
                divStep3.Visible = true;
                divStep4.Visible = true;
                divStep5.Visible = true;
                BtnAgree5.Visible = true;
                BtnDisagree5.Visible = true;
                txtAgreeRemark5.ReadOnly = false;
                BtnAgree5.Enabled = true;
                BtnDisagree5.Enabled = true;
                grdCodes.Visible = true;
                grdCodesSwitch(false);
            }
            else if (Step == 6)
            {
                divStep1.Visible = true;
                divStep2.Visible = true;
                divStep3.Visible = true;
                divStep4.Visible = true;
                divStep5.Visible = true;
                divStep6.Visible = true;
                BtnAgree6.Visible = true;
                BtnDisagree6.Visible = true;
                txtAgreeRemark6.ReadOnly = false;
                BtnAgree6.Enabled = true;
                BtnDisagree6.Enabled = true;
                grdCodes.Visible = true;
                grdCodesSwitch(false);
            }
            else if (Step == 7)
            {
                divStep1.Visible = true;
                divStep2.Visible = true;
                divStep3.Visible = true;
                divStep4.Visible = true;
                divStep5.Visible = true;
                divStep6.Visible = true;
                divStep7.Visible = true;
                BtnAgree7.Visible = true;
                BtnDisagree7.Visible = true;
                txtAgreeRemark7.ReadOnly = false;
                BtnAgree7.Enabled = true;
                BtnDisagree7.Enabled = true;
                grdCodes.Visible = true;
                grdCodesSwitch(false);
            }
        }

        protected void BtnClear_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                LblCodesResult.Text = "";
                ddlMonth.SelectedIndex = 0;
                ddlSection.SelectedIndex = 0;
                grdAbs.DataSource = null;
                grdAbs.DataBind();

                this.grdCodes.DataSource = null;
                this.grdCodes.DataBind();

                this.grdAttach.DataSource = null;
                this.grdAttach.DataBind();
                Enableall();
                InitAgree();
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

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid) 
                {
                    if (ddlMonth.SelectedIndex == 0)
                    {

                    }
                    if (ddlSection.SelectedIndex == 0)
                    {

                    }
                    foreach (GridViewRow gvr in grdAbs.Rows)
                    {
                        string EmpCode = grdAbs.DataKeys[gvr.RowIndex]["EmpCode"].ToString();
                        TextBox txtAbs0 = gvr.FindControl("txtAbs0") as TextBox;
                        TextBox txtAbs1 = gvr.FindControl("txtAbs1") as TextBox;
                        TextBox txtAbs2 = gvr.FindControl("txtAbs2") as TextBox;
                        TextBox txtAbs3 = gvr.FindControl("txtAbs3") as TextBox;
                        TextBox txtAbs4 = gvr.FindControl("txtAbs4") as TextBox;
                        TextBox txtAbs5 = gvr.FindControl("txtAbs5") as TextBox;
                        TextBox txtOver0 = gvr.FindControl("txtOver0") as TextBox;
                        TextBox txtOver1 = gvr.FindControl("txtOver1") as TextBox;
                        TextBox txtOver2 = gvr.FindControl("txtOver2") as TextBox;
                        TextBox txtOver3 = gvr.FindControl("txtOver3") as TextBox;
                        TextBox txtPen0 = gvr.FindControl("txtPen0") as TextBox;
                        TextBox txtRemark = gvr.FindControl("txtRemark") as TextBox;
                        HiddenField txtAction = gvr.FindControl("txtAction") as HiddenField;

                        if (EmpCode != null && txtAbs0 != null && txtAbs1 != null && txtAbs2 != null && txtAbs3 != null && txtAbs4 != null && txtOver0 != null && txtOver1 != null && txtOver2 != null && txtOver3 != null && txtPen0 != null && txtRemark != null && txtAction != null && txtAbs5 != null)
                        {
                            SalOP mySal = new SalOP();
                            mySal.Year1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                            mySal.Month1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                            mySal.EmpCode = int.Parse(EmpCode);
                            bool vAdd = false;
                            mySal = mySal.GetMonthEmpCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (mySal == null)
                            {
                                vAdd = true;
                                mySal = new SalOP();
                                mySal.Year1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                                mySal.Month1 = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                                mySal.EmpCode = int.Parse(EmpCode);
                            }
                            mySal.Section = short.Parse(ddlSection.SelectedValue);
                            mySal.Abs0 = moh.StrToDouble(txtAbs0.Text);
                            mySal.Abs1 = moh.StrToDouble(txtAbs1.Text);
                            mySal.Abs2 = moh.StrToDouble(txtAbs2.Text);
                            mySal.Abs3 = moh.StrToDouble(txtAbs3.Text);
                            mySal.Abs4 = moh.StrToDouble(txtAbs4.Text);
                            mySal.Abs5 = moh.StrToDouble(txtAbs5.Text);
                            mySal.Over0 = moh.StrToDouble(txtOver0.Text);
                            mySal.Over1 = moh.StrToDouble(txtOver1.Text);
                            mySal.Over2 = moh.StrToDouble(txtOver2.Text);
                            mySal.Over3 = moh.StrToDouble(txtOver3.Text);
                            mySal.Pen0 = moh.StrToDouble(txtPen0.Text);
                            mySal.Remark = txtRemark.Text;
                            mySal.UserName = txtUserName.ToolTip;
                            mySal.UserDate = txtUserDate.Text;
                            if (vAdd) mySal.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            else if (txtAction.Value != "") mySal.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            doAgree myAgree = new doAgree();
                            myAgree.FType = 400;
                            myAgree.LocType = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                            myAgree.LocNumber = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                            myAgree.Number = int.Parse(ddlSection.SelectedValue);
                            myAgree.FNo = 0;
                            myAgree.UserName = "";
                            myAgree.UserName2 = "";
                            myAgree.UserGroup = "";
                            myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            myAgree.FNo = 1;
                            myAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            DepManager vDep = new DepManager();
                            vDep.Dep = int.Parse(ddlSection.SelectedValue);
                            vDep = vDep.GetDepManager(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            myAgree = new doAgree();
                            myAgree.FType = 400;
                            myAgree.LocType = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                            myAgree.LocNumber = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                            myAgree.Number = int.Parse(ddlSection.SelectedValue);
                            myAgree.FNo = 1;
                            myAgree.UserName = vDep.Manag1;
                            myAgree.UserName2 = "-1";  // vDep.Manag2;
                            myAgree.UserGroup = "";
                            myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                    }
                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(1,'" + LblCodesResult.Text + "');", true);
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


        [System.Web.Services.WebMethodAttribute(enableSession: true),
            System.Web.Script.Services.ScriptMethodAttribute()]
        public static string GetSalOPDynamicContent(string contextKey)
        {
            try
            {
                SEmp myEmp = new SEmp();
                myEmp.EmpCode = int.Parse(contextKey.Split('/')[0]);
                myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);

                SalOP mySal = new SalOP();               
                mySal.EmpCode = int.Parse(contextKey.Split('/')[0]);
                mySal.Year1 = short.Parse(contextKey.Split('/')[1]);

                StringBuilder b = new StringBuilder();
                b.Append("<table style='background-color:#f3f3f3; border: #336699 3px solid; ");
                b.Append("width:800px; font-size:10pt; font-family:Verdana;' cellspacing='0' cellpadding='3'>");

                b.Append("<tr><td colspan='12' style='background-color:#336699; color:white;'>");
                b.Append("<center><b>عرض بيان بمؤثرات الرواتب للموظف  " + myEmp.EmpCode.ToString() + " " + myEmp.Name  + "</b></center>");
                b.Append("</td></tr>");
                b.Append("<tr><td  style='text-align:center;width:50px;'><b>الشهر</b></td>");
                b.Append("<td style='text-align:center;width:50px;'><b>بدون عذر</b></td>");
                b.Append("<td style='text-align:center;width:50px;'><b>مرضي</b></td>");
                b.Append("<td style='text-align:center;width:50px;'><b>أضطراري</b></td>");
                b.Append("<td style='text-align:center;width:50px;'><b>أجازة براتب</b></td>");
                b.Append("<td style='text-align:center;width:50px;'><b>أجازة بدون راتب</b></td>");
                b.Append("<td style='text-align:center;width:50px;'><b>أجازة أخرى</b></td>");
                b.Append("<td style='text-align:center;width:50px;'><b>أضافي الجمع</b></td>");
                b.Append("<td style='text-align:center;width:50px;'><b>أضافي ساعات</b></td>");
                b.Append("<td style='text-align:center;width:50px;'><b>أعياد</b></td>");
                b.Append("<td style='text-align:center;width:50px;'><b>وطني</b></td>");
                b.Append("<td style='text-align:center;width:50px;'><b>جزاءات ساعات</b></td>");
                b.Append("<td style='text-align:center;width:200px;'><b>ملاحظات</b></td>");
                foreach (SalOP itm in mySal.GetEmpYear(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString))
                {
                    b.Append("<tr>");
                    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.Year1.ToString()+"/"+itm.Month1.ToString() + "</td>");
                    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.Abs0.ToString() + "</td>");
                    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.Abs1.ToString() + "</td>");
                    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.Abs2.ToString() + "</td>");
                    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.Abs3.ToString() + "</td>");
                    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.Abs4.ToString() + "</td>");
                    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.Abs5.ToString() + "</td>");
                    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.Over0.ToString() + "</td>");
                    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.Over1.ToString() + "</td>");
                    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.Over2.ToString() + "</td>");
                    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.Over3.ToString() + "</td>");
                    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.Pen0.ToString() + "</td>");
                    b.Append("<td style='border-top:1px solid #FFFFFF;text-align:center;'>" + itm.Remark + "</td>");
                    b.Append("</tr>");
                }

                b.Append("</table>");
                return b.ToString();
            }
            catch (Exception)
            {
                StringBuilder b = new StringBuilder();
                b.Append("<table style='background-color:#f3f3f3; border: #336699 3px solid; ");
                b.Append("width:1250px; font-size:10pt; font-family:Verdana;' cellspacing='0' cellpadding='3'>");
                b.Append("<tr><td colspan='12' style='background-color:#336699; color:white;'>");
                b.Append("<center><b>عرض بيان بمؤثرات الرواتب للموظف رقم " + contextKey.Split('/')[0] + "</b></center>");
                b.Append("</td></tr>");
                b.Append("<tr><td  style='text-align:center;width:50px;'><b>الشهر</b></td>");
                b.Append("<td style='text-align:center;width:90px;'><b>بدون عذر</b></td>");
                b.Append("<td style='text-align:center;width:90px;'><b>مرضي</b></td>");
                b.Append("<td style='text-align:center;width:90px;'><b>أضطراري</b></td>");
                b.Append("<td style='text-align:center;width:90px;'><b>أجازة براتب</b></td>");
                b.Append("<td style='text-align:center;width:90px;'><b>أجازة بدون راتب</b></td>");
                b.Append("<td style='text-align:center;width:90px;'><b>أجازة أخرى</b></td>");
                b.Append("<td style='text-align:center;width:90px;'><b>أضافي الجمع</b></td>");
                b.Append("<td style='text-align:center;width:90px;'><b>أضافي ساعات</b></td>");
                b.Append("<td style='text-align:center;width:90px;'><b>أعياد</b></td>");
                b.Append("<td style='text-align:center;width:90px;'><b>وطني</b></td>");
                b.Append("<td style='text-align:center;width:90px;'><b>جزاءات ساعات</b></td>");
                b.Append("<td style='text-align:center;width:200px;'><b>ملاحظات</b></td>");
                b.Append("<tr><td colspan='12'><center><b>لا توجد بيانات</b></center>");
                b.Append("</td></tr>");
                b.Append("</table>");
                return b.ToString();
            }
        }

        protected void BtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                var cols = new[] { 160, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 175, 50 };

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
                page.PageNo = "1";
                page.UserName = Session["FullUser"].ToString();
                MyConfig mysetting = new MyConfig();
                mysetting.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                mysetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);

                page.vStr1 = (ddlMonth.SelectedIndex == 0 ? "" : "لشهر  " + ddlMonth.SelectedItem.Text.Split('/')[1] + "/" + ddlMonth.SelectedItem.Text.Split('/')[0]);
                page.vStr2 = ddlSection.SelectedItem.Text;
                pw.PageEvent = page;

                BaseFont nationalBase;
                string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 9f, iTextSharp.text.Font.NORMAL);
                document.Open();

                PdfPTable table = new PdfPTable(14);
                table.SetWidths(cols);
                PdfPCell cell = new PdfPCell();
                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;


                cell.Phrase = new iTextSharp.text.Phrase("الرقم", nationalTextFont);
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("الاسم", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("بدون عذر", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("مرضي", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("أضطراري", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("أجازة براتب", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("أجازة بدون راتب", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("أجازة أخرى", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("أضافي الجمع", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("اضافي ساعات", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("أعياد", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("تأخيرات دقائق", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("جزاءات أيام", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("ملاحظات", nationalTextFont);
                table.AddCell(cell);

                cell = new PdfPCell();
                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                double abs0 = 0, abs1 = 0, abs2 = 0, abs3 = 0, abs4 = 0, abs5 = 0, over0 = 0, over1 = 0, over2 = 0, over3 = 0, pen0 = 0;
                foreach (SalOP itm in MyOver)
                {
                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Phrase = new iTextSharp.text.Phrase(itm.EmpCode.ToString(), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.Name, nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.Abs0.ToString(), nationalTextFont);
                    table.AddCell(cell);
                    abs0 += (double)itm.Abs0;

                    cell.Phrase = new iTextSharp.text.Phrase(itm.Abs1.ToString(), nationalTextFont);
                    table.AddCell(cell);
                    abs1 += (double)itm.Abs1;

                    cell.Phrase = new iTextSharp.text.Phrase(itm.Abs2.ToString(), nationalTextFont);
                    table.AddCell(cell);
                    abs2 += (double)itm.Abs2;

                    cell.Phrase = new iTextSharp.text.Phrase(itm.Abs3.ToString(), nationalTextFont);
                    table.AddCell(cell);
                    abs3 += (double)itm.Abs3;

                    cell.Phrase = new iTextSharp.text.Phrase(itm.Abs4.ToString(), nationalTextFont);
                    table.AddCell(cell);
                    abs4 += (double)itm.Abs4;

                    cell.Phrase = new iTextSharp.text.Phrase(itm.Abs5.ToString(), nationalTextFont);
                    table.AddCell(cell);
                    abs5 += (double)itm.Abs5;

                    cell.Phrase = new iTextSharp.text.Phrase(itm.Over0.ToString(), nationalTextFont);
                    table.AddCell(cell);
                    over0 += (double)itm.Over0;

                    cell.Phrase = new iTextSharp.text.Phrase(itm.Over1.ToString(), nationalTextFont);
                    table.AddCell(cell);
                    over1 += (double)itm.Over1;

                    cell.Phrase = new iTextSharp.text.Phrase(itm.Over2.ToString(), nationalTextFont);
                    table.AddCell(cell);
                    over2 += (double)itm.Over2;

                    cell.Phrase = new iTextSharp.text.Phrase(itm.Over3.ToString(), nationalTextFont);
                    table.AddCell(cell);
                    over3 += (double)itm.Over3;

                    cell.Phrase = new iTextSharp.text.Phrase(itm.Pen0.ToString(), nationalTextFont);
                    table.AddCell(cell);
                    pen0 += (double)itm.Pen0;

                    cell.Phrase = new iTextSharp.text.Phrase(itm.Remark, nationalTextFont);
                    table.AddCell(cell);
                }
                cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("الاجمالي", nationalTextFont);
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(abs0.ToString(), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(abs1.ToString(), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(abs2.ToString(), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(abs3.ToString(), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(abs4.ToString(), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(abs5.ToString(), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(over0.ToString(), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(over1.ToString(), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(over2.ToString(), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(over3.ToString(), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(pen0.ToString(), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
                document.Add(table);

                document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));

                if (MyOver2.Count > 0)
                {
                    cols = new[] { 200, 75, 75, 75, 75, 75, 75, 75, 75, 200, 50 };
                    table = new PdfPTable(11);
                    table.SetWidths(cols);
                    cell = new PdfPCell();
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    cell.Phrase = new iTextSharp.text.Phrase("الرقم", nationalTextFont);
                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الاسم", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("عدد الأيام", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الأضافي", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("أجمالي الراتب", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الحسميات", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الذمم", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("قسط السلفة", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("نسبة الحسميات", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("صافي الراتب", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("ملاحظات", nationalTextFont);
                    table.AddCell(cell);

                    cell = new PdfPCell();
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    foreach (SalOP itm in MyOver2)
                    {
                        cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        cell.Phrase = new iTextSharp.text.Phrase(itm.EmpCode.ToString(), nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(itm.Name, nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(itm.Abs0.ToString(), nationalTextFont);
                        table.AddCell(cell);
                        abs0 += (double)itm.Abs0;

                        cell.Phrase = new iTextSharp.text.Phrase(itm.Abs2.ToString(), nationalTextFont);
                        table.AddCell(cell);
                        abs1 += (double)itm.Abs1;

                        cell.Phrase = new iTextSharp.text.Phrase(itm.Net0.ToString(), nationalTextFont);
                        table.AddCell(cell);
                        abs2 += (double)itm.Abs2;

                        cell.Phrase = new iTextSharp.text.Phrase(itm.Abs3.ToString(), nationalTextFont);
                        table.AddCell(cell);
                        abs3 += (double)itm.Abs3;

                        cell.Phrase = new iTextSharp.text.Phrase(itm.Over0.ToString(), nationalTextFont);
                        table.AddCell(cell);
                        abs4 += (double)itm.Abs4;

                        cell.Phrase = new iTextSharp.text.Phrase(itm.Ded03.ToString(), nationalTextFont);
                        table.AddCell(cell);
                        over0 += (double)itm.Over0;

                        cell.Phrase = new iTextSharp.text.Phrase(itm.Per0.ToString(), nationalTextFont);
                        table.AddCell(cell);
                        over1 += (double)itm.Over1;

                        cell.Phrase = new iTextSharp.text.Phrase(itm.Net00.ToString(), nationalTextFont);
                        table.AddCell(cell);
                        over2 += (double)itm.Over2;

                        cell.Phrase = new iTextSharp.text.Phrase(itm.Remark, nationalTextFont);
                        table.AddCell(cell);
                    }
                    document.Add(table);
                    document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                }


                cols = new[] { 200, 200, 150, 200, 150, 200, 200 };
                table = new PdfPTable(7);
                table.TotalWidth = document.PageSize.Width; //100f;
                table.SetWidths(cols);
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell.Border = 0;
                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("مدير القسـم", nationalTextFont);
                table.AddCell(cell);


                cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("الحسابات", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("الشئون الادارية", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                table.AddCell(cell);

                //---------------------------------------------------------------------------                
                cell.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                //----------------------------------------------------------------------------
                table.AddCell(cell);

                cell.Border = 2;
                table.AddCell(cell);

                cell.Border = 0;
                table.AddCell(cell);

                cell.Border = 2;
                table.AddCell(cell);

                cell.Border = 0;
                table.AddCell(cell);

                cell.Border = 2;
                table.AddCell(cell);

                cell.Border = 0;
                table.AddCell(cell);
                //----------------------------------------------------------------------------
                cell.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                //----------------------------------------------------------------------------
                document.Add(table);
                document.Close();
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


        // *************************************************** ITextSharp ****************************************************************
        public class pdfPage : iTextSharp.text.pdf.PdfPageEventHelper
        {
            public string UserName, PageNo, vCompanyName, vStr1,vStr2;

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
                cell2.Phrase = new iTextSharp.text.Phrase(vCompanyName + "\n" + vStr2, nationalTextFont);
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                headerTbl.AddCell(cell2);

                //cell2.PaddingRight = 0;
                cell2.Phrase = new iTextSharp.text.Phrase("كشف مؤثرات الرواتب  " + vStr1, nationalTextFont);
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
                nationalTextFont = new iTextSharp.text.Font(nationalBase, 10f, iTextSharp.text.Font.NORMAL);

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

                cell.Phrase = new iTextSharp.text.Phrase("صفحة رقم " + writer.PageNumber.ToString(), footer);
                footerTbl.AddCell(cell);

                //write the rows out to the PDF output stream.
                footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin - 10), writer.DirectContent);
            }
        }

        protected void BtnAgree1_Click(object sender, ImageClickEventArgs e)
        {
            SetAgree(1);
            PostSal();
        }

        public void SetAgree(short Step)
        {
            try
            {
                string Remark = "", User = "", UserDate = "";
                if (Step == 1)
                {
                    txtAgreeUser1.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser1.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate1.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Remark = txtAgreeRemark1.Text;
                    User = txtAgreeUser1.ToolTip;
                    UserDate = txtAgreeUserDate1.Text;

                    txtAgreeRemark1.ReadOnly = true;
                    BtnAgree1.Enabled = false;
                    BtnDisagree1.Enabled = false;
                }
                else if (Step == 2)
                {
                    txtAgreeUser2.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser2.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate2.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Remark = txtAgreeRemark2.Text;
                    User = txtAgreeUser2.ToolTip;
                    UserDate = txtAgreeUserDate2.Text;

                    txtAgreeRemark2.ReadOnly = true;
                    BtnAgree2.Enabled = false;
                    BtnDisagree2.Enabled = false;
                }
                else if (Step == 3)
                {
                    txtAgreeUser3.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser3.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate3.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Remark = txtAgreeRemark3.Text;
                    User = txtAgreeUser3.ToolTip;
                    UserDate = txtAgreeUserDate3.Text;

                    txtAgreeRemark3.ReadOnly = true;
                    BtnAgree3.Enabled = false;
                    BtnDisagree3.Enabled = false;
                }
                else if (Step == 4)
                {
                    txtAgreeUser4.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser4.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate4.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Remark = txtAgreeRemark4.Text;
                    User = txtAgreeUser4.ToolTip;
                    UserDate = txtAgreeUserDate4.Text;

                    txtAgreeRemark4.ReadOnly = true;
                    BtnAgree4.Enabled = false;
                    BtnDisagree4.Enabled = false;
                }
                else if (Step == 5)
                {
                    txtAgreeUser5.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser5.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate5.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Remark = txtAgreeRemark5.Text;
                    User = txtAgreeUser5.ToolTip;
                    UserDate = txtAgreeUserDate5.Text;

                    txtAgreeRemark5.ReadOnly = true;
                    BtnAgree5.Enabled = false;
                    BtnDisagree5.Enabled = false;
                }
                else if (Step == 6)
                {
                    txtAgreeUser6.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser6.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate6.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Remark = txtAgreeRemark6.Text;
                    User = txtAgreeUser6.ToolTip;
                    UserDate = txtAgreeUserDate6.Text;

                    txtAgreeRemark6.ReadOnly = true;
                    BtnAgree6.Enabled = false;
                    BtnDisagree6.Enabled = false;
                }
                else if (Step == 7)
                {
                    txtAgreeUser7.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser7.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate7.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Remark = txtAgreeRemark7.Text;
                    User = txtAgreeUser7.ToolTip;
                    UserDate = txtAgreeUserDate7.Text;

                    txtAgreeRemark7.ReadOnly = true;
                    BtnAgree7.Enabled = false;
                    BtnDisagree7.Enabled = false;
                }

                bool vFound = false;
                Agreement myAgree = new Agreement();
                myAgree.FType = 400;
                myAgree.LocType = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                myAgree.LocNumber = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                myAgree.Number = int.Parse(ddlSection.SelectedValue);
                myAgree.FNo = Step;
                myAgree = myAgree.FindFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                vFound = (myAgree != null);                

                myAgree = new Agreement();
                myAgree.FType = 400;
                myAgree.LocType = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                myAgree.LocNumber = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                myAgree.Number = int.Parse(ddlSection.SelectedValue);
                myAgree.FNo = Step;
                myAgree.Agree = 1;
                myAgree.AgreeRemark = Remark;
                myAgree.AgreeUser = User;
                myAgree.AgreeUserDate = UserDate;

                if (vFound)
                {
                    if (!myAgree.Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "خطأ أثناء تعميد المستند ... حاول مرة أخرى";
                        return;
                    }
                }
                else
                {
                    if (!myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "خطأ أثناء تعميد المستند ... حاول مرة أخرى";
                        return;
                    }
                }

                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                LblCodesResult.Text = "تم اعتماد المستند بنجاح";

                doAgree mydoAgree = new doAgree();
                mydoAgree.FType = 400;
                mydoAgree.LocType = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                mydoAgree.LocNumber = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                mydoAgree.Number = int.Parse(ddlSection.SelectedValue);
                mydoAgree.FNo = Step;
                mydoAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                mydoAgree = new doAgree();
                mydoAgree.FType = 400;
                mydoAgree.LocType = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                mydoAgree.LocNumber = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                mydoAgree.Number = int.Parse(ddlSection.SelectedValue);
                Step++;
                mydoAgree.FNo = Step;

                if (Step == 2)
                {
                    mydoAgree.UserName = "wejdan";
                    mydoAgree.UserName2 = "";
                    mydoAgree.UserGroup = "";
                }
                else if (Step == 3)
                {
                    mydoAgree.UserName = "m.yousef";
                    mydoAgree.UserName2 = "";
                    mydoAgree.UserGroup = "";
                }
                else if (Step == 4)
                {
                    mydoAgree.UserName = "sameh";  // sameh
                    mydoAgree.UserName2 = "";  // "khobrany";
                    mydoAgree.UserGroup = "";
                }
                else if (Step == 5)
                {
                    mydoAgree.UserName = "sameh";  // sameh
                    mydoAgree.UserName2 = "";  // "khobrany";
                    mydoAgree.UserGroup = "";
                }
                else if (Step == 6)
                {
                    mydoAgree.UserName = "m.yousef";
                    mydoAgree.UserName2 = "wejdan";
                    mydoAgree.UserGroup = "شئون موظفين";
                }
                else if (Step == 7)
                {
                    mydoAgree.UserName = "Admin";
                    mydoAgree.UserName2 = "";
                    mydoAgree.UserGroup = "";
                }
                if(Step < 8) mydoAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);



                Transactions UserTran = new Transactions();
                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                UserTran.UserName = Session["CurrentUser"].ToString();
                UserTran.Description = "أعتماد كشف مؤثرات الرواتب عن شهر   " + ddlMonth.SelectedItem.Text + " عن قسم " + ddlSection.SelectedItem.Text;
                UserTran.FormAction = "أعتماد";
                UserTran.FormName = "كشف مؤثرات الرواتب";
                UserTran.IP = IPNetworking.GetIP4Address();
                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, true), true);
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void BtnAgree2_Click(object sender, ImageClickEventArgs e)
        {
            SetAgree(2);
        }

        protected void BtnAgree5_Click(object sender, ImageClickEventArgs e)
        {
            SetAgree(5);
            PostSal2();
        }

        protected void BtnAgree4_Click(object sender, ImageClickEventArgs e)
        {
            SetAgree(4);
            //PostSal2();
        }

        protected void BtnAgree3_Click(object sender, ImageClickEventArgs e)
        {
            SetAgree(3);
        }


        public void SetDisAgree(short Step)
        {
            try
            {
                string Remark = "", User = "", UserDate = "";
                if (Step == 1)
                {
                    txtAgreeUser1.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser1.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate1.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Remark = txtAgreeRemark1.Text;
                    User = txtAgreeUser1.ToolTip;
                    UserDate = txtAgreeUserDate1.Text;

                    txtAgreeRemark1.ReadOnly = true;
                    BtnAgree1.Enabled = false;
                    BtnDisagree1.Enabled = false;
                }
                else if (Step == 2)
                {
                    txtAgreeUser2.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser2.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate2.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Remark = txtAgreeRemark2.Text;
                    User = txtAgreeUser2.ToolTip;
                    UserDate = txtAgreeUserDate2.Text;

                    txtAgreeRemark2.ReadOnly = true;
                    BtnAgree2.Enabled = false;
                    BtnDisagree2.Enabled = false;
                }
                else if (Step == 3)
                {
                    txtAgreeUser3.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser3.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate3.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Remark = txtAgreeRemark3.Text;
                    User = txtAgreeUser3.ToolTip;
                    UserDate = txtAgreeUserDate3.Text;

                    txtAgreeRemark3.ReadOnly = true;
                    BtnAgree3.Enabled = false;
                    BtnDisagree3.Enabled = false;
                }
                else if (Step == 4)
                {
                    txtAgreeUser4.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser4.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate4.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Remark = txtAgreeRemark4.Text;
                    User = txtAgreeUser4.ToolTip;
                    UserDate = txtAgreeUserDate4.Text;

                    txtAgreeRemark4.ReadOnly = true;
                    BtnAgree4.Enabled = false;
                    BtnDisagree4.Enabled = false;
                }
                else if (Step == 5)
                {
                    txtAgreeUser5.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser5.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate5.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Remark = txtAgreeRemark5.Text;
                    User = txtAgreeUser5.ToolTip;
                    UserDate = txtAgreeUserDate5.Text;

                    txtAgreeRemark5.ReadOnly = true;
                    BtnAgree5.Enabled = false;
                    BtnDisagree5.Enabled = false;
                }
                else if (Step == 6)
                {
                    txtAgreeUser6.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser6.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate6.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Remark = txtAgreeRemark6.Text;
                    User = txtAgreeUser6.ToolTip;
                    UserDate = txtAgreeUserDate6.Text;

                    txtAgreeRemark6.ReadOnly = true;
                    BtnAgree6.Enabled = false;
                    BtnDisagree6.Enabled = false;
                }
                else if (Step == 7)
                {
                    txtAgreeUser7.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser7.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate7.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Remark = txtAgreeRemark7.Text;
                    User = txtAgreeUser7.ToolTip;
                    UserDate = txtAgreeUserDate7.Text;

                    txtAgreeRemark7.ReadOnly = true;
                    BtnAgree7.Enabled = false;
                    BtnDisagree7.Enabled = false;
                }
            
                Agreement myAgree = new Agreement();
                myAgree.FType = 400;
                myAgree.LocType = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                myAgree.LocNumber = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                myAgree.Number = int.Parse(ddlSection.SelectedValue);
                myAgree.FNo = Step;

                bool vFound = false;
                myAgree = myAgree.FindFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                vFound = (myAgree != null);

                myAgree = new Agreement();
                myAgree.FType = 400;
                myAgree.LocType = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                myAgree.LocNumber = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                myAgree.Number = int.Parse(ddlSection.SelectedValue);
                myAgree.FNo = Step;
                myAgree.Agree = 2;
                myAgree.AgreeRemark = Remark;
                myAgree.AgreeUser = User;
                myAgree.AgreeUserDate = UserDate;

                if(vFound)
                {
                    if(!myAgree.Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "خطأ أثناء تعميد المستند ... حاول مرة أخرى";
                        return;                    
                    }
                }
                else
                {
                    if(!myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "خطأ أثناء تعميد المستند ... حاول مرة أخرى";
                        return;                    
                    }                
                }

                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                LblCodesResult.Text = "تم رفض اعتماد المستند";

                doAgree mydoAgree = new doAgree();
                mydoAgree.FType = 400;
                mydoAgree.LocType = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                mydoAgree.LocNumber = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                mydoAgree.Number = int.Parse(ddlSection.SelectedValue);
                mydoAgree.FNo = Step;
                mydoAgree.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                DepManager vDep = new DepManager();
                vDep.Dep = int.Parse(ddlSection.SelectedValue);
                vDep = vDep.GetDepManager(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                mydoAgree = new doAgree();
                mydoAgree.FType = 400;
                mydoAgree.LocType = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                mydoAgree.LocNumber = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                mydoAgree.Number = int.Parse(ddlSection.SelectedValue);
                Step--;
                mydoAgree.FNo = Step;

                if (Step == 0)
                {
                    mydoAgree.UserName = txtUserName.ToolTip;
                    mydoAgree.UserName2 = "";
                    mydoAgree.UserGroup = "";
                }
                else if (Step == 1)
                {
                    mydoAgree.UserName = txtAgreeUser1.ToolTip;
                    mydoAgree.UserName2 = "";
                    mydoAgree.UserGroup = "";
                }
                else if (Step == 2)
                {
                    mydoAgree.UserName = txtAgreeUser2.ToolTip;
                    mydoAgree.UserName2 = "";
                    mydoAgree.UserGroup = "";
                }
                else if (Step == 3)
                {
                    mydoAgree.UserName = txtAgreeUser3.ToolTip;
                    mydoAgree.UserName2 = "";
                    mydoAgree.UserGroup = "";
                }
                else if (Step == 4)
                {
                    mydoAgree.UserName = txtAgreeUser4.ToolTip;
                    mydoAgree.UserName2 = "";
                    mydoAgree.UserGroup = "";
                }
                else if (Step == 5)
                {
                    mydoAgree.UserName = txtAgreeUser5.ToolTip;
                    mydoAgree.UserName2 = "";
                    mydoAgree.UserGroup = "";
                }
                else if (Step == 6)
                {
                    mydoAgree.UserName = txtAgreeUser6.ToolTip;
                    mydoAgree.UserName2 = "";
                    mydoAgree.UserGroup = "";
                }

                mydoAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                Transactions UserTran = new Transactions();
                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                UserTran.UserName = Session["CurrentUser"].ToString();
                UserTran.Description = "أعتماد كشف مؤثرات الرواتب عن شهر   " + ddlMonth.SelectedItem.Text + " عن قسم " + ddlSection.SelectedItem.Text;
                UserTran.FormAction = "رفض";
                UserTran.FormName = "كشف مؤثرات الرواتب";
                UserTran.IP = IPNetworking.GetIP4Address();
                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, true), true);
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void BtnDisagree1_Click(object sender, ImageClickEventArgs e)
        {
            SetDisAgree(1);
            UnPostSal();
        }

        protected void BtnDisagree2_Click(object sender, ImageClickEventArgs e)
        {
            SetDisAgree(2);
        }

        protected void BtnDisagree3_Click(object sender, ImageClickEventArgs e)
        {
            SetDisAgree(3);
        }

        protected void BtnDisagree4_Click(object sender, ImageClickEventArgs e)
        {
            SetDisAgree(4);
        }

        protected void BtnDisagree5_Click(object sender, ImageClickEventArgs e)
        {
            SetDisAgree(5);
            UnPostSal2();
        }

        protected void BtnAgree6_Click(object sender, ImageClickEventArgs e)
        {
            SetAgree(6);
        }

        protected void BtnAgree7_Click(object sender, ImageClickEventArgs e)
        {
            SetAgree(7);
        }

        protected void BtnDisagree6_Click(object sender, ImageClickEventArgs e)
        {
            SetDisAgree(6);
        }

        protected void BtnDisagree7_Click(object sender, ImageClickEventArgs e)
        {
            SetDisAgree(7);
        }


        protected void BtnAttach_Click(object sender, ImageClickEventArgs e)
        {
            if (FileUpload1.HasFile)
                try
                {
                    MyConfig mySetting = new MyConfig();
                    mySetting.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    mySetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                    if (mySetting != null)
                    {
                        string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
                        String FileName = Config.GetImageName(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + fileExt;
                        FileUpload1.SaveAs(mySetting.ImagePath + FileName);

                        Arch myArch = new Arch();
                        myArch.Branch = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                        myArch.LocNumber = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                        myArch.Number = int.Parse(ddlSection.SelectedValue);
                        myArch.DocType = 400;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                        myArch.LocNumber = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                        myArch.Number = int.Parse(ddlSection.SelectedValue);
                        myArch.DocType = 400;
                        myArch.FileName = FileUpload1.FileName;
                        myArch.FileName2 = mySetting.ImagePath2 + FileName;
                        myArch.FNo = (short)i;
                        myArch.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "مؤثرات رواتب", "اضافة مرفقات", "اضافة مرفقات لقسم " + ddlSection.SelectedItem.Text + " لشهر " + ddlMonth.SelectedItem.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        LoadAttachData();
                    }

                    //    LblCodesResult.Text = "File name: " + FileUpload1.PostedFile.FileName + "<br>" + FileUpload1.PostedFile.ContentLength + " kb<br>" + "Content type: " + FileUpload1.PostedFile.ContentType;
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
                        LblCodesResult.Text = "ERROR: " + ex.Message.ToString();
                    }
                }
            else
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "لم بتم اختيار الملف";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);

            }
        }



        protected void grdAttach_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string FNo = grdAttach.DataKeys[e.RowIndex]["FNo"].ToString();
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                myArch.LocNumber = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                myArch.Number = int.Parse(ddlSection.SelectedValue);
                myArch.DocType = 400;
                myArch.FNo = short.Parse(FNo);
                myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "مؤثرات رواتب", "الغاء مرفقات", "الغاء مرفقات لقسم " + ddlSection.SelectedItem.Text + " لشهر " + ddlMonth.SelectedItem.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                LoadAttachData();
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

        public void LoadAttachData()
        {
            if (ddlMonth.SelectedIndex>0 && ddlSection.SelectedIndex>0)
            {
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                myArch.LocNumber = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                myArch.Number = int.Parse(ddlSection.SelectedValue);
                myArch.DocType = 400;
                grdAttach.DataSource = myArch.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                grdAttach.DataBind();
                if (((List<Arch>)grdAttach.DataSource).Count > 0)
                {
                    cpeDemo.Collapsed = false;
                    cpeDemo.ClientState = "false";
                }
                else
                {
                    cpeDemo.Collapsed = true;
                    cpeDemo.ClientState = "true";
                }
            }
        }

        public string UrlHelper(object EmpCode)
        {
            return "~/WebStatement.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&Code=12050" + EmpCode.ToString();
        }


        public void PostSal()
        {
            foreach (SalOP itm in MyOver)
            {
                Salaries mySal = new Salaries();
                mySal.Year1 = itm.Year1;
                mySal.Month1 = itm.Month1;
                mySal.EmpCode = itm.EmpCode;
                mySal = mySal.GetEmp(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (mySal != null)
                {
                    double vBasic = 0 , vSal = 0 , vDed = 0;
                    SEmp myEmp = new SEmp();
                    myEmp.EmpCode = itm.EmpCode;
                    myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myEmp != null)
                    {
                        vBasic = (double)myEmp.Basic;
                        vSal = (double)(myEmp.Basic + myEmp.Add01 + myEmp.Add02 + myEmp.Add03 + myEmp.Add05 + myEmp.Add13 + myEmp.Add14);
                        vDed = (double)(myEmp.Add01 + myEmp.Add03 + myEmp.Add05 + myEmp.Add13 + myEmp.Add14);
                    }
                    //if (mySal.NoDays > 0) mySal.Ded13 = (vSal / 30) * itm.Abs4;
                    if (mySal.NoDays > 0 && itm.Abs4 > 0)
                    {
                        mySal.NoDays = (short)((int)mySal.NoDays - itm.Abs4);
                        mySal.Basic = Math.Round((double)myEmp.Basic * (int)mySal.NoDays / 30, 2);
                        mySal.Add01 = Math.Round((double)myEmp.Add01 * (int)mySal.NoDays / 30, 2);
                        mySal.Add02 = Math.Round((double)myEmp.Add02 * (int)mySal.NoDays / 30, 2);
                        mySal.Add03 = Math.Round((double)myEmp.Add03 * (int)mySal.NoDays / 30, 2);
                        mySal.Add05 = Math.Round((double)myEmp.Add05 * (int)mySal.NoDays / 30, 2);
                        mySal.Add13 = Math.Round((double)myEmp.Add13 * (int)mySal.NoDays / 30, 2);
                        mySal.Add14 = Math.Round((double)myEmp.Add14 * (int)mySal.NoDays / 30, 2);
                    }

                    if(mySal.NoDays>0) mySal.Ded02 = (vSal / 30) * itm.Abs0;
                    mySal.Ded021 = itm.Abs0;

                    if (mySal.NoDays > 0) mySal.Ded14 = (vDed / 30) * itm.Abs3;
                    mySal.Ded014 = itm.Abs3;


                    if (mySal.NoDays > 0) mySal.Add04 = 1.5 * (vBasic / 240) * (((itm.Over0 + itm.Over2) * 8) + itm.Over1);
                    mySal.Add041 = itm.Over0 + itm.Over2;
                    mySal.Add042 = itm.Over1;

                    if (mySal.NoDays > 0) mySal.Ded12 = (itm.Over3 / 60) * (vBasic / 240);

                    if (mySal.NoDays > 0)  mySal.Ded04 = (vBasic / 30) * itm.Pen0;

                    //mySal.Ded03 = itm.Ded03;
                    mySal.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }
            }
        }


        public void PostSal2()
        {
            foreach (SalOP itm in MyOver)
            {
                Salaries mySal = new Salaries();
                mySal.Year1 = itm.Year1;
                mySal.Month1 = itm.Month1;
                mySal.EmpCode = itm.EmpCode;
                mySal = mySal.GetEmp(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (mySal != null)
                {
                    mySal.Ded03 = itm.Ded03;
                    mySal.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }
            }
        }


        public void UnPostSal()
        {
            foreach (SalOP itm in MyOver)
            {
                Salaries mySal = new Salaries();
                mySal.Year1 = itm.Year1;
                mySal.Month1 = itm.Month1;
                mySal.EmpCode = itm.EmpCode;
                mySal = mySal.GetEmp(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (mySal != null)
                {
                    double vBasic = 0, vSal = 0, vDed = 0;
                    SEmp myEmp = new SEmp();
                    myEmp.EmpCode = itm.EmpCode;
                    myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myEmp != null)
                    {
                        vBasic = (double)myEmp.Basic;
                        vSal = (double)(myEmp.Basic + myEmp.Add01 + myEmp.Add02 + myEmp.Add03 + myEmp.Add05 + myEmp.Add13 + myEmp.Add14);
                        vDed = (double)(myEmp.Add01 + myEmp.Add03 + myEmp.Add05 + myEmp.Add13 + myEmp.Add14);
                    }

                    // check if come from 3
                    Agreement myAgree = new Agreement();
                    myAgree.FType = 400;
                    myAgree.LocType = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[0]);
                    myAgree.LocNumber = short.Parse(ddlMonth.SelectedItem.Text.Split('/')[1]);
                    myAgree.Number = int.Parse(ddlSection.SelectedValue);
                    myAgree.FNo = 2;
                    myAgree = myAgree.FindFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myAgree != null)
                    {
                        if (mySal.NoDays > 0 && itm.Abs4 > 0)
                        {
                            mySal.NoDays = (short)((int)mySal.NoDays + itm.Abs4);
                            mySal.Basic = Math.Round((double)myEmp.Basic * (int)mySal.NoDays / 30, 2);
                            mySal.Add01 = Math.Round((double)myEmp.Add01 * (int)mySal.NoDays / 30, 2);
                            mySal.Add02 = Math.Round((double)myEmp.Add02 * (int)mySal.NoDays / 30, 2);
                            mySal.Add03 = Math.Round((double)myEmp.Add03 * (int)mySal.NoDays / 30, 2);
                            mySal.Add05 = Math.Round((double)myEmp.Add05 * (int)mySal.NoDays / 30, 2);
                            mySal.Add13 = Math.Round((double)myEmp.Add13 * (int)mySal.NoDays / 30, 2);
                            mySal.Add14 = Math.Round((double)myEmp.Add14 * (int)mySal.NoDays / 30, 2);
                        }
                    }

                    mySal.Ded02 = 0;
                    mySal.Ded021 = 0;

                    mySal.Ded14 = 0;
                    mySal.Ded014 = 0;


                    mySal.Add04 = 0;
                    mySal.Add041 = 0;
                    mySal.Add042 = 0;

                    mySal.Ded12 = 0;

                    mySal.Ded04 = 0;
                    mySal.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }
            }
        }


        public void UnPostSal2()
        {
            foreach (SalOP itm in MyOver)
            {
                if (itm.Ded03 > 0)
                {
                    Salaries mySal = new Salaries();
                    mySal.Year1 = itm.Year1;
                    mySal.Month1 = itm.Month1;
                    mySal.EmpCode = itm.EmpCode;
                    mySal = mySal.GetEmp(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (mySal != null)
                    {


                        mySal.Ded03 = 0;
                        mySal.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                }
            }
        }


        protected void txtDed03_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtDed03 = sender as TextBox;
                if (txtDed03.Text != "")
                {
                    GridViewRow gvr = txtDed03.NamingContainer as GridViewRow;
                    MyOver2[gvr.RowIndex].Ded03 = double.Parse(txtDed03.Text);
                    MyOver[gvr.RowIndex].Ded03 = double.Parse(txtDed03.Text);
                    MyOver[gvr.RowIndex].update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    grdCodes.DataSource = MyOver2;
                    grdCodes.DataBind();                    
                }
            }
            catch (Exception)
            {
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            PostSal();
        }

    }
}


