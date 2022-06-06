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
    public partial class WebStatement : System.Web.UI.Page
    {
        public string TotalDbAmount
        {
            get
            {
                if (ViewState["TotalDbAmount"] == null)
                {
                    ViewState["TotalDbAmount"] = "0.00";
                }
                return ViewState["TotalDbAmount"].ToString();
            }
            set { ViewState["TotalDbAmount"] = value; }
        }
        public string TotalCrAmount
        {
            get
            {
                if (ViewState["TotalCrAmount"] == null)
                {
                    ViewState["TotalCrAmount"] = "0.00";
                }
                return ViewState["TotalCrAmount"].ToString();
            }
            set { ViewState["TotalCrAmount"] = value; }
        }
        public string TotalBal
        {
            get
            {
                if (ViewState["TotalBal"] == null)
                {
                    ViewState["TotalBal"] = "0.00";
                }
                return ViewState["TotalBal"].ToString();
            }
            set { ViewState["TotalBal"] = value; }
        }

        public List<vJv> MyOver
        {
            get
            {
                if (ViewState["MyOver"] == null)
                {
                    ViewState["MyOver"] = new List<vJv>();
                }
                return (List<vJv>)ViewState["MyOver"];
            }
            set { ViewState["MyOver"] = value; }
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
                BtnPrint1.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                BtnExcel.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnPrint1);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnExcel);

                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "كشف حساب تفصيلي";
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
                        UserTran.Description = "اختيار عرض كشف حساب تفصيلي";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    Area myArea = new Area();
                    myArea.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastArea" + Session["CNN2"].ToString()] == null) Cache.Insert("LastArea" + Session["CNN2"].ToString(), myArea.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlArea.DataTextField = "Name1";
                    ddlArea.DataValueField = "Code";
                    ddlArea.DataSource = (List<Area>)(Cache["LastArea" + Session["CNN2"].ToString()]);
                    ddlArea.DataBind();
                    ddlArea.Items.Insert(0, new ListItem("--- أختار المنطقة---", "-1", true));

                    CostCenter myCostCenter = new CostCenter();
                    myCostCenter.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlCostCenter.DataTextField = "Name1";
                    ddlCostCenter.DataValueField = "Code";
                    ddlCostCenter.DataSource = (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()]);
                    ddlCostCenter.DataBind();
                    ddlCostCenter.Items.Insert(0, new ListItem("--- أختار الفرع---", "-1", true));

                    AccProject myProject = new AccProject();
                    myProject.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastProject" + Session["CNN2"].ToString()] == null) Cache.Insert("LastProject" + Session["CNN2"].ToString(), myProject.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlProject.DataTextField = "Name1";
                    ddlProject.DataValueField = "Code";
                    ddlProject.DataSource = (List<AccProject>)(Cache["LastProject" + Session["CNN2"].ToString()]);
                    ddlProject.DataBind();
                    ddlProject.Items.Insert(0, new ListItem("--- أختار المشروع---", "-1", true));

                    CostAcc myCostAcc = new CostAcc();
                    myCostAcc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastCostAcc" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostAcc" + Session["CNN2"].ToString(), myCostAcc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlCostAcc.DataTextField = "Name1";
                    ddlCostAcc.DataValueField = "Code";
                    ddlCostAcc.DataSource = (List<CostAcc>)(Cache["LastCostAcc" + Session["CNN2"].ToString()]);
                    ddlCostAcc.DataBind();
                    ddlCostAcc.Items.Insert(0, new ListItem("--- أختار حساب التكاليف---", "-1", true));

                    ddlEmp.Items.Insert(0, new ListItem("--- أختار الموظف---", "-1", true));

                    AccCenter myCenter = new AccCenter();
                    myCenter.Branch = short.Parse(Session["Branch"].ToString());
                    ddlCenter.DataSource = myCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlCenter.DataTextField = "Name1";
                    ddlCenter.DataValueField = "Code";
                    ddlCenter.DataBind();
                    ddlCenter.Items.Insert(0, new ListItem("--- أختار مركز الحسابات ---", "-1", true));
                    ddlCenter.SelectedIndex = 0;

                    Cars myCar = new Cars();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlCars.DataTextField = "CodeName";
                    ddlCars.DataValueField = "Code";
                    ddlCars.DataSource = (from itm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                           orderby itm.Code
                                           select itm).ToList();
                    ddlCars.DataBind();
                    ddlCars.Items.Insert(0, new ListItem("--- أختار الشاحنة ---", "-1", true));
                    ddlCars.SelectedIndex = 0;

                    SEmp myemp = new SEmp();
                    if (Cache["Emps" + Session["CNN2"].ToString()] == null) Cache.Insert("Emps" + Session["CNN2"].ToString(), myemp.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    List<CostCenter> lemp = new List<CostCenter>();
                    lemp.AddRange((from itm in (List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()])
                                   select new CostCenter{
                                    Code = itm.EmpCode.ToString(),
                                    Name1 = itm.Name,
                                    Name2 = itm.Name2
                                   }).ToList());

                    ShipDrivers myuser = new ShipDrivers();
                    lemp.AddRange((from itm in myuser.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                           orderby itm.ID
                                           select new CostCenter {
                                                Code = "D"+itm.Num.ToString(),
                                                Name1 = "Driver " + itm.FirstName + " " + itm.LastName,
                                                Name2 = "Driver " + itm.FirstName + " " + itm.LastName
                                           }).ToList());
                    

                    ShipUsers myuser0 = new ShipUsers();
                    lemp.AddRange((from itm in myuser0.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                           orderby itm.ID
                                           select new CostCenter
                                           {                                               
                                               Code = "C"+itm.Num.ToString(),
                                               Name1 = "Customer " + itm.FirstName + " " + itm.LastName,
                                               Name2 = "Customer " + itm.FirstName + " " + itm.LastName
                                           }).ToList());


                    ddlEmp.DataTextField = "Name1";
                    ddlEmp.DataValueField = "Code";
                    ddlEmp.DataSource = lemp; // (List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()]);
                    ddlEmp.DataBind();
                    ddlEmp.Items.Insert(0, new ListItem("--- أختار الموظف---", "-1", true));

                    if (Request.QueryString["StoreNo"] != null) StoreNo = Request.QueryString["StoreNo"].ToString();
                    if (Request.QueryString["AreaNo"] != null) AreaNo = Request.QueryString["AreaNo"].ToString();

                    if (Request.QueryString["Code"] != null)
                    {
                        if (Request.QueryString["FDate"] != null)
                        {
                            ChkPeriod.Checked = false;
                            ChkPeriod_CheckedChanged(sender, e);
                            txtFDate.Text = Request.QueryString["FDate"].ToString();
                            txtEDate.Text = Request.QueryString["EDate"].ToString();
                        }

                        if (Request.QueryString["Center"] != null) ddlCostCenter.SelectedValue = Request.QueryString["Center"].ToString();

                        Acc myAcc = new Acc();
                        myAcc.Branch = short.Parse(Session["Branch"].ToString());
                        myAcc.Code = Request.QueryString["Code"].ToString();

                        if (myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            txtCode.Text = myAcc.Code;
                            txtName.Text = myAcc.Name1;
                            if (Request.QueryString["FMode"] == null) BtnProcess_Click(sender, null);
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
            finally
            {
             
            }
        }

        protected void LoadCodesData()
        {
            try
            {
                double OpenBal = 0;
                if (txtCode.Text != "")
                {
                    Acc myAcc = new Acc();
                    myAcc.Branch = short.Parse(Session["Branch"].ToString());
                    myAcc.Code = txtCode.Text;
                    if (myAcc.GetAcc(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        OpenBal = (double)(myAcc.ODAcc - myAcc.OCAcc);
                    }
                }
                else if (ddlCenter.SelectedIndex > 0)
                {
                    Acc myAcc = new Acc();
                    myAcc.Branch = short.Parse(Session["Branch"].ToString());
                    myAcc.BatchCode = ddlCenter.SelectedValue;
                    OpenBal = myAcc.GetOpenBatch(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }
                else
                {
                    grdCodes.DataSource = null;
                    grdCodes.DataBind();
                    return;
                }
                Jv myJv = new Jv();
                double bal = 0;
                DateTime vDate = DateTime.Parse(ChkPeriod.Checked ? "01/01/2012" : txtFDate.Text);
                DateTime vDate2 = DateTime.Parse(ChkPeriod.Checked ? "01/01/2012" : txtFDate.Text);
                //DateTime vDate2 = DateTime.Parse(ChkPeriod.Checked ? "01/01/2012" : txtFDate.Text);
                myJv.Branch = short.Parse(Session["Branch"].ToString());
                //if (Cache["MyJv"] != null)
                //{
                //    string FDate = txtFDate.Text;
                //    string EDate = txtEDate.Text;
                //    string Code = txtCode.Text;
                //    string Area = ddlArea.SelectedValue;
                //    string CostCenter = ddlCostCenter.SelectedValue;
                //    string Project = ddlProject.SelectedValue;
                //    string CostAcc = ddlCostAcc.SelectedValue;
                //    string EmpCode = ddlEmp.SelectedValue;
                //    string Center = ddlCenter.SelectedValue;
                //    string CarNo = ddlCars.SelectedValue;
                //    MyOver = (from sitm in (List<vJv>)(Cache["MyJv"])
                //              where sitm.Branch == myJv.Branch && (FDate == "" || (FDate != "" && DateTime.Parse(sitm.FDate) <= DateTime.Parse(EDate)))
                //              && ((Code == "") || (Code != "" && (sitm.DbCode.StartsWith(Code) || sitm.CrCode.StartsWith(Code))))
                //              //&& ((Area == "-1") || (Area != "-1" && Area == sitm.Area))
                //              //&& ((CostCenter == "-1") || (CostCenter != "-1" && CostCenter == sitm.CostCenter))
                //              //&& ((Project == "-1") || (Project != "-1" && Project == sitm.Project))
                //              //&& ((CostAcc == "-1") || (CostAcc != "-1" && CostAcc == sitm.CostAcc))
                //              //&& ((EmpCode == "-1") || (EmpCode != "-1" && EmpCode == sitm.EmpCode))
                //              //&& ((Center == "-1") || (Center != "-1" && Center == sitm.CostCenter))
                //              //&& ((CarNo == "-1") || (CarNo != "-1" && CarNo == sitm.CarNo))
                //              orderby DateTime.Parse(sitm.FDate)
                //              select sitm).ToList();
                //}
                //else 
                MyOver = myJv.GetStatement(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, ChkPeriod.Checked, txtFDate.Text, txtEDate.Text, txtCode.Text, ddlArea.SelectedValue, ddlCostCenter.SelectedValue, ddlProject.SelectedValue, ddlCostAcc.SelectedValue, ddlEmp.SelectedValue, ddlCenter.SelectedValue, ddlCars.SelectedValue);
                MyOver.Insert(0, new vJv { FType = 0, FDate = ChkPeriod.Checked ? "01/01/2012" : txtFDate.Text, Bal = OpenBal });
                bal = OpenBal;
                if (!ChkPeriod.Checked && txtFDate.Text.StartsWith("01/01/") && DateTime.Parse(txtFDate.Text) >= DateTime.Parse("01/01/2018"))
                {
                    bool vFound = false;
                    foreach (vJv itm in MyOver)
                    {
                        if (itm.FType == 100 && itm.InvNo == "OPEN" && itm.FDate == txtFDate.Text)
                        {
                            vFound = true;
                            vDate = DateTime.Parse(itm.FDate);
                            OpenBal = itm.DbAmount - itm.CrAmount;
                            bal = OpenBal;
                            MyOver.Remove(itm);
                            break;
                        }
                    }
                    if (vFound && !ChkPeriod.Checked) MyOver.RemoveAll(p => DateTime.Parse(p.FDate) < vDate);
                }

                foreach (vJv itm in MyOver)
                {
                    if (vDate > DateTime.Parse(itm.FDate))
                    {
                        OpenBal = OpenBal + itm.DbAmount - itm.CrAmount;
                    }
                    else
                    {
                        vDate2 = DateTime.Parse(itm.FDate);
                        //if (itm.FType == 103) CheckInv(itm);
                    }
                    bal = bal + itm.DbAmount - itm.CrAmount;
                    itm.Bal = bal;
                    if (this.ChkPeriod.Checked ||DateTime.Parse(itm.FDate) >= DateTime.Parse(txtFDate.Text))
                    {                        
                        //if (Cache["MyJv"] != null) itm.AccName1 = GetName(itm);
                        if (itm.RecCount > 2) itm.AccName1 = (itm.DbAmount > 0 ?  "إلى مذكورين" : "من مذكورين");
                        else itm.AccName1 = myJv.GetAccName(itm.Branch, itm.FType, itm.LocType, itm.LocNumber, itm.Number, itm.FNo, (itm.DbAmount > 0), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);  //itm.AccName1,  
                    }
                }
                MyOver[0].Bal = OpenBal;
                //MyOver.Add(new vJv { FType = 999, FDate = String.Format("{0:dd/MM/yyyy}", vDate2), Bal = bal });
                MyOver.Add(new vJv { FType = 999, FDate = String.Format("{0:dd/MM/yyyy}", (ChkPeriod.Checked ? vDate2 : DateTime.Parse(txtEDate.Text))), Bal = bal });


                if (!ChkPeriod.Checked) MyOver.RemoveAll(p => DateTime.Parse(p.FDate) < DateTime.Parse(txtFDate.Text));
                grdCodes.DataSource = MyOver;
                grdCodes.DataBind();
                MyOver = (List<vJv>)grdCodes.DataSource;
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

        public string GetName(vJv myJv)
        {
            string Result = "";
            int i = 0;
            bool Db = (myJv.DbAmount>0);

            foreach(vJv itm in (from sitm in (List<vJv>)(Cache["MyJv"])
                                where sitm.Branch == myJv.Branch && sitm.FType == myJv.FType && sitm.LocType == myJv.LocType && sitm.LocNumber == myJv.LocType && sitm.Number == myJv.Number
                                orderby sitm.FNo
                                 select sitm).ToList())
            {
                if (itm.FNo != myJv.FNo && ((itm.DbCode!="" && !(Db) || (itm.CrCode!="" && Db))))
                {                   
                    Result = itm.AccName1;
                    i++;
                    if (i > 1) break;
                }
            }
            if (i > 1)
            {
                if(!Db) Result = "من مذكورين ";
                else Result = "الى مذكورين ";
            }
            return Result;
        }



        public void CheckInv(vJv myJv)        
        {
            Invoice myInv = new Invoice();
            myInv.Branch = myJv.Branch;
            myInv.VouLoc = moh.MakeMask(myJv.LocNumber.ToString(), 5);
            myInv.VouNo = myJv.Number;
            myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myInv != null)
            {
                if (myInv.CashAmount == myInv.Amount)
                {
                    myJv.InvNo = "نقدي";
                }
                else
                {
                    Jv jv = new Jv();
                    jv.Branch = myJv.Branch;
                    jv.FType = 101; // سند قبض
                    jv.InvNo = myJv.LocNumber.ToString() + "/" + myJv.Number.ToString();

                    jv = jv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (jv != null)
                    {
                        myJv.InvNo = "سددت بسند " + jv.LocNumber.ToString() + "/" + jv.Number.ToString();
                    }
                    else
                    {
                        jv = new Jv();
                        jv.Branch = myJv.Branch;
                        jv.FType = 100; // قيد يومية
                        jv.InvNo = myJv.LocNumber.ToString() + "/" + myJv.Number.ToString();

                        jv = jv.findInvNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (jv != null)
                        {
                            myJv.InvNo = "سددت بقيد " + jv.LocNumber.ToString() + "/" + jv.Number.ToString();
                        }
                        else myJv.InvNo = "غير مسدده";
                    }
                }
            }
        }

        public void MakeSum()
        {
            try
            {
                if (grdCodes.FooterRow != null)
                {
                    Label lblTotalDbAmount = grdCodes.FooterRow.FindControl("lblTotalDbAmount") as Label;
                    Label lblTotalCrAmount = grdCodes.FooterRow.FindControl("lblTotalCrAmount") as Label;
                    if (lblTotalDbAmount != null)
                    {
                        lblTotalDbAmount.Text = string.Format("{0:N2}", MyOver.Sum(itm => itm.DbAmount));
                        TotalDbAmount = lblTotalDbAmount.Text;
                    }
                    if (lblTotalCrAmount != null)
                    {
                        lblTotalCrAmount.Text = string.Format("{0:N2}", MyOver.Sum(itm => itm.CrAmount));
                        TotalCrAmount = lblTotalCrAmount.Text;
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

        protected string UrlHelper(object FType, object Number, object LocNumber, object LocType)
        {
            switch ((short)FType)
            {
                case 100: return "~/WebJVou.aspx?AreaNo=" + AreaNo + "&StoreNo="+ StoreNo + "&FNum=" + Number.ToString() ;
                case 101: return LocType.ToString() == "1" ? "~/WebRVou12.aspx?FType=1&FNum=" + Number.ToString() + "&LocNumber=" + LocNumber.ToString() + "&LocType=" + LocType.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo :
                                                               "~/WebRVou1.aspx?FType=1&FNum=" + Number.ToString() + "&LocNumber=" + LocNumber.ToString() + "&LocType=" + LocType.ToString() + "&AreaNo=" + moh.MakeMask(LocNumber.ToString(),5) + "&StoreNo=" + StoreNo + "&Flag=0";
                case 102: return LocType.ToString() == "1" ? "~/WebPay12.aspx?FType=2&FNum=" + Number.ToString() + "&LocNumber=" + LocNumber.ToString() + "&LocType=" + LocType.ToString() + "&AreaNo=" + AreaNo + "&StoreNo=" + StoreNo :
                                                               "~/WebPay1.aspx?FType=2&FNum=" + Number.ToString() + "&LocNumber=" + LocNumber.ToString() + "&LocType=" + LocType.ToString() + "&AreaNo=" + moh.MakeMask(LocNumber.ToString(),5) + "&StoreNo=" + StoreNo + "&Flag=0";
                case 103: return "~/WebInvoice.aspx?FNum=" + Number.ToString() + "&AreaNo=" + moh.MakeMask(LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&Flag=0";
                case 104: return "~/WebCarMove.aspx?FNum=" + Number.ToString() + "&AreaNo=" + moh.MakeMask(LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&Flag=0";
                case 105: return "~/WebBankPay.aspx?FNum=" + Number.ToString() + "&AreaNo=" + moh.MakeMask(LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&Flag=" + (int.Parse(LocType.ToString())-1).ToString() ;
                case 106: return "~/WebBankTrans.aspx?FNum=" + Number.ToString() + "&AreaNo=" + moh.MakeMask(LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&Flag=" + (int.Parse(LocType.ToString()) - 1).ToString();
                case 107: return "~/WebShipment.aspx?Flag=0&FNum=" + Number.ToString() + "&AreaNo=" + moh.MakeMask(LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&Flag=0";
                case 108: return "~/WebLShipment.aspx?Flag=0&FNum=" + Number.ToString() + "&AreaNo=" + moh.MakeMask(LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&Flag=0";
                case 501: return "~/WebPurchaseInvoice.aspx?FNum=" + Number.ToString() + "&StoreNo=" + moh.MakeMask(LocNumber.ToString(), 5) + "&AreaNo=" + AreaNo + "&Flag=0";
                case 502: return "~/WebReturnPurchaseInvoice.aspx?FNum=" + Number.ToString() + "&StoreNo=" + moh.MakeMask(LocNumber.ToString(), 5) + "&AreaNo=" + AreaNo + "&Flag=0";
                case 701: return "~/WebIssueNote.aspx?FNum=" + Number.ToString() + "&StoreNo=" + moh.MakeMask(LocNumber.ToString(), 5) + "&AreaNo=" + AreaNo + "&Flag=0";
                case 801: return "~/WebFastRepair.aspx?FNum=" + Number.ToString() + "&AreaNo=" + moh.MakeMask(LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&FMode=0&Flag=0" + (LocType.ToString() == "3"?"&FType=1":"");
                case 802: return "~/WebPettyCash.aspx?FNum=" + Number.ToString() + "&AreaNo=" + moh.MakeMask(LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&FMode=0&Flag=0" + (LocType.ToString() == "3" ? "&FType=1" : "");
                default: return "";
            }
        }

        protected void BtnPrint1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), -50, -50, 80, 50);
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
                bool vZerobal = false;
                if (ChkPeriod.Checked) page.vSubTitle = "جميع الفترات";
                else page.vSubTitle = "من " + txtFDate.Text + " إلى " + txtEDate.Text;
                if (ddlArea.SelectedIndex > 0)
                {
                    page.vStr1 = ddlArea.SelectedItem.Text;
                    vZerobal = true;
                }
                else page.vStr1 = "جميع المناطق";
                if (ddlCostCenter.SelectedIndex > 0)
                {
                    page.vStr2 = ddlCostCenter.SelectedItem.Text;
                    vZerobal = true;
                }
                else page.vStr2 = "جميع الفروع";
                if (ddlProject.SelectedIndex > 0)
                {
                    page.vStr3 = ddlProject.SelectedItem.Text;
                    vZerobal = true;
                }
                else page.vStr3 = "جميع المشاريع";
                if (ddlCostAcc.SelectedIndex > 0)
                {
                    page.vStr4 = ddlCostAcc.SelectedItem.Text;
                    vZerobal = true;
                }
                else page.vStr4 = "جميع التكاليف";
                if (ddlEmp.SelectedIndex > 0)
                {
                    page.vStr5 = ddlEmp.SelectedItem.Text;
                    vZerobal = true;
                }
                else page.vStr5 = "جميع الموظفين";

                if (ddlCostCenter.SelectedIndex > 0)
                {
                    page.vStr7 = ddlCostCenter.SelectedItem.Text;
                    vZerobal = true;
                }
                else page.vStr7 = "لا يوجد";
                if (ddlCars.SelectedIndex > 0)
                {
                    page.vStr8 = ddlCars.SelectedItem.Text;
                    vZerobal = true;
                }
                else page.vStr8 = "لا يوجد";
                page.PageNo = "1";
                page.UserName = Session["FullUser"].ToString();
                page.DispHeader = true;
                pw.PageEvent = page;
                

                if (ChkDetailsPrint.Checked)
                {
                    if (txtCode.Text.Length < 9)
                    {
                        bool vStart = false;
                        Acc myacc = new Acc();
                        myacc.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["AllACC" + Session["CNN2"].ToString()] == null) Cache.Insert("AllACC" + Session["CNN2"].ToString(), myacc.Getall(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        List<Acc> lacc = new List<Acc>();
                        lacc = (from myitm in (List<Acc>)(Cache["AllACC" + Session["CNN2"].ToString()])
                                where myitm.FLevel == 5 && myitm.Code.StartsWith(txtCode.Text)
                                select myitm).ToList();
                        if (lacc.Count() > 0) page.vStr6 = lacc[0].Code + " " + lacc[0].Name1;
                        document.Open();
                        foreach (Acc sitm in lacc)
                        {

                            double OpenBal = 0;
                            OpenBal = (double)(sitm.ODAcc - sitm.OCAcc);
                            if (vZerobal) OpenBal = 0;
                            List<vJv> vOver = new List<vJv>();
                            Jv myJv = new Jv();
                            double bal = 0;
                            DateTime vDate = DateTime.Parse(ChkPeriod.Checked ? "01/01/2012" : txtFDate.Text);
                            DateTime vDate2 = DateTime.Parse(ChkPeriod.Checked ? "01/01/2012" : txtFDate.Text);                            
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            vOver = myJv.GetStatement(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, ChkPeriod.Checked, txtFDate.Text, txtEDate.Text, sitm.Code, ddlArea.SelectedValue, ddlCostCenter.SelectedValue, ddlProject.SelectedValue, ddlCostAcc.SelectedValue, ddlEmp.SelectedValue, ddlCenter.SelectedValue, ddlCars.SelectedValue);
                            vOver.Insert(0, new vJv { FType = 0, FDate = ChkPeriod.Checked ? "01/01/2012" : txtFDate.Text, Bal = OpenBal });
                            if (!ChkPeriod.Checked && txtFDate.Text.StartsWith("01/01"))
                            {

                            }
                            else bal = OpenBal;
                            if (vZerobal)
                            {
                                OpenBal = 0;
                                bal = 0;
                            }

                            bool vFound = false;
                            foreach (vJv itm in vOver)
                            {
                                if (itm.FType == 100 && itm.InvNo == "OPEN" && itm.FDate == txtFDate.Text)
                                {

                                    vFound = true; 
                                    vDate = DateTime.Parse(itm.FDate);
                                    OpenBal = itm.DbAmount - itm.CrAmount;
                                    bal = OpenBal;
                                    vOver.Remove(itm);
                                    break;
                                }
                            }
                            if (vFound && !ChkPeriod.Checked) vOver.RemoveAll(p => DateTime.Parse(p.FDate) < vDate);

                            foreach (vJv itm in vOver)
                            {
                                if (vDate > DateTime.Parse(itm.FDate))
                                {
                                    OpenBal = OpenBal + itm.DbAmount - itm.CrAmount;
                                    if (vZerobal) OpenBal = 0;
                                }
                                else
                                {
                                    vDate2 = DateTime.Parse(itm.FDate);
                                    bal = bal + itm.DbAmount - itm.CrAmount;
                                }
                                itm.Bal = bal;
                                //if (Cache["MyJv"] != null) itm.AccName1 = GetName(itm);
                                if (this.ChkPeriod.Checked || DateTime.Parse(itm.FDate) >= DateTime.Parse(txtFDate.Text))
                                {
                                    if (itm.RecCount > 2) itm.AccName1 = (itm.DbAmount > 0 ? "إلى مذكورين" : "من مذكورين");
                                    else itm.AccName1 = myJv.GetAccName(itm.Branch, itm.FType, itm.LocType, itm.LocNumber, itm.Number, itm.FNo, (itm.DbAmount > 0), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);  //itm.AccName1,  
                                }
                            }
                            vOver[0].Bal = OpenBal;
                            vOver.Add(new vJv { FType = 999, FDate = String.Format("{0:dd/MM/yyyy}", (ChkPeriod.Checked ? vDate2 : DateTime.Parse(txtEDate.Text))), Bal = bal });
                            if (!ChkPeriod.Checked) vOver.RemoveAll(p => DateTime.Parse(p.FDate) < DateTime.Parse(txtFDate.Text));
                            page.vStr6 = sitm.Code + " " + sitm.Name1;
                            if (vStart)
                            {
                                page.DispHeader = true;
                                document.NewPage();                                
                            }
                            vStart = true;
                            PrintAcc(vOver, document);
                        }
                    }
                    else
                    {
                        page.vStr6 = txtCode.Text + " " + txtName.Text;
                        document.Open();
                        PrintAcc(MyOver, document);
                    }
                }
                else
                {
                    page.vStr6 = txtCode.Text + " " + txtName.Text;
                    document.Open();
                    PrintAcc(MyOver, document);
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


        public void PrintAcc(List<vJv> MyOver2, iTextSharp.text.Document document)
        {
            //PdfPTable table = new PdfPTable(grdCodes.HeaderRow.Cells.Count);
            PdfPTable table = new PdfPTable(8);
            float[] colWidths = { 200, 500, 120, 120, 100, 120, 100, 120 };
            table.SetWidths(colWidths);
            PdfPCell cell = new PdfPCell();
            cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
            table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

            string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
            BaseFont nationalBase;
            nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);
            double TotDB = 0, TotCR = 0;
            foreach (vJv itm in MyOver2)
            {
                cell.Phrase = new iTextSharp.text.Phrase(itm.FType2, nationalTextFont);
                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(itm.LocType == 2 ? itm.Number.ToString() + "/" + itm.LocNumber.ToString() : itm.Number.ToString(), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(itm.FDate, nationalTextFont);
                table.AddCell(cell);

                //cell.Phrase = new iTextSharp.text.Phrase(itm.Code, nationalTextFont);
                //table.AddCell(cell);


                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.DbAmount), nationalTextFont);
                table.AddCell(cell);
                TotDB += itm.DbAmount;

                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.CrAmount), nationalTextFont);
                table.AddCell(cell);
                TotCR += itm.CrAmount;

                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Bal), nationalTextFont);
                table.AddCell(cell);


                cell.Phrase = new iTextSharp.text.Phrase(itm.AccName1 + "\n" + itm.Remark, nationalTextFont);
                table.AddCell(cell);


                //cell.Phrase = new iTextSharp.text.Phrase(itm.InvNo.ToString(), nationalTextFont);
                //table.AddCell(cell);


                PdfPTable headerTbl3 = new PdfPTable(1);
                headerTbl3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl3.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                PdfPCell cell30 = new PdfPCell(headerTbl3);
                cell30.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell30.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell30.PaddingRight = 0;
                PdfPCell cell20 = new PdfPCell();
                //cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell20.Phrase = new iTextSharp.text.Phrase(itm.AreaName1, nationalTextFont);
                cell20.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell20.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell20.Border = 0;
                headerTbl3.AddCell(cell20);
                cell20.Phrase = new iTextSharp.text.Phrase(itm.CostName1, nationalTextFont);
                headerTbl3.AddCell(cell20);
                cell20.Phrase = new iTextSharp.text.Phrase(itm.ProjectName1, nationalTextFont);
                headerTbl3.AddCell(cell20);
                cell20.Phrase = new iTextSharp.text.Phrase(itm.CostAccName1, nationalTextFont);
                headerTbl3.AddCell(cell20);
                cell20.Phrase = new iTextSharp.text.Phrase(itm.CarType, nationalTextFont);
                headerTbl3.AddCell(cell20);
                //cell20.Phrase = new iTextSharp.text.Phrase(itm.Emp, nationalTextFont);
                //headerTbl3.AddCell(cell20);
                table.AddCell(cell30);
            }
            cell.Phrase = new iTextSharp.text.Phrase("الاجمالي", nationalTextFont);
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            table.AddCell(cell);

            cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
            table.AddCell(cell);

            cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
            table.AddCell(cell);

            //cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
            //table.AddCell(cell);


            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", TotDB), nationalTextFont);
            table.AddCell(cell);

            cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", TotCR), nationalTextFont);
            table.AddCell(cell);

            cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
            table.AddCell(cell);

            cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
            table.AddCell(cell);

            cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
            table.AddCell(cell);

            cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
            table.AddCell(cell);

            //cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
            //table.AddCell(cell);

            document.Add(table);

            document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));

            var cols5 = new[] { 200, 200, 400, 200, 200 };
            PdfPCell cell5 = new PdfPCell();
            cell5.ArabicOptions = ColumnText.DIGITS_EN2AN;
            PdfPTable table50 = new PdfPTable(5);
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

            cell5.Phrase = new iTextSharp.text.Phrase("المحاسب", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            cell5.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell.Border = 0;
            table50.AddCell(cell5);

            cell5.Phrase = new iTextSharp.text.Phrase("رئيس الحسابات", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
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

            cell5.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
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

            cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
            cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            cell5.Border = 0;
            table50.AddCell(cell5);

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

            document.Add(table50);
        }

        // *************************************************** ITextSharp ****************************************************************
        public class pdfPage : iTextSharp.text.pdf.PdfPageEventHelper
        {
            public string UserName, PageNo, vSubTitle, vCompanyName;
            public string vStr1, vStr2, vStr3, vStr4, vStr5,vStr6,vStr7,vStr8;
            public bool DispHeader;
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
                iTextSharp.text.Font nationalTextFont18 = new iTextSharp.text.Font(nationalBase, 16f, iTextSharp.text.Font.NORMAL);

                //I use a PdfPtable with 1 column to position my header where I want it
                PdfPTable headerTbl = new PdfPTable(3);
                var cols2 = new[] { 225, 300, 225 };
                headerTbl.SetWidths(cols2);

                headerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                //set the width of the table to be the same as the document
                headerTbl.TotalWidth = doc.PageSize.Width;
                string vStr = "الإدارة المالية";

                PdfPCell cell2 = new PdfPCell();
                cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell2.Border = 0;
                cell2.PaddingRight = 15;
                cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell2.Phrase = new iTextSharp.text.Phrase(vCompanyName + "\n" + vStr, nationalTextFont18);
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                headerTbl.AddCell(cell2);

                cell2.PaddingRight = 0;
                cell2.Phrase = new iTextSharp.text.Phrase("كشف حساب تفصيلي", nationalTextFont18);
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

                //arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";                    
                //BaseFont nationalBase;
                //nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                //nationalTextFont = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);
                //nationalTextFont18 = new iTextSharp.text.Font(nationalBase, 18f, iTextSharp.text.Font.NORMAL);

                if (DispHeader)
                {
                    PdfPTable table0 = new PdfPTable(6);
                    float[] colWidths0 = { 230, 140, 250, 120, 250, 120 };
                    table0.SetWidths(colWidths0);
                    PdfPCell cell0 = new PdfPCell();
                    cell0.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    table0.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    cell0.Phrase = new iTextSharp.text.Phrase("الفترة", nationalTextFont);
                    cell0.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table0.AddCell(cell0);

                    cell0.Phrase = new iTextSharp.text.Phrase(vSubTitle, nationalTextFont);
                    cell0.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table0.AddCell(cell0);

                    cell0.Phrase = new iTextSharp.text.Phrase("الحساب", nationalTextFont);
                    cell0.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table0.AddCell(cell0);

                    cell0.Phrase = new iTextSharp.text.Phrase(vStr6, nationalTextFont);
                    cell0.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table0.AddCell(cell0);

                    cell0.Phrase = new iTextSharp.text.Phrase("المنطقة", nationalTextFont);
                    cell0.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table0.AddCell(cell0);

                    cell0.Phrase = new iTextSharp.text.Phrase(vStr1, nationalTextFont);
                    cell0.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table0.AddCell(cell0);
                    //
                    cell0.Phrase = new iTextSharp.text.Phrase("الفرع", nationalTextFont);
                    cell0.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table0.AddCell(cell0);

                    cell0.Phrase = new iTextSharp.text.Phrase(vStr2, nationalTextFont);
                    cell0.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table0.AddCell(cell0);

                    cell0.Phrase = new iTextSharp.text.Phrase("المشروع", nationalTextFont);
                    cell0.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table0.AddCell(cell0);

                    cell0.Phrase = new iTextSharp.text.Phrase(vStr3, nationalTextFont);
                    cell0.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table0.AddCell(cell0);

                    cell0.Phrase = new iTextSharp.text.Phrase("حساب التكاليف", nationalTextFont);
                    cell0.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table0.AddCell(cell0);

                    cell0.Phrase = new iTextSharp.text.Phrase(vStr4, nationalTextFont);
                    cell0.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table0.AddCell(cell0);
                    //
                    cell0.Phrase = new iTextSharp.text.Phrase("الموظف", nationalTextFont);
                    cell0.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table0.AddCell(cell0);

                    cell0.Phrase = new iTextSharp.text.Phrase(vStr5, nationalTextFont);
                    cell0.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table0.AddCell(cell0);

                    cell0.Phrase = new iTextSharp.text.Phrase("مركز الحسابات", nationalTextFont);
                    cell0.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table0.AddCell(cell0);

                    cell0.Phrase = new iTextSharp.text.Phrase(vStr7, nationalTextFont);
                    cell0.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table0.AddCell(cell0);

                    cell0.Phrase = new iTextSharp.text.Phrase("الشاحنة", nationalTextFont);
                    cell0.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table0.AddCell(cell0);

                    cell0.Phrase = new iTextSharp.text.Phrase(vStr8, nationalTextFont);
                    cell0.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table0.AddCell(cell0);

                    doc.Add(table0);
                    doc.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));

                    //DispHeader = false;
                }

                PdfPTable table = new PdfPTable(8);
                float[] colWidths = { 200, 500, 120, 120, 100, 120, 100, 120 };
                table.SetWidths(colWidths);
                PdfPCell cell = new PdfPCell();
                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                cell.Phrase = new iTextSharp.text.Phrase("نوع القيد", nationalTextFont);
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("رقم القيد", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("التاريخ", nationalTextFont);
                table.AddCell(cell);

                //cell.Phrase = new iTextSharp.text.Phrase("رقم الحساب", nationalTextFont);
                //table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("مدين", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("دائن", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("الرصيد", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("أسم الحساب/شرح القيد", nationalTextFont);
                table.AddCell(cell);

                //cell.Phrase = new iTextSharp.text.Phrase("المستند", nationalTextFont);
                //table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("التوجيه", nationalTextFont);
                table.AddCell(cell);


                headerTbl.WriteSelectedRows(0, -1, -1, (doc.PageSize.Height - 20), writer.DirectContent);
                doc.Add(table);
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

            //for (int i = 0; i < CardsDataGridView.Rows.Count; i++)
            //{
            //    GridViewRow row = CardsDataGridView.Rows[i];

            //    //Change Color back to white
            //    row.BackColor = System.Drawing.Color.White;

            //    //Apply text style to each Row
            //    row.Attributes.Add("class", "textmode");

            //    //Apply style to Individual Cells of Alternating Row
            //    if (i % 2 != 0)
            //    {
            //        row.Cells[0].Style.Add("background-color", "#C2D69B");
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

        protected void ChkPeriod_CheckedChanged(object sender, EventArgs e)
        {
            LblFDate.Visible = !ChkPeriod.Checked;
            LblEDate.Visible = !ChkPeriod.Checked;
            txtFDate.Visible = !ChkPeriod.Checked;
            txtEDate.Visible = !ChkPeriod.Checked;

            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void BtnProcess_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (!ChkPeriod.Checked)
                {
                    if (txtFDate.Text == "")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب إدخال التاريخ";
                        txtFDate.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }
                    if (txtEDate.Text == "")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب إدخال التاريخ";
                        txtEDate.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }
                }


                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                {
                    Transactions UserTran = new Transactions();
                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                    UserTran.UserName = Session["CurrentUser"].ToString();
                    UserTran.FormName = "كشف حساب";
                    UserTran.FormAction = "اختيار";
                    UserTran.Description = "اختيار عرض كشف حساب تفصيلي للحساب " + txtName.Text + " - " + txtFDate.Text + " - " + txtEDate.Text;
                    UserTran.IP = IPNetworking.GetIP4Address();
                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                }

                TblUsers ax = new TblUsers();
                if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                if (!moh.CheckUserAccount(Session["CurrentUser"].ToString(), txtCode.Text, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, (from useritm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                                                                                                                                                                   where useritm.UserName == Session["CurrentUser"].ToString()
                                                                                                                                                                                   select useritm).FirstOrDefault()))
                {
                  // if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "كشف حساب", "تجاوز صلاحيات", "قد حاول المستخدم تجاوز صلاحياتة بعرض بيانات الحساب رقم " + txtCode.Text , "" , IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                   Response.Redirect("WebNotPrev.aspx", false);
                   return; 
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

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void ddlCostCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void ddlCostAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void ddlEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void ddlCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void ddlCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void txtCode_TextChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void txtName_TextChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void txtFDate_TextChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void txtEDate_TextChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void BtnRefresh_Click(object sender, EventArgs e)
        {
            Jv VJV = new Jv();
            VJV.Branch = short.Parse(Session["Branch"].ToString());
            if (Cache["MyJv"] != null) Cache.Remove("MyJv");
            Cache.Insert("MyJv", VJV.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, true, "", ""));
        }

    }
}