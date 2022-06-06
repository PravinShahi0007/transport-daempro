using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class PReq
    {
        public short Branch { get; set; }
        public int VouNo { get; set; }
        public short VouLoc { get; set; }
        public short FNo { get; set; }
        public string VouDate { get; set; }
        public System.Nullable<int> JobOrder { get; set; }
        public System.Nullable<short> JobOrderLoc { get; set; }
        public string Remark { get; set; }
        public string ITCode { get; set; }
        public string UnitCode { get; set; }
        public System.Nullable<double> Quan { get; set; }
        public System.Nullable<double> Quan2 { get; set; }
        public System.Nullable<double> Bal { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public short? Approved { get; set; }

        public PReq()
        {
            this.Branch = 1;
            this.VouNo = 0; 
            this.VouLoc = 1;
            this.FNo = 1;
            this.VouDate = "";
            this.JobOrder = 0;
            this.JobOrderLoc = 1;
            this.Remark = "";
            this.ITCode = "";
            this.UnitCode = "-1";
            this.Quan = 0;
            this.Quan2 = 0;
            this.Bal = 0;
            this.UserName = "";
            this.UserDate = "";
            this.Approved = 0;
        }

        /// <summary>
        /// Add Item in PReq Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.PReqInsert(this.Branch, this.VouNo, this.VouLoc, this.FNo, this.VouDate, this.JobOrder, this.JobOrderLoc, this.Remark, this.ITCode, this.UnitCode, this.Quan,this.Quan2,this.Bal,this.UserName , this.UserDate , this.Approved);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete PReq from PReq Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.PReqDelete(this.Branch, this.VouNo,this.VouLoc);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select all PReq center from PReq Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<PReq> Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.PReqGet(this.Branch,this.VouNo,this.VouLoc);
                    return (from itm in result
                            select new PReq
                            {
                                Branch = itm.Branch,
                                VouNo  = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                FNo = itm.FNo,
                                VouDate = itm.VouDate,
                                JobOrder = itm.JobOrder,
                                JobOrderLoc = itm.JobOrderLoc,
                                Remark = itm.Remark,
                                ITCode = itm.ITCode,
                                Quan = itm.Quan,
                                Quan2 = itm.Quan2,
                                Bal = itm.Bal,
                                UnitCode = itm.UnitCode,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                Approved = itm.Approved
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all PReq center from PReq Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<PReq> PReqNotInPO(bool CheckQuan, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.PReqNotinPO(CheckQuan);
                    return (from itm in result
                            select new PReq
                            {
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                VouDate = itm.VouDate
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



        /// <summary>
        /// select all PReq center from PReq Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<vPReq> Find20(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vPReqGet(this.Branch, this.VouNo, this.VouLoc);
                    return (from itm in result                            
                            select new vPReq
                            {
                                Branch = itm.Branch,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                FNo = itm.FNo,
                                VouDate = itm.VouDate,
                                JobOrder = itm.JobOrder,
                                JobOrderLoc = itm.JobOrderLoc,
                                Remark = itm.Remark,
                                ITCode = itm.ITCode,
                                Quan = itm.Quan,
                                Quan2 = itm.Quan2,
                                Bal = itm.Bal,
                                UnitCode = itm.UnitCode,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2,
                                UnitName1 = itm.UnitName1,
                                UnitName2 = itm.UnitName2,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Approved = itm.Approved                                                 
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all PReq center from PReq Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<vPReq> Find2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vPReqGet(this.Branch, this.VouNo, this.VouLoc);
                    return (from itm in result
                            where itm.Quan - itm.Quan2>0 && (itm.Approved == 1 || itm.Approved == 3)
                            select new vPReq
                            {
                                Branch = itm.Branch,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                FNo = itm.FNo,
                                VouDate = itm.VouDate,
                                JobOrder = itm.JobOrder,
                                JobOrderLoc = itm.JobOrderLoc,
                                Remark = itm.Remark,
                                ITCode = itm.ITCode,
                                Quan = itm.Quan,
                                Quan2 = itm.Quan2,
                                Bal = itm.Bal,
                                UnitCode = itm.UnitCode,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2,
                                UnitName1 = itm.UnitName1,
                                UnitName2 = itm.UnitName2,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Approved = itm.Approved
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all PReq center from PReq Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<PReq> FindOpenItem(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.PReqGetOpenItem(this.VouNo, this.ITCode);
                    return (from itm in result
                            select new PReq
                            {
                                Branch = itm.Branch,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                FNo = itm.FNo,
                                VouDate = itm.VouDate,
                                JobOrder = itm.JobOrder,
                                JobOrderLoc = itm.JobOrderLoc,
                                Remark = itm.Remark,
                                ITCode = itm.ITCode,
                                Quan = itm.Quan,
                                Quan2 = itm.Quan2,
                                Bal = itm.Bal,
                                UnitCode = itm.UnitCode,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Approved = itm.Approved                                 
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Get New Code for PReq Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public int? GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.PReqaMaxCode(this.Branch,this.VouLoc);
                    return (from Cat in result
                            select Cat.myCode).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cars from MyPO Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<PReq> NotApproved(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.PReqGetNotApproved(this.Branch,this.VouLoc);
                    return (from itm in result
                            select new PReq
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate  = itm.VouDate
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Update Approved Status for Item in MyPo Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool UpdateStatus(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.PReqUpDateStatus(this.Branch, this.VouLoc, this.VouNo, this.FNo , this.Approved);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


    }

    [Serializable]
    public class vPReq
    {
        public short Branch { get; set; }
        public int VouNo { get; set; }
        public short VouLoc { get; set; }
        public short FNo { get; set; }
        public string VouDate { get; set; }
        public System.Nullable<int> JobOrder { get; set; }
        public System.Nullable<short> JobOrderLoc { get; set; }
        public string Remark { get; set; }
        public string ITCode { get; set; }
        public string ITName1 { get; set; }
        public string ITName2 { get; set; }
        public string UnitCode { get; set; }
        public string UnitName1 { get; set; }
        public string UnitName2 { get; set; }
        public System.Nullable<double> Quan { get; set; }
        public System.Nullable<double> Quan2 { get; set; }
        public System.Nullable<double> Bal { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public short? Approved { get; set; }

        public vPReq()
        {
            this.Branch = 1;
            this.VouNo = 0; 
            this.VouLoc = 1;
            this.FNo = 1;
            this.VouDate = "";
            this.JobOrder = 0;
            this.JobOrderLoc = 1;
            this.Remark = "";
            this.ITCode = "";
            this.UnitCode = "-1";
            this.Quan = 0;
            this.Quan2 = 0;
            this.ITName1 = "";
            this.ITName2 = "";
            this.UnitName1 = "";
            this.UnitName2 = "";
            this.Bal = 0;
            this.UserName = "";
            this.UserDate = "";
            this.Approved = 0;
        }
    }

}
