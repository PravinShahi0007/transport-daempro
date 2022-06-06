using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Pay
    {
        public short Year1 { get; set; }
        public short Month1 { get; set; }
        public int EmpCode { get; set; }


        public Pay()
        {
            this.Year1 = 0;
            this.Month1 = 0;
            this.EmpCode = 0;
        }


        /// <summary>
        /// Add Account in Acc Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.PayAdd(this.Year1, this.Month1, this.EmpCode);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Account from Acc Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.PayDelete(this.Year1, this.Month1, this.EmpCode);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select all Account from Acc Table
        /// </summary>
        /// <returns>List of Account or null if Fail</returns>
        public List<Pay> GetMonth(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.PayGetMonth(this.Year1, this.Month1);
                    return (from itm in result
                            select new Pay
                            {
                                Year1 = itm.Year1,
                                Month1 = itm.Month1,
                                EmpCode = itm.EmpCode
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Account from Acc Table
        /// </summary>
        /// <returns>List of Account or null if Fail</returns>
        public List<vPay> GetMonth2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vPayGetMonth(this.Year1, this.Month1);
                    return (from itm in result
                            select new vPay
                            {
                                Year1 = itm.Year1,
                                Month1 = itm.Month1,
                                EmpCode = itm.EmpCode,
                                Name = itm.Name,
                                Name2 = itm.Name2,
                                ATM = itm.ATM,
                                PaperNo1 = itm.PaperNo1  
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Account from Acc Table
        /// </summary>
        /// <returns>List of Account or null if Fail</returns>
        public Pay Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.PayFind(this.Year1, this.Month1, this.EmpCode);
                    return (from itm in result
                            select new Pay
                            {
                                Year1 = itm.Year1,
                                Month1 = itm.Month1,
                                EmpCode = itm.EmpCode
                            }).FirstOrDefault();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    [Serializable]
    public class vPay : Pay
    {
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string ATM { get; set; }
        public string PaperNo1 { get; set; }
    }
}
