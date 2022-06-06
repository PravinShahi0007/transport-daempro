using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class TripLog
    {
        public short Branch { get; set; }
        public string VouLoc { get; set; }
        public int VouNo { get; set; }
        public System.Nullable<int> FNo { get; set; }
        public System.Nullable<short> FType { get; set; }
        public string DriverId { get; set; }
        public string FDate { get; set; }
        public string FTime { get; set; }
        public System.Nullable<short> ActType { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Number { 
            get {
                return int.Parse(this.VouLoc).ToString() + "/" + this.VouNo.ToString();        
                }    
        }
        public string FDateTime
        {
            get
            {
                return this.FDate + " " + this.FTime;
            }

        }

        public TripLog()
        {
            this.Branch = 1;
            this.VouLoc = "";
            this.VouNo = 0;
            this.FNo = 0;
            this.FType = 0;
            this.DriverId = "";
            this.FDate = "";
            this.FTime = "";
            this.ActType = 0;
            this.Lat = "";
            this.Lng = "";
        }

        /// <summary>
        /// Add Trip in TripLog Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.TripLogAdd(this.Branch, this.VouLoc, this.VouNo, this.FNo, this.FType, this.DriverId, this.FDate, this.FTime, this.ActType,this.Lat,this.Lng);
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
                    myContext.TripLogGetDelete(this.Branch, this.VouLoc, this.VouNo, this.FNo);
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
                    myContext.TripLogUpdate(this.Branch, this.VouLoc, this.VouNo, this.FNo, this.FType, this.DriverId, this.FDate, this.FTime, this.ActType, this.Lat, this.Lng);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// select all Account center from Area Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<TripLog> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.TripLogGetall();
                    return (from itm in result
                            select new TripLog
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                FNo = itm.FNo,
                                FType = itm.FType,
                                DriverId = itm.DriverId,
                                FDate = itm.FDate,
                                FTime = itm.FTime,
                                ActType = itm.ActType,
                                Lat = itm.Lat,
                                Lng = itm.Lng
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Account center from Area Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<TripLog> GetAllByFDate(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.TripLogGetByFDate(this.FDate);
                    return (from itm in result
                            select new TripLog
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                FNo = itm.FNo,
                                FType = itm.FType,
                                DriverId = itm.DriverId,
                                FDate = itm.FDate,
                                FTime = itm.FTime,
                                ActType = itm.ActType,
                                Lat = itm.Lat,
                                Lng = itm.Lng
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Account center from Area Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<TripLog> GetAllFDate(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.TripLogGetFDate();
                    return (from itm in result
                            select new TripLog
                            {
                                FDate = itm.FDate,
                                FTime = itm.mDate
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
        public List<TripLog> GetByDriverID(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.TripLogGetbyDriverId(this.DriverId);
                    return (from itm in result
                            select new TripLog
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                FNo = itm.FNo,
                                FType = itm.FType,
                                DriverId = itm.DriverId,
                                FDate = itm.FDate,
                                FTime = itm.FTime,
                                ActType = itm.ActType,
                                Lat = itm.Lat,
                                Lng = itm.Lng
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
        public List<TripLog> GetByDriverID2(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.TripLogGetbyDriverId2(this.Branch, this.VouLoc, this.VouNo, this.DriverId, this.FDate);
                    return (from itm in result
                            select new TripLog
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                FNo = itm.FNo,
                                FType = itm.FType,
                                DriverId = itm.DriverId,
                                FDate = itm.FDate,
                                FTime = itm.FTime,
                                ActType = itm.ActType,
                                Lat = itm.Lat,
                                Lng = itm.Lng
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
        public List<TripLog> GetByDriverIDFType(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.TripLogGetbyDriverIdFType(this.DriverId,this.FType);
                    return (from itm in result
                            select new TripLog
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                FNo = itm.FNo,
                                FType = itm.FType,
                                DriverId = itm.DriverId,
                                FDate = itm.FDate,
                                FTime = itm.FTime,
                                ActType = itm.ActType,
                                Lat = itm.Lat,
                                Lng = itm.Lng
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
        public TripLog find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.TripLogGet(this.Branch, this.VouLoc, this.VouNo);
                    return (from itm in result
                            select new TripLog
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                FNo = itm.FNo,
                                FType = itm.FType,
                                DriverId = itm.DriverId,
                                FDate = itm.FDate,
                                FTime = itm.FTime,
                                ActType = itm.ActType,
                                Lat = itm.Lat,
                                Lng = itm.Lng
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
        public int? GetNewFNum(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.TripLogGetMaxFNum(this.Branch, this.VouLoc, this.VouNo);
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
