using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;
using iTextSharp.text.pdf;
using System.IO;
using System.Threading;
using System.Globalization;

namespace ACC
{
    public partial class WebInvoice2 : System.Web.UI.Page
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
        public CostCenter SiteInfo
        {
            get
            {
                if (ViewState["SiteInfo"] == null)
                {
                    ViewState["SiteInfo"] = new CostCenter();
                }
                return (CostCenter)ViewState["SiteInfo"];
            }
            set { ViewState["SiteInfo"] = value; }
        }

        public List<InvDetails> VouData
        {
            get
            {
                if (ViewState["VouData"] == null)
                {
                    ViewState["VouData"] = new List<InvDetails>();
                }
                return (List<InvDetails>)ViewState["VouData"];
            }
            set
            {
                ViewState["VouData"] = value;

            }
        }
        public string vRoleName
        {
            get
            {
                if (ViewState["RoleName"] == null)
                {
                    ViewState["RoleName"] = "Roll";
                }
                return ViewState["RoleName"].ToString();
            }
            set { ViewState["RoleName"] = value; }
        }
        public void EditMode()
        {
            txtVouNo.ReadOnly = true;
            txtVouNo.BackColor = System.Drawing.Color.LightGray;

            BtnPrint.Visible = true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass205;
            BtnEdit.Visible = true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass202;
            BtnNew.Visible = false;
            BtnDelete.Visible = true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass203;
        }

        public void NewMode()
        {
            txtVouNo.ReadOnly = false;
            txtVouNo.BackColor = System.Drawing.Color.White;

            BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = true && (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass201;
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
                    this.Page.Header.Title = "أتفاقية شحن - فاتورة";

                    if (Request.QueryString["AreaNo"] != null)
                    {
                        AreaNo = Request.QueryString["AreaNo"].ToString();
                        CostCenter myCost = new CostCenter();
                        myCost.Branch = 1;
                        if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCost.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCost.Code = Request.QueryString["AreaNo"].ToString();
                        myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                  where citm.Code == myCost.Code
                                  select citm).FirstOrDefault();
                        if (myCost != null) SiteInfo = myCost;
                    }
                    else
                    {
                        AreaNo = Session["AreaNo"].ToString();
                        SiteInfo = (CostCenter)Session["SiteInfo"];
                    }
                    if (Request.QueryString["StoreNo"] != null) StoreNo = Request.QueryString["StoreNo"].ToString();
                    else
                    {
                        if (Session["StoreNo"] == null) Session["StoreNo"] = 1;
                        StoreNo = Session["StoreNo"].ToString();
                    }
                    lblBranch.Text = "/" + short.Parse(AreaNo).ToString();                    

                    Acc myacc = new Acc();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastACC" + Session["CNN2"].ToString()] == null) Cache.Insert("LastACC" + Session["CNN2"].ToString(), myacc.GetLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    ddlCustomers.DataSource = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                               where itm.FCode.StartsWith("120301")
                                               orderby itm.Name1
                                               select itm).ToList();
                    ddlCustomers.DataTextField = "Name1";
                    ddlCustomers.DataValueField = "Code";
                    ddlCustomers.DataBind();
                    ddlCustomers.Items.Insert(0, new ListItem("--- أختار حساب العميل ---", "-1", true));

                    CostCenter myCostCenter = new CostCenter();
                    if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCostCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    myCostCenter.Branch = short.Parse(Session["Branch"].ToString());
                    ddlSite.DataTextField = "Name1";
                    ddlSite.DataValueField = "Code";
                    ddlSite.DataSource = (from sitm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                          orderby sitm.Name1
                                          select sitm).ToList();

                    Cities myCity = new Cities();
                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlDestination.DataTextField = "Name1";
                    ddlDestination.DataValueField = "Code";
                    ddlPlaceofLoading.DataTextField = "Name1";
                    ddlPlaceofLoading.DataValueField = "Code";
                    ddlDestination.DataSource = (from itm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                                 orderby itm.Name1
                                                 select itm).ToList();
                    ddlPlaceofLoading.DataSource = ddlDestination.DataSource;

                    ddlSite.DataBind();
                    ddlDestination.DataBind();
                    ddlPlaceofLoading.DataBind();
                    ddlSite.Items.Insert(0, new ListItem("--- أختار الفرع ---", "-1", true));
                    ddlDestination.Items.Insert(0, new ListItem("--- أختار جهة الترحيل ---", "-1", true));
                    ddlPlaceofLoading.Items.Insert(0, new ListItem("--- أختار مكان الشحن ---", "-1", true));

                    ddlPlaceofLoading.SelectedValue = AreaNo;

                    TblUsers ax = new TblUsers();
                    if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    vRoleName = moh.GetCurrentRole(AreaNo,(from useritm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                                          where useritm.UserName == Session["CurrentUser"].ToString()
                                                          select useritm).FirstOrDefault());
                    if (Session[vRoleName] == null)
                    {
                        Response.Redirect("WebNotPrev.aspx", false);
                        return;
                    }
                    BtnNew.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass201;
                    BtnEdit.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass202;
                    BtnDelete.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass203;
                    BtnSearch.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass204;
                    BtnFind.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass204;
                    BtnPrint.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass205;

