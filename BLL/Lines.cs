using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Lines
    {
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public short FNo { get; set; }
        public string CustCode { get; set; }
        public string Area1 { get; set; }
        public string Area2 { get; set; }
        public int? KM { get; set; } 
        public double? Cost { get; set; }
        public bool? Status { get; set; } 

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
                    myContext.LinesInsert(this.FromCity, this.ToCity, this.FNo, this.CustCode, this.Area1, this.Area2, this.KM, this.Cost);
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
                    myContext.LinesDelete(this.FromCity, this.ToCity, this.FNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Area in Area Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.LinesUpdate(this.FromCity, this.ToCity, this.FNo, this.CustCode, this.Area1, this.Area2, this.KM, this.Cost);
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
        public List<Lines> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.LinesGetAll(this.FromCity,this.ToCity);
                    return (from itm in result
                            select new Lines
                            {
                                Area1 = itm.Area1,
                                Area2 = itm.Area2,
                                Cost = itm.Cost,
                                CustCode = itm.CustCode,
                                FromCity = itm.FromCity,
                                FNo = itm.FNo,
                                KM = itm.KM,
                                ToCity = itm.ToCity                               
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Account center from Area Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<Lines> GetAll2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.LinesGetAll2(this.FromCity, this.ToCity);
                    return (from itm in result
                            select new Lines
                            {
                                Status = false,
                                Area1 = itm.Area1,
                                Area2 = itm.Area2,
                                Cost = itm.Cost,
                                CustCode = itm.CustCode,
                                FromCity = itm.FromCity,
                                FNo = itm.FNo,
                                KM = itm.KM,
                                ToCity = itm.ToCity
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select  Cost Acc  from CostAcc Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public Lines find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.LinesGet(this.FromCity, this.ToCity, this.FNo);
                    return (from itm in result
                            select new Lines
                            {
                                Area1 = itm.Area1,
                                Area2 = itm.Area2,
                                Cost = itm.Cost,
                                CustCode = itm.CustCode,
                                FromCity = itm.FromCity,
                                FNo = itm.FNo,
                                KM = itm.KM,
                                ToCity = itm.ToCity
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get New Code for Area Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public short? GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.LinesMaxCode(this.FromCity,this.ToCity);
                    return (from Cat in result
                            select Cat.myCode).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}

