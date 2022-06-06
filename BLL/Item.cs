using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Item
    {
        public short Branch { get; set; }
        public string ITCode { get; set; }
        public System.Nullable<short> FType { get; set; }
        public string ICat { get; set; }
        public string ISize { get; set; }
        public string IColor { get; set; }
        public string ICoo { get; set; }
        public string IWidth { get; set; }
        public string ITName1 { get; set; }
        public string ITName2 { get; set; }
        public string ITUnit1 { get; set; }
        public System.Nullable<double> ITSprice1 { get; set; }
        public System.Nullable<double> ITLprice1 { get; set; }
        public string ITUnit2 { get; set; }
        public System.Nullable<double> ITSprice2 { get; set; }
        public System.Nullable<double> ITLprice2 { get; set; }
        public System.Nullable<double> ITreorder { get; set; }
        public System.Nullable<double> ITEqual { get; set; }
        public System.Nullable<double> ITCPrice { get; set; }
        public string SubItem1 { get; set; }
        public string SubItem2 { get; set; }
        public System.Nullable<double> IOpen { get; set; }
        public System.Nullable<double> AOpen { get; set; }
        public System.Nullable<double> ISale { get; set; }
        public System.Nullable<double> ASale { get; set; }
        public System.Nullable<double> IPurch { get; set; }
        public System.Nullable<double> APurch { get; set; }
        public System.Nullable<double> CSale { get; set; }
        public System.Nullable<double> ITemp { get; set; }
        public System.Nullable<double> ATemp { get; set; }
        public System.Nullable<double> ITLPPrice { get; set; }
        public string Remark { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public string ITCode0 { get; set; }
        public string ITCode2 { get; set; }
        public bool? ReturnItem { get; set; }
        public string NCode { get; set; }

        public Item()
        {
            Branch=0;
            ITCode="";
            FType=1;
            ICat="";
            ISize="";
            IColor="";
            ICoo="";
            IWidth="";
            ITName1="";
            ITName2="";
            ITUnit1="";
            ITSprice1=0;
            ITLprice1=0;
            ITUnit2="";
            ITSprice2=0;
            ITLprice2=0;
            ITreorder=0;
            ITEqual=1;
            ITCPrice=0;
            SubItem1="";
            SubItem2="";
            IOpen=0;
            AOpen=0;
            ISale=0;
            ASale=0;
            IPurch=0;
            APurch=0;
            CSale=0;
            ITemp=0;
            ATemp=0;
            ITLPPrice=0;
            Remark="";
            UserName = "";
            UserDate = "";
            ITCode0 = "";
            ITCode2 = "";
            ReturnItem = true;
            this.NCode = "";
        }


        /// <summary>
        /// Add Stock Item in Item Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ItemInsert(this.Branch,this.ITCode,this.FType,this.ICat,this.ISize,this.IColor,this.ICoo,this.IWidth,this.ITName1,this.ITName2,this.ITUnit1,
                        this.ITSprice1,this.ITLprice1,this.ITUnit2,this.ITSprice2,this.ITLprice2,this.ITreorder,this.ITEqual,this.ITCPrice,this.SubItem1,this.SubItem2,this.IOpen,
                        this.AOpen,this.ISale,this.ASale,this.IPurch,this.APurch,this.CSale,this.ITemp,this.ATemp,this.ITLPPrice,this.Remark,this.UserName,this.UserDate,this.ITCode0,this.ITCode2,this.ReturnItem,this.NCode);                       
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
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ItemDelete(this.Branch,this.ITCode);
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
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ItemUpdate(this.Branch, this.ITCode, this.FType, this.ICat, this.ISize, this.IColor, this.ICoo, this.IWidth, this.ITName1, this.ITName2, this.ITUnit1,
                        this.ITSprice1, this.ITLprice1, this.ITUnit2, this.ITSprice2, this.ITLprice2, this.ITreorder, this.ITEqual, this.ITCPrice, this.SubItem1, this.SubItem2, this.IOpen,
                        this.AOpen, this.ISale, this.ASale, this.IPurch, this.APurch, this.CSale, this.ITemp, this.ATemp, this.ITLPPrice, this.Remark, this.UserName, this.UserDate, this.ITCode0, this.ITCode2, this.ReturnItem,this.NCode);                       
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
        public List<Item> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ItemGetAll(this.Branch, this.FType);
                    return (from itm in result
                            select new Item
                            {
                                Branch=itm.Branch,
                                ITCode=itm.ITCode,
                                FType=itm.FType,
                                ICat=itm.ICat,
                                ISize=itm.ISize,
                                IColor=itm.IColor,
                                ICoo=itm.ICoo,
                                IWidth=itm.IWidth,
                                ITName1=itm.ITName1,
                                ITName2=itm.ITName2,
                                ITUnit1=itm.ITUnit1,
                                ITSprice1=itm.ITSprice1,
                                ITLprice1=itm.ITLprice1,
                                ITUnit2=itm.ITUnit2,
                                ITSprice2=itm.ITSprice2,
                                ITLprice2=itm.ITLprice2,
                                ITreorder=itm.ITreorder,
                                ITEqual=itm.ITEqual,
                                ITCPrice=itm.ITCPrice,
                                SubItem1=itm.SubItem1,
                                SubItem2=itm.SubItem2,
                                IOpen=itm.IOpen,
                                AOpen=itm.AOpen,
                                ISale=itm.ISale,
                                ASale=itm.ASale,
                                IPurch=itm.IPurch,
                                APurch=itm.APurch,
                                CSale=itm.CSale,
                                ITemp=itm.ITemp,
                                ATemp=itm.ATemp,
                                ITLPPrice=itm.ITLPPrice,
                                Remark=itm.Remark,
                                UserName=itm.UserName,
                                UserDate=itm.UserDate,
                                ITCode0 = itm.ITCode0,
                                ITCode2 = itm.ITCode2,
                                ReturnItem = itm.ReturnItem,
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
        /// select all Branch or Stores from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public List<Item> GetByNCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ItemGetByNCode(this.Branch, this.NCode);
                    return (from itm in result
                            select new Item
                            {
                                Branch = itm.Branch,
                                ITCode = itm.ITCode,
                                FType = itm.FType,
                                ICat = itm.ICat,
                                ISize = itm.ISize,
                                IColor = itm.IColor,
                                ICoo = itm.ICoo,
                                IWidth = itm.IWidth,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2,
                                ITUnit1 = itm.ITUnit1,
                                ITSprice1 = itm.ITSprice1,
                                ITLprice1 = itm.ITLprice1,
                                ITUnit2 = itm.ITUnit2,
                                ITSprice2 = itm.ITSprice2,
                                ITLprice2 = itm.ITLprice2,
                                ITreorder = itm.ITreorder,
                                ITEqual = itm.ITEqual,
                                ITCPrice = itm.ITCPrice,
                                SubItem1 = itm.SubItem1,
                                SubItem2 = itm.SubItem2,
                                IOpen = itm.IOpen,
                                AOpen = itm.AOpen,
                                ISale = itm.ISale,
                                ASale = itm.ASale,
                                IPurch = itm.IPurch,
                                APurch = itm.APurch,
                                CSale = itm.CSale,
                                ITemp = itm.ITemp,
                                ATemp = itm.ATemp,
                                ITLPPrice = itm.ITLPPrice,
                                Remark = itm.Remark,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                ITCode0 = itm.ITCode0,
                                ITCode2 = itm.ITCode2,
                                ReturnItem = itm.ReturnItem,
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
        /// select all Branch or Stores from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public List<Item> GetByITCode2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ItemGetByITCode2(this.Branch, this.ITCode2);
                    return (from itm in result
                            select new Item
                            {
                                Branch = itm.Branch,
                                ITCode = itm.ITCode,
                                FType = itm.FType,
                                ICat = itm.ICat,
                                ISize = itm.ISize,
                                IColor = itm.IColor,
                                ICoo = itm.ICoo,
                                IWidth = itm.IWidth,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2,
                                ITUnit1 = itm.ITUnit1,
                                ITSprice1 = itm.ITSprice1,
                                ITLprice1 = itm.ITLprice1,
                                ITUnit2 = itm.ITUnit2,
                                ITSprice2 = itm.ITSprice2,
                                ITLprice2 = itm.ITLprice2,
                                ITreorder = itm.ITreorder,
                                ITEqual = itm.ITEqual,
                                ITCPrice = itm.ITCPrice,
                                SubItem1 = itm.SubItem1,
                                SubItem2 = itm.SubItem2,
                                IOpen = itm.IOpen,
                                AOpen = itm.AOpen,
                                ISale = itm.ISale,
                                ASale = itm.ASale,
                                IPurch = itm.IPurch,
                                APurch = itm.APurch,
                                CSale = itm.CSale,
                                ITemp = itm.ITemp,
                                ATemp = itm.ATemp,
                                ITLPPrice = itm.ITLPPrice,
                                Remark = itm.Remark,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                ITCode0 = itm.ITCode0,
                                ITCode2 = itm.ITCode2,
                                ReturnItem = itm.ReturnItem,
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
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public Item find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ItemGet(this.Branch,this.ITCode);
                    return (from itm in result
                            select new Item
                            {
                                Branch = itm.Branch,
                                ITCode = itm.ITCode,
                                FType = itm.FType,
                                ICat = itm.ICat,
                                ISize = itm.ISize,
                                IColor = itm.IColor,
                                ICoo = itm.ICoo,
                                IWidth = itm.IWidth,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2,
                                ITUnit1 = itm.ITUnit1,
                                ITSprice1 = itm.ITSprice1,
                                ITLprice1 = itm.ITLprice1,
                                ITUnit2 = itm.ITUnit2,
                                ITSprice2 = itm.ITSprice2,
                                ITLprice2 = itm.ITLprice2,
                                ITreorder = itm.ITreorder,
                                ITEqual = itm.ITEqual,
                                ITCPrice = itm.ITCPrice,
                                SubItem1 = itm.SubItem1,
                                SubItem2 = itm.SubItem2,
                                IOpen = itm.IOpen,
                                AOpen = itm.AOpen,
                                ISale = itm.ISale,
                                ASale = itm.ASale,
                                IPurch = itm.IPurch,
                                APurch = itm.APurch,
                                CSale = itm.CSale,
                                ITemp = itm.ITemp,
                                ATemp = itm.ATemp,
                                ITLPPrice = itm.ITLPPrice,
                                Remark = itm.Remark,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                ITCode0 = itm.ITCode0,
                                ITCode2 = itm.ITCode2,
                                ReturnItem = itm.ReturnItem,
                                NCode = itm.NCode
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
        public Item find2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ItemGet2(this.Branch, this.ITCode,this.FType);
                    return (from itm in result
                            select new Item
                            {
                                Branch = itm.Branch,
                                ITCode = itm.ITCode,
                                FType = itm.FType,
                                ICat = itm.ICat,
                                ISize = itm.ISize,
                                IColor = itm.IColor,
                                ICoo = itm.ICoo,
                                IWidth = itm.IWidth,
                                ITName1 = itm.ITName1,
                                ITName2 = itm.ITName2,
                                ITUnit1 = itm.ITUnit1,
                                ITSprice1 = itm.ITSprice1,
                                ITLprice1 = itm.ITLprice1,
                                ITUnit2 = itm.ITUnit2,
                                ITSprice2 = itm.ITSprice2,
                                ITLprice2 = itm.ITLprice2,
                                ITreorder = itm.ITreorder,
                                ITEqual = itm.ITEqual,
                                ITCPrice = itm.ITCPrice,
                                SubItem1 = itm.SubItem1,
                                SubItem2 = itm.SubItem2,
                                IOpen = itm.IOpen,
                                AOpen = itm.AOpen,
                                ISale = itm.ISale,
                                ASale = itm.ASale,
                                IPurch = itm.IPurch,
                                APurch = itm.APurch,
                                CSale = itm.CSale,
                                ITemp = itm.ITemp,
                                ATemp = itm.ATemp,
                                ITLPPrice = itm.ITLPPrice,
                                Remark = itm.Remark,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                ITCode0 = itm.ITCode0,
                                ITCode2 = itm.ITCode2,
                                ReturnItem = itm.ReturnItem,
                                NCode = itm.NCode
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Get New Code for Size Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public string GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ItemMaxCode(this.Branch);
                    return (from itm in result
                            select itm.myCode).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}