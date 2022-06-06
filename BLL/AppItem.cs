using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class AppItem
    {

        public short Branch { get; set; }
        public string ITCode { get; set; }
        public System.Nullable<short> FType { get; set; }
        public string ITNo { get; set; }
        public string ITName1 { get; set; }
        public string ITName2 { get; set; }
        public string ITStyle { get; set; }
        public System.Nullable<double> ITprice { get; set; }
        public System.Nullable<double> Cost { get; set; }
        public string CompName { get; set; }
        public System.Nullable<short> CompCode { get; set; }
        public string Remark { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }



        public AppItem()
        {
            this.Branch=0;
            this.ITCode = "";
            this.FType = 1;
            this.ITNo = "";
            this.ITName1 = "";
            this.ITName2 = "";
            this.CompName = "";
            this.ITprice = 0;
            this.Cost = 0;
            this.CompCode = 0;
            this.ITStyle = "";
            this.Remark = "";
            this.UserName = "";
            this.UserDate = "";           
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
                    myContext.AppItemInsert(this.Branch, this.ITCode, this.FType, this.ITNo, this.ITName1, this.ITName2, this.ITprice,this.Cost, this.ITStyle, this.CompName, this.CompCode,this.Remark, this.UserName, this.UserDate);
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
                    myContext.AppItemDelete(this.Branch, this.ITCode);
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
                    myContext.AppItemUpdate(this.Branch, this.ITCode, this.FType, this.ITNo, this.ITName1, this.ITName2, this.ITprice, this.Cost, this.ITStyle, this.CompName, this.CompCode, this.Remark, this.UserName, this.UserDate);
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
        public List<AppItem> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.AppItemGetAll(this.Branch, this.FType);
                    return (from itm in result
                            select new AppItem
                            {
                                Branch = itm.Branch,
                                ITCode = itm.ITCode,
                                FType = itm.FType,
                                ITNo = itm.ITNo,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2,
                                ITprice = itm.ITprice,
                                Cost = itm.Cost,
                                ITStyle = itm.ITstyle,
                                CompName = itm.CompName,
                                CompCode = itm.CompCode,
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
        public AppItem Find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.AppItemFind(this.Branch, this.ITCode, this.FType);
                    return (from itm in result
                            select new AppItem
                            {
                                Branch = itm.Branch,
                                ITCode = itm.ITCode,
                                FType = itm.FType,
                                ITNo = itm.ITNo,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2,
                                ITprice = itm.ITprice,
                                Cost = itm.Cost,
                                ITStyle = itm.ITstyle,
                                CompName = itm.CompName,
                                CompCode = itm.CompCode,
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



    }
}
