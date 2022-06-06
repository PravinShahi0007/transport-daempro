using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Tech
    {
        public int Code { get; set; }
        public string AccountAcc { get; set; }
        public string Name { get; set; }
		public string Name2 { get; set; }
		public System.Nullable<int> Job { get; set; }
		public System.Nullable<double> HourRate { get; set; }
        public bool?  Formen { get; set; }
		public string MobileNo { get; set; }
		public string Remark { get; set; }

        public Tech()
        {
            this.Code = 0;
            this.AccountAcc = "-1";
            this.Name = "";
            this.Name2 = "";
            this.Job = -1;
            this.HourRate = 0;
            this.MobileNo = "";
            this.Remark = "";
            this.Formen = false;
        }

        /// <summary>
        /// Add Car in Cars Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.TechInsert(this.Code, this.AccountAcc, this.Name, this.Name2, this.Job, this.HourRate, this.MobileNo, this.Remark);
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
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.TechDelete(this.Code);
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
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.TechUpdate(this.Code, this.AccountAcc, this.Name, this.Name2, this.Job, this.HourRate, this.MobileNo, this.Remark);
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
        public List<Tech> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.TechGetAll();
                    return (from itm in result
                            select new Tech
                            {
                               AccountAcc = itm.AccAccount,
                               Code = itm.Code,
                               HourRate = itm.HourRate,
                               Job = itm.Job,
                               MobileNo = itm.MobileNo,
                               Name = itm.Name,
                               Name2 = itm.Name2,
                               Remark = itm.Remark,
                               Formen = itm.Formen
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
        public Tech Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.TechGet(this.Code);
                    return (from itm in result
                            select new Tech
                            {
                                 AccountAcc = itm.AccAccount,
                                 Code = itm.Code,
                                 HourRate = itm.HourRate,
                                 Job = itm.Job,
                                 MobileNo = itm.MobileNo,
                                 Name = itm.Name,
                                 Name2 = itm.Name2,
                                 Remark = itm.Remark,
                                 Formen = itm.Formen
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
        public int? GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.TechMaxCode();
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