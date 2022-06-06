using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class FavPlaces
    {
        public string IDUser { get; set; }
        public int FNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; } 
        public string AddDateTime { get; set; } 

        /// <summary>
        /// Add Area in Area Table
        /// </summary>
        /// <returns>True if Insert Success or False if Fail</returns>
        public bool Add(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.FavPlacesAdd(this.IDUser,this.Name, this.Address, this.Lat, this.Lng , this.AddDateTime);
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
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.FavPlacesDelete(this.IDUser, this.FNo);
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
        public List<FavPlaces> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.FavPlacesGetByUserID(this.IDUser);
                    return (from itm in result
                            select new FavPlaces
                            {
                                IDUser = itm.IDUser,
                                Name = itm.Name,
                                FNo = itm.FNo,
                                Address = itm.Address,
                                Lat = itm.Lat,
                                Lng = itm.Lng,
                                AddDateTime = itm.AddDateTime
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
    public class MyFavPlaces
    {
        public string MobileNo { get; set; }
        public int FNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string AddDateTime { get; set; }
    }

}
