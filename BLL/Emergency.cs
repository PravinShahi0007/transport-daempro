using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Emergency
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
        public System.Nullable<short> EmrType { get; set; }
        public System.Nullable<short> DetailType { get; set; }
        public System.Nullable<short> ItemType { get; set; }
        public System.Nullable<short> CarType { get; set; }
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
                return "30" + this.VouLoc.Substring(3, 2) + this.VouNo.ToString();
            }
        }
        public string UIID
        {
            get
            {
                return "31" + this.VouNo.ToString();
            }
        }


        public Emergency()
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
            this.EmrType = 0;
            this.DetailType = 0;
            this.ItemType = 0;
            this.CarType = 0;
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
        /// Add Area in Area Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.EmergencyInsert(this.Branch,
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
                                                this.EmrType,
                                                this.DetailType,
                                                this.ItemType,
                                                this.CarType,
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
        /// Delete Area from Area Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.EmergencyDelete(this.Branch, this.VouLoc , this.VouNo);
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
                    myContext.EmergencyUpdate(this.Branch,
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
                                                this.EmrType,
                                                this.DetailType,
                                                this.ItemType,
                                                this.CarType,
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
                                                this.Points);
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
                    myContext.EmergencyStatusUpdate(this.Branch,
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
        public bool UpdateDriver(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.EmergencyUpdateDriver(this.Branch,
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
        /// post Emergency in Emergency Table
        /// </summary>
        /// <returns>True if Gas Success or False if Fail</returns>
        public bool PostEmergency(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.EmergencyPost(this.Branch,
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



        public List<Emergency> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.EmergencyGetAll(this.Branch, this.VouLoc);
                    return (from itm in result
                            select new Emergency
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
                                EmrType = itm.EmrType,
                                DetailType = itm.DetailType,
                                ItemType = itm.ItemType,
                                CarType = itm.CarType,
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



        public List<Emergency> GetByVouLoc(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.EmergencyGetByVouLoc(this.Branch, this.VouLoc);
                    return (from itm in result
                            select new Emergency
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
                                EmrType = itm.EmrType,
                                DetailType = itm.DetailType,
                                ItemType = itm.ItemType,
                                CarType = itm.CarType,
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
        public List<Emergency> GetByUserID(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.EmergencyGetByUserID(this.IDUser);
                    return (from itm in result
                            select new Emergency
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
                                EmrType = itm.EmrType,
                                DetailType = itm.DetailType,
                                ItemType = itm.ItemType,
                                CarType = itm.CarType,
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
        public List<Emergency> GetByUserIDStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.EmergencyGetByIDUserStatus(this.IDUser,this.Status);
                    return (from itm in result
                            select new Emergency
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
                                EmrType = itm.EmrType,
                                DetailType = itm.DetailType,
                                ItemType = itm.ItemType,
                                CarType = itm.CarType,
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
        public List<Emergency> GetByStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.EmergencyGetByStatus(this.Status);
                    return (from itm in result
                            select new Emergency
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
                                EmrType = itm.EmrType,
                                DetailType = itm.DetailType,
                                ItemType = itm.ItemType,
                                CarType = itm.CarType,
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
        public Emergency find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.EmergencyGet(this.Branch, this.VouLoc,this.VouNo);
                    return (from itm in result
                            select new Emergency
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
                                EmrType = itm.EmrType,
                                DetailType = itm.DetailType,
                                ItemType = itm.ItemType,
                                CarType = itm.CarType,
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
                    var result = myContext.EmergencyMaxCode(this.Branch,this.VouLoc);
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
