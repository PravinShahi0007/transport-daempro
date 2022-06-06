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

namespace ACC
{
    public partial class WebDrivers : System.Web.UI.Page
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
        public void EditMode()
        {
            txtCode.ReadOnly = true;
            txtCode.BackColor = System.Drawing.Color.LightGray;

            BtnEdit.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass162;
            BtnNew.Visible = false;
            BtnDelete.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass163;
        }

        public void NewMode()
        {
            txtCode.ReadOnly = false;
            txtCode.BackColor = System.Drawing.Color.White;

            BtnEdit.Visible = false;
            BtnNew.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass161;
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
                    this.Page.Header.Title = "بيانات السائقين";
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

                    BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass161;
                    BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass162;
                    BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass163;
                    BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass164;
                    BtnFind.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass164;

                    ddlSponosor.DataTextField = "Name";
                    ddlSponosor.DataValueField = "EmpCode";
                    SEmp myemp = new SEmp();
                    if (Cache["Emps" + Session["CNN2"].ToString()] == null) Cache.Insert("Emps" + Session["CNN2"].ToString(), myemp.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlSponosor.DataSource = (List<SEmp>)(Cache["Emps" + Session["CNN2"].ToString()]);
                    ddlSponosor.DataBind();
                    ddlSponosor.Items.Insert(0, new ListItem("أختر الموظف", "-1", true));



                    ddlShipDriver.DataTextField = "Name";
                    ddlShipDriver.DataValueField = "MobileNo";
                    ShipDrivers myuser = new ShipDrivers();
                    ddlShipDriver.DataSource = (from itm in myuser.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                           orderby itm.ID
                                           select itm).ToList();
                    ddlShipDriver.DataBind();
                    ddlShipDriver.Items.Insert(0, new ListItem("أختر السائق", "-1", true));
                    LoadDriversData();
                    BtnClear_Click(sender, null);
                }
                else
                {
                    LblCodesResult.Text = "";
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


        protected void LoadDriversData()
        {
            try
            {
                Drivers myDrive = new Drivers();
                myDrive.Branch = short.Parse(Session["Branch"].ToString());
                if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                grdCodes.DataSource = (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()]);
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

        protected void grdCodes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                string Code = grdCodes.DataKeys[e.NewSelectedIndex]["Code"].ToString();
                txtCode.Text = Code;
                BtnSearch_Click(sender, null);
                e.NewSelectedIndex = -1;
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
                LoadDriversData();
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

        protected void BtnClear_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                NewMode();
                txtCode.Text = "";
                txtIqamaDate.Text = "";
                txtIqamaFrom.Text = "";
                txtIqamaNo.Text = "";
                txtMobileNo.Text = "";
                txtName1.Text = "";
                txtName2.Text = "";
                txtCost.Text = "";
                ChkAjir.Checked = false;
                ChkAjir_CheckedChanged(sender, null);
                ddlSponosor.SelectedIndex = 0;
                ddlShipDriver.SelectedIndex = 0;
                ChkStatus.Checked = true;

                Drivers myacc = new Drivers();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                string s = myacc.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (s != null)
                {
                    txtCode.Text = moh.MakeMask((Int32.Parse(s) + 1).ToString(), 5);
                }
                else
                {
                    txtCode.Text = "00001";
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

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    txtCode.Text = moh.MakeMask(txtCode.Text, 5);
                    Drivers myacc = new Drivers();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myacc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myacc.Code = txtCode.Text;
                    myacc = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                             where sitm.Code == myacc.Code
                               select sitm).FirstOrDefault();
                    if (myacc == null)
                    {
                        myacc = new Drivers();
                        myacc.Branch = short.Parse(Session["Branch"].ToString());
                        myacc.Code = txtCode.Text;
                        myacc.Name1 = txtName1.Text;
                        myacc.Name2 = txtName2.Text;
                        myacc.IqamaDate = txtIqamaDate.Text;
                        myacc.IqamaFrom = txtIqamaFrom.Text;
                        myacc.IqamaNo = txtIqamaNo.Text;
                        myacc.MobileNo = txtMobileNo.Text;
                        myacc.Status = ChkStatus.Checked;
                        myacc.Sponsor = ddlSponosor.SelectedValue;
                        myacc.Cost = moh.StrToDouble(txtCost.Text);
                        myacc.Ajir = ChkAjir.Checked;
                        myacc.TwegaAcc = ddlShipDriver.SelectedValue;
                        if (myacc.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            UpdateCache();
                            if (!ChkAjir.Checked)
                            {
                                ChkAccAccount();
                                ChkEmpAccount();
                            }
                            LoadDriversData();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم حفظ البيانات بنجاح";
                            BtnClear_Click(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);                           
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ اثناء حفظ البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
                    else
                    {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "رقم السائق مكرر";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
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

        protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtCode.Text != "")
                {
                    txtCode.Text = moh.MakeMask(txtCode.Text, 5);
                    Drivers myacc = new Drivers();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myacc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myacc.Code = txtCode.Text;
                    myacc = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                             where sitm.Code == myacc.Code
                             select sitm).FirstOrDefault();
                    if (myacc != null)
                    {
                        EditMode();
                        txtName1.Text = myacc.Name1;
                        txtName2.Text = myacc.Name2;
                        txtIqamaDate.Text = myacc.IqamaDate;
                        txtIqamaFrom.Text = myacc.IqamaFrom;
                        txtIqamaNo.Text = myacc.IqamaNo;
                        txtMobileNo.Text = myacc.MobileNo;
                        ddlSponosor.SelectedValue = myacc.Sponsor;
                        txtCost.Text = myacc.Cost.ToString();
                        ChkAjir.Checked = (bool)myacc.Ajir;
                        ChkAjir_CheckedChanged(sender, null);
                        ChkStatus.Checked = (bool)myacc.Status;
                        ddlShipDriver.SelectedValue = myacc.TwegaAcc;
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم السائق غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم السائق";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
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

        public void ChkAccAccount()
        {
            return;
            //Acc myAcc = new Acc();
            //myAcc.Branch = short.Parse(Session["Branch"].ToString());
            //myAcc.Code = "120503" + txtCode.Text.Substring(2, 3);
            //if (!myAcc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            //{
            //    myAcc = new Acc();
            //    myAcc.Branch = short.Parse(Session["Branch"].ToString());
            //    myAcc.Code = "120503" + txtCode.Text.Substring(2, 3);
            //    myAcc.FCode = "120503";
            //    myAcc.MCode = txtCode.Text.Substring(2, 3);
            //    myAcc.FLevel = 5;
            //    myAcc.Name1 = txtName1.Text;
            //    myAcc.Name2 = txtName2.Text;
            //    myAcc.LastLevel = true;
            //    myAcc.FType = "2";
            //    myAcc.SType = "2";
            //    myAcc.Stype1 = "8";
            //    myAcc.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            //}
        }

        public void ChkEmpAccount()
        {
            return;
            //Emp myEmp = new Emp();
            //myEmp.Branch = short.Parse(Session["Branch"].ToString());
            //myEmp.EmpCode = "120503" + txtCode.Text.Substring(2, 3);
            //myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            //if (myEmp == null)
            //{
            //    myEmp = new Emp();
            //    myEmp.Branch = short.Parse(Session["Branch"].ToString());
            //    myEmp.EmpCode = "120503" + txtCode.Text.Substring(2, 3);
            //    myEmp.Name1 = txtName1.Text;
            //    myEmp.Name2 = txtName2.Text;
            //    myEmp.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            //}
        }

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    txtCode.Text = moh.MakeMask(txtCode.Text, 5);
                    Drivers myacc = new Drivers();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myacc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myacc.Code = txtCode.Text;
                    myacc = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                             where sitm.Code == myacc.Code
                             select sitm).FirstOrDefault();
                    if (myacc != null)
                    {
                        myacc.Name1 = txtName1.Text;
                        myacc.Name2 = txtName2.Text;
                        myacc.IqamaDate = txtIqamaDate.Text;
                        myacc.IqamaFrom = txtIqamaFrom.Text;
                        myacc.IqamaNo = txtIqamaNo.Text;
                        myacc.MobileNo = txtMobileNo.Text;
                        myacc.Status = (bool)ChkStatus.Checked;
                        myacc.Sponsor = ddlSponosor.SelectedValue;
                        myacc.Cost = moh.StrToDouble(txtCost.Text);
                        myacc.Ajir = ChkAjir.Checked;
                        myacc.TwegaAcc = ddlShipDriver.SelectedValue;
                        if (myacc.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            UpdateCache();
                            if (!ChkAjir.Checked)
                            {
                                ChkAccAccount();
                                ChkEmpAccount();
                            }
                            LoadDriversData();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم حفظ البيانات بنجاح";
                            BtnClear_Click(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ اثناء حفظ البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم السائق غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
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

        protected void BtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtCode.Text != "")
                {
                    txtCode.Text = moh.MakeMask(txtCode.Text, 5);
                    Drivers myacc = new Drivers();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myacc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myacc.Code = txtCode.Text;
                    myacc = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                             where sitm.Code == myacc.Code
                             select sitm).FirstOrDefault();
                    if (myacc != null)
                    {
                        // Check for Delete Drivers
                        if (myacc.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            UpdateCache();
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();                            
                            UserTran.Description = "الغاء بيانات السائق " + myacc.Name1;
                            UserTran.FormAction = "الغاء";
                            UserTran.FormName = "السائقين";
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            LoadDriversData();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقم تم الغاء بيانات السائق بنجاح";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ أثناء الغاء البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم السائق";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
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

        public void UpdateCache()
        {
            if (Cache["Drivers" + Session["CNN2"].ToString()] != null)
            {
                Cache.Remove("Drivers" + Session["CNN2"].ToString());
                Drivers myDrive = new Drivers();
                myDrive.Branch = 1;
                Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ShipUsers myuser = new ShipUsers();
                myuser.ID = txtCode.Text;
                myuser.Password = txtMobileNo.Text.Substring(0, 10);
                myuser.UserType = 2;
                myuser.LoginType = 2;
                myuser.MobileNo = "966" + txtMobileNo.Text.Substring(1, 9);
                myuser.FirstName = txtName2.Text.Split(' ')[0];
                myuser.LastName = txtName2.Text.Split(' ')[1];
                myuser.IDNo = txtIqamaNo.Text;
                myuser.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            }
        }

        protected void ChkAjir_CheckedChanged(object sender, EventArgs e)
        {
            lblCost.Visible = ChkAjir.Checked;
            txtCost.Visible = ChkAjir.Checked;
        }
    }
}