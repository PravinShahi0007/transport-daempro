using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class yStock
    {
        public short Branch { get; set; }
        public string FYear { get; set; }
        public string Code { get; set; }
        public short Number { get; set; }
        public System.Nullable<double> Price { get; set; }
        public System.Nullable<double> FBal { get; set; }
        public System.Nullable<double> Bal { get; set; }
        public System.Nullable<double> Price2 { get; set; }
        public string FStatus { get; set; }
        public System.Nullable<int> SNote { get; set; }

        public System.Nullable<double> Amount {
            get
            {
                return Bal * Price;
            }
        }

        public System.Nullable<double> FAmount
        {
            get
            {
                return FBal * Price;
            }
        }

        public yStock()
        {
            this.Branch = 1;
            this.Code = "";
            this.Number = 1;
            this.Price = 0;
            this.Bal = 0;
            this.FStatus = "-1";
            this.SNote = 0;
            this.Price2 = 0;
        }

        /// <summary>
        /// Add Stock Item in Stock Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.yStockInsert(this.Branch, this.FYear, this.Code, this.Number, this.FBal, this.Price, this.Bal, this.FStatus, this.SNote,this.Price2);

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Stock Iten from Stock Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool DeleteYear(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.yStockDeleteYear(this.Branch, this.FYear, this.Number);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Stock Iten from Stock Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.yStockDeleteItem(this.Branch, this.FYear,this.Code,this.Number);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Branch or Store in Shop Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.yStockUpdate(this.Branch, this.FYear, this.Code, this.Number, this.FBal, this.Price, this.Bal, this.FStatus, this.SNote,this.Price2);
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
        public yStock Get(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.yStockGetItem(this.Branch,this.FYear,this.Number,this.Code);
                    return (from itm in result
                            select new yStock
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Number = itm.Number,
                                Bal = itm.Bal,
                                FBal = itm.FBal,
                                FStatus = itm.FStatus,
                                FYear = itm.FYear,
                                Price = itm.Price,
                                SNote = itm.SNote,
                                Price2 = itm.Price2
                            }).FirstOrDefault();
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
        public List<vyStock> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vyStockGetNumber(this.Branch,this.FYear,this.Number);
                    return (from itm in result
                            select new vyStock
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Number = itm.Number,
                                Bal = itm.Bal,
                                FBal = itm.FBal,
                                FStatus = itm.FStatus,
                                FYear = itm.FYear,
                                Price = itm.Price,
                                SNote = itm.SNote,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2,
                                Price2 = itm.Price2
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    [Serializable]
    public class vyStock:yStock
    {
        public string ITName1 { get; set; }
        public string ITName2 { get; set; }
        public System.Nullable<double> FAdd
        {
            get
            {
                if (this.FBal > this.Bal) return (this.FBal - this.Bal);
                else return 0;
            }
        }

        public System.Nullable<double> FDed
        {
            get
            {
                if (this.FBal < this.Bal) return (this.Bal - this.FBal);
                else return 0;
            }
        }

        public System.Nullable<double> FAddam
        {
            get
            {
                return FAdd * Price;
            }
        }

        public System.Nullable<double> FDedam
        {
            get
            {
                return FDed * Price;
            }
        }

        public vyStock()
        {
            this.ITName1 = "";
            this.ITName2 = "";
        }
    }
}
