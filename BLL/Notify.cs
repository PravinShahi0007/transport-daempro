using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
 
    [Serializable]
    public class Notify
    {

        public string MobileNo { get; set; }
        public short AppType { get; set; }
        public string FDateTime { get; set; }
        public string Msg { get; set; }


        public Notify()
        {
            this.MobileNo = "";
            this.AppType = 1;
            this.FDateTime = String.Format("{0:dd/MM/yyyy HH:mm:ss}", moh.Nows());
            this.Msg = "";
        }



        /// <summary>
        /// Add Stock Item in Item Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.NotifyInsert(this.MobileNo,this.AppType, this.FDateTime, this.Msg);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select all Branch or Stores from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public List<Notify> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.NotifyGetAll(this.MobileNo,this.AppType);
                    return (from itm in result
                            select new Notify
                            {
                                MobileNo = itm.MobileNo,
                                AppType = itm.AppType,
                                FDateTime = itm.FDateTime,
                                Msg = itm.Msg
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
