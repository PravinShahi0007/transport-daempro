using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class AccValue
    {

        public short Branch { get; set; }
        public string FDate { get; set; }
        public string Code { get; set; }
        public System.Nullable<double> odacc { get; set; }
        public System.Nullable<double> ocacc { get; set; }
        public System.Nullable<double> Depamount { get; set;}

        public AccValue()
        {
            this.Branch = 1;
            this.FDate = "";
            this.Code = "";
            this.odacc = 0;
            this.ocacc = 0;
            this.Depamount = 0;
        }


        /// <summary>
        /// select all Branch or Stores from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public List<AccValue> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.AccValueGetAll(this.FDate);
                    return (from itm in result
                            select new AccValue
                            {
                                Branch = itm.Branch,
                                FDate = itm.FDate,
                                Code = itm.Code,
                                odacc = itm.odacc,
                                ocacc = itm.ocacc,
                                Depamount = itm.Depamount
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Branch or Stores from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public List<AccValue> GetAcc(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.AccValueGetAcc(this.Code);
                    return (from itm in result
                            select new AccValue
                            {
                                Branch = itm.Branch,
                                FDate = itm.FDate,
                                Code = itm.Code,
                                odacc = itm.odacc,
                                ocacc = itm.ocacc,
                                Depamount = itm.Depamount
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Branch or Stores from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public AccValue GetBal(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.AccValueGetBal(this.FDate,this.Code);
                    return (from itm in result
                            select new AccValue
                            {
                                Branch = itm.Branch,
                                FDate = itm.FDate,
                                Code = itm.Code,
                                odacc = itm.odacc,
                                ocacc = itm.ocacc,
                                Depamount = itm.Depamount
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all Branch or Stores from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public AccValue GetStartDate(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.AccValueGetStartDate(this.Code,this.FDate);
                    return (from itm in result
                            select new AccValue
                            {
                                Branch = itm.Branch,
                                FDate = itm.FDate,
                                Code = itm.Code,
                                odacc = itm.odacc,
                                ocacc = itm.ocacc,
                                Depamount = itm.Depamount
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
