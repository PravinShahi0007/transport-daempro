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
    public partial class WebFixAssetPro : System.Web.UI.Page
    {
        public string Tot
        {
            get
            {
                if (ViewState["Tot"] == null)
                {
                    ViewState["Tot"] = "0.00";
                }
                return ViewState["Tot"].ToString();
            }
            set { ViewState["Tot"] = value; }
        }
        public string AreaNo
        {
            get
            {
                if (ViewState["AreaNo"] == null)
                {
                    ViewState["AreaNo"] = "00000";
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

        public short LocNumber
        {
            get
            {
                if (ViewState["LocNumber"] == null)
                {
                    ViewState["LocNumber"] = 1;
                }
                return short.Parse(ViewState["LocNumber"].ToString());
            }
            set { ViewState["LocNumber"] = value; }
        }
        public short LocType
        {
            get
            {
                if (ViewState["LocType"] == null)
                {
                    ViewState["LocType"] = 1;
                }
                return short.Parse(ViewState["LocType"].ToString());
            }
            set { ViewState["LocType"] = value; }
        }
        public List<FixCalc> fx 
        {
            get
            {
                if (ViewState["fx"] == null)
                {
                    ViewState["fx"] = new List<FixCalc>();
                }
                return (List<FixCalc>)ViewState["fx"];
            }
            set
            {
                ViewState["fx"] = value;
            }
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

                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                {
                    Transactions UserTran = new Transactions();
                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                    UserTran.UserName = Session["CurrentUser"].ToString();
                    UserTran.FormName = "الرئيسية";
                    UserTran.FormAction = "اختيار";
                    UserTran.Description = "تشغيل قيود الاهلاك";
                    UserTran.IP = IPNetworking.GetIP4Address();
                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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


        protected void BtnProcess_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    string vStartDate = "01/06/2017"; // "01/01/2014"
                    if (!string.IsNullOrEmpty(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                    {
                        if (DateTime.Parse(txtFDate.Text) <= DateTime.Parse(((HiddenField)this.Master.FindControl("ClosedPeriod")).Value))
                        {
                            LblCodesResult.ForeColor = System.Drawing.Color.Red;
                            LblCodesResult.Text = "لقد تم اغلاق الفترة حتى تاريخ " + ((HiddenField)this.Master.FindControl("ClosedPeriod")).Value;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, true, (bool)Session["Modal"]), true);
                            return;
                        }
                    }

                    if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                    {
                        Transactions UserTran = new Transactions();
                        UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                        UserTran.UserName = Session["CurrentUser"].ToString();
                        UserTran.FormName = "تشغيل قيود الاهلاك";
                        UserTran.FormAction = "عرض";
                        UserTran.Description = "عرض اهلاكات الاصول الثابتة خلال الفترة من " + txtFDate.Text + " إلى " + txtEDate.Text;
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }
                    fx.Clear();
                    int fxi = -1;
                    List<Acc> AllAssets = new List<Acc>();
                    Acc myAcc = new Acc();
                    if (Cache["AllACC" + Session["CNN2"].ToString()] == null) Cache.Insert("AllACC" + Session["CNN2"].ToString(), myAcc.Getall(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    AllAssets = (from itm in (List<Acc>)(Cache["AllACC" + Session["CNN2"].ToString()])
                                 where itm.FType == "1" && itm.SType == "1" && itm.FLevel == 5 && itm.DepPer > 0 && !string.IsNullOrEmpty(itm.DepCode) && !string.IsNullOrEmpty(itm.ACDep)                                 
                                 select itm).ToList();

                    List<AccValue> lValue = new List<AccValue>();
                    AccValue myValue = new AccValue();
                    myValue.FDate = vStartDate;
                    lValue = myValue.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    foreach (Acc itm in AllAssets)
                    {
                        itm.ODAcc = 0;
                        itm.OCAcc = 0;
                        itm.DepAmount = 0;
                        foreach (AccValue sitm in lValue)
                        {
                            if (sitm.Code == itm.Code)
                            {
                                itm.ODAcc = sitm.odacc;
                                itm.OCAcc = sitm.ocacc;
                                itm.DepAmount = sitm.Depamount;
                                break;
                            }
                        }
                    }


                    foreach (Acc itm in AllAssets)
                    {
                        Jv myJv = new Jv();
                        myJv.InvNo = itm.Code;
                        myJv.DbCode = "";
                        myJv.CrCode = itm.DepCode;
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        double? s = myJv.SumofInvNo(vStartDate,txtEDate.Text,WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);                        
                        double bal = (double)(itm.ODAcc - itm.OCAcc);
                        double bal2 = (double)(itm.ODAcc - itm.OCAcc - itm.DepAmount - (s!=null ? s : 0));

                        DateTime vDate = DateTime.Parse(txtFDate.Text);
                        DateTime tDate = DateTime.Parse(DateTime.DaysInMonth(DateTime.Parse(txtFDate.Text).Year, DateTime.Parse(txtFDate.Text).Month).ToString() + "/" + DateTime.Parse(txtFDate.Text).Month.ToString() + "/" + DateTime.Parse(txtFDate.Text).Year.ToString());
                        DateTime vDate2 = DateTime.Parse(txtEDate.Text);
                        bool vSet = false;

                        if (bal2 > 1)
                        {
                            if (bal2 > 1 && DateTime.Parse(txtFDate.Text) == DateTime.Parse(vStartDate).AddDays(-1))   // تاريخ بداية السنة المالية
                            {
                                fx.Add(new FixCalc
                                {
                                    Code = itm.Code,
                                    ACDep = itm.ACDep,
                                    DepCode = itm.DepCode,
                                    FDate = vDate,
                                    TDate = tDate,
                                    Amount = bal,
                                    Per = (double)itm.DepPer,
                                    Area = itm.Area,
                                    CarNo = itm.CarNo,
                                    CostAcc = itm.CostAcc,
                                    CostCenter = itm.CostCenter,
                                    EmpCode = itm.EmpCode,
                                    Project = itm.Project,
                                    Net = bal2
                                });
                                fxi++;
                                bal2 = fx[fxi].Net2;
                                if (bal2 < 0) bal2 = 0.01;
                            }
                        }

                        foreach (vJv Jvitm in myJv.GetStatement0(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, false, txtFDate.Text, txtEDate.Text, itm.Code, "-1", "-1", "-1", "-1", "-1", "-1","-1"))
                        {
                            if (tDate >= DateTime.Parse(Jvitm.FDate))
                            {
                                if (vDate > DateTime.Parse(Jvitm.FDate))
                                {
                                    if (Jvitm.CrAmount > 0 && Jvitm.CrAmount >= bal2)
                                    {
                                        if (DateTime.Parse(Jvitm.FDate).AddDays(-1) >= DateTime.Parse(txtFDate.Text))
                                        {
                                            vSet = true;
                                            if (!CheckDep(short.Parse(Session["Branch"].ToString()), 100, LocType, LocNumber, String.Format("{0:dd/MM/yyyy}", DateTime.Parse(Jvitm.FDate).AddDays(-1)), itm.Code))
                                            {                                                
                                                fx.Add(new FixCalc
                                                {
                                                    Code = itm.Code,
                                                    ACDep = itm.ACDep,
                                                    DepCode = itm.DepCode,
                                                    FDate = DateTime.Parse("01/" + DateTime.Parse(Jvitm.FDate).Month.ToString() + "/" + DateTime.Parse(Jvitm.FDate).Year.ToString()),
                                                    TDate = DateTime.Parse(Jvitm.FDate).AddDays(-1),
                                                    Amount = bal,
                                                    Per = (double)itm.DepPer,
                                                    Area = itm.Area,
                                                    CarNo = itm.CarNo,
                                                    CostAcc = itm.CostAcc,
                                                    CostCenter = itm.CostCenter,
                                                    EmpCode = itm.EmpCode,
                                                    Project = itm.Project,
                                                    Net = bal2
                                                });
                                                fxi++;
                                            }
                                        }
                                        bal2 = 0;
                                        //bal = 0;
                                        //break;
                                    }
                                    else
                                    {
                                        bal += (Jvitm.DbAmount - Jvitm.CrAmount);
                                        bal2 += (Jvitm.DbAmount - Jvitm.CrAmount);
                                    }
                                }
                                else
                                {
                                    if (Jvitm.CrAmount > 0 && Jvitm.CrAmount >= bal2)
                                    {
                                        if (DateTime.Parse(Jvitm.FDate).AddDays(-1) >= DateTime.Parse(txtFDate.Text))
                                        {
                                            vSet = true;
                                            if (!CheckDep(short.Parse(Session["Branch"].ToString()), 100, LocType, LocNumber, String.Format("{0:dd/MM/yyyy}", DateTime.Parse(Jvitm.FDate).AddDays(-1)), itm.Code))
                                            {                                                
                                                fx.Add(new FixCalc
                                                {
                                                    Code = itm.Code,
                                                    ACDep = itm.ACDep,
                                                    DepCode = itm.DepCode,
                                                    FDate = DateTime.Parse("01/" + DateTime.Parse(Jvitm.FDate).Month.ToString() + "/" + DateTime.Parse(Jvitm.FDate).Year.ToString()),
                                                    TDate = DateTime.Parse(Jvitm.FDate).AddDays(-1),
                                                    Amount = bal,
                                                    Per = (double)itm.DepPer,
                                                    Area = itm.Area,
                                                    CarNo = itm.CarNo,
                                                    CostAcc = itm.CostAcc,
                                                    CostCenter = itm.CostCenter,
                                                    EmpCode = itm.EmpCode,
                                                    Project = itm.Project,
                                                    Net = bal2
                                                });
                                                fxi++;
                                            }
                                        }
                                        bal2 = 0;
                                        //bal = 0;
                                        //break;
                                    }
                                    else
                                    {
                                        vSet = true;
                                        if (!CheckDep(short.Parse(Session["Branch"].ToString()), 100, LocType, LocNumber, String.Format("{0:dd/MM/yyyy}", tDate), itm.Code))
                                        {
                                            if (tDate == DateTime.Parse(Jvitm.FDate))
                                            {
                                                fx.Add(new FixCalc
                                                {
                                                    Code = itm.Code,
                                                    ACDep = itm.ACDep,
                                                    DepCode = itm.DepCode,
                                                    FDate = vDate,
                                                    TDate = tDate,
                                                    Amount = moh.GetBal(itm.Code, String.Format("{0:dd/MM/yyyy}", vDate.AddDays(-1)), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString),   // bal,
                                                    Per = (double)itm.DepPer,
                                                    Area = itm.Area,
                                                    CarNo = itm.CarNo,
                                                    CostAcc = itm.CostAcc,
                                                    CostCenter = itm.CostCenter,
                                                    EmpCode = itm.EmpCode,
                                                    Project = itm.Project,
                                                    Net = bal2
                                                });
                                                fxi++;
                                                bal2 = fx[fxi].Net2;
                                                if (bal2 < 0) bal2 = 0.01;
                                            }

                                            bal2 += (Jvitm.DbAmount - Jvitm.CrAmount);                                            
                                            fx.Add(new FixCalc
                                            {
                                                Code = itm.Code,
                                                ACDep = itm.ACDep,
                                                DepCode = itm.DepCode,
                                                FDate = DateTime.Parse(Jvitm.FDate),
                                                TDate = tDate,
                                                Amount = (Jvitm.DbAmount - Jvitm.CrAmount),
                                                Per = (double)itm.DepPer,
                                                Area = itm.Area,
                                                CarNo = itm.CarNo,
                                                CostAcc = itm.CostAcc,
                                                CostCenter = itm.CostCenter,
                                                EmpCode = itm.EmpCode,
                                                Project = itm.Project,
                                                Net = bal2
                                            });
                                            bal += (Jvitm.DbAmount - Jvitm.CrAmount);
                                            fxi++;
                                            bal2 = fx[fxi].Net2;
                                            if (bal2 < 0) bal2 = 0.01;
                                        }
                                        if (bal2 < 1)
                                        {
                                            bal2 = 0; //break;
                                          //  bal = 0;
                                        }
                                    }
                                }
                            }
                            else 
                            {
                                while (tDate < DateTime.Parse(Jvitm.FDate) && tDate < vDate2)
                                {
                                    tDate = tDate.AddDays(1);
                                    tDate = DateTime.Parse(DateTime.DaysInMonth(tDate.Year, tDate.Month) + "/" + tDate.Month.ToString() + "/" + tDate.Year.ToString());
                                    vDate = DateTime.Parse("01/" + tDate.Month.ToString() + "/" + tDate.Year.ToString());
                                    if (tDate > vDate2) break;

                                    if (tDate >= DateTime.Parse(Jvitm.FDate))
                                    {
                                        if (Jvitm.CrAmount >= bal2 && Jvitm.CrAmount > 0)
                                        {
                                            if (DateTime.Parse(Jvitm.FDate).AddDays(-1) >= DateTime.Parse(txtFDate.Text))
                                            {
                                                vSet = true;
                                                if (!CheckDep(short.Parse(Session["Branch"].ToString()), 100, LocType, LocNumber, String.Format("{0:dd/MM/yyyy}", DateTime.Parse(Jvitm.FDate).AddDays(-1)), itm.Code))
                                                {                                                    
                                                    fx.Add(new FixCalc
                                                    {
                                                        Code = itm.Code,
                                                        ACDep = itm.ACDep,
                                                        DepCode = itm.DepCode,
                                                        FDate = vDate,
                                                        TDate = DateTime.Parse(Jvitm.FDate).AddDays(-1),
                                                        Amount = bal,
                                                        Per = (double)itm.DepPer,
                                                        Area = itm.Area,
                                                        CarNo = itm.CarNo,
                                                        CostAcc = itm.CostAcc,
                                                        CostCenter = itm.CostCenter,
                                                        EmpCode = itm.EmpCode,
                                                        Project = itm.Project,
                                                        Net = bal2
                                                    });
                                                    fxi++;
                                                }
                                            }
                                            bal2 = 0;
                                            //bal = 0;
                                            break;
                                        }
                                    }
                                    else if (bal2>1)
                                    {
                                        vSet = true;
                                        if (!CheckDep(short.Parse(Session["Branch"].ToString()), 100, LocType, LocNumber, String.Format("{0:dd/MM/yyyy}", tDate), itm.Code))
                                        {
                                            fx.Add(new FixCalc
                                            {
                                                Code = itm.Code,
                                                ACDep = itm.ACDep,
                                                DepCode = itm.DepCode,
                                                FDate = vDate,
                                                TDate = tDate,
                                                Amount = bal,
                                                Per = (double)itm.DepPer,
                                                Area = itm.Area,
                                                CarNo = itm.CarNo,
                                                CostAcc = itm.CostAcc,
                                                CostCenter = itm.CostCenter,
                                                EmpCode = itm.EmpCode,
                                                Project = itm.Project,
                                                Net = bal2
                                            });
                                            fxi++;
                                            bal2 = fx[fxi].Net2;
                                        }
                                        if (bal2 <= 1)
                                        {
                                            //bal = 0;
                                            bal2 = 0;
                                            //break;
                                        }
                                    }
                                    if (tDate == DateTime.Parse(Jvitm.FDate))
                                    {
                                        vSet = true;
                                        if (!CheckDep(short.Parse(Session["Branch"].ToString()), 100, LocType, LocNumber, String.Format("{0:dd/MM/yyyy}", tDate), itm.Code))
                                        {
                                            fx.Add(new FixCalc
                                            {
                                                Code = itm.Code,
                                                ACDep = itm.ACDep,
                                                DepCode = itm.DepCode,
                                                FDate = vDate,
                                                TDate = tDate,
                                                Amount = moh.GetBal(itm.Code, String.Format("{0:dd/MM/yyyy}", vDate.AddDays(-1)), WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString), // bal,
                                                Per = (double)itm.DepPer,
                                                Area = itm.Area,
                                                CarNo = itm.CarNo,
                                                CostAcc = itm.CostAcc,
                                                CostCenter = itm.CostCenter,
                                                EmpCode = itm.EmpCode,
                                                Project = itm.Project,
                                                Net = bal2
                                            });
                                            fxi++;
                                            bal2 = fx[fxi].Net2;
                                            if (bal2 < 0) bal2 = 0.01;

                                            bal2 += (Jvitm.DbAmount - Jvitm.CrAmount);
                                            fx.Add(new FixCalc
                                            {
                                                Code = itm.Code,
                                                ACDep = itm.ACDep,
                                                DepCode = itm.DepCode,
                                                FDate = DateTime.Parse(Jvitm.FDate),
                                                TDate = tDate,
                                                Amount = (Jvitm.DbAmount - Jvitm.CrAmount),
                                                Per = (double)itm.DepPer,
                                                Area = itm.Area,
                                                CarNo = itm.CarNo,
                                                CostAcc = itm.CostAcc,
                                                CostCenter = itm.CostCenter,
                                                EmpCode = itm.EmpCode,
                                                Project = itm.Project,
                                                Net = bal2
                                            });
                                            bal += (Jvitm.DbAmount - Jvitm.CrAmount);
                                            fxi++;
                                            bal2 = fx[fxi].Net2;
                                        }
                                        if (bal2 <= 1)
                                        {
                                            bal2 = 0;
                                            //bal = 0;
                                            break;
                                        }
                                    }
                                    else if (tDate > DateTime.Parse(Jvitm.FDate))
                                    {
                                        vSet = true;
                                        if (!CheckDep(short.Parse(Session["Branch"].ToString()), 100, LocType, LocNumber, String.Format("{0:dd/MM/yyyy}", tDate), itm.Code))
                                        {
                                            bal2 += (Jvitm.DbAmount - Jvitm.CrAmount);
                                            fx.Add(new FixCalc
                                            {
                                                Code = itm.Code,
                                                ACDep = itm.ACDep,
                                                DepCode = itm.DepCode,
                                                FDate = DateTime.Parse(Jvitm.FDate),
                                                TDate = tDate,
                                                Amount = (Jvitm.DbAmount - Jvitm.CrAmount),
                                                Per = (double)itm.DepPer,
                                                Area = itm.Area,
                                                CarNo = itm.CarNo,
                                                CostAcc = itm.CostAcc,
                                                CostCenter = itm.CostCenter,
                                                EmpCode = itm.EmpCode,
                                                Project = itm.Project,
                                                Net = bal2
                                            });
                                            bal += (Jvitm.DbAmount - Jvitm.CrAmount);
                                            fxi++;
                                            bal2 = fx[fxi].Net2;
                                        }
                                        if (bal2 <= 1)
                                        {
                                            bal2 = 0;
                                            //bal = 0;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        if (bal2 > 0)
                        {
                            while (tDate < vDate2)
                            {
                                if (vSet)
                                {
                                    tDate = tDate.AddDays(1);
                                    tDate = DateTime.Parse(DateTime.DaysInMonth(tDate.Year, tDate.Month) + "/" + tDate.Month.ToString() + "/" + tDate.Year.ToString());
                                    vDate = DateTime.Parse("01/" + tDate.Month.ToString() + "/" + tDate.Year.ToString());
                                }
                                if (tDate > vDate2) break;
                                vSet = true;
                                if (!CheckDep(short.Parse(Session["Branch"].ToString()), 100, LocType, LocNumber, String.Format("{0:dd/MM/yyyy}", tDate), itm.Code))
                                {                                    
                                    fx.Add(new FixCalc
                                    {
                                        Code = itm.Code,
                                        ACDep = itm.ACDep,
                                        DepCode = itm.DepCode,
                                        FDate = vDate,
                                        TDate = tDate,
                                        Amount = bal,
                                        Per = (double)itm.DepPer,
                                        Area = itm.Area,
                                        CarNo = itm.CarNo,
                                        CostAcc = itm.CostAcc,
                                        CostCenter = itm.CostCenter,
                                        EmpCode = itm.EmpCode,
                                        Project = itm.Project,
                                        Net = bal2
                                    });
                                    fxi++;
                                    bal2 = fx[fxi].Net2;
                                }
                                if (bal2 <= 1)
                                {
                                    bal2 = 0;
                                    //bal = 0;
                                    break;
                                }
                            }
                        }
                    }
                    this.grdCodes.DataSource = fx;
                    this.grdCodes.DataBind();
                    if (fx.Count() > 0)
                    {
                        BtnPost.Visible = true;
                        Tot = string.Format("{0:N2}", (fx.Sum(itm => itm.Total2)));
                        Label lblTot = grdCodes.FooterRow.FindControl("lblTot") as Label;
                        lblTot.Text = Tot;
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

        public bool CheckDep(short bran,short FType,short LocType,short LocNumber,string FDate,string DbCode)
        {
            Jv myJv = new Jv();
            myJv.Branch = bran;
            myJv.FType = FType;
            myJv.LocType = LocType;
            myJv.LocNumber = LocNumber;
            myJv.FDate = FDate;
            myJv.DbCode = DbCode;
            myJv = myJv.findbyDep(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            return (myJv != null);
        }

        protected void BtnPost_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                // get New Jv Number
                Jv myJv = new Jv();
                int? vFNo = 1;
                int? i = 0;
                int vStart = int.Parse(txtStart.Text) - 1;
                string vDate = "";
                foreach (FixCalc sitm in (from itm in fx
                                          orderby itm.TDate
                                          select itm).ToList())
                {
                    if (Math.Round(sitm.Total2, 2) > 0)
                    {                 
                        if (vDate != String.Format("{0:dd/MM/yyyy}", sitm.TDate))
                        {
                            vFNo = 1;
                            myJv = new Jv();
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.FType = 100;
                            myJv.LocType = LocType;
                            myJv.LocNumber = LocNumber;
                            myJv.Number = vStart++;
                            i = myJv.Number;
                            while( myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).Count>0 )
                            {                                
                                myJv.Number = vStart++;
                                i = myJv.Number;
                            }                            
                            //if (i == 0 || i == null)
                            //{
                            //    i = 1;
                            //}
                            //else
                            //{
                            //    i++;
                            //}
                            //myJv.Number = (int)i;
                            vDate = String.Format("{0:dd/MM/yyyy}", sitm.TDate);
                        }

                        myJv.FDate = vDate;
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.FType = 100;
                        myJv.LocType = LocType;
                        myJv.LocNumber = LocNumber;
                        myJv.Post = 1;
                        myJv.CostCenter = sitm.CostCenter;
                        myJv.Project = sitm.Project;
                        myJv.CarNo = sitm.CarNo;
                        myJv.Area = sitm.Area;
                        myJv.CostAcc = sitm.CostAcc;
                        myJv.EmpCode = sitm.EmpCode;
                        myJv.Remark = "تنفيذ قيد الاهلاك حتى " + myJv.FDate;
                        myJv.InvNo = "";
                        myJv.DbCode = sitm.ACDep;
                        myJv.CrCode = "";
                        myJv.Amount = Math.Round(sitm.Total2, 2);
                        myJv.UserName = Session["CurrentUser"].ToString(); // "Admin";
                        myJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        myJv.FNo = (short)vFNo++;
                        myJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);


                        myJv = new Jv();
                        myJv.Number = (int)i;
                        myJv.FDate = vDate;
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.FType = 100;
                        myJv.LocType = LocType;
                        myJv.LocNumber = LocNumber;
                        myJv.Post = 1;
                        myJv.CostCenter = "-1";
                        myJv.Project = "-1";
                        myJv.CarNo = sitm.CarNo;
                        myJv.Area = "-1";
                        myJv.CostAcc = "-1";
                        myJv.EmpCode = "-1";
                        myJv.Remark = "تنفيذ قيد الاهلاك حتى " + myJv.FDate;
                        myJv.InvNo = sitm.Code;
                        myJv.DbCode = "";
                        myJv.CrCode = sitm.DepCode;
                        myJv.Amount = Math.Round(sitm.Total2, 2);
                        myJv.UserName = Session["CurrentUser"].ToString(); // "Admin";
                        myJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        myJv.FNo = (short)vFNo++;
                        myJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    }
                    else if (Math.Round(sitm.Total2, 2) < 0 && sitm.Amount < 0)
                    {
                        if (vDate != String.Format("{0:dd/MM/yyyy}", sitm.TDate))
                        {
                            vFNo = 1;
                            myJv = new Jv();
                            myJv.Branch = short.Parse(Session["Branch"].ToString());
                            myJv.FType = 100;
                            myJv.LocType = LocType;
                            myJv.LocNumber = LocNumber;
                            myJv.Number = vStart++;
                            i = myJv.Number;
                            while (myJv.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString).Count > 0)
                            {
                                myJv.Number = vStart++;
                                i = myJv.Number;
                            }                            


                            //i = myJv.GetNewNumber(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            //if (i == 0 || i == null)
                            //{
                            //    i = 1;
                            //}
                            //else
                            //{
                            //    i++;
                            //}
                            //myJv.Number = (int)i;
                            vDate = String.Format("{0:dd/MM/yyyy}", sitm.TDate);
                        }

                        myJv.FDate = vDate;
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.FType = 100;
                        myJv.LocType = LocType;
                        myJv.LocNumber = LocNumber;
                        myJv.Post = 1;
                        myJv.CostCenter = "-1";
                        myJv.Project = "-1";
                        myJv.CarNo = sitm.CarNo;
                        myJv.Area = "-1";
                        myJv.CostAcc = "-1";
                        myJv.EmpCode = "-1";
                        myJv.Remark = "تنفيذ قيد الاهلاك حتى " + myJv.FDate;
                        myJv.InvNo = sitm.Code;
                        myJv.CrCode = "";
                        myJv.DbCode = sitm.DepCode;
                        myJv.Amount = Math.Round(sitm.Total2, 2) * -1;
                        myJv.UserName = Session["CurrentUser"].ToString(); // "Admin";
                        myJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        myJv.FNo = (short)vFNo++;
                        myJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        myJv = new Jv();
                        myJv.Number = (int)i;
                        myJv.FDate = vDate;
                        myJv.Branch = short.Parse(Session["Branch"].ToString());
                        myJv.FType = 100;
                        myJv.LocType = LocType;
                        myJv.LocNumber = LocNumber;
                        myJv.Post = 1;
                        myJv.CostCenter = sitm.CostCenter;
                        myJv.Project = sitm.Project;
                        myJv.CarNo = sitm.CarNo;
                        myJv.Area = sitm.Area;
                        myJv.CostAcc = sitm.CostAcc;
                        myJv.EmpCode = sitm.EmpCode;
                        myJv.Remark = "تنفيذ قيد الاهلاك حتى " + myJv.FDate;
                        myJv.InvNo = "";
                        myJv.CrCode = sitm.ACDep;
                        myJv.DbCode = "";
                        myJv.Amount = Math.Round(sitm.Total2, 2) * -1;
                        myJv.UserName = Session["CurrentUser"].ToString(); // "Admin";
                        myJv.UserDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                        myJv.FNo = (short)vFNo++;
                        myJv.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                    }
                 
                }

                this.grdCodes.DataSource = null;
                this.grdCodes.DataBind();
                BtnPost.Visible = false;

                LblCodesResult.ForeColor = System.Drawing.Color.Green;
                LblCodesResult.Text = "لقد تم ترحيل قيد الاهلاك بنجاح";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(LblCodesResult.Text, false, (bool)Session["Modal"]), true);

                if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1")
                {
                    Transactions UserTran = new Transactions();
                    UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
                    UserTran.UserName = Session["CurrentUser"].ToString();
                    UserTran.FormName = "تشغيل قيود الاهلاك";
                    UserTran.FormAction = "ترحيل";
                    UserTran.Description = "ترحيل قيد اهلاكات الاصول الثابتة خلال الفترة من " + txtFDate.Text + " إلى " + txtEDate.Text;
                    UserTran.IP = IPNetworking.GetIP4Address();
                    UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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
    }
}