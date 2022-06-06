using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Payments
    {
        public string PaymentCode { get; set; }
        public string FCode { get; set; }
        public System.Nullable<short> FLevel { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public System.Nullable<bool> Online { get; set; }
        public string AppIcon { get; set; }

        public Payments()
        {
            this.PaymentCode = "";
            this.FCode = "";
            this.FLevel = 0;
            this.Name1 = "";
            this.Name2 = "";
            this.Online = false;
            this.AppIcon = "";                
        }

        /// <summary>
        /// select all Cars from Cars Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<Payments> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.PaymentsGetAll();
                    return (from itm in result
                            select new Payments
                            {
                                 PaymentCode = itm.PaymentCode,
                                 FCode = itm.FCode,
                                 FLevel = itm.FLevel,
                                 Name1 = itm.Name1,
                                 Name2 = itm.Name2,
                                 Online = itm.Online,
                                 AppIcon = itm.AppIcon
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
    public class OPayments
    {
        public string PaymentCode { get; set; }
        public string FCode { get; set; }
        public System.Nullable<short> FLevel { get; set; }
        public string Name { get; set; }
        public System.Nullable<bool> Online { get; set; }
        public string AppIcon { get; set; }

        public OPayments()
        {
            this.PaymentCode = "";
            this.FCode = "";
            this.FLevel = 0;
            this.Name = "";
            this.Online = false;
            this.AppIcon = "";
        }
    }
}
