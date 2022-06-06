using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class CustDetails
    {
        public short Branch { get; set; }
        public string Code { get; set; }
        public short FNo { get; set; }
        public string City { get; set; }
        public string City2 { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string RecName { get; set; }
        public string RecMobileNo { get; set; }


        public CustDetails()
        {
            this.Branch = 1;
            this.Code = "";
            this.FNo = 0;
            this.City = "-1";
            this.City2 = "";
            this.Name = "";
            this.MobileNo = "";
            this.RecName = "";
            this.RecMobileNo = "";
        }


        /// <summary>
        /// Add Client in Clients Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CustDetailsAdd(this.Branch, this.Code, this.FNo, this.City, this.Name, this.MobileNo, this.RecName, this.RecMobileNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


         /// <summary>
        /// Delete Client from Clients Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CustDetailsDelete(this.Branch, this.Code);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Client from Clients Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool DeleteFNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CustDetailsDeleteFNo(this.Branch, this.Code,this.FNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// select all Clients from Clients Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<CustDetails> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CustDetailsGet(this.Branch,this.Code);
                    return (from itm in result
                            select new CustDetails
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                City = itm.City,
                                FNo = itm.FNo,
                                MobileNo = itm.MobileNo,
                                Name = itm.Name,
                                RecMobileNo = itm.RecMobileNo,
                                RecName = itm.RecName
                           }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Clients from Clients Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<CustDetails> GetAll2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vCustDetailsGet(this.Branch, this.Code);
                    return (from itm in result
                            select new CustDetails
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                City = itm.City,
                                FNo = itm.FNo,
                                MobileNo = itm.MobileNo,
                                Name = itm.Name,
                                RecMobileNo = itm.RecMobileNo,
                                RecName = itm.RecName,
                                City2 = itm.City2
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Clients from Clients Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public CustDetails Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CustDetailsGet2(this.Branch, this.Code,this.City);
                    return (from itm in result
                            select new CustDetails
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                City = itm.City,
                                FNo = itm.FNo,
                                MobileNo = itm.MobileNo,
                                Name = itm.Name,
                                RecMobileNo = itm.RecMobileNo,
                                RecName = itm.RecName
                            }).FirstOrDefault();
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
        public short? GetNewFNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CustDetailsMaxCode(this.Branch,this.Code);
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