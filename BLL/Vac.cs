using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Vac
    {
        public int FNo { get; set; }
        public string FDate { get; set; }
        public string Name { get; set; }

        public Vac()
        {
            this.FNo = 0;
            this.FDate = "";
            this.Name = "";
        }

        /// <summary>
        /// Add Car in Cars Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.VacAdd(this.FDate, this.Name);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Car from Cars Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.VacDelete(this.FDate);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Car in Cars Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.VacUpdate(this.FNo, this.FDate, this.Name);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select all Cars from Cars Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<Vac> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.VacGetAll();
                    return (from itm in result
                            select new Vac
                            {
                                FNo = itm.FNo,
                                FDate = itm.FDate,
                                Name = itm.Name
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select a Car from Cars Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public Vac Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.VacGet(this.FDate);
                    return (from itm in result
                            select new Vac
                            {
                                 FNo = itm.FNo,
                                 FDate = itm.FDate,
                                 Name = itm.Name
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
