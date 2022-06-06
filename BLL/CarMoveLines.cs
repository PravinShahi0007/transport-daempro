using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class CarMoveLines
    {
        public short Branch { get; set; }
        public string VouLoc { get; set; }
        public int Number { get; set; }
        public short FNo { get; set; }
        public string FromLoc { get; set; }
        public string ToLoc { get; set; }
        public short? LineFNo { get; set; }
        public int? KM { get; set; }
        public double? Cost { get; set; }

        /// <summary>
        /// Add Area in Area Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CarMoveLinesInsert(this.Branch, this.VouLoc, this.Number, this.FNo, this.FromLoc, this.ToLoc, this.LineFNo, this.KM, this.Cost);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Area from Area Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CarMoveLinesDelete(this.Branch, this.VouLoc, this.Number);

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select all Account center from Area Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<CarMoveLines> find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarMoveLinesGet(this.Branch, this.VouLoc, this.Number);
                    return (from itm in result
                            select new CarMoveLines
                            {
                                 Branch = itm.Branch,
                                 Cost = itm.Cost,
                                 FNo = itm.FNo,
                                 FromLoc = itm.FromLoc,
                                 KM = itm.KM,
                                 LineFNo = itm.LineFNo,
                                 Number = itm.Number,
                                 ToLoc = itm.ToLoc,
                                 VouLoc = itm.VouLoc                                                                   
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