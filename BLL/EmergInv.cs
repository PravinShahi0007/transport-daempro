using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;


namespace BLL
{
    [Serializable]
    public class EmergInv
    {
        public short Branch { get; set; }
        public string VouLoc { get; set; }
        public int VouNo { get; set; }
        public string GDate { get; set; }
        public string HDate { get; set; }        
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
        public string DropLat { get; set; }
        public string DropLong { get; set; }
        public System.Nullable<short> Status { get; set; }
        public System.Nullable<short> CardType { get; set; }
        public System.Nullable<short> PayType { get; set; }
        public string CardNo { get; set; }
        public string CardHolder { get; set; }
        public string Expiry { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public string PromoCode { get; set; }
        public System.Nullable<double> Discount { get; set; }
        public System.Nullable<double> Total { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public System.Nullable<double> Tax { get; set; }
        public short? Rate { get; set; }
        public short? CustRate { get; set; }
        public int? CancelReason { get; set; }
        public string DeliveredDate { get; set; }
        public string ArrivingTime { get; set; }
        public string RateNote { get; set; }
        public System.Nullable<int> RateReason { get; set; }
        public string RecAddress { get; set; }
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
                return "30" + this.VouLoc.Substring(3, 2) + this.VouNo.ToString();
            }
        }
        public string UIID
        {
            get
            {
                return "30" + this.VouNo.ToString();
            }
        }

