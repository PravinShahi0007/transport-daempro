using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class AppPrice
    {
        public short Branch { get; set; }
        public short FType { get; set; }
        public short FType2 { get; set; }
        public short FType3 { get; set; }
        public string Code { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public System.Nullable<double> Price { get; set; }
        public System.Nullable<double> SerPrice { get; set; }
        public System.Nullable<double> Cost { get; set; }
       



        public AppPrice()
        {
            Branch=0;
            FType = 0;
            FType2 = 0;
            FType3 = 0;
            Code = "";
            Name1 = "";
            Name2 = "";
            Price = 0;
            SerPrice = 0;
            Cost = 0;
  
           
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
                    myContext.AppPriceInsert(this.Branch, this.FType, this.FType2, this.Code, this.FType3, this.Name1, this.Name2, this.Price,this.SerPrice, this.Cost);
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
                    myContext.AppPriceDelete(this.Branch, this.FType, this.FType2, this.Code, this.FType3);
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
                    myContext.AppPriceUpdate(this.Branch, this.FType, this.FType2, this.Code, this.FType3, this.Name1, this.Name2, this.Price, this.SerPrice, this.Cost);
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
        public List<AppPrice> GetAll0(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.AppPriceGetAll0(this.Branch, this.FType);
                    return (from itm in result
                            select new AppPrice
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                FType2 = itm.FType2,
                                Code = itm.Code,
                                FType3 = itm.FType3,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                Price = itm.Price,
                                SerPrice = itm.SerPrice,
                                Cost = itm.Cost
                              
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Branch or Stores from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public List<AppPrice> GetAll1(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.AppPriceGetAll1(this.Branch, this.FType, this.FType2);
                    return (from itm in result
                            select new AppPrice
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                FType2 = itm.FType2,
                                Code = itm.Code,
                                FType3 = itm.FType3,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                Price = itm.Price,
                                SerPrice = itm.SerPrice,
                                Cost = itm.Cost

                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Branch or Stores from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public List<AppPrice> GetAll2(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.AppPriceGetAll2(this.Branch, this.FType, this.FType2, this.Code);
                    return (from itm in result
                            select new AppPrice
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                FType2 = itm.FType2,
                                Code = itm.Code,
                                FType3 = itm.FType3,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                Price = itm.Price,
                                SerPrice = itm.SerPrice,
                                Cost = itm.Cost

                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Branch or Stores from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public List<AppPrice> GetAll3(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.AppPriceGetAll3(this.Branch, this.FType, this.Code);
                    return (from Sitm in result
                            select new AppPrice
                            {
                                Branch = Sitm.Branch,
                                FType = Sitm.FType,
                                FType2 = Sitm.FType2,
                                Code = Sitm.Code,
                                FType3 = Sitm.FType3,
                                Name1 = Sitm.Name1,
                                Name2 = Sitm.Name2,
                                Price = Sitm.Price,
                                SerPrice = Sitm.SerPrice,
                                Cost = Sitm.Cost
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
        public AppPrice Find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.AppPriceFind(this.Branch, this.FType, this.FType2, this.Code, this.FType3);
                    return (from itm in result
                            select new AppPrice
                            {
                                Branch = itm.Branch,
                                FType = itm.FType,
                                FType2 = itm.FType2,
                                Code = itm.Code,
                                FType3 = itm.FType3,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                Price = itm.Price,
                                SerPrice = itm.SerPrice,
                                Cost = itm.Cost

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
                    var result = myContext.AppPriceMaxCode(this.Branch, this.FType, this.FType2, this.Code);
                    return (from Cat in result
                            select Cat.myType3).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



    }
}
