using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class WaterOnline
    {
        public short Branch { get; set; }
        public string VouLoc { get; set; }
        public int VouNo { get; set; }
        public string OrDateTime { get; set; }
        public string GDate { get; set; }
        public string HDate { get; set; }
        public string FTime { get; set; }
        public string Name { get; set; }
        public string IDNo { get; set; }
        public System.Nullable<short> IDType { get; set; }
        public string IDFrom { get; set; }
        public string IDDate { get; set; }
        public string MobileNo { get; set; }
        public string Mail { get; set; }
        public string IDUser { get; set; }
        public string IDdriver { get; set; }
        public string PickLat { get; set; }
        public string PickLong { get; set; }
        public System.Nullable<double> Price { get; set; }
        public System.Nullable<double> SerPrice { get; set; }
        public System.Nullable<short> Status { get; set; }
        public System.Nullable<short> WaterType { get; set; }
        public System.Nullable<short> DetailType { get; set; }
        public string Descr { get; set; }
        public System.Nullable<short> PayType { get; set; }
        public string Address { get; set; }
        public System.Nullable<short> CardType { get; set; }
        public string CardNo { get; set; }
        public string CardHolder { get; set; }
        public string Expiry { get; set; }
        public string Remark { get; set; }
        public string PromoCode { get; set; }
        public System.Nullable<double> Discount { get; set; }
        public System.Nullable<short> Rate { get; set; }
        public System.Nullable<int> Points { get; set; }
        public string NewVouNo { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public string DropLat { get; set; }
        public string DropLong { get; set; }
        public System.Nullable<double> Total { get; set; }
        public System.Nullable<double> Tax { get; set; }
        public System.Nullable<short> CustRate { get; set; }
        public System.Nullable<int> CancelReason { get; set; }
        public string DeliveredDate { get; set; }
        public string ArrivingTime { get; set; }
        public string RateNote { get; set; }
        public System.Nullable<int> RateReason { get; set; }
        public string OrderID
        {
            get
            {
                return "50" + this.VouLoc.Substring(3, 2) + this.VouNo.ToString();
            }
        }
        public string UIID
        {
            get
            {
                return "51" + this.VouNo.ToString();
            }
        }



        public WaterOnline()
        { 
            this.Branch = 1;
            this.VouLoc = "00000";
            this.VouNo = 0;
            this.OrDateTime = "";
            this.GDate = "";
            this.HDate = "";
            this.FTime = "";
            this.Name = "";
            this.IDNo = "";
            this.IDType = -1;
            this.IDFrom = "";
            this.IDDate = "";
            this.MobileNo = "";
            this.Mail = "";
            this.IDUser = "";
            this.IDdriver = "";
            this.PickLat = "";
            this.PickLong = "";
            this.Price = 0;
            this.SerPrice = 0;
            this.Status = 0;
            this.WaterType = 0;
            this.DetailType = 0;
            this.Descr = "";
            this.PayType = -1;
            this.Address = "";
            this.CardType = -1;
            this.CardNo = "";
            this.CardHolder = "";
            this.Expiry = "";
            this.Remark = "";
            this.PromoCode = "";
            this.Discount = 0;
            this.Rate = -1;
            this.Points = 0;
            this.NewVouNo = "";
            this.UserName = "";
            this.UserDate = "";
            this.DropLat = "";
            this.DropLong = "";
            this.Total = 0;
            this.Tax = 0;
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
                    myContext.WaterOnlineInsert(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
                                                this.OrDateTime,
                                                this.GDate,
                                                this.HDate,
                                                this.FTime,
                                                this.Name,
                                                this.IDNo,
                                                this.IDType,
                                                this.IDFrom,
                                                this.IDDate,
                                                this.MobileNo,
                                                this.Mail,
                                                this.IDUser,
                                                this.IDdriver,
                                                this.PickLat,
                                                this.PickLong,
                                                this.Price,
                                                this.SerPrice,
                                                this.Status,
                                                this.WaterType,
                                                this.DetailType,
                                                this.Descr,
                                                this.PayType,
                                                this.Address,
                                                this.CardType,
                                                this.CardNo,
                                                this.CardHolder,
                                                this.Expiry,
                                                this.Remark,
                                                this.PromoCode,
                                                this.Discount,
                                                this.Rate,
                                                this.Points,
                                                this.NewVouNo,
                                                this.UserName,
                                                this.UserDate,
                                                this.DropLat,
                                                this.DropLong,
                                                this.Total,
                                                this.Tax,
                                                this.CustRate,
                                                this.CancelReason,
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
                    myContext.WaterOnlineDelete(this.Branch, this.VouLoc, this.VouNo);
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
                    myContext.WaterOnlineUpdate(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
                                                this.OrDateTime,
                                                this.GDate,
                                                this.HDate,
                                                this.FTime,
                                                this.Name,
                                                this.IDNo,
                                                this.IDType,
                                                this.IDFrom,
                                                this.IDDate,
                                                this.MobileNo,
                                                this.Mail,
                                                this.IDUser,
                                                this.IDdriver,
                                                this.PickLat,
                                                this.PickLong,
                                                this.Price,
                                                this.SerPrice,
                                                this.Status,
                                                this.WaterType,
                                                this.DetailType,
                                                this.Descr,
                                                this.PayType,
                                                this.Address,
                                                this.CardType,
                                                this.CardNo,
                                                this.CardHolder,
                                                this.Expiry,
                                                this.Remark,
                                                this.PromoCode,
                                                this.Discount,
                                                this.Rate,
                                                this.Points,
                                                this.NewVouNo,
                                                this.UserName,
                                                this.UserDate,
                                                this.DropLat,
                                                this.DropLong,
                                                this.Total,
                                                this.Tax,
                                                this.CustRate,
                                                this.CancelReason,
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
        public bool StatusUpdate(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.WaterStatusUpdate(this.Branch,
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
        /// Update Invoice center in Invoice Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool UpdateStatusDriver(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.WaterOnLineStatusDriverUpdate(this.Branch, this.VouLoc, this.VouNo, this.Status, this.IDdriver);

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
        public bool UpdateDriver(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.WaterOnlineUpdateDriver(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
                                                this.IDdriver);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// post water in waterOnline Table
        /// </summary>
        /// <returns>True if Gas Success or False if Fail</returns>
        public bool PostWaterOnline(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.WaterOnlinePost(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
                                                this.NewVouNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }



        public List<WaterOnline> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.WaterOnlineGetAll(this.Branch, this.VouLoc);
                    return (from itm in result
                            select new WaterOnline
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                OrDateTime = itm.OrDateTime,
                                IDUser = itm.IDUser,
                                IDdriver = itm.IDdriver,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong,
                                Price = itm.Price,
                                SerPrice = itm.SerPrice,
                                Status = itm.Status,
                                WaterType = itm.WaterType,
                                DetailType = itm.DetailType,
                                PayType = itm.PayType,
                                Address = itm.Address,
                                CardType = itm.CardType,
                                CardNo = itm.CardNo,
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Discount = itm.Discount,
                                Rate = itm.Rate,
                                Points = itm.Points,
                                NewVouNo = itm.NewVouNo,
                                ArrivingTime = itm.ArrivingTime,
                                CancelReason = itm.CancelReason,
                                CardHolder = itm.CardHolder,
                                CustRate = itm.CustRate,
                                DeliveredDate = itm.DeliveredDate,
                                Descr = itm.Descr,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Expiry = itm.Expiry,
                                FTime = itm.FTime,
                                GDate = itm.GDate,
                                HDate = itm.HDate,
                                IDDate = itm.IDDate,
                                IDFrom = itm.IDFrom,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                Mail = itm.Mail,
                                MobileNo = itm.MobileNo,
                                Name = itm.Name,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                Tax = itm.Tax,
                                Total = itm.Total,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }




        public List<WaterOnline> GetByVouLoc(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.WaterOnlineGetByVouLoc(this.Branch, this.VouLoc);
                    return (from itm in result
                            select new WaterOnline
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                OrDateTime = itm.OrDateTime,
                                IDUser = itm.IDUser,
                                IDdriver = itm.IDdriver,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong,
                                Price = itm.Price,
                                SerPrice = itm.SerPrice,
                                Status = itm.Status,
                                WaterType = itm.WaterType,
                                DetailType = itm.DetailType,
                                PayType = itm.PayType,
                                Address = itm.Address,
                                CardType = itm.CardType,
                                CardNo = itm.CardNo,
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Discount = itm.Discount,
                                Rate = itm.Rate,
                                Points = itm.Points,
                                NewVouNo = itm.NewVouNo,
                                ArrivingTime = itm.ArrivingTime,
                                CancelReason = itm.CancelReason,
                                CardHolder = itm.CardHolder,
                                CustRate = itm.CustRate,
                                DeliveredDate = itm.DeliveredDate,
                                Descr = itm.Descr,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Expiry = itm.Expiry,
                                FTime = itm.FTime,
                                GDate = itm.GDate,
                                HDate = itm.HDate,
                                IDDate = itm.IDDate,
                                IDFrom = itm.IDFrom,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                Mail = itm.Mail,
                                MobileNo = itm.MobileNo,
                                Name = itm.Name,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                Tax = itm.Tax,
                                Total = itm.Total,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Account center from Area Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<WaterOnline> GetByUserID(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.WaterOnlineGetByUserID(this.IDUser);
                    return (from itm in result
                            select new WaterOnline
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                OrDateTime = itm.OrDateTime,
                                IDUser = itm.IDUser,
                                IDdriver = itm.IDdriver,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong,
                                Price = itm.Price,
                                SerPrice = itm.SerPrice,
                                Status = itm.Status,
                                WaterType = itm.WaterType,
                                DetailType = itm.DetailType,
                                PayType = itm.PayType,
                                Address = itm.Address,
                                CardType = itm.CardType,
                                CardNo = itm.CardNo,
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Discount = itm.Discount,
                                Rate = itm.Rate,
                                Points = itm.Points,
                                NewVouNo = itm.NewVouNo,
                                ArrivingTime = itm.ArrivingTime,
                                CancelReason = itm.CancelReason,
                                CardHolder = itm.CardHolder,
                                CustRate = itm.CustRate,
                                DeliveredDate = itm.DeliveredDate,
                                Descr = itm.Descr,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Expiry = itm.Expiry,
                                FTime = itm.FTime,
                                GDate = itm.GDate,
                                HDate = itm.HDate,
                                IDDate = itm.IDDate,
                                IDFrom = itm.IDFrom,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                Mail = itm.Mail,
                                MobileNo = itm.MobileNo,
                                Name = itm.Name,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                Tax = itm.Tax,
                                Total = itm.Total,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



        /// <summary>
        /// select all Account center from Area Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<WaterOnline> GetByUserIDStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.WaterOnlineGetByIDUserStatus(this.IDUser, this.Status);
                    return (from itm in result
                            select new WaterOnline
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                OrDateTime = itm.OrDateTime,
                                IDUser = itm.IDUser,
                                IDdriver = itm.IDdriver,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong,
                                Price = itm.Price,
                                SerPrice = itm.SerPrice,
                                Status = itm.Status,
                                WaterType = itm.WaterType,
                                DetailType = itm.DetailType,
                                PayType = itm.PayType,
                                Address = itm.Address,
                                CardType = itm.CardType,
                                CardNo = itm.CardNo,
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Discount = itm.Discount,
                                Rate = itm.Rate,
                                Points = itm.Points,
                                NewVouNo = itm.NewVouNo,
                                ArrivingTime = itm.ArrivingTime,
                                CancelReason = itm.CancelReason,
                                CardHolder = itm.CardHolder,
                                CustRate = itm.CustRate,
                                DeliveredDate = itm.DeliveredDate,
                                Descr = itm.Descr,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Expiry = itm.Expiry,
                                FTime = itm.FTime,
                                GDate = itm.GDate,
                                HDate = itm.HDate,
                                IDDate = itm.IDDate,
                                IDFrom = itm.IDFrom,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                Mail = itm.Mail,
                                MobileNo = itm.MobileNo,
                                Name = itm.Name,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                Tax = itm.Tax,
                                Total = itm.Total,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Account center from Area Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<WaterOnline> GetByStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.WaterOnlineGetByStatus(this.Status);
                    return (from itm in result
                            select new WaterOnline
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                OrDateTime = itm.OrDateTime,
                                IDUser = itm.IDUser,
                                IDdriver = itm.IDdriver,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong,
                                Price = itm.Price,
                                SerPrice = itm.SerPrice,
                                Status = itm.Status,
                                WaterType = itm.WaterType,
                                DetailType = itm.DetailType,
                                PayType = itm.PayType,
                                Address = itm.Address,
                                CardType = itm.CardType,
                                CardNo = itm.CardNo,
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Discount = itm.Discount,
                                Rate = itm.Rate,
                                Points = itm.Points,
                                NewVouNo = itm.NewVouNo,
                                ArrivingTime = itm.ArrivingTime,
                                CancelReason = itm.CancelReason,
                                CardHolder = itm.CardHolder,
                                CustRate = itm.CustRate,
                                DeliveredDate = itm.DeliveredDate,
                                Descr = itm.Descr,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Expiry = itm.Expiry,
                                FTime = itm.FTime,
                                GDate = itm.GDate,
                                HDate = itm.HDate,
                                IDDate = itm.IDDate,
                                IDFrom = itm.IDFrom,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                Mail = itm.Mail,
                                MobileNo = itm.MobileNo,
                                Name = itm.Name,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                Tax = itm.Tax,
                                Total = itm.Total,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName
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
        public WaterOnline find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.WaterOnlineGet(this.Branch, this.VouLoc, this.VouNo);
                    return (from itm in result
                            select new WaterOnline
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                OrDateTime = itm.OrDateTime,
                                IDUser = itm.IDUser,
                                IDdriver = itm.IDdriver,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong,
                                Price = itm.Price,
                                SerPrice = itm.SerPrice,
                                Status = itm.Status,
                                WaterType = itm.WaterType,
                                DetailType = itm.DetailType,
                                PayType = itm.PayType,
                                Address = itm.Address,
                                CardType = itm.CardType,
                                CardNo = itm.CardNo,
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Discount = itm.Discount,
                                Rate = itm.Rate,
                                Points = itm.Points,
                                NewVouNo = itm.NewVouNo,
                                ArrivingTime = itm.ArrivingTime,
                                CancelReason = itm.CancelReason,
                                CardHolder = itm.CardHolder,
                                CustRate = itm.CustRate,
                                DeliveredDate = itm.DeliveredDate,
                                Descr = itm.Descr,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Expiry = itm.Expiry,
                                FTime = itm.FTime,
                                GDate = itm.GDate,
                                HDate = itm.HDate,
                                IDDate = itm.IDDate,
                                IDFrom = itm.IDFrom,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                Mail = itm.Mail,
                                MobileNo = itm.MobileNo,
                                Name = itm.Name,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                Tax = itm.Tax,
                                Total = itm.Total,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
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
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.WaterOnLineCancel(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
                                                this.Status, this.CancelReason);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
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
                    var result = myContext.WaterOnlineMaxCode(this.Branch, this.VouLoc);
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
