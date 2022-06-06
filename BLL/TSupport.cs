using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class TSupport
    {
        public string FDate { get; set; }
        public string FTime { get; set; }
        public string UserName { get; set; }
        public string Customer { get; set; }
        public string InvNo { get; set; }
        public string MobileNo { get; set; }
        public string PlateNo { get; set; }
        public string SType { get; set; }
        public string Reply { get; set; }
        public string Remark { get; set; }

        public TSupport()
        {
                this.FDate = "";
                this.FTime = "";
                this.UserName = "";
                this.Customer = "";
                this.InvNo = "";
                this.MobileNo = "";
                this.PlateNo = "";
                this.SType = "";
                this.Reply = "";
                this.Remark = "";
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
                    myContext.TSupportAdd(this.FDate, this.FTime, this.UserName, this.Customer, this.InvNo, this.MobileNo, this.PlateNo, this.SType, this.Reply, this.Remark);
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
                    myContext.TSupportDelete(this.FDate, this.FTime, this.UserName);
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
                    myContext.TSupportUpdate(this.FDate, this.FTime, this.UserName, this.Customer, this.InvNo, this.MobileNo, this.PlateNo, this.SType, this.Reply, this.Remark);
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
        public List<TSupport> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.TSupportGetAll(this.UserName);
                    return (from itm in result
                            select new TSupport
                            {
                                 FDate = itm.FDate,
                                 FTime = itm.FTime,
                                 UserName = itm.UserName,
                                 Customer = itm.Customer,
                                 InvNo = itm.InvNo,
                                 MobileNo = itm.MobileNo,
                                 PlateNo = itm.PlateNo,
                                 Remark = itm.Remark,
                                 Reply = itm.Reply,
                                 SType = itm.SType
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
        public List<String> GetAllUsers(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.TSupportGetUserName();
                    return (from itm in result
                            select itm.UserName).ToList();
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
        public TSupport find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.TSupportGet(this.FDate, this.FTime, this.UserName);
                    return (from itm in result
                            select new TSupport
                            {
                                FDate = itm.FDate,
                                FTime = itm.FTime,
                                UserName = itm.UserName,
                                Customer = itm.Customer,
                                InvNo = itm.InvNo,
                                MobileNo = itm.MobileNo,
                                PlateNo = itm.PlateNo,
                                Remark = itm.Remark,
                                Reply = itm.Reply,
                                SType = itm.SType
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
