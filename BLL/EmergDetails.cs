using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class EmergDetails
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
        public string PickLat { get; set; }
        public string PickLong { get; set; }

        public EmergDetails()
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
            this.PickLat = "";
            this.PickLong = "";
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
                    myContext.EmergDetailsInsert(this.Branch,
                                                 this.VouLoc,
                                                 this.VouNo,
                                                 this.FNo,
                                                 this.Service,
                                                 this.ItemCode,
                                                 this.Price,
                                                 this.SPrice,
                                                 this.Qty,
                                                 this.PickLat,
                                                 this.PickLong
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
                    myContext.EmergDetailsDelete(this.Branch, this.VouLoc, this.VouNo);
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
        public List<EmergDetails> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.EmergDetailsGet(this.Branch, this.VouLoc, this.VouNo);
                    return (from Sitm in result
                            select new EmergDetails
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
                                PickLat  = Sitm.PickLat,
                                PickLong = Sitm.PickLong
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
   }

    [Serializable]
    public class OrderDetails
    {
        public short Branch { get; set; }
        public string VouLoc { get; set; }
        public int VouNo { get; set; }
        public short? FNo { get; set; }
        public string ServiceCode { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public System.Nullable<double> Price { get; set; }
        public System.Nullable<double> SPrice { get; set; }
        public System.Nullable<short> Qty { get; set; }
        public string PickLat { get; set; }
        public string PickLong { get; set; }
        public System.Nullable<double> Weight { get; set; }
        public System.Nullable<short> WeightType { get; set; }
        public System.Nullable<double> Width { get; set; }
        public System.Nullable<double> Length { get; set; }
        public System.Nullable<double> Height { get; set; }
        public System.Nullable<short> WidthType { get; set; }
        public string PlateNo { get; set; }


        public OrderDetails()
        {
            this.Branch = 1;
            this.VouLoc = "00019";
            this.VouNo = 0;
            this.FNo = 0;
            this.Brand = "";
            this.Model = "";
            this.ServiceCode = "";
            this.ItemCode = "";
            this.ItemName = "";
            this.Price = 0;
            this.SPrice = 0;
            this.Qty = 1;
            this.PickLat = "";
            this.PickLong = "";
            this.Weight = 0;
            this.WeightType = 0;
            this.Width = 0;
            this.Length = 0;
            this.Height = 0;
            this.WidthType = 0;
            this.PlateNo = "";
        }
    }

}
