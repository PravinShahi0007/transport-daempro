using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Promo
    {
        public short OrderType { get; set; }
        public string VouLoc { get; set; }
        public int VouNo { get; set; }
        public string GDateTime { get; set; }
        public string PromoCode { get; set; }
        public string UserName { get; set; }
        public System.Nullable<double> Discount { get; set; }
        public System.Nullable<short> DeviceType { get; set; }
        public System.Nullable<double> Amount { get; set; }

        public Promo()
        {
            this.OrderType = 0;
            this.VouLoc = "";
            this.VouNo = 0;
            this.GDateTime = "";
            this.PromoCode = "";
            this.UserName = "";
            this.Discount = 0;
            this.DeviceType = 0;
            this.Amount = 0;
        }

        /// <summary>
        /// Add Car in Cars Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    myContext.PromoCodeAdd(this.OrderType, this.VouLoc, this.VouNo, this.GDateTime, this.PromoCode, this.UserName, this.Discount, this.DeviceType, this.Amount);
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
        public int? TotalCount(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.PromoCodeCount(this.PromoCode);
                    return (from itm in result
                            select itm).ToList().Count();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cars from Cars Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<Promo> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.PromoCodeGet(this.PromoCode);
                    return (from itm in result
                            select new Promo
                            {
                               OrderType = itm.OrderType,
                               VouLoc = itm.VouLoc,
                               VouNo = itm.VouNo,
                               GDateTime = itm.GDateTime,
                               PromoCode = itm.PromoCode,
                               UserName = itm.UserName,
                               Discount = itm.Discount,
                               DeviceType = itm.DeviceType,
                               Amount = itm.Amount
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cars from Cars Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public Promo Find(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.PromoCodeGetVou(this.OrderType, this.VouLoc, this.VouNo);
                    return (from itm in result
                            select new Promo
                            {
                                OrderType = itm.OrderType,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                GDateTime = itm.GDateTime,
                                PromoCode = itm.PromoCode,
                                UserName = itm.UserName,
                                Discount = itm.Discount,
                                DeviceType = itm.DeviceType,
                                Amount = itm.Amount
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Cars from Cars Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public int? CustCount(string ConnectionStr)
        {
            try
            {
                using (DataERP2DataContext myContext = new DataERP2DataContext(ConnectionStr))
                {
                    var result = myContext.PromoCodeCountUserName(this.PromoCode,this.UserName);
                    return (from itm in result
                            select itm.Column1).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
