using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class AppServices
    {
        public string ServiceCode { get; set; }
        public string FCode { get; set; }
        public short? FLevel { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public bool? Online { get; set; }
        public string AppIcon { get; set; }
        public string Tags { get; set; }
        public string Remark1 { get; set; }
        public string Remark2 { get; set; }


        public AppServices()
        {
            this.ServiceCode = "";
            this.FCode = "";
            this.FLevel = 1;
            this.Name1 = "";
            this.Name2 = "";
            this.Online = true;
            this.AppIcon = "";
            this.Tags = "";
            this.Remark1 = "";
            this.Remark2 = "";
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
                    myContext.AppServicesAdd(this.ServiceCode,this.FCode,this.FLevel,this.Name1,this.Name2,this.Online,this.AppIcon,this.Tags,this.Remark1,this.Remark2);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete Stock Iten from Item Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.AppServicesDelete(this.ServiceCode);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Item Stock in Item Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool update(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.AppServicesUpdate(this.ServiceCode, this.FCode, this.FLevel, this.Name1, this.Name2, this.Online, this.AppIcon, this.Tags, this.Remark1, this.Remark2);
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
        public List<AppServices> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    /*
                    List<AppServices> myService = new List<AppServices>();
                    var result = myContext.AppServicesGetAll();

                    myService = (from itm in result
                                 select new AppServices
                                 {
                                     ServiceCode = itm.ServiceCode,
                                     FCode = itm.FCode,
                                     FLevel = itm.FLevel,
                                     Name1 = itm.Name1,
                                     Name2 = itm.Name2,
                                     Online = itm.Online,
                                     AppIcon = itm.AppIcon,
                                     Tags = itm.Tags,
                                     Remark1 = itm.Remark1,
                                     Remark2 = itm.Remark2
                                 }).ToList();

                    myService.Add(new AppServices
                    {
                        ServiceCode = "9",
                        FCode = "",
                        FLevel = 1,
                        Name1 = "بيان ترحيل",
                        Name2 = "Trip Note",
                        Online = true,
                        AppIcon = @"Images\Auto\home_auto.png",
                        Tags = "",
                        Remark1 = "",
                        Remark2 = ""
                    });
                     

                    return myService;
                     */
                    var result = myContext.AppServicesGetAll();
                    return (from itm in result
                            select new AppServices
                            {
                                 ServiceCode = itm.ServiceCode,
                                 FCode = itm.FCode,
                                 FLevel = itm.FLevel,
                                 Name1 = itm.Name1,
                                 Name2 = itm.Name2,
                                 Online = itm.Online,
                                 AppIcon = itm.AppIcon,
                                 Tags = itm.Tags,
                                 Remark1 = itm.Remark1,
                                 Remark2 = itm.Remark2
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
        public List<AppServices> GetAll2(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    List<AppServices> myService = new List<AppServices>();
                    var result = myContext.AppServicesGetAll();

                    myService =  (from itm in result
                            select new AppServices
                            {
                                ServiceCode = itm.ServiceCode,
                                FCode = itm.FCode,
                                FLevel = itm.FLevel,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                Online = itm.Online,
                                AppIcon = itm.AppIcon,
                                Tags = itm.Tags,
                                Remark1 = itm.Remark1,
                                Remark2 = itm.Remark2
                            }).ToList();

                    myService.Add(new AppServices {
                        ServiceCode = "9",
                        FCode = "",
                        FLevel = 1,
                        Name1 = "بيان ترحيل",
                        Name2 = "Trip Note",
                        Online = true,
                        AppIcon = @"Images\Auto\home_auto.png",
                        Tags = "",
                        Remark1 = "",
                        Remark2 = ""                                                
                    });

                    return myService;
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
        public List<AppServices> GetFCode(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.AppServicesGetFCode(this.FCode);
                    return (from itm in result
                            select new AppServices
                            {
                                ServiceCode = itm.ServiceCode,
                                FCode = itm.FCode,
                                FLevel = itm.FLevel,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                Online = itm.Online,
                                AppIcon = itm.AppIcon,
                                Tags = itm.Tags,
                                Remark1 = itm.Remark1,
                                Remark2 = itm.Remark2
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
        public List<AppServices> GetFLevel(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.AppServicesGetFLevel(this.FLevel);
                    return (from itm in result
                            select new AppServices
                            {
                                ServiceCode = itm.ServiceCode,
                                FCode = itm.FCode,
                                FLevel = itm.FLevel,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                Online = itm.Online,
                                AppIcon = itm.AppIcon,
                                Tags = itm.Tags,
                                Remark1 = itm.Remark1,
                                Remark2 = itm.Remark2
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
        public List<AppServices> Search(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.AppServicesGet2(this.Tags);
                    return (from itm in result
                            select new AppServices
                            {
                                ServiceCode = itm.ServiceCode,
                                FCode = itm.FCode,
                                FLevel = itm.FLevel,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                Online = itm.Online,
                                AppIcon = itm.AppIcon,
                                Tags = itm.Tags,
                                Remark1 = itm.Remark1,
                                Remark2 = itm.Remark2
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }




        /// <summary>
        /// select all Item Stock from Stock Table
        /// </summary>
        /// <returns>List of Coin or null if Fail</returns>
        public AppServices Find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.AppServicesGet(this.ServiceCode);
                    return (from itm in result
                            select new AppServices
                            {
                                ServiceCode = itm.ServiceCode,
                                FCode = itm.FCode,
                                FLevel = itm.FLevel,
                                Name1 = itm.Name1,
                                Name2 = itm.Name2,
                                Online = itm.Online,
                                AppIcon = itm.AppIcon,
                                Tags = itm.Tags,
                                Remark1 = itm.Remark1,
                                Remark2 = itm.Remark2
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
        public int? GetNewCode(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.AppServicesMaxCode(this.FCode);
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

    [Serializable]
    public class AppServices02
    {
        public string ServiceCode { get; set; }
        public string FCode { get; set; }
        public short? FLevel { get; set; }
        public string Name { get; set; }
        public bool? Online { get; set; }
        public string AppIcon { get; set; }
        public string Remark { get; set; }


        public AppServices02()
        {
            this.ServiceCode = "";
            this.FCode = "";
            this.FLevel = 1;
            this.Name = "";
            this.AppIcon = "";
            this.Remark = "";
        }
    }

}
