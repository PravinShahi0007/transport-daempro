using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class RJv
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
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int? Period { get; set; }
        public string CDate { get; set; }
        public String VouNo2
        {
            get
            {
                return this.LocNumber.ToString() + "/" + this.Number.ToString();
            }
        }

        public RJv()
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
            this.StartDate = "";
            this.EndDate = "";
            this.Period = 0;
            this.CDate = "";
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
                    myContext.RJvInsert(this.Branch,
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
                                        this.StartDate,
                                        this.EndDate,
                                        this.Period,
                                        this.CDate
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
        /// Jv Transaction from Jv Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool SetCDate(string CDate,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.RJvSetCDate(this.Branch, this.FType, this.LocType, this.LocNumber, this.Number, CDate);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
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
                    myContext.RJvDelete(this.Branch,this.FType,this.LocType,this.LocNumber,this.Number);
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
        public RJv findUserName(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.RJvGetUserName(this.Branch, this.FType, this.LocType, this.LocNumber, this.UserName);
                    return (from itm in result
                            select new RJv
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
                                CDate = itm.CDate,
                                EndDate = itm.EndDate,
                                Period = itm.Period,
                                StartDate = itm.StartDate                                 
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
        public List<RJv> find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.RJvGet(this.Branch, this.FType, this.LocType, this.LocNumber, this.Number);
                    return (from itm in result
                            select new RJv
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
                                CDate = itm.CDate,
                                EndDate = itm.EndDate,
                                Period = itm.Period,
                                StartDate = itm.StartDate
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
        public List<string> GetActive(string today,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.RJVActive(today);
                    return (from itm in result
                            select itm.Number.ToString()).ToList();
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
        public int SetActive(string today,string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.RJVExecActive(today);
                    return (int)result;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Find Jv in Jv Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<vRJv> find2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vRJvGet(this.Branch, this.FType, this.LocType, this.LocNumber, this.Number);
                    return (from itm in result
                            select new vRJv
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
                                StartDate = itm.StartDate,
                                EndDate = itm.EndDate,
                                Period = itm.Period                                                                                                    
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
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
                    var result = myContext.RJvMaxNumber(this.Branch, this.FType, this.LocType, this.LocNumber);
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
    public class vRJv:RJv
    {
        public string AccName1 { get; set; }
        public string AccName2 { get; set; }
        public string ProjectName1 { get; set; }
        public string ProjectName2 { get; set; }
        public string CostName1 { get; set; }
        public string CostName2 { get; set; }
        public string EmpName1 { get; set; }
        public string EmpName2 { get; set; }
        public string PlateNo { get; set; }
        public string CarType { get; set; }
        public string AreaName1 { get; set; }
        public string AreaName2 { get; set; }
        public string CostAccName1 { get; set; }
        public string CostAccName2 { get; set; }
        public string BatchCode { get; set; }
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
                    case 501: return "فاتورة مشتريات";
                    case 502: return "فاتورة ترجيع مشتريات";
                    case 701: return "سند صرف بضاعة";
                    case 999: return "رصيد أخر الفترة";
                    default: return "أخرى";
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
                    case 501: return "مشتريات";
                    case 502: return "ت مشتريات";
                    case 701: return "سند صرف بضاعة";
                    case 999: return "رصيد أخر الفترة";
                    default: return "أخرى";
                }
            }
        }

        public vRJv()
        {
            this.ProjectName1 = "";
            this.ProjectName2 = "";
            this.CostName1 = "";
            this.CostName2 = "";
            this.EmpName1 = "";
            this.EmpName2 = "";
            this.AreaName1 = "";
            this.AreaName2 = "";
            this.CostAccName1 = "";
            this.CostAccName2 = "";
            this.Bal = 0;
            this.CarType = "";
            this.PlateNo = "";
            this.DocType = 0;
            this.BatchCode = "";
        }
    }

}
