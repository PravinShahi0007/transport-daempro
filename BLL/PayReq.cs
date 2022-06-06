using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class PayReq
    {
        public int VouNo { get; set; }
        public string HDate { get; set; }
        public string GDate { get; set; }
        public System.Nullable<short> FType { get; set; }
        public System.Nullable<double> Amount { get; set; }
        public string Person { get; set; }
        public string Remark { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public short? Approved { get; set; }
        public string AccCode { get; set; }
        public string AccCode2 { get; set; }

        public PayReq()
        {
            this.VouNo = 0;
            this.HDate = "";
            this.GDate = "";
            this.FType = 0;
            this.Amount = 0;
            this.Person = "";
            this.Remark = "";
            this.UserName = "";
            this.UserDate = "";
            this.Approved = 0;
            this.AccCode = "";
            this.AccCode2 = "";
        }


        /// <summary>
        /// Add Shipment in Shipment Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        /// 
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.PayReqAdd(this.VouNo, this.HDate, this.GDate, this.FType, this.Amount, this.Person, this.Remark, this.UserName, this.UserDate,this.Approved,this.AccCode,this.AccCode2);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }




        /// <summary>
        /// Update Shipment in Shipment Table
        /// </summary>
        /// <returns>True if Shipment Success or False if Fail</returns>

        public bool Update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.PayReqUpdate(this.VouNo, this.HDate, this.GDate, this.FType, this.Amount, this.Person, this.Remark, this.UserName, this.UserDate, this.Approved, this.AccCode, this.AccCode2);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }




        /// <summary>
        /// Delete Shipment in Shipment Table
        /// </summary>
        /// <returns>True if Delete Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.PayReqDelete(VouNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Find Shipment in Shipment Table
        /// </summary>
        /// <returns>null</returns>
        public PayReq Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.PayReqGet(VouNo);
                    return (from sitm in result
                            select new PayReq
                            {
                                 VouNo = sitm.VouNo,
                                 Amount = sitm.Amount,
                                 FType = sitm.FType,
                                 GDate = sitm.GDate,
                                 HDate = sitm.HDate,
                                 Person = sitm.Person,
                                 Remark = sitm.Remark,
                                 UserName = sitm.UserName,
                                 UserDate = sitm.UserDate,
                                 AccCode = sitm.AccCode,
                                 Approved = sitm.Approved,
                                 AccCode2 = sitm.AccCode2
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Get New Invoice No from Invoice Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public int? GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.PayReqMaxCode();
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
