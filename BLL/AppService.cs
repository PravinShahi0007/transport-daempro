using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class AppService
    {

        public short Branch { get; set; }
        public int SCode { get; set; }
        public string SName1 { get; set; }
        public string SName2 { get; set; }
        public System.Nullable<double> Sprice { get; set; }
        public string Remark { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }



        public AppService()
        {
            Branch=0;
            SCode = 0;
            SName1 = "";
            SName2 = "";
            Sprice = 0;
            Remark="";
            UserName = "";
            UserDate = "";
           
        }



        /// <summary>
        /// Add Stock Item in Item Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.AppServiceInsert(this.Branch, this.SCode, this.SName1, this.SName2, this.Sprice, this.Remark, this.UserName, this.UserDate);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Stock Iten from Item Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    //myContext.AppServiceDelete(this.Branch, this.SCode);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Item Stock in Item Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.AppServiceUpdate(this.Branch, this.SCode, this.SName1, this.SName2, this.Sprice, this.Remark, this.UserName, this.UserDate);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// select all Branch or Stores from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public List<AppService> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.AppServiceGetAll(this.Branch);
                    return (from itm in result
                            select new AppService
                            {
                                Branch = itm.Branch,
                                SCode = itm.SCode,
                                SName1 = itm.SName1,
                                SName2 = itm.SName2,
                                Sprice = itm.Sprice,
                                Remark = itm.Remark,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public AppService Find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.AppServiceFind(this.Branch, this.SCode);
                    return (from itm in result
                            select new AppService
                            {
                                Branch = itm.Branch,
                                SCode = itm.SCode,
                                SName1 = itm.SName1,
                                SName2 = itm.SName2,
                                Sprice = itm.Sprice,
                                Remark = itm.Remark,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate
                            }).FirstOrDefault();
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
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.AppServiceMaxCode(this.Branch);
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
