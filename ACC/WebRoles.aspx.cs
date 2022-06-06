using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using System.Reflection;
using System.Configuration;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class WebRoles : System.Web.UI.Page
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
            txtRoleName.ReadOnly = true;
            txtRoleName.BackColor = System.Drawing.Color.LightGray;

            BtnEdit.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass182;
            BtnNew.Visible = false;
            BtnDelete.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass183;

            if (BtnEdit.Visible || BtnDelete.Visible)
            {
                txtReason.Visible = true;
                ValReason.Enabled = true;
                lblReason.Visible = true;
            }
        }

        public void NewMode()
        {
            txtRoleName.ReadOnly = false;
            txtRoleName.BackColor = System.Drawing.Color.White;

            BtnEdit.Visible = false;
            BtnNew.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass181;
            BtnDelete.Visible = false;

            txtReason.Visible = false;
            ValReason.Enabled = false;
            lblReason.Visible = false;
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
                    this.Page.Header.Title = "مجموعة العمل";
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
                        UserTran.Description = "تم اختيار صفحة مجموعة العمل";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass181;
                    BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass182;
                    BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass183;
                    BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[0].Pass184;

                    ddlRoles.DataTextField = "RoleName";
                    ddlRoles.DataValueField = "RoleName";
                    TblRoles ax = new TblRoles();
                    if (Cache["Roles" + Session["CNN2"].ToString()] == null) Cache.Insert("Roles" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlRoles.DataSource = (List<TblRoles>)(Cache["Roles" + Session["CNN2"].ToString()]);
                    ddlRoles.DataBind();
                    ddlRoles.Items.Insert(0, new ListItem("أختر مجموعة العمل", "-1", true));
                   
                    txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtUserName.Text = Session["FullUser"].ToString();
                    txtUserDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    ddlInterface_SelectedIndexChanged(sender, e);
                    LoadRolesData();
                    NewMode();
                }
                else
                {
                    LblCodesResult.Text = "";
                }
                int i = 0;
                foreach (ListItem myli in ChkPass.Items)
                {
                    myli.Attributes.Add("onclick", "uncheckList('ContentPlaceHolder1_ChkPass_" + i.ToString() + "')");
                    i++;
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

        public bool CheckItem(string keyname)
        {
            if ((string)((List<TblRoles>)(Session["Roll"]))[0].RoleName.ToUpper() == "ADMIN") return true;
            else
            {
                PropertyInfo propertyInfo = typeof(TblRoles).GetProperty("Pass" + (keyname.Substring(5, keyname.Length - 5)));
                return (bool)propertyInfo.GetValue(((List<TblRoles>)(Session["Roll"]))[
                    keyname.Substring(0, 5) == "PassA" ? 0 :
                    keyname.Substring(0, 5) == "PassB" ? 1 :
                    keyname.Substring(0, 5) == "PassC" ? 2 : 3], null);
            }
        }

        protected void LoadRolesData()
        {
            try
            {
                TblRoles ax = new TblRoles();
                if (Cache["Roles" + Session["CNN2"].ToString()] == null) Cache.Insert("Roles" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                grdCodes.DataSource = (List<TblRoles>)(Cache["Roles" + Session["CNN2"].ToString()]);
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


        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    TblRoles myRoll = new TblRoles();
                    myRoll.RoleName = txtRoleName.Text;
                    if (Cache["MyRoles" + Session["CNN2"].ToString()] == null) Cache.Insert("MyRoles" + Session["CNN2"].ToString(), myRoll.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myRoll = (from itm in (List<TblRoles>)(Cache["MyRoles" + Session["CNN2"].ToString()])
                             where itm.RoleName == myRoll.RoleName
                             select itm).FirstOrDefault();
                    if (myRoll == null )
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "اسم مجموعة العمل غير مدرج من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        TblRoles myRollA = new TblRoles();
                        myRollA.Interface = short.Parse(ddlInterface.SelectedValue);
                        myRollA.RoleName = txtRoleName.Text;
                        myRollA.PassType = "A";
                        myRollA = myRollA.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myRollA == null)
                        {
                            myRollA = new TblRoles();
                            myRollA.Interface = short.Parse(ddlInterface.SelectedValue);
                            myRollA.RoleName = txtRoleName.Text;
                            myRollA.PassType = "A";
                            myRollA.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                        myRollA.Interface = short.Parse(ddlInterface.SelectedValue);

                        TblRoles myRollB = new TblRoles();
                        myRollB.Interface = short.Parse(ddlInterface.SelectedValue);
                        myRollB.RoleName = txtRoleName.Text;
                        myRollB.PassType = "B";
                        myRollB = myRollB.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myRollB == null)
                       {
                            myRollB = new TblRoles();
                            myRollB.Interface = short.Parse(ddlInterface.SelectedValue);
                            myRollB.RoleName = txtRoleName.Text;
                            myRollB.PassType = "B";
                            myRollB.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                        myRollB.Interface = short.Parse(ddlInterface.SelectedValue);

                        TblRoles myRollC = new TblRoles();
                        myRollC.Interface = short.Parse(ddlInterface.SelectedValue);
                        myRollC.RoleName = txtRoleName.Text;
                        myRollC.PassType = "C";
                        myRollC = myRollC.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myRollC == null)
                        {
                            myRollC = new TblRoles();
                            myRollC.Interface = short.Parse(ddlInterface.SelectedValue);
                            myRollC.RoleName = txtRoleName.Text;
                            myRollC.PassType = "C";
                            myRollC.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                        myRollC.Interface = short.Parse(ddlInterface.SelectedValue);

                        TblRoles myRollD = new TblRoles();
                        myRollD.Interface = short.Parse(ddlInterface.SelectedValue);
                        myRollD.RoleName = txtRoleName.Text;
                        myRollD.PassType = "D";
                        myRollD = myRollD.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myRollD == null)
                        {
                            myRollD = new TblRoles();
                            myRollD.Interface = short.Parse(ddlInterface.SelectedValue);
                            myRollD.RoleName = txtRoleName.Text;
                            myRollD.PassType = "D";
                            myRollD.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                        myRollD.Interface = short.Parse(ddlInterface.SelectedValue);

                        for (int i = 0; i < ChkPass.Items.Count; i++)
                        {
                            if (ChkPass.Items[i].Value.Substring(0, 5) == "PassA")
                            {
                                PropertyInfo propertyInfo = typeof(TblRoles).GetProperty("Pass" + (ChkPass.Items[i].Value.Substring(5, ChkPass.Items[i].Value.Length - 5)));
                                if (propertyInfo != null) propertyInfo.SetValue(myRollA, ChkPass.Items[i].Selected, null);
                            }
                            else if (ChkPass.Items[i].Value.Substring(0, 5) == "PassB")
                            {
                                PropertyInfo propertyInfo = typeof(TblRoles).GetProperty("Pass" + (ChkPass.Items[i].Value.Substring(5, ChkPass.Items[i].Value.Length - 5)));
                                if (propertyInfo != null) propertyInfo.SetValue(myRollB, ChkPass.Items[i].Selected, null);
                            }
                            else if (ChkPass.Items[i].Value.Substring(0, 5) == "PassC")
                            {
                                PropertyInfo propertyInfo = typeof(TblRoles).GetProperty("Pass" + (ChkPass.Items[i].Value.Substring(5, ChkPass.Items[i].Value.Length - 5)));
                                if (propertyInfo != null) propertyInfo.SetValue(myRollC, ChkPass.Items[i].Selected, null);
                            }
                            else if (ChkPass.Items[i].Value.Substring(0, 5) == "PassD")
                            {
                                PropertyInfo propertyInfo = typeof(TblRoles).GetProperty("Pass" + (ChkPass.Items[i].Value.Substring(5, ChkPass.Items[i].Value.Length - 5)));
                                if (propertyInfo != null) propertyInfo.SetValue(myRollD, ChkPass.Items[i].Selected, null);
                            }
                        }

                        myRollA.UserName = txtUserName.ToolTip;
                        myRollA.UserOp = "تعديل";
                        myRollA.UserDate = txtUserDate.Text;

                        myRollB.UserName = txtUserName.ToolTip;
                        myRollB.UserOp = "تعديل";
                        myRollB.UserDate = txtUserDate.Text;

                        myRollC.UserName = txtUserName.ToolTip;
                        myRollC.UserOp = "تعديل";
                        myRollC.UserDate = txtUserDate.Text;

                        myRollD.UserName = txtUserName.ToolTip;
                        myRollD.UserOp = "تعديل";
                        myRollD.UserDate = txtUserDate.Text;

                        if (myRollA.Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                            && myRollB.Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                            && myRollC.Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                            && myRollD.Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.FormName = "مجموعة العمل";
                                UserTran.FormAction = "تعديل";
                                UserTran.Description = "تعديل مجموعة العمل " + myRollA.RoleName;
                                UserTran.Reason = txtReason.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }
                            txtReason.Text = "";

                            updateCache();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                            LoadRolesData();
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ اثناء تعديل البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
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

        protected void BtnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    TblRoles myRoll = new TblRoles();
                    if (Cache["MyRoles" + Session["CNN2"].ToString()] == null) Cache.Insert("MyRoles" + Session["CNN2"].ToString(), myRoll.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myRoll.RoleName = txtRoleName.Text;
                    myRoll = (from itm in (List<TblRoles>)(Cache["MyRoles" + Session["CNN2"].ToString()])
                              where itm.RoleName == myRoll.RoleName
                              select itm).FirstOrDefault();
                    if (myRoll != null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "اسم مجموعة العمل مدخل من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        TblRoles myRollA = new TblRoles();
                        myRollA.Interface = short.Parse(ddlInterface.SelectedValue);
                        myRollA.RoleName = txtRoleName.Text;
                        myRollA.PassType = "A";

                        TblRoles myRollB = new TblRoles();
                        myRollB.Interface = short.Parse(ddlInterface.SelectedValue);
                        myRollB.RoleName = txtRoleName.Text;
                        myRollB.PassType = "B";

                        TblRoles myRollC = new TblRoles();
                        myRollC.Interface = short.Parse(ddlInterface.SelectedValue);
                        myRollC.RoleName = txtRoleName.Text;
                        myRollC.PassType = "C";

                        TblRoles myRollD = new TblRoles();
                        myRollD.Interface = short.Parse(ddlInterface.SelectedValue);
                        myRollD.RoleName = txtRoleName.Text;
                        myRollD.PassType = "D";

                        for (int i = 0; i < ChkPass.Items.Count; i++)
                        {
                            if (ChkPass.Items[i].Value.Substring(0, 5) == "PassA")
                            {
                                PropertyInfo propertyInfo = typeof(TblRoles).GetProperty("Pass" + (ChkPass.Items[i].Value.Substring(5, ChkPass.Items[i].Value.Length - 5)));
                                if (propertyInfo != null) propertyInfo.SetValue(myRollA, ChkPass.Items[i].Selected, null);
                            }
                            else if (ChkPass.Items[i].Value.Substring(0, 5) == "PassB")
                            {
                                PropertyInfo propertyInfo = typeof(TblRoles).GetProperty("Pass" + (ChkPass.Items[i].Value.Substring(5, ChkPass.Items[i].Value.Length - 5)));
                                if (propertyInfo != null)  propertyInfo.SetValue(myRollB, ChkPass.Items[i].Selected, null);
                            }
                            else if (ChkPass.Items[i].Value.Substring(0, 5) == "PassC")
                            {
                                PropertyInfo propertyInfo = typeof(TblRoles).GetProperty("Pass" + (ChkPass.Items[i].Value.Substring(5, ChkPass.Items[i].Value.Length - 5)));
                                if (propertyInfo != null)  propertyInfo.SetValue(myRollC, ChkPass.Items[i].Selected, null);
                            }
                            else if (ChkPass.Items[i].Value.Substring(0, 5) == "PassD")
                            {
                                PropertyInfo propertyInfo = typeof(TblRoles).GetProperty("Pass" + (ChkPass.Items[i].Value.Substring(5, ChkPass.Items[i].Value.Length - 5)));
                                if (propertyInfo != null)  propertyInfo.SetValue(myRollD, ChkPass.Items[i].Selected, null);
                            }
                        }

                        myRollA.UserName = txtUserName.ToolTip;
                        myRollA.UserOp = "جديد";
                        myRollA.UserDate = txtUserDate.Text;

                        myRollB.UserName = txtUserName.ToolTip;
                        myRollB.UserOp = "جديد";
                        myRollB.UserDate = txtUserDate.Text;

                        myRollC.UserName = txtUserName.ToolTip;
                        myRollC.UserOp = "جديد";
                        myRollC.UserDate = txtUserDate.Text;

                        myRollD.UserName = txtUserName.ToolTip;
                        myRollD.UserOp = "جديد";
                        myRollD.UserDate = txtUserDate.Text;

                        if (myRollA.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                            && myRollB.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                            && myRollC.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                            && myRollD.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.FormName = "مجموعة العمل";
                                UserTran.FormAction = "اضافة";
                                UserTran.Description = "اضافة مجموعة العمل " + myRollA.RoleName;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }
                            updateCache();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                            LoadRolesData();
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ اثناء أضافة البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
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
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }

        protected void BtnClear_Click(object sender, ImageClickEventArgs e)
        {
            NewMode();
            txtRoleName.Text = "";
            txtReason.Text = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> ChangeState(false); </script>", false);
        }

        protected void BtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    TblRoles myRoll = new TblRoles();
                    if (Cache["MyRoles" + Session["CNN2"].ToString()] == null) Cache.Insert("MyRoles" + Session["CNN2"].ToString(), myRoll.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myRoll.RoleName = txtRoleName.Text;
                    myRoll = (from itm in (List<TblRoles>)(Cache["MyRoles" + Session["CNN2"].ToString()])
                              where itm.RoleName == myRoll.RoleName
                              select itm).FirstOrDefault();
                    if (myRoll == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "اسم مجموعة العمل غير مدرج من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        if (myRoll.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.FormName = "مجموعة العمل";
                                UserTran.FormAction = "الغاء";
                                UserTran.Description = "الغاء مجموعة العمل " + myRoll.RoleName;
                                UserTran.Reason = txtReason.Text;
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            }
                            txtReason.Text = "";
                            updateCache();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم الغاء البيانات بنجاح";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                            LoadRolesData();
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ اثناء الغاء البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
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

        protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtSearch.Text != "")
                {
                }
                else if (txtRoleName.Text != "")
                {
                    TblRoles myRoll = new TblRoles();
                    if (Cache["MyRoles" + Session["CNN2"].ToString()] == null) Cache.Insert("MyRoles" + Session["CNN2"].ToString(), myRoll.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myRoll.RoleName = txtRoleName.Text;
                    myRoll = (from itm in (List<TblRoles>)(Cache["MyRoles" + Session["CNN2"].ToString()])
                              where itm.RoleName == myRoll.RoleName
                              select itm).FirstOrDefault();
                    if (myRoll == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "اسم مجموعة العمل غير مدرج من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.FormName = "مجموعة العمل";
                            UserTran.FormAction = "عرض";
                            UserTran.Description = "عرض بيانات مجموعة العمل " + myRoll.RoleName;
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                        }

                        EditMode();
                        TblRoles myRollA = new TblRoles();
                        myRollA.RoleName = txtRoleName.Text;
                        myRollA.PassType = "A";
                        myRollA = myRollA.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myRollA != null)
                        {
                            ddlInterface.SelectedValue = myRollA.Interface.ToString();
                            ddlInterface_SelectedIndexChanged(sender, e);
                            TblRoles myRollB = new TblRoles();
                            myRollB.RoleName = txtRoleName.Text;
                            myRollB.PassType = "B";
                            myRollB = myRollB.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myRollB != null)
                            {
                                TblRoles myRollC = new TblRoles();
                                myRollC.RoleName = txtRoleName.Text;
                                myRollC.PassType = "C";
                                myRollC = myRollC.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                if (myRollC != null)
                                {
                                    TblRoles myRollD = new TblRoles();
                                    myRollD.RoleName = txtRoleName.Text;
                                    myRollD.PassType = "D";
                                    myRollD = myRollD.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (myRollD != null)
                                    {
                                        for (int i = 0; i < ChkPass.Items.Count; i++)
                                        {
                                            if (ChkPass.Items[i].Value.Substring(0, 5) == "PassA")
                                            {
                                                PropertyInfo propertyInfo = typeof(TblRoles).GetProperty("Pass" + (ChkPass.Items[i].Value.Substring(5, ChkPass.Items[i].Value.Length - 5)));
                                                if(propertyInfo != null) ChkPass.Items[i].Selected = (bool)propertyInfo.GetValue(myRollA, null);
                                            }
                                            else if (ChkPass.Items[i].Value.Substring(0, 5) == "PassB")
                                            {
                                                PropertyInfo propertyInfo = typeof(TblRoles).GetProperty("Pass" + (ChkPass.Items[i].Value.Substring(5, ChkPass.Items[i].Value.Length - 5)));
                                                if (propertyInfo != null) ChkPass.Items[i].Selected = (bool)propertyInfo.GetValue(myRollB, null);
                                            }
                                            else if (ChkPass.Items[i].Value.Substring(0, 5) == "PassC")
                                            {
                                                PropertyInfo propertyInfo = typeof(TblRoles).GetProperty("Pass" + (ChkPass.Items[i].Value.Substring(5, ChkPass.Items[i].Value.Length - 5)));
                                                if (propertyInfo != null) ChkPass.Items[i].Selected = (bool)propertyInfo.GetValue(myRollC, null);
                                            }
                                            else if (ChkPass.Items[i].Value.Substring(0, 5) == "PassD")
                                            {
                                                PropertyInfo propertyInfo = typeof(TblRoles).GetProperty("Pass" + (ChkPass.Items[i].Value.Substring(5, ChkPass.Items[i].Value.Length - 5)));
                                                if (propertyInfo != null) ChkPass.Items[i].Selected = (bool)propertyInfo.GetValue(myRollD, null);
                                            }
                                        }
                                        txtUserName.ToolTip = myRollA.UserName;
                                        TblUsers ax = new TblUsers();
                                        if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                        ax.UserName = myRollA.UserName;
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
                                        txtUserDate.Text = myRollA.UserDate.ToString();
                                    }
                                }
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

        protected void grdCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdCodes.PageIndex = e.NewPageIndex;
                LoadRolesData();
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
                string RoleName = grdCodes.DataKeys[e.NewSelectedIndex]["RoleName"].ToString();
                if (RoleName != null)
                {
                    txtRoleName.Text = RoleName;
                    BtnSearch_Click(sender, null);
                    e.NewSelectedIndex = -1;
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
                    e.NewSelectedIndex = -1;
                }
            }
        }

        protected void ddlInterface_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChkPass.CssClass = (ddlInterface.SelectedIndex == 0 ? "chicklist" : "chicklist0");
            Prev myPrev = new Prev();
            myPrev.Interface = short.Parse(ddlInterface.SelectedValue);
            ChkPass.DataTextField = "Name";
            ChkPass.DataValueField = "KeyName";
            //ChkPass.DataSource = myPrev.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            ChkPass.DataSource = (from itm in myPrev.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                  where CheckItem(itm.KeyName)
                                  select itm).ToList();

            ChkPass.DataBind();

        }

        protected void ddlRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRoles.SelectedValue != "-1")
            {
                bool vAdd = !txtRoleName.ReadOnly;
                string vrole = txtRoleName.Text;
                txtRoleName.Text = ddlRoles.SelectedValue;
                BtnSearch_Click(sender, null);
                txtRoleName.Text = vrole;
                if (vAdd)
                {
                    NewMode();
                    txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtUserName.Text = Session["FullUser"].ToString();
                    txtUserDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                }
            }
        }

        public void updateCache()
        {
            if (Cache["MyRoles" + Session["CNN2"].ToString()] != null) Cache.Remove("MyRoles" + Session["CNN2"].ToString());
            if (Cache["Roles" + Session["CNN2"].ToString()] != null) Cache.Remove("Roles" + Session["CNN2"].ToString());
            TblRoles myRole = new TblRoles();
            if (Cache["MyRoles" + Session["CNN2"].ToString()] == null) Cache.Insert("MyRoles" + Session["CNN2"].ToString(), myRole.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            if (Cache["Roles" + Session["CNN2"].ToString()] == null) Cache.Insert("Roles" + Session["CNN2"].ToString(), myRole.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
        }
    }
}