using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Claim
    {
        public int DocNo { get; set; }
        public short FNo { get; set; }
        public short? DocLoc { get; set; }
        public string DocDate { get; set; }
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int? InvNo { get; set; }
        public int? Qty { get; set; }
        public short? InvLoc { get; set; }
        public string Ref { get; set; }
        public bool? State { get; set; }
        public double? amount { get; set; }
        public double? tax { get; set; }
        public double? amount0
        {
            get
            {
                return (this.amount - this.tax);
            }
        }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public string FDate { get; set; }
        public string EDate { get; set; }
        public string InvNo2 { get; set; }
        public string Flag { get; set; }
        public string Customer { get; set; }
        //{
        //    get
        //    {
        //        return InvLoc.ToString() + "/" + InvNo.ToString();
        //    }
        //}


        public Claim()
        {
            this.DocNo = 1;
            this.FNo = 1;
            this.DocLoc = 1;
            this.CustCode = "";
            this.InvNo = 0;
            this.InvLoc = 1;
            this.Ref = "";
            this.State = false;
            this.amount = 0;
            this.tax = 0;
            this.Qty = 0;
            this.Source = "";
            this.Destination = "";
            this.UserName = "";
            this.UserDate = "";
            this.CustName = "";
            this.InvNo2 = "";
            this.Flag = "";
            this.Customer = "";
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
                    myContext.ClaimInsert(this.DocNo, this.FNo,this.DocLoc, this.DocDate, this.CustCode, this.InvNo, this.InvLoc, this.Ref, this.State , this.UserName , this.UserDate,this.FDate,this.EDate,this.Flag,this.Customer);
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
                    myContext.ClaimDelete(this.DocNo);
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
                    myContext.ClaimUpdate(this.DocNo, this.FNo, this.DocLoc, this.DocDate, this.CustCode, this.InvNo, this.InvLoc, this.Ref, this.State, this.UserName, this.UserDate, this.FDate, this.EDate, this.Flag, this.Customer);
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
        public bool UpdateState(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ClaimUpdateState(this.DocNo, this.FNo, this.State);
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
        public List<Claim> Get(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ClaimGet(this.DocNo);
                    return (from itm in result
                            select new Claim
                            {
                                 DocNo = itm.DocNo,
                                 FNo = itm.FNo,
                                 DocDate = itm.DocDate,
                                 CustCode = itm.CustCode,
                                 InvNo = itm.InvNo,
                                 InvLoc = itm.InvLoc,
                                 Ref = itm.Ref,
                                 State = itm.State,
                                 UserDate = itm.UserDate,
                                 UserName = itm.UserName,
                                 FDate = itm.FDate,
                                 EDate = itm.EDate,
                                 DocLoc = itm.DocLoc,
                                 Flag = itm.Flag,
                                 Customer = itm.Customer
                            }).ToList();
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
        public List<Claim> GetForCustCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ClaimGetForCust(this.CustCode);
                    return (from itm in result
                            select new Claim
                            {
                                DocNo = itm.DocNo,
                                DocDate = itm.DocDate,
                                CustCode = itm.CustCode,
                                FDate = itm.FDate,
                                EDate = itm.EDate,
                                Customer = itm.Customer
                            }).ToList();
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
        public List<Claim> GetAll(string FDate, string EDate , bool CheckState , string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ClaimGetAll(FDate, EDate, this.CustCode, CheckState, this.State);
                    return (from itm in result
                            select new Claim
                            {
                                DocNo = itm.DocNo,
                                FNo = itm.FNo,
                                DocDate = itm.DocDate,
                                CustCode = itm.CustCode,
                                InvNo = itm.InvNo,
                                InvLoc = itm.InvLoc,
                                Ref = itm.Ref,
                                State = itm.State,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                FDate = itm.FDate,
                                EDate = itm.EDate,
                                DocLoc = itm.DocLoc,
                                Flag = itm.Flag,
                                Customer = itm.Customer
                            }).ToList();
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
        public Claim GetByFNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ClaimGetFNo(this.DocNo, this.FNo);
                    return (from itm in result
                            select new Claim
                            {
                                DocNo = itm.DocNo,
                                FNo = itm.FNo,
                                DocDate = itm.DocDate,
                                CustCode = itm.CustCode,
                                InvNo = itm.InvNo,
                                InvLoc = itm.InvLoc,
                                Ref = itm.Ref,
                                State = itm.State,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                FDate = itm.FDate,
                                EDate = itm.EDate,
                                DocLoc = itm.DocLoc,
                                Flag = itm.Flag,
                                Customer = itm.Customer
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
        public Claim GetByInvNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ClaimGetInvNo(this.InvNo,this.InvLoc,this.Flag);
                    return (from itm in result
                            select new Claim
                            {
                                DocNo = itm.DocNo,
                                FNo = itm.FNo,
                                DocDate = itm.DocDate,
                                CustCode = itm.CustCode,
                                InvNo = itm.InvNo,
                                InvLoc = itm.InvLoc,
                                Ref = itm.Ref,
                                State = itm.State,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                FDate = itm.FDate,
                                EDate = itm.EDate,
                                DocLoc = itm.DocLoc,
                                Flag = itm.Flag,
                                Customer = itm.Customer
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
        public Claim GetByCustCode2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ClaimGetCustCode(this.CustCode);
                    return (from itm in result
                            where itm.Customer!=""
                            select new Claim
                            {
                                DocNo = itm.DocNo,
                                FNo = itm.FNo,
                                DocDate = itm.DocDate,
                                CustCode = itm.CustCode,
                                InvNo = itm.InvNo,
                                InvLoc = itm.InvLoc,
                                Ref = itm.Ref,
                                State = itm.State,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                FDate = itm.FDate,
                                EDate = itm.EDate,
                                DocLoc = itm.DocLoc,
                                Flag = itm.Flag,
                                Customer = itm.Customer
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
        public List<Claim> GetPending(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vClaimGetPending(this.DocLoc);
                    return (from itm in result                            
                            select new Claim
                            {
                                DocNo = itm.DocNo,
                                CustName = itm.Name1,
                                amount = itm.amount,
                                DocLoc = itm.DocLoc,
                                DocDate = itm.DocDate
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
                    var result = myContext.ClaimMaxNo();
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
