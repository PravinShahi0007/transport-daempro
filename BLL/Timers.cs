using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Timers
    {
        public int Code { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string LANTCPIP { get; set; }
        public string LANPort { get; set; }
        public string WANTCPIP { get; set; }
        public string WANPort { get; set; }
        public string Loc { get; set; }

        public Timers()
        {
            this.Code = 0;
            this.Name1 = "";
            this.Name2 = "";
            this.LANTCPIP = "";
            this.LANPort = "";
            this.WANTCPIP = "";
            this.WANPort = "";
            this.Loc = "";
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
                    myContext.TimersAdd(this.Code,this.Name1,this.Name2,this.LANTCPIP,this.LANPort,this.WANTCPIP,this.WANPort,this.Loc);
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
                    myContext.TimersDelete(this.Code);
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
                    myContext.TimersUpdate(this.Code, this.Name1, this.Name2, this.LANTCPIP, this.LANPort, this.WANTCPIP, this.WANPort, this.Loc);
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
        public List<Timers> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.TimersGetAll();
                    return (from itm in result
                            select new Timers
                            {
                                Code = itm.Code,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                LANPort = itm.LANPort,
                                LANTCPIP = itm.LANTCPIP,
                                Loc = itm.Loc,
                                WANPort = itm.WANPort,
                                WANTCPIP = itm.WANTCPIP
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
        public Timers find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.TimersGet(this.Code);
                    return (from itm in result
                            select new Timers
                            {
                                Code = itm.Code,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                LANPort = itm.LANPort,
                                LANTCPIP = itm.LANTCPIP,
                                Loc = itm.Loc,
                                WANPort = itm.WANPort,
                                WANTCPIP = itm.WANTCPIP
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