using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class LShipment
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
        public System.Nullable<short> Status { get; set; }
        public double? Tax { get; set; }
        public double? Discount { get; set; }
        public string DiscountTerm { get; set; }

        public LShipment()
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
            this.Status = 0;
            this.Tax = 0;
            this.Discount = 0;
            this.DiscountTerm = "";
        }




        /// <summary>
        /// Add Shipment in Shipment Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        /// 
        public bool Add(string ConnectionStr, string IncomeAcc, string CashAcc, string ShabakaAcc, string SiteAcc, string Area, string Project, string SiteCode, string Shabaka)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.LShipmentAdd(this.Branch,
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
                                            IncomeAcc, CashAcc, ShabakaAcc, SiteAcc, Area, Project, SiteCode, Shabaka,this.Tax,this.Discount,this.DiscountTerm);
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
                    myContext.LShipmentStatusUpdate(this.Branch,
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
        /// Update Shipment in Shipment Table
        /// </summary>
        /// <returns>True if Shipment Success or False if Fail</returns>

        public bool Update(string ConnectionStr, string IncomeAcc, string CashAcc, string ShabakaAcc, string SiteAcc, string Area, string Project, string SiteCode, string Shabaka)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.LShipmentUpdate(this.Branch,
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
                                            IncomeAcc, CashAcc, ShabakaAcc, SiteAcc, Area, Project, SiteCode, Shabaka,this.Tax,this.Discount,this.DiscountTerm);
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
                    myContext.LShipmentDelete(Branch, VouLoc, VouNo);
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
        public List<LShipment> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.LShipmentGetAll();
                    return (from Sitm in result
                            select new LShipment
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
                                Tax = Sitm.Tax,
                                Discount = Sitm.Discount,
                                DiscountTerm = Sitm.DiscountTerm                                 
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
        public List<LShipment> GetByRecMobileNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.LShipmentGetByRecMobileNo(this.RecMobileNo);
                    return (from Sitm in result
                            select new LShipment
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
                                Tax = Sitm.Tax,
                                Discount = Sitm.Discount,
                                DiscountTerm = Sitm.DiscountTerm                                 
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<LShipment> GetStatement(string ConnectionStr, string FDate, string EDate)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.LShipmentStatement(this.Branch, this.VouLoc, FDate, EDate);
                    return (from Sitm in result
                            select new LShipment
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
                                Tax = Sitm.Tax,
                                Discount = Sitm.Discount,
                                DiscountTerm = Sitm.DiscountTerm                                                                  
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
        public List<LShipment> GetByMobileNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.LShipmentGetByMobileNo(this.MobileNo);
                    return (from Sitm in result
                            select new LShipment
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
                                Tax = Sitm.Tax,
                                Discount = Sitm.Discount,
                                DiscountTerm = Sitm.DiscountTerm                                 
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
        public List<LShipment> GetByIDNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.LShipmentGetByIDNo(this.IDNo);
                    return (from Sitm in result
                            select new LShipment
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
                                Tax = Sitm.Tax,
                                Discount = Sitm.Discount,
                                DiscountTerm = Sitm.DiscountTerm                                 
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
        public List<LShipment> GetByName(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.LShipmentGetByName(this.Name);
                    return (from Sitm in result
                            select new LShipment
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
                                Tax = Sitm.Tax,
                                Discount = Sitm.Discount,
                                DiscountTerm = Sitm.DiscountTerm                                 
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
        public List<LShipment> GetByRecName(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.LShipmentGetByRecName(this.RecName);
                    return (from Sitm in result
                            select new LShipment
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
                                Tax = Sitm.Tax,
                                Discount = Sitm.Discount,
                                DiscountTerm = Sitm.DiscountTerm                                 
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
        public LShipment Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.LShipmentFind(Branch, VouLoc, VouNo);
                    return (from sitm in result
                            select new LShipment
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
                                Tax = sitm.Tax,
                                Discount = sitm.Discount,
                                DiscountTerm = sitm.DiscountTerm                                 
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
        public List<LShipment> FindByDestination(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.LShipmentGetByDestination(Destination);
                    return (from sitm in result
                            select new LShipment
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
                                Tax = sitm.Tax,
                                Discount = sitm.Discount,
                                DiscountTerm = sitm.DiscountTerm                                 
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
                    var result = myContext.LShipmentMaxCode(this.Branch, this.VouLoc);
                    return (from Cat in result
                            select Cat.myCode).FirstOrDefault();
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
                    var result = myContext.vLShipment2GetMove(this.Branch, this.VouLoc);
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
                                InvoiceFNo = itm.FNo,
                                FNo2 = itm.FNo,
                                FTime = itm.FTime,
                                Price = itm.Price,
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
                                ItemName = itm.ItemName,
                                ItemQty = itm.ItemQty,
                                CashAmount = itm.CashAmount,
                                Flag = "L",
                                CarType = itm.ItemName,
                                PlateNo = itm.ItemQty.ToString(),
                                //Tax = itm.Tax,
                                //Discount = itm.Discount,
                                //DiscountTerm = itm.DiscountTerm                                 
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
                    var result = myContext.vLShipment2GetMove2(this.Branch, this.VouLoc, this.Destination);
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
                                InvoiceFNo = itm.FNo,
                                FNo2 = itm.FNo,
                                FTime = itm.FTime,
                                //Transit = itm.Transit
                                Price = itm.Price,
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
                                ItemName = itm.ItemName,
                                ItemQty = itm.ItemQty,
                                Flag = "L",
                                CarType = itm.ItemName,
                                PlateNo = itm.ItemQty.ToString()
                                //Tax = sitm.Tax,
                                //Discount = sitm.Discount,
                                //DiscountTerm = sitm.DiscountTerm                                 
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
                    var result = myContext.vLShipment2GetMove3(this.Branch, this.VouLoc, this.PlaceofLoading);
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
                                InvoiceFNo = itm.FNo,
                                FNo2 = itm.FNo,
                                FTime = itm.FTime,
                                //Transit = itm.Transit
                                Price = itm.Price,
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
                                ItemName = itm.ItemName,
                                ItemQty = itm.ItemQty,
                                Flag = "L",
                                CarType = itm.ItemName,
                                PlateNo = itm.ItemQty.ToString()
                                //Tax = sitm.Tax,
                                //Discount = sitm.Discount,
                                //DiscountTerm = sitm.DiscountTerm                                 
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


    }


    [Serializable]
    public class ShipDetails
    {
        public short Branch { get; set; }
        public string VouLoc { get; set; }
        public int VouNo { get; set; }
        public short FNo { get; set; }
        public string Name { get; set; }
        public int? Qty { get; set; }
        public double? Price { get; set; }
        public bool? Transit { get; set; }

        public ShipDetails()
        {
            this.Branch = 1;
            this.VouLoc = "";
            this.VouNo = 0;
            this.FNo = 0;
            this.Name = "";
            this.Qty = 0;
            this.Price = 0;
            this.Transit = false;
        }

        /// <summary>
        /// Add Shipment in Shipment Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        /// 
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShipDetailsAdd(this.Branch,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.FNo,
                                            this.Name,
                                            this.Qty,
                                            this.Price,
                                            this.Transit);
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
                    myContext.ShipDetailsUpdateTransit(this.Branch,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.FNo,
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
        /// Delete Shipment in Shipment Table
        /// </summary>
        /// <returns>True if Delete Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShipDetailsDelete(Branch, VouLoc, VouNo);
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
        public List<ShipDetails> Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShipDetailsGet(Branch, VouLoc, VouNo);
                    return (from sitm in result
                            select new ShipDetails
                            {
                                Branch = sitm.Branch,
                                VouLoc = sitm.VouLoc,
                                VouNo = sitm.VouNo,
                                FNo = sitm.FNo,
                                Name = sitm.Name,
                                Price = sitm.Price,
                                Qty = sitm.Qty,
                                Transit = sitm.Transit
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
        public ShipDetails GetFNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShipDetailsGetFNo(this.Branch, this.VouLoc, this.VouNo,this.FNo);
                    return (from sitm in result
                            select new ShipDetails
                            {
                                Branch = sitm.Branch,
                                VouLoc = sitm.VouLoc,
                                VouNo = sitm.VouNo,
                                FNo = sitm.FNo,
                                Name = sitm.Name,
                                Price = sitm.Price,
                                Qty = sitm.Qty,
                                Transit = sitm.Transit
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
