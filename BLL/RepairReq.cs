using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class RepairReq
    {
        public short Branch { get; set; }
        public short LocType { get; set; }
        public short VouLoc { get; set; }
        public int VouNo { get; set; }
        public string VouDate { get; set; }
        public string From2 { get; set; }
        public string InTime { get; set; }
        public System.Nullable<int> VehType { get; set; }
        public string Vehicle { get; set; }
        public System.Nullable<int> KMS { get; set; }
        public string Driver { get; set; }
        public System.Nullable<bool> Require0 { get; set; }
        public System.Nullable<bool> Require1 { get; set; }
        public System.Nullable<bool> Require2 { get; set; }
        public System.Nullable<bool> Require3 { get; set; }
        public System.Nullable<bool> Require4 { get; set; }
        public System.Nullable<bool> Require5 { get; set; }
        public string DateOut { get; set; }
        public string TimeOut { get; set; }
        public string Remark { get; set; }
        public string Require { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public string CarMove { get; set; }
        public string VouNo2
        {
            get
            {
                return (this.LocType == 3 ? "00" : "") + this.VouLoc.ToString() + "/" + this.VouNo.ToString();
            }
        }

        public RepairReq()
        {
            this.Branch = 1;
            this.LocType = 2;
            this.VouLoc = 1;
            this.VouNo = 0;
            this.VouDate = "";
            this.From2 = "";
            this.InTime = "";
            this.VehType = 0;
            this.Vehicle = "";
            this.KMS = 0;
            this.Driver = "";
            this.Require0 = false;
            this.Require1 = false;
            this.Require2 = false;
            this.Require3 = false;
            this.Require4 = false;
            this.Require5 = false;
            this.DateOut = "";
            this.TimeOut = "";
            this.Remark = "";
            this.Require = "";
            this.UserName = "";
            this.UserDate = "";
            this.CarMove = "";
        }


        /// <summary>
        /// Add City in Cities Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.RepairReqInsert(this.Branch, this.LocType, this.VouLoc, this.VouNo, this.From2, this.VouDate, this.InTime, this.VehType, this.Vehicle, this.KMS, this.Driver, this.Require0, this.Require1, this.Require2, this.Require3, this.Require4, this.Require5, this.DateOut, this.TimeOut, this.Remark, this.Require, this.UserName, this.UserDate, this.CarMove);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete City from Cities Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.RepairReqDelete(this.Branch, this.LocType, this.VouLoc, this.VouNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update city in Cities Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.RepairReqUpdate(this.Branch, this.LocType, this.VouLoc, this.VouNo, this.From2, this.VouDate, this.InTime, this.VehType, this.Vehicle, this.KMS, this.Driver, this.Require0, this.Require1, this.Require2, this.Require3, this.Require4, this.Require5, this.DateOut, this.TimeOut, this.Remark, this.Require, this.UserName, this.UserDate, this.CarMove);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select all cities from Cities Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public RepairReq Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.RepairReqGet(this.Branch, this.LocType, this.VouLoc, this.VouNo);
                    return (from itm in result
                            select new RepairReq
                            {
                                 Branch = itm.Branch,
                                 LocType = itm.LocType,
                                 DateOut = itm.DateOut,
                                 Driver = itm.Driver,
                                 From2 = itm.From2,
                                 InTime = itm.InTime,
                                 KMS = itm.KMS,
                                 Remark = itm.Remark,
                                 Require = itm.Require,
                                 Require0 = itm.Require0,
                                 Require1 = itm.Require1,
                                 TimeOut = itm.TimeOut,
                                 Vehicle = itm.Vehicle,
                                 VehType = itm.VehType,
                                 VouDate = itm.VouDate,
                                 VouLoc = itm.VouLoc,
                                 VouNo = itm.VouNo,
                                 UserDate = itm.UserDate,
                                 UserName = itm.UserName,
                                 CarMove = itm.CarMove,
                                 Require2 = itm.Require2,
                                 Require3 = itm.Require3,
                                 Require4 = itm.Require4,
                                 Require5 = itm.Require5
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all cities from Cities Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<RepairReq> FindLast(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.RepairReqGetLast();
                    return (from itm in result
                            select new RepairReq
                            {
                                Branch = itm.Branch,
                                DateOut = itm.DateOut,
                                LocType = itm.LocType,
                                Driver = itm.Driver,
                                From2 = itm.From2,
                                InTime = itm.InTime,
                                KMS = itm.KMS,
                                Remark = itm.Remark,
                                Require = itm.Require,
                                Require0 = itm.Require0,
                                Require1 = itm.Require1,
                                TimeOut = itm.TimeOut,
                                Vehicle = itm.Vehicle,
                                VehType = itm.VehType,
                                VouDate = itm.VouDate,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                CarMove = itm.CarMove,
                                Require2 = itm.Require2,
                                Require3 = itm.Require3,
                                Require4 = itm.Require4,
                                Require5 = itm.Require5
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<vRepairReq> GetAllNotJobWork(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    int i = 1;
                    var result = myContext.vRepairReqNotJobWorkGetAll();
                    return (from itm in result
                            select new vRepairReq
                            {
                                FNo = i++,
                                Branch = itm.Branch,
                                DateOut = itm.DateOut,
                                LocType = itm.LocType,
                                Driver = itm.Driver,
                                From2 = itm.From2,
                                InTime = itm.InTime,
                                KMS = itm.KMS,
                                Remark = itm.Remark,
                                Require = itm.Require,
                                Require0 = itm.Require0,
                                Require1 = itm.Require1,
                                TimeOut = itm.TimeOut,
                                Vehicle = itm.Vehicle,
                                VehType = itm.VehType,
                                VouDate = itm.VouDate,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                CarMove = itm.CarMove,
                                CarName1 = itm.CarName1,
                                CarName2 = itm.CarName2,
                                DriverName1 = itm.DriverName1,
                                DriverName2 = itm.DriverName2,
                                SiteName1 = itm.SiteName1,
                                SiteName2 = itm.SiteName2,
                                PlateNo = itm.PlateNo,
                                Require2 = itm.Require2,
                                Require3 = itm.Require3,
                                Require4 = itm.Require4,
                                Require5 = itm.Require5
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public vRepairReq GetVechNotJobWork(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    int i = 1;
                    var result = myContext.vRepairReqNotJobWorkGetCarNo(this.Vehicle);
                    return (from itm in result
                            select new vRepairReq
                            {
                                FNo = i++,
                                Branch = itm.Branch,
                                DateOut = itm.DateOut,
                                LocType = itm.LocType,
                                Driver = itm.Driver,
                                From2 = itm.From2,
                                InTime = itm.InTime,
                                KMS = itm.KMS,
                                Remark = itm.Remark,
                                Require = itm.Require,
                                Require0 = itm.Require0,
                                Require1 = itm.Require1,
                                TimeOut = itm.TimeOut,
                                Vehicle = itm.Vehicle,
                                VehType = itm.VehType,
                                VouDate = itm.VouDate,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                CarMove = itm.CarMove,
                                CarName1 = itm.CarName1,
                                CarName2 = itm.CarName2,
                                DriverName1 = itm.DriverName1,
                                DriverName2 = itm.DriverName2,
                                SiteName1 = itm.SiteName1,
                                SiteName2 = itm.SiteName2,
                                PlateNo = itm.PlateNo,
                                Require2 = itm.Require2,
                                Require3 = itm.Require3,
                                Require4 = itm.Require4,
                                Require5 = itm.Require5
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<vRepairReq> GetAllInJobWork(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    int i = 1;
                    var result = myContext.vRepairReqInJobWorkGetAll();
                    return (from itm in result
                            select new vRepairReq
                            {
                                FNo = i++,
                                Branch = itm.Branch,
                                DateOut = itm.DateOut,
                                LocType = itm.LocType,
                                Driver = itm.Driver,
                                From2 = itm.From2,
                                InTime = itm.InTime,
                                KMS = itm.KMS,
                                Remark = itm.Remark,
                                Require = itm.Require,
                                Require0 = itm.Require0,
                                Require1 = itm.Require1,
                                TimeOut = itm.TimeOut,
                                Vehicle = itm.Vehicle,
                                VehType = itm.VehType,
                                VouDate = itm.VouDate,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                CarMove = itm.CarMove,
                                CarName1 = itm.CarName1,
                                CarName2 = itm.CarName2,
                                DriverName1 = itm.DriverName1,
                                DriverName2 = itm.DriverName2,
                                SiteName1 = itm.SiteName1,
                                SiteName2 = itm.SiteName2,
                                PlateNo = itm.PlateNo,
                                JobWorkVouDate = itm.JWVouDate,
                                JobWorkVouLoc = itm.JWVouLoc,
                                JobWorkVouNo = itm.JWVouNo,
                                JobWorkVouTime = itm.JWVouTime,
                                Require2 = itm.Require2,
                                Require3 = itm.Require3,
                                Require4 = itm.Require4,
                                Require5 = itm.Require5
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Get New Code for Center Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public int? GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.RepairReqMaxCode(this.Branch, this.LocType, this.VouLoc);
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
    public class vRepairReq : RepairReq
    {
        public int FNo { get; set; }
        public string SiteName1 { get; set; }
        public string SiteName2 { get; set; }
        public string PlateNo { get; set; }
        public string CarName1 { get; set; }
        public string CarName2 { get; set; }
        public string DriverName1 { get; set; }
        public string DriverName2 { get; set; }
        public string Site2Name1 { get; set; }
        public string Site2Name2 { get; set; }
        public short? JobWorkVouLoc { get; set; }
        public int? JobWorkVouNo { get; set; }
        public string JobWorkVouDate { get; set; }
        public string JobWorkVouTime { get; set; }
        public string JobWorkVouNo2
        {
            get
            {
                return "00" + this.JobWorkVouLoc.ToString() + "/" + this.JobWorkVouNo.ToString();
            }
        }

        public vRepairReq()
        {
            this.FNo = 0;
            this.SiteName1 = "";
            this.SiteName2 = "";
            this.PlateNo = "";             
            this.CarName1 = "";
            this.CarName2 = "";
            this.DriverName1 = "";
            this.DriverName2 = "";
            this.Site2Name1 = "الورشة";
            this.Site2Name2 = "Workshop";
            this.JobWorkVouLoc = 1;
            this.JobWorkVouNo = 0;
            this.JobWorkVouDate = "";
            this.JobWorkVouTime = "";
        }
    }
}
