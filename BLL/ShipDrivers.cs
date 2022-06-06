using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;


namespace BLL
{
    [Serializable]
    public class ShipDrivers
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
        public System.Nullable<double> InPoints { get; set; }
        public System.Nullable<double> OutPoints { get; set; }
        public System.Nullable<int> Num { get; set; }
        public System.Nullable<double> Bal
        {
            get
            {
                return Math.Round((double)(this.InPoints - this.OutPoints), 2);
            }
        }
        public string Name
        {
            get
            {
                return this.FirstName + " " + this.LastName;
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
        public int? TRate { get; set;}
        public string Gender { get; set; }
        public string DateofBirth { get; set; }
        public string Nationality { get; set; }
        public string YearofRegistration { get; set; }
        public string CarRegistration { get; set; }
        public string Imagebase64 { get; set; }
        public string ImageFileName { get; set; }
        public Device Current_Device { get; set; }
        public string BankAcc1 { get; set; }
        public string BankAcc2 { get; set; }
        public string BankAcc3 { get; set; }
        public string BankAcc4 { get; set; }
        public bool? BankAcc01 { get; set; }
        public bool? BankAcc02 { get; set; }
        public bool? BankAcc03 { get; set; }
        public bool? BankAcc04 { get; set; }
        public string AccountName1 { get; set; }
        public string AccountName2 { get; set; }
        public string AccountName3 { get; set; }
        public string AccountName4 { get; set; }
        public string AccountImage1 { get; set; }
        public string AccountImage2 { get; set; }
        public string AccountImage3 { get; set; }
        public string AccountImage4 { get; set; }
        public string CarOwner { get; set; }
        public string PHDate3 { get; set; }
        public string PHDate4 { get; set; }
        public double? CarWeight { get; set; }
        public string CountryCode { get; set; }
        public double? odacc { get; set; }
        public double? ocacc { get; set; }
        public double? dacc { get; set; }
        public double? cacc { get; set; }
        public double? MyRate
        {

            get
            {
                if (this.TRate > 0) return Math.Round((double)((this.Rate / this.TRate)), 2);
                else return 0;
            }

        }

        public ShipDrivers()
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
            this.Num = 0;
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
            this.Gender = "";
            this.DateofBirth = "";
            this.Nationality = "";
            this.YearofRegistration = "";
            this.CarRegistration = "";
            this.Imagebase64 = "";
            this.ImageFileName = "";
            this.Current_Device = new Device();            
            this.BankAcc1 = "";
            this.BankAcc2 = "";
            this.BankAcc3 = "";
            this.BankAcc4 = "";
            this.BankAcc01 = false;
            this.BankAcc02 = false;
            this.BankAcc03 = false;
            this.BankAcc04 = false;
            this.AccountName1 = "";
            this.AccountName2 = "";
            this.AccountName3 = "";
            this.AccountName4 = "";
            this.AccountImage1 = "";
            this.AccountImage2 = "";
            this.AccountImage3 = "";
            this.AccountImage4 = "";
            this.PHDate3  = "";
            this.PHDate4  = "";
            this.CarWeight  = 0;
            this.CountryCode = "";
            this.CarOwner = "";
            this.odacc = 0;
            this.ocacc = 0;
            this.dacc = 0;
            this.cacc = 0;
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
                    myContext.ShipDriversAdd(MyEncryption.base64Encode(this.ID),
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
                                            this.Email, this.AccessToken, this.Photo, this.ILang,this.Rate,this.TRate,
                                            this.Gender, this.DateofBirth, this.Nationality, this.YearofRegistration,this.CarRegistration,
                                            this.Current_Device.device_mac,
                                            this.Current_Device.device_label,
                                            this.Current_Device.device_os_version,
                                            this.Current_Device.device_name,
                                            this.Current_Device.fire_base_id,
                                            this.Current_Device.one_signal_id,
                                            this.Current_Device.device_type,
                                            this.Current_Device.app_version,
                                            this.Current_Device.login_status,
                                            this.BankAcc1,
                                            this.BankAcc2,
                                            this.BankAcc3,
                                            this.BankAcc4,
                                            this.BankAcc01,
                                            this.BankAcc02,
                                            this.BankAcc03,
                                            this.BankAcc04,
                                            this.AccountName1,
                                            this.AccountName2,
                                            this.AccountName3,
                                            this.AccountName4,
                                            this.AccountImage1,
                                            this.AccountImage2,
                                            this.AccountImage3,
                                            this.AccountImage4,
                                            this.CarOwner,
                                            this.PHDate3,
                                            this.PHDate4,
                                            this.CarWeight,
                                            this.CountryCode, this.odacc, this.ocacc, this.dacc, this.cacc
                                );
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
                    myContext.ShipDriversDelete(MyEncryption.base64Encode(this.ID));
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
                    myContext.ShipDriversUpdate(MyEncryption.base64Encode(this.ID),
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
                                            this.Email, this.AccessToken, this.Photo, this.ILang,this.Rate,this.TRate,
                                            this.Gender, this.DateofBirth, this.Nationality,this.YearofRegistration, this.CarRegistration,
                                            this.Current_Device.device_mac,
                                            this.Current_Device.device_label,
                                            this.Current_Device.device_os_version,
                                            this.Current_Device.device_name,
                                            this.Current_Device.fire_base_id,
                                            this.Current_Device.one_signal_id,
                                            this.Current_Device.device_type,
                                            this.Current_Device.app_version,
                                            this.Current_Device.login_status,
                                            this.BankAcc1,
                                            this.BankAcc2,
                                            this.BankAcc3,
                                            this.BankAcc4,
                                            this.BankAcc01,
                                            this.BankAcc02,
                                            this.BankAcc03,
                                            this.BankAcc04,
                                            this.AccountName1,
                                            this.AccountName2,
                                            this.AccountName3,
                                            this.AccountName4,
                                            this.AccountImage1,
                                            this.AccountImage2,
                                            this.AccountImage3,
                                            this.AccountImage4,
                                            this.CarOwner,
                                            this.PHDate3,
                                            this.PHDate4,
                                            this.CarWeight,
                                            this.CountryCode, this.odacc, this.ocacc, this.dacc, this.cacc
                                            );
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
        public bool updateDevice(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.ShipDriversUpdateInfo2(MyEncryption.base64Encode(this.ID),
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
        public bool updateLoc(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.ShipDriversUpdateLoc(MyEncryption.base64Encode(this.ID),
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
        public bool UpdateBankAcc(string BankAcc,string AccountName,string AccountImage,short? BankNo,string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.ShipDriversUpdateBankAcc(MyEncryption.base64Encode(this.ID),BankAcc,AccountName,AccountImage,BankNo);
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
        public bool UpdateBankApprove(bool? BankAcc, short? BankNo, string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    myContext.ShipDriversUpdateBankAcc2(MyEncryption.base64Encode(this.ID), BankAcc, BankNo);
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
                    myContext.ShipDriversUpdateLang(MyEncryption.base64Encode(this.ID), this.ILang);
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
                    //myContext.ShipDriversUpdateOrders(MyEncryption.base64Encode(this.ID), this.OrdID, this.OrdTemp);
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
                    //myContext.ShipDriversUpdateOrdID(MyEncryption.base64Encode(this.ID), this.OrdID);
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
                    myContext.ShipDriversUpdateOrdTemp(MyEncryption.base64Encode(this.ID), this.OrdTemp);
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
                    myContext.ShipDriversUpdateOnline(MyEncryption.base64Encode(this.ID), this.Online);
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
                    myContext.ShipDriversUpdateVersion(MyEncryption.base64Encode(this.ID), this.Version);
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
        public ShipDrivers find(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipDriversFind(this.ID);

                    return (from itm in result
                            select new ShipDrivers
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
                                OrdTemp = itm.OrdTemp,
                                Email = itm.Email,
                                AccessToken = itm.AccessToken,
                                Photo = itm.Photo,
                                ILang = itm.ILang,
                                Rate = itm.Rate,
                                TRate = itm.TRate,
                                CarRegistration = itm.CarRegistration,
                                DateofBirth = itm.DateofBirth,
                                Gender = itm.Gender,
                                Nationality = itm.Nationality,
                                YearofRegistration = itm.YearofRegistration,
                                BankAcc01 = itm.BankAcc01,
                                BankAcc02 = itm.BankAcc02,
                                BankAcc03 = itm.BankAcc03,
                                BankAcc04 = itm.BankAcc04,
                                BankAcc1 = itm.BankAcc1,
                                BankAcc2 = itm.BankAcc2,
                                BankAcc3 = itm.BankAcc3,
                                BankAcc4 = itm.BankAcc4,
                                AccountImage1 = itm.AccountImage1,
                                AccountImage2 = itm.AccountImage2,
                                AccountImage3 = itm.AccountImage3,
                                AccountImage4 = itm.AccountImage4,
                                AccountName1 = itm.AccountName1,
                                AccountName2 = itm.AccountName2,
                                AccountName3 = itm.AccountName3,
                                AccountName4 = itm.AccountName4,
                                CarWeight = itm.CarWeight,
                                Num = itm.Num,
                                CountryCode = itm.CountryCode,
                                PHDate3 = itm.PHDate3,
                                PHDate4 = itm.PHDate4,                                
                                CarOwner = itm.CarOwner,                               
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
        public ShipDrivers findByMobileNo(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipDriversFindByMobileNo(this.MobileNo);

                    return (from itm in result
                            select new ShipDrivers
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
                                Num = itm.Num,
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
                                CarRegistration = itm.CarRegistration,
                                DateofBirth = itm.DateofBirth,
                                Gender = itm.Gender,
                                Nationality = itm.Nationality,
                                YearofRegistration = itm.YearofRegistration,
                                BankAcc01 = itm.BankAcc01,
                                BankAcc02 = itm.BankAcc02,
                                BankAcc03 = itm.BankAcc03,
                                BankAcc04 = itm.BankAcc04,
                                BankAcc1 = itm.BankAcc1,
                                BankAcc2 = itm.BankAcc2,
                                BankAcc3 = itm.BankAcc3,
                                BankAcc4 = itm.BankAcc4,
                                AccountImage1 = itm.AccountImage1,
                                AccountImage2 = itm.AccountImage2,
                                AccountImage3 = itm.AccountImage3,
                                AccountImage4 = itm.AccountImage4,
                                AccountName1 = itm.AccountName1,
                                AccountName2 = itm.AccountName2,
                                AccountName3 = itm.AccountName3,
                                AccountName4 = itm.AccountName4,
                                CarWeight = itm.CarWeight,
                                CountryCode = itm.CountryCode,
                                PHDate3 = itm.PHDate3,
                                PHDate4 = itm.PHDate4,
                                CarOwner = itm.CarOwner,
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
        public ShipDrivers findByEmail(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipDriversFindByEmail(this.Email);
                    return (from itm in result
                            select new ShipDrivers
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
                                Num = itm.Num,
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
                                CarRegistration = itm.CarRegistration,
                                DateofBirth = itm.DateofBirth,
                                Gender = itm.Gender,
                                Nationality = itm.Nationality,
                                YearofRegistration = itm.YearofRegistration,
                                BankAcc01 = itm.BankAcc01,
                                BankAcc02 = itm.BankAcc02,
                                BankAcc03 = itm.BankAcc03,
                                BankAcc04 = itm.BankAcc04,
                                BankAcc1 = itm.BankAcc1,
                                BankAcc2 = itm.BankAcc2,
                                BankAcc3 = itm.BankAcc3,
                                BankAcc4 = itm.BankAcc4,
                                AccountImage1 = itm.AccountImage1,
                                AccountImage2 = itm.AccountImage2,
                                AccountImage3 = itm.AccountImage3,
                                AccountImage4 = itm.AccountImage4,
                                AccountName1 = itm.AccountName1,
                                AccountName2 = itm.AccountName2,
                                AccountName3 = itm.AccountName3,
                                AccountName4 = itm.AccountName4,
                                CarWeight = itm.CarWeight,
                                CountryCode = itm.CountryCode,
                                PHDate3 = itm.PHDate3,
                                PHDate4 = itm.PHDate4,
                                CarOwner = itm.CarOwner,
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
        public List<ShipDrivers> GetAll(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipDriversGetAll();
                    return (from itm in result
                            select new ShipDrivers
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
                                Num = itm.Num,
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
                                CarRegistration = itm.CarRegistration,
                                DateofBirth = itm.DateofBirth,
                                Gender = itm.Gender,
                                Nationality = itm.Nationality,
                                YearofRegistration = itm.YearofRegistration,
                                BankAcc01 = itm.BankAcc01,
                                BankAcc02 = itm.BankAcc02,
                                BankAcc03 = itm.BankAcc03,
                                BankAcc04 = itm.BankAcc04,
                                BankAcc1 = itm.BankAcc1,
                                BankAcc2 = itm.BankAcc2,
                                BankAcc3 = itm.BankAcc3,
                                BankAcc4 = itm.BankAcc4,
                                AccountImage1 = itm.AccountImage1,
                                AccountImage2 = itm.AccountImage2,
                                AccountImage3 = itm.AccountImage3,
                                AccountImage4 = itm.AccountImage4,
                                AccountName1 = itm.AccountName1,
                                AccountName2 = itm.AccountName2,
                                AccountName3 = itm.AccountName3,
                                AccountName4 = itm.AccountName4,
                                CarWeight = itm.CarWeight,
                                CountryCode = itm.CountryCode,
                                PHDate3 = itm.PHDate3,
                                PHDate4 = itm.PHDate4,
                                CarOwner = itm.CarOwner,
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



        public List<ShipDrivers> GetAll2(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipDriversGetAll2();
                    return (from itm in result
                            select new ShipDrivers
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
                                CarRegistration = itm.CarRegistration,
                                DateofBirth = itm.DateofBirth,
                                Gender = itm.Gender,
                                Nationality = itm.Nationality,
                                YearofRegistration = itm.YearofRegistration,
                                BankAcc01 = itm.BankAcc01,
                                BankAcc02 = itm.BankAcc02,
                                BankAcc03 = itm.BankAcc03,
                                BankAcc04 = itm.BankAcc04,
                                BankAcc1 = itm.BankAcc1,
                                BankAcc2 = itm.BankAcc2,
                                BankAcc3 = itm.BankAcc3,
                                BankAcc4 = itm.BankAcc4,
                                AccountImage1 = itm.AccountImage1,
                                AccountImage2 = itm.AccountImage2,
                                AccountImage3 = itm.AccountImage3,
                                AccountImage4 = itm.AccountImage4,
                                AccountName1 = itm.AccountName1,
                                AccountName2 = itm.AccountName2,
                                AccountName3 = itm.AccountName3,
                                AccountName4 = itm.AccountName4,
                                CarWeight = itm.CarWeight,
                                CountryCode = itm.CountryCode,
                                PHDate3 = itm.PHDate3,
                                PHDate4 = itm.PHDate4,
                                CarOwner = itm.CarOwner,
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


        public List<ShipDrivers> GetByOrdTemp(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipDriversFindByOrdTemp(this.OrdTemp);
                    return (from itm in result
                            select new ShipDrivers
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
                                Num = itm.Num,
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
                                CarRegistration = itm.CarRegistration,
                                DateofBirth = itm.DateofBirth,
                                Gender = itm.Gender,
                                Nationality = itm.Nationality,
                                YearofRegistration = itm.YearofRegistration,
                                BankAcc01 = itm.BankAcc01,
                                BankAcc02 = itm.BankAcc02,
                                BankAcc03 = itm.BankAcc03,
                                BankAcc04 = itm.BankAcc04,
                                BankAcc1 = itm.BankAcc1,
                                BankAcc2 = itm.BankAcc2,
                                BankAcc3 = itm.BankAcc3,
                                BankAcc4 = itm.BankAcc4,
                                AccountImage1 = itm.AccountImage1,
                                AccountImage2 = itm.AccountImage2,
                                AccountImage3 = itm.AccountImage3,
                                AccountImage4 = itm.AccountImage4,
                                AccountName1 = itm.AccountName1,
                                AccountName2 = itm.AccountName2,
                                AccountName3 = itm.AccountName3,
                                AccountName4 = itm.AccountName4,
                                CarWeight = itm.CarWeight,
                                CountryCode = itm.CountryCode,
                                PHDate3 = itm.PHDate3,
                                PHDate4 = itm.PHDate4,
                                CarOwner = itm.CarOwner,
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


        public List<ShipDrivers> GetByUserType(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipDriversFindByUserType(this.UserType);
                    return (from itm in result
                            select new ShipDrivers
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
                                Num = itm.Num,
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
                                CarRegistration = itm.CarRegistration,
                                DateofBirth = itm.DateofBirth,
                                Gender = itm.Gender,
                                Nationality = itm.Nationality,
                                YearofRegistration = itm.YearofRegistration,
                                BankAcc01 = itm.BankAcc01,
                                BankAcc02 = itm.BankAcc02,
                                BankAcc03 = itm.BankAcc03,
                                BankAcc04 = itm.BankAcc04,
                                BankAcc1 = itm.BankAcc1,
                                BankAcc2 = itm.BankAcc2,
                                BankAcc3 = itm.BankAcc3,
                                BankAcc4 = itm.BankAcc4,
                                AccountImage1 = itm.AccountImage1,
                                AccountImage2 = itm.AccountImage2,
                                AccountImage3 = itm.AccountImage3,
                                AccountImage4 = itm.AccountImage4,
                                AccountName1 = itm.AccountName1,
                                AccountName2 = itm.AccountName2,
                                AccountName3 = itm.AccountName3,
                                AccountName4 = itm.AccountName4,
                                CarWeight = itm.CarWeight,
                                CountryCode = itm.CountryCode,
                                PHDate3 = itm.PHDate3,
                                PHDate4 = itm.PHDate4,
                                CarOwner = itm.CarOwner,
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


        public List<ShipDrivers> GetByOnlineUserType(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipDriversFindByOnlineUserType(this.Online, this.UserType);
                    return (from itm in result
                            select new ShipDrivers
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
                                Num = itm.Num,
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
                                CarRegistration = itm.CarRegistration,
                                DateofBirth = itm.DateofBirth,
                                Gender = itm.Gender,
                                Nationality = itm.Nationality,
                                YearofRegistration = itm.YearofRegistration,
                                BankAcc01 = itm.BankAcc01,
                                BankAcc02 = itm.BankAcc02,
                                BankAcc03 = itm.BankAcc03,
                                BankAcc04 = itm.BankAcc04,
                                BankAcc1 = itm.BankAcc1,
                                BankAcc2 = itm.BankAcc2,
                                BankAcc3 = itm.BankAcc3,
                                BankAcc4 = itm.BankAcc4,
                                AccountImage1 = itm.AccountImage1,
                                AccountImage2 = itm.AccountImage2,
                                AccountImage3 = itm.AccountImage3,
                                AccountImage4 = itm.AccountImage4,
                                AccountName1 = itm.AccountName1,
                                AccountName2 = itm.AccountName2,
                                AccountName3 = itm.AccountName3,
                                AccountName4 = itm.AccountName4,
                                CarWeight = itm.CarWeight,
                                CountryCode = itm.CountryCode,
                                PHDate3 = itm.PHDate3,
                                PHDate4 = itm.PHDate4,
                                CarOwner = itm.CarOwner,
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


        public List<ShipDrivers> GetByOnlineUserType2(string ConnectionStr, int cartype1)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipDriversFindByOnlineUserType2(this.Online, this.UserType, this.DCareType);
                    return (from itm in result
                            select new ShipDrivers
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
                                Num = itm.Num,
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
                                CarRegistration = itm.CarRegistration,
                                DateofBirth = itm.DateofBirth,
                                Gender = itm.Gender,
                                Nationality = itm.Nationality,
                                YearofRegistration = itm.YearofRegistration,
                                BankAcc01 = itm.BankAcc01,
                                BankAcc02 = itm.BankAcc02,
                                BankAcc03 = itm.BankAcc03,
                                BankAcc04 = itm.BankAcc04,
                                BankAcc1 = itm.BankAcc1,
                                BankAcc2 = itm.BankAcc2,
                                BankAcc3 = itm.BankAcc3,
                                BankAcc4 = itm.BankAcc4,
                                AccountImage1 = itm.AccountImage1,
                                AccountImage2 = itm.AccountImage2,
                                AccountImage3 = itm.AccountImage3,
                                AccountImage4 = itm.AccountImage4,
                                AccountName1 = itm.AccountName1,
                                AccountName2 = itm.AccountName2,
                                AccountName3 = itm.AccountName3,
                                AccountName4 = itm.AccountName4,
                                CarWeight = itm.CarWeight,
                                CountryCode = itm.CountryCode,
                                PHDate3 = itm.PHDate3,
                                PHDate4 = itm.PHDate4,
                                CarOwner = itm.CarOwner,
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

                            List<ShipDrivers> myRet = new List<ShipDrivers>();
                            foreach (var itm2 in result2)
                            {
                                myRet.AddRange((from itm in result
                                                where MyEncryption.base64Decode(itm.ID) == itm2.DriverCode
                                                select new ShipDrivers
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


        public List<ShipDrivers> GetByOnline(string ConnectionStr)
        {
            try
            {
                using (DataERP3DataContext myContext = new DataERP3DataContext(ConnectionStr))
                {
                    var result = myContext.ShipDriversFindByOnline(this.Online);
                    return (from itm in result
                            select new ShipDrivers
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
                                Num = itm.Num,
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
                                CarRegistration = itm.CarRegistration,
                                DateofBirth = itm.DateofBirth,
                                Gender = itm.Gender,
                                Nationality = itm.Nationality,
                                YearofRegistration = itm.YearofRegistration,
                                BankAcc01 = itm.BankAcc01,
                                BankAcc02 = itm.BankAcc02,
                                BankAcc03 = itm.BankAcc03,
                                BankAcc04 = itm.BankAcc04,
                                BankAcc1 = itm.BankAcc1,
                                BankAcc2 = itm.BankAcc2,
                                BankAcc3 = itm.BankAcc3,
                                BankAcc4 = itm.BankAcc4,
                                AccountImage1 = itm.AccountImage1,
                                AccountImage2 = itm.AccountImage2,
                                AccountImage3 = itm.AccountImage3,
                                AccountImage4 = itm.AccountImage4,
                                AccountName1 = itm.AccountName1,
                                AccountName2 = itm.AccountName2,
                                AccountName3 = itm.AccountName3,
                                AccountName4 = itm.AccountName4,
                                CarWeight = itm.CarWeight,
                                CountryCode = itm.CountryCode,
                                PHDate3 = itm.PHDate3,
                                PHDate4 = itm.PHDate4,
                                CarOwner = itm.CarOwner,
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