        public EmergInv()
        { 
            this.Branch = 1;
            this.VouLoc = "00000";
            this.VouNo = 0;
            this.GDate = "";
            this.HDate = "";
            this.FTime = "";
            this.Name = "";
            this.IDNo = "";
            this.IDType = 0;
            this.IDFrom = "";
            this.IDDate = "";
            this.MobileNo = "";
            this.Mail = "";
            this.IDUser = "";
            this.IDdriver = "";
            this.PickLat = "";
            this.PickLong = "";
            this.DropLat = "";
            this.DropLong = "";
            this.Status = 0;
            this.CardType = -1;
            this.PayType = 0;
            this.CardNo  = "";
            this.CardHolder = "";
            this.Expiry = "";
            this.Address = "";
            this.Remark = "";
            this.PromoCode = "";
            this.Discount = 0;
            this.Total = 0;
            this.UserName = "";
            this.UserDate = "";
            this.Tax = 0;
            this.Rate = 0;
            this.CustRate = 0;
            this.CancelReason = 0;
            this.DeliveredDate = "";
            this.ArrivingTime = "";
            this.RateNote = "";
            this.RateReason = -1;
            this.RecAddress = "";
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
        /// Add EmergInv in EmergInv Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        /// 
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.EmergInvInsert(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
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
                                                this.DropLat,
                                                this.DropLong,
                                                this.Status,
                                                this.CardType,
                                                this.PayType,
                                                this.CardNo,
                                                this.CardHolder,
                                                this.Expiry,
                                                this.Address,
                                                this.Remark,
                                                this.PromoCode,
                                                this.Discount,
                                                this.Total,
                                                this.UserName,
                                                this.UserDate,
                                                this.Tax, this.Rate, this.CustRate, this.CancelReason,
                                                this.DeliveredDate,
                                                this.ArrivingTime,
                                                this.RateNote,
                                                this.RateReason,
                                                this.RecAddress,
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
        /// Update EmergInv in EmergInv Table
        /// </summary>
        /// <returns>True if EmergInv Success or False if Fail</returns>
        public bool Update(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.EmergInvUpdate(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
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
                                                this.DropLat,
                                                this.DropLong,
                                                this.Status,
                                                this.CardType,
                                                this.PayType,
                                                this.CardNo,
                                                this.CardHolder,
                                                this.Expiry,
                                                this.Address,
                                                this.Remark,
                                                this.PromoCode,
                                                this.Discount,
                                                this.Total,
                                                this.UserName,
                                                this.UserDate,
                                                this.Tax, this.Rate, this.CustRate, this.CancelReason,
                                                this.DeliveredDate,
                                                this.ArrivingTime,
                                                this.RateNote,
                                                this.RateReason,
                                                this.RecAddress,
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
        /// Update EmergInv in EmergInv Table
        /// </summary>
        /// <returns>True if EmergInv Success or False if Fail</returns>
        public bool StatusUpdate(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.EmergInvStatusUpdate(this.Branch,
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
        /// Update EmergInv in EmergInv Table
        /// </summary>
        /// <returns>True if EmergInv Success or False if Fail</returns>
        public bool StatusDriverUpdate(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.EmergInvStatusDriverUpdate(this.Branch,
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
                    myContext.EmergInvDriverNoteUpdate(this.Branch,
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
                    myContext.EmergInvOrderIssueUpdate(this.Branch,
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
        /// Update EmergInv in EmergInv Table
        /// </summary>
        /// <returns>True if EmergInv Success or False if Fail</returns>
        public bool doCancel(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.EmergInvCancel(this.Branch,
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
        /// Update EmergInv in EmergInv Table
        /// </summary>
        /// <returns>True if EmergInv Success or False if Fail</returns>
        public bool doRate(string DriverID,string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.EmergInvRate(this.Branch,
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
        /// Update EmergInv in EmergInv Table
        /// </summary>
        /// <returns>True if EmergInv Success or False if Fail</returns>
        public bool doCustRate(string CustID,string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.EmergInvCustRate(this.Branch,
                                                this.VouLoc,
                                                this.VouNo,
                                                this.CustRate,MyEncryption.base64Encode(CustID));
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }



        /// <summary>
        /// Delete EmergInv in EmergInv Table
        /// </summary>
        /// <returns>True if Delete Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.EmergInvDelete(Branch, VouLoc, VouNo);
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
        public List<EmergInv> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.EmergInvGetAll();
                    return (from Sitm in result
                            select new EmergInv
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
                                Status = Sitm.Status,
                                CardType = Sitm.CardType,
                                PayType = Sitm.PayType,
                                Remark = Sitm.Remark,
                                PromoCode = Sitm.PromoCode,
                                Discount = Sitm.Discount,
                                Total = Sitm.Total,
                                UserName = Sitm.UserName,
                                UserDate = Sitm.UserDate,
                                CardHolder = Sitm.Cardholder,
                                CardNo = Sitm.CardNo,
                                DropLat = Sitm.DropLat,
                                DropLong = Sitm.DropLong,
                                Expiry = Sitm.Expiry,
                                Tax = Sitm.Tax,
                                CancelReason = Sitm.CancelReason,
                                CustRate = Sitm.CustRate,
                                Rate = Sitm.Rate,
                                ArrivingTime = Sitm.ArrivingTime,
                                DeliveredDate = Sitm.DeliveredDate,
                                RateNote = Sitm.RateNote,
                                RateReason = Sitm.RateReason,
                                RecAddress = Sitm.RecAddress,
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
        /// Find EmergInv in EmergInv Table
        /// </summary>
        /// <returns>null</returns>
        public EmergInv Find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.EmergInvFind(Branch, VouLoc, VouNo);
                    return (from Sitm in result
                            select new EmergInv
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
                                Status = Sitm.Status,
                                CardType = Sitm.CardType,
                                PayType = Sitm.PayType,
                                Remark = Sitm.Remark,
                                PromoCode = Sitm.PromoCode,
                                Discount = Sitm.Discount,
                                Total = Sitm.Total,
                                UserName = Sitm.UserName,
                                UserDate = Sitm.UserDate,
                                CardHolder = Sitm.Cardholder,
                                CardNo = Sitm.CardNo,
                                DropLat = Sitm.DropLat,
                                DropLong = Sitm.DropLong,
                                Expiry = Sitm.Expiry,
                                Tax = Sitm.Tax,
                                CancelReason = Sitm.CancelReason,
                                CustRate = Sitm.CustRate,
                                Rate = Sitm.Rate,
                                ArrivingTime = Sitm.ArrivingTime,
                                DeliveredDate = Sitm.DeliveredDate,
                                RateNote = Sitm.RateNote,
                                RateReason = Sitm.RateReason,
                                RecAddress = Sitm.RecAddress,
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


     
        public List<EmergInv> GetByUserID(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.EmergInvGetByUserID(this.IDUser);
                    return (from itm in result
                            select new EmergInv
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
                                Status = itm.Status,
                                CardType = itm.CardType,
                                PayType = itm.PayType,
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Discount = itm.Discount,
                                Total = itm.Total,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                CardHolder = itm.Cardholder,
                                CardNo = itm.CardNo,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Expiry = itm.Expiry,
                                Tax = itm.Tax,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                RecAddress = itm.RecAddress,
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



      
        public List<EmergInv> GetByUserIDStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.EmergInvGetByIDUserStatus(this.IDUser, this.Status);
                    return (from itm in result
                            select new EmergInv
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
                                Status = itm.Status,
                                CardType = itm.CardType,
                                PayType = itm.PayType,
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Discount = itm.Discount,
                                Total = itm.Total,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                CardHolder = itm.Cardholder,
                                CardNo = itm.CardNo,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Expiry = itm.Expiry,
                                Tax = itm.Tax,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                RecAddress = itm.RecAddress,
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


        public List<EmergInv> GetByDriverIDStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.EmergInvGetByIDdriverStatus(this.IDdriver, this.Status);
                    return (from itm in result
                            select new EmergInv
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
                                Status = itm.Status,
                                CardType = itm.CardType,
                                PayType = itm.PayType,
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Discount = itm.Discount,
                                Total = itm.Total,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                CardHolder = itm.Cardholder,
                                CardNo = itm.CardNo,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Expiry = itm.Expiry,
                                Tax = itm.Tax,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                RecAddress = itm.RecAddress,
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



   
        public List<EmergInv> GetByStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.EmergInvGetByStatus(this.Status);
                    return (from itm in result
                            select new EmergInv
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
                                Status = itm.Status,
                                CardType = itm.CardType,
                                PayType = itm.PayType,
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Discount = itm.Discount,
                                Total = itm.Total,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                CardHolder = itm.Cardholder,
                                CardNo = itm.CardNo,
                                DropLat = itm.DropLat,
                                DropLong = itm.DropLong,
                                Expiry = itm.Expiry,
                                Tax = itm.Tax,
                                CancelReason = itm.CancelReason,
                                CustRate = itm.CustRate,
                                Rate = itm.Rate,
                                ArrivingTime = itm.ArrivingTime,
                                DeliveredDate = itm.DeliveredDate,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                RecAddress = itm.RecAddress,
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
        /// Get New Code for Area Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public int? GetMax(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.EmergInvMaxCode(this.Branch, this.VouLoc);
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


    [Serializable]
    public class Order
    {
        public short OrderType { get; set; }
        public short Branch { get; set; }
        public string VouLoc { get; set; }
        public int VouNo { get; set; }
        public string GDate { get; set; }
        public string HDate { get; set; }
        public string FTime { get; set; }
        public string Name { get; set; } // اسم المرسل
        public string IDNo { get; set; } // رقم هوية المرسل
        public short? IDType { get; set; } // نوع الهوية: إقامة/هوية وطنية
        public string IDFrom { get; set; } // مصدرها
        public string IDDate { get; set; } // تاريخها
        public string MobileNo { get; set; } // رقم الجوال
        public string Email { get; set; } // الايميل
        public string IDUser { get; set; }
        public string IDdriver { get; set; }
        public string PickLat { get; set; }
        public string PickLong { get; set; }
        public string DropLat { get; set; }
        public string DropLong { get; set; }
        public System.Nullable<short> Status { get; set; }
        public System.Nullable<short> CardType { get; set; }
        public string PayType { get; set; }
        public string CardNo { get; set; }
        public string CardHolder { get; set; }
        public string Expiry { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public string PromoCode { get; set; }
        public System.Nullable<double> Discount { get; set; }
        public System.Nullable<double> PTotal { get; set; }
        public System.Nullable<double> STotal { get; set; }
        public System.Nullable<double> Total { get{
            return Math.Round((double)(this.PTotal + this.STotal),2);        
        }}
        public System.Nullable<double> Net { get {
            return Math.Round((double)(this.Total - this.Discount + this.Tax),2);        
        } }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public System.Nullable<double> Tax { get{
            return Math.Round((double)(this.Total - this.Discount) * 0.15,2);            
        }}
        public string RecName { get; set; }
        public string RecAddress { get; set; }
        public string RecMobileNo { get; set; }
        public string RecEmail { get; set; }
        public string OrderDateTime { get; set; }
        public string ServiceCode { get; set; }
        public short? ShipType { get; set; }
        public System.Nullable<short> Qty { get; set; }
        public string DriverName { get; set; }
        public string DriverPhoto { get; set; }
        public string DriverMobileNo { get; set; }
        public string ServiceName { get; set; }
        public string AppIcon { get; set; }
        public string StatusName { get; set;}
        public short? Rate { get; set; }
        public short? CustRate { get; set; }
        public int? CancelReason { get; set; }
        public string CancelReasonName { get; set; }
        public string DeliveredDate { get; set; }
        public string ArrivingTime { get; set; }
        public string RateNote { get; set; }
        public System.Nullable<int> RateReason { get; set; }
        public string RateReasonName { get; set; }
        public double? Duration { get; set; }
        public double? Distance { get; set; }
        public List<ImagesOfOrder> Images { get; set; }
        //public string IDDriver2 { get; set; }
        //public short? Rate2 { get; set; }
        public int? OrderIssue { get; set; }
        public string OrderIssueName { get; set; }
        //public int? OrderIssue2 { get; set; }
        public string DriverNote { get; set; }
        //public string DriverNote2 { get; set; }
        public List<string> TripSummary { get; set; }
        public double? Reward1 { get; set; }
        public double? Reward2 { get; set; }
        public double? Penal1 { get; set; }
        public double? Penal2 { get; set; }
        public double? Earn1 { get; set; }
        public double? Earn2 { get; set; }

        public double? MyPenal { get; set; }
        public double? MyBouns { get; set; }
        public double? MyEarn { get; set; }
        public string CNN { get; set; }
        public string FromName { get{
            string Name = "out side of saudi arabia";
            if (!string.IsNullOrEmpty(this.PickLat) && !string.IsNullOrEmpty(this.PickLong))
            {
                Name = moh.GetCity(this.PickLat, this.PickLong);
            }
            else if(this.OrderType>2)
            {
                Name = "-1";
            }

            if (Name == "-1")
            {
                return Name;
            }
            else 
            {
                Cities myCity = new Cities();
                myCity.Name1 = Name;
                myCity = myCity.Find2(this.CNN);
                return (myCity == null ? "00165" : myCity.Code) + Name;
            }
            
        }
        }
        public string ToName
        {
            get
            {
                string Name = "out side of saudi arabia";
                if (!string.IsNullOrEmpty(this.DropLat) && !string.IsNullOrEmpty(this.DropLong))
                {
                    Name = moh.GetCity(this.DropLat, this.DropLong);
                }

                Cities myCity = new Cities();
                myCity.Name1 = Name;
                myCity = myCity.Find2(this.CNN);
                return (myCity == null ? "00165" : myCity.Code) + Name;
            }
        }
        public string FromName2
        {
            get
            {
                string Name = "out side of saudi arabia";
                if (!string.IsNullOrEmpty(this.PickLat) && !string.IsNullOrEmpty(this.PickLong))
                {
                    Name = moh.GetCity(this.PickLat, this.PickLong);
                }
                else if (this.OrderType > 2)
                {
                    Name = "-1";
                }

                if (Name == "-1")
                {
                    return Name;
                }
                else
                {
                    Cities myCity = new Cities();
                    myCity.Name1 = Name;
                    myCity = myCity.Find2(this.CNN);
                    return (myCity == null ? "00165" : myCity.Code);
                }

            }
        }
        public string ToName2
        {
            get
            {
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
        public string OrderID { get {
            return ((int)this.OrderType * 10).ToString() + this.VouLoc.Substring(3, 2) + this.VouNo.ToString();
        }
        }
        public string UIID
        {
            get
            {
                return this.OrderType.ToString() + (this.VouLoc =="00019" ? "0" : "1") + this.VouNo.ToString();
            }
        }


        public Order()
        {
            this.OrderType = 3;
            this.Branch = 1;
            this.VouLoc = "00019";
            this.VouNo = 0;
            this.GDate = "";
            this.HDate = "";
            this.FTime = "";
            this.Name = "";
            this.IDNo = "";
            this.IDType = 0;
            this.IDFrom = "";
            this.IDDate = "";
            this.MobileNo = "";
            this.Email = "";
            this.IDUser = "";
            this.IDdriver = "";
            this.PickLat = "";
            this.PickLong = "";
            this.DropLat = "";
            this.DropLong = "";
            this.Status = 0;
            this.CardType = -1;
            this.PayType = "0";
            this.CardNo = "";
            this.CardHolder = "";
            this.Expiry = "";
            this.Address = "";
            this.Remark = "";
            this.PromoCode = "";
            this.Discount = 0;
            this.UserName = "";
            this.UserDate = "";
            this.RecName = "";
            this.RecAddress = "";
            this.RecMobileNo = "";
            this.RecEmail = "";
            this.OrderDateTime = "";
            this.ServiceCode = "";
            this.ShipType = -1;
            this.Qty = 0;
            this.DriverName= "";
            this.DriverPhoto = "";
            this.DriverMobileNo = "";
            this.Discount = 0;
            this.PTotal = 0;
            this.STotal = 0;
            this.ServiceName = "";
            this.AppIcon = "";
            this.StatusName = "";
            this.Rate = -1;
            this.CustRate = -1;
            this.CancelReason = -1;
            this.CancelReasonName = "";
            this.DeliveredDate = "";
            this.ArrivingTime = "";
            this.RateNote = "";
            this.RateReason = -1;
            this.RateReasonName = "";
            this.Duration = 0;
            this.Distance = 0;
            //this.IDDriver2 = "";
            //this.Rate2 = -1;
            this.OrderIssue = -1;
            this.OrderIssueName = "";
            //this.OrderIssue2 = -1;
            this.DriverNote = "";
            //this.DriverNote2 = "";
            this.Reward1 = 0;
            this.Reward2 = 0;
            this.Penal1 = 0;
            this.Penal2 = 0;
            this.Earn1 = 0;
            this.Earn2 = 0;
            this.MyPenal = 0;
            this.MyBouns = 10;
            this.MyEarn = 0;
        }


        public Order Find(string iLang, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrdersGet(this.OrderType, this.Branch, this.VouLoc, this.VouNo);
                    return (from itm in result
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDdriver,
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
                                DriverMobileNo = itm.IDdriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto,
                                OrderIssue = itm.OrderIssue,
                                OrderIssueName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.OrderIssueName2 : itm.OrderIssueName1),
                                DriverNote = itm.DriverNote,
                                Qty = (short)itm.Qty,
                                PayType = itm.PayType.ToString(),
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                Reward1 = itm.Reward1,
                                Reward2 = itm.Reward2,
                                MyEarn = itm.Earn1,
                                TripSummary = GetTripSummary(itm.OrderType, itm.VouLoc, itm.VouNo, ConnectionStr,iLang)                                    
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetTripSummary(int OrderType, string VouLoc, int VouNo, string ConnectionStr,string iLang)
        {
            List<string> myResult = new List<string>();
            OrderTran vTran = new OrderTran();
            vTran.OrderType = (short)OrderType;
            vTran.VouLoc = VouLoc;
            vTran.VouNo = VouNo;
            foreach (OrderTran itm in vTran.GetAll(ConnectionStr))
            {
                if (itm.Steps == 1)
                {
                    myResult.Add((string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ?     "Order Accepted    " : "تم قبول الطلب       ") + itm.AcceptDateTime);
                    if (!string.IsNullOrEmpty(itm.StartDateTime))
                        myResult.Add((string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? "Reached Pick-Up   " : "في الطريق للمرسل    ") + itm.StartDateTime);
                    if (!string.IsNullOrEmpty(itm.EndDateTime))
                        myResult.Add((string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? "Order Collected   " : "تم أستلام الطلب      ") + itm.EndDateTime);                    
                }
                else if (itm.Steps == 9)
                {
                    //myResult.Add((string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ?   "Order Accepted    " : "تم قبول الطلب   ") + itm.AcceptDateTime);
                    if (!string.IsNullOrEmpty(itm.EndDateTime))
                        myResult.Add((string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? "Reached Drop-Off  " : "في الطريق للمستلم   ") + itm.EndDateTime);
                    if (!string.IsNullOrEmpty(itm.Delivered))
                        myResult.Add((string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? "Order Delivered   " : "تم تسليم الطلب      ") + itm.Delivered);
                    if (!string.IsNullOrEmpty(itm.Completed))
                        myResult.Add((string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? "Order Completed   " : "تم أنهاء الطلب      ") + itm.Delivered);                    
                }
            }
            return myResult;
        }

        public List<Order> GetByUserName(bool PastOrder,string iLang,string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrdersGetByUserName(this.UserName);
                    return (from itm in result
                            where (PastOrder && (itm.Status == 99 || itm.Status == -2)) || (!PastOrder && itm.Status !=99 && itm.Status !=-2)
                            select new  Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDdriver,
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
                                DriverMobileNo = itm.IDdriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto,
                                OrderIssue = itm.OrderIssue,
                                OrderIssueName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.OrderIssueName2 : itm.OrderIssueName1),
                                DriverNote = itm.DriverNote,
                                Qty = (short)itm.Qty,
                                PayType = itm.PayType.ToString(),
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                MyEarn = itm.Earn1,
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public Order GetFirstUse(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrdersGetFirstUse(this.UserName);
                    return (from itm in result
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDdriver,
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
                                //CancelReasonName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.CancelReasonName2 : itm.CancelReasonName1),
                                DeliveredDate = itm.DeliveredDate,
                                ArrivingTime = itm.ArrivingTime,
                                RateNote = itm.RateNote,
                                RateReason = itm.RateReason,
                                //RateReasonName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.RateReasonName2 : itm.RateReasonName1),
                                DriverMobileNo = itm.IDdriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto,
                                OrderIssue = itm.OrderIssue,
                                //OrderIssueName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.OrderIssueName2 : itm.OrderIssueName1),
                                DriverNote = itm.DriverNote,
                                Qty = (short)itm.Qty,
                                PayType = itm.PayType.ToString(),
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                MyEarn = itm.Earn1
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public int? GetPromoCode(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrdersGetByPromoCode(this.PromoCode);
                    return (from itm in result
                            select itm.FNo).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int? GetUserNamePromoCode(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrdersGetByUserNamePromoCode(this.UserName, this.PromoCode);
                    return (from itm in result
                            select itm.FNo).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }




        public List<Order> GetByIDDriver(bool PastOrder, string iLang, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrdersGetByIDDriver2(this.IDdriver);
                    return (from itm in result
                            where (PastOrder && (itm.Status == 99 || itm.Status == -2)) || (!PastOrder && itm.Status != 99 && itm.Status != -2)
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDdriver,
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
                                DriverMobileNo = itm.IDdriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto,
                                OrderIssue = itm.OrderIssue,
                                OrderIssueName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.OrderIssueName2 : itm.OrderIssueName1),
                                DriverNote = itm.DriverNote,
                                Qty = (short)itm.Qty,
                                PayType = itm.PayType.ToString(),
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                MyEarn = itm.Earn1
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Order> GetByUserName2Rate(string iLang, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrdersGet2Rate(this.UserName);
                    return (from itm in result
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDdriver,
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
                                DriverMobileNo = itm.IDdriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto,
                                OrderIssue = itm.OrderIssue,
                                OrderIssueName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.OrderIssueName2 : itm.OrderIssueName1),
                                DriverNote = itm.DriverNote,
                                Qty = (short)itm.Qty,
                                PayType = itm.PayType.ToString(),
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                MyEarn = itm.Earn1
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<Order> GetByStatus(string iLang,string Services, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrdersGetByStatus(this.Status,this.IDdriver,Services);
                    return (from itm in result
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDdriver,
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
                                DriverMobileNo = itm.IDdriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto,
                                OrderIssue = itm.OrderIssue,
                                OrderIssueName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.OrderIssueName2 : itm.OrderIssueName1),
                                DriverNote = itm.DriverNote,
                                Qty = (short)itm.Qty,
                                PayType = itm.PayType.ToString(),
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                MyEarn = itm.Earn1
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Order> GetByStatus2(string iLang,string Services, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrdersGetByStatus2(this.Status, this.IDdriver,Services);
                    return (from itm in result
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDdriver,
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
                                DriverMobileNo = itm.IDdriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto,
                                OrderIssue = itm.OrderIssue,
                                OrderIssueName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.OrderIssueName2 : itm.OrderIssueName1),
                                DriverNote = itm.DriverNote,
                                Qty = (short)itm.Qty,
                                PayType = itm.PayType.ToString(),
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                MyEarn = itm.Earn1
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public Order GetBy99Driver(string iLang, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrders99GetByIDDriver(this.IDdriver);
                    return (from itm in result
                            //where (PastOrder && itm.Status == 9) || (!PastOrder && itm.Status != 9)
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDdriver,
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
                                DriverMobileNo = itm.IDdriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto,
                                OrderIssue = itm.OrderIssue,
                                OrderIssueName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.OrderIssueName2 : itm.OrderIssueName1),
                                DriverNote = itm.DriverNote,
                                Qty = (short)itm.Qty,
                                PayType = itm.PayType.ToString(),
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                MyEarn = itm.Earn1
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Order GetByUserName2(string iLang, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrdersGetByUserName2(this.UserName);
                    return (from itm in result
                            //where (PastOrder && itm.Status == 9) || (!PastOrder && itm.Status != 9)
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDdriver,
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
                                DriverMobileNo = itm.IDdriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto,
                                OrderIssue = itm.OrderIssue,
                                OrderIssueName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.OrderIssueName2 : itm.OrderIssueName1),
                                DriverNote = itm.DriverNote,
                                Qty = (short)itm.Qty,
                                PayType = itm.PayType.ToString(),
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                MyEarn = itm.Earn1
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Order> GetByWUserName(string FDate,string EDate,string iLang, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrdersGetByWUserName(this.UserName,FDate,EDate);
                    return (from itm in result
                            //where (PastOrder && itm.Status == 9) || (!PastOrder && itm.Status != 9)
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDdriver,
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
                                DriverMobileNo = itm.IDdriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto,
                                OrderIssue = itm.OrderIssue,
                                OrderIssueName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.OrderIssueName2 : itm.OrderIssueName1),
                                DriverNote = itm.DriverNote,
                                Qty = (short)itm.Qty,
                                PayType = itm.PayType.ToString(),
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                MyEarn = itm.Earn1
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Order> GetByWDriver(string FDate, string EDate,string iLang, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrdersGetByDriver(this.IDdriver,FDate,EDate);
                    return (from itm in result
                            //where (PastOrder && itm.Status == 9) || (!PastOrder && itm.Status != 9)
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDdriver,
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
                                DriverMobileNo = itm.IDdriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto,
                                OrderIssue = itm.OrderIssue,
                                OrderIssueName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.OrderIssueName2 : itm.OrderIssueName1),
                                DriverNote = itm.DriverNote,
                                Qty = (short)itm.Qty,
                                PayType = itm.PayType.ToString(),
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                MyEarn = itm.Earn1
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<Order> GetByPenalDriver(string FDate, string EDate, string iLang, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrdersGetByPenalIDDriver(this.IDdriver, FDate, EDate);
                    return (from itm in result
                            //where (PastOrder && itm.Status == 9) || (!PastOrder && itm.Status != 9)
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDdriver,
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
                                DriverMobileNo = itm.IDdriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto,
                                OrderIssue = itm.OrderIssue,
                                OrderIssueName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.OrderIssueName2 : itm.OrderIssueName1),
                                DriverNote = itm.DriverNote,
                                Qty = (short)itm.Qty,
                                PayType = itm.PayType.ToString(),
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Penal1 = itm.Penal1,
                                Penal2 = itm.Penal2,
                                Reward1 = itm.Reward1,
                                Reward2 = itm.Reward2,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                MyEarn = itm.Earn1
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Order> GetByRewardDriver(string FDate, string EDate, string iLang, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrdersGetByRewardIDDriver(this.IDdriver, FDate, EDate);
                    return (from itm in result
                            //where (PastOrder && itm.Status == 9) || (!PastOrder && itm.Status != 9)
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDdriver,
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
                                DriverMobileNo = itm.IDdriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto,
                                OrderIssue = itm.OrderIssue,
                                OrderIssueName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.OrderIssueName2 : itm.OrderIssueName1),
                                DriverNote = itm.DriverNote,
                                Qty = (short)itm.Qty,
                                PayType = itm.PayType.ToString(),
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Penal1 = itm.Penal1,
                                Penal2 = itm.Penal2,
                                Reward1 = itm.Reward1,
                                Reward2 = itm.Reward2,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                MyEarn = itm.Earn1
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<Order> GetByEarnDriver(string FDate, string EDate, string iLang, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrdersGetByRewardIDDriver(this.IDdriver, FDate, EDate);
                    return (from itm in result
                            //where (PastOrder && itm.Status == 9) || (!PastOrder && itm.Status != 9)
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDdriver,
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
                                DriverMobileNo = itm.IDdriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto,
                                OrderIssue = itm.OrderIssue,
                                OrderIssueName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.OrderIssueName2 : itm.OrderIssueName1),
                                DriverNote = itm.DriverNote,
                                Qty = (short)itm.Qty,
                                PayType = itm.PayType.ToString(),
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Penal1 = itm.Penal1,
                                Penal2 = itm.Penal2,
                                Reward1 = itm.Reward1,
                                Reward2 = itm.Reward2,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                MyEarn = itm.Earn1
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



        /*
        public Order Find(string iLang, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrdersGet(this.OrderType, this.Branch, this.VouLoc, this.VouNo);
                    return (from itm in result
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDdriver,
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
                                DriverMobileNo = itm.IDdriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto,
                                OrderIssue = itm.OrderIssue,
                                OrderIssueName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.OrderIssueName2 : itm.OrderIssueName1),
                                DriverNote = itm.DriverNote
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
         */


        public Order GetByIDDriver(string iLang, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrdersGetByIDDriver(this.IDdriver);
                    return (from itm in result
                            //where (PastOrder && itm.Status == 9) || (!PastOrder && itm.Status != 9)
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDdriver,
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
                                DriverMobileNo = itm.IDdriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto,
                                OrderIssue = itm.OrderIssue,
                                OrderIssueName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.OrderIssueName2 : itm.OrderIssueName1),
                                DriverNote = itm.DriverNote,
                                Qty = (short)itm.Qty,
                                PayType = itm.PayType.ToString(),
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                MyEarn = itm.Earn1
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Order> PickedByIDDriver(string iLang, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrdersPickedByIDDriver(this.IDdriver);
                    return (from itm in result
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDdriver,
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
                                DriverMobileNo = itm.IDdriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto,
                                OrderIssue = itm.OrderIssue,
                                OrderIssueName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.OrderIssueName2 : itm.OrderIssueName1),
                                DriverNote = itm.DriverNote,
                                Qty = (short)itm.Qty,
                                PayType = itm.PayType.ToString(),
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                MyEarn = itm.Earn1
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
        public double? IDdriverWRate(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrdersWRate(this.IDdriver);
                    return (from itm in result
                            select Math.Round((double)(itm.MyRate / itm.MyCount), 2)).FirstOrDefault();
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
        public double? IDdriverDRate(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrdersDRate(this.IDdriver);
                    return (from itm in result
                            select Math.Round((double)(itm.MyRate / itm.MyCount), 2)).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Order> GetByDriver2Rate(string iLang, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vOrdersGetDriver2Rate(this.IDdriver);
                    return (from itm in result
                            select new Order
                            {
                                OrderType = (short)itm.OrderType,
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                HDate = itm.HDate,
                                GDate = itm.GDate,
                                FTime = itm.FTime,
                                Name = itm.Name,
                                IDNo = itm.IDNo,
                                Address = itm.Address,
                                MobileNo = itm.MobileNo,
                                Email = itm.Email,
                                IDdriver = itm.IDdriver,
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
                                DriverMobileNo = itm.IDdriver,
                                DriverName = itm.DriverName,
                                DriverPhoto = itm.DriverPhoto,
                                OrderIssue = itm.OrderIssue,
                                OrderIssueName = (string.IsNullOrEmpty(iLang) || iLang.ToUpper() == "EN" ? itm.OrderIssueName2 : itm.OrderIssueName1),
                                DriverNote = itm.DriverNote,
                                Qty = (short)itm.Qty,
                                PayType = itm.PayType.ToString(),
                                Remark = itm.Remark,
                                PromoCode = itm.PromoCode,
                                Earn1 = itm.Earn1,
                                Earn2 = itm.Earn2,
                                MyEarn = itm.Earn1
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
    public class ImagesOfOrder
    {
        public string Imagebase64 { get; set; }
        public string ImageFileName { get; set; }
        public short? ImageNo { get; set; }
        public string ImageRef { get; set; }
        public string UserType
        {
            get
            {
                return (this.ImageRef.StartsWith("Driver") ? "Driver" : "Customer");
            }
        }
        public string MobileNo
        {
            get
            {
                if (!string.IsNullOrEmpty(this.ImageRef))
                {
                    if (this.ImageRef.Split(' ').Count() > 1)
                        if (this.ImageRef.StartsWith("Driver")) return this.ImageRef.Split(' ')[2];
                        else return this.ImageRef.Split(' ')[1];
                    else return "";
                }
                else return "";
            }
        }
    }


}
