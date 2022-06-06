using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Gas
    {

        public short Branch { get; set; }
        public string VouLoc { get; set; }
        public int VouNo { get; set; }
        public string HDate { get; set; }
        public string GDate { get; set; }
        public string FTime { get; set; }
        public string Name { get; set; } // اسم المرسل
        public string IDNo { get; set; } // رقم هوية المرسل
        public short? IDType { get; set; } // نوع الهوية: إقامة/هوية وطنية
        public string IDFrom { get; set; } // مصدرها
        public string IDDate { get; set; } // تاريخها
        public string MobileNo { get; set; } // رقم الجوال
        public string Mail { get; set; } // الايميل
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
        public string Descr { get; set; }
        public System.Nullable<short> PayType { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public string PromoCode { get; set; }
        public System.Nullable<double> Discount { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public System.Nullable<double> Amount { get; set; }
        public System.Nullable<double> Tax { get; set; }
        public System.Nullable<short> CardType { get; set; }
        public string CardNo { get; set; }
        public string CardHolder { get; set; }
        public string Expiry { get; set; }
        public System.Nullable<short> Rate { get; set; }
        public System.Nullable<short> CustRate { get; set; }
        public System.Nullable<int> CancelReason { get; set; }
        public string DeliveredDate { get; set; }
        public string ArrivingTime { get; set; }
        public string RateNote { get; set; }
        public System.Nullable<int> RateReason { get; set; }
        public string OrDateTime { get; set; }
        public string DropLat { get; set; }
        public string DropLong { get; set; }
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
                return "40" + this.VouNo.ToString();
            }
        }


        public Gas()
        { 
            this.Branch = 1;
            this.VouLoc = "00000";
            this.VouNo = 0;
            this.HDate = "";
            this.GDate = "";
            this.FTime = "";
            this.Name = "";
            this.IDNo = "";
            this.IDType = 0;
            this.IDFrom = "";
            this.MobileNo = "";
            this.Mail = "";
            this.IDDate = "";
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
            this.Descr = "";
            this.PayType = 0;
            this.Address = "";
            this.Remark = "";
            this.PromoCode = "";
            this.Discount = 0;
            this.UserName = "";
            this.UserDate = "";
            this.Amount = 0;
            this.Tax = 0;
            this.CardType = -1;
            this.CardNo = "";
            this.CardHolder = "";
            this.Expiry = "";
            this.Rate = -1;
            this.CustRate = -1;
            this.CancelReason = -1;
            this.DeliveredDate = "";
            this.ArrivingTime = "";
            this.RateNote = "";
            this.RateReason = -1;
            this.OrDateTime = "";
            this.DropLat = "";
            this.DropLong = "";
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
        /// Add Water in Water Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        /// 
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.GasInsert(this.Branch,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.HDate,
                                            this.GDate,
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
                                            this.GasType,
                                            this.DetailType,
                                            this.Qty,
                                            this.Descr,
                                            this.PayType,
                                            this.Address,
                                            this.Remark,
                                            this.PromoCode,
                                            this.Discount,
                                            this.UserName,
                                            this.UserDate,
                                            this.Amount,
                                            this.Tax,
                                            this.CardType,
                                            this.CardNo,
                                            this.CardHolder,
                                            this.Expiry,
                                            this.Rate,
                                            this.CustRate,
                                            this.CancelReason,
                                            this.DeliveredDate,
                                            this.ArrivingTime,
                                            this.RateNote,
                                            this.RateReason,
                                            this.OrDateTime,
                                            this.DropLat,
                                            this.DropLong,
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
        public bool Update(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.GasUpdate(this.Branch,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.HDate,
                                            this.GDate,
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
                                            this.GasType,
                                            this.DetailType,
                                            this.Qty,
                                            this.Descr,
                                            this.PayType,
                                            this.Address,
                                            this.Remark,
                                            this.PromoCode,
                                            this.Discount,
                                            this.UserName,
                                            this.UserDate,
                                            this.Amount,
                                            this.Tax,
                                            this.CardType,
                                            this.CardNo,
                                            this.CardHolder,
                                            this.Expiry,
                                            this.Rate,
                                            this.CustRate,
                                            this.CancelReason,
                                            this.DeliveredDate,
                                            this.ArrivingTime,
                                            this.RateNote,
                                            this.RateReason,
                                            this.OrDateTime,
                                            this.DropLat,
                                            this.DropLong,
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
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.GasStatusUpdate(this.Branch,
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
        /// Add Shipment in Shipment Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        /// 
        public bool UpdateDriverNote(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.GasDriverNoteUpdate(this.Branch,
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
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.GasOrderIssueUpdate(this.Branch,
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
        /// Delete gas in Gas Table
        /// </summary>
        /// <returns>True if Delete Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.GasDelete(Branch, VouLoc, VouNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }



        /// <summary>
        /// get all gas from Gas Table
        /// </summary>
        /// <returns>null</returns>
        public List<Gas> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.GasGetAll();
                    return (from Sitm in result
                            select new Gas
                            {
                                Branch = Sitm.Branch,
                                VouLoc = Sitm.VouLoc,
                                VouNo = Sitm.VouNo,
                                HDate = Sitm.HDate,
                                GDate = Sitm.GDate,
                                FTime = Sitm.FTime,
                                Name = Sitm.Name,
                                IDNo = Sitm.IDNo,
                                IDType = Sitm.IDType,
                                IDFrom = Sitm.IDFrom,
                                IDDate = Sitm.IDDate,
                                Address = Sitm.Address,
                                MobileNo = Sitm.MobileNo,
                                Mail = Sitm.Mail,
                                IDUser = Sitm.IDUser,
                                IDdriver = Sitm.IDdriver,
                                PickLat = Sitm.PickLat,
                                PickLong = Sitm.PickLong,
                                Price = Sitm.Price,
                                SerPrice = Sitm.SerPrice,
                                Status = Sitm.Status,
                                GasType = Sitm.GasType,
                                DetailType = Sitm.DetailType,
                                Qty = Sitm.Qty,
                                Descr = Sitm.Descr,
                                PayType = Sitm.PayType,
                                Remark = Sitm.Remark,
                                PromoCode = Sitm.PromoCode,
                                Discount = Sitm.Discount,
                                UserName = Sitm.UserName,
                                UserDate = Sitm.UserDate,
                                Amount = Sitm.Amount,
                                ArrivingTime = Sitm.ArrivingTime,
                                CancelReason = Sitm.CancelReason,
                                CardHolder = Sitm.CardHolder,
                                CardNo = Sitm.CardNo,
                                CardType = Sitm.CardType,
                                CustRate = Sitm.CustRate,
                                DeliveredDate = Sitm.DeliveredDate,
                                Expiry = Sitm.Expiry,
                                OrDateTime = Sitm.OrDateTime,
                                Rate = Sitm.Rate,
                                RateNote = Sitm.RateNote,
                                RateReason = Sitm.RateReason,
                                Tax = Sitm.Tax,
                                DropLat = Sitm.DropLat,
                                DropLong = Sitm.DropLong,
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



        public List<Gas> GetByVouLoc(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.GasGetByVouLoc(this.Branch, this.VouLoc);
                    return (from itm in result
                            select new Gas
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Mail = itm.Mail,
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
                                Descr = itm.Descr,
                                PayType = itm.PayType,
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Discount = itm.Discount,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Amount = itm.Amount,
                                ArrivingTime = itm.ArrivingTime,
                                CancelReason = itm.CancelReason,
                                CardHolder = itm.CardHolder,
                                CardNo = itm.CardNo,
                                CardType = itm.CardType,
                                CustRate = itm.CustRate,
                                DeliveredDate = itm.DeliveredDate,
                                Expiry = itm.Expiry,
                                OrDateTime = itm.OrDateTime,
                                Rate = itm.Rate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                Tax = itm.Tax,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                DriverNote = itm.DriverNote,
                                DriverNote2 = itm.DriverNote2,
                                IDDriver2 = itm.IDDriver2,
                                OrderIssue = itm.OrderIssue,
                                OrderIssue2 = itm.OrderIssue2,
                                Rate2 = itm.Rate2,
                                Reward1 = itm.Reward1,
                                Reward2 = itm.Reward2,
                                Penal1 = itm.Penal1,
                                Penal2 = itm.Penal2,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2                               
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



        /// <summary>
        /// Find Gas in Gas Table
        /// </summary>
        /// <returns>null</returns>
        public Gas Find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.GasFind(Branch, VouLoc, VouNo);
                    return (from Sitm in result
                            select new Gas
                            {
                                Branch = Sitm.Branch,
                                VouLoc = Sitm.VouLoc,
                                VouNo = Sitm.VouNo,
                                HDate = Sitm.HDate,
                                GDate = Sitm.GDate,
                                FTime = Sitm.FTime,
                                Name = Sitm.Name,
                                IDNo = Sitm.IDNo,
                                IDType = Sitm.IDType,
                                IDFrom = Sitm.IDFrom,
                                IDDate = Sitm.IDDate,
                                Address = Sitm.Address,
                                MobileNo = Sitm.MobileNo,
                                Mail = Sitm.Mail,
                                IDUser = Sitm.IDUser,
                                IDdriver = Sitm.IDdriver,
                                PickLat = Sitm.PickLat,
                                PickLong = Sitm.PickLong,
                                Price = Sitm.Price,
                                SerPrice = Sitm.SerPrice,
                                Status = Sitm.Status,
                                GasType = Sitm.GasType,
                                DetailType = Sitm.DetailType,
                                Qty = Sitm.Qty,
                                Descr = Sitm.Descr,
                                PayType = Sitm.PayType,
                                Remark = Sitm.Remark,
                                PromoCode = Sitm.PromoCode,
                                Discount = Sitm.Discount,
                                UserName = Sitm.UserName,
                                UserDate = Sitm.UserDate,
                                Amount = Sitm.Amount,
                                ArrivingTime = Sitm.ArrivingTime,
                                CancelReason = Sitm.CancelReason,
                                CardHolder = Sitm.CardHolder,
                                CardNo = Sitm.CardNo,
                                CardType = Sitm.CardType,
                                CustRate = Sitm.CustRate,
                                DeliveredDate = Sitm.DeliveredDate,
                                Expiry = Sitm.Expiry,
                                OrDateTime = Sitm.OrDateTime,
                                Rate = Sitm.Rate,
                                RateNote = Sitm.RateNote,
                                RateReason = Sitm.RateReason,
                                Tax = Sitm.Tax,
                                DropLat = Sitm.DropLat,
                                DropLong = Sitm.DropLong,
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
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



        public List<Gas> GetByUserID(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.GasGetByUserID(this.IDUser);
                    return (from itm in result
                            select new Gas
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Mail = itm.Mail,
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
                                Descr = itm.Descr,
                                PayType = itm.PayType,
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Discount = itm.Discount,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Amount = itm.Amount,
                                ArrivingTime = itm.ArrivingTime,
                                CancelReason = itm.CancelReason,
                                CardHolder = itm.CardHolder,
                                CardNo = itm.CardNo,
                                CardType = itm.CardType,
                                CustRate = itm.CustRate,
                                DeliveredDate = itm.DeliveredDate,
                                Expiry = itm.Expiry,
                                OrDateTime = itm.OrDateTime,
                                Rate = itm.Rate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                Tax = itm.Tax,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                DriverNote = itm.DriverNote,
                                DriverNote2 = itm.DriverNote2,
                                IDDriver2 = itm.IDDriver2,
                                OrderIssue = itm.OrderIssue,
                                OrderIssue2 = itm.OrderIssue2,
                                Rate2 = itm.Rate2,
                                Reward1 = itm.Reward1,
                                Reward2 = itm.Reward2,
                                Penal1 = itm.Penal1,
                                Penal2 = itm.Penal2,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2                                                                    
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }




        public List<Gas> GetByUserIDStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.GasGetByIDUserStatus(this.IDUser, this.Status);
                    return (from itm in result
                            select new Gas
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Mail = itm.Mail,
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
                                Descr = itm.Descr,
                                PayType = itm.PayType,
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Discount = itm.Discount,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Amount = itm.Amount,
                                ArrivingTime = itm.ArrivingTime,
                                CancelReason = itm.CancelReason,
                                CardHolder = itm.CardHolder,
                                CardNo = itm.CardNo,
                                CardType = itm.CardType,
                                CustRate = itm.CustRate,
                                DeliveredDate = itm.DeliveredDate,
                                Expiry = itm.Expiry,
                                OrDateTime = itm.OrDateTime,
                                Rate = itm.Rate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                Tax = itm.Tax,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                DriverNote = itm.DriverNote,
                                DriverNote2 = itm.DriverNote2,
                                IDDriver2 = itm.IDDriver2,
                                OrderIssue = itm.OrderIssue,
                                OrderIssue2 = itm.OrderIssue2,
                                Rate2 = itm.Rate2,
                                Reward1 = itm.Reward1,
                                Reward2 = itm.Reward2,
                                Penal1 = itm.Penal1,
                                Penal2 = itm.Penal2,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2                                                                                                                                                                          
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



        public List<Gas> GetByDriverIDStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.GasGetByIDdriverStatus(this.IDdriver, this.Status);
                    return (from itm in result
                            select new Gas
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Mail = itm.Mail,
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
                                Descr = itm.Descr,
                                PayType = itm.PayType,
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Discount = itm.Discount,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Amount = itm.Amount,
                                ArrivingTime = itm.ArrivingTime,
                                CancelReason = itm.CancelReason,
                                CardHolder = itm.CardHolder,
                                CardNo = itm.CardNo,
                                CardType = itm.CardType,
                                CustRate = itm.CustRate,
                                DeliveredDate = itm.DeliveredDate,
                                Expiry = itm.Expiry,
                                OrDateTime = itm.OrDateTime,
                                Rate = itm.Rate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                Tax = itm.Tax,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                DriverNote = itm.DriverNote,
                                DriverNote2 = itm.DriverNote2,
                                IDDriver2 = itm.IDDriver2,
                                OrderIssue = itm.OrderIssue,
                                OrderIssue2 = itm.OrderIssue2,
                                Rate2 = itm.Rate2,
                                Reward1 = itm.Reward1,
                                Reward2 = itm.Reward2,
                                Penal1 = itm.Penal1,
                                Penal2 = itm.Penal2,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2                                                                                                                                                                          
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }




        public List<Gas> GetByStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.GasGetByStatus(this.Status);
                    return (from itm in result
                            select new Gas
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                IDType = itm.IDType,
                                IDFrom = itm.IDFrom,
                                IDDate = itm.IDDate,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Mail = itm.Mail,
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
                                Descr = itm.Descr,
                                PayType = itm.PayType,
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Discount = itm.Discount,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Amount = itm.Amount,
                                ArrivingTime = itm.ArrivingTime,
                                CancelReason = itm.CancelReason,
                                CardHolder = itm.CardHolder,
                                CardNo = itm.CardNo,
                                CardType = itm.CardType,
                                CustRate = itm.CustRate,
                                DeliveredDate = itm.DeliveredDate,
                                Expiry = itm.Expiry,
                                OrDateTime = itm.OrDateTime,
                                Rate = itm.Rate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                Tax = itm.Tax,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                DriverNote = itm.DriverNote,
                                DriverNote2 = itm.DriverNote2,
                                IDDriver2 = itm.IDDriver2,
                                OrderIssue = itm.OrderIssue,
                                OrderIssue2 = itm.OrderIssue2,
                                Rate2 = itm.Rate2,
                                Reward1 = itm.Reward1,
                                Reward2 = itm.Reward2,
                                Penal1 = itm.Penal1,
                                Penal2 = itm.Penal2,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2                                                                                                                                                                          
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Update EmergInv in EmergInv Table
        /// </summary>
        /// <returns>True if EmergInv Success or False if Fail</returns>
        public bool doCancel(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.GasCancel(this.Branch,
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
        /// Update EmergInv in EmergInv Table
        /// </summary>
        /// <returns>True if EmergInv Success or False if Fail</returns>
        public bool doRate(string DriverID, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.GasRate(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
                                                this.Rate, MyEncryption.base64Encode(DriverID), this.RateNote, this.RateReason);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update EmergInv in EmergInv Table
        /// </summary>
        /// <returns>True if EmergInv Success or False if Fail</returns>
        public bool doCustRate(string CustID, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.GasCustRate(this.Branch,
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
        /// Update Invoice center in Invoice Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool UpdateStatusDriver(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.GasStatusDriverUpdate(this.Branch, this.VouLoc, this.VouNo, this.Status, this.IDdriver);

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Get New Code for Gas Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public int? GetMax(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.GasMaxCode(this.Branch, this.VouLoc);
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
