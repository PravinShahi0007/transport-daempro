using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Orders
    {
        public string ID { get; set; }
        public string ODateTime { get; set; }
        public string IDUser { get; set; }
        public string IDdriver { get; set; }
        public string PickLat { get; set; }
        public string PickLong { get; set; }
        public string DropLat { get; set; }
        public string DropLong { get; set; }
        public string Distance { get; set; }
        public string Duration { get; set; }
        public System.Nullable<double> Fare { get; set; }
        public System.Nullable<short> Status { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public System.Nullable<short> CarType { get; set; }
        public System.Nullable<short> PayType { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public System.Nullable<short> CardType { get; set; }
        public string CardNo { get; set; }
        public string CardName { get; set; }
        public string CardSec { get; set; }
        public string CardExpiry { get; set; }
        public string Remark { get; set; }
        public string PromoCode { get; set; }
        public System.Nullable<double> Discount { get; set; }
        public System.Nullable<int> iRate { get; set; }
        public System.Nullable<int> Points { get; set; }
        public string AssignUser { get; set; }
        public string NextUser { get; set; }
        public System.Nullable<int> LoopNo { get; set; }

        public Orders()
        {
            this.ID = "";
            this.ODateTime = "";
            this.IDUser = "";
            this.IDdriver = "";
            this.PickLat = "";
            this.PickLong = "";
            this.DropLat = "";
            this.DropLong = "";
            this.Distance = "";
            this.Duration = "";
            this.Fare = 0;
            this.Status = 0;
            this.TimeStart = "";
            this.TimeEnd = "";
            this.CarType = 0;
            this.PayType = 0;
            this.Address1 = "";
            this.Address2 = "";
            this.CardType = 0;
            this.CardNo = "";
            this.CardName = "";
            this.CardSec = "";
            this.CardExpiry = "";
            this.Remark = "";
            this.PromoCode = "";
            this.Discount = 0;
            this.iRate = 0;
            this.Points = 0;
            this.AssignUser = "";
            this.NextUser = "";
            this.LoopNo = 0;
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
                    myContext.OrdersAdd(this.ID, this.ODateTime, this.IDUser, this.IDdriver, this.PickLat, this.PickLong, this.DropLat, this.DropLong, this.Distance, this.Duration, this.Fare, this.Status, this.TimeStart, this.TimeEnd, this.CarType, this.PayType,this.Address1,this.Address2,this.CardType,this.CardNo,this.CardName,this.CardSec,this.CardExpiry,this.Remark,this.PromoCode,this.Discount,this.iRate,this.Points,this.AssignUser,this.NextUser,this.LoopNo);
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
                    myContext.OrdersDelete(this.ID);
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
                    myContext.OrdersUpdate(this.ID, this.ODateTime, this.IDUser, this.IDdriver, this.PickLat, this.PickLong, this.DropLat, this.DropLong, this.Distance, this.Duration, this.Fare, this.Status, this.TimeStart, this.TimeEnd, this.CarType, this.PayType, this.Address1, this.Address2, this.CardType, this.CardNo, this.CardName, this.CardSec, this.CardExpiry, this.Remark, this.PromoCode, this.Discount, this.iRate, this.Points,this.AssignUser,this.NextUser,this.LoopNo);
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
        public bool Start(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.OrdersStart(this.ID, this.Status, this.TimeStart);
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
        public bool End(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.OrdersEnd(this.ID, this.Status, this.TimeEnd,this.Distance,this.Duration,this.Fare,this.Points);
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
        public bool Payment(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.OrdersPayment(this.ID,this.Status,this.IDUser,this.PayType,this.CardType,this.CardNo,this.CardName,this.CardSec,this.CardExpiry,this.PromoCode,this.Discount,this.Points);
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
        public bool Rate(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.OrdersRate(this.ID, this.iRate);
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
        public bool SetStatus(string ConnectionStr,short onLine)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.OrdersSetStatus(this.ID, this.Status, this.IDdriver, onLine,this.AssignUser,this.NextUser);
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
        public bool SetAssign(string ConnectionStr, short FromStatus, short ToStatus)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.OrdersSetAssign(this.AssignUser,FromStatus,ToStatus);
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
        public bool SetLoopNo(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.OrdersSetLoopNo(this.ID, this.LoopNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }



        /// <summary>
        /// select all Account center from Area Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<Orders> GetByDriver(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrdersGetByDriver(this.IDdriver);
                    return (from itm in result
                            select new Orders
                            {
                                 ID = itm.ID,
                                 ODateTime = itm.ODateTime,
                                 IDUser = itm.IDUser,
                                 IDdriver = itm.IDdriver,
                                 PickLat = itm.PickLat,
                                 DropLat = itm.DropLat,
                                 DropLong = itm.DropLong,
                                 Distance = itm.Distance,
                                 Duration = itm.Duration,
                                 Fare = itm.Fare,
                                 Status = itm.Status,
                                 TimeStart = itm.TimeStart,
                                 TimeEnd = itm.TimeEnd,
                                 CarType = itm.CarType,
                                 PayType = itm.PayType,
                                 PickLong = itm.PickLong,
                                 Address1 = itm.Address1,
                                 Address2 = itm.Address2,
                                 CardExpiry = itm.CardExpiry,
                                 CardName = itm.CardName,
                                 CardNo = itm.CardNo,
                                 CardSec = itm.CardSec,
                                 CardType = itm.CardType,
                                 Discount = itm.Discount,
                                 Points = itm.Points,
                                 PromoCode = itm.PromoCode,
                                 iRate = itm.Rate,
                                 Remark = itm.Remark,
                                 AssignUser = itm.AssignUser,
                                 NextUser = itm.NextUser,
                                 LoopNo = itm.LoopNo
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
        public List<Orders> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrdersGetAll();
                    return (from itm in result
                            select new Orders
                            {
                                ID = itm.ID,
                                ODateTime = itm.ODateTime,
                                IDUser = itm.IDUser,
                                IDdriver = itm.IDdriver,
                                PickLat = itm.PickLat,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Distance = itm.Distance,
                                Duration = itm.Duration,
                                Fare = itm.Fare,
                                Status = itm.Status,
                                TimeStart = itm.TimeStart,
                                TimeEnd = itm.TimeEnd,
                                CarType = itm.CarType,
                                PayType = itm.PayType,
                                PickLong = itm.PickLong,
                                Address1 = itm.Address1,
                                Address2 = itm.Address2,
                                CardExpiry = itm.CardExpiry,
                                CardName = itm.CardName,
                                CardNo = itm.CardNo,
                                CardSec = itm.CardSec,
                                CardType = itm.CardType,
                                Discount = itm.Discount,
                                Points = itm.Points,
                                PromoCode = itm.PromoCode,
                                iRate = itm.Rate,
                                Remark = itm.Remark,
                                AssignUser = itm.AssignUser,
                                NextUser = itm.NextUser,
                                LoopNo = itm.LoopNo
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
        public List<Orders> GetByStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrdersGetByStatus(this.Status);
                    return (from itm in result
                            select new Orders
                            {
                                ID = itm.ID,
                                ODateTime = itm.ODateTime,
                                IDUser = itm.IDUser,
                                IDdriver = itm.IDdriver,
                                PickLat = itm.PickLat,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Distance = itm.Distance,
                                Duration = itm.Duration,
                                Fare = itm.Fare,
                                Status = itm.Status,
                                TimeStart = itm.TimeStart,
                                TimeEnd = itm.TimeEnd,
                                CarType = itm.CarType,
                                PayType = itm.PayType,
                                PickLong = itm.PickLong,
                                Address1 = itm.Address1,
                                Address2 = itm.Address2,
                                CardExpiry = itm.CardExpiry,
                                CardName = itm.CardName,
                                CardNo = itm.CardNo,
                                CardSec = itm.CardSec,
                                CardType = itm.CardType,
                                Discount = itm.Discount,
                                Points = itm.Points,
                                PromoCode = itm.PromoCode,
                                iRate = itm.Rate,
                                Remark = itm.Remark,
                                AssignUser = itm.AssignUser,
                                NextUser = itm.NextUser,
                                LoopNo = itm.LoopNo
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
        public List<Orders> GetByStatusAssignUser(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrdersGetByStatusAssignUser(this.Status,this.AssignUser);
                    return (from itm in result
                            select new Orders
                            {
                                ID = itm.ID,
                                ODateTime = itm.ODateTime,
                                IDUser = itm.IDUser,
                                IDdriver = itm.IDdriver,
                                PickLat = itm.PickLat,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Distance = itm.Distance,
                                Duration = itm.Duration,
                                Fare = itm.Fare,
                                Status = itm.Status,
                                TimeStart = itm.TimeStart,
                                TimeEnd = itm.TimeEnd,
                                CarType = itm.CarType,
                                PayType = itm.PayType,
                                PickLong = itm.PickLong,
                                Address1 = itm.Address1,
                                Address2 = itm.Address2,
                                CardExpiry = itm.CardExpiry,
                                CardName = itm.CardName,
                                CardNo = itm.CardNo,
                                CardSec = itm.CardSec,
                                CardType = itm.CardType,
                                Discount = itm.Discount,
                                Points = itm.Points,
                                PromoCode = itm.PromoCode,
                                iRate = itm.Rate,
                                Remark = itm.Remark,
                                AssignUser = itm.AssignUser,
                                NextUser = itm.NextUser,
                                LoopNo = itm.LoopNo
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
        public List<Orders> GetByUser(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrdersGetByUser(this.IDUser);
                    return (from itm in result
                            select new Orders
                            {
                                ID = itm.ID,
                                ODateTime = itm.ODateTime,
                                IDUser = itm.IDUser,
                                IDdriver = itm.IDdriver,
                                PickLat = itm.PickLat,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Distance = itm.Distance,
                                Duration = itm.Duration,
                                Fare = itm.Fare,
                                Status = itm.Status,
                                TimeStart = itm.TimeStart,
                                TimeEnd = itm.TimeEnd,
                                CarType = itm.CarType,
                                PayType = itm.PayType,
                                PickLong = itm.PickLong,
                                Address1 = itm.Address1,
                                Address2 = itm.Address2,
                                CardExpiry = itm.CardExpiry,
                                CardName = itm.CardName,
                                CardNo = itm.CardNo,
                                CardSec = itm.CardSec,
                                CardType = itm.CardType,
                                Discount = itm.Discount,
                                Points = itm.Points,
                                PromoCode = itm.PromoCode,
                                iRate = itm.Rate,
                                Remark = itm.Remark,
                                AssignUser = itm.AssignUser,
                                NextUser = itm.NextUser,
                                LoopNo = itm.LoopNo   
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
        public Orders Find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrdersGetByID(this.ID);
                    return (from itm in result
                            select new Orders
                            {
                                ID = itm.ID,
                                ODateTime = itm.ODateTime,
                                IDUser = itm.IDUser,
                                IDdriver = itm.IDdriver,
                                PickLat = itm.PickLat,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Distance = itm.Distance,
                                Duration = itm.Duration,
                                Fare = itm.Fare,
                                Status = itm.Status,
                                TimeStart = itm.TimeStart,
                                TimeEnd = itm.TimeEnd,
                                CarType = itm.CarType,
                                PayType = itm.PayType,
                                PickLong = itm.PickLong,
                                Address1 = itm.Address1,
                                Address2 = itm.Address2,
                                CardExpiry = itm.CardExpiry,
                                CardName = itm.CardName,
                                CardNo = itm.CardNo,
                                CardSec = itm.CardSec,
                                CardType = itm.CardType,
                                Discount = itm.Discount,
                                Points = itm.Points,
                                PromoCode = itm.PromoCode,
                                iRate = itm.Rate,
                                Remark = itm.Remark,
                                AssignUser = itm.AssignUser,
                                NextUser = itm.NextUser,
                                LoopNo = itm.LoopNo   
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
        public string GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrdersGetMax();
                    return (from Cat in result
                            select Cat.myCode).FirstOrDefault().ToString();
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
        /*
        public vOrders FindOrders1(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrders1GetByID(this.ID);
                    return (from itm in result
                            select new vOrders
                            {
                                ID = itm.ID,
                                ODateTime = itm.ODateTime,
                                IDUser = itm.IDUser,
                                IDdriver = itm.IDdriver,
                                PickLat = itm.PickLat,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Distance = itm.Distance,
                                Duration = itm.Duration,
                                Fare = itm.Fare,
                                Status = itm.Status,
                                TimeStart = itm.TimeStart,
                                TimeEnd = itm.TimeEnd,
                                CarType = itm.CarType,
                                PayType = itm.PayType,
                                PickLong = itm.PickLong,
                                Address1 = itm.Address1,
                                Address2 = itm.Address2,
                                CardExpiry = itm.CardExpiry,
                                CardName = itm.CardName,
                                CardNo = itm.CardNo,
                                CardSec = itm.CardSec,
                                CardType = itm.CardType,
                                Discount = itm.Discount,
                                Points = itm.Points,
                                PromoCode = itm.PromoCode,
                                iRate = itm.Rate,
                                Remark = itm.Remark,
                                CardExpiry1 = itm.CardExpiry1,
                                CardName1 = itm.CardName1,
                                CardNo1 = itm.CardNo1,
                                CardSec1 = itm.CardSec1,
                                CardType1 = itm.CardType1,
                                DCarColor = itm.DCarColor,
                                DCareType = itm.DCareType,
                                DCarModel = itm.DCarModel,
                                DPlateNo = itm.DPlateNo,
                                FirstName = itm.FirstName,
                                InPoints = itm.InPoints,
                                LastName = itm.LastName,
                                LocDateTime = itm.LocDateTime,
                                LoginType = itm.LoginType,
                                MobileNo = itm.MobileNo,
                                Online = itm.Online,
                                OutPoints = itm.OutPoints,
                                PLat = itm.PLat,
                                PLong = itm.PLong,
                                UserType = itm.UserType,
                                AssignUser = itm.AssignUser,
                                NextUser = itm.NextUser
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }        
        }
         */


        /*
        /// <summary>
        /// select all Account center from Area Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public vOrders FindOrders2(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result;// = myContext.vOrders2GetByID(this.ID);
                    return (from itm in result
                            select new vOrders
                            {
                                ID = itm.ID,
                                ODateTime = itm.ODateTime,
                                IDUser = itm.IDUser,
                                IDdriver = itm.IDdriver,
                                PickLat = itm.PickLat,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Distance = itm.Distance,
                                Duration = itm.Duration,
                                Fare = itm.Fare,
                                Status = itm.Status,
                                TimeStart = itm.TimeStart,
                                TimeEnd = itm.TimeEnd,
                                CarType = itm.CarType,
                                PayType = itm.PayType,
                                PickLong = itm.PickLong,
                                Address1 = itm.Address1,
                                Address2 = itm.Address2,
                                CardExpiry = itm.CardExpiry,
                                CardName = itm.CardName,
                                CardNo = itm.CardNo,
                                CardSec = itm.CardSec,
                                CardType = itm.CardType,
                                Discount = itm.Discount,
                                Points = itm.Points,
                                PromoCode = itm.PromoCode,
                                iRate = itm.Rate,
                                Remark = itm.Remark,
                                CardExpiry1 = itm.CardExpiry1,
                                CardName1 = itm.CardName1,
                                CardNo1 = itm.CardNo1,
                                CardSec1 = itm.CardSec1,
                                CardType1 = itm.CardType1,
                                DCarColor = itm.DCarColor,
                                DCareType = itm.DCareType,
                                DCarModel = itm.DCarModel,
                                DPlateNo = itm.DPlateNo,
                                FirstName = itm.FirstName,
                                InPoints = itm.InPoints,
                                LastName = itm.LastName,
                                LocDateTime = itm.LocDateTime,
                                LoginType = itm.LoginType,
                                MobileNo = itm.MobileNo,
                                Online = itm.Online,
                                OutPoints = itm.OutPoints,
                                PLat = itm.PLat,
                                PLong = itm.PLong,
                                UserType = itm.UserType,
                                AssignUser = itm.AssignUser,
                                NextUser = itm.NextUser
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
         */


    }

    [Serializable]
    public class vOrders:Orders
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public System.Nullable<short> UserType { get; set; }
        public System.Nullable<short> LoginType { get; set; }
        public string PLat { get; set; }
        public string PLong { get; set; }
        public string LocDateTime { get; set; }
        public System.Nullable<short> Online { get; set; }
        public System.Nullable<short> DCareType { get; set; }
        public string DPlateNo { get; set; }
        public string DCarModel { get; set; }
        public string DCarColor { get; set; }
        public System.Nullable<short> CardType1 { get; set; }
        public string CardNo1 { get; set; }
        public string CardName1 { get; set; }
        public string CardSec1 { get; set; }
        public string CardExpiry1 { get; set; }
        public System.Nullable<int> InPoints { get; set; }
        public System.Nullable<int> OutPoints { get; set; }

        public vOrders()
        {
            this.FirstName = "";
            this.LastName = "";
            this.MobileNo = "";
            this.UserType = 0;
            this.LoginType = 0;
            this.PLat = "";
            this.PLong = "";
            this.LocDateTime = "";
            this.Online = 0;
            this.DCareType= 0;
            this.DPlateNo = "";
            this.DCarModel = "";
            this.DCarColor = "";
            this.CardType1 = 0;
            this.CardNo1 = "";
            this.CardName1 = "";
            this.CardSec1 = "";
            this.CardExpiry1 = "";
            this.InPoints = 0;
            this.OutPoints = 0;
        }

    }


    [Serializable]
    public class OrdersTemp
    {
        public string OrderID { get; set; }
        public string DriverID { get; set; }
        public System.Nullable<short> OStatus { get; set; }

        public OrdersTemp()
        {
            this.OrderID = "";
            this.DriverID = "";
            this.OStatus = 0;
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
                    myContext.OrdersTempAdd(this.OrderID, this.DriverID, this.OStatus);
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
                    myContext.OrdersTempDelete(this.OrderID);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select all Account center from Area Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<OrdersTemp> GetByDriver(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrdersTempGetByDriver(this.DriverID);
                    return (from itm in result
                            select new OrdersTemp
                            {
                                 DriverID = itm.DriverId,
                                 OrderID = itm.OrderId,
                                 OStatus = itm.Ostatus
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
        public List<OrdersTemp> GetByOrderID(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrdersTempGetByOrderID(this.OrderID);
                    return (from itm in result
                            select new OrdersTemp
                            {
                                DriverID = itm.DriverId,
                                OrderID = itm.OrderId,
                                OStatus = itm.Ostatus
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
        public List<OrdersTemp> GetByOrderIDDriver(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrdersTempGetByOrderIDDriver(this.OrderID,this.DriverID);
                    return (from itm in result
                            select new OrdersTemp
                            {
                                DriverID = itm.DriverId,
                                OrderID = itm.OrderId,
                                OStatus = itm.Ostatus
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    }

}
