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
using System.Web.UI.HtmlControls;

namespace ACC
{
    public partial class WebRepairReq : System.Web.UI.Page
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
        public string vAreaNo
        {
            get
            {
                if (ViewState["vAreaNo"] == null)
                {
                    ViewState["vAreaNo"] = "00001";
                }
                return ViewState["vAreaNo"].ToString();
            }
            set { ViewState["vAreaNo"] = value; }
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
        public short LocType
        {
            get
            {
                if (ViewState["LocType"] == null)
                {
                    ViewState["LocType"] = 2;
                }
                return short.Parse(ViewState["LocType"].ToString());
            }
            set { ViewState["LocType"] = value; }
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
                    this.Page.Header.Title = GetLocalResourceObject("RepairReq").ToString();  // "Repair Request";
                    if (Request.QueryString["AreaNo"] != null) AreaNo = Request.QueryString["AreaNo"].ToString();
                    else
                    {
                        if (Session["AreaNo"] != null) AreaNo = Session["AreaNo"].ToString();
                    }
                    vAreaNo = AreaNo;

                    if (Request.QueryString["StoreNo"] != null) StoreNo = Request.QueryString["StoreNo"].ToString();
                    else
                    {
                        if (Session["StoreNo"] == null) Session["StoreNo"] = 1;
                        StoreNo = Session["StoreNo"].ToString();
                    }

                    if (Request.QueryString["FType"] != null)
                    {
                        LocType = 3;
                        vAreaNo = "00001";
                        lblBranch.Text = "/00" + short.Parse(vAreaNo).ToString();
                    }
                    else lblBranch.Text = "/" + short.Parse(vAreaNo).ToString();


                    CarsType myCarsType = new CarsType();
                    myCarsType.Branch = short.Parse(Session["Branch"].ToString());
                    ddlVehType.DataTextField = "Name1";
                    ddlVehType.DataValueField = "Code";
                    ddlVehType.DataSource = myCarsType.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlVehType.DataBind();
                    ddlVehType.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectVType").ToString(), "-1", true)); // "--- Select Vehical Type ---"

                    ddlVehicle.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectVeh2").ToString(), "-1", true));  // "--- Select Vehical ---"

                    Drivers myDrive = new Drivers();
                    myDrive.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlDriver.DataTextField = "Name2";
                    ddlDriver.DataValueField = "Code";
                    ddlDriver.DataSource = (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()]);
                    ddlDriver.DataBind();
                    ddlDriver.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectDriver2").ToString(), "-1", true));   // "--- Select Driver ---"

                    AccProject myProject = new AccProject();
                    myProject.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastProject" + Session["CNN2"].ToString()] == null) Cache.Insert("LastProject" + Session["CNN2"].ToString(), myProject.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlFrom2.DataTextField = "Name2";
                    ddlFrom2.DataValueField = "Code";
                    ddlFrom2.DataSource = (List<AccProject>)(Cache["LastProject" + Session["CNN2"].ToString()]);
                    ddlFrom2.DataBind();
                    ddlFrom2.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectDivision").ToString(), "-1", true));    // "--- Select Division ---"

                    //BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass181;
                    //BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass182;
                    //BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass183;
                    //BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass184;
                    //BtnFind.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass184;

                    if (Request.QueryString["FNum"] != null)
                    {
                        if (Request.QueryString["Flag"] != null)
                        {
                            if (Request.QueryString["Flag"].ToString() == "0")
                            {
                                BtnEdit.Visible = false;
                                BtnDelete.Visible = false;
                                BtnClear.Visible = false;
                                ((HtmlGenericControl)this.Master.FindControl("menu")).Visible = false;
                            }
                        }
                        txtVouNo.Text = Request.QueryString["FNum"].ToString();
                        BtnSearch_Click(sender, null);
                    }
                    else
                    {
                        BtnClear_Click(sender, null);
                    }
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
                //txtTimeOut.Text = "";               
                txtRequire.Text = "";
                txtRemark.Text = "";
                txtModel.Text = "";
                txtKMS.Text = "";
                txtInTime.Text = "";
                txtInTime.Text = String.Format("{0:HH:mm:ss}", moh.Nows());  //moh.Nows().ToShortTimeString();
                //txtDateOut.Text = "";
                txtCarNo.Text = "";
                this.lblStatus.Text = "";

                for (int i = 0; i < this.ChkRequire.Items.Count; i++)
                {
                    this.ChkRequire.Items[i].Selected = false;
                }

                ddlDriver.SelectedIndex = 0;
                ddlFrom2.SelectedIndex = 0;
                ddlVehicle.SelectedIndex = 0;
                ddlVehType.SelectedIndex = 0;

                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));

                if (sender != null)
                {
                    RepairReq myJv = new RepairReq();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.LocType = LocType;
                    myJv.VouLoc = short.Parse(vAreaNo);
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
                txtVouDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        public bool CheckCarJobWork(string CarNo)
        {
            JobWork jw = new JobWork();
            jw.CarNo = CarNo;
            jw = jw.GetOpenCarNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (jw != null)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يوجد للشاحنة امر تشغيل مفتوح حاليا في الصيانة برقم " + jw.VouNo.ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return true;
            }
            else return false;
        }

        public bool CheckCarRepairReq(string CarNo)
        {
            RepairReq Rr = new RepairReq();
            Rr.Vehicle = CarNo;
            Rr = Rr.GetVechNotJobWork(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (Rr != null)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يوجد للشاحنة طلب اصلاح حاليا برقم " + Rr.VouNo2.ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return true;
            }
            else return false;
        }

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (CheckCarJobWork(ddlVehicle.SelectedValue)) return;
                    if (CheckCarRepairReq(ddlVehicle.SelectedValue)) return;

                    txtVouNo.Text = txtVouNo.Text.Trim();
                    RepairReq myacc = new RepairReq();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.LocType = LocType;
                    myacc.VouLoc = short.Parse(vAreaNo);
                    myacc.VouNo = int.Parse(txtVouNo.Text);
                    myacc = myacc.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc == null)
                    {
                        if (txtKMS.Text.Trim() == "") txtKMS.Text = "0";
                        myacc = new RepairReq();
                        myacc.Branch = short.Parse(Session["Branch"].ToString());
                        myacc.LocType = LocType;
                        myacc.VouLoc = short.Parse(vAreaNo);
                        myacc.VouNo = int.Parse(txtVouNo.Text);
                        //myacc.DateOut = txtDateOut.Text;
                        myacc.Driver = ddlDriver.SelectedValue;
                        myacc.From2 = ddlFrom2.SelectedValue;
                        myacc.InTime = txtInTime.Text;
                        myacc.KMS = int.Parse(txtKMS.Text);
                        myacc.Remark = txtRemark.Text;
                        myacc.Require = txtRequire.Text;
                        myacc.Require0 = ChkRequire.Items[0].Selected;
                        myacc.Require1 = ChkRequire.Items[1].Selected;
                        myacc.Require2 = ChkRequire.Items[2].Selected;
                        myacc.Require3 = ChkRequire.Items[3].Selected;
                        myacc.Require4 = ChkRequire.Items[4].Selected;
                        myacc.Require5 = ChkRequire.Items[5].Selected;
                        //myacc.TimeOut = txtTimeOut.Text;
                        myacc.Vehicle = ddlVehicle.SelectedValue;
                        myacc.VehType = int.Parse(ddlVehType.SelectedValue);
                        myacc.VouDate = moh.CheckDate(txtVouDate.Text);
                        myacc.UserName = txtUserName.ToolTip;
                        myacc.UserDate = txtUserDate.Text;
                        if (myacc.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            updateCache();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = GetLocalResourceObject("SuccessSave").ToString();   //"Saving Data Successfully Done";
                            BtnClear_Click(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("ErrorSave").ToString();   //"Error During Saving Data ... Try Again";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("DuplicateReq").ToString();   // "Duplicate Repair Request No."
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

        protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtVouNo.Text.Trim() != "")
                {
                    txtVouNo.Text = txtVouNo.Text.Trim();
                    RepairReq myacc = new RepairReq();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.LocType = LocType;
                    myacc.VouLoc = short.Parse(vAreaNo);
                    myacc.VouNo = int.Parse(txtVouNo.Text);
                    myacc = myacc.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc != null)
                    {
                        EditMode();
                        txtCarNo.Text = myacc.Vehicle;
                        //txtDateOut.Text = myacc.DateOut;
                        txtInTime.Text = myacc.InTime;
                        txtKMS.Text = myacc.KMS.ToString();
                        txtRemark.Text = myacc.Remark;
                        txtRequire.Text = myacc.Require;
                        //txtTimeOut.Text = myacc.TimeOut;
                        txtVouDate.Text = myacc.VouDate;
                        txtVouNo.Text = myacc.VouNo.ToString();
                        ddlDriver.SelectedValue = myacc.Driver;
                        ddlFrom2.SelectedValue = myacc.From2;
                        ddlVehType.SelectedValue = myacc.VehType.ToString();
                        ddlVehType_SelectedIndexChanged(sender, e);
                        ddlVehicle.SelectedValue = myacc.Vehicle;
                        ChkRequire.Items[0].Selected = (bool)myacc.Require0;
                        ChkRequire.Items[1].Selected = (bool)myacc.Require1;
                        ChkRequire.Items[2].Selected = (bool)myacc.Require2;
                        ChkRequire.Items[3].Selected = (bool)myacc.Require3;
                        ChkRequire.Items[4].Selected = (bool)myacc.Require4;
                        ChkRequire.Items[5].Selected = (bool)myacc.Require5;
                        txtUserDate.Text = myacc.UserDate;

                        Cars myInv = new Cars();
                        myInv.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myInv.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myInv.Code = txtCarNo.Text;
                        myInv.CarsType = int.Parse(ddlVehType.SelectedValue);
                        myInv = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                 where sitm.Code == myInv.Code
                                 select sitm).FirstOrDefault();
                        if (myInv != null)
                        {
                            txtModel.Text = myInv.Model;
                        }

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
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("ReqNotFound").ToString();  // "Repair Request No. Not Found";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = GetLocalResourceObject("EnterReqNo").ToString();  // "You Should Enter Repair Request No.";
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
                    RepairReq myacc = new RepairReq();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.LocType = LocType;
                    myacc.VouLoc = short.Parse(vAreaNo);
                    myacc.VouNo = int.Parse(txtVouNo.Text);
                    myacc = myacc.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc != null)
                    {
                        //myacc.DateOut = txtDateOut.Text;
                        myacc.Driver = ddlDriver.SelectedValue;
                        myacc.From2 = ddlFrom2.SelectedValue;
                        myacc.InTime = txtInTime.Text;
                        myacc.KMS = int.Parse(txtKMS.Text);
                        myacc.Remark = txtRemark.Text;
                        myacc.Require = txtRequire.Text;
                        myacc.Require0 = ChkRequire.Items[0].Selected;
                        myacc.Require1 = ChkRequire.Items[1].Selected;
                        myacc.Require2 = ChkRequire.Items[2].Selected;
                        myacc.Require3 = ChkRequire.Items[3].Selected;
                        myacc.Require4 = ChkRequire.Items[4].Selected;
                        myacc.Require5 = ChkRequire.Items[5].Selected;
                        //myacc.TimeOut = txtTimeOut.Text;
                        myacc.Vehicle = ddlVehicle.SelectedValue;
                        myacc.VehType = int.Parse(ddlVehType.SelectedValue);
                        myacc.VouDate = moh.CheckDate(txtVouDate.Text);
                        myacc.UserName = txtUserName.ToolTip;
                        myacc.UserDate = txtUserDate.Text;

                        if (myacc.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            updateCache();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = GetLocalResourceObject("SuccessSave").ToString();  //"Saving Data Successfully Done";
                            BtnClear_Click(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("ErrorSave").ToString();   //"Error During Saving Data ... Try Again";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("ReqNotFound").ToString();  // "Repair Request No. Not Found";
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
                    RepairReq myacc = new RepairReq();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.LocType = LocType;
                    myacc.VouLoc = short.Parse(vAreaNo);
                    myacc.VouNo = int.Parse(txtVouNo.Text);
                    myacc = myacc.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc != null)
                    {
                        // Check for Delete Clients
                        if (myacc.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            updateCache();
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.Description = "Delete Repair Request No. " + myacc.VouNo;
                            UserTran.FormAction = "Delete";
                            UserTran.FormName = "Repair Request";
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = GetLocalResourceObject("SuccessDelete").ToString();  // "Deleting Repair Request Successfully Done";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("ErrorDelete").ToString();  // "Error During Deleting Repair Request ... Try Again";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = GetLocalResourceObject("EnterReqNo").ToString();  // "You Should Enter Repair Request No.";
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
                        myArch.LocNumber = short.Parse(vAreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = (LocType == 2 ? 907 : 908); 

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(vAreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = (LocType == 2 ? 907 : 908);
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
                LblCodesResult.Text = GetLocalResourceObject("SelectFile").ToString();  // "لم بتم اختيار الملف";
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
                myArch.LocNumber = short.Parse(vAreaNo);
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = (LocType == 2 ? 907 : 908); 
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
            myArch.LocNumber = short.Parse(vAreaNo);
            myArch.Number = int.Parse(txtVouNo.Text);
            myArch.DocType = (LocType == 2 ? 907 : 908);
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
                ddlVehicle.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectVeh2").ToString(), "-1", true));  // "--- Select Vehical ---"
            }
            else
            {
                ddlVehicle.Items.Clear();
                ddlVehicle.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectVeh2").ToString(), "-1", true));   // "--- Select Vehical ---"
            }
 
        }

        protected void BtnFind2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (this.txtCarNo.Text != "" && ddlVehType.SelectedIndex >0)
                {
                    txtCarNo.Text = moh.MakeMask(txtCarNo.Text, 5);
                    Cars myInv = new Cars();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myInv.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myInv.Code = txtCarNo.Text;
                    myInv.CarsType = int.Parse(ddlVehType.SelectedValue);
                    myInv = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                             where sitm.Code == myInv.Code
                             select sitm).FirstOrDefault();
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("CarNotFound").ToString();  // "Car No. Not Found";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    else
                    {
                        ddlVehicle.SelectedValue = myInv.Code;
                        ddlDriver.SelectedValue = myInv.DriverCode;
                        txtModel.Text = myInv.Model;

                        string vFound = "";
                        CarMove vCarMove = new CarMove();
                        foreach (CarMove itm in vCarMove.NotCarMoveRCV(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (itm.CarCode == myInv.Code)
                            {
                                vFound = int.Parse(itm.VouLoc).ToString() + "/" + itm.Number.ToString();
                                break;
                            }
                        }
                        if (vFound == "") lblStatus.Text = GetLocalResourceObject("NoLoad").ToString();  // "Without Load";
                        else lblStatus.Text = @"<a target='_blank' href='WebCarMove.aspx?Support=1&FNum=" + vFound.Split('/')[1] + "&AreaNo=" + moh.MakeMask(vFound.Split('/')[0], 5) + "&StoreNo=" + StoreNo + "&Flag=0'>" + GetLocalResourceObject("LoadNo").ToString() + " " + vFound + @"</a>";
                    }
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            } 
        }

        protected void ddlVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlVehType.SelectedIndex > 0)
                {
                    Cars myInv = new Cars();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myInv.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myInv.Code = ddlVehicle.SelectedValue;
                    myInv.CarsType = int.Parse(ddlVehType.SelectedValue);
                    myInv = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                             where sitm.Code == myInv.Code
                             select sitm).FirstOrDefault();
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("CarNotFound").ToString();  // "Car No. Not Found";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    else
                    {
                        txtCarNo.Text = myInv.Code;
                        ddlDriver.SelectedValue = myInv.DriverCode;
                        txtModel.Text = myInv.Model;

                        string vFound = "";
                        CarMove vCarMove = new CarMove();
                        foreach (CarMove itm in vCarMove.NotCarMoveRCV(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (itm.CarCode == myInv.Code)
                            {
                                vFound = int.Parse(itm.VouLoc).ToString() + "/" + itm.Number.ToString();
                                break;
                            }
                        }
                        if (vFound == "") lblStatus.Text = GetLocalResourceObject("NoLoad").ToString();  // "Without Load";
                        else lblStatus.Text = @"<a target='_blank' href='WebCarMove.aspx?Support=1&FNum=" + vFound.Split('/')[1] + "&AreaNo=" + moh.MakeMask(vFound.Split('/')[0], 5) + "&StoreNo=" + StoreNo + "&Flag=0'>" + GetLocalResourceObject("LoadNo").ToString() + " " + vFound + @"</a>";                           
                        
                    }
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            } 
        }

        protected void txtCarNo_TextChanged(object sender, EventArgs e)
        {
            BtnFind2_Click(sender, null);
        }

        public void updateCache()
        {
            if (HttpRuntime.Cache["WSOverCarMove_" + StoreNo + Session["CNN2"].ToString()] != null) Cache.Remove("WSOverCarMove_" + StoreNo + Session["CNN2"].ToString());
            if (HttpRuntime.Cache["WSOverInCarMove_" + StoreNo + Session["CNN2"].ToString()] != null) Cache.Remove("WSOverInCarMove_" + StoreNo + Session["CNN2"].ToString());
            if (HttpRuntime.Cache["WSOverOutCarMove_" + StoreNo + Session["CNN2"].ToString()] != null) Cache.Remove("WSOverOutCarMove_" + StoreNo + Session["CNN2"].ToString());
        }
    }
}