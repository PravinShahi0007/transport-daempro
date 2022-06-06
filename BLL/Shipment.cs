using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Shipment
    {
        public short Branch { get; set; }
        public string VouLoc { get; set; }
        public int VouNo { get; set; }               
        public string FTime { get; set; }
        public string Name { get; set; } // اسم المرسل
        public string IDNo { get; set; } // رقم هوية المرسل
        public short? IDType { get; set; } // نوع الهوية: إقامة/هوية وطنية
        public string IDFrom { get; set; } // مصدرها
        public string IDDate { get; set; } // تاريخها
        public string Address { get; set; } // العنوان
        public string MobileNo { get; set; } // رقم الجوال
        public string Mail { get; set; } // الايميل
        public string PlaceofLoading { get; set; } // فرع استلام الشحنة
        public string Destination { get; set; } // فرع تسليم الشحنة
        public string LocFrom { get; set; } // موقع استلام الشحنة من العميل
        public string LocTo { get; set; } // موقع تسليم الشحنة للعميل
        public string RecName { get; set; } // اسم المستلم
        public string RecAddress { get; set; } // عنوان المستلم
        public string RecMobileNo { get; set; } // رقم جوال المستلم
        public double? CashAmount { get; set; } // المبلغ المدفوع
        public string RecMail { get; set; } // ايميل المستلم
        public int? Qty { get; set; } // عدد القطع
        public bool? PlaceFrom { get; set; } // في حال إضافة خيار إعادة الشحنة
        public double? Weight { get; set; } // وزن القطعة
        public double? SiteAmount { get; set; } // الوزن الكلي للشحنة
        public short? Unit { get; set; } // الوحدة
        public string Site { get; set; } // تاريخ الشحن
        public short? ShUse { get; set; } // الغرض من الشحنة
        public short? ShType { get; set; } // نوع الشحنة
        public string ShRemark { get; set; } // وصف الشحنة
        public string ShNote { get; set; } // ملاحظات
        public double? ShabakaAmount { get; set; } // طريقة الدفع
        public double? Amount { get; set; } // المبلغ الاجمالي
        public short? DPeriod { get; set; }
        public string HDate { get; set; }
        public string GDate { get; set; }
        public string VouLoc2 { get; set; }
        public short? CoverType { get; set; }
        public short? CoverSize { get; set; }
        public bool? bto { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public int? Qty2 { get; set; }
        public short? sitm { get; set; }
        public short? ShipType { get; set; }
        public string Customer { get; set; }
        public double? CustomerAmount { get; set; }
        public bool? Transit { get; set; }
        public System.Nullable<short> Status { get; set; }
        public double? Tax { get; set; } 
        public double? Discount { get; set; } 
        public string  DiscountTerm { get; set; }
        public string  PickLat	{ get; set; }
        public string  PickLong	{ get; set; }
        public string  DropLat	{ get; set; }
        public string  DropLong	{ get; set; }
        public string  PromoCode	{ get; set; }
        public short? CardType	{ get; set; }
        public short? PayType	{ get; set; }
        public string  CardNo	{ get; set; }
        public string  CardHolder	{ get; set; }
        public string Expiry { get; set; }
        public string IDdriver { get; set; }
        public short? Rate { get; set; }
        public short? CustRate { get; set; }
        public int? CancelReason { get; set; }
        public string DeliveredDate { get; set; }
        public string ArrivingTime { get; set; }
        public string RateNote { get; set; }
        public System.Nullable<int> RateReason { get; set; }
        public string OrDateTime { get; set; }
        public string IDDriver2 { get; set; }
        public short? Rate2 { get; set; }
        public int? OrderIssue { get; set; }
        public int? OrderIssue2 { get; set; }
        public string DriverNote { get; set; }
        public string DriverNote2 { get; set; }
        public double? Reward1 { get; set; }
        public double? Reward2 { get; set; }
        public double? Penal1 { get; set; }
        public double? Penal2 { get; set; }
        public double? Earn1 { get; set; }
        public double? Earn2 { get; set; }
        public string CNN { get; set; }
        public string FromName
        {
            get
            {
                return "";
                string Name = "out side of saudi arabia";
                if (!string.IsNullOrEmpty(this.PickLat) && !string.IsNullOrEmpty(this.PickLong))
                {
                    Name = moh.GetCity(this.PickLat, this.PickLong);
                }
                Cities myCity = new Cities();
                myCity.Name1 = Name;
                myCity = myCity.Find2(this.CNN);
                return (myCity == null ? "00165" : myCity.Code);
            }
        }
        public string ToName
        {
            get
            {
                return "";
                string Name = "out side of saudi arabia";
                if (!string.IsNullOrEmpty(this.DropLat) && !string.IsNullOrEmpty(this.DropLong))
                {
                    Name = moh.GetCity(this.DropLat, this.DropLong);
                }

                Cities myCity = new Cities();
                myCity.Name1 = Name;
                myCity = myCity.Find2(this.CNN);
                return (myCity == null ? "00165" : myCity.Code);
            }
        }
        public string OrderID
        {
            get
            {
                return "20" + this.VouLoc.Substring(3, 2) + this.VouNo.ToString();
            }
        }
        public string UIID
        {
            get
            {
                return "20" + this.VouNo.ToString();
            }
        }

        public Shipment()
        {
            this.Branch = 1;
            this.VouLoc = "";
            this.VouNo = 0;
            this.FTime = "";
            this.Name = "";
            this.IDNo = "";
            this.IDType = 0;
            this.IDFrom = "";
            this.IDDate = "";
            this.Address = "";
            this.MobileNo = "";
            this.Mail = "";
            this.PlaceofLoading = "";
            this.Destination = "";
            this.LocFrom = "";
            this.LocTo = "";
            this.RecName = "";
            this.RecAddress = "";
            this.RecMobileNo = "";
            this.CashAmount = 0;
            this.RecMail = "";
            this.Qty = 0;
            this.PlaceFrom = false;
            this.Weight = 0;
            this.SiteAmount = 0;
            this.Unit = 0;
            this.Site = "";
            this.ShUse = 0;
            this.ShType = 0;
            this.ShRemark = "";
            this.ShNote = "";
            this.ShabakaAmount = 0;
            this.Amount = 0;
            this.DPeriod = 0;
            this.HDate = "";
            this.GDate = "";
            this.VouLoc2 = "";
            this.CoverType = 0;
            this.CoverSize = 0;
            this.bto = false;
            this.UserName = "";
            this.UserDate = "";
            this.Qty2 = 1;
            this.sitm = 10;
            this.ShipType = 0;
            this.Customer = "-1";
            this.CustomerAmount = 0;
            this.Transit = false;
            this.Status = 0;
            this.Tax = 0;
            this.Discount = 0;
            this.DiscountTerm = "";
            this.PickLat = "";
            this.PickLong = "";
            this.DropLat = "";
            this.DropLong = "";
            this.PromoCode = "";
            this.CardType = 0;
            this.PayType = 0;
            this.CardNo	= "";
            this.CardHolder	= "";
            this.Expiry = "";
            this.IDdriver = "";
            this.Rate = -1;
            this.CustRate = -1;
            this.CancelReason = -1;
            this.DeliveredDate = "";
            this.ArrivingTime = "";
            this.RateNote = "";
            this.RateReason = -1;
            this.OrDateTime = "";
            this.IDDriver2 = "";
            this.Rate2 = -1;
            this.OrderIssue = -1;
            this.OrderIssue2 = -1;
            this.DriverNote = "";
            this.DriverNote2 = "";
            this.Reward1 = 0;
            this.Reward2 = 0;
            this.Penal1 = 0;
            this.Penal2 = 0;
            this.Earn1 = 0;
            this.Earn2 = 0;
        }

        /// <summary>
        /// Add Shipment in Shipment Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        /// 
        public bool Add(string ConnectionStr, string IncomeAcc, string CashAcc,string ShabakaAcc ,string SiteAcc, string Area, string Project, string SiteCode, string Shabaka)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShipmentAdd(this.Branch,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.FTime,
                                            this.Name,
                                            this.IDNo,
                                            this.IDType,
                                            this.IDFrom,
                                            this.IDDate,
                                            this.Address,
                                            this.MobileNo,
                                            this.Mail,
                                            this.PlaceofLoading,
                                            this.Destination,
                                            this.RecName,
                                            this.RecAddress,
                                            this.RecMobileNo,
                                            this.CashAmount,
                                            this.RecMail,
                                            this.Qty,
                                            this.PlaceFrom,
                                            this.Weight,
                                            this.SiteAmount,
                                            this.Unit,
                                            this.ShUse,
                                            this.Site,                                           
                                            this.ShType,
                                            this.ShRemark,
                                            this.ShNote,
                                            this.ShabakaAmount,
                                            this.Amount,
                                            this.LocFrom,
                                            this.LocTo,
                                            this.DPeriod,
                                            this.HDate,
                                            this.GDate,
                                            this.VouLoc2,
                                            this.CoverType,
                                            this.CoverSize,
                                            this.bto,
                                            this.UserName,
                                            this.UserDate,
                                            this.Qty2,
                                            this.sitm,
                                            this.ShipType,
                                            this.Customer,
                                            this.CustomerAmount,
                                            IncomeAcc,CashAcc,ShabakaAcc,SiteAcc,Area,Project,SiteCode,Shabaka,this.Transit,this.Tax,this.Discount,this.DiscountTerm,
                                            this.PickLat,this.PickLong,this.DropLat,this.DropLong,this.PromoCode,this.CardType,this.PayType,this.CardNo,this.CardHolder,this.Expiry,this.IDdriver,this.Rate,this.CustRate,this.CancelReason,
                                            this.DeliveredDate,
                                            this.ArrivingTime,
                                            this.RateNote,
                                            this.RateReason,
                                            this.OrDateTime,
                                            this.IDDriver2,
                                            this.Rate2,
                                            this.OrderIssue,
                                            this.OrderIssue2,
                                            this.DriverNote,
                                            this.DriverNote2,
                                            this.Reward1,
                                            this.Reward2,
                                            this.Penal1,
                                            this.Penal2,
                                            this.Earn1,
                                            this.Earn2                                            
                                            );

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }



        /// <summary>
        /// Update Gas in Gas Table
        /// </summary>
        /// <returns>True if Gas Success or False if Fail</returns>
        public bool StatusUpdate(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShipmentStatusUpdate(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
                                                this.Status);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Gas in Gas Table
        /// </summary>
        /// <returns>True if Gas Success or False if Fail</returns>
        public bool updateLoc(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShipmentUpdateLOC(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
                                                this.PlaceofLoading,
                                                this.Destination);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Gas in Gas Table
        /// </summary>
        /// <returns>True if Gas Success or False if Fail</returns>
        public bool StatusDriverUpdate(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShipmentStatusDriverUpdate(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
                                                this.Status,this.IDdriver);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Update Gas in Gas Table
        /// </summary>
        /// <returns>True if Gas Success or False if Fail</returns>
        public bool doCancel(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShipmentCancel(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
                                                this.Status,this.CancelReason);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Gas in Gas Table
        /// </summary>
        /// <returns>True if Gas Success or False if Fail</returns>
        public bool doRate(string DriverID,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShipmentRate(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
                                                this.Rate, MyEncryption.base64Encode(DriverID),this.RateNote,this.RateReason);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Gas in Gas Table
        /// </summary>
        /// <returns>True if Gas Success or False if Fail</returns>
        public bool doCustRate(string CustID,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShipmentCustRate(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
                                                this.CustRate, MyEncryption.base64Encode(CustID));
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Update Shipment in Shipment Table
        /// </summary>
        /// <returns>True if Shipment Success or False if Fail</returns>

        public bool Update(string ConnectionStr, string IncomeAcc, string CashAcc, string ShabakaAcc, string SiteAcc, string Area, string Project, string SiteCode, string Shabaka)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShipmentUpdate(this.Branch,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.FTime,
                                            this.Name,
                                            this.IDNo,
                                            this.IDType,
                                            this.IDFrom,
                                            this.IDDate,
                                            this.Address,
                                            this.MobileNo,
                                            this.Mail,
                                            this.PlaceofLoading,
                                            this.Destination,
                                            this.RecName,
                                            this.RecAddress,
                                            this.RecMobileNo,
                                            this.CashAmount,
                                            this.RecMail,
                                            this.Qty,
                                            this.PlaceFrom,
                                            this.Weight,
                                            this.SiteAmount,
                                            this.Unit,
                                            this.ShUse,
                                            this.Site,
                                            this.ShType,
                                            this.ShRemark,
                                            this.ShNote,
                                            this.ShabakaAmount,
                                            this.Amount,
                                            this.LocFrom,
                                            this.LocTo,
                                            this.DPeriod,
                                            this.HDate,
                                            this.GDate,
                                            this.VouLoc2,
                                            this.CoverType,
                                            this.CoverSize,
                                            this.bto,
                                            this.UserName,
                                            this.UserDate,
                                            this.Qty2,
                                            this.sitm,
                                            this.ShipType,
                                            this.Customer,
                                            this.CustomerAmount,
                                            IncomeAcc, CashAcc, ShabakaAcc, SiteAcc, Area, Project, SiteCode, Shabaka, this.Transit, this.Tax, this.Discount, this.DiscountTerm,
                                            this.PickLat, this.PickLong, this.DropLat, this.DropLong, this.PromoCode, this.CardType, this.PayType, this.CardNo, this.CardHolder, this.Expiry,this.IDdriver,this.Rate,this.CustRate,this.CancelReason,
                                            this.DeliveredDate,
                                            this.ArrivingTime,
                                            this.RateNote,
                                            this.RateReason,
                                            this.OrDateTime,
                                            this.IDDriver2,
                                            this.Rate2,
                                            this.OrderIssue,
                                            this.OrderIssue2,
                                            this.DriverNote,
                                            this.DriverNote2,
                                            this.Reward1,
                                            this.Reward2,
                                            this.Penal1,
                                            this.Penal2,
                                            this.Earn1,
                                            this.Earn2                                                                                                                                    
                                            );

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Add Shipment in Shipment Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        /// 
        public bool UpdateTransit(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShipmentUpdateTransit(this.Branch,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.Transit
                                            );
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Add Shipment in Shipment Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        /// 
        public bool UpdateDriverNote(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShipmentDriverNoteUpdate(this.Branch,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.DriverNote);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Add Shipment in Shipment Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        /// 
        public bool UpdateOrderIssue(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShipmentOrderIssueUpdate(this.Branch,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.OrderIssue);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Shipment in Shipment Table
        /// </summary>
        /// <returns>True if Delete Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShipmentDelete(Branch, VouLoc, VouNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }




        /// <summary>
        /// get all Shipment from Shipment Table
        /// </summary>
        /// <returns>null</returns>
        public List<Shipment> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShipmentGetAll();
                    return (from Sitm in result
                            select new Shipment
                            {
                                Branch = Sitm.Branch,
                                VouLoc = Sitm.VouLoc,
                                VouNo = Sitm.VouNo,
                                FTime = Sitm.FTime,
                                Name = Sitm.Name,
                                IDNo = Sitm.IDNo,
                                IDType = Sitm.IDType,
                                IDFrom = Sitm.IDFrom,
                                IDDate = Sitm.IDDate,
                                Address = Sitm.Address,
                                MobileNo = Sitm.MobileNo,
                                Mail = Sitm.Mail,
                                PlaceofLoading = Sitm.PlaceofLoading,
                                Destination = Sitm.Destination,
                                RecName = Sitm.RecName,
                                RecAddress = Sitm.RecAddress,
                                RecMobileNo = Sitm.RecMobileNo,
                                CashAmount = Sitm.CashAmount,
                                RecMail = Sitm.RecMail,
                                Qty = Sitm.Qty,
                                PlaceFrom = Sitm.PlaceFrom,
                                Weight = Sitm.Weight,
                                SiteAmount = Sitm.SiteAmount,
                                Unit = Sitm.Unit,
                                ShUse = Sitm.ShUse,
                                Site = Sitm.Site,
                                ShType = Sitm.ShType,
                                ShRemark = Sitm.ShRemark,
                                ShNote = Sitm.ShNote,
                                ShabakaAmount = Sitm.ShabakaAmount,
                                Amount = Sitm.Amount,
                                LocFrom = Sitm.LocFrom,
                                LocTo = Sitm.LocTo,
                                DPeriod = Sitm.DPeriod,
                                HDate = Sitm.HDate,
                                GDate = Sitm.GDate,
                                VouLoc2 = Sitm.VouLoc2,
                                CoverType = Sitm.CoverType,
                                CoverSize = Sitm.CoverSize,
                                bto = Sitm.bto,
                                UserName = Sitm.UserName,
                                UserDate = Sitm.UserDate,
                                Qty2 = Sitm.Qty2,
                                ShipType = Sitm.shipType,
                                sitm = Sitm.sitm,
                                Customer = Sitm.Customer,
                                CustomerAmount = Sitm.CustomerAmount,
                                Transit = Sitm.Transit,
                                Tax = Sitm.Tax,
                                Discount = Sitm.Discount,
                                DiscountTerm = Sitm.DiscountTerm,
                                CardHolder = Sitm.CardHolder,
                                CardNo = Sitm.CardNo,
                                CardType = Sitm.CardType,
                                DropLat = Sitm.DropLat,
                                DropLong = Sitm.DropLong,
                                Expiry = Sitm.Expiry,
                                PayType = Sitm.PayType,
                                PickLat = Sitm.PickLat,
                                PickLong = Sitm.PickLong,
                                PromoCode = Sitm.PromoCode,
                                Status = Sitm.Status,
                                IDdriver = Sitm.IDdriver,
                                CancelReason = Sitm.CancelReason,
                                CustRate = Sitm.CustRate,
                                Rate = Sitm.Rate,
                                ArrivingTime = Sitm.ArrivingTime,
                                DeliveredDate = Sitm.DeliveredDate,
                                RateNote = Sitm.RateNote,
                                RateReason = Sitm.RateReason,
                                OrDateTime = Sitm.OrDateTime,
                                DriverNote = Sitm.DriverNote,
                                DriverNote2 = Sitm.DriverNote2,
                                IDDriver2 = Sitm.IDDriver2,
                                OrderIssue = Sitm.OrderIssue,
                                OrderIssue2 = Sitm.OrderIssue2,
                                Rate2 = Sitm.Rate2,
                                Reward1 = Sitm.Reward1,
                                Reward2 = Sitm.Reward2,
                                Penal1 = Sitm.Penal1,
                                Penal2 = Sitm.Penal2,
                                Earn1 = Sitm.Earn1,
                                Earn2 = Sitm.Earn2                                 
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Shipment> GetStatement(string ConnectionStr, string FDate, string EDate)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShipmentStatement(this.Branch, this.VouLoc, FDate, EDate);
                    return (from Sitm in result
                            select new Shipment
                            {
                                Branch = Sitm.Branch,
                                VouLoc = Sitm.VouLoc,
                                VouNo = Sitm.VouNo,
                                FTime = Sitm.FTime,
                                Name = Sitm.Name,
                                IDNo = Sitm.IDNo,
                                IDType = Sitm.IDType,
                                IDFrom = Sitm.IDFrom,
                                IDDate = Sitm.IDDate,
                                Address = Sitm.Address,
                                MobileNo = Sitm.MobileNo,
                                Mail = Sitm.Mail,
                                PlaceofLoading = Sitm.PlaceofLoading,
                                Destination = Sitm.Destination,
                                RecName = Sitm.RecName,
                                RecAddress = Sitm.RecAddress,
                                RecMobileNo = Sitm.RecMobileNo,
                                CashAmount = Sitm.CashAmount,
                                RecMail = Sitm.RecMail,
                                Qty = Sitm.Qty,
                                PlaceFrom = Sitm.PlaceFrom,
                                Weight = Sitm.Weight,
                                SiteAmount = Sitm.SiteAmount,
                                Unit = Sitm.Unit,
                                ShUse = Sitm.ShUse,
                                Site = Sitm.Site,
                                ShType = Sitm.ShType,
                                ShRemark = Sitm.ShRemark,
                                ShNote = Sitm.ShNote,
                                ShabakaAmount = Sitm.ShabakaAmount,
                                Amount = Sitm.Amount,
                                LocFrom = Sitm.LocFrom,
                                LocTo = Sitm.LocTo,
                                DPeriod = Sitm.DPeriod,
                                HDate = Sitm.HDate,
                                GDate = Sitm.GDate,
                                VouLoc2 = Sitm.VouLoc2,
                                CoverType = Sitm.CoverType,
                                CoverSize = Sitm.CoverSize,
                                bto = Sitm.bto,
                                UserName = Sitm.UserName,
                                UserDate = Sitm.UserDate,
                                Qty2 = Sitm.Qty2,
                                ShipType = Sitm.shipType,
                                sitm = Sitm.sitm,
                                Customer = Sitm.Customer,
                                CustomerAmount = Sitm.CustomerAmount,
                                Transit = Sitm.Transit,
                                CardHolder = Sitm.CardHolder,
                                CardNo = Sitm.CardNo,
                                CardType = Sitm.CardType,
                                DropLat = Sitm.DropLat,
                                DropLong = Sitm.DropLong,
                                Expiry = Sitm.Expiry,
                                PayType = Sitm.PayType,
                                PickLat = Sitm.PickLat,
                                PickLong = Sitm.PickLong,
                                PromoCode = Sitm.PromoCode,
                                Status = Sitm.Status,
                                IDdriver = Sitm.IDdriver,
                                CancelReason = Sitm.CancelReason,
                                CustRate = Sitm.CustRate,
                                Rate = Sitm.Rate,
                                ArrivingTime = Sitm.ArrivingTime,
                                DeliveredDate = Sitm.DeliveredDate,
                                RateNote = Sitm.RateNote,
                                RateReason = Sitm.RateReason,
                                OrDateTime = Sitm.OrDateTime,
                                DriverNote = Sitm.DriverNote,
                                DriverNote2 = Sitm.DriverNote2,
                                IDDriver2 = Sitm.IDDriver2,
                                OrderIssue = Sitm.OrderIssue,
                                OrderIssue2 = Sitm.OrderIssue2,
                                Rate2 = Sitm.Rate2,
                                Reward1 = Sitm.Reward1,
                                Reward2 = Sitm.Reward2,
                                Penal1 = Sitm.Penal1,
                                Penal2 = Sitm.Penal2,
                                Earn1 = Sitm.Earn1,
                                Earn2 = Sitm.Earn2                                 
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// get all Shipment from Shipment Table
        /// </summary>
        /// <returns>null</returns>
        public List<Shipment> GetByRecMobileNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShipmentGetByRecMobileNo(this.RecMobileNo);
                    return (from Sitm in result
                            select new Shipment
                            {
                                Branch = Sitm.Branch,
                                VouLoc = Sitm.VouLoc,
                                VouNo = Sitm.VouNo,
                                FTime = Sitm.FTime,
                                Name = Sitm.Name,
                                IDNo = Sitm.IDNo,
                                IDType = Sitm.IDType,
                                IDFrom = Sitm.IDFrom,
                                IDDate = Sitm.IDDate,
                                Address = Sitm.Address,
                                MobileNo = Sitm.MobileNo,
                                Mail = Sitm.Mail,
                                PlaceofLoading = Sitm.PlaceofLoading,
                                Destination = Sitm.Destination,
                                RecName = Sitm.RecName,
                                RecAddress = Sitm.RecAddress,
                                RecMobileNo = Sitm.RecMobileNo,
                                CashAmount = Sitm.CashAmount,
                                RecMail = Sitm.RecMail,
                                Qty = Sitm.Qty,
                                PlaceFrom = Sitm.PlaceFrom,
                                Weight = Sitm.Weight,
                                SiteAmount = Sitm.SiteAmount,
                                Unit = Sitm.Unit,
                                ShUse = Sitm.ShUse,
                                Site = Sitm.Site,
                                ShType = Sitm.ShType,
                                ShRemark = Sitm.ShRemark,
                                ShNote = Sitm.ShNote,
                                ShabakaAmount = Sitm.ShabakaAmount,
                                Amount = Sitm.Amount,
                                LocFrom = Sitm.LocFrom,
                                LocTo = Sitm.LocTo,
                                DPeriod = Sitm.DPeriod,
                                HDate = Sitm.HDate,
                                GDate = Sitm.GDate,
                                VouLoc2 = Sitm.VouLoc2,
                                CoverType = Sitm.CoverType,
                                CoverSize = Sitm.CoverSize,
                                bto = Sitm.bto,
                                UserName = Sitm.UserName,
                                UserDate = Sitm.UserDate,
                                Qty2 = Sitm.Qty2,
                                ShipType = Sitm.shipType,
                                sitm = Sitm.sitm,
                                Customer = Sitm.Customer,
                                CustomerAmount = Sitm.CustomerAmount,
                                Transit = Sitm.Transit,
                                CardHolder = Sitm.CardHolder,
                                CardNo = Sitm.CardNo,
                                CardType = Sitm.CardType,
                                DropLat = Sitm.DropLat,
                                DropLong = Sitm.DropLong,
                                Expiry = Sitm.Expiry,
                                PayType = Sitm.PayType,
                                PickLat = Sitm.PickLat,
                                PickLong = Sitm.PickLong,
                                PromoCode = Sitm.PromoCode,
                                Status = Sitm.Status,
                                IDdriver = Sitm.IDdriver,
                                CancelReason = Sitm.CancelReason,
                                CustRate = Sitm.CustRate,
                                Rate = Sitm.Rate,
                                ArrivingTime = Sitm.ArrivingTime,
                                DeliveredDate = Sitm.DeliveredDate,
                                RateNote = Sitm.RateNote,
                                RateReason = Sitm.RateReason,
                                OrDateTime = Sitm.OrDateTime,
                                DriverNote = Sitm.DriverNote,
                                DriverNote2 = Sitm.DriverNote2,
                                IDDriver2 = Sitm.IDDriver2,
                                OrderIssue = Sitm.OrderIssue,
                                OrderIssue2 = Sitm.OrderIssue2,
                                Rate2 = Sitm.Rate2,
                                Reward1 = Sitm.Reward1,
                                Reward2 = Sitm.Reward2,
                                Penal1 = Sitm.Penal1,
                                Penal2 = Sitm.Penal2,
                                Earn1 = Sitm.Earn1,
                                Earn2 = Sitm.Earn2                                 
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// get all Shipment from Shipment Table
        /// </summary>
        /// <returns>null</returns>
        public List<Shipment> GetByMobileNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShipmentGetByMobileNo(this.MobileNo);
                    return (from Sitm in result
                            select new Shipment
                            {
                                Branch = Sitm.Branch,
                                VouLoc = Sitm.VouLoc,
                                VouNo = Sitm.VouNo,
                                FTime = Sitm.FTime,
                                Name = Sitm.Name,
                                IDNo = Sitm.IDNo,
                                IDType = Sitm.IDType,
                                IDFrom = Sitm.IDFrom,
                                IDDate = Sitm.IDDate,
                                Address = Sitm.Address,
                                MobileNo = Sitm.MobileNo,
                                Mail = Sitm.Mail,
                                PlaceofLoading = Sitm.PlaceofLoading,
                                Destination = Sitm.Destination,
                                RecName = Sitm.RecName,
                                RecAddress = Sitm.RecAddress,
                                RecMobileNo = Sitm.RecMobileNo,
                                CashAmount = Sitm.CashAmount,
                                RecMail = Sitm.RecMail,
                                Qty = Sitm.Qty,
                                PlaceFrom = Sitm.PlaceFrom,
                                Weight = Sitm.Weight,
                                SiteAmount = Sitm.SiteAmount,
                                Unit = Sitm.Unit,
                                ShUse = Sitm.ShUse,
                                Site = Sitm.Site,
                                ShType = Sitm.ShType,
                                ShRemark = Sitm.ShRemark,
                                ShNote = Sitm.ShNote,
                                ShabakaAmount = Sitm.ShabakaAmount,
                                Amount = Sitm.Amount,
                                LocFrom = Sitm.LocFrom,
                                LocTo = Sitm.LocTo,
                                DPeriod = Sitm.DPeriod,
                                HDate = Sitm.HDate,
                                GDate = Sitm.GDate,
                                VouLoc2 = Sitm.VouLoc2,
                                CoverType = Sitm.CoverType,
                                CoverSize = Sitm.CoverSize,
                                bto = Sitm.bto,
                                UserName = Sitm.UserName,
                                UserDate = Sitm.UserDate,
                                Qty2 = Sitm.Qty2,
                                ShipType = Sitm.shipType,
                                sitm = Sitm.sitm,
                                Customer = Sitm.Customer,
                                CustomerAmount = Sitm.CustomerAmount,
                                Transit = Sitm.Transit,
                                CardHolder = Sitm.CardHolder,
                                CardNo = Sitm.CardNo,
                                CardType = Sitm.CardType,
                                DropLat = Sitm.DropLat,
                                DropLong = Sitm.DropLong,
                                Expiry = Sitm.Expiry,
                                PayType = Sitm.PayType,
                                PickLat = Sitm.PickLat,
                                PickLong = Sitm.PickLong,
                                PromoCode = Sitm.PromoCode,
                                Status = Sitm.Status,
                                IDdriver = Sitm.IDdriver,
                                CancelReason = Sitm.CancelReason,
                                CustRate = Sitm.CustRate,
                                Rate = Sitm.Rate,
                                ArrivingTime = Sitm.ArrivingTime,
                                DeliveredDate = Sitm.DeliveredDate,
                                RateNote = Sitm.RateNote,
                                RateReason = Sitm.RateReason,
                                OrDateTime = Sitm.OrDateTime,
                                DriverNote = Sitm.DriverNote,
                                DriverNote2 = Sitm.DriverNote2,
                                IDDriver2 = Sitm.IDDriver2,
                                OrderIssue = Sitm.OrderIssue,
                                OrderIssue2 = Sitm.OrderIssue2,
                                Rate2 = Sitm.Rate2,
                                Reward1 = Sitm.Reward1,
                                Reward2 = Sitm.Reward2,
                                Penal1 = Sitm.Penal1,
                                Penal2 = Sitm.Penal2,
                                Earn1 = Sitm.Earn1,
                                Earn2 = Sitm.Earn2                                 
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// get all Shipment from Shipment Table
        /// </summary>
        /// <returns>null</returns>
        public List<Shipment> GetByIDNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShipmentGetByIDNo(this.IDNo);
                    return (from Sitm in result
                            select new Shipment
                            {
                                Branch = Sitm.Branch,
                                VouLoc = Sitm.VouLoc,
                                VouNo = Sitm.VouNo,
                                FTime = Sitm.FTime,
                                Name = Sitm.Name,
                                IDNo = Sitm.IDNo,
                                IDType = Sitm.IDType,
                                IDFrom = Sitm.IDFrom,
                                IDDate = Sitm.IDDate,
                                Address = Sitm.Address,
                                MobileNo = Sitm.MobileNo,
                                Mail = Sitm.Mail,
                                PlaceofLoading = Sitm.PlaceofLoading,
                                Destination = Sitm.Destination,
                                RecName = Sitm.RecName,
                                RecAddress = Sitm.RecAddress,
                                RecMobileNo = Sitm.RecMobileNo,
                                CashAmount = Sitm.CashAmount,
                                RecMail = Sitm.RecMail,
                                Qty = Sitm.Qty,
                                PlaceFrom = Sitm.PlaceFrom,
                                Weight = Sitm.Weight,
                                SiteAmount = Sitm.SiteAmount,
                                Unit = Sitm.Unit,
                                ShUse = Sitm.ShUse,
                                Site = Sitm.Site,
                                ShType = Sitm.ShType,
                                ShRemark = Sitm.ShRemark,
                                ShNote = Sitm.ShNote,
                                ShabakaAmount = Sitm.ShabakaAmount,
                                Amount = Sitm.Amount,
                                LocFrom = Sitm.LocFrom,
                                LocTo = Sitm.LocTo,
                                DPeriod = Sitm.DPeriod,
                                HDate = Sitm.HDate,
                                GDate = Sitm.GDate,
                                VouLoc2 = Sitm.VouLoc2,
                                CoverType = Sitm.CoverType,
                                CoverSize = Sitm.CoverSize,
                                bto = Sitm.bto,
                                UserName = Sitm.UserName,
                                UserDate = Sitm.UserDate,
                                Qty2 = Sitm.Qty2,
                                ShipType = Sitm.shipType,
                                sitm = Sitm.sitm,
                                Customer = Sitm.Customer,
                                CustomerAmount = Sitm.CustomerAmount,
                                Transit = Sitm.Transit,
                                CardHolder = Sitm.CardHolder,
                                CardNo = Sitm.CardNo,
                                CardType = Sitm.CardType,
                                DropLat = Sitm.DropLat,
                                DropLong = Sitm.DropLong,
                                Expiry = Sitm.Expiry,
                                PayType = Sitm.PayType,
                                PickLat = Sitm.PickLat,
                                PickLong = Sitm.PickLong,
                                PromoCode = Sitm.PromoCode,
                                Status = Sitm.Status,
                                IDdriver = Sitm.IDdriver,
                                CancelReason = Sitm.CancelReason,
                                CustRate = Sitm.CustRate,
                                Rate = Sitm.Rate,
                                ArrivingTime = Sitm.ArrivingTime,
                                DeliveredDate = Sitm.DeliveredDate,
                                RateNote = Sitm.RateNote,
                                RateReason = Sitm.RateReason,
                                OrDateTime = Sitm.OrDateTime,
                                DriverNote = Sitm.DriverNote,
                                DriverNote2 = Sitm.DriverNote2,
                                IDDriver2 = Sitm.IDDriver2,
                                OrderIssue = Sitm.OrderIssue,
                                OrderIssue2 = Sitm.OrderIssue2,
                                Rate2 = Sitm.Rate2,
                                Reward1 = Sitm.Reward1,
                                Reward2 = Sitm.Reward2,
                                Penal1 = Sitm.Penal1,
                                Penal2 = Sitm.Penal2,
                                Earn1 = Sitm.Earn1,
                                Earn2 = Sitm.Earn2                                 
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// get all Shipment from Shipment Table
        /// </summary>
        /// <returns>null</returns>
        public List<Shipment> GetByName(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShipmentGetByName(this.Name);
                    return (from Sitm in result
                            select new Shipment
                            {
                                Branch = Sitm.Branch,
                                VouLoc = Sitm.VouLoc,
                                VouNo = Sitm.VouNo,
                                FTime = Sitm.FTime,
                                Name = Sitm.Name,
                                IDNo = Sitm.IDNo,
                                IDType = Sitm.IDType,
                                IDFrom = Sitm.IDFrom,
                                IDDate = Sitm.IDDate,
                                Address = Sitm.Address,
                                MobileNo = Sitm.MobileNo,
                                Mail = Sitm.Mail,
                                PlaceofLoading = Sitm.PlaceofLoading,
                                Destination = Sitm.Destination,
                                RecName = Sitm.RecName,
                                RecAddress = Sitm.RecAddress,
                                RecMobileNo = Sitm.RecMobileNo,
                                CashAmount = Sitm.CashAmount,
                                RecMail = Sitm.RecMail,
                                Qty = Sitm.Qty,
                                PlaceFrom = Sitm.PlaceFrom,
                                Weight = Sitm.Weight,
                                SiteAmount = Sitm.SiteAmount,
                                Unit = Sitm.Unit,
                                ShUse = Sitm.ShUse,
                                Site = Sitm.Site,
                                ShType = Sitm.ShType,
                                ShRemark = Sitm.ShRemark,
                                ShNote = Sitm.ShNote,
                                ShabakaAmount = Sitm.ShabakaAmount,
                                Amount = Sitm.Amount,
                                LocFrom = Sitm.LocFrom,
                                LocTo = Sitm.LocTo,
                                DPeriod = Sitm.DPeriod,
                                HDate = Sitm.HDate,
                                GDate = Sitm.GDate,
                                VouLoc2 = Sitm.VouLoc2,
                                CoverType = Sitm.CoverType,
                                CoverSize = Sitm.CoverSize,
                                bto = Sitm.bto,
                                UserName = Sitm.UserName,
                                UserDate = Sitm.UserDate,
                                Qty2 = Sitm.Qty2,
                                ShipType = Sitm.shipType,
                                sitm = Sitm.sitm,
                                Customer = Sitm.Customer,
                                CustomerAmount = Sitm.CustomerAmount,
                                Transit = Sitm.Transit,
                                CardHolder = Sitm.CardHolder,
                                CardNo = Sitm.CardNo,
                                CardType = Sitm.CardType,
                                DropLat = Sitm.DropLat,
                                DropLong = Sitm.DropLong,
                                Expiry = Sitm.Expiry,
                                PayType = Sitm.PayType,
                                PickLat = Sitm.PickLat,
                                PickLong = Sitm.PickLong,
                                PromoCode = Sitm.PromoCode,
                                Status = Sitm.Status,
                                IDdriver = Sitm.IDdriver,
                                CancelReason = Sitm.CancelReason,
                                CustRate = Sitm.CustRate,
                                Rate = Sitm.Rate,
                                ArrivingTime = Sitm.ArrivingTime,
                                DeliveredDate = Sitm.DeliveredDate,
                                RateNote = Sitm.RateNote,
                                RateReason = Sitm.RateReason,
                                OrDateTime = Sitm.OrDateTime,
                                DriverNote = Sitm.DriverNote,
                                DriverNote2 = Sitm.DriverNote2,
                                IDDriver2 = Sitm.IDDriver2,
                                OrderIssue = Sitm.OrderIssue,
                                OrderIssue2 = Sitm.OrderIssue2,
                                Rate2 = Sitm.Rate2,
                                Reward1 = Sitm.Reward1,
                                Reward2 = Sitm.Reward2,
                                Penal1 = Sitm.Penal1,
                                Penal2 = Sitm.Penal2,
                                Earn1 = Sitm.Earn1,
                                Earn2 = Sitm.Earn2                                 
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// get all Shipment from Shipment Table
        /// </summary>
        /// <returns>null</returns>
        public List<Shipment> GetByRecName(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShipmentGetByMobileNo(this.RecName);
                    return (from Sitm in result
                            select new Shipment
                            {
                                Branch = Sitm.Branch,
                                VouLoc = Sitm.VouLoc,
                                VouNo = Sitm.VouNo,
                                FTime = Sitm.FTime,
                                Name = Sitm.Name,
                                IDNo = Sitm.IDNo,
                                IDType = Sitm.IDType,
                                IDFrom = Sitm.IDFrom,
                                IDDate = Sitm.IDDate,
                                Address = Sitm.Address,
                                MobileNo = Sitm.MobileNo,
                                Mail = Sitm.Mail,
                                PlaceofLoading = Sitm.PlaceofLoading,
                                Destination = Sitm.Destination,
                                RecName = Sitm.RecName,
                                RecAddress = Sitm.RecAddress,
                                RecMobileNo = Sitm.RecMobileNo,
                                CashAmount = Sitm.CashAmount,
                                RecMail = Sitm.RecMail,
                                Qty = Sitm.Qty,
                                PlaceFrom = Sitm.PlaceFrom,
                                Weight = Sitm.Weight,
                                SiteAmount = Sitm.SiteAmount,
                                Unit = Sitm.Unit,
                                ShUse = Sitm.ShUse,
                                Site = Sitm.Site,
                                ShType = Sitm.ShType,
                                ShRemark = Sitm.ShRemark,
                                ShNote = Sitm.ShNote,
                                ShabakaAmount = Sitm.ShabakaAmount,
                                Amount = Sitm.Amount,
                                LocFrom = Sitm.LocFrom,
                                LocTo = Sitm.LocTo,
                                DPeriod = Sitm.DPeriod,
                                HDate = Sitm.HDate,
                                GDate = Sitm.GDate,
                                VouLoc2 = Sitm.VouLoc2,
                                CoverType = Sitm.CoverType,
                                CoverSize = Sitm.CoverSize,
                                bto = Sitm.bto,
                                UserName = Sitm.UserName,
                                UserDate = Sitm.UserDate,
                                Qty2 = Sitm.Qty2,
                                ShipType = Sitm.shipType,
                                sitm = Sitm.sitm,
                                Customer = Sitm.Customer,
                                CustomerAmount = Sitm.CustomerAmount,
                                Transit = Sitm.Transit,
                                CardHolder = Sitm.CardHolder,
                                CardNo = Sitm.CardNo,
                                CardType = Sitm.CardType,
                                DropLat = Sitm.DropLat,
                                DropLong = Sitm.DropLong,
                                Expiry = Sitm.Expiry,
                                PayType = Sitm.PayType,
                                PickLat = Sitm.PickLat,
                                PickLong = Sitm.PickLong,
                                PromoCode = Sitm.PromoCode,
                                Status = Sitm.Status,
                                IDdriver = Sitm.IDdriver,
                                CancelReason = Sitm.CancelReason,
                                CustRate = Sitm.CustRate,
                                Rate = Sitm.Rate,
                                ArrivingTime = Sitm.ArrivingTime,
                                DeliveredDate = Sitm.DeliveredDate,
                                RateNote = Sitm.RateNote,
                                RateReason = Sitm.RateReason,
                                OrDateTime = Sitm.OrDateTime,
                                DriverNote = Sitm.DriverNote,
                                DriverNote2 = Sitm.DriverNote2,
                                IDDriver2 = Sitm.IDDriver2,
                                OrderIssue = Sitm.OrderIssue,
                                OrderIssue2 = Sitm.OrderIssue2,
                                Rate2 = Sitm.Rate2,
                                Reward1 = Sitm.Reward1,
                                Reward2 = Sitm.Reward2,
                                Penal1 = Sitm.Penal1,
                                Penal2 = Sitm.Penal2,
                                Earn1 = Sitm.Earn1,
                                Earn2 = Sitm.Earn2                                 
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Find Shipment in Shipment Table
        /// </summary>
        /// <returns>null</returns>
        public Shipment Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShipmentFind(Branch, VouLoc, VouNo);
                    return (from sitm in result
                            select new Shipment
                            {
                                Branch = sitm.Branch,
                                VouLoc = sitm.VouLoc,
                                VouNo = sitm.VouNo,
                                FTime = sitm.FTime,
                                Name = sitm.Name,
                                IDNo = sitm.IDNo,
                                IDType = sitm.IDType,
                                IDFrom = sitm.IDFrom,
                                IDDate = sitm.IDDate,
                                Address = sitm.Address,
                                MobileNo = sitm.MobileNo,
                                Mail = sitm.Mail,
                                PlaceofLoading = sitm.PlaceofLoading,
                                Destination = sitm.Destination,
                                RecName = sitm.RecName,
                                RecAddress = sitm.RecAddress,
                                RecMobileNo = sitm.RecMobileNo,
                                CashAmount = sitm.CashAmount,
                                RecMail = sitm.RecMail,
                                Qty = sitm.Qty,
                                PlaceFrom = sitm.PlaceFrom,
                                Weight = sitm.Weight,
                                SiteAmount = sitm.SiteAmount,
                                Unit = sitm.Unit,
                                ShUse = sitm.ShUse,
                                Site = sitm.Site,
                                ShType = sitm.ShType,
                                ShRemark = sitm.ShRemark,
                                ShNote = sitm.ShNote,
                                ShabakaAmount = sitm.ShabakaAmount,
                                Amount = sitm.Amount,
                                LocFrom = sitm.LocFrom,
                                LocTo = sitm.LocTo,
                                DPeriod = sitm.DPeriod,
                                HDate = sitm.HDate,
                                GDate = sitm.GDate,
                                VouLoc2 = sitm.VouLoc2,
                                CoverType = sitm.CoverType,
                                CoverSize = sitm.CoverSize,
                                bto = sitm.bto,
                                UserName = sitm.UserName,
                                UserDate = sitm.UserDate,
                                Qty2 = sitm.Qty2,
                                ShipType = sitm.shipType,
                                sitm = sitm.sitm,
                                Customer = sitm.Customer,
                                CustomerAmount = sitm.CustomerAmount,
                                Transit = sitm.Transit,
                                CardHolder = sitm.CardHolder,
                                CardNo = sitm.CardNo,
                                CardType = sitm.CardType,
                                DropLat = sitm.DropLat,
                                DropLong = sitm.DropLong,
                                Expiry = sitm.Expiry,
                                PayType = sitm.PayType,
                                PickLat = sitm.PickLat,
                                PickLong = sitm.PickLong,
                                PromoCode = sitm.PromoCode,
                                Status = sitm.Status,
                                IDdriver = sitm.IDdriver,
                                CancelReason = sitm.CancelReason,
                                CustRate = sitm.CustRate,
                                Rate = sitm.Rate,
                                ArrivingTime = sitm.ArrivingTime,
                                DeliveredDate = sitm.DeliveredDate,
                                RateNote = sitm.RateNote,
                                RateReason = sitm.RateReason,
                                OrDateTime = sitm.OrDateTime,
                                DriverNote = sitm.DriverNote,
                                DriverNote2 = sitm.DriverNote2,
                                IDDriver2 = sitm.IDDriver2,
                                OrderIssue = sitm.OrderIssue,
                                OrderIssue2 = sitm.OrderIssue2,
                                Rate2 = sitm.Rate2,
                                Reward1 = sitm.Reward1,
                                Reward2 = sitm.Reward2,
                                Penal1 = sitm.Penal1,
                                Penal2 = sitm.Penal2,
                                Earn1 = sitm.Earn1,
                                Earn2 = sitm.Earn2,
                                CNN = ConnectionStr 
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Get Shipments By Destination from Shipment Table
        /// </summary>
        /// <returns>null</returns>
        public List<Shipment> FindByDestination(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShipmentGetByDestination(Destination);
                    return (from sitm in result
                            select new Shipment
                            {
                                Branch = sitm.Branch,
                                VouLoc = sitm.VouLoc,
                                VouNo = sitm.VouNo,
                                FTime = sitm.FTime,
                                Name = sitm.Name,
                                IDNo = sitm.IDNo,
                                IDType = sitm.IDType,
                                IDFrom = sitm.IDFrom,
                                IDDate = sitm.IDDate,
                                Address = sitm.Address,
                                MobileNo = sitm.MobileNo,
                                Mail = sitm.Mail,
                                PlaceofLoading = sitm.PlaceofLoading,
                                Destination = sitm.Destination,
                                RecName = sitm.RecName,
                                RecAddress = sitm.RecAddress,
                                RecMobileNo = sitm.RecMobileNo,
                                CashAmount = sitm.CashAmount,
                                RecMail = sitm.RecMail,
                                Qty = sitm.Qty,
                                PlaceFrom = sitm.PlaceFrom,
                                Weight = sitm.Weight,
                                SiteAmount = sitm.SiteAmount,
                                Unit = sitm.Unit,
                                ShUse = sitm.ShUse,
                                Site = sitm.Site,
                                ShType = sitm.ShType,
                                ShRemark = sitm.ShRemark,
                                ShNote = sitm.ShNote,
                                ShabakaAmount = sitm.ShabakaAmount,
                                Amount = sitm.Amount,
                                LocFrom = sitm.LocFrom,
                                LocTo = sitm.LocTo,
                                DPeriod = sitm.DPeriod,
                                HDate = sitm.HDate,
                                GDate = sitm.GDate,
                                VouLoc2 = sitm.VouLoc2,
                                CoverType = sitm.CoverType,
                                CoverSize = sitm.CoverSize,
                                bto = sitm.bto,
                                UserName = sitm.UserName,
                                UserDate = sitm.UserDate,
                                Qty2 = sitm.Qty2,
                                ShipType = sitm.shipType,
                                sitm = sitm.sitm,
                                Customer = sitm.Customer,
                                CustomerAmount = sitm.CustomerAmount,
                                Transit = sitm.Transit,
                                CardHolder = sitm.CardHolder,
                                CardNo = sitm.CardNo,
                                CardType = sitm.CardType,
                                DropLat = sitm.DropLat,
                                DropLong = sitm.DropLong,
                                Expiry = sitm.Expiry,
                                PayType = sitm.PayType,
                                PickLat = sitm.PickLat,
                                PickLong = sitm.PickLong,
                                PromoCode = sitm.PromoCode,
                                Status = sitm.Status,
                                IDdriver = sitm.IDdriver,
                                CancelReason = sitm.CancelReason,
                                CustRate = sitm.CustRate,
                                Rate = sitm.Rate,
                                ArrivingTime = sitm.ArrivingTime,
                                DeliveredDate = sitm.DeliveredDate,
                                RateNote = sitm.RateNote,
                                RateReason = sitm.RateReason,
                                OrDateTime = sitm.OrDateTime,
                                DriverNote = sitm.DriverNote,
                                DriverNote2 = sitm.DriverNote2,
                                IDDriver2 = sitm.IDDriver2,
                                OrderIssue = sitm.OrderIssue,
                                OrderIssue2 = sitm.OrderIssue2,
                                Rate2 = sitm.Rate2,
                                Reward1 = sitm.Reward1,
                                Reward2 = sitm.Reward2,
                                Penal1 = sitm.Penal1,
                                Penal2 = sitm.Penal2,
                                Earn1 = sitm.Earn1,
                                Earn2 = sitm.Earn2                                 
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<myInv2> GetInvMove(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vShipment2GetMove(this.Branch, this.VouLoc);
                    return (from itm in result
                            select new myInv2
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                // VouType = itm.VouType,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                Amount = itm.Amount,
                                // Amount2 = itm.Amount2,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                Site = itm.Site,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = (short?)itm.Qty,
                                Qty2 = (short)itm.Qty2,
                                Status = false,
                                CustomerName1 = itm.CustomerName1,
                                CustomerName2 = itm.CustomerName2,
                                DestinationName1 = itm.DestinationName1,
                                DestinationName2 = itm.DestinationName2,
                                PlaceofLoadingName1 = itm.PlaceofLoadingName1,
                                PlaceofLoadingName2 = itm.PlaceofLoadingName2,
                                SiteName1 = itm.SiteName1,
                                SiteName2 = itm.SiteName2,
                                InvoiceVouLoc = itm.VouLoc,
                                // VouNo20 = itm.VouNo2,
                                FTime = itm.FTime,
                                Mail = itm.Mail,
                                RecMail = itm.RecMail,
                                PlaceFrom = itm.PlaceFrom,
                                Weight = itm.Weight,
                                Unit = itm.Unit,
                                ShUse = itm.ShUse,
                                ShType = itm.ShType,
                                ShRemark = itm.ShRemark,
                                ShNote = itm.ShNote,
                                ShabakaAmount = itm.ShabakaAmount,
                                LocFrom = itm.LocFrom,
                                LocTo = itm.LocTo,
                                DPeriod = itm.DPeriod,
                                VouLoc2 = itm.VouLoc2,
                                CoverType = itm.CoverType,
                                CoverSize = itm.CoverSize,
                                bto = itm.bto,
                                sitm = itm.sitm,
                                shipType = itm.shipType,
                                CashAmount = itm.CashAmount,
                                Flag = "E",
                                CarType = itm.ShRemark,
                                PlateNo = itm.Weight.ToString(),
                                Model = itm.ShNote,
                                //Transit = itm.Transit
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<myInv2> GetInvMove2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vShipment2GetMove2(this.Branch, this.VouLoc, this.Destination);
                    return (from itm in result
                            select new myInv2
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                Amount = itm.Amount,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CashAmount = itm.CashAmount,
                                Site = itm.Site,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = (short?)itm.Qty,
                                Qty2 = (short?)itm.Qty2,
                                Status = false,
                                CustomerName1 = itm.CustomerName1,
                                CustomerName2 = itm.CustomerName2,
                                DestinationName1 = itm.DestinationName1,
                                DestinationName2 = itm.DestinationName2,
                                PlaceofLoadingName1 = itm.PlaceofLoadingName1,
                                PlaceofLoadingName2 = itm.PlaceofLoadingName2,
                                SiteName1 = itm.SiteName1,
                                SiteName2 = itm.SiteName2,
                                InvoiceVouLoc = itm.VouLoc,
                                FTime = itm.FTime,
                                //Transit = itm.Transit
                                Mail = itm.Mail,
                                RecMail = itm.RecMail,
                                PlaceFrom = itm.PlaceFrom,
                                Weight = itm.Weight,
                                Unit = itm.Unit,
                                ShUse = itm.ShUse,
                                ShType = itm.ShType,
                                ShRemark = itm.ShRemark,
                                ShNote = itm.ShNote,
                                ShabakaAmount = itm.ShabakaAmount,
                                LocFrom = itm.LocFrom,
                                LocTo = itm.LocTo,
                                DPeriod = itm.DPeriod,
                                VouLoc2 = itm.VouLoc2,
                                CoverType = itm.CoverType,
                                CoverSize = itm.CoverSize,
                                bto = itm.bto,
                                sitm = itm.sitm,
                                shipType = itm.shipType,
                                Flag = "E",
                                CarType = itm.ShRemark,
                                PlateNo = itm.Weight.ToString(),
                                Model = itm.ShNote
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<myInv2> GetInvMove3(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vShipment2GetMove3(this.Branch, this.VouLoc, this.PlaceofLoading);
                    return (from itm in result
                            select new myInv2
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                Amount = itm.Amount,
                                InvoiceFNo = 1,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CashAmount = itm.CashAmount,
                                Site = itm.Site,
                                SiteAmount = itm.SiteAmount,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = (short?)itm.Qty,
                                Qty2 = (short?)itm.Qty2,
                                Status = false,
                                CustomerName1 = itm.CustomerName1,
                                CustomerName2 = itm.CustomerName2,
                                DestinationName1 = itm.DestinationName1,
                                DestinationName2 = itm.DestinationName2,
                                PlaceofLoadingName1 = itm.PlaceofLoadingName1,
                                PlaceofLoadingName2 = itm.PlaceofLoadingName2,
                                SiteName1 = itm.SiteName1,
                                SiteName2 = itm.SiteName2,
                                InvoiceVouLoc = itm.VouLoc,
                                FTime = itm.FTime,
                                //Transit = itm.Transit
                                Mail = itm.Mail,
                                RecMail = itm.RecMail,
                                PlaceFrom = itm.PlaceFrom,
                                Weight = itm.Weight,
                                Unit = itm.Unit,
                                ShUse = itm.ShUse,
                                ShType = itm.ShType,
                                ShRemark = itm.ShRemark,
                                ShNote = itm.ShNote,
                                ShabakaAmount = itm.ShabakaAmount,
                                LocFrom = itm.LocFrom,
                                LocTo = itm.LocTo,
                                DPeriod = itm.DPeriod,
                                VouLoc2 = itm.VouLoc2,
                                CoverType = itm.CoverType,
                                CoverSize = itm.CoverSize,
                                bto = itm.bto,
                                sitm = itm.sitm,
                                shipType = itm.shipType,
                                Flag = "E",
                                CarType = itm.ShRemark,
                                PlateNo = itm.Weight.ToString(),
                                Model = itm.ShNote,
                                SLat = itm.PickLat,
                                SLong = itm.PickLong                                
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Get New Invoice No from Invoice Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public int? GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShipmentMaxCode(this.Branch, this.VouLoc);
                    return (from Cat in result
                            select Cat.myCode).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}