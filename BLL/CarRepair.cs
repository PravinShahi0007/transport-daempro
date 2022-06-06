using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class CarRepair
    {
        public string CarNo { get; set; }
        public short VouType { get; set; }
        public short LocType { get; set; }
        public short VouLoc { get; set; }
        public int VouNo { get; set; }
        public short FNo { get; set; }
        public string VouDate { get; set; }
        public string Ref { get; set; }
        public System.Nullable<short> MonthNo { get; set; }
        public System.Nullable<double> Amount { get; set; }
        public string LDate { get; set; }
        public String VouType2
        {
            get
            {
                return (this.VouType == 801 ? "أصلاح خارجي" : "سند صرف");
            }
        }

        public CarRepair()
        {
            this.CarNo = "";
            this.VouType = 0;
            this.LocType = 2;
            this.VouLoc = 0;
            this.VouNo = 0;
            this.FNo = 0;
            this.VouDate = "";
            this.Ref = "";
            this.MonthNo = 0;
            this.Amount = 0;
            this.LDate = "";
        }


        /// <summary>
        /// Add City in Cities Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CarRepairInsert(this.CarNo, this.VouType,this.LocType,this.VouLoc, this.VouNo, this.FNo, this.VouDate, this.Ref, this.MonthNo, this.Amount, this.LDate);
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
                    myContext.CarRepairDelete(this.VouType, this.LocType, this.VouLoc, this.VouNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select a Driver from Drivers Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<CarRepair> Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CarRepairGet(this.CarNo);
                    return (from itm in result
                            select new CarRepair
                            {
                                  CarNo = itm.CarNo,
                                  VouType = itm.VouType,
                                  LocType = itm.LocType,
                                  VouLoc = itm.VouLoc,
                                  VouNo = itm.VouNo,
                                  FNo = itm.FNo,
                                  VouDate = itm.VouDate,
                                  Ref = itm.Ref,
                                  MonthNo = itm.MonthNo,
                                  Amount =  itm.Amount,
                                  LDate = itm.LDate 
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
