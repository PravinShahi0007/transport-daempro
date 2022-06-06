using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Jv
    {
        public short Branch { get; set; }
        public short FType { get; set; }
        public short LocType { get; set; }
        public short LocNumber { get; set; }
        public int Number { get; set; }
        public short FNo { get; set; }
        public System.Nullable<short> Post { get; set; }
        public string DbCode { get; set; }
        public string CrCode { get; set; }
        public string FDate { get; set; }
        public System.Nullable<double> Amount { get; set; }
        public string ChequeNo { get; set; }
        public string ChequeDate { get; set; }
        public string InvNo { get; set; }
        public string Remark { get; set; }
        public System.Nullable<short> Seller { get; set; }
        public string Project { get; set; }
        public string BankName { get; set; }
        public string CostCenter { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public string EmpCode { get; set; }
        public string Area { get; set; }
        public string CostAcc { get; set; }
        public string CarNo { get; set; }
        public System.Nullable<short> DocType { get; set; }
        public System.Nullable<short> FNo2 { get; set; }
        public string Person { get; set; }
        public short? Payment { get; set; }
        public int? Claim { get; set; }
        public System.Nullable<bool> AccApprove { get; set; }
        public System.Nullable<bool> GMApprove { get; set; }
        public string AccApproveDate { get; set; }
        public string GMApproveDate { get; set; }
        public string UserDate2 { get; set; }
        public short? UserOP { get; set; }
        public String OPName
        {
            get
            {
                return (this.UserOP == 1 ? "أضافة" : this.UserOP == 2 ? "تعديل" : this.UserOP == 3 ? "الغاء" : "طباعة");                    
            }
        }


        public String VouNo2
        {
            get
            {
                return this.LocNumber.ToString() + "/" + this.Number.ToString();
            }
        }

        public Jv()
        {
            this.Branch = 0;
            this.FType = 0;
            this.LocType = 0;
            this.LocNumber = 0;
            this.Number = 0;
            this.FNo = 0;
            this.Post = 1;
            this.DbCode = "";
            this.CrCode = "";
            this.FDate = "";
            this.Amount = 0;
            this.ChequeNo = "";
            this.ChequeDate = "";
            this.InvNo = "";
            this.Remark = "";
            this.Seller = 0;
            this.Project = "-1";
            this.BankName = "";
            this.CostCenter = "-1";
            this.UserName = "";
            this.UserDate = "";
            this.EmpCode = "-1";
            this.CostAcc = "-1";
            this.Area = "-1";
            this.CarNo = "-1";
            this.DocType = 0;
            this.FNo2 = 0;
            this.Person = "";
            this.Payment = 0;
            this.Claim = 0;
            this.AccApprove = false;
            this.GMApprove = false;
            this.AccApproveDate = "";
            this.GMApproveDate = "";
            this.UserOP = 0;
        }

        /// <summary>
        /// Add Jv Transaction center in Jv Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.JvInsert(this.Branch,
                                        this.FType,
                                        this.LocType,
                                        this.LocNumber,
                                        this.Number,
                                        this.FNo,
                                        this.Post,
                                        this.DbCode,
                                        this.CrCode,
                                        this.FDate,
                                        this.Amount,
                                        this.ChequeNo,
                                        this.ChequeDate,
                                        this.InvNo,
                                        this.Remark,
                                        this.Seller,
                                        this.Project,
                                        this.BankName,
                                        this.CostCenter,
                                        this.UserName,
                                        this.UserDate,
                                        this.EmpCode,
                                        this.Area,
                                        this.CostAcc,
                                        this.CarNo,
                                        this.DocType,
                                        this.FNo2,
                                        this.Person,
                                        this.Payment,
                                        this.Claim,
                                        this.AccApprove,
                                        this.GMApprove,
                                        this.AccApproveDate,
                                        this.GMApproveDate
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
        /// Add Jv Transaction center in Jv Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool pAdd(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.pJvInsert(this.UserDate2,
                                        this.Branch,
                                        this.FType,
                                        this.LocType,
                                        this.LocNumber,
                                        this.Number,
                                        this.FNo,
                                        this.Post,
                                        this.DbCode,
                                        this.CrCode,
                                        this.FDate,
                                        this.Amount,
                                        this.ChequeNo,
                                        this.ChequeDate,
                                        this.InvNo,
                                        this.Remark,
                                        this.Seller,
                                        this.Project,
                                        this.BankName,
                                        this.CostCenter,
                                        this.UserName,
                                        this.UserDate,
                                        this.EmpCode,
                                        this.Area,
                                        this.CostAcc,
                                        this.CarNo,
                                        this.DocType,
                                        this.FNo2,
                                        this.Person,
                                        this.Payment,
                                        this.Claim,
                                        this.AccApprove,
                                        this.GMApprove,
                                        this.AccApproveDate,
                                        this.GMApproveDate,
                                        this.UserOP
                                        );
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Jv> GetNotAgree(short myFNo, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JvAgree(myFNo,this.FType,this.LocType);
                    return (from itm in result
                            where DateTime.Parse(itm.FDate) >= DateTime.Parse("01/09/2020")
                            select new Jv
                            {
                                FType = itm.fType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FDate = itm.FDate
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



        /// <summary>
        /// Add Jv Transaction center in Jv Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool SetAccApprove(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.JvSetAccApprove(this.Branch,this.FType,this.LocType,this.LocNumber,this.Number,this.AccApprove,this.AccApproveDate);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Add Jv Transaction center in Jv Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool SetGMApprove(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.JvSetGMApprove(this.Branch, this.FType, this.LocType, this.LocNumber, this.Number, this.GMApprove, this.GMApproveDate);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }



        /// <summary>
        /// Jv Transaction from Jv Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public double? SumofInvNo(string FDate,string EDate,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    return myContext.JvSumDbByInvNo(this.Branch, this.InvNo, this.DbCode, this.CrCode, FDate,EDate).FirstOrDefault().dbamount;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Delete Jv Transaction from Jv Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.JvDelete(this.Branch,this.FType,this.LocType,this.LocNumber,this.Number);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }



        /// <summary>
        /// Find Jv in Jv Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<Jv> VouNotInMyPO(short MyPoFType,short MyPOLocNumber,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.VouNotMyPO(this.FType, this.LocType, this.LocNumber, MyPoFType, MyPOLocNumber);
                    return (from itm in result
                            select new Jv
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FDate = itm.FDate,
                                Amount = itm.Net
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }





        /// <summary>
        /// Find Jv in Jv Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<Jv> find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JvGet(this.Branch, this.FType, this.LocType, this.LocNumber, this.Number);
                    return (from itm in result
                            select new Jv
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                Post = itm.Post,
                                DbCode = itm.DbCode,
                                CrCode = itm.CrCode,
                                FDate = itm.FDate,
                                Amount = itm.Amount,
                                ChequeNo = itm.ChequeNo,
                                ChequeDate = itm.ChequeDate,
                                InvNo = itm.InvNo,
                                Remark = itm.Remark,
                                Seller = itm.Seller,
                                Project = itm.Project,
                                BankName = itm.BankName,
                                CostCenter = itm.CostCenter,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                EmpCode = itm.EmpCode,
                                Area = itm.Area,
                                CostAcc = itm.CostAcc,
                                CarNo = itm.CarNo,
                                DocType = itm.DocType,
                                FNo2 = itm.FNo2,
                                Person = itm.Person,
                                Payment = itm.Payment,                                
                                Claim = itm.Claim,
                                AccApprove = itm.AccApprove,
                                AccApproveDate = itm.AccApproveDate,
                                GMApprove = itm.GMApprove,
                                GMApproveDate = itm.GMApproveDate                                
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Find Jv in Jv Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<Jv> JvDBCust(string FDate,string EDate,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JVDbCustTrans(this.DbCode,FDate,EDate);
                    return (from itm in result
                            select new Jv
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                Post = itm.Post,
                                DbCode = itm.DbCode,
                                CrCode = itm.CrCode,
                                FDate = itm.FDate,
                                Amount = itm.Amount,
                                ChequeNo = itm.ChequeNo,
                                ChequeDate = itm.ChequeDate,
                                InvNo = itm.InvNo,
                                Remark = itm.Remark,
                                Seller = itm.Seller,
                                Project = itm.Project,
                                BankName = itm.BankName,
                                CostCenter = itm.CostCenter,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                EmpCode = itm.EmpCode,
                                Area = itm.Area,
                                CostAcc = itm.CostAcc,
                                CarNo = itm.CarNo,
                                DocType = itm.DocType,
                                FNo2 = itm.FNo2,
                                Person = itm.Person,
                                Payment = itm.Payment,
                                Claim = itm.Claim,
                                AccApprove = itm.AccApprove,
                                AccApproveDate = itm.AccApproveDate,
                                GMApprove = itm.GMApprove,
                                GMApproveDate = itm.GMApproveDate
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Find Jv in Jv Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public Jv findbyDep(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JvGetByDep(this.Branch, this.FType, this.LocType, this.LocNumber, this.DbCode, this.FDate);
                    return (from itm in result
                            select new Jv
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                Post = itm.Post,
                                DbCode = itm.DbCode,
                                CrCode = itm.CrCode,
                                FDate = itm.FDate,
                                Amount = itm.Amount,
                                ChequeNo = itm.ChequeNo,
                                ChequeDate = itm.ChequeDate,
                                InvNo = itm.InvNo,
                                Remark = itm.Remark,
                                Seller = itm.Seller,
                                Project = itm.Project,
                                BankName = itm.BankName,
                                CostCenter = itm.CostCenter,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                EmpCode = itm.EmpCode,
                                Area = itm.Area,
                                CostAcc = itm.CostAcc,
                                CarNo = itm.CarNo,
                                DocType = itm.DocType,
                                FNo2 = itm.FNo2,
                                Person = itm.Person,
                                Payment = itm.Payment,
                                Claim = itm.Claim,
                                AccApprove = itm.AccApprove,
                                AccApproveDate = itm.AccApproveDate,
                                GMApprove = itm.GMApprove,
                                GMApproveDate = itm.GMApproveDate                                
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Find Jv in Jv Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<vJv> GetLast10(string Account, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JvGetLast10(Account);
                    return (from itm in result
                            select new vJv
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                Post = itm.Post,
                                DbCode = itm.DbCode,
                                CrCode = itm.CrCode,
                                FDate = itm.FDate,
                                Amount = itm.Amount,
                                ChequeNo = itm.ChequeNo,
                                ChequeDate = itm.ChequeDate,
                                InvNo = itm.InvNo,
                                Remark = itm.Remark,
                                Seller = itm.Seller,
                                Project = itm.Project,
                                BankName = itm.BankName,
                                CostCenter = itm.CostCenter,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                EmpCode = itm.EmpCode,
                                AccName1 = itm.AccName1,
                                AccName2 = itm.AccName2,
                                CostName1 = itm.CostName1,
                                CostName2 = itm.CostName2,
                                ProjectName1 = itm.ProjectName1,
                                ProjectName2 = itm.ProjectName2,
                                Area = itm.Area,
                                AreaName1 = itm.AreaName1,
                                AreaName2 = itm.AreaName2,
                                CostAcc = itm.CostAcc,
                                CostAccName1 = itm.CostAccName1,
                                CostAccName2 = itm.CostAccName2,
                                BatchCode = itm.BatchCode,
                                PlateNo = itm.PlateNo,
                                CarNo = itm.CarNo,
                                CarType = itm.CarType,
                                DocType = itm.DocType,
                                FNo2 = itm.FNo2,
                                Person = itm.Person,
                                Payment = itm.Payment
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Find Jv in Jv Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<Jv> GetStatement(string ConnectionStr , string FDate , string EDate)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JvGetStatement(this.Branch, FDate, EDate, this.FType, this.LocType, this.LocNumber);
                    return (from itm in result
                            select new Jv
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                Post = itm.Post,
                                DbCode = itm.DbCode,
                                CrCode = itm.CrCode,
                                FDate = itm.FDate,
                                Amount = itm.Amount,
                                ChequeNo = itm.ChequeNo,
                                ChequeDate = itm.ChequeDate,
                                InvNo = itm.InvNo,
                                Remark = itm.Remark,
                                Seller = itm.Seller,
                                Project = itm.Project,
                                BankName = itm.BankName,
                                CostCenter = itm.CostCenter,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                EmpCode = itm.EmpCode,
                                Area = itm.Area,
                                CostAcc = itm.CostAcc,
                                CarNo = itm.CarNo,
                                DocType = itm.DocType,
                                FNo2 = itm.FNo2,
                                Person = itm.Person,
                                Payment = itm.Payment,
                                Claim = itm.Claim,
                                AccApprove = itm.AccApprove,
                                AccApproveDate = itm.AccApproveDate,
                                GMApprove = itm.GMApprove,
                                GMApproveDate = itm.GMApproveDate                                
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Find Jv in Jv Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<Jv> JvGetClaim(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JvGetByClaim(this.Claim);
                    return (from itm in result
                            select new Jv
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                Post = itm.Post,
                                DbCode = itm.DbCode,
                                CrCode = itm.CrCode,
                                FDate = itm.FDate,
                                Amount = itm.Amount,
                                ChequeNo = itm.ChequeNo,
                                ChequeDate = itm.ChequeDate,
                                InvNo = itm.InvNo,
                                Remark = itm.Remark,
                                Seller = itm.Seller,
                                Project = itm.Project,
                                BankName = itm.BankName,
                                CostCenter = itm.CostCenter,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                EmpCode = itm.EmpCode,
                                Area = itm.Area,
                                CostAcc = itm.CostAcc,
                                CarNo = itm.CarNo,
                                DocType = itm.DocType,
                                FNo2 = itm.FNo2,
                                Person = itm.Person,
                                Payment = itm.Payment,
                                Claim = itm.Claim,
                                AccApprove = itm.AccApprove,
                                AccApproveDate = itm.AccApproveDate,
                                GMApprove = itm.GMApprove,
                                GMApproveDate = itm.GMApproveDate                                
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Find Jv in Jv Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public Jv findInvNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JvGetByInvNo(this.Branch, this.FType, this.InvNo);
                    return (from itm in result
                            select new Jv
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                Post = itm.Post,
                                DbCode = itm.DbCode,
                                CrCode = itm.CrCode,
                                FDate = itm.FDate,
                                Amount = itm.Amount,
                                ChequeNo = itm.ChequeNo,
                                ChequeDate = itm.ChequeDate,
                                InvNo = itm.InvNo,
                                Remark = itm.Remark,
                                Seller = itm.Seller,
                                Project = itm.Project,
                                BankName = itm.BankName,
                                CostCenter = itm.CostCenter,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                EmpCode = itm.EmpCode,
                                Area = itm.Area,
                                CostAcc = itm.CostAcc,
                                CarNo = itm.CarNo,
                                DocType = itm.DocType,
                                FNo2 = itm.FNo2,
                                Person = itm.Person,
                                Payment = itm.Payment,
                                Claim = itm.Claim,
                                AccApprove = itm.AccApprove,
                                AccApproveDate = itm.AccApproveDate,
                                GMApprove = itm.GMApprove,
                                GMApproveDate = itm.GMApproveDate                                
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Jv findInvNo20(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JvGetByInvNo2(this.Branch, this.FType, this.InvNo,this.DocType);
                    return (from itm in result
                            select new Jv
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                Post = itm.Post,
                                DbCode = itm.DbCode,
                                CrCode = itm.CrCode,
                                FDate = itm.FDate,
                                Amount = itm.Amount,
                                ChequeNo = itm.ChequeNo,
                                ChequeDate = itm.ChequeDate,
                                InvNo = itm.InvNo,
                                Remark = itm.Remark,
                                Seller = itm.Seller,
                                Project = itm.Project,
                                BankName = itm.BankName,
                                CostCenter = itm.CostCenter,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                EmpCode = itm.EmpCode,
                                Area = itm.Area,
                                CostAcc = itm.CostAcc,
                                CarNo = itm.CarNo,
                                DocType = itm.DocType,
                                FNo2 = itm.FNo2,
                                Person = itm.Person,
                                Payment = itm.Payment,
                                Claim = itm.Claim,
                                AccApprove = itm.AccApprove,
                                AccApproveDate = itm.AccApproveDate,
                                GMApprove = itm.GMApprove,
                                GMApproveDate = itm.GMApproveDate
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Jv findInvNo30(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JvGetByInvNo3(this.Branch, this.FType, this.InvNo, this.DocType, this.LocType);
                    return (from itm in result
                            select new Jv
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                Post = itm.Post,
                                DbCode = itm.DbCode,
                                CrCode = itm.CrCode,
                                FDate = itm.FDate,
                                Amount = itm.Amount,
                                ChequeNo = itm.ChequeNo,
                                ChequeDate = itm.ChequeDate,
                                InvNo = itm.InvNo,
                                Remark = itm.Remark,
                                Seller = itm.Seller,
                                Project = itm.Project,
                                BankName = itm.BankName,
                                CostCenter = itm.CostCenter,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                EmpCode = itm.EmpCode,
                                Area = itm.Area,
                                CostAcc = itm.CostAcc,
                                CarNo = itm.CarNo,
                                DocType = itm.DocType,
                                FNo2 = itm.FNo2,
                                Person = itm.Person,
                                Payment = itm.Payment,
                                Claim = itm.Claim,
                                AccApprove = itm.AccApprove,
                                AccApproveDate = itm.AccApproveDate,
                                GMApprove = itm.GMApprove,
                                GMApproveDate = itm.GMApproveDate
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



        public List<Jv> findInvNo200(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JvGetByInvNo2(this.Branch, this.FType, this.InvNo, this.DocType);
                    return (from itm in result
                            select new Jv
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                Post = itm.Post,
                                DbCode = itm.DbCode,
                                CrCode = itm.CrCode,
                                FDate = itm.FDate,
                                Amount = itm.Amount,
                                ChequeNo = itm.ChequeNo,
                                ChequeDate = itm.ChequeDate,
                                InvNo = itm.InvNo,
                                Remark = itm.Remark,
                                Seller = itm.Seller,
                                Project = itm.Project,
                                BankName = itm.BankName,
                                CostCenter = itm.CostCenter,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                EmpCode = itm.EmpCode,
                                Area = itm.Area,
                                CostAcc = itm.CostAcc,
                                CarNo = itm.CarNo,
                                DocType = itm.DocType,
                                FNo2 = itm.FNo2,
                                Person = itm.Person,
                                Payment = itm.Payment,
                                Claim = itm.Claim,
                                AccApprove = itm.AccApprove,
                                AccApproveDate = itm.AccApproveDate,
                                GMApprove = itm.GMApprove,
                                GMApproveDate = itm.GMApproveDate
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Find Jv in Jv Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<Jv> findInvNo2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JvGetByInvNo(this.Branch, this.FType, this.InvNo);
                    return (from itm in result
                            select new Jv
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                Post = itm.Post,
                                DbCode = itm.DbCode,
                                CrCode = itm.CrCode,
                                FDate = itm.FDate,
                                Amount = itm.Amount,
                                ChequeNo = itm.ChequeNo,
                                ChequeDate = itm.ChequeDate,
                                InvNo = itm.InvNo,
                                Remark = itm.Remark,
                                Seller = itm.Seller,
                                Project = itm.Project,
                                BankName = itm.BankName,
                                CostCenter = itm.CostCenter,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                EmpCode = itm.EmpCode,
                                Area = itm.Area,
                                CostAcc = itm.CostAcc,
                                CarNo = itm.CarNo,
                                DocType = itm.DocType,
                                FNo2 = itm.FNo2,
                                Person = itm.Person,
                                Payment = itm.Payment,
                                Claim = itm.Claim,
                                AccApprove = itm.AccApprove,
                                AccApproveDate = itm.AccApproveDate,
                                GMApprove = itm.GMApprove,
                                GMApproveDate = itm.GMApproveDate
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Find Jv in Jv Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<vJv> find2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vJvGet(this.Branch, this.FType, this.LocType, this.LocNumber, this.Number);
                    return (from itm in result
                            orderby itm.FNo
                            select new vJv
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                Post = itm.Post,
                                DbCode = itm.DbCode,
                                CrCode = itm.CrCode,
                                FDate = itm.FDate,
                                Amount = itm.Amount,
                                ChequeNo = itm.ChequeNo,
                                ChequeDate = itm.ChequeDate,
                                InvNo = itm.InvNo,
                                Remark = itm.Remark,
                                Seller = itm.Seller,
                                Project = itm.Project,                                 
                                BankName = itm.BankName,
                                CostCenter = itm.CostCenter,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                EmpCode = itm.EmpCode,                               
                                AccName1 = itm.AccName1,
                                AccName2 = itm.AccName2,
                                CostName1 = itm.CostName1,
                                CostName2 = itm.CostName2,
                                ProjectName1  = itm.ProjectName1,
                                ProjectName2 = itm.ProjectName2,                                                                  
                                Area = itm.Area,
                                AreaName1 = itm.AreaName1,
                                AreaName2 = itm.AreaName2,
                                CostAcc = itm.CostAcc,
                                CostAccName1 = itm.CostAccName1,
                                CostAccName2 = itm.CostAccName2,
                                BatchCode = itm.BatchCode,
                                PlateNo = itm.PlateNo,
                                CarNo = itm.CarNo,
                                CarType = itm.CarType,
                                DocType = itm.DocType,
                                FNo2 = itm.FNo2,
                                Person = itm.Person,
                                Payment = itm.Payment,
                                Claim = itm.Claim,
                                EmpName1 = itm.EmpName1,
                                EmpName2 = itm.EmpName2,
                                RecCount = itm.RecCount
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Find Jv in Jv Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<vJv> pfind2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.pvJvGet(this.UserDate2,this.Branch, this.FType, this.LocType, this.LocNumber, this.Number);
                    return (from itm in result
                            orderby itm.FNo
                            select new vJv
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                Post = itm.Post,
                                DbCode = itm.DbCode,
                                CrCode = itm.CrCode,
                                FDate = itm.FDate,
                                Amount = itm.Amount,
                                ChequeNo = itm.ChequeNo,
                                ChequeDate = itm.ChequeDate,
                                InvNo = itm.InvNo,
                                Remark = itm.Remark,
                                Seller = itm.Seller,
                                Project = itm.Project,
                                BankName = itm.BankName,
                                CostCenter = itm.CostCenter,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                EmpCode = itm.EmpCode,
                                AccName1 = itm.AccName1,
                                AccName2 = itm.AccName2,
                                CostName1 = itm.CostName1,
                                CostName2 = itm.CostName2,
                                ProjectName1 = itm.ProjectName1,
                                ProjectName2 = itm.ProjectName2,
                                Area = itm.Area,
                                AreaName1 = itm.AreaName1,
                                AreaName2 = itm.AreaName2,
                                CostAcc = itm.CostAcc,
                                CostAccName1 = itm.CostAccName1,
                                CostAccName2 = itm.CostAccName2,
                                BatchCode = itm.BatchCode,
                                PlateNo = itm.PlateNo,
                                CarNo = itm.CarNo,
                                CarType = itm.CarType,
                                DocType = itm.DocType,
                                FNo2 = itm.FNo2,
                                Person = itm.Person,
                                Payment = itm.Payment,
                                Claim = itm.Claim,
                                EmpName1 = itm.EmpName1,
                                EmpName2 = itm.EmpName2,
                                UserDate2 = itm.UserDate2,
                                UserOP = itm.UserOP
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Find Jv in Jv Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<Jv> pGetList(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.pJvGetTran(this.Branch, this.FType, this.LocType, this.LocNumber, this.Number);
                    return (from itm in result
                            orderby DateTime.Parse(itm.Userdate2)
                            select new Jv
                            {
                                Branch = itm.Branch,
                                FType = itm.fType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                UserName = itm.UserName,
                                UserDate2 = itm.Userdate2,
                                UserOP = itm.UserOP
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Find Jv in Jv Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<string> JvGetMonths(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JvGetMonths();
                    return (from itm in result
                            select itm.FDate).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Find Jv in Jv Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<string> JvGetYears(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JvGetYears();
                    return (from itm in result
                            select itm.FDate).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Find Jv in Jv Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<vJv> GetAll(string ConnectionStr, bool Period , string FDate , string EDate)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vJvGetAll(this.Branch, Period ? "" : FDate, Period ? "" : EDate);
                    return (from itm in result
                            select new vJv
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                Post = itm.Post,
                                DbCode = itm.DbCode,
                                CrCode = itm.CrCode,
                                FDate = itm.FDate,
                                Amount = itm.Amount,
                                ChequeNo = itm.ChequeNo,
                                ChequeDate = itm.ChequeDate,
                                InvNo = itm.InvNo,
                                Remark = itm.Remark,
                                Seller = itm.Seller,
                                Project = itm.Project,
                                BankName = itm.BankName,
                                CostCenter = itm.CostCenter,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                EmpCode = itm.EmpCode,
                                AccName1 = itm.AccName1,
                                AccName2 = itm.AccName2,
                                CostName1 = itm.CostName1,
                                CostName2 = itm.CostName2,
                                ProjectName1 = itm.ProjectName1,
                                ProjectName2 = itm.ProjectName2,
                                Area = itm.Area,
                                AreaName1 = itm.AreaName1,
                                AreaName2 = itm.AreaName2,
                                CostAcc = itm.CostAcc,
                                CostAccName1 = itm.CostAccName1,
                                CostAccName2 = itm.CostAccName2,
                                BatchCode = itm.BatchCode,
                                PlateNo = itm.PlateNo,
                                CarNo = itm.CarNo,
                                CarType = itm.CarType,
                                DocType = itm.DocType,
                                FNo2 = itm.FNo2,
                                Person = itm.Person,
                                RecCount = itm.RecCount
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Find Jv in Jv Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<vJv> GetStatement(string ConnectionStr, bool Period, string FDate, string EDate , string Code , string Area , string CostCenter , string Project , string CostAcc , string EmpCode , string Center , string CarNo)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vJvGetStatement(this.Branch, Period ? "" : FDate, Period ? "" : EDate, Code, Area == "-1" ? "" : Area, CostCenter == "-1" ? "" : CostCenter, Project == "-1" ? "" : Project, CostAcc == "-1" ? "" : CostAcc, EmpCode == "-1" ? "" : EmpCode, Center == "-1" ? "" : Center, CarNo == "-1" ? "" : CarNo);
                    return (from itm in result
                            orderby DateTime.Parse(itm.FDate)
                            select new vJv
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                Post = itm.Post,
                                DbCode = itm.DbCode,
                                CrCode = itm.CrCode,
                                FDate = itm.FDate,
                                Amount = itm.Amount,
                                ChequeNo = itm.ChequeNo,
                                ChequeDate = itm.ChequeDate,
                                InvNo = itm.InvNo,
                                Remark = itm.Remark,
                                Seller = itm.Seller,
                                Project = itm.Project,
                                BankName = itm.BankName,
                                CostCenter = itm.CostCenter,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                EmpCode = itm.EmpCode,
                                AccName1 = itm.AccName1,                                //GetAccName(itm.Branch, itm.FType, itm.LocType, itm.LocNumber, itm.Number, itm.FNo, (itm.DbCode != ""), ConnectionStr),   //itm.AccName1,  
                                AccName2 = itm.AccName2,
                                CostName1 = itm.CostName1,
                                CostName2 = itm.CostName2,
                                ProjectName1 = itm.ProjectName1,
                                ProjectName2 = itm.ProjectName2,
                                Area = itm.Area,
                                AreaName1 = itm.AreaName1,
                                AreaName2 = itm.AreaName2,
                                CostAcc = itm.CostAcc,
                                CostAccName1 = itm.CostAccName1,
                                CostAccName2 = itm.CostAccName2,
                                BatchCode = itm.BatchCode,
                                PlateNo = itm.PlateNo,
                                CarNo = itm.CarNo,
                                CarType = itm.CarType,
                                DocType = itm.DocType,
                                FNo2 = itm.FNo2,
                                Person = itm.Person,
                                Payment = itm.Payment,
                                RecCount = itm.RecCount
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Find Jv in Jv Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<vJv> GetStatement3(string ConnectionStr, bool Period, string FDate, string EDate, string Code, string Area, string CostCenter, string Project, string CostAcc, string EmpCode, string Center, string CarNo)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vJvGetStatement3(this.Branch, Period ? "" : FDate, Period ? "" : EDate, Code, Area == "-1" ? "" : Area, CostCenter == "-1" ? "" : CostCenter, Project == "-1" ? "" : Project, CostAcc == "-1" ? "" : CostAcc, EmpCode == "-1" ? "" : EmpCode, Center == "-1" ? "" : Center, CarNo == "-1" ? "" : CarNo);
                    return (from itm in result
                            orderby DateTime.Parse(itm.FDate)
                            select new vJv
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                Post = itm.Post,
                                DbCode = itm.DbCode,
                                CrCode = itm.CrCode,
                                FDate = itm.FDate,
                                Amount = itm.Amount,
                                ChequeNo = itm.ChequeNo,
                                ChequeDate = itm.ChequeDate,
                                InvNo = itm.InvNo,
                                Remark = itm.Remark,
                                Seller = itm.Seller,
                                Project = itm.Project,
                                BankName = itm.BankName,
                                CostCenter = itm.CostCenter,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                EmpCode = itm.EmpCode,
                                AccName1 = itm.AccName1,                                //GetAccName(itm.Branch, itm.FType, itm.LocType, itm.LocNumber, itm.Number, itm.FNo, (itm.DbCode != ""), ConnectionStr),   //itm.AccName1,  
                                AccName2 = itm.AccName2,
                                CostName1 = itm.CostName1,
                                CostName2 = itm.CostName2,
                                ProjectName1 = itm.ProjectName1,
                                ProjectName2 = itm.ProjectName2,
                                Area = itm.Area,
                                AreaName1 = itm.AreaName1,
                                AreaName2 = itm.AreaName2,
                                CostAcc = itm.CostAcc,
                                CostAccName1 = itm.CostAccName1,
                                CostAccName2 = itm.CostAccName2,
                                BatchCode = itm.BatchCode,
                                PlateNo = itm.PlateNo,
                                CarNo = itm.CarNo,
                                CarType = itm.CarType,
                                DocType = itm.DocType,
                                FNo2 = itm.FNo2,
                                Person = itm.Person,
                                Payment = itm.Payment,
                                RecCount = itm.RecCount
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Find Jv in Jv Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<vJv> GetStatement0(string ConnectionStr, bool Period, string FDate, string EDate, string Code, string Area, string CostCenter, string Project, string CostAcc, string EmpCode, string Center, string CarNo)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vJvGetStatement2(this.Branch, Period ? "" : FDate, Period ? "" : EDate, Code, Area == "-1" ? "" : Area, CostCenter == "-1" ? "" : CostCenter, Project == "-1" ? "" : Project, CostAcc == "-1" ? "" : CostAcc, EmpCode == "-1" ? "" : EmpCode, Center == "-1" ? "" : Center, CarNo == "-1" ? "" : CarNo);
                    return (from itm in result
                            orderby DateTime.Parse(itm.FDate)
                            select new vJv
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                Post = itm.Post,
                                DbCode = itm.DbCode,
                                CrCode = itm.CrCode,
                                FDate = itm.FDate,
                                Amount = itm.Amount,
                                ChequeNo = itm.ChequeNo,
                                ChequeDate = itm.ChequeDate,
                                InvNo = itm.InvNo,
                                Remark = itm.Remark,
                                Seller = itm.Seller,
                                Project = itm.Project,
                                BankName = itm.BankName,
                                CostCenter = itm.CostCenter,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                EmpCode = itm.EmpCode,
                                AccName1 = itm.AccName1,                                //GetAccName(itm.Branch, itm.FType, itm.LocType, itm.LocNumber, itm.Number, itm.FNo, (itm.DbCode != ""), ConnectionStr),   //itm.AccName1,  
                                AccName2 = itm.AccName2,
                                CostName1 = itm.CostName1,
                                CostName2 = itm.CostName2,
                                ProjectName1 = itm.ProjectName1,
                                ProjectName2 = itm.ProjectName2,
                                Area = itm.Area,
                                AreaName1 = itm.AreaName1,
                                AreaName2 = itm.AreaName2,
                                CostAcc = itm.CostAcc,
                                CostAccName1 = itm.CostAccName1,
                                CostAccName2 = itm.CostAccName2,
                                BatchCode = itm.BatchCode,
                                PlateNo = itm.PlateNo,
                                CarNo = itm.CarNo,
                                CarType = itm.CarType,
                                DocType = itm.DocType,
                                FNo2 = itm.FNo2,
                                Person = itm.Person,
                                Payment = itm.Payment,
                                RecCount = itm.RecCount
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetAccName(short Branch,short FType,short LocType,short LocNumber,int Number,short FNo,bool Db,string ConnectionStr)
        {
            string Result = "";
            Jv myJv = new Jv();
            myJv.Branch = Branch;
            myJv.FType = FType;
            myJv.LocType = LocType;
            myJv.LocNumber = LocNumber;
            myJv.Number = Number;
            int i = 0;
            foreach(vJv itm in myJv.find2(ConnectionStr))
            {
                if (itm.FNo != FNo && ((itm.DbCode!="" && !Db) || (itm.CrCode!="" && Db)))
                {
                    Result = itm.AccName1;
                    i++;
                    if (i > 1) break;
                }
            }
            if (i > 1)
            {
                if(!Db) Result = "من مذكورين ";
                else Result = "الى مذكورين ";
            }
            return Result;
        }

        /// <summary>
        /// Get New Number for Jv Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public int? GetNewNumber(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.JvMaxNumber(this.Branch, this.FType, this.LocType, this.LocNumber);
                    return (from Cat in result
                            select Cat.myNumber).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }


    [Serializable]
    public class vJv
    {
        public short Branch { get; set; }
        public short FType { get; set; }
        public short LocType { get; set; }
        public short LocNumber { get; set; }
        public int Number { get; set; }
        public short FNo { get; set; }
        public System.Nullable<short> Post { get; set; }
        public string DbCode { get; set; }
        public string CrCode { get; set; }
        public string AccName1 { get; set; }
        public string AccName2 { get; set; }
        public string FDate { get; set; }
        public System.Nullable<double> Amount { get; set; }
        public string ChequeNo { get; set; }
        public string ChequeDate { get; set; }
        public string InvNo { get; set; }
        public string Remark { get; set; }
        public System.Nullable<short> Seller { get; set; }
        public string Project { get; set; }
        public string ProjectName1 { get; set; }
        public string ProjectName2 { get; set; }
        public string CostName1 { get; set; }
        public string CostName2 { get; set; }
        public string BankName { get; set; }
        public string CostCenter { get; set; }
        public string UserName { get; set; }
        public string UserDate2 { get; set; }
        public string UserDate { get; set; }
        public string EmpCode { get; set; }
        public string EmpName1 { get; set; }
        public string EmpName2 { get; set; }
        public string Area { get; set; }
        public string CarNo { get; set; }
        public string PlateNo { get; set; }
        public string CarType { get; set; }
        public string AreaName1 { get; set; }
        public string AreaName2 { get; set; }
        public string CostAcc { get; set; }
        public string CostAccName1 { get; set; }
        public string CostAccName2 { get; set; }
        public string BatchCode { get; set; }
        public System.Nullable<short> DocType { get; set; }
        public System.Nullable<short> FNo2 { get; set; }
        public string Person { get; set; }
        public System.Nullable<short> Payment { get; set; }
        public System.Nullable<short> UserOP { get; set; }
        public System.Nullable<int> Claim { get; set; }
        public System.Nullable<int> RecCount { get; set; }
        public string Code
        {
            get
            {
                return this.DbCode == "" ? this.CrCode : this.DbCode;
            }
        }
        public double DbAmount
        {
            get
            {
                return (double)(this.DbCode == "" ? 0 : this.Amount);
            }
        }
        public double CrAmount
        {
            get
            {
                return (double)(this.DbCode == "" ? this.Amount : 0);
            }
        }
        public double Bal { get; set; }
        public string FType2
        {
            get
            {
                switch (this.FType) 
                {
                    case 0: return "رصيد أول الفترة"; 
                    case 100: return "قيد يومية"; 
                    case 101: return "سند قبض";
                    case 102: return "سند صرف";
                    case 103: return "فاتورة شحن";
                    case 104: return "بيان ترحيل";
                    case 105: return "قسيمة إيداع بنكي";
                    case 106: return "تحويل بنكي";
                    case 107: return "فاتورة شحن طرود";
                    case 108: return "فاتورة شحن بضاعة";
                    case 501: return "فاتورة مشتريات";
                    case 502: return "فاتورة ترجيع مشتريات";
                    case 503: return "بيان أستلام مستعمل";
                    case 701: return "سند صرف بضاعة";
                    case 801: return "بيان أصلاح خارجي";
                    case 111: return "مصروف التجميع";
                    case 112: return "سداد مصروف التجميع";
                    case 113: return "مصروف التوزيع";
                    case 114: return "سداد مصروف التوزيع";
                    case 115: return "تحصيل لمحفظة سائق"; 
                    case 802: return "بيان مصروفات نثرية";
                    case 999: return "رصيد أخر الفترة"; 
                    default:  return "أخرى";
                }
            }
        }
        public string FType3
        {
            get
            {
                switch (this.FType)
                {
                    case 0: return "رصيد أول الفترة";
                    case 100: return "قيد يومية";
                    case 101: return "سند قبض";
                    case 102: return "سند صرف";
                    case 103: return "فاتورة شحن";
                    case 104: return "بيان ترحيل";
                    case 105: return "إيداع بنكي";
                    case 106: return "تحويل بنكي";
                    case 107: return "فاتورة شحن طرود";
                    case 108: return "فاتورة شحن بضاعة";
                    case 501: return "مشتريات";
                    case 502: return "ت مشتريات";
                    case 503: return "بيان أستلام مستعمل";
                    case 701: return "سند صرف بضاعة";
                    case 801: return "بيان أصلاح خارجي";
                    case 802: return "بيان مصروفات نثرية";
                    case 111: return "مصروف التجميع";
                    case 112: return "سداد مصروف التجميع";
                    case 113: return "مصروف التوزيع";
                    case 114: return "سداد مصروف التوزيع";
                    case 115: return "تحصيل لمحفظة سائق"; 
                    case 999: return "رصيد أخر الفترة";
                    default: return "أخرى";
                }
            }
        }

        public vJv()
        {
            this.Branch = 0;
            this.FType = 0;
            this.LocType = 0;
            this.LocNumber = 0;
            this.Number = 0;
            this.FNo = 0;
            this.Post = 1;
            this.DbCode = "";
            this.CrCode = "";
            this.AccName1 = "";
            this.AccName2 = "";
            this.FDate = "";
            this.Amount = 0;
            this.ChequeNo = "";
            this.ChequeDate = "";
            this.InvNo = "";
            this.Remark = "";
            this.Seller = 0;
            this.Project = "";
            this.ProjectName1 = "";
            this.ProjectName2 = "";
            this.CostName1 = "";
            this.CostName2 = "";
            this.BankName = "";
            this.CostCenter = "";
            this.UserName = "";
            this.UserDate = "";
            this.EmpCode = "";
            this.EmpName1 = "";
            this.EmpName2 = "";
            this.Area = "";
            this.AreaName1 = "";
            this.AreaName2 = "";
            this.CostAcc = "";
            this.CostAccName1 = "";
            this.CostAccName2 = "";
            this.BatchCode = "";
            this.Bal = 0;
            this.CarNo = "";
            this.CarType = "";
            this.PlateNo = "";
            this.DocType = 0;
            this.FNo2 = 0;
        }
    }

    [Serializable]
    public class vJv2
    {
        public short Branch { get; set; }
        public string AccName1 { get; set; }
        public string AccName2 { get; set; }
        public System.Nullable<double> DbAmount { get; set; }
        public System.Nullable<double> CrAmount { get; set; }
        public string Code { get; set; }
        public System.Nullable<double> DbAmount1 { get; set; }
        public System.Nullable<double> CrAmount1 { get; set; }
        public System.Nullable<double> DbAmount2 { get; set; }
        public System.Nullable<double> CrAmount2 { get; set; }
        public System.Nullable<double> DbAmount3 { get; set; }
        public System.Nullable<double> CrAmount3 { get; set; }
        public System.Nullable<double> DbAmount4 { get; set; }
        public System.Nullable<double> CrAmount4 { get; set; }
        public System.Nullable<double> DbAmount5 { get; set; }
        public System.Nullable<double> CrAmount5 { get; set; }
        public System.Nullable<double> DbAmount6 { get; set; }
        public System.Nullable<double> CrAmount6 { get; set; }
        public System.Nullable<double> DbAmount7 { get; set; }
        public System.Nullable<double> CrAmount7 { get; set; }
        public System.Nullable<double> DbAmount8 { get; set; }
        public System.Nullable<double> CrAmount8 { get; set; }
        public System.Nullable<double> DbAmount9 { get; set; }
        public System.Nullable<double> CrAmount9 { get; set; }
        public System.Nullable<double> DbAmount10 { get; set; }
        public System.Nullable<double> CrAmount10 { get; set; }
        public System.Nullable<double> DbAmount11 { get; set; }
        public System.Nullable<double> CrAmount11 { get; set; }
        public System.Nullable<double> DbAmount12 { get; set; }
        public System.Nullable<double> CrAmount12 { get; set; }
        public string Db1 { get; set; }
        public string Cr1 { get; set; }
        public string Db2 { get; set; }
        public string Cr2 { get; set; }
        public string Db3 { get; set; }
        public string Cr3 { get; set; }
        public string Db4 { get; set; }
        public string Cr4 { get; set; }
        public string Db5 { get; set; }
        public string Cr5 { get; set; }
        public string Db6 { get; set; }
        public string Cr6 { get; set; }
        public string Db7 { get; set; }
        public string Cr7 { get; set; }
        public string Db8 { get; set; }
        public string Cr8 { get; set; }
        public string Db9 { get; set; }
        public string Cr9 { get; set; }
        public string Db10 { get; set; }
        public string Cr10 { get; set; }
        public string Db11 { get; set; }
        public string Cr11 { get; set; }
        public string Db12 { get; set; }
        public string Cr12 { get; set; }
        public System.Nullable<double> OpenBal { get; set; }
        public double Bal
        {
            get
            {
                return (double)((this.OpenBal == null ? 0 : this.OpenBal) + (this.DbAmount == null ? 0 : this.DbAmount) - (this.CrAmount == null ? 0 : this.CrAmount));
            }
        }

        public vJv2()
        {
            this.Branch = 0;
            this.Code = "";
            this.AccName1 = "";
            this.AccName2 = "";
            this.DbAmount = 0;
            this.CrAmount = 0;
            this.DbAmount1 = 0;
            this.CrAmount1 = 0;
            this.DbAmount2 = 0;
            this.CrAmount2 = 0;
            this.DbAmount3 = 0;
            this.CrAmount3 = 0;
            this.DbAmount4 = 0;
            this.CrAmount4 = 0;
            this.DbAmount5 = 0;
            this.CrAmount5 = 0;
            this.DbAmount6 = 0;
            this.CrAmount6 = 0;
            this.DbAmount7 = 0;
            this.CrAmount7 = 0;
            this.DbAmount8 = 0;
            this.CrAmount8 = 0;
            this.DbAmount9 = 0;
            this.CrAmount9 = 0;
            this.DbAmount10 = 0;
            this.CrAmount10 = 0;
            this.DbAmount11 = 0;
            this.CrAmount11 = 0;
            this.DbAmount12 = 0;
            this.CrAmount12 = 0;
            this.OpenBal = 0;
            this.Db1 = "";
            this.Cr1 = "";
            this.Db2 = "";
            this.Cr2 = "";
            this.Db3 = "";
            this.Cr3 = "";
            this.Db4 = "";
            this.Cr4 = "";
            this.Db5 = "";
            this.Cr5 = "";
            this.Db6 = "";
            this.Cr6 = "";
            this.Db7 = "";
            this.Cr7 = "";
            this.Db8 = "";
            this.Cr8 = "";
            this.Db9 = "";
            this.Cr9 = "";
            this.Db10 = "";
            this.Cr10 = "";
            this.Db11 = "";
            this.Cr11 = "";
            this.Db12 = "";
            this.Cr12 = "";

        }

        /// <summary>
        /// Find Jv in Jv Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<vJv2> GetAll(string ConnectionStr, string FCode , string FYear)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vJvGetAll2(this.Branch,int.Parse(FYear));
                    return (from itm in result
                            where (FCode == "" ? true : string.IsNullOrEmpty(itm.Code) ? false : itm.Code.StartsWith(FCode))
                            select new vJv2
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                AccName1 = itm.AccName1,
                                AccName2 = itm.AccName2,
                                DbAmount = itm.DbAmount,
                                CrAmount = itm.CrAmount,
                                DbAmount1 = itm.DbAmount1,
                                CrAmount1 = itm.CrAmount1,
                                DbAmount2 = itm.DbAmount2,
                                CrAmount2 = itm.CrAmount2,
                                DbAmount3 = itm.DbAmount3,
                                CrAmount3 = itm.CrAmount3,
                                DbAmount4 = itm.DbAmount4,
                                CrAmount4 = itm.CrAmount4,
                                DbAmount5 = itm.DbAmount5,
                                CrAmount5 = itm.CrAmount5,
                                DbAmount6 = itm.DbAmount6,
                                CrAmount6 = itm.CrAmount6,
                                DbAmount7 = itm.DbAmount7,
                                CrAmount7 = itm.CrAmount7,
                                DbAmount8 = itm.DbAmount8,
                                CrAmount8 = itm.CrAmount8,
                                DbAmount9 = itm.DbAmount9,
                                CrAmount9 = itm.CrAmount9,
                                DbAmount10 = itm.DbAmount10,
                                CrAmount10 = itm.CrAmount10,
                                DbAmount11 = itm.DbAmount11,
                                CrAmount11 = itm.CrAmount11,
                                DbAmount12 = itm.DbAmount12,
                                CrAmount12 = itm.CrAmount12,
                                OpenBal = itm.OpenBal
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
