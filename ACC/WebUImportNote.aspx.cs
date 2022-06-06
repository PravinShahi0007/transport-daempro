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
using System.Configuration;

namespace ACC
{
    public partial class WebUImportNote : System.Web.UI.Page
    {
        public List<vSTP> VouData
        {
            get
            {
                if (ViewState["VouData"] == null)
                {
                    ViewState["VouData"] = new List<vSTP>();
                }
                return (List<vSTP>)ViewState["VouData"];
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
                    ViewState["StoreNo"] = "00001";
                }
                return ViewState["StoreNo"].ToString();
            }
            set { ViewState["StoreNo"] = value; }
        }
        public Shop ShopArea
        {
            get
            {
                if (ViewState["ShopArea"] == null)
                {
                    ViewState["ShopArea"] = new Shop();
                }
                return (Shop)ViewState["ShopArea"];
            }
            set
            {
                ViewState["ShopArea"] = value;
            }
        }

        public void EditMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = true; // && (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass355;
            BtnEdit.Visible = true; // && (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass352;
            BtnNew.Visible = false;
            BtnDelete.Visible = true; // && (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass353;

        }

        public void NewMode()
        {
            txtVouNo.ReadOnly = false;
            txtVouNo.BackColor = System.Drawing.Color.White;

            BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = true;  // && (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass351;
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
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttach);

                if (!Page.IsPostBack)
                {
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
                    this.Page.Header.Title = "Used Import Note";

                    ShopArea.FType = 2;
                    ShopArea.Bran = short.Parse(Session["Branch"].ToString());
                    ShopArea.Number = short.Parse(StoreNo);
                    ShopArea.GetShop(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    Cars myCar = new Cars();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlCar.DataTextField = "CarType2";
                    ddlCar.DataValueField = "Code";
                    ddlCar.DataSource = (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()]);
                    ddlCar.DataBind();
                    ddlCar.Items.Insert(0, new ListItem("--- Select Car ---", "-1", true));

                    //BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass351;
                    //BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass352;
                    //BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass353;
                    //BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass354;
                    //BtnPrint.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass355;
                    //BtnFind.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass354;

                    if (Request.QueryString["FNum"] != null)
                    {
                        txtVouNo.Text = Request.QueryString["FNum"].ToString();
                        BtnSearch_Click(sender, null);

                        if (Request.QueryString["FType"] != null)
                        {
                            if (Request.QueryString["FType"].ToString() == "1")
                            {
                                txtAgreeRemark1.Enabled = true;
                                chkAgree1.Enabled = true;
                            }
                            else if (Request.QueryString["FType"].ToString() == "2")
                            {
                                txtAgreeRemark2.Enabled = true;
                                chkAgree2.Enabled = true;
                            }
                        }
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

        protected void LoadVouData()
        {
            try
            {
                grdCodes.DataSource = VouData;
                grdCodes.DataBind();

                if (grdCodes.Rows.Count < 1)
                {
                    vSTP ax = new vSTP();
                    VouData.Add(ax);
                    grdCodes.DataSource = VouData;
                    grdCodes.DataBind();
                    grdCodes.Rows[0].Controls.Clear();
                    grdCodes.Rows[0].Cells.Clear();
                    VouData.Remove(ax);
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
                    TextBox txtPrice2 = gvr.FindControl("txtPrice2") as TextBox;

                    if (txtITCode2 == null || txtITName2 == null || ddlUnit2 == null || txtQuan2 == null || txtPrice2 == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "Error During Adding Data ... Try Again";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    if (txtQuan2.Text == "") txtQuan2.Text = "0.00";
                    if (txtPrice2.Text == "") txtPrice2.Text = "0.00";

                    if (double.Parse(txtQuan2.Text) == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "You Should Enter Qty.";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }

                    if (double.Parse(txtPrice2.Text) == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "You Should Enter Price";
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
                        if (ddlUnit2.SelectedIndex <= 0 || (ddlUnit2.SelectedValue != myItem.ITUnit1 && ddlUnit2.SelectedValue != myItem.ITUnit2)) ddlUnit2.SelectedValue = myItem.ITUnit1;
                    }

                    vSTP myAccess = new vSTP();
                    myAccess.FNo = (short)(VouData.Count + 1);
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
                    myAccess.Price = double.Parse(txtPrice2.Text);
                    myAccess.Remark = txtRemark.Text;
                    myAccess.InvType = 0;
                    vStock myStock = new vStock();
                    myStock.Branch = short.Parse(Session["Branch"].ToString());
                    myStock.Number = short.Parse(StoreNo);
                    myStock.Code = txtITCode2.Text;
                    myStock = myStock.GetStockItem(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myStock != null)
                    {
                        myAccess.Bal = myStock.IOpen + myStock.IPurch - myStock.ISale;
                        myAccess.CrCode = myItem.ITCode == "000001S" || myItem.ITCode == "000002S" || myItem.ITCode == "000003S" ? "420103001" : "420103005";
                        myAccess.DbCode = ShopArea.CPur_Acc + moh.MakeMask(StoreNo, 2) + myStock.CPur_Acc;
                    }

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
            double Amount = 0;
            foreach (vSTP itm in VouData)
            {
                Quan += (double)itm.Quan;
                Amount += itm.Amount;
            }
            lblTotalQty.Text = string.Format("{0:N2}", Quan);
            LblTotal.Text = string.Format("{0:N2}", Amount);
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

        protected void BtnClear_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                NewMode();
                txtVouNo.Text = "";
                txtVouDate.Text = "";
                txtCarNo.Text = "";
                txtRefNo.Text = "";
                ddlCar.SelectedIndex = 0;
                txtRemark.Text = "";
                lblTotalQty.Text = "";
                LblCodesResult.Text = "";
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));

                if (sender != null)
                {
                    STP myJv = new STP();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.VouLoc = short.Parse(StoreNo);
                    myJv.Ftype = 503;
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
                VouData.Clear();
                LoadVouData();
                LoadAttachData();

                txtAgreeRemark1.Enabled = false;
                chkAgree1.Enabled = false;
                txtAgreeRemark2.Enabled = false;
                chkAgree2.Enabled = false;

                txtAgreeRemark1.Text = "";
                txtAgreeRemark2.Text = "";
                txtAgreeUser1.Text = "";
                txtAgreeUser2.Text = "";
                txtAgreeUserDate1.Text = "";
                txtAgreeUserDate2.Text = "";
                chkAgree1.Checked = false;
                chkAgree2.Checked = false;
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
                    if (!CheckRef()) return;
                    if (lblTotalQty.Text == "" || double.Parse(lblTotalQty.Text) == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "No Qty to Save";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    STP myJv = new STP();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.Ftype = 503;
                    myJv.VouLoc = short.Parse(StoreNo);
                    myJv.VouNo = int.Parse(txtVouNo.Text);
                    myJv = myJv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myJv != null)
                    {
                        if (myJv.UserName == txtUserName.ToolTip)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "Duplicate Note No.";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            return;
                        }
                        else
                        {
                            myJv = new STP();
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.VouLoc = short.Parse(StoreNo);
                            myJv.Ftype = 503;
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
                    }

                    foreach (vSTP itm in VouData)
                    {
                        myJv = new STP();
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.VouLoc = short.Parse(StoreNo);
                        myJv.Ftype = 503;
                        myJv.FNo = itm.FNo;
                        myJv.ITCode = itm.ITCode;
                        myJv.RefNo = int.Parse(txtRefNo.Text);
                        myJv.Quan = itm.Quan;
                        myJv.Price = itm.Price;
                        myJv.Remark = txtRemark.Text;
                        myJv.UnitCode = itm.UnitCode;
                        myJv.UserName = txtUserName.ToolTip;
                        myJv.UserDate = txtUserDate.Text;
                        myJv.VouDate = moh.CheckDate(txtVouDate.Text);
                        myJv.VouNo = int.Parse(txtVouNo.Text);
                        myJv.DbCode = itm.DbCode;
                        myJv.CrCode = itm.CrCode;
                        myJv.InvType = 0;
                        myJv.ExpRef = ddlCar.SelectedValue;
                        myJv.ExpPer = 0;
                        myJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }

                    List<vSTP> myList = new List<vSTP>();
                    myList = (from itm in VouData
                              group itm by new { itm.DbCode }
                                  into g
                                  select new vSTP
                                  {
                                      DbCode = g.Key.DbCode,
                                      ExpAmount = g.Sum(p => (p.Price * p.Quan))
                                  }).ToList();

                    short FNo = 1;
                    foreach (vSTP itm in myList)
                    {
                        if (itm.ExpAmount != 0)
                        {
                            Jv mJv = new Jv();
                            mJv.Branch = short.Parse(Session["Branch"].ToString());
                            mJv.FType = 503;
                            mJv.LocType = 2;
                            mJv.LocNumber = short.Parse(StoreNo);
                            mJv.Number = int.Parse(txtVouNo.Text);
                            mJv.FNo = FNo;
                            mJv.Post = 1;
                            mJv.DbCode = itm.DbCode;  // Here Account;
                            mJv.CrCode = "";
                            mJv.FDate = moh.CheckDate(txtVouDate.Text);
                            mJv.Amount = Math.Round((double)itm.ExpAmount, 2); // here amount
                            mJv.ChequeNo = "";
                            mJv.ChequeDate = "";
                            mJv.InvNo = txtRefNo.Text;
                            mJv.Remark = txtRemark.Text;
                            mJv.Seller = -1;
                            mJv.Project = "-1";
                            mJv.BankName = "";
                            mJv.CostCenter = "-1";
                            mJv.UserName = txtUserName.ToolTip;
                            mJv.UserDate = txtUserDate.Text;
                            mJv.EmpCode = "-1";
                            mJv.Area = "-1";
                            mJv.CostAcc = "-1";
                            mJv.CarNo = "-1";
                            mJv.DocType = 0;
                            mJv.FNo2 = 0;
                            FNo++;
                            mJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                    }

                    myList = new List<vSTP>();
                    myList = (from itm in VouData
                              group itm by new { itm.CrCode }
                                  into g
                                  select new vSTP
                                  {
                                      CrCode = g.Key.CrCode,
                                      ExpAmount = g.Sum(p => (p.Price * p.Quan))
                                  }).ToList();

                    foreach (vSTP itm in myList)
                    {
                        if (itm.ExpAmount != 0)
                        {
                            Jv mJv2 = new Jv();
                            mJv2.Branch = short.Parse(Session["Branch"].ToString());
                            mJv2.FType = 503;
                            mJv2.LocType = 2;
                            mJv2.LocNumber = short.Parse(StoreNo);
                            mJv2.Number = int.Parse(txtVouNo.Text);
                            mJv2.FNo = FNo;
                            FNo++;
                            mJv2.Post = 1;
                            mJv2.DbCode = "";
                            mJv2.CrCode = itm.CrCode;
                            mJv2.FDate = moh.CheckDate(txtVouDate.Text);
                            mJv2.Amount = Math.Round((double)itm.ExpAmount, 2); // here amount
                            mJv2.ChequeNo = "";
                            mJv2.ChequeDate = "";
                            mJv2.InvNo = txtRefNo.Text;
                            mJv2.Remark = txtRemark.Text;
                            mJv2.Seller = -1;
                            mJv2.Project = "00001";
                            mJv2.BankName = "";
                            mJv2.CostCenter = "00017";
                            mJv2.UserName = txtUserName.ToolTip;
                            mJv2.UserDate = txtUserDate.Text;
                            mJv2.EmpCode = "-1";
                            mJv2.Area = "00001";
                            mJv2.CostAcc = "00002";
                            mJv2.CarNo = ddlCar.SelectedValue;
                            mJv2.DocType = 0;
                            mJv2.FNo2 = 0;
                            mJv2.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                    }

                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult.Text = "Adding Data Done Successfully";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                    string vNumber = txtVouNo.Text;
                    BtnClear_Click(sender, e);
                    PrintMe(vNumber);
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
                    if (!CheckRef()) return;
                    if (lblTotalQty.Text == "" || double.Parse(lblTotalQty.Text) == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "No Qty to Save";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    STP myJv = new STP();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.Ftype = 503;
                    myJv.VouLoc = short.Parse(StoreNo);
                    myJv.VouNo = int.Parse(txtVouNo.Text);
                    myJv = myJv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myJv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "Note No. Not Found";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }
                    else
                    {
                        if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            Jv mJv2 = new Jv();
                            mJv2.Branch = short.Parse(Session["Branch"].ToString());
                            mJv2.FType = 503;
                            mJv2.LocType = 2;
                            mJv2.LocNumber = short.Parse(StoreNo);
                            mJv2.Number = int.Parse(txtVouNo.Text);
                            mJv2.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            foreach (vSTP itm in VouData)
                            {
                                myJv = new STP();
                                myJv.Ftype = 503;
                                myJv.Branch = short.Parse(Session["Branch"].ToString());
                                myJv.VouLoc = short.Parse(StoreNo);
                                myJv.FNo = itm.FNo;
                                myJv.ITCode = itm.ITCode;
                                myJv.RefNo = int.Parse(txtRefNo.Text);
                                myJv.Quan = itm.Quan;
                                myJv.Price = itm.Price;
                                myJv.Remark = txtRemark.Text;
                                myJv.UnitCode = itm.UnitCode;
                                myJv.UserName = txtUserName.ToolTip;
                                myJv.UserDate = txtUserDate.Text;
                                myJv.VouDate = moh.CheckDate(txtVouDate.Text);
                                myJv.VouNo = int.Parse(txtVouNo.Text);
                                myJv.InvType = 0;
                                myJv.CrCode = "";
                                myJv.ExpAmount = 0;
                                myJv.ExpRef = ddlCar.SelectedValue;
                                myJv.DbCode = itm.DbCode;
                                myJv.CrCode = itm.CrCode;
                                myJv.ExpPer = 0;
                                myJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }

                            List<vSTP> myList = new List<vSTP>();
                            myList = (from itm in VouData
                                      group itm by new { itm.DbCode }
                                          into g
                                          select new vSTP
                                          {
                                              DbCode = g.Key.DbCode,
                                              ExpAmount = g.Sum(p => (p.Price * p.Quan))
                                          }).ToList();

                            short FNo = 1;
                            foreach (vSTP itm in myList)
                            {
                                if (itm.ExpAmount != 0)
                                {
                                    Jv mJv = new Jv();
                                    mJv.Branch = short.Parse(Session["Branch"].ToString());
                                    mJv.FType = 503;
                                    mJv.LocType = 2;
                                    mJv.LocNumber = short.Parse(StoreNo);
                                    mJv.Number = int.Parse(txtVouNo.Text);
                                    mJv.FNo = FNo;
                                    mJv.Post = 1;
                                    mJv.DbCode = itm.DbCode;  // Here Account;
                                    mJv.CrCode = "";
                                    mJv.FDate = moh.CheckDate(txtVouDate.Text);
                                    mJv.Amount = Math.Round((double)itm.ExpAmount, 2); // here amount
                                    mJv.ChequeNo = "";
                                    mJv.ChequeDate = "";
                                    mJv.InvNo = txtRefNo.Text;
                                    mJv.Remark = txtRemark.Text;
                                    mJv.Seller = -1;
                                    mJv.Project = "-1";
                                    mJv.BankName = "";
                                    mJv.CostCenter = "-1";
                                    mJv.UserName = txtUserName.ToolTip;
                                    mJv.UserDate = txtUserDate.Text;
                                    mJv.EmpCode = "-1";
                                    mJv.Area = "-1";
                                    mJv.CostAcc = "-1";
                                    mJv.CarNo = "-1";
                                    mJv.DocType = 0;
                                    mJv.FNo2 = 0;
                                    FNo++;
                                    mJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                }
                            }

                            myList = new List<vSTP>();
                            myList = (from itm in VouData
                                      group itm by new { itm.CrCode }
                                          into g
                                          select new vSTP
                                          {
                                              CrCode = g.Key.CrCode,
                                              ExpAmount = g.Sum(p => (p.Price * p.Quan))
                                          }).ToList();

                            foreach (vSTP itm in myList)
                            {
                                if (itm.ExpAmount != 0)
                                {
                                    mJv2 = new Jv();
                                    mJv2.Branch = short.Parse(Session["Branch"].ToString());
                                    mJv2.FType = 503;
                                    mJv2.LocType = 2;
                                    mJv2.LocNumber = short.Parse(StoreNo);
                                    mJv2.Number = int.Parse(txtVouNo.Text);
                                    mJv2.FNo = FNo;
                                    FNo++;
                                    mJv2.Post = 1;
                                    mJv2.DbCode = "";
                                    mJv2.CrCode = itm.CrCode;
                                    mJv2.FDate = moh.CheckDate(txtVouDate.Text);
                                    mJv2.Amount = Math.Round((double)itm.ExpAmount, 2); // here amount
                                    mJv2.ChequeNo = "";
                                    mJv2.ChequeDate = "";
                                    mJv2.InvNo = txtRefNo.Text;
                                    mJv2.Remark = txtRemark.Text;
                                    mJv2.Seller = -1;
                                    mJv2.Project = "00001";
                                    mJv2.BankName = "";
                                    mJv2.CostCenter = "00017";
                                    mJv2.UserName = txtUserName.ToolTip;
                                    mJv2.UserDate = txtUserDate.Text;
                                    mJv2.EmpCode = "-1";
                                    mJv2.Area = "00001";
                                    mJv2.CostAcc = "00002";
                                    mJv2.CarNo = ddlCar.SelectedValue;
                                    mJv2.DocType = 0;
                                    mJv2.FNo2 = 0;
                                    mJv2.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                }
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
                    STS myJv = new STS();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.Ftype = 503;
                    myJv.VouLoc = short.Parse(StoreNo);
                    myJv.VouNo = int.Parse(txtVouNo.Text);
                    myJv = myJv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myJv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "Note No. Not Found";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }
                    else
                    {
                        if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            Jv mJv2 = new Jv();
                            mJv2.Branch = short.Parse(Session["Branch"].ToString());
                            mJv2.FType = 503;
                            mJv2.LocType = 2;
                            mJv2.LocNumber = short.Parse(StoreNo);
                            mJv2.Number = int.Parse(txtVouNo.Text);
                            mJv2.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.Description = "Delete Used Import Note No. " + txtVouNo.Text;
                            UserTran.FormAction = "Delete";
                            UserTran.FormName = "Used Import Note";
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

                    STP myJv = new STP();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.Ftype = 503;
                    myJv.VouLoc = short.Parse(StoreNo);
                    myJv.VouNo = int.Parse(txtVouNo.Text);
                    myJv = myJv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myJv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "Note No. Not Found";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }
                    else
                    {
                        EditMode();
                        txtVouDate.Text = myJv.VouDate;
                        txtUserDate.Text = myJv.UserDate;
                        txtUserName.ToolTip = myJv.UserName;
                        txtRefNo.Text = myJv.RefNo.ToString();
                        txtRemark.Text = myJv.Remark;
                        if (myJv.ExpRef == "-1" || myJv.ExpRef == "")
                        {
                            ddlCar.SelectedValue = "-1";
                        }
                        else
                        {
                            if (ddlCar.Items.FindByValue(myJv.ExpRef) == null)
                            {
                                ddlCar.Items.Add(new ListItem(myJv.ExpRef, myJv.ExpRef));
                            }
                            ddlCar.SelectedValue = myJv.ExpRef;
                            txtCarNo.Text = myJv.ExpRef;
                        }
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
                        VouData = myJv.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        LoadVouData();
                        MakeSum();
                        LoadAttachData();

                        Agreement myAgree = new Agreement();
                        myAgree.FType = 503;
                        myAgree.LocType = 3;
                        myAgree.LocNumber = short.Parse(StoreNo);
                        myAgree.Number = int.Parse(txtVouNo.Text);
                        foreach (Agreement itm in myAgree.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (itm.FNo == 1)
                            {
                                txtAgreeRemark1.Text = itm.AgreeRemark;
                                chkAgree1.Checked = (itm.Agree == 1);
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
                            }
                            else if (itm.FNo == 2)
                            {
                                txtAgreeRemark2.Text = itm.AgreeRemark;
                                chkAgree2.Checked = (itm.Agree == 1);
                                txtAgreeUserDate2.Text = itm.AgreeUserDate;
                                txtAgreeUser2.ToolTip = itm.AgreeUser;

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
                            }
                        }

                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "You Should Enter Note No.";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=207&AreaNo=" + StoreNo + "&Number=" + Number + "');</script>", false);
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
                        myArch.DocType = 900;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(StoreNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 900;
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
                myArch.DocType = 900;
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
            myArch.DocType = 900;
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
                if (gvr != null && gvr.RowIndex > -1)
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

        protected void BtnFindCar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtCarNo.Text != "")
                {
                    txtCarNo.Text = moh.MakeMask(txtCarNo.Text, 5);
                    Cars myInv = new Cars();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myInv.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myInv.CarsType = int.Parse(ddlCar.SelectedValue.Substring(0, 2));
                    myInv.Code = txtCarNo.Text;
                    myInv = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                             where sitm.Code == myInv.Code
                             select sitm).FirstOrDefault();
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "Car No. Not Found";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    else
                    {
                        ddlCar.SelectedValue = txtCarNo.Text;
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "You Should Enter Car No.";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                }
                if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
            }
            catch (Exception)
            {
                /*
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
                 */
            }
        }

        protected void grdCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.EditIndex = grdCodes.SelectedIndex;
            LoadVouData();
        }

        protected void txtCarNo_TextChanged(object sender, EventArgs e)
        {
            BtnFindCar_Click(sender, null);
        }

        protected void chkAgree1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAgree1.Checked)
                {
                    txtAgreeUser1.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser1.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate1.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Agreement myAgree = new Agreement();
                    myAgree.FType = 503;
                    myAgree.LocType = 3;
                    myAgree.LocNumber = short.Parse(StoreNo);
                    myAgree.Number = int.Parse(txtVouNo.Text);
                    myAgree.FNo = 1;
                    myAgree.Agree = 1;
                    myAgree.AgreeRemark = txtAgreeRemark1.Text;
                    myAgree.AgreeUser = txtAgreeUser1.ToolTip;
                    myAgree.AgreeUserDate = txtAgreeUserDate1.Text;
                    if (myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "تم اعتماد المستند بنجاح";

                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.Description = "أعتماد سند الصرف رقم  " + txtVouNo.Text;
                        UserTran.FormAction = "أعتماد";
                        UserTran.FormName = "Issue Note";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, true), true);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "خطأ أثناء تعميد المستند ... حاول مرة أخرى";
                    }
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }

        }

        protected void chkAgree2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAgree2.Checked)
                {
                    txtAgreeUser2.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                    txtAgreeUser2.Text = Session["FullUser"].ToString();
                    txtAgreeUserDate2.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                    Agreement myAgree = new Agreement();
                    myAgree.FType = 503;
                    myAgree.LocType = 3;
                    myAgree.LocNumber = short.Parse(StoreNo);
                    myAgree.Number = int.Parse(txtVouNo.Text);
                    myAgree.FNo = 2;
                    myAgree.Agree = 1;
                    myAgree.AgreeRemark = txtAgreeRemark2.Text;
                    myAgree.AgreeUser = txtAgreeUser2.ToolTip;
                    myAgree.AgreeUserDate = txtAgreeUserDate2.Text;
                    if (myAgree.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "تم اعتماد المستند بنجاح";

                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.Description = "أعتماد سند الصرف رقم  " + txtVouNo.Text;
                        UserTran.FormAction = "أعتماد";
                        UserTran.FormName = "Issue Note";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, true), true);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "خطأ أثناء تعميد المستند ... حاول مرة أخرى";
                    }
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void ddlCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCar.SelectedIndex > 0)
                {
                    Cars myCar = new Cars();
                    myCar.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myCar.Code = ddlCar.SelectedValue;
                    myCar.CarsType = int.Parse(ddlCar.SelectedValue.Substring(0, 2));
                    myCar = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                             where sitm.Code == myCar.Code
                             select sitm).FirstOrDefault();
                    if (myCar != null)
                    {
                        txtCarNo.Text = myCar.Code;
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

        protected void txtRefNo_TextChanged(object sender, EventArgs e)
        {
            CheckRef();
        }


        public bool CheckRef()
        {
            JobWork myJv = new JobWork();
            myJv.Branch = short.Parse(Session["Branch"].ToString());
            myJv.VouLoc = short.Parse(StoreNo);
            myJv.VouNo = int.Parse(txtRefNo.Text);
            myJv = myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myJv == null)
            {
                txtRefNo.Text = "";
                txtCarNo.Text = "";
                ddlCar.SelectedIndex = 0;

                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "رقم بيان التشغيل غير معرف من قبل";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }
            else
            {
                if (myJv.Status != 0)
                {
                    txtRefNo.Text = "";
                    txtCarNo.Text = "";
                    ddlCar.SelectedIndex = 0;

                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "حالة بيان التشغيل غير مفتوح للصرف";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    return false;
                }
                else
                {
                    txtCarNo.Text = myJv.CarNo;
                    ddlCar.SelectedValue = myJv.CarNo;
                    ddlCar_SelectedIndexChanged(ddlCar, null);
                    return true;
                }
            }
        }
    }
}