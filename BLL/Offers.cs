using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Offers
    {
        public short Branch { get; set; }
        public int OfferNo { get; set; }
        public string FDate { get; set; }
        public string EDate { get; set; }
        public string FTime { get; set; }
        public string ETime { get; set; }
        public System.Nullable<double> Discount { get; set; }
        public System.Nullable<bool> OfferActive { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public string PromoCode { get; set; }
        public System.Nullable<bool> Amount { get; set; }
        public string InvoiceNo { get; set; }
        public string Services { get; set; }
        public string CustomerCode { get; set; }
        public string FromLoc { get; set; }
        public string ToLoc { get; set; }
        public System.Nullable<bool> FirstOrder { get; set; }
        public System.Nullable<bool> FromService { get; set; }
        public System.Nullable<bool> UseWebsite { get; set; }
        public System.Nullable<bool> UseApp { get; set; }
        public System.Nullable<bool> UseSystem { get; set; }
        public System.Nullable<int> NoofUse { get; set; }
        public System.Nullable<int> TotalofUse { get; set; }
        public string LocLat { get; set; }
        public string LocLng { get; set; }
        public System.Nullable<int> LocKM { get; set; }

        public Offers()
        {
            this.Branch = 1;
            this.OfferNo = 0;
            this.FDate = "";
            this.EDate = "";
            this.FTime = "";
            this.ETime = "";
            this.Discount = 0;
            this.OfferActive = false;
            this.UserName = "";
            this.UserDate = "";
            this.PromoCode = "";
            this.Amount = false;
            this.InvoiceNo = "";
            this.Services = "";
            this.CustomerCode = "";
            this.FromLoc = "";
            this.ToLoc = "";
            this.FirstOrder = false;
            this.FromService = false;
            this.UseWebsite = false;
            this.UseApp = false;
            this.UseSystem = false;
            this.NoofUse  = 0;
            this.TotalofUse = 0;
            this.LocLat = "";
            this.LocLng = "";
            this.LocKM = 0;
        }

        /// <summary>
        /// Add Offer in Offers Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.OffersInsert(this.Branch, this.FDate, this.EDate, this.FTime, this.ETime, this.Discount, this.OfferActive, this.UserName, this.UserDate, this.PromoCode, this.Amount, this.InvoiceNo, this.Services, this.CustomerCode, this.FromLoc, this.ToLoc, this.FirstOrder, this.FromService, this.UseWebsite, this.UseApp, this.UseSystem, this.NoofUse, this.TotalofUse, this.LocLat, this.LocLng, this.LocKM);

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Offer from Offers Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.OffersDelete(this.Branch, this.OfferNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Offer in Offers Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.OffersUpdate(this.Branch, this.OfferNo, this.FDate, this.EDate, this.FTime, this.ETime, this.Discount, this.OfferActive, this.UserName, this.UserDate, this.PromoCode, this.Amount, this.InvoiceNo, this.Services, this.CustomerCode, this.FromLoc, this.ToLoc, this.FirstOrder, this.FromService, this.UseWebsite, this.UseApp, this.UseSystem, this.NoofUse, this.TotalofUse, this.LocLat, this.LocLng, this.LocKM);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// select all Offers from Offers Table
        /// </summary>
        /// <returns>List of Item Offers or null if Fail</returns>
        public List<Offers> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.OffersGetAll(this.Branch);
                    return (from itm in result
                            select new Offers
                            {
                                Branch = itm.Branch,
                                Discount = itm.Discount,
                                EDate = itm.EDate,
                                FDate = itm.FDate,
                                OfferActive = itm.OfferActive,
                                OfferNo = itm.OfferNo,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                ETime = itm.ETime,
                                FTime = itm.FTime,
                                Amount = itm.Amount,
                                CustomerCode = itm.CustomerCode,
                                FirstOrder = itm.FirstOrder,
                                FromLoc = itm.FromLoc,
                                FromService = itm.FromService,
                                InvoiceNo = itm.InvoiceNo,
                                NoofUse = itm.NoofUse,
                                PromoCode = itm.PromoCode,
                                Services = itm.Services,
                                ToLoc = itm.ToLoc,
                                TotalofUse = itm.TotalofUse,
                                UseApp = itm.UseApp,
                                UseSystem = itm.UseSystem,
                                UseWebsite = itm.UseWebsite,
                                LocKM = itm.LocKM,
                                LocLat = itm.LocLat,
                                LocLng = itm.LocLng                                
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Find Offer from Offers Table
        /// </summary>
        /// <returns>List of Item Offers or null if Fail</returns>
        public Offers Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.OffersGet(this.Branch,this.OfferNo);
                    return (from itm in result
                            select new Offers
                            {
                                Branch = itm.Branch,
                                Discount = itm.Discount,
                                EDate = itm.EDate,
                                FDate = itm.FDate,
                                OfferActive = itm.OfferActive,
                                OfferNo = itm.OfferNo,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                ETime = itm.ETime,
                                FTime = itm.FTime,
                                Amount = itm.Amount,
                                CustomerCode = itm.CustomerCode,
                                FirstOrder = itm.FirstOrder,
                                FromLoc = itm.FromLoc,
                                FromService = itm.FromService,
                                InvoiceNo = itm.InvoiceNo,
                                NoofUse = itm.NoofUse,
                                PromoCode = itm.PromoCode,
                                Services = itm.Services,
                                ToLoc = itm.ToLoc,
                                TotalofUse = itm.TotalofUse,
                                UseApp = itm.UseApp,
                                UseSystem = itm.UseSystem,
                                UseWebsite = itm.UseWebsite,
                                LocKM = itm.LocKM,
                                LocLat = itm.LocLat,
                                LocLng = itm.LocLng
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Find Offer from Offers Table
        /// </summary>
        /// <returns>List of Item Offers or null if Fail</returns>
        public Offers FindPromoCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.OffersGetPromoCode(this.PromoCode);
                    return (from itm in result
                            select new Offers
                            {
                                Branch = itm.Branch,
                                Discount = itm.Discount,
                                EDate = itm.EDate,
                                FDate = itm.FDate,
                                OfferActive = itm.OfferActive,
                                OfferNo = itm.OfferNo,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                ETime = itm.ETime,
                                FTime = itm.FTime,
                                Amount = itm.Amount,
                                CustomerCode = itm.CustomerCode,
                                FirstOrder = itm.FirstOrder,
                                FromLoc = itm.FromLoc,
                                FromService = itm.FromService,
                                InvoiceNo = itm.InvoiceNo,
                                NoofUse = itm.NoofUse,
                                PromoCode = itm.PromoCode,
                                Services = itm.Services,
                                ToLoc = itm.ToLoc,
                                TotalofUse = itm.TotalofUse,
                                UseApp = itm.UseApp,
                                UseSystem = itm.UseSystem,
                                UseWebsite = itm.UseWebsite,
                                LocKM = itm.LocKM,
                                LocLat = itm.LocLat,
                                LocLng = itm.LocLng
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
