using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class ShipOnLine
    {
        public short Branch { get; set; }
        public string VouLoc { get; set; }
        public int VouNo { get; set; }
        public string FTime { get; set; }
        public string Name { get; set; }
        public string IDNo { get; set; }
        public System.Nullable<short> IDType { get; set; }
        public string IDFrom { get; set; }
        public string IDDate { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Mail { get; set; }
        public string PlaceofLoading { get; set; }
        public string Destination { get; set; }
        public string RecName { get; set; }
        public string RecAddress { get; set; }
        public string RecMobileNo { get; set; }
        public System.Nullable<double> CashAmount { get; set; }
        public System.Nullable<double> RecCash { get; set; }
        public string RecMail { get; set; }
        public System.Nullable<int> Qty { get; set; }
        public System.Nullable<bool> PlaceFrom { get; set; }
        public System.Nullable<double> Weight { get; set; }
        public System.Nullable<double> SiteAmount { get; set; }
        public System.Nullable<short> Unit { get; set; }
        public string Site { get; set; }
        public System.Nullable<short> ShUse { get; set; }
        public System.Nullable<short> ShType { get; set; }
        public string ShRemark { get; set; }
        public string ShNote { get; set; }
        public System.Nullable<double> ShabakaAmount { get; set; }
        public System.Nullable<double> Amount { get; set; }
        public string LocFrom { get; set; }
        public string LocTo { get; set; }
        public System.Nullable<short> DPeriod { get; set; }
        public string HDate { get; set; }
        public string GDate { get; set; }
        public string VouLoc2 { get; set; }
        public System.Nullable<short> CoverType { get; set; }
        public System.Nullable<short> CoverSize { get; set; }
        public System.Nullable<bool> bto { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public System.Nullable<int> Qty2 { get; set; }
        public System.Nullable<short> sitm { get; set; }
        public string Customer { get; set; }
        public System.Nullable<double> CustomerAmount { get; set; }
        public System.Nullable<short> shipType { get; set; }
        public System.Nullable<short> OrderType { get; set; }
        public System.Nullable<short> PartAddrType { get; set; }
        public string OrDatetime { get; set; }
        public System.Nullable<short> Status { get; set; }
        public System.Nullable<short> CreateType { get; set; }
        public string RecIDNo { get; set; }
        public string RLat { get; set; }
        public string RLng { get; set; }
        public string SLat { get; set; }
        public string SLng { get; set; }
        public string NewVouNo { get; set; }
        public System.Nullable<double> Tax { get; set; }
        public System.Nullable<double> Discount { get; set; }
        public string DiscountTerm { get; set; }
        public string PickLat { get; set; }
        public string PickLong { get; set; }
        public string DropLat { get; set; }
        public string DropLong { get; set; }
        public string PromoCode { get; set; }
        public short? CardType { get; set; }
        public short? PayType { get; set; }
        public string CardNo { get; set; }
        public string CardHolder { get; set; }
        public string Expiry { get; set; }
        public string IDdriver { get; set; }
        public short? Rate { get; set; }
        public short? CustRate { get; set; }
        public int? CancelReason { get; set; }
        public string DeliveredDate { get; set; }
        public string ArrivingTime { get; set; }
        public string RateNote { get; set; }
        public System.Nullable<int> RateReason { get; set; }
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
                return "21" + this.VouNo.ToString();
            }
        }


        public ShipOnLine()
        {
            this.Branch = 1;
            this.VouLoc = "00000";
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
            this.RecName = "";
            this.RecAddress = "";
            this.RecMobileNo = "";
            this.CashAmount = 0;
            this.RecCash = 0;
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
            this.LocFrom = "";
            this.LocTo = "";
            this.DPeriod = 0;
            this.HDate = "";
            this.GDate = "";
            this.VouLoc2 = "";
            this.CoverType = 0;
            this.CoverSize = 0;
            this.bto = false;
            this.UserName = "";
            this.UserDate = "";
            this.Qty2 = 0;
            this.sitm = 0;
            this.Customer = "";
            this.CustomerAmount = 0;
            this.shipType = 0;
            this.OrderType = 0;
            this.PartAddrType = 0;
            this.OrDatetime = "";
            this.Status = 0;
            this.CreateType = 0;
            this.RecIDNo = "";
            this.RLat = "";
            this.RLng = "";
            this.SLat = "";
            this.SLng = "";
            this.NewVouNo = "0";
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
            this.CardNo = "";
            this.CardHolder = "";
            this.Expiry = "";
            this.IDdriver = "";
            this.Rate = -1;
            this.CustRate = -1;
            this.CancelReason = -1;
            this.DeliveredDate = "";
            this.ArrivingTime = "";
            this.RateNote = "";
            this.RateReason = -1;
        }

        /// <summary>
        /// Add Area in Area Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.ShipOnLineInsert( this.Branch,
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
                                                this.RecCash,
                                                this.RecMail,
                                                this.Qty,
                                                this.PlaceFrom,
                                                this.Weight,
                                                this.SiteAmount,
                                                this.Unit,
                                                this.Site,
                                                this.ShUse,
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
                                                this.Customer,
                                                this.CustomerAmount,
                                                this.shipType,
                                                this.OrderType,
                                                this.PartAddrType,
                                                this.OrDatetime,
                                                this.Status,
                                                this.CreateType,
                                                this.RecIDNo,
                                                this.RLat,
                                                this.RLng,
                                                this.SLat,
                                                this.SLng,
                                                this.NewVouNo,
                                                this.Tax,
                                                this.Discount,
                                                this.DiscountTerm,
                                                this.PickLat, this.PickLong, this.DropLat, this.DropLong, this.PromoCode, this.CardType, this.PayType, this.CardNo, this.CardHolder, this.Expiry, this.IDdriver, this.Rate, this.CustRate, this.CancelReason,
                                                this.DeliveredDate,
                                                this.ArrivingTime,
                                                this.RateNote,
                                                this.RateReason);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Area from Area Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.ShipOnLineDelete(this.Branch, this.VouLoc,this.VouNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Area in Area Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.ShipOnLineUpdate(this.Branch,
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
                                                this.RecCash,
                                                this.RecMail,
                                                this.Qty,
                                                this.PlaceFrom,
                                                this.Weight,
                                                this.SiteAmount,
                                                this.Unit,
                                                this.Site,
                                                this.ShUse,
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
                                                this.Customer,
                                                this.CustomerAmount,
                                                this.shipType,
                                                this.OrderType,
                                                this.PartAddrType,
                                                this.OrDatetime,
                                                this.Status,
                                                this.CreateType,
                                                this.RecIDNo,
                                                this.RLat,
                                                this.RLng,
                                                this.SLat,
                                                this.SLng,
                                                this.Tax,
                                                this.Discount,
                                                this.DiscountTerm,
                                                this.PickLat, this.PickLong, this.DropLat, this.DropLong, this.PromoCode, this.CardType, this.PayType, this.CardNo, this.CardHolder, this.Expiry, this.IDdriver, this.Rate, this.CustRate, this.CancelReason,
                                                this.DeliveredDate,
                                                this.ArrivingTime,
                                                this.RateNote,
                                                this.RateReason);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Area in Area Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Post(string InvNo,string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.ShipOnLinePost(this.Branch,this.VouLoc,this.VouNo,InvNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Update Area in Area Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool StatusUpdate(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.ShipOnLineStatusUpdate(this.Branch,
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
        /// Update Area in Area Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool StatusDriverUpdate(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.ShipOnLineStatusDriverUpdate(this.Branch,
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
        /// Update Area in Area Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool doCancel(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.ShipOnLineCancel(this.Branch,
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
        /// select  Cost Acc  from CostAcc Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public ShipOnLine find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipOnLineGet(this.Branch, this.VouLoc, this.VouNo);
                    return (from itm in result
                            select new ShipOnLine
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Mail = itm.Mail,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CashAmount = itm.CashAmount,
                                RecCash = itm.RecCash,
                                RecMail = itm.RecMail,
                                Qty = itm.Qty,
                                PlaceFrom = itm.PlaceFrom,
                                Weight = itm.Weight,
                                SiteAmount = itm.SiteAmount,
                                Unit = itm.Unit,
                                Site = itm.Site,
                                ShUse = itm.ShUse,
                                ShType = itm.ShType,
                                ShRemark = itm.ShRemark,
                                ShNote = itm.ShNote,
                                ShabakaAmount = itm.ShabakaAmount,
                                Amount = itm.Amount,
                                LocFrom = itm.LocFrom,
                                LocTo = itm.LocTo,
                                DPeriod = itm.DPeriod,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                VouLoc2 = itm.VouLoc2,
                                CoverType = itm.CoverType,
                                CoverSize = itm.CoverSize,
                                bto = itm.bto,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty2 = itm.Qty2,
                                sitm = itm.sitm,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                shipType = itm.shipType,
                                OrderType = itm.OrderType,
                                PartAddrType = itm.PartAddrType,
                                OrDatetime = itm.OrDatetime,
                                Status = itm.Status,
                                CreateType = itm.CreateType,
                                RecIDNo = itm.RecIDNo,
                                RLat = itm.Rlat,
                                RLng = itm.Rlng,
                                SLat = itm.Slat,
                                SLng = itm.Slng,
                                NewVouNo = itm.NewVouNo,
                                Tax = itm.Tax,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                CardHolder = itm.CardHolder,
                                CardNo = itm.CardNo,
                                CardType = itm.CardType,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Expiry = itm.Expiry,
                                PayType = itm.PayType,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong,
                                PromoCode = itm.PromoCode,
                                IDdriver = itm.IDdriver,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select  Cost Acc  from CostAcc Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<ShipOnLine> GetByUserName(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipOnLineGetByUserName(this.UserName);
                    return (from itm in result
                            select new ShipOnLine
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Mail = itm.Mail,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CashAmount = itm.CashAmount,
                                RecCash = itm.RecCash,
                                RecMail = itm.RecMail,
                                Qty = itm.Qty,
                                PlaceFrom = itm.PlaceFrom,
                                Weight = itm.Weight,
                                SiteAmount = itm.SiteAmount,
                                Unit = itm.Unit,
                                Site = itm.Site,
                                ShUse = itm.ShUse,
                                ShType = itm.ShType,
                                ShRemark = itm.ShRemark,
                                ShNote = itm.ShNote,
                                ShabakaAmount = itm.ShabakaAmount,
                                Amount = itm.Amount,
                                LocFrom = itm.LocFrom,
                                LocTo = itm.LocTo,
                                DPeriod = itm.DPeriod,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                VouLoc2 = itm.VouLoc2,
                                CoverType = itm.CoverType,
                                CoverSize = itm.CoverSize,
                                bto = itm.bto,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty2 = itm.Qty2,
                                sitm = itm.sitm,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                shipType = itm.shipType,
                                OrderType = itm.OrderType,
                                PartAddrType = itm.PartAddrType,
                                OrDatetime = itm.OrDatetime,
                                Status = itm.Status,
                                CreateType = itm.CreateType,
                                RecIDNo = itm.RecIDNo,
                                RLat = itm.Rlat,
                                RLng = itm.Rlng,
                                SLat = itm.Slat,
                                SLng = itm.Slng,
                                NewVouNo = itm.NewVouNo,
                                Tax = itm.Tax,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                CardHolder = itm.CardHolder,
                                CardNo = itm.CardNo,
                                CardType = itm.CardType,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Expiry = itm.Expiry,
                                PayType = itm.PayType,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong,
                                PromoCode = itm.PromoCode,                                 
                                IDdriver = itm.IDdriver,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select  Cost Acc  from CostAcc Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<ShipOnLine> GetByUserNameStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipOnLineGetByUserNameStatus(this.UserName,this.Status);
                    return (from itm in result
                            select new ShipOnLine
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Mail = itm.Mail,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CashAmount = itm.CashAmount,
                                RecCash = itm.RecCash,
                                RecMail = itm.RecMail,
                                Qty = itm.Qty,
                                PlaceFrom = itm.PlaceFrom,
                                Weight = itm.Weight,
                                SiteAmount = itm.SiteAmount,
                                Unit = itm.Unit,
                                Site = itm.Site,
                                ShUse = itm.ShUse,
                                ShType = itm.ShType,
                                ShRemark = itm.ShRemark,
                                ShNote = itm.ShNote,
                                ShabakaAmount = itm.ShabakaAmount,
                                Amount = itm.Amount,
                                LocFrom = itm.LocFrom,
                                LocTo = itm.LocTo,
                                DPeriod = itm.DPeriod,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                VouLoc2 = itm.VouLoc2,
                                CoverType = itm.CoverType,
                                CoverSize = itm.CoverSize,
                                bto = itm.bto,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty2 = itm.Qty2,
                                sitm = itm.sitm,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                shipType = itm.shipType,
                                OrderType = itm.OrderType,
                                PartAddrType = itm.PartAddrType,
                                OrDatetime = itm.OrDatetime,
                                Status = itm.Status,
                                CreateType = itm.CreateType,
                                RecIDNo = itm.RecIDNo,
                                RLat = itm.Rlat,
                                RLng = itm.Rlng,
                                SLat = itm.Slat,
                                SLng = itm.Slng,
                                NewVouNo = itm.NewVouNo,
                                Tax = itm.Tax,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select  Cost Acc  from CostAcc Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<ShipOnLine> GetByDriverStatus(string ConnectionStr, string driverCode1)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipOnLineGetByDriverStatus(driverCode1, this.Status);
                    return (from itm in result
                            select new ShipOnLine
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Mail = itm.Mail,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CashAmount = itm.CashAmount,
                                RecCash = itm.RecCash,
                                RecMail = itm.RecMail,
                                Qty = itm.Qty,
                                PlaceFrom = itm.PlaceFrom,
                                Weight = itm.Weight,
                                SiteAmount = itm.SiteAmount,
                                Unit = itm.Unit,
                                Site = itm.Site,
                                ShUse = itm.ShUse,
                                ShType = itm.ShType,
                                ShRemark = itm.ShRemark,
                                ShNote = itm.ShNote,
                                ShabakaAmount = itm.ShabakaAmount,
                                Amount = itm.Amount,
                                LocFrom = itm.LocFrom,
                                LocTo = itm.LocTo,
                                DPeriod = itm.DPeriod,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                VouLoc2 = itm.VouLoc2,
                                CoverType = itm.CoverType,
                                CoverSize = itm.CoverSize,
                                bto = itm.bto,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty2 = itm.Qty2,
                                sitm = itm.sitm,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                shipType = itm.shipType,
                                OrderType = itm.OrderType,
                                PartAddrType = itm.PartAddrType,
                                OrDatetime = itm.OrDatetime,
                                Status = itm.Status,
                                CreateType = itm.CreateType,
                                RecIDNo = itm.RecIDNo,
                                RLat = itm.Rlat,
                                RLng = itm.Rlng,
                                SLat = itm.Slat,
                                SLng = itm.Slng,
                                NewVouNo = itm.NewVouNo,
                                Tax = itm.Tax,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select  Cost Acc  from CostAcc Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<ShipOnLine> GetByStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipOnLineGetByStatus(this.Status);
                    return (from itm in result
                            select new ShipOnLine
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Mail = itm.Mail,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CashAmount = itm.CashAmount,
                                RecCash = itm.RecCash,
                                RecMail = itm.RecMail,
                                Qty = itm.Qty,
                                PlaceFrom = itm.PlaceFrom,
                                Weight = itm.Weight,
                                SiteAmount = itm.SiteAmount,
                                Unit = itm.Unit,
                                Site = itm.Site,
                                ShUse = itm.ShUse,
                                ShType = itm.ShType,
                                ShRemark = itm.ShRemark,
                                ShNote = itm.ShNote,
                                ShabakaAmount = itm.ShabakaAmount,
                                Amount = itm.Amount,
                                LocFrom = itm.LocFrom,
                                LocTo = itm.LocTo,
                                DPeriod = itm.DPeriod,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                VouLoc2 = itm.VouLoc2,
                                CoverType = itm.CoverType,
                                CoverSize = itm.CoverSize,
                                bto = itm.bto,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty2 = itm.Qty2,
                                sitm = itm.sitm,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                shipType = itm.shipType,
                                OrderType = itm.OrderType,
                                PartAddrType = itm.PartAddrType,
                                OrDatetime = itm.OrDatetime,
                                Status = itm.Status,
                                CreateType = itm.CreateType,
                                RecIDNo = itm.RecIDNo,
                                RLat = itm.Rlat,
                                RLng = itm.Rlng,
                                SLat = itm.Slat,
                                SLng = itm.Slng,
                                NewVouNo = itm.NewVouNo,
                                Tax = itm.Tax,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select  Cost Acc  from CostAcc Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<ShipOnLine> GetAll(string mySite,string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipOnLineGetAll(mySite);
                    return (from itm in result
                            select new ShipOnLine
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Mail = itm.Mail,
                                PlaceofLoading = itm.PlaceofLoading,
                                Destination = itm.Destination,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                CashAmount = itm.CashAmount,
                                RecCash = itm.RecCash,
                                RecMail = itm.RecMail,
                                Qty = itm.Qty,
                                PlaceFrom = itm.PlaceFrom,
                                Weight = itm.Weight,
                                SiteAmount = itm.SiteAmount,
                                Unit = itm.Unit,
                                Site = itm.Site,
                                ShUse = itm.ShUse,
                                ShType = itm.ShType,
                                ShRemark = itm.ShRemark,
                                ShNote = itm.ShNote,
                                ShabakaAmount = itm.ShabakaAmount,
                                Amount = itm.Amount,
                                LocFrom = itm.LocFrom,
                                LocTo = itm.LocTo,
                                DPeriod = itm.DPeriod,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                VouLoc2 = itm.VouLoc2,
                                CoverType = itm.CoverType,
                                CoverSize = itm.CoverSize,
                                bto = itm.bto,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty2 = itm.Qty2,
                                sitm = itm.sitm,
                                Customer = itm.Customer,
                                CustomerAmount = itm.CustomerAmount,
                                shipType = itm.shipType,
                                OrderType = itm.OrderType,
                                PartAddrType = itm.PartAddrType,
                                OrDatetime = itm.OrDatetime,
                                Status = itm.Status,
                                CreateType = itm.CreateType,
                                RecIDNo = itm.RecIDNo,
                                RLat = itm.Rlat,
                                RLng = itm.Rlng,
                                SLat = itm.Slat,
                                SLng = itm.Slng,
                                NewVouNo = itm.NewVouNo,
                                Tax = itm.Tax,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Get New Code for Area Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public int? GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipOnLineMaxCode(this.Branch,this.VouLoc);
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
