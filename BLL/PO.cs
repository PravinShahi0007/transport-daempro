using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class PO
    {
        public short Branch { get; set; }
        public int VouNo { get; set; }
        public short VouLoc { get; set; }
        public short FNo { get; set; }
        public string VouDate { get; set; }
        public System.Nullable<int> RefNo { get; set; }
        public System.Nullable<short> RefNoLoc { get; set; }
        public System.Nullable<short> RefType { get; set; }
        public System.Nullable<short> FNo2 { get; set; }
        public string Remark { get; set; }
        public string ITCode { get; set; }
        public string UnitCode { get; set; }
        public System.Nullable<double> Quan { get; set; }
        public System.Nullable<double> Quan2 { get; set; }
        public System.Nullable<double> MQuan { get; set; }
        public System.Nullable<double> Price { get; set; }
        public System.Nullable<double> Bal { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public System.Nullable<double> Tax { get; set; }

        public PO()
        {
            this.Branch = 1;
            this.VouNo = 0;
            this.VouLoc = 1;
            this.FNo = 1;
            this.VouDate = "";
            this.RefNo = 0;
            this.RefNoLoc = 1;
            this.RefType = 0;
            this.FNo2 = 1;
            this.Remark = "";
            this.ITCode = "";
            this.UnitCode = "-1";
            this.Quan = 0;
            this.Quan2 = 0;
            this.MQuan = 0;
            this.Price = 0;
            this.Bal = 0;
            this.UserName = "";
            this.UserDate = "";
            this.Tax = 0;
        }

        /// <summary>
        /// Add Item in PO Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.POInsert(this.Branch, this.VouNo, this.VouLoc, this.FNo, this.VouDate, this.RefNo, this.RefNoLoc,this.RefType,this.FNo2, this.Remark, this.ITCode, this.UnitCode, this.Quan,this.Quan2,this.MQuan,this.Price,this.Bal, this.UserName, this.UserDate,this.Tax);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete PO from PO Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.PODelete(this.Branch, this.VouNo, this.VouLoc);
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
        public List<PO> FindOpenItem(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.POGetOpenItem(this.ITCode);
                    return (from itm in result
                            select new PO
                            {
                                Branch = itm.Branch,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                FNo = itm.FNo,
                                VouDate = itm.VouDate,
                                Remark = itm.Remark,
                                ITCode = itm.ITCode,
                                Quan = itm.Quan,
                                Quan2 = itm.Quan2,
                                Bal = itm.Bal,
                                UnitCode = itm.UnitCode,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Price = itm.Price,
                                RefNo = itm.RefNo,
                                RefNoLoc = itm.RefNoLoc,
                                RefType = itm.RefType,
                                Tax = itm.Tax,
                                MQuan = itm.MQuan,
                                FNo2 = itm.FNo2                                 
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
        public List<PO> Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.POGet(this.Branch, this.VouNo, this.VouLoc);
                    return (from itm in result
                            select new PO
                            {
                                Branch = itm.Branch,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                FNo = itm.FNo,
                                VouDate = itm.VouDate,
                                RefNo = itm.RefNo,
                                RefNoLoc = itm.RefNoLoc,                                
                                RefType = itm.RefType,
                                FNo2 = itm.FNo2,
                                Remark = itm.Remark,
                                ITCode = itm.ITCode,
                                Quan = itm.Quan,
                                Quan2 = itm.Quan2,
                                MQuan = itm.MQuan,
                                Price = itm.Price,
                                Bal = itm.Bal,
                                UnitCode = itm.UnitCode,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                Tax = itm.Tax
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
        public List<PO> FindRef2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.POFindRef(this.Branch, this.RefNo, this.RefNoLoc).GroupBy(test => test.VouNo).Select(grp => grp.First()).ToList();
                    return (from itm in result
                            select new PO
                            {
                                Branch = itm.Branch,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                FNo = itm.FNo,
                                VouDate = itm.VouDate,
                                RefNo = itm.RefNo,
                                RefNoLoc = itm.RefNoLoc,
                                RefType = itm.RefType,
                                FNo2 = itm.FNo2,
                                Remark = itm.Remark,
                                ITCode = itm.ITCode,
                                Quan = itm.Quan,
                                Quan2 = itm.Quan2,
                                MQuan = itm.MQuan,
                                Price = itm.Price,
                                Bal = itm.Bal,
                                UnitCode = itm.UnitCode,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                Tax = itm.Tax
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
        public List<PO> FindRef(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.POFindRef(this.Branch,this.RefNo,this.RefNoLoc);
                    return (from itm in result
                            select new PO
                            {
                                Branch = itm.Branch,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                FNo = itm.FNo,
                                VouDate = itm.VouDate,
                                RefNo = itm.RefNo,
                                RefNoLoc = itm.RefNoLoc,
                                RefType = itm.RefType,
                                FNo2 = itm.FNo2,
                                Remark = itm.Remark,
                                ITCode = itm.ITCode,
                                Quan = itm.Quan,
                                Quan2 = itm.Quan2,
                                MQuan = itm.MQuan,
                                Price = itm.Price,
                                Bal = itm.Bal,
                                UnitCode = itm.UnitCode,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                Tax = itm.Tax
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
        public List<PO> POInDNote(bool CheckQuan,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.PONotinDNote(CheckQuan);
                    return (from itm in result
                            select new PO
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
        public List<vPO> Find2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vPOGet(this.Branch, this.VouNo, this.VouLoc);
                    return (from itm in result
                            where itm.Quan - itm.Quan2 > 0
                            select new vPO
                            {
                                Branch = itm.Branch,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                FNo = itm.FNo,
                                VouDate = itm.VouDate,
                                RefNo = itm.RefNo,
                                RefNoLoc = itm.RefNoLoc,
                                RefType = itm.RefType,
                                FNo2 = itm.FNo2,
                                Remark = itm.Remark,
                                ITCode = itm.ITCode,
                                Quan = itm.Quan,
                                Quan2 = itm.Quan2,
                                MQuan = itm.MQuan,
                                Price = itm.Price,
                                Bal = itm.Bal, 
                                UnitCode = itm.UnitCode,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2,
                                UnitName1 = itm.UnitName1,
                                UnitName2 = itm.UnitName2,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Tax = itm.Tax
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
        public List<vPO> Find20(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vPOGet(this.Branch, this.VouNo, this.VouLoc);
                    return (from itm in result                            
                            select new vPO
                            {
                                Branch = itm.Branch,
                                VouNo = itm.VouNo,
                                VouLoc = itm.VouLoc,
                                FNo = itm.FNo,
                                VouDate = itm.VouDate,
                                RefNo = itm.RefNo,
                                RefNoLoc = itm.RefNoLoc,
                                RefType = itm.RefType,
                                FNo2 = itm.FNo2,
                                Remark = itm.Remark,
                                ITCode = itm.ITCode,
                                Quan = itm.Quan,
                                Quan2 = itm.Quan2,
                                MQuan = itm.MQuan,
                                Price = itm.Price,
                                Bal = itm.Bal,
                                UnitCode = itm.UnitCode,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2,
                                UnitName1 = itm.UnitName1,
                                UnitName2 = itm.UnitName2,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                Tax = itm.Tax
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
                    var result = myContext.POMaxCode(this.Branch, this.VouLoc);
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
    public class vPO
    {
        public short Branch { get; set; }
        public int VouNo { get; set; }
        public short VouLoc { get; set; }
        public short FNo { get; set; }
        public string VouDate { get; set; }
        public System.Nullable<int> RefNo { get; set; }
        public System.Nullable<short> RefNoLoc { get; set; }
        public System.Nullable<short> RefType { get; set; }
        public System.Nullable<short> FNo2 { get; set; }
        public string Remark { get; set; }
        public string ITCode { get; set; }
        public string ITName1 { get; set; }
        public string ITName2 { get; set; }
        public string UnitCode { get; set; }
        public string UnitName1 { get; set; }
        public string UnitName2 { get; set; }
        public System.Nullable<double> MQuan { get; set; }
        public System.Nullable<double> Quan { get; set; }
        public System.Nullable<double> Quan2 { get; set; }
        public System.Nullable<double> Price { get; set; }
        public System.Nullable<double> Tax { get; set; }
        public System.Nullable<double> Bal { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public double Amount { 
            get
            {
                return (double)this.Price * (double)this.Quan;            
            }
        }


        public vPO()
        {
            this.Branch = 1;
            this.VouNo = 0;
            this.VouLoc = 1;
            this.FNo = 1;
            this.VouDate = "";
            this.RefNo = 0;
            this.RefNoLoc = 1;
            this.RefType = 0;
            this.FNo2 = 0;
            this.Remark = "";
            this.ITCode = "";
            this.UnitCode = "-1";
            this.MQuan = 0;
            this.Quan = 0;
            this.Quan2 = 0;
            this.Price = 0;
            this.Bal = 0;
            this.ITName1 = "";
            this.ITName2 = "";
            this.UnitName1 = "";
            this.UnitName2 = "";
            this.UserName = "";
            this.UserDate = "";
            this.Tax = 0;
        }
    }

}
