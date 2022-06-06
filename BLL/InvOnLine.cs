using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class InvOnLine
    {
        public short Branch { get; set; }
        public string VouLoc { get; set; }
        public int VouNo { get; set; }
        public System.Nullable<short> VouType { get; set; }
        public string HDate { get; set; }
        public string GDate { get; set; }
        public string Name { get; set; }
        public string IDNo { get; set; }
        public System.Nullable<short> IDType { get; set; }
        public string IDFrom { get; set; }
        public string IDDate { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string PlaceofLoading { get; set; }
        public string Destination { get; set; }
        public System.Nullable<double> Amount { get; set; }
        public string RecName { get; set; }
        public string RecAddress { get; set; }
        public string RecMobileNo { get; set; }
        public System.Nullable<double> CashAmount { get; set; }
        public string Site { get; set; }
        public System.Nullable<double> SiteAmount { get; set; }
        public string Customer { get; set; }
        public System.Nullable<double> CustomerAmount { get; set; }
        public System.Nullable<bool> Access1 { get; set; }
        public System.Nullable<bool> Access2 { get; set; }
        public System.Nullable<bool> Access4 { get; set; }
        public System.Nullable<bool> Access6 { get; set; }
        public string Remark1 { get; set; }
        public string Attached { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public System.Nullable<short> Qty { get; set; }
        public string FTime { get; set; }
        public System.Nullable<short> Payment { get; set; }
        public string Site2 { get; set; }
        public string Mail { get; set; }
        public string RecMail { get; set; }
        public string DiscountTerm { get; set; }
        public double? Discount { get; set; }
        public int? InvNo { get; set; }
        public string RetDate { get; set; }
        public short? ShipType { get; set; }
        public short? OrderType { get; set; }
        public short? PartaddrType { get; set; }
        public string OrDateTime { get; set; }
        public short? Status { get; set; }
        public short? CreateType { get; set; }
        public string RecIDNo { get; set; }
        public string RLat { get; set; }
        public string RLng { get; set; }
        public string SLat { get; set; }
        public string SLng { get; set; }
        public string NewVouNo { get; set; }
        public short? ShipType2 { get; set; }
        public double? Tax { get; set; }
        public string IDdriver { get; set; }
        public short? CardType { get; set; }
        public short? PayType { get; set; }
        public string CardNo { get; set; }
        public string CardHolder { get; set; }
        public string Expiry { get; set; }
        public string ServiceCode { get; set; }
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
                return "10" + this.VouLoc.Substring(3, 2) + this.VouNo.ToString();
            }
        }
        public string UIID
        {
            get
            {
                return "11" + this.VouNo.ToString();
            }
        }

        public InvOnLine()
        {
            this.Branch = 1;
            this.VouLoc = "";
            this.VouNo = 0;
            this.VouType = 0;
            this.HDate = "";
            this.GDate = "";
            this.Name = "";
            this.IDNo = "";
            this.IDType = 0;
            this.IDFrom = "";
            this.IDDate = "";
            this.Address = "";
            this.MobileNo = "";
            this.PlaceofLoading = "";
            this.Destination = "";
            this.Amount = 0;
            this.RecName = "";
            this.RecAddress = "";
            this.RecMobileNo = "";
            this.CashAmount = 0;
            this.Site = "";
            this.SiteAmount = 0;
            this.Customer = "";
            this.CustomerAmount = 0;
            this.Access1 = false;
            this.Access2 = false;
            this.Access4 = false;
            this.Access6 = false;
            this.Remark1 = "";
            this.Attached = "";
            this.UserName = "";
            this.UserDate = "";
            this.Qty = 1;
            this.FTime = String.Format("{0:HH:mm:ss}", moh.Nows());  //moh.Nows().ToShortTimeString();
            this.Payment = 0;
            this.Site2 = "";
            this.Mail = "";
            this.RecMail = "";
            this.DiscountTerm = "";
            this.Discount = 0;
            this.InvNo = 0;
            this.RetDate = "";
            this.ShipType = 0;
            this.OrderType = 0;
            this.PartaddrType = 0;
            this.OrDateTime = "";
            this.Status = 0;
            this.CreateType = 0;
            this.RecIDNo = "";
            this.RLat = "";
            this.RLng = "";
            this.SLat = "";
            this.SLng = "";
            this.NewVouNo = "0";
            this.ShipType2 = 0;
            this.Tax = 0;
            this.IDdriver = "";
            this.CardType = -1;
            this.PayType = -1;
            this.CardNo = "";
            this.CardHolder = "";
            this.Expiry = "";
            this.ServiceCode = "";
            this.Rate = -1;
            this.CustRate = -1;
            this.CancelReason = -1;
            this.DeliveredDate = "";
            this.ArrivingTime = "";
            this.RateNote = "";
            this.RateReason = -1;
        }

        /// <summary>
        /// Add Invoice center in Invoice Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.InvOnLineInsert(this.Branch,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.VouType,
                                            this.HDate,
                                            this.GDate,
                                            this.Name,
                                            this.IDNo,
                                            this.IDType,
                                            this.IDFrom,
                                            this.IDDate,
                                            this.Address,
                                            this.MobileNo,
                                            this.PlaceofLoading,
                                            this.Destination,
                                            this.Amount,
                                            this.RecName,
                                            this.RecAddress,
                                            this.RecMobileNo,
                                            this.CashAmount,
                                            this.Site,
                                            this.SiteAmount,
                                            this.Customer,
                                            this.CustomerAmount,
                                            this.Access1,
                                            this.Access2,
                                            this.Access4,
                                            this.Access6,
                                            this.Remark1,
                                            this.Attached,
                                            this.UserName,
                                            this.UserDate,
                                            this.Qty,
                                            this.FTime,
                                            this.Payment,
                                            this.Site2,
                                            this.Mail,
                                            this.RecMail,
                                            this.DiscountTerm,
                                            this.Discount,
                                            this.InvNo,
                                            this.ShipType,
                                            this.OrderType,
                                            this.PartaddrType,
                                            this.OrDateTime,
                                            this.Status,
                                            this.CreateType,
                                            this.RecIDNo,
                                            this.RLat,
                                            this.RLng,
                                            this.SLat,
                                            this.SLng,
                                            this.NewVouNo,
                                            this.ShipType2,
                                            this.Tax,
                                            this.IDdriver,
                                            this.CardType,
                                            this.PayType,
                                            this.CardNo,
                                            this.CardHolder,
                                            this.Expiry,
                                            this.ServiceCode, this.Rate, this.CustRate, this.CancelReason,
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
        /// Delete Invoice center from Invoice Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.InvOnLineDelete(this.Branch, this.VouLoc, this.VouNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Invoice center from Invoice Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Post(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.InvOnLinePost(this.Branch, this.VouLoc, this.VouNo,this.InvNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Invoice center in Invoice Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.InvOnLineUpdate(this.Branch,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.VouType,
                                            this.HDate,
                                            this.GDate,
                                            this.Name,
                                            this.IDNo,
                                            this.IDType,
                                            this.IDFrom,
                                            this.IDDate,
                                            this.Address,
                                            this.MobileNo,
                                            this.PlaceofLoading,
                                            this.Destination,
                                            this.Amount,
                                            this.RecName,
                                            this.RecAddress,
                                            this.RecMobileNo,
                                            this.CashAmount,
                                            this.Site,
                                            this.SiteAmount,
                                            this.Customer,
                                            this.CustomerAmount,
                                            this.Access1,
                                            this.Access2,
                                            this.Access4,
                                            this.Access6,
                                            this.Remark1,
                                            this.Attached,
                                            this.UserName,
                                            this.UserDate,
                                            this.Qty,
                                            this.FTime,
                                            this.Payment,
                                            this.Site2,
                                            this.Mail,
                                            this.RecMail,
                                            this.DiscountTerm,
                                            this.Discount,
                                            this.InvNo,
                                            this.ShipType,
                                            this.OrderType,
                                            this.PartaddrType,
                                            this.OrDateTime,
                                            this.Status,
                                            this.CreateType,
                                            this.RecIDNo,
                                            this.RLat,
                                            this.RLng,
                                            this.SLat,
                                            this.SLng,
                                            this.ShipType2,
                                            this.Tax,
                                            this.IDdriver,
                                            this.CardType,
                                            this.PayType,
                                            this.CardNo,
                                            this.CardHolder,
                                            this.Expiry,
                                            this.ServiceCode, this.Rate, this.CustRate, this.CancelReason,
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
        /// Update Invoice center in Invoice Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool UpdateStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.InvOnLineStatusUpdate(this.Branch,this.VouLoc,this.VouNo,this.Status);

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Invoice center in Invoice Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool UpdateStatusDriver(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.InvOnLineStatusDriverUpdate(this.Branch, this.VouLoc, this.VouNo, this.Status,this.IDdriver);

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Invoice center in Invoice Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool doCancel(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.InvOnLineCancel(this.Branch, this.VouLoc, this.VouNo, this.Status,this.CancelReason);

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public InvOnLine Find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.InvOnLineGet(this.Branch, this.VouLoc, this.VouNo);
                    return (from itm in result
                            select new InvOnLine
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
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
                                Access1 = itm.Access1,
                                Access2 = itm.Access2,
                                Access4 = itm.Access4,
                                Access6 = itm.Access6,
                                Remark1 = itm.Remark1,
                                Attached = itm.Attached,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = itm.Qty,
                                FTime = itm.FTime,
                                Payment = itm.Payment,
                                Site2 = itm.Site2,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                Mail = itm.Mail,
                                RecMail = itm.RecMail,
                                InvNo = itm.InvNo,
                                CreateType = itm.CreateType,
                                OrDateTime = itm.OrDateTime,
                                OrderType = itm.OrderType,
                                PartaddrType = itm.PartaddrType,
                                RetDate = itm.RetDate,
                                ShipType = itm.ShipType,
                                Status = itm.Status,
                                RecIDNo = itm.RecIDNo,
                                RLat = itm.Rlat,
                                RLng = itm.Rlng,
                                SLat = itm.Slat,
                                SLng = itm.Slng,
                                NewVouNo = itm.NewVouNo,
                                ShipType2 = itm.ShipType2,
                                Tax = itm.Tax,
                                CardHolder = itm.CardHolder,
                                CardNo = itm.CardNo,
                                CardType = itm.CardType,
                                Expiry = itm.Expiry,
                                IDdriver = itm.IDdriver,
                                PayType = itm.PayType,
                                ServiceCode = itm.ServiceCode,
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
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public InvOnLine FindByInvNo(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.InvOnLineGetByInvNo(this.Branch, this.VouLoc, this.Site,this.InvNo);
                    return (from itm in result
                            select new InvOnLine
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
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
                                Access1 = itm.Access1,
                                Access2 = itm.Access2,
                                Access4 = itm.Access4,
                                Access6 = itm.Access6,
                                Remark1 = itm.Remark1,
                                Attached = itm.Attached,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = itm.Qty,
                                FTime = itm.FTime,
                                Payment = itm.Payment,
                                Site2 = itm.Site2,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                Mail = itm.Mail,
                                RecMail = itm.RecMail,
                                InvNo = itm.InvNo,
                                CreateType = itm.CreateType,
                                OrDateTime = itm.OrDateTime,
                                OrderType = itm.OrderType,
                                PartaddrType = itm.PartaddrType,
                                RetDate = itm.RetDate,
                                ShipType = itm.ShipType,
                                Status = itm.Status,
                                RecIDNo = itm.RecIDNo,
                                RLat = itm.Rlat,
                                RLng = itm.Rlng,
                                SLat = itm.Slat,
                                SLng = itm.Slng,
                                NewVouNo = itm.NewVouNo,
                                ShipType2 = itm.ShipType2,
                                Tax = itm.Tax,
                                CardHolder = itm.CardHolder,
                                CardNo = itm.CardNo,
                                CardType = itm.CardType,
                                Expiry = itm.Expiry,
                                IDdriver = itm.IDdriver,
                                PayType = itm.PayType,
                                ServiceCode = itm.ServiceCode,
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
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<InvOnLine> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.InvOnLineGetAll(this.Branch, this.VouLoc, this.Site);
                    return (from itm in result
                            select new InvOnLine
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
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
                                Access1 = itm.Access1,
                                Access2 = itm.Access2,
                                Access4 = itm.Access4,
                                Access6 = itm.Access6,
                                Remark1 = itm.Remark1,
                                Attached = itm.Attached,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = itm.Qty,
                                FTime = itm.FTime,
                                Payment = itm.Payment,
                                Site2 = itm.Site2,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                Mail = itm.Mail,
                                RecMail = itm.RecMail,
                                InvNo = itm.InvNo,
                                CreateType = itm.CreateType,
                                OrDateTime = itm.OrDateTime,
                                OrderType = itm.OrderType,
                                PartaddrType = itm.PartaddrType,
                                RetDate = itm.RetDate,
                                ShipType = itm.ShipType,
                                Status = itm.Status,
                                RecIDNo = itm.RecIDNo,
                                RLat = itm.Rlat,
                                RLng = itm.Rlng,
                                SLat = itm.Slat,
                                SLng = itm.Slng,
                                NewVouNo = itm.NewVouNo,
                                ShipType2 = itm.ShipType2,
                                Tax = itm.Tax,
                                //ArrivingTime = itm.ArrivingTime,
                                //DeliveredDate = itm.DeliveredDate,
                                //RateNote = itm.RateNote,
                                //RateReason = itm.RateReason
                                //CancelReason = itm.CancelReason,
                                //CustRate = itm.CustRate,
                                //Rate = itm.Rate
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
        public List<InvOnLine> FindByUserName(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.InvOnLineGetByUserName(this.UserName);
                    return (from itm in result
                            select new InvOnLine
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
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
                                Access1 = itm.Access1,
                                Access2 = itm.Access2,
                                Access4 = itm.Access4,
                                Access6 = itm.Access6,
                                Remark1 = itm.Remark1,
                                Attached = itm.Attached,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = itm.Qty,
                                FTime = itm.FTime,
                                Payment = itm.Payment,
                                Site2 = itm.Site2,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                Mail = itm.Mail,
                                RecMail = itm.RecMail,
                                InvNo = itm.InvNo,
                                CreateType = itm.CreateType,
                                OrDateTime = itm.OrDateTime,
                                OrderType = itm.OrderType,
                                PartaddrType = itm.PartaddrType,
                                RetDate = itm.RetDate,
                                ShipType = itm.ShipType,
                                Status = itm.Status,
                                RecIDNo = itm.RecIDNo,
                                RLat = itm.Rlat,
                                RLng = itm.Rlng,
                                SLat = itm.Slat,
                                SLng = itm.Slng,
                                NewVouNo = itm.NewVouNo,
                                ShipType2 = itm.ShipType2,
                                Tax = itm.Tax,
                                CardHolder = itm.CardHolder,
                                CardNo = itm.CardNo,
                                CardType = itm.CardType,
                                Expiry = itm.Expiry,
                                IDdriver = itm.IDdriver,
                                PayType = itm.PayType,
                                ServiceCode = itm.ServiceCode,
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
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<InvOnLine> FindByStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.InvOnLineGetByStatus(this.Status);
                    return (from itm in result
                            select new InvOnLine
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
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
                                Access1 = itm.Access1,
                                Access2 = itm.Access2,
                                Access4 = itm.Access4,
                                Access6 = itm.Access6,
                                Remark1 = itm.Remark1,
                                Attached = itm.Attached,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = itm.Qty,
                                FTime = itm.FTime,
                                Payment = itm.Payment,
                                Site2 = itm.Site2,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                Mail = itm.Mail,
                                RecMail = itm.RecMail,
                                InvNo = itm.InvNo,
                                CreateType = itm.CreateType,
                                OrDateTime = itm.OrDateTime,
                                OrderType = itm.OrderType,
                                PartaddrType = itm.PartaddrType,
                                RetDate = itm.RetDate,
                                ShipType = itm.ShipType,
                                Status = itm.Status,
                                RecIDNo = itm.RecIDNo,
                                RLat = itm.Rlat,
                                RLng = itm.Rlng,
                                SLat = itm.Slat,
                                SLng = itm.Slng,
                                NewVouNo = itm.NewVouNo,
                                ShipType2 = itm.ShipType2,
                                Tax = itm.Tax,
                                CardHolder = itm.CardHolder,
                                CardNo = itm.CardNo,
                                CardType = itm.CardType,
                                Expiry = itm.Expiry,
                                IDdriver = itm.IDdriver,
                                PayType = itm.PayType,
                                ServiceCode = itm.ServiceCode,
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
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<InvOnLine> FindByUserNameStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.InvOnLineGetByUserNameStatus(this.UserName,this.Status);
                    return (from itm in result
                            select new InvOnLine
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
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
                                Access1 = itm.Access1,
                                Access2 = itm.Access2,
                                Access4 = itm.Access4,
                                Access6 = itm.Access6,
                                Remark1 = itm.Remark1,
                                Attached = itm.Attached,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = itm.Qty,
                                FTime = itm.FTime,
                                Payment = itm.Payment,
                                Site2 = itm.Site2,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                Mail = itm.Mail,
                                RecMail = itm.RecMail,
                                InvNo = itm.InvNo,
                                CreateType = itm.CreateType,
                                OrDateTime = itm.OrDateTime,
                                OrderType = itm.OrderType,
                                PartaddrType = itm.PartaddrType,
                                RetDate = itm.RetDate,
                                ShipType = itm.ShipType,
                                Status = itm.Status,
                                RecIDNo = itm.RecIDNo,
                                RLat = itm.Rlat,
                                RLng = itm.Rlng,
                                SLat = itm.Slat,
                                SLng = itm.Slng,
                                NewVouNo = itm.NewVouNo,
                                ShipType2 = itm.ShipType2,
                                Tax = itm.Tax,
                                CardHolder = itm.CardHolder,
                                CardNo = itm.CardNo,
                                CardType = itm.CardType,
                                Expiry = itm.Expiry,
                                IDdriver = itm.IDdriver,
                                PayType = itm.PayType,
                                ServiceCode = itm.ServiceCode,
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
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<InvOnLine> FindByDriverStatus(string ConnectionStr,string driverCode1)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.InvOnLineGetByDriverStatus(driverCode1, this.Status);
                    return (from itm in result
                            select new InvOnLine
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
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
                                Access1 = itm.Access1,
                                Access2 = itm.Access2,
                                Access4 = itm.Access4,
                                Access6 = itm.Access6,
                                Remark1 = itm.Remark1,
                                Attached = itm.Attached,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Qty = itm.Qty,
                                FTime = itm.FTime,
                                Payment = itm.Payment,
                                Site2 = itm.Site2,
                                Discount = itm.Discount,
                                DiscountTerm = itm.DiscountTerm,
                                Mail = itm.Mail,
                                RecMail = itm.RecMail,
                                InvNo = itm.InvNo,
                                CreateType = itm.CreateType,
                                OrDateTime = itm.OrDateTime,
                                OrderType = itm.OrderType,
                                PartaddrType = itm.PartaddrType,
                                RetDate = itm.RetDate,
                                ShipType = itm.ShipType,
                                Status = itm.Status,
                                RecIDNo = itm.RecIDNo,
                                RLat = itm.Rlat,
                                RLng = itm.Rlng,
                                SLat = itm.Slat,
                                SLng = itm.Slng,
                                NewVouNo = itm.NewVouNo,
                                ShipType2 = itm.ShipType2,
                                Tax = itm.Tax,
                                CardHolder = itm.CardHolder,
                                CardNo = itm.CardNo,
                                CardType = itm.CardType,
                                Expiry = itm.Expiry,
                                IDdriver = itm.IDdriver,
                                PayType = itm.PayType,
                                ServiceCode = itm.ServiceCode,
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
        /// Get New Invoice No from Invoice Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public int? GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.InvOnLineMaxCode(this.Branch, this.VouLoc);
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




