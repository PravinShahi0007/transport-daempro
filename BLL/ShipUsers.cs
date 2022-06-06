using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    [Serializable]
    public class Device
    {
        public string device_mac { get; set; }
        public string device_label { get; set; }
        public string device_os_version { get; set; }
        public string device_name { get; set; }
        public string one_signal_id { get; set; }
        public string fire_base_id { get; set; }
        public string device_type { get; set; }
        public string app_version { get; set; }
        public System.Nullable<bool> login_status { get; set; }
        public Device()
        {
            this.one_signal_id = "";
            this.device_mac = "";
            this.device_label = "";
            this.device_os_version = "";
            this.device_name = "";
            this.fire_base_id = "";
            this.device_type = "";
            this.app_version = "";
            this.login_status = false;
        }
    }

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
        public System.Nullable<int> Num { get; set; }
        public System.Nullable<double> InPoints { get; set; }
        public System.Nullable<double> OutPoints { get; set; }
        public System.Nullable<double> Bal
        {
            get
            {
                return Math.Round((double)(this.InPoints - this.OutPoints),2);
            }
        }
        public double? MyRate
        {

            get
            {
                if (this.TRate > 0) return Math.Round((double)((this.Rate / this.TRate)), 2);
                else return 0;
            }

        }
        public string Version { get; set; }
        public string Account { get; set; }
        public string OrdID { get; set; }
        public string OrdTemp { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public string Photo { get; set; }
        public string Status { get; set; }
        public string ILang { get; set; }
        public string OTP { get; set; }
        public int? Rate { get; set; }
        public int? TRate { get; set; }
        public string Imagebase64 { get; set; }
        public string ImageFileName { get; set; }
        public Device Current_Device { get; set;}
        public string CountryCode { get; set; }
        public double? odacc { get; set; }
        public double? ocacc { get; set; }
        public double? dacc { get; set; }
        public double? cacc { get; set; }

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
            this.OrdID = "";
            this.OrdTemp = "";
            this.Email = "";
            this.AccessToken = "";
            this.Photo = "";
            this.Status = "";
            this.ILang = "En";
            this.OTP = "";
            this.Rate = 0;
            this.TRate = 0;
            this.Num = 0;
            this.Imagebase64 = "";
            this.ImageFileName = "";
            this.Current_Device = new Device();
            this.CountryCode = "";
            this.odacc = 0;
            this.ocacc = 0;
            this.dacc = 0;
            this.cacc = 0;

            /*
            this.Current_Device.one_signal_id = "";
            this.Current_Device.device_mac = "";
            this.Current_Device.device_label = "";
            this.Current_Device.device_os_version = "";
            this.Current_Device.device_name = "";
            this.Current_Device.fire_base_id = "";
            this.Current_Device.device_type = "";
            this.Current_Device.app_version = "";
            this.Current_Device.login_status = false;
             */
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
                                            this.Version,
                                            this.OrdID,
                                            this.OrdTemp,
                                            this.Email,this.AccessToken,this.Photo,this.ILang,this.Rate,this.TRate,
                                            this.Current_Device.device_mac,
                                            this.Current_Device.device_label,
                                            this.Current_Device.device_os_version,
                                            this.Current_Device.device_name,
                                            this.Current_Device.fire_base_id,
                                            this.Current_Device.one_signal_id,
                                            this.Current_Device.device_type,
                                            this.Current_Device.app_version,
                                            this.Current_Device.login_status,this.CountryCode,this.odacc,this.ocacc,this.dacc,this.cacc);
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
                                            this.Version,
                                            this.OrdID,
                                            this.OrdTemp,
                                            this.Email, this.AccessToken, this.Photo,this.ILang,this.Rate,this.TRate,
                                            this.Current_Device.device_mac,
                                            this.Current_Device.device_label,
                                            this.Current_Device.device_os_version,
                                            this.Current_Device.device_name,
                                            this.Current_Device.fire_base_id,
                                            this.Current_Device.one_signal_id,
                                            this.Current_Device.device_type,
                                            this.Current_Device.app_version,
                                            this.Current_Device.login_status, this.CountryCode, this.odacc, this.ocacc, this.dacc, this.cacc);

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
        public bool updateLang(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.ShipUsersUpdateLang(MyEncryption.base64Encode(this.ID),this.ILang);
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
        public bool UpdateOrders(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.ShipUsersUpdateOrders(MyEncryption.base64Encode(this.ID),this.OrdID,this.OrdTemp);
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
        public bool UpdateDevice(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.ShipUsersUpdateInfo2(MyEncryption.base64Encode(this.ID),
                                            this.Current_Device.device_mac,
                                            this.Current_Device.device_label,
                                            this.Current_Device.device_os_version,
                                            this.Current_Device.device_name,
                                            this.Current_Device.fire_base_id,
                                            this.Current_Device.one_signal_id,
                                            this.Current_Device.device_type,
                                            this.Current_Device.app_version,
                                            this.Current_Device.login_status);
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
        public bool UpdateOrdID(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.ShipUsersUpdateOrdID(MyEncryption.base64Encode(this.ID), this.OrdID);
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
        public bool UpdateOrdTemp(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.ShipUsersUpdateOrdTemp(MyEncryption.base64Encode(this.ID), this.OrdTemp);
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
                    //var result = myContext.ShipUsersFind(MyEncryption.base64Encode(this.ID));
                    var result = myContext.ShipUsersFind(this.ID);

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
                                Photo = itm.Photo,                               
                                Online = itm.Online,
                                DCareType = itm.DCareType,
                                DPlateNo = itm.DPlateNo,
                                DCarModel = itm.DCarModel,
                                DCarColor = itm.DCarColor,
                                CardType = itm.CardType,
                                Num = itm.Num,
                                CardNo = itm.CardNo,
                                CardName = itm.CardName,
                                CardSec = itm.CardSec,
                                CardExpiry = itm.CardExpiry,
                                InPoints = itm.InPoints,
                                OutPoints = itm.OutPoints,
                                Account = itm.Account,
                                Version = itm.Version,
                                OrdID = itm.OrdID,
                                OrdTemp = itm.OrdTemp,
                                Email = itm.Email,
                                AccessToken = itm.AccessToken,
                                CountryCode = itm.CountryCode,
                                Current_Device = new Device{
                                        one_signal_id = itm.one_signal_id,
                                        app_version = itm.app_version,
                                        device_label = itm.device_label,
                                        device_mac = itm.device_mac,
                                        device_name = itm.device_name,
                                        device_os_version = itm.device_os_version,
                                        device_type = itm.device_type,
                                        fire_base_id = itm.fire_base_id,
                                        login_status = itm.login_status                                 
                                },
                                ILang = itm.ILang,
                                Rate = itm.Rate,
                                TRate = itm.TRate,
                                odacc = itm.Odacc,
                                ocacc = itm.Ocacc,
                                dacc = itm.dacc,
                                cacc = itm.cacc
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
        public ShipUsers findbyToken(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipUsersFindByToken(this.AccessToken);

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
                                Num = itm.Num,
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
                                Version = itm.Version,
                                OrdID = itm.OrdID,
                                OrdTemp = itm.OrdTemp,
                                Email = itm.Email,
                                AccessToken = itm.AccessToken,
                                Photo = itm.Photo,
                                ILang = itm.ILang,
                                Rate = itm.Rate,
                                TRate = itm.TRate,
                                CountryCode = itm.CountryCode,
                                odacc = itm.Odacc,
                                ocacc = itm.Ocacc,
                                dacc = itm.dacc,
                                cacc = itm.cacc,                               
                                Current_Device = new Device
                                {
                                    one_signal_id = itm.one_signal_id,
                                    app_version = itm.app_version,
                                    device_label = itm.device_label,
                                    device_mac = itm.device_mac,
                                    device_name = itm.device_name,
                                    device_os_version = itm.device_os_version,
                                    device_type = itm.device_type,
                                    fire_base_id = itm.fire_base_id,
                                    login_status = itm.login_status
                                }
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
        public ShipUsers findByMobileNo(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipUsersFindByMobileNo(this.MobileNo);

                    return (from itm in result
                            select new ShipUsers
                            {
                                ID = MyEncryption.base64Decode(itm.ID),
                                Password = MyEncryption.base64Decode(itm.Password),
                                FirstName = itm.FirstName,
                                LastName = itm.LastName,
                                IDNo = itm.IDNo,
                                Num = itm.Num,
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
                                Version = itm.Version,
                                OrdID = itm.OrdID,
                                OrdTemp = itm.OrdTemp,
                                Email = itm.Email,
                                AccessToken = itm.AccessToken,
                                Photo = itm.Photo,
                                ILang = itm.ILang,
                                Rate = itm.Rate,
                                TRate = itm.TRate,
                                CountryCode = itm.CountryCode,
                                odacc = itm.Odacc,
                                ocacc = itm.Ocacc,
                                dacc = itm.dacc,
                                cacc = itm.cacc,
                                Current_Device = new Device
                                {
                                    one_signal_id = itm.one_signal_id,
                                    app_version = itm.app_version,
                                    device_label = itm.device_label,
                                    device_mac = itm.device_mac,
                                    device_name = itm.device_name,
                                    device_os_version = itm.device_os_version,
                                    device_type = itm.device_type,
                                    fire_base_id = itm.fire_base_id,
                                    login_status = itm.login_status
                                }
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
        public ShipUsers findByEmail(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipUsersFindByEmail(this.Email);
                    return (from itm in result
                            select new ShipUsers
                            {
                                ID = MyEncryption.base64Decode(itm.ID),
                                Password = MyEncryption.base64Decode(itm.Password),
                                FirstName = itm.FirstName,
                                LastName = itm.LastName,
                                IDNo = itm.IDNo,
                                Num = itm.Num,
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
                                Version = itm.Version,
                                OrdID = itm.OrdID,
                                OrdTemp = itm.OrdTemp,
                                Email = itm.Email,
                                AccessToken = itm.AccessToken,
                                Photo = itm.Photo,
                                ILang = itm.ILang,
                                Rate = itm.Rate,
                                TRate = itm.TRate,
                                CountryCode = itm.CountryCode,
                                odacc = itm.Odacc,
                                ocacc = itm.Ocacc,
                                dacc = itm.dacc,
                                cacc = itm.cacc,
                                Current_Device = new Device
                                {
                                    one_signal_id = itm.one_signal_id,
                                    app_version = itm.app_version,
                                    device_label = itm.device_label,
                                    device_mac = itm.device_mac,
                                    device_name = itm.device_name,
                                    device_os_version = itm.device_os_version,
                                    device_type = itm.device_type,
                                    fire_base_id = itm.fire_base_id,
                                    login_status = itm.login_status
                                }
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
        public ShipUsers findByAccessToken(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipUsersFindByAccessToken(this.AccessToken);
                    return (from itm in result
                            select new ShipUsers
                            {
                                ID = MyEncryption.base64Decode(itm.ID),
                                Password = MyEncryption.base64Decode(itm.Password),
                                FirstName = itm.FirstName,
                                LastName = itm.LastName,
                                IDNo = itm.IDNo,
                                Num = itm.Num,
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
                                Version = itm.Version,
                                OrdID = itm.OrdID,
                                OrdTemp = itm.OrdTemp,
                                Email = itm.Email,
                                AccessToken = itm.AccessToken,
                                Photo = itm.Photo,
                                ILang = itm.ILang,
                                Rate = itm.Rate,
                                TRate = itm.TRate,
                                odacc = itm.Odacc,
                                ocacc = itm.Ocacc,
                                dacc = itm.dacc,
                                cacc = itm.cacc,
                                CountryCode = itm.CountryCode,
                                Current_Device = new Device
                                {
                                    one_signal_id = itm.one_signal_id,
                                    app_version = itm.app_version,
                                    device_label = itm.device_label,
                                    device_mac = itm.device_mac,
                                    device_name = itm.device_name,
                                    device_os_version = itm.device_os_version,
                                    device_type = itm.device_type,
                                    fire_base_id = itm.fire_base_id,
                                    login_status = itm.login_status
                                }
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
        public ShipUsers findByOneSignalToken(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipUsersFindByOneSignalToken(this.Current_Device.one_signal_id);
                    return (from itm in result
                            select new ShipUsers
                            {
                                ID = MyEncryption.base64Decode(itm.ID),
                                Password = MyEncryption.base64Decode(itm.Password),
                                FirstName = itm.FirstName,
                                LastName = itm.LastName,
                                IDNo = itm.IDNo,
                                Num = itm.Num,
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
                                Version = itm.Version,
                                OrdID = itm.OrdID,
                                OrdTemp = itm.OrdTemp,
                                Email = itm.Email,
                                AccessToken = itm.AccessToken,
                                Photo = itm.Photo,
                                ILang = itm.ILang,
                                Rate = itm.Rate,
                                TRate = itm.TRate,
                                CountryCode = itm.CountryCode,
                                odacc = itm.Odacc,
                                ocacc = itm.Ocacc,
                                dacc = itm.dacc,
                                cacc = itm.cacc,
                                Current_Device = new Device
                                {
                                    one_signal_id = itm.one_signal_id,
                                    app_version = itm.app_version,
                                    device_label = itm.device_label,
                                    device_mac = itm.device_mac,
                                    device_name = itm.device_name,
                                    device_os_version = itm.device_os_version,
                                    device_type = itm.device_type,
                                    fire_base_id = itm.fire_base_id,
                                    login_status = itm.login_status
                                }
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
                                Num = itm.Num,
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
                                Version = itm.Version,
                                OrdID = itm.OrdID,
                                OrdTemp = itm.OrdTemp,
                                Email = itm.Email,
                                AccessToken = itm.AccessToken,
                                Photo = itm.Photo,
                                ILang = itm.ILang,
                                Rate = itm.Rate,
                                TRate = itm.TRate,
                                CountryCode = itm.CountryCode,
                                odacc = itm.Odacc,
                                ocacc = itm.Ocacc,
                                dacc = itm.dacc,
                                cacc = itm.cacc,
                                Current_Device = new Device
                                {
                                    one_signal_id = itm.one_signal_id,
                                    app_version = itm.app_version,
                                    device_label = itm.device_label,
                                    device_mac = itm.device_mac,
                                    device_name = itm.device_name,
                                    device_os_version = itm.device_os_version,
                                    device_type = itm.device_type,
                                    fire_base_id = itm.fire_base_id,
                                    login_status = itm.login_status
                                }
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
                                Num = itm.Num,
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
                                Version = itm.Version,
                                OrdID = itm.OrdID,
                                OrdTemp = itm.OrdTemp,
                                Email = itm.Email,
                                AccessToken = itm.AccessToken,
                                Photo = itm.Photo,
                                ILang = itm.ILang,
                                Rate = itm.Rate,
                                TRate = itm.TRate,
                                CountryCode = itm.CountryCode,
                                odacc = itm.Odacc,
                                ocacc = itm.Ocacc,
                                dacc = itm.dacc,
                                cacc = itm.cacc,
                                Current_Device = new Device
                                {
                                    one_signal_id = itm.one_signal_id,
                                    app_version = itm.app_version,
                                    device_label = itm.device_label,
                                    device_mac = itm.device_mac,
                                    device_name = itm.device_name,
                                    device_os_version = itm.device_os_version,
                                    device_type = itm.device_type,
                                    fire_base_id = itm.fire_base_id,
                                    login_status = itm.login_status
                                }
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<ShipUsers> GetByOrdTemp(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipUsersFindByOrdTemp(this.OrdTemp);
                    return (from itm in result
                            select new ShipUsers
                            {
                                ID = MyEncryption.base64Decode(itm.ID),
                                Password = MyEncryption.base64Decode(itm.Password),
                                FirstName = itm.FirstName,
                                LastName = itm.LastName,
                                IDNo = itm.IDNo,
                                Num = itm.Num,
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
                                Version = itm.Version,
                                OrdID = itm.OrdID,
                                OrdTemp = itm.OrdTemp,
                                Email = itm.Email,
                                AccessToken = itm.AccessToken,
                                Photo = itm.Photo,
                                ILang = itm.ILang,
                                Rate = itm.Rate,
                                TRate = itm.TRate,
                                CountryCode = itm.CountryCode,
                                odacc = itm.Odacc,
                                ocacc = itm.Ocacc,
                                dacc = itm.dacc,
                                cacc = itm.cacc,
                                Current_Device = new Device
                                {
                                    one_signal_id = itm.one_signal_id,
                                    app_version = itm.app_version,
                                    device_label = itm.device_label,
                                    device_mac = itm.device_mac,
                                    device_name = itm.device_name,
                                    device_os_version = itm.device_os_version,
                                    device_type = itm.device_type,
                                    fire_base_id = itm.fire_base_id,
                                    login_status = itm.login_status
                                }
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
                                Num = itm.Num,
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
                                Version = itm.Version,
                                OrdID = itm.OrdID,
                                OrdTemp = itm.OrdTemp,
                                Email = itm.Email,
                                AccessToken = itm.AccessToken,
                                Photo = itm.Photo,
                                ILang = itm.ILang,
                                Rate = itm.Rate,
                                TRate = itm.TRate,
                                CountryCode = itm.CountryCode,
                                odacc = itm.Odacc,
                                ocacc = itm.Ocacc,
                                dacc = itm.dacc,
                                cacc = itm.cacc,
                                Current_Device = new Device
                                {
                                    one_signal_id = itm.one_signal_id,
                                    app_version = itm.app_version,
                                    device_label = itm.device_label,
                                    device_mac = itm.device_mac,
                                    device_name = itm.device_name,
                                    device_os_version = itm.device_os_version,
                                    device_type = itm.device_type,
                                    fire_base_id = itm.fire_base_id,
                                    login_status = itm.login_status
                                }
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
                                Num = itm.Num,
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
                                Version = itm.Version,
                                OrdID = itm.OrdID,
                                OrdTemp = itm.OrdTemp,
                                Email = itm.Email,
                                AccessToken = itm.AccessToken,
                                Photo = itm.Photo,
                                ILang = itm.ILang,
                                Rate = itm.Rate,
                                TRate = itm.TRate,
                                CountryCode = itm.CountryCode,
                                odacc = itm.Odacc,
                                ocacc = itm.Ocacc,
                                dacc = itm.dacc,
                                cacc = itm.cacc,
                                Current_Device = new Device
                                {
                                    one_signal_id = itm.one_signal_id,
                                    app_version = itm.app_version,
                                    device_label = itm.device_label,
                                    device_mac = itm.device_mac,
                                    device_name = itm.device_name,
                                    device_os_version = itm.device_os_version,
                                    device_type = itm.device_type,
                                    fire_base_id = itm.fire_base_id,
                                    login_status = itm.login_status
                                }
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
                    var result = myContext.ShipUsersFindByOnlineUserType2(this.Online, this.UserType, this.DCareType);
                    return (from itm in result
                            select new ShipUsers
                            {
                                ID = MyEncryption.base64Decode(itm.ID),
                                Password = MyEncryption.base64Decode(itm.Password),
                                FirstName = itm.FirstName,
                                LastName = itm.LastName,
                                IDNo = itm.IDNo,
                                Num = itm.Num,
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
                                Version = itm.Version,
                                OrdID = itm.OrdID,
                                OrdTemp = itm.OrdTemp,
                                Email = itm.Email,
                                AccessToken = itm.AccessToken,
                                Photo = itm.Photo,
                                ILang = itm.ILang,
                                Rate = itm.Rate,
                                TRate = itm.TRate,
                                CountryCode = itm.CountryCode,
                                odacc = itm.Odacc,
                                ocacc = itm.Ocacc,
                                dacc = itm.dacc,
                                cacc = itm.cacc,
                                Current_Device = new Device
                                {
                                    one_signal_id = itm.one_signal_id,
                                    app_version = itm.app_version,
                                    device_label = itm.device_label,
                                    device_mac = itm.device_mac,
                                    device_name = itm.device_name,
                                    device_os_version = itm.device_os_version,
                                    device_type = itm.device_type,
                                    fire_base_id = itm.fire_base_id,
                                    login_status = itm.login_status
                                }
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    /*
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
                                                Version = itm.Version,
                                                OrdID = itm.OrdID,
                                                OrdTemp = itm.OrdTemp
                                            }).ToList());
                        }
                        return myRet;
 */


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
                                Num = itm.Num,
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
                                Version = itm.Version,
                                OrdID = itm.OrdID,
                                OrdTemp = itm.OrdTemp,
                                Email = itm.Email,
                                AccessToken = itm.AccessToken,
                                Photo = itm.Photo,
                                ILang = itm.ILang,
                                Rate = itm.Rate,
                                TRate = itm.TRate,
                                CountryCode = itm.CountryCode,
                                odacc = itm.Odacc,
                                ocacc = itm.Ocacc,
                                dacc = itm.dacc,
                                cacc = itm.cacc,
                                Current_Device = new Device
                                {
                                    one_signal_id = itm.one_signal_id,
                                    app_version = itm.app_version,
                                    device_label = itm.device_label,
                                    device_mac = itm.device_mac,
                                    device_name = itm.device_name,
                                    device_os_version = itm.device_os_version,
                                    device_type = itm.device_type,
                                    fire_base_id = itm.fire_base_id,
                                    login_status = itm.login_status
                                }
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
