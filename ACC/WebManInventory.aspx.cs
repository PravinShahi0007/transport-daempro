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
using System.Configuration;
using System.Web.UI.HtmlControls;
using iTextSharp.text.pdf;
using System.IO;


namespace ACC
{
    public partial class WebManInventory : System.Web.UI.Page
    {
        public List<vyStock> VouData
        {
            get
            {
                if (ViewState["VouData"] == null)
                {
                    ViewState["VouData"] = new List<vyStock>();
                }
                return (List<vyStock>)ViewState["VouData"];
            }
            set
            {
                ViewState["VouData"] = value;

            }
        }

        public List<Acc1> ActionList
        {
            get
            {
                if (ViewState["ActionList"] == null)
                {
                    ViewState["ActionList"] = new List<Acc1>();
                }
                return (List<Acc1>)ViewState["ActionList"];
            }
            set
            {
                ViewState["ActionList"] = value;

            }
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
                BtnPrint1.OnClientClick = string.Format("{0}.target='_blank';", ((HtmlForm)Page.Master.FindControl("form1")).ClientID);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnPrint1);
                ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttach);

                if (!Page.IsPostBack)
                {
                    Session["Branch"] = "1";
                    this.Page.Header.Title = "Manual Inventory Data Entery";
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

                    List<string> lTech = new List<string>();
                    Tech myTech = new Tech();
                    lTech = (from itm in myTech.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                             where !string.IsNullOrEmpty(itm.AccountAcc) && itm.AccountAcc != "-1"
                             select itm.AccountAcc).ToList();

                    ActionList.Add(new Acc1 { Code = "-1", Name1 = "بدون تسوية" });
                    ActionList.Add(new Acc1 { Code = "-2", Name1 = "تحويل رصيد لصنف" });
                    Acc myAcc = new Acc();
                    myAcc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastACC" + Session["CNN2"].ToString()] == null) Cache.Insert("LastACC" + Session["CNN2"].ToString(), myAcc.GetLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ActionList.AddRange((from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                         where lTech.Contains(itm.Code) || itm.Code == "420103004" || itm.Code == "310202017"
                                         select itm).ToList().OrderByDescending(c => c.Code));
                                       
                    Shop myShop = new Shop();
                    myShop.FType = 2;
                    myShop.Bran = short.Parse(Session["Branch"].ToString());
                    ddlStore.DataTextField = GetGlobalResourceObject("Resource", "Name").ToString();
                    ddlStore.DataValueField = "Number";
                    ddlStore.DataSource = myShop.GetAllType(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    ddlStore.DataBind();                    
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

        public void LoadGridData()
        {
            grdCodes.DataSource = VouData;
            grdCodes.DataBind();
            divEdit.Visible = (VouData.Count > 0);
            BtnPrint1.Visible = divEdit.Visible;
            for (int i = 0; i < grdCodes.Rows.Count; i++)
            {
                TextBox txtFBal = grdCodes.Rows[i].FindControl("txtFBal") as TextBox;
                Label lblBal = grdCodes.Rows[i].FindControl("lblBal") as Label;
                Label lblFDed = grdCodes.Rows[i].FindControl("lblFDed") as Label;
                Label lblFAdd = grdCodes.Rows[i].FindControl("lblFAdd") as Label;
                txtFBal.Attributes.Add("onchange", "javascript:CallMe('" + txtFBal.ClientID + "', '" + lblBal.ClientID + "', ['" + lblFDed.ClientID + "', '" + lblFAdd.ClientID + "'])");
                
            }
        }

        protected void grdCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdCodes.PageIndex = e.NewPageIndex;
                LoadGridData();
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
                    foreach (GridViewRow gvr in grdCodes.Rows)
                    {
                        string Code = grdCodes.DataKeys[gvr.RowIndex]["Code"].ToString();
                        TextBox txtFBal = gvr.FindControl("txtFBal") as TextBox;
                        TextBox txtPrice = gvr.FindControl("txtPrice") as TextBox;
                        Label lblBal = gvr.FindControl("lblBal") as Label;
                        DropDownList ddlAction = gvr.FindControl("ddlAction") as DropDownList;
                        HiddenField txtAction = gvr.FindControl("txtAction") as HiddenField;
                        if (Code != null && txtFBal != null && txtPrice != null && lblBal != null && ddlAction != null && txtAction != null)
                        {
                            yStock myStock = new yStock();
                            myStock.Branch = short.Parse(Session["Branch"].ToString());
                            myStock.Code = Code;
                            myStock.Number = short.Parse(ddlStore.SelectedValue);
                            myStock.FYear = txtFYear.Text;
                            myStock = myStock.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (myStock == null || txtAction.Value != "")
                            {
                                if (lblBal.Text == "") lblBal.Text = "0";
                                if (txtFBal.Text == "") txtFBal.Text = "0";
                                if (txtPrice.Text == "") txtPrice.Text = "0";

                                foreach (vyStock itm in VouData)
                                {
                                    if (itm.Code == Code)
                                    {
                                        itm.FStatus = ddlAction.SelectedValue;
                                        itm.FBal = double.Parse(txtFBal.Text);
                                        itm.Price = double.Parse(txtPrice.Text);
                                        break;
                                    }
                                }
                                if (myStock == null)
                                {
                                    myStock = new yStock();
                                    myStock.Branch = short.Parse(Session["Branch"].ToString());
                                    myStock.Code = Code;
                                    myStock.Number = short.Parse(ddlStore.SelectedValue);
                                    myStock.FYear = txtFYear.Text;
                                    myStock.FStatus = ddlAction.SelectedValue;
                                    myStock.Bal = double.Parse(lblBal.Text);
                                    myStock.FBal = double.Parse(txtFBal.Text);
                                    myStock.Price = double.Parse(txtPrice.Text);
                                    if (myStock.Bal - myStock.FBal > 0) myStock.Price2 = GetPrice(myStock.Number, myStock.Code, (double)(myStock.Bal - myStock.FBal));
                                    myStock.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                }
                                else
                                {
                                    myStock.FStatus = ddlAction.SelectedValue;
                                    myStock.Bal = double.Parse(lblBal.Text);
                                    myStock.FBal = double.Parse(txtFBal.Text);
                                    myStock.Price = double.Parse(txtPrice.Text);
                                    if (myStock.Bal - myStock.FBal > 0) myStock.Price2 = GetPrice(myStock.Number, myStock.Code, (double)(myStock.Bal - myStock.FBal));
                                    myStock.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);                                    
                                }
                            }
                        }
                    }
                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "DispMessage(1,'" + LblCodesResult.Text + "');", true);
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGridData();
        }

        protected void BtnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Page.Validate(); 

                if (Page.IsValid)
                {
                    BtnAdd.Visible = false;
                    BtnDed.Visible = false;
                    // Check if Existing yStock
                    VouData.Clear();
                    List<vyStock> ls = new List<vyStock>();
                    yStock myStock2 = new yStock();
                    myStock2.Branch = short.Parse(Session["Branch"].ToString());
                    myStock2.Number = short.Parse(ddlStore.SelectedValue);
                    myStock2.FYear = txtFYear.Text;
                    ls = (from itm in myStock2.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                          where ddlType.SelectedValue == "0" || (ddlType.SelectedValue == "1" && itm.Bal != itm.FBal ) || (ddlType.SelectedValue == "2" && itm.FBal < itm.Bal ) ||(ddlType.SelectedValue == "3" &&  itm.FBal > itm.Bal)
                          select itm).ToList();
                    if (ls != null && ls.Count > 0)
                    {
                        VouData.AddRange((from itm in ls
                                          select new vyStock
                                          {
                                              FYear = txtFYear.Text,
                                              Number = itm.Number,
                                              Branch = itm.Branch,
                                              Code = itm.Code,
                                              Bal = itm.Bal,
                                              FBal = itm.FBal,
                                              Price = itm.Price,
                                              ITName1 = itm.ITName1,
                                              ITName2 = itm.ITName2,
                                              Price2 = itm.Price2
                                          }).ToList());


                        Session.Add("ManInventory", VouData);
                        BtnDed.NavigateUrl = @"~\WebIssueNote.aspx?ManInventory=1&AreaNo="+Request.QueryString["AreaNo"].ToString()+"&StoreNo="+Request.QueryString["StoreNo"].ToString();
                        BtnAdd.NavigateUrl = @"~\WebDeliveryNote.aspx?ManInventory=1&AreaNo=" + Request.QueryString["AreaNo"].ToString() + "&StoreNo=" + Request.QueryString["StoreNo"].ToString();
                        BtnAdd.Visible = true;
                        BtnDed.Visible = true; 
                    }
                    else
                    {
                        List<StockPeriod> lsp = new List<StockPeriod>();
                        STS mysts = new STS();
                        mysts.Branch = short.Parse(Session["Branch"].ToString());
                        mysts.VouLoc = short.Parse(ddlStore.SelectedValue);
                        lsp = mysts.GetStatement("01/01/2014", txtFYear.Text, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        //public double GetQty(short StoreNo, short FType , string code,List<StockPeriod> lsp)

                        vStock myStock = new vStock();
                        myStock.Branch = short.Parse(Session["Branch"].ToString());
                        myStock.Number = short.Parse(ddlStore.SelectedValue);
                        VouData.AddRange((from itm in myStock.GetNumber(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                          select new vyStock
                                          {
                                              FYear = txtFYear.Text,
                                              Number = itm.Number,
                                              Branch = itm.Branch,
                                              Code = itm.Code,
                                              Bal = itm.IOpen + GetQty(601, itm.Code, lsp) - GetQty(502, itm.Code, lsp) - GetQty(701, itm.Code, lsp) - GetQty(710, itm.Code, lsp) + GetQty(711, itm.Code, lsp),
                                              FBal = 0,                                             
                                              Price = ((itm.IOpen * itm.ITCPrice) + GetOpenAmount(501, itm.Code, lsp) - GetOpenAmount(502, itm.Code, lsp) - GetOpenAmount(701, itm.Code, lsp) - GetOpenAmount(710, itm.Code, lsp) + GetOpenAmount(711, itm.Code, lsp) + GetAmount(501, itm.Code, lsp) + GetAmount(711, itm.Code, lsp) - (GetAmount(502, itm.Code, lsp) + GetAmount(701, itm.Code, lsp) + GetAmount(710, itm.Code, lsp))),
                                              ITName1 = itm.ITName1,
                                              ITName2 = itm.ITName2
                                          }).ToList());
                        foreach (vyStock itm in VouData)
                        {
                            itm.FBal = itm.Bal;
                            itm.Price =  Math.Round((double)(itm.Bal == 0 ? 0 : itm.Price / itm.Bal),2);
                        }
                    }
                    LoadGridData();
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

        public double GetQty(short FType, string code, List<StockPeriod> lsp)
        {
            double? Qty = (from itm in lsp
                           where itm.ITCode == code && itm.FType == FType
                           select (itm.Quan + itm.OpenQuan)).FirstOrDefault();
            return (Qty == null ? 0 : (double)Qty);
        }

        public double GetOpenAmount(short FType, string code, List<StockPeriod> lsp)
        {
            double? Amount = (from itm in lsp
                              where itm.ITCode == code && itm.FType == FType
                              select itm.OpenAmount).FirstOrDefault();
            return (Amount == null ? 0 : (double)Amount);
        }

        public double GetAmount(short FType, string code, List<StockPeriod> lsp)
        {
            double? Amount = (from itm in lsp
                              where itm.ITCode == code && itm.FType == FType
                              select itm.Amount).FirstOrDefault();
            return (Amount == null ? 0 : (double)Amount);
        }

        public double GetPrice(short StoreNo,string code,double Qty)
        {
            STP mySTP = new STP();
            mySTP.Branch = short.Parse(Session["Branch"].ToString());
            mySTP.VouLoc = StoreNo;
            mySTP.ITCode = code;
            return mySTP.GetItemCostPrice(Qty, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
        }

        [System.Web.Services.WebMethod]
        public static string[] GetDate(string FBal , String Bal)
        {
            vyStock myStock = new vyStock();
            myStock.FBal = double.Parse(FBal);
            myStock.Bal = double.Parse(Bal);
            return new string[] { string.Format("{0:N0}", myStock.FDed), string.Format("{0:N0}", myStock.FAdd) };
        }

        protected void ddlAction_Init(object sender, EventArgs e)
        {
            DropDownList ddlAction = sender as DropDownList;
            GridViewRow gvr = ddlAction.NamingContainer as GridViewRow;
            string Code = grdCodes.DataKeys[gvr.RowIndex]["Code"].ToString();
            ddlAction.DataTextField = "name1";
            ddlAction.DataValueField = "Code";
            ddlAction.DataSource = ActionList;
            ddlAction.DataBind();

            yStock myStock = new yStock();
            myStock.Branch = short.Parse(Session["Branch"].ToString());
            myStock.Code = Code;
            myStock.Number = short.Parse(ddlStore.SelectedValue);
            myStock.FYear = txtFYear.Text;
            myStock = myStock.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myStock != null && myStock.FStatus != "-1") ddlAction.SelectedValue = myStock.FStatus;
        }

        protected void BtnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    List<StockPeriod> lsp = new List<StockPeriod>();
                    STS mysts = new STS();
                    mysts.Branch = short.Parse(Session["Branch"].ToString());
                    mysts.VouLoc = short.Parse(ddlStore.SelectedValue);
                    lsp = mysts.GetStatement("01/01/2014", txtFYear.Text, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    //public double GetQty(short StoreNo, short FType , string code,List<StockPeriod> lsp)
                    vStock myStock = new vStock();
                    myStock.Branch = short.Parse(Session["Branch"].ToString());
                    myStock.Number = short.Parse(ddlStore.SelectedValue);
                    int i = 0;
                    double? vBal = 0;
                    double? vPrice = 0;
                    double? vPrice2 = 0;
                    foreach(vStock itm in myStock.GetNumber(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        i = VouData.FindIndex(p => p.Code == itm.Code);
                        if( i > -1)
                        {
                            if (VouData[i].FDed > 0)
                            {
                                vPrice2 = GetPrice(itm.Number, itm.Code, (double)VouData[i].FDed);
                            }

                            //vBal = itm.IOpen + GetQty(601, itm.Code, lsp) - GetQty(502, itm.Code, lsp) - GetQty(701, itm.Code, lsp) - GetQty(710, itm.Code, lsp) + GetQty(711, itm.Code, lsp);
                            if (vBal > 0)
                            {
                                vPrice = ((itm.IOpen * itm.ITCPrice) + GetOpenAmount(501, itm.Code, lsp) - GetOpenAmount(502, itm.Code, lsp) - GetOpenAmount(701, itm.Code, lsp) - GetOpenAmount(710, itm.Code, lsp) + GetOpenAmount(711, itm.Code, lsp) + GetAmount(501, itm.Code, lsp) + GetAmount(711, itm.Code, lsp) - (GetAmount(502, itm.Code, lsp) + GetAmount(701, itm.Code, lsp) + GetAmount(710, itm.Code, lsp))) / vBal;
                                vPrice = Math.Round((double)vPrice, 2);
                                if (VouData[i].Bal != vBal || VouData[i].Price != vPrice || VouData[i].Price2 != vPrice2)
                                {
                                    VouData[i].Bal = vBal;
                                    VouData[i].Price = vPrice;
                                    VouData[i].Price2 = vPrice2;
                                    SaveStock(VouData[i]);
                                }
                            }
                            else if (VouData[i].Price2 != vPrice2)
                            {
                                VouData[i].Price2 = vPrice2;
                                SaveStock(VouData[i]);
                            }
                        }
                        else
                        {
                            VouData.Add(new vyStock
                            {
                                FYear = txtFYear.Text,
                                Number = itm.Number,
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Bal = itm.IOpen + GetQty(601, itm.Code, lsp) - GetQty(502, itm.Code, lsp) - GetQty(701, itm.Code, lsp) - GetQty(710, itm.Code, lsp) + GetQty(711, itm.Code, lsp),
                                FBal = itm.IOpen + GetQty(601, itm.Code, lsp) - GetQty(502, itm.Code, lsp) - GetQty(701, itm.Code, lsp) - GetQty(710, itm.Code, lsp) + GetQty(711, itm.Code, lsp),
                                //Price = GetPrice(itm.Number, itm.Code, itm.bal),
                                Price = Math.Round((double)((((itm.IOpen * itm.ITCPrice) + GetOpenAmount(501, itm.Code, lsp) - GetOpenAmount(502, itm.Code, lsp) - GetOpenAmount(701, itm.Code, lsp) - GetOpenAmount(710, itm.Code, lsp) + GetOpenAmount(711, itm.Code, lsp) + GetAmount(501, itm.Code, lsp) + GetAmount(711, itm.Code, lsp) - (GetAmount(502, itm.Code, lsp) + GetAmount(701, itm.Code, lsp) + GetAmount(710, itm.Code, lsp)))) / (itm.IOpen + GetQty(601, itm.Code, lsp) - GetQty(502, itm.Code, lsp) - GetQty(701, itm.Code, lsp) - GetQty(710, itm.Code, lsp) + GetQty(711, itm.Code, lsp))), 2),
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2
                            });

                            i = VouData.FindIndex(p => p.Code == itm.Code);
                            if (i > -1) SaveStock(VouData[i]);
                        }
                    }
                    LoadGridData();
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        public void SaveStock(vyStock Stockitm)
        {
            yStock myStock = new yStock();
            myStock.Branch = short.Parse(Session["Branch"].ToString());
            myStock.Code = Stockitm.Code;
            myStock.Number = Stockitm.Number;
            myStock.FYear = Stockitm.FYear;
            myStock = myStock.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myStock == null)
            {
                Stockitm.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            }
            else
            {
                Stockitm.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
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
                        myArch.LocNumber = 0;
                        myArch.Number = DateTime.Parse(txtFYear.Text).Year * 365 + DateTime.Parse(txtFYear.Text).Month * 30 + DateTime.Parse(txtFYear.Text).Day;
                        myArch.DocType = 667;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = 0;
                        myArch.Number = DateTime.Parse(txtFYear.Text).Year * 365 + DateTime.Parse(txtFYear.Text).Month * 30 + DateTime.Parse(txtFYear.Text).Day;
                        myArch.DocType = 667;
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
                myArch.LocNumber = 0;
                myArch.Number = DateTime.Parse(txtFYear.Text).Year * 365 + DateTime.Parse(txtFYear.Text).Month * 30 + DateTime.Parse(txtFYear.Text).Day;
                myArch.DocType = 667;
                myArch.FNo = short.Parse(FNo);
                myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                LoadAttachData();
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

        public void LoadAttachData()
        {
            if (txtFYear.Text != "")
            {
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(Session["Branch"].ToString());
                myArch.LocNumber = 0;
                myArch.Number = DateTime.Parse(txtFYear.Text).Year * 365 + DateTime.Parse(txtFYear.Text).Month * 30 + DateTime.Parse(txtFYear.Text).Day;
                myArch.DocType = 667;
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
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BtnFind_Click(sender, null);
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }

        }

        protected void BtnPrint1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), -50, -50, 80, 25);
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
                page.PageNo = "1";
                page.vStr1 = ddlType.SelectedItem.Text;
                page.UserName = Session["FullUser"].ToString();
                pw.PageEvent = page;
                document.Open();
                //PdfPTable table = new PdfPTable(grdCodes.HeaderRow.Cells.Count);
                PdfPTable table = new PdfPTable(12);
                float[] colWidths = { 50, 100, 250, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
                table.SetWidths(colWidths);
                PdfPCell cell = new PdfPCell();
                //cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                string arialunicodepath = Server.MapPath("Fonts") + @"\ARIALUNI.TTF"; //arial.ttf";
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 10f, iTextSharp.text.Font.NORMAL);

                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;

                int FNo = 1;
                double bal = 0, fbal = 0, fadd = 0, fded = 0, amount = 0, famount = 0, faddam = 0, fdedam = 0;
                foreach (vyStock itm in VouData)
                {
                    cell.Phrase = new iTextSharp.text.Phrase((FNo++).ToString(), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(itm.Code, nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase((itm.ITName1.Trim() != "" ? itm.ITName1 : itm.ITName2), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Bal), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.FBal), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Price), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.FAdd), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.FDed), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.Amount), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.FAmount), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.FAddam), nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", itm.FDedam), nationalTextFont);
                    table.AddCell(cell);


                    bal += (double)itm.Bal;
                    fbal += (double)itm.FBal;
                    fadd += (double)itm.FAdd;
                    fded += (double)itm.FDed;
                    amount += (double)itm.Amount;
                    famount += (double)itm.FAmount;
                    faddam += (double)itm.FAddam;
                    fdedam += (double)itm.FDedam;
                }
                cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Total", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", bal), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", fbal), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("   ", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", fadd), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", fded), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", amount), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", famount), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", faddam), nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", fdedam), nationalTextFont);
                table.AddCell(cell);

                document.Add(table);

                document.Close();
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }


        // *************************************************** ITextSharp ****************************************************************
        public class pdfPage : iTextSharp.text.pdf.PdfPageEventHelper
        {
            public string UserName, PageNo, vCompanyName, vStr1;
            //I create a font object to use within my footer
            protected iTextSharp.text.Font footer
            {
                get
                {
                    // create a basecolor to use for the footer font, if needed.
                    iTextSharp.text.BaseColor grey = new iTextSharp.text.BaseColor(128, 128, 128);
                    string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\ARIALUNI.TTF";
                    BaseFont nationalBase;
                    nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(nationalBase, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.WHITE);
                    return font;
                }
            }
            //override the OnStartPage event handler to add our header
            public override void OnStartPage(PdfWriter writer, iTextSharp.text.Document doc)
            {
                string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\ARIALUNI.TTF";
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 14f, iTextSharp.text.Font.NORMAL);

                //I use a PdfPtable with 1 column to position my header where I want it
                PdfPTable headerTbl = new PdfPTable(3);
                var cols2 = new[] { 200, 300, 200 };
                headerTbl.SetWidths(cols2);

                //headerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                //set the width of the table to be the same as the document
                headerTbl.TotalWidth = doc.PageSize.Width;

                PdfPCell cell2 = new PdfPCell();
                //cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell2.Border = 0;
                cell2.PaddingRight = 15;
                cell2.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont); // vCompanyName
                cell2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                headerTbl.AddCell(cell2);

                cell2 = new PdfPCell();
                cell2.Border = 0;
                cell2.PaddingRight = 0;
                cell2.Phrase = new iTextSharp.text.Phrase("Goods Manual Inventory Report" + "\n" + vStr1, nationalTextFont);
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

                arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\arial.ttf";
                //BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                nationalTextFont = new iTextSharp.text.Font(nationalBase, 10f, iTextSharp.text.Font.NORMAL);


                PdfPTable table = new PdfPTable(12);
                float[] colWidths = { 50,100, 250, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
                table.SetWidths(colWidths);
                PdfPCell cell = new PdfPCell();
                //cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                cell.Phrase = new iTextSharp.text.Phrase("No.", nationalTextFont);
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Item Code", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Description", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Balance", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Manual Balance", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Cost Price", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Addition", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Lost", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Amount", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Manual Amount", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Addition Amount", nationalTextFont);
                table.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("Lost Amount", nationalTextFont);
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
                //footerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                footerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                //set the width of the table to be the same as the document
                footerTbl.TotalWidth = doc.PageSize.Width;
                //Center the table on the page
                footerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                PdfPCell cell = new PdfPCell();
                //cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell.BackgroundColor = iTextSharp.text.BaseColor.RED;
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                //set cell border to 0
                cell.Border = 0;

                //add some padding to bring away from the edge
                cell.PaddingRight = 5;
                cell.Phrase = new iTextSharp.text.Phrase("Printed Date : " + String.Format("{0:dd/MM/yyyy}", moh.Nows()), footer);
                //add cell to table
                footerTbl.AddCell(cell);

                //create new instance of cell to hold the text
                //cell = new PdfPCell();



                //align the text to the right of the cell
                //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                //cell.Phrase = new iTextSharp.text.Phrase("     ", footer);
                cell.Phrase = new iTextSharp.text.Phrase("Printed By " + UserName, footer);

                // add some padding to take away from the edge of the page
                //cell.PaddingRight = 5;

                //add the cell to the table
                footerTbl.AddCell(cell);

                cell.Phrase = new iTextSharp.text.Phrase("No. of Print Times " + PageNo, footer);
                footerTbl.AddCell(cell);

                // add some padding to take away from the edge of the page
                //cell.PaddingRight = 5;

                //add the cell to the table

                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                cell.Phrase = new iTextSharp.text.Phrase("Page No. " + writer.PageNumber.ToString(), footer);

                // add some padding to take away from the edge of the page
                cell.PaddingLeft = 5;

                //add the cell to the table
                footerTbl.AddCell(cell);

                //write the rows out to the PDF output stream.
                footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin - 10), writer.DirectContent);
            }
        }

    }
}