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
    public partial class WebCarMoveLines : System.Web.UI.Page
    {
        public string TotalKM
        {
            get
            {
                if (ViewState["TotalKM"] == null)
                {
                    ViewState["TotalKM"] = "0.00";
                }
                return ViewState["TotalKM"].ToString();
            }
            set { ViewState["TotalKM"] = value; }
        }
        public string TotalCost
        {
            get
            {
                if (ViewState["TotalCost"] == null)
                {
                    ViewState["TotalCost"] = "0.00";
                }
                return ViewState["TotalCost"].ToString();
            }
            set { ViewState["TotalCost"] = value; }
        }

        public double CostAmount
        {
            get
            {
                if (ViewState["CostAmount"] == null)
                {
                    ViewState["CostAmount"] = "0.00";
                }
                return moh.StrToDouble(ViewState["CostAmount"].ToString());
            }
            set { ViewState["CostAmount"] = value; }            
        }

        public double KM
        {
            get
            {
                if (ViewState["KM"] == null)
                {
                    ViewState["KM"] = "0.00";
                }
                return moh.StrToDouble(ViewState["KM"].ToString());
            }
            set { ViewState["KM"] = value; }
        }

        public List<Lines> MyOver
        {
            get
            {
                if (ViewState["MyOver"] == null)
                {
                    ViewState["MyOver"] = new List<Lines>();
                }
                return (List<Lines>)ViewState["MyOver"];
            }
            set { ViewState["MyOver"] = value; }
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
                    this.Page.Header.Title = "خط سير الرحلة";
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

                    Cities myCity = new Cities();
                    myCity.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    ddlTo.DataTextField = "Name1";
                    ddlTo.DataValueField = "Code";
                    ddlFrom.DataTextField = "Name1";
                    ddlFrom.DataValueField = "Code";
                    ddlTo.DataSource = (from itm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                        orderby itm.Name1
                                        select itm).ToList();
                    ddlFrom.DataSource = ddlTo.DataSource;

                    ddlTo.DataBind();
                    ddlFrom.DataBind();

                    if (Request.QueryString["FNo"] != null && Request.QueryString["From"] != null && Request.QueryString["To"] != null)
                    {
                        ddlTo.SelectedValue = Request.QueryString["To"].ToString();
                        ddlFrom.SelectedValue = Request.QueryString["From"].ToString();


                        CarPrices myPrice = new CarPrices();
                        myPrice.Branch = short.Parse(Session["Branch"].ToString());
                        myPrice.MonthNo = 0;
                        myPrice.FromCode = this.ddlFrom.SelectedValue;
                        myPrice.toCode = this.ddlTo.SelectedValue;
                        myPrice.PLevel = "00002";
                        myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (myPrice != null)
                        {
                            KM = (double)myPrice.KMeter;
                            //CostAmount = (double)myPrice.CostAmount;
                            CostAmount = Math.Round((double)(moh.doTripCost(Request.QueryString["FDate"].ToString()) * KM),0);                            

                            if (Request.QueryString["Driver"] != null)
                            {
                                Drivers myDrive = new Drivers();
                                myDrive.Branch = short.Parse(Session["Branch"].ToString());
                                if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                myDrive.Code = Request.QueryString["Driver"].ToString();
                                myDrive = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                                           where sitm.Code == myDrive.Code
                                           select sitm).FirstOrDefault();
                                if (myDrive != null)
                                {
                                    if ((bool)myDrive.Ajir)
                                    {
                                        CostAmount = Math.Round((double)(myDrive.Cost * KM),0);
                                    }
                                }
                            }
                        }

                        Lines myLine = new Lines();
                        myLine.FromCity = ddlFrom.SelectedValue;
                        myLine.ToCity = ddlTo.SelectedValue;
                        MyOver = myLine.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                       CarMoveLines mylines = new CarMoveLines();
                       mylines.Branch = short.Parse(Session["Branch"].ToString());
                       mylines.VouLoc = moh.MakeMask(Request.QueryString["FNo"].ToString().Split('/')[1], 5);
                       mylines.Number = int.Parse(Request.QueryString["FNo"].ToString().Split('/')[0]);
                       foreach(CarMoveLines itm in mylines.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                       {
                          for (int i = 0; i < MyOver.Count(); i++)
                          {
                              if (MyOver[i].FNo == itm.LineFNo && MyOver[i].FromCity == itm.FromLoc)
                              {
                                  MyOver[i].Status = true;
                                  MyOver[i].KM = itm.KM;
                                  MyOver[i].Cost = itm.Cost;
                              }
                          }
                       }
                       DisplayData();
                    }
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
                    Response.Redirect("GeneralServerError.aspx", false);
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }

        private void DisplayData()
        {
            try
            {
                grdCodes.DataSource = MyOver;
                grdCodes.DataBind();
                if (grdCodes.FooterRow != null)
                {
                    Label lblTotalKM = grdCodes.FooterRow.FindControl("lblTotalKM") as Label;
                    Label lblTotalCost = grdCodes.FooterRow.FindControl("lblTotalCost") as Label;
                    double vKM = KM;
                    double vCost = CostAmount;

                    for (int i = 0; i < MyOver.Count(); i++)
                    {
                        if ((bool)MyOver[i].Status)
                        {
                            if (MyOver[i].FromCity == "-1")
                            {
                                if (MyOver[i].Area2.Contains('+'))
                                {
                                    vKM += (double)MyOver[i].KM;
                                    vCost += (double)MyOver[i].Cost;
                                }
                                else
                                {
                                    vKM -= (double)MyOver[i].KM;
                                    vCost -= (double)MyOver[i].Cost;
                                }
                            }
                            else
                            {
                                vKM += (double)MyOver[i].KM;
                                vCost += (double)MyOver[i].Cost;
                            }                                
                        }
                    }

                    if (lblTotalKM != null)
                    {
                       lblTotalKM.Text = string.Format("{0:N2}", vKM);
                       TotalKM = lblTotalKM.Text;
                    }

                    if (lblTotalCost != null)
                    {
                       lblTotalCost.Text = string.Format("{0:N2}", vCost);
                       TotalCost = lblTotalCost.Text;
                    }
                }

                int r = 0;
                foreach (GridViewRow R in grdCodes.Rows)
                {
                    if (MyOver[r].FromCity != "-1")
                    {
                        TextBox txtKM = R.FindControl("txtKM") as TextBox;
                        TextBox txtCost = R.FindControl("txtCost") as TextBox;
                        if (txtKM != null && txtCost != null)
                        {
                            txtKM.ReadOnly = true;
                            txtCost.ReadOnly = true;
                        }
                    }
                    r++;
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationManager.AppSettings["ExitOnError"].ToString() == "1")
                {
                    Session.Add("Error", ex);
                    Response.Redirect("GeneralServerError.aspx", false);
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }

        protected void ChkStatus_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ChkStatus = sender as CheckBox;
            GridViewRow gvr = ChkStatus.NamingContainer as GridViewRow;
            string FNo = gvr.RowIndex.ToString();
            MyOver[int.Parse(FNo)].Status = ChkStatus.Checked;
            DisplayData();                     
        }

        protected void txtKM_TextChanged(object sender, EventArgs e)
        {
            TextBox txtKM = sender as TextBox;
            GridViewRow gvr = txtKM.NamingContainer as GridViewRow;
            string FNo = gvr.RowIndex.ToString();
            if (txtKM.Text.Trim() == "") txtKM.Text = "0";
            MyOver[int.Parse(FNo)].KM = int.Parse(txtKM.Text);
            DisplayData();                     
        }

        protected void txtCost_TextChanged(object sender, EventArgs e)
        {
            TextBox txtCost = sender as TextBox;
            GridViewRow gvr = txtCost.NamingContainer as GridViewRow;
            string FNo = gvr.RowIndex.ToString();
            if (txtCost.Text.Trim() == "") txtCost.Text = "0";
            MyOver[int.Parse(FNo)].Cost = moh.StrToDouble(txtCost.Text);
            DisplayData();                     
        }

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    double CostAmount = 0;
                    CarPrices myPrice = new CarPrices();
                    myPrice.Branch = short.Parse(Session["Branch"].ToString());
                    myPrice.MonthNo = 0;
                    myPrice.FromCode = this.ddlFrom.SelectedValue;
                    myPrice.toCode = this.ddlTo.SelectedValue;
                    myPrice.PLevel = "00002";
                    myPrice = myPrice.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (myPrice != null)
                    {
                        //CostAmount = (double)myPrice.CostAmount;
                        CostAmount = Math.Round((double)(moh.doTripCost(Request.QueryString["FDate"].ToString()) * KM),0);
                        if (Request.QueryString["Driver"] != null)
                        {
                            Drivers myDrive = new Drivers();
                            myDrive.Branch = short.Parse(Session["Branch"].ToString());
                            if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                            myDrive.Code = Request.QueryString["Driver"].ToString();
                            myDrive = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                                       where sitm.Code == myDrive.Code
                                       select sitm).FirstOrDefault();
                            if (myDrive != null)
                            {
                                if ((bool)myDrive.Ajir)
                                {
                                    CostAmount = Math.Round((double)(myDrive.Cost * KM),0);
                                }
                            }
                        }
                    }

                    CarMoveLines mylines = new CarMoveLines();
                    mylines.Branch = short.Parse(Session["Branch"].ToString());
                    mylines.VouLoc = moh.MakeMask(Request.QueryString["FNo"].ToString().Split('/')[1], 5);
                    mylines.Number = int.Parse(Request.QueryString["FNo"].ToString().Split('/')[0]);
                    mylines = mylines.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (mylines != null)
                    {
                        mylines.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    for (int i = 0; i < MyOver.Count(); i++)
                    {
                        if((bool)MyOver[i].Status)
                        {
                            mylines = new CarMoveLines();
                            mylines.Branch = short.Parse(Session["Branch"].ToString());
                            mylines.VouLoc = moh.MakeMask(Request.QueryString["FNo"].ToString().Split('/')[1], 5);
                            mylines.Number = int.Parse(Request.QueryString["FNo"].ToString().Split('/')[0]);
                            mylines.Cost = MyOver[i].Cost;
                            mylines.KM = MyOver[i].KM;
                            mylines.FromLoc = MyOver[i].FromCity;
                            mylines.ToLoc = MyOver[i].ToCity;
                            mylines.FNo = (short)(i + 1);
                            mylines.LineFNo = MyOver[i].FNo;
                            mylines.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                            if (mylines.FromLoc == "-1" && mylines.LineFNo != 1) CostAmount -= (double)mylines.Cost;
                            else CostAmount += (double)mylines.Cost;
                        }
                    }

                    CarMove myInv = new CarMove();
                    myInv.Branch = short.Parse(Session["Branch"].ToString());
                    myInv.VouLoc = moh.MakeMask(Request.QueryString["FNo"].ToString().Split('/')[1], 5);
                    myInv.Number = int.Parse(Request.QueryString["FNo"].ToString().Split('/')[0]);
                    myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).FirstOrDefault();
                    if (myInv != null)
                    {
                        if (CostAmount != 0)
                        {
                            Jv myJv = new Jv();
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.FType = 104;
                            myJv.LocType = 2;
                            myJv.LocNumber = short.Parse(myInv.VouLoc);
                            myJv.Number = myInv.Number;
                            if (myJv.Delete(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                CostCenter mySiteInfo = new CostCenter();
                                mySiteInfo.Branch = 1;
                                if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), mySiteInfo.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                                mySiteInfo.Code = myInv.VouLoc;
                                mySiteInfo = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                              where citm.Code == mySiteInfo.Code
                                              select citm).FirstOrDefault();
                                if (mySiteInfo != null) myInv.Post(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, CostAmount, mySiteInfo.DezelAcc, mySiteInfo.TripAcc, mySiteInfo.CurExpAcc, mySiteInfo.Project, mySiteInfo.Area, "00002",0);
                            }
                        }
                    }

                    LblCodesResult.ForeColor = System.Drawing.Color.Green;
                    LblCodesResult.Text = "لقد تم تعديل البيانات بنجاح";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "window.close();", true);
                    //DisplayData();
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationManager.AppSettings["ExitOnError"].ToString() == "1")
                {
                    Session.Add("Error", ex);
                    Response.Redirect("GeneralServerError.aspx", false);
                }
                else
                {
                    LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    LblCodesResult.Text = ex.Message.ToString();
                }
            }
        }
    }
}