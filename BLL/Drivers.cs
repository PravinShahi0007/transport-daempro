using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Drivers
    {
        public short Branch { get; set; }
        public string Code { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string IqamaNo { get; set; }
        public string Sponsor { get; set; }
        public string IqamaFrom { get; set; }
        public string IqamaDate { get; set; }
        public string MobileNo { get; set; }
        public bool? Status { get; set; }
        public bool? Ajir { get; set; }
        public double? Cost { get; set; }
        public string TwegaAcc { get; set; }

        public Drivers()
        {
            this.Branch = 0;
            this.Code = "";
            this.Name1 = "";
            this.Name2 = "";
            this.IqamaNo = "";
            this.Sponsor = "";
            this.IqamaFrom = "";
            this.IqamaDate = "";
            this.MobileNo = "";
            this.Status = true;
            this.Ajir = false;
            this.Cost = 0;
            this.TwegaAcc = "-1";
        }


        /// <summary>
        /// Add Driver in Drivers Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.DriversInsert(this.Branch, this.Code, this.Name1, this.Name2, this.IqamaNo, this.Sponsor, this.IqamaFrom, this.IqamaDate, this.MobileNo, this.Status, this.Ajir, this.Cost, this.TwegaAcc);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Driver from Drivers Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.DriversDelete(this.Branch, this.Code);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Driver in Drivers Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.DriversUpdate(this.Branch, this.Code, this.Name1, this.Name2, this.IqamaNo, this.Sponsor, this.IqamaFrom, this.IqamaDate, this.MobileNo, this.Status, this.Ajir, this.Cost,this.TwegaAcc);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select all Drivers from Drivers Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<Drivers> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.DriversGetAll(this.Branch);
                    return (from itm in result
                            select new Drivers
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                IqamaDate = itm.IqamaDate,
                                IqamaFrom = itm.IqamaFrom,
                                IqamaNo = itm.IqamaNo,
                                MobileNo = itm.MobileNo,
                                Sponsor = itm.Sponsor,
                                Status = itm.Status,
                                Ajir = itm.Ajir,
                                Cost = itm.Cost,
                                TwegaAcc = itm.TwegaAcc
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Drivers from Drivers Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<Drivers> GetAll0(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.DriversGetAll(this.Branch);
                    return (from itm in result
                            where (bool)itm.Status
                            select new Drivers
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                IqamaDate = itm.IqamaDate,
                                IqamaFrom = itm.IqamaFrom,
                                IqamaNo = itm.IqamaNo,
                                MobileNo = itm.MobileNo,
                                Sponsor = itm.Sponsor,
                                Status = itm.Status,
                                Ajir = itm.Ajir,
                                Cost = itm.Cost,
                                TwegaAcc = itm.TwegaAcc
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Drivers from Drivers Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<Drivers> GetAll2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.DriversGetAll(this.Branch);
                    return (from itm in result
                            orderby itm.Name1
                            select new Drivers
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                IqamaDate = itm.IqamaDate,
                                IqamaFrom = itm.IqamaFrom,
                                IqamaNo = itm.IqamaNo,
                                MobileNo = itm.MobileNo,
                                Sponsor = itm.Sponsor,
                                Status = itm.Status,
                                Ajir = itm.Ajir,
                                Cost = itm.Cost,
                                TwegaAcc = itm.TwegaAcc 
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select a Driver from Drivers Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public Drivers Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.DriversGet(this.Branch, this.Code);
                    return (from itm in result
                            select new Drivers
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                IqamaDate = itm.IqamaDate,
                                IqamaFrom = itm.IqamaFrom,
                                IqamaNo = itm.IqamaNo,
                                MobileNo = itm.MobileNo,
                                Sponsor = itm.Sponsor,
                                Status = itm.Status,
                                Ajir = itm.Ajir,
                                Cost = itm.Cost,
                                TwegaAcc = itm.TwegaAcc
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Get New Code for Center Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public string GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.DriversMaxCode(this.Branch);
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