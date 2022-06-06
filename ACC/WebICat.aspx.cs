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
    public partial class WebICat : System.Web.UI.Page
    {

        private short TypeFlag
        {
            get
            {
                if (ViewState["TypeFlag"] == null)
                {
                    ViewState["TypeFlag"] = 0;
                }
                return short.Parse(ViewState["TypeFlag"].ToString());
            }
            set { ViewState["TypeFlag"] = value; }
        }

        private short CurLevel
        {
            get
            {
                if (ViewState["CurLevel"] == null)
                {
                    ViewState["CurLevel"] = 1;
                }
                return short.Parse(ViewState["CurLevel"].ToString());
            }
            set { ViewState["CurLevel"] = value; }
        }

        private short Levels
        {
            get
            {
                if (ViewState["Levels"] == null)
                {
                    ViewState["Levels"] = 1;
                }
                return short.Parse(ViewState["Levels"].ToString());
            }
            set { ViewState["Levels"] = value; }
        }

        private string fcode
        {
            get
            {
                if (ViewState["fcode"] == null)
                {
                    ViewState["fcode"] = "";
                }
                return ViewState["fcode"].ToString();
            }
            set { ViewState["fcode"] = value; }
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
                    Session["Branch"] = "1";
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
                    TypeFlag = 1;
                    fcode = "";
                    Levels = 2;
                    LbtnLevel1.Text = GetLocalResourceObject("ItemCat").ToString();  // "أنواع الأصناف";
                    string[] ax = new string[2];
                    ax[0] = "FCode";
                    ax[1] = "Code";
                    grdCodes.DataKeyNames = ax;
                    LoadCodesData();
                    this.Page.Header.Title = LbtnLevel1.Text;
                }
                else
                {
                    LblCodesResult.Text = "";
                }
                if (CurLevel > 1)
                {
                    grdCodes.Columns[3].Visible = true;
                    grdCodes.Columns[4].Visible = true;
                    grdCodes.Columns[5].Visible = true;
                    grdCodes.Columns[6].Visible = true;
                    grdCodes.Columns[7].Visible = true;
                    grdCodes.Columns[8].Visible = true;
                    grdCodes.Columns[9].Visible = true;
                    grdCodes.Columns[10].Visible = true;
                }
                else
                {
                    grdCodes.Columns[3].Visible = false;
                    grdCodes.Columns[4].Visible = false;
                    grdCodes.Columns[5].Visible = false;
                    grdCodes.Columns[6].Visible = false;
                    grdCodes.Columns[7].Visible = false;
                    grdCodes.Columns[8].Visible = false;
                    grdCodes.Columns[9].Visible = false;
                    grdCodes.Columns[10].Visible = false;
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void LoadCodesData()
        {
            try
            {
                        grdCodes.ShowFooter = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass101;
                        ICat ax = new ICat();
                        ax.Branch = short.Parse(Session["Branch"].ToString());
                        ax.FCode = fcode;
                        grdCodes.DataSource = ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        grdCodes.DataBind();
                        if (CurLevel > 1)
                        {
                            grdCodes.Columns[3].Visible = true;
                            grdCodes.Columns[4].Visible = true;
                            grdCodes.Columns[5].Visible = true;
                            grdCodes.Columns[6].Visible = true;
                            grdCodes.Columns[7].Visible = true;
                            grdCodes.Columns[8].Visible = true;
                            grdCodes.Columns[9].Visible = true;
                            grdCodes.Columns[10].Visible = true;
                        }
                        else
                        {
                            grdCodes.Columns[3].Visible = false;
                            grdCodes.Columns[4].Visible = false;
                            grdCodes.Columns[5].Visible = false;
                            grdCodes.Columns[6].Visible = false;
                            grdCodes.Columns[7].Visible = false;
                            grdCodes.Columns[8].Visible = false;
                            grdCodes.Columns[9].Visible = false;
                            grdCodes.Columns[10].Visible = false;
                        }

                        if (grdCodes.Rows.Count < 1)
                        {
                            List<ICat> Listax = new List<ICat>();
                            Listax.Add(ax);
                            grdCodes.DataSource = Listax;
                            grdCodes.DataBind();
                            grdCodes.Rows[0].Cells.Clear();
                        }

                        foreach (GridViewRow itm in grdCodes.Rows)
                        {
                            ImageButton BtnEdit = itm.FindControl("BtnEdit") as ImageButton;
                            ImageButton BtnDelete = itm.FindControl("BtnDelete") as ImageButton;
                            if (BtnEdit != null) BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass102;
                            if (BtnDelete != null) BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass103;
                        }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }


        protected void grdCodes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string FCode = "";
                if (TypeFlag < 5) FCode = grdCodes.DataKeys[e.RowIndex]["FCode"].ToString();
                string Code = grdCodes.DataKeys[e.RowIndex]["Code"].ToString();
                GridViewRow gvr = grdCodes.Rows[e.RowIndex];
                TextBox txtName1 = gvr.FindControl("txtName1") as TextBox;
                TextBox txtName2 = gvr.FindControl("txtName2") as TextBox;

                if (txtName2 == null || txtName1 == null)
                {
                    e.Cancel = true;
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = GetLocalResourceObject("ErrorUpdate").ToString();  // "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    return;
                }

                        ICat myAccess = new ICat();
                        myAccess.Branch = short.Parse(Session["Branch"].ToString());
                        myAccess.Code = Code;
                        myAccess.FCode = FCode;
                        myAccess.Name1 = txtName1.Text;
                        myAccess.Name2 = txtName2.Text;
                        if (CurLevel > 1)
                        {
                            TextBox txtCSal_Acc = gvr.FindControl("txtCSal_Acc") as TextBox;
                            TextBox txtCRSal_Acc = gvr.FindControl("txtCRSal_Acc") as TextBox;
                            TextBox txtRCSal_Acc = gvr.FindControl("txtRCSal_Acc") as TextBox;
                            TextBox txtRCRSal_Acc = gvr.FindControl("txtRCRSal_Acc") as TextBox;
                            TextBox txtCPur_Acc = gvr.FindControl("txtCPur_Acc") as TextBox;
                            TextBox txtCRPur_Acc = gvr.FindControl("txtCRPur_Acc") as TextBox;
                            TextBox txtRCPur_Acc = gvr.FindControl("txtRCPur_Acc") as TextBox;
                            TextBox txtRCRPur_Acc = gvr.FindControl("txtRCRPur_Acc") as TextBox;
                            if (txtCSal_Acc == null || txtCRSal_Acc == null || txtRCSal_Acc == null || txtRCRSal_Acc == null || txtCPur_Acc == null || txtCRPur_Acc == null || txtRCPur_Acc == null || txtRCRPur_Acc == null)
                            {
                                e.Cancel = true;
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = GetLocalResourceObject("ErrorUpdate").ToString();  // "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                            myAccess.CSal_Acc = txtCSal_Acc.Text;
                            myAccess.CrSal_Acc = txtCRSal_Acc.Text;
                            myAccess.RCSal_Acc = txtRCSal_Acc.Text;
                            myAccess.RCRSal_Acc = txtRCRSal_Acc.Text;
                            myAccess.CPur_Acc = txtCPur_Acc.Text;
                            myAccess.CrPur_Acc = txtCRPur_Acc.Text;
                            myAccess.RCPur_Acc = txtRCPur_Acc.Text;
                            myAccess.RCRPur_Acc = txtRCRPur_Acc.Text;
                        }
                        else
                        {
                            myAccess.CSal_Acc = "";
                            myAccess.CrSal_Acc = "";
                            myAccess.RCSal_Acc = "";
                            myAccess.RCRSal_Acc = "";
                            myAccess.CPur_Acc = "";
                            myAccess.CrPur_Acc = "";
                            myAccess.RCPur_Acc = "";
                            myAccess.RCRPur_Acc = "";
                        }
                        myAccess.FUpdate = false;

                        if (!myAccess.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            e.Cancel = true;
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("ErrorUpdate").ToString();  //"حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                grdCodes.EditIndex = -1;
                LoadCodesData();
                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                LblCodesResult.Text = GetLocalResourceObject("EditSuccess").ToString();  // "لقد تم تعديل البيانات بنجاح";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void grdCodes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                if (CurLevel < Levels)
                {
                    string FCode = grdCodes.DataKeys[e.NewSelectedIndex]["FCode"].ToString();
                    string Code = grdCodes.DataKeys[e.NewSelectedIndex]["Code"].ToString();
                    GridViewRow gvr = grdCodes.Rows[e.NewSelectedIndex];
                    Label txtName1 = gvr.FindControl("lblName1") as Label;

                    CurLevel++;
                    fcode = Code;
                    LoadCodesData();

                    switch (CurLevel)
                    {
                        case 1:
                            LbtnLevel1.Visible = true;
                            LbtnLevel2.Visible = false;
                            LbtnLevel3.Visible = false;
                            LbtnLevel4.Visible = false;
                            LbtnLevel5.Visible = false;
                            break;
                        case 2:
                            LbtnLevel1.Visible = true;
                            LbtnLevel2.Visible = true;
                            LbtnLevel2.Text = " :: " + txtName1.Text;
                            LbtnLevel2.ToolTip = Code.ToString();
                            LbtnLevel3.Visible = false;
                            LbtnLevel4.Visible = false;
                            LbtnLevel5.Visible = false;
                            break;
                        case 3:
                            LbtnLevel1.Visible = true;
                            LbtnLevel2.Visible = true;
                            LbtnLevel3.Visible = true;
                            LbtnLevel3.Text = " :: " + txtName1.Text;
                            LbtnLevel3.ToolTip = Code.ToString();
                            LbtnLevel4.Visible = false;
                            LbtnLevel5.Visible = false;
                            break;
                        case 4:
                            LbtnLevel1.Visible = true;
                            LbtnLevel2.Visible = true;
                            LbtnLevel3.Visible = true;
                            LbtnLevel4.Visible = true;
                            LbtnLevel4.Text = " :: " + txtName1.Text;
                            LbtnLevel4.ToolTip = Code.ToString();
                            LbtnLevel5.Visible = false;
                            break;
                    }
                    e.NewSelectedIndex = -1;
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = GetLocalResourceObject("MaxLevel").ToString();  // "لقد تم الوصول الى أخر مستوى للتصنيف";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    e.NewSelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
                e.NewSelectedIndex = -1;
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
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void grdCodes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdCodes.EditIndex = -1;
                LoadCodesData();
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void grdCodes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Insert"))
                {
                    ImageButton btnInsert = e.CommandSource as ImageButton;
                    if (btnInsert == null)
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    GridViewRow gvr = btnInsert.NamingContainer as GridViewRow;
                    if (gvr == null)
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    TextBox txtName1 = gvr.FindControl("txtName1") as TextBox;
                    TextBox txtName2 = gvr.FindControl("txtName2") as TextBox;

                    if (txtName1 == null || txtName2 == null)
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("ErrorAdd").ToString();  // "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                    if (txtName1.Text == "")
                    {
                        grdCodes_RowCancelingEdit(sender, null);
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("SureEnter").ToString();  // "تاكد من أدخال البيانات المطلوبة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }


                            ICat myAccess = new ICat();
                            myAccess.Branch = short.Parse(Session["Branch"].ToString());
                            myAccess.FCode = fcode;
                            myAccess.Name1 = txtName1.Text;
                            myAccess.Name2 = txtName2.Text;
                            myAccess.FUpdate = false;

                            if (CurLevel > 1)
                            {
                                TextBox txtCSal_Acc = gvr.FindControl("txtCSal_Acc2") as TextBox;
                                TextBox txtCRSal_Acc = gvr.FindControl("txtCRSal_Acc2") as TextBox;
                                TextBox txtRCSal_Acc = gvr.FindControl("txtRCSal_Acc2") as TextBox;
                                TextBox txtRCRSal_Acc = gvr.FindControl("txtRCRSal_Acc2") as TextBox;
                                TextBox txtCPur_Acc = gvr.FindControl("txtCPur_Acc2") as TextBox;
                                TextBox txtCRPur_Acc = gvr.FindControl("txtCRPur_Acc2") as TextBox;
                                TextBox txtRCPur_Acc = gvr.FindControl("txtRCPur_Acc2") as TextBox;
                                TextBox txtRCRPur_Acc = gvr.FindControl("txtRCRPur_Acc2") as TextBox;
                                if (txtCSal_Acc == null || txtCRSal_Acc == null || txtRCSal_Acc == null || txtRCRSal_Acc == null || txtCPur_Acc == null || txtCRPur_Acc == null || txtRCPur_Acc == null || txtRCRPur_Acc == null)
                                {
                                    grdCodes_RowCancelingEdit(sender, null);
                                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                    LblCodesResult.Text = GetLocalResourceObject("SureEnter").ToString();  // "تاكد من أدخال البيانات المطلوبة";
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                    return;
                                }
                                myAccess.CSal_Acc = txtCSal_Acc.Text;
                                myAccess.CrSal_Acc = txtCRSal_Acc.Text;
                                myAccess.RCSal_Acc = txtRCSal_Acc.Text;
                                myAccess.RCRSal_Acc = txtRCRSal_Acc.Text;
                                myAccess.CPur_Acc = txtCPur_Acc.Text;
                                myAccess.CrPur_Acc = txtCRPur_Acc.Text;
                                myAccess.RCPur_Acc = txtRCPur_Acc.Text;
                                myAccess.RCRPur_Acc = txtRCRPur_Acc.Text;
                            }
                            else
                            {
                                myAccess.CSal_Acc = "";
                                myAccess.CrSal_Acc = "";
                                myAccess.RCSal_Acc = "";
                                myAccess.RCRSal_Acc = "";
                                myAccess.CPur_Acc = "";
                                myAccess.CrPur_Acc = "";
                                myAccess.RCPur_Acc = "";
                                myAccess.RCRPur_Acc = "";
                            }
             


                            string s = myAccess.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (s == "0" || s == null)
                            {
                                s = fcode + "0001";
                            }
                            else
                            {
                                s = moh.MakeMask((Int32.Parse(s) + 1).ToString(), 4);
                            }
                            if (myAccess.FCode == "")
                            {
                                s = moh.MakeMask(s, 4);
                            }
                            else
                            {
                                s = moh.MakeMask(s, 8);
                            }
                            myAccess.Code = s;

                            if (myAccess.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = GetLocalResourceObject("AddSuccess").ToString();  //"لقد تم اضافة البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            }
                            else
                            {
                                grdCodes_RowCancelingEdit(sender, null);
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = GetLocalResourceObject("ErrorAdd").ToString();  //"لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                            LoadCodesData();
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void grdCodes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string Code = grdCodes.DataKeys[e.RowIndex]["Code"].ToString();
                String FCode = "";
                        FCode = grdCodes.DataKeys[e.RowIndex]["FCode"].ToString();
                        ICat myAccess = new ICat();
                        myAccess.Branch = short.Parse(Session["Branch"].ToString());
                        myAccess.FCode = FCode;
                        myAccess.Code = Code;

                        if (myAccess.IsFather(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("ErrorDelete").ToString();  // "لا يمكن الغاء البند حيث انه مرتبط ببنود أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            e.Cancel = true;
                        }
                        else
                        {
                            if (!myAccess.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = GetLocalResourceObject("ErrorUpdate").ToString();  // "حدث خطأ أثناء تحديث البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                e.Cancel = true;
                            }
                            else
                            {
                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.UserName = Session["CurrentUser"].ToString();
                                UserTran.Description = GetLocalResourceObject("DeleteItemCat").ToString() + " " + myAccess.Name1;  // "الغاء بيانات نوع الصنف  "
                                UserTran.FormAction = "الغاء";
                                UserTran.FormName = "انواع الاصناف";
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = GetLocalResourceObject("DeleteSuccess").ToString();  // "لقد تم حذف السجل بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                                LoadCodesData();
                            }
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void grdCodes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                LoadCodesData();
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }


        protected void LbtnLevel1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                switch (int.Parse(e.CommandName))
                {
                    case 1:
                        LbtnLevel1.Visible = true;
                        LbtnLevel2.Visible = false;
                        LbtnLevel3.Visible = false;
                        LbtnLevel4.Visible = false;
                        LbtnLevel5.Visible = false;
                        fcode = "";
                        CurLevel = 1;
                        LoadCodesData();
                        break;
                    case 2:
                        LbtnLevel1.Visible = true;
                        LbtnLevel2.Visible = true;
                        LbtnLevel3.Visible = false;
                        LbtnLevel4.Visible = false;
                        LbtnLevel5.Visible = false;
                        fcode = LbtnLevel2.ToolTip;
                        CurLevel = 2;
                        LoadCodesData();
                        break;
                    case 3:
                        LbtnLevel1.Visible = true;
                        LbtnLevel2.Visible = true;
                        LbtnLevel3.Visible = true;
                        LbtnLevel4.Visible = false;
                        LbtnLevel5.Visible = false;
                        fcode = LbtnLevel3.ToolTip;
                        CurLevel = 3;
                        LoadCodesData();
                        break;
                    case 4:
                        LbtnLevel1.Visible = true;
                        LbtnLevel2.Visible = true;
                        LbtnLevel3.Visible = true;
                        LbtnLevel4.Visible = true;
                        LbtnLevel5.Visible = false;
                        fcode = LbtnLevel4.ToolTip;
                        CurLevel = 4;
                        LoadCodesData();
                        break;
                    case 5:
                        LbtnLevel1.Visible = true;
                        LbtnLevel2.Visible = true;
                        LbtnLevel3.Visible = true;
                        LbtnLevel4.Visible = true;
                        LbtnLevel5.Visible = true;
                        fcode = LbtnLevel5.ToolTip;
                        CurLevel = 5;
                        LoadCodesData();
                        break;
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void btnUpdate_Load(object sender, EventArgs e)
        {
            ((ImageButton)sender).Visible = true;
        }

    }
}