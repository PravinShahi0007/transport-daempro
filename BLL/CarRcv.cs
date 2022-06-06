using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class CarRcv
    {
        public short Branch { get; set; }
        public short LocNumber { get; set; }
        public int Number { get; set; }
        public short FNo { get; set; }
        public string InvNo { get; set; }
        public string Customer { get; set;}
        public string Remark { get; set; }
        public string GDate { get; set; }
        public string GTime { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public string PlateNo { get; set; }
        public string Name { get; set; }
        public string Destination { get; set; }
        public string DestinationName1 { get; set; }
        public string DestinationName2 { get; set; }
        public short? InvFNo { get; set; }
        public CarRcv()
        {
            this.Branch = 0;
            this.LocNumber = 0;
            this.Number = 0;
            this.FNo = 1;
            this.InvNo = "";
            this.Customer = "";
            this.Remark = "";
            this.GDate = "";
            this.GTime = "";
            this.UserName = "";
            this.UserDate = "";
            this.PlateNo = "";
            this.Name = "";
            this.Destination = "";
            this.DestinationName1 = "";
            this.DestinationName2 = "";
            this.InvFNo = 0;
        }

        /// <summary>
        /// Add Car in CarRcv Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CarRcvInsert(this.Branch , this.LocNumber , this.Number ,this.FNo , this.InvNo , this.Customer , this.Remark , this.GDate , this.GTime , this.UserName , this.UserDate , this.InvFNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Car from CarRcv Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CarRcvDelete(this.Branch, this.LocNumber, this.Number);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select all Cars from CarRcv Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<CarRcv> Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarRcvGet(this.Branch , this.LocNumber , this.Number);
                    return (from itm in result
                            select new CarRcv
                            {
                                Branch = itm.Branch,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                GDate = itm.GDate,
                                GTime = itm.GTime,
                                Customer = itm.Customer,
                                InvNo = itm.InvNo,
                                Remark = itm.Remark,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                InvFNo = itm.InvFNo,                                 
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Cars from CarRcv Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<CarRcv> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarRcvGetAll(this.Branch);
                    return (from itm in result
                            select new CarRcv
                            {
                                Branch = itm.Branch,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                GDate = itm.GDate,
                                GTime = itm.GTime,
                                Customer = itm.Customer,
                                InvNo = itm.InvNo,
                                Remark = itm.Remark,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                InvFNo = itm.InvFNo
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cars from CarRcv Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<CarRcv> GetByInv(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarRcvGetByInvoice(this.Branch, this.InvNo);
                    return (from itm in result
                            select new CarRcv
                            {
                                Branch = itm.Branch,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                GDate = itm.GDate,
                                GTime = itm.GTime,
                                Customer = itm.Customer,
                                InvNo = itm.InvNo,
                                Remark = itm.Remark,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                InvFNo = itm.InvFNo
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Cars from CarRcv Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public CarRcv GetByInvFNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarRcvGetByInvoiceFNo(this.Branch, this.InvNo,this.InvFNo);
                    return (from itm in result
                            select new CarRcv
                            {
                                Branch = itm.Branch,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                GDate = itm.GDate,
                                GTime = itm.GTime,
                                Customer = itm.Customer,
                                InvNo = itm.InvNo,
                                Remark = itm.Remark,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                InvFNo = itm.InvFNo
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get New Code for CarMove Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public int? GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarRcvMaxCode(this.Branch,this.LocNumber);
                    return (from Cat in result
                            select Cat.myCode).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }

    [Serializable]
    public class vCarRcvSite
    {
        public short Branch { get; set; }
        public System.Nullable<int> FNo { get; set; }
        public System.Nullable<int> VouNo { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Destination { get; set; }
        public string RecName { get; set; }
        public string RecMobileNo { get; set; }
        public string DestinationName1 { get; set; }
        public string DestinationName2 { get; set; }
        public string PlateNo { get; set; }
        public string ChassisNo { get; set; }
        public string GDate { get; set; }
        public string FTime { get; set; }
        public System.Nullable<double> SiteAmount { get; set; }
        public System.Nullable<double> CustomerAmount { get; set; }
        public short RCVLocNumber { get; set; }
        public int RcvNumber { get; set; }
        public string VouLoc { get; set; }
        public string RcvNo2 { get; set; }
        public string InvDate { get; set; }
        public string InvTime { get; set; }
        public string CarMoveLoc { get; set; }
        public int Number { get; set; }
        public string CarMoveDate { get; set; }
        public string CarMoveTime { get; set; }
        public System.Nullable<short> VouType { get; set; }
        public short DocType { get; set; }
        public string HDate { get; set; }
        public string IDNo { get; set; }
        public System.Nullable<short> IDType { get; set; }
        public string IDFrom { get; set; }
        public string IDDate { get; set; }
        public string Address { get; set; }
        public string PlaceofLoading { get; set; }
        public string FromLoc { get; set; }
        public string ToLoc { get; set; }
        public System.Nullable<double> Amount { get; set; }
        public System.Nullable<double> Amount2 { get; set; }
        public string RecAddress { get; set; }
        public string CarType { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public System.Nullable<double> CashAmount { get; set; }
        public System.Nullable<int> RecVouNo { get; set; }
        public string RecVouDate { get; set; }
        public string Site { get; set; }
        public string Customer { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public string SiteName1 { get; set; }
        public string SiteName2 { get; set; }
        public string CustomerName1 { get; set; }
        public string CustomerName2 { get; set; }
        public string PlaceofLoadingName1 { get; set; }
        public string PlaceofLoadingName2 { get; set; }
        public System.Nullable<short> Qty { get; set; }
        public System.Nullable<short> Qty2 { get; set; }
        public string InvoiceVouLoc { get; set; }
        public bool Status1 { get; set; }
        public System.Nullable<short> InvoiceFNo { get; set; }
        //      public System.Nullable<int> CarMoveNo { get; set; }
        public string VouNo20 { get; set; }
        public string InvFTime { get; set; }
        public System.Nullable<short> FNo2 { get; set; }
        public System.Nullable<short> Payment { get; set; }
        public bool? Transit { get; set; }
        public string MobileNo2 { get; set; }
        public string DriverCode { get; set; }
        public string SendStatus { get; set; }
        public string Flag { get; set; }
        public string Status { get; set; }
        public string Status2
        {
            get
            {
                return sms.ShowResult(this.SendStatus);
            }
        }
        public string VouNo2
        {
            get
            {
                return this.Flag + int.Parse(this.InvoiceVouLoc).ToString() + "/" + this.VouNo.ToString();
            }
        }

        public System.Nullable<double> Price { get; set; }
        public string Mail { get; set; }
        public string RecMail { get; set; }
        public System.Nullable<bool> PlaceFrom { get; set; }
        public System.Nullable<double> Weight { get; set; }
        public System.Nullable<short> Unit { get; set; }
        public System.Nullable<short> ShUse { get; set; }
        public System.Nullable<short> ShType { get; set; }
        public string ShRemark { get; set; }
        public string ShNote { get; set; }
        public System.Nullable<double> ShabakaAmount { get; set; }
        public string LocFrom { get; set; }
        public string LocTo { get; set; }
        public System.Nullable<short> DPeriod { get; set; }
        public string VouLoc2 { get; set; }
        public System.Nullable<short> CoverType { get; set; }
        public System.Nullable<short> CoverSize { get; set; }
        public System.Nullable<bool> bto { get; set; }
        public System.Nullable<short> sitm { get; set; }
        public System.Nullable<short> shipType { get; set; }
        public string ItemName { get; set; }
        public System.Nullable<int> ItemQty { get; set; }
        public System.Nullable<int> Claim { get; set; }
        public System.Nullable<int> myStatus { get; set; }
        public string DTPickUp { get; set; }
        public string DTDropOff { get; set; }
        public string RLat { get; set; }
        public string RLng { get; set; }

        public string InvNo
        {
            get
            {
                return this.Flag + int.Parse(this.VouLoc).ToString() + "/" + this.VouNo.ToString();
            }
        }
        public string CarMoveNo
        {
            get
            {
                return int.Parse(this.CarMoveLoc).ToString() + "/" + this.Number.ToString();
            }
        }
        public string CarMoveRCVNo
        {
            get
            {
                return this.RCVLocNumber.ToString() + "/" + this.RcvNumber.ToString();
            }
        }
        public string SiteAmount2
        {
            get
            {
                if (this.SiteAmount > 0) return this.SiteAmount.ToString() + " فرع";
                else if (this.CustomerAmount > 0) return this.CustomerAmount.ToString() + " عميل";
                else return "لا يوجد";
            }
        }


        /// <summary>
        /// select all Cars from CarRcv Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<vCarRcvSite> Get(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vCarRcvSite(this.RCVLocNumber);
                    int i = 1;
                    return (from itm in result
                            select new vCarRcvSite
                            {
                                FNo = i++,
                                ChassisNo = itm.ChassisNo,
                                CustomerAmount = itm.CustomerAmount,
                                Destination = itm.Destination,
                                DestinationName1 = itm.DestinationName1,
                                DestinationName2 = itm.DestinationName2,
                                FTime = itm.FTime,
                                GDate = itm.GDate,
                                MobileNo = itm.MobileNo,
                                Name = itm.Name,
                                PlateNo = itm.PlateNo,
                                RCVLocNumber = itm.RCVLocNumber,
                                RcvNo2 = itm.RcvNo2,
                                RcvNumber = itm.RcvNumber,
                                RecMobileNo = itm.RecMobileNo,
                                RecName = itm.RecName,
                                SiteAmount = itm.SiteAmount,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                CarMoveDate = itm.CarMoveDate,
                                CarMoveLoc = itm.CarMoveLoc,
                                CarMoveTime = itm.CarMoveTime,
                                InvDate = itm.InvDate,
                                InvTime = itm.InvTime,
                                Number = itm.Number,
                                Status = itm.Status                               
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<vCarRcvSite> Get0(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vCarRcvSite0(this.RCVLocNumber);
                    int i = 1;
                    return (from itm in result
                            select new vCarRcvSite
                            {
                                FNo = i++,
                                ChassisNo = itm.ChassisNo,
                                CustomerAmount = itm.CustomerAmount,
                                Destination = itm.Destination,
                                DestinationName1 = itm.DestinationName1,
                                DestinationName2 = itm.DestinationName2,
                                FTime = itm.FTime,
                                GDate = itm.GDate,
                                MobileNo = itm.MobileNo,
                                Name = itm.Name,
                                PlateNo = itm.PlateNo,
                                RCVLocNumber = itm.RCVLocNumber,
                                RcvNo2 = itm.RcvNo2,
                                RcvNumber = itm.RcvNumber,
                                RecMobileNo = itm.RecMobileNo,
                                RecName = itm.RecName,
                                SiteAmount = itm.SiteAmount,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                CarMoveDate = itm.CarMoveDate,
                                CarMoveLoc = itm.CarMoveLoc,
                                CarMoveTime = itm.CarMoveTime,
                                InvDate = itm.InvDate,
                                InvTime = itm.InvTime,
                                Number = itm.Number,
                                Status = itm.Status,
                                RecAddress = itm.RecAddress,
                                RLat = itm.RLat,
                                RLng = itm.RLng,
                                Flag = ""
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<vCarRcvSite> GetE0(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.vCarRcvSiteE0(this.RCVLocNumber);
                    int i = 1;
                    return (from itm in result
                            select new vCarRcvSite
                            {
                                FNo = i++,
                                ChassisNo = "",
                                CustomerAmount = itm.CustomerAmount,
                                Destination = itm.Destination,
                                DestinationName1 = itm.DestinationName1,
                                DestinationName2 = itm.DestinationName2,
                                FTime = itm.FTime,
                                GDate = itm.GDate,
                                MobileNo = itm.MobileNo,
                                Name = itm.Name,
                                PlateNo = itm.PlateNo,
                                RCVLocNumber = itm.RCVLocNumber,
                                RcvNo2 = itm.RcvNo2,
                                RcvNumber = itm.RcvNumber,
                                RecMobileNo = itm.RecMobileNo,
                                RecName = itm.RecName,
                                SiteAmount = itm.SiteAmount,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                CarMoveDate = itm.CarMoveDate,
                                CarMoveLoc = itm.CarMoveLoc,
                                CarMoveTime = itm.CarMoveTime,
                                InvDate = itm.InvDate,
                                InvTime = itm.InvTime,
                                Number = itm.Number,
                                RecAddress = itm.RecAddress,
                                RLat = itm.DropLat,
                                RLng = itm.DropLong,
                                Flag = "E"
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cars from CarRcv Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<vCarRcvSite> Get2(int MonthNo,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vCarRcvSite2(this.RCVLocNumber,MonthNo);
                    int i = 1;
                    return (from itm in result
                            select new vCarRcvSite
                            {
                                FNo = i++,
                                ChassisNo = itm.ChassisNo,
                                CustomerAmount = itm.CustomerAmount,
                                Destination = itm.Destination,
                                DestinationName1 = itm.DestinationName1,
                                DestinationName2 = itm.DestinationName2,
                                FTime = itm.FTime,
                                GDate = itm.GDate,
                                MobileNo = itm.MobileNo,
                                Name = itm.Name,
                                PlateNo = itm.PlateNo,
                                RCVLocNumber = itm.RCVLocNumber,
                                RcvNo2 = itm.RcvNo2,
                                RcvNumber = itm.RcvNumber,
                                RecMobileNo = itm.RecMobileNo,
                                RecName = itm.RecName,
                                SiteAmount = itm.SiteAmount,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                CarMoveDate = itm.CarMoveDate,
                                CarMoveLoc = itm.CarMoveLoc,
                                CarMoveTime = itm.CarMoveTime,
                                InvDate = itm.InvDate,
                                InvTime = itm.InvTime,
                                Number = itm.Number,
                                Status = itm.Status,
                                Flag = itm.Flag
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cars from CarRcv Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<vCarRcvSite> Get22(int MonthNo, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vCarRcvSite222(this.RCVLocNumber, MonthNo);
                    int i = 1;
                    return (from itm in result
                            select new vCarRcvSite
                            {
                                FNo = i++,
                                ChassisNo = itm.ChassisNo,
                                CustomerAmount = itm.CustomerAmount,
                                Destination = itm.Destination,
                                DestinationName1 = itm.DestinationName1,
                                DestinationName2 = itm.DestinationName2,
                                FTime = itm.FTime,
                                GDate = itm.GDate,
                                MobileNo = itm.MobileNo,
                                Name = itm.Name,
                                PlateNo = itm.PlateNo,
                                RCVLocNumber = itm.RCVLocNumber,
                                RcvNo2 = itm.RcvNo2,
                                RcvNumber = itm.RcvNumber,
                                RecMobileNo = itm.RecMobileNo,
                                RecName = itm.RecName,
                                SiteAmount = itm.SiteAmount,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                CarMoveDate = itm.CarMoveDate,
                                CarMoveLoc = itm.CarMoveLoc,
                                CarMoveTime = itm.CarMoveTime,
                                InvDate = itm.InvDate,
                                InvTime = itm.InvTime,
                                Number = itm.Number,
                                Status = itm.Status,
                                Flag = itm.Flag
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cars from CarRcv Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<vCarRcvSite> Get3(int MonthNo, string ConnectionStr)
        {
            //         try
            //         {
            using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
            {
                var result = myContext.vCarRcvSite3(this.RCVLocNumber, MonthNo, this.Flag);
                int i = 1;
                return (from itm in result
                        //      where myflag == itm.Flag
                        select new vCarRcvSite
                        {
                            //     Branch = itm.Branch,
                            VouLoc = itm.VouLoc,
                            FNo = i++,
                            ChassisNo = itm.ChassisNo,
                            CustomerAmount = itm.CustomerAmount,
                            PlaceofLoading = itm.PlaceofLoading,
                            Destination = itm.Destination,
                            DestinationName1 = itm.DestinationName1,
                            DestinationName2 = itm.DestinationName2,
                            FTime = itm.FTime,
                            GDate = itm.InvDate,
                            MobileNo = itm.MobileNo,
                            Name = itm.Name,
                            Address = itm.Address,
                            InvoiceVouLoc = itm.VouLoc,
                            InvoiceFNo = 1, //(short)itm.FNo,
                            PlateNo = itm.PlateNo,
                            //   PlateNo = itm.Weight.ToString(),
                            RCVLocNumber = itm.RCVLocNumber,
                            RcvNo2 = itm.RcvNo2,
                            RcvNumber = itm.RcvNumber,
                            RecMobileNo = itm.RecMobileNo,
                            RecName = itm.RecName,
                            RecAddress = itm.RecAddress,
                            SiteAmount = itm.SiteAmount,
                            VouNo = itm.VouNo,
                            CarMoveDate = itm.CarMoveDate,
                            CarMoveLoc = itm.CarMoveLoc,
                            CarMoveTime = itm.CarMoveTime,
                            InvDate = itm.InvDate,
                            InvTime = itm.InvTime,
                            Number = itm.Number,
                            Status = itm.Status,
                            Flag = itm.Flag,
                            myStatus = 0 
                        }).ToList();
            }
            //        }
            //        catch (Exception)
            //        {
            //            return null;
            //       }
        }



        /// <summary>
        /// select all Cars from CarRcv Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<vCarRcvSite> GetNotSMS(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vCarRcvNotSMS();
                    int i = 1;
                    return (from itm in result
                            select new vCarRcvSite
                            {
                                FNo = i++,
                                CustomerAmount = itm.CustomerAmount,
                                Destination = itm.Destination,
                                DestinationName1 = itm.DestinationName1,
                                DestinationName2 = itm.DestinationName2,
                                FTime = itm.FTime,
                                GDate = itm.GDate,
                                MobileNo = itm.MobileNo,
                                Name = itm.Name,
                                RCVLocNumber = itm.RCVLocNumber,
                                RcvNumber = itm.RcvNumber,
                                RecMobileNo = itm.RecMobileNo,
                                RecName = itm.RecName,
                                InvoiceFNo = itm.FNo,
                                SiteAmount = itm.SiteAmount,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                CarMoveDate = itm.CarMoveDate,
                                CarMoveLoc = itm.CarMoveLoc,
                                CarMoveTime = itm.CarMoveTime,
                                InvDate = itm.InvDate,
                                InvTime = itm.InvTime,
                                Number = itm.Number,
                                Status = itm.Status                               
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
