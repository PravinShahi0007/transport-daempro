using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Agreement
    {
        public short FType { get; set; }
        public short LocType { get; set; }
        public short LocNumber { get; set; }
        public int Number { get; set; }
        public short FNo { get; set; }
        public System.Nullable<short> Agree { get; set; }
        public string AgreeRemark { get; set;}
        public string AgreeUser { get; set; }
        public string AgreeUserDate { get; set; }

        public Agreement()
        {           
            this.FType = 0;
            this.LocType = 0;
            this.LocNumber = 0;
            this.Number = 0;
            this.FNo = 0;
            this.Agree = 0;
            this.AgreeRemark = "";
            this.AgreeUser = "";
            this.AgreeUserDate = "";
        }

        /// <summary>
        /// Add Item in Arch Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.AgreeInsert(this.FType,this.LocType,this.LocNumber,this.Number,this.FNo,this.Agree,this.AgreeRemark,this.AgreeUser,this.AgreeUserDate);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Item in Arch Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Update(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.AgreeUpdate(this.FType, this.LocType, this.LocNumber, this.Number, this.FNo, this.Agree, this.AgreeRemark, this.AgreeUser, this.AgreeUserDate);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Item from Arch Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.AgreeDelete(this.FType, this.LocType, this.LocNumber, this.Number);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Item from Arch Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool DeleteFNo(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.AgreeDeleteFNo(this.FType, this.LocType, this.LocNumber, this.Number, this.FNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// select all Cars from MyPO Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<Agreement> Find(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.AgreeGet(this.FType, this.LocType, this.LocNumber, this.Number);
                    return (from itm in result
                            select new Agreement
                            {
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                Agree = itm.Agree,
                                AgreeRemark = itm.AgreeRemark,
                                AgreeUser = itm.AgreeUser,
                                AgreeUserDate = itm.AgreeUserDate
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Cars from MyPO Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public Agreement FindFNo(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.AgreeGetFNo(this.FType, this.LocType, this.LocNumber, this.Number,this.FNo);
                    return (from itm in result
                            select new Agreement
                            {
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                Agree = itm.Agree,
                                AgreeRemark = itm.AgreeRemark,
                                AgreeUser = itm.AgreeUser,
                                AgreeUserDate = itm.AgreeUserDate
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get New FNo for Arch Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public short? GetNewFNo(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.AgreeMaxFNo(this.FType, this.LocType, this.LocNumber, this.Number);
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