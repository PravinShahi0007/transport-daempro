using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class WebCheckList : System.Web.UI.Page
    {
        public string AreaNo
        {
            get
            {
                if (ViewState["AreaNo"] == null)
                {
                    ViewState["AreaNo"] = "1";
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
        public string VouType
        {
            get
            {
                if (ViewState["VouType"] == null)
                {
                    ViewState["VouType"] = "1";
                }
                return ViewState["VouType"].ToString();
            }
            set { ViewState["VouType"] = value; }
        }
        public void EditMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            BtnEdit.Visible = true;     // && (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass182;
            BtnNew.Visible = false;
            BtnDelete.Visible = true;       // && (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass183;
        }

        public void NewMode()
        {
            txtVouNo.ReadOnly = false;
            txtVouNo.BackColor = System.Drawing.Color.White;

            BtnEdit.Visible = false;
            BtnNew.Visible = true;      // && (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass181;
            BtnDelete.Visible = false;
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
                    this.Page.Header.Title = "Repair Request";
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

                    if (Request.QueryString["FType"] != null) VouType = Request.QueryString["FType"].ToString();

                    lblBranch.Text = "/" + StoreNo;

                    CarsType myCarsType = new CarsType();
                    myCarsType.Branch = short.Parse(Session["Branch"].ToString());
                    ddlVehType.DataTextField = "Name1";
                    ddlVehType.DataValueField = "Code";
                    ddlVehType.DataSource = myCarsType.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlVehType.DataBind();
                    ddlVehType.Items.Insert(0, new ListItem("--- Select Vehical Type ---", "-1", true));

                    ddlVehicle.Items.Insert(0, new ListItem("--- Select Vehical ---", "-1", true));
                    ddlJob.Items.Insert(0, new ListItem("--- Select Job Title ---", "-1", true));
                    ddlBranch.Items.Insert(0, new ListItem("--- Select Branch ---", "-1", true));

                    Drivers myDrive = new Drivers();
                    myDrive.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlDriver.DataTextField = "Name2";
                    ddlDriver.DataValueField = "Code";
                    ddlDriver.DataSource = (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()]);
                    ddlDriver.DataBind();
                    ddlDriver.Items.Insert(0, new ListItem("--- Select Driver ---", "-1", true));

                    AccProject myProject = new AccProject();
                    myProject.Branch = short.Parse(Session["Branch"].ToString());


                    //BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass181;
                    //BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass182;
                    //BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass183;
                    //BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass184;
                    //BtnFind.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass184;
                    if (VouType == "1" || VouType == "2")
                    {
                        ddlVehicle.Enabled = false;
                        ddlVehType.Enabled = false;
                        txtCarNo.ReadOnly = true;
                        txtModel.ReadOnly = true;
                        ddlDriver.Enabled = false;
                        if (VouType == "1")
                        {
                            Label2.Text = "Date - Time In ";
                        }
                        else
                        {
                            Label2.Text = "Date - Time Out ";
                        }
                    }
                    BtnClear_Click(sender, null);
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

        protected void BtnClear_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                NewMode();
                txtVouNo.Text = "";
                txtVouDate.Text = "";
                txtModel.Text = "";
                txtInTime.Text = "";
                txtInTime.Text = String.Format("{0:HH:mm:ss}", moh.Nows());  //moh.Nows().ToShortTimeString();
                txtCarNo.Text = "";
                ddlDriver.SelectedIndex = 0;
                ddlBranch.SelectedIndex = 0;
                ddlJob.SelectedIndex = 0;
                ddlVehicle.SelectedIndex = 0;
                ddlVehType.SelectedIndex = 0;
                txtACSNo.Text = "";
                txtACType.Text = "";
                txtEngineSNo.Text = "";
                txtEngineType.Text = "";
                txtGearSNo.Text = "";
                txtGearType.Text = "";
                txtIPSNo.Text = "";
                txtIPType.Text = "";
                txtModel.Text = "";
                txtRemark1.Text = "";
                txtRemark2.Text = "";
                txtRemark3.Text = "";
                txtRemark4.Text = "";
                txtRemark5.Text = "";
                txtRepairReqNo.Text = "";               
                txtItem01.Text = "";
                txtItem02.Text = "";
                txtItem03.Text = "";
                txtItem04.Text = "";
                txtItem05.Text = "";
                txtItem06.Text = "";
                txtItem07.Text = "";
                txtItem08.Text = "";
                txtItem09.Text = "";
                txtItem10.Text = "";
                txtItem11.Text = "";
                txtItem12.Text = "";
                txtItem13.Text = "";
                txtItem14.Text = "";
                txtItem15.Text = "";
                txtItem16.Text = "";
                txtItem17.Text = "";
                txtItem18.Text = "";
                txtItem19.Text = "";
                txtItem20.Text = "";
                txtItem21.Text = "";
                txtItem22.Text = "";
                txtItem23.Text = "";
                txtItem24.Text = "";
                txtItem25.Text = "";
                txtItem26.Text = "";
                txtItem27.Text = "";
                txtItem28.Text = "";
                txtItem29.Text = "";
                txtItem30.Text = "";

                txtSItem01.Text = "";
                txtSItem02.Text = "";
                txtSItem03.Text = "";
                txtSItem04.Text = "";
                txtSItem05.Text = "";
                txtSItem06.Text = "";
                txtSItem07.Text = "";
                txtSItem08.Text = "";
                txtSItem09.Text = "";
                txtSItem10.Text = "";
                txtSItem11.Text = "";
                txtSItem12.Text = "";
                txtSItem13.Text = "";
                txtSItem14.Text = "";
                txtSItem15.Text = "";
                txtSItem16.Text = "";
                txtSItem17.Text = "";
                txtSItem18.Text = "";
                txtSItem19.Text = "";
                txtSItem20.Text = "";
                txtSItem21.Text = "";
                txtSItem22.Text = "";
                txtSItem23.Text = "";
                txtSItem24.Text = "";
                txtSItem25.Text = "";
                txtSItem26.Text = "";
                txtSItem27.Text = "";
                txtSItem28.Text = "";
                txtSItem29.Text = "";
                txtSItem30.Text = "";


                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                if (sender != null)
                {
                    CheckList myJv = new CheckList();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.VouType = short.Parse(VouType);
                    myJv.VouLoc = short.Parse(StoreNo);
                    int? i = myJv.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (i == 0 || i == null)
                    {
                        i = 1;
                    }
                    else
                    {
                        i++;
                    }
                    txtVouNo.Text = i.ToString();
                }
                txtVouDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    txtVouNo.Text = txtVouNo.Text.Trim();
                    CheckList myacc = new CheckList();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.VouType = short.Parse(VouType);
                    myacc.VouLoc = short.Parse(StoreNo);
                    myacc.VouNo = int.Parse(txtVouNo.Text);
                    myacc = myacc.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc == null)
                    {
                        myacc = new CheckList();
                        myacc.Branch = short.Parse(Session["Branch"].ToString());
                        myacc.VouLoc = short.Parse(StoreNo);
                        myacc.VouNo = int.Parse(txtVouNo.Text);
                        myacc.VouType = short.Parse(VouType);
                        PutItem(myacc);
                        if (myacc.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "Saving Data Successfully Done";
                            BtnClear_Click(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "Error During Saving Data ... Try Again";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "Duplicate Repair Request No.";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }

                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        public void PutItem(CheckList myacc)
        {
            myacc.InTime = txtInTime.Text;            
            myacc.Vechicle = ddlVehicle.SelectedValue;
            myacc.DriverCode = ddlDriver.SelectedValue;
            myacc.Job = ddlJob.SelectedValue;
            myacc.VehType = int.Parse(ddlVehType.SelectedValue);
            myacc.VouDate = txtVouDate.Text;
            myacc.ACSNo = txtACSNo.Text;
            myacc.ACType = txtACType.Text;
            myacc.EngineSNo = txtEngineSNo.Text;
            myacc.EngineType = txtEngineType.Text;
            myacc.GearSNo = txtGearSNo.Text;
            myacc.GearType = txtGearType.Text;
            myacc.IPSNo = txtIPSNo.Text;
            myacc.IPType = txtIPType.Text;
            myacc.Remark1 = txtRemark1.Text;
            myacc.Remark2 = txtRemark2.Text;
            myacc.Remark3 = txtRemark3.Text;
            myacc.Remark4 = txtRemark4.Text;
            myacc.Remark5 = txtRemark5.Text;
            myacc.RepaiReqLoc = short.Parse(StoreNo);
            myacc.RepairReqNo = int.Parse(txtRepairReqNo.Text);
            myacc.Item01 = txtItem01.Text;
            myacc.Item02 = txtItem02.Text;
            myacc.Item03 = txtItem03.Text;
            myacc.Item04 = txtItem04.Text;
            myacc.Item05 = txtItem05.Text;
            myacc.Item06 = txtItem06.Text;
            myacc.Item07 = txtItem07.Text;
            myacc.Item08 = txtItem08.Text;
            myacc.Item09 = txtItem09.Text;
            myacc.Item10 = txtItem10.Text;
            myacc.Item11 = txtItem11.Text;
            myacc.Item12 = txtItem12.Text;
            myacc.Item13 = txtItem13.Text;
            myacc.Item14 = txtItem14.Text;
            myacc.Item15 = txtItem15.Text;
            myacc.Item16 = txtItem16.Text;
            myacc.Item17 = txtItem17.Text;
            myacc.Item18 = txtItem18.Text;
            myacc.Item19 = txtItem19.Text;
            myacc.Item20 = txtItem20.Text;
            myacc.Item21 = txtItem21.Text;
            myacc.Item22 = txtItem22.Text;
            myacc.Item23 = txtItem23.Text;
            myacc.Item24 = txtItem24.Text;
            myacc.Item25 = txtItem25.Text;
            myacc.Item26 = txtItem26.Text;
            myacc.Item27 = txtItem27.Text;
            myacc.Item28 = txtItem28.Text;
            myacc.Item29 = txtItem29.Text;
            myacc.Item30 = txtItem30.Text;
            myacc.SItem01 = txtSItem01.Text;
            myacc.SItem02 = txtSItem02.Text;
            myacc.SItem03 = txtSItem03.Text;
            myacc.SItem04 = txtSItem04.Text;
            myacc.SItem05 = txtSItem05.Text;
            myacc.SItem06 = txtSItem06.Text;
            myacc.SItem07 = txtSItem07.Text;
            myacc.SItem08 = txtSItem08.Text;
            myacc.SItem09 = txtSItem09.Text;
            myacc.SItem10 = txtSItem10.Text;
            myacc.SItem11 = txtSItem11.Text;
            myacc.SItem12 = txtSItem12.Text;
            myacc.SItem13 = txtSItem13.Text;
            myacc.SItem14 = txtSItem14.Text;
            myacc.SItem15 = txtSItem15.Text;
            myacc.SItem16 = txtSItem16.Text;
            myacc.SItem17 = txtSItem17.Text;
            myacc.SItem18 = txtSItem18.Text;
            myacc.SItem19 = txtSItem19.Text;
            myacc.SItem20 = txtSItem20.Text;
            myacc.SItem21 = txtSItem21.Text;
            myacc.SItem22 = txtSItem22.Text;
            myacc.SItem23 = txtSItem23.Text;
            myacc.SItem24 = txtSItem24.Text;
            myacc.SItem25 = txtSItem25.Text;
            myacc.SItem26 = txtSItem26.Text;
            myacc.SItem27 = txtSItem27.Text;
            myacc.SItem28 = txtSItem28.Text;
            myacc.SItem29 = txtSItem29.Text;
            myacc.SItem30 = txtSItem30.Text; 
            myacc.UserName = txtUserName.ToolTip;
            myacc.UserDate = txtUserDate.Text;
            myacc.Branch2 = ddlBranch.SelectedValue;
            myacc.Job = ddlJob.SelectedValue;
        }

        public void GetItem(CheckList myacc)
        {
            txtInTime.Text = myacc.InTime;
            ddlVehType.SelectedValue = myacc.VehType.ToString();
            ddlVehType_SelectedIndexChanged(ddlVehType, null);
            // Check Type
            ddlVehicle.SelectedValue = myacc.Vechicle;
            txtCarNo.Text = myacc.Vechicle;
            ddlDriver.SelectedValue = myacc.DriverCode;

            Cars myInv = new Cars();
            myInv.Branch = short.Parse(Session["Branch"].ToString());
            if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myInv.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            myInv.Code = ddlVehicle.SelectedValue;
            myInv.CarsType = int.Parse(ddlVehType.SelectedValue);
            myInv = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                     where sitm.Code == myInv.Code
                     select sitm).FirstOrDefault();
            if (myInv != null)
            {
                txtModel.Text = myInv.Model;
            }                        

            ddlJob.SelectedValue = myacc.Job;
            txtVouDate.Text = myacc.VouDate;
            txtACSNo.Text = myacc.ACSNo;
            txtACType.Text = myacc.ACType;
            txtEngineSNo.Text = myacc.EngineSNo;
            txtEngineType.Text = myacc.EngineType;
            txtGearSNo.Text = myacc.GearSNo;
            txtGearType.Text = myacc.GearType;
            txtIPSNo.Text = myacc.IPSNo;
            txtIPType.Text = myacc.IPType;
            txtRemark1.Text = myacc.Remark1;
            txtRemark2.Text = myacc.Remark2;
            txtRemark3.Text = myacc.Remark3;
            txtRemark4.Text = myacc.Remark4;
            txtRemark5.Text = myacc.Remark5;
            txtRepairReqNo.Text = myacc.RepairReqNo.ToString();
            txtItem01.Text = myacc.Item01;
            txtItem02.Text = myacc.Item02;
            txtItem03.Text = myacc.Item03;
            txtItem04.Text = myacc.Item04;
            txtItem05.Text = myacc.Item05;
            txtItem06.Text = myacc.Item06;
            txtItem07.Text = myacc.Item07;
            txtItem08.Text = myacc.Item08;
            txtItem09.Text = myacc.Item09;
            txtItem10.Text = myacc.Item10;
            txtItem11.Text = myacc.Item11;
            txtItem12.Text = myacc.Item12;
            txtItem13.Text = myacc.Item13;
            txtItem14.Text = myacc.Item14;
            txtItem15.Text = myacc.Item15;
            txtItem16.Text = myacc.Item16;
            txtItem17.Text = myacc.Item17;
            txtItem18.Text = myacc.Item18;
            txtItem19.Text = myacc.Item19;
            txtItem20.Text = myacc.Item20;
            txtItem21.Text = myacc.Item21;
            txtItem22.Text = myacc.Item22;
            txtItem23.Text = myacc.Item23;
            txtItem24.Text = myacc.Item24;
            txtItem25.Text = myacc.Item25;
            txtItem26.Text = myacc.Item26;
            txtItem27.Text = myacc.Item27;
            txtItem28.Text = myacc.Item28;
            txtItem29.Text = myacc.Item29;
            txtItem30.Text = myacc.Item30;
            txtSItem01.Text = myacc.SItem01;
            txtSItem02.Text = myacc.SItem02;
            txtSItem03.Text = myacc.SItem03;
            txtSItem04.Text = myacc.SItem04;
            txtSItem05.Text = myacc.SItem05;
            txtSItem06.Text = myacc.SItem06;
            txtSItem07.Text = myacc.SItem07;
            txtSItem08.Text = myacc.SItem08;
            txtSItem09.Text = myacc.SItem09;
            txtSItem10.Text = myacc.SItem10;
            txtSItem11.Text = myacc.SItem11;
            txtSItem12.Text = myacc.SItem12;
            txtSItem13.Text = myacc.SItem13;
            txtSItem14.Text = myacc.SItem14;
            txtSItem15.Text = myacc.SItem15;
            txtSItem16.Text = myacc.SItem16;
            txtSItem17.Text = myacc.SItem17;
            txtSItem18.Text = myacc.SItem18;
            txtSItem19.Text = myacc.SItem19;
            txtSItem20.Text = myacc.SItem20;
            txtSItem21.Text = myacc.SItem21;
            txtSItem22.Text = myacc.SItem22;
            txtSItem23.Text = myacc.SItem23;
            txtSItem24.Text = myacc.SItem24;
            txtSItem25.Text = myacc.SItem25;
            txtSItem26.Text = myacc.SItem26;
            txtSItem27.Text = myacc.SItem27;
            txtSItem28.Text = myacc.SItem28;
            txtSItem29.Text = myacc.SItem29;
            txtSItem30.Text = myacc.SItem30;
            ddlBranch.SelectedValue = myacc.Branch2;
            ddlJob.SelectedValue = myacc.Job;

            myacc.UserName = txtUserName.ToolTip;
            myacc.UserDate = txtUserDate.Text;
            TblUsers ax = new TblUsers();
            if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            ax.UserName = myacc.UserName;
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

        protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtVouNo.Text.Trim() != "")
                {
                    txtVouNo.Text = txtVouNo.Text.Trim();
                    CheckList myacc = new CheckList();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.VouType = short.Parse(VouType);
                    myacc.VouLoc = short.Parse(StoreNo);
                    myacc.VouNo = int.Parse(txtVouNo.Text);
                    myacc = myacc.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc != null)
                    {
                        EditMode();
                        GetItem(myacc);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "Check List No. Not Found";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "You Should Enter Check List No.";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    txtVouNo.Text = txtVouNo.Text.Trim();
                    CheckList myacc = new CheckList();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.VouType = short.Parse(VouType);
                    myacc.VouLoc = short.Parse(StoreNo);
                    myacc.VouNo = int.Parse(txtVouNo.Text);
                    myacc = myacc.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc != null)
                    {
                        PutItem(myacc);
                        if (myacc.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "Saving Data Successfully Done";
                            BtnClear_Click(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "Error During Saving Data ... Try Again";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "Check List No. Not Found";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void BtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtVouNo.Text.Trim() != "")
                {
                    txtVouNo.Text = txtVouNo.Text.Trim();
                    CheckList myacc = new CheckList();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.VouType = short.Parse(VouType);
                    myacc.VouLoc = short.Parse(StoreNo);
                    myacc.VouNo = int.Parse(txtVouNo.Text);
                    myacc = myacc.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc != null)
                    {
                        // Check for Delete Clients
                        if (myacc.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());  //moh.Nows().ToShortTimeString();
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.Description = "Delete Check List No. " + myacc.VouNo;
                            UserTran.FormAction = "Delete";
                            UserTran.FormName = "Check List";
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "Deleting Check List Successfully Done";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "Error During Deleting Check List ... Try Again";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "You Should Enter Check List No.";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void BtnFind_Click(object sender, ImageClickEventArgs e)
        {
            BtnSearch_Click(sender, e);
        }

        protected void BtnFind2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtRepairReqNo.Text.Trim() != "")
                {
                    txtRepairReqNo.Text = txtRepairReqNo.Text.Trim();
                    RepairReq myacc = new RepairReq();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.VouLoc = short.Parse(StoreNo);
                    myacc.VouNo = int.Parse(txtVouNo.Text);
                    myacc = myacc.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc != null)
                    {
                        txtCarNo.Text = myacc.Vehicle;
                        ddlDriver.SelectedValue = myacc.Driver;
                        ddlVehType.SelectedValue = myacc.VehType.ToString();
                        ddlVehType_SelectedIndexChanged(sender, e);
                        ddlVehicle.SelectedValue = myacc.Vehicle;

                        Cars myInv = new Cars();
                        myInv.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myInv.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myInv.Code = ddlVehicle.SelectedValue;
                        myInv.CarsType = int.Parse(ddlVehType.SelectedValue);
                        myInv = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                 where sitm.Code == myInv.Code
                                 select sitm).FirstOrDefault();
                        if (myInv != null)
                        {
                            txtModel.Text = myInv.Model;
                        }                        
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "Repair Request No. Not Found";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "You Should Enter Repair Request No.";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
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
                        myArch.LocNumber = short.Parse(StoreNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 908;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(StoreNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 908;
                        myArch.FileName = FileUpload1.FileName;
                        myArch.FileName2 = mySetting.ImagePath2 + FileName;
                        myArch.FNo = (short)i;
                        myArch.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        LoadAttachData();
                    }

                    //    LblCodesResult.Text = "File name: " + FileUpload1.PostedFile.FileName + "<br>" + FileUpload1.PostedFile.ContentLength + " kb<br>" + "Content type: " + FileUpload1.PostedFile.ContentType;
                }
                catch (Exception ex)
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "ERROR: " + ex.Message.ToString();
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
                myArch.LocNumber = short.Parse(StoreNo);
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = 908;
                myArch.FNo = short.Parse(FNo);
                myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                LoadAttachData();
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        public void LoadAttachData()
        {
            Arch myArch = new Arch();
            myArch.Branch = short.Parse(Session["Branch"].ToString());
            myArch.LocNumber = short.Parse(StoreNo);
            myArch.Number = int.Parse(txtVouNo.Text);
            myArch.DocType = 908;
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

        protected void ddlVehType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model1.Visible = (ddlVehType.SelectedIndex == 1);
            if (ddlVehType.SelectedIndex == 1)
            {
                lblItem01.Text = "License";
                lblItem16.Text = "T.M.R. & Tyre Cards";
                lblItem02.Text = "Transport Permit";
                lblItem17.Text = "Inj. Pump Seal";
                lblItem03.Text = "MVPI Document";
                lblItem18.Text = "R.P.M. Reading";
                lblItem04.Text = "Body & Cabinet";
                lblItem19.Text = "Oil Pressure";
                lblItem05.Text = "Side Doors";
                lblItem20.Text = "Batteries";
                lblItem06.Text = "Wind Shield";
                lblItem21.Text = "Fuel Tanks";
                lblItem07.Text = "Beds & Seats";
                lblItem22.Text = "Trailor Coupling";
                lblItem08.Text = "Cabinet Curtains";
                lblItem23.Text = "Trail Bumper, Lights";
                lblItem09.Text = "Side Mirrors";
                lblItem24.Text = "Front Bumper, Lights";
                lblItem10.Text = "Doors & Lgn. Keys";
                lblItem25.Text = "Air Condition Unit";
                lblItem11.Text = "Radio & Sterio";
                lblItem26.Text = "Trailer Air Cables";
                lblItem12.Text = "Fire Extinguisher";
                lblItem27.Text = "Trailer Elect. Cables";
                lblItem13.Text = "Early Warning A's";
                lblItem28.Text = "Tools & Jack";
                lblItem14.Text = "Other Accessories";
                lblItem29.Text = "Spare Tires";
                lblItem15.Text = "Plate Number 2 pcs.";
                lblItem30.Text = "Others";
            }
            else
            {
                lblItem01.Text = "License";
                lblItem16.Text = "Side Mirrors";
                lblItem02.Text = "MVPI Document";
                lblItem17.Text = "Internal Mirrors";
                lblItem03.Text = "Front Glass";
                lblItem18.Text = "Seats";
                lblItem04.Text = "Back Glass";
                lblItem19.Text = "AC Unit";
                lblItem05.Text = "Front Doors";
                lblItem20.Text = "Radio & Sterio";
                lblItem06.Text = "Back Doors";
                lblItem21.Text = "Spare Tires";
                lblItem07.Text = "Front Shield";
                lblItem22.Text = "Tools & Jack";
                lblItem08.Text = "Back Shield";
                lblItem23.Text = "Plates";
                lblItem09.Text = "Front Lights";
                lblItem24.Text = "K.M. Reading";
                lblItem10.Text = "Back Lights";
                lblItem25.Text = "Others";
                lblItem11.Text = "";
                lblItem26.Text = "";
                lblItem12.Text = "";
                lblItem27.Text = "";
                lblItem13.Text = "";
                lblItem28.Text = "";
                lblItem14.Text = "";
                lblItem29.Text = "";
                lblItem15.Text = "";
                lblItem30.Text = "";
            }

            Label6.Visible = !(ddlVehType.SelectedIndex == 1 || ddlVehType.SelectedIndex == 2);
            ddlBranch.Visible = !(ddlVehType.SelectedIndex == 1 || ddlVehType.SelectedIndex == 2);
            Label5.Visible = !(ddlVehType.SelectedIndex == 1 || ddlVehType.SelectedIndex == 2);
            ddlJob.Visible = !(ddlVehType.SelectedIndex == 1 || ddlVehType.SelectedIndex == 2);

            if (ddlVehType.SelectedIndex > 0)
            {
                Cars myacc = new Cars();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myacc.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myacc.CarsType = int.Parse(ddlVehType.SelectedValue);

                ddlVehicle.DataTextField = "Name";
                ddlVehicle.DataValueField = "Code";
                ddlVehicle.DataSource = (from itm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                         where itm.CarsType == myacc.CarsType && (bool)itm.Status
                                         select itm).ToList();
                ddlVehicle.DataBind();
                ddlVehicle.Items.Insert(0, new ListItem("--- Select Vehicle ---", "-1", true));
            }
            else
            {
                ddlVehicle.Items.Clear();
                ddlVehicle.Items.Insert(0, new ListItem("--- Select Vehicle ---", "-1", true));
            }

       }

    }
}