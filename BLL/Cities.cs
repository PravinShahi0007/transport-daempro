using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Cities
    {
        public short Branch { get; set; }
        public string Code { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Site { get; set; }
        public string cnn { get; set; }
        public bool? OnLine { get; set; }
        public string Site2
        {
            get
            {
                if (!string.IsNullOrEmpty(cnn) && !string.IsNullOrEmpty(this.Site) && this.Site!="-1")
                {
                    CostCenter myCostCenter = new CostCenter();
                    myCostCenter.Branch = 1;
                    myCostCenter.Code = this.Site;
                    myCostCenter = myCostCenter.find(this.cnn);
                    if (myCostCenter != null)
                    {
                        return myCostCenter.Name1;
                    }
                    else return "";
                }
                else return "";
            }
        }

        public Cities()
        {
            this.Branch = 1;
            this.Code = "";
            this.Name1 = "";
            this.Name2 = "";
            this.Site = "";
            this.cnn = "";
            this.OnLine = true;
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
                    myContext.CitiesInsert(this.Branch, this.Code, this.Name1, this.Name2 , this.Site , this.OnLine);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete City from Cities Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CitiesDelete(this.Branch, this.Code);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update city in Cities Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.CitiesUpdate(this.Branch, this.Code, this.Name1, this.Name2 , this.Site , this.OnLine);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select all cities from Cities Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<Cities> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CitiesGetAll(this.Branch);
                    return (from itm in result
                            select new Cities
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                Site = itm.Site,
                                cnn = ConnectionStr,
                                OnLine = itm.OnLine
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all cities from Cities Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<Cities> GetBySite(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CitiesFindBySite(this.Branch, this.Site);
                    return (from itm in result
                            select new Cities
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                Site = itm.Site,
                                OnLine = itm.OnLine
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Cities> GetMySites(string Site,string ConnectionStr,List<Cities> ls,List<CostCenter> lcost)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    List<Cities> lc = new List<Cities>();
                    CostCenter cs = new CostCenter();
                    cs.Branch = this.Branch;
                    cs.Code = Site;
                    cs = (from sitm in lcost
                          where sitm.Code == cs.Code
                          select sitm).FirstOrDefault();
                    if (cs != null)
                    {
                        Cities ci = new Cities();
                        ci.Branch = this.Branch;
                        ci.Code = cs.City;
                        ci = (from sitm in ls
                                  where sitm.Code == ci.Code
                                  select sitm).FirstOrDefault();

                        if (ci != null)
                        {
                            lc.Add(ci);
                            //var result = myContext.CitiesFindBySite(this.Branch, (ci.Site=="00003" ? "00009" : ci.Site));
                            lc.AddRange( (from itm in ls
                                          where itm.Site == (ci.Site == "00003" ? "00009" : ci.Site)
                                            select new Cities
                                            {
                                                Branch = itm.Branch,
                                                Code = itm.Code,
                                                Name1 = itm.Name1,
                                                Name2 = itm.Name2,
                                                Site = itm.Site,
                                                OnLine = itm.OnLine
                                            }).ToList());
                            return lc;
                        }
                        else return null;
                    }
                    else return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all cities from Cities Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<Cities> GetAll2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CitiesGetAll(this.Branch);
                    return (from itm in result
                            orderby itm.Name1
                            select new Cities
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                Site = itm.Site,
                                cnn = ConnectionStr,
                                OnLine = itm.OnLine
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all cities from Cities Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<Cities> GetAllOnLine(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CitiesGetAllOnLine(this.Branch);
                    return (from itm in result
                            orderby itm.Name1
                            select new Cities
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                Site = itm.Site,
                                cnn = ConnectionStr,
                                OnLine = itm.OnLine
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all cities from Cities Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public Cities Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CitiesFind(this.Branch,this.Code);
                    return (from itm in result
                            select new Cities
                            {
                                Branch = itm.Branch,
                                Code = itm.Code,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                Site = itm.Site,
                                cnn = ConnectionStr,
                                OnLine = itm.OnLine
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// select all cities from Cities Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public Cities Find2(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.CitiesFind2(this.Name1);
                    return (from itm in result
                            select new Cities
                            {
                 Code = itm.Code,
                                Name1 = itm.Name1,
                                 Branch = itm.Branch,
                                              Name2 = itm.Name2,
                                Site = itm.Site,
                                cnn = ConnectionStr,
                                OnLine = itm.OnLine
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
                    var result = myContext.CitiesMaxCode(this.Branch);
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
