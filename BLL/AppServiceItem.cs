using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class AppServiceItem
    {
        public string ServiceCode { get; set; }
        public string ItemCode { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Unit { get; set; }
        public string Unit2 { get; set; }
        public double? Price { get; set; }
        public double? SPrice { get; set; }
        public double? SPRate { get; set; }
        public double? ServicePrice { 
            get {
                    return this.SPrice * this.SPRate;
                } 
        }
        public string Remark { get; set; }
        public string Remark2 { get; set; }
        public bool? Online { get; set; }
        public string PickLat { get; set; }
        public string PickLong { get; set; }

        public AppServiceItem()
        {
            this.ServiceCode = "";
            this.ItemCode = "";
            this.Name1 = "";
            this.Name2 = "";
            this.Unit = "";
            this.Unit2 = "";
            this.Price = 0;
            this.SPrice = 0;
            this.SPRate = 1;
            this.Remark = "";
            this.Remark2 = "";
            this.Online = true;
            this.PickLat = "24.6894855";
            this.PickLong = "46.6722939";
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
                    myContext.AppServiceItemAdd(this.ServiceCode,this.ItemCode,this.Name1,this.Name2,this.Unit,this.Unit2,this.Price,this.SPrice,this.SPRate,this.Remark,this.Remark2,this.Online,this.PickLat,this.PickLong);
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
                    myContext.AppServiceItemDelete(this.ServiceCode, this.ItemCode);
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
                    myContext.AppServiceItemUpdate(this.ServiceCode, this.ItemCode, this.Name1, this.Name2, this.Unit,this.Unit2, this.Price, this.SPrice, this.SPRate, this.Remark, this.Remark2, this.Online, this.PickLat, this.PickLong);
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
        public List<AppServiceItem> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.AppServiceItemGetAll(this.ServiceCode);
                    return (from itm in result
                            select new AppServiceItem
                            {
                                 ServiceCode = itm.ServiceCode,
                                 ItemCode = itm.ItemCode,
                                 Name1 = itm.Name1,
                                 Name2 = itm.Name2,
                                 Online = itm.Online,
                                 Price = itm.Price,
                                 Remark = itm.Remark,
                                 SPRate = itm.SPRate,
                                 SPrice = itm.SPrice,
                                 Remark2 = itm.Remark2,
                                 Unit = itm.Unit,
                                 PickLat = itm.PickLat,
                                 PickLong = itm.PickLong
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
        public AppServiceItem Find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.AppServiceItemGet(this.ServiceCode, this.ItemCode);
                    return (from itm in result
                            select new AppServiceItem
                            {
                                ServiceCode = itm.ServiceCode,
                                ItemCode = itm.ItemCode,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                Online = itm.Online,
                                Price = itm.Price,
                                Remark = itm.Remark,
                                SPRate = itm.SPRate,
                                SPrice = itm.SPrice,
                                Remark2 = itm.Remark2,
                                Unit = itm.Unit,
                                PickLat = itm.PickLat,
                                PickLong = itm.PickLong
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
                    var result = myContext.AppServiceItemMaxCode(this.ServiceCode);
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


    [Serializable]
    public class AppServiceItem02
    {
        public string ServiceCode { get; set; }
        public string ItemCode { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public double? Price { get; set; }
        public double? SPrice { get; set; }
        public double? SPRate { get; set; }
        public double? ServicePrice
        {
            get
            {
                return this.SPrice * this.SPRate;
            }
        }
        public string Remark { get; set; }
        public bool? Online { get; set; }
        public string PickLat { get; set; }
        public string PickLong { get; set; }
    }

}