                    if (Request.QueryString["FNum"] != null)
                    {
                        txtVouNo.Text = Request.QueryString["FNum"].ToString();
                        BtnSearch_Click(sender, null);
                    }
                    else BtnClear_Click(sender, null);
                }
                else
                {
                    ContentPlaceHolder myContent = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
                    for (int i = 1; i < 19; i++)
                    {
                        HtmlImage ImgAccess = myContent.FindControl("ImgAccess" + i.ToString()) as HtmlImage;
                        if (HImgAccess.Value[i-1] == '1' && ImgAccess.Src.Contains("False")) ImgAccess.Src = @"~/images/True.gif";
                        if (HImgAccess.Value[i-1] == '0' && ImgAccess.Src.Contains("True")) ImgAccess.Src = @"~/images/False.gif";
                    }
                    for (int i = 1; i < 38; i++)
                    {
                        HtmlImage ImgS = myContent.FindControl("ImgS" + i.ToString()) as HtmlImage;                       
                        if (HImgS.Value[i - 1] == '1' && ImgS.Src.Contains("False")) ImgS.Src = @"~/images/True.gif";
                        if (HImgS.Value[i - 1] == '0' && ImgS.Src.Contains("True")) ImgS.Src = @"~/images/False.gif";
                    }

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
                ChkReturnInv.Checked = false;
                ChkReturnInv_CheckedChanged(sender, e);
                txtOVouNo.Text = "";
                rdoVouType.SelectedIndex = 0;
                txtGDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                txtHDate.Text = HDate.getNow();
                txtName.Text = "";
                txtIDNo.Text = "";
                rdoIDType.SelectedIndex = 0;
                txtIDFrom.Text = "";
                txtIdDate.Text = "";
                txtAddress.Text = "";
                txtMobileNo.Text = "";
                ddlPlaceofLoading.SelectedIndex = 0;
                ddlDestination.SelectedIndex = 0;
                txtRecName.Text = "";
                txtRecAddress.Text = "";
                txtRecMobileNo.Text = "";
                txtTotal.Text = "";
                txtCashAmount.Text = "";
                ddlSite.SelectedIndex = 0;
                txtSiteAmount.Text = "";
                ddlCustomers.SelectedIndex = 0;
                txtCustomerAmount.Text = "";
                ImgS1.Src = "~/images/True.gif";
                ImgS2.Src = "~/images/True.gif";
                ImgS3.Src = "~/images/True.gif";
                ImgS4.Src = "~/images/True.gif";
                ImgS5.Src = "~/images/True.gif";
                ImgS6.Src = "~/images/True.gif";
                ImgS7.Src = "~/images/True.gif";
                ImgS8.Src = "~/images/True.gif";
                ImgS9.Src = "~/images/True.gif";
                ImgS10.Src = "~/images/True.gif";
                ImgS11.Src = "~/images/True.gif";
                ImgS12.Src = "~/images/True.gif";
                ImgS13.Src = "~/images/True.gif";
                ImgS14.Src = "~/images/True.gif";
                ImgS15.Src = "~/images/True.gif";
                ImgS16.Src = "~/images/True.gif";
                ImgS17.Src = "~/images/True.gif";
                ImgS18.Src = "~/images/True.gif";
                ImgS19.Src = "~/images/True.gif";
                ImgS20.Src = "~/images/True.gif";
                ImgS21.Src = "~/images/True.gif";
                ImgS22.Src = "~/images/True.gif";
                ImgS23.Src = "~/images/True.gif";
                ImgS24.Src = "~/images/True.gif";
                ImgS25.Src = "~/images/True.gif";
                ImgS26.Src = "~/images/True.gif";
                ImgS27.Src = "~/images/True.gif";
                ImgS28.Src = "~/images/True.gif";
                ImgS29.Src = "~/images/True.gif";
                ImgS30.Src = "~/images/True.gif";
                ImgS31.Src = "~/images/True.gif";
                ImgS32.Src = "~/images/True.gif";
                ImgS33.Src = "~/images/True.gif";
                ImgS34.Src = "~/images/True.gif";
                ImgS35.Src = "~/images/True.gif";
                ImgS36.Src = "~/images/True.gif";
                ImgS37.Src = "~/images/True.gif";
                ImgS38.Src = "~/images/True.gif";
                ImgAccess1.Src = "~/images/True.gif";
                ImgAccess2.Src = "~/images/True.gif";
                ImgAccess3.Src = "~/images/True.gif";
                ImgAccess4.Src = "~/images/True.gif";
                ImgAccess5.Src = "~/images/True.gif";
                ImgAccess6.Src = "~/images/True.gif";
                ImgAccess7.Src = "~/images/True.gif";
                ImgAccess8.Src = "~/images/True.gif";
                ImgAccess9.Src = "~/images/True.gif";
                ImgAccess10.Src = "~/images/True.gif";
                ImgAccess11.Src = "~/images/True.gif";
                ImgAccess12.Src = "~/images/True.gif";
                ImgAccess13.Src = "~/images/True.gif";
                ImgAccess14.Src = "~/images/True.gif";
                ImgAccess15.Src = "~/images/True.gif";
                ImgAccess16.Src = "~/images/True.gif";
                ImgAccess17.Src = "~/images/True.gif";
                ImgAccess18.Src = "~/images/True.gif";
                HImgAccess.Value = "111111111111111111";
                HImgS.Value = "11111111111111111111111111111111111111";
                txtAccess1.Text = "";
                txtAccess2.Text = "";
                txtAccess3.Text = "";
                txtAccess4.Text = "";
                txtAccess5.Text = "";
                txtAccess6.Text = "";
                txtAccess7.Text = "";
                txtAccess8.Text = "";
                txtAccess9.Text = "";
                txtAccess10.Text = "";
                txtAccess11.Text = "";
                txtAccess12.Text = "";
                txtAccess13.Text = "";
                txtAccess14.Text = "";
                txtAccess15.Text = "";
                txtAccess16.Text = "";
                txtAccess17.Text = "";
                txtAccess18.Text = "";
                txtRemark1.Text = "";
                txtRemark2.Text = "";
                txtAttached.Text = "";
                ddlQty.SelectedIndex = 0;
                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                Invoice myInv = new Invoice();
                myInv.Branch = short.Parse(Session["Branch"].ToString());
                myInv.VouLoc = AreaNo;                
                int? i = myInv.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (i == 0 || i == null)
                {
                    i = SiteInfo.InvNo;
                }
                else
                {
                    i++;
                }
                LblFTime.Text = String.Format("{0:HH:mm:ss}", moh.Nows());  //moh.Nows().ToShortTimeString();
                txtVouNo.Text = i.ToString();
                LoadAttachData();
                VouData.Clear();
                VouData.Add(new InvDetails { FNo = 1 });
                DispVouData();
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
                    if (!ValidateInv()) return;
                    Invoice myInv = new Invoice();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.VouNo = int.Parse(txtVouNo.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myInv != null)
                    {
                        myInv = new Invoice();
                        myInv.Branch = short.Parse(Session["Branch"].ToString());
                        myInv.VouLoc = AreaNo;
                        int? i = myInv.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
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

                    myInv = new Invoice();                        
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.VouNo = int.Parse(txtVouNo.Text);
                    PutInv(myInv);
                    string SiteCode = "-1";
                    if(ddlSite.SelectedIndex>0)
                    {
                        CostCenter myCenter = new CostCenter();
                        myCenter.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCenter.Code = ddlSite.SelectedValue;
                        myCenter = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                    where citm.Code == myCenter.Code
                                    select citm).FirstOrDefault();
                        if(myCenter != null ) SiteCode = myCenter.SiteAcc;
                    }
                    if (myInv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, SiteInfo.InComeAcc, SiteInfo.CashAcc,moh.MadaAcc, SiteInfo.SiteAcc, SiteInfo.Area, SiteInfo.Project, SiteCode,"310102027"))
                    {
                        SaveGridInfo();
                        foreach(InvDetails inv in VouData)
                        {
                            inv.Branch = short.Parse(Session["Branch"].ToString());
                            inv.VouLoc = AreaNo;
                            inv.VouNo = int.Parse(txtVouNo.Text);
                            inv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }

                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                        BtnClear_Click(sender, e);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء أضافة البيانات ... حاول مرة أخرى";
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

        public bool ValidateInv()
        {
            if (txtName.Text == "")
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يجب أدخال أسم المرسل";
                txtName.Focus();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }

            if (ddlPlaceofLoading.SelectedIndex ==0)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يجب أختيار مكان الشحن";
                ddlPlaceofLoading.Focus();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }

            if (ddlDestination.SelectedIndex == 0)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يجب أختيار جهة الترحيل";
                ddlDestination.Focus();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }


            if (txtCashAmount.Text == "") txtCashAmount.Text = "0";
            if (txtSiteAmount.Text == "") txtSiteAmount.Text = "0";
            if (txtCustomerAmount.Text == "") txtCustomerAmount.Text = "0";

            MakeSum();
            
            if (moh.StrToDouble(txtTotal.Text) > moh.StrToDouble(txtCashAmount.Text) + moh.StrToDouble(txtSiteAmount.Text) + moh.StrToDouble(txtCustomerAmount.Text))
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "السعر لا يغطي أجمالي الفاتورة";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }

            if (moh.StrToDouble(txtTotal.Text) != moh.StrToDouble(txtCashAmount.Text) + moh.StrToDouble(txtSiteAmount.Text) + moh.StrToDouble(txtCustomerAmount.Text))
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "المدفوع لا يتساوى مع مبلغ الفاتورة";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }

            foreach (GridViewRow gvr in grdCodes.Rows)
            {
                DropDownList ddlCarType = gvr.FindControl("ddlCarType") as DropDownList;
                TextBox txtPlateNo = gvr.FindControl("txtPlateNo") as TextBox;
                TextBox txtChassisNo = gvr.FindControl("txtChassisNo") as TextBox;

                if (ddlCarType != null && txtPlateNo != null && txtChassisNo != null)
                {
                    if (ddlCarType.SelectedIndex == 0)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أختيار نوع السيارة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return false;                        
                    }

                    if (txtPlateNo.Text == "" && txtChassisNo.Text == "")
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أدخال رقم اللوحة أو الهيكل للسيارة";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return false;
                    }
                }
            }

            if (moh.StrToDouble(txtCustomerAmount.Text) != 0 && ddlCustomers.SelectedIndex == 0)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يجب أختيار العميل";
                ddlCustomers.Focus();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }

            if (moh.StrToDouble(txtSiteAmount.Text) != 0 && ddlSite.SelectedIndex == 0)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "يجب أختيار الفرع";
                ddlSite.Focus();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                return false;
            }

            return true;
        }
      
        public void PutInv(Invoice myInv)
        {
            myInv.VouType = short.Parse(rdoVouType.SelectedValue);
            myInv.HDate = txtHDate.Text;
            myInv.GDate = txtGDate.Text;
            myInv.Name = txtName.Text;
            myInv.IDNo = txtIDNo.Text;
            myInv.IDType = short.Parse(rdoIDType.SelectedValue);
            myInv.IDFrom = txtIDFrom.Text;
            myInv.IDDate = txtIdDate.Text;
            myInv.Address = txtAddress.Text;
            myInv.MobileNo = txtMobileNo.Text;
            myInv.PlaceofLoading = ddlPlaceofLoading.SelectedValue;
            myInv.Destination = ddlDestination.SelectedValue;
            myInv.RecName = txtRecName.Text;
            myInv.RecAddress = txtRecAddress.Text;
            myInv.RecMobileNo = txtRecMobileNo.Text;
            myInv.FTime = LblFTime.Text;
            myInv.ReturnInv = ChkReturnInv.Checked;
            myInv.OVouNo = txtOVouNo.Text;

            SaveGridInfo();

            myInv.CashAmount = moh.StrToDouble(txtCashAmount.Text);
            myInv.RecVouNo = 0;  // int.Parse(txtRecVouNo.Text);
            myInv.RecVouDate = ""; // txtRecVouDate.Text;
            myInv.Site = ddlSite.SelectedValue;
            myInv.SiteAmount = moh.StrToDouble(txtSiteAmount.Text);
            myInv.Customer = ddlCustomers.SelectedValue;
            myInv.CustomerAmount = moh.StrToDouble(txtCustomerAmount.Text);
            myInv.S1 = ImgS1.Src.Contains("False");
            myInv.S2 = ImgS2.Src.Contains("False");
            myInv.S3 = ImgS3.Src.Contains("False");
            myInv.S4 = ImgS4.Src.Contains("False");
            myInv.S5 = ImgS5.Src.Contains("False");
            myInv.S6 = ImgS6.Src.Contains("False");
            myInv.S7 = ImgS7.Src.Contains("False");
            myInv.S8 = ImgS8.Src.Contains("False");
            myInv.S9 = ImgS9.Src.Contains("False");
            myInv.S10 = ImgS10.Src.Contains("False");
            myInv.S11 = ImgS11.Src.Contains("False");
            myInv.S12 = ImgS12.Src.Contains("False");
            myInv.S13 = ImgS13.Src.Contains("False");
            myInv.S14 = ImgS14.Src.Contains("False");
            myInv.S15 = ImgS15.Src.Contains("False");
            myInv.S16 = ImgS16.Src.Contains("False");
            myInv.S17 = ImgS17.Src.Contains("False");
            myInv.S18 = ImgS18.Src.Contains("False");
            myInv.S19 = ImgS19.Src.Contains("False");
            myInv.S20 = ImgS20.Src.Contains("False");
            myInv.S21 = ImgS21.Src.Contains("False");
            myInv.S22 = ImgS22.Src.Contains("False");
            myInv.S23 = ImgS23.Src.Contains("False");
            myInv.S24 = ImgS24.Src.Contains("False");
            myInv.S25 = ImgS25.Src.Contains("False");
            myInv.S26 = ImgS26.Src.Contains("False");
            myInv.S27 = ImgS27.Src.Contains("False");
            myInv.S28 = ImgS28.Src.Contains("False");
            myInv.S29 = ImgS29.Src.Contains("False");
            myInv.S30 = ImgS30.Src.Contains("False");
            myInv.S31 = ImgS31.Src.Contains("False");
            myInv.S32 = ImgS32.Src.Contains("False");
            myInv.S33 = ImgS33.Src.Contains("False");
            myInv.S34 = ImgS34.Src.Contains("False");
            myInv.S35 = ImgS35.Src.Contains("False");
            myInv.S36 = ImgS36.Src.Contains("False");
            myInv.S37 = ImgS37.Src.Contains("False");
            myInv.S38 = ImgS38.Src.Contains("False");
            myInv.Access1 = ImgAccess1.Src.Contains("False");
            myInv.Access2 = ImgAccess2.Src.Contains("False");
            myInv.Access3 = ImgAccess3.Src.Contains("False");
            myInv.Access4 = ImgAccess4.Src.Contains("False");
            myInv.Access5 = ImgAccess5.Src.Contains("False");
            myInv.Access6 = ImgAccess6.Src.Contains("False");
            myInv.Access7 = ImgAccess7.Src.Contains("False");
            myInv.Access8 = ImgAccess8.Src.Contains("False");
            myInv.Access9 = ImgAccess9.Src.Contains("False");
            myInv.Access10 = ImgAccess10.Src.Contains("False");
            myInv.Access11 = ImgAccess11.Src.Contains("False");
            myInv.Access12 = ImgAccess12.Src.Contains("False");
            myInv.Access13 = ImgAccess13.Src.Contains("False");
            myInv.Access14 = ImgAccess14.Src.Contains("False");
            myInv.Access15 = ImgAccess15.Src.Contains("False");
            myInv.Access16 = ImgAccess16.Src.Contains("False");
            myInv.Access17 = ImgAccess17.Src.Contains("False");
            myInv.Access18 = ImgAccess18.Src.Contains("False");
            myInv.sAccess1 = txtAccess1.Text;
            myInv.sAccess2 = txtAccess2.Text;
            myInv.sAccess3 = txtAccess3.Text;
            myInv.sAccess4 = txtAccess4.Text;
            myInv.sAccess5 = txtAccess5.Text;
            myInv.sAccess6 = txtAccess6.Text;
            myInv.sAccess7 = txtAccess7.Text;
            myInv.sAccess8 = txtAccess8.Text;
            myInv.sAccess9 = txtAccess9.Text;
            myInv.sAccess10 = txtAccess10.Text;
            myInv.sAccess11 = txtAccess11.Text;
            myInv.sAccess12 = txtAccess12.Text;
            myInv.sAccess13 = txtAccess13.Text;
            myInv.sAccess14 = txtAccess14.Text;
            myInv.sAccess15 = txtAccess15.Text;
            myInv.sAccess16 = txtAccess16.Text;
            myInv.sAccess17 = txtAccess17.Text;
            myInv.sAccess18 = txtAccess18.Text;
            myInv.Remark1 = txtRemark1.Text;
            myInv.Remark2 = txtRemark2.Text;
            myInv.Attached = txtAttached.Text;
            myInv.UserName = txtUserName.ToolTip;
            myInv.UserDate = txtUserDate.Text;
            myInv.Qty = short.Parse(ddlQty.SelectedValue);                 
        }

        public void GetInv(Invoice myInv, Boolean ReturnFlag)
        {
            if(!ReturnFlag) rdoVouType.SelectedValue = myInv.VouType.ToString();            
            txtHDate.Text = myInv.HDate;
            txtGDate.Text = myInv.GDate;
            LblFTime.Text = myInv.FTime;

            if (ReturnFlag)
            {
                txtName.Text = myInv.RecName;
                txtAddress.Text = myInv.RecAddress;
                txtMobileNo.Text = myInv.RecMobileNo;

                txtRecName.Text = myInv.Name;
                txtRecAddress.Text = myInv.Address;
                txtRecMobileNo.Text = myInv.MobileNo;

                ddlPlaceofLoading.SelectedValue = myInv.Destination;
                ddlDestination.SelectedValue = myInv.PlaceofLoading;

                txtCashAmount.Text = "0";
                //txtRecVouNo.Text = myInv.RecVouNo.ToString();
                //txtRecVouDate.Text = myInv.RecVouDate;
                ddlSite.SelectedValue = "-1";
                txtSiteAmount.Text = "0";
                ddlCustomers.SelectedValue = "-1";
                txtCustomerAmount.Text = "0";
            }
            else
            {
                ChkReturnInv.Checked = (bool)myInv.ReturnInv;
                txtOVouNo.Text = myInv.OVouNo;

                txtRecName.Text = myInv.RecName;
                txtRecAddress.Text = myInv.RecAddress;
                txtRecMobileNo.Text = myInv.RecMobileNo;

                txtName.Text = myInv.Name;
                txtAddress.Text = myInv.Address;
                txtMobileNo.Text = myInv.MobileNo;

                ddlPlaceofLoading.SelectedValue = myInv.PlaceofLoading;
                ddlDestination.SelectedValue = myInv.Destination;

                txtCashAmount.Text = myInv.CashAmount.ToString();   // string.Format("{0:N2}", myInv.CashAmount);
                //txtRecVouNo.Text = myInv.RecVouNo.ToString();
                //txtRecVouDate.Text = myInv.RecVouDate;
                ddlSite.SelectedValue = myInv.Site;
                txtSiteAmount.Text = myInv.SiteAmount.ToString();   // string.Format("{0:N2}", myInv.SiteAmount);
                ddlCustomers.SelectedValue = myInv.Customer;
                txtCustomerAmount.Text = myInv.CustomerAmount.ToString();   // string.Format("{0:N2}", myInv.CustomerAmount);
            }
            txtIDNo.Text = myInv.IDNo;
            rdoIDType.SelectedValue = myInv.IDType.ToString();
            txtIDFrom.Text = myInv.IDFrom;
            txtIdDate.Text = myInv.IDDate;

            ImgS1.Src = (bool)myInv.S1 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS2.Src = (bool)myInv.S2 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS3.Src = (bool)myInv.S3 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS4.Src = (bool)myInv.S4 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS5.Src = (bool)myInv.S5 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS6.Src = (bool)myInv.S6 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS7.Src = (bool)myInv.S7 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS8.Src = (bool)myInv.S8 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS9.Src = (bool)myInv.S9 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS10.Src = (bool)myInv.S10 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS11.Src = (bool)myInv.S11 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS12.Src = (bool)myInv.S12 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS13.Src = (bool)myInv.S13 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS14.Src = (bool)myInv.S14 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS15.Src = (bool)myInv.S15 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS16.Src = (bool)myInv.S16 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS17.Src = (bool)myInv.S17 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS18.Src = (bool)myInv.S18 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS19.Src = (bool)myInv.S19 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS20.Src = (bool)myInv.S20 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS21.Src = (bool)myInv.S21 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS22.Src = (bool)myInv.S22 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS23.Src = (bool)myInv.S23 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS24.Src = (bool)myInv.S24 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS25.Src = (bool)myInv.S25 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS26.Src = (bool)myInv.S26 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS27.Src = (bool)myInv.S27 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS28.Src = (bool)myInv.S28 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS29.Src = (bool)myInv.S29 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS30.Src = (bool)myInv.S30 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS31.Src = (bool)myInv.S31 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS32.Src = (bool)myInv.S32 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS33.Src = (bool)myInv.S33 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS34.Src = (bool)myInv.S34 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS35.Src = (bool)myInv.S35 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS36.Src = (bool)myInv.S36 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS37.Src = (bool)myInv.S37 ? "~/images/False.gif" : "~/images/True.gif";
            ImgS38.Src = (bool)myInv.S38 ? "~/images/False.gif" : "~/images/True.gif";
            ImgAccess1.Src = (bool)myInv.Access1 ? "~/images/False.gif" : "~/images/True.gif";
            ImgAccess2.Src = (bool)myInv.Access2 ? "~/images/False.gif" : "~/images/True.gif";
            ImgAccess3.Src = (bool)myInv.Access3 ? "~/images/False.gif" : "~/images/True.gif";
            ImgAccess4.Src = (bool)myInv.Access4 ? "~/images/False.gif" : "~/images/True.gif";
            ImgAccess5.Src = (bool)myInv.Access5 ? "~/images/False.gif" : "~/images/True.gif";
            ImgAccess6.Src = (bool)myInv.Access6 ? "~/images/False.gif" : "~/images/True.gif";
            ImgAccess7.Src = (bool)myInv.Access7 ? "~/images/False.gif" : "~/images/True.gif";
            ImgAccess8.Src = (bool)myInv.Access8 ? "~/images/False.gif" : "~/images/True.gif";
            ImgAccess9.Src = (bool)myInv.Access9 ? "~/images/False.gif" : "~/images/True.gif";
            ImgAccess10.Src = (bool)myInv.Access10 ? "~/images/False.gif" : "~/images/True.gif";
            ImgAccess11.Src = (bool)myInv.Access11 ? "~/images/False.gif" : "~/images/True.gif";
            ImgAccess12.Src = (bool)myInv.Access12 ? "~/images/False.gif" : "~/images/True.gif";
            ImgAccess13.Src = (bool)myInv.Access13 ? "~/images/False.gif" : "~/images/True.gif";
            ImgAccess14.Src = (bool)myInv.Access14 ? "~/images/False.gif" : "~/images/True.gif";
            ImgAccess15.Src = (bool)myInv.Access15 ? "~/images/False.gif" : "~/images/True.gif";
            ImgAccess16.Src = (bool)myInv.Access16 ? "~/images/False.gif" : "~/images/True.gif";
            ImgAccess17.Src = (bool)myInv.Access17 ? "~/images/False.gif" : "~/images/True.gif";
            ImgAccess18.Src = (bool)myInv.Access18 ? "~/images/False.gif" : "~/images/True.gif";
            txtAccess1.Text = myInv.sAccess1;
            txtAccess2.Text = myInv.sAccess2;
            txtAccess3.Text = myInv.sAccess3;
            txtAccess4.Text = myInv.sAccess4;
            txtAccess5.Text = myInv.sAccess5;
            txtAccess6.Text = myInv.sAccess6;
            txtAccess7.Text = myInv.sAccess7;
            txtAccess8.Text = myInv.sAccess8;
            txtAccess9.Text = myInv.sAccess9;
            txtAccess10.Text = myInv.sAccess10;
            txtAccess11.Text = myInv.sAccess11;
            txtAccess12.Text = myInv.sAccess12;
            txtAccess13.Text = myInv.sAccess13;
            txtAccess14.Text = myInv.sAccess14;
            txtAccess15.Text = myInv.sAccess15;
            txtAccess16.Text = myInv.sAccess16;
            txtAccess17.Text = myInv.sAccess17;
            txtAccess18.Text = myInv.sAccess18;
            txtRemark1.Text = myInv.Remark1;
            txtRemark2.Text = myInv.Remark2;
            txtAttached.Text = myInv.Attached;
            ddlQty.SelectedValue = myInv.Qty.ToString();
            if (!ReturnFlag)
            {
                txtUserName.ToolTip = myInv.UserName;
                TblUsers ax = new TblUsers();
                if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                ax.UserName = myInv.UserName;
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
                txtUserDate.Text = myInv.UserDate;
            }
            string vStr = "";
            string vStr2 = "";
            ContentPlaceHolder myContent = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
            for (int i = 1; i < 19; i++)
            {
                HtmlImage ImgAccess = myContent.FindControl("ImgAccess" + i.ToString()) as HtmlImage;
                vStr += (ImgAccess.Src.Contains("True") ? "1" : "0");
            }
            for (int i = 1; i < 38; i++)
            {
                HtmlImage ImgS = myContent.FindControl("ImgS" + i.ToString()) as HtmlImage;
                vStr2 += (ImgS.Src.Contains("True") ? "1" : "0");
            }
            HImgAccess.Value = vStr;
            HImgS.Value = vStr2;
            if (!ReturnFlag) LoadAttachData();
        }

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (!ValidateInv()) return;
                    Invoice myInv = new Invoice();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = AreaNo;
                    myInv.VouNo = int.Parse(txtVouNo.Text);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myInv == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم الفاتورة غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                    }
                    else
                    {
                        PutInv(myInv);
                        string SiteCode = "-1";
                        if (ddlSite.SelectedIndex > 0)
                        {
                            CostCenter myCenter = new CostCenter();
                            myCenter.Branch = short.Parse(Session["Branch"].ToString());
                            if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCenter.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                            myCenter.Code = ddlSite.SelectedValue;
                            myCenter = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                        where citm.Code == myCenter.Code
                                        select citm).FirstOrDefault();
                            if (myCenter != null) SiteCode = myCenter.SiteAcc;
                        }
                        if (myInv.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, SiteInfo.InComeAcc, SiteInfo.CashAcc,moh.MadaAcc, SiteInfo.SiteAcc, SiteInfo.Area, SiteInfo.Project, SiteCode, "310102027"))
                        {
                            InvDetails sinv = new InvDetails();
                            sinv.Branch = short.Parse(Session["Branch"].ToString());
                            sinv.VouLoc = AreaNo;
                            sinv.VouNo = int.Parse(txtVouNo.Text);
                            sinv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            SaveGridInfo();
                            foreach (InvDetails inv in VouData)
                            {
                                inv.Branch = short.Parse(Session["Branch"].ToString());
                                inv.VouLoc = AreaNo;
                                inv.VouNo = int.Parse(txtVouNo.Text);
                                inv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            }

                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ أثناء تعديل البيانات ... حاول مرة أخرى";
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
                     Invoice myInv = new Invoice();
                     myInv.Branch = short.Parse(Session["Branch"].ToString());
                     myInv.VouLoc = AreaNo;
                     myInv.VouNo = int.Parse(txtVouNo.Text);
                     myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                     if (myInv == null)
                     {
                         LblCodesResult.ForeColor = System.Drawing.Color.Red;
                         LblCodesResult.Text = "رقم الفاتورة غير معرف من قبل";
                         ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                     }
                     else
                     {
                         if (myInv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                         {
                             InvDetails sinv = new InvDetails();
                             sinv.Branch = short.Parse(Session["Branch"].ToString());
                             sinv.VouLoc = AreaNo;
                             sinv.VouNo = int.Parse(txtVouNo.Text);
                             sinv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                             Transactions UserTran = new Transactions();
                             UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                             UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                             UserTran.UserName = Session["CurrentUser"].ToString();
                             UserTran.Description = "الغاء بيانات فاتورة الشحن رقم " + txtVouNo.Text;
                             UserTran.FormAction = "الغاء";
                             UserTran.FormName = "اتفاقية الشحن";
                             UserTran.IP = IPNetworking.GetIP4Address();
                             UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);


                             LblCodesResult.ForeColor = System.Drawing.Color.Green;
                             LblCodesResult.Text = "لقد تم الغاء البيانات بنجاح";
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
                     Invoice myInv = new Invoice();
                     myInv.Branch = short.Parse(Session["Branch"].ToString());
                     myInv.VouLoc = AreaNo;
                     myInv.VouNo = int.Parse(txtVouNo.Text);
                     myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                     if (myInv == null)
                     {
                         LblCodesResult.ForeColor = System.Drawing.Color.Red;
                         LblCodesResult.Text = "رقم الفاتورة غير معرف من قبل";
                         ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                     }
                     else
                     {
                         EditMode();
                         GetInv(myInv,false);
                         InvDetails sinv = new InvDetails();
                         sinv.Branch = short.Parse(Session["Branch"].ToString());
                         sinv.VouLoc = AreaNo;
                         sinv.VouNo = int.Parse(txtVouNo.Text);
                         VouData.Clear();
                         VouData = sinv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                         DispVouData();                         
                     }
                 }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم الفاتورة";
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

        protected void BtnPrint_Click(object sender, ImageClickEventArgs e)
        {
             try
             {
                 if (Page.IsValid)
                 {
                     if (!ValidateInv()) return;
                     iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, -50, -50, 80, 40);
                     HttpContext.Current.Response.ContentType = "application/pdf";
                     PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
                     pdfPage page = new pdfPage();
                     MyConfig mySetting = new MyConfig();
                     mySetting.Branch = short.Parse(Session["Branch"].ToString());
                     if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                     mySetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                     if (mySetting != null)
                     {
                         page.vCompanyName = mySetting.CompanyName;
                     }

                     writer.PageEvent = page;
                     page.PageNo = "1";
                     page.UserName = Session["FullUser"].ToString();
                     page.vStr4 = ((Label)this.Master.FindControl("LblBranchName")).Text;    //Session["AreaName"].ToString();
                     page.vStr2 = lblBranch.Text;
                     page.vStr3 = txtVouNo.Text;
                     page.vStr5 = AreaNo;
                     page.vStr6 = txtGDate.Text;

                     string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                     BaseFont nationalBase;
                     nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                     iTextSharp.text.Font nationalTextFont8 = new iTextSharp.text.Font(nationalBase, 8f, iTextSharp.text.Font.NORMAL);                     iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 11f, iTextSharp.text.Font.NORMAL);
                     iTextSharp.text.Font nationalTextFont2 = new iTextSharp.text.Font(nationalBase, 10f, iTextSharp.text.Font.NORMAL);
                     iTextSharp.text.Font nationalTextFont12 = new iTextSharp.text.Font(nationalBase, 12f, iTextSharp.text.Font.NORMAL);
                     iTextSharp.text.Font nationalTextFont14 = new iTextSharp.text.Font(nationalBase, 14f, iTextSharp.text.Font.NORMAL);
                     iTextSharp.text.Font nationalTextFont16 = new iTextSharp.text.Font(nationalBase, 16f, iTextSharp.text.Font.NORMAL);
                     //-------------------------------------------------------------------------------------------
                     document.Open();
                     //-------------------------------------------------------------------------------------------

                     int ColCount = 3;
                     var cols = new[] { 80, 550, 70 };
                     PdfPTable table = new PdfPTable(ColCount);
                     table.TotalWidth = document.PageSize.Width; //100f;
                     table.SetWidths(cols);
                     PdfPCell cell = new PdfPCell();
                     cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                     //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                     table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     //-------------------------------------------------------------------------------------------
                     cell.BackgroundColor = new iTextSharp.text.BaseColor(242, 242, 242);  // iTextSharp.text.BaseColor.LIGHT_GRAY;
                     cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     //cell.Border = 0;
                     cell.Phrase = new iTextSharp.text.Phrase("التاريخ", nationalTextFont);
                     table.AddCell(cell);

                     PdfPTable TblInside = new PdfPTable(3);
                     var colsInside = new[] { 100, 340, 100 };
                     TblInside.SetWidths(colsInside);
                     TblInside.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                     TblInside.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     PdfPCell cellInside = new PdfPCell(TblInside);
                     cellInside.ArabicOptions = ColumnText.DIGITS_EN2AN;
                     //cell330.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cellInside.PaddingRight = 0;

                     PdfPCell cell0 = new PdfPCell();
                     //cell320.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell0.ArabicOptions = ColumnText.DIGITS_EN2AN;
                     cell0.Border = 0;

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase(HDate.RotateDate2(txtHDate.Text) + " هـ ", nationalTextFont);
                     cell0.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                     TblInside.AddCell(cell0);

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     if (rdoVouType.SelectedIndex == 0)
                     {
                         cell0.Phrase = new iTextSharp.text.Phrase("ذهاب", nationalTextFont12);
                         TblInside.AddCell(cell0);
                     }
                     else
                     {
                         cell0.Phrase = new iTextSharp.text.Phrase("ذهاب و عوده", nationalTextFont12);
                         TblInside.AddCell(cell0);
                     }

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell0.Phrase = new iTextSharp.text.Phrase(txtGDate.Text + " م ", nationalTextFont);
                     TblInside.AddCell(cell0);

                     table.AddCell(cellInside);

                     cell.BackgroundColor = new iTextSharp.text.BaseColor(242, 242, 242);  // iTextSharp.text.BaseColor.LIGHT_GRAY;
                     cell.Phrase = new iTextSharp.text.Phrase("Date", nationalTextFont2);
                     table.AddCell(cell);

                     //-------------------------------------------------------------------------------------------
                     cell.BackgroundColor = new iTextSharp.text.BaseColor(242, 242, 242);     // iTextSharp.text.BaseColor.LIGHT_GRAY;
                     cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     //cell.Border = 0;
                     cell.Phrase = new iTextSharp.text.Phrase("\r\n\r\n\r\n"+"بيانات المرسل و المرسل إليه", nationalTextFont);
                     table.AddCell(cell);

                     TblInside = new PdfPTable(3);
                     colsInside = new[] { 140, 300, 100 };
                     TblInside.SetWidths(colsInside);
                     TblInside.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                     TblInside.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                     cellInside = new PdfPCell(TblInside);
                     cellInside.ArabicOptions = ColumnText.DIGITS_EN2AN;
                     //cell330.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cellInside.PaddingRight = 0;

                     cell0 = new PdfPCell();
                     //cell320.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell0.ArabicOptions = ColumnText.DIGITS_EN2AN;
                     cell0.Border = 0;

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("الاســم:", nationalTextFont);                     
                     cell0.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                     TblInside.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase(txtName.Text, nationalTextFont);
                     TblInside.AddCell(cell0);
                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;                     
                     cell0.Phrase = new iTextSharp.text.Phrase("Consigner Name", nationalTextFont2);                     
                     TblInside.AddCell(cell0);

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("رقم الهوية:", nationalTextFont);
                     TblInside.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase(txtIDNo.Text + " " + rdoIDType.SelectedItem.Text, nationalTextFont);
                     TblInside.AddCell(cell0);
                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell0.Phrase = new iTextSharp.text.Phrase("I.D.No./Iqama", nationalTextFont2);
                     TblInside.AddCell(cell0);

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("مصدرها/تاريخها:", nationalTextFont);
                     TblInside.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase(txtIDFrom.Text+"    " +txtIdDate.Text, nationalTextFont);
                     TblInside.AddCell(cell0);
                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell0.Phrase = new iTextSharp.text.Phrase("Place of Issue/Date", nationalTextFont2);
                     TblInside.AddCell(cell0);

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("العنوان:", nationalTextFont);
                     TblInside.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase(txtAddress.Text + (txtMobileNo.Text != "" ? " جوال رقم " + txtMobileNo.Text : ""), nationalTextFont);
                     TblInside.AddCell(cell0);
                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;                     
                     cell0.Phrase = new iTextSharp.text.Phrase("Address", nationalTextFont2);                     
                     TblInside.AddCell(cell0);

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("مكان الشحن:", nationalTextFont);
                     TblInside.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase(ddlPlaceofLoading.SelectedItem.Text, nationalTextFont);
                     TblInside.AddCell(cell0);
                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;                     
                     cell0.Phrase = new iTextSharp.text.Phrase("Place of Loading", nationalTextFont2);
                     TblInside.AddCell(cell0);

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("جهه الترحيل:", nationalTextFont);
                     TblInside.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase(ddlDestination.SelectedItem.Text, nationalTextFont);
                     TblInside.AddCell(cell0);
                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;                     
                     cell0.Phrase = new iTextSharp.text.Phrase("Destination", nationalTextFont2);
                     TblInside.AddCell(cell0);

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("أسم المستلم:", nationalTextFont);
                     TblInside.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase(txtRecName.Text, nationalTextFont);
                     TblInside.AddCell(cell0);
                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;                     
                     cell0.Phrase = new iTextSharp.text.Phrase("Consignee Name", nationalTextFont2);
                     TblInside.AddCell(cell0);

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("عنوان المستلم:", nationalTextFont);
                     TblInside.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase(txtRecAddress.Text + (txtRecMobileNo.Text != "" ? " جوال رقم " + txtRecMobileNo.Text : ""), nationalTextFont);
                     TblInside.AddCell(cell0);
                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;                                                                  
                     cell0.Phrase = new iTextSharp.text.Phrase("Consignee Address", nationalTextFont2);                     
                     TblInside.AddCell(cell0);

                     table.AddCell(cellInside);


                     cell.BackgroundColor = new iTextSharp.text.BaseColor(242, 242, 242);  // iTextSharp.text.BaseColor.LIGHT_GRAY;
                     cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell.Phrase = new iTextSharp.text.Phrase("\r\n\r\n\r\n" + "Consigner and Consignee Information", nationalTextFont2);                     
                     table.AddCell(cell);

                     //-------------------------------------------------------------------------------------------

                     cell.BackgroundColor = new iTextSharp.text.BaseColor(242, 242, 242);  // iTextSharp.text.BaseColor.LIGHT_GRAY;
                     cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     //cell.Border = 0;
                     cell.Phrase = new iTextSharp.text.Phrase("\r\n\r\n"+"بيانات السيارة المرسلة", nationalTextFont);
                     table.AddCell(cell);

                     TblInside = new PdfPTable(7);
                     colsInside = new[] { 60,60,100,70,80,100,80};
                     TblInside.SetWidths(colsInside);
                     TblInside.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                     TblInside.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cellInside = new PdfPCell(TblInside);
                     cellInside.ArabicOptions = ColumnText.DIGITS_EN2AN;
                     cellInside.PaddingRight = 0;

                     cell0 = new PdfPCell();
                     cell0.ArabicOptions = ColumnText.DIGITS_EN2AN;
                     cell0.FixedHeight = 15f;
                     //cell0.Border = 0;
                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell0.Phrase = new iTextSharp.text.Phrase("نوع السيارة", nationalTextFont);
                     cell0.BackgroundColor = new iTextSharp.text.BaseColor(242, 242, 242);  // iTextSharp.text.BaseColor.LIGHT_GRAY;
                     TblInside.AddCell(cell0);

                     cell0.Phrase = new iTextSharp.text.Phrase("الطراز", nationalTextFont);
                     TblInside.AddCell(cell0);

                     cell0.Phrase = new iTextSharp.text.Phrase("الموديل", nationalTextFont);
                     TblInside.AddCell(cell0);

                     cell0.Phrase = new iTextSharp.text.Phrase("رقم اللوحة", nationalTextFont);
                     TblInside.AddCell(cell0);

                     cell0.Phrase = new iTextSharp.text.Phrase("رقم الهيكل", nationalTextFont);
                     TblInside.AddCell(cell0);

                     cell0.Phrase = new iTextSharp.text.Phrase("اللون", nationalTextFont);
                     TblInside.AddCell(cell0);

                     cell0.Phrase = new iTextSharp.text.Phrase("السعر", nationalTextFont);
                     TblInside.AddCell(cell0);

                     cell0.Phrase = new iTextSharp.text.Phrase("Brand Name", nationalTextFont2);
                     TblInside.AddCell(cell0);

                     cell0.Phrase = new iTextSharp.text.Phrase("Type", nationalTextFont2);
                     TblInside.AddCell(cell0);

                     cell0.Phrase = new iTextSharp.text.Phrase("Model", nationalTextFont2);
                     TblInside.AddCell(cell0);

                     cell0.Phrase = new iTextSharp.text.Phrase("Plate No.", nationalTextFont2);
                     TblInside.AddCell(cell0);

                     cell0.Phrase = new iTextSharp.text.Phrase("Chassis No.", nationalTextFont2);
                     TblInside.AddCell(cell0);

                     cell0.Phrase = new iTextSharp.text.Phrase("Color", nationalTextFont2);
                     TblInside.AddCell(cell0);

                     cell0.Phrase = new iTextSharp.text.Phrase("Price", nationalTextFont2);
                     TblInside.AddCell(cell0);

                     cell0.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                     foreach (GridViewRow itm in grdCodes.Rows)
                     {
                         DropDownList ddlCarType = itm.FindControl("ddlCarType") as DropDownList;
                         DropDownList ddlModel = itm.FindControl("ddlModel") as DropDownList;
                         TextBox txtBrand = itm.FindControl("txtBrand") as TextBox;
                         TextBox txtPlateNo = itm.FindControl("txtPlateNo") as TextBox;
                         TextBox txtChassisNo = itm.FindControl("txtChassisNo") as TextBox;
                         TextBox txtColor = itm.FindControl("txtColor") as TextBox;
                         TextBox txtPrice = itm.FindControl("txtPrice") as TextBox;
                         if (ddlCarType != null && ddlModel != null && txtBrand != null && txtPlateNo != null && txtChassisNo != null && txtColor != null && txtPrice != null)
                         {
                            cell0.Phrase = new iTextSharp.text.Phrase(ddlCarType.SelectedItem.Text, nationalTextFont2);
                            TblInside.AddCell(cell0);

                            cell0.Phrase = new iTextSharp.text.Phrase(ddlModel.SelectedItem.Text, nationalTextFont2);
                            TblInside.AddCell(cell0);

                            cell0.Phrase = new iTextSharp.text.Phrase(txtBrand.Text, nationalTextFont2);
                            TblInside.AddCell(cell0);

                            cell0.Phrase = new iTextSharp.text.Phrase(txtPlateNo.Text, nationalTextFont2);
                            TblInside.AddCell(cell0);

                            cell0.Phrase = new iTextSharp.text.Phrase(txtChassisNo.Text, nationalTextFont2);
                            TblInside.AddCell(cell0);

                            cell0.Phrase = new iTextSharp.text.Phrase(txtColor.Text, nationalTextFont2);
                            TblInside.AddCell(cell0);

                            if(txtPrice.Text == "") txtPrice.Text = "0";
                            cell0.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", moh.StrToDouble(txtPrice.Text)), nationalTextFont2);
                            TblInside.AddCell(cell0);                           
                         }
                     }

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell0.Phrase = new iTextSharp.text.Phrase("عدد السيارات", nationalTextFont);
                     cell0.BackgroundColor = new iTextSharp.text.BaseColor(242, 242, 242);  // iTextSharp.text.BaseColor.LIGHT_GRAY;
                     TblInside.AddCell(cell0);

                     cell0.Phrase = new iTextSharp.text.Phrase(ddlQty.SelectedItem.Text, nationalTextFont);
                     TblInside.AddCell(cell0);

                     cell0.Phrase = new iTextSharp.text.Phrase("Total of Cars", nationalTextFont2);
                     TblInside.AddCell(cell0);

                     cell0.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                     TblInside.AddCell(cell0);

                     cell0.Phrase = new iTextSharp.text.Phrase("الإجمالي", nationalTextFont);
                     TblInside.AddCell(cell0);

                     cell0.Phrase = new iTextSharp.text.Phrase("Total", nationalTextFont2);
                     TblInside.AddCell(cell0);

                     if (txtTotal.Text == "") txtTotal.Text = "0";
                     cell0.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", moh.StrToDouble(txtTotal.Text)), nationalTextFont);
                     TblInside.AddCell(cell0);

                     table.AddCell(cellInside);

                     cell.BackgroundColor = new iTextSharp.text.BaseColor(242, 242, 242);  // iTextSharp.text.BaseColor.LIGHT_GRAY;
                     cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell.Phrase = new iTextSharp.text.Phrase("\r\n\r\n" + "The Consignment Information", nationalTextFont2);
                     table.AddCell(cell);

                     //-------------------------------------------------------------------------------------------
                     cell.BackgroundColor = new iTextSharp.text.BaseColor(242, 242, 242);  // iTextSharp.text.BaseColor.LIGHT_GRAY;
                     cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     //cell.Border = 0;
                     cell.Phrase = new iTextSharp.text.Phrase("طريقة الدفع", nationalTextFont);
                     table.AddCell(cell);

                     TblInside = new PdfPTable(6);
                     colsInside = new[] { 90, 90, 90,40,140,90 };
                     TblInside.SetWidths(colsInside);
                     TblInside.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                     TblInside.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cellInside = new PdfPCell(TblInside);
                     cellInside.ArabicOptions = ColumnText.DIGITS_EN2AN;
                     //cell330.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cellInside.PaddingRight = 0;

                     cell0 = new PdfPCell();
                     //cell320.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell0.ArabicOptions = ColumnText.DIGITS_EN2AN;
                     cell0.Border = 0;

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("نقداً:", nationalTextFont);
                     cell0.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                     TblInside.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                     TblInside.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                     TblInside.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                     TblInside.AddCell(cell0);
                     
                     PdfPCell cell90 = new PdfPCell();
                     cell90.ArabicOptions = ColumnText.DIGITS_EN2AN;
                     cell90.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     if (txtCashAmount.Text == "" || moh.StrToDouble(txtCashAmount.Text) == 0)
                     {
                         txtCashAmount.Text = "0";
                         cell90.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", moh.StrToDouble(txtCashAmount.Text)), nationalTextFont);
                     }
                     else
                     {
                         cell90.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2} ريال", moh.StrToDouble(txtCashAmount.Text)), nationalTextFont);
                     }
                     TblInside.AddCell(cell90);

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell0.Phrase = new iTextSharp.text.Phrase("Cash", nationalTextFont2);
                     TblInside.AddCell(cell0);

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("آجل فرع:", nationalTextFont);
                     TblInside.AddCell(cell0);
                     if (ddlSite.SelectedValue == "-1") cell0.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                     cell0.Phrase = new iTextSharp.text.Phrase(ddlSite.SelectedItem.Text, nationalTextFont);
                     TblInside.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                     TblInside.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                     TblInside.AddCell(cell0);
                     if (txtSiteAmount.Text == "" || moh.StrToDouble(txtSiteAmount.Text) == 0)
                     {
                         txtSiteAmount.Text = "0";
                         cell90.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", moh.StrToDouble(txtSiteAmount.Text)), nationalTextFont);
                     }
                     else
                     {
                         cell90.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2} ريال", moh.StrToDouble(txtSiteAmount.Text)), nationalTextFont);
                     }
                     TblInside.AddCell(cell90);
                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell0.Phrase = new iTextSharp.text.Phrase("Credit", nationalTextFont2);
                     TblInside.AddCell(cell0);

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("على حساب العميل:", nationalTextFont);
                     TblInside.AddCell(cell0);
                     if (ddlCustomers.SelectedValue == "-1") cell0.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                     else cell0.Phrase = new iTextSharp.text.Phrase(ddlCustomers.SelectedItem.Text, nationalTextFont);
                     TblInside.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                     TblInside.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("", nationalTextFont);
                     TblInside.AddCell(cell0);

                     if (txtCustomerAmount.Text == "" || moh.StrToDouble(txtCustomerAmount.Text) == 0)
                     {
                         txtCustomerAmount.Text = "0";
                         cell90.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2}", moh.StrToDouble(txtCustomerAmount.Text)), nationalTextFont);
                     }
                     else
                     {
                         cell90.Phrase = new iTextSharp.text.Phrase(string.Format("{0:N2} ريال", moh.StrToDouble(txtCustomerAmount.Text)), nationalTextFont);
                     }
                     TblInside.AddCell(cell90);
                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell0.Phrase = new iTextSharp.text.Phrase("Bill to Co", nationalTextFont2);
                     TblInside.AddCell(cell0);
                     table.AddCell(cellInside);

                     cell.BackgroundColor = new iTextSharp.text.BaseColor(242, 242, 242);  // iTextSharp.text.BaseColor.LIGHT_GRAY;
                     cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell.Phrase = new iTextSharp.text.Phrase("Method of Payment", nationalTextFont2);
                     table.AddCell(cell);

                     //-------------------------------------------------------------------------------------------

                     cell.BackgroundColor = new iTextSharp.text.BaseColor(242, 242, 242);  // iTextSharp.text.BaseColor.LIGHT_GRAY;
                     cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     //cell.Border = 0;
                     cell.Phrase = new iTextSharp.text.Phrase("حالة السيارة" + "\r\n\r\n\r\n\r\n" + "العودة خلال ستة شهور فقط", nationalTextFont);
                     table.AddCell(cell);

                     TblInside = new PdfPTable(1);
                     colsInside = new[] { 550 };
                     TblInside.SetWidths(colsInside);
                     TblInside.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                     TblInside.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cellInside = new PdfPCell(TblInside);
                     cellInside.ArabicOptions = ColumnText.DIGITS_EN2AN;
                     //cell330.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cellInside.PaddingRight = 0;

                     iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("images/Car.jpg"));
                     logo.ScalePercent(38);
                     PdfPCell cell20 = new PdfPCell(logo);
                     cell20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell20.PaddingTop = 5;
                     cell20.PaddingBottom = 5;
                     cell20.PaddingRight = 0;
                     cell20.Border = 0;
                     TblInside.AddCell(cell20);




                     //--------------
                     PdfPTable TblInside20 = new PdfPTable(8);
                     colsInside = new[] { 125,30,30, 125, 125,30,30,125};
                     TblInside20.SetWidths(colsInside);
                     TblInside20.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                     TblInside20.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     PdfPCell cellInside20 = new PdfPCell(TblInside20);
                     cellInside20.ArabicOptions = ColumnText.DIGITS_EN2AN;
                     //cell330.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cellInside20.PaddingRight = 0;
                     cellInside20.Border = 0;

                     cell0 = new PdfPCell();
                     //cell320.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell0.ArabicOptions = ColumnText.DIGITS_EN2AN;
                     cell0.Border = 0;

                     cell90 = new PdfPCell();
                     cell90.ArabicOptions = ColumnText.DIGITS_EN2AN;
                     cell90.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     //cell90.PaddingTop = 3;
                     //cell90.PaddingBottom = 3;
                     //cell90.PaddingLeft = 1;
                     //cell90.PaddingRight = 1;
                                           
                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("الاســتـمــــارة", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell90.Phrase = new iTextSharp.text.Phrase(ImgAccess1.Src.Contains("False") ? "X" : " ", nationalTextFont2);                    
                     TblInside20.AddCell(cell90);
                     cell0.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("Registration", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("الايـــريــــال", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell90.Phrase = new iTextSharp.text.Phrase(ImgAccess2.Src.Contains("False") ? "X" : "  ", nationalTextFont2);
                     TblInside20.AddCell(cell90);
                     cell0.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("Anten", nationalTextFont2);
                     TblInside20.AddCell(cell0);

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("الكــنـداســـة", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell90.Phrase = new iTextSharp.text.Phrase(ImgAccess3.Src.Contains("False") ? "X" : " ", nationalTextFont2);
                     TblInside20.AddCell(cell90);
                     cell0.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("Silencer", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("راديـو و مسـجــل", nationalTextFont);
                     TblInside20.AddCell(cell0);
                     cell90.Phrase = new iTextSharp.text.Phrase(ImgAccess4.Src.Contains("False") ? "X" : " ", nationalTextFont2);
                     TblInside20.AddCell(cell90);
                     cell0.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("Radio Casete", nationalTextFont2);
                     TblInside20.AddCell(cell0);

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("سقف السيارة الخارجي", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell90.Phrase = new iTextSharp.text.Phrase(ImgAccess5.Src.Contains("False") ? "X" : " ", nationalTextFont2);
                     TblInside20.AddCell(cell90);
                     cell0.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("Top Roof", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("الاطـار الاحتيــاطي", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell90.Phrase = new iTextSharp.text.Phrase(ImgAccess6.Src.Contains("False") ? "X" : " ", nationalTextFont2);
                     TblInside20.AddCell(cell90);
                     cell0.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("Spare Tyre", nationalTextFont2);
                     TblInside20.AddCell(cell0);

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("مرآة جانبية يمين يسار", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell90.Phrase = new iTextSharp.text.Phrase(ImgAccess7.Src.Contains("False") ? "X" : " ", nationalTextFont2);
                     TblInside20.AddCell(cell90);
                     cell90.Phrase = new iTextSharp.text.Phrase(ImgAccess8.Src.Contains("False") ? "X" : " ", nationalTextFont2);
                     TblInside20.AddCell(cell90);
                     cell0.Phrase = new iTextSharp.text.Phrase("Side Mirror", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("طاسات كفرات أمامية", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell90.Phrase = new iTextSharp.text.Phrase(ImgAccess9.Src.Contains("False") ? "X" : " ", nationalTextFont2);
                     TblInside20.AddCell(cell90);
                     cell90.Phrase = new iTextSharp.text.Phrase(ImgAccess10.Src.Contains("False") ? "X" : " ", nationalTextFont2);
                     TblInside20.AddCell(cell90);
                     cell0.Phrase = new iTextSharp.text.Phrase("Wheel Cover Front", nationalTextFont2);
                     TblInside20.AddCell(cell0);

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("لوحات أمامية وخلفية", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell90.Phrase = new iTextSharp.text.Phrase(ImgAccess11.Src.Contains("False") ? "X" : " ", nationalTextFont2);
                     TblInside20.AddCell(cell90);
                     cell90.Phrase = new iTextSharp.text.Phrase(ImgAccess12.Src.Contains("False") ? "X" : " ", nationalTextFont2);
                     TblInside20.AddCell(cell90);
                     cell0.Phrase = new iTextSharp.text.Phrase("Number Plates", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("طاسات كفرات خلفية", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell90.Phrase = new iTextSharp.text.Phrase(ImgAccess13.Src.Contains("False") ? "X" : " ", nationalTextFont2);
                     TblInside20.AddCell(cell90);
                     cell90.Phrase = new iTextSharp.text.Phrase(ImgAccess14.Src.Contains("False") ? "X" : " ", nationalTextFont2);
                     TblInside20.AddCell(cell90);
                     cell0.Phrase = new iTextSharp.text.Phrase("Wheel Cover Rear", nationalTextFont2);
                     TblInside20.AddCell(cell0);

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("انوار أمامية وخلفية", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell90.Phrase = new iTextSharp.text.Phrase(ImgAccess15.Src.Contains("False") ? "X" : " ", nationalTextFont2);
                     TblInside20.AddCell(cell90);
                     cell90.Phrase = new iTextSharp.text.Phrase(ImgAccess16.Src.Contains("False") ? "X" : " ", nationalTextFont2);
                     TblInside20.AddCell(cell90);
                     cell0.Phrase = new iTextSharp.text.Phrase("Head & Back Lights", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("زجاج أمامي وخلفي", nationalTextFont2);
                     TblInside20.AddCell(cell0);
                     cell90.Phrase = new iTextSharp.text.Phrase(ImgAccess17.Src.Contains("False") ? "X" : " ", nationalTextFont2);
                     TblInside20.AddCell(cell90);
                     cell90.Phrase = new iTextSharp.text.Phrase(ImgAccess18.Src.Contains("False") ? "X" : " ", nationalTextFont2);
                     TblInside20.AddCell(cell90);
                     cell0.Phrase = new iTextSharp.text.Phrase("Wind Screen", nationalTextFont2);
                     TblInside20.AddCell(cell0);

                     TblInside.AddCell(cellInside20);
                     //--------------

                     cell0 = new PdfPCell();
                     //cell320.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell0.ArabicOptions = ColumnText.DIGITS_EN2AN;
                     //cell0.Border = 0;
                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell0.Phrase = new iTextSharp.text.Phrase("علامة (X) تعني ملاحظة على السيارة", nationalTextFont2);
                     cell0.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                     TblInside.AddCell(cell0);

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("1- "+ txtRemark1.Text, nationalTextFont2);
                     cell0.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                     TblInside.AddCell(cell0);

                     cell0.Phrase = new iTextSharp.text.Phrase("2- "+txtRemark2.Text, nationalTextFont2);
                     cell0.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                     TblInside.AddCell(cell0);

                     cell0.Phrase = new iTextSharp.text.Phrase("المرفقات: "+ txtAttached.Text, nationalTextFont2);
                     cell0.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                     TblInside.AddCell(cell0);

                     //--------------
                     PdfPTable TblInside2 = new PdfPTable(3);
                     colsInside = new[] { 180,180,180};
                     TblInside2.SetWidths(colsInside);
                     TblInside2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                     TblInside2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     PdfPCell cellInside2 = new PdfPCell(TblInside2);
                     cellInside2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                     //cell330.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cellInside2.PaddingRight = 0;
                     cellInside2.Border = 0;

                     cell0 = new PdfPCell();
                     cell0.FixedHeight = 14f;
                     //cell320.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell0.ArabicOptions = ColumnText.DIGITS_EN2AN;
                     cell0.Border = 0;

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("", nationalTextFont2);
                     cell0.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                     TblInside2.AddCell(cell0);
                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell0.Phrase = new iTextSharp.text.Phrase("مرسل السيارة", nationalTextFont2);
                     TblInside2.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("", nationalTextFont2);
                     TblInside2.AddCell(cell0);

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell0.Phrase = new iTextSharp.text.Phrase("موظف الأستقبال", nationalTextFont2);
                     TblInside2.AddCell(cell0);
                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("(قرأت الشروط بالخلف و أوافق عليها)", nationalTextFont2);
                     TblInside2.AddCell(cell0);
                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell0.Phrase = new iTextSharp.text.Phrase("المستلم", nationalTextFont2);
                     TblInside2.AddCell(cell0);

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("الاســم: " + txtUserName.Text, nationalTextFont2);
                     TblInside2.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("الاســم: " +txtName.Text , nationalTextFont2);
                     TblInside2.AddCell(cell0);
                     cell0.Phrase = new iTextSharp.text.Phrase("الاســم: " +txtRecName.Text , nationalTextFont2);
                     TblInside2.AddCell(cell0);

                     cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell0.Phrase = new iTextSharp.text.Phrase("التوقيع:", nationalTextFont2);
                     TblInside2.AddCell(cell0);
                     TblInside2.AddCell(cell0);
                     TblInside2.AddCell(cell0);

                     for (int r = ddlQty.SelectedIndex; r < 10; r++)
                     {
                         cell0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                         cell0.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont2);
                         TblInside2.AddCell(cell0);
                         TblInside2.AddCell(cell0);
                         TblInside2.AddCell(cell0);
                     }
                     TblInside.AddCell(cellInside2);

                     table.AddCell(cellInside);
                     //--------------
                     cell.BackgroundColor = new iTextSharp.text.BaseColor(242, 242, 242);  // iTextSharp.text.BaseColor.LIGHT_GRAY;
                     cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell.Phrase = new iTextSharp.text.Phrase("Status of Consignment Vehicle", nationalTextFont2);
                     table.AddCell(cell);
                     //------------------------------------------------------------------------------------------
                     document.Add(table);

                     PdfPTable foot = new PdfPTable(20);
                     colsInside = new[] { 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30 };
                     foot.TotalWidth = document.PageSize.Width; //100f;
                     foot.SetWidths(colsInside);
                     foot.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                     foot.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                     PdfPCell cell901 = new PdfPCell(foot);
                     cell901.ArabicOptions = ColumnText.DIGITS_EN2AN;
                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell901.Phrase = new iTextSharp.text.Phrase("X", nationalTextFont2);
                     cell901.Border = 0;

                     PdfPCell cell902 = new PdfPCell(foot);
                     cell902.ArabicOptions = ColumnText.DIGITS_EN2AN;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell902.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont2);
                     cell902.Border = 0;    

                     //0
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     foot.AddCell(ImgS1.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     foot.AddCell(ImgS2.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     foot.AddCell(ImgS3.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(ImgS4.Src.Contains("False") ? cell901 : cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     foot.AddCell(ImgS5.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(cell902);
                     foot.AddCell(cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     foot.AddCell(ImgS6.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     //1
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     foot.AddCell(ImgS7.Src.Contains("False") ? cell901 : cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     foot.AddCell(ImgS8.Src.Contains("False") ? cell901 : cell902);
                     foot.AddCell(ImgS9.Src.Contains("False") ? cell901 : cell902);
                     foot.AddCell(ImgS10.Src.Contains("False") ? cell901 : cell902);
                     foot.AddCell(cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     foot.AddCell(ImgS11.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(cell902);
                     foot.AddCell(cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     foot.AddCell(ImgS12.Src.Contains("False") ? cell901 : cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     foot.AddCell(ImgS13.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     foot.AddCell(ImgS14.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(ImgS15.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(ImgS16.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(ImgS17.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     //2
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     foot.AddCell(ImgS18.Src.Contains("False") ? cell901 : cell902);
                     foot.AddCell(ImgS19.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     foot.AddCell(ImgS21.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(ImgS22.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(cell902);

                     foot.AddCell(ImgS23.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);

                     //3
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);

                     //4
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);

                     //5
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     foot.AddCell(ImgS24.Src.Contains("False") ? cell901 : cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     foot.AddCell(ImgS25.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     foot.AddCell(ImgS26.Src.Contains("False") ? cell901 : cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     foot.AddCell(ImgS27.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     foot.AddCell(ImgS28.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);

                     //6
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     foot.AddCell(ImgS29.Src.Contains("False") ? cell901 : cell902);


                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     foot.AddCell(ImgS30.Src.Contains("False") ? cell901 : cell902);


                     foot.AddCell(cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     foot.AddCell(ImgS31.Src.Contains("False") ? cell901 : cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     foot.AddCell(ImgS32.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     foot.AddCell(ImgS33.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);

                     //7
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     foot.AddCell(ImgS34.Src.Contains("False") ? cell901 : cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     foot.AddCell(ImgS35.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     foot.AddCell(ImgS36.Src.Contains("False") ? cell901 : cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                     foot.AddCell(ImgS37.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(cell902);

                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     cell902.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                     foot.AddCell(ImgS38.Src.Contains("False") ? cell901 : cell902);

                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     //8
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     //9
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);
                     foot.AddCell(cell902);

                     foot.WriteSelectedRows(0, foot.Rows.Count(), 0, 500 - (15 * ddlQty.SelectedIndex), writer.DirectContent);


                     foot = new PdfPTable(5);
                     colsInside = new[] { 23, 75, 500, 65, 23 };
                     foot.TotalWidth = document.PageSize.Width; //100f;
                     foot.SetWidths(colsInside);
                     foot.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                     foot.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                     cell901 = new PdfPCell(foot);
                     cell901.ArabicOptions = ColumnText.DIGITS_EN2AN;
                     cell901.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell901.FixedHeight = 15f;
                     cell901.Border = 0;

                     //0
                     cell901.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(txtAccess1.Text, nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(txtAccess2.Text, nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont8);
                     foot.AddCell(cell901);

                     //1
                     cell901.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(txtAccess3.Text, nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(txtAccess4.Text, nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont8);
                     foot.AddCell(cell901);

                     //2
                     cell901.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(txtAccess5.Text, nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(txtAccess6.Text, nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont8);
                     foot.AddCell(cell901);

                     //3
                     cell901.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(txtAccess7.Text + " " + txtAccess8.Text, nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(txtAccess9.Text + " " + txtAccess10.Text, nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont8);
                     foot.AddCell(cell901);

                     //4
                     cell901.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(txtAccess11.Text + " " + txtAccess12.Text, nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(txtAccess13.Text + " " + txtAccess14.Text, nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont8);
                     foot.AddCell(cell901);

                     //5
                     cell901.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(txtAccess15.Text + " " + txtAccess16.Text, nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(txtAccess17.Text + " " + txtAccess18.Text, nationalTextFont8);
                     foot.AddCell(cell901);
                     cell901.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont8);
                     foot.AddCell(cell901);

                     foot.WriteSelectedRows(0, foot.Rows.Count(), 0, 407 - (15 * ddlQty.SelectedIndex), writer.DirectContent);








                     cols = new[] { 700 };
                     table = new PdfPTable(1);
                     table.TotalWidth = document.PageSize.Width; //100f;
                     table.SetWidths(cols);
                     cell = new PdfPCell();
                     cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                     cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                     table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                     cell.Border = 0;
                     cell.Phrase = new iTextSharp.text.Phrase("شركة ناقلات البرية - لمتابعة شحنتك على موقعنا www.naqelat.com للاستفسار اتصل على الرقم الموحد 920028833 ", nationalTextFont);
                     table.AddCell(cell);
                     //-------------------------------------------------------------------------------------------
                     document.Add(table);

                     document.Close();
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
        public class pdfPage : iTextSharp.text.pdf.PdfPageEventHelper
        {
            public string vStr1, vStr2, vStr3, vStr4,vStr5,vStr6, UserName, PageNo, vCompanyName;
            //I create a font object to use within my footer
            protected iTextSharp.text.Font footer
            {
                get
                {
                    // create a basecolor to use for the footer font, if needed.
                    iTextSharp.text.BaseColor grey = new iTextSharp.text.BaseColor(128, 128, 128);
                    string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                    BaseFont nationalBase;
                    nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(nationalBase, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.WHITE);
                    return font;
                }
            }
            //override the OnStartPage event handler to add our header
            public override void OnStartPage(PdfWriter writer, iTextSharp.text.Document doc)
            {
                string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                string arialunicodepath2 = HttpContext.Current.Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                BaseFont nationalBase;
                BaseFont nationalBase2;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                nationalBase2 = BaseFont.CreateFont(arialunicodepath2, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 16f, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font nationalTextFont16 = new iTextSharp.text.Font(nationalBase2, 14f, iTextSharp.text.Font.NORMAL);


                //I use a PdfPtable with 1 column to position my header where I want it
                PdfPTable headerTbl = new PdfPTable(4);
                var cols2 = new[] { 325,100,450, 325 };
                headerTbl.TotalWidth = doc.PageSize.Width;
                headerTbl.SetWidths(cols2);
                headerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                //set the width of the table to be the same as the document


                PdfPCell cell2 = new PdfPCell();
                cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell2.Border = 0;
                cell2.PaddingRight = 15;
                cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell2.Phrase = new iTextSharp.text.Phrase(vCompanyName + "\n" + vStr4, nationalTextFont);
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                headerTbl.AddCell(cell2);

                cell2.PaddingRight = 0;
                cell2.Phrase = new iTextSharp.text.Phrase("\n" + "إتفاقية شحن (فاتورة) \n رقم " + moh.MakeMask(DateTime.Parse(vStr6).Month.ToString(), 2) + moh.MakeMask(DateTime.Parse(vStr6).Day.ToString(), 2) + " " + vStr3 + " " + (100 + int.Parse(vStr5)).ToString(), nationalTextFont16);
                cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                headerTbl.AddCell(cell2);

                var TextCell = new PdfPCell(headerTbl.DefaultCell);
                TextCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                TextCell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                //TextCell.Border = 0;
                TextCell.BorderColor = iTextSharp.text.BaseColor.WHITE;
                PdfContentByte cb = writer.DirectContent;
                var bc128 = new Barcode128();
                bc128.CodeType = Barcode.CODE128;
                bc128.Code = vStr2 + vStr3;
                bc128.GenerateChecksum = true;
                bc128.AltText = "";
                bc128.StartStopText = true;


                //bc128.BarHeight = 8;
                //bc128.Extended = true; 

                //bc128.Baseline = 20;   // Doesn't affect rendering.
                //bc128.Size = 20;       // Doesn't affect rendering.
                //bc128.BarHeight = 60;  // DOES affect rendering.
                //bc128.X = 2;                          

                TextCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                TextCell.PaddingTop = 10;
                //cell.AddElement(bc128.CreateImageWithBarcode(cb, null, null));                    
                var bi = bc128.CreateImageWithBarcode(cb, null, null);
                bi.ScalePercent(100);
                bi.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                TextCell.AddElement(bi);

                //cell.Image = bc128.CreateImageWithBarcode(cb, null, null);                    
                //table.AddCell(cell);
                headerTbl.AddCell(TextCell);



                //var cols = new[] { 200, 150, 150, 300, 350 };
                //document.Open();
                //PdfPTable table = new PdfPTable(5);
                //table.TotalWidth = document.PageSize.Width; //100f;
                //table.SetWidths(cols);
                //PdfPCell cell2 = new PdfPCell();
                //cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell2.Border = 0;
                ////cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                //table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                //table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                //cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                //cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                //PdfPCell cell22 = new PdfPCell();
                //cell22.ArabicOptions = ColumnText.DIGITS_EN2AN;
                //cell22.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                //cell22.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                //cell2.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                //table.AddCell(cell2);

                //cell2.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                //cell2.Phrase = new iTextSharp.text.Phrase("إتفاقية شحن (فاتورة) رقم", nationalTextFont16);
                //table.AddCell(cell2);

                //cell22.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                //cell22.Phrase = new iTextSharp.text.Phrase(txtVouNo.Text + lblBranch.Text, nationalTextFont16);
                //table.AddCell(cell22);

                //cell2.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                //table.AddCell(cell2);


                //var TextCell = new PdfPCell(table.DefaultCell);
                //TextCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                //TextCell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                ////TextCell.Border = 0;
                //TextCell.BorderColor = iTextSharp.text.BaseColor.WHITE;
                //PdfContentByte cb = writer.DirectContent;
                //var bc128 = new Barcode128();
                //bc128.CodeType = Barcode.CODE128;
                //bc128.Code = lblBranch.Text + txtVouNo.Text;
                //bc128.GenerateChecksum = true;
                //bc128.AltText = "";
                //bc128.StartStopText = true;


                ////bc128.BarHeight = 8;
                ////bc128.Extended = true; 

                ////bc128.Baseline = 20;   // Doesn't affect rendering.
                ////bc128.Size = 20;       // Doesn't affect rendering.
                ////bc128.BarHeight = 60;  // DOES affect rendering.
                ////bc128.X = 2;                          

                //TextCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                ////cell.AddElement(bc128.CreateImageWithBarcode(cb, null, null));                    
                //var bi = bc128.CreateImageWithBarcode(cb, null, null);
                //bi.ScalePercent(100);
                //bi.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                //TextCell.AddElement(bi);

                ////cell.Image = bc128.CreateImageWithBarcode(cb, null, null);                    
                ////table.AddCell(cell);
                //table.AddCell(TextCell);
                //document.Add(table);


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
                headerTbl.WriteSelectedRows(0, -1, -1, (doc.PageSize.Height - 20), writer.DirectContent);
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
                if (moh.PrintDateofPrint) cell.Phrase = new iTextSharp.text.Phrase("تاريخ الطباعة : " + String.Format("{0:dd/MM/yyyy}", moh.Nows()), footer);
                else cell.Phrase = new iTextSharp.text.Phrase(" ", footer);
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


        public class pdfPage2 : iTextSharp.text.pdf.PdfPageEventHelper
        {
            public string vStr1, vStr2, vStr3, vStr4, UserName, PageNo, vCompanyName;
            //I create a font object to use within my footer
            protected iTextSharp.text.Font footer
            {
                get
                {
                    // create a basecolor to use for the footer font, if needed.
                    iTextSharp.text.BaseColor grey = new iTextSharp.text.BaseColor(128, 128, 128);
                    string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                    BaseFont nationalBase;
                    nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(nationalBase, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.WHITE);
                    return font;
                }
            }
            //override the OnStartPage event handler to add our header
            public override void OnStartPage(PdfWriter writer, iTextSharp.text.Document doc)
            {
                string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                //string arialunicodepath = HttpContext.Current.Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                BaseFont nationalBase;
                nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 18f, iTextSharp.text.Font.NORMAL);

                /*
                //I use a PdfPtable with 1 column to position my header where I want it
                PdfPTable headerTbl = new PdfPTable(3);
                var cols2 = new[] { 300, 600, 300 };
                headerTbl.TotalWidth = doc.PageSize.Width;
                headerTbl.SetWidths(cols2);
                headerTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                headerTbl.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                //set the width of the table to be the same as the document

                
                PdfPCell cell2 = new PdfPCell();
                cell2.ArabicOptions = ColumnText.DIGITS_EN2AN;
                cell2.Border = 0;
                cell2.PaddingRight = 15;
                cell2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                cell2.Phrase = new iTextSharp.text.Phrase(vCompanyName + "\n" + vStr4, nationalTextFont);
                cell2.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                headerTbl.AddCell(cell2);

                cell2.PaddingRight = 0;
                cell2.Phrase = new iTextSharp.text.Phrase(vStr1, nationalTextFont);
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
                headerTbl.WriteSelectedRows(0, -1, -1, (doc.PageSize.Height - 20), writer.DirectContent);
                 */
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
                if (moh.PrintDateofPrint) cell.Phrase = new iTextSharp.text.Phrase("تاريخ الطباعة : " + String.Format("{0:dd/MM/yyyy}", moh.Nows()), footer);
                else cell.Phrase = new iTextSharp.text.Phrase(" ", footer);
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



        protected void ddlPlaceofLoading_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDestination.SelectedIndex > 0 && ddlPlaceofLoading.SelectedIndex > 0)
                {
                    foreach (GridViewRow gvr in grdCodes.Rows)
                    {
                        DropDownList ddlModel = gvr.FindControl("ddlModel") as DropDownList;
                        if (ddlModel != null)
                        {
                            ddlModel_SelectedIndexChanged(ddlModel, e);
                        }
                    }
                    MakeSum();
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }

        }

        protected void BtnPrint2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, -50, -50, 40, 50);
                    HttpContext.Current.Response.ContentType = "application/pdf";
                    PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
                    pdfPage2 page = new pdfPage2();
                    MyConfig mySetting = new MyConfig();
                    mySetting.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    mySetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                    if (mySetting != null)
                    {
                        page.vCompanyName = mySetting.CompanyName;
                    }

                    writer.PageEvent = page;
                    page.PageNo = "1";
                    page.UserName = Session["FullUser"].ToString();

                    int ColCount = 3;
                    var cols = new[] { 28,350, 322 };
                    document.Open();
                    PdfPTable table = new PdfPTable(ColCount);
                    table.TotalWidth = document.PageSize.Width; //100f;
                    table.SetWidths(cols);
                    PdfPCell cell = new PdfPCell();
                    cell.ArabicOptions = ColumnText.DIGITS_EN2AN;
                    //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    string arialunicodepath = Server.MapPath("Fonts") + @"\mohammad_bold_art_1.ttf";
                    BaseFont nationalBase;
                    nationalBase = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font nationalTextFont = new iTextSharp.text.Font(nationalBase, 11f, iTextSharp.text.Font.NORMAL);
                    cell.Border = 0;

                    cell.BackgroundColor = new iTextSharp.text.BaseColor(242, 242, 242);  // iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.Phrase = new iTextSharp.text.Phrase("شروط النقل البري", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase("LAND TRANSIT CONDITIONS", nationalTextFont);
                    table.AddCell(cell);

                    cell.Phrase = new iTextSharp.text.Phrase(" ", nationalTextFont);
                    table.AddCell(cell);

                    cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.Phrase = new iTextSharp.text.Phrase("1- تعنى العبارة (المقاول) و (الناقل) في هذه الشروط – مؤسسة الناقلات البرية العربية – أو و كلائه وأي شخص أو أشخاص يقومون بنقل السيارات بموجب عقد من الباطن مع المقاول", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("In these Land Transit Condition the 'Contractor' or 'Transporter' means Arab Land Transporters Est. And includes the servants. Agents and any person or persons effecting the transport of vehicles for Contractor and/or under a sub-contract with the Contractor", nationalTextFont);                    
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("[1]", nationalTextFont);
                    table.AddCell(cell);


                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.Phrase = new iTextSharp.text.Phrase("2- شروط النقل هذه جزء لا يتحزأ من مستندات العقد المبرم مع العميل – ووثيقة رسمية لا يحق لأي شخص تعديل أي منها في أي وجه من الأوجه إلا بموجب أتفاق مستبق وتفويضاً صريحاً بذلك من المقاول", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("These Land Transit Conditions are part of the Contract documents. Witch are executed with the customer. Therefore no one will have any authority to vary these conditions in any way unless he is expressly authorized to do so by the contractor", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("[2]", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.Phrase = new iTextSharp.text.Phrase("3- يجب على العميل التأكد من صحة كافة البيانات المعبأة من قبله أو من يمثله والموضحة في هذه الاتفاقية وإذا اتضح عدم صحة أي من هذه البيانات فإن العميل سيتحمل كافة ما ينتج عن ذلك.", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("It is the customer's responsibility to make sure of the required relevant information that he or his representative should fill out on the cover side of this contract, if any given information are wrong customer is responsible for consequence", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("[3]", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.Phrase = new iTextSharp.text.Phrase("4- تقتصر مسؤولية المقاول إزاء العميل عن ضرر سيارته / سياراته على المسؤولية التي تغطيها بوليصة التأمين ولا يكون الناقل مسؤولاً عن الأضرار غير المباشرة أو المترتبة عن الخسائر والأضرار الناتجة عن تعرض السيارة للأعطال الميكانيكية و الكهربائية أو كسر بالزجاج أو أي أضرار أخرى ناتجة بسبب حادث مروري قبل استلام السيارة من قبل الناقل ، كما لا يتحمل الناقل أي مسؤولية تجاه تلف أو فقدان الأمتعة الشخصية داخل السيارة.", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("The Contractor's liability to the customer for damage or loss of his vehicle/vehicles shall be limited to that covered by the Contractor's  Land Transit Insurance policy. The Contractor shall not be limited to that covered by the Contract's land Transit Insurance police. The Contractor shall not be liable forindirect  or consequential damage to the vehicle/vehicles; or  loss or damage happen Electro-Mechanical work or break down of grass or any other damage due to traffic accident before receiving the vehicle by Transporter. Also the Transporter is not liable for the loss or damage to the personal effects or luggage inside the vehicle", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("[4]", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.Phrase = new iTextSharp.text.Phrase("5- على المقاول أن يبذل كل جهد معقول لضمان توريد السيارة / السيارات بأمان إلى العنوان الموضح على وجه هذه الاتفاقية وتسليمها إلى العميل أو من ينوب عنه.", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("The Contractor  shall  make reasonable effect to see that the vehicle/vehicles are safely delivered at the address indicated on the cover side of this contract  to an apparently member of the consignee's staff", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("[5]", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.Phrase = new iTextSharp.text.Phrase("6- الناقل غير مسؤول عن أي أضرار للسيارة بعد استلام العميل لها أو من ينوب عنه وتقتصر مسؤولية الناقل في الفترة من تاريخ الاستلام إلى تاريخ التسليم.", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("The Contractor shall  not be liable  for any damage or loss to the vehicle after receipt by customer or his representative. The Transporter liability towards vehicle/vehicles are only limited during the period from the date of received to the time of delivery", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("[6]", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.Phrase = new iTextSharp.text.Phrase("7- يلتزم العميل باستلام سيارته أو من ينوب عنه مباشرة في موقع التسليم للمقاول والمدن في هذه الاتفاقية وفي مدة أقصاها سبعة أيام من تاريخ وصول السيارة وبعد هذا التاريخ مباشرة يلتزم العميل بدفع مبلغ وقدره (10) ريالات رسوم أرضية عن كل يوم تأخير.", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("The costumer is obliged to receive his vehicle from Contractor's place of delivery mentioned in this contract within seven days of arrived .After passing this date the costumer has to pay demurrage charges SR: 10 per each day", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("[7]", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.Phrase = new iTextSharp.text.Phrase("8- يمنع منعاً باتاً وضع أي مواد قالبة للاشتعال أو أسلحة غير مرخصة أو أي ممنوعات أخرى يحظر تداولها طبقاً للأنظمة المعمول بها في المملكة العربية السعودية داخل السيارة المنقولة ويتحمل العميل كامل المسؤولية تجاه ما يترتب على ذلك ، كما أنه الناقل غير مسؤول عن ترك أي أشياء ثمينة من قبل العميل داخل السيارة عند نقلها.", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("It is totally prohibited to place inside the transported vehicle any inflammable item or arms without license or any other forbidden goods according  to the law of Kingdom  of Saudi Arabia and the customer shall be fully responsible for violating this act. Also the Transporter is not responsible for any valuable things left out by customer in the vehicle", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("[8]", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.Phrase = new iTextSharp.text.Phrase("9- تدفع رسوم النقل الخاصة بالمقابل بواسطة العميل دون أن يؤثر ذلك على حقوق المقاول ضد المرسل أو المرسل إليه أو أي شخص أخر ويجب ألا يؤخذ أي أدعاء كمبرر لتأخير أو احتجاز مدفوعات مستحقة للمقاول أو مسؤوليات يتكبدها المقاول.", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("The Contractor 's charge shall by  payable by the customer without prejudice to the Contractor 's right against the consignor, consignee or any other person. A claim or counterclaim shall not be made the reason for deferring or withholding payment of money or liabilities owing to the Contractor", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("[9]", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.Phrase = new iTextSharp.text.Phrase("10- على العميل أن يبري ذمة المقاول ويحميه ضد كل الدعاوي والتكاليف والمطالبات التي تقدم من أي جهة كانت و تتجاوز قيمتها المسؤوليات القانونية للمقاول وفقاً لأحكام هذه الشروط", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("The customer shall save harmless and keep the Contractor indemnified from and against all claim, cost and demands by whosoever made or preferred in excess of the legal liabilities of the Contractor under the terms of these conditions", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("[10]", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.Phrase = new iTextSharp.text.Phrase("11- في حالة الغاء اتفاقية الشحن يلتزم العميل بسداد مبلغ 50 ريال مصاريف أدارية", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("In case of cancellation shipping invoice customer shall pay an amount of SR 50 administrative expenses", nationalTextFont);
                    table.AddCell(cell);

                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    cell.Phrase = new iTextSharp.text.Phrase("[11]", nationalTextFont);
                    table.AddCell(cell);
                   

                    document.Add(table);

                    document.Close();
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

        public void DispVouData()
        {
            try
            {
                grdCodes.DataSource = VouData;
                grdCodes.DataBind();
                int i = 1;
                foreach (GridViewRow gvr in grdCodes.Rows)
                {
                    DropDownList ddlCarType = gvr.FindControl("ddlCarType") as DropDownList;
                    DropDownList ddlModel = gvr.FindControl("ddlModel") as DropDownList;
                    TextBox txtBrand = gvr.FindControl("txtBrand") as TextBox;
                    TextBox txtPlateNo = gvr.FindControl("txtPlateNo") as TextBox;
                    TextBox txtChassisNo = gvr.FindControl("txtChassisNo") as TextBox;
                    TextBox txtColor = gvr.FindControl("txtColor") as TextBox;
                    TextBox txtPrice = gvr.FindControl("txtPrice") as TextBox;
                    HiddenField txtPrice2 = gvr.FindControl("txtPrice2") as HiddenField;
                    string FNo = grdCodes.DataKeys[gvr.RowIndex]["FNo"].ToString();
                    CustomValidator ValAmount2 = gvr.FindControl("ValAmount2") as CustomValidator;

                    if (ddlCarType != null && ddlModel != null && txtBrand != null && txtPlateNo != null && txtChassisNo != null && txtColor != null && txtPrice != null && FNo != null && txtPrice2 != null && ValAmount2 != null)
                    {

                        CarType myCarType = new CarType();
                        myCarType.cnn = WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString;
                        myCarType.Branch = short.Parse(Session["Branch"].ToString());
                        myCarType.FCode = "";
                        ddlCarType.DataTextField = "Name1";
                        ddlCarType.DataValueField = "Code";
                        ddlCarType.DataSource = myCarType.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        ddlCarType.DataBind();
                        ddlCarType.Items.Insert(0, new ListItem("["+i.ToString()+"]", "-1", true));
                        
                        ValAmount2.ClientValidationFunction = "CheckItemO" + (i - 1).ToString();
                        txtPrice.Attributes.Add("onchange", "javascript:MakeJSum();");
                        ddlCarType.SelectedValue = VouData[int.Parse(FNo) - 1].CarType;
                        if (ddlCarType.SelectedIndex > 0)
                        {
                            myCarType = new CarType();
                            myCarType.cnn = WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString;
                            myCarType.Branch = short.Parse(Session["Branch"].ToString());
                            myCarType.FCode = ddlCarType.SelectedValue;
                            ddlModel.DataTextField = "Name1";
                            ddlModel.DataValueField = "Code";

                            ddlModel.DataSource = myCarType.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            ddlModel.DataBind();

                            ddlModel.SelectedValue = VouData[int.Parse(FNo) - 1].Model;
                            txtPlateNo.Text = VouData[int.Parse(FNo) - 1].PlateNo;
                            txtChassisNo.Text = VouData[int.Parse(FNo) - 1].ChassisNo;
                            txtColor.Text = VouData[int.Parse(FNo) - 1].Color;
                            txtPrice.Text = VouData[int.Parse(FNo) - 1].Price.ToString();   // string.Format("{0:N2}", VouData[int.Parse(FNo) - 1].Price);
                            txtPrice2.Value = VouData[int.Parse(FNo) - 1].Price2.ToString(); // string.Format("{0:N2}", VouData[int.Parse(FNo) - 1].Price2);
                        }
                    }
                    i++;
                }
                MakeSum();
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        public void MakeSum()
        {
            try
            {
                txtTotal.Text = "";
                double tot = 0;
                foreach (GridViewRow gvr in grdCodes.Rows)
                {
                    TextBox txtPrice = gvr.FindControl("txtPrice") as TextBox;
                    if (txtPrice != null)
                    {
                        if (txtPrice.Text == "") txtPrice.Text = "0";
                        tot += moh.StrToDouble(txtPrice.Text);
                    }
                }
                txtTotal.Text = tot.ToString(); //string.Format("{0:N2}", tot);
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        public void SaveGridInfo()
        {
            VouData.Clear();
            int i = 1;
            foreach (GridViewRow gvr in grdCodes.Rows)
            {
                DropDownList ddlCarType = gvr.FindControl("ddlCarType") as DropDownList;
                string FNo = grdCodes.DataKeys[gvr.RowIndex]["FNo"].ToString();
                DropDownList ddlModel = gvr.FindControl("ddlModel") as DropDownList;
                TextBox txtBrand = gvr.FindControl("txtBrand") as TextBox;
                TextBox txtPlateNo = gvr.FindControl("txtPlateNo") as TextBox;
                TextBox txtChassisNo = gvr.FindControl("txtChassisNo") as TextBox;
                TextBox txtColor = gvr.FindControl("txtColor") as TextBox;
                TextBox txtPrice = gvr.FindControl("txtPrice") as TextBox;
                HiddenField txtPrice2 = gvr.FindControl("txtPrice2") as HiddenField;

                if (ddlCarType != null && ddlModel != null && txtBrand != null && txtPlateNo != null && txtChassisNo != null && txtColor != null && txtPrice != null && FNo != null && txtPrice2 != null)
                {
                    if (txtPrice.Text == "") txtPrice.Text = "0";
                    if (txtPrice2.Value == "") txtPrice2.Value = "0";
                    VouData.Add(new InvDetails
                    {
                        Brand = txtBrand.Text,
                        CarType = ddlCarType.SelectedValue,
                        ChassisNo = txtChassisNo.Text,
                        Color = txtColor.Text,
                        FNo = (short)i,
                        Model = ddlModel.SelectedValue,
                        PlateNo = txtPlateNo.Text,
                        Price = moh.StrToDouble(txtPrice.Text),
                        Price2 = moh.StrToDouble(txtPrice2.Value)
                    });
                }
                i++;
            }
        }

        protected void ddlQty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SaveGridInfo();
                if (VouData.Count > ddlQty.SelectedIndex + 1)
                {
                    for (int i = VouData.Count; i > (ddlQty.SelectedIndex+1); i--)
                    {
                        VouData.RemoveAt(i-1);
                    }
                }
                else
                {
                    for(int i = VouData.Count;i<=ddlQty.SelectedIndex;i++)
                    {
                        VouData.Add(new InvDetails {FNo = (short)(i+1) });
                    }
                }
                DispVouData();
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
                        myArch.LocNumber = short.Parse(AreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 503;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(AreaNo);
                        myArch.Number = int.Parse(txtVouNo.Text);
                        myArch.DocType = 503;
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
                myArch.LocNumber = short.Parse(AreaNo);
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = 503;
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
            try
            {
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(Session["Branch"].ToString());
                myArch.LocNumber = short.Parse(AreaNo);
                myArch.Number = int.Parse(txtVouNo.Text);
                myArch.DocType = 503;
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
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void ddlCarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddlCarType = sender as DropDownList;
                if (ddlCarType != null && ddlCarType.SelectedIndex > 0)
                {
                    GridViewRow gvr = ddlCarType.NamingContainer as GridViewRow;
                    string FNo = grdCodes.DataKeys[gvr.RowIndex]["FNo"].ToString();
                    VouData[int.Parse(FNo) - 1].CarType = ddlCarType.SelectedValue;
                    DropDownList ddlModel = gvr.FindControl("ddlModel") as DropDownList;
                    if (ddlModel != null)
                    {
                        CarType myCarType = new CarType();
                        myCarType.cnn = WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString;
                        myCarType.Branch = short.Parse(Session["Branch"].ToString());
                        myCarType.FCode = ddlCarType.SelectedValue;
                        ddlModel.DataTextField = "Name1";
                        ddlModel.DataValueField = "Code";
                        ddlModel.DataSource = myCarType.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        ddlModel.DataBind();
                        VouData[int.Parse(FNo) - 1].Model = ddlModel.SelectedValue;
                        ddlModel_SelectedIndexChanged(ddlModel, e);
                    }
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddlModel = sender as DropDownList;
                if (ddlModel != null)
                {
                    GridViewRow gvr = ddlModel.NamingContainer as GridViewRow;
                    string FNo = grdCodes.DataKeys[gvr.RowIndex]["FNo"].ToString();
                    TextBox txtPrice = gvr.FindControl("txtPrice") as TextBox;
                    HiddenField txtPrice2 = gvr.FindControl("txtPrice2") as HiddenField;

                    VouData[int.Parse(FNo) - 1].Model = ddlModel.SelectedValue;
                    CarType myCarType = new CarType();
                    myCarType.cnn = WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString;
                    myCarType.Branch = short.Parse(Session["Branch"].ToString());
                    myCarType.Code = ddlModel.SelectedValue;
                    myCarType = myCarType.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myCarType != null && ddlDestination.SelectedIndex > 0 && ddlPlaceofLoading.SelectedIndex > 0)
                    {
                        CarPrices myPrice = new CarPrices();
                        myPrice.Branch = short.Parse(Session["Branch"].ToString());
                        myPrice.MonthNo = (short)DateTime.Parse(txtGDate.Text).Month;
                        myPrice.FromCode = ddlPlaceofLoading.SelectedValue;
                        myPrice.toCode = ddlDestination.SelectedValue;
                        myPrice.PLevel = myCarType.LevelCode;
                        myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myPrice == null)
                        {
                            myPrice = new CarPrices();
                            myPrice.Branch = short.Parse(Session["Branch"].ToString());
                            myPrice.MonthNo = 0;
                            myPrice.FromCode = ddlPlaceofLoading.SelectedValue;
                            myPrice.toCode = ddlDestination.SelectedValue;
                            myPrice.PLevel = myCarType.LevelCode;
                            myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                        if (myPrice != null && txtPrice != null && txtPrice2 != null)
                        {
                            Offers myOffer = new Offers();                           
                            myOffer.Branch = short.Parse(Session["Branch"].ToString());
                            double vPer = 0;
                            foreach (Offers itm in myOffer.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                if ((bool)itm.OfferActive)
                                {
                                    if (DateTime.Parse(txtGDate.Text) >= DateTime.Parse(itm.FDate)  && DateTime.Parse(txtGDate.Text) <= DateTime.Parse(itm.EDate))
                                    {
                                        vPer = (double)itm.Discount;
                                        if (itm.FTime != "" && itm.ETime != "")
                                        {
                                            if (moh.Nows().TimeOfDay >= TimeSpan.Parse(itm.FTime) && moh.Nows().TimeOfDay <= TimeSpan.Parse(itm.ETime))
                                            {
                                                vPer = (double)itm.Discount;
                                            }
                                            else vPer = 0;
                                        }

                                        break;
                                    }
                                }
                            }

                            txtPrice.Text = (rdoVouType.SelectedValue == "0" ? (myPrice.HOneWay + (myPrice.HOneWay*vPer/100)).ToString() : (myPrice.HTwoWay + (myPrice.HTwoWay*vPer/100)).ToString());
                            txtPrice2.Value = (rdoVouType.SelectedValue == "0" ? (myPrice.LOneWay + (myPrice.LOneWay*vPer/100)).ToString() : (myPrice.LTwoWay + (myPrice.LTwoWay*vPer/100)).ToString());

                            VouData[int.Parse(FNo) - 1].Price = moh.StrToDouble(txtPrice.Text);
                            VouData[int.Parse(FNo) - 1].Price2 = moh.StrToDouble(txtPrice2.Value);
                            MakeSum();
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

        protected void ValAmount2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                CustomValidator ValAmount2 = source as CustomValidator;
                GridViewRow gvr = ValAmount2.NamingContainer as GridViewRow;
                TextBox txtPrice = gvr.FindControl("txtPrice") as TextBox;
                HiddenField txtPrice2 = gvr.FindControl("txtPrice2") as HiddenField;
                string FNo = grdCodes.DataKeys[gvr.RowIndex]["FNo"].ToString();
                args.IsValid = true;
                if (txtPrice != null && txtPrice2 != null && FNo != null)
                {
                    if (txtPrice.Text == "") txtPrice.Text = "0";
                    if (txtPrice2.Value == "") txtPrice2.Value = "0";
                    if (moh.StrToDouble(txtPrice.Text) < moh.StrToDouble(txtPrice2.Value))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد تجاوزت الحد الادنى";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        args.IsValid = false;
                    }
                    else VouData[int.Parse(FNo) - 1].Price = moh.StrToDouble(txtPrice.Text);
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void BtnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                int vCarType = -1;
                int vModel = -1;
                string vBrand = "";
                string vColor = "";
                string vPrice = "";
                string vPrice2 = "";

                foreach (GridViewRow gvr in grdCodes.Rows)
                {
                    DropDownList ddlCarType = gvr.FindControl("ddlCarType") as DropDownList;
                    DropDownList ddlModel = gvr.FindControl("ddlModel") as DropDownList;
                    TextBox txtBrand = gvr.FindControl("txtBrand") as TextBox;
                    TextBox txtColor = gvr.FindControl("txtColor") as TextBox;
                    TextBox txtPrice = gvr.FindControl("txtPrice") as TextBox;
                    HiddenField txtPrice2 = gvr.FindControl("txtPrice2") as HiddenField;
                    string FNo = grdCodes.DataKeys[gvr.RowIndex]["FNo"].ToString();

                    if (ddlCarType != null && ddlModel != null && txtBrand != null && txtColor != null && txtPrice != null && FNo != null && txtPrice2 != null)
                    {
                        if (ddlCarType.SelectedIndex > 0)
                        {
                            vCarType = ddlCarType.SelectedIndex;
                            vModel = ddlModel.SelectedIndex;
                            vBrand = txtBrand.Text;
                            vColor = txtColor.Text;
                            vPrice = txtPrice.Text;
                            vPrice2 = txtPrice2.Value;
                        }
                        else
                        {
                            ddlCarType.SelectedIndex = vCarType;
                            ddlCarType_SelectedIndexChanged(ddlCarType, e);
                            ddlModel.SelectedIndex = vModel;
                            txtBrand.Text = vBrand;
                            txtColor.Text = vColor;
                            txtPrice.Text = vPrice;
                            txtPrice2.Value = vPrice2;
                            VouData[int.Parse(FNo) - 1].CarType = ddlCarType.SelectedValue;
                            VouData[int.Parse(FNo) - 1].Model = ddlModel.SelectedValue;
                            if (txtPrice.Text == "") txtPrice.Text = "0";
                            if (txtPrice2.Value == "") txtPrice2.Value = "0";
                            VouData[int.Parse(FNo) - 1].Price = moh.StrToDouble(txtPrice.Text);
                            VouData[int.Parse(FNo) - 1].Price2 = moh.StrToDouble(txtPrice2.Value);
                            MakeSum();
                            break;
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

        protected void ChkReturnInv_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtOVouNo.Visible = ChkReturnInv.Checked;
                BtnFind2.Visible = ChkReturnInv.Checked;
                if (!ChkReturnInv.Checked) txtOVouNo.Text = "";
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        protected void BtnFind2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtOVouNo.Text != "")
                {
                    if (txtOVouNo.Text.Split('/').Count() < 2)
                    {
                        txtOVouNo.Text = int.Parse(AreaNo).ToString() + "/" + txtOVouNo.Text;
                    }

                     Invoice myInv = new Invoice();
                     myInv.OVouNo = txtOVouNo.Text;
                     myInv = myInv.FindByOVouNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                     if (myInv != null)
                     {
                         LblCodesResult.ForeColor = System.Drawing.Color.Red;
                         LblCodesResult.Text = "تم عمل عودة لنفس الفاتورة في الفاتورة رقم " + int.Parse(myInv.VouLoc).ToString() + "/" + myInv.VouNo.ToString();
                         ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                         return;   
                     }

                     myInv = new Invoice();
                     myInv.Branch = short.Parse(Session["Branch"].ToString());
                     myInv.VouLoc = moh.MakeMask(txtOVouNo.Text.Split('/')[0], 5);
                     myInv.VouNo = int.Parse(txtOVouNo.Text.Split('/')[1]);

 
                     myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                     if (myInv == null)
                     {
                         LblCodesResult.ForeColor = System.Drawing.Color.Red;
                         LblCodesResult.Text = "رقم الفاتورة غير معرف من قبل";
                         ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                     }
                     else
                     {
                         if ((short)myInv.VouType != 1)
                         {
                             LblCodesResult.ForeColor = System.Drawing.Color.Red;
                             LblCodesResult.Text = "الفاتورة ذهاب فقط وليست ذهاب و عودة";
                             ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, false), true);
                         }
                         else
                         {
                             GetInv(myInv,true);
                             InvDetails sinv = new InvDetails();
                             sinv.Branch = myInv.Branch;
                             sinv.VouLoc = myInv.VouLoc;
                             sinv.VouNo = myInv.VouNo;
                             VouData.Clear();
                             VouData = sinv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                             foreach (InvDetails itm in VouData)
                             {
                                 itm.Price = 0;
                                 itm.Price2 = 0;
                             }
                             DispVouData();
                         }
                     }
                 }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم الفاتورة";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

     }
}