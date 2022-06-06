using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using System.Configuration;
using BLL;
using System.Web.Configuration;

namespace ACC
{
    public partial class WebInquiry : System.Web.UI.Page
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
                    this.Page.Header.Title = "الاستعلام";
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
                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), "الرئيسية", "اختيار", "تم اختيار شاشة الاستعلام", "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                }
            }
            catch
            {
            }
        }


        protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtSearch.Text != "")
                {
                    List<CarStatus> myStatus = new List<CarStatus>();
                    if (ddlFType.SelectedIndex == 0)
                    {
                        Invoice vInv = new Invoice();
                        vInv.RecMobileNo = txtSearch.Text;
                        foreach (Invoice mInv in vInv.GetByRecMobileNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (mInv != null) GetDetails(short.Parse(mInv.VouLoc).ToString() + "/" + mInv.VouNo.ToString(), myStatus,0,"","");
                        }
                    }
                    else if (ddlFType.SelectedIndex == 1)
                    {
                        Invoice vInv = new Invoice();
                        vInv.MobileNo = txtSearch.Text;
                        foreach (Invoice mInv in vInv.GetByMobileNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (mInv != null) GetDetails(short.Parse(mInv.VouLoc).ToString() + "/" + mInv.VouNo.ToString(), myStatus,0,"","");
                        }
                    }
                    else if (ddlFType.SelectedIndex == 2)
                    {
                        Invoice vInv = new Invoice();
                        vInv.IDNo = txtSearch.Text;
                        foreach (Invoice mInv in vInv.GetByIDNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (mInv != null) GetDetails(short.Parse(mInv.VouLoc).ToString() + "/" + mInv.VouNo.ToString(), myStatus,0,"","");
                        }
                    }
                    else if (ddlFType.SelectedIndex == 3)
                    {
                        GetDetails(txtSearch.Text, myStatus,0,"","");
                    }
                    else if (ddlFType.SelectedIndex == 4)
                    {
                        InvDetails sinv = new InvDetails();
                        sinv.Branch = 1;
                        sinv.PlateNo = txtSearch.Text;
                        foreach (InvDetails myDetails in sinv.GetByPlateNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (myDetails != null) GetDetails(short.Parse(myDetails.VouLoc).ToString() + "/" + myDetails.VouNo.ToString(), myStatus, 1, sinv.PlateNo, "");
                        }
                    }
                    else if (ddlFType.SelectedIndex == 5)
                    {
                        InvDetails sinv = new InvDetails();
                        sinv.Branch = 1;
                        sinv.ChassisNo = txtSearch.Text;
                        foreach (InvDetails myDetails in sinv.GetByChassisNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (myDetails != null) GetDetails(short.Parse(myDetails.VouLoc).ToString() + "/" + myDetails.VouNo.ToString(), myStatus, 2, "", sinv.ChassisNo);
                        }
                    }
                    else if (ddlFType.SelectedIndex == 6)
                    {
                        Invoice vInv = new Invoice();
                        vInv.Name = txtSearch.Text;
                        foreach (Invoice mInv in vInv.GetByName(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (mInv != null) GetDetails(short.Parse(mInv.VouLoc).ToString() + "/" + mInv.VouNo.ToString(), myStatus,0,"","");
                        }
                    }
                    else if (ddlFType.SelectedIndex == 7)
                    {
                        Invoice vInv = new Invoice();
                        vInv.RecName = txtSearch.Text;
                        foreach (Invoice mInv in vInv.GetByRecName(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            if (mInv != null) GetDetails(short.Parse(mInv.VouLoc).ToString() + "/" + mInv.VouNo.ToString(), myStatus,0,"","");
                        }
                    }
                    grdCodes.DataSource = myStatus.OrderByDescending(p => DateTime.Parse(p.TranDate));
                    grdCodes.DataBind();
                }
            }
            catch (Exception ex)
            {
                LblCodesResult.ForeColor = System.Drawing.Color.Red;
                LblCodesResult.Text = ex.Message.ToString();
            }
        }

        public void GetDetails(string InvNo, List<CarStatus> myStatus,short option , string PlateNo , string ChassisNo)
        {
            Invoice myInv = new Invoice();
            myInv.Branch = 1;
            if (InvNo.Split('/').Count() > 1)
            {
                myInv.VouLoc = moh.MakeMask(InvNo.Split('/')[0], 5);
                myInv.VouNo = int.Parse(InvNo.Split('/')[1]);
            }
            else
            {
                myInv.VouLoc = AreaNo;
                myInv.VouNo = int.Parse(InvNo);
            }
            myInv = myInv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myInv != null)
            {
                if (RdoPeriod.SelectedValue != "0")
                    if (DateTime.Parse(myInv.GDate) < moh.Nows().AddDays(double.Parse(RdoPeriod.SelectedValue) * -1)) return;

                CostCenter myCost = new CostCenter();
                myCost.Branch = 1;
                if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCost.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myCost.Code = myInv.VouLoc2;
                myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                          where citm.Code == myCost.Code
                          select citm).FirstOrDefault();

                Cities myCity = new Cities();
                myCity.Branch = 1;
                myCity.Code = string.IsNullOrEmpty(myInv.PlaceofLoading) ? myInv.FromName : myInv.PlaceofLoading;
                if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                myCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                          where sitm.Code == myCity.Code
                          select sitm).FirstOrDefault();

                Cities myCity2 = new Cities();
                myCity2.Branch = 1;
                myCity2.Code = string.IsNullOrEmpty(myInv.Destination) ? myInv.ToName : myInv.Destination;
                myCity2 = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                          where sitm.Code == myCity2.Code
                          select sitm).FirstOrDefault();

                InvDetails sinv = new InvDetails();
                sinv.Branch = myInv.Branch;
                sinv.VouLoc = myInv.VouLoc;
                sinv.VouNo = myInv.VouNo;
                foreach (InvDetails itm in sinv.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    if (option == 0 || (option == 1 && itm.PlateNo == PlateNo) || (option == 2 && itm.ChassisNo == ChassisNo))
                    {
                        myStatus.Add(new CarStatus
                        {
                            ChassisNo = itm.ChassisNo,
                            DocNumber = @"<a target='_blank' href='WebInvoice.aspx?Support=1&FNum=" + itm.VouNo.ToString() + "&AreaNo=" + itm.VouLoc + "&StoreNo=" + StoreNo + "&Flag=0'>فاتورة " + int.Parse(itm.VouLoc).ToString() + "/" + itm.VouNo.ToString() + @"</a>",
                            PlateNo = itm.PlateNo,
                            TranDate = myInv.RDate,
                            Area = myCity.Name1 + " - " + myCost.Name1,
                            Remark = "تم الحجز بتاريخ " + myInv.RDate
                        });


                        myStatus.Add(new CarStatus
                        {
                            ChassisNo = itm.ChassisNo,
                            DocNumber = @"<a target='_blank' href='WebInvoice.aspx?Support=1&FNum=" + itm.VouNo.ToString() + "&AreaNo=" + itm.VouLoc + "&StoreNo=" + StoreNo + "&Flag=0'>فاتورة " + int.Parse(itm.VouLoc).ToString() + "/" + itm.VouNo.ToString() + @"</a>",
                            PlateNo = itm.PlateNo,
                            TranDate = myInv.GDate + " " + myInv.FTime,
                            Area = myCity.Name1 + " - " + myCost.Name1,
                            Remark = "تم الاستلام من العميل " + myInv.Name + Environment.NewLine + " - جهة الوصول " + myCity2.Name1
                        });

                        if ((bool)itm.FClosed)
                        {
                            myStatus.Add(new CarStatus
                            {
                                ChassisNo = itm.ChassisNo,
                                DocNumber = @"<a target='_blank' href='WebInvoice.aspx?Support=1&FNum=" + itm.VouNo.ToString() + "&AreaNo=" + itm.VouLoc + "&StoreNo=" + StoreNo + "&Flag=0'>فاتورة " + int.Parse(itm.VouLoc).ToString() + "/" + itm.VouNo.ToString() + @"</a>",
                                PlateNo = itm.PlateNo,
                                TranDate = itm.ClosedDateTime,
                                Area = myCity.Name1 + " - " + myCost.Name1,
                                Remark = "تم أغلاق الفاتورة من قبل  " + itm.ClosedUser + Environment.NewLine + " - بتاريخ " + itm.ClosedDateTime
                            });
                        }
                    }

                    CarMove vCarMove = new CarMove();
                    vCarMove.Branch = 1;
                    vCarMove.InvoiceNo = itm.VouNo;
                    vCarMove.InvoiceVouLoc = itm.VouLoc;
                    vCarMove.InvoiceFNo = itm.FNo;
                    foreach (CarMove CarMoveitm in vCarMove.GetByInv(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                    {
                        Cities FromCity = new Cities();
                        FromCity.Branch = 1;
                        FromCity.Code = CarMoveitm.FromLoc;
                        FromCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                  where sitm.Code == FromCity.Code
                                  select sitm).FirstOrDefault();


                        Cities ToCity = new Cities();
                        ToCity.Branch = 1;
                        ToCity.Code = CarMoveitm.ToLoc;
                        ToCity = (from sitm in (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()])
                                  where sitm.Code == ToCity.Code
                                  select sitm).FirstOrDefault();

                        Drivers myDrive = new Drivers();
                        myDrive.Branch = 1;
                        if (Cache["Drivers" + Session["CNN2"].ToString()] == null) Cache.Insert("Drivers" + Session["CNN2"].ToString(), myDrive.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myDrive.Code = CarMoveitm.DriverCode;
                        myDrive = (from sitm in (List<Drivers>)(Cache["Drivers" + Session["CNN2"].ToString()])
                                   where sitm.Code == myDrive.Code
                                select sitm).FirstOrDefault();

                        Cars myCar = new Cars();
                        myCar.Branch = 1;
                        if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCar.Code = CarMoveitm.CarCode;
                        myCar = (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                 where sitm.Code == myCar.Code
                                 select sitm).FirstOrDefault();

                        CostCenter CarMoveArea = new CostCenter();
                        CarMoveArea.Branch = 1;
                        CarMoveArea.Code = CarMoveitm.VouLoc;
                        CarMoveArea = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                       where citm.Code == CarMoveArea.Code
                                       select citm).FirstOrDefault();

                        if (option == 0 || (option == 1 && itm.PlateNo == PlateNo) || (option == 2 && itm.ChassisNo == ChassisNo))
                        myStatus.Add(new CarStatus
                        {
                            ChassisNo = itm.ChassisNo,
                            DocNumber = @"<a target='_blank' href='WebCarMove.aspx?Support=1&FNum=" + CarMoveitm.Number.ToString() + "&AreaNo=" + CarMoveitm.VouLoc + "&StoreNo=" + StoreNo + "&Flag=0'>بيان ترحيل " + short.Parse(CarMoveitm.VouLoc).ToString() + "/" + CarMoveitm.Number.ToString() + @"</a>",
                            PlateNo = itm.PlateNo,
                            TranDate = CarMoveitm.GDate + " " + CarMoveitm.FTime,
                            Area = FromCity.Name1 + " - " + CarMoveArea.Name1,
                            Remark = (myDrive == null ? (CarMoveitm.RentDriver != null ? "تم تسليم السائق " + CarMoveitm.RentDriver + " على شاحنة مستأجرة " + CarMoveitm.RentPlateNo + " - جهة الوصول " + ToCity.Name1 : "")
                            : "تم تسليم السائق " +  myDrive.Name1 + " على الشاحنة " + myCar.PlateNo + " - جهة الوصول " + ToCity.Name1)
                        });

                        CarMoveRCV vCarMoveRCV = new CarMoveRCV();
                        vCarMoveRCV.Branch = 1;
                        vCarMoveRCV.CarMove = short.Parse(CarMoveitm.VouLoc).ToString() + "/" + CarMoveitm.Number.ToString();
                        vCarMoveRCV = vCarMoveRCV.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (vCarMoveRCV != null)
                        {
                            CostCenter CarMoveRCVArea = new CostCenter();
                            CarMoveRCVArea.Branch = 1;
                            CarMoveRCVArea.Code = moh.MakeMask(vCarMoveRCV.LocNumber.ToString(), 5);
                            CarMoveRCVArea = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                              where citm.Code == CarMoveRCVArea.Code
                                              select citm).FirstOrDefault();

                            if (option == 0 || (option == 1 && itm.PlateNo == PlateNo) || (option == 2 && itm.ChassisNo == ChassisNo))
                            myStatus.Add(new CarStatus
                            {
                                ChassisNo = itm.ChassisNo,
                                DocNumber = @"<a target='_blank' href='WebCarMoveRCV.aspx?Support=1&FNum=" + vCarMoveRCV.Number.ToString() + "&AreaNo=" + moh.MakeMask(vCarMoveRCV.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&Flag=0'>بيان الوصول " + vCarMoveRCV.LocNumber.ToString() + "/" + vCarMoveRCV.Number.ToString() + @"</a>",
                                PlateNo = itm.PlateNo,
                                TranDate = vCarMoveRCV.GDate + " " + vCarMoveRCV.FTime,
                                Area = CarMoveRCVArea.Name1,
                                Remark = CarMoveitm.ToLoc != myInv.Destination ? "تم الوصول الى محطة الترانزيت" : "تم الوصول"
                            });
                        }
                    }
                    CarRcv vCarRcv = new CarRcv();
                    vCarRcv.Branch = 1;
                    vCarRcv.InvNo = int.Parse(itm.VouLoc).ToString() + "/" + itm.VouNo;
                    vCarRcv.InvFNo = itm.FNo;
                    vCarRcv = vCarRcv.GetByInvFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (vCarRcv != null)
                    {
                        CostCenter CarRcvArea = new CostCenter();
                        CarRcvArea.Branch = 1;
                        CarRcvArea.Code = moh.MakeMask(vCarRcv.LocNumber.ToString(), 5);
                        CarRcvArea = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                      where citm.Code == CarRcvArea.Code
                                      select citm).FirstOrDefault();

                        if (option == 0 || (option == 1 && itm.PlateNo == PlateNo) || (option == 2 && itm.ChassisNo == ChassisNo))
                        myStatus.Add(new CarStatus
                        {
                            ChassisNo = itm.ChassisNo,
                            DocNumber = @"<a target='_blank' href='WebCarRCV.aspx?Support=1&FNum=" + vCarRcv.Number.ToString() + "&AreaNo=" + moh.MakeMask(vCarRcv.LocNumber.ToString(), 5) + "&StoreNo=" + StoreNo + "&Flag=0'> بيان تسليم " + vCarRcv.LocNumber.ToString() + "/" + vCarRcv.Number.ToString() + @"</a>",
                            PlateNo = itm.PlateNo,
                            TranDate = vCarRcv.GDate + " " + vCarRcv.GTime,
                            Area = CarRcvArea.Name1,
                            Remark = "تم تسليم العميل " + vCarRcv.Customer
                        });
                    }
                }
            }
        }

        protected void RdoPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void ddlFType_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            grdCodes.DataSource = null;
            grdCodes.DataBind();
        }
    }
}