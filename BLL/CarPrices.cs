using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class CarPrices
    {
        public short Branch { get; set; }
        public short MonthNo { get; set; }
        public string AccountNo { get; set; }
        public string PLevel { get; set; }
        public string FromCode { get; set; }
        public string toCode { get; set; }
        public System.Nullable<double> KMeter { get; set; }
        public System.Nullable<double> LOneWay { get; set; }
        public System.Nullable<double> LTwoWay { get; set; }
        public System.Nullable<double> HOneWay { get; set; }
        public System.Nullable<double> HTwoWay { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public string FTime { get; set; }
        public System.Nullable<double> CostAmount { get; set; }
        public string cnn { get; set; }
        public System.Nullable<double> ExPrice1 { get; set; }
        public System.Nullable<double> ExPrice2 { get; set; }
        public System.Nullable<double> ExPrice3 { get; set; }
        public System.Nullable<double> ExPrice4 { get; set; }
        public System.Nullable<double> ExPrice5 { get; set; }
        public System.Nullable<double> ExPrice01 { get; set; }
        public System.Nullable<double> ExPrice12 { get; set; }
        public System.Nullable<double> ExPrice012 { get; set; }
        public System.Nullable<double> ExPrice04 { get; set; }
        public System.Nullable<double> ExPrice42 { get; set; }
        public System.Nullable<double> ExPrice042 { get; set; }
        public System.Nullable<double> ExPrice02 { get; set; }
        public System.Nullable<double> ExPrice22 { get; set; }
        public System.Nullable<double> ExPrice022 { get; set; }
        public System.Nullable<double> ExPrice03 { get; set; }
        public System.Nullable<double> ExPrice032 { get; set; }
        public System.Nullable<double> CollectPrice { get; set; }
        public System.Nullable<double> CollectPrice2 { get; set; }
        public System.Nullable<double> DisPrice { get; set; }
        public System.Nullable<double> DisPrice2 { get; set; }
        public System.Nullable<double> TruckPrice { get; set; }
        public System.Nullable<double> TruckPrice2 { get; set; }
        public System.Nullable<double> Truck2Price { get; set; }
        public System.Nullable<double> Truck2Price2 { get; set; }
        public System.Nullable<double> Price { get; set; }
        public System.Nullable<double> PriceDiff { get; set; }
        public System.Nullable<double> DriverRate { get; set; }
        public System.Nullable<double> CollectDisRate { get; set; }
        public string FTime2 { get; set; }
        public System.Nullable<double> XPrice1 { get; set; }
        public System.Nullable<double> XPrice2 { get; set; }
        public System.Nullable<double> XPrice3 { get; set; }
        public System.Nullable<double> XPrice4 { get; set; }
        public System.Nullable<double> XPrice5 { get; set; }
        public System.Nullable<double> ExPrice32 { get; set; }
        public string CollectBran { get; set; }
        public string DisBran { get; set; }
        public System.Nullable<double> BranRange { get; set; }
        public System.Nullable<double> BranRange2 { get; set; }


        public string FromCode2
        {
            get
            {
                if (this.FromCode != "")
                {
                    Cities myCity = new Cities();
                    myCity.Branch = this.Branch;
                    myCity.Code = this.FromCode;
                    myCity = myCity.Find(cnn);
                    if (myCity != null)
                    {
                        return myCity.Name1;
                    }
                    else
                    {
                        return "";
                    }
                }
                else return "";
            }
            
        }
        public string ToCode2
        {
            get
            {
                if (this.toCode != "")
                {
                    Cities myCity = new Cities();
                    myCity.Branch = this.Branch;
                    myCity.Code = this.toCode;
                    myCity = myCity.Find(cnn);
                    if (myCity != null)
                    {
                        return myCity.Name1;
                    }
                    else
                    {
                        return "";
                    }
                }
                else return "";
            }

        }

        public string CollectBran2
        {
            get
            {
                if (this.CollectBran != "")
                {
                    CostCenter myCity = new CostCenter();
                    myCity.Branch = this.Branch;
                    myCity.Code = this.CollectBran;
                    myCity = myCity.find(cnn);
                    if (myCity != null)
                    {
                        return myCity.Name1;
                    }
                    else
                    {
                        return "";
                    }
                }
                else return "";
            }
            
        }
        public string DisBran2
        {
            get
            {
                if (this.DisBran != "")
                {
                    CostCenter myCity = new CostCenter();
                    myCity.Branch = this.Branch;
                    myCity.Code = this.DisBran;
                    myCity = myCity.find(cnn);
                    if (myCity != null)
                    {
                        return myCity.Name1;
                    }
                    else
                    {
                        return "";
                    }
                }
                else return "";
            }

        }


        public CarPrices()
        {
            this.Branch = 1;
            this.MonthNo = 0;
            this.AccountNo = "-1";
            this.PLevel = "";
            this.FromCode = "";
            this.toCode = "";
            this.cnn = "";
            this.KMeter = 0;
            this.LOneWay = 0;
            this.LTwoWay = 0;
            this.HOneWay = 0;
            this.HTwoWay = 0;
            this.UserName = "";
            this.UserDate = "";
            this.CostAmount = 0;
            this.FTime = "";
            this.ExPrice1 = 0;
            this.ExPrice2 = 0;
            this.ExPrice3 = 0;
            this.ExPrice4 = 0;
            this.ExPrice5 = 0;
            this.ExPrice32 = 0;
            this.ExPrice01 = 0;
            this.ExPrice12 = 0;
            this.ExPrice012 = 0;
            this.ExPrice04 = 0;
            this.ExPrice42 = 0;
            this.ExPrice042 = 0;
            this.ExPrice02 = 0;
            this.ExPrice22 = 0;
            this.ExPrice022 = 0;
            this.ExPrice03 = 0;
            this.ExPrice032 = 0;
            this.CollectPrice = 0;
            this.CollectPrice2 = 0;
            this.DisPrice = 0;
            this.DisPrice2 = 0;
            this.TruckPrice = 0;
            this.TruckPrice2 = 0;
            this.Truck2Price = 0;
            this.Truck2Price2 = 0;
            this.Price = 0;
            this.PriceDiff = 0;
            this.DriverRate = 0;
            this.CollectDisRate = 0;
            this.FTime2 = "";
            this.XPrice1 = 0;
            this.XPrice2 = 0;
            this.XPrice3 = 0;
            this.XPrice4 = 0;
            this.XPrice5 = 0;
            this.ExPrice32 = 0;
            this.CollectBran = "";
            this.DisBran = "";
            this.BranRange = 0;
            this.BranRange2 = 0;
        }

        /// <summary>
        /// Add Car Transfer Price in CarPrices Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CarPricesInsert(this.Branch, this.MonthNo, this.AccountNo, this.PLevel, this.FromCode, this.toCode, this.KMeter, this.LOneWay, this.LTwoWay, this.HOneWay, this.HTwoWay, this.UserName, this.UserDate, this.CostAmount, this.FTime, this.ExPrice1, this.ExPrice2, this.ExPrice3, this.ExPrice4, this.ExPrice5,
                    this.ExPrice01,this.ExPrice12,this.ExPrice012,this.ExPrice04,this.ExPrice42,this.ExPrice042,this.ExPrice02,this.ExPrice22,this.ExPrice022,this.ExPrice03,this.ExPrice032,this.CollectPrice,this.CollectPrice2,this.DisPrice,this.DisPrice2,this.TruckPrice,this.TruckPrice2,this.Truck2Price,this.Truck2Price2,this.Price,
                    this.PriceDiff,this.DriverRate,this.CollectDisRate,this.FTime2,this.XPrice1,this.XPrice2,this.XPrice3,this.XPrice4,this.XPrice5
                    ,this.ExPrice32,this.CollectBran,this.DisBran,this.BranRange,this.BranRange2);                    
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Car Transfer Price from CarPrices Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CarPricesDelete(this.Branch, this.MonthNo,this.AccountNo,this.PLevel, this.FromCode, this.toCode);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Car Transfer Price in CarPrices Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CarPricesUpdate(this.Branch, this.MonthNo, this.AccountNo, this.PLevel, this.FromCode, this.toCode, this.KMeter, this.LOneWay, this.LTwoWay, this.HOneWay, this.HTwoWay, this.UserName, this.UserDate, this.CostAmount, this.FTime, this.ExPrice1, this.ExPrice2, this.ExPrice3, this.ExPrice4, this.ExPrice5,
                    this.ExPrice01, this.ExPrice12, this.ExPrice012, this.ExPrice04, this.ExPrice42, this.ExPrice042, this.ExPrice02, this.ExPrice22, this.ExPrice022, this.ExPrice03, this.ExPrice032, this.CollectPrice, this.CollectPrice2, this.DisPrice, this.DisPrice2, this.TruckPrice, this.TruckPrice2, this.Truck2Price, this.Truck2Price2,
                    this.Price, this.PriceDiff, this.DriverRate, this.CollectDisRate, this.FTime2, this.XPrice1, this.XPrice2, this.XPrice3, this.XPrice4, this.XPrice5, this.ExPrice32, this.CollectBran, this.DisBran, this.BranRange, this.BranRange2);                    
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// select all Car Transfer Prices from CarPrices Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<CarPrices> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarPricesGetAll(this.Branch);
                    return (from itm in result
                            select new CarPrices
                            {
                                cnn = ConnectionStr, 
                                Branch = itm.Branch,
                                MonthNo = itm.MonthNo,
                                AccountNo = itm.AccountNo,
                                PLevel = itm.PLevel,
                                FromCode = itm.FromCode,
                                toCode = itm.toCode,
                                KMeter = itm.KMeter,
                                LOneWay = itm.LOneWay,
                                LTwoWay = itm.LTwoWay,
                                HOneWay = itm.HOneWay,
                                HTwoWay = itm.HTwoWay,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                CostAmount = itm.CostAmount,
                                FTime = itm.FTime,
                                ExPrice1 = itm.ExPrice1,
                                ExPrice2 = itm.ExPrice2,
                                ExPrice3 = itm.ExPrice3,
                                ExPrice4 = itm.ExPrice4,
                                ExPrice5 = itm.ExPrice5,
                                ExPrice01 = itm.ExPrice01,
                                ExPrice12 = itm.ExPrice12,
                                ExPrice012 = itm.ExPrice012,
                                ExPrice04 = itm.ExPrice04,
                                ExPrice42 = itm.ExPrice42,
                                ExPrice042 = itm.ExPrice042,
                                ExPrice02 = itm.ExPrice02,
                                ExPrice22 = itm.ExPrice22,
                                ExPrice022 = itm.ExPrice022,
                                ExPrice03 = itm.ExPrice03,
                                ExPrice032 = itm.ExPrice032,
                                CollectPrice = itm.CollectPrice,
                                CollectPrice2 = itm.CollectPrice2,
                                DisPrice = itm.DisPrice,
                                DisPrice2 = itm.DisPrice2,
                                TruckPrice = itm.TruckPrice,
                                TruckPrice2 = itm.TruckPrice2,
                                Truck2Price = itm.Truck2Price,
                                Truck2Price2 = itm.Truck2Price2,
                                Price = itm.Price,
                                PriceDiff = itm.PriceDiff,
                                DriverRate = itm.DriverRate,
                                CollectDisRate = itm.CollectDisRate,
                                FTime2 = itm.FTime2,
                                XPrice1 = itm.XPrice1,
                                XPrice2 = itm.XPrice2,
                                XPrice3 = itm.XPrice3,
                                XPrice4 = itm.XPrice4,
                                XPrice5 = itm.XPrice5,
                                ExPrice32 = itm.ExPrice32,
                                CollectBran = itm.CollectBran,
                                DisBran = itm.DisBran,
                                BranRange = itm.BranRange,
                                BranRange2 = itm.BranRange2
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Car Transfer Prices from CarPrices Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<CarPrices> GetMonth(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarPricesGetMonth(this.Branch , this.MonthNo,this.AccountNo , this.PLevel);
                    return (from itm in result
                            select new CarPrices
                            {
                                cnn = ConnectionStr, 
                                Branch = itm.Branch,
                                MonthNo = itm.MonthNo,
                                AccountNo = itm.AccountNo,
                                PLevel = itm.PLevel,
                                FromCode = itm.FromCode,
                                toCode = itm.toCode,
                                KMeter = itm.KMeter,
                                LOneWay = itm.LOneWay,
                                LTwoWay = itm.LTwoWay,
                                HOneWay = itm.HOneWay,
                                HTwoWay = itm.HTwoWay,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                CostAmount = itm.CostAmount,
                                FTime = itm.FTime,
                                ExPrice1 = itm.ExPrice1,
                                ExPrice2 = itm.ExPrice2,
                                ExPrice3 = itm.ExPrice3,
                                ExPrice4 = itm.ExPrice4,
                                ExPrice5 = itm.ExPrice5,
                                ExPrice01 = itm.ExPrice01,
                                ExPrice12 = itm.ExPrice12,
                                ExPrice012 = itm.ExPrice012,
                                ExPrice04 = itm.ExPrice04,
                                ExPrice42 = itm.ExPrice42,
                                ExPrice042 = itm.ExPrice042,
                                ExPrice02 = itm.ExPrice02,
                                ExPrice22 = itm.ExPrice22,
                                ExPrice022 = itm.ExPrice022,
                                ExPrice03 = itm.ExPrice03,
                                ExPrice032 = itm.ExPrice032,
                                CollectPrice = itm.CollectPrice,
                                CollectPrice2 = itm.CollectPrice2,
                                DisPrice = itm.DisPrice,
                                DisPrice2 = itm.DisPrice2,
                                TruckPrice = itm.TruckPrice,
                                TruckPrice2 = itm.TruckPrice2,
                                Truck2Price = itm.Truck2Price,
                                Truck2Price2 = itm.Truck2Price2,
                                Price = itm.Price,
                                PriceDiff = itm.PriceDiff,
                                DriverRate = itm.DriverRate,
                                CollectDisRate = itm.CollectDisRate,
                                FTime2 = itm.FTime2,
                                XPrice1 = itm.XPrice1,
                                XPrice2 = itm.XPrice2,
                                XPrice3 = itm.XPrice3,
                                XPrice4 = itm.XPrice4,
                                XPrice5 = itm.XPrice5,
                                ExPrice32 = itm.ExPrice32,
                                CollectBran = itm.CollectBran,
                                DisBran = itm.DisBran,
                                BranRange = itm.BranRange,
                                BranRange2 = itm.BranRange2                                                          
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Car Transfer Prices from CarPrices Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<CarPrices> GetMonth2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarPricesGetMonth2(this.Branch, this.MonthNo,this.AccountNo, this.PLevel,this.FromCode);
                    return (from itm in result
                            select new CarPrices
                            {
                                cnn = ConnectionStr,
                                Branch = itm.Branch,
                                MonthNo = itm.MonthNo,
                                AccountNo = itm.AccountNo,
                                PLevel = itm.PLevel,
                                FromCode = itm.FromCode,
                                toCode = itm.toCode,
                                KMeter = itm.KMeter,
                                LOneWay = itm.LOneWay,
                                LTwoWay = itm.LTwoWay,
                                HOneWay = itm.HOneWay,
                                HTwoWay = itm.HTwoWay,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                CostAmount = itm.CostAmount,
                                FTime = itm.FTime,
                                ExPrice1 = itm.ExPrice1,
                                ExPrice2 = itm.ExPrice2,
                                ExPrice3 = itm.ExPrice3,
                                ExPrice4 = itm.ExPrice4,
                                ExPrice5 = itm.ExPrice5,
                                ExPrice01 = itm.ExPrice01,
                                ExPrice12 = itm.ExPrice12,
                                ExPrice012 = itm.ExPrice012,
                                ExPrice04 = itm.ExPrice04,
                                ExPrice42 = itm.ExPrice42,
                                ExPrice042 = itm.ExPrice042,
                                ExPrice02 = itm.ExPrice02,
                                ExPrice22 = itm.ExPrice22,
                                ExPrice022 = itm.ExPrice022,
                                ExPrice03 = itm.ExPrice03,
                                ExPrice032 = itm.ExPrice032,
                                CollectPrice = itm.CollectPrice,
                                CollectPrice2 = itm.CollectPrice2,
                                DisPrice = itm.DisPrice,
                                DisPrice2 = itm.DisPrice2,
                                TruckPrice = itm.TruckPrice,
                                TruckPrice2 = itm.TruckPrice2,
                                Truck2Price = itm.Truck2Price,
                                Truck2Price2 = itm.Truck2Price2,
                                Price = itm.Price,
                                PriceDiff = itm.PriceDiff,
                                DriverRate = itm.DriverRate,
                                CollectDisRate = itm.CollectDisRate,
                                FTime2 = itm.FTime2,
                                XPrice1 = itm.XPrice1,
                                XPrice2 = itm.XPrice2,
                                XPrice3 = itm.XPrice3,
                                XPrice4 = itm.XPrice4,
                                XPrice5 = itm.XPrice5,
                                ExPrice32 = itm.ExPrice32,
                                CollectBran = itm.CollectBran,
                                DisBran = itm.DisBran,
                                BranRange = itm.BranRange,
                                BranRange2 = itm.BranRange2                                                          
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Car Transfer Prices from CarPrices Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public CarPrices Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarPricesFind(this.Branch, this.MonthNo,this.AccountNo, this.PLevel, this.FromCode, this.toCode);
                    return (from itm in result
                            select new CarPrices
                            {
                                cnn = ConnectionStr, 
                                Branch = itm.Branch,
                                MonthNo = itm.MonthNo,
                                AccountNo = itm.AccountNo,
                                PLevel = itm.PLevel,
                                FromCode = itm.FromCode,
                                toCode = itm.toCode,
                                KMeter = itm.KMeter,
                                LOneWay = itm.LOneWay,
                                LTwoWay = itm.LTwoWay,
                                HOneWay = itm.HOneWay,
                                HTwoWay = itm.HTwoWay,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                CostAmount = itm.CostAmount,
                                FTime = itm.FTime,
                                ExPrice1 = itm.ExPrice1,
                                ExPrice2 = itm.ExPrice2,
                                ExPrice3 = itm.ExPrice3,
                                ExPrice4 = itm.ExPrice4,
                                ExPrice5 = itm.ExPrice5,
                                ExPrice01 = itm.ExPrice01,
                                ExPrice12 = itm.ExPrice12,
                                ExPrice012 = itm.ExPrice012,
                                ExPrice04 = itm.ExPrice04,
                                ExPrice42 = itm.ExPrice42,
                                ExPrice042 = itm.ExPrice042,
                                ExPrice02 = itm.ExPrice02,
                                ExPrice22 = itm.ExPrice22,
                                ExPrice022 = itm.ExPrice022,
                                ExPrice03 = itm.ExPrice03,
                                ExPrice032 = itm.ExPrice032,
                                CollectPrice = itm.CollectPrice,
                                CollectPrice2 = itm.CollectPrice2,
                                DisPrice = itm.DisPrice,
                                DisPrice2 = itm.DisPrice2,
                                TruckPrice = itm.TruckPrice,
                                TruckPrice2 = itm.TruckPrice2,
                                Truck2Price = itm.Truck2Price,
                                Truck2Price2 = itm.Truck2Price2,
                                Price = itm.Price,
                                PriceDiff = itm.PriceDiff,
                                DriverRate = itm.DriverRate,
                                CollectDisRate = itm.CollectDisRate,
                                FTime2 = itm.FTime2,
                                XPrice1 = itm.XPrice1,
                                XPrice2 = itm.XPrice2,
                                XPrice3 = itm.XPrice3,
                                XPrice4 = itm.XPrice4,
                                XPrice5 = itm.XPrice5,
                                ExPrice32 = itm.ExPrice32,
                                CollectBran = itm.CollectBran,
                                DisBran = itm.DisBran,
                                BranRange = itm.BranRange,
                                BranRange2 = itm.BranRange2                                                          
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Car Transfer Prices from CarPrices Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public CarPrices Find2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarPricesFind2(this.Branch, this.MonthNo,this.AccountNo, this.PLevel, this.FromCode, this.toCode);
                    return (from itm in result
                            select new CarPrices
                            {
                                cnn = ConnectionStr,
                                Branch = itm.Branch,
                                MonthNo = itm.MonthNo,
                                AccountNo = itm.AccountNo,
                                PLevel = itm.PLevel,
                                FromCode = itm.FromCode,
                                toCode = itm.toCode,
                                KMeter = itm.KMeter,
                                LOneWay = itm.LOneWay,
                                LTwoWay = itm.LTwoWay,
                                HOneWay = itm.HOneWay,
                                HTwoWay = itm.HTwoWay,
                                UserName = itm.UserName,
                                UserDate = itm.UserDate,
                                CostAmount = itm.CostAmount,
                                FTime = itm.FTime,
                                ExPrice1 = itm.ExPrice1,
                                ExPrice2 = itm.ExPrice2,
                                ExPrice3 = itm.ExPrice3,
                                ExPrice4 = itm.ExPrice4,
                                ExPrice5 = itm.ExPrice5,
                                ExPrice01 = itm.ExPrice01,
                                ExPrice12 = itm.ExPrice12,
                                ExPrice012 = itm.ExPrice012,
                                ExPrice04 = itm.ExPrice04,
                                ExPrice42 = itm.ExPrice42,
                                ExPrice042 = itm.ExPrice042,
                                ExPrice02 = itm.ExPrice02,
                                ExPrice22 = itm.ExPrice22,
                                ExPrice022 = itm.ExPrice022,
                                ExPrice03 = itm.ExPrice03,
                                ExPrice032 = itm.ExPrice032,
                                CollectPrice = itm.CollectPrice,
                                CollectPrice2 = itm.CollectPrice2,
                                DisPrice = itm.DisPrice,
                                DisPrice2 = itm.DisPrice2,
                                TruckPrice = itm.TruckPrice,
                                TruckPrice2 = itm.TruckPrice2,
                                Truck2Price = itm.Truck2Price,
                                Truck2Price2 = itm.Truck2Price2,
                                Price = itm.Price,
                                PriceDiff = itm.PriceDiff,
                                DriverRate = itm.DriverRate,
                                CollectDisRate = itm.CollectDisRate,
                                FTime2 = itm.FTime2,
                                XPrice1 = itm.XPrice1,
                                XPrice2 = itm.XPrice2,
                                XPrice3 = itm.XPrice3,
                                XPrice4 = itm.XPrice4,
                                XPrice5 = itm.XPrice5,
                                ExPrice32 = itm.ExPrice32,
                                CollectBran = itm.CollectBran,
                                DisBran = itm.DisBran,
                                BranRange = itm.BranRange,
                                BranRange2 = itm.BranRange2                                                          
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