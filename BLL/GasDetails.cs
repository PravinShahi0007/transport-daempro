using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class GasDetails
    {
        public short Branch { get; set; }
        public string VouLoc { get; set; }
        public int VouNo { get; set; }
        public short FNo { get; set; }
        public string Service { get; set; }
        public string ItemCode { get; set; }
        public System.Nullable<double> Price { get; set; }
        public System.Nullable<double> SPrice { get; set; }
        public System.Nullable<short> Qty { get; set; }


        public GasDetails()
        {
            this.Branch = 1;
            this.VouLoc = "00019";
            this.VouNo = 0;
            this.FNo = 0;
            this.Service = "";
            this.ItemCode = "";
            this.Price = 0;
            this.SPrice = 0;
            this.Qty = 1;
        }



        /// <summary>
        /// Add EmergInv in EmergInv Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        /// 
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.GasDetailsInsert(this.Branch,
                                                 this.VouLoc,
                                                 this.VouNo,
                                                 this.FNo,
                                                 this.Service,
                                                 this.ItemCode,
                                                 this.Price,
                                                 this.SPrice,
                                                 this.Qty
                                                );
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete EmergInv in EmergInv Table
        /// </summary>
        /// <returns>True if Delete Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.GasDetailsDelete(this.Branch, this.VouLoc, this.VouNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }



        /// <summary>
        /// get all Shipment from Shipment Table
        /// </summary>
        /// <returns>null</returns>
        public List<GasDetails> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.GasDetailsGet(this.Branch, this.VouLoc, this.VouNo);
                    return (from Sitm in result
                            select new GasDetails
                            {
                                Branch = Sitm.Branch,
                                VouLoc = Sitm.VouLoc,
                                VouNo = Sitm.VouNo,
                                FNo = Sitm.FNo,
                                ItemCode = Sitm.ItemCode,
                                Price = Sitm.Price,
                                Qty = Sitm.Qty,
                                Service = Sitm.Service,
                                SPrice = Sitm.SPrice
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }        
}
