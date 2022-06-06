using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class GasOnline
    {

        public short Branch { get; set; }
        public string VouLoc { get; set; }
        public int VouNo { get; set; }
        public string ODateTime { get; set; }
        public string IDUser { get; set; }
        public string IDdriver { get; set; }
        public string PickLat { get; set; }
        public string PickLong { get; set; }
        public System.Nullable<double> Price { get; set; }
        public System.Nullable<double> SerPrice { get; set; }
        public System.Nullable<short> Status { get; set; }
        public System.Nullable<short> GasType { get; set; }
        public System.Nullable<short> DetailType { get; set; }
        public System.Nullable<short> Qty { get; set; }
        public System.Nullable<short> PayType { get; set; }
        public string Address1 { get; set; }
        public System.Nullable<short> CardType { get; set; }
        public string CardNo { get; set; }
        public string CardName { get; set; }
        public string CardSec { get; set; }
        public string CardExpiry { get; set; }
        public string Remark { get; set; }
        public string PromoCode { get; set; }
        public System.Nullable<double> Discount { get; set; }
        public System.Nullable<int> Rate { get; set; }
        public System.Nullable<int> Points { get; set; }
        public string NewVouNo { get; set; }
        public string OrderID
        {
            get
            {
                return "40" + this.VouLoc.Substring(3, 2) + this.VouNo.ToString();
            }
        }
        public string UIID
        {
            get
            {
                return "41" + this.VouNo.ToString();
            }
        }


        public GasOnline()
        { 
            this.Branch = 1;
            this.VouLoc = "00000";
            this.VouNo = 0;
            this.ODateTime = "";
            this.IDUser = "";
            this.IDdriver = "";
            this.PickLat = "";
            this.PickLong = "";
            this.Price = 0;
            this.SerPrice = 0;
            this.Status = 0;
            this.GasType = 0;
            this.DetailType = 0;
            this.Qty = 0;
            this.PayType = 0;
            this.Address1 = "";
            this.CardType = 0;
            this.CardNo = "";
            this.CardName = "";
            this.CardSec = "";
            this.CardExpiry = "";
            this.Remark = "";
            this.PromoCode = "";
            this.Discount = 0;
            this.Rate = 0;
            this.Points = 0;
            this.NewVouNo = "";
        }

                        
        /// <summary>
        /// Add Gas in Gas Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.GasOnlineInsert(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
                                                this.ODateTime,
                                                this.IDUser,
                                                this.IDdriver,
                                                this.PickLat,
                                                this.PickLong,
                                                this.Price,
                                                this.SerPrice,
                                                this.Status,
                                                this.GasType,
                                                this.DetailType,
                                                this.Qty,
                                                this.PayType,
                                                this.Address1,
                                                this.CardType,
                                                this.CardNo,
                                                this.CardName,
                                                this.CardSec,
                                                this.CardExpiry,
                                                this.Remark,
                                                this.PromoCode,
                                                this.Discount,
                                                this.Rate,
                                                this.Points,
                                                this.NewVouNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Gas from Gas Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.GasOnlineDelete(this.Branch, this.VouLoc, this.VouNo);
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
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.GasOnlineUpdate(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
                                                this.ODateTime,
                                                this.IDUser,
                                                this.IDdriver,
                                                this.PickLat,
                                                this.PickLong,
                                                this.Price,
                                                this.SerPrice,
                                                this.Status,
                                                this.GasType,
                                                this.DetailType,
                                                this.Qty,
                                                this.PayType,
                                                this.Address1,
                                                this.CardType,
                                                this.CardNo,
                                                this.CardName,
                                                this.CardSec,
                                                this.CardExpiry,
                                                this.Remark,
                                                this.PromoCode,
                                                this.Discount,
                                                this.Rate,
                                                this.Points,
                                                this.NewVouNo
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
        /// <returns>True if Update Success or False if Fail</returns>
        public bool UpdateDriver(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.GasOnlineUpdateDriver(this.Branch,
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
        /// post Gas in GasOnline Table
        /// </summary>
        /// <returns>True if Gas Success or False if Fail</returns>
        public bool PostGasOnline(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.GasOnlinePost(this.Branch,
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


        /// <summary>
        /// Update Gas in Gas Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool StatusUpdate(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.GasOnlineStatusUpdate(this.Branch,
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
                    myContext.GasOnLineStatusDriverUpdate(this.Branch, this.VouLoc, this.VouNo, this.Status, this.IDdriver);

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public List<GasOnline> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.GasOnlineGetAll(this.Branch, this.VouLoc);
                    return (from itm in result
                            select new GasOnline
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                ODateTime = itm.ODateTime,
                                IDUser = itm.IDUser,
                                IDdriver = itm.IDdriver,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong,
                                Price = itm.Price,
                                SerPrice = itm.SerPrice,
                                Status = itm.Status,
                                GasType = itm.GasType,
                                DetailType = itm.DetailType,
                                Qty = itm.Qty,
                                PayType = itm.PayType,
                                Address1 = itm.Address1,
                                CardType = itm.CardType,
                                CardNo = itm.CardNo,
                                CardName = itm.CardName,
                                CardSec = itm.CardSec,
                                CardExpiry = itm.CardExpiry,
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Discount = itm.Discount,
                                Rate = itm.Rate,
                                Points = itm.Points,
                                NewVouNo = itm.NewVouNo
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<GasOnline> GetByVouLoc(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.GasOnlineGetByVouLoc(this.Branch, this.VouLoc);
                    return (from itm in result
                            select new GasOnline
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                ODateTime = itm.ODateTime,
                                IDUser = itm.IDUser,
                                IDdriver = itm.IDdriver,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong,
                                Price = itm.Price,
                                SerPrice = itm.SerPrice,
                                Status = itm.Status,
                                GasType = itm.GasType,
                                DetailType = itm.DetailType,
                                Qty = itm.Qty,
                                PayType = itm.PayType,
                                Address1 = itm.Address1,
                                CardType = itm.CardType,
                                CardNo = itm.CardNo,
                                CardName = itm.CardName,
                                CardSec = itm.CardSec,
                                CardExpiry = itm.CardExpiry,
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Discount = itm.Discount,
                                Rate = itm.Rate,
                                Points = itm.Points,
                                NewVouNo = itm.NewVouNo
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
        public List<GasOnline> GetByUserID(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.GasOnlineGetByUserID(this.IDUser);
                    return (from itm in result
                            select new GasOnline
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                ODateTime = itm.ODateTime,
                                IDUser = itm.IDUser,
                                IDdriver = itm.IDdriver,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong,
                                Price = itm.Price,
                                SerPrice = itm.SerPrice,
                                Status = itm.Status,
                                GasType = itm.GasType,
                                DetailType = itm.DetailType,
                                Qty = itm.Qty,
                                PayType = itm.PayType,
                                Address1 = itm.Address1,
                                CardType = itm.CardType,
                                CardNo = itm.CardNo,
                                CardName = itm.CardName,
                                CardSec = itm.CardSec,
                                CardExpiry = itm.CardExpiry,
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Discount = itm.Discount,
                                Rate = itm.Rate,
                                Points = itm.Points,
                                NewVouNo = itm.NewVouNo
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
        public List<GasOnline> GetByUserIDStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.GasOnlineGetByIDUserStatus(this.IDUser, this.Status);
                    return (from itm in result
                            select new GasOnline
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                ODateTime = itm.ODateTime,
                                IDUser = itm.IDUser,
                                IDdriver = itm.IDdriver,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong,
                                Price = itm.Price,
                                SerPrice = itm.SerPrice,
                                Status = itm.Status,
                                GasType = itm.GasType,
                                DetailType = itm.DetailType,
                                Qty = itm.Qty,
                                PayType = itm.PayType,
                                Address1 = itm.Address1,
                                CardType = itm.CardType,
                                CardNo = itm.CardNo,
                                CardName = itm.CardName,
                                CardSec = itm.CardSec,
                                CardExpiry = itm.CardExpiry,
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Discount = itm.Discount,
                                Rate = itm.Rate,
                                Points = itm.Points,
                                NewVouNo = itm.NewVouNo
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
        public List<GasOnline> GetByStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.GasOnlineGetByStatus(this.Status);
                    return (from itm in result
                            select new GasOnline
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                ODateTime = itm.ODateTime,
                                IDUser = itm.IDUser,
                                IDdriver = itm.IDdriver,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong,
                                Price = itm.Price,
                                SerPrice = itm.SerPrice,
                                Status = itm.Status,
                                GasType = itm.GasType,
                                DetailType = itm.DetailType,
                                Qty = itm.Qty,
                                PayType = itm.PayType,
                                Address1 = itm.Address1,
                                CardType = itm.CardType,
                                CardNo = itm.CardNo,
                                CardName = itm.CardName,
                                CardSec = itm.CardSec,
                                CardExpiry = itm.CardExpiry,
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Discount = itm.Discount,
                                Rate = itm.Rate,
                                Points = itm.Points,
                                NewVouNo = itm.NewVouNo
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
        public GasOnline find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.GasOnlineGet(this.Branch, this.VouLoc, this.VouNo);
                    return (from itm in result
                            select new GasOnline
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                ODateTime = itm.ODateTime,
                                IDUser = itm.IDUser,
                                IDdriver = itm.IDdriver,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong,
                                Price = itm.Price,
                                SerPrice = itm.SerPrice,
                                Status = itm.Status,
                                GasType = itm.GasType,
                                DetailType = itm.DetailType,
                                Qty = itm.Qty,
                                PayType = itm.PayType,
                                Address1 = itm.Address1,
                                CardType = itm.CardType,
                                CardNo = itm.CardNo,
                                CardName = itm.CardName,
                                CardSec = itm.CardSec,
                                CardExpiry = itm.CardExpiry,
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Discount = itm.Discount,
                                Rate = itm.Rate,
                                Points = itm.Points,
                                NewVouNo = itm.NewVouNo
                            }).FirstOrDefault();
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
                    var result = myContext.GasOnlineMaxCode(this.Branch, this.VouLoc);
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
