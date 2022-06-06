using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Providers
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
        public string OrderID
        {
            get
            {
                return "70" + this.VouLoc.Substring(3, 2) + this.VouNo.ToString();
            }
        }
        public string UIID
        {
            get
            {
                return "70" + this.VouNo.ToString();
            }
        }

        public Providers()
        { 
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
                    myContext.ProvidersInsert(this.Branch,
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
                                                this.DriverNote2                                                
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
                    myContext.ProvidersUpdate(this.Branch,
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
                                                this.DriverNote2                                                                                                                                                
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
                    myContext.ProvidersStatusUpdate(this.Branch,
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
                    myContext.ProvidersStatusDriverUpdate(this.Branch,
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
                    myContext.ProvidersDriverNoteUpdate(this.Branch,
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
                    myContext.ProvidersOrderIssueUpdate(this.Branch,
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
                    myContext.ProvidersCancel(this.Branch,
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
                    myContext.ProvidersRate(this.Branch,
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
                    myContext.ProvidersCustRate(this.Branch,
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
                    myContext.ProvidersDelete(Branch, VouLoc, VouNo);
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
        public List<Providers> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ProvidersGetAll();
                    return (from Sitm in result
                            select new Providers
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
                                Rate2 = Sitm.Rate2
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
        public Providers Find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ProvidersFind(Branch, VouLoc, VouNo);
                    return (from Sitm in result
                            select new Providers
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
                                Rate2 = Sitm.Rate2
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



        public List<Providers> GetByUserID(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ProvidersGetByUserID(this.IDUser);
                    return (from itm in result
                            select new Providers
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
                                Rate2 = itm.Rate2
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }




        public List<Providers> GetByUserIDStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ProvidersGetByIDUserStatus(this.IDUser, this.Status);
                    return (from itm in result
                            select new Providers
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
                                Rate2 = itm.Rate2
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<Providers> GetByDriverIDStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ProvidersGetByIDdriverStatus(this.IDdriver, this.Status);
                    return (from itm in result
                            select new Providers
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
                                Rate2 = itm.Rate2
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }




        public List<Providers> GetByStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ProvidersGetByStatus(this.Status);
                    return (from itm in result
                            select new Providers
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
                                Rate2 = itm.Rate2
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
                    var result = myContext.ProvidersMaxCode(this.Branch, this.VouLoc);
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
