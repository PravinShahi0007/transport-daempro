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
    public partial class WebOffers : System.Web.UI.Page
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
        public string Slat
        {
            get
            {
                if (ViewState["Slat"] == null)
                {
                    ViewState["Slat"] = "";
                }
                return ViewState["Slat"].ToString();
            }
            set { ViewState["Slat"] = value; }
        }
        public string Slng
        {
            get
            {
                if (ViewState["Slng"] == null)
                {
                    ViewState["Slng"] = "";
                }
                return ViewState["Slng"].ToString();
            }
            set { ViewState["Slng"] = value; }
        }
        public void EditMode()
        {
            BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass141;
            BtnEdit.Visible = 
            BtnDelete.Visible = 
            BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass144;
            BtnFind.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass144;
            RangeValidator1.Enabled = false;
            RangeValidator2.Enabled = false;

            txtPromoCode.ReadOnly = true;
            txtPromoCode.BackColor = System.Drawing.Color.LightGray;

            //BtnPrint.Visible = true && (bool)((List<TblRoles>)(Session[RoleName]))[1].Pass215;
            BtnEdit.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass142;
            BtnNew.Visible = false;
            BtnDelete.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass143;
        }

        public void NewMode()
        {
            txtPromoCode.ReadOnly = false;
            txtPromoCode.BackColor = System.Drawing.Color.White;
            RangeValidator1.Enabled = true;
            RangeValidator2.Enabled = true;

            //BtnPrint.Visible = false;
            BtnEdit.Visible = false;
            BtnNew.Visible = true && (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass141;
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
                    this.Page.Header.Title = "العروض الخاصة و المواسم";
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

                    BtnNew.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass141;
                    BtnEdit.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass142;
                    BtnDelete.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass143;
                    BtnSearch.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass144;
                    BtnFind.Visible = (bool)((List<TblRoles>)(Session["Roll"]))[1].Pass144;
                    List<Acc1> lacc = new List<Acc1>();
                    Acc myacc = new Acc();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["LastACC" + Session["CNN2"].ToString()] == null) Cache.Insert("LastACC" + Session["CNN2"].ToString(), myacc.GetLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));

                    lacc = (from itm in (List<Acc1>)(Cache["LastACC" + Session["CNN2"].ToString()])
                                               where itm.FCode.StartsWith("120301")
                                               orderby itm.Name1
                                               select itm).ToList();

                    ShipUsers myship = new ShipUsers();
                    lacc.AddRange((from itm in myship.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                   select new Acc1
                                   {
                                       Code = itm.ID,
                                       Name1 = itm.FirstName + " " + itm.LastName
                                   }).ToList());
                                     
                    ddlCustomer.DataSource  = lacc;
                    ddlCustomer.DataTextField = "Name1";
                    ddlCustomer.DataValueField = "Code";
                    ddlCustomer.DataBind();


                    Cities myCity = new Cities();
                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlFromLoc.DataTextField = "Name1";
                    ddlFromLoc.DataValueField = "Code";
                    ddlToLoc.DataTextField = "Name1";
                    ddlToLoc.DataValueField = "Code";
                    ddlFromLoc.DataSource = (from itm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                             orderby itm.Name1
                                             select itm).ToList();
                    ddlToLoc.DataSource = ddlFromLoc.DataSource;

                    ddlCustomer.DataBind();
                    ddlFromLoc.DataBind();
                    ddlToLoc.DataBind();
                    ddlCustomer.Items.Insert(0, new ListItem("--- أختار العميل ---", "-1", true));
                    ddlToLoc.Items.Insert(0, new ListItem("--- أختار جهة الترحيل ---", "-1", true));
                    ddlFromLoc.Items.Insert(0, new ListItem("--- أختار مكان الشحن ---", "-1", true));

                    LoadGridData();
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


        protected void LoadGridData()
        {
            try
            {
                Offers myacc = new Offers();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                grdCodes.DataSource = myacc.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
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
                string OfferNo = grdCodes.DataKeys[e.NewSelectedIndex]["OfferNo"].ToString();
                BtnClear_Click(sender, null);
                txtOfferNo.Text = OfferNo;
                Offers myacc = new Offers();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                myacc.OfferNo = int.Parse(txtOfferNo.Text);
                myacc = myacc.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myacc != null)
                {
                    EditMode();
                    GetData(myacc);
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "رقم العرض غير معرف من قبل";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                }
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
                e.NewSelectedIndex = -1;
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
                txtOfferNo.Text = "";
                txtDiscount.Text = "";
                txtEDate.Text = "";
                txtFDate.Text = "";
                txtFTime.Text = String.Format("{0:HH:mm}", moh.Nows());
                txtETime.Text = String.Format("{0:HH:mm}", moh.Nows());  
                txtInvoiceNo.Text = "";
                txtNoofUse.Text = "";
                txtPromoCode.Text = "";
                txtTotalofUse.Text = "";
                txtLocKM.Text = "";
                txtNoofUse.ReadOnly = false;
                txtTotalofUse.ReadOnly = false;
                ddlCustomer.SelectedIndex = 0;
                ddlFromLoc.SelectedIndex = 0;
                ddlToLoc.SelectedIndex = 0;
                ChkAmount.Checked = false;
                ChkFirstOrder.Checked = false;
                ChkFromServices.Checked = false;
                ChkOfferActive.Checked = false;
                ChkUseApp.Checked = false;
                ChkUseSystem.Checked = false;
                ChkUseWebsite.Checked = false;               
                for (int i = 0; i < ChkServices.Items.Count; i++)
                {
                    ChkServices.Items[i].Selected = false;
                }

                txtUserName.ToolTip = Session["CurrentUser"].ToString(); // "Admin";
                txtUserName.Text = Session["FullUser"].ToString();
                txtUserDate.Text = moh.CheckDate(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
                lnkFrom.Visible = false;
                lnkFrom.NavigateUrl = "";
                Slat = "";
                Slng = "";
                Offers myacc = new Offers();
                myacc.Branch = short.Parse(Session["Branch"].ToString());
                int? s = null;
                //myacc.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (s != null)
                {
                    txtOfferNo.Text = (s + 1).ToString();
                }
                else
                {
                    txtOfferNo.Text = "1";
                }
                Random r = new Random();
                bool vFound = false;
                while(!vFound)
                {
                    txtPromoCode.Text = ((char)r.Next(65, 90)).ToString() + ((char)r.Next(65, 90)).ToString() + ((char)r.Next(65, 90)).ToString() + r.Next(11111, 99999).ToString();
                    myacc = new Offers();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.PromoCode = txtPromoCode.Text;
                    myacc = myacc.FindPromoCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc == null)
                    {
                        vFound = true;
                        break;
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
                    Offers myacc = new Offers();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.PromoCode = txtPromoCode.Text;
                    myacc = myacc.FindPromoCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc != null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "كود العرض مكرر";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    if (DateTime.Parse(txtFDate.Text + " " + txtFTime.Text) > DateTime.Parse(txtEDate.Text + " " + txtETime.Text))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أن يكون تاريخ ووقت نهاية العرض اكبر من أو يساوي تاريخ ووقت بداية العرض";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    if (!ChkUseApp.Checked && !ChkUseSystem.Checked && !ChkUseWebsite.Checked)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أختيار طريقة أستخدام الخصم سواء تطبيق أو موقع أو الفروع";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    if ((bool)ChkAmount.Checked && moh.StrToShort(txtDiscount.Text) > 100)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أن لا يتجاوز نسبة الخصم 100%";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    string vRole = "";
                    bool vFound = false;
                    for (int i = 0; i < ChkServices.Items.Count; i++)
                    {
                        if (ChkServices.Items[i].Selected)
                        {
                            if (vRole == "") vRole = ChkServices.Items[i].Value;
                            else vRole += ";" + ChkServices.Items[i].Value;
                            vFound = true;
                        }
                    }
                    if (!vFound)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أن ينضم الخصم لخدمة من الخدمات";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    //myacc = new Offers();
                    //myacc.Branch = short.Parse(Session["Branch"].ToString());
                    //myacc.OfferNo = int.Parse(txtOfferNo.Text);
                    //myacc = myacc.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    //if (myacc == null)
                    //{
                        myacc = new Offers();
                        myacc.Branch = short.Parse(Session["Branch"].ToString());
                        myacc.OfferNo = int.Parse(txtOfferNo.Text);
                        myacc.FDate = txtFDate.Text;
                        myacc.EDate = txtEDate.Text;
                        myacc.FTime = txtFTime.Text;
                        myacc.ETime = txtETime.Text;
                        myacc.Discount = moh.StrToDouble(txtDiscount.Text);
                        myacc.OfferActive = ChkOfferActive.Checked;
                        myacc.UserName = txtUserName.ToolTip;
                        myacc.UserDate = txtUserDate.Text;

                        myacc.Amount = ChkAmount.Checked;
                        myacc.CustomerCode = ddlCustomer.SelectedValue;
                        myacc.FromLoc = ddlFromLoc.SelectedValue;
                        myacc.ToLoc = ddlToLoc.SelectedValue;
                        myacc.TotalofUse = moh.StrToInt(txtTotalofUse.Text);
                        myacc.UseApp = ChkUseApp.Checked;
                        myacc.UseSystem = ChkUseSystem.Checked;
                        myacc.UseWebsite = ChkUseWebsite.Checked;
                        myacc.PromoCode = txtPromoCode.Text;
                        myacc.FirstOrder = ChkFirstOrder.Checked;
                        myacc.FromService = ChkFromServices.Checked;
                        myacc.LocKM = moh.StrToInt(txtLocKM.Text);
                        myacc.LocLat = Slat;
                        myacc.LocLng = Slng;
                        myacc.Services = vRole;
                        myacc.NoofUse = moh.StrToInt(txtNoofUse.Text);
                        myacc.InvoiceNo = txtInvoiceNo.Text;

                        if (myacc.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LoadGridData();
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
                    //}
                    //else
                    //{
                    //    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    //    LblCodesResult.Text = "رقم العرض مكرر";
                    //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    //}

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
                if (txtPromoCode.Text != "")
                {
                    Offers myacc = new Offers();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.PromoCode = txtPromoCode.Text;
                    myacc = myacc.FindPromoCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc != null)
                    {
                        BtnClear_Click(sender, null);
                        EditMode();
                        GetData(myacc);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "رقم العرض غير معرف من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                    }
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = "يجب إدخال رقم العرض";
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

        public bool GetData(Offers myacc)
        {
            txtOfferNo.Text = myacc.OfferNo.ToString();
            txtFDate.Text = myacc.FDate;
            txtEDate.Text = myacc.EDate;
            txtFTime.Text = myacc.FTime;
            txtETime.Text = myacc.ETime;
            txtDiscount.Text = string.Format("{0:N2}", myacc.Discount);
            ChkOfferActive.Checked = (bool)myacc.OfferActive;
            txtUserName.ToolTip = myacc.UserName;
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
            txtUserDate.Text = myacc.UserDate;

            ChkAmount.Checked = (bool)myacc.Amount;
            ddlCustomer.SelectedValue = myacc.CustomerCode;
            ddlFromLoc.SelectedValue = myacc.FromLoc;
            ddlToLoc.SelectedValue = myacc.ToLoc;
            txtTotalofUse.Text = myacc.TotalofUse.ToString();
            txtNoofUse.Text = myacc.NoofUse.ToString();
            ChkUseApp.Checked = (bool)myacc.UseApp;
            ChkUseSystem.Checked = (bool)myacc.UseSystem;
            ChkUseWebsite.Checked = (bool)myacc.UseWebsite;
            txtPromoCode.Text = myacc.PromoCode;
            ChkFirstOrder.Checked = (bool)myacc.FirstOrder;
            ChkFromServices.Checked = (bool)myacc.FromService;
            txtLocKM.Text = myacc.LocKM.ToString();
            txtInvoiceNo.Text = myacc.InvoiceNo;
            Slat = myacc.LocLat;
            Slng = myacc.LocLng;
            if (Slat != "" && Slng != "")
            {
                lnkFrom.NavigateUrl = @"WebMap.aspx?lat=" + Slat + @"&lng=" + Slng;
                lnkFrom.Visible = true;
            }            
            for (int i = 0; i < ChkServices.Items.Count; i++)
            {
                if (myacc.Services.Contains(ChkServices.Items[i].Value))
                {
                    ChkServices.Items[i].Selected = true;
                }
            }
            return true;
        }

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    Offers myacc = new Offers();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.PromoCode = txtPromoCode.Text;
                    myacc = myacc.FindPromoCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc == null )
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "كود العرض غير مدرج من قبل";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    if (DateTime.Parse(txtFDate.Text + " " + txtFTime.Text) > DateTime.Parse(txtEDate.Text + " " + txtETime.Text))
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أن يكون تاريخ ووقت نهاية العرض اكبر من أو يساوي تاريخ ووقت بداية العرض";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    if (!ChkUseApp.Checked && !ChkUseSystem.Checked && !ChkUseWebsite.Checked)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أختيار طريقة أستخدام الخصم سواء تطبيق أو موقع أو الفروع";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    string vRole = "";
                    bool vFound = false;
                    for (int i = 0; i < ChkServices.Items.Count; i++)
                    {
                        if (ChkServices.Items[i].Selected)
                        {
                            if (vRole == "") vRole = ChkServices.Items[i].Value;
                            else vRole += ";" + ChkServices.Items[i].Value;
                            vFound = true;
                        }
                    }
                    if (!vFound)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أن ينضم الخصم لخدمة من الخدمات";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }

                    if ((bool)ChkAmount.Checked && moh.StrToShort(txtDiscount.Text) > 100)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "يجب أن لا يتجاوز نسبة الخصم 100%";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        return;
                    }
                    myacc = new Offers();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.OfferNo = int.Parse(txtOfferNo.Text);
                    myacc = myacc.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc != null)
                    {
                        myacc.FDate = txtFDate.Text;
                        myacc.EDate = txtEDate.Text;
                        myacc.FTime = txtFTime.Text;
                        myacc.ETime = txtETime.Text;
                        myacc.Discount = moh.StrToDouble(txtDiscount.Text);
                        myacc.OfferActive = ChkOfferActive.Checked;
                        myacc.UserName = txtUserName.ToolTip;
                        myacc.UserDate = txtUserDate.Text;

                        myacc.Amount = ChkAmount.Checked;
                        myacc.CustomerCode = ddlCustomer.SelectedValue;
                        myacc.FromLoc = ddlFromLoc.SelectedValue;
                        myacc.ToLoc = ddlToLoc.SelectedValue;
                        myacc.TotalofUse = moh.StrToInt(txtTotalofUse.Text);
                        myacc.UseApp = ChkUseApp.Checked;
                        myacc.UseSystem = ChkUseSystem.Checked;
                        myacc.UseWebsite = ChkUseWebsite.Checked;
                        myacc.PromoCode = txtPromoCode.Text;
                        myacc.FirstOrder = ChkFirstOrder.Checked;
                        myacc.FromService = ChkFromServices.Checked;
                        myacc.LocKM = moh.StrToInt(txtLocKM.Text);
                        myacc.LocLat = Slat;
                        myacc.LocLng = Slng;
                        myacc.Services = vRole;
                        myacc.NoofUse = moh.StrToInt(txtNoofUse.Text);
                        myacc.InvoiceNo = txtInvoiceNo.Text;

                        if (myacc.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            LoadGridData();
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
                        LblCodesResult.Text = "رقم العرض غير معرف من قبل";
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
                if (txtOfferNo.Text != "")
                {
                    Offers myacc = new Offers();
                    myacc.Branch = short.Parse(Session["Branch"].ToString());
                    myacc.OfferNo = int.Parse(txtOfferNo.Text);
                    myacc = myacc.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myacc != null)
                    {
                        // Check for Delete Offers
                        if (myacc.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            Transactions UserTran = new Transactions();
                            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                            UserTran.UserName = Session["CurrentUser"].ToString();
                            UserTran.Description = "الغاء بيانات العرض " + myacc.OfferNo.ToString();
                            UserTran.FormAction = "الغاء";
                            UserTran.FormName = "العروض";
                            UserTran.IP = IPNetworking.GetIP4Address();
                            UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                            LoadGridData();
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقم تم الغاء بيانات العرض بنجاح";
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
                    LblCodesResult.Text = "يجب إدخال رقم العرض";
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

        protected void btnFrom_Click(object sender, EventArgs e)
        {
            HttpCookie UserlatCookie = Request.Cookies["Userlat"];
            HttpCookie UserlngCookie = Request.Cookies["Userlng"];
            if (UserlatCookie != null && UserlngCookie != null)
            {
                Slat = UserlatCookie.Value;
                Slng = UserlngCookie.Value;
                lnkFrom.NavigateUrl = @"WebMap.aspx?lat=" + UserlatCookie.Value + @"&lng=" + UserlngCookie.Value;
                lnkFrom.Visible = true;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            RangeValidator1.MinimumValue = DateTime.Now.Date.ToString("dd/MM/yyyy");
            RangeValidator1.MaximumValue = DateTime.Now.Date.AddYears(90).ToString("dd/MM/yyyy");

            RangeValidator2.MinimumValue = DateTime.Now.Date.ToString("dd/MM/yyyy");
            RangeValidator2.MaximumValue = DateTime.Now.Date.AddYears(90).ToString("dd/MM/yyyy");
        }

        protected void ChkFirstOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkFirstOrder.Checked)
            {
                txtNoofUse.ReadOnly = true;
                txtNoofUse.Text = "0";
            }
            else
            {
                txtNoofUse.ReadOnly = false;
            }
        }

    }
}