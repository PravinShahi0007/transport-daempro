using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class PriceList
    {
        public int VouNo { get; set; }
        public System.Nullable<short> VouType { get; set; }
        public string GDate { get; set; }
        public string HDate { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string UserName { get; set; }
        public string UserDate { get; set; }
        public Boolean? PrintTot { get; set; }

        public PriceList()
        {
            this.VouNo = 0;
            this.VouType = 0;
            this.GDate = "";
            this.HDate = "";
            this.Name = "";
            this.Subject = "";
            this.UserName = "";
            this.UserDate = "";
            this.PrintTot = true;
        }

        /// <summary>
        /// Add Item in Arch Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.PriceListInsert(this.VouNo,this.VouType,this.GDate,this.HDate,this.Name,this.Subject,this.UserName,this.UserDate,this.PrintTot);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Add Item in Arch Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Update(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.PriceListUpdate(this.VouNo, this.VouType, this.GDate, this.HDate, this.Name, this.Subject, this.UserName, this.UserDate,this.PrintTot);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Item from Arch Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.PriceListDelete(this.VouNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select all Cars from MyPO Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public PriceList Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.PriceListGet(this.VouNo);
                    return (from itm in result
                            select new PriceList
                            {
                                 GDate = itm.GDate,
                                 HDate = itm.HDate,
                                 Name = itm.Name,
                                 Subject = itm.Subject,
                                 VouNo = itm.VouNo,
                                 VouType = itm.VouType,
                                 UserDate = itm.UserDate,
                                 UserName = itm.UserName,
                                 PrintTot = itm.PrintTot
                            }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cars from MyPO Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<PriceList> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.PriceListGetAll(this.Name);
                    return (from itm in result
                            select new PriceList
                            {
                                GDate = itm.GDate,
                                HDate = itm.HDate,
                                Name = itm.Name,
                                Subject = itm.Subject,
                                VouNo = itm.VouNo,
                                VouType = itm.VouType,
                                UserDate = itm.UserDate,
                                UserName = itm.UserName,
                                PrintTot = itm.PrintTot
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// select all Cars from MyPO Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<PriceList> GetName(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.PriceListGetName();
                    return (from itm in result
                            select new PriceList
                            {
                                Name = itm.Name,
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get New FNo for Arch Table
        /// </summary>
        /// <returns>New code or null if fail</returns>
        public int? GetNewFNo(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.PriceListMaxCode();
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
    public class PriceListDetails
    {
        public int VouNo { get; set; }
        public short FNo { get; set; }
        public string CarType { get; set; }
        public string Model { get; set; }
        public System.Nullable<int> Qty { get; set; }
        public System.Nullable<double> Price { get; set; }
        public System.Nullable<double> Total { get; set; }
        public string Name { get; set; }
        public string PlaceofLoading { get; set; }
        public string Destination { get; set; }
        public string From2 { get; set; }
        public string To2 { get; set; }

        public PriceListDetails()
        {
            this.VouNo = 0;
            this.FNo = 0;
            this.CarType = "";
            this.Model = "";
            this.Qty = 0;
            this.Price = 0;
            this.Name = "";
            this.Total = 0;
            this.PlaceofLoading = "-1";
            this.Destination = "-1";
            this.From2 = "";
            this.To2 = "";
        }

        /// <summary>
        /// Add Item in Arch Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.PriceListDetailsInsert(this.VouNo, this.FNo, this.CarType, this.Model, this.Qty, this.Price, this.Name,this.PlaceofLoading,this.Destination,this.From2,this.To2);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Item from Arch Table
        /// </summary>
        /// <returns>True if Update Success or False if Fail</returns>
        public bool Delete(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    myContext.PriceListDetailsDelete(this.VouNo);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// select all Cars from MyPO Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public List<PriceListDetails> Find(string ConnectionStr)
        {
            try
            {
                using (DataERPDataContext myContext = new DataERPDataContext(ConnectionStr))
                {
                    var result = myContext.PriceListDetailsGet(this.VouNo);
                    return (from itm in result
                            select new PriceListDetails
                            {
                                 VouNo = itm.VouNo,
                                 Model = itm.Model,
                                 CarType = itm.CarType,
                                 FNo = itm.FNo,
                                 Name = itm.Name,
                                 Price = itm.Price,
                                 Qty = itm.Qty,
                                 Destination  = itm.Destination,
                                 From2 = itm.From2,
                                 PlaceofLoading = itm.PlaceofLoading,
                                 To2 = itm.To2,
                                 Total = itm.Price * itm.Qty
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
