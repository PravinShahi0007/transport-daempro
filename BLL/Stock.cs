using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Stock
    {
        public short Branch { get; set; }
        public string Code { get; set; }
        public short Number { get; set; }
        public string Loc { get; set; }
        public System.Nullable<double> IOpen { get; set; }
        public System.Nullable<double> ISale { get; set; }
        public System.Nullable<double> IPurch { get; set; }
        public System.Nullable<double> AOpen { get; set; }
        public System.Nullable<double> ASale { get; set; }
        public System.Nullable<double> CSale { get; set; }
        public System.Nullable<double> ITemp { get; set; }
        public System.Nullable<double> ATemp { get; set; }
        public System.Nullable<double> APurch { get; set; }
        public string OpenDate { get; set; }
        public double bal
        {
            get
            {
                return (double)this.IOpen - (double)this.ISale + (double)this.IPurch;
            }
        }

        public Stock()
        {
            Branch = 0;
            Code = "";
            Number = 0;
            Loc = "";
            IOpen = 0;
            ISale = 0;
            IPurch = 0;
            AOpen = 0;
            ASale = 0;
            CSale = 0;
            ITemp = 0;
            ATemp = 0;
            APurch = 0;
            OpenDate = "";
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
                    myContext.StockInsert(this.Branch, this.Code, this.Number, this.Loc, this.IOpen, this.ISale, this.IPurch, this.AOpen, this.ASale, this.CSale, this.ITemp, this.ATemp, this.APurch, this.OpenDate);
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
                    myContext.StockDelete(this.Branch, this.Code, this.Number);
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
                    myContext.StockUpdate(this.Branch, this.Code, this.Number, this.Loc, this.IOpen, this.ISale, this.IPurch, this.AOpen, this.ASale, this.CSale, this.ITemp, this.ATemp, this.APurch, this.OpenDate);
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
        public List<Stock> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.StockGetAll(this.Branch);
                    return (from itm in result
                            select new Stock
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Number = itm.Number,
                                Loc = itm.Loc,
                                IOpen = itm.IOpen,
                                ISale = itm.ISale,
                                IPurch = itm.IPurch,
                                AOpen = itm.AOpen,
                                ASale = itm.ASale,
                                CSale = itm.CSale,
                                ITemp = itm.ITemp,
                                ATemp = itm.ATemp,
                                APurch = itm.APurch,
                                OpenDate = itm.OpenDate
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
        public List<Stock> GetNumber(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.StockGetNumber(this.Branch, this.Number);
                    return (from itm in result
                            select new Stock
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Number = itm.Number,
                                Loc = itm.Loc,
                                IOpen = itm.IOpen,
                                ISale = itm.ISale,
                                IPurch = itm.IPurch,
                                AOpen = itm.AOpen,
                                ASale = itm.ASale,
                                CSale = itm.CSale,
                                ITemp = itm.ITemp,
                                ATemp = itm.ATemp,
                                APurch = itm.APurch,
                                OpenDate = itm.OpenDate
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
        public Stock GetItem(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.StockGetItem(this.Branch, this.Number, this.Code);
                    return (from itm in result
                            select new Stock
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Number = itm.Number,
                                Loc = itm.Loc,
                                IOpen = itm.IOpen,
                                ISale = itm.ISale,
                                IPurch = itm.IPurch,
                                AOpen = itm.AOpen,
                                ASale = itm.ASale,
                                CSale = itm.CSale,
                                ITemp = itm.ITemp,
                                ATemp = itm.ATemp,
                                APurch = itm.APurch,
                                OpenDate = itm.OpenDate
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
        public List<Stock> GetItems(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.StockGetItems(this.Branch, this.Code);
                    return (from itm in result
                            select new Stock
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Number = itm.Number,
                                Loc = itm.Loc,
                                IOpen = itm.IOpen,
                                ISale = itm.ISale,
                                IPurch = itm.IPurch,
                                AOpen = itm.AOpen,
                                ASale = itm.ASale,
                                CSale = itm.CSale,
                                ITemp = itm.ITemp,
                                ATemp = itm.ATemp,
                                APurch = itm.APurch,
                                OpenDate = itm.OpenDate
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
    public class ItemStock
    {
        public short Branch { get; set; }
        public string Code { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public short Number { get; set; }
        public string Loc { get; set; }
        public System.Nullable<double> IOpen { get; set; }
        public string OpenDate { get; set; }

        public ItemStock()
        {
            Branch = 0;
            Code = "";
            Name1 = "";
            Name2 = "";
            Number = 0;
            Loc = "";
            IOpen = 0;
            OpenDate = "";
        }

        public List<ItemStock> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShopGetAll(2, this.Branch);
                    return (from itm in result
                            select new ItemStock
                            {
                                Branch = itm.Bran,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                Number = itm.Number  
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
    public class vStock : Stock
    {
        public string ITName1 { get; set; }
        public string ITName2 { get; set; }
        public string ICat { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string CSal_Acc { get; set; }
        public string CrSal_Acc { get; set; }
        public string RCSal_Acc { get; set; }
        public string RCrSal_Acc { get; set; }
        public string CPur_Acc { get; set; }
        public string RCrPur_Acc { get; set; }
        public string RCPur_Acc { get; set; }
        public string CrPur_Acc { get; set; }
        public System.Nullable<double> ITCPrice { get; set; }
        public string NCode { get; set; }
        public string ITCode2 { get; set; }
        public double Amount
        {
            get
            {
                //if ((this.IOpen - this.ISale + this.IPurch) * this.ITCPrice < 0) return 0;
                //else 
                return (double)((this.IOpen - this.ISale + this.IPurch) * this.ITCPrice);
            }
        }
        public double Amount2
        {
            get
            {
                //if (this.AOpen - this.ASale + this.APurch < 0) return 0;
                //else 
                return (double)(this.AOpen - this.ASale + this.APurch);
            }
        }


        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public new List<vStock> GetNumber(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vStockGetNumber(this.Branch, this.Number);
                    return (from itm in result
                            select new vStock
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Number = itm.Number,
                                Loc = itm.Loc,
                                IOpen = itm.IOpen,
                                ISale = itm.ISale,
                                IPurch = itm.IPurch,
                                AOpen = itm.AOpen,
                                ASale = itm.ASale,
                                CSale = itm.CSale,
                                ITemp = itm.ITemp,
                                ATemp = itm.ATemp,
                                APurch = itm.APurch,
                                OpenDate = itm.OpenDate,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2,
                                CPur_Acc = itm.CPur_Acc,
                                CrPur_Acc = itm.CrPur_Acc,
                                CrSal_Acc = itm.CrSal_Acc,
                                CSal_Acc = itm.CSal_Acc,
                                ICat = itm.ICat,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                RCPur_Acc = itm.RCPur_Acc,
                                RCrPur_Acc = itm.RCrPur_Acc,
                                RCSal_Acc = itm.RCSal_Acc,
                                RCrSal_Acc = itm.RCrSal_Acc,
                                ITCPrice = itm.ITCPrice,
                                ITCode2 = itm.ITCode2,
                                NCode = itm.NCode
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public vStock GetStockItem(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.vStockGetItem(this.Branch, this.Number,this.Code);
                    return (from itm in result
                            select new vStock
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Number = itm.Number,
                                Loc = itm.Loc,
                                IOpen = itm.IOpen,
                                ISale = itm.ISale,
                                IPurch = itm.IPurch,
                                AOpen = itm.AOpen,
                                ASale = itm.ASale,
                                CSale = itm.CSale,
                                ITemp = itm.ITemp,
                                ATemp = itm.ATemp,
                                APurch = itm.APurch,
                                OpenDate = itm.OpenDate,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2,
                                CPur_Acc = itm.CPur_Acc,
                                CrPur_Acc = itm.CrPur_Acc,
                                CrSal_Acc = itm.CrSal_Acc,
                                CSal_Acc = itm.CSal_Acc,
                                ICat = itm.ICat,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                RCPur_Acc = itm.RCPur_Acc,
                                RCrPur_Acc = itm.RCrPur_Acc,
                                RCSal_Acc = itm.RCSal_Acc,
                                RCrSal_Acc = itm.RCrSal_Acc,
                                ITCPrice = itm.ITCPrice,
                                ITCode2 = itm.ITCode2,
                                NCode = itm.NCode
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