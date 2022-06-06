using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using BLL;
using System.Web.Configuration;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class WebItem : System.Web.UI.Page
    {
        public List<ItemStock> MyItemStock
        {
            get
            {
                if (ViewState["MyItemStock"] == null)
                {
                    ViewState["MyItemStock"] = new List<ItemStock>();
                }
                return (List<ItemStock>)ViewState["MyItemStock"];
            }
            set { ViewState["MyItemStock"] = value; }
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
        public void EditMode()
        {
            txtITCode.ReadOnly = true;
            txtITCode.BackColor = System.Drawing.Color.LightGray;
            txtITCode0.ReadOnly = true;
            txtITCode0.BackColor = System.Drawing.Color.LightGray;

            BtnEdit.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass112;
            BtnNew.Visible = false;
            BtnDelete.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass113;
        }

        public void NewMode()
        {
            txtITCode.ReadOnly = false;
            txtITCode.BackColor = System.Drawing.Color.White;
            txtITCode0.ReadOnly = false;
            txtITCode0.BackColor = System.Drawing.Color.White;

            BtnEdit.Visible = false;
            BtnNew.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass111;
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
                    this.Page.Header.Title = GetLocalResourceObject("Header2").ToString();  //"بيانات الاصناف";
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

                    ItemStock myStock = new ItemStock();
                    myStock.Branch = short.Parse(Session["Branch"].ToString());
                    MyItemStock = myStock.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    LoadStockData();
                    txtITEqual.Text = "1";
                    LoadddlData();

                    BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass111;
                    BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass112;
                    BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass113;
                    BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass114;
                    BtnFind.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[2].Pass114;

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

        public void LoadddlData()
        {
            try
            {
                ICat mycat = new ICat();
                mycat.Branch = short.Parse(Session["Branch"].ToString());
                mycat.FCode = "";
                PopulateNodes(mycat.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString), TreeView1.Nodes);

                IColor myColor = new IColor();
                myColor.Branch = short.Parse(Session["Branch"].ToString());
                ddlIColor.DataTextField = GetLocalResourceObject("Name").ToString();
                ddlIColor.DataValueField = "Code";
                ddlIColor.DataSource = myColor.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                ddlIColor.DataBind();
                ddlIColor.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectColor").ToString(), "-1", true));  // "--- أختر اللون ---"

                ISize mySize = new ISize();
                mySize.Branch = short.Parse(Session["Branch"].ToString());
                ddlISize.DataTextField = GetLocalResourceObject("Name").ToString();
                ddlISize.DataValueField = "Code";
                ddlISize.DataSource = mySize.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                ddlISize.DataBind();
                ddlISize.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectSize").ToString(), "-1", true));  // "--- أختر المقاس ---"

                IWidth myWidth = new IWidth();
                myWidth.Branch = short.Parse(Session["Branch"].ToString());
                ddlIWidth.DataTextField = GetLocalResourceObject("Name").ToString();
                ddlIWidth.DataValueField = "Code";
                ddlIWidth.DataSource = myWidth.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                ddlIWidth.DataBind();
                ddlIWidth.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectWidth").ToString(), "-1", true));  // "--- أختر الحجم ---"

                ICOO myCoo = new ICOO();
                myCoo.Branch = short.Parse(Session["Branch"].ToString());
                ddlICOO.DataTextField = GetLocalResourceObject("Name").ToString();
                ddlICOO.DataValueField = "Code";
                ddlICOO.DataSource = myCoo.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                ddlICOO.DataBind();
                ddlICOO.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectCOO").ToString(), "-1", true));   // "--- أختر بلد المنشأ ---"

                IUnit myUnit = new IUnit();
                myUnit.Branch = short.Parse(Session["Branch"].ToString());
                ddlitUnit1.DataTextField = GetLocalResourceObject("Name").ToString();
                ddlitUnit1.DataValueField = "Code";
                ddlitUnit2.DataTextField = GetLocalResourceObject("Name").ToString();
                ddlitUnit2.DataValueField = "Code";
                ddlitUnit1.DataSource = myUnit.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                ddlitUnit2.DataSource = ddlitUnit1.DataSource;
                ddlitUnit1.DataBind();
                ddlitUnit2.DataBind();
                ddlitUnit1.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectUnit").ToString(), "-1", true));  // "- أختر الوحدة -"
                ddlitUnit2.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectUnit").ToString(), "-1", true)); // "- أختر الوحدة -"

                Item myItem = new Item();
                myItem.Branch = short.Parse(Session["Branch"].ToString());
                myItem.FType = 1;
                if (Cache["Items" + Session["CNN2"].ToString()] == null) Cache.Insert("Items" + Session["CNN2"].ToString(), myItem.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                ddlSubItem1.DataTextField = GetLocalResourceObject("ITName").ToString();
                ddlSubItem1.DataValueField = "ITCode";
                ddlSubItem2.DataTextField = GetLocalResourceObject("ITName").ToString();
                ddlSubItem2.DataValueField = "ITCode";
                ddlSubItem1.DataSource = (List<Item>)(Cache["Items" + Session["CNN2"].ToString()]);
                ddlSubItem2.DataSource = (List<Item>)(Cache["Items" + Session["CNN2"].ToString()]);
                ddlSubItem1.DataBind();
                ddlSubItem2.DataBind();
                ddlSubItem1.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectAlter").ToString(), "-1", true));   // "--- أختر الصنف البديل ---"
                ddlSubItem2.Items.Insert(0, new ListItem(GetLocalResourceObject("SelectAlter").ToString(), "-1", true)); // "--- أختر الصنف البديل ---"
                TreeView1.ExpandAll();
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        public void LoadStockData()
        {
            try
            {
                grdCodes.DataSource = MyItemStock;
                grdCodes.DataBind();
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void PopulateNodes(List<ICat> mycode, TreeNodeCollection nodes)
        {
            try
            {
                for (int i = 0; i < mycode.Count; i++)
                {
                    TreeNode tr = new TreeNode();
                    tr.Text = mycode[i].Name1;
                    tr.Value = mycode[i].Code;
                    //tr.ToolTip = mycode[i].Ftype;
                    nodes.Add(tr);

                    //'If node has child nodes, then enable on-demand populating
                    tr.PopulateOnDemand = true; // (CInt(dr("childnodecount")) > 0);
                    tr.PopulateOnDemand = mycode[i].IsFather(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void PopulateSubLevel(string parentcode, TreeNode parentNode)
        {
            try
            {
                ICat mycat = new ICat();
                mycat.Branch = short.Parse(Session["Branch"].ToString());
                mycat.FCode = parentcode;
                PopulateNodes(mycat.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString), parentNode.ChildNodes);
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }


        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                if (TreeView1.SelectedNode.Depth == 1)
                {
                    PopupControlExtender.GetProxyForCurrentPopup(this).Commit(TreeView1.SelectedNode.Text);
                    txtICat.ToolTip = TreeView1.SelectedNode.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void TreeView1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            try
            {
                PopulateSubLevel(e.Node.Value, e.Node);
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtICat.Text != "")
                {
                    ICat mycat = new ICat();
                    mycat.Branch = short.Parse(Session["Branch"].ToString());
                    mycat.Name1 = txtICat.Text;
                    mycat = mycat.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    txtICat.Text = mycat.Name1;
                    txtICat.ToolTip = mycat.Code;
                    TreeView1.ExpandAll();
                    TreeView1.FindNode(mycat.FCode + '/' + mycat.Code).Select();
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
                txtICat.Text = "";
                txtICat.ToolTip = "";
                txtITCode.Text = "";
                txtITName1.Text = "";
                txtITName2.Text = "";
                txtITCPrice.Text = "";
                txtITEqual.Text = "1";
                txtITLPrice1.Text = "";
                txtITLPrice2.Text = "";
                txtITReorder.Text = "";
                txtItSPrice1.Text = "";
                txtITSPrice2.Text = "";
                txtRemark.Text = "";
                ddlIColor.SelectedIndex = -1;
                ddlICOO.SelectedIndex = -1;
                ddlISize.SelectedIndex = -1;
                ddlitUnit1.SelectedIndex = -1;
                ddlitUnit2.SelectedIndex = -1;
                ddlIWidth.SelectedIndex = -1;
                ddlSubItem1.SelectedIndex = -1;
                ddlSubItem2.SelectedIndex = -1;
                txtITCode0.Text = "";
                txtITCode2.Text = "";
                txtNCode.Text = "";
                ChkReturnItem.Checked = true;

                MyItemStock.Clear();
                ItemStock myStock = new ItemStock();
                myStock.Branch = short.Parse(Session["Branch"].ToString());
                MyItemStock = myStock.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                LoadStockData();

                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());

                // Check if AutoCounter
                Item myItem = new Item();
                myItem.Branch = short.Parse(Session["Branch"].ToString());
                string s9 = myItem.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (s9 == "0" || s9 == null)
                {
                    s9 = "000001";
                }
                else
                {
                    s9 = s9.Substring(0, s9.Length - 1);
                    s9 = (Int32.Parse(s9) + 1).ToString();
                }
                txtITCode.Text = moh.MakeMask(s9, 6);
                txtITCode0.Text = "B";

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
                    if(txtITCode0.Text.Trim()=="")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("EnterItem2").ToString(); // "يجب ادخل حرف الصنف";
                        txtITCode0.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    Item myItem = new Item();
                    myItem.Branch = short.Parse(Session["Branch"].ToString());
                    myItem.ITCode = txtITCode.Text.Trim() + txtITCode0.Text.Trim();
                    if (myItem.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) != null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("ItemFound").ToString(); // "كود الصنف مدخل من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                    else
                    {
                        if (txtICat.ToolTip != "")
                        {
                            ICat mycat = new ICat();
                            mycat.Branch = short.Parse(Session["Branch"].ToString());
                            mycat.Code = txtICat.ToolTip;
                            mycat = mycat.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (mycat != null)
                            {
                                if (mycat.FCode == "") 
                                {
                                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                    LblCodesResult.Text = GetLocalResourceObject("ICatValid").ToString(); // "يجب أختيار النوع الفرعي للصنف";
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                    return;
                                }
                            }
                            else
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = GetLocalResourceObject("InvalidICat").ToString(); // "نوع الصنف غير معرف من قبل";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("EnterItem").ToString(); // "يجب إدخال نوع الصنف";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }


                        double vOpen = 0;
                        for (int i = 0; i < grdCodes.Rows.Count; i++)
                        {
                            TextBox txtIOpen = grdCodes.Rows[i].FindControl("txtIOpen") as TextBox;
                            if (txtIOpen != null )
                            {
                                if (txtIOpen.Text == "") txtIOpen.Text = "0.00";
                                vOpen += double.Parse(txtIOpen.Text);
                            }
                        }                                                                

                        myItem.Branch = short.Parse(Session["Branch"].ToString());
                        myItem.ITCode = txtITCode.Text + txtITCode0.Text;
                        myItem.ICat = txtICat.ToolTip;
                        myItem.FType = 1;
                        myItem.ITName1 = txtITName1.Text;
                        myItem.ITName2 = txtITName2.Text;
                        if (txtITReorder.Text == "") txtITReorder.Text = "0.00";
                        myItem.ITreorder = double.Parse(txtITReorder.Text);
                        myItem.IColor = ddlIColor.SelectedValue;
                        myItem.ICoo = ddlICOO.SelectedValue;
                        myItem.ISize = ddlISize.SelectedValue;
                        if (txtITCPrice.Text  == "" ) txtITReorder.Text = "0.00";
                        myItem.ITCPrice = double.Parse(txtITCPrice.Text);                        
                        if (txtITEqual.Text == "") txtITEqual.Text = "1.00";
                        myItem.ITEqual = double.Parse(txtITEqual.Text);
                        if (txtITLPrice1.Text == "") txtITLPrice1.Text = "0.00";
                        myItem.ITLprice1 = double.Parse(txtITLPrice1.Text);
                        if (txtITLPrice2.Text == "") txtITLPrice2.Text = "0.00";
                        myItem.ITLprice2 = double.Parse(txtITLPrice2.Text);
                        if (txtItSPrice1.Text == "") txtItSPrice1.Text = "0.00";
                        myItem.ITSprice1 = double.Parse(txtItSPrice1.Text);
                        if (txtITSPrice2.Text == "") txtITSPrice2.Text = "0.00";
                        myItem.ITSprice2 = double.Parse(txtITSPrice2.Text);
                        myItem.ITUnit1 = ddlitUnit1.SelectedValue;
                        myItem.ITUnit2 = ddlitUnit2.SelectedValue;
                        myItem.IWidth = ddlIWidth.SelectedValue;
                        myItem.Remark = txtRemark.Text;
                        myItem.SubItem1 = ddlSubItem1.SelectedValue;
                        myItem.SubItem2 = ddlSubItem2.SelectedValue;
                        myItem.UserName = txtUserName.ToolTip;
                        myItem.UserDate = txtUserDate.Text;
                        myItem.IOpen = vOpen;
                        myItem.AOpen = vOpen * myItem.ITCPrice;
                        myItem.ITCode0 = txtITCode0.Text;
                        myItem.ITCode2 = txtITCode2.Text;
                        myItem.NCode = txtNCode.Text;
                        if (myItem.ITCode2.Trim() != "") myItem.ITCode2 = txtITCode.Text;
                        myItem.ReturnItem = ChkReturnItem.Checked;
                        if (myItem.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            for (int i = 0; i < grdCodes.Rows.Count; i++)
                            {
                                TextBox txtLoc = grdCodes.Rows[i].FindControl("txtLoc") as TextBox;
                                TextBox txtIOpen = grdCodes.Rows[i].FindControl("txtIOpen") as TextBox;
                                TextBox txtOpenDate = grdCodes.Rows[i].FindControl("txtOpenDate") as TextBox;
                                string Number = grdCodes.DataKeys[i]["Number"].ToString();
                                if (txtLoc != null && txtIOpen != null && txtOpenDate != null && Number != null)
                                {
                                    if (txtIOpen.Text == "") txtIOpen.Text = "0.00";
                                    Stock myStock = new Stock();
                                    myStock.Branch = short.Parse(Session["Branch"].ToString());
                                    myStock.Code = txtITCode.Text.Trim() + txtITCode0.Text.Trim();
                                    myStock.IOpen = double.Parse(txtIOpen.Text);
                                    myStock.AOpen = double.Parse(txtIOpen.Text) * myItem.ITCPrice;
                                    myStock.Loc = txtLoc.Text;
                                    myStock.Number = short.Parse(Number);
                                    myStock.OpenDate = txtOpenDate.Text;
                                    myStock.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                                    if (myStock.AOpen != 0)
                                    {
                                        String vStockAccount = "";

                                        Shop myShop = new Shop();
                                        myShop.FType = 2;
                                        myShop.Bran = 1;
                                        myShop.Number = short.Parse(Number);
                                        if (myShop.GetShop(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                        {
                                            vStockAccount = myShop.CPur_Acc + moh.MakeMask(Number,2);
                                        }

                                        ICat myCat = new ICat();
                                        myCat.Branch = short.Parse(Session["Branch"].ToString());
                                        myCat.Code = myItem.ICat;
                                        myCat = myCat.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if (myCat != null)
                                        {
                                            vStockAccount += myCat.CPur_Acc;
                                        }

                                        Acc myAcc = new Acc();
                                        myAcc.Branch = short.Parse(Session["Branch"].ToString());
                                        myAcc.Code = vStockAccount;
                                        myAcc.Post(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, 1, (double)myStock.AOpen);
                                    }

                                }
                            }

                            LblCodesResult.ForeColor = System.Drawing.Color.Green; // ItemAdded
                            LblCodesResult.Text = GetLocalResourceObject("ItemAdded").ToString();  // "لقد تمت أضافة البيانات بنجاح";
                            SetItemCache();
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("AddError").ToString();  // "لقد حدث خطأ اثناء أضافة البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
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

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (txtITCode0.Text.Trim() == "")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("EnterItem2").ToString();  // ""يجب ادخل حرف الصنف";
                        txtITCode0.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                    Item myItem = new Item();
                    myItem.Branch = short.Parse(Session["Branch"].ToString());
                    myItem.ITCode = txtITCode.Text.Trim() + txtITCode0.Text.Trim();
                    myItem = myItem.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myItem == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("ItemNotFound").ToString();  //  "كود الصنف غير مدرج من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                    else
                    {
                        if (txtICat.ToolTip != "")
                        {
                            ICat mycat = new ICat();
                            mycat.Branch = short.Parse(Session["Branch"].ToString());
                            mycat.Code = txtICat.ToolTip;
                            mycat = mycat.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (mycat != null)
                            {
                                if (mycat.FCode == "")
                                {
                                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                    LblCodesResult.Text = GetLocalResourceObject("ICatValid").ToString();  //  "يجب أختيار النوع الفرعي للصنف";
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                    return;
                                }
                            }
                            else
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = GetLocalResourceObject("InvalidICat").ToString();  //   "نوع الصنف غير معرف من قبل";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                                return;
                            }
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("ICatValid").ToString();  //   "يجب إدخال نوع الصنف";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }

                        double vOpen = 0;
                        for (int i = 0; i < grdCodes.Rows.Count; i++)
                        {
                            TextBox txtIOpen = grdCodes.Rows[i].FindControl("txtIOpen") as TextBox;
                            if (txtIOpen != null)
                            {
                                if (txtIOpen.Text == "") txtIOpen.Text = "0.00";
                                vOpen += double.Parse(txtIOpen.Text);
                            }
                        }                                                                

                        myItem.Branch = short.Parse(Session["Branch"].ToString());
                        myItem.ITCode = txtITCode.Text.Trim() + txtITCode0.Text.Trim();
                        myItem.ICat = txtICat.ToolTip;
                        myItem.FType = 1;
                        myItem.ITName1 = txtITName1.Text;
                        myItem.ITName2 = txtITName2.Text;
                        if (txtITReorder.Text == "") txtITReorder.Text = "0.00";
                        myItem.ITreorder = double.Parse(txtITReorder.Text);
                        myItem.IColor = ddlIColor.SelectedValue;
                        myItem.ICoo = ddlICOO.SelectedValue;
                        myItem.ISize = ddlISize.SelectedValue;
                        if (txtITCPrice.Text == "") txtITReorder.Text = "0.00";
                        myItem.ITCPrice = double.Parse(txtITCPrice.Text);
                        if (txtITEqual.Text == "") txtITEqual.Text = "1.00";
                        myItem.ITEqual = double.Parse(txtITEqual.Text);
                        if (txtITLPrice1.Text == "") txtITLPrice1.Text = "0.00";
                        myItem.ITLprice1 = double.Parse(txtITLPrice1.Text);
                        if (txtITLPrice2.Text == "") txtITLPrice2.Text = "0.00";
                        myItem.ITLprice2 = double.Parse(txtITLPrice2.Text);
                        if (txtItSPrice1.Text == "") txtItSPrice1.Text = "0.00";
                        myItem.ITSprice1 = double.Parse(txtItSPrice1.Text);
                        if (txtITSPrice2.Text == "") txtITSPrice2.Text = "0.00";
                        myItem.ITSprice2 = double.Parse(txtITSPrice2.Text);
                        myItem.ITUnit1 = ddlitUnit1.SelectedValue;
                        myItem.ITUnit2 = ddlitUnit2.SelectedValue;
                        myItem.IWidth = ddlIWidth.SelectedValue;
                        myItem.Remark = txtRemark.Text;
                        myItem.UserName = txtUserName.ToolTip;
                        myItem.UserDate = txtUserDate.Text;
                        myItem.SubItem1 = ddlSubItem1.SelectedValue;
                        myItem.SubItem2 = ddlSubItem2.SelectedValue;
                        myItem.UserName = Session["CurrentUser"].ToString();
                        myItem.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        myItem.IOpen = vOpen;
                        myItem.AOpen = vOpen * myItem.ITCPrice;
                        myItem.ITCode0 = txtITCode0.Text;
                        myItem.ITCode2 = txtITCode2.Text;
                        myItem.NCode = txtNCode.Text;
                        myItem.ReturnItem = ChkReturnItem.Checked;
                        if (myItem.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            for (int i = 0; i < grdCodes.Rows.Count; i++)
                            {
                                double vOldQuan = 0;
                                double AOpen = 0;

                                TextBox txtLoc = grdCodes.Rows[i].FindControl("txtLoc") as TextBox;
                                TextBox txtIOpen = grdCodes.Rows[i].FindControl("txtIOpen") as TextBox;
                                TextBox txtOpenDate = grdCodes.Rows[i].FindControl("txtOpenDate") as TextBox;
                                string Number = grdCodes.DataKeys[i]["Number"].ToString();
                                if (txtLoc != null && txtIOpen != null && txtOpenDate != null && Number != null)
                                {                                    
                                    Stock myStock2 = new Stock();
                                    myStock2.Branch = short.Parse(Session["Branch"].ToString());
                                    myStock2.Code = txtITCode.Text.Trim() + txtITCode0.Text.Trim();
                                    myStock2.Number = short.Parse(Number);
                                    myStock2 = myStock2.GetItem(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                    if (myStock2 != null)
                                    {
                                        vOldQuan = (double)(myStock2.IOpen * myItem.ITCPrice);

                                        if (txtIOpen.Text == "") txtIOpen.Text = "0.00";
                                        Stock myStock = new Stock();
                                        myStock.Branch = short.Parse(Session["Branch"].ToString());
                                        myStock.Code = txtITCode.Text.Trim() + txtITCode0.Text.Trim();
                                        myStock.Number = short.Parse(Number);
                                        myStock = myStock.GetItem(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if (myStock != null)
                                        {
                                            myStock.IOpen = double.Parse(txtIOpen.Text);
                                            myStock.AOpen = double.Parse(txtIOpen.Text) * myItem.ITCPrice;
                                            myStock.Loc = txtLoc.Text;
                                            myStock.OpenDate = txtOpenDate.Text;
                                            myStock.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        }
                                        AOpen = (double)myStock.AOpen;
                                    }
                                    else
                                    {
                                        if (txtIOpen.Text == "") txtIOpen.Text = "0.00";
                                        Stock myStock = new Stock();
                                        myStock.Branch = short.Parse(Session["Branch"].ToString());
                                        myStock.Code = txtITCode.Text.Trim() + txtITCode0.Text.Trim();
                                        myStock.IOpen = double.Parse(txtIOpen.Text);
                                        myStock.AOpen = double.Parse(txtIOpen.Text) * myItem.ITCPrice;
                                        myStock.Loc = txtLoc.Text;
                                        myStock.Number = short.Parse(Number);
                                        myStock.OpenDate = txtOpenDate.Text;
                                        myStock.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        AOpen = (double)myStock.AOpen;
                                    }

                                    if (AOpen-vOldQuan != 0)
                                    {
                                        String vStockAccount = "";

                                        Shop myShop = new Shop();
                                        myShop.FType = 2;
                                        myShop.Bran = 1;
                                        myShop.Number = short.Parse(Number);
                                        if (myShop.GetShop(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                        {
                                            vStockAccount = myShop.CPur_Acc + moh.MakeMask(Number, 2);
                                        }

                                        ICat myCat = new ICat();
                                        myCat.Branch = short.Parse(Session["Branch"].ToString());
                                        myCat.Code = myItem.ICat;
                                        myCat = myCat.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if (myCat != null)
                                        {
                                            vStockAccount += myCat.CPur_Acc;
                                        }

                                        Acc myAcc = new Acc();
                                        myAcc.Branch = short.Parse(Session["Branch"].ToString());
                                        myAcc.Code = vStockAccount;
                                        myAcc.Post(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, 1, AOpen - vOldQuan);
                                    }
                                }
                            }
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = GetLocalResourceObject("DataUpdated").ToString();  //   "لقد تم تعديل البيانات بنجاح";
                            SetItemCache();
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("UpdateError").ToString();  //    "لقد حدث خطأ اثناء تعديل البيانات ... حاول مرة أخرى";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
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
                    Item myItem = new Item();
                    myItem.Branch = short.Parse(Session["Branch"].ToString());
                    myItem.ITCode = txtITCode.Text.Trim() + txtITCode0.Text.Trim();
                    myItem = myItem.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myItem == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("ItemNotFound").ToString();  //     "كود الصنف غير مدرج من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                    else
                    {
                        if (myItem.IOpen != 0 || myItem.IPurch != 0 | myItem.ISale != 0 | myItem.ITemp != 0)
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = GetLocalResourceObject("BalanceFound").ToString();  //     "لا يمكن الغاء الصنف لوجود أرصدة او حركات";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        }
                        else
                        {
                            if (myItem.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                for (int i = 0; i < grdCodes.Rows.Count; i++)
                                {
                                    double vOldQuan = 0;
                                    TextBox txtLoc = grdCodes.Rows[i].FindControl("txtLoc") as TextBox;
                                    TextBox txtIOpen = grdCodes.Rows[i].FindControl("txtIOpen") as TextBox;
                                    TextBox txtOpenDate = grdCodes.Rows[i].FindControl("txtOpenDate") as TextBox;
                                    string Number = grdCodes.DataKeys[i]["Number"].ToString();
                                    if (txtLoc != null && txtIOpen != null && txtOpenDate != null && Number != null)
                                    {
                                        Stock myStock2 = new Stock();
                                        myStock2.Branch = short.Parse(Session["Branch"].ToString());
                                        myStock2.Code = txtITCode.Text.Trim() + txtITCode0.Text.Trim();
                                        myStock2.Number = short.Parse(Number);
                                        myStock2 = myStock2.GetItem(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if (myStock2 != null)
                                        {
                                            vOldQuan = (double)(myStock2.IOpen * myItem.ITCPrice);
                                        }

                                        if (txtIOpen.Text == "") txtIOpen.Text = "0.00";
                                        Stock myStock = new Stock();
                                        myStock.Branch = short.Parse(Session["Branch"].ToString());
                                        myStock.Code = txtITCode.Text.Trim() + txtITCode0.Text.Trim();
                                        myStock.Number = short.Parse(Number);
                                        myStock = myStock.GetItem(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        if (myStock != null)
                                        {
                                            myStock.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                        }

                                        if (vOldQuan != 0)
                                        {
                                            String vStockAccount = "";

                                            Shop myShop = new Shop();
                                            myShop.FType = 2;
                                            myShop.Bran = 1;
                                            myShop.Number = short.Parse(Number);
                                            if (myShop.GetShop(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                            {
                                                vStockAccount = myShop.CPur_Acc + moh.MakeMask(Number, 2);
                                            }

                                            ICat myCat = new ICat();
                                            myCat.Branch = short.Parse(Session["Branch"].ToString());
                                            myCat.Code = myItem.ICat;
                                            myCat = myCat.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                            if (myCat != null)
                                            {
                                                vStockAccount += myCat.CPur_Acc;
                                            }

                                            Acc myAcc = new Acc();
                                            myAcc.Branch = short.Parse(Session["Branch"].ToString());
                                            myAcc.Code = vStockAccount;
                                            myAcc.Post(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, 1, vOldQuan * -1);
                                        }
                                    }
                                }

                                Transactions UserTran = new Transactions();
                                UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                                UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                                UserTran.UserName = txtUserName.ToolTip;
                                UserTran.Description = "الغاء بيانات الصنف  " + txtITName1.Text;
                                UserTran.FormAction = "الغاء";
                                UserTran.FormName = "اصناف البضاعة";
                                UserTran.IP = IPNetworking.GetIP4Address();
                                UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);

                                SetItemCache();
                                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                                LblCodesResult.Text = GetLocalResourceObject("ItemDeleted").ToString();  //     "لقد تم الغاء البيانات بنجاح";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                                BtnClear_Click(sender, e);
                            }
                            else
                            {
                                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                                LblCodesResult.Text = GetLocalResourceObject("DeleteError").ToString();  //     "لقد حدث خطأ اثناء الغاء البيانات ... حاول مرة أخرى";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
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

        protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtITCode.Text != "" && txtITCode0.Text != "")
                {
                    // Check if AutoCounter
                    MyItemStock.Clear();
                    txtITCode.Text = moh.MakeMask(txtITCode.Text.Trim(), 6);

                    Item myItem = new Item();
                    myItem.Branch = short.Parse(Session["Branch"].ToString());
                    myItem.ITCode = txtITCode.Text + txtITCode0.Text.Trim();
                    myItem.FType = 1;
                    myItem = myItem.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myItem == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = GetLocalResourceObject("ItemNotFound").ToString();  // "كود الصنف غير مدرج من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        BtnClear_Click(sender, e);
                    }
                    else
                    {
                        EditMode();
                        //txtITCode.Text = myItem.ITCode;
                        txtICat.ToolTip = myItem.ICat;

                        ICat mycat = new ICat();
                        mycat.Branch = short.Parse(Session["Branch"].ToString());
                        mycat.Code = myItem.ICat;
                        mycat = mycat.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (mycat != null)
                        {
                            txtICat.Text = mycat.Name1;
                            txtICat.ToolTip = mycat.Code;
                            TreeView1.ExpandAll();
                            TreeView1.FindNode(mycat.FCode + '/' + mycat.Code).Select();
                        }
                        txtITName1.Text = myItem.ITName1;
                        txtITName2.Text = myItem.ITName2;
                        txtITReorder.Text = string.Format("{0:N2}", myItem.ITreorder);
                        ddlIColor.SelectedValue = myItem.IColor;
                        ddlICOO.SelectedValue = myItem.ICoo;
                        ddlISize.SelectedValue = myItem.ISize;
                        txtITCPrice.Text = string.Format("{0:N2}", myItem.ITCPrice);
                        txtITEqual.Text = string.Format("{0:N2}", myItem.ITEqual);
                        txtITLPrice1.Text = string.Format("{0:N2}", myItem.ITLprice1);
                        txtITLPrice2.Text = string.Format("{0:N2}", myItem.ITLprice2);
                        txtItSPrice1.Text = string.Format("{0:N2}", myItem.ITSprice1);
                        txtITSPrice2.Text = string.Format("{0:N2}", myItem.ITSprice2);
                        ddlitUnit1.SelectedValue = myItem.ITUnit1;
                        ddlitUnit2.SelectedValue = myItem.ITUnit2;
                        ddlIWidth.SelectedValue = myItem.IWidth;
                        txtRemark.Text = myItem.Remark;
                        ddlSubItem1.SelectedValue = myItem.SubItem1;
                        ddlSubItem2.SelectedValue = myItem.SubItem2;
                        txtITCode0.Text = myItem.ITCode0;
                        txtITCode2.Text = myItem.ITCode2;
                        txtNCode.Text = myItem.NCode;
                        ChkReturnItem.Checked = (bool)myItem.ReturnItem;

                        txtUserName.ToolTip = myItem.UserName;
                        TblUsers ax = new TblUsers();
                        if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        ax.UserName = myItem.UserName;
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

                        ItemStock Stock = new ItemStock();
                        Stock.Branch = short.Parse(Session["Branch"].ToString());
                        MyItemStock = Stock.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        Stock myStock = new Stock();
                        myStock.Branch = short.Parse(Session["Branch"].ToString());
                        myStock.Code = myItem.ITCode;
                        foreach (Stock itm in myStock.GetItems(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            foreach (ItemStock itmstock in MyItemStock)
                            {
                                if (itm.Number == itmstock.Number)
                                {
                                    itmstock.IOpen = itm.IOpen;
                                    break;
                                }
                            }
                        }
                        LoadStockData();
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = GetLocalResourceObject("EnterItem").ToString();  //  "يجب إدخال كود الصنف";
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

        public void SetItemCache()
        {
            if (Cache["Items" + Session["CNN2"].ToString()] != null) Cache.Remove("Items" + Session["CNN2"].ToString());
            Item myItem = new Item();
            myItem.Branch = 1;
            Cache.Insert("Items" + Session["CNN2"].ToString(), myItem.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
        }

    }
}