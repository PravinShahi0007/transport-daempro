using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class ICat
    {
        public short Branch { get; set; }
        public string Code { get; set; }
        public string FCode { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string CSal_Acc { get; set; }
        public string CrSal_Acc { get; set; }
        public string RCSal_Acc { get; set; }
        public string RCRSal_Acc { get; set; }
        public string CPur_Acc { get; set; }
        public string CrPur_Acc { get; set; }
        public string RCPur_Acc { get; set; }
        public string RCRPur_Acc { get; set; }
        public System.Nullable<bool> FUpdate { get; set; }
        public string FType2 { get; set; } // for test
        /// <summary>
        /// Add Cat in ICat Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ICatInsert(this.Branch, this.Code, this.FCode, this.Name1, this.Name2,this.CSal_Acc,this.CrSal_Acc,this.RCSal_Acc,this.RCRSal_Acc,this.CPur_Acc,this.CrPur_Acc,this.RCPur_Acc,this.RCRPur_Acc, this.FUpdate);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Cat from ICat Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ICatDelete(this.Branch, this.Code);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Cat in ICat Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ICatUpdate(this.Branch, this.Code, this.FCode, this.Name1, this.Name2,this.CSal_Acc,this.CrSal_Acc,this.RCSal_Acc,this.RCRSal_Acc,this.CPur_Acc,this.CrPur_Acc,this.RCPur_Acc,this.RCRPur_Acc, this.FUpdate);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// select all Cat from ICat Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<ICat> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ICatGetAll(this.Branch, this.FCode);
                    return (from itm in result
                            select new ICat
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                FCode = itm.FCode,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                CSal_Acc = itm.CSal_Acc,
                                CrSal_Acc = itm.CrSal_Acc,
                                RCSal_Acc = itm.RCSal_Acc,
                                RCRSal_Acc = itm.RCrSal_Acc,
                                CPur_Acc = itm.CPur_Acc,
                                CrPur_Acc = itm.CrPur_Acc,
                                RCPur_Acc = itm.RCPur_Acc,
                                RCRPur_Acc = itm.RCrPur_Acc,
                                FUpdate = itm.FUpdate
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cat from ICat Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<ICat> GetAll2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ICatGetAll2();
                    return (from itm in result
                            select new ICat
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                FCode = itm.FCode,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                CSal_Acc = itm.CSal_Acc,
                                CrSal_Acc = itm.CrSal_Acc,
                                RCSal_Acc = itm.RCSal_Acc,
                                RCRSal_Acc = itm.RCrSal_Acc,
                                CPur_Acc = itm.CPur_Acc,
                                CrPur_Acc = itm.CrPur_Acc,
                                RCPur_Acc = itm.RCPur_Acc,
                                RCRPur_Acc = itm.RCrPur_Acc,
                                FUpdate = itm.FUpdate
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// find all Cat from ICat Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<ICat> find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ICatFind(this.Branch, this.Name1);
                    return (from itm in result
                            select new ICat
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                FCode = itm.FCode,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                CSal_Acc = itm.CSal_Acc,
                                CrSal_Acc = itm.CrSal_Acc,
                                RCSal_Acc = itm.RCSal_Acc,
                                RCRSal_Acc = itm.RCrSal_Acc,
                                CPur_Acc = itm.CPur_Acc,
                                CrPur_Acc = itm.CrPur_Acc,
                                RCPur_Acc = itm.RCPur_Acc,
                                RCRPur_Acc = itm.RCrPur_Acc,
                                FUpdate = itm.FUpdate
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// find all Cat from ICat Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public ICat find2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ICatFind2(this.Branch, this.Code);
                    return (from itm in result
                            select new ICat
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                FCode = itm.FCode,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                CSal_Acc = itm.CSal_Acc,
                                CrSal_Acc = itm.CrSal_Acc,
                                RCSal_Acc = itm.RCSal_Acc,
                                RCRSal_Acc = itm.RCrSal_Acc,
                                CPur_Acc = itm.CPur_Acc,
                                CrPur_Acc = itm.CrPur_Acc,
                                RCPur_Acc = itm.RCPur_Acc,
                                RCRPur_Acc = itm.RCrPur_Acc,
                                FUpdate = itm.FUpdate
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



        /// <summary>
        /// Check if Cat is Father Cat
        /// </summary>
        /// <returns>True if father or False if not</returns>
        public Boolean IsFather(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    // Pending work check if there any item have same Cat. 
                    return (myContext.ICatGetParents(this.Branch, this.Code).Count() > 0);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Get New Code for Cat Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public string GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    // Pending work check if there any item have same Cat. 
                    var result = myContext.ICatMaxCode(this.Branch, this.FCode);
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
