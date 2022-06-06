using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class STS
    {
        public short Branch { get; set; }
        public short Ftype { get; set; }
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
        public System.Nullable<double> Price { get; set; }
        public System.Nullable<double> Bal { get; set; }
        public string CrCode { get; set; }
        public string DbCode { get; set; }
        public System.Nullable<double> ExpAmount { get; set; }
        public System.Nullable<double> ExpPer { get; set; }
        public string ExpRef { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public System.Nullable<short> InvType { get; set; }

        public STS()
        {
            this.Branch = 1;
            this.Ftype = 0;
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
            this.Price = 0;
            this.Bal = 0;
            this.CrCode = "";
            this.DbCode = "";
            this.ExpAmount = 0;
            this.ExpPer = 0;
            this.ExpRef = "";
            this.UserName = "";
            this.UserDate = "";
            this.InvType = 0;
        }

        /// <summary>
        /// Add Item in PTP Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.STSInsert(this.Branch, this.Ftype, this.VouNo, this.VouLoc, this.FNo, this.VouDate, this.RefNo, this.RefNoLoc, this.RefType , this.FNo2, this.Remark, this.ITCode, this.UnitCode, this.Quan,this.Quan2, this.Price, this.Bal, this.CrCode, this.DbCode, this.ExpAmount, this.ExpPer, this.ExpRef, this.UserName, this.UserDate, this.InvType);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Voucher from STS Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.STSDelete(this.Branch, this.Ftype, this.VouNo, this.VouLoc);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Voucher from STS Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.STSDelete2(this.Branch, this.Ftype, this.VouNo, this.VouLoc);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Voucher from STS Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool ResetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.StsReset();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select Vou from STS Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<vSTS> GetCarTotal(string FDate, string EDate, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vStsCarTotal(FDate,EDate);
                    return (from itm in result                            
                            select new vSTS
                            {
                                ExpRef = itm.ExpRef,
                                CarName1 = itm.CarType,
                                CarName2 = itm.CarType2,
                                Bal = itm.MyBal
                            }).OrderByDescending(x => x.Bal).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select Vou from STS Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<vSTS> GetCar(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vStsGetExpRef();
                    return (from itm in result
                            orderby itm.ExpRef
                            select new vSTS
                            {
                                ExpRef = itm.ExpRef,
                                CarName1 = itm.CarType,
                                CarName2 = itm.CarType2,
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<STS> GetNotAgree(short myFNo,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.StsAgree(myFNo);
                    return (from itm in result
                            select new STS
                            {
                                Ftype = itm.fType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
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
        /// select Vou from STS Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<vSTS> GetJO(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vStsGetRemark();
                    return (from itm in result
                            orderby itm.RefNo
                            select new vSTS
                            {
                                RefNo = itm.RefNo
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select Vou from STS Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<vSTS> GetByExpRef(string FDate, string EDate, int SortType, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vStsGetByExpRef(this.ExpRef,FDate, EDate);
                    return (SortType == 0 ?
                            (from itm in result
                             orderby itm.VouNo
                             select new vSTS
                             {
                                 Branch = itm.Branch,
                                 FType = itm.FType,
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
                                 Price = itm.Price,
                                 Bal = itm.Quan * itm.Price,
                                 CrCode = itm.CrCode,
                                 DbCode = itm.DbCode,
                                 ExpAmount = itm.ExpAmount,
                                 ExpPer = itm.ExpPer,
                                 ExpRef = itm.ExpRef,
                                 UnitCode = itm.UnitCode,
                                 ITName1 = itm.ITName1,
                                 ITName2 = itm.ITName2,
                                 UnitName1 = itm.UnitName1,
                                 UnitName2 = itm.UnitName2,
                                 UserName = itm.UserName,
                                 UserDate = itm.UserDate,
                                 InvType = itm.InvType,
                                 CarName1 = itm.CarType,
                                 CarName2 = itm.CarType2
                             }).ToList() : SortType == 1 ?
                            (from itm in result
                             orderby DateTime.Parse(itm.VouDate)
                             select new vSTS
                             {
                                 Branch = itm.Branch,
                                 FType = itm.FType,
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
                                 Price = itm.Price,
                                 Bal = itm.Quan * itm.Price,
                                 CrCode = itm.CrCode,
                                 DbCode = itm.DbCode,
                                 ExpAmount = itm.ExpAmount,
                                 ExpPer = itm.ExpPer,
                                 ExpRef = itm.ExpRef,
                                 UnitCode = itm.UnitCode,
                                 ITName1 = itm.ITName1,
                                 ITName2 = itm.ITName2,
                                 UnitName1 = itm.UnitName1,
                                 UnitName2 = itm.UnitName2,
                                 UserName = itm.UserName,
                                 UserDate = itm.UserDate,
                                 InvType = itm.InvType,
                                 CarName1 = itm.CarType,
                                 CarName2 = itm.CarType2
                             }).ToList() :
                                                        (from itm in result
                                                         orderby itm.ITCode
                                                         select new vSTS
                                                         {
                                                             Branch = itm.Branch,
                                                             FType = itm.FType,
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
                                                             Price = itm.Price,
                                                             Bal = itm.Quan * itm.Price,
                                                             CrCode = itm.CrCode,
                                                             DbCode = itm.DbCode,
                                                             ExpAmount = itm.ExpAmount,
                                                             ExpPer = itm.ExpPer,
                                                             ExpRef = itm.ExpRef,
                                                             UnitCode = itm.UnitCode,
                                                             ITName1 = itm.ITName1,
                                                             ITName2 = itm.ITName2,
                                                             UnitName1 = itm.UnitName1,
                                                             UnitName2 = itm.UnitName2,
                                                             UserName = itm.UserName,
                                                             UserDate = itm.UserDate,
                                                             InvType = itm.InvType,
                                                             CarName1 = itm.CarType,
                                                             CarName2 = itm.CarType2
                                                         }).ToList());
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select Vou from STS Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<vSTS> GetByRemark(string FDate, string EDate, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vStsGetByExpRef(this.Remark, FDate, EDate);
                    return  (from itm in result
                             orderby itm.ITCode
                             select new vSTS
                             {
                                 Branch = itm.Branch,
                                 FType = itm.FType,
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
                                 Price = itm.Price,
                                 Bal = itm.Quan * itm.Price,
                                 CrCode = itm.CrCode,
                                 DbCode = itm.DbCode,
                                 ExpAmount = itm.ExpAmount,
                                 ExpPer = itm.ExpPer,
                                 ExpRef = itm.ExpRef,
                                 UnitCode = itm.UnitCode,
                                 ITName1 = itm.ITName1,
                                 ITName2 = itm.ITName2,
                                 UnitName1 = itm.UnitName1,
                                 UnitName2 = itm.UnitName2,
                                 UserName = itm.UserName,
                                 UserDate = itm.UserDate,
                                 InvType = itm.InvType,
                                 CarName1 = itm.CarType,
                                 CarName2 = itm.CarType2
                             }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select Vou from STS Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<vSTS> GetByITCode(string FDate, string EDate, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vStsGetByITCode(this.ITCode, FDate, EDate);
                    return (from itm in result
                            orderby DateTime.Parse(itm.VouDate)
                            select new vSTS
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
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
                                Price = itm.Price,
                                Bal = itm.Quan * itm.Price,
                                CrCode = itm.CrCode,
                                DbCode = itm.DbCode,
                                ExpAmount = itm.ExpAmount,
                                ExpPer = itm.ExpPer,
                                ExpRef = itm.ExpRef,
                                UnitCode = itm.UnitCode,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2,
                                UnitName1 = itm.UnitName1,
                                UnitName2 = itm.UnitName2,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                InvType = itm.InvType,
                                CarName1 = itm.CarType,
                                CarName2 = itm.CarType2
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select Vou from STS Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<vSTS> GetByRemark2(string FDate, string EDate, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vStsGetByRemark2(this.ExpRef, FDate, EDate);
                    return (from itm in result
                            orderby itm.RefNo
                            select new vSTS
                            {
                                VouDate = itm.VouDate,
                                RefNo = itm.RefNo,
                                Bal = itm.MyBal,
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select Vou from STS Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<vSTS> GetByExpRefITCode(string FDate, string EDate, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vStsGetByExpRefITCode(this.ExpRef, FDate, EDate);
                    return (from itm in result
                            select new vSTS
                            {
                                ITCode = itm.ITCode,
                                Bal = itm.MyBal,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2                               
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select Vou from STS Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<STS> Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.STSGet(this.Branch, this.Ftype, this.VouNo, this.VouLoc);
                    return (from itm in result
                            select new STS
                            {
                                Branch = itm.Branch,
                                Ftype = itm.FType,
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
                                Price = itm.Price,
                                Bal = itm.Bal,
                                CrCode = itm.CrCode,
                                DbCode = itm.DbCode,
                                ExpAmount = itm.ExpAmount,
                                ExpPer = itm.ExpPer,
                                ExpRef = itm.ExpRef,
                                UnitCode = itm.UnitCode,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                InvType = itm.InvType
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
        public List<vSTS> FindRef(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.STSFindRef(this.Branch,this.Ftype, this.RefNo, this.RefNoLoc,this.InvType);
                    return (from itm in result
                            select new vSTS
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
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
                                Price = itm.Price,
                                Bal = itm.Bal,
                                CrCode = itm.CrCode,
                                DbCode = itm.DbCode,
                                ExpAmount = itm.ExpAmount,
                                ExpPer = itm.ExpPer,
                                ExpRef = itm.ExpRef,
                                UnitCode = itm.UnitCode,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2,
                                UnitName1 = itm.UnitName1,
                                UnitName2 = itm.UnitName2,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                InvType = itm.InvType
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
        public List<string> GetAllRef(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.STSRefNo();
                    return (from itm in result
                            select itm.RefNo.ToString()).ToList();
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
        public List<vSTS> Find2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vSTSGet(this.Branch, this.Ftype, this.VouNo, this.VouLoc);
                    return (from itm in result
                            select new vSTS
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
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
                                Price = itm.Price,
                                Bal = itm.Bal,
                                CrCode = itm.CrCode,
                                DbCode = itm.DbCode,
                                ExpAmount = itm.ExpAmount,
                                ExpPer = itm.ExpPer,
                                ExpRef = itm.ExpRef,
                                UnitCode = itm.UnitCode,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2,
                                UnitName1 = itm.UnitName1,
                                UnitName2 = itm.UnitName2,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                InvType = itm.InvType
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
        public List<vSTS> GetStatement(string FDate , string EDate,string ICat,string ItemCard,int? Job,string CarNo, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vSTSGetStatement(this.Branch,EDate,ICat,ItemCard,Job,CarNo);
                    return (from itm in result
                         //   where (FDate != "" && DateTime.Parse(itm.VouDate)>=DateTime.Parse(FDate)) || FDate == ""
                            select new vSTS
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
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
                                Price = itm.Price,
                                Bal = itm.Bal,
                                CrCode = itm.CrCode,
                                DbCode = itm.DbCode,
                                ExpAmount = itm.ExpAmount,
                                ExpPer = itm.ExpPer,
                                ExpRef = itm.ExpRef,
                                UnitCode = itm.UnitCode,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2,
                                UnitName1 = itm.UnitName1,
                                UnitName2 = itm.UnitName2,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                InvType = itm.InvType
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
        public List<int> GetStatement2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.STSGetStatement2();
                    return (from itm in result
                            select itm.VouNo).ToList();
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
                    var result = myContext.STSMaxCode(this.Branch, this.Ftype, this.VouLoc);
                    return (from Cat in result
                            select Cat.myCode).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<StockPeriod> GetStatement(string FDate,string EDate,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    List<StockPeriod> lsp = new List<StockPeriod>();
                    lsp = (from itm in myContext.STSGetStatements(this.Branch, this.VouLoc, FDate, EDate)
                            select new StockPeriod{
                                 FType = itm.FType,
                                 ITCode = itm.ITCode,
                                 OpenQuan = itm.OpenQuan == null ? 0 : itm.OpenQuan,
                                 Quan = itm.TotQuan == null ? 0 : itm.TotQuan,
                                 OpenAmount = itm.OpenAmount == null ? 0 : itm.OpenAmount,
                                 Amount = itm.TotAmount == null ? 0 : itm.TotAmount
                            }).ToList();
                    lsp.AddRange((from itm in myContext.STPGetStatements(this.Branch, this.VouLoc, FDate, EDate)
                            select new StockPeriod{
                                 FType = itm.FType,
                                 ITCode = itm.ITCode,
                                 OpenQuan = itm.OpenQuan == null ? 0 : itm.OpenQuan,
                                 Quan = itm.TotQuan == null ? 0 : itm.TotQuan,
                                 OpenAmount = itm.OpenAmount == null ? 0 : itm.OpenAmount,
                                 Amount = itm.TotAmount == null ? 0 : itm.TotAmount
                            }).ToList());
                    return lsp;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    [Serializable]
    public class StockPeriod
    {
        public short FType { get; set; }
        public string ITCode { get; set; }
        public System.Nullable<double> OpenQuan { get; set; }
        public System.Nullable<double> Quan { get; set; }
        public System.Nullable<double> OpenAmount { get; set; }
        public System.Nullable<double> Amount { get; set; }
    }
 
    [Serializable]
    public class vSTS
    {
        public short Branch { get; set; }
        public short FType { get; set; }
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
        public System.Nullable<double> Quan { get; set; }
        public System.Nullable<double> Quan2 { get; set; }
        public System.Nullable<double> Price { get; set; }
        public System.Nullable<double> Bal { get; set; }
        public string CrCode { get; set; }
        public string DbCode { get; set; }
        public System.Nullable<double> ExpAmount { get; set; }
        public System.Nullable<double> ExpPer { get; set; }
        public string ExpRef { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public System.Nullable<short> InvType { get; set; }
        public string CarName1 { get; set; }
        public string CarName2 { get; set; }
        public string FType2
        {
            get
            {
                switch (this.FType)
                {
                    case 0: return "رصيد أفتتاحي";
                    case 601: return "بيان أستلام";
                    case 501: return "فاتورة مشتريات";
                    case 502: return "فاتورة مرتجع مشتريات";
                    case 701: return "بيان صرف";
                    case 602: return "بيان أستلام";
                    default: return this.FType.ToString();
                }
            }
        }
        public string FType3
        {
            get
            {
                switch (this.FType)
                {
                    case 0: return "Open Balance";
                    case 601: return "Delivery Note";
                    case 501: return "Purchase";
                    case 502: return "Return Purchase";
                    case 701: return "Issue Note";
                    case 602: return "Delivery Note";
                    default: return this.FType.ToString();
                }
            }
        }
        public string VouNo2
        {
            get
            {
                return this.FType == 0 ? "" : this.VouLoc.ToString() + "/" + this.VouNo.ToString();
            }
        }
 
        public double Amount
        {
            get
            {
                return (double)this.Price * (double)this.Quan;
            }
        }
        public double Amount2
        {
            get
            {
                return (double)this.Price * (double)this.Quan2;
            }
        }

        public vSTS()
        {
            this.Branch = 1;
            this.FType = 0;
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
            this.Price = 0;
            this.Bal = 0;
            this.CrCode = "";
            this.DbCode = "";
            this.ExpAmount = 0;
            this.ExpPer = 0;
            this.ExpRef = "";
            this.ITName1 = "";
            this.ITName2 = "";
            this.UnitName1 = "";
            this.UnitName2 = "";
            this.UserName = "";
            this.UserDate = "";
            this.InvType = 0;
            this.CarName1 = "";
            this.CarName2 = "";
        }



    }
}