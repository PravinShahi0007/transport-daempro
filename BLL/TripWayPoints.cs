using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class TripWayPoints
    {
        public string ID { get; set; }
        public int FNo { get; set; }
        public string LocDateTime { get; set; }
        public string PLat { get; set; }
        public string PLong { get; set; }
        public string VouLoc { get; set; }
        public System.Nullable<int> VouNo { get; set; }
        public System.Nullable<short> VouType { get; set; }
        public string CarNo { get; set; }


        public TripWayPoints()
        {
            this.ID = "";
            this.FNo = 0;
            this.LocDateTime = "";
            this.PLat = "0";
            this.PLong = "0";
            this.VouLoc = "";
            this.VouNo = 0;
            this.VouType = 0;
            this.CarNo = "0";
           
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
                    myContext.TripWayPointsInsert(
                                            this.ID,
                                            this.LocDateTime,
                                            this.PLat,
                                            this.PLong,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.VouType,
                                            this.CarNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Add Area in Area Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Update(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.TripWayPointsUpdate(
                                            this.ID,
                                            this.FNo,
                                            this.LocDateTime,
                                            this.PLat,
                                            this.PLong,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.VouType,
                                            this.CarNo);
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
                    myContext.TripWayPointsDelete(this.ID,this.FNo);
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
        public TripWayPoints find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.TripWayPointsFind(this.ID, this.FNo);

                    return (from itm in result
                            select new TripWayPoints
                            {
                                ID = itm.ID,
                                FNo = itm.FNo,
                                PLat = itm.PLat,
                                PLong = itm.PLong,
                                LocDateTime = itm.LocDateTime,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
                                CarNo = itm.CarNo

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
        public List<TripWayPoints> find2(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.TripWayPointsFind2(this.ID,this.LocDateTime,this.CarNo,this.VouLoc,this.VouNo);

                    return (from itm in result
                            select new TripWayPoints
                            {
                                ID = itm.ID,
                                FNo = itm.FNo,
                                PLat = itm.PLat,
                                PLong = itm.PLong,
                                LocDateTime = itm.LocDateTime,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
                                CarNo = itm.CarNo
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
        public List<TripWayPoints> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.TripWayPointsGetall();
                    return (from itm in result
                            select new TripWayPoints
                            {
                                ID = itm.ID,
                                FNo = itm.FNo,
                                PLat = itm.PLat,
                                PLong = itm.PLong,
                                LocDateTime = itm.LocDateTime,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
                                CarNo = itm.CarNo
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
        public List<TripWayPoints> GetAll2(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.TripWayPointsGetall2();
                    return (from itm in result
                            select new TripWayPoints
                            {
                                ID = itm.ID,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
                                CarNo = itm.CarNo,
                                LocDateTime = itm.ID.ToString() + " " + itm.FDate.ToString().Substring(0,10) + " " + itm.CarNo + " " + int.Parse(itm.VouLoc).ToString()+"/"+itm.VouNo.ToString()
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
        public List<TripWayPoints> GetByID(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.TripWayPointsGetbyID(this.ID);
                    return (from itm in result
                            select new TripWayPoints
                            {
                                ID = itm.ID,
                                FNo = itm.FNo,
                                PLat = itm.PLat,
                                PLong = itm.PLong,
                                LocDateTime = itm.LocDateTime,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
                                CarNo = itm.CarNo
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
        public TripWayPoints GetLastID(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.TripWayPointsGetLastID(this.ID);

                    return (from itm in result
                            select new TripWayPoints
                            {
                                ID = itm.ID,
                                FNo = itm.FNo,
                                PLat = itm.PLat,
                                PLong = itm.PLong,
                                LocDateTime = itm.LocDateTime,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
                                CarNo = itm.CarNo

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
