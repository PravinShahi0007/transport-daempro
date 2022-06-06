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
    public partial class WebIssueNote : System.Web.UI.Page
    {
        public List<vSTS> VouData
        {
            get
            {
                if (ViewState["VouData"] == null)
                {
                    ViewState["VouData"] = new List<vSTS>();
                }
                return (List<vSTS>)ViewState["VouData"];
            }
            set
            {
                ViewState["VouData"] = value;
            }
        }

        public List<vSTS> VouData2
        {
            get
            {
                if (ViewState["VouData2"] == null)
                {
                    ViewState["VouData2"] = new List<vSTS>();
                }
                return (List<vSTS>)ViewState["VouData2"];
            }
            set
            {
                ViewState["VouData2"] = value;
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

            BtnPrint.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass355;
            BtnEdit.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass352;
            BtnNew.Visible = false;
            BtnDelete.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass353;

            Label8.Visible = BtnEdit.Visible;
            txtItemCode.Visible = BtnEdit.Visible;
        }

        public void NewMode()
        {
            txtVouNo.ReadOnly = false;
            txtVouNo.BackColor = System.Drawing.Color.White;

            BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass351;
            BtnDelete.Visible = false;

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
                    this.Page.Header.Title = "Issue Note";

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

                    BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass351;
                    BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass352;
                    BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass353;
                    BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass354;
                    BtnPrint.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass355;
                    BtnFind.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass354;

                   // BtnChPrice.Visible = (Session["CurrentUser"].ToString() == "Admin1");

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
                        if (Request.QueryString["ManInventory"] != null && Session["ManInventory"] != null)
                        {
                            ChkLost.Checked = true;
                            ChkLost_CheckedChanged(sender,e);
                            txtVouDate.Text = "31/12/"+((List<vyStock>)Session["ManInventory"])[0].FYear.Substring(6,4);
                            txtRemark.Text = "الاصناف التي بها عجز في الجرد عن " + ((List<vyStock>)Session["ManInventory"])[0].FYear.Substring(6, 4);
                            foreach (vyStock itm in (List<vyStock>)Session["ManInventory"])
                            {
                                if (itm.FDed > 0)
                                {
                                    Item myItem = new Item();
                                    myItem.Branch = short.Parse(Session["Branch"].ToString());
                                    myItem.FType = 1;
                                    myItem.ITCode = itm.Code;
                                    myItem = myItem.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (myItem != null)
                                    {

                                        string vUnitName1 = "", vUnitName2 = "";
                                        IUnit myUnit = new IUnit();
                                        myUnit.Branch = short.Parse(Session["Branch"].ToString());
                                        myUnit.Code = myItem.ITUnit1;
                                        myUnit = myUnit.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if (myUnit != null)
                                        {
                                            vUnitName1 = myUnit.Name1;
                                            vUnitName2 = myUnit.Name2;
                                        }

                                        STP mySTP = new STP();
                                        mySTP.Branch = short.Parse(Session["Branch"].ToString());
                                        mySTP.VouLoc = short.Parse(StoreNo);
                                        mySTP.ITCode = itm.Code;

                                        double vPQuan = 0;
                                        foreach (vSTS item in VouData)
                                        {
                                            if (item.ITCode == mySTP.ITCode) vPQuan += (double)item.Quan;
                                        }

                                        int r = 1;
                                        List<String> CostPrice = new List<string>();
                                        CostPrice = mySTP.GetItemCostPrice2((double)itm.FDed, vPQuan, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        for (int i1 = 0; i1 < CostPrice.Count(); i1++)
                                        {
                                            string str = CostPrice[i1];
                                            if (str == "0") break;
                                            vSTS myAccess = new vSTS();
                                            myAccess.FNo = (short)(VouData.Count + 1);
                                            myAccess.Branch = short.Parse(Session["Branch"].ToString());
                                            myAccess.ITCode = myItem.ITCode;
                                            myAccess.ITName1 = myItem.ITName1;
                                            myAccess.ITName2 = myItem.ITName2;
                                            myAccess.UnitCode = myItem.ITUnit1;
                                            myAccess.UnitName1 = vUnitName1;
                                            myAccess.UnitName2 = vUnitName2;
                                            myAccess.Quan = double.Parse(str.Split('&')[1]);
                                            myAccess.Price = double.Parse(str.Split('&')[0]);

                                            mySTP.Branch = short.Parse(Session["Branch"].ToString());
                                            mySTP.VouLoc = short.Parse(StoreNo);
                                            mySTP.ITCode = myItem.ITCode;

                                            myAccess.Remark = "الاصناف التي بها عجز في الجرد عن " + itm.FYear.Substring(6,4);
                                            myAccess.InvType = 0;
                                            vStock myStock = new vStock();
                                            myStock.Branch = short.Parse(Session["Branch"].ToString());
                                            myStock.Number = short.Parse(StoreNo);
                                            myStock.Code = myItem.ITCode;
                                            myStock = myStock.GetStockItem(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                            if (myStock != null)
                                            {
                                                myAccess.Bal = myStock.IOpen + myStock.IPurch - myStock.ISale;
                                                myAccess.CrCode = ShopArea.CPur_Acc + moh.MakeMask(StoreNo, 2) + myStock.CPur_Acc;
                                                myAccess.DbCode = "310202017";
                                            }
                                            myAccess.FNo = (short)(VouData.Count() + 1);
                                            VouData.Add(myAccess);
                                            r++;
                                        }
                                    }
                                }
                            }
                            MakeSum();
                            LoadVouData();
                        }
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
                grdCodes.ShowFooter = (BtnUnlock.ToolTip != "");
                grdCodes.DataSource = VouData;
                grdCodes.DataBind();

                if (grdCodes.Rows.Count < 1)
                {
                    vSTS ax = new vSTS();
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

                if(BtnUnlock.ToolTip != "")
                {
                    if (grdCodes.Rows != null)
                    {
                        foreach (GridViewRow grv in grdCodes.Rows)
                        {
                            ImageButton btnDelete = grv.FindControl("btnDelete") as ImageButton;
                            if (btnDelete != null) btnDelete.Visible = true;
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
                            if (btnDelete != null) btnDelete.Visible = false;
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
                        if (ddlUnit2.SelectedIndex <= 0 || (ddlUnit2.SelectedValue != myItem.ITUnit1 && ddlUnit2.SelectedValue != myItem.ITUnit2)) ddlUnit2.SelectedValue = myItem.ITUnit1;
                    }

                    Stock myStock2 = new Stock();
                    myStock2.Branch = short.Parse(Session["Branch"].ToString());
                    myStock2.Code = txtITCode2.Text;
                    myStock2.Number = short.Parse(StoreNo);
                    myStock2 = myStock2.GetItem(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myStock2 == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "Stock Item Qty Not Enough";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }
                    else
                    {
                        double OldQuan = 0;
                        foreach (vSTS itm in VouData)
                        {
                            if (itm.ITCode == txtITCode2.Text) OldQuan += (double)itm.Quan;
                        }
                        if (myStock2.IOpen + myStock2.IPurch - myStock2.ISale - double.Parse(txtQuan2.Text) - OldQuan < 0)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "Stock Item Qty Not Enough";
                            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                            return;
                        }
                        lblBal.Text = (myStock2.IOpen + myStock2.IPurch - myStock2.ISale - 1 - OldQuan).ToString();
                    }

                    //vSTS myAccess = new vSTS();
                    //myAccess.FNo = (short)(VouData.Count + 1);
                    //myAccess.Branch = short.Parse(Session["Branch"].ToString());
                    //myAccess.ITCode = myItem.ITCode;
                    //myAccess.ITName1 = myItem.ITName1;
                    //myAccess.ITName2 = myItem.ITName2;
                    //myAccess.UnitCode = ddlUnit2.SelectedValue.ToString();
                    //if (myAccess.UnitCode != "-1")
                    //{
                    //    myAccess.UnitName1 = ddlUnit2.SelectedItem.Text;
                    //    myAccess.UnitName2 = ddlUnit2.SelectedItem.Text;
                    //}
                    //myAccess.Quan = double.Parse(txtQuan2.Text);
                    //STP mySTP = new STP();
                    //mySTP.Branch = short.Parse(Session["Branch"].ToString());
                    //mySTP.VouLoc = short.Parse(StoreNo);
                    //mySTP.ITCode = myItem.ITCode;
                    //myAccess.Price = mySTP.GetItemCostPrice(double.Parse(txtQuan2.Text), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    //myAccess.Remark = txtRemark.Text;
                    //myAccess.InvType = 0;
                    //vStock myStock = new vStock();
                    //myStock.Branch = short.Parse(Session["Branch"].ToString());
                    //myStock.Number = short.Parse(StoreNo);
                    //myStock.Code = txtITCode2.Text;
                    //myStock = myStock.GetStockItem(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    //if (myStock != null)
                    //{
                    //    myAccess.Bal = myStock.IOpen + myStock.IPurch - myStock.ISale;
                    //    myAccess.CrCode = ShopArea.CPur_Acc + moh.MakeMask(StoreNo, 2) + myStock.CPur_Acc;

                    //    Acc myacc = new Acc();
                    //    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    //    myacc.Code = myAccess.CrCode;
                    //    if (myacc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    //    {
                    //        myAccess.DbCode = myacc.ACDep;
                    //    }
                    //    else myAccess.DbCode = "-1";
                    //}
                    //VouData.Add(myAccess);

                                        
                    STP mySTP = new STP();
                    mySTP.Branch = short.Parse(Session["Branch"].ToString());
                    mySTP.VouLoc = short.Parse(StoreNo);
                    mySTP.ITCode = txtITCode2.Text;

                    double vPQuan = 0;
                    foreach (vSTS item in VouData)
                    {
                        if (item.ITCode == mySTP.ITCode) vPQuan += (double)item.Quan;
                    }


                    int r = 1;
                    List<String> CostPrice = new List<string>();
                    CostPrice = mySTP.GetItemCostPrice2(double.Parse(txtQuan2.Text),vPQuan, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    for (int i1 = 0; i1 < CostPrice.Count(); i1++)
                    //for(int i1 = CostPrice.Count()-1; i1>=0 ; i1--)
                    {
                        string str = CostPrice[i1];
                        if (str == "0") break;
                        vSTS myAccess = new vSTS();
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
                        myAccess.Quan = double.Parse(str.Split('&')[1]);
                        myAccess.Price = double.Parse(str.Split('&')[0]);

                        mySTP.Branch = short.Parse(Session["Branch"].ToString());
                        mySTP.VouLoc = short.Parse(StoreNo);
                        mySTP.ITCode = myItem.ITCode;

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
                            myAccess.CrCode = ShopArea.CPur_Acc + moh.MakeMask(StoreNo, 2) + myStock.CPur_Acc;

                            if (ChkLost.Checked) myAccess.DbCode = "310202017";
                            else
                            {
                                Acc myacc = new Acc();
                                myacc.Branch = short.Parse(Session["Branch"].ToString());
                                myacc.Code = myAccess.CrCode;
                                if (myacc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                {
                                    myAccess.DbCode = myacc.ACDep;
                                }
                                else myAccess.DbCode = "-1";
                            }


                        }
                        myAccess.FNo = (short)(VouData.Count() + 1);
                        VouData.Add(myAccess);
                        r++;
                    }

                    if (r == 1)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "Stock Item Qty Not Enough";
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                        return;
                    }
                    else
                    {
                        MakeSum();
                        LoadVouData();

                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "Adding Item done Successfully";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, false), true);
                    }
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
            foreach (vSTS itm in VouData)
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
                STP mySTP = new STP();
                mySTP.Branch = short.Parse(Session["Branch"].ToString());
                mySTP.VouLoc = short.Parse(StoreNo);
                mySTP.ITCode = myItem.ITCode;
                VouData[int.Parse(FNo) - 1].Price = mySTP.GetItemCostPrice(double.Parse(txtQuan2.Text), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                vStock myStock = new vStock();
                myStock.Branch = short.Parse(Session["Branch"].ToString());
                myStock.Number = short.Parse(StoreNo);
                myStock.Code = txtITCode2.Text;
                myStock = myStock.GetStockItem(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myStock != null)
                {
                    VouData[int.Parse(FNo) - 1].Bal = myStock.IOpen + myStock.IPurch - myStock.ISale;
                    VouData[int.Parse(FNo) - 1].CrCode = ShopArea.CPur_Acc + moh.MakeMask(StoreNo, 2) + myStock.CPur_Acc;

                    if (ChkLost.Checked) VouData[int.Parse(FNo) - 1].DbCode = "310202017";
                    else
                    {
                        Acc myacc = new Acc();
                        myacc.Branch = short.Parse(Session["Branch"].ToString());
                        myacc.Code = VouData[int.Parse(FNo) - 1].CrCode;
                        if (myacc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            VouData[int.Parse(FNo) - 1].DbCode = myacc.ACDep;
                        }
                        else VouData[int.Parse(FNo) - 1].DbCode = "-1";
                    }
                }

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
                txtVouNo.Text = "";
                txtVouDate.Text = "";
                txtRefNo.Text = "";
                txtRemark.Text = "";
                lblTotalQty.Text = "";
                LblCodesResult.Text = "";
                ddlCar.SelectedIndex = 0;
                ChkLost.Checked = false;
                ChkLost_CheckedChanged(sender, e);
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                lblBal.Text = "";
                txtPassword.Text = "";

                if (sender != null)
                {
                    STS myJv = new STS();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.VouLoc = short.Parse(StoreNo);
                    myJv.Ftype = 701;
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
                VouData2.Clear();
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
                txtCarNo.Text = "";
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

                    if (!CheckRef())
                    {
                        return;
                    }

                    JobWork myJob = new JobWork();
                    myJob.Branch = short.Parse(Session["Branch"].ToString());
                    myJob.VouLoc = short.Parse(StoreNo);
                    myJob.VouNo = int.Parse(txtRefNo.Text);
                    myJob = myJob.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myJob == null)
                    {
                        txtRefNo.Text = "";
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم بيان التشغيل غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                    else
                    {
                        if (myJob.Status != 0)
                        {
                            txtRefNo.Text = "";
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "حالة بيان التشغيل غير مفتوح للصرف";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                    }

                    if (lblTotalQty.Text == "" || double.Parse(lblTotalQty.Text) == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "No Qty to Save";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    STS myJv = new STS();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.Ftype = 701;
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
                            myJv = new STS();
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.VouLoc = short.Parse(StoreNo);
                            myJv.Ftype = 701;
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

                    foreach (vSTS itm in VouData)
                    {
                        if (itm.DbCode == "310202001")
                        {
                            if (itm.Amount < 1500)
                            {
                                itm.DbCode = "310202001";
                            }
                            else if (itm.Amount < 20000)
                            {
                                //itm.InvNo = mJv.DbCode;
                                itm.DbCode = "120402003";
                            }
                            else
                            {
                                itm.DbCode = "1101" + ddlCar.SelectedValue;
                            }
                        }
                        myJv = new STS();
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.VouLoc = short.Parse(StoreNo);
                        myJv.Ftype = 701;
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

                    List<vSTS> myList = new List<vSTS>();
                    myList = (from itm in VouData
                                group itm by new { itm.DbCode }
                                    into g
                                    select new vSTS
                                    {
                                        DbCode = g.Key.DbCode,
                                        ExpAmount = g.Sum(p => (p.Price * p.Quan))
                                    }).ToList();

                    short FNo = 1;
                    foreach (vSTS itm in myList)
                    {
                        if (itm.ExpAmount != 0)
                        {
                            Jv mJv = new Jv();
                            mJv.Branch = short.Parse(Session["Branch"].ToString());
                            mJv.FType = 701;
                            mJv.LocType = 2;
                            mJv.LocNumber = short.Parse(StoreNo);
                            mJv.Number = int.Parse(txtVouNo.Text);
                            mJv.FNo = FNo;
                            mJv.Post = 1;
                            mJv.DbCode = itm.DbCode;  // Here Account;
                            mJv.CrCode = "";
                            mJv.FDate = moh.CheckDate(txtVouDate.Text);
                            mJv.Amount = Math.Round((double)itm.ExpAmount,2); // here amount
                            mJv.ChequeNo = "";
                            mJv.ChequeDate = "";
                            mJv.InvNo = txtRefNo.Text;
                            mJv.Remark = txtRemark.Text;
                            mJv.Seller = -1;
                            mJv.Project = "00001";
                            mJv.BankName = "";
                            mJv.CostCenter = "00017";
                            mJv.UserName = txtUserName.ToolTip;
                            mJv.UserDate = txtUserDate.Text;
                            mJv.EmpCode = "-1";
                            mJv.Area = "00001";
                            mJv.CostAcc = "00002";
                            mJv.CarNo = ddlCar.SelectedValue;
                            mJv.DocType = 0;
                            mJv.FNo2 = 0;

                            if(mJv.DbCode == "310202001")
                            {
                               mJv.DbCode = "310202001";
                            }
                            else if(mJv.DbCode == "120402003")
                            {
                                mJv.InvNo = "310202001";

                                CarRepair myCar = new CarRepair();
                                myCar.CarNo = mJv.CarNo;
                                myCar.VouType = mJv.FType;
                                myCar.LocType = 2;
                                myCar.VouLoc = mJv.LocNumber;
                                myCar.VouNo = mJv.Number;
                                myCar.FNo = FNo;
                                myCar.VouDate = mJv.FDate;
                                myCar.Ref = "قطع غيار";
                                myCar.Amount = mJv.Amount;
                                myCar.MonthNo = 12;
                                myCar.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                mJv.CostCenter = "-1";
                                mJv.CarNo = "-1";
                                mJv.Area = "-1";
                                mJv.CostAcc = "-1";
                                mJv.Project = "-1";
                            }
                            else if(mJv.DbCode == "1101" + ddlCar.SelectedValue)
                            {
                                    mJv.CostCenter = "-1";
                                    mJv.CarNo = "-1";
                                    mJv.Area = "-1";
                                    mJv.CostAcc = "-1";
                                    mJv.Project = "-1";
                            }
                            else if(mJv.DbCode == "310202002")
                            {
                                mJv.InvNo = mJv.DbCode;
                                mJv.DbCode = "120402001";

                                CarRepair myCar = new CarRepair();
                                myCar.CarNo = mJv.CarNo;
                                myCar.VouType = mJv.FType;
                                myCar.LocType = 2;
                                myCar.VouLoc = mJv.LocNumber;
                                myCar.VouNo = mJv.Number;
                                myCar.FNo = FNo;
                                myCar.VouDate = mJv.FDate;
                                myCar.Ref = "إطارات";
                                myCar.Amount = mJv.Amount;
                                myCar.MonthNo = 12;
                                myCar.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                mJv.CostCenter = "-1";
                                mJv.CarNo = "-1";
                                mJv.Area = "-1";
                                mJv.CostAcc = "-1";
                                mJv.Project = "-1";
                            }
                            else if(mJv.DbCode == "310202003")
                            {
                                mJv.InvNo = mJv.DbCode;
                                mJv.DbCode = "120402002";

                                CarRepair myCar = new CarRepair();
                                myCar.CarNo = mJv.CarNo;
                                myCar.VouType = mJv.FType;
                                myCar.LocType = 2;
                                myCar.VouLoc = mJv.LocNumber;
                                myCar.VouNo = mJv.Number;
                                myCar.FNo = FNo;
                                myCar.VouDate = mJv.FDate;
                                myCar.Ref = "بطاريات";
                                myCar.Amount = mJv.Amount;
                                myCar.MonthNo = 12;
                                myCar.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                mJv.CostCenter = "-1";
                                mJv.CarNo = "-1";
                                mJv.Area = "-1";
                                mJv.CostAcc = "-1";
                                mJv.Project = "-1";
                            }
                            FNo++;
                            mJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                    }

                    myList = new List<vSTS>();
                    myList = (from itm in VouData
                                group itm by new { itm.CrCode }
                                    into g
                                    select new vSTS
                                    {
                                        CrCode = g.Key.CrCode,
                                        ExpAmount = g.Sum(p => (p.Price * p.Quan))
                                    }).ToList();

                    foreach (vSTS itm in myList)
                    {
                        if (itm.ExpAmount != 0)
                        {
                            Jv mJv2 = new Jv();
                            mJv2.Branch = short.Parse(Session["Branch"].ToString());
                            mJv2.FType = 701;
                            mJv2.LocType = 2;
                            mJv2.LocNumber = short.Parse(StoreNo);
                            mJv2.Number = int.Parse(txtVouNo.Text);
                            mJv2.FNo = FNo;
                            FNo++;
                            mJv2.Post = 1;
                            mJv2.DbCode = "";
                            mJv2.CrCode = itm.CrCode;
                            mJv2.FDate = moh.CheckDate(txtVouDate.Text);
                            mJv2.Amount = Math.Round((double)itm.ExpAmount,2); // here amount
                            mJv2.ChequeNo = "";
                            mJv2.ChequeDate = "";
                            mJv2.InvNo = txtRefNo.Text;
                            mJv2.Remark = txtRemark.Text;
                            mJv2.Seller = -1;
                            mJv2.Project = "-1";
                            mJv2.BankName = "";
                            mJv2.CostCenter = "-1";
                            mJv2.UserName = txtUserName.ToolTip;
                            mJv2.UserDate = txtUserDate.Text;
                            mJv2.EmpCode = "-1";
                            mJv2.Area = "-1";
                            mJv2.CostAcc = "-1";
                            mJv2.CarNo = "-1";
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

                    if (!CheckRef())
                    {
                        return;
                    }
                    
                    if (lblTotalQty.Text == "" || double.Parse(lblTotalQty.Text) == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "No Qty to Save";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                        return;
                    }

                    STS myJv = new STS();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.Ftype = 701;
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
                            mJv2.FType = 701;
                            mJv2.LocType = 2;
                            mJv2.LocNumber = short.Parse(StoreNo);
                            mJv2.Number = int.Parse(txtVouNo.Text);
                            mJv2.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            CarRepair myCar2 = new CarRepair();
                            myCar2.VouType = 701;
                            myCar2.LocType = 2;
                            myCar2.VouLoc = short.Parse(StoreNo);
                            myCar2.VouNo = int.Parse(txtVouNo.Text);
                            myCar2.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            foreach (vSTS itm in VouData)
                            {
                                if (itm.DbCode == "310202001")
                                {
                                    if (itm.Amount < 1500)
                                    {
                                        itm.DbCode = "310202001";
                                    }
                                    else if (itm.Amount < 20000)
                                    {
                                        //itm.InvNo = mJv.DbCode;
                                        itm.DbCode = "120402003";
                                    }
                                    else
                                    {
                                        itm.DbCode = "1101" + ddlCar.SelectedValue;
                                    }
                                }

                                myJv = new STS();
                                myJv.Ftype = 701;
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

                            List<vSTS> myList = new List<vSTS>();
                            myList = (from itm in VouData
                                      group itm by new { itm.DbCode }
                                          into g
                                          select new vSTS
                                          {
                                              DbCode = g.Key.DbCode,
                                              ExpAmount = g.Sum(p => (p.Price * p.Quan))
                                          }).ToList();

                            short FNo = 1;
                            foreach (vSTS itm in myList)
                            {
                                if (itm.ExpAmount != 0)
                                {
                                    Jv mJv = new Jv();
                                    mJv.Branch = short.Parse(Session["Branch"].ToString());
                                    mJv.FType = 701;
                                    mJv.LocType = 2;
                                    mJv.LocNumber = short.Parse(StoreNo);
                                    mJv.Number = int.Parse(txtVouNo.Text);
                                    mJv.FNo = FNo;
                                    mJv.Post = 1;
                                    mJv.DbCode = itm.DbCode;  // Here Account;
                                    mJv.CrCode = "";
                                    mJv.FDate = moh.CheckDate(txtVouDate.Text);
                                    mJv.Amount = Math.Round((double)itm.ExpAmount,2); // here amount
                                    mJv.ChequeNo = "";
                                    mJv.ChequeDate = "";
                                    mJv.InvNo = txtRefNo.Text;
                                    mJv.Remark = txtRemark.Text;
                                    mJv.Seller = -1;
                                    mJv.Project = "00001";
                                    mJv.BankName = "";
                                    mJv.CostCenter = "00017";
                                    mJv.UserName = txtUserName.ToolTip;
                                    mJv.UserDate = txtUserDate.Text;
                                    mJv.EmpCode = "-1";
                                    mJv.Area = "00001";
                                    mJv.CostAcc = "00002";
                                    mJv.CarNo = ddlCar.SelectedValue;
                                    mJv.DocType = 0;
                                    mJv.FNo2 = 0;
                                    FNo++;

                                    if (mJv.DbCode == "310202001")
                                    {
                                        mJv.DbCode = "310202001";
                                    }
                                    else if (mJv.DbCode == "120402003")
                                    {
                                        mJv.InvNo = "310202001";

                                        CarRepair myCar = new CarRepair();
                                        myCar.CarNo = mJv.CarNo;
                                        myCar.VouType = mJv.FType;
                                        myCar.LocType = 2;
                                        myCar.VouLoc = mJv.LocNumber;
                                        myCar.VouNo = mJv.Number;
                                        myCar.FNo = FNo;
                                        myCar.VouDate = mJv.FDate;
                                        myCar.Ref = "قطع غيار";
                                        myCar.Amount = mJv.Amount;
                                        myCar.MonthNo = 12;
                                        myCar.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                        mJv.CostCenter = "-1";
                                        mJv.CarNo = "-1";
                                        mJv.Area = "-1";
                                        mJv.CostAcc = "-1";
                                        mJv.Project = "-1";
                                    }
                                    else if (mJv.DbCode == "1101" + ddlCar.SelectedValue)
                                    {
                                        mJv.CostCenter = "-1";
                                        mJv.CarNo = "-1";
                                        mJv.Area = "-1";
                                        mJv.CostAcc = "-1";
                                        mJv.Project = "-1";
                                    }
                                    else if (mJv.DbCode == "310202002")
                                    {
                                        mJv.InvNo = mJv.DbCode;
                                        mJv.DbCode = "120402001";

                                        CarRepair myCar = new CarRepair();
                                        myCar.LocType = 2;
                                        myCar.CarNo = mJv.CarNo;
                                        myCar.VouType = mJv.FType;
                                        myCar.VouLoc = mJv.LocNumber;
                                        myCar.VouNo = mJv.Number;
                                        myCar.FNo = FNo;
                                        myCar.VouDate = mJv.FDate;
                                        myCar.Ref = "إطارات";
                                        myCar.Amount = mJv.Amount;
                                        myCar.MonthNo = 12;
                                        myCar.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                        mJv.CostCenter = "-1";
                                        mJv.CarNo = "-1";
                                        mJv.Area = "-1";
                                        mJv.CostAcc = "-1";
                                        mJv.Project = "-1";

                                    }
                                    else if (mJv.DbCode == "310202003")
                                    {
                                        mJv.InvNo = mJv.DbCode;
                                        mJv.DbCode = "120402002";

                                        CarRepair myCar = new CarRepair();
                                        myCar.LocType = 2;
                                        myCar.CarNo = mJv.CarNo;
                                        myCar.VouType = mJv.FType;
                                        myCar.VouLoc = mJv.LocNumber;
                                        myCar.VouNo = mJv.Number;
                                        myCar.FNo = FNo;
                                        myCar.VouDate = mJv.FDate;
                                        myCar.Ref = "بطاريات";
                                        myCar.Amount = mJv.Amount;
                                        myCar.MonthNo = 12;
                                        myCar.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                        mJv.CostCenter = "-1";
                                        mJv.CarNo = "-1";
                                        mJv.Area = "-1";
                                        mJv.CostAcc = "-1";
                                        mJv.Project = "-1";
                                    }

                                    mJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                }
                            }

                            myList = new List<vSTS>();
                            myList = (from itm in VouData
                                      group itm by new { itm.CrCode }
                                          into g
                                          select new vSTS
                                          {
                                              CrCode = g.Key.CrCode,
                                              ExpAmount = g.Sum(p => (p.Price * p.Quan))
                                          }).ToList();

                            foreach (vSTS itm in myList)
                            {
                                if (itm.ExpAmount != 0)
                                {
                                    mJv2 = new Jv();
                                    mJv2.Branch = short.Parse(Session["Branch"].ToString());
                                    mJv2.FType = 701;
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
                                    mJv2.Project = "-1";
                                    mJv2.BankName = "";
                                    mJv2.CostCenter = "-1";
                                    mJv2.UserName = txtUserName.ToolTip;
                                    mJv2.UserDate = txtUserDate.Text;
                                    mJv2.EmpCode = "-1";
                                    mJv2.Area = "-1";
                                    mJv2.CostAcc = "-1";
                                    mJv2.CarNo = "-1";
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
                    myJv.Ftype = 701;
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
                            mJv2.FType = 701;
                            mJv2.LocType = 2;
                            mJv2.LocNumber = short.Parse(StoreNo);
                            mJv2.Number = int.Parse(txtVouNo.Text);
                            mJv2.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            CarRepair myCar = new CarRepair();
                            myCar.VouType = 701;
                            myCar.LocType = 2;
                            myCar.VouLoc = short.Parse(StoreNo);
                            myCar.VouNo = int.Parse(txtVouNo.Text);
                            myCar.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.Description = "Delete Issue Note No. " + txtVouNo.Text;
                            UserTran.FormAction = "Delete";
                            UserTran.FormName = "Issue Note";
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

                    STS myJv = new STS();
                    myJv.Branch = short.Parse(Session["Branch"].ToString());
                    myJv.Ftype = 701;
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
                            ChkLost.Checked = true;
                            ChkLost_CheckedChanged(sender, e);
                            ddlCar.SelectedValue = "-1";
                        }
                        else
                        {
                            ChkLost.Checked = false;
                            ChkLost_CheckedChanged(sender, e);
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
                        myAgree.FType = 701;
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


        protected void BtnChPrice_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int LastNo = 0;
                STS myJv = new STS();
                myJv.Branch = short.Parse(Session["Branch"].ToString());
                myJv.VouLoc = short.Parse(StoreNo);
                myJv.Ftype = 701;
                int? i = myJv.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (i == 0 || i == null)
                {
                    LastNo = 1;
                }
                else
                {
                    LastNo = (int)i++;
                }
 
                STS myJv2 = new STS();
                myJv2.ResetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                foreach(int myNo in myJv2.GetStatement2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    txtVouNo.Text = myNo.ToString();
                    if (txtVouNo.Text != "")
                    {
                        myJv = new STS();
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.Ftype = 701;
                        myJv.VouLoc = short.Parse(StoreNo);
                        myJv.VouNo = int.Parse(txtVouNo.Text);
                        myJv = myJv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                        if (myJv == null)
                        {
                            //LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            //LblCodesResult.Text = "Note No. Not Found";
                            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            //if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                            continue;
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
                                ChkLost.Checked = true;
                                ChkLost_CheckedChanged(sender, e);
                                ddlCar.SelectedValue = "-1";
                            }
                            else
                            {
                                ChkLost.Checked = false;
                                ChkLost_CheckedChanged(sender, e);
                                if (ddlCar.Items.FindByValue(myJv.ExpRef) == null)
                                {
                                    ddlCar.Items.Add(new ListItem(myJv.ExpRef, myJv.ExpRef));
                                }
                                ddlCar.SelectedValue = myJv.ExpRef;
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
                            int r = 1;
                            foreach (vSTS itm in VouData)
                            {
                                STP mySTP = new STP();
                                mySTP.Branch = short.Parse(Session["Branch"].ToString());
                                mySTP.VouLoc = short.Parse(StoreNo);
                                mySTP.ITCode = itm.ITCode;
                                double vPQuan = 0;
                                foreach (vSTS item in VouData2)
                                {
                                    if (item.ITCode == itm.ITCode) vPQuan += (double)item.Quan;
                                }

                                //itm.Price = mySTP.GetItemCostPrice((double)itm.Quan, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);                                
                                List<String> CostPrice = new List<string>();
                                CostPrice = mySTP.GetItemCostPrice2((double)itm.Quan,vPQuan, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                for (int i1 = 0; i1 < CostPrice.Count(); i1++)
                                {
                                    string str = CostPrice[i1];
                                    if (str == "0")
                                    {
                                     //   break;
                                    }
                                    vSTS myAccess = new vSTS();
                                    myAccess.FNo = (short)(VouData.Count + 1);
                                    myAccess.Branch = short.Parse(Session["Branch"].ToString());
                                    myAccess.ITCode = itm.ITCode;
                                    myAccess.ITName1 = itm.ITName1;
                                    myAccess.ITName2 = itm.ITName2;
                                    myAccess.UnitCode = itm.UnitCode;
                                    if (myAccess.UnitCode != "-1")
                                    {
                                        myAccess.UnitName1 = itm.UnitName1;
                                        myAccess.UnitName2 = itm.UnitName2;
                                    }
                                    myAccess.Quan = double.Parse(str.Split('&')[1]);
                                    myAccess.Price = double.Parse(str.Split('&')[0]);

                                    mySTP.Branch = short.Parse(Session["Branch"].ToString());
                                    mySTP.VouLoc = short.Parse(StoreNo);
                                    mySTP.ITCode = itm.ITCode;

                                    myAccess.Remark = txtRemark.Text;
                                    myAccess.InvType = 0;
                                    vStock myStock = new vStock();
                                    myStock.Branch = short.Parse(Session["Branch"].ToString());
                                    myStock.Number = short.Parse(StoreNo);
                                    myStock.Code = itm.ITCode;
                                    myStock = myStock.GetStockItem(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (myStock != null)
                                    {
                                        myAccess.Bal = myStock.IOpen + myStock.IPurch - myStock.ISale;
                                        myAccess.CrCode = ShopArea.CPur_Acc + moh.MakeMask(StoreNo, 2) + myStock.CPur_Acc;
                                        if (ChkLost.Checked) myAccess.DbCode = "310202017";
                                        else
                                        {
                                            Acc myacc = new Acc();
                                            myacc.Branch = short.Parse(Session["Branch"].ToString());
                                            myacc.Code = myAccess.CrCode;
                                            if (myacc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                            {
                                                myAccess.DbCode = myacc.ACDep;
                                            }
                                            else myAccess.DbCode = "-1";
                                        }
                                    }

                                    myAccess.FNo = (short)r;
                                    VouData2.Add(myAccess);
                                    r++;
                                }
                            }
                            LoadVouData();
                            MakeSum();

                            if (txtRefNo.Text == "") txtRefNo.Text = "0";
                            if (lblTotalQty.Text == "" || double.Parse(lblTotalQty.Text) == 0)
                            {
                                //LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                //LblCodesResult.Text = "No Qty to Save";
                                //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                //if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
                                BtnClear_Click(sender, e);
                                continue;
                            }

                            myJv = new STS();
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.Ftype = 701;
                            myJv.VouLoc = short.Parse(StoreNo);
                            myJv.VouNo = int.Parse(txtVouNo.Text);
                            myJv = myJv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                            if (myJv != null)
                            {
                                if (myJv.Delete2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                {
                                    Jv mJv2 = new Jv();
                                    mJv2.Branch = short.Parse(Session["Branch"].ToString());
                                    mJv2.FType = 701;
                                    mJv2.LocType = 2;
                                    mJv2.LocNumber = short.Parse(StoreNo);
                                    mJv2.Number = int.Parse(txtVouNo.Text);
                                    mJv2.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                    foreach (vSTS itm in VouData2)
                                    {
                                        myJv = new STS();
                                        myJv.Ftype = 701;
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

                                    List<vSTS> myList = new List<vSTS>();
                                    myList = (from itm in VouData2
                                              group itm by new { itm.DbCode }
                                                  into g
                                                  select new vSTS
                                                  {
                                                      DbCode = g.Key.DbCode,
                                                      ExpAmount = g.Sum(p => (p.Price * p.Quan))
                                                  }).ToList();

                                    short FNo = 1;
                                    foreach (vSTS itm in myList)
                                    {
                                        if (itm.ExpAmount != 0)
                                        {
                                            Jv mJv = new Jv();
                                            mJv.Branch = short.Parse(Session["Branch"].ToString());
                                            mJv.FType = 701;
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
                                            mJv.Project = "00001";
                                            mJv.BankName = "";
                                            mJv.CostCenter = "00017";
                                            mJv.UserName = txtUserName.ToolTip;
                                            mJv.UserDate = txtUserDate.Text;
                                            mJv.EmpCode = "-1";
                                            mJv.Area = "00001";
                                            mJv.CostAcc = "00002";
                                            mJv.CarNo = ddlCar.SelectedValue;
                                            mJv.DocType = 0;
                                            mJv.FNo2 = 0;
                                            FNo++;
                                            mJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        }
                                    }

                                    myList = new List<vSTS>();
                                    myList = (from itm in VouData2
                                              group itm by new { itm.CrCode }
                                                  into g
                                                  select new vSTS
                                                  {
                                                      CrCode = g.Key.CrCode,
                                                      ExpAmount = g.Sum(p => (p.Price * p.Quan))
                                                  }).ToList();

                                    foreach (vSTS itm in myList)
                                    {
                                        if (itm.ExpAmount != 0)
                                        {
                                            mJv2 = new Jv();
                                            mJv2.Branch = short.Parse(Session["Branch"].ToString());
                                            mJv2.FType = 701;
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
                                            mJv2.Project = "-1";
                                            mJv2.BankName = "";
                                            mJv2.CostCenter = "-1";
                                            mJv2.UserName = txtUserName.ToolTip;
                                            mJv2.UserDate = txtUserDate.Text;
                                            mJv2.EmpCode = "-1";
                                            mJv2.Area = "-1";
                                            mJv2.CostAcc = "-1";
                                            mJv2.CarNo = "-1";
                                            mJv2.DocType = 0;
                                            mJv2.FNo2 = 0;
                                            mJv2.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        }
                                    }
                                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                    LblCodesResult.Text = "Updating Data Done Successfully";
                                    BtnClear_Click(sender, e);
                                }
                            }
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



        protected void BtnFind_Click(object sender, ImageClickEventArgs e)
        {
            BtnSearch_Click(sender, e);
        }

        public void PrintMe(String Number)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=206&AreaNo=" + StoreNo + "&Number=" + Number + "');</script>", false);
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
                        myArch.DocType = 906;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(StoreNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 906;
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
                myArch.DocType = 906;
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
            myArch.DocType = 906;
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

        protected void BtnFind2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                txtRefNo_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }



            //try
            //{
            //    if (txtRefNo.Text != "")
            //    {
            //        STS myPo = new STS();
            //        myPo.Branch = short.Parse(Session["Branch"].ToString());
            //        myPo.RefNo = int.Parse(txtRefNo.Text);
            //        myPo.RefNoLoc = myPo.VouLoc;
            //        bool vFind = false;
            //        int VouNo = 0;
            //        foreach (STS itm in myPo.FindRef(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            //        {
            //            if (itm.VouNo != int.Parse(txtVouNo.Text) && itm.Ftype == 601)
            //            {
            //                vFind = true;
            //                VouNo = itm.VouNo;
            //                break;
            //            }
            //        }
            //        if (vFind)
            //        {
            //            LblCodesResult.ForeColor = System.Drawing.Color.Red;
            //            LblCodesResult.Text = "Purchase Order No. Used before in Purchase Order No. " + VouNo.ToString();
            //            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
            //            return;
            //        }

            //        foreach (vSTS itm in VouData)
            //        {
            //            if (itm.RefNo == int.Parse(txtRefNo.Text))
            //            {
            //                vFind = true;
            //                break;
            //            }
            //        }
            //        if (vFind)
            //        {
            //            LblCodesResult.ForeColor = System.Drawing.Color.Red;
            //            LblCodesResult.Text = "Purchase Order No. Used before in same Purchase Invoice No. ";
            //            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
            //            return;
            //        }

            //        PO myJv = new PO();
            //        myJv.Branch = short.Parse(Session["Branch"].ToString());
            //        myJv.VouNo = int.Parse(txtRefNo.Text);
            //        myJv = myJv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
            //        if (myJv == null)
            //        {
            //            LblCodesResult.ForeColor = System.Drawing.Color.Red;
            //            LblCodesResult.Text = "Purchase Order No. Not Found";
            //            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
            //            return;
            //        }
            //        else
            //        {
            //            foreach (vPO itm in myJv.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
            //            {
            //                VouData.Add(
            //                                new vSTS
            //                                {
            //                                    FNo = (short)(VouData.Count + 1),
            //                                    Branch = itm.Branch,
            //                                    Price = itm.Price,
            //                                    Quan = itm.Quan,
            //                                    RefNo = int.Parse(txtRefNo.Text),
            //                                    RefNoLoc = itm.VouLoc,
            //                                    ITCode = itm.ITCode,
            //                                    ITName1 = itm.ITName1,
            //                                    ITName2 = itm.ITName2,
            //                                    UnitCode = itm.UnitCode,
            //                                    UnitName1 = itm.UnitName1,
            //                                    UnitName2 = itm.UnitName2,
            //                                }
            //                    );
            //            }
            //            LoadVouData();
            //            MakeSum();
            //            LoadAttachData();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    LblCodesResult.ForeColor = System.Drawing.Color.Red;
            //    LblCodesResult.Text = ex.Message.ToString();
            //}
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

        protected void ChkLost_CheckedChanged(object sender, EventArgs e)
        {
            Label4.Visible = !ChkLost.Checked;
            txtCarNo.Visible = !ChkLost.Checked;
            BtnFindCar.Visible = !ChkLost.Checked;
            ddlCar.Visible = !ChkLost.Checked;
            ValCar.Enabled = !ChkLost.Checked;
            if (ChkLost.Checked)
            {
                ddlCar.SelectedValue = "-1";
                txtCarNo.Text = "";
            }
                
            if (VouData.Count() < 1) grdCodes_RowCancelingEdit(sender, null);
            else if (ChkLost.Checked)
            {
                foreach (vSTS itm in VouData)
                {
                    itm.DbCode = "310202017";
                }
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
                    string vResult = PutItem(txtItemCode.Text,true);
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

                    Stock myStock2 = new Stock();
                    myStock2.Branch = short.Parse(Session["Branch"].ToString());
                    myStock2.Code = myItem.ITCode;
                    myStock2.Number = short.Parse(StoreNo);
                    myStock2 = myStock2.GetItem(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myStock2 == null)
                    {
                        return "Stock Item Qty Not Enough";
                    }
                    else
                    {
                        double OldQuan = 0;
                        foreach (vSTS itm in VouData)
                        {
                            if (itm.ITCode == myItem.ITCode) OldQuan += (double)itm.Quan;
                        }
                        if (myStock2.IOpen + myStock2.IPurch - myStock2.ISale - Quan - OldQuan < 0)
                        {
                            return "Stock Item Qty Not Enough";
                        }
                        lblBal.Text = (myStock2.IOpen + myStock2.IPurch - myStock2.ISale - Quan - OldQuan).ToString();
                    }

                    STP mySTP = new STP();
                    mySTP.Branch = short.Parse(Session["Branch"].ToString());
                    mySTP.VouLoc = short.Parse(StoreNo);
                    mySTP.ITCode = myItem.ITCode;

                    double vPQuan = 0;
                    foreach (vSTS item in VouData)
                    {
                        if (item.ITCode == mySTP.ITCode) vPQuan += (double)item.Quan;
                    }

                    int r = 1;
                    List<String> CostPrice = new List<string>();
                    CostPrice = mySTP.GetItemCostPrice2(Quan, vPQuan, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    for (int i1 = 0; i1 < CostPrice.Count(); i1++)
                    {
                        string str = CostPrice[i1];
                        if (str == "0") break;

                        bool vFound = false;
                        foreach (vSTS eitm in VouData)
                        {
                            if (eitm.ITCode == myItem.ITCode && eitm.Price == double.Parse(str.Split('&')[0]))
                            {
                                vFound = true;
                                eitm.Quan += double.Parse(str.Split('&')[1]);
                                break;
                            }
                        }

                        if(!vFound)
                        {
                            vSTS myAccess = new vSTS();
                            myAccess.FNo = (short)(VouData.Count + 1);
                            myAccess.Branch = short.Parse(Session["Branch"].ToString());
                            myAccess.ITCode = myItem.ITCode;
                            myAccess.ITName1 = myItem.ITName1;
                            myAccess.ITName2 = myItem.ITName2;
                            myAccess.UnitCode = myItem.ITUnit1;

                            IUnit myUnit = new IUnit();
                            myUnit.Branch = short.Parse(Session["Branch"].ToString());
                            myUnit.Code = myItem.ITUnit1;
                            myUnit = myUnit.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myUnit != null)
                            {
                                myAccess.UnitName1 = myUnit.Name1;
                                myAccess.UnitName2 = myUnit.Name2;
                            }
                            myAccess.Quan = double.Parse(str.Split('&')[1]);
                            myAccess.Price = double.Parse(str.Split('&')[0]);

                            mySTP.Branch = short.Parse(Session["Branch"].ToString());
                            mySTP.VouLoc = short.Parse(StoreNo);
                            mySTP.ITCode = myItem.ITCode;

                            myAccess.Remark = txtRemark.Text;
                            myAccess.InvType = 0;
                            vStock myStock = new vStock();
                            myStock.Branch = short.Parse(Session["Branch"].ToString());
                            myStock.Number = short.Parse(StoreNo);
                            myStock.Code = myItem.ITCode;
                            myStock = myStock.GetStockItem(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myStock != null)
                            {
                                myAccess.Bal = myStock.IOpen + myStock.IPurch - myStock.ISale;
                                myAccess.CrCode = ShopArea.CPur_Acc + moh.MakeMask(StoreNo, 2) + myStock.CPur_Acc;

                                if (ChkLost.Checked) myAccess.DbCode = "310202017";
                                else
                                {
                                    Acc myacc = new Acc();
                                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                                    myacc.Code = myAccess.CrCode;
                                    if (myacc.GetAcc2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                    {
                                        myAccess.DbCode = myacc.ACDep;
                                    }
                                    else myAccess.DbCode = "-1";
                                }

                            }
                            myAccess.FNo = (short)(VouData.Count() + 1);
                            VouData.Add(myAccess);
                        }
                        r++;
                    }

                    if (r == 1)
                    {
                        return "Stock Item Qty Not Enough";
                    }
                    else
                    {
                        return "";
                    }
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
                    myAgree.FType = 701;
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
                    myAgree.FType = 701;
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