using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Support
    {
        public int ID { get; set; }
        public short ReplyNum { get; set; }
        public string SenderID { get; set; }
        public string EmpID { get; set; }
        public string SDateTime { get; set; } // for test
        public string SContent { get; set; }
        public short? FStatus { get; set; }

        public Support()
		{
			this.ID = 0;
			this.ReplyNum = 0;
			this.SenderID = "";
			this.EmpID = "";
			this.SDateTime = "";
			this.SContent = "";
			this.FStatus = 0;
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
                    myContext.SupportAdd(this.ID, this.ReplyNum, this.SenderID, this.EmpID, this.SDateTime, this.SContent, this.FStatus);
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
                    myContext.SupportDelete(this.ID);
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
                    myContext.SupportUpdate(this.ID, this.ReplyNum, this.SenderID, this.EmpID, this.SDateTime, this.SContent, this.FStatus);
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
        public List<Support> FindByFStatus(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.SupportFindByFStatus(this.FStatus);
                    return (from itm in result
                            select new Support
                            {
                                 EmpID = itm.EmpId,
                                 FStatus = itm.FStatus,
                                 ID = itm.ID,
                                 ReplyNum = itm.ReplyNum,
                                 SContent = itm.SContent,
                                 SDateTime = itm.SDateTime,
                                 SenderID = itm.SenderId
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
        public List<Support> FindBySenderID(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.SupportFindBySenderID(this.SenderID);
                    return (from itm in result
                            select new Support
                            {
                                EmpID = itm.EmpId,
                                FStatus = itm.FStatus,
                                ID = itm.ID,
                                ReplyNum = itm.ReplyNum,
                                SContent = itm.SContent,
                                SDateTime = itm.SDateTime,
                                SenderID = itm.SenderId
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
        public List<Support> FindByEmpID(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.SupportFindByEmpID(this.EmpID);
                    return (from itm in result
                            select new Support
                            {
                                EmpID = itm.EmpId,
                                FStatus = itm.FStatus,
                                ID = itm.ID,
                                ReplyNum = itm.ReplyNum,
                                SContent = itm.SContent,
                                SDateTime = itm.SDateTime,
                                SenderID = itm.SenderId
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
        public Support find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.SupportFind(this.ID);
                    return (from itm in result
                            select new Support
                            {
                                EmpID = itm.EmpId,
                                FStatus = itm.FStatus,
                                ID = itm.ID,
                                ReplyNum = itm.ReplyNum,
                                SContent = itm.SContent,
                                SDateTime = itm.SDateTime,
                                SenderID = itm.SenderId
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
        public int? GetNewID(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.SupportGetMax();
                    return (from Cat in result
                            select Cat.myCode).FirstOrDefault();
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
        public short? GetNewNum(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.SupportGetMaxNum(this.ID);
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
