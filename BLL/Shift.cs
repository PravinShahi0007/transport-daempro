using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Shift
    {
        public int ShiftNo { get; set; }
        public string FTime { get; set; }
        public string ETime { get; set; }
        public string SFTime { get; set; }
        public string SETime { get; set; }
        public string RFTime { get; set; }
        public string RETime { get; set; }
        public System.Nullable<int> DLate { get; set; }
        public System.Nullable<int> MDLate { get; set; }
        public System.Nullable<int> MDLateNo { get; set; }
        public System.Nullable<int> YDLate { get; set; }
        public System.Nullable<int> YDLateNo { get; set; }
        public System.Nullable<int> DEarly { get; set; }
        public System.Nullable<int> MDEarly { get; set; }
        public System.Nullable<int> MDEarlyNo { get; set; }
        public System.Nullable<int> YDEarly { get; set; }
        public System.Nullable<int> YDEarlyNo { get; set; }
        public System.Nullable<int> MForget { get; set; }
        public System.Nullable<int> YForget { get; set; }
        public System.Nullable<int> Forget { get; set; }
        public System.Nullable<double> NoTime { get; set; }
        public System.Nullable<bool> ThSat { get; set; }


        public Shift()
        {
            this.ShiftNo = 0;
            this.FTime = "";
            this.ETime = "";
            this.SFTime = "";
            this.SETime = "";
            this.RFTime = "";
            this.RETime = "";
            this.DLate = 0;
            this.MDLate = 0;
            this.MDLateNo = 0;
            this.YDLate = 0;
            this.YDLateNo = 0;
            this.DEarly = 0;
            this.MDEarly = 0;
            this.MDEarlyNo = 0;
            this.YDEarly = 0;
            this.YDEarlyNo = 0;
            this.MForget = 0;
            this.YForget = 0;
            this.Forget = 0;
            this.NoTime = 0;
            this.ThSat = false;
        }

        /// <summary>
        /// Add Area in Area Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShiftInsert(this.ShiftNo, this.FTime, this.ETime, this.SFTime, this.SETime, this.RFTime, this.RETime, this.DLate, this.MDLate, this.MDLateNo, this.YDLate,
                        this.YDLateNo, this.DEarly, this.MDEarly, this.MDEarlyNo, this.YDEarly, this.YDEarlyNo, this.MForget, this.YForget, this.Forget, this.NoTime , this.ThSat);
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
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShiftDelete(this.ShiftNo);
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
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShiftUpdate(this.ShiftNo, this.FTime, this.ETime, this.SFTime, this.SETime, this.RFTime, this.RETime, this.DLate, this.MDLate, this.MDLateNo, this.YDLate,
                        this.YDLateNo, this.DEarly, this.MDEarly, this.MDEarlyNo, this.YDEarly, this.YDEarlyNo, this.MForget, this.YForget, this.Forget, this.NoTime , this.ThSat);
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
        public List<Shift> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShiftGetAll();
                    return (from itm in result
                            select new Shift
                            {
                                 ShiftNo = itm.Shift,
                                 NoTime = itm.NoTime,
                                 DEarly = itm.DEarly,
                                 DLate = itm.DLate,
                                 ETime = itm.ETime,
                                 Forget = itm.Forget,
                                 FTime = itm.FTime,
                                 MDEarly = itm.MDEarly,
                                 MDEarlyNo = itm.MDEarlyNo,
                                 MDLate = itm.MDLate,
                                 MDLateNo = itm.MDLateNo,
                                 MForget = itm.MForget,
                                 RETime = itm.RETime,
                                 RFTime = itm.RFTime,
                                 SETime = itm.SETime,
                                 SFTime = itm.SFTime,
                                 YDEarly = itm.YDEarly,
                                 YDEarlyNo = itm.YDEarlyNo,
                                 YDLate = itm.YDLate,
                                 YDLateNo = itm.YDLateNo,
                                 YForget = itm.YForget,
                                 ThSat = itm.ThSat
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
        public Shift find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.ShiftGet(this.ShiftNo);
                    return (from itm in result
                            select new Shift
                            {
                                ShiftNo = itm.Shift,
                                NoTime = itm.NoTime,
                                DEarly = itm.DEarly,
                                DLate = itm.DLate,
                                ETime = itm.ETime,
                                Forget = itm.Forget,
                                FTime = itm.FTime,
                                MDEarly = itm.MDEarly,
                                MDEarlyNo = itm.MDEarlyNo,
                                MDLate = itm.MDLate,
                                MDLateNo = itm.MDLateNo,
                                MForget = itm.MForget,
                                RETime = itm.RETime,
                                RFTime = itm.RFTime,
                                SETime = itm.SETime,
                                SFTime = itm.SFTime,
                                YDEarly = itm.YDEarly,
                                YDEarlyNo = itm.YDEarlyNo,
                                YDLate = itm.YDLate,
                                YDLateNo = itm.YDLateNo,
                                YForget = itm.YForget,
                                ThSat = itm.ThSat
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
