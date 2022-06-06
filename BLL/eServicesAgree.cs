using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class eServicesAgree
    {
        public short  DocType { get; set; }
        public int    DocNo { get; set; }
        public short  FNo { get; set; }
        public short? Agree { get; set; }
        public string AgreeRemark { get; set; }
        public string AgreeUser { get; set; }
        public string AgreeUserDate { get; set; }
        public string TransferUser { get; set; }


        public eServicesAgree()
        {
            this.DocType = 0;
            this.DocNo = 0;
            this.FNo = 0;
            this.Agree = 0;
            this.AgreeRemark = "";
            this.AgreeUser = "";
            this.AgreeUserDate = "";
            this.TransferUser = "";
        }


        /// <summary>
        /// Add Area in Area Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.eServicesAgreeAdd(this.DocType, this.DocNo, this.FNo, this.Agree, this.AgreeRemark, this.AgreeUser, this.AgreeUserDate,this.TransferUser);
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
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.eServicesAgreeDelete(this.DocType, this.DocNo);
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
        public bool DeleteFNo(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.eServicesAgreeDeleteFNo(this.DocType, this.DocNo , this.FNo);
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
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.eServicesAgreeUpdate(this.DocType, this.DocNo, this.FNo, this.Agree, this.AgreeRemark, this.AgreeUser, this.AgreeUserDate, this.TransferUser);
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
        public List<eServicesAgree> find(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.eServicesAgreeGet(this.DocType, this.DocNo);
                    return (from itm in result
                            select new eServicesAgree
                            {
                                DocType = itm.DocType,
                                DocNo = itm.DocNo,
                                FNo = itm.FNo,
                                Agree = itm.Agree,
                                AgreeRemark = itm.AgreeRemark,
                                AgreeUser = itm.AgreeUser,
                                AgreeUserDate = itm.AgreeUserDate,
                                TransferUser = itm.TransferUser
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
        public eServicesAgree findFNo(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.eServicesAgreeGetFNo(this.DocType, this.DocNo,this.FNo);
                    return (from itm in result
                            select new eServicesAgree
                            {
                                DocType = itm.DocType,
                                DocNo = itm.DocNo,
                                FNo = itm.FNo,
                                Agree = itm.Agree,
                                AgreeRemark = itm.AgreeRemark,
                                AgreeUser = itm.AgreeUser,
                                AgreeUserDate = itm.AgreeUserDate,
                                TransferUser = itm.TransferUser
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
        public short? GetMaxFNo(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.eServicesAgreeGetMaxFNo(this.DocType,this.DocNo);
                    return (from Cat in result
                            select Cat.myFNo).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}

