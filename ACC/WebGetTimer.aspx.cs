using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace ACC
{
    
    public partial class WebGetTimer : System.Web.UI.Page
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

        // public zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();
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
                ScriptManager.GetCurrent(this).RegisterPostBackControl(btnImportFromFile);
                if (!Page.IsPostBack)
                {
                    this.Page.Header.Title = "استيراد بيانات الحضور والانصراف";

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
                        UserTran.Description = "اختيار الحضور و الانصراف";
                        UserTran.IP = IPNetworking.GetIP4Address();
                        UserTran.Add(WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
                    }

                    Timers myTime = new Timers();
                    rdoTimers.DataValueField = "Code";
                    rdoTimers.DataTextField = "Name1";
                    rdoTimers.DataSource = myTime.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    rdoTimers.DataBind();

                    if (rdoTimers.Items.Count > 0) rdoTimers.Items[0].Selected = true;
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
                    //LblCodesResult.ForeColor = System.Drawing.Color.Red;
                    //LblCodesResult.Text = ex.Message.ToString();
                }
            }

        }

        protected void btnConnect_Click(object sender, EventArgs e)
        {
            //bool bIsConnected = false;//the boolean value identifies whether the device is connected
            //int iMachineNumber = 1;//the serial number of the device.After connecting the device ,this value will be changed.

            //if (txtIP.Text.Trim() == "" || txtPort.Text.Trim() == "")
            //{
            //    lblError.Text = "IP and Port cannot be null";
            //    return;
            //}
            //int idwErrorCode = 0;

            //if (btnConnect.Text == "DisConnect")
            //{
            //    axCZKEM1.Disconnect();
            //    bIsConnected = false;
            //    btnConnect.Text = "Connect";
            //    return;
            //}

            //bIsConnected = axCZKEM1.Connect_Net(txtIP.Text, Convert.ToInt32(txtPort.Text));
            //if (bIsConnected == true)
            //{
            //    btnConnect.Text = "DisConnect";
            //    iMachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
            //    axCZKEM1.RegEvent(iMachineNumber, 65535);//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            //}
            //else
            //{
            //    axCZKEM1.GetLastError(ref idwErrorCode);
            //    lblError.Text = "Unable to connect the device,ErrorCode=" + idwErrorCode.ToString();
            //}
        }

        protected void Button2_Click(object sender, EventArgs e) // No. of Record
        {
            /*
            bool bIsConnected = false;//the boolean value identifies whether the device is connected
            int iMachineNumber = 1;//the serial number of the device.After connecting the device ,this value will be changed.

            int iSelected = -1;
            for(int i = 0 ; i < rdoTimers.Items.Count ; i++)
            {
                if(rdoTimers.Items[i].Selected)
                {
                    iSelected = int.Parse(rdoTimers.Items[i].Value);
                    break;
                }
            }

            if(iSelected == -1)
            {
                lblError.Text = "يجب أختيار الساعة";
                return;            
            }

            Timers myTime = new Timers();
            myTime.Code = iSelected;
            myTime = myTime.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myTime == null)
            {
                lblError.Text = "يجب أختيار الساعة";
                return;            
            }

            int idwErrorCode = 0;

            if (btnConnect.Text == "DisConnect")
            {
                axCZKEM1.Disconnect();
                bIsConnected = false;
                btnConnect.Text = "Connect";
                // return;
            }

            bIsConnected = axCZKEM1.Connect_Net(myTime.WANTCPIP, Convert.ToInt32(myTime.WANPort));
            if (bIsConnected == true)
            {
                btnConnect.Text = "DisConnect";
                iMachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
                axCZKEM1.RegEvent(iMachineNumber, 65535);//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                lblError.Text = "Unable to connect the device,ErrorCode=" + idwErrorCode.ToString();
            }

            if (btnConnect.Text != "DisConnect")
            {
                lblError.Text = "Please connect the device first";
                return;
            }
            int iValue = 0;

            axCZKEM1.EnableDevice(iMachineNumber, false);//disable the device
            if (axCZKEM1.GetDeviceStatus(iMachineNumber, 6, ref iValue)) //Here we use the function "GetDeviceStatus" to get the record's count.The parameter "Status" is 6.
            {
                lblError.Text = "أجمالي عدد السجلات   " + iValue.ToString();
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                lblError.Text = "Operation failed,ErrorCode=" + idwErrorCode.ToString();
            }
            axCZKEM1.EnableDevice(iMachineNumber, true);//enable the device

            if (btnConnect.Text == "DisConnect")
            {
                axCZKEM1.Disconnect();
                bIsConnected = false;
                btnConnect.Text = "Connect";
                return;
            }
             */
        }

        protected void Button1_Click(object sender, EventArgs e)  // Import
        {
            /*
            bool bIsConnected = false;//the boolean value identifies whether the device is connected
            int iMachineNumber = 1;//the serial number of the device.After connecting the device ,this value will be changed.

            int iSelected = -1;
            for (int i = 0; i < rdoTimers.Items.Count; i++)
            {
                if (rdoTimers.Items[i].Selected)
                {
                    iSelected = int.Parse(rdoTimers.Items[i].Value);
                    break;
                }
            }

            if (iSelected == -1)
            {
                lblError.Text = "يجب أختيار الساعة";
                return;
            }

            Timers myTime = new Timers();
            myTime.Code = iSelected;
            myTime = myTime.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (myTime == null)
            {
                lblError.Text = "يجب أختيار الساعة";
                return;
            }

            int idwErrorCode = 0;
            if (btnConnect.Text == "DisConnect")
            {
                axCZKEM1.Disconnect();
                bIsConnected = false;
                btnConnect.Text = "Connect";
                return;
            }

            bIsConnected = axCZKEM1.Connect_Net(myTime.WANTCPIP, Convert.ToInt32(myTime.WANPort));
            if (bIsConnected == true)
            {
                btnConnect.Text = "DisConnect";
                iMachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
                axCZKEM1.RegEvent(iMachineNumber, 65535);//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                lblError.Text = "Unable to connect the device,ErrorCode=" + idwErrorCode.ToString();
                return;
            }

            string sdwEnrollNumber = "";
            //int idwTMachineNumber = 0;
            //int idwEMachineNumber = 0;
            int idwVerifyMode = 0;
            int idwInOutMode = 0;
            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;
            int idwWorkcode = 0;

            int iGLCount = 0;
            int iIndex = 0;
            AttLog mytime = new AttLog();
            AttLog mytime2 = new AttLog();

            //lvLogs.Items.Clear();
            axCZKEM1.EnableDevice(iMachineNumber, false);//disable the device

            MyConfig mySetting = new MyConfig();
            mySetting.Branch = short.Parse(Session["Branch"].ToString());
            mySetting = mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            if (mySetting == null) return;
            string ImagePath = mySetting.ImagePath;

            string FileName = ImagePath + "data1.dat";
            FileName = @"c:\1\data1.dat";
            axCZKEM1.GetDataFile(iMachineNumber, 1, FileName);  // here
            string myString = "";

            List<string> ms = new List<string>();
            char s = ' ';
            ms.Add("1");
            ms.Add("1");
            using (StreamReader sr = new StreamReader(FileName))
            {
                while (sr.Peek() >= 0)
                {
                    s = (char)sr.Read();
                    if (s >= '0' && s <= '9') myString += s;
                    else if (myString.Trim() != "")
                    {
                        if(myString.Length > 3 ) ms.Add(myString);
                        myString = "";
                    }
                }
            }
             


            if (axCZKEM1.ReadGeneralLogData(iMachineNumber))//read all the attendance records to the memory
            {
                
                while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
                           out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
                {

                    string checkEmp;
                    string checkDate;

                    iGLCount++;

                    if (moh.MakeMask(idwYear.ToString(), 4) != moh.Nows().Year.ToString()) continue;
                    //if (idwMonth != 11) continue;

                    if (sdwEnrollNumber.Trim() == "")
                    {
                       // if (iGLCount > ms.Count) continue;

                        sdwEnrollNumber = ms[iGLCount - 1];
                        // continue;
                        if (sdwEnrollNumber.ToString().Equals("2044"))
                        {
                            checkEmp = "2042";
                            sdwEnrollNumber = checkEmp;
                        }
                    }
                        
                    if (sdwEnrollNumber.ToString().Equals("1"))
                    {
                        checkEmp = "2044";
                    }
                    else if (sdwEnrollNumber.ToString().Equals("20"))
                    {
                        checkEmp = "2003";
                    }
                    else if (sdwEnrollNumber.ToString().Equals("2"))
                    {
                        checkEmp = "1001";
                    }
                    else if (sdwEnrollNumber.ToString().Equals("21"))
                    {
                        checkEmp = "2006";
                    }
                    else if (sdwEnrollNumber.ToString().Equals("22") || sdwEnrollNumber.ToString().Equals("2023"))
                    {
                        checkEmp = "2009";
                    }
                    else if (sdwEnrollNumber.ToString().Equals("23"))
                    {
                        checkEmp = "2011";
                    }
                    else if (sdwEnrollNumber.ToString().Equals("1006"))
                    {
                        checkEmp = "2001";
                    }
                    else if (sdwEnrollNumber.ToString().Equals("2025"))
                    {
                        checkEmp = "2052";
                    }
                    else
                        checkEmp = sdwEnrollNumber.ToString();

                    // if (idwYear == 2016 && idwMonth == 7 && idwDay > 23 && idwDay < 29) idwMonth = 8;

                    mytime.EmpCode = int.Parse(checkEmp); // int.Parse(sdwEnrollNumber.ToString()); //modify by Darcy on Nov.26 2009
                    checkDate = moh.MakeMask(idwYear.ToString(),4) + "/" + moh.MakeMask(idwMonth.ToString(),2) + "/" + moh.MakeMask(idwDay.ToString(),2);
                    mytime.FDate = moh.MakeMask(idwYear.ToString(),4) + "/" + moh.MakeMask(idwMonth.ToString(),2) + "/" + moh.MakeMask(idwDay.ToString(),2);
                    string vsTime = moh.MakeMask(idwHour.ToString(),2) + ":" + moh.MakeMask(idwMinute.ToString(),2) + ":" + moh.MakeMask(idwSecond.ToString(),2);
                    DateTime mypDate = DateTime.Parse(moh.MakeMask(idwDay.ToString(), 2) + "/" + moh.MakeMask(idwMonth.ToString(), 2) + "/" + moh.MakeMask(idwYear.ToString(), 4)).AddDays(-1);
                    mytime2 = mytime.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                    if (mytime2 != null)
                    {
                        if (checkEmp == mytime2.EmpCode.ToString() && checkDate == mytime2.FDate && mytime2.STime != vsTime && mytime2.ETime != vsTime)
                        {
                            mytime2.ETime = vsTime;
                            mytime2.Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                    }
                    else
                    {
                        
                        if (ChkAMTime(mytime, vsTime, moh.MakeMask(mypDate.Year.ToString(), 4) + "/" + moh.MakeMask(mypDate.Month.ToString(), 2) + "/" + moh.MakeMask(mypDate.Day.ToString(), 2)))
                        {
                            mytime.FDate = moh.MakeMask(mypDate.Year.ToString(), 4) + "/" + moh.MakeMask(mypDate.Month.ToString(), 2) + "/" + moh.MakeMask(mypDate.Day.ToString(), 2);
                            mytime2 = mytime.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            mytime2.ETime = vsTime;
                            mytime2.Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        }
                        else
                        {
                            SEmp myEmp = new SEmp();
                            myEmp.EmpCode = mytime.EmpCode;
                            myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);                           
                            mytime.Shift = (myEmp != null ? myEmp.Shift : -1);
                            mytime.STime = vsTime;
                            iIndex++;
                            if (mytime.insert(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                            {
                                lblResult.Text = " تم اضافة البيانات بنجاح ";
                            }

                            else
                            {
                                lblResult.Text = "لقد حدث خطأ اثناء إرسال البيانات";
                            }
                        }

                    } //end else

                } //end while
                DisplayGridData();
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);

                if (idwErrorCode != 0)
                {
                    lblError.Text = "Reading data from terminal failed,ErrorCode: " + idwErrorCode.ToString();
                }
                else
                {
                    lblError.Text = "No data from terminal returns!";
                }
            }
            axCZKEM1.EnableDevice(iMachineNumber, true);//enable the device
            if (btnConnect.Text == "DisConnect")
            {
                axCZKEM1.Disconnect();
                bIsConnected = false;
                btnConnect.Text = "Connect";
                return;
            }
             */
        }

        public bool ChkAMTime(AttLog myatt, string vTime ,string pDate)
        {
            bool vResult = false;
            if (DateTime.Parse(vTime) < DateTime.Parse("05:00"))
            {
                myatt.FDate = pDate;
                myatt = myatt.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                if (myatt != null)
                {
                    vResult = true;
                }
            }
            return vResult;
        }


        public void DisplayGridData()
        {
            AttLog mytime = new AttLog();
            GridView1.DataSource = (from itm in mytime.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                                    where itm.FDate == String.Format("{0:dd/MM/yyyy}", moh.Nows())
                                    select itm).ToList();

            GridView1.DataBind();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            /*
            bool bIsConnected = false;//the boolean value identifies whether the device is connected
            int iMachineNumber = 1;//the serial number of the device.After connecting the device ,this value will be changed.


            if (bIsConnected == false)
            {
                lblError.Text = "Please connect the device first";
                return;
            }
            int idwErrorCode = 0;

            //lvLogs.Items.Clear();
            axCZKEM1.EnableDevice(iMachineNumber, false);//disable the device
            if (axCZKEM1.ClearGLog(iMachineNumber))
            {
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                lblError.Text = "All att Logs have been cleared from teiminal!";
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                lblError.Text = "Operation failed,ErrorCode=" + idwErrorCode.ToString();
            }
            axCZKEM1.EnableDevice(iMachineNumber, true);//enable the device
             */
        }

        
        protected void btnImportFromFile_Click(object sender, EventArgs e)
        {
            if (Fp1.HasFile)
            {
               MyConfig mySetting = new MyConfig();
               mySetting.Branch = short.Parse(Session["Branch"].ToString());
               if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
               mySetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
               if (mySetting != null)
               {
                   string fileExt = System.IO.Path.GetExtension(Fp1.FileName);
                   String FileName = Config.GetImageName(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + fileExt;
                   Fp1.SaveAs(mySetting.ImagePath + FileName);
                   AttLog mytime = new AttLog();
                   AttLog mytime2 = new AttLog();
                   string vFilename = mySetting.ImagePath + FileName;
                   using (StreamReader sr = new StreamReader(vFilename))     //(@"C:\1\000.dat"))
                   {
                       while (sr.Peek() >= 0)
                       {
                           string[] sm = sr.ReadLine().Split('\t');
                           if (sm.Count() > 1)
                           {
                               mytime.EmpCode = int.Parse(sm[0]);
                               if (mytime.EmpCode == 2024) mytime.EmpCode = 2062;

                               SEmp myEmp = new SEmp();
                               myEmp.EmpCode = mytime.EmpCode;
                               myEmp = myEmp.find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                               mytime.Shift = (myEmp != null ? myEmp.Shift : -1);

                               if (mytime.EmpCode == 1) continue;
                               mytime.FDate = sm[1].Split(' ')[0].Replace('-', '/');
                               string vsTime = sm[1].Split(' ')[1];
                               mytime2 = mytime.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                               if (mytime2 != null)
                               {
                                   if (mytime2.STime != vsTime && mytime2.ETime != vsTime)
                                   {
                                       mytime2.ETime = vsTime;
                                       mytime2.Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                   }
                               }
                               else
                               {
                                   if (DateTime.Parse(vsTime) < DateTime.Parse("04:30"))
                                   {
                                       string voldDate  = mytime.FDate;
                                       mytime.FDate = DateTime.Parse(mytime.FDate).AddDays(-1).ToString("yyyy/MM/dd");
                                       mytime2 = new AttLog();
                                       mytime2 = mytime.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                       if (mytime2 != null)
                                       {
                                           if (mytime2.STime != vsTime)
                                           {
                                               mytime2.ETime = vsTime;
                                               mytime2.Update(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                                           }
                                       }
                                       else
                                       {
                                           mytime.FDate = voldDate;
                                           mytime.STime = vsTime;
                                           if (mytime.insert(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                           {
                                               lblResult.Text = " تم اضافة البيانات بنجاح ";
                                           }
                                           else
                                           {
                                               lblResult.Text = "لقد حدث خطأ اثناء إرسال البيانات";
                                           }
                                       }
                                   }
                                   else
                                   {
                                       mytime.STime = vsTime;
                                       if (mytime.insert(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                                       {
                                           lblResult.Text = " تم اضافة البيانات بنجاح ";
                                       }
                                       else
                                       {
                                           lblResult.Text = "لقد حدث خطأ اثناء إرسال البيانات";
                                       }
                                   }
                               }
                           }
                       }
                       DisplayGridData();
                   }
               }
            }
        }   

    }
}