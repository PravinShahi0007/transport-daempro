using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.IO;

namespace ACC
{
    public partial class WebMPro : System.Web.UI.Page
    {
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

        public List<TransSal> VouData
        {
            get
            {
                if (ViewState["VouData"] == null)
                {
                    ViewState["VouData"] = new List<TransSal>();
                }
                return (List<TransSal>)ViewState["VouData"];
            }
            set
            {
                ViewState["VouData"] = value;

            }
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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttach);
                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "التشغيل الشهري للرواتب";
                    //BtnProcess.Visible = (bool)((TblRoles)(Session["Roll"])).Pass241;
                    //BtnDelete.Visible = (bool)((TblRoles)(Session["Roll"])).Pass242;
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

                    for (int i = 2015; i < DateTime.Now.Year + 5; i++)
                    {
                        ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    }
                    ddlMonth.Items.Add(new ListItem("يناير", "1"));
                    ddlMonth.Items.Add(new ListItem("فبراير", "2"));
                    ddlMonth.Items.Add(new ListItem("مارس", "3"));
                    ddlMonth.Items.Add(new ListItem("أبريل", "4"));
                    ddlMonth.Items.Add(new ListItem("مايو", "5"));
                    ddlMonth.Items.Add(new ListItem("يونيه", "6"));
                    ddlMonth.Items.Add(new ListItem("يولية", "7"));
                    ddlMonth.Items.Add(new ListItem("أغسطس", "8"));
                    ddlMonth.Items.Add(new ListItem("سبتمبر", "9"));
                    ddlMonth.Items.Add(new ListItem("أكتوبر", "10"));
                    ddlMonth.Items.Add(new ListItem("نوفمبر", "11"));
                    ddlMonth.Items.Add(new ListItem("ديسمبر", "12"));
                    ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
                    ddlYear.SelectedValue = DateTime.Now.Year.ToString();

                    txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtUserName.Text = Session["FullUser"].ToString();
                    txtUserDate.Text = DateTime.Now.ToShortDateString();

                    ddlEmpCode.DataTextField = "EmpCode";
                    ddlEmpCode.DataValueField = "EmpCode";

                    SEmp myemp = new SEmp();
                    if (Cache["Emps" + Session["CNN2"].ToString()] == null) Cache.Insert("Emps" + Session["CNN2"].ToString(), myemp.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlEmpCode.DataSource = (List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()]);
                    ddlEmpCode.DataBind();

                    ddlEmpCode.Items.Insert(0, new ListItem("أختر كود الموظف", "-1", true));
                    BtnPostJv.Visible = ((List<TblRoles>)(Session["Roll"]))[0].RoleName.Contains("مدير الحسابات") || ((List<TblRoles>)(Session["Roll"]))[0].RoleName.ToLower().Contains("admin");
                    ddlYear_SelectedIndexChanged(sender, e);

                }
                else
                {
                    LblCodesResult.Text = "";
                }

            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void ChkEmpCode_CheckedChanged(object sender, EventArgs e)
        {
            ddlEmpCode.Visible = ChkEmpCode.Checked;
            if (!ddlEmpCode.Visible) ddlEmpCode.SelectedIndex = 0;
        }


