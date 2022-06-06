using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class WebPurchaseRequest : System.Web.UI.Page
    {
        public List<vPReq> VouData
        {
            get
            {
                if (ViewState["VouData"] == null)
                {
                    ViewState["VouData"] = new List<vPReq>();
                }
                return (List<vPReq>)ViewState["VouData"];
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
        public string Area2
        {
            get
            {
                if (ViewState["Area2"] == null)
                {
                    ViewState["Area2"] = "1";
                }
                return ViewState["Area2"].ToString();
            }
            set { ViewState["Area2"] = value; }
        }

        public void EditMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass305;
            BtnEdit.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass302;
            BtnNew.Visible = false;
            BtnDelete.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass303;
            if (Request.QueryString["FMode"] != null)
            {
                BtnNew.Visible = false;
                BtnEdit.Visible = false;
                BtnDelete.Visible = false;
            }

            Label8.Visible = BtnEdit.Visible;
            txtItemCode.Visible = BtnEdit.Visible;
        }

        public void NewMode()
        {
            txtVouNo.ReadOnly = false;
            txtVouNo.BackColor = System.Drawing.Color.White;

            BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass301;
            BtnDelete.Visible = false;
            if (Request.QueryString["FMode"] != null)
            {
                BtnNew.Visible = false;
                BtnEdit.Visible = false;
                BtnDelete.Visible = false;
            }

            Label8.Visible = BtnNew.Visible;
            txtItemCode.Visible = BtnNew.Visible;
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
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttach);

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

                    lblBranch.Text = "/" + StoreNo;
                    this.Page.Header.Title = "Purchase Request";

                    BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass301;
                    BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass302;
                    BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass303;
                    BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass304;
                    BtnPrint.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass305;
                    BtnFind.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass304;

                    if (Request.QueryString["FMode"] != null)
                    {
                        BtnNew.Visible = false;
                        BtnEdit.Visible = false;
                        BtnDelete.Visible = false;
                    }

                    if (Request.QueryString["FNum"] != null)
                    {
                        txtVouNo.Text = Request.QueryString["FNum"].ToString();
                        BtnSearch_Click(sender, null);
                    }
                    else BtnClear_Click(sender, null);
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

        protected void LoadVouData()
        {
            try
            {
                grdCodes.ShowFooter = true; // (BtnUnlock.ToolTip != "");

                grdCodes.DataSource = VouData;
                grdCodes.DataBind();

                if (grdCodes.Rows.Count < 1)
                {
                    vPReq ax = new vPReq();
                    VouData.Add(ax);
                    grdCodes.DataSource = VouData;
                    grdCodes.DataBind();
                    grdCodes.Rows[0].Controls.Clear();
                    grdCodes.Rows[0].Cells.Clear();
                    VouData.Remove(ax);
                }
                else
                {
                    //  صلاحية Approved
                    if ((bool)((List<TblRoles>)(Session["Roll"]))[0].Pass343 && Request.QueryString["FMode"] != null)
                    {
                        if (Request.QueryString["FMode"].ToString() == "1")
                        {
                            foreach (GridViewRow itm in grdCodes.Rows)
                            {
                                DropDownList ddlApproved = itm.FindControl("ddlApproved") as DropDownList;
                                if (ddlApproved != null) ddlApproved.Enabled = true;
                            }
                        }
                    }
                }
                DropDownList ddlUnit2 = grdCodes.FooterRow.FindControl("ddlUnit2") as DropDownList;
                if (ddlUnit2 != null)
                {
                    IUnit myUnit = new IUnit();
                    myUnit.Branch = short.Parse(Session["Branch"].ToString());
                    ddlUnit2.DataTextField = "Name2";
                    ddlUnit2.DataValueField = "Code";
                    ddlUnit2.DataSource = myUnit.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlUnit2.DataBind();
                    ddlUnit2.Items.Insert(0, new ListItem("Select Unit", "-1", true));
                }

                if (true) // BtnUnlock.ToolTip != "")
                {
                    if (grdCodes.Rows != null)
                    {
                        foreach (GridViewRow grv in grdCodes.Rows)
                        {
                            ImageButton btnDelete = grv.FindControl("btnDelete") as ImageButton;
                            ImageButton btnEdit = grv.FindControl("btnEdit") as ImageButton;
                            if (btnDelete != null) btnDelete.Visible = true;
                            if (btnEdit != null) btnEdit.Visible = true;
                        }
                    }
                }
                else
                {
                    if (grdCodes.Rows != null)
                    {
                        foreach (GridViewRow grv in grdCodes.Rows)
                        {
                            ImageButton btnDelete = grv.FindControl("btnDelete") as ImageButton;
                            ImageButton btnEdit = grv.FindControl("btnEdit") as ImageButton;
                            if (btnDelete != null) btnDelete.Visible = false;
                            if (btnEdit != null) btnEdit.Visible = false;
                        }
                    }
                }

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
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    GridViewRow gvr = btnInsert.NamingContainer as GridViewRow;
                    if (gvr == null)
                    {
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    TextBox txtITCode2 = gvr.FindControl("txtITCode2") as TextBox;
                    TextBox txtITName2 = gvr.FindControl("txtITName2") as TextBox;
                    DropDownList ddlUnit2 = gvr.FindControl("ddlUnit2") as DropDownList;
                    TextBox txtQuan2 = gvr.FindControl("txtQuan2") as TextBox;

                    if (txtITCode2 == null || txtITName2 == null || ddlUnit2 == null || txtQuan2 == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "Error During Adding Data ... Try Again";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    if (txtITCode2.Text == "")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "You Should Enter Item Code";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    if (txtQuan2.Text == "") txtQuan2.Text = "0.00";

                    if (double.Parse(txtQuan2.Text) == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "You Should Enter Qty.";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    Item myItem = new Item();
                    myItem.Branch = short.Parse(Session["Branch"].ToString());
                    myItem.FType = 1;
                    myItem.ITCode = txtITCode2.Text;
                    myItem = myItem.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myItem == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "Stock Item Not Found";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;                        
                    }
                    else
                    {
                        if (ddlUnit2.SelectedIndex <= 0 || (ddlUnit2.SelectedValue != myItem.ITUnit1 && ddlUnit2.SelectedValue != myItem.ITUnit2) ) ddlUnit2.SelectedValue = myItem.ITUnit1;
                    }

                    // Check Item Exists in another Open Request
                    PReq myReq = new PReq();
                    myReq.ITCode = txtITCode2.Text;
                    myReq.VouNo = int.Parse(txtVouNo.Text);
                    myReq = myReq.FindOpenItem(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myReq != null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "Item Still Open in Requset# " + myReq.VouNo.ToString();
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;                        
                    }

                    PO myPo = new PO();
                    myPo.ITCode = txtITCode2.Text;
                    myPo = myPo.FindOpenItem(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myPo != null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "Item Still Open in PO# " + myPo.VouNo.ToString();
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    vPReq myAccess = new vPReq();
                    myAccess.FNo = (short)(VouData.Count + 1);
                    myAccess.VouLoc = short.Parse(StoreNo);
                    myAccess.Branch = short.Parse(Session["Branch"].ToString());
                    myAccess.ITCode = myItem.ITCode;
                    myAccess.ITName1 = myItem.ITName1;
                    myAccess.ITName2 = myItem.ITName2;
                    myAccess.UnitCode = ddlUnit2.SelectedValue.ToString();
                    if (myAccess.UnitCode != "-1")
                    {
                        myAccess.UnitName1 = ddlUnit2.SelectedItem.Text;
                        myAccess.UnitName2 = ddlUnit2.SelectedItem.Text;
                    }
                    myAccess.Quan = double.Parse(txtQuan2.Text);
                    Stock myStock = new Stock();
                    myStock.Branch = short.Parse(Session["Branch"].ToString());
                    myStock.Number = short.Parse(StoreNo); 
                    myStock.Code = txtITCode2.Text;
                    myStock = myStock.GetItem(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myStock != null) myAccess.Bal = myStock.IOpen + myStock.IPurch - myStock.ISale;
                    myAccess.Remark = txtRemark.Text;
                    VouData.Add(myAccess);
                    MakeSum();
                    LoadVouData();

                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult.Text = "Adding Item done Successfully";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, false), true);
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        public void MakeSum()
        {
            double Quan = 0;
            foreach (vPReq itm in VouData)
            {
                Quan += (double)itm.Quan;
            }
            lblTotalQty.Text = string.Format("{0:N2}", Quan);
        }

        protected void grdCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdCodes.PageIndex = e.NewPageIndex;
                LoadVouData();
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }


        protected void grdCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.EditIndex = grdCodes.SelectedIndex;
            LoadVouData();
        }

        protected void grdCodes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdCodes.EditIndex = -1;
                LoadVouData();
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
                string FNo = grdCodes.DataKeys[e.RowIndex]["FNo"].ToString();
                GridViewRow gvr = grdCodes.Rows[e.RowIndex];

                if (FNo == null || gvr == null)
                {
                    e.Cancel = true;
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "Error During Updating Data ... Try Again";
                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    return;
                }

                TextBox txtITCode2 = gvr.FindControl("txtITCode") as TextBox;
                TextBox txtITName2 = gvr.FindControl("txtITName") as TextBox;
                DropDownList ddlUnit2 = gvr.FindControl("ddlUnit") as DropDownList;
                TextBox txtQuan2 = gvr.FindControl("txtQuan") as TextBox;

                if (txtITCode2 == null || txtITName2 == null || ddlUnit2 == null || txtQuan2 == null)
                {
                    e.Cancel = true;
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "Error During Updating Data ... Try Again";
                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    return;
                }

                if (txtITCode2.Text == "")
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "You Should Enter Item Code";
                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    return;
                }

                if (txtQuan2.Text == "") txtQuan2.Text = "0.00";

                if (double.Parse(txtQuan2.Text) == 0)
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "You Should Enter Qty";
                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    return;
                }

                Item myItem = new Item();
                myItem.Branch = short.Parse(Session["Branch"].ToString());
                myItem.FType = 1;
                myItem.ITCode = txtITCode2.Text;
                myItem = myItem.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myItem == null)
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "Stock Item not Found";
                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    return;
                }
                else
                {
                    if (ddlUnit2.SelectedIndex <= 0 || (ddlUnit2.SelectedValue != myItem.ITUnit1 && ddlUnit2.SelectedValue != myItem.ITUnit2)) ddlUnit2.SelectedValue = myItem.ITUnit1;
                }

                VouData[int.Parse(FNo) - 1].ITCode = myItem.ITCode;
                VouData[int.Parse(FNo) - 1].ITName1 = myItem.ITName1;
                VouData[int.Parse(FNo) - 1].ITName2 = myItem.ITName2;
                VouData[int.Parse(FNo) - 1].UnitCode = ddlUnit2.SelectedValue.ToString();
                if (VouData[int.Parse(FNo) - 1].UnitCode != "-1")
                {
                    VouData[int.Parse(FNo) - 1].UnitName1 = ddlUnit2.SelectedItem.Text;
                    VouData[int.Parse(FNo) - 1].UnitName2 = ddlUnit2.SelectedItem.Text;
                }
                else
                {
                    VouData[int.Parse(FNo) - 1].UnitName1 = "";
                    VouData[int.Parse(FNo) - 1].UnitName2 = "";
                }
                VouData[int.Parse(FNo) - 1].Quan = double.Parse(txtQuan2.Text);
                Stock myStock = new Stock();
                myStock.Branch = short.Parse(Session["Branch"].ToString());
                myStock.Number = short.Parse(StoreNo);
                myStock.Code = txtITCode2.Text;
                myStock = myStock.GetItem(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myStock != null) VouData[int.Parse(FNo) - 1].Bal = myStock.IOpen + myStock.IPurch - myStock.ISale;

                grdCodes.EditIndex = -1;
                MakeSum();
                LoadVouData();

                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                LblCodesResult.Text = "Updating Item done Successfully";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, false), true);
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void grdCodes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            {
                try
                {
                    //e.NewSelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                    e.NewSelectedIndex = -1;
                }
            }
        }

        protected void grdCodes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string FNo = grdCodes.DataKeys[e.RowIndex]["FNo"].ToString();
                VouData.RemoveAt((int)double.Parse(FNo) - 1);
                for (int i = 0; i < VouData.Count; i++)
                {
                    VouData[i].FNo = (short)(i + 1);
                }
                e.Cancel = false;
                MakeSum();
                LoadVouData();
                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                LblCodesResult.Text = "Deleting Item done Successfully";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, false), true);
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
                LoadVouData();
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
                lblStatus.Text = "";
                txtVouNo.Text = "";
                txtVouDate.Text = "";
                txtJobOrder.Text = "";
                txtRemark.Text = "";
                lblTotalQty.Text = "";
                LblCodesResult.Text = "";
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                txtPassword.Text = "";
                txtItemCode.Text = "";
                if (sender != null)
                {
                    PReq myJv = new PReq();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
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
                    BtnUnlock.ToolTip = "";
                    BtnUnlock.Text = "UnLock";
                }
                txtVouDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                VouData.Clear();
                LoadVouData();
                LoadAttachData();
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
                    MakeSum();
                    if (txtJobOrder.Text == "") txtJobOrder.Text = "0";
                    if (lblTotalQty.Text == "" || double.Parse(lblTotalQty.Text) == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "No Qty to Save";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    PReq myJv = new PReq();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.VouLoc = short.Parse(StoreNo);
                    myJv.VouNo = int.Parse(txtVouNo.Text);                    
                    myJv = myJv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myJv != null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "Duplicate Request No.";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }
                    else
                    {
                        foreach (vPReq itm in VouData)
                        {
                            myJv = new PReq();
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.FNo = itm.FNo;
                            myJv.ITCode = itm.ITCode;                           
                            myJv.JobOrder = int.Parse(txtJobOrder.Text);
                            myJv.Quan = itm.Quan;
                            myJv.Remark = txtRemark.Text;
                            myJv.UnitCode = itm.UnitCode;
                            myJv.UserName = txtUserName.ToolTip;
                            myJv.UserDate = txtUserDate.Text;
                            myJv.VouDate = moh.CheckDate(txtVouDate.Text);
                            myJv.VouNo = int.Parse(txtVouNo.Text);
                            myJv.Bal = itm.Bal;
                            myJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "Adding Data Done Successfully";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        string vNumber = txtVouNo.Text;
                        BtnClear_Click(sender, e);
                        PrintMe(vNumber);
                    }
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
                    MakeSum();
                    if (txtJobOrder.Text == "") txtJobOrder.Text = "0";
                    if (lblTotalQty.Text == "" || double.Parse(lblTotalQty.Text) == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "No Qty to Save";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    PReq myJv = new PReq();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.VouNo = int.Parse(txtVouNo.Text);                    
                    myJv = myJv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myJv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "Request No. Not Found";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }
                    else
                    {
                        if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            foreach (vPReq itm in VouData)
                            {
                                myJv = new PReq();
                                myJv.Branch = short.Parse(Session["Branch"].ToString());
                                myJv.VouLoc = short.Parse(StoreNo);
                                myJv.FNo = itm.FNo;
                                myJv.ITCode = itm.ITCode;
                                myJv.JobOrder = int.Parse(txtJobOrder.Text);
                                myJv.Quan = itm.Quan;
                                myJv.Remark = txtRemark.Text;
                                myJv.UnitCode = itm.UnitCode;
                                myJv.UserName = txtUserName.ToolTip;
                                myJv.UserDate = txtUserDate.Text;
                                myJv.VouDate = moh.CheckDate(txtVouDate.Text);
                                myJv.VouNo = int.Parse(txtVouNo.Text);
                                myJv.Bal = itm.Bal;
                                myJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "Updating Data Done Successfully";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            string vNumber = txtVouNo.Text;
                            BtnClear_Click(sender, e);
                            PrintMe(vNumber);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "Error During Updating Data...Try Again";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }
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
                if (Page.IsValid)
                {
                    PReq myJv = new PReq();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.VouLoc = short.Parse(StoreNo);
                    myJv.VouNo = int.Parse(txtVouNo.Text);                    
                    myJv = myJv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myJv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "Request No. Not Found";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }
                    else
                    {
                        bool vOutQuan = false;
                        foreach(vPReq itm in VouData)
                        {
                            vOutQuan = (itm.Quan2 > 0);
                            if (vOutQuan) break;
                        }

                        if (vOutQuan)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "Request No. Related to Purchase Order";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }

                        if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.Description = "Delete Request No. " + txtVouNo.Text;
                            UserTran.FormAction = "Delete";
                            UserTran.FormName = "Purchase Request";
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);


                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "Deleting Data Done Sucessfully";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "Error While Deleteing Data...Try Again";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        }
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
                if (txtVouNo.Text != "")
                {
                    //string vs = txtSearch.Text;
                    //BtnClear_Click(sender, e);
                    //txtSearch.Text = vs;

                    string vs = txtVouNo.Text;
                    BtnClear_Click(sender, e);
                    txtVouNo.Text = vs;

                    PReq myJv = new PReq();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.VouLoc = short.Parse(StoreNo);
                    myJv.VouNo = int.Parse(txtVouNo.Text);                    
                    myJv = myJv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myJv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "Request No. Not Found";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                    else
                    {
                        EditMode();
                        txtVouDate.Text = myJv.VouDate;
                        txtUserDate.Text = myJv.UserDate;
                        txtUserName.ToolTip = myJv.UserName;
                        txtJobOrder.Text = myJv.JobOrder.ToString();
                        txtRemark.Text = myJv.Remark;
                        TblUsers ax = new TblUsers();
                        if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        ax.UserName = myJv.UserName;
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

                        lblStatus.Text = "";
                        PO mypo = new PO();
                        mypo.Branch = short.Parse(Session["Branch"].ToString());
                        mypo.RefNoLoc = short.Parse(StoreNo);
                        mypo.RefNo = int.Parse(txtVouNo.Text);
                        foreach (PO itm in mypo.FindRef2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (lblStatus.Text == "") lblStatus.Text = "Releated to PO# :" + @"<a href='WebPurchaseOrder.aspx?Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + @"' target='_blank'>" + itm.VouNo.ToString() + @"</a>";
                            else lblStatus.Text += @"&nbsp;&nbsp;&nbsp;" + @"<a href='WebPurchaseOrder.aspx?Flag=0&AreaNo=" + moh.MakeMask(itm.VouLoc.ToString(), 5) + "&StoreNo=" + StoreNo + "&FNum=" + itm.VouNo.ToString() + @"' target='_blank'>" + itm.VouNo.ToString() + @"</a>";
                        }
                        VouData = myJv.Find20(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        LoadVouData();
                        MakeSum();
                        LoadAttachData();
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم القيد";
                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
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

        public void PrintMe(String Number)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=201&AreaNo=" + StoreNo + "&Number=" + Number + "');</script>", false);
            return;
        }

        protected void BtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    string vNumber = txtVouNo.Text;
                    PrintMe(vNumber);
                    /*
                    iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, -50, -50, 80, 50);
                    HttpContext.Current.Response.ContentType = "application/pdf";
                    PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
                    pdfPage page = new pdfPage();
                    writer.PageEvent = page;
                    MyConfig mySetting = new MyConfig();
                    mySetting.Branch = short.Parse(Session["Branch"].ToString());
                    mySetting = mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (mySetting != null)
                    {
                        page.vComapnyName = mySetting.CompanyName;
                    }
                    page.vStr1 = txtVouNo.Text;
                    page.vStr2 = txtVouDate.Text;
                    page.PageNo = "1";
                    page.UserName = Session["FullUser"].ToString();
                    int ColCount = 6;
                    var cols = new[] { 150, 75, 285, 90, 100, 100 };
                    document.Open();
                    PdfPTable table = new PdfPTable(ColCount);
                    table.TotalWidth = document.PageSize.Width; //100f;
                    table.SetWidths(cols);
                    PdfPCell cell = new PdfPCell();
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    string arialunicodepath = Server.MapPath("Fonts") + @"\arial.ttf";
                    BaseFont nationalBase;
                    nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);

                    double TotalDB = 0, TotalCr = 0;
                    foreach (Vou itm in VouData)
                    {
                        TotalDB += (double)itm.Debit;
                        cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Debit), nationalTextFont);
                        table.AddCell(cell);

                        TotalCr += (double)itm.Credit;
                        cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Credit), nationalTextFont);
                        table.AddCell(cell);

                        cell.Phrase = new iTextSharp.text.Phrase(itm.Code, nationalTextFont);
                        table.AddCell(cell);

                        PdfPTable headerTbl2 = new PdfPTable(1);

                        headerTbl2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                        headerTbl2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        PdfPCell cell3 = new PdfPCell(headerTbl2);
                        cell3.ArabicOptions = ColumnText.DIGITS_EN2AN;
                        //cell3.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        cell3.PaddingRight = 0;                    
                        PdfPCell cell2 = new PdfPCell();
                        //cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                        cell2.Phrase = new iTextSharp.text.Phrase(itm.Name, nationalTextFont);
                        cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        cell2.Border = 0;
                        headerTbl2.AddCell(cell2);
                        cell2.Phrase = new iTextSharp.text.Phrase(itm.Remark, nationalTextFont);
                        headerTbl2.AddCell(cell2);
                        table.AddCell(cell3);

                        cell.Phrase = new iTextSharp.text.Phrase(itm.InvNo, nationalTextFont);
                        table.AddCell(cell);


                        PdfPTable headerTbl3 = new PdfPTable(1);
                        headerTbl3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                        headerTbl3.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                        PdfPCell cell30 = new PdfPCell(headerTbl3);
                        cell30.ArabicOptions = ColumnText.DIGITS_EN2AN;
                        //cell30.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        cell30.PaddingRight = 0;
                        PdfPCell cell20 = new PdfPCell();
                        //cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        cell20.Phrase = new iTextSharp.text.Phrase(itm.Area, nationalTextFont);
                        cell20.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                        cell20.ArabicOptions = ColumnText.DIGITS_EN2AN;
                        cell20.Border = 0;
                        headerTbl3.AddCell(cell20);
                        cell20.Phrase = new iTextSharp.text.Phrase(itm.CostCenter, nationalTextFont);
                        headerTbl3.AddCell(cell20);
                        cell20.Phrase = new iTextSharp.text.Phrase(itm.Project, nationalTextFont);
                        headerTbl3.AddCell(cell20);
                        cell20.Phrase = new iTextSharp.text.Phrase(itm.CostAcc, nationalTextFont);
                        headerTbl3.AddCell(cell20);
                        cell20.Phrase = new iTextSharp.text.Phrase(itm.Emp, nationalTextFont);
                        headerTbl3.AddCell(cell20);
                        table.AddCell(cell30);

                        document.Add(table);
                        table.Rows.Clear();
                    }
                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", TotalDB), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", TotalCr), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("الاجمالي", nationalTextFont);
                    table.AddCell(cell);
                    cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    table.AddCell(cell);

                    document.Add(table);

                    //document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));

                    PdfPTable table5 = new PdfPTable(4);
                    table5.TotalWidth = 100f;

                    var cols5 = new[] { 175, 75, 175, 75 };
                    table5.SetWidths(cols5);
                    PdfPCell cell5 = new PdfPCell();
                    cell5.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    table5.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table5.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    cell5.Phrase = new iTextSharp.text.Phrase("إدخلت بواسطة", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    //cell.Border = 0;
                    table5.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase(txtUserName.Text, nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table5.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("تاريخ الإدخال", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table5.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase(txtUserDate.Text, nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table5.AddCell(cell5);

                    document.Add(table5);
                    document.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));

                    PdfPTable table50 = new PdfPTable(5);
                    table50.TotalWidth = 100f;
                    cell5 = new PdfPCell();
                    cols5 = new[] { 75, 200, 200, 200, 75 };
                    table50.SetWidths(cols5);
                    cell5.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    table50.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table50.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    cell5.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                    cell5.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("رئيس الحسابات", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell5.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("  ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.Border = 0;
                    table50.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("المحاسب", nationalTextFont);
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

                    document.Close();
                     */
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
            }
        }


        // *************************************************** ITextSharp ****************************************************************
        /*
        public class pdfPage : iTextSharp.text.pdf.PdfPageEventHelper
        {
            public string vStr1, vStr2, vStr3, vStr4, UserName, PageNo, vComapnyName;
            //I create a font object to use within my footer
            protected iTextSharp.text.Font footer
            {
                get
                {
                    // create a basecolor to use for the footer font, if needed.
                    iTextSharp.text.BaseColor grey = new iTextSharp.text.BaseColor(128, 128, 128);
                    string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\arial.ttf";
                    BaseFont nationalBase;
                    nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(nationalBase, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.WHITE);
                    return font;
                }
            }
            //override the OnStartPage event handler to add our header
            public override void OnStartPage(PdfWriter writer, iTextSharp.text.Document doc)
            {
                string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\DTNASKH1.TTF";
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 16f, iTextSharp.text.Font.NORMAL);

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
                cell2.PaddingRight = 15;
                cell2.Phrase = new iTextSharp.text.Phrase(vComapnyName, nationalTextFont);
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                headerTbl.AddCell(cell2);

                cell2.PaddingRight = 0;
                cell2.Phrase = new iTextSharp.text.Phrase("قيد يومية", nationalTextFont);
                cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                headerTbl.AddCell(cell2);

                //I use an image logo in the header so I need to get an instance of the image to be able to insert it. I believe this is something you couldn't do with older versions of iTextSharp
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("images/logo2.jpg"));

                //I used a large version of the logo to maintain the quality when the size was reduced. I guess you could reduce the size manually and use a smaller version, but I used iTextSharp to reduce the scale. As you can see, I reduced it down to 7% of original size.
                logo.ScalePercent(30);

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

                arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\arial.ttf";
                //BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                nationalTextFont = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);

                if (vStr1 != "")
                {
                    PdfPTable table5 = new PdfPTable(4);
                    table5.TotalWidth = 100f;

                    var cols5 = new[] { 175, 75, 175, 75 };
                    table5.SetWidths(cols5);
                    PdfPCell cell5 = new PdfPCell();
                    cell5.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    table5.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table5.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    cell5.Phrase = new iTextSharp.text.Phrase("رقم القيد", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    //cell.Border = 0;
                    table5.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase(vStr1, nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table5.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase("التاريخ", nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table5.AddCell(cell5);

                    cell5.Phrase = new iTextSharp.text.Phrase(vStr2, nationalTextFont);
                    cell5.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table5.AddCell(cell5);

                    doc.Add(table5);
                    doc.Add(new iTextSharp.text.Phrase("            ", nationalTextFont));
                    vStr1 = "";
                }

                PdfPTable table = new PdfPTable(6);
                table.TotalWidth = doc.PageSize.Width;

                var cols = new[] { 150, 75, 285, 90, 100, 100 };
                table.SetWidths(cols);
                PdfPCell cell = new PdfPCell();
                cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                cell.Phrase = new iTextSharp.text.Phrase("مدين", nationalTextFont);
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("دائن", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("رقم الحساب", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("الحساب / شرح القيد", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("رقم المستند", nationalTextFont);
                table.AddCell(cell);

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
                var cols2 = new[] { 200, 200, 200, 200 };
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
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                //set cell border to 0
                cell.Border = 2;

                //add some padding to bring away from the edge
                cell.PaddingRight = 5;
                cell.Phrase = new iTextSharp.text.Phrase("تاريخ الطباعة : " + String.Format("{0:dd/MM/yyyy}", moh.Nows()), footer);
                //add cell to table
                footerTbl.AddCell(cell);

                //create new instance of cell to hold the text
                //cell = new PdfPCell();

                //align the text to the right of the cell
                //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell.Phrase = new iTextSharp.text.Phrase("طبعت بواسطة " + UserName, footer);

                // add some padding to take away from the edge of the page
                //cell.PaddingRight = 5;

                //add the cell to the table
                footerTbl.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("عدد مرات الطباعة " + PageNo, footer);
                footerTbl.AddCell(cell);

                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell.Phrase = new iTextSharp.text.Phrase("صفحة رقم " + writer.PageNumber.ToString(), footer);

                // add some padding to take away from the edge of the page
                cell.PaddingLeft = 5;

                //add the cell to the table
                footerTbl.AddCell(cell);

                //write the rows out to the PDF output stream.
                footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin - 10), writer.DirectContent);
            }
        }
        */

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
                        myArch.DocType = 901;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(StoreNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 901;
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
                myArch.DocType = 901;
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
            myArch.DocType = 901;
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

        protected void ddlUnit2_Init(object sender, EventArgs e)
        {
            DropDownList ddlUnit2 = sender as DropDownList;
            if (ddlUnit2.Items.Count == 0)
            {
                GridViewRow gvr = ddlUnit2.NamingContainer as GridViewRow;
                if (gvr != null && gvr.RowIndex>-1)
                {
                    string FNo = grdCodes.DataKeys[gvr.RowIndex]["FNo"].ToString();
                    IUnit myUnit = new IUnit();
                    myUnit.Branch = short.Parse(Session["Branch"].ToString());
                    ddlUnit2.DataTextField = "Name2";
                    ddlUnit2.DataValueField = "Code";
                    ddlUnit2.DataSource = myUnit.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlUnit2.DataBind();
                    ddlUnit2.Items.Insert(0, new ListItem("Select Unit", "-1", true));
                    if (VouData[int.Parse(FNo) - 1].UnitCode != "") ddlUnit2.SelectedValue = VouData[int.Parse(FNo) - 1].UnitCode;
                }
            }
        }

        protected void ddlApproved_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddlApproved = sender as DropDownList;
                GridViewRow gvr = ddlApproved.NamingContainer as GridViewRow;
                string FNo = grdCodes.DataKeys[gvr.RowIndex]["FNo"].ToString();

                PReq myPo = new PReq();
                myPo.Branch = short.Parse(Session["Branch"].ToString());
                myPo.VouLoc = short.Parse(StoreNo);
                myPo.VouNo = int.Parse(txtVouNo.Text);
                myPo.FNo = short.Parse(FNo);
                myPo.Approved = short.Parse(ddlApproved.SelectedValue);
                myPo.UpdateStatus(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                VouData[myPo.FNo - 1].Approved = myPo.Approved;
                LoadVouData();
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }

        }

        protected void BtnUnlock_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "9999999")
            {
                if (BtnUnlock.ToolTip == "")
                {
                    BtnUnlock.Text = "Lock";
                    BtnUnlock.ToolTip = "1";
                }
                else
                {
                    BtnUnlock.Text = "UnLock";
                    BtnUnlock.ToolTip = "";
                }
                txtPassword.Text = "";
                LoadVouData();
            }
        }

        protected void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtItemCode.Text != "")
                {
                    string vResult = PutItem(txtItemCode.Text, true);
                    if (vResult != "")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = txtItemCode.Text + " " + vResult;
                    }
                    else
                    {
                        MakeSum();
                        LoadVouData();

                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = txtItemCode.Text + " Adding Item done Successfully";
                    }
                    txtItemCode.Text = "";
                    txtItemCode.Focus();
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        public string PutItem(string ItemCode, bool CodeType)
        {
            double Quan = 1;
            if (ItemCode.Contains("-"))
            {
                Quan = double.Parse(ItemCode.Split('-')[1]);
                ItemCode = ItemCode.Split('-')[0];
            }

            Item myItem = new Item();
            myItem.Branch = short.Parse(Session["Branch"].ToString());
            myItem.FType = 1;
            myItem.ITCode2 = ItemCode;
            myItem = myItem.GetByITCode2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
            if (myItem == null)
            {
                myItem = new Item();
                myItem.Branch = short.Parse(Session["Branch"].ToString());
                myItem.FType = 1;
                myItem.ITCode = ItemCode;
                myItem = myItem.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myItem == null)
                {
                    return "Stock Item Not Found";
                }
            }

            bool vFound = false;
            foreach (vPReq eitm in VouData)
            {
                if (eitm.ITCode == myItem.ITCode)
                {
                    vFound = true;
                    eitm.Quan += Quan;
                    break;
                }
            }

            if (!vFound)
            {
                vPReq myAccess = new vPReq();
                myAccess.FNo = (short)(VouData.Count + 1);
                myAccess.VouLoc = short.Parse(StoreNo);
                myAccess.Branch = short.Parse(Session["Branch"].ToString());
                myAccess.ITCode = myItem.ITCode;
                myAccess.ITName1 = myItem.ITName1;
                myAccess.ITName2 = myItem.ITName2;
                myAccess.UnitCode = myItem.ITUnit1; ;
                IUnit myUnit = new IUnit();
                myUnit.Branch = short.Parse(Session["Branch"].ToString());
                myUnit.Code = myItem.ITUnit1;
                myUnit = myUnit.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myUnit != null)
                {
                    myAccess.UnitName1 = myUnit.Name1;
                    myAccess.UnitName2 = myUnit.Name2;
                }
                myAccess.Quan = Quan;
                Stock myStock = new Stock();
                myStock.Branch = short.Parse(Session["Branch"].ToString());
                myStock.Number = short.Parse(StoreNo);
                myStock.Code = myItem.ITCode;
                myStock = myStock.GetItem(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myStock != null) myAccess.Bal = myStock.IOpen + myStock.IPurch - myStock.ISale;
                myAccess.Remark = txtRemark.Text;
                VouData.Add(myAccess);
            }
            return "";
        }            




        [WebMethod]
        public string[] GetCompletionStock(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            Item myItem = new Item();
            myItem.Branch = 1;
            if (Cache["Items" + Session["CNN2"].ToString()] == null) Cache.Insert("Items" + Session["CNN2"].ToString(), myItem.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

            List<string> items = new List<string>();
                items = (from itm in (List<Item>)(Cache["Items" + Session["CNN2"].ToString()])
                         where itm.ITCode.Contains(prefixText)
                         select itm.ITCode + " . " + itm.ITName2).ToList();

            return items.Take(count).ToArray();
        }
    }
    
}