using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class JobWork
    {
        public short Branch { get; set; }
        public short VouLoc { get; set; }
        public int VouNo { get; set; }
        public string VouDate { get; set; }
        public string VouTime { get; set; }
        public System.Nullable<short> Status { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public string RepairReq { get; set; }
        public string CarNo { get; set; }
        public string DriverNo { get; set; }
        public string FaultType { get; set; }
        public string RepairType { get; set; }
        public System.Nullable<int> KMReading { get; set; }
        public System.Nullable<int> KMReading2 { get; set; }
        public string EndDateTime { get; set; }
        public System.Nullable<short> CloseType { get; set; }
        public string Forman { get; set; }
        public string Remark { get; set; }
        public string WorkRequset { get; set; }
        public string WorkDone { get; set; }

        public JobWork()
        {
            this.Branch = 1;
            this.VouLoc = 1;
            this.VouNo = 0;
            this.VouDate = "";
            this.VouTime = "";
            this.Status = 0;
            this.UserName = "";
            this.UserDate = "";
            this.RepairReq = "";
            this.CarNo = "-1";
            this.DriverNo = "-1";
            this.FaultType = "";
            this.RepairType = "";
            this.KMReading = 0;
            this.KMReading2 = 0;
            this.EndDateTime = "";
            this.CloseType = 0;
            this.Forman = "-1";
            this.Remark = "";
            this.WorkRequset = "";
            this.WorkDone = "";
        }

        /// <summary>
        /// Add Area in Area Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.JobWorkAdd(this.Branch, this.VouLoc, this.VouNo, this.VouDate, this.VouTime, this.Status, this.UserName, this.UserDate, this.RepairReq, this.CarNo, this.DriverNo, this.FaultType, this.RepairType, this.KMReading, this.KMReading2, this.EndDateTime, this.CloseType, this.Forman, this.Remark, this.WorkRequset,this.WorkDone);
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
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.JobWorkDelete(this.Branch, this.VouLoc, this.VouNo);
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
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.JobWorkUpdate(this.Branch, this.VouLoc, this.VouNo, this.VouDate, this.VouTime, this.Status, this.UserName, this.UserDate, this.RepairReq, this.CarNo, this.DriverNo, this.FaultType, this.RepairType, this.KMReading, this.KMReading2, this.EndDateTime, this.CloseType, this.Forman, this.Remark,this.WorkRequset,this.WorkDone);
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
        public List<JobWork> GetByCarNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JobWorkGetByCarNo(this.CarNo);
                    return (from itm in result
                            select new JobWork
                            {
                                Branch = itm.Branch,
                                CarNo = itm.CarNo,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                CloseType = itm.CloseType,
                                DriverNo = itm.DriverNo,
                                EndDateTime = itm.EndDateTime,
                                FaultType = itm.FaultType,
                                Forman = itm.Forman,
                                KMReading = itm.KMReading,
                                KMReading2 = itm.KMReading2,
                                Remark = itm.Remark,
                                RepairReq = itm.RepairReq,
                                RepairType = itm.RepairType,
                                Status = itm.Status,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                VouDate = itm.VouDate,
                                VouTime = itm.VouTime,
                                WorkDone = itm.WorkDone,
                                WorkRequset = itm.WorkRequest
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
        public JobWork GetOpenCarNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JobWorkOpenCarNo(this.CarNo);
                    return (from itm in result
                            select new JobWork
                            {
                                Branch = itm.Branch,
                                CarNo = itm.CarNo,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                CloseType = itm.CloseType,
                                DriverNo = itm.DriverNo,
                                EndDateTime = itm.EndDateTime,
                                FaultType = itm.FaultType,
                                Forman = itm.Forman,
                                KMReading = itm.KMReading,
                                KMReading2 = itm.KMReading2,
                                Remark = itm.Remark,
                                RepairReq = itm.RepairReq,
                                RepairType = itm.RepairType,
                                Status = itm.Status,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                VouDate = itm.VouDate,
                                VouTime = itm.VouTime,
                                WorkDone = itm.WorkDone,
                                WorkRequset = itm.WorkRequest
                            }).FirstOrDefault();
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
        public JobWork GetByRepairReq(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JobWorkGetByRepairReq(this.RepairReq);
                    return (from itm in result
                            select new JobWork
                            {
                                Branch = itm.Branch,
                                CarNo = itm.CarNo,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                CloseType = itm.CloseType,
                                DriverNo = itm.DriverNo,
                                EndDateTime = itm.EndDateTime,
                                FaultType = itm.FaultType,
                                Forman = itm.Forman,
                                KMReading = itm.KMReading,
                                KMReading2 = itm.KMReading2,
                                Remark = itm.Remark,
                                RepairReq = itm.RepairReq,
                                RepairType = itm.RepairType,
                                Status = itm.Status,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                VouDate = itm.VouDate,
                                VouTime = itm.VouTime,
                                WorkDone = itm.WorkDone,
                                WorkRequset = itm.WorkRequest
                            }).FirstOrDefault();
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
        public JobWork find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JobWorkGet(this.Branch, this.VouLoc, this.VouNo);
                    return (from itm in result
                            select new JobWork
                            {
                                Branch = itm.Branch,
                                CarNo = itm.CarNo,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                CloseType = itm.CloseType,
                                DriverNo = itm.DriverNo,
                                EndDateTime = itm.EndDateTime,
                                FaultType = itm.FaultType,
                                Forman = itm.Forman,
                                KMReading = itm.KMReading,
                                KMReading2 = itm.KMReading2,
                                Remark = itm.Remark,
                                RepairReq = itm.RepairReq,
                                RepairType = itm.RepairType,
                                Status = itm.Status,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                VouDate = itm.VouDate,
                                VouTime = itm.VouTime,
                                WorkDone = itm.WorkDone,
                                WorkRequset = itm.WorkRequest                                  
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
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JobWorkGetMax(this.Branch, this.VouLoc);
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
    public class JobDetails
    {
        public short Branch { get; set; }
        public short VouLoc { get; set; }
        public int VouNo { get; set; }
        public short FNo { get; set; }
        public string TechNo { get; set; }
        public string FDate { get; set; }
        public string FTime { get; set; }
        public string ETime { get; set; }
        public string Remark { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public double? Hour { 
            get{
                return (ETime != "" && FTime != "" ? (DateTime.Parse(ETime) - DateTime.Parse(FTime)).Hours + (DateTime.Parse(ETime) - DateTime.Parse(FTime)).Minutes/60  : 0);   
            
            }
        }
        public double? Amount 
        { get {
            return Hour * Price;
                }
        }


        public JobDetails()
        {
            this.Branch = 1;
            this.VouLoc = 1;
            this.VouNo = 0;
            this.FNo = 1;
            this.FDate = "";
            this.FTime = "";
            this.ETime = "";
            this.Remark = "";
            this.Name = "";
            this.Price = 0;
        }

        /// <summary>
        /// Add Area in Area Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.JobDetailsAdd(this.Branch, this.VouLoc, this.VouNo, this.FNo, this.TechNo, this.FDate, this.FTime, this.ETime, this.Remark,this.Price);
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
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.JobDetailsDelete(this.Branch, this.VouLoc, this.VouNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// select  Cost Acc  from CostAcc Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<JobDetails> find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JobDetailsGet(this.Branch, this.VouLoc, this.VouNo);
                    return (from itm in result
                            select new JobDetails
                            {
                                Branch = itm.Branch,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                Remark = itm.Remark,
                                ETime = itm.ETime,
                                FTime = itm.FTime,
                                FDate = itm.FDate,
                                FNo = itm.FNo,
                                TechNo = itm.TechNo,
                                Price = itm.Price
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
        public List<JobDetails> find2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vJobDetailsGet(this.Branch, this.VouLoc, this.VouNo);
                    return (from itm in result
                            select new JobDetails
                            {
                                Branch = itm.Branch,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                Remark = itm.Remark,
                                ETime = itm.ETime,
                                FTime = itm.FTime,
                                FDate = itm.FDate,
                                FNo = itm.FNo,
                                TechNo = itm.TechNo,
                                Price = itm.Price,
                                Name = itm.Name2
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
