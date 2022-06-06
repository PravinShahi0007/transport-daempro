using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Codes
    {
        public short Branch { get; set; }
        public short Ftype { get; set; }
        public int Code { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string FType2 { get; set; }

        /// <summary>
        /// Add Code in Codes Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CodesInsert(this.Branch, this.Ftype, this.Name1, this.Name2,this.FType2);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Code from Codes Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CodesDelete(this.Branch,this.Code);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Code in Codes Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CodesUpdate(this.Branch,this.Code, this.Name1, this.Name2 , this.FType2);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// select all Codes for Spec. FType from Codes Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public List<Codes> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CodesGetAll(this.Branch, this.Ftype);
                    return (from itm in result
                            select new Codes
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Ftype = itm.Ftype,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                FType2 = itm.FType2
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Codes for Spec. FType from Codes Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public List<Codes> GetAll2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CodesGetAll2(this.Branch);
                    return (from itm in result
                            select new Codes
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Ftype = itm.Ftype,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                FType2 = itm.FType2
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Codes for Spec. FType from Codes Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public Codes Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CodesGet(this.Branch, this.Ftype , this.Code);
                    return (from itm in result
                            select new Codes
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Ftype = itm.Ftype,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                FType2 = itm.FType2
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



    }

}
