using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class ShipUsers
    {
        public short Branch { get; set; }
        public string ID { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDNo { get; set; }
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
        public string Version { get; set; }
        public string Account { get; set; }

        public ShipUsers()
        {
            this.Branch = 1;
            this.ID = "";
            this.Password = "";
            this.FirstName = "";
            this.LastName = "";
            this.IDNo = "";
            this.MobileNo = "";
            this.UserType = 0;
            this.LoginType = 0;
            this.PLat = "0";
            this.PLong = "0";
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
            this.Account = "";
            this.Version = "";
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
                    myContext.ShipUsersAdd(MyEncryption.base64Encode(this.ID),
                                            MyEncryption.base64Encode(this.Password),
                                            this.FirstName,
                                            this.LastName,
                                            this.IDNo,
                                            this.MobileNo,
                                            this.UserType,
                                            this.LoginType,
                                            this.PLat,
                                            this.PLong,
                                            this.LocDateTime,
                                            this.Online,
                                            this.DCareType,
                                            this.DPlateNo,
                                            this.DCarModel,
                                            this.DCarColor,
                                            this.CardType,
                                            this.CardNo,
                                            this.CardName,
                                            this.CardSec,
                                            this.CardExpiry,
                                            this.InPoints,
                                            this.OutPoints,
                                            this.Account,
                                            this.Version);
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
                    myContext.ShipUsersDelete(MyEncryption.base64Encode(this.ID));
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
                    myContext.ShipUsersUpdate(MyEncryption.base64Encode(this.ID),
                                            MyEncryption.base64Encode(this.Password),
                                            this.FirstName,
                                            this.LastName,
                                            this.IDNo,
                                            this.MobileNo,
                                            this.UserType,
                                            this.LoginType,
                                            this.PLat,
                                            this.PLong,
                                            this.LocDateTime,
                                            this.Online,
                                            this.DCareType,
                                            this.DPlateNo,
                                            this.DCarModel,
                                            this.DCarColor,
                                            this.CardType,
                                            this.CardNo,
                                            this.CardName,
                                            this.CardSec,
                                            this.CardExpiry,
                                            this.InPoints,
                                            this.OutPoints,
                                            this.Account,
                                            this.Version);
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
        public bool updateLoc(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.ShipUsersUpdateLoc(MyEncryption.base64Encode(this.ID),
                                            this.PLat,
                                            this.PLong,
                                            this.LocDateTime);
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
        public bool updateOnline(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.ShipUsersUpdateOnline(MyEncryption.base64Encode(this.ID), this.Online);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


       
        public bool updateVersion(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.ShipUsersUpdateVersion(MyEncryption.base64Encode(this.ID), this.Version);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// select  Cost Acc  from CostAcc Table
        /// </summary>
        /// <returns>List of Account center or null if Fail</returns>
        public ShipUsers find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipUsersFind(MyEncryption.base64Encode(this.ID));

                    return (from itm in result
                            select new ShipUsers
                            {
                                ID = MyEncryption.base64Decode(itm.ID),
                                Password = MyEncryption.base64Decode(itm.Password),
                                FirstName = itm.FirstName,
                                LastName = itm.LastName,
                                IDNo = itm.IDNo,
                                MobileNo = itm.MobileNo,
                                UserType = itm.UserType,
                                LoginType = itm.LoginType,
                                PLat = itm.PLat,
                                PLong = itm.PLong,
                                LocDateTime = itm.LocDateTime,
                                Online = itm.Online,
                                DCareType = itm.DCareType,
                                DPlateNo = itm.DPlateNo,
                                DCarModel = itm.DCarModel,
                                DCarColor = itm.DCarColor,
                                CardType = itm.CardType,
                                CardNo = itm.CardNo,
                                CardName = itm.CardName,
                                CardSec = itm.CardSec,
                                CardExpiry = itm.CardExpiry,
                                InPoints = itm.InPoints,
                                OutPoints = itm.OutPoints,
                                Account = itm.Account,
                                Version = itm.Version
                            }).FirstOrDefault();
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
        public List<ShipUsers> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipUsersGetAll();
                    return (from itm in result
                            select new ShipUsers
                            {
                                ID = MyEncryption.base64Decode(itm.ID),
                                Password = MyEncryption.base64Decode(itm.Password),
                                FirstName = itm.FirstName,
                                LastName = itm.LastName,
                                IDNo = itm.IDNo,
                                MobileNo = itm.MobileNo,
                                UserType = itm.UserType,
                                LoginType = itm.LoginType,
                                PLat = itm.PLat,
                                PLong = itm.PLong,
                                LocDateTime = itm.LocDateTime,
                                Online = itm.Online,
                                DCareType = itm.DCareType,
                                DPlateNo = itm.DPlateNo,
                                DCarModel = itm.DCarModel,
                                DCarColor = itm.DCarColor,
                                CardType = itm.CardType,
                                CardNo = itm.CardNo,
                                CardName = itm.CardName,
                                CardSec = itm.CardSec,
                                CardExpiry = itm.CardExpiry,
                                InPoints = itm.InPoints,
                                OutPoints = itm.OutPoints,
                                Account = itm.Account,
                                Version = itm.Version
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



        public List<ShipUsers> GetAll2(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipUsersGetAll2();
                    return (from itm in result
                            select new ShipUsers
                            {
                                ID = MyEncryption.base64Decode(itm.ID),
                                Password = MyEncryption.base64Decode(itm.Password),
                                FirstName = itm.FirstName,
                                LastName = itm.LastName,
                                IDNo = itm.IDNo,
                                MobileNo = itm.MobileNo,
                                UserType = itm.UserType,
                                LoginType = itm.LoginType,
                                PLat = itm.PLat,
                                PLong = itm.PLong,
                                LocDateTime = itm.LocDateTime,
                                Online = itm.Online,
                                DCareType = itm.DCareType,
                                DPlateNo = itm.DPlateNo,
                                DCarModel = itm.DCarModel,
                                DCarColor = itm.DCarColor,
                                CardType = itm.CardType,
                                CardNo = itm.CardNo,
                                CardName = itm.CardName,
                                CardSec = itm.CardSec,
                                CardExpiry = itm.CardExpiry,
                                InPoints = itm.InPoints,
                                OutPoints = itm.OutPoints,
                                Account = itm.Account,
                                Version = itm.Version
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<ShipUsers> GetByUserType(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipUsersFindByUserType(this.UserType);
                    return (from itm in result
                            select new ShipUsers
                            {
                                ID = MyEncryption.base64Decode(itm.ID),
                                Password = MyEncryption.base64Decode(itm.Password),
                                FirstName = itm.FirstName,
                                LastName = itm.LastName,
                                IDNo = itm.IDNo,
                                MobileNo = itm.MobileNo,
                                UserType = itm.UserType,
                                LoginType = itm.LoginType,
                                PLat = itm.PLat,
                                PLong = itm.PLong,
                                LocDateTime = itm.LocDateTime,
                                Online = itm.Online,
                                DCareType = itm.DCareType,
                                DPlateNo = itm.DPlateNo,
                                DCarModel = itm.DCarModel,
                                DCarColor = itm.DCarColor,
                                CardType = itm.CardType,
                                CardNo = itm.CardNo,
                                CardName = itm.CardName,
                                CardSec = itm.CardSec,
                                CardExpiry = itm.CardExpiry,
                                InPoints = itm.InPoints,
                                OutPoints = itm.OutPoints,
                                Account = itm.Account,
                                Version = itm.Version
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<ShipUsers> GetByOnlineUserType(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipUsersFindByOnlineUserType(this.Online,this.UserType);
                    return (from itm in result
                            select new ShipUsers
                            {
                                ID = MyEncryption.base64Decode(itm.ID),
                                Password = MyEncryption.base64Decode(itm.Password),
                                FirstName = itm.FirstName,
                                LastName = itm.LastName,
                                IDNo = itm.IDNo,
                                MobileNo = itm.MobileNo,
                                UserType = itm.UserType,
                                LoginType = itm.LoginType,
                                PLat = itm.PLat,
                                PLong = itm.PLong,
                                LocDateTime = itm.LocDateTime,
                                Online = itm.Online,
                                DCareType = itm.DCareType,
                                DPlateNo = itm.DPlateNo,
                                DCarModel = itm.DCarModel,
                                DCarColor = itm.DCarColor,
                                CardType = itm.CardType,
                                CardNo = itm.CardNo,
                                CardName = itm.CardName,
                                CardSec = itm.CardSec,
                                CardExpiry = itm.CardExpiry,
                                InPoints = itm.InPoints,
                                OutPoints = itm.OutPoints,
                                Account = itm.Account,
                                Version = itm.Version
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<ShipUsers> GetByOnlineUserType2(string ConnectionStr,int cartype1)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipUsersFindByOnlineUserType(this.Online, this.UserType);
                    using (DataERPDataContext myContext2 = new DataERPDataContext(ConnectionStr))
                    {
                        var result2 = myContext2.CarsGetAll(this.Branch, cartype1);
                        List<ShipUsers> myRet = new List<ShipUsers>();
                        foreach (var itm2 in result2)
                        {
                            myRet.AddRange((from itm in result
                                            where MyEncryption.base64Decode(itm.ID) == itm2.DriverCode
                                            select new ShipUsers
                                            {
                                                ID = MyEncryption.base64Decode(itm.ID),
                                                Password = MyEncryption.base64Decode(itm.Password),
                                                FirstName = itm.FirstName,
                                                LastName = itm.LastName,
                                                IDNo = itm.IDNo,
                                                MobileNo = itm.MobileNo,
                                                UserType = itm.UserType,
                                                LoginType = itm.LoginType,
                                                PLat = itm.PLat,
                                                PLong = itm.PLong,
                                                LocDateTime = itm.LocDateTime,
                                                Online = itm.Online,
                                                DCareType = itm.DCareType,
                                                DPlateNo = itm.DPlateNo,
                                                DCarModel = itm.DCarModel,
                                                DCarColor = itm.DCarColor,
                                                CardType = itm.CardType,
                                                CardNo = itm.CardNo,
                                                CardName = itm.CardName,
                                                CardSec = itm.CardSec,
                                                CardExpiry = itm.CardExpiry,
                                                InPoints = itm.InPoints,
                                                OutPoints = itm.OutPoints,
                                                Account = itm.Account,
                                                Version = itm.Version
                                            }).ToList());
                        }
                        return myRet;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<ShipUsers> GetByOnline(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipUsersFindByOnline(this.Online);
                    return (from itm in result
                            select new ShipUsers
                            {
                                ID = MyEncryption.base64Decode(itm.ID),
                                Password = MyEncryption.base64Decode(itm.Password),
                                FirstName = itm.FirstName,
                                LastName = itm.LastName,
                                IDNo = itm.IDNo,
                                MobileNo = itm.MobileNo,
                                UserType = itm.UserType,
                                LoginType = itm.LoginType,
                                PLat = itm.PLat,
                                PLong = itm.PLong,
                                LocDateTime = itm.LocDateTime,
                                Online = itm.Online,
                                DCareType = itm.DCareType,
                                DPlateNo = itm.DPlateNo,
                                DCarModel = itm.DCarModel,
                                DCarColor = itm.DCarColor,
                                CardType = itm.CardType,
                                CardNo = itm.CardNo,
                                CardName = itm.CardName,
                                CardSec = itm.CardSec,
                                CardExpiry = itm.CardExpiry,
                                InPoints = itm.InPoints,
                                OutPoints = itm.OutPoints,
                                Account = itm.Account,
                                Version = itm.Version
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
