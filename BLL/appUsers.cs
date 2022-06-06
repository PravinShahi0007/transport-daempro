using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class appUsers
    {
        public string ID { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MobileNo { get; set; }
		public System.Nullable<short> UserType { get; set; }
		public System.Nullable<short> LoginType { get; set; }
		public string PLat { get; set; }
		public string PLong { get; set; }
		public string LocDateTime { get; set; }
		public System.Nullable<short> Online { get; set; }
		public System.Nullable<short> DCareType { get; set; }
		public string DPlateNo { get; set; }
		public string DCarModel { get; set; }
		public string DCarColor { get; set; }
        public System.Nullable<short> CardType { get; set; }
        public string CardNo { get; set; }
        public string CardName { get; set; }
        public string CardSec { get; set; }
        public string CardExpiry { get; set; }
        public System.Nullable<int> InPoints { get; set; }
        public System.Nullable<int> OutPoints { get; set; }

        public appUsers()
        {
            this.ID = "";
		    this.Password = "";
		    this.FirstName = "";
		    this.LastName = "";
		    this.MobileNo = "";
		    this.UserType = 0;
		    this.LoginType = 0;
		    this.PLat = "";
		    this.PLong = "";
		    this.LocDateTime = "";
		    this.Online = 0;
		    this.DCareType = 0;
		    this.DPlateNo = "";
		    this.DCarModel = "";
		    this.DCarColor = "";
            this.CardType = 0;
            this.CardNo = "";
            this.CardName = "";
            this.CardSec = "";
            this.CardExpiry = "";
            this.InPoints = 0;
            this.OutPoints = 0;
        }

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
                    myContext.appUsersAdd(this.ID,this.Password,this.FirstName,this.LastName,this.MobileNo,this.UserType,this.LoginType,this.PLat,this.PLong,this.LocDateTime,this.Online,this.DCareType,this.DPlateNo,this.DCarModel,this.DCarColor,this.CardType,this.CardNo,this.CardName,this.CardSec,this.CardExpiry,this.InPoints,this.OutPoints);
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
                    myContext.appUsersDelete(this.ID);
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
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.appUsersUpdate(this.ID, this.Password, this.FirstName, this.LastName, this.MobileNo, this.UserType, this.LoginType, this.PLat, this.PLong, this.LocDateTime, this.Online, this.DCareType, this.DPlateNo, this.DCarModel, this.DCarColor, this.CardType, this.CardNo, this.CardName, this.CardSec, this.CardExpiry, this.InPoints, this.OutPoints);
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
        public bool SetOnLine(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.appUsersSetOnLine(this.ID, this.Online);
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
        public bool SetLoc(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.appUsersSetLoc(this.ID, this.PLat, this.PLong);
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
        public List<appUsers> GetOnLine(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.appUsersGetOnline(this.Online);

                    return (from itm in result
                            select new appUsers
                            {
                                 ID = itm.ID,
                                 CardExpiry = itm.CardExpiry,
                                 CardName = itm.CardName,
                                 CardNo = itm.CardNo,
                                 CardSec = itm.CardSec,
                                 CardType = itm.CardType,
                                 DCarColor = itm.DCarColor,
                                 DCareType = itm.DCareType,
                                 DCarModel = itm.DCarModel,
                                 DPlateNo = itm.DPlateNo,
                                 FirstName = itm.FirstName,
                                 InPoints = itm.InPoints,
                                 LastName = itm.LastName,
                                 LocDateTime = itm.LocDateTime,
                                 LoginType = itm.LoginType,
                                 MobileNo = itm.MobileNo,
                                 Online = itm.Online,
                                 OutPoints = itm.OutPoints,
                                 Password = itm.Password,
                                 PLat = itm.PLat,
                                 PLong = itm.PLong,
                                 UserType = itm.UserType                                  
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
        public List<appUsers> GetByUserType(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.appUsersGetByUserType(this.UserType);
                    return (from itm in result
                            select new appUsers
                            {
                                ID = itm.ID,
                                CardExpiry = itm.CardExpiry,
                                CardName = itm.CardName,
                                CardNo = itm.CardNo,
                                CardSec = itm.CardSec,
                                CardType = itm.CardType,
                                DCarColor = itm.DCarColor,
                                DCareType = itm.DCareType,
                                DCarModel = itm.DCarModel,
                                DPlateNo = itm.DPlateNo,
                                FirstName = itm.FirstName,
                                InPoints = itm.InPoints,
                                LastName = itm.LastName,
                                LocDateTime = itm.LocDateTime,
                                LoginType = itm.LoginType,
                                MobileNo = itm.MobileNo,
                                Online = itm.Online,
                                OutPoints = itm.OutPoints,
                                Password = itm.Password,
                                PLat = itm.PLat,
                                PLong = itm.PLong,
                                UserType = itm.UserType
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
        public appUsers Find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.appUsersGetByID(this.ID);
                    return (from itm in result
                            select new appUsers
                            {
                                ID = itm.ID,
                                CardExpiry = itm.CardExpiry,
                                CardName = itm.CardName,
                                CardNo = itm.CardNo,
                                CardSec = itm.CardSec,
                                CardType = itm.CardType,
                                DCarColor = itm.DCarColor,
                                DCareType = itm.DCareType,
                                DCarModel = itm.DCarModel,
                                DPlateNo = itm.DPlateNo,
                                FirstName = itm.FirstName,
                                InPoints = itm.InPoints,
                                LastName = itm.LastName,
                                LocDateTime = itm.LocDateTime,
                                LoginType = itm.LoginType,
                                MobileNo = itm.MobileNo,
                                Online = itm.Online,
                                OutPoints = itm.OutPoints,
                                Password = itm.Password,
                                PLat = itm.PLat,
                                PLong = itm.PLong,
                                UserType = itm.UserType
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
