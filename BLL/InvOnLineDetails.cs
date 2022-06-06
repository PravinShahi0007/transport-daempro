using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    [Serializable]
    public class InvOnLineDetails
    {

        public short Branch { get; set; }
        public string VouLoc { get; set; }
        public int VouNo { get; set; }
        public short FNo { get; set; }
        public string CarType { get; set; }
        public string Brand { get; set; }
        public string PlateNo { get; set; }
        public string ChassisNo { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public double? Price { get; set; }
        public double? Price2 { get; set; }

        public InvOnLineDetails()
        {
            this.Branch = 0;
            this.VouLoc = "";
            this.VouNo = 0;
            this.FNo = 0;
            this.CarType = "-1";
            this.Brand = "";
            this.PlateNo = "";
            this.ChassisNo = "";
            this.Color = "";
            this.Model = "-1";
            this.Price = 0;
            this.Price2 = 0;            
        }

        /// <summary>
        /// Add Invoice center in Invoice Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.InvOnLineDetailsInsert(this.Branch,
                                            this.VouLoc,
                                            this.VouNo,
                                            this.FNo,
                                            this.CarType,
                                            this.Brand,
                                            this.PlateNo,
                                            this.ChassisNo,
                                            this.Color,
                                            this.Model,
                                            this.Price
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
        /// Delete Invoice center from Invoice Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.InvOnLineDetailsDelete(this.Branch, this.VouLoc, this.VouNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// select all Item Sizes from Size Table
        /// </summary>
        /// <returns>List of Item Colors or null if Fail</returns>
        public List<InvOnLineDetails> Find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.InvOnLineDetailsGet(this.Branch, this.VouLoc, this.VouNo);
                    return (from itm in result
                            select new InvOnLineDetails
                            {
                                Branch = itm.Branch,
                                VouLoc = itm.VouLoc,
                                VouNo = itm.VouNo,
                                FNo = itm.FNo,
                                CarType = itm.CarType,
                                Brand = itm.Brand,
                                PlateNo = itm.PlateNo,
                                ChassisNo = itm.ChassisNo,
                                Color = itm.Color,
                                Model = itm.Model,
                                Price = itm.Price                                
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
