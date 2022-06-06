using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class CoDrivers
    {

        public int ID { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string IDNo { get; set; }
        public string IDdate { get; set; }
        public string MobileNo { get; set; }
        public System.Nullable<int> Nat { get; set; }
        public string Address { get; set; }
        public System.Nullable<short> Online { get; set; }
        public System.Nullable<short> DCareType { get; set; }
        public string DPlateNo { get; set; }
        public string DCarModel { get; set; }
        public string DCarColor { get; set; }
        public System.Nullable<int> Bank { get; set; }
        public string IBan { get; set; }
        public string ATM { get; set; }
        public System.Nullable<short> TransType { get; set; }
        public System.Nullable<short> PIncome { get; set; }
        public string AccCode { get; set; }
        public string DriverCode { get; set; }

        public CoDrivers()
        {
            this.ID = 0;
            this.Name1 = "";
            this.Name2 = "";
            this.IDNo = "";
            this.IDdate = "";
            this.MobileNo = "";
            this.Nat = 0;
            this.Address = "";
            this.Online = 0;
            this.DCareType = 0;
            this.DPlateNo = "";
            this.DCarModel = "";
            this.DCarColor = "";
            this.Bank = 0;
            this.IBan = "";
            this.ATM = "";
            this.TransType = 0;
            this.AccCode = "";
            this.PIncome = 0;

        }



        /// <summary>
        /// Add Area in Area Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.CoDriversAdd(this.ID,
                                            this.Name1,
                                            this.Name2,
                                            this.IDNo,
                                            this.IDdate,
                                            this.MobileNo,
                                            this.Nat,
                                            this.Address,
                                            this.Online,
                                            this.DCareType,
                                            this.DPlateNo,
                                            this.DCarModel,
                                            this.DCarColor,
                                            this.Bank,
                                            this.IBan,
                                            this.ATM,
                                            this.TransType,
                                            this.PIncome,
                                            this.AccCode
                                             );
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Area from Area Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.CoDriversDelete(this.ID);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Area in Area Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.CoDriversUpdate(this.ID,
                                            this.Name1,
                                            this.Name2,
                                            this.IDNo,
                                            this.IDdate,
                                            this.MobileNo,
                                            this.Nat,
                                            this.Address,
                                            this.Online,
                                            this.DCareType,
                                            this.DPlateNo,
                                            this.DCarModel,
                                            this.DCarColor,
                                            this.Bank,
                                            this.IBan,
                                            this.ATM,
                                            this.TransType,
                                            this.PIncome,
                                            this.AccCode);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// select  Cost Acc  from CostAcc Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public CoDrivers Find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.CoDriversFind(this.ID);

                    return (from itm in result
                            select new CoDrivers
                            {
                                ID = itm.ID,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                IDNo = itm.IDNo,
                                IDdate = itm.IDdate,
                                MobileNo = itm.MobileNo,
                                Nat = itm.Nat,
                                Address = itm.Address,
                                Online = itm.Online,
                                DCareType = itm.DCareType,
                                DPlateNo = itm.DPlateNo,
                                DCarModel = itm.DCarModel,
                                DCarColor = itm.DCarColor,
                                Bank = itm.Bank,
                                IBan = itm.IBan,
                                ATM = itm.ATM,
                                TransType = itm.TransType,
                                PIncome = itm.PIncome,
                                AccCode = itm.AccCode
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select  Cost Acc  from CostAcc Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<CoDrivers> FindByCarType(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.CoDriversFindByDCarType(this.DCareType);

                    return (from itm in result
                            select new CoDrivers
                            {
                                ID = itm.ID,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                IDNo = itm.IDNo,
                                IDdate = itm.IDdate,
                                MobileNo = itm.MobileNo,
                                Nat = itm.Nat,
                                Address = itm.Address,
                                Online = itm.Online,
                                DCareType = itm.DCareType,
                                DPlateNo = itm.DPlateNo,
                                DCarModel = itm.DCarModel,
                                DCarColor = itm.DCarColor,
                                Bank = itm.Bank,
                                IBan = itm.IBan,
                                ATM = itm.ATM,
                                TransType = itm.TransType,
                                PIncome = itm.PIncome,
                                AccCode = itm.AccCode,
                                DriverCode = itm.ID.ToString()
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select  Cost Acc  from CostAcc Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<CoDrivers> FindByTransType(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.CoDriversFindByTransType(this.TransType);

                    return (from itm in result
                            select new CoDrivers
                            {
                                ID = itm.ID,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                IDNo = itm.IDNo,
                                IDdate = itm.IDdate,
                                MobileNo = itm.MobileNo,
                                Nat = itm.Nat,
                                Address = itm.Address,
                                Online = itm.Online,
                                DCareType = itm.DCareType,
                                DPlateNo = itm.DPlateNo,
                                DCarModel = itm.DCarModel,
                                DCarColor = itm.DCarColor,
                                Bank = itm.Bank,
                                IBan = itm.IBan,
                                ATM = itm.ATM,
                                TransType = itm.TransType,
                                PIncome = itm.PIncome,
                                AccCode = itm.AccCode
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select  Cost Acc  from CostAcc Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<CoDrivers> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.CoDriversGetAll();
                    return (from itm in result
                            select new CoDrivers
                            {
                                ID = itm.ID,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                IDNo = itm.IDNo,
                                IDdate = itm.IDdate,
                                MobileNo = itm.MobileNo,
                                Nat = itm.Nat,
                                Address = itm.Address,
                                Online = itm.Online,
                                DCareType = itm.DCareType,
                                DPlateNo = itm.DPlateNo,
                                DCarModel = itm.DCarModel,
                                DCarColor = itm.DCarColor,
                                Bank = itm.Bank,
                                IBan = itm.IBan,
                                ATM = itm.ATM,
                                TransType = itm.TransType,
                                PIncome = itm.PIncome,
                                AccCode = itm.AccCode
                            }).ToList();
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
        public int? GetMax(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.CoDriversMaxCode();
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