        protected void BtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Salaries mySal = new Salaries();
                mySal.Year1 = short.Parse(ddlYear.SelectedValue);
                mySal.Month1 = short.Parse(ddlMonth.SelectedValue);
                if (!mySal.CheckMonth(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "لم يتم تشغيل الشهر من قبل";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(0,'" + LblCodesResult.Text + "');", true);
                    return;
                }

                if (ChkEmpCode.Checked && ddlEmpCode.SelectedIndex == 0)
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب أختيار الموظف";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(0,'" + LblCodesResult.Text + "');", true);
                    return;
                }

                if (ChkEmpCode.Checked)
                {
                    mySal.EmpCode = int.Parse(ddlEmpCode.SelectedValue);
                    if (mySal.DeleteSalary(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تم الغاء تشغيل البيانات للموظف بنجاح";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(1,'" + LblCodesResult.Text + "');", true);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يوجد خطأ اثناء تشغيل البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(0,'" + LblCodesResult.Text + "');", true);
                        return;
                    }
                }
                else
                {
                    if (mySal.DeleteMonthSalary(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تم الغاء تشغيل البيانات بنجاح";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(1,'" + LblCodesResult.Text + "');", true);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يوجد خطأ اثناء تشغيل البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(0,'" + LblCodesResult.Text + "');", true);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void BtnProcess_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Salaries mySal =new Salaries();
                mySal.Year1 = short.Parse(ddlYear.SelectedValue);
                mySal.Month1 = short.Parse(ddlMonth.SelectedValue);
                if (mySal.CheckMonth(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    if (ChkEmpCode.Checked)
                    {
                        mySal.EmpCode = int.Parse(ddlEmpCode.SelectedItem.Text);
                        mySal = (from itm in mySal.GetAllSalary(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                 where itm.EmpCode == int.Parse(ddlEmpCode.SelectedItem.Text)
                                 select itm).FirstOrDefault();
                        if(mySal != null)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تم تشغيل الموظف لهذا الشهر من قبل";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(0,'" + LblCodesResult.Text + "');", true);
                            return;                        
                        }
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد تم تشغيل الشهر من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(0,'" + LblCodesResult.Text + "');", true);
                        return;
                    }
                }

                if (ChkEmpCode.Checked && ddlEmpCode.SelectedIndex == 0)
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب أختيار الموظف";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(0,'" + LblCodesResult.Text + "');", true);
                    return;
                }

                SEmp myacc = new SEmp();
                if (Cache["Emps" + Session["CNN2"].ToString()] == null) Cache.Insert("Emps" + Session["CNN2"].ToString(), myacc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                List<SEmp> le = new List<SEmp>();

                if (ChkEmpCode.Checked)
                {
                    myacc.EmpCode = int.Parse(ddlEmpCode.SelectedValue);
                    le.Add((from sitm in (List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()])
                                where sitm.EmpCode == myacc.EmpCode
                                select sitm).FirstOrDefault());
                }
                else
                {
                    le.AddRange((List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()]));
                }

                foreach(SEmp item in le)
                {
                    DateTime vStart = DateTime.Parse("01/" + ddlMonth.SelectedValue + "/" + ddlYear.SelectedValue);
                    DateTime vEnd = DateTime.Parse(DateTime.DaysInMonth(int.Parse(ddlYear.SelectedValue), int.Parse(ddlMonth.SelectedValue)).ToString() + "/" + ddlMonth.SelectedValue + "/" + ddlYear.SelectedValue);
                    bool vtammen = false;
                    if (item.Status == 0 && (!String.IsNullOrEmpty(item.ReturnDate) && DateTime.Parse(item.ReturnDate) <= vEnd))
                    {
                        double NoofDays = 30;
                        double rate = 1;
                        if (item.JoinDate != "")
                        {
                            if (DateTime.Parse(item.JoinDate) > vStart && DateTime.Parse(item.JoinDate) <= vEnd)
                            {
                                TimeSpan ts = new TimeSpan();
                                ts = vEnd - DateTime.Parse(item.JoinDate);
                                NoofDays = ts.Days + 1;
                                if (DateTime.DaysInMonth(vEnd.Year, vEnd.Month) == 31) NoofDays--;
                                if (DateTime.DaysInMonth(vEnd.Year, vEnd.Month) == 29) NoofDays++;
                                if (DateTime.DaysInMonth(vEnd.Year, vEnd.Month) == 28) NoofDays += 2;
                                if (NoofDays > 30) NoofDays = 30;
                                rate = NoofDays / 30;
                                vtammen = true;
                            }
                        }

                        if (item.ReturnDate != "" && item.ReturnDate != item.JoinDate)
                        {
                            if (DateTime.Parse(item.ReturnDate) > vStart && DateTime.Parse(item.ReturnDate) <= vEnd)
                            {
                                TimeSpan ts = new TimeSpan();
                                ts = vEnd - DateTime.Parse(item.ReturnDate);
                                NoofDays = ts.Days + 1;
                                if (DateTime.DaysInMonth(vEnd.Year, vEnd.Month) == 31) NoofDays--;
                                if (DateTime.DaysInMonth(vEnd.Year, vEnd.Month) == 29) NoofDays++;
                                if (DateTime.DaysInMonth(vEnd.Year, vEnd.Month) == 28) NoofDays += 2;
                                if (NoofDays > 30) NoofDays = 30;
                                rate = NoofDays / 30;
                                vtammen = true;
                            }
                        }
                        
                        mySal = new Salaries();
                        mySal.EmpCode = item.EmpCode;
                        mySal.Year1 = short.Parse(ddlYear.SelectedValue);
                        mySal.Month1 = short.Parse(ddlMonth.SelectedValue);
                        
                        // Check Pervious Month Notes

                        Salaries oldSal = new Salaries();
                        oldSal.EmpCode = item.EmpCode;
                        if (ddlMonth.SelectedValue == "1")
                        {
                            oldSal.Year1 = (short)(int.Parse(ddlYear.SelectedValue) - 1);
                            oldSal.Month1 = 12;
                        }
                        else
                        {
                            oldSal.Year1 = short.Parse(ddlYear.SelectedValue);
                            oldSal.Month1 = (short)(int.Parse(ddlMonth.SelectedValue) - 1);
                        }
                        oldSal = oldSal.GetEmp(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (oldSal != null)
                        {
                            mySal.Remark = oldSal.Remark;
                        }
                        else mySal.Remark = "";


                        mySal.Basic = Math.Round((double)item.Basic * rate, 2);
                        mySal.Add01 = Math.Round((double)item.Add01 * rate, 2);
                        mySal.Add02 = Math.Round((double)item.Add02 * rate, 2);
                        mySal.Add03 = Math.Round((double)item.Add03 * rate, 2);
                        mySal.Add04 = (double)item.Add04;
                        mySal.Add05 = Math.Round((double)item.Add05 * rate, 2);
                        mySal.Add06 = (double)item.Add06;
                        if (vtammen)
                        {
                            mySal.Add07 = Math.Round((double)item.Add07, 2);
                            mySal.Add08 = Math.Round((double)item.Add08, 2);
                        }
                        else
                        {
                            mySal.Add07 = Math.Round((double)item.Add07 * rate, 2);
                            mySal.Add08 = Math.Round((double)item.Add08 * rate, 2);
                        }
                        mySal.Add09 = (double)item.Add09;
                        mySal.Add10 = (double)item.Add10;
                        mySal.Add11 = (double)item.Add11;
                        mySal.Add12 = (double)item.Add12;
                        mySal.Add13 = Math.Round((double)item.Add13 * rate, 2);
                        mySal.Add14 = Math.Round((double)item.Add14 * rate, 2);
                        mySal.Add15 = (double)item.Add15;
                        //if (vtammen) mySal.Ded01 = Math.Round((double)item.Ded01, 2);
                        //else mySal.Ded01 = Math.Round((double)item.Ded01 * rate, 2);
                        mySal.Ded01 = Math.Round((double)item.Ded01, 2);
                        mySal.Ded02 = (double)item.Ded02;
                        mySal.Ded03 = (double)item.Ded03;
                        mySal.Ded04 = (double)item.Ded04;
                        mySal.Ded05 = (double)item.Ded05;
                        mySal.Ded06 = (double)item.Ded06;
                        mySal.Ded07 = (double)item.Ded07;
                        mySal.Ded08 = (double)item.Ded08;
                        mySal.Ded09 = (double)item.Ded09;
                        mySal.Ded10 = (double)item.Ded10;
                        mySal.Ded11 = (double)item.Ded11;
                        mySal.Ded12 = (double)item.Ded12;
                        mySal.Ded13 = (double)item.Ded13;
                        mySal.Ded14 = (double)item.Ded14;
                        mySal.Ded15 = (double)item.Ded15;
                        mySal.Section = item.Section;
                        mySal.Username = Session["CurrentUser"].ToString();
                        mySal.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                        mySal.NoDays = (short)NoofDays;

                        if (item.Status == 1 && rate != 1)
                        {
                            mySal.Basic = 0;
                            mySal.Add01 = 0;
                            mySal.Add02 = 0;
                            mySal.Add03 = 0;
                            mySal.Add04 = 0;
                            mySal.Add05 = 0;
                            mySal.Add06 = 0;
                            //mySal.Add07 = 0;
                            //mySal.Add08 = 0;
                            mySal.Add09 = 0;
                            mySal.Add10 = 0;
                            mySal.Add11 = 0;
                            mySal.Add12 = 0;
                            mySal.Add13 = 0;
                            mySal.Add14 = 0;
                            //mySal.Add15 = 0;
                            //mySal.Ded01 = 0;
                            mySal.Ded02 = 0;
                            mySal.Ded03 = 0;
                            mySal.Ded04 = 0;
                            mySal.Ded05 = 0;
                            mySal.Ded06 = 0;
                            mySal.Ded07 = 0;
                            mySal.Ded08 = 0;
                            mySal.Ded09 = 0;
                            mySal.Ded10 = 0;
                            mySal.Ded11 = 0;
                            mySal.Ded12 = 0;
                            mySal.Ded13 = 0;
                            mySal.Ded14 = 0;
                            mySal.Ded15 = 0;
                            mySal.NoDays = 0;
                        }
                        mySal.insertSalary(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    else if (item.Status == 1 || (!String.IsNullOrEmpty(item.ReturnDate) && DateTime.Parse(item.ReturnDate) > vEnd))
                    {
                        double NoofDays = 30;
                        double rate = 1;
                        mySal = new Salaries();
                        mySal.EmpCode = item.EmpCode;
                        mySal.Year1 = short.Parse(ddlYear.SelectedValue);
                        mySal.Month1 = short.Parse(ddlMonth.SelectedValue);

                        Salaries oldSal = new Salaries();
                        oldSal.EmpCode = item.EmpCode;
                        if (ddlMonth.SelectedValue == "1")
                        {
                            oldSal.Year1 = (short)(int.Parse(ddlYear.SelectedValue) - 1);
                            oldSal.Month1 = 12;
                        }
                        else
                        {
                            oldSal.Year1 = short.Parse(ddlYear.SelectedValue);
                            oldSal.Month1 = (short)(int.Parse(ddlMonth.SelectedValue) - 1);
                        }
                        oldSal = oldSal.GetEmp(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (oldSal != null)
                        {
                            mySal.Remark = oldSal.Remark;
                        }
                        else mySal.Remark = "";

                        mySal.Basic = Math.Round((double)item.Basic * rate, 2);
                        mySal.Add01 = Math.Round((double)item.Add01 * rate, 2);
                        mySal.Add02 = Math.Round((double)item.Add02 * rate, 2);
                        mySal.Add03 = Math.Round((double)item.Add03 * rate, 2);
                        mySal.Add04 = (double)item.Add04;
                        mySal.Add05 = Math.Round((double)item.Add05 * rate, 2);
                        mySal.Add06 = (double)item.Add06;
                        mySal.Add07 = Math.Round((double)item.Add07 * rate, 2);
                        mySal.Add08 = Math.Round((double)item.Add08 * rate, 2);
                        mySal.Add09 = (double)item.Add09;
                        mySal.Add10 = (double)item.Add10;
                        mySal.Add11 = (double)item.Add11;
                        mySal.Add12 = (double)item.Add12;
                        mySal.Add13 = Math.Round((double)item.Add13 * rate, 2);
                        mySal.Add14 = Math.Round((double)item.Add14 * rate, 2);
                        mySal.Add15 = (double)item.Add15;
                        mySal.Ded01 = Math.Round((double)item.Ded01 * rate, 2);
                        mySal.Ded02 = (double)item.Ded02;
                        mySal.Ded03 = (double)item.Ded03;
                        mySal.Ded04 = (double)item.Ded04;
                        mySal.Ded05 = (double)item.Ded05;
                        mySal.Ded06 = (double)item.Ded06;
                        mySal.Ded07 = (double)item.Ded07;
                        mySal.Ded08 = (double)item.Ded08;
                        mySal.Ded09 = (double)item.Ded09;
                        mySal.Ded10 = (double)item.Ded10;
                        mySal.Ded11 = (double)item.Ded11;
                        mySal.Ded12 = (double)item.Ded12;
                        mySal.Ded13 = (double)item.Ded13;
                        mySal.Ded14 = (double)item.Ded14;
                        mySal.Ded15 = (double)item.Ded15;
                        mySal.Section = item.Section;
                        mySal.Username = Session["CurrentUser"].ToString();
                        mySal.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                        mySal.NoDays = (short)NoofDays;

                            mySal.Basic = 0;
                            mySal.Add01 = 0;
                            mySal.Add02 = 0;
                            mySal.Add03 = 0;
                            mySal.Add04 = 0;
                            mySal.Add05 = 0;
                            mySal.Add06 = 0;
                            //mySal.Add07 = 0;
                            //mySal.Add08 = 0;
                            mySal.Add09 = 0;
                            mySal.Add10 = 0;
                            mySal.Add11 = 0;
                            mySal.Add12 = 0;
                            mySal.Add13 = 0;
                            mySal.Add14 = 0;
                            //mySal.Add15 = 0;
                            //mySal.Ded01 = 0;
                            mySal.Ded02 = 0;
                            mySal.Ded03 = 0;
                            mySal.Ded04 = 0;
                            mySal.Ded05 = 0;
                            mySal.Ded06 = 0;
                            mySal.Ded07 = 0;
                            mySal.Ded08 = 0;
                            mySal.Ded09 = 0;
                            mySal.Ded10 = 0;
                            mySal.Ded11 = 0;
                            mySal.Ded12 = 0;
                            mySal.Ded13 = 0;
                            mySal.Ded14 = 0;
                            mySal.Ded15 = 0;
                            mySal.NoDays = 0;

                        mySal.insertSalary(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    else if (item.EndDate != "" && DateTime.Parse(item.EndDate) > vStart && DateTime.Parse(item.EndDate) <= vEnd)
                    {
                        if (item.VacDate == "01/01/2999")
                        {
                            double NoofDays = 30;
                            double rate = 1;
                            TimeSpan ts = new TimeSpan();
                            ts = DateTime.Parse(item.EndDate) - vStart;
                            NoofDays = ts.Days;
                            if (NoofDays > 30) NoofDays = 30;
                            rate = NoofDays / 30;

                            mySal = new Salaries();
                            mySal.EmpCode = item.EmpCode;
                            mySal.Year1 = short.Parse(ddlYear.SelectedValue);
                            mySal.Month1 = short.Parse(ddlMonth.SelectedValue);

                            Salaries oldSal = new Salaries();
                            oldSal.EmpCode = item.EmpCode;
                            if (ddlMonth.SelectedValue == "1")
                            {
                                oldSal.Year1 = (short)(int.Parse(ddlYear.SelectedValue) - 1);
                                oldSal.Month1 = 12;
                            }
                            else
                            {
                                oldSal.Year1 = short.Parse(ddlYear.SelectedValue);
                                oldSal.Month1 = (short)(int.Parse(ddlMonth.SelectedValue) - 1);
                            }
                            oldSal = oldSal.GetEmp(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (oldSal != null)
                            {
                                mySal.Remark = oldSal.Remark;
                            }
                            else mySal.Remark = "";

                            mySal.Basic = Math.Round((double)item.Basic * rate, 2);
                            mySal.Add01 = Math.Round((double)item.Add01 * rate, 2);
                            mySal.Add02 = Math.Round((double)item.Add02 * rate, 2);
                            mySal.Add03 = Math.Round((double)item.Add03 * rate, 2);
                            mySal.Add04 = (double)item.Add04;
                            mySal.Add05 = Math.Round((double)item.Add05 * rate, 2);
                            mySal.Add06 = (double)item.Add06;
                            mySal.Add07 = 0;    // Math.Round((double)item.Add07 * rate, 2);
                            mySal.Add08 = 0;    // Math.Round((double)item.Add08 * rate, 2);
                            mySal.Add09 = (double)item.Add09;
                            mySal.Add10 = (double)item.Add10;
                            mySal.Add11 = (double)item.Add11;
                            mySal.Add12 = (double)item.Add12;
                            mySal.Add13 = Math.Round((double)item.Add13 * rate, 2);
                            mySal.Add14 = Math.Round((double)item.Add14 * rate, 2);
                            mySal.Add15 = (double)item.Add15;
                            mySal.Ded01 = 0;
                            mySal.Ded02 = (double)item.Ded02;
                            mySal.Ded03 = (double)item.Ded03;
                            mySal.Ded04 = (double)item.Ded04;
                            mySal.Ded05 = (double)item.Ded05;
                            mySal.Ded06 = (double)item.Ded06;
                            mySal.Ded07 = (double)item.Ded07;
                            mySal.Ded08 = (double)item.Ded08;
                            mySal.Ded09 = (double)item.Ded09;
                            mySal.Ded10 = (double)item.Ded10;
                            mySal.Ded11 = (double)item.Ded11;
                            mySal.Ded12 = (double)item.Ded12;
                            mySal.Ded13 = (double)item.Ded13;
                            mySal.Ded14 = (double)item.Ded14;
                            mySal.Ded15 = (double)item.Ded15;
                            mySal.Section = item.Section;
                            mySal.Username = Session["CurrentUser"].ToString();
                            mySal.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            mySal.NoDays = (short)NoofDays;
                            mySal.insertSalary(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                        else
                        {
                            mySal = new Salaries();
                            mySal.EmpCode = item.EmpCode;
                            mySal.Year1 = short.Parse(ddlYear.SelectedValue);
                            mySal.Month1 = short.Parse(ddlMonth.SelectedValue);

                            Salaries oldSal = new Salaries();
                            oldSal.EmpCode = item.EmpCode;
                            if (ddlMonth.SelectedValue == "1")
                            {
                                oldSal.Year1 = (short)(int.Parse(ddlYear.SelectedValue) - 1);
                                oldSal.Month1 = 12;
                            }
                            else
                            {
                                oldSal.Year1 = short.Parse(ddlYear.SelectedValue);
                                oldSal.Month1 = (short)(int.Parse(ddlMonth.SelectedValue) - 1);
                            }
                            oldSal = oldSal.GetEmp(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (oldSal != null)
                            {
                                mySal.Remark = oldSal.Remark;
                            }
                            else mySal.Remark =  "";

                            mySal.Section = item.Section;
                            mySal.Username = Session["CurrentUser"].ToString();
                            mySal.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            mySal.NoDays = 0;
                            mySal.insertSalary(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                    }
                }


                List<Arch> la = new List<Arch>();
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(Session["Branch"].ToString());
                myArch.LocNumber = short.Parse(ddlYear.SelectedValue);
                myArch.Number = int.Parse(ddlMonth.SelectedValue);
                myArch.DocType = 333;
                la = myArch.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (la.Count > 0)
                {
                    foreach (Arch itm in la)
                    {
                        UnDeleteExcelData(System.IO.Path.GetFullPath(Server.MapPath(itm.FileName2)));
                    }
                }

                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                LblCodesResult.Text = "لقد تم تشغيل البيانات بنجاح";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(1,'" + LblCodesResult.Text + "');", true);
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }

        }

        protected void BtnPostJv_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                MyConfig mysetting = new MyConfig();
                mysetting.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mysetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                mysetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                if (mysetting != null)
                {
                    Salaries mySal = new Salaries();
                    mySal.Year1 = short.Parse(ddlYear.SelectedValue);
                    mySal.Month1 = short.Parse(ddlMonth.SelectedValue);
                    if (mySal.CheckMonth(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        // get New Jv Number
                        List<Jv> lJv = new List<Jv>();
                        Jv myJv = new Jv();
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
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
                        int vStart = (int)i;
                        int FNo = 1;
                        double Net  = 0;
                        double Ded01 = 0;
                        foreach (Salaries itm in mySal.GetAllSalary(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            Acc myAcc = new Acc();
                            myAcc.Branch = short.Parse(Session["Branch"].ToString());
                            myAcc.Code = "12050" + itm.EmpCode;
                            if (myAcc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                //Net += (double)itm.Basic + (double)itm.Add01 + (double)itm.Add02 + (double)itm.Add03 + (double)itm.Add04 + (double)itm.Add05 + (double)itm.Add06 + (double)itm.Add07 + (double)itm.Add08 + (double)itm.Add09 + (double)itm.Add10 + (double)itm.Add11 + (double)itm.Add12 + (double)itm.Add13 + (double)itm.Add14 + (double)itm.Add15 - (double)itm.Ded01 - (double)itm.Ded02 - (double)itm.Ded03 - (double)itm.Ded04 - (double)itm.Ded05 - (double)itm.Ded06 - (double)itm.Ded07 - (double)itm.Ded08 - (double)itm.Ded09 - (double)itm.Ded10 - (double)itm.Ded11 - (double)itm.Ded12 - (double)itm.Ded13 - (double)itm.Ded14 - (double)itm.Ded15;
                                Net = (double)itm.Basic + (double)itm.Add01 + (double)itm.Add02 + (double)itm.Add03 + (double)itm.Add04 + (double)itm.Add05 + (double)itm.Add06 + (double)itm.Add07 + (double)itm.Add08 + (double)itm.Add09 + (double)itm.Add10 + (double)itm.Add11 + (double)itm.Add12 + (double)itm.Add13 + (double)itm.Add14 + (double)itm.Add15 - (double)itm.Ded01 - (double)itm.Ded02 - (double)itm.Ded03 - (double)itm.Ded04 - (double)itm.Ded05 - (double)itm.Ded06 - (double)itm.Ded07 - (double)itm.Ded08 - (double)itm.Ded09 - (double)itm.Ded10 - (double)itm.Ded11 - (double)itm.Ded12 - (double)itm.Ded13 - (double)itm.Ded14 - (double)itm.Ded15;
                                if (itm.Basic != 0) lJv.Add(PutJv(vStart, FNo++, true, mysetting.BasicAcc == "-1" ? myAcc.Code : mysetting.BasicAcc, (double)itm.Basic, (itm.sBasic.Trim() == "" ? "أساسي الموظف ": itm.sBasic) + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Add01 != 0) lJv.Add(PutJv(vStart, FNo++, true, mysetting.AddAcc01 == "-1" ? myAcc.Code : mysetting.AddAcc01, (double)itm.Add01, (itm.sAdd01.Trim() == "" ? mysetting.Add01 : itm.sAdd01)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Add02 != 0) lJv.Add(PutJv(vStart, FNo++, true, mysetting.AddAcc02 == "-1" ? myAcc.Code : mysetting.AddAcc02, (double)itm.Add02, (itm.sAdd02.Trim() == "" ? mysetting.Add02 : itm.sAdd01)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Add03 != 0) lJv.Add(PutJv(vStart, FNo++, true, mysetting.AddAcc03 == "-1" ? myAcc.Code : mysetting.AddAcc03, (double)itm.Add03, (itm.sAdd03.Trim() == "" ? mysetting.Add03 : itm.sAdd01)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Add04 != 0) lJv.Add(PutJv(vStart, FNo++, true, mysetting.AddAcc04 == "-1" ? myAcc.Code : mysetting.AddAcc04, (double)itm.Add04, (itm.sAdd04.Trim() == "" ? mysetting.Add04 : itm.sAdd01)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, "00002"));
                                if (itm.Add05 != 0) lJv.Add(PutJv(vStart, FNo++, true, mysetting.AddAcc05 == "-1" ? myAcc.Code : mysetting.AddAcc05, (double)itm.Add05, (itm.sAdd05.Trim() == "" ? mysetting.Add05 : itm.sAdd01)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Add06 != 0) lJv.Add(PutJv(vStart, FNo++, true, mysetting.AddAcc06 == "-1" ? myAcc.Code : mysetting.AddAcc06, (double)itm.Add06, (itm.sAdd06.Trim() == "" ? mysetting.Add06 : itm.sAdd01)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Add07 != 0) lJv.Add(PutJv(vStart, FNo++, true, mysetting.AddAcc07 == "-1" ? myAcc.Code : mysetting.AddAcc07, (double)itm.Add07, (itm.sAdd07.Trim() == "" ? mysetting.Add07 : itm.sAdd01)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Add08 != 0) lJv.Add(PutJv(vStart, FNo++, true, mysetting.AddAcc08 == "-1" ? myAcc.Code : mysetting.AddAcc08, (double)itm.Add08, (itm.sAdd08.Trim() == "" ? mysetting.Add08 : itm.sAdd01)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Add09 != 0) lJv.Add(PutJv(vStart, FNo++, true, mysetting.AddAcc09 == "-1" ? myAcc.Code : mysetting.AddAcc09, (double)itm.Add09, (itm.sAdd09.Trim() == "" ? mysetting.Add09 : itm.sAdd01)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc)); 
                                if (itm.Add10 != 0) lJv.Add(PutJv(vStart, FNo++, true, mysetting.AddAcc10 == "-1" ? myAcc.Code : mysetting.AddAcc10, (double)itm.Add10, (itm.sAdd10.Trim() == "" ? mysetting.Add10 : itm.sAdd01)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Add11 != 0) lJv.Add(PutJv(vStart, FNo++, true, mysetting.AddAcc11 == "-1" ? myAcc.Code : mysetting.AddAcc11, (double)itm.Add11, (itm.sAdd11.Trim() == "" ? mysetting.Add11 : itm.sAdd01)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Add12 != 0) lJv.Add(PutJv(vStart, FNo++, true, mysetting.AddAcc12 == "-1" ? myAcc.Code : mysetting.AddAcc12, (double)itm.Add12, (itm.sAdd12.Trim() == "" ? mysetting.Add12 : itm.sAdd01)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Add13 != 0) lJv.Add(PutJv(vStart, FNo++, true, mysetting.AddAcc13 == "-1" ? myAcc.Code : mysetting.AddAcc13, (double)itm.Add13, (itm.sAdd13.Trim() == "" ? mysetting.Add13 : itm.sAdd01)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Add14 != 0) lJv.Add(PutJv(vStart, FNo++, true, mysetting.AddAcc14 == "-1" ? myAcc.Code : mysetting.AddAcc14, (double)itm.Add14, (itm.sAdd14.Trim() == "" ? mysetting.Add14 : itm.sAdd01)+ "  " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Add15 != 0) lJv.Add(PutJv(vStart, FNo++, true, mysetting.AddAcc15 == "-1" ? myAcc.Code : mysetting.AddAcc15, (double)itm.Add15, (itm.sAdd15.Trim() == "" ? mysetting.Add15 : itm.sAdd01)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (Net < 0) lJv.Add(PutJv(vStart, FNo++, true, "240101001", Net * -1, " راتب " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), "-1", "-1", "-1", "-1", myAcc.EmpCode, "-1"));

                                //if (itm.Ded01 != 0) lJv.Add(PutJv(vStart, (10000 + FNo++), false, mysetting.DedAcc01 == "-1" ? myAcc.Code : mysetting.DedAcc01, (double)itm.Ded01, itm.sDed01.Trim() == "" ? mysetting.Ded01 + " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString() : itm.sDed01, myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                Ded01 += (double)itm.Ded01;
                                if (itm.Ded02 != 0) lJv.Add(PutJv(vStart, (10000 + FNo++), false, mysetting.DedAcc02 == "-1" ? myAcc.Code : mysetting.DedAcc02, (double)itm.Ded02, (itm.sDed02.Trim() == "" ? mysetting.Ded02 : itm.sDed02)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Ded03 != 0) lJv.Add(PutJv(vStart, (10000 + FNo++), false, mysetting.DedAcc03 == "-1" ? myAcc.Code : mysetting.DedAcc03, (double)itm.Ded03, (itm.sDed03.Trim() == "" ? mysetting.Ded03 : itm.sDed03)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Ded04 != 0) lJv.Add(PutJv(vStart, (10000 + FNo++), false, mysetting.DedAcc04 == "-1" ? myAcc.Code : mysetting.DedAcc04, (double)itm.Ded04, (itm.sDed04.Trim() == "" ? mysetting.Ded04 : itm.sDed04)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Ded05 != 0) lJv.Add(PutJv(vStart, (10000 + FNo++), false, mysetting.DedAcc05 == "-1" ? myAcc.Code : mysetting.DedAcc05, (double)itm.Ded05, (itm.sDed05.Trim() == "" ? mysetting.Ded05 : itm.sDed05)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Ded06 != 0) lJv.Add(PutJv(vStart, (10000 + FNo++), false, mysetting.DedAcc06 == "-1" ? myAcc.Code : mysetting.DedAcc06, (double)itm.Ded06, (itm.sDed06.Trim() == "" ? mysetting.Ded06 : itm.sDed06)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Ded07 != 0) lJv.Add(PutJv(vStart, (10000 + FNo++), false, mysetting.DedAcc07 == "-1" ? myAcc.Code : mysetting.DedAcc07, (double)itm.Ded07, (itm.sDed07.Trim() == "" ? mysetting.Ded07 : itm.sDed07)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Ded08 != 0) lJv.Add(PutJv(vStart, (10000 + FNo++), false, mysetting.DedAcc08 == "-1" ? myAcc.Code : mysetting.DedAcc08, (double)itm.Ded08, (itm.sDed08.Trim() == "" ? mysetting.Ded08 : itm.sDed08)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Ded09 != 0) lJv.Add(PutJv(vStart, (10000 + FNo++), false, mysetting.DedAcc09 == "-1" ? myAcc.Code : mysetting.DedAcc09, (double)itm.Ded09, (itm.sDed09.Trim() == "" ? mysetting.Ded09 : itm.sDed09)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Ded10 != 0) lJv.Add(PutJv(vStart, (10000 + FNo++), false, mysetting.DedAcc10 == "-1" ? myAcc.Code : mysetting.DedAcc10, (double)itm.Ded10, (itm.sDed10.Trim() == "" ? mysetting.Ded10 : itm.sDed10)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Ded11 != 0) lJv.Add(PutJv(vStart, (10000 + FNo++), false, mysetting.DedAcc11 == "-1" ? myAcc.Code : mysetting.DedAcc11, (double)itm.Ded11, (itm.sDed11.Trim() == "" ? mysetting.Ded11 : itm.sDed11)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Ded12 != 0) lJv.Add(PutJv(vStart, (10000 + FNo++), false, mysetting.DedAcc12 == "-1" ? myAcc.Code : mysetting.DedAcc12, (double)itm.Ded12, (itm.sDed12.Trim() == "" ? mysetting.Ded12 : itm.sDed12)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Ded13 != 0) lJv.Add(PutJv(vStart, (10000 + FNo++), false, mysetting.DedAcc13 == "-1" ? myAcc.Code : mysetting.DedAcc13, (double)itm.Ded13, (itm.sDed13.Trim() == "" ? mysetting.Ded13 : itm.sDed13)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Ded14 != 0) lJv.Add(PutJv(vStart, (10000 + FNo++), false, mysetting.DedAcc14 == "-1" ? myAcc.Code : mysetting.DedAcc14, (double)itm.Ded14, (itm.sDed14.Trim() == "" ? mysetting.Ded14 : itm.sDed14)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (itm.Ded15 != 0) lJv.Add(PutJv(vStart, (10000 + FNo++), false, mysetting.DedAcc15 == "-1" ? myAcc.Code : mysetting.DedAcc15, (double)itm.Ded15, (itm.sDed15.Trim() == "" ? mysetting.Ded15 : itm.sDed15)+ " " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), myAcc.Area, myAcc.CostCenter, myAcc.Project, myAcc.CarNo, myAcc.EmpCode, myAcc.CostAcc));
                                if (Net > 0) lJv.Add(PutJv(vStart, (10000 + FNo++), false, "240101001", Net, " راتب " + itm.Name + " عن شهر  " + itm.Month1.ToString() + "-" + itm.Year1.ToString(), "-1", "-1", "-1", "-1", myAcc.EmpCode, "-1"));

                                itm.VouNo = vStart;
                                itm.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }
                        }
                        //if (Net > 0) lJv.Add(PutJv(vStart, (9000 + FNo++), false, "240101001", Net, " رواتب الموظفين عن شهر " + ddlMonth.Text + "-" + ddlYear.Text, "-1", "-1", "-1", "-1", "-1", "-1")); // رواتب مستحقة
                        if (Ded01 != 0) lJv.Add(PutJv(vStart, (9000 + FNo++), false, mysetting.DedAcc01, Ded01, " تامينات الموظفين عن شهر  " + ddlMonth.Text + "-" + ddlYear.Text ,"-1", "-1", "-1", "-1", "-1", "-1"));
                        myJv = new Jv();
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.FType = 100;
                        myJv.LocType = 1;
                        myJv.LocNumber = 1;
                        i = myJv.GetNewNumber(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == 0 || i == null)
                        {
                            i = 1;
                        }
                        else
                        {
                            i++;
                        }
                        vStart = (int)i;
                        FNo = 1;
                        foreach(Jv itm in (from itm in lJv
                                            orderby itm.FNo
                                            select itm).ToList())
                        {
                            itm.FNo = (short)FNo++;
                            itm.Number = vStart;
                            itm.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);                        
                        }

                    
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormName = "ترحيل قيد الرواتب";
                            UserTran.FormAction = "ترحيل";
                            UserTran.Description = "ترحيل قيد الرواتب رقم  لشهر";
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }

                        // Catch Arch Files
                        Arch myArch2 = new Arch();
                        myArch2.Branch = short.Parse(Session["Branch"].ToString());
                        myArch2.LocNumber = 0;
                        myArch2.Number = vStart;
                        myArch2.DocType = 101;

                        i = myArch2.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        SalOP vsp = new SalOP();
                        vsp.Year1 = short.Parse(ddlYear.SelectedValue);
                        vsp.Month1 = short.Parse(ddlMonth.SelectedValue);
                        foreach (SalOP sitm in vsp.GetMonth2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            Arch myArch = new Arch();
                            myArch.Branch = short.Parse(ddlYear.SelectedValue);
                            myArch.LocNumber = short.Parse(ddlMonth.SelectedValue);
                            myArch.Number = sitm.Section;
                            myArch.DocType = 400;
                            foreach(Arch Aitm in myArch.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                myArch2 = new Arch();
                                myArch2.Branch = short.Parse(Session["Branch"].ToString());
                                myArch2.LocNumber = 0;
                                myArch2.Number = vStart;
                                myArch2.DocType = 101;
                                myArch2.FileName = Aitm.FileName;
                                myArch2.FileName2 = Aitm.FileName2;
                                myArch2.FNo = (short)i;
                                myArch2.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                i++;
                            }
                        }

                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تم ترحيل القيد رقم " + "" + " بنجاح";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(1,'" + LblCodesResult.Text + "');", true);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لم يتم تشغيل الشهر من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(0,'" + LblCodesResult.Text + "');", true);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }


        public Jv PutJv(int JvNumber,int FNo,bool Debit,string Account,double Amount,string Remark,string Area,string CostCenter,string Project,string CarNo, string EmpCode,string CostAcc)
        {
            return new Jv{
                Branch = short.Parse(Session["Branch"].ToString()),
                FType = 100,
                LocType = 1,
                LocNumber = 1,
                Number = JvNumber,
                FNo = (short)FNo,
                FDate = moh.MakeMask(DateTime.DaysInMonth(int.Parse(ddlYear.SelectedValue),int.Parse(ddlMonth.SelectedValue)).ToString(),2) + "/" + moh.MakeMask(ddlMonth.SelectedValue,2) + "/" + ddlYear.SelectedValue,
                UserName = Session["CurrentUser"].ToString(),
                UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows()),
                Post = 1,
                DbCode = Debit ? Account :"",
                CrCode = Debit ? "" :Account,
                Amount = Amount,
                InvNo = "",
                Remark = Remark,
                Area = Account.StartsWith("3") || Account.StartsWith("4") ? Area: "-1",
                CostCenter = Account.StartsWith("3") || Account.StartsWith("4") ? CostCenter: "-1",
                Project = Account.StartsWith("3") || Account.StartsWith("4") ? Project: "-1",
                CarNo = Account.StartsWith("3") || Account.StartsWith("4") ? CarNo: "-1",
                CostAcc = Account.StartsWith("3") || Account.StartsWith("4") ? CostAcc: "-1",
                EmpCode = Account.StartsWith("3") || Account.StartsWith("4") || Account == "240101001" ? EmpCode : "-1",
                BankName = "",
                ChequeDate = "",
                ChequeNo = "",
                Claim = 0,
                DocType = 0,
                Seller = 0,
                FNo2 = 0,
                Person = "",
                Payment = 0
            };
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            Salaries mySal =new Salaries();
            mySal.Year1 = short.Parse(ddlYear.SelectedValue);
            mySal.Month1 = short.Parse(ddlMonth.SelectedValue);
            if (mySal.CheckMonth(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            {
                mySal = mySal.GetAllSalary(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                if (mySal != null)
                {
                    lblEmp.Visible = true;
                    txtName.Visible = true;
                    txtEmpCode.Visible = true;
                    divTransfer.Visible = true;
                    BtnAdd.Visible = true;
                    BtnRemove.Visible = true;

                    BtnProcess.Visible = true;
                    BtnDelete.Visible = true;
                    BtnPostJv.Visible = ((List<TblRoles>)(Session["Roll"]))[0].RoleName.Contains("مدير الحسابات") || ((List<TblRoles>)(Session["Roll"]))[0].RoleName.ToLower().Contains("admin");
                    if (mySal.VouNo > 0)
                    {
                        lblStatus.Text = @"<a href='WebJVou.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FNum=" + mySal.VouNo.ToString() + @"' target='_blank'> تم ترحيل القيد رقم " + mySal.VouNo.ToString() + @"</a>";
                        BtnDelete.Visible = false;
                        BtnPostJv.Visible = false;
                        BtnProcess.Visible = false;
                    }
                    else lblStatus.Text = "";
                }
            }
            else
            {
                BtnDelete.Visible = false;
                BtnPostJv.Visible = false;

                lblEmp.Visible = false;
                txtName.Visible = false;
                txtEmpCode.Visible = false;
                divTransfer.Visible = false;
                BtnAdd.Visible = false;
                BtnRemove.Visible = false;
            }

            SalOP vsp = new SalOP();
            vsp.Year1 = short.Parse(ddlYear.SelectedValue);
            vsp.Month1 = short.Parse(ddlMonth.SelectedValue);
            grdActiveTran.DataSource = vsp.GetMonth2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            grdActiveTran.DataBind();
            LoadAttachData();
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
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(ddlYear.SelectedValue);
                        myArch.Number = int.Parse(ddlMonth.SelectedValue);
                        myArch.DocType = 333;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(ddlYear.SelectedValue);
                        myArch.Number = int.Parse(ddlMonth.SelectedValue);
                        myArch.DocType = 333;
                        myArch.FileName = FileUpload1.FileName;
                        myArch.FileName2 = mySetting.ImagePath2 + FileName;
                        myArch.FNo = (short)i;
                        myArch.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        // Update Payroll Status
                        FileStream fs = new FileStream(Server.MapPath(myArch.FileName2), FileMode.Open, FileAccess.Read, FileShare.None);
                        string str = "";
                        using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding(936)))
                        {
                            str = sr.ReadLine();
                            while (sr.Peek() >= 0)
                            {
                                str = sr.ReadLine();
                                string[] xu = str.Split('\t');
                                if (xu[0][0] == '0')
                                {
                                    SEmp MyEmp = new SEmp();
                                    MyEmp.ATM = xu[1].Substring(1);
                                    MyEmp = MyEmp.FindByATM(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (MyEmp != null)
                                    {
                                        Salaries mySal = new Salaries();
                                        mySal.EmpCode = MyEmp.EmpCode;
                                        mySal.Month1 = short.Parse(ddlMonth.SelectedValue);
                                        mySal.Year1 = short.Parse(ddlYear.SelectedValue);
                                        mySal.Status = true;
                                        mySal.SetStatus(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    }
                                }
                            }
                            sr.Close();
                        }
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
                        LblCodesResult.Text = ex.Message.ToString();
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
                myArch.Branch = short.Parse(Session["Branch"].ToString());
                myArch.LocNumber = short.Parse(ddlYear.SelectedValue);
                myArch.Number = int.Parse(ddlMonth.SelectedValue);
                myArch.DocType = 333;
                myArch.FNo = short.Parse(FNo);
                myArch = myArch.FindFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myArch != null)
                {
                    DeleteExcelData(System.IO.Path.GetFullPath(Server.MapPath(myArch.FileName2)));
                    myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }
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
                VouData.Clear();
                List<Arch> la = new List<Arch>();
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(Session["Branch"].ToString());
                myArch.LocNumber = short.Parse(ddlYear.SelectedValue);
                myArch.Number = int.Parse(ddlMonth.SelectedValue);
                myArch.DocType = 333;
                la = myArch.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                grdAttach.DataSource = la;
                grdAttach.DataBind();
                if (la.Count > 0)
                {
                    foreach (Arch itm in la)
                    {
                        GenerateExcelData(System.IO.Path.GetFullPath(Server.MapPath(itm.FileName2)));
                    }

                    cpeDemo.Collapsed = false;
                    cpeDemo.ClientState = "false";
                }
                else
                {
                    cpeDemo.Collapsed = true;
                    cpeDemo.ClientState = "true";
                }

                Pay myPay = new Pay();
                myPay.Month1 = short.Parse(ddlMonth.SelectedValue);
                myPay.Year1 = short.Parse(ddlYear.SelectedValue);
                VouData.AddRange((from itm in myPay.GetMonth2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                      select new TransSal
                                         {
                                             Net = 0,
                                             ATM = itm.ATM,
                                             Name = itm.Name,                                
                                             Basic = 0,
                                             House = 0,
                                             Other = 0,
                                             Ded = 0,
                                             ID = itm.PaperNo1,
                                             Status = ""
                                         }).ToList());
                grvData.DataSource = VouData;
                grvData.DataBind();
        }

        private void GenerateExcelData(string FileName)
        {
            try
            {
                FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.None);
                string str = "";
                using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding(936)))
                {
                    str = sr.ReadLine();
                    while (sr.Peek() >= 0)
                    {
                        str = sr.ReadLine();
                        string[] xu = str.Split('\t');
                        if (xu[0][0] == '0')
                        {
                            VouData.Add(new TransSal
                            {
                                Net = moh.StrToDouble(xu[0].Replace(',','.')),
                                ATM = xu[1].Substring(1),
                                Name = xu[2],
                                Basic = moh.StrToDouble(xu[6].Replace(',', '.')),
                                House = moh.StrToDouble(xu[7].Replace(',', '.')),
                                Other = moh.StrToDouble(xu[8].Replace(',', '.')),
                                Ded = moh.StrToDouble(xu[9].Replace(',', '.')),
                                ID = xu[10],
                                Status = xu[12]
                            });
                        }
                    }
                    sr.Close();
                }
            }
            // need to catch possible exceptions
            catch (Exception ex)
            {
                LblCodesResult.Text = ex.ToString();
            }
        }// close of method GemerateExceLData


        private void DeleteExcelData(string FileName)
        {
            try
            {
                FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.None);
                string str = "";
                using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding(936)))
                {
                    str = sr.ReadLine();
                    while (sr.Peek() >= 0)
                    {
                        str = sr.ReadLine();
                        string[] xu = str.Split('\t');
                        if (xu[0][0] == '0')
                        {
                            SEmp MyEmp = new SEmp();
                            MyEmp.ATM = xu[1].Substring(1);
                            MyEmp = MyEmp.FindByATM(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (MyEmp != null)
                            {
                                Salaries mySal = new Salaries();
                                mySal.EmpCode = MyEmp.EmpCode;
                                mySal.Month1 = short.Parse(ddlMonth.SelectedValue);
                                mySal.Year1 = short.Parse(ddlYear.SelectedValue);
                                mySal.Status = false;
                                mySal.SetStatus(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }
                        }
                    }
                    sr.Close();
                }
            }
            // need to catch possible exceptions
            catch (Exception ex)
            {
                LblCodesResult.Text = ex.ToString();
            }
        }// close of method GemerateExceLData


        private void UnDeleteExcelData(string FileName)
        {
            try
            {
                FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.None);
                string str = "";
                using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding(936)))
                {
                    str = sr.ReadLine();
                    while (sr.Peek() >= 0)
                    {
                        str = sr.ReadLine();
                        string[] xu = str.Split('\t');
                        if (xu[0][0] == '0')
                        {
                            SEmp MyEmp = new SEmp();
                            MyEmp.ATM = xu[1].Substring(1);
                            MyEmp = MyEmp.FindByATM(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (MyEmp != null)
                            {
                                Salaries mySal = new Salaries();
                                mySal.EmpCode = MyEmp.EmpCode;
                                mySal.Month1 = short.Parse(ddlMonth.SelectedValue);
                                mySal.Year1 = short.Parse(ddlYear.SelectedValue);
                                mySal.Status = true;
                                mySal.SetStatus(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }
                        }
                    }
                    sr.Close();
                }
            }
            // need to catch possible exceptions
            catch (Exception ex)
            {
                LblCodesResult.Text = ex.ToString();
            }
        }
        // close of method GemerateExceLData

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmpCode.Text != "")
                {
                    SEmp MyEmp = new SEmp();
                    MyEmp.EmpCode = int.Parse(txtEmpCode.Text);
                    MyEmp = MyEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (MyEmp != null)
                    {
                        bool sfind = false;
                        foreach (TransSal itm in VouData)
                        {
                            if (itm.ATM == MyEmp.ATM)
                            {
                                sfind = true;
                                break;
                            }
                        }

                        if (!sfind)
                        {
                            Pay myPay = new Pay();
                            myPay.EmpCode = MyEmp.EmpCode;
                            myPay.Month1 = short.Parse(ddlMonth.SelectedValue);
                            myPay.Year1 = short.Parse(ddlYear.SelectedValue);
                            myPay.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            Salaries mySal = new Salaries();
                            mySal.EmpCode = MyEmp.EmpCode;
                            mySal.Month1 = short.Parse(ddlMonth.SelectedValue);
                            mySal.Year1 = short.Parse(ddlYear.SelectedValue);
                            mySal.Status = true;
                            mySal.SetStatus(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            VouData.Add(new TransSal
                             {
                                 Net = 0,
                                 ATM = MyEmp.ATM,
                                 Name = MyEmp.Name,                                
                                 Basic = 0,
                                 House = 0,
                                 Other = 0,
                                 Ded = 0,
                                 ID = MyEmp.PaperNo1,
                                 Status = ""
                             });

                            grvData.DataSource = VouData;
                            grvData.DataBind();

                            txtEmpCode.Text = "";
                            txtName.Text = "";
                            LblCodesResult.Text = "تمت اضافة تحويل راتب الموظف بنجاح";
          
                        }
                        else
                        {
                            LblCodesResult.Text = "الموظف تم تحويل الراتب له من قبل";
                        }
                    }
                    else
                    {
                        LblCodesResult.Text = "كود الموظف غير صحيح";
                    }
                }

            }
            catch (Exception ex)
            {
                LblCodesResult.Text = ex.ToString();
            }
        }

        protected void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmpCode.Text != "")
                {
                    SEmp MyEmp = new SEmp();
                    MyEmp.EmpCode = int.Parse(txtEmpCode.Text);
                    MyEmp = MyEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (MyEmp != null)
                    {
                        bool sfind = false;
                        foreach (TransSal itm in VouData)
                        {
                            if (itm.ATM == MyEmp.ATM)
                            {
                                VouData.Remove(itm);
                                sfind = true;
                                break;
                            }
                        }

                        if (sfind)
                        {
                            Pay myPay = new Pay();
                            myPay.EmpCode = MyEmp.EmpCode;
                            myPay.Month1 = short.Parse(ddlMonth.SelectedValue);
                            myPay.Year1 = short.Parse(ddlYear.SelectedValue);
                            myPay.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            Salaries mySal = new Salaries();
                            mySal.EmpCode = MyEmp.EmpCode;
                            mySal.Month1 = short.Parse(ddlMonth.SelectedValue);
                            mySal.Year1 = short.Parse(ddlYear.SelectedValue);
                            mySal.Status = false;
                            mySal.SetStatus(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            grvData.DataSource = VouData;
                            grvData.DataBind();

                            txtEmpCode.Text = "";
                            txtName.Text = "";

                            LblCodesResult.Text = "تمت الغاء تحويل راتب الموظف بنجاح";

                        }
                        else
                        {
                            LblCodesResult.Text = "الموظف لم يتم تحويل الراتب له من قبل";
                        }
                    }
                    else
                    {
                        LblCodesResult.Text = "كود الموظف غير صحيح";
                    }
                }

            }
            catch (Exception ex)
            {
                LblCodesResult.Text = ex.ToString();
            }
        }

    }
}
