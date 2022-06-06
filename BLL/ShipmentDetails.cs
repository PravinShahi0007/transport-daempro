using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class ShipmentDetails
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
        public System.Nullable<double> Weight	{ get; set; }
        public System.Nullable<short> WeightType	{ get; set; }
        public System.Nullable<double> Width	{ get; set; }
        public System.Nullable<double> Length	{ get; set; }
        public System.Nullable<double> Height	{ get; set; }
        public System.Nullable<short> WidthType { get; set; }

        public ShipmentDetails()
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
            this.Weight = 0;
            this.WeightType = 0;
            this.Width = 0;
            this.Length = 0;
            this.Height = 0;
            this.WidthType = 0;
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
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShipmentDetailsInsert(this.Branch,
                                                 this.VouLoc,
                                                 this.VouNo,
                                                 this.FNo,
                                                 this.Service,
                                                 this.ItemCode,
                                                 this.Price,
                                                 this.SPrice,
                                                 this.Qty,
                                                 this.Weight,
                                                 this.WeightType,
                                                 this.Width,
                                                 this.Length,
                                                 this.Height,
                                                 this.WidthType
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
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.ShipmentDetailsDelete(this.Branch, this.VouLoc, this.VouNo);
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
        public List<ShipmentDetails> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    //int i = 1;
                    var result = myContext.ShipmentDetailsGet(this.Branch, this.VouLoc, this.VouNo);
                    return (from Sitm in result
                            select new ShipmentDetails
                            {
                                Branch = Sitm.Branch,
                                VouLoc = Sitm.VouLoc,
                                VouNo = Sitm.VouNo,
                                FNo = Sitm.FNo,
                                ItemCode = Sitm.ItemCode,
                                Price = Sitm.Price,
                                Qty = Sitm.Qty,
                                Service = Sitm.Service,
                                SPrice = Sitm.SPrice,
                                Height = Sitm.Height,
                                Length = Sitm.Length,
                                Weight = Sitm.Weight,
                                WeightType = Sitm.WeightType,
                                Width = Sitm.Width,
                                WidthType = Sitm.WidthType                                 
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
