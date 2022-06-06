using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class doAgree
    {
        public string UserName { get; set; }
        public short? FType { get; set; }
        public short? LocType { get; set; }
        public short? LocNumber { get; set; }
        public int? Number { get; set; }
        public short? FNo { get; set; }
        public string UserName2 { get; set; }
        public string UserGroup { get; set; }
        
        public doAgree()
        {
            this.UserName = "";
            this.FType = 0;
            this.LocType = 0;
            this.LocNumber = 0;
            this.Number = 0;
            this.FNo = 0;
            this.UserName2 = "";
            this.UserGroup = "";
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
                    myContext.doAgreeAdd(this.UserName,this.FType,this.LocType,this.LocNumber,this.Number,this.FNo,this.UserName2,this.UserGroup);
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
                    myContext.doAgreeDelete(this.FType, this.LocType, this.LocNumber, this.Number,this.FNo);
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
        public List<doAgree> Find(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.doAgreeGet(this.UserName,this.UserGroup);
                    return (from itm in result
                            select new doAgree
                            {
                                UserName = itm.UserName,
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
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
        public doAgree FindFNo(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.doAgreeGetFNo(this.FType,this.LocType,this.LocNumber,this.Number,this.FNo);
                    return (from itm in result
                            select new doAgree
                            {
                                UserName = itm.UserName,
                                FType = itm.FType,
                                LocType = itm.LocType,
                                LocNumber = itm.LocNumber,
                                Number = itm.Number,
                                FNo = itm.FNo,
                                UserName2 = itm.UserName2,
                                UserGroup = itm.UserGroup
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