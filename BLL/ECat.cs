using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class ECat
    {
        public short Branch { get; set; }
        public string Code { get; set; }
        public string FCode { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public System.Nullable<bool> FUpdate { get; set; }
        public string FType2 { get; set; } // for test

        /// <summary>
        /// Add Cat in ECat Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ECatInsert(this.Branch, this.Code, this.FCode, this.Name1, this.Name2, this.FUpdate);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Cat from ECat Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ECatDelete(this.Branch, this.Code);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Cat in ECat Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ECatUpdate(this.Branch, this.Code, this.FCode, this.Name1, this.Name2, this.FUpdate);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// select all Cat from ECat Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public List<ECat> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ECatGetAll(this.Branch, this.FCode);
                    return (from itm in result
                            select new ECat
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                FCode = itm.FCode,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
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
        /// select all Cat from ECat Table
        /// </summary>
        /// <returns>List of Cat or null if Fail</returns>
        public ECat find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ECatFind(this.Branch, this.Code);
                    return (from itm in result
                            select new ECat
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                FCode = itm.FCode,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
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
                    return (myContext.ECatGetParents(this.Branch, this.Code).Count() > 0);
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
                    var result = myContext.ECatMaxCode(this.Branch, this.FCode);
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
