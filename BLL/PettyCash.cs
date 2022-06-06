using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class PettyCash
    {
        public short Branch { get; set; }
        public short LocType { get; set; }
        public int VouNo { get; set; }
        public System.Nullable<short> VouLoc { get; set; }
        public short FNo { get; set; }
        public string VouDate { get; set; }
        public string FTime { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public System.Nullable<double> Amount { get; set; }
        public string InvNo { get; set; }
        public string FDate { get; set; }
        public string Remark { get; set; }
        public string Remark2 { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public System.Nullable<double> Tax { get; set; }
        public string Emp { get; set; }

        public PettyCash()
        {
            this.Branch = 1;
            this.LocType = 2;
            this.VouNo = 0;
            this.VouLoc = 0;
            this.FNo = 1;
            this.VouDate = "";
            this.FTime = "";
            this.Code = "";
            this.Amount = 0;
            this.InvNo = "";
            this.FDate = "";
            this.Remark = "";
            this.Remark2 = "";
            this.UserName = "";
            this.UserDate = "";
            this.Tax = 0;
            this.Emp = "";
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
                    myContext.PettyCashAdd(this.Branch, this.LocType, this.VouLoc, this.VouNo, this.FNo, this.VouDate, this.FTime, this.Code, this.Amount, this.InvNo, this.FDate, this.Remark, this.UserName, this.UserDate, this.Tax, this.Emp,this.Remark2);
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
                    myContext.PettyCashDelete(this.Branch, this.LocType, this.VouLoc, this.VouNo);
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
        public List<PettyCash> find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.PettyCashGet(this.Branch, this.LocType, this.VouLoc, this.VouNo);
                    return (from itm in result
                            select new PettyCash
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                Code = itm.Code,
                                InvNo = itm.InvNo,
                                Amount = itm.Amount,
                                Remark = itm.Remark,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                FDate = itm.FDate,
                                FNo = itm.FNo,
                                Tax = itm.Tax,
                                Emp = itm.Emp,
                                Remark2 = itm.Remark2
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
        public List<PettyCash> find2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vPettyCashGet(this.Branch, this.LocType, this.VouLoc, this.VouNo);
                    return (from itm in result
                            select new PettyCash
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                Code = itm.Code + (itm.Emp != "" ? ";"+itm.Emp : ""),
                                InvNo = itm.InvNo,
                                Amount = itm.Amount,
                                Remark = itm.Remark,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                FDate = itm.FDate,
                                FNo = itm.FNo,
                                Tax = itm.Tax,
                                Name = itm.Name1 + (itm.Emp != "" ? " " + GetEmpName(itm.Emp, ConnectionStr) : ""),
                                Emp = itm.Emp,
                                Remark2 = itm.Remark2
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
        public List<PettyCash> find3(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vPettyCashGet(this.Branch, this.LocType, this.VouLoc, this.VouNo);
                    return (from itm in result
                            select new PettyCash
                            {
                                Branch = itm.Branch,
                                LocType = itm.LocType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouDate = itm.VouDate,
                                FTime = itm.FTime,
                                Code = itm.Code,
                                InvNo = itm.InvNo,
                                Amount = itm.Amount,
                                Remark = itm.Remark,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                FDate = itm.FDate,
                                FNo = itm.FNo,
                                Tax = itm.Tax,
                                Name = itm.Name1 + (itm.Emp != "" ? " " + GetEmpName(itm.Emp, ConnectionStr) : ""),
                                Emp = itm.Emp,
                                Remark2 = itm.Remark2
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetEmpName(string EmpCode , string ConnectionStr)
        {
            SEmp myemp = new SEmp();
            myemp.EmpCode = int.Parse(EmpCode);
            myemp = myemp.find(ConnectionStr);
            if (myemp != null)
            {
                return myemp.Name;
            }
            else return "";
        }
        public List<PettyCash> GetNotAgree(short myFNo, string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.PettyCashAgree(myFNo);
                    return (from itm in result
                            select new PettyCash
                            {
                                VouLoc = itm.VouLoc,
                                LocType = itm.LocType,
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
        /// Get New Code for Area Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public int? GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.PettyCashMaxCode(this.Branch, this.LocType, this.VouLoc);
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
