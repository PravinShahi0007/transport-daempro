using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class CoCars
    {
        public short Branch { get; set; }
        public int CarsType { get; set; }
        public string Code { get; set; }
        public string PlateNo { get; set; }
        public string CarType { get; set; }
        public string CarType2 { get; set; }
        public System.Nullable<int> KMeter { get; set; }
        public System.Nullable<int> ChOilKMeter { get; set; }
        public string ChOilDate { get; set; }
        public System.Nullable<int> ChDezelKMeter { get; set; }
        public string ChDezelDate { get; set; }
        public System.Nullable<int> DriverCode { get; set; }
        public string Taraz { get; set; }
        public string Model { get; set; }
        public bool? Status { get; set; }
        public string PHDate1 { get; set; }
        public string PHDate2 { get; set; }
        public string PHDate3 { get; set; }
        public string PHDate4 { get; set; }
        public string PHDate5 { get; set; }
        public string PLoc1 { get; set; }
        public string PLoc2 { get; set; }
        public string PLoc3 { get; set; }
        public string PLoc4 { get; set; }
        public string PLoc5 { get; set; }
        public string PLoc { get; set; }
        public string Brand { get; set; }
        public string CarStruct { get; set; }
        public string CarSerial { get; set; }

        public string CodeName
        {
            get
            {
                return this.Code + " " + this.CarType;
            }
        }
        public string Name
        {
            get
            {
                return this.CarType;
            }
        }
        public string Name2
        {
            get
            {
                return this.CarType2;
            }
        }

        public CoCars()
        {
            this.Branch = 0;
            this.CarsType = 1;
            this.Code = "";
            this.PlateNo = "";
            this.CarType = "";
            this.CarType2 = "";
            this.KMeter = 0;
            this.ChOilDate = "";
            this.ChOilKMeter = 0;
            this.ChDezelDate = "";
            this.ChDezelKMeter = 0;
            this.DriverCode = -1;
            this.Taraz = "";
            this.Model = "";
            this.Status = true;
            this.PHDate1 = "";
            this.PHDate2 = "";
            this.PHDate3 = "";
            this.PHDate4 = "";
            this.PHDate5 = "";
            this.PLoc1 = "";
            this.PLoc2 = "";
            this.PLoc3 = "";
            this.PLoc4 = "";
            this.PLoc5 = "";
            this.PLoc = "";
            this.Brand = "";
            this.CarStruct = "";
            this.CarSerial = "";
        }

        /// <summary>
        /// Add Car in Cars Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.CoCarsAdd(this.Branch, this.CarsType, this.Code, this.PlateNo, this.CarType, this.CarType2, this.KMeter, this.ChOilKMeter, this.ChOilDate, this.ChDezelKMeter, this.ChDezelDate, this.DriverCode, this.Taraz, this.Model, this.Status, this.PHDate1, this.PHDate2, this.PHDate3, this.PHDate4, this.PLoc1, this.PLoc2, this.PLoc3, this.PLoc4, this.PHDate5, this.PLoc5, this.PLoc, this.Brand, this.CarStruct, this.CarSerial);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Car from Cars Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.CoCarsDelete(this.Branch, this.Code);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Car in Cars Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.CoCarsUpdate(this.Branch, this.CarsType, this.Code, this.PlateNo, this.CarType, this.CarType2, this.KMeter, this.ChOilKMeter, this.ChOilDate, this.ChDezelKMeter, this.ChDezelDate, this.DriverCode, this.Taraz, this.Model, this.Status, this.PHDate1, this.PHDate2, this.PHDate3, this.PHDate4, this.PLoc1, this.PLoc2, this.PLoc3, this.PLoc4, this.PHDate5, this.PLoc5, this.PLoc, this.Brand, this.CarStruct, this.CarSerial);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select all Cars from Cars Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<CoCars> GetAllByCarsType(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.CoCarsGetByCarsType(this.Branch, this.CarsType);
                    return (from itm in result
                            select new CoCars
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                CarType = itm.CarType,
                                CarType2 = itm.CarType2,
                                PlateNo = itm.PlateNo,
                                ChDezelDate = itm.ChDezelDate,
                                ChDezelKMeter = itm.ChDezelKMeter,
                                ChOilDate = itm.ChOilDate,
                                ChOilKMeter = itm.ChOilKMeter,
                                KMeter = itm.KMeter,
                                DriverCode = itm.DriverCode,
                                Model = itm.Model,
                                Taraz = itm.Taraz,
                                CarsType = itm.CarsType,
                                Status = itm.Status,
                                PHDate1 = itm.PHDate1,
                                PHDate2 = itm.PHDate2,
                                PHDate3 = itm.PHDate3,
                                PHDate4 = itm.PHDate4,
                                PLoc1 = itm.PLoc1,
                                PLoc2 = itm.PLoc2,
                                PLoc3 = itm.PLoc3,
                                PLoc4 = itm.PLoc4,
                                PHDate5 = itm.PHDate5,
                                PLoc5 = itm.PLoc5,
                                PLoc = itm.PLoc,
                                Brand = itm.Brand,
                                CarSerial = itm.CarSerial,
                                CarStruct = itm.CarStruct
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cars from Cars Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public CoCars GetByPlateNo(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.coCarsGetByPlateNo(this.Branch, this.PlateNo);
                    return (from itm in result
                            select new CoCars
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                CarType = itm.CarType,
                                CarType2 = itm.CarType2,
                                PlateNo = itm.PlateNo,
                                ChDezelDate = itm.ChDezelDate,
                                ChDezelKMeter = itm.ChDezelKMeter,
                                ChOilDate = itm.ChOilDate,
                                ChOilKMeter = itm.ChOilKMeter,
                                KMeter = itm.KMeter,
                                DriverCode = itm.DriverCode,
                                Model = itm.Model,
                                Taraz = itm.Taraz,
                                CarsType = itm.CarsType,
                                Status = itm.Status,
                                PHDate1 = itm.PHDate1,
                                PHDate2 = itm.PHDate2,
                                PHDate3 = itm.PHDate3,
                                PHDate4 = itm.PHDate4,
                                PLoc1 = itm.PLoc1,
                                PLoc2 = itm.PLoc2,
                                PLoc3 = itm.PLoc3,
                                PLoc4 = itm.PLoc4,
                                PHDate5 = itm.PHDate5,
                                PLoc5 = itm.PLoc5,
                                PLoc = itm.PLoc,
                                Brand = itm.Brand,
                                CarSerial = itm.CarSerial,
                                CarStruct = itm.CarStruct
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cars from Cars Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public CoCars GetByDriver(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.CoCarsGetByDriver(this.Branch, this.DriverCode);
                    return (from itm in result
                            select new CoCars
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                CarType = itm.CarType,
                                CarType2 = itm.CarType2,
                                PlateNo = itm.PlateNo,
                                ChDezelDate = itm.ChDezelDate,
                                ChDezelKMeter = itm.ChDezelKMeter,
                                ChOilDate = itm.ChOilDate,
                                ChOilKMeter = itm.ChOilKMeter,
                                KMeter = itm.KMeter,
                                DriverCode = itm.DriverCode,
                                Model = itm.Model,
                                Taraz = itm.Taraz,
                                CarsType = itm.CarsType,
                                Status = itm.Status,
                                PHDate1 = itm.PHDate1,
                                PHDate2 = itm.PHDate2,
                                PHDate3 = itm.PHDate3,
                                PHDate4 = itm.PHDate4,
                                PLoc1 = itm.PLoc1,
                                PLoc2 = itm.PLoc2,
                                PLoc3 = itm.PLoc3,
                                PLoc4 = itm.PLoc4,
                                PHDate5 = itm.PHDate5,
                                PLoc5 = itm.PLoc5,
                                PLoc = itm.PLoc,
                                Brand = itm.Brand,
                                CarSerial = itm.CarSerial,
                                CarStruct = itm.CarStruct
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Cars from Cars Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<CoCars> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.CoCarsGetAll();
                    return (from itm in result
                            select new CoCars
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                CarType = itm.CarType,
                                CarType2 = itm.CarType2,
                                PlateNo = itm.PlateNo,
                                ChDezelDate = itm.ChDezelDate,
                                ChDezelKMeter = itm.ChDezelKMeter,
                                ChOilDate = itm.ChOilDate,
                                ChOilKMeter = itm.ChOilKMeter,
                                KMeter = itm.KMeter,
                                DriverCode = itm.DriverCode,
                                Model = itm.Model,
                                Taraz = itm.Taraz,
                                CarsType = itm.CarsType,
                                Status = itm.Status,
                                PHDate1 = itm.PHDate1,
                                PHDate2 = itm.PHDate2,
                                PHDate3 = itm.PHDate3,
                                PHDate4 = itm.PHDate4,
                                PLoc1 = itm.PLoc1,
                                PLoc2 = itm.PLoc2,
                                PLoc3 = itm.PLoc3,
                                PLoc4 = itm.PLoc4,
                                PHDate5 = itm.PHDate5,
                                PLoc5 = itm.PLoc5,
                                PLoc = itm.PLoc,
                                Brand = itm.Brand,
                                CarSerial = itm.CarSerial,
                                CarStruct = itm.CarStruct
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cars from Cars Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<CoCars> GetAll2(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.CoCarsGetAll2();
                    return (from itm in result
                            select new CoCars
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                CarType = itm.CarType,
                                CarType2 = itm.CarType2,
                                PlateNo = itm.PlateNo,
                                ChDezelDate = itm.ChDezelDate,
                                ChDezelKMeter = itm.ChDezelKMeter,
                                ChOilDate = itm.ChOilDate,
                                ChOilKMeter = itm.ChOilKMeter,
                                KMeter = itm.KMeter,
                                DriverCode = itm.DriverCode,
                                Model = itm.Model,
                                Taraz = itm.Taraz,
                                CarsType = itm.CarsType,
                                Status = itm.Status,
                                PHDate1 = itm.PHDate1,
                                PHDate2 = itm.PHDate2,
                                PHDate3 = itm.PHDate3,
                                PHDate4 = itm.PHDate4,
                                PLoc1 = itm.PLoc1,
                                PLoc2 = itm.PLoc2,
                                PLoc3 = itm.PLoc3,
                                PLoc4 = itm.PLoc4,
                                PHDate5 = itm.PHDate5,
                                PLoc5 = itm.PLoc5,
                                PLoc = itm.PLoc,
                                Brand = itm.Brand,
                                CarSerial = itm.CarSerial,
                                CarStruct = itm.CarStruct
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select a Car from Cars Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public CoCars Find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.CoCarsGet(this.Branch, this.Code);
                    return (from itm in result
                            select new CoCars
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                CarType = itm.CarType,
                                CarType2 = itm.CarType2,
                                PlateNo = itm.PlateNo,
                                ChDezelDate = itm.ChDezelDate,
                                ChDezelKMeter = itm.ChDezelKMeter,
                                ChOilDate = itm.ChOilDate,
                                ChOilKMeter = itm.ChOilKMeter,
                                KMeter = itm.KMeter,
                                DriverCode = itm.DriverCode,
                                Model = itm.Model,
                                Taraz = itm.Taraz,
                                CarsType = itm.CarsType,
                                Status = itm.Status,
                                PHDate1 = itm.PHDate1,
                                PHDate2 = itm.PHDate2,
                                PHDate3 = itm.PHDate3,
                                PHDate4 = itm.PHDate4,
                                PLoc1 = itm.PLoc1,
                                PLoc2 = itm.PLoc2,
                                PLoc3 = itm.PLoc3,
                                PLoc4 = itm.PLoc4,
                                PHDate5 = itm.PHDate5,
                                PLoc5 = itm.PLoc5,
                                PLoc = itm.PLoc,
                                Brand = itm.Brand,
                                CarSerial = itm.CarSerial,
                                CarStruct = itm.CarStruct
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get New Code for Cars Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public string GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.CoCarsMaxCode(this.Branch);
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
