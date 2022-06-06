using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{    
    [Serializable]
    public class OrderTran
    {
        public string IDDriver { get; set; }
		public short OrderType { get; set; }
		public string VouLoc { get; set; }
		public int VouNo { get; set; }
        public short Steps { get; set; }
		public System.Nullable<bool> Accept { get; set; }
        public string AcceptDateTime { get; set; }
		public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public double? FTime { get; set; }
        public double? Distance { get; set; }
        public int? RejectReason { get; set; }
        public string DriverLat { get; set; }
        public string DriverLong { get; set; }
        public string LocLat { get; set; }
        public string LocLong { get; set; }
        public double? RecAmount { get; set; }
        public string Delivered { get; set; }
        public string Completed { get; set; }

        public OrderTran()
        {
            this.IDDriver = "";
		    this.OrderType = 0;
		    this.VouLoc = "";
		    this.VouNo = 0;
            this.Steps = 0;
		    this.Accept = false;
            this.AcceptDateTime = "";
		    this.StartDateTime = "";
            this.EndDateTime = "";
            this.FTime = 0;
            this.Distance = 0;
            this.RejectReason = -1;
            this.DriverLat = "";
            this.DriverLong = "";
            this.LocLat = "";
            this.LocLong = "";
            this.RecAmount =0;
            this.Delivered = "";
            this.Completed = "";
        }


        /// <summary>
        /// Add Stock Item in Item Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.OrderTranAdd(this.IDDriver,this.OrderType,this.VouLoc,this.VouNo,this.Steps,this.Accept,this.AcceptDateTime,this.StartDateTime,this.EndDateTime,this.FTime,this.Distance,this.RejectReason,this.DriverLat,this.DriverLong,this.LocLat,this.LocLong,this.RecAmount,this.Delivered,this.Completed);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Update Item Stock in Item Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.OrderTranupdate(this.IDDriver, this.OrderType, this.VouLoc, this.VouNo, this.Steps, this.Accept, this.AcceptDateTime, this.StartDateTime, this.EndDateTime, this.FTime, this.Distance, this.RejectReason, this.DriverLat, this.DriverLong, this.LocLat, this.LocLong, this.RecAmount, this.Delivered, this.Completed);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public OrderTran Find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrderTranGet(this.IDDriver, this.OrderType, this.VouLoc, this.VouNo,this.Steps);
                    return (from itm in result
                            select new OrderTran
                            {
                                IDDriver = itm.IDDriver,
		                        OrderType = itm.OrderType,
		                        VouLoc = itm.VouLoc,
		                        VouNo = itm.VouNo,
		                        Accept = itm.Accept,
                                Distance = itm.Distance,
                                FTime = itm.FTime,
                                RejectReason = itm.RejectReason,
                                DriverLat = itm.DriverLat,
                                DriverLong = itm.DriverLong,
                                EndDateTime = itm.EndDateTime,
                                LocLat = itm.LocLat,
                                LocLong = itm.LocLong,
                                RecAmount = itm.RecAmount,
                                StartDateTime = itm.StartDateTime,
                                Steps = itm.Steps,
                                AcceptDateTime = itm.AcceptDateTime,
                                Completed = itm.Completed,
                                Delivered = itm.Delivered
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrderTranDelete(this.IDDriver, this.OrderType, this.VouLoc, this.VouNo, this.Steps);
                    return true;
                }
                            
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public Order LiveTask(string iLang,string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrderTranLiveTask(this.IDDriver);
                    return (from itm in result
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = (short)itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = (int)itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDDriver,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Status = itm.Status,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                RecEmail = itm.RecEmail,
                                Discount = itm.Discount,
                                PTotal = itm.Amount,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                OrderDateTime = itm.OrderDateTime,
                                Rate = itm.Rate,
                                CustRate = itm.CustRate,
                                CancelReason = itm.CancelReason,
                                CancelReasonName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.CancelReasonName2 : itm.CancelReasonName1),
                                DeliveredDate = itm.DeliveredDate,
                                ArrivingTime = itm.ArrivingTime,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                RateReasonName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.RateReasonName2 : itm.RateReasonName1),
                                DriverMobileNo = itm.IDDriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public List<Order> LiveTask2(string iLang, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrderTranLiveTask2(this.IDDriver);
                    return (from itm in result
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = (short)itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = (int)itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDDriver,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Status = itm.Status,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                RecEmail = itm.RecEmail,
                                Discount = itm.Discount,
                                PTotal = itm.Amount,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                OrderDateTime = itm.OrderDateTime,
                                Rate = itm.Rate,
                                CustRate = itm.CustRate,
                                CancelReason = itm.CancelReason,
                                CancelReasonName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.CancelReasonName2 : itm.CancelReasonName1),
                                DeliveredDate = itm.DeliveredDate,
                                ArrivingTime = itm.ArrivingTime,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                RateReasonName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.RateReasonName2 : itm.RateReasonName1),
                                DriverMobileNo = itm.IDDriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public List<Order> SchTask(string iLang, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrderTransSchLiveTask(this.IDDriver);
                    return (from itm in result
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = (short)itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = (int)itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDDriver,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Status = itm.Status,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                RecEmail = itm.RecEmail,
                                Discount = itm.Discount,
                                PTotal = itm.Amount,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                OrderDateTime = itm.OrderDateTime,
                                Rate = itm.Rate,
                                CustRate = itm.CustRate,
                                CancelReason = itm.CancelReason,
                                CancelReasonName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.CancelReasonName2 : itm.CancelReasonName1),
                                DeliveredDate = itm.DeliveredDate,
                                ArrivingTime = itm.ArrivingTime,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                RateReasonName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.RateReasonName2 : itm.RateReasonName1),
                                DriverMobileNo = itm.IDDriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public int? CompletedCount(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrderTranCompleted(this.IDDriver);
                    return (from itm in result
                            select itm.myCount).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public int? CompletedTodayCount(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrderTranTodayCompleted(this.IDDriver);
                    return (from itm in result
                            select itm.myCount).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public double? CompletedHTodayCount(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrderTranTodayHCompleted(this.IDDriver);
                    return (from itm in result
                            select itm.myCount).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }


        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public List<Order> CompletedOrders(string iLang, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrderTranCompleted2(this.IDDriver);
                    return (from itm in result
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = (short)itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = (int)itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDDriver,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Status = (!(bool)itm.Accept? -1 : itm.Status),
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                RecEmail = itm.RecEmail,
                                Discount = itm.Discount,
                                PTotal = itm.Amount,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                OrderDateTime = itm.OrderDateTime,
                                Rate = itm.Rate,
                                CustRate = itm.CustRate,
                                CancelReason = itm.CancelReason,
                                CancelReasonName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.CancelReasonName2 : itm.CancelReasonName1),
                                DeliveredDate = itm.DeliveredDate,
                                ArrivingTime = itm.ArrivingTime,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                RateReasonName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.RateReasonName2 : itm.RateReasonName1),
                                DriverMobileNo = itm.IDDriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public int? RejectCount(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrderTranReject(this.IDDriver);
                    return (from itm in result
                            select itm).Count();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }


        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public int? RejectCount2(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrderTranReject2(this.IDDriver);
                    return (from itm in result
                            select itm).Count();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }


        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public CalcRoad GetTimeDistance(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrderTranTimeDistance(this.IDDriver, this.OrderType, this.VouLoc, this.VouNo);
                    return (from itm in result
                            select new CalcRoad{
                             Distance = itm.Distance2,
                             Duration = itm.FTime2                                                       
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public int? AcceptCount(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrderTranAccepted(this.IDDriver);
                    return (from itm in result
                            select itm).Count();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }


        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public int? AcceptCount2(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrderTranAccepted2(this.IDDriver);
                    return (from itm in result
                            select itm).Count();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public int? WorkingHours(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrderTranGetTime(this.IDDriver);
                    return (from itm in result
                            select itm.FTime20).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public int? WorkingHoursWeekly(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrderTranGetTimeW(this.IDDriver);
                    return (from itm in result
                            select itm.FTime20).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }


        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public int? WorkingHoursToday(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrderTranGetTimeD(this.IDDriver);
                    return (from itm in result
                            select itm.FTime20).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }


        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public List<Order> WorkingHours(string iLang,string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrderTranGetTime2(this.IDDriver);
                    return (from itm in result
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = (short)itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = (int)itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDDriver,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Status = itm.Status,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                RecEmail = itm.RecEmail,
                                Discount = itm.Discount,
                                PTotal = itm.Amount,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                OrderDateTime = itm.OrderDateTime,
                                Rate = itm.Rate,
                                CustRate = itm.CustRate,
                                CancelReason = itm.CancelReason,
                                CancelReasonName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.CancelReasonName2 : itm.CancelReasonName1),
                                DeliveredDate = itm.DeliveredDate,
                                ArrivingTime = itm.ArrivingTime,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                RateReasonName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.RateReasonName2 : itm.RateReasonName1),
                                DriverMobileNo = itm.IDDriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto,
                                Duration = (double?)itm.FTime20
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public List<Order> WorkingHoursWeekly(string iLang,string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrderTranGetTimeW2(this.IDDriver);
                    return (from itm in result
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = (short)itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = (int)itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDDriver,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Status = itm.Status,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                RecEmail = itm.RecEmail,
                                Discount = itm.Discount,
                                PTotal = itm.Amount,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                OrderDateTime = itm.OrderDateTime,
                                Rate = itm.Rate,
                                CustRate = itm.CustRate,
                                CancelReason = itm.CancelReason,
                                CancelReasonName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.CancelReasonName2 : itm.CancelReasonName1),
                                DeliveredDate = itm.DeliveredDate,
                                ArrivingTime = itm.ArrivingTime,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                RateReasonName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.RateReasonName2 : itm.RateReasonName1),
                                DriverMobileNo = itm.IDDriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto,
                                Duration = (double?)itm.FTime20
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public List<Order> WorkingHoursToday(string iLang,string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrderTranGetTimeD2(this.IDDriver);
                    return (from itm in result
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = (short)itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = (int)itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDDriver,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Status = itm.Status,
                                RecName = itm.RecName,
                                RecAddress = itm.RecAddress,
                                RecMobileNo = itm.RecMobileNo,
                                RecEmail = itm.RecEmail,
                                Discount = itm.Discount,
                                PTotal = itm.Amount,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                OrderDateTime = itm.OrderDateTime,
                                Rate = itm.Rate,
                                CustRate = itm.CustRate,
                                CancelReason = itm.CancelReason,
                                CancelReasonName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.CancelReasonName2 : itm.CancelReasonName1),
                                DeliveredDate = itm.DeliveredDate,
                                ArrivingTime = itm.ArrivingTime,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                RateReasonName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.RateReasonName2 : itm.RateReasonName1),
                                DriverMobileNo = itm.IDDriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto,
                                Duration = (double?)itm.FTime20
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public List<OrderTran> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.OrderTranGetAll(this.OrderType, this.VouLoc, this.VouNo);
                    return (from itm in result
                            select new OrderTran
                            {
                                IDDriver = itm.IDDriver,
                                OrderType = itm.OrderType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                Accept = itm.Accept,
                                Distance = itm.Distance,
                                FTime = itm.FTime,
                                RejectReason = itm.RejectReason,
                                DriverLat = itm.DriverLat,
                                DriverLong = itm.DriverLong,
                                EndDateTime = itm.EndDateTime,
                                LocLat = itm.LocLat,
                                LocLong = itm.LocLong,
                                RecAmount = itm.RecAmount,
                                StartDateTime = itm.StartDateTime,
                                Steps = itm.Steps,
                                AcceptDateTime = itm.AcceptDateTime,
                                Completed = itm.Completed,
                                Delivered = itm.Delivered
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
