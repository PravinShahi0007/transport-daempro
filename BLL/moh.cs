using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Net.Mail;
using System.Net;
using System.Globalization;
using System.IO;

namespace BLL
{   
    [Serializable]
    public static class moh
    {
        public static string GoogleAPI = "AIzaSyBiZRfD5bZzvAJccC4ZWge89JW6qdlBL9s";   //"AIzaSyAir8XGSzZBDOZKSqASUy1-MxTZAlMj57g";
        //AIzaSyA1Gw3ykb4lPagVRLUgPpKU94cDSrGvGKU
        public static string MadaAcc = "120101009"; 
        public static bool PrintDateofPrint = false; 
        public static string[] DaysToString = { "", "يوم", "يومان", "ثلاثة أيام", "اربعة أيام", "خمسة أيام", "ستة أيام", "سبعة أيام"
                                        , "ثمانية أيام", "تسعة ايام", "عشرة أيام", "أحدى عشر يوم", "أثنى عشر يوم", "ثلاثة عشر يوم"
                                        , "اربعة عشر يوم", "خمسة عشر يوم", "ستة عشر يوم", "سبعة عشر يوم", "ثمانية عشر يوم", "تسعة عشر يوم"
                                        , "عشرون يوم", "واحد عشرون يوم", "أثنين وعشرون يوم", "ثلاثة وعشرون يوم", "أربعة وعشرون يوم", "خمسة وعشرون يوم", "ستة وعشرون يوم", "سبعة وعشرون يوم", "ثمانية وعشرون يوم", "تسعة وعشرون يوم", "ثلاثون يوم"};
        public static string[] Money = { "", "واحد", "اثنان", "ثلاثة", "اربعة", "خمسة", "ستة", "سبعة"
                                        , "ثمانية", "تسعة", "عشرة", "أحدى عشر", "أثنى عشر", "ثلاثة عشر"
                                        , "اربعة عشر", "خمسة عشر", "ستة عشر", "سبعة عشر", "ثمانية عشر", "تسعة عشر"
                                        , "", "", "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون", ""
                                        , "مائة", "مائتان", "ثلاثمائة", "اربعمائة", "خمسمائة", "ستمائة", "سبعمائة", "ثمانمائة", "تسعمائة"
                                        , "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""};

        public static string[] Money2 = { "", "one", "two", "three", "four", "five", "six", "seven"
                                        , "eight", "nine", "ten", "eleven", "twelve", "thirteen"
                                        , "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
                                        , "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety", ""
                                        , "hundred", "two hundred", "three hundred", "four hundred", "five hundred", "six hundred", "seven hundred", "eight hundred", "nine hundred"
                                        , "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""};

        public static string[] Days = {"السبت","الاحد","الاثنين","الثلاثاء","الاربعاء","الخميس","الجمعة","السبت","الاحد"};
        public static string[] MonthName = { "يناير", "فبراير", "مارس", "أبريل", "مايو", "يونية", "يولية", "أغسطس", "سبتمبر", "أكتوبر", "نوفمبر", "ديسمبر"};

        public static string CheckDate(string myDate)
        {
            try
            {
                string Y = DateTime.Parse(myDate).Year.ToString();
                string M = DateTime.Parse(myDate).Month.ToString();
                string D = DateTime.Parse(myDate).Day.ToString();
                if (M.Length < 2) M = '0' + M;
                if (D.Length < 2) D = '0' + D;
                if (Y.Length < 4) Y = moh.MakeMask(Y, 4);
                return D + "/" + M + "/" + Y;
            }
            catch
            {
                return myDate;
            }

        }

        public static string NTOW(int P1, int P2, int P3, short Lang)
        {
            string Result = "";
            string WAW = Lang == 1 ? " و " : " , ";
            string NOWAW = " ";
            int Num_P = 3;
            if(P3 == -1) Num_P = 2;
            if(P2 == -1) Num_P = 1;
            if(Num_P == 1)
            {
                Result = (Lang == 1 ? Money[P1] : Money2[P1]);
            }
            if(Num_P == 2 && P1 != 1)
            {
                Result = (Lang == 1 ? Money[P2] : Money2[P2]);
                if (Result.Trim() != "" && (Lang == 1 ? Money[20 + P1].Trim() != "" && Money[20 + P1] != "0" : Money2[20 + P1].Trim() != "" && Money2[20 + P1] != "0")) Result += WAW;
                Result += (Lang == 1 ? Money[20+P1] : Money2[20+P1]);                  
            }
            if(Num_P == 2 && P1 == 1)
            {
                Result = (Lang == 1 ? Money[10+P2] : Money2[10+P2]);
            }
            if(Num_P == 3 && P2 != 1)
            {
                Result = (Lang == 1 ? Money[30+P1] : Money2[30+P1]);
                if(Result.Trim() == "" && (Lang == 1 ? Money[P3].Trim() != "" : Money2[P3].Trim() != "")) Result += NOWAW;
                if (Result.Trim() != "" && (Lang == 1 ? Money[P3].Trim() != "" && Money[P3].Trim() != "0" : Money2[P3].Trim() != "" && Money2[P3].Trim() != "0")) Result += WAW;
                Result += (Lang == 1 ? Money[P3] : Money2[P3]);
                if (Result.Trim() != "" && (Lang == 1 ? Money[20 + P2].Trim() != "" && Money[20 + P2].Trim() != "0" : Money2[20 + P2].Trim() != "" && Money2[20 + P2].Trim() != "0")) Result += WAW;
                Result += (Lang == 1 ? Money[20+P2] : Money2[20+P2]);
            }
            if(Num_P == 3 && P2 == 1)
            {
                Result = (Lang == 1 ? Money[30+P1] : Money2[30+P1]);
                if (Result.Trim() != "" && (Lang == 1 ? Money[10 + P3].Trim() != "" && Money[10 + P3].Trim() != "0" : Money2[10 + P3].Trim() != "" && Money2[10 + P3].Trim() != "0")) Result += WAW;
                Result += (Lang == 1 ? Money[10+P3] : Money2[10+P3]);
            }
            return Result;
        }


        public static TimeSpan SubTime(DateTime STime, DateTime ETime)
        {
            //string start2 = STime.ToString("HH:mm:ss");
            //string end2 = ETime.ToString("HH:mm:ss");


            //TimeSpan Result = DateTime.Parse(end2).Subtract(DateTime.Parse(start2));
            TimeSpan Result = STime.Subtract(ETime);

            if (ETime < STime && ETime < DateTime.Parse("04:00:00"))
            {
                Result = STime.Subtract(ETime.AddDays(1));
            }


            /*
            if (DateTime.Parse(end2) < DateTime.Parse(start2) && DateTime.Parse(end2) < DateTime.Parse("04:00:00"))
            {
                Result = DateTime.Parse("23:59:59").Subtract(DateTime.Parse(start2));
                Result += DateTime.Parse(end2).Subtract(DateTime.Parse("00:00:01"));
                Result = TimeSpan.Parse("00:00:00");
            }
             */
            return Result;
        }

        public static CalcRoad GetDistanceTime(string DriverLat, string DriverLong, string LocLat, string LocLong)
        {
           

            CalcRoad myResult = new CalcRoad();
            try
            {
                double startLatitude = moh.StrToDouble(DriverLat);
                double endLatitude = moh.StrToDouble(LocLat);
                double startLongitude = moh.StrToDouble(DriverLong);
                double endLongitude = moh.StrToDouble(LocLong);
                string apiUrl = @"https://maps.googleapis.com/maps/api/directions/json?region=SA&language=ar&key={0}&origin={1},{2}&destination={3},{4}";
                apiUrl = string.Format(apiUrl,
                    GoogleAPI,
                    startLatitude, startLongitude,
                    endLatitude.ToString(),
                    endLongitude.ToString()
                    );



                WebRequest request = HttpWebRequest.Create(apiUrl);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                string responseStringData = reader.ReadToEnd();
                RootObject responseData = parser.Deserialize<RootObject>(responseStringData);
                if (responseData != null)
                {
                    double distance = Math.Round((double)(responseData.routes.Sum(r => r.legs.Sum(l => l.distance.value)) / 1000), 2);
                    double duration = Math.Round((double)(responseData.routes.Sum(r => r.legs.Sum(l => l.duration.value)) / 60), 2);
                    myResult.Distance = distance;
                    myResult.Duration = duration;
                }
                else
                {
                    myResult.Distance = 0;
                    myResult.Duration = 0;
                }

            }
            catch
            {
                myResult.Distance = 0;
                myResult.Duration = 0;
            }
            return myResult;
        }

        public static string RemoveNo(string vs)
        {
            string vResult = "";
            for (int i=0;i<vs.Length;i++)
            {
                if (vs[i] >= '0' && vs[i] >= '9')
                {

                }
                else vResult += vs[i];
            }
            return vResult.Trim();
        }

        public static ChkPromo CheckMyPromoCode(short ServiceCode,string PromoCode,string CustomerCode,string InvoiceNo,string InvoiceDateTime,short DeviceType,string FromLoc,string ToLoc,string FromLat,string FromLng,string UserName,string cnn)
        {
            ChkPromo cp = new ChkPromo();
            Offers myOffer = new Offers();
            myOffer.PromoCode = PromoCode;
            myOffer = myOffer.FindPromoCode(cnn);
            if (myOffer != null)
            {
                if (myOffer.Services.Contains(ServiceCode.ToString()))
                {
                    if ((bool)myOffer.OfferActive)
                    {
                        if (myOffer.CustomerCode == "-1" || myOffer.CustomerCode == CustomerCode || myOffer.CustomerCode == UserName)
                        {
                            if (myOffer.InvoiceNo == "" || myOffer.InvoiceNo == InvoiceNo)
                            {
                                if ((DeviceType == 3 && (bool)myOffer.UseApp) || (DeviceType == 2 && (bool)myOffer.UseWebsite) || (DeviceType == 1 && (bool)myOffer.UseSystem))
                                {
                                    if (myOffer.FromLoc == "-1" || myOffer.FromLoc == FromLoc)
                                    {
                                        if (myOffer.ToLoc == "-1" || myOffer.ToLoc == ToLoc)
                                        {
                                            if (myOffer.LocLng == "" || myOffer.LocLat == "" || (myOffer.LocLat != "" && myOffer.LocLng != null && FromLat != "" && FromLng != "" && moh.GetDistanceTime(myOffer.LocLat, myOffer.LocLng, FromLat, FromLng).Distance <= (double)myOffer.LocKM))
                                            {
                                                if (myOffer.FDate == "" || myOffer.FTime == "" || myOffer.EDate == "" || myOffer.ETime == "" || (DateTime.ParseExact(InvoiceDateTime, "dd/MM/yyyy HH:mm:ss", null) >= DateTime.ParseExact(myOffer.FDate + " " + myOffer.FTime, "dd/MM/yyyy HH:mm", null) && DateTime.ParseExact(InvoiceDateTime, "dd/MM/yyyy HH:mm:ss", null) <= DateTime.ParseExact(myOffer.EDate + " " + myOffer.ETime, "dd/MM/yyyy HH:mm", null)))
                                                {
                                                    //FirstOrder
                                                    if ((bool)myOffer.FirstOrder)
                                                    {
                                                        Order myOrder = new Order();
                                                        myOrder.UserName = UserName;
                                                        myOrder = myOrder.GetFirstUse(cnn);
                                                        if (myOrder != null) return cp;
                                                    }
                                                    // NoofUse
                                                    if (myOffer.NoofUse > 0)
                                                    {
                                                        Order myOrder = new Order();
                                                        myOrder.PromoCode = PromoCode;
                                                        myOrder.UserName = UserName;
                                                        int? vUse = myOrder.GetUserNamePromoCode(cnn);
                                                        if (vUse == null) vUse = 0;
                                                        if (myOffer.NoofUse < vUse) return cp;
                                                    }

                                                    // Total of Use
                                                    if (myOffer.TotalofUse > 0)
                                                    {
                                                        Order myOrder = new Order();
                                                        myOrder.PromoCode = PromoCode;
                                                        int? vUse = myOrder.GetPromoCode(cnn);
                                                        if (vUse == null) vUse = 0;
                                                        if (myOffer.TotalofUse < vUse) return cp;
                                                    }

                                                     // FromServices
                                                    // Amount  percent
                                                    cp.ErrMsg = "1";
                                                    if ((bool)myOffer.FromService)
                                                    {
                                                        if ((bool)myOffer.Amount) cp.SPer = myOffer.Discount;
                                                        else cp.SAmount = myOffer.Discount;
                                                    }
                                                    else
                                                    {
                                                        if ((bool)myOffer.Amount) cp.Per = myOffer.Discount;
                                                        else cp.Amount = myOffer.Discount;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return cp;
        }




        public static bool doTax(string FDate,string Customer)
        {
            bool vResult = false;
            if (Customer != "-1")
            {
                if (DateTime.Parse(FDate) >= DateTime.Parse("01/01/2018") && DateTime.Parse(FDate) < DateTime.Parse("01/03/2019")) vResult = true;
                if (DateTime.Parse(FDate) >= DateTime.Parse("01/04/2019")) return true;
            }
            else
            {
                if (DateTime.Parse(FDate) >= DateTime.Parse("01/01/2018") && DateTime.Parse(FDate) < DateTime.Parse("07/03/2019")) vResult = true;
                if (DateTime.Parse(FDate) >= DateTime.Parse("01/04/2019")) return true;
            }
            return vResult;
        }

        public static double doTax(string FDate)
        {
            double vResult = 0.00;
            if (!string.IsNullOrEmpty(FDate))
            {
                if (DateTime.Parse(FDate) >= DateTime.Parse("01/07/2020")) vResult = 0.15;
                else if (DateTime.Parse(FDate) >= DateTime.Parse("01/01/2018")) vResult = 0.05;
            }
            return vResult;
        }


        public static double doTripCost(string FDate)
        {
            double vResult = 0.00;
            if (!string.IsNullOrEmpty(FDate))
            {
                if (DateTime.Parse(FDate) >= DateTime.Parse("07/01/2022")) vResult = 0.43;
                else vResult = 0.40;
            }
            return vResult;
        }


        public static string doTax(string FDate,int Lang)
        {            
            string vResult = (Lang == 1 ? "الضريبة" : "VAT");
            if (!string.IsNullOrEmpty(FDate))
            {
                if (DateTime.Parse(FDate) >= DateTime.Parse("01/07/2020")) vResult = (Lang == 1 ? "الضريبة 15%" : "VAT 15%");
                else if (DateTime.Parse(FDate) >= DateTime.Parse("01/01/2018")) vResult = (Lang == 1 ? "الضريبة 5%" : "VAT 5%");
            }
            return vResult;
        }

        public static string NTOC(double x , short Lang)
        {
            string Result = "";
            string outPut = "0";
            string xs0 = string.Format("{0:N2}", x).Trim();
            string xs = "";
            for (int g = 0; g < xs0.Length; g++)
                if (xs0[g] != ',' && xs0[g] != '(' && xs0[g] != ')' && xs0[g] != '-') xs += xs0[g];
            outPut = xs.Split('.')[1].Substring(0, xs.Split('.')[1].Length);            
            string rem1 = "";
            string Only = Lang == 1 ?  " فقط لا غير" : " Only";
            string Msg1 = Lang == 1 ? " ريال " : " S.R. ";
            string ALF = Lang == 1 ? " ألف" : " thousand";
            string ALAF = Lang == 1 ? " ألاف" : " thousand";
            string WAW = Lang == 1 ?  " و " : " , ";
            string NOWAW = " ";
            string MELION = Lang == 1 ?  " مليون" : " million";
            string ALFIN = Lang == 1 ?  " ألفين" : " two thousand";
            string ALF1 = Lang == 1 ?  " ألف" : " thousand";
            string VHALAL = Lang == 1 ?  " هلله" : " halala";
            string vHand = "";
            string VDATA = "";
            string VTHOU = "";
            string VHAND_THOU = "";
            if (int.Parse(outPut) > 0)
            {
                rem1 = WAW + outPut + VHALAL;
            }
            VHALAL = "";
            int VP1 = 0;
            int VP2 = 0;
            int VP3 = 0;
            xs = xs.Split('.')[0];
            int e = (xs.Length < 3 ? xs.Length : 3);
            string xs1 = xs.Substring(xs.Length - e, e); // +1
            if (xs1 == "0") return "";
            if (xs1.Length >= 1) VP1 = int.Parse(xs1.Substring(0, 1));
            else VP1 = 0;
            if (xs1.Length >= 2) VP2 = int.Parse(xs1.Substring(1, 1));
            else VP2 = 0;
            if (xs1.Length >= 3) VP3 = int.Parse(xs1.Substring(2, 1));
            else VP3 = 0;
            int a = xs1.Length;
            if (a == 1) vHand = NTOW(VP1, -1, -1 ,Lang);
            if (a == 2) vHand = NTOW(VP1, VP2, -1 , Lang);
            if (a == 3) vHand = NTOW(VP1, VP2, VP3 , Lang);
            string R1 = "";
            if (xs.Length > 3) R1 = xs.Substring(0, xs.Length - 3);
            else R1 = "";
            if (R1 == "")
            {
                if (a != 1) VDATA = VHALAL;
                else if (vHand == "") VDATA = "";
                else VDATA = ""; // Only
                Result = vHand + VDATA + Msg1 + rem1 + Only;
            }
            if(xs.Length<4) return Result; // will remove

            e = (R1.Length < 3 ? R1.Length : 3);
            xs1 = R1.Substring(R1.Length - e, e).Trim();
            if (xs1.Length >= 1)  VP1 = int.Parse(xs1.Substring(0, 1));
            if (xs1.Length >= 2) VP2 = int.Parse(xs1.Substring(1, 1));
            if (xs1.Length >= 3) VP3 = int.Parse(xs1.Substring(2, 1));
            a = xs1.Length;
            if (a == 1) VTHOU = NTOW(VP1, -1, -1 , Lang);
            if (a == 2) VTHOU = NTOW(VP1, VP2, -1 , Lang);
            if (a == 3) VTHOU = NTOW(VP1, VP2, VP3 , Lang);
            string R2 = "";

            if (R1.Length > 3) R2 = R1.Substring(0, R1.Length - 3);
            else R2 = "";
            if (R2 == "")
            {
                VDATA = "";
                if (VTHOU == "") VDATA = "";
                else if (R1.Length != 1) VDATA = ALF;
                else
                {
                    a = int.Parse(R1);
                    if (a > 2) VDATA = ALAF;
                    else
                    {
                        VDATA = ALF;
                        if (a == 1)
                        {
                            VTHOU = ALF1;
                            VDATA = "";
                        }
                        if (a == 2)
                        {
                            VTHOU = ALFIN;
                            VDATA = "";
                        }
                    }
                }
                if (vHand.Trim().Length <= 1) VDATA = VTHOU + VDATA + NOWAW;
                if (vHand.Trim().Length > 1) VDATA = VTHOU + VDATA + WAW + vHand;
                Result = VDATA + Msg1 + rem1 + Only;
            }
            if (R2.Trim().Length < 1) return Result; // will remove
            string xs2 = "";
            e = (R2.Length < 3 ? R2.Length : 3);
            xs2 = R2.Substring(R2.Length - e, e);
            if (xs2.Length >= 1) VP1 = int.Parse(xs2.Substring(0, 1));
            if (xs2.Length >= 2) VP2 = int.Parse(xs2.Substring(1, 1));
            if (xs2.Length >= 3) VP3 = int.Parse(xs2.Substring(2, 1));
            a = xs2.Length;
            if (a == 1) VHAND_THOU = NTOW(VP1, -1, -1, Lang);
            if (a == 2) VHAND_THOU = NTOW(VP1, VP2, -1 , Lang);
            if (a == 3) VHAND_THOU = NTOW(VP1, VP2, VP3 , Lang);
            string R3 = "";
            e = (R2.Length < 3 ? R2.Length : 3);
            R3 = R2.Substring(0, R2.Length - e);
            if (R3 == "")
            {
                VDATA = VHAND_THOU + MELION;
                if (VTHOU.Trim() == "") VDATA += NOWAW + VTHOU;
                else VDATA += WAW + VTHOU + ALF;
                if (vHand.Trim() == "") VDATA += NOWAW + vHand;
                else VDATA += WAW + vHand;
                Result = VDATA + Msg1 + rem1 + Only;
            }
            return Result;
        }

        public static string DisptopMessage(object text, bool v1, bool v2)
        {
            throw new NotImplementedException();
        }

        public static string GetStatus(short? Status, string iLang)
        {
            string vResult = "";
            if (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN")
            {
                vResult = (Status == -1 ? "Cancelled" :
                           Status == 0 ? "Order Confirmed" :
                           Status == 1 || Status == 10 ? "Scheduled" :
                           Status == 3 ? "On The Way to Sender" :
                           Status == 4 ? "Picked from Sender" :
                           Status == 5 ? "On The Way to Receiver" :
                           Status == 6 ? "Arrived" :
                           Status == 7 ? "Delivered" :
                           Status == 8 ? "On The Way to Assembly Area" :
                           Status == 80 ? "Reached Assembly Area" :
                           Status == 81 ? "Delivered to Assembly Area" :
                    //Status == 9 ? "Collected" :
                           Status == 99 ? "Completed" : "");
            }
            else
            {
                vResult = (Status == -1 ? "ملغي" :
                           Status == 0 ? "تم الطلب" :
                           Status == 1 || Status == 10 ? "تم قبول الطلب" :
                           Status == 99 ? "تم الانجاز" :
                           Status == 3 ? "في الطريق إلى المرسل" :
                           Status == 4 ? "تم الاستلام" :
                           Status == 5 ? "في الطريق إلى المستلم" :
                           Status == 6 ? "تم الوصول" :
                           Status == 8 ? "في الطريق إلى منطقة التجميع" :
                           Status == 80 ? "تم الوصول لمنطقة التجميع" :
                           Status == 81 ? "تم التسليم لمنطقة التجميع" :
                    //Status == 9 ? "تم التجميع" :
                           Status == 7 ? "تم التسليم" : "");
            }
            return vResult;
        }

        public static bool CheckUserAccount(string UserName,string Account,string cnn,TblUsers myUser)
        {
            bool vResult = false;
            if (myUser != null)
            {
                if (Account.StartsWith(myUser.Account1) || Account.StartsWith(myUser.Account2) || Account.StartsWith(myUser.Account3) || Account.StartsWith(myUser.Account4) || (myUser.Account5.Length == 9 && Account.StartsWith(myUser.Account5)) || (myUser.Account6.Length == 9 && Account.StartsWith(myUser.Account6)))
                {
                    vResult = true;
                }
                else if (Account.Trim().Length ==9 && (Account.StartsWith(myUser.Account5) || Account.StartsWith(myUser.Account6)))
                {
                    SEmp myEmp = new SEmp();
                    myEmp.EmpCode = int.Parse(Account.Substring(5, 4));
                    myEmp = myEmp.find(cnn);
                    if (myEmp != null)
                    {
                        if (myEmp.Manag1 == UserName || myEmp.UserName == UserName || myEmp.UserName2 == UserName)
                        {
                            vResult = true;
                        }
                    }
                }
            }
            return vResult;
        }

        public static string Repeatstr(string vstr, int len)
        {
            string s = vstr.Trim();
            for (int i = s.Length; i < len; i++)
            {
                s += " ";
            }
            return s;
        }

        public static string GetStartDate(string code,string OrderDate,string cnn)
        {
            AccValue myAccValue = new AccValue();
            myAccValue.Code = code;
            myAccValue.FDate = OrderDate;
            myAccValue = myAccValue.GetStartDate(cnn);
            return (myAccValue!=null ? myAccValue.FDate : "01/01/2014");
        }
        
        public static void AddUserTrans(string username,string formname,string formAction,string description,string reason,string IP,string cnn)

        {
            Transactions UserTran = new Transactions();
            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
            UserTran.UserName = username;
            UserTran.FormName = formname;
            UserTran.FormAction = formAction;
            UserTran.Description = description;
            UserTran.IP = IP;            
            UserTran.Add(cnn);        
        }

        public static bool CheckTime(string input)
        {
            TimeSpan dummyOutput;
            return TimeSpan.TryParse(input, out dummyOutput);
        }

        public static void AddUserTrans2(string username, string formname, string formAction, string description, string reason, string IP, string cnn , string lat , string lng)
        {
            Transactions UserTran = new Transactions();
            UserTran.TranDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
            UserTran.TranTime = String.Format("{0:HH:mm:ss}", moh.Nows());
            UserTran.UserName = username;
            UserTran.FormName = formname;
            UserTran.FormAction = formAction;
            UserTran.Description = description;
            UserTran.IP = IP;
            UserTran.lat = lat;
            UserTran.lng = lng;
            UserTran.Add(cnn);
        }

        public static string GetPic(int no, string CarNo,string cnn)
        {
            string vStr = "";
            Arch myArch = new Arch();
            myArch.Branch = 1;
            myArch.LocNumber = 0;
            myArch.Number = int.Parse(CarNo);
            myArch.DocType = 999;
            foreach (Arch itm in myArch.Find(cnn))
            {
                if (no == 1)
                {
                    if (itm.FileName.Contains("ستمار"))
                    {
                        vStr = itm.FileName2;
                        // break;
                    }
                }
                else if (no == 2)
                {
                    if (itm.FileName.Contains("تامين"))
                    {
                        vStr = itm.FileName2;
                        // break;
                    }
                }
                else if (no == 3)
                {
                    if (itm.FileName.Contains("تشغيل"))
                    {
                        vStr = itm.FileName2;
                        // break;
                    }
                }
                else
                {
                    if (itm.FileName.Contains("فحص"))
                    {
                        vStr = itm.FileName2;
                        // break;
                    }
                }
            }
            return vStr;
        }


        public static double GetBal(string Code, string FDate , string cnn)
        {
            if (Code == "-1") return 0;
            double OpenBal = 0;
            Acc myAcc = new Acc();
            myAcc.Branch = 1;
            myAcc.Code = Code;
            if (myAcc.GetAcc(cnn))
            {
                OpenBal = (double)(myAcc.ODAcc - myAcc.OCAcc);
            }

            Jv myJv = new Jv();
            myJv.Branch = 1;
            foreach (vJv itm in myJv.GetStatement(cnn, false, FDate, FDate, Code, "-1", "-1", "-1", "-1", "-1", "-1","-1"))
            {
                if (!string.IsNullOrEmpty(itm.DbCode)) OpenBal = OpenBal + (double)itm.Amount;
                else if (!string.IsNullOrEmpty(itm.CrCode)) OpenBal = OpenBal - (double)itm.Amount;
            }
            return OpenBal;
        }

        public static double GetBal(string Code, string cnn)
        {
            if (Code == "-1") return 0;
            double OpenBal = 0;
            Acc myAcc = new Acc();
            myAcc.Branch = 1;
            myAcc.Code = Code;
            if (myAcc.GetAcc(cnn))
            {
                OpenBal = myAcc.Bal;
            }
            return OpenBal;
        }


        public static double GetBal(string Code, string FDate , string EDate , bool Trans, string cnn)
        {
            if (Code == "-1") return 0;
            double OpenBal = 0;
            if (!Trans)
            {
                Acc myAcc = new Acc();
                myAcc.Branch = 1;
                myAcc.Code = Code;
                if (myAcc.GetAcc(cnn))
                {
                    OpenBal = (double)(myAcc.ODAcc - myAcc.OCAcc);
                }
                Jv myJv = new Jv();
                myJv.Branch = 1;
                foreach (vJv itm in myJv.GetStatement(cnn, false, FDate, EDate, Code, "-1", "-1", "-1", "-1", "-1", "-1", "-1"))
                {
                    if (!string.IsNullOrEmpty(itm.DbCode)) OpenBal = OpenBal + (double)itm.Amount;
                    else if (!string.IsNullOrEmpty(itm.CrCode)) OpenBal = OpenBal - (double)itm.Amount;
                }
            }
            else
            {
                Jv myJv = new Jv();
                myJv.Branch = 1;
                foreach (vJv itm in myJv.GetStatement3(cnn, false, FDate, EDate, Code, "-1", "-1", "-1", "-1", "-1", "-1", "-1"))
                {
                    if (!string.IsNullOrEmpty(itm.DbCode)) OpenBal = OpenBal + (double)itm.Amount;
                    else if (!string.IsNullOrEmpty(itm.CrCode)) OpenBal = OpenBal - (double)itm.Amount;
                }
            }
            return OpenBal;
        }

        public static double GetBal0(string Code, string FDate, string EDate, bool Trans, string cnn)
        {
            if (Code == "-1") return 0;
            double OpenBal = 0;
            if (!Trans)
            {
                Acc myAcc = new Acc();
                myAcc.Branch = 1;
                myAcc.Code = Code;
                if (myAcc.GetAcc(cnn))
                {
                    OpenBal = (double)(myAcc.ODAcc - myAcc.OCAcc);
                }
                Jv myJv = new Jv();
                myJv.Branch = 1;
                foreach (vJv itm in myJv.GetStatement(cnn, false, FDate, EDate, Code, "-1", "-1", "-1", "-1", "-1", "-1", "-1"))
                {
                    if (itm.InvNo == "OPEN" || itm.InvNo == "END")
                    {

                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(itm.DbCode)) OpenBal = OpenBal + (double)itm.Amount;
                        else if (!string.IsNullOrEmpty(itm.CrCode)) OpenBal = OpenBal - (double)itm.Amount;
                    }
                }
            }
            else
            {
                Jv myJv = new Jv();
                myJv.Branch = 1;
                foreach (vJv itm in myJv.GetStatement3(cnn, false, FDate, EDate, Code, "-1", "-1", "-1", "-1", "-1", "-1", "-1"))
                {
                    if (itm.InvNo == "OPEN" || itm.InvNo == "END")
                    {

                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(itm.DbCode)) OpenBal = OpenBal + (double)itm.Amount;
                        else if (!string.IsNullOrEmpty(itm.CrCode)) OpenBal = OpenBal - (double)itm.Amount;
                    }
                }
            }
            return OpenBal;
        }


        public static double GetLandCost(string FDate,string FTime,DateTime EDate,double DayCost,double HourCost)
        {
            try
            {
                double vResult = 0;
                DateTime DFrom = new DateTime();
                DFrom = DateTime.Parse(FDate + " " + FTime.Replace("ص", "AM").Replace("م", "PM"));

                TimeSpan ts = new TimeSpan();
                ts = EDate - DFrom;
                if (ts.Days < 7) return vResult;
                else if (ts.Days == 7 && ts.Hours < 1) return vResult;
                else
                {
                    vResult = (ts.Days - 7) * DayCost + ts.Hours * HourCost;                    
                    return vResult;
                }
            }
            catch
            {
                return 0;
            }
        }

        public static double GetLoanBal(string Cash,string cnn,List<CostCenter> lcs)
        {
            double vResult = 0;
            //CostCenter myCost = new CostCenter();
            //myCost.Branch = 1;
            //foreach (CostCenter itemCost in myCost.GetAll(cnn))
            foreach (CostCenter itemCost in lcs)
            {
                if (Cash == itemCost.CashAcc)
                {
                    if(itemCost.LoanAcc != "-1")
                    {
                        Acc myAcc = new Acc();
                        myAcc.Branch = 1;
                        myAcc.Code = itemCost.LoanAcc;
                        if (myAcc.GetAcc(cnn))
                        {
                            vResult = myAcc.Bal;
                        }                    
                    }
                    break;
                }
            }
            return vResult;

        }

        public static double StrToDouble(string s)
        {
            try
            {
                return double.Parse(s, System.Globalization.NumberStyles.AllowParentheses |
                                       System.Globalization.NumberStyles.AllowLeadingSign |
                                       System.Globalization.NumberStyles.AllowThousands |
                                       System.Globalization.NumberStyles.AllowDecimalPoint);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int StrToInt(string s)
        {
            try
            {
                if (string.IsNullOrEmpty(s.Trim())) s = "0";
                return int.Parse(s);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static short StrToShort(string s)
        {
            try
            {
                if (string.IsNullOrEmpty(s.Trim())) s = "0";
                return short.Parse(s);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static string MakeSize(string s, int no)
        {
            try
            {
                if (s.Length < no)
                {
                    return moh.Repeatstr(s, no);
                }
                else if (s.Length > no)
                {
                    return s.Substring(0, no);
                }
                else return s;
            }
            catch (Exception)
            {
                return moh.Repeatstr(" ", no);
            }
        }

        public static string GetCurrentRole(string Branch,TblUsers ax)
        {
              if (ax != null)
              {
                  if (Branch != ax.MainBran) return "AltRoll";
                  else return "Roll";
              }
              return "AltRoll";
        }

        public static void Backup(string ConnectionStr , string Path)
        {
            using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
            {
                myContext.BackupDB(Path);
            }
        }

        public static int PActiveCars2(string ConnectionStr)
        {
            using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
            {
                return myContext.CarsPActive2(String.Format("{0:dd/MM/yyyy}", moh.Nows()));
            }
        }

        /// <summary>
        /// Update Area in Area Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public static bool UserPoints(string ConnectionStr,string ID,double Points,bool Add)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.ShipUsersUpdatePoints(MyEncryption.base64Encode(ID),Points,Add);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static List<Acc1> PettyCashAccGetAll(string ConnectionStr)
        {
            using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
            {
                var result = myContext.PettyCashAccGet();
                return (from itm in result
                        select new Acc1
                        {
                           Code = itm.Code,
                           FCode = itm.FCode
                        }).ToList();

            }
        }

        public static int PActiveCars(string ConnectionStr)
        {

            using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
            {
                var x = myContext.CarsActiveDate();
                string mydate = (from itm in x
                               select itm.myDate.ToString()).FirstOrDefault();
                if(!string.IsNullOrEmpty(mydate))
                {
                    int vY = DateTime.Parse(mydate).Year;
                    int vM = DateTime.Parse(mydate).Month;
                    int vD = DateTime.Parse(mydate).Day;


                    mydate = moh.MakeMask(vD.ToString(), 2) + "/" + moh.MakeMask(vM.ToString(), 2) + "/" + moh.MakeMask(vY.ToString(), 4);

                    string myNow = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    if (DateTime.Parse(mydate) >= DateTime.Parse(myNow))
                    {
                        return 0;
                    }

                    string mydate2 = moh.MakeMask(DateTime.DaysInMonth(vY, vM).ToString(), 2) + "/" + moh.MakeMask(vM.ToString(), 2) + "/" + moh.MakeMask(vY.ToString(), 4);

                    if (DateTime.Parse(mydate) == DateTime.Parse(mydate2))
                    {
                        if(vM == 12)
                        {
                            vM = 1;
                            vY = vY +1;
                        }
                        else vM += 1;

                        mydate2 = moh.MakeMask(DateTime.DaysInMonth(vY, vM).ToString(), 2) + "/" + moh.MakeMask(vM.ToString(), 2) + "/" + moh.MakeMask(vY.ToString(), 4);
                    }


                    if (DateTime.Parse(mydate2) >= DateTime.Parse(myNow))
                    {                        
                        return 0;
                    }
                    else 
                    {
                        while (DateTime.Parse(mydate2) <= DateTime.Parse(myNow))
                        {

                            myContext.CarsPActive(mydate2);

                            if (vM == 12)
                            {
                                vM = 1;
                                vY = vY + 1;
                            }
                            else vM += 1;
                            mydate2 = moh.MakeMask(DateTime.DaysInMonth(vY, vM).ToString(), 2) + "/" + moh.MakeMask(vM.ToString(), 2) + "/" + moh.MakeMask(vY.ToString(), 4);
                        }
                    }
                }

                return 0;
            }
        }


        public static int PActiveEmps(string ConnectionStr)
        {
            using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
            {
                var x = myContext.SEmpActiveDate();
                string mydate = (from itm in x
                               select itm.myDate.ToString()).FirstOrDefault();
                if(!string.IsNullOrEmpty(mydate))
                {
                    int vY = DateTime.Parse(mydate).Year;
                    int vM = DateTime.Parse(mydate).Month;
                    int vD = DateTime.Parse(mydate).Day;


                    mydate = moh.MakeMask(vD.ToString(), 2) + "/" + moh.MakeMask(vM.ToString(), 2) + "/" + moh.MakeMask(vY.ToString(), 4);

                    string myNow = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                    if (DateTime.Parse(mydate) >= DateTime.Parse(myNow))
                    {
                        return 0;
                    }

                    string mydate2 = moh.MakeMask(DateTime.DaysInMonth(vY, vM).ToString(), 2) + "/" + moh.MakeMask(vM.ToString(), 2) + "/" + moh.MakeMask(vY.ToString(), 4);

                    if (DateTime.Parse(mydate) == DateTime.Parse(mydate2))
                    {
                        if(vM == 12)
                        {
                            vM = 1;
                            vY = vY +1;
                        }
                        else vM += 1;

                        mydate2 = moh.MakeMask(DateTime.DaysInMonth(vY, vM).ToString(), 2) + "/" + moh.MakeMask(vM.ToString(), 2) + "/" + moh.MakeMask(vY.ToString(), 4);
                    }


                    if (DateTime.Parse(mydate2) >= DateTime.Parse(myNow))
                    {                        
                        return 0;
                    }
                    else 
                    {
                        while (DateTime.Parse(mydate2) <= DateTime.Parse(myNow))
                        {

                            myContext.SEmpPActive(mydate2);

                            if (vM == 12)
                            {
                                vM = 1;
                                vY = vY + 1;
                            }
                            else vM += 1;
                            mydate2 = moh.MakeMask(DateTime.DaysInMonth(vY, vM).ToString(), 2) + "/" + moh.MakeMask(vM.ToString(), 2) + "/" + moh.MakeMask(vY.ToString(), 4);
                        }
                    }
                }

                return 0;
            }
        }

        public static void RestoreDataBase(string ConnectionStr, string DataBaseName)
        {
            using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
            {
                myContext.RestoreDB(DataBaseName);
            }
        }

        public static bool CheckVac(string ConnectionStr, string FDate )
        {
            using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
            {
                var result = myContext.VacGet(FDate);
                return (result.Count() > 0);

            }
        }


        public static void PostDoc(string ConnectionStr, short VouType , short Branch , short LocNumber , string VouLoc , int Number , String VouNo2 , short FNo2 , bool Mode)
        {
            using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
            {
                myContext.PostVou(VouType, Branch, LocNumber, VouLoc, Number, VouNo2, FNo2, Mode);
            }
        }

        public static DateTime Nows()
        {
            return DateTime.Now.ToUniversalTime().AddHours(3);
        }

        public static void Tally(string ConnectionStr, short Branch)
        {
            using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
            {
                myContext.UpdateBalances(Branch);
            }
        }

        public static void SendEmail(string to, string body , string subject , Attachment myitem)
        {
            string MailServerName = "mail.naqelat.com";
            MailMessage Message = new MailMessage("info@Naqelat.com",to , subject, body);
            if(myitem != null) Message.Attachments.Add(myitem);
            Message.IsBodyHtml = true;
            SmtpClient mailclient = new SmtpClient();
            mailclient.Host = MailServerName;
            mailclient.Port = 25;
            NetworkCredential basicAuthenticationInfo = new NetworkCredential("info@Naqelat.com", "N@5283100");
            mailclient.UseDefaultCredentials = false;
            mailclient.Credentials = basicAuthenticationInfo;
            mailclient.Send(Message);
            Message.Dispose();
        }

        public static string GetCity(string LocLat, string LocLong)
        {
            string myResult = "";
            try
            {                
                double endLatitude = moh.StrToDouble(LocLat);
                double endLongitude = moh.StrToDouble(LocLong);
                string apiUrl = @"https://maps.googleapis.com/maps/api/geocode/json?region=SA&language=ar&key={0}&latlng={1},{2}&sensor=false";
                apiUrl = string.Format(apiUrl,
                    GoogleAPI,
                    endLatitude.ToString(),
                    endLongitude.ToString()
                    );
                WebRequest request = HttpWebRequest.Create(apiUrl);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                string responseStringData = reader.ReadToEnd();
                RootObject2 responseData = parser.Deserialize<RootObject2>(responseStringData);
                if (responseData != null)
                {
                    foreach (var singleResult in responseData.results)
                    {
                        foreach (var vaddress in singleResult.address_components)
                        {
                            if (vaddress.types[0] == "locality")
                            {
                                myResult = vaddress.long_name;
                                break;
                            }
                        }
                        if (myResult != "") break;
                    }
                }
            }
            catch
            {
            }
            if (myResult == "") myResult = "out side of saudi arabia";
            myResult = myResult.Replace("\u064b", "");
            myResult = myResult.Replace("\u064f", "");
            myResult = myResult.Replace("\u064c", "");
            myResult = myResult.Replace("\u0652", "");
            myResult = myResult.Replace("\u064d", "");
            myResult = myResult.Replace("\u0650", "");
            myResult = myResult.Replace("\u0651", "");
            myResult = myResult.Replace("\u064e", "");

            return myResult;
        }



        public static bool IsRtl(this string input)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, @"\p{IsArabic}");
        }

        public static string MakeMask(string str, short no)
        {
            for (int i = str.Length; i < no; i++)
            {
                str = "0" + str;
            }
            return str;
        }

        public static double Trunc(double no)
        {
            return double.Parse(string.Format("{0:N2}", no));
        }

        public static string DisptopMessage(string msg, bool error , bool Modal, string Delay = "3000")
        {
            if (Modal)
            {
                if (error)
                {
                    // Red #E1150C #CC0000
                    // Green '#98C770' #006E2E
                    string script = @"  
               $(function() {        
               DispMessage(0,'" + msg + "');" + @"
               var options = {id: 'message_from_top1',
               position: 'top',
               size: 50,
               backgroundColor: '#D95429',
               border_bottom_width:'1px',
               border_bottom_color:'#CC0000',
               border_bottom_style:'solid',
               color: 'white',
               width: '100%',
               delay: " + Delay + @",
               speed: 500,
               fontSize: '18px'
               };               
               $.showMessage('" + msg + @"',options);
               return false;
               });";
                    return script;
                }
                else
                {
                    // Red #E1150C #CC0000
                    // Green '#98C770'#006E2E //'#98C770',
                    string script = @"  
               $(function() {        
               DispMessage(1,'" + msg + "');" + @"
               var options = {id: 'message_from_top2',
               position: 'top',
               size: 50,
               backgroundColor: '#0B9101',     
               border_bottom_width:'1px',
               border_bottom_color:'#086E00',
               border_bottom_style:'solid',
               color: 'white',
               width: '100%',
               delay: " + Delay + @",
               speed: 500,
               fontSize: '18px'
               };               
               $.showMessage('" + msg + @"',options);
               return false;
               });";
               //refreshOpener();";
               
                    return script;
                }
            }
            else
            {
                if (error)
                {
                    // Red #E1150C #CC0000
                    // Green '#98C770' #006E2E
                    string script = @"  
               $(function() {        
               var options = {id: 'message_from_top1',
               position: 'top',
               size: 50,
               backgroundColor: '#D95429',
               border_bottom_width:'1px',
               border_bottom_color:'#CC0000',
               border_bottom_style:'solid',
               color: 'white',
               width: '100%',
               delay: " + Delay + @",
               speed: 500,
               fontSize: '18px'
               };               
               $.showMessage('" + msg + @"',options);
               return false;
               });";
                    return script;
                }
                else
                {
                    // Red #E1150C #CC0000
                    // Green '#98C770'#006E2E //'#98C770',
                    string script = @"  
               $(function() {        
               var options = {id: 'message_from_top2',
               position: 'top',
               size: 50,
               backgroundColor: '#0B9101',     
               border_bottom_width:'1px',
               border_bottom_color:'#086E00',
               border_bottom_style:'solid',
               color: 'white',
               width: '100%',
               delay: " + Delay + @",
               speed: 500,
               fontSize: '18px'
               };               
               $.showMessage('" + msg + @"',options);
               return false;
               });";
                    return script;
                }
            }
        }
    }


    [Serializable]
    public static class HDate
    {
        public static string getNow()
        {
            System.Globalization.UmAlQuraCalendar MyCal = new System.Globalization.UmAlQuraCalendar();
            int d = MyCal.GetDayOfMonth(DateTime.Now);
            string vd;
            if (d < 10) { vd = "0" + d.ToString(); }
            else { vd = d.ToString(); }

            int m = MyCal.GetMonth(DateTime.Now);
            string vm;
            if (m < 10) { vm = "0" + m.ToString(); }
            else { vm = m.ToString(); }

            if (m == 2 && d > 28)
            {
                d = 28;
                vd = d.ToString();
            }
            return MyCal.GetYear(DateTime.Now).ToString() + "/" + vm + "/" + vd;
        }

        public static DateTime Ch_Date(string vs)
        {
            try
            {
                //CultureInfo arSA = CultureInfo.CreateSpecificCulture("ar-SA");
                //DateTime dt = DateTime.Parse(vs, arSA);
                //return dt;
                if(vs.Split('/')[0].Length == 4) return DateTime.ParseExact(vs, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                else return DateTime.ParseExact(vs, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                return DateTime.ParseExact(DateTime.Now.ToShortDateString(), "yyyy/MM/dd", CultureInfo.InvariantCulture);
            }

            //CultureInfo arSA = CultureInfo.CreateSpecificCulture("ar-SA");
            //DateTime dt = DateTime.Parse(HDate.getNow(), arSA);
        }


        public static string DatetoHjiri(string gDate)
        {
            var UmAlQuraCalendar = new UmAlQuraCalendar();
            DateTime dt = DateTime.Parse(gDate);
            CultureInfo arSA = new CultureInfo("ar-SA")
            {
                DateTimeFormat = { Calendar = UmAlQuraCalendar }
            };

            //HijriCalendar h = new HijriCalendar();
            arSA.DateTimeFormat.Calendar = UmAlQuraCalendar;
            string s = dt.ToString("dd/MM/yyyy", arSA);
            if (s.StartsWith("29/02/")) 
                s = "28/02/" + s.Substring(6, 4);
            return s;
        }



        public static int getMonth(String Date)
        {
            System.Globalization.UmAlQuraCalendar MyCal = new System.Globalization.UmAlQuraCalendar();
            return MyCal.GetMonth(DateTime.Parse(Date));
        }

        public static int getYear(String Date)
        {
            System.Globalization.UmAlQuraCalendar MyCal = new System.Globalization.UmAlQuraCalendar();
            return MyCal.GetYear(DateTime.Parse(Date));
        }

        public static int getDays(String Date)
        {
            System.Globalization.UmAlQuraCalendar MyCal = new System.Globalization.UmAlQuraCalendar();
            return MyCal.GetDayOfMonth(DateTime.Parse(Date));
        }

        public static string AddDays(String Date, int NoDays)
        {
            System.Globalization.UmAlQuraCalendar MyCal = new System.Globalization.UmAlQuraCalendar();
            DateTime mydate;
            mydate = MyCal.AddDays(DateTime.Parse(Date), NoDays);
            int d = MyCal.GetDayOfMonth(mydate);
            string vd;
            if (d < 10) { vd = "0" + d.ToString(); }
            else { vd = d.ToString(); }

            int m = MyCal.GetMonth(mydate);
            string vm;
            if (m < 10) { vm = "0" + m.ToString(); }
            else { vm = m.ToString(); }
            return MyCal.GetYear(mydate).ToString() + "/" + vm + "/" + vd;

        }

        public static string RotateDate(string myDate)
        {
            try
            {
                string Y = DateTime.Parse(myDate).Year.ToString();
                string M = DateTime.Parse(myDate).Month.ToString();
                if (M.Length < 2) M = '0' + M;
                string D = DateTime.Parse(myDate).Day.ToString();
                if (D.Length < 2) D = '0' + D;
                return Y + "/" + M + "/" + D;
            }
            catch
            {
                return myDate;
            }
        }


        public static string RotateDate2(string myDate)
        {
            try
            {
                string Y = DateTime.Parse(myDate).Year.ToString();
                string M = DateTime.Parse(myDate).Month.ToString();
                if (M.Length < 2) M = '0' + M;
                string D = DateTime.Parse(myDate).Day.ToString();
                if (D.Length < 2) D = '0' + D;
                return D + "/" + M + "/" + Y;
            }
            catch
            {
                return myDate;
            }
        }




    }

    public class AddressComponent
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }
    }

  //  public class Bounds
  //  {
  //      public Location northeast { get; set; }
  //      public Location southwest { get; set; }
  //  }

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Geometry
    {
        public Bounds bounds { get; set; }
        public Location location { get; set; }
        public string location_type { get; set; }
        public Bounds viewport { get; set; }
    }

    [Serializable]
    public class CalcRoad
    {
        public double? Distance { get; set; }
        public double? Duration { get; set; }

        public CalcRoad()
        {
            this.Distance = 0;
            this.Duration = 0;
        }
    }
    public class Result
    {
        public List<AddressComponent> address_components { get; set; }
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public bool partial_match { get; set; }
        public List<string> types { get; set; }
    }

    public class RootObject2
    {
        public List<Result> results { get; set; }
        public string status { get; set; }
    }

    //[Serializable]
    //public class GridSetting
    //{
    //    public System.Nullable<short> GridNo { get; set; }
    //    public System.Nullable<short> ColNo { get; set; }
    //    public System.Nullable<short> ColType { get; set; }
    //    public string HeaderText { get; set; }
    //    public string DataField { get; set; }
    //    public System.Nullable<short> ColWidth { get; set; }
    //    public string UrlField1 { get; set; }
    //    public string UrlField2 { get; set; }
    //    public string UrlField3 { get; set; }
    //    public string UrlField4 { get; set; }
    //    public string UrlFormatString { get; set; }

    //    public List<GridSetting> GetGridSetting(short GridNo, string ConnectionStr)
    //    {

    //        try
    //        {
    //            using (SoftTecDataDataContext mycontext = new SoftTecDataDataContext(ConnectionStr))
    //            {
    //                return (from Grid in mycontext.GetTable<GridSetting1>()
    //                        where Grid.GridNo.Equals(GridNo)
    //                        select new GridSetting
    //                        {
    //                            GridNo = Grid.GridNo,
    //                            ColNo = Grid.ColNo,
    //                            ColType = Grid.ColType,
    //                            HeaderText = Grid.HeaderText,
    //                            DataField = Grid.DataField,
    //                            ColWidth = Grid.ColWidth,
    //                            UrlField1 = Grid.urlField1,
    //                            UrlField2 = Grid.urlField2,
    //                            UrlField3 = Grid.urlField3,
    //                            UrlField4 = Grid.urlField4,
    //                            UrlFormatString = Grid.urlFormatString
    //                        }).ToList();
    //            }
    //        }
    //        catch (Exception)
    //        {
    //            return null;
    //        }
    //    }
    //}


}

