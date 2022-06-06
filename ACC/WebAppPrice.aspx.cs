using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using BLL;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Data;

namespace ACC
{
    public partial class WebAppPrice : System.Web.UI.Page
    {

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

        public string AreaNo
        {
            get
            {
                if (ViewState["AreaNo"] == null)
                {
                    ViewState["AreaNo"] = "00018";
                }
                return ViewState["AreaNo"].ToString();
            }
            set { ViewState["AreaNo"] = value; }
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

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                //  ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttach);

                if (!Page.IsPostBack)
                {
                    Cities myCity = new Cities();
                    this.Page.Header.Title = "بطاقة خدمة / التطبيق";

                    //Session.Add("Branch", 1);
                    //Session.Add("AreaNo", "00001");
                    //Session.Add("CurrentUser", "Hanan");
                    //Session.Add("FullUser", "Hanan m");
                    //Session.Add("CNN", "MyCnn2");
                    //Session.Add("CNN2", "MyCnnlog");

                    //    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "الرئيسية", "اختيار", "اختيار بيان الترحيل", "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    if (Request.QueryString["AreaNo"] != null)
                    {
                        AreaNo = Request.QueryString["AreaNo"].ToString();

                        /*     CostCenter myCost = new CostCenter();
                             myCost.Branch = 1;
                             myCost.Code = Request.QueryString["AreaNo"].ToString();
                             myCost = myCost.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                             if (myCost != null) SiteInfo = myCost; */
                    }
                    else
                    {
                        AreaNo = Session["AreaNo"].ToString();
                        //  SiteInfo = (CostCenter)Session["SiteInfo"];
                    }

                    vRoleName = moh.GetCurrentRole(AreaNo, Session["CurrentUser"].ToString(), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    /*       if (Session[vRoleName] == null)
                           {
                              Response.Redirect("WebNotPrev.aspx", false);
                               return;
                           }
                           if (Session[vRoleName] != null && Request.QueryString["Support"] == null)
                           {
                               BtnNew.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass211;
                               BtnEdit.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass212;
                               BtnDelete.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass213;
                            //   BtnSearch.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass214;
                               BtnPrint.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass215;
                               BtnFind.Visible = (bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass214;
                           } */

                    //  lblBranch.Text = "/" + short.Parse(AreaNo).ToString();


                    /*       if (Request.QueryString["FNum"] != null)
                               {
                                   if (Request.QueryString["Flag"] != null)
                                   {
                                       if (Request.QueryString["Flag"].ToString() == "0")
                                       {
                                           if (Session[vRoleName] != null && Request.QueryString["Support"] == null && !(bool)((List<TblRoles>)(Session[vRoleName]))[1].Pass40)
                                           {
                                               BtnEdit.Visible = false;
                                               BtnDelete.Visible = false;
                                               BtnClear.Visible = false;
                                               ((HtmlGenericControl)this.Master.FindControl("menu")).Visible = false;
                                           }
                                       }
                                   }
                                   txtSearch.Text = Request.QueryString["FNum"].ToString();
                                   BtnSearch_Click(sender, null);
                               }
                               else
                               { */
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
                    Response.Redirect("GeneralServerError.aspx");
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }


        }

        protected void ddltype11_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppPrice myprice = new AppPrice();

    //        grdCodes.Columns.Clear();
            grdCodes.DataSource = null;
            grdCodes.DataBind();

            if (ddltype11.SelectedValue != "-1" && ddlcity.SelectedValue != "-1")
            {
                myprice.Branch = short.Parse(Session["Branch"].ToString());
                myprice.FType = 1;
                myprice.FType2 = short.Parse(ddltype11.SelectedValue);
                myprice.Code = ddlcity.SelectedValue;
                grdCodes.DataSource = myprice.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                grdCodes.DataBind();
            }
            else if (ddltype11.SelectedValue != "-1" && ddlcity.SelectedValue == "-1")
            {
                myprice.Branch = short.Parse(Session["Branch"].ToString());
                myprice.FType = 1;
                myprice.FType2 = short.Parse(ddltype11.SelectedValue);
                grdCodes.DataSource = myprice.GetAll1(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                grdCodes.DataBind();
            }
            else if (ddltype11.SelectedValue == "-1" && ddlcity.SelectedValue != "-1")
            {
                myprice.Branch = short.Parse(Session["Branch"].ToString());
                myprice.FType = 1;
                myprice.FType2 = short.Parse(ddltype11.SelectedValue);
                myprice.Code = ddlcity.SelectedValue;
                grdCodes.DataSource = myprice.GetAll3(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                grdCodes.DataBind();
            }

        }

        protected void ddlcity_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppPrice myprice = new AppPrice();

  //          grdCodes.Columns.Clear();
            grdCodes.DataSource = null;
            grdCodes.DataBind();

            if (ddltype11.SelectedValue != "-1" && ddlcity.SelectedValue != "-1")
            {
                myprice.Branch = short.Parse(Session["Branch"].ToString());
                myprice.FType = 1;
                myprice.FType2 = short.Parse(ddltype11.SelectedValue);
                myprice.Code = ddlcity.SelectedValue;
                grdCodes.DataSource = myprice.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                grdCodes.DataBind();
            }
            else if (ddltype11.SelectedValue != "-1" && ddlcity.SelectedValue == "-1")
            {
                myprice.Branch = short.Parse(Session["Branch"].ToString());
                myprice.FType = 1;
                myprice.FType2 = short.Parse(ddltype11.SelectedValue);
                grdCodes.DataSource = myprice.GetAll1(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                grdCodes.DataBind();
            }
            else if (ddltype11.SelectedValue == "-1" && ddlcity.SelectedValue != "-1")
            {
                myprice.Branch = short.Parse(Session["Branch"].ToString());
                myprice.FType = 1;
                myprice.Code = ddlcity.SelectedValue;
                grdCodes.DataSource = myprice.GetAll3(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                grdCodes.DataBind();
            }

        }


        protected void BtnNew_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid)
                {

                    /*   if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                       {
                           if (DateTime.Parse(txtGDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                           {
                               LblCodesResult.ForeColor = System.Drawing.Color.Red;
                               LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                               ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                               return;
                           }
                       } */

                    BtnNew.Enabled = true;

                    AppPrice myprice = new AppPrice();
                    
                    myprice.Branch = short.Parse(Session["Branch"].ToString());
                    myprice.FType = 1;
                    myprice.FType2 = short.Parse(ddltype11.SelectedValue);
                    myprice.Code = ddlcity.SelectedValue;

                    int? myid = myprice.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myid == 0 || myid == null)
                    {
                        myid = 1;
                    }
                    else
                    {
                        myid++;
                    }
                    txtNumber.Text = myid.ToString();

                    myprice = new AppPrice();
                    myprice.Branch = short.Parse(Session["Branch"].ToString());
                    myprice.FType = 1;
                    myprice.FType2 = short.Parse(ddltype11.SelectedValue);
                    myprice.Code = ddlcity.SelectedValue;
                    myprice.FType3 = short.Parse(txtNumber.Text);
                    myprice = myprice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    if (myprice != null)
                    {

                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "بطاقة التسعير موجودة مسبقا";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                        BtnNew.Enabled = true;
                        return;
                    }

                   

                    bool Add = false;
                    myprice = new AppPrice();
                    myprice.Branch = short.Parse(Session["Branch"].ToString());
                    myprice.FType = 1;
                    myprice.FType2 = short.Parse(ddltype11.SelectedValue);
                    myprice.Code = ddlcity.SelectedValue;
                    myprice.FType3 = short.Parse(txtNumber.Text);
                    myprice.Name1 = txtname.Text;
                    myprice.Name2 = "";
                    myprice.Price = double.Parse(txtprice.Text);
                    myprice.Cost = double.Parse(txtcost.Text); // edited by hanan3
                    myprice.SerPrice = double.Parse(txtprice2.Text); // edited by hanan3

                    Add = myprice.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    if (Add)
                    {

                        LblCodesResult.ForeColor = System.Drawing.Color.Green;
                        LblCodesResult.Text = "لقد تمت أضافة البيانات بنجاح";
                        BtnNew.Enabled = true;
                        BtnClear_Click(sender, e);
                    }
                    else
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "لقد حدث خطأ أثناء اضافة البيانات ... حاول مرة أخرى";
                        BtnNew.Enabled = true;

                    }
                }
            }
            catch (Exception ex)
            {
                BtnNew.Enabled = true;
                if (ConfigurationManager.AppSettings["ExitOnError"].ToString() == "1")
                {
                    Session.Add("Error", ex);
                    Response.Redirect("GeneralServerError.aspx");
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }


        protected void BtnEdit_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid)
                {

                    /*  if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                      {
                          if (DateTime.Parse(txtGDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                          {
                              LblCodesResult.ForeColor = System.Drawing.Color.Red;
                              LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                              ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                              return;
                          }
                      } */

                    AppPrice myprice = new AppPrice();
                    myprice.Branch = short.Parse(Session["Branch"].ToString());
                    myprice.FType = 1;
                    myprice.FType2 = short.Parse(ddltype11.SelectedValue);
                    myprice.Code = ddlcity.SelectedValue;
                    myprice.FType3 = short.Parse(txtNumber.Text);
                    myprice = myprice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myprice == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "بيانات التسعير غير معرفة من قبل";

                    }
                    else
                    {
                        myprice = new AppPrice();

                        bool upd = false;
                        myprice.Branch = short.Parse(Session["Branch"].ToString());
                        myprice.FType = 1;
                        myprice.FType2 = short.Parse(ddltype11.SelectedValue);
                        myprice.Code = ddlcity.SelectedValue;
                        myprice.FType3 = short.Parse(txtNumber.Text);
                        myprice.Name1 = txtname.Text;
                        myprice.Name2 = "";
                        myprice.Price = double.Parse(txtprice.Text);
                        myprice.Cost = double.Parse(txtcost.Text); // edited by hanan3
                        myprice.SerPrice = double.Parse(txtprice2.Text); // edited by hanan3

                        upd = myprice.update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        if (upd)
                        {

                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "تم تحديث البيانات بنجاح";
                            BtnNew.Enabled = true;
                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ أثناء التحديث ... حاول مرة أخرى";
                            BtnNew.Enabled = true;

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                if (ConfigurationManager.AppSettings["ExitOnError"].ToString() == "1")
                {
                    Session.Add("Error", ex);
                    Response.Redirect("GeneralServerError.aspx");
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }

        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                //  NewMode();

                txtSearch.Text = "";
                txtNumber.Text = "";
                DateTime localDate = DateTime.Now;
                txtname.Text = "";
                txtprice.Text = "0";
                txtcost.Text = "0"; // edited by hanan3
                txtprice2.Text = "0"; // edited by hanan3

                Cities mycity = new Cities();
                mycity.Branch = short.Parse(Session["Branch"].ToString());
               
                ddlcity.DataTextField = "Name1";
                ddlcity.DataValueField = "Code";
                ddlcity.DataSource = mycity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                ddlcity.DataBind();
                ddlcity.Items.Insert(0, new ListItem("-- أختر المدينة --", "-1", true));

                ddltype11.SelectedValue = "-1";

                grdCodes.DataSource = null;
                grdCodes.DataBind();

         /*       AppPrice myprice = new AppPrice();
                myprice.Branch = short.Parse(Session["Branch"].ToString());
                int? myid = myprice.GetNewCode(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myid == 0 || myid == null)
                {
                    myid = 1;
                }
                else
                {
                    myid++;
                }
                txtNumber.Text = myid.ToString(); */

            }
            catch (Exception ex)
            {
                // if (ConfigurationManager.AppSettings["ExitOnError"].ToString() == "1")
                // {
                //      Session.Add("Error", ex);
                //      Response.Redirect("GeneralServerError.aspx");
                //  }
                //  else
                //   {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
                //  }
            }

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid)
                {
                    /*  if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                      {
                          if (DateTime.Parse(txtGDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                          {
                              LblCodesResult.ForeColor = System.Drawing.Color.Red;
                              LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                              ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                              return;
                          }
                      } */

                    AppPrice myprice = new AppPrice();
                    myprice.Branch = short.Parse(Session["Branch"].ToString());
                    myprice.FType = 1;
                    myprice.FType2 = short.Parse(ddltype11.SelectedValue);
                    myprice.Code = ddlcity.SelectedValue;
                    myprice.FType3 = short.Parse(txtNumber.Text);
                    myprice = myprice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myprice == null)
                    {
                        LblCodesResult.ForeColor = System.Drawing.Color.Red;
                        LblCodesResult.Text = "بيانات التسعير غير معرفة من قبل";

                    }
                    else
                    {
                        myprice = new AppPrice();
                        myprice.Branch = short.Parse(Session["Branch"].ToString()); // edited by hanan4
                        myprice.FType = 1;
                        myprice.FType2 = short.Parse(ddltype11.SelectedValue);
                        myprice.Code = ddlcity.SelectedValue;
                        myprice.FType3 = short.Parse(txtNumber.Text);

                        if (myprice.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                           
                            LblCodesResult.ForeColor = System.Drawing.Color.Green;
                            LblCodesResult.Text = "لقد تم الغاء البيانات بنجاح";

                            BtnClear_Click(sender, e);
                        }
                        else
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد حدث خطأ أثناء الغاء البيانات ... حاول مرة أخرى";

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                if (ConfigurationManager.AppSettings["ExitOnError"].ToString() == "1")
                {
                    Session.Add("Error", ex);
                    Response.Redirect("GeneralServerError.aspx");
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }

        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void BtnPrint_Click(object sender, EventArgs e)
        {

        }

        public void PrintMe(String Number)
        {
            // if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان ترحيل", "طباعة", "طباعة بيان الترحيل رقم " + int.Parse(AreaNo).ToString() + "/" + Number, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=1&AreaNo=" + AreaNo + "&Number=" + Number + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
            return;
        }

        protected void BtnFind_Click(object sender, EventArgs e)
        {
            AppPrice myprice = new AppPrice();
            myprice.Branch = short.Parse(Session["Branch"].ToString());
            myprice.FType = 1;
            myprice.FType2 = short.Parse(ddltype11.SelectedValue);
            myprice.Code = ddlcity.SelectedValue;
            myprice.FType3 = short.Parse(txtSearch.Text);
            myprice = myprice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myprice == null)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = "بيانات التسعير غير معرفة من قبل";
            }
            else
            {

                //     if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "بيان ترحيل", "عرض", "عرض بيان الترحيل رقم " + lblBranch.Text + "/" + txtNumber.Text, "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                //     EditMode();

                txtNumber.Text = myprice.FType3.ToString();
                txtname.Text = myprice.Name1;
                txtprice.Text = myprice.Price.ToString();
                txtcost.Text = myprice.Cost.ToString(); // edited by hanan3
                txtprice2.Text = myprice.SerPrice.ToString(); // edited by hanan3
                ddltype11.SelectedValue = myprice.FType2.ToString();
                ddlcity.SelectedValue = myprice.Code;

            }
       
        }


    }
